"""Commands: load-settings, reload-settings, get/set-parameter, list-parameters, monitoring."""

from __future__ import annotations

from commands.context import CommandSessionContext
from commands.registry import CommandRegistry
from commands.result import CommandResult, failure, success
from core.codegen_parameter_list_models import ParameterAccessKind
from core.device_modbus_link import DeviceModbusLinkError
from core.device_setting_tree_loader import (
    DeviceSettingTreeLoader,
    DeviceSettingTreeLoaderError,
)
from core.modbus_register_value_codec import (
    ModbusRegisterValueCodecError,
    decode_parameter_value_from_holding_registers,
    encode_parameter_value_to_holding_registers,
    format_decoded_parameter_value_for_display,
    register_count_for_data_type_name,
)
from core.parameter_value_validation import (
    ParameterValueValidationError,
    parse_and_validate_parameter_value_text,
)


def register(registry: CommandRegistry) -> None:
    registry.register("load-settings", handle_load_settings)
    registry.register("reload-settings", handle_reload_settings)
    registry.register("get-parameter", handle_get_parameter)
    registry.register("set-parameter", handle_set_parameter)
    registry.register("list-parameters", handle_list_parameters)
    registry.register("get-monitoring-header", handle_get_monitoring_header)


def handle_load_settings(context: CommandSessionContext, args) -> CommandResult:
    return _load_settings_impl(context, args, command_name="load-settings")


def handle_reload_settings(context: CommandSessionContext, args) -> CommandResult:
    return _load_settings_impl(context, args, command_name="reload-settings")


def _loaded_package_for_slave(context: CommandSessionContext, slave_id: int):
    """Return loaded parameter metadata only when it belongs to this slave."""
    load = context.last_settings_load_result
    if load is None:
        raise RuntimeError("Settings not loaded. Run: load-settings")

    loaded_slave_id = load.monitoring_header_values.modbus_slave_unit_identifier
    if loaded_slave_id != slave_id:
        raise RuntimeError(
            f"Settings are loaded for SlaveId {loaded_slave_id}, not {slave_id}. "
            f"Run: load-settings --slave-id {slave_id}"
        )
    return load.parameter_list_package


def _load_settings_impl(
    context: CommandSessionContext, args, command_name: str
) -> CommandResult:
    try:
        context.require_connected()
        slave_id = context.effective_slave_id(getattr(args, "slave_id", None))
    except RuntimeError as exc:
        return failure(command_name, str(exc))

    context.device_modbus_link.set_modbus_unit_identifier_override(slave_id)
    context.selected_slave_id = slave_id
    context.log(f"Loading settings (SlaveId/unit={slave_id})...")

    loader = DeviceSettingTreeLoader(
        device_modbus_link=context.device_modbus_link,
        modbus_slave_unit_identifier=slave_id,
        codegen_json_root_directory=context.codegen_json_root_directory,
    )
    try:
        result = loader.load_setting_tree_from_connected_device(
            progress_callback=lambda c, t, m: context.log(m)
        )
    except DeviceSettingTreeLoaderError as exc:
        return failure(command_name, str(exc))

    context.last_settings_load_result = result
    error_count = sum(1 for leaf in result.setting_leaf_values if leaf.read_error_message)
    data = {
        "slave_id": slave_id,
        "device_id": result.device_id_from_device,
        "parameter_list_version": result.parameter_list_version_from_device,
        "device_name": result.parameter_list_package.info.device_name,
        "setting_count": len(result.setting_leaf_values),
        "error_count": error_count,
    }
    if getattr(args, "dump_values", False):
        data["values"] = [
            {
                "name": leaf.parameter.parameter_name,
                "value": leaf.display_value_text,
                "modbus_addr": leaf.parameter.modbus_address,
                "data_type": leaf.parameter.data_type_name,
                "tag2": leaf.parameter.tag_2,
                "name_path_segments": leaf.parameter.name_path_segments,
                "error": leaf.read_error_message,
            }
            for leaf in result.setting_leaf_values
        ]
    return success(command_name, data)


def handle_get_parameter(context: CommandSessionContext, args) -> CommandResult:
    try:
        context.require_connected()
        slave_id = context.effective_slave_id(getattr(args, "slave_id", None))
        package = _loaded_package_for_slave(context, slave_id)
    except RuntimeError as exc:
        return failure("get-parameter", str(exc))

    name = str(args.name)
    parameter = next((p for p in package.parameters if p.parameter_name == name), None)
    if parameter is None:
        return failure("get-parameter", f"Unknown parameter: {name}")

    count = parameter.modbus_register_size
    if count <= 0:
        count = register_count_for_data_type_name(parameter.data_type_name)
    try:
        registers = context.device_modbus_link.read_holding_registers_u16(
            parameter.modbus_address,
            count,
            modbus_unit_identifier=slave_id,
        )
        value = decode_parameter_value_from_holding_registers(
            parameter.data_type_name, registers
        )
        text = format_decoded_parameter_value_for_display(
            parameter.data_type_name, value
        )
    except (DeviceModbusLinkError, ModbusRegisterValueCodecError) as exc:
        return failure("get-parameter", str(exc))

    return success(
        "get-parameter",
        {
            "name": name,
            "value": value,
            "display": text,
            "data_type": parameter.data_type_name,
            "modbus_addr": parameter.modbus_address,
            "slave_id": slave_id,
        },
    )


