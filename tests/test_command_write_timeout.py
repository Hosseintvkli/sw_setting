from __future__ import annotations

import unittest
from types import SimpleNamespace
from unittest.mock import Mock

from pymodbus.exceptions import ModbusException

from core.communication_settings import (
    CommunicationLinkKind,
    DeviceCommunicationSettings,
)
from core.device_command_executor import DeviceCommandExecutor
from core.device_modbus_link import (
    DeviceModbusLink,
    DeviceModbusLinkState,
)


class CommandWriteTimeoutTests(unittest.TestCase):
    def make_link(self, response=None):
        if response is None:
            response = SimpleNamespace(isError=lambda: False)
        settings = DeviceCommunicationSettings(
            link_kind=CommunicationLinkKind.ETHERNET_TCP,
            command_execution_timeout_milliseconds=10_000,
            modbus_transaction_retry_count=3,
        )
        client = SimpleNamespace(
            connected=True,
            retries=2,
            transaction=SimpleNamespace(retries=2),
            comm_params=SimpleNamespace(timeout_connect=0.2),
            write_register=Mock(return_value=response),
        )
        link = DeviceModbusLink()
        link._modbus_client = client
        link._active_communication_settings = settings
        link._link_state = DeviceModbusLinkState.CONNECTED
        return link, client

    def test_command_trigger_uses_ten_seconds_and_one_attempt(self):
        link, client = self.make_link()

        def write_register(**kwargs):
            self.assertEqual(client.comm_params.timeout_connect, 10.0)
            self.assertEqual(client.retries, 0)
            self.assertEqual(client.transaction.retries, 0)
            return SimpleNamespace(isError=lambda: False)

        client.write_register.side_effect = write_register
        result = DeviceCommandExecutor(link).trigger_command(221, 243)
        self.assertIsNone(result)
        self.assertEqual(client.retries, 2)
        self.assertEqual(client.transaction.retries, 2)
        client.write_register.assert_called_once_with(
            address=221, value=0xFFFF, device_id=243
        )

    def test_retries_are_restored_even_if_write_raises(self):
        link, client = self.make_link()
        client.write_register.side_effect = ModbusException("no response")
        result = DeviceCommandExecutor(link).trigger_command(221, 243)
        self.assertFalse(result.success)
        self.assertEqual(client.retries, 2)
        self.assertEqual(client.transaction.retries, 2)

    def test_ordinary_write_still_uses_short_write_timeout(self):
        link, client = self.make_link()
        link.write_holding_register_u16(100, 1, modbus_unit_identifier=243)
        self.assertEqual(client.comm_params.timeout_connect, 0.1)
        self.assertEqual(client.retries, 2)

    def test_broadcast_ignores_unsolicited_streamer_frame(self):
        link, client = self.make_link()
        client.write_register.side_effect = ModbusException(
            "request uses device id=0 but received 232"
        )

        link.write_holding_register_u16(4003, 0xFFFF, modbus_unit_identifier=0)

        client.write_register.assert_called_once_with(
            address=4003,
            value=0xFFFF,
            device_id=0,
        )

    def test_discard_pending_input_resets_serial_buffer(self):
        link, client = self.make_link()
        serial_socket = SimpleNamespace(reset_input_buffer=Mock())
        client.socket = serial_socket

        self.assertTrue(link.discard_pending_input())
        serial_socket.reset_input_buffer.assert_called_once_with()


if __name__ == "__main__":
    unittest.main()
