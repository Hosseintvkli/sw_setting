# Device Setting Tool (`sw_setting`)

Desktop application for configuring embedded devices over **Modbus RTU (serial)** or **Modbus TCP (Ethernet)**: topology discovery (**Identify**), SETTING parameter read/write from CodeGen JSON, CSV **Profile** apply/verify, and **COMMAND** execution.

This document is the functional and technical specification of the implemented scenario. It is detailed enough to re-implement the software from scratch.

---

## 1. Goals

1. Connect to devices via Modbus RTU or Modbus TCP.
2. Discover multi-layer **hub + device** topology with the **Identify** process.
3. Read/write **SETTING** parameters from CodeGen-generated parameter lists (JSON).
4. Apply / verify **Profile** CSV files.
5. Execute **COMMAND** parameters.

### Design rules

- Long, self-explanatory names for variables and functions.
- Modular split: UI / communication / JSON catalog / Identify / Profile / Command.
- Fixed JSON catalog path relative to application start (user does not pick the folder).

---

## 2. Project layout and fixed JSON path

```text
sw_setting/
  main.py
  core/
    communication_settings.py
    device_modbus_link.py
    codegen_parameter_list_models.py
    codegen_parameter_list_catalog.py
    device_setting_tree_loader.py
    modbus_register_value_codec.py
    parameter_value_validation.py
    setting_profile_csv.py
    device_topology_models.py
    device_identify_session.py
    device_command_executor.py
  ui/
    communication_panel.py
    main_window.py
  files/
    codegen_output/
      JSON/
        cg_database_deviceid.json
        parameter_list_<DeviceId>/
          parameter_list_<DeviceId>_<Version>/
            cg_parameter_list_<DeviceId>_<Version>_info.json
            cg_parameter_list_<DeviceId>_<Version>_parameter_list.json
```

**Fixed catalog root:**

```text
<working directory or next to main.py>/files/codegen_output/JSON
```

---

## 3. CodeGen JSON model

### 3.1 Info file

Minimum fields:

- `DeviceId` (integer)
- `ParameterListVersion` / version (integer)
- Device name (e.g. `DeviceName`)

### 3.2 Parameter list (array)

| JSON field | Meaning |
|------------|---------|
| `Name` | Unique name; `.` = hierarchy; `[n]` = array element |
| `ModbusAddr` | Holding register address |
| `ModbusSize` | Number of 16-bit registers |
| `DataType` | `U8`/`U16`/`U32`/`U64`/`I8`/`I16`/`I32`/`I64`/`F32`/`F64` (and similar) |
| `ParameterType` | `MONITORING (R)` / `SETTING (...)` / `COMMAND (W)` |
| `Tag1` … `Tag5` | Tags; **UI category tree uses Tag2** |

- **SETTING**: shown in Parameters tree; editable.
- **MONITORING**: not in main settings tree (except fixed header fields where applicable).
- **COMMAND**: Commands tab only.

Access mapping:

- name contains `COMMAND` → Command  
- name contains `SETTING` → Setting  
- otherwise → Monitoring  

---

## 4. Fixed holding register addresses (all devices)

| Address | Meaning |
|---------|---------|
| `0` | DeviceId |
| `1` | ParameterListVersion |
| `14` | DownStreamQty (hub downstream port count; `0` = leaf) |
| `4000` | Device SlaveId (writable) |
| `4001` | IdentifyStatus (`1` = identify active, `0` = finished) |

`DownStreamsSetting[i].SlaveIdMin` / `SlaveIdMax` addresses are resolved by **exact parameter name** from the matching parameter-list JSON.

---

## 5. Register value codec (little-endian)

For multi-register values (`U32`, `F32`, `U64`, `F64`, …):

- **Low word first** (little-endian word order).
- Binary pack/unpack with little-endian (`struct` format `<`).

All holding I/O goes through the Modbus link layer.

---

## 6. Communication (Communicate tab)

### 6.1 Serial RTU

- List system COM ports + Refresh.
- Baud rate (standard list + Custom).
- Read timeout / Write timeout (ms).
- Retries (total attempts per transaction).

### 6.2 Ethernet TCP

- **Local network**: list of host IPv4 adapters (name + IP) + Refresh  
  (`psutil` if available, else Windows PowerShell `Get-NetIPAddress`).
