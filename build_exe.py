"""Official Windows EXE build entry point.

Always prepares the four-part application version before invoking PyInstaller.
"""

from __future__ import annotations

import shutil
import subprocess
import sys
from pathlib import Path

from version.prepare_version import prepare_version_for_build


def _run_pyinstaller(
    *,
    project_root: Path,
    temporary_dist: Path,
    name: str,
    entry_point: Path,
    icon_path: Path,
    windowed: bool,
    add_data: list[tuple[Path, str]],
) -> int:
    separator = ";" if sys.platform == "win32" else ":"
    command = [
        sys.executable,
        "-m",
        "PyInstaller",
        "--noconfirm",
        "--clean",
        "--windowed" if windowed else "--console",
        "--name",
        name,
        "--icon",
        str(icon_path),
        "--distpath",
        str(temporary_dist),
        "--workpath",
        str(project_root / "build" / name),
        "--specpath",
        str(project_root / "build" / "specs"),
    ]
    for source, destination in add_data:
        command.extend(
            ["--add-data", f"{source}{separator}{destination}"]
        )
    command.append(str(entry_point))
    print(f"Building {name}.exe ...", flush=True)
    return subprocess.run(command, cwd=project_root, check=False).returncode


def _merge_onedir_bundle(source: Path, release_directory: Path) -> None:
    """Merge one PyInstaller onedir bundle into the shared release folder."""
    for item in source.iterdir():
        destination = release_directory / item.name
        if item.is_dir():
            shutil.copytree(item, destination, dirs_exist_ok=True)
        else:
            shutil.copy2(item, destination)


def main() -> int:
    project_root = Path(__file__).resolve().parent
    icon_path = project_root / "files" / "icon" / "icon.ico"
    codegen_json_source = project_root / "files" / "codegen_output" / "JSON"
    if not codegen_json_source.is_dir():
        print(f"CodeGen JSON directory not found: {codegen_json_source}", file=sys.stderr)
        return 1
    version = prepare_version_for_build(project_root)
    print(f"Building {version.title}", flush=True)

    temporary_dist = project_root / "build" / "pyinstaller_dist"
    if temporary_dist.exists():
        shutil.rmtree(temporary_dist)
    (project_root / "build" / "specs").mkdir(parents=True, exist_ok=True)

    gui_exit_code = _run_pyinstaller(
        project_root=project_root,
        temporary_dist=temporary_dist,
        name="sw_setting_gui",
        entry_point=project_root / "main.py",
        icon_path=icon_path,
        windowed=True,
        add_data=[
            (icon_path, "files/icon"),
            (project_root / "ui" / "assets", "ui/assets"),
        ],
    )
    if gui_exit_code != 0:
        print("GUI EXE build failed.", file=sys.stderr)
        return gui_exit_code

    cli_exit_code = _run_pyinstaller(
        project_root=project_root,
        temporary_dist=temporary_dist,
        name="sw_setting_cli",
        entry_point=project_root / "cli.py",
        icon_path=icon_path,
        windowed=False,
        add_data=[],
    )
    if cli_exit_code != 0:
        print("CLI/Server EXE build failed.", file=sys.stderr)
        return cli_exit_code

    release_directory = project_root / "dist" / "sw_setting"
    if release_directory.exists():
        shutil.rmtree(release_directory)
    release_directory.mkdir(parents=True)
    _merge_onedir_bundle(
        temporary_dist / "sw_setting_gui", release_directory
    )
    _merge_onedir_bundle(
        temporary_dist / "sw_setting_cli", release_directory
    )
    codegen_json_destination = (
        release_directory / "files" / "codegen_output" / "JSON"
    )
    shutil.copytree(codegen_json_source, codegen_json_destination)
    print(f"Build complete: {release_directory}")
    print(f"GUI: {release_directory / 'sw_setting_gui.exe'}")
    print(f"CLI/Server: {release_directory / 'sw_setting_cli.exe'}")
    print(f"CodeGen JSON copied to: {codegen_json_destination}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
