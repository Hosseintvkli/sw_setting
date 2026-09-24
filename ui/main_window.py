"""Command-driven GUI.

Widgets never call ``core``. Every operation is shown as and executed through
an exact ``python cli.py ...`` command in :class:`CliConsolePanel`.
"""

from __future__ import annotations

import html
import re
import time
from pathlib import Path
from typing import Any

from PyQt6.QtCore import QEasingCurve, QTimer, Qt, QVariantAnimation
from PyQt6.QtGui import QBrush, QColor, QGuiApplication
from PyQt6.QtWidgets import (
    QAbstractItemView,
    QCheckBox,
    QDialog,
    QDialogButtonBox,
    QFileDialog,
    QFormLayout,
    QGridLayout,
    QGroupBox,
    QHBoxLayout,
    QLabel,
    QLineEdit,
    QMainWindow,
    QMessageBox,
    QProgressBar,
    QPushButton,
    QSizePolicy,
    QSplitter,
    QScrollArea,
    QTabWidget,
    QTextEdit,
    QTreeWidget,
    QTreeWidgetItem,
    QVBoxLayout,
    QWidget,
)

from ui.cli_console_panel import CliConsolePanel, parse_cli_invocation
from ui.communication_panel import CommunicationSettingsPanel
from ui.operator_theme import OPERATOR_STYLESHEET, operator_font
from generated_version import APPLICATION_TITLE

_ROLE_KIND = Qt.ItemDataRole.UserRole
_ROLE_NAME = Qt.ItemDataRole.UserRole + 1
_ROLE_LAST_VALUE = Qt.ItemDataRole.UserRole + 2
_ROLE_NODE = Qt.ItemDataRole.UserRole + 3
_ROLE_PARAMETER_ID = Qt.ItemDataRole.UserRole + 4
_ROLE_LAST_READ_MONOTONIC = Qt.ItemDataRole.UserRole + 5
_ROLE_CHANGE_HIGHLIGHT_UNTIL = Qt.ItemDataRole.UserRole + 6
_ROLE_MONITORING_VISUAL_STATE = Qt.ItemDataRole.UserRole + 7
_ROLE_TOPOLOGY_BASE_LABEL = Qt.ItemDataRole.UserRole + 8
_MONITORING_PARAMETERS_PER_COMMAND = 250
_MONITORING_STALE_AFTER_SECONDS = 2.0
_STATUS_OK_COLOR = "#d9f0df"
_STATUS_ERROR_COLOR = "#f8d7da"
_STATUS_IDLE_COLOR = "#fff0b3"
_STATUS_BUSY_COLOR = "#dcebf8"
_STATUS_CANCELLED_COLOR = "#fde5bf"


