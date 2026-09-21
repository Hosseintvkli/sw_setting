"""Commands: list-commands, execute-command."""

from __future__ import annotations

from commands.context import CommandSessionContext
from commands.registry import CommandRegistry
from commands.result import CommandResult, failure, success
from core.codegen_parameter_list_models import ParameterAccessKind
from core.device_command_executor import DeviceCommandExecutor


def register(registry: CommandRegistry) -> None:
    registry.register("list-commands", handle_list_commands)
    registry.register("execute-command", handle_execute_command)


def handle_list_commands(context: CommandSessionContext, args) -> CommandResult:
    try:
        package = context.loaded_package()
    except RuntimeError as exc:
        return failure("list-commands", str(exc))

    items = [
        {
            "name": p.parameter_name,
            "modbus_addr": p.modbus_address,
            "data_type": p.data_type_name,
        }
        for p in package.parameters
        if p.parameter_access_kind == ParameterAccessKind.COMMAND_WRITE
    ]
    return success("list-commands", {"count": len(items), "commands": items})


def handle_execute_command(context: CommandSessionContext, args) -> CommandResult:
    try:
        context.require_connected()
        slave_id = context.effective_slave_id(getattr(args, "slave_id", None))
    except RuntimeError as e:
        return failure("execute-command", str(e))

    address = getattr(args, "address", None)
    name = getattr(args, "name", None)

    if address is None:
        if not name:
            return failure("execute-command", "Provide --name or --address")
        try:
            package = context.loaded_package()
        except RuntimeError as e:
            return failure("execute-command", str(e))
        parameter = next(
            (p for p in package.parameters if p.parameter_name == name), None
        )
        if parameter is None:
            return failure("execute-command", f"Unknown command parameter: {name}")
        if parameter.parameter_access_kind != ParameterAccessKind.COMMAND_WRITE:
            return failure("execute-command", f"Not a COMMAND parameter: {name}")
        address = parameter.modbus_address
    else:
        address = int(address)
        name = name or f"addr_{address}"

    if getattr(args, "all_same_device_id", False):
        load = context.last_settings_load_result
        identify = context.last_identify_result
        if load is None or identify is None or identify.root_node is None:
            return failure(
                "execute-command",
                "Load settings and run identify before --all-same-device-id.",
            )
        targets = [
            node
            for node in identify.root_node.iter_depth_first()
            if node.device_id == load.device_id_from_device
        ]
        if not targets:
            return failure("execute-command", "No matching devices in the Identify topology.")
        if any(
            node.parameter_list_version != load.parameter_list_version_from_device
            for node in targets
        ):
            return failure(
                "execute-command",
                "Matching DeviceIds have different parameter-list versions; "
                "one command address cannot safely be used for all of them.",
            )
        executor = DeviceCommandExecutor(context.device_modbus_link)
        results = executor.execute_command_for_units(
            int(address), [node.permanent_modbus_slave_id for node in targets]
        )
        details = [
            {
                "slave_id": node.permanent_modbus_slave_id,
                "name": node.device_name,
                "success": results[node.permanent_modbus_slave_id].success,
                "message": results[node.permanent_modbus_slave_id].message,
                "last_read_value": results[node.permanent_modbus_slave_id].last_read_value,
            }
            for node in targets
        ]
        data = {
            "name": name,
            "modbus_addr": int(address),
            "targets": details,
            "success_count": sum(item["success"] for item in details),
            "failure_count": sum(not item["success"] for item in details),
        }
        if data["failure_count"]:
            return CommandResult(
                ok=False,
                command="execute-command",
                data=data,
                error=f"{data['failure_count']} device command(s) failed.",
                exit_code=1,
            )
        return success("execute-command", data)

    context.device_modbus_link.set_modbus_unit_identifier_override(slave_id)
    executor = DeviceCommandExecutor(context.device_modbus_link)
    result = executor.execute_command_at_modbus_address(int(address))
    data = {
        "name": name,
        "modbus_addr": int(address),
        "slave_id": slave_id,
        "success": result.success,
        "message": result.message,
        "last_read_value": result.last_read_value,
    }
    if result.success:
        return success("execute-command", data)
    from commands.result import CommandResult

    return CommandResult(
        ok=False,
        command="execute-command",
        data=data,
        error=result.message,
        exit_code=1,
    )
