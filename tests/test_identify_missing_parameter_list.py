from __future__ import annotations

import unittest
from pathlib import Path
from types import SimpleNamespace
from unittest.mock import patch

from commands.handlers.topology_commands import node_to_dict
from core.device_identify_session import DeviceIdentifySession, DeviceIdentifySessionError
from core.device_modbus_link import DeviceModbusLinkError
from core.device_topology_models import IdentifiedDeviceNode


class _FakeModbusLink:
    def __init__(self) -> None:
        self.writes: list[tuple[int, int, int | None]] = []

    def read_holding_register_u16(
        self, address: int, modbus_unit_identifier: int | None = None,
        total_attempt_count_override: int | None = None,
    ) -> int:
        return {0: 1004, 1: 65534, 14: 0}[address]

    def write_holding_register_u16(
        self,
        address: int,
        value: int,
        modbus_unit_identifier: int | None = None,
    ) -> None:
        self.writes.append((address, value, modbus_unit_identifier))

    def read_holding_registers_u16(
        self, modbus_start_address: int, register_count: int,
        modbus_unit_identifier: int | None = None,
    ) -> list[int]:
        if modbus_start_address == 7 and register_count == 2:
            return [123, 0]
        raise AssertionError("Unexpected register read")

    def get_active_write_timeout_seconds(self) -> float:
        return 0.0

    def get_active_read_timeout_seconds(self) -> float:
        return 0.2


class MissingParameterListIdentifyTests(unittest.TestCase):
    def test_routing_write_timeout_is_accepted_when_readback_matches(self):
        session = DeviceIdentifySession(_FakeModbusLink())
        package = SimpleNamespace(
            parameters=[
                SimpleNamespace(
                    parameter_name=f"DownStreamsSetting[0].SlaveId{field}",
                    modbus_address=address,
                )
                for field, address in (("Min", 100), ("Max", 101))
            ]
        )
        hub = IdentifiedDeviceNode(
            device_id=3,
            parameter_list_version=15,
            device_name="hub",
            permanent_modbus_slave_id=246,
            downstream_port_quantity=1,
            parameter_list_package=package,
        )
        with (
            patch.object(
                session,
                "_write_u16",
                side_effect=[DeviceModbusLinkError("No response"), None],
            ) as write,
            patch.object(session, "_read_u16", return_value=1) as read,
        ):
            session._write_port_min_max(hub, package, 0, 1, 1)

        self.assertEqual(write.call_count, 2)
        read.assert_called_once_with(100, 246)

    def test_failed_empty_port_close_aborts_instead_of_claiming_it_closed(self):
        session = DeviceIdentifySession(_FakeModbusLink())
        hub = IdentifiedDeviceNode(
            device_id=3,
            parameter_list_version=15,
            device_name="hub",
            permanent_modbus_slave_id=246,
            downstream_port_quantity=1,
            parameter_list_package=object(),
        )
        with (
            patch.object(session, "_configure_hub_ports_for_discovery_scan"),
            patch.object(session, "_wait_for_device_state_to_settle"),
            patch.object(session, "_discover_node_on_temporary_slave_one", return_value=None),
            patch.object(
                session,
                "_write_port_min_max",
                side_effect=DeviceModbusLinkError("No response"),
            ),
        ):
            with self.assertRaises(DeviceIdentifySessionError):
                session._scan_downstream_ports_recursively(hub)

        self.assertNotIn(0, hub.downstream_port_slave_id_min)

    def test_empty_downstream_port_is_probed_three_times(self):
        session = DeviceIdentifySession(_FakeModbusLink())
        hub = IdentifiedDeviceNode(
            device_id=3,
            parameter_list_version=15,
            device_name="datalogger_v3_Salve",
            permanent_modbus_slave_id=246,
            downstream_port_quantity=1,
            parameter_list_package=object(),
        )
        with (
            patch.object(session, "_configure_hub_ports_for_discovery_scan"),
            patch.object(session, "_wait_for_device_state_to_settle") as wait,
            patch.object(session, "_write_port_min_max"),
            patch.object(
                session, "_discover_node_on_temporary_slave_one", return_value=None
            ) as probe,
        ):
            session._scan_downstream_ports_recursively(hub)

        self.assertEqual(probe.call_count, 3)
        self.assertEqual(wait.call_count, 3)
        self.assertEqual([call.args[0] for call in wait.call_args_list], [0.2] * 3)
        self.assertEqual(hub.downstream_port_slave_id_min[0], 0)
        self.assertEqual(hub.downstream_port_slave_id_max[0], 0)

    def test_device_is_kept_when_exact_parameter_list_version_is_missing(self):
        events: list[tuple[str, str, dict]] = []
        link = _FakeModbusLink()
        json_root = (
            Path(__file__).resolve().parent.parent
            / "files"
            / "codegen_output"
            / "JSON"
        )
        session = DeviceIdentifySession(
            link,
            codegen_json_root_directory=json_root,
            progress_callback=lambda kind, message, data: events.append(
                (kind, message, data)
            ),
        )
        session._catalog.scan_catalog_from_disk()

        node = session._discover_node_on_temporary_slave_one(None, None)

        self.assertIsNotNone(node)
        assert node is not None
        self.assertEqual(node.device_name, "matchbox")
        self.assertEqual(node.parameter_list_version, 65534)
        self.assertFalse(node.parameter_list_available)
        self.assertEqual(node.permanent_modbus_slave_id, 247)
        self.assertIn((4000, 247, 1), link.writes)
        payload = node_to_dict(node)
        self.assertFalse(payload["parameter_list_available"])
        self.assertTrue(payload["parameter_list_error"])
        self.assertEqual(events[-1][0], "device_discovered")
        self.assertFalse(events[-1][2]["parameter_list_available"])


if __name__ == "__main__":
    unittest.main()
