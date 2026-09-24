"""Commands: help, version, set-json-root, ping."""

from __future__ import annotations

from pathlib import Path

from commands.context import CommandSessionContext
from commands.parser import build_argument_parser
from commands.registry import CommandRegistry, build_default_registry
from commands.result import CommandResult, failure, success
from generated_version import VERSION_TEXT

TOOL_VERSION = VERSION_TEXT


def register(registry: CommandRegistry) -> None:
    registry.register("help", handle_help)
    registry.register("version", handle_version)
    registry.register("set-json-root", handle_set_json_root)
    registry.register("ping", handle_ping)


def handle_help(context: CommandSessionContext, args) -> CommandResult:
    topic = getattr(args, "topic", None)
    parser = build_argument_parser()
    if topic:
        # find subparser help text
        for action in parser._subparsers._group_actions:  # noqa: SLF001
            choices = getattr(action, "choices", None)
            if choices and topic in choices:
                return success(
                    "help",
                    {"topic": topic, "text": choices[topic].format_help()},
                )
        return failure("help", f"Unknown topic: {topic}")
    names = build_default_registry().list_command_names()
    return success("help", {"commands": names})


def handle_version(context: CommandSessionContext, args) -> CommandResult:
    return success("version", {"version": TOOL_VERSION})


def handle_set_json_root(context: CommandSessionContext, args) -> CommandResult:
    path = Path(args.path)
    if not path.is_dir():
        return failure("set-json-root", f"Not a directory: {path}")
    context.codegen_json_root_directory = path.resolve()
    return success(
        "set-json-root", {"path": str(context.codegen_json_root_directory)}
    )


def handle_ping(context: CommandSessionContext, args) -> CommandResult:
    return success("ping", {"message": "pong"})
