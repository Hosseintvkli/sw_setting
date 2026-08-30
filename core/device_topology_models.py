"""Topology tree produced by the Identify process."""

from __future__ import annotations

from dataclasses import dataclass, field
from typing import TYPE_CHECKING

if TYPE_CHECKING:
    from core.codegen_parameter_list_models import CodeGenParameterListPackage


@dataclass
class IdentifiedDeviceNode:
    """One device or hub discovered on the bus."""

    device_id: int
    parameter_list_version: int
    device_name: str
    permanent_modbus_slave_id: int
    downstream_port_quantity: int
    parameter_list_package: CodeGenParameterListPackage = field(
        repr=False, compare=False
    )
    parent_node: IdentifiedDeviceNode | None = None
    port_index_on_parent: int | None = None
    # port_index -> child node (only ports that answered)
    children_by_port_index: dict[int, IdentifiedDeviceNode] = field(default_factory=dict)
    # Software mirror of DownStreamsSetting[i] min/max on this hub
    downstream_port_slave_id_min: dict[int, int] = field(default_factory=dict)
    downstream_port_slave_id_max: dict[int, int] = field(default_factory=dict)

    def iter_depth_first(self):
        yield self
        for port_index in sorted(self.children_by_port_index):
            child = self.children_by_port_index[port_index]
            yield from child.iter_depth_first()


@dataclass
class DeviceIdentifyResult:
    root_node: IdentifiedDeviceNode | None
    assigned_slave_id_count: int
    log_lines: list[str] = field(default_factory=list)
