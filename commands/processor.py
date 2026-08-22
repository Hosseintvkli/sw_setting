"""Execute one command line against session context."""

from __future__ import annotations

from commands.context import CommandSessionContext
from commands.parser import parse_command_line, parse_command_tokens
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

    def execute_tokens(self, tokens: list[str]) -> CommandResult:
        """Run a command from argv-style tokens (preserves multi-word values)."""
        try:
            parsed = parse_command_tokens(tokens)
        except ValueError as exc:
            return failure("?", str(exc))
        return self._dispatch(parsed.command_name, parsed.arguments)

    def execute_line(self, command_line: str) -> CommandResult:
        """Run a command from one typed line (interactive / console)."""
        try:
            parsed = parse_command_line(command_line)
        except ValueError as exc:
            return failure("?", str(exc))
        return self._dispatch(parsed.command_name, parsed.arguments)

    def _dispatch(self, command_name: str, arguments) -> CommandResult:
        handler = self.registry.get(command_name)
        if handler is None:
            return failure(
                command_name,
                f"Unknown command: {command_name}",
            )
        try:
            return handler(self.session_context, arguments)
        except Exception as exc:
            return failure(command_name, str(exc))
