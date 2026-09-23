"""Compact operator-facing Qt theme inspired by the legacy Setting tool."""

from __future__ import annotations

from pathlib import Path

from PyQt6.QtGui import QFont


def operator_font() -> QFont:
    """Return the compact Windows UI font used throughout the application."""
    font = QFont("Segoe UI", 9)
    font.setStyleHint(QFont.StyleHint.System)
    return font


OPERATOR_STYLESHEET = r"""
QMainWindow, QWidget {
    background-color: #f5f6f8;
    color: #20242a;
}

QGroupBox {
    border: 1px solid #d4d8de;
    border-radius: 4px;
    margin-top: 11px;
    padding: 10px 7px 7px 7px;
    background-color: #ffffff;
}
QGroupBox::title {
    subcontrol-origin: margin;
    subcontrol-position: top left;
    left: 9px;
    padding: 0 5px;
    color: #4a5565;
    background-color: #f5f6f8;
    font-weight: 600;
}

QRadioButton {
    spacing: 7px;
    padding: 3px 5px;
    border-radius: 4px;
}
QRadioButton:hover {
    background: #edf5fb;
}
QRadioButton:checked {
    color: #32336c;
    font-weight: 600;
    background: #e7f1fa;
}
QRadioButton::indicator {
    width: 16px;
    height: 16px;
    border: none;
    background: transparent;
    image: url("__RADIO_UNCHECKED__");
}
QRadioButton::indicator:checked {
    image: url("__RADIO_CHECKED__");
}

QTabWidget::pane {
    border: 1px solid #d1d5db;
    background: #ffffff;
    top: -1px;
}
QTabBar::tab {
    background: #e9ecf1;
    color: #4b5563;
    border: 1px solid #d1d5db;
    border-bottom: none;
    padding: 5px 13px;
    min-height: 19px;
    margin-right: 2px;
    border-top-left-radius: 4px;
    border-top-right-radius: 4px;
}
QTabBar::tab:selected {
    background: #ffffff;
    color: #32336c;
    font-weight: 600;
}
QTabBar::tab:hover:!selected {
    background: #f2f5f8;
    color: #273444;
}

QPushButton {
    min-height: 23px;
    padding: 1px 10px;
    border: 1px solid #b8bec7;
    border-radius: 4px;
    background: #ffffff;
    color: #27313d;
}
QPushButton:hover {
    border-color: #7778a7;
    background: #f3f8fc;
}
QPushButton:pressed {
    background: #e1edf7;
}
QPushButton:disabled {
    color: #9aa1aa;
    background: #eceff2;
    border-color: #d5d9de;
}
QPushButton#primaryActionButton {
    background: #32336c;
    border-color: #262752;
    color: #ffffff;
    font-weight: 600;
}
QPushButton#primaryActionButton:hover {
    background: #414386;
}
QPushButton#dangerActionButton {
    background: #fff3f3;
    border-color: #dca6a6;
    color: #9d3030;
}
QPushButton#secondaryActionButton {
    background: #eeeef7;
    border-color: #b7b8d0;
    color: #32336c;
}

QLineEdit, QComboBox, QSpinBox {
    min-height: 23px;
    padding: 0 6px;
    border: 1px solid #b9bec6;
    border-radius: 3px;
    background: #ffffff;
    selection-background-color: #32336c;
    selection-color: #ffffff;
}
QLineEdit:focus, QComboBox:focus, QSpinBox:focus {
    border: 1px solid #32336c;
}
QComboBox::drop-down {
    width: 20px;
    border: none;
    border-left: 1px solid #d4d7dc;
}
QComboBox::down-arrow {
    image: url("__COMBO_DOWN_ARROW__");
    width: 12px;
    height: 8px;
}
QComboBox::down-arrow:on {
    top: 1px;
}
QComboBox QAbstractItemView {
    padding: 4px;
    border: 1px solid #aeb6c1;
    background: #ffffff;
    selection-background-color: #dcebf8;
    selection-color: #1f3448;
    outline: none;
}
QComboBox QAbstractItemView::item {
    min-height: 26px;
    padding: 3px 7px;
}

QTreeWidget, QTableView, QTextEdit, QPlainTextEdit {
    border: 1px solid #c7ccd3;
    border-radius: 2px;
    background: #ffffff;
    alternate-background-color: #f7f8fa;
    selection-background-color: #32336c;
    selection-color: #ffffff;
}
QTreeWidget::item {
    min-height: 21px;
}
QTreeWidget::item:hover:!selected {
    background: #edf5fb;
}
QHeaderView::section {
    min-height: 22px;
    padding: 2px 6px;
    border: none;
    border-right: 1px solid #d4d8de;
    border-bottom: 1px solid #c1c7cf;
    background: #eef1f5;
    color: #374151;
    font-weight: 600;
}

QProgressBar {
    min-height: 14px;
    max-height: 14px;
    border: 1px solid #c3c8cf;
    border-radius: 3px;
    background: #eef0f3;
    text-align: center;
}
QProgressBar::chunk {
    background: #32336c;
    border-radius: 2px;
}

QGroupBox#deviceInformationBox {
    background: #d2ae6d;
    border: 1px solid #ad8744;
    border-radius: 5px;
    padding-top: 10px;
}
QGroupBox#deviceInformationBox::title {
    color: #32336c;
    background: #f5f6f8;
    font-weight: 600;
}
QGroupBox#deviceInformationBox QLabel#deviceInfoValue {
    background: #fffaf0;
    color: #32336c;
    border: 1px solid #ae8847;
    border-radius: 2px;
    padding: 1px 6px;
    min-height: 19px;
}

QWidget#reportLogPanel {
    background: #f5f6f8;
    border-left: 1px solid #d1d5db;
}
QTextEdit#reportLogText, QTextEdit#profileLogText,
QTextEdit#commandLogText, QPlainTextEdit#cliOutputText {
    font-family: Consolas, "Courier New";
    font-size: 9pt;
}

QLabel#identifyStateLabel {
    color: #5e4b17;
    background: #fff7db;
    border: 1px solid #dfca82;
    border-radius: 3px;
    padding: 4px 6px;
}

QStatusBar {
    background: #e9ecf0;
    border-top: 1px solid #c5cad1;
    min-height: 22px;
}
QLabel#statusSegment {
    border: 1px solid #b8bec7;
    border-radius: 3px;
    padding: 1px 8px;
    margin: 1px 0 1px 2px;
    color: #27313d;
}

QSplitter::handle {
    background: #d2d6dc;
}
QSplitter::handle:horizontal {
    width: 5px;
}
QSplitter::handle:horizontal:hover {
    background: #8fb5d6;
}

QScrollBar:vertical {
    width: 11px;
    margin: 1px;
    border: none;
    background: #eef0f3;
}
QScrollBar::handle:vertical {
    min-height: 28px;
    border-radius: 4px;
    background: #aeb5bf;
}
QScrollBar::handle:vertical:hover {
    background: #858f9c;
}
QScrollBar:horizontal {
    height: 11px;
    margin: 1px;
    border: none;
    background: #eef0f3;
}
QScrollBar::handle:horizontal {
    min-width: 28px;
    border-radius: 4px;
    background: #aeb5bf;
}
QScrollBar::handle:horizontal:hover {
    background: #858f9c;
}
QScrollBar::add-line, QScrollBar::sub-line {
    width: 0px;
    height: 0px;
    border: none;
    background: transparent;
}
QScrollBar::add-page, QScrollBar::sub-page {
    background: transparent;
}
QToolTip {
    color: #20242a;
    background: #ffffdc;
    border: 1px solid #9ca3ad;
}
"""

OPERATOR_STYLESHEET = OPERATOR_STYLESHEET.replace(
    "__COMBO_DOWN_ARROW__",
    (Path(__file__).resolve().parent / "assets" / "chevron_down.svg").as_posix(),
)
OPERATOR_STYLESHEET = OPERATOR_STYLESHEET.replace(
    "__RADIO_UNCHECKED__",
    (Path(__file__).resolve().parent / "assets" / "radio_unchecked.svg").as_posix(),
)
OPERATOR_STYLESHEET = OPERATOR_STYLESHEET.replace(
    "__RADIO_CHECKED__",
    (Path(__file__).resolve().parent / "assets" / "radio_checked.svg").as_posix(),
)
