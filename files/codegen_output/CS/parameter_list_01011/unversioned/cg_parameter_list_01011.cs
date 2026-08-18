using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
╔══════════════════════════╗
║ parameter_list_atlas_alg ║
╚══════════════════════════╝
*/

namespace ACCUNAV_IMU_Setting
{
    [DefaultProperty("SerialNo")]
    public class Parameters_DeviceID_01011 : IParameterListDevice
    {
        private bool readedOnce;

        public UInt16 deviceId;
        public UInt16 parameterListVersion;
        public UInt16 fwVersionMajor;
        public UInt16 fwVersionMinor;
        public UInt16 fwVersionBuild1;
        public UInt32 fwVersionBuild2;
        public UInt32 serialNo;
        public UInt16 hwVersionMajor;
        public UInt16 hwVersionMinor;
        public UInt16 productionYear;
        public UInt16 productionMonth;
        public UInt16 productionDay;
        public UInt16 downStreamQty;
        public UInt16 downStreamsStartAddr;
        public UInt16 downStreamsSettingSize;
        public UInt16 memoryRetryQty;
        public UInt16 memoryRetryDelayMs;
        public UInt16 watchdogTimeMs;
        public UInt16 dateYearConfig;
        public UInt16 dateMonthConfig;
        public UInt16 dateDayConfig;
        public UInt16 clockHourConfig;
        public UInt16 clockMinuteConfig;
        public UInt16 clockSecondConfig;
        public UInt32 upStreamBaudrate;
        public UInt16[] shodowHoldingRegisterConfig;
        public UInt16 slaveId;
        public UInt16 identifyStatus;
        public UInt32 downStreamBaudrate;
        public UInt16 upStreamDelayBetweenFrameUs;
        public UInt16 streamerEnable;
        public UInt16 streamerExtendedHeaderEnable;
        public UInt16 streamerInternalClockIntervalMs;
        public UInt16 streamerPrescaler;
        public UInt16[] streamerParameterIds;
        public UInt16 boardStartupDelayMs;
        public UInt16 boardStartupRetryQty;
        public UInt16 boardStartupRetryDelayMs;
        public sExternalImuSetting externalImu_Setting;
        public sProfilerSetting mainLoopProfilerSetting;
        public Double[] debugControlSignalsF64;
        public Single[] debugControlSignalsF32;
        public UInt32[] debugControlSignalsU32;
        public Int32[] debugControlSignalsI32;
        public UInt16[] debugControlSignalsU16;
        public Int16[] debugControlSignalsI16;
        public UInt16 outputStabilizationCycleQty;
        public UInt16 rawDataStabilizationCycleQty;
        public Double northFinding1_EulerAngleI32_Range;
        public UInt16 northFinding1_Type;
        public UInt16 northFinding1_GyroNumber;
        public UInt16 northFinding1_AccNumber;
        public Double[] northFinding1_LLA;
        public Double northFinding1_Limit_Acc_ug;
        public Double northFinding1_Limit_Gyr_dph;
        public Double northFinding1_Max_questCounter;
        public Double northFinding1_Reset_questCounter;
        public Double northFinding1_ZVDConfig_threshold;
        public Double northFinding1_ZVDConfig_TimeThreshold;
        public Double northFinding1_InitialNorthFindingTime;
        public Double northFinding1_DuringNorthFindingTime;
        public Double northFinding1_AlignTime_s;
        public UInt16 outputDecimationRate;
        public Double sensorAccI32_Range;
        public Double sensorGyroI32_Range;
        public Double sensorTemperatureI16_Range;
        public Double calcFaultDetection_WarmUpTempRateWarningLevel;
        public Double calcFaultDetection_AfterWarmUpTempRateWarningLevel;
        public UInt16 calcFaultDetection_InitIdleTimeS;
        public UInt16 calcFaultDetection_AddedWarmUpTimeS;
        public Double calcFaultDetection_AfterAlgReset_IdleTimeS;
        public Double[] rotationCoordinateAnglesDegree;
        public Double calcPreProcessAlgorithm_AccI32_Range;
        public Double calcPreProcessAlgorithm_GyroI32_Range;

        public Parameters_DeviceID_01011()
        {
            readedOnce = false;
        
            deviceId = 1011;
            parameterListVersion = 0;
            fwVersionMajor = 0;
            fwVersionMinor = 0;
            fwVersionBuild1 = 0;
            fwVersionBuild2 = 0;
            serialNo = 0;
            hwVersionMajor = 0;
            hwVersionMinor = 0;
            productionYear = 0;
            productionMonth = 0;
            productionDay = 0;
            downStreamQty = 0;
            downStreamsStartAddr = 0;
            downStreamsSettingSize = 0;
            memoryRetryQty = 3;
            memoryRetryDelayMs = 50;
            watchdogTimeMs = 0;
            dateYearConfig = 0;
            dateMonthConfig = 0;
            dateDayConfig = 0;
            clockHourConfig = 0;
            clockMinuteConfig = 0;
            clockSecondConfig = 0;
            upStreamBaudrate = 2000000;
            shodowHoldingRegisterConfig = new UInt16[1000];
            slaveId = 1;
            identifyStatus = 0;
            downStreamBaudrate = 2000000;
            upStreamDelayBetweenFrameUs = 50;
            streamerEnable = 0;
            streamerExtendedHeaderEnable = 0;
            streamerInternalClockIntervalMs = 10;
            streamerPrescaler = 19;
            streamerParameterIds = new UInt16[200];
            boardStartupDelayMs = 50;
            boardStartupRetryQty = 3;
            boardStartupRetryDelayMs = 50;
            externalImu_Setting = new sExternalImuSetting((UInt16)(4835));
            mainLoopProfilerSetting = new sProfilerSetting((UInt16)(5065));
            debugControlSignalsF64 = new Double[50];
            debugControlSignalsF32 = new Single[50];
            debugControlSignalsU32 = new UInt32[50];
            debugControlSignalsI32 = new Int32[50];
            debugControlSignalsU16 = new UInt16[50];
            debugControlSignalsI16 = new Int16[50];
            outputStabilizationCycleQty = 100;
            rawDataStabilizationCycleQty = 100;
            northFinding1_EulerAngleI32_Range = 0;
            northFinding1_Type = 0;
            northFinding1_GyroNumber = 0;
            northFinding1_AccNumber = 0;
            northFinding1_LLA = new Double[3];
            northFinding1_Limit_Acc_ug = 0;
            northFinding1_Limit_Gyr_dph = 0;
            northFinding1_Max_questCounter = 0;
            northFinding1_Reset_questCounter = 0;
            northFinding1_ZVDConfig_threshold = 0;
            northFinding1_ZVDConfig_TimeThreshold = 0;
            northFinding1_InitialNorthFindingTime = 0;
            northFinding1_DuringNorthFindingTime = 0;
            northFinding1_AlignTime_s = 0;
            outputDecimationRate = 0;
            sensorAccI32_Range = 0;
            sensorGyroI32_Range = 0;
            sensorTemperatureI16_Range = 0;
            calcFaultDetection_WarmUpTempRateWarningLevel = 0;
            calcFaultDetection_AfterWarmUpTempRateWarningLevel = 0;
            calcFaultDetection_InitIdleTimeS = 0;
            calcFaultDetection_AddedWarmUpTimeS = 0;
            calcFaultDetection_AfterAlgReset_IdleTimeS = 0;
            rotationCoordinateAnglesDegree = new Double[3];
            calcPreProcessAlgorithm_AccI32_Range = 0;
            calcPreProcessAlgorithm_GyroI32_Range = 0;
        }

        [Category("Info"), ReadOnly(false), DefaultValue(0), Description("")]
        public UInt32 SerialNo
        {
            get { return serialNo; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(7, 0, value, typeof(UInt32), 1))
                {
                    serialNo = value;
                    MainForm.modbusExt.RefreshDeviceSerialNoInfo(serialNo);
                }
            }
        }

        [Category("Info"), ReadOnly(false), DefaultValue(0), Description("")]
        public UInt16 HwVersionMajor
        {
            get { return hwVersionMajor; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(9, 0, value, typeof(UInt16), 1))
                {
                    hwVersionMajor = value;
                }
            }
        }

        [Category("Info"), ReadOnly(false), DefaultValue(0), Description("")]
        public UInt16 HwVersionMinor
        {
            get { return hwVersionMinor; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(10, 0, value, typeof(UInt16), 1))
                {
                    hwVersionMinor = value;
                }
            }
        }

        [Category("Info"), ReadOnly(false), DefaultValue(0), Description("")]
        public UInt16 ProductionYear
        {
            get { return productionYear; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(11, 0, value, typeof(UInt16), 1))
                {
                    productionYear = value;
                }
            }
        }

        [Category("Info"), ReadOnly(false), DefaultValue(0), Description("")]
        public UInt16 ProductionMonth
        {
            get { return productionMonth; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(12, 0, value, typeof(UInt16), 1))
                {
                    productionMonth = value;
                }
            }
        }

        [Category("Info"), ReadOnly(false), DefaultValue(0), Description("")]
        public UInt16 ProductionDay
        {
            get { return productionDay; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(13, 0, value, typeof(UInt16), 1))
                {
                    productionDay = value;
                }
            }
        }

        [Category("RappBaseParameterList"), ReadOnly(false), DefaultValue(3), Description("")]
        public UInt16 MemoryRetryQty
        {
            get { return memoryRetryQty; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(200, 0, value, typeof(UInt16), 1))
                {
                    memoryRetryQty = value;
                }
            }
        }

        [Category("RappBaseParameterList"), ReadOnly(false), DefaultValue(50), Description("")]
        public UInt16 MemoryRetryDelayMs
        {
            get { return memoryRetryDelayMs; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(201, 0, value, typeof(UInt16), 1))
                {
                    memoryRetryDelayMs = value;
                }
            }
        }

        [Category("RappBaseSystem"), ReadOnly(false), DefaultValue(0), Description("0 : Disable watchdog")]
        public UInt16 WatchdogTimeMs
        {
            get { return watchdogTimeMs; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(400, 0, value, typeof(UInt16), 1))
                {
                    watchdogTimeMs = value;
                }
            }
        }

        [Category("RappBaseSystem"), ReadOnly(false), DefaultValue(0), Description("")]
        public UInt16 DateYearConfig
        {
            get { return dateYearConfig; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(409, 0, value, typeof(UInt16), 1))
                {
                    dateYearConfig = value;
                }
            }
        }

        [Category("RappBaseSystem"), ReadOnly(false), DefaultValue(0), Description("")]
        public UInt16 DateMonthConfig
        {
            get { return dateMonthConfig; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(410, 0, value, typeof(UInt16), 1))
                {
                    dateMonthConfig = value;
                }
            }
        }

        [Category("RappBaseSystem"), ReadOnly(false), DefaultValue(0), Description("")]
        public UInt16 DateDayConfig
        {
            get { return dateDayConfig; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(411, 0, value, typeof(UInt16), 1))
                {
                    dateDayConfig = value;
                }
            }
        }

        [Category("RappBaseSystem"), ReadOnly(false), DefaultValue(0), Description("")]
        public UInt16 ClockHourConfig
        {
            get { return clockHourConfig; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(412, 0, value, typeof(UInt16), 1))
                {
                    clockHourConfig = value;
                }
            }
        }

        [Category("RappBaseSystem"), ReadOnly(false), DefaultValue(0), Description("")]
        public UInt16 ClockMinuteConfig
        {
            get { return clockMinuteConfig; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(413, 0, value, typeof(UInt16), 1))
                {
                    clockMinuteConfig = value;
                }
            }
        }

        [Category("RappBaseSystem"), ReadOnly(false), DefaultValue(0), Description("")]
        public UInt16 ClockSecondConfig
        {
            get { return clockSecondConfig; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(414, 0, value, typeof(UInt16), 1))
                {
                    clockSecondConfig = value;
                }
            }
        }

        [Category("RappSerialExpander"), ReadOnly(false), DefaultValue(2000000), Description("")]
        public UInt32 UpStreamBaudrate
        {
            get { return upStreamBaudrate; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(900, 0, value, typeof(UInt32), 1))
                {
                    upStreamBaudrate = value;
                }
            }
        }

        [Category("RappModbusSlave"), ReadOnly(false), Description("")]
        public UInt16[] ShodowHoldingRegisterConfig
        {
            get { return shodowHoldingRegisterConfig; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(2000, 0, value, typeof(UInt16), 1000))
                {
                    shodowHoldingRegisterConfig = value;
                }
            }
        }

        [Category("RappModbusSlave"), ReadOnly(false), DefaultValue(1), Description("ModbusExt node slave id")]
        public UInt16 SlaveId
        {
            get { return slaveId; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(4000, 0, value, typeof(UInt16), 1))
                {
                    slaveId = value;
                }
            }
        }

        [Category("RappModbusExtEvents"), ReadOnly(false), DefaultValue(0), Description("1 : Identify Started - 0 : Identify End")]
        public UInt16 IdentifyStatus
        {
            get { return identifyStatus; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(4001, 0, value, typeof(UInt16), 1))
                {
                    identifyStatus = value;
                }
            }
        }

        [Category("RappModbusExtEvents"), ReadOnly(false), DefaultValue(2000000), Description("")]
        public UInt32 DownStreamBaudrate
        {
            get { return downStreamBaudrate; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(4004, 0, value, typeof(UInt32), 1))
                {
                    downStreamBaudrate = value;
                }
            }
        }

        [Category("RappModbusExtEvents"), ReadOnly(false), DefaultValue(50), Description("")]
        public UInt16 UpStreamDelayBetweenFrameUs
        {
            get { return upStreamDelayBetweenFrameUs; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(4034, 0, value, typeof(UInt16), 1))
                {
                    upStreamDelayBetweenFrameUs = value;
                }
            }
        }

        [Category("RappPrtlStreamer"), ReadOnly(false), DefaultValue(0), Description("")]
        public UInt16 StreamerEnable
        {
            get { return streamerEnable; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(4035, 0, value, typeof(UInt16), 1))
                {
                    streamerEnable = value;
                }
            }
        }

        [Category("RappPrtlStreamer"), ReadOnly(false), DefaultValue(0), Description("")]
        public UInt16 StreamerExtendedHeaderEnable
        {
            get { return streamerExtendedHeaderEnable; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(4036, 0, value, typeof(UInt16), 1))
                {
                    streamerExtendedHeaderEnable = value;
                }
            }
        }

        [Category("RappPrtlStreamer"), ReadOnly(false), DefaultValue(10), Description("")]
        public UInt16 StreamerInternalClockIntervalMs
        {
            get { return streamerInternalClockIntervalMs; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(4037, 0, value, typeof(UInt16), 1))
                {
                    streamerInternalClockIntervalMs = value;
                }
            }
        }

        [Category("RappPrtlStreamer"), ReadOnly(false), DefaultValue(19), Description("")]
        public UInt16 StreamerPrescaler
        {
            get { return streamerPrescaler; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(4038, 0, value, typeof(UInt16), 1))
                {
                    streamerPrescaler = value;
                }
            }
        }

        [Category("RappPrtlStreamer"), ReadOnly(false), Description("")]
        public UInt16[] StreamerParameterIds
        {
            get { return streamerParameterIds; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(4039, 0, value, typeof(UInt16), 200))
                {
                    streamerParameterIds = value;
                }
            }
        }

        [Category("RappBaseBoardStartup"), ReadOnly(false), DefaultValue(50), Description("")]
        public UInt16 BoardStartupDelayMs
        {
            get { return boardStartupDelayMs; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(4247, 0, value, typeof(UInt16), 1))
                {
                    boardStartupDelayMs = value;
                }
            }
        }

        [Category("RappBaseBoardStartup"), ReadOnly(false), DefaultValue(3), Description("")]
        public UInt16 BoardStartupRetryQty
        {
            get { return boardStartupRetryQty; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(4248, 0, value, typeof(UInt16), 1))
                {
                    boardStartupRetryQty = value;
                }
            }
        }

        [Category("RappBaseBoardStartup"), ReadOnly(false), DefaultValue(50), Description("")]
        public UInt16 BoardStartupRetryDelayMs
        {
            get { return boardStartupRetryDelayMs; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(4249, 0, value, typeof(UInt16), 1))
                {
                    boardStartupRetryDelayMs = value;
                }
            }
        }

        [Category("RappBaseBoardStartup"), ReadOnly(false), Description("")]
        public sExternalImuSetting ExternalImu_Setting
        {
            get { return externalImu_Setting; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(4835, 0, value, typeof(sExternalImuSetting), 1))
                {
                    externalImu_Setting = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), Description("")]
        public sProfilerSetting MainLoopProfilerSetting
        {
            get { return mainLoopProfilerSetting; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(5065, 0, value, typeof(sProfilerSetting), 1))
                {
                    mainLoopProfilerSetting = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), Description("")]
        public Double[] DebugControlSignalsF64
        {
            get { return debugControlSignalsF64; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(5675, 0, value, typeof(Double), 50))
                {
                    debugControlSignalsF64 = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), Description("")]
        public Single[] DebugControlSignalsF32
        {
            get { return debugControlSignalsF32; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(5875, 0, value, typeof(Single), 50))
                {
                    debugControlSignalsF32 = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), Description("")]
        public UInt32[] DebugControlSignalsU32
        {
            get { return debugControlSignalsU32; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(5975, 0, value, typeof(UInt32), 50))
                {
                    debugControlSignalsU32 = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), Description("")]
        public Int32[] DebugControlSignalsI32
        {
            get { return debugControlSignalsI32; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6075, 0, value, typeof(Int32), 50))
                {
                    debugControlSignalsI32 = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), Description("")]
        public UInt16[] DebugControlSignalsU16
        {
            get { return debugControlSignalsU16; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6175, 0, value, typeof(UInt16), 50))
                {
                    debugControlSignalsU16 = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), Description("")]
        public Int16[] DebugControlSignalsI16
        {
            get { return debugControlSignalsI16; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6225, 0, value, typeof(Int16), 50))
                {
                    debugControlSignalsI16 = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(100), Description("")]
        public UInt16 OutputStabilizationCycleQty
        {
            get { return outputStabilizationCycleQty; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6275, 0, value, typeof(UInt16), 1))
                {
                    outputStabilizationCycleQty = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(100), Description("")]
        public UInt16 RawDataStabilizationCycleQty
        {
            get { return rawDataStabilizationCycleQty; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6276, 0, value, typeof(UInt16), 1))
                {
                    rawDataStabilizationCycleQty = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public Double NorthFinding1_EulerAngleI32_Range
        {
            get { return northFinding1_EulerAngleI32_Range; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6297, 0, value, typeof(Double), 1))
                {
                    northFinding1_EulerAngleI32_Range = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public UInt16 NorthFinding1_Type
        {
            get { return northFinding1_Type; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6308, 0, value, typeof(UInt16), 1))
                {
                    northFinding1_Type = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public UInt16 NorthFinding1_GyroNumber
        {
            get { return northFinding1_GyroNumber; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6309, 0, value, typeof(UInt16), 1))
                {
                    northFinding1_GyroNumber = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public UInt16 NorthFinding1_AccNumber
        {
            get { return northFinding1_AccNumber; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6310, 0, value, typeof(UInt16), 1))
                {
                    northFinding1_AccNumber = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), Description("")]
        public Double[] NorthFinding1_LLA
        {
            get { return northFinding1_LLA; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6311, 0, value, typeof(Double), 3))
                {
                    northFinding1_LLA = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public Double NorthFinding1_Limit_Acc_ug
        {
            get { return northFinding1_Limit_Acc_ug; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6326, 0, value, typeof(Double), 1))
                {
                    northFinding1_Limit_Acc_ug = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public Double NorthFinding1_Limit_Gyr_dph
        {
            get { return northFinding1_Limit_Gyr_dph; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6330, 0, value, typeof(Double), 1))
                {
                    northFinding1_Limit_Gyr_dph = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public Double NorthFinding1_Max_questCounter
        {
            get { return northFinding1_Max_questCounter; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6334, 0, value, typeof(Double), 1))
                {
                    northFinding1_Max_questCounter = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public Double NorthFinding1_Reset_questCounter
        {
            get { return northFinding1_Reset_questCounter; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6338, 0, value, typeof(Double), 1))
                {
                    northFinding1_Reset_questCounter = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public Double NorthFinding1_ZVDConfig_threshold
        {
            get { return northFinding1_ZVDConfig_threshold; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6342, 0, value, typeof(Double), 1))
                {
                    northFinding1_ZVDConfig_threshold = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public Double NorthFinding1_ZVDConfig_TimeThreshold
        {
            get { return northFinding1_ZVDConfig_TimeThreshold; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6346, 0, value, typeof(Double), 1))
                {
                    northFinding1_ZVDConfig_TimeThreshold = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public Double NorthFinding1_InitialNorthFindingTime
        {
            get { return northFinding1_InitialNorthFindingTime; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6350, 0, value, typeof(Double), 1))
                {
                    northFinding1_InitialNorthFindingTime = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public Double NorthFinding1_DuringNorthFindingTime
        {
            get { return northFinding1_DuringNorthFindingTime; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6354, 0, value, typeof(Double), 1))
                {
                    northFinding1_DuringNorthFindingTime = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public Double NorthFinding1_AlignTime_s
        {
            get { return northFinding1_AlignTime_s; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6362, 0, value, typeof(Double), 1))
                {
                    northFinding1_AlignTime_s = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public UInt16 OutputDecimationRate
        {
            get { return outputDecimationRate; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6366, 0, value, typeof(UInt16), 1))
                {
                    outputDecimationRate = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public Double SensorAccI32_Range
        {
            get { return sensorAccI32_Range; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6695, 0, value, typeof(Double), 1))
                {
                    sensorAccI32_Range = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public Double SensorGyroI32_Range
        {
            get { return sensorGyroI32_Range; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6717, 0, value, typeof(Double), 1))
                {
                    sensorGyroI32_Range = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public Double SensorTemperatureI16_Range
        {
            get { return sensorTemperatureI16_Range; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6726, 0, value, typeof(Double), 1))
                {
                    sensorTemperatureI16_Range = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public Double CalcFaultDetection_WarmUpTempRateWarningLevel
        {
            get { return calcFaultDetection_WarmUpTempRateWarningLevel; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6730, 0, value, typeof(Double), 1))
                {
                    calcFaultDetection_WarmUpTempRateWarningLevel = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public Double CalcFaultDetection_AfterWarmUpTempRateWarningLevel
        {
            get { return calcFaultDetection_AfterWarmUpTempRateWarningLevel; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6734, 0, value, typeof(Double), 1))
                {
                    calcFaultDetection_AfterWarmUpTempRateWarningLevel = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public UInt16 CalcFaultDetection_InitIdleTimeS
        {
            get { return calcFaultDetection_InitIdleTimeS; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6738, 0, value, typeof(UInt16), 1))
                {
                    calcFaultDetection_InitIdleTimeS = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public UInt16 CalcFaultDetection_AddedWarmUpTimeS
        {
            get { return calcFaultDetection_AddedWarmUpTimeS; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6739, 0, value, typeof(UInt16), 1))
                {
                    calcFaultDetection_AddedWarmUpTimeS = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public Double CalcFaultDetection_AfterAlgReset_IdleTimeS
        {
            get { return calcFaultDetection_AfterAlgReset_IdleTimeS; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6740, 0, value, typeof(Double), 1))
                {
                    calcFaultDetection_AfterAlgReset_IdleTimeS = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), Description("")]
        public Double[] RotationCoordinateAnglesDegree
        {
            get { return rotationCoordinateAnglesDegree; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6767, 0, value, typeof(Double), 3))
                {
                    rotationCoordinateAnglesDegree = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public Double CalcPreProcessAlgorithm_AccI32_Range
        {
            get { return calcPreProcessAlgorithm_AccI32_Range; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6815, 0, value, typeof(Double), 1))
                {
                    calcPreProcessAlgorithm_AccI32_Range = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public Double CalcPreProcessAlgorithm_GyroI32_Range
        {
            get { return calcPreProcessAlgorithm_GyroI32_Range; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6819, 0, value, typeof(Double), 1))
                {
                    calcPreProcessAlgorithm_GyroI32_Range = value;
                }
            }
        }

        public bool ModbusWriteAll()
        {
            bool _status = true;
        
            _status &= MainForm.modbusExt.ModbusWrite(7, 0, serialNo, typeof(UInt32), 1);
            _status &= MainForm.modbusExt.ModbusWrite(9, 0, hwVersionMajor, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(10, 0, hwVersionMinor, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(11, 0, productionYear, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(12, 0, productionMonth, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(13, 0, productionDay, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(200, 0, memoryRetryQty, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(201, 0, memoryRetryDelayMs, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(400, 0, watchdogTimeMs, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(409, 0, dateYearConfig, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(410, 0, dateMonthConfig, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(411, 0, dateDayConfig, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(412, 0, clockHourConfig, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(413, 0, clockMinuteConfig, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(414, 0, clockSecondConfig, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(900, 0, upStreamBaudrate, typeof(UInt32), 1);
            _status &= MainForm.modbusExt.ModbusWrite(2000, 0, shodowHoldingRegisterConfig, typeof(UInt16), 1000);
            _status &= MainForm.modbusExt.ModbusWrite(4000, 0, slaveId, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(4001, 0, identifyStatus, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(4004, 0, downStreamBaudrate, typeof(UInt32), 1);
            _status &= MainForm.modbusExt.ModbusWrite(4034, 0, upStreamDelayBetweenFrameUs, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(4035, 0, streamerEnable, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(4036, 0, streamerExtendedHeaderEnable, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(4037, 0, streamerInternalClockIntervalMs, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(4038, 0, streamerPrescaler, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(4039, 0, streamerParameterIds, typeof(UInt16), 200);
            _status &= MainForm.modbusExt.ModbusWrite(4247, 0, boardStartupDelayMs, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(4248, 0, boardStartupRetryQty, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(4249, 0, boardStartupRetryDelayMs, typeof(UInt16), 1);
            _status &= externalImu_Setting.ModbusWriteAll();
            _status &= mainLoopProfilerSetting.ModbusWriteAll();
            _status &= MainForm.modbusExt.ModbusWrite(5675, 0, debugControlSignalsF64, typeof(Double), 50);
            _status &= MainForm.modbusExt.ModbusWrite(5875, 0, debugControlSignalsF32, typeof(Single), 50);
            _status &= MainForm.modbusExt.ModbusWrite(5975, 0, debugControlSignalsU32, typeof(UInt32), 50);
            _status &= MainForm.modbusExt.ModbusWrite(6075, 0, debugControlSignalsI32, typeof(Int32), 50);
            _status &= MainForm.modbusExt.ModbusWrite(6175, 0, debugControlSignalsU16, typeof(UInt16), 50);
            _status &= MainForm.modbusExt.ModbusWrite(6225, 0, debugControlSignalsI16, typeof(Int16), 50);
            _status &= MainForm.modbusExt.ModbusWrite(6275, 0, outputStabilizationCycleQty, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(6276, 0, rawDataStabilizationCycleQty, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(6297, 0, northFinding1_EulerAngleI32_Range, typeof(Double), 1);
            _status &= MainForm.modbusExt.ModbusWrite(6308, 0, northFinding1_Type, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(6309, 0, northFinding1_GyroNumber, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(6310, 0, northFinding1_AccNumber, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(6311, 0, northFinding1_LLA, typeof(Double), 3);
            _status &= MainForm.modbusExt.ModbusWrite(6326, 0, northFinding1_Limit_Acc_ug, typeof(Double), 1);
            _status &= MainForm.modbusExt.ModbusWrite(6330, 0, northFinding1_Limit_Gyr_dph, typeof(Double), 1);
            _status &= MainForm.modbusExt.ModbusWrite(6334, 0, northFinding1_Max_questCounter, typeof(Double), 1);
            _status &= MainForm.modbusExt.ModbusWrite(6338, 0, northFinding1_Reset_questCounter, typeof(Double), 1);
            _status &= MainForm.modbusExt.ModbusWrite(6342, 0, northFinding1_ZVDConfig_threshold, typeof(Double), 1);
            _status &= MainForm.modbusExt.ModbusWrite(6346, 0, northFinding1_ZVDConfig_TimeThreshold, typeof(Double), 1);
            _status &= MainForm.modbusExt.ModbusWrite(6350, 0, northFinding1_InitialNorthFindingTime, typeof(Double), 1);
            _status &= MainForm.modbusExt.ModbusWrite(6354, 0, northFinding1_DuringNorthFindingTime, typeof(Double), 1);
            _status &= MainForm.modbusExt.ModbusWrite(6362, 0, northFinding1_AlignTime_s, typeof(Double), 1);
            _status &= MainForm.modbusExt.ModbusWrite(6366, 0, outputDecimationRate, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(6695, 0, sensorAccI32_Range, typeof(Double), 1);
            _status &= MainForm.modbusExt.ModbusWrite(6717, 0, sensorGyroI32_Range, typeof(Double), 1);
            _status &= MainForm.modbusExt.ModbusWrite(6726, 0, sensorTemperatureI16_Range, typeof(Double), 1);
            _status &= MainForm.modbusExt.ModbusWrite(6730, 0, calcFaultDetection_WarmUpTempRateWarningLevel, typeof(Double), 1);
            _status &= MainForm.modbusExt.ModbusWrite(6734, 0, calcFaultDetection_AfterWarmUpTempRateWarningLevel, typeof(Double), 1);
            _status &= MainForm.modbusExt.ModbusWrite(6738, 0, calcFaultDetection_InitIdleTimeS, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(6739, 0, calcFaultDetection_AddedWarmUpTimeS, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(6740, 0, calcFaultDetection_AfterAlgReset_IdleTimeS, typeof(Double), 1);
            _status &= MainForm.modbusExt.ModbusWrite(6767, 0, rotationCoordinateAnglesDegree, typeof(Double), 3);
            _status &= MainForm.modbusExt.ModbusWrite(6815, 0, calcPreProcessAlgorithm_AccI32_Range, typeof(Double), 1);
            _status &= MainForm.modbusExt.ModbusWrite(6819, 0, calcPreProcessAlgorithm_GyroI32_Range, typeof(Double), 1);
            
            if (!_status)
            {
                MessageBox.Show("Writing all parameters failed!", "Modbus error ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return _status;
        }

        public void ModbusReadAll()
        {
            if (readedOnce){return;} else
            {
                deviceId = MainForm.modbusExt.ModbusRead(0, 0, typeof(UInt16), 1);
                parameterListVersion = MainForm.modbusExt.ModbusRead(1, 0, typeof(UInt16), 1);
                fwVersionMajor = MainForm.modbusExt.ModbusRead(2, 0, typeof(UInt16), 1);
                fwVersionMinor = MainForm.modbusExt.ModbusRead(3, 0, typeof(UInt16), 1);
                fwVersionBuild1 = MainForm.modbusExt.ModbusRead(4, 0, typeof(UInt16), 1);
                fwVersionBuild2 = MainForm.modbusExt.ModbusRead(5, 0, typeof(UInt32), 1);
                serialNo = MainForm.modbusExt.ModbusRead(7, 0, typeof(UInt32), 1);
                hwVersionMajor = MainForm.modbusExt.ModbusRead(9, 0, typeof(UInt16), 1);
                hwVersionMinor = MainForm.modbusExt.ModbusRead(10, 0, typeof(UInt16), 1);
                productionYear = MainForm.modbusExt.ModbusRead(11, 0, typeof(UInt16), 1);
                productionMonth = MainForm.modbusExt.ModbusRead(12, 0, typeof(UInt16), 1);
                productionDay = MainForm.modbusExt.ModbusRead(13, 0, typeof(UInt16), 1);
                downStreamQty = MainForm.modbusExt.ModbusRead(14, 0, typeof(UInt16), 1);
                downStreamsStartAddr = MainForm.modbusExt.ModbusRead(15, 0, typeof(UInt16), 1);
                downStreamsSettingSize = MainForm.modbusExt.ModbusRead(16, 0, typeof(UInt16), 1);
                memoryRetryQty = MainForm.modbusExt.ModbusRead(200, 0, typeof(UInt16), 1);
                memoryRetryDelayMs = MainForm.modbusExt.ModbusRead(201, 0, typeof(UInt16), 1);
                watchdogTimeMs = MainForm.modbusExt.ModbusRead(400, 0, typeof(UInt16), 1);
                dateYearConfig = MainForm.modbusExt.ModbusRead(409, 0, typeof(UInt16), 1);
                dateMonthConfig = MainForm.modbusExt.ModbusRead(410, 0, typeof(UInt16), 1);
                dateDayConfig = MainForm.modbusExt.ModbusRead(411, 0, typeof(UInt16), 1);
                clockHourConfig = MainForm.modbusExt.ModbusRead(412, 0, typeof(UInt16), 1);
                clockMinuteConfig = MainForm.modbusExt.ModbusRead(413, 0, typeof(UInt16), 1);
                clockSecondConfig = MainForm.modbusExt.ModbusRead(414, 0, typeof(UInt16), 1);
                upStreamBaudrate = MainForm.modbusExt.ModbusRead(900, 0, typeof(UInt32), 1);
                shodowHoldingRegisterConfig = MainForm.modbusExt.ModbusRead(2000, 0, typeof(UInt16), 1000);
                slaveId = MainForm.modbusExt.ModbusRead(4000, 0, typeof(UInt16), 1);
                identifyStatus = MainForm.modbusExt.ModbusRead(4001, 0, typeof(UInt16), 1);
                downStreamBaudrate = MainForm.modbusExt.ModbusRead(4004, 0, typeof(UInt32), 1);
                upStreamDelayBetweenFrameUs = MainForm.modbusExt.ModbusRead(4034, 0, typeof(UInt16), 1);
                streamerEnable = MainForm.modbusExt.ModbusRead(4035, 0, typeof(UInt16), 1);
                streamerExtendedHeaderEnable = MainForm.modbusExt.ModbusRead(4036, 0, typeof(UInt16), 1);
                streamerInternalClockIntervalMs = MainForm.modbusExt.ModbusRead(4037, 0, typeof(UInt16), 1);
                streamerPrescaler = MainForm.modbusExt.ModbusRead(4038, 0, typeof(UInt16), 1);
                streamerParameterIds = MainForm.modbusExt.ModbusRead(4039, 0, typeof(UInt16), 200);
                boardStartupDelayMs = MainForm.modbusExt.ModbusRead(4247, 0, typeof(UInt16), 1);
                boardStartupRetryQty = MainForm.modbusExt.ModbusRead(4248, 0, typeof(UInt16), 1);
                boardStartupRetryDelayMs = MainForm.modbusExt.ModbusRead(4249, 0, typeof(UInt16), 1);
                externalImu_Setting.ModbusReadAll();
                mainLoopProfilerSetting.ModbusReadAll();
                debugControlSignalsF64 = MainForm.modbusExt.ModbusRead(5675, 0, typeof(Double), 50);
                debugControlSignalsF32 = MainForm.modbusExt.ModbusRead(5875, 0, typeof(Single), 50);
                debugControlSignalsU32 = MainForm.modbusExt.ModbusRead(5975, 0, typeof(UInt32), 50);
                debugControlSignalsI32 = MainForm.modbusExt.ModbusRead(6075, 0, typeof(Int32), 50);
                debugControlSignalsU16 = MainForm.modbusExt.ModbusRead(6175, 0, typeof(UInt16), 50);
                debugControlSignalsI16 = MainForm.modbusExt.ModbusRead(6225, 0, typeof(Int16), 50);
                outputStabilizationCycleQty = MainForm.modbusExt.ModbusRead(6275, 0, typeof(UInt16), 1);
                rawDataStabilizationCycleQty = MainForm.modbusExt.ModbusRead(6276, 0, typeof(UInt16), 1);
                northFinding1_EulerAngleI32_Range = MainForm.modbusExt.ModbusRead(6297, 0, typeof(Double), 1);
                northFinding1_Type = MainForm.modbusExt.ModbusRead(6308, 0, typeof(UInt16), 1);
                northFinding1_GyroNumber = MainForm.modbusExt.ModbusRead(6309, 0, typeof(UInt16), 1);
                northFinding1_AccNumber = MainForm.modbusExt.ModbusRead(6310, 0, typeof(UInt16), 1);
                northFinding1_LLA = MainForm.modbusExt.ModbusRead(6311, 0, typeof(Double), 3);
                northFinding1_Limit_Acc_ug = MainForm.modbusExt.ModbusRead(6326, 0, typeof(Double), 1);
                northFinding1_Limit_Gyr_dph = MainForm.modbusExt.ModbusRead(6330, 0, typeof(Double), 1);
                northFinding1_Max_questCounter = MainForm.modbusExt.ModbusRead(6334, 0, typeof(Double), 1);
                northFinding1_Reset_questCounter = MainForm.modbusExt.ModbusRead(6338, 0, typeof(Double), 1);
                northFinding1_ZVDConfig_threshold = MainForm.modbusExt.ModbusRead(6342, 0, typeof(Double), 1);
                northFinding1_ZVDConfig_TimeThreshold = MainForm.modbusExt.ModbusRead(6346, 0, typeof(Double), 1);
                northFinding1_InitialNorthFindingTime = MainForm.modbusExt.ModbusRead(6350, 0, typeof(Double), 1);
                northFinding1_DuringNorthFindingTime = MainForm.modbusExt.ModbusRead(6354, 0, typeof(Double), 1);
                northFinding1_AlignTime_s = MainForm.modbusExt.ModbusRead(6362, 0, typeof(Double), 1);
                outputDecimationRate = MainForm.modbusExt.ModbusRead(6366, 0, typeof(UInt16), 1);
                sensorAccI32_Range = MainForm.modbusExt.ModbusRead(6695, 0, typeof(Double), 1);
                sensorGyroI32_Range = MainForm.modbusExt.ModbusRead(6717, 0, typeof(Double), 1);
                sensorTemperatureI16_Range = MainForm.modbusExt.ModbusRead(6726, 0, typeof(Double), 1);
                calcFaultDetection_WarmUpTempRateWarningLevel = MainForm.modbusExt.ModbusRead(6730, 0, typeof(Double), 1);
                calcFaultDetection_AfterWarmUpTempRateWarningLevel = MainForm.modbusExt.ModbusRead(6734, 0, typeof(Double), 1);
                calcFaultDetection_InitIdleTimeS = MainForm.modbusExt.ModbusRead(6738, 0, typeof(UInt16), 1);
                calcFaultDetection_AddedWarmUpTimeS = MainForm.modbusExt.ModbusRead(6739, 0, typeof(UInt16), 1);
                calcFaultDetection_AfterAlgReset_IdleTimeS = MainForm.modbusExt.ModbusRead(6740, 0, typeof(Double), 1);
                rotationCoordinateAnglesDegree = MainForm.modbusExt.ModbusRead(6767, 0, typeof(Double), 3);
                calcPreProcessAlgorithm_AccI32_Range = MainForm.modbusExt.ModbusRead(6815, 0, typeof(Double), 1);
                calcPreProcessAlgorithm_GyroI32_Range = MainForm.modbusExt.ModbusRead(6819, 0, typeof(Double), 1);
            
                readedOnce = true;
            }
        }

        public void ResetReadFlag()
        {
            readedOnce = false;
        }

        public void Reload_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
            
            readedOnce = false;
            ModbusReadAll();
            MainForm.modbusExt.RefreshDevicePropertyGrid();
            
            MainForm.modbusExt.SetWaitCursor(false);
        }

        public void RestoreDefaultValue_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(202, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(202, 0, typeof(UInt16), 1);
        
                if (result != 0xFFFF)
                {
                    if (result == 0)
                    {
                        MessageBox.Show("Command Ok!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Command Error! Code: {result}", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
        
                Thread.Sleep(500);
        
                if (cnt++ > 20)
                {
                    MessageBox.Show("Command Error! Timeout!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            MainForm.modbusExt.SetWaitCursor(false);
        }

        public void LoadAll_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(203, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(203, 0, typeof(UInt16), 1);
        
                if (result != 0xFFFF)
                {
                    if (result == 0)
                    {
                        MessageBox.Show("Command Ok!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Command Error! Code: {result}", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
        
                Thread.Sleep(500);
        
                if (cnt++ > 20)
                {
                    MessageBox.Show("Command Error! Timeout!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            MainForm.modbusExt.SetWaitCursor(false);
        }

        public void LoadInfo_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(206, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(206, 0, typeof(UInt16), 1);
        
                if (result != 0xFFFF)
                {
                    if (result == 0)
                    {
                        MessageBox.Show("Command Ok!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Command Error! Code: {result}", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
        
                Thread.Sleep(500);
        
                if (cnt++ > 20)
                {
                    MessageBox.Show("Command Error! Timeout!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            MainForm.modbusExt.SetWaitCursor(false);
        }

        public void LoadModbusExt_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(207, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(207, 0, typeof(UInt16), 1);
        
                if (result != 0xFFFF)
                {
                    if (result == 0)
                    {
                        MessageBox.Show("Command Ok!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Command Error! Code: {result}", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
        
                Thread.Sleep(500);
        
                if (cnt++ > 20)
                {
                    MessageBox.Show("Command Error! Timeout!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            MainForm.modbusExt.SetWaitCursor(false);
        }

        public void LoadHardwareConfiguration_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(208, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(208, 0, typeof(UInt16), 1);
        
                if (result != 0xFFFF)
                {
                    if (result == 0)
                    {
                        MessageBox.Show("Command Ok!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Command Error! Code: {result}", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
        
                Thread.Sleep(500);
        
                if (cnt++ > 20)
                {
                    MessageBox.Show("Command Error! Timeout!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            MainForm.modbusExt.SetWaitCursor(false);
        }

        public void LoadFunctional_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(209, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(209, 0, typeof(UInt16), 1);
        
                if (result != 0xFFFF)
                {
                    if (result == 0)
                    {
                        MessageBox.Show("Command Ok!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Command Error! Code: {result}", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
        
                Thread.Sleep(500);
        
                if (cnt++ > 20)
                {
                    MessageBox.Show("Command Error! Timeout!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            MainForm.modbusExt.SetWaitCursor(false);
        }

        public void LoadSensorCalibCoef_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(210, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(210, 0, typeof(UInt16), 1);
        
                if (result != 0xFFFF)
                {
                    if (result == 0)
                    {
                        MessageBox.Show("Command Ok!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Command Error! Code: {result}", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
        
                Thread.Sleep(500);
        
                if (cnt++ > 20)
                {
                    MessageBox.Show("Command Error! Timeout!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            MainForm.modbusExt.SetWaitCursor(false);
        }

        public void LoadOutputCalibCoef_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(211, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(211, 0, typeof(UInt16), 1);
        
                if (result != 0xFFFF)
                {
                    if (result == 0)
                    {
                        MessageBox.Show("Command Ok!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Command Error! Code: {result}", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
        
                Thread.Sleep(500);
        
                if (cnt++ > 20)
                {
                    MessageBox.Show("Command Error! Timeout!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            MainForm.modbusExt.SetWaitCursor(false);
        }

        public void LoadOutputRotation_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(212, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(212, 0, typeof(UInt16), 1);
        
                if (result != 0xFFFF)
                {
                    if (result == 0)
                    {
                        MessageBox.Show("Command Ok!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Command Error! Code: {result}", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
        
                Thread.Sleep(500);
        
                if (cnt++ > 20)
                {
                    MessageBox.Show("Command Error! Timeout!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            MainForm.modbusExt.SetWaitCursor(false);
        }

        public void LoadWithForceAll_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(213, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(213, 0, typeof(UInt16), 1);
        
                if (result != 0xFFFF)
                {
                    if (result == 0)
                    {
                        MessageBox.Show("Command Ok!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Command Error! Code: {result}", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
        
                Thread.Sleep(500);
        
                if (cnt++ > 20)
                {
                    MessageBox.Show("Command Error! Timeout!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            MainForm.modbusExt.SetWaitCursor(false);
        }

        public void LoadWithForceInfo_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(214, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(214, 0, typeof(UInt16), 1);
        
                if (result != 0xFFFF)
                {
                    if (result == 0)
                    {
                        MessageBox.Show("Command Ok!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Command Error! Code: {result}", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
        
                Thread.Sleep(500);
        
                if (cnt++ > 20)
                {
                    MessageBox.Show("Command Error! Timeout!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            MainForm.modbusExt.SetWaitCursor(false);
        }

        public void LoadWithForceModbusExt_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(215, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(215, 0, typeof(UInt16), 1);
        
                if (result != 0xFFFF)
                {
                    if (result == 0)
                    {
                        MessageBox.Show("Command Ok!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Command Error! Code: {result}", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
        
                Thread.Sleep(500);
        
                if (cnt++ > 20)
                {
                    MessageBox.Show("Command Error! Timeout!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            MainForm.modbusExt.SetWaitCursor(false);
        }

        public void LoadWithForceHardwareConfiguration_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(216, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(216, 0, typeof(UInt16), 1);
        
                if (result != 0xFFFF)
                {
                    if (result == 0)
                    {
                        MessageBox.Show("Command Ok!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Command Error! Code: {result}", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
        
                Thread.Sleep(500);
        
                if (cnt++ > 20)
                {
                    MessageBox.Show("Command Error! Timeout!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            MainForm.modbusExt.SetWaitCursor(false);
        }

        public void LoadWithForceFunctional_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(217, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(217, 0, typeof(UInt16), 1);
        
                if (result != 0xFFFF)
                {
                    if (result == 0)
                    {
                        MessageBox.Show("Command Ok!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Command Error! Code: {result}", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
        
                Thread.Sleep(500);
        
                if (cnt++ > 20)
                {
                    MessageBox.Show("Command Error! Timeout!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            MainForm.modbusExt.SetWaitCursor(false);
        }

        public void LoadWithForceSensorCalibCoef_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(218, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(218, 0, typeof(UInt16), 1);
        
                if (result != 0xFFFF)
                {
                    if (result == 0)
                    {
                        MessageBox.Show("Command Ok!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Command Error! Code: {result}", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
        
                Thread.Sleep(500);
        
                if (cnt++ > 20)
                {
                    MessageBox.Show("Command Error! Timeout!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            MainForm.modbusExt.SetWaitCursor(false);
        }

        public void LoadWithForceOutputCalibCoef_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(219, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(219, 0, typeof(UInt16), 1);
        
                if (result != 0xFFFF)
                {
                    if (result == 0)
                    {
                        MessageBox.Show("Command Ok!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Command Error! Code: {result}", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
        
                Thread.Sleep(500);
        
                if (cnt++ > 20)
                {
                    MessageBox.Show("Command Error! Timeout!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            MainForm.modbusExt.SetWaitCursor(false);
        }

        public void LoadWithForceOutputRotation_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(220, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(220, 0, typeof(UInt16), 1);
        
                if (result != 0xFFFF)
                {
                    if (result == 0)
                    {
                        MessageBox.Show("Command Ok!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Command Error! Code: {result}", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
        
                Thread.Sleep(500);
        
                if (cnt++ > 20)
                {
                    MessageBox.Show("Command Error! Timeout!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            MainForm.modbusExt.SetWaitCursor(false);
        }

        public void SaveAll_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(221, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(221, 0, typeof(UInt16), 1);
        
                if (result != 0xFFFF)
                {
                    if (result == 0)
                    {
                        MessageBox.Show("Command Ok!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Command Error! Code: {result}", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
        
                Thread.Sleep(500);
        
                if (cnt++ > 20)
                {
                    MessageBox.Show("Command Error! Timeout!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            MainForm.modbusExt.SetWaitCursor(false);
        }

        public void SaveInfo_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(224, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(224, 0, typeof(UInt16), 1);
        
                if (result != 0xFFFF)
                {
                    if (result == 0)
                    {
                        MessageBox.Show("Command Ok!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Command Error! Code: {result}", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
        
                Thread.Sleep(500);
        
                if (cnt++ > 20)
                {
                    MessageBox.Show("Command Error! Timeout!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            MainForm.modbusExt.SetWaitCursor(false);
        }

        public void SaveModbusExt_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(225, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(225, 0, typeof(UInt16), 1);
        
                if (result != 0xFFFF)
                {
                    if (result == 0)
                    {
                        MessageBox.Show("Command Ok!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Command Error! Code: {result}", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
        
                Thread.Sleep(500);
        
                if (cnt++ > 20)
                {
                    MessageBox.Show("Command Error! Timeout!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            MainForm.modbusExt.SetWaitCursor(false);
        }

        public void SaveHardwareConfiguration_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(226, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(226, 0, typeof(UInt16), 1);
        
                if (result != 0xFFFF)
                {
                    if (result == 0)
                    {
                        MessageBox.Show("Command Ok!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Command Error! Code: {result}", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
        
                Thread.Sleep(500);
        
                if (cnt++ > 20)
                {
                    MessageBox.Show("Command Error! Timeout!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            MainForm.modbusExt.SetWaitCursor(false);
        }

        public void SaveFunctional_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(227, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(227, 0, typeof(UInt16), 1);
        
                if (result != 0xFFFF)
                {
                    if (result == 0)
                    {
                        MessageBox.Show("Command Ok!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Command Error! Code: {result}", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
        
                Thread.Sleep(500);
        
                if (cnt++ > 20)
                {
                    MessageBox.Show("Command Error! Timeout!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            MainForm.modbusExt.SetWaitCursor(false);
        }

        public void SaveSensorCalibCoef_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(228, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(228, 0, typeof(UInt16), 1);
        
                if (result != 0xFFFF)
                {
                    if (result == 0)
                    {
                        MessageBox.Show("Command Ok!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Command Error! Code: {result}", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
        
                Thread.Sleep(500);
        
                if (cnt++ > 20)
                {
                    MessageBox.Show("Command Error! Timeout!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            MainForm.modbusExt.SetWaitCursor(false);
        }

        public void SaveOutputCalibCoef_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(229, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(229, 0, typeof(UInt16), 1);
        
                if (result != 0xFFFF)
                {
                    if (result == 0)
                    {
                        MessageBox.Show("Command Ok!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Command Error! Code: {result}", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
        
                Thread.Sleep(500);
        
                if (cnt++ > 20)
                {
                    MessageBox.Show("Command Error! Timeout!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            MainForm.modbusExt.SetWaitCursor(false);
        }

        public void SaveOutputRotation_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(230, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(230, 0, typeof(UInt16), 1);
        
                if (result != 0xFFFF)
                {
                    if (result == 0)
                    {
                        MessageBox.Show("Command Ok!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Command Error! Code: {result}", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
        
                Thread.Sleep(500);
        
                if (cnt++ > 20)
                {
                    MessageBox.Show("Command Error! Timeout!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            MainForm.modbusExt.SetWaitCursor(false);
        }

        public void ResetCmd_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(402, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(402, 0, typeof(UInt16), 1);
        
                if (result != 0xFFFF)
                {
                    if (result == 0)
                    {
                        MessageBox.Show("Command Ok!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Command Error! Code: {result}", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
        
                Thread.Sleep(500);
        
                if (cnt++ > 20)
                {
                    MessageBox.Show("Command Error! Timeout!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            MainForm.modbusExt.SetWaitCursor(false);
        }

        public void SaveRtc_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(415, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(415, 0, typeof(UInt16), 1);
        
                if (result != 0xFFFF)
                {
                    if (result == 0)
                    {
                        MessageBox.Show("Command Ok!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Command Error! Code: {result}", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
        
                Thread.Sleep(500);
        
                if (cnt++ > 20)
                {
                    MessageBox.Show("Command Error! Timeout!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            MainForm.modbusExt.SetWaitCursor(false);
        }

        public void StreamingEnableCmd_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(4002, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(4002, 0, typeof(UInt16), 1);
        
                if (result != 0xFFFF)
                {
                    if (result == 0)
                    {
                        MessageBox.Show("Command Ok!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Command Error! Code: {result}", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
        
                Thread.Sleep(500);
        
                if (cnt++ > 20)
                {
                    MessageBox.Show("Command Error! Timeout!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            MainForm.modbusExt.SetWaitCursor(false);
        }

        public void StreamingDisableCmd_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(4003, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(4003, 0, typeof(UInt16), 1);
        
                if (result != 0xFFFF)
                {
                    if (result == 0)
                    {
                        MessageBox.Show("Command Ok!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Command Error! Code: {result}", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
        
                Thread.Sleep(500);
        
                if (cnt++ > 20)
                {
                    MessageBox.Show("Command Error! Timeout!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            MainForm.modbusExt.SetWaitCursor(false);
        }

        public void NorthFinding1_ResetCmd_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(6323, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(6323, 0, typeof(UInt16), 1);
        
                if (result != 0xFFFF)
                {
                    if (result == 0)
                    {
                        MessageBox.Show("Command Ok!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Command Error! Code: {result}", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
        
                Thread.Sleep(500);
        
                if (cnt++ > 20)
                {
                    MessageBox.Show("Command Error! Timeout!", "Command ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            MainForm.modbusExt.SetWaitCursor(false);
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class sProfilerData
        {
            public UInt32 intervalTimeUs;
            public UInt32 intervalTimeMaximaUs;
            public UInt32 intervalTimeMinimaUs;
            public UInt32 intervalTimeLimitExceedCounter;
            public UInt16 intervalTimingError;
            public UInt32 executionTimeUs;
            public UInt32 executionTimeMaximaUs;
            public UInt32 executionTimeMinimaUs;
            public UInt32 runCounter;

            private UInt16 ModbusBaseAddr;

            public static UInt16 ModbusSize = 17; // VarTypeSize in excel
            
            public sProfilerData(UInt16 ObjectModbusBaseAddr)
            {
                ModbusBaseAddr = ObjectModbusBaseAddr;

                intervalTimeUs = 0;
                intervalTimeMaximaUs = 0;
                intervalTimeMinimaUs = 0;
                intervalTimeLimitExceedCounter = 0;
                intervalTimingError = 0;
                executionTimeUs = 0;
                executionTimeMaximaUs = 0;
                executionTimeMinimaUs = 0;
                runCounter = 0;
            }

            public UInt32 IntervalTimeUs
            {
                get { return intervalTimeUs; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, value, typeof(UInt32), 1))
                    {
                        intervalTimeUs = value;
                    }
                }
            }

            public UInt32 IntervalTimeMaximaUs
            {
                get { return intervalTimeMaximaUs; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 2, value, typeof(UInt32), 1))
                    {
                        intervalTimeMaximaUs = value;
                    }
                }
            }

            public UInt32 IntervalTimeMinimaUs
            {
                get { return intervalTimeMinimaUs; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 4, value, typeof(UInt32), 1))
                    {
                        intervalTimeMinimaUs = value;
                    }
                }
            }

            public UInt32 IntervalTimeLimitExceedCounter
            {
                get { return intervalTimeLimitExceedCounter; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 6, value, typeof(UInt32), 1))
                    {
                        intervalTimeLimitExceedCounter = value;
                    }
                }
            }

            public UInt16 IntervalTimingError
            {
                get { return intervalTimingError; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 8, value, typeof(UInt16), 1))
                    {
                        intervalTimingError = value;
                    }
                }
            }

            public UInt32 ExecutionTimeUs
            {
                get { return executionTimeUs; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 9, value, typeof(UInt32), 1))
                    {
                        executionTimeUs = value;
                    }
                }
            }

            public UInt32 ExecutionTimeMaximaUs
            {
                get { return executionTimeMaximaUs; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 11, value, typeof(UInt32), 1))
                    {
                        executionTimeMaximaUs = value;
                    }
                }
            }

            public UInt32 ExecutionTimeMinimaUs
            {
                get { return executionTimeMinimaUs; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 13, value, typeof(UInt32), 1))
                    {
                        executionTimeMinimaUs = value;
                    }
                }
            }

            public UInt32 RunCounter
            {
                get { return runCounter; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 15, value, typeof(UInt32), 1))
                    {
                        runCounter = value;
                    }
                }
            }

            public bool ModbusWriteAll()
            {
                bool _status = true;
            
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, intervalTimeUs, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 2, intervalTimeMaximaUs, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 4, intervalTimeMinimaUs, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 6, intervalTimeLimitExceedCounter, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 8, intervalTimingError, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 9, executionTimeUs, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 11, executionTimeMaximaUs, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 13, executionTimeMinimaUs, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 15, runCounter, typeof(UInt32), 1);
                
                if (!_status)
                {
                    MessageBox.Show("Writing all parameters failed!", "Modbus error ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return _status;
            }

            public void ModbusReadAll()
            {
                intervalTimeUs = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 0, typeof(UInt32), 1);
                intervalTimeMaximaUs = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 2, typeof(UInt32), 1);
                intervalTimeMinimaUs = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 4, typeof(UInt32), 1);
                intervalTimeLimitExceedCounter = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 6, typeof(UInt32), 1);
                intervalTimingError = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 8, typeof(UInt16), 1);
                executionTimeUs = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 9, typeof(UInt32), 1);
                executionTimeMaximaUs = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 11, typeof(UInt32), 1);
                executionTimeMinimaUs = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 13, typeof(UInt32), 1);
                runCounter = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 15, typeof(UInt32), 1);
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class sProfilerSetting
        {
            public UInt32 intervalTimeNominalUs;
            public UInt32 intervalTimeMaxAllowedJitterUs;

            private UInt16 ModbusBaseAddr;

            public static UInt16 ModbusSize = 4; // VarTypeSize in excel
            
            public sProfilerSetting(UInt16 ObjectModbusBaseAddr)
            {
                ModbusBaseAddr = ObjectModbusBaseAddr;

                intervalTimeNominalUs = 0;
                intervalTimeMaxAllowedJitterUs = 0;
            }

            public UInt32 IntervalTimeNominalUs
            {
                get { return intervalTimeNominalUs; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, value, typeof(UInt32), 1))
                    {
                        intervalTimeNominalUs = value;
                    }
                }
            }

            public UInt32 IntervalTimeMaxAllowedJitterUs
            {
                get { return intervalTimeMaxAllowedJitterUs; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 2, value, typeof(UInt32), 1))
                    {
                        intervalTimeMaxAllowedJitterUs = value;
                    }
                }
            }

            public bool ModbusWriteAll()
            {
                bool _status = true;
            
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, intervalTimeNominalUs, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 2, intervalTimeMaxAllowedJitterUs, typeof(UInt32), 1);
                
                if (!_status)
                {
                    MessageBox.Show("Writing all parameters failed!", "Modbus error ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return _status;
            }

            public void ModbusReadAll()
            {
                intervalTimeNominalUs = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 0, typeof(UInt32), 1);
                intervalTimeMaxAllowedJitterUs = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 2, typeof(UInt32), 1);
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class sBoardStartupReport
        {
            public UInt16 overallResult;
            public UInt16 executionTimeUs;
            public sBoardStartupReportItem[] bmi088Gyro;
            public sBoardStartupReportItem[] bmi088Acc;
            public sBoardStartupReportItem[] adxl357;
            public sBoardStartupReportItem[] xrmaSx;
            public sBoardStartupReportItem[] h3;
            public sBoardStartupReportItem[] xrmg;
            public sBoardStartupReportItem xrmaH60;
            public sBoardStartupReportItem[] hmc5983;
            public sBoardStartupReportItem[] bmm;
            public sBoardStartupReportItem ms56;

            private UInt16 ModbusBaseAddr;

            public static UInt16 ModbusSize = 218; // VarTypeSize in excel
            
            public sBoardStartupReport(UInt16 ObjectModbusBaseAddr)
            {
                ModbusBaseAddr = ObjectModbusBaseAddr;

                overallResult = 0;
                executionTimeUs = 0;

                bmi088Gyro = new sBoardStartupReportItem[4];
                for (UInt16 i = 0; i < 4; i++)
                {
                    bmi088Gyro[i] = new sBoardStartupReportItem((UInt16)(ModbusBaseAddr + 2 + (8 * i)));
                }

                bmi088Acc = new sBoardStartupReportItem[4];
                for (UInt16 i = 0; i < 4; i++)
                {
                    bmi088Acc[i] = new sBoardStartupReportItem((UInt16)(ModbusBaseAddr + 34 + (8 * i)));
                }

                adxl357 = new sBoardStartupReportItem[3];
                for (UInt16 i = 0; i < 3; i++)
                {
                    adxl357[i] = new sBoardStartupReportItem((UInt16)(ModbusBaseAddr + 66 + (8 * i)));
                }

                xrmaSx = new sBoardStartupReportItem[3];
                for (UInt16 i = 0; i < 3; i++)
                {
                    xrmaSx[i] = new sBoardStartupReportItem((UInt16)(ModbusBaseAddr + 90 + (8 * i)));
                }

                h3 = new sBoardStartupReportItem[3];
                for (UInt16 i = 0; i < 3; i++)
                {
                    h3[i] = new sBoardStartupReportItem((UInt16)(ModbusBaseAddr + 114 + (8 * i)));
                }

                xrmg = new sBoardStartupReportItem[3];
                for (UInt16 i = 0; i < 3; i++)
                {
                    xrmg[i] = new sBoardStartupReportItem((UInt16)(ModbusBaseAddr + 138 + (8 * i)));
                }

                xrmaH60 = new sBoardStartupReportItem((UInt16)(ModbusBaseAddr + 162));

                hmc5983 = new sBoardStartupReportItem[3];
                for (UInt16 i = 0; i < 3; i++)
                {
                    hmc5983[i] = new sBoardStartupReportItem((UInt16)(ModbusBaseAddr + 170 + (8 * i)));
                }

                bmm = new sBoardStartupReportItem[2];
                for (UInt16 i = 0; i < 2; i++)
                {
                    bmm[i] = new sBoardStartupReportItem((UInt16)(ModbusBaseAddr + 194 + (8 * i)));
                }

                ms56 = new sBoardStartupReportItem((UInt16)(ModbusBaseAddr + 210));
            }

            public UInt16 OverallResult
            {
                get { return overallResult; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, value, typeof(UInt16), 1))
                    {
                        overallResult = value;
                    }
                }
            }

            public UInt16 ExecutionTimeUs
            {
                get { return executionTimeUs; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 1, value, typeof(UInt16), 1))
                    {
                        executionTimeUs = value;
                    }
                }
            }

            public sBoardStartupReportItem[] Bmi088Gyro
            {
                get { return bmi088Gyro; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 2, value, typeof(sBoardStartupReportItem), 4))
                    {
                        bmi088Gyro = value;
                    }
                }
            }

            public sBoardStartupReportItem[] Bmi088Acc
            {
                get { return bmi088Acc; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 34, value, typeof(sBoardStartupReportItem), 4))
                    {
                        bmi088Acc = value;
                    }
                }
            }

            public sBoardStartupReportItem[] Adxl357
            {
                get { return adxl357; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 66, value, typeof(sBoardStartupReportItem), 3))
                    {
                        adxl357 = value;
                    }
                }
            }

            public sBoardStartupReportItem[] XrmaSx
            {
                get { return xrmaSx; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 90, value, typeof(sBoardStartupReportItem), 3))
                    {
                        xrmaSx = value;
                    }
                }
            }

            public sBoardStartupReportItem[] H3
            {
                get { return h3; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 114, value, typeof(sBoardStartupReportItem), 3))
                    {
                        h3 = value;
                    }
                }
            }

            public sBoardStartupReportItem[] Xrmg
            {
                get { return xrmg; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 138, value, typeof(sBoardStartupReportItem), 3))
                    {
                        xrmg = value;
                    }
                }
            }

            public sBoardStartupReportItem XrmaH60
            {
                get { return xrmaH60; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 162, value, typeof(sBoardStartupReportItem), 1))
                    {
                        xrmaH60 = value;
                    }
                }
            }

            public sBoardStartupReportItem[] Hmc5983
            {
                get { return hmc5983; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 170, value, typeof(sBoardStartupReportItem), 3))
                    {
                        hmc5983 = value;
                    }
                }
            }

            public sBoardStartupReportItem[] Bmm
            {
                get { return bmm; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 194, value, typeof(sBoardStartupReportItem), 2))
                    {
                        bmm = value;
                    }
                }
            }

            public sBoardStartupReportItem Ms56
            {
                get { return ms56; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 210, value, typeof(sBoardStartupReportItem), 1))
                    {
                        ms56 = value;
                    }
                }
            }

            public bool ModbusWriteAll()
            {
                bool _status = true;
            
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, overallResult, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 1, executionTimeUs, typeof(UInt16), 1);

                for (int i = 0; i < 4; i++)
                {
                    bmi088Gyro[i].ModbusWriteAll();
                }

                for (int i = 0; i < 4; i++)
                {
                    bmi088Acc[i].ModbusWriteAll();
                }

                for (int i = 0; i < 3; i++)
                {
                    adxl357[i].ModbusWriteAll();
                }

                for (int i = 0; i < 3; i++)
                {
                    xrmaSx[i].ModbusWriteAll();
                }

                for (int i = 0; i < 3; i++)
                {
                    h3[i].ModbusWriteAll();
                }

                for (int i = 0; i < 3; i++)
                {
                    xrmg[i].ModbusWriteAll();
                }

                _status &= xrmaH60.ModbusWriteAll();

                for (int i = 0; i < 3; i++)
                {
                    hmc5983[i].ModbusWriteAll();
                }

                for (int i = 0; i < 2; i++)
                {
                    bmm[i].ModbusWriteAll();
                }

                _status &= ms56.ModbusWriteAll();
                
                if (!_status)
                {
                    MessageBox.Show("Writing all parameters failed!", "Modbus error ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return _status;
            }

            public void ModbusReadAll()
            {
                overallResult = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 0, typeof(UInt16), 1);
                executionTimeUs = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 1, typeof(UInt16), 1);

                for (int i = 0; i < 4; i++)
                {
                    bmi088Gyro[i].ModbusReadAll();
                }

                for (int i = 0; i < 4; i++)
                {
                    bmi088Acc[i].ModbusReadAll();
                }

                for (int i = 0; i < 3; i++)
                {
                    adxl357[i].ModbusReadAll();
                }

                for (int i = 0; i < 3; i++)
                {
                    xrmaSx[i].ModbusReadAll();
                }

                for (int i = 0; i < 3; i++)
                {
                    h3[i].ModbusReadAll();
                }

                for (int i = 0; i < 3; i++)
                {
                    xrmg[i].ModbusReadAll();
                }

                xrmaH60.ModbusReadAll();

                for (int i = 0; i < 3; i++)
                {
                    hmc5983[i].ModbusReadAll();
                }

                for (int i = 0; i < 2; i++)
                {
                    bmm[i].ModbusReadAll();
                }

                ms56.ModbusReadAll();
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class sBoardStartupReportItem
        {
            public UInt16 connectionResult;
            public UInt16 connectionRetry;
            public UInt32 connectionTimeUs;
            public UInt16 configResult;
            public UInt16 configRetry;
            public UInt32 configTimeUs;

            private UInt16 ModbusBaseAddr;

            public static UInt16 ModbusSize = 8; // VarTypeSize in excel
            
            public sBoardStartupReportItem(UInt16 ObjectModbusBaseAddr)
            {
                ModbusBaseAddr = ObjectModbusBaseAddr;

                connectionResult = 0;
                connectionRetry = 0;
                connectionTimeUs = 0;
                configResult = 0;
                configRetry = 0;
                configTimeUs = 0;
            }

            public UInt16 ConnectionResult
            {
                get { return connectionResult; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, value, typeof(UInt16), 1))
                    {
                        connectionResult = value;
                    }
                }
            }

            public UInt16 ConnectionRetry
            {
                get { return connectionRetry; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 1, value, typeof(UInt16), 1))
                    {
                        connectionRetry = value;
                    }
                }
            }

            public UInt32 ConnectionTimeUs
            {
                get { return connectionTimeUs; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 2, value, typeof(UInt32), 1))
                    {
                        connectionTimeUs = value;
                    }
                }
            }

            public UInt16 ConfigResult
            {
                get { return configResult; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 4, value, typeof(UInt16), 1))
                    {
                        configResult = value;
                    }
                }
            }

            public UInt16 ConfigRetry
            {
                get { return configRetry; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 5, value, typeof(UInt16), 1))
                    {
                        configRetry = value;
                    }
                }
            }

            public UInt32 ConfigTimeUs
            {
                get { return configTimeUs; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 6, value, typeof(UInt32), 1))
                    {
                        configTimeUs = value;
                    }
                }
            }

            public bool ModbusWriteAll()
            {
                bool _status = true;
            
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, connectionResult, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 1, connectionRetry, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 2, connectionTimeUs, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 4, configResult, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 5, configRetry, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 6, configTimeUs, typeof(UInt32), 1);
                
                if (!_status)
                {
                    MessageBox.Show("Writing all parameters failed!", "Modbus error ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return _status;
            }

            public void ModbusReadAll()
            {
                connectionResult = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 0, typeof(UInt16), 1);
                connectionRetry = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 1, typeof(UInt16), 1);
                connectionTimeUs = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 2, typeof(UInt32), 1);
                configResult = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 4, typeof(UInt16), 1);
                configRetry = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 5, typeof(UInt16), 1);
                configTimeUs = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 6, typeof(UInt32), 1);
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class s3d
        {
            public Double x;
            public Double y;
            public Double z;

            private UInt16 ModbusBaseAddr;

            public static UInt16 ModbusSize = 12; // VarTypeSize in excel
            
            public s3d(UInt16 ObjectModbusBaseAddr)
            {
                ModbusBaseAddr = ObjectModbusBaseAddr;

                x = 0;
                y = 0;
                z = 0;
            }

            public Double X
            {
                get { return x; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, value, typeof(Double), 1))
                    {
                        x = value;
                    }
                }
            }

            public Double Y
            {
                get { return y; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 4, value, typeof(Double), 1))
                    {
                        y = value;
                    }
                }
            }

            public Double Z
            {
                get { return z; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 8, value, typeof(Double), 1))
                    {
                        z = value;
                    }
                }
            }

            public bool ModbusWriteAll()
            {
                bool _status = true;
            
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, x, typeof(Double), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 4, y, typeof(Double), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 8, z, typeof(Double), 1);
                
                if (!_status)
                {
                    MessageBox.Show("Writing all parameters failed!", "Modbus error ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return _status;
            }

            public void ModbusReadAll()
            {
                x = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 0, typeof(Double), 1);
                y = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 4, typeof(Double), 1);
                z = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 8, typeof(Double), 1);
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class s3dI32
        {
            public Int32 x;
            public Int32 y;
            public Int32 z;

            private UInt16 ModbusBaseAddr;

            public static UInt16 ModbusSize = 6; // VarTypeSize in excel
            
            public s3dI32(UInt16 ObjectModbusBaseAddr)
            {
                ModbusBaseAddr = ObjectModbusBaseAddr;

                x = 0;
                y = 0;
                z = 0;
            }

            public Int32 X
            {
                get { return x; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, value, typeof(Int32), 1))
                    {
                        x = value;
                    }
                }
            }

            public Int32 Y
            {
                get { return y; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 2, value, typeof(Int32), 1))
                    {
                        y = value;
                    }
                }
            }

            public Int32 Z
            {
                get { return z; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 4, value, typeof(Int32), 1))
                    {
                        z = value;
                    }
                }
            }

            public bool ModbusWriteAll()
            {
                bool _status = true;
            
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, x, typeof(Int32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 2, y, typeof(Int32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 4, z, typeof(Int32), 1);
                
                if (!_status)
                {
                    MessageBox.Show("Writing all parameters failed!", "Modbus error ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return _status;
            }

            public void ModbusReadAll()
            {
                x = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 0, typeof(Int32), 1);
                y = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 2, typeof(Int32), 1);
                z = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 4, typeof(Int32), 1);
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class s3dI16
        {
            public Int16 x;
            public Int16 y;
            public Int16 z;

            private UInt16 ModbusBaseAddr;

            public static UInt16 ModbusSize = 3; // VarTypeSize in excel
            
            public s3dI16(UInt16 ObjectModbusBaseAddr)
            {
                ModbusBaseAddr = ObjectModbusBaseAddr;

                x = 0;
                y = 0;
                z = 0;
            }

            public Int16 X
            {
                get { return x; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, value, typeof(Int16), 1))
                    {
                        x = value;
                    }
                }
            }

            public Int16 Y
            {
                get { return y; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 1, value, typeof(Int16), 1))
                    {
                        y = value;
                    }
                }
            }

            public Int16 Z
            {
                get { return z; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 2, value, typeof(Int16), 1))
                    {
                        z = value;
                    }
                }
            }

            public bool ModbusWriteAll()
            {
                bool _status = true;
            
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, x, typeof(Int16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 1, y, typeof(Int16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 2, z, typeof(Int16), 1);
                
                if (!_status)
                {
                    MessageBox.Show("Writing all parameters failed!", "Modbus error ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return _status;
            }

            public void ModbusReadAll()
            {
                x = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 0, typeof(Int16), 1);
                y = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 1, typeof(Int16), 1);
                z = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 2, typeof(Int16), 1);
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class sTypicalImuData
        {
            public s3d gyro;
            public s3d acc;
            public Single temperature;
            public UInt32 counter;
            public UInt32 readErrorCounter;
            public UInt32 serialNo;
            public UInt16 no;
            public UInt32 status;
            public UInt16 active;

            private UInt16 ModbusBaseAddr;

            public static UInt16 ModbusSize = 36; // VarTypeSize in excel
            
            public sTypicalImuData(UInt16 ObjectModbusBaseAddr)
            {
                ModbusBaseAddr = ObjectModbusBaseAddr;

                gyro = new s3d((UInt16)(ModbusBaseAddr + 0));
                acc = new s3d((UInt16)(ModbusBaseAddr + 12));
                temperature = 0;
                counter = 0;
                readErrorCounter = 0;
                serialNo = 0;
                no = 0;
                status = 0;
                active = 0;
            }

            public s3d Gyro
            {
                get { return gyro; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, value, typeof(s3d), 1))
                    {
                        gyro = value;
                    }
                }
            }

            public s3d Acc
            {
                get { return acc; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 12, value, typeof(s3d), 1))
                    {
                        acc = value;
                    }
                }
            }

            public Single Temperature
            {
                get { return temperature; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 24, value, typeof(Single), 1))
                    {
                        temperature = value;
                    }
                }
            }

            public UInt32 Counter
            {
                get { return counter; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 26, value, typeof(UInt32), 1))
                    {
                        counter = value;
                    }
                }
            }

            public UInt32 ReadErrorCounter
            {
                get { return readErrorCounter; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 28, value, typeof(UInt32), 1))
                    {
                        readErrorCounter = value;
                    }
                }
            }

            public UInt32 SerialNo
            {
                get { return serialNo; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 30, value, typeof(UInt32), 1))
                    {
                        serialNo = value;
                    }
                }
            }

            public UInt16 No
            {
                get { return no; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 32, value, typeof(UInt16), 1))
                    {
                        no = value;
                    }
                }
            }

            public UInt32 Status
            {
                get { return status; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 33, value, typeof(UInt32), 1))
                    {
                        status = value;
                    }
                }
            }

            public UInt16 Active
            {
                get { return active; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 35, value, typeof(UInt16), 1))
                    {
                        active = value;
                    }
                }
            }

            public bool ModbusWriteAll()
            {
                bool _status = true;
            
                _status &= gyro.ModbusWriteAll();
                _status &= acc.ModbusWriteAll();
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 24, temperature, typeof(Single), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 26, counter, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 28, readErrorCounter, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 30, serialNo, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 32, no, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 33, status, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 35, active, typeof(UInt16), 1);
                
                if (!_status)
                {
                    MessageBox.Show("Writing all parameters failed!", "Modbus error ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return _status;
            }

            public void ModbusReadAll()
            {
                gyro.ModbusReadAll();
                acc.ModbusReadAll();
                temperature = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 24, typeof(Single), 1);
                counter = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 26, typeof(UInt32), 1);
                readErrorCounter = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 28, typeof(UInt32), 1);
                serialNo = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 30, typeof(UInt32), 1);
                no = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 32, typeof(UInt16), 1);
                status = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 33, typeof(UInt32), 1);
                active = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 35, typeof(UInt16), 1);
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class sExternalImuData
        {
            public sTypicalImuData[] data;
            public UInt16 imuQty;
            public UInt16 externalImuValid;
            public UInt16 externalImuNewDataFlag;
            public Single externalImuFreqHz;
            public UInt32 externalImuFreqErrorCounter;

            private UInt16 ModbusBaseAddr;

            public static UInt16 ModbusSize = 367; // VarTypeSize in excel
            
            public sExternalImuData(UInt16 ObjectModbusBaseAddr)
            {
                ModbusBaseAddr = ObjectModbusBaseAddr;


                data = new sTypicalImuData[10];
                for (UInt16 i = 0; i < 10; i++)
                {
                    data[i] = new sTypicalImuData((UInt16)(ModbusBaseAddr + 0 + (36 * i)));
                }

                imuQty = 0;
                externalImuValid = 0;
                externalImuNewDataFlag = 0;
                externalImuFreqHz = 0;
                externalImuFreqErrorCounter = 0;
            }

            public sTypicalImuData[] Data
            {
                get { return data; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, value, typeof(sTypicalImuData), 10))
                    {
                        data = value;
                    }
                }
            }

            public UInt16 ImuQty
            {
                get { return imuQty; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 360, value, typeof(UInt16), 1))
                    {
                        imuQty = value;
                    }
                }
            }

            public UInt16 ExternalImuValid
            {
                get { return externalImuValid; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 361, value, typeof(UInt16), 1))
                    {
                        externalImuValid = value;
                    }
                }
            }

            public UInt16 ExternalImuNewDataFlag
            {
                get { return externalImuNewDataFlag; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 362, value, typeof(UInt16), 1))
                    {
                        externalImuNewDataFlag = value;
                    }
                }
            }

            public Single ExternalImuFreqHz
            {
                get { return externalImuFreqHz; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 363, value, typeof(Single), 1))
                    {
                        externalImuFreqHz = value;
                    }
                }
            }

            public UInt32 ExternalImuFreqErrorCounter
            {
                get { return externalImuFreqErrorCounter; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 365, value, typeof(UInt32), 1))
                    {
                        externalImuFreqErrorCounter = value;
                    }
                }
            }

            public bool ModbusWriteAll()
            {
                bool _status = true;
            

                for (int i = 0; i < 10; i++)
                {
                    data[i].ModbusWriteAll();
                }

                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 360, imuQty, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 361, externalImuValid, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 362, externalImuNewDataFlag, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 363, externalImuFreqHz, typeof(Single), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 365, externalImuFreqErrorCounter, typeof(UInt32), 1);
                
                if (!_status)
                {
                    MessageBox.Show("Writing all parameters failed!", "Modbus error ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return _status;
            }

            public void ModbusReadAll()
            {

                for (int i = 0; i < 10; i++)
                {
                    data[i].ModbusReadAll();
                }

                imuQty = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 360, typeof(UInt16), 1);
                externalImuValid = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 361, typeof(UInt16), 1);
                externalImuNewDataFlag = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 362, typeof(UInt16), 1);
                externalImuFreqHz = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 363, typeof(Single), 1);
                externalImuFreqErrorCounter = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 365, typeof(UInt32), 1);
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class sExternalImuSetting
        {
            public Single externalImuNominalFreqHz;
            public Single externalImuFreqMaxAllowedJitterHz;

            private UInt16 ModbusBaseAddr;

            public static UInt16 ModbusSize = 4; // VarTypeSize in excel
            
            public sExternalImuSetting(UInt16 ObjectModbusBaseAddr)
            {
                ModbusBaseAddr = ObjectModbusBaseAddr;

                externalImuNominalFreqHz = 0;
                externalImuFreqMaxAllowedJitterHz = 0;
            }

            public Single ExternalImuNominalFreqHz
            {
                get { return externalImuNominalFreqHz; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, value, typeof(Single), 1))
                    {
                        externalImuNominalFreqHz = value;
                    }
                }
            }

            public Single ExternalImuFreqMaxAllowedJitterHz
            {
                get { return externalImuFreqMaxAllowedJitterHz; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 2, value, typeof(Single), 1))
                    {
                        externalImuFreqMaxAllowedJitterHz = value;
                    }
                }
            }

            public bool ModbusWriteAll()
            {
                bool _status = true;
            
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, externalImuNominalFreqHz, typeof(Single), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 2, externalImuFreqMaxAllowedJitterHz, typeof(Single), 1);
                
                if (!_status)
                {
                    MessageBox.Show("Writing all parameters failed!", "Modbus error ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return _status;
            }

            public void ModbusReadAll()
            {
                externalImuNominalFreqHz = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 0, typeof(Single), 1);
                externalImuFreqMaxAllowedJitterHz = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 2, typeof(Single), 1);
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class sMainMcuData
        {
            public s3d[] sensorGyro;
            public s3d[] sensorGyroTemperature;
            public s3d[] sensorGyroTemperatureRate;
            public s3dI16[] sensorGyroTemperatureRateI16;
            public s3d[] sensorAcc;
            public s3d[] sensorAccTemperature;
            public s3d[] sensorAccTemperatureRate;
            public s3dI16[] sensorAccTemperatureRateI16;
            public s3dI32[] sensorGyroI32;
            public s3dI16[] sensorGyroTemperatureI16;
            public s3dI32[] sensorAccI32;
            public s3dI16[] sensorAccTemperatureI16;
            public UInt32 chipActive;
            public UInt32 calcStatus;
            public UInt64 sensorStatus;
            public UInt32 counter;
            public UInt32 generalStatusSummary;
            public UInt32 frameErrorCounter;
            public UInt16 frameErrorStatus;

            private UInt16 ModbusBaseAddr;

            public static UInt16 ModbusSize = 207; // VarTypeSize in excel
            
            public sMainMcuData(UInt16 ObjectModbusBaseAddr)
            {
                ModbusBaseAddr = ObjectModbusBaseAddr;


                sensorGyro = new s3d[2];
                for (UInt16 i = 0; i < 2; i++)
                {
                    sensorGyro[i] = new s3d((UInt16)(ModbusBaseAddr + 0 + (12 * i)));
                }

                sensorGyroTemperature = new s3d[2];
                for (UInt16 i = 0; i < 2; i++)
                {
                    sensorGyroTemperature[i] = new s3d((UInt16)(ModbusBaseAddr + 24 + (12 * i)));
                }

                sensorGyroTemperatureRate = new s3d[2];
                for (UInt16 i = 0; i < 2; i++)
                {
                    sensorGyroTemperatureRate[i] = new s3d((UInt16)(ModbusBaseAddr + 48 + (12 * i)));
                }

                sensorGyroTemperatureRateI16 = new s3dI16[2];
                for (UInt16 i = 0; i < 2; i++)
                {
                    sensorGyroTemperatureRateI16[i] = new s3dI16((UInt16)(ModbusBaseAddr + 72 + (3 * i)));
                }

                sensorAcc = new s3d[2];
                for (UInt16 i = 0; i < 2; i++)
                {
                    sensorAcc[i] = new s3d((UInt16)(ModbusBaseAddr + 78 + (12 * i)));
                }

                sensorAccTemperature = new s3d[2];
                for (UInt16 i = 0; i < 2; i++)
                {
                    sensorAccTemperature[i] = new s3d((UInt16)(ModbusBaseAddr + 102 + (12 * i)));
                }

                sensorAccTemperatureRate = new s3d[2];
                for (UInt16 i = 0; i < 2; i++)
                {
                    sensorAccTemperatureRate[i] = new s3d((UInt16)(ModbusBaseAddr + 126 + (12 * i)));
                }

                sensorAccTemperatureRateI16 = new s3dI16[2];
                for (UInt16 i = 0; i < 2; i++)
                {
                    sensorAccTemperatureRateI16[i] = new s3dI16((UInt16)(ModbusBaseAddr + 150 + (3 * i)));
                }

                sensorGyroI32 = new s3dI32[2];
                for (UInt16 i = 0; i < 2; i++)
                {
                    sensorGyroI32[i] = new s3dI32((UInt16)(ModbusBaseAddr + 156 + (6 * i)));
                }

                sensorGyroTemperatureI16 = new s3dI16[2];
                for (UInt16 i = 0; i < 2; i++)
                {
                    sensorGyroTemperatureI16[i] = new s3dI16((UInt16)(ModbusBaseAddr + 168 + (3 * i)));
                }

                sensorAccI32 = new s3dI32[2];
                for (UInt16 i = 0; i < 2; i++)
                {
                    sensorAccI32[i] = new s3dI32((UInt16)(ModbusBaseAddr + 174 + (6 * i)));
                }

                sensorAccTemperatureI16 = new s3dI16[2];
                for (UInt16 i = 0; i < 2; i++)
                {
                    sensorAccTemperatureI16[i] = new s3dI16((UInt16)(ModbusBaseAddr + 186 + (3 * i)));
                }

                chipActive = 0;
                calcStatus = 0;
                sensorStatus = 0;
                counter = 0;
                generalStatusSummary = 0;
                frameErrorCounter = 0;
                frameErrorStatus = 0;
            }

            public s3d[] SensorGyro
            {
                get { return sensorGyro; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, value, typeof(s3d), 2))
                    {
                        sensorGyro = value;
                    }
                }
            }

            public s3d[] SensorGyroTemperature
            {
                get { return sensorGyroTemperature; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 24, value, typeof(s3d), 2))
                    {
                        sensorGyroTemperature = value;
                    }
                }
            }

            public s3d[] SensorGyroTemperatureRate
            {
                get { return sensorGyroTemperatureRate; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 48, value, typeof(s3d), 2))
                    {
                        sensorGyroTemperatureRate = value;
                    }
                }
            }

            public s3dI16[] SensorGyroTemperatureRateI16
            {
                get { return sensorGyroTemperatureRateI16; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 72, value, typeof(s3dI16), 2))
                    {
                        sensorGyroTemperatureRateI16 = value;
                    }
                }
            }

            public s3d[] SensorAcc
            {
                get { return sensorAcc; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 78, value, typeof(s3d), 2))
                    {
                        sensorAcc = value;
                    }
                }
            }

            public s3d[] SensorAccTemperature
            {
                get { return sensorAccTemperature; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 102, value, typeof(s3d), 2))
                    {
                        sensorAccTemperature = value;
                    }
                }
            }

            public s3d[] SensorAccTemperatureRate
            {
                get { return sensorAccTemperatureRate; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 126, value, typeof(s3d), 2))
                    {
                        sensorAccTemperatureRate = value;
                    }
                }
            }

            public s3dI16[] SensorAccTemperatureRateI16
            {
                get { return sensorAccTemperatureRateI16; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 150, value, typeof(s3dI16), 2))
                    {
                        sensorAccTemperatureRateI16 = value;
                    }
                }
            }

            public s3dI32[] SensorGyroI32
            {
                get { return sensorGyroI32; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 156, value, typeof(s3dI32), 2))
                    {
                        sensorGyroI32 = value;
                    }
                }
            }

            public s3dI16[] SensorGyroTemperatureI16
            {
                get { return sensorGyroTemperatureI16; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 168, value, typeof(s3dI16), 2))
                    {
                        sensorGyroTemperatureI16 = value;
                    }
                }
            }

            public s3dI32[] SensorAccI32
            {
                get { return sensorAccI32; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 174, value, typeof(s3dI32), 2))
                    {
                        sensorAccI32 = value;
                    }
                }
            }

            public s3dI16[] SensorAccTemperatureI16
            {
                get { return sensorAccTemperatureI16; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 186, value, typeof(s3dI16), 2))
                    {
                        sensorAccTemperatureI16 = value;
                    }
                }
            }

            public UInt32 ChipActive
            {
                get { return chipActive; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 192, value, typeof(UInt32), 1))
                    {
                        chipActive = value;
                    }
                }
            }

            public UInt32 CalcStatus
            {
                get { return calcStatus; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 194, value, typeof(UInt32), 1))
                    {
                        calcStatus = value;
                    }
                }
            }

            public UInt64 SensorStatus
            {
                get { return sensorStatus; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 196, value, typeof(UInt64), 1))
                    {
                        sensorStatus = value;
                    }
                }
            }

            public UInt32 Counter
            {
                get { return counter; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 200, value, typeof(UInt32), 1))
                    {
                        counter = value;
                    }
                }
            }

            public UInt32 GeneralStatusSummary
            {
                get { return generalStatusSummary; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 202, value, typeof(UInt32), 1))
                    {
                        generalStatusSummary = value;
                    }
                }
            }

            public UInt32 FrameErrorCounter
            {
                get { return frameErrorCounter; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 204, value, typeof(UInt32), 1))
                    {
                        frameErrorCounter = value;
                    }
                }
            }

            public UInt16 FrameErrorStatus
            {
                get { return frameErrorStatus; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 206, value, typeof(UInt16), 1))
                    {
                        frameErrorStatus = value;
                    }
                }
            }

            public bool ModbusWriteAll()
            {
                bool _status = true;
            

                for (int i = 0; i < 2; i++)
                {
                    sensorGyro[i].ModbusWriteAll();
                }

                for (int i = 0; i < 2; i++)
                {
                    sensorGyroTemperature[i].ModbusWriteAll();
                }

                for (int i = 0; i < 2; i++)
                {
                    sensorGyroTemperatureRate[i].ModbusWriteAll();
                }

                for (int i = 0; i < 2; i++)
                {
                    sensorGyroTemperatureRateI16[i].ModbusWriteAll();
                }

                for (int i = 0; i < 2; i++)
                {
                    sensorAcc[i].ModbusWriteAll();
                }

                for (int i = 0; i < 2; i++)
                {
                    sensorAccTemperature[i].ModbusWriteAll();
                }

                for (int i = 0; i < 2; i++)
                {
                    sensorAccTemperatureRate[i].ModbusWriteAll();
                }

                for (int i = 0; i < 2; i++)
                {
                    sensorAccTemperatureRateI16[i].ModbusWriteAll();
                }

                for (int i = 0; i < 2; i++)
                {
                    sensorGyroI32[i].ModbusWriteAll();
                }

                for (int i = 0; i < 2; i++)
                {
                    sensorGyroTemperatureI16[i].ModbusWriteAll();
                }

                for (int i = 0; i < 2; i++)
                {
                    sensorAccI32[i].ModbusWriteAll();
                }

                for (int i = 0; i < 2; i++)
                {
                    sensorAccTemperatureI16[i].ModbusWriteAll();
                }

                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 192, chipActive, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 194, calcStatus, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 196, sensorStatus, typeof(UInt64), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 200, counter, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 202, generalStatusSummary, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 204, frameErrorCounter, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 206, frameErrorStatus, typeof(UInt16), 1);
                
                if (!_status)
                {
                    MessageBox.Show("Writing all parameters failed!", "Modbus error ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return _status;
            }

            public void ModbusReadAll()
            {

                for (int i = 0; i < 2; i++)
                {
                    sensorGyro[i].ModbusReadAll();
                }

                for (int i = 0; i < 2; i++)
                {
                    sensorGyroTemperature[i].ModbusReadAll();
                }

                for (int i = 0; i < 2; i++)
                {
                    sensorGyroTemperatureRate[i].ModbusReadAll();
                }

                for (int i = 0; i < 2; i++)
                {
                    sensorGyroTemperatureRateI16[i].ModbusReadAll();
                }

                for (int i = 0; i < 2; i++)
                {
                    sensorAcc[i].ModbusReadAll();
                }

                for (int i = 0; i < 2; i++)
                {
                    sensorAccTemperature[i].ModbusReadAll();
                }

                for (int i = 0; i < 2; i++)
                {
                    sensorAccTemperatureRate[i].ModbusReadAll();
                }

                for (int i = 0; i < 2; i++)
                {
                    sensorAccTemperatureRateI16[i].ModbusReadAll();
                }

                for (int i = 0; i < 2; i++)
                {
                    sensorGyroI32[i].ModbusReadAll();
                }

                for (int i = 0; i < 2; i++)
                {
                    sensorGyroTemperatureI16[i].ModbusReadAll();
                }

                for (int i = 0; i < 2; i++)
                {
                    sensorAccI32[i].ModbusReadAll();
                }

                for (int i = 0; i < 2; i++)
                {
                    sensorAccTemperatureI16[i].ModbusReadAll();
                }

                chipActive = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 192, typeof(UInt32), 1);
                calcStatus = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 194, typeof(UInt32), 1);
                sensorStatus = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 196, typeof(UInt64), 1);
                counter = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 200, typeof(UInt32), 1);
                generalStatusSummary = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 202, typeof(UInt32), 1);
                frameErrorCounter = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 204, typeof(UInt32), 1);
                frameErrorStatus = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 206, typeof(UInt16), 1);
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class sTransferAlignmentData
        {
            public Double[] imuEulerAngle;
            public Double[] imuDeltaAngle;
            public UInt16 mode;
            public UInt32 status;
            public UInt32 version;
            public UInt32 counter;

            private UInt16 ModbusBaseAddr;

            public static UInt16 ModbusSize = 31; // VarTypeSize in excel
            
            public sTransferAlignmentData(UInt16 ObjectModbusBaseAddr)
            {
                ModbusBaseAddr = ObjectModbusBaseAddr;

                imuEulerAngle = new Double[3];
                imuDeltaAngle = new Double[3];
                mode = 0;
                status = 0;
                version = 0;
                counter = 0;
            }

            public Double[] ImuEulerAngle
            {
                get { return imuEulerAngle; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, value, typeof(Double), 3))
                    {
                        imuEulerAngle = value;
                    }
                }
            }

            public Double[] ImuDeltaAngle
            {
                get { return imuDeltaAngle; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 12, value, typeof(Double), 3))
                    {
                        imuDeltaAngle = value;
                    }
                }
            }

            public UInt16 Mode
            {
                get { return mode; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 24, value, typeof(UInt16), 1))
                    {
                        mode = value;
                    }
                }
            }

            public UInt32 Status
            {
                get { return status; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 25, value, typeof(UInt32), 1))
                    {
                        status = value;
                    }
                }
            }

            public UInt32 Version
            {
                get { return version; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 27, value, typeof(UInt32), 1))
                    {
                        version = value;
                    }
                }
            }

            public UInt32 Counter
            {
                get { return counter; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 29, value, typeof(UInt32), 1))
                    {
                        counter = value;
                    }
                }
            }

            public bool ModbusWriteAll()
            {
                bool _status = true;
            
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, imuEulerAngle, typeof(Double), 3);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 12, imuDeltaAngle, typeof(Double), 3);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 24, mode, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 25, status, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 27, version, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 29, counter, typeof(UInt32), 1);
                
                if (!_status)
                {
                    MessageBox.Show("Writing all parameters failed!", "Modbus error ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return _status;
            }

            public void ModbusReadAll()
            {
                imuEulerAngle = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 0, typeof(Double), 3);
                imuDeltaAngle = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 12, typeof(Double), 3);
                mode = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 24, typeof(UInt16), 1);
                status = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 25, typeof(UInt32), 1);
                version = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 27, typeof(UInt32), 1);
                counter = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 29, typeof(UInt32), 1);
            }
        }

        public enum eTag1_SettingGroup : ushort
        {
            eSETTING_INFO = 1,
            eSETTING_MODBUS_EXT = 2,
            eSETTING_HW_CONFIGURATION = 3,
            eSETTING_FUNCTIONAL = 4,
            eSETTING_OUTPUT_ROTATION = 5
        }

        public enum eParameterId : ushort
        {
            DEVICE_ID = 0,
            PARAMETER_LIST_VERSION = 1,
            FW_VERSION_MAJOR = 2,
            FW_VERSION_MINOR = 3,
            FW_VERSION_BUILD1 = 4,
            FW_VERSION_BUILD2 = 5,
            SERIAL_NO = 6,
            HW_VERSION_MAJOR = 7,
            HW_VERSION_MINOR = 8,
            PRODUCTION_YEAR = 9,
            PRODUCTION_MONTH = 10,
            PRODUCTION_DAY = 11,
            DOWN_STREAM_QTY = 12,
            DOWN_STREAMS_START_ADDR = 13,
            DOWN_STREAMS_SETTING_SIZE = 14,
            MEMORY_RETRY_QTY = 15,
            MEMORY_RETRY_DELAY_MS = 16,
            RESTORE_DEFAULT_VALUE = 17,
            LOAD_ALL = 18,
            LOAD_ALL_MEMORY_RESULT = 19,
            LOAD_INFO = 20,
            LOAD_MODBUS_EXT = 21,
            LOAD_HARDWARE_CONFIGURATION = 22,
            LOAD_FUNCTIONAL = 23,
            LOAD_SENSOR_CALIB_COEF = 24,
            LOAD_OUTPUT_CALIB_COEF = 25,
            LOAD_OUTPUT_ROTATION = 26,
            LOAD_WITH_FORCE_ALL = 27,
            LOAD_WITH_FORCE_INFO = 28,
            LOAD_WITH_FORCE_MODBUS_EXT = 29,
            LOAD_WITH_FORCE_HARDWARE_CONFIGURATION = 30,
            LOAD_WITH_FORCE_FUNCTIONAL = 31,
            LOAD_WITH_FORCE_SENSOR_CALIB_COEF = 32,
            LOAD_WITH_FORCE_OUTPUT_CALIB_COEF = 33,
            LOAD_WITH_FORCE_OUTPUT_ROTATION = 34,
            SAVE_ALL = 35,
            SAVE_ALL_MEMORY_RESULT = 36,
            SAVE_INFO = 37,
            SAVE_MODBUS_EXT = 38,
            SAVE_HARDWARE_CONFIGURATION = 39,
            SAVE_FUNCTIONAL = 40,
            SAVE_SENSOR_CALIB_COEF = 41,
            SAVE_OUTPUT_CALIB_COEF = 42,
            SAVE_OUTPUT_ROTATION = 43,
            WATCHDOG_TIME_MS = 44,
            RESET_SOURCE = 45,
            RESET_CMD = 46,
            DATE_YEAR = 47,
            DATE_MONTH = 48,
            DATE_DAY = 49,
            CLOCK_HOUR = 50,
            CLOCK_MINUTE = 51,
            CLOCK_SECOND = 52,
            DATE_YEAR_CONFIG = 53,
            DATE_MONTH_CONFIG = 54,
            DATE_DAY_CONFIG = 55,
            CLOCK_HOUR_CONFIG = 56,
            CLOCK_MINUTE_CONFIG = 57,
            CLOCK_SECOND_CONFIG = 58,
            SAVE_RTC = 59,
            UP_STREAM_BAUDRATE = 60,
            SHODOW_HOLDING_REGISTER_0 = 61,
            SHODOW_HOLDING_REGISTER_1 = 62,
            SHODOW_HOLDING_REGISTER_2 = 63,
            SHODOW_HOLDING_REGISTER_3 = 64,
            SHODOW_HOLDING_REGISTER_4 = 65,
            SHODOW_HOLDING_REGISTER_5 = 66,
            SHODOW_HOLDING_REGISTER_6 = 67,
            SHODOW_HOLDING_REGISTER_7 = 68,
            SHODOW_HOLDING_REGISTER_8 = 69,
            SHODOW_HOLDING_REGISTER_9 = 70,
            SHODOW_HOLDING_REGISTER_10 = 71,
            SHODOW_HOLDING_REGISTER_11 = 72,
            SHODOW_HOLDING_REGISTER_12 = 73,
            SHODOW_HOLDING_REGISTER_13 = 74,
            SHODOW_HOLDING_REGISTER_14 = 75,
            SHODOW_HOLDING_REGISTER_15 = 76,
            SHODOW_HOLDING_REGISTER_16 = 77,
            SHODOW_HOLDING_REGISTER_17 = 78,
            SHODOW_HOLDING_REGISTER_18 = 79,
            SHODOW_HOLDING_REGISTER_19 = 80,
            SHODOW_HOLDING_REGISTER_20 = 81,
            SHODOW_HOLDING_REGISTER_21 = 82,
            SHODOW_HOLDING_REGISTER_22 = 83,
            SHODOW_HOLDING_REGISTER_23 = 84,
            SHODOW_HOLDING_REGISTER_24 = 85,
            SHODOW_HOLDING_REGISTER_25 = 86,
            SHODOW_HOLDING_REGISTER_26 = 87,
            SHODOW_HOLDING_REGISTER_27 = 88,
            SHODOW_HOLDING_REGISTER_28 = 89,
            SHODOW_HOLDING_REGISTER_29 = 90,
            SHODOW_HOLDING_REGISTER_30 = 91,
            SHODOW_HOLDING_REGISTER_31 = 92,
            SHODOW_HOLDING_REGISTER_32 = 93,
            SHODOW_HOLDING_REGISTER_33 = 94,
            SHODOW_HOLDING_REGISTER_34 = 95,
            SHODOW_HOLDING_REGISTER_35 = 96,
            SHODOW_HOLDING_REGISTER_36 = 97,
            SHODOW_HOLDING_REGISTER_37 = 98,
            SHODOW_HOLDING_REGISTER_38 = 99,
            SHODOW_HOLDING_REGISTER_39 = 100,
            SHODOW_HOLDING_REGISTER_40 = 101,
            SHODOW_HOLDING_REGISTER_41 = 102,
            SHODOW_HOLDING_REGISTER_42 = 103,
            SHODOW_HOLDING_REGISTER_43 = 104,
            SHODOW_HOLDING_REGISTER_44 = 105,
            SHODOW_HOLDING_REGISTER_45 = 106,
            SHODOW_HOLDING_REGISTER_46 = 107,
            SHODOW_HOLDING_REGISTER_47 = 108,
            SHODOW_HOLDING_REGISTER_48 = 109,
            SHODOW_HOLDING_REGISTER_49 = 110,
            SHODOW_HOLDING_REGISTER_50 = 111,
            SHODOW_HOLDING_REGISTER_51 = 112,
            SHODOW_HOLDING_REGISTER_52 = 113,
            SHODOW_HOLDING_REGISTER_53 = 114,
            SHODOW_HOLDING_REGISTER_54 = 115,
            SHODOW_HOLDING_REGISTER_55 = 116,
            SHODOW_HOLDING_REGISTER_56 = 117,
            SHODOW_HOLDING_REGISTER_57 = 118,
            SHODOW_HOLDING_REGISTER_58 = 119,
            SHODOW_HOLDING_REGISTER_59 = 120,
            SHODOW_HOLDING_REGISTER_60 = 121,
            SHODOW_HOLDING_REGISTER_61 = 122,
            SHODOW_HOLDING_REGISTER_62 = 123,
            SHODOW_HOLDING_REGISTER_63 = 124,
            SHODOW_HOLDING_REGISTER_64 = 125,
            SHODOW_HOLDING_REGISTER_65 = 126,
            SHODOW_HOLDING_REGISTER_66 = 127,
            SHODOW_HOLDING_REGISTER_67 = 128,
            SHODOW_HOLDING_REGISTER_68 = 129,
            SHODOW_HOLDING_REGISTER_69 = 130,
            SHODOW_HOLDING_REGISTER_70 = 131,
            SHODOW_HOLDING_REGISTER_71 = 132,
            SHODOW_HOLDING_REGISTER_72 = 133,
            SHODOW_HOLDING_REGISTER_73 = 134,
            SHODOW_HOLDING_REGISTER_74 = 135,
            SHODOW_HOLDING_REGISTER_75 = 136,
            SHODOW_HOLDING_REGISTER_76 = 137,
            SHODOW_HOLDING_REGISTER_77 = 138,
            SHODOW_HOLDING_REGISTER_78 = 139,
            SHODOW_HOLDING_REGISTER_79 = 140,
            SHODOW_HOLDING_REGISTER_80 = 141,
            SHODOW_HOLDING_REGISTER_81 = 142,
            SHODOW_HOLDING_REGISTER_82 = 143,
            SHODOW_HOLDING_REGISTER_83 = 144,
            SHODOW_HOLDING_REGISTER_84 = 145,
            SHODOW_HOLDING_REGISTER_85 = 146,
            SHODOW_HOLDING_REGISTER_86 = 147,
            SHODOW_HOLDING_REGISTER_87 = 148,
            SHODOW_HOLDING_REGISTER_88 = 149,
            SHODOW_HOLDING_REGISTER_89 = 150,
            SHODOW_HOLDING_REGISTER_90 = 151,
            SHODOW_HOLDING_REGISTER_91 = 152,
            SHODOW_HOLDING_REGISTER_92 = 153,
            SHODOW_HOLDING_REGISTER_93 = 154,
            SHODOW_HOLDING_REGISTER_94 = 155,
            SHODOW_HOLDING_REGISTER_95 = 156,
            SHODOW_HOLDING_REGISTER_96 = 157,
            SHODOW_HOLDING_REGISTER_97 = 158,
            SHODOW_HOLDING_REGISTER_98 = 159,
            SHODOW_HOLDING_REGISTER_99 = 160,
            SHODOW_HOLDING_REGISTER_100 = 161,
            SHODOW_HOLDING_REGISTER_101 = 162,
            SHODOW_HOLDING_REGISTER_102 = 163,
            SHODOW_HOLDING_REGISTER_103 = 164,
            SHODOW_HOLDING_REGISTER_104 = 165,
            SHODOW_HOLDING_REGISTER_105 = 166,
            SHODOW_HOLDING_REGISTER_106 = 167,
            SHODOW_HOLDING_REGISTER_107 = 168,
            SHODOW_HOLDING_REGISTER_108 = 169,
            SHODOW_HOLDING_REGISTER_109 = 170,
            SHODOW_HOLDING_REGISTER_110 = 171,
            SHODOW_HOLDING_REGISTER_111 = 172,
            SHODOW_HOLDING_REGISTER_112 = 173,
            SHODOW_HOLDING_REGISTER_113 = 174,
            SHODOW_HOLDING_REGISTER_114 = 175,
            SHODOW_HOLDING_REGISTER_115 = 176,
            SHODOW_HOLDING_REGISTER_116 = 177,
            SHODOW_HOLDING_REGISTER_117 = 178,
            SHODOW_HOLDING_REGISTER_118 = 179,
            SHODOW_HOLDING_REGISTER_119 = 180,
            SHODOW_HOLDING_REGISTER_120 = 181,
            SHODOW_HOLDING_REGISTER_121 = 182,
            SHODOW_HOLDING_REGISTER_122 = 183,
            SHODOW_HOLDING_REGISTER_123 = 184,
            SHODOW_HOLDING_REGISTER_124 = 185,
            SHODOW_HOLDING_REGISTER_125 = 186,
            SHODOW_HOLDING_REGISTER_126 = 187,
            SHODOW_HOLDING_REGISTER_127 = 188,
            SHODOW_HOLDING_REGISTER_128 = 189,
            SHODOW_HOLDING_REGISTER_129 = 190,
            SHODOW_HOLDING_REGISTER_130 = 191,
            SHODOW_HOLDING_REGISTER_131 = 192,
            SHODOW_HOLDING_REGISTER_132 = 193,
            SHODOW_HOLDING_REGISTER_133 = 194,
            SHODOW_HOLDING_REGISTER_134 = 195,
            SHODOW_HOLDING_REGISTER_135 = 196,
            SHODOW_HOLDING_REGISTER_136 = 197,
            SHODOW_HOLDING_REGISTER_137 = 198,
            SHODOW_HOLDING_REGISTER_138 = 199,
            SHODOW_HOLDING_REGISTER_139 = 200,
            SHODOW_HOLDING_REGISTER_140 = 201,
            SHODOW_HOLDING_REGISTER_141 = 202,
            SHODOW_HOLDING_REGISTER_142 = 203,
            SHODOW_HOLDING_REGISTER_143 = 204,
            SHODOW_HOLDING_REGISTER_144 = 205,
            SHODOW_HOLDING_REGISTER_145 = 206,
            SHODOW_HOLDING_REGISTER_146 = 207,
            SHODOW_HOLDING_REGISTER_147 = 208,
            SHODOW_HOLDING_REGISTER_148 = 209,
            SHODOW_HOLDING_REGISTER_149 = 210,
            SHODOW_HOLDING_REGISTER_150 = 211,
            SHODOW_HOLDING_REGISTER_151 = 212,
            SHODOW_HOLDING_REGISTER_152 = 213,
            SHODOW_HOLDING_REGISTER_153 = 214,
            SHODOW_HOLDING_REGISTER_154 = 215,
            SHODOW_HOLDING_REGISTER_155 = 216,
            SHODOW_HOLDING_REGISTER_156 = 217,
            SHODOW_HOLDING_REGISTER_157 = 218,
            SHODOW_HOLDING_REGISTER_158 = 219,
            SHODOW_HOLDING_REGISTER_159 = 220,
            SHODOW_HOLDING_REGISTER_160 = 221,
            SHODOW_HOLDING_REGISTER_161 = 222,
            SHODOW_HOLDING_REGISTER_162 = 223,
            SHODOW_HOLDING_REGISTER_163 = 224,
            SHODOW_HOLDING_REGISTER_164 = 225,
            SHODOW_HOLDING_REGISTER_165 = 226,
            SHODOW_HOLDING_REGISTER_166 = 227,
            SHODOW_HOLDING_REGISTER_167 = 228,
            SHODOW_HOLDING_REGISTER_168 = 229,
            SHODOW_HOLDING_REGISTER_169 = 230,
            SHODOW_HOLDING_REGISTER_170 = 231,
            SHODOW_HOLDING_REGISTER_171 = 232,
            SHODOW_HOLDING_REGISTER_172 = 233,
            SHODOW_HOLDING_REGISTER_173 = 234,
            SHODOW_HOLDING_REGISTER_174 = 235,
            SHODOW_HOLDING_REGISTER_175 = 236,
            SHODOW_HOLDING_REGISTER_176 = 237,
            SHODOW_HOLDING_REGISTER_177 = 238,
            SHODOW_HOLDING_REGISTER_178 = 239,
            SHODOW_HOLDING_REGISTER_179 = 240,
            SHODOW_HOLDING_REGISTER_180 = 241,
            SHODOW_HOLDING_REGISTER_181 = 242,
            SHODOW_HOLDING_REGISTER_182 = 243,
            SHODOW_HOLDING_REGISTER_183 = 244,
            SHODOW_HOLDING_REGISTER_184 = 245,
            SHODOW_HOLDING_REGISTER_185 = 246,
            SHODOW_HOLDING_REGISTER_186 = 247,
            SHODOW_HOLDING_REGISTER_187 = 248,
            SHODOW_HOLDING_REGISTER_188 = 249,
            SHODOW_HOLDING_REGISTER_189 = 250,
            SHODOW_HOLDING_REGISTER_190 = 251,
            SHODOW_HOLDING_REGISTER_191 = 252,
            SHODOW_HOLDING_REGISTER_192 = 253,
            SHODOW_HOLDING_REGISTER_193 = 254,
            SHODOW_HOLDING_REGISTER_194 = 255,
            SHODOW_HOLDING_REGISTER_195 = 256,
            SHODOW_HOLDING_REGISTER_196 = 257,
            SHODOW_HOLDING_REGISTER_197 = 258,
            SHODOW_HOLDING_REGISTER_198 = 259,
            SHODOW_HOLDING_REGISTER_199 = 260,
            SHODOW_HOLDING_REGISTER_200 = 261,
            SHODOW_HOLDING_REGISTER_201 = 262,
            SHODOW_HOLDING_REGISTER_202 = 263,
            SHODOW_HOLDING_REGISTER_203 = 264,
            SHODOW_HOLDING_REGISTER_204 = 265,
            SHODOW_HOLDING_REGISTER_205 = 266,
            SHODOW_HOLDING_REGISTER_206 = 267,
            SHODOW_HOLDING_REGISTER_207 = 268,
            SHODOW_HOLDING_REGISTER_208 = 269,
            SHODOW_HOLDING_REGISTER_209 = 270,
            SHODOW_HOLDING_REGISTER_210 = 271,
            SHODOW_HOLDING_REGISTER_211 = 272,
            SHODOW_HOLDING_REGISTER_212 = 273,
            SHODOW_HOLDING_REGISTER_213 = 274,
            SHODOW_HOLDING_REGISTER_214 = 275,
            SHODOW_HOLDING_REGISTER_215 = 276,
            SHODOW_HOLDING_REGISTER_216 = 277,
            SHODOW_HOLDING_REGISTER_217 = 278,
            SHODOW_HOLDING_REGISTER_218 = 279,
            SHODOW_HOLDING_REGISTER_219 = 280,
            SHODOW_HOLDING_REGISTER_220 = 281,
            SHODOW_HOLDING_REGISTER_221 = 282,
            SHODOW_HOLDING_REGISTER_222 = 283,
            SHODOW_HOLDING_REGISTER_223 = 284,
            SHODOW_HOLDING_REGISTER_224 = 285,
            SHODOW_HOLDING_REGISTER_225 = 286,
            SHODOW_HOLDING_REGISTER_226 = 287,
            SHODOW_HOLDING_REGISTER_227 = 288,
            SHODOW_HOLDING_REGISTER_228 = 289,
            SHODOW_HOLDING_REGISTER_229 = 290,
            SHODOW_HOLDING_REGISTER_230 = 291,
            SHODOW_HOLDING_REGISTER_231 = 292,
            SHODOW_HOLDING_REGISTER_232 = 293,
            SHODOW_HOLDING_REGISTER_233 = 294,
            SHODOW_HOLDING_REGISTER_234 = 295,
            SHODOW_HOLDING_REGISTER_235 = 296,
            SHODOW_HOLDING_REGISTER_236 = 297,
            SHODOW_HOLDING_REGISTER_237 = 298,
            SHODOW_HOLDING_REGISTER_238 = 299,
            SHODOW_HOLDING_REGISTER_239 = 300,
            SHODOW_HOLDING_REGISTER_240 = 301,
            SHODOW_HOLDING_REGISTER_241 = 302,
            SHODOW_HOLDING_REGISTER_242 = 303,
            SHODOW_HOLDING_REGISTER_243 = 304,
            SHODOW_HOLDING_REGISTER_244 = 305,
            SHODOW_HOLDING_REGISTER_245 = 306,
            SHODOW_HOLDING_REGISTER_246 = 307,
            SHODOW_HOLDING_REGISTER_247 = 308,
            SHODOW_HOLDING_REGISTER_248 = 309,
            SHODOW_HOLDING_REGISTER_249 = 310,
            SHODOW_HOLDING_REGISTER_250 = 311,
            SHODOW_HOLDING_REGISTER_251 = 312,
            SHODOW_HOLDING_REGISTER_252 = 313,
            SHODOW_HOLDING_REGISTER_253 = 314,
            SHODOW_HOLDING_REGISTER_254 = 315,
            SHODOW_HOLDING_REGISTER_255 = 316,
            SHODOW_HOLDING_REGISTER_256 = 317,
            SHODOW_HOLDING_REGISTER_257 = 318,
            SHODOW_HOLDING_REGISTER_258 = 319,
            SHODOW_HOLDING_REGISTER_259 = 320,
            SHODOW_HOLDING_REGISTER_260 = 321,
            SHODOW_HOLDING_REGISTER_261 = 322,
            SHODOW_HOLDING_REGISTER_262 = 323,
            SHODOW_HOLDING_REGISTER_263 = 324,
            SHODOW_HOLDING_REGISTER_264 = 325,
            SHODOW_HOLDING_REGISTER_265 = 326,
            SHODOW_HOLDING_REGISTER_266 = 327,
            SHODOW_HOLDING_REGISTER_267 = 328,
            SHODOW_HOLDING_REGISTER_268 = 329,
            SHODOW_HOLDING_REGISTER_269 = 330,
            SHODOW_HOLDING_REGISTER_270 = 331,
            SHODOW_HOLDING_REGISTER_271 = 332,
            SHODOW_HOLDING_REGISTER_272 = 333,
            SHODOW_HOLDING_REGISTER_273 = 334,
            SHODOW_HOLDING_REGISTER_274 = 335,
            SHODOW_HOLDING_REGISTER_275 = 336,
            SHODOW_HOLDING_REGISTER_276 = 337,
            SHODOW_HOLDING_REGISTER_277 = 338,
            SHODOW_HOLDING_REGISTER_278 = 339,
            SHODOW_HOLDING_REGISTER_279 = 340,
            SHODOW_HOLDING_REGISTER_280 = 341,
            SHODOW_HOLDING_REGISTER_281 = 342,
            SHODOW_HOLDING_REGISTER_282 = 343,
            SHODOW_HOLDING_REGISTER_283 = 344,
            SHODOW_HOLDING_REGISTER_284 = 345,
            SHODOW_HOLDING_REGISTER_285 = 346,
            SHODOW_HOLDING_REGISTER_286 = 347,
            SHODOW_HOLDING_REGISTER_287 = 348,
            SHODOW_HOLDING_REGISTER_288 = 349,
            SHODOW_HOLDING_REGISTER_289 = 350,
            SHODOW_HOLDING_REGISTER_290 = 351,
            SHODOW_HOLDING_REGISTER_291 = 352,
            SHODOW_HOLDING_REGISTER_292 = 353,
            SHODOW_HOLDING_REGISTER_293 = 354,
            SHODOW_HOLDING_REGISTER_294 = 355,
            SHODOW_HOLDING_REGISTER_295 = 356,
            SHODOW_HOLDING_REGISTER_296 = 357,
            SHODOW_HOLDING_REGISTER_297 = 358,
            SHODOW_HOLDING_REGISTER_298 = 359,
            SHODOW_HOLDING_REGISTER_299 = 360,
            SHODOW_HOLDING_REGISTER_300 = 361,
            SHODOW_HOLDING_REGISTER_301 = 362,
            SHODOW_HOLDING_REGISTER_302 = 363,
            SHODOW_HOLDING_REGISTER_303 = 364,
            SHODOW_HOLDING_REGISTER_304 = 365,
            SHODOW_HOLDING_REGISTER_305 = 366,
            SHODOW_HOLDING_REGISTER_306 = 367,
            SHODOW_HOLDING_REGISTER_307 = 368,
            SHODOW_HOLDING_REGISTER_308 = 369,
            SHODOW_HOLDING_REGISTER_309 = 370,
            SHODOW_HOLDING_REGISTER_310 = 371,
            SHODOW_HOLDING_REGISTER_311 = 372,
            SHODOW_HOLDING_REGISTER_312 = 373,
            SHODOW_HOLDING_REGISTER_313 = 374,
            SHODOW_HOLDING_REGISTER_314 = 375,
            SHODOW_HOLDING_REGISTER_315 = 376,
            SHODOW_HOLDING_REGISTER_316 = 377,
            SHODOW_HOLDING_REGISTER_317 = 378,
            SHODOW_HOLDING_REGISTER_318 = 379,
            SHODOW_HOLDING_REGISTER_319 = 380,
            SHODOW_HOLDING_REGISTER_320 = 381,
            SHODOW_HOLDING_REGISTER_321 = 382,
            SHODOW_HOLDING_REGISTER_322 = 383,
            SHODOW_HOLDING_REGISTER_323 = 384,
            SHODOW_HOLDING_REGISTER_324 = 385,
            SHODOW_HOLDING_REGISTER_325 = 386,
            SHODOW_HOLDING_REGISTER_326 = 387,
            SHODOW_HOLDING_REGISTER_327 = 388,
            SHODOW_HOLDING_REGISTER_328 = 389,
            SHODOW_HOLDING_REGISTER_329 = 390,
            SHODOW_HOLDING_REGISTER_330 = 391,
            SHODOW_HOLDING_REGISTER_331 = 392,
            SHODOW_HOLDING_REGISTER_332 = 393,
            SHODOW_HOLDING_REGISTER_333 = 394,
            SHODOW_HOLDING_REGISTER_334 = 395,
            SHODOW_HOLDING_REGISTER_335 = 396,
            SHODOW_HOLDING_REGISTER_336 = 397,
            SHODOW_HOLDING_REGISTER_337 = 398,
            SHODOW_HOLDING_REGISTER_338 = 399,
            SHODOW_HOLDING_REGISTER_339 = 400,
            SHODOW_HOLDING_REGISTER_340 = 401,
            SHODOW_HOLDING_REGISTER_341 = 402,
            SHODOW_HOLDING_REGISTER_342 = 403,
            SHODOW_HOLDING_REGISTER_343 = 404,
            SHODOW_HOLDING_REGISTER_344 = 405,
            SHODOW_HOLDING_REGISTER_345 = 406,
            SHODOW_HOLDING_REGISTER_346 = 407,
            SHODOW_HOLDING_REGISTER_347 = 408,
            SHODOW_HOLDING_REGISTER_348 = 409,
            SHODOW_HOLDING_REGISTER_349 = 410,
            SHODOW_HOLDING_REGISTER_350 = 411,
            SHODOW_HOLDING_REGISTER_351 = 412,
            SHODOW_HOLDING_REGISTER_352 = 413,
            SHODOW_HOLDING_REGISTER_353 = 414,
            SHODOW_HOLDING_REGISTER_354 = 415,
            SHODOW_HOLDING_REGISTER_355 = 416,
            SHODOW_HOLDING_REGISTER_356 = 417,
            SHODOW_HOLDING_REGISTER_357 = 418,
            SHODOW_HOLDING_REGISTER_358 = 419,
            SHODOW_HOLDING_REGISTER_359 = 420,
            SHODOW_HOLDING_REGISTER_360 = 421,
            SHODOW_HOLDING_REGISTER_361 = 422,
            SHODOW_HOLDING_REGISTER_362 = 423,
            SHODOW_HOLDING_REGISTER_363 = 424,
            SHODOW_HOLDING_REGISTER_364 = 425,
            SHODOW_HOLDING_REGISTER_365 = 426,
            SHODOW_HOLDING_REGISTER_366 = 427,
            SHODOW_HOLDING_REGISTER_367 = 428,
            SHODOW_HOLDING_REGISTER_368 = 429,
            SHODOW_HOLDING_REGISTER_369 = 430,
            SHODOW_HOLDING_REGISTER_370 = 431,
            SHODOW_HOLDING_REGISTER_371 = 432,
            SHODOW_HOLDING_REGISTER_372 = 433,
            SHODOW_HOLDING_REGISTER_373 = 434,
            SHODOW_HOLDING_REGISTER_374 = 435,
            SHODOW_HOLDING_REGISTER_375 = 436,
            SHODOW_HOLDING_REGISTER_376 = 437,
            SHODOW_HOLDING_REGISTER_377 = 438,
            SHODOW_HOLDING_REGISTER_378 = 439,
            SHODOW_HOLDING_REGISTER_379 = 440,
            SHODOW_HOLDING_REGISTER_380 = 441,
            SHODOW_HOLDING_REGISTER_381 = 442,
            SHODOW_HOLDING_REGISTER_382 = 443,
            SHODOW_HOLDING_REGISTER_383 = 444,
            SHODOW_HOLDING_REGISTER_384 = 445,
            SHODOW_HOLDING_REGISTER_385 = 446,
            SHODOW_HOLDING_REGISTER_386 = 447,
            SHODOW_HOLDING_REGISTER_387 = 448,
            SHODOW_HOLDING_REGISTER_388 = 449,
            SHODOW_HOLDING_REGISTER_389 = 450,
            SHODOW_HOLDING_REGISTER_390 = 451,
            SHODOW_HOLDING_REGISTER_391 = 452,
            SHODOW_HOLDING_REGISTER_392 = 453,
            SHODOW_HOLDING_REGISTER_393 = 454,
            SHODOW_HOLDING_REGISTER_394 = 455,
            SHODOW_HOLDING_REGISTER_395 = 456,
            SHODOW_HOLDING_REGISTER_396 = 457,
            SHODOW_HOLDING_REGISTER_397 = 458,
            SHODOW_HOLDING_REGISTER_398 = 459,
            SHODOW_HOLDING_REGISTER_399 = 460,
            SHODOW_HOLDING_REGISTER_400 = 461,
            SHODOW_HOLDING_REGISTER_401 = 462,
            SHODOW_HOLDING_REGISTER_402 = 463,
            SHODOW_HOLDING_REGISTER_403 = 464,
            SHODOW_HOLDING_REGISTER_404 = 465,
            SHODOW_HOLDING_REGISTER_405 = 466,
            SHODOW_HOLDING_REGISTER_406 = 467,
            SHODOW_HOLDING_REGISTER_407 = 468,
            SHODOW_HOLDING_REGISTER_408 = 469,
            SHODOW_HOLDING_REGISTER_409 = 470,
            SHODOW_HOLDING_REGISTER_410 = 471,
            SHODOW_HOLDING_REGISTER_411 = 472,
            SHODOW_HOLDING_REGISTER_412 = 473,
            SHODOW_HOLDING_REGISTER_413 = 474,
            SHODOW_HOLDING_REGISTER_414 = 475,
            SHODOW_HOLDING_REGISTER_415 = 476,
            SHODOW_HOLDING_REGISTER_416 = 477,
            SHODOW_HOLDING_REGISTER_417 = 478,
            SHODOW_HOLDING_REGISTER_418 = 479,
            SHODOW_HOLDING_REGISTER_419 = 480,
            SHODOW_HOLDING_REGISTER_420 = 481,
            SHODOW_HOLDING_REGISTER_421 = 482,
            SHODOW_HOLDING_REGISTER_422 = 483,
            SHODOW_HOLDING_REGISTER_423 = 484,
            SHODOW_HOLDING_REGISTER_424 = 485,
            SHODOW_HOLDING_REGISTER_425 = 486,
            SHODOW_HOLDING_REGISTER_426 = 487,
            SHODOW_HOLDING_REGISTER_427 = 488,
            SHODOW_HOLDING_REGISTER_428 = 489,
            SHODOW_HOLDING_REGISTER_429 = 490,
            SHODOW_HOLDING_REGISTER_430 = 491,
            SHODOW_HOLDING_REGISTER_431 = 492,
            SHODOW_HOLDING_REGISTER_432 = 493,
            SHODOW_HOLDING_REGISTER_433 = 494,
            SHODOW_HOLDING_REGISTER_434 = 495,
            SHODOW_HOLDING_REGISTER_435 = 496,
            SHODOW_HOLDING_REGISTER_436 = 497,
            SHODOW_HOLDING_REGISTER_437 = 498,
            SHODOW_HOLDING_REGISTER_438 = 499,
            SHODOW_HOLDING_REGISTER_439 = 500,
            SHODOW_HOLDING_REGISTER_440 = 501,
            SHODOW_HOLDING_REGISTER_441 = 502,
            SHODOW_HOLDING_REGISTER_442 = 503,
            SHODOW_HOLDING_REGISTER_443 = 504,
            SHODOW_HOLDING_REGISTER_444 = 505,
            SHODOW_HOLDING_REGISTER_445 = 506,
            SHODOW_HOLDING_REGISTER_446 = 507,
            SHODOW_HOLDING_REGISTER_447 = 508,
            SHODOW_HOLDING_REGISTER_448 = 509,
            SHODOW_HOLDING_REGISTER_449 = 510,
            SHODOW_HOLDING_REGISTER_450 = 511,
            SHODOW_HOLDING_REGISTER_451 = 512,
            SHODOW_HOLDING_REGISTER_452 = 513,
            SHODOW_HOLDING_REGISTER_453 = 514,
            SHODOW_HOLDING_REGISTER_454 = 515,
            SHODOW_HOLDING_REGISTER_455 = 516,
            SHODOW_HOLDING_REGISTER_456 = 517,
            SHODOW_HOLDING_REGISTER_457 = 518,
            SHODOW_HOLDING_REGISTER_458 = 519,
            SHODOW_HOLDING_REGISTER_459 = 520,
            SHODOW_HOLDING_REGISTER_460 = 521,
            SHODOW_HOLDING_REGISTER_461 = 522,
            SHODOW_HOLDING_REGISTER_462 = 523,
            SHODOW_HOLDING_REGISTER_463 = 524,
            SHODOW_HOLDING_REGISTER_464 = 525,
            SHODOW_HOLDING_REGISTER_465 = 526,
            SHODOW_HOLDING_REGISTER_466 = 527,
            SHODOW_HOLDING_REGISTER_467 = 528,
            SHODOW_HOLDING_REGISTER_468 = 529,
            SHODOW_HOLDING_REGISTER_469 = 530,
            SHODOW_HOLDING_REGISTER_470 = 531,
            SHODOW_HOLDING_REGISTER_471 = 532,
            SHODOW_HOLDING_REGISTER_472 = 533,
            SHODOW_HOLDING_REGISTER_473 = 534,
            SHODOW_HOLDING_REGISTER_474 = 535,
            SHODOW_HOLDING_REGISTER_475 = 536,
            SHODOW_HOLDING_REGISTER_476 = 537,
            SHODOW_HOLDING_REGISTER_477 = 538,
            SHODOW_HOLDING_REGISTER_478 = 539,
            SHODOW_HOLDING_REGISTER_479 = 540,
            SHODOW_HOLDING_REGISTER_480 = 541,
            SHODOW_HOLDING_REGISTER_481 = 542,
            SHODOW_HOLDING_REGISTER_482 = 543,
            SHODOW_HOLDING_REGISTER_483 = 544,
            SHODOW_HOLDING_REGISTER_484 = 545,
            SHODOW_HOLDING_REGISTER_485 = 546,
            SHODOW_HOLDING_REGISTER_486 = 547,
            SHODOW_HOLDING_REGISTER_487 = 548,
            SHODOW_HOLDING_REGISTER_488 = 549,
            SHODOW_HOLDING_REGISTER_489 = 550,
            SHODOW_HOLDING_REGISTER_490 = 551,
            SHODOW_HOLDING_REGISTER_491 = 552,
            SHODOW_HOLDING_REGISTER_492 = 553,
            SHODOW_HOLDING_REGISTER_493 = 554,
            SHODOW_HOLDING_REGISTER_494 = 555,
            SHODOW_HOLDING_REGISTER_495 = 556,
            SHODOW_HOLDING_REGISTER_496 = 557,
            SHODOW_HOLDING_REGISTER_497 = 558,
            SHODOW_HOLDING_REGISTER_498 = 559,
            SHODOW_HOLDING_REGISTER_499 = 560,
            SHODOW_HOLDING_REGISTER_500 = 561,
            SHODOW_HOLDING_REGISTER_501 = 562,
            SHODOW_HOLDING_REGISTER_502 = 563,
            SHODOW_HOLDING_REGISTER_503 = 564,
            SHODOW_HOLDING_REGISTER_504 = 565,
            SHODOW_HOLDING_REGISTER_505 = 566,
            SHODOW_HOLDING_REGISTER_506 = 567,
            SHODOW_HOLDING_REGISTER_507 = 568,
            SHODOW_HOLDING_REGISTER_508 = 569,
            SHODOW_HOLDING_REGISTER_509 = 570,
            SHODOW_HOLDING_REGISTER_510 = 571,
            SHODOW_HOLDING_REGISTER_511 = 572,
            SHODOW_HOLDING_REGISTER_512 = 573,
            SHODOW_HOLDING_REGISTER_513 = 574,
            SHODOW_HOLDING_REGISTER_514 = 575,
            SHODOW_HOLDING_REGISTER_515 = 576,
            SHODOW_HOLDING_REGISTER_516 = 577,
            SHODOW_HOLDING_REGISTER_517 = 578,
            SHODOW_HOLDING_REGISTER_518 = 579,
            SHODOW_HOLDING_REGISTER_519 = 580,
            SHODOW_HOLDING_REGISTER_520 = 581,
            SHODOW_HOLDING_REGISTER_521 = 582,
            SHODOW_HOLDING_REGISTER_522 = 583,
            SHODOW_HOLDING_REGISTER_523 = 584,
            SHODOW_HOLDING_REGISTER_524 = 585,
            SHODOW_HOLDING_REGISTER_525 = 586,
            SHODOW_HOLDING_REGISTER_526 = 587,
            SHODOW_HOLDING_REGISTER_527 = 588,
            SHODOW_HOLDING_REGISTER_528 = 589,
            SHODOW_HOLDING_REGISTER_529 = 590,
            SHODOW_HOLDING_REGISTER_530 = 591,
            SHODOW_HOLDING_REGISTER_531 = 592,
            SHODOW_HOLDING_REGISTER_532 = 593,
            SHODOW_HOLDING_REGISTER_533 = 594,
            SHODOW_HOLDING_REGISTER_534 = 595,
            SHODOW_HOLDING_REGISTER_535 = 596,
            SHODOW_HOLDING_REGISTER_536 = 597,
            SHODOW_HOLDING_REGISTER_537 = 598,
            SHODOW_HOLDING_REGISTER_538 = 599,
            SHODOW_HOLDING_REGISTER_539 = 600,
            SHODOW_HOLDING_REGISTER_540 = 601,
            SHODOW_HOLDING_REGISTER_541 = 602,
            SHODOW_HOLDING_REGISTER_542 = 603,
            SHODOW_HOLDING_REGISTER_543 = 604,
            SHODOW_HOLDING_REGISTER_544 = 605,
            SHODOW_HOLDING_REGISTER_545 = 606,
            SHODOW_HOLDING_REGISTER_546 = 607,
            SHODOW_HOLDING_REGISTER_547 = 608,
            SHODOW_HOLDING_REGISTER_548 = 609,
            SHODOW_HOLDING_REGISTER_549 = 610,
            SHODOW_HOLDING_REGISTER_550 = 611,
            SHODOW_HOLDING_REGISTER_551 = 612,
            SHODOW_HOLDING_REGISTER_552 = 613,
            SHODOW_HOLDING_REGISTER_553 = 614,
            SHODOW_HOLDING_REGISTER_554 = 615,
            SHODOW_HOLDING_REGISTER_555 = 616,
            SHODOW_HOLDING_REGISTER_556 = 617,
            SHODOW_HOLDING_REGISTER_557 = 618,
            SHODOW_HOLDING_REGISTER_558 = 619,
            SHODOW_HOLDING_REGISTER_559 = 620,
            SHODOW_HOLDING_REGISTER_560 = 621,
            SHODOW_HOLDING_REGISTER_561 = 622,
            SHODOW_HOLDING_REGISTER_562 = 623,
            SHODOW_HOLDING_REGISTER_563 = 624,
            SHODOW_HOLDING_REGISTER_564 = 625,
            SHODOW_HOLDING_REGISTER_565 = 626,
            SHODOW_HOLDING_REGISTER_566 = 627,
            SHODOW_HOLDING_REGISTER_567 = 628,
            SHODOW_HOLDING_REGISTER_568 = 629,
            SHODOW_HOLDING_REGISTER_569 = 630,
            SHODOW_HOLDING_REGISTER_570 = 631,
            SHODOW_HOLDING_REGISTER_571 = 632,
            SHODOW_HOLDING_REGISTER_572 = 633,
            SHODOW_HOLDING_REGISTER_573 = 634,
            SHODOW_HOLDING_REGISTER_574 = 635,
            SHODOW_HOLDING_REGISTER_575 = 636,
            SHODOW_HOLDING_REGISTER_576 = 637,
            SHODOW_HOLDING_REGISTER_577 = 638,
            SHODOW_HOLDING_REGISTER_578 = 639,
            SHODOW_HOLDING_REGISTER_579 = 640,
            SHODOW_HOLDING_REGISTER_580 = 641,
            SHODOW_HOLDING_REGISTER_581 = 642,
            SHODOW_HOLDING_REGISTER_582 = 643,
            SHODOW_HOLDING_REGISTER_583 = 644,
            SHODOW_HOLDING_REGISTER_584 = 645,
            SHODOW_HOLDING_REGISTER_585 = 646,
            SHODOW_HOLDING_REGISTER_586 = 647,
            SHODOW_HOLDING_REGISTER_587 = 648,
            SHODOW_HOLDING_REGISTER_588 = 649,
            SHODOW_HOLDING_REGISTER_589 = 650,
            SHODOW_HOLDING_REGISTER_590 = 651,
            SHODOW_HOLDING_REGISTER_591 = 652,
            SHODOW_HOLDING_REGISTER_592 = 653,
            SHODOW_HOLDING_REGISTER_593 = 654,
            SHODOW_HOLDING_REGISTER_594 = 655,
            SHODOW_HOLDING_REGISTER_595 = 656,
            SHODOW_HOLDING_REGISTER_596 = 657,
            SHODOW_HOLDING_REGISTER_597 = 658,
            SHODOW_HOLDING_REGISTER_598 = 659,
            SHODOW_HOLDING_REGISTER_599 = 660,
            SHODOW_HOLDING_REGISTER_600 = 661,
            SHODOW_HOLDING_REGISTER_601 = 662,
            SHODOW_HOLDING_REGISTER_602 = 663,
            SHODOW_HOLDING_REGISTER_603 = 664,
            SHODOW_HOLDING_REGISTER_604 = 665,
            SHODOW_HOLDING_REGISTER_605 = 666,
            SHODOW_HOLDING_REGISTER_606 = 667,
            SHODOW_HOLDING_REGISTER_607 = 668,
            SHODOW_HOLDING_REGISTER_608 = 669,
            SHODOW_HOLDING_REGISTER_609 = 670,
            SHODOW_HOLDING_REGISTER_610 = 671,
            SHODOW_HOLDING_REGISTER_611 = 672,
            SHODOW_HOLDING_REGISTER_612 = 673,
            SHODOW_HOLDING_REGISTER_613 = 674,
            SHODOW_HOLDING_REGISTER_614 = 675,
            SHODOW_HOLDING_REGISTER_615 = 676,
            SHODOW_HOLDING_REGISTER_616 = 677,
            SHODOW_HOLDING_REGISTER_617 = 678,
            SHODOW_HOLDING_REGISTER_618 = 679,
            SHODOW_HOLDING_REGISTER_619 = 680,
            SHODOW_HOLDING_REGISTER_620 = 681,
            SHODOW_HOLDING_REGISTER_621 = 682,
            SHODOW_HOLDING_REGISTER_622 = 683,
            SHODOW_HOLDING_REGISTER_623 = 684,
            SHODOW_HOLDING_REGISTER_624 = 685,
            SHODOW_HOLDING_REGISTER_625 = 686,
            SHODOW_HOLDING_REGISTER_626 = 687,
            SHODOW_HOLDING_REGISTER_627 = 688,
            SHODOW_HOLDING_REGISTER_628 = 689,
            SHODOW_HOLDING_REGISTER_629 = 690,
            SHODOW_HOLDING_REGISTER_630 = 691,
            SHODOW_HOLDING_REGISTER_631 = 692,
            SHODOW_HOLDING_REGISTER_632 = 693,
            SHODOW_HOLDING_REGISTER_633 = 694,
            SHODOW_HOLDING_REGISTER_634 = 695,
            SHODOW_HOLDING_REGISTER_635 = 696,
            SHODOW_HOLDING_REGISTER_636 = 697,
            SHODOW_HOLDING_REGISTER_637 = 698,
            SHODOW_HOLDING_REGISTER_638 = 699,
            SHODOW_HOLDING_REGISTER_639 = 700,
            SHODOW_HOLDING_REGISTER_640 = 701,
            SHODOW_HOLDING_REGISTER_641 = 702,
            SHODOW_HOLDING_REGISTER_642 = 703,
            SHODOW_HOLDING_REGISTER_643 = 704,
            SHODOW_HOLDING_REGISTER_644 = 705,
            SHODOW_HOLDING_REGISTER_645 = 706,
            SHODOW_HOLDING_REGISTER_646 = 707,
            SHODOW_HOLDING_REGISTER_647 = 708,
            SHODOW_HOLDING_REGISTER_648 = 709,
            SHODOW_HOLDING_REGISTER_649 = 710,
            SHODOW_HOLDING_REGISTER_650 = 711,
            SHODOW_HOLDING_REGISTER_651 = 712,
            SHODOW_HOLDING_REGISTER_652 = 713,
            SHODOW_HOLDING_REGISTER_653 = 714,
            SHODOW_HOLDING_REGISTER_654 = 715,
            SHODOW_HOLDING_REGISTER_655 = 716,
            SHODOW_HOLDING_REGISTER_656 = 717,
            SHODOW_HOLDING_REGISTER_657 = 718,
            SHODOW_HOLDING_REGISTER_658 = 719,
            SHODOW_HOLDING_REGISTER_659 = 720,
            SHODOW_HOLDING_REGISTER_660 = 721,
            SHODOW_HOLDING_REGISTER_661 = 722,
            SHODOW_HOLDING_REGISTER_662 = 723,
            SHODOW_HOLDING_REGISTER_663 = 724,
            SHODOW_HOLDING_REGISTER_664 = 725,
            SHODOW_HOLDING_REGISTER_665 = 726,
            SHODOW_HOLDING_REGISTER_666 = 727,
            SHODOW_HOLDING_REGISTER_667 = 728,
            SHODOW_HOLDING_REGISTER_668 = 729,
            SHODOW_HOLDING_REGISTER_669 = 730,
            SHODOW_HOLDING_REGISTER_670 = 731,
            SHODOW_HOLDING_REGISTER_671 = 732,
            SHODOW_HOLDING_REGISTER_672 = 733,
            SHODOW_HOLDING_REGISTER_673 = 734,
            SHODOW_HOLDING_REGISTER_674 = 735,
            SHODOW_HOLDING_REGISTER_675 = 736,
            SHODOW_HOLDING_REGISTER_676 = 737,
            SHODOW_HOLDING_REGISTER_677 = 738,
            SHODOW_HOLDING_REGISTER_678 = 739,
            SHODOW_HOLDING_REGISTER_679 = 740,
            SHODOW_HOLDING_REGISTER_680 = 741,
            SHODOW_HOLDING_REGISTER_681 = 742,
            SHODOW_HOLDING_REGISTER_682 = 743,
            SHODOW_HOLDING_REGISTER_683 = 744,
            SHODOW_HOLDING_REGISTER_684 = 745,
            SHODOW_HOLDING_REGISTER_685 = 746,
            SHODOW_HOLDING_REGISTER_686 = 747,
            SHODOW_HOLDING_REGISTER_687 = 748,
            SHODOW_HOLDING_REGISTER_688 = 749,
            SHODOW_HOLDING_REGISTER_689 = 750,
            SHODOW_HOLDING_REGISTER_690 = 751,
            SHODOW_HOLDING_REGISTER_691 = 752,
            SHODOW_HOLDING_REGISTER_692 = 753,
            SHODOW_HOLDING_REGISTER_693 = 754,
            SHODOW_HOLDING_REGISTER_694 = 755,
            SHODOW_HOLDING_REGISTER_695 = 756,
            SHODOW_HOLDING_REGISTER_696 = 757,
            SHODOW_HOLDING_REGISTER_697 = 758,
            SHODOW_HOLDING_REGISTER_698 = 759,
            SHODOW_HOLDING_REGISTER_699 = 760,
            SHODOW_HOLDING_REGISTER_700 = 761,
            SHODOW_HOLDING_REGISTER_701 = 762,
            SHODOW_HOLDING_REGISTER_702 = 763,
            SHODOW_HOLDING_REGISTER_703 = 764,
            SHODOW_HOLDING_REGISTER_704 = 765,
            SHODOW_HOLDING_REGISTER_705 = 766,
            SHODOW_HOLDING_REGISTER_706 = 767,
            SHODOW_HOLDING_REGISTER_707 = 768,
            SHODOW_HOLDING_REGISTER_708 = 769,
            SHODOW_HOLDING_REGISTER_709 = 770,
            SHODOW_HOLDING_REGISTER_710 = 771,
            SHODOW_HOLDING_REGISTER_711 = 772,
            SHODOW_HOLDING_REGISTER_712 = 773,
            SHODOW_HOLDING_REGISTER_713 = 774,
            SHODOW_HOLDING_REGISTER_714 = 775,
            SHODOW_HOLDING_REGISTER_715 = 776,
            SHODOW_HOLDING_REGISTER_716 = 777,
            SHODOW_HOLDING_REGISTER_717 = 778,
            SHODOW_HOLDING_REGISTER_718 = 779,
            SHODOW_HOLDING_REGISTER_719 = 780,
            SHODOW_HOLDING_REGISTER_720 = 781,
            SHODOW_HOLDING_REGISTER_721 = 782,
            SHODOW_HOLDING_REGISTER_722 = 783,
            SHODOW_HOLDING_REGISTER_723 = 784,
            SHODOW_HOLDING_REGISTER_724 = 785,
            SHODOW_HOLDING_REGISTER_725 = 786,
            SHODOW_HOLDING_REGISTER_726 = 787,
            SHODOW_HOLDING_REGISTER_727 = 788,
            SHODOW_HOLDING_REGISTER_728 = 789,
            SHODOW_HOLDING_REGISTER_729 = 790,
            SHODOW_HOLDING_REGISTER_730 = 791,
            SHODOW_HOLDING_REGISTER_731 = 792,
            SHODOW_HOLDING_REGISTER_732 = 793,
            SHODOW_HOLDING_REGISTER_733 = 794,
            SHODOW_HOLDING_REGISTER_734 = 795,
            SHODOW_HOLDING_REGISTER_735 = 796,
            SHODOW_HOLDING_REGISTER_736 = 797,
            SHODOW_HOLDING_REGISTER_737 = 798,
            SHODOW_HOLDING_REGISTER_738 = 799,
            SHODOW_HOLDING_REGISTER_739 = 800,
            SHODOW_HOLDING_REGISTER_740 = 801,
            SHODOW_HOLDING_REGISTER_741 = 802,
            SHODOW_HOLDING_REGISTER_742 = 803,
            SHODOW_HOLDING_REGISTER_743 = 804,
            SHODOW_HOLDING_REGISTER_744 = 805,
            SHODOW_HOLDING_REGISTER_745 = 806,
            SHODOW_HOLDING_REGISTER_746 = 807,
            SHODOW_HOLDING_REGISTER_747 = 808,
            SHODOW_HOLDING_REGISTER_748 = 809,
            SHODOW_HOLDING_REGISTER_749 = 810,
            SHODOW_HOLDING_REGISTER_750 = 811,
            SHODOW_HOLDING_REGISTER_751 = 812,
            SHODOW_HOLDING_REGISTER_752 = 813,
            SHODOW_HOLDING_REGISTER_753 = 814,
            SHODOW_HOLDING_REGISTER_754 = 815,
            SHODOW_HOLDING_REGISTER_755 = 816,
            SHODOW_HOLDING_REGISTER_756 = 817,
            SHODOW_HOLDING_REGISTER_757 = 818,
            SHODOW_HOLDING_REGISTER_758 = 819,
            SHODOW_HOLDING_REGISTER_759 = 820,
            SHODOW_HOLDING_REGISTER_760 = 821,
            SHODOW_HOLDING_REGISTER_761 = 822,
            SHODOW_HOLDING_REGISTER_762 = 823,
            SHODOW_HOLDING_REGISTER_763 = 824,
            SHODOW_HOLDING_REGISTER_764 = 825,
            SHODOW_HOLDING_REGISTER_765 = 826,
            SHODOW_HOLDING_REGISTER_766 = 827,
            SHODOW_HOLDING_REGISTER_767 = 828,
            SHODOW_HOLDING_REGISTER_768 = 829,
            SHODOW_HOLDING_REGISTER_769 = 830,
            SHODOW_HOLDING_REGISTER_770 = 831,
            SHODOW_HOLDING_REGISTER_771 = 832,
            SHODOW_HOLDING_REGISTER_772 = 833,
            SHODOW_HOLDING_REGISTER_773 = 834,
            SHODOW_HOLDING_REGISTER_774 = 835,
            SHODOW_HOLDING_REGISTER_775 = 836,
            SHODOW_HOLDING_REGISTER_776 = 837,
            SHODOW_HOLDING_REGISTER_777 = 838,
            SHODOW_HOLDING_REGISTER_778 = 839,
            SHODOW_HOLDING_REGISTER_779 = 840,
            SHODOW_HOLDING_REGISTER_780 = 841,
            SHODOW_HOLDING_REGISTER_781 = 842,
            SHODOW_HOLDING_REGISTER_782 = 843,
            SHODOW_HOLDING_REGISTER_783 = 844,
            SHODOW_HOLDING_REGISTER_784 = 845,
            SHODOW_HOLDING_REGISTER_785 = 846,
            SHODOW_HOLDING_REGISTER_786 = 847,
            SHODOW_HOLDING_REGISTER_787 = 848,
            SHODOW_HOLDING_REGISTER_788 = 849,
            SHODOW_HOLDING_REGISTER_789 = 850,
            SHODOW_HOLDING_REGISTER_790 = 851,
            SHODOW_HOLDING_REGISTER_791 = 852,
            SHODOW_HOLDING_REGISTER_792 = 853,
            SHODOW_HOLDING_REGISTER_793 = 854,
            SHODOW_HOLDING_REGISTER_794 = 855,
            SHODOW_HOLDING_REGISTER_795 = 856,
            SHODOW_HOLDING_REGISTER_796 = 857,
            SHODOW_HOLDING_REGISTER_797 = 858,
            SHODOW_HOLDING_REGISTER_798 = 859,
            SHODOW_HOLDING_REGISTER_799 = 860,
            SHODOW_HOLDING_REGISTER_800 = 861,
            SHODOW_HOLDING_REGISTER_801 = 862,
            SHODOW_HOLDING_REGISTER_802 = 863,
            SHODOW_HOLDING_REGISTER_803 = 864,
            SHODOW_HOLDING_REGISTER_804 = 865,
            SHODOW_HOLDING_REGISTER_805 = 866,
            SHODOW_HOLDING_REGISTER_806 = 867,
            SHODOW_HOLDING_REGISTER_807 = 868,
            SHODOW_HOLDING_REGISTER_808 = 869,
            SHODOW_HOLDING_REGISTER_809 = 870,
            SHODOW_HOLDING_REGISTER_810 = 871,
            SHODOW_HOLDING_REGISTER_811 = 872,
            SHODOW_HOLDING_REGISTER_812 = 873,
            SHODOW_HOLDING_REGISTER_813 = 874,
            SHODOW_HOLDING_REGISTER_814 = 875,
            SHODOW_HOLDING_REGISTER_815 = 876,
            SHODOW_HOLDING_REGISTER_816 = 877,
            SHODOW_HOLDING_REGISTER_817 = 878,
            SHODOW_HOLDING_REGISTER_818 = 879,
            SHODOW_HOLDING_REGISTER_819 = 880,
            SHODOW_HOLDING_REGISTER_820 = 881,
            SHODOW_HOLDING_REGISTER_821 = 882,
            SHODOW_HOLDING_REGISTER_822 = 883,
            SHODOW_HOLDING_REGISTER_823 = 884,
            SHODOW_HOLDING_REGISTER_824 = 885,
            SHODOW_HOLDING_REGISTER_825 = 886,
            SHODOW_HOLDING_REGISTER_826 = 887,
            SHODOW_HOLDING_REGISTER_827 = 888,
            SHODOW_HOLDING_REGISTER_828 = 889,
            SHODOW_HOLDING_REGISTER_829 = 890,
            SHODOW_HOLDING_REGISTER_830 = 891,
            SHODOW_HOLDING_REGISTER_831 = 892,
            SHODOW_HOLDING_REGISTER_832 = 893,
            SHODOW_HOLDING_REGISTER_833 = 894,
            SHODOW_HOLDING_REGISTER_834 = 895,
            SHODOW_HOLDING_REGISTER_835 = 896,
            SHODOW_HOLDING_REGISTER_836 = 897,
            SHODOW_HOLDING_REGISTER_837 = 898,
            SHODOW_HOLDING_REGISTER_838 = 899,
            SHODOW_HOLDING_REGISTER_839 = 900,
            SHODOW_HOLDING_REGISTER_840 = 901,
            SHODOW_HOLDING_REGISTER_841 = 902,
            SHODOW_HOLDING_REGISTER_842 = 903,
            SHODOW_HOLDING_REGISTER_843 = 904,
            SHODOW_HOLDING_REGISTER_844 = 905,
            SHODOW_HOLDING_REGISTER_845 = 906,
            SHODOW_HOLDING_REGISTER_846 = 907,
            SHODOW_HOLDING_REGISTER_847 = 908,
            SHODOW_HOLDING_REGISTER_848 = 909,
            SHODOW_HOLDING_REGISTER_849 = 910,
            SHODOW_HOLDING_REGISTER_850 = 911,
            SHODOW_HOLDING_REGISTER_851 = 912,
            SHODOW_HOLDING_REGISTER_852 = 913,
            SHODOW_HOLDING_REGISTER_853 = 914,
            SHODOW_HOLDING_REGISTER_854 = 915,
            SHODOW_HOLDING_REGISTER_855 = 916,
            SHODOW_HOLDING_REGISTER_856 = 917,
            SHODOW_HOLDING_REGISTER_857 = 918,
            SHODOW_HOLDING_REGISTER_858 = 919,
            SHODOW_HOLDING_REGISTER_859 = 920,
            SHODOW_HOLDING_REGISTER_860 = 921,
            SHODOW_HOLDING_REGISTER_861 = 922,
            SHODOW_HOLDING_REGISTER_862 = 923,
            SHODOW_HOLDING_REGISTER_863 = 924,
            SHODOW_HOLDING_REGISTER_864 = 925,
            SHODOW_HOLDING_REGISTER_865 = 926,
            SHODOW_HOLDING_REGISTER_866 = 927,
            SHODOW_HOLDING_REGISTER_867 = 928,
            SHODOW_HOLDING_REGISTER_868 = 929,
            SHODOW_HOLDING_REGISTER_869 = 930,
            SHODOW_HOLDING_REGISTER_870 = 931,
            SHODOW_HOLDING_REGISTER_871 = 932,
            SHODOW_HOLDING_REGISTER_872 = 933,
            SHODOW_HOLDING_REGISTER_873 = 934,
            SHODOW_HOLDING_REGISTER_874 = 935,
            SHODOW_HOLDING_REGISTER_875 = 936,
            SHODOW_HOLDING_REGISTER_876 = 937,
            SHODOW_HOLDING_REGISTER_877 = 938,
            SHODOW_HOLDING_REGISTER_878 = 939,
            SHODOW_HOLDING_REGISTER_879 = 940,
            SHODOW_HOLDING_REGISTER_880 = 941,
            SHODOW_HOLDING_REGISTER_881 = 942,
            SHODOW_HOLDING_REGISTER_882 = 943,
            SHODOW_HOLDING_REGISTER_883 = 944,
            SHODOW_HOLDING_REGISTER_884 = 945,
            SHODOW_HOLDING_REGISTER_885 = 946,
            SHODOW_HOLDING_REGISTER_886 = 947,
            SHODOW_HOLDING_REGISTER_887 = 948,
            SHODOW_HOLDING_REGISTER_888 = 949,
            SHODOW_HOLDING_REGISTER_889 = 950,
            SHODOW_HOLDING_REGISTER_890 = 951,
            SHODOW_HOLDING_REGISTER_891 = 952,
            SHODOW_HOLDING_REGISTER_892 = 953,
            SHODOW_HOLDING_REGISTER_893 = 954,
            SHODOW_HOLDING_REGISTER_894 = 955,
            SHODOW_HOLDING_REGISTER_895 = 956,
            SHODOW_HOLDING_REGISTER_896 = 957,
            SHODOW_HOLDING_REGISTER_897 = 958,
            SHODOW_HOLDING_REGISTER_898 = 959,
            SHODOW_HOLDING_REGISTER_899 = 960,
            SHODOW_HOLDING_REGISTER_900 = 961,
            SHODOW_HOLDING_REGISTER_901 = 962,
            SHODOW_HOLDING_REGISTER_902 = 963,
            SHODOW_HOLDING_REGISTER_903 = 964,
            SHODOW_HOLDING_REGISTER_904 = 965,
            SHODOW_HOLDING_REGISTER_905 = 966,
            SHODOW_HOLDING_REGISTER_906 = 967,
            SHODOW_HOLDING_REGISTER_907 = 968,
            SHODOW_HOLDING_REGISTER_908 = 969,
            SHODOW_HOLDING_REGISTER_909 = 970,
            SHODOW_HOLDING_REGISTER_910 = 971,
            SHODOW_HOLDING_REGISTER_911 = 972,
            SHODOW_HOLDING_REGISTER_912 = 973,
            SHODOW_HOLDING_REGISTER_913 = 974,
            SHODOW_HOLDING_REGISTER_914 = 975,
            SHODOW_HOLDING_REGISTER_915 = 976,
            SHODOW_HOLDING_REGISTER_916 = 977,
            SHODOW_HOLDING_REGISTER_917 = 978,
            SHODOW_HOLDING_REGISTER_918 = 979,
            SHODOW_HOLDING_REGISTER_919 = 980,
            SHODOW_HOLDING_REGISTER_920 = 981,
            SHODOW_HOLDING_REGISTER_921 = 982,
            SHODOW_HOLDING_REGISTER_922 = 983,
            SHODOW_HOLDING_REGISTER_923 = 984,
            SHODOW_HOLDING_REGISTER_924 = 985,
            SHODOW_HOLDING_REGISTER_925 = 986,
            SHODOW_HOLDING_REGISTER_926 = 987,
            SHODOW_HOLDING_REGISTER_927 = 988,
            SHODOW_HOLDING_REGISTER_928 = 989,
            SHODOW_HOLDING_REGISTER_929 = 990,
            SHODOW_HOLDING_REGISTER_930 = 991,
            SHODOW_HOLDING_REGISTER_931 = 992,
            SHODOW_HOLDING_REGISTER_932 = 993,
            SHODOW_HOLDING_REGISTER_933 = 994,
            SHODOW_HOLDING_REGISTER_934 = 995,
            SHODOW_HOLDING_REGISTER_935 = 996,
            SHODOW_HOLDING_REGISTER_936 = 997,
            SHODOW_HOLDING_REGISTER_937 = 998,
            SHODOW_HOLDING_REGISTER_938 = 999,
            SHODOW_HOLDING_REGISTER_939 = 1000,
            SHODOW_HOLDING_REGISTER_940 = 1001,
            SHODOW_HOLDING_REGISTER_941 = 1002,
            SHODOW_HOLDING_REGISTER_942 = 1003,
            SHODOW_HOLDING_REGISTER_943 = 1004,
            SHODOW_HOLDING_REGISTER_944 = 1005,
            SHODOW_HOLDING_REGISTER_945 = 1006,
            SHODOW_HOLDING_REGISTER_946 = 1007,
            SHODOW_HOLDING_REGISTER_947 = 1008,
            SHODOW_HOLDING_REGISTER_948 = 1009,
            SHODOW_HOLDING_REGISTER_949 = 1010,
            SHODOW_HOLDING_REGISTER_950 = 1011,
            SHODOW_HOLDING_REGISTER_951 = 1012,
            SHODOW_HOLDING_REGISTER_952 = 1013,
            SHODOW_HOLDING_REGISTER_953 = 1014,
            SHODOW_HOLDING_REGISTER_954 = 1015,
            SHODOW_HOLDING_REGISTER_955 = 1016,
            SHODOW_HOLDING_REGISTER_956 = 1017,
            SHODOW_HOLDING_REGISTER_957 = 1018,
            SHODOW_HOLDING_REGISTER_958 = 1019,
            SHODOW_HOLDING_REGISTER_959 = 1020,
            SHODOW_HOLDING_REGISTER_960 = 1021,
            SHODOW_HOLDING_REGISTER_961 = 1022,
            SHODOW_HOLDING_REGISTER_962 = 1023,
            SHODOW_HOLDING_REGISTER_963 = 1024,
            SHODOW_HOLDING_REGISTER_964 = 1025,
            SHODOW_HOLDING_REGISTER_965 = 1026,
            SHODOW_HOLDING_REGISTER_966 = 1027,
            SHODOW_HOLDING_REGISTER_967 = 1028,
            SHODOW_HOLDING_REGISTER_968 = 1029,
            SHODOW_HOLDING_REGISTER_969 = 1030,
            SHODOW_HOLDING_REGISTER_970 = 1031,
            SHODOW_HOLDING_REGISTER_971 = 1032,
            SHODOW_HOLDING_REGISTER_972 = 1033,
            SHODOW_HOLDING_REGISTER_973 = 1034,
            SHODOW_HOLDING_REGISTER_974 = 1035,
            SHODOW_HOLDING_REGISTER_975 = 1036,
            SHODOW_HOLDING_REGISTER_976 = 1037,
            SHODOW_HOLDING_REGISTER_977 = 1038,
            SHODOW_HOLDING_REGISTER_978 = 1039,
            SHODOW_HOLDING_REGISTER_979 = 1040,
            SHODOW_HOLDING_REGISTER_980 = 1041,
            SHODOW_HOLDING_REGISTER_981 = 1042,
            SHODOW_HOLDING_REGISTER_982 = 1043,
            SHODOW_HOLDING_REGISTER_983 = 1044,
            SHODOW_HOLDING_REGISTER_984 = 1045,
            SHODOW_HOLDING_REGISTER_985 = 1046,
            SHODOW_HOLDING_REGISTER_986 = 1047,
            SHODOW_HOLDING_REGISTER_987 = 1048,
            SHODOW_HOLDING_REGISTER_988 = 1049,
            SHODOW_HOLDING_REGISTER_989 = 1050,
            SHODOW_HOLDING_REGISTER_990 = 1051,
            SHODOW_HOLDING_REGISTER_991 = 1052,
            SHODOW_HOLDING_REGISTER_992 = 1053,
            SHODOW_HOLDING_REGISTER_993 = 1054,
            SHODOW_HOLDING_REGISTER_994 = 1055,
            SHODOW_HOLDING_REGISTER_995 = 1056,
            SHODOW_HOLDING_REGISTER_996 = 1057,
            SHODOW_HOLDING_REGISTER_997 = 1058,
            SHODOW_HOLDING_REGISTER_998 = 1059,
            SHODOW_HOLDING_REGISTER_999 = 1060,
            SHODOW_HOLDING_REGISTER_CONFIG_0 = 1061,
            SHODOW_HOLDING_REGISTER_CONFIG_1 = 1062,
            SHODOW_HOLDING_REGISTER_CONFIG_2 = 1063,
            SHODOW_HOLDING_REGISTER_CONFIG_3 = 1064,
            SHODOW_HOLDING_REGISTER_CONFIG_4 = 1065,
            SHODOW_HOLDING_REGISTER_CONFIG_5 = 1066,
            SHODOW_HOLDING_REGISTER_CONFIG_6 = 1067,
            SHODOW_HOLDING_REGISTER_CONFIG_7 = 1068,
            SHODOW_HOLDING_REGISTER_CONFIG_8 = 1069,
            SHODOW_HOLDING_REGISTER_CONFIG_9 = 1070,
            SHODOW_HOLDING_REGISTER_CONFIG_10 = 1071,
            SHODOW_HOLDING_REGISTER_CONFIG_11 = 1072,
            SHODOW_HOLDING_REGISTER_CONFIG_12 = 1073,
            SHODOW_HOLDING_REGISTER_CONFIG_13 = 1074,
            SHODOW_HOLDING_REGISTER_CONFIG_14 = 1075,
            SHODOW_HOLDING_REGISTER_CONFIG_15 = 1076,
            SHODOW_HOLDING_REGISTER_CONFIG_16 = 1077,
            SHODOW_HOLDING_REGISTER_CONFIG_17 = 1078,
            SHODOW_HOLDING_REGISTER_CONFIG_18 = 1079,
            SHODOW_HOLDING_REGISTER_CONFIG_19 = 1080,
            SHODOW_HOLDING_REGISTER_CONFIG_20 = 1081,
            SHODOW_HOLDING_REGISTER_CONFIG_21 = 1082,
            SHODOW_HOLDING_REGISTER_CONFIG_22 = 1083,
            SHODOW_HOLDING_REGISTER_CONFIG_23 = 1084,
            SHODOW_HOLDING_REGISTER_CONFIG_24 = 1085,
            SHODOW_HOLDING_REGISTER_CONFIG_25 = 1086,
            SHODOW_HOLDING_REGISTER_CONFIG_26 = 1087,
            SHODOW_HOLDING_REGISTER_CONFIG_27 = 1088,
            SHODOW_HOLDING_REGISTER_CONFIG_28 = 1089,
            SHODOW_HOLDING_REGISTER_CONFIG_29 = 1090,
            SHODOW_HOLDING_REGISTER_CONFIG_30 = 1091,
            SHODOW_HOLDING_REGISTER_CONFIG_31 = 1092,
            SHODOW_HOLDING_REGISTER_CONFIG_32 = 1093,
            SHODOW_HOLDING_REGISTER_CONFIG_33 = 1094,
            SHODOW_HOLDING_REGISTER_CONFIG_34 = 1095,
            SHODOW_HOLDING_REGISTER_CONFIG_35 = 1096,
            SHODOW_HOLDING_REGISTER_CONFIG_36 = 1097,
            SHODOW_HOLDING_REGISTER_CONFIG_37 = 1098,
            SHODOW_HOLDING_REGISTER_CONFIG_38 = 1099,
            SHODOW_HOLDING_REGISTER_CONFIG_39 = 1100,
            SHODOW_HOLDING_REGISTER_CONFIG_40 = 1101,
            SHODOW_HOLDING_REGISTER_CONFIG_41 = 1102,
            SHODOW_HOLDING_REGISTER_CONFIG_42 = 1103,
            SHODOW_HOLDING_REGISTER_CONFIG_43 = 1104,
            SHODOW_HOLDING_REGISTER_CONFIG_44 = 1105,
            SHODOW_HOLDING_REGISTER_CONFIG_45 = 1106,
            SHODOW_HOLDING_REGISTER_CONFIG_46 = 1107,
            SHODOW_HOLDING_REGISTER_CONFIG_47 = 1108,
            SHODOW_HOLDING_REGISTER_CONFIG_48 = 1109,
            SHODOW_HOLDING_REGISTER_CONFIG_49 = 1110,
            SHODOW_HOLDING_REGISTER_CONFIG_50 = 1111,
            SHODOW_HOLDING_REGISTER_CONFIG_51 = 1112,
            SHODOW_HOLDING_REGISTER_CONFIG_52 = 1113,
            SHODOW_HOLDING_REGISTER_CONFIG_53 = 1114,
            SHODOW_HOLDING_REGISTER_CONFIG_54 = 1115,
            SHODOW_HOLDING_REGISTER_CONFIG_55 = 1116,
            SHODOW_HOLDING_REGISTER_CONFIG_56 = 1117,
            SHODOW_HOLDING_REGISTER_CONFIG_57 = 1118,
            SHODOW_HOLDING_REGISTER_CONFIG_58 = 1119,
            SHODOW_HOLDING_REGISTER_CONFIG_59 = 1120,
            SHODOW_HOLDING_REGISTER_CONFIG_60 = 1121,
            SHODOW_HOLDING_REGISTER_CONFIG_61 = 1122,
            SHODOW_HOLDING_REGISTER_CONFIG_62 = 1123,
            SHODOW_HOLDING_REGISTER_CONFIG_63 = 1124,
            SHODOW_HOLDING_REGISTER_CONFIG_64 = 1125,
            SHODOW_HOLDING_REGISTER_CONFIG_65 = 1126,
            SHODOW_HOLDING_REGISTER_CONFIG_66 = 1127,
            SHODOW_HOLDING_REGISTER_CONFIG_67 = 1128,
            SHODOW_HOLDING_REGISTER_CONFIG_68 = 1129,
            SHODOW_HOLDING_REGISTER_CONFIG_69 = 1130,
            SHODOW_HOLDING_REGISTER_CONFIG_70 = 1131,
            SHODOW_HOLDING_REGISTER_CONFIG_71 = 1132,
            SHODOW_HOLDING_REGISTER_CONFIG_72 = 1133,
            SHODOW_HOLDING_REGISTER_CONFIG_73 = 1134,
            SHODOW_HOLDING_REGISTER_CONFIG_74 = 1135,
            SHODOW_HOLDING_REGISTER_CONFIG_75 = 1136,
            SHODOW_HOLDING_REGISTER_CONFIG_76 = 1137,
            SHODOW_HOLDING_REGISTER_CONFIG_77 = 1138,
            SHODOW_HOLDING_REGISTER_CONFIG_78 = 1139,
            SHODOW_HOLDING_REGISTER_CONFIG_79 = 1140,
            SHODOW_HOLDING_REGISTER_CONFIG_80 = 1141,
            SHODOW_HOLDING_REGISTER_CONFIG_81 = 1142,
            SHODOW_HOLDING_REGISTER_CONFIG_82 = 1143,
            SHODOW_HOLDING_REGISTER_CONFIG_83 = 1144,
            SHODOW_HOLDING_REGISTER_CONFIG_84 = 1145,
            SHODOW_HOLDING_REGISTER_CONFIG_85 = 1146,
            SHODOW_HOLDING_REGISTER_CONFIG_86 = 1147,
            SHODOW_HOLDING_REGISTER_CONFIG_87 = 1148,
            SHODOW_HOLDING_REGISTER_CONFIG_88 = 1149,
            SHODOW_HOLDING_REGISTER_CONFIG_89 = 1150,
            SHODOW_HOLDING_REGISTER_CONFIG_90 = 1151,
            SHODOW_HOLDING_REGISTER_CONFIG_91 = 1152,
            SHODOW_HOLDING_REGISTER_CONFIG_92 = 1153,
            SHODOW_HOLDING_REGISTER_CONFIG_93 = 1154,
            SHODOW_HOLDING_REGISTER_CONFIG_94 = 1155,
            SHODOW_HOLDING_REGISTER_CONFIG_95 = 1156,
            SHODOW_HOLDING_REGISTER_CONFIG_96 = 1157,
            SHODOW_HOLDING_REGISTER_CONFIG_97 = 1158,
            SHODOW_HOLDING_REGISTER_CONFIG_98 = 1159,
            SHODOW_HOLDING_REGISTER_CONFIG_99 = 1160,
            SHODOW_HOLDING_REGISTER_CONFIG_100 = 1161,
            SHODOW_HOLDING_REGISTER_CONFIG_101 = 1162,
            SHODOW_HOLDING_REGISTER_CONFIG_102 = 1163,
            SHODOW_HOLDING_REGISTER_CONFIG_103 = 1164,
            SHODOW_HOLDING_REGISTER_CONFIG_104 = 1165,
            SHODOW_HOLDING_REGISTER_CONFIG_105 = 1166,
            SHODOW_HOLDING_REGISTER_CONFIG_106 = 1167,
            SHODOW_HOLDING_REGISTER_CONFIG_107 = 1168,
            SHODOW_HOLDING_REGISTER_CONFIG_108 = 1169,
            SHODOW_HOLDING_REGISTER_CONFIG_109 = 1170,
            SHODOW_HOLDING_REGISTER_CONFIG_110 = 1171,
            SHODOW_HOLDING_REGISTER_CONFIG_111 = 1172,
            SHODOW_HOLDING_REGISTER_CONFIG_112 = 1173,
            SHODOW_HOLDING_REGISTER_CONFIG_113 = 1174,
            SHODOW_HOLDING_REGISTER_CONFIG_114 = 1175,
            SHODOW_HOLDING_REGISTER_CONFIG_115 = 1176,
            SHODOW_HOLDING_REGISTER_CONFIG_116 = 1177,
            SHODOW_HOLDING_REGISTER_CONFIG_117 = 1178,
            SHODOW_HOLDING_REGISTER_CONFIG_118 = 1179,
            SHODOW_HOLDING_REGISTER_CONFIG_119 = 1180,
            SHODOW_HOLDING_REGISTER_CONFIG_120 = 1181,
            SHODOW_HOLDING_REGISTER_CONFIG_121 = 1182,
            SHODOW_HOLDING_REGISTER_CONFIG_122 = 1183,
            SHODOW_HOLDING_REGISTER_CONFIG_123 = 1184,
            SHODOW_HOLDING_REGISTER_CONFIG_124 = 1185,
            SHODOW_HOLDING_REGISTER_CONFIG_125 = 1186,
            SHODOW_HOLDING_REGISTER_CONFIG_126 = 1187,
            SHODOW_HOLDING_REGISTER_CONFIG_127 = 1188,
            SHODOW_HOLDING_REGISTER_CONFIG_128 = 1189,
            SHODOW_HOLDING_REGISTER_CONFIG_129 = 1190,
            SHODOW_HOLDING_REGISTER_CONFIG_130 = 1191,
            SHODOW_HOLDING_REGISTER_CONFIG_131 = 1192,
            SHODOW_HOLDING_REGISTER_CONFIG_132 = 1193,
            SHODOW_HOLDING_REGISTER_CONFIG_133 = 1194,
            SHODOW_HOLDING_REGISTER_CONFIG_134 = 1195,
            SHODOW_HOLDING_REGISTER_CONFIG_135 = 1196,
            SHODOW_HOLDING_REGISTER_CONFIG_136 = 1197,
            SHODOW_HOLDING_REGISTER_CONFIG_137 = 1198,
            SHODOW_HOLDING_REGISTER_CONFIG_138 = 1199,
            SHODOW_HOLDING_REGISTER_CONFIG_139 = 1200,
            SHODOW_HOLDING_REGISTER_CONFIG_140 = 1201,
            SHODOW_HOLDING_REGISTER_CONFIG_141 = 1202,
            SHODOW_HOLDING_REGISTER_CONFIG_142 = 1203,
            SHODOW_HOLDING_REGISTER_CONFIG_143 = 1204,
            SHODOW_HOLDING_REGISTER_CONFIG_144 = 1205,
            SHODOW_HOLDING_REGISTER_CONFIG_145 = 1206,
            SHODOW_HOLDING_REGISTER_CONFIG_146 = 1207,
            SHODOW_HOLDING_REGISTER_CONFIG_147 = 1208,
            SHODOW_HOLDING_REGISTER_CONFIG_148 = 1209,
            SHODOW_HOLDING_REGISTER_CONFIG_149 = 1210,
            SHODOW_HOLDING_REGISTER_CONFIG_150 = 1211,
            SHODOW_HOLDING_REGISTER_CONFIG_151 = 1212,
            SHODOW_HOLDING_REGISTER_CONFIG_152 = 1213,
            SHODOW_HOLDING_REGISTER_CONFIG_153 = 1214,
            SHODOW_HOLDING_REGISTER_CONFIG_154 = 1215,
            SHODOW_HOLDING_REGISTER_CONFIG_155 = 1216,
            SHODOW_HOLDING_REGISTER_CONFIG_156 = 1217,
            SHODOW_HOLDING_REGISTER_CONFIG_157 = 1218,
            SHODOW_HOLDING_REGISTER_CONFIG_158 = 1219,
            SHODOW_HOLDING_REGISTER_CONFIG_159 = 1220,
            SHODOW_HOLDING_REGISTER_CONFIG_160 = 1221,
            SHODOW_HOLDING_REGISTER_CONFIG_161 = 1222,
            SHODOW_HOLDING_REGISTER_CONFIG_162 = 1223,
            SHODOW_HOLDING_REGISTER_CONFIG_163 = 1224,
            SHODOW_HOLDING_REGISTER_CONFIG_164 = 1225,
            SHODOW_HOLDING_REGISTER_CONFIG_165 = 1226,
            SHODOW_HOLDING_REGISTER_CONFIG_166 = 1227,
            SHODOW_HOLDING_REGISTER_CONFIG_167 = 1228,
            SHODOW_HOLDING_REGISTER_CONFIG_168 = 1229,
            SHODOW_HOLDING_REGISTER_CONFIG_169 = 1230,
            SHODOW_HOLDING_REGISTER_CONFIG_170 = 1231,
            SHODOW_HOLDING_REGISTER_CONFIG_171 = 1232,
            SHODOW_HOLDING_REGISTER_CONFIG_172 = 1233,
            SHODOW_HOLDING_REGISTER_CONFIG_173 = 1234,
            SHODOW_HOLDING_REGISTER_CONFIG_174 = 1235,
            SHODOW_HOLDING_REGISTER_CONFIG_175 = 1236,
            SHODOW_HOLDING_REGISTER_CONFIG_176 = 1237,
            SHODOW_HOLDING_REGISTER_CONFIG_177 = 1238,
            SHODOW_HOLDING_REGISTER_CONFIG_178 = 1239,
            SHODOW_HOLDING_REGISTER_CONFIG_179 = 1240,
            SHODOW_HOLDING_REGISTER_CONFIG_180 = 1241,
            SHODOW_HOLDING_REGISTER_CONFIG_181 = 1242,
            SHODOW_HOLDING_REGISTER_CONFIG_182 = 1243,
            SHODOW_HOLDING_REGISTER_CONFIG_183 = 1244,
            SHODOW_HOLDING_REGISTER_CONFIG_184 = 1245,
            SHODOW_HOLDING_REGISTER_CONFIG_185 = 1246,
            SHODOW_HOLDING_REGISTER_CONFIG_186 = 1247,
            SHODOW_HOLDING_REGISTER_CONFIG_187 = 1248,
            SHODOW_HOLDING_REGISTER_CONFIG_188 = 1249,
            SHODOW_HOLDING_REGISTER_CONFIG_189 = 1250,
            SHODOW_HOLDING_REGISTER_CONFIG_190 = 1251,
            SHODOW_HOLDING_REGISTER_CONFIG_191 = 1252,
            SHODOW_HOLDING_REGISTER_CONFIG_192 = 1253,
            SHODOW_HOLDING_REGISTER_CONFIG_193 = 1254,
            SHODOW_HOLDING_REGISTER_CONFIG_194 = 1255,
            SHODOW_HOLDING_REGISTER_CONFIG_195 = 1256,
            SHODOW_HOLDING_REGISTER_CONFIG_196 = 1257,
            SHODOW_HOLDING_REGISTER_CONFIG_197 = 1258,
            SHODOW_HOLDING_REGISTER_CONFIG_198 = 1259,
            SHODOW_HOLDING_REGISTER_CONFIG_199 = 1260,
            SHODOW_HOLDING_REGISTER_CONFIG_200 = 1261,
            SHODOW_HOLDING_REGISTER_CONFIG_201 = 1262,
            SHODOW_HOLDING_REGISTER_CONFIG_202 = 1263,
            SHODOW_HOLDING_REGISTER_CONFIG_203 = 1264,
            SHODOW_HOLDING_REGISTER_CONFIG_204 = 1265,
            SHODOW_HOLDING_REGISTER_CONFIG_205 = 1266,
            SHODOW_HOLDING_REGISTER_CONFIG_206 = 1267,
            SHODOW_HOLDING_REGISTER_CONFIG_207 = 1268,
            SHODOW_HOLDING_REGISTER_CONFIG_208 = 1269,
            SHODOW_HOLDING_REGISTER_CONFIG_209 = 1270,
            SHODOW_HOLDING_REGISTER_CONFIG_210 = 1271,
            SHODOW_HOLDING_REGISTER_CONFIG_211 = 1272,
            SHODOW_HOLDING_REGISTER_CONFIG_212 = 1273,
            SHODOW_HOLDING_REGISTER_CONFIG_213 = 1274,
            SHODOW_HOLDING_REGISTER_CONFIG_214 = 1275,
            SHODOW_HOLDING_REGISTER_CONFIG_215 = 1276,
            SHODOW_HOLDING_REGISTER_CONFIG_216 = 1277,
            SHODOW_HOLDING_REGISTER_CONFIG_217 = 1278,
            SHODOW_HOLDING_REGISTER_CONFIG_218 = 1279,
            SHODOW_HOLDING_REGISTER_CONFIG_219 = 1280,
            SHODOW_HOLDING_REGISTER_CONFIG_220 = 1281,
            SHODOW_HOLDING_REGISTER_CONFIG_221 = 1282,
            SHODOW_HOLDING_REGISTER_CONFIG_222 = 1283,
            SHODOW_HOLDING_REGISTER_CONFIG_223 = 1284,
            SHODOW_HOLDING_REGISTER_CONFIG_224 = 1285,
            SHODOW_HOLDING_REGISTER_CONFIG_225 = 1286,
            SHODOW_HOLDING_REGISTER_CONFIG_226 = 1287,
            SHODOW_HOLDING_REGISTER_CONFIG_227 = 1288,
            SHODOW_HOLDING_REGISTER_CONFIG_228 = 1289,
            SHODOW_HOLDING_REGISTER_CONFIG_229 = 1290,
            SHODOW_HOLDING_REGISTER_CONFIG_230 = 1291,
            SHODOW_HOLDING_REGISTER_CONFIG_231 = 1292,
            SHODOW_HOLDING_REGISTER_CONFIG_232 = 1293,
            SHODOW_HOLDING_REGISTER_CONFIG_233 = 1294,
            SHODOW_HOLDING_REGISTER_CONFIG_234 = 1295,
            SHODOW_HOLDING_REGISTER_CONFIG_235 = 1296,
            SHODOW_HOLDING_REGISTER_CONFIG_236 = 1297,
            SHODOW_HOLDING_REGISTER_CONFIG_237 = 1298,
            SHODOW_HOLDING_REGISTER_CONFIG_238 = 1299,
            SHODOW_HOLDING_REGISTER_CONFIG_239 = 1300,
            SHODOW_HOLDING_REGISTER_CONFIG_240 = 1301,
            SHODOW_HOLDING_REGISTER_CONFIG_241 = 1302,
            SHODOW_HOLDING_REGISTER_CONFIG_242 = 1303,
            SHODOW_HOLDING_REGISTER_CONFIG_243 = 1304,
            SHODOW_HOLDING_REGISTER_CONFIG_244 = 1305,
            SHODOW_HOLDING_REGISTER_CONFIG_245 = 1306,
            SHODOW_HOLDING_REGISTER_CONFIG_246 = 1307,
            SHODOW_HOLDING_REGISTER_CONFIG_247 = 1308,
            SHODOW_HOLDING_REGISTER_CONFIG_248 = 1309,
            SHODOW_HOLDING_REGISTER_CONFIG_249 = 1310,
            SHODOW_HOLDING_REGISTER_CONFIG_250 = 1311,
            SHODOW_HOLDING_REGISTER_CONFIG_251 = 1312,
            SHODOW_HOLDING_REGISTER_CONFIG_252 = 1313,
            SHODOW_HOLDING_REGISTER_CONFIG_253 = 1314,
            SHODOW_HOLDING_REGISTER_CONFIG_254 = 1315,
            SHODOW_HOLDING_REGISTER_CONFIG_255 = 1316,
            SHODOW_HOLDING_REGISTER_CONFIG_256 = 1317,
            SHODOW_HOLDING_REGISTER_CONFIG_257 = 1318,
            SHODOW_HOLDING_REGISTER_CONFIG_258 = 1319,
            SHODOW_HOLDING_REGISTER_CONFIG_259 = 1320,
            SHODOW_HOLDING_REGISTER_CONFIG_260 = 1321,
            SHODOW_HOLDING_REGISTER_CONFIG_261 = 1322,
            SHODOW_HOLDING_REGISTER_CONFIG_262 = 1323,
            SHODOW_HOLDING_REGISTER_CONFIG_263 = 1324,
            SHODOW_HOLDING_REGISTER_CONFIG_264 = 1325,
            SHODOW_HOLDING_REGISTER_CONFIG_265 = 1326,
            SHODOW_HOLDING_REGISTER_CONFIG_266 = 1327,
            SHODOW_HOLDING_REGISTER_CONFIG_267 = 1328,
            SHODOW_HOLDING_REGISTER_CONFIG_268 = 1329,
            SHODOW_HOLDING_REGISTER_CONFIG_269 = 1330,
            SHODOW_HOLDING_REGISTER_CONFIG_270 = 1331,
            SHODOW_HOLDING_REGISTER_CONFIG_271 = 1332,
            SHODOW_HOLDING_REGISTER_CONFIG_272 = 1333,
            SHODOW_HOLDING_REGISTER_CONFIG_273 = 1334,
            SHODOW_HOLDING_REGISTER_CONFIG_274 = 1335,
            SHODOW_HOLDING_REGISTER_CONFIG_275 = 1336,
            SHODOW_HOLDING_REGISTER_CONFIG_276 = 1337,
            SHODOW_HOLDING_REGISTER_CONFIG_277 = 1338,
            SHODOW_HOLDING_REGISTER_CONFIG_278 = 1339,
            SHODOW_HOLDING_REGISTER_CONFIG_279 = 1340,
            SHODOW_HOLDING_REGISTER_CONFIG_280 = 1341,
            SHODOW_HOLDING_REGISTER_CONFIG_281 = 1342,
            SHODOW_HOLDING_REGISTER_CONFIG_282 = 1343,
            SHODOW_HOLDING_REGISTER_CONFIG_283 = 1344,
            SHODOW_HOLDING_REGISTER_CONFIG_284 = 1345,
            SHODOW_HOLDING_REGISTER_CONFIG_285 = 1346,
            SHODOW_HOLDING_REGISTER_CONFIG_286 = 1347,
            SHODOW_HOLDING_REGISTER_CONFIG_287 = 1348,
            SHODOW_HOLDING_REGISTER_CONFIG_288 = 1349,
            SHODOW_HOLDING_REGISTER_CONFIG_289 = 1350,
            SHODOW_HOLDING_REGISTER_CONFIG_290 = 1351,
            SHODOW_HOLDING_REGISTER_CONFIG_291 = 1352,
            SHODOW_HOLDING_REGISTER_CONFIG_292 = 1353,
            SHODOW_HOLDING_REGISTER_CONFIG_293 = 1354,
            SHODOW_HOLDING_REGISTER_CONFIG_294 = 1355,
            SHODOW_HOLDING_REGISTER_CONFIG_295 = 1356,
            SHODOW_HOLDING_REGISTER_CONFIG_296 = 1357,
            SHODOW_HOLDING_REGISTER_CONFIG_297 = 1358,
            SHODOW_HOLDING_REGISTER_CONFIG_298 = 1359,
            SHODOW_HOLDING_REGISTER_CONFIG_299 = 1360,
            SHODOW_HOLDING_REGISTER_CONFIG_300 = 1361,
            SHODOW_HOLDING_REGISTER_CONFIG_301 = 1362,
            SHODOW_HOLDING_REGISTER_CONFIG_302 = 1363,
            SHODOW_HOLDING_REGISTER_CONFIG_303 = 1364,
            SHODOW_HOLDING_REGISTER_CONFIG_304 = 1365,
            SHODOW_HOLDING_REGISTER_CONFIG_305 = 1366,
            SHODOW_HOLDING_REGISTER_CONFIG_306 = 1367,
            SHODOW_HOLDING_REGISTER_CONFIG_307 = 1368,
            SHODOW_HOLDING_REGISTER_CONFIG_308 = 1369,
            SHODOW_HOLDING_REGISTER_CONFIG_309 = 1370,
            SHODOW_HOLDING_REGISTER_CONFIG_310 = 1371,
            SHODOW_HOLDING_REGISTER_CONFIG_311 = 1372,
            SHODOW_HOLDING_REGISTER_CONFIG_312 = 1373,
            SHODOW_HOLDING_REGISTER_CONFIG_313 = 1374,
            SHODOW_HOLDING_REGISTER_CONFIG_314 = 1375,
            SHODOW_HOLDING_REGISTER_CONFIG_315 = 1376,
            SHODOW_HOLDING_REGISTER_CONFIG_316 = 1377,
            SHODOW_HOLDING_REGISTER_CONFIG_317 = 1378,
            SHODOW_HOLDING_REGISTER_CONFIG_318 = 1379,
            SHODOW_HOLDING_REGISTER_CONFIG_319 = 1380,
            SHODOW_HOLDING_REGISTER_CONFIG_320 = 1381,
            SHODOW_HOLDING_REGISTER_CONFIG_321 = 1382,
            SHODOW_HOLDING_REGISTER_CONFIG_322 = 1383,
            SHODOW_HOLDING_REGISTER_CONFIG_323 = 1384,
            SHODOW_HOLDING_REGISTER_CONFIG_324 = 1385,
            SHODOW_HOLDING_REGISTER_CONFIG_325 = 1386,
            SHODOW_HOLDING_REGISTER_CONFIG_326 = 1387,
            SHODOW_HOLDING_REGISTER_CONFIG_327 = 1388,
            SHODOW_HOLDING_REGISTER_CONFIG_328 = 1389,
            SHODOW_HOLDING_REGISTER_CONFIG_329 = 1390,
            SHODOW_HOLDING_REGISTER_CONFIG_330 = 1391,
            SHODOW_HOLDING_REGISTER_CONFIG_331 = 1392,
            SHODOW_HOLDING_REGISTER_CONFIG_332 = 1393,
            SHODOW_HOLDING_REGISTER_CONFIG_333 = 1394,
            SHODOW_HOLDING_REGISTER_CONFIG_334 = 1395,
            SHODOW_HOLDING_REGISTER_CONFIG_335 = 1396,
            SHODOW_HOLDING_REGISTER_CONFIG_336 = 1397,
            SHODOW_HOLDING_REGISTER_CONFIG_337 = 1398,
            SHODOW_HOLDING_REGISTER_CONFIG_338 = 1399,
            SHODOW_HOLDING_REGISTER_CONFIG_339 = 1400,
            SHODOW_HOLDING_REGISTER_CONFIG_340 = 1401,
            SHODOW_HOLDING_REGISTER_CONFIG_341 = 1402,
            SHODOW_HOLDING_REGISTER_CONFIG_342 = 1403,
            SHODOW_HOLDING_REGISTER_CONFIG_343 = 1404,
            SHODOW_HOLDING_REGISTER_CONFIG_344 = 1405,
            SHODOW_HOLDING_REGISTER_CONFIG_345 = 1406,
            SHODOW_HOLDING_REGISTER_CONFIG_346 = 1407,
            SHODOW_HOLDING_REGISTER_CONFIG_347 = 1408,
            SHODOW_HOLDING_REGISTER_CONFIG_348 = 1409,
            SHODOW_HOLDING_REGISTER_CONFIG_349 = 1410,
            SHODOW_HOLDING_REGISTER_CONFIG_350 = 1411,
            SHODOW_HOLDING_REGISTER_CONFIG_351 = 1412,
            SHODOW_HOLDING_REGISTER_CONFIG_352 = 1413,
            SHODOW_HOLDING_REGISTER_CONFIG_353 = 1414,
            SHODOW_HOLDING_REGISTER_CONFIG_354 = 1415,
            SHODOW_HOLDING_REGISTER_CONFIG_355 = 1416,
            SHODOW_HOLDING_REGISTER_CONFIG_356 = 1417,
            SHODOW_HOLDING_REGISTER_CONFIG_357 = 1418,
            SHODOW_HOLDING_REGISTER_CONFIG_358 = 1419,
            SHODOW_HOLDING_REGISTER_CONFIG_359 = 1420,
            SHODOW_HOLDING_REGISTER_CONFIG_360 = 1421,
            SHODOW_HOLDING_REGISTER_CONFIG_361 = 1422,
            SHODOW_HOLDING_REGISTER_CONFIG_362 = 1423,
            SHODOW_HOLDING_REGISTER_CONFIG_363 = 1424,
            SHODOW_HOLDING_REGISTER_CONFIG_364 = 1425,
            SHODOW_HOLDING_REGISTER_CONFIG_365 = 1426,
            SHODOW_HOLDING_REGISTER_CONFIG_366 = 1427,
            SHODOW_HOLDING_REGISTER_CONFIG_367 = 1428,
            SHODOW_HOLDING_REGISTER_CONFIG_368 = 1429,
            SHODOW_HOLDING_REGISTER_CONFIG_369 = 1430,
            SHODOW_HOLDING_REGISTER_CONFIG_370 = 1431,
            SHODOW_HOLDING_REGISTER_CONFIG_371 = 1432,
            SHODOW_HOLDING_REGISTER_CONFIG_372 = 1433,
            SHODOW_HOLDING_REGISTER_CONFIG_373 = 1434,
            SHODOW_HOLDING_REGISTER_CONFIG_374 = 1435,
            SHODOW_HOLDING_REGISTER_CONFIG_375 = 1436,
            SHODOW_HOLDING_REGISTER_CONFIG_376 = 1437,
            SHODOW_HOLDING_REGISTER_CONFIG_377 = 1438,
            SHODOW_HOLDING_REGISTER_CONFIG_378 = 1439,
            SHODOW_HOLDING_REGISTER_CONFIG_379 = 1440,
            SHODOW_HOLDING_REGISTER_CONFIG_380 = 1441,
            SHODOW_HOLDING_REGISTER_CONFIG_381 = 1442,
            SHODOW_HOLDING_REGISTER_CONFIG_382 = 1443,
            SHODOW_HOLDING_REGISTER_CONFIG_383 = 1444,
            SHODOW_HOLDING_REGISTER_CONFIG_384 = 1445,
            SHODOW_HOLDING_REGISTER_CONFIG_385 = 1446,
            SHODOW_HOLDING_REGISTER_CONFIG_386 = 1447,
            SHODOW_HOLDING_REGISTER_CONFIG_387 = 1448,
            SHODOW_HOLDING_REGISTER_CONFIG_388 = 1449,
            SHODOW_HOLDING_REGISTER_CONFIG_389 = 1450,
            SHODOW_HOLDING_REGISTER_CONFIG_390 = 1451,
            SHODOW_HOLDING_REGISTER_CONFIG_391 = 1452,
            SHODOW_HOLDING_REGISTER_CONFIG_392 = 1453,
            SHODOW_HOLDING_REGISTER_CONFIG_393 = 1454,
            SHODOW_HOLDING_REGISTER_CONFIG_394 = 1455,
            SHODOW_HOLDING_REGISTER_CONFIG_395 = 1456,
            SHODOW_HOLDING_REGISTER_CONFIG_396 = 1457,
            SHODOW_HOLDING_REGISTER_CONFIG_397 = 1458,
            SHODOW_HOLDING_REGISTER_CONFIG_398 = 1459,
            SHODOW_HOLDING_REGISTER_CONFIG_399 = 1460,
            SHODOW_HOLDING_REGISTER_CONFIG_400 = 1461,
            SHODOW_HOLDING_REGISTER_CONFIG_401 = 1462,
            SHODOW_HOLDING_REGISTER_CONFIG_402 = 1463,
            SHODOW_HOLDING_REGISTER_CONFIG_403 = 1464,
            SHODOW_HOLDING_REGISTER_CONFIG_404 = 1465,
            SHODOW_HOLDING_REGISTER_CONFIG_405 = 1466,
            SHODOW_HOLDING_REGISTER_CONFIG_406 = 1467,
            SHODOW_HOLDING_REGISTER_CONFIG_407 = 1468,
            SHODOW_HOLDING_REGISTER_CONFIG_408 = 1469,
            SHODOW_HOLDING_REGISTER_CONFIG_409 = 1470,
            SHODOW_HOLDING_REGISTER_CONFIG_410 = 1471,
            SHODOW_HOLDING_REGISTER_CONFIG_411 = 1472,
            SHODOW_HOLDING_REGISTER_CONFIG_412 = 1473,
            SHODOW_HOLDING_REGISTER_CONFIG_413 = 1474,
            SHODOW_HOLDING_REGISTER_CONFIG_414 = 1475,
            SHODOW_HOLDING_REGISTER_CONFIG_415 = 1476,
            SHODOW_HOLDING_REGISTER_CONFIG_416 = 1477,
            SHODOW_HOLDING_REGISTER_CONFIG_417 = 1478,
            SHODOW_HOLDING_REGISTER_CONFIG_418 = 1479,
            SHODOW_HOLDING_REGISTER_CONFIG_419 = 1480,
            SHODOW_HOLDING_REGISTER_CONFIG_420 = 1481,
            SHODOW_HOLDING_REGISTER_CONFIG_421 = 1482,
            SHODOW_HOLDING_REGISTER_CONFIG_422 = 1483,
            SHODOW_HOLDING_REGISTER_CONFIG_423 = 1484,
            SHODOW_HOLDING_REGISTER_CONFIG_424 = 1485,
            SHODOW_HOLDING_REGISTER_CONFIG_425 = 1486,
            SHODOW_HOLDING_REGISTER_CONFIG_426 = 1487,
            SHODOW_HOLDING_REGISTER_CONFIG_427 = 1488,
            SHODOW_HOLDING_REGISTER_CONFIG_428 = 1489,
            SHODOW_HOLDING_REGISTER_CONFIG_429 = 1490,
            SHODOW_HOLDING_REGISTER_CONFIG_430 = 1491,
            SHODOW_HOLDING_REGISTER_CONFIG_431 = 1492,
            SHODOW_HOLDING_REGISTER_CONFIG_432 = 1493,
            SHODOW_HOLDING_REGISTER_CONFIG_433 = 1494,
            SHODOW_HOLDING_REGISTER_CONFIG_434 = 1495,
            SHODOW_HOLDING_REGISTER_CONFIG_435 = 1496,
            SHODOW_HOLDING_REGISTER_CONFIG_436 = 1497,
            SHODOW_HOLDING_REGISTER_CONFIG_437 = 1498,
            SHODOW_HOLDING_REGISTER_CONFIG_438 = 1499,
            SHODOW_HOLDING_REGISTER_CONFIG_439 = 1500,
            SHODOW_HOLDING_REGISTER_CONFIG_440 = 1501,
            SHODOW_HOLDING_REGISTER_CONFIG_441 = 1502,
            SHODOW_HOLDING_REGISTER_CONFIG_442 = 1503,
            SHODOW_HOLDING_REGISTER_CONFIG_443 = 1504,
            SHODOW_HOLDING_REGISTER_CONFIG_444 = 1505,
            SHODOW_HOLDING_REGISTER_CONFIG_445 = 1506,
            SHODOW_HOLDING_REGISTER_CONFIG_446 = 1507,
            SHODOW_HOLDING_REGISTER_CONFIG_447 = 1508,
            SHODOW_HOLDING_REGISTER_CONFIG_448 = 1509,
            SHODOW_HOLDING_REGISTER_CONFIG_449 = 1510,
            SHODOW_HOLDING_REGISTER_CONFIG_450 = 1511,
            SHODOW_HOLDING_REGISTER_CONFIG_451 = 1512,
            SHODOW_HOLDING_REGISTER_CONFIG_452 = 1513,
            SHODOW_HOLDING_REGISTER_CONFIG_453 = 1514,
            SHODOW_HOLDING_REGISTER_CONFIG_454 = 1515,
            SHODOW_HOLDING_REGISTER_CONFIG_455 = 1516,
            SHODOW_HOLDING_REGISTER_CONFIG_456 = 1517,
            SHODOW_HOLDING_REGISTER_CONFIG_457 = 1518,
            SHODOW_HOLDING_REGISTER_CONFIG_458 = 1519,
            SHODOW_HOLDING_REGISTER_CONFIG_459 = 1520,
            SHODOW_HOLDING_REGISTER_CONFIG_460 = 1521,
            SHODOW_HOLDING_REGISTER_CONFIG_461 = 1522,
            SHODOW_HOLDING_REGISTER_CONFIG_462 = 1523,
            SHODOW_HOLDING_REGISTER_CONFIG_463 = 1524,
            SHODOW_HOLDING_REGISTER_CONFIG_464 = 1525,
            SHODOW_HOLDING_REGISTER_CONFIG_465 = 1526,
            SHODOW_HOLDING_REGISTER_CONFIG_466 = 1527,
            SHODOW_HOLDING_REGISTER_CONFIG_467 = 1528,
            SHODOW_HOLDING_REGISTER_CONFIG_468 = 1529,
            SHODOW_HOLDING_REGISTER_CONFIG_469 = 1530,
            SHODOW_HOLDING_REGISTER_CONFIG_470 = 1531,
            SHODOW_HOLDING_REGISTER_CONFIG_471 = 1532,
            SHODOW_HOLDING_REGISTER_CONFIG_472 = 1533,
            SHODOW_HOLDING_REGISTER_CONFIG_473 = 1534,
            SHODOW_HOLDING_REGISTER_CONFIG_474 = 1535,
            SHODOW_HOLDING_REGISTER_CONFIG_475 = 1536,
            SHODOW_HOLDING_REGISTER_CONFIG_476 = 1537,
            SHODOW_HOLDING_REGISTER_CONFIG_477 = 1538,
            SHODOW_HOLDING_REGISTER_CONFIG_478 = 1539,
            SHODOW_HOLDING_REGISTER_CONFIG_479 = 1540,
            SHODOW_HOLDING_REGISTER_CONFIG_480 = 1541,
            SHODOW_HOLDING_REGISTER_CONFIG_481 = 1542,
            SHODOW_HOLDING_REGISTER_CONFIG_482 = 1543,
            SHODOW_HOLDING_REGISTER_CONFIG_483 = 1544,
            SHODOW_HOLDING_REGISTER_CONFIG_484 = 1545,
            SHODOW_HOLDING_REGISTER_CONFIG_485 = 1546,
            SHODOW_HOLDING_REGISTER_CONFIG_486 = 1547,
            SHODOW_HOLDING_REGISTER_CONFIG_487 = 1548,
            SHODOW_HOLDING_REGISTER_CONFIG_488 = 1549,
            SHODOW_HOLDING_REGISTER_CONFIG_489 = 1550,
            SHODOW_HOLDING_REGISTER_CONFIG_490 = 1551,
            SHODOW_HOLDING_REGISTER_CONFIG_491 = 1552,
            SHODOW_HOLDING_REGISTER_CONFIG_492 = 1553,
            SHODOW_HOLDING_REGISTER_CONFIG_493 = 1554,
            SHODOW_HOLDING_REGISTER_CONFIG_494 = 1555,
            SHODOW_HOLDING_REGISTER_CONFIG_495 = 1556,
            SHODOW_HOLDING_REGISTER_CONFIG_496 = 1557,
            SHODOW_HOLDING_REGISTER_CONFIG_497 = 1558,
            SHODOW_HOLDING_REGISTER_CONFIG_498 = 1559,
            SHODOW_HOLDING_REGISTER_CONFIG_499 = 1560,
            SHODOW_HOLDING_REGISTER_CONFIG_500 = 1561,
            SHODOW_HOLDING_REGISTER_CONFIG_501 = 1562,
            SHODOW_HOLDING_REGISTER_CONFIG_502 = 1563,
            SHODOW_HOLDING_REGISTER_CONFIG_503 = 1564,
            SHODOW_HOLDING_REGISTER_CONFIG_504 = 1565,
            SHODOW_HOLDING_REGISTER_CONFIG_505 = 1566,
            SHODOW_HOLDING_REGISTER_CONFIG_506 = 1567,
            SHODOW_HOLDING_REGISTER_CONFIG_507 = 1568,
            SHODOW_HOLDING_REGISTER_CONFIG_508 = 1569,
            SHODOW_HOLDING_REGISTER_CONFIG_509 = 1570,
            SHODOW_HOLDING_REGISTER_CONFIG_510 = 1571,
            SHODOW_HOLDING_REGISTER_CONFIG_511 = 1572,
            SHODOW_HOLDING_REGISTER_CONFIG_512 = 1573,
            SHODOW_HOLDING_REGISTER_CONFIG_513 = 1574,
            SHODOW_HOLDING_REGISTER_CONFIG_514 = 1575,
            SHODOW_HOLDING_REGISTER_CONFIG_515 = 1576,
            SHODOW_HOLDING_REGISTER_CONFIG_516 = 1577,
            SHODOW_HOLDING_REGISTER_CONFIG_517 = 1578,
            SHODOW_HOLDING_REGISTER_CONFIG_518 = 1579,
            SHODOW_HOLDING_REGISTER_CONFIG_519 = 1580,
            SHODOW_HOLDING_REGISTER_CONFIG_520 = 1581,
            SHODOW_HOLDING_REGISTER_CONFIG_521 = 1582,
            SHODOW_HOLDING_REGISTER_CONFIG_522 = 1583,
            SHODOW_HOLDING_REGISTER_CONFIG_523 = 1584,
            SHODOW_HOLDING_REGISTER_CONFIG_524 = 1585,
            SHODOW_HOLDING_REGISTER_CONFIG_525 = 1586,
            SHODOW_HOLDING_REGISTER_CONFIG_526 = 1587,
            SHODOW_HOLDING_REGISTER_CONFIG_527 = 1588,
            SHODOW_HOLDING_REGISTER_CONFIG_528 = 1589,
            SHODOW_HOLDING_REGISTER_CONFIG_529 = 1590,
            SHODOW_HOLDING_REGISTER_CONFIG_530 = 1591,
            SHODOW_HOLDING_REGISTER_CONFIG_531 = 1592,
            SHODOW_HOLDING_REGISTER_CONFIG_532 = 1593,
            SHODOW_HOLDING_REGISTER_CONFIG_533 = 1594,
            SHODOW_HOLDING_REGISTER_CONFIG_534 = 1595,
            SHODOW_HOLDING_REGISTER_CONFIG_535 = 1596,
            SHODOW_HOLDING_REGISTER_CONFIG_536 = 1597,
            SHODOW_HOLDING_REGISTER_CONFIG_537 = 1598,
            SHODOW_HOLDING_REGISTER_CONFIG_538 = 1599,
            SHODOW_HOLDING_REGISTER_CONFIG_539 = 1600,
            SHODOW_HOLDING_REGISTER_CONFIG_540 = 1601,
            SHODOW_HOLDING_REGISTER_CONFIG_541 = 1602,
            SHODOW_HOLDING_REGISTER_CONFIG_542 = 1603,
            SHODOW_HOLDING_REGISTER_CONFIG_543 = 1604,
            SHODOW_HOLDING_REGISTER_CONFIG_544 = 1605,
            SHODOW_HOLDING_REGISTER_CONFIG_545 = 1606,
            SHODOW_HOLDING_REGISTER_CONFIG_546 = 1607,
            SHODOW_HOLDING_REGISTER_CONFIG_547 = 1608,
            SHODOW_HOLDING_REGISTER_CONFIG_548 = 1609,
            SHODOW_HOLDING_REGISTER_CONFIG_549 = 1610,
            SHODOW_HOLDING_REGISTER_CONFIG_550 = 1611,
            SHODOW_HOLDING_REGISTER_CONFIG_551 = 1612,
            SHODOW_HOLDING_REGISTER_CONFIG_552 = 1613,
            SHODOW_HOLDING_REGISTER_CONFIG_553 = 1614,
            SHODOW_HOLDING_REGISTER_CONFIG_554 = 1615,
            SHODOW_HOLDING_REGISTER_CONFIG_555 = 1616,
            SHODOW_HOLDING_REGISTER_CONFIG_556 = 1617,
            SHODOW_HOLDING_REGISTER_CONFIG_557 = 1618,
            SHODOW_HOLDING_REGISTER_CONFIG_558 = 1619,
            SHODOW_HOLDING_REGISTER_CONFIG_559 = 1620,
            SHODOW_HOLDING_REGISTER_CONFIG_560 = 1621,
            SHODOW_HOLDING_REGISTER_CONFIG_561 = 1622,
            SHODOW_HOLDING_REGISTER_CONFIG_562 = 1623,
            SHODOW_HOLDING_REGISTER_CONFIG_563 = 1624,
            SHODOW_HOLDING_REGISTER_CONFIG_564 = 1625,
            SHODOW_HOLDING_REGISTER_CONFIG_565 = 1626,
            SHODOW_HOLDING_REGISTER_CONFIG_566 = 1627,
            SHODOW_HOLDING_REGISTER_CONFIG_567 = 1628,
            SHODOW_HOLDING_REGISTER_CONFIG_568 = 1629,
            SHODOW_HOLDING_REGISTER_CONFIG_569 = 1630,
            SHODOW_HOLDING_REGISTER_CONFIG_570 = 1631,
            SHODOW_HOLDING_REGISTER_CONFIG_571 = 1632,
            SHODOW_HOLDING_REGISTER_CONFIG_572 = 1633,
            SHODOW_HOLDING_REGISTER_CONFIG_573 = 1634,
            SHODOW_HOLDING_REGISTER_CONFIG_574 = 1635,
            SHODOW_HOLDING_REGISTER_CONFIG_575 = 1636,
            SHODOW_HOLDING_REGISTER_CONFIG_576 = 1637,
            SHODOW_HOLDING_REGISTER_CONFIG_577 = 1638,
            SHODOW_HOLDING_REGISTER_CONFIG_578 = 1639,
            SHODOW_HOLDING_REGISTER_CONFIG_579 = 1640,
            SHODOW_HOLDING_REGISTER_CONFIG_580 = 1641,
            SHODOW_HOLDING_REGISTER_CONFIG_581 = 1642,
            SHODOW_HOLDING_REGISTER_CONFIG_582 = 1643,
            SHODOW_HOLDING_REGISTER_CONFIG_583 = 1644,
            SHODOW_HOLDING_REGISTER_CONFIG_584 = 1645,
            SHODOW_HOLDING_REGISTER_CONFIG_585 = 1646,
            SHODOW_HOLDING_REGISTER_CONFIG_586 = 1647,
            SHODOW_HOLDING_REGISTER_CONFIG_587 = 1648,
            SHODOW_HOLDING_REGISTER_CONFIG_588 = 1649,
            SHODOW_HOLDING_REGISTER_CONFIG_589 = 1650,
            SHODOW_HOLDING_REGISTER_CONFIG_590 = 1651,
            SHODOW_HOLDING_REGISTER_CONFIG_591 = 1652,
            SHODOW_HOLDING_REGISTER_CONFIG_592 = 1653,
            SHODOW_HOLDING_REGISTER_CONFIG_593 = 1654,
            SHODOW_HOLDING_REGISTER_CONFIG_594 = 1655,
            SHODOW_HOLDING_REGISTER_CONFIG_595 = 1656,
            SHODOW_HOLDING_REGISTER_CONFIG_596 = 1657,
            SHODOW_HOLDING_REGISTER_CONFIG_597 = 1658,
            SHODOW_HOLDING_REGISTER_CONFIG_598 = 1659,
            SHODOW_HOLDING_REGISTER_CONFIG_599 = 1660,
            SHODOW_HOLDING_REGISTER_CONFIG_600 = 1661,
            SHODOW_HOLDING_REGISTER_CONFIG_601 = 1662,
            SHODOW_HOLDING_REGISTER_CONFIG_602 = 1663,
            SHODOW_HOLDING_REGISTER_CONFIG_603 = 1664,
            SHODOW_HOLDING_REGISTER_CONFIG_604 = 1665,
            SHODOW_HOLDING_REGISTER_CONFIG_605 = 1666,
            SHODOW_HOLDING_REGISTER_CONFIG_606 = 1667,
            SHODOW_HOLDING_REGISTER_CONFIG_607 = 1668,
            SHODOW_HOLDING_REGISTER_CONFIG_608 = 1669,
            SHODOW_HOLDING_REGISTER_CONFIG_609 = 1670,
            SHODOW_HOLDING_REGISTER_CONFIG_610 = 1671,
            SHODOW_HOLDING_REGISTER_CONFIG_611 = 1672,
            SHODOW_HOLDING_REGISTER_CONFIG_612 = 1673,
            SHODOW_HOLDING_REGISTER_CONFIG_613 = 1674,
            SHODOW_HOLDING_REGISTER_CONFIG_614 = 1675,
            SHODOW_HOLDING_REGISTER_CONFIG_615 = 1676,
            SHODOW_HOLDING_REGISTER_CONFIG_616 = 1677,
            SHODOW_HOLDING_REGISTER_CONFIG_617 = 1678,
            SHODOW_HOLDING_REGISTER_CONFIG_618 = 1679,
            SHODOW_HOLDING_REGISTER_CONFIG_619 = 1680,
            SHODOW_HOLDING_REGISTER_CONFIG_620 = 1681,
            SHODOW_HOLDING_REGISTER_CONFIG_621 = 1682,
            SHODOW_HOLDING_REGISTER_CONFIG_622 = 1683,
            SHODOW_HOLDING_REGISTER_CONFIG_623 = 1684,
            SHODOW_HOLDING_REGISTER_CONFIG_624 = 1685,
            SHODOW_HOLDING_REGISTER_CONFIG_625 = 1686,
            SHODOW_HOLDING_REGISTER_CONFIG_626 = 1687,
            SHODOW_HOLDING_REGISTER_CONFIG_627 = 1688,
            SHODOW_HOLDING_REGISTER_CONFIG_628 = 1689,
            SHODOW_HOLDING_REGISTER_CONFIG_629 = 1690,
            SHODOW_HOLDING_REGISTER_CONFIG_630 = 1691,
            SHODOW_HOLDING_REGISTER_CONFIG_631 = 1692,
            SHODOW_HOLDING_REGISTER_CONFIG_632 = 1693,
            SHODOW_HOLDING_REGISTER_CONFIG_633 = 1694,
            SHODOW_HOLDING_REGISTER_CONFIG_634 = 1695,
            SHODOW_HOLDING_REGISTER_CONFIG_635 = 1696,
            SHODOW_HOLDING_REGISTER_CONFIG_636 = 1697,
            SHODOW_HOLDING_REGISTER_CONFIG_637 = 1698,
            SHODOW_HOLDING_REGISTER_CONFIG_638 = 1699,
            SHODOW_HOLDING_REGISTER_CONFIG_639 = 1700,
            SHODOW_HOLDING_REGISTER_CONFIG_640 = 1701,
            SHODOW_HOLDING_REGISTER_CONFIG_641 = 1702,
            SHODOW_HOLDING_REGISTER_CONFIG_642 = 1703,
            SHODOW_HOLDING_REGISTER_CONFIG_643 = 1704,
            SHODOW_HOLDING_REGISTER_CONFIG_644 = 1705,
            SHODOW_HOLDING_REGISTER_CONFIG_645 = 1706,
            SHODOW_HOLDING_REGISTER_CONFIG_646 = 1707,
            SHODOW_HOLDING_REGISTER_CONFIG_647 = 1708,
            SHODOW_HOLDING_REGISTER_CONFIG_648 = 1709,
            SHODOW_HOLDING_REGISTER_CONFIG_649 = 1710,
            SHODOW_HOLDING_REGISTER_CONFIG_650 = 1711,
            SHODOW_HOLDING_REGISTER_CONFIG_651 = 1712,
            SHODOW_HOLDING_REGISTER_CONFIG_652 = 1713,
            SHODOW_HOLDING_REGISTER_CONFIG_653 = 1714,
            SHODOW_HOLDING_REGISTER_CONFIG_654 = 1715,
            SHODOW_HOLDING_REGISTER_CONFIG_655 = 1716,
            SHODOW_HOLDING_REGISTER_CONFIG_656 = 1717,
            SHODOW_HOLDING_REGISTER_CONFIG_657 = 1718,
            SHODOW_HOLDING_REGISTER_CONFIG_658 = 1719,
            SHODOW_HOLDING_REGISTER_CONFIG_659 = 1720,
            SHODOW_HOLDING_REGISTER_CONFIG_660 = 1721,
            SHODOW_HOLDING_REGISTER_CONFIG_661 = 1722,
            SHODOW_HOLDING_REGISTER_CONFIG_662 = 1723,
            SHODOW_HOLDING_REGISTER_CONFIG_663 = 1724,
            SHODOW_HOLDING_REGISTER_CONFIG_664 = 1725,
            SHODOW_HOLDING_REGISTER_CONFIG_665 = 1726,
            SHODOW_HOLDING_REGISTER_CONFIG_666 = 1727,
            SHODOW_HOLDING_REGISTER_CONFIG_667 = 1728,
            SHODOW_HOLDING_REGISTER_CONFIG_668 = 1729,
            SHODOW_HOLDING_REGISTER_CONFIG_669 = 1730,
            SHODOW_HOLDING_REGISTER_CONFIG_670 = 1731,
            SHODOW_HOLDING_REGISTER_CONFIG_671 = 1732,
            SHODOW_HOLDING_REGISTER_CONFIG_672 = 1733,
            SHODOW_HOLDING_REGISTER_CONFIG_673 = 1734,
            SHODOW_HOLDING_REGISTER_CONFIG_674 = 1735,
            SHODOW_HOLDING_REGISTER_CONFIG_675 = 1736,
            SHODOW_HOLDING_REGISTER_CONFIG_676 = 1737,
            SHODOW_HOLDING_REGISTER_CONFIG_677 = 1738,
            SHODOW_HOLDING_REGISTER_CONFIG_678 = 1739,
            SHODOW_HOLDING_REGISTER_CONFIG_679 = 1740,
            SHODOW_HOLDING_REGISTER_CONFIG_680 = 1741,
            SHODOW_HOLDING_REGISTER_CONFIG_681 = 1742,
            SHODOW_HOLDING_REGISTER_CONFIG_682 = 1743,
            SHODOW_HOLDING_REGISTER_CONFIG_683 = 1744,
            SHODOW_HOLDING_REGISTER_CONFIG_684 = 1745,
            SHODOW_HOLDING_REGISTER_CONFIG_685 = 1746,
            SHODOW_HOLDING_REGISTER_CONFIG_686 = 1747,
            SHODOW_HOLDING_REGISTER_CONFIG_687 = 1748,
            SHODOW_HOLDING_REGISTER_CONFIG_688 = 1749,
            SHODOW_HOLDING_REGISTER_CONFIG_689 = 1750,
            SHODOW_HOLDING_REGISTER_CONFIG_690 = 1751,
            SHODOW_HOLDING_REGISTER_CONFIG_691 = 1752,
            SHODOW_HOLDING_REGISTER_CONFIG_692 = 1753,
            SHODOW_HOLDING_REGISTER_CONFIG_693 = 1754,
            SHODOW_HOLDING_REGISTER_CONFIG_694 = 1755,
            SHODOW_HOLDING_REGISTER_CONFIG_695 = 1756,
            SHODOW_HOLDING_REGISTER_CONFIG_696 = 1757,
            SHODOW_HOLDING_REGISTER_CONFIG_697 = 1758,
            SHODOW_HOLDING_REGISTER_CONFIG_698 = 1759,
            SHODOW_HOLDING_REGISTER_CONFIG_699 = 1760,
            SHODOW_HOLDING_REGISTER_CONFIG_700 = 1761,
            SHODOW_HOLDING_REGISTER_CONFIG_701 = 1762,
            SHODOW_HOLDING_REGISTER_CONFIG_702 = 1763,
            SHODOW_HOLDING_REGISTER_CONFIG_703 = 1764,
            SHODOW_HOLDING_REGISTER_CONFIG_704 = 1765,
            SHODOW_HOLDING_REGISTER_CONFIG_705 = 1766,
            SHODOW_HOLDING_REGISTER_CONFIG_706 = 1767,
            SHODOW_HOLDING_REGISTER_CONFIG_707 = 1768,
            SHODOW_HOLDING_REGISTER_CONFIG_708 = 1769,
            SHODOW_HOLDING_REGISTER_CONFIG_709 = 1770,
            SHODOW_HOLDING_REGISTER_CONFIG_710 = 1771,
            SHODOW_HOLDING_REGISTER_CONFIG_711 = 1772,
            SHODOW_HOLDING_REGISTER_CONFIG_712 = 1773,
            SHODOW_HOLDING_REGISTER_CONFIG_713 = 1774,
            SHODOW_HOLDING_REGISTER_CONFIG_714 = 1775,
            SHODOW_HOLDING_REGISTER_CONFIG_715 = 1776,
            SHODOW_HOLDING_REGISTER_CONFIG_716 = 1777,
            SHODOW_HOLDING_REGISTER_CONFIG_717 = 1778,
            SHODOW_HOLDING_REGISTER_CONFIG_718 = 1779,
            SHODOW_HOLDING_REGISTER_CONFIG_719 = 1780,
            SHODOW_HOLDING_REGISTER_CONFIG_720 = 1781,
            SHODOW_HOLDING_REGISTER_CONFIG_721 = 1782,
            SHODOW_HOLDING_REGISTER_CONFIG_722 = 1783,
            SHODOW_HOLDING_REGISTER_CONFIG_723 = 1784,
            SHODOW_HOLDING_REGISTER_CONFIG_724 = 1785,
            SHODOW_HOLDING_REGISTER_CONFIG_725 = 1786,
            SHODOW_HOLDING_REGISTER_CONFIG_726 = 1787,
            SHODOW_HOLDING_REGISTER_CONFIG_727 = 1788,
            SHODOW_HOLDING_REGISTER_CONFIG_728 = 1789,
            SHODOW_HOLDING_REGISTER_CONFIG_729 = 1790,
            SHODOW_HOLDING_REGISTER_CONFIG_730 = 1791,
            SHODOW_HOLDING_REGISTER_CONFIG_731 = 1792,
            SHODOW_HOLDING_REGISTER_CONFIG_732 = 1793,
            SHODOW_HOLDING_REGISTER_CONFIG_733 = 1794,
            SHODOW_HOLDING_REGISTER_CONFIG_734 = 1795,
            SHODOW_HOLDING_REGISTER_CONFIG_735 = 1796,
            SHODOW_HOLDING_REGISTER_CONFIG_736 = 1797,
            SHODOW_HOLDING_REGISTER_CONFIG_737 = 1798,
            SHODOW_HOLDING_REGISTER_CONFIG_738 = 1799,
            SHODOW_HOLDING_REGISTER_CONFIG_739 = 1800,
            SHODOW_HOLDING_REGISTER_CONFIG_740 = 1801,
            SHODOW_HOLDING_REGISTER_CONFIG_741 = 1802,
            SHODOW_HOLDING_REGISTER_CONFIG_742 = 1803,
            SHODOW_HOLDING_REGISTER_CONFIG_743 = 1804,
            SHODOW_HOLDING_REGISTER_CONFIG_744 = 1805,
            SHODOW_HOLDING_REGISTER_CONFIG_745 = 1806,
            SHODOW_HOLDING_REGISTER_CONFIG_746 = 1807,
            SHODOW_HOLDING_REGISTER_CONFIG_747 = 1808,
            SHODOW_HOLDING_REGISTER_CONFIG_748 = 1809,
            SHODOW_HOLDING_REGISTER_CONFIG_749 = 1810,
            SHODOW_HOLDING_REGISTER_CONFIG_750 = 1811,
            SHODOW_HOLDING_REGISTER_CONFIG_751 = 1812,
            SHODOW_HOLDING_REGISTER_CONFIG_752 = 1813,
            SHODOW_HOLDING_REGISTER_CONFIG_753 = 1814,
            SHODOW_HOLDING_REGISTER_CONFIG_754 = 1815,
            SHODOW_HOLDING_REGISTER_CONFIG_755 = 1816,
            SHODOW_HOLDING_REGISTER_CONFIG_756 = 1817,
            SHODOW_HOLDING_REGISTER_CONFIG_757 = 1818,
            SHODOW_HOLDING_REGISTER_CONFIG_758 = 1819,
            SHODOW_HOLDING_REGISTER_CONFIG_759 = 1820,
            SHODOW_HOLDING_REGISTER_CONFIG_760 = 1821,
            SHODOW_HOLDING_REGISTER_CONFIG_761 = 1822,
            SHODOW_HOLDING_REGISTER_CONFIG_762 = 1823,
            SHODOW_HOLDING_REGISTER_CONFIG_763 = 1824,
            SHODOW_HOLDING_REGISTER_CONFIG_764 = 1825,
            SHODOW_HOLDING_REGISTER_CONFIG_765 = 1826,
            SHODOW_HOLDING_REGISTER_CONFIG_766 = 1827,
            SHODOW_HOLDING_REGISTER_CONFIG_767 = 1828,
            SHODOW_HOLDING_REGISTER_CONFIG_768 = 1829,
            SHODOW_HOLDING_REGISTER_CONFIG_769 = 1830,
            SHODOW_HOLDING_REGISTER_CONFIG_770 = 1831,
            SHODOW_HOLDING_REGISTER_CONFIG_771 = 1832,
            SHODOW_HOLDING_REGISTER_CONFIG_772 = 1833,
            SHODOW_HOLDING_REGISTER_CONFIG_773 = 1834,
            SHODOW_HOLDING_REGISTER_CONFIG_774 = 1835,
            SHODOW_HOLDING_REGISTER_CONFIG_775 = 1836,
            SHODOW_HOLDING_REGISTER_CONFIG_776 = 1837,
            SHODOW_HOLDING_REGISTER_CONFIG_777 = 1838,
            SHODOW_HOLDING_REGISTER_CONFIG_778 = 1839,
            SHODOW_HOLDING_REGISTER_CONFIG_779 = 1840,
            SHODOW_HOLDING_REGISTER_CONFIG_780 = 1841,
            SHODOW_HOLDING_REGISTER_CONFIG_781 = 1842,
            SHODOW_HOLDING_REGISTER_CONFIG_782 = 1843,
            SHODOW_HOLDING_REGISTER_CONFIG_783 = 1844,
            SHODOW_HOLDING_REGISTER_CONFIG_784 = 1845,
            SHODOW_HOLDING_REGISTER_CONFIG_785 = 1846,
            SHODOW_HOLDING_REGISTER_CONFIG_786 = 1847,
            SHODOW_HOLDING_REGISTER_CONFIG_787 = 1848,
            SHODOW_HOLDING_REGISTER_CONFIG_788 = 1849,
            SHODOW_HOLDING_REGISTER_CONFIG_789 = 1850,
            SHODOW_HOLDING_REGISTER_CONFIG_790 = 1851,
            SHODOW_HOLDING_REGISTER_CONFIG_791 = 1852,
            SHODOW_HOLDING_REGISTER_CONFIG_792 = 1853,
            SHODOW_HOLDING_REGISTER_CONFIG_793 = 1854,
            SHODOW_HOLDING_REGISTER_CONFIG_794 = 1855,
            SHODOW_HOLDING_REGISTER_CONFIG_795 = 1856,
            SHODOW_HOLDING_REGISTER_CONFIG_796 = 1857,
            SHODOW_HOLDING_REGISTER_CONFIG_797 = 1858,
            SHODOW_HOLDING_REGISTER_CONFIG_798 = 1859,
            SHODOW_HOLDING_REGISTER_CONFIG_799 = 1860,
            SHODOW_HOLDING_REGISTER_CONFIG_800 = 1861,
            SHODOW_HOLDING_REGISTER_CONFIG_801 = 1862,
            SHODOW_HOLDING_REGISTER_CONFIG_802 = 1863,
            SHODOW_HOLDING_REGISTER_CONFIG_803 = 1864,
            SHODOW_HOLDING_REGISTER_CONFIG_804 = 1865,
            SHODOW_HOLDING_REGISTER_CONFIG_805 = 1866,
            SHODOW_HOLDING_REGISTER_CONFIG_806 = 1867,
            SHODOW_HOLDING_REGISTER_CONFIG_807 = 1868,
            SHODOW_HOLDING_REGISTER_CONFIG_808 = 1869,
            SHODOW_HOLDING_REGISTER_CONFIG_809 = 1870,
            SHODOW_HOLDING_REGISTER_CONFIG_810 = 1871,
            SHODOW_HOLDING_REGISTER_CONFIG_811 = 1872,
            SHODOW_HOLDING_REGISTER_CONFIG_812 = 1873,
            SHODOW_HOLDING_REGISTER_CONFIG_813 = 1874,
            SHODOW_HOLDING_REGISTER_CONFIG_814 = 1875,
            SHODOW_HOLDING_REGISTER_CONFIG_815 = 1876,
            SHODOW_HOLDING_REGISTER_CONFIG_816 = 1877,
            SHODOW_HOLDING_REGISTER_CONFIG_817 = 1878,
            SHODOW_HOLDING_REGISTER_CONFIG_818 = 1879,
            SHODOW_HOLDING_REGISTER_CONFIG_819 = 1880,
            SHODOW_HOLDING_REGISTER_CONFIG_820 = 1881,
            SHODOW_HOLDING_REGISTER_CONFIG_821 = 1882,
            SHODOW_HOLDING_REGISTER_CONFIG_822 = 1883,
            SHODOW_HOLDING_REGISTER_CONFIG_823 = 1884,
            SHODOW_HOLDING_REGISTER_CONFIG_824 = 1885,
            SHODOW_HOLDING_REGISTER_CONFIG_825 = 1886,
            SHODOW_HOLDING_REGISTER_CONFIG_826 = 1887,
            SHODOW_HOLDING_REGISTER_CONFIG_827 = 1888,
            SHODOW_HOLDING_REGISTER_CONFIG_828 = 1889,
            SHODOW_HOLDING_REGISTER_CONFIG_829 = 1890,
            SHODOW_HOLDING_REGISTER_CONFIG_830 = 1891,
            SHODOW_HOLDING_REGISTER_CONFIG_831 = 1892,
            SHODOW_HOLDING_REGISTER_CONFIG_832 = 1893,
            SHODOW_HOLDING_REGISTER_CONFIG_833 = 1894,
            SHODOW_HOLDING_REGISTER_CONFIG_834 = 1895,
            SHODOW_HOLDING_REGISTER_CONFIG_835 = 1896,
            SHODOW_HOLDING_REGISTER_CONFIG_836 = 1897,
            SHODOW_HOLDING_REGISTER_CONFIG_837 = 1898,
            SHODOW_HOLDING_REGISTER_CONFIG_838 = 1899,
            SHODOW_HOLDING_REGISTER_CONFIG_839 = 1900,
            SHODOW_HOLDING_REGISTER_CONFIG_840 = 1901,
            SHODOW_HOLDING_REGISTER_CONFIG_841 = 1902,
            SHODOW_HOLDING_REGISTER_CONFIG_842 = 1903,
            SHODOW_HOLDING_REGISTER_CONFIG_843 = 1904,
            SHODOW_HOLDING_REGISTER_CONFIG_844 = 1905,
            SHODOW_HOLDING_REGISTER_CONFIG_845 = 1906,
            SHODOW_HOLDING_REGISTER_CONFIG_846 = 1907,
            SHODOW_HOLDING_REGISTER_CONFIG_847 = 1908,
            SHODOW_HOLDING_REGISTER_CONFIG_848 = 1909,
            SHODOW_HOLDING_REGISTER_CONFIG_849 = 1910,
            SHODOW_HOLDING_REGISTER_CONFIG_850 = 1911,
            SHODOW_HOLDING_REGISTER_CONFIG_851 = 1912,
            SHODOW_HOLDING_REGISTER_CONFIG_852 = 1913,
            SHODOW_HOLDING_REGISTER_CONFIG_853 = 1914,
            SHODOW_HOLDING_REGISTER_CONFIG_854 = 1915,
            SHODOW_HOLDING_REGISTER_CONFIG_855 = 1916,
            SHODOW_HOLDING_REGISTER_CONFIG_856 = 1917,
            SHODOW_HOLDING_REGISTER_CONFIG_857 = 1918,
            SHODOW_HOLDING_REGISTER_CONFIG_858 = 1919,
            SHODOW_HOLDING_REGISTER_CONFIG_859 = 1920,
            SHODOW_HOLDING_REGISTER_CONFIG_860 = 1921,
            SHODOW_HOLDING_REGISTER_CONFIG_861 = 1922,
            SHODOW_HOLDING_REGISTER_CONFIG_862 = 1923,
            SHODOW_HOLDING_REGISTER_CONFIG_863 = 1924,
            SHODOW_HOLDING_REGISTER_CONFIG_864 = 1925,
            SHODOW_HOLDING_REGISTER_CONFIG_865 = 1926,
            SHODOW_HOLDING_REGISTER_CONFIG_866 = 1927,
            SHODOW_HOLDING_REGISTER_CONFIG_867 = 1928,
            SHODOW_HOLDING_REGISTER_CONFIG_868 = 1929,
            SHODOW_HOLDING_REGISTER_CONFIG_869 = 1930,
            SHODOW_HOLDING_REGISTER_CONFIG_870 = 1931,
            SHODOW_HOLDING_REGISTER_CONFIG_871 = 1932,
            SHODOW_HOLDING_REGISTER_CONFIG_872 = 1933,
            SHODOW_HOLDING_REGISTER_CONFIG_873 = 1934,
            SHODOW_HOLDING_REGISTER_CONFIG_874 = 1935,
            SHODOW_HOLDING_REGISTER_CONFIG_875 = 1936,
            SHODOW_HOLDING_REGISTER_CONFIG_876 = 1937,
            SHODOW_HOLDING_REGISTER_CONFIG_877 = 1938,
            SHODOW_HOLDING_REGISTER_CONFIG_878 = 1939,
            SHODOW_HOLDING_REGISTER_CONFIG_879 = 1940,
            SHODOW_HOLDING_REGISTER_CONFIG_880 = 1941,
            SHODOW_HOLDING_REGISTER_CONFIG_881 = 1942,
            SHODOW_HOLDING_REGISTER_CONFIG_882 = 1943,
            SHODOW_HOLDING_REGISTER_CONFIG_883 = 1944,
            SHODOW_HOLDING_REGISTER_CONFIG_884 = 1945,
            SHODOW_HOLDING_REGISTER_CONFIG_885 = 1946,
            SHODOW_HOLDING_REGISTER_CONFIG_886 = 1947,
            SHODOW_HOLDING_REGISTER_CONFIG_887 = 1948,
            SHODOW_HOLDING_REGISTER_CONFIG_888 = 1949,
            SHODOW_HOLDING_REGISTER_CONFIG_889 = 1950,
            SHODOW_HOLDING_REGISTER_CONFIG_890 = 1951,
            SHODOW_HOLDING_REGISTER_CONFIG_891 = 1952,
            SHODOW_HOLDING_REGISTER_CONFIG_892 = 1953,
            SHODOW_HOLDING_REGISTER_CONFIG_893 = 1954,
            SHODOW_HOLDING_REGISTER_CONFIG_894 = 1955,
            SHODOW_HOLDING_REGISTER_CONFIG_895 = 1956,
            SHODOW_HOLDING_REGISTER_CONFIG_896 = 1957,
            SHODOW_HOLDING_REGISTER_CONFIG_897 = 1958,
            SHODOW_HOLDING_REGISTER_CONFIG_898 = 1959,
            SHODOW_HOLDING_REGISTER_CONFIG_899 = 1960,
            SHODOW_HOLDING_REGISTER_CONFIG_900 = 1961,
            SHODOW_HOLDING_REGISTER_CONFIG_901 = 1962,
            SHODOW_HOLDING_REGISTER_CONFIG_902 = 1963,
            SHODOW_HOLDING_REGISTER_CONFIG_903 = 1964,
            SHODOW_HOLDING_REGISTER_CONFIG_904 = 1965,
            SHODOW_HOLDING_REGISTER_CONFIG_905 = 1966,
            SHODOW_HOLDING_REGISTER_CONFIG_906 = 1967,
            SHODOW_HOLDING_REGISTER_CONFIG_907 = 1968,
            SHODOW_HOLDING_REGISTER_CONFIG_908 = 1969,
            SHODOW_HOLDING_REGISTER_CONFIG_909 = 1970,
            SHODOW_HOLDING_REGISTER_CONFIG_910 = 1971,
            SHODOW_HOLDING_REGISTER_CONFIG_911 = 1972,
            SHODOW_HOLDING_REGISTER_CONFIG_912 = 1973,
            SHODOW_HOLDING_REGISTER_CONFIG_913 = 1974,
            SHODOW_HOLDING_REGISTER_CONFIG_914 = 1975,
            SHODOW_HOLDING_REGISTER_CONFIG_915 = 1976,
            SHODOW_HOLDING_REGISTER_CONFIG_916 = 1977,
            SHODOW_HOLDING_REGISTER_CONFIG_917 = 1978,
            SHODOW_HOLDING_REGISTER_CONFIG_918 = 1979,
            SHODOW_HOLDING_REGISTER_CONFIG_919 = 1980,
            SHODOW_HOLDING_REGISTER_CONFIG_920 = 1981,
            SHODOW_HOLDING_REGISTER_CONFIG_921 = 1982,
            SHODOW_HOLDING_REGISTER_CONFIG_922 = 1983,
            SHODOW_HOLDING_REGISTER_CONFIG_923 = 1984,
            SHODOW_HOLDING_REGISTER_CONFIG_924 = 1985,
            SHODOW_HOLDING_REGISTER_CONFIG_925 = 1986,
            SHODOW_HOLDING_REGISTER_CONFIG_926 = 1987,
            SHODOW_HOLDING_REGISTER_CONFIG_927 = 1988,
            SHODOW_HOLDING_REGISTER_CONFIG_928 = 1989,
            SHODOW_HOLDING_REGISTER_CONFIG_929 = 1990,
            SHODOW_HOLDING_REGISTER_CONFIG_930 = 1991,
            SHODOW_HOLDING_REGISTER_CONFIG_931 = 1992,
            SHODOW_HOLDING_REGISTER_CONFIG_932 = 1993,
            SHODOW_HOLDING_REGISTER_CONFIG_933 = 1994,
            SHODOW_HOLDING_REGISTER_CONFIG_934 = 1995,
            SHODOW_HOLDING_REGISTER_CONFIG_935 = 1996,
            SHODOW_HOLDING_REGISTER_CONFIG_936 = 1997,
            SHODOW_HOLDING_REGISTER_CONFIG_937 = 1998,
            SHODOW_HOLDING_REGISTER_CONFIG_938 = 1999,
            SHODOW_HOLDING_REGISTER_CONFIG_939 = 2000,
            SHODOW_HOLDING_REGISTER_CONFIG_940 = 2001,
            SHODOW_HOLDING_REGISTER_CONFIG_941 = 2002,
            SHODOW_HOLDING_REGISTER_CONFIG_942 = 2003,
            SHODOW_HOLDING_REGISTER_CONFIG_943 = 2004,
            SHODOW_HOLDING_REGISTER_CONFIG_944 = 2005,
            SHODOW_HOLDING_REGISTER_CONFIG_945 = 2006,
            SHODOW_HOLDING_REGISTER_CONFIG_946 = 2007,
            SHODOW_HOLDING_REGISTER_CONFIG_947 = 2008,
            SHODOW_HOLDING_REGISTER_CONFIG_948 = 2009,
            SHODOW_HOLDING_REGISTER_CONFIG_949 = 2010,
            SHODOW_HOLDING_REGISTER_CONFIG_950 = 2011,
            SHODOW_HOLDING_REGISTER_CONFIG_951 = 2012,
            SHODOW_HOLDING_REGISTER_CONFIG_952 = 2013,
            SHODOW_HOLDING_REGISTER_CONFIG_953 = 2014,
            SHODOW_HOLDING_REGISTER_CONFIG_954 = 2015,
            SHODOW_HOLDING_REGISTER_CONFIG_955 = 2016,
            SHODOW_HOLDING_REGISTER_CONFIG_956 = 2017,
            SHODOW_HOLDING_REGISTER_CONFIG_957 = 2018,
            SHODOW_HOLDING_REGISTER_CONFIG_958 = 2019,
            SHODOW_HOLDING_REGISTER_CONFIG_959 = 2020,
            SHODOW_HOLDING_REGISTER_CONFIG_960 = 2021,
            SHODOW_HOLDING_REGISTER_CONFIG_961 = 2022,
            SHODOW_HOLDING_REGISTER_CONFIG_962 = 2023,
            SHODOW_HOLDING_REGISTER_CONFIG_963 = 2024,
            SHODOW_HOLDING_REGISTER_CONFIG_964 = 2025,
            SHODOW_HOLDING_REGISTER_CONFIG_965 = 2026,
            SHODOW_HOLDING_REGISTER_CONFIG_966 = 2027,
            SHODOW_HOLDING_REGISTER_CONFIG_967 = 2028,
            SHODOW_HOLDING_REGISTER_CONFIG_968 = 2029,
            SHODOW_HOLDING_REGISTER_CONFIG_969 = 2030,
            SHODOW_HOLDING_REGISTER_CONFIG_970 = 2031,
            SHODOW_HOLDING_REGISTER_CONFIG_971 = 2032,
            SHODOW_HOLDING_REGISTER_CONFIG_972 = 2033,
            SHODOW_HOLDING_REGISTER_CONFIG_973 = 2034,
            SHODOW_HOLDING_REGISTER_CONFIG_974 = 2035,
            SHODOW_HOLDING_REGISTER_CONFIG_975 = 2036,
            SHODOW_HOLDING_REGISTER_CONFIG_976 = 2037,
            SHODOW_HOLDING_REGISTER_CONFIG_977 = 2038,
            SHODOW_HOLDING_REGISTER_CONFIG_978 = 2039,
            SHODOW_HOLDING_REGISTER_CONFIG_979 = 2040,
            SHODOW_HOLDING_REGISTER_CONFIG_980 = 2041,
            SHODOW_HOLDING_REGISTER_CONFIG_981 = 2042,
            SHODOW_HOLDING_REGISTER_CONFIG_982 = 2043,
            SHODOW_HOLDING_REGISTER_CONFIG_983 = 2044,
            SHODOW_HOLDING_REGISTER_CONFIG_984 = 2045,
            SHODOW_HOLDING_REGISTER_CONFIG_985 = 2046,
            SHODOW_HOLDING_REGISTER_CONFIG_986 = 2047,
            SHODOW_HOLDING_REGISTER_CONFIG_987 = 2048,
            SHODOW_HOLDING_REGISTER_CONFIG_988 = 2049,
            SHODOW_HOLDING_REGISTER_CONFIG_989 = 2050,
            SHODOW_HOLDING_REGISTER_CONFIG_990 = 2051,
            SHODOW_HOLDING_REGISTER_CONFIG_991 = 2052,
            SHODOW_HOLDING_REGISTER_CONFIG_992 = 2053,
            SHODOW_HOLDING_REGISTER_CONFIG_993 = 2054,
            SHODOW_HOLDING_REGISTER_CONFIG_994 = 2055,
            SHODOW_HOLDING_REGISTER_CONFIG_995 = 2056,
            SHODOW_HOLDING_REGISTER_CONFIG_996 = 2057,
            SHODOW_HOLDING_REGISTER_CONFIG_997 = 2058,
            SHODOW_HOLDING_REGISTER_CONFIG_998 = 2059,
            SHODOW_HOLDING_REGISTER_CONFIG_999 = 2060,
            SLAVE_ID = 2061,
            IDENTIFY_STATUS = 2062,
            STREAMING_ENABLE_CMD = 2063,
            STREAMING_DISABLE_CMD = 2064,
            DOWN_STREAM_BAUDRATE = 2065,
            UP_STREAM_RECEIVED_FRAME_QTY = 2066,
            UP_STREAM_RECEIVED_FRAME_MISMATCH_ID_QTY = 2067,
            UP_STREAM_RECEIVED_FRAME_BROADCAST_QTY = 2068,
            UP_STREAM_RECEIVED_FRAME_ERROR_QTY = 2069,
            UP_STREAM_SEND_FRAME_QTY = 2070,
            UP_STREAM_ENQUEUED_FRAME_QTY = 2071,
            UP_STREAM_ENQUEUE_FAILED_FRAME_QTY = 2072,
            UP_STREAM_RECEIVED_FRAME_HANDLE_EXECUTION_TIME_US = 2073,
            UP_STREAM_RECEIVED_FRAME_MEMORY_MAP_HANDLER_EXECUTION_TIME_US = 2074,
            UP_STREAM_RECEIVED_FRAME_MISMATCH_ID_HANDLER_EXECUTION_TIME_US = 2075,
            UP_STREAM_RECEIVED_FRAME_BROADCAST_HANDLER_EXECUTION_TIME_US = 2076,
            UP_STREAM_RECEIVED_FRAME_TRANSACTION_DONE_HANDLER_EXECUTION_TIME_US = 2077,
            UP_STREAM_RECEIVED_FRAME_ERROR_HANDLER_EXECUTION_TIME_US = 2078,
            UP_STREAM_SEND_FRAME_HANDLE_EXECUTION_TIME_US = 2079,
            UP_STREAM_DELAY_BETWEEN_FRAME_US = 2080,
            STREAMER_ENABLE = 2081,
            STREAMER_EXTENDED_HEADER_ENABLE = 2082,
            STREAMER_INTERNAL_CLOCK_INTERVAL_MS = 2083,
            STREAMER_PRESCALER = 2084,
            STREAMER_PARAMETER_IDS_0 = 2085,
            STREAMER_PARAMETER_IDS_1 = 2086,
            STREAMER_PARAMETER_IDS_2 = 2087,
            STREAMER_PARAMETER_IDS_3 = 2088,
            STREAMER_PARAMETER_IDS_4 = 2089,
            STREAMER_PARAMETER_IDS_5 = 2090,
            STREAMER_PARAMETER_IDS_6 = 2091,
            STREAMER_PARAMETER_IDS_7 = 2092,
            STREAMER_PARAMETER_IDS_8 = 2093,
            STREAMER_PARAMETER_IDS_9 = 2094,
            STREAMER_PARAMETER_IDS_10 = 2095,
            STREAMER_PARAMETER_IDS_11 = 2096,
            STREAMER_PARAMETER_IDS_12 = 2097,
            STREAMER_PARAMETER_IDS_13 = 2098,
            STREAMER_PARAMETER_IDS_14 = 2099,
            STREAMER_PARAMETER_IDS_15 = 2100,
            STREAMER_PARAMETER_IDS_16 = 2101,
            STREAMER_PARAMETER_IDS_17 = 2102,
            STREAMER_PARAMETER_IDS_18 = 2103,
            STREAMER_PARAMETER_IDS_19 = 2104,
            STREAMER_PARAMETER_IDS_20 = 2105,
            STREAMER_PARAMETER_IDS_21 = 2106,
            STREAMER_PARAMETER_IDS_22 = 2107,
            STREAMER_PARAMETER_IDS_23 = 2108,
            STREAMER_PARAMETER_IDS_24 = 2109,
            STREAMER_PARAMETER_IDS_25 = 2110,
            STREAMER_PARAMETER_IDS_26 = 2111,
            STREAMER_PARAMETER_IDS_27 = 2112,
            STREAMER_PARAMETER_IDS_28 = 2113,
            STREAMER_PARAMETER_IDS_29 = 2114,
            STREAMER_PARAMETER_IDS_30 = 2115,
            STREAMER_PARAMETER_IDS_31 = 2116,
            STREAMER_PARAMETER_IDS_32 = 2117,
            STREAMER_PARAMETER_IDS_33 = 2118,
            STREAMER_PARAMETER_IDS_34 = 2119,
            STREAMER_PARAMETER_IDS_35 = 2120,
            STREAMER_PARAMETER_IDS_36 = 2121,
            STREAMER_PARAMETER_IDS_37 = 2122,
            STREAMER_PARAMETER_IDS_38 = 2123,
            STREAMER_PARAMETER_IDS_39 = 2124,
            STREAMER_PARAMETER_IDS_40 = 2125,
            STREAMER_PARAMETER_IDS_41 = 2126,
            STREAMER_PARAMETER_IDS_42 = 2127,
            STREAMER_PARAMETER_IDS_43 = 2128,
            STREAMER_PARAMETER_IDS_44 = 2129,
            STREAMER_PARAMETER_IDS_45 = 2130,
            STREAMER_PARAMETER_IDS_46 = 2131,
            STREAMER_PARAMETER_IDS_47 = 2132,
            STREAMER_PARAMETER_IDS_48 = 2133,
            STREAMER_PARAMETER_IDS_49 = 2134,
            STREAMER_PARAMETER_IDS_50 = 2135,
            STREAMER_PARAMETER_IDS_51 = 2136,
            STREAMER_PARAMETER_IDS_52 = 2137,
            STREAMER_PARAMETER_IDS_53 = 2138,
            STREAMER_PARAMETER_IDS_54 = 2139,
            STREAMER_PARAMETER_IDS_55 = 2140,
            STREAMER_PARAMETER_IDS_56 = 2141,
            STREAMER_PARAMETER_IDS_57 = 2142,
            STREAMER_PARAMETER_IDS_58 = 2143,
            STREAMER_PARAMETER_IDS_59 = 2144,
            STREAMER_PARAMETER_IDS_60 = 2145,
            STREAMER_PARAMETER_IDS_61 = 2146,
            STREAMER_PARAMETER_IDS_62 = 2147,
            STREAMER_PARAMETER_IDS_63 = 2148,
            STREAMER_PARAMETER_IDS_64 = 2149,
            STREAMER_PARAMETER_IDS_65 = 2150,
            STREAMER_PARAMETER_IDS_66 = 2151,
            STREAMER_PARAMETER_IDS_67 = 2152,
            STREAMER_PARAMETER_IDS_68 = 2153,
            STREAMER_PARAMETER_IDS_69 = 2154,
            STREAMER_PARAMETER_IDS_70 = 2155,
            STREAMER_PARAMETER_IDS_71 = 2156,
            STREAMER_PARAMETER_IDS_72 = 2157,
            STREAMER_PARAMETER_IDS_73 = 2158,
            STREAMER_PARAMETER_IDS_74 = 2159,
            STREAMER_PARAMETER_IDS_75 = 2160,
            STREAMER_PARAMETER_IDS_76 = 2161,
            STREAMER_PARAMETER_IDS_77 = 2162,
            STREAMER_PARAMETER_IDS_78 = 2163,
            STREAMER_PARAMETER_IDS_79 = 2164,
            STREAMER_PARAMETER_IDS_80 = 2165,
            STREAMER_PARAMETER_IDS_81 = 2166,
            STREAMER_PARAMETER_IDS_82 = 2167,
            STREAMER_PARAMETER_IDS_83 = 2168,
            STREAMER_PARAMETER_IDS_84 = 2169,
            STREAMER_PARAMETER_IDS_85 = 2170,
            STREAMER_PARAMETER_IDS_86 = 2171,
            STREAMER_PARAMETER_IDS_87 = 2172,
            STREAMER_PARAMETER_IDS_88 = 2173,
            STREAMER_PARAMETER_IDS_89 = 2174,
            STREAMER_PARAMETER_IDS_90 = 2175,
            STREAMER_PARAMETER_IDS_91 = 2176,
            STREAMER_PARAMETER_IDS_92 = 2177,
            STREAMER_PARAMETER_IDS_93 = 2178,
            STREAMER_PARAMETER_IDS_94 = 2179,
            STREAMER_PARAMETER_IDS_95 = 2180,
            STREAMER_PARAMETER_IDS_96 = 2181,
            STREAMER_PARAMETER_IDS_97 = 2182,
            STREAMER_PARAMETER_IDS_98 = 2183,
            STREAMER_PARAMETER_IDS_99 = 2184,
            STREAMER_PARAMETER_IDS_100 = 2185,
            STREAMER_PARAMETER_IDS_101 = 2186,
            STREAMER_PARAMETER_IDS_102 = 2187,
            STREAMER_PARAMETER_IDS_103 = 2188,
            STREAMER_PARAMETER_IDS_104 = 2189,
            STREAMER_PARAMETER_IDS_105 = 2190,
            STREAMER_PARAMETER_IDS_106 = 2191,
            STREAMER_PARAMETER_IDS_107 = 2192,
            STREAMER_PARAMETER_IDS_108 = 2193,
            STREAMER_PARAMETER_IDS_109 = 2194,
            STREAMER_PARAMETER_IDS_110 = 2195,
            STREAMER_PARAMETER_IDS_111 = 2196,
            STREAMER_PARAMETER_IDS_112 = 2197,
            STREAMER_PARAMETER_IDS_113 = 2198,
            STREAMER_PARAMETER_IDS_114 = 2199,
            STREAMER_PARAMETER_IDS_115 = 2200,
            STREAMER_PARAMETER_IDS_116 = 2201,
            STREAMER_PARAMETER_IDS_117 = 2202,
            STREAMER_PARAMETER_IDS_118 = 2203,
            STREAMER_PARAMETER_IDS_119 = 2204,
            STREAMER_PARAMETER_IDS_120 = 2205,
            STREAMER_PARAMETER_IDS_121 = 2206,
            STREAMER_PARAMETER_IDS_122 = 2207,
            STREAMER_PARAMETER_IDS_123 = 2208,
            STREAMER_PARAMETER_IDS_124 = 2209,
            STREAMER_PARAMETER_IDS_125 = 2210,
            STREAMER_PARAMETER_IDS_126 = 2211,
            STREAMER_PARAMETER_IDS_127 = 2212,
            STREAMER_PARAMETER_IDS_128 = 2213,
            STREAMER_PARAMETER_IDS_129 = 2214,
            STREAMER_PARAMETER_IDS_130 = 2215,
            STREAMER_PARAMETER_IDS_131 = 2216,
            STREAMER_PARAMETER_IDS_132 = 2217,
            STREAMER_PARAMETER_IDS_133 = 2218,
            STREAMER_PARAMETER_IDS_134 = 2219,
            STREAMER_PARAMETER_IDS_135 = 2220,
            STREAMER_PARAMETER_IDS_136 = 2221,
            STREAMER_PARAMETER_IDS_137 = 2222,
            STREAMER_PARAMETER_IDS_138 = 2223,
            STREAMER_PARAMETER_IDS_139 = 2224,
            STREAMER_PARAMETER_IDS_140 = 2225,
            STREAMER_PARAMETER_IDS_141 = 2226,
            STREAMER_PARAMETER_IDS_142 = 2227,
            STREAMER_PARAMETER_IDS_143 = 2228,
            STREAMER_PARAMETER_IDS_144 = 2229,
            STREAMER_PARAMETER_IDS_145 = 2230,
            STREAMER_PARAMETER_IDS_146 = 2231,
            STREAMER_PARAMETER_IDS_147 = 2232,
            STREAMER_PARAMETER_IDS_148 = 2233,
            STREAMER_PARAMETER_IDS_149 = 2234,
            STREAMER_PARAMETER_IDS_150 = 2235,
            STREAMER_PARAMETER_IDS_151 = 2236,
            STREAMER_PARAMETER_IDS_152 = 2237,
            STREAMER_PARAMETER_IDS_153 = 2238,
            STREAMER_PARAMETER_IDS_154 = 2239,
            STREAMER_PARAMETER_IDS_155 = 2240,
            STREAMER_PARAMETER_IDS_156 = 2241,
            STREAMER_PARAMETER_IDS_157 = 2242,
            STREAMER_PARAMETER_IDS_158 = 2243,
            STREAMER_PARAMETER_IDS_159 = 2244,
            STREAMER_PARAMETER_IDS_160 = 2245,
            STREAMER_PARAMETER_IDS_161 = 2246,
            STREAMER_PARAMETER_IDS_162 = 2247,
            STREAMER_PARAMETER_IDS_163 = 2248,
            STREAMER_PARAMETER_IDS_164 = 2249,
            STREAMER_PARAMETER_IDS_165 = 2250,
            STREAMER_PARAMETER_IDS_166 = 2251,
            STREAMER_PARAMETER_IDS_167 = 2252,
            STREAMER_PARAMETER_IDS_168 = 2253,
            STREAMER_PARAMETER_IDS_169 = 2254,
            STREAMER_PARAMETER_IDS_170 = 2255,
            STREAMER_PARAMETER_IDS_171 = 2256,
            STREAMER_PARAMETER_IDS_172 = 2257,
            STREAMER_PARAMETER_IDS_173 = 2258,
            STREAMER_PARAMETER_IDS_174 = 2259,
            STREAMER_PARAMETER_IDS_175 = 2260,
            STREAMER_PARAMETER_IDS_176 = 2261,
            STREAMER_PARAMETER_IDS_177 = 2262,
            STREAMER_PARAMETER_IDS_178 = 2263,
            STREAMER_PARAMETER_IDS_179 = 2264,
            STREAMER_PARAMETER_IDS_180 = 2265,
            STREAMER_PARAMETER_IDS_181 = 2266,
            STREAMER_PARAMETER_IDS_182 = 2267,
            STREAMER_PARAMETER_IDS_183 = 2268,
            STREAMER_PARAMETER_IDS_184 = 2269,
            STREAMER_PARAMETER_IDS_185 = 2270,
            STREAMER_PARAMETER_IDS_186 = 2271,
            STREAMER_PARAMETER_IDS_187 = 2272,
            STREAMER_PARAMETER_IDS_188 = 2273,
            STREAMER_PARAMETER_IDS_189 = 2274,
            STREAMER_PARAMETER_IDS_190 = 2275,
            STREAMER_PARAMETER_IDS_191 = 2276,
            STREAMER_PARAMETER_IDS_192 = 2277,
            STREAMER_PARAMETER_IDS_193 = 2278,
            STREAMER_PARAMETER_IDS_194 = 2279,
            STREAMER_PARAMETER_IDS_195 = 2280,
            STREAMER_PARAMETER_IDS_196 = 2281,
            STREAMER_PARAMETER_IDS_197 = 2282,
            STREAMER_PARAMETER_IDS_198 = 2283,
            STREAMER_PARAMETER_IDS_199 = 2284,
            STREAMER_INTERVAL_US = 2285,
            STREAMER_FRAME_COUNTER = 2286,
            STREAMER_PARAMETER_QTY = 2287,
            STREAMER_FRAME_GENERATION_EXECUTION_TIME_US = 2288,
            BOARD_STARTUP_DELAY_MS = 2289,
            BOARD_STARTUP_RETRY_QTY = 2290,
            BOARD_STARTUP_RETRY_DELAY_MS = 2291,
            BOARD_STARTUP_REPORT_OVERALL_RESULT = 2292,
            BOARD_STARTUP_REPORT_EXECUTION_TIME_US = 2293,
            BOARD_STARTUP_REPORT_BMI088_GYRO_0_CONNECTION_RESULT = 2294,
            BOARD_STARTUP_REPORT_BMI088_GYRO_0_CONNECTION_RETRY = 2295,
            BOARD_STARTUP_REPORT_BMI088_GYRO_0_CONNECTION_TIME_US = 2296,
            BOARD_STARTUP_REPORT_BMI088_GYRO_0_CONFIG_RESULT = 2297,
            BOARD_STARTUP_REPORT_BMI088_GYRO_0_CONFIG_RETRY = 2298,
            BOARD_STARTUP_REPORT_BMI088_GYRO_0_CONFIG_TIME_US = 2299,
            BOARD_STARTUP_REPORT_BMI088_GYRO_1_CONNECTION_RESULT = 2300,
            BOARD_STARTUP_REPORT_BMI088_GYRO_1_CONNECTION_RETRY = 2301,
            BOARD_STARTUP_REPORT_BMI088_GYRO_1_CONNECTION_TIME_US = 2302,
            BOARD_STARTUP_REPORT_BMI088_GYRO_1_CONFIG_RESULT = 2303,
            BOARD_STARTUP_REPORT_BMI088_GYRO_1_CONFIG_RETRY = 2304,
            BOARD_STARTUP_REPORT_BMI088_GYRO_1_CONFIG_TIME_US = 2305,
            BOARD_STARTUP_REPORT_BMI088_GYRO_2_CONNECTION_RESULT = 2306,
            BOARD_STARTUP_REPORT_BMI088_GYRO_2_CONNECTION_RETRY = 2307,
            BOARD_STARTUP_REPORT_BMI088_GYRO_2_CONNECTION_TIME_US = 2308,
            BOARD_STARTUP_REPORT_BMI088_GYRO_2_CONFIG_RESULT = 2309,
            BOARD_STARTUP_REPORT_BMI088_GYRO_2_CONFIG_RETRY = 2310,
            BOARD_STARTUP_REPORT_BMI088_GYRO_2_CONFIG_TIME_US = 2311,
            BOARD_STARTUP_REPORT_BMI088_GYRO_3_CONNECTION_RESULT = 2312,
            BOARD_STARTUP_REPORT_BMI088_GYRO_3_CONNECTION_RETRY = 2313,
            BOARD_STARTUP_REPORT_BMI088_GYRO_3_CONNECTION_TIME_US = 2314,
            BOARD_STARTUP_REPORT_BMI088_GYRO_3_CONFIG_RESULT = 2315,
            BOARD_STARTUP_REPORT_BMI088_GYRO_3_CONFIG_RETRY = 2316,
            BOARD_STARTUP_REPORT_BMI088_GYRO_3_CONFIG_TIME_US = 2317,
            BOARD_STARTUP_REPORT_BMI088_ACC_0_CONNECTION_RESULT = 2318,
            BOARD_STARTUP_REPORT_BMI088_ACC_0_CONNECTION_RETRY = 2319,
            BOARD_STARTUP_REPORT_BMI088_ACC_0_CONNECTION_TIME_US = 2320,
            BOARD_STARTUP_REPORT_BMI088_ACC_0_CONFIG_RESULT = 2321,
            BOARD_STARTUP_REPORT_BMI088_ACC_0_CONFIG_RETRY = 2322,
            BOARD_STARTUP_REPORT_BMI088_ACC_0_CONFIG_TIME_US = 2323,
            BOARD_STARTUP_REPORT_BMI088_ACC_1_CONNECTION_RESULT = 2324,
            BOARD_STARTUP_REPORT_BMI088_ACC_1_CONNECTION_RETRY = 2325,
            BOARD_STARTUP_REPORT_BMI088_ACC_1_CONNECTION_TIME_US = 2326,
            BOARD_STARTUP_REPORT_BMI088_ACC_1_CONFIG_RESULT = 2327,
            BOARD_STARTUP_REPORT_BMI088_ACC_1_CONFIG_RETRY = 2328,
            BOARD_STARTUP_REPORT_BMI088_ACC_1_CONFIG_TIME_US = 2329,
            BOARD_STARTUP_REPORT_BMI088_ACC_2_CONNECTION_RESULT = 2330,
            BOARD_STARTUP_REPORT_BMI088_ACC_2_CONNECTION_RETRY = 2331,
            BOARD_STARTUP_REPORT_BMI088_ACC_2_CONNECTION_TIME_US = 2332,
            BOARD_STARTUP_REPORT_BMI088_ACC_2_CONFIG_RESULT = 2333,
            BOARD_STARTUP_REPORT_BMI088_ACC_2_CONFIG_RETRY = 2334,
            BOARD_STARTUP_REPORT_BMI088_ACC_2_CONFIG_TIME_US = 2335,
            BOARD_STARTUP_REPORT_BMI088_ACC_3_CONNECTION_RESULT = 2336,
            BOARD_STARTUP_REPORT_BMI088_ACC_3_CONNECTION_RETRY = 2337,
            BOARD_STARTUP_REPORT_BMI088_ACC_3_CONNECTION_TIME_US = 2338,
            BOARD_STARTUP_REPORT_BMI088_ACC_3_CONFIG_RESULT = 2339,
            BOARD_STARTUP_REPORT_BMI088_ACC_3_CONFIG_RETRY = 2340,
            BOARD_STARTUP_REPORT_BMI088_ACC_3_CONFIG_TIME_US = 2341,
            BOARD_STARTUP_REPORT_ADXL357_0_CONNECTION_RESULT = 2342,
            BOARD_STARTUP_REPORT_ADXL357_0_CONNECTION_RETRY = 2343,
            BOARD_STARTUP_REPORT_ADXL357_0_CONNECTION_TIME_US = 2344,
            BOARD_STARTUP_REPORT_ADXL357_0_CONFIG_RESULT = 2345,
            BOARD_STARTUP_REPORT_ADXL357_0_CONFIG_RETRY = 2346,
            BOARD_STARTUP_REPORT_ADXL357_0_CONFIG_TIME_US = 2347,
            BOARD_STARTUP_REPORT_ADXL357_1_CONNECTION_RESULT = 2348,
            BOARD_STARTUP_REPORT_ADXL357_1_CONNECTION_RETRY = 2349,
            BOARD_STARTUP_REPORT_ADXL357_1_CONNECTION_TIME_US = 2350,
            BOARD_STARTUP_REPORT_ADXL357_1_CONFIG_RESULT = 2351,
            BOARD_STARTUP_REPORT_ADXL357_1_CONFIG_RETRY = 2352,
            BOARD_STARTUP_REPORT_ADXL357_1_CONFIG_TIME_US = 2353,
            BOARD_STARTUP_REPORT_ADXL357_2_CONNECTION_RESULT = 2354,
            BOARD_STARTUP_REPORT_ADXL357_2_CONNECTION_RETRY = 2355,
            BOARD_STARTUP_REPORT_ADXL357_2_CONNECTION_TIME_US = 2356,
            BOARD_STARTUP_REPORT_ADXL357_2_CONFIG_RESULT = 2357,
            BOARD_STARTUP_REPORT_ADXL357_2_CONFIG_RETRY = 2358,
            BOARD_STARTUP_REPORT_ADXL357_2_CONFIG_TIME_US = 2359,
            BOARD_STARTUP_REPORT_XRMA_SX_0_CONNECTION_RESULT = 2360,
            BOARD_STARTUP_REPORT_XRMA_SX_0_CONNECTION_RETRY = 2361,
            BOARD_STARTUP_REPORT_XRMA_SX_0_CONNECTION_TIME_US = 2362,
            BOARD_STARTUP_REPORT_XRMA_SX_0_CONFIG_RESULT = 2363,
            BOARD_STARTUP_REPORT_XRMA_SX_0_CONFIG_RETRY = 2364,
            BOARD_STARTUP_REPORT_XRMA_SX_0_CONFIG_TIME_US = 2365,
            BOARD_STARTUP_REPORT_XRMA_SX_1_CONNECTION_RESULT = 2366,
            BOARD_STARTUP_REPORT_XRMA_SX_1_CONNECTION_RETRY = 2367,
            BOARD_STARTUP_REPORT_XRMA_SX_1_CONNECTION_TIME_US = 2368,
            BOARD_STARTUP_REPORT_XRMA_SX_1_CONFIG_RESULT = 2369,
            BOARD_STARTUP_REPORT_XRMA_SX_1_CONFIG_RETRY = 2370,
            BOARD_STARTUP_REPORT_XRMA_SX_1_CONFIG_TIME_US = 2371,
            BOARD_STARTUP_REPORT_XRMA_SX_2_CONNECTION_RESULT = 2372,
            BOARD_STARTUP_REPORT_XRMA_SX_2_CONNECTION_RETRY = 2373,
            BOARD_STARTUP_REPORT_XRMA_SX_2_CONNECTION_TIME_US = 2374,
            BOARD_STARTUP_REPORT_XRMA_SX_2_CONFIG_RESULT = 2375,
            BOARD_STARTUP_REPORT_XRMA_SX_2_CONFIG_RETRY = 2376,
            BOARD_STARTUP_REPORT_XRMA_SX_2_CONFIG_TIME_US = 2377,
            BOARD_STARTUP_REPORT_H3_0_CONNECTION_RESULT = 2378,
            BOARD_STARTUP_REPORT_H3_0_CONNECTION_RETRY = 2379,
            BOARD_STARTUP_REPORT_H3_0_CONNECTION_TIME_US = 2380,
            BOARD_STARTUP_REPORT_H3_0_CONFIG_RESULT = 2381,
            BOARD_STARTUP_REPORT_H3_0_CONFIG_RETRY = 2382,
            BOARD_STARTUP_REPORT_H3_0_CONFIG_TIME_US = 2383,
            BOARD_STARTUP_REPORT_H3_1_CONNECTION_RESULT = 2384,
            BOARD_STARTUP_REPORT_H3_1_CONNECTION_RETRY = 2385,
            BOARD_STARTUP_REPORT_H3_1_CONNECTION_TIME_US = 2386,
            BOARD_STARTUP_REPORT_H3_1_CONFIG_RESULT = 2387,
            BOARD_STARTUP_REPORT_H3_1_CONFIG_RETRY = 2388,
            BOARD_STARTUP_REPORT_H3_1_CONFIG_TIME_US = 2389,
            BOARD_STARTUP_REPORT_H3_2_CONNECTION_RESULT = 2390,
            BOARD_STARTUP_REPORT_H3_2_CONNECTION_RETRY = 2391,
            BOARD_STARTUP_REPORT_H3_2_CONNECTION_TIME_US = 2392,
            BOARD_STARTUP_REPORT_H3_2_CONFIG_RESULT = 2393,
            BOARD_STARTUP_REPORT_H3_2_CONFIG_RETRY = 2394,
            BOARD_STARTUP_REPORT_H3_2_CONFIG_TIME_US = 2395,
            BOARD_STARTUP_REPORT_XRMG_0_CONNECTION_RESULT = 2396,
            BOARD_STARTUP_REPORT_XRMG_0_CONNECTION_RETRY = 2397,
            BOARD_STARTUP_REPORT_XRMG_0_CONNECTION_TIME_US = 2398,
            BOARD_STARTUP_REPORT_XRMG_0_CONFIG_RESULT = 2399,
            BOARD_STARTUP_REPORT_XRMG_0_CONFIG_RETRY = 2400,
            BOARD_STARTUP_REPORT_XRMG_0_CONFIG_TIME_US = 2401,
            BOARD_STARTUP_REPORT_XRMG_1_CONNECTION_RESULT = 2402,
            BOARD_STARTUP_REPORT_XRMG_1_CONNECTION_RETRY = 2403,
            BOARD_STARTUP_REPORT_XRMG_1_CONNECTION_TIME_US = 2404,
            BOARD_STARTUP_REPORT_XRMG_1_CONFIG_RESULT = 2405,
            BOARD_STARTUP_REPORT_XRMG_1_CONFIG_RETRY = 2406,
            BOARD_STARTUP_REPORT_XRMG_1_CONFIG_TIME_US = 2407,
            BOARD_STARTUP_REPORT_XRMG_2_CONNECTION_RESULT = 2408,
            BOARD_STARTUP_REPORT_XRMG_2_CONNECTION_RETRY = 2409,
            BOARD_STARTUP_REPORT_XRMG_2_CONNECTION_TIME_US = 2410,
            BOARD_STARTUP_REPORT_XRMG_2_CONFIG_RESULT = 2411,
            BOARD_STARTUP_REPORT_XRMG_2_CONFIG_RETRY = 2412,
            BOARD_STARTUP_REPORT_XRMG_2_CONFIG_TIME_US = 2413,
            BOARD_STARTUP_REPORT_XRMA_H60_CONNECTION_RESULT = 2414,
            BOARD_STARTUP_REPORT_XRMA_H60_CONNECTION_RETRY = 2415,
            BOARD_STARTUP_REPORT_XRMA_H60_CONNECTION_TIME_US = 2416,
            BOARD_STARTUP_REPORT_XRMA_H60_CONFIG_RESULT = 2417,
            BOARD_STARTUP_REPORT_XRMA_H60_CONFIG_RETRY = 2418,
            BOARD_STARTUP_REPORT_XRMA_H60_CONFIG_TIME_US = 2419,
            BOARD_STARTUP_REPORT_HMC5983_0_CONNECTION_RESULT = 2420,
            BOARD_STARTUP_REPORT_HMC5983_0_CONNECTION_RETRY = 2421,
            BOARD_STARTUP_REPORT_HMC5983_0_CONNECTION_TIME_US = 2422,
            BOARD_STARTUP_REPORT_HMC5983_0_CONFIG_RESULT = 2423,
            BOARD_STARTUP_REPORT_HMC5983_0_CONFIG_RETRY = 2424,
            BOARD_STARTUP_REPORT_HMC5983_0_CONFIG_TIME_US = 2425,
            BOARD_STARTUP_REPORT_HMC5983_1_CONNECTION_RESULT = 2426,
            BOARD_STARTUP_REPORT_HMC5983_1_CONNECTION_RETRY = 2427,
            BOARD_STARTUP_REPORT_HMC5983_1_CONNECTION_TIME_US = 2428,
            BOARD_STARTUP_REPORT_HMC5983_1_CONFIG_RESULT = 2429,
            BOARD_STARTUP_REPORT_HMC5983_1_CONFIG_RETRY = 2430,
            BOARD_STARTUP_REPORT_HMC5983_1_CONFIG_TIME_US = 2431,
            BOARD_STARTUP_REPORT_HMC5983_2_CONNECTION_RESULT = 2432,
            BOARD_STARTUP_REPORT_HMC5983_2_CONNECTION_RETRY = 2433,
            BOARD_STARTUP_REPORT_HMC5983_2_CONNECTION_TIME_US = 2434,
            BOARD_STARTUP_REPORT_HMC5983_2_CONFIG_RESULT = 2435,
            BOARD_STARTUP_REPORT_HMC5983_2_CONFIG_RETRY = 2436,
            BOARD_STARTUP_REPORT_HMC5983_2_CONFIG_TIME_US = 2437,
            BOARD_STARTUP_REPORT_BMM_0_CONNECTION_RESULT = 2438,
            BOARD_STARTUP_REPORT_BMM_0_CONNECTION_RETRY = 2439,
            BOARD_STARTUP_REPORT_BMM_0_CONNECTION_TIME_US = 2440,
            BOARD_STARTUP_REPORT_BMM_0_CONFIG_RESULT = 2441,
            BOARD_STARTUP_REPORT_BMM_0_CONFIG_RETRY = 2442,
            BOARD_STARTUP_REPORT_BMM_0_CONFIG_TIME_US = 2443,
            BOARD_STARTUP_REPORT_BMM_1_CONNECTION_RESULT = 2444,
            BOARD_STARTUP_REPORT_BMM_1_CONNECTION_RETRY = 2445,
            BOARD_STARTUP_REPORT_BMM_1_CONNECTION_TIME_US = 2446,
            BOARD_STARTUP_REPORT_BMM_1_CONFIG_RESULT = 2447,
            BOARD_STARTUP_REPORT_BMM_1_CONFIG_RETRY = 2448,
            BOARD_STARTUP_REPORT_BMM_1_CONFIG_TIME_US = 2449,
            BOARD_STARTUP_REPORT_MS56_CONNECTION_RESULT = 2450,
            BOARD_STARTUP_REPORT_MS56_CONNECTION_RETRY = 2451,
            BOARD_STARTUP_REPORT_MS56_CONNECTION_TIME_US = 2452,
            BOARD_STARTUP_REPORT_MS56_CONFIG_RESULT = 2453,
            BOARD_STARTUP_REPORT_MS56_CONFIG_RETRY = 2454,
            BOARD_STARTUP_REPORT_MS56_CONFIG_TIME_US = 2455,
            EXTERNAL_IMU_DATA_DATA_0_GYRO_X = 2456,
            EXTERNAL_IMU_DATA_DATA_0_GYRO_Y = 2457,
            EXTERNAL_IMU_DATA_DATA_0_GYRO_Z = 2458,
            EXTERNAL_IMU_DATA_DATA_0_ACC_X = 2459,
            EXTERNAL_IMU_DATA_DATA_0_ACC_Y = 2460,
            EXTERNAL_IMU_DATA_DATA_0_ACC_Z = 2461,
            EXTERNAL_IMU_DATA_DATA_0_TEMPERATURE = 2462,
            EXTERNAL_IMU_DATA_DATA_0_COUNTER = 2463,
            EXTERNAL_IMU_DATA_DATA_0_READ_ERROR_COUNTER = 2464,
            EXTERNAL_IMU_DATA_DATA_0_SERIAL_NO = 2465,
            EXTERNAL_IMU_DATA_DATA_0_NO = 2466,
            EXTERNAL_IMU_DATA_DATA_0_STATUS = 2467,
            EXTERNAL_IMU_DATA_DATA_0_ACTIVE = 2468,
            EXTERNAL_IMU_DATA_DATA_1_GYRO_X = 2469,
            EXTERNAL_IMU_DATA_DATA_1_GYRO_Y = 2470,
            EXTERNAL_IMU_DATA_DATA_1_GYRO_Z = 2471,
            EXTERNAL_IMU_DATA_DATA_1_ACC_X = 2472,
            EXTERNAL_IMU_DATA_DATA_1_ACC_Y = 2473,
            EXTERNAL_IMU_DATA_DATA_1_ACC_Z = 2474,
            EXTERNAL_IMU_DATA_DATA_1_TEMPERATURE = 2475,
            EXTERNAL_IMU_DATA_DATA_1_COUNTER = 2476,
            EXTERNAL_IMU_DATA_DATA_1_READ_ERROR_COUNTER = 2477,
            EXTERNAL_IMU_DATA_DATA_1_SERIAL_NO = 2478,
            EXTERNAL_IMU_DATA_DATA_1_NO = 2479,
            EXTERNAL_IMU_DATA_DATA_1_STATUS = 2480,
            EXTERNAL_IMU_DATA_DATA_1_ACTIVE = 2481,
            EXTERNAL_IMU_DATA_DATA_2_GYRO_X = 2482,
            EXTERNAL_IMU_DATA_DATA_2_GYRO_Y = 2483,
            EXTERNAL_IMU_DATA_DATA_2_GYRO_Z = 2484,
            EXTERNAL_IMU_DATA_DATA_2_ACC_X = 2485,
            EXTERNAL_IMU_DATA_DATA_2_ACC_Y = 2486,
            EXTERNAL_IMU_DATA_DATA_2_ACC_Z = 2487,
            EXTERNAL_IMU_DATA_DATA_2_TEMPERATURE = 2488,
            EXTERNAL_IMU_DATA_DATA_2_COUNTER = 2489,
            EXTERNAL_IMU_DATA_DATA_2_READ_ERROR_COUNTER = 2490,
            EXTERNAL_IMU_DATA_DATA_2_SERIAL_NO = 2491,
            EXTERNAL_IMU_DATA_DATA_2_NO = 2492,
            EXTERNAL_IMU_DATA_DATA_2_STATUS = 2493,
            EXTERNAL_IMU_DATA_DATA_2_ACTIVE = 2494,
            EXTERNAL_IMU_DATA_DATA_3_GYRO_X = 2495,
            EXTERNAL_IMU_DATA_DATA_3_GYRO_Y = 2496,
            EXTERNAL_IMU_DATA_DATA_3_GYRO_Z = 2497,
            EXTERNAL_IMU_DATA_DATA_3_ACC_X = 2498,
            EXTERNAL_IMU_DATA_DATA_3_ACC_Y = 2499,
            EXTERNAL_IMU_DATA_DATA_3_ACC_Z = 2500,
            EXTERNAL_IMU_DATA_DATA_3_TEMPERATURE = 2501,
            EXTERNAL_IMU_DATA_DATA_3_COUNTER = 2502,
            EXTERNAL_IMU_DATA_DATA_3_READ_ERROR_COUNTER = 2503,
            EXTERNAL_IMU_DATA_DATA_3_SERIAL_NO = 2504,
            EXTERNAL_IMU_DATA_DATA_3_NO = 2505,
            EXTERNAL_IMU_DATA_DATA_3_STATUS = 2506,
            EXTERNAL_IMU_DATA_DATA_3_ACTIVE = 2507,
            EXTERNAL_IMU_DATA_DATA_4_GYRO_X = 2508,
            EXTERNAL_IMU_DATA_DATA_4_GYRO_Y = 2509,
            EXTERNAL_IMU_DATA_DATA_4_GYRO_Z = 2510,
            EXTERNAL_IMU_DATA_DATA_4_ACC_X = 2511,
            EXTERNAL_IMU_DATA_DATA_4_ACC_Y = 2512,
            EXTERNAL_IMU_DATA_DATA_4_ACC_Z = 2513,
            EXTERNAL_IMU_DATA_DATA_4_TEMPERATURE = 2514,
            EXTERNAL_IMU_DATA_DATA_4_COUNTER = 2515,
            EXTERNAL_IMU_DATA_DATA_4_READ_ERROR_COUNTER = 2516,
            EXTERNAL_IMU_DATA_DATA_4_SERIAL_NO = 2517,
            EXTERNAL_IMU_DATA_DATA_4_NO = 2518,
            EXTERNAL_IMU_DATA_DATA_4_STATUS = 2519,
            EXTERNAL_IMU_DATA_DATA_4_ACTIVE = 2520,
            EXTERNAL_IMU_DATA_DATA_5_GYRO_X = 2521,
            EXTERNAL_IMU_DATA_DATA_5_GYRO_Y = 2522,
            EXTERNAL_IMU_DATA_DATA_5_GYRO_Z = 2523,
            EXTERNAL_IMU_DATA_DATA_5_ACC_X = 2524,
            EXTERNAL_IMU_DATA_DATA_5_ACC_Y = 2525,
            EXTERNAL_IMU_DATA_DATA_5_ACC_Z = 2526,
            EXTERNAL_IMU_DATA_DATA_5_TEMPERATURE = 2527,
            EXTERNAL_IMU_DATA_DATA_5_COUNTER = 2528,
            EXTERNAL_IMU_DATA_DATA_5_READ_ERROR_COUNTER = 2529,
            EXTERNAL_IMU_DATA_DATA_5_SERIAL_NO = 2530,
            EXTERNAL_IMU_DATA_DATA_5_NO = 2531,
            EXTERNAL_IMU_DATA_DATA_5_STATUS = 2532,
            EXTERNAL_IMU_DATA_DATA_5_ACTIVE = 2533,
            EXTERNAL_IMU_DATA_DATA_6_GYRO_X = 2534,
            EXTERNAL_IMU_DATA_DATA_6_GYRO_Y = 2535,
            EXTERNAL_IMU_DATA_DATA_6_GYRO_Z = 2536,
            EXTERNAL_IMU_DATA_DATA_6_ACC_X = 2537,
            EXTERNAL_IMU_DATA_DATA_6_ACC_Y = 2538,
            EXTERNAL_IMU_DATA_DATA_6_ACC_Z = 2539,
            EXTERNAL_IMU_DATA_DATA_6_TEMPERATURE = 2540,
            EXTERNAL_IMU_DATA_DATA_6_COUNTER = 2541,
            EXTERNAL_IMU_DATA_DATA_6_READ_ERROR_COUNTER = 2542,
            EXTERNAL_IMU_DATA_DATA_6_SERIAL_NO = 2543,
            EXTERNAL_IMU_DATA_DATA_6_NO = 2544,
            EXTERNAL_IMU_DATA_DATA_6_STATUS = 2545,
            EXTERNAL_IMU_DATA_DATA_6_ACTIVE = 2546,
            EXTERNAL_IMU_DATA_DATA_7_GYRO_X = 2547,
            EXTERNAL_IMU_DATA_DATA_7_GYRO_Y = 2548,
            EXTERNAL_IMU_DATA_DATA_7_GYRO_Z = 2549,
            EXTERNAL_IMU_DATA_DATA_7_ACC_X = 2550,
            EXTERNAL_IMU_DATA_DATA_7_ACC_Y = 2551,
            EXTERNAL_IMU_DATA_DATA_7_ACC_Z = 2552,
            EXTERNAL_IMU_DATA_DATA_7_TEMPERATURE = 2553,
            EXTERNAL_IMU_DATA_DATA_7_COUNTER = 2554,
            EXTERNAL_IMU_DATA_DATA_7_READ_ERROR_COUNTER = 2555,
            EXTERNAL_IMU_DATA_DATA_7_SERIAL_NO = 2556,
            EXTERNAL_IMU_DATA_DATA_7_NO = 2557,
            EXTERNAL_IMU_DATA_DATA_7_STATUS = 2558,
            EXTERNAL_IMU_DATA_DATA_7_ACTIVE = 2559,
            EXTERNAL_IMU_DATA_DATA_8_GYRO_X = 2560,
            EXTERNAL_IMU_DATA_DATA_8_GYRO_Y = 2561,
            EXTERNAL_IMU_DATA_DATA_8_GYRO_Z = 2562,
            EXTERNAL_IMU_DATA_DATA_8_ACC_X = 2563,
            EXTERNAL_IMU_DATA_DATA_8_ACC_Y = 2564,
            EXTERNAL_IMU_DATA_DATA_8_ACC_Z = 2565,
            EXTERNAL_IMU_DATA_DATA_8_TEMPERATURE = 2566,
            EXTERNAL_IMU_DATA_DATA_8_COUNTER = 2567,
            EXTERNAL_IMU_DATA_DATA_8_READ_ERROR_COUNTER = 2568,
            EXTERNAL_IMU_DATA_DATA_8_SERIAL_NO = 2569,
            EXTERNAL_IMU_DATA_DATA_8_NO = 2570,
            EXTERNAL_IMU_DATA_DATA_8_STATUS = 2571,
            EXTERNAL_IMU_DATA_DATA_8_ACTIVE = 2572,
            EXTERNAL_IMU_DATA_DATA_9_GYRO_X = 2573,
            EXTERNAL_IMU_DATA_DATA_9_GYRO_Y = 2574,
            EXTERNAL_IMU_DATA_DATA_9_GYRO_Z = 2575,
            EXTERNAL_IMU_DATA_DATA_9_ACC_X = 2576,
            EXTERNAL_IMU_DATA_DATA_9_ACC_Y = 2577,
            EXTERNAL_IMU_DATA_DATA_9_ACC_Z = 2578,
            EXTERNAL_IMU_DATA_DATA_9_TEMPERATURE = 2579,
            EXTERNAL_IMU_DATA_DATA_9_COUNTER = 2580,
            EXTERNAL_IMU_DATA_DATA_9_READ_ERROR_COUNTER = 2581,
            EXTERNAL_IMU_DATA_DATA_9_SERIAL_NO = 2582,
            EXTERNAL_IMU_DATA_DATA_9_NO = 2583,
            EXTERNAL_IMU_DATA_DATA_9_STATUS = 2584,
            EXTERNAL_IMU_DATA_DATA_9_ACTIVE = 2585,
            EXTERNAL_IMU_DATA_IMU_QTY = 2586,
            EXTERNAL_IMU_DATA_EXTERNAL_IMU_VALID = 2587,
            EXTERNAL_IMU_DATA_EXTERNAL_IMU_NEW_DATA_FLAG = 2588,
            EXTERNAL_IMU_DATA_EXTERNAL_IMU_FREQ_HZ = 2589,
            EXTERNAL_IMU_DATA_EXTERNAL_IMU_FREQ_ERROR_COUNTER = 2590,
            EXTERNAL_IMU_SETTING_EXTERNAL_IMU_NOMINAL_FREQ_HZ = 2591,
            EXTERNAL_IMU_SETTING_EXTERNAL_IMU_FREQ_MAX_ALLOWED_JITTER_HZ = 2592,
            MAIN_MCU_DATA_SENSOR_GYRO_0_X = 2593,
            MAIN_MCU_DATA_SENSOR_GYRO_0_Y = 2594,
            MAIN_MCU_DATA_SENSOR_GYRO_0_Z = 2595,
            MAIN_MCU_DATA_SENSOR_GYRO_1_X = 2596,
            MAIN_MCU_DATA_SENSOR_GYRO_1_Y = 2597,
            MAIN_MCU_DATA_SENSOR_GYRO_1_Z = 2598,
            MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_0_X = 2599,
            MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_0_Y = 2600,
            MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_0_Z = 2601,
            MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_1_X = 2602,
            MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_1_Y = 2603,
            MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_1_Z = 2604,
            MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_0_X = 2605,
            MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_0_Y = 2606,
            MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_0_Z = 2607,
            MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_1_X = 2608,
            MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_1_Y = 2609,
            MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_1_Z = 2610,
            MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_I16_0_X = 2611,
            MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_I16_0_Y = 2612,
            MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_I16_0_Z = 2613,
            MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_I16_1_X = 2614,
            MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_I16_1_Y = 2615,
            MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_I16_1_Z = 2616,
            MAIN_MCU_DATA_SENSOR_ACC_0_X = 2617,
            MAIN_MCU_DATA_SENSOR_ACC_0_Y = 2618,
            MAIN_MCU_DATA_SENSOR_ACC_0_Z = 2619,
            MAIN_MCU_DATA_SENSOR_ACC_1_X = 2620,
            MAIN_MCU_DATA_SENSOR_ACC_1_Y = 2621,
            MAIN_MCU_DATA_SENSOR_ACC_1_Z = 2622,
            MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_0_X = 2623,
            MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_0_Y = 2624,
            MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_0_Z = 2625,
            MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_1_X = 2626,
            MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_1_Y = 2627,
            MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_1_Z = 2628,
            MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_0_X = 2629,
            MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_0_Y = 2630,
            MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_0_Z = 2631,
            MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_1_X = 2632,
            MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_1_Y = 2633,
            MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_1_Z = 2634,
            MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_I16_0_X = 2635,
            MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_I16_0_Y = 2636,
            MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_I16_0_Z = 2637,
            MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_I16_1_X = 2638,
            MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_I16_1_Y = 2639,
            MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_I16_1_Z = 2640,
            MAIN_MCU_DATA_SENSOR_GYRO_I32_0_X = 2641,
            MAIN_MCU_DATA_SENSOR_GYRO_I32_0_Y = 2642,
            MAIN_MCU_DATA_SENSOR_GYRO_I32_0_Z = 2643,
            MAIN_MCU_DATA_SENSOR_GYRO_I32_1_X = 2644,
            MAIN_MCU_DATA_SENSOR_GYRO_I32_1_Y = 2645,
            MAIN_MCU_DATA_SENSOR_GYRO_I32_1_Z = 2646,
            MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_I16_0_X = 2647,
            MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_I16_0_Y = 2648,
            MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_I16_0_Z = 2649,
            MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_I16_1_X = 2650,
            MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_I16_1_Y = 2651,
            MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_I16_1_Z = 2652,
            MAIN_MCU_DATA_SENSOR_ACC_I32_0_X = 2653,
            MAIN_MCU_DATA_SENSOR_ACC_I32_0_Y = 2654,
            MAIN_MCU_DATA_SENSOR_ACC_I32_0_Z = 2655,
            MAIN_MCU_DATA_SENSOR_ACC_I32_1_X = 2656,
            MAIN_MCU_DATA_SENSOR_ACC_I32_1_Y = 2657,
            MAIN_MCU_DATA_SENSOR_ACC_I32_1_Z = 2658,
            MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_I16_0_X = 2659,
            MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_I16_0_Y = 2660,
            MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_I16_0_Z = 2661,
            MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_I16_1_X = 2662,
            MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_I16_1_Y = 2663,
            MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_I16_1_Z = 2664,
            MAIN_MCU_DATA_CHIP_ACTIVE = 2665,
            MAIN_MCU_DATA_CALC_STATUS = 2666,
            MAIN_MCU_DATA_SENSOR_STATUS = 2667,
            MAIN_MCU_DATA_COUNTER = 2668,
            MAIN_MCU_DATA_GENERAL_STATUS_SUMMARY = 2669,
            MAIN_MCU_DATA_FRAME_ERROR_COUNTER = 2670,
            MAIN_MCU_DATA_FRAME_ERROR_STATUS = 2671,
            MAIN_MCU_FRAME_SEQUENCE_ERROR = 2672,
            MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_US = 2673,
            MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_MAXIMA_US = 2674,
            MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_MINIMA_US = 2675,
            MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_LIMIT_EXCEED_COUNTER = 2676,
            MAIN_LOOP_PROFILER_DATA_INTERVAL_TIMING_ERROR = 2677,
            MAIN_LOOP_PROFILER_DATA_EXECUTION_TIME_US = 2678,
            MAIN_LOOP_PROFILER_DATA_EXECUTION_TIME_MAXIMA_US = 2679,
            MAIN_LOOP_PROFILER_DATA_EXECUTION_TIME_MINIMA_US = 2680,
            MAIN_LOOP_PROFILER_DATA_RUN_COUNTER = 2681,
            MAIN_LOOP_PROFILER_SETTING_INTERVAL_TIME_NOMINAL_US = 2682,
            MAIN_LOOP_PROFILER_SETTING_INTERVAL_TIME_MAX_ALLOWED_JITTER_US = 2683,
            CALC_VERSION = 2684,
            CALC_STATUS = 2685,
            CALC_COUNTER = 2686,
            DEBUG_SIGNALS_F64_0 = 2687,
            DEBUG_SIGNALS_F64_1 = 2688,
            DEBUG_SIGNALS_F64_2 = 2689,
            DEBUG_SIGNALS_F64_3 = 2690,
            DEBUG_SIGNALS_F64_4 = 2691,
            DEBUG_SIGNALS_F64_5 = 2692,
            DEBUG_SIGNALS_F64_6 = 2693,
            DEBUG_SIGNALS_F64_7 = 2694,
            DEBUG_SIGNALS_F64_8 = 2695,
            DEBUG_SIGNALS_F64_9 = 2696,
            DEBUG_SIGNALS_F64_10 = 2697,
            DEBUG_SIGNALS_F64_11 = 2698,
            DEBUG_SIGNALS_F64_12 = 2699,
            DEBUG_SIGNALS_F64_13 = 2700,
            DEBUG_SIGNALS_F64_14 = 2701,
            DEBUG_SIGNALS_F64_15 = 2702,
            DEBUG_SIGNALS_F64_16 = 2703,
            DEBUG_SIGNALS_F64_17 = 2704,
            DEBUG_SIGNALS_F64_18 = 2705,
            DEBUG_SIGNALS_F64_19 = 2706,
            DEBUG_SIGNALS_F64_20 = 2707,
            DEBUG_SIGNALS_F64_21 = 2708,
            DEBUG_SIGNALS_F64_22 = 2709,
            DEBUG_SIGNALS_F64_23 = 2710,
            DEBUG_SIGNALS_F64_24 = 2711,
            DEBUG_SIGNALS_F64_25 = 2712,
            DEBUG_SIGNALS_F64_26 = 2713,
            DEBUG_SIGNALS_F64_27 = 2714,
            DEBUG_SIGNALS_F64_28 = 2715,
            DEBUG_SIGNALS_F64_29 = 2716,
            DEBUG_SIGNALS_F64_30 = 2717,
            DEBUG_SIGNALS_F64_31 = 2718,
            DEBUG_SIGNALS_F64_32 = 2719,
            DEBUG_SIGNALS_F64_33 = 2720,
            DEBUG_SIGNALS_F64_34 = 2721,
            DEBUG_SIGNALS_F64_35 = 2722,
            DEBUG_SIGNALS_F64_36 = 2723,
            DEBUG_SIGNALS_F64_37 = 2724,
            DEBUG_SIGNALS_F64_38 = 2725,
            DEBUG_SIGNALS_F64_39 = 2726,
            DEBUG_SIGNALS_F64_40 = 2727,
            DEBUG_SIGNALS_F64_41 = 2728,
            DEBUG_SIGNALS_F64_42 = 2729,
            DEBUG_SIGNALS_F64_43 = 2730,
            DEBUG_SIGNALS_F64_44 = 2731,
            DEBUG_SIGNALS_F64_45 = 2732,
            DEBUG_SIGNALS_F64_46 = 2733,
            DEBUG_SIGNALS_F64_47 = 2734,
            DEBUG_SIGNALS_F64_48 = 2735,
            DEBUG_SIGNALS_F64_49 = 2736,
            DEBUG_SIGNALS_F32_0 = 2737,
            DEBUG_SIGNALS_F32_1 = 2738,
            DEBUG_SIGNALS_F32_2 = 2739,
            DEBUG_SIGNALS_F32_3 = 2740,
            DEBUG_SIGNALS_F32_4 = 2741,
            DEBUG_SIGNALS_F32_5 = 2742,
            DEBUG_SIGNALS_F32_6 = 2743,
            DEBUG_SIGNALS_F32_7 = 2744,
            DEBUG_SIGNALS_F32_8 = 2745,
            DEBUG_SIGNALS_F32_9 = 2746,
            DEBUG_SIGNALS_F32_10 = 2747,
            DEBUG_SIGNALS_F32_11 = 2748,
            DEBUG_SIGNALS_F32_12 = 2749,
            DEBUG_SIGNALS_F32_13 = 2750,
            DEBUG_SIGNALS_F32_14 = 2751,
            DEBUG_SIGNALS_F32_15 = 2752,
            DEBUG_SIGNALS_F32_16 = 2753,
            DEBUG_SIGNALS_F32_17 = 2754,
            DEBUG_SIGNALS_F32_18 = 2755,
            DEBUG_SIGNALS_F32_19 = 2756,
            DEBUG_SIGNALS_F32_20 = 2757,
            DEBUG_SIGNALS_F32_21 = 2758,
            DEBUG_SIGNALS_F32_22 = 2759,
            DEBUG_SIGNALS_F32_23 = 2760,
            DEBUG_SIGNALS_F32_24 = 2761,
            DEBUG_SIGNALS_F32_25 = 2762,
            DEBUG_SIGNALS_F32_26 = 2763,
            DEBUG_SIGNALS_F32_27 = 2764,
            DEBUG_SIGNALS_F32_28 = 2765,
            DEBUG_SIGNALS_F32_29 = 2766,
            DEBUG_SIGNALS_F32_30 = 2767,
            DEBUG_SIGNALS_F32_31 = 2768,
            DEBUG_SIGNALS_F32_32 = 2769,
            DEBUG_SIGNALS_F32_33 = 2770,
            DEBUG_SIGNALS_F32_34 = 2771,
            DEBUG_SIGNALS_F32_35 = 2772,
            DEBUG_SIGNALS_F32_36 = 2773,
            DEBUG_SIGNALS_F32_37 = 2774,
            DEBUG_SIGNALS_F32_38 = 2775,
            DEBUG_SIGNALS_F32_39 = 2776,
            DEBUG_SIGNALS_F32_40 = 2777,
            DEBUG_SIGNALS_F32_41 = 2778,
            DEBUG_SIGNALS_F32_42 = 2779,
            DEBUG_SIGNALS_F32_43 = 2780,
            DEBUG_SIGNALS_F32_44 = 2781,
            DEBUG_SIGNALS_F32_45 = 2782,
            DEBUG_SIGNALS_F32_46 = 2783,
            DEBUG_SIGNALS_F32_47 = 2784,
            DEBUG_SIGNALS_F32_48 = 2785,
            DEBUG_SIGNALS_F32_49 = 2786,
            DEBUG_SIGNALS_U32_0 = 2787,
            DEBUG_SIGNALS_U32_1 = 2788,
            DEBUG_SIGNALS_U32_2 = 2789,
            DEBUG_SIGNALS_U32_3 = 2790,
            DEBUG_SIGNALS_U32_4 = 2791,
            DEBUG_SIGNALS_U32_5 = 2792,
            DEBUG_SIGNALS_U32_6 = 2793,
            DEBUG_SIGNALS_U32_7 = 2794,
            DEBUG_SIGNALS_U32_8 = 2795,
            DEBUG_SIGNALS_U32_9 = 2796,
            DEBUG_SIGNALS_U32_10 = 2797,
            DEBUG_SIGNALS_U32_11 = 2798,
            DEBUG_SIGNALS_U32_12 = 2799,
            DEBUG_SIGNALS_U32_13 = 2800,
            DEBUG_SIGNALS_U32_14 = 2801,
            DEBUG_SIGNALS_U32_15 = 2802,
            DEBUG_SIGNALS_U32_16 = 2803,
            DEBUG_SIGNALS_U32_17 = 2804,
            DEBUG_SIGNALS_U32_18 = 2805,
            DEBUG_SIGNALS_U32_19 = 2806,
            DEBUG_SIGNALS_U32_20 = 2807,
            DEBUG_SIGNALS_U32_21 = 2808,
            DEBUG_SIGNALS_U32_22 = 2809,
            DEBUG_SIGNALS_U32_23 = 2810,
            DEBUG_SIGNALS_U32_24 = 2811,
            DEBUG_SIGNALS_U32_25 = 2812,
            DEBUG_SIGNALS_U32_26 = 2813,
            DEBUG_SIGNALS_U32_27 = 2814,
            DEBUG_SIGNALS_U32_28 = 2815,
            DEBUG_SIGNALS_U32_29 = 2816,
            DEBUG_SIGNALS_U32_30 = 2817,
            DEBUG_SIGNALS_U32_31 = 2818,
            DEBUG_SIGNALS_U32_32 = 2819,
            DEBUG_SIGNALS_U32_33 = 2820,
            DEBUG_SIGNALS_U32_34 = 2821,
            DEBUG_SIGNALS_U32_35 = 2822,
            DEBUG_SIGNALS_U32_36 = 2823,
            DEBUG_SIGNALS_U32_37 = 2824,
            DEBUG_SIGNALS_U32_38 = 2825,
            DEBUG_SIGNALS_U32_39 = 2826,
            DEBUG_SIGNALS_U32_40 = 2827,
            DEBUG_SIGNALS_U32_41 = 2828,
            DEBUG_SIGNALS_U32_42 = 2829,
            DEBUG_SIGNALS_U32_43 = 2830,
            DEBUG_SIGNALS_U32_44 = 2831,
            DEBUG_SIGNALS_U32_45 = 2832,
            DEBUG_SIGNALS_U32_46 = 2833,
            DEBUG_SIGNALS_U32_47 = 2834,
            DEBUG_SIGNALS_U32_48 = 2835,
            DEBUG_SIGNALS_U32_49 = 2836,
            DEBUG_SIGNALS_I32_0 = 2837,
            DEBUG_SIGNALS_I32_1 = 2838,
            DEBUG_SIGNALS_I32_2 = 2839,
            DEBUG_SIGNALS_I32_3 = 2840,
            DEBUG_SIGNALS_I32_4 = 2841,
            DEBUG_SIGNALS_I32_5 = 2842,
            DEBUG_SIGNALS_I32_6 = 2843,
            DEBUG_SIGNALS_I32_7 = 2844,
            DEBUG_SIGNALS_I32_8 = 2845,
            DEBUG_SIGNALS_I32_9 = 2846,
            DEBUG_SIGNALS_I32_10 = 2847,
            DEBUG_SIGNALS_I32_11 = 2848,
            DEBUG_SIGNALS_I32_12 = 2849,
            DEBUG_SIGNALS_I32_13 = 2850,
            DEBUG_SIGNALS_I32_14 = 2851,
            DEBUG_SIGNALS_I32_15 = 2852,
            DEBUG_SIGNALS_I32_16 = 2853,
            DEBUG_SIGNALS_I32_17 = 2854,
            DEBUG_SIGNALS_I32_18 = 2855,
            DEBUG_SIGNALS_I32_19 = 2856,
            DEBUG_SIGNALS_I32_20 = 2857,
            DEBUG_SIGNALS_I32_21 = 2858,
            DEBUG_SIGNALS_I32_22 = 2859,
            DEBUG_SIGNALS_I32_23 = 2860,
            DEBUG_SIGNALS_I32_24 = 2861,
            DEBUG_SIGNALS_I32_25 = 2862,
            DEBUG_SIGNALS_I32_26 = 2863,
            DEBUG_SIGNALS_I32_27 = 2864,
            DEBUG_SIGNALS_I32_28 = 2865,
            DEBUG_SIGNALS_I32_29 = 2866,
            DEBUG_SIGNALS_I32_30 = 2867,
            DEBUG_SIGNALS_I32_31 = 2868,
            DEBUG_SIGNALS_I32_32 = 2869,
            DEBUG_SIGNALS_I32_33 = 2870,
            DEBUG_SIGNALS_I32_34 = 2871,
            DEBUG_SIGNALS_I32_35 = 2872,
            DEBUG_SIGNALS_I32_36 = 2873,
            DEBUG_SIGNALS_I32_37 = 2874,
            DEBUG_SIGNALS_I32_38 = 2875,
            DEBUG_SIGNALS_I32_39 = 2876,
            DEBUG_SIGNALS_I32_40 = 2877,
            DEBUG_SIGNALS_I32_41 = 2878,
            DEBUG_SIGNALS_I32_42 = 2879,
            DEBUG_SIGNALS_I32_43 = 2880,
            DEBUG_SIGNALS_I32_44 = 2881,
            DEBUG_SIGNALS_I32_45 = 2882,
            DEBUG_SIGNALS_I32_46 = 2883,
            DEBUG_SIGNALS_I32_47 = 2884,
            DEBUG_SIGNALS_I32_48 = 2885,
            DEBUG_SIGNALS_I32_49 = 2886,
            DEBUG_SIGNALS_U16_0 = 2887,
            DEBUG_SIGNALS_U16_1 = 2888,
            DEBUG_SIGNALS_U16_2 = 2889,
            DEBUG_SIGNALS_U16_3 = 2890,
            DEBUG_SIGNALS_U16_4 = 2891,
            DEBUG_SIGNALS_U16_5 = 2892,
            DEBUG_SIGNALS_U16_6 = 2893,
            DEBUG_SIGNALS_U16_7 = 2894,
            DEBUG_SIGNALS_U16_8 = 2895,
            DEBUG_SIGNALS_U16_9 = 2896,
            DEBUG_SIGNALS_U16_10 = 2897,
            DEBUG_SIGNALS_U16_11 = 2898,
            DEBUG_SIGNALS_U16_12 = 2899,
            DEBUG_SIGNALS_U16_13 = 2900,
            DEBUG_SIGNALS_U16_14 = 2901,
            DEBUG_SIGNALS_U16_15 = 2902,
            DEBUG_SIGNALS_U16_16 = 2903,
            DEBUG_SIGNALS_U16_17 = 2904,
            DEBUG_SIGNALS_U16_18 = 2905,
            DEBUG_SIGNALS_U16_19 = 2906,
            DEBUG_SIGNALS_U16_20 = 2907,
            DEBUG_SIGNALS_U16_21 = 2908,
            DEBUG_SIGNALS_U16_22 = 2909,
            DEBUG_SIGNALS_U16_23 = 2910,
            DEBUG_SIGNALS_U16_24 = 2911,
            DEBUG_SIGNALS_U16_25 = 2912,
            DEBUG_SIGNALS_U16_26 = 2913,
            DEBUG_SIGNALS_U16_27 = 2914,
            DEBUG_SIGNALS_U16_28 = 2915,
            DEBUG_SIGNALS_U16_29 = 2916,
            DEBUG_SIGNALS_U16_30 = 2917,
            DEBUG_SIGNALS_U16_31 = 2918,
            DEBUG_SIGNALS_U16_32 = 2919,
            DEBUG_SIGNALS_U16_33 = 2920,
            DEBUG_SIGNALS_U16_34 = 2921,
            DEBUG_SIGNALS_U16_35 = 2922,
            DEBUG_SIGNALS_U16_36 = 2923,
            DEBUG_SIGNALS_U16_37 = 2924,
            DEBUG_SIGNALS_U16_38 = 2925,
            DEBUG_SIGNALS_U16_39 = 2926,
            DEBUG_SIGNALS_U16_40 = 2927,
            DEBUG_SIGNALS_U16_41 = 2928,
            DEBUG_SIGNALS_U16_42 = 2929,
            DEBUG_SIGNALS_U16_43 = 2930,
            DEBUG_SIGNALS_U16_44 = 2931,
            DEBUG_SIGNALS_U16_45 = 2932,
            DEBUG_SIGNALS_U16_46 = 2933,
            DEBUG_SIGNALS_U16_47 = 2934,
            DEBUG_SIGNALS_U16_48 = 2935,
            DEBUG_SIGNALS_U16_49 = 2936,
            DEBUG_SIGNALS_I16_0 = 2937,
            DEBUG_SIGNALS_I16_1 = 2938,
            DEBUG_SIGNALS_I16_2 = 2939,
            DEBUG_SIGNALS_I16_3 = 2940,
            DEBUG_SIGNALS_I16_4 = 2941,
            DEBUG_SIGNALS_I16_5 = 2942,
            DEBUG_SIGNALS_I16_6 = 2943,
            DEBUG_SIGNALS_I16_7 = 2944,
            DEBUG_SIGNALS_I16_8 = 2945,
            DEBUG_SIGNALS_I16_9 = 2946,
            DEBUG_SIGNALS_I16_10 = 2947,
            DEBUG_SIGNALS_I16_11 = 2948,
            DEBUG_SIGNALS_I16_12 = 2949,
            DEBUG_SIGNALS_I16_13 = 2950,
            DEBUG_SIGNALS_I16_14 = 2951,
            DEBUG_SIGNALS_I16_15 = 2952,
            DEBUG_SIGNALS_I16_16 = 2953,
            DEBUG_SIGNALS_I16_17 = 2954,
            DEBUG_SIGNALS_I16_18 = 2955,
            DEBUG_SIGNALS_I16_19 = 2956,
            DEBUG_SIGNALS_I16_20 = 2957,
            DEBUG_SIGNALS_I16_21 = 2958,
            DEBUG_SIGNALS_I16_22 = 2959,
            DEBUG_SIGNALS_I16_23 = 2960,
            DEBUG_SIGNALS_I16_24 = 2961,
            DEBUG_SIGNALS_I16_25 = 2962,
            DEBUG_SIGNALS_I16_26 = 2963,
            DEBUG_SIGNALS_I16_27 = 2964,
            DEBUG_SIGNALS_I16_28 = 2965,
            DEBUG_SIGNALS_I16_29 = 2966,
            DEBUG_SIGNALS_I16_30 = 2967,
            DEBUG_SIGNALS_I16_31 = 2968,
            DEBUG_SIGNALS_I16_32 = 2969,
            DEBUG_SIGNALS_I16_33 = 2970,
            DEBUG_SIGNALS_I16_34 = 2971,
            DEBUG_SIGNALS_I16_35 = 2972,
            DEBUG_SIGNALS_I16_36 = 2973,
            DEBUG_SIGNALS_I16_37 = 2974,
            DEBUG_SIGNALS_I16_38 = 2975,
            DEBUG_SIGNALS_I16_39 = 2976,
            DEBUG_SIGNALS_I16_40 = 2977,
            DEBUG_SIGNALS_I16_41 = 2978,
            DEBUG_SIGNALS_I16_42 = 2979,
            DEBUG_SIGNALS_I16_43 = 2980,
            DEBUG_SIGNALS_I16_44 = 2981,
            DEBUG_SIGNALS_I16_45 = 2982,
            DEBUG_SIGNALS_I16_46 = 2983,
            DEBUG_SIGNALS_I16_47 = 2984,
            DEBUG_SIGNALS_I16_48 = 2985,
            DEBUG_SIGNALS_I16_49 = 2986,
            DEBUG_CONTROL_SIGNALS_F64_0 = 2987,
            DEBUG_CONTROL_SIGNALS_F64_1 = 2988,
            DEBUG_CONTROL_SIGNALS_F64_2 = 2989,
            DEBUG_CONTROL_SIGNALS_F64_3 = 2990,
            DEBUG_CONTROL_SIGNALS_F64_4 = 2991,
            DEBUG_CONTROL_SIGNALS_F64_5 = 2992,
            DEBUG_CONTROL_SIGNALS_F64_6 = 2993,
            DEBUG_CONTROL_SIGNALS_F64_7 = 2994,
            DEBUG_CONTROL_SIGNALS_F64_8 = 2995,
            DEBUG_CONTROL_SIGNALS_F64_9 = 2996,
            DEBUG_CONTROL_SIGNALS_F64_10 = 2997,
            DEBUG_CONTROL_SIGNALS_F64_11 = 2998,
            DEBUG_CONTROL_SIGNALS_F64_12 = 2999,
            DEBUG_CONTROL_SIGNALS_F64_13 = 3000,
            DEBUG_CONTROL_SIGNALS_F64_14 = 3001,
            DEBUG_CONTROL_SIGNALS_F64_15 = 3002,
            DEBUG_CONTROL_SIGNALS_F64_16 = 3003,
            DEBUG_CONTROL_SIGNALS_F64_17 = 3004,
            DEBUG_CONTROL_SIGNALS_F64_18 = 3005,
            DEBUG_CONTROL_SIGNALS_F64_19 = 3006,
            DEBUG_CONTROL_SIGNALS_F64_20 = 3007,
            DEBUG_CONTROL_SIGNALS_F64_21 = 3008,
            DEBUG_CONTROL_SIGNALS_F64_22 = 3009,
            DEBUG_CONTROL_SIGNALS_F64_23 = 3010,
            DEBUG_CONTROL_SIGNALS_F64_24 = 3011,
            DEBUG_CONTROL_SIGNALS_F64_25 = 3012,
            DEBUG_CONTROL_SIGNALS_F64_26 = 3013,
            DEBUG_CONTROL_SIGNALS_F64_27 = 3014,
            DEBUG_CONTROL_SIGNALS_F64_28 = 3015,
            DEBUG_CONTROL_SIGNALS_F64_29 = 3016,
            DEBUG_CONTROL_SIGNALS_F64_30 = 3017,
            DEBUG_CONTROL_SIGNALS_F64_31 = 3018,
            DEBUG_CONTROL_SIGNALS_F64_32 = 3019,
            DEBUG_CONTROL_SIGNALS_F64_33 = 3020,
            DEBUG_CONTROL_SIGNALS_F64_34 = 3021,
            DEBUG_CONTROL_SIGNALS_F64_35 = 3022,
            DEBUG_CONTROL_SIGNALS_F64_36 = 3023,
            DEBUG_CONTROL_SIGNALS_F64_37 = 3024,
            DEBUG_CONTROL_SIGNALS_F64_38 = 3025,
            DEBUG_CONTROL_SIGNALS_F64_39 = 3026,
            DEBUG_CONTROL_SIGNALS_F64_40 = 3027,
            DEBUG_CONTROL_SIGNALS_F64_41 = 3028,
            DEBUG_CONTROL_SIGNALS_F64_42 = 3029,
            DEBUG_CONTROL_SIGNALS_F64_43 = 3030,
            DEBUG_CONTROL_SIGNALS_F64_44 = 3031,
            DEBUG_CONTROL_SIGNALS_F64_45 = 3032,
            DEBUG_CONTROL_SIGNALS_F64_46 = 3033,
            DEBUG_CONTROL_SIGNALS_F64_47 = 3034,
            DEBUG_CONTROL_SIGNALS_F64_48 = 3035,
            DEBUG_CONTROL_SIGNALS_F64_49 = 3036,
            DEBUG_CONTROL_SIGNALS_F32_0 = 3037,
            DEBUG_CONTROL_SIGNALS_F32_1 = 3038,
            DEBUG_CONTROL_SIGNALS_F32_2 = 3039,
            DEBUG_CONTROL_SIGNALS_F32_3 = 3040,
            DEBUG_CONTROL_SIGNALS_F32_4 = 3041,
            DEBUG_CONTROL_SIGNALS_F32_5 = 3042,
            DEBUG_CONTROL_SIGNALS_F32_6 = 3043,
            DEBUG_CONTROL_SIGNALS_F32_7 = 3044,
            DEBUG_CONTROL_SIGNALS_F32_8 = 3045,
            DEBUG_CONTROL_SIGNALS_F32_9 = 3046,
            DEBUG_CONTROL_SIGNALS_F32_10 = 3047,
            DEBUG_CONTROL_SIGNALS_F32_11 = 3048,
            DEBUG_CONTROL_SIGNALS_F32_12 = 3049,
            DEBUG_CONTROL_SIGNALS_F32_13 = 3050,
            DEBUG_CONTROL_SIGNALS_F32_14 = 3051,
            DEBUG_CONTROL_SIGNALS_F32_15 = 3052,
            DEBUG_CONTROL_SIGNALS_F32_16 = 3053,
            DEBUG_CONTROL_SIGNALS_F32_17 = 3054,
            DEBUG_CONTROL_SIGNALS_F32_18 = 3055,
            DEBUG_CONTROL_SIGNALS_F32_19 = 3056,
            DEBUG_CONTROL_SIGNALS_F32_20 = 3057,
            DEBUG_CONTROL_SIGNALS_F32_21 = 3058,
            DEBUG_CONTROL_SIGNALS_F32_22 = 3059,
            DEBUG_CONTROL_SIGNALS_F32_23 = 3060,
            DEBUG_CONTROL_SIGNALS_F32_24 = 3061,
            DEBUG_CONTROL_SIGNALS_F32_25 = 3062,
            DEBUG_CONTROL_SIGNALS_F32_26 = 3063,
            DEBUG_CONTROL_SIGNALS_F32_27 = 3064,
            DEBUG_CONTROL_SIGNALS_F32_28 = 3065,
            DEBUG_CONTROL_SIGNALS_F32_29 = 3066,
            DEBUG_CONTROL_SIGNALS_F32_30 = 3067,
            DEBUG_CONTROL_SIGNALS_F32_31 = 3068,
            DEBUG_CONTROL_SIGNALS_F32_32 = 3069,
            DEBUG_CONTROL_SIGNALS_F32_33 = 3070,
            DEBUG_CONTROL_SIGNALS_F32_34 = 3071,
            DEBUG_CONTROL_SIGNALS_F32_35 = 3072,
            DEBUG_CONTROL_SIGNALS_F32_36 = 3073,
            DEBUG_CONTROL_SIGNALS_F32_37 = 3074,
            DEBUG_CONTROL_SIGNALS_F32_38 = 3075,
            DEBUG_CONTROL_SIGNALS_F32_39 = 3076,
            DEBUG_CONTROL_SIGNALS_F32_40 = 3077,
            DEBUG_CONTROL_SIGNALS_F32_41 = 3078,
            DEBUG_CONTROL_SIGNALS_F32_42 = 3079,
            DEBUG_CONTROL_SIGNALS_F32_43 = 3080,
            DEBUG_CONTROL_SIGNALS_F32_44 = 3081,
            DEBUG_CONTROL_SIGNALS_F32_45 = 3082,
            DEBUG_CONTROL_SIGNALS_F32_46 = 3083,
            DEBUG_CONTROL_SIGNALS_F32_47 = 3084,
            DEBUG_CONTROL_SIGNALS_F32_48 = 3085,
            DEBUG_CONTROL_SIGNALS_F32_49 = 3086,
            DEBUG_CONTROL_SIGNALS_U32_0 = 3087,
            DEBUG_CONTROL_SIGNALS_U32_1 = 3088,
            DEBUG_CONTROL_SIGNALS_U32_2 = 3089,
            DEBUG_CONTROL_SIGNALS_U32_3 = 3090,
            DEBUG_CONTROL_SIGNALS_U32_4 = 3091,
            DEBUG_CONTROL_SIGNALS_U32_5 = 3092,
            DEBUG_CONTROL_SIGNALS_U32_6 = 3093,
            DEBUG_CONTROL_SIGNALS_U32_7 = 3094,
            DEBUG_CONTROL_SIGNALS_U32_8 = 3095,
            DEBUG_CONTROL_SIGNALS_U32_9 = 3096,
            DEBUG_CONTROL_SIGNALS_U32_10 = 3097,
            DEBUG_CONTROL_SIGNALS_U32_11 = 3098,
            DEBUG_CONTROL_SIGNALS_U32_12 = 3099,
            DEBUG_CONTROL_SIGNALS_U32_13 = 3100,
            DEBUG_CONTROL_SIGNALS_U32_14 = 3101,
            DEBUG_CONTROL_SIGNALS_U32_15 = 3102,
            DEBUG_CONTROL_SIGNALS_U32_16 = 3103,
            DEBUG_CONTROL_SIGNALS_U32_17 = 3104,
            DEBUG_CONTROL_SIGNALS_U32_18 = 3105,
            DEBUG_CONTROL_SIGNALS_U32_19 = 3106,
            DEBUG_CONTROL_SIGNALS_U32_20 = 3107,
            DEBUG_CONTROL_SIGNALS_U32_21 = 3108,
            DEBUG_CONTROL_SIGNALS_U32_22 = 3109,
            DEBUG_CONTROL_SIGNALS_U32_23 = 3110,
            DEBUG_CONTROL_SIGNALS_U32_24 = 3111,
            DEBUG_CONTROL_SIGNALS_U32_25 = 3112,
            DEBUG_CONTROL_SIGNALS_U32_26 = 3113,
            DEBUG_CONTROL_SIGNALS_U32_27 = 3114,
            DEBUG_CONTROL_SIGNALS_U32_28 = 3115,
            DEBUG_CONTROL_SIGNALS_U32_29 = 3116,
            DEBUG_CONTROL_SIGNALS_U32_30 = 3117,
            DEBUG_CONTROL_SIGNALS_U32_31 = 3118,
            DEBUG_CONTROL_SIGNALS_U32_32 = 3119,
            DEBUG_CONTROL_SIGNALS_U32_33 = 3120,
            DEBUG_CONTROL_SIGNALS_U32_34 = 3121,
            DEBUG_CONTROL_SIGNALS_U32_35 = 3122,
            DEBUG_CONTROL_SIGNALS_U32_36 = 3123,
            DEBUG_CONTROL_SIGNALS_U32_37 = 3124,
            DEBUG_CONTROL_SIGNALS_U32_38 = 3125,
            DEBUG_CONTROL_SIGNALS_U32_39 = 3126,
            DEBUG_CONTROL_SIGNALS_U32_40 = 3127,
            DEBUG_CONTROL_SIGNALS_U32_41 = 3128,
            DEBUG_CONTROL_SIGNALS_U32_42 = 3129,
            DEBUG_CONTROL_SIGNALS_U32_43 = 3130,
            DEBUG_CONTROL_SIGNALS_U32_44 = 3131,
            DEBUG_CONTROL_SIGNALS_U32_45 = 3132,
            DEBUG_CONTROL_SIGNALS_U32_46 = 3133,
            DEBUG_CONTROL_SIGNALS_U32_47 = 3134,
            DEBUG_CONTROL_SIGNALS_U32_48 = 3135,
            DEBUG_CONTROL_SIGNALS_U32_49 = 3136,
            DEBUG_CONTROL_SIGNALS_I32_0 = 3137,
            DEBUG_CONTROL_SIGNALS_I32_1 = 3138,
            DEBUG_CONTROL_SIGNALS_I32_2 = 3139,
            DEBUG_CONTROL_SIGNALS_I32_3 = 3140,
            DEBUG_CONTROL_SIGNALS_I32_4 = 3141,
            DEBUG_CONTROL_SIGNALS_I32_5 = 3142,
            DEBUG_CONTROL_SIGNALS_I32_6 = 3143,
            DEBUG_CONTROL_SIGNALS_I32_7 = 3144,
            DEBUG_CONTROL_SIGNALS_I32_8 = 3145,
            DEBUG_CONTROL_SIGNALS_I32_9 = 3146,
            DEBUG_CONTROL_SIGNALS_I32_10 = 3147,
            DEBUG_CONTROL_SIGNALS_I32_11 = 3148,
            DEBUG_CONTROL_SIGNALS_I32_12 = 3149,
            DEBUG_CONTROL_SIGNALS_I32_13 = 3150,
            DEBUG_CONTROL_SIGNALS_I32_14 = 3151,
            DEBUG_CONTROL_SIGNALS_I32_15 = 3152,
            DEBUG_CONTROL_SIGNALS_I32_16 = 3153,
            DEBUG_CONTROL_SIGNALS_I32_17 = 3154,
            DEBUG_CONTROL_SIGNALS_I32_18 = 3155,
            DEBUG_CONTROL_SIGNALS_I32_19 = 3156,
            DEBUG_CONTROL_SIGNALS_I32_20 = 3157,
            DEBUG_CONTROL_SIGNALS_I32_21 = 3158,
            DEBUG_CONTROL_SIGNALS_I32_22 = 3159,
            DEBUG_CONTROL_SIGNALS_I32_23 = 3160,
            DEBUG_CONTROL_SIGNALS_I32_24 = 3161,
            DEBUG_CONTROL_SIGNALS_I32_25 = 3162,
            DEBUG_CONTROL_SIGNALS_I32_26 = 3163,
            DEBUG_CONTROL_SIGNALS_I32_27 = 3164,
            DEBUG_CONTROL_SIGNALS_I32_28 = 3165,
            DEBUG_CONTROL_SIGNALS_I32_29 = 3166,
            DEBUG_CONTROL_SIGNALS_I32_30 = 3167,
            DEBUG_CONTROL_SIGNALS_I32_31 = 3168,
            DEBUG_CONTROL_SIGNALS_I32_32 = 3169,
            DEBUG_CONTROL_SIGNALS_I32_33 = 3170,
            DEBUG_CONTROL_SIGNALS_I32_34 = 3171,
            DEBUG_CONTROL_SIGNALS_I32_35 = 3172,
            DEBUG_CONTROL_SIGNALS_I32_36 = 3173,
            DEBUG_CONTROL_SIGNALS_I32_37 = 3174,
            DEBUG_CONTROL_SIGNALS_I32_38 = 3175,
            DEBUG_CONTROL_SIGNALS_I32_39 = 3176,
            DEBUG_CONTROL_SIGNALS_I32_40 = 3177,
            DEBUG_CONTROL_SIGNALS_I32_41 = 3178,
            DEBUG_CONTROL_SIGNALS_I32_42 = 3179,
            DEBUG_CONTROL_SIGNALS_I32_43 = 3180,
            DEBUG_CONTROL_SIGNALS_I32_44 = 3181,
            DEBUG_CONTROL_SIGNALS_I32_45 = 3182,
            DEBUG_CONTROL_SIGNALS_I32_46 = 3183,
            DEBUG_CONTROL_SIGNALS_I32_47 = 3184,
            DEBUG_CONTROL_SIGNALS_I32_48 = 3185,
            DEBUG_CONTROL_SIGNALS_I32_49 = 3186,
            DEBUG_CONTROL_SIGNALS_U16_0 = 3187,
            DEBUG_CONTROL_SIGNALS_U16_1 = 3188,
            DEBUG_CONTROL_SIGNALS_U16_2 = 3189,
            DEBUG_CONTROL_SIGNALS_U16_3 = 3190,
            DEBUG_CONTROL_SIGNALS_U16_4 = 3191,
            DEBUG_CONTROL_SIGNALS_U16_5 = 3192,
            DEBUG_CONTROL_SIGNALS_U16_6 = 3193,
            DEBUG_CONTROL_SIGNALS_U16_7 = 3194,
            DEBUG_CONTROL_SIGNALS_U16_8 = 3195,
            DEBUG_CONTROL_SIGNALS_U16_9 = 3196,
            DEBUG_CONTROL_SIGNALS_U16_10 = 3197,
            DEBUG_CONTROL_SIGNALS_U16_11 = 3198,
            DEBUG_CONTROL_SIGNALS_U16_12 = 3199,
            DEBUG_CONTROL_SIGNALS_U16_13 = 3200,
            DEBUG_CONTROL_SIGNALS_U16_14 = 3201,
            DEBUG_CONTROL_SIGNALS_U16_15 = 3202,
            DEBUG_CONTROL_SIGNALS_U16_16 = 3203,
            DEBUG_CONTROL_SIGNALS_U16_17 = 3204,
            DEBUG_CONTROL_SIGNALS_U16_18 = 3205,
            DEBUG_CONTROL_SIGNALS_U16_19 = 3206,
            DEBUG_CONTROL_SIGNALS_U16_20 = 3207,
            DEBUG_CONTROL_SIGNALS_U16_21 = 3208,
            DEBUG_CONTROL_SIGNALS_U16_22 = 3209,
            DEBUG_CONTROL_SIGNALS_U16_23 = 3210,
            DEBUG_CONTROL_SIGNALS_U16_24 = 3211,
            DEBUG_CONTROL_SIGNALS_U16_25 = 3212,
            DEBUG_CONTROL_SIGNALS_U16_26 = 3213,
            DEBUG_CONTROL_SIGNALS_U16_27 = 3214,
            DEBUG_CONTROL_SIGNALS_U16_28 = 3215,
            DEBUG_CONTROL_SIGNALS_U16_29 = 3216,
            DEBUG_CONTROL_SIGNALS_U16_30 = 3217,
            DEBUG_CONTROL_SIGNALS_U16_31 = 3218,
            DEBUG_CONTROL_SIGNALS_U16_32 = 3219,
            DEBUG_CONTROL_SIGNALS_U16_33 = 3220,
            DEBUG_CONTROL_SIGNALS_U16_34 = 3221,
            DEBUG_CONTROL_SIGNALS_U16_35 = 3222,
            DEBUG_CONTROL_SIGNALS_U16_36 = 3223,
            DEBUG_CONTROL_SIGNALS_U16_37 = 3224,
            DEBUG_CONTROL_SIGNALS_U16_38 = 3225,
            DEBUG_CONTROL_SIGNALS_U16_39 = 3226,
            DEBUG_CONTROL_SIGNALS_U16_40 = 3227,
            DEBUG_CONTROL_SIGNALS_U16_41 = 3228,
            DEBUG_CONTROL_SIGNALS_U16_42 = 3229,
            DEBUG_CONTROL_SIGNALS_U16_43 = 3230,
            DEBUG_CONTROL_SIGNALS_U16_44 = 3231,
            DEBUG_CONTROL_SIGNALS_U16_45 = 3232,
            DEBUG_CONTROL_SIGNALS_U16_46 = 3233,
            DEBUG_CONTROL_SIGNALS_U16_47 = 3234,
            DEBUG_CONTROL_SIGNALS_U16_48 = 3235,
            DEBUG_CONTROL_SIGNALS_U16_49 = 3236,
            DEBUG_CONTROL_SIGNALS_I16_0 = 3237,
            DEBUG_CONTROL_SIGNALS_I16_1 = 3238,
            DEBUG_CONTROL_SIGNALS_I16_2 = 3239,
            DEBUG_CONTROL_SIGNALS_I16_3 = 3240,
            DEBUG_CONTROL_SIGNALS_I16_4 = 3241,
            DEBUG_CONTROL_SIGNALS_I16_5 = 3242,
            DEBUG_CONTROL_SIGNALS_I16_6 = 3243,
            DEBUG_CONTROL_SIGNALS_I16_7 = 3244,
            DEBUG_CONTROL_SIGNALS_I16_8 = 3245,
            DEBUG_CONTROL_SIGNALS_I16_9 = 3246,
            DEBUG_CONTROL_SIGNALS_I16_10 = 3247,
            DEBUG_CONTROL_SIGNALS_I16_11 = 3248,
            DEBUG_CONTROL_SIGNALS_I16_12 = 3249,
            DEBUG_CONTROL_SIGNALS_I16_13 = 3250,
            DEBUG_CONTROL_SIGNALS_I16_14 = 3251,
            DEBUG_CONTROL_SIGNALS_I16_15 = 3252,
            DEBUG_CONTROL_SIGNALS_I16_16 = 3253,
            DEBUG_CONTROL_SIGNALS_I16_17 = 3254,
            DEBUG_CONTROL_SIGNALS_I16_18 = 3255,
            DEBUG_CONTROL_SIGNALS_I16_19 = 3256,
            DEBUG_CONTROL_SIGNALS_I16_20 = 3257,
            DEBUG_CONTROL_SIGNALS_I16_21 = 3258,
            DEBUG_CONTROL_SIGNALS_I16_22 = 3259,
            DEBUG_CONTROL_SIGNALS_I16_23 = 3260,
            DEBUG_CONTROL_SIGNALS_I16_24 = 3261,
            DEBUG_CONTROL_SIGNALS_I16_25 = 3262,
            DEBUG_CONTROL_SIGNALS_I16_26 = 3263,
            DEBUG_CONTROL_SIGNALS_I16_27 = 3264,
            DEBUG_CONTROL_SIGNALS_I16_28 = 3265,
            DEBUG_CONTROL_SIGNALS_I16_29 = 3266,
            DEBUG_CONTROL_SIGNALS_I16_30 = 3267,
            DEBUG_CONTROL_SIGNALS_I16_31 = 3268,
            DEBUG_CONTROL_SIGNALS_I16_32 = 3269,
            DEBUG_CONTROL_SIGNALS_I16_33 = 3270,
            DEBUG_CONTROL_SIGNALS_I16_34 = 3271,
            DEBUG_CONTROL_SIGNALS_I16_35 = 3272,
            DEBUG_CONTROL_SIGNALS_I16_36 = 3273,
            DEBUG_CONTROL_SIGNALS_I16_37 = 3274,
            DEBUG_CONTROL_SIGNALS_I16_38 = 3275,
            DEBUG_CONTROL_SIGNALS_I16_39 = 3276,
            DEBUG_CONTROL_SIGNALS_I16_40 = 3277,
            DEBUG_CONTROL_SIGNALS_I16_41 = 3278,
            DEBUG_CONTROL_SIGNALS_I16_42 = 3279,
            DEBUG_CONTROL_SIGNALS_I16_43 = 3280,
            DEBUG_CONTROL_SIGNALS_I16_44 = 3281,
            DEBUG_CONTROL_SIGNALS_I16_45 = 3282,
            DEBUG_CONTROL_SIGNALS_I16_46 = 3283,
            DEBUG_CONTROL_SIGNALS_I16_47 = 3284,
            DEBUG_CONTROL_SIGNALS_I16_48 = 3285,
            DEBUG_CONTROL_SIGNALS_I16_49 = 3286,
            OUTPUT_STABILIZATION_CYCLE_QTY = 3287,
            RAW_DATA_STABILIZATION_CYCLE_QTY = 3288,
            RUN_TIME_S = 3289,
            NORTH_FINDING1_EULER_ANGLE_0 = 3290,
            NORTH_FINDING1_EULER_ANGLE_1 = 3291,
            NORTH_FINDING1_EULER_ANGLE_2 = 3292,
            NORTH_FINDING1_EULER_ANGLE_I32_0 = 3293,
            NORTH_FINDING1_EULER_ANGLE_I32_1 = 3294,
            NORTH_FINDING1_EULER_ANGLE_I32_2 = 3295,
            NORTH_FINDING1_EULER_ANGLE_I32_RANGE = 3296,
            NORTH_FINDING1_MODE = 3297,
            NORTH_FINDING1_STATUS = 3298,
            NORTH_FINDING1_VERSION = 3299,
            NORTH_FINDING1_COUNTER = 3300,
            NORTH_FINDING1_TYPE = 3301,
            NORTH_FINDING1_GYRO_NUMBER = 3302,
            NORTH_FINDING1_ACC_NUMBER = 3303,
            NORTH_FINDING1_LLA_0 = 3304,
            NORTH_FINDING1_LLA_1 = 3305,
            NORTH_FINDING1_LLA_2 = 3306,
            NORTH_FINDING1_RESET_CMD = 3307,
            NORTH_FINDING1_TIME_S = 3308,
            NORTH_FINDING1_LIMIT_ACC_UG = 3309,
            NORTH_FINDING1_LIMIT_GYR_DPH = 3310,
            NORTH_FINDING1_MAX_QUEST_COUNTER = 3311,
            NORTH_FINDING1_RESET_QUEST_COUNTER = 3312,
            NORTH_FINDING1_ZVDCONFIG_THRESHOLD = 3313,
            NORTH_FINDING1_ZVDCONFIG_TIME_THRESHOLD = 3314,
            NORTH_FINDING1_INITIAL_NORTH_FINDING_TIME = 3315,
            NORTH_FINDING1_DURING_NORTH_FINDING_TIME = 3316,
            NORTH_FINDING1_IDLE_TIME = 3317,
            NORTH_FINDING1_ALIGN_TIME_S = 3318,
            OUTPUT_DECIMATION_RATE = 3319,
            TRANSFER_ALIGNMENT_DATA_0_IMU_EULER_ANGLE_0 = 3320,
            TRANSFER_ALIGNMENT_DATA_0_IMU_EULER_ANGLE_1 = 3321,
            TRANSFER_ALIGNMENT_DATA_0_IMU_EULER_ANGLE_2 = 3322,
            TRANSFER_ALIGNMENT_DATA_0_IMU_DELTA_ANGLE_0 = 3323,
            TRANSFER_ALIGNMENT_DATA_0_IMU_DELTA_ANGLE_1 = 3324,
            TRANSFER_ALIGNMENT_DATA_0_IMU_DELTA_ANGLE_2 = 3325,
            TRANSFER_ALIGNMENT_DATA_0_MODE = 3326,
            TRANSFER_ALIGNMENT_DATA_0_STATUS = 3327,
            TRANSFER_ALIGNMENT_DATA_0_VERSION = 3328,
            TRANSFER_ALIGNMENT_DATA_0_COUNTER = 3329,
            TRANSFER_ALIGNMENT_DATA_1_IMU_EULER_ANGLE_0 = 3330,
            TRANSFER_ALIGNMENT_DATA_1_IMU_EULER_ANGLE_1 = 3331,
            TRANSFER_ALIGNMENT_DATA_1_IMU_EULER_ANGLE_2 = 3332,
            TRANSFER_ALIGNMENT_DATA_1_IMU_DELTA_ANGLE_0 = 3333,
            TRANSFER_ALIGNMENT_DATA_1_IMU_DELTA_ANGLE_1 = 3334,
            TRANSFER_ALIGNMENT_DATA_1_IMU_DELTA_ANGLE_2 = 3335,
            TRANSFER_ALIGNMENT_DATA_1_MODE = 3336,
            TRANSFER_ALIGNMENT_DATA_1_STATUS = 3337,
            TRANSFER_ALIGNMENT_DATA_1_VERSION = 3338,
            TRANSFER_ALIGNMENT_DATA_1_COUNTER = 3339,
            TRANSFER_ALIGNMENT_DATA_2_IMU_EULER_ANGLE_0 = 3340,
            TRANSFER_ALIGNMENT_DATA_2_IMU_EULER_ANGLE_1 = 3341,
            TRANSFER_ALIGNMENT_DATA_2_IMU_EULER_ANGLE_2 = 3342,
            TRANSFER_ALIGNMENT_DATA_2_IMU_DELTA_ANGLE_0 = 3343,
            TRANSFER_ALIGNMENT_DATA_2_IMU_DELTA_ANGLE_1 = 3344,
            TRANSFER_ALIGNMENT_DATA_2_IMU_DELTA_ANGLE_2 = 3345,
            TRANSFER_ALIGNMENT_DATA_2_MODE = 3346,
            TRANSFER_ALIGNMENT_DATA_2_STATUS = 3347,
            TRANSFER_ALIGNMENT_DATA_2_VERSION = 3348,
            TRANSFER_ALIGNMENT_DATA_2_COUNTER = 3349,
            TRANSFER_ALIGNMENT_DATA_3_IMU_EULER_ANGLE_0 = 3350,
            TRANSFER_ALIGNMENT_DATA_3_IMU_EULER_ANGLE_1 = 3351,
            TRANSFER_ALIGNMENT_DATA_3_IMU_EULER_ANGLE_2 = 3352,
            TRANSFER_ALIGNMENT_DATA_3_IMU_DELTA_ANGLE_0 = 3353,
            TRANSFER_ALIGNMENT_DATA_3_IMU_DELTA_ANGLE_1 = 3354,
            TRANSFER_ALIGNMENT_DATA_3_IMU_DELTA_ANGLE_2 = 3355,
            TRANSFER_ALIGNMENT_DATA_3_MODE = 3356,
            TRANSFER_ALIGNMENT_DATA_3_STATUS = 3357,
            TRANSFER_ALIGNMENT_DATA_3_VERSION = 3358,
            TRANSFER_ALIGNMENT_DATA_3_COUNTER = 3359,
            TRANSFER_ALIGNMENT_DATA_4_IMU_EULER_ANGLE_0 = 3360,
            TRANSFER_ALIGNMENT_DATA_4_IMU_EULER_ANGLE_1 = 3361,
            TRANSFER_ALIGNMENT_DATA_4_IMU_EULER_ANGLE_2 = 3362,
            TRANSFER_ALIGNMENT_DATA_4_IMU_DELTA_ANGLE_0 = 3363,
            TRANSFER_ALIGNMENT_DATA_4_IMU_DELTA_ANGLE_1 = 3364,
            TRANSFER_ALIGNMENT_DATA_4_IMU_DELTA_ANGLE_2 = 3365,
            TRANSFER_ALIGNMENT_DATA_4_MODE = 3366,
            TRANSFER_ALIGNMENT_DATA_4_STATUS = 3367,
            TRANSFER_ALIGNMENT_DATA_4_VERSION = 3368,
            TRANSFER_ALIGNMENT_DATA_4_COUNTER = 3369,
            TRANSFER_ALIGNMENT_DATA_5_IMU_EULER_ANGLE_0 = 3370,
            TRANSFER_ALIGNMENT_DATA_5_IMU_EULER_ANGLE_1 = 3371,
            TRANSFER_ALIGNMENT_DATA_5_IMU_EULER_ANGLE_2 = 3372,
            TRANSFER_ALIGNMENT_DATA_5_IMU_DELTA_ANGLE_0 = 3373,
            TRANSFER_ALIGNMENT_DATA_5_IMU_DELTA_ANGLE_1 = 3374,
            TRANSFER_ALIGNMENT_DATA_5_IMU_DELTA_ANGLE_2 = 3375,
            TRANSFER_ALIGNMENT_DATA_5_MODE = 3376,
            TRANSFER_ALIGNMENT_DATA_5_STATUS = 3377,
            TRANSFER_ALIGNMENT_DATA_5_VERSION = 3378,
            TRANSFER_ALIGNMENT_DATA_5_COUNTER = 3379,
            TRANSFER_ALIGNMENT_DATA_6_IMU_EULER_ANGLE_0 = 3380,
            TRANSFER_ALIGNMENT_DATA_6_IMU_EULER_ANGLE_1 = 3381,
            TRANSFER_ALIGNMENT_DATA_6_IMU_EULER_ANGLE_2 = 3382,
            TRANSFER_ALIGNMENT_DATA_6_IMU_DELTA_ANGLE_0 = 3383,
            TRANSFER_ALIGNMENT_DATA_6_IMU_DELTA_ANGLE_1 = 3384,
            TRANSFER_ALIGNMENT_DATA_6_IMU_DELTA_ANGLE_2 = 3385,
            TRANSFER_ALIGNMENT_DATA_6_MODE = 3386,
            TRANSFER_ALIGNMENT_DATA_6_STATUS = 3387,
            TRANSFER_ALIGNMENT_DATA_6_VERSION = 3388,
            TRANSFER_ALIGNMENT_DATA_6_COUNTER = 3389,
            TRANSFER_ALIGNMENT_DATA_7_IMU_EULER_ANGLE_0 = 3390,
            TRANSFER_ALIGNMENT_DATA_7_IMU_EULER_ANGLE_1 = 3391,
            TRANSFER_ALIGNMENT_DATA_7_IMU_EULER_ANGLE_2 = 3392,
            TRANSFER_ALIGNMENT_DATA_7_IMU_DELTA_ANGLE_0 = 3393,
            TRANSFER_ALIGNMENT_DATA_7_IMU_DELTA_ANGLE_1 = 3394,
            TRANSFER_ALIGNMENT_DATA_7_IMU_DELTA_ANGLE_2 = 3395,
            TRANSFER_ALIGNMENT_DATA_7_MODE = 3396,
            TRANSFER_ALIGNMENT_DATA_7_STATUS = 3397,
            TRANSFER_ALIGNMENT_DATA_7_VERSION = 3398,
            TRANSFER_ALIGNMENT_DATA_7_COUNTER = 3399,
            TRANSFER_ALIGNMENT_DATA_8_IMU_EULER_ANGLE_0 = 3400,
            TRANSFER_ALIGNMENT_DATA_8_IMU_EULER_ANGLE_1 = 3401,
            TRANSFER_ALIGNMENT_DATA_8_IMU_EULER_ANGLE_2 = 3402,
            TRANSFER_ALIGNMENT_DATA_8_IMU_DELTA_ANGLE_0 = 3403,
            TRANSFER_ALIGNMENT_DATA_8_IMU_DELTA_ANGLE_1 = 3404,
            TRANSFER_ALIGNMENT_DATA_8_IMU_DELTA_ANGLE_2 = 3405,
            TRANSFER_ALIGNMENT_DATA_8_MODE = 3406,
            TRANSFER_ALIGNMENT_DATA_8_STATUS = 3407,
            TRANSFER_ALIGNMENT_DATA_8_VERSION = 3408,
            TRANSFER_ALIGNMENT_DATA_8_COUNTER = 3409,
            TRANSFER_ALIGNMENT_DATA_9_IMU_EULER_ANGLE_0 = 3410,
            TRANSFER_ALIGNMENT_DATA_9_IMU_EULER_ANGLE_1 = 3411,
            TRANSFER_ALIGNMENT_DATA_9_IMU_EULER_ANGLE_2 = 3412,
            TRANSFER_ALIGNMENT_DATA_9_IMU_DELTA_ANGLE_0 = 3413,
            TRANSFER_ALIGNMENT_DATA_9_IMU_DELTA_ANGLE_1 = 3414,
            TRANSFER_ALIGNMENT_DATA_9_IMU_DELTA_ANGLE_2 = 3415,
            TRANSFER_ALIGNMENT_DATA_9_MODE = 3416,
            TRANSFER_ALIGNMENT_DATA_9_STATUS = 3417,
            TRANSFER_ALIGNMENT_DATA_9_VERSION = 3418,
            TRANSFER_ALIGNMENT_DATA_9_COUNTER = 3419,
            SENSOR_ACC_X = 3420,
            SENSOR_ACC_Y = 3421,
            SENSOR_ACC_Z = 3422,
            SENSOR_ACC_I32_X = 3423,
            SENSOR_ACC_I32_Y = 3424,
            SENSOR_ACC_I32_Z = 3425,
            SENSOR_ACC_I32_RANGE = 3426,
            SENSOR_GYRO_X = 3427,
            SENSOR_GYRO_Y = 3428,
            SENSOR_GYRO_Z = 3429,
            SENSOR_GYRO_I32_X = 3430,
            SENSOR_GYRO_I32_Y = 3431,
            SENSOR_GYRO_I32_Z = 3432,
            SENSOR_GYRO_I32_RANGE = 3433,
            SENSOR_TEMPERATURE = 3434,
            SENSOR_TEMPERATURE_I16 = 3435,
            SENSOR_TEMPERATURE_I16_RANGE = 3436,
            CALC_FAULT_DETECTION_WARM_UP_TEMP_RATE_WARNING_LEVEL = 3437,
            CALC_FAULT_DETECTION_AFTER_WARM_UP_TEMP_RATE_WARNING_LEVEL = 3438,
            CALC_FAULT_DETECTION_INIT_IDLE_TIME_S = 3439,
            CALC_FAULT_DETECTION_ADDED_WARM_UP_TIME_S = 3440,
            CALC_FAULT_DETECTION_AFTER_ALG_RESET_IDLE_TIME_S = 3441,
            CALC_FAULT_DETECTION_COUNTER = 3442,
            CALC_FAULT_DETECTION_VERSION_MAJOR = 3443,
            CALC_FAULT_DETECTION_VERSION_MINOR = 3444,
            CALC_FAULT_DETECTION_VERSION_BUILD1 = 3445,
            CALC_FAULT_DETECTION_VERSION_BUILD2 = 3446,
            CALC_FAULT_DETECTION_FAULT_STATUS_0 = 3447,
            CALC_FAULT_DETECTION_FAULT_STATUS_1 = 3448,
            CALC_FAULT_DETECTION_FAULT_STATUS_2 = 3449,
            CALC_FAULT_DETECTION_FAULT_STATUS_3 = 3450,
            CALC_FAULT_DETECTION_WARNING_STATUS_0 = 3451,
            CALC_FAULT_DETECTION_WARNING_STATUS_1 = 3452,
            CALC_FAULT_DETECTION_WARNING_STATUS_2 = 3453,
            CALC_FAULT_DETECTION_WARNING_STATUS_3 = 3454,
            ROTATION_COORDINATE_ANGLES_DEGREE_0 = 3455,
            ROTATION_COORDINATE_ANGLES_DEGREE_1 = 3456,
            ROTATION_COORDINATE_ANGLES_DEGREE_2 = 3457,
            CALC_PRE_PROCESS_ALGORITHM_ACC_X = 3458,
            CALC_PRE_PROCESS_ALGORITHM_ACC_Y = 3459,
            CALC_PRE_PROCESS_ALGORITHM_ACC_Z = 3460,
            CALC_PRE_PROCESS_ALGORITHM_GYRO_X = 3461,
            CALC_PRE_PROCESS_ALGORITHM_GYRO_Y = 3462,
            CALC_PRE_PROCESS_ALGORITHM_GYRO_Z = 3463,
            CALC_PRE_PROCESS_ALGORITHM_ACC_I32_X = 3464,
            CALC_PRE_PROCESS_ALGORITHM_ACC_I32_Y = 3465,
            CALC_PRE_PROCESS_ALGORITHM_ACC_I32_Z = 3466,
            CALC_PRE_PROCESS_ALGORITHM_GYRO_I32_X = 3467,
            CALC_PRE_PROCESS_ALGORITHM_GYRO_I32_Y = 3468,
            CALC_PRE_PROCESS_ALGORITHM_GYRO_I32_Z = 3469,
            CALC_PRE_PROCESS_ALGORITHM_ACC_I32_RANGE = 3470,
            CALC_PRE_PROCESS_ALGORITHM_GYRO_I32_RANGE = 3471,
            CALC_PRE_PROCESS_ALGORITHM_VERSION_MAJOR = 3472,
            CALC_PRE_PROCESS_ALGORITHM_VERSION_MINOR = 3473,
            CALC_PRE_PROCESS_ALGORITHM_VERSION_BUILD1 = 3474,
            CALC_PRE_PROCESS_ALGORITHM_VERSION_BUILD2 = 3475,
            GENERAL_STATUS_SUMMARY = 3476,
            NONE = 65535
        }

        public enum eParameterMbAddr : ushort
        {
            PARAMETER_MB_ADDR_DEVICE_ID = 0,
            PARAMETER_MB_ADDR_PARAMETER_LIST_VERSION = 1,
            PARAMETER_MB_ADDR_FW_VERSION_MAJOR = 2,
            PARAMETER_MB_ADDR_FW_VERSION_MINOR = 3,
            PARAMETER_MB_ADDR_FW_VERSION_BUILD1 = 4,
            PARAMETER_MB_ADDR_FW_VERSION_BUILD2_0 = 5,
            PARAMETER_MB_ADDR_FW_VERSION_BUILD2_1 = 6,
            PARAMETER_MB_ADDR_SERIAL_NO_0 = 7,
            PARAMETER_MB_ADDR_SERIAL_NO_1 = 8,
            PARAMETER_MB_ADDR_HW_VERSION_MAJOR = 9,
            PARAMETER_MB_ADDR_HW_VERSION_MINOR = 10,
            PARAMETER_MB_ADDR_PRODUCTION_YEAR = 11,
            PARAMETER_MB_ADDR_PRODUCTION_MONTH = 12,
            PARAMETER_MB_ADDR_PRODUCTION_DAY = 13,
            PARAMETER_MB_ADDR_DOWN_STREAM_QTY = 14,
            PARAMETER_MB_ADDR_DOWN_STREAMS_START_ADDR = 15,
            PARAMETER_MB_ADDR_DOWN_STREAMS_SETTING_SIZE = 16,
            PARAMETER_MB_ADDR_RESERVE0_0 = 17,
            PARAMETER_MB_ADDR_RESERVE0_1 = 18,
            PARAMETER_MB_ADDR_RESERVE0_2 = 19,
            PARAMETER_MB_ADDR_RESERVE0_3 = 20,
            PARAMETER_MB_ADDR_RESERVE0_4 = 21,
            PARAMETER_MB_ADDR_RESERVE0_5 = 22,
            PARAMETER_MB_ADDR_RESERVE0_6 = 23,
            PARAMETER_MB_ADDR_RESERVE0_7 = 24,
            PARAMETER_MB_ADDR_RESERVE0_8 = 25,
            PARAMETER_MB_ADDR_RESERVE0_9 = 26,
            PARAMETER_MB_ADDR_RESERVE0_10 = 27,
            PARAMETER_MB_ADDR_RESERVE0_11 = 28,
            PARAMETER_MB_ADDR_RESERVE0_12 = 29,
            PARAMETER_MB_ADDR_RESERVE0_13 = 30,
            PARAMETER_MB_ADDR_RESERVE0_14 = 31,
            PARAMETER_MB_ADDR_RESERVE0_15 = 32,
            PARAMETER_MB_ADDR_RESERVE0_16 = 33,
            PARAMETER_MB_ADDR_RESERVE0_17 = 34,
            PARAMETER_MB_ADDR_RESERVE0_18 = 35,
            PARAMETER_MB_ADDR_RESERVE0_19 = 36,
            PARAMETER_MB_ADDR_RESERVE0_20 = 37,
            PARAMETER_MB_ADDR_RESERVE0_21 = 38,
            PARAMETER_MB_ADDR_RESERVE0_22 = 39,
            PARAMETER_MB_ADDR_RESERVE0_23 = 40,
            PARAMETER_MB_ADDR_RESERVE0_24 = 41,
            PARAMETER_MB_ADDR_RESERVE0_25 = 42,
            PARAMETER_MB_ADDR_RESERVE0_26 = 43,
            PARAMETER_MB_ADDR_RESERVE0_27 = 44,
            PARAMETER_MB_ADDR_RESERVE0_28 = 45,
            PARAMETER_MB_ADDR_RESERVE0_29 = 46,
            PARAMETER_MB_ADDR_RESERVE0_30 = 47,
            PARAMETER_MB_ADDR_RESERVE0_31 = 48,
            PARAMETER_MB_ADDR_RESERVE0_32 = 49,
            PARAMETER_MB_ADDR_RESERVE0_33 = 50,
            PARAMETER_MB_ADDR_RESERVE0_34 = 51,
            PARAMETER_MB_ADDR_RESERVE0_35 = 52,
            PARAMETER_MB_ADDR_RESERVE0_36 = 53,
            PARAMETER_MB_ADDR_RESERVE0_37 = 54,
            PARAMETER_MB_ADDR_RESERVE0_38 = 55,
            PARAMETER_MB_ADDR_RESERVE0_39 = 56,
            PARAMETER_MB_ADDR_RESERVE0_40 = 57,
            PARAMETER_MB_ADDR_RESERVE0_41 = 58,
            PARAMETER_MB_ADDR_RESERVE0_42 = 59,
            PARAMETER_MB_ADDR_RESERVE0_43 = 60,
            PARAMETER_MB_ADDR_RESERVE0_44 = 61,
            PARAMETER_MB_ADDR_RESERVE0_45 = 62,
            PARAMETER_MB_ADDR_RESERVE0_46 = 63,
            PARAMETER_MB_ADDR_RESERVE0_47 = 64,
            PARAMETER_MB_ADDR_RESERVE0_48 = 65,
            PARAMETER_MB_ADDR_RESERVE0_49 = 66,
            PARAMETER_MB_ADDR_RESERVE0_50 = 67,
            PARAMETER_MB_ADDR_RESERVE0_51 = 68,
            PARAMETER_MB_ADDR_RESERVE0_52 = 69,
            PARAMETER_MB_ADDR_RESERVE0_53 = 70,
            PARAMETER_MB_ADDR_RESERVE0_54 = 71,
            PARAMETER_MB_ADDR_RESERVE0_55 = 72,
            PARAMETER_MB_ADDR_RESERVE0_56 = 73,
            PARAMETER_MB_ADDR_RESERVE0_57 = 74,
            PARAMETER_MB_ADDR_RESERVE0_58 = 75,
            PARAMETER_MB_ADDR_RESERVE0_59 = 76,
            PARAMETER_MB_ADDR_RESERVE0_60 = 77,
            PARAMETER_MB_ADDR_RESERVE0_61 = 78,
            PARAMETER_MB_ADDR_RESERVE0_62 = 79,
            PARAMETER_MB_ADDR_RESERVE0_63 = 80,
            PARAMETER_MB_ADDR_RESERVE0_64 = 81,
            PARAMETER_MB_ADDR_RESERVE0_65 = 82,
            PARAMETER_MB_ADDR_RESERVE0_66 = 83,
            PARAMETER_MB_ADDR_RESERVE0_67 = 84,
            PARAMETER_MB_ADDR_RESERVE0_68 = 85,
            PARAMETER_MB_ADDR_RESERVE0_69 = 86,
            PARAMETER_MB_ADDR_RESERVE0_70 = 87,
            PARAMETER_MB_ADDR_RESERVE0_71 = 88,
            PARAMETER_MB_ADDR_RESERVE0_72 = 89,
            PARAMETER_MB_ADDR_RESERVE0_73 = 90,
            PARAMETER_MB_ADDR_RESERVE0_74 = 91,
            PARAMETER_MB_ADDR_RESERVE0_75 = 92,
            PARAMETER_MB_ADDR_RESERVE0_76 = 93,
            PARAMETER_MB_ADDR_RESERVE0_77 = 94,
            PARAMETER_MB_ADDR_RESERVE0_78 = 95,
            PARAMETER_MB_ADDR_RESERVE0_79 = 96,
            PARAMETER_MB_ADDR_RESERVE0_80 = 97,
            PARAMETER_MB_ADDR_RESERVE0_81 = 98,
            PARAMETER_MB_ADDR_RESERVE0_82 = 99,
            PARAMETER_MB_ADDR_RESERVE0_83 = 100,
            PARAMETER_MB_ADDR_RESERVE0_84 = 101,
            PARAMETER_MB_ADDR_RESERVE0_85 = 102,
            PARAMETER_MB_ADDR_RESERVE0_86 = 103,
            PARAMETER_MB_ADDR_RESERVE0_87 = 104,
            PARAMETER_MB_ADDR_RESERVE0_88 = 105,
            PARAMETER_MB_ADDR_RESERVE0_89 = 106,
            PARAMETER_MB_ADDR_RESERVE0_90 = 107,
            PARAMETER_MB_ADDR_RESERVE0_91 = 108,
            PARAMETER_MB_ADDR_RESERVE0_92 = 109,
            PARAMETER_MB_ADDR_RESERVE0_93 = 110,
            PARAMETER_MB_ADDR_RESERVE0_94 = 111,
            PARAMETER_MB_ADDR_RESERVE0_95 = 112,
            PARAMETER_MB_ADDR_RESERVE0_96 = 113,
            PARAMETER_MB_ADDR_RESERVE0_97 = 114,
            PARAMETER_MB_ADDR_RESERVE0_98 = 115,
            PARAMETER_MB_ADDR_RESERVE0_99 = 116,
            PARAMETER_MB_ADDR_RESERVE0_100 = 117,
            PARAMETER_MB_ADDR_RESERVE0_101 = 118,
            PARAMETER_MB_ADDR_RESERVE0_102 = 119,
            PARAMETER_MB_ADDR_RESERVE0_103 = 120,
            PARAMETER_MB_ADDR_RESERVE0_104 = 121,
            PARAMETER_MB_ADDR_RESERVE0_105 = 122,
            PARAMETER_MB_ADDR_RESERVE0_106 = 123,
            PARAMETER_MB_ADDR_RESERVE0_107 = 124,
            PARAMETER_MB_ADDR_RESERVE0_108 = 125,
            PARAMETER_MB_ADDR_RESERVE0_109 = 126,
            PARAMETER_MB_ADDR_RESERVE0_110 = 127,
            PARAMETER_MB_ADDR_RESERVE0_111 = 128,
            PARAMETER_MB_ADDR_RESERVE0_112 = 129,
            PARAMETER_MB_ADDR_RESERVE0_113 = 130,
            PARAMETER_MB_ADDR_RESERVE0_114 = 131,
            PARAMETER_MB_ADDR_RESERVE0_115 = 132,
            PARAMETER_MB_ADDR_RESERVE0_116 = 133,
            PARAMETER_MB_ADDR_RESERVE0_117 = 134,
            PARAMETER_MB_ADDR_RESERVE0_118 = 135,
            PARAMETER_MB_ADDR_RESERVE0_119 = 136,
            PARAMETER_MB_ADDR_RESERVE0_120 = 137,
            PARAMETER_MB_ADDR_RESERVE0_121 = 138,
            PARAMETER_MB_ADDR_RESERVE0_122 = 139,
            PARAMETER_MB_ADDR_RESERVE0_123 = 140,
            PARAMETER_MB_ADDR_RESERVE0_124 = 141,
            PARAMETER_MB_ADDR_RESERVE0_125 = 142,
            PARAMETER_MB_ADDR_RESERVE0_126 = 143,
            PARAMETER_MB_ADDR_RESERVE0_127 = 144,
            PARAMETER_MB_ADDR_RESERVE0_128 = 145,
            PARAMETER_MB_ADDR_RESERVE0_129 = 146,
            PARAMETER_MB_ADDR_RESERVE0_130 = 147,
            PARAMETER_MB_ADDR_RESERVE0_131 = 148,
            PARAMETER_MB_ADDR_RESERVE0_132 = 149,
            PARAMETER_MB_ADDR_RESERVE0_133 = 150,
            PARAMETER_MB_ADDR_RESERVE0_134 = 151,
            PARAMETER_MB_ADDR_RESERVE0_135 = 152,
            PARAMETER_MB_ADDR_RESERVE0_136 = 153,
            PARAMETER_MB_ADDR_RESERVE0_137 = 154,
            PARAMETER_MB_ADDR_RESERVE0_138 = 155,
            PARAMETER_MB_ADDR_RESERVE0_139 = 156,
            PARAMETER_MB_ADDR_RESERVE0_140 = 157,
            PARAMETER_MB_ADDR_RESERVE0_141 = 158,
            PARAMETER_MB_ADDR_RESERVE0_142 = 159,
            PARAMETER_MB_ADDR_RESERVE0_143 = 160,
            PARAMETER_MB_ADDR_RESERVE0_144 = 161,
            PARAMETER_MB_ADDR_RESERVE0_145 = 162,
            PARAMETER_MB_ADDR_RESERVE0_146 = 163,
            PARAMETER_MB_ADDR_RESERVE0_147 = 164,
            PARAMETER_MB_ADDR_RESERVE0_148 = 165,
            PARAMETER_MB_ADDR_RESERVE0_149 = 166,
            PARAMETER_MB_ADDR_RESERVE0_150 = 167,
            PARAMETER_MB_ADDR_RESERVE0_151 = 168,
            PARAMETER_MB_ADDR_RESERVE0_152 = 169,
            PARAMETER_MB_ADDR_RESERVE0_153 = 170,
            PARAMETER_MB_ADDR_RESERVE0_154 = 171,
            PARAMETER_MB_ADDR_RESERVE0_155 = 172,
            PARAMETER_MB_ADDR_RESERVE0_156 = 173,
            PARAMETER_MB_ADDR_RESERVE0_157 = 174,
            PARAMETER_MB_ADDR_RESERVE0_158 = 175,
            PARAMETER_MB_ADDR_RESERVE0_159 = 176,
            PARAMETER_MB_ADDR_RESERVE0_160 = 177,
            PARAMETER_MB_ADDR_RESERVE0_161 = 178,
            PARAMETER_MB_ADDR_RESERVE0_162 = 179,
            PARAMETER_MB_ADDR_RESERVE0_163 = 180,
            PARAMETER_MB_ADDR_RESERVE0_164 = 181,
            PARAMETER_MB_ADDR_RESERVE0_165 = 182,
            PARAMETER_MB_ADDR_RESERVE0_166 = 183,
            PARAMETER_MB_ADDR_RESERVE0_167 = 184,
            PARAMETER_MB_ADDR_RESERVE0_168 = 185,
            PARAMETER_MB_ADDR_RESERVE0_169 = 186,
            PARAMETER_MB_ADDR_RESERVE0_170 = 187,
            PARAMETER_MB_ADDR_RESERVE0_171 = 188,
            PARAMETER_MB_ADDR_RESERVE0_172 = 189,
            PARAMETER_MB_ADDR_RESERVE0_173 = 190,
            PARAMETER_MB_ADDR_RESERVE0_174 = 191,
            PARAMETER_MB_ADDR_RESERVE0_175 = 192,
            PARAMETER_MB_ADDR_RESERVE0_176 = 193,
            PARAMETER_MB_ADDR_RESERVE0_177 = 194,
            PARAMETER_MB_ADDR_RESERVE0_178 = 195,
            PARAMETER_MB_ADDR_RESERVE0_179 = 196,
            PARAMETER_MB_ADDR_RESERVE0_180 = 197,
            PARAMETER_MB_ADDR_RESERVE0_181 = 198,
            PARAMETER_MB_ADDR_RESERVE0_182 = 199,
            PARAMETER_MB_ADDR_MEMORY_RETRY_QTY = 200,
            PARAMETER_MB_ADDR_MEMORY_RETRY_DELAY_MS = 201,
            PARAMETER_MB_ADDR_RESTORE_DEFAULT_VALUE = 202,
            PARAMETER_MB_ADDR_LOAD_ALL = 203,
            PARAMETER_MB_ADDR_LOAD_ALL_MEMORY_RESULT_0 = 204,
            PARAMETER_MB_ADDR_LOAD_ALL_MEMORY_RESULT_1 = 205,
            PARAMETER_MB_ADDR_LOAD_INFO = 206,
            PARAMETER_MB_ADDR_LOAD_MODBUS_EXT = 207,
            PARAMETER_MB_ADDR_LOAD_HARDWARE_CONFIGURATION = 208,
            PARAMETER_MB_ADDR_LOAD_FUNCTIONAL = 209,
            PARAMETER_MB_ADDR_LOAD_SENSOR_CALIB_COEF = 210,
            PARAMETER_MB_ADDR_LOAD_OUTPUT_CALIB_COEF = 211,
            PARAMETER_MB_ADDR_LOAD_OUTPUT_ROTATION = 212,
            PARAMETER_MB_ADDR_LOAD_WITH_FORCE_ALL = 213,
            PARAMETER_MB_ADDR_LOAD_WITH_FORCE_INFO = 214,
            PARAMETER_MB_ADDR_LOAD_WITH_FORCE_MODBUS_EXT = 215,
            PARAMETER_MB_ADDR_LOAD_WITH_FORCE_HARDWARE_CONFIGURATION = 216,
            PARAMETER_MB_ADDR_LOAD_WITH_FORCE_FUNCTIONAL = 217,
            PARAMETER_MB_ADDR_LOAD_WITH_FORCE_SENSOR_CALIB_COEF = 218,
            PARAMETER_MB_ADDR_LOAD_WITH_FORCE_OUTPUT_CALIB_COEF = 219,
            PARAMETER_MB_ADDR_LOAD_WITH_FORCE_OUTPUT_ROTATION = 220,
            PARAMETER_MB_ADDR_SAVE_ALL = 221,
            PARAMETER_MB_ADDR_SAVE_ALL_MEMORY_RESULT_0 = 222,
            PARAMETER_MB_ADDR_SAVE_ALL_MEMORY_RESULT_1 = 223,
            PARAMETER_MB_ADDR_SAVE_INFO = 224,
            PARAMETER_MB_ADDR_SAVE_MODBUS_EXT = 225,
            PARAMETER_MB_ADDR_SAVE_HARDWARE_CONFIGURATION = 226,
            PARAMETER_MB_ADDR_SAVE_FUNCTIONAL = 227,
            PARAMETER_MB_ADDR_SAVE_SENSOR_CALIB_COEF = 228,
            PARAMETER_MB_ADDR_SAVE_OUTPUT_CALIB_COEF = 229,
            PARAMETER_MB_ADDR_SAVE_OUTPUT_ROTATION = 230,
            PARAMETER_MB_ADDR_RESERVE1_0 = 231,
            PARAMETER_MB_ADDR_RESERVE1_1 = 232,
            PARAMETER_MB_ADDR_RESERVE1_2 = 233,
            PARAMETER_MB_ADDR_RESERVE1_3 = 234,
            PARAMETER_MB_ADDR_RESERVE1_4 = 235,
            PARAMETER_MB_ADDR_RESERVE1_5 = 236,
            PARAMETER_MB_ADDR_RESERVE1_6 = 237,
            PARAMETER_MB_ADDR_RESERVE1_7 = 238,
            PARAMETER_MB_ADDR_RESERVE1_8 = 239,
            PARAMETER_MB_ADDR_RESERVE1_9 = 240,
            PARAMETER_MB_ADDR_RESERVE1_10 = 241,
            PARAMETER_MB_ADDR_RESERVE1_11 = 242,
            PARAMETER_MB_ADDR_RESERVE1_12 = 243,
            PARAMETER_MB_ADDR_RESERVE1_13 = 244,
            PARAMETER_MB_ADDR_RESERVE1_14 = 245,
            PARAMETER_MB_ADDR_RESERVE1_15 = 246,
            PARAMETER_MB_ADDR_RESERVE1_16 = 247,
            PARAMETER_MB_ADDR_RESERVE1_17 = 248,
            PARAMETER_MB_ADDR_RESERVE1_18 = 249,
            PARAMETER_MB_ADDR_RESERVE1_19 = 250,
            PARAMETER_MB_ADDR_RESERVE1_20 = 251,
            PARAMETER_MB_ADDR_RESERVE1_21 = 252,
            PARAMETER_MB_ADDR_RESERVE1_22 = 253,
            PARAMETER_MB_ADDR_RESERVE1_23 = 254,
            PARAMETER_MB_ADDR_RESERVE1_24 = 255,
            PARAMETER_MB_ADDR_RESERVE1_25 = 256,
            PARAMETER_MB_ADDR_RESERVE1_26 = 257,
            PARAMETER_MB_ADDR_RESERVE1_27 = 258,
            PARAMETER_MB_ADDR_RESERVE1_28 = 259,
            PARAMETER_MB_ADDR_RESERVE1_29 = 260,
            PARAMETER_MB_ADDR_RESERVE1_30 = 261,
            PARAMETER_MB_ADDR_RESERVE1_31 = 262,
            PARAMETER_MB_ADDR_RESERVE1_32 = 263,
            PARAMETER_MB_ADDR_RESERVE1_33 = 264,
            PARAMETER_MB_ADDR_RESERVE1_34 = 265,
            PARAMETER_MB_ADDR_RESERVE1_35 = 266,
            PARAMETER_MB_ADDR_RESERVE1_36 = 267,
            PARAMETER_MB_ADDR_RESERVE1_37 = 268,
            PARAMETER_MB_ADDR_RESERVE1_38 = 269,
            PARAMETER_MB_ADDR_RESERVE1_39 = 270,
            PARAMETER_MB_ADDR_RESERVE1_40 = 271,
            PARAMETER_MB_ADDR_RESERVE1_41 = 272,
            PARAMETER_MB_ADDR_RESERVE1_42 = 273,
            PARAMETER_MB_ADDR_RESERVE1_43 = 274,
            PARAMETER_MB_ADDR_RESERVE1_44 = 275,
            PARAMETER_MB_ADDR_RESERVE1_45 = 276,
            PARAMETER_MB_ADDR_RESERVE1_46 = 277,
            PARAMETER_MB_ADDR_RESERVE1_47 = 278,
            PARAMETER_MB_ADDR_RESERVE1_48 = 279,
            PARAMETER_MB_ADDR_RESERVE1_49 = 280,
            PARAMETER_MB_ADDR_RESERVE1_50 = 281,
            PARAMETER_MB_ADDR_RESERVE1_51 = 282,
            PARAMETER_MB_ADDR_RESERVE1_52 = 283,
            PARAMETER_MB_ADDR_RESERVE1_53 = 284,
            PARAMETER_MB_ADDR_RESERVE1_54 = 285,
            PARAMETER_MB_ADDR_RESERVE1_55 = 286,
            PARAMETER_MB_ADDR_RESERVE1_56 = 287,
            PARAMETER_MB_ADDR_RESERVE1_57 = 288,
            PARAMETER_MB_ADDR_RESERVE1_58 = 289,
            PARAMETER_MB_ADDR_RESERVE1_59 = 290,
            PARAMETER_MB_ADDR_RESERVE1_60 = 291,
            PARAMETER_MB_ADDR_RESERVE1_61 = 292,
            PARAMETER_MB_ADDR_RESERVE1_62 = 293,
            PARAMETER_MB_ADDR_RESERVE1_63 = 294,
            PARAMETER_MB_ADDR_RESERVE1_64 = 295,
            PARAMETER_MB_ADDR_RESERVE1_65 = 296,
            PARAMETER_MB_ADDR_RESERVE1_66 = 297,
            PARAMETER_MB_ADDR_RESERVE1_67 = 298,
            PARAMETER_MB_ADDR_RESERVE1_68 = 299,
            PARAMETER_MB_ADDR_RESERVE1_69 = 300,
            PARAMETER_MB_ADDR_RESERVE1_70 = 301,
            PARAMETER_MB_ADDR_RESERVE1_71 = 302,
            PARAMETER_MB_ADDR_RESERVE1_72 = 303,
            PARAMETER_MB_ADDR_RESERVE1_73 = 304,
            PARAMETER_MB_ADDR_RESERVE1_74 = 305,
            PARAMETER_MB_ADDR_RESERVE1_75 = 306,
            PARAMETER_MB_ADDR_RESERVE1_76 = 307,
            PARAMETER_MB_ADDR_RESERVE1_77 = 308,
            PARAMETER_MB_ADDR_RESERVE1_78 = 309,
            PARAMETER_MB_ADDR_RESERVE1_79 = 310,
            PARAMETER_MB_ADDR_RESERVE1_80 = 311,
            PARAMETER_MB_ADDR_RESERVE1_81 = 312,
            PARAMETER_MB_ADDR_RESERVE1_82 = 313,
            PARAMETER_MB_ADDR_RESERVE1_83 = 314,
            PARAMETER_MB_ADDR_RESERVE1_84 = 315,
            PARAMETER_MB_ADDR_RESERVE1_85 = 316,
            PARAMETER_MB_ADDR_RESERVE1_86 = 317,
            PARAMETER_MB_ADDR_RESERVE1_87 = 318,
            PARAMETER_MB_ADDR_RESERVE1_88 = 319,
            PARAMETER_MB_ADDR_RESERVE1_89 = 320,
            PARAMETER_MB_ADDR_RESERVE1_90 = 321,
            PARAMETER_MB_ADDR_RESERVE1_91 = 322,
            PARAMETER_MB_ADDR_RESERVE1_92 = 323,
            PARAMETER_MB_ADDR_RESERVE1_93 = 324,
            PARAMETER_MB_ADDR_RESERVE1_94 = 325,
            PARAMETER_MB_ADDR_RESERVE1_95 = 326,
            PARAMETER_MB_ADDR_RESERVE1_96 = 327,
            PARAMETER_MB_ADDR_RESERVE1_97 = 328,
            PARAMETER_MB_ADDR_RESERVE1_98 = 329,
            PARAMETER_MB_ADDR_RESERVE1_99 = 330,
            PARAMETER_MB_ADDR_RESERVE1_100 = 331,
            PARAMETER_MB_ADDR_RESERVE1_101 = 332,
            PARAMETER_MB_ADDR_RESERVE1_102 = 333,
            PARAMETER_MB_ADDR_RESERVE1_103 = 334,
            PARAMETER_MB_ADDR_RESERVE1_104 = 335,
            PARAMETER_MB_ADDR_RESERVE1_105 = 336,
            PARAMETER_MB_ADDR_RESERVE1_106 = 337,
            PARAMETER_MB_ADDR_RESERVE1_107 = 338,
            PARAMETER_MB_ADDR_RESERVE1_108 = 339,
            PARAMETER_MB_ADDR_RESERVE1_109 = 340,
            PARAMETER_MB_ADDR_RESERVE1_110 = 341,
            PARAMETER_MB_ADDR_RESERVE1_111 = 342,
            PARAMETER_MB_ADDR_RESERVE1_112 = 343,
            PARAMETER_MB_ADDR_RESERVE1_113 = 344,
            PARAMETER_MB_ADDR_RESERVE1_114 = 345,
            PARAMETER_MB_ADDR_RESERVE1_115 = 346,
            PARAMETER_MB_ADDR_RESERVE1_116 = 347,
            PARAMETER_MB_ADDR_RESERVE1_117 = 348,
            PARAMETER_MB_ADDR_RESERVE1_118 = 349,
            PARAMETER_MB_ADDR_RESERVE1_119 = 350,
            PARAMETER_MB_ADDR_RESERVE1_120 = 351,
            PARAMETER_MB_ADDR_RESERVE1_121 = 352,
            PARAMETER_MB_ADDR_RESERVE1_122 = 353,
            PARAMETER_MB_ADDR_RESERVE1_123 = 354,
            PARAMETER_MB_ADDR_RESERVE1_124 = 355,
            PARAMETER_MB_ADDR_RESERVE1_125 = 356,
            PARAMETER_MB_ADDR_RESERVE1_126 = 357,
            PARAMETER_MB_ADDR_RESERVE1_127 = 358,
            PARAMETER_MB_ADDR_RESERVE1_128 = 359,
            PARAMETER_MB_ADDR_RESERVE1_129 = 360,
            PARAMETER_MB_ADDR_RESERVE1_130 = 361,
            PARAMETER_MB_ADDR_RESERVE1_131 = 362,
            PARAMETER_MB_ADDR_RESERVE1_132 = 363,
            PARAMETER_MB_ADDR_RESERVE1_133 = 364,
            PARAMETER_MB_ADDR_RESERVE1_134 = 365,
            PARAMETER_MB_ADDR_RESERVE1_135 = 366,
            PARAMETER_MB_ADDR_RESERVE1_136 = 367,
            PARAMETER_MB_ADDR_RESERVE1_137 = 368,
            PARAMETER_MB_ADDR_RESERVE1_138 = 369,
            PARAMETER_MB_ADDR_RESERVE1_139 = 370,
            PARAMETER_MB_ADDR_RESERVE1_140 = 371,
            PARAMETER_MB_ADDR_RESERVE1_141 = 372,
            PARAMETER_MB_ADDR_RESERVE1_142 = 373,
            PARAMETER_MB_ADDR_RESERVE1_143 = 374,
            PARAMETER_MB_ADDR_RESERVE1_144 = 375,
            PARAMETER_MB_ADDR_RESERVE1_145 = 376,
            PARAMETER_MB_ADDR_RESERVE1_146 = 377,
            PARAMETER_MB_ADDR_RESERVE1_147 = 378,
            PARAMETER_MB_ADDR_RESERVE1_148 = 379,
            PARAMETER_MB_ADDR_RESERVE1_149 = 380,
            PARAMETER_MB_ADDR_RESERVE1_150 = 381,
            PARAMETER_MB_ADDR_RESERVE1_151 = 382,
            PARAMETER_MB_ADDR_RESERVE1_152 = 383,
            PARAMETER_MB_ADDR_RESERVE1_153 = 384,
            PARAMETER_MB_ADDR_RESERVE1_154 = 385,
            PARAMETER_MB_ADDR_RESERVE1_155 = 386,
            PARAMETER_MB_ADDR_RESERVE1_156 = 387,
            PARAMETER_MB_ADDR_RESERVE1_157 = 388,
            PARAMETER_MB_ADDR_RESERVE1_158 = 389,
            PARAMETER_MB_ADDR_RESERVE1_159 = 390,
            PARAMETER_MB_ADDR_RESERVE1_160 = 391,
            PARAMETER_MB_ADDR_RESERVE1_161 = 392,
            PARAMETER_MB_ADDR_RESERVE1_162 = 393,
            PARAMETER_MB_ADDR_RESERVE1_163 = 394,
            PARAMETER_MB_ADDR_RESERVE1_164 = 395,
            PARAMETER_MB_ADDR_RESERVE1_165 = 396,
            PARAMETER_MB_ADDR_RESERVE1_166 = 397,
            PARAMETER_MB_ADDR_RESERVE1_167 = 398,
            PARAMETER_MB_ADDR_RESERVE1_168 = 399,
            PARAMETER_MB_ADDR_WATCHDOG_TIME_MS = 400,
            PARAMETER_MB_ADDR_RESET_SOURCE = 401,
            PARAMETER_MB_ADDR_RESET_CMD = 402,
            PARAMETER_MB_ADDR_DATE_YEAR = 403,
            PARAMETER_MB_ADDR_DATE_MONTH = 404,
            PARAMETER_MB_ADDR_DATE_DAY = 405,
            PARAMETER_MB_ADDR_CLOCK_HOUR = 406,
            PARAMETER_MB_ADDR_CLOCK_MINUTE = 407,
            PARAMETER_MB_ADDR_CLOCK_SECOND = 408,
            PARAMETER_MB_ADDR_DATE_YEAR_CONFIG = 409,
            PARAMETER_MB_ADDR_DATE_MONTH_CONFIG = 410,
            PARAMETER_MB_ADDR_DATE_DAY_CONFIG = 411,
            PARAMETER_MB_ADDR_CLOCK_HOUR_CONFIG = 412,
            PARAMETER_MB_ADDR_CLOCK_MINUTE_CONFIG = 413,
            PARAMETER_MB_ADDR_CLOCK_SECOND_CONFIG = 414,
            PARAMETER_MB_ADDR_SAVE_RTC = 415,
            PARAMETER_MB_ADDR_RESERVE2_0 = 416,
            PARAMETER_MB_ADDR_RESERVE2_1 = 417,
            PARAMETER_MB_ADDR_RESERVE2_2 = 418,
            PARAMETER_MB_ADDR_RESERVE2_3 = 419,
            PARAMETER_MB_ADDR_RESERVE2_4 = 420,
            PARAMETER_MB_ADDR_RESERVE2_5 = 421,
            PARAMETER_MB_ADDR_RESERVE2_6 = 422,
            PARAMETER_MB_ADDR_RESERVE2_7 = 423,
            PARAMETER_MB_ADDR_RESERVE2_8 = 424,
            PARAMETER_MB_ADDR_RESERVE2_9 = 425,
            PARAMETER_MB_ADDR_RESERVE2_10 = 426,
            PARAMETER_MB_ADDR_RESERVE2_11 = 427,
            PARAMETER_MB_ADDR_RESERVE2_12 = 428,
            PARAMETER_MB_ADDR_RESERVE2_13 = 429,
            PARAMETER_MB_ADDR_RESERVE2_14 = 430,
            PARAMETER_MB_ADDR_RESERVE2_15 = 431,
            PARAMETER_MB_ADDR_RESERVE2_16 = 432,
            PARAMETER_MB_ADDR_RESERVE2_17 = 433,
            PARAMETER_MB_ADDR_RESERVE2_18 = 434,
            PARAMETER_MB_ADDR_RESERVE2_19 = 435,
            PARAMETER_MB_ADDR_RESERVE2_20 = 436,
            PARAMETER_MB_ADDR_RESERVE2_21 = 437,
            PARAMETER_MB_ADDR_RESERVE2_22 = 438,
            PARAMETER_MB_ADDR_RESERVE2_23 = 439,
            PARAMETER_MB_ADDR_RESERVE2_24 = 440,
            PARAMETER_MB_ADDR_RESERVE2_25 = 441,
            PARAMETER_MB_ADDR_RESERVE2_26 = 442,
            PARAMETER_MB_ADDR_RESERVE2_27 = 443,
            PARAMETER_MB_ADDR_RESERVE2_28 = 444,
            PARAMETER_MB_ADDR_RESERVE2_29 = 445,
            PARAMETER_MB_ADDR_RESERVE2_30 = 446,
            PARAMETER_MB_ADDR_RESERVE2_31 = 447,
            PARAMETER_MB_ADDR_RESERVE2_32 = 448,
            PARAMETER_MB_ADDR_RESERVE2_33 = 449,
            PARAMETER_MB_ADDR_RESERVE2_34 = 450,
            PARAMETER_MB_ADDR_RESERVE2_35 = 451,
            PARAMETER_MB_ADDR_RESERVE2_36 = 452,
            PARAMETER_MB_ADDR_RESERVE2_37 = 453,
            PARAMETER_MB_ADDR_RESERVE2_38 = 454,
            PARAMETER_MB_ADDR_RESERVE2_39 = 455,
            PARAMETER_MB_ADDR_RESERVE2_40 = 456,
            PARAMETER_MB_ADDR_RESERVE2_41 = 457,
            PARAMETER_MB_ADDR_RESERVE2_42 = 458,
            PARAMETER_MB_ADDR_RESERVE2_43 = 459,
            PARAMETER_MB_ADDR_RESERVE2_44 = 460,
            PARAMETER_MB_ADDR_RESERVE2_45 = 461,
            PARAMETER_MB_ADDR_RESERVE2_46 = 462,
            PARAMETER_MB_ADDR_RESERVE2_47 = 463,
            PARAMETER_MB_ADDR_RESERVE2_48 = 464,
            PARAMETER_MB_ADDR_RESERVE2_49 = 465,
            PARAMETER_MB_ADDR_RESERVE2_50 = 466,
            PARAMETER_MB_ADDR_RESERVE2_51 = 467,
            PARAMETER_MB_ADDR_RESERVE2_52 = 468,
            PARAMETER_MB_ADDR_RESERVE2_53 = 469,
            PARAMETER_MB_ADDR_RESERVE2_54 = 470,
            PARAMETER_MB_ADDR_RESERVE2_55 = 471,
            PARAMETER_MB_ADDR_RESERVE2_56 = 472,
            PARAMETER_MB_ADDR_RESERVE2_57 = 473,
            PARAMETER_MB_ADDR_RESERVE2_58 = 474,
            PARAMETER_MB_ADDR_RESERVE2_59 = 475,
            PARAMETER_MB_ADDR_RESERVE2_60 = 476,
            PARAMETER_MB_ADDR_RESERVE2_61 = 477,
            PARAMETER_MB_ADDR_RESERVE2_62 = 478,
            PARAMETER_MB_ADDR_RESERVE2_63 = 479,
            PARAMETER_MB_ADDR_RESERVE2_64 = 480,
            PARAMETER_MB_ADDR_RESERVE2_65 = 481,
            PARAMETER_MB_ADDR_RESERVE2_66 = 482,
            PARAMETER_MB_ADDR_RESERVE2_67 = 483,
            PARAMETER_MB_ADDR_RESERVE2_68 = 484,
            PARAMETER_MB_ADDR_RESERVE2_69 = 485,
            PARAMETER_MB_ADDR_RESERVE2_70 = 486,
            PARAMETER_MB_ADDR_RESERVE2_71 = 487,
            PARAMETER_MB_ADDR_RESERVE2_72 = 488,
            PARAMETER_MB_ADDR_RESERVE2_73 = 489,
            PARAMETER_MB_ADDR_RESERVE2_74 = 490,
            PARAMETER_MB_ADDR_RESERVE2_75 = 491,
            PARAMETER_MB_ADDR_RESERVE2_76 = 492,
            PARAMETER_MB_ADDR_RESERVE2_77 = 493,
            PARAMETER_MB_ADDR_RESERVE2_78 = 494,
            PARAMETER_MB_ADDR_RESERVE2_79 = 495,
            PARAMETER_MB_ADDR_RESERVE2_80 = 496,
            PARAMETER_MB_ADDR_RESERVE2_81 = 497,
            PARAMETER_MB_ADDR_RESERVE2_82 = 498,
            PARAMETER_MB_ADDR_RESERVE2_83 = 499,
            PARAMETER_MB_ADDR_RESERVE2_84 = 500,
            PARAMETER_MB_ADDR_RESERVE2_85 = 501,
            PARAMETER_MB_ADDR_RESERVE2_86 = 502,
            PARAMETER_MB_ADDR_RESERVE2_87 = 503,
            PARAMETER_MB_ADDR_RESERVE2_88 = 504,
            PARAMETER_MB_ADDR_RESERVE2_89 = 505,
            PARAMETER_MB_ADDR_RESERVE2_90 = 506,
            PARAMETER_MB_ADDR_RESERVE2_91 = 507,
            PARAMETER_MB_ADDR_RESERVE2_92 = 508,
            PARAMETER_MB_ADDR_RESERVE2_93 = 509,
            PARAMETER_MB_ADDR_RESERVE2_94 = 510,
            PARAMETER_MB_ADDR_RESERVE2_95 = 511,
            PARAMETER_MB_ADDR_RESERVE2_96 = 512,
            PARAMETER_MB_ADDR_RESERVE2_97 = 513,
            PARAMETER_MB_ADDR_RESERVE2_98 = 514,
            PARAMETER_MB_ADDR_RESERVE2_99 = 515,
            PARAMETER_MB_ADDR_RESERVE2_100 = 516,
            PARAMETER_MB_ADDR_RESERVE2_101 = 517,
            PARAMETER_MB_ADDR_RESERVE2_102 = 518,
            PARAMETER_MB_ADDR_RESERVE2_103 = 519,
            PARAMETER_MB_ADDR_RESERVE2_104 = 520,
            PARAMETER_MB_ADDR_RESERVE2_105 = 521,
            PARAMETER_MB_ADDR_RESERVE2_106 = 522,
            PARAMETER_MB_ADDR_RESERVE2_107 = 523,
            PARAMETER_MB_ADDR_RESERVE2_108 = 524,
            PARAMETER_MB_ADDR_RESERVE2_109 = 525,
            PARAMETER_MB_ADDR_RESERVE2_110 = 526,
            PARAMETER_MB_ADDR_RESERVE2_111 = 527,
            PARAMETER_MB_ADDR_RESERVE2_112 = 528,
            PARAMETER_MB_ADDR_RESERVE2_113 = 529,
            PARAMETER_MB_ADDR_RESERVE2_114 = 530,
            PARAMETER_MB_ADDR_RESERVE2_115 = 531,
            PARAMETER_MB_ADDR_RESERVE2_116 = 532,
            PARAMETER_MB_ADDR_RESERVE2_117 = 533,
            PARAMETER_MB_ADDR_RESERVE2_118 = 534,
            PARAMETER_MB_ADDR_RESERVE2_119 = 535,
            PARAMETER_MB_ADDR_RESERVE2_120 = 536,
            PARAMETER_MB_ADDR_RESERVE2_121 = 537,
            PARAMETER_MB_ADDR_RESERVE2_122 = 538,
            PARAMETER_MB_ADDR_RESERVE2_123 = 539,
            PARAMETER_MB_ADDR_RESERVE2_124 = 540,
            PARAMETER_MB_ADDR_RESERVE2_125 = 541,
            PARAMETER_MB_ADDR_RESERVE2_126 = 542,
            PARAMETER_MB_ADDR_RESERVE2_127 = 543,
            PARAMETER_MB_ADDR_RESERVE2_128 = 544,
            PARAMETER_MB_ADDR_RESERVE2_129 = 545,
            PARAMETER_MB_ADDR_RESERVE2_130 = 546,
            PARAMETER_MB_ADDR_RESERVE2_131 = 547,
            PARAMETER_MB_ADDR_RESERVE2_132 = 548,
            PARAMETER_MB_ADDR_RESERVE2_133 = 549,
            PARAMETER_MB_ADDR_RESERVE2_134 = 550,
            PARAMETER_MB_ADDR_RESERVE2_135 = 551,
            PARAMETER_MB_ADDR_RESERVE2_136 = 552,
            PARAMETER_MB_ADDR_RESERVE2_137 = 553,
            PARAMETER_MB_ADDR_RESERVE2_138 = 554,
            PARAMETER_MB_ADDR_RESERVE2_139 = 555,
            PARAMETER_MB_ADDR_RESERVE2_140 = 556,
            PARAMETER_MB_ADDR_RESERVE2_141 = 557,
            PARAMETER_MB_ADDR_RESERVE2_142 = 558,
            PARAMETER_MB_ADDR_RESERVE2_143 = 559,
            PARAMETER_MB_ADDR_RESERVE2_144 = 560,
            PARAMETER_MB_ADDR_RESERVE2_145 = 561,
            PARAMETER_MB_ADDR_RESERVE2_146 = 562,
            PARAMETER_MB_ADDR_RESERVE2_147 = 563,
            PARAMETER_MB_ADDR_RESERVE2_148 = 564,
            PARAMETER_MB_ADDR_RESERVE2_149 = 565,
            PARAMETER_MB_ADDR_RESERVE2_150 = 566,
            PARAMETER_MB_ADDR_RESERVE2_151 = 567,
            PARAMETER_MB_ADDR_RESERVE2_152 = 568,
            PARAMETER_MB_ADDR_RESERVE2_153 = 569,
            PARAMETER_MB_ADDR_RESERVE2_154 = 570,
            PARAMETER_MB_ADDR_RESERVE2_155 = 571,
            PARAMETER_MB_ADDR_RESERVE2_156 = 572,
            PARAMETER_MB_ADDR_RESERVE2_157 = 573,
            PARAMETER_MB_ADDR_RESERVE2_158 = 574,
            PARAMETER_MB_ADDR_RESERVE2_159 = 575,
            PARAMETER_MB_ADDR_RESERVE2_160 = 576,
            PARAMETER_MB_ADDR_RESERVE2_161 = 577,
            PARAMETER_MB_ADDR_RESERVE2_162 = 578,
            PARAMETER_MB_ADDR_RESERVE2_163 = 579,
            PARAMETER_MB_ADDR_RESERVE2_164 = 580,
            PARAMETER_MB_ADDR_RESERVE2_165 = 581,
            PARAMETER_MB_ADDR_RESERVE2_166 = 582,
            PARAMETER_MB_ADDR_RESERVE2_167 = 583,
            PARAMETER_MB_ADDR_RESERVE2_168 = 584,
            PARAMETER_MB_ADDR_RESERVE2_169 = 585,
            PARAMETER_MB_ADDR_RESERVE2_170 = 586,
            PARAMETER_MB_ADDR_RESERVE2_171 = 587,
            PARAMETER_MB_ADDR_RESERVE2_172 = 588,
            PARAMETER_MB_ADDR_RESERVE2_173 = 589,
            PARAMETER_MB_ADDR_RESERVE2_174 = 590,
            PARAMETER_MB_ADDR_RESERVE2_175 = 591,
            PARAMETER_MB_ADDR_RESERVE2_176 = 592,
            PARAMETER_MB_ADDR_RESERVE2_177 = 593,
            PARAMETER_MB_ADDR_RESERVE2_178 = 594,
            PARAMETER_MB_ADDR_RESERVE2_179 = 595,
            PARAMETER_MB_ADDR_RESERVE2_180 = 596,
            PARAMETER_MB_ADDR_RESERVE2_181 = 597,
            PARAMETER_MB_ADDR_RESERVE2_182 = 598,
            PARAMETER_MB_ADDR_RESERVE2_183 = 599,
            PARAMETER_MB_ADDR_RESERVE2_184 = 600,
            PARAMETER_MB_ADDR_RESERVE2_185 = 601,
            PARAMETER_MB_ADDR_RESERVE2_186 = 602,
            PARAMETER_MB_ADDR_RESERVE2_187 = 603,
            PARAMETER_MB_ADDR_RESERVE2_188 = 604,
            PARAMETER_MB_ADDR_RESERVE2_189 = 605,
            PARAMETER_MB_ADDR_RESERVE2_190 = 606,
            PARAMETER_MB_ADDR_RESERVE2_191 = 607,
            PARAMETER_MB_ADDR_RESERVE2_192 = 608,
            PARAMETER_MB_ADDR_RESERVE2_193 = 609,
            PARAMETER_MB_ADDR_RESERVE2_194 = 610,
            PARAMETER_MB_ADDR_RESERVE2_195 = 611,
            PARAMETER_MB_ADDR_RESERVE2_196 = 612,
            PARAMETER_MB_ADDR_RESERVE2_197 = 613,
            PARAMETER_MB_ADDR_RESERVE2_198 = 614,
            PARAMETER_MB_ADDR_RESERVE2_199 = 615,
            PARAMETER_MB_ADDR_RESERVE2_200 = 616,
            PARAMETER_MB_ADDR_RESERVE2_201 = 617,
            PARAMETER_MB_ADDR_RESERVE2_202 = 618,
            PARAMETER_MB_ADDR_RESERVE2_203 = 619,
            PARAMETER_MB_ADDR_RESERVE2_204 = 620,
            PARAMETER_MB_ADDR_RESERVE2_205 = 621,
            PARAMETER_MB_ADDR_RESERVE2_206 = 622,
            PARAMETER_MB_ADDR_RESERVE2_207 = 623,
            PARAMETER_MB_ADDR_RESERVE2_208 = 624,
            PARAMETER_MB_ADDR_RESERVE2_209 = 625,
            PARAMETER_MB_ADDR_RESERVE2_210 = 626,
            PARAMETER_MB_ADDR_RESERVE2_211 = 627,
            PARAMETER_MB_ADDR_RESERVE2_212 = 628,
            PARAMETER_MB_ADDR_RESERVE2_213 = 629,
            PARAMETER_MB_ADDR_RESERVE2_214 = 630,
            PARAMETER_MB_ADDR_RESERVE2_215 = 631,
            PARAMETER_MB_ADDR_RESERVE2_216 = 632,
            PARAMETER_MB_ADDR_RESERVE2_217 = 633,
            PARAMETER_MB_ADDR_RESERVE2_218 = 634,
            PARAMETER_MB_ADDR_RESERVE2_219 = 635,
            PARAMETER_MB_ADDR_RESERVE2_220 = 636,
            PARAMETER_MB_ADDR_RESERVE2_221 = 637,
            PARAMETER_MB_ADDR_RESERVE2_222 = 638,
            PARAMETER_MB_ADDR_RESERVE2_223 = 639,
            PARAMETER_MB_ADDR_RESERVE2_224 = 640,
            PARAMETER_MB_ADDR_RESERVE2_225 = 641,
            PARAMETER_MB_ADDR_RESERVE2_226 = 642,
            PARAMETER_MB_ADDR_RESERVE2_227 = 643,
            PARAMETER_MB_ADDR_RESERVE2_228 = 644,
            PARAMETER_MB_ADDR_RESERVE2_229 = 645,
            PARAMETER_MB_ADDR_RESERVE2_230 = 646,
            PARAMETER_MB_ADDR_RESERVE2_231 = 647,
            PARAMETER_MB_ADDR_RESERVE2_232 = 648,
            PARAMETER_MB_ADDR_RESERVE2_233 = 649,
            PARAMETER_MB_ADDR_RESERVE2_234 = 650,
            PARAMETER_MB_ADDR_RESERVE2_235 = 651,
            PARAMETER_MB_ADDR_RESERVE2_236 = 652,
            PARAMETER_MB_ADDR_RESERVE2_237 = 653,
            PARAMETER_MB_ADDR_RESERVE2_238 = 654,
            PARAMETER_MB_ADDR_RESERVE2_239 = 655,
            PARAMETER_MB_ADDR_RESERVE2_240 = 656,
            PARAMETER_MB_ADDR_RESERVE2_241 = 657,
            PARAMETER_MB_ADDR_RESERVE2_242 = 658,
            PARAMETER_MB_ADDR_RESERVE2_243 = 659,
            PARAMETER_MB_ADDR_RESERVE2_244 = 660,
            PARAMETER_MB_ADDR_RESERVE2_245 = 661,
            PARAMETER_MB_ADDR_RESERVE2_246 = 662,
            PARAMETER_MB_ADDR_RESERVE2_247 = 663,
            PARAMETER_MB_ADDR_RESERVE2_248 = 664,
            PARAMETER_MB_ADDR_RESERVE2_249 = 665,
            PARAMETER_MB_ADDR_RESERVE2_250 = 666,
            PARAMETER_MB_ADDR_RESERVE2_251 = 667,
            PARAMETER_MB_ADDR_RESERVE2_252 = 668,
            PARAMETER_MB_ADDR_RESERVE2_253 = 669,
            PARAMETER_MB_ADDR_RESERVE2_254 = 670,
            PARAMETER_MB_ADDR_RESERVE2_255 = 671,
            PARAMETER_MB_ADDR_RESERVE2_256 = 672,
            PARAMETER_MB_ADDR_RESERVE2_257 = 673,
            PARAMETER_MB_ADDR_RESERVE2_258 = 674,
            PARAMETER_MB_ADDR_RESERVE2_259 = 675,
            PARAMETER_MB_ADDR_RESERVE2_260 = 676,
            PARAMETER_MB_ADDR_RESERVE2_261 = 677,
            PARAMETER_MB_ADDR_RESERVE2_262 = 678,
            PARAMETER_MB_ADDR_RESERVE2_263 = 679,
            PARAMETER_MB_ADDR_RESERVE2_264 = 680,
            PARAMETER_MB_ADDR_RESERVE2_265 = 681,
            PARAMETER_MB_ADDR_RESERVE2_266 = 682,
            PARAMETER_MB_ADDR_RESERVE2_267 = 683,
            PARAMETER_MB_ADDR_RESERVE2_268 = 684,
            PARAMETER_MB_ADDR_RESERVE2_269 = 685,
            PARAMETER_MB_ADDR_RESERVE2_270 = 686,
            PARAMETER_MB_ADDR_RESERVE2_271 = 687,
            PARAMETER_MB_ADDR_RESERVE2_272 = 688,
            PARAMETER_MB_ADDR_RESERVE2_273 = 689,
            PARAMETER_MB_ADDR_RESERVE2_274 = 690,
            PARAMETER_MB_ADDR_RESERVE2_275 = 691,
            PARAMETER_MB_ADDR_RESERVE2_276 = 692,
            PARAMETER_MB_ADDR_RESERVE2_277 = 693,
            PARAMETER_MB_ADDR_RESERVE2_278 = 694,
            PARAMETER_MB_ADDR_RESERVE2_279 = 695,
            PARAMETER_MB_ADDR_RESERVE2_280 = 696,
            PARAMETER_MB_ADDR_RESERVE2_281 = 697,
            PARAMETER_MB_ADDR_RESERVE2_282 = 698,
            PARAMETER_MB_ADDR_RESERVE2_283 = 699,
            PARAMETER_MB_ADDR_RESERVE2_284 = 700,
            PARAMETER_MB_ADDR_RESERVE2_285 = 701,
            PARAMETER_MB_ADDR_RESERVE2_286 = 702,
            PARAMETER_MB_ADDR_RESERVE2_287 = 703,
            PARAMETER_MB_ADDR_RESERVE2_288 = 704,
            PARAMETER_MB_ADDR_RESERVE2_289 = 705,
            PARAMETER_MB_ADDR_RESERVE2_290 = 706,
            PARAMETER_MB_ADDR_RESERVE2_291 = 707,
            PARAMETER_MB_ADDR_RESERVE2_292 = 708,
            PARAMETER_MB_ADDR_RESERVE2_293 = 709,
            PARAMETER_MB_ADDR_RESERVE2_294 = 710,
            PARAMETER_MB_ADDR_RESERVE2_295 = 711,
            PARAMETER_MB_ADDR_RESERVE2_296 = 712,
            PARAMETER_MB_ADDR_RESERVE2_297 = 713,
            PARAMETER_MB_ADDR_RESERVE2_298 = 714,
            PARAMETER_MB_ADDR_RESERVE2_299 = 715,
            PARAMETER_MB_ADDR_RESERVE2_300 = 716,
            PARAMETER_MB_ADDR_RESERVE2_301 = 717,
            PARAMETER_MB_ADDR_RESERVE2_302 = 718,
            PARAMETER_MB_ADDR_RESERVE2_303 = 719,
            PARAMETER_MB_ADDR_RESERVE2_304 = 720,
            PARAMETER_MB_ADDR_RESERVE2_305 = 721,
            PARAMETER_MB_ADDR_RESERVE2_306 = 722,
            PARAMETER_MB_ADDR_RESERVE2_307 = 723,
            PARAMETER_MB_ADDR_RESERVE2_308 = 724,
            PARAMETER_MB_ADDR_RESERVE2_309 = 725,
            PARAMETER_MB_ADDR_RESERVE2_310 = 726,
            PARAMETER_MB_ADDR_RESERVE2_311 = 727,
            PARAMETER_MB_ADDR_RESERVE2_312 = 728,
            PARAMETER_MB_ADDR_RESERVE2_313 = 729,
            PARAMETER_MB_ADDR_RESERVE2_314 = 730,
            PARAMETER_MB_ADDR_RESERVE2_315 = 731,
            PARAMETER_MB_ADDR_RESERVE2_316 = 732,
            PARAMETER_MB_ADDR_RESERVE2_317 = 733,
            PARAMETER_MB_ADDR_RESERVE2_318 = 734,
            PARAMETER_MB_ADDR_RESERVE2_319 = 735,
            PARAMETER_MB_ADDR_RESERVE2_320 = 736,
            PARAMETER_MB_ADDR_RESERVE2_321 = 737,
            PARAMETER_MB_ADDR_RESERVE2_322 = 738,
            PARAMETER_MB_ADDR_RESERVE2_323 = 739,
            PARAMETER_MB_ADDR_RESERVE2_324 = 740,
            PARAMETER_MB_ADDR_RESERVE2_325 = 741,
            PARAMETER_MB_ADDR_RESERVE2_326 = 742,
            PARAMETER_MB_ADDR_RESERVE2_327 = 743,
            PARAMETER_MB_ADDR_RESERVE2_328 = 744,
            PARAMETER_MB_ADDR_RESERVE2_329 = 745,
            PARAMETER_MB_ADDR_RESERVE2_330 = 746,
            PARAMETER_MB_ADDR_RESERVE2_331 = 747,
            PARAMETER_MB_ADDR_RESERVE2_332 = 748,
            PARAMETER_MB_ADDR_RESERVE2_333 = 749,
            PARAMETER_MB_ADDR_RESERVE2_334 = 750,
            PARAMETER_MB_ADDR_RESERVE2_335 = 751,
            PARAMETER_MB_ADDR_RESERVE2_336 = 752,
            PARAMETER_MB_ADDR_RESERVE2_337 = 753,
            PARAMETER_MB_ADDR_RESERVE2_338 = 754,
            PARAMETER_MB_ADDR_RESERVE2_339 = 755,
            PARAMETER_MB_ADDR_RESERVE2_340 = 756,
            PARAMETER_MB_ADDR_RESERVE2_341 = 757,
            PARAMETER_MB_ADDR_RESERVE2_342 = 758,
            PARAMETER_MB_ADDR_RESERVE2_343 = 759,
            PARAMETER_MB_ADDR_RESERVE2_344 = 760,
            PARAMETER_MB_ADDR_RESERVE2_345 = 761,
            PARAMETER_MB_ADDR_RESERVE2_346 = 762,
            PARAMETER_MB_ADDR_RESERVE2_347 = 763,
            PARAMETER_MB_ADDR_RESERVE2_348 = 764,
            PARAMETER_MB_ADDR_RESERVE2_349 = 765,
            PARAMETER_MB_ADDR_RESERVE2_350 = 766,
            PARAMETER_MB_ADDR_RESERVE2_351 = 767,
            PARAMETER_MB_ADDR_RESERVE2_352 = 768,
            PARAMETER_MB_ADDR_RESERVE2_353 = 769,
            PARAMETER_MB_ADDR_RESERVE2_354 = 770,
            PARAMETER_MB_ADDR_RESERVE2_355 = 771,
            PARAMETER_MB_ADDR_RESERVE2_356 = 772,
            PARAMETER_MB_ADDR_RESERVE2_357 = 773,
            PARAMETER_MB_ADDR_RESERVE2_358 = 774,
            PARAMETER_MB_ADDR_RESERVE2_359 = 775,
            PARAMETER_MB_ADDR_RESERVE2_360 = 776,
            PARAMETER_MB_ADDR_RESERVE2_361 = 777,
            PARAMETER_MB_ADDR_RESERVE2_362 = 778,
            PARAMETER_MB_ADDR_RESERVE2_363 = 779,
            PARAMETER_MB_ADDR_RESERVE2_364 = 780,
            PARAMETER_MB_ADDR_RESERVE2_365 = 781,
            PARAMETER_MB_ADDR_RESERVE2_366 = 782,
            PARAMETER_MB_ADDR_RESERVE2_367 = 783,
            PARAMETER_MB_ADDR_RESERVE2_368 = 784,
            PARAMETER_MB_ADDR_RESERVE2_369 = 785,
            PARAMETER_MB_ADDR_RESERVE2_370 = 786,
            PARAMETER_MB_ADDR_RESERVE2_371 = 787,
            PARAMETER_MB_ADDR_RESERVE2_372 = 788,
            PARAMETER_MB_ADDR_RESERVE2_373 = 789,
            PARAMETER_MB_ADDR_RESERVE2_374 = 790,
            PARAMETER_MB_ADDR_RESERVE2_375 = 791,
            PARAMETER_MB_ADDR_RESERVE2_376 = 792,
            PARAMETER_MB_ADDR_RESERVE2_377 = 793,
            PARAMETER_MB_ADDR_RESERVE2_378 = 794,
            PARAMETER_MB_ADDR_RESERVE2_379 = 795,
            PARAMETER_MB_ADDR_RESERVE2_380 = 796,
            PARAMETER_MB_ADDR_RESERVE2_381 = 797,
            PARAMETER_MB_ADDR_RESERVE2_382 = 798,
            PARAMETER_MB_ADDR_RESERVE2_383 = 799,
            PARAMETER_MB_ADDR_RESERVE2_384 = 800,
            PARAMETER_MB_ADDR_RESERVE2_385 = 801,
            PARAMETER_MB_ADDR_RESERVE2_386 = 802,
            PARAMETER_MB_ADDR_RESERVE2_387 = 803,
            PARAMETER_MB_ADDR_RESERVE2_388 = 804,
            PARAMETER_MB_ADDR_RESERVE2_389 = 805,
            PARAMETER_MB_ADDR_RESERVE2_390 = 806,
            PARAMETER_MB_ADDR_RESERVE2_391 = 807,
            PARAMETER_MB_ADDR_RESERVE2_392 = 808,
            PARAMETER_MB_ADDR_RESERVE2_393 = 809,
            PARAMETER_MB_ADDR_RESERVE2_394 = 810,
            PARAMETER_MB_ADDR_RESERVE2_395 = 811,
            PARAMETER_MB_ADDR_RESERVE2_396 = 812,
            PARAMETER_MB_ADDR_RESERVE2_397 = 813,
            PARAMETER_MB_ADDR_RESERVE2_398 = 814,
            PARAMETER_MB_ADDR_RESERVE2_399 = 815,
            PARAMETER_MB_ADDR_RESERVE2_400 = 816,
            PARAMETER_MB_ADDR_RESERVE2_401 = 817,
            PARAMETER_MB_ADDR_RESERVE2_402 = 818,
            PARAMETER_MB_ADDR_RESERVE2_403 = 819,
            PARAMETER_MB_ADDR_RESERVE2_404 = 820,
            PARAMETER_MB_ADDR_RESERVE2_405 = 821,
            PARAMETER_MB_ADDR_RESERVE2_406 = 822,
            PARAMETER_MB_ADDR_RESERVE2_407 = 823,
            PARAMETER_MB_ADDR_RESERVE2_408 = 824,
            PARAMETER_MB_ADDR_RESERVE2_409 = 825,
            PARAMETER_MB_ADDR_RESERVE2_410 = 826,
            PARAMETER_MB_ADDR_RESERVE2_411 = 827,
            PARAMETER_MB_ADDR_RESERVE2_412 = 828,
            PARAMETER_MB_ADDR_RESERVE2_413 = 829,
            PARAMETER_MB_ADDR_RESERVE2_414 = 830,
            PARAMETER_MB_ADDR_RESERVE2_415 = 831,
            PARAMETER_MB_ADDR_RESERVE2_416 = 832,
            PARAMETER_MB_ADDR_RESERVE2_417 = 833,
            PARAMETER_MB_ADDR_RESERVE2_418 = 834,
            PARAMETER_MB_ADDR_RESERVE2_419 = 835,
            PARAMETER_MB_ADDR_RESERVE2_420 = 836,
            PARAMETER_MB_ADDR_RESERVE2_421 = 837,
            PARAMETER_MB_ADDR_RESERVE2_422 = 838,
            PARAMETER_MB_ADDR_RESERVE2_423 = 839,
            PARAMETER_MB_ADDR_RESERVE2_424 = 840,
            PARAMETER_MB_ADDR_RESERVE2_425 = 841,
            PARAMETER_MB_ADDR_RESERVE2_426 = 842,
            PARAMETER_MB_ADDR_RESERVE2_427 = 843,
            PARAMETER_MB_ADDR_RESERVE2_428 = 844,
            PARAMETER_MB_ADDR_RESERVE2_429 = 845,
            PARAMETER_MB_ADDR_RESERVE2_430 = 846,
            PARAMETER_MB_ADDR_RESERVE2_431 = 847,
            PARAMETER_MB_ADDR_RESERVE2_432 = 848,
            PARAMETER_MB_ADDR_RESERVE2_433 = 849,
            PARAMETER_MB_ADDR_RESERVE2_434 = 850,
            PARAMETER_MB_ADDR_RESERVE2_435 = 851,
            PARAMETER_MB_ADDR_RESERVE2_436 = 852,
            PARAMETER_MB_ADDR_RESERVE2_437 = 853,
            PARAMETER_MB_ADDR_RESERVE2_438 = 854,
            PARAMETER_MB_ADDR_RESERVE2_439 = 855,
            PARAMETER_MB_ADDR_RESERVE2_440 = 856,
            PARAMETER_MB_ADDR_RESERVE2_441 = 857,
            PARAMETER_MB_ADDR_RESERVE2_442 = 858,
            PARAMETER_MB_ADDR_RESERVE2_443 = 859,
            PARAMETER_MB_ADDR_RESERVE2_444 = 860,
            PARAMETER_MB_ADDR_RESERVE2_445 = 861,
            PARAMETER_MB_ADDR_RESERVE2_446 = 862,
            PARAMETER_MB_ADDR_RESERVE2_447 = 863,
            PARAMETER_MB_ADDR_RESERVE2_448 = 864,
            PARAMETER_MB_ADDR_RESERVE2_449 = 865,
            PARAMETER_MB_ADDR_RESERVE2_450 = 866,
            PARAMETER_MB_ADDR_RESERVE2_451 = 867,
            PARAMETER_MB_ADDR_RESERVE2_452 = 868,
            PARAMETER_MB_ADDR_RESERVE2_453 = 869,
            PARAMETER_MB_ADDR_RESERVE2_454 = 870,
            PARAMETER_MB_ADDR_RESERVE2_455 = 871,
            PARAMETER_MB_ADDR_RESERVE2_456 = 872,
            PARAMETER_MB_ADDR_RESERVE2_457 = 873,
            PARAMETER_MB_ADDR_RESERVE2_458 = 874,
            PARAMETER_MB_ADDR_RESERVE2_459 = 875,
            PARAMETER_MB_ADDR_RESERVE2_460 = 876,
            PARAMETER_MB_ADDR_RESERVE2_461 = 877,
            PARAMETER_MB_ADDR_RESERVE2_462 = 878,
            PARAMETER_MB_ADDR_RESERVE2_463 = 879,
            PARAMETER_MB_ADDR_RESERVE2_464 = 880,
            PARAMETER_MB_ADDR_RESERVE2_465 = 881,
            PARAMETER_MB_ADDR_RESERVE2_466 = 882,
            PARAMETER_MB_ADDR_RESERVE2_467 = 883,
            PARAMETER_MB_ADDR_RESERVE2_468 = 884,
            PARAMETER_MB_ADDR_RESERVE2_469 = 885,
            PARAMETER_MB_ADDR_RESERVE2_470 = 886,
            PARAMETER_MB_ADDR_RESERVE2_471 = 887,
            PARAMETER_MB_ADDR_RESERVE2_472 = 888,
            PARAMETER_MB_ADDR_RESERVE2_473 = 889,
            PARAMETER_MB_ADDR_RESERVE2_474 = 890,
            PARAMETER_MB_ADDR_RESERVE2_475 = 891,
            PARAMETER_MB_ADDR_RESERVE2_476 = 892,
            PARAMETER_MB_ADDR_RESERVE2_477 = 893,
            PARAMETER_MB_ADDR_RESERVE2_478 = 894,
            PARAMETER_MB_ADDR_RESERVE2_479 = 895,
            PARAMETER_MB_ADDR_RESERVE2_480 = 896,
            PARAMETER_MB_ADDR_RESERVE2_481 = 897,
            PARAMETER_MB_ADDR_RESERVE2_482 = 898,
            PARAMETER_MB_ADDR_RESERVE2_483 = 899,
            PARAMETER_MB_ADDR_UP_STREAM_BAUDRATE_0 = 900,
            PARAMETER_MB_ADDR_UP_STREAM_BAUDRATE_1 = 901,
            PARAMETER_MB_ADDR_RESERVE3_0 = 902,
            PARAMETER_MB_ADDR_RESERVE3_1 = 903,
            PARAMETER_MB_ADDR_RESERVE3_2 = 904,
            PARAMETER_MB_ADDR_RESERVE3_3 = 905,
            PARAMETER_MB_ADDR_RESERVE3_4 = 906,
            PARAMETER_MB_ADDR_RESERVE3_5 = 907,
            PARAMETER_MB_ADDR_RESERVE3_6 = 908,
            PARAMETER_MB_ADDR_RESERVE3_7 = 909,
            PARAMETER_MB_ADDR_RESERVE3_8 = 910,
            PARAMETER_MB_ADDR_RESERVE3_9 = 911,
            PARAMETER_MB_ADDR_RESERVE3_10 = 912,
            PARAMETER_MB_ADDR_RESERVE3_11 = 913,
            PARAMETER_MB_ADDR_RESERVE3_12 = 914,
            PARAMETER_MB_ADDR_RESERVE3_13 = 915,
            PARAMETER_MB_ADDR_RESERVE3_14 = 916,
            PARAMETER_MB_ADDR_RESERVE3_15 = 917,
            PARAMETER_MB_ADDR_RESERVE3_16 = 918,
            PARAMETER_MB_ADDR_RESERVE3_17 = 919,
            PARAMETER_MB_ADDR_RESERVE3_18 = 920,
            PARAMETER_MB_ADDR_RESERVE3_19 = 921,
            PARAMETER_MB_ADDR_RESERVE3_20 = 922,
            PARAMETER_MB_ADDR_RESERVE3_21 = 923,
            PARAMETER_MB_ADDR_RESERVE3_22 = 924,
            PARAMETER_MB_ADDR_RESERVE3_23 = 925,
            PARAMETER_MB_ADDR_RESERVE3_24 = 926,
            PARAMETER_MB_ADDR_RESERVE3_25 = 927,
            PARAMETER_MB_ADDR_RESERVE3_26 = 928,
            PARAMETER_MB_ADDR_RESERVE3_27 = 929,
            PARAMETER_MB_ADDR_RESERVE3_28 = 930,
            PARAMETER_MB_ADDR_RESERVE3_29 = 931,
            PARAMETER_MB_ADDR_RESERVE3_30 = 932,
            PARAMETER_MB_ADDR_RESERVE3_31 = 933,
            PARAMETER_MB_ADDR_RESERVE3_32 = 934,
            PARAMETER_MB_ADDR_RESERVE3_33 = 935,
            PARAMETER_MB_ADDR_RESERVE3_34 = 936,
            PARAMETER_MB_ADDR_RESERVE3_35 = 937,
            PARAMETER_MB_ADDR_RESERVE3_36 = 938,
            PARAMETER_MB_ADDR_RESERVE3_37 = 939,
            PARAMETER_MB_ADDR_RESERVE3_38 = 940,
            PARAMETER_MB_ADDR_RESERVE3_39 = 941,
            PARAMETER_MB_ADDR_RESERVE3_40 = 942,
            PARAMETER_MB_ADDR_RESERVE3_41 = 943,
            PARAMETER_MB_ADDR_RESERVE3_42 = 944,
            PARAMETER_MB_ADDR_RESERVE3_43 = 945,
            PARAMETER_MB_ADDR_RESERVE3_44 = 946,
            PARAMETER_MB_ADDR_RESERVE3_45 = 947,
            PARAMETER_MB_ADDR_RESERVE3_46 = 948,
            PARAMETER_MB_ADDR_RESERVE3_47 = 949,
            PARAMETER_MB_ADDR_RESERVE3_48 = 950,
            PARAMETER_MB_ADDR_RESERVE3_49 = 951,
            PARAMETER_MB_ADDR_RESERVE3_50 = 952,
            PARAMETER_MB_ADDR_RESERVE3_51 = 953,
            PARAMETER_MB_ADDR_RESERVE3_52 = 954,
            PARAMETER_MB_ADDR_RESERVE3_53 = 955,
            PARAMETER_MB_ADDR_RESERVE3_54 = 956,
            PARAMETER_MB_ADDR_RESERVE3_55 = 957,
            PARAMETER_MB_ADDR_RESERVE3_56 = 958,
            PARAMETER_MB_ADDR_RESERVE3_57 = 959,
            PARAMETER_MB_ADDR_RESERVE3_58 = 960,
            PARAMETER_MB_ADDR_RESERVE3_59 = 961,
            PARAMETER_MB_ADDR_RESERVE3_60 = 962,
            PARAMETER_MB_ADDR_RESERVE3_61 = 963,
            PARAMETER_MB_ADDR_RESERVE3_62 = 964,
            PARAMETER_MB_ADDR_RESERVE3_63 = 965,
            PARAMETER_MB_ADDR_RESERVE3_64 = 966,
            PARAMETER_MB_ADDR_RESERVE3_65 = 967,
            PARAMETER_MB_ADDR_RESERVE3_66 = 968,
            PARAMETER_MB_ADDR_RESERVE3_67 = 969,
            PARAMETER_MB_ADDR_RESERVE3_68 = 970,
            PARAMETER_MB_ADDR_RESERVE3_69 = 971,
            PARAMETER_MB_ADDR_RESERVE3_70 = 972,
            PARAMETER_MB_ADDR_RESERVE3_71 = 973,
            PARAMETER_MB_ADDR_RESERVE3_72 = 974,
            PARAMETER_MB_ADDR_RESERVE3_73 = 975,
            PARAMETER_MB_ADDR_RESERVE3_74 = 976,
            PARAMETER_MB_ADDR_RESERVE3_75 = 977,
            PARAMETER_MB_ADDR_RESERVE3_76 = 978,
            PARAMETER_MB_ADDR_RESERVE3_77 = 979,
            PARAMETER_MB_ADDR_RESERVE3_78 = 980,
            PARAMETER_MB_ADDR_RESERVE3_79 = 981,
            PARAMETER_MB_ADDR_RESERVE3_80 = 982,
            PARAMETER_MB_ADDR_RESERVE3_81 = 983,
            PARAMETER_MB_ADDR_RESERVE3_82 = 984,
            PARAMETER_MB_ADDR_RESERVE3_83 = 985,
            PARAMETER_MB_ADDR_RESERVE3_84 = 986,
            PARAMETER_MB_ADDR_RESERVE3_85 = 987,
            PARAMETER_MB_ADDR_RESERVE3_86 = 988,
            PARAMETER_MB_ADDR_RESERVE3_87 = 989,
            PARAMETER_MB_ADDR_RESERVE3_88 = 990,
            PARAMETER_MB_ADDR_RESERVE3_89 = 991,
            PARAMETER_MB_ADDR_RESERVE3_90 = 992,
            PARAMETER_MB_ADDR_RESERVE3_91 = 993,
            PARAMETER_MB_ADDR_RESERVE3_92 = 994,
            PARAMETER_MB_ADDR_RESERVE3_93 = 995,
            PARAMETER_MB_ADDR_RESERVE3_94 = 996,
            PARAMETER_MB_ADDR_RESERVE3_95 = 997,
            PARAMETER_MB_ADDR_RESERVE3_96 = 998,
            PARAMETER_MB_ADDR_RESERVE3_97 = 999,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_0 = 1000,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_1 = 1001,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_2 = 1002,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_3 = 1003,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_4 = 1004,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_5 = 1005,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_6 = 1006,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_7 = 1007,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_8 = 1008,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_9 = 1009,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_10 = 1010,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_11 = 1011,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_12 = 1012,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_13 = 1013,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_14 = 1014,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_15 = 1015,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_16 = 1016,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_17 = 1017,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_18 = 1018,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_19 = 1019,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_20 = 1020,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_21 = 1021,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_22 = 1022,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_23 = 1023,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_24 = 1024,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_25 = 1025,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_26 = 1026,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_27 = 1027,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_28 = 1028,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_29 = 1029,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_30 = 1030,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_31 = 1031,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_32 = 1032,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_33 = 1033,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_34 = 1034,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_35 = 1035,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_36 = 1036,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_37 = 1037,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_38 = 1038,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_39 = 1039,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_40 = 1040,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_41 = 1041,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_42 = 1042,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_43 = 1043,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_44 = 1044,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_45 = 1045,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_46 = 1046,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_47 = 1047,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_48 = 1048,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_49 = 1049,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_50 = 1050,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_51 = 1051,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_52 = 1052,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_53 = 1053,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_54 = 1054,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_55 = 1055,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_56 = 1056,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_57 = 1057,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_58 = 1058,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_59 = 1059,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_60 = 1060,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_61 = 1061,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_62 = 1062,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_63 = 1063,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_64 = 1064,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_65 = 1065,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_66 = 1066,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_67 = 1067,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_68 = 1068,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_69 = 1069,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_70 = 1070,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_71 = 1071,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_72 = 1072,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_73 = 1073,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_74 = 1074,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_75 = 1075,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_76 = 1076,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_77 = 1077,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_78 = 1078,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_79 = 1079,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_80 = 1080,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_81 = 1081,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_82 = 1082,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_83 = 1083,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_84 = 1084,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_85 = 1085,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_86 = 1086,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_87 = 1087,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_88 = 1088,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_89 = 1089,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_90 = 1090,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_91 = 1091,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_92 = 1092,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_93 = 1093,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_94 = 1094,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_95 = 1095,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_96 = 1096,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_97 = 1097,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_98 = 1098,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_99 = 1099,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_100 = 1100,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_101 = 1101,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_102 = 1102,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_103 = 1103,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_104 = 1104,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_105 = 1105,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_106 = 1106,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_107 = 1107,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_108 = 1108,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_109 = 1109,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_110 = 1110,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_111 = 1111,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_112 = 1112,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_113 = 1113,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_114 = 1114,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_115 = 1115,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_116 = 1116,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_117 = 1117,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_118 = 1118,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_119 = 1119,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_120 = 1120,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_121 = 1121,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_122 = 1122,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_123 = 1123,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_124 = 1124,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_125 = 1125,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_126 = 1126,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_127 = 1127,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_128 = 1128,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_129 = 1129,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_130 = 1130,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_131 = 1131,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_132 = 1132,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_133 = 1133,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_134 = 1134,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_135 = 1135,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_136 = 1136,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_137 = 1137,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_138 = 1138,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_139 = 1139,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_140 = 1140,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_141 = 1141,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_142 = 1142,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_143 = 1143,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_144 = 1144,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_145 = 1145,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_146 = 1146,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_147 = 1147,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_148 = 1148,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_149 = 1149,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_150 = 1150,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_151 = 1151,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_152 = 1152,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_153 = 1153,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_154 = 1154,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_155 = 1155,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_156 = 1156,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_157 = 1157,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_158 = 1158,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_159 = 1159,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_160 = 1160,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_161 = 1161,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_162 = 1162,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_163 = 1163,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_164 = 1164,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_165 = 1165,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_166 = 1166,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_167 = 1167,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_168 = 1168,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_169 = 1169,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_170 = 1170,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_171 = 1171,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_172 = 1172,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_173 = 1173,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_174 = 1174,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_175 = 1175,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_176 = 1176,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_177 = 1177,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_178 = 1178,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_179 = 1179,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_180 = 1180,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_181 = 1181,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_182 = 1182,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_183 = 1183,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_184 = 1184,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_185 = 1185,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_186 = 1186,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_187 = 1187,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_188 = 1188,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_189 = 1189,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_190 = 1190,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_191 = 1191,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_192 = 1192,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_193 = 1193,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_194 = 1194,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_195 = 1195,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_196 = 1196,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_197 = 1197,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_198 = 1198,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_199 = 1199,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_200 = 1200,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_201 = 1201,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_202 = 1202,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_203 = 1203,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_204 = 1204,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_205 = 1205,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_206 = 1206,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_207 = 1207,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_208 = 1208,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_209 = 1209,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_210 = 1210,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_211 = 1211,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_212 = 1212,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_213 = 1213,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_214 = 1214,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_215 = 1215,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_216 = 1216,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_217 = 1217,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_218 = 1218,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_219 = 1219,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_220 = 1220,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_221 = 1221,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_222 = 1222,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_223 = 1223,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_224 = 1224,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_225 = 1225,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_226 = 1226,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_227 = 1227,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_228 = 1228,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_229 = 1229,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_230 = 1230,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_231 = 1231,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_232 = 1232,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_233 = 1233,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_234 = 1234,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_235 = 1235,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_236 = 1236,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_237 = 1237,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_238 = 1238,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_239 = 1239,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_240 = 1240,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_241 = 1241,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_242 = 1242,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_243 = 1243,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_244 = 1244,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_245 = 1245,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_246 = 1246,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_247 = 1247,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_248 = 1248,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_249 = 1249,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_250 = 1250,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_251 = 1251,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_252 = 1252,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_253 = 1253,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_254 = 1254,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_255 = 1255,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_256 = 1256,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_257 = 1257,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_258 = 1258,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_259 = 1259,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_260 = 1260,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_261 = 1261,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_262 = 1262,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_263 = 1263,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_264 = 1264,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_265 = 1265,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_266 = 1266,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_267 = 1267,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_268 = 1268,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_269 = 1269,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_270 = 1270,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_271 = 1271,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_272 = 1272,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_273 = 1273,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_274 = 1274,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_275 = 1275,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_276 = 1276,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_277 = 1277,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_278 = 1278,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_279 = 1279,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_280 = 1280,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_281 = 1281,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_282 = 1282,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_283 = 1283,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_284 = 1284,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_285 = 1285,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_286 = 1286,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_287 = 1287,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_288 = 1288,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_289 = 1289,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_290 = 1290,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_291 = 1291,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_292 = 1292,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_293 = 1293,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_294 = 1294,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_295 = 1295,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_296 = 1296,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_297 = 1297,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_298 = 1298,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_299 = 1299,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_300 = 1300,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_301 = 1301,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_302 = 1302,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_303 = 1303,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_304 = 1304,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_305 = 1305,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_306 = 1306,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_307 = 1307,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_308 = 1308,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_309 = 1309,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_310 = 1310,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_311 = 1311,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_312 = 1312,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_313 = 1313,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_314 = 1314,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_315 = 1315,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_316 = 1316,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_317 = 1317,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_318 = 1318,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_319 = 1319,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_320 = 1320,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_321 = 1321,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_322 = 1322,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_323 = 1323,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_324 = 1324,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_325 = 1325,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_326 = 1326,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_327 = 1327,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_328 = 1328,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_329 = 1329,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_330 = 1330,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_331 = 1331,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_332 = 1332,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_333 = 1333,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_334 = 1334,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_335 = 1335,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_336 = 1336,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_337 = 1337,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_338 = 1338,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_339 = 1339,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_340 = 1340,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_341 = 1341,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_342 = 1342,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_343 = 1343,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_344 = 1344,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_345 = 1345,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_346 = 1346,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_347 = 1347,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_348 = 1348,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_349 = 1349,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_350 = 1350,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_351 = 1351,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_352 = 1352,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_353 = 1353,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_354 = 1354,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_355 = 1355,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_356 = 1356,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_357 = 1357,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_358 = 1358,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_359 = 1359,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_360 = 1360,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_361 = 1361,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_362 = 1362,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_363 = 1363,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_364 = 1364,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_365 = 1365,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_366 = 1366,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_367 = 1367,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_368 = 1368,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_369 = 1369,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_370 = 1370,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_371 = 1371,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_372 = 1372,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_373 = 1373,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_374 = 1374,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_375 = 1375,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_376 = 1376,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_377 = 1377,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_378 = 1378,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_379 = 1379,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_380 = 1380,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_381 = 1381,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_382 = 1382,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_383 = 1383,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_384 = 1384,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_385 = 1385,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_386 = 1386,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_387 = 1387,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_388 = 1388,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_389 = 1389,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_390 = 1390,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_391 = 1391,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_392 = 1392,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_393 = 1393,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_394 = 1394,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_395 = 1395,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_396 = 1396,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_397 = 1397,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_398 = 1398,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_399 = 1399,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_400 = 1400,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_401 = 1401,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_402 = 1402,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_403 = 1403,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_404 = 1404,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_405 = 1405,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_406 = 1406,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_407 = 1407,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_408 = 1408,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_409 = 1409,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_410 = 1410,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_411 = 1411,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_412 = 1412,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_413 = 1413,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_414 = 1414,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_415 = 1415,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_416 = 1416,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_417 = 1417,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_418 = 1418,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_419 = 1419,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_420 = 1420,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_421 = 1421,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_422 = 1422,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_423 = 1423,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_424 = 1424,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_425 = 1425,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_426 = 1426,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_427 = 1427,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_428 = 1428,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_429 = 1429,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_430 = 1430,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_431 = 1431,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_432 = 1432,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_433 = 1433,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_434 = 1434,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_435 = 1435,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_436 = 1436,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_437 = 1437,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_438 = 1438,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_439 = 1439,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_440 = 1440,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_441 = 1441,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_442 = 1442,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_443 = 1443,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_444 = 1444,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_445 = 1445,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_446 = 1446,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_447 = 1447,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_448 = 1448,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_449 = 1449,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_450 = 1450,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_451 = 1451,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_452 = 1452,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_453 = 1453,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_454 = 1454,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_455 = 1455,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_456 = 1456,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_457 = 1457,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_458 = 1458,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_459 = 1459,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_460 = 1460,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_461 = 1461,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_462 = 1462,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_463 = 1463,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_464 = 1464,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_465 = 1465,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_466 = 1466,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_467 = 1467,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_468 = 1468,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_469 = 1469,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_470 = 1470,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_471 = 1471,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_472 = 1472,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_473 = 1473,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_474 = 1474,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_475 = 1475,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_476 = 1476,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_477 = 1477,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_478 = 1478,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_479 = 1479,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_480 = 1480,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_481 = 1481,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_482 = 1482,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_483 = 1483,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_484 = 1484,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_485 = 1485,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_486 = 1486,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_487 = 1487,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_488 = 1488,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_489 = 1489,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_490 = 1490,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_491 = 1491,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_492 = 1492,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_493 = 1493,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_494 = 1494,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_495 = 1495,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_496 = 1496,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_497 = 1497,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_498 = 1498,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_499 = 1499,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_500 = 1500,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_501 = 1501,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_502 = 1502,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_503 = 1503,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_504 = 1504,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_505 = 1505,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_506 = 1506,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_507 = 1507,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_508 = 1508,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_509 = 1509,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_510 = 1510,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_511 = 1511,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_512 = 1512,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_513 = 1513,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_514 = 1514,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_515 = 1515,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_516 = 1516,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_517 = 1517,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_518 = 1518,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_519 = 1519,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_520 = 1520,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_521 = 1521,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_522 = 1522,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_523 = 1523,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_524 = 1524,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_525 = 1525,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_526 = 1526,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_527 = 1527,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_528 = 1528,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_529 = 1529,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_530 = 1530,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_531 = 1531,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_532 = 1532,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_533 = 1533,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_534 = 1534,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_535 = 1535,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_536 = 1536,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_537 = 1537,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_538 = 1538,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_539 = 1539,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_540 = 1540,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_541 = 1541,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_542 = 1542,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_543 = 1543,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_544 = 1544,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_545 = 1545,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_546 = 1546,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_547 = 1547,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_548 = 1548,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_549 = 1549,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_550 = 1550,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_551 = 1551,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_552 = 1552,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_553 = 1553,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_554 = 1554,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_555 = 1555,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_556 = 1556,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_557 = 1557,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_558 = 1558,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_559 = 1559,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_560 = 1560,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_561 = 1561,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_562 = 1562,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_563 = 1563,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_564 = 1564,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_565 = 1565,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_566 = 1566,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_567 = 1567,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_568 = 1568,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_569 = 1569,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_570 = 1570,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_571 = 1571,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_572 = 1572,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_573 = 1573,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_574 = 1574,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_575 = 1575,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_576 = 1576,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_577 = 1577,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_578 = 1578,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_579 = 1579,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_580 = 1580,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_581 = 1581,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_582 = 1582,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_583 = 1583,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_584 = 1584,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_585 = 1585,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_586 = 1586,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_587 = 1587,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_588 = 1588,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_589 = 1589,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_590 = 1590,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_591 = 1591,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_592 = 1592,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_593 = 1593,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_594 = 1594,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_595 = 1595,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_596 = 1596,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_597 = 1597,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_598 = 1598,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_599 = 1599,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_600 = 1600,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_601 = 1601,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_602 = 1602,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_603 = 1603,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_604 = 1604,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_605 = 1605,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_606 = 1606,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_607 = 1607,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_608 = 1608,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_609 = 1609,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_610 = 1610,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_611 = 1611,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_612 = 1612,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_613 = 1613,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_614 = 1614,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_615 = 1615,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_616 = 1616,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_617 = 1617,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_618 = 1618,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_619 = 1619,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_620 = 1620,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_621 = 1621,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_622 = 1622,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_623 = 1623,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_624 = 1624,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_625 = 1625,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_626 = 1626,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_627 = 1627,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_628 = 1628,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_629 = 1629,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_630 = 1630,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_631 = 1631,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_632 = 1632,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_633 = 1633,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_634 = 1634,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_635 = 1635,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_636 = 1636,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_637 = 1637,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_638 = 1638,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_639 = 1639,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_640 = 1640,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_641 = 1641,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_642 = 1642,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_643 = 1643,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_644 = 1644,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_645 = 1645,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_646 = 1646,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_647 = 1647,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_648 = 1648,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_649 = 1649,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_650 = 1650,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_651 = 1651,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_652 = 1652,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_653 = 1653,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_654 = 1654,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_655 = 1655,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_656 = 1656,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_657 = 1657,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_658 = 1658,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_659 = 1659,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_660 = 1660,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_661 = 1661,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_662 = 1662,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_663 = 1663,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_664 = 1664,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_665 = 1665,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_666 = 1666,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_667 = 1667,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_668 = 1668,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_669 = 1669,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_670 = 1670,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_671 = 1671,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_672 = 1672,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_673 = 1673,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_674 = 1674,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_675 = 1675,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_676 = 1676,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_677 = 1677,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_678 = 1678,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_679 = 1679,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_680 = 1680,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_681 = 1681,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_682 = 1682,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_683 = 1683,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_684 = 1684,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_685 = 1685,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_686 = 1686,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_687 = 1687,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_688 = 1688,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_689 = 1689,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_690 = 1690,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_691 = 1691,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_692 = 1692,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_693 = 1693,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_694 = 1694,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_695 = 1695,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_696 = 1696,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_697 = 1697,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_698 = 1698,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_699 = 1699,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_700 = 1700,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_701 = 1701,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_702 = 1702,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_703 = 1703,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_704 = 1704,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_705 = 1705,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_706 = 1706,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_707 = 1707,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_708 = 1708,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_709 = 1709,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_710 = 1710,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_711 = 1711,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_712 = 1712,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_713 = 1713,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_714 = 1714,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_715 = 1715,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_716 = 1716,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_717 = 1717,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_718 = 1718,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_719 = 1719,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_720 = 1720,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_721 = 1721,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_722 = 1722,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_723 = 1723,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_724 = 1724,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_725 = 1725,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_726 = 1726,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_727 = 1727,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_728 = 1728,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_729 = 1729,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_730 = 1730,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_731 = 1731,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_732 = 1732,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_733 = 1733,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_734 = 1734,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_735 = 1735,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_736 = 1736,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_737 = 1737,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_738 = 1738,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_739 = 1739,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_740 = 1740,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_741 = 1741,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_742 = 1742,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_743 = 1743,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_744 = 1744,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_745 = 1745,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_746 = 1746,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_747 = 1747,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_748 = 1748,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_749 = 1749,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_750 = 1750,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_751 = 1751,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_752 = 1752,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_753 = 1753,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_754 = 1754,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_755 = 1755,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_756 = 1756,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_757 = 1757,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_758 = 1758,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_759 = 1759,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_760 = 1760,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_761 = 1761,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_762 = 1762,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_763 = 1763,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_764 = 1764,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_765 = 1765,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_766 = 1766,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_767 = 1767,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_768 = 1768,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_769 = 1769,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_770 = 1770,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_771 = 1771,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_772 = 1772,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_773 = 1773,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_774 = 1774,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_775 = 1775,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_776 = 1776,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_777 = 1777,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_778 = 1778,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_779 = 1779,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_780 = 1780,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_781 = 1781,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_782 = 1782,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_783 = 1783,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_784 = 1784,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_785 = 1785,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_786 = 1786,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_787 = 1787,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_788 = 1788,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_789 = 1789,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_790 = 1790,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_791 = 1791,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_792 = 1792,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_793 = 1793,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_794 = 1794,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_795 = 1795,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_796 = 1796,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_797 = 1797,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_798 = 1798,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_799 = 1799,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_800 = 1800,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_801 = 1801,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_802 = 1802,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_803 = 1803,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_804 = 1804,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_805 = 1805,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_806 = 1806,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_807 = 1807,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_808 = 1808,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_809 = 1809,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_810 = 1810,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_811 = 1811,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_812 = 1812,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_813 = 1813,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_814 = 1814,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_815 = 1815,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_816 = 1816,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_817 = 1817,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_818 = 1818,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_819 = 1819,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_820 = 1820,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_821 = 1821,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_822 = 1822,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_823 = 1823,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_824 = 1824,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_825 = 1825,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_826 = 1826,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_827 = 1827,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_828 = 1828,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_829 = 1829,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_830 = 1830,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_831 = 1831,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_832 = 1832,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_833 = 1833,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_834 = 1834,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_835 = 1835,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_836 = 1836,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_837 = 1837,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_838 = 1838,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_839 = 1839,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_840 = 1840,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_841 = 1841,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_842 = 1842,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_843 = 1843,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_844 = 1844,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_845 = 1845,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_846 = 1846,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_847 = 1847,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_848 = 1848,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_849 = 1849,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_850 = 1850,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_851 = 1851,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_852 = 1852,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_853 = 1853,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_854 = 1854,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_855 = 1855,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_856 = 1856,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_857 = 1857,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_858 = 1858,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_859 = 1859,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_860 = 1860,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_861 = 1861,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_862 = 1862,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_863 = 1863,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_864 = 1864,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_865 = 1865,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_866 = 1866,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_867 = 1867,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_868 = 1868,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_869 = 1869,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_870 = 1870,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_871 = 1871,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_872 = 1872,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_873 = 1873,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_874 = 1874,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_875 = 1875,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_876 = 1876,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_877 = 1877,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_878 = 1878,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_879 = 1879,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_880 = 1880,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_881 = 1881,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_882 = 1882,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_883 = 1883,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_884 = 1884,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_885 = 1885,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_886 = 1886,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_887 = 1887,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_888 = 1888,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_889 = 1889,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_890 = 1890,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_891 = 1891,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_892 = 1892,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_893 = 1893,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_894 = 1894,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_895 = 1895,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_896 = 1896,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_897 = 1897,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_898 = 1898,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_899 = 1899,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_900 = 1900,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_901 = 1901,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_902 = 1902,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_903 = 1903,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_904 = 1904,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_905 = 1905,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_906 = 1906,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_907 = 1907,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_908 = 1908,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_909 = 1909,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_910 = 1910,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_911 = 1911,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_912 = 1912,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_913 = 1913,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_914 = 1914,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_915 = 1915,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_916 = 1916,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_917 = 1917,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_918 = 1918,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_919 = 1919,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_920 = 1920,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_921 = 1921,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_922 = 1922,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_923 = 1923,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_924 = 1924,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_925 = 1925,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_926 = 1926,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_927 = 1927,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_928 = 1928,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_929 = 1929,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_930 = 1930,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_931 = 1931,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_932 = 1932,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_933 = 1933,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_934 = 1934,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_935 = 1935,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_936 = 1936,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_937 = 1937,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_938 = 1938,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_939 = 1939,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_940 = 1940,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_941 = 1941,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_942 = 1942,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_943 = 1943,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_944 = 1944,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_945 = 1945,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_946 = 1946,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_947 = 1947,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_948 = 1948,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_949 = 1949,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_950 = 1950,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_951 = 1951,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_952 = 1952,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_953 = 1953,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_954 = 1954,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_955 = 1955,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_956 = 1956,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_957 = 1957,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_958 = 1958,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_959 = 1959,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_960 = 1960,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_961 = 1961,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_962 = 1962,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_963 = 1963,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_964 = 1964,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_965 = 1965,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_966 = 1966,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_967 = 1967,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_968 = 1968,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_969 = 1969,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_970 = 1970,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_971 = 1971,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_972 = 1972,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_973 = 1973,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_974 = 1974,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_975 = 1975,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_976 = 1976,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_977 = 1977,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_978 = 1978,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_979 = 1979,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_980 = 1980,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_981 = 1981,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_982 = 1982,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_983 = 1983,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_984 = 1984,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_985 = 1985,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_986 = 1986,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_987 = 1987,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_988 = 1988,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_989 = 1989,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_990 = 1990,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_991 = 1991,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_992 = 1992,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_993 = 1993,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_994 = 1994,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_995 = 1995,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_996 = 1996,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_997 = 1997,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_998 = 1998,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_999 = 1999,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_0 = 2000,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_1 = 2001,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_2 = 2002,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_3 = 2003,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_4 = 2004,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_5 = 2005,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_6 = 2006,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_7 = 2007,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_8 = 2008,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_9 = 2009,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_10 = 2010,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_11 = 2011,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_12 = 2012,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_13 = 2013,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_14 = 2014,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_15 = 2015,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_16 = 2016,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_17 = 2017,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_18 = 2018,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_19 = 2019,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_20 = 2020,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_21 = 2021,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_22 = 2022,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_23 = 2023,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_24 = 2024,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_25 = 2025,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_26 = 2026,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_27 = 2027,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_28 = 2028,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_29 = 2029,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_30 = 2030,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_31 = 2031,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_32 = 2032,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_33 = 2033,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_34 = 2034,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_35 = 2035,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_36 = 2036,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_37 = 2037,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_38 = 2038,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_39 = 2039,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_40 = 2040,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_41 = 2041,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_42 = 2042,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_43 = 2043,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_44 = 2044,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_45 = 2045,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_46 = 2046,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_47 = 2047,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_48 = 2048,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_49 = 2049,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_50 = 2050,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_51 = 2051,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_52 = 2052,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_53 = 2053,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_54 = 2054,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_55 = 2055,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_56 = 2056,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_57 = 2057,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_58 = 2058,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_59 = 2059,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_60 = 2060,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_61 = 2061,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_62 = 2062,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_63 = 2063,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_64 = 2064,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_65 = 2065,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_66 = 2066,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_67 = 2067,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_68 = 2068,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_69 = 2069,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_70 = 2070,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_71 = 2071,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_72 = 2072,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_73 = 2073,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_74 = 2074,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_75 = 2075,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_76 = 2076,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_77 = 2077,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_78 = 2078,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_79 = 2079,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_80 = 2080,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_81 = 2081,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_82 = 2082,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_83 = 2083,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_84 = 2084,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_85 = 2085,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_86 = 2086,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_87 = 2087,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_88 = 2088,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_89 = 2089,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_90 = 2090,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_91 = 2091,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_92 = 2092,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_93 = 2093,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_94 = 2094,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_95 = 2095,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_96 = 2096,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_97 = 2097,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_98 = 2098,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_99 = 2099,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_100 = 2100,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_101 = 2101,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_102 = 2102,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_103 = 2103,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_104 = 2104,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_105 = 2105,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_106 = 2106,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_107 = 2107,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_108 = 2108,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_109 = 2109,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_110 = 2110,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_111 = 2111,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_112 = 2112,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_113 = 2113,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_114 = 2114,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_115 = 2115,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_116 = 2116,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_117 = 2117,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_118 = 2118,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_119 = 2119,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_120 = 2120,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_121 = 2121,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_122 = 2122,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_123 = 2123,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_124 = 2124,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_125 = 2125,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_126 = 2126,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_127 = 2127,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_128 = 2128,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_129 = 2129,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_130 = 2130,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_131 = 2131,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_132 = 2132,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_133 = 2133,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_134 = 2134,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_135 = 2135,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_136 = 2136,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_137 = 2137,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_138 = 2138,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_139 = 2139,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_140 = 2140,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_141 = 2141,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_142 = 2142,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_143 = 2143,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_144 = 2144,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_145 = 2145,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_146 = 2146,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_147 = 2147,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_148 = 2148,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_149 = 2149,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_150 = 2150,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_151 = 2151,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_152 = 2152,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_153 = 2153,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_154 = 2154,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_155 = 2155,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_156 = 2156,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_157 = 2157,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_158 = 2158,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_159 = 2159,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_160 = 2160,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_161 = 2161,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_162 = 2162,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_163 = 2163,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_164 = 2164,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_165 = 2165,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_166 = 2166,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_167 = 2167,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_168 = 2168,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_169 = 2169,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_170 = 2170,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_171 = 2171,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_172 = 2172,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_173 = 2173,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_174 = 2174,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_175 = 2175,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_176 = 2176,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_177 = 2177,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_178 = 2178,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_179 = 2179,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_180 = 2180,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_181 = 2181,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_182 = 2182,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_183 = 2183,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_184 = 2184,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_185 = 2185,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_186 = 2186,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_187 = 2187,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_188 = 2188,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_189 = 2189,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_190 = 2190,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_191 = 2191,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_192 = 2192,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_193 = 2193,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_194 = 2194,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_195 = 2195,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_196 = 2196,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_197 = 2197,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_198 = 2198,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_199 = 2199,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_200 = 2200,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_201 = 2201,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_202 = 2202,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_203 = 2203,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_204 = 2204,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_205 = 2205,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_206 = 2206,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_207 = 2207,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_208 = 2208,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_209 = 2209,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_210 = 2210,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_211 = 2211,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_212 = 2212,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_213 = 2213,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_214 = 2214,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_215 = 2215,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_216 = 2216,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_217 = 2217,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_218 = 2218,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_219 = 2219,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_220 = 2220,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_221 = 2221,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_222 = 2222,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_223 = 2223,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_224 = 2224,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_225 = 2225,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_226 = 2226,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_227 = 2227,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_228 = 2228,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_229 = 2229,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_230 = 2230,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_231 = 2231,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_232 = 2232,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_233 = 2233,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_234 = 2234,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_235 = 2235,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_236 = 2236,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_237 = 2237,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_238 = 2238,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_239 = 2239,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_240 = 2240,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_241 = 2241,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_242 = 2242,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_243 = 2243,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_244 = 2244,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_245 = 2245,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_246 = 2246,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_247 = 2247,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_248 = 2248,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_249 = 2249,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_250 = 2250,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_251 = 2251,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_252 = 2252,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_253 = 2253,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_254 = 2254,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_255 = 2255,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_256 = 2256,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_257 = 2257,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_258 = 2258,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_259 = 2259,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_260 = 2260,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_261 = 2261,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_262 = 2262,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_263 = 2263,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_264 = 2264,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_265 = 2265,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_266 = 2266,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_267 = 2267,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_268 = 2268,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_269 = 2269,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_270 = 2270,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_271 = 2271,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_272 = 2272,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_273 = 2273,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_274 = 2274,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_275 = 2275,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_276 = 2276,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_277 = 2277,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_278 = 2278,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_279 = 2279,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_280 = 2280,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_281 = 2281,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_282 = 2282,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_283 = 2283,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_284 = 2284,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_285 = 2285,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_286 = 2286,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_287 = 2287,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_288 = 2288,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_289 = 2289,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_290 = 2290,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_291 = 2291,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_292 = 2292,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_293 = 2293,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_294 = 2294,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_295 = 2295,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_296 = 2296,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_297 = 2297,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_298 = 2298,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_299 = 2299,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_300 = 2300,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_301 = 2301,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_302 = 2302,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_303 = 2303,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_304 = 2304,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_305 = 2305,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_306 = 2306,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_307 = 2307,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_308 = 2308,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_309 = 2309,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_310 = 2310,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_311 = 2311,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_312 = 2312,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_313 = 2313,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_314 = 2314,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_315 = 2315,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_316 = 2316,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_317 = 2317,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_318 = 2318,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_319 = 2319,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_320 = 2320,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_321 = 2321,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_322 = 2322,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_323 = 2323,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_324 = 2324,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_325 = 2325,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_326 = 2326,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_327 = 2327,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_328 = 2328,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_329 = 2329,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_330 = 2330,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_331 = 2331,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_332 = 2332,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_333 = 2333,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_334 = 2334,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_335 = 2335,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_336 = 2336,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_337 = 2337,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_338 = 2338,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_339 = 2339,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_340 = 2340,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_341 = 2341,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_342 = 2342,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_343 = 2343,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_344 = 2344,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_345 = 2345,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_346 = 2346,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_347 = 2347,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_348 = 2348,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_349 = 2349,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_350 = 2350,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_351 = 2351,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_352 = 2352,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_353 = 2353,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_354 = 2354,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_355 = 2355,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_356 = 2356,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_357 = 2357,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_358 = 2358,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_359 = 2359,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_360 = 2360,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_361 = 2361,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_362 = 2362,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_363 = 2363,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_364 = 2364,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_365 = 2365,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_366 = 2366,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_367 = 2367,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_368 = 2368,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_369 = 2369,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_370 = 2370,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_371 = 2371,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_372 = 2372,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_373 = 2373,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_374 = 2374,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_375 = 2375,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_376 = 2376,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_377 = 2377,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_378 = 2378,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_379 = 2379,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_380 = 2380,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_381 = 2381,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_382 = 2382,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_383 = 2383,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_384 = 2384,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_385 = 2385,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_386 = 2386,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_387 = 2387,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_388 = 2388,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_389 = 2389,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_390 = 2390,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_391 = 2391,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_392 = 2392,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_393 = 2393,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_394 = 2394,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_395 = 2395,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_396 = 2396,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_397 = 2397,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_398 = 2398,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_399 = 2399,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_400 = 2400,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_401 = 2401,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_402 = 2402,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_403 = 2403,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_404 = 2404,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_405 = 2405,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_406 = 2406,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_407 = 2407,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_408 = 2408,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_409 = 2409,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_410 = 2410,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_411 = 2411,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_412 = 2412,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_413 = 2413,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_414 = 2414,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_415 = 2415,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_416 = 2416,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_417 = 2417,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_418 = 2418,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_419 = 2419,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_420 = 2420,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_421 = 2421,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_422 = 2422,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_423 = 2423,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_424 = 2424,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_425 = 2425,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_426 = 2426,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_427 = 2427,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_428 = 2428,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_429 = 2429,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_430 = 2430,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_431 = 2431,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_432 = 2432,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_433 = 2433,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_434 = 2434,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_435 = 2435,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_436 = 2436,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_437 = 2437,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_438 = 2438,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_439 = 2439,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_440 = 2440,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_441 = 2441,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_442 = 2442,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_443 = 2443,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_444 = 2444,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_445 = 2445,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_446 = 2446,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_447 = 2447,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_448 = 2448,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_449 = 2449,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_450 = 2450,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_451 = 2451,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_452 = 2452,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_453 = 2453,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_454 = 2454,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_455 = 2455,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_456 = 2456,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_457 = 2457,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_458 = 2458,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_459 = 2459,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_460 = 2460,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_461 = 2461,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_462 = 2462,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_463 = 2463,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_464 = 2464,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_465 = 2465,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_466 = 2466,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_467 = 2467,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_468 = 2468,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_469 = 2469,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_470 = 2470,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_471 = 2471,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_472 = 2472,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_473 = 2473,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_474 = 2474,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_475 = 2475,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_476 = 2476,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_477 = 2477,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_478 = 2478,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_479 = 2479,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_480 = 2480,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_481 = 2481,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_482 = 2482,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_483 = 2483,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_484 = 2484,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_485 = 2485,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_486 = 2486,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_487 = 2487,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_488 = 2488,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_489 = 2489,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_490 = 2490,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_491 = 2491,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_492 = 2492,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_493 = 2493,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_494 = 2494,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_495 = 2495,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_496 = 2496,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_497 = 2497,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_498 = 2498,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_499 = 2499,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_500 = 2500,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_501 = 2501,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_502 = 2502,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_503 = 2503,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_504 = 2504,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_505 = 2505,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_506 = 2506,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_507 = 2507,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_508 = 2508,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_509 = 2509,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_510 = 2510,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_511 = 2511,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_512 = 2512,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_513 = 2513,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_514 = 2514,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_515 = 2515,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_516 = 2516,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_517 = 2517,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_518 = 2518,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_519 = 2519,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_520 = 2520,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_521 = 2521,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_522 = 2522,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_523 = 2523,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_524 = 2524,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_525 = 2525,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_526 = 2526,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_527 = 2527,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_528 = 2528,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_529 = 2529,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_530 = 2530,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_531 = 2531,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_532 = 2532,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_533 = 2533,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_534 = 2534,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_535 = 2535,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_536 = 2536,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_537 = 2537,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_538 = 2538,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_539 = 2539,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_540 = 2540,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_541 = 2541,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_542 = 2542,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_543 = 2543,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_544 = 2544,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_545 = 2545,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_546 = 2546,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_547 = 2547,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_548 = 2548,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_549 = 2549,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_550 = 2550,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_551 = 2551,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_552 = 2552,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_553 = 2553,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_554 = 2554,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_555 = 2555,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_556 = 2556,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_557 = 2557,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_558 = 2558,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_559 = 2559,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_560 = 2560,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_561 = 2561,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_562 = 2562,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_563 = 2563,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_564 = 2564,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_565 = 2565,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_566 = 2566,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_567 = 2567,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_568 = 2568,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_569 = 2569,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_570 = 2570,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_571 = 2571,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_572 = 2572,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_573 = 2573,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_574 = 2574,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_575 = 2575,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_576 = 2576,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_577 = 2577,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_578 = 2578,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_579 = 2579,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_580 = 2580,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_581 = 2581,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_582 = 2582,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_583 = 2583,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_584 = 2584,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_585 = 2585,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_586 = 2586,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_587 = 2587,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_588 = 2588,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_589 = 2589,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_590 = 2590,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_591 = 2591,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_592 = 2592,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_593 = 2593,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_594 = 2594,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_595 = 2595,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_596 = 2596,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_597 = 2597,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_598 = 2598,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_599 = 2599,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_600 = 2600,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_601 = 2601,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_602 = 2602,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_603 = 2603,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_604 = 2604,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_605 = 2605,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_606 = 2606,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_607 = 2607,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_608 = 2608,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_609 = 2609,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_610 = 2610,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_611 = 2611,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_612 = 2612,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_613 = 2613,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_614 = 2614,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_615 = 2615,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_616 = 2616,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_617 = 2617,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_618 = 2618,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_619 = 2619,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_620 = 2620,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_621 = 2621,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_622 = 2622,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_623 = 2623,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_624 = 2624,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_625 = 2625,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_626 = 2626,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_627 = 2627,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_628 = 2628,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_629 = 2629,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_630 = 2630,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_631 = 2631,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_632 = 2632,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_633 = 2633,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_634 = 2634,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_635 = 2635,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_636 = 2636,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_637 = 2637,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_638 = 2638,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_639 = 2639,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_640 = 2640,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_641 = 2641,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_642 = 2642,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_643 = 2643,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_644 = 2644,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_645 = 2645,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_646 = 2646,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_647 = 2647,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_648 = 2648,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_649 = 2649,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_650 = 2650,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_651 = 2651,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_652 = 2652,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_653 = 2653,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_654 = 2654,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_655 = 2655,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_656 = 2656,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_657 = 2657,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_658 = 2658,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_659 = 2659,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_660 = 2660,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_661 = 2661,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_662 = 2662,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_663 = 2663,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_664 = 2664,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_665 = 2665,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_666 = 2666,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_667 = 2667,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_668 = 2668,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_669 = 2669,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_670 = 2670,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_671 = 2671,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_672 = 2672,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_673 = 2673,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_674 = 2674,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_675 = 2675,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_676 = 2676,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_677 = 2677,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_678 = 2678,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_679 = 2679,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_680 = 2680,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_681 = 2681,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_682 = 2682,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_683 = 2683,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_684 = 2684,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_685 = 2685,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_686 = 2686,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_687 = 2687,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_688 = 2688,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_689 = 2689,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_690 = 2690,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_691 = 2691,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_692 = 2692,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_693 = 2693,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_694 = 2694,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_695 = 2695,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_696 = 2696,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_697 = 2697,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_698 = 2698,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_699 = 2699,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_700 = 2700,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_701 = 2701,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_702 = 2702,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_703 = 2703,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_704 = 2704,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_705 = 2705,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_706 = 2706,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_707 = 2707,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_708 = 2708,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_709 = 2709,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_710 = 2710,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_711 = 2711,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_712 = 2712,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_713 = 2713,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_714 = 2714,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_715 = 2715,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_716 = 2716,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_717 = 2717,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_718 = 2718,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_719 = 2719,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_720 = 2720,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_721 = 2721,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_722 = 2722,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_723 = 2723,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_724 = 2724,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_725 = 2725,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_726 = 2726,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_727 = 2727,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_728 = 2728,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_729 = 2729,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_730 = 2730,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_731 = 2731,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_732 = 2732,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_733 = 2733,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_734 = 2734,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_735 = 2735,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_736 = 2736,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_737 = 2737,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_738 = 2738,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_739 = 2739,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_740 = 2740,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_741 = 2741,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_742 = 2742,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_743 = 2743,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_744 = 2744,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_745 = 2745,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_746 = 2746,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_747 = 2747,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_748 = 2748,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_749 = 2749,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_750 = 2750,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_751 = 2751,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_752 = 2752,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_753 = 2753,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_754 = 2754,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_755 = 2755,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_756 = 2756,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_757 = 2757,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_758 = 2758,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_759 = 2759,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_760 = 2760,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_761 = 2761,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_762 = 2762,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_763 = 2763,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_764 = 2764,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_765 = 2765,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_766 = 2766,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_767 = 2767,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_768 = 2768,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_769 = 2769,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_770 = 2770,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_771 = 2771,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_772 = 2772,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_773 = 2773,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_774 = 2774,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_775 = 2775,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_776 = 2776,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_777 = 2777,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_778 = 2778,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_779 = 2779,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_780 = 2780,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_781 = 2781,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_782 = 2782,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_783 = 2783,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_784 = 2784,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_785 = 2785,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_786 = 2786,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_787 = 2787,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_788 = 2788,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_789 = 2789,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_790 = 2790,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_791 = 2791,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_792 = 2792,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_793 = 2793,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_794 = 2794,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_795 = 2795,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_796 = 2796,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_797 = 2797,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_798 = 2798,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_799 = 2799,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_800 = 2800,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_801 = 2801,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_802 = 2802,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_803 = 2803,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_804 = 2804,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_805 = 2805,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_806 = 2806,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_807 = 2807,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_808 = 2808,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_809 = 2809,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_810 = 2810,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_811 = 2811,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_812 = 2812,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_813 = 2813,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_814 = 2814,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_815 = 2815,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_816 = 2816,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_817 = 2817,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_818 = 2818,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_819 = 2819,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_820 = 2820,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_821 = 2821,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_822 = 2822,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_823 = 2823,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_824 = 2824,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_825 = 2825,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_826 = 2826,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_827 = 2827,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_828 = 2828,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_829 = 2829,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_830 = 2830,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_831 = 2831,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_832 = 2832,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_833 = 2833,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_834 = 2834,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_835 = 2835,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_836 = 2836,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_837 = 2837,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_838 = 2838,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_839 = 2839,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_840 = 2840,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_841 = 2841,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_842 = 2842,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_843 = 2843,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_844 = 2844,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_845 = 2845,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_846 = 2846,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_847 = 2847,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_848 = 2848,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_849 = 2849,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_850 = 2850,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_851 = 2851,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_852 = 2852,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_853 = 2853,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_854 = 2854,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_855 = 2855,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_856 = 2856,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_857 = 2857,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_858 = 2858,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_859 = 2859,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_860 = 2860,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_861 = 2861,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_862 = 2862,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_863 = 2863,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_864 = 2864,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_865 = 2865,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_866 = 2866,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_867 = 2867,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_868 = 2868,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_869 = 2869,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_870 = 2870,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_871 = 2871,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_872 = 2872,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_873 = 2873,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_874 = 2874,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_875 = 2875,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_876 = 2876,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_877 = 2877,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_878 = 2878,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_879 = 2879,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_880 = 2880,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_881 = 2881,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_882 = 2882,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_883 = 2883,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_884 = 2884,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_885 = 2885,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_886 = 2886,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_887 = 2887,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_888 = 2888,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_889 = 2889,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_890 = 2890,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_891 = 2891,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_892 = 2892,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_893 = 2893,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_894 = 2894,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_895 = 2895,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_896 = 2896,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_897 = 2897,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_898 = 2898,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_899 = 2899,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_900 = 2900,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_901 = 2901,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_902 = 2902,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_903 = 2903,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_904 = 2904,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_905 = 2905,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_906 = 2906,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_907 = 2907,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_908 = 2908,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_909 = 2909,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_910 = 2910,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_911 = 2911,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_912 = 2912,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_913 = 2913,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_914 = 2914,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_915 = 2915,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_916 = 2916,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_917 = 2917,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_918 = 2918,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_919 = 2919,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_920 = 2920,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_921 = 2921,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_922 = 2922,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_923 = 2923,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_924 = 2924,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_925 = 2925,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_926 = 2926,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_927 = 2927,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_928 = 2928,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_929 = 2929,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_930 = 2930,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_931 = 2931,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_932 = 2932,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_933 = 2933,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_934 = 2934,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_935 = 2935,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_936 = 2936,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_937 = 2937,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_938 = 2938,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_939 = 2939,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_940 = 2940,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_941 = 2941,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_942 = 2942,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_943 = 2943,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_944 = 2944,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_945 = 2945,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_946 = 2946,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_947 = 2947,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_948 = 2948,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_949 = 2949,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_950 = 2950,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_951 = 2951,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_952 = 2952,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_953 = 2953,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_954 = 2954,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_955 = 2955,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_956 = 2956,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_957 = 2957,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_958 = 2958,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_959 = 2959,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_960 = 2960,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_961 = 2961,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_962 = 2962,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_963 = 2963,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_964 = 2964,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_965 = 2965,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_966 = 2966,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_967 = 2967,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_968 = 2968,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_969 = 2969,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_970 = 2970,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_971 = 2971,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_972 = 2972,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_973 = 2973,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_974 = 2974,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_975 = 2975,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_976 = 2976,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_977 = 2977,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_978 = 2978,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_979 = 2979,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_980 = 2980,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_981 = 2981,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_982 = 2982,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_983 = 2983,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_984 = 2984,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_985 = 2985,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_986 = 2986,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_987 = 2987,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_988 = 2988,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_989 = 2989,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_990 = 2990,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_991 = 2991,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_992 = 2992,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_993 = 2993,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_994 = 2994,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_995 = 2995,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_996 = 2996,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_997 = 2997,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_998 = 2998,
            PARAMETER_MB_ADDR_SHODOW_HOLDING_REGISTER_CONFIG_999 = 2999,
            PARAMETER_MB_ADDR_RESERVE4_0 = 3000,
            PARAMETER_MB_ADDR_RESERVE4_1 = 3001,
            PARAMETER_MB_ADDR_RESERVE4_2 = 3002,
            PARAMETER_MB_ADDR_RESERVE4_3 = 3003,
            PARAMETER_MB_ADDR_RESERVE4_4 = 3004,
            PARAMETER_MB_ADDR_RESERVE4_5 = 3005,
            PARAMETER_MB_ADDR_RESERVE4_6 = 3006,
            PARAMETER_MB_ADDR_RESERVE4_7 = 3007,
            PARAMETER_MB_ADDR_RESERVE4_8 = 3008,
            PARAMETER_MB_ADDR_RESERVE4_9 = 3009,
            PARAMETER_MB_ADDR_RESERVE4_10 = 3010,
            PARAMETER_MB_ADDR_RESERVE4_11 = 3011,
            PARAMETER_MB_ADDR_RESERVE4_12 = 3012,
            PARAMETER_MB_ADDR_RESERVE4_13 = 3013,
            PARAMETER_MB_ADDR_RESERVE4_14 = 3014,
            PARAMETER_MB_ADDR_RESERVE4_15 = 3015,
            PARAMETER_MB_ADDR_RESERVE4_16 = 3016,
            PARAMETER_MB_ADDR_RESERVE4_17 = 3017,
            PARAMETER_MB_ADDR_RESERVE4_18 = 3018,
            PARAMETER_MB_ADDR_RESERVE4_19 = 3019,
            PARAMETER_MB_ADDR_RESERVE4_20 = 3020,
            PARAMETER_MB_ADDR_RESERVE4_21 = 3021,
            PARAMETER_MB_ADDR_RESERVE4_22 = 3022,
            PARAMETER_MB_ADDR_RESERVE4_23 = 3023,
            PARAMETER_MB_ADDR_RESERVE4_24 = 3024,
            PARAMETER_MB_ADDR_RESERVE4_25 = 3025,
            PARAMETER_MB_ADDR_RESERVE4_26 = 3026,
            PARAMETER_MB_ADDR_RESERVE4_27 = 3027,
            PARAMETER_MB_ADDR_RESERVE4_28 = 3028,
            PARAMETER_MB_ADDR_RESERVE4_29 = 3029,
            PARAMETER_MB_ADDR_RESERVE4_30 = 3030,
            PARAMETER_MB_ADDR_RESERVE4_31 = 3031,
            PARAMETER_MB_ADDR_RESERVE4_32 = 3032,
            PARAMETER_MB_ADDR_RESERVE4_33 = 3033,
            PARAMETER_MB_ADDR_RESERVE4_34 = 3034,
            PARAMETER_MB_ADDR_RESERVE4_35 = 3035,
            PARAMETER_MB_ADDR_RESERVE4_36 = 3036,
            PARAMETER_MB_ADDR_RESERVE4_37 = 3037,
            PARAMETER_MB_ADDR_RESERVE4_38 = 3038,
            PARAMETER_MB_ADDR_RESERVE4_39 = 3039,
            PARAMETER_MB_ADDR_RESERVE4_40 = 3040,
            PARAMETER_MB_ADDR_RESERVE4_41 = 3041,
            PARAMETER_MB_ADDR_RESERVE4_42 = 3042,
            PARAMETER_MB_ADDR_RESERVE4_43 = 3043,
            PARAMETER_MB_ADDR_RESERVE4_44 = 3044,
            PARAMETER_MB_ADDR_RESERVE4_45 = 3045,
            PARAMETER_MB_ADDR_RESERVE4_46 = 3046,
            PARAMETER_MB_ADDR_RESERVE4_47 = 3047,
            PARAMETER_MB_ADDR_RESERVE4_48 = 3048,
            PARAMETER_MB_ADDR_RESERVE4_49 = 3049,
            PARAMETER_MB_ADDR_RESERVE4_50 = 3050,
            PARAMETER_MB_ADDR_RESERVE4_51 = 3051,
            PARAMETER_MB_ADDR_RESERVE4_52 = 3052,
            PARAMETER_MB_ADDR_RESERVE4_53 = 3053,
            PARAMETER_MB_ADDR_RESERVE4_54 = 3054,
            PARAMETER_MB_ADDR_RESERVE4_55 = 3055,
            PARAMETER_MB_ADDR_RESERVE4_56 = 3056,
            PARAMETER_MB_ADDR_RESERVE4_57 = 3057,
            PARAMETER_MB_ADDR_RESERVE4_58 = 3058,
            PARAMETER_MB_ADDR_RESERVE4_59 = 3059,
            PARAMETER_MB_ADDR_RESERVE4_60 = 3060,
            PARAMETER_MB_ADDR_RESERVE4_61 = 3061,
            PARAMETER_MB_ADDR_RESERVE4_62 = 3062,
            PARAMETER_MB_ADDR_RESERVE4_63 = 3063,
            PARAMETER_MB_ADDR_RESERVE4_64 = 3064,
            PARAMETER_MB_ADDR_RESERVE4_65 = 3065,
            PARAMETER_MB_ADDR_RESERVE4_66 = 3066,
            PARAMETER_MB_ADDR_RESERVE4_67 = 3067,
            PARAMETER_MB_ADDR_RESERVE4_68 = 3068,
            PARAMETER_MB_ADDR_RESERVE4_69 = 3069,
            PARAMETER_MB_ADDR_RESERVE4_70 = 3070,
            PARAMETER_MB_ADDR_RESERVE4_71 = 3071,
            PARAMETER_MB_ADDR_RESERVE4_72 = 3072,
            PARAMETER_MB_ADDR_RESERVE4_73 = 3073,
            PARAMETER_MB_ADDR_RESERVE4_74 = 3074,
            PARAMETER_MB_ADDR_RESERVE4_75 = 3075,
            PARAMETER_MB_ADDR_RESERVE4_76 = 3076,
            PARAMETER_MB_ADDR_RESERVE4_77 = 3077,
            PARAMETER_MB_ADDR_RESERVE4_78 = 3078,
            PARAMETER_MB_ADDR_RESERVE4_79 = 3079,
            PARAMETER_MB_ADDR_RESERVE4_80 = 3080,
            PARAMETER_MB_ADDR_RESERVE4_81 = 3081,
            PARAMETER_MB_ADDR_RESERVE4_82 = 3082,
            PARAMETER_MB_ADDR_RESERVE4_83 = 3083,
            PARAMETER_MB_ADDR_RESERVE4_84 = 3084,
            PARAMETER_MB_ADDR_RESERVE4_85 = 3085,
            PARAMETER_MB_ADDR_RESERVE4_86 = 3086,
            PARAMETER_MB_ADDR_RESERVE4_87 = 3087,
            PARAMETER_MB_ADDR_RESERVE4_88 = 3088,
            PARAMETER_MB_ADDR_RESERVE4_89 = 3089,
            PARAMETER_MB_ADDR_RESERVE4_90 = 3090,
            PARAMETER_MB_ADDR_RESERVE4_91 = 3091,
            PARAMETER_MB_ADDR_RESERVE4_92 = 3092,
            PARAMETER_MB_ADDR_RESERVE4_93 = 3093,
            PARAMETER_MB_ADDR_RESERVE4_94 = 3094,
            PARAMETER_MB_ADDR_RESERVE4_95 = 3095,
            PARAMETER_MB_ADDR_RESERVE4_96 = 3096,
            PARAMETER_MB_ADDR_RESERVE4_97 = 3097,
            PARAMETER_MB_ADDR_RESERVE4_98 = 3098,
            PARAMETER_MB_ADDR_RESERVE4_99 = 3099,
            PARAMETER_MB_ADDR_RESERVE4_100 = 3100,
            PARAMETER_MB_ADDR_RESERVE4_101 = 3101,
            PARAMETER_MB_ADDR_RESERVE4_102 = 3102,
            PARAMETER_MB_ADDR_RESERVE4_103 = 3103,
            PARAMETER_MB_ADDR_RESERVE4_104 = 3104,
            PARAMETER_MB_ADDR_RESERVE4_105 = 3105,
            PARAMETER_MB_ADDR_RESERVE4_106 = 3106,
            PARAMETER_MB_ADDR_RESERVE4_107 = 3107,
            PARAMETER_MB_ADDR_RESERVE4_108 = 3108,
            PARAMETER_MB_ADDR_RESERVE4_109 = 3109,
            PARAMETER_MB_ADDR_RESERVE4_110 = 3110,
            PARAMETER_MB_ADDR_RESERVE4_111 = 3111,
            PARAMETER_MB_ADDR_RESERVE4_112 = 3112,
            PARAMETER_MB_ADDR_RESERVE4_113 = 3113,
            PARAMETER_MB_ADDR_RESERVE4_114 = 3114,
            PARAMETER_MB_ADDR_RESERVE4_115 = 3115,
            PARAMETER_MB_ADDR_RESERVE4_116 = 3116,
            PARAMETER_MB_ADDR_RESERVE4_117 = 3117,
            PARAMETER_MB_ADDR_RESERVE4_118 = 3118,
            PARAMETER_MB_ADDR_RESERVE4_119 = 3119,
            PARAMETER_MB_ADDR_RESERVE4_120 = 3120,
            PARAMETER_MB_ADDR_RESERVE4_121 = 3121,
            PARAMETER_MB_ADDR_RESERVE4_122 = 3122,
            PARAMETER_MB_ADDR_RESERVE4_123 = 3123,
            PARAMETER_MB_ADDR_RESERVE4_124 = 3124,
            PARAMETER_MB_ADDR_RESERVE4_125 = 3125,
            PARAMETER_MB_ADDR_RESERVE4_126 = 3126,
            PARAMETER_MB_ADDR_RESERVE4_127 = 3127,
            PARAMETER_MB_ADDR_RESERVE4_128 = 3128,
            PARAMETER_MB_ADDR_RESERVE4_129 = 3129,
            PARAMETER_MB_ADDR_RESERVE4_130 = 3130,
            PARAMETER_MB_ADDR_RESERVE4_131 = 3131,
            PARAMETER_MB_ADDR_RESERVE4_132 = 3132,
            PARAMETER_MB_ADDR_RESERVE4_133 = 3133,
            PARAMETER_MB_ADDR_RESERVE4_134 = 3134,
            PARAMETER_MB_ADDR_RESERVE4_135 = 3135,
            PARAMETER_MB_ADDR_RESERVE4_136 = 3136,
            PARAMETER_MB_ADDR_RESERVE4_137 = 3137,
            PARAMETER_MB_ADDR_RESERVE4_138 = 3138,
            PARAMETER_MB_ADDR_RESERVE4_139 = 3139,
            PARAMETER_MB_ADDR_RESERVE4_140 = 3140,
            PARAMETER_MB_ADDR_RESERVE4_141 = 3141,
            PARAMETER_MB_ADDR_RESERVE4_142 = 3142,
            PARAMETER_MB_ADDR_RESERVE4_143 = 3143,
            PARAMETER_MB_ADDR_RESERVE4_144 = 3144,
            PARAMETER_MB_ADDR_RESERVE4_145 = 3145,
            PARAMETER_MB_ADDR_RESERVE4_146 = 3146,
            PARAMETER_MB_ADDR_RESERVE4_147 = 3147,
            PARAMETER_MB_ADDR_RESERVE4_148 = 3148,
            PARAMETER_MB_ADDR_RESERVE4_149 = 3149,
            PARAMETER_MB_ADDR_RESERVE4_150 = 3150,
            PARAMETER_MB_ADDR_RESERVE4_151 = 3151,
            PARAMETER_MB_ADDR_RESERVE4_152 = 3152,
            PARAMETER_MB_ADDR_RESERVE4_153 = 3153,
            PARAMETER_MB_ADDR_RESERVE4_154 = 3154,
            PARAMETER_MB_ADDR_RESERVE4_155 = 3155,
            PARAMETER_MB_ADDR_RESERVE4_156 = 3156,
            PARAMETER_MB_ADDR_RESERVE4_157 = 3157,
            PARAMETER_MB_ADDR_RESERVE4_158 = 3158,
            PARAMETER_MB_ADDR_RESERVE4_159 = 3159,
            PARAMETER_MB_ADDR_RESERVE4_160 = 3160,
            PARAMETER_MB_ADDR_RESERVE4_161 = 3161,
            PARAMETER_MB_ADDR_RESERVE4_162 = 3162,
            PARAMETER_MB_ADDR_RESERVE4_163 = 3163,
            PARAMETER_MB_ADDR_RESERVE4_164 = 3164,
            PARAMETER_MB_ADDR_RESERVE4_165 = 3165,
            PARAMETER_MB_ADDR_RESERVE4_166 = 3166,
            PARAMETER_MB_ADDR_RESERVE4_167 = 3167,
            PARAMETER_MB_ADDR_RESERVE4_168 = 3168,
            PARAMETER_MB_ADDR_RESERVE4_169 = 3169,
            PARAMETER_MB_ADDR_RESERVE4_170 = 3170,
            PARAMETER_MB_ADDR_RESERVE4_171 = 3171,
            PARAMETER_MB_ADDR_RESERVE4_172 = 3172,
            PARAMETER_MB_ADDR_RESERVE4_173 = 3173,
            PARAMETER_MB_ADDR_RESERVE4_174 = 3174,
            PARAMETER_MB_ADDR_RESERVE4_175 = 3175,
            PARAMETER_MB_ADDR_RESERVE4_176 = 3176,
            PARAMETER_MB_ADDR_RESERVE4_177 = 3177,
            PARAMETER_MB_ADDR_RESERVE4_178 = 3178,
            PARAMETER_MB_ADDR_RESERVE4_179 = 3179,
            PARAMETER_MB_ADDR_RESERVE4_180 = 3180,
            PARAMETER_MB_ADDR_RESERVE4_181 = 3181,
            PARAMETER_MB_ADDR_RESERVE4_182 = 3182,
            PARAMETER_MB_ADDR_RESERVE4_183 = 3183,
            PARAMETER_MB_ADDR_RESERVE4_184 = 3184,
            PARAMETER_MB_ADDR_RESERVE4_185 = 3185,
            PARAMETER_MB_ADDR_RESERVE4_186 = 3186,
            PARAMETER_MB_ADDR_RESERVE4_187 = 3187,
            PARAMETER_MB_ADDR_RESERVE4_188 = 3188,
            PARAMETER_MB_ADDR_RESERVE4_189 = 3189,
            PARAMETER_MB_ADDR_RESERVE4_190 = 3190,
            PARAMETER_MB_ADDR_RESERVE4_191 = 3191,
            PARAMETER_MB_ADDR_RESERVE4_192 = 3192,
            PARAMETER_MB_ADDR_RESERVE4_193 = 3193,
            PARAMETER_MB_ADDR_RESERVE4_194 = 3194,
            PARAMETER_MB_ADDR_RESERVE4_195 = 3195,
            PARAMETER_MB_ADDR_RESERVE4_196 = 3196,
            PARAMETER_MB_ADDR_RESERVE4_197 = 3197,
            PARAMETER_MB_ADDR_RESERVE4_198 = 3198,
            PARAMETER_MB_ADDR_RESERVE4_199 = 3199,
            PARAMETER_MB_ADDR_RESERVE4_200 = 3200,
            PARAMETER_MB_ADDR_RESERVE4_201 = 3201,
            PARAMETER_MB_ADDR_RESERVE4_202 = 3202,
            PARAMETER_MB_ADDR_RESERVE4_203 = 3203,
            PARAMETER_MB_ADDR_RESERVE4_204 = 3204,
            PARAMETER_MB_ADDR_RESERVE4_205 = 3205,
            PARAMETER_MB_ADDR_RESERVE4_206 = 3206,
            PARAMETER_MB_ADDR_RESERVE4_207 = 3207,
            PARAMETER_MB_ADDR_RESERVE4_208 = 3208,
            PARAMETER_MB_ADDR_RESERVE4_209 = 3209,
            PARAMETER_MB_ADDR_RESERVE4_210 = 3210,
            PARAMETER_MB_ADDR_RESERVE4_211 = 3211,
            PARAMETER_MB_ADDR_RESERVE4_212 = 3212,
            PARAMETER_MB_ADDR_RESERVE4_213 = 3213,
            PARAMETER_MB_ADDR_RESERVE4_214 = 3214,
            PARAMETER_MB_ADDR_RESERVE4_215 = 3215,
            PARAMETER_MB_ADDR_RESERVE4_216 = 3216,
            PARAMETER_MB_ADDR_RESERVE4_217 = 3217,
            PARAMETER_MB_ADDR_RESERVE4_218 = 3218,
            PARAMETER_MB_ADDR_RESERVE4_219 = 3219,
            PARAMETER_MB_ADDR_RESERVE4_220 = 3220,
            PARAMETER_MB_ADDR_RESERVE4_221 = 3221,
            PARAMETER_MB_ADDR_RESERVE4_222 = 3222,
            PARAMETER_MB_ADDR_RESERVE4_223 = 3223,
            PARAMETER_MB_ADDR_RESERVE4_224 = 3224,
            PARAMETER_MB_ADDR_RESERVE4_225 = 3225,
            PARAMETER_MB_ADDR_RESERVE4_226 = 3226,
            PARAMETER_MB_ADDR_RESERVE4_227 = 3227,
            PARAMETER_MB_ADDR_RESERVE4_228 = 3228,
            PARAMETER_MB_ADDR_RESERVE4_229 = 3229,
            PARAMETER_MB_ADDR_RESERVE4_230 = 3230,
            PARAMETER_MB_ADDR_RESERVE4_231 = 3231,
            PARAMETER_MB_ADDR_RESERVE4_232 = 3232,
            PARAMETER_MB_ADDR_RESERVE4_233 = 3233,
            PARAMETER_MB_ADDR_RESERVE4_234 = 3234,
            PARAMETER_MB_ADDR_RESERVE4_235 = 3235,
            PARAMETER_MB_ADDR_RESERVE4_236 = 3236,
            PARAMETER_MB_ADDR_RESERVE4_237 = 3237,
            PARAMETER_MB_ADDR_RESERVE4_238 = 3238,
            PARAMETER_MB_ADDR_RESERVE4_239 = 3239,
            PARAMETER_MB_ADDR_RESERVE4_240 = 3240,
            PARAMETER_MB_ADDR_RESERVE4_241 = 3241,
            PARAMETER_MB_ADDR_RESERVE4_242 = 3242,
            PARAMETER_MB_ADDR_RESERVE4_243 = 3243,
            PARAMETER_MB_ADDR_RESERVE4_244 = 3244,
            PARAMETER_MB_ADDR_RESERVE4_245 = 3245,
            PARAMETER_MB_ADDR_RESERVE4_246 = 3246,
            PARAMETER_MB_ADDR_RESERVE4_247 = 3247,
            PARAMETER_MB_ADDR_RESERVE4_248 = 3248,
            PARAMETER_MB_ADDR_RESERVE4_249 = 3249,
            PARAMETER_MB_ADDR_RESERVE4_250 = 3250,
            PARAMETER_MB_ADDR_RESERVE4_251 = 3251,
            PARAMETER_MB_ADDR_RESERVE4_252 = 3252,
            PARAMETER_MB_ADDR_RESERVE4_253 = 3253,
            PARAMETER_MB_ADDR_RESERVE4_254 = 3254,
            PARAMETER_MB_ADDR_RESERVE4_255 = 3255,
            PARAMETER_MB_ADDR_RESERVE4_256 = 3256,
            PARAMETER_MB_ADDR_RESERVE4_257 = 3257,
            PARAMETER_MB_ADDR_RESERVE4_258 = 3258,
            PARAMETER_MB_ADDR_RESERVE4_259 = 3259,
            PARAMETER_MB_ADDR_RESERVE4_260 = 3260,
            PARAMETER_MB_ADDR_RESERVE4_261 = 3261,
            PARAMETER_MB_ADDR_RESERVE4_262 = 3262,
            PARAMETER_MB_ADDR_RESERVE4_263 = 3263,
            PARAMETER_MB_ADDR_RESERVE4_264 = 3264,
            PARAMETER_MB_ADDR_RESERVE4_265 = 3265,
            PARAMETER_MB_ADDR_RESERVE4_266 = 3266,
            PARAMETER_MB_ADDR_RESERVE4_267 = 3267,
            PARAMETER_MB_ADDR_RESERVE4_268 = 3268,
            PARAMETER_MB_ADDR_RESERVE4_269 = 3269,
            PARAMETER_MB_ADDR_RESERVE4_270 = 3270,
            PARAMETER_MB_ADDR_RESERVE4_271 = 3271,
            PARAMETER_MB_ADDR_RESERVE4_272 = 3272,
            PARAMETER_MB_ADDR_RESERVE4_273 = 3273,
            PARAMETER_MB_ADDR_RESERVE4_274 = 3274,
            PARAMETER_MB_ADDR_RESERVE4_275 = 3275,
            PARAMETER_MB_ADDR_RESERVE4_276 = 3276,
            PARAMETER_MB_ADDR_RESERVE4_277 = 3277,
            PARAMETER_MB_ADDR_RESERVE4_278 = 3278,
            PARAMETER_MB_ADDR_RESERVE4_279 = 3279,
            PARAMETER_MB_ADDR_RESERVE4_280 = 3280,
            PARAMETER_MB_ADDR_RESERVE4_281 = 3281,
            PARAMETER_MB_ADDR_RESERVE4_282 = 3282,
            PARAMETER_MB_ADDR_RESERVE4_283 = 3283,
            PARAMETER_MB_ADDR_RESERVE4_284 = 3284,
            PARAMETER_MB_ADDR_RESERVE4_285 = 3285,
            PARAMETER_MB_ADDR_RESERVE4_286 = 3286,
            PARAMETER_MB_ADDR_RESERVE4_287 = 3287,
            PARAMETER_MB_ADDR_RESERVE4_288 = 3288,
            PARAMETER_MB_ADDR_RESERVE4_289 = 3289,
            PARAMETER_MB_ADDR_RESERVE4_290 = 3290,
            PARAMETER_MB_ADDR_RESERVE4_291 = 3291,
            PARAMETER_MB_ADDR_RESERVE4_292 = 3292,
            PARAMETER_MB_ADDR_RESERVE4_293 = 3293,
            PARAMETER_MB_ADDR_RESERVE4_294 = 3294,
            PARAMETER_MB_ADDR_RESERVE4_295 = 3295,
            PARAMETER_MB_ADDR_RESERVE4_296 = 3296,
            PARAMETER_MB_ADDR_RESERVE4_297 = 3297,
            PARAMETER_MB_ADDR_RESERVE4_298 = 3298,
            PARAMETER_MB_ADDR_RESERVE4_299 = 3299,
            PARAMETER_MB_ADDR_RESERVE4_300 = 3300,
            PARAMETER_MB_ADDR_RESERVE4_301 = 3301,
            PARAMETER_MB_ADDR_RESERVE4_302 = 3302,
            PARAMETER_MB_ADDR_RESERVE4_303 = 3303,
            PARAMETER_MB_ADDR_RESERVE4_304 = 3304,
            PARAMETER_MB_ADDR_RESERVE4_305 = 3305,
            PARAMETER_MB_ADDR_RESERVE4_306 = 3306,
            PARAMETER_MB_ADDR_RESERVE4_307 = 3307,
            PARAMETER_MB_ADDR_RESERVE4_308 = 3308,
            PARAMETER_MB_ADDR_RESERVE4_309 = 3309,
            PARAMETER_MB_ADDR_RESERVE4_310 = 3310,
            PARAMETER_MB_ADDR_RESERVE4_311 = 3311,
            PARAMETER_MB_ADDR_RESERVE4_312 = 3312,
            PARAMETER_MB_ADDR_RESERVE4_313 = 3313,
            PARAMETER_MB_ADDR_RESERVE4_314 = 3314,
            PARAMETER_MB_ADDR_RESERVE4_315 = 3315,
            PARAMETER_MB_ADDR_RESERVE4_316 = 3316,
            PARAMETER_MB_ADDR_RESERVE4_317 = 3317,
            PARAMETER_MB_ADDR_RESERVE4_318 = 3318,
            PARAMETER_MB_ADDR_RESERVE4_319 = 3319,
            PARAMETER_MB_ADDR_RESERVE4_320 = 3320,
            PARAMETER_MB_ADDR_RESERVE4_321 = 3321,
            PARAMETER_MB_ADDR_RESERVE4_322 = 3322,
            PARAMETER_MB_ADDR_RESERVE4_323 = 3323,
            PARAMETER_MB_ADDR_RESERVE4_324 = 3324,
            PARAMETER_MB_ADDR_RESERVE4_325 = 3325,
            PARAMETER_MB_ADDR_RESERVE4_326 = 3326,
            PARAMETER_MB_ADDR_RESERVE4_327 = 3327,
            PARAMETER_MB_ADDR_RESERVE4_328 = 3328,
            PARAMETER_MB_ADDR_RESERVE4_329 = 3329,
            PARAMETER_MB_ADDR_RESERVE4_330 = 3330,
            PARAMETER_MB_ADDR_RESERVE4_331 = 3331,
            PARAMETER_MB_ADDR_RESERVE4_332 = 3332,
            PARAMETER_MB_ADDR_RESERVE4_333 = 3333,
            PARAMETER_MB_ADDR_RESERVE4_334 = 3334,
            PARAMETER_MB_ADDR_RESERVE4_335 = 3335,
            PARAMETER_MB_ADDR_RESERVE4_336 = 3336,
            PARAMETER_MB_ADDR_RESERVE4_337 = 3337,
            PARAMETER_MB_ADDR_RESERVE4_338 = 3338,
            PARAMETER_MB_ADDR_RESERVE4_339 = 3339,
            PARAMETER_MB_ADDR_RESERVE4_340 = 3340,
            PARAMETER_MB_ADDR_RESERVE4_341 = 3341,
            PARAMETER_MB_ADDR_RESERVE4_342 = 3342,
            PARAMETER_MB_ADDR_RESERVE4_343 = 3343,
            PARAMETER_MB_ADDR_RESERVE4_344 = 3344,
            PARAMETER_MB_ADDR_RESERVE4_345 = 3345,
            PARAMETER_MB_ADDR_RESERVE4_346 = 3346,
            PARAMETER_MB_ADDR_RESERVE4_347 = 3347,
            PARAMETER_MB_ADDR_RESERVE4_348 = 3348,
            PARAMETER_MB_ADDR_RESERVE4_349 = 3349,
            PARAMETER_MB_ADDR_RESERVE4_350 = 3350,
            PARAMETER_MB_ADDR_RESERVE4_351 = 3351,
            PARAMETER_MB_ADDR_RESERVE4_352 = 3352,
            PARAMETER_MB_ADDR_RESERVE4_353 = 3353,
            PARAMETER_MB_ADDR_RESERVE4_354 = 3354,
            PARAMETER_MB_ADDR_RESERVE4_355 = 3355,
            PARAMETER_MB_ADDR_RESERVE4_356 = 3356,
            PARAMETER_MB_ADDR_RESERVE4_357 = 3357,
            PARAMETER_MB_ADDR_RESERVE4_358 = 3358,
            PARAMETER_MB_ADDR_RESERVE4_359 = 3359,
            PARAMETER_MB_ADDR_RESERVE4_360 = 3360,
            PARAMETER_MB_ADDR_RESERVE4_361 = 3361,
            PARAMETER_MB_ADDR_RESERVE4_362 = 3362,
            PARAMETER_MB_ADDR_RESERVE4_363 = 3363,
            PARAMETER_MB_ADDR_RESERVE4_364 = 3364,
            PARAMETER_MB_ADDR_RESERVE4_365 = 3365,
            PARAMETER_MB_ADDR_RESERVE4_366 = 3366,
            PARAMETER_MB_ADDR_RESERVE4_367 = 3367,
            PARAMETER_MB_ADDR_RESERVE4_368 = 3368,
            PARAMETER_MB_ADDR_RESERVE4_369 = 3369,
            PARAMETER_MB_ADDR_RESERVE4_370 = 3370,
            PARAMETER_MB_ADDR_RESERVE4_371 = 3371,
            PARAMETER_MB_ADDR_RESERVE4_372 = 3372,
            PARAMETER_MB_ADDR_RESERVE4_373 = 3373,
            PARAMETER_MB_ADDR_RESERVE4_374 = 3374,
            PARAMETER_MB_ADDR_RESERVE4_375 = 3375,
            PARAMETER_MB_ADDR_RESERVE4_376 = 3376,
            PARAMETER_MB_ADDR_RESERVE4_377 = 3377,
            PARAMETER_MB_ADDR_RESERVE4_378 = 3378,
            PARAMETER_MB_ADDR_RESERVE4_379 = 3379,
            PARAMETER_MB_ADDR_RESERVE4_380 = 3380,
            PARAMETER_MB_ADDR_RESERVE4_381 = 3381,
            PARAMETER_MB_ADDR_RESERVE4_382 = 3382,
            PARAMETER_MB_ADDR_RESERVE4_383 = 3383,
            PARAMETER_MB_ADDR_RESERVE4_384 = 3384,
            PARAMETER_MB_ADDR_RESERVE4_385 = 3385,
            PARAMETER_MB_ADDR_RESERVE4_386 = 3386,
            PARAMETER_MB_ADDR_RESERVE4_387 = 3387,
            PARAMETER_MB_ADDR_RESERVE4_388 = 3388,
            PARAMETER_MB_ADDR_RESERVE4_389 = 3389,
            PARAMETER_MB_ADDR_RESERVE4_390 = 3390,
            PARAMETER_MB_ADDR_RESERVE4_391 = 3391,
            PARAMETER_MB_ADDR_RESERVE4_392 = 3392,
            PARAMETER_MB_ADDR_RESERVE4_393 = 3393,
            PARAMETER_MB_ADDR_RESERVE4_394 = 3394,
            PARAMETER_MB_ADDR_RESERVE4_395 = 3395,
            PARAMETER_MB_ADDR_RESERVE4_396 = 3396,
            PARAMETER_MB_ADDR_RESERVE4_397 = 3397,
            PARAMETER_MB_ADDR_RESERVE4_398 = 3398,
            PARAMETER_MB_ADDR_RESERVE4_399 = 3399,
            PARAMETER_MB_ADDR_RESERVE4_400 = 3400,
            PARAMETER_MB_ADDR_RESERVE4_401 = 3401,
            PARAMETER_MB_ADDR_RESERVE4_402 = 3402,
            PARAMETER_MB_ADDR_RESERVE4_403 = 3403,
            PARAMETER_MB_ADDR_RESERVE4_404 = 3404,
            PARAMETER_MB_ADDR_RESERVE4_405 = 3405,
            PARAMETER_MB_ADDR_RESERVE4_406 = 3406,
            PARAMETER_MB_ADDR_RESERVE4_407 = 3407,
            PARAMETER_MB_ADDR_RESERVE4_408 = 3408,
            PARAMETER_MB_ADDR_RESERVE4_409 = 3409,
            PARAMETER_MB_ADDR_RESERVE4_410 = 3410,
            PARAMETER_MB_ADDR_RESERVE4_411 = 3411,
            PARAMETER_MB_ADDR_RESERVE4_412 = 3412,
            PARAMETER_MB_ADDR_RESERVE4_413 = 3413,
            PARAMETER_MB_ADDR_RESERVE4_414 = 3414,
            PARAMETER_MB_ADDR_RESERVE4_415 = 3415,
            PARAMETER_MB_ADDR_RESERVE4_416 = 3416,
            PARAMETER_MB_ADDR_RESERVE4_417 = 3417,
            PARAMETER_MB_ADDR_RESERVE4_418 = 3418,
            PARAMETER_MB_ADDR_RESERVE4_419 = 3419,
            PARAMETER_MB_ADDR_RESERVE4_420 = 3420,
            PARAMETER_MB_ADDR_RESERVE4_421 = 3421,
            PARAMETER_MB_ADDR_RESERVE4_422 = 3422,
            PARAMETER_MB_ADDR_RESERVE4_423 = 3423,
            PARAMETER_MB_ADDR_RESERVE4_424 = 3424,
            PARAMETER_MB_ADDR_RESERVE4_425 = 3425,
            PARAMETER_MB_ADDR_RESERVE4_426 = 3426,
            PARAMETER_MB_ADDR_RESERVE4_427 = 3427,
            PARAMETER_MB_ADDR_RESERVE4_428 = 3428,
            PARAMETER_MB_ADDR_RESERVE4_429 = 3429,
            PARAMETER_MB_ADDR_RESERVE4_430 = 3430,
            PARAMETER_MB_ADDR_RESERVE4_431 = 3431,
            PARAMETER_MB_ADDR_RESERVE4_432 = 3432,
            PARAMETER_MB_ADDR_RESERVE4_433 = 3433,
            PARAMETER_MB_ADDR_RESERVE4_434 = 3434,
            PARAMETER_MB_ADDR_RESERVE4_435 = 3435,
            PARAMETER_MB_ADDR_RESERVE4_436 = 3436,
            PARAMETER_MB_ADDR_RESERVE4_437 = 3437,
            PARAMETER_MB_ADDR_RESERVE4_438 = 3438,
            PARAMETER_MB_ADDR_RESERVE4_439 = 3439,
            PARAMETER_MB_ADDR_RESERVE4_440 = 3440,
            PARAMETER_MB_ADDR_RESERVE4_441 = 3441,
            PARAMETER_MB_ADDR_RESERVE4_442 = 3442,
            PARAMETER_MB_ADDR_RESERVE4_443 = 3443,
            PARAMETER_MB_ADDR_RESERVE4_444 = 3444,
            PARAMETER_MB_ADDR_RESERVE4_445 = 3445,
            PARAMETER_MB_ADDR_RESERVE4_446 = 3446,
            PARAMETER_MB_ADDR_RESERVE4_447 = 3447,
            PARAMETER_MB_ADDR_RESERVE4_448 = 3448,
            PARAMETER_MB_ADDR_RESERVE4_449 = 3449,
            PARAMETER_MB_ADDR_RESERVE4_450 = 3450,
            PARAMETER_MB_ADDR_RESERVE4_451 = 3451,
            PARAMETER_MB_ADDR_RESERVE4_452 = 3452,
            PARAMETER_MB_ADDR_RESERVE4_453 = 3453,
            PARAMETER_MB_ADDR_RESERVE4_454 = 3454,
            PARAMETER_MB_ADDR_RESERVE4_455 = 3455,
            PARAMETER_MB_ADDR_RESERVE4_456 = 3456,
            PARAMETER_MB_ADDR_RESERVE4_457 = 3457,
            PARAMETER_MB_ADDR_RESERVE4_458 = 3458,
            PARAMETER_MB_ADDR_RESERVE4_459 = 3459,
            PARAMETER_MB_ADDR_RESERVE4_460 = 3460,
            PARAMETER_MB_ADDR_RESERVE4_461 = 3461,
            PARAMETER_MB_ADDR_RESERVE4_462 = 3462,
            PARAMETER_MB_ADDR_RESERVE4_463 = 3463,
            PARAMETER_MB_ADDR_RESERVE4_464 = 3464,
            PARAMETER_MB_ADDR_RESERVE4_465 = 3465,
            PARAMETER_MB_ADDR_RESERVE4_466 = 3466,
            PARAMETER_MB_ADDR_RESERVE4_467 = 3467,
            PARAMETER_MB_ADDR_RESERVE4_468 = 3468,
            PARAMETER_MB_ADDR_RESERVE4_469 = 3469,
            PARAMETER_MB_ADDR_RESERVE4_470 = 3470,
            PARAMETER_MB_ADDR_RESERVE4_471 = 3471,
            PARAMETER_MB_ADDR_RESERVE4_472 = 3472,
            PARAMETER_MB_ADDR_RESERVE4_473 = 3473,
            PARAMETER_MB_ADDR_RESERVE4_474 = 3474,
            PARAMETER_MB_ADDR_RESERVE4_475 = 3475,
            PARAMETER_MB_ADDR_RESERVE4_476 = 3476,
            PARAMETER_MB_ADDR_RESERVE4_477 = 3477,
            PARAMETER_MB_ADDR_RESERVE4_478 = 3478,
            PARAMETER_MB_ADDR_RESERVE4_479 = 3479,
            PARAMETER_MB_ADDR_RESERVE4_480 = 3480,
            PARAMETER_MB_ADDR_RESERVE4_481 = 3481,
            PARAMETER_MB_ADDR_RESERVE4_482 = 3482,
            PARAMETER_MB_ADDR_RESERVE4_483 = 3483,
            PARAMETER_MB_ADDR_RESERVE4_484 = 3484,
            PARAMETER_MB_ADDR_RESERVE4_485 = 3485,
            PARAMETER_MB_ADDR_RESERVE4_486 = 3486,
            PARAMETER_MB_ADDR_RESERVE4_487 = 3487,
            PARAMETER_MB_ADDR_RESERVE4_488 = 3488,
            PARAMETER_MB_ADDR_RESERVE4_489 = 3489,
            PARAMETER_MB_ADDR_RESERVE4_490 = 3490,
            PARAMETER_MB_ADDR_RESERVE4_491 = 3491,
            PARAMETER_MB_ADDR_RESERVE4_492 = 3492,
            PARAMETER_MB_ADDR_RESERVE4_493 = 3493,
            PARAMETER_MB_ADDR_RESERVE4_494 = 3494,
            PARAMETER_MB_ADDR_RESERVE4_495 = 3495,
            PARAMETER_MB_ADDR_RESERVE4_496 = 3496,
            PARAMETER_MB_ADDR_RESERVE4_497 = 3497,
            PARAMETER_MB_ADDR_RESERVE4_498 = 3498,
            PARAMETER_MB_ADDR_RESERVE4_499 = 3499,
            PARAMETER_MB_ADDR_RESERVE4_500 = 3500,
            PARAMETER_MB_ADDR_RESERVE4_501 = 3501,
            PARAMETER_MB_ADDR_RESERVE4_502 = 3502,
            PARAMETER_MB_ADDR_RESERVE4_503 = 3503,
            PARAMETER_MB_ADDR_RESERVE4_504 = 3504,
            PARAMETER_MB_ADDR_RESERVE4_505 = 3505,
            PARAMETER_MB_ADDR_RESERVE4_506 = 3506,
            PARAMETER_MB_ADDR_RESERVE4_507 = 3507,
            PARAMETER_MB_ADDR_RESERVE4_508 = 3508,
            PARAMETER_MB_ADDR_RESERVE4_509 = 3509,
            PARAMETER_MB_ADDR_RESERVE4_510 = 3510,
            PARAMETER_MB_ADDR_RESERVE4_511 = 3511,
            PARAMETER_MB_ADDR_RESERVE4_512 = 3512,
            PARAMETER_MB_ADDR_RESERVE4_513 = 3513,
            PARAMETER_MB_ADDR_RESERVE4_514 = 3514,
            PARAMETER_MB_ADDR_RESERVE4_515 = 3515,
            PARAMETER_MB_ADDR_RESERVE4_516 = 3516,
            PARAMETER_MB_ADDR_RESERVE4_517 = 3517,
            PARAMETER_MB_ADDR_RESERVE4_518 = 3518,
            PARAMETER_MB_ADDR_RESERVE4_519 = 3519,
            PARAMETER_MB_ADDR_RESERVE4_520 = 3520,
            PARAMETER_MB_ADDR_RESERVE4_521 = 3521,
            PARAMETER_MB_ADDR_RESERVE4_522 = 3522,
            PARAMETER_MB_ADDR_RESERVE4_523 = 3523,
            PARAMETER_MB_ADDR_RESERVE4_524 = 3524,
            PARAMETER_MB_ADDR_RESERVE4_525 = 3525,
            PARAMETER_MB_ADDR_RESERVE4_526 = 3526,
            PARAMETER_MB_ADDR_RESERVE4_527 = 3527,
            PARAMETER_MB_ADDR_RESERVE4_528 = 3528,
            PARAMETER_MB_ADDR_RESERVE4_529 = 3529,
            PARAMETER_MB_ADDR_RESERVE4_530 = 3530,
            PARAMETER_MB_ADDR_RESERVE4_531 = 3531,
            PARAMETER_MB_ADDR_RESERVE4_532 = 3532,
            PARAMETER_MB_ADDR_RESERVE4_533 = 3533,
            PARAMETER_MB_ADDR_RESERVE4_534 = 3534,
            PARAMETER_MB_ADDR_RESERVE4_535 = 3535,
            PARAMETER_MB_ADDR_RESERVE4_536 = 3536,
            PARAMETER_MB_ADDR_RESERVE4_537 = 3537,
            PARAMETER_MB_ADDR_RESERVE4_538 = 3538,
            PARAMETER_MB_ADDR_RESERVE4_539 = 3539,
            PARAMETER_MB_ADDR_RESERVE4_540 = 3540,
            PARAMETER_MB_ADDR_RESERVE4_541 = 3541,
            PARAMETER_MB_ADDR_RESERVE4_542 = 3542,
            PARAMETER_MB_ADDR_RESERVE4_543 = 3543,
            PARAMETER_MB_ADDR_RESERVE4_544 = 3544,
            PARAMETER_MB_ADDR_RESERVE4_545 = 3545,
            PARAMETER_MB_ADDR_RESERVE4_546 = 3546,
            PARAMETER_MB_ADDR_RESERVE4_547 = 3547,
            PARAMETER_MB_ADDR_RESERVE4_548 = 3548,
            PARAMETER_MB_ADDR_RESERVE4_549 = 3549,
            PARAMETER_MB_ADDR_RESERVE4_550 = 3550,
            PARAMETER_MB_ADDR_RESERVE4_551 = 3551,
            PARAMETER_MB_ADDR_RESERVE4_552 = 3552,
            PARAMETER_MB_ADDR_RESERVE4_553 = 3553,
            PARAMETER_MB_ADDR_RESERVE4_554 = 3554,
            PARAMETER_MB_ADDR_RESERVE4_555 = 3555,
            PARAMETER_MB_ADDR_RESERVE4_556 = 3556,
            PARAMETER_MB_ADDR_RESERVE4_557 = 3557,
            PARAMETER_MB_ADDR_RESERVE4_558 = 3558,
            PARAMETER_MB_ADDR_RESERVE4_559 = 3559,
            PARAMETER_MB_ADDR_RESERVE4_560 = 3560,
            PARAMETER_MB_ADDR_RESERVE4_561 = 3561,
            PARAMETER_MB_ADDR_RESERVE4_562 = 3562,
            PARAMETER_MB_ADDR_RESERVE4_563 = 3563,
            PARAMETER_MB_ADDR_RESERVE4_564 = 3564,
            PARAMETER_MB_ADDR_RESERVE4_565 = 3565,
            PARAMETER_MB_ADDR_RESERVE4_566 = 3566,
            PARAMETER_MB_ADDR_RESERVE4_567 = 3567,
            PARAMETER_MB_ADDR_RESERVE4_568 = 3568,
            PARAMETER_MB_ADDR_RESERVE4_569 = 3569,
            PARAMETER_MB_ADDR_RESERVE4_570 = 3570,
            PARAMETER_MB_ADDR_RESERVE4_571 = 3571,
            PARAMETER_MB_ADDR_RESERVE4_572 = 3572,
            PARAMETER_MB_ADDR_RESERVE4_573 = 3573,
            PARAMETER_MB_ADDR_RESERVE4_574 = 3574,
            PARAMETER_MB_ADDR_RESERVE4_575 = 3575,
            PARAMETER_MB_ADDR_RESERVE4_576 = 3576,
            PARAMETER_MB_ADDR_RESERVE4_577 = 3577,
            PARAMETER_MB_ADDR_RESERVE4_578 = 3578,
            PARAMETER_MB_ADDR_RESERVE4_579 = 3579,
            PARAMETER_MB_ADDR_RESERVE4_580 = 3580,
            PARAMETER_MB_ADDR_RESERVE4_581 = 3581,
            PARAMETER_MB_ADDR_RESERVE4_582 = 3582,
            PARAMETER_MB_ADDR_RESERVE4_583 = 3583,
            PARAMETER_MB_ADDR_RESERVE4_584 = 3584,
            PARAMETER_MB_ADDR_RESERVE4_585 = 3585,
            PARAMETER_MB_ADDR_RESERVE4_586 = 3586,
            PARAMETER_MB_ADDR_RESERVE4_587 = 3587,
            PARAMETER_MB_ADDR_RESERVE4_588 = 3588,
            PARAMETER_MB_ADDR_RESERVE4_589 = 3589,
            PARAMETER_MB_ADDR_RESERVE4_590 = 3590,
            PARAMETER_MB_ADDR_RESERVE4_591 = 3591,
            PARAMETER_MB_ADDR_RESERVE4_592 = 3592,
            PARAMETER_MB_ADDR_RESERVE4_593 = 3593,
            PARAMETER_MB_ADDR_RESERVE4_594 = 3594,
            PARAMETER_MB_ADDR_RESERVE4_595 = 3595,
            PARAMETER_MB_ADDR_RESERVE4_596 = 3596,
            PARAMETER_MB_ADDR_RESERVE4_597 = 3597,
            PARAMETER_MB_ADDR_RESERVE4_598 = 3598,
            PARAMETER_MB_ADDR_RESERVE4_599 = 3599,
            PARAMETER_MB_ADDR_RESERVE4_600 = 3600,
            PARAMETER_MB_ADDR_RESERVE4_601 = 3601,
            PARAMETER_MB_ADDR_RESERVE4_602 = 3602,
            PARAMETER_MB_ADDR_RESERVE4_603 = 3603,
            PARAMETER_MB_ADDR_RESERVE4_604 = 3604,
            PARAMETER_MB_ADDR_RESERVE4_605 = 3605,
            PARAMETER_MB_ADDR_RESERVE4_606 = 3606,
            PARAMETER_MB_ADDR_RESERVE4_607 = 3607,
            PARAMETER_MB_ADDR_RESERVE4_608 = 3608,
            PARAMETER_MB_ADDR_RESERVE4_609 = 3609,
            PARAMETER_MB_ADDR_RESERVE4_610 = 3610,
            PARAMETER_MB_ADDR_RESERVE4_611 = 3611,
            PARAMETER_MB_ADDR_RESERVE4_612 = 3612,
            PARAMETER_MB_ADDR_RESERVE4_613 = 3613,
            PARAMETER_MB_ADDR_RESERVE4_614 = 3614,
            PARAMETER_MB_ADDR_RESERVE4_615 = 3615,
            PARAMETER_MB_ADDR_RESERVE4_616 = 3616,
            PARAMETER_MB_ADDR_RESERVE4_617 = 3617,
            PARAMETER_MB_ADDR_RESERVE4_618 = 3618,
            PARAMETER_MB_ADDR_RESERVE4_619 = 3619,
            PARAMETER_MB_ADDR_RESERVE4_620 = 3620,
            PARAMETER_MB_ADDR_RESERVE4_621 = 3621,
            PARAMETER_MB_ADDR_RESERVE4_622 = 3622,
            PARAMETER_MB_ADDR_RESERVE4_623 = 3623,
            PARAMETER_MB_ADDR_RESERVE4_624 = 3624,
            PARAMETER_MB_ADDR_RESERVE4_625 = 3625,
            PARAMETER_MB_ADDR_RESERVE4_626 = 3626,
            PARAMETER_MB_ADDR_RESERVE4_627 = 3627,
            PARAMETER_MB_ADDR_RESERVE4_628 = 3628,
            PARAMETER_MB_ADDR_RESERVE4_629 = 3629,
            PARAMETER_MB_ADDR_RESERVE4_630 = 3630,
            PARAMETER_MB_ADDR_RESERVE4_631 = 3631,
            PARAMETER_MB_ADDR_RESERVE4_632 = 3632,
            PARAMETER_MB_ADDR_RESERVE4_633 = 3633,
            PARAMETER_MB_ADDR_RESERVE4_634 = 3634,
            PARAMETER_MB_ADDR_RESERVE4_635 = 3635,
            PARAMETER_MB_ADDR_RESERVE4_636 = 3636,
            PARAMETER_MB_ADDR_RESERVE4_637 = 3637,
            PARAMETER_MB_ADDR_RESERVE4_638 = 3638,
            PARAMETER_MB_ADDR_RESERVE4_639 = 3639,
            PARAMETER_MB_ADDR_RESERVE4_640 = 3640,
            PARAMETER_MB_ADDR_RESERVE4_641 = 3641,
            PARAMETER_MB_ADDR_RESERVE4_642 = 3642,
            PARAMETER_MB_ADDR_RESERVE4_643 = 3643,
            PARAMETER_MB_ADDR_RESERVE4_644 = 3644,
            PARAMETER_MB_ADDR_RESERVE4_645 = 3645,
            PARAMETER_MB_ADDR_RESERVE4_646 = 3646,
            PARAMETER_MB_ADDR_RESERVE4_647 = 3647,
            PARAMETER_MB_ADDR_RESERVE4_648 = 3648,
            PARAMETER_MB_ADDR_RESERVE4_649 = 3649,
            PARAMETER_MB_ADDR_RESERVE4_650 = 3650,
            PARAMETER_MB_ADDR_RESERVE4_651 = 3651,
            PARAMETER_MB_ADDR_RESERVE4_652 = 3652,
            PARAMETER_MB_ADDR_RESERVE4_653 = 3653,
            PARAMETER_MB_ADDR_RESERVE4_654 = 3654,
            PARAMETER_MB_ADDR_RESERVE4_655 = 3655,
            PARAMETER_MB_ADDR_RESERVE4_656 = 3656,
            PARAMETER_MB_ADDR_RESERVE4_657 = 3657,
            PARAMETER_MB_ADDR_RESERVE4_658 = 3658,
            PARAMETER_MB_ADDR_RESERVE4_659 = 3659,
            PARAMETER_MB_ADDR_RESERVE4_660 = 3660,
            PARAMETER_MB_ADDR_RESERVE4_661 = 3661,
            PARAMETER_MB_ADDR_RESERVE4_662 = 3662,
            PARAMETER_MB_ADDR_RESERVE4_663 = 3663,
            PARAMETER_MB_ADDR_RESERVE4_664 = 3664,
            PARAMETER_MB_ADDR_RESERVE4_665 = 3665,
            PARAMETER_MB_ADDR_RESERVE4_666 = 3666,
            PARAMETER_MB_ADDR_RESERVE4_667 = 3667,
            PARAMETER_MB_ADDR_RESERVE4_668 = 3668,
            PARAMETER_MB_ADDR_RESERVE4_669 = 3669,
            PARAMETER_MB_ADDR_RESERVE4_670 = 3670,
            PARAMETER_MB_ADDR_RESERVE4_671 = 3671,
            PARAMETER_MB_ADDR_RESERVE4_672 = 3672,
            PARAMETER_MB_ADDR_RESERVE4_673 = 3673,
            PARAMETER_MB_ADDR_RESERVE4_674 = 3674,
            PARAMETER_MB_ADDR_RESERVE4_675 = 3675,
            PARAMETER_MB_ADDR_RESERVE4_676 = 3676,
            PARAMETER_MB_ADDR_RESERVE4_677 = 3677,
            PARAMETER_MB_ADDR_RESERVE4_678 = 3678,
            PARAMETER_MB_ADDR_RESERVE4_679 = 3679,
            PARAMETER_MB_ADDR_RESERVE4_680 = 3680,
            PARAMETER_MB_ADDR_RESERVE4_681 = 3681,
            PARAMETER_MB_ADDR_RESERVE4_682 = 3682,
            PARAMETER_MB_ADDR_RESERVE4_683 = 3683,
            PARAMETER_MB_ADDR_RESERVE4_684 = 3684,
            PARAMETER_MB_ADDR_RESERVE4_685 = 3685,
            PARAMETER_MB_ADDR_RESERVE4_686 = 3686,
            PARAMETER_MB_ADDR_RESERVE4_687 = 3687,
            PARAMETER_MB_ADDR_RESERVE4_688 = 3688,
            PARAMETER_MB_ADDR_RESERVE4_689 = 3689,
            PARAMETER_MB_ADDR_RESERVE4_690 = 3690,
            PARAMETER_MB_ADDR_RESERVE4_691 = 3691,
            PARAMETER_MB_ADDR_RESERVE4_692 = 3692,
            PARAMETER_MB_ADDR_RESERVE4_693 = 3693,
            PARAMETER_MB_ADDR_RESERVE4_694 = 3694,
            PARAMETER_MB_ADDR_RESERVE4_695 = 3695,
            PARAMETER_MB_ADDR_RESERVE4_696 = 3696,
            PARAMETER_MB_ADDR_RESERVE4_697 = 3697,
            PARAMETER_MB_ADDR_RESERVE4_698 = 3698,
            PARAMETER_MB_ADDR_RESERVE4_699 = 3699,
            PARAMETER_MB_ADDR_RESERVE4_700 = 3700,
            PARAMETER_MB_ADDR_RESERVE4_701 = 3701,
            PARAMETER_MB_ADDR_RESERVE4_702 = 3702,
            PARAMETER_MB_ADDR_RESERVE4_703 = 3703,
            PARAMETER_MB_ADDR_RESERVE4_704 = 3704,
            PARAMETER_MB_ADDR_RESERVE4_705 = 3705,
            PARAMETER_MB_ADDR_RESERVE4_706 = 3706,
            PARAMETER_MB_ADDR_RESERVE4_707 = 3707,
            PARAMETER_MB_ADDR_RESERVE4_708 = 3708,
            PARAMETER_MB_ADDR_RESERVE4_709 = 3709,
            PARAMETER_MB_ADDR_RESERVE4_710 = 3710,
            PARAMETER_MB_ADDR_RESERVE4_711 = 3711,
            PARAMETER_MB_ADDR_RESERVE4_712 = 3712,
            PARAMETER_MB_ADDR_RESERVE4_713 = 3713,
            PARAMETER_MB_ADDR_RESERVE4_714 = 3714,
            PARAMETER_MB_ADDR_RESERVE4_715 = 3715,
            PARAMETER_MB_ADDR_RESERVE4_716 = 3716,
            PARAMETER_MB_ADDR_RESERVE4_717 = 3717,
            PARAMETER_MB_ADDR_RESERVE4_718 = 3718,
            PARAMETER_MB_ADDR_RESERVE4_719 = 3719,
            PARAMETER_MB_ADDR_RESERVE4_720 = 3720,
            PARAMETER_MB_ADDR_RESERVE4_721 = 3721,
            PARAMETER_MB_ADDR_RESERVE4_722 = 3722,
            PARAMETER_MB_ADDR_RESERVE4_723 = 3723,
            PARAMETER_MB_ADDR_RESERVE4_724 = 3724,
            PARAMETER_MB_ADDR_RESERVE4_725 = 3725,
            PARAMETER_MB_ADDR_RESERVE4_726 = 3726,
            PARAMETER_MB_ADDR_RESERVE4_727 = 3727,
            PARAMETER_MB_ADDR_RESERVE4_728 = 3728,
            PARAMETER_MB_ADDR_RESERVE4_729 = 3729,
            PARAMETER_MB_ADDR_RESERVE4_730 = 3730,
            PARAMETER_MB_ADDR_RESERVE4_731 = 3731,
            PARAMETER_MB_ADDR_RESERVE4_732 = 3732,
            PARAMETER_MB_ADDR_RESERVE4_733 = 3733,
            PARAMETER_MB_ADDR_RESERVE4_734 = 3734,
            PARAMETER_MB_ADDR_RESERVE4_735 = 3735,
            PARAMETER_MB_ADDR_RESERVE4_736 = 3736,
            PARAMETER_MB_ADDR_RESERVE4_737 = 3737,
            PARAMETER_MB_ADDR_RESERVE4_738 = 3738,
            PARAMETER_MB_ADDR_RESERVE4_739 = 3739,
            PARAMETER_MB_ADDR_RESERVE4_740 = 3740,
            PARAMETER_MB_ADDR_RESERVE4_741 = 3741,
            PARAMETER_MB_ADDR_RESERVE4_742 = 3742,
            PARAMETER_MB_ADDR_RESERVE4_743 = 3743,
            PARAMETER_MB_ADDR_RESERVE4_744 = 3744,
            PARAMETER_MB_ADDR_RESERVE4_745 = 3745,
            PARAMETER_MB_ADDR_RESERVE4_746 = 3746,
            PARAMETER_MB_ADDR_RESERVE4_747 = 3747,
            PARAMETER_MB_ADDR_RESERVE4_748 = 3748,
            PARAMETER_MB_ADDR_RESERVE4_749 = 3749,
            PARAMETER_MB_ADDR_RESERVE4_750 = 3750,
            PARAMETER_MB_ADDR_RESERVE4_751 = 3751,
            PARAMETER_MB_ADDR_RESERVE4_752 = 3752,
            PARAMETER_MB_ADDR_RESERVE4_753 = 3753,
            PARAMETER_MB_ADDR_RESERVE4_754 = 3754,
            PARAMETER_MB_ADDR_RESERVE4_755 = 3755,
            PARAMETER_MB_ADDR_RESERVE4_756 = 3756,
            PARAMETER_MB_ADDR_RESERVE4_757 = 3757,
            PARAMETER_MB_ADDR_RESERVE4_758 = 3758,
            PARAMETER_MB_ADDR_RESERVE4_759 = 3759,
            PARAMETER_MB_ADDR_RESERVE4_760 = 3760,
            PARAMETER_MB_ADDR_RESERVE4_761 = 3761,
            PARAMETER_MB_ADDR_RESERVE4_762 = 3762,
            PARAMETER_MB_ADDR_RESERVE4_763 = 3763,
            PARAMETER_MB_ADDR_RESERVE4_764 = 3764,
            PARAMETER_MB_ADDR_RESERVE4_765 = 3765,
            PARAMETER_MB_ADDR_RESERVE4_766 = 3766,
            PARAMETER_MB_ADDR_RESERVE4_767 = 3767,
            PARAMETER_MB_ADDR_RESERVE4_768 = 3768,
            PARAMETER_MB_ADDR_RESERVE4_769 = 3769,
            PARAMETER_MB_ADDR_RESERVE4_770 = 3770,
            PARAMETER_MB_ADDR_RESERVE4_771 = 3771,
            PARAMETER_MB_ADDR_RESERVE4_772 = 3772,
            PARAMETER_MB_ADDR_RESERVE4_773 = 3773,
            PARAMETER_MB_ADDR_RESERVE4_774 = 3774,
            PARAMETER_MB_ADDR_RESERVE4_775 = 3775,
            PARAMETER_MB_ADDR_RESERVE4_776 = 3776,
            PARAMETER_MB_ADDR_RESERVE4_777 = 3777,
            PARAMETER_MB_ADDR_RESERVE4_778 = 3778,
            PARAMETER_MB_ADDR_RESERVE4_779 = 3779,
            PARAMETER_MB_ADDR_RESERVE4_780 = 3780,
            PARAMETER_MB_ADDR_RESERVE4_781 = 3781,
            PARAMETER_MB_ADDR_RESERVE4_782 = 3782,
            PARAMETER_MB_ADDR_RESERVE4_783 = 3783,
            PARAMETER_MB_ADDR_RESERVE4_784 = 3784,
            PARAMETER_MB_ADDR_RESERVE4_785 = 3785,
            PARAMETER_MB_ADDR_RESERVE4_786 = 3786,
            PARAMETER_MB_ADDR_RESERVE4_787 = 3787,
            PARAMETER_MB_ADDR_RESERVE4_788 = 3788,
            PARAMETER_MB_ADDR_RESERVE4_789 = 3789,
            PARAMETER_MB_ADDR_RESERVE4_790 = 3790,
            PARAMETER_MB_ADDR_RESERVE4_791 = 3791,
            PARAMETER_MB_ADDR_RESERVE4_792 = 3792,
            PARAMETER_MB_ADDR_RESERVE4_793 = 3793,
            PARAMETER_MB_ADDR_RESERVE4_794 = 3794,
            PARAMETER_MB_ADDR_RESERVE4_795 = 3795,
            PARAMETER_MB_ADDR_RESERVE4_796 = 3796,
            PARAMETER_MB_ADDR_RESERVE4_797 = 3797,
            PARAMETER_MB_ADDR_RESERVE4_798 = 3798,
            PARAMETER_MB_ADDR_RESERVE4_799 = 3799,
            PARAMETER_MB_ADDR_RESERVE4_800 = 3800,
            PARAMETER_MB_ADDR_RESERVE4_801 = 3801,
            PARAMETER_MB_ADDR_RESERVE4_802 = 3802,
            PARAMETER_MB_ADDR_RESERVE4_803 = 3803,
            PARAMETER_MB_ADDR_RESERVE4_804 = 3804,
            PARAMETER_MB_ADDR_RESERVE4_805 = 3805,
            PARAMETER_MB_ADDR_RESERVE4_806 = 3806,
            PARAMETER_MB_ADDR_RESERVE4_807 = 3807,
            PARAMETER_MB_ADDR_RESERVE4_808 = 3808,
            PARAMETER_MB_ADDR_RESERVE4_809 = 3809,
            PARAMETER_MB_ADDR_RESERVE4_810 = 3810,
            PARAMETER_MB_ADDR_RESERVE4_811 = 3811,
            PARAMETER_MB_ADDR_RESERVE4_812 = 3812,
            PARAMETER_MB_ADDR_RESERVE4_813 = 3813,
            PARAMETER_MB_ADDR_RESERVE4_814 = 3814,
            PARAMETER_MB_ADDR_RESERVE4_815 = 3815,
            PARAMETER_MB_ADDR_RESERVE4_816 = 3816,
            PARAMETER_MB_ADDR_RESERVE4_817 = 3817,
            PARAMETER_MB_ADDR_RESERVE4_818 = 3818,
            PARAMETER_MB_ADDR_RESERVE4_819 = 3819,
            PARAMETER_MB_ADDR_RESERVE4_820 = 3820,
            PARAMETER_MB_ADDR_RESERVE4_821 = 3821,
            PARAMETER_MB_ADDR_RESERVE4_822 = 3822,
            PARAMETER_MB_ADDR_RESERVE4_823 = 3823,
            PARAMETER_MB_ADDR_RESERVE4_824 = 3824,
            PARAMETER_MB_ADDR_RESERVE4_825 = 3825,
            PARAMETER_MB_ADDR_RESERVE4_826 = 3826,
            PARAMETER_MB_ADDR_RESERVE4_827 = 3827,
            PARAMETER_MB_ADDR_RESERVE4_828 = 3828,
            PARAMETER_MB_ADDR_RESERVE4_829 = 3829,
            PARAMETER_MB_ADDR_RESERVE4_830 = 3830,
            PARAMETER_MB_ADDR_RESERVE4_831 = 3831,
            PARAMETER_MB_ADDR_RESERVE4_832 = 3832,
            PARAMETER_MB_ADDR_RESERVE4_833 = 3833,
            PARAMETER_MB_ADDR_RESERVE4_834 = 3834,
            PARAMETER_MB_ADDR_RESERVE4_835 = 3835,
            PARAMETER_MB_ADDR_RESERVE4_836 = 3836,
            PARAMETER_MB_ADDR_RESERVE4_837 = 3837,
            PARAMETER_MB_ADDR_RESERVE4_838 = 3838,
            PARAMETER_MB_ADDR_RESERVE4_839 = 3839,
            PARAMETER_MB_ADDR_RESERVE4_840 = 3840,
            PARAMETER_MB_ADDR_RESERVE4_841 = 3841,
            PARAMETER_MB_ADDR_RESERVE4_842 = 3842,
            PARAMETER_MB_ADDR_RESERVE4_843 = 3843,
            PARAMETER_MB_ADDR_RESERVE4_844 = 3844,
            PARAMETER_MB_ADDR_RESERVE4_845 = 3845,
            PARAMETER_MB_ADDR_RESERVE4_846 = 3846,
            PARAMETER_MB_ADDR_RESERVE4_847 = 3847,
            PARAMETER_MB_ADDR_RESERVE4_848 = 3848,
            PARAMETER_MB_ADDR_RESERVE4_849 = 3849,
            PARAMETER_MB_ADDR_RESERVE4_850 = 3850,
            PARAMETER_MB_ADDR_RESERVE4_851 = 3851,
            PARAMETER_MB_ADDR_RESERVE4_852 = 3852,
            PARAMETER_MB_ADDR_RESERVE4_853 = 3853,
            PARAMETER_MB_ADDR_RESERVE4_854 = 3854,
            PARAMETER_MB_ADDR_RESERVE4_855 = 3855,
            PARAMETER_MB_ADDR_RESERVE4_856 = 3856,
            PARAMETER_MB_ADDR_RESERVE4_857 = 3857,
            PARAMETER_MB_ADDR_RESERVE4_858 = 3858,
            PARAMETER_MB_ADDR_RESERVE4_859 = 3859,
            PARAMETER_MB_ADDR_RESERVE4_860 = 3860,
            PARAMETER_MB_ADDR_RESERVE4_861 = 3861,
            PARAMETER_MB_ADDR_RESERVE4_862 = 3862,
            PARAMETER_MB_ADDR_RESERVE4_863 = 3863,
            PARAMETER_MB_ADDR_RESERVE4_864 = 3864,
            PARAMETER_MB_ADDR_RESERVE4_865 = 3865,
            PARAMETER_MB_ADDR_RESERVE4_866 = 3866,
            PARAMETER_MB_ADDR_RESERVE4_867 = 3867,
            PARAMETER_MB_ADDR_RESERVE4_868 = 3868,
            PARAMETER_MB_ADDR_RESERVE4_869 = 3869,
            PARAMETER_MB_ADDR_RESERVE4_870 = 3870,
            PARAMETER_MB_ADDR_RESERVE4_871 = 3871,
            PARAMETER_MB_ADDR_RESERVE4_872 = 3872,
            PARAMETER_MB_ADDR_RESERVE4_873 = 3873,
            PARAMETER_MB_ADDR_RESERVE4_874 = 3874,
            PARAMETER_MB_ADDR_RESERVE4_875 = 3875,
            PARAMETER_MB_ADDR_RESERVE4_876 = 3876,
            PARAMETER_MB_ADDR_RESERVE4_877 = 3877,
            PARAMETER_MB_ADDR_RESERVE4_878 = 3878,
            PARAMETER_MB_ADDR_RESERVE4_879 = 3879,
            PARAMETER_MB_ADDR_RESERVE4_880 = 3880,
            PARAMETER_MB_ADDR_RESERVE4_881 = 3881,
            PARAMETER_MB_ADDR_RESERVE4_882 = 3882,
            PARAMETER_MB_ADDR_RESERVE4_883 = 3883,
            PARAMETER_MB_ADDR_RESERVE4_884 = 3884,
            PARAMETER_MB_ADDR_RESERVE4_885 = 3885,
            PARAMETER_MB_ADDR_RESERVE4_886 = 3886,
            PARAMETER_MB_ADDR_RESERVE4_887 = 3887,
            PARAMETER_MB_ADDR_RESERVE4_888 = 3888,
            PARAMETER_MB_ADDR_RESERVE4_889 = 3889,
            PARAMETER_MB_ADDR_RESERVE4_890 = 3890,
            PARAMETER_MB_ADDR_RESERVE4_891 = 3891,
            PARAMETER_MB_ADDR_RESERVE4_892 = 3892,
            PARAMETER_MB_ADDR_RESERVE4_893 = 3893,
            PARAMETER_MB_ADDR_RESERVE4_894 = 3894,
            PARAMETER_MB_ADDR_RESERVE4_895 = 3895,
            PARAMETER_MB_ADDR_RESERVE4_896 = 3896,
            PARAMETER_MB_ADDR_RESERVE4_897 = 3897,
            PARAMETER_MB_ADDR_RESERVE4_898 = 3898,
            PARAMETER_MB_ADDR_RESERVE4_899 = 3899,
            PARAMETER_MB_ADDR_RESERVE4_900 = 3900,
            PARAMETER_MB_ADDR_RESERVE4_901 = 3901,
            PARAMETER_MB_ADDR_RESERVE4_902 = 3902,
            PARAMETER_MB_ADDR_RESERVE4_903 = 3903,
            PARAMETER_MB_ADDR_RESERVE4_904 = 3904,
            PARAMETER_MB_ADDR_RESERVE4_905 = 3905,
            PARAMETER_MB_ADDR_RESERVE4_906 = 3906,
            PARAMETER_MB_ADDR_RESERVE4_907 = 3907,
            PARAMETER_MB_ADDR_RESERVE4_908 = 3908,
            PARAMETER_MB_ADDR_RESERVE4_909 = 3909,
            PARAMETER_MB_ADDR_RESERVE4_910 = 3910,
            PARAMETER_MB_ADDR_RESERVE4_911 = 3911,
            PARAMETER_MB_ADDR_RESERVE4_912 = 3912,
            PARAMETER_MB_ADDR_RESERVE4_913 = 3913,
            PARAMETER_MB_ADDR_RESERVE4_914 = 3914,
            PARAMETER_MB_ADDR_RESERVE4_915 = 3915,
            PARAMETER_MB_ADDR_RESERVE4_916 = 3916,
            PARAMETER_MB_ADDR_RESERVE4_917 = 3917,
            PARAMETER_MB_ADDR_RESERVE4_918 = 3918,
            PARAMETER_MB_ADDR_RESERVE4_919 = 3919,
            PARAMETER_MB_ADDR_RESERVE4_920 = 3920,
            PARAMETER_MB_ADDR_RESERVE4_921 = 3921,
            PARAMETER_MB_ADDR_RESERVE4_922 = 3922,
            PARAMETER_MB_ADDR_RESERVE4_923 = 3923,
            PARAMETER_MB_ADDR_RESERVE4_924 = 3924,
            PARAMETER_MB_ADDR_RESERVE4_925 = 3925,
            PARAMETER_MB_ADDR_RESERVE4_926 = 3926,
            PARAMETER_MB_ADDR_RESERVE4_927 = 3927,
            PARAMETER_MB_ADDR_RESERVE4_928 = 3928,
            PARAMETER_MB_ADDR_RESERVE4_929 = 3929,
            PARAMETER_MB_ADDR_RESERVE4_930 = 3930,
            PARAMETER_MB_ADDR_RESERVE4_931 = 3931,
            PARAMETER_MB_ADDR_RESERVE4_932 = 3932,
            PARAMETER_MB_ADDR_RESERVE4_933 = 3933,
            PARAMETER_MB_ADDR_RESERVE4_934 = 3934,
            PARAMETER_MB_ADDR_RESERVE4_935 = 3935,
            PARAMETER_MB_ADDR_RESERVE4_936 = 3936,
            PARAMETER_MB_ADDR_RESERVE4_937 = 3937,
            PARAMETER_MB_ADDR_RESERVE4_938 = 3938,
            PARAMETER_MB_ADDR_RESERVE4_939 = 3939,
            PARAMETER_MB_ADDR_RESERVE4_940 = 3940,
            PARAMETER_MB_ADDR_RESERVE4_941 = 3941,
            PARAMETER_MB_ADDR_RESERVE4_942 = 3942,
            PARAMETER_MB_ADDR_RESERVE4_943 = 3943,
            PARAMETER_MB_ADDR_RESERVE4_944 = 3944,
            PARAMETER_MB_ADDR_RESERVE4_945 = 3945,
            PARAMETER_MB_ADDR_RESERVE4_946 = 3946,
            PARAMETER_MB_ADDR_RESERVE4_947 = 3947,
            PARAMETER_MB_ADDR_RESERVE4_948 = 3948,
            PARAMETER_MB_ADDR_RESERVE4_949 = 3949,
            PARAMETER_MB_ADDR_RESERVE4_950 = 3950,
            PARAMETER_MB_ADDR_RESERVE4_951 = 3951,
            PARAMETER_MB_ADDR_RESERVE4_952 = 3952,
            PARAMETER_MB_ADDR_RESERVE4_953 = 3953,
            PARAMETER_MB_ADDR_RESERVE4_954 = 3954,
            PARAMETER_MB_ADDR_RESERVE4_955 = 3955,
            PARAMETER_MB_ADDR_RESERVE4_956 = 3956,
            PARAMETER_MB_ADDR_RESERVE4_957 = 3957,
            PARAMETER_MB_ADDR_RESERVE4_958 = 3958,
            PARAMETER_MB_ADDR_RESERVE4_959 = 3959,
            PARAMETER_MB_ADDR_RESERVE4_960 = 3960,
            PARAMETER_MB_ADDR_RESERVE4_961 = 3961,
            PARAMETER_MB_ADDR_RESERVE4_962 = 3962,
            PARAMETER_MB_ADDR_RESERVE4_963 = 3963,
            PARAMETER_MB_ADDR_RESERVE4_964 = 3964,
            PARAMETER_MB_ADDR_RESERVE4_965 = 3965,
            PARAMETER_MB_ADDR_RESERVE4_966 = 3966,
            PARAMETER_MB_ADDR_RESERVE4_967 = 3967,
            PARAMETER_MB_ADDR_RESERVE4_968 = 3968,
            PARAMETER_MB_ADDR_RESERVE4_969 = 3969,
            PARAMETER_MB_ADDR_RESERVE4_970 = 3970,
            PARAMETER_MB_ADDR_RESERVE4_971 = 3971,
            PARAMETER_MB_ADDR_RESERVE4_972 = 3972,
            PARAMETER_MB_ADDR_RESERVE4_973 = 3973,
            PARAMETER_MB_ADDR_RESERVE4_974 = 3974,
            PARAMETER_MB_ADDR_RESERVE4_975 = 3975,
            PARAMETER_MB_ADDR_RESERVE4_976 = 3976,
            PARAMETER_MB_ADDR_RESERVE4_977 = 3977,
            PARAMETER_MB_ADDR_RESERVE4_978 = 3978,
            PARAMETER_MB_ADDR_RESERVE4_979 = 3979,
            PARAMETER_MB_ADDR_RESERVE4_980 = 3980,
            PARAMETER_MB_ADDR_RESERVE4_981 = 3981,
            PARAMETER_MB_ADDR_RESERVE4_982 = 3982,
            PARAMETER_MB_ADDR_RESERVE4_983 = 3983,
            PARAMETER_MB_ADDR_RESERVE4_984 = 3984,
            PARAMETER_MB_ADDR_RESERVE4_985 = 3985,
            PARAMETER_MB_ADDR_RESERVE4_986 = 3986,
            PARAMETER_MB_ADDR_RESERVE4_987 = 3987,
            PARAMETER_MB_ADDR_RESERVE4_988 = 3988,
            PARAMETER_MB_ADDR_RESERVE4_989 = 3989,
            PARAMETER_MB_ADDR_RESERVE4_990 = 3990,
            PARAMETER_MB_ADDR_RESERVE4_991 = 3991,
            PARAMETER_MB_ADDR_RESERVE4_992 = 3992,
            PARAMETER_MB_ADDR_RESERVE4_993 = 3993,
            PARAMETER_MB_ADDR_RESERVE4_994 = 3994,
            PARAMETER_MB_ADDR_RESERVE4_995 = 3995,
            PARAMETER_MB_ADDR_RESERVE4_996 = 3996,
            PARAMETER_MB_ADDR_RESERVE4_997 = 3997,
            PARAMETER_MB_ADDR_RESERVE4_998 = 3998,
            PARAMETER_MB_ADDR_RESERVE4_999 = 3999,
            PARAMETER_MB_ADDR_SLAVE_ID = 4000,
            PARAMETER_MB_ADDR_IDENTIFY_STATUS = 4001,
            PARAMETER_MB_ADDR_STREAMING_ENABLE_CMD = 4002,
            PARAMETER_MB_ADDR_STREAMING_DISABLE_CMD = 4003,
            PARAMETER_MB_ADDR_DOWN_STREAM_BAUDRATE_0 = 4004,
            PARAMETER_MB_ADDR_DOWN_STREAM_BAUDRATE_1 = 4005,
            PARAMETER_MB_ADDR_UP_STREAM_RECEIVED_FRAME_QTY_0 = 4006,
            PARAMETER_MB_ADDR_UP_STREAM_RECEIVED_FRAME_QTY_1 = 4007,
            PARAMETER_MB_ADDR_UP_STREAM_RECEIVED_FRAME_MISMATCH_ID_QTY_0 = 4008,
            PARAMETER_MB_ADDR_UP_STREAM_RECEIVED_FRAME_MISMATCH_ID_QTY_1 = 4009,
            PARAMETER_MB_ADDR_UP_STREAM_RECEIVED_FRAME_BROADCAST_QTY_0 = 4010,
            PARAMETER_MB_ADDR_UP_STREAM_RECEIVED_FRAME_BROADCAST_QTY_1 = 4011,
            PARAMETER_MB_ADDR_UP_STREAM_RECEIVED_FRAME_ERROR_QTY_0 = 4012,
            PARAMETER_MB_ADDR_UP_STREAM_RECEIVED_FRAME_ERROR_QTY_1 = 4013,
            PARAMETER_MB_ADDR_UP_STREAM_SEND_FRAME_QTY_0 = 4014,
            PARAMETER_MB_ADDR_UP_STREAM_SEND_FRAME_QTY_1 = 4015,
            PARAMETER_MB_ADDR_UP_STREAM_ENQUEUED_FRAME_QTY_0 = 4016,
            PARAMETER_MB_ADDR_UP_STREAM_ENQUEUED_FRAME_QTY_1 = 4017,
            PARAMETER_MB_ADDR_UP_STREAM_ENQUEUE_FAILED_FRAME_QTY_0 = 4018,
            PARAMETER_MB_ADDR_UP_STREAM_ENQUEUE_FAILED_FRAME_QTY_1 = 4019,
            PARAMETER_MB_ADDR_UP_STREAM_RECEIVED_FRAME_HANDLE_EXECUTION_TIME_US_0 = 4020,
            PARAMETER_MB_ADDR_UP_STREAM_RECEIVED_FRAME_HANDLE_EXECUTION_TIME_US_1 = 4021,
            PARAMETER_MB_ADDR_UP_STREAM_RECEIVED_FRAME_MEMORY_MAP_HANDLER_EXECUTION_TIME_US_0 = 4022,
            PARAMETER_MB_ADDR_UP_STREAM_RECEIVED_FRAME_MEMORY_MAP_HANDLER_EXECUTION_TIME_US_1 = 4023,
            PARAMETER_MB_ADDR_UP_STREAM_RECEIVED_FRAME_MISMATCH_ID_HANDLER_EXECUTION_TIME_US_0 = 4024,
            PARAMETER_MB_ADDR_UP_STREAM_RECEIVED_FRAME_MISMATCH_ID_HANDLER_EXECUTION_TIME_US_1 = 4025,
            PARAMETER_MB_ADDR_UP_STREAM_RECEIVED_FRAME_BROADCAST_HANDLER_EXECUTION_TIME_US_0 = 4026,
            PARAMETER_MB_ADDR_UP_STREAM_RECEIVED_FRAME_BROADCAST_HANDLER_EXECUTION_TIME_US_1 = 4027,
            PARAMETER_MB_ADDR_UP_STREAM_RECEIVED_FRAME_TRANSACTION_DONE_HANDLER_EXECUTION_TIME_US_0 = 4028,
            PARAMETER_MB_ADDR_UP_STREAM_RECEIVED_FRAME_TRANSACTION_DONE_HANDLER_EXECUTION_TIME_US_1 = 4029,
            PARAMETER_MB_ADDR_UP_STREAM_RECEIVED_FRAME_ERROR_HANDLER_EXECUTION_TIME_US_0 = 4030,
            PARAMETER_MB_ADDR_UP_STREAM_RECEIVED_FRAME_ERROR_HANDLER_EXECUTION_TIME_US_1 = 4031,
            PARAMETER_MB_ADDR_UP_STREAM_SEND_FRAME_HANDLE_EXECUTION_TIME_US_0 = 4032,
            PARAMETER_MB_ADDR_UP_STREAM_SEND_FRAME_HANDLE_EXECUTION_TIME_US_1 = 4033,
            PARAMETER_MB_ADDR_UP_STREAM_DELAY_BETWEEN_FRAME_US = 4034,
            PARAMETER_MB_ADDR_STREAMER_ENABLE = 4035,
            PARAMETER_MB_ADDR_STREAMER_EXTENDED_HEADER_ENABLE = 4036,
            PARAMETER_MB_ADDR_STREAMER_INTERNAL_CLOCK_INTERVAL_MS = 4037,
            PARAMETER_MB_ADDR_STREAMER_PRESCALER = 4038,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_0 = 4039,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_1 = 4040,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_2 = 4041,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_3 = 4042,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_4 = 4043,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_5 = 4044,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_6 = 4045,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_7 = 4046,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_8 = 4047,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_9 = 4048,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_10 = 4049,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_11 = 4050,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_12 = 4051,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_13 = 4052,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_14 = 4053,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_15 = 4054,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_16 = 4055,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_17 = 4056,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_18 = 4057,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_19 = 4058,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_20 = 4059,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_21 = 4060,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_22 = 4061,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_23 = 4062,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_24 = 4063,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_25 = 4064,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_26 = 4065,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_27 = 4066,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_28 = 4067,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_29 = 4068,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_30 = 4069,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_31 = 4070,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_32 = 4071,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_33 = 4072,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_34 = 4073,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_35 = 4074,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_36 = 4075,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_37 = 4076,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_38 = 4077,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_39 = 4078,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_40 = 4079,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_41 = 4080,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_42 = 4081,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_43 = 4082,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_44 = 4083,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_45 = 4084,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_46 = 4085,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_47 = 4086,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_48 = 4087,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_49 = 4088,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_50 = 4089,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_51 = 4090,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_52 = 4091,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_53 = 4092,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_54 = 4093,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_55 = 4094,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_56 = 4095,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_57 = 4096,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_58 = 4097,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_59 = 4098,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_60 = 4099,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_61 = 4100,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_62 = 4101,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_63 = 4102,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_64 = 4103,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_65 = 4104,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_66 = 4105,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_67 = 4106,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_68 = 4107,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_69 = 4108,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_70 = 4109,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_71 = 4110,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_72 = 4111,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_73 = 4112,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_74 = 4113,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_75 = 4114,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_76 = 4115,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_77 = 4116,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_78 = 4117,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_79 = 4118,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_80 = 4119,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_81 = 4120,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_82 = 4121,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_83 = 4122,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_84 = 4123,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_85 = 4124,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_86 = 4125,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_87 = 4126,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_88 = 4127,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_89 = 4128,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_90 = 4129,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_91 = 4130,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_92 = 4131,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_93 = 4132,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_94 = 4133,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_95 = 4134,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_96 = 4135,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_97 = 4136,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_98 = 4137,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_99 = 4138,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_100 = 4139,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_101 = 4140,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_102 = 4141,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_103 = 4142,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_104 = 4143,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_105 = 4144,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_106 = 4145,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_107 = 4146,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_108 = 4147,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_109 = 4148,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_110 = 4149,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_111 = 4150,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_112 = 4151,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_113 = 4152,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_114 = 4153,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_115 = 4154,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_116 = 4155,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_117 = 4156,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_118 = 4157,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_119 = 4158,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_120 = 4159,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_121 = 4160,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_122 = 4161,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_123 = 4162,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_124 = 4163,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_125 = 4164,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_126 = 4165,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_127 = 4166,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_128 = 4167,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_129 = 4168,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_130 = 4169,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_131 = 4170,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_132 = 4171,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_133 = 4172,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_134 = 4173,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_135 = 4174,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_136 = 4175,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_137 = 4176,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_138 = 4177,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_139 = 4178,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_140 = 4179,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_141 = 4180,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_142 = 4181,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_143 = 4182,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_144 = 4183,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_145 = 4184,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_146 = 4185,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_147 = 4186,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_148 = 4187,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_149 = 4188,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_150 = 4189,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_151 = 4190,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_152 = 4191,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_153 = 4192,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_154 = 4193,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_155 = 4194,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_156 = 4195,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_157 = 4196,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_158 = 4197,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_159 = 4198,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_160 = 4199,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_161 = 4200,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_162 = 4201,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_163 = 4202,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_164 = 4203,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_165 = 4204,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_166 = 4205,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_167 = 4206,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_168 = 4207,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_169 = 4208,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_170 = 4209,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_171 = 4210,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_172 = 4211,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_173 = 4212,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_174 = 4213,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_175 = 4214,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_176 = 4215,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_177 = 4216,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_178 = 4217,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_179 = 4218,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_180 = 4219,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_181 = 4220,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_182 = 4221,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_183 = 4222,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_184 = 4223,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_185 = 4224,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_186 = 4225,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_187 = 4226,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_188 = 4227,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_189 = 4228,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_190 = 4229,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_191 = 4230,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_192 = 4231,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_193 = 4232,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_194 = 4233,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_195 = 4234,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_196 = 4235,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_197 = 4236,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_198 = 4237,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_IDS_199 = 4238,
            PARAMETER_MB_ADDR_STREAMER_INTERVAL_US_0 = 4239,
            PARAMETER_MB_ADDR_STREAMER_INTERVAL_US_1 = 4240,
            PARAMETER_MB_ADDR_STREAMER_FRAME_COUNTER_0 = 4241,
            PARAMETER_MB_ADDR_STREAMER_FRAME_COUNTER_1 = 4242,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_QTY_0 = 4243,
            PARAMETER_MB_ADDR_STREAMER_PARAMETER_QTY_1 = 4244,
            PARAMETER_MB_ADDR_STREAMER_FRAME_GENERATION_EXECUTION_TIME_US_0 = 4245,
            PARAMETER_MB_ADDR_STREAMER_FRAME_GENERATION_EXECUTION_TIME_US_1 = 4246,
            PARAMETER_MB_ADDR_BOARD_STARTUP_DELAY_MS = 4247,
            PARAMETER_MB_ADDR_BOARD_STARTUP_RETRY_QTY = 4248,
            PARAMETER_MB_ADDR_BOARD_STARTUP_RETRY_DELAY_MS = 4249,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_OVERALL_RESULT = 4250,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_EXECUTION_TIME_US = 4251,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_0_CONNECTION_RESULT = 4252,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_0_CONNECTION_RETRY = 4253,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_0_CONNECTION_TIME_US_0 = 4254,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_0_CONNECTION_TIME_US_1 = 4255,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_0_CONFIG_RESULT = 4256,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_0_CONFIG_RETRY = 4257,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_0_CONFIG_TIME_US_0 = 4258,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_0_CONFIG_TIME_US_1 = 4259,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_1_CONNECTION_RESULT = 4260,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_1_CONNECTION_RETRY = 4261,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_1_CONNECTION_TIME_US_0 = 4262,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_1_CONNECTION_TIME_US_1 = 4263,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_1_CONFIG_RESULT = 4264,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_1_CONFIG_RETRY = 4265,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_1_CONFIG_TIME_US_0 = 4266,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_1_CONFIG_TIME_US_1 = 4267,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_2_CONNECTION_RESULT = 4268,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_2_CONNECTION_RETRY = 4269,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_2_CONNECTION_TIME_US_0 = 4270,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_2_CONNECTION_TIME_US_1 = 4271,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_2_CONFIG_RESULT = 4272,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_2_CONFIG_RETRY = 4273,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_2_CONFIG_TIME_US_0 = 4274,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_2_CONFIG_TIME_US_1 = 4275,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_3_CONNECTION_RESULT = 4276,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_3_CONNECTION_RETRY = 4277,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_3_CONNECTION_TIME_US_0 = 4278,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_3_CONNECTION_TIME_US_1 = 4279,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_3_CONFIG_RESULT = 4280,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_3_CONFIG_RETRY = 4281,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_3_CONFIG_TIME_US_0 = 4282,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_3_CONFIG_TIME_US_1 = 4283,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_0_CONNECTION_RESULT = 4284,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_0_CONNECTION_RETRY = 4285,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_0_CONNECTION_TIME_US_0 = 4286,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_0_CONNECTION_TIME_US_1 = 4287,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_0_CONFIG_RESULT = 4288,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_0_CONFIG_RETRY = 4289,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_0_CONFIG_TIME_US_0 = 4290,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_0_CONFIG_TIME_US_1 = 4291,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_1_CONNECTION_RESULT = 4292,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_1_CONNECTION_RETRY = 4293,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_1_CONNECTION_TIME_US_0 = 4294,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_1_CONNECTION_TIME_US_1 = 4295,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_1_CONFIG_RESULT = 4296,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_1_CONFIG_RETRY = 4297,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_1_CONFIG_TIME_US_0 = 4298,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_1_CONFIG_TIME_US_1 = 4299,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_2_CONNECTION_RESULT = 4300,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_2_CONNECTION_RETRY = 4301,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_2_CONNECTION_TIME_US_0 = 4302,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_2_CONNECTION_TIME_US_1 = 4303,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_2_CONFIG_RESULT = 4304,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_2_CONFIG_RETRY = 4305,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_2_CONFIG_TIME_US_0 = 4306,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_2_CONFIG_TIME_US_1 = 4307,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_3_CONNECTION_RESULT = 4308,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_3_CONNECTION_RETRY = 4309,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_3_CONNECTION_TIME_US_0 = 4310,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_3_CONNECTION_TIME_US_1 = 4311,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_3_CONFIG_RESULT = 4312,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_3_CONFIG_RETRY = 4313,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_3_CONFIG_TIME_US_0 = 4314,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_3_CONFIG_TIME_US_1 = 4315,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_ADXL357_0_CONNECTION_RESULT = 4316,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_ADXL357_0_CONNECTION_RETRY = 4317,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_ADXL357_0_CONNECTION_TIME_US_0 = 4318,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_ADXL357_0_CONNECTION_TIME_US_1 = 4319,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_ADXL357_0_CONFIG_RESULT = 4320,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_ADXL357_0_CONFIG_RETRY = 4321,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_ADXL357_0_CONFIG_TIME_US_0 = 4322,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_ADXL357_0_CONFIG_TIME_US_1 = 4323,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_ADXL357_1_CONNECTION_RESULT = 4324,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_ADXL357_1_CONNECTION_RETRY = 4325,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_ADXL357_1_CONNECTION_TIME_US_0 = 4326,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_ADXL357_1_CONNECTION_TIME_US_1 = 4327,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_ADXL357_1_CONFIG_RESULT = 4328,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_ADXL357_1_CONFIG_RETRY = 4329,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_ADXL357_1_CONFIG_TIME_US_0 = 4330,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_ADXL357_1_CONFIG_TIME_US_1 = 4331,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_ADXL357_2_CONNECTION_RESULT = 4332,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_ADXL357_2_CONNECTION_RETRY = 4333,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_ADXL357_2_CONNECTION_TIME_US_0 = 4334,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_ADXL357_2_CONNECTION_TIME_US_1 = 4335,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_ADXL357_2_CONFIG_RESULT = 4336,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_ADXL357_2_CONFIG_RETRY = 4337,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_ADXL357_2_CONFIG_TIME_US_0 = 4338,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_ADXL357_2_CONFIG_TIME_US_1 = 4339,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMA_SX_0_CONNECTION_RESULT = 4340,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMA_SX_0_CONNECTION_RETRY = 4341,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMA_SX_0_CONNECTION_TIME_US_0 = 4342,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMA_SX_0_CONNECTION_TIME_US_1 = 4343,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMA_SX_0_CONFIG_RESULT = 4344,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMA_SX_0_CONFIG_RETRY = 4345,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMA_SX_0_CONFIG_TIME_US_0 = 4346,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMA_SX_0_CONFIG_TIME_US_1 = 4347,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMA_SX_1_CONNECTION_RESULT = 4348,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMA_SX_1_CONNECTION_RETRY = 4349,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMA_SX_1_CONNECTION_TIME_US_0 = 4350,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMA_SX_1_CONNECTION_TIME_US_1 = 4351,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMA_SX_1_CONFIG_RESULT = 4352,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMA_SX_1_CONFIG_RETRY = 4353,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMA_SX_1_CONFIG_TIME_US_0 = 4354,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMA_SX_1_CONFIG_TIME_US_1 = 4355,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMA_SX_2_CONNECTION_RESULT = 4356,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMA_SX_2_CONNECTION_RETRY = 4357,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMA_SX_2_CONNECTION_TIME_US_0 = 4358,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMA_SX_2_CONNECTION_TIME_US_1 = 4359,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMA_SX_2_CONFIG_RESULT = 4360,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMA_SX_2_CONFIG_RETRY = 4361,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMA_SX_2_CONFIG_TIME_US_0 = 4362,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMA_SX_2_CONFIG_TIME_US_1 = 4363,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_H3_0_CONNECTION_RESULT = 4364,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_H3_0_CONNECTION_RETRY = 4365,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_H3_0_CONNECTION_TIME_US_0 = 4366,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_H3_0_CONNECTION_TIME_US_1 = 4367,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_H3_0_CONFIG_RESULT = 4368,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_H3_0_CONFIG_RETRY = 4369,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_H3_0_CONFIG_TIME_US_0 = 4370,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_H3_0_CONFIG_TIME_US_1 = 4371,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_H3_1_CONNECTION_RESULT = 4372,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_H3_1_CONNECTION_RETRY = 4373,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_H3_1_CONNECTION_TIME_US_0 = 4374,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_H3_1_CONNECTION_TIME_US_1 = 4375,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_H3_1_CONFIG_RESULT = 4376,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_H3_1_CONFIG_RETRY = 4377,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_H3_1_CONFIG_TIME_US_0 = 4378,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_H3_1_CONFIG_TIME_US_1 = 4379,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_H3_2_CONNECTION_RESULT = 4380,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_H3_2_CONNECTION_RETRY = 4381,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_H3_2_CONNECTION_TIME_US_0 = 4382,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_H3_2_CONNECTION_TIME_US_1 = 4383,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_H3_2_CONFIG_RESULT = 4384,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_H3_2_CONFIG_RETRY = 4385,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_H3_2_CONFIG_TIME_US_0 = 4386,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_H3_2_CONFIG_TIME_US_1 = 4387,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMG_0_CONNECTION_RESULT = 4388,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMG_0_CONNECTION_RETRY = 4389,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMG_0_CONNECTION_TIME_US_0 = 4390,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMG_0_CONNECTION_TIME_US_1 = 4391,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMG_0_CONFIG_RESULT = 4392,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMG_0_CONFIG_RETRY = 4393,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMG_0_CONFIG_TIME_US_0 = 4394,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMG_0_CONFIG_TIME_US_1 = 4395,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMG_1_CONNECTION_RESULT = 4396,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMG_1_CONNECTION_RETRY = 4397,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMG_1_CONNECTION_TIME_US_0 = 4398,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMG_1_CONNECTION_TIME_US_1 = 4399,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMG_1_CONFIG_RESULT = 4400,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMG_1_CONFIG_RETRY = 4401,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMG_1_CONFIG_TIME_US_0 = 4402,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMG_1_CONFIG_TIME_US_1 = 4403,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMG_2_CONNECTION_RESULT = 4404,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMG_2_CONNECTION_RETRY = 4405,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMG_2_CONNECTION_TIME_US_0 = 4406,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMG_2_CONNECTION_TIME_US_1 = 4407,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMG_2_CONFIG_RESULT = 4408,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMG_2_CONFIG_RETRY = 4409,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMG_2_CONFIG_TIME_US_0 = 4410,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMG_2_CONFIG_TIME_US_1 = 4411,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMA_H60_CONNECTION_RESULT = 4412,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMA_H60_CONNECTION_RETRY = 4413,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMA_H60_CONNECTION_TIME_US_0 = 4414,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMA_H60_CONNECTION_TIME_US_1 = 4415,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMA_H60_CONFIG_RESULT = 4416,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMA_H60_CONFIG_RETRY = 4417,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMA_H60_CONFIG_TIME_US_0 = 4418,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_XRMA_H60_CONFIG_TIME_US_1 = 4419,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_HMC5983_0_CONNECTION_RESULT = 4420,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_HMC5983_0_CONNECTION_RETRY = 4421,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_HMC5983_0_CONNECTION_TIME_US_0 = 4422,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_HMC5983_0_CONNECTION_TIME_US_1 = 4423,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_HMC5983_0_CONFIG_RESULT = 4424,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_HMC5983_0_CONFIG_RETRY = 4425,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_HMC5983_0_CONFIG_TIME_US_0 = 4426,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_HMC5983_0_CONFIG_TIME_US_1 = 4427,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_HMC5983_1_CONNECTION_RESULT = 4428,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_HMC5983_1_CONNECTION_RETRY = 4429,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_HMC5983_1_CONNECTION_TIME_US_0 = 4430,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_HMC5983_1_CONNECTION_TIME_US_1 = 4431,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_HMC5983_1_CONFIG_RESULT = 4432,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_HMC5983_1_CONFIG_RETRY = 4433,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_HMC5983_1_CONFIG_TIME_US_0 = 4434,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_HMC5983_1_CONFIG_TIME_US_1 = 4435,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_HMC5983_2_CONNECTION_RESULT = 4436,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_HMC5983_2_CONNECTION_RETRY = 4437,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_HMC5983_2_CONNECTION_TIME_US_0 = 4438,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_HMC5983_2_CONNECTION_TIME_US_1 = 4439,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_HMC5983_2_CONFIG_RESULT = 4440,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_HMC5983_2_CONFIG_RETRY = 4441,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_HMC5983_2_CONFIG_TIME_US_0 = 4442,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_HMC5983_2_CONFIG_TIME_US_1 = 4443,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMM_0_CONNECTION_RESULT = 4444,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMM_0_CONNECTION_RETRY = 4445,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMM_0_CONNECTION_TIME_US_0 = 4446,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMM_0_CONNECTION_TIME_US_1 = 4447,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMM_0_CONFIG_RESULT = 4448,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMM_0_CONFIG_RETRY = 4449,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMM_0_CONFIG_TIME_US_0 = 4450,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMM_0_CONFIG_TIME_US_1 = 4451,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMM_1_CONNECTION_RESULT = 4452,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMM_1_CONNECTION_RETRY = 4453,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMM_1_CONNECTION_TIME_US_0 = 4454,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMM_1_CONNECTION_TIME_US_1 = 4455,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMM_1_CONFIG_RESULT = 4456,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMM_1_CONFIG_RETRY = 4457,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMM_1_CONFIG_TIME_US_0 = 4458,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMM_1_CONFIG_TIME_US_1 = 4459,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_MS56_CONNECTION_RESULT = 4460,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_MS56_CONNECTION_RETRY = 4461,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_MS56_CONNECTION_TIME_US_0 = 4462,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_MS56_CONNECTION_TIME_US_1 = 4463,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_MS56_CONFIG_RESULT = 4464,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_MS56_CONFIG_RETRY = 4465,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_MS56_CONFIG_TIME_US_0 = 4466,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_MS56_CONFIG_TIME_US_1 = 4467,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_GYRO_X_0 = 4468,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_GYRO_X_1 = 4469,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_GYRO_X_2 = 4470,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_GYRO_X_3 = 4471,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_GYRO_Y_0 = 4472,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_GYRO_Y_1 = 4473,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_GYRO_Y_2 = 4474,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_GYRO_Y_3 = 4475,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_GYRO_Z_0 = 4476,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_GYRO_Z_1 = 4477,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_GYRO_Z_2 = 4478,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_GYRO_Z_3 = 4479,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_ACC_X_0 = 4480,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_ACC_X_1 = 4481,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_ACC_X_2 = 4482,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_ACC_X_3 = 4483,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_ACC_Y_0 = 4484,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_ACC_Y_1 = 4485,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_ACC_Y_2 = 4486,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_ACC_Y_3 = 4487,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_ACC_Z_0 = 4488,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_ACC_Z_1 = 4489,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_ACC_Z_2 = 4490,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_ACC_Z_3 = 4491,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_TEMPERATURE_0 = 4492,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_TEMPERATURE_1 = 4493,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_COUNTER_0 = 4494,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_COUNTER_1 = 4495,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_READ_ERROR_COUNTER_0 = 4496,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_READ_ERROR_COUNTER_1 = 4497,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_SERIAL_NO_0 = 4498,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_SERIAL_NO_1 = 4499,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_NO = 4500,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_STATUS_0 = 4501,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_STATUS_1 = 4502,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_0_ACTIVE = 4503,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_GYRO_X_0 = 4504,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_GYRO_X_1 = 4505,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_GYRO_X_2 = 4506,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_GYRO_X_3 = 4507,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_GYRO_Y_0 = 4508,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_GYRO_Y_1 = 4509,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_GYRO_Y_2 = 4510,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_GYRO_Y_3 = 4511,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_GYRO_Z_0 = 4512,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_GYRO_Z_1 = 4513,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_GYRO_Z_2 = 4514,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_GYRO_Z_3 = 4515,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_ACC_X_0 = 4516,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_ACC_X_1 = 4517,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_ACC_X_2 = 4518,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_ACC_X_3 = 4519,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_ACC_Y_0 = 4520,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_ACC_Y_1 = 4521,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_ACC_Y_2 = 4522,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_ACC_Y_3 = 4523,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_ACC_Z_0 = 4524,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_ACC_Z_1 = 4525,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_ACC_Z_2 = 4526,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_ACC_Z_3 = 4527,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_TEMPERATURE_0 = 4528,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_TEMPERATURE_1 = 4529,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_COUNTER_0 = 4530,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_COUNTER_1 = 4531,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_READ_ERROR_COUNTER_0 = 4532,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_READ_ERROR_COUNTER_1 = 4533,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_SERIAL_NO_0 = 4534,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_SERIAL_NO_1 = 4535,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_NO = 4536,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_STATUS_0 = 4537,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_STATUS_1 = 4538,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_1_ACTIVE = 4539,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_GYRO_X_0 = 4540,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_GYRO_X_1 = 4541,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_GYRO_X_2 = 4542,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_GYRO_X_3 = 4543,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_GYRO_Y_0 = 4544,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_GYRO_Y_1 = 4545,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_GYRO_Y_2 = 4546,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_GYRO_Y_3 = 4547,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_GYRO_Z_0 = 4548,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_GYRO_Z_1 = 4549,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_GYRO_Z_2 = 4550,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_GYRO_Z_3 = 4551,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_ACC_X_0 = 4552,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_ACC_X_1 = 4553,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_ACC_X_2 = 4554,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_ACC_X_3 = 4555,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_ACC_Y_0 = 4556,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_ACC_Y_1 = 4557,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_ACC_Y_2 = 4558,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_ACC_Y_3 = 4559,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_ACC_Z_0 = 4560,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_ACC_Z_1 = 4561,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_ACC_Z_2 = 4562,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_ACC_Z_3 = 4563,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_TEMPERATURE_0 = 4564,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_TEMPERATURE_1 = 4565,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_COUNTER_0 = 4566,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_COUNTER_1 = 4567,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_READ_ERROR_COUNTER_0 = 4568,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_READ_ERROR_COUNTER_1 = 4569,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_SERIAL_NO_0 = 4570,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_SERIAL_NO_1 = 4571,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_NO = 4572,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_STATUS_0 = 4573,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_STATUS_1 = 4574,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_2_ACTIVE = 4575,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_GYRO_X_0 = 4576,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_GYRO_X_1 = 4577,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_GYRO_X_2 = 4578,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_GYRO_X_3 = 4579,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_GYRO_Y_0 = 4580,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_GYRO_Y_1 = 4581,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_GYRO_Y_2 = 4582,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_GYRO_Y_3 = 4583,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_GYRO_Z_0 = 4584,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_GYRO_Z_1 = 4585,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_GYRO_Z_2 = 4586,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_GYRO_Z_3 = 4587,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_ACC_X_0 = 4588,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_ACC_X_1 = 4589,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_ACC_X_2 = 4590,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_ACC_X_3 = 4591,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_ACC_Y_0 = 4592,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_ACC_Y_1 = 4593,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_ACC_Y_2 = 4594,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_ACC_Y_3 = 4595,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_ACC_Z_0 = 4596,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_ACC_Z_1 = 4597,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_ACC_Z_2 = 4598,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_ACC_Z_3 = 4599,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_TEMPERATURE_0 = 4600,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_TEMPERATURE_1 = 4601,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_COUNTER_0 = 4602,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_COUNTER_1 = 4603,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_READ_ERROR_COUNTER_0 = 4604,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_READ_ERROR_COUNTER_1 = 4605,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_SERIAL_NO_0 = 4606,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_SERIAL_NO_1 = 4607,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_NO = 4608,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_STATUS_0 = 4609,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_STATUS_1 = 4610,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_3_ACTIVE = 4611,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_GYRO_X_0 = 4612,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_GYRO_X_1 = 4613,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_GYRO_X_2 = 4614,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_GYRO_X_3 = 4615,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_GYRO_Y_0 = 4616,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_GYRO_Y_1 = 4617,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_GYRO_Y_2 = 4618,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_GYRO_Y_3 = 4619,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_GYRO_Z_0 = 4620,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_GYRO_Z_1 = 4621,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_GYRO_Z_2 = 4622,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_GYRO_Z_3 = 4623,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_ACC_X_0 = 4624,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_ACC_X_1 = 4625,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_ACC_X_2 = 4626,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_ACC_X_3 = 4627,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_ACC_Y_0 = 4628,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_ACC_Y_1 = 4629,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_ACC_Y_2 = 4630,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_ACC_Y_3 = 4631,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_ACC_Z_0 = 4632,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_ACC_Z_1 = 4633,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_ACC_Z_2 = 4634,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_ACC_Z_3 = 4635,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_TEMPERATURE_0 = 4636,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_TEMPERATURE_1 = 4637,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_COUNTER_0 = 4638,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_COUNTER_1 = 4639,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_READ_ERROR_COUNTER_0 = 4640,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_READ_ERROR_COUNTER_1 = 4641,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_SERIAL_NO_0 = 4642,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_SERIAL_NO_1 = 4643,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_NO = 4644,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_STATUS_0 = 4645,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_STATUS_1 = 4646,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_4_ACTIVE = 4647,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_GYRO_X_0 = 4648,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_GYRO_X_1 = 4649,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_GYRO_X_2 = 4650,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_GYRO_X_3 = 4651,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_GYRO_Y_0 = 4652,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_GYRO_Y_1 = 4653,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_GYRO_Y_2 = 4654,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_GYRO_Y_3 = 4655,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_GYRO_Z_0 = 4656,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_GYRO_Z_1 = 4657,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_GYRO_Z_2 = 4658,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_GYRO_Z_3 = 4659,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_ACC_X_0 = 4660,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_ACC_X_1 = 4661,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_ACC_X_2 = 4662,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_ACC_X_3 = 4663,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_ACC_Y_0 = 4664,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_ACC_Y_1 = 4665,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_ACC_Y_2 = 4666,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_ACC_Y_3 = 4667,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_ACC_Z_0 = 4668,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_ACC_Z_1 = 4669,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_ACC_Z_2 = 4670,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_ACC_Z_3 = 4671,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_TEMPERATURE_0 = 4672,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_TEMPERATURE_1 = 4673,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_COUNTER_0 = 4674,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_COUNTER_1 = 4675,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_READ_ERROR_COUNTER_0 = 4676,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_READ_ERROR_COUNTER_1 = 4677,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_SERIAL_NO_0 = 4678,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_SERIAL_NO_1 = 4679,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_NO = 4680,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_STATUS_0 = 4681,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_STATUS_1 = 4682,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_5_ACTIVE = 4683,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_GYRO_X_0 = 4684,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_GYRO_X_1 = 4685,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_GYRO_X_2 = 4686,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_GYRO_X_3 = 4687,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_GYRO_Y_0 = 4688,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_GYRO_Y_1 = 4689,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_GYRO_Y_2 = 4690,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_GYRO_Y_3 = 4691,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_GYRO_Z_0 = 4692,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_GYRO_Z_1 = 4693,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_GYRO_Z_2 = 4694,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_GYRO_Z_3 = 4695,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_ACC_X_0 = 4696,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_ACC_X_1 = 4697,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_ACC_X_2 = 4698,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_ACC_X_3 = 4699,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_ACC_Y_0 = 4700,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_ACC_Y_1 = 4701,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_ACC_Y_2 = 4702,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_ACC_Y_3 = 4703,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_ACC_Z_0 = 4704,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_ACC_Z_1 = 4705,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_ACC_Z_2 = 4706,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_ACC_Z_3 = 4707,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_TEMPERATURE_0 = 4708,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_TEMPERATURE_1 = 4709,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_COUNTER_0 = 4710,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_COUNTER_1 = 4711,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_READ_ERROR_COUNTER_0 = 4712,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_READ_ERROR_COUNTER_1 = 4713,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_SERIAL_NO_0 = 4714,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_SERIAL_NO_1 = 4715,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_NO = 4716,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_STATUS_0 = 4717,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_STATUS_1 = 4718,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_6_ACTIVE = 4719,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_GYRO_X_0 = 4720,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_GYRO_X_1 = 4721,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_GYRO_X_2 = 4722,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_GYRO_X_3 = 4723,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_GYRO_Y_0 = 4724,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_GYRO_Y_1 = 4725,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_GYRO_Y_2 = 4726,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_GYRO_Y_3 = 4727,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_GYRO_Z_0 = 4728,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_GYRO_Z_1 = 4729,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_GYRO_Z_2 = 4730,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_GYRO_Z_3 = 4731,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_ACC_X_0 = 4732,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_ACC_X_1 = 4733,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_ACC_X_2 = 4734,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_ACC_X_3 = 4735,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_ACC_Y_0 = 4736,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_ACC_Y_1 = 4737,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_ACC_Y_2 = 4738,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_ACC_Y_3 = 4739,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_ACC_Z_0 = 4740,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_ACC_Z_1 = 4741,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_ACC_Z_2 = 4742,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_ACC_Z_3 = 4743,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_TEMPERATURE_0 = 4744,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_TEMPERATURE_1 = 4745,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_COUNTER_0 = 4746,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_COUNTER_1 = 4747,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_READ_ERROR_COUNTER_0 = 4748,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_READ_ERROR_COUNTER_1 = 4749,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_SERIAL_NO_0 = 4750,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_SERIAL_NO_1 = 4751,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_NO = 4752,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_STATUS_0 = 4753,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_STATUS_1 = 4754,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_7_ACTIVE = 4755,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_GYRO_X_0 = 4756,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_GYRO_X_1 = 4757,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_GYRO_X_2 = 4758,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_GYRO_X_3 = 4759,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_GYRO_Y_0 = 4760,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_GYRO_Y_1 = 4761,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_GYRO_Y_2 = 4762,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_GYRO_Y_3 = 4763,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_GYRO_Z_0 = 4764,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_GYRO_Z_1 = 4765,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_GYRO_Z_2 = 4766,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_GYRO_Z_3 = 4767,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_ACC_X_0 = 4768,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_ACC_X_1 = 4769,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_ACC_X_2 = 4770,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_ACC_X_3 = 4771,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_ACC_Y_0 = 4772,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_ACC_Y_1 = 4773,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_ACC_Y_2 = 4774,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_ACC_Y_3 = 4775,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_ACC_Z_0 = 4776,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_ACC_Z_1 = 4777,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_ACC_Z_2 = 4778,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_ACC_Z_3 = 4779,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_TEMPERATURE_0 = 4780,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_TEMPERATURE_1 = 4781,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_COUNTER_0 = 4782,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_COUNTER_1 = 4783,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_READ_ERROR_COUNTER_0 = 4784,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_READ_ERROR_COUNTER_1 = 4785,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_SERIAL_NO_0 = 4786,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_SERIAL_NO_1 = 4787,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_NO = 4788,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_STATUS_0 = 4789,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_STATUS_1 = 4790,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_8_ACTIVE = 4791,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_GYRO_X_0 = 4792,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_GYRO_X_1 = 4793,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_GYRO_X_2 = 4794,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_GYRO_X_3 = 4795,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_GYRO_Y_0 = 4796,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_GYRO_Y_1 = 4797,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_GYRO_Y_2 = 4798,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_GYRO_Y_3 = 4799,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_GYRO_Z_0 = 4800,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_GYRO_Z_1 = 4801,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_GYRO_Z_2 = 4802,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_GYRO_Z_3 = 4803,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_ACC_X_0 = 4804,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_ACC_X_1 = 4805,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_ACC_X_2 = 4806,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_ACC_X_3 = 4807,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_ACC_Y_0 = 4808,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_ACC_Y_1 = 4809,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_ACC_Y_2 = 4810,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_ACC_Y_3 = 4811,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_ACC_Z_0 = 4812,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_ACC_Z_1 = 4813,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_ACC_Z_2 = 4814,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_ACC_Z_3 = 4815,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_TEMPERATURE_0 = 4816,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_TEMPERATURE_1 = 4817,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_COUNTER_0 = 4818,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_COUNTER_1 = 4819,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_READ_ERROR_COUNTER_0 = 4820,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_READ_ERROR_COUNTER_1 = 4821,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_SERIAL_NO_0 = 4822,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_SERIAL_NO_1 = 4823,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_NO = 4824,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_STATUS_0 = 4825,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_STATUS_1 = 4826,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_DATA_9_ACTIVE = 4827,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_IMU_QTY = 4828,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_EXTERNAL_IMU_VALID = 4829,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_EXTERNAL_IMU_NEW_DATA_FLAG = 4830,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_EXTERNAL_IMU_FREQ_HZ_0 = 4831,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_EXTERNAL_IMU_FREQ_HZ_1 = 4832,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_EXTERNAL_IMU_FREQ_ERROR_COUNTER_0 = 4833,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_DATA_EXTERNAL_IMU_FREQ_ERROR_COUNTER_1 = 4834,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_SETTING_EXTERNAL_IMU_NOMINAL_FREQ_HZ_0 = 4835,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_SETTING_EXTERNAL_IMU_NOMINAL_FREQ_HZ_1 = 4836,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_SETTING_EXTERNAL_IMU_FREQ_MAX_ALLOWED_JITTER_HZ_0 = 4837,
            PARAMETER_MB_ADDR_EXTERNAL_IMU_SETTING_EXTERNAL_IMU_FREQ_MAX_ALLOWED_JITTER_HZ_1 = 4838,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_0_X_0 = 4839,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_0_X_1 = 4840,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_0_X_2 = 4841,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_0_X_3 = 4842,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_0_Y_0 = 4843,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_0_Y_1 = 4844,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_0_Y_2 = 4845,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_0_Y_3 = 4846,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_0_Z_0 = 4847,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_0_Z_1 = 4848,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_0_Z_2 = 4849,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_0_Z_3 = 4850,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_1_X_0 = 4851,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_1_X_1 = 4852,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_1_X_2 = 4853,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_1_X_3 = 4854,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_1_Y_0 = 4855,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_1_Y_1 = 4856,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_1_Y_2 = 4857,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_1_Y_3 = 4858,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_1_Z_0 = 4859,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_1_Z_1 = 4860,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_1_Z_2 = 4861,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_1_Z_3 = 4862,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_0_X_0 = 4863,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_0_X_1 = 4864,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_0_X_2 = 4865,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_0_X_3 = 4866,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_0_Y_0 = 4867,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_0_Y_1 = 4868,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_0_Y_2 = 4869,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_0_Y_3 = 4870,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_0_Z_0 = 4871,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_0_Z_1 = 4872,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_0_Z_2 = 4873,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_0_Z_3 = 4874,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_1_X_0 = 4875,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_1_X_1 = 4876,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_1_X_2 = 4877,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_1_X_3 = 4878,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_1_Y_0 = 4879,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_1_Y_1 = 4880,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_1_Y_2 = 4881,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_1_Y_3 = 4882,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_1_Z_0 = 4883,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_1_Z_1 = 4884,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_1_Z_2 = 4885,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_1_Z_3 = 4886,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_0_X_0 = 4887,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_0_X_1 = 4888,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_0_X_2 = 4889,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_0_X_3 = 4890,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_0_Y_0 = 4891,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_0_Y_1 = 4892,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_0_Y_2 = 4893,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_0_Y_3 = 4894,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_0_Z_0 = 4895,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_0_Z_1 = 4896,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_0_Z_2 = 4897,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_0_Z_3 = 4898,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_1_X_0 = 4899,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_1_X_1 = 4900,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_1_X_2 = 4901,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_1_X_3 = 4902,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_1_Y_0 = 4903,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_1_Y_1 = 4904,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_1_Y_2 = 4905,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_1_Y_3 = 4906,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_1_Z_0 = 4907,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_1_Z_1 = 4908,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_1_Z_2 = 4909,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_1_Z_3 = 4910,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_I16_0_X = 4911,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_I16_0_Y = 4912,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_I16_0_Z = 4913,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_I16_1_X = 4914,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_I16_1_Y = 4915,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_RATE_I16_1_Z = 4916,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_0_X_0 = 4917,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_0_X_1 = 4918,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_0_X_2 = 4919,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_0_X_3 = 4920,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_0_Y_0 = 4921,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_0_Y_1 = 4922,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_0_Y_2 = 4923,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_0_Y_3 = 4924,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_0_Z_0 = 4925,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_0_Z_1 = 4926,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_0_Z_2 = 4927,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_0_Z_3 = 4928,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_1_X_0 = 4929,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_1_X_1 = 4930,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_1_X_2 = 4931,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_1_X_3 = 4932,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_1_Y_0 = 4933,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_1_Y_1 = 4934,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_1_Y_2 = 4935,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_1_Y_3 = 4936,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_1_Z_0 = 4937,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_1_Z_1 = 4938,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_1_Z_2 = 4939,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_1_Z_3 = 4940,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_0_X_0 = 4941,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_0_X_1 = 4942,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_0_X_2 = 4943,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_0_X_3 = 4944,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_0_Y_0 = 4945,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_0_Y_1 = 4946,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_0_Y_2 = 4947,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_0_Y_3 = 4948,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_0_Z_0 = 4949,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_0_Z_1 = 4950,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_0_Z_2 = 4951,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_0_Z_3 = 4952,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_1_X_0 = 4953,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_1_X_1 = 4954,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_1_X_2 = 4955,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_1_X_3 = 4956,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_1_Y_0 = 4957,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_1_Y_1 = 4958,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_1_Y_2 = 4959,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_1_Y_3 = 4960,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_1_Z_0 = 4961,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_1_Z_1 = 4962,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_1_Z_2 = 4963,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_1_Z_3 = 4964,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_0_X_0 = 4965,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_0_X_1 = 4966,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_0_X_2 = 4967,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_0_X_3 = 4968,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_0_Y_0 = 4969,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_0_Y_1 = 4970,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_0_Y_2 = 4971,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_0_Y_3 = 4972,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_0_Z_0 = 4973,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_0_Z_1 = 4974,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_0_Z_2 = 4975,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_0_Z_3 = 4976,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_1_X_0 = 4977,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_1_X_1 = 4978,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_1_X_2 = 4979,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_1_X_3 = 4980,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_1_Y_0 = 4981,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_1_Y_1 = 4982,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_1_Y_2 = 4983,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_1_Y_3 = 4984,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_1_Z_0 = 4985,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_1_Z_1 = 4986,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_1_Z_2 = 4987,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_1_Z_3 = 4988,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_I16_0_X = 4989,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_I16_0_Y = 4990,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_I16_0_Z = 4991,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_I16_1_X = 4992,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_I16_1_Y = 4993,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_RATE_I16_1_Z = 4994,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_I32_0_X_0 = 4995,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_I32_0_X_1 = 4996,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_I32_0_Y_0 = 4997,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_I32_0_Y_1 = 4998,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_I32_0_Z_0 = 4999,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_I32_0_Z_1 = 5000,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_I32_1_X_0 = 5001,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_I32_1_X_1 = 5002,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_I32_1_Y_0 = 5003,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_I32_1_Y_1 = 5004,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_I32_1_Z_0 = 5005,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_I32_1_Z_1 = 5006,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_I16_0_X = 5007,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_I16_0_Y = 5008,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_I16_0_Z = 5009,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_I16_1_X = 5010,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_I16_1_Y = 5011,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_GYRO_TEMPERATURE_I16_1_Z = 5012,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_I32_0_X_0 = 5013,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_I32_0_X_1 = 5014,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_I32_0_Y_0 = 5015,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_I32_0_Y_1 = 5016,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_I32_0_Z_0 = 5017,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_I32_0_Z_1 = 5018,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_I32_1_X_0 = 5019,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_I32_1_X_1 = 5020,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_I32_1_Y_0 = 5021,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_I32_1_Y_1 = 5022,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_I32_1_Z_0 = 5023,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_I32_1_Z_1 = 5024,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_I16_0_X = 5025,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_I16_0_Y = 5026,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_I16_0_Z = 5027,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_I16_1_X = 5028,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_I16_1_Y = 5029,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_ACC_TEMPERATURE_I16_1_Z = 5030,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_CHIP_ACTIVE_0 = 5031,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_CHIP_ACTIVE_1 = 5032,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_CALC_STATUS_0 = 5033,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_CALC_STATUS_1 = 5034,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_STATUS_0 = 5035,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_STATUS_1 = 5036,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_STATUS_2 = 5037,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_SENSOR_STATUS_3 = 5038,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_COUNTER_0 = 5039,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_COUNTER_1 = 5040,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_GENERAL_STATUS_SUMMARY_0 = 5041,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_GENERAL_STATUS_SUMMARY_1 = 5042,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_FRAME_ERROR_COUNTER_0 = 5043,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_FRAME_ERROR_COUNTER_1 = 5044,
            PARAMETER_MB_ADDR_MAIN_MCU_DATA_FRAME_ERROR_STATUS = 5045,
            PARAMETER_MB_ADDR_MAIN_MCU_FRAME_SEQUENCE_ERROR_0 = 5046,
            PARAMETER_MB_ADDR_MAIN_MCU_FRAME_SEQUENCE_ERROR_1 = 5047,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_US_0 = 5048,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_US_1 = 5049,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_MAXIMA_US_0 = 5050,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_MAXIMA_US_1 = 5051,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_MINIMA_US_0 = 5052,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_MINIMA_US_1 = 5053,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_LIMIT_EXCEED_COUNTER_0 = 5054,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_LIMIT_EXCEED_COUNTER_1 = 5055,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_INTERVAL_TIMING_ERROR = 5056,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_EXECUTION_TIME_US_0 = 5057,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_EXECUTION_TIME_US_1 = 5058,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_EXECUTION_TIME_MAXIMA_US_0 = 5059,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_EXECUTION_TIME_MAXIMA_US_1 = 5060,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_EXECUTION_TIME_MINIMA_US_0 = 5061,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_EXECUTION_TIME_MINIMA_US_1 = 5062,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_RUN_COUNTER_0 = 5063,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_RUN_COUNTER_1 = 5064,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_SETTING_INTERVAL_TIME_NOMINAL_US_0 = 5065,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_SETTING_INTERVAL_TIME_NOMINAL_US_1 = 5066,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_SETTING_INTERVAL_TIME_MAX_ALLOWED_JITTER_US_0 = 5067,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_SETTING_INTERVAL_TIME_MAX_ALLOWED_JITTER_US_1 = 5068,
            PARAMETER_MB_ADDR_CALC_VERSION_0 = 5069,
            PARAMETER_MB_ADDR_CALC_VERSION_1 = 5070,
            PARAMETER_MB_ADDR_CALC_STATUS_0 = 5071,
            PARAMETER_MB_ADDR_CALC_STATUS_1 = 5072,
            PARAMETER_MB_ADDR_CALC_COUNTER_0 = 5073,
            PARAMETER_MB_ADDR_CALC_COUNTER_1 = 5074,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_0_0 = 5075,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_0_1 = 5076,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_0_2 = 5077,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_0_3 = 5078,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_1_0 = 5079,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_1_1 = 5080,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_1_2 = 5081,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_1_3 = 5082,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_2_0 = 5083,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_2_1 = 5084,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_2_2 = 5085,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_2_3 = 5086,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_3_0 = 5087,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_3_1 = 5088,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_3_2 = 5089,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_3_3 = 5090,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_4_0 = 5091,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_4_1 = 5092,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_4_2 = 5093,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_4_3 = 5094,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_5_0 = 5095,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_5_1 = 5096,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_5_2 = 5097,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_5_3 = 5098,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_6_0 = 5099,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_6_1 = 5100,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_6_2 = 5101,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_6_3 = 5102,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_7_0 = 5103,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_7_1 = 5104,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_7_2 = 5105,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_7_3 = 5106,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_8_0 = 5107,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_8_1 = 5108,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_8_2 = 5109,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_8_3 = 5110,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_9_0 = 5111,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_9_1 = 5112,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_9_2 = 5113,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_9_3 = 5114,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_10_0 = 5115,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_10_1 = 5116,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_10_2 = 5117,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_10_3 = 5118,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_11_0 = 5119,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_11_1 = 5120,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_11_2 = 5121,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_11_3 = 5122,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_12_0 = 5123,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_12_1 = 5124,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_12_2 = 5125,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_12_3 = 5126,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_13_0 = 5127,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_13_1 = 5128,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_13_2 = 5129,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_13_3 = 5130,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_14_0 = 5131,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_14_1 = 5132,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_14_2 = 5133,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_14_3 = 5134,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_15_0 = 5135,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_15_1 = 5136,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_15_2 = 5137,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_15_3 = 5138,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_16_0 = 5139,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_16_1 = 5140,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_16_2 = 5141,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_16_3 = 5142,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_17_0 = 5143,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_17_1 = 5144,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_17_2 = 5145,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_17_3 = 5146,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_18_0 = 5147,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_18_1 = 5148,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_18_2 = 5149,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_18_3 = 5150,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_19_0 = 5151,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_19_1 = 5152,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_19_2 = 5153,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_19_3 = 5154,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_20_0 = 5155,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_20_1 = 5156,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_20_2 = 5157,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_20_3 = 5158,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_21_0 = 5159,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_21_1 = 5160,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_21_2 = 5161,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_21_3 = 5162,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_22_0 = 5163,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_22_1 = 5164,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_22_2 = 5165,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_22_3 = 5166,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_23_0 = 5167,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_23_1 = 5168,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_23_2 = 5169,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_23_3 = 5170,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_24_0 = 5171,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_24_1 = 5172,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_24_2 = 5173,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_24_3 = 5174,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_25_0 = 5175,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_25_1 = 5176,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_25_2 = 5177,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_25_3 = 5178,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_26_0 = 5179,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_26_1 = 5180,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_26_2 = 5181,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_26_3 = 5182,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_27_0 = 5183,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_27_1 = 5184,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_27_2 = 5185,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_27_3 = 5186,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_28_0 = 5187,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_28_1 = 5188,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_28_2 = 5189,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_28_3 = 5190,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_29_0 = 5191,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_29_1 = 5192,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_29_2 = 5193,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_29_3 = 5194,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_30_0 = 5195,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_30_1 = 5196,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_30_2 = 5197,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_30_3 = 5198,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_31_0 = 5199,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_31_1 = 5200,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_31_2 = 5201,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_31_3 = 5202,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_32_0 = 5203,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_32_1 = 5204,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_32_2 = 5205,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_32_3 = 5206,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_33_0 = 5207,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_33_1 = 5208,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_33_2 = 5209,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_33_3 = 5210,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_34_0 = 5211,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_34_1 = 5212,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_34_2 = 5213,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_34_3 = 5214,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_35_0 = 5215,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_35_1 = 5216,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_35_2 = 5217,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_35_3 = 5218,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_36_0 = 5219,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_36_1 = 5220,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_36_2 = 5221,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_36_3 = 5222,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_37_0 = 5223,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_37_1 = 5224,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_37_2 = 5225,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_37_3 = 5226,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_38_0 = 5227,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_38_1 = 5228,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_38_2 = 5229,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_38_3 = 5230,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_39_0 = 5231,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_39_1 = 5232,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_39_2 = 5233,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_39_3 = 5234,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_40_0 = 5235,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_40_1 = 5236,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_40_2 = 5237,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_40_3 = 5238,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_41_0 = 5239,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_41_1 = 5240,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_41_2 = 5241,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_41_3 = 5242,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_42_0 = 5243,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_42_1 = 5244,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_42_2 = 5245,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_42_3 = 5246,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_43_0 = 5247,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_43_1 = 5248,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_43_2 = 5249,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_43_3 = 5250,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_44_0 = 5251,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_44_1 = 5252,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_44_2 = 5253,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_44_3 = 5254,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_45_0 = 5255,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_45_1 = 5256,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_45_2 = 5257,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_45_3 = 5258,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_46_0 = 5259,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_46_1 = 5260,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_46_2 = 5261,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_46_3 = 5262,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_47_0 = 5263,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_47_1 = 5264,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_47_2 = 5265,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_47_3 = 5266,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_48_0 = 5267,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_48_1 = 5268,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_48_2 = 5269,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_48_3 = 5270,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_49_0 = 5271,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_49_1 = 5272,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_49_2 = 5273,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_49_3 = 5274,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_0_0 = 5275,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_0_1 = 5276,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_1_0 = 5277,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_1_1 = 5278,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_2_0 = 5279,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_2_1 = 5280,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_3_0 = 5281,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_3_1 = 5282,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_4_0 = 5283,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_4_1 = 5284,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_5_0 = 5285,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_5_1 = 5286,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_6_0 = 5287,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_6_1 = 5288,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_7_0 = 5289,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_7_1 = 5290,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_8_0 = 5291,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_8_1 = 5292,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_9_0 = 5293,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_9_1 = 5294,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_10_0 = 5295,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_10_1 = 5296,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_11_0 = 5297,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_11_1 = 5298,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_12_0 = 5299,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_12_1 = 5300,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_13_0 = 5301,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_13_1 = 5302,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_14_0 = 5303,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_14_1 = 5304,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_15_0 = 5305,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_15_1 = 5306,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_16_0 = 5307,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_16_1 = 5308,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_17_0 = 5309,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_17_1 = 5310,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_18_0 = 5311,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_18_1 = 5312,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_19_0 = 5313,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_19_1 = 5314,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_20_0 = 5315,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_20_1 = 5316,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_21_0 = 5317,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_21_1 = 5318,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_22_0 = 5319,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_22_1 = 5320,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_23_0 = 5321,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_23_1 = 5322,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_24_0 = 5323,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_24_1 = 5324,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_25_0 = 5325,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_25_1 = 5326,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_26_0 = 5327,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_26_1 = 5328,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_27_0 = 5329,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_27_1 = 5330,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_28_0 = 5331,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_28_1 = 5332,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_29_0 = 5333,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_29_1 = 5334,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_30_0 = 5335,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_30_1 = 5336,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_31_0 = 5337,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_31_1 = 5338,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_32_0 = 5339,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_32_1 = 5340,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_33_0 = 5341,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_33_1 = 5342,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_34_0 = 5343,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_34_1 = 5344,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_35_0 = 5345,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_35_1 = 5346,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_36_0 = 5347,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_36_1 = 5348,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_37_0 = 5349,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_37_1 = 5350,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_38_0 = 5351,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_38_1 = 5352,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_39_0 = 5353,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_39_1 = 5354,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_40_0 = 5355,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_40_1 = 5356,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_41_0 = 5357,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_41_1 = 5358,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_42_0 = 5359,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_42_1 = 5360,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_43_0 = 5361,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_43_1 = 5362,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_44_0 = 5363,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_44_1 = 5364,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_45_0 = 5365,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_45_1 = 5366,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_46_0 = 5367,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_46_1 = 5368,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_47_0 = 5369,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_47_1 = 5370,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_48_0 = 5371,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_48_1 = 5372,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_49_0 = 5373,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_49_1 = 5374,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_0_0 = 5375,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_0_1 = 5376,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_1_0 = 5377,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_1_1 = 5378,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_2_0 = 5379,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_2_1 = 5380,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_3_0 = 5381,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_3_1 = 5382,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_4_0 = 5383,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_4_1 = 5384,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_5_0 = 5385,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_5_1 = 5386,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_6_0 = 5387,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_6_1 = 5388,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_7_0 = 5389,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_7_1 = 5390,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_8_0 = 5391,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_8_1 = 5392,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_9_0 = 5393,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_9_1 = 5394,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_10_0 = 5395,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_10_1 = 5396,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_11_0 = 5397,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_11_1 = 5398,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_12_0 = 5399,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_12_1 = 5400,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_13_0 = 5401,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_13_1 = 5402,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_14_0 = 5403,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_14_1 = 5404,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_15_0 = 5405,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_15_1 = 5406,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_16_0 = 5407,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_16_1 = 5408,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_17_0 = 5409,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_17_1 = 5410,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_18_0 = 5411,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_18_1 = 5412,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_19_0 = 5413,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_19_1 = 5414,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_20_0 = 5415,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_20_1 = 5416,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_21_0 = 5417,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_21_1 = 5418,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_22_0 = 5419,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_22_1 = 5420,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_23_0 = 5421,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_23_1 = 5422,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_24_0 = 5423,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_24_1 = 5424,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_25_0 = 5425,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_25_1 = 5426,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_26_0 = 5427,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_26_1 = 5428,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_27_0 = 5429,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_27_1 = 5430,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_28_0 = 5431,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_28_1 = 5432,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_29_0 = 5433,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_29_1 = 5434,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_30_0 = 5435,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_30_1 = 5436,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_31_0 = 5437,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_31_1 = 5438,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_32_0 = 5439,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_32_1 = 5440,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_33_0 = 5441,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_33_1 = 5442,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_34_0 = 5443,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_34_1 = 5444,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_35_0 = 5445,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_35_1 = 5446,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_36_0 = 5447,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_36_1 = 5448,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_37_0 = 5449,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_37_1 = 5450,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_38_0 = 5451,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_38_1 = 5452,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_39_0 = 5453,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_39_1 = 5454,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_40_0 = 5455,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_40_1 = 5456,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_41_0 = 5457,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_41_1 = 5458,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_42_0 = 5459,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_42_1 = 5460,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_43_0 = 5461,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_43_1 = 5462,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_44_0 = 5463,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_44_1 = 5464,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_45_0 = 5465,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_45_1 = 5466,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_46_0 = 5467,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_46_1 = 5468,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_47_0 = 5469,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_47_1 = 5470,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_48_0 = 5471,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_48_1 = 5472,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_49_0 = 5473,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_49_1 = 5474,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_0_0 = 5475,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_0_1 = 5476,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_1_0 = 5477,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_1_1 = 5478,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_2_0 = 5479,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_2_1 = 5480,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_3_0 = 5481,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_3_1 = 5482,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_4_0 = 5483,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_4_1 = 5484,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_5_0 = 5485,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_5_1 = 5486,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_6_0 = 5487,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_6_1 = 5488,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_7_0 = 5489,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_7_1 = 5490,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_8_0 = 5491,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_8_1 = 5492,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_9_0 = 5493,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_9_1 = 5494,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_10_0 = 5495,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_10_1 = 5496,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_11_0 = 5497,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_11_1 = 5498,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_12_0 = 5499,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_12_1 = 5500,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_13_0 = 5501,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_13_1 = 5502,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_14_0 = 5503,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_14_1 = 5504,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_15_0 = 5505,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_15_1 = 5506,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_16_0 = 5507,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_16_1 = 5508,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_17_0 = 5509,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_17_1 = 5510,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_18_0 = 5511,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_18_1 = 5512,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_19_0 = 5513,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_19_1 = 5514,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_20_0 = 5515,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_20_1 = 5516,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_21_0 = 5517,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_21_1 = 5518,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_22_0 = 5519,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_22_1 = 5520,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_23_0 = 5521,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_23_1 = 5522,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_24_0 = 5523,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_24_1 = 5524,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_25_0 = 5525,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_25_1 = 5526,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_26_0 = 5527,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_26_1 = 5528,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_27_0 = 5529,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_27_1 = 5530,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_28_0 = 5531,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_28_1 = 5532,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_29_0 = 5533,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_29_1 = 5534,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_30_0 = 5535,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_30_1 = 5536,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_31_0 = 5537,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_31_1 = 5538,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_32_0 = 5539,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_32_1 = 5540,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_33_0 = 5541,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_33_1 = 5542,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_34_0 = 5543,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_34_1 = 5544,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_35_0 = 5545,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_35_1 = 5546,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_36_0 = 5547,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_36_1 = 5548,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_37_0 = 5549,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_37_1 = 5550,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_38_0 = 5551,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_38_1 = 5552,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_39_0 = 5553,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_39_1 = 5554,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_40_0 = 5555,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_40_1 = 5556,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_41_0 = 5557,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_41_1 = 5558,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_42_0 = 5559,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_42_1 = 5560,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_43_0 = 5561,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_43_1 = 5562,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_44_0 = 5563,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_44_1 = 5564,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_45_0 = 5565,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_45_1 = 5566,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_46_0 = 5567,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_46_1 = 5568,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_47_0 = 5569,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_47_1 = 5570,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_48_0 = 5571,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_48_1 = 5572,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_49_0 = 5573,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_49_1 = 5574,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_0 = 5575,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_1 = 5576,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_2 = 5577,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_3 = 5578,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_4 = 5579,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_5 = 5580,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_6 = 5581,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_7 = 5582,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_8 = 5583,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_9 = 5584,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_10 = 5585,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_11 = 5586,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_12 = 5587,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_13 = 5588,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_14 = 5589,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_15 = 5590,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_16 = 5591,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_17 = 5592,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_18 = 5593,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_19 = 5594,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_20 = 5595,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_21 = 5596,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_22 = 5597,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_23 = 5598,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_24 = 5599,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_25 = 5600,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_26 = 5601,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_27 = 5602,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_28 = 5603,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_29 = 5604,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_30 = 5605,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_31 = 5606,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_32 = 5607,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_33 = 5608,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_34 = 5609,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_35 = 5610,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_36 = 5611,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_37 = 5612,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_38 = 5613,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_39 = 5614,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_40 = 5615,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_41 = 5616,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_42 = 5617,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_43 = 5618,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_44 = 5619,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_45 = 5620,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_46 = 5621,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_47 = 5622,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_48 = 5623,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_49 = 5624,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_0 = 5625,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_1 = 5626,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_2 = 5627,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_3 = 5628,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_4 = 5629,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_5 = 5630,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_6 = 5631,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_7 = 5632,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_8 = 5633,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_9 = 5634,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_10 = 5635,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_11 = 5636,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_12 = 5637,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_13 = 5638,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_14 = 5639,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_15 = 5640,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_16 = 5641,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_17 = 5642,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_18 = 5643,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_19 = 5644,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_20 = 5645,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_21 = 5646,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_22 = 5647,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_23 = 5648,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_24 = 5649,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_25 = 5650,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_26 = 5651,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_27 = 5652,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_28 = 5653,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_29 = 5654,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_30 = 5655,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_31 = 5656,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_32 = 5657,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_33 = 5658,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_34 = 5659,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_35 = 5660,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_36 = 5661,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_37 = 5662,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_38 = 5663,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_39 = 5664,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_40 = 5665,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_41 = 5666,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_42 = 5667,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_43 = 5668,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_44 = 5669,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_45 = 5670,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_46 = 5671,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_47 = 5672,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_48 = 5673,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_49 = 5674,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_0_0 = 5675,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_0_1 = 5676,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_0_2 = 5677,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_0_3 = 5678,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_1_0 = 5679,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_1_1 = 5680,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_1_2 = 5681,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_1_3 = 5682,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_2_0 = 5683,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_2_1 = 5684,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_2_2 = 5685,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_2_3 = 5686,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_3_0 = 5687,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_3_1 = 5688,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_3_2 = 5689,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_3_3 = 5690,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_4_0 = 5691,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_4_1 = 5692,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_4_2 = 5693,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_4_3 = 5694,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_5_0 = 5695,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_5_1 = 5696,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_5_2 = 5697,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_5_3 = 5698,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_6_0 = 5699,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_6_1 = 5700,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_6_2 = 5701,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_6_3 = 5702,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_7_0 = 5703,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_7_1 = 5704,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_7_2 = 5705,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_7_3 = 5706,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_8_0 = 5707,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_8_1 = 5708,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_8_2 = 5709,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_8_3 = 5710,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_9_0 = 5711,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_9_1 = 5712,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_9_2 = 5713,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_9_3 = 5714,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_10_0 = 5715,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_10_1 = 5716,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_10_2 = 5717,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_10_3 = 5718,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_11_0 = 5719,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_11_1 = 5720,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_11_2 = 5721,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_11_3 = 5722,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_12_0 = 5723,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_12_1 = 5724,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_12_2 = 5725,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_12_3 = 5726,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_13_0 = 5727,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_13_1 = 5728,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_13_2 = 5729,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_13_3 = 5730,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_14_0 = 5731,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_14_1 = 5732,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_14_2 = 5733,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_14_3 = 5734,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_15_0 = 5735,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_15_1 = 5736,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_15_2 = 5737,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_15_3 = 5738,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_16_0 = 5739,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_16_1 = 5740,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_16_2 = 5741,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_16_3 = 5742,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_17_0 = 5743,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_17_1 = 5744,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_17_2 = 5745,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_17_3 = 5746,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_18_0 = 5747,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_18_1 = 5748,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_18_2 = 5749,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_18_3 = 5750,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_19_0 = 5751,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_19_1 = 5752,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_19_2 = 5753,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_19_3 = 5754,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_20_0 = 5755,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_20_1 = 5756,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_20_2 = 5757,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_20_3 = 5758,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_21_0 = 5759,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_21_1 = 5760,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_21_2 = 5761,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_21_3 = 5762,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_22_0 = 5763,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_22_1 = 5764,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_22_2 = 5765,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_22_3 = 5766,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_23_0 = 5767,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_23_1 = 5768,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_23_2 = 5769,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_23_3 = 5770,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_24_0 = 5771,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_24_1 = 5772,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_24_2 = 5773,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_24_3 = 5774,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_25_0 = 5775,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_25_1 = 5776,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_25_2 = 5777,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_25_3 = 5778,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_26_0 = 5779,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_26_1 = 5780,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_26_2 = 5781,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_26_3 = 5782,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_27_0 = 5783,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_27_1 = 5784,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_27_2 = 5785,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_27_3 = 5786,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_28_0 = 5787,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_28_1 = 5788,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_28_2 = 5789,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_28_3 = 5790,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_29_0 = 5791,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_29_1 = 5792,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_29_2 = 5793,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_29_3 = 5794,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_30_0 = 5795,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_30_1 = 5796,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_30_2 = 5797,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_30_3 = 5798,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_31_0 = 5799,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_31_1 = 5800,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_31_2 = 5801,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_31_3 = 5802,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_32_0 = 5803,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_32_1 = 5804,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_32_2 = 5805,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_32_3 = 5806,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_33_0 = 5807,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_33_1 = 5808,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_33_2 = 5809,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_33_3 = 5810,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_34_0 = 5811,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_34_1 = 5812,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_34_2 = 5813,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_34_3 = 5814,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_35_0 = 5815,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_35_1 = 5816,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_35_2 = 5817,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_35_3 = 5818,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_36_0 = 5819,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_36_1 = 5820,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_36_2 = 5821,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_36_3 = 5822,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_37_0 = 5823,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_37_1 = 5824,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_37_2 = 5825,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_37_3 = 5826,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_38_0 = 5827,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_38_1 = 5828,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_38_2 = 5829,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_38_3 = 5830,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_39_0 = 5831,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_39_1 = 5832,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_39_2 = 5833,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_39_3 = 5834,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_40_0 = 5835,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_40_1 = 5836,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_40_2 = 5837,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_40_3 = 5838,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_41_0 = 5839,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_41_1 = 5840,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_41_2 = 5841,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_41_3 = 5842,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_42_0 = 5843,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_42_1 = 5844,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_42_2 = 5845,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_42_3 = 5846,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_43_0 = 5847,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_43_1 = 5848,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_43_2 = 5849,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_43_3 = 5850,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_44_0 = 5851,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_44_1 = 5852,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_44_2 = 5853,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_44_3 = 5854,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_45_0 = 5855,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_45_1 = 5856,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_45_2 = 5857,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_45_3 = 5858,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_46_0 = 5859,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_46_1 = 5860,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_46_2 = 5861,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_46_3 = 5862,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_47_0 = 5863,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_47_1 = 5864,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_47_2 = 5865,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_47_3 = 5866,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_48_0 = 5867,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_48_1 = 5868,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_48_2 = 5869,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_48_3 = 5870,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_49_0 = 5871,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_49_1 = 5872,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_49_2 = 5873,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_49_3 = 5874,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_0_0 = 5875,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_0_1 = 5876,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_1_0 = 5877,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_1_1 = 5878,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_2_0 = 5879,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_2_1 = 5880,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_3_0 = 5881,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_3_1 = 5882,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_4_0 = 5883,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_4_1 = 5884,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_5_0 = 5885,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_5_1 = 5886,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_6_0 = 5887,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_6_1 = 5888,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_7_0 = 5889,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_7_1 = 5890,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_8_0 = 5891,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_8_1 = 5892,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_9_0 = 5893,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_9_1 = 5894,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_10_0 = 5895,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_10_1 = 5896,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_11_0 = 5897,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_11_1 = 5898,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_12_0 = 5899,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_12_1 = 5900,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_13_0 = 5901,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_13_1 = 5902,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_14_0 = 5903,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_14_1 = 5904,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_15_0 = 5905,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_15_1 = 5906,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_16_0 = 5907,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_16_1 = 5908,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_17_0 = 5909,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_17_1 = 5910,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_18_0 = 5911,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_18_1 = 5912,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_19_0 = 5913,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_19_1 = 5914,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_20_0 = 5915,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_20_1 = 5916,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_21_0 = 5917,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_21_1 = 5918,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_22_0 = 5919,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_22_1 = 5920,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_23_0 = 5921,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_23_1 = 5922,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_24_0 = 5923,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_24_1 = 5924,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_25_0 = 5925,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_25_1 = 5926,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_26_0 = 5927,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_26_1 = 5928,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_27_0 = 5929,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_27_1 = 5930,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_28_0 = 5931,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_28_1 = 5932,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_29_0 = 5933,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_29_1 = 5934,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_30_0 = 5935,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_30_1 = 5936,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_31_0 = 5937,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_31_1 = 5938,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_32_0 = 5939,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_32_1 = 5940,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_33_0 = 5941,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_33_1 = 5942,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_34_0 = 5943,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_34_1 = 5944,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_35_0 = 5945,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_35_1 = 5946,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_36_0 = 5947,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_36_1 = 5948,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_37_0 = 5949,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_37_1 = 5950,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_38_0 = 5951,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_38_1 = 5952,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_39_0 = 5953,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_39_1 = 5954,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_40_0 = 5955,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_40_1 = 5956,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_41_0 = 5957,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_41_1 = 5958,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_42_0 = 5959,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_42_1 = 5960,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_43_0 = 5961,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_43_1 = 5962,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_44_0 = 5963,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_44_1 = 5964,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_45_0 = 5965,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_45_1 = 5966,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_46_0 = 5967,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_46_1 = 5968,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_47_0 = 5969,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_47_1 = 5970,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_48_0 = 5971,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_48_1 = 5972,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_49_0 = 5973,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_49_1 = 5974,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_0_0 = 5975,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_0_1 = 5976,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_1_0 = 5977,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_1_1 = 5978,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_2_0 = 5979,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_2_1 = 5980,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_3_0 = 5981,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_3_1 = 5982,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_4_0 = 5983,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_4_1 = 5984,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_5_0 = 5985,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_5_1 = 5986,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_6_0 = 5987,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_6_1 = 5988,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_7_0 = 5989,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_7_1 = 5990,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_8_0 = 5991,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_8_1 = 5992,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_9_0 = 5993,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_9_1 = 5994,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_10_0 = 5995,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_10_1 = 5996,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_11_0 = 5997,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_11_1 = 5998,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_12_0 = 5999,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_12_1 = 6000,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_13_0 = 6001,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_13_1 = 6002,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_14_0 = 6003,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_14_1 = 6004,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_15_0 = 6005,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_15_1 = 6006,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_16_0 = 6007,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_16_1 = 6008,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_17_0 = 6009,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_17_1 = 6010,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_18_0 = 6011,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_18_1 = 6012,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_19_0 = 6013,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_19_1 = 6014,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_20_0 = 6015,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_20_1 = 6016,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_21_0 = 6017,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_21_1 = 6018,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_22_0 = 6019,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_22_1 = 6020,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_23_0 = 6021,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_23_1 = 6022,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_24_0 = 6023,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_24_1 = 6024,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_25_0 = 6025,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_25_1 = 6026,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_26_0 = 6027,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_26_1 = 6028,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_27_0 = 6029,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_27_1 = 6030,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_28_0 = 6031,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_28_1 = 6032,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_29_0 = 6033,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_29_1 = 6034,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_30_0 = 6035,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_30_1 = 6036,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_31_0 = 6037,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_31_1 = 6038,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_32_0 = 6039,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_32_1 = 6040,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_33_0 = 6041,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_33_1 = 6042,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_34_0 = 6043,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_34_1 = 6044,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_35_0 = 6045,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_35_1 = 6046,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_36_0 = 6047,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_36_1 = 6048,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_37_0 = 6049,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_37_1 = 6050,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_38_0 = 6051,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_38_1 = 6052,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_39_0 = 6053,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_39_1 = 6054,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_40_0 = 6055,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_40_1 = 6056,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_41_0 = 6057,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_41_1 = 6058,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_42_0 = 6059,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_42_1 = 6060,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_43_0 = 6061,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_43_1 = 6062,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_44_0 = 6063,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_44_1 = 6064,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_45_0 = 6065,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_45_1 = 6066,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_46_0 = 6067,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_46_1 = 6068,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_47_0 = 6069,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_47_1 = 6070,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_48_0 = 6071,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_48_1 = 6072,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_49_0 = 6073,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_49_1 = 6074,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_0_0 = 6075,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_0_1 = 6076,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_1_0 = 6077,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_1_1 = 6078,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_2_0 = 6079,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_2_1 = 6080,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_3_0 = 6081,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_3_1 = 6082,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_4_0 = 6083,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_4_1 = 6084,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_5_0 = 6085,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_5_1 = 6086,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_6_0 = 6087,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_6_1 = 6088,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_7_0 = 6089,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_7_1 = 6090,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_8_0 = 6091,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_8_1 = 6092,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_9_0 = 6093,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_9_1 = 6094,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_10_0 = 6095,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_10_1 = 6096,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_11_0 = 6097,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_11_1 = 6098,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_12_0 = 6099,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_12_1 = 6100,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_13_0 = 6101,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_13_1 = 6102,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_14_0 = 6103,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_14_1 = 6104,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_15_0 = 6105,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_15_1 = 6106,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_16_0 = 6107,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_16_1 = 6108,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_17_0 = 6109,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_17_1 = 6110,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_18_0 = 6111,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_18_1 = 6112,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_19_0 = 6113,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_19_1 = 6114,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_20_0 = 6115,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_20_1 = 6116,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_21_0 = 6117,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_21_1 = 6118,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_22_0 = 6119,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_22_1 = 6120,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_23_0 = 6121,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_23_1 = 6122,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_24_0 = 6123,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_24_1 = 6124,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_25_0 = 6125,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_25_1 = 6126,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_26_0 = 6127,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_26_1 = 6128,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_27_0 = 6129,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_27_1 = 6130,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_28_0 = 6131,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_28_1 = 6132,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_29_0 = 6133,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_29_1 = 6134,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_30_0 = 6135,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_30_1 = 6136,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_31_0 = 6137,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_31_1 = 6138,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_32_0 = 6139,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_32_1 = 6140,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_33_0 = 6141,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_33_1 = 6142,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_34_0 = 6143,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_34_1 = 6144,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_35_0 = 6145,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_35_1 = 6146,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_36_0 = 6147,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_36_1 = 6148,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_37_0 = 6149,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_37_1 = 6150,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_38_0 = 6151,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_38_1 = 6152,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_39_0 = 6153,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_39_1 = 6154,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_40_0 = 6155,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_40_1 = 6156,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_41_0 = 6157,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_41_1 = 6158,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_42_0 = 6159,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_42_1 = 6160,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_43_0 = 6161,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_43_1 = 6162,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_44_0 = 6163,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_44_1 = 6164,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_45_0 = 6165,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_45_1 = 6166,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_46_0 = 6167,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_46_1 = 6168,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_47_0 = 6169,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_47_1 = 6170,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_48_0 = 6171,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_48_1 = 6172,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_49_0 = 6173,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_49_1 = 6174,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_0 = 6175,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_1 = 6176,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_2 = 6177,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_3 = 6178,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_4 = 6179,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_5 = 6180,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_6 = 6181,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_7 = 6182,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_8 = 6183,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_9 = 6184,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_10 = 6185,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_11 = 6186,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_12 = 6187,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_13 = 6188,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_14 = 6189,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_15 = 6190,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_16 = 6191,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_17 = 6192,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_18 = 6193,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_19 = 6194,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_20 = 6195,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_21 = 6196,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_22 = 6197,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_23 = 6198,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_24 = 6199,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_25 = 6200,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_26 = 6201,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_27 = 6202,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_28 = 6203,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_29 = 6204,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_30 = 6205,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_31 = 6206,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_32 = 6207,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_33 = 6208,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_34 = 6209,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_35 = 6210,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_36 = 6211,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_37 = 6212,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_38 = 6213,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_39 = 6214,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_40 = 6215,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_41 = 6216,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_42 = 6217,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_43 = 6218,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_44 = 6219,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_45 = 6220,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_46 = 6221,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_47 = 6222,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_48 = 6223,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_49 = 6224,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_0 = 6225,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_1 = 6226,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_2 = 6227,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_3 = 6228,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_4 = 6229,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_5 = 6230,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_6 = 6231,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_7 = 6232,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_8 = 6233,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_9 = 6234,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_10 = 6235,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_11 = 6236,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_12 = 6237,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_13 = 6238,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_14 = 6239,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_15 = 6240,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_16 = 6241,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_17 = 6242,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_18 = 6243,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_19 = 6244,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_20 = 6245,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_21 = 6246,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_22 = 6247,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_23 = 6248,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_24 = 6249,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_25 = 6250,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_26 = 6251,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_27 = 6252,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_28 = 6253,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_29 = 6254,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_30 = 6255,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_31 = 6256,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_32 = 6257,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_33 = 6258,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_34 = 6259,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_35 = 6260,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_36 = 6261,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_37 = 6262,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_38 = 6263,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_39 = 6264,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_40 = 6265,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_41 = 6266,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_42 = 6267,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_43 = 6268,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_44 = 6269,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_45 = 6270,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_46 = 6271,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_47 = 6272,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_48 = 6273,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I16_49 = 6274,
            PARAMETER_MB_ADDR_OUTPUT_STABILIZATION_CYCLE_QTY = 6275,
            PARAMETER_MB_ADDR_RAW_DATA_STABILIZATION_CYCLE_QTY = 6276,
            PARAMETER_MB_ADDR_RUN_TIME_S_0 = 6277,
            PARAMETER_MB_ADDR_RUN_TIME_S_1 = 6278,
            PARAMETER_MB_ADDR_NORTH_FINDING1_EULER_ANGLE_0_0 = 6279,
            PARAMETER_MB_ADDR_NORTH_FINDING1_EULER_ANGLE_0_1 = 6280,
            PARAMETER_MB_ADDR_NORTH_FINDING1_EULER_ANGLE_0_2 = 6281,
            PARAMETER_MB_ADDR_NORTH_FINDING1_EULER_ANGLE_0_3 = 6282,
            PARAMETER_MB_ADDR_NORTH_FINDING1_EULER_ANGLE_1_0 = 6283,
            PARAMETER_MB_ADDR_NORTH_FINDING1_EULER_ANGLE_1_1 = 6284,
            PARAMETER_MB_ADDR_NORTH_FINDING1_EULER_ANGLE_1_2 = 6285,
            PARAMETER_MB_ADDR_NORTH_FINDING1_EULER_ANGLE_1_3 = 6286,
            PARAMETER_MB_ADDR_NORTH_FINDING1_EULER_ANGLE_2_0 = 6287,
            PARAMETER_MB_ADDR_NORTH_FINDING1_EULER_ANGLE_2_1 = 6288,
            PARAMETER_MB_ADDR_NORTH_FINDING1_EULER_ANGLE_2_2 = 6289,
            PARAMETER_MB_ADDR_NORTH_FINDING1_EULER_ANGLE_2_3 = 6290,
            PARAMETER_MB_ADDR_NORTH_FINDING1_EULER_ANGLE_I32_0_0 = 6291,
            PARAMETER_MB_ADDR_NORTH_FINDING1_EULER_ANGLE_I32_0_1 = 6292,
            PARAMETER_MB_ADDR_NORTH_FINDING1_EULER_ANGLE_I32_1_0 = 6293,
            PARAMETER_MB_ADDR_NORTH_FINDING1_EULER_ANGLE_I32_1_1 = 6294,
            PARAMETER_MB_ADDR_NORTH_FINDING1_EULER_ANGLE_I32_2_0 = 6295,
            PARAMETER_MB_ADDR_NORTH_FINDING1_EULER_ANGLE_I32_2_1 = 6296,
            PARAMETER_MB_ADDR_NORTH_FINDING1_EULER_ANGLE_I32_RANGE_0 = 6297,
            PARAMETER_MB_ADDR_NORTH_FINDING1_EULER_ANGLE_I32_RANGE_1 = 6298,
            PARAMETER_MB_ADDR_NORTH_FINDING1_EULER_ANGLE_I32_RANGE_2 = 6299,
            PARAMETER_MB_ADDR_NORTH_FINDING1_EULER_ANGLE_I32_RANGE_3 = 6300,
            PARAMETER_MB_ADDR_NORTH_FINDING1_MODE = 6301,
            PARAMETER_MB_ADDR_NORTH_FINDING1_STATUS_0 = 6302,
            PARAMETER_MB_ADDR_NORTH_FINDING1_STATUS_1 = 6303,
            PARAMETER_MB_ADDR_NORTH_FINDING1_VERSION_0 = 6304,
            PARAMETER_MB_ADDR_NORTH_FINDING1_VERSION_1 = 6305,
            PARAMETER_MB_ADDR_NORTH_FINDING1_COUNTER_0 = 6306,
            PARAMETER_MB_ADDR_NORTH_FINDING1_COUNTER_1 = 6307,
            PARAMETER_MB_ADDR_NORTH_FINDING1_TYPE = 6308,
            PARAMETER_MB_ADDR_NORTH_FINDING1_GYRO_NUMBER = 6309,
            PARAMETER_MB_ADDR_NORTH_FINDING1_ACC_NUMBER = 6310,
            PARAMETER_MB_ADDR_NORTH_FINDING1_LLA_0_0 = 6311,
            PARAMETER_MB_ADDR_NORTH_FINDING1_LLA_0_1 = 6312,
            PARAMETER_MB_ADDR_NORTH_FINDING1_LLA_0_2 = 6313,
            PARAMETER_MB_ADDR_NORTH_FINDING1_LLA_0_3 = 6314,
            PARAMETER_MB_ADDR_NORTH_FINDING1_LLA_1_0 = 6315,
            PARAMETER_MB_ADDR_NORTH_FINDING1_LLA_1_1 = 6316,
            PARAMETER_MB_ADDR_NORTH_FINDING1_LLA_1_2 = 6317,
            PARAMETER_MB_ADDR_NORTH_FINDING1_LLA_1_3 = 6318,
            PARAMETER_MB_ADDR_NORTH_FINDING1_LLA_2_0 = 6319,
            PARAMETER_MB_ADDR_NORTH_FINDING1_LLA_2_1 = 6320,
            PARAMETER_MB_ADDR_NORTH_FINDING1_LLA_2_2 = 6321,
            PARAMETER_MB_ADDR_NORTH_FINDING1_LLA_2_3 = 6322,
            PARAMETER_MB_ADDR_NORTH_FINDING1_RESET_CMD = 6323,
            PARAMETER_MB_ADDR_NORTH_FINDING1_TIME_S_0 = 6324,
            PARAMETER_MB_ADDR_NORTH_FINDING1_TIME_S_1 = 6325,
            PARAMETER_MB_ADDR_NORTH_FINDING1_LIMIT_ACC_UG_0 = 6326,
            PARAMETER_MB_ADDR_NORTH_FINDING1_LIMIT_ACC_UG_1 = 6327,
            PARAMETER_MB_ADDR_NORTH_FINDING1_LIMIT_ACC_UG_2 = 6328,
            PARAMETER_MB_ADDR_NORTH_FINDING1_LIMIT_ACC_UG_3 = 6329,
            PARAMETER_MB_ADDR_NORTH_FINDING1_LIMIT_GYR_DPH_0 = 6330,
            PARAMETER_MB_ADDR_NORTH_FINDING1_LIMIT_GYR_DPH_1 = 6331,
            PARAMETER_MB_ADDR_NORTH_FINDING1_LIMIT_GYR_DPH_2 = 6332,
            PARAMETER_MB_ADDR_NORTH_FINDING1_LIMIT_GYR_DPH_3 = 6333,
            PARAMETER_MB_ADDR_NORTH_FINDING1_MAX_QUEST_COUNTER_0 = 6334,
            PARAMETER_MB_ADDR_NORTH_FINDING1_MAX_QUEST_COUNTER_1 = 6335,
            PARAMETER_MB_ADDR_NORTH_FINDING1_MAX_QUEST_COUNTER_2 = 6336,
            PARAMETER_MB_ADDR_NORTH_FINDING1_MAX_QUEST_COUNTER_3 = 6337,
            PARAMETER_MB_ADDR_NORTH_FINDING1_RESET_QUEST_COUNTER_0 = 6338,
            PARAMETER_MB_ADDR_NORTH_FINDING1_RESET_QUEST_COUNTER_1 = 6339,
            PARAMETER_MB_ADDR_NORTH_FINDING1_RESET_QUEST_COUNTER_2 = 6340,
            PARAMETER_MB_ADDR_NORTH_FINDING1_RESET_QUEST_COUNTER_3 = 6341,
            PARAMETER_MB_ADDR_NORTH_FINDING1_ZVDCONFIG_THRESHOLD_0 = 6342,
            PARAMETER_MB_ADDR_NORTH_FINDING1_ZVDCONFIG_THRESHOLD_1 = 6343,
            PARAMETER_MB_ADDR_NORTH_FINDING1_ZVDCONFIG_THRESHOLD_2 = 6344,
            PARAMETER_MB_ADDR_NORTH_FINDING1_ZVDCONFIG_THRESHOLD_3 = 6345,
            PARAMETER_MB_ADDR_NORTH_FINDING1_ZVDCONFIG_TIME_THRESHOLD_0 = 6346,
            PARAMETER_MB_ADDR_NORTH_FINDING1_ZVDCONFIG_TIME_THRESHOLD_1 = 6347,
            PARAMETER_MB_ADDR_NORTH_FINDING1_ZVDCONFIG_TIME_THRESHOLD_2 = 6348,
            PARAMETER_MB_ADDR_NORTH_FINDING1_ZVDCONFIG_TIME_THRESHOLD_3 = 6349,
            PARAMETER_MB_ADDR_NORTH_FINDING1_INITIAL_NORTH_FINDING_TIME_0 = 6350,
            PARAMETER_MB_ADDR_NORTH_FINDING1_INITIAL_NORTH_FINDING_TIME_1 = 6351,
            PARAMETER_MB_ADDR_NORTH_FINDING1_INITIAL_NORTH_FINDING_TIME_2 = 6352,
            PARAMETER_MB_ADDR_NORTH_FINDING1_INITIAL_NORTH_FINDING_TIME_3 = 6353,
            PARAMETER_MB_ADDR_NORTH_FINDING1_DURING_NORTH_FINDING_TIME_0 = 6354,
            PARAMETER_MB_ADDR_NORTH_FINDING1_DURING_NORTH_FINDING_TIME_1 = 6355,
            PARAMETER_MB_ADDR_NORTH_FINDING1_DURING_NORTH_FINDING_TIME_2 = 6356,
            PARAMETER_MB_ADDR_NORTH_FINDING1_DURING_NORTH_FINDING_TIME_3 = 6357,
            PARAMETER_MB_ADDR_NORTH_FINDING1_IDLE_TIME_0 = 6358,
            PARAMETER_MB_ADDR_NORTH_FINDING1_IDLE_TIME_1 = 6359,
            PARAMETER_MB_ADDR_NORTH_FINDING1_IDLE_TIME_2 = 6360,
            PARAMETER_MB_ADDR_NORTH_FINDING1_IDLE_TIME_3 = 6361,
            PARAMETER_MB_ADDR_NORTH_FINDING1_ALIGN_TIME_S_0 = 6362,
            PARAMETER_MB_ADDR_NORTH_FINDING1_ALIGN_TIME_S_1 = 6363,
            PARAMETER_MB_ADDR_NORTH_FINDING1_ALIGN_TIME_S_2 = 6364,
            PARAMETER_MB_ADDR_NORTH_FINDING1_ALIGN_TIME_S_3 = 6365,
            PARAMETER_MB_ADDR_OUTPUT_DECIMATION_RATE = 6366,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_0_IMU_EULER_ANGLE_0_0 = 6367,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_0_IMU_EULER_ANGLE_0_1 = 6368,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_0_IMU_EULER_ANGLE_0_2 = 6369,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_0_IMU_EULER_ANGLE_0_3 = 6370,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_0_IMU_EULER_ANGLE_1_0 = 6371,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_0_IMU_EULER_ANGLE_1_1 = 6372,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_0_IMU_EULER_ANGLE_1_2 = 6373,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_0_IMU_EULER_ANGLE_1_3 = 6374,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_0_IMU_EULER_ANGLE_2_0 = 6375,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_0_IMU_EULER_ANGLE_2_1 = 6376,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_0_IMU_EULER_ANGLE_2_2 = 6377,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_0_IMU_EULER_ANGLE_2_3 = 6378,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_0_IMU_DELTA_ANGLE_0_0 = 6379,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_0_IMU_DELTA_ANGLE_0_1 = 6380,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_0_IMU_DELTA_ANGLE_0_2 = 6381,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_0_IMU_DELTA_ANGLE_0_3 = 6382,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_0_IMU_DELTA_ANGLE_1_0 = 6383,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_0_IMU_DELTA_ANGLE_1_1 = 6384,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_0_IMU_DELTA_ANGLE_1_2 = 6385,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_0_IMU_DELTA_ANGLE_1_3 = 6386,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_0_IMU_DELTA_ANGLE_2_0 = 6387,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_0_IMU_DELTA_ANGLE_2_1 = 6388,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_0_IMU_DELTA_ANGLE_2_2 = 6389,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_0_IMU_DELTA_ANGLE_2_3 = 6390,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_0_MODE = 6391,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_0_STATUS_0 = 6392,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_0_STATUS_1 = 6393,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_0_VERSION_0 = 6394,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_0_VERSION_1 = 6395,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_0_COUNTER_0 = 6396,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_0_COUNTER_1 = 6397,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_1_IMU_EULER_ANGLE_0_0 = 6398,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_1_IMU_EULER_ANGLE_0_1 = 6399,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_1_IMU_EULER_ANGLE_0_2 = 6400,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_1_IMU_EULER_ANGLE_0_3 = 6401,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_1_IMU_EULER_ANGLE_1_0 = 6402,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_1_IMU_EULER_ANGLE_1_1 = 6403,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_1_IMU_EULER_ANGLE_1_2 = 6404,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_1_IMU_EULER_ANGLE_1_3 = 6405,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_1_IMU_EULER_ANGLE_2_0 = 6406,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_1_IMU_EULER_ANGLE_2_1 = 6407,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_1_IMU_EULER_ANGLE_2_2 = 6408,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_1_IMU_EULER_ANGLE_2_3 = 6409,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_1_IMU_DELTA_ANGLE_0_0 = 6410,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_1_IMU_DELTA_ANGLE_0_1 = 6411,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_1_IMU_DELTA_ANGLE_0_2 = 6412,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_1_IMU_DELTA_ANGLE_0_3 = 6413,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_1_IMU_DELTA_ANGLE_1_0 = 6414,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_1_IMU_DELTA_ANGLE_1_1 = 6415,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_1_IMU_DELTA_ANGLE_1_2 = 6416,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_1_IMU_DELTA_ANGLE_1_3 = 6417,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_1_IMU_DELTA_ANGLE_2_0 = 6418,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_1_IMU_DELTA_ANGLE_2_1 = 6419,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_1_IMU_DELTA_ANGLE_2_2 = 6420,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_1_IMU_DELTA_ANGLE_2_3 = 6421,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_1_MODE = 6422,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_1_STATUS_0 = 6423,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_1_STATUS_1 = 6424,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_1_VERSION_0 = 6425,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_1_VERSION_1 = 6426,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_1_COUNTER_0 = 6427,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_1_COUNTER_1 = 6428,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_2_IMU_EULER_ANGLE_0_0 = 6429,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_2_IMU_EULER_ANGLE_0_1 = 6430,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_2_IMU_EULER_ANGLE_0_2 = 6431,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_2_IMU_EULER_ANGLE_0_3 = 6432,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_2_IMU_EULER_ANGLE_1_0 = 6433,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_2_IMU_EULER_ANGLE_1_1 = 6434,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_2_IMU_EULER_ANGLE_1_2 = 6435,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_2_IMU_EULER_ANGLE_1_3 = 6436,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_2_IMU_EULER_ANGLE_2_0 = 6437,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_2_IMU_EULER_ANGLE_2_1 = 6438,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_2_IMU_EULER_ANGLE_2_2 = 6439,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_2_IMU_EULER_ANGLE_2_3 = 6440,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_2_IMU_DELTA_ANGLE_0_0 = 6441,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_2_IMU_DELTA_ANGLE_0_1 = 6442,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_2_IMU_DELTA_ANGLE_0_2 = 6443,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_2_IMU_DELTA_ANGLE_0_3 = 6444,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_2_IMU_DELTA_ANGLE_1_0 = 6445,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_2_IMU_DELTA_ANGLE_1_1 = 6446,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_2_IMU_DELTA_ANGLE_1_2 = 6447,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_2_IMU_DELTA_ANGLE_1_3 = 6448,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_2_IMU_DELTA_ANGLE_2_0 = 6449,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_2_IMU_DELTA_ANGLE_2_1 = 6450,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_2_IMU_DELTA_ANGLE_2_2 = 6451,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_2_IMU_DELTA_ANGLE_2_3 = 6452,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_2_MODE = 6453,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_2_STATUS_0 = 6454,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_2_STATUS_1 = 6455,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_2_VERSION_0 = 6456,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_2_VERSION_1 = 6457,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_2_COUNTER_0 = 6458,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_2_COUNTER_1 = 6459,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_3_IMU_EULER_ANGLE_0_0 = 6460,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_3_IMU_EULER_ANGLE_0_1 = 6461,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_3_IMU_EULER_ANGLE_0_2 = 6462,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_3_IMU_EULER_ANGLE_0_3 = 6463,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_3_IMU_EULER_ANGLE_1_0 = 6464,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_3_IMU_EULER_ANGLE_1_1 = 6465,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_3_IMU_EULER_ANGLE_1_2 = 6466,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_3_IMU_EULER_ANGLE_1_3 = 6467,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_3_IMU_EULER_ANGLE_2_0 = 6468,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_3_IMU_EULER_ANGLE_2_1 = 6469,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_3_IMU_EULER_ANGLE_2_2 = 6470,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_3_IMU_EULER_ANGLE_2_3 = 6471,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_3_IMU_DELTA_ANGLE_0_0 = 6472,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_3_IMU_DELTA_ANGLE_0_1 = 6473,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_3_IMU_DELTA_ANGLE_0_2 = 6474,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_3_IMU_DELTA_ANGLE_0_3 = 6475,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_3_IMU_DELTA_ANGLE_1_0 = 6476,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_3_IMU_DELTA_ANGLE_1_1 = 6477,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_3_IMU_DELTA_ANGLE_1_2 = 6478,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_3_IMU_DELTA_ANGLE_1_3 = 6479,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_3_IMU_DELTA_ANGLE_2_0 = 6480,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_3_IMU_DELTA_ANGLE_2_1 = 6481,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_3_IMU_DELTA_ANGLE_2_2 = 6482,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_3_IMU_DELTA_ANGLE_2_3 = 6483,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_3_MODE = 6484,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_3_STATUS_0 = 6485,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_3_STATUS_1 = 6486,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_3_VERSION_0 = 6487,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_3_VERSION_1 = 6488,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_3_COUNTER_0 = 6489,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_3_COUNTER_1 = 6490,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_4_IMU_EULER_ANGLE_0_0 = 6491,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_4_IMU_EULER_ANGLE_0_1 = 6492,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_4_IMU_EULER_ANGLE_0_2 = 6493,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_4_IMU_EULER_ANGLE_0_3 = 6494,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_4_IMU_EULER_ANGLE_1_0 = 6495,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_4_IMU_EULER_ANGLE_1_1 = 6496,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_4_IMU_EULER_ANGLE_1_2 = 6497,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_4_IMU_EULER_ANGLE_1_3 = 6498,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_4_IMU_EULER_ANGLE_2_0 = 6499,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_4_IMU_EULER_ANGLE_2_1 = 6500,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_4_IMU_EULER_ANGLE_2_2 = 6501,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_4_IMU_EULER_ANGLE_2_3 = 6502,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_4_IMU_DELTA_ANGLE_0_0 = 6503,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_4_IMU_DELTA_ANGLE_0_1 = 6504,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_4_IMU_DELTA_ANGLE_0_2 = 6505,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_4_IMU_DELTA_ANGLE_0_3 = 6506,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_4_IMU_DELTA_ANGLE_1_0 = 6507,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_4_IMU_DELTA_ANGLE_1_1 = 6508,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_4_IMU_DELTA_ANGLE_1_2 = 6509,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_4_IMU_DELTA_ANGLE_1_3 = 6510,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_4_IMU_DELTA_ANGLE_2_0 = 6511,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_4_IMU_DELTA_ANGLE_2_1 = 6512,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_4_IMU_DELTA_ANGLE_2_2 = 6513,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_4_IMU_DELTA_ANGLE_2_3 = 6514,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_4_MODE = 6515,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_4_STATUS_0 = 6516,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_4_STATUS_1 = 6517,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_4_VERSION_0 = 6518,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_4_VERSION_1 = 6519,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_4_COUNTER_0 = 6520,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_4_COUNTER_1 = 6521,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_5_IMU_EULER_ANGLE_0_0 = 6522,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_5_IMU_EULER_ANGLE_0_1 = 6523,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_5_IMU_EULER_ANGLE_0_2 = 6524,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_5_IMU_EULER_ANGLE_0_3 = 6525,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_5_IMU_EULER_ANGLE_1_0 = 6526,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_5_IMU_EULER_ANGLE_1_1 = 6527,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_5_IMU_EULER_ANGLE_1_2 = 6528,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_5_IMU_EULER_ANGLE_1_3 = 6529,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_5_IMU_EULER_ANGLE_2_0 = 6530,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_5_IMU_EULER_ANGLE_2_1 = 6531,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_5_IMU_EULER_ANGLE_2_2 = 6532,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_5_IMU_EULER_ANGLE_2_3 = 6533,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_5_IMU_DELTA_ANGLE_0_0 = 6534,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_5_IMU_DELTA_ANGLE_0_1 = 6535,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_5_IMU_DELTA_ANGLE_0_2 = 6536,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_5_IMU_DELTA_ANGLE_0_3 = 6537,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_5_IMU_DELTA_ANGLE_1_0 = 6538,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_5_IMU_DELTA_ANGLE_1_1 = 6539,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_5_IMU_DELTA_ANGLE_1_2 = 6540,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_5_IMU_DELTA_ANGLE_1_3 = 6541,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_5_IMU_DELTA_ANGLE_2_0 = 6542,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_5_IMU_DELTA_ANGLE_2_1 = 6543,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_5_IMU_DELTA_ANGLE_2_2 = 6544,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_5_IMU_DELTA_ANGLE_2_3 = 6545,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_5_MODE = 6546,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_5_STATUS_0 = 6547,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_5_STATUS_1 = 6548,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_5_VERSION_0 = 6549,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_5_VERSION_1 = 6550,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_5_COUNTER_0 = 6551,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_5_COUNTER_1 = 6552,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_6_IMU_EULER_ANGLE_0_0 = 6553,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_6_IMU_EULER_ANGLE_0_1 = 6554,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_6_IMU_EULER_ANGLE_0_2 = 6555,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_6_IMU_EULER_ANGLE_0_3 = 6556,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_6_IMU_EULER_ANGLE_1_0 = 6557,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_6_IMU_EULER_ANGLE_1_1 = 6558,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_6_IMU_EULER_ANGLE_1_2 = 6559,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_6_IMU_EULER_ANGLE_1_3 = 6560,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_6_IMU_EULER_ANGLE_2_0 = 6561,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_6_IMU_EULER_ANGLE_2_1 = 6562,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_6_IMU_EULER_ANGLE_2_2 = 6563,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_6_IMU_EULER_ANGLE_2_3 = 6564,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_6_IMU_DELTA_ANGLE_0_0 = 6565,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_6_IMU_DELTA_ANGLE_0_1 = 6566,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_6_IMU_DELTA_ANGLE_0_2 = 6567,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_6_IMU_DELTA_ANGLE_0_3 = 6568,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_6_IMU_DELTA_ANGLE_1_0 = 6569,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_6_IMU_DELTA_ANGLE_1_1 = 6570,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_6_IMU_DELTA_ANGLE_1_2 = 6571,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_6_IMU_DELTA_ANGLE_1_3 = 6572,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_6_IMU_DELTA_ANGLE_2_0 = 6573,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_6_IMU_DELTA_ANGLE_2_1 = 6574,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_6_IMU_DELTA_ANGLE_2_2 = 6575,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_6_IMU_DELTA_ANGLE_2_3 = 6576,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_6_MODE = 6577,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_6_STATUS_0 = 6578,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_6_STATUS_1 = 6579,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_6_VERSION_0 = 6580,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_6_VERSION_1 = 6581,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_6_COUNTER_0 = 6582,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_6_COUNTER_1 = 6583,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_7_IMU_EULER_ANGLE_0_0 = 6584,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_7_IMU_EULER_ANGLE_0_1 = 6585,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_7_IMU_EULER_ANGLE_0_2 = 6586,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_7_IMU_EULER_ANGLE_0_3 = 6587,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_7_IMU_EULER_ANGLE_1_0 = 6588,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_7_IMU_EULER_ANGLE_1_1 = 6589,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_7_IMU_EULER_ANGLE_1_2 = 6590,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_7_IMU_EULER_ANGLE_1_3 = 6591,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_7_IMU_EULER_ANGLE_2_0 = 6592,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_7_IMU_EULER_ANGLE_2_1 = 6593,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_7_IMU_EULER_ANGLE_2_2 = 6594,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_7_IMU_EULER_ANGLE_2_3 = 6595,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_7_IMU_DELTA_ANGLE_0_0 = 6596,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_7_IMU_DELTA_ANGLE_0_1 = 6597,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_7_IMU_DELTA_ANGLE_0_2 = 6598,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_7_IMU_DELTA_ANGLE_0_3 = 6599,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_7_IMU_DELTA_ANGLE_1_0 = 6600,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_7_IMU_DELTA_ANGLE_1_1 = 6601,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_7_IMU_DELTA_ANGLE_1_2 = 6602,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_7_IMU_DELTA_ANGLE_1_3 = 6603,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_7_IMU_DELTA_ANGLE_2_0 = 6604,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_7_IMU_DELTA_ANGLE_2_1 = 6605,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_7_IMU_DELTA_ANGLE_2_2 = 6606,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_7_IMU_DELTA_ANGLE_2_3 = 6607,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_7_MODE = 6608,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_7_STATUS_0 = 6609,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_7_STATUS_1 = 6610,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_7_VERSION_0 = 6611,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_7_VERSION_1 = 6612,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_7_COUNTER_0 = 6613,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_7_COUNTER_1 = 6614,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_8_IMU_EULER_ANGLE_0_0 = 6615,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_8_IMU_EULER_ANGLE_0_1 = 6616,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_8_IMU_EULER_ANGLE_0_2 = 6617,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_8_IMU_EULER_ANGLE_0_3 = 6618,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_8_IMU_EULER_ANGLE_1_0 = 6619,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_8_IMU_EULER_ANGLE_1_1 = 6620,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_8_IMU_EULER_ANGLE_1_2 = 6621,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_8_IMU_EULER_ANGLE_1_3 = 6622,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_8_IMU_EULER_ANGLE_2_0 = 6623,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_8_IMU_EULER_ANGLE_2_1 = 6624,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_8_IMU_EULER_ANGLE_2_2 = 6625,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_8_IMU_EULER_ANGLE_2_3 = 6626,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_8_IMU_DELTA_ANGLE_0_0 = 6627,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_8_IMU_DELTA_ANGLE_0_1 = 6628,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_8_IMU_DELTA_ANGLE_0_2 = 6629,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_8_IMU_DELTA_ANGLE_0_3 = 6630,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_8_IMU_DELTA_ANGLE_1_0 = 6631,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_8_IMU_DELTA_ANGLE_1_1 = 6632,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_8_IMU_DELTA_ANGLE_1_2 = 6633,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_8_IMU_DELTA_ANGLE_1_3 = 6634,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_8_IMU_DELTA_ANGLE_2_0 = 6635,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_8_IMU_DELTA_ANGLE_2_1 = 6636,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_8_IMU_DELTA_ANGLE_2_2 = 6637,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_8_IMU_DELTA_ANGLE_2_3 = 6638,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_8_MODE = 6639,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_8_STATUS_0 = 6640,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_8_STATUS_1 = 6641,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_8_VERSION_0 = 6642,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_8_VERSION_1 = 6643,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_8_COUNTER_0 = 6644,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_8_COUNTER_1 = 6645,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_9_IMU_EULER_ANGLE_0_0 = 6646,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_9_IMU_EULER_ANGLE_0_1 = 6647,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_9_IMU_EULER_ANGLE_0_2 = 6648,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_9_IMU_EULER_ANGLE_0_3 = 6649,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_9_IMU_EULER_ANGLE_1_0 = 6650,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_9_IMU_EULER_ANGLE_1_1 = 6651,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_9_IMU_EULER_ANGLE_1_2 = 6652,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_9_IMU_EULER_ANGLE_1_3 = 6653,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_9_IMU_EULER_ANGLE_2_0 = 6654,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_9_IMU_EULER_ANGLE_2_1 = 6655,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_9_IMU_EULER_ANGLE_2_2 = 6656,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_9_IMU_EULER_ANGLE_2_3 = 6657,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_9_IMU_DELTA_ANGLE_0_0 = 6658,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_9_IMU_DELTA_ANGLE_0_1 = 6659,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_9_IMU_DELTA_ANGLE_0_2 = 6660,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_9_IMU_DELTA_ANGLE_0_3 = 6661,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_9_IMU_DELTA_ANGLE_1_0 = 6662,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_9_IMU_DELTA_ANGLE_1_1 = 6663,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_9_IMU_DELTA_ANGLE_1_2 = 6664,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_9_IMU_DELTA_ANGLE_1_3 = 6665,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_9_IMU_DELTA_ANGLE_2_0 = 6666,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_9_IMU_DELTA_ANGLE_2_1 = 6667,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_9_IMU_DELTA_ANGLE_2_2 = 6668,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_9_IMU_DELTA_ANGLE_2_3 = 6669,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_9_MODE = 6670,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_9_STATUS_0 = 6671,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_9_STATUS_1 = 6672,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_9_VERSION_0 = 6673,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_9_VERSION_1 = 6674,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_9_COUNTER_0 = 6675,
            PARAMETER_MB_ADDR_TRANSFER_ALIGNMENT_DATA_9_COUNTER_1 = 6676,
            PARAMETER_MB_ADDR_SENSOR_ACC_X_0 = 6677,
            PARAMETER_MB_ADDR_SENSOR_ACC_X_1 = 6678,
            PARAMETER_MB_ADDR_SENSOR_ACC_X_2 = 6679,
            PARAMETER_MB_ADDR_SENSOR_ACC_X_3 = 6680,
            PARAMETER_MB_ADDR_SENSOR_ACC_Y_0 = 6681,
            PARAMETER_MB_ADDR_SENSOR_ACC_Y_1 = 6682,
            PARAMETER_MB_ADDR_SENSOR_ACC_Y_2 = 6683,
            PARAMETER_MB_ADDR_SENSOR_ACC_Y_3 = 6684,
            PARAMETER_MB_ADDR_SENSOR_ACC_Z_0 = 6685,
            PARAMETER_MB_ADDR_SENSOR_ACC_Z_1 = 6686,
            PARAMETER_MB_ADDR_SENSOR_ACC_Z_2 = 6687,
            PARAMETER_MB_ADDR_SENSOR_ACC_Z_3 = 6688,
            PARAMETER_MB_ADDR_SENSOR_ACC_I32_X_0 = 6689,
            PARAMETER_MB_ADDR_SENSOR_ACC_I32_X_1 = 6690,
            PARAMETER_MB_ADDR_SENSOR_ACC_I32_Y_0 = 6691,
            PARAMETER_MB_ADDR_SENSOR_ACC_I32_Y_1 = 6692,
            PARAMETER_MB_ADDR_SENSOR_ACC_I32_Z_0 = 6693,
            PARAMETER_MB_ADDR_SENSOR_ACC_I32_Z_1 = 6694,
            PARAMETER_MB_ADDR_SENSOR_ACC_I32_RANGE_0 = 6695,
            PARAMETER_MB_ADDR_SENSOR_ACC_I32_RANGE_1 = 6696,
            PARAMETER_MB_ADDR_SENSOR_ACC_I32_RANGE_2 = 6697,
            PARAMETER_MB_ADDR_SENSOR_ACC_I32_RANGE_3 = 6698,
            PARAMETER_MB_ADDR_SENSOR_GYRO_X_0 = 6699,
            PARAMETER_MB_ADDR_SENSOR_GYRO_X_1 = 6700,
            PARAMETER_MB_ADDR_SENSOR_GYRO_X_2 = 6701,
            PARAMETER_MB_ADDR_SENSOR_GYRO_X_3 = 6702,
            PARAMETER_MB_ADDR_SENSOR_GYRO_Y_0 = 6703,
            PARAMETER_MB_ADDR_SENSOR_GYRO_Y_1 = 6704,
            PARAMETER_MB_ADDR_SENSOR_GYRO_Y_2 = 6705,
            PARAMETER_MB_ADDR_SENSOR_GYRO_Y_3 = 6706,
            PARAMETER_MB_ADDR_SENSOR_GYRO_Z_0 = 6707,
            PARAMETER_MB_ADDR_SENSOR_GYRO_Z_1 = 6708,
            PARAMETER_MB_ADDR_SENSOR_GYRO_Z_2 = 6709,
            PARAMETER_MB_ADDR_SENSOR_GYRO_Z_3 = 6710,
            PARAMETER_MB_ADDR_SENSOR_GYRO_I32_X_0 = 6711,
            PARAMETER_MB_ADDR_SENSOR_GYRO_I32_X_1 = 6712,
            PARAMETER_MB_ADDR_SENSOR_GYRO_I32_Y_0 = 6713,
            PARAMETER_MB_ADDR_SENSOR_GYRO_I32_Y_1 = 6714,
            PARAMETER_MB_ADDR_SENSOR_GYRO_I32_Z_0 = 6715,
            PARAMETER_MB_ADDR_SENSOR_GYRO_I32_Z_1 = 6716,
            PARAMETER_MB_ADDR_SENSOR_GYRO_I32_RANGE_0 = 6717,
            PARAMETER_MB_ADDR_SENSOR_GYRO_I32_RANGE_1 = 6718,
            PARAMETER_MB_ADDR_SENSOR_GYRO_I32_RANGE_2 = 6719,
            PARAMETER_MB_ADDR_SENSOR_GYRO_I32_RANGE_3 = 6720,
            PARAMETER_MB_ADDR_SENSOR_TEMPERATURE_0 = 6721,
            PARAMETER_MB_ADDR_SENSOR_TEMPERATURE_1 = 6722,
            PARAMETER_MB_ADDR_SENSOR_TEMPERATURE_2 = 6723,
            PARAMETER_MB_ADDR_SENSOR_TEMPERATURE_3 = 6724,
            PARAMETER_MB_ADDR_SENSOR_TEMPERATURE_I16 = 6725,
            PARAMETER_MB_ADDR_SENSOR_TEMPERATURE_I16_RANGE_0 = 6726,
            PARAMETER_MB_ADDR_SENSOR_TEMPERATURE_I16_RANGE_1 = 6727,
            PARAMETER_MB_ADDR_SENSOR_TEMPERATURE_I16_RANGE_2 = 6728,
            PARAMETER_MB_ADDR_SENSOR_TEMPERATURE_I16_RANGE_3 = 6729,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_WARM_UP_TEMP_RATE_WARNING_LEVEL_0 = 6730,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_WARM_UP_TEMP_RATE_WARNING_LEVEL_1 = 6731,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_WARM_UP_TEMP_RATE_WARNING_LEVEL_2 = 6732,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_WARM_UP_TEMP_RATE_WARNING_LEVEL_3 = 6733,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_AFTER_WARM_UP_TEMP_RATE_WARNING_LEVEL_0 = 6734,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_AFTER_WARM_UP_TEMP_RATE_WARNING_LEVEL_1 = 6735,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_AFTER_WARM_UP_TEMP_RATE_WARNING_LEVEL_2 = 6736,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_AFTER_WARM_UP_TEMP_RATE_WARNING_LEVEL_3 = 6737,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_INIT_IDLE_TIME_S = 6738,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_ADDED_WARM_UP_TIME_S = 6739,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_AFTER_ALG_RESET_IDLE_TIME_S_0 = 6740,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_AFTER_ALG_RESET_IDLE_TIME_S_1 = 6741,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_AFTER_ALG_RESET_IDLE_TIME_S_2 = 6742,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_AFTER_ALG_RESET_IDLE_TIME_S_3 = 6743,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_COUNTER_0 = 6744,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_COUNTER_1 = 6745,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_VERSION_MAJOR = 6746,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_VERSION_MINOR = 6747,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_VERSION_BUILD1 = 6748,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_VERSION_BUILD2_0 = 6749,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_VERSION_BUILD2_1 = 6750,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_FAULT_STATUS_0_0 = 6751,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_FAULT_STATUS_0_1 = 6752,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_FAULT_STATUS_1_0 = 6753,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_FAULT_STATUS_1_1 = 6754,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_FAULT_STATUS_2_0 = 6755,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_FAULT_STATUS_2_1 = 6756,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_FAULT_STATUS_3_0 = 6757,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_FAULT_STATUS_3_1 = 6758,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_WARNING_STATUS_0_0 = 6759,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_WARNING_STATUS_0_1 = 6760,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_WARNING_STATUS_1_0 = 6761,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_WARNING_STATUS_1_1 = 6762,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_WARNING_STATUS_2_0 = 6763,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_WARNING_STATUS_2_1 = 6764,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_WARNING_STATUS_3_0 = 6765,
            PARAMETER_MB_ADDR_CALC_FAULT_DETECTION_WARNING_STATUS_3_1 = 6766,
            PARAMETER_MB_ADDR_ROTATION_COORDINATE_ANGLES_DEGREE_0_0 = 6767,
            PARAMETER_MB_ADDR_ROTATION_COORDINATE_ANGLES_DEGREE_0_1 = 6768,
            PARAMETER_MB_ADDR_ROTATION_COORDINATE_ANGLES_DEGREE_0_2 = 6769,
            PARAMETER_MB_ADDR_ROTATION_COORDINATE_ANGLES_DEGREE_0_3 = 6770,
            PARAMETER_MB_ADDR_ROTATION_COORDINATE_ANGLES_DEGREE_1_0 = 6771,
            PARAMETER_MB_ADDR_ROTATION_COORDINATE_ANGLES_DEGREE_1_1 = 6772,
            PARAMETER_MB_ADDR_ROTATION_COORDINATE_ANGLES_DEGREE_1_2 = 6773,
            PARAMETER_MB_ADDR_ROTATION_COORDINATE_ANGLES_DEGREE_1_3 = 6774,
            PARAMETER_MB_ADDR_ROTATION_COORDINATE_ANGLES_DEGREE_2_0 = 6775,
            PARAMETER_MB_ADDR_ROTATION_COORDINATE_ANGLES_DEGREE_2_1 = 6776,
            PARAMETER_MB_ADDR_ROTATION_COORDINATE_ANGLES_DEGREE_2_2 = 6777,
            PARAMETER_MB_ADDR_ROTATION_COORDINATE_ANGLES_DEGREE_2_3 = 6778,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_ACC_X_0 = 6779,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_ACC_X_1 = 6780,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_ACC_X_2 = 6781,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_ACC_X_3 = 6782,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_ACC_Y_0 = 6783,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_ACC_Y_1 = 6784,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_ACC_Y_2 = 6785,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_ACC_Y_3 = 6786,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_ACC_Z_0 = 6787,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_ACC_Z_1 = 6788,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_ACC_Z_2 = 6789,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_ACC_Z_3 = 6790,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_GYRO_X_0 = 6791,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_GYRO_X_1 = 6792,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_GYRO_X_2 = 6793,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_GYRO_X_3 = 6794,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_GYRO_Y_0 = 6795,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_GYRO_Y_1 = 6796,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_GYRO_Y_2 = 6797,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_GYRO_Y_3 = 6798,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_GYRO_Z_0 = 6799,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_GYRO_Z_1 = 6800,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_GYRO_Z_2 = 6801,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_GYRO_Z_3 = 6802,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_ACC_I32_X_0 = 6803,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_ACC_I32_X_1 = 6804,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_ACC_I32_Y_0 = 6805,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_ACC_I32_Y_1 = 6806,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_ACC_I32_Z_0 = 6807,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_ACC_I32_Z_1 = 6808,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_GYRO_I32_X_0 = 6809,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_GYRO_I32_X_1 = 6810,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_GYRO_I32_Y_0 = 6811,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_GYRO_I32_Y_1 = 6812,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_GYRO_I32_Z_0 = 6813,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_GYRO_I32_Z_1 = 6814,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_ACC_I32_RANGE_0 = 6815,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_ACC_I32_RANGE_1 = 6816,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_ACC_I32_RANGE_2 = 6817,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_ACC_I32_RANGE_3 = 6818,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_GYRO_I32_RANGE_0 = 6819,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_GYRO_I32_RANGE_1 = 6820,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_GYRO_I32_RANGE_2 = 6821,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_GYRO_I32_RANGE_3 = 6822,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_VERSION_MAJOR = 6823,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_VERSION_MINOR = 6824,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_VERSION_BUILD1 = 6825,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_VERSION_BUILD2_0 = 6826,
            PARAMETER_MB_ADDR_CALC_PRE_PROCESS_ALGORITHM_VERSION_BUILD2_1 = 6827,
            PARAMETER_MB_ADDR_GENERAL_STATUS_SUMMARY_0 = 6828,
            PARAMETER_MB_ADDR_GENERAL_STATUS_SUMMARY_1 = 6829
        }
    }
}

