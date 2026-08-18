"""
Real Modbus link to a device (Serial RTU or Ethernet TCP) via pymodbus.

Responsibility:
  - open / close connection from DeviceCommunicationSettings
  - primitive register read/write helpers used by higher layers later

Install:
  pip install pymodbus
"""

from __future__ import annotations

from enum import Enum

from pymodbus.client import ModbusSerialClient, ModbusTcpClient
from pymodbus.exceptions import ModbusException

from core.communication_settings import (
    CommunicationLinkKind,
    DeviceCommunicationSettings,
)


class DeviceModbusLinkState(Enum):
    DISCONNECTED = "disconnected"
    CONNECTED = "connected"


class DeviceModbusLinkError(Exception):
    """Raised when a Modbus operation fails or the link is not connected."""


class DeviceModbusLink:
    """
    One active Modbus client toward a single device.

    Naming is intentionally explicit so call sites stay readable.
    """

    def __init__(self) -> None:
        self._modbus_client: ModbusSerialClient | ModbusTcpClient | None = None
        self._active_communication_settings: DeviceCommunicationSettings | None = None
        self._link_state: DeviceModbusLinkState = DeviceModbusLinkState.DISCONNECTED

    @property
    def link_state(self) -> DeviceModbusLinkState:
        return self._link_state

    @property
    def is_connected(self) -> bool:
        return (
            self._link_state == DeviceModbusLinkState.CONNECTED
            and self._modbus_client is not None
            and bool(self._modbus_client.connected)
        )

    def connect_using_settings(
        self, communication_settings: DeviceCommunicationSettings
    ) -> None:
        """
        Open Serial RTU or TCP according to settings.

        Closes any previous connection first.
        """
        self.disconnect()

        if communication_settings.link_kind == CommunicationLinkKind.SERIAL_RTU:
            serial = communication_settings.serial_port_settings
            timeout_seconds = max(serial.read_timeout_milliseconds, 1) / 1000.0
            client: ModbusSerialClient | ModbusTcpClient = ModbusSerialClient(
                port=serial.serial_port_name,
                baudrate=serial.baud_rate_bits_per_second,
                bytesize=serial.data_bits,
                parity=self._parity_label_to_pymodbus_char(serial.parity_label),
                stopbits=serial.stop_bits,
                timeout=timeout_seconds,
            )
        elif communication_settings.link_kind == CommunicationLinkKind.ETHERNET_TCP:
            ethernet = communication_settings.ethernet_tcp_settings
            timeout_seconds = max(ethernet.read_timeout_milliseconds, 1) / 1000.0
            client = ModbusTcpClient(
                host=ethernet.device_ip_address,
                port=ethernet.modbus_tcp_port_number,
                timeout=timeout_seconds,
            )
        else:
            raise DeviceModbusLinkError(
                f"Unsupported link kind: {communication_settings.link_kind}"
            )

        opened = client.connect()
        if not opened:
            client.close()
            raise DeviceModbusLinkError(
                "Modbus client failed to open the link "
                f"(kind={communication_settings.link_kind.value}). "
                "Check COM port / IP / cable / virtual port pair."
            )

        self._modbus_client = client
        self._active_communication_settings = communication_settings
        self._modbus_unit_identifier_override = None
        self._link_state = DeviceModbusLinkState.CONNECTED

    def disconnect(self) -> None:
        """Close the underlying client if any; safe to call repeatedly."""
        if self._modbus_client is not None:
            try:
                self._modbus_client.close()
            finally:
                self._modbus_client = None
        self._active_communication_settings = None
        self._modbus_unit_identifier_override = None
        self._link_state = DeviceModbusLinkState.DISCONNECTED

    def read_holding_register_u16(
        self,
        modbus_register_address: int,
        modbus_unit_identifier: int | None = None,
    ) -> int:
        """Read one holding register (16-bit) as unsigned int."""
        registers = self.read_holding_registers_u16(
            modbus_start_address=modbus_register_address,
            register_count=1,
            modbus_unit_identifier=modbus_unit_identifier,
        )
        return registers[0]

    def read_holding_registers_u16(
        self,
        modbus_start_address: int,
        register_count: int,
        modbus_unit_identifier: int | None = None,
    ) -> list[int]:
        """
        Read consecutive holding registers.

        modbus_unit_identifier: override unit/slave id; None = connection default.
        Returns a list of unsigned 16-bit values (0..65535).
        """
        client, unit_id = self._require_connected_client_and_unit_id(
            modbus_unit_identifier_override=modbus_unit_identifier
        )
        try:
            response = client.read_holding_registers(
                address=modbus_start_address,
                count=register_count,
                device_id=unit_id,
            )
        except TypeError:
            # Older pymodbus versions use slave= instead of device_id=
            response = client.read_holding_registers(
                address=modbus_start_address,
                count=register_count,
                slave=unit_id,
            )
        except ModbusException as exc:
            raise DeviceModbusLinkError(f"Modbus read exception: {exc}") from exc

        if response is None:
            raise DeviceModbusLinkError("Modbus read returned no response.")
        if hasattr(response, "isError") and response.isError():
            raise DeviceModbusLinkError(f"Modbus read error response: {response}")

        values = list(response.registers)
        if len(values) != register_count:
            raise DeviceModbusLinkError(
                f"Expected {register_count} registers, got {len(values)}."
            )
        return values

    def write_holding_register_u16(
        self,
        modbus_register_address: int,
        value_u16: int,
        modbus_unit_identifier: int | None = None,
    ) -> None:
        """Write one holding register (value masked to 16-bit)."""
        client, unit_id = self._require_connected_client_and_unit_id(
            modbus_unit_identifier_override=modbus_unit_identifier
        )
        value_u16 = int(value_u16) & 0xFFFF
        try:
            response = client.write_register(
                address=modbus_register_address,
                value=value_u16,
                device_id=unit_id,
            )
        except TypeError:
            response = client.write_register(
                address=modbus_register_address,
                value=value_u16,
                slave=unit_id,
            )
        except ModbusException as exc:
            raise DeviceModbusLinkError(f"Modbus write exception: {exc}") from exc

        if response is None:
            raise DeviceModbusLinkError("Modbus write returned no response.")
        if hasattr(response, "isError") and response.isError():
            raise DeviceModbusLinkError(f"Modbus write error response: {response}")

    def write_holding_registers_u16(
        self,
        modbus_start_address: int,
        register_values_u16: list[int],
        modbus_unit_identifier: int | None = None,
    ) -> None:
        """Write one or more consecutive holding registers."""
        if not register_values_u16:
            return
        if len(register_values_u16) == 1:
            self.write_holding_register_u16(
                modbus_start_address,
                register_values_u16[0],
                modbus_unit_identifier=modbus_unit_identifier,
            )
            return

        client, unit_id = self._require_connected_client_and_unit_id(
            modbus_unit_identifier_override=modbus_unit_identifier
        )
        values = [int(v) & 0xFFFF for v in register_values_u16]
        try:
            response = client.write_registers(
                address=modbus_start_address,
                values=values,
                device_id=unit_id,
            )
        except TypeError:
            response = client.write_registers(
                address=modbus_start_address,
                values=values,
                slave=unit_id,
            )
        except ModbusException as exc:
            raise DeviceModbusLinkError(f"Modbus write exception: {exc}") from exc

        if response is None:
            raise DeviceModbusLinkError("Modbus multi-write returned no response.")
        if hasattr(response, "isError") and response.isError():
            raise DeviceModbusLinkError(f"Modbus multi-write error response: {response}")

    def set_modbus_unit_identifier_override(self, modbus_unit_identifier: int | None) -> None:
        """
        When set, all reads/writes that do not pass an explicit unit id use this value.
        Used after Identify when the user selects a device in the topology tree.
        """
        self._modbus_unit_identifier_override = (
            None if modbus_unit_identifier is None else int(modbus_unit_identifier)
        )

    def get_effective_modbus_unit_identifier(self) -> int:
        client, unit_id = self._require_connected_client_and_unit_id()
        return unit_id

    def _require_connected_client_and_unit_id(
        self,
        modbus_unit_identifier_override: int | None = None,
    ) -> tuple[ModbusSerialClient | ModbusTcpClient, int]:
        if self._modbus_client is None or not self.is_connected:
            raise DeviceModbusLinkError("Not connected to a device.")
        if self._active_communication_settings is None:
            raise DeviceModbusLinkError("Internal error: settings missing while connected.")
        if modbus_unit_identifier_override is not None:
            unit_id = int(modbus_unit_identifier_override)
        elif self._modbus_unit_identifier_override is not None:
            unit_id = int(self._modbus_unit_identifier_override)
        else:
            unit_id = self._active_communication_settings.modbus_unit_identifier
        return (self._modbus_client, unit_id)

    @staticmethod
    def _parity_label_to_pymodbus_char(parity_label: str) -> str:
        normalized = parity_label.strip().lower()
        if normalized in ("n", "none"):
            return "N"
        if normalized in ("e", "even"):
            return "E"
        if normalized in ("o", "odd"):
            return "O"
        return "N"
