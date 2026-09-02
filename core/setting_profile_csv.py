"""
CSV profiles: load/save values for settings and command registers.
"""

from __future__ import annotations

import csv
import re
from dataclasses import dataclass
from pathlib import Path

from core.codegen_parameter_list_models import (
    CodeGenParameterDefinition,
    CodeGenParameterListPackage,
    ParameterAccessKind,
)
from core.parameter_value_validation import (
    ParameterValueValidationError,
    parse_and_validate_parameter_value_text,
)

_ARRAY_NAME_PATTERN = re.compile(r"^(?P<base>.+)\[(?P<index>\d+)\]$")


@dataclass(frozen=True)
class SettingProfileAssignment:
    """One concrete setting or command target after CSV expansion."""

    parameter_name: str
    value_text: str
    parsed_value: int | float
    parameter_definition: CodeGenParameterDefinition
    source_csv_line_number: int


@dataclass
class SettingProfileParseIssue:
    source_csv_line_number: int
    message: str


@dataclass
class SettingProfileParseResult:
    assignments: list[SettingProfileAssignment]
    issues: list[SettingProfileParseIssue]


def build_setting_parameter_definition_by_name(
    parameter_list_package: CodeGenParameterListPackage,
) -> dict[str, CodeGenParameterDefinition]:
    result: dict[str, CodeGenParameterDefinition] = {}
    for parameter in parameter_list_package.parameters:
        if parameter.parameter_access_kind != ParameterAccessKind.SETTING_READ_WRITE:
            continue
        result[parameter.parameter_name] = parameter
    return result


def build_array_base_name_to_sorted_indices(
    setting_parameter_by_name: dict[str, CodeGenParameterDefinition],
) -> dict[str, list[int]]:
    arrays: dict[str, list[int]] = {}
    for parameter_name in setting_parameter_by_name:
        match = _ARRAY_NAME_PATTERN.fullmatch(parameter_name)
        if not match:
            continue
        base_name = match.group("base")
        index = int(match.group("index"))
        arrays.setdefault(base_name, []).append(index)
    for base_name in arrays:
        arrays[base_name] = sorted(set(arrays[base_name]))
    return arrays


