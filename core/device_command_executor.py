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
from collections.abc import Callable
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
    def __init__(
        self,
        device_modbus_link: DeviceModbusLink,
        cancel_check: Callable[[], bool] | None = None,
    ) -> None:
        self._device_modbus_link = device_modbus_link
        self._cancel_check = cancel_check

    def execute_command_at_modbus_address(
        self, modbus_address: int
    ) -> DeviceCommandExecutionResult:
        if not self._device_modbus_link.is_connected:
            return DeviceCommandExecutionResult(success=False, message="Not connected.")

        write_error = self.trigger_command(modbus_address)
        if write_error is not None:
            return write_error
        return self.wait_for_command_completion(modbus_address)

    def trigger_command(
        self, modbus_address: int, modbus_unit_identifier: int | None = None
    ) -> DeviceCommandExecutionResult | None:
        """Send 0xFFFF; a normal Modbus write response confirms acceptance only."""
        try:
            self._device_modbus_link.write_holding_register_u16(
                modbus_address,
                COMMAND_TRIGGER_VALUE_U16,
                modbus_unit_identifier=modbus_unit_identifier,
            )
        except DeviceModbusLinkError as exc:
            return DeviceCommandExecutionResult(
                success=False, message=f"Write trigger 0xFFFF failed: {exc}"
            )
        return None

    def wait_for_command_completion(
        self, modbus_address: int, modbus_unit_identifier: int | None = None
    ) -> DeviceCommandExecutionResult:
        """Poll a previously triggered command until 0, error code, or timeout."""

        wait_s = self._device_modbus_link.get_active_read_timeout_seconds()
        command_timeout_s = (
            self._device_modbus_link.get_active_command_execution_timeout_seconds()
        )
        deadline = time.monotonic() + command_timeout_s

        last_value: int | None = None
        while True:
            if self._cancel_check is not None and self._cancel_check():
                return DeviceCommandExecutionResult(
                    success=False,
                    message="Command wait cancelled by user.",
                    last_read_value=last_value,
                )
            try:
                value = self._device_modbus_link._read_holding_registers_u16_once(
                    modbus_address, 1, modbus_unit_identifier
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

    def execute_command_for_units(
        self,
        modbus_address: int,
        unit_ids: list[int],
        progress_callback: Callable[[int, int, str], None] | None = None,
    ) -> dict[int, DeviceCommandExecutionResult]:
        """Trigger every unit first, then poll each acknowledged trigger."""
        results: dict[int, DeviceCommandExecutionResult] = {}
        acknowledged: list[int] = []
        unique_unit_ids = list(dict.fromkeys(unit_ids))
        total = max(1, len(unique_unit_ids))
        completed = 0
        for unit_id in unique_unit_ids:
            if unit_id == 0:
                results[unit_id] = DeviceCommandExecutionResult(
                    success=False,
                    message="Broadcast unit 0 cannot acknowledge a command trigger.",
                )
                completed += 1
                if progress_callback is not None:
                    progress_callback(completed, total, f"SlaveId={unit_id} rejected")
                continue
            write_error = self.trigger_command(modbus_address, unit_id)
            if write_error is not None:
                results[unit_id] = write_error
                completed += 1
                if progress_callback is not None:
                    progress_callback(
                        completed, total, f"Command write failed on SlaveId={unit_id}"
                    )
            else:
                acknowledged.append(unit_id)
        for unit_id in acknowledged:
            results[unit_id] = self.wait_for_command_completion(modbus_address, unit_id)
            completed += 1
            if progress_callback is not None:
                progress_callback(
                    completed, total, f"Command completed on SlaveId={unit_id}"
                )
        return results
