"""
HTTP session server for sw_setting.

- Multiple independent sessions (two setting clients can work in parallel).
- Each session has its own Modbus link + CommandSessionContext.
- Long commands (e.g. identify) can be cancelled via POST .../cancel.

Bind default: 0.0.0.0:8000 (reachable from other machines on the LAN).

Endpoints:
  GET  /health
  GET  /sessions
  POST /sessions                         -> { "session_id": "..." }
  DELETE /sessions/{session_id}
  POST /sessions/{session_id}/command    body: { "command": "connect", "args": {...} }
  POST /sessions/{session_id}/cancel     -> cancel in-flight long command
  GET  /sessions/{session_id}/logs       -> recent log lines
"""

from __future__ import annotations

import asyncio
import threading
import traceback
import uuid
from dataclasses import dataclass, field
from datetime import datetime, timezone
from typing import Any

from fastapi import FastAPI, HTTPException
from fastapi.middleware.cors import CORSMiddleware
from pydantic import BaseModel, Field

from commands.command_request_builder import structured_request_to_tokens
from commands.context import CommandSessionContext
from commands.processor import CommandProcessor


class CommandBody(BaseModel):
    command: str = Field(..., description="Command name or full command line")
    args: dict[str, Any] | None = Field(
        default=None, description="Optional structured arguments"
    )
    tokens: list[str] | None = Field(
        default=None, description="Optional raw argv (advanced)"
    )


@dataclass
class SessionState:
    session_id: str
    context: CommandSessionContext
    processor: CommandProcessor
    cancel_event: threading.Event = field(default_factory=threading.Event)
    busy: bool = False
    current_command: str | None = None
    log_lines: list[str] = field(default_factory=list)
    created_at: str = field(
        default_factory=lambda: datetime.now(timezone.utc).isoformat()
    )
    lock: threading.Lock = field(default_factory=threading.Lock)

    def append_log(self, message: str) -> None:
        self.log_lines.append(message)
        if len(self.log_lines) > 2000:
            self.log_lines = self.log_lines[-1500:]


_sessions: dict[str, SessionState] = {}
_sessions_lock = threading.Lock()


def _get_session(session_id: str) -> SessionState:
    with _sessions_lock:
        state = _sessions.get(session_id)
    if state is None:
        raise HTTPException(status_code=404, detail=f"Unknown session_id: {session_id}")
    return state


def create_app() -> FastAPI:
    app = FastAPI(title="sw_setting HTTP API", version="0.2.0")
    app.add_middleware(
        CORSMiddleware,
        allow_origins=["*"],
        allow_methods=["*"],
        allow_headers=["*"],
    )

    @app.get("/health")
    def health() -> dict[str, Any]:
        with _sessions_lock:
            n = len(_sessions)
        return {"ok": True, "sessions": n}

    @app.get("/sessions")
    def list_sessions() -> dict[str, Any]:
        with _sessions_lock:
            items = [
                {
                    "session_id": s.session_id,
                    "created_at": s.created_at,
                    "busy": s.busy,
                    "current_command": s.current_command,
                    "connected": s.context.device_modbus_link.is_connected,
                }
                for s in _sessions.values()
            ]
        return {"sessions": items}

    @app.post("/sessions")
    def open_session() -> dict[str, Any]:
        session_id = uuid.uuid4().hex
        state = SessionState(
            session_id=session_id,
            context=CommandSessionContext(),
            processor=CommandProcessor(),  # temporary; re-bind below
        )

        def log_cb(message: str) -> None:
            state.append_log(message)

        def cancel_check() -> bool:
            return state.cancel_event.is_set()

        state.context = CommandSessionContext(
            log_callback=log_cb,
            cancel_check=cancel_check,
        )
        state.processor = CommandProcessor(session_context=state.context)

        with _sessions_lock:
            _sessions[session_id] = state
        return {"session_id": session_id, "created_at": state.created_at}

    @app.delete("/sessions/{session_id}")
    def close_session(session_id: str) -> dict[str, Any]:
        state = _get_session(session_id)
        state.cancel_event.set()
        try:
            state.context.device_modbus_link.disconnect()
        except Exception:
            pass
        with _sessions_lock:
            _sessions.pop(session_id, None)
        return {"ok": True, "session_id": session_id, "closed": True}

    @app.post("/sessions/{session_id}/cancel")
    def cancel_session_command(session_id: str) -> dict[str, Any]:
        state = _get_session(session_id)
        state.cancel_event.set()
        state.append_log("Cancel requested by client.")
        return {
            "ok": True,
            "session_id": session_id,
            "cancel_requested": True,
            "busy": state.busy,
            "current_command": state.current_command,
        }

    @app.get("/sessions/{session_id}/logs")
    def session_logs(session_id: str, limit: int = 200) -> dict[str, Any]:
        state = _get_session(session_id)
        lines = state.log_lines[-max(1, min(limit, 2000)) :]
        return {
            "session_id": session_id,
            "busy": state.busy,
            "current_command": state.current_command,
            "lines": lines,
        }

    @app.post("/sessions/{session_id}/command")
    async def run_command(session_id: str, body: CommandBody) -> dict[str, Any]:
        """
        Run a command on this session.

        Long work (identify) runs in a worker thread so POST .../cancel can be
        handled concurrently on the event loop.
        """
        state = _get_session(session_id)

        try:
            payload = body.model_dump()
            tokens = structured_request_to_tokens(payload)
        except ValueError as exc:
            raise HTTPException(status_code=400, detail=str(exc)) from exc

        with state.lock:
            if state.busy:
                raise HTTPException(
                    status_code=409,
                    detail=(
                        f"Session busy with command {state.current_command!r}. "
                        "Wait or POST .../cancel"
                    ),
                )
            state.busy = True
            state.current_command = tokens[0] if tokens else None
            state.cancel_event.clear()

        def _execute() -> dict[str, Any]:
            try:
                result = state.processor.execute_tokens(tokens)
                return result.to_json_dict()
            except Exception as exc:
                state.append_log(f"Unhandled error: {exc}")
                state.append_log(traceback.format_exc())
                return {
                    "ok": False,
                    "command": tokens[0] if tokens else "?",
                    "data": {},
                    "error": str(exc),
                }
            finally:
                with state.lock:
                    state.busy = False
                    state.current_command = None

        return await asyncio.to_thread(_execute)

    return app


def run_http_server(host: str = "0.0.0.0", port: int = 8000) -> None:
    import uvicorn

    app = create_app()
    uvicorn.run(app, host=host, port=port, log_level="info")
