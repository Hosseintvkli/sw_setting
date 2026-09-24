# راهنمای توسعه و عیب‌یابی `sw_setting`

این سند نقشه فنی نسخه فعلی پروژه است: هر فایل چه مسئولیتی دارد، جریان‌ها از چه فایل‌هایی عبور می‌کنند و برای هر نوع خطا از کجا باید بررسی را شروع کرد. برای جزئیات الگوریتم Identify و قرارداد اولیه محصول، `README.md` و `logic.md` نیز مفیدند؛ بااین‌حال کد موجود مرجع نهایی رفتار فعلی است.

## ۱. هدف و معماری کلی

پروژه ابزار تنظیم دستگاه‌های Embedded روی **Modbus RTU** یا **Modbus TCP** است و این قابلیت‌ها را فراهم می‌کند:

- اتصال و عملیات خام Holding Register؛
- کشف topology هاب‌ها و دستگاه‌ها و اختصاص Slave ID دائمی؛
- انتخاب JSON متناسب با `DeviceId + ParameterListVersion`؛
- خواندن و نوشتن پارامترهای SETTING و خواندن دوره‌ای MONITORING؛
- اعمال، بررسی و ذخیره Profile CSV؛
- اجرای پارامترهای COMMAND با پروتکل `0xFFFF` و poll نتیجه؛
- اجرای یک‌باره CLI یا نگهداری نشست پایدار روی HTTP؛
- یک GUI مبتنی بر همان commandهای CLI، همراه با history و اجرای script.

لایه‌ها به‌صورت زیرند:

```text
cli.py / HTTP API / GUI
          ↓
commands: parse، dispatch، session state، handlers
          ↓
core: Modbus، JSON، codec، validation، Identify، Profile، Command
          ↓
pymodbus / serial port / TCP / فایل‌های CodeGen JSON
```

CLI، HTTP و تمام کنترل‌های GUI از لایه `commands` استفاده می‌کنند. GUI برای هر اقدام یک فرمان واقعی و قابل کپی می‌سازد و آن را با `QProcess` روی session نام‌دار اجرا می‌کند: در اجرای سورس به شکل `python cli.py ...` و در بستهٔ نهایی به شکل `sw_setting_cli.exe ...`. پوشه `ui` هیچ import مستقیمی از `core` ندارد.

## ۲. مسیرهای اجرای برنامه

### CLI یک‌باره

```text
python cli.py <command> [args]
  → cli.py
  → CommandProcessor.execute_tokens
  → parser.py
  → registry.py
  → handler مربوط
  → core
  → CommandResult به شکل JSON
```

در اجرای یک‌باره، `CommandSessionContext` با پایان process از بین می‌رود؛ بنابراین زنجیره‌ای مانند `connect → identify → load-settings` بین چند اجرای جدا حفظ نمی‌شود.

### نشست پایدار HTTP برای CLI

```text
python cli.py serve-http       # اجرای FastAPI/uvicorn
python cli.py serve            # ساخت session و ذخیره شناسه آن
python cli.py connect ...      # ارسال به همان session
python cli.py identify
python cli.py serve-stop       # حذف session و فایل اشاره‌گر محلی
```

`serve-http` خود سرور است و تا زمان توقف process ادامه دارد. `serve` فقط روی سرور موجود session می‌سازد. فایل `.sw_setting_http_session.json` در ریشه، `base_url` و `session_id` نشست پیش‌فرض را نگه می‌دارد. برای نشست‌های مستقل می‌توان `--session NAME` را پیش یا پس از نام فرمان نوشت:

```text
python cli.py --session gui serve
python cli.py --session gui connect --port COM3
python cli.py --session gui identify
python cli.py --session gui serve-stop
```

در نسخهٔ Buildشده، همین مسیر بدون نصب Python در دسترس است:

```text
sw_setting_cli.exe serve-http --host 127.0.0.1 --port 8000
sw_setting_cli.exe --session gui serve
sw_setting_cli.exe --session gui connect ...
sw_setting_cli.exe --session gui identify
```

نشست نام‌دار در `.sw_setting_http_session.<NAME>.json` ذخیره می‌شود؛ نام فقط می‌تواند شامل حروف و ارقام ASCII و `. _ -` باشد. نبودن نشست نام‌دار خطاست و به اجرای محلی یک‌باره fallback نمی‌شود. sessionها فقط در حافظه سرورند؛ restart سرور آن‌ها را از بین می‌برد و ممکن است فایل‌های اشاره‌گر محلی stale شوند.

