"""
Terminal CLI entry:

  cd sw_setting
  python cli.py
  python cli.py identify
  python cli.py connect --port COM3 --baud 115200
"""

from __future__ import annotations

import sys
from pathlib import Path

# Allow running from repo root or sw_setting folder
_ROOT = Path(__file__).resolve().parent
if str(_ROOT) not in sys.path:
    sys.path.insert(0, str(_ROOT))

from commands.context import CommandSessionContext  # noqa: E402
from commands.processor import CommandProcessor     # noqa: E402


def main(argv: list[str] | None = None) -> int:
    argv = list(sys.argv[1:] if argv is None else argv)
    context = CommandSessionContext(log_callback=lambda m: print(m, file=sys.stderr))
    processor = CommandProcessor(session_context=context)

    if not argv:
        print("sw_setting CLI — type a command, or 'help'. Empty line / exit to quit.")
        while True:
            try:
                line = input("sw_setting> ").strip()
            except (EOFError, KeyboardInterrupt):
                print()
                return 0
            if not line:
                continue
            if line in ("exit", "quit"):
                return 0
            result = processor.execute_line(line)
            print(result.to_json_text())
            if not result.ok and result.exit_code:
                pass  # interactive: stay in loop
        return 0

    # Single-shot: join argv as one command line
    # Re-quote is imperfect; prefer interactive or pass as one string
    line = " ".join(argv)
    result = processor.execute_line(line)
    print(result.to_json_text())
    return result.exit_code


if __name__ == "__main__":
    raise SystemExit(main())
