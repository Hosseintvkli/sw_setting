from __future__ import annotations

import unittest
from types import SimpleNamespace
from unittest.mock import Mock

from core.device_setting_tree_loader import DeviceSettingTreeLoader


class SettingsReadBatchSizeTests(unittest.TestCase):
    def test_contiguous_settings_are_read_in_at_most_120_register_batches(self):
        link = Mock()
        link.read_holding_registers_u16.side_effect = (
            lambda modbus_start_address, register_count, modbus_unit_identifier: [
                0
            ]
            * register_count
        )
        parameters = [
            SimpleNamespace(
                modbus_address=2000 + offset,
                modbus_register_size=1,
                data_type_name="U16",
            )
            for offset in range(250)
        ]
        loader = DeviceSettingTreeLoader(link, 247)

        register_map, error_map = (
            loader._read_holding_registers_for_parameters_batched(
                parameters,
                progress_callback=None,
            )
        )

        calls = link.read_holding_registers_u16.call_args_list
        self.assertEqual(
            [call.kwargs["modbus_start_address"] for call in calls],
            [2000, 2120, 2240],
        )
        self.assertEqual(
            [call.kwargs["register_count"] for call in calls],
            [120, 120, 10],
        )
        self.assertEqual(len(register_map), 250)
        self.assertEqual(error_map, {})


if __name__ == "__main__":
    unittest.main()
