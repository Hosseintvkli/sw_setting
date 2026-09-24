"""Commands: apply-profile, verify-profile, save-profile, parse-profile."""

from __future__ import annotations

from pathlib import Path

from commands.context import CommandSessionContext
from commands.registry import CommandRegistry
from commands.result import CommandResult, failure, success
from core.codegen_parameter_list_models import ParameterAccessKind
from core.device_modbus_link import DeviceModbusLinkError
from core.device_command_executor import (
    COMMAND_TRIGGER_VALUE_U16,
    DeviceCommandExecutor,
)
from core.device_setting_tree_loader import (
    DeviceSettingTreeLoader,
    DeviceSettingTreeLoadCancelled,
    DeviceSettingTreeLoaderError,
)
from core.modbus_register_value_codec import (
    ModbusRegisterValueCodecError,
    decode_parameter_value_from_holding_registers,
    encode_parameter_value_to_holding_registers,
    register_count_for_data_type_name,
)
from core.parameter_value_validation import ParameterValueValidationError
from core.setting_profile_csv import (
    load_setting_profile_assignments_from_csv,
    save_setting_profile_csv,
)


def register(registry: CommandRegistry) -> None:
    registry.register("apply-profile", handle_apply_profile)
    registry.register("verify-profile", handle_verify_profile)
    registry.register("save-profile", handle_save_profile)
    registry.register("parse-profile", handle_parse_profile)


def _emit_operation_progress(
    context: CommandSessionContext,
    operation: str,
    current: int,
    total: int,
    message: str,
    phase: str,
) -> None:
    progress = getattr(context, "progress", None)
    if callable(progress):
        progress(
            "operation_progress",
            message,
            {
                "operation": operation,
                "current": current,
                "total": total,
                "phase": phase,
            },
        )


def handle_apply_profile(context: CommandSessionContext, args) -> CommandResult:
    return _run_profile(context, args, verify_only=False, command_name="apply-profile")


def handle_verify_profile(context: CommandSessionContext, args) -> CommandResult:
    return _run_profile(context, args, verify_only=True, command_name="verify-profile")


