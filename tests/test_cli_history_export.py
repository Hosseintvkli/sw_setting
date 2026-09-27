from __future__ import annotations

import unittest

from ui.cli_console_panel import command_history_to_script, script_command_lines


class CliHistoryExportTests(unittest.TestCase):
    def test_export_preserves_order_and_comments_long_running_helpers(self):
        commands = [
            "python cli.py serve-http --port 8000",
            "python cli.py --session gui serve",
            "python cli.py --session gui watch-events --command identify --json-lines",
            "python cli.py --session gui identify",
        ]
        exported = command_history_to_script(commands)
        self.assertIn("# Long-running helper (not replayed): python cli.py serve-http", exported)
        self.assertEqual(
            script_command_lines(exported),
            [commands[1], commands[3]],
        )


if __name__ == "__main__":
    unittest.main()
