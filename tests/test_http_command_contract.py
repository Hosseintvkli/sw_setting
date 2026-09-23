from __future__ import annotations

import unittest
from pathlib import Path
from unittest.mock import patch

from pydantic import ValidationError

from commands.http_session_server import CommandBody
from commands.session_client import call_http_session_tokens


class HttpCommandContractTests(unittest.TestCase):
    def test_command_body_accepts_only_non_empty_complete_tokens(self):
        body = CommandBody(tokens=["connect", "--tcp-port", "502"])
        self.assertEqual(body.tokens[0], "connect")

        with self.assertRaises(ValidationError):
            CommandBody(tokens=[])
        with self.assertRaises(ValidationError):
            CommandBody(command="connect", args={})
        with self.assertRaises(ValidationError):
            CommandBody(tokens=["connect"], command="connect")

    def test_session_client_sends_tokens_without_duplicate_command_field(self):
        tokens = ["write-holding", "--address", "10", "--value", "7"]
        state = {"base_url": "http://127.0.0.1:8000", "session_id": "abc"}
        with (
            patch("commands.session_client.read_http_session_state", return_value=state),
            patch(
                "commands.session_client._http_json_request",
                return_value={"ok": True},
            ) as request,
        ):
            result = call_http_session_tokens(Path.cwd(), tokens)

        self.assertEqual(result, {"ok": True})
        self.assertEqual(request.call_args.args[2], {"tokens": tokens})


if __name__ == "__main__":
    unittest.main()
