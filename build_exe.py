"""Official Windows EXE build entry point.

Always prepares the four-part application version before invoking PyInstaller.
"""

from __future__ import annotations

import subprocess
import shutil
import sys
from pathlib import Path

from version.prepare_version import prepare_version_for_build


def main() -> int:
    project_root = Path(__file__).resolve().parent
    icon_path = project_root / "files" / "icon" / "icon.ico"
    codegen_json_source = project_root / "files" / "codegen_output" / "JSON"
    if not codegen_json_source.is_dir():
        print(f"CodeGen JSON directory not found: {codegen_json_source}", file=sys.stderr)
        return 1
    version = prepare_version_for_build(project_root)
    print(f"Building {version.title}", flush=True)

    add_data_separator = ";" if sys.platform == "win32" else ":"
    command = [
        sys.executable,
        "-m",
        "PyInstaller",
        "--noconfirm",
        "--clean",
        "--windowed",
        "--name",
        "sw_setting",
        "--icon",
        str(icon_path),
        "--add-data",
        f"{icon_path}{add_data_separator}files/icon",
        "--add-data",
        (
            f"{project_root / 'ui' / 'assets'}"
            f"{add_data_separator}ui/assets"
        ),
        str(project_root / "main.py"),
    ]
    completed = subprocess.run(command, cwd=project_root, check=False)
    if completed.returncode != 0:
        print("EXE build failed.", file=sys.stderr)
        return completed.returncode
    release_directory = project_root / "dist" / "sw_setting"
    codegen_json_destination = (
        release_directory / "files" / "codegen_output" / "JSON"
    )
    shutil.copytree(codegen_json_source, codegen_json_destination)
    print(f"Build complete: {release_directory}")
    print(f"CodeGen JSON copied to: {codegen_json_destination}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
