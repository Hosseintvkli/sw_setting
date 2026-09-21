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
PROGRESS_TOTAL = 100
PROGRESS_IDENTIFICATION_DONE = 10
PROGRESS_HEADER_DONE = 20
PROGRESS_CATALOG_DONE = 30
PROGRESS_REGISTER_READS_DONE = 85

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

        report(0, PROGRESS_TOTAL, "Reading DeviceId and ParameterListVersion...")
        unit = self._modbus_slave_unit_identifier
        try:
            device_id = self._device_modbus_link.read_holding_register_u16(
                DEVICE_ID_HOLDING_REGISTER_ADDRESS,
                modbus_unit_identifier=unit,
            )
            parameter_list_version = self._device_modbus_link.read_holding_register_u16(
                PARAMETER_LIST_VERSION_HOLDING_REGISTER_ADDRESS,
                modbus_unit_identifier=unit,
            )
        except DeviceModbusLinkError as exc:
            raise DeviceSettingTreeLoaderError(
                f"Failed to read DeviceId/ParameterListVersion: {exc}"
            ) from exc

        report(
            PROGRESS_IDENTIFICATION_DONE,
            PROGRESS_TOTAL,
            "Reading monitoring header...",
        )
        monitoring_header_values = self._read_monitoring_header_values(
            device_id=device_id,
            parameter_list_version=parameter_list_version,
        )

        report(
            PROGRESS_HEADER_DONE,
            PROGRESS_TOTAL,
            "Loading parameter-list JSON from catalog...",
        )
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

        def report_register_progress(current: int, total: int, message: str) -> None:
            safe_total = max(total, 1)
            phase_size = PROGRESS_REGISTER_READS_DONE - PROGRESS_CATALOG_DONE
            global_current = PROGRESS_CATALOG_DONE + int(
                phase_size * min(max(current, 0), safe_total) / safe_total
            )
            report(global_current, PROGRESS_TOTAL, message)

        report(
            PROGRESS_CATALOG_DONE,
            PROGRESS_TOTAL,
            "Reading holding registers (batched)...",
        )
        register_map, register_error_map = (
            self._read_holding_registers_for_parameters_batched(
                setting_parameters,
                progress_callback=report_register_progress,
            )
        )

        setting_leaf_values: list[SettingParameterTreeLeafValue] = []
        total_params = max(len(setting_parameters), 1)
        for index, parameter in enumerate(setting_parameters):
            if index % 50 == 0:
                decode_progress = PROGRESS_REGISTER_READS_DONE + int(
                    (PROGRESS_TOTAL - PROGRESS_REGISTER_READS_DONE)
                    * index
                    / total_params
                )
                report(
                    decode_progress,
                    PROGRESS_TOTAL,
                    f"Decoding settings... {index}/{total_params}",
                )
            setting_leaf_values.append(
                self._decode_setting_parameter_from_register_map(
                    parameter,
                    register_map,
                    register_error_map,
                )
            )

        report(PROGRESS_TOTAL, PROGRESS_TOTAL, "Done.")
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
                FIRMWARE_VERSION_MAJOR_HOLDING_REGISTER_ADDRESS,
                modbus_unit_identifier=self._modbus_slave_unit_identifier,
            )
            fw_minor = self._device_modbus_link.read_holding_register_u16(
                FIRMWARE_VERSION_MINOR_HOLDING_REGISTER_ADDRESS,
                modbus_unit_identifier=self._modbus_slave_unit_identifier,
            )
            firmware_version_text = f"{fw_major}.{fw_minor}"
        except DeviceModbusLinkError:
            pass

        try:
            hw_major = self._device_modbus_link.read_holding_register_u16(
                HARDWARE_VERSION_MAJOR_HOLDING_REGISTER_ADDRESS,
                modbus_unit_identifier=self._modbus_slave_unit_identifier,
            )
            hw_minor = self._device_modbus_link.read_holding_register_u16(
                HARDWARE_VERSION_MINOR_HOLDING_REGISTER_ADDRESS,
                modbus_unit_identifier=self._modbus_slave_unit_identifier,
            )
            hardware_version_text = f"{hw_major}.{hw_minor}"
        except DeviceModbusLinkError:
            pass

        try:
            serial_regs = self._device_modbus_link.read_holding_registers_u16(
                SERIAL_NUMBER_HOLDING_REGISTER_ADDRESS,
                SERIAL_NUMBER_REGISTER_COUNT,
                modbus_unit_identifier=self._modbus_slave_unit_identifier,
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
    ) -> tuple[dict[int, int], dict[int, str]]:
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
        register_error_map: dict[int, str] = {}
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
                        modbus_unit_identifier=self._modbus_slave_unit_identifier,
                    )
                    for offset, value in enumerate(values):
                        register_map[address + offset] = int(value) & 0xFFFF
                except DeviceModbusLinkError as exc:
                    range_end_inclusive = address + count - 1
                    error_message = (
                        f"Failed to read register range {address}.."
                        f"{range_end_inclusive}: {exc}"
                    )
                    for offset in range(count):
                        register_error_map[address + offset] = error_message
                registers_done += count
                address += count
                report_read_progress(
                    f"Read registers... {registers_done}/{total_registers_to_read}"
                )

        return register_map, register_error_map

    def _decode_setting_parameter_from_register_map(
        self,
        parameter: CodeGenParameterDefinition,
        register_map: dict[int, int],
        register_error_map: dict[int, str] | None = None,
    ) -> SettingParameterTreeLeafValue:
        try:
            count = self._register_count_for_parameter(parameter)
            registers: list[int] = []
            for offset in range(count):
                address = parameter.modbus_address + offset
                if address not in register_map:
                    original_read_error = (register_error_map or {}).get(address)
                    if original_read_error is not None:
                        raise DeviceModbusLinkError(original_read_error)
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