def load_setting_profile_assignments_from_csv(
    csv_file_path: Path,
    parameter_list_package: CodeGenParameterListPackage,
    *,
    include_commands: bool = False,
) -> SettingProfileParseResult:
    """
    Parse CSV into validated assignments.

    Row forms:
      Name,value
      ArrayName[start],v0,v1,v2,...  -> ArrayName[start], ArrayName[start+1], ...
      CommandName,value
    """
    profile_parameter_by_name = build_setting_parameter_definition_by_name(
        parameter_list_package
    )
    if include_commands:
        profile_parameter_by_name.update(
            {
                parameter.parameter_name: parameter
                for parameter in parameter_list_package.parameters
                if parameter.parameter_access_kind == ParameterAccessKind.COMMAND_WRITE
            }
        )
    array_indices = build_array_base_name_to_sorted_indices(profile_parameter_by_name)

    assignments: list[SettingProfileAssignment] = []
    issues: list[SettingProfileParseIssue] = []

    try:
        raw_text = csv_file_path.read_text(encoding="utf-8-sig")
    except OSError as exc:
        issues.append(
            SettingProfileParseIssue(0, f"Cannot read CSV file: {exc}")
        )
        return SettingProfileParseResult(assignments=[], issues=issues)

    lines = raw_text.splitlines()
    reader = csv.reader(lines)

    for line_number, row in enumerate(reader, start=1):
        if not row:
            continue
        # skip empty / comment lines
        if len(row) == 1 and not row[0].strip():
            continue
        if row[0].strip().startswith("#"):
            continue

        parameter_name = row[0].strip()
        value_cells = [cell.strip() for cell in row[1:]]
        if not parameter_name:
            issues.append(
                SettingProfileParseIssue(line_number, "Missing parameter name.")
            )
            continue
        if not value_cells or all(value == "" for value in value_cells):
            issues.append(
                SettingProfileParseIssue(
                    line_number, f"No value cells for {parameter_name!r}."
                )
            )
            continue
        if any(value == "" for value in value_cells):
            issues.append(
                SettingProfileParseIssue(
                    line_number,
                    f"Empty value cell in row for {parameter_name!r}.",
                )
            )
            continue

        array_match = _ARRAY_NAME_PATTERN.fullmatch(parameter_name)
        if array_match and len(value_cells) > 1:
            base_name = array_match.group("base")
            start_index = int(array_match.group("index"))
            known_indices = array_indices.get(base_name, [])
            if not known_indices:
                issues.append(
                    SettingProfileParseIssue(
                        line_number,
                        f"Array base {base_name!r} not found among allowed "
                        "profile parameters.",
                    )
                )
                continue
            max_index = max(known_indices)
            for offset, value_text in enumerate(value_cells):
                target_index = start_index + offset
                target_name = f"{base_name}[{target_index}]"
                if target_index not in known_indices or target_index > max_index:
                    issues.append(
                        SettingProfileParseIssue(
                            line_number,
                            f"Array index out of range: {target_name} "
                            f"(valid indices for {base_name}: "
                            f"{known_indices[0]}..{max_index}).",
                        )
                    )
                    continue
                _append_single_assignment(
                    assignments=assignments,
                    issues=issues,
                    profile_parameter_by_name=profile_parameter_by_name,
                    parameter_name=target_name,
                    value_text=value_text,
                    source_csv_line_number=line_number,
                )
        else:
            # Single value (scalar or one array element)
            if len(value_cells) != 1:
                # Non-array name with multiple values is invalid
                if not array_match:
                    issues.append(
                        SettingProfileParseIssue(
                            line_number,
                            f"Multiple values for non-array parameter {parameter_name!r}.",
                        )
                    )
                    continue
            _append_single_assignment(
                assignments=assignments,
                issues=issues,
                profile_parameter_by_name=profile_parameter_by_name,
                parameter_name=parameter_name,
                value_text=value_cells[0],
                source_csv_line_number=line_number,
            )

    return SettingProfileParseResult(assignments=assignments, issues=issues)


def _append_single_assignment(
    *,
    assignments: list[SettingProfileAssignment],
    issues: list[SettingProfileParseIssue],
    profile_parameter_by_name: dict[str, CodeGenParameterDefinition],
    parameter_name: str,
    value_text: str,
    source_csv_line_number: int,
) -> None:
    definition = profile_parameter_by_name.get(parameter_name)
    if definition is None:
        issues.append(
            SettingProfileParseIssue(
                source_csv_line_number,
                f"Parameter {parameter_name!r} is not allowed in this profile.",
            )
        )
        return
    try:
        parsed_value = parse_and_validate_parameter_value_text(
            definition.data_type_name, value_text
        )
    except ParameterValueValidationError as exc:
        issues.append(
            SettingProfileParseIssue(
                source_csv_line_number,
                f"{parameter_name}: {exc}",
            )
        )
        return

    assignments.append(
        SettingProfileAssignment(
            parameter_name=parameter_name,
            value_text=value_text,
            parsed_value=parsed_value,
            parameter_definition=definition,
            source_csv_line_number=source_csv_line_number,
        )
    )


def save_setting_profile_csv(
    csv_file_path: Path,
    rows: list[tuple[str, str]],
) -> None:
    """Write Name,Value rows (UTF-8)."""
    csv_file_path.parent.mkdir(parents=True, exist_ok=True)
    with csv_file_path.open("w", encoding="utf-8", newline="") as file_handle:
        writer = csv.writer(file_handle)
        for parameter_name, value_text in rows:
            writer.writerow([parameter_name, value_text])
