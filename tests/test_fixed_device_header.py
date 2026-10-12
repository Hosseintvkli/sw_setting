from __future__ import annotations

import unittest
from types import SimpleNamespace
from unittest.mock import Mock

from commands.handlers.settings_commands import handle_get_monitoring_header
from core.device_setting_tree_loader import DeviceSettingTreeLoader


class FixedDeviceHeaderTests(unittest.TestCase):
    def test_header_is_read_without_parameter_list(self):
        registers = [0] * 17
        registers[0:4] = [1004, 16, 3, 9]
        registers[4:9] = [72, 1234, 0, 1013, 0]
        registers[9:11] = [2, 1]
        link = Mock()
        link.read_holding_registers_u16.return_value = registers
        context = SimpleNamespace(
            require_connected=lambda: None,
            effective_slave_id=lambda requested: requested,
            last_settings_load_result=None,
            device_modbus_link=link,
        )

        result = handle_get_monitoring_header(context, SimpleNamespace(slave_id=244))

        self.assertTrue(result.ok)
        self.assertEqual(result.data["serial_number"], 1013)
        self.assertEqual(result.data["device_id"], 1004)
        self.assertEqual(result.data["hardware_version"], "2.1")
        link.read_holding_registers_u16.assert_called_once_with(
            0, 17, modbus_unit_identifier=244
        )

    def test_settings_loader_keeps_all_four_firmware_version_parts(self):
        link = Mock()

        def read_registers(address, count, *, modbus_unit_identifier):
            self.assertEqual(modbus_unit_identifier, 244)
            if (address, count) == (2, 5):
                return [3, 9, 72, 1234, 0]
            if (address, count) == (7, 2):
                return [1013, 0]
            self.fail(f"Unexpected register read: address={address}, count={count}")

        link.read_holding_registers_u16.side_effect = read_registers
        link.read_holding_register_u16.side_effect = lambda address, **_kwargs: {
            9: 2,
            10: 1,
        }[address]
        loader = DeviceSettingTreeLoader(link, 244)

        header = loader._read_monitoring_header_values(1004, 16)

        self.assertEqual(header.firmware_version_text, "3.9.72.1234")


if __name__ == "__main__":
    unittest.main()
