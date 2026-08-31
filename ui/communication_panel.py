"""Communication form that only produces CLI arguments.

OS discovery and Modbus connection work are deliberately delegated to
``list-serial-ports``, ``list-networks`` and ``connect`` commands.
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
        self.combo_box_serial_port_name.setMinimumWidth(220)
        self.combo_box_serial_port_name.addItem("(refresh to list ports)", "")
        self.push_button_refresh_serial_port_list = QPushButton("Refresh ports")
        self.push_button_refresh_serial_port_list.clicked.connect(
            self.refresh_serial_ports_requested
        )
        serial_port_row = QHBoxLayout()
        serial_port_row.addWidget(self.combo_box_serial_port_name, stretch=1)
        serial_port_row.addWidget(self.push_button_refresh_serial_port_list)

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

        self.spin_box_serial_read_timeout_milliseconds = self._timeout_spin(1000)
        self.spin_box_serial_write_timeout_milliseconds = self._timeout_spin(1000)
        serial_form = QFormLayout(self.serial_settings_group_box)
        serial_form.addRow("COM port:", serial_port_row)
        serial_form.addRow("Baud rate:", baud_row)
        serial_form.addRow(
            "Read timeout:", self.spin_box_serial_read_timeout_milliseconds
        )
        serial_form.addRow(
            "Write timeout:", self.spin_box_serial_write_timeout_milliseconds
        )

        self.ethernet_settings_group_box = QGroupBox("Ethernet (TCP)")
        self.combo_box_local_network_interface = QComboBox()
        self.combo_box_local_network_interface.setMinimumWidth(260)
        self.combo_box_local_network_interface.addItem(
            "(refresh to list networks)", ("", "")
        )
        self.push_button_refresh_network_interface_list = QPushButton(
            "Refresh networks"
        )
        self.push_button_refresh_network_interface_list.clicked.connect(
            self.refresh_networks_requested
        )
        network_row = QHBoxLayout()
        network_row.addWidget(self.combo_box_local_network_interface, stretch=1)
        network_row.addWidget(self.push_button_refresh_network_interface_list)

        self.line_edit_device_ip_address = QLineEdit("192.168.1.110")
        self.spin_box_modbus_tcp_port_number = QSpinBox()
        self.spin_box_modbus_tcp_port_number.setRange(1, 65535)
        self.spin_box_modbus_tcp_port_number.setValue(502)
        self.spin_box_ethernet_connect_timeout_milliseconds = self._timeout_spin(2000)
        self.spin_box_ethernet_read_timeout_milliseconds = self._timeout_spin(1000)
        self.spin_box_ethernet_write_timeout_milliseconds = self._timeout_spin(1000)
        ethernet_form = QFormLayout(self.ethernet_settings_group_box)
        ethernet_form.addRow("Local network:", network_row)
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
        common_form = QFormLayout()
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
        self._update_link_kind_visibility()
        self._update_custom_baud_enabled()

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
        if not interfaces:
            self.combo_box_local_network_interface.addItem(
                "(no IPv4 networks found)", ("", "")
            )
            return
        for interface in interfaces:
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

    def connect_cli_arguments(self) -> list[str]:
        retries = str(self.spin_box_modbus_transaction_retry_count.value())
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
            "--retries", retries,
        ]
        if local_name:
            arguments.extend(["--local-interface", local_name])
        if local_ip:
            arguments.extend(["--local-ip", local_ip])
        return arguments