### GUI

```text
python main.py
  → PyQt6
  → ui/main_window.py
  → ui/cli_console_panel.py / QProcess
  → cli.py --session <name> <command>
  → HTTP → CommandProcessor → handler → core
```

GUI یک session نام‌دار HTTP می‌سازد یا به session ساخته‌شده در Shell متصل می‌شود. دکمه‌های گرافیکی فقط آرگومان CLI تولید می‌کنند؛ state قابل نمایش آن‌ها از JSON نتیجه command بازسازی می‌شود.

## ۳. وضعیت مشترک یک نشست CLI/HTTP

`commands/context.py` این وضعیت‌ها را در `CommandSessionContext` نگه می‌دارد:

| فیلد | کاربرد |
|---|---|
| `device_modbus_link` | اتصال فعال Serial/TCP |
| `codegen_json_root_directory` | مسیر Catalog JSON |
| `last_identify_result` | آخرین topology کامل یا ناقص |
| `selected_slave_id` | دستگاه انتخاب‌شده |
| `last_settings_load_result` | package و مقادیر آخرین `load-settings` |
| `log_callback` | ارسال log به stderr یا HTTP session |
| `cancel_check` | لغو cooperative عملیات طولانی، فعلاً مهم برای Identify |

ترتیب معمول کار:

```text
connect → identify → select-device → load-settings
                                 ↓
          get/set/list/profile/command
```

برخی فرمان‌ها `--slave-id` مستقیم می‌پذیرند. اولویت Unit ID در لایه Modbus چنین است:

```text
Unit صریح همان فراخوانی → override لینک → Unit پیش‌فرض تنظیمات
```

## ۴. مسئولیت فایل‌های ریشه

| فایل/مسیر | مسئولیت |
|---|---|
| `cli.py` | نقطه ورود CLI؛ تشخیص `serve-http`، `serve` و `serve-stop`؛ انتخاب بین session HTTP و اجرای محلی یک‌باره؛ چاپ JSON و exit code. |
| `main.py` | نقطه ورود GUI و ساخت `QApplication` و `DeviceSettingMainWindow`. |
| `README.md` | مشخصات کلی محصول، الگوریتم‌ها و UI؛ ممکن است بعضی جزئیات آن از کد فعلی عقب باشد. |
| `logic.md` | سند طراحی اولیه و جزئی‌تر؛ برای فهم intent مفید است، ولی مرجع رفتار واقعی نیست. |
| `files/codegen_output/JSON/` | داده runtime مورد استفاده Catalog: database دستگاه‌ها و packageهای نسخه‌دار. سایر خروجی‌های C/C#/H/MD/TXT مستقیماً توسط Python فعلی خوانده نمی‌شوند. |
| `tests/test_settings_commands.py` | تست‌های regression فعلی برای handler تنظیمات با `FakeLink`: جلوگیری از نوشتن پارامتر غیرـSETTING، جلوگیری از استفاده از metadata مربوط به Slave دیگر و کنترل cache هدر. تست‌های handler/core جدید نیز باید در `tests/` اضافه شوند. |

## ۵. لایه `commands`

### فایل‌های زیرساختی

| فایل | مسئولیت و ارتباط |
|---|---|
| `commands/__init__.py` | export ساده `CommandProcessor`. |
| `commands/parser.py` | تعریف تمام subcommandها و آرگومان‌ها با `argparse`؛ تبدیل token یا خط متنی به `ParsedCommandLine`. اگر نام option، default، required یا help اشتباه است از اینجا شروع کنید. |
| `commands/result.py` | قرارداد خروجی همه فرمان‌ها: `ok`، `command`، `data`، `error` و `exit_code`؛ تبدیل به JSON. |
| `commands/context.py` | state طول‌عمر نشست، انتخاب Slave، package بارگذاری‌شده و helperهای پیش‌شرط. |
| `commands/registry.py` | نگاشت نام command به handler و ثبت همه گروه‌های handler. فرمانی که parse می‌شود ولی handler ندارد یا برعکس، این فایل و `register()` همان handler را بررسی کنید. |
| `commands/processor.py` | parse، dispatch و تبدیل exception کنترل‌نشده handler به `failure`. تمام مسیرهای CLI/HTTP به این نقطه می‌رسند. |
| `commands/session_client.py` | کلاینت HTTP مبتنی بر `urllib`؛ ساخت/خواندن/حذف فایل اشاره‌گر نشست پیش‌فرض یا نام‌دار، فراخوانی command و بستن session. خطاهای server unreachable، state stale یا پاسخ JSON نامعتبر اینجاست. |
| `commands/http_session_server.py` | FastAPI چندنشستی؛ هر session یک context و processor مستقل دارد. endpointهای health/session/command/cancel/log، قفل global sessionها و قفل busy هر session، اجرای handler در worker thread و شروع uvicorn. |

