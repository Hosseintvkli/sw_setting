"""
Load SETTING parameters for the connected device: catalog match + Modbus reads.

Reads are batched into consecutive holding-register ranges (max 125 per request)
to reduce round-trips versus one transaction per parameter.
"""

from __future__ import annotations

from collections.abc import Callable
from dataclasses import dataclass
from pathlib import Path

from core.codegen_parameter_list_catalog import (
    CodeGenParameterListCatalog,
    CodeGenParameterListCatalogError,
)
from core.codegen_parameter_list_models import (
    CodeGenParameterDefinition,
    CodeGenParameterListPackage,
    ParameterAccessKind,
)
from core.device_modbus_link import DeviceModbusLink, DeviceModbusLinkError
from core.modbus_register_value_codec import (
    ModbusRegisterValueCodecError,
    decode_parameter_value_from_holding_registers,
    format_decoded_parameter_value_for_display,
    register_count_for_data_type_name,
)

DEVICE_ID_HOLDING_REGISTER_ADDRESS = 0
PARAMETER_LIST_VERSION_HOLDING_REGISTER_ADDRESS = 1
FIRMWARE_VERSION_MAJOR_HOLDING_REGISTER_ADDRESS = 2
FIRMWARE_VERSION_MINOR_HOLDING_REGISTER_ADDRESS = 3
SERIAL_NUMBER_HOLDING_REGISTER_ADDRESS = 7
SERIAL_NUMBER_REGISTER_COUNT = 2
HARDWARE_VERSION_MAJOR_HOLDING_REGISTER_ADDRESS = 9
HARDWARE_VERSION_MINOR_HOLDING_REGISTER_ADDRESS = 10
MAX_HOLDING_REGISTERS_PER_MODBUS_READ = 125

ProgressCallback = Callable[[int, int, str], None]


def get_fixed_codegen_json_root_directory() -> Path:
    package_root_directory = Path(__file__).resolve().parent.parent
    return package_root_directory / "files" / "codegen_output" / "JSON"


@dataclass
class DeviceMonitoringHeaderValues:
    """Small set of monitoring fields shown above the settings tree."""

    modbus_slave_unit_identifier: int
    device_id: int
    parameter_list_version: int
    serial_number: int | None
    hardware_version_text: str
    firmware_version_text: str


@dataclass
class SettingParameterTreeLeafValue:
    parameter: CodeGenParameterDefinition
    decoded_value: int | float | None
    display_value_text: str
    read_error_message: str | None = None


@dataclass
class DeviceSettingTreeLoadResult:
    device_id_from_device: int
    parameter_list_version_from_device: int
    parameter_list_package: CodeGenParameterListPackage
    setting_leaf_values: list[SettingParameterTreeLeafValue]
    monitoring_header_values: DeviceMonitoringHeaderValues


class DeviceSettingTreeLoaderError(Exception):
    pass


