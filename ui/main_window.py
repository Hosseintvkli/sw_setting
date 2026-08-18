"""
Main window:

  Left (fixed): Communicate | Devices
  Center: monitoring + tabs Parameters | Profile
  Right: application log
"""

from __future__ import annotations

import time
from pathlib import Path

from PyQt6.QtCore import Qt, QThread, pyqtSignal
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

from core.device_modbus_link import DeviceModbusLink, DeviceModbusLinkError
from core.device_setting_tree_loader import (
    DeviceMonitoringHeaderValues,
    DeviceSettingTreeLoader,
    DeviceSettingTreeLoaderError,
    DeviceSettingTreeLoadResult,
    SettingParameterTreeLeafValue,
    get_fixed_codegen_json_root_directory,
)
from core.modbus_register_value_codec import (
    ModbusRegisterValueCodecError,
    decode_parameter_value_from_holding_registers,
    encode_parameter_value_to_holding_registers,
    format_decoded_parameter_value_for_display,
)
from core.parameter_value_validation import (
    ParameterValueValidationError,
    parse_and_validate_parameter_value_text,
)
from core.setting_profile_csv import (
    load_setting_profile_assignments_from_csv,
    save_setting_profile_csv,
)
from core.device_identify_session import (
    DeviceIdentifySession,
    DeviceIdentifySessionError,
)
from core.device_topology_models import DeviceIdentifyResult, IdentifiedDeviceNode
from ui.communication_panel import CommunicationSettingsPanel

_ROLE_IS_SETTING_LEAF = Qt.ItemDataRole.UserRole
_ROLE_DATA_TYPE = Qt.ItemDataRole.UserRole + 1
_ROLE_MODBUS_ADDRESS = Qt.ItemDataRole.UserRole + 2
_ROLE_LAST_GOOD_VALUE_TEXT = Qt.ItemDataRole.UserRole + 3
_ROLE_PARAMETER_NAME = Qt.ItemDataRole.UserRole + 4


class LoadSettingsTreeWorkerThread(QThread):
    progress_updated = pyqtSignal(int, int, str)
    load_succeeded = pyqtSignal(object)
    load_failed = pyqtSignal(str)

    def __init__(
        self,
        device_modbus_link: DeviceModbusLink,
        modbus_slave_unit_identifier: int,
        parent: QWidget | None = None,
    ) -> None:
        super().__init__(parent)
        self._device_modbus_link = device_modbus_link
        self._modbus_slave_unit_identifier = modbus_slave_unit_identifier
        self._last_progress_emit_monotonic: float = 0.0

    def run(self) -> None:
        def progress_callback(current: int, total: int, message: str) -> None:
            now = time.monotonic()
            is_finished = total > 0 and current >= total
            if is_finished or (now - self._last_progress_emit_monotonic) >= 0.5:
                self._last_progress_emit_monotonic = now
                self.progress_updated.emit(current, max(total, 1), message)

        try:
            loader = DeviceSettingTreeLoader(
                device_modbus_link=self._device_modbus_link,
                modbus_slave_unit_identifier=self._modbus_slave_unit_identifier,
                codegen_json_root_directory=get_fixed_codegen_json_root_directory(),
            )
            result = loader.load_setting_tree_from_connected_device(
                progress_callback=progress_callback
            )
            self.load_succeeded.emit(result)
        except DeviceSettingTreeLoaderError as exc:
            self.load_failed.emit(str(exc))
        except Exception as exc:
            self.load_failed.emit(str(exc))