endpointهای HTTP:

| Method و مسیر | کار |
|---|---|
| `GET /health` | سلامت و تعداد sessionها |
| `GET /sessions` | فهرست sessionهای حافظه |
| `POST /sessions` | ساخت session |
| `DELETE /sessions/{id}` | cancel، disconnect و حذف session |
| `POST /sessions/{id}/command` | تبدیل request به token و اجرای یک command |
| `POST /sessions/{id}/cancel` | set کردن event لغو |
| `GET /sessions/{id}/logs` | logهای اخیر |

در هر session فقط یک command هم‌زمان مجاز است؛ درخواست دوم هنگام busy بودن HTTP 409 می‌گیرد. `_sessions_lock` فقط dictionary مشترک sessionها و `state.lock` وضعیت busy همان session را محافظت می‌کند.

### Handlerها

| فایل | فرمان‌ها و مسئولیت |
|---|---|
| `commands/handlers/connection_commands.py` | `connect`، `disconnect`، `status`، `list-serial-ports`، `list-networks`، `set-timeouts`. آرگومان parser را به مدل ارتباط تبدیل می‌کند و `DeviceModbusLink` را کنترل می‌کند. |
| `commands/handlers/topology_commands.py` | `identify`، `show-topology`، `select-device`، `clear-device-selection`. `DeviceIdentifySession` را اجرا، partial result را حفظ و topology را به JSON یا متن تبدیل می‌کند. |
| `commands/handlers/settings_commands.py` | `load/reload-settings`، `get/set/list-parameter`، `read-monitoring` و `get-monitoring-header`. Loader، codec و validation را به command متصل می‌کند؛ تطابق package با Slave و writable بودن setting را کنترل می‌کند. `read-monitoring` پارامترها را با ParameterId انتخاب و بازه‌های رجیستر مجاور را تا سقف ۱۲۵ رجیستر batch می‌کند. |
| `commands/handlers/profile_commands.py` | `apply/verify/save/parse-profile`. CSV را parse می‌کند و مقدار SETTING و COMMAND را روی یک یا چند Slave می‌نویسد یا بررسی می‌کند. Apply مقدار COMMAND را عیناً از CSV encode و فقط write می‌کند؛ polling ندارد. Verify رجیستر SETTING و COMMAND را می‌خواند، decode می‌کند و با مقدار CSV مقایسه می‌کند. |
| `commands/handlers/device_command_commands.py` | `list-commands` و `execute-command`؛ پیدا کردن COMMAND از package یا اجرای آدرس مستقیم. |
| `commands/handlers/modbus_raw_commands.py` | `read-holding`، `write-holding` و broadcast write؛ مناسب تست پایین‌ترین لایه بدون JSON. |
| `commands/handlers/utility_commands.py` | `help`، `version`، `set-json-root` و `ping`. مسیر help فعلی `help [topic]` است. |
| `commands/handlers/__init__.py` | marker بسته Python؛ منطق اجرایی ندارد. |

## ۶. لایه `core`

### ارتباط و تبدیل داده

| فایل | مسئولیت و مصرف‌کنندگان |
|---|---|
| `core/communication_settings.py` | dataclassهای تنظیم Serial RTU، Ethernet TCP، timeout، retry و Unit پیش‌فرض. توسط connection handler و Modbus link مصرف می‌شود؛ GUI فقط آرگومان CLI تولید می‌کند. |
| `core/host_communication_discovery.py` | فهرست COMها با pyserial و IPv4های غیر-loopback با psutil. مسیر CLI از این فایل استفاده می‌کند. |
| `core/device_modbus_link.py` | wrapper واقعی `pymodbus`: connect/disconnect، read/write U16، retry خواندن، timeoutها، broadcast و Unit override. اولین محل بررسی خطاهای فیزیکی، protocol، timeout و نسخه pymodbus است. |
| `core/modbus_register_value_codec.py` | تعداد رجیستر هر DataType و encode/decode بین `int/float` و رجیسترهای U16 با قرارداد little-endian word order. هیچ I/O ندارد. |
| `core/parameter_value_validation.py` | تبدیل متن کاربر به int/float و بررسی نوع و محدوده U/I/F. محدودیت اختصاصی پارامتر در JSON را بررسی نمی‌کند. |

