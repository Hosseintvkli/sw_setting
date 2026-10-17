from __future__ import annotations

import unittest
from unittest.mock import patch

from PyQt6.QtWidgets import QApplication, QMessageBox

from ui.main_window import DeviceSettingMainWindow, _count_identified_hubs_and_devices


class IdentifyGuiCountTests(unittest.TestCase):
    def test_counts_nested_nodes_not_empty_ports(self):
        root = {
            "device_id": 2,
            "ports": [
                {"device": {"device_id": 3, "ports": [
                    {"device": {"device_id": 1004, "ports": []}},
                    {"connected": False},
                ]}},
                {"device": {"device_id": 1000, "ports": []}},
            ],
        }
        self.assertEqual(_count_identified_hubs_and_devices(root), (2, 2))

    def test_streaming_buttons_issue_expected_broadcast_commands(self):
        app = QApplication.instance() or QApplication([])
        window = DeviceSettingMainWindow()
        window._connected = True
        try:
            with (
                patch.object(QMessageBox, "question", return_value=QMessageBox.StandardButton.Yes),
                patch.object(window, "_execute") as execute,
            ):
                window._broadcast_streaming_command(4002, "Enable")
                window._broadcast_streaming_command(4003, "Disable")
            self.assertEqual(
                [call.args[:2] for call in execute.call_args_list],
                [
                    ("write-holding-broadcast", ["--address", "4002", "--value", "65535"]),
                    ("write-holding-broadcast", ["--address", "4003", "--value", "65535"]),
                ],
            )
        finally:
            window.close()

    def test_reconnect_is_available_for_serial_and_starts_disconnect(self):
        app = QApplication.instance() or QApplication([])
        window = DeviceSettingMainWindow()
        try:
            window.communication_settings_panel.radio_button_serial_rtu.setChecked(True)
            window._session_ready_flag = True
            window._cli_busy = False
            window._connected = True
            window._update_action_states()

            self.assertTrue(window.push_button_reconnect.isEnabled())
            with patch.object(window, "_on_disconnect_clicked") as disconnect:
                window._on_reconnect_clicked()

            self.assertTrue(window._reconnect_requested)
            self.assertEqual(window.push_button_reconnect.toolTip(), "Reconnecting...")
            disconnect.assert_called_once_with()
        finally:
            window.close()


if __name__ == "__main__":
    unittest.main()
