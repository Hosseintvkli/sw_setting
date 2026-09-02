"""Communication form, local Windows-network validation, and CLI arguments.

OS discovery and Modbus connection work are deliberately delegated to
``list-serial-ports``, ``list-networks`` and ``connect`` commands.
"""

from __future__ import annotations

import sys

from PyQt6.QtCore import QProcess, pyqtSignal
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
    QSizePolicy,
    QSpinBox,
    QVBoxLayout,
    QWidget,
)

_STANDARD_BAUD_RATES = (
    9600,
    19200,
    38400,
    57600,
    115200,
    230400,
    460800,
    921600,
)
_CUSTOM_BAUD_LABEL = "Custom..."
_REQUIRED_LOCAL_IPV4_ADDRESS = "192.168.1.120"


class CommunicationSettingsPanel(QWidget):
    refresh_serial_ports_requested = pyqtSignal()
    refresh_networks_requested = pyqtSignal()

    def __init__(self, parent: QWidget | None = None) -> None:
        super().__init__(parent)

        self.radio_button_serial_rtu = QRadioButton("Serial (Modbus RTU)")
        self.radio_button_ethernet_tcp = QRadioButton("Ethernet (Modbus TCP)")
        self.radio_button_serial_rtu.setChecked(True)
        group = QButtonGroup(self)
        group.addButton(self.radio_button_serial_rtu)
        group.addButton(self.radio_button_ethernet_tcp)

        kind_row = QHBoxLayout()
        kind_row.addWidget(self.radio_button_serial_rtu)
        kind_row.addWidget(self.radio_button_ethernet_tcp)
        kind_row.addStretch(1)

        self.serial_settings_group_box = QGroupBox("Serial port")
        self.combo_box_serial_port_name = QComboBox()
        self.combo_box_serial_port_name.setMinimumWidth(0)
        self.combo_box_serial_port_name.setSizePolicy(
            QSizePolicy.Policy.Ignored,
            QSizePolicy.Policy.Fixed,
        )
        self.combo_box_serial_port_name.addItem("(refresh to list ports)", "")
        self.push_button_refresh_serial_port_list = QPushButton("Refresh ports")
        self.push_button_refresh_serial_port_list.clicked.connect(
            self.refresh_serial_ports_requested
        )
        serial_port_controls = QVBoxLayout()
        serial_port_controls.setContentsMargins(0, 0, 0, 0)
        serial_port_controls.addWidget(self.combo_box_serial_port_name)
        serial_refresh_row = QHBoxLayout()
        serial_refresh_row.addStretch(1)
        serial_refresh_row.addWidget(self.push_button_refresh_serial_port_list)
        serial_port_controls.addLayout(serial_refresh_row)

        self.combo_box_baud_rate_bits_per_second = QComboBox()
        for baud_rate in _STANDARD_BAUD_RATES:
            self.combo_box_baud_rate_bits_per_second.addItem(str(baud_rate), baud_rate)
        self.combo_box_baud_rate_bits_per_second.addItem(_CUSTOM_BAUD_LABEL, None)
        self.combo_box_baud_rate_bits_per_second.setCurrentText("115200")
        self.spin_box_custom_baud_rate_bits_per_second = QSpinBox()
        self.spin_box_custom_baud_rate_bits_per_second.setRange(50, 12_000_000)
        self.spin_box_custom_baud_rate_bits_per_second.setValue(115200)
        self.spin_box_custom_baud_rate_bits_per_second.setEnabled(False)
        baud_row = QHBoxLayout()
        baud_row.addWidget(self.combo_box_baud_rate_bits_per_second, stretch=1)
        baud_row.addWidget(QLabel("Custom:"))
        baud_row.addWidget(self.spin_box_custom_baud_rate_bits_per_second)

        self.spin_box_serial_read_timeout_milliseconds = self._timeout_spin(100)
        self.spin_box_serial_write_timeout_milliseconds = self._timeout_spin(100)
        serial_form = QFormLayout(self.serial_settings_group_box)
        serial_form.addRow("COM port:", serial_port_controls)
        serial_form.addRow("Baud rate:", baud_row)
        serial_form.addRow(
            "Read timeout:", self.spin_box_serial_read_timeout_milliseconds
        )
        serial_form.addRow(
            "Write timeout:", self.spin_box_serial_write_timeout_milliseconds
        )

        self.ethernet_settings_group_box = QGroupBox("Ethernet (TCP)")
        self.combo_box_local_network_interface = QComboBox()
        self.combo_box_local_network_interface.setMinimumWidth(0)
        self.combo_box_local_network_interface.setSizePolicy(
            QSizePolicy.Policy.Ignored,
            QSizePolicy.Policy.Fixed,
        )
        self.combo_box_local_network_interface.addItem(
            "(refresh to list networks)", ("", "")
        )
        self.push_button_refresh_network_interface_list = QPushButton(
            "Refresh networks"
        )
        self.push_button_refresh_network_interface_list.clicked.connect(
            self.refresh_networks_requested
        )
        network_controls = QVBoxLayout()
        network_controls.setContentsMargins(0, 0, 0, 0)
        network_controls.addWidget(self.combo_box_local_network_interface)
        network_refresh_row = QHBoxLayout()
        network_refresh_row.addStretch(1)
        network_refresh_row.addWidget(
            self.push_button_refresh_network_interface_list
        )
        network_controls.addLayout(network_refresh_row)

        self.label_local_network_validation = QLabel()
        self.label_local_network_validation.setWordWrap(True)
        self.push_button_open_windows_network_connections = QPushButton(
            "Open Windows Network Connections"
        )
        self.push_button_open_windows_network_connections.clicked.connect(
            self._open_windows_network_connections
        )

        self.line_edit_device_ip_address = QLineEdit("192.168.1.110")
        self.spin_box_modbus_tcp_port_number = QSpinBox()
        self.spin_box_modbus_tcp_port_number.setRange(1, 65535)
        self.spin_box_modbus_tcp_port_number.setValue(502)
        self.spin_box_ethernet_connect_timeout_milliseconds = self._timeout_spin(100)
        self.spin_box_ethernet_read_timeout_milliseconds = self._timeout_spin(100)
        self.spin_box_ethernet_write_timeout_milliseconds = self._timeout_spin(100)
        ethernet_form = QFormLayout(self.ethernet_settings_group_box)
        ethernet_form.addRow("Local network:", network_controls)
        ethernet_form.addRow("", self.label_local_network_validation)
        ethernet_form.addRow(
            "", self.push_button_open_windows_network_connections
        )
        ethernet_form.addRow("Device IP:", self.line_edit_device_ip_address)
        ethernet_form.addRow("TCP port:", self.spin_box_modbus_tcp_port_number)
        ethernet_form.addRow(
            "Connect timeout:", self.spin_box_ethernet_connect_timeout_milliseconds
        )
        ethernet_form.addRow(
            "Read timeout:", self.spin_box_ethernet_read_timeout_milliseconds
        )
        ethernet_form.addRow(
            "Write timeout:", self.spin_box_ethernet_write_timeout_milliseconds
        )

        self.spin_box_modbus_transaction_retry_count = QSpinBox()
        self.spin_box_modbus_transaction_retry_count.setRange(1, 20)
        self.spin_box_modbus_transaction_retry_count.setValue(3)
        self.spin_box_command_execution_timeout_milliseconds = self._timeout_spin(
            10_000
        )
        common_form = QFormLayout()
        common_form.addRow(
            "Command timeout:",
            self.spin_box_command_execution_timeout_milliseconds,
        )
        common_form.addRow(
            "Retries (per transaction):",
            self.spin_box_modbus_transaction_retry_count,
        )

        layout = QVBoxLayout(self)
        layout.addWidget(QLabel("Communication"))
        layout.addLayout(kind_row)
        layout.addWidget(self.serial_settings_group_box)
        layout.addWidget(self.ethernet_settings_group_box)
        layout.addLayout(common_form)

        self.radio_button_serial_rtu.toggled.connect(
            self._update_link_kind_visibility
        )
        self.combo_box_baud_rate_bits_per_second.currentIndexChanged.connect(
            self._update_custom_baud_enabled
        )
        self.combo_box_local_network_interface.currentIndexChanged.connect(
            self._update_local_network_validation
        )
        self._update_link_kind_visibility()
        self._update_custom_baud_enabled()
        self._update_local_network_validation()

    @staticmethod
    def _timeout_spin(default: int) -> QSpinBox:
        spin = QSpinBox()
        spin.setRange(10, 60_000)
        spin.setValue(default)
        spin.setSuffix(" ms")
        return spin

    def _update_link_kind_visibility(self, *_args) -> None:
        serial = self.radio_button_serial_rtu.isChecked()
        self.serial_settings_group_box.setVisible(serial)
        self.ethernet_settings_group_box.setVisible(not serial)

    def _update_custom_baud_enabled(self, *_args) -> None:
        self.spin_box_custom_baud_rate_bits_per_second.setEnabled(
            self.combo_box_baud_rate_bits_per_second.currentData() is None
        )

    def set_available_serial_ports(self, ports: list[dict[str, object]]) -> None:
        previous = self.combo_box_serial_port_name.currentData()
        self.combo_box_serial_port_name.clear()
        if not ports:
            self.combo_box_serial_port_name.addItem("(no serial ports found)", "")
            return
        for port in ports:
            device_name = str(port.get("device") or "")
            description = str(port.get("description") or "")
            label = (
                f"{device_name} | {description}"
                if description and description != device_name
                else device_name
            )
            self.combo_box_serial_port_name.addItem(label, device_name)
        index = self.combo_box_serial_port_name.findData(previous)
        if index >= 0:
            self.combo_box_serial_port_name.setCurrentIndex(index)

    def set_available_network_interfaces(
        self, interfaces: list[dict[str, object]]
    ) -> None:
        previous = self.combo_box_local_network_interface.currentData()
        self.combo_box_local_network_interface.clear()
        selected_interfaces = self._one_preferred_ipv4_per_interface(interfaces)
        if not selected_interfaces:
            self.combo_box_local_network_interface.addItem(
                "(no IPv4 networks found)", ("", "")
            )
            self._update_local_network_validation()
            return
        for interface in selected_interfaces:
            name = str(interface.get("name") or "")
            description = str(interface.get("description") or "")
            ipv4 = str(interface.get("ipv4") or "")
            identity = f"{name} | {description}" if description else name
            self.combo_box_local_network_interface.addItem(
                f"{identity} | {ipv4}", (name, ipv4)
            )
        index = self.combo_box_local_network_interface.findData(previous)
        if index >= 0:
            self.combo_box_local_network_interface.setCurrentIndex(index)
        else:
            for candidate_index in range(
                self.combo_box_local_network_interface.count()
            ):
                candidate = self.combo_box_local_network_interface.itemData(
                    candidate_index
                )
                if (
                    isinstance(candidate, tuple)
                    and len(candidate) == 2
                    and str(candidate[1]) == _REQUIRED_LOCAL_IPV4_ADDRESS
                ):
                    self.combo_box_local_network_interface.setCurrentIndex(
                        candidate_index
                    )
                    break
        self._update_local_network_validation()

    @staticmethod
    def _one_preferred_ipv4_per_interface(
        interfaces: list[dict[str, object]],
    ) -> list[dict[str, object]]:
        """Collapse multiple IPv4 addresses reported for one Windows adapter."""
        grouped: dict[str, list[dict[str, object]]] = {}
        order: list[str] = []
        for interface in interfaces:
            name = str(interface.get("name") or "").strip()
            if not name:
                continue
            if name not in grouped:
                grouped[name] = []
                order.append(name)
            grouped[name].append(interface)

        def preference(item: dict[str, object]) -> tuple[int, str]:
            ipv4 = str(item.get("ipv4") or "")
            if ipv4 == _REQUIRED_LOCAL_IPV4_ADDRESS:
                return (0, ipv4)
            if ipv4 and not ipv4.startswith("169.254."):
                return (1, ipv4)
            return (2, ipv4)

        return [min(grouped[name], key=preference) for name in order]

    def _update_local_network_validation(self, *_args) -> None:
        data = self.combo_box_local_network_interface.currentData()
        selected_ip = ""
        if isinstance(data, tuple) and len(data) == 2:
            selected_ip = str(data[1])
        if selected_ip == _REQUIRED_LOCAL_IPV4_ADDRESS:
            self.label_local_network_validation.setText(
                f"Local IPv4 is correct: {_REQUIRED_LOCAL_IPV4_ADDRESS}"
            )
            self.label_local_network_validation.setStyleSheet(
                "QLabel { color: #147a28; font-weight: bold; }"
            )
            return
        actual = selected_ip or "not available"
        self.label_local_network_validation.setText(
            f"Problem: local IPv4 must be {_REQUIRED_LOCAL_IPV4_ADDRESS}; "
            f"selected adapter has {actual}."
        )
        self.label_local_network_validation.setStyleSheet(
            "QLabel { color: #c00000; font-weight: bold; }"
        )

    def _open_windows_network_connections(self) -> None:
        windows_10_or_newer = (
            sys.platform == "win32"
            and sys.getwindowsversion().major >= 10
        )
        if not windows_10_or_newer:
            self.label_local_network_validation.setText(
                "Opening Network Connections is supported only on Windows 10/11."
            )
            self.label_local_network_validation.setStyleSheet(
                "QLabel { color: #c00000; font-weight: bold; }"
            )
            return
        started = QProcess.startDetached("control.exe", ["ncpa.cpl"])
        ok = bool(started[0]) if isinstance(started, tuple) else bool(started)
        if not ok:
            self.label_local_network_validation.setText(
                "Could not open Windows Network Connections."
            )
            self.label_local_network_validation.setStyleSheet(
                "QLabel { color: #c00000; font-weight: bold; }"
            )

    def connect_cli_arguments(self) -> list[str]:
        retries = str(self.spin_box_modbus_transaction_retry_count.value())
        command_timeout = str(
            self.spin_box_command_execution_timeout_milliseconds.value()
        )
        if self.radio_button_serial_rtu.isChecked():
            port = str(self.combo_box_serial_port_name.currentData() or "").strip()
            if not port:
                raise ValueError("Select a serial port first.")
            baud_data = self.combo_box_baud_rate_bits_per_second.currentData()
            baud = (
                int(baud_data)
                if baud_data is not None
                else self.spin_box_custom_baud_rate_bits_per_second.value()
            )
            return [
                "--port", port,
                "--baud", str(baud),
                "--read-timeout-ms",
                str(self.spin_box_serial_read_timeout_milliseconds.value()),
                "--write-timeout-ms",
                str(self.spin_box_serial_write_timeout_milliseconds.value()),
                "--command-timeout-ms", command_timeout,
                "--retries", retries,
            ]

        device_ip = self.line_edit_device_ip_address.text().strip()
        if not device_ip:
            raise ValueError("Enter the device IP address first.")
        network_data = self.combo_box_local_network_interface.currentData()
        local_name = ""
        local_ip = ""
        if isinstance(network_data, tuple) and len(network_data) == 2:
            local_name, local_ip = str(network_data[0]), str(network_data[1])
        arguments = [
            "--device-ip", device_ip,
            "--tcp-port", str(self.spin_box_modbus_tcp_port_number.value()),
            "--connect-timeout-ms",
            str(self.spin_box_ethernet_connect_timeout_milliseconds.value()),
            "--read-timeout-ms",
            str(self.spin_box_ethernet_read_timeout_milliseconds.value()),
            "--write-timeout-ms",
            str(self.spin_box_ethernet_write_timeout_milliseconds.value()),
            "--command-timeout-ms", command_timeout,
            "--retries", retries,
        ]
        if local_name:
            arguments.extend(["--local-interface", local_name])
        if local_ip:
            arguments.extend(["--local-ip", local_ip])
        return arguments
