"""
Pure data model for how the setting tool talks to a device.

No Qt, no Modbus I/O here — only values the UI and later the Modbus layer share.
"""

from __future__ import annotations

from dataclasses import dataclass, field
from enum import Enum


class CommunicationLinkKind(Enum):
    """Which physical/transport link is used for Modbus."""

    SERIAL_RTU = "serial_rtu"
    ETHERNET_TCP = "ethernet_tcp"


@dataclass
class SerialPortCommunicationSettings:
    """Settings for Modbus RTU over a serial (COM) port."""

    serial_port_name: str = "COM1"
    baud_rate_bits_per_second: int = 115200
    read_timeout_milliseconds: int = 1000
    write_timeout_milliseconds: int = 1000
    # Common RTU defaults; exposed later if devices need other values
    data_bits: int = 8
    stop_bits: int = 1
    parity_label: str = "None"  # None / Even / Odd — mapped by Modbus layer later


@dataclass
class EthernetTcpCommunicationSettings:
    """Settings for Modbus TCP over Ethernet."""

    device_ip_address: str = "192.168.1.100"
    modbus_tcp_port_number: int = 502
    connect_timeout_milliseconds: int = 2000
    read_timeout_milliseconds: int = 1000
    write_timeout_milliseconds: int = 1000


@dataclass
class DeviceCommunicationSettings:
    """
    Full communication configuration chosen by the user.

    Exactly one of the link-specific blocks is active, selected by link_kind.
    """

    link_kind: CommunicationLinkKind = CommunicationLinkKind.SERIAL_RTU
    serial_port_settings: SerialPortCommunicationSettings = field(
        default_factory=SerialPortCommunicationSettings
    )
    ethernet_tcp_settings: EthernetTcpCommunicationSettings = field(
        default_factory=EthernetTcpCommunicationSettings
    )
    # Modbus unit / slave id (often same idea as device addressing on the bus)
    modbus_unit_identifier: int = 1
