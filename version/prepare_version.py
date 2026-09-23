"""Generate the application version used by source code and EXE builds."""

from __future__ import annotations

from dataclasses import dataclass
from datetime import date, datetime
from pathlib import Path

if __package__:
    from .project_version import VERSION_MAJOR, VERSION_MINOR
else:
    from project_version import VERSION_MAJOR, VERSION_MINOR


_BUILD_EPOCH = date(2000, 1, 1)


@dataclass(frozen=True)
class ApplicationVersion:
    major: int
    minor: int
    build_1: int
    build_2: int

    @property
    def text(self) -> str:
        return f"{self.major}.{self.minor}.{self.build_1}.{self.build_2}"

    @property
    def title(self) -> str:
        return f"sw_setting (V{self.text})"


def version_from_datetime(build_datetime: datetime) -> ApplicationVersion:
    """Build1 is days since 2000-01-01; Build2 is seconds since midnight."""
    build_1 = (build_datetime.date() - _BUILD_EPOCH).days
    build_2 = (
        build_datetime.hour * 60 * 60
        + build_datetime.minute * 60
        + build_datetime.second
    )
    if build_1 < 0:
        raise RuntimeError("Build date cannot be before 2000-01-01.")
    if VERSION_MAJOR < 0 or VERSION_MINOR < 0:
        raise RuntimeError("VERSION_MAJOR and VERSION_MINOR must be non-negative.")
    return ApplicationVersion(
        major=VERSION_MAJOR,
        minor=VERSION_MINOR,
        build_1=build_1,
        build_2=build_2,
    )


def _write_python_version(project_root: Path, version: ApplicationVersion) -> None:
    target = project_root / "generated_version.py"
    temporary = project_root / "generated_version.py.tmp"
    temporary.write_text(
        "\n".join(
            (
                '"""Generated application version. Do not edit manually."""',
                "",
                f"VERSION_MAJOR = {version.major}",
                f"VERSION_MINOR = {version.minor}",
                f"VERSION_BUILD_1 = {version.build_1}",
                f"VERSION_BUILD_2 = {version.build_2}",
                "",
                "VERSION_TEXT = (",
                '    f"{VERSION_MAJOR}.{VERSION_MINOR}."',
                '    f"{VERSION_BUILD_1}.{VERSION_BUILD_2}"',
                ")",
                'APPLICATION_TITLE = f"sw_setting (V{VERSION_TEXT})"',
                "",
            )
        ),
        encoding="utf-8",
    )
    temporary.replace(target)


def prepare_version_for_build(
    project_root: Path, *, build_datetime: datetime | None = None
) -> ApplicationVersion:
    """Generate and publish a version without modifying Git or running an EXE."""
    version = version_from_datetime(build_datetime or datetime.now())
    _write_python_version(project_root.resolve(), version)
    return version


if __name__ == "__main__":
    root = Path(__file__).resolve().parent.parent
    prepared = prepare_version_for_build(root)
    print(f"Prepared {prepared.title}")
