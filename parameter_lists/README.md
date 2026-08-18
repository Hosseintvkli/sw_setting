## الزامات تهیه فایل اکسل
- توضیحات متنی نوشته شده باید در یک خط باشد. (مثلا در ستون های Description)
- آدرس پارامترهای زیر باید ثابت باشند :

| Parameter               | Type   | Address |
|-------------------------|--------|---------|
| DeviceId                | U16    | 0       |
| ParameterListVersion    | U16    | 1       |
| FwVersionMajor          | U16    | 2       |
| FwVersionMinor          | U16    | 3       |
| FwVersionBuild1         | U16    | 4       |
| FwVersionBuild2         | U32    | 5       |
| SerialNo                | U32    | 7       |
| HwVersionMajor          | U16    | 9       |
| HwVersionMinor          | U16    | 10      |
| ProductionYear          | U16    | 11      |
| ProductionMonth         | U16    | 12      |
| ProductionDay           | U16    | 13      |
| DownStreamQty           | U16    | 14      |
| DownStreamsStartAddr    | U16    | 15      |
| DownStreamsSettingSize  | U16    | 16      |
| SlaveId                 | U16    | 4000    |
| IdentifyStatus          | U16    | 4001    |
| StreamingEnableCmd      | U16    | 4002    |
| StreamingDisableCmd     | U16    | 4003    |

- برای محصولات شرکت، DeviceId باید از 1000 شروع شود.
- مقادیر کمتر از 1000 برای زیرساخت تولید شرکت است.
- حداکثر 246 محصول در یک اتصال زیرساخت قابل شناسایی است.
- پروتکل streamer از ترتیب بایت‌های little-endian پیروی می‌کند.

