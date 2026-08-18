"""
Scan CodeGen JSON output and load parameter-list packages by DeviceId + version.

Expected layout under the JSON root folder:

  JSON/
    cg_database_deviceid.json
    parameter_list_01000/
      parameter_list_01000_00001/
        cg_parameter_list_01000_00001_info.json
        cg_parameter_list_01000_00001_parameter_list.json
    parameter_list_01001/
      ...
"""

from __future__ import annotations

import json
import re
from pathlib import Path

from core.codegen_parameter_list_models import (
    CodeGenDeviceDatabaseEntry,
    CodeGenParameterDefinition,
    CodeGenParameterListInfo,
    CodeGenParameterListPackage,
    ParameterAccessKind,
)

_DEVICE_FOLDER_NAME_PATTERN = re.compile(r"^parameter_list_(\d{5})$")
_VERSION_FOLDER_NAME_PATTERN = re.compile(r"^parameter_list_(\d{5})_(\d{5})$")
_INFO_FILE_NAME_PATTERN = re.compile(
    r"^cg_parameter_list_(\d{5})_(\d{5})_info\.json$"
)
_PARAMETER_LIST_FILE_NAME_PATTERN = re.compile(
    r"^cg_parameter_list_(\d{5})_(\d{5})_parameter_list\.json$"
)


class CodeGenParameterListCatalogError(Exception):
    """Raised when catalog files are missing or malformed."""