### JSON و مدل داده

| فایل | مسئولیت و مصرف‌کنندگان |
|---|---|
| `core/codegen_parameter_list_models.py` | enum دسترسی و dataclassهای database، info، تعریف پارامتر و package. مبنای Catalog، Loader، Profile و handlerهاست. |
| `core/codegen_parameter_list_catalog.py` | scan ساختار پوشه JSON، index کردن `(DeviceId, Version)` و تبدیل info/parameter-list JSON به مدل‌ها. هیچ Modbus I/O ندارد. |
| `core/device_topology_models.py` | مدل node و نتیجه Identify؛ parent/child، port، بازه routing و پیمایش depth-first. |

### سرویس‌های سطح بالاتر core

| فایل | مسئولیت و ارتباط |
|---|---|
| `core/device_setting_tree_loader.py` | خواندن DeviceId/Version/header، انتخاب package، فیلتر SETTINGها، ادغام بازه‌ها، batch read حداکثر ۱۲۵ رجیستر، حفظ خطای اصلی هر batch و decode مقادیر. progress عمومی آن `0..100` است. |
| `core/device_identify_session.py` | الگوریتم کامل Identify: broadcast شناسه موقت، کشف node روی Unit 1، تخصیص ID از 247 تا 2، تنظیم Min/Max portهای Hub، recursion، log، cancel و partial topology. |
| `core/setting_profile_csv.py` | خواندن/نوشتن Profile UTF-8، اعتبارسنجی ردیف‌ها، گسترش آرایه، گزارش issue و پذیرش اختیاری COMMAND با هر مقدار معتبر برای DataType آن. خروجی save header ندارد؛ سلول خالی کل ردیف را رد می‌کند. |
| `core/device_command_executor.py` | نوشتن `0xFFFF` در رجیستر COMMAND و poll همان رجیستر: صفر موفق، `0xFFFF` pending، مقدار دیگر error code، no-response احتمالاً busy. |

## ۷. قراردادهای داده مهم

### ساختار JSON

```text
files/codegen_output/JSON/
  cg_database_deviceid.json
  parameter_list_<DeviceId:05d>/
    parameter_list_<DeviceId:05d>_<Version:05d>/
      cg_parameter_list_<DeviceId>_<Version>_info.json
      cg_parameter_list_<DeviceId>_<Version>_parameter_list.json
```

فیلدهای مهم پارامتر: `Name`، `ModbusAddr`، `ModbusSize`، `DataType`، `ParameterType`، `Description` و `Tag1..Tag5`. تطبیق نام پارامترها دقیق و case-sensitive است. `ParameterType` به `MONITORING_READ_ONLY`، `SETTING_READ_WRITE`، `COMMAND_WRITE` یا `UNKNOWN` نگاشت می‌شود.

### رجیسترهای ثابت

| آدرس | معنا |
|---:|---|
| 0 | DeviceId |
| 1 | ParameterListVersion |
| 2 و 3 | Firmware major/minor |
| 7 و 8 | Serial Number به‌صورت U32 |
| 9 و 10 | Hardware major/minor |
| 14 | DownStreamQty |
| 4000 | SlaveId قابل نوشتن |
| 4001 | IdentifyStatus |

آدرس `DownStreamsSetting[i].SlaveIdMin/Max` ثابت نیست و با نام دقیق از JSON همان Hub پیدا می‌شود.

### Codec

در مقدارهای چندرجیستری، رجیستر آدرس پایین‌تر word کم‌ارزش است. هر word نیز با `struct` و قالب little-endian تبدیل می‌شود. اگر مقدار خوانده‌شده درست است ولی عدد نهایی غلط است، `DataType` و `ModbusSize` JSON و سپس `modbus_register_value_codec.py` را بررسی کنید.

### Profile CSV

```csv
WatchdogTimeMs,1000
WatchdogTimeMs,"1000"
Offsets[0],10,20,30
ResetCommand,42
```

