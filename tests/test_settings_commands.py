from __future__ import annotations

import unittest
from types import SimpleNamespace

from commands.handlers.settings_commands import (
    handle_get_monitoring_header,
    handle_get_parameter,
    handle_set_parameter,
)
from core.codegen_parameter_list_models import ParameterAccessKind


class FakeLink:
    def __init__(self) -> None:
        self.writes: list[tuple[int, list[int], int]] = []
        self.single_register_values = {0: 200, 1: 3}

    def write_holding_registers_u16(
        self, address: int, values: list[int], *, modbus_unit_identifier: int
    ) -> None:
        self.writes.append((address, values, modbus_unit_identifier))

    def read_holding_register_u16(
        self, address: int, *, modbus_unit_identifier: int
    ) -> int:
        return self.single_register_values[address]


def make_context(*, loaded_slave_id: int, parameter_access_kind: ParameterAccessKind):
    parameter = SimpleNamespace(
        parameter_name="Example",
        parameter_access_kind=parameter_access_kind,
        data_type_name="U16",
        modbus_address=20,
        modbus_register_size=1,
    )
    header = SimpleNamespace(
        modbus_slave_unit_identifier=loaded_slave_id,
        firmware_version_text="1.2",
        hardware_version_text="3.4",
        serial_number=123,
    )
    load = SimpleNamespace(
        device_id_from_device=100,
        parameter_list_version_from_device=2,
        parameter_list_package=SimpleNamespace(parameters=[parameter]),
        monitoring_header_values=header,
    )
    link = FakeLink()
    context = SimpleNamespace(
        require_connected=lambda: None,
        effective_slave_id=lambda argument: loaded_slave_id if argument is None else argument,
        last_settings_load_result=load,
        device_modbus_link=link,
    )
    return context, link


class SettingsCommandsTests(unittest.TestCase):
    def test_set_parameter_rejects_non_setting_parameter(self) -> None:
        context, link = make_context(
            loaded_slave_id=10,
            parameter_access_kind=ParameterAccessKind.MONITORING_READ_ONLY,
        )

        result = handle_set_parameter(
            context, SimpleNamespace(slave_id=10, name="Example", value="5")
        )

        self.assertFalse(result.ok)
        self.assertIn("not writable as a setting", result.error or "")
        self.assertEqual([], link.writes)

    def test_get_parameter_rejects_metadata_loaded_for_another_slave(self) -> None:
        context, _ = make_context(
            loaded_slave_id=10,
            parameter_access_kind=ParameterAccessKind.SETTING_READ_WRITE,
        )

        result = handle_get_parameter(
            context, SimpleNamespace(slave_id=11, name="Example")
        )

        self.assertFalse(result.ok)
        self.assertIn("loaded for SlaveId 10, not 11", result.error or "")

    def test_monitoring_header_ignores_cache_from_another_slave(self) -> None:
        context, _ = make_context(
            loaded_slave_id=10,
            parameter_access_kind=ParameterAccessKind.SETTING_READ_WRITE,
        )

        result = handle_get_monitoring_header(
            context, SimpleNamespace(slave_id=11)
        )

        self.assertTrue(result.ok)
        self.assertEqual(11, result.data["slave_id"])
        self.assertEqual(200, result.data["device_id"])
        self.assertEqual(3, result.data["parameter_list_version"])
        self.assertNotIn("serial_number", result.data)

    def test_monitoring_header_uses_cache_for_same_slave(self) -> None:
        context, _ = make_context(
            loaded_slave_id=10,
            parameter_access_kind=ParameterAccessKind.SETTING_READ_WRITE,
        )

        result = handle_get_monitoring_header(
            context, SimpleNamespace(slave_id=10)
        )

        self.assertTrue(result.ok)
        self.assertEqual(100, result.data["device_id"])
        self.assertEqual(123, result.data["serial_number"])


if __name__ == "__main__":
    unittest.main()
