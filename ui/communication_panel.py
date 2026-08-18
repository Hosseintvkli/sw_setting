"""
UI panel: choose Serial vs Ethernet and edit the matching connection fields.
"""

from __future__ import annotations

from PyQt6.QtCore import pyqtSignal
from PyQt6.QtWidgets import (
    QButtonGroup,
    QComboBox,
    QFormLayout,
    QGroupBox,
    QHBoxLayout,
    QLabel,
    QLineEdit,
    QPushButton,
    QRadioButton,
    QSpinBox,
    QVBoxLayout,
    QWidget,
)

from core.communication_settings import (
    CommunicationLinkKind,
    DeviceCommunicationSettings,
    EthernetTcpCommunicationSettings,
    SerialPortCommunicationSettings,
)

# Common baud rates shown in the list; user can also pick Custom.
_STANDARD_BAUD_RATE_BITS_PER_SECOND: tuple[int, ...] = (
    9600,
    19200,
    38400,
    57600,
    115200,
    230400,
    460800,
    921600,
)
_CUSTOM_BAUD_RATE_ITEM_LABEL = "Custom..."


def list_available_serial_port_device_names() -> list[str]:
    """
    Return sorted COM / tty device names currently visible to the OS.
    Requires pyserial (comes with pymodbus).
    """
    try:
        from serial.tools import list_ports
    except ImportError:
        return []

    port_names: list[str] = []
    for port_info in list_ports.comports():
        if port_info.device:
            port_names.append(port_info.device)
    return sorted(set(port_names), key=lambda name: name.lower())


def list_available_ipv4_network_interfaces() -> list[tuple[str, str]]:
    """
    Return (interface_name, ipv4_address) for non-loopback IPv4 adapters.
    Tries psutil, then a Windows PowerShell fallback.
    """
    results: list[tuple[str, str]] = []

    try:
        import psutil  # type: ignore

        for interface_name, address_list in psutil.net_if_addrs().items():
            for address in address_list:
                family = getattr(address, "family", None)
                # AF_INET is often 2; on some systems AddressFamily.AF_INET
                if str(family).endswith("AF_INET") or family == 2:
                    ip = address.address
                    if not ip or ip.startswith("127."):
                        continue
                    results.append((interface_name, ip))
        if results:
            # stable unique by name+ip
            seen: set[tuple[str, str]] = set()
            unique: list[tuple[str, str]] = []
            for item in sorted(results, key=lambda x: (x[0].lower(), x[1])):
                if item not in seen:
                    seen.add(item)
                    unique.append(item)
            return unique
    except Exception:
        pass

    # Windows fallback
    try:
        import json
        import subprocess

        command = (
            "Get-NetIPAddress -AddressFamily IPv4 | "
            "Where-Object { $_.IPAddress -notlike '127.*' } | "
            "Select-Object InterfaceAlias, IPAddress | ConvertTo-Json -Compress"
        )
        completed = subprocess.run(
            ["powershell", "-NoProfile", "-Command", command],
            capture_output=True,
            text=True,
            timeout=8,
            check=False,
        )
        if completed.returncode == 0 and completed.stdout.strip():
            payload = json.loads(completed.stdout)
            if isinstance(payload, dict):
                payload = [payload]
            for row in payload:
                name = str(row.get("InterfaceAlias", "")).strip()
                ip = str(row.get("IPAddress", "")).strip()
                if name and ip:
                    results.append((name, ip))
    except Exception:
        pass

    seen2: set[tuple[str, str]] = set()
    unique2: list[tuple[str, str]] = []
    for item in sorted(results, key=lambda x: (x[0].lower(), x[1])):
        if item not in seen2:
            seen2.add(item)
            unique2.append(item)
    return unique2


