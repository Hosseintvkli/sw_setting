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

from PyQt6.QtCore import QTimer, Qt
from PyQt6.QtGui import QBrush, QColor
from PyQt6.QtWidgets import (
    QAbstractItemView,
    QCheckBox,
    QFileDialog,
    QFormLayout,
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
    QTabWidget,
    QTextEdit,
    QTreeWidget,
    QTreeWidgetItem,
    QVBoxLayout,
    QWidget,
)

from ui.cli_console_panel import CliConsolePanel, parse_cli_invocation
from ui.communication_panel import CommunicationSettingsPanel

_ROLE_KIND = Qt.ItemDataRole.UserRole
_ROLE_NAME = Qt.ItemDataRole.UserRole + 1
_ROLE_LAST_VALUE = Qt.ItemDataRole.UserRole + 2
_ROLE_NODE = Qt.ItemDataRole.UserRole + 3
_ROLE_PARAMETER_ID = Qt.ItemDataRole.UserRole + 4
_ROLE_LAST_READ_MONOTONIC = Qt.ItemDataRole.UserRole + 5
_ROLE_CHANGE_HIGHLIGHT_UNTIL = Qt.ItemDataRole.UserRole + 6
_ROLE_MONITORING_VISUAL_STATE = Qt.ItemDataRole.UserRole + 7
_MONITORING_PARAMETERS_PER_COMMAND = 250


