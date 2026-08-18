"""
Identify session: discover hubs/devices and assign permanent Modbus slave IDs.

Every Modbus step is written to the log callback so the right-hand Log panel
shows exactly how far the process went (useful with simulators that ignore
SlaveId register changes).
"""

from __future__ import annotations

from collections.abc import Callable
from pathlib import Path
import time

from core.codegen_parameter_list_catalog import (
    CodeGenParameterListCatalog,
    CodeGenParameterListCatalogError,
)
from core.codegen_parameter_list_models import CodeGenParameterListPackage
from core.device_modbus_link import DeviceModbusLink, DeviceModbusLinkError
from core.device_setting_tree_loader import get_fixed_codegen_json_root_directory
from core.device_topology_models import DeviceIdentifyResult, IdentifiedDeviceNode

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
        self._step_number = 0

    def run_identify(self) -> DeviceIdentifyResult:
        if not self._device_modbus_link.is_connected:
            raise DeviceIdentifySessionError("Not connected.")

        self._next_permanent_slave_id = FIRST_PERMANENT_MODBUS_SLAVE_ID
        self._log_lines = []
        self._step_number = 0
        self._log("========== IDENTIFY START ==========")
        self._log(
            "Note: real hubs change SlaveId at holding 4000; "
            "Modbus Slave simulators often ignore that — later steps may fail."
        )

        try:
            self._log(
                f"Scanning JSON catalog: {self._codegen_json_root_directory}"
            )
            self._catalog.scan_catalog_from_disk()
            self._log("JSON catalog scan OK.")
        except CodeGenParameterListCatalogError as exc:
            self._log(f"FAIL catalog: {exc}")
            raise DeviceIdentifySessionError(str(exc)) from exc

        root: IdentifiedDeviceNode | None = None
        try:
            self._log(
                f"STEP broadcast WRITE unit={BROADCAST_MODBUS_UNIT_IDENTIFIER} "
                f"addr={HOLDING_ADDRESS_SLAVE_ID} value=1 (force all SlaveId→1)"
            )
            self._broadcast_write_u16(HOLDING_ADDRESS_SLAVE_ID, 1)
            self._log(
                "  → broadcast SlaveId=1 sent "
                "(no reply expected — timeout is OK)"
            )
            settle_s = self._settle_seconds_after_broadcast()
            self._log(
                f"  Waiting {settle_s:.3f}s after broadcast "
                f"(= Write timeout from Communicate settings; "
                f"set simulator unit/SlaveId to 1 now if testing manually)..."
            )
            time.sleep(settle_s)

            self._log(
                f"STEP broadcast WRITE unit={BROADCAST_MODBUS_UNIT_IDENTIFIER} "
                f"addr={HOLDING_ADDRESS_IDENTIFY_STATUS} value=1"
            )
            self._broadcast_write_u16(HOLDING_ADDRESS_IDENTIFY_STATUS, 1)
            self._log(
                "  → broadcast IdentifyStatus=1 sent (no reply expected)"
            )
            settle_s = self._settle_seconds_after_broadcast()
            self._log(
                f"  Waiting {settle_s:.3f}s after broadcast "
                f"(= Write timeout from Communicate settings)..."
            )
            time.sleep(settle_s)

            self._log(
                f"STEP probe root: READ unit={TEMPORARY_DISCOVERY_MODBUS_UNIT_IDENTIFIER} "
                f"addr {HOLDING_ADDRESS_DEVICE_ID} and {HOLDING_ADDRESS_PARAMETER_LIST_VERSION}"
            )
            root = self._discover_node_on_temporary_slave_one(
                parent_node=None, port_index_on_parent=None
            )
            if root is None:
                self._log(
                    "FAIL: no response on temporary SlaveId=1. "
                    "Check simulator unit id is 1 (or device accepted broadcast)."
                )
                raise DeviceIdentifySessionError(
                    "No device answered on temporary SlaveId=1 after broadcast."
                )

            self._log(
                f"Root discovered: name={root.device_name!r} "
                f"DeviceId={root.device_id} Version={root.parameter_list_version} "
                f"permanent SlaveId={root.permanent_modbus_slave_id} "
                f"DownStreamQty={root.downstream_port_quantity}"
            )

            self._scan_downstream_ports_recursively(root)

            self._log(
                f"STEP broadcast WRITE unit={BROADCAST_MODBUS_UNIT_IDENTIFIER} "
                f"addr={HOLDING_ADDRESS_IDENTIFY_STATUS} value=0"
            )
            self._broadcast_write_u16(HOLDING_ADDRESS_IDENTIFY_STATUS, 0)
            self._log("  → broadcast IdentifyStatus=0 OK")
            self._log("========== IDENTIFY FINISHED OK ==========")
        except Exception as exc:
            self._log(f"IDENTIFY ABORT: {type(exc).__name__}: {exc}")
            try:
                self._log("Best-effort: broadcast IdentifyStatus=0")
                self._broadcast_write_u16(HOLDING_ADDRESS_IDENTIFY_STATUS, 0)
                self._log("  → IdentifyStatus cleared")
            except Exception as clear_exc:
                self._log(f"  → could not clear IdentifyStatus: {clear_exc}")
            self._log("========== IDENTIFY FAILED ==========")
            raise

        assigned = FIRST_PERMANENT_MODBUS_SLAVE_ID - self._next_permanent_slave_id
        self._log(f"Total permanent SlaveIds assigned: {assigned}")
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
        unit = TEMPORARY_DISCOVERY_MODBUS_UNIT_IDENTIFIER
        parent_info = (
            "root"
            if parent_node is None
            else (
                f"parent SlaveId={parent_node.permanent_modbus_slave_id} "
                f"port[{port_index_on_parent}]"
            )
        )
        self._log(f"--- discover under {parent_info} via unit={unit} ---")

        try:
            self._log(f"  READ unit={unit} addr={HOLDING_ADDRESS_DEVICE_ID}")
            device_id = self._read_u16(HOLDING_ADDRESS_DEVICE_ID, unit)
            self._log(f"  → DeviceId={device_id}")

            self._log(
                f"  READ unit={unit} addr={HOLDING_ADDRESS_PARAMETER_LIST_VERSION}"
            )
            parameter_list_version = self._read_u16(
                HOLDING_ADDRESS_PARAMETER_LIST_VERSION, unit
            )
            self._log(f"  → ParameterListVersion={parameter_list_version}")
        except DeviceModbusLinkError as exc:
            self._log(f"  → no answer / read failed: {exc}")
            return None

        try:
            self._log(
                f"  Load JSON package DeviceId={device_id} "
                f"Version={parameter_list_version}"
            )
            package = self._catalog.load_parameter_list_package(
                device_id, parameter_list_version
            )
            self._log(f"  → JSON OK name={package.info.device_name!r}")
        except CodeGenParameterListCatalogError as exc:
            self._log(f"  → JSON FAIL: {exc}")
            raise DeviceIdentifySessionError(
                f"No JSON for DeviceId={device_id} Version={parameter_list_version}: {exc}"
            ) from exc

        permanent_slave_id = self._allocate_permanent_slave_id()
        self._log(
            f"  WRITE unit={unit} addr={HOLDING_ADDRESS_SLAVE_ID} "
            f"value={permanent_slave_id} (assign permanent SlaveId)"
        )
        try:
            self._write_u16(HOLDING_ADDRESS_SLAVE_ID, permanent_slave_id, unit)
            settle_s = self._settle_seconds_after_slave_id_assign()
            self._log(
                f"  → assign write OK. Waiting {settle_s:.3f}s "
                f"(= Write timeout from Communicate settings; "
                f"if simulator: change unit to {permanent_slave_id} now)..."
            )
            time.sleep(settle_s)
        except DeviceModbusLinkError as exc:
            self._log(f"  → assign write FAIL: {exc}")
            raise DeviceIdentifySessionError(
                f"Failed to write permanent SlaveId={permanent_slave_id}: {exc}"
            ) from exc

        # Build node early so we can open hub routing before any unicast to permanent id.
        node = IdentifiedDeviceNode(
            device_id=device_id,
            parameter_list_version=parameter_list_version,
            device_name=package.info.device_name,
            permanent_modbus_slave_id=permanent_slave_id,
            downstream_port_quantity=0,
            parent_node=parent_node,
            port_index_on_parent=port_index_on_parent,
        )
        node._parameter_list_package = package  # type: ignore[attr-defined]

        if parent_node is not None and port_index_on_parent is not None:
            parent_node.children_by_port_index[port_index_on_parent] = node
            self._log(
                f"  Open hub path for permanent SlaveId={permanent_slave_id} "
                f"on all ancestor ports BEFORE talking to unit={permanent_slave_id}"
            )
            self._expand_routing_ranges_for_slave_id_on_ancestors(
                child_node=node, permanent_slave_id=permanent_slave_id
            )
            settle_s = self._settle_seconds_after_slave_id_assign()
            self._log(
                f"  Waiting {settle_s:.3f}s after routing update "
                f"(Write timeout) so hubs apply Min/Max..."
            )
            time.sleep(settle_s)
        else:
            self._log(
                "  Root device — no parent hub routing to update before permanent-unit I/O"
            )

        self._log(
            f"  READ unit={permanent_slave_id} addr={HOLDING_ADDRESS_DOWNSTREAM_QUANTITY}"
        )
        try:
            downstream_quantity = self._read_u16(
                HOLDING_ADDRESS_DOWNSTREAM_QUANTITY, permanent_slave_id
            )
            self._log(f"  → DownStreamQty={downstream_quantity}")
        except DeviceModbusLinkError as exc:
            self._log(
                f"  → read DownStreamQty on unit={permanent_slave_id} FAIL: {exc}. "
                f"If using a fixed-unit simulator, it still answers only on unit={unit}."
            )
            raise DeviceIdentifySessionError(
                f"Cannot read DownStreamQty from SlaveId={permanent_slave_id}: {exc}"
            ) from exc

        node.downstream_port_quantity = downstream_quantity
        self._log(
            f"  Node ready: {node.device_name!r} permanent SlaveId={permanent_slave_id} "
            f"DownStreamQty={downstream_quantity}"
        )
        return node

    def _scan_downstream_ports_recursively(self, hub_node: IdentifiedDeviceNode) -> None:
        if hub_node.downstream_port_quantity <= 0:
            self._log(
                f"SlaveId={hub_node.permanent_modbus_slave_id} leaf "
                f"(DownStreamQty=0) — no ports to scan."
            )
            return

        package: CodeGenParameterListPackage = hub_node._parameter_list_package  # type: ignore[attr-defined]
        qty = hub_node.downstream_port_quantity
        self._log(
            f"=== Scan ports on hub SlaveId={hub_node.permanent_modbus_slave_id} "
            f"qty={qty} ==="
        )

        for port_index in range(qty):
            self._log(
                f"Port[{port_index}] of hub {hub_node.permanent_modbus_slave_id}: "
                f"configure discovery (Min=Max=1 on this port)"
            )
            self._configure_hub_ports_for_discovery_scan(hub_node, package, port_index)

            child = self._discover_node_on_temporary_slave_one(
                parent_node=hub_node, port_index_on_parent=port_index
            )
            if child is None:
                self._log(
                    f"Port[{port_index}] empty — close Min=Max=0"
                )
                self._write_port_min_max(hub_node, package, port_index, 0, 0)
                hub_node.downstream_port_slave_id_min[port_index] = 0
                hub_node.downstream_port_slave_id_max[port_index] = 0
                continue

            self._log(
                f"Port[{port_index}] child SlaveId={child.permanent_modbus_slave_id} "
                f"— set port range Min=Max={child.permanent_modbus_slave_id}"
            )
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
        for port_index in range(hub_node.downstream_port_quantity):
            if port_index == discovery_port_index:
                self._log(
                    f"  hub {hub_node.permanent_modbus_slave_id} "
                    f"port[{port_index}] → 1..1 (discovery open)"
                )
                self._write_port_min_max(hub_node, package, port_index, 1, 1)
            elif port_index in hub_node.children_by_port_index:
                child = hub_node.children_by_port_index[port_index]
                min_id = hub_node.downstream_port_slave_id_min.get(
                    port_index, child.permanent_modbus_slave_id
                )
                max_id = hub_node.downstream_port_slave_id_max.get(
                    port_index, child.permanent_modbus_slave_id
                )
                self._log(
                    f"  hub {hub_node.permanent_modbus_slave_id} "
                    f"port[{port_index}] keep {min_id}..{max_id}"
                )
                self._write_port_min_max(hub_node, package, port_index, min_id, max_id)
            else:
                self._log(
                    f"  hub {hub_node.permanent_modbus_slave_id} "
                    f"port[{port_index}] → 0..0 (closed)"
                )
                self._write_port_min_max(hub_node, package, port_index, 0, 0)

        self._ensure_ancestors_forward_temporary_slave_one(hub_node)

    def _ensure_ancestors_forward_temporary_slave_one(
        self, hub_node: IdentifiedDeviceNode
    ) -> None:
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
            if min_id == 0 and max_id == 0:
                new_min = 1
                new_max = max(node.permanent_modbus_slave_id, 1)
            else:
                new_min = min(min_id, 1)
                new_max = max(max_id, 1, node.permanent_modbus_slave_id)
            self._log(
                f"  ancestor hub {parent.permanent_modbus_slave_id} "
                f"port[{port_index}] ensure forwards 1 → set {new_min}..{new_max}"
            )
            self._write_port_min_max(parent, package, port_index, new_min, new_max)
            parent.downstream_port_slave_id_min[port_index] = new_min
            parent.downstream_port_slave_id_max[port_index] = new_max
            node = parent

    def _expand_routing_ranges_for_slave_id_on_ancestors(
        self, child_node: IdentifiedDeviceNode, permanent_slave_id: int
    ) -> None:
        node = child_node
        while node.parent_node is not None and node.port_index_on_parent is not None:
            parent = node.parent_node
            port_index = node.port_index_on_parent
            package: CodeGenParameterListPackage = parent._parameter_list_package  # type: ignore[attr-defined]
            old_min = parent.downstream_port_slave_id_min.get(
                port_index, permanent_slave_id
            )
            old_max = parent.downstream_port_slave_id_max.get(
                port_index, permanent_slave_id
            )
            if old_min == 0 and old_max == 0:
                new_min = permanent_slave_id
                new_max = permanent_slave_id
            else:
                candidates = [permanent_slave_id, old_min, old_max]
                permanent_candidates = [
                    c for c in candidates if c >= LAST_PERMANENT_MODBUS_SLAVE_ID
                ]
                if not permanent_candidates:
                    permanent_candidates = [permanent_slave_id]
                new_min = min(permanent_candidates)
                new_max = max(permanent_candidates)
            self._log(
                f"  routing: hub {parent.permanent_modbus_slave_id} "
                f"port[{port_index}] → {new_min}..{new_max} "
                f"(include SlaveId={permanent_slave_id})"
            )
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
        self._log(
            f"    WRITE unit={unit} {min_name}@addr={min_addr}={slave_id_min}, "
            f"{max_name}@addr={max_addr}={slave_id_max}"
        )
        self._write_u16(min_addr, slave_id_min, unit)
        self._write_u16(max_addr, slave_id_max, unit)

    def _allocate_permanent_slave_id(self) -> int:
        if self._next_permanent_slave_id < LAST_PERMANENT_MODBUS_SLAVE_ID:
            self._log("FAIL: SlaveId pool 247..2 exhausted")
            raise DeviceIdentifySessionError(
                "Too many devices: permanent SlaveId pool 247..2 exhausted."
            )
        allocated = self._next_permanent_slave_id
        self._next_permanent_slave_id -= 1
        self._log(f"  Allocated permanent SlaveId={allocated}")
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

    def _settle_seconds_after_broadcast(self) -> float:
        """Use Communicate Write timeout — broadcast has no reply."""
        return self._device_modbus_link.get_active_write_timeout_seconds()

    def _settle_seconds_after_slave_id_assign(self) -> float:
        """Same Write timeout window for manual simulator unit change."""
        return self._device_modbus_link.get_active_write_timeout_seconds()

    def _log(self, message: str) -> None:
        self._step_number += 1
        line = f"[ID:{self._step_number:04d}] {message}"
        self._log_lines.append(line)
        if self._log_callback is not None:
            self._log_callback(line)


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