- کوتیشن برای مقدار ساده اختیاری است؛
- header نوشته نمی‌شود؛
- نام باید دقیقاً در package باشد؛
- `Offsets[0],10,,30` کل ردیف را نامعتبر می‌کند؛
- command فقط در مسیرهایی که `include_commands=True` است پذیرفته می‌شود و مقدار آن باید در محدودهٔ DataType تعریف‌شده در JSON باشد؛
- Apply مقدار command را عیناً encode و فقط write می‌کند؛ polling و بررسی نتیجه ندارد. Verify رجیستر command را بدون write کردن می‌خواند و مقدار آن را با CSV مقایسه می‌کند.

## ۸. جریان‌های مهم و زنجیره فایل‌ها

### اتصال

```text
parser.py
→ connection_commands.py
→ communication_settings.py
→ device_modbus_link.py
→ pymodbus
```

### بارگذاری setting

```text
settings_commands.py
→ device_setting_tree_loader.py
   ├→ device_modbus_link.py: DeviceId/Version و رجیسترها
   ├→ codegen_parameter_list_catalog.py: JSON مطابق
   └→ modbus_register_value_codec.py: decode
→ context.last_settings_load_result
```

### Identify

```text
topology_commands.py
→ device_identify_session.py
   ├→ device_modbus_link.py
   ├→ codegen_parameter_list_catalog.py
   └→ device_topology_models.py
→ context.last_identify_result
```

### Profile

```text
profile_commands.py
→ setting_profile_csv.py
→ parameter_value_validation.py
→ modbus_register_value_codec.py / device_command_executor.py
→ device_modbus_link.py
```

### اجرای command دستگاه

```text
device_command_commands.py
→ package از context
→ device_command_executor.py
→ device_modbus_link.py
```

## ۹. GUI مبتنی بر command

| فایل | مسئولیت |
|---|---|
| `ui/communication_panel.py` | فرم خالص Serial/TCP و timeoutها؛ آرگومان‌های `connect` را می‌سازد و نتیجه `list-serial-ports`/`list-networks` را نمایش می‌دهد. discovery یا Modbus I/O ندارد. |
| `ui/cli_console_panel.py` | CLI قابل مشاهده داخل GUI؛ اجرای بدون shell فرمان‌های `python cli.py ...` در حالت سورس و `sw_setting_cli.exe ...` در بستهٔ نهایی با `QProcess`، session نام‌دار، history/copy، stdout/stderr/exit code، اجرای ترتیبی script و مدیریت خودکار `serve-http`. Scriptهای قدیمی با فرم Python در نسخهٔ بسته‌بندی‌شده نیز شناخته و به EXE مستقل نگاشت می‌شوند. پردازش‌های پایان‌یافته با `deleteLater()` آزاد می‌شوند و history/output سقف دارند. فرمان دوره‌ای Monitoring در history قابل‌کپی می‌ماند، اما JSON حجیم آن در output pane تکرار نمی‌شود و فقط برای به‌روزرسانی جدول parse می‌شود. |
| `ui/main_window.py` | layout و تبدیل رخداد widgetها به command؛ مصرف JSON نتیجه برای topology، setting tree، header، Monitoring، Profile و COMMAND. درخت Monitoring مانند Setting از `Tag2` و سپس اجزای نقطه‌ای/آرایه‌ای Name ساخته می‌شود و Checkbox فقط روی برگ است. ورود به تب read را آغاز نمی‌کند: کاربر باید Start را بزند و فقط برگ‌های تیک‌خورده خوانده می‌شوند؛ خروج از تب چرخه را متوقف می‌کند. انتخاب‌ها با ParameterId حفظ می‌شوند و برای جلوگیری از عبور از محدودیت command line و نمایش تدریجی، در فرمان‌های قابل‌کپی حداکثر ۲۵۰ پارامتری خوانده می‌شوند. تایمر highlight/stale فقط برگ‌های قابل‌مشاهده در viewport را بازآرایی می‌کند. تمام عملیات از `CliConsolePanel` عبور می‌کنند. |

## ۱۰. نقشه عیب‌یابی