class DeviceSettingMainWindow(QMainWindow):
    _LEFT_PANEL_WIDTH_PIXELS = 350

    def __init__(self) -> None:
        super().__init__()
        self.setWindowTitle(APPLICATION_TITLE)
        self.resize(1440, 800)
        self.setMinimumSize(1080, 650)
        self.setFont(operator_font())
        self.setStyleSheet(OPERATOR_STYLESHEET)

        self._connected = False
        self._cli_busy = False
        self._identify_running = False
        self._identify_cancel_requested = False
        self._settings_load_running = False
        self._profile_operation_running = False
        self._operation_cancel_requested = False
        self._live_identify_items: dict[int, QTreeWidgetItem] = {}
        self._live_identify_port_items: dict[tuple[int, int], QTreeWidgetItem] = {}
        self._device_discovery_animations: set[QVariantAnimation] = set()
        self._session_ready_flag = False
        self._settings_loaded = False
        self._loaded_profile_tag1_categories: list[str] = []
        self._suppress_setting_change = False
        self._selected_slave_id: int | None = None
        self._loaded_topology_slave_id: int | None = None
        self._pending_device_slave_id: int | None = None
        self._monitoring_selected_parameter_ids: set[int] = set()
        self._monitoring_items_by_parameter_id: dict[int, QTreeWidgetItem] = {}
        self._monitoring_device_ready = False
        self._monitoring_read_in_flight = False
        self._monitoring_read_scheduled = False
        self._monitoring_next_parameter_index = 0
        self._suppress_monitoring_item_change = False
        self._pending_watched_command: tuple[
            str, list[str], object, bool, str, bool
        ] | None = None
        self._global_progress_command: str | None = None
        self._global_progress_generation = 0

        self.cli_console_panel = CliConsolePanel(Path(__file__).resolve().parent.parent)
        self._build_ui()
        self._build_status_bar()
        self._connect_signals()
        self._monitoring_visual_timer = QTimer(self)
        self._monitoring_visual_timer.setInterval(100)
        self._monitoring_visual_timer.timeout.connect(self._on_monitoring_visual_timer)
        self._monitoring_visual_timer.start()
        self._set_connected_state(False)
        self._append_log(
            "GUI is command-driven. Every action is recorded in the CLI tab."
        )

    def _build_ui(self) -> None:
        # ----- left: communication -----
        self.communication_settings_panel = CommunicationSettingsPanel()
        self.push_button_connection_toggle = QPushButton("Connect")
        self.push_button_connection_toggle.setObjectName("primaryActionButton")
        connection_buttons = QHBoxLayout()
        connection_buttons.setContentsMargins(12, 0, 0, 0)
        connection_buttons.addWidget(self.push_button_connection_toggle)
        connection_buttons.addStretch(1)

        communicate_tab = QWidget()
        communicate_layout = QVBoxLayout(communicate_tab)
        communicate_layout.setContentsMargins(0, 0, 0, 0)
        communicate_layout.addWidget(self.communication_settings_panel)
        communicate_layout.addLayout(connection_buttons)
        communicate_layout.addStretch(1)

        # ----- left: topology -----
        self.push_button_run_identify = QPushButton("Identify")
        self.push_button_cancel_identify = QPushButton("Cancel Identify")
        self.push_button_run_identify.setObjectName("primaryActionButton")
        self.push_button_cancel_identify.setObjectName("dangerActionButton")
        self.push_button_cancel_identify.hide()
        identify_buttons = QHBoxLayout()
        identify_buttons.addWidget(self.push_button_run_identify)
        identify_buttons.addWidget(self.push_button_cancel_identify)
        identify_buttons.addStretch(1)
        self.devices_topology_tree_widget = QTreeWidget()
        self.devices_topology_tree_widget.setHeaderLabels(
            ["Device", "SlaveId", "DeviceId", "Version", "Ports"]
        )
        self.devices_topology_tree_widget.setUniformRowHeights(True)
        devices_tab = QWidget()
        devices_layout = QVBoxLayout(devices_tab)
        devices_layout.addLayout(identify_buttons)
        devices_layout.addWidget(
            QLabel(
                "Double-click to load a device.  "
                "● marks the currently loaded device."
            )
        )
        devices_layout.addWidget(self.devices_topology_tree_widget, stretch=1)

        self.left_tab_widget = QTabWidget()
        self.left_tab_widget.addTab(communicate_tab, "Communicate")
        self.left_tab_widget.addTab(devices_tab, "Devices")
        left_container = QWidget()
        left_container.setMinimumWidth(0)
        left_container.setSizePolicy(
            QSizePolicy.Policy.Preferred, QSizePolicy.Policy.Expanding
        )
        left_layout = QVBoxLayout(left_container)
        left_layout.setContentsMargins(4, 4, 4, 4)
        left_layout.addWidget(self.left_tab_widget)

        # ----- monitoring -----
        self.label_monitoring_slave_id = self._device_info_value_label()
        self.label_monitoring_device_id = self._device_info_value_label()
        self.label_monitoring_serial_no = self._device_info_value_label()
        self.label_monitoring_hardware_version = self._device_info_value_label()
        self.label_monitoring_firmware_version = self._device_info_value_label()
        self.label_monitoring_device_name = self._device_info_value_label()
        monitoring_grid = QGridLayout()
        monitoring_grid.setContentsMargins(5, 4, 5, 4)
        monitoring_grid.setHorizontalSpacing(5)
        monitoring_grid.setVerticalSpacing(3)
        info_fields = (
            ("SlaveID:", self.label_monitoring_slave_id),
            ("DeviceID:", self.label_monitoring_device_id),
            ("SerialNo:", self.label_monitoring_serial_no),
            ("HW. Ver:", self.label_monitoring_hardware_version),
            ("FW. Ver:", self.label_monitoring_firmware_version),
        )
        for field_index, (caption, value_label) in enumerate(info_fields):
            column = field_index * 2
            caption_label = QLabel(caption)
            caption_label.setObjectName("deviceInfoCaption")
            monitoring_grid.addWidget(caption_label, 0, column)
            monitoring_grid.addWidget(value_label, 0, column + 1)
        name_caption_label = QLabel("Name:")
        name_caption_label.setObjectName("deviceInfoCaption")
        monitoring_grid.addWidget(name_caption_label, 1, 0)
        monitoring_grid.addWidget(self.label_monitoring_device_name, 1, 1, 1, 9)
        monitoring_box = QGroupBox("Device Information")
        monitoring_box.setObjectName("deviceInformationBox")
        monitoring_box.setLayout(monitoring_grid)
        monitoring_box.setMaximumHeight(92)

        self.push_button_reload_settings_tree = QPushButton("Reload")
        self.push_button_reload_settings_tree.setObjectName("secondaryActionButton")
        self.label_selected_device = QLabel("Selected device: (none)")
        toolbar = QHBoxLayout()
        toolbar.addWidget(self.push_button_reload_settings_tree)
        toolbar.addStretch(1)
        toolbar.addWidget(self.label_selected_device)

        self.push_button_cancel_settings_load = QPushButton("Cancel Load")
        self.push_button_cancel_settings_load.setObjectName("dangerActionButton")
        self.push_button_cancel_settings_load.hide()

        # ----- parameters -----
        self.settings_tree_widget = QTreeWidget()
        self.settings_tree_widget.setColumnCount(4)
        self.settings_tree_widget.setHeaderLabels(
            ["Name", "Value", "DataType", "ModbusAddr"]
        )
        self.settings_tree_widget.setAlternatingRowColors(True)
        self.settings_tree_widget.setUniformRowHeights(True)
        self.settings_tree_widget.setEditTriggers(
            QAbstractItemView.EditTrigger.NoEditTriggers
        )
        self.line_edit_settings_filter = QLineEdit()
        self.line_edit_settings_filter.setPlaceholderText(
            "Type part of a parameter name..."
        )
        self.line_edit_settings_filter.setClearButtonEnabled(True)
        self.line_edit_settings_filter.setEnabled(False)
        settings_filter_layout = QHBoxLayout()
        settings_filter_layout.addWidget(QLabel("Search parameters:"))
        settings_filter_layout.addWidget(self.line_edit_settings_filter, stretch=1)
        self.push_button_copy_setting_name = QPushButton("Copy Name")
        self.push_button_copy_setting_name.setObjectName("secondaryActionButton")
        self.push_button_copy_setting_name.setEnabled(False)
        settings_filter_layout.addWidget(self.push_button_copy_setting_name)
        parameters_tab = QWidget()
        parameters_layout = QVBoxLayout(parameters_tab)
        parameters_layout.addWidget(
            QLabel(
                "SETTING R/W — double-click Value, then Enter to execute set-parameter"
            )
        )
        parameters_layout.addWidget(self.settings_tree_widget, stretch=1)
        parameters_layout.addLayout(settings_filter_layout)

        # ----- periodic monitoring -----
        self.push_button_periodic_monitoring_read = QPushButton("Start Monitoring")
        self.push_button_periodic_monitoring_read.setObjectName("primaryActionButton")
        self.push_button_periodic_monitoring_read.setCheckable(True)
        self.push_button_periodic_monitoring_read.setChecked(False)
        self.push_button_toggle_all_monitoring_parameters = QPushButton("Select All")
        self.push_button_toggle_all_monitoring_parameters.setEnabled(False)
        self.label_monitoring_selection_summary = QLabel("0 available · 0 selected")
        self.label_monitoring_selection_summary.setObjectName(
            "monitoringSelectionSummary"
        )
        monitoring_controls = QHBoxLayout()
        monitoring_controls.addWidget(self.push_button_periodic_monitoring_read)
        monitoring_controls.addWidget(self.push_button_toggle_all_monitoring_parameters)
        monitoring_controls.addStretch(1)
        monitoring_controls.addWidget(self.label_monitoring_selection_summary)

        self.monitoring_parameters_tree_widget = QTreeWidget()
        self.monitoring_parameters_tree_widget.setColumnCount(5)
        self.monitoring_parameters_tree_widget.setHeaderLabels(
            ["Name", "Read", "Value", "DataType", "ModbusAddr"]
        )
        self.monitoring_parameters_tree_widget.setAlternatingRowColors(True)
        self.monitoring_parameters_tree_widget.setUniformRowHeights(True)
        self.monitoring_parameters_tree_widget.setRootIsDecorated(True)
        self.line_edit_monitoring_filter = QLineEdit()
        self.line_edit_monitoring_filter.setPlaceholderText(
            "Type part of a Monitoring parameter name..."
        )
        self.line_edit_monitoring_filter.setClearButtonEnabled(True)
        self.line_edit_monitoring_filter.setEnabled(False)
        monitoring_filter_layout = QHBoxLayout()
        monitoring_filter_layout.addWidget(QLabel("Search parameters:"))
        monitoring_filter_layout.addWidget(
            self.line_edit_monitoring_filter, stretch=1
        )
        monitoring_tab = QWidget()
        monitoring_layout = QVBoxLayout(monitoring_tab)
        monitoring_layout.addLayout(monitoring_controls)
        monitoring_layout.addWidget(
            QLabel("Only checked parameters are read periodically."),
        )
        monitoring_layout.addWidget(
            self.monitoring_parameters_tree_widget,
            stretch=1,
        )
        monitoring_layout.addLayout(monitoring_filter_layout)
        self.monitoring_tab = monitoring_tab

        # ----- profile -----
        self.line_edit_profile_csv_path = QLineEdit()
        self.line_edit_profile_csv_path.setPlaceholderText("Path to profile CSV file")
        self.push_button_browse_profile_csv = QPushButton("Browse...")
        csv_row = QHBoxLayout()
        csv_row.addWidget(self.line_edit_profile_csv_path, stretch=1)
        csv_row.addWidget(self.push_button_browse_profile_csv)
        self.check_box_apply_profile_to_all_similar_device_ids = QCheckBox(
            "Apply / Verify to all same devices"
        )
        self.check_box_apply_profile_to_all_similar_device_ids.setToolTip(
            "Apply or verify on every compatible discovered device of this type."
        )
        self.push_button_profile_apply = QPushButton("Apply")
        self.push_button_profile_verify = QPushButton("Verify")
        self.push_button_profile_save = QPushButton("Save parameters as profile...")
        self.push_button_clear_profile_log = QPushButton("Clear Log")
        self.push_button_cancel_profile = QPushButton("Cancel")
        self.push_button_profile_apply.setObjectName("primaryActionButton")
        self.push_button_profile_verify.setObjectName("secondaryActionButton")
        self.push_button_profile_save.setObjectName("secondaryActionButton")
        self.push_button_clear_profile_log.setObjectName("dangerActionButton")
        self.push_button_cancel_profile.setObjectName("dangerActionButton")
        self.push_button_cancel_profile.hide()
        profile_buttons = QHBoxLayout()
        profile_buttons.addWidget(self.push_button_profile_apply)
        profile_buttons.addWidget(self.push_button_profile_verify)
        profile_buttons.addWidget(self.push_button_profile_save)
        profile_buttons.addWidget(self.push_button_clear_profile_log)
        profile_buttons.addWidget(self.push_button_cancel_profile)
        profile_buttons.addStretch(1)
        self.profile_log_text_edit = QTextEdit()
        self.profile_log_text_edit.setObjectName("profileLogText")
        self.profile_log_text_edit.setReadOnly(True)
        profile_tab = QWidget()
        profile_layout = QVBoxLayout(profile_tab)
        profile_layout.addWidget(QLabel("Profile CSV"))
        profile_layout.addLayout(csv_row)
        profile_layout.addWidget(self.check_box_apply_profile_to_all_similar_device_ids)
        profile_layout.addLayout(profile_buttons)
        profile_layout.addWidget(QLabel("Profile result"))
        profile_layout.addWidget(self.profile_log_text_edit, stretch=1)

        # ----- device commands -----
        self.commands_tree_widget = QTreeWidget()
        self.commands_tree_widget.setColumnCount(3)
        self.commands_tree_widget.setHeaderLabels(["Name", "ModbusAddr", "DataType"])
        self.commands_tree_widget.setUniformRowHeights(True)
        self.commands_tree_widget.setAlternatingRowColors(True)
        self.commands_tree_widget.setSelectionBehavior(
            QAbstractItemView.SelectionBehavior.SelectRows
        )
        self.push_button_execute_selected_command = QPushButton(
            "Execute selected command"
        )
        self.push_button_execute_selected_command.setObjectName("primaryActionButton")
        self.check_box_execute_command_on_all_similar_device_ids = QCheckBox(
            "Apply to all same devices"
        )
        self.check_box_execute_command_on_all_similar_device_ids.setToolTip(
            "Execute on every compatible discovered device of this type."
        )
        self.push_button_clear_command_log = QPushButton("Clear Log")
        self.push_button_clear_command_log.setObjectName("dangerActionButton")
        self.commands_log_text_edit = QTextEdit()
        self.commands_log_text_edit.setObjectName("commandLogText")
        self.commands_log_text_edit.setReadOnly(True)
        self.commands_log_text_edit.setMaximumHeight(160)
        commands_tab = QWidget()
        commands_layout = QVBoxLayout(commands_tab)
        commands_layout.addWidget(
            QLabel("COMMAND parameters — execution uses execute-command")
        )
        commands_layout.addWidget(self.commands_tree_widget, stretch=1)
        commands_layout.addWidget(
            self.check_box_execute_command_on_all_similar_device_ids
        )
        command_buttons = QHBoxLayout()
        command_buttons.addWidget(self.push_button_execute_selected_command)
        command_buttons.addWidget(self.push_button_clear_command_log)
        command_buttons.addStretch(1)
        commands_layout.addLayout(command_buttons)
        commands_layout.addWidget(self.commands_log_text_edit)

        self.center_tab_widget = QTabWidget()
        self.center_tab_widget.addTab(parameters_tab, "Device Properties")
        self.center_tab_widget.addTab(monitoring_tab, "Monitoring")
        self.center_tab_widget.addTab(profile_tab, "Profile")
        self.center_tab_widget.addTab(commands_tab, "Commands")
        self.center_tab_widget.addTab(self.cli_console_panel, "CLI")

        center_container = QWidget()
        center_layout = QVBoxLayout(center_container)
        center_layout.setContentsMargins(4, 4, 4, 4)
        center_layout.addLayout(toolbar)
        center_layout.addWidget(monitoring_box)
        settings_load_progress_layout = QHBoxLayout()
        settings_load_progress_layout.addWidget(self.push_button_cancel_settings_load)
        center_layout.addLayout(settings_load_progress_layout)
        center_layout.addWidget(self.center_tab_widget, stretch=1)

        self.status_log_text_edit = QTextEdit()
        self.status_log_text_edit.setObjectName("reportLogText")
        self.status_log_text_edit.setReadOnly(True)
        right_container = QWidget()
        right_container.setObjectName("reportLogPanel")
        right_container.setMinimumWidth(280)
        right_container.setMaximumWidth(390)
        right_layout = QVBoxLayout(right_container)
        right_layout.setContentsMargins(4, 4, 4, 4)
        right_header = QHBoxLayout()
        right_header.addWidget(QLabel("Report Log"))
        right_header.addStretch(1)
        self.push_button_clear_status_log = QPushButton("Clear")
        self.push_button_clear_status_log.setObjectName("dangerActionButton")
        right_header.addWidget(self.push_button_clear_status_log)
        right_layout.addLayout(right_header)
        detailed_log_hint = QLabel(
            "Operator messages are shown here. Full technical output is in the CLI tab."
        )
        detailed_log_hint.setWordWrap(True)
        detailed_log_hint.setStyleSheet("QLabel { color: #555555; }")
        right_layout.addWidget(detailed_log_hint)
        right_layout.addWidget(self.status_log_text_edit, stretch=1)

        splitter = QSplitter(Qt.Orientation.Horizontal)
        splitter.addWidget(left_container)
        splitter.addWidget(center_container)
        splitter.addWidget(right_container)
        splitter.setStretchFactor(0, 1)
        splitter.setStretchFactor(1, 1)
        splitter.setStretchFactor(2, 0)
        splitter.setCollapsible(0, True)
        splitter.setSizes([self._LEFT_PANEL_WIDTH_PIXELS, 750, 340])
        self.setCentralWidget(splitter)

        self.left_tab_widget.setTabText(0, "Communication")

    @staticmethod
    def _device_info_value_label() -> QLabel:
        label = QLabel("—")
        label.setObjectName("deviceInfoValue")
        label.setTextInteractionFlags(Qt.TextInteractionFlag.TextSelectableByMouse)
        return label

    def _build_status_bar(self) -> None:
        status = self.statusBar()
        status.setSizeGripEnabled(False)
        self.global_progress_container = QWidget()
        self.global_progress_container.setObjectName("globalProgressContainer")
        self.global_progress_container.setFixedSize(380, 34)
        progress_layout = QGridLayout(self.global_progress_container)
        progress_layout.setContentsMargins(3, 3, 5, 3)
        self.progress_bar_global = QProgressBar()
        self.progress_bar_global.setObjectName("globalOperationProgress")
        self.progress_bar_global.setRange(0, 100)
        self.progress_bar_global.setValue(0)
        self.progress_bar_global.setFormat("")
        self.progress_bar_global.hide()
        self.label_global_operation = QLabel("")
        self.label_global_operation.setObjectName("globalOperationLabel")
        self.label_global_operation.setAlignment(Qt.AlignmentFlag.AlignCenter)
        self.label_global_operation.setAttribute(
            Qt.WidgetAttribute.WA_TransparentForMouseEvents
        )
        self.label_global_operation.hide()
        progress_layout.addWidget(self.progress_bar_global, 0, 0)
        progress_layout.addWidget(self.label_global_operation, 0, 0)
        self.label_status_connection = QLabel("Modbus Connection")
        self.label_status_identification = QLabel("Identification")
        self.label_status_device_id = QLabel("File DeviceID: None")
        self.label_status_serial_no = QLabel("File SerialNo: None")
        self.label_status_connection.setFixedWidth(135)
        self.label_status_identification.setFixedWidth(105)
        self.label_status_device_id.setFixedWidth(145)
        self.label_status_serial_no.setFixedWidth(145)
        status.addWidget(self.global_progress_container)
        for label in (
            self.label_status_connection,
            self.label_status_identification,
            self.label_status_device_id,
            self.label_status_serial_no,
        ):
            label.setObjectName("statusSegment")
            status.addWidget(label)
        status.addPermanentWidget(QLabel("CLI-driven"))
        self._set_status_segment(self.label_status_connection, _STATUS_ERROR_COLOR)
        self._set_status_segment(self.label_status_identification, _STATUS_IDLE_COLOR)
        self._set_status_segment(self.label_status_device_id, _STATUS_ERROR_COLOR)
        self._set_status_segment(self.label_status_serial_no, _STATUS_ERROR_COLOR)

    @staticmethod
    def _set_status_segment(label: QLabel, background_color: str) -> None:
        label.setStyleSheet(
            "QLabel {"
            f"background-color: {background_color};"
            "border: 1px solid #b8bec7; border-radius: 3px; "
            "padding: 1px 8px; margin: 1px 0 1px 2px;"
            "}"
        )

    @staticmethod
    def _style_tree_group_item(item: QTreeWidgetItem, column_count: int) -> None:
        """Give Tag2/category rows the compact blue legacy section style."""
        font = item.font(0)
        font.setBold(True)
        for column in range(column_count):
            item.setFont(column, font)
            item.setBackground(column, QBrush(QColor("#edf3fa")))
            item.setForeground(column, QBrush(QColor("#17334f")))

    @staticmethod
    def _style_unconnected_port_item(item: QTreeWidgetItem, column_count: int) -> None:
        font = item.font(0)
        font.setItalic(True)
        muted_foreground = QBrush(QColor("#8b929b"))
        for column in range(column_count):
            item.setForeground(column, muted_foreground)
            item.setFont(column, font)
        item.setToolTip(
            0,
            "The device did not answer on this downstream port during Identify.",
        )

    @staticmethod
    def _style_missing_parameter_list_item(
        item: QTreeWidgetItem,
        column_count: int,
        *,
        parameter_list_version: object,
        error: object = None,
    ) -> None:
        font = item.font(0)
        font.setBold(True)
        foreground = QBrush(QColor("#9f1d27"))
        background = QBrush(QColor("#fde3e5"))
        for column in range(column_count):
            item.setForeground(column, foreground)
            item.setBackground(column, background)
            item.setFont(column, font)
        tooltip = (
            f"Parameter-list version {parameter_list_version} is not available. "
            "This device cannot be opened."
        )
        if error:
            tooltip += f"\n{error}"
        item.setToolTip(0, tooltip)

    def _connect_signals(self) -> None:
        self.cli_console_panel.busy_changed.connect(self._on_cli_busy_changed)
        self.cli_console_panel.session_ready.connect(self._on_session_ready)
        self.cli_console_panel.command_completed.connect(
            self._on_any_cli_command_completed
        )
        self.cli_console_panel.session_event_received.connect(
            self._on_live_session_event
        )
        self.cli_console_panel.event_watcher_ready.connect(self._on_event_watcher_ready)
        self.cli_console_panel.event_watcher_error.connect(self._on_event_watcher_error)
        self.cli_console_panel.event_watcher_finished.connect(
            self._on_event_watcher_finished
        )
        self.communication_settings_panel.refresh_serial_ports_requested.connect(
            self._refresh_serial_ports
        )
        self.communication_settings_panel.refresh_networks_requested.connect(
            self._refresh_networks
        )
        self.push_button_connection_toggle.clicked.connect(
            self._on_connection_toggle_clicked
        )
        self.push_button_run_identify.clicked.connect(self._on_identify_clicked)
        self.push_button_cancel_identify.clicked.connect(
            self._on_cancel_identify_clicked
        )
        self.push_button_reload_settings_tree.clicked.connect(
            self._on_reload_settings_clicked
        )
        self.push_button_cancel_settings_load.clicked.connect(
            lambda: self._request_operation_cancel("parameter loading")
        )
        self.devices_topology_tree_widget.itemDoubleClicked.connect(
            self._on_topology_item_double_clicked
        )
        self.settings_tree_widget.itemDoubleClicked.connect(
            self._on_setting_item_double_clicked
        )
        self.settings_tree_widget.itemChanged.connect(self._on_setting_item_changed)
        self.settings_tree_widget.currentItemChanged.connect(
            self._on_setting_current_item_changed
        )
        self.line_edit_settings_filter.textChanged.connect(self._filter_settings_tree)
        self.push_button_copy_setting_name.clicked.connect(
            self._copy_selected_setting_name
        )
        self.push_button_periodic_monitoring_read.toggled.connect(
            self._on_periodic_monitoring_toggled
        )
        self.push_button_toggle_all_monitoring_parameters.clicked.connect(
            self._on_toggle_all_monitoring_parameters_clicked
        )
        self.monitoring_parameters_tree_widget.itemChanged.connect(
            self._on_monitoring_item_changed
        )
        self.line_edit_monitoring_filter.textChanged.connect(
            self._filter_monitoring_tree
        )
        self.center_tab_widget.currentChanged.connect(self._on_center_tab_changed)
        self.push_button_browse_profile_csv.clicked.connect(self._browse_profile)
        self.push_button_profile_apply.clicked.connect(
            lambda: self._run_profile("apply-profile")
        )
        self.push_button_profile_verify.clicked.connect(
            lambda: self._run_profile("verify-profile")
        )
        self.push_button_profile_save.clicked.connect(self._save_profile)
        self.push_button_clear_profile_log.clicked.connect(
            self.profile_log_text_edit.clear
        )
        self.push_button_cancel_profile.clicked.connect(
            lambda: self._request_operation_cancel("profile operation")
        )
        self.push_button_execute_selected_command.clicked.connect(
            self._execute_selected_device_command
        )
        self.commands_tree_widget.itemDoubleClicked.connect(
            lambda _item, _column: self._execute_selected_device_command()
        )
        self.commands_tree_widget.currentItemChanged.connect(
            self._on_selected_device_command_changed
        )
        self.push_button_clear_command_log.clicked.connect(
            self.commands_log_text_edit.clear
        )
        self.push_button_clear_status_log.clicked.connect(
            self.status_log_text_edit.clear
        )

    # ----- generic command/state handling -----

    def _execute(
        self,
        command_name: str,
        arguments: list[str] | None = None,
        callback=None,
        *,
        report_log: bool = True,
    ) -> bool:
        try:
            visible = self.cli_console_panel.build_session_command(
                command_name, *(arguments or [])
            )
        except ValueError as exc:
            QMessageBox.warning(self, "CLI", str(exc))
            return False
        if report_log:
            self._append_log(f"Running {command_name}...")
        return self.cli_console_panel.execute_session_command(
            command_name,
            arguments,
            callback,
            echo_output=report_log,
        )

    def _execute_with_live_progress(
        self,
        command_name: str,
        arguments: list[str] | None = None,
        callback=None,
        *,
        indeterminate: bool = False,
        operation_label: str | None = None,
        report_log: bool = True,
    ) -> bool:
        """Start the event watcher first, then run one long CLI command."""
        if self._pending_watched_command is not None:
            QMessageBox.information(
                self, "Operation in progress", "Another live operation is starting."
            )
            return False
        arguments = list(arguments or [])
        label = operation_label or command_name
        self._pending_watched_command = (
            command_name,
            arguments,
            callback,
            report_log,
            label,
            indeterminate,
        )
        self._begin_global_progress(command_name, label, indeterminate=indeterminate)
        if self.cli_console_panel.start_session_event_watcher(command_name):
            return True
        self._pending_watched_command = None
        self._finish_global_progress(command_name, ok=False, message="Could not start")
        return False

    def _begin_global_progress(
        self, command_name: str, message: str, *, indeterminate: bool
    ) -> None:
        self._global_progress_generation += 1
        self._global_progress_command = command_name
        self._set_global_progress_text(message)
        self.label_global_operation.show()
        if indeterminate:
            self.progress_bar_global.setRange(0, 0)
        else:
            self.progress_bar_global.setRange(0, 100)
            self.progress_bar_global.setValue(0)
        self.progress_bar_global.setFormat("")
        self.progress_bar_global.show()

    def _set_global_progress_text(
        self, message: str, percent: int | None = None
    ) -> None:
        text = str(message or "Working...").strip()
        if percent is not None:
            text = f"{text} — {percent}%"
        text = self.label_global_operation.fontMetrics().elidedText(
            text,
            Qt.TextElideMode.ElideRight,
            350,
        )
        self.label_global_operation.setText(text)

    def _update_global_progress(
        self,
        command_name: str,
        message: str,
        *,
        current: int | None = None,
        total: int | None = None,
    ) -> None:
        if self._global_progress_command != command_name:
            return
        if current is None or total is None or total <= 0:
            self.progress_bar_global.setRange(0, 0)
            self._set_global_progress_text(message)
            return
        percent = max(0, min(100, round(100 * current / total)))
        self.progress_bar_global.setRange(0, 100)
        self.progress_bar_global.setFormat("")
        self.progress_bar_global.setValue(percent)
        self._set_global_progress_text(message, percent)

    def _finish_global_progress(
        self, command_name: str, *, ok: bool, message: str | None = None
    ) -> None:
        if self._global_progress_command != command_name:
            return
        self.progress_bar_global.setRange(0, 100)
        self.progress_bar_global.setValue(100 if ok else self.progress_bar_global.value())
        self.progress_bar_global.setFormat("")
        self._set_global_progress_text(
            message or (f"{command_name} completed" if ok else f"{command_name} failed"),
            100 if ok else None,
        )
        generation = self._global_progress_generation

        def hide_if_still_current() -> None:
            if generation != self._global_progress_generation:
                return
            self.progress_bar_global.hide()
            self.label_global_operation.hide()
            self._global_progress_command = None

        QTimer.singleShot(1800, hide_if_still_current)

    def _on_cli_busy_changed(self, busy: bool) -> None:
        self._cli_busy = busy
        self._update_action_states()
        if not busy:
            if self._pending_device_slave_id is not None:
                slave_id = self._pending_device_slave_id
                self._pending_device_slave_id = None
                QTimer.singleShot(0, lambda: self._select_and_load_device(slave_id))
                return
            self._schedule_next_monitoring_read()

    def _on_session_ready(self, session_name: str) -> None:
        self._session_ready_flag = True
        self._append_log(f"CLI session ready: {session_name}", success=True)
        self._refresh_serial_ports(lambda _payload, _code: self._refresh_networks())

    def _on_any_cli_command_completed(
        self, command_text: str, exit_code: int, payload: object
    ) -> None:
        try:
            completed_command = parse_cli_invocation(command_text).command_name
        except ValueError:
            completed_command = ""
        if completed_command == "identify":
            self._identify_running = False
            self._identify_cancel_requested = False
            if exit_code == 0:
                self._set_status_segment(
                    self.label_status_identification, _STATUS_OK_COLOR
                )
            else:
                self._set_status_segment(
                    self.label_status_identification, _STATUS_ERROR_COLOR
                )
            self._update_action_states()
        elif completed_command in ("load-settings", "reload-settings"):
            self._settings_load_running = False
            self._operation_cancel_requested = False
            self._update_action_states()
        elif completed_command in ("apply-profile", "verify-profile", "save-profile"):
            self._profile_operation_running = False
            self._operation_cancel_requested = False
            self._update_action_states()

        ok = exit_code == 0
        if completed_command != "read-monitoring":
            self._append_log(
                f"{completed_command or 'Command'} "
                f"{'completed successfully' if ok else 'failed'}.",
                success=ok,
            )
        if not isinstance(payload, dict):
            if completed_command == self._global_progress_command:
                self._finish_global_progress(completed_command, ok=ok)
            return
        command = str(payload.get("command") or "")
        data = payload.get("data")
        data = data if isinstance(data, dict) else {}
        error = payload.get("error")
        if completed_command == self._global_progress_command:
            if data.get("requires_confirmation"):
                self.progress_bar_global.hide()
                self.label_global_operation.hide()
                self._global_progress_command = None
            else:
                self._finish_global_progress(completed_command, ok=ok)
        if command == "cancel":
            cancel_was_sent_to_running_command = bool(data.get("busy"))
            if not ok or not cancel_was_sent_to_running_command:
                self._identify_cancel_requested = False
                self._update_action_states()
        if error:
            self._append_log(str(error), success=False)

        if command == "connect" and ok:
            self._clear_loaded_device_state()
            self._set_connected_state(True)
        elif command == "disconnect" and ok:
            self._set_connected_state(False)
        elif command == "serve-stop" and ok:
            self._session_ready_flag = False
            self._set_connected_state(False)
        elif command == "status" and ok:
            self._set_connected_state(bool(data.get("connected")))
        elif command == "list-serial-ports" and ok:
            ports = data.get("ports")
            normalized_ports = []
            if isinstance(ports, list):
                for port in ports:
                    if isinstance(port, dict):
                        normalized_ports.append(port)
                    elif isinstance(port, str):
                        normalized_ports.append({"device": port, "description": ""})
            self.communication_settings_panel.set_available_serial_ports(
                normalized_ports
            )
        elif command == "list-networks" and ok:
            interfaces = data.get("interfaces")
            self.communication_settings_panel.set_available_network_interfaces(
                [item for item in interfaces if isinstance(item, dict)]
                if isinstance(interfaces, list)
                else []
            )
        elif command in ("identify", "show-topology"):
            root = data.get("root")
            if isinstance(root, dict):
                self._populate_topology(root)
                self.left_tab_widget.setCurrentIndex(1)
        elif command == "select-device" and ok:
            self._selected_slave_id = _optional_int(data.get("slave_id"))
            self.label_selected_device.setText(
                "Selected device: "
                f"{data.get('device_name') or '(unknown)'}  "
                f"SlaveId={data.get('slave_id')}  DeviceId={data.get('device_id', '—')}"
            )
        elif command in ("load-settings", "reload-settings") and ok:
            self._settings_loaded = True
            self._selected_slave_id = _optional_int(data.get("slave_id"))
            self._loaded_topology_slave_id = self._selected_slave_id
            loaded_item = self._refresh_loaded_topology_marker()
            if loaded_item is not None:
                self._animate_loaded_device_item(loaded_item)
            values = data.get("values")
            if isinstance(values, list):
                self._populate_settings(
                    [item for item in values if isinstance(item, dict)]
                )
            self.label_selected_device.setText(
                f"Selected device: {data.get('device_name', '(unknown)')}  "
                f"SlaveId={data.get('slave_id')}  DeviceId={data.get('device_id')}"
            )
            self.label_monitoring_device_name.setText(
                str(data.get("device_name") or "—")
            )
            self.label_status_device_id.setText(
                f"File DeviceID: {data.get('device_id', 'None')}"
            )
            self._set_status_segment(self.label_status_device_id, _STATUS_OK_COLOR)
        elif command == "get-monitoring-header" and ok:
            self._apply_monitoring_data(data)
        elif command == "list-commands" and ok:
            commands = data.get("commands")
            self._populate_device_commands(
                [item for item in commands if isinstance(item, dict)]
                if isinstance(commands, list)
                else []
            )
        elif command == "list-parameters" and ok:
            if data.get("parameter_type_filter") == "monitoring":
                parameters = data.get("parameters")
                self._populate_monitoring_parameters(
                    [item for item in parameters if isinstance(item, dict)]
                    if isinstance(parameters, list)
                    else []
                )
        elif command == "read-monitoring" and ok:
            values = data.get("values")
            self._apply_monitoring_read_values(
                [item for item in values if isinstance(item, dict)]
                if isinstance(values, list)
                else []
            )
        elif command in ("apply-profile", "verify-profile", "parse-profile"):
            if not data.get("requires_confirmation"):
                self._render_profile_result(command, data, ok, error)
        elif command == "save-profile":
            self._append_profile_log(
                f"{'SAVE OK' if ok else 'SAVE FAILED'}: "
                f"{data.get('file') or error}",
                success=ok,
            )
        elif command == "execute-command":
            if data.get("requires_confirmation"):
                self._append_command_log(
                    str(error or "Confirmation is required before execution."),
                    success=False,
                )
                self._update_action_states()
                return
            result_lines: list[str] = []
            targets = data.get("targets")
            if isinstance(targets, list):
                for target in targets:
                    if isinstance(target, dict):
                        line = (
                            f"SlaveId={target.get('slave_id')} "
                            f"{target.get('name')}: {target.get('message')}"
                        )
                        result_lines.append(line)
                        self._append_command_log(
                            line, success=bool(target.get("success"))
                        )
                for target in data.get("incompatible_targets", []):
                    if isinstance(target, dict):
                        self._append_command_log(
                            f"Skipped SlaveId={target.get('slave_id')} "
                            f"{target.get('name')}: {target.get('reason')}",
                            success=False,
                        )
                success_count = int(data.get("success_count") or 0)
                failure_count = int(data.get("failure_count") or 0)
                if failure_count:
                    dialog_text = (
                        f"Command succeeded on {success_count} device(s) and failed "
                        f"on {failure_count} device(s).\n\n"
                        "See the Command log for details."
                    )
                else:
                    dialog_text = (
                        f"Command applied successfully to {success_count} device(s)."
                    )
            else:
                line = str(data.get("message") or error or "No result")
                result_lines.append(line)
                self._append_command_log(line, success=ok)
                dialog_text = "\n".join(result_lines) or str(error or "No result")
            if ok:
                QMessageBox.information(
                    self,
                    "Command completed",
                    dialog_text,
                    QMessageBox.StandardButton.Ok,
                )
            else:
                QMessageBox.critical(
                    self, "Command failed", dialog_text, QMessageBox.StandardButton.Ok
                )
        self._update_action_states()

    # ----- discovery and connection -----

    def _refresh_serial_ports(self, callback=None) -> None:
        self._execute("list-serial-ports", callback=callback)

    def _refresh_networks(self, callback=None) -> None:
        self._execute("list-networks", callback=callback)

    def _on_connect_clicked(self) -> None:
        try:
            arguments = self.communication_settings_panel.connect_cli_arguments()
        except ValueError as exc:
            QMessageBox.warning(self, "Communication", str(exc))
            return
        self._execute("connect", arguments)

    def _on_disconnect_clicked(self) -> None:
        self._execute("disconnect")

    def _on_connection_toggle_clicked(self) -> None:
        if self._connected:
            self._on_disconnect_clicked()
        else:
            self._on_connect_clicked()

    def _set_connected_state(self, connected: bool) -> None:
        self._connected = connected
        self.push_button_connection_toggle.setText(
            "Disconnect" if connected else "Connect"
        )
        self.push_button_connection_toggle.setObjectName(
            "dangerActionButton" if connected else "primaryActionButton"
        )
        self.push_button_connection_toggle.style().unpolish(
            self.push_button_connection_toggle
        )
        self.push_button_connection_toggle.style().polish(
            self.push_button_connection_toggle
        )
        self._set_status_segment(
            self.label_status_connection,
            _STATUS_OK_COLOR if connected else _STATUS_ERROR_COLOR,
        )
        if not connected:
            self._settings_loaded = False
            self._selected_slave_id = None
            self._loaded_topology_slave_id = None
            self.settings_tree_widget.clear()
            self.commands_tree_widget.clear()
            self._clear_monitoring_parameter_table()
            self.label_selected_device.setText("Selected device: (none)")
            self._clear_monitoring()
        self._update_action_states()

    def _update_action_states(self) -> None:
        ready = self._session_ready_flag and not self._cli_busy
        self.push_button_connection_toggle.setEnabled(ready)
        self.push_button_run_identify.setEnabled(
            ready and self._connected and not self._identify_running
        )
        self.push_button_cancel_identify.setEnabled(
            self._session_ready_flag
            and self._identify_running
            and self._cli_busy
            and not self._identify_cancel_requested
        )
        self.push_button_cancel_identify.setText(
            "Cancelling..."
            if self._identify_running and self._identify_cancel_requested
            else "Cancel Identify"
        )
        self.push_button_cancel_identify.setVisible(self._identify_running)
        self.push_button_cancel_settings_load.setVisible(self._settings_load_running)
        self.push_button_cancel_settings_load.setEnabled(
            self._settings_load_running and not self._operation_cancel_requested
        )
        self.push_button_cancel_profile.setVisible(self._profile_operation_running)
        self.push_button_cancel_profile.setEnabled(
            self._profile_operation_running and not self._operation_cancel_requested
        )
        self.push_button_reload_settings_tree.setEnabled(ready and self._connected)
        self.line_edit_settings_filter.setEnabled(self._settings_loaded)
        current_setting_item = self.settings_tree_widget.currentItem()
        self.push_button_copy_setting_name.setEnabled(
            self._settings_loaded
            and current_setting_item is not None
            and current_setting_item.data(0, _ROLE_KIND) == "setting"
        )
        self.communication_settings_panel.setEnabled(ready and not self._connected)
        profile_ready = ready and self._connected and self._settings_loaded
        self.push_button_profile_apply.setEnabled(profile_ready)
        self.push_button_profile_verify.setEnabled(profile_ready)
        self.push_button_profile_save.setEnabled(profile_ready)
        self.push_button_execute_selected_command.setEnabled(
            profile_ready and self.commands_tree_widget.topLevelItemCount() > 0
        )
        self.push_button_periodic_monitoring_read.setEnabled(
            self._session_ready_flag
            and self._connected
            and self._settings_loaded
            and self._monitoring_device_ready
        )
        self.push_button_toggle_all_monitoring_parameters.setEnabled(
            self._session_ready_flag
            and self._connected
            and self._settings_loaded
            and self._monitoring_device_ready
            and bool(self._monitoring_items_by_parameter_id)
        )
        self.line_edit_monitoring_filter.setEnabled(
            self._settings_loaded and self._monitoring_device_ready
        )

    def _clear_loaded_device_state(self) -> None:
        self._settings_loaded = False
        self._selected_slave_id = None
        self._loaded_topology_slave_id = None
        self._loaded_profile_tag1_categories.clear()
        self.settings_tree_widget.clear()
        self.commands_tree_widget.clear()
        self._clear_monitoring_parameter_table()
        self.label_selected_device.setText("Selected device: (none)")
        self._clear_monitoring()

    # ----- topology -----

    def _on_identify_clicked(self) -> None:
        self._stop_device_discovery_animations()
        self.devices_topology_tree_widget.clear()
        self._live_identify_items.clear()
        self._live_identify_port_items.clear()
        self._clear_loaded_device_state()
        self._set_status_segment(self.label_status_identification, _STATUS_BUSY_COLOR)
        self._identify_running = True
        self._identify_cancel_requested = False
        self._update_action_states()
        if not self._execute_with_live_progress(
            "identify",
            indeterminate=True,
            operation_label="Preparing Identify...",
        ):
            self._identify_running = False
            self._update_action_states()

    def _on_event_watcher_ready(self, command_name: str) -> None:
        pending = self._pending_watched_command
        if pending is None or pending[0] != command_name:
            return
        (
            _command_name,
            arguments,
            callback,
            report_log,
            operation_label,
            _indeterminate,
        ) = pending
        self._pending_watched_command = None
        self._set_global_progress_text(operation_label)
        if command_name == "identify":
            self._update_global_progress("identify", "Identify starting")
        if not self._execute(
            command_name,
            arguments,
            callback,
            report_log=report_log,
        ):
            self.cli_console_panel.stop_session_event_watcher()
            self._finish_global_progress(
                command_name, ok=False, message=f"{operation_label} could not start"
            )
            if command_name == "identify":
                self._identify_running = False
            elif command_name in ("load-settings", "reload-settings"):
                self._settings_load_running = False
            elif command_name in (
                "apply-profile",
                "verify-profile",
                "save-profile",
            ):
                self._profile_operation_running = False
            self._update_action_states()

    def _on_event_watcher_finished(self, command_name: str, exit_code: int) -> None:
        pending = self._pending_watched_command
        if pending is not None and pending[0] == command_name:
            self._pending_watched_command = None
            self._finish_global_progress(
                command_name, ok=False, message="Live progress could not start"
            )
            if command_name == "identify":
                self._identify_running = False
            elif command_name in ("load-settings", "reload-settings"):
                self._settings_load_running = False
            elif command_name in (
                "apply-profile",
                "verify-profile",
                "save-profile",
            ):
                self._profile_operation_running = False
            self._update_action_states()
        if exit_code != 0:
            self._append_log(
                f"Live {command_name} events stopped with exit code {exit_code}.",
                success=False,
            )
            if command_name == "identify":
                self._set_status_segment(
                    self.label_status_identification, _STATUS_ERROR_COLOR
                )
        if command_name == "identify" and self._identify_running and not self._cli_busy:
            self._identify_running = False
            self._identify_cancel_requested = False
            self._update_action_states()

    def _on_event_watcher_error(self, message: str) -> None:
        self._append_log(f"Live event watcher error: {message}", success=False)

    def _on_live_session_event(self, event: object) -> None:
        if not isinstance(event, dict):
            return
        event_type = str(event.get("type") or "")
        message = str(event.get("message") or "")
        data = event.get("data")
        data = data if isinstance(data, dict) else {}

        if event_type == "operation_progress":
            operation = str(data.get("operation") or "")
            self._update_global_progress(
                operation,
                message,
                current=_optional_int(data.get("current")),
                total=_optional_int(data.get("total")),
            )

        # Low-level Modbus steps remain visible in the CLI tab. The right-hand
        # panel is deliberately limited to information useful to an operator.
        if message and event_type not in (
            "log",
            "command_started",
            "command_finished",
            "operation_progress",
            "port_scanning",
            "empty_port",
        ):
            success = None
            if event_type in (
                "identify_failed",
                "identify_cancelled",
                "parameter_list_missing",
            ) or (
                event_type == "device_discovered"
                and data.get("parameter_list_available") is False
            ):
                success = False
            elif event_type in ("device_discovered", "identify_finished"):
                success = True
            self._append_log(message, success=success)

        if event_type == "identify_started":
            self._update_global_progress("identify", "Identify running")
            self._set_status_segment(
                self.label_status_identification, _STATUS_BUSY_COLOR
            )
        elif event_type == "port_scanning":
            self._update_global_progress(
                "identify", f"Identify: port {data.get('port_index', '?')}"
            )
        elif event_type == "device_discovered":
            self._update_global_progress(
                "identify", f"Found: {data.get('device_name', 'device')}"
            )
            self._add_live_identified_device(data)
        elif event_type == "empty_port":
            self._update_global_progress(
                "identify", f"Empty port: {data.get('port_index', '?')}"
            )
            self._mark_live_empty_port(data)
        elif event_type == "cancel_requested":
            self._update_global_progress(
                "identify", "Cancelling Identify..."
            )
        elif event_type == "identify_cancelled":
            self._set_status_segment(
                self.label_status_identification, _STATUS_CANCELLED_COLOR
            )
        elif event_type == "identify_failed":
            self._set_status_segment(
                self.label_status_identification, _STATUS_ERROR_COLOR
            )
        elif event_type == "identify_finished":
            self._set_status_segment(self.label_status_identification, _STATUS_OK_COLOR)

    def _add_live_identified_device(self, data: dict[str, Any]) -> None:
        slave_id = _optional_int(data.get("slave_id"))
        if slave_id is None or slave_id in self._live_identify_items:
            return
        device_name = str(data.get("device_name") or "(unknown)")
        parameter_list_available = data.get("parameter_list_available") is not False
        port_index = _optional_int(data.get("port_index"))
        parent_slave_id = _optional_int(data.get("parent_slave_id"))
        label = (
            f"port[{port_index}]: {device_name}"
            if port_index is not None
            else device_name
        )
        if not parameter_list_available:
            label += " (parameter list unavailable)"
        item = QTreeWidgetItem(
            [
                label,
                str(slave_id),
                _display_or_empty(data.get("device_id")),
                _display_or_empty(data.get("parameter_list_version")),
                _display_or_empty(data.get("downstream_qty")),
            ]
        )
        parent_item = self._live_identify_items.get(parent_slave_id)
        if parent_item is None:
            self.devices_topology_tree_widget.addTopLevelItem(item)
        else:
            if port_index is not None and parent_slave_id is not None:
                port_key = (parent_slave_id, port_index)
                previous_port_item = self._live_identify_port_items.get(port_key)
                if previous_port_item is not None:
                    previous_index = parent_item.indexOfChild(previous_port_item)
                    if previous_index >= 0:
                        parent_item.takeChild(previous_index)
            parent_item.addChild(item)
            if port_index is not None and parent_slave_id is not None:
                self._live_identify_port_items[(parent_slave_id, port_index)] = item
        self._live_identify_items[slave_id] = item
        self.devices_topology_tree_widget.expandAll()
        self.devices_topology_tree_widget.scrollToItem(
            item, QAbstractItemView.ScrollHint.EnsureVisible
        )
        if parameter_list_available:
            self._animate_discovered_device_item(item)
        else:
            self._style_missing_parameter_list_item(
                item,
                self.devices_topology_tree_widget.columnCount(),
                parameter_list_version=data.get("parameter_list_version"),
                error=data.get("parameter_list_error"),
            )
        for column in range(self.devices_topology_tree_widget.columnCount()):
            self.devices_topology_tree_widget.resizeColumnToContents(column)

    def _mark_live_empty_port(self, data: dict[str, Any]) -> None:
        hub_slave_id = _optional_int(data.get("hub_slave_id"))
        port_index = _optional_int(data.get("port_index"))
        if hub_slave_id is None or port_index is None:
            return
        parent_item = self._live_identify_items.get(hub_slave_id)
        if parent_item is None:
            return

        port_key = (hub_slave_id, port_index)
        item = self._live_identify_port_items.get(port_key)
        if item is None:
            item = QTreeWidgetItem([f"port[{port_index}]:"])
            self._live_identify_port_items[port_key] = item
            parent_item.addChild(item)
        else:
            item.setText(0, f"port[{port_index}]:")

        self._style_unconnected_port_item(
            item, self.devices_topology_tree_widget.columnCount()
        )
        parent_item.setExpanded(True)
        self.devices_topology_tree_widget.scrollToItem(
            item, QAbstractItemView.ScrollHint.EnsureVisible
        )

    def _animate_discovered_device_item(self, item: QTreeWidgetItem) -> None:
        """Fade a newly discovered topology row into its normal appearance."""
        animation = QVariantAnimation(self)
        animation.setDuration(900)
        animation.setStartValue(QColor("#b9ddf5"))
        animation.setEndValue(QColor("#ffffff"))
        animation.setEasingCurve(QEasingCurve.Type.OutCubic)
        self._device_discovery_animations.add(animation)

        def update_row(background_color: QColor) -> None:
            progress = min(
                1.0,
                animation.currentTime() / max(1, animation.duration()),
            )
            foreground_color = QColor(
                round(255 + (32 - 255) * progress),
                round(255 + (36 - 255) * progress),
                round(255 + (42 - 255) * progress),
            )
            try:
                for column in range(self.devices_topology_tree_widget.columnCount()):
                    item.setBackground(column, QBrush(background_color))
                    item.setForeground(column, QBrush(foreground_color))
            except RuntimeError:
                animation.stop()

        def finish_row() -> None:
            try:
                for column in range(self.devices_topology_tree_widget.columnCount()):
                    item.setBackground(column, QBrush())
                    item.setForeground(column, QBrush())
            except RuntimeError:
                pass
            self._device_discovery_animations.discard(animation)
            animation.deleteLater()

        animation.valueChanged.connect(update_row)
        animation.finished.connect(finish_row)
        animation.start()

    def _stop_device_discovery_animations(self) -> None:
        for animation in tuple(self._device_discovery_animations):
            animation.stop()
            animation.deleteLater()
        self._device_discovery_animations.clear()

    def _on_cancel_identify_clicked(self) -> None:
        try:
            visible = self.cli_console_panel.build_session_command("cancel")
        except ValueError as exc:
            QMessageBox.warning(self, "Cancel Identify", str(exc))
            return
        self._append_log(f"> {visible}")
        if self.cli_console_panel.request_session_cancel():
            self._identify_cancel_requested = True
            self._update_global_progress("identify", "Cancelling Identify...")
            self._update_action_states()

    def _request_operation_cancel(self, operation_label: str) -> None:
        if self._operation_cancel_requested:
            return
        if self.cli_console_panel.request_session_cancel():
            self._operation_cancel_requested = True
            if self._settings_load_running:
                self._update_global_progress(
                    self._global_progress_command or "load-settings",
                    "Cancelling parameter loading...",
                )
            if self._profile_operation_running:
                self._append_profile_log(
                    f"Cancelling {operation_label}...", success=False
                )
            self._update_action_states()

    def _populate_topology(self, root: dict[str, Any]) -> None:
        self._stop_device_discovery_animations()
        self.devices_topology_tree_widget.clear()
        self._live_identify_items.clear()
        self._live_identify_port_items.clear()

        def make_device_item(node: dict[str, Any], label: str | None = None):
            name = str(node.get("device_name") or f"DeviceId={node.get('device_id')}")
            parameter_list_available = node.get("parameter_list_available") is not False
            display_label = label or name
            if not parameter_list_available:
                display_label += " (parameter list unavailable)"
            item = QTreeWidgetItem(
                [
                    display_label,
                    str(node.get("slave_id", "")),
                    str(node.get("device_id", "")),
                    str(node.get("parameter_list_version", "")),
                    str(node.get("downstream_qty", 0)),
                ]
            )
            item.setData(0, _ROLE_NODE, node)
            item.setData(0, _ROLE_TOPOLOGY_BASE_LABEL, display_label)
            for port in node.get("ports", []):
                if not isinstance(port, dict):
                    continue
                port_index = port.get("port_index")
                child = port.get("device")
                if port.get("connected") and isinstance(child, dict):
                    child_name = str(
                        child.get("device_name") or f"DeviceId={child.get('device_id')}"
                    )
                    item.addChild(
                        make_device_item(child, f"port[{port_index}]: {child_name}")
                    )
                else:
                    empty_port_item = QTreeWidgetItem([f"port[{port_index}]:"])
                    self._style_unconnected_port_item(
                        empty_port_item,
                        self.devices_topology_tree_widget.columnCount(),
                    )
                    item.addChild(empty_port_item)
            if not parameter_list_available:
                self._style_missing_parameter_list_item(
                    item,
                    self.devices_topology_tree_widget.columnCount(),
                    parameter_list_version=node.get("parameter_list_version"),
                    error=node.get("parameter_list_error"),
                )
            return item

        self.devices_topology_tree_widget.addTopLevelItem(make_device_item(root))
        self.devices_topology_tree_widget.expandAll()
        self._refresh_loaded_topology_marker()
        for column in range(5):
            self.devices_topology_tree_widget.resizeColumnToContents(column)

    def _refresh_loaded_topology_marker(self) -> QTreeWidgetItem | None:
        """Keep the loaded device visually distinct from the clicked row."""
        tree = self.devices_topology_tree_widget
        iterator = tree.invisibleRootItem()
        active_item: QTreeWidgetItem | None = None

        def update_children(parent: QTreeWidgetItem) -> None:
            nonlocal active_item
            for index in range(parent.childCount()):
                item = parent.child(index)
                node = item.data(0, _ROLE_NODE)
                base_label = item.data(0, _ROLE_TOPOLOGY_BASE_LABEL)
                if isinstance(node, dict) and isinstance(base_label, str):
                    if node.get("parameter_list_available") is False:
                        item.setText(0, base_label)
                        self._style_missing_parameter_list_item(
                            item,
                            tree.columnCount(),
                            parameter_list_version=node.get("parameter_list_version"),
                            error=node.get("parameter_list_error"),
                        )
                        update_children(item)
                        continue
                    active = (
                        _optional_int(node.get("slave_id"))
                        == self._loaded_topology_slave_id
                    )
                    if active:
                        active_item = item
                    item.setText(0, f"● {base_label}" if active else base_label)
                    font = item.font(0)
                    font.setBold(active)
                    for column in range(tree.columnCount()):
                        item.setFont(column, font)
                        item.setBackground(
                            column,
                            QBrush(QColor("#d7f0d0")) if active else QBrush(),
                        )
                        item.setForeground(
                            column,
                            QBrush(QColor("#153d20")) if active else QBrush(),
                        )
                update_children(item)

        update_children(iterator)
        return active_item

    def _animate_loaded_device_item(self, item: QTreeWidgetItem) -> None:
        """Briefly highlight the device whose data has just been loaded."""
        animation = QVariantAnimation(self)
        animation.setDuration(650)
        animation.setStartValue(QColor("#8fc5eb"))
        animation.setEndValue(QColor("#d7f0d0"))
        animation.setEasingCurve(QEasingCurve.Type.OutCubic)
        self._device_discovery_animations.add(animation)

        def update_row(background_color: QColor) -> None:
            try:
                for column in range(self.devices_topology_tree_widget.columnCount()):
                    item.setBackground(column, QBrush(background_color))
                    item.setForeground(column, QBrush(QColor("#153d20")))
            except RuntimeError:
                animation.stop()

        def finish_row() -> None:
            try:
                for column in range(self.devices_topology_tree_widget.columnCount()):
                    item.setBackground(column, QBrush(QColor("#d7f0d0")))
                    item.setForeground(column, QBrush(QColor("#153d20")))
            except RuntimeError:
                pass
            self._device_discovery_animations.discard(animation)
            animation.deleteLater()

        animation.valueChanged.connect(update_row)
        animation.finished.connect(finish_row)
        animation.start()

    def _on_topology_item_double_clicked(
        self, item: QTreeWidgetItem, _column: int
    ) -> None:
        node = item.data(0, _ROLE_NODE)
        if not isinstance(node, dict):
            return
        if not self._connected:
            QMessageBox.warning(
                self,
                "Device is disconnected",
                "Connect to the device network before loading this device.",
            )
            return
        if node.get("parameter_list_available") is False:
            QMessageBox.warning(
                self,
                "Parameter List Unavailable",
                (
                    f"{node.get('device_name', 'This device')} was identified, "
                    f"but parameter-list version "
                    f"{node.get('parameter_list_version')} is not available.\n\n"
                    "The device cannot be opened until the matching CodeGen "
                    "JSON package is installed."
                ),
            )
            return
        slave_id = _optional_int(node.get("slave_id"))
        if slave_id is None:
            return

        self._stop_periodic_monitoring("Monitoring stopped for device change.")
        if self._cli_busy:
            self._pending_device_slave_id = slave_id
            self._append_log(
                f"Waiting for the current read before loading SlaveId={slave_id}."
            )
            return
        self._select_and_load_device(slave_id)

    def _select_and_load_device(self, slave_id: int) -> None:
        if not self._connected:
            QMessageBox.warning(
                self,
                "Device is disconnected",
                "Connect to the device network before loading this device.",
            )
            return

        def after_select(_payload, exit_code: int) -> None:
            if exit_code == 0:
                self._load_settings(slave_id=slave_id)

        self._execute("select-device", ["--slave-id", str(slave_id)], after_select)

    # ----- settings -----

    def _on_reload_settings_clicked(self) -> None:
        self._load_settings(reload=True)

    def _load_settings(
        self, *, slave_id: int | None = None, reload: bool = False
    ) -> None:
        command = "reload-settings" if reload else "load-settings"
        if (
            slave_id is not None
            and self._loaded_topology_slave_id is not None
            and slave_id != self._loaded_topology_slave_id
        ):
            self._monitoring_selected_parameter_ids.clear()
        arguments = ["--dump-values"]
        if slave_id is not None:
            arguments.extend(["--slave-id", str(slave_id)])
        self._settings_load_running = True
        self._operation_cancel_requested = False
        self._update_action_states()
        self._stop_periodic_monitoring("Monitoring stopped for device load.")
        self._clear_monitoring_parameter_table()

        def after_load(_payload, exit_code: int) -> None:
            self._settings_load_running = False
            self._operation_cancel_requested = False
            self._update_action_states()
            if exit_code != 0:
                return

            def after_header(_payload2, _exit_code2: int) -> None:
                def after_commands(_payload3, _exit_code3: int) -> None:
                    self._execute(
                        "list-parameters",
                        ["--type", "monitoring"],
                    )

                self._execute("list-commands", callback=after_commands)

            header_args = (
                ["--slave-id", str(self._selected_slave_id)]
                if self._selected_slave_id is not None
                else []
            )
            self._execute("get-monitoring-header", header_args, after_header)

        if not self._execute_with_live_progress(
            command,
            arguments,
            after_load,
            operation_label="Loading device settings...",
        ):
            self._settings_load_running = False
            self._operation_cancel_requested = False
            self._update_action_states()

    def _populate_settings(self, values: list[dict[str, Any]]) -> None:
        self._suppress_setting_change = True
        try:
            self.settings_tree_widget.clear()
            self._loaded_profile_tag1_categories = sorted(
                {
                    str(value.get("tag1") or "")
                    for value in values
                    if isinstance(value, dict)
                },
                key=lambda value: (not value, value.casefold()),
            )
            categories: dict[str, QTreeWidgetItem] = {}
            branches: dict[tuple[str, tuple[str, ...]], QTreeWidgetItem] = {}
            for value in values:
                category = str(value.get("tag2") or "").strip() or "(No Tag2)"
                category_item = categories.get(category)
                if category_item is None:
                    category_item = QTreeWidgetItem([category])
                    self._style_tree_group_item(
                        category_item, self.settings_tree_widget.columnCount()
                    )
                    categories[category] = category_item
                    self.settings_tree_widget.addTopLevelItem(category_item)

                raw_segments = value.get("name_path_segments")
                segments = (
                    [str(part) for part in raw_segments if str(part)]
                    if isinstance(raw_segments, list)
                    else []
                )
                name = str(value.get("name") or "(unnamed)")
                if not segments:
                    segments = [name]
                parent = category_item
                path: tuple[str, ...] = ()
                for segment in segments[:-1]:
                    path += (segment,)
                    key = (category, path)
                    branch = branches.get(key)
                    if branch is None:
                        branch = QTreeWidgetItem([segment])
                        branches[key] = branch
                        parent.addChild(branch)
                    parent = branch

                raw_value = value.get("value")
                display = "" if raw_value is None else str(raw_value)
                if value.get("error"):
                    display = f"ERROR: {value['error']}"
                leaf = QTreeWidgetItem(
                    [
                        segments[-1],
                        display,
                        str(value.get("data_type") or ""),
                        _display_or_empty(value.get("modbus_addr")),
                    ]
                )
                leaf.setFlags(
                    leaf.flags()
                    | Qt.ItemFlag.ItemIsEditable
                    | Qt.ItemFlag.ItemIsEnabled
                    | Qt.ItemFlag.ItemIsSelectable
                )
                leaf.setData(0, _ROLE_KIND, "setting")
                leaf.setData(0, _ROLE_NAME, name)
                leaf.setData(0, _ROLE_LAST_VALUE, display)
                parent.addChild(leaf)
            self.settings_tree_widget.expandToDepth(0)
            self.settings_tree_widget.setColumnWidth(0, 420)
            self.settings_tree_widget.setColumnWidth(1, 160)
            self.settings_tree_widget.setColumnWidth(2, 75)
            self._filter_settings_tree(self.line_edit_settings_filter.text())
        finally:
            self._suppress_setting_change = False

    def _filter_settings_tree(self, filter_text: str) -> None:
        """Show setting leaves whose complete parameter name contains the text."""
        query = str(filter_text or "").strip().casefold()

        def update_item_visibility(item: QTreeWidgetItem) -> bool:
            if item.data(0, _ROLE_KIND) == "setting":
                parameter_name = str(item.data(0, _ROLE_NAME) or item.text(0) or "")
                visible = not query or query in parameter_name.casefold()
            else:
                visible = False
                for index in range(item.childCount()):
                    if update_item_visibility(item.child(index)):
                        visible = True

            item.setHidden(not visible)
            if query and visible and item.data(0, _ROLE_KIND) != "setting":
                item.setExpanded(True)
            return visible

        for index in range(self.settings_tree_widget.topLevelItemCount()):
            update_item_visibility(self.settings_tree_widget.topLevelItem(index))

    def _on_setting_current_item_changed(
        self,
        current: QTreeWidgetItem | None,
        _previous: QTreeWidgetItem | None,
    ) -> None:
        self.push_button_copy_setting_name.setEnabled(
            self._settings_loaded
            and current is not None
            and current.data(0, _ROLE_KIND) == "setting"
        )

    def _copy_selected_setting_name(self) -> None:
        item = self.settings_tree_widget.currentItem()
        if item is None or item.data(0, _ROLE_KIND) != "setting":
            return
        name = str(item.data(0, _ROLE_NAME) or "").strip()
        if not name:
            return
        QGuiApplication.clipboard().setText(name)
        self._append_log(f"Copied parameter name: {name}", success=True)

    def _on_setting_item_double_clicked(
        self, item: QTreeWidgetItem, column: int
    ) -> None:
        if (
            column == 1
            and item.data(0, _ROLE_KIND) == "setting"
            and self._connected
            and not self._cli_busy
        ):
            self.settings_tree_widget.editItem(item, 1)

    def _on_setting_item_changed(self, item: QTreeWidgetItem, column: int) -> None:
        if self._suppress_setting_change or column != 1:
            return
        if item.data(0, _ROLE_KIND) != "setting":
            return
        name = str(item.data(0, _ROLE_NAME) or "")
        previous = str(item.data(0, _ROLE_LAST_VALUE) or "")
        new_value = item.text(1).strip()
        if not name or new_value == previous:
            return

        def restore(text: str) -> None:
            self._suppress_setting_change = True
            try:
                item.setText(1, text)
                item.setData(0, _ROLE_LAST_VALUE, text)
            finally:
                self._suppress_setting_change = False

        def after_set(payload, exit_code: int) -> None:
            if exit_code != 0 or not isinstance(payload, dict):
                restore(previous)
                QMessageBox.warning(
                    self,
                    "set-parameter failed",
                    str(
                        payload.get("error")
                        if isinstance(payload, dict)
                        else "No result"
                    ),
                )
                return
            data = payload.get("data")
            display = (
                str(data.get("display"))
                if isinstance(data, dict) and data.get("display") is not None
                else new_value
            )
            restore(display)

        if not self._execute(
            "set-parameter", ["--name", name, "--value", new_value], after_set
        ):
            restore(previous)

    def _apply_monitoring_data(self, data: dict[str, Any]) -> None:
        self.label_monitoring_slave_id.setText(str(data.get("slave_id", "—")))
        self.label_monitoring_device_id.setText(str(data.get("device_id", "—")))
        self.label_monitoring_serial_no.setText(str(data.get("serial_number") or "—"))
        self.label_monitoring_hardware_version.setText(
            str(data.get("hardware_version") or "—")
        )
        self.label_monitoring_firmware_version.setText(
            str(data.get("firmware_version") or "—")
        )
        serial_number = data.get("serial_number")
        self.label_status_serial_no.setText(
            f"File SerialNo: {serial_number if serial_number is not None else 'None'}"
        )
        self._set_status_segment(
            self.label_status_serial_no,
            _STATUS_OK_COLOR if serial_number is not None else _STATUS_ERROR_COLOR,
        )

    def _clear_monitoring(self) -> None:
        for label in (
            self.label_monitoring_slave_id,
            self.label_monitoring_device_id,
            self.label_monitoring_serial_no,
            self.label_monitoring_hardware_version,
            self.label_monitoring_firmware_version,
            self.label_monitoring_device_name,
        ):
            label.setText("—")
        self.label_status_device_id.setText("File DeviceID: None")
        self.label_status_serial_no.setText("File SerialNo: None")
        self._set_status_segment(self.label_status_device_id, _STATUS_ERROR_COLOR)
        self._set_status_segment(self.label_status_serial_no, _STATUS_ERROR_COLOR)

    # ----- periodic monitoring -----

    def _clear_monitoring_parameter_table(self) -> None:
        if self.push_button_periodic_monitoring_read.isChecked():
            self.push_button_periodic_monitoring_read.setChecked(False)
        self._monitoring_device_ready = False
        self._monitoring_read_scheduled = False
        self._monitoring_read_in_flight = False
        self._monitoring_next_parameter_index = 0
        self._suppress_monitoring_item_change = True
        try:
            self.monitoring_parameters_tree_widget.clear()
            self._monitoring_items_by_parameter_id.clear()
        finally:
            self._suppress_monitoring_item_change = False
        self._update_monitoring_selection_summary()
        self._update_monitoring_selection_button()

    def _populate_monitoring_parameters(self, parameters: list[dict[str, Any]]) -> None:
        tree = self.monitoring_parameters_tree_widget
        updates_were_enabled = tree.updatesEnabled()
        tree.setUpdatesEnabled(False)
        self._suppress_monitoring_item_change = True
        try:
            tree.clear()
            self._monitoring_items_by_parameter_id.clear()
            categories: dict[str, QTreeWidgetItem] = {}
            branches: dict[tuple[str, tuple[str, ...]], QTreeWidgetItem] = {}
            for parameter in parameters:
                parameter_id = _optional_int(parameter.get("parameter_id"))
                if parameter_id is None:
                    continue

                category = str(parameter.get("tag2") or "").strip() or "(No Tag2)"
                category_item = categories.get(category)
                if category_item is None:
                    category_item = QTreeWidgetItem([category])
                    category_item.setData(0, _ROLE_KIND, "monitoring_category")
                    self._style_tree_group_item(category_item, tree.columnCount())
                    categories[category] = category_item
                    tree.addTopLevelItem(category_item)

                raw_segments = parameter.get("name_path_segments")
                name = str(parameter.get("name") or "(unnamed)")
                segments = (
                    [str(part) for part in raw_segments if str(part)]
                    if isinstance(raw_segments, list)
                    else []
                )
                if not segments:
                    segments = _parameter_name_path_segments(name)

                parent = category_item
                path: tuple[str, ...] = ()
                for segment in segments[:-1]:
                    path += (segment,)
                    key = (category, path)
                    branch = branches.get(key)
                    if branch is None:
                        branch = QTreeWidgetItem([segment])
                        branch.setData(0, _ROLE_KIND, "monitoring_branch")
                        branches[key] = branch
                        parent.addChild(branch)
                    parent = branch

                item = QTreeWidgetItem(
                    [
                        segments[-1],
                        "",
                        "",
                        str(parameter.get("data_type") or ""),
                        _display_or_empty(parameter.get("modbus_addr")),
                    ]
                )
                item.setFlags(
                    item.flags()
                    | Qt.ItemFlag.ItemIsUserCheckable
                    | Qt.ItemFlag.ItemIsEnabled
                    | Qt.ItemFlag.ItemIsSelectable
                )
                item.setData(0, _ROLE_PARAMETER_ID, parameter_id)
                item.setData(0, _ROLE_KIND, "monitoring_parameter")
                item.setData(0, _ROLE_NAME, name)
                item.setCheckState(
                    1,
                    (
                        Qt.CheckState.Checked
                        if parameter_id in self._monitoring_selected_parameter_ids
                        else Qt.CheckState.Unchecked
                    ),
                )
                description = str(parameter.get("description") or "").strip()
                if description:
                    item.setToolTip(0, description)
                parent.addChild(item)
                self._monitoring_items_by_parameter_id[parameter_id] = item
        finally:
            self._suppress_monitoring_item_change = False
            tree.setUpdatesEnabled(updates_were_enabled)

        self._monitoring_device_ready = True
        self._monitoring_next_parameter_index = 0
        self.monitoring_parameters_tree_widget.expandToDepth(0)
        self.monitoring_parameters_tree_widget.setColumnWidth(0, 360)
        self.monitoring_parameters_tree_widget.setColumnWidth(1, 55)
        self.monitoring_parameters_tree_widget.setColumnWidth(2, 150)
        self.monitoring_parameters_tree_widget.setColumnWidth(3, 80)
        self.monitoring_parameters_tree_widget.setColumnWidth(4, 90)
        self._refresh_monitoring_row_visuals()
        self._refresh_monitoring_branch_visuals()
        self._filter_monitoring_tree(self.line_edit_monitoring_filter.text())
        self._update_monitoring_selection_summary()
        self._update_monitoring_selection_button()
        self._update_action_states()
        self._schedule_next_monitoring_read()

    def _on_monitoring_item_changed(self, item: QTreeWidgetItem, column: int) -> None:
        if self._suppress_monitoring_item_change or column != 1:
            return
        parameter_id = _optional_int(item.data(0, _ROLE_PARAMETER_ID))
        if parameter_id is None:
            return
        if item.checkState(1) == Qt.CheckState.Checked:
            self._monitoring_selected_parameter_ids.add(parameter_id)
        else:
            self._monitoring_selected_parameter_ids.discard(parameter_id)
            tree = self.monitoring_parameters_tree_widget
            signals_were_blocked = tree.blockSignals(True)
            try:
                item.setData(0, _ROLE_LAST_READ_MONOTONIC, None)
                item.setData(0, _ROLE_CHANGE_HIGHLIGHT_UNTIL, None)
            finally:
                tree.blockSignals(signals_were_blocked)
        self._monitoring_next_parameter_index = 0
        self._refresh_monitoring_row_visuals()
        self._refresh_monitoring_branch_visuals()
        self._update_monitoring_selection_summary()
        self._update_monitoring_selection_button()
        self._schedule_next_monitoring_read()

    def _on_toggle_all_monitoring_parameters_clicked(self) -> None:
        items = self._monitoring_items_by_parameter_id
        if not items:
            return

        # None selected -> select every visible leaf. Partial/all selected ->
        # clear every visible leaf, as requested.
        select_all = not any(
            item.checkState(1) == Qt.CheckState.Checked for item in items.values()
        )
        visible_parameter_ids = set(items)
        if select_all:
            self._monitoring_selected_parameter_ids.update(visible_parameter_ids)
        else:
            self._monitoring_selected_parameter_ids.difference_update(
                visible_parameter_ids
            )

        tree = self.monitoring_parameters_tree_widget
        signals_were_blocked = tree.blockSignals(True)
        updates_were_enabled = tree.updatesEnabled()
        tree.setUpdatesEnabled(False)
        try:
            target_state = (
                Qt.CheckState.Checked if select_all else Qt.CheckState.Unchecked
            )
            for item in items.values():
                item.setCheckState(1, target_state)
                if not select_all:
                    item.setData(0, _ROLE_LAST_READ_MONOTONIC, None)
                    item.setData(0, _ROLE_CHANGE_HIGHLIGHT_UNTIL, None)
        finally:
            tree.blockSignals(signals_were_blocked)
            tree.setUpdatesEnabled(updates_were_enabled)

        self._monitoring_next_parameter_index = 0
        self._refresh_monitoring_row_visuals()
        self._refresh_monitoring_branch_visuals()
        self._update_monitoring_selection_summary()
        self._update_monitoring_selection_button()
        self._schedule_next_monitoring_read()

    def _update_monitoring_selection_button(self) -> None:
        any_selected = any(
            item.checkState(1) == Qt.CheckState.Checked
            for item in self._monitoring_items_by_parameter_id.values()
        )
        self.push_button_toggle_all_monitoring_parameters.setText(
            "Clear All" if any_selected else "Select All"
        )

    def _update_monitoring_selection_summary(self) -> None:
        available_count = len(self._monitoring_items_by_parameter_id)
        selected_count = sum(
            item.checkState(1) == Qt.CheckState.Checked
            for item in self._monitoring_items_by_parameter_id.values()
        )
        self.label_monitoring_selection_summary.setText(
            f"{available_count} available · {selected_count} selected"
        )

    def _filter_monitoring_tree(self, filter_text: str) -> None:
        """Show Monitoring leaves whose complete parameter name matches."""
        query = str(filter_text or "").strip().casefold()

        def update_item_visibility(item: QTreeWidgetItem) -> bool:
            if item.data(0, _ROLE_KIND) == "monitoring_parameter":
                parameter_name = str(item.data(0, _ROLE_NAME) or item.text(0) or "")
                visible = not query or query in parameter_name.casefold()
            else:
                visible = False
                for child_index in range(item.childCount()):
                    if update_item_visibility(item.child(child_index)):
                        visible = True
            item.setHidden(not visible)
            if query and visible and item.childCount() > 0:
                item.setExpanded(True)
            return visible

        tree = self.monitoring_parameters_tree_widget
        for index in range(tree.topLevelItemCount()):
            update_item_visibility(tree.topLevelItem(index))

    def _refresh_monitoring_branch_visuals(self) -> None:
        """Keep a structure muted until at least one descendant is selected."""
        tree = self.monitoring_parameters_tree_widget

        def update_branch(item: QTreeWidgetItem) -> bool:
            if item.data(0, _ROLE_KIND) == "monitoring_parameter":
                return item.checkState(1) == Qt.CheckState.Checked

            has_selected_descendant = False
            for index in range(item.childCount()):
                child_selected = update_branch(item.child(index))
                has_selected_descendant = has_selected_descendant or child_selected
            if item.data(0, _ROLE_KIND) == "monitoring_branch":
                foreground = QBrush(
                    QColor("#24313d" if has_selected_descendant else "#969da6")
                )
                font = item.font(0)
                font.setBold(has_selected_descendant)
                for column in range(tree.columnCount()):
                    item.setForeground(column, foreground)
                    item.setFont(column, font)
            return has_selected_descendant

        for index in range(tree.topLevelItemCount()):
            update_branch(tree.topLevelItem(index))

    def _on_periodic_monitoring_toggled(self, enabled: bool) -> None:
        if enabled:
            self.push_button_periodic_monitoring_read.setText("Stop Monitoring")
            self._schedule_next_monitoring_read()
        else:
            self.push_button_periodic_monitoring_read.setText("Start Monitoring")

    def _stop_periodic_monitoring(self, _status_message: str) -> None:
        if self.push_button_periodic_monitoring_read.isChecked():
            self.push_button_periodic_monitoring_read.setChecked(False)
        self._monitoring_read_scheduled = False

    def _on_center_tab_changed(self, _index: int) -> None:
        if self.center_tab_widget.currentWidget() is self.monitoring_tab:
            self._refresh_monitoring_row_visuals()
            self._schedule_next_monitoring_read()
        elif self.push_button_periodic_monitoring_read.isChecked():
            self._stop_periodic_monitoring(
                "Monitoring stopped because its tab is inactive."
            )

    def _monitoring_should_run(self) -> bool:
        return (
            self._session_ready_flag
            and self._connected
            and self._settings_loaded
            and self._monitoring_device_ready
            and self.push_button_periodic_monitoring_read.isChecked()
            and self.center_tab_widget.currentWidget() is self.monitoring_tab
            and any(
                item.checkState(1) == Qt.CheckState.Checked
                for item in self._monitoring_items_by_parameter_id.values()
            )
        )

    def _schedule_next_monitoring_read(self) -> None:
        if (
            self._monitoring_read_scheduled
            or self._monitoring_read_in_flight
            or self._cli_busy
            or not self._monitoring_should_run()
        ):
            return
        self._monitoring_read_scheduled = True
        QTimer.singleShot(0, self._start_next_monitoring_read)

    def _start_next_monitoring_read(self) -> None:
        self._monitoring_read_scheduled = False
        if (
            self._monitoring_read_in_flight
            or self._cli_busy
            or not self._monitoring_should_run()
        ):
            return

        parameter_ids = [
            parameter_id
            for parameter_id, item in self._monitoring_items_by_parameter_id.items()
            if item.checkState(1) == Qt.CheckState.Checked
        ]
        if not parameter_ids:
            return

        if self._monitoring_next_parameter_index >= len(parameter_ids):
            self._monitoring_next_parameter_index = 0
        batch_start_index = self._monitoring_next_parameter_index
        batch_end_index = min(
            batch_start_index + _MONITORING_PARAMETERS_PER_COMMAND,
            len(parameter_ids),
        )
        batch_parameter_ids = parameter_ids[batch_start_index:batch_end_index]
        self._monitoring_next_parameter_index = (
            0 if batch_end_index >= len(parameter_ids) else batch_end_index
        )

        arguments: list[str] = []
        for parameter_id in batch_parameter_ids:
            arguments.extend(["--parameter-id", str(parameter_id)])
        if self._selected_slave_id is not None:
            arguments.extend(["--slave-id", str(self._selected_slave_id)])

        self._monitoring_read_in_flight = True

        def after_read(payload, exit_code: int) -> None:
            self._monitoring_read_in_flight = False
            if exit_code != 0:
                error = (
                    payload.get("error")
                    if isinstance(payload, dict)
                    else "No response from read-monitoring."
                )
                self._append_log(f"Monitoring read failed: {error}", success=False)
            self._schedule_next_monitoring_read()

        if not self._execute(
            "read-monitoring",
            arguments,
            after_read,
            report_log=False,
        ):
            self._monitoring_read_in_flight = False

    def _apply_monitoring_read_values(self, values: list[dict[str, Any]]) -> None:
        now = time.monotonic()
        success_count = 0
        error_count = 0
        tree = self.monitoring_parameters_tree_widget
        signals_were_blocked = tree.blockSignals(True)
        try:
            for value in values:
                parameter_id = _optional_int(value.get("parameter_id"))
                item = self._monitoring_items_by_parameter_id.get(
                    parameter_id if parameter_id is not None else -1
                )
                if item is None or item.checkState(1) != Qt.CheckState.Checked:
                    continue
                error = str(value.get("error") or "").strip()
                if error:
                    error_count += 1
                    item.setToolTip(2, error)
                    continue

                raw_display = value.get("display")
                display = "" if raw_display is None else str(raw_display)
                previous = item.data(0, _ROLE_LAST_VALUE)
                if previous is not None and str(previous) != display:
                    item.setData(0, _ROLE_CHANGE_HIGHLIGHT_UNTIL, now + 3.0)
                item.setData(0, _ROLE_LAST_VALUE, display)
                item.setData(0, _ROLE_LAST_READ_MONOTONIC, now)
                item.setText(2, display)
                item.setToolTip(2, "")
                success_count += 1
        finally:
            tree.blockSignals(signals_were_blocked)

        if error_count:
            self._append_log(
                f"Monitoring batch: {success_count} read, {error_count} failed.",
                success=False,
            )
        self._refresh_monitoring_row_visuals()

    def _on_monitoring_visual_timer(self) -> None:
        # A large package can contain more than a thousand Monitoring rows. Do
        # not walk and repaint all of them while another tab is visible.
        if self.center_tab_widget.currentWidget() is self.monitoring_tab:
            self._refresh_monitoring_row_visuals()

    def _refresh_monitoring_row_visuals(self) -> None:
        now = time.monotonic()
        tree = self.monitoring_parameters_tree_widget
        signals_were_blocked = tree.blockSignals(True)
        try:
            for item in self._visible_monitoring_parameter_items():
                selected = item.checkState(1) == Qt.CheckState.Checked
                last_read = item.data(0, _ROLE_LAST_READ_MONOTONIC)
                age_seconds = (
                    now - float(last_read)
                    if selected and last_read is not None
                    else None
                )
                stale = (
                    age_seconds is None or age_seconds > _MONITORING_STALE_AFTER_SECONDS
                )
                highlight_until = item.data(0, _ROLE_CHANGE_HIGHLIGHT_UNTIL)
                highlighted = highlight_until is not None and now < float(
                    highlight_until
                )
                if highlight_until is not None and not highlighted:
                    item.setData(0, _ROLE_CHANGE_HIGHLIGHT_UNTIL, None)

                visual_state = (selected, stale, highlighted)
                if item.data(0, _ROLE_MONITORING_VISUAL_STATE) != visual_state:
                    item.setData(0, _ROLE_MONITORING_VISUAL_STATE, visual_state)
                    if stale:
                        foreground = QBrush(QColor("#8a8a8a"))
                        background = QBrush()
                    elif highlighted:
                        # Explicit foreground is required on dark themes; an
                        # inherited light foreground is unreadable on green.
                        foreground = QBrush(QColor("#12351f"))
                        background = QBrush(QColor("#a9dfb2"))
                    else:
                        foreground = QBrush(QColor("#24313d"))
                        background = QBrush()
                    font = item.font(0)
                    font.setBold(selected)
                    for column in range(tree.columnCount()):
                        item.setFont(column, font)
                        item.setForeground(column, foreground)
                        item.setBackground(column, background)
        finally:
            tree.blockSignals(signals_were_blocked)

    def _visible_monitoring_parameter_items(self):
        """Yield only parameter leaves currently painted in the viewport."""
        tree = self.monitoring_parameters_tree_widget
        viewport_height = tree.viewport().height()
        item = tree.itemAt(0, 0)
        while item is not None:
            item_rect = tree.visualItemRect(item)
            if item_rect.top() > viewport_height:
                break
            if item.data(0, _ROLE_PARAMETER_ID) is not None:
                yield item
            item = tree.itemBelow(item)

    # ----- profile -----

    def _browse_profile(self) -> None:
        path, _ = QFileDialog.getOpenFileName(
            self,
            "Select profile CSV",
            self.line_edit_profile_csv_path.text().strip() or str(Path.home()),
            "CSV files (*.csv);;All files (*.*)",
        )
        if path:
            self.line_edit_profile_csv_path.setText(path)

    def _run_profile(
        self, command_name: str, confirmation_flags: list[str] | None = None
    ) -> None:
        path = self.line_edit_profile_csv_path.text().strip()
        if not path:
            QMessageBox.warning(self, "Profile", "Choose a profile CSV file.")
            return
        arguments = ["--file", path, "--verbose"]
        if self.check_box_apply_profile_to_all_similar_device_ids.isChecked():
            arguments.append("--all-same-device-id")
        arguments.extend(confirmation_flags or [])

        def after_profile(payload, exit_code: int) -> None:
            data = (
                payload.get("data")
                if isinstance(payload, dict) and isinstance(payload.get("data"), dict)
                else {}
            )
            if not data.get("requires_confirmation"):
                return

            issues = [
                issue
                for issue in data.get("parse_issues", [])
                if isinstance(issue, dict)
            ]
            incompatible = [
                target
                for target in data.get("incompatible_targets", [])
                if isinstance(target, dict)
            ]
            lines = []
            for issue in issues[:8]:
                lines.append(f"Line {issue.get('line')}: {issue.get('message')}")
                self._append_profile_log(lines[-1], success=False)
            for target in incompatible[:8]:
                lines.append(
                    f"SlaveId={target.get('slave_id')} {target.get('name')}: "
                    f"{target.get('reason')}"
                )
                self._append_profile_log(lines[-1], success=False)
            omitted = len(issues) + len(incompatible) - len(lines)
            if omitted > 0:
                lines.append(f"... and {omitted} more issue(s); see Profile log.")
            lines.append("")
            lines.append("Continue with valid rows and compatible devices only?")
            answer = QMessageBox.question(
                self,
                "Profile validation warning",
                "\n".join(lines),
                QMessageBox.StandardButton.Yes | QMessageBox.StandardButton.No,
                QMessageBox.StandardButton.No,
            )
            if answer != QMessageBox.StandardButton.Yes:
                self._append_profile_log(
                    "Profile operation cancelled before writing.", success=False
                )
                return
            flags: list[str] = []
            if issues:
                flags.append("--allow-partial")
            if incompatible:
                flags.append("--skip-incompatible")
            # Let the watcher for the validation response consume its
            # command_finished event before starting the confirmed run.
            QTimer.singleShot(0, lambda: self._run_profile(command_name, flags))

        self._profile_operation_running = True
        self._operation_cancel_requested = False
        self._update_action_states()
        operation_label = (
            "Verifying profile..."
            if command_name == "verify-profile"
            else "Applying profile..."
        )
        if not self._execute_with_live_progress(
            command_name,
            arguments,
            after_profile,
            operation_label=operation_label,
        ):
            self._profile_operation_running = False
            self._operation_cancel_requested = False
            self._update_action_states()

    def _save_profile(self) -> None:
        selected_tag_1 = self._choose_profile_tag1_categories()
        if selected_tag_1 is None:
            return
        if not selected_tag_1:
            QMessageBox.warning(
                self,
                "Save profile",
                "Select at least one Tag1 category to save.",
            )
            return
        path, _ = QFileDialog.getSaveFileName(
            self,
            "Save parameters as profile CSV",
            str(Path.home() / "settings_profile.csv"),
            "CSV files (*.csv);;All files (*.*)",
        )
        if path:
            arguments = ["--file", path]
            for tag_1 in selected_tag_1:
                arguments.extend(["--tag1", tag_1])
            self._profile_operation_running = True
            self._operation_cancel_requested = False
            self._update_action_states()
            if not self._execute_with_live_progress(
                "save-profile",
                arguments,
                operation_label="Saving profile...",
            ):
                self._profile_operation_running = False
                self._update_action_states()

    def _choose_profile_tag1_categories(self) -> list[str] | None:
        """Let the operator select the Tag1 groups written to a CSV profile."""
        categories = self._loaded_profile_tag1_categories
        if not categories:
            QMessageBox.warning(
                self,
                "Save profile",
                "Load this device's settings before saving a grouped profile.",
            )
            return None

        dialog = QDialog(self)
        dialog.setWindowTitle("Profile categories")
        dialog.setMinimumWidth(420)
        layout = QVBoxLayout(dialog)
        layout.addWidget(QLabel("Choose Tag1 categories to include in the CSV:"))

        scroll_area = QScrollArea()
        scroll_area.setWidgetResizable(True)
        list_widget = QWidget()
        list_layout = QVBoxLayout(list_widget)
        checkboxes: list[tuple[str, QCheckBox]] = []
        for tag_1 in categories:
            display_name = tag_1 or "(No Tag1)"
            checkbox = QCheckBox(display_name)
            checkbox.setChecked(True)
            list_layout.addWidget(checkbox)
            checkboxes.append((tag_1, checkbox))
        list_layout.addStretch(1)
        scroll_area.setWidget(list_widget)
        layout.addWidget(scroll_area)

        select_buttons = QHBoxLayout()
        select_all_button = QPushButton("Select All")
        clear_all_button = QPushButton("Clear All")
        select_all_button.clicked.connect(
            lambda: [checkbox.setChecked(True) for _, checkbox in checkboxes]
        )
        clear_all_button.clicked.connect(
            lambda: [checkbox.setChecked(False) for _, checkbox in checkboxes]
        )
        select_buttons.addWidget(select_all_button)
        select_buttons.addWidget(clear_all_button)
        select_buttons.addStretch(1)
        layout.addLayout(select_buttons)

        buttons = QDialogButtonBox(
            QDialogButtonBox.StandardButton.Save
            | QDialogButtonBox.StandardButton.Cancel
        )
        buttons.accepted.connect(dialog.accept)
        buttons.rejected.connect(dialog.reject)
        layout.addWidget(buttons)

        if dialog.exec() != QDialog.DialogCode.Accepted:
            return None
        return [tag_1 for tag_1, checkbox in checkboxes if checkbox.isChecked()]

    def _render_profile_result(
        self,
        command: str,
        data: dict[str, Any],
        ok: bool,
        error: object,
    ) -> None:
        self._append_profile_log(
            f"{command}: {'OK' if ok else 'FAILED'} "
            f"ok={data.get('ok_count', 0)} fail={data.get('fail_count', 0)} "
            f"skipped={data.get('skipped_count', 0)}",
            success=ok,
        )
        for issue in data.get("parse_issues", data.get("issues", [])):
            if isinstance(issue, dict):
                self._append_profile_log(
                    f"line {issue.get('line')}: {issue.get('message')}", success=False
                )
        for target in data.get("incompatible_targets", []):
            if isinstance(target, dict):
                self._append_profile_log(
                    f"Skipped Device={target.get('name')} "
                    f"(SlaveId={target.get('slave_id')}): {target.get('reason')}",
                    success=False,
                )
        target_names = {
            _optional_int(target.get("slave_id")): str(target.get("name") or "")
            for target in data.get("targets", [])
            if isinstance(target, dict)
        }
        for detail in data.get("details", []):
            if isinstance(detail, dict):
                if bool(detail.get("ok")):
                    continue
                message = detail.get("message") or detail.get("error") or ""
                slave_id = _optional_int(detail.get("slave_id"))
                device_name = target_names.get(slave_id) or "(unknown device)"
                self._append_profile_log(
                    f"Device={device_name} (SlaveId={slave_id}), "
                    f"parameter={detail.get('name')}: {message}",
                    success=False,
                )
        if error:
            self._append_profile_log(str(error), success=False)

    # ----- device commands -----

    def _populate_device_commands(self, commands: list[dict[str, Any]]) -> None:
        self.commands_tree_widget.clear()
        for command in commands:
            item = QTreeWidgetItem(
                [
                    str(command.get("name") or ""),
                    _display_or_empty(command.get("modbus_addr")),
                    str(command.get("data_type") or ""),
                ]
            )
            item.setData(0, _ROLE_NAME, command.get("name"))
            self.commands_tree_widget.addTopLevelItem(item)
        self.commands_tree_widget.resizeColumnToContents(0)
        self._on_selected_device_command_changed(
            self.commands_tree_widget.currentItem(), None
        )
        self._update_action_states()

    def _on_selected_device_command_changed(
        self,
        current: QTreeWidgetItem | None,
        _previous: QTreeWidgetItem | None,
    ) -> None:
        name = (
            str(current.data(0, _ROLE_NAME) or "").strip()
            if current is not None
            else ""
        )
        self.push_button_execute_selected_command.setText(
            f"Execute: {name}" if name else "Execute selected command"
        )
        self.push_button_execute_selected_command.setToolTip(
            f"Execute COMMAND parameter {name}" if name else "Select a command first."
        )

    def _execute_selected_device_command(
        self, *, skip_incompatible: bool = False
    ) -> None:
        item = self.commands_tree_widget.currentItem()
        if item is None:
            QMessageBox.warning(self, "Device command", "Select a command first.")
            return
        name = str(item.data(0, _ROLE_NAME) or "")
        if name:
            arguments = ["--name", name]
            if self.check_box_execute_command_on_all_similar_device_ids.isChecked():
                arguments.append("--all-same-device-id")
            if skip_incompatible:
                arguments.append("--skip-incompatible")

            def after_command(payload, _exit_code: int) -> None:
                data = (
                    payload.get("data")
                    if isinstance(payload, dict)
                    and isinstance(payload.get("data"), dict)
                    else {}
                )
                if not data.get("requires_confirmation"):
                    return
                incompatible = [
                    target
                    for target in data.get("incompatible_targets", [])
                    if isinstance(target, dict)
                ]
                lines = [
                    (
                        f"SlaveId={target.get('slave_id')} {target.get('name')}: "
                        f"{target.get('reason')}"
                    )
                    for target in incompatible[:10]
                ]
                omitted = len(incompatible) - len(lines)
                if omitted > 0:
                    lines.append(f"... and {omitted} more incompatible device(s).")
                lines.extend(
                    (
                        "",
                        f"Continue on {data.get('compatible_target_count', 0)} "
                        "compatible device(s)?",
                    )
                )
                answer = QMessageBox.question(
                    self,
                    "Command compatibility warning",
                    "\n".join(lines),
                    QMessageBox.StandardButton.Yes | QMessageBox.StandardButton.No,
                    QMessageBox.StandardButton.No,
                )
                if answer == QMessageBox.StandardButton.Yes:
                    QTimer.singleShot(
                        0,
                        lambda: self._execute_selected_device_command(
                            skip_incompatible=True
                        ),
                    )

            self._execute_with_live_progress(
                "execute-command",
                arguments,
                after_command,
                operation_label=f"Executing {name}...",
            )

    # ----- log helpers and shutdown -----

    def _append_log(self, message: str, *, success: bool | None = None) -> None:
        color = ""
        if success is True:
            color = "#1b7a1b"
        elif success is False:
            color = "#b00020"
        text = html.escape(message).replace("\n", "<br>")
        self.status_log_text_edit.append(
            f'<span style="color:{color}">{text}</span>' if color else text
        )

    def _append_profile_log(self, message: str, *, success: bool | None = None) -> None:
        color = "#1b7a1b" if success is True else "#b00020" if success is False else ""
        text = html.escape(message)
        self.profile_log_text_edit.append(
            f'<span style="color:{color}">{text}</span>' if color else text
        )

    def _append_command_log(self, message: str, *, success: bool | None = None) -> None:
        color = "#1b7a1b" if success is True else "#b00020" if success is False else ""
        text = html.escape(message)
        self.commands_log_text_edit.append(
            f'<span style="color:{color}">{text}</span>' if color else text
        )

    def closeEvent(self, event) -> None:  # noqa: N802
        self.cli_console_panel.shutdown()
        super().closeEvent(event)


def _optional_int(value: object) -> int | None:
    try:
        return int(value) if value is not None else None
    except (TypeError, ValueError):
        return None


def _parameter_name_path_segments(parameter_name: str) -> list[str]:
    """Split dotted and indexed parameter names for a GUI tree."""
    segments: list[str] = []
    for dotted_part in parameter_name.split("."):
        if not dotted_part:
            continue
        array_match = re.fullmatch(r"(.+)\[(\d+)\]", dotted_part)
        if array_match:
            segments.extend((array_match.group(1), f"[{array_match.group(2)}]"))
        else:
            segments.append(dotted_part)
    return segments or [parameter_name]


def _display_or_empty(value: object) -> str:
    return "" if value is None else str(value)
