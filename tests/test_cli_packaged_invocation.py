from __future__ import annotations

import sys
import unittest
from pathlib import Path
from unittest.mock import patch

from ui.cli_console_panel import (
    build_copyable_cli_command,
    parse_cli_invocation,
)


class CliPackagedInvocationTests(unittest.TestCase):
    def test_source_mode_uses_python_and_cli_script(self):
        command = build_copyable_cli_command(["--session", "gui", "status"])
        parsed = parse_cli_invocation(command)

        self.assertEqual(command, "python cli.py --session gui status")
        self.assertEqual(parsed.program, sys.executable)
        self.assertEqual(
            parsed.arguments, ["cli.py", "--session", "gui", "status"]
        )

    def test_packaged_mode_uses_sibling_cli_executable(self):
        gui_executable = Path("C:/release/sw_setting_gui.exe")
        expected_cli = gui_executable.with_name("sw_setting_cli.exe")
        with (
            patch.object(sys, "frozen", True, create=True),
            patch.object(sys, "executable", str(gui_executable)),
        ):
            command = build_copyable_cli_command(
                ["--session", "gui", "status"]
            )
            parsed = parse_cli_invocation(command)

        self.assertEqual(command, "sw_setting_cli.exe --session gui status")
        self.assertEqual(Path(parsed.program), expected_cli)
        self.assertEqual(parsed.arguments, ["--session", "gui", "status"])

    def test_packaged_mode_can_load_an_old_python_style_script(self):
        gui_executable = Path("C:/release/sw_setting_gui.exe")
        expected_cli = gui_executable.with_name("sw_setting_cli.exe")
        with (
            patch.object(sys, "frozen", True, create=True),
            patch.object(sys, "executable", str(gui_executable)),
        ):
            parsed = parse_cli_invocation(
                "python cli.py --session gui identify"
            )

        self.assertEqual(Path(parsed.program), expected_cli)
        self.assertEqual(parsed.arguments, ["--session", "gui", "identify"])


if __name__ == "__main__":
    unittest.main()
