"""Command-driven GUI.

Widgets never call ``core``. Every operation is shown as and executed through
an exact ``python cli.py ...`` command in :class:`CliConsolePanel`.
"""

from __future__ import annotations

import html
from pathlib import Path
from typing import Any

from PyQt6.QtCore import Qt
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
        self._session_ready_flag = False
        self._settings_loaded = False
        self._suppress_setting_change = False
        self._selected_slave_id: int | None = None

        self.cli_console_panel = CliConsolePanel(Path(__file__).resolve().parent.parent)
        self._build_ui()
        self._connect_signals()
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
        right_layout.addWidget(QLabel("GUI command log"))
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
    ) -> bool:
        try:
            visible = self.cli_console_panel.build_session_command(
                command_name, *(arguments or [])
            )
        except ValueError as exc:
            QMessageBox.warning(self, "CLI", str(exc))
            return False
        self._append_log(f"> {visible}")
        return self.cli_console_panel.execute_session_command(
            command_name, arguments, callback
        )

    def _on_cli_busy_changed(self, busy: bool) -> None:
        self._cli_busy = busy
        self._update_action_states()

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
            self._update_action_states()

        ok = exit_code == 0
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
            self.label_selected_device.setText("Selected device: (none)")
            self._clear_monitoring()
        self._update_action_states()

    def _update_action_states(self) -> None:
        ready = self._session_ready_flag and not self._cli_busy
        self.push_button_connect.setEnabled(ready and not self._connected)
        self.push_button_disconnect.setEnabled(ready and self._connected)
        self.push_button_run_identify.setEnabled(ready and self._connected)
        self.push_button_cancel_identify.setEnabled(
            self._session_ready_flag
            and self._identify_running
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

    def _clear_loaded_device_state(self) -> None:
        self._settings_loaded = False
        self._selected_slave_id = None
        self.settings_tree_widget.clear()
        self.commands_tree_widget.clear()
        self.label_selected_device.setText("Selected device: (none)")
        self._clear_monitoring()

    # ----- topology -----

    def _on_identify_clicked(self) -> None:
        self.devices_topology_tree_widget.clear()
        if self._execute("identify"):
            self._identify_running = True
            self._identify_cancel_requested = False
            self._update_action_states()

    def _on_cancel_identify_clicked(self) -> None:
        try:
            visible = self.cli_console_panel.build_session_command("cancel")
        except ValueError as exc:
            QMessageBox.warning(self, "Cancel Identify", str(exc))
            return
        self._append_log(f"> {visible}")
        if self.cli_console_panel.request_session_cancel():
            self._identify_cancel_requested = True
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

        def after_load(_payload, exit_code: int) -> None:
            self.progress_bar_settings_load.hide()
            self.label_settings_load_status.hide()
            if exit_code != 0:
                return

            def after_header(_payload2, _exit_code2: int) -> None:
                self._execute("list-commands")

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


def _display_or_empty(value: object) -> str:
    return "" if value is None else str(value)
