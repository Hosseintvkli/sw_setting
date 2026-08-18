"""
Validate user-entered values against CodeGen DataType names.
Used by tree edits and CSV profile Apply/Verify.
"""

from __future__ import annotations


class ParameterValueValidationError(Exception):
    pass


def parse_and_validate_parameter_value_text(
    data_type_name: str, value_text: str
) -> int | float:
    """
    Parse text into int/float and enforce integer vs float and numeric range.
    Raises ParameterValueValidationError on failure.
    """
    normalized = (data_type_name or "").strip().upper()
    cleaned = (value_text or "").strip().replace(" ", "")
    if cleaned == "":
        raise ParameterValueValidationError("Value is empty.")

    if normalized in ("F32", "F64"):
        try:
            return float(cleaned)
        except ValueError as exc:
            raise ParameterValueValidationError(
                f"Expected a floating-point number for {normalized}, got {value_text!r}."
            ) from exc

    # Integer types
    try:
        if cleaned.lower().startswith("0x"):
            number = int(cleaned, 16)
        else:
            if any(ch in cleaned for ch in (".", "e", "E")):
                raise ParameterValueValidationError(
                    f"Expected an integer for {normalized}, got {value_text!r}."
                )
            number = int(cleaned, 10)
    except ValueError as exc:
        raise ParameterValueValidationError(
            f"Expected an integer for {normalized}, got {value_text!r}."
        ) from exc

    ranges: dict[str, tuple[int, int]] = {
        "U8": (0, 0xFF),
        "I8": (-0x80, 0x7F),
        "U16": (0, 0xFFFF),
        "I16": (-0x8000, 0x7FFF),
        "U32": (0, 0xFFFFFFFF),
        "I32": (-0x80000000, 0x7FFFFFFF),
        "U64": (0, 0xFFFFFFFFFFFFFFFF),
        "I64": (-0x8000000000000000, 0x7FFFFFFFFFFFFFFF),
    }
    if normalized not in ranges:
        raise ParameterValueValidationError(f"Unsupported DataType: {data_type_name}")

    low, high = ranges[normalized]
    if number < low or number > high:
        raise ParameterValueValidationError(
            f"Value {number} out of range for {normalized} [{low} .. {high}]."
        )
    return number
