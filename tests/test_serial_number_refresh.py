from __future__ import annotations

import unittest
from types import SimpleNamespace
from unittest.mock import Mock

from commands.handlers.settings_commands import handle_set_parameter
from core.codegen_parameter_list_models import (
    CodeGenParameterDefinition,
    ParameterAccessKind,
)


class SerialNumberRefreshTests(unittest.TestCase):
    def test_successful_serial_write_updates_loaded_header_leaf_and_topology(self):
        parameter = CodeGenParameterDefinition(
            parameter_name="SerialNo",
            modbus_register_size=2,
            parameter_id=7,
            modbus_address=7,
            data_type_name="U32",
            parameter_type_raw_text="SETTING (R/W)",
            parameter_access_kind=ParameterAccessKind.SETTING_READ_WRITE,
            description="",
            category_tag_1="Info",
            tag_2="",
            tag_3="",
            tag_4="",
            tag_5="",
        )
        header = SimpleNamespace(
            modbus_slave_unit_identifier=247,
            serial_number=10,
        )
        leaf = SimpleNamespace(
            parameter=parameter,
            decoded_value=10,
            display_value_text="10",
            read_error_message=None,
        )
        load = SimpleNamespace(
            monitoring_header_values=header,
            parameter_list_package=SimpleNamespace(parameters=[parameter]),
            setting_leaf_values=[leaf],
        )
        node = SimpleNamespace(serial_number=10)
        link = Mock()
        context = SimpleNamespace(
            require_connected=lambda: None,
            effective_slave_id=lambda requested: requested or 247,
            last_settings_load_result=load,
            device_modbus_link=link,
            find_node_by_slave_id=lambda slave_id: node if slave_id == 247 else None,
        )

        result = handle_set_parameter(
            context,
            SimpleNamespace(name="SerialNo", value="123456", slave_id=247),
        )

        self.assertTrue(result.ok)
        self.assertEqual(result.data["serial_number"], 123456)
        self.assertEqual(header.serial_number, 123456)
        self.assertEqual(leaf.decoded_value, 123456)
        self.assertEqual(leaf.display_value_text, "123456")
        self.assertEqual(node.serial_number, 123456)


if __name__ == "__main__":
    unittest.main()