def _run_profile(
    context: CommandSessionContext, args, verify_only: bool, command_name: str
) -> CommandResult:
    try:
        context.require_connected()
        package = context.loaded_package()
    except RuntimeError as exc:
        return failure(command_name, str(exc))

    csv_path = Path(args.file)
    if not csv_path.is_file():
        return failure(command_name, f"File not found: {csv_path}")

    parse_result = load_setting_profile_assignments_from_csv(
        csv_path, package, include_commands=True
    )
    issues = [
        {"line": i.source_csv_line_number, "message": i.message}
        for i in parse_result.issues
    ]

    current_device_id = context.last_settings_load_result.device_id_from_device
    current_unit = context.selected_slave_id
    if current_unit is None:
        try:
            current_unit = (
                context.device_modbus_link.get_effective_modbus_unit_identifier()
            )
        except Exception:
            current_unit = 1

    targets: list[tuple[int, str]] = []
    incompatible_targets: list[dict] = []
    if getattr(args, "all_same_device_id", False):
        identify = context.last_identify_result
        if identify is None or identify.root_node is None:
            return failure(command_name, "Run identify before --all-same-device-id.")
        else:
            for node in identify.root_node.iter_depth_first():
                if node.device_id == current_device_id:
                    reason: str | None = None
                    if node.parameter_list_package is None:
                        reason = "parameter-list JSON is unavailable"
                    elif node.parameter_list_version != package.parameter_list_version:
                        reason = (
                            "parameter-list version differs "
                            f"({node.parameter_list_version} != "
                            f"{package.parameter_list_version})"
                        )
                    else:
                        available_names = {
                            parameter.parameter_name
                            for parameter in node.parameter_list_package.parameters
                        }
                        missing_names = sorted(
                            assignment.parameter_name
                            for assignment in parse_result.assignments
                            if assignment.parameter_name not in available_names
                        )
                        if missing_names:
                            reason = f"{len(missing_names)} profile parameter(s) are unavailable"
                    if reason is not None:
                        incompatible_targets.append(
                            {
                                "slave_id": node.permanent_modbus_slave_id,
                                "name": node.device_name,
                                "reason": reason,
                            }
                        )
                        continue
                    targets.append((node.permanent_modbus_slave_id, node.device_name))
            if not targets:
                if not incompatible_targets:
                    return failure(
                        command_name, "No matching devices in the Identify topology."
                    )
    else:
        targets.append((int(current_unit), "current"))

    allow_partial = bool(getattr(args, "allow_partial", False))
    skip_incompatible = bool(getattr(args, "skip_incompatible", False))
    needs_issue_confirmation = bool(issues) and not allow_partial
    needs_target_confirmation = bool(incompatible_targets) and not skip_incompatible
    if needs_issue_confirmation or needs_target_confirmation:
        return CommandResult(
            ok=False,
            command=command_name,
            data={
                "file": str(csv_path),
                "requires_confirmation": True,
                "parse_issues": issues,
                "incompatible_targets": incompatible_targets,
                "compatible_target_count": len(targets),
            },
            error="Profile contains invalid rows or incompatible target devices.",
            exit_code=3,
        )

    if not targets:
        return failure(command_name, "No compatible target devices remain.")

    previous_override = getattr(
        context.device_modbus_link, "_modbus_unit_identifier_override", None
    )
    ok_count = 0
    fail_count = 0 if allow_partial else len(issues)
    skipped_count = (len(issues) if allow_partial else 0) + len(incompatible_targets)
    details: list[dict] = []
    cancelled = False
    progress_current = 0
    progress_total = max(1, len(targets) * len(parse_result.assignments))

    def report_progress(message: str, phase: str) -> None:
        _emit_operation_progress(
            context,
            command_name,
            progress_current,
            progress_total,
            message,
            phase,
        )

    report_progress(
        "Preparing profile verification..."
        if verify_only
        else "Preparing profile application...",
        "prepare",
    )
    try:
        for slave_id, target_name in targets:
            if context.cancel_check is not None and context.cancel_check():
                cancelled = True
                break
            context.device_modbus_link.set_modbus_unit_identifier_override(slave_id)
            for assignment in parse_result.assignments:
                if context.cancel_check is not None and context.cancel_check():
                    cancelled = True
                    break
                definition = assignment.parameter_definition
                if (
                    not verify_only
                    and getattr(args, "all_same_device_id", False)
                    and definition.parameter_access_kind
                    == ParameterAccessKind.COMMAND_WRITE
                    and assignment.parsed_value == COMMAND_TRIGGER_VALUE_U16
                ):
                    # Trigger this command on every target only after the
                    # ordinary profile writes have finished on every target.
                    continue
                try:
                    if verify_only:
                        count = definition.modbus_register_size
                        if count <= 0:
                            count = register_count_for_data_type_name(
                                definition.data_type_name
                            )
                        registers = (
                            context.device_modbus_link.read_holding_registers_u16(
                                definition.modbus_address,
                                count,
                                modbus_unit_identifier=slave_id,
                            )
                        )
                        device_value = decode_parameter_value_from_holding_registers(
                            definition.data_type_name, registers
                        )
                        if device_value != assignment.parsed_value:
                            # soft compare floats
                            if isinstance(device_value, float) and isinstance(
                                assignment.parsed_value, float
                            ):
                                if abs(device_value - assignment.parsed_value) < 1e-6:
                                    ok_count += 1
                                    if args.verbose:
                                        details.append(
                                            {
                                                "slave_id": slave_id,
                                                "name": assignment.parameter_name,
                                                "ok": True,
                                            }
                                        )
                                    progress_current += 1
                                    report_progress(
                                        f"Verified {assignment.parameter_name} on "
                                        f"SlaveId={slave_id}",
                                        "verify",
                                    )
                                    continue
                            raise DeviceModbusLinkError(
                                f"Mismatch device={device_value!r} "
                                f"csv={assignment.parsed_value!r}"
                            )
                    else:
                        registers = encode_parameter_value_to_holding_registers(
                            definition.data_type_name, assignment.parsed_value
                        )
                        context.device_modbus_link.write_holding_registers_u16(
                            definition.modbus_address,
                            registers,
                            modbus_unit_identifier=slave_id,
                        )
                    ok_count += 1
                    if args.verbose:
                        details.append(
                            {
                                "slave_id": slave_id,
                                "name": assignment.parameter_name,
                                "ok": True,
                            }
                        )
                except (
                    DeviceModbusLinkError,
                    ModbusRegisterValueCodecError,
                    ParameterValueValidationError,
                ) as exc:
                    fail_count += 1
                    details.append(
                        {
                            "slave_id": slave_id,
                            "name": assignment.parameter_name,
                            "ok": False,
                            "error": str(exc),
                        }
                    )
                progress_current += 1
                report_progress(
                    (
                        f"Verified {assignment.parameter_name} on SlaveId={slave_id}"
                        if verify_only
                        else f"Applied {assignment.parameter_name} on SlaveId={slave_id}"
                    ),
                    "verify" if verify_only else "write",
                )
            if cancelled:
                break
        if (
            not cancelled
            and not verify_only
            and getattr(args, "all_same_device_id", False)
        ):
            executor = DeviceCommandExecutor(
                context.device_modbus_link,
                cancel_check=context.cancel_check,
            )
            for assignment in parse_result.assignments:
                if context.cancel_check is not None and context.cancel_check():
                    cancelled = True
                    break
                definition = assignment.parameter_definition
                if (
                    definition.parameter_access_kind
                    != ParameterAccessKind.COMMAND_WRITE
                    or assignment.parsed_value != COMMAND_TRIGGER_VALUE_U16
                ):
                    continue
                command_progress_base = progress_current
                results = executor.execute_command_for_units(
                    definition.modbus_address,
                    [slave_id for slave_id, _ in targets],
                    progress_callback=lambda current, total, message, base=command_progress_base: _emit_operation_progress(
                        context,
                        command_name,
                        base + current,
                        progress_total,
                        message,
                        "command",
                    ),
                )
                for slave_id, _ in targets:
                    command_result = results[slave_id]
                    if command_result.success:
                        ok_count += 1
                    else:
                        fail_count += 1
                    if args.verbose or not command_result.success:
                        details.append(
                            {
                                "slave_id": slave_id,
                                "name": assignment.parameter_name,
                                "ok": command_result.success,
                                "message": command_result.message,
                                "last_read_value": command_result.last_read_value,
                            }
                        )
                    progress_current += 1
                    report_progress(
                        f"Executed {assignment.parameter_name} on SlaveId={slave_id}",
                        "command",
                    )
    finally:
        context.device_modbus_link.set_modbus_unit_identifier_override(
            previous_override
        )

    data = {
        "file": str(csv_path),
        "verify_only": verify_only,
        "targets": [{"slave_id": s, "name": n} for s, n in targets],
        "ok_count": ok_count,
        "fail_count": fail_count,
        "skipped_count": skipped_count,
        "parse_issues": issues,
        "incompatible_targets": incompatible_targets,
    }
    if args.verbose:
        data["details"] = details
    if cancelled:
        return CommandResult(
            ok=False,
            command=command_name,
            data=data,
            error="Profile operation cancelled by user.",
            exit_code=130,
        )
    return (
        success(command_name, data)
        if fail_count == 0
        else CommandResult_partial(command_name, data, fail_count)
    )


