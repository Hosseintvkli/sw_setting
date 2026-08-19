"""Commands: identify, show-topology, select-device, clear-device-selection."""

from __future__ import annotations

from pathlib import Path
from typing import Any

from commands.context import CommandSessionContext
from commands.registry import CommandRegistry
from commands.result import CommandResult, failure, success
from core.device_identify_session import (
    DeviceIdentifySession,
    DeviceIdentifySessionError,
)
from core.device_topology_models import IdentifiedDeviceNode


def register(registry: CommandRegistry) -> None:
    registry.register("identify", handle_identify)
    registry.register("show-topology", handle_show_topology)
    registry.register("select-device", handle_select_device)
    registry.register("clear-device-selection", handle_clear_device_selection)


def handle_identify(context: CommandSessionContext, args) -> CommandResult:
    try:
        context.require_connected()
    except RuntimeError as exc:
        return failure("identify", str(exc))

    json_root = (
        Path(args.json_root)
        if getattr(args, "json_root", None)
        else context.codegen_json_root_directory
    )

    session = DeviceIdentifySession(
        device_modbus_link=context.device_modbus_link,
        codegen_json_root_directory=json_root,
        log_callback=context.log,
    )
    try:
        result = session.run_identify()
    except DeviceIdentifySessionError as exc:
        partial = getattr(exc, "partial_result", None)
        if partial is not None and partial.root_node is not None:
            context.last_identify_result = partial
            return CommandResult_from_topology(
                "identify",
                partial,
                ok=False,
                error=str(exc),
            )
        return failure("identify", str(exc))

    context.last_identify_result = result
    return CommandResult_from_topology("identify", result, ok=True)


def handle_show_topology(context: CommandSessionContext, args) -> CommandResult:
    result = context.last_identify_result
    if result is None or result.root_node is None:
        return failure("show-topology", "No topology. Run: identify")
    fmt = getattr(args, "format", "json")
    if fmt == "tree":
        text = format_topology_tree_text(result.root_node)
        return success("show-topology", {"format": "tree", "text": text})
    return CommandResult_from_topology("show-topology", result, ok=True)


def handle_select_device(context: CommandSessionContext, args) -> CommandResult:
    slave_id = getattr(args, "slave_id", None)
    device_id = getattr(args, "device_id", None)

    if slave_id is not None:
        slave_id = int(slave_id)
        node = context.find_node_by_slave_id(slave_id)
        context.selected_slave_id = slave_id
        context.device_modbus_link.set_modbus_unit_identifier_override(slave_id)
        data: dict[str, Any] = {"slave_id": slave_id}
        if node is not None:
            data.update(
                {
                    "device_id": node.device_id,
                    "device_name": node.device_name,
                    "parameter_list_version": node.parameter_list_version,
                }
            )
        context.log(f"Selected SlaveId={slave_id}")
        return success("select-device", data)

    if device_id is not None:
        device_id = int(device_id)
        result = context.last_identify_result
        if result is None or result.root_node is None:
            return failure(
                "select-device",
                "No topology for DeviceId lookup. Pass --slave-id or run identify.",
            )
        matches = [
            n
            for n in result.root_node.iter_depth_first()
            if n.device_id == device_id
        ]
        if not matches:
            return failure("select-device", f"No node with DeviceId={device_id}")
        if len(matches) > 1:
            return failure(
                "select-device",
                f"Multiple nodes with DeviceId={device_id}; pass --slave-id. "
                f"Candidates: {[m.permanent_modbus_slave_id for m in matches]}",
            )
        node = matches[0]
        context.selected_slave_id = node.permanent_modbus_slave_id
        context.device_modbus_link.set_modbus_unit_identifier_override(
            node.permanent_modbus_slave_id
        )
        return success(
            "select-device",
            {
                "slave_id": node.permanent_modbus_slave_id,
                "device_id": node.device_id,
                "device_name": node.device_name,
                "parameter_list_version": node.parameter_list_version,
            },
        )

    return failure("select-device", "Provide --slave-id or --device-id")


def handle_clear_device_selection(context: CommandSessionContext, args) -> CommandResult:
    context.selected_slave_id = None
    context.device_modbus_link.set_modbus_unit_identifier_override(None)
    return success("clear-device-selection", {"selected_slave_id": None})


def CommandResult_from_topology(
    command: str, result, ok: bool, error: str | None = None
) -> CommandResult:
    from commands.result import CommandResult

    data = {
        "assigned_slave_id_count": result.assigned_slave_id_count,
        "root": node_to_dict(result.root_node) if result.root_node else None,
    }
    return CommandResult(
        ok=ok,
        command=command,
        data=data,
        error=error,
        exit_code=0 if ok else 1,
    )


def node_to_dict(node: IdentifiedDeviceNode) -> dict[str, Any]:
    ports: list[dict[str, Any]] = []
    for port_index in range(node.downstream_port_quantity):
        child = node.children_by_port_index.get(port_index)
        if child is None:
            ports.append({"port_index": port_index, "connected": False})
        else:
            ports.append(
                {
                    "port_index": port_index,
                    "connected": True,
                    "device": node_to_dict(child),
                }
            )
    return {
        "device_name": node.device_name,
        "device_id": node.device_id,
        "parameter_list_version": node.parameter_list_version,
        "slave_id": node.permanent_modbus_slave_id,
        "downstream_qty": node.downstream_port_quantity,
        "ports": ports,
    }


def format_topology_tree_text(node: IdentifiedDeviceNode, indent: int = 0) -> str:
    pad = "  " * indent
    lines = [
        f"{pad}{node.device_name}  slave={node.permanent_modbus_slave_id}  "
        f"id={node.device_id}  ver={node.parameter_list_version}  "
        f"ports={node.downstream_port_quantity}"
    ]
    for port_index in range(node.downstream_port_quantity):
        child = node.children_by_port_index.get(port_index)
        if child is None:
            lines.append(f"{pad}  port[{port_index}]: (no connection)")
        else:
            lines.append(
                f"{pad}  port[{port_index}]: {child.device_name}  "
                f"slave={child.permanent_modbus_slave_id}"
            )
            if child.downstream_port_quantity > 0:
                # nested ports under child
                nested = format_topology_tree_text(child, indent + 2)
                # skip first line (device already printed)
                nested_lines = nested.splitlines()[1:]
                lines.extend(nested_lines)
    return "\n".join(lines)
