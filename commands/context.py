"""
Session state shared across commands in one process lifetime.

GUI and CLI both hold one CommandSessionContext.
"""

from __future__ import annotations

from dataclasses import dataclass, field
from pathlib import Path
from typing import Callable

from core.codegen_parameter_list_models import CodeGenParameterListPackage
from core.device_modbus_link import DeviceModbusLink
from core.device_setting_tree_loader import (
    DeviceSettingTreeLoadResult,
    get_fixed_codegen_json_root_directory,
)
from core.device_topology_models import DeviceIdentifyResult, IdentifiedDeviceNode


LogCallback = Callable[[str], None]


@dataclass
class CommandSessionContext:
    device_modbus_link: DeviceModbusLink = field(default_factory=DeviceModbusLink)
    codegen_json_root_directory: Path = field(
        default_factory=get_fixed_codegen_json_root_directory
    )
    last_identify_result: DeviceIdentifyResult | None = None
    selected_slave_id: int | None = None
    last_settings_load_result: DeviceSettingTreeLoadResult | None = None
    log_callback: LogCallback | None = None

    def log(self, message: str) -> None:
        if self.log_callback is not None:
            self.log_callback(message)

    def require_connected(self) -> None:
        if not self.device_modbus_link.is_connected:
            raise RuntimeError("Not connected. Run: connect ...")

    def effective_slave_id(self, slave_id_argument: int | None) -> int:
        if slave_id_argument is not None:
            return int(slave_id_argument)
        if self.selected_slave_id is not None:
            return int(self.selected_slave_id)
        raise RuntimeError(
            "No device selected. Run: select-device --slave-id <id> "
            "or pass --slave-id on the command."
        )

    def find_node_by_slave_id(self, slave_id: int) -> IdentifiedDeviceNode | None:
        result = self.last_identify_result
        if result is None or result.root_node is None:
            return None
        for node in result.root_node.iter_depth_first():
            if node.permanent_modbus_slave_id == slave_id:
                return node
        return None

    def loaded_package(self) -> CodeGenParameterListPackage:
        if self.last_settings_load_result is None:
            raise RuntimeError("Settings not loaded. Run: load-settings")
        return self.last_settings_load_result.parameter_list_package