def handle_set_parameter(context: CommandSessionContext, args) -> CommandResult:
    try:
        context.require_connected()
        slave_id = context.effective_slave_id(getattr(args, "slave_id", None))
        package = _loaded_package_for_slave(context, slave_id)
    except RuntimeError as exc:
        return failure("set-parameter", str(exc))

    name = str(args.name)
    parameter = next((p for p in package.parameters if p.parameter_name == name), None)
    if parameter is None:
        return failure("set-parameter", f"Unknown parameter: {name}")
    if parameter.parameter_access_kind != ParameterAccessKind.SETTING_READ_WRITE:
        return failure(
            "set-parameter",
            f"Parameter '{name}' is not writable as a setting "
            f"(kind: {parameter.parameter_access_kind.value}).",
        )

    try:
        parsed_value = parse_and_validate_parameter_value_text(
            parameter.data_type_name, str(args.value)
        )
        registers = encode_parameter_value_to_holding_registers(
            parameter.data_type_name, parsed_value
        )
        context.device_modbus_link.write_holding_registers_u16(
            parameter.modbus_address,
            registers,
            modbus_unit_identifier=slave_id,
        )
    except (
        ParameterValueValidationError,
        ModbusRegisterValueCodecError,
        DeviceModbusLinkError,
    ) as exc:
        return failure("set-parameter", str(exc))

    return success(
        "set-parameter",
        {
            "name": name,
            "value": parsed_value,
            "display": format_decoded_parameter_value_for_display(
                parameter.data_type_name, parsed_value
            ),
            "modbus_addr": parameter.modbus_address,
            "slave_id": slave_id,
        },
    )


def handle_list_parameters(context: CommandSessionContext, args) -> CommandResult:
    try:
        package = context.loaded_package()
    except RuntimeError as exc:
        return failure("list-parameters", str(exc))

    filter_kind = getattr(args, "parameter_type_filter", "setting")
    tag2 = getattr(args, "tag2", None)
    items = []
    for parameter in package.parameters:
        kind = parameter.parameter_access_kind
        if filter_kind == "setting" and kind != ParameterAccessKind.SETTING_READ_WRITE:
            continue
        elif filter_kind == "command" and kind != ParameterAccessKind.COMMAND_WRITE:
            continue
        if tag2 is not None and parameter.tag_2 != tag2:
            continue
        items.append(
            {
                "name": parameter.parameter_name,
                "modbus_addr": parameter.modbus_address,
                "data_type": parameter.data_type_name,
                "kind": kind.value,
                "tag2": parameter.tag_2,
            }
        )
    return success("list-parameters", {"count": len(items), "parameters": items})


def handle_get_monitoring_header(context: CommandSessionContext, args) -> CommandResult:
    try:
        context.require_connected()
        slave_id = context.effective_slave_id(getattr(args, "slave_id", None))
    except RuntimeError as exc:
        return failure("get-monitoring-header", str(exc))

    # Prefer the cached header only when it belongs to the requested unit.
    load = context.last_settings_load_result
    if (
        load is not None
        and load.monitoring_header_values.modbus_slave_unit_identifier == slave_id
    ):
        header = load.monitoring_header_values
        return success(
            "get-monitoring-header",
            {
                "slave_id": slave_id,
                "device_id": load.device_id_from_device,
                "parameter_list_version": load.parameter_list_version_from_device,
                "firmware_version": getattr(header, "firmware_version_text", None),
                "hardware_version": getattr(header, "hardware_version_text", None),
                "serial_number": getattr(header, "serial_number", None),
            },
        )

    try:
        device_id = context.device_modbus_link.read_holding_register_u16(
            0, modbus_unit_identifier=slave_id
        )
        version = context.device_modbus_link.read_holding_register_u16(
            1, modbus_unit_identifier=slave_id
        )
    except DeviceModbusLinkError as exc:
        return failure("get-monitoring-header", str(exc))

    return success(
        "get-monitoring-header",
        {
            "slave_id": slave_id,
            "device_id": device_id,
            "parameter_list_version": version,
        },
    )
