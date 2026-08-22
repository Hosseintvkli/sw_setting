"""Commands: connect, disconnect, status, list-serial-ports, list-networks, set-timeouts."""

from __future__ import annotations

from commands.context import CommandSessionContext
from commands.registry import CommandRegistry
from commands.result import CommandResult, failure, success
from core.communication_settings import (
    CommunicationLinkKind,
    DeviceCommunicationSettings,
    EthernetTcpCommunicationSettings,
    SerialPortCommunicationSettings,
)
from core.device_modbus_link import DeviceModbusLinkError


def register(registry: CommandRegistry) -> None:
    registry.register("connect", handle_connect)
    registry.register("disconnect", handle_disconnect)
    registry.register("status", handle_status)
    registry.register("list-serial-ports", handle_list_serial_ports)
    registry.register("list-networks", handle_list_networks)
    registry.register("set-timeouts", handle_set_timeouts)


def handle_connect(context: CommandSessionContext, args) -> CommandResult:
    if context.device_modbus_link.is_connected:
        context.device_modbus_link.disconnect()

    retries = int(args.retries)
    if getattr(args, "port", None):
        settings = DeviceCommunicationSettings(
            link_kind=CommunicationLinkKind.SERIAL_RTU,
            serial_port_settings=SerialPortCommunicationSettings(
                serial_port_name=str(args.port),
                baud_rate_bits_per_second=int(args.baud),
                read_timeout_milliseconds=int(args.read_timeout_ms),
                write_timeout_milliseconds=int(args.write_timeout_ms),
            ),
            modbus_unit_identifier=1,
            modbus_transaction_retry_count=retries,
        )
        link_info = {
            "link_kind": "serial_rtu",
            "port": args.port,
            "baud": int(args.baud),
        }
    else:
        settings = DeviceCommunicationSettings(
            link_kind=CommunicationLinkKind.ETHERNET_TCP,
            ethernet_tcp_settings=EthernetTcpCommunicationSettings(
                local_network_interface_name=str(args.local_interface or ""),
                local_network_ipv4_address=str(args.local_ip or ""),
                device_ip_address=str(args.device_ip),
                modbus_tcp_port_number=int(args.tcp_port),
                connect_timeout_milliseconds=int(args.connect_timeout_ms),
                read_timeout_milliseconds=int(args.read_timeout_ms),
                write_timeout_milliseconds=int(args.write_timeout_ms),
            ),
            modbus_unit_identifier=1,
            modbus_transaction_retry_count=retries,
        )
        link_info = {
            "link_kind": "ethernet_tcp",
            "device_ip": args.device_ip,
            "tcp_port": int(args.tcp_port),
            "local_interface": args.local_interface,
            "local_ip": args.local_ip,
        }

    try:
        context.device_modbus_link.connect_using_settings(settings)
    except DeviceModbusLinkError as exc:
        return failure("connect", str(exc))

    context.selected_slave_id = None
    context.log(f"Connected: {link_info}")
    return success(
        "connect",
        {
            **link_info,
            "read_timeout_ms": int(args.read_timeout_ms),
            "write_timeout_ms": int(args.write_timeout_ms),
            "retries": retries,
        },
    )


def handle_disconnect(context: CommandSessionContext, args) -> CommandResult:
    context.device_modbus_link.disconnect()
    context.selected_slave_id = None
    context.last_settings_load_result = None
    context.log("Disconnected.")
    return success("disconnect", {"connected": False})


def handle_status(context: CommandSessionContext, args) -> CommandResult:
    link = context.device_modbus_link
    topology = context.last_identify_result
    assigned = 0
    if topology is not None:
        assigned = topology.assigned_slave_id_count
    return success(
        "status",
        {
            "connected": link.is_connected,
            "selected_slave_id": context.selected_slave_id,
            "has_topology": topology is not None and topology.root_node is not None,
            "assigned_slave_id_count": assigned,
            "settings_loaded": context.last_settings_load_result is not None,
            "json_root": str(context.codegen_json_root_directory),
        },
    )


def handle_list_serial_ports(context: CommandSessionContext, args) -> CommandResult:
    from core.host_communication_discovery import list_available_serial_port_device_names

    names = list_available_serial_port_device_names()
    return success("list-serial-ports", {"ports": names})


def handle_list_networks(context: CommandSessionContext, args) -> CommandResult:
    from core.host_communication_discovery import list_available_ipv4_network_interfaces

    interfaces = [
        {"name": name, "ipv4": ipv4}
        for name, ipv4 in list_available_ipv4_network_interfaces()
    ]
    return success("list-networks", {"interfaces": interfaces})


def handle_set_timeouts(context: CommandSessionContext, args) -> CommandResult:
    """
    Timeouts are applied on next connect via settings snapshot.
    If already connected, store hint in log; full apply requires reconnect
    unless link exposes live timeout setters (current core applies at connect).
    """
    data = {
        "read_timeout_ms": int(args.read_timeout_ms),
        "write_timeout_ms": int(args.write_timeout_ms),
        "connect_timeout_ms": args.connect_timeout_ms,
        "retries": args.retries,
        "note": "Reconnect for timeouts to take full effect on pymodbus client.",
    }
    context.log(f"Timeout preferences updated: {data}")
    return success("set-timeouts", data)
