"""Standard command result written as JSON on stdout."""

from __future__ import annotations

import json
from dataclasses import asdict, dataclass, field
from typing import Any


@dataclass
class CommandResult:
    ok: bool
    command: str
    data: dict[str, Any] = field(default_factory=dict)
    error: str | None = None
    exit_code: int = 0

    def to_json_dict(self) -> dict[str, Any]:
        payload: dict[str, Any] = {
            "ok": self.ok,
            "command": self.command,
            "data": self.data,
        }
        if self.error is not None:
            payload["error"] = self.error
        return payload

    def to_json_text(self) -> str:
        return json.dumps(self.to_json_dict(), ensure_ascii=False, indent=2)


def success(command: str, data: dict[str, Any] | None = None) -> CommandResult:
    return CommandResult(ok=True, command=command, data=data or {}, exit_code=0)


def failure(command: str, error: str, exit_code: int = 1) -> CommandResult:
    return CommandResult(
        ok=False, command=command, data={}, error=error, exit_code=exit_code
    )
