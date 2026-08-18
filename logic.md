Markdown# مشخصات کامل نرم‌افزار تنظیم دستگاه (Device Setting Tool / `sw_setting`)

این سند **مشخصات عملکردی و فنی کامل** نرم‌افزاری است که برای پیکربندی دستگاه‌های امبدد از طریق مدباس پیاده‌سازی شده است. هدف این است که یک نفر (یا یک هوش مصنوعی) **فقط با خواندن همین فایل** بتواند دقیقاً همان رفتار را بازپیاده‌سازی کند.

---

## ۰. قوانین طراحی اجباری

1. **نام‌گذاری:** نام متغیرها، توابع، کلاس‌ها و فیلدها باید طولانی و خودتوضیح باشد. با دیدن نام باید مشخص شود چه چیزی نگه می‌دارد یا چه کاری می‌کند. کوتاه‌نویسی عمدی ممنوع است.
2. **ماژولار بودن:** هر مسئولیت در فایل/ماژول جدا. UI به منطق مدباس وابستهٔ مستقیم نباشد؛ Identify از UI جدا؛ پارس JSON جدا.
3. **مسیر JSON ثابت است.** کاربر مسیر پوشهٔ CodeGen را انتخاب نمی‌کند.
4. **بدون SlaveId در صفحهٔ اتصال.** unit/slave از Identify و انتخاب دستگاه در درخت می‌آید.

---

## ۱. هدف محصول

| قابلیت | توضیح |
|--------|--------|
| ارتباط | سریال Modbus RTU یا شبکه Modbus TCP |
| Identify | کشف توپولوژی چندلایه هاب/دستگاه و اختصاص SlaveId |
| SETTING | خواندن و نوشتن پارامترها از JSON تولیدی CodeGen |
| Profile | اعمال / تأیید / ذخیره تنظیمات از/به CSV |
| Command | اجرای دستور با پروتکل 0xFFFF و poll نتیجه |

---

## ۲. ساختار پوشه‌ها

