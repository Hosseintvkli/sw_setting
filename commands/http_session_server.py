"""
HTTP session server for sw_setting.

- Multiple independent sessions (two setting clients can work in parallel).
- Each session has its own Modbus link + CommandSessionContext.
- Long commands (e.g. identify) can be cancelled via POST .../cancel.

Bind default: 127.0.0.1:8000. Use 0.0.0.0 explicitly for trusted LAN access.

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
from pydantic import BaseModel, ConfigDict, Field

from commands.context import CommandSessionContext
from commands.processor import CommandProcessor


class CommandBody(BaseModel):
    model_config = ConfigDict(extra="forbid")

    tokens: list[str] = Field(
        ...,
        min_length=1,
        description="Complete argv-style command; tokens[0] is the command name",
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
    events: list[dict[str, Any]] = field(default_factory=list)
    event_sequence: int = 0
    created_at: str = field(
        default_factory=lambda: datetime.now(timezone.utc).isoformat()
    )
    lock: threading.Lock = field(default_factory=threading.Lock)
    event_condition: threading.Condition = field(
        default_factory=threading.Condition
    )

    def append_log(self, message: str) -> None:
        with self.event_condition:
            self.log_lines.append(message)
            if len(self.log_lines) > 2000:
                self.log_lines = self.log_lines[-1500:]
            self._append_event_locked("log", message, {})

    def append_event(
        self,
        event_type: str,
        message: str,
        data: dict[str, Any] | None = None,
    ) -> None:
        with self.event_condition:
            self._append_event_locked(event_type, message, dict(data or {}))

    def _append_event_locked(
        self,
        event_type: str,
        message: str,
        data: dict[str, Any],
    ) -> None:
        self.event_sequence += 1
        self.events.append(
            {
                "sequence": self.event_sequence,
                "timestamp": datetime.now(timezone.utc).isoformat(),
                "type": event_type,
                "message": message,
                "data": data,
            }
        )
        if len(self.events) > 4000:
            self.events = self.events[-3000:]
        self.event_condition.notify_all()


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

        def progress_cb(
            event_type: str,
            message: str,
            data: dict[str, Any],
        ) -> None:
            state.append_event(event_type, message, data)

        state.context = CommandSessionContext(
            log_callback=log_cb,
            cancel_check=cancel_check,
            progress_callback=progress_cb,
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
        state.append_event(
            "cancel_requested",
            "Cancellation requested.",
            {
                "busy": state.busy,
                "current_command": state.current_command,
            },
        )
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
        with state.event_condition:
            lines = list(state.log_lines[-max(1, min(limit, 2000)) :])
        return {
            "session_id": session_id,
            "busy": state.busy,
            "current_command": state.current_command,
            "lines": lines,
        }

    @app.get("/sessions/{session_id}/events")
    def session_events(
        session_id: str,
        after: int | None = None,
        limit: int = 200,
        wait_ms: int = 0,
    ) -> dict[str, Any]:
        """Return numbered session events, optionally waiting for a new one."""
        state = _get_session(session_id)
        bounded_limit = max(1, min(int(limit), 1000))
        bounded_wait_seconds = max(0, min(int(wait_ms), 30_000)) / 1000.0
        with state.event_condition:
            if after is None:
                # Tail mode: establish a cursor without replaying old events.
                selected: list[dict[str, Any]] = []
                next_cursor = state.event_sequence
            else:
                if (
                    bounded_wait_seconds > 0
                    and not any(e["sequence"] > after for e in state.events)
                ):
                    state.event_condition.wait(timeout=bounded_wait_seconds)
                selected = [
                    dict(event)
                    for event in state.events
                    if int(event["sequence"]) > after
                ][:bounded_limit]
                next_cursor = (
                    int(selected[-1]["sequence"])
                    if selected
                    else max(int(after), state.event_sequence)
                )
        return {
            "session_id": session_id,
            "events": selected,
            "next_cursor": next_cursor,
            "busy": state.busy,
            "current_command": state.current_command,
        }

    @app.post("/sessions/{session_id}/command")
    async def run_command(session_id: str, body: CommandBody) -> dict[str, Any]:
        """
        Run a command on this session.

        Long work (identify) runs in a worker thread so POST .../cancel can be
        handled concurrently on the event loop.
        """
        state = _get_session(session_id)

        tokens = list(body.tokens)

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
            command_name = tokens[0] if tokens else "?"
            state.append_event(
                "command_started",
                f"Command started: {command_name}",
                {"command": command_name},
            )
            try:
                result = state.processor.execute_tokens(tokens)
                payload = result.to_json_dict()
                state.append_event(
                    "command_finished",
                    f"Command finished: {command_name}",
                    {
                        "command": command_name,
                        "ok": bool(payload.get("ok")),
                        "error": payload.get("error"),
                    },
                )
                return payload
            except Exception as exc:
                state.append_log(f"Unhandled error: {exc}")
                state.append_log(traceback.format_exc())
                state.append_event(
                    "command_finished",
                    f"Command failed: {command_name}",
                    {
                        "command": command_name,
                        "ok": False,
                        "error": str(exc),
                    },
                )
                return {
                    "ok": False,
                    "command": command_name,
                    "data": {},
                    "error": str(exc),
                }
            finally:
                with state.lock:
                    state.busy = False
                    state.current_command = None

        return await asyncio.to_thread(_execute)

    return app


def run_http_server(host: str = "127.0.0.1", port: int = 8000) -> None:
    import uvicorn

    app = create_app()
    uvicorn.run(app, host=host, port=port, log_level="info")
