"""
Discover host serial ports and local IPv4 network interfaces.

Shared by CLI handlers and UI — no Qt dependency.
"""

from __future__ import annotations


def list_available_serial_port_device_names() -> list[str]:
    """
    Return sorted COM / tty device names currently visible to the OS.
    Requires pyserial (typically installed with pymodbus).
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
    Returns an empty list when psutil is unavailable or finds no adapters.
    """
    results: list[tuple[str, str]] = []

    try:
        import psutil  # type: ignore

        for interface_name, address_list in psutil.net_if_addrs().items():
            for address in address_list:
                family = getattr(address, "family", None)
                if str(family).endswith("AF_INET") or family == 2:
                    ip = address.address
                    if not ip or ip.startswith("127."):
                        continue
                    results.append((interface_name, ip))
        if results:
            return _unique_sorted_name_ip_pairs(results)
    except Exception:
        return []

    return _unique_sorted_name_ip_pairs(results)


def _unique_sorted_name_ip_pairs(
    pairs: list[tuple[str, str]],
) -> list[tuple[str, str]]:
    seen: set[tuple[str, str]] = set()
    unique: list[tuple[str, str]] = []
    for item in sorted(pairs, key=lambda x: (x[0].lower(), x[1])):
        if item not in seen:
            seen.add(item)
            unique.append(item)
    return unique
