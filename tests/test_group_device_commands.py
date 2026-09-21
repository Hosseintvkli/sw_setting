import unittest
from pathlib import Path
from types import SimpleNamespace
from unittest.mock import patch

from commands.handlers.profile_commands import handle_apply_profile
from core.codegen_parameter_list_models import ParameterAccessKind
from core.device_command_executor import DeviceCommandExecutor
from core.device_modbus_link import DeviceModbusLinkError
from core.setting_profile_csv import SettingProfileParseResult


class FakeLink:
    def __init__(self, read_values, failed_writes=()):
        self.operations = []
        self.read_values = dict(read_values)
        self.failed_writes = set(failed_writes)

    def write_holding_register_u16(self, address, value, modbus_unit_identifier=None):
        self.operations.append(("write", modbus_unit_identifier, address, value))
        if modbus_unit_identifier in self.failed_writes:
            raise DeviceModbusLinkError("write rejected")

    def _read_holding_registers_u16_once(self, address, count, unit_id):
        self.operations.append(("read", unit_id, address, count))
        return [self.read_values[unit_id].pop(0)]

    def get_active_read_timeout_seconds(self):
        return 0

    def get_active_command_execution_timeout_seconds(self):
        return 1

    def set_modbus_unit_identifier_override(self, unit_id):
        self._modbus_unit_identifier_override = unit_id


class GroupDeviceCommandTests(unittest.TestCase):
    def test_all_writes_precede_reads_and_pending_is_polled(self):
        link = FakeLink({244: [0xFFFF, 0], 245: [0]})

        results = DeviceCommandExecutor(link).execute_command_for_units(100, [244, 245])

        self.assertTrue(results[244].success)
        self.assertTrue(results[245].success)
        self.assertEqual([item[0] for item in link.operations[:2]], ["write", "write"])
        self.assertEqual(link.operations[:2], [
            ("write", 244, 100, 0xFFFF),
            ("write", 245, 100, 0xFFFF),
        ])
        self.assertEqual([item[0] for item in link.operations[2:]], ["read", "read", "read"])

    def test_failed_write_is_not_polled_but_other_units_continue(self):
        link = FakeLink({245: [7]}, failed_writes={244})

        results = DeviceCommandExecutor(link).execute_command_for_units(100, [244, 245])

        self.assertFalse(results[244].success)
        self.assertIn("write rejected", results[244].message)
        self.assertFalse(results[245].success)
        self.assertEqual(results[245].last_read_value, 7)
        self.assertNotIn(("read", 244, 100, 1), link.operations)

    def test_profile_triggers_all_matching_units_before_polling(self):
        link = FakeLink({244: [0], 245: [0]})
        definition = SimpleNamespace(
            parameter_access_kind=ParameterAccessKind.COMMAND_WRITE,
            modbus_address=100,
            data_type_name="U16",
        )
        assignment = SimpleNamespace(
            parameter_definition=definition,
            parsed_value=0xFFFF,
            parameter_name="ResetCommand",
        )
        nodes = [
            SimpleNamespace(
                device_id=1004,
                parameter_list_version=1,
                permanent_modbus_slave_id=unit_id,
                device_name=f"device_{unit_id}",
            )
            for unit_id in (244, 245)
        ]
        context = SimpleNamespace(
            require_connected=lambda: None,
            loaded_package=lambda: SimpleNamespace(parameter_list_version=1),
            last_settings_load_result=SimpleNamespace(device_id_from_device=1004),
            selected_slave_id=244,
            last_identify_result=SimpleNamespace(
                root_node=SimpleNamespace(iter_depth_first=lambda: iter(nodes))
            ),
            device_modbus_link=link,
        )
        args = SimpleNamespace(
            file=str(Path(__file__)), all_same_device_id=True, verbose=True
        )
        with patch(
            "commands.handlers.profile_commands.load_setting_profile_assignments_from_csv",
            return_value=SettingProfileParseResult([assignment], []),
        ):
            result = handle_apply_profile(context, args)

        self.assertTrue(result.ok)
        self.assertEqual(result.data["ok_count"], 2)
        self.assertEqual([item[0] for item in link.operations], [
            "write", "write", "read", "read"
        ])


if __name__ == "__main__":
    unittest.main()