```text
sw_setting/
  main.py
  README.md
  README_FA.md
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
مسیر ثابت کاتالوگ
text<cwd یا کنار main.py>/files/codegen_output/JSON
تابع مثلاً get_fixed_codegen_json_root_directory() این مسیر را برمی‌گرداند. UI برای انتخاب مسیر نیست.
زیر JSON:
textJSON/
  cg_database_deviceid.json
  parameter_list_<DeviceId>/
    parameter_list_<DeviceId>_<Version>/
      cg_parameter_list_<DeviceId>_<Version>_info.json
      cg_parameter_list_<DeviceId>_<Version>_parameter_list.json
با (DeviceId, ParameterListVersion) خوانده‌شده از دستگاه، package متناظر لود می‌شود. نسخه‌های قدیمی JSON باید بمانند.

۳. مدل CodeGen
info

DeviceId (int)
ParameterListVersion (int)
نام دستگاه برای نمایش

parameter_list (آرایه)

































فیلدمعنیNameیکتا؛ . سلسله‌مراتب؛ [n] آرایهModbusAddrآدرس holdingModbusSizeتعداد رجیستر ۱۶بیتیDataTypeU8/U16/U32/U64/I8/I16/I32/I64/F32/F64 و مشابهParameterTypeشامل MONITORING / SETTING / COMMANDTag1…Tag5برچسب
دسته درخت UI = Tag2 (اگر خالی: (No Tag2)).
نگاشت: COMMAND در نام نوع → Command؛ SETTING → Setting؛ وگرنه Monitoring.

۴. آدرس‌های holding ثابت





























آدرسمعنی0DeviceId1ParameterListVersion14DownStreamQty (0 = برگ)4000SlaveId4001IdentifyStatus (1=فعال، پایان=0)
DownStreamsSetting[i].SlaveIdMin / Max: آدرس از JSON همان نسخه با نام دقیق پارامتر.

۵. کدک رجیستر
چندرجیستری: little-endian word order (word کم‌ارزش اول) + struct با <.
توابع: encode، decode، تعداد رجیستر نوع، قالب نمایش.

۶. ارتباط (Communicate)
مدل

link_kind: SERIAL_RTU | ETHERNET_TCP
سریال: port، baud، read/write timeout ms
اترنت: local interface name + local IPv4، device IP، TCP port (502)، connect/read/write timeout
modbus_unit_identifier پیش‌فرض داخلی 1 (در UI اتصال نباشد)
modbus_transaction_retry_count پیش‌فرض 3

سریال UI
لیست COM + Refresh؛ baud استاندارد + Custom؛ timeoutها؛ Retries مشترک.
اترنت UI
لیست شبکه محلی (نام — IP) + Refresh (psutil یا PowerShell Get-NetIPAddress بدون 127)؛ Device IP؛ port؛ timeoutها.
Connect / Disconnect
زیر تنظیمات در همان تب؛ هنگام Connected تنظیمات غیرفعال.
Retry READ
فوری → شکست → صبر Read timeout → تکرار تا Retries.
Broadcast unit 0
بدون پاسخ؛ timeout = موفقیت.

۷. DeviceModbusLink
Connect/disconnect؛ read/write holding U16؛ unit اختیاری روی هر فراخوانی؛ override بعد از انتخاب دستگاه؛ اولویت unit: آرگومان > override > پیش‌فرض settings؛ سازگاری device_id= و slave= در pymodbus.

۸. Identify (جزئیات)
قواعد هاب

unit 0: همه اعمال + forward پایین؛ جواب نیست
unicast غیرخود: اگر در [Min,Max] پورت → forward
استخر دائمی: 247 → 2؛ 1 فقط موقت؛ 0 broadcast

الگوریتم

Broadcast 4000=1 و 4001=1
Probe unit=1: DeviceId، Version → JSON
Assign SlaveId دائمی؛ WRITE 4000 روی unit=1
اگر parent: وصل به پورت + قبل از unicast دائمی باز کردن Min/Max اجداد
READ unit دائمی addr 14 = DownStreamQty
برای هر پورت i:
کشف: i → 1..1
کشف‌شده‌ها: فقط permanent زیردرخت (بدون 1)
اسکن‌نشده: 0..0
اجداد مسیر unit=1 را تا این هاب pass کنند
probe unit=1؛ خالی → 0..0 و ادامه پورت بعد
پیدا شد → assign، بازگشتی، بعد seal بازه permanent

Broadcast 4001=0

شکست وسط کار: partial tree در UI.
نمایش درخت
textHub
  port[0]: Child
    port[0]: (no connection)
    port[1]: Leaf
  port[1]: (no connection)
پورت‌ها هم‌سطح؛ port[i]: name یا (no connection)؛ دابل‌کلیک فقط روی گره دستگاه.

۹. UI کلی
سه ستون splitter؛ چپ قابل resize (min ~280، بدون max قفل).
وسط Parameters: هدر monitoring (SlaveID, DeviceId, SerialNo, HW, FW)؛ فقط Reload؛ درخت Tag2 + Name؛ Value قابل ویرایش+Enter؛ progress مخفی بعد از اتمام؛ حفظ عرض ستون.
لود SETTING: unit صریح روی همه read؛ batch؛ errors per leaf.
Profile: CSV؛ تیک همه DeviceId مشابه از درخت Identify؛ Apply/Verify/Save؛ Save بعد از Reload؛ لاگ رنگی.
CSV: ستون1=Name؛ ستونهای بعد=مقادیر؛ گسترش آرایه از ایندکس Name.
Commands: لیست COMMAND؛ Execute: write 0xFFFF؛ poll: بی‌پاسخ=در حال اجرا؛ FFFF=pending؛ 0=موفق؛ دیگر=کد خطا.
راست: لاگ رنگی مختصر.

۱۰. اعتبارسنجی
قبل write: بازه و صحیح/اعشاری بودن مطابق DataType.

۱۱. فناوری
Python 3.10+، PyQt6، pymodbus، pyserial، اختیاری psutil. اجرا از ریشه sw_setting.

۱۲. جریان کاربر
Connect → Identify → دابل‌کلیک دستگاه → Parameters/Profile/Commands → Disconnect.

۱۳. دام‌های الزامی

Broadcast بدون reply
کشف با unit 1
بعد assign، اول routing اجداد بعد READ دائمی
پورت‌های قبلی بدون 1 در Min/Max هنگام کشف پورت بعد
خطای یک پورت بقیه را قطع نکند
partial topology
JSON ثابت
دسته = Tag2
little-endian چندرجیستری
unit صریح در لود SETTING
Save Profile بعد Reload
پنل چپ unlock


۱۴. چک‌لیست فایل‌ها





























































فایلنقشmain.pyورودcommunication_settings.pyمدل settingscommunication_panel.pyUI ارتباطdevice_modbus_link.pyI/O مدباسcodegen_parameter_list_*JSONmodbus_register_value_codec.pyencode/decodeparameter_value_validation.pyvalidatedevice_setting_tree_loader.pyلود SETTINGdevice_topology_models.pyدرختdevice_identify_session.pyIdentifysetting_profile_csv.pyCSVdevice_command_executor.pyCommandmain_window.pyارکستراسیون UI

۱۵. Acceptance

 Connect سریال/TCP
 Identify چندلایه؛ پورت خالی/پر؛ پورت دوم بعد از اول
 درخت Devices طبق فرمت بالا
 دابل‌کلیک + لود SETTING
 ویرایش Value
 Profile Apply/Verify/Save + multi DeviceId
 Command 0 / FFFF / کد خطا / timeout
 Broadcast بدون قفل
 JSON مسیر ثابت و چندنسخه