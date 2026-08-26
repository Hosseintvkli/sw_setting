"""
Build HTTP command payloads and argv tokens from structured args.

Structured form (preferred for clients):
  {
    "command": "connect",
    "args": {
      "device-ip": "192.168.1.110",
      "tcp-port": 502
    }
  }

Line form (helper input):
  { "command": "connect --device-ip 192.168.1.110 --tcp-port 502" }
"""

from __future__ import annotations

import shlex
from typing import Any


def args_dict_to_tokens(command_name: str, args: dict[str, Any] | None) -> list[str]:
    """
    Convert structured command + args into argv tokens for the processor.

    Rules:
      - keys become flags: "device-ip" -> "--device-ip", "device_ip" -> "--device-ip"
      - True  -> flag only (store_true style)
      - False / None -> omit
      - other values -> flag + str(value)
    """
    tokens: list[str] = [command_name]
    if not args:
        return tokens
    for key, value in args.items():
        flag = key.strip()
        if not flag.startswith("-"):
            flag = "--" + flag.replace("_", "-")
        if value is True:
            tokens.append(flag)
        elif value is False or value is None:
            continue
        else:
            tokens.append(flag)
            tokens.append(str(value))
    return tokens


def command_line_string_to_structured(command_line: str) -> dict[str, Any]:
    """
    Parse a shell-like line into { "command": name, "args": { ... } }.

    Example:
      "connect --device-ip 192.168.1.110 --tcp-port 502"
      ->
      {
        "command": "connect",
        "args": {"device-ip": "192.168.1.110", "tcp-port": "502"}
      }
    """
    line = command_line.strip()
    if not line:
        raise ValueError("Empty command line")
    tokens = shlex.split(line, posix=False)
    name = tokens[0]
    args: dict[str, Any] = {}
    i = 1
    while i < len(tokens):
        tok = tokens[i]
        if tok.startswith("--"):
            key = tok[2:]
            if i + 1 < len(tokens) and not tokens[i + 1].startswith("-"):
                args[key] = tokens[i + 1]
                i += 2
            else:
                args[key] = True
                i += 1
        elif tok.startswith("-") and len(tok) == 2:
            key = tok[1:]
            if i + 1 < len(tokens) and not tokens[i + 1].startswith("-"):
                args[key] = tokens[i + 1]
                i += 2
            else:
                args[key] = True
                i += 1
        else:
            raise ValueError(f"Unexpected positional argument: {tok}")
    return {"command": name, "args": args}


def structured_request_to_tokens(body: dict[str, Any]) -> list[str]:
    """
    Accept either structured {command, args} or a single-line {command: "..."}.
    """
    if "tokens" in body and body["tokens"]:
        return list(body["tokens"])

    raw = body.get("command")
    if raw is None:
        raise ValueError("Missing 'command' field")

    args = body.get("args")
    if isinstance(raw, str) and (args is None) and (" " in raw or raw.startswith("-")):
        # full line in command field
        structured = command_line_string_to_structured(raw)
        return args_dict_to_tokens(structured["command"], structured.get("args"))

    if not isinstance(raw, str) or not raw.strip():
        raise ValueError("'command' must be a non-empty string")

    command_name = raw.strip()
    # if command_name still has spaces and no args, treat as line
    if " " in command_name and not args:
        structured = command_line_string_to_structured(command_name)
        return args_dict_to_tokens(structured["command"], structured.get("args"))

    return args_dict_to_tokens(
        command_name,
        args if isinstance(args, dict) else None,
    )