def CommandResult_partial(
    command_name: str, data: dict, fail_count: int
) -> CommandResult:
    from commands.result import CommandResult

    return CommandResult(
        ok=fail_count == 0,
        command=command_name,
        data=data,
        error=None if fail_count == 0 else f"{fail_count} failure(s)",
        exit_code=0 if fail_count == 0 else 1,
    )


def handle_save_profile(context: CommandSessionContext, args) -> CommandResult:
    try:
        context.require_connected()
        slave_id = context.effective_slave_id(None)
    except RuntimeError as exc:
        return failure("save-profile", str(exc))

    # Reload first
    loader = DeviceSettingTreeLoader(
        device_modbus_link=context.device_modbus_link,
        modbus_slave_unit_identifier=slave_id,
        codegen_json_root_directory=context.codegen_json_root_directory,
        cancel_check=context.cancel_check,
    )
    try:
        result = loader.load_setting_tree_from_connected_device(
            progress_callback=lambda current, total, message: _emit_operation_progress(
                context,
                "save-profile",
                min(95, round(95 * current / max(total, 1))),
                100,
                message,
                "read",
            )
        )
    except DeviceSettingTreeLoadCancelled as exc:
        return failure("save-profile", str(exc), exit_code=130)
    except DeviceSettingTreeLoaderError as exc:
        return failure("save-profile", f"Reload failed: {exc}")

    context.last_settings_load_result = result
    selected_tag_1_values = getattr(args, "tag1", None)
    selected_tag_1 = (
        {str(tag) for tag in selected_tag_1_values}
        if selected_tag_1_values is not None
        else None
    )
    grouped_rows_by_tag_1: dict[str, list[tuple[str, str]]] = {}
    for leaf in result.setting_leaf_values:
        if leaf.read_error_message:
            continue
        tag_1 = str(leaf.parameter.category_tag_1 or "")
        if selected_tag_1 is not None and tag_1 not in selected_tag_1:
            continue
        grouped_rows_by_tag_1.setdefault(tag_1, []).append(
            (leaf.parameter.parameter_name, leaf.display_value_text)
        )
    if not grouped_rows_by_tag_1:
        return failure("save-profile", "No settings match the selected Tag1 categories.")

    grouped_rows = list(grouped_rows_by_tag_1.items())
    csv_path = Path(args.file)
    _emit_operation_progress(
        context,
        "save-profile",
        95,
        100,
        "Writing profile CSV...",
        "write-file",
    )
    try:
        header = result.monitoring_header_values
        save_setting_profile_csv(
            csv_path,
            grouped_rows,
            serial_number=header.serial_number,
            firmware_version=header.firmware_version_text,
            hardware_version=header.hardware_version_text,
        )
    except OSError as exc:
        return failure("save-profile", str(exc))

    _emit_operation_progress(
        context,
        "save-profile",
        100,
        100,
        "Profile saved.",
        "done",
    )
    return success(
        "save-profile",
        {
            "file": str(csv_path),
            "row_count": sum(len(rows) for _, rows in grouped_rows),
            "tag1_categories": [tag_1 for tag_1, _ in grouped_rows],
            "slave_id": slave_id,
        },
    )


def handle_parse_profile(context: CommandSessionContext, args) -> CommandResult:
    try:
        package = context.loaded_package()
    except RuntimeError as exc:
        return failure("parse-profile", str(exc))

    csv_path = Path(args.file)
    if not csv_path.is_file():
        return failure("parse-profile", f"File not found: {csv_path}")

    parse_result = load_setting_profile_assignments_from_csv(
        csv_path, package, include_commands=True
    )
    return success(
        "parse-profile",
        {
            "file": str(csv_path),
            "assignment_count": len(parse_result.assignments),
            "issues": [
                {"line": i.source_csv_line_number, "message": i.message}
                for i in parse_result.issues
            ],
        },
    )
