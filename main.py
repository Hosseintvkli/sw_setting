"""
Entry point for the Device Setting Tool.
"""

from __future__ import annotations

import sys
from pathlib import Path

_PACKAGE_ROOT_DIRECTORY = Path(__file__).resolve().parent
if str(_PACKAGE_ROOT_DIRECTORY) not in sys.path:
    sys.path.insert(0, str(_PACKAGE_ROOT_DIRECTORY))

from PyQt6.QtGui import QIcon  # noqa: E402
from PyQt6.QtWidgets import QApplication  # noqa: E402
from ui.main_window import DeviceSettingMainWindow  # noqa: E402


def main() -> None:
    application = QApplication(sys.argv)
    application.setApplicationName("Setting")
    application.setWindowIcon(
        QIcon(str(_PACKAGE_ROOT_DIRECTORY / "files" / "icon" / "icon.ico"))
    )
    main_window = DeviceSettingMainWindow()
    main_window.show()
    sys.exit(application.exec())


if __name__ == "__main__":
    main()
