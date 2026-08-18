"""
Identify session: discover hubs/devices and assign permanent Modbus slave IDs.

Contract (firmware):
  - Broadcast unit id = 0
  - Holding 4000 = SlaveId, 4001 = IdentifyStatus
  - Holding 0/1 = DeviceId / ParameterListVersion
  - Holding 14 = DownStreamQty
  - DownStreamsSetting[i].SlaveIdMin/Max addresses from parameter-list JSON
  - Temporary discovery uses slave id 1; permanent ids 247 .. 2
"""

from __future__ import annotations

from collections.abc import Callable
from pathlib import Path

from core.codegen_parameter_list_catalog import (
    CodeGenParameterListCatalog,
    CodeGenParameterListCatalogError,
)
from core.codegen_parameter_list_models import CodeGenParameterListPackage
from core.device_modbus_link import DeviceModbusLink, DeviceModbusLinkError
from core.device_topology_models import DeviceIdentifyResult, IdentifiedDeviceNode
from core.device_setting_tree_loader import get_fixed_codegen_json_root_directory

HOLDING_ADDRESS_DEVICE_ID = 0
HOLDING_ADDRESS_PARAMETER_LIST_VERSION = 1
HOLDING_ADDRESS_DOWNSTREAM_QUANTITY = 14
HOLDING_ADDRESS_SLAVE_ID = 4000
HOLDING_ADDRESS_IDENTIFY_STATUS = 4001

BROADCAST_MODBUS_UNIT_IDENTIFIER = 0
TEMPORARY_DISCOVERY_MODBUS_UNIT_IDENTIFIER = 1
FIRST_PERMANENT_MODBUS_SLAVE_ID = 247
LAST_PERMANENT_MODBUS_SLAVE_ID = 2

LogCallback = Callable[[str], None]


class DeviceIdentifySessionError(Exception):
    pass