class CodeGenParameterListCatalog:
    """
    Index of all parameter-list versions found under a CodeGen JSON root.
    """

    def __init__(self, codegen_json_root_directory: Path) -> None:
        self.codegen_json_root_directory = Path(codegen_json_root_directory).resolve()
        self._device_database_entries: list[CodeGenDeviceDatabaseEntry] = []
        # (device_id, version) -> package directory path (lazy load of full JSON)
        self._package_directory_by_device_id_and_version: dict[
            tuple[int, int], Path
        ] = {}

    def scan_catalog_from_disk(self) -> None:
        """Read device database and discover all version folders."""
        if not self.codegen_json_root_directory.is_dir():
            raise CodeGenParameterListCatalogError(
                f"CodeGen JSON root is not a directory: {self.codegen_json_root_directory}"
            )

        self._device_database_entries = self._load_device_database_file()
        self._package_directory_by_device_id_and_version = (
            self._discover_package_directories()
        )

    def list_device_database_entries(self) -> list[CodeGenDeviceDatabaseEntry]:
        return list(self._device_database_entries)

    def list_available_versions_for_device_id(self, device_id: int) -> list[int]:
        versions = [
            version
            for (indexed_device_id, version) in self._package_directory_by_device_id_and_version
            if indexed_device_id == device_id
        ]
        return sorted(versions)

    def has_parameter_list_package(self, device_id: int, parameter_list_version: int) -> bool:
        return (
            device_id,
            parameter_list_version,
        ) in self._package_directory_by_device_id_and_version

    def load_parameter_list_package(
        self, device_id: int, parameter_list_version: int
    ) -> CodeGenParameterListPackage:
        """Load info + full parameter array for one device version."""
        key = (device_id, parameter_list_version)
        package_directory = self._package_directory_by_device_id_and_version.get(key)
        if package_directory is None:
            raise CodeGenParameterListCatalogError(
                f"No parameter list package for device_id={device_id}, "
                f"version={parameter_list_version} under {self.codegen_json_root_directory}"
            )

        info = self._load_info_json(
            package_directory=package_directory,
            expected_device_id=device_id,
            expected_version=parameter_list_version,
        )
        parameters = self._load_parameter_list_json(
            package_directory=package_directory,
            expected_device_id=device_id,
            expected_version=parameter_list_version,
        )

        return CodeGenParameterListPackage(
            device_id=device_id,
            parameter_list_version=parameter_list_version,
            package_directory_path=package_directory,
            info=info,
            parameters=parameters,
        )

    def find_device_database_entry_by_device_id(
        self, device_id: int
    ) -> CodeGenDeviceDatabaseEntry | None:
        for entry in self._device_database_entries:
            if entry.device_id == device_id:
                return entry
        return None

    # -------------------------------------------------------------------------
    # private
    # -------------------------------------------------------------------------

    def _load_device_database_file(self) -> list[CodeGenDeviceDatabaseEntry]:
        database_path = self.codegen_json_root_directory / "cg_database_deviceid.json"
        if not database_path.is_file():
            raise CodeGenParameterListCatalogError(
                f"Missing device database file: {database_path}"
            )

        raw_list = self._read_json_file(database_path)
        if not isinstance(raw_list, list):
            raise CodeGenParameterListCatalogError(
                f"Device database must be a JSON array: {database_path}"
            )

        entries: list[CodeGenDeviceDatabaseEntry] = []
        for raw_item in raw_list:
            if not isinstance(raw_item, dict):
                continue
            # CodeGen uses typo "Decription" — accept both spellings
            description = str(
                raw_item.get("Description")
                or raw_item.get("Decription")
                or ""
            )
            entries.append(
                CodeGenDeviceDatabaseEntry(
                    group_name=str(raw_item.get("Group", "")),
                    device_name=str(raw_item.get("Name", "")),
                    device_id=int(raw_item["DeviceId"]),
                    description=description,
                )
            )
        return entries

    def _discover_package_directories(self) -> dict[tuple[int, int], Path]:
        discovered: dict[tuple[int, int], Path] = {}

        for device_folder in sorted(self.codegen_json_root_directory.iterdir()):
            if not device_folder.is_dir():
                continue
            device_match = _DEVICE_FOLDER_NAME_PATTERN.match(device_folder.name)
            if not device_match:
                continue
            device_id_from_folder = int(device_match.group(1))

            for version_folder in sorted(device_folder.iterdir()):
                if not version_folder.is_dir():
                    continue
                version_match = _VERSION_FOLDER_NAME_PATTERN.match(version_folder.name)
                if not version_match:
                    continue
                device_id_in_version_name = int(version_match.group(1))
                version = int(version_match.group(2))
                if device_id_in_version_name != device_id_from_folder:
                    continue

                # Require both expected files to exist
                info_name = (
                    f"cg_parameter_list_{device_id_from_folder:05d}_"
                    f"{version:05d}_info.json"
                )
                list_name = (
                    f"cg_parameter_list_{device_id_from_folder:05d}_"
                    f"{version:05d}_parameter_list.json"
                )
                if not (version_folder / info_name).is_file():
                    continue
                if not (version_folder / list_name).is_file():
                    continue

                discovered[(device_id_from_folder, version)] = version_folder

        return discovered

    def _load_info_json(
        self,
        package_directory: Path,
        expected_device_id: int,
        expected_version: int,
    ) -> CodeGenParameterListInfo:
        info_path = (
            package_directory
            / f"cg_parameter_list_{expected_device_id:05d}_{expected_version:05d}_info.json"
        )
        raw = self._read_json_file(info_path)
        if not isinstance(raw, dict):
            raise CodeGenParameterListCatalogError(f"Info JSON must be an object: {info_path}")

        device_id = int(raw["DeviceId"])
        if device_id != expected_device_id:
            raise CodeGenParameterListCatalogError(
                f"DeviceId mismatch in {info_path}: file={device_id}, folder={expected_device_id}"
            )

        return CodeGenParameterListInfo(
            device_name=str(raw.get("Name", "")),
            device_id=device_id,
            downstream_quantity=int(raw.get("DownStreamQty", 0)),
            parameter_list_version=expected_version,
            info_json_file_path=info_path,
        )

    def _load_parameter_list_json(
        self,
        package_directory: Path,
        expected_device_id: int,
        expected_version: int,
    ) -> list[CodeGenParameterDefinition]:
        list_path = (
            package_directory
            / f"cg_parameter_list_{expected_device_id:05d}_"
            f"{expected_version:05d}_parameter_list.json"
        )
        raw_list = self._read_json_file(list_path)
        if not isinstance(raw_list, list):
            raise CodeGenParameterListCatalogError(
                f"Parameter list JSON must be an array: {list_path}"
            )

        parameters: list[CodeGenParameterDefinition] = []
        for raw_item in raw_list:
            if not isinstance(raw_item, dict):
                continue
            parameter_type_raw = str(raw_item.get("ParameterType", ""))
            parameters.append(
                CodeGenParameterDefinition(
                    parameter_name=str(raw_item.get("Name", "")),
                    modbus_register_size=int(raw_item.get("ModbusSize", 1)),
                    parameter_id=int(raw_item.get("ParameterID", -1)),
                    modbus_address=int(raw_item.get("ModbusAddr", -1)),
                    data_type_name=str(raw_item.get("DataType", "")),
                    parameter_type_raw_text=parameter_type_raw,
                    parameter_access_kind=ParameterAccessKind.from_codegen_parameter_type_string(
                        parameter_type_raw
                    ),
                    description=str(raw_item.get("Description", "")),
                    category_tag_1=str(raw_item.get("Tag1", "")),
                    tag_2=str(raw_item.get("Tag2", "")),
                    tag_3=str(raw_item.get("Tag3", "")),
                    tag_4=str(raw_item.get("Tag4", "")),
                    tag_5=str(raw_item.get("Tag5", "")),
                )
            )
        return parameters

    @staticmethod
    def _read_json_file(path: Path):
        try:
            return json.loads(path.read_text(encoding="utf-8"))
        except json.JSONDecodeError as exc:
            raise CodeGenParameterListCatalogError(
                f"Invalid JSON in {path}: {exc}"
            ) from exc
        except OSError as exc:
            raise CodeGenParameterListCatalogError(
                f"Cannot read {path}: {exc}"
            ) from exc
