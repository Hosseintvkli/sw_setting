from __future__ import annotations

import unittest
from types import SimpleNamespace
from unittest.mock import Mock

from commands.handlers.settings_commands import handle_get_monitoring_header


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


if __name__ == "__main__":
    unittest.main()