class DeviceSettingMainWindow(QMainWindow):
    _LEFT_PANEL_WIDTH_PIXELS = 450

    def __init__(self) -> None:
        super().__init__()
        self.setWindowTitle("Device Setting Tool")
        self.resize(1200, 740)

        self.device_modbus_link = DeviceModbusLink()
        self._load_settings_worker_thread: LoadSettingsTreeWorkerThread | None = None
        self._suppress_settings_tree_item_changed: bool = False
        self._settings_tree_column_widths: list[int] | None = None
        self._settings_tree_has_been_populated_once: bool = False
        self._last_setting_tree_load_result: DeviceSettingTreeLoadResult | None = None
        self._last_device_identify_result: DeviceIdentifyResult | None = None
        self._pending_save_profile_after_reload: Path | None = None

        # ----- left -----
        self.communication_settings_panel = CommunicationSettingsPanel()

        self.push_button_connect = QPushButton("Connect")
        self.push_button_disconnect = QPushButton("Disconnect")
        self.push_button_disconnect.setEnabled(False)
        self.label_connection_state = QLabel("State: Disconnected")
        self.push_button_connect.clicked.connect(self._on_connect_clicked)
        self.push_button_disconnect.clicked.connect(self._on_disconnect_clicked)

        connect_row = QHBoxLayout()
        connect_row.addWidget(self.push_button_connect)
        connect_row.addWidget(self.push_button_disconnect)
        connect_row.addStretch(1)

        communicate_tab = QWidget()
        communicate_layout = QVBoxLayout(communicate_tab)
        communicate_layout.setContentsMargins(0, 0, 0, 0)
        communicate_layout.addWidget(self.communication_settings_panel)
        communicate_layout.addLayout(connect_row)
        communicate_layout.addWidget(self.label_connection_state)
        communicate_layout.addStretch(1)

        self.push_button_run_identify = QPushButton("Identify")
        self.push_button_run_identify.setEnabled(False)
        self.push_button_run_identify.clicked.connect(self._on_run_identify_clicked)
        self.devices_topology_tree_widget = QTreeWidget()
        self.devices_topology_tree_widget.setHeaderLabels(
            ["Device", "SlaveId", "DeviceId", "Version", "Ports"]
        )
        self.devices_topology_tree_widget.setUniformRowHeights(True)
        self.devices_topology_tree_widget.itemDoubleClicked.connect(
            self._on_devices_topology_item_double_clicked
        )

        devices_tab = QWidget()
        devices_layout = QVBoxLayout(devices_tab)
        devices_layout.addWidget(self.push_button_run_identify)
        devices_layout.addWidget(
            QLabel("Double-click a device to load its settings")
        )
        devices_layout.addWidget(self.devices_topology_tree_widget, stretch=1)

        self.left_tab_widget = QTabWidget()
        self.left_tab_widget.addTab(communicate_tab, "Communicate")
        self.left_tab_widget.addTab(devices_tab, "Devices")

        left_container = QWidget()
        left_container.setMinimumWidth(self._LEFT_PANEL_WIDTH_PIXELS)
        left_container.setMaximumWidth(self._LEFT_PANEL_WIDTH_PIXELS)
        left_container.setSizePolicy(
            QSizePolicy.Policy.Fixed, QSizePolicy.Policy.Expanding
        )
        left_layout = QVBoxLayout(left_container)
        left_layout.setContentsMargins(4, 4, 4, 4)
        left_layout.addWidget(self.left_tab_widget)

        # ----- center top: monitoring + toolbar -----
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

        monitoring_group_box = QGroupBox("Device monitoring")
        monitoring_group_box.setLayout(monitoring_form)
        monitoring_group_box.setMaximumHeight(160)

        self.push_button_reload_settings_tree = QPushButton("Reload")
        self.push_button_reload_settings_tree.setEnabled(False)
        self.push_button_reload_settings_tree.clicked.connect(
            self._on_load_or_reload_settings_tree_clicked
        )
        self.label_selected_device = QLabel("Selected device: (none)")

        toolbar_row = QHBoxLayout()
        toolbar_row.addWidget(self.push_button_reload_settings_tree)
        toolbar_row.addStretch(1)
        toolbar_row.addWidget(self.label_selected_device)

        self.progress_bar_settings_load = QProgressBar()
        self.progress_bar_settings_load.setMinimum(0)
        self.progress_bar_settings_load.setMaximum(100)
        self.progress_bar_settings_load.setValue(0)
        self.progress_bar_settings_load.hide()
        self.label_settings_load_status = QLabel("")
        self.label_settings_load_status.hide()

        # ----- Parameters tab (tree) -----
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
        self.settings_tree_widget.itemDoubleClicked.connect(
            self._on_settings_tree_item_double_clicked
        )
        self.settings_tree_widget.itemChanged.connect(
            self._on_settings_tree_item_changed
        )

        parameters_tab = QWidget()
        parameters_layout = QVBoxLayout(parameters_tab)
        parameters_layout.addWidget(
            QLabel("Settings (SETTING R/W) — double-click Value, Enter to write")
        )
        parameters_layout.addWidget(self.settings_tree_widget, stretch=1)

        # ----- Profile tab -----
        self.line_edit_profile_csv_path = QLineEdit()
        self.line_edit_profile_csv_path.setPlaceholderText("Path to profile CSV file")
        self.push_button_browse_profile_csv = QPushButton("Browse...")
        self.push_button_browse_profile_csv.clicked.connect(
            self._on_browse_profile_csv_clicked
        )

        csv_path_row = QHBoxLayout()
        csv_path_row.addWidget(self.line_edit_profile_csv_path, stretch=1)
        csv_path_row.addWidget(self.push_button_browse_profile_csv)

        self.check_box_apply_profile_to_all_similar_device_ids = QCheckBox(
            "Apply to all discovered devices with the same DeviceId (not implemented yet)"
        )
        # Placeholder only — no logic
        self.check_box_apply_profile_to_all_similar_device_ids.setEnabled(True)

        self.push_button_profile_apply = QPushButton("Apply")
        self.push_button_profile_verify = QPushButton("Verify")
        self.push_button_profile_save = QPushButton("Save parameters as profile...")
        self.push_button_profile_apply.clicked.connect(self._on_profile_apply_clicked)
        self.push_button_profile_verify.clicked.connect(self._on_profile_verify_clicked)
        self.push_button_profile_save.clicked.connect(self._on_profile_save_clicked)

        profile_actions_row = QHBoxLayout()
        profile_actions_row.addWidget(self.push_button_profile_apply)
        profile_actions_row.addWidget(self.push_button_profile_verify)
        profile_actions_row.addWidget(self.push_button_profile_save)
        profile_actions_row.addStretch(1)

        self.profile_log_text_edit = QTextEdit()
        self.profile_log_text_edit.setReadOnly(True)

        profile_tab = QWidget()
        profile_layout = QVBoxLayout(profile_tab)
        profile_layout.addWidget(QLabel("Profile CSV"))
        profile_layout.addLayout(csv_path_row)
        profile_layout.addWidget(self.check_box_apply_profile_to_all_similar_device_ids)
        profile_layout.addLayout(profile_actions_row)
        profile_layout.addWidget(QLabel("Profile log"))
        profile_layout.addWidget(self.profile_log_text_edit, stretch=1)

        self.center_tab_widget = QTabWidget()
        self.center_tab_widget.addTab(parameters_tab, "Parameters")
        self.center_tab_widget.addTab(profile_tab, "Profile")

        center_container = QWidget()
        center_layout = QVBoxLayout(center_container)
        center_layout.setContentsMargins(4, 4, 4, 4)
        center_layout.addLayout(toolbar_row)
        center_layout.addWidget(monitoring_group_box, stretch=0)
        center_layout.addWidget(self.progress_bar_settings_load)
        center_layout.addWidget(self.label_settings_load_status)
        center_layout.addWidget(self.center_tab_widget, stretch=1)

        # ----- right log -----
        self.status_log_text_edit = QTextEdit()
        self.status_log_text_edit.setReadOnly(True)
        right_container = QWidget()
        right_layout = QVBoxLayout(right_container)
        right_layout.setContentsMargins(4, 4, 4, 4)
        right_layout.addWidget(QLabel("Log"))
        right_layout.addWidget(self.status_log_text_edit, stretch=1)

        main_splitter = QSplitter(Qt.Orientation.Horizontal)
        main_splitter.addWidget(left_container)
        main_splitter.addWidget(center_container)
        main_splitter.addWidget(right_container)
        main_splitter.setStretchFactor(0, 0)
        main_splitter.setStretchFactor(1, 1)
        main_splitter.setStretchFactor(2, 0)
        main_splitter.setSizes([self._LEFT_PANEL_WIDTH_PIXELS, 700, 260])

        self.setCentralWidget(main_splitter)

        json_root = get_fixed_codegen_json_root_directory()
        self._append_log(
            f"JSON path (fixed): {json_root}\n"
            "Communicate: Connect. Devices: Identify, then double-click a device to load settings."
        )

    def _append_log(self, message: str) -> None:
        self.status_log_text_edit.append(message)

    def _append_profile_log(self, message: str, *, success: bool | None = None) -> None:
        """success True=green, False=red, None=default."""
        escaped = (
            message.replace("&", "&amp;")
            .replace("<", "&lt;")
            .replace(">", "&gt;")
        )
        if success is True:
            html = f'<span style="color:#1b7a1b;">{escaped}</span>'
        elif success is False:
            html = f'<span style="color:#b00020;">{escaped}</span>'
        else:
            html = escaped
        self.profile_log_text_edit.append(html)

    def _remember_settings_tree_column_widths(self) -> None:
        widths = [
            self.settings_tree_widget.columnWidth(column_index)
            for column_index in range(self.settings_tree_widget.columnCount())
        ]
        if any(width > 0 for width in widths):
            self._settings_tree_column_widths = widths

    def _restore_settings_tree_column_widths(self) -> None:
        if not self._settings_tree_column_widths:
            return
        for column_index, width in enumerate(self._settings_tree_column_widths):
            if width > 0:
                self.settings_tree_widget.setColumnWidth(column_index, width)

    def _apply_default_settings_tree_column_widths(self) -> None:
        self.settings_tree_widget.setColumnWidth(0, 420)
        self.settings_tree_widget.setColumnWidth(1, 160)
        self.settings_tree_widget.setColumnWidth(2, 70)
        self.settings_tree_widget.setColumnWidth(3, 55)

    def _clear_monitoring_header_labels(self) -> None:
        self.label_monitoring_slave_id.setText("—")
        self.label_monitoring_device_id.setText("—")
        self.label_monitoring_serial_no.setText("—")
        self.label_monitoring_hardware_version.setText("—")
        self.label_monitoring_firmware_version.setText("—")

    def _apply_monitoring_header_values(
        self, header: DeviceMonitoringHeaderValues
    ) -> None:
        self.label_monitoring_slave_id.setText(str(header.modbus_slave_unit_identifier))
        self.label_monitoring_device_id.setText(str(header.device_id))
        if header.serial_number is None:
            self.label_monitoring_serial_no.setText("—")
        else:
            self.label_monitoring_serial_no.setText(str(header.serial_number))
        self.label_monitoring_hardware_version.setText(header.hardware_version_text)
        self.label_monitoring_firmware_version.setText(header.firmware_version_text)

    def _set_connected_ui_state(self, is_connected: bool) -> None:
        self.push_button_connect.setEnabled(not is_connected)
        self.push_button_disconnect.setEnabled(is_connected)
        self.push_button_reload_settings_tree.setEnabled(is_connected)
        self.push_button_run_identify.setEnabled(is_connected)
        self.communication_settings_panel.setEnabled(not is_connected)
        self.label_connection_state.setText(
            "State: Connected" if is_connected else "State: Disconnected"
        )

    def _set_loading_ui_state(self, is_loading: bool) -> None:
        busy = is_loading
        connected = self.device_modbus_link.is_connected
        self.push_button_connect.setEnabled((not connected) and (not busy))
        self.push_button_disconnect.setEnabled(connected and (not busy))
        self.push_button_reload_settings_tree.setEnabled(connected and (not busy))
        self.push_button_run_identify.setEnabled(connected and (not busy))
        self.communication_settings_panel.setEnabled((not connected) and (not busy))

    def _on_connect_clicked(self) -> None:
        settings = (
            self.communication_settings_panel.read_device_communication_settings()
        )
        self._append_log("Connecting...")
        try:
            self.device_modbus_link.connect_using_settings(settings)
        except (DeviceModbusLinkError, Exception) as exc:
            self._append_log(f"CONNECT FAILED: {exc}")
            QMessageBox.critical(self, "Connect failed", str(exc))
            self._set_connected_ui_state(False)
            return
        self._append_log("Connected.")
        self._set_connected_ui_state(True)

    def _on_disconnect_clicked(self) -> None:
        if self._load_settings_worker_thread is not None and (
            self._load_settings_worker_thread.isRunning()
        ):
            QMessageBox.warning(self, "Busy", "Wait for the current load to finish.")
            return
        self.device_modbus_link.disconnect()
        self._remember_settings_tree_column_widths()
        self.settings_tree_widget.clear()
        self._last_setting_tree_load_result = None
        self.label_selected_device.setText("Selected device: (none)")
        self._clear_monitoring_header_labels()
        self.progress_bar_settings_load.setValue(0)
        self.progress_bar_settings_load.hide()
        self.label_settings_load_status.setText("")
        self.label_settings_load_status.hide()
        self._append_log("Disconnected.")
        self._set_connected_ui_state(False)

    def _on_load_or_reload_settings_tree_clicked(self) -> None:
        if self._load_settings_worker_thread is not None and (
            self._load_settings_worker_thread.isRunning()
        ):
            return

        json_root = get_fixed_codegen_json_root_directory()
        if not json_root.is_dir():
            QMessageBox.critical(
                self,
                "JSON catalog missing",
                f"Fixed path not found:\n{json_root}",
            )
            return

        try:
            unit_id = self.device_modbus_link.get_effective_modbus_unit_identifier()
        except DeviceModbusLinkError:
            settings = (
                self.communication_settings_panel.read_device_communication_settings()
            )
            unit_id = settings.modbus_unit_identifier

        self._remember_settings_tree_column_widths()
        self.settings_tree_widget.clear()
        self.progress_bar_settings_load.setValue(0)
        self.progress_bar_settings_load.show()
        self.label_settings_load_status.setText("Starting...")
        self.label_settings_load_status.show()
        self._append_log("Loading settings tree (batched Modbus reads)...")
        self._set_loading_ui_state(True)

        worker = LoadSettingsTreeWorkerThread(
            self.device_modbus_link, unit_id, self
        )
        worker.progress_updated.connect(self._on_load_progress_updated)
        worker.load_succeeded.connect(self._on_load_succeeded)
        worker.load_failed.connect(self._on_load_failed)
        worker.finished.connect(self._on_load_worker_thread_finished)
        self._load_settings_worker_thread = worker
        worker.start()

    def _on_load_progress_updated(
        self, current: int, total: int, message: str
    ) -> None:
        total = max(total, 1)
        percent = int(min(100, max(0, (100 * current) // total)))
        self.progress_bar_settings_load.setValue(percent)
        self.label_settings_load_status.setText(f"{message}  ({percent}%)")

    def _on_load_succeeded(self, result: object) -> None:
        assert isinstance(result, DeviceSettingTreeLoadResult)
        self._last_setting_tree_load_result = result
        self._apply_monitoring_header_values(result.monitoring_header_values)
        self._populate_settings_tree_widget(result)
        error_count = sum(
            1 for leaf in result.setting_leaf_values if leaf.read_error_message
        )
        self.progress_bar_settings_load.setValue(100)
        self.progress_bar_settings_load.hide()
        self.label_settings_load_status.setText("")
        self.label_settings_load_status.hide()
        self._append_log(
            f"DeviceId={result.device_id_from_device}  "
            f"Version={result.parameter_list_version_from_device}  "
            f"Name={result.parameter_list_package.info.device_name}  "
            f"SETTING={len(result.setting_leaf_values)}  "
            f"errors={error_count}"
        )
        self._finish_pending_profile_save_after_reload()

    def _on_load_failed(self, error_message: str) -> None:
        self.progress_bar_settings_load.hide()
        self.label_settings_load_status.hide()
        if self._pending_save_profile_after_reload is not None:
            self._append_profile_log(
                f"SAVE aborted: reload failed: {error_message}",
                success=False,
            )
            self._pending_save_profile_after_reload = None
        self._append_log(f"LOAD FAILED: {error_message}")
        QMessageBox.critical(self, "Load failed", error_message)

    def _on_load_worker_thread_finished(self) -> None:
        self._set_loading_ui_state(False)
        self._load_settings_worker_thread = None

    def _populate_settings_tree_widget(
        self, result: DeviceSettingTreeLoadResult
    ) -> None:
        self._suppress_settings_tree_item_changed = True
        try:
            self.settings_tree_widget.clear()
            category_items: dict[str, QTreeWidgetItem] = {}
            branch_items: dict[tuple[str, tuple[str, ...]], QTreeWidgetItem] = {}

            for leaf in result.setting_leaf_values:
                self._add_setting_leaf_to_tree(leaf, category_items, branch_items)

            self.settings_tree_widget.expandToDepth(0)

            if (
                not self._settings_tree_has_been_populated_once
                and not self._settings_tree_column_widths
            ):
                self._apply_default_settings_tree_column_widths()
                self._settings_tree_has_been_populated_once = True
                self._remember_settings_tree_column_widths()
            else:
                self._restore_settings_tree_column_widths()
        finally:
            self._suppress_settings_tree_item_changed = False

    def _add_setting_leaf_to_tree(
        self,
        leaf: SettingParameterTreeLeafValue,
        category_items: dict[str, QTreeWidgetItem],
        branch_items: dict[tuple[str, tuple[str, ...]], QTreeWidgetItem],
    ) -> None:
        parameter = leaf.parameter
        category_name = parameter.category_tag_1.strip() or "(No Tag1)"

        if category_name not in category_items:
            category_item = QTreeWidgetItem([category_name, "", "", ""])
            category_item.setFlags(
                category_item.flags() & ~Qt.ItemFlag.ItemIsEditable
            )
            self.settings_tree_widget.addTopLevelItem(category_item)
            category_items[category_name] = category_item
        category_item = category_items[category_name]

        segments = parameter.name_path_segments
        if not segments:
            segments = [parameter.parameter_name or "(unnamed)"]

        parent_item = category_item
        parent_path: tuple[str, ...] = ()

        for segment in segments[:-1]:
            parent_path = parent_path + (segment,)
            key = (category_name, parent_path)
            if key not in branch_items:
                branch_item = QTreeWidgetItem([segment, "", "", ""])
                branch_item.setFlags(
                    branch_item.flags() & ~Qt.ItemFlag.ItemIsEditable
                )
                parent_item.addChild(branch_item)
                branch_items[key] = branch_item
            parent_item = branch_items[key]

        value_text = leaf.display_value_text
        if leaf.read_error_message:
            value_text = f"ERROR: {leaf.read_error_message}"

        leaf_item = QTreeWidgetItem(
            [
                segments[-1],
                value_text,
                parameter.data_type_name,
                str(parameter.modbus_address),
            ]
        )
        leaf_item.setFlags(
            leaf_item.flags()
            | Qt.ItemFlag.ItemIsEditable
            | Qt.ItemFlag.ItemIsEnabled
            | Qt.ItemFlag.ItemIsSelectable
        )
        leaf_item.setData(0, _ROLE_IS_SETTING_LEAF, True)
        leaf_item.setData(0, _ROLE_DATA_TYPE, parameter.data_type_name)
        leaf_item.setData(0, _ROLE_MODBUS_ADDRESS, int(parameter.modbus_address))
        leaf_item.setData(0, _ROLE_LAST_GOOD_VALUE_TEXT, value_text)
        leaf_item.setData(0, _ROLE_PARAMETER_NAME, parameter.parameter_name)
        parent_item.addChild(leaf_item)

    def _on_settings_tree_item_double_clicked(
        self, item: QTreeWidgetItem, column: int
    ) -> None:
        if column != 1:
            return
        if not item.data(0, _ROLE_IS_SETTING_LEAF):
            return
        if not self.device_modbus_link.is_connected:
            return
        self.settings_tree_widget.editItem(item, 1)

    def _on_settings_tree_item_changed(
        self, item: QTreeWidgetItem, column: int
    ) -> None:
        if self._suppress_settings_tree_item_changed:
            return
        if column != 1:
            return
        if not item.data(0, _ROLE_IS_SETTING_LEAF):
            return

        data_type_name = item.data(0, _ROLE_DATA_TYPE)
        modbus_address = item.data(0, _ROLE_MODBUS_ADDRESS)
        previous_text = item.data(0, _ROLE_LAST_GOOD_VALUE_TEXT) or ""
        new_text = item.text(1).strip()

        if new_text == previous_text:
            return
        if data_type_name is None or modbus_address is None:
            return

        try:
            parsed_value = parse_and_validate_parameter_value_text(
                data_type_name, new_text
            )
            register_values = encode_parameter_value_to_holding_registers(
                data_type_name, parsed_value
            )
            self.device_modbus_link.write_holding_registers_u16(
                int(modbus_address), register_values
            )
            display_text = format_decoded_parameter_value_for_display(
                data_type_name, parsed_value
            )
        except (
            ParameterValueValidationError,
            ModbusRegisterValueCodecError,
            DeviceModbusLinkError,
        ) as exc:
            self._append_log(f"WRITE FAILED @ {modbus_address}: {exc}")
            self._suppress_settings_tree_item_changed = True
            try:
                item.setText(1, str(previous_text))
            finally:
                self._suppress_settings_tree_item_changed = False
            QMessageBox.warning(self, "Write failed", str(exc))
            return

        self._suppress_settings_tree_item_changed = True
        try:
            item.setText(1, display_text)
            item.setData(0, _ROLE_LAST_GOOD_VALUE_TEXT, display_text)
        finally:
            self._suppress_settings_tree_item_changed = False

        self._append_log(
            f"WRITE OK addr={modbus_address} type={data_type_name} value={display_text}"
        )

    # ----- Profile -----

    def _on_browse_profile_csv_clicked(self) -> None:
        start = self.line_edit_profile_csv_path.text().strip() or str(Path.home())
        path, _filter = QFileDialog.getOpenFileName(
            self,
            "Select profile CSV",
            start,
            "CSV files (*.csv);;All files (*.*)",
        )
        if path:
            self.line_edit_profile_csv_path.setText(path)

    def _require_connected_and_loaded_package(self) -> DeviceSettingTreeLoadResult | None:
        if not self.device_modbus_link.is_connected:
            QMessageBox.warning(self, "Not connected", "Connect to a device first.")
            return None
        if self._last_setting_tree_load_result is None:
            QMessageBox.warning(
                self,
                "No parameter list",
                "Open a device first (Identify → double-click device, or Reload after selection).",
            )
            return None
        return self._last_setting_tree_load_result

    def _on_profile_apply_clicked(self) -> None:
        self._run_profile_from_csv(verify_only=False)

    def _on_profile_verify_clicked(self) -> None:
        self._run_profile_from_csv(verify_only=True)

    def _run_profile_from_csv(self, verify_only: bool) -> None:
        load_result = self._require_connected_and_loaded_package()
        if load_result is None:
            return

        csv_path_text = self.line_edit_profile_csv_path.text().strip()
        if not csv_path_text:
            QMessageBox.warning(self, "No CSV", "Choose a profile CSV file.")
            return
        csv_path = Path(csv_path_text)
        if not csv_path.is_file():
            QMessageBox.warning(self, "CSV missing", f"File not found:\n{csv_path}")
            return

        if self.check_box_apply_profile_to_all_similar_device_ids.isChecked():
            self._append_profile_log(
                "Note: 'all similar DeviceId' is not implemented yet — "
                "only the current connection is used."
            )

        mode_label = "VERIFY" if verify_only else "APPLY"
        self._append_profile_log(f"===== {mode_label} {csv_path.name} =====")

        parse_result = load_setting_profile_assignments_from_csv(
            csv_path, load_result.parameter_list_package
        )
        for issue in parse_result.issues:
            self._append_profile_log(
                f"PARSE FAIL line {issue.source_csv_line_number}: {issue.message}",
                success=False,
            )

        ok_count = 0
        fail_count = len(parse_result.issues)

        for assignment in parse_result.assignments:
            definition = assignment.parameter_definition
            try:
                if verify_only:
                    registers = self.device_modbus_link.read_holding_registers_u16(
                        definition.modbus_address,
                        definition.modbus_register_size
                        if definition.modbus_register_size > 0
                        else 1,
                    )
                    # use modbus size from definition; codec expects matching type size
                    from core.modbus_register_value_codec import (
                        register_count_for_data_type_name,
                    )

                    expected_count = definition.modbus_register_size
                    if expected_count <= 0:
                        expected_count = register_count_for_data_type_name(
                            definition.data_type_name
                        )
                    if len(registers) < expected_count:
                        registers = self.device_modbus_link.read_holding_registers_u16(
                            definition.modbus_address, expected_count
                        )
                    device_value = decode_parameter_value_from_holding_registers(
                        definition.data_type_name, registers[:expected_count]
                    )
                    if not _profile_values_equal(
                        definition.data_type_name,
                        device_value,
                        assignment.parsed_value,
                    ):
                        raise DeviceModbusLinkError(
                            f"Mismatch device={device_value!r} csv={assignment.parsed_value!r}"
                        )
                    self._append_profile_log(
                        f"VERIFY OK {assignment.parameter_name} = {assignment.parsed_value!r}",
                        success=True,
                    )
                else:
                    register_values = encode_parameter_value_to_holding_registers(
                        definition.data_type_name, assignment.parsed_value
                    )
                    self.device_modbus_link.write_holding_registers_u16(
                        definition.modbus_address, register_values
                    )
                    self._append_profile_log(
                        f"APPLY OK {assignment.parameter_name} = {assignment.parsed_value!r}",
                        success=True,
                    )
                ok_count += 1
            except (
                DeviceModbusLinkError,
                ModbusRegisterValueCodecError,
                ParameterValueValidationError,
            ) as exc:
                fail_count += 1
                self._append_profile_log(
                    f"{mode_label} FAIL {assignment.parameter_name}: {exc}",
                    success=False,
                )

        self._append_profile_log(
            f"===== {mode_label} done: ok={ok_count} fail={fail_count} ====="
        )
        self._append_log(f"Profile {mode_label}: ok={ok_count} fail={fail_count}")

        if (
            not verify_only
            and ok_count > 0
            and self._last_setting_tree_load_result is not None
        ):
            # Tree may be stale; user can Reload. Optional soft note:
            self._append_log("Profile applied — Reload settings tree to refresh values.")

    def _on_profile_save_clicked(self) -> None:
        if not self.device_modbus_link.is_connected:
            QMessageBox.warning(self, "Not connected", "Connect to a device first.")
            return

        path, _filter = QFileDialog.getSaveFileName(
            self,
            "Save parameters as profile CSV",
            str(Path.home() / "settings_profile.csv"),
            "CSV files (*.csv);;All files (*.*)",
        )
        if not path:
            return
        csv_path = Path(path)
        self._pending_save_profile_after_reload = csv_path
        self._append_profile_log(f"Reloading settings before save to {csv_path}...")
        self._append_log("Profile save: Reload first, then write CSV.")
        self._on_load_or_reload_settings_tree_clicked()

    def _finish_pending_profile_save_after_reload(self) -> None:
        csv_path = self._pending_save_profile_after_reload
        self._pending_save_profile_after_reload = None
        if csv_path is None:
            return
        load_result = self._last_setting_tree_load_result
        if load_result is None:
            self._append_profile_log("SAVE FAIL: no settings after reload.", success=False)
            return

        rows: list[tuple[str, str]] = []
        for leaf in load_result.setting_leaf_values:
            if leaf.read_error_message:
                continue
            rows.append((leaf.parameter.parameter_name, leaf.display_value_text))

        try:
            save_setting_profile_csv(csv_path, rows)
        except OSError as exc:
            self._append_profile_log(f"SAVE FAIL: {exc}", success=False)
            QMessageBox.critical(self, "Save failed", str(exc))
            return

        self._append_profile_log(
            f"SAVE OK {csv_path} ({len(rows)} SETTING rows)",
            success=True,
        )
        self._append_log(f"Profile saved: {csv_path}")
        self.line_edit_profile_csv_path.setText(str(csv_path))

    def _on_run_identify_clicked(self) -> None:
        if not self.device_modbus_link.is_connected:
            QMessageBox.warning(self, "Not connected", "Connect first.")
            return
        self.devices_topology_tree_widget.clear()
        self._append_log("Identify started...")
        self._set_loading_ui_state(True)
        try:
            session = DeviceIdentifySession(
                device_modbus_link=self.device_modbus_link,
                codegen_json_root_directory=get_fixed_codegen_json_root_directory(),
                log_callback=self._append_log,
            )
            result = session.run_identify()
        except DeviceIdentifySessionError as exc:
            self._append_log(f"IDENTIFY FAILED: {exc}")
            QMessageBox.critical(self, "Identify failed", str(exc))
            self._set_loading_ui_state(False)
            return
        except Exception as exc:
            self._append_log(f"IDENTIFY FAILED (unexpected): {exc}")
            QMessageBox.critical(self, "Identify failed", str(exc))
            self._set_loading_ui_state(False)
            return
        finally:
            self._set_loading_ui_state(False)

        self._last_device_identify_result = result
        self._populate_devices_topology_tree(result)
        self._append_log(
            f"Identify done. Assigned slave ids: {result.assigned_slave_id_count}"
        )
        self.left_tab_widget.setCurrentIndex(1)

    def _populate_devices_topology_tree(self, result: DeviceIdentifyResult) -> None:
        self.devices_topology_tree_widget.clear()
        if result.root_node is None:
            return

        def add_node(node: IdentifiedDeviceNode, parent_item: QTreeWidgetItem | None) -> None:
            label = node.device_name or f"DeviceId={node.device_id}"
            item = QTreeWidgetItem(
                [
                    label,
                    str(node.permanent_modbus_slave_id),
                    str(node.device_id),
                    str(node.parameter_list_version),
                    str(node.downstream_port_quantity),
                ]
            )
            item.setData(0, Qt.ItemDataRole.UserRole, node)
            if parent_item is None:
                self.devices_topology_tree_widget.addTopLevelItem(item)
            else:
                parent_item.addChild(item)
            for port_index in sorted(node.children_by_port_index):
                child = node.children_by_port_index[port_index]
                port_item = QTreeWidgetItem(
                    [f"port[{port_index}]", "", "", "", ""]
                )
                # port rows are not selectable targets for settings load
                item.addChild(port_item)
                add_node(child, port_item)

        add_node(result.root_node, None)
        self.devices_topology_tree_widget.expandAll()
        for column_index in range(5):
            self.devices_topology_tree_widget.resizeColumnToContents(column_index)

    def closeEvent(self, event) -> None:  # noqa: N802
        if self._load_settings_worker_thread is not None and (
            self._load_settings_worker_thread.isRunning()
        ):
            self._load_settings_worker_thread.wait(3000)
        self.device_modbus_link.disconnect()
        super().closeEvent(event)


def _profile_values_equal(
    data_type_name: str, device_value: int | float, csv_value: int | float
) -> bool:
    normalized = data_type_name.strip().upper()
    if normalized in ("F32", "F64"):
        return abs(float(device_value) - float(csv_value)) <= 1e-6 * max(
            1.0, abs(float(csv_value))
        )
    return int(device_value) == int(csv_value)
