"""
Identify session: discover hubs/devices and assign permanent Modbus slave IDs.

Every Modbus step is written to the log callback so the right-hand Log panel
shows exactly how far the process went (useful with simulators that ignore
SlaveId register changes).
"""

from __future__ import annotations

import time
from collections.abc import Callable
from pathlib import Path
from typing import Any

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

# A routing write is acknowledged by the hub before its downstream path is
# necessarily ready to forward the temporary discovery SlaveId.  Keep this
# independent from the user-facing Modbus read/write timeout (which may be as
# low as 100 ms for normal commands).
DISCOVERY_ROUTING_SETTLE_SECONDS = 0.5
DISCOVERY_PORT_PROBE_ATTEMPTS = 3
DISCOVERY_PORT_PROBE_RETRY_DELAY_SECONDS = 0.25

LogCallback = Callable[[str], None]
ProgressCallback = Callable[[str, str, dict[str, Any]], None]


class DeviceIdentifySessionError(Exception):
    def __init__(self, message: str, partial_result=None) -> None:
        super().__init__(message)
        self.partial_result = partial_result
        self.routing_restored = False


class DeviceIdentifySession:
    def __init__(
        self,
        device_modbus_link: DeviceModbusLink,
        codegen_json_root_directory: Path | None = None,
        log_callback: LogCallback | None = None,
        cancel_check: Callable[[], bool] | None = None,
        progress_callback: ProgressCallback | None = None,
    ) -> None:
        self._device_modbus_link = device_modbus_link
        self._codegen_json_root_directory = (
            Path(codegen_json_root_directory)
            if codegen_json_root_directory is not None
            else get_fixed_codegen_json_root_directory()
        )
        self._log_callback = log_callback
        self._cancel_check = cancel_check
        self._progress_callback = progress_callback
        self._next_permanent_slave_id = FIRST_PERMANENT_MODBUS_SLAVE_ID
        self._log_lines: list[str] = []
        self._catalog = CodeGenParameterListCatalog(self._codegen_json_root_directory)

    def run_identify(self) -> DeviceIdentifyResult:
        if not self._device_modbus_link.is_connected:
            raise DeviceIdentifySessionError("Not connected.")

        self._next_permanent_slave_id = FIRST_PERMANENT_MODBUS_SLAVE_ID
        self._log_lines = []
        self._progress(
            "identify_started",
            "Identify started.",
            {},
        )
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
            self._progress(
                "identify_failed",
                f"Identify failed while loading the JSON catalog: {exc}",
                {},
            )
            raise DeviceIdentifySessionError(str(exc)) from exc

        root: IdentifiedDeviceNode | None = None
        try:
            self._log(
                f"STEP broadcast WRITE unit={BROADCAST_MODBUS_UNIT_IDENTIFIER} "
                f"addr={HOLDING_ADDRESS_SLAVE_ID} value=1 (force all SlaveId→1)"
            )
            self._broadcast_write_u16(HOLDING_ADDRESS_SLAVE_ID, 1)
            self._log("Broadcast SlaveId=1 (no reply expected)")
            self._log(
                f"STEP broadcast WRITE unit={BROADCAST_MODBUS_UNIT_IDENTIFIER} "
                f"addr={HOLDING_ADDRESS_IDENTIFY_STATUS} value=1"
            )
            self._broadcast_write_u16(HOLDING_ADDRESS_IDENTIFY_STATUS, 1)
            self._log("Broadcast IdentifyStatus=1 (no reply expected)")
            self._wait_for_device_state_to_settle(
                self._settle_seconds_after_broadcast(),
                "broadcast Identify setup",
            )

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
            if root is not None:
                n = sum(1 for _ in root.iter_depth_first())
                self._log(f"Partial topology kept: {n} device(s) before failure.")
            self._log("========== IDENTIFY FAILED ==========")
            assigned = max(
                0,
                FIRST_PERMANENT_MODBUS_SLAVE_ID
                - self._next_permanent_slave_id,
            )
            partial = DeviceIdentifyResult(
                root_node=root,
                assigned_slave_id_count=assigned,
                log_lines=list(self._log_lines),
            )
            cancelled = "cancelled" in str(exc).lower()
            self._progress(
                "identify_cancelled" if cancelled else "identify_failed",
                "Identify cancelled by user." if cancelled else f"Identify failed: {exc}",
                {
                    "assigned_slave_id_count": assigned,
                    "has_partial_topology": root is not None,
                },
            )
            if isinstance(exc, DeviceIdentifySessionError):
                if getattr(exc, "partial_result", None) is None:
                    exc.partial_result = partial
                raise
            raise DeviceIdentifySessionError(str(exc), partial_result=partial) from exc

        assigned = FIRST_PERMANENT_MODBUS_SLAVE_ID - self._next_permanent_slave_id
        self._log(f"Total permanent SlaveIds assigned: {assigned}")
        self._progress(
            "identify_finished",
            f"Identify finished. {assigned} device(s) discovered.",
            {"assigned_slave_id_count": assigned},
        )
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
        self._log(f"Probe ({parent_info}) unit={unit}")
        try:
            device_id = self._read_u16(HOLDING_ADDRESS_DEVICE_ID, unit)
            parameter_list_version = self._read_u16(
                HOLDING_ADDRESS_PARAMETER_LIST_VERSION, unit
            )
            self._log(
                f"  Found DeviceId={device_id} Version={parameter_list_version}"
            )
        except DeviceModbusLinkError as exc:
            self._log(f"  → no answer / read failed: {exc}")
            return None

        package: CodeGenParameterListPackage | None = None
        parameter_list_error: str | None = None
        try:
            package = self._catalog.load_parameter_list_package(
                device_id, parameter_list_version
            )
            self._log(f"  JSON: {package.info.device_name!r}")
        except CodeGenParameterListCatalogError as exc:
            parameter_list_error = str(exc)
            self._log(
                f"  → JSON unavailable for DeviceId={device_id} "
                f"Version={parameter_list_version}: {exc}"
            )

        database_entry = self._catalog.find_device_database_entry_by_device_id(
            device_id
        )
        device_name = (
            package.info.device_name
            if package is not None
            else (
                database_entry.device_name
                if database_entry is not None
                else f"Unknown DeviceId={device_id}"
            )
        )

        permanent_slave_id = self._allocate_permanent_slave_id()
        self._log(f"  Set permanent SlaveId={permanent_slave_id}")
        try:
            self._write_u16(HOLDING_ADDRESS_SLAVE_ID, permanent_slave_id, unit)
            self._log(f"Assigned SlaveId={permanent_slave_id}")
            self._wait_for_device_state_to_settle(
                self._settle_seconds_after_slave_id_assign(),
                f"SlaveId={permanent_slave_id} assignment",
            )
        except DeviceModbusLinkError as exc:
            self._log(f"  → assign write FAIL: {exc}")
            raise DeviceIdentifySessionError(
                f"Failed to write permanent SlaveId={permanent_slave_id}: {exc}"
            ) from exc

        # Build node early so we can open hub routing before any unicast to permanent id.
        node = IdentifiedDeviceNode(
            device_id=device_id,
            parameter_list_version=parameter_list_version,
            device_name=device_name,
            permanent_modbus_slave_id=permanent_slave_id,
            downstream_port_quantity=0,
            parameter_list_package=package,
            parameter_list_error=parameter_list_error,
            parent_node=parent_node,
            port_index_on_parent=port_index_on_parent,
        )

        if parent_node is not None and port_index_on_parent is not None:
            parent_node.children_by_port_index[port_index_on_parent] = node
            self._log(
                f"  Update ancestor hub Min/Max for SlaveId={permanent_slave_id}"
            )
            self._expand_routing_ranges_for_slave_id_on_ancestors(
                child_node=node, permanent_slave_id=permanent_slave_id
            )

        self._log(f"  Read DownStreamQty unit={permanent_slave_id}")
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
        parameter_list_available = node.parameter_list_available
        event_message = (
            f"Device identified: {node.device_name} "
            f"(DeviceId={node.device_id}, SlaveId={node.permanent_modbus_slave_id})"
        )
        if not parameter_list_available:
            event_message += (
                f"; parameter-list version {node.parameter_list_version} "
                "is not available in this software."
            )
        self._progress(
            "device_discovered",
            event_message,
            {
                "device_name": node.device_name,
                "device_id": node.device_id,
                "parameter_list_version": node.parameter_list_version,
                "slave_id": node.permanent_modbus_slave_id,
                "downstream_qty": node.downstream_port_quantity,
                "parameter_list_available": parameter_list_available,
                "parameter_list_error": node.parameter_list_error,
                "parent_slave_id": (
                    parent_node.permanent_modbus_slave_id
                    if parent_node is not None
                    else None
                ),
                "port_index": port_index_on_parent,
            },
        )
        return node

    def _scan_downstream_ports_recursively(self, hub_node: IdentifiedDeviceNode) -> None:
        if hub_node.downstream_port_quantity <= 0:
            self._log(
                f"SlaveId={hub_node.permanent_modbus_slave_id} leaf "
                f"(DownStreamQty=0) — no ports to scan."
            )
            return

        package = hub_node.parameter_list_package
        if package is None:
            message = (
                f"Cannot scan {hub_node.downstream_port_quantity} downstream port(s) "
                f"of {hub_node.device_name}: parameter-list version "
                f"{hub_node.parameter_list_version} is unavailable."
            )
            self._log(message)
            self._progress(
                "parameter_list_missing",
                message,
                {
                    "device_name": hub_node.device_name,
                    "device_id": hub_node.device_id,
                    "parameter_list_version": hub_node.parameter_list_version,
                    "slave_id": hub_node.permanent_modbus_slave_id,
                },
            )
            return
        qty = hub_node.downstream_port_quantity
        self._log(
            f"=== Scan ports on hub SlaveId={hub_node.permanent_modbus_slave_id} "
            f"qty={qty} ==="
        )

        for port_index in range(qty):
            routing_snapshot = [
                (
                    hub_node.downstream_port_slave_id_min.get(index, 0),
                    hub_node.downstream_port_slave_id_max.get(index, 0),
                )
                for index in range(qty)
            ]
            try:
                self._progress(
                    "port_scanning",
                    (
                        f"Scanning port {port_index} on "
                        f"SlaveId={hub_node.permanent_modbus_slave_id}."
                    ),
                    {
                        "hub_slave_id": hub_node.permanent_modbus_slave_id,
                        "port_index": port_index,
                        "port_count": qty,
                    },
                )
                self._log(
                    f"Port[{port_index}] of hub {hub_node.permanent_modbus_slave_id}: "
                    f"configure discovery (Min=Max=1 on this port)"
                )
                self._configure_hub_ports_for_discovery_scan(
                    hub_node, package, port_index
                )
                self._wait_for_device_state_to_settle(
                    DISCOVERY_ROUTING_SETTLE_SECONDS,
                    (
                        f"routing on hub SlaveId="
                        f"{hub_node.permanent_modbus_slave_id} port[{port_index}]"
                    ),
                )

                child = self._probe_downstream_port_with_retry(
                    parent_node=hub_node, port_index_on_parent=port_index
                )
                if child is None:
                    self._progress(
                        "empty_port",
                        (
                            f"No device found on port {port_index} of "
                            f"SlaveId={hub_node.permanent_modbus_slave_id}."
                        ),
                        {
                            "hub_slave_id": hub_node.permanent_modbus_slave_id,
                            "port_index": port_index,
                        },
                    )
                    self._log(f"Port[{port_index}] empty — close Min=Max=0")
                    try:
                        self._write_port_min_max(hub_node, package, port_index, 0, 0)
                    except Exception as close_exc:
                        self._log(f"Port[{port_index}] close failed: {close_exc}")
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
                # After subtree is done, drop temp id 1 from this port range
                perm_min, perm_max = self._permanent_slave_id_range_for_port(
                    hub_node, port_index
                )
                self._write_port_min_max(
                    hub_node, package, port_index, perm_min, perm_max
                )
                hub_node.downstream_port_slave_id_min[port_index] = perm_min
                hub_node.downstream_port_slave_id_max[port_index] = perm_max
                self._log(
                    f"Port[{port_index}] sealed permanent range {perm_min}..{perm_max}"
                )
            except Exception as port_exc:
                self._log(
                    f"Port[{port_index}] ERROR — abort Identify: {port_exc}"
                )
                routing_already_restored = bool(
                    getattr(port_exc, "routing_restored", False)
                )
                if not routing_already_restored:
                    self._restore_hub_port_routing_after_failure(
                        hub_node,
                        package,
                        routing_snapshot,
                    )
                if isinstance(port_exc, DeviceIdentifySessionError):
                    port_exc.routing_restored = True
                    raise
                wrapped = DeviceIdentifySessionError(
                    f"Port[{port_index}] scan failed: {port_exc}"
                )
                wrapped.routing_restored = True
                raise wrapped from port_exc

    def _probe_downstream_port_with_retry(
        self,
        parent_node: IdentifiedDeviceNode,
        port_index_on_parent: int,
    ) -> IdentifiedDeviceNode | None:
        """Probe a newly-opened downstream route before declaring it empty."""
        for attempt in range(1, DISCOVERY_PORT_PROBE_ATTEMPTS + 1):
            child = self._discover_node_on_temporary_slave_one(
                parent_node=parent_node, port_index_on_parent=port_index
            )
            if child is not None:
                return child
            if attempt >= DISCOVERY_PORT_PROBE_ATTEMPTS:
                break
            self._log(
                f"  No response on port[{port_index}]; retry "
                f"{attempt + 1}/{DISCOVERY_PORT_PROBE_ATTEMPTS} after "
                f"{DISCOVERY_PORT_PROBE_RETRY_DELAY_SECONDS * 1000:.0f} ms"
            )
            self._wait_for_device_state_to_settle(
                DISCOVERY_PORT_PROBE_RETRY_DELAY_SECONDS,
                f"retry probe on port[{port_index}]",
            )
        return None

    def _restore_hub_port_routing_after_failure(
        self,
        hub_node: IdentifiedDeviceNode,
        package: CodeGenParameterListPackage,
        routing_snapshot: list[tuple[int, int]],
    ) -> None:
        """Best-effort rollback of the hub modified by an interrupted port scan."""
        self._log(
            f"Restore routing on hub SlaveId={hub_node.permanent_modbus_slave_id}"
        )
        for port_index, (slave_id_min, slave_id_max) in enumerate(
            routing_snapshot
        ):
            try:
                self._write_port_min_max(
                    hub_node,
                    package,
                    port_index,
                    slave_id_min,
                    slave_id_max,
                )
                hub_node.downstream_port_slave_id_min[port_index] = slave_id_min
                hub_node.downstream_port_slave_id_max[port_index] = slave_id_max
            except Exception as restore_exc:
                self._log(
                    f"  Port[{port_index}] routing restore failed: {restore_exc}"
                )

    def _permanent_slave_id_range_for_port(
        self, hub_node: IdentifiedDeviceNode, port_index: int
    ) -> tuple[int, int]:
        """
        Min/Max of permanent SlaveIds under this port only (never includes
        temporary discovery id 1). Used so the next discovery open port is
        the only path that accepts unit=1.
        """
        child = hub_node.children_by_port_index.get(port_index)
        if child is None:
            return 0, 0
        permanent_ids = [
            n.permanent_modbus_slave_id for n in child.iter_depth_first()
        ]
        if not permanent_ids:
            sid = child.permanent_modbus_slave_id
            return sid, sid
        return min(permanent_ids), max(permanent_ids)

    def _configure_hub_ports_for_discovery_scan(
        self,
        hub_node: IdentifiedDeviceNode,
        package: CodeGenParameterListPackage,
        discovery_port_index: int,
    ) -> None:
        """
        Only the discovery port may accept temporary SlaveId=1.
        Already-discovered ports keep permanent-only ranges (exclude 1),
        otherwise the hub forwards unit=1 to an old port and new ports look empty.
        """
        for port_index in range(hub_node.downstream_port_quantity):
            if port_index == discovery_port_index:
                self._log(
                    f"  hub {hub_node.permanent_modbus_slave_id} "
                    f"port[{port_index}] → 1..1 (discovery open)"
                )
                self._write_port_min_max(hub_node, package, port_index, 1, 1)
                hub_node.downstream_port_slave_id_min[port_index] = 1
                hub_node.downstream_port_slave_id_max[port_index] = 1
            elif port_index in hub_node.children_by_port_index:
                min_id, max_id = self._permanent_slave_id_range_for_port(
                    hub_node, port_index
                )
                self._log(
                    f"  hub {hub_node.permanent_modbus_slave_id} "
                    f"port[{port_index}] permanent-only {min_id}..{max_id} "
                    f"(exclude temp id 1)"
                )
                self._write_port_min_max(hub_node, package, port_index, min_id, max_id)
                hub_node.downstream_port_slave_id_min[port_index] = min_id
                hub_node.downstream_port_slave_id_max[port_index] = max_id
            else:
                self._log(
                    f"  hub {hub_node.permanent_modbus_slave_id} "
                    f"port[{port_index}] → 0..0 (closed)"
                )
                self._write_port_min_max(hub_node, package, port_index, 0, 0)
                hub_node.downstream_port_slave_id_min[port_index] = 0
                hub_node.downstream_port_slave_id_max[port_index] = 0

        self._ensure_ancestors_forward_temporary_slave_one(hub_node)

    def _ensure_ancestors_forward_temporary_slave_one(
        self, hub_node: IdentifiedDeviceNode
    ) -> None:
        node = hub_node
        while node.parent_node is not None and node.port_index_on_parent is not None:
            parent = node.parent_node
            port_index = node.port_index_on_parent
            package = parent.parameter_list_package
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
            package = parent.parameter_list_package
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
                f"  Hub {parent.permanent_modbus_slave_id} port[{port_index}] "
                f"→ {new_min}..{new_max}"
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

    def _wait_for_device_state_to_settle(self, seconds: float, reason: str) -> None:
        """Allow broadcast/routing writes to take effect before the next read."""
        delay = max(0.0, float(seconds))
        if delay <= 0.0:
            return
        self._log(f"Wait {delay * 1000:.0f} ms for {reason} to settle")
        time.sleep(delay)

    def _log(self, message: str) -> None:
        if self._cancel_check is not None and self._cancel_check():
            # Consume cancellation once. Failure handling logs additional
            # messages and must be allowed to clear IdentifyStatus and keep
            # the partial topology instead of raising cancellation again.
            self._cancel_check = None
            raise DeviceIdentifySessionError("Identify cancelled by user")
        self._log_lines.append(message)
        if self._log_callback is not None:
            self._log_callback(message)

    def _progress(
        self,
        event_type: str,
        message: str,
        data: dict[str, Any],
    ) -> None:
        if self._progress_callback is None:
            return
        try:
            self._progress_callback(event_type, message, data)
        except Exception:
            # Telemetry must never change the Identify algorithm's outcome.
            pass


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