| علامت یا حوزه مشکل | ابتدا بررسی شود | سپس بررسی شود |
|---|---|---|
| CLI فرمان را نمی‌شناسد یا option رد می‌شود | `commands/parser.py` | `registry.py` و `register()` handler |
| HTTP فرمان را رد می‌کند یا token اشتباه می‌رسد | بدنه `{"tokens": [...]}` در Client و `CommandBody` در `http_session_server.py` | `session_client.py` و سپس `parser.py` |
| فرمان محلی کار می‌کند ولی HTTP نه | `http_session_server.py`، `session_client.py` | فایل `.sw_setting_http_session.json` و log endpoint |
| session پیدا نمی‌شود | `session_client.py` | حافظه `_sessions` سرور و restart شدن uvicorn |
| HTTP 409 | `SessionState.busy` و `state.lock` در server | command طولانی یا cancel ناقص |
| cancel عمل نمی‌کند | `http_session_server.py` event | `context.cancel_check` و `_log()` در `device_identify_session.py` |
| اتصال Serial/TCP باز نمی‌شود | `connection_commands.py` و args | `communication_settings.py`، `device_modbus_link.py`، کابل/IP/COM |
| فهرست COM یا شبکه در CLI غلط است | `core/host_communication_discovery.py` | pyserial/psutil و OS |
| فهرست شبکه GUI با CLI فرق دارد | خروجی ثبت‌شده `list-networks` در تب CLI | رندر `set_available_network_interfaces` در `communication_panel.py` |
| local NIC انتخاب می‌شود ولی اثری ندارد | `device_modbus_link.py` | فیلدهای local interface فقط ذخیره می‌شوند و client فعلی bind صریح ندارد |
| read/write خام خطا دارد | `modbus_raw_commands.py` | `device_modbus_link.py` و Unit/timeout/retry |
| Slave اشتباه هدف قرار می‌گیرد | `context.effective_slave_id` و handler | override و اولویت Unit در `device_modbus_link.py` |
| Identify Root را نمی‌یابد | `topology_commands.py` و logها | broadcast/Unit 1 در `device_identify_session.py` و link |
| Identify بعضی portها را جا می‌اندازد | `_configure_hub_ports_for_discovery_scan` | Min/Max JSON، ancestor routing و log هر port |
| Identify ظاهراً OK است ولی port error دارد | logهای session | broad `except` هر port در `device_identify_session.py` |
| پس از assign، دستگاه پاسخ نمی‌دهد | رجیستر 4000 و firmware/simulator | routing ancestor و `device_modbus_link.py` |
| JSON برای دستگاه پیدا نمی‌شود | رجیسترهای 0 و 1 | `codegen_parameter_list_catalog.py` و ساختار `files/.../JSON` |
| نام/آدرس/نوع پارامتر غلط است | JSON parameter list | `codegen_parameter_list_models.py` و Catalog parser |
| `load-settings` چند مقدار error دارد | `device_setting_tree_loader.py` و error هر leaf | batch range، link، `ModbusSize` و `DataType` |
| مقدار چندرجیستری یا float غلط است | `modbus_register_value_codec.py` | ترتیب word firmware و JSON |
| مقدار ورودی رد/پذیرفته اشتباه است | `parameter_value_validation.py` | DataType JSON؛ validation محدودیت اختصاصی پارامتر ندارد |
| get/set روی دستگاه دیگری اجرا می‌شود | `_loaded_package_for_slave` در settings handler | `selected_slave_id` و load مجدد package |
| monitoring header قدیمی است | cache check در `settings_commands.py` | `device_setting_tree_loader.py` و Unit صریح header |
| Monitoring مقدار تازه نشان نمی‌دهد | فرمان‌های `read-monitoring` در تب CLI و `error_count` | فشرده‌شدن Start Monitoring، تیک پارامتر، فعال بودن تب، `settings_commands.py` و آدرس/DataType JSON |
| Profile parse نمی‌شود | `setting_profile_csv.py` و issues | نام دقیق پارامتر، DataType، سلول خالی و آرایه |
| Profile روی چند دستگاه اشتباه است | targets در `profile_commands.py` | topology و تطابق DeviceId/Version |
| COMMAND timeout/error دارد | `device_command_executor.py` | handler، آدرس JSON، timeout و رفتار firmware |
| GUI فرمانی را اجرا نمی‌کند یا freeze دارد | `ui/cli_console_panel.py` و وضعیت `QProcess` | command/exit code ثبت‌شده و busy همان HTTP session |
| خروجی JSON یا exit code غلط است | handler مربوط | `commands/result.py` و `processor.py` |

## ۱۱. نقاط حساس فعلی

