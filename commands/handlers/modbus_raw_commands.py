"""Commands: read-holding, write-holding, write-holding-broadcast."""

from __future__ import annotations

from commands.context import CommandSessionContext
from commands.registry import CommandRegistry
from commands.result import CommandResult, failure, success
from core.device_modbus_link import DeviceModbusLinkError


def register(registry: CommandRegistry) -> None:
    registry.register("read-holding", handle_read_holding)
    registry.register("write-holding", handle_write_holding)
    registry.register("write-holding-broadcast", handle_write_holding_broadcast)


def handle_read_holding(context: CommandSessionContext, args) -> CommandResult:
    try:
        context.require_connected()
        slave_id = context.effective_slave_id(getattr(args, "slave_id", None))
    except RuntimeError as exc:
        return failure("read-holding", str(exc))

    address = int(args.address)
    count = int(args.count)
    try:
        values = context.device_modbus_link.read_holding_registers_u16(
            address, count, modbus_unit_identifier=slave_id
        )
    except DeviceModbusLinkError as exc:
        return failure("read-holding", str(exc))

    return success(
        "read-holding",
        {
            "slave_id": slave_id,
            "address": address,
            "count": count,
            "values": values,
        },
    )


def handle_write_holding(context: CommandSessionContext, args) -> CommandResult:
    try:
        context.require_connected()
        slave_id = context.effective_slave_id(getattr(args, "slave_id", None))
    except RuntimeError as e:
        return failure("write-holding", str(e))

    address = int(args.address)
    if args.values:
        values = [int(x.strip()) & 0xFFFF for x in str(args.values).split(",")]
    elif args.value is not None:
        values = [int(args.value) & 0xFFFF]
    else:
        return failure("write-holding", "Provide --value or --values")

    try:
        context.device_modbus_link.write_holding_registers_u16(
            address, values, modbus_unit_identifier=slave_id
        )
    except DeviceModbusLinkError as exc:
        return failure("write-holding", str(exc))

    return success(
        "write-holding",
        {"slave_id": slave_id, "address": address, "values": values},
    )


def handle_write_holding_broadcast(
    context: CommandSessionContext, args
) -> CommandResult:
    try:
        context.require_connected()
    except RuntimeError as e:
        return failure("write-holding-broadcast", str(e))

    address = int(args.address)
    value = int(args.value) & 0xFFFF
    try:
        context.device_modbus_link.write_holding_register_u16(
            address, value, modbus_unit_identifier=0
        )
    except DeviceModbusLinkError as exc:
        return failure("write-holding-broadcast", str(exc))

    return success(
        "write-holding-broadcast",
        {
            "address": address,
            "value": value,
            "note": "Broadcast unit=0; no reply expected",
        },
    )
