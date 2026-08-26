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
        self._modbus_unit_identifier_override: int | None = None
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
            timeout_seconds = (
                max(ethernet.connect_timeout_milliseconds, 1) / 1000.0
            )
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
        self._set_client_timeout_seconds(
            client, self.get_active_read_timeout_seconds()
        )
        client.retries = self.get_active_transaction_retry_count()

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

        Tries immediately; on failure waits Read timeout and retries
        (modbus_transaction_retry_count total attempts).
        """
        return self._execute_with_timeout_retries(
            operation_label=f"READ addr={modbus_start_address} count={register_count}",
            operation=lambda: self._read_holding_registers_u16_once(
                modbus_start_address, register_count, modbus_unit_identifier
            ),
        )

    def _read_holding_registers_u16_once(
        self,
        modbus_start_address: int,
        register_count: int,
        modbus_unit_identifier: int | None,
    ) -> list[int]:
        client, unit_id = self._require_connected_client_and_unit_id(
            modbus_unit_identifier_override=modbus_unit_identifier
        )
        self._set_client_timeout_seconds(
            client, self.get_active_read_timeout_seconds()
        )
        try:
            response = client.read_holding_registers(
                address=modbus_start_address,
                count=register_count,
                device_id=unit_id,
            )
        except TypeError:
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

    def _execute_with_timeout_retries(self, operation_label: str, operation):
        import time

        attempts = self.get_active_transaction_retry_count()
        wait_s = self.get_active_read_timeout_seconds()
        last_error: Exception | None = None
        for attempt_index in range(1, attempts + 1):
            try:
                return operation()
            except DeviceModbusLinkError as exc:
                last_error = exc
                if attempt_index >= attempts:
                    break
                time.sleep(wait_s)
        assert last_error is not None
        raise DeviceModbusLinkError(
            f"{operation_label} failed after {attempts} attempt(s): {last_error}"
        ) from last_error

    def write_holding_register_u16(
        self,
        modbus_register_address: int,
        value_u16: int,
        modbus_unit_identifier: int | None = None,
    ) -> None:
        """
        Write one holding register (value masked to 16-bit).

        Broadcast (unit id 0): devices must not reply. Timeout / no response
        is treated as success. Explicit exception error responses still fail
        unless they look like a pure timeout/no-response.
        """
        client, unit_id = self._require_connected_client_and_unit_id(
            modbus_unit_identifier_override=modbus_unit_identifier
        )
        self._set_client_timeout_seconds(
            client, self.get_active_write_timeout_seconds()
        )
        value_u16 = int(value_u16) & 0xFFFF
        is_broadcast = int(unit_id) == 0
        try:
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
            if is_broadcast and _is_modbus_no_response_error(exc):
                return
            raise DeviceModbusLinkError(f"Modbus write exception: {exc}") from exc
        except OSError as exc:
            # Some backends surface I/O timeout as OSError
            if is_broadcast and _is_modbus_no_response_error(exc):
                return
            raise DeviceModbusLinkError(f"Modbus write I/O error: {exc}") from exc

        if is_broadcast:
            # No reply expected; None or timeout-like error response → OK
            if response is None:
                return
            if hasattr(response, "isError") and response.isError():
                if _is_modbus_no_response_error(response):
                    return
                # Still ignore generic broadcast non-replies
                return
            return

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
        self._set_client_timeout_seconds(
            client, self.get_active_write_timeout_seconds()
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

    def get_active_write_timeout_seconds(self) -> float:
        """Write timeout from the active communication settings (seconds)."""
        settings = self._active_communication_settings
        if settings is None:
            return 1.0
        if settings.link_kind == CommunicationLinkKind.SERIAL_RTU:
            ms = settings.serial_port_settings.write_timeout_milliseconds
        else:
            ms = settings.ethernet_tcp_settings.write_timeout_milliseconds
        return max(int(ms), 1) / 1000.0

    def get_active_transaction_retry_count(self) -> int:
        settings = self._active_communication_settings
        if settings is None:
            return 3
        return max(1, int(settings.modbus_transaction_retry_count))

    def get_active_read_timeout_seconds(self) -> float:
        """Read timeout from the active communication settings (seconds)."""
        settings = self._active_communication_settings
        if settings is None:
            return 1.0
        if settings.link_kind == CommunicationLinkKind.SERIAL_RTU:
            ms = settings.serial_port_settings.read_timeout_milliseconds
        else:
            ms = settings.ethernet_tcp_settings.read_timeout_milliseconds
        return max(int(ms), 1) / 1000.0

    def update_active_timeouts_and_retries(
        self,
        *,
        read_timeout_milliseconds: int,
        write_timeout_milliseconds: int,
        connect_timeout_milliseconds: int | None = None,
        transaction_retry_count: int | None = None,
    ) -> dict[str, int | str]:
        """Update the active session settings without reconnecting."""
        client, _unit_id = self._require_connected_client_and_unit_id()
        settings = self._active_communication_settings
        assert settings is not None

        read_ms = int(read_timeout_milliseconds)
        write_ms = int(write_timeout_milliseconds)
        if read_ms <= 0 or write_ms <= 0:
            raise DeviceModbusLinkError("Read and write timeouts must be positive.")
        if connect_timeout_milliseconds is not None:
            connect_ms = int(connect_timeout_milliseconds)
            if connect_ms <= 0:
                raise DeviceModbusLinkError("Connect timeout must be positive.")
        else:
            connect_ms = None
        if transaction_retry_count is not None:
            retry_count = int(transaction_retry_count)
            if retry_count < 1:
                raise DeviceModbusLinkError("Retries must be at least 1.")
        else:
            retry_count = int(settings.modbus_transaction_retry_count)

        if settings.link_kind == CommunicationLinkKind.SERIAL_RTU:
            settings.serial_port_settings.read_timeout_milliseconds = read_ms
            settings.serial_port_settings.write_timeout_milliseconds = write_ms
        else:
            ethernet = settings.ethernet_tcp_settings
            ethernet.read_timeout_milliseconds = read_ms
            ethernet.write_timeout_milliseconds = write_ms
            if connect_ms is not None:
                ethernet.connect_timeout_milliseconds = connect_ms

        settings.modbus_transaction_retry_count = retry_count
        client.retries = retry_count
        self._set_client_timeout_seconds(client, read_ms / 1000.0)

        result: dict[str, int | str] = {
            "link_kind": settings.link_kind.value,
            "read_timeout_ms": read_ms,
            "write_timeout_ms": write_ms,
            "retries": retry_count,
        }
        if settings.link_kind == CommunicationLinkKind.ETHERNET_TCP:
            result["connect_timeout_ms"] = (
                settings.ethernet_tcp_settings.connect_timeout_milliseconds
            )
        return result

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
    def _set_client_timeout_seconds(
        client: ModbusSerialClient | ModbusTcpClient,
        timeout_seconds: float,
    ) -> None:
        """Apply a transaction timeout across supported pymodbus versions."""
        seconds = max(float(timeout_seconds), 0.001)
        comm_params = getattr(client, "comm_params", None)
        if comm_params is not None and hasattr(comm_params, "timeout_connect"):
            comm_params.timeout_connect = seconds
        elif hasattr(client, "timeout"):
            client.timeout = seconds

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


def _is_modbus_no_response_error(exc_or_response: object) -> bool:
    """True when the failure is only missing reply / timeout (broadcast-safe)."""
    text_value = str(exc_or_response).lower()
    markers = (
        "no response",
        "timeout",
        "timed out",
    )
    return any(marker in text_value for marker in markers)