class DeviceSettingTreeLoader:
    def __init__(
        self,
        device_modbus_link: DeviceModbusLink,
        modbus_slave_unit_identifier: int,
        codegen_json_root_directory: Path | None = None,
    ) -> None:
        self._device_modbus_link = device_modbus_link
        self._modbus_slave_unit_identifier = modbus_slave_unit_identifier
        self._codegen_json_root_directory = (
            Path(codegen_json_root_directory)
            if codegen_json_root_directory is not None
            else get_fixed_codegen_json_root_directory()
        )

    def load_setting_tree_from_connected_device(
        self,
        progress_callback: ProgressCallback | None = None,
    ) -> DeviceSettingTreeLoadResult:
        if not self._device_modbus_link.is_connected:
            raise DeviceSettingTreeLoaderError("Device is not connected.")

        def report(step: int, total: int, message: str) -> None:
            if progress_callback is not None:
                progress_callback(step, total, message)

        report(0, 1, "Reading DeviceId and ParameterListVersion...")
        try:
            device_id = self._device_modbus_link.read_holding_register_u16(
                DEVICE_ID_HOLDING_REGISTER_ADDRESS
            )
            parameter_list_version = self._device_modbus_link.read_holding_register_u16(
                PARAMETER_LIST_VERSION_HOLDING_REGISTER_ADDRESS
            )
        except DeviceModbusLinkError as exc:
            raise DeviceSettingTreeLoaderError(
                f"Failed to read DeviceId/ParameterListVersion: {exc}"
            ) from exc

        monitoring_header_values = self._read_monitoring_header_values(
            device_id=device_id,
            parameter_list_version=parameter_list_version,
        )

        report(0, 1, "Loading parameter-list JSON from catalog...")
        try:
            catalog = CodeGenParameterListCatalog(self._codegen_json_root_directory)
            catalog.scan_catalog_from_disk()
            package = catalog.load_parameter_list_package(
                device_id=device_id,
                parameter_list_version=parameter_list_version,
            )
        except CodeGenParameterListCatalogError as exc:
            raise DeviceSettingTreeLoaderError(
                f"Catalog/JSON mismatch for DeviceId={device_id}, "
                f"Version={parameter_list_version}: {exc}"
            ) from exc

        setting_parameters = [
            parameter
            for parameter in package.parameters
            if parameter.parameter_access_kind == ParameterAccessKind.SETTING_READ_WRITE
        ]

        register_map = self._read_holding_registers_for_parameters_batched(
            setting_parameters,
            progress_callback=progress_callback,
        )

        setting_leaf_values: list[SettingParameterTreeLeafValue] = []
        total_params = max(len(setting_parameters), 1)
        for index, parameter in enumerate(setting_parameters):
            if index % 50 == 0:
                report(
                    index,
                    total_params,
                    f"Decoding settings... {index}/{total_params}",
                )
            setting_leaf_values.append(
                self._decode_setting_parameter_from_register_map(
                    parameter, register_map
                )
            )

        report(total_params, total_params, "Done.")
        return DeviceSettingTreeLoadResult(
            device_id_from_device=device_id,
            parameter_list_version_from_device=parameter_list_version,
            parameter_list_package=package,
            setting_leaf_values=setting_leaf_values,
            monitoring_header_values=monitoring_header_values,
        )

    def _read_monitoring_header_values(
        self, device_id: int, parameter_list_version: int
    ) -> DeviceMonitoringHeaderValues:
        firmware_version_text = "—"
        hardware_version_text = "—"
        serial_number: int | None = None

        try:
            fw_major = self._device_modbus_link.read_holding_register_u16(
                FIRMWARE_VERSION_MAJOR_HOLDING_REGISTER_ADDRESS
            )
            fw_minor = self._device_modbus_link.read_holding_register_u16(
                FIRMWARE_VERSION_MINOR_HOLDING_REGISTER_ADDRESS
            )
            firmware_version_text = f"{fw_major}.{fw_minor}"
        except DeviceModbusLinkError:
            pass

        try:
            hw_major = self._device_modbus_link.read_holding_register_u16(
                HARDWARE_VERSION_MAJOR_HOLDING_REGISTER_ADDRESS
            )
            hw_minor = self._device_modbus_link.read_holding_register_u16(
                HARDWARE_VERSION_MINOR_HOLDING_REGISTER_ADDRESS
            )
            hardware_version_text = f"{hw_major}.{hw_minor}"
        except DeviceModbusLinkError:
            pass

        try:
            serial_regs = self._device_modbus_link.read_holding_registers_u16(
                SERIAL_NUMBER_HOLDING_REGISTER_ADDRESS,
                SERIAL_NUMBER_REGISTER_COUNT,
            )
            serial_number = int(
                decode_parameter_value_from_holding_registers("U32", serial_regs)
            )
        except (DeviceModbusLinkError, ModbusRegisterValueCodecError):
            serial_number = None

        return DeviceMonitoringHeaderValues(
            modbus_slave_unit_identifier=self._modbus_slave_unit_identifier,
            device_id=device_id,
            parameter_list_version=parameter_list_version,
            serial_number=serial_number,
            hardware_version_text=hardware_version_text,
            firmware_version_text=firmware_version_text,
        )

    def _register_count_for_parameter(self, parameter: CodeGenParameterDefinition) -> int:
        if parameter.modbus_register_size > 0:
            return parameter.modbus_register_size
        return register_count_for_data_type_name(parameter.data_type_name)

    def _read_holding_registers_for_parameters_batched(
        self,
        parameters: list[CodeGenParameterDefinition],
        progress_callback: ProgressCallback | None,
    ) -> dict[int, int]:
        intervals: list[tuple[int, int]] = []
        for parameter in parameters:
            try:
                count = self._register_count_for_parameter(parameter)
            except ModbusRegisterValueCodecError:
                continue
            start = parameter.modbus_address
            intervals.append((start, start + count))

        merged_intervals = _merge_half_open_intervals(intervals)
        total_registers_to_read = sum(end - start for start, end in merged_intervals)
        total_registers_to_read = max(total_registers_to_read, 1)

        register_map: dict[int, int] = {}
        registers_done = 0

        def report_read_progress(message: str) -> None:
            if progress_callback is not None:
                progress_callback(registers_done, total_registers_to_read, message)

        report_read_progress("Reading holding registers (batched)...")

        for range_start, range_end in merged_intervals:
            address = range_start
            while address < range_end:
                count = min(MAX_HOLDING_REGISTERS_PER_MODBUS_READ, range_end - address)
                try:
                    values = self._device_modbus_link.read_holding_registers_u16(
                        modbus_start_address=address,
                        register_count=count,
                    )
                    for offset, value in enumerate(values):
                        register_map[address + offset] = int(value) & 0xFFFF
                except DeviceModbusLinkError:
                    pass
                registers_done += count
                address += count
                report_read_progress(
                    f"Read registers... {registers_done}/{total_registers_to_read}"
                )

        return register_map

    def _decode_setting_parameter_from_register_map(
        self,
        parameter: CodeGenParameterDefinition,
        register_map: dict[int, int],
    ) -> SettingParameterTreeLeafValue:
        try:
            count = self._register_count_for_parameter(parameter)
            registers: list[int] = []
            for offset in range(count):
                address = parameter.modbus_address + offset
                if address not in register_map:
                    raise DeviceModbusLinkError(
                        f"Missing register data at address {address}"
                    )
                registers.append(register_map[address])

            decoded = decode_parameter_value_from_holding_registers(
                parameter.data_type_name, registers
            )
            text = format_decoded_parameter_value_for_display(
                parameter.data_type_name, decoded
            )
            return SettingParameterTreeLeafValue(
                parameter=parameter,
                decoded_value=decoded,
                display_value_text=text,
            )
        except (DeviceModbusLinkError, ModbusRegisterValueCodecError) as exc:
            return SettingParameterTreeLeafValue(
                parameter=parameter,
                decoded_value=None,
                display_value_text="—",
                read_error_message=str(exc),
            )


def _merge_half_open_intervals(
    intervals: list[tuple[int, int]],
) -> list[tuple[int, int]]:
    if not intervals:
        return []
    ordered = sorted(intervals, key=lambda item: item[0])
    merged: list[list[int]] = [[ordered[0][0], ordered[0][1]]]
    for start, end in ordered[1:]:
        last = merged[-1]
        if start <= last[1]:
            last[1] = max(last[1], end)
        else:
            merged.append([start, end])
    return [(item[0], item[1]) for item in merged]