- **Device IP** (remote target).
- TCP port (default `502`).
- Connect / Read / Write timeouts.
- Shared Retries control.

### 6.3 No SlaveId on the Connect screen

Unit/SlaveId comes from **Identify** and double-click on the Devices tree.  
Internal default before selection: `1`.

### 6.4 Retry policy

For each READ:

1. Try immediately.
2. On failure: wait **Read timeout**.
3. Repeat until **Retries** is exhausted.

**Broadcast (unit id = 0) never expects a reply.** Timeout / no response on unit `0` is treated as success.

---

## 7. `DeviceModbusLink` layer

Responsibilities:

- Connect / disconnect from `DeviceCommunicationSettings`.
- `read_holding_register(s)_u16` / `write_holding_register(s)_u16`.
- Optional `modbus_unit_identifier` on every transaction.
- `set_modbus_unit_identifier_override(unit)` after the user selects a device.
- If no per-call unit and no override → settings default unit.

---

## 8. Identify (topology discovery)

### 8.1 Hub rules

- **Broadcast** (`unit = 0`): applied by every node and forwarded downstream; **no response**.
- **Unicast**: if SlaveId is not the hub itself and falls in a port’s `[Min, Max]`, forward to that port.
- Upstream traffic from children is forwarded upward.

### 8.2 Algorithm

1. Broadcast: holding `4000 ← 1` (temporary SlaveId = 1 for all).
2. Broadcast: holding `4001 ← 1` (IdentifyStatus).
3. Probe **unit = 1**: read DeviceId (`0`) and Version (`1`) → load matching JSON package.
4. Allocate permanent SlaveId from **247 down to 2**; if pool exhausted → error.
5. WRITE unit=`1`, address `4000` = permanent SlaveId.
6. **Before any unicast to the permanent unit:** update Min/Max on **all ancestor hubs** so that SlaveId is routable on the correct path.
7. READ permanent unit, address `14` = DownStreamQty.
8. If Qty > 0, for each port `i = 0 .. Qty-1`:
   - Discovery port `i`: `Min = Max = 1`.
   - **Already discovered ports:** permanent-only range of the subtree (**must not include temporary id 1**).  
     Otherwise the hub still forwards unit `1` to an old port and new ports look empty.
   - Not-yet-scanned ports: `0 .. 0`.
   - Ancestors on the path must forward unit `1` to this hub.
   - Probe unit `1`; no answer → mark port empty, close `0..0`, **continue next port**.
   - Answer → assign permanent id, expand ancestor ranges, recursively scan child ports.
   - After subtree finishes: **seal** port range to permanent-only ids.
9. Finish: Broadcast `4001 ← 0`.

On failure mid-way: keep **partial topology** and show it in the Devices tree.

### 8.3 Tree model

Each node stores: DeviceId, Version, Name, permanent SlaveId, DownStreamQty, parent, `port_index_on_parent`, `children_by_port_index`, software mirror of port Min/Max.

---

## 9. User interface layout

Three vertical columns (splitter). Left panel width is **user-resizable** (not locked).

### Left — tabs

**Communicate**

- Serial / Ethernet settings.
- Connect / Disconnect.
- Connection state label.

**Devices**

- **Identify** button.
- Topology tree.
- Double-click a **device** row (not an empty port) → set unit override + load settings.

Tree display format:

```text
HubName
  port[0]: ChildName          (SlaveId, DeviceId, Version, Ports)
  port[1]: (no connection)
  port[2]: ChildName
    port[0]: LeafName
    ...
```

Every hub port is listed as a sibling row. Port and connected device share one row. Nesting is only for that device’s own ports.

### Center — tabs

**Parameters**

- Small monitoring header (~10%): SlaveID, DeviceId, SerialNo, HW.Ver, FW.Ver (from fixed addresses when available).
- SETTING tree: categories from **Tag2**; under each category, name path (dots and arrays).
- Columns: Name | Value (editable) | ModbusAddr | Type  
  Prefer wide Name, narrow address; **preserve column widths across Reload**.
- Progress bar while loading; hide when finished.
- **Reload** re-reads with the current unit.
- Edit Value + Enter → type validation → encode → Modbus write.

**Monitoring**