- CLI مسیر واحد اجراست؛ GUI فقط تولیدکننده command و نمایش‌دهنده JSON نتیجه است.
- HTTP به‌طور پیش‌فرض روی `127.0.0.1:8000` اجرا می‌شود. برای دسترسی راه‌دور باید `--host 0.0.0.0` صریحاً داده شود؛ چون CORS باز است و authentication وجود ندارد، این حالت فقط برای LAN قابل‌اعتماد مناسب است.
- sessionهای HTTP پایدار روی دیسک نیستند؛ فقط اشاره‌گر client ذخیره می‌شود.
- `CommandProcessor` exceptionهای handler را به failure کوتاه تبدیل می‌کند؛ برای traceback در HTTP logها را ببینید.
- `DeviceModbusLink` retry دستی مشخصی برای read دارد؛ مسیر write و broadcast رفتار متفاوت دارند.
- Identify خطای یک port را log و scan را ادامه می‌دهد؛ موفقیت نهایی لزوماً به معنی بدون خطا بودن تمام portها نیست.
- دو helper مربوط به settle time در Identify وجود دارند ولی استفاده نمی‌شوند؛ بعد از broadcast/assign تأخیر صریحی اعمال نمی‌شود.
- Catalog باید پیش از load شدن package اسکن شود و package فقط با ترکیب دقیق DeviceId/Version معتبر است.
- `parse-profile` issues را در data برمی‌گرداند؛ صرف `ok=True` را معادل «بدون issue» ندانید.
- Verify Profile رجیسترهای SETTING و COMMAND را فقط می‌خواند و با CSV مقایسه می‌کند؛ هیچ مقداری نمی‌نویسد.
- discovery شبکه GUI نیز فرمان `list-networks` را اجرا می‌کند؛ تنها پیاده‌سازی discovery در `core/host_communication_discovery.py` است.

## ۱۲. وابستگی‌های اجرایی

Build رسمی با `python build_exe.py` دو فایل اجرایی را در یک بسته می‌سازد:

```text
dist/sw_setting/
├── sw_setting_gui.exe
├── sw_setting_cli.exe
├── _internal/
└── files/codegen_output/JSON/
```

`sw_setting_gui.exe` از نوع windowed و فقط نقطهٔ ورود GUI است. `sw_setting_cli.exe` از نوع console است و هم فرمان‌های CLI و هم `serve-http` مستقل را اجرا می‌کند. GUI در حالت بسته‌بندی‌شده فرمان‌ها و سرور تحت مالکیت خود را با همین EXE دوم راه می‌اندازد. اگر در `127.0.0.1:8000` از قبل سروری فعال باشد، GUI به آن attach می‌شود و هنگام خروج آن process خارجی را متوقف نمی‌کند. کل پوشهٔ بالا باید منتقل شود؛ دو EXE کتابخانه‌های مشترکشان را از `_internal` می‌خوانند و CodeGen بیرون از فایل‌های اجرایی قابل‌جایگزینی باقی می‌ماند.

- Python؛
- `pymodbus` برای RTU/TCP؛
- `pyserial` برای Serial و فهرست COM؛
- `psutil` برای فهرست شبکه CLI؛
- `fastapi`، `pydantic` و `uvicorn` برای HTTP؛
- `PyQt6` فقط برای GUI.

در پروژه فعلی فایل استاندارد dependency مانند `requirements.txt` یا `pyproject.toml` دیده نمی‌شود؛ خطای import را علاوه بر فایل مصرف‌کننده، در محیط نصب نیز بررسی کنید.

## ۱۳. ترتیب پیشنهادی برای دنبال‌کردن یک باگ

1. مشخص کنید باگ فقط در CLI، فقط HTTP یا فقط GUI رخ می‌دهد.
2. ورودی و state را در entry point و `CommandSessionContext` بررسی کنید.
3. handler همان command را پیدا کنید؛ handler باید orchestration کند، نه protocol پایین‌دست را.
4. به سرویس core مربوط بروید: Loader، Identify، Profile یا CommandExecutor.
5. برای خطای داده، مدل/Catalog/Codec؛ برای خطای ارتباط، `DeviceModbusLink` و تنظیمات را بررسی کنید.
6. Unit ID، JSON package و آخرین state کش‌شده را همیشه کنترل کنید.
7. یک تست کوچک در `tests/` بسازید که بدون سخت‌افزار و با fake link رفتار خراب را بازتولید کند.
