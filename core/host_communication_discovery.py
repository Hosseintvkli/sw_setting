"""
Discover host serial ports and local IPv4 network interfaces.

Shared by CLI handlers and UI — no Qt dependency.
"""

from __future__ import annotations


def list_available_serial_ports() -> list[tuple[str, str]]:
    """Return ``(device_name, description)`` for visible serial ports."""
    try:
        from serial.tools import list_ports
    except ImportError:
        return []

    results: list[tuple[str, str]] = []
    for port_info in list_ports.comports():
        device_name = str(port_info.device or "").strip()
        if not device_name:
            continue
        description = str(port_info.description or "").strip()
        if not description or description.lower() == "n/a":
            description = str(port_info.manufacturer or "").strip()
        results.append((device_name, description))
    return sorted(set(results), key=lambda item: item[0].lower())


def list_available_serial_port_device_names() -> list[str]:
    """
    Return sorted COM / tty device names currently visible to the OS.
    Requires pyserial (typically installed with pymodbus).
    """
    return [device_name for device_name, _description in list_available_serial_ports()]


def list_available_ipv4_network_interface_details(
) -> list[tuple[str, str, str]]:
    """Return ``(interface_alias, hardware_description, ipv4_address)``."""
    descriptions = _windows_network_interface_descriptions()
    results: list[tuple[str, str, str]] = []

    try:
        import psutil  # type: ignore

        for interface_name, address_list in psutil.net_if_addrs().items():
            for address in address_list:
                family = getattr(address, "family", None)
                if str(family).endswith("AF_INET") or family == 2:
                    ip = address.address
                    if not ip or ip.startswith("127."):
                        continue
                    results.append(
                        (
                            interface_name,
                            descriptions.get(interface_name, ""),
                            ip,
                        )
                    )
    except Exception:
        return []

    return sorted(
        set(results),
        key=lambda item: (item[0].lower(), item[2]),
    )


def list_available_ipv4_network_interfaces() -> list[tuple[str, str]]:
    """
    Return (interface_name, ipv4_address) for non-loopback IPv4 adapters.
    Returns an empty list when psutil is unavailable or finds no adapters.
    """
    return [
        (interface_name, ipv4_address)
        for interface_name, _description, ipv4_address
        in list_available_ipv4_network_interface_details()
    ]


def _windows_network_interface_descriptions() -> dict[str, str]:
    """Map Windows connection aliases to their hardware descriptions."""
    try:
        import sys
        import winreg
    except ImportError:
        return {}
    if sys.platform != "win32":
        return {}

    cards_path = r"SOFTWARE\Microsoft\Windows NT\CurrentVersion\NetworkCards"
    connections_path = (
        r"SYSTEM\CurrentControlSet\Control\Network"
        r"\{4D36E972-E325-11CE-BFC1-08002BE10318}"
    )
    descriptions_by_guid: dict[str, str] = {}
    aliases: dict[str, str] = {}
    try:
        with winreg.OpenKey(winreg.HKEY_LOCAL_MACHINE, cards_path) as cards:
            index = 0
            while True:
                try:
                    subkey_name = winreg.EnumKey(cards, index)
                except OSError:
                    break
                index += 1
                try:
                    with winreg.OpenKey(cards, subkey_name) as card:
                        guid = str(winreg.QueryValueEx(card, "ServiceName")[0]).upper()
                        description = str(
                            winreg.QueryValueEx(card, "Description")[0]
                        ).strip()
                    if guid and description:
                        descriptions_by_guid[guid] = description
                except OSError:
                    continue

        for guid, description in descriptions_by_guid.items():
            try:
                with winreg.OpenKey(
                    winreg.HKEY_LOCAL_MACHINE,
                    rf"{connections_path}\{guid}\Connection",
                ) as connection:
                    alias = str(winreg.QueryValueEx(connection, "Name")[0]).strip()
                if alias:
                    aliases[alias] = description
            except OSError:
                continue
    except OSError:
        return {}
    return aliases