class CommunicationSettingsPanel(QWidget):
    """
    Top-of-window block for link type and timeouts.

    Emits communication_settings_changed when the user edits any field.
    Does not open the port or socket — only collects settings.
    """

    communication_settings_changed = pyqtSignal()

    def __init__(self, parent: QWidget | None = None) -> None:
        super().__init__(parent)

        self._suppress_change_signal: bool = False

        # --- link kind ---
        self.radio_button_serial_rtu = QRadioButton("Serial (Modbus RTU)")
        self.radio_button_ethernet_tcp = QRadioButton("Ethernet (Modbus TCP)")
        self.radio_button_serial_rtu.setChecked(True)

        self.link_kind_button_group = QButtonGroup(self)
        self.link_kind_button_group.addButton(self.radio_button_serial_rtu)
        self.link_kind_button_group.addButton(self.radio_button_ethernet_tcp)

        link_kind_row = QHBoxLayout()
        link_kind_row.addWidget(self.radio_button_serial_rtu)
        link_kind_row.addWidget(self.radio_button_ethernet_tcp)
        link_kind_row.addStretch(1)

        # --- serial: port list + refresh ---
        self.serial_settings_group_box = QGroupBox("Serial port")

        self.combo_box_serial_port_name = QComboBox()
        self.combo_box_serial_port_name.setEditable(False)
        self.combo_box_serial_port_name.setMinimumWidth(220)

        self.push_button_refresh_serial_port_list = QPushButton("Refresh ports")
        self.push_button_refresh_serial_port_list.clicked.connect(
            self.refresh_available_serial_port_list
        )

        serial_port_row = QHBoxLayout()
        serial_port_row.addWidget(self.combo_box_serial_port_name, stretch=1)
        serial_port_row.addWidget(self.push_button_refresh_serial_port_list)

        # --- serial: baud standard list + custom spin ---
        self.combo_box_baud_rate_bits_per_second = QComboBox()
        for baud_rate in _STANDARD_BAUD_RATE_BITS_PER_SECOND:
            self.combo_box_baud_rate_bits_per_second.addItem(str(baud_rate), baud_rate)
        self.combo_box_baud_rate_bits_per_second.addItem(
            _CUSTOM_BAUD_RATE_ITEM_LABEL, None
        )
        self.combo_box_baud_rate_bits_per_second.setCurrentText("115200")

        self.spin_box_custom_baud_rate_bits_per_second = QSpinBox()
        self.spin_box_custom_baud_rate_bits_per_second.setRange(50, 12_000_000)
        self.spin_box_custom_baud_rate_bits_per_second.setValue(115200)
        self.spin_box_custom_baud_rate_bits_per_second.setEnabled(False)

        baud_rate_row = QHBoxLayout()
        baud_rate_row.addWidget(self.combo_box_baud_rate_bits_per_second, stretch=1)
        baud_rate_row.addWidget(QLabel("Custom:"))
        baud_rate_row.addWidget(self.spin_box_custom_baud_rate_bits_per_second)

        self.spin_box_serial_read_timeout_milliseconds = QSpinBox()
        self.spin_box_serial_read_timeout_milliseconds.setRange(10, 60_000)
        self.spin_box_serial_read_timeout_milliseconds.setValue(1000)
        self.spin_box_serial_read_timeout_milliseconds.setSuffix(" ms")

        self.spin_box_serial_write_timeout_milliseconds = QSpinBox()
        self.spin_box_serial_write_timeout_milliseconds.setRange(10, 60_000)
        self.spin_box_serial_write_timeout_milliseconds.setValue(1000)
        self.spin_box_serial_write_timeout_milliseconds.setSuffix(" ms")

        self.spin_box_modbus_transaction_retry_count = QSpinBox()
        self.spin_box_modbus_transaction_retry_count.setRange(1, 20)
        self.spin_box_modbus_transaction_retry_count.setValue(3)
        self.spin_box_modbus_transaction_retry_count.setToolTip(
            "Total attempts: try immediately, then wait Read timeout and retry"
        )

        serial_form_layout = QFormLayout()
        serial_form_layout.addRow("COM port:", serial_port_row)
        serial_form_layout.addRow("Baud rate:", baud_rate_row)
        serial_form_layout.addRow(
            "Read timeout:", self.spin_box_serial_read_timeout_milliseconds
        )
        serial_form_layout.addRow(
            "Write timeout:", self.spin_box_serial_write_timeout_milliseconds
        )
        self.serial_settings_group_box.setLayout(serial_form_layout)

        # --- ethernet fields ---
        self.ethernet_settings_group_box = QGroupBox("Ethernet (TCP)")

        self.combo_box_local_network_interface = QComboBox()
        self.combo_box_local_network_interface.setMinimumWidth(260)
        self.push_button_refresh_network_interface_list = QPushButton("Refresh networks")
        self.push_button_refresh_network_interface_list.clicked.connect(
            self.refresh_available_network_interface_list
        )
        network_row = QHBoxLayout()
        network_row.addWidget(self.combo_box_local_network_interface, stretch=1)
        network_row.addWidget(self.push_button_refresh_network_interface_list)

        self.line_edit_device_ip_address = QLineEdit("192.168.1.100")
        self.spin_box_modbus_tcp_port_number = QSpinBox()
        self.spin_box_modbus_tcp_port_number.setRange(1, 65535)
        self.spin_box_modbus_tcp_port_number.setValue(502)

        self.spin_box_ethernet_connect_timeout_milliseconds = QSpinBox()
        self.spin_box_ethernet_connect_timeout_milliseconds.setRange(10, 60_000)
        self.spin_box_ethernet_connect_timeout_milliseconds.setValue(2000)
        self.spin_box_ethernet_connect_timeout_milliseconds.setSuffix(" ms")

        self.spin_box_ethernet_read_timeout_milliseconds = QSpinBox()
        self.spin_box_ethernet_read_timeout_milliseconds.setRange(10, 60_000)
        self.spin_box_ethernet_read_timeout_milliseconds.setValue(1000)
        self.spin_box_ethernet_read_timeout_milliseconds.setSuffix(" ms")

        self.spin_box_ethernet_write_timeout_milliseconds = QSpinBox()
        self.spin_box_ethernet_write_timeout_milliseconds.setRange(10, 60_000)
        self.spin_box_ethernet_write_timeout_milliseconds.setValue(1000)
        self.spin_box_ethernet_write_timeout_milliseconds.setSuffix(" ms")

        ethernet_form_layout = QFormLayout()
        ethernet_form_layout.addRow("Local network:", network_row)
        ethernet_form_layout.addRow("Device IP:", self.line_edit_device_ip_address)
        ethernet_form_layout.addRow("TCP port:", self.spin_box_modbus_tcp_port_number)
        ethernet_form_layout.addRow(
            "Connect timeout:", self.spin_box_ethernet_connect_timeout_milliseconds
        )
        ethernet_form_layout.addRow(
            "Read timeout:", self.spin_box_ethernet_read_timeout_milliseconds
        )
        ethernet_form_layout.addRow(
            "Write timeout:", self.spin_box_ethernet_write_timeout_milliseconds
        )
        self.ethernet_settings_group_box.setLayout(ethernet_form_layout)

        # --- common (no SlaveId on connect screen) ---
        common_form_layout = QFormLayout()
        common_form_layout.addRow(
            "Retries (per transaction):", self.spin_box_modbus_transaction_retry_count
        )

        root_layout = QVBoxLayout()
        root_layout.addWidget(QLabel("Communication"))
        root_layout.addLayout(link_kind_row)
        root_layout.addWidget(self.serial_settings_group_box)
        root_layout.addWidget(self.ethernet_settings_group_box)
        root_layout.addLayout(common_form_layout)
        self.setLayout(root_layout)

        self.refresh_available_serial_port_list()
        self.refresh_available_network_interface_list()
        self._update_link_kind_panels_visibility()
        self._update_custom_baud_rate_spin_box_enabled_state()
        self._connect_widget_signals()

    def _connect_widget_signals(self) -> None:
        self.radio_button_serial_rtu.toggled.connect(self._on_link_kind_toggled)
        self.radio_button_ethernet_tcp.toggled.connect(self._on_link_kind_toggled)

        self.combo_box_serial_port_name.currentIndexChanged.connect(
            self._emit_settings_changed
        )
        self.combo_box_baud_rate_bits_per_second.currentIndexChanged.connect(
            self._on_baud_rate_combo_box_changed
        )
        self.spin_box_custom_baud_rate_bits_per_second.valueChanged.connect(
            self._emit_settings_changed
        )

        self.line_edit_device_ip_address.textChanged.connect(self._emit_settings_changed)

        for widget in (
            self.spin_box_serial_read_timeout_milliseconds,
            self.spin_box_serial_write_timeout_milliseconds,
            self.spin_box_modbus_tcp_port_number,
            self.spin_box_ethernet_connect_timeout_milliseconds,
            self.spin_box_ethernet_read_timeout_milliseconds,
            self.spin_box_ethernet_write_timeout_milliseconds,
            self.spin_box_modbus_transaction_retry_count,
        ):
            widget.valueChanged.connect(self._emit_settings_changed)

        self.combo_box_local_network_interface.currentIndexChanged.connect(
            self._emit_settings_changed
        )

    def refresh_available_serial_port_list(self) -> None:
        """Rebuild COM list from the OS; keep selection if still present."""
        previously_selected_port_name = self.combo_box_serial_port_name.currentData()
        if previously_selected_port_name is None:
            previously_selected_port_name = self.combo_box_serial_port_name.currentText()

        available_port_names = list_available_serial_port_device_names()

        self._suppress_change_signal = True
        try:
            self.combo_box_serial_port_name.clear()
            if not available_port_names:
                self.combo_box_serial_port_name.addItem("(no serial ports found)", "")
            else:
                for port_name in available_port_names:
                    self.combo_box_serial_port_name.addItem(port_name, port_name)

                if previously_selected_port_name in available_port_names:
                    index = self.combo_box_serial_port_name.findData(
                        previously_selected_port_name
                    )
                    if index >= 0:
                        self.combo_box_serial_port_name.setCurrentIndex(index)
        finally:
            self._suppress_change_signal = False

        self._emit_settings_changed()


    def refresh_available_network_interface_list(self) -> None:
        """List local IPv4 adapters so the user can pick which network to use."""
        previous_name = ""
        previous_data = self.combo_box_local_network_interface.currentData()
        if isinstance(previous_data, tuple) and len(previous_data) == 2:
            previous_name = str(previous_data[0])

        interfaces = list_available_ipv4_network_interfaces()

        self._suppress_change_signal = True
        try:
            self.combo_box_local_network_interface.clear()
            if not interfaces:
                self.combo_box_local_network_interface.addItem(
                    "(no IPv4 networks found)", ("", "")
                )
            else:
                for interface_name, ipv4_address in interfaces:
                    label = f"{interface_name}  —  {ipv4_address}"
                    self.combo_box_local_network_interface.addItem(
                        label, (interface_name, ipv4_address)
                    )
                for index in range(self.combo_box_local_network_interface.count()):
                    data = self.combo_box_local_network_interface.itemData(index)
                    if (
                        isinstance(data, tuple)
                        and len(data) == 2
                        and data[0] == previous_name
                    ):
                        self.combo_box_local_network_interface.setCurrentIndex(index)
                        break
        finally:
            self._suppress_change_signal = False
        self._emit_settings_changed()

    def _on_baud_rate_combo_box_changed(self, _index: int) -> None:
        self._update_custom_baud_rate_spin_box_enabled_state()
        self._emit_settings_changed()

    def _update_custom_baud_rate_spin_box_enabled_state(self) -> None:
        is_custom = (
            self.combo_box_baud_rate_bits_per_second.currentData() is None
            and self.combo_box_baud_rate_bits_per_second.currentText()
            == _CUSTOM_BAUD_RATE_ITEM_LABEL
        )
        self.spin_box_custom_baud_rate_bits_per_second.setEnabled(is_custom)

    def _selected_baud_rate_bits_per_second(self) -> int:
        data = self.combo_box_baud_rate_bits_per_second.currentData()
        if data is not None:
            return int(data)
        return int(self.spin_box_custom_baud_rate_bits_per_second.value())

    def _selected_serial_port_name(self) -> str:
        data = self.combo_box_serial_port_name.currentData()
        if data:
            return str(data)
        text = self.combo_box_serial_port_name.currentText().strip()
        if text.startswith("("):
            return ""
        return text

    def _on_link_kind_toggled(self, _checked: bool) -> None:
        self._update_link_kind_panels_visibility()
        self._emit_settings_changed()

    def _update_link_kind_panels_visibility(self) -> None:
        is_serial = self.radio_button_serial_rtu.isChecked()
        self.serial_settings_group_box.setVisible(is_serial)
        self.ethernet_settings_group_box.setVisible(not is_serial)

    def _emit_settings_changed(self, *_args) -> None:
        if self._suppress_change_signal:
            return
        self.communication_settings_changed.emit()

    def read_device_communication_settings(self) -> DeviceCommunicationSettings:
        """Build a DeviceCommunicationSettings snapshot from the current widgets."""
        if self.radio_button_serial_rtu.isChecked():
            link_kind = CommunicationLinkKind.SERIAL_RTU
        else:
            link_kind = CommunicationLinkKind.ETHERNET_TCP

        serial_settings = SerialPortCommunicationSettings(
            serial_port_name=self._selected_serial_port_name(),
            baud_rate_bits_per_second=self._selected_baud_rate_bits_per_second(),
            read_timeout_milliseconds=self.spin_box_serial_read_timeout_milliseconds.value(),
            write_timeout_milliseconds=self.spin_box_serial_write_timeout_milliseconds.value(),
        )

        network_data = self.combo_box_local_network_interface.currentData()
        local_name = ""
        local_ip = ""
        if isinstance(network_data, tuple) and len(network_data) == 2:
            local_name = str(network_data[0] or "")
            local_ip = str(network_data[1] or "")

        ethernet_settings = EthernetTcpCommunicationSettings(
            local_network_interface_name=local_name,
            local_network_ipv4_address=local_ip,
            device_ip_address=self.line_edit_device_ip_address.text().strip(),
            modbus_tcp_port_number=self.spin_box_modbus_tcp_port_number.value(),
            connect_timeout_milliseconds=self.spin_box_ethernet_connect_timeout_milliseconds.value(),
            read_timeout_milliseconds=self.spin_box_ethernet_read_timeout_milliseconds.value(),
            write_timeout_milliseconds=self.spin_box_ethernet_write_timeout_milliseconds.value(),
        )

        return DeviceCommunicationSettings(
            link_kind=link_kind,
            serial_port_settings=serial_settings,
            ethernet_tcp_settings=ethernet_settings,
            modbus_unit_identifier=1,
            modbus_transaction_retry_count=self.spin_box_modbus_transaction_retry_count.value(),
        )

    def write_device_communication_settings(
        self, settings: DeviceCommunicationSettings
    ) -> None:
        """Push a settings object into the widgets (e.g. load defaults / profile)."""
        self._suppress_change_signal = True
        try:
            if settings.link_kind == CommunicationLinkKind.SERIAL_RTU:
                self.radio_button_serial_rtu.setChecked(True)
            else:
                self.radio_button_ethernet_tcp.setChecked(True)

            self.refresh_available_serial_port_list()
            serial = settings.serial_port_settings
            port_index = self.combo_box_serial_port_name.findData(
                serial.serial_port_name
            )
            if port_index >= 0:
                self.combo_box_serial_port_name.setCurrentIndex(port_index)

            baud = serial.baud_rate_bits_per_second
            baud_index = self.combo_box_baud_rate_bits_per_second.findData(baud)
            if baud_index >= 0:
                self.combo_box_baud_rate_bits_per_second.setCurrentIndex(baud_index)
            else:
                custom_index = self.combo_box_baud_rate_bits_per_second.findText(
                    _CUSTOM_BAUD_RATE_ITEM_LABEL
                )
                self.combo_box_baud_rate_bits_per_second.setCurrentIndex(custom_index)
                self.spin_box_custom_baud_rate_bits_per_second.setValue(baud)

            self.spin_box_serial_read_timeout_milliseconds.setValue(
                serial.read_timeout_milliseconds
            )
            self.spin_box_serial_write_timeout_milliseconds.setValue(
                serial.write_timeout_milliseconds
            )

            ethernet = settings.ethernet_tcp_settings
            self.refresh_available_network_interface_list()
            for index in range(self.combo_box_local_network_interface.count()):
                data = self.combo_box_local_network_interface.itemData(index)
                if (
                    isinstance(data, tuple)
                    and len(data) == 2
                    and data[0] == ethernet.local_network_interface_name
                ):
                    self.combo_box_local_network_interface.setCurrentIndex(index)
                    break
            self.line_edit_device_ip_address.setText(ethernet.device_ip_address)
            self.spin_box_modbus_tcp_port_number.setValue(ethernet.modbus_tcp_port_number)
            self.spin_box_ethernet_connect_timeout_milliseconds.setValue(
                ethernet.connect_timeout_milliseconds
            )
            self.spin_box_ethernet_read_timeout_milliseconds.setValue(
                ethernet.read_timeout_milliseconds
            )
            self.spin_box_ethernet_write_timeout_milliseconds.setValue(
                ethernet.write_timeout_milliseconds
            )

            self.spin_box_modbus_transaction_retry_count.setValue(
                settings.modbus_transaction_retry_count
            )
            self._update_link_kind_panels_visibility()
            self._update_custom_baud_rate_spin_box_enabled_state()
        finally:
            self._suppress_change_signal = False
