from __future__ import annotations

import unittest
from types import SimpleNamespace

from commands.context import CommandSessionContext
from commands.handlers.connection_commands import handle_connect, handle_disconnect


class _FakeLink:
    def __init__(self) -> None:
        self.is_connected = False
        self.connected_settings = None
        self.selected_override = None

    def connect_using_settings(self, settings) -> None:
        self.connected_settings = settings
        self.is_connected = True

    def disconnect(self) -> None:
        self.is_connected = False

    def set_modbus_unit_identifier_override(self, slave_id: int) -> None:
        self.selected_override = slave_id


def _tcp_connect_args():
    return SimpleNamespace(
        retries=1,
        port=None,
        baud=115200,
        read_timeout_ms=200,
        write_timeout_ms=100,
        connect_timeout_ms=100,
        command_timeout_ms=10_000,
        local_interface="Ethernet 2",
        local_ip="192.168.1.120",
        device_ip="192.168.1.110",
        tcp_port=502,
    )


class ConnectionStatePreservationTests(unittest.TestCase):
    def test_disconnect_preserves_selected_device_and_loaded_settings(self):
        link = _FakeLink()
        loaded_settings = object()
        context = CommandSessionContext(
            device_modbus_link=link,
            selected_slave_id=246,
            last_settings_load_result=loaded_settings,
        )

        result = handle_disconnect(context, SimpleNamespace())

        self.assertTrue(result.ok)
        self.assertEqual(context.selected_slave_id, 246)
        self.assertIs(context.last_settings_load_result, loaded_settings)
        self.assertEqual(result.data["preserved_selected_slave_id"], 246)
        self.assertTrue(result.data["settings_state_preserved"])

    def test_connect_restores_selected_slave_override(self):
        link = _FakeLink()
        loaded_settings = object()
        context = CommandSessionContext(
            device_modbus_link=link,
            selected_slave_id=246,
            last_settings_load_result=loaded_settings,
        )

        result = handle_connect(context, _tcp_connect_args())

        self.assertTrue(result.ok)
        self.assertEqual(link.selected_override, 246)
        self.assertEqual(context.selected_slave_id, 246)
        self.assertIs(context.last_settings_load_result, loaded_settings)
        self.assertEqual(result.data["restored_selected_slave_id"], 246)
        self.assertTrue(result.data["settings_state_preserved"])


if __name__ == "__main__":
    unittest.main()
