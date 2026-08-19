"""Map command name -> handler callable."""

from __future__ import annotations

from typing import Any, Callable

from commands.context import CommandSessionContext
from commands.result import CommandResult

# handler(context, argparse.Namespace) -> CommandResult
CommandHandler = Callable[[CommandSessionContext, Any], CommandResult]


class CommandRegistry:
    def __init__(self) -> None:
        self._handlers: dict[str, CommandHandler] = {}

    def register(self, command_name: str, handler: CommandHandler) -> None:
        key = command_name.strip().lower()
        self._handlers[key] = handler

    def get(self, command_name: str) -> CommandHandler | None:
        return self._handlers.get(command_name.strip().lower())

    def list_command_names(self) -> list[str]:
        return sorted(self._handlers.keys())


def build_default_registry() -> CommandRegistry:
    from commands.handlers import (
        connection_commands,
        device_command_commands,
        modbus_raw_commands,
        profile_commands,
        settings_commands,
        topology_commands,
        utility_commands,
    )

    registry = CommandRegistry()

    connection_commands.register(registry)
    topology_commands.register(registry)
    settings_commands.register(registry)
    profile_commands.register(registry)
    device_command_commands.register(registry)
    modbus_raw_commands.register(registry)
    utility_commands.register(registry)

    return registry
