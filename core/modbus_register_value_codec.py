"""
Convert between Modbus holding-register words and typed parameter values.

Multi-register types use little-endian layout (firmware convention):
  - lowest Modbus address = least-significant 16-bit word
  - bytes of the assembled value are little-endian

Example U32 at address N:
  reg[N]     = bits 15..0
  reg[N + 1] = bits 31..16
"""

from __future__ import annotations

import struct


class ModbusRegisterValueCodecError(Exception):
    pass


def register_count_for_data_type_name(data_type_name: str) -> int:
    normalized = data_type_name.strip().upper()
    mapping = {
        "U8": 1,
        "I8": 1,
        "U16": 1,
        "I16": 1,
        "U32": 2,
        "I32": 2,
        "F32": 2,
        "U64": 4,
        "I64": 4,
        "F64": 4,
    }
    if normalized not in mapping:
        raise ModbusRegisterValueCodecError(f"Unsupported DataType: {data_type_name}")
    return mapping[normalized]


def _registers_to_little_endian_bytes(register_values_u16: list[int]) -> bytes:
    """
    First register = least-significant word.
    Each word contributes 2 bytes in little-endian order.
    """
    return b"".join(
        struct.pack("<H", int(word) & 0xFFFF) for word in register_values_u16
    )


def decode_parameter_value_from_holding_registers(
    data_type_name: str, register_values_u16: list[int]
) -> int | float:
    """Decode raw holding registers into a Python int or float (little-endian)."""
    normalized = data_type_name.strip().upper()
    expected = register_count_for_data_type_name(normalized)
    if len(register_values_u16) != expected:
        raise ModbusRegisterValueCodecError(
            f"{normalized} expects {expected} registers, got {len(register_values_u16)}"
        )

    words = [int(v) & 0xFFFF for v in register_values_u16]
    packed_little_endian = _registers_to_little_endian_bytes(words)

    if normalized == "U16":
        return words[0]
    if normalized == "I16":
        return struct.unpack("<h", packed_little_endian)[0]
    if normalized == "U8":
        return words[0] & 0xFF
    if normalized == "I8":
        return struct.unpack("<b", bytes([words[0] & 0xFF]))[0]
    if normalized == "U32":
        return struct.unpack("<I", packed_little_endian)[0]
    if normalized == "I32":
        return struct.unpack("<i", packed_little_endian)[0]
    if normalized == "F32":
        return struct.unpack("<f", packed_little_endian)[0]
    if normalized == "U64":
        return struct.unpack("<Q", packed_little_endian)[0]
    if normalized == "I64":
        return struct.unpack("<q", packed_little_endian)[0]
    if normalized == "F64":
        return struct.unpack("<d", packed_little_endian)[0]

    raise ModbusRegisterValueCodecError(f"Unsupported DataType: {data_type_name}")


def encode_parameter_value_to_holding_registers(
    data_type_name: str, value: int | float
) -> list[int]:
    """Encode a Python value to holding-register words (little-endian, for writes later)."""
    normalized = data_type_name.strip().upper()
    count = register_count_for_data_type_name(normalized)

    if normalized == "U16":
        return [int(value) & 0xFFFF]
    if normalized == "I16":
        return [struct.unpack("<H", struct.pack("<h", int(value)))[0]]
    if normalized == "U8":
        return [int(value) & 0xFF]
    if normalized == "I8":
        return [struct.unpack("<H", struct.pack("<b", int(value)) + b"\x00")[0] & 0xFF]
    if normalized == "U32":
        raw = struct.pack("<I", int(value) & 0xFFFFFFFF)
    elif normalized == "I32":
        raw = struct.pack("<i", int(value))
    elif normalized == "F32":
        raw = struct.pack("<f", float(value))
    elif normalized == "U64":
        raw = struct.pack("<Q", int(value) & 0xFFFFFFFFFFFFFFFF)
    elif normalized == "I64":
        raw = struct.pack("<q", int(value))
    elif normalized == "F64":
        raw = struct.pack("<d", float(value))
    else:
        raise ModbusRegisterValueCodecError(f"Unsupported DataType: {data_type_name}")

    registers = list(struct.unpack("<" + "H" * count, raw))
    return registers


def format_decoded_parameter_value_for_display(
    data_type_name: str, value: int | float
) -> str:
    normalized = data_type_name.strip().upper()
    if normalized in ("F32", "F64"):
        return repr(float(value))
    return str(int(value))