- Lists `MONITORING_READ_ONLY` parameters from the loaded device package.
- Uses the same hierarchy as Settings: `Tag2` is the first level, followed by the dotted/indexed parameter-name path.
- Each row has an independent selection checkbox; selections are retained by `ParameterId` when the selected device changes.
- Merely opening the Monitoring tab never reads the hardware. The user must press **Start Monitoring**; only checked parameter rows then enter the read cycle.
- Leaving the Monitoring tab, loading another device, or pressing **Stop Monitoring** stops scheduling new reads. Returning to the tab requires Start again.
- Selected parameters are read through copyable `read-monitoring --parameter-id ...` CLI commands; adjacent registers are merged into batches of at most 125 registers.
- A changed value highlights its row in green for 3 seconds.
- Last-read age is shown in milliseconds. Unselected rows and rows older than 5 seconds are dimmed and show no age.

**Profile**

- CSV path picker.
- Checkbox: apply to **all discovered devices with the same DeviceId**.
- Apply / Verify / Save parameters as profile.
- Save: **Reload first**, then write CSV.
- Colored log (green = success, red = failure).

CSV format:

- Column 1: parameter `Name` exactly as in JSON.
- Columns 2+: values. Multiple values after an array name expand from the start index in the name; out-of-bounds is an error.
- SETTING and COMMAND rows accept values valid for their JSON `DataType`.
- Apply writes a COMMAND value exactly as provided and does not poll it. Verify reads and compares COMMAND rows without writing them.

**Commands**

- List of COMMAND parameters from the loaded JSON package.
- **Execute**: WRITE `0xFFFF` to the address, then poll:
  - no response → still running (keep polling within budget);
  - `0xFFFF` → not accepted yet;
  - `0` → success;
  - any other value → device error code.
- Colored command log.

### Right

- General application log (Identify, connect, load, …), colored, kept concise.

---

## 10. Loading the SETTING tree

1. Read DeviceId / Version with the **selected unit** (explicit unit id on every call).
2. Load parameter-list package from catalog.
3. Filter `ParameterType` = SETTING.
4. Batched holding reads (merge address ranges; respect max registers per Modbus frame).
5. Decode with little-endian codec.
6. Build UI tree from Tag2 + name segments.

Do not rely only on a global unit override; pass unit explicitly.

---

## 11. Value validation

Before write (tree edit or Profile):

- Range checks per `DataType` (e.g. U16 ≤ 65535).
- Integer types reject non-integers; floats accept real numbers.

---

## 12. Suggested tech stack

- Python 3.10+
- PyQt6
- pymodbus
- pyserial (with pymodbus) for COM ports
- Optional: `psutil` for network interface listing

---

## 13. Typical user flow

1. **Communicate** → configure link → **Connect**.
2. **Devices** → **Identify**.
3. Double-click a device in the topology tree.
4. Use **Parameters** / **Profile** / **Commands**.
5. **Disconnect**.

---

## 14. Implementation pitfalls (do not skip)

1. Broadcast unit `0` must not require a response.
2. Discovery uses temporary unit `1`; after permanent assign, update ancestor Min/Max **before** unicast to the new unit.
3. Already-discovered ports must **exclude** temporary id `1` from Min/Max while opening the next discovery port.
4. Failure on one port must not stop scanning the remaining ports of the same hub.
5. On Identify failure, show partial topology.
6. JSON path is fixed under `files/codegen_output/JSON`.
7. UI categories use **Tag2**, not Tag1.
8. Multi-register values use **little-endian word order**.

---

## 15. Module responsibilities (summary)

| Module | Role |
|--------|------|
| `communication_settings` | Pure settings model |
| `communication_panel` | Connect UI |
| `device_modbus_link` | pymodbus client, retries, unit override, broadcast-safe write |
| `codegen_parameter_list_*` | Parse/scan JSON catalog |
| `modbus_register_value_codec` | Encode/decode register values |
| `parameter_value_validation` | Type/range checks |
| `device_setting_tree_loader` | Read DeviceId/version + batch SETTING values |
| `device_identify_session` | Identify algorithm |
| `device_topology_models` | Tree nodes / result |
| `setting_profile_csv` | CSV load/save profile |
| `device_command_executor` | COMMAND 0xFFFF protocol |
| `main_window` | Layout, tabs, orchestration |

---

## License / ownership

Internal tooling for device parameter configuration. Adjust license and branding as needed for your organization.