class DeviceSettingMainWindow(QMainWindow):
    _LEFT_PANEL_WIDTH_PIXELS = 450

    def __init__(self) -> None:
        super().__init__()
        self.setWindowTitle("Device Setting Tool — CLI driven")
        self.resize(1320, 780)

        self._connected = False
        self._cli_busy = False
        self._identify_running = False
        self._identify_cancel_requested = False
        self._live_identify_items: dict[int, QTreeWidgetItem] = {}
        self._session_ready_flag = False
        self._settings_loaded = False
        self._suppress_setting_change = False
        self._selected_slave_id: int | None = None
        self._monitoring_selected_parameter_ids: set[int] = set()
        self._monitoring_items_by_parameter_id: dict[int, QTreeWidgetItem] = {}
        self._monitoring_device_ready = False
        self._monitoring_read_in_flight = False
        self._monitoring_read_scheduled = False
        self._monitoring_next_parameter_index = 0
        self._suppress_monitoring_item_change = False

        self.cli_console_panel = CliConsolePanel(Path(__file__).resolve().parent.parent)
        self._build_ui()
        self._connect_signals()
        self._monitoring_visual_timer = QTimer(self)
        self._monitoring_visual_timer.setInterval(100)
        self._monitoring_visual_timer.timeout.connect(
            self._on_monitoring_visual_timer
        )
        self._monitoring_visual_timer.start()
        self._set_connected_state(False)
        self._append_log(
            "GUI is command-driven. Every action is recorded in the CLI tab."
        )

    def _build_ui(self) -> None:
        # ----- left: communication -----
        self.communication_settings_panel = CommunicationSettingsPanel()
        self.push_button_connect = QPushButton("Connect")
        self.push_button_disconnect = QPushButton("Disconnect")
        self.label_connection_state = QLabel("State: Disconnected")
        connection_buttons = QHBoxLayout()
        connection_buttons.addWidget(self.push_button_connect)
        connection_buttons.addWidget(self.push_button_disconnect)
        connection_buttons.addStretch(1)

        communicate_tab = QWidget()
        communicate_layout = QVBoxLayout(communicate_tab)
        communicate_layout.setContentsMargins(0, 0, 0, 0)
        communicate_layout.addWidget(self.communication_settings_panel)
        communicate_layout.addLayout(connection_buttons)
        communicate_layout.addWidget(self.label_connection_state)
        communicate_layout.addStretch(1)

        # ----- left: topology -----
        self.push_button_run_identify = QPushButton("Identify")
        self.push_button_cancel_identify = QPushButton("Cancel Identify")
        self.label_identify_progress = QLabel("Idle")
        self.label_identify_progress.setStyleSheet(
            "QLabel { color: #202020; background: #dce8f5; "
            "border: 1px solid #8aa9c7; padding: 4px; }"
        )
        self.progress_bar_identify = QProgressBar()
        self.progress_bar_identify.setRange(0, 0)
        self.progress_bar_identify.hide()
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
        devices_layout.addWidget(self.label_identify_progress)
        devices_layout.addWidget(self.progress_bar_identify)
        devices_layout.addWidget(QLabel("Double-click a device to select and load it"))
        devices_layout.addWidget(self.devices_topology_tree_widget, stretch=1)

        self.left_tab_widget = QTabWidget()
        self.left_tab_widget.addTab(communicate_tab, "Communicate")
        self.left_tab_widget.addTab(devices_tab, "Devices")
        left_container = QWidget()
        left_container.setMinimumWidth(280)
        left_container.setSizePolicy(
            QSizePolicy.Policy.Fixed, QSizePolicy.Policy.Expanding
        )
        left_layout = QVBoxLayout(left_container)
        left_layout.setContentsMargins(4, 4, 4, 4)
        left_layout.addWidget(self.left_tab_widget)

        # ----- monitoring -----
        self.label_monitoring_slave_id = QLabel("—")
        self.label_monitoring_device_id = QLabel("—")
        self.label_monitoring_serial_no = QLabel("—")
        self.label_monitoring_hardware_version = QLabel("—")
        self.label_monitoring_firmware_version = QLabel("—")
        monitoring_form = QFormLayout()
        monitoring_form.addRow("SlaveID:", self.label_monitoring_slave_id)
        monitoring_form.addRow("DeviceId:", self.label_monitoring_device_id)
        monitoring_form.addRow("SerialNo:", self.label_monitoring_serial_no)
        monitoring_form.addRow("HW. Ver:", self.label_monitoring_hardware_version)
        monitoring_form.addRow("FW. Ver:", self.label_monitoring_firmware_version)
        monitoring_box = QGroupBox("Device monitoring")
        monitoring_box.setLayout(monitoring_form)
        monitoring_box.setMaximumHeight(160)

        self.push_button_reload_settings_tree = QPushButton("Reload")
        self.label_selected_device = QLabel("Selected device: (none)")
        toolbar = QHBoxLayout()
        toolbar.addWidget(self.push_button_reload_settings_tree)
        toolbar.addStretch(1)
        toolbar.addWidget(self.label_selected_device)

        self.progress_bar_settings_load = QProgressBar()
        self.progress_bar_settings_load.setRange(0, 0)
        self.progress_bar_settings_load.hide()
        self.label_settings_load_status = QLabel("")
        self.label_settings_load_status.hide()

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
        parameters_tab = QWidget()
        parameters_layout = QVBoxLayout(parameters_tab)
        parameters_layout.addWidget(
            QLabel("SETTING R/W — double-click Value, then Enter to execute set-parameter")
        )
        parameters_layout.addWidget(self.settings_tree_widget, stretch=1)

        # ----- periodic monitoring -----
        self.push_button_periodic_monitoring_read = QPushButton("Start Monitoring")
        self.push_button_periodic_monitoring_read.setCheckable(True)
        self.push_button_periodic_monitoring_read.setChecked(False)
        self.push_button_toggle_all_monitoring_parameters = QPushButton("Select All")
        self.push_button_toggle_all_monitoring_parameters.setEnabled(False)
        self.label_periodic_monitoring_status = QLabel(
            "Load a device to list Monitoring parameters."
        )
        monitoring_controls = QHBoxLayout()
        monitoring_controls.addWidget(self.push_button_periodic_monitoring_read)
        monitoring_controls.addWidget(
            self.push_button_toggle_all_monitoring_parameters
        )
        monitoring_controls.addStretch(1)
        monitoring_controls.addWidget(self.label_periodic_monitoring_status)

        self.monitoring_parameters_tree_widget = QTreeWidget()
        self.monitoring_parameters_tree_widget.setColumnCount(6)
        self.monitoring_parameters_tree_widget.setHeaderLabels(
            ["Name", "Read", "Value", "DataType", "ModbusAddr", "Last read (ms)"]
        )
        self.monitoring_parameters_tree_widget.setAlternatingRowColors(True)
        self.monitoring_parameters_tree_widget.setUniformRowHeights(True)
        self.monitoring_parameters_tree_widget.setRootIsDecorated(True)
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
        self.monitoring_tab = monitoring_tab

        # ----- profile -----
        self.line_edit_profile_csv_path = QLineEdit()
        self.line_edit_profile_csv_path.setPlaceholderText("Path to profile CSV file")
        self.push_button_browse_profile_csv = QPushButton("Browse...")
        csv_row = QHBoxLayout()
        csv_row.addWidget(self.line_edit_profile_csv_path, stretch=1)
        csv_row.addWidget(self.push_button_browse_profile_csv)
        self.check_box_apply_profile_to_all_similar_device_ids = QCheckBox(
            "Apply to all discovered devices with the same DeviceId"
        )
        self.push_button_profile_apply = QPushButton("Apply")
        self.push_button_profile_verify = QPushButton("Verify")
        self.push_button_profile_save = QPushButton("Save parameters as profile...")
        profile_buttons = QHBoxLayout()
        profile_buttons.addWidget(self.push_button_profile_apply)
        profile_buttons.addWidget(self.push_button_profile_verify)
        profile_buttons.addWidget(self.push_button_profile_save)
        profile_buttons.addStretch(1)
        self.profile_log_text_edit = QTextEdit()
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
        self.push_button_execute_selected_command = QPushButton(
            "Execute selected command"
        )
        self.commands_log_text_edit = QTextEdit()
        self.commands_log_text_edit.setReadOnly(True)
        self.commands_log_text_edit.setMaximumHeight(160)
        commands_tab = QWidget()
        commands_layout = QVBoxLayout(commands_tab)
        commands_layout.addWidget(
            QLabel("COMMAND parameters — execution uses execute-command")
        )
        commands_layout.addWidget(self.commands_tree_widget, stretch=1)
        commands_layout.addWidget(self.push_button_execute_selected_command)
        commands_layout.addWidget(self.commands_log_text_edit)

        self.center_tab_widget = QTabWidget()
        self.center_tab_widget.addTab(parameters_tab, "Parameters")
        self.center_tab_widget.addTab(monitoring_tab, "Monitoring")
        self.center_tab_widget.addTab(profile_tab, "Profile")
        self.center_tab_widget.addTab(commands_tab, "Commands")
        self.center_tab_widget.addTab(self.cli_console_panel, "CLI")

        center_container = QWidget()
        center_layout = QVBoxLayout(center_container)
        center_layout.setContentsMargins(4, 4, 4, 4)
        center_layout.addLayout(toolbar)
        center_layout.addWidget(monitoring_box)
        center_layout.addWidget(self.progress_bar_settings_load)
        center_layout.addWidget(self.label_settings_load_status)
        center_layout.addWidget(self.center_tab_widget, stretch=1)

        self.status_log_text_edit = QTextEdit()
        self.status_log_text_edit.setReadOnly(True)
        right_container = QWidget()
        right_layout = QVBoxLayout(right_container)
        right_layout.setContentsMargins(4, 4, 4, 4)
        right_layout.addWidget(QLabel("Report Log"))
        right_layout.addWidget(self.status_log_text_edit, stretch=1)

        splitter = QSplitter(Qt.Orientation.Horizontal)
        splitter.addWidget(left_container)
        splitter.addWidget(center_container)
        splitter.addWidget(right_container)
        splitter.setStretchFactor(0, 0)
        splitter.setStretchFactor(1, 1)
        splitter.setStretchFactor(2, 0)
        splitter.setSizes([self._LEFT_PANEL_WIDTH_PIXELS, 740, 300])
        self.setCentralWidget(splitter)

    def _connect_signals(self) -> None:
        self.cli_console_panel.busy_changed.connect(self._on_cli_busy_changed)
        self.cli_console_panel.session_ready.connect(self._on_session_ready)
        self.cli_console_panel.command_completed.connect(
            self._on_any_cli_command_completed
        )
        self.cli_console_panel.session_event_received.connect(
            self._on_live_session_event
        )
        self.cli_console_panel.event_watcher_ready.connect(
            self._on_event_watcher_ready
        )
        self.cli_console_panel.event_watcher_error.connect(
            self._on_event_watcher_error
        )
        self.cli_console_panel.event_watcher_finished.connect(
            self._on_event_watcher_finished
        )
        self.communication_settings_panel.refresh_serial_ports_requested.connect(
            self._refresh_serial_ports
        )
        self.communication_settings_panel.refresh_networks_requested.connect(
            self._refresh_networks
        )
        self.push_button_connect.clicked.connect(self._on_connect_clicked)
        self.push_button_disconnect.clicked.connect(self._on_disconnect_clicked)
        self.push_button_run_identify.clicked.connect(self._on_identify_clicked)
        self.push_button_cancel_identify.clicked.connect(
            self._on_cancel_identify_clicked
        )
        self.push_button_reload_settings_tree.clicked.connect(
            self._on_reload_settings_clicked
        )
        self.devices_topology_tree_widget.itemDoubleClicked.connect(
            self._on_topology_item_double_clicked
        )
        self.settings_tree_widget.itemDoubleClicked.connect(
            self._on_setting_item_double_clicked
        )
        self.settings_tree_widget.itemChanged.connect(self._on_setting_item_changed)
        self.push_button_periodic_monitoring_read.toggled.connect(
            self._on_periodic_monitoring_toggled
        )
        self.push_button_toggle_all_monitoring_parameters.clicked.connect(
            self._on_toggle_all_monitoring_parameters_clicked
        )
        self.monitoring_parameters_tree_widget.itemChanged.connect(
            self._on_monitoring_item_changed
        )
        self.center_tab_widget.currentChanged.connect(
            self._on_center_tab_changed
        )
        self.push_button_browse_profile_csv.clicked.connect(self._browse_profile)
        self.push_button_profile_apply.clicked.connect(
            lambda: self._run_profile("apply-profile")
        )
        self.push_button_profile_verify.clicked.connect(
            lambda: self._run_profile("verify-profile")
        )
        self.push_button_profile_save.clicked.connect(self._save_profile)
        self.push_button_execute_selected_command.clicked.connect(
            self._execute_selected_device_command
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
            self._append_log(f"> {visible}")
        return self.cli_console_panel.execute_session_command(
            command_name,
            arguments,
            callback,
            echo_output=report_log,
        )

    def _on_cli_busy_changed(self, busy: bool) -> None:
        self._cli_busy = busy
        self._update_action_states()
        if not busy:
            self._schedule_next_monitoring_read()

    def _on_session_ready(self, session_name: str) -> None:
        self._session_ready_flag = True
        self._append_log(f"CLI session ready: {session_name}", success=True)
        self._refresh_serial_ports(
            lambda _payload, _code: self._refresh_networks()
        )

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
                self.label_identify_progress.setText("Identify finished")
            else:
                self.label_identify_progress.setText("Identify stopped")
            self.progress_bar_identify.hide()
            self._update_action_states()

        ok = exit_code == 0
        if completed_command != "read-monitoring":
            self._append_log(
                f"{'OK' if ok else 'FAILED'} exit={exit_code}: {command_text}",
                success=ok,
            )
        if not isinstance(payload, dict):
            return
        command = str(payload.get("command") or "")
        data = payload.get("data")
        data = data if isinstance(data, dict) else {}
        error = payload.get("error")
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
                        normalized_ports.append(
                            {"device": port, "description": ""}
                        )
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
            values = data.get("values")
            if isinstance(values, list):
                self._populate_settings(
                    [item for item in values if isinstance(item, dict)]
                )
            self.label_selected_device.setText(
                f"Selected device: {data.get('device_name', '(unknown)')}  "
                f"SlaveId={data.get('slave_id')}  DeviceId={data.get('device_id')}"
            )
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
            self._render_profile_result(command, data, ok, error)
        elif command == "save-profile":
            self._append_profile_log(
                f"{'SAVE OK' if ok else 'SAVE FAILED'}: "
                f"{data.get('file') or error}",
                success=ok,
            )
        elif command == "execute-command":
            self._append_command_log(
                str(data.get("message") or error or "No result"), success=ok
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

    def _set_connected_state(self, connected: bool) -> None:
        self._connected = connected
        self.label_connection_state.setText(
            "State: Connected" if connected else "State: Disconnected"
        )
        if not connected:
            self._settings_loaded = False
            self._selected_slave_id = None
            self.settings_tree_widget.clear()
            self.commands_tree_widget.clear()
            self._clear_monitoring_parameter_table()
            self.label_selected_device.setText("Selected device: (none)")
            self._clear_monitoring()
        self._update_action_states()

    def _update_action_states(self) -> None:
        ready = self._session_ready_flag and not self._cli_busy
        self.push_button_connect.setEnabled(ready and not self._connected)
        self.push_button_disconnect.setEnabled(ready and self._connected)
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
        self.push_button_reload_settings_tree.setEnabled(ready and self._connected)
        self.communication_settings_panel.setEnabled(ready and not self._connected)
        profile_ready = ready and self._connected and self._settings_loaded
        self.push_button_profile_apply.setEnabled(profile_ready)
        self.push_button_profile_verify.setEnabled(profile_ready)
        self.push_button_profile_save.setEnabled(ready and self._connected)
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

    def _clear_loaded_device_state(self) -> None:
        self._settings_loaded = False
        self._selected_slave_id = None
        self.settings_tree_widget.clear()
        self.commands_tree_widget.clear()
        self._clear_monitoring_parameter_table()
        self.label_selected_device.setText("Selected device: (none)")
        self._clear_monitoring()

    # ----- topology -----

    def _on_identify_clicked(self) -> None:
        self.devices_topology_tree_widget.clear()
        self._live_identify_items.clear()
        self._identify_running = True
        self._identify_cancel_requested = False
        self.label_identify_progress.setText("Preparing live Identify events...")
        self.progress_bar_identify.show()
        self._update_action_states()
        try:
            visible = self.cli_console_panel.build_session_command(
                "watch-events",
                "--command",
                "identify",
                "--json-lines",
            )
        except ValueError as exc:
            self._identify_running = False
            self.progress_bar_identify.hide()
            self._update_action_states()
            QMessageBox.warning(self, "Identify", str(exc))
            return
        self._append_log(f"> {visible}")
        if not self.cli_console_panel.start_session_event_watcher("identify"):
            self._identify_running = False
            self.label_identify_progress.setText("Could not start live events")
            self.progress_bar_identify.hide()
            self._update_action_states()

    def _on_event_watcher_ready(self, command_name: str) -> None:
        if command_name != "identify" or not self._identify_running:
            return
        self.label_identify_progress.setText("Starting Identify...")
        if not self._execute("identify"):
            self.cli_console_panel.stop_session_event_watcher()
            self._identify_running = False
            self.label_identify_progress.setText("Identify could not start")
            self.progress_bar_identify.hide()
            self._update_action_states()

    def _on_event_watcher_finished(
        self, command_name: str, exit_code: int
    ) -> None:
        if command_name != "identify":
            return
        if exit_code != 0:
            self._append_log(
                f"Live Identify events stopped with exit code {exit_code}.",
                success=False,
            )
        if self._identify_running and not self._cli_busy:
            self._identify_running = False
            self._identify_cancel_requested = False
            self.label_identify_progress.setText("Live event watcher stopped")
            self.progress_bar_identify.hide()
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

        if message and event_type not in ("command_started", "command_finished"):
            success = None
            if event_type in ("identify_failed", "identify_cancelled"):
                success = False
            elif event_type in ("device_discovered", "identify_finished"):
                success = True
            self._append_log(message, success=success)

        if event_type == "identify_started":
            self.label_identify_progress.setText("Identify is running...")
        elif event_type == "port_scanning":
            self.label_identify_progress.setText(message)
        elif event_type == "device_discovered":
            self.label_identify_progress.setText(message)
            self._add_live_identified_device(data)
        elif event_type == "cancel_requested":
            self.label_identify_progress.setText(
                "Cancelling Identify and restoring routing..."
            )
        elif event_type == "identify_cancelled":
            self.label_identify_progress.setText("Identify cancelled")
        elif event_type == "identify_failed":
            self.label_identify_progress.setText("Identify failed")
        elif event_type == "identify_finished":
            self.label_identify_progress.setText(message)

    def _add_live_identified_device(self, data: dict[str, Any]) -> None:
        slave_id = _optional_int(data.get("slave_id"))
        if slave_id is None or slave_id in self._live_identify_items:
            return
        device_name = str(data.get("device_name") or "(unknown)")
        port_index = _optional_int(data.get("port_index"))
        parent_slave_id = _optional_int(data.get("parent_slave_id"))
        label = (
            f"port[{port_index}]: {device_name}"
            if port_index is not None
            else device_name
        )
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
            parent_item.addChild(item)
        self._live_identify_items[slave_id] = item
        self.devices_topology_tree_widget.expandAll()
        for column in range(self.devices_topology_tree_widget.columnCount()):
            self.devices_topology_tree_widget.resizeColumnToContents(column)

    def _on_cancel_identify_clicked(self) -> None:
        try:
            visible = self.cli_console_panel.build_session_command("cancel")
        except ValueError as exc:
            QMessageBox.warning(self, "Cancel Identify", str(exc))
            return
        self._append_log(f"> {visible}")
        if self.cli_console_panel.request_session_cancel():
            self._identify_cancel_requested = True
            self.label_identify_progress.setText("Requesting cancellation...")
            self._update_action_states()

    def _populate_topology(self, root: dict[str, Any]) -> None:
        self.devices_topology_tree_widget.clear()

        def make_device_item(node: dict[str, Any], label: str | None = None):
            name = str(node.get("device_name") or f"DeviceId={node.get('device_id')}")
            item = QTreeWidgetItem(
                [
                    label or name,
                    str(node.get("slave_id", "")),
                    str(node.get("device_id", "")),
                    str(node.get("parameter_list_version", "")),
                    str(node.get("downstream_qty", 0)),
                ]
            )
            item.setData(0, _ROLE_NODE, node)
            for port in node.get("ports", []):
                if not isinstance(port, dict):
                    continue
                port_index = port.get("port_index")
                child = port.get("device")
                if port.get("connected") and isinstance(child, dict):
                    child_name = str(
                        child.get("device_name")
                        or f"DeviceId={child.get('device_id')}"
                    )
                    item.addChild(
                        make_device_item(child, f"port[{port_index}]: {child_name}")
                    )
                else:
                    item.addChild(
                        QTreeWidgetItem([f"port[{port_index}]: (no connection)"])
                    )
            return item

        self.devices_topology_tree_widget.addTopLevelItem(make_device_item(root))
        self.devices_topology_tree_widget.expandAll()
        for column in range(5):
            self.devices_topology_tree_widget.resizeColumnToContents(column)

    def _on_topology_item_double_clicked(
        self, item: QTreeWidgetItem, _column: int
    ) -> None:
        node = item.data(0, _ROLE_NODE)
        if not isinstance(node, dict):
            return
        slave_id = _optional_int(node.get("slave_id"))
        if slave_id is None:
            return

        def after_select(_payload, exit_code: int) -> None:
            if exit_code == 0:
                self.center_tab_widget.setCurrentIndex(0)
                self._load_settings(slave_id=slave_id)

        self._execute(
            "select-device", ["--slave-id", str(slave_id)], after_select
        )

    # ----- settings -----

    def _on_reload_settings_clicked(self) -> None:
        self._load_settings(reload=True)

    def _load_settings(self, *, slave_id: int | None = None, reload: bool = False) -> None:
        command = "reload-settings" if reload else "load-settings"
        arguments = ["--dump-values"]
        if slave_id is not None:
            arguments.extend(["--slave-id", str(slave_id)])
        self.progress_bar_settings_load.show()
        self.label_settings_load_status.setText("Running load-settings through CLI...")
        self.label_settings_load_status.show()
        self._stop_periodic_monitoring("Monitoring stopped for device load.")
        self._clear_monitoring_parameter_table()

        def after_load(_payload, exit_code: int) -> None:
            self.progress_bar_settings_load.hide()
            self.label_settings_load_status.hide()
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

        self._execute(command, arguments, after_load)

    def _populate_settings(self, values: list[dict[str, Any]]) -> None:
        self._suppress_setting_change = True
        try:
            self.settings_tree_widget.clear()
            categories: dict[str, QTreeWidgetItem] = {}
            branches: dict[tuple[str, tuple[str, ...]], QTreeWidgetItem] = {}
            for value in values:
                category = str(value.get("tag2") or "").strip() or "(No Tag2)"
                category_item = categories.get(category)
                if category_item is None:
                    category_item = QTreeWidgetItem([category])
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
        finally:
            self._suppress_setting_change = False

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

    def _on_setting_item_changed(
        self, item: QTreeWidgetItem, column: int
    ) -> None:
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
                    str(payload.get("error") if isinstance(payload, dict) else "No result"),
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

    def _clear_monitoring(self) -> None:
        for label in (
            self.label_monitoring_slave_id,
            self.label_monitoring_device_id,
            self.label_monitoring_serial_no,
            self.label_monitoring_hardware_version,
            self.label_monitoring_firmware_version,
        ):
            label.setText("—")

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
        self.label_periodic_monitoring_status.setText(
            "Load a device to list Monitoring parameters."
        )
        self._update_monitoring_selection_button()

    def _populate_monitoring_parameters(
        self, parameters: list[dict[str, Any]]
    ) -> None:
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
                        "",
                    ]
                )
                item.setFlags(
                    item.flags()
                    | Qt.ItemFlag.ItemIsUserCheckable
                    | Qt.ItemFlag.ItemIsEnabled
                    | Qt.ItemFlag.ItemIsSelectable
                )
                item.setData(0, _ROLE_PARAMETER_ID, parameter_id)
                item.setCheckState(
                    1,
                    Qt.CheckState.Checked
                    if parameter_id in self._monitoring_selected_parameter_ids
                    else Qt.CheckState.Unchecked,
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
        count = len(self._monitoring_items_by_parameter_id)
        self.label_periodic_monitoring_status.setText(
            f"{count} Monitoring parameter(s) available."
        )
        self.monitoring_parameters_tree_widget.expandToDepth(0)
        self.monitoring_parameters_tree_widget.setColumnWidth(0, 360)
        self.monitoring_parameters_tree_widget.setColumnWidth(1, 55)
        self.monitoring_parameters_tree_widget.setColumnWidth(2, 150)
        self.monitoring_parameters_tree_widget.setColumnWidth(3, 80)
        self.monitoring_parameters_tree_widget.setColumnWidth(4, 90)
        self._refresh_monitoring_row_visuals()
        self._update_monitoring_selection_button()
        self._update_action_states()
        self._schedule_next_monitoring_read()

    def _on_monitoring_item_changed(
        self, item: QTreeWidgetItem, column: int
    ) -> None:
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
                item.setText(5, "")
            finally:
                tree.blockSignals(signals_were_blocked)
        self._monitoring_next_parameter_index = 0
        self._refresh_monitoring_row_visuals()
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
                    item.setText(5, "")
        finally:
            tree.blockSignals(signals_were_blocked)
            tree.setUpdatesEnabled(updates_were_enabled)

        self._monitoring_next_parameter_index = 0
        self._refresh_monitoring_row_visuals()
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

    def _on_periodic_monitoring_toggled(self, enabled: bool) -> None:
        if enabled:
            self.push_button_periodic_monitoring_read.setText("Stop Monitoring")
            self.label_periodic_monitoring_status.setText(
                "Monitoring started; select parameters to read."
            )
            self._schedule_next_monitoring_read()
        else:
            self.push_button_periodic_monitoring_read.setText("Start Monitoring")
            self.label_periodic_monitoring_status.setText(
                "Monitoring is stopped."
            )

    def _stop_periodic_monitoring(self, status_message: str) -> None:
        if self.push_button_periodic_monitoring_read.isChecked():
            self.push_button_periodic_monitoring_read.setChecked(False)
        self._monitoring_read_scheduled = False
        self.label_periodic_monitoring_status.setText(status_message)

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
            self.label_periodic_monitoring_status.setText(
                "Select at least one Monitoring parameter."
            )
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
        self.label_periodic_monitoring_status.setText(
            f"Reading selected parameters {batch_start_index + 1}–"
            f"{batch_end_index} of {len(parameter_ids)}..."
        )

        def after_read(payload, exit_code: int) -> None:
            self._monitoring_read_in_flight = False
            if exit_code != 0:
                error = (
                    payload.get("error")
                    if isinstance(payload, dict)
                    else "No response from read-monitoring."
                )
                self.label_periodic_monitoring_status.setText(
                    f"Monitoring read failed: {error}"
                )
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

        self.label_periodic_monitoring_status.setText(
            f"Last batch: {success_count} read, {error_count} failed."
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
                stale = age_seconds is None or age_seconds > 5.0
                age_text = (
                    str(max(0, int(age_seconds * 1000)))
                    if age_seconds is not None and not stale
                    else ""
                )
                if item.text(5) != age_text:
                    item.setText(5, age_text)
                highlight_until = item.data(0, _ROLE_CHANGE_HIGHLIGHT_UNTIL)
                highlighted = (
                    highlight_until is not None and now < float(highlight_until)
                )
                if highlight_until is not None and not highlighted:
                    item.setData(0, _ROLE_CHANGE_HIGHLIGHT_UNTIL, None)

                visual_state = (stale, highlighted)
                if item.data(0, _ROLE_MONITORING_VISUAL_STATE) != visual_state:
                    item.setData(0, _ROLE_MONITORING_VISUAL_STATE, visual_state)
                    if highlighted:
                        # Explicit foreground is required on dark themes; an
                        # inherited light foreground is unreadable on green.
                        foreground = QBrush(QColor("#12351f"))
                        background = QBrush(QColor("#a9dfb2"))
                    elif stale:
                        foreground = QBrush(QColor("#8a8a8a"))
                        background = QBrush()
                    else:
                        foreground = QBrush()
                        background = QBrush()
                    for column in range(tree.columnCount()):
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

    def _run_profile(self, command_name: str) -> None:
        path = self.line_edit_profile_csv_path.text().strip()
        if not path:
            QMessageBox.warning(self, "Profile", "Choose a profile CSV file.")
            return
        arguments = ["--file", path, "--verbose"]
        if self.check_box_apply_profile_to_all_similar_device_ids.isChecked():
            arguments.append("--all-same-device-id")
        self._execute(command_name, arguments)

    def _save_profile(self) -> None:
        path, _ = QFileDialog.getSaveFileName(
            self,
            "Save parameters as profile CSV",
            str(Path.home() / "settings_profile.csv"),
            "CSV files (*.csv);;All files (*.*)",
        )
        if path:
            self._execute("save-profile", ["--file", path])

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
        for detail in data.get("details", []):
            if isinstance(detail, dict):
                message = detail.get("message") or detail.get("error") or ""
                self._append_profile_log(
                    f"SlaveId={detail.get('slave_id')} {detail.get('name')}: {message}",
                    success=bool(detail.get("ok")),
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
        self._update_action_states()

    def _execute_selected_device_command(self) -> None:
        item = self.commands_tree_widget.currentItem()
        if item is None:
            QMessageBox.warning(self, "Device command", "Select a command first.")
            return
        name = str(item.data(0, _ROLE_NAME) or "")
        if name:
            self._execute("execute-command", ["--name", name])

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

    def _append_profile_log(
        self, message: str, *, success: bool | None = None
    ) -> None:
        color = "#1b7a1b" if success is True else "#b00020" if success is False else ""
        text = html.escape(message)
        self.profile_log_text_edit.append(
            f'<span style="color:{color}">{text}</span>' if color else text
        )

    def _append_command_log(
        self, message: str, *, success: bool | None = None
    ) -> None:
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