class DeviceIdentifySession:
    def __init__(
        self,
        device_modbus_link: DeviceModbusLink,
        codegen_json_root_directory: Path | None = None,
        log_callback: LogCallback | None = None,
    ) -> None:
        self._device_modbus_link = device_modbus_link
        self._codegen_json_root_directory = (
            Path(codegen_json_root_directory)
            if codegen_json_root_directory is not None
            else get_fixed_codegen_json_root_directory()
        )
        self._log_callback = log_callback
        self._next_permanent_slave_id = FIRST_PERMANENT_MODBUS_SLAVE_ID
        self._log_lines: list[str] = []
        self._catalog = CodeGenParameterListCatalog(self._codegen_json_root_directory)

    def run_identify(self) -> DeviceIdentifyResult:
        if not self._device_modbus_link.is_connected:
            raise DeviceIdentifySessionError("Not connected.")

        self._next_permanent_slave_id = FIRST_PERMANENT_MODBUS_SLAVE_ID
        self._log_lines = []
        self._log("Identify start.")

        try:
            self._catalog.scan_catalog_from_disk()
        except CodeGenParameterListCatalogError as exc:
            raise DeviceIdentifySessionError(str(exc)) from exc

        try:
            self._broadcast_write_u16(HOLDING_ADDRESS_SLAVE_ID, 1)
            self._log("Broadcast SlaveId=1")
            self._broadcast_write_u16(HOLDING_ADDRESS_IDENTIFY_STATUS, 1)
            self._log("Broadcast IdentifyStatus=1")

            root = self._discover_node_on_temporary_slave_one(parent_node=None, port_index_on_parent=None)
            if root is None:
                raise DeviceIdentifySessionError(
                    "No device answered on temporary SlaveId=1 after broadcast."
                )

            self._scan_downstream_ports_recursively(root)

            self._broadcast_write_u16(HOLDING_ADDRESS_IDENTIFY_STATUS, 0)
            self._log("Broadcast IdentifyStatus=0 — Identify finished.")
        except Exception:
            # Best-effort clear identify flag
            try:
                self._broadcast_write_u16(HOLDING_ADDRESS_IDENTIFY_STATUS, 0)
            except Exception:
                pass
            raise

        assigned = FIRST_PERMANENT_MODBUS_SLAVE_ID - self._next_permanent_slave_id
        return DeviceIdentifyResult(
            root_node=root,
            assigned_slave_id_count=assigned,
            log_lines=list(self._log_lines),
        )

    def _discover_node_on_temporary_slave_one(
        self,
        parent_node: IdentifiedDeviceNode | None,
        port_index_on_parent: int | None,
    ) -> IdentifiedDeviceNode | None:
        try:
            device_id = self._read_u16(
                HOLDING_ADDRESS_DEVICE_ID, TEMPORARY_DISCOVERY_MODBUS_UNIT_IDENTIFIER
            )
            parameter_list_version = self._read_u16(
                HOLDING_ADDRESS_PARAMETER_LIST_VERSION,
                TEMPORARY_DISCOVERY_MODBUS_UNIT_IDENTIFIER,
            )
        except DeviceModbusLinkError as exc:
            self._log(f"Probe SlaveId=1 failed: {exc}")
            return None

        try:
            package = self._catalog.load_parameter_list_package(
                device_id, parameter_list_version
            )
        except CodeGenParameterListCatalogError as exc:
            raise DeviceIdentifySessionError(
                f"No JSON for DeviceId={device_id} Version={parameter_list_version}: {exc}"
            ) from exc

        permanent_slave_id = self._allocate_permanent_slave_id()
        self._write_u16(
            HOLDING_ADDRESS_SLAVE_ID,
            permanent_slave_id,
            TEMPORARY_DISCOVERY_MODBUS_UNIT_IDENTIFIER,
        )
        self._log(
            f"Assigned SlaveId={permanent_slave_id} to DeviceId={device_id} "
            f"({package.info.device_name}) Version={parameter_list_version}"
        )

        try:
            downstream_quantity = self._read_u16(
                HOLDING_ADDRESS_DOWNSTREAM_QUANTITY, permanent_slave_id
            )
        except DeviceModbusLinkError as exc:
            raise DeviceIdentifySessionError(
                f"Cannot read DownStreamQty from SlaveId={permanent_slave_id}: {exc}"
            ) from exc

        node = IdentifiedDeviceNode(
            device_id=device_id,
            parameter_list_version=parameter_list_version,
            device_name=package.info.device_name,
            permanent_modbus_slave_id=permanent_slave_id,
            downstream_port_quantity=downstream_quantity,
            parent_node=parent_node,
            port_index_on_parent=port_index_on_parent,
        )

        if parent_node is not None and port_index_on_parent is not None:
            parent_node.children_by_port_index[port_index_on_parent] = node
            self._expand_routing_ranges_for_slave_id_on_ancestors(
                child_node=node, permanent_slave_id=permanent_slave_id
            )

        # Cache package on node via attribute for port address lookup
        node._parameter_list_package = package  # type: ignore[attr-defined]
        return node

    def _scan_downstream_ports_recursively(self, hub_node: IdentifiedDeviceNode) -> None:
        if hub_node.downstream_port_quantity <= 0:
            self._log(
                f"SlaveId={hub_node.permanent_modbus_slave_id} is leaf "
                f"(DownStreamQty=0)."
            )
            return

        package: CodeGenParameterListPackage = hub_node._parameter_list_package  # type: ignore[attr-defined]
        qty = hub_node.downstream_port_quantity
        self._log(
            f"Hub SlaveId={hub_node.permanent_modbus_slave_id} "
            f"DownStreamQty={qty} — scanning ports..."
        )

        for port_index in range(qty):
            self._configure_hub_ports_for_discovery_scan(hub_node, package, port_index)
            self._log(
                f"Hub {hub_node.permanent_modbus_slave_id} port[{port_index}] "
                f"open for discovery (Min=Max=1)"
            )

            child = self._discover_node_on_temporary_slave_one(
                parent_node=hub_node, port_index_on_parent=port_index
            )
            if child is None:
                # empty port — keep closed
                self._write_port_min_max(hub_node, package, port_index, 0, 0)
                hub_node.downstream_port_slave_id_min[port_index] = 0
                hub_node.downstream_port_slave_id_max[port_index] = 0
                self._log(
                    f"Hub {hub_node.permanent_modbus_slave_id} port[{port_index}] empty."
                )
                continue

            # Permanent range for this direct child (expanded later if subtree grows)
            self._write_port_min_max(
                hub_node,
                package,
                port_index,
                child.permanent_modbus_slave_id,
                child.permanent_modbus_slave_id,
            )
            hub_node.downstream_port_slave_id_min[port_index] = (
                child.permanent_modbus_slave_id
            )
            hub_node.downstream_port_slave_id_max[port_index] = (
                child.permanent_modbus_slave_id
            )

            self._scan_downstream_ports_recursively(child)

    def _configure_hub_ports_for_discovery_scan(
        self,
        hub_node: IdentifiedDeviceNode,
        package: CodeGenParameterListPackage,
        discovery_port_index: int,
    ) -> None:
        """
        Keep already-discovered ports at their permanent ranges;
        set discovery port to 1..1; unscoped empty ports stay 0..0.
        Also ensure every ancestor still routes temporary id 1 toward this hub.
        """
        for port_index in range(hub_node.downstream_port_quantity):
            if port_index == discovery_port_index:
                self._write_port_min_max(hub_node, package, port_index, 1, 1)
            elif port_index in hub_node.children_by_port_index:
                child = hub_node.children_by_port_index[port_index]
                # Range covering that child's subtree slave ids (from software mirror)
                min_id = hub_node.downstream_port_slave_id_min.get(
                    port_index, child.permanent_modbus_slave_id
                )
                max_id = hub_node.downstream_port_slave_id_max.get(
                    port_index, child.permanent_modbus_slave_id
                )
                self._write_port_min_max(hub_node, package, port_index, min_id, max_id)
            else:
                self._write_port_min_max(hub_node, package, port_index, 0, 0)

        self._ensure_ancestors_forward_temporary_slave_one(hub_node)

    def _ensure_ancestors_forward_temporary_slave_one(
        self, hub_node: IdentifiedDeviceNode
    ) -> None:
        """Ancestors must forward unit=1 to the port that leads to hub_node."""
        node = hub_node
        while node.parent_node is not None and node.port_index_on_parent is not None:
            parent = node.parent_node
            port_index = node.port_index_on_parent
            package: CodeGenParameterListPackage = parent._parameter_list_package  # type: ignore[attr-defined]
            min_id = parent.downstream_port_slave_id_min.get(
                port_index, node.permanent_modbus_slave_id
            )
            max_id = parent.downstream_port_slave_id_max.get(
                port_index, node.permanent_modbus_slave_id
            )
            new_min = min(min_id, TEMPORARY_DISCOVERY_MODBUS_UNIT_IDENTIFIER) if min_id else 1
            # If min was 0 (closed), open to 1..max(permanent)
            if min_id == 0 and max_id == 0:
                new_min = 1
                new_max = max(node.permanent_modbus_slave_id, 1)
            else:
                new_min = min(min_id, 1)
                new_max = max(max_id, 1, node.permanent_modbus_slave_id)
            self._write_port_min_max(parent, package, port_index, new_min, new_max)
            parent.downstream_port_slave_id_min[port_index] = new_min
            parent.downstream_port_slave_id_max[port_index] = new_max
            node = parent

    def _expand_routing_ranges_for_slave_id_on_ancestors(
        self, child_node: IdentifiedDeviceNode, permanent_slave_id: int
    ) -> None:
        """Every hub on the path must allow permanent_slave_id on the port toward the child."""
        node = child_node
        while node.parent_node is not None and node.port_index_on_parent is not None:
            parent = node.parent_node
            port_index = node.port_index_on_parent
            package: CodeGenParameterListPackage = parent._parameter_list_package  # type: ignore[attr-defined]
            old_min = parent.downstream_port_slave_id_min.get(port_index, permanent_slave_id)
            old_max = parent.downstream_port_slave_id_max.get(port_index, permanent_slave_id)
            if old_min == 0 and old_max == 0:
                new_min = permanent_slave_id
                new_max = permanent_slave_id
            else:
                # Drop temporary 1 from range when finalizing if only path ids matter;
                # keep full span of permanent ids in subtree.
                candidates = [permanent_slave_id, old_min, old_max]
                permanent_candidates = [c for c in candidates if c >= LAST_PERMANENT_MODBUS_SLAVE_ID]
                if not permanent_candidates:
                    permanent_candidates = [permanent_slave_id]
                new_min = min(permanent_candidates)
                new_max = max(permanent_candidates)
            self._write_port_min_max(parent, package, port_index, new_min, new_max)
            parent.downstream_port_slave_id_min[port_index] = new_min
            parent.downstream_port_slave_id_max[port_index] = new_max
            node = parent

    def _write_port_min_max(
        self,
        hub_node: IdentifiedDeviceNode,
        package: CodeGenParameterListPackage,
        port_index: int,
        slave_id_min: int,
        slave_id_max: int,
    ) -> None:
        min_name = f"DownStreamsSetting[{port_index}].SlaveIdMin"
        max_name = f"DownStreamsSetting[{port_index}].SlaveIdMax"
        min_addr = _find_parameter_modbus_address(package, min_name)
        max_addr = _find_parameter_modbus_address(package, max_name)
        unit = hub_node.permanent_modbus_slave_id
        self._write_u16(min_addr, slave_id_min, unit)
        self._write_u16(max_addr, slave_id_max, unit)

    def _allocate_permanent_slave_id(self) -> int:
        if self._next_permanent_slave_id < LAST_PERMANENT_MODBUS_SLAVE_ID:
            raise DeviceIdentifySessionError(
                "Too many devices: permanent SlaveId pool 247..2 exhausted."
            )
        allocated = self._next_permanent_slave_id
        self._next_permanent_slave_id -= 1
        return allocated

    def _broadcast_write_u16(self, address: int, value: int) -> None:
        self._write_u16(address, value, BROADCAST_MODBUS_UNIT_IDENTIFIER)

    def _read_u16(self, address: int, unit_id: int) -> int:
        return self._device_modbus_link.read_holding_register_u16(
            address, modbus_unit_identifier=unit_id
        )

    def _write_u16(self, address: int, value: int, unit_id: int) -> None:
        self._device_modbus_link.write_holding_register_u16(
            address, value, modbus_unit_identifier=unit_id
        )

    def _log(self, message: str) -> None:
        self._log_lines.append(message)
        if self._log_callback is not None:
            self._log_callback(message)


def _find_parameter_modbus_address(
    package: CodeGenParameterListPackage, parameter_name: str
) -> int:
    for parameter in package.parameters:
        if parameter.parameter_name == parameter_name:
            return parameter.modbus_address
    raise DeviceIdentifySessionError(
        f"Parameter {parameter_name!r} not found in parameter list "
        f"for DeviceId={package.device_id} Version={package.parameter_list_version}."
    )
