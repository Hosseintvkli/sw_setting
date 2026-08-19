"""Execute one command line against session context."""

from __future__ import annotations

from commands.context import CommandSessionContext
from commands.parser import parse_command_line
from commands.registry import CommandRegistry, build_default_registry
from commands.result import CommandResult, failure


class CommandProcessor:
    def __init__(
        self,
        session_context: CommandSessionContext | None = None,
        registry: CommandRegistry | None = None,
    ) -> None:
        self.session_context = session_context or CommandSessionContext()
        self.registry = registry or build_default_registry()

    def execute_line(self, command_line: str) -> CommandResult:
        try:
            parsed = parse_command_line(command_line)
        except ValueError as exc:
            return failure("?", str(exc))

        handler = self.registry.get(parsed.command_name)
        if handler is None:
            return failure(
                parsed.command_name,
                f"Unknown command: {parsed.command_name}",
            )
        try:
            return handler(self.session_context, parsed.arguments)
        except Exception as exc:
            return failure(parsed.command_name, str(exc))
