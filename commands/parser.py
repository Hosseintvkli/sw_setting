"""
Parse a single command line into (command_name, argparse.Namespace).

Uses one top-level argparse parser with subcommands.
"""

from __future__ import annotations

import argparse
import shlex
from dataclasses import dataclass


@dataclass
class ParsedCommandLine:
    command_name: str
    arguments: argparse.Namespace


def build_argument_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(
        prog="sw_setting",
        description="Device setting tool command processor",
    )
    sub = parser.add_subparsers(dest="command_name", required=True)

    # --- connection ---
    # Defaults: TCP lab setup. --port selects serial instead of --device-ip.
    p = sub.add_parser("connect", help="Open Modbus link (serial or TCP)")
    g = p.add_mutually_exclusive_group(required=False)
    g.add_argument("--port", default=None, help="Serial COM port, e.g. COM3")
    g.add_argument(
        "--device-ip",
        default="192.168.1.110",
        help="Modbus TCP device IP (default: 192.168.1.110)",
    )
    p.add_argument("--baud", type=int, default=115200)
    p.add_argument("--tcp-port", type=int, default=502)
    p.add_argument("--local-interface", default="", help="Local NIC name (optional)")
    p.add_argument(
        "--local-ip",
        default="192.168.1.120",
        help="Local NIC IPv4 (default: 192.168.1.120)",
    )
    p.add_argument("--read-timeout-ms", type=int, default=100)
    p.add_argument("--write-timeout-ms", type=int, default=100)
    p.add_argument("--connect-timeout-ms", type=int, default=100)
    p.add_argument("--command-timeout-ms", type=int, default=10_000)
    p.add_argument("--retries", type=int, default=3)

    sub.add_parser("disconnect", help="Close Modbus link")
    sub.add_parser("status", help="Show session status")
    sub.add_parser("list-serial-ports", help="List COM ports")
    sub.add_parser("list-networks", help="List local IPv4 interfaces")

    p = sub.add_parser("set-timeouts", help="Update timeouts/retries on session")
    p.add_argument("--read-timeout-ms", type=int, required=True)
    p.add_argument("--write-timeout-ms", type=int, required=True)
    p.add_argument("--connect-timeout-ms", type=int, default=None)
    p.add_argument("--command-timeout-ms", type=int, default=None)
    p.add_argument("--retries", type=int, default=None)

    # --- topology ---
    p = sub.add_parser("identify", help="Run Identify and store topology")
    p.add_argument("--json-root", default=None, help="Override JSON catalog root")

    p = sub.add_parser("show-topology", help="Print last Identify tree")
    p.add_argument("--format", choices=("json", "tree"), default="json")

    p = sub.add_parser("select-device", help="Select active SlaveId")
    p.add_argument("--slave-id", type=int, default=None)
    p.add_argument("--device-id", type=int, default=None)

    sub.add_parser("clear-device-selection", help="Clear selected SlaveId")

    # --- settings ---
    p = sub.add_parser("load-settings", help="Load SETTING parameters from device")
    p.add_argument("--slave-id", type=int, default=None)
    p.add_argument(
        "--dump-values",
        action="store_true",
        help="Include all Name/Value pairs in JSON data",
    )

    p = sub.add_parser("reload-settings", help="Reload settings for current device")
    p.add_argument("--dump-values", action="store_true")

    p = sub.add_parser("get-parameter", help="Read one SETTING by name")
    p.add_argument("--name", required=True)
    p.add_argument("--slave-id", type=int, default=None)

    p = sub.add_parser("set-parameter", help="Write one SETTING by name")
    p.add_argument("--name", required=True)
    p.add_argument("--value", required=True)
    p.add_argument("--slave-id", type=int, default=None)

    p = sub.add_parser("list-parameters", help="List parameters from loaded package")
    p.add_argument(
        "--type",
        dest="parameter_type_filter",
        choices=("setting", "monitoring", "command", "all"),
        default="setting",
    )
    p.add_argument("--tag2", default=None)

    p = sub.add_parser(
        "read-monitoring",
        help="Read selected MONITORING parameters in efficient batches",
    )
    p.add_argument(
        "--parameter-id",
        dest="parameter_ids",
        action="append",
        type=int,
        required=True,
        help="ParameterId to read; repeat this option for multiple parameters",
    )
    p.add_argument("--slave-id", type=int, default=None)

    p = sub.add_parser("get-monitoring-header", help="Read fixed monitoring header")
    p.add_argument("--slave-id", type=int, default=None)

    # --- profile ---
    p = sub.add_parser("apply-profile", help="Apply CSV profile to device(s)")
    p.add_argument("--file", required=True)
    p.add_argument("--all-same-device-id", action="store_true")
    p.add_argument("--verbose", action="store_true")

    p = sub.add_parser("verify-profile", help="Verify CSV against device(s)")
    p.add_argument("--file", required=True)
    p.add_argument("--all-same-device-id", action="store_true")
    p.add_argument("--verbose", action="store_true")

    p = sub.add_parser("save-profile", help="Reload then save SETTING values to CSV")
    p.add_argument("--file", required=True)

    p = sub.add_parser("parse-profile", help="Parse/validate CSV only")
    p.add_argument("--file", required=True)

    # --- device commands ---
    sub.add_parser("list-commands", help="List COMMAND parameters")

    p = sub.add_parser("execute-command", help="Execute COMMAND (0xFFFF protocol)")
    p.add_argument("--name", default=None)
    p.add_argument("--address", type=int, default=None)
    p.add_argument("--slave-id", type=int, default=None)

    # --- raw modbus ---
    p = sub.add_parser("read-holding", help="Raw read holding registers")
    p.add_argument("--address", type=int, required=True)
    p.add_argument("--count", type=int, default=1)
    p.add_argument("--slave-id", type=int, default=None)

    p = sub.add_parser("write-holding", help="Raw write holding register(s)")
    p.add_argument("--address", type=int, required=True)
    p.add_argument("--value", type=int, default=None)
    p.add_argument(
        "--values",
        default=None,
        help="Comma-separated U16 values, e.g. 1,2,3",
    )
    p.add_argument("--slave-id", type=int, default=None)

    p = sub.add_parser("write-holding-broadcast", help="Broadcast write (unit 0)")
    p.add_argument("--address", type=int, required=True)
    p.add_argument("--value", type=int, required=True)

    # --- utility ---
    p = sub.add_parser("help", help="List commands or help for one command")
    p.add_argument("topic", nargs="?", default=None)

    sub.add_parser("version", help="Tool version")

    p = sub.add_parser("set-json-root", help="Override JSON catalog root for session")
    p.add_argument("--path", required=True)

    sub.add_parser("ping", help="Processor health check")

    return parser


def parse_command_tokens(tokens: list[str]) -> ParsedCommandLine:
    """
    Parse an already-split argv-style token list.

    Prefer this for single-shot CLI so multi-word values (e.g. "Ethernet 5")
    stay as one argument — unlike join + shlex which can break them.
    """
    if not tokens:
        raise ValueError("Empty command line")
    parser = build_argument_parser()
    try:
        namespace = parser.parse_args(list(tokens))
    except SystemExit as exc:
        raise ValueError(
            f"Invalid command or arguments: {' '.join(tokens)}"
        ) from exc
    command_name = getattr(namespace, "command_name", None)
    if not command_name:
        raise ValueError("No command name parsed")
    return ParsedCommandLine(command_name=command_name, arguments=namespace)


def parse_command_line(line: str) -> ParsedCommandLine:
    """Parse a single typed line (interactive CLI / GUI console)."""
    line = line.strip()
    if not line:
        raise ValueError("Empty command line")
    tokens = shlex.split(line, posix=False)
    return parse_command_tokens(tokens)
