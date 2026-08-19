"""Commands: apply-profile, verify-profile, save-profile, parse-profile."""

from __future__ import annotations

from pathlib import Path

from commands.context import CommandSessionContext
from commands.registry import CommandRegistry
from commands.result import CommandResult, failure, success
from core.device_modbus_link import DeviceModbusLinkError
from core.device_setting_tree_loader import (
    DeviceSettingTreeLoader,
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

    parse_result = load_setting_profile_assignments_from_csv(csv_path, package)
    issues = [
        {"line": i.source_csv_line_number, "message": i.message}
        for i in parse_result.issues
    ]

    current_device_id = context.last_settings_load_result.device_id_from_device
    current_unit = context.selected_slave_id
    if current_unit is None:
        try:
            current_unit = context.device_modbus_link.get_effective_modbus_unit_identifier()
        except Exception:
            current_unit = 1

    targets: list[tuple[int, str]] = []
    if getattr(args, "all_same_device_id", False):
        identify = context.last_identify_result
        if identify is None or identify.root_node is None:
            targets.append((int(current_unit), "current"))
        else:
            for node in identify.root_node.iter_depth_first():
                if node.device_id == current_device_id:
                    targets.append(
                        (node.permanent_modbus_slave_id, node.device_name)
                    )
            if not targets:
                targets.append((int(current_unit), "current"))
    else:
        targets.append((int(current_unit), "current"))

    previous_override = getattr(
        context.device_modbus_link, "_modbus_unit_identifier_override", None
    )
    ok_count = 0
    fail_count = len(issues)
    details: list[dict] = []

    try:
        for slave_id, target_name in targets:
            context.device_modbus_link.set_modbus_unit_identifier_override(slave_id)
            for assignment in parse_result.assignments:
                definition = assignment.parameter_definition
                try:
                    if verify_only:
                        count = definition.modbus_register_size
                        if count <= 0:
                            count = register_count_for_data_type_name(
                                definition.data_type_name
                            )
                        registers = context.device_modbus_link.read_holding_registers_u16(
                            definition.modbus_address,
                            count,
                            modbus_unit_identifier=slave_id,
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
    finally:
        context.device_modbus_link.set_modbus_unit_identifier_override(previous_override)

    data = {
        "file": str(csv_path),
        "verify_only": verify_only,
        "targets": [{"slave_id": s, "name": n} for s, n in targets],
        "ok_count": ok_count,
        "fail_count": fail_count,
        "parse_issues": issues,
    }
    if args.verbose:
        data["details"] = details
    return success(command_name, data) if fail_count == 0 else CommandResult_partial(
        command_name, data, fail_count
    )


def CommandResult_partial(command_name: str, data: dict, fail_count: int) -> CommandResult:
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
    )
    try:
        result = loader.load_setting_tree_from_connected_device()
    except DeviceSettingTreeLoaderError as exc:
        return failure("save-profile", f"Reload failed: {exc}")

    context.last_settings_load_result = result
    rows = [
        (leaf.parameter.parameter_name, leaf.display_value_text)
        for leaf in result.setting_leaf_values
        if not leaf.read_error_message
    ]
    csv_path = Path(args.file)
    try:
        save_setting_profile_csv(csv_path, rows)
    except OSError as exc:
        return failure("save-profile", str(exc))

    return success(
        "save-profile",
        {"file": str(csv_path), "row_count": len(rows), "slave_id": slave_id},
    )


def handle_parse_profile(context: CommandSessionContext, args) -> CommandResult:
    try:
        package = context.loaded_package()
    except RuntimeError as exc:
        return failure("parse-profile", str(exc))

    csv_path = Path(args.file)
    if not csv_path.is_file():
        return failure("parse-profile", f"File not found: {csv_path}")

    parse_result = load_setting_profile_assignments_from_csv(csv_path, package)
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
