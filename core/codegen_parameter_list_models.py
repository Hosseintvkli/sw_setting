"""
Data models for CodeGen JSON parameter lists used by the setting tool.
"""

from __future__ import annotations

from dataclasses import dataclass, field
from enum import Enum
from pathlib import Path


class ParameterAccessKind(Enum):
    """Parsed from ParameterType field in CodeGen JSON."""

    MONITORING_READ_ONLY = "monitoring_read_only"
    SETTING_READ_WRITE = "setting_read_write"
    COMMAND_WRITE = "command_write"
    UNKNOWN = "unknown"

    @staticmethod
    def from_codegen_parameter_type_string(parameter_type_text: str) -> ParameterAccessKind:
        normalized = (parameter_type_text or "").strip().upper()
        if "MONITORING" in normalized:
            return ParameterAccessKind.MONITORING_READ_ONLY
        if "SETTING" in normalized:
            return ParameterAccessKind.SETTING_READ_WRITE
        if "COMMAND" in normalized:
            return ParameterAccessKind.COMMAND_WRITE
        return ParameterAccessKind.UNKNOWN


@dataclass(frozen=True)
class CodeGenDeviceDatabaseEntry:
    """One row from cg_database_deviceid.json."""

    group_name: str
    device_name: str
    device_id: int
    description: str


@dataclass(frozen=True)
class CodeGenParameterListInfo:
    """Contents of cg_parameter_list_XXXXX_YYYYY_info.json."""

    device_name: str
    device_id: int
    downstream_quantity: int
    parameter_list_version: int
    info_json_file_path: Path


@dataclass
class CodeGenParameterDefinition:
    """One parameter entry from cg_parameter_list_*_parameter_list.json."""

    parameter_name: str
    modbus_register_size: int
    parameter_id: int
    modbus_address: int
    data_type_name: str
    parameter_type_raw_text: str
    parameter_access_kind: ParameterAccessKind
    description: str
    category_tag_1: str
    tag_2: str
    tag_3: str
    tag_4: str
    tag_5: str

    @property
    def name_path_segments(self) -> list[str]:
        """
        Split Name for tree building:
          - '.' separates struct-like path segments
          - 'ArrayName[i]' becomes branch ArrayName + leaf [i]

        Examples:
          InternalImu_Data.DeserializedErrorCounter
            -> ['InternalImu_Data', 'DeserializedErrorCounter']
          DbgControlSignalsI16[3]
            -> ['DbgControlSignalsI16', '[3]']
          Foo.Bar[0]
            -> ['Foo', 'Bar', '[0]']
        """
        import re

        segments: list[str] = []
        for dotted_part in self.parameter_name.split("."):
            if not dotted_part:
                continue
            array_match = re.fullmatch(r"(.+)\[(\d+)\]", dotted_part)
            if array_match:
                segments.append(array_match.group(1))
                segments.append(f"[{array_match.group(2)}]")
            else:
                segments.append(dotted_part)
        return segments


@dataclass
class CodeGenParameterListPackage:
    """
    One concrete parameter-list version for one device.

    Folder layout (under JSON/):
      parameter_list_{deviceId:05d}/
        parameter_list_{deviceId:05d}_{version:05d}/
          cg_parameter_list_{deviceId:05d}_{version:05d}_info.json
          cg_parameter_list_{deviceId:05d}_{version:05d}_parameter_list.json
    """

    device_id: int
    parameter_list_version: int
    package_directory_path: Path
    info: CodeGenParameterListInfo
    parameters: list[CodeGenParameterDefinition] = field(default_factory=list)

    def count_parameters_by_access_kind(self) -> dict[ParameterAccessKind, int]:
        counts: dict[ParameterAccessKind, int] = {kind: 0 for kind in ParameterAccessKind}
        for parameter in self.parameters:
            counts[parameter.parameter_access_kind] = (
                counts[parameter.parameter_access_kind] + 1
            )
        return counts

    def iter_setting_parameters(self):
        for parameter in self.parameters:
            if parameter.parameter_access_kind == ParameterAccessKind.SETTING_READ_WRITE:
                yield parameter

    def iter_command_parameters(self):
        for parameter in self.parameters:
            if parameter.parameter_access_kind == ParameterAccessKind.COMMAND_WRITE:
                yield parameter
