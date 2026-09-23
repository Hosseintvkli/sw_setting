from __future__ import annotations

import unittest
from pathlib import Path

from commands.handlers.topology_commands import node_to_dict
from core.device_identify_session import DeviceIdentifySession


class _FakeModbusLink:
    def __init__(self) -> None:
        self.writes: list[tuple[int, int, int | None]] = []

    def read_holding_register_u16(
        self, address: int, modbus_unit_identifier: int | None = None
    ) -> int:
        return {0: 1004, 1: 16, 14: 0}[address]

    def write_holding_register_u16(
        self,
        address: int,
        value: int,
        modbus_unit_identifier: int | None = None,
    ) -> None:
        self.writes.append((address, value, modbus_unit_identifier))

    def get_active_write_timeout_seconds(self) -> float:
        return 0.0


class MissingParameterListIdentifyTests(unittest.TestCase):
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
        self.assertEqual(node.parameter_list_version, 16)
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
