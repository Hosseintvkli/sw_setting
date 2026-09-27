from __future__ import annotations

import unittest
from pathlib import Path

from core.codegen_parameter_list_catalog import CodeGenParameterListCatalog
from core.modbus_register_value_codec import (
    ModbusRegisterValueCodecError,
    decode_parameter_value_from_holding_registers,
    encode_parameter_value_to_holding_registers,
    format_decoded_parameter_value_for_display,
    register_count_for_data_type_name,
)
from core.parameter_value_validation import (
    ParameterValueValidationError,
    parse_and_validate_parameter_value_text,
)


class CodeGenEnumU16Tests(unittest.TestCase):
    ENUM_TYPE = "Parameters_DeviceID_01008_00006+eBaudrate"

    def test_real_codegen_enum_parameter_uses_one_register(self):
        json_root = Path(__file__).resolve().parents[1] / "files" / "codegen_output" / "JSON"
        catalog = CodeGenParameterListCatalog(json_root)
        catalog.scan_catalog_from_disk()
        package = catalog.load_parameter_list_package(1008, 6)
        parameter = next(p for p in package.parameters if p.parameter_name == "UpStreamBaudrate")
        self.assertEqual(parameter.data_type_name, self.ENUM_TYPE)
        self.assertEqual(register_count_for_data_type_name(parameter.data_type_name), 1)

    def test_enum_round_trip_and_numeric_display(self):
        self.assertEqual(decode_parameter_value_from_holding_registers(self.ENUM_TYPE, [65535]), 65535)
        self.assertEqual(encode_parameter_value_to_holding_registers(self.ENUM_TYPE, 42), [42])
        self.assertEqual(format_decoded_parameter_value_for_display(self.ENUM_TYPE, 42), "42")

    def test_enum_accepts_u16_range_only(self):
        self.assertEqual(parse_and_validate_parameter_value_text(self.ENUM_TYPE, "0xFFFF"), 65535)
        with self.assertRaises(ParameterValueValidationError):
            parse_and_validate_parameter_value_text(self.ENUM_TYPE, "65536")
        with self.assertRaises(ParameterValueValidationError):
            parse_and_validate_parameter_value_text(self.ENUM_TYPE, "eENABLE")

    def test_unrecognized_custom_type_is_not_assumed_to_be_enum(self):
        with self.assertRaises(ModbusRegisterValueCodecError):
            register_count_for_data_type_name("CustomStruct")


if __name__ == "__main__":
    unittest.main()
