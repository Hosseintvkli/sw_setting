"""
Execute COMMAND parameters over Modbus.

Protocol:
  1) Write 0xFFFF (65535) to the command holding register
  2) Poll-read the same address:
       - no response  → still executing (keep polling until command timeout)
       - 65535        → still pending (keep polling until command timeout)
       - 0            → success
       - any other    → failure; value is the error code
"""

from __future__ import annotations

import time
from dataclasses import dataclass

from core.device_modbus_link import DeviceModbusLink, DeviceModbusLinkError

COMMAND_TRIGGER_VALUE_U16 = 0xFFFF
COMMAND_SUCCESS_VALUE_U16 = 0
COMMAND_PENDING_VALUE_U16 = 0xFFFF


@dataclass
class DeviceCommandExecutionResult:
    success: bool
    message: str
    last_read_value: int | None = None


class DeviceCommandExecutor:
    def __init__(self, device_modbus_link: DeviceModbusLink) -> None:
        self._device_modbus_link = device_modbus_link

    def execute_command_at_modbus_address(
        self, modbus_address: int
    ) -> DeviceCommandExecutionResult:
        if not self._device_modbus_link.is_connected:
            return DeviceCommandExecutionResult(
                success=False, message="Not connected."
            )

        try:
            self._device_modbus_link.write_holding_register_u16(
                modbus_address, COMMAND_TRIGGER_VALUE_U16
            )
        except DeviceModbusLinkError as exc:
            return DeviceCommandExecutionResult(
                success=False,
                message=f"Write trigger 0xFFFF failed: {exc}",
            )

        wait_s = self._device_modbus_link.get_active_read_timeout_seconds()
        command_timeout_s = (
            self._device_modbus_link.get_active_command_execution_timeout_seconds()
        )
        deadline = time.monotonic() + command_timeout_s

        last_value: int | None = None
        while True:
            try:
                value = self._device_modbus_link._read_holding_registers_u16_once(
                    modbus_address, 1, None
                )[0]
                last_value = int(value) & 0xFFFF
                if last_value == COMMAND_SUCCESS_VALUE_U16:
                    return DeviceCommandExecutionResult(
                        success=True,
                        message="Command completed successfully (value=0).",
                        last_read_value=last_value,
                    )
                if last_value != COMMAND_PENDING_VALUE_U16:
                    return DeviceCommandExecutionResult(
                        success=False,
                        message=f"Command failed, error code={last_value}.",
                        last_read_value=last_value,
                    )
            except DeviceModbusLinkError:
                # No response → device still busy executing
                pass

            remaining_s = deadline - time.monotonic()
            if remaining_s <= 0:
                break
            time.sleep(min(wait_s, remaining_s))

        if last_value == COMMAND_PENDING_VALUE_U16:
            return DeviceCommandExecutionResult(
                success=False,
                message="Timeout: command still pending (0xFFFF).",
                last_read_value=last_value,
            )
        return DeviceCommandExecutionResult(
            success=False,
            message="Timeout: no conclusive response while command may still be running.",
            last_read_value=last_value,
        )
