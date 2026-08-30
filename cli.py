"""Command-line entry point for sw_setting.

``serve-http`` starts the multi-session HTTP API. ``serve`` creates one
session on that API and stores its id locally. Later CLI invocations reuse
that server-side context until ``serve-stop`` closes it. Without an active
stored session, an ordinary command keeps the local one-shot behavior.
"""

from __future__ import annotations

import json
import sys
from pathlib import Path

_ROOT = Path(__file__).resolve().parent
if str(_ROOT) not in sys.path:
    sys.path.insert(0, str(_ROOT))


def _extract_session_name(argv: list[str]) -> tuple[list[str], str | None]:
    """Remove the CLI-only --session option before command parsing."""
    cleaned: list[str] = []
    session_name: str | None = None
    i = 0
    while i < len(argv):
        token = argv[i]
        if token == "--session":
            if session_name is not None:
                raise ValueError("--session may be specified only once.")
            if i + 1 >= len(argv):
                raise ValueError("--session requires a name.")
            session_name = argv[i + 1]
            i += 2
            continue
        if token.startswith("--session="):
            if session_name is not None:
                raise ValueError("--session may be specified only once.")
            session_name = token.split("=", 1)[1]
            if not session_name:
                raise ValueError("--session requires a name.")
            i += 1
            continue
        cleaned.append(token)
        i += 1
    return cleaned, session_name


def main(argv: list[str] | None = None) -> int:
    argv = list(sys.argv[1:] if argv is None else argv)
    try:
        argv, session_name = _extract_session_name(argv)
        from commands.session_client import (
            HttpSessionClientError,
            validate_http_session_name,
        )

        validate_http_session_name(session_name)
    except (ValueError, HttpSessionClientError) as exc:
        print(f"Invalid CLI arguments: {exc}", file=sys.stderr)
        return 2

    if argv and argv[0] == "serve-http" and session_name is not None:
        print("--session does not apply to serve-http.", file=sys.stderr)
        return 2

    if argv and argv[0] == "serve-http":
        host = "0.0.0.0"
        port = 8000
        i = 1
        while i < len(argv):
            if argv[i] == "--host" and i + 1 < len(argv):
                host = argv[i + 1]
                i += 2
            elif argv[i] == "--port" and i + 1 < len(argv):
                port = int(argv[i + 1])
                i += 2
            else:
                print(f"Unknown serve-http argument: {argv[i]}", file=sys.stderr)
                return 2
        from commands.http_session_server import run_http_server

        print(
            f"sw_setting HTTP API on http://{host}:{port}\n"
            f"  docs: http://127.0.0.1:{port}/docs\n"
            f"  create session: POST /sessions\n"
            f"  run command:    POST /sessions/{{id}}/command\n"
            f"  cancel:         POST /sessions/{{id}}/cancel",
            file=sys.stderr,
        )
        run_http_server(host=host, port=port)
        return 0

    # Create a persistent session on the already-running HTTP API. The
    # session id is stored locally so later CLI processes reuse its context.
    if argv and argv[0] == "serve":
        host = "127.0.0.1"
        port = 8000
        i = 1
        while i < len(argv):
            if argv[i] == "--host" and i + 1 < len(argv):
                host = argv[i + 1]
                i += 2
            elif argv[i] == "--port" and i + 1 < len(argv):
                port = int(argv[i + 1])
                i += 2
            else:
                print(f"Unknown serve argument: {argv[i]}", file=sys.stderr)
                return 2

        from commands.session_client import HttpSessionClientError, open_http_session

        base_url = f"http://{host}:{port}"
        try:
            state = open_http_session(_ROOT, base_url, session_name=session_name)
        except HttpSessionClientError as exc:
            print(
                json.dumps(
                    {"ok": False, "command": "serve", "error": str(exc)},
                    ensure_ascii=False,
                    indent=2,
                )
            )
            return 1
        print(
            json.dumps(
                {
                    "ok": True,
                    "command": "serve",
                    "data": {
                        "base_url": state["base_url"],
                        "session_id": state["session_id"],
                        "session_name": session_name or "default",
                        "message": "Persistent HTTP session created.",
                    },
                },
                ensure_ascii=False,
                indent=2,
            )
        )
        return 0

    if argv and argv[0] == "serve-stop":
        from commands.session_client import (
            HttpSessionClientError,
            close_http_session,
            print_result_dict,
        )

        try:
            response = close_http_session(_ROOT, session_name=session_name)
            return print_result_dict(
                {
                    "ok": bool(response.get("ok", True)),
                    "command": "serve-stop",
                    "data": response,
                }
            )
        except HttpSessionClientError as exc:
            print(
                json.dumps(
                    {"ok": False, "command": "serve-stop", "error": str(exc)},
                    ensure_ascii=False,
                    indent=2,
                )
            )
            return 1

    if not argv:
        print(
            "Usage:\n"
            "  python cli.py serve-http [--host 0.0.0.0] [--port 8000]\n"
            "  python cli.py [--session NAME] serve [--host 127.0.0.1] [--port 8000]\n"
            "  python cli.py [--session NAME] <command> [args...]\n"
            "  python cli.py [--session NAME] serve-stop\n",
            file=sys.stderr,
        )
        return 2

    # When ``serve`` has stored a session pointer, ordinary commands execute
    # in that server-side context. Without it, retain local one-shot behavior.
    from commands.session_client import (
        HttpSessionClientError,
        call_http_session_tokens,
        print_result_dict,
        read_http_session_state,
    )

    if read_http_session_state(_ROOT, session_name=session_name) is not None:
        try:
            return print_result_dict(
                call_http_session_tokens(
                    _ROOT,
                    argv,
                    session_name=session_name,
                )
            )
        except HttpSessionClientError as exc:
            print(
                json.dumps(
                    {"ok": False, "command": argv[0], "error": str(exc)},
                    ensure_ascii=False,
                    indent=2,
                )
            )
            return 1

    if session_name is not None:
        print(
            json.dumps(
                {
                    "ok": False,
                    "command": argv[0],
                    "error": (
                        f"No active HTTP session named {session_name!r}. Run: "
                        f"python cli.py --session {session_name} serve"
                    ),
                },
                ensure_ascii=False,
                indent=2,
            )
        )
        return 1

    from commands.context import CommandSessionContext
    from commands.processor import CommandProcessor

    context = CommandSessionContext(log_callback=lambda m: print(m, file=sys.stderr))
    processor = CommandProcessor(session_context=context)
    result = processor.execute_tokens(argv)
    print(result.to_json_text())
    return result.exit_code


if __name__ == "__main__":
    raise SystemExit(main())
