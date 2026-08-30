"""HTTP persistent-session client plus legacy raw-TCP client helpers."""

from __future__ import annotations

import json
import re
from pathlib import Path
from typing import Any
from urllib.error import HTTPError, URLError
from urllib.request import Request, urlopen


class HttpSessionClientError(Exception):
    """Raised when the HTTP server/session cannot be reached or used."""


HTTP_SESSION_STATE_FILE_NAME = ".sw_setting_http_session.json"
_SESSION_NAME_PATTERN = re.compile(r"^[A-Za-z0-9][A-Za-z0-9_.-]{0,63}$")


def validate_http_session_name(session_name: str | None) -> str | None:
    """Validate a CLI session alias before using it in a state-file name."""
    if session_name is None:
        return None
    normalized = session_name.strip()
    if not _SESSION_NAME_PATTERN.fullmatch(normalized):
        raise HttpSessionClientError(
            "Invalid session name. Use 1..64 ASCII letters, digits, '.', '_' or '-' "
            "and start with a letter or digit."
        )
    return normalized


def http_session_state_file_path(
    project_root: Path, session_name: str | None = None
) -> Path:
    normalized = validate_http_session_name(session_name)
    if normalized is None:
        return project_root / HTTP_SESSION_STATE_FILE_NAME
    return project_root / f".sw_setting_http_session.{normalized}.json"


def read_http_session_state(
    project_root: Path, session_name: str | None = None
) -> dict[str, Any] | None:
    path = http_session_state_file_path(project_root, session_name)
    if not path.is_file():
        return None
    try:
        payload = json.loads(path.read_text(encoding="utf-8"))
    except (OSError, json.JSONDecodeError):
        return None
    if not payload.get("base_url") or not payload.get("session_id"):
        return None
    return payload


def clear_http_session_state(
    project_root: Path, session_name: str | None = None
) -> None:
    try:
        http_session_state_file_path(project_root, session_name).unlink(missing_ok=True)
    except OSError:
        pass


def _http_json_request(
    method: str,
    url: str,
    payload: dict[str, Any] | None = None,
    timeout_seconds: float = 600.0,
) -> dict[str, Any]:
    data = None
    headers = {"Accept": "application/json"}
    if payload is not None:
        data = json.dumps(payload, ensure_ascii=False).encode("utf-8")
        headers["Content-Type"] = "application/json"
    request = Request(url=url, data=data, headers=headers, method=method)
    try:
        with urlopen(request, timeout=timeout_seconds) as response:
            body = response.read().decode("utf-8")
    except HTTPError as exc:
        try:
            detail = exc.read().decode("utf-8")
        except Exception:
            detail = str(exc)
        raise HttpSessionClientError(
            f"HTTP {exc.code} from {url}: {detail}"
        ) from exc
    except (URLError, OSError) as exc:
        raise HttpSessionClientError(
            f"Cannot reach HTTP server at {url}: {exc}"
        ) from exc

    try:
        result = json.loads(body) if body else {}
    except json.JSONDecodeError as exc:
        raise HttpSessionClientError(
            f"Invalid JSON response from {url}: {exc}"
        ) from exc
    if not isinstance(result, dict):
        raise HttpSessionClientError(f"Unexpected response from {url}: {result!r}")
    return result


def open_http_session(
    project_root: Path,
    base_url: str,
    session_name: str | None = None,
) -> dict[str, Any]:
    """Create a server-side session and persist its id for future CLI calls."""
    normalized_base_url = base_url.rstrip("/")
    response = _http_json_request("POST", f"{normalized_base_url}/sessions", {})
    session_id = str(response.get("session_id") or "").strip()
    if not session_id:
        raise HttpSessionClientError(
            f"Server did not return a session_id: {response!r}"
        )
    state = {
        "base_url": normalized_base_url,
        "session_id": session_id,
        "session_name": validate_http_session_name(session_name),
    }
    http_session_state_file_path(project_root, session_name).write_text(
        json.dumps(state, ensure_ascii=False, indent=2),
        encoding="utf-8",
    )
    return state


def call_http_session_tokens(
    project_root: Path,
    tokens: list[str],
    timeout_seconds: float = 600.0,
    session_name: str | None = None,
) -> dict[str, Any]:
    """Execute argv-style tokens in the currently stored HTTP session."""
    state = read_http_session_state(project_root, session_name)
    if state is None:
        selector = f" --session {session_name}" if session_name else ""
        raise HttpSessionClientError(
            f"No active HTTP session. Run: python cli.py{selector} serve"
        )
    base_url = str(state["base_url"]).rstrip("/")
    session_id = str(state["session_id"])
    return _http_json_request(
        "POST",
        f"{base_url}/sessions/{session_id}/command",
        {"command": tokens[0] if tokens else "?", "tokens": list(tokens)},
        timeout_seconds=timeout_seconds,
    )


def close_http_session(
    project_root: Path, session_name: str | None = None
) -> dict[str, Any]:
    """Delete the stored server-side session and remove the local pointer."""
    state = read_http_session_state(project_root, session_name)
    if state is None:
        clear_http_session_state(project_root, session_name)
        raise HttpSessionClientError("No active HTTP session to close.")
    base_url = str(state["base_url"]).rstrip("/")
    session_id = str(state["session_id"])
    try:
        return _http_json_request(
            "DELETE",
            f"{base_url}/sessions/{session_id}",
            timeout_seconds=30.0,
        )
    finally:
        clear_http_session_state(project_root, session_name)


def print_result_dict(result: dict[str, Any]) -> int:
    print(json.dumps(result, ensure_ascii=False, indent=2))
    if result.get("ok"):
        return 0
    return int(result.get("exit_code") or 1)
