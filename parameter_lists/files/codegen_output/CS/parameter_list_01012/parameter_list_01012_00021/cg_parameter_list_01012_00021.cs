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
╔════════════════════════╗
║ parameter_list_mohajer ║
╚════════════════════════╝
*/

namespace ACCUNAV_IMU_Setting
{
    [DefaultProperty("SerialNo")]
    public class Parameters_DeviceID_01012_00021 : IParameterListDevice
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
        public sSensorImuSetting imu_Setting;
        public sSensorMs5611Setting ms5611_Setting;
        public sSensorGpsSetting m9n_Setting;
        public sSensorDadcSetting dadc_Setting;
        public sSensorHmc5983Setting hmc5983_Setting;
        public sSensorIBNS_MatchSetting iBNS_Match_Setting;
        public sSensorIBNS_SpeedSetting iBNS_Speed_Setting;
        public sSensorSadraSetting sadra_Setting;
        public sProfilerSetting mainLoopProfilerSetting;
        public UInt16 calcFreqHz;
        public Double[] debugControlSignalsF64;
        public Single[] debugControlSignalsF32;
        public UInt32[] debugControlSignalsU32;
        public Int32[] debugControlSignalsI32;
        public UInt16[] debugControlSignalsU16;
        public UInt16 zUPTUse;
        public UInt16 gNSSUse;
        public UInt16 airDataAllUse;
        public UInt16 airDataSpeedUse;
        public UInt16 airDataAltitudeUse;
        public UInt16 visionUse;
        public UInt16 magUse;
        public UInt16 algorithmType;
        public UInt16 gNSSType;
        public UInt16 headType;
        public UInt16 alignType;
        public UInt16 nSensor;
        public Double initIdleTime;
        public Double[] initLLA_rrm;
        public Double initHead_rad;
        public Double alignTime_s;
        public Double relAz_rad;
        public Double speed0_mps;
        public Double[] euler0_rad;
        public UInt16 chipStabilizationCycleQty;
        public UInt16 outputStabilizationCycleQty;

        public Parameters_DeviceID_01012_00021()
        {
            readedOnce = false;
        
            deviceId = 1012;
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
            imu_Setting = new sSensorImuSetting((UInt16)(4374));
            ms5611_Setting = new sSensorMs5611Setting((UInt16)(4403));
            m9n_Setting = new sSensorGpsSetting((UInt16)(4472));
            dadc_Setting = new sSensorDadcSetting((UInt16)(4525));
            hmc5983_Setting = new sSensorHmc5983Setting((UInt16)(4537));
            iBNS_Match_Setting = new sSensorIBNS_MatchSetting((UInt16)(4596));
            iBNS_Speed_Setting = new sSensorIBNS_SpeedSetting((UInt16)(4644));
            sadra_Setting = new sSensorSadraSetting((UInt16)(4741));
            mainLoopProfilerSetting = new sProfilerSetting((UInt16)(4759));
            calcFreqHz = 2000;
            debugControlSignalsF64 = new Double[50];
            debugControlSignalsF32 = new Single[50];
            debugControlSignalsU32 = new UInt32[50];
            debugControlSignalsI32 = new Int32[50];
            debugControlSignalsU16 = new UInt16[50];
            zUPTUse = 0;
            gNSSUse = 0;
            airDataAllUse = 0;
            airDataSpeedUse = 0;
            airDataAltitudeUse = 0;
            visionUse = 0;
            magUse = 0;
            algorithmType = 0;
            gNSSType = 0;
            headType = 0;
            alignType = 0;
            nSensor = 2;
            initIdleTime = 0;
            initLLA_rrm = new Double[3];
            initHead_rad = 0;
            alignTime_s = 0;
            relAz_rad = 0;
            speed0_mps = 0;
            euler0_rad = new Double[3];
            chipStabilizationCycleQty = 100;
            outputStabilizationCycleQty = 200;
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

        [Category("Hardware"), ReadOnly(false), Description("")]
        public sSensorImuSetting Imu_Setting
        {
            get { return imu_Setting; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(4374, 0, value, typeof(sSensorImuSetting), 1))
                {
                    imu_Setting = value;
                }
            }
        }

        [Category("Hardware"), ReadOnly(false), Description("")]
        public sSensorMs5611Setting Ms5611_Setting
        {
            get { return ms5611_Setting; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(4403, 0, value, typeof(sSensorMs5611Setting), 1))
                {
                    ms5611_Setting = value;
                }
            }
        }

        [Category("Hardware"), ReadOnly(false), Description("")]
        public sSensorGpsSetting M9n_Setting
        {
            get { return m9n_Setting; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(4472, 0, value, typeof(sSensorGpsSetting), 1))
                {
                    m9n_Setting = value;
                }
            }
        }

        [Category("Hardware"), ReadOnly(false), Description("")]
        public sSensorDadcSetting Dadc_Setting
        {
            get { return dadc_Setting; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(4525, 0, value, typeof(sSensorDadcSetting), 1))
                {
                    dadc_Setting = value;
                }
            }
        }

        [Category("Hardware"), ReadOnly(false), Description("")]
        public sSensorHmc5983Setting Hmc5983_Setting
        {
            get { return hmc5983_Setting; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(4537, 0, value, typeof(sSensorHmc5983Setting), 1))
                {
                    hmc5983_Setting = value;
                }
            }
        }

        [Category("Hardware"), ReadOnly(false), Description("")]
        public sSensorIBNS_MatchSetting IBNS_Match_Setting
        {
            get { return iBNS_Match_Setting; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(4596, 0, value, typeof(sSensorIBNS_MatchSetting), 1))
                {
                    iBNS_Match_Setting = value;
                }
            }
        }

        [Category("Hardware"), ReadOnly(false), Description("")]
        public sSensorIBNS_SpeedSetting IBNS_Speed_Setting
        {
            get { return iBNS_Speed_Setting; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(4644, 0, value, typeof(sSensorIBNS_SpeedSetting), 1))
                {
                    iBNS_Speed_Setting = value;
                }
            }
        }

        [Category("Hardware"), ReadOnly(false), Description("")]
        public sSensorSadraSetting Sadra_Setting
        {
            get { return sadra_Setting; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(4741, 0, value, typeof(sSensorSadraSetting), 1))
                {
                    sadra_Setting = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), Description("")]
        public sProfilerSetting MainLoopProfilerSetting
        {
            get { return mainLoopProfilerSetting; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(4759, 0, value, typeof(sProfilerSetting), 1))
                {
                    mainLoopProfilerSetting = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(2000), Description("")]
        public UInt16 CalcFreqHz
        {
            get { return calcFreqHz; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(4770, 0, value, typeof(UInt16), 1))
                {
                    calcFreqHz = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), Description("")]
        public Double[] DebugControlSignalsF64
        {
            get { return debugControlSignalsF64; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(5373, 0, value, typeof(Double), 50))
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
                if(MainForm.modbusExt.ModbusWrite(5573, 0, value, typeof(Single), 50))
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
                if(MainForm.modbusExt.ModbusWrite(5673, 0, value, typeof(UInt32), 50))
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
                if(MainForm.modbusExt.ModbusWrite(5773, 0, value, typeof(Int32), 50))
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
                if(MainForm.modbusExt.ModbusWrite(5873, 0, value, typeof(UInt16), 50))
                {
                    debugControlSignalsU16 = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public UInt16 ZUPTUse
        {
            get { return zUPTUse; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(5923, 0, value, typeof(UInt16), 1))
                {
                    zUPTUse = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public UInt16 GNSSUse
        {
            get { return gNSSUse; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(5924, 0, value, typeof(UInt16), 1))
                {
                    gNSSUse = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public UInt16 AirDataAllUse
        {
            get { return airDataAllUse; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(5925, 0, value, typeof(UInt16), 1))
                {
                    airDataAllUse = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public UInt16 AirDataSpeedUse
        {
            get { return airDataSpeedUse; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(5926, 0, value, typeof(UInt16), 1))
                {
                    airDataSpeedUse = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public UInt16 AirDataAltitudeUse
        {
            get { return airDataAltitudeUse; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(5927, 0, value, typeof(UInt16), 1))
                {
                    airDataAltitudeUse = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public UInt16 VisionUse
        {
            get { return visionUse; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(5928, 0, value, typeof(UInt16), 1))
                {
                    visionUse = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public UInt16 MagUse
        {
            get { return magUse; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(5929, 0, value, typeof(UInt16), 1))
                {
                    magUse = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("eAlgorithmType")]
        public UInt16 AlgorithmType
        {
            get { return algorithmType; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(5933, 0, value, typeof(UInt16), 1))
                {
                    algorithmType = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("eGNSSType")]
        public UInt16 GNSSType
        {
            get { return gNSSType; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(5934, 0, value, typeof(UInt16), 1))
                {
                    gNSSType = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("eHeadType")]
        public UInt16 HeadType
        {
            get { return headType; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(5935, 0, value, typeof(UInt16), 1))
                {
                    headType = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("eAlignMode")]
        public UInt16 AlignType
        {
            get { return alignType; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(5936, 0, value, typeof(UInt16), 1))
                {
                    alignType = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(2), Description("")]
        public UInt16 NSensor
        {
            get { return nSensor; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(5937, 0, value, typeof(UInt16), 1))
                {
                    nSensor = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public Double InitIdleTime
        {
            get { return initIdleTime; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(5938, 0, value, typeof(Double), 1))
                {
                    initIdleTime = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), Description("")]
        public Double[] InitLLA_rrm
        {
            get { return initLLA_rrm; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(5942, 0, value, typeof(Double), 3))
                {
                    initLLA_rrm = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public Double InitHead_rad
        {
            get { return initHead_rad; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(5954, 0, value, typeof(Double), 1))
                {
                    initHead_rad = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public Double AlignTime_s
        {
            get { return alignTime_s; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(5958, 0, value, typeof(Double), 1))
                {
                    alignTime_s = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public Double RelAz_rad
        {
            get { return relAz_rad; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(5962, 0, value, typeof(Double), 1))
                {
                    relAz_rad = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public Double Speed0_mps
        {
            get { return speed0_mps; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(5966, 0, value, typeof(Double), 1))
                {
                    speed0_mps = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), Description("")]
        public Double[] Euler0_rad
        {
            get { return euler0_rad; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(5970, 0, value, typeof(Double), 3))
                {
                    euler0_rad = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(100), Description("This time is started from first run of calculation. This time is based on CalcFreqHz")]
        public UInt16 ChipStabilizationCycleQty
        {
            get { return chipStabilizationCycleQty; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6254, 0, value, typeof(UInt16), 1))
                {
                    chipStabilizationCycleQty = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(200), Description("This time is started from first run of calculation. This time is based on CalcFreqHz")]
        public UInt16 OutputStabilizationCycleQty
        {
            get { return outputStabilizationCycleQty; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(6255, 0, value, typeof(UInt16), 1))
                {
                    outputStabilizationCycleQty = value;
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
            _status &= imu_Setting.ModbusWriteAll();
            _status &= ms5611_Setting.ModbusWriteAll();
            _status &= m9n_Setting.ModbusWriteAll();
            _status &= dadc_Setting.ModbusWriteAll();
            _status &= hmc5983_Setting.ModbusWriteAll();
            _status &= iBNS_Match_Setting.ModbusWriteAll();
            _status &= iBNS_Speed_Setting.ModbusWriteAll();
            _status &= sadra_Setting.ModbusWriteAll();
            _status &= mainLoopProfilerSetting.ModbusWriteAll();
            _status &= MainForm.modbusExt.ModbusWrite(4770, 0, calcFreqHz, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5373, 0, debugControlSignalsF64, typeof(Double), 50);
            _status &= MainForm.modbusExt.ModbusWrite(5573, 0, debugControlSignalsF32, typeof(Single), 50);
            _status &= MainForm.modbusExt.ModbusWrite(5673, 0, debugControlSignalsU32, typeof(UInt32), 50);
            _status &= MainForm.modbusExt.ModbusWrite(5773, 0, debugControlSignalsI32, typeof(Int32), 50);
            _status &= MainForm.modbusExt.ModbusWrite(5873, 0, debugControlSignalsU16, typeof(UInt16), 50);
            _status &= MainForm.modbusExt.ModbusWrite(5923, 0, zUPTUse, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5924, 0, gNSSUse, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5925, 0, airDataAllUse, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5926, 0, airDataSpeedUse, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5927, 0, airDataAltitudeUse, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5928, 0, visionUse, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5929, 0, magUse, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5933, 0, algorithmType, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5934, 0, gNSSType, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5935, 0, headType, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5936, 0, alignType, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5937, 0, nSensor, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5938, 0, initIdleTime, typeof(Double), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5942, 0, initLLA_rrm, typeof(Double), 3);
            _status &= MainForm.modbusExt.ModbusWrite(5954, 0, initHead_rad, typeof(Double), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5958, 0, alignTime_s, typeof(Double), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5962, 0, relAz_rad, typeof(Double), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5966, 0, speed0_mps, typeof(Double), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5970, 0, euler0_rad, typeof(Double), 3);
            _status &= MainForm.modbusExt.ModbusWrite(6254, 0, chipStabilizationCycleQty, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(6255, 0, outputStabilizationCycleQty, typeof(UInt16), 1);
            
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
                imu_Setting.ModbusReadAll();
                ms5611_Setting.ModbusReadAll();
                m9n_Setting.ModbusReadAll();
                dadc_Setting.ModbusReadAll();
                hmc5983_Setting.ModbusReadAll();
                iBNS_Match_Setting.ModbusReadAll();
                iBNS_Speed_Setting.ModbusReadAll();
                sadra_Setting.ModbusReadAll();
                mainLoopProfilerSetting.ModbusReadAll();
                calcFreqHz = MainForm.modbusExt.ModbusRead(4770, 0, typeof(UInt16), 1);
                debugControlSignalsF64 = MainForm.modbusExt.ModbusRead(5373, 0, typeof(Double), 50);
                debugControlSignalsF32 = MainForm.modbusExt.ModbusRead(5573, 0, typeof(Single), 50);
                debugControlSignalsU32 = MainForm.modbusExt.ModbusRead(5673, 0, typeof(UInt32), 50);
                debugControlSignalsI32 = MainForm.modbusExt.ModbusRead(5773, 0, typeof(Int32), 50);
                debugControlSignalsU16 = MainForm.modbusExt.ModbusRead(5873, 0, typeof(UInt16), 50);
                zUPTUse = MainForm.modbusExt.ModbusRead(5923, 0, typeof(UInt16), 1);
                gNSSUse = MainForm.modbusExt.ModbusRead(5924, 0, typeof(UInt16), 1);
                airDataAllUse = MainForm.modbusExt.ModbusRead(5925, 0, typeof(UInt16), 1);
                airDataSpeedUse = MainForm.modbusExt.ModbusRead(5926, 0, typeof(UInt16), 1);
                airDataAltitudeUse = MainForm.modbusExt.ModbusRead(5927, 0, typeof(UInt16), 1);
                visionUse = MainForm.modbusExt.ModbusRead(5928, 0, typeof(UInt16), 1);
                magUse = MainForm.modbusExt.ModbusRead(5929, 0, typeof(UInt16), 1);
                algorithmType = MainForm.modbusExt.ModbusRead(5933, 0, typeof(UInt16), 1);
                gNSSType = MainForm.modbusExt.ModbusRead(5934, 0, typeof(UInt16), 1);
                headType = MainForm.modbusExt.ModbusRead(5935, 0, typeof(UInt16), 1);
                alignType = MainForm.modbusExt.ModbusRead(5936, 0, typeof(UInt16), 1);
                nSensor = MainForm.modbusExt.ModbusRead(5937, 0, typeof(UInt16), 1);
                initIdleTime = MainForm.modbusExt.ModbusRead(5938, 0, typeof(Double), 1);
                initLLA_rrm = MainForm.modbusExt.ModbusRead(5942, 0, typeof(Double), 3);
                initHead_rad = MainForm.modbusExt.ModbusRead(5954, 0, typeof(Double), 1);
                alignTime_s = MainForm.modbusExt.ModbusRead(5958, 0, typeof(Double), 1);
                relAz_rad = MainForm.modbusExt.ModbusRead(5962, 0, typeof(Double), 1);
                speed0_mps = MainForm.modbusExt.ModbusRead(5966, 0, typeof(Double), 1);
                euler0_rad = MainForm.modbusExt.ModbusRead(5970, 0, typeof(Double), 3);
                chipStabilizationCycleQty = MainForm.modbusExt.ModbusRead(6254, 0, typeof(UInt16), 1);
                outputStabilizationCycleQty = MainForm.modbusExt.ModbusRead(6255, 0, typeof(UInt16), 1);
            
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

        public void LoadBoard_Button_Click(object sender, EventArgs e)
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

        public void LoadRappMain_Button_Click(object sender, EventArgs e)
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

        public void LoadWithForceAll_Button_Click(object sender, EventArgs e)
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

        public void LoadWithForceInfo_Button_Click(object sender, EventArgs e)
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

        public void LoadWithForceModbusExt_Button_Click(object sender, EventArgs e)
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

        public void LoadWithForceBoard_Button_Click(object sender, EventArgs e)
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

        public void LoadWithForceRappMain_Button_Click(object sender, EventArgs e)
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

        public void SaveAll_Button_Click(object sender, EventArgs e)
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

        public void SaveInfo_Button_Click(object sender, EventArgs e)
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

        public void SaveModbusExt_Button_Click(object sender, EventArgs e)
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

        public void SaveBoard_Button_Click(object sender, EventArgs e)
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

        public void SaveRappMain_Button_Click(object sender, EventArgs e)
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

        public void AlgorithmReset_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(5930, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(5930, 0, typeof(UInt16), 1);
        
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

        public void FlightZero_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(5931, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(5931, 0, typeof(UInt16), 1);
        
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

        public void Arm_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(5932, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(5932, 0, typeof(UInt16), 1);
        
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

        public void SendLogStart_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(6256, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(6256, 0, typeof(UInt16), 1);
        
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

        public void SendLogStop_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(6257, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(6257, 0, typeof(UInt16), 1);
        
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

        public void EraseAllLogs_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(6258, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(6258, 0, typeof(UInt16), 1);
        
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

        public void GpsM9nBridgeStartCmd_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(6417, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(6417, 0, typeof(UInt16), 1);
        
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

        public void DadcBridgeStartCmd_Button_Click(object sender, EventArgs e)
        {
            // Handle the button click
            MainForm.modbusExt.SetWaitCursor(true);
        
            MainForm.modbusExt.ModbusWrite(6418, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(6418, 0, typeof(UInt16), 1);
        
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
            public sBoardStartupReportItem ms5611;
            public sBoardStartupReportItem dadc;
            public sBoardStartupReportItem iBNS_Match;
            public sBoardStartupReportItem iBNS_Speed;
            public sBoardStartupReportItem sadra;
            public sBoardStartupReportItem hmc5983;
            public sBoardStartupReportItem gpsM9N;
            public sBoardStartupReportItem imu;

            private UInt16 ModbusBaseAddr;

            public static UInt16 ModbusSize = 66; // VarTypeSize in excel
            
            public sBoardStartupReport(UInt16 ObjectModbusBaseAddr)
            {
                ModbusBaseAddr = ObjectModbusBaseAddr;

                overallResult = 0;
                executionTimeUs = 0;
                ms5611 = new sBoardStartupReportItem((UInt16)(ModbusBaseAddr + 2));
                dadc = new sBoardStartupReportItem((UInt16)(ModbusBaseAddr + 10));
                iBNS_Match = new sBoardStartupReportItem((UInt16)(ModbusBaseAddr + 18));
                iBNS_Speed = new sBoardStartupReportItem((UInt16)(ModbusBaseAddr + 26));
                sadra = new sBoardStartupReportItem((UInt16)(ModbusBaseAddr + 34));
                hmc5983 = new sBoardStartupReportItem((UInt16)(ModbusBaseAddr + 42));
                gpsM9N = new sBoardStartupReportItem((UInt16)(ModbusBaseAddr + 50));
                imu = new sBoardStartupReportItem((UInt16)(ModbusBaseAddr + 58));
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

            public sBoardStartupReportItem Ms5611
            {
                get { return ms5611; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 2, value, typeof(sBoardStartupReportItem), 1))
                    {
                        ms5611 = value;
                    }
                }
            }

            public sBoardStartupReportItem Dadc
            {
                get { return dadc; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 10, value, typeof(sBoardStartupReportItem), 1))
                    {
                        dadc = value;
                    }
                }
            }

            public sBoardStartupReportItem IBNS_Match
            {
                get { return iBNS_Match; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 18, value, typeof(sBoardStartupReportItem), 1))
                    {
                        iBNS_Match = value;
                    }
                }
            }

            public sBoardStartupReportItem IBNS_Speed
            {
                get { return iBNS_Speed; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 26, value, typeof(sBoardStartupReportItem), 1))
                    {
                        iBNS_Speed = value;
                    }
                }
            }

            public sBoardStartupReportItem Sadra
            {
                get { return sadra; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 34, value, typeof(sBoardStartupReportItem), 1))
                    {
                        sadra = value;
                    }
                }
            }

            public sBoardStartupReportItem Hmc5983
            {
                get { return hmc5983; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 42, value, typeof(sBoardStartupReportItem), 1))
                    {
                        hmc5983 = value;
                    }
                }
            }

            public sBoardStartupReportItem GpsM9N
            {
                get { return gpsM9N; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 50, value, typeof(sBoardStartupReportItem), 1))
                    {
                        gpsM9N = value;
                    }
                }
            }

            public sBoardStartupReportItem Imu
            {
                get { return imu; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 58, value, typeof(sBoardStartupReportItem), 1))
                    {
                        imu = value;
                    }
                }
            }

            public bool ModbusWriteAll()
            {
                bool _status = true;
            
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, overallResult, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 1, executionTimeUs, typeof(UInt16), 1);
                _status &= ms5611.ModbusWriteAll();
                _status &= dadc.ModbusWriteAll();
                _status &= iBNS_Match.ModbusWriteAll();
                _status &= iBNS_Speed.ModbusWriteAll();
                _status &= sadra.ModbusWriteAll();
                _status &= hmc5983.ModbusWriteAll();
                _status &= gpsM9N.ModbusWriteAll();
                _status &= imu.ModbusWriteAll();
                
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
                ms5611.ModbusReadAll();
                dadc.ModbusReadAll();
                iBNS_Match.ModbusReadAll();
                iBNS_Speed.ModbusReadAll();
                sadra.ModbusReadAll();
                hmc5983.ModbusReadAll();
                gpsM9N.ModbusReadAll();
                imu.ModbusReadAll();
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
        public class sSensorImuData
        {
            public s3d[] acc_g;
            public s3d[] gyr_dps;
            public Double temperature;
            public UInt16 serialNo;
            public UInt16 counter;
            public UInt16 isNewData;
            public UInt16 active;
            public UInt32 summaryStatus;

            private UInt16 ModbusBaseAddr;

            public static UInt16 ModbusSize = 58; // VarTypeSize in excel
            
            public sSensorImuData(UInt16 ObjectModbusBaseAddr)
            {
                ModbusBaseAddr = ObjectModbusBaseAddr;


                acc_g = new s3d[2];
                for (UInt16 i = 0; i < 2; i++)
                {
                    acc_g[i] = new s3d((UInt16)(ModbusBaseAddr + 0 + (12 * i)));
                }

                gyr_dps = new s3d[2];
                for (UInt16 i = 0; i < 2; i++)
                {
                    gyr_dps[i] = new s3d((UInt16)(ModbusBaseAddr + 24 + (12 * i)));
                }

                temperature = 0;
                serialNo = 0;
                counter = 0;
                isNewData = 0;
                active = 0;
                summaryStatus = 0;
            }

            public s3d[] Acc_g
            {
                get { return acc_g; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, value, typeof(s3d), 2))
                    {
                        acc_g = value;
                    }
                }
            }

            public s3d[] Gyr_dps
            {
                get { return gyr_dps; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 24, value, typeof(s3d), 2))
                    {
                        gyr_dps = value;
                    }
                }
            }

            public Double Temperature
            {
                get { return temperature; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 48, value, typeof(Double), 1))
                    {
                        temperature = value;
                    }
                }
            }

            public UInt16 SerialNo
            {
                get { return serialNo; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 52, value, typeof(UInt16), 1))
                    {
                        serialNo = value;
                    }
                }
            }

            public UInt16 Counter
            {
                get { return counter; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 53, value, typeof(UInt16), 1))
                    {
                        counter = value;
                    }
                }
            }

            public UInt16 IsNewData
            {
                get { return isNewData; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 54, value, typeof(UInt16), 1))
                    {
                        isNewData = value;
                    }
                }
            }

            public UInt16 Active
            {
                get { return active; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 55, value, typeof(UInt16), 1))
                    {
                        active = value;
                    }
                }
            }

            public UInt32 SummaryStatus
            {
                get { return summaryStatus; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 56, value, typeof(UInt32), 1))
                    {
                        summaryStatus = value;
                    }
                }
            }

            public bool ModbusWriteAll()
            {
                bool _status = true;
            

                for (int i = 0; i < 2; i++)
                {
                    acc_g[i].ModbusWriteAll();
                }

                for (int i = 0; i < 2; i++)
                {
                    gyr_dps[i].ModbusWriteAll();
                }

                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 48, temperature, typeof(Double), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 52, serialNo, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 53, counter, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 54, isNewData, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 55, active, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 56, summaryStatus, typeof(UInt32), 1);
                
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
                    acc_g[i].ModbusReadAll();
                }

                for (int i = 0; i < 2; i++)
                {
                    gyr_dps[i].ModbusReadAll();
                }

                temperature = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 48, typeof(Double), 1);
                serialNo = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 52, typeof(UInt16), 1);
                counter = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 53, typeof(UInt16), 1);
                isNewData = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 54, typeof(UInt16), 1);
                active = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 55, typeof(UInt16), 1);
                summaryStatus = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 56, typeof(UInt32), 1);
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class sSensorImuSetting
        {
            public UInt16 type;
            public UInt16 decRate;
            public UInt16 filterAccXEnable;
            public UInt16 filterAccXType;
            public UInt16 filterAccYEnable;
            public UInt16 filterAccYType;
            public UInt16 filterAccZEnable;
            public UInt16 filterAccZType;
            public UInt16 filterGyroXEnable;
            public UInt16 filterGyroXType;
            public UInt16 filterGyroYEnable;
            public UInt16 filterGyroYType;
            public UInt16 filterGyroZEnable;
            public UInt16 filterGyroZType;
            public UInt16 filterMagXEnable;
            public UInt16 filterMagXType;
            public UInt16 filterMagYEnable;
            public UInt16 filterMagYType;
            public UInt16 filterMagZEnable;
            public UInt16 filterMagZType;
            public UInt16 enable;

            private UInt16 ModbusBaseAddr;

            public static UInt16 ModbusSize = 21; // VarTypeSize in excel
            
            public sSensorImuSetting(UInt16 ObjectModbusBaseAddr)
            {
                ModbusBaseAddr = ObjectModbusBaseAddr;

                type = 0;
                decRate = 0;
                filterAccXEnable = 0;
                filterAccXType = 0;
                filterAccYEnable = 0;
                filterAccYType = 0;
                filterAccZEnable = 0;
                filterAccZType = 0;
                filterGyroXEnable = 0;
                filterGyroXType = 0;
                filterGyroYEnable = 0;
                filterGyroYType = 0;
                filterGyroZEnable = 0;
                filterGyroZType = 0;
                filterMagXEnable = 0;
                filterMagXType = 0;
                filterMagYEnable = 0;
                filterMagYType = 0;
                filterMagZEnable = 0;
                filterMagZType = 0;
                enable = 0;
            }

            public UInt16 Type
            {
                get { return type; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, value, typeof(UInt16), 1))
                    {
                        type = value;
                    }
                }
            }

            public UInt16 DecRate
            {
                get { return decRate; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 1, value, typeof(UInt16), 1))
                    {
                        decRate = value;
                    }
                }
            }

            public UInt16 FilterAccXEnable
            {
                get { return filterAccXEnable; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 2, value, typeof(UInt16), 1))
                    {
                        filterAccXEnable = value;
                    }
                }
            }

            public UInt16 FilterAccXType
            {
                get { return filterAccXType; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 3, value, typeof(UInt16), 1))
                    {
                        filterAccXType = value;
                    }
                }
            }

            public UInt16 FilterAccYEnable
            {
                get { return filterAccYEnable; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 4, value, typeof(UInt16), 1))
                    {
                        filterAccYEnable = value;
                    }
                }
            }

            public UInt16 FilterAccYType
            {
                get { return filterAccYType; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 5, value, typeof(UInt16), 1))
                    {
                        filterAccYType = value;
                    }
                }
            }

            public UInt16 FilterAccZEnable
            {
                get { return filterAccZEnable; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 6, value, typeof(UInt16), 1))
                    {
                        filterAccZEnable = value;
                    }
                }
            }

            public UInt16 FilterAccZType
            {
                get { return filterAccZType; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 7, value, typeof(UInt16), 1))
                    {
                        filterAccZType = value;
                    }
                }
            }

            public UInt16 FilterGyroXEnable
            {
                get { return filterGyroXEnable; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 8, value, typeof(UInt16), 1))
                    {
                        filterGyroXEnable = value;
                    }
                }
            }

            public UInt16 FilterGyroXType
            {
                get { return filterGyroXType; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 9, value, typeof(UInt16), 1))
                    {
                        filterGyroXType = value;
                    }
                }
            }

            public UInt16 FilterGyroYEnable
            {
                get { return filterGyroYEnable; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 10, value, typeof(UInt16), 1))
                    {
                        filterGyroYEnable = value;
                    }
                }
            }

            public UInt16 FilterGyroYType
            {
                get { return filterGyroYType; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 11, value, typeof(UInt16), 1))
                    {
                        filterGyroYType = value;
                    }
                }
            }

            public UInt16 FilterGyroZEnable
            {
                get { return filterGyroZEnable; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 12, value, typeof(UInt16), 1))
                    {
                        filterGyroZEnable = value;
                    }
                }
            }

            public UInt16 FilterGyroZType
            {
                get { return filterGyroZType; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 13, value, typeof(UInt16), 1))
                    {
                        filterGyroZType = value;
                    }
                }
            }

            public UInt16 FilterMagXEnable
            {
                get { return filterMagXEnable; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 14, value, typeof(UInt16), 1))
                    {
                        filterMagXEnable = value;
                    }
                }
            }

            public UInt16 FilterMagXType
            {
                get { return filterMagXType; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 15, value, typeof(UInt16), 1))
                    {
                        filterMagXType = value;
                    }
                }
            }

            public UInt16 FilterMagYEnable
            {
                get { return filterMagYEnable; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 16, value, typeof(UInt16), 1))
                    {
                        filterMagYEnable = value;
                    }
                }
            }

            public UInt16 FilterMagYType
            {
                get { return filterMagYType; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 17, value, typeof(UInt16), 1))
                    {
                        filterMagYType = value;
                    }
                }
            }

            public UInt16 FilterMagZEnable
            {
                get { return filterMagZEnable; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 18, value, typeof(UInt16), 1))
                    {
                        filterMagZEnable = value;
                    }
                }
            }

            public UInt16 FilterMagZType
            {
                get { return filterMagZType; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 19, value, typeof(UInt16), 1))
                    {
                        filterMagZType = value;
                    }
                }
            }

            public UInt16 Enable
            {
                get { return enable; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 20, value, typeof(UInt16), 1))
                    {
                        enable = value;
                    }
                }
            }

            public bool ModbusWriteAll()
            {
                bool _status = true;
            
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, type, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 1, decRate, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 2, filterAccXEnable, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 3, filterAccXType, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 4, filterAccYEnable, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 5, filterAccYType, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 6, filterAccZEnable, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 7, filterAccZType, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 8, filterGyroXEnable, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 9, filterGyroXType, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 10, filterGyroYEnable, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 11, filterGyroYType, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 12, filterGyroZEnable, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 13, filterGyroZType, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 14, filterMagXEnable, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 15, filterMagXType, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 16, filterMagYEnable, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 17, filterMagYType, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 18, filterMagZEnable, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 19, filterMagZType, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 20, enable, typeof(UInt16), 1);
                
                if (!_status)
                {
                    MessageBox.Show("Writing all parameters failed!", "Modbus error ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return _status;
            }

            public void ModbusReadAll()
            {
                type = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 0, typeof(UInt16), 1);
                decRate = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 1, typeof(UInt16), 1);
                filterAccXEnable = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 2, typeof(UInt16), 1);
                filterAccXType = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 3, typeof(UInt16), 1);
                filterAccYEnable = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 4, typeof(UInt16), 1);
                filterAccYType = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 5, typeof(UInt16), 1);
                filterAccZEnable = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 6, typeof(UInt16), 1);
                filterAccZType = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 7, typeof(UInt16), 1);
                filterGyroXEnable = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 8, typeof(UInt16), 1);
                filterGyroXType = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 9, typeof(UInt16), 1);
                filterGyroYEnable = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 10, typeof(UInt16), 1);
                filterGyroYType = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 11, typeof(UInt16), 1);
                filterGyroZEnable = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 12, typeof(UInt16), 1);
                filterGyroZType = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 13, typeof(UInt16), 1);
                filterMagXEnable = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 14, typeof(UInt16), 1);
                filterMagXType = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 15, typeof(UInt16), 1);
                filterMagYEnable = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 16, typeof(UInt16), 1);
                filterMagYType = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 17, typeof(UInt16), 1);
                filterMagZEnable = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 18, typeof(UInt16), 1);
                filterMagZType = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 19, typeof(UInt16), 1);
                enable = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 20, typeof(UInt16), 1);
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class sSensorGpsData
        {
            public UInt32 iTOW;
            public UInt16 year;
            public UInt16 month;
            public UInt16 day;
            public UInt16 hours;
            public UInt16 min;
            public UInt16 sec;
            public UInt16 valid;
            public UInt32 tAcc;
            public Int32 nano;
            public UInt16 fixType;
            public UInt16 flags;
            public UInt16 flags2;
            public UInt16 numSV;
            public Double lon;
            public Double lat;
            public Double height;
            public Int32 hMSL;
            public UInt32 hAcc;
            public UInt32 vAcc;
            public Int32[] velNED;
            public Int32 gSpeed;
            public Int32 headMot;
            public UInt32 sAcc;
            public UInt32 headAcc;
            public UInt16 pDOP;
            public UInt16[] resesrved;
            public Int32 headVeh;
            public Int16 magDec;
            public UInt16 magAcc;
            public UInt32 frameCounter;
            public UInt32 frameErrorCounter;
            public UInt16 isValidData;
            public UInt16 isNewData;
            public UInt16 active;
            public UInt32 summaryStatus;

            private UInt16 ModbusBaseAddr;

            public static UInt16 ModbusSize = 67; // VarTypeSize in excel
            
            public sSensorGpsData(UInt16 ObjectModbusBaseAddr)
            {
                ModbusBaseAddr = ObjectModbusBaseAddr;

                iTOW = 0;
                year = 0;
                month = 0;
                day = 0;
                hours = 0;
                min = 0;
                sec = 0;
                valid = 0;
                tAcc = 0;
                nano = 0;
                fixType = 0;
                flags = 0;
                flags2 = 0;
                numSV = 0;
                lon = 0;
                lat = 0;
                height = 0;
                hMSL = 0;
                hAcc = 0;
                vAcc = 0;
                velNED = new Int32[3];
                gSpeed = 0;
                headMot = 0;
                sAcc = 0;
                headAcc = 0;
                pDOP = 0;
                resesrved = new UInt16[4];
                headVeh = 0;
                magDec = 0;
                magAcc = 0;
                frameCounter = 0;
                frameErrorCounter = 0;
                isValidData = 0;
                isNewData = 0;
                active = 0;
                summaryStatus = 0;
            }

            public UInt32 ITOW
            {
                get { return iTOW; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, value, typeof(UInt32), 1))
                    {
                        iTOW = value;
                    }
                }
            }

            public UInt16 Year
            {
                get { return year; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 2, value, typeof(UInt16), 1))
                    {
                        year = value;
                    }
                }
            }

            public UInt16 Month
            {
                get { return month; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 3, value, typeof(UInt16), 1))
                    {
                        month = value;
                    }
                }
            }

            public UInt16 Day
            {
                get { return day; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 4, value, typeof(UInt16), 1))
                    {
                        day = value;
                    }
                }
            }

            public UInt16 Hours
            {
                get { return hours; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 5, value, typeof(UInt16), 1))
                    {
                        hours = value;
                    }
                }
            }

            public UInt16 Min
            {
                get { return min; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 6, value, typeof(UInt16), 1))
                    {
                        min = value;
                    }
                }
            }

            public UInt16 Sec
            {
                get { return sec; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 7, value, typeof(UInt16), 1))
                    {
                        sec = value;
                    }
                }
            }

            public UInt16 Valid
            {
                get { return valid; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 8, value, typeof(UInt16), 1))
                    {
                        valid = value;
                    }
                }
            }

            public UInt32 TAcc
            {
                get { return tAcc; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 9, value, typeof(UInt32), 1))
                    {
                        tAcc = value;
                    }
                }
            }

            public Int32 Nano
            {
                get { return nano; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 11, value, typeof(Int32), 1))
                    {
                        nano = value;
                    }
                }
            }

            public UInt16 FixType
            {
                get { return fixType; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 13, value, typeof(UInt16), 1))
                    {
                        fixType = value;
                    }
                }
            }

            public UInt16 Flags
            {
                get { return flags; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 14, value, typeof(UInt16), 1))
                    {
                        flags = value;
                    }
                }
            }

            public UInt16 Flags2
            {
                get { return flags2; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 15, value, typeof(UInt16), 1))
                    {
                        flags2 = value;
                    }
                }
            }

            public UInt16 NumSV
            {
                get { return numSV; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 16, value, typeof(UInt16), 1))
                    {
                        numSV = value;
                    }
                }
            }

            public Double Lon
            {
                get { return lon; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 17, value, typeof(Double), 1))
                    {
                        lon = value;
                    }
                }
            }

            public Double Lat
            {
                get { return lat; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 21, value, typeof(Double), 1))
                    {
                        lat = value;
                    }
                }
            }

            public Double Height
            {
                get { return height; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 25, value, typeof(Double), 1))
                    {
                        height = value;
                    }
                }
            }

            public Int32 HMSL
            {
                get { return hMSL; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 29, value, typeof(Int32), 1))
                    {
                        hMSL = value;
                    }
                }
            }

            public UInt32 HAcc
            {
                get { return hAcc; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 31, value, typeof(UInt32), 1))
                    {
                        hAcc = value;
                    }
                }
            }

            public UInt32 VAcc
            {
                get { return vAcc; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 33, value, typeof(UInt32), 1))
                    {
                        vAcc = value;
                    }
                }
            }

            public Int32[] VelNED
            {
                get { return velNED; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 35, value, typeof(Int32), 3))
                    {
                        velNED = value;
                    }
                }
            }

            public Int32 GSpeed
            {
                get { return gSpeed; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 41, value, typeof(Int32), 1))
                    {
                        gSpeed = value;
                    }
                }
            }

            public Int32 HeadMot
            {
                get { return headMot; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 43, value, typeof(Int32), 1))
                    {
                        headMot = value;
                    }
                }
            }

            public UInt32 SAcc
            {
                get { return sAcc; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 45, value, typeof(UInt32), 1))
                    {
                        sAcc = value;
                    }
                }
            }

            public UInt32 HeadAcc
            {
                get { return headAcc; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 47, value, typeof(UInt32), 1))
                    {
                        headAcc = value;
                    }
                }
            }

            public UInt16 PDOP
            {
                get { return pDOP; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 49, value, typeof(UInt16), 1))
                    {
                        pDOP = value;
                    }
                }
            }

            public UInt16[] Resesrved
            {
                get { return resesrved; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 50, value, typeof(UInt16), 4))
                    {
                        resesrved = value;
                    }
                }
            }

            public Int32 HeadVeh
            {
                get { return headVeh; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 54, value, typeof(Int32), 1))
                    {
                        headVeh = value;
                    }
                }
            }

            public Int16 MagDec
            {
                get { return magDec; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 56, value, typeof(Int16), 1))
                    {
                        magDec = value;
                    }
                }
            }

            public UInt16 MagAcc
            {
                get { return magAcc; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 57, value, typeof(UInt16), 1))
                    {
                        magAcc = value;
                    }
                }
            }

            public UInt32 FrameCounter
            {
                get { return frameCounter; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 58, value, typeof(UInt32), 1))
                    {
                        frameCounter = value;
                    }
                }
            }

            public UInt32 FrameErrorCounter
            {
                get { return frameErrorCounter; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 60, value, typeof(UInt32), 1))
                    {
                        frameErrorCounter = value;
                    }
                }
            }

            public UInt16 IsValidData
            {
                get { return isValidData; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 62, value, typeof(UInt16), 1))
                    {
                        isValidData = value;
                    }
                }
            }

            public UInt16 IsNewData
            {
                get { return isNewData; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 63, value, typeof(UInt16), 1))
                    {
                        isNewData = value;
                    }
                }
            }

            public UInt16 Active
            {
                get { return active; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 64, value, typeof(UInt16), 1))
                    {
                        active = value;
                    }
                }
            }

            public UInt32 SummaryStatus
            {
                get { return summaryStatus; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 65, value, typeof(UInt32), 1))
                    {
                        summaryStatus = value;
                    }
                }
            }

            public bool ModbusWriteAll()
            {
                bool _status = true;
            
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, iTOW, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 2, year, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 3, month, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 4, day, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 5, hours, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 6, min, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 7, sec, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 8, valid, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 9, tAcc, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 11, nano, typeof(Int32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 13, fixType, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 14, flags, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 15, flags2, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 16, numSV, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 17, lon, typeof(Double), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 21, lat, typeof(Double), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 25, height, typeof(Double), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 29, hMSL, typeof(Int32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 31, hAcc, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 33, vAcc, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 35, velNED, typeof(Int32), 3);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 41, gSpeed, typeof(Int32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 43, headMot, typeof(Int32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 45, sAcc, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 47, headAcc, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 49, pDOP, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 50, resesrved, typeof(UInt16), 4);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 54, headVeh, typeof(Int32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 56, magDec, typeof(Int16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 57, magAcc, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 58, frameCounter, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 60, frameErrorCounter, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 62, isValidData, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 63, isNewData, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 64, active, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 65, summaryStatus, typeof(UInt32), 1);
                
                if (!_status)
                {
                    MessageBox.Show("Writing all parameters failed!", "Modbus error ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return _status;
            }

            public void ModbusReadAll()
            {
                iTOW = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 0, typeof(UInt32), 1);
                year = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 2, typeof(UInt16), 1);
                month = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 3, typeof(UInt16), 1);
                day = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 4, typeof(UInt16), 1);
                hours = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 5, typeof(UInt16), 1);
                min = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 6, typeof(UInt16), 1);
                sec = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 7, typeof(UInt16), 1);
                valid = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 8, typeof(UInt16), 1);
                tAcc = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 9, typeof(UInt32), 1);
                nano = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 11, typeof(Int32), 1);
                fixType = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 13, typeof(UInt16), 1);
                flags = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 14, typeof(UInt16), 1);
                flags2 = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 15, typeof(UInt16), 1);
                numSV = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 16, typeof(UInt16), 1);
                lon = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 17, typeof(Double), 1);
                lat = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 21, typeof(Double), 1);
                height = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 25, typeof(Double), 1);
                hMSL = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 29, typeof(Int32), 1);
                hAcc = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 31, typeof(UInt32), 1);
                vAcc = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 33, typeof(UInt32), 1);
                velNED = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 35, typeof(Int32), 3);
                gSpeed = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 41, typeof(Int32), 1);
                headMot = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 43, typeof(Int32), 1);
                sAcc = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 45, typeof(UInt32), 1);
                headAcc = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 47, typeof(UInt32), 1);
                pDOP = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 49, typeof(UInt16), 1);
                resesrved = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 50, typeof(UInt16), 4);
                headVeh = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 54, typeof(Int32), 1);
                magDec = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 56, typeof(Int16), 1);
                magAcc = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 57, typeof(UInt16), 1);
                frameCounter = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 58, typeof(UInt32), 1);
                frameErrorCounter = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 60, typeof(UInt32), 1);
                isValidData = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 62, typeof(UInt16), 1);
                isNewData = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 63, typeof(UInt16), 1);
                active = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 64, typeof(UInt16), 1);
                summaryStatus = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 65, typeof(UInt32), 1);
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class sSensorGpsSetting
        {
            public UInt32 baudRate;
            public UInt16 enable;

            private UInt16 ModbusBaseAddr;

            public static UInt16 ModbusSize = 3; // VarTypeSize in excel
            
            public sSensorGpsSetting(UInt16 ObjectModbusBaseAddr)
            {
                ModbusBaseAddr = ObjectModbusBaseAddr;

                baudRate = 0;
                enable = 0;
            }

            public UInt32 BaudRate
            {
                get { return baudRate; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, value, typeof(UInt32), 1))
                    {
                        baudRate = value;
                    }
                }
            }

            public UInt16 Enable
            {
                get { return enable; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 2, value, typeof(UInt16), 1))
                    {
                        enable = value;
                    }
                }
            }

            public bool ModbusWriteAll()
            {
                bool _status = true;
            
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, baudRate, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 2, enable, typeof(UInt16), 1);
                
                if (!_status)
                {
                    MessageBox.Show("Writing all parameters failed!", "Modbus error ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return _status;
            }

            public void ModbusReadAll()
            {
                baudRate = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 0, typeof(UInt32), 1);
                enable = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 2, typeof(UInt16), 1);
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class sSensorDadcData
        {
            public UInt16 adc_IsNewData;
            public UInt16 adc_Unit;
            public Single adc_OutsideProbeTemp;
            public Single adc_InternalProbeTemp;
            public Single adc_StaticPressure;
            public Single adc_PitotDiffPressure;
            public UInt16 ada_IsNewData;
            public UInt16 ada_Unit;
            public Single ada_PressureAltitude;
            public Single ada_IndicatedAltitude;
            public Single ada_TrueAltitude;
            public Single ada_RateOfClimb;
            public Single ada_OutsideAirTemperature;
            public Single ada_TotalAirTemperature;
            public Single ada_DiffOutsideAirTempAnd_ISA;
            public UInt16 adv_IsNewData;
            public UInt16 adv_Unit;
            public Single adv_CalibratedAirSpeed;
            public Single adv_TrueAirspeed;
            public Single adv_MachNum;
            public Single adv_AirDensity;
            public UInt16 adr_IsNewData;
            public Single adr_CpuTemp;
            public Single adr_OutsideRtd_mv;
            public Single adr_InsideRtd_mv;
            public Single adr_static_press_v;
            public Single adr_diff_press_v;
            public UInt16 active;
            public UInt32 summaryStatus;

            private UInt16 ModbusBaseAddr;

            public static UInt16 ModbusSize = 50; // VarTypeSize in excel
            
            public sSensorDadcData(UInt16 ObjectModbusBaseAddr)
            {
                ModbusBaseAddr = ObjectModbusBaseAddr;

                adc_IsNewData = 0;
                adc_Unit = 0;
                adc_OutsideProbeTemp = 0;
                adc_InternalProbeTemp = 0;
                adc_StaticPressure = 0;
                adc_PitotDiffPressure = 0;
                ada_IsNewData = 0;
                ada_Unit = 0;
                ada_PressureAltitude = 0;
                ada_IndicatedAltitude = 0;
                ada_TrueAltitude = 0;
                ada_RateOfClimb = 0;
                ada_OutsideAirTemperature = 0;
                ada_TotalAirTemperature = 0;
                ada_DiffOutsideAirTempAnd_ISA = 0;
                adv_IsNewData = 0;
                adv_Unit = 0;
                adv_CalibratedAirSpeed = 0;
                adv_TrueAirspeed = 0;
                adv_MachNum = 0;
                adv_AirDensity = 0;
                adr_IsNewData = 0;
                adr_CpuTemp = 0;
                adr_OutsideRtd_mv = 0;
                adr_InsideRtd_mv = 0;
                adr_static_press_v = 0;
                adr_diff_press_v = 0;
                active = 0;
                summaryStatus = 0;
            }

            public UInt16 Adc_IsNewData
            {
                get { return adc_IsNewData; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, value, typeof(UInt16), 1))
                    {
                        adc_IsNewData = value;
                    }
                }
            }

            public UInt16 Adc_Unit
            {
                get { return adc_Unit; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 1, value, typeof(UInt16), 1))
                    {
                        adc_Unit = value;
                    }
                }
            }

            public Single Adc_OutsideProbeTemp
            {
                get { return adc_OutsideProbeTemp; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 2, value, typeof(Single), 1))
                    {
                        adc_OutsideProbeTemp = value;
                    }
                }
            }

            public Single Adc_InternalProbeTemp
            {
                get { return adc_InternalProbeTemp; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 4, value, typeof(Single), 1))
                    {
                        adc_InternalProbeTemp = value;
                    }
                }
            }

            public Single Adc_StaticPressure
            {
                get { return adc_StaticPressure; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 6, value, typeof(Single), 1))
                    {
                        adc_StaticPressure = value;
                    }
                }
            }

            public Single Adc_PitotDiffPressure
            {
                get { return adc_PitotDiffPressure; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 8, value, typeof(Single), 1))
                    {
                        adc_PitotDiffPressure = value;
                    }
                }
            }

            public UInt16 Ada_IsNewData
            {
                get { return ada_IsNewData; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 10, value, typeof(UInt16), 1))
                    {
                        ada_IsNewData = value;
                    }
                }
            }

            public UInt16 Ada_Unit
            {
                get { return ada_Unit; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 11, value, typeof(UInt16), 1))
                    {
                        ada_Unit = value;
                    }
                }
            }

            public Single Ada_PressureAltitude
            {
                get { return ada_PressureAltitude; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 12, value, typeof(Single), 1))
                    {
                        ada_PressureAltitude = value;
                    }
                }
            }

            public Single Ada_IndicatedAltitude
            {
                get { return ada_IndicatedAltitude; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 14, value, typeof(Single), 1))
                    {
                        ada_IndicatedAltitude = value;
                    }
                }
            }

            public Single Ada_TrueAltitude
            {
                get { return ada_TrueAltitude; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 16, value, typeof(Single), 1))
                    {
                        ada_TrueAltitude = value;
                    }
                }
            }

            public Single Ada_RateOfClimb
            {
                get { return ada_RateOfClimb; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 18, value, typeof(Single), 1))
                    {
                        ada_RateOfClimb = value;
                    }
                }
            }

            public Single Ada_OutsideAirTemperature
            {
                get { return ada_OutsideAirTemperature; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 20, value, typeof(Single), 1))
                    {
                        ada_OutsideAirTemperature = value;
                    }
                }
            }

            public Single Ada_TotalAirTemperature
            {
                get { return ada_TotalAirTemperature; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 22, value, typeof(Single), 1))
                    {
                        ada_TotalAirTemperature = value;
                    }
                }
            }

            public Single Ada_DiffOutsideAirTempAnd_ISA
            {
                get { return ada_DiffOutsideAirTempAnd_ISA; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 24, value, typeof(Single), 1))
                    {
                        ada_DiffOutsideAirTempAnd_ISA = value;
                    }
                }
            }

            public UInt16 Adv_IsNewData
            {
                get { return adv_IsNewData; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 26, value, typeof(UInt16), 1))
                    {
                        adv_IsNewData = value;
                    }
                }
            }

            public UInt16 Adv_Unit
            {
                get { return adv_Unit; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 27, value, typeof(UInt16), 1))
                    {
                        adv_Unit = value;
                    }
                }
            }

            public Single Adv_CalibratedAirSpeed
            {
                get { return adv_CalibratedAirSpeed; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 28, value, typeof(Single), 1))
                    {
                        adv_CalibratedAirSpeed = value;
                    }
                }
            }

            public Single Adv_TrueAirspeed
            {
                get { return adv_TrueAirspeed; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 30, value, typeof(Single), 1))
                    {
                        adv_TrueAirspeed = value;
                    }
                }
            }

            public Single Adv_MachNum
            {
                get { return adv_MachNum; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 32, value, typeof(Single), 1))
                    {
                        adv_MachNum = value;
                    }
                }
            }

            public Single Adv_AirDensity
            {
                get { return adv_AirDensity; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 34, value, typeof(Single), 1))
                    {
                        adv_AirDensity = value;
                    }
                }
            }

            public UInt16 Adr_IsNewData
            {
                get { return adr_IsNewData; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 36, value, typeof(UInt16), 1))
                    {
                        adr_IsNewData = value;
                    }
                }
            }

            public Single Adr_CpuTemp
            {
                get { return adr_CpuTemp; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 37, value, typeof(Single), 1))
                    {
                        adr_CpuTemp = value;
                    }
                }
            }

            public Single Adr_OutsideRtd_mv
            {
                get { return adr_OutsideRtd_mv; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 39, value, typeof(Single), 1))
                    {
                        adr_OutsideRtd_mv = value;
                    }
                }
            }

            public Single Adr_InsideRtd_mv
            {
                get { return adr_InsideRtd_mv; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 41, value, typeof(Single), 1))
                    {
                        adr_InsideRtd_mv = value;
                    }
                }
            }

            public Single Adr_static_press_v
            {
                get { return adr_static_press_v; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 43, value, typeof(Single), 1))
                    {
                        adr_static_press_v = value;
                    }
                }
            }

            public Single Adr_diff_press_v
            {
                get { return adr_diff_press_v; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 45, value, typeof(Single), 1))
                    {
                        adr_diff_press_v = value;
                    }
                }
            }

            public UInt16 Active
            {
                get { return active; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 47, value, typeof(UInt16), 1))
                    {
                        active = value;
                    }
                }
            }

            public UInt32 SummaryStatus
            {
                get { return summaryStatus; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 48, value, typeof(UInt32), 1))
                    {
                        summaryStatus = value;
                    }
                }
            }

            public bool ModbusWriteAll()
            {
                bool _status = true;
            
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, adc_IsNewData, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 1, adc_Unit, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 2, adc_OutsideProbeTemp, typeof(Single), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 4, adc_InternalProbeTemp, typeof(Single), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 6, adc_StaticPressure, typeof(Single), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 8, adc_PitotDiffPressure, typeof(Single), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 10, ada_IsNewData, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 11, ada_Unit, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 12, ada_PressureAltitude, typeof(Single), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 14, ada_IndicatedAltitude, typeof(Single), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 16, ada_TrueAltitude, typeof(Single), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 18, ada_RateOfClimb, typeof(Single), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 20, ada_OutsideAirTemperature, typeof(Single), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 22, ada_TotalAirTemperature, typeof(Single), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 24, ada_DiffOutsideAirTempAnd_ISA, typeof(Single), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 26, adv_IsNewData, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 27, adv_Unit, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 28, adv_CalibratedAirSpeed, typeof(Single), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 30, adv_TrueAirspeed, typeof(Single), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 32, adv_MachNum, typeof(Single), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 34, adv_AirDensity, typeof(Single), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 36, adr_IsNewData, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 37, adr_CpuTemp, typeof(Single), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 39, adr_OutsideRtd_mv, typeof(Single), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 41, adr_InsideRtd_mv, typeof(Single), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 43, adr_static_press_v, typeof(Single), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 45, adr_diff_press_v, typeof(Single), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 47, active, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 48, summaryStatus, typeof(UInt32), 1);
                
                if (!_status)
                {
                    MessageBox.Show("Writing all parameters failed!", "Modbus error ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return _status;
            }

            public void ModbusReadAll()
            {
                adc_IsNewData = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 0, typeof(UInt16), 1);
                adc_Unit = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 1, typeof(UInt16), 1);
                adc_OutsideProbeTemp = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 2, typeof(Single), 1);
                adc_InternalProbeTemp = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 4, typeof(Single), 1);
                adc_StaticPressure = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 6, typeof(Single), 1);
                adc_PitotDiffPressure = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 8, typeof(Single), 1);
                ada_IsNewData = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 10, typeof(UInt16), 1);
                ada_Unit = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 11, typeof(UInt16), 1);
                ada_PressureAltitude = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 12, typeof(Single), 1);
                ada_IndicatedAltitude = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 14, typeof(Single), 1);
                ada_TrueAltitude = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 16, typeof(Single), 1);
                ada_RateOfClimb = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 18, typeof(Single), 1);
                ada_OutsideAirTemperature = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 20, typeof(Single), 1);
                ada_TotalAirTemperature = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 22, typeof(Single), 1);
                ada_DiffOutsideAirTempAnd_ISA = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 24, typeof(Single), 1);
                adv_IsNewData = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 26, typeof(UInt16), 1);
                adv_Unit = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 27, typeof(UInt16), 1);
                adv_CalibratedAirSpeed = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 28, typeof(Single), 1);
                adv_TrueAirspeed = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 30, typeof(Single), 1);
                adv_MachNum = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 32, typeof(Single), 1);
                adv_AirDensity = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 34, typeof(Single), 1);
                adr_IsNewData = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 36, typeof(UInt16), 1);
                adr_CpuTemp = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 37, typeof(Single), 1);
                adr_OutsideRtd_mv = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 39, typeof(Single), 1);
                adr_InsideRtd_mv = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 41, typeof(Single), 1);
                adr_static_press_v = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 43, typeof(Single), 1);
                adr_diff_press_v = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 45, typeof(Single), 1);
                active = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 47, typeof(UInt16), 1);
                summaryStatus = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 48, typeof(UInt32), 1);
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class sSensorDadcSetting
        {
            public UInt16 enable;

            private UInt16 ModbusBaseAddr;

            public static UInt16 ModbusSize = 1; // VarTypeSize in excel
            
            public sSensorDadcSetting(UInt16 ObjectModbusBaseAddr)
            {
                ModbusBaseAddr = ObjectModbusBaseAddr;

                enable = 0;
            }

            public UInt16 Enable
            {
                get { return enable; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, value, typeof(UInt16), 1))
                    {
                        enable = value;
                    }
                }
            }

            public bool ModbusWriteAll()
            {
                bool _status = true;
            
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, enable, typeof(UInt16), 1);
                
                if (!_status)
                {
                    MessageBox.Show("Writing all parameters failed!", "Modbus error ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return _status;
            }

            public void ModbusReadAll()
            {
                enable = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 0, typeof(UInt16), 1);
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class sSensorHmc5983Data
        {
            public s3dI16 mag;
            public Double temperature;
            public UInt16 isNewData;
            public UInt16 active;
            public UInt32 summaryStatus;

            private UInt16 ModbusBaseAddr;

            public static UInt16 ModbusSize = 11; // VarTypeSize in excel
            
            public sSensorHmc5983Data(UInt16 ObjectModbusBaseAddr)
            {
                ModbusBaseAddr = ObjectModbusBaseAddr;

                mag = new s3dI16((UInt16)(ModbusBaseAddr + 0));
                temperature = 0;
                isNewData = 0;
                active = 0;
                summaryStatus = 0;
            }

            public s3dI16 Mag
            {
                get { return mag; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, value, typeof(s3dI16), 1))
                    {
                        mag = value;
                    }
                }
            }

            public Double Temperature
            {
                get { return temperature; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 3, value, typeof(Double), 1))
                    {
                        temperature = value;
                    }
                }
            }

            public UInt16 IsNewData
            {
                get { return isNewData; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 7, value, typeof(UInt16), 1))
                    {
                        isNewData = value;
                    }
                }
            }

            public UInt16 Active
            {
                get { return active; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 8, value, typeof(UInt16), 1))
                    {
                        active = value;
                    }
                }
            }

            public UInt32 SummaryStatus
            {
                get { return summaryStatus; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 9, value, typeof(UInt32), 1))
                    {
                        summaryStatus = value;
                    }
                }
            }

            public bool ModbusWriteAll()
            {
                bool _status = true;
            
                _status &= mag.ModbusWriteAll();
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 3, temperature, typeof(Double), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 7, isNewData, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 8, active, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 9, summaryStatus, typeof(UInt32), 1);
                
                if (!_status)
                {
                    MessageBox.Show("Writing all parameters failed!", "Modbus error ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return _status;
            }

            public void ModbusReadAll()
            {
                mag.ModbusReadAll();
                temperature = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 3, typeof(Double), 1);
                isNewData = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 7, typeof(UInt16), 1);
                active = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 8, typeof(UInt16), 1);
                summaryStatus = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 9, typeof(UInt32), 1);
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class sSensorHmc5983Setting
        {
            public UInt16 odr;
            public UInt16 sampleAverage;
            public UInt16 gain;
            public UInt16 enable;

            private UInt16 ModbusBaseAddr;

            public static UInt16 ModbusSize = 4; // VarTypeSize in excel
            
            public sSensorHmc5983Setting(UInt16 ObjectModbusBaseAddr)
            {
                ModbusBaseAddr = ObjectModbusBaseAddr;

                odr = 0;
                sampleAverage = 0;
                gain = 0;
                enable = 0;
            }

            public UInt16 Odr
            {
                get { return odr; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, value, typeof(UInt16), 1))
                    {
                        odr = value;
                    }
                }
            }

            public UInt16 SampleAverage
            {
                get { return sampleAverage; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 1, value, typeof(UInt16), 1))
                    {
                        sampleAverage = value;
                    }
                }
            }

            public UInt16 Gain
            {
                get { return gain; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 2, value, typeof(UInt16), 1))
                    {
                        gain = value;
                    }
                }
            }

            public UInt16 Enable
            {
                get { return enable; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 3, value, typeof(UInt16), 1))
                    {
                        enable = value;
                    }
                }
            }

            public bool ModbusWriteAll()
            {
                bool _status = true;
            
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, odr, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 1, sampleAverage, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 2, gain, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 3, enable, typeof(UInt16), 1);
                
                if (!_status)
                {
                    MessageBox.Show("Writing all parameters failed!", "Modbus error ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return _status;
            }

            public void ModbusReadAll()
            {
                odr = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 0, typeof(UInt16), 1);
                sampleAverage = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 1, typeof(UInt16), 1);
                gain = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 2, typeof(UInt16), 1);
                enable = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 3, typeof(UInt16), 1);
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class sSensorMs5611Data
        {
            public Single press;
            public Single temperature;
            public UInt16 isNewData;
            public UInt16 active;
            public UInt32 summaryStatus;

            private UInt16 ModbusBaseAddr;

            public static UInt16 ModbusSize = 8; // VarTypeSize in excel
            
            public sSensorMs5611Data(UInt16 ObjectModbusBaseAddr)
            {
                ModbusBaseAddr = ObjectModbusBaseAddr;

                press = 0;
                temperature = 0;
                isNewData = 0;
                active = 0;
                summaryStatus = 0;
            }

            public Single Press
            {
                get { return press; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, value, typeof(Single), 1))
                    {
                        press = value;
                    }
                }
            }

            public Single Temperature
            {
                get { return temperature; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 2, value, typeof(Single), 1))
                    {
                        temperature = value;
                    }
                }
            }

            public UInt16 IsNewData
            {
                get { return isNewData; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 4, value, typeof(UInt16), 1))
                    {
                        isNewData = value;
                    }
                }
            }

            public UInt16 Active
            {
                get { return active; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 5, value, typeof(UInt16), 1))
                    {
                        active = value;
                    }
                }
            }

            public UInt32 SummaryStatus
            {
                get { return summaryStatus; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 6, value, typeof(UInt32), 1))
                    {
                        summaryStatus = value;
                    }
                }
            }

            public bool ModbusWriteAll()
            {
                bool _status = true;
            
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, press, typeof(Single), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 2, temperature, typeof(Single), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 4, isNewData, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 5, active, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 6, summaryStatus, typeof(UInt32), 1);
                
                if (!_status)
                {
                    MessageBox.Show("Writing all parameters failed!", "Modbus error ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return _status;
            }

            public void ModbusReadAll()
            {
                press = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 0, typeof(Single), 1);
                temperature = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 2, typeof(Single), 1);
                isNewData = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 4, typeof(UInt16), 1);
                active = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 5, typeof(UInt16), 1);
                summaryStatus = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 6, typeof(UInt32), 1);
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class sSensorMs5611Setting
        {
            public UInt16 osr;
            public UInt16 enable;

            private UInt16 ModbusBaseAddr;

            public static UInt16 ModbusSize = 2; // VarTypeSize in excel
            
            public sSensorMs5611Setting(UInt16 ObjectModbusBaseAddr)
            {
                ModbusBaseAddr = ObjectModbusBaseAddr;

                osr = 0;
                enable = 0;
            }

            public UInt16 Osr
            {
                get { return osr; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, value, typeof(UInt16), 1))
                    {
                        osr = value;
                    }
                }
            }

            public UInt16 Enable
            {
                get { return enable; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 1, value, typeof(UInt16), 1))
                    {
                        enable = value;
                    }
                }
            }

            public bool ModbusWriteAll()
            {
                bool _status = true;
            
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, osr, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 1, enable, typeof(UInt16), 1);
                
                if (!_status)
                {
                    MessageBox.Show("Writing all parameters failed!", "Modbus error ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return _status;
            }

            public void ModbusReadAll()
            {
                osr = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 0, typeof(UInt16), 1);
                enable = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 1, typeof(UInt16), 1);
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class sSensorIBNS_MatchData
        {
            public UInt32 jetsonTime_UTC;
            public Double rawLat_deg;
            public Double rawLon_deg;
            public Double estLat_deg;
            public Double estLon_deg;
            public Double aGL_m;
            public Double demAlt_m;
            public Double rollFus_deg;
            public Double pitchFus_deg;
            public Double yawFus_deg;
            public Double heading_deg;
            public Double coures_deg;
            public UInt16 qualityMatch;
            public UInt16 statusFlags;
            public UInt32 updateMask;
            public UInt16 excutionTimeMs;
            public UInt16 isNewData;
            public UInt16 active;
            public UInt32 summaryStatus;

            private UInt16 ModbusBaseAddr;

            public static UInt16 ModbusSize = 55; // VarTypeSize in excel
            
            public sSensorIBNS_MatchData(UInt16 ObjectModbusBaseAddr)
            {
                ModbusBaseAddr = ObjectModbusBaseAddr;

                jetsonTime_UTC = 0;
                rawLat_deg = 0;
                rawLon_deg = 0;
                estLat_deg = 0;
                estLon_deg = 0;
                aGL_m = 0;
                demAlt_m = 0;
                rollFus_deg = 0;
                pitchFus_deg = 0;
                yawFus_deg = 0;
                heading_deg = 0;
                coures_deg = 0;
                qualityMatch = 0;
                statusFlags = 0;
                updateMask = 0;
                excutionTimeMs = 0;
                isNewData = 0;
                active = 0;
                summaryStatus = 0;
            }

            public UInt32 JetsonTime_UTC
            {
                get { return jetsonTime_UTC; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, value, typeof(UInt32), 1))
                    {
                        jetsonTime_UTC = value;
                    }
                }
            }

            public Double RawLat_deg
            {
                get { return rawLat_deg; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 2, value, typeof(Double), 1))
                    {
                        rawLat_deg = value;
                    }
                }
            }

            public Double RawLon_deg
            {
                get { return rawLon_deg; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 6, value, typeof(Double), 1))
                    {
                        rawLon_deg = value;
                    }
                }
            }

            public Double EstLat_deg
            {
                get { return estLat_deg; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 10, value, typeof(Double), 1))
                    {
                        estLat_deg = value;
                    }
                }
            }

            public Double EstLon_deg
            {
                get { return estLon_deg; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 14, value, typeof(Double), 1))
                    {
                        estLon_deg = value;
                    }
                }
            }

            public Double AGL_m
            {
                get { return aGL_m; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 18, value, typeof(Double), 1))
                    {
                        aGL_m = value;
                    }
                }
            }

            public Double DemAlt_m
            {
                get { return demAlt_m; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 22, value, typeof(Double), 1))
                    {
                        demAlt_m = value;
                    }
                }
            }

            public Double RollFus_deg
            {
                get { return rollFus_deg; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 26, value, typeof(Double), 1))
                    {
                        rollFus_deg = value;
                    }
                }
            }

            public Double PitchFus_deg
            {
                get { return pitchFus_deg; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 30, value, typeof(Double), 1))
                    {
                        pitchFus_deg = value;
                    }
                }
            }

            public Double YawFus_deg
            {
                get { return yawFus_deg; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 34, value, typeof(Double), 1))
                    {
                        yawFus_deg = value;
                    }
                }
            }

            public Double Heading_deg
            {
                get { return heading_deg; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 38, value, typeof(Double), 1))
                    {
                        heading_deg = value;
                    }
                }
            }

            public Double Coures_deg
            {
                get { return coures_deg; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 42, value, typeof(Double), 1))
                    {
                        coures_deg = value;
                    }
                }
            }

            public UInt16 QualityMatch
            {
                get { return qualityMatch; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 46, value, typeof(UInt16), 1))
                    {
                        qualityMatch = value;
                    }
                }
            }

            public UInt16 StatusFlags
            {
                get { return statusFlags; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 47, value, typeof(UInt16), 1))
                    {
                        statusFlags = value;
                    }
                }
            }

            public UInt32 UpdateMask
            {
                get { return updateMask; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 48, value, typeof(UInt32), 1))
                    {
                        updateMask = value;
                    }
                }
            }

            public UInt16 ExcutionTimeMs
            {
                get { return excutionTimeMs; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 50, value, typeof(UInt16), 1))
                    {
                        excutionTimeMs = value;
                    }
                }
            }

            public UInt16 IsNewData
            {
                get { return isNewData; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 51, value, typeof(UInt16), 1))
                    {
                        isNewData = value;
                    }
                }
            }

            public UInt16 Active
            {
                get { return active; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 52, value, typeof(UInt16), 1))
                    {
                        active = value;
                    }
                }
            }

            public UInt32 SummaryStatus
            {
                get { return summaryStatus; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 53, value, typeof(UInt32), 1))
                    {
                        summaryStatus = value;
                    }
                }
            }

            public bool ModbusWriteAll()
            {
                bool _status = true;
            
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, jetsonTime_UTC, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 2, rawLat_deg, typeof(Double), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 6, rawLon_deg, typeof(Double), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 10, estLat_deg, typeof(Double), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 14, estLon_deg, typeof(Double), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 18, aGL_m, typeof(Double), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 22, demAlt_m, typeof(Double), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 26, rollFus_deg, typeof(Double), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 30, pitchFus_deg, typeof(Double), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 34, yawFus_deg, typeof(Double), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 38, heading_deg, typeof(Double), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 42, coures_deg, typeof(Double), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 46, qualityMatch, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 47, statusFlags, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 48, updateMask, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 50, excutionTimeMs, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 51, isNewData, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 52, active, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 53, summaryStatus, typeof(UInt32), 1);
                
                if (!_status)
                {
                    MessageBox.Show("Writing all parameters failed!", "Modbus error ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return _status;
            }

            public void ModbusReadAll()
            {
                jetsonTime_UTC = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 0, typeof(UInt32), 1);
                rawLat_deg = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 2, typeof(Double), 1);
                rawLon_deg = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 6, typeof(Double), 1);
                estLat_deg = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 10, typeof(Double), 1);
                estLon_deg = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 14, typeof(Double), 1);
                aGL_m = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 18, typeof(Double), 1);
                demAlt_m = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 22, typeof(Double), 1);
                rollFus_deg = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 26, typeof(Double), 1);
                pitchFus_deg = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 30, typeof(Double), 1);
                yawFus_deg = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 34, typeof(Double), 1);
                heading_deg = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 38, typeof(Double), 1);
                coures_deg = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 42, typeof(Double), 1);
                qualityMatch = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 46, typeof(UInt16), 1);
                statusFlags = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 47, typeof(UInt16), 1);
                updateMask = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 48, typeof(UInt32), 1);
                excutionTimeMs = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 50, typeof(UInt16), 1);
                isNewData = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 51, typeof(UInt16), 1);
                active = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 52, typeof(UInt16), 1);
                summaryStatus = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 53, typeof(UInt32), 1);
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class sSensorIBNS_MatchSetting
        {
            public UInt16 enable;

            private UInt16 ModbusBaseAddr;

            public static UInt16 ModbusSize = 1; // VarTypeSize in excel
            
            public sSensorIBNS_MatchSetting(UInt16 ObjectModbusBaseAddr)
            {
                ModbusBaseAddr = ObjectModbusBaseAddr;

                enable = 0;
            }

            public UInt16 Enable
            {
                get { return enable; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, value, typeof(UInt16), 1))
                    {
                        enable = value;
                    }
                }
            }

            public bool ModbusWriteAll()
            {
                bool _status = true;
            
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, enable, typeof(UInt16), 1);
                
                if (!_status)
                {
                    MessageBox.Show("Writing all parameters failed!", "Modbus error ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return _status;
            }

            public void ModbusReadAll()
            {
                enable = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 0, typeof(UInt16), 1);
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class sSensorIBNS_SpeedData
        {
            public UInt32 jetsonTime_UTC;
            public Double oDOLat_deg;
            public Double oDOLon_deg;
            public Double alt_m;
            public Double rollFus_deg;
            public Double pitchFus_deg;
            public Double yawFus_deg;
            public Double speed_mps;
            public UInt16 qualitySpeed;
            public Double oDO_DX_m;
            public Double oDO_DY_m;
            public UInt16 statusFlags;
            public UInt32 updateMask;
            public UInt16 excutionTime_ms;
            public UInt16 isNewData;
            public UInt16 active;
            public UInt32 summaryStatus;

            private UInt16 ModbusBaseAddr;

            public static UInt16 ModbusSize = 47; // VarTypeSize in excel
            
            public sSensorIBNS_SpeedData(UInt16 ObjectModbusBaseAddr)
            {
                ModbusBaseAddr = ObjectModbusBaseAddr;

                jetsonTime_UTC = 0;
                oDOLat_deg = 0;
                oDOLon_deg = 0;
                alt_m = 0;
                rollFus_deg = 0;
                pitchFus_deg = 0;
                yawFus_deg = 0;
                speed_mps = 0;
                qualitySpeed = 0;
                oDO_DX_m = 0;
                oDO_DY_m = 0;
                statusFlags = 0;
                updateMask = 0;
                excutionTime_ms = 0;
                isNewData = 0;
                active = 0;
                summaryStatus = 0;
            }

            public UInt32 JetsonTime_UTC
            {
                get { return jetsonTime_UTC; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, value, typeof(UInt32), 1))
                    {
                        jetsonTime_UTC = value;
                    }
                }
            }

            public Double ODOLat_deg
            {
                get { return oDOLat_deg; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 2, value, typeof(Double), 1))
                    {
                        oDOLat_deg = value;
                    }
                }
            }

            public Double ODOLon_deg
            {
                get { return oDOLon_deg; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 6, value, typeof(Double), 1))
                    {
                        oDOLon_deg = value;
                    }
                }
            }

            public Double Alt_m
            {
                get { return alt_m; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 10, value, typeof(Double), 1))
                    {
                        alt_m = value;
                    }
                }
            }

            public Double RollFus_deg
            {
                get { return rollFus_deg; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 14, value, typeof(Double), 1))
                    {
                        rollFus_deg = value;
                    }
                }
            }

            public Double PitchFus_deg
            {
                get { return pitchFus_deg; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 18, value, typeof(Double), 1))
                    {
                        pitchFus_deg = value;
                    }
                }
            }

            public Double YawFus_deg
            {
                get { return yawFus_deg; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 22, value, typeof(Double), 1))
                    {
                        yawFus_deg = value;
                    }
                }
            }

            public Double Speed_mps
            {
                get { return speed_mps; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 26, value, typeof(Double), 1))
                    {
                        speed_mps = value;
                    }
                }
            }

            public UInt16 QualitySpeed
            {
                get { return qualitySpeed; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 30, value, typeof(UInt16), 1))
                    {
                        qualitySpeed = value;
                    }
                }
            }

            public Double ODO_DX_m
            {
                get { return oDO_DX_m; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 31, value, typeof(Double), 1))
                    {
                        oDO_DX_m = value;
                    }
                }
            }

            public Double ODO_DY_m
            {
                get { return oDO_DY_m; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 35, value, typeof(Double), 1))
                    {
                        oDO_DY_m = value;
                    }
                }
            }

            public UInt16 StatusFlags
            {
                get { return statusFlags; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 39, value, typeof(UInt16), 1))
                    {
                        statusFlags = value;
                    }
                }
            }

            public UInt32 UpdateMask
            {
                get { return updateMask; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 40, value, typeof(UInt32), 1))
                    {
                        updateMask = value;
                    }
                }
            }

            public UInt16 ExcutionTime_ms
            {
                get { return excutionTime_ms; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 42, value, typeof(UInt16), 1))
                    {
                        excutionTime_ms = value;
                    }
                }
            }

            public UInt16 IsNewData
            {
                get { return isNewData; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 43, value, typeof(UInt16), 1))
                    {
                        isNewData = value;
                    }
                }
            }

            public UInt16 Active
            {
                get { return active; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 44, value, typeof(UInt16), 1))
                    {
                        active = value;
                    }
                }
            }

            public UInt32 SummaryStatus
            {
                get { return summaryStatus; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 45, value, typeof(UInt32), 1))
                    {
                        summaryStatus = value;
                    }
                }
            }

            public bool ModbusWriteAll()
            {
                bool _status = true;
            
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, jetsonTime_UTC, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 2, oDOLat_deg, typeof(Double), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 6, oDOLon_deg, typeof(Double), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 10, alt_m, typeof(Double), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 14, rollFus_deg, typeof(Double), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 18, pitchFus_deg, typeof(Double), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 22, yawFus_deg, typeof(Double), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 26, speed_mps, typeof(Double), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 30, qualitySpeed, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 31, oDO_DX_m, typeof(Double), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 35, oDO_DY_m, typeof(Double), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 39, statusFlags, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 40, updateMask, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 42, excutionTime_ms, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 43, isNewData, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 44, active, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 45, summaryStatus, typeof(UInt32), 1);
                
                if (!_status)
                {
                    MessageBox.Show("Writing all parameters failed!", "Modbus error ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return _status;
            }

            public void ModbusReadAll()
            {
                jetsonTime_UTC = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 0, typeof(UInt32), 1);
                oDOLat_deg = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 2, typeof(Double), 1);
                oDOLon_deg = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 6, typeof(Double), 1);
                alt_m = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 10, typeof(Double), 1);
                rollFus_deg = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 14, typeof(Double), 1);
                pitchFus_deg = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 18, typeof(Double), 1);
                yawFus_deg = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 22, typeof(Double), 1);
                speed_mps = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 26, typeof(Double), 1);
                qualitySpeed = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 30, typeof(UInt16), 1);
                oDO_DX_m = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 31, typeof(Double), 1);
                oDO_DY_m = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 35, typeof(Double), 1);
                statusFlags = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 39, typeof(UInt16), 1);
                updateMask = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 40, typeof(UInt32), 1);
                excutionTime_ms = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 42, typeof(UInt16), 1);
                isNewData = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 43, typeof(UInt16), 1);
                active = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 44, typeof(UInt16), 1);
                summaryStatus = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 45, typeof(UInt32), 1);
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class sSensorIBNS_SpeedSetting
        {
            public UInt16 enable;

            private UInt16 ModbusBaseAddr;

            public static UInt16 ModbusSize = 1; // VarTypeSize in excel
            
            public sSensorIBNS_SpeedSetting(UInt16 ObjectModbusBaseAddr)
            {
                ModbusBaseAddr = ObjectModbusBaseAddr;

                enable = 0;
            }

            public UInt16 Enable
            {
                get { return enable; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, value, typeof(UInt16), 1))
                    {
                        enable = value;
                    }
                }
            }

            public bool ModbusWriteAll()
            {
                bool _status = true;
            
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, enable, typeof(UInt16), 1);
                
                if (!_status)
                {
                    MessageBox.Show("Writing all parameters failed!", "Modbus error ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return _status;
            }

            public void ModbusReadAll()
            {
                enable = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 0, typeof(UInt16), 1);
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class sSensorSadraData
        {
            public UInt16 insFrame_IsNewData;
            public Double[] insFrame_Euler_rad;
            public Double insFrame_Course_rad;
            public Double[] insFrame_AccENU_mps2;
            public Double[] insFrame_GyroENU_rps;
            public UInt16 insFrame_Status;
            public Double[] insFrame_LLA_rrm;
            public Double[] insFrame_VelENU;
            public UInt16 gpsFrame_IsNewData;
            public UInt32 gPSFrame_iTOW;
            public UInt32 gPSFrame_fTOW;
            public UInt16 gPSFrame_NumSV;
            public UInt16 gPSFrame_Week;
            public UInt16 gPSFrame_GPSfix;
            public UInt16 gPSFrame_Flag;
            public Double[] gPSFrame_PosECEF;
            public UInt32[] gPSFrame_VelECEF;
            public UInt16 active;
            public UInt32 summaryStatus;

            private UInt16 ModbusBaseAddr;

            public static UInt16 ModbusSize = 96; // VarTypeSize in excel
            
            public sSensorSadraData(UInt16 ObjectModbusBaseAddr)
            {
                ModbusBaseAddr = ObjectModbusBaseAddr;

                insFrame_IsNewData = 0;
                insFrame_Euler_rad = new Double[3];
                insFrame_Course_rad = 0;
                insFrame_AccENU_mps2 = new Double[3];
                insFrame_GyroENU_rps = new Double[3];
                insFrame_Status = 0;
                insFrame_LLA_rrm = new Double[3];
                insFrame_VelENU = new Double[3];
                gpsFrame_IsNewData = 0;
                gPSFrame_iTOW = 0;
                gPSFrame_fTOW = 0;
                gPSFrame_NumSV = 0;
                gPSFrame_Week = 0;
                gPSFrame_GPSfix = 0;
                gPSFrame_Flag = 0;
                gPSFrame_PosECEF = new Double[3];
                gPSFrame_VelECEF = new UInt32[3];
                active = 0;
                summaryStatus = 0;
            }

            public UInt16 InsFrame_IsNewData
            {
                get { return insFrame_IsNewData; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, value, typeof(UInt16), 1))
                    {
                        insFrame_IsNewData = value;
                    }
                }
            }

            public Double[] InsFrame_Euler_rad
            {
                get { return insFrame_Euler_rad; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 1, value, typeof(Double), 3))
                    {
                        insFrame_Euler_rad = value;
                    }
                }
            }

            public Double InsFrame_Course_rad
            {
                get { return insFrame_Course_rad; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 13, value, typeof(Double), 1))
                    {
                        insFrame_Course_rad = value;
                    }
                }
            }

            public Double[] InsFrame_AccENU_mps2
            {
                get { return insFrame_AccENU_mps2; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 17, value, typeof(Double), 3))
                    {
                        insFrame_AccENU_mps2 = value;
                    }
                }
            }

            public Double[] InsFrame_GyroENU_rps
            {
                get { return insFrame_GyroENU_rps; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 29, value, typeof(Double), 3))
                    {
                        insFrame_GyroENU_rps = value;
                    }
                }
            }

            public UInt16 InsFrame_Status
            {
                get { return insFrame_Status; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 41, value, typeof(UInt16), 1))
                    {
                        insFrame_Status = value;
                    }
                }
            }

            public Double[] InsFrame_LLA_rrm
            {
                get { return insFrame_LLA_rrm; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 42, value, typeof(Double), 3))
                    {
                        insFrame_LLA_rrm = value;
                    }
                }
            }

            public Double[] InsFrame_VelENU
            {
                get { return insFrame_VelENU; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 54, value, typeof(Double), 3))
                    {
                        insFrame_VelENU = value;
                    }
                }
            }

            public UInt16 GpsFrame_IsNewData
            {
                get { return gpsFrame_IsNewData; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 66, value, typeof(UInt16), 1))
                    {
                        gpsFrame_IsNewData = value;
                    }
                }
            }

            public UInt32 GPSFrame_iTOW
            {
                get { return gPSFrame_iTOW; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 67, value, typeof(UInt32), 1))
                    {
                        gPSFrame_iTOW = value;
                    }
                }
            }

            public UInt32 GPSFrame_fTOW
            {
                get { return gPSFrame_fTOW; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 69, value, typeof(UInt32), 1))
                    {
                        gPSFrame_fTOW = value;
                    }
                }
            }

            public UInt16 GPSFrame_NumSV
            {
                get { return gPSFrame_NumSV; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 71, value, typeof(UInt16), 1))
                    {
                        gPSFrame_NumSV = value;
                    }
                }
            }

            public UInt16 GPSFrame_Week
            {
                get { return gPSFrame_Week; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 72, value, typeof(UInt16), 1))
                    {
                        gPSFrame_Week = value;
                    }
                }
            }

            public UInt16 GPSFrame_GPSfix
            {
                get { return gPSFrame_GPSfix; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 73, value, typeof(UInt16), 1))
                    {
                        gPSFrame_GPSfix = value;
                    }
                }
            }

            public UInt16 GPSFrame_Flag
            {
                get { return gPSFrame_Flag; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 74, value, typeof(UInt16), 1))
                    {
                        gPSFrame_Flag = value;
                    }
                }
            }

            public Double[] GPSFrame_PosECEF
            {
                get { return gPSFrame_PosECEF; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 75, value, typeof(Double), 3))
                    {
                        gPSFrame_PosECEF = value;
                    }
                }
            }

            public UInt32[] GPSFrame_VelECEF
            {
                get { return gPSFrame_VelECEF; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 87, value, typeof(UInt32), 3))
                    {
                        gPSFrame_VelECEF = value;
                    }
                }
            }

            public UInt16 Active
            {
                get { return active; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 93, value, typeof(UInt16), 1))
                    {
                        active = value;
                    }
                }
            }

            public UInt32 SummaryStatus
            {
                get { return summaryStatus; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 94, value, typeof(UInt32), 1))
                    {
                        summaryStatus = value;
                    }
                }
            }

            public bool ModbusWriteAll()
            {
                bool _status = true;
            
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, insFrame_IsNewData, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 1, insFrame_Euler_rad, typeof(Double), 3);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 13, insFrame_Course_rad, typeof(Double), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 17, insFrame_AccENU_mps2, typeof(Double), 3);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 29, insFrame_GyroENU_rps, typeof(Double), 3);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 41, insFrame_Status, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 42, insFrame_LLA_rrm, typeof(Double), 3);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 54, insFrame_VelENU, typeof(Double), 3);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 66, gpsFrame_IsNewData, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 67, gPSFrame_iTOW, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 69, gPSFrame_fTOW, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 71, gPSFrame_NumSV, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 72, gPSFrame_Week, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 73, gPSFrame_GPSfix, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 74, gPSFrame_Flag, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 75, gPSFrame_PosECEF, typeof(Double), 3);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 87, gPSFrame_VelECEF, typeof(UInt32), 3);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 93, active, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 94, summaryStatus, typeof(UInt32), 1);
                
                if (!_status)
                {
                    MessageBox.Show("Writing all parameters failed!", "Modbus error ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return _status;
            }

            public void ModbusReadAll()
            {
                insFrame_IsNewData = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 0, typeof(UInt16), 1);
                insFrame_Euler_rad = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 1, typeof(Double), 3);
                insFrame_Course_rad = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 13, typeof(Double), 1);
                insFrame_AccENU_mps2 = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 17, typeof(Double), 3);
                insFrame_GyroENU_rps = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 29, typeof(Double), 3);
                insFrame_Status = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 41, typeof(UInt16), 1);
                insFrame_LLA_rrm = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 42, typeof(Double), 3);
                insFrame_VelENU = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 54, typeof(Double), 3);
                gpsFrame_IsNewData = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 66, typeof(UInt16), 1);
                gPSFrame_iTOW = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 67, typeof(UInt32), 1);
                gPSFrame_fTOW = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 69, typeof(UInt32), 1);
                gPSFrame_NumSV = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 71, typeof(UInt16), 1);
                gPSFrame_Week = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 72, typeof(UInt16), 1);
                gPSFrame_GPSfix = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 73, typeof(UInt16), 1);
                gPSFrame_Flag = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 74, typeof(UInt16), 1);
                gPSFrame_PosECEF = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 75, typeof(Double), 3);
                gPSFrame_VelECEF = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 87, typeof(UInt32), 3);
                active = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 93, typeof(UInt16), 1);
                summaryStatus = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 94, typeof(UInt32), 1);
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class sSensorSadraSetting
        {
            public UInt16 enable;

            private UInt16 ModbusBaseAddr;

            public static UInt16 ModbusSize = 1; // VarTypeSize in excel
            
            public sSensorSadraSetting(UInt16 ObjectModbusBaseAddr)
            {
                ModbusBaseAddr = ObjectModbusBaseAddr;

                enable = 0;
            }

            public UInt16 Enable
            {
                get { return enable; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, value, typeof(UInt16), 1))
                    {
                        enable = value;
                    }
                }
            }

            public bool ModbusWriteAll()
            {
                bool _status = true;
            
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, enable, typeof(UInt16), 1);
                
                if (!_status)
                {
                    MessageBox.Show("Writing all parameters failed!", "Modbus error ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return _status;
            }

            public void ModbusReadAll()
            {
                enable = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 0, typeof(UInt16), 1);
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class sLoggerSessionData
        {
            public UInt16 sessionId;
            public UInt32 recordsOccupiedQty;
            public UInt32 payloadsOccupiedSize;
            public UInt32 recordsDurationUs;

            private UInt16 ModbusBaseAddr;

            public static UInt16 ModbusSize = 7; // VarTypeSize in excel
            
            public sLoggerSessionData(UInt16 ObjectModbusBaseAddr)
            {
                ModbusBaseAddr = ObjectModbusBaseAddr;

                sessionId = 0;
                recordsOccupiedQty = 0;
                payloadsOccupiedSize = 0;
                recordsDurationUs = 0;
            }

            public UInt16 SessionId
            {
                get { return sessionId; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, value, typeof(UInt16), 1))
                    {
                        sessionId = value;
                    }
                }
            }

            public UInt32 RecordsOccupiedQty
            {
                get { return recordsOccupiedQty; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 1, value, typeof(UInt32), 1))
                    {
                        recordsOccupiedQty = value;
                    }
                }
            }

            public UInt32 PayloadsOccupiedSize
            {
                get { return payloadsOccupiedSize; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 3, value, typeof(UInt32), 1))
                    {
                        payloadsOccupiedSize = value;
                    }
                }
            }

            public UInt32 RecordsDurationUs
            {
                get { return recordsDurationUs; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 5, value, typeof(UInt32), 1))
                    {
                        recordsDurationUs = value;
                    }
                }
            }

            public bool ModbusWriteAll()
            {
                bool _status = true;
            
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, sessionId, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 1, recordsOccupiedQty, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 3, payloadsOccupiedSize, typeof(UInt32), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 5, recordsDurationUs, typeof(UInt32), 1);
                
                if (!_status)
                {
                    MessageBox.Show("Writing all parameters failed!", "Modbus error ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return _status;
            }

            public void ModbusReadAll()
            {
                sessionId = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 0, typeof(UInt16), 1);
                recordsOccupiedQty = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 1, typeof(UInt32), 1);
                payloadsOccupiedSize = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 3, typeof(UInt32), 1);
                recordsDurationUs = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 5, typeof(UInt32), 1);
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

        public enum eTag1_SettingGroup : ushort
        {
            eSETTING_INFO = 1,
            eSETTING_MODBUS_EXT = 2,
            eSETTING_BOARD = 3,
            eSETTING_RAPP_MAIN = 4
        }

        public enum eSensorImuFliterType : ushort
        {
            eSENSOR_IMU_FILTER_TYPE_A = 0,
            eSENSOR_IMU_FILTER_TYPE_B = 1,
            eSENSOR_IMU_FILTER_TYPE_C = 2,
            eSENSOR_IMU_FILTER_TYPE_D = 3
        }

        public enum eSensorMs5611Osr : ushort
        {
            eSENSOR_MS5611_OSR_256 = 0,
            eSENSOR_MS5611_OSR_512 = 1,
            eSENSOR_MS5611_OSR_1024 = 2,
            eSENSOR_MS5611_OSR_2048 = 3,
            eSENSOR_MS5611_OSR_4096 = 4
        }

        public enum eAlgorithmType : ushort
        {
            eALG_TYPE_INS = 0,
            eALG_TYPE_INS_GNSS = 1,
            eALG_TYPE_INS_VISION = 2,
            eALG_TYPE_INS_GNSS_VISION = 3
        }

        public enum eGNSSType : ushort
        {
            eGNSS_TYPE_ZEDF9P = 0,
            eGNSS_TYPE_M8NM9N = 1,
            eGNSS_TYPE_EXTERNAL = 2
        }

        public enum eHeadType : ushort
        {
            eHEAD_TYPE_TOTAL_STATION = 0,
            eHEAD_TYPE_GYRO_COMPASSING = 1
        }

        public enum eAlignMode : ushort
        {
            eALIGN_MODE_STATIC = 0,
            eALIGN_MODE_IN_FLIGHT = 1
        }

        public enum eImuType : ushort
        {
            eIMU_TYPE_MATCHBOX = 0,
            eIMU_TYPE_DRAGON = 1
        }

        public enum eCurrentState : ushort
        {
            eCURRENT_STATE_IDLE = 0,
            eCURRENT_STATE_INIT = 1,
            eCURRENT_STATE_ALIGN = 2,
            eCURRENT_STATE_NAV = 3,
            eCURRENT_STATE_FUSION = 4
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
            LOAD_BOARD = 22,
            LOAD_RAPP_MAIN = 23,
            LOAD_WITH_FORCE_ALL = 24,
            LOAD_WITH_FORCE_INFO = 25,
            LOAD_WITH_FORCE_MODBUS_EXT = 26,
            LOAD_WITH_FORCE_BOARD = 27,
            LOAD_WITH_FORCE_RAPP_MAIN = 28,
            SAVE_ALL = 29,
            SAVE_ALL_MEMORY_RESULT = 30,
            SAVE_INFO = 31,
            SAVE_MODBUS_EXT = 32,
            SAVE_BOARD = 33,
            SAVE_RAPP_MAIN = 34,
            WATCHDOG_TIME_MS = 35,
            RESET_SOURCE = 36,
            RESET_CMD = 37,
            DATE_YEAR = 38,
            DATE_MONTH = 39,
            DATE_DAY = 40,
            CLOCK_HOUR = 41,
            CLOCK_MINUTE = 42,
            CLOCK_SECOND = 43,
            DATE_YEAR_CONFIG = 44,
            DATE_MONTH_CONFIG = 45,
            DATE_DAY_CONFIG = 46,
            CLOCK_HOUR_CONFIG = 47,
            CLOCK_MINUTE_CONFIG = 48,
            CLOCK_SECOND_CONFIG = 49,
            SAVE_RTC = 50,
            UP_STREAM_BAUDRATE = 51,
            SHODOW_HOLDING_REGISTER_0 = 52,
            SHODOW_HOLDING_REGISTER_1 = 53,
            SHODOW_HOLDING_REGISTER_2 = 54,
            SHODOW_HOLDING_REGISTER_3 = 55,
            SHODOW_HOLDING_REGISTER_4 = 56,
            SHODOW_HOLDING_REGISTER_5 = 57,
            SHODOW_HOLDING_REGISTER_6 = 58,
            SHODOW_HOLDING_REGISTER_7 = 59,
            SHODOW_HOLDING_REGISTER_8 = 60,
            SHODOW_HOLDING_REGISTER_9 = 61,
            SHODOW_HOLDING_REGISTER_10 = 62,
            SHODOW_HOLDING_REGISTER_11 = 63,
            SHODOW_HOLDING_REGISTER_12 = 64,
            SHODOW_HOLDING_REGISTER_13 = 65,
            SHODOW_HOLDING_REGISTER_14 = 66,
            SHODOW_HOLDING_REGISTER_15 = 67,
            SHODOW_HOLDING_REGISTER_16 = 68,
            SHODOW_HOLDING_REGISTER_17 = 69,
            SHODOW_HOLDING_REGISTER_18 = 70,
            SHODOW_HOLDING_REGISTER_19 = 71,
            SHODOW_HOLDING_REGISTER_20 = 72,
            SHODOW_HOLDING_REGISTER_21 = 73,
            SHODOW_HOLDING_REGISTER_22 = 74,
            SHODOW_HOLDING_REGISTER_23 = 75,
            SHODOW_HOLDING_REGISTER_24 = 76,
            SHODOW_HOLDING_REGISTER_25 = 77,
            SHODOW_HOLDING_REGISTER_26 = 78,
            SHODOW_HOLDING_REGISTER_27 = 79,
            SHODOW_HOLDING_REGISTER_28 = 80,
            SHODOW_HOLDING_REGISTER_29 = 81,
            SHODOW_HOLDING_REGISTER_30 = 82,
            SHODOW_HOLDING_REGISTER_31 = 83,
            SHODOW_HOLDING_REGISTER_32 = 84,
            SHODOW_HOLDING_REGISTER_33 = 85,
            SHODOW_HOLDING_REGISTER_34 = 86,
            SHODOW_HOLDING_REGISTER_35 = 87,
            SHODOW_HOLDING_REGISTER_36 = 88,
            SHODOW_HOLDING_REGISTER_37 = 89,
            SHODOW_HOLDING_REGISTER_38 = 90,
            SHODOW_HOLDING_REGISTER_39 = 91,
            SHODOW_HOLDING_REGISTER_40 = 92,
            SHODOW_HOLDING_REGISTER_41 = 93,
            SHODOW_HOLDING_REGISTER_42 = 94,
            SHODOW_HOLDING_REGISTER_43 = 95,
            SHODOW_HOLDING_REGISTER_44 = 96,
            SHODOW_HOLDING_REGISTER_45 = 97,
            SHODOW_HOLDING_REGISTER_46 = 98,
            SHODOW_HOLDING_REGISTER_47 = 99,
            SHODOW_HOLDING_REGISTER_48 = 100,
            SHODOW_HOLDING_REGISTER_49 = 101,
            SHODOW_HOLDING_REGISTER_50 = 102,
            SHODOW_HOLDING_REGISTER_51 = 103,
            SHODOW_HOLDING_REGISTER_52 = 104,
            SHODOW_HOLDING_REGISTER_53 = 105,
            SHODOW_HOLDING_REGISTER_54 = 106,
            SHODOW_HOLDING_REGISTER_55 = 107,
            SHODOW_HOLDING_REGISTER_56 = 108,
            SHODOW_HOLDING_REGISTER_57 = 109,
            SHODOW_HOLDING_REGISTER_58 = 110,
            SHODOW_HOLDING_REGISTER_59 = 111,
            SHODOW_HOLDING_REGISTER_60 = 112,
            SHODOW_HOLDING_REGISTER_61 = 113,
            SHODOW_HOLDING_REGISTER_62 = 114,
            SHODOW_HOLDING_REGISTER_63 = 115,
            SHODOW_HOLDING_REGISTER_64 = 116,
            SHODOW_HOLDING_REGISTER_65 = 117,
            SHODOW_HOLDING_REGISTER_66 = 118,
            SHODOW_HOLDING_REGISTER_67 = 119,
            SHODOW_HOLDING_REGISTER_68 = 120,
            SHODOW_HOLDING_REGISTER_69 = 121,
            SHODOW_HOLDING_REGISTER_70 = 122,
            SHODOW_HOLDING_REGISTER_71 = 123,
            SHODOW_HOLDING_REGISTER_72 = 124,
            SHODOW_HOLDING_REGISTER_73 = 125,
            SHODOW_HOLDING_REGISTER_74 = 126,
            SHODOW_HOLDING_REGISTER_75 = 127,
            SHODOW_HOLDING_REGISTER_76 = 128,
            SHODOW_HOLDING_REGISTER_77 = 129,
            SHODOW_HOLDING_REGISTER_78 = 130,
            SHODOW_HOLDING_REGISTER_79 = 131,
            SHODOW_HOLDING_REGISTER_80 = 132,
            SHODOW_HOLDING_REGISTER_81 = 133,
            SHODOW_HOLDING_REGISTER_82 = 134,
            SHODOW_HOLDING_REGISTER_83 = 135,
            SHODOW_HOLDING_REGISTER_84 = 136,
            SHODOW_HOLDING_REGISTER_85 = 137,
            SHODOW_HOLDING_REGISTER_86 = 138,
            SHODOW_HOLDING_REGISTER_87 = 139,
            SHODOW_HOLDING_REGISTER_88 = 140,
            SHODOW_HOLDING_REGISTER_89 = 141,
            SHODOW_HOLDING_REGISTER_90 = 142,
            SHODOW_HOLDING_REGISTER_91 = 143,
            SHODOW_HOLDING_REGISTER_92 = 144,
            SHODOW_HOLDING_REGISTER_93 = 145,
            SHODOW_HOLDING_REGISTER_94 = 146,
            SHODOW_HOLDING_REGISTER_95 = 147,
            SHODOW_HOLDING_REGISTER_96 = 148,
            SHODOW_HOLDING_REGISTER_97 = 149,
            SHODOW_HOLDING_REGISTER_98 = 150,
            SHODOW_HOLDING_REGISTER_99 = 151,
            SHODOW_HOLDING_REGISTER_100 = 152,
            SHODOW_HOLDING_REGISTER_101 = 153,
            SHODOW_HOLDING_REGISTER_102 = 154,
            SHODOW_HOLDING_REGISTER_103 = 155,
            SHODOW_HOLDING_REGISTER_104 = 156,
            SHODOW_HOLDING_REGISTER_105 = 157,
            SHODOW_HOLDING_REGISTER_106 = 158,
            SHODOW_HOLDING_REGISTER_107 = 159,
            SHODOW_HOLDING_REGISTER_108 = 160,
            SHODOW_HOLDING_REGISTER_109 = 161,
            SHODOW_HOLDING_REGISTER_110 = 162,
            SHODOW_HOLDING_REGISTER_111 = 163,
            SHODOW_HOLDING_REGISTER_112 = 164,
            SHODOW_HOLDING_REGISTER_113 = 165,
            SHODOW_HOLDING_REGISTER_114 = 166,
            SHODOW_HOLDING_REGISTER_115 = 167,
            SHODOW_HOLDING_REGISTER_116 = 168,
            SHODOW_HOLDING_REGISTER_117 = 169,
            SHODOW_HOLDING_REGISTER_118 = 170,
            SHODOW_HOLDING_REGISTER_119 = 171,
            SHODOW_HOLDING_REGISTER_120 = 172,
            SHODOW_HOLDING_REGISTER_121 = 173,
            SHODOW_HOLDING_REGISTER_122 = 174,
            SHODOW_HOLDING_REGISTER_123 = 175,
            SHODOW_HOLDING_REGISTER_124 = 176,
            SHODOW_HOLDING_REGISTER_125 = 177,
            SHODOW_HOLDING_REGISTER_126 = 178,
            SHODOW_HOLDING_REGISTER_127 = 179,
            SHODOW_HOLDING_REGISTER_128 = 180,
            SHODOW_HOLDING_REGISTER_129 = 181,
            SHODOW_HOLDING_REGISTER_130 = 182,
            SHODOW_HOLDING_REGISTER_131 = 183,
            SHODOW_HOLDING_REGISTER_132 = 184,
            SHODOW_HOLDING_REGISTER_133 = 185,
            SHODOW_HOLDING_REGISTER_134 = 186,
            SHODOW_HOLDING_REGISTER_135 = 187,
            SHODOW_HOLDING_REGISTER_136 = 188,
            SHODOW_HOLDING_REGISTER_137 = 189,
            SHODOW_HOLDING_REGISTER_138 = 190,
            SHODOW_HOLDING_REGISTER_139 = 191,
            SHODOW_HOLDING_REGISTER_140 = 192,
            SHODOW_HOLDING_REGISTER_141 = 193,
            SHODOW_HOLDING_REGISTER_142 = 194,
            SHODOW_HOLDING_REGISTER_143 = 195,
            SHODOW_HOLDING_REGISTER_144 = 196,
            SHODOW_HOLDING_REGISTER_145 = 197,
            SHODOW_HOLDING_REGISTER_146 = 198,
            SHODOW_HOLDING_REGISTER_147 = 199,
            SHODOW_HOLDING_REGISTER_148 = 200,
            SHODOW_HOLDING_REGISTER_149 = 201,
            SHODOW_HOLDING_REGISTER_150 = 202,
            SHODOW_HOLDING_REGISTER_151 = 203,
            SHODOW_HOLDING_REGISTER_152 = 204,
            SHODOW_HOLDING_REGISTER_153 = 205,
            SHODOW_HOLDING_REGISTER_154 = 206,
            SHODOW_HOLDING_REGISTER_155 = 207,
            SHODOW_HOLDING_REGISTER_156 = 208,
            SHODOW_HOLDING_REGISTER_157 = 209,
            SHODOW_HOLDING_REGISTER_158 = 210,
            SHODOW_HOLDING_REGISTER_159 = 211,
            SHODOW_HOLDING_REGISTER_160 = 212,
            SHODOW_HOLDING_REGISTER_161 = 213,
            SHODOW_HOLDING_REGISTER_162 = 214,
            SHODOW_HOLDING_REGISTER_163 = 215,
            SHODOW_HOLDING_REGISTER_164 = 216,
            SHODOW_HOLDING_REGISTER_165 = 217,
            SHODOW_HOLDING_REGISTER_166 = 218,
            SHODOW_HOLDING_REGISTER_167 = 219,
            SHODOW_HOLDING_REGISTER_168 = 220,
            SHODOW_HOLDING_REGISTER_169 = 221,
            SHODOW_HOLDING_REGISTER_170 = 222,
            SHODOW_HOLDING_REGISTER_171 = 223,
            SHODOW_HOLDING_REGISTER_172 = 224,
            SHODOW_HOLDING_REGISTER_173 = 225,
            SHODOW_HOLDING_REGISTER_174 = 226,
            SHODOW_HOLDING_REGISTER_175 = 227,
            SHODOW_HOLDING_REGISTER_176 = 228,
            SHODOW_HOLDING_REGISTER_177 = 229,
            SHODOW_HOLDING_REGISTER_178 = 230,
            SHODOW_HOLDING_REGISTER_179 = 231,
            SHODOW_HOLDING_REGISTER_180 = 232,
            SHODOW_HOLDING_REGISTER_181 = 233,
            SHODOW_HOLDING_REGISTER_182 = 234,
            SHODOW_HOLDING_REGISTER_183 = 235,
            SHODOW_HOLDING_REGISTER_184 = 236,
            SHODOW_HOLDING_REGISTER_185 = 237,
            SHODOW_HOLDING_REGISTER_186 = 238,
            SHODOW_HOLDING_REGISTER_187 = 239,
            SHODOW_HOLDING_REGISTER_188 = 240,
            SHODOW_HOLDING_REGISTER_189 = 241,
            SHODOW_HOLDING_REGISTER_190 = 242,
            SHODOW_HOLDING_REGISTER_191 = 243,
            SHODOW_HOLDING_REGISTER_192 = 244,
            SHODOW_HOLDING_REGISTER_193 = 245,
            SHODOW_HOLDING_REGISTER_194 = 246,
            SHODOW_HOLDING_REGISTER_195 = 247,
            SHODOW_HOLDING_REGISTER_196 = 248,
            SHODOW_HOLDING_REGISTER_197 = 249,
            SHODOW_HOLDING_REGISTER_198 = 250,
            SHODOW_HOLDING_REGISTER_199 = 251,
            SHODOW_HOLDING_REGISTER_200 = 252,
            SHODOW_HOLDING_REGISTER_201 = 253,
            SHODOW_HOLDING_REGISTER_202 = 254,
            SHODOW_HOLDING_REGISTER_203 = 255,
            SHODOW_HOLDING_REGISTER_204 = 256,
            SHODOW_HOLDING_REGISTER_205 = 257,
            SHODOW_HOLDING_REGISTER_206 = 258,
            SHODOW_HOLDING_REGISTER_207 = 259,
            SHODOW_HOLDING_REGISTER_208 = 260,
            SHODOW_HOLDING_REGISTER_209 = 261,
            SHODOW_HOLDING_REGISTER_210 = 262,
            SHODOW_HOLDING_REGISTER_211 = 263,
            SHODOW_HOLDING_REGISTER_212 = 264,
            SHODOW_HOLDING_REGISTER_213 = 265,
            SHODOW_HOLDING_REGISTER_214 = 266,
            SHODOW_HOLDING_REGISTER_215 = 267,
            SHODOW_HOLDING_REGISTER_216 = 268,
            SHODOW_HOLDING_REGISTER_217 = 269,
            SHODOW_HOLDING_REGISTER_218 = 270,
            SHODOW_HOLDING_REGISTER_219 = 271,
            SHODOW_HOLDING_REGISTER_220 = 272,
            SHODOW_HOLDING_REGISTER_221 = 273,
            SHODOW_HOLDING_REGISTER_222 = 274,
            SHODOW_HOLDING_REGISTER_223 = 275,
            SHODOW_HOLDING_REGISTER_224 = 276,
            SHODOW_HOLDING_REGISTER_225 = 277,
            SHODOW_HOLDING_REGISTER_226 = 278,
            SHODOW_HOLDING_REGISTER_227 = 279,
            SHODOW_HOLDING_REGISTER_228 = 280,
            SHODOW_HOLDING_REGISTER_229 = 281,
            SHODOW_HOLDING_REGISTER_230 = 282,
            SHODOW_HOLDING_REGISTER_231 = 283,
            SHODOW_HOLDING_REGISTER_232 = 284,
            SHODOW_HOLDING_REGISTER_233 = 285,
            SHODOW_HOLDING_REGISTER_234 = 286,
            SHODOW_HOLDING_REGISTER_235 = 287,
            SHODOW_HOLDING_REGISTER_236 = 288,
            SHODOW_HOLDING_REGISTER_237 = 289,
            SHODOW_HOLDING_REGISTER_238 = 290,
            SHODOW_HOLDING_REGISTER_239 = 291,
            SHODOW_HOLDING_REGISTER_240 = 292,
            SHODOW_HOLDING_REGISTER_241 = 293,
            SHODOW_HOLDING_REGISTER_242 = 294,
            SHODOW_HOLDING_REGISTER_243 = 295,
            SHODOW_HOLDING_REGISTER_244 = 296,
            SHODOW_HOLDING_REGISTER_245 = 297,
            SHODOW_HOLDING_REGISTER_246 = 298,
            SHODOW_HOLDING_REGISTER_247 = 299,
            SHODOW_HOLDING_REGISTER_248 = 300,
            SHODOW_HOLDING_REGISTER_249 = 301,
            SHODOW_HOLDING_REGISTER_250 = 302,
            SHODOW_HOLDING_REGISTER_251 = 303,
            SHODOW_HOLDING_REGISTER_252 = 304,
            SHODOW_HOLDING_REGISTER_253 = 305,
            SHODOW_HOLDING_REGISTER_254 = 306,
            SHODOW_HOLDING_REGISTER_255 = 307,
            SHODOW_HOLDING_REGISTER_256 = 308,
            SHODOW_HOLDING_REGISTER_257 = 309,
            SHODOW_HOLDING_REGISTER_258 = 310,
            SHODOW_HOLDING_REGISTER_259 = 311,
            SHODOW_HOLDING_REGISTER_260 = 312,
            SHODOW_HOLDING_REGISTER_261 = 313,
            SHODOW_HOLDING_REGISTER_262 = 314,
            SHODOW_HOLDING_REGISTER_263 = 315,
            SHODOW_HOLDING_REGISTER_264 = 316,
            SHODOW_HOLDING_REGISTER_265 = 317,
            SHODOW_HOLDING_REGISTER_266 = 318,
            SHODOW_HOLDING_REGISTER_267 = 319,
            SHODOW_HOLDING_REGISTER_268 = 320,
            SHODOW_HOLDING_REGISTER_269 = 321,
            SHODOW_HOLDING_REGISTER_270 = 322,
            SHODOW_HOLDING_REGISTER_271 = 323,
            SHODOW_HOLDING_REGISTER_272 = 324,
            SHODOW_HOLDING_REGISTER_273 = 325,
            SHODOW_HOLDING_REGISTER_274 = 326,
            SHODOW_HOLDING_REGISTER_275 = 327,
            SHODOW_HOLDING_REGISTER_276 = 328,
            SHODOW_HOLDING_REGISTER_277 = 329,
            SHODOW_HOLDING_REGISTER_278 = 330,
            SHODOW_HOLDING_REGISTER_279 = 331,
            SHODOW_HOLDING_REGISTER_280 = 332,
            SHODOW_HOLDING_REGISTER_281 = 333,
            SHODOW_HOLDING_REGISTER_282 = 334,
            SHODOW_HOLDING_REGISTER_283 = 335,
            SHODOW_HOLDING_REGISTER_284 = 336,
            SHODOW_HOLDING_REGISTER_285 = 337,
            SHODOW_HOLDING_REGISTER_286 = 338,
            SHODOW_HOLDING_REGISTER_287 = 339,
            SHODOW_HOLDING_REGISTER_288 = 340,
            SHODOW_HOLDING_REGISTER_289 = 341,
            SHODOW_HOLDING_REGISTER_290 = 342,
            SHODOW_HOLDING_REGISTER_291 = 343,
            SHODOW_HOLDING_REGISTER_292 = 344,
            SHODOW_HOLDING_REGISTER_293 = 345,
            SHODOW_HOLDING_REGISTER_294 = 346,
            SHODOW_HOLDING_REGISTER_295 = 347,
            SHODOW_HOLDING_REGISTER_296 = 348,
            SHODOW_HOLDING_REGISTER_297 = 349,
            SHODOW_HOLDING_REGISTER_298 = 350,
            SHODOW_HOLDING_REGISTER_299 = 351,
            SHODOW_HOLDING_REGISTER_300 = 352,
            SHODOW_HOLDING_REGISTER_301 = 353,
            SHODOW_HOLDING_REGISTER_302 = 354,
            SHODOW_HOLDING_REGISTER_303 = 355,
            SHODOW_HOLDING_REGISTER_304 = 356,
            SHODOW_HOLDING_REGISTER_305 = 357,
            SHODOW_HOLDING_REGISTER_306 = 358,
            SHODOW_HOLDING_REGISTER_307 = 359,
            SHODOW_HOLDING_REGISTER_308 = 360,
            SHODOW_HOLDING_REGISTER_309 = 361,
            SHODOW_HOLDING_REGISTER_310 = 362,
            SHODOW_HOLDING_REGISTER_311 = 363,
            SHODOW_HOLDING_REGISTER_312 = 364,
            SHODOW_HOLDING_REGISTER_313 = 365,
            SHODOW_HOLDING_REGISTER_314 = 366,
            SHODOW_HOLDING_REGISTER_315 = 367,
            SHODOW_HOLDING_REGISTER_316 = 368,
            SHODOW_HOLDING_REGISTER_317 = 369,
            SHODOW_HOLDING_REGISTER_318 = 370,
            SHODOW_HOLDING_REGISTER_319 = 371,
            SHODOW_HOLDING_REGISTER_320 = 372,
            SHODOW_HOLDING_REGISTER_321 = 373,
            SHODOW_HOLDING_REGISTER_322 = 374,
            SHODOW_HOLDING_REGISTER_323 = 375,
            SHODOW_HOLDING_REGISTER_324 = 376,
            SHODOW_HOLDING_REGISTER_325 = 377,
            SHODOW_HOLDING_REGISTER_326 = 378,
            SHODOW_HOLDING_REGISTER_327 = 379,
            SHODOW_HOLDING_REGISTER_328 = 380,
            SHODOW_HOLDING_REGISTER_329 = 381,
            SHODOW_HOLDING_REGISTER_330 = 382,
            SHODOW_HOLDING_REGISTER_331 = 383,
            SHODOW_HOLDING_REGISTER_332 = 384,
            SHODOW_HOLDING_REGISTER_333 = 385,
            SHODOW_HOLDING_REGISTER_334 = 386,
            SHODOW_HOLDING_REGISTER_335 = 387,
            SHODOW_HOLDING_REGISTER_336 = 388,
            SHODOW_HOLDING_REGISTER_337 = 389,
            SHODOW_HOLDING_REGISTER_338 = 390,
            SHODOW_HOLDING_REGISTER_339 = 391,
            SHODOW_HOLDING_REGISTER_340 = 392,
            SHODOW_HOLDING_REGISTER_341 = 393,
            SHODOW_HOLDING_REGISTER_342 = 394,
            SHODOW_HOLDING_REGISTER_343 = 395,
            SHODOW_HOLDING_REGISTER_344 = 396,
            SHODOW_HOLDING_REGISTER_345 = 397,
            SHODOW_HOLDING_REGISTER_346 = 398,
            SHODOW_HOLDING_REGISTER_347 = 399,
            SHODOW_HOLDING_REGISTER_348 = 400,
            SHODOW_HOLDING_REGISTER_349 = 401,
            SHODOW_HOLDING_REGISTER_350 = 402,
            SHODOW_HOLDING_REGISTER_351 = 403,
            SHODOW_HOLDING_REGISTER_352 = 404,
            SHODOW_HOLDING_REGISTER_353 = 405,
            SHODOW_HOLDING_REGISTER_354 = 406,
            SHODOW_HOLDING_REGISTER_355 = 407,
            SHODOW_HOLDING_REGISTER_356 = 408,
            SHODOW_HOLDING_REGISTER_357 = 409,
            SHODOW_HOLDING_REGISTER_358 = 410,
            SHODOW_HOLDING_REGISTER_359 = 411,
            SHODOW_HOLDING_REGISTER_360 = 412,
            SHODOW_HOLDING_REGISTER_361 = 413,
            SHODOW_HOLDING_REGISTER_362 = 414,
            SHODOW_HOLDING_REGISTER_363 = 415,
            SHODOW_HOLDING_REGISTER_364 = 416,
            SHODOW_HOLDING_REGISTER_365 = 417,
            SHODOW_HOLDING_REGISTER_366 = 418,
            SHODOW_HOLDING_REGISTER_367 = 419,
            SHODOW_HOLDING_REGISTER_368 = 420,
            SHODOW_HOLDING_REGISTER_369 = 421,
            SHODOW_HOLDING_REGISTER_370 = 422,
            SHODOW_HOLDING_REGISTER_371 = 423,
            SHODOW_HOLDING_REGISTER_372 = 424,
            SHODOW_HOLDING_REGISTER_373 = 425,
            SHODOW_HOLDING_REGISTER_374 = 426,
            SHODOW_HOLDING_REGISTER_375 = 427,
            SHODOW_HOLDING_REGISTER_376 = 428,
            SHODOW_HOLDING_REGISTER_377 = 429,
            SHODOW_HOLDING_REGISTER_378 = 430,
            SHODOW_HOLDING_REGISTER_379 = 431,
            SHODOW_HOLDING_REGISTER_380 = 432,
            SHODOW_HOLDING_REGISTER_381 = 433,
            SHODOW_HOLDING_REGISTER_382 = 434,
            SHODOW_HOLDING_REGISTER_383 = 435,
            SHODOW_HOLDING_REGISTER_384 = 436,
            SHODOW_HOLDING_REGISTER_385 = 437,
            SHODOW_HOLDING_REGISTER_386 = 438,
            SHODOW_HOLDING_REGISTER_387 = 439,
            SHODOW_HOLDING_REGISTER_388 = 440,
            SHODOW_HOLDING_REGISTER_389 = 441,
            SHODOW_HOLDING_REGISTER_390 = 442,
            SHODOW_HOLDING_REGISTER_391 = 443,
            SHODOW_HOLDING_REGISTER_392 = 444,
            SHODOW_HOLDING_REGISTER_393 = 445,
            SHODOW_HOLDING_REGISTER_394 = 446,
            SHODOW_HOLDING_REGISTER_395 = 447,
            SHODOW_HOLDING_REGISTER_396 = 448,
            SHODOW_HOLDING_REGISTER_397 = 449,
            SHODOW_HOLDING_REGISTER_398 = 450,
            SHODOW_HOLDING_REGISTER_399 = 451,
            SHODOW_HOLDING_REGISTER_400 = 452,
            SHODOW_HOLDING_REGISTER_401 = 453,
            SHODOW_HOLDING_REGISTER_402 = 454,
            SHODOW_HOLDING_REGISTER_403 = 455,
            SHODOW_HOLDING_REGISTER_404 = 456,
            SHODOW_HOLDING_REGISTER_405 = 457,
            SHODOW_HOLDING_REGISTER_406 = 458,
            SHODOW_HOLDING_REGISTER_407 = 459,
            SHODOW_HOLDING_REGISTER_408 = 460,
            SHODOW_HOLDING_REGISTER_409 = 461,
            SHODOW_HOLDING_REGISTER_410 = 462,
            SHODOW_HOLDING_REGISTER_411 = 463,
            SHODOW_HOLDING_REGISTER_412 = 464,
            SHODOW_HOLDING_REGISTER_413 = 465,
            SHODOW_HOLDING_REGISTER_414 = 466,
            SHODOW_HOLDING_REGISTER_415 = 467,
            SHODOW_HOLDING_REGISTER_416 = 468,
            SHODOW_HOLDING_REGISTER_417 = 469,
            SHODOW_HOLDING_REGISTER_418 = 470,
            SHODOW_HOLDING_REGISTER_419 = 471,
            SHODOW_HOLDING_REGISTER_420 = 472,
            SHODOW_HOLDING_REGISTER_421 = 473,
            SHODOW_HOLDING_REGISTER_422 = 474,
            SHODOW_HOLDING_REGISTER_423 = 475,
            SHODOW_HOLDING_REGISTER_424 = 476,
            SHODOW_HOLDING_REGISTER_425 = 477,
            SHODOW_HOLDING_REGISTER_426 = 478,
            SHODOW_HOLDING_REGISTER_427 = 479,
            SHODOW_HOLDING_REGISTER_428 = 480,
            SHODOW_HOLDING_REGISTER_429 = 481,
            SHODOW_HOLDING_REGISTER_430 = 482,
            SHODOW_HOLDING_REGISTER_431 = 483,
            SHODOW_HOLDING_REGISTER_432 = 484,
            SHODOW_HOLDING_REGISTER_433 = 485,
            SHODOW_HOLDING_REGISTER_434 = 486,
            SHODOW_HOLDING_REGISTER_435 = 487,
            SHODOW_HOLDING_REGISTER_436 = 488,
            SHODOW_HOLDING_REGISTER_437 = 489,
            SHODOW_HOLDING_REGISTER_438 = 490,
            SHODOW_HOLDING_REGISTER_439 = 491,
            SHODOW_HOLDING_REGISTER_440 = 492,
            SHODOW_HOLDING_REGISTER_441 = 493,
            SHODOW_HOLDING_REGISTER_442 = 494,
            SHODOW_HOLDING_REGISTER_443 = 495,
            SHODOW_HOLDING_REGISTER_444 = 496,
            SHODOW_HOLDING_REGISTER_445 = 497,
            SHODOW_HOLDING_REGISTER_446 = 498,
            SHODOW_HOLDING_REGISTER_447 = 499,
            SHODOW_HOLDING_REGISTER_448 = 500,
            SHODOW_HOLDING_REGISTER_449 = 501,
            SHODOW_HOLDING_REGISTER_450 = 502,
            SHODOW_HOLDING_REGISTER_451 = 503,
            SHODOW_HOLDING_REGISTER_452 = 504,
            SHODOW_HOLDING_REGISTER_453 = 505,
            SHODOW_HOLDING_REGISTER_454 = 506,
            SHODOW_HOLDING_REGISTER_455 = 507,
            SHODOW_HOLDING_REGISTER_456 = 508,
            SHODOW_HOLDING_REGISTER_457 = 509,
            SHODOW_HOLDING_REGISTER_458 = 510,
            SHODOW_HOLDING_REGISTER_459 = 511,
            SHODOW_HOLDING_REGISTER_460 = 512,
            SHODOW_HOLDING_REGISTER_461 = 513,
            SHODOW_HOLDING_REGISTER_462 = 514,
            SHODOW_HOLDING_REGISTER_463 = 515,
            SHODOW_HOLDING_REGISTER_464 = 516,
            SHODOW_HOLDING_REGISTER_465 = 517,
            SHODOW_HOLDING_REGISTER_466 = 518,
            SHODOW_HOLDING_REGISTER_467 = 519,
            SHODOW_HOLDING_REGISTER_468 = 520,
            SHODOW_HOLDING_REGISTER_469 = 521,
            SHODOW_HOLDING_REGISTER_470 = 522,
            SHODOW_HOLDING_REGISTER_471 = 523,
            SHODOW_HOLDING_REGISTER_472 = 524,
            SHODOW_HOLDING_REGISTER_473 = 525,
            SHODOW_HOLDING_REGISTER_474 = 526,
            SHODOW_HOLDING_REGISTER_475 = 527,
            SHODOW_HOLDING_REGISTER_476 = 528,
            SHODOW_HOLDING_REGISTER_477 = 529,
            SHODOW_HOLDING_REGISTER_478 = 530,
            SHODOW_HOLDING_REGISTER_479 = 531,
            SHODOW_HOLDING_REGISTER_480 = 532,
            SHODOW_HOLDING_REGISTER_481 = 533,
            SHODOW_HOLDING_REGISTER_482 = 534,
            SHODOW_HOLDING_REGISTER_483 = 535,
            SHODOW_HOLDING_REGISTER_484 = 536,
            SHODOW_HOLDING_REGISTER_485 = 537,
            SHODOW_HOLDING_REGISTER_486 = 538,
            SHODOW_HOLDING_REGISTER_487 = 539,
            SHODOW_HOLDING_REGISTER_488 = 540,
            SHODOW_HOLDING_REGISTER_489 = 541,
            SHODOW_HOLDING_REGISTER_490 = 542,
            SHODOW_HOLDING_REGISTER_491 = 543,
            SHODOW_HOLDING_REGISTER_492 = 544,
            SHODOW_HOLDING_REGISTER_493 = 545,
            SHODOW_HOLDING_REGISTER_494 = 546,
            SHODOW_HOLDING_REGISTER_495 = 547,
            SHODOW_HOLDING_REGISTER_496 = 548,
            SHODOW_HOLDING_REGISTER_497 = 549,
            SHODOW_HOLDING_REGISTER_498 = 550,
            SHODOW_HOLDING_REGISTER_499 = 551,
            SHODOW_HOLDING_REGISTER_500 = 552,
            SHODOW_HOLDING_REGISTER_501 = 553,
            SHODOW_HOLDING_REGISTER_502 = 554,
            SHODOW_HOLDING_REGISTER_503 = 555,
            SHODOW_HOLDING_REGISTER_504 = 556,
            SHODOW_HOLDING_REGISTER_505 = 557,
            SHODOW_HOLDING_REGISTER_506 = 558,
            SHODOW_HOLDING_REGISTER_507 = 559,
            SHODOW_HOLDING_REGISTER_508 = 560,
            SHODOW_HOLDING_REGISTER_509 = 561,
            SHODOW_HOLDING_REGISTER_510 = 562,
            SHODOW_HOLDING_REGISTER_511 = 563,
            SHODOW_HOLDING_REGISTER_512 = 564,
            SHODOW_HOLDING_REGISTER_513 = 565,
            SHODOW_HOLDING_REGISTER_514 = 566,
            SHODOW_HOLDING_REGISTER_515 = 567,
            SHODOW_HOLDING_REGISTER_516 = 568,
            SHODOW_HOLDING_REGISTER_517 = 569,
            SHODOW_HOLDING_REGISTER_518 = 570,
            SHODOW_HOLDING_REGISTER_519 = 571,
            SHODOW_HOLDING_REGISTER_520 = 572,
            SHODOW_HOLDING_REGISTER_521 = 573,
            SHODOW_HOLDING_REGISTER_522 = 574,
            SHODOW_HOLDING_REGISTER_523 = 575,
            SHODOW_HOLDING_REGISTER_524 = 576,
            SHODOW_HOLDING_REGISTER_525 = 577,
            SHODOW_HOLDING_REGISTER_526 = 578,
            SHODOW_HOLDING_REGISTER_527 = 579,
            SHODOW_HOLDING_REGISTER_528 = 580,
            SHODOW_HOLDING_REGISTER_529 = 581,
            SHODOW_HOLDING_REGISTER_530 = 582,
            SHODOW_HOLDING_REGISTER_531 = 583,
            SHODOW_HOLDING_REGISTER_532 = 584,
            SHODOW_HOLDING_REGISTER_533 = 585,
            SHODOW_HOLDING_REGISTER_534 = 586,
            SHODOW_HOLDING_REGISTER_535 = 587,
            SHODOW_HOLDING_REGISTER_536 = 588,
            SHODOW_HOLDING_REGISTER_537 = 589,
            SHODOW_HOLDING_REGISTER_538 = 590,
            SHODOW_HOLDING_REGISTER_539 = 591,
            SHODOW_HOLDING_REGISTER_540 = 592,
            SHODOW_HOLDING_REGISTER_541 = 593,
            SHODOW_HOLDING_REGISTER_542 = 594,
            SHODOW_HOLDING_REGISTER_543 = 595,
            SHODOW_HOLDING_REGISTER_544 = 596,
            SHODOW_HOLDING_REGISTER_545 = 597,
            SHODOW_HOLDING_REGISTER_546 = 598,
            SHODOW_HOLDING_REGISTER_547 = 599,
            SHODOW_HOLDING_REGISTER_548 = 600,
            SHODOW_HOLDING_REGISTER_549 = 601,
            SHODOW_HOLDING_REGISTER_550 = 602,
            SHODOW_HOLDING_REGISTER_551 = 603,
            SHODOW_HOLDING_REGISTER_552 = 604,
            SHODOW_HOLDING_REGISTER_553 = 605,
            SHODOW_HOLDING_REGISTER_554 = 606,
            SHODOW_HOLDING_REGISTER_555 = 607,
            SHODOW_HOLDING_REGISTER_556 = 608,
            SHODOW_HOLDING_REGISTER_557 = 609,
            SHODOW_HOLDING_REGISTER_558 = 610,
            SHODOW_HOLDING_REGISTER_559 = 611,
            SHODOW_HOLDING_REGISTER_560 = 612,
            SHODOW_HOLDING_REGISTER_561 = 613,
            SHODOW_HOLDING_REGISTER_562 = 614,
            SHODOW_HOLDING_REGISTER_563 = 615,
            SHODOW_HOLDING_REGISTER_564 = 616,
            SHODOW_HOLDING_REGISTER_565 = 617,
            SHODOW_HOLDING_REGISTER_566 = 618,
            SHODOW_HOLDING_REGISTER_567 = 619,
            SHODOW_HOLDING_REGISTER_568 = 620,
            SHODOW_HOLDING_REGISTER_569 = 621,
            SHODOW_HOLDING_REGISTER_570 = 622,
            SHODOW_HOLDING_REGISTER_571 = 623,
            SHODOW_HOLDING_REGISTER_572 = 624,
            SHODOW_HOLDING_REGISTER_573 = 625,
            SHODOW_HOLDING_REGISTER_574 = 626,
            SHODOW_HOLDING_REGISTER_575 = 627,
            SHODOW_HOLDING_REGISTER_576 = 628,
            SHODOW_HOLDING_REGISTER_577 = 629,
            SHODOW_HOLDING_REGISTER_578 = 630,
            SHODOW_HOLDING_REGISTER_579 = 631,
            SHODOW_HOLDING_REGISTER_580 = 632,
            SHODOW_HOLDING_REGISTER_581 = 633,
            SHODOW_HOLDING_REGISTER_582 = 634,
            SHODOW_HOLDING_REGISTER_583 = 635,
            SHODOW_HOLDING_REGISTER_584 = 636,
            SHODOW_HOLDING_REGISTER_585 = 637,
            SHODOW_HOLDING_REGISTER_586 = 638,
            SHODOW_HOLDING_REGISTER_587 = 639,
            SHODOW_HOLDING_REGISTER_588 = 640,
            SHODOW_HOLDING_REGISTER_589 = 641,
            SHODOW_HOLDING_REGISTER_590 = 642,
            SHODOW_HOLDING_REGISTER_591 = 643,
            SHODOW_HOLDING_REGISTER_592 = 644,
            SHODOW_HOLDING_REGISTER_593 = 645,
            SHODOW_HOLDING_REGISTER_594 = 646,
            SHODOW_HOLDING_REGISTER_595 = 647,
            SHODOW_HOLDING_REGISTER_596 = 648,
            SHODOW_HOLDING_REGISTER_597 = 649,
            SHODOW_HOLDING_REGISTER_598 = 650,
            SHODOW_HOLDING_REGISTER_599 = 651,
            SHODOW_HOLDING_REGISTER_600 = 652,
            SHODOW_HOLDING_REGISTER_601 = 653,
            SHODOW_HOLDING_REGISTER_602 = 654,
            SHODOW_HOLDING_REGISTER_603 = 655,
            SHODOW_HOLDING_REGISTER_604 = 656,
            SHODOW_HOLDING_REGISTER_605 = 657,
            SHODOW_HOLDING_REGISTER_606 = 658,
            SHODOW_HOLDING_REGISTER_607 = 659,
            SHODOW_HOLDING_REGISTER_608 = 660,
            SHODOW_HOLDING_REGISTER_609 = 661,
            SHODOW_HOLDING_REGISTER_610 = 662,
            SHODOW_HOLDING_REGISTER_611 = 663,
            SHODOW_HOLDING_REGISTER_612 = 664,
            SHODOW_HOLDING_REGISTER_613 = 665,
            SHODOW_HOLDING_REGISTER_614 = 666,
            SHODOW_HOLDING_REGISTER_615 = 667,
            SHODOW_HOLDING_REGISTER_616 = 668,
            SHODOW_HOLDING_REGISTER_617 = 669,
            SHODOW_HOLDING_REGISTER_618 = 670,
            SHODOW_HOLDING_REGISTER_619 = 671,
            SHODOW_HOLDING_REGISTER_620 = 672,
            SHODOW_HOLDING_REGISTER_621 = 673,
            SHODOW_HOLDING_REGISTER_622 = 674,
            SHODOW_HOLDING_REGISTER_623 = 675,
            SHODOW_HOLDING_REGISTER_624 = 676,
            SHODOW_HOLDING_REGISTER_625 = 677,
            SHODOW_HOLDING_REGISTER_626 = 678,
            SHODOW_HOLDING_REGISTER_627 = 679,
            SHODOW_HOLDING_REGISTER_628 = 680,
            SHODOW_HOLDING_REGISTER_629 = 681,
            SHODOW_HOLDING_REGISTER_630 = 682,
            SHODOW_HOLDING_REGISTER_631 = 683,
            SHODOW_HOLDING_REGISTER_632 = 684,
            SHODOW_HOLDING_REGISTER_633 = 685,
            SHODOW_HOLDING_REGISTER_634 = 686,
            SHODOW_HOLDING_REGISTER_635 = 687,
            SHODOW_HOLDING_REGISTER_636 = 688,
            SHODOW_HOLDING_REGISTER_637 = 689,
            SHODOW_HOLDING_REGISTER_638 = 690,
            SHODOW_HOLDING_REGISTER_639 = 691,
            SHODOW_HOLDING_REGISTER_640 = 692,
            SHODOW_HOLDING_REGISTER_641 = 693,
            SHODOW_HOLDING_REGISTER_642 = 694,
            SHODOW_HOLDING_REGISTER_643 = 695,
            SHODOW_HOLDING_REGISTER_644 = 696,
            SHODOW_HOLDING_REGISTER_645 = 697,
            SHODOW_HOLDING_REGISTER_646 = 698,
            SHODOW_HOLDING_REGISTER_647 = 699,
            SHODOW_HOLDING_REGISTER_648 = 700,
            SHODOW_HOLDING_REGISTER_649 = 701,
            SHODOW_HOLDING_REGISTER_650 = 702,
            SHODOW_HOLDING_REGISTER_651 = 703,
            SHODOW_HOLDING_REGISTER_652 = 704,
            SHODOW_HOLDING_REGISTER_653 = 705,
            SHODOW_HOLDING_REGISTER_654 = 706,
            SHODOW_HOLDING_REGISTER_655 = 707,
            SHODOW_HOLDING_REGISTER_656 = 708,
            SHODOW_HOLDING_REGISTER_657 = 709,
            SHODOW_HOLDING_REGISTER_658 = 710,
            SHODOW_HOLDING_REGISTER_659 = 711,
            SHODOW_HOLDING_REGISTER_660 = 712,
            SHODOW_HOLDING_REGISTER_661 = 713,
            SHODOW_HOLDING_REGISTER_662 = 714,
            SHODOW_HOLDING_REGISTER_663 = 715,
            SHODOW_HOLDING_REGISTER_664 = 716,
            SHODOW_HOLDING_REGISTER_665 = 717,
            SHODOW_HOLDING_REGISTER_666 = 718,
            SHODOW_HOLDING_REGISTER_667 = 719,
            SHODOW_HOLDING_REGISTER_668 = 720,
            SHODOW_HOLDING_REGISTER_669 = 721,
            SHODOW_HOLDING_REGISTER_670 = 722,
            SHODOW_HOLDING_REGISTER_671 = 723,
            SHODOW_HOLDING_REGISTER_672 = 724,
            SHODOW_HOLDING_REGISTER_673 = 725,
            SHODOW_HOLDING_REGISTER_674 = 726,
            SHODOW_HOLDING_REGISTER_675 = 727,
            SHODOW_HOLDING_REGISTER_676 = 728,
            SHODOW_HOLDING_REGISTER_677 = 729,
            SHODOW_HOLDING_REGISTER_678 = 730,
            SHODOW_HOLDING_REGISTER_679 = 731,
            SHODOW_HOLDING_REGISTER_680 = 732,
            SHODOW_HOLDING_REGISTER_681 = 733,
            SHODOW_HOLDING_REGISTER_682 = 734,
            SHODOW_HOLDING_REGISTER_683 = 735,
            SHODOW_HOLDING_REGISTER_684 = 736,
            SHODOW_HOLDING_REGISTER_685 = 737,
            SHODOW_HOLDING_REGISTER_686 = 738,
            SHODOW_HOLDING_REGISTER_687 = 739,
            SHODOW_HOLDING_REGISTER_688 = 740,
            SHODOW_HOLDING_REGISTER_689 = 741,
            SHODOW_HOLDING_REGISTER_690 = 742,
            SHODOW_HOLDING_REGISTER_691 = 743,
            SHODOW_HOLDING_REGISTER_692 = 744,
            SHODOW_HOLDING_REGISTER_693 = 745,
            SHODOW_HOLDING_REGISTER_694 = 746,
            SHODOW_HOLDING_REGISTER_695 = 747,
            SHODOW_HOLDING_REGISTER_696 = 748,
            SHODOW_HOLDING_REGISTER_697 = 749,
            SHODOW_HOLDING_REGISTER_698 = 750,
            SHODOW_HOLDING_REGISTER_699 = 751,
            SHODOW_HOLDING_REGISTER_700 = 752,
            SHODOW_HOLDING_REGISTER_701 = 753,
            SHODOW_HOLDING_REGISTER_702 = 754,
            SHODOW_HOLDING_REGISTER_703 = 755,
            SHODOW_HOLDING_REGISTER_704 = 756,
            SHODOW_HOLDING_REGISTER_705 = 757,
            SHODOW_HOLDING_REGISTER_706 = 758,
            SHODOW_HOLDING_REGISTER_707 = 759,
            SHODOW_HOLDING_REGISTER_708 = 760,
            SHODOW_HOLDING_REGISTER_709 = 761,
            SHODOW_HOLDING_REGISTER_710 = 762,
            SHODOW_HOLDING_REGISTER_711 = 763,
            SHODOW_HOLDING_REGISTER_712 = 764,
            SHODOW_HOLDING_REGISTER_713 = 765,
            SHODOW_HOLDING_REGISTER_714 = 766,
            SHODOW_HOLDING_REGISTER_715 = 767,
            SHODOW_HOLDING_REGISTER_716 = 768,
            SHODOW_HOLDING_REGISTER_717 = 769,
            SHODOW_HOLDING_REGISTER_718 = 770,
            SHODOW_HOLDING_REGISTER_719 = 771,
            SHODOW_HOLDING_REGISTER_720 = 772,
            SHODOW_HOLDING_REGISTER_721 = 773,
            SHODOW_HOLDING_REGISTER_722 = 774,
            SHODOW_HOLDING_REGISTER_723 = 775,
            SHODOW_HOLDING_REGISTER_724 = 776,
            SHODOW_HOLDING_REGISTER_725 = 777,
            SHODOW_HOLDING_REGISTER_726 = 778,
            SHODOW_HOLDING_REGISTER_727 = 779,
            SHODOW_HOLDING_REGISTER_728 = 780,
            SHODOW_HOLDING_REGISTER_729 = 781,
            SHODOW_HOLDING_REGISTER_730 = 782,
            SHODOW_HOLDING_REGISTER_731 = 783,
            SHODOW_HOLDING_REGISTER_732 = 784,
            SHODOW_HOLDING_REGISTER_733 = 785,
            SHODOW_HOLDING_REGISTER_734 = 786,
            SHODOW_HOLDING_REGISTER_735 = 787,
            SHODOW_HOLDING_REGISTER_736 = 788,
            SHODOW_HOLDING_REGISTER_737 = 789,
            SHODOW_HOLDING_REGISTER_738 = 790,
            SHODOW_HOLDING_REGISTER_739 = 791,
            SHODOW_HOLDING_REGISTER_740 = 792,
            SHODOW_HOLDING_REGISTER_741 = 793,
            SHODOW_HOLDING_REGISTER_742 = 794,
            SHODOW_HOLDING_REGISTER_743 = 795,
            SHODOW_HOLDING_REGISTER_744 = 796,
            SHODOW_HOLDING_REGISTER_745 = 797,
            SHODOW_HOLDING_REGISTER_746 = 798,
            SHODOW_HOLDING_REGISTER_747 = 799,
            SHODOW_HOLDING_REGISTER_748 = 800,
            SHODOW_HOLDING_REGISTER_749 = 801,
            SHODOW_HOLDING_REGISTER_750 = 802,
            SHODOW_HOLDING_REGISTER_751 = 803,
            SHODOW_HOLDING_REGISTER_752 = 804,
            SHODOW_HOLDING_REGISTER_753 = 805,
            SHODOW_HOLDING_REGISTER_754 = 806,
            SHODOW_HOLDING_REGISTER_755 = 807,
            SHODOW_HOLDING_REGISTER_756 = 808,
            SHODOW_HOLDING_REGISTER_757 = 809,
            SHODOW_HOLDING_REGISTER_758 = 810,
            SHODOW_HOLDING_REGISTER_759 = 811,
            SHODOW_HOLDING_REGISTER_760 = 812,
            SHODOW_HOLDING_REGISTER_761 = 813,
            SHODOW_HOLDING_REGISTER_762 = 814,
            SHODOW_HOLDING_REGISTER_763 = 815,
            SHODOW_HOLDING_REGISTER_764 = 816,
            SHODOW_HOLDING_REGISTER_765 = 817,
            SHODOW_HOLDING_REGISTER_766 = 818,
            SHODOW_HOLDING_REGISTER_767 = 819,
            SHODOW_HOLDING_REGISTER_768 = 820,
            SHODOW_HOLDING_REGISTER_769 = 821,
            SHODOW_HOLDING_REGISTER_770 = 822,
            SHODOW_HOLDING_REGISTER_771 = 823,
            SHODOW_HOLDING_REGISTER_772 = 824,
            SHODOW_HOLDING_REGISTER_773 = 825,
            SHODOW_HOLDING_REGISTER_774 = 826,
            SHODOW_HOLDING_REGISTER_775 = 827,
            SHODOW_HOLDING_REGISTER_776 = 828,
            SHODOW_HOLDING_REGISTER_777 = 829,
            SHODOW_HOLDING_REGISTER_778 = 830,
            SHODOW_HOLDING_REGISTER_779 = 831,
            SHODOW_HOLDING_REGISTER_780 = 832,
            SHODOW_HOLDING_REGISTER_781 = 833,
            SHODOW_HOLDING_REGISTER_782 = 834,
            SHODOW_HOLDING_REGISTER_783 = 835,
            SHODOW_HOLDING_REGISTER_784 = 836,
            SHODOW_HOLDING_REGISTER_785 = 837,
            SHODOW_HOLDING_REGISTER_786 = 838,
            SHODOW_HOLDING_REGISTER_787 = 839,
            SHODOW_HOLDING_REGISTER_788 = 840,
            SHODOW_HOLDING_REGISTER_789 = 841,
            SHODOW_HOLDING_REGISTER_790 = 842,
            SHODOW_HOLDING_REGISTER_791 = 843,
            SHODOW_HOLDING_REGISTER_792 = 844,
            SHODOW_HOLDING_REGISTER_793 = 845,
            SHODOW_HOLDING_REGISTER_794 = 846,
            SHODOW_HOLDING_REGISTER_795 = 847,
            SHODOW_HOLDING_REGISTER_796 = 848,
            SHODOW_HOLDING_REGISTER_797 = 849,
            SHODOW_HOLDING_REGISTER_798 = 850,
            SHODOW_HOLDING_REGISTER_799 = 851,
            SHODOW_HOLDING_REGISTER_800 = 852,
            SHODOW_HOLDING_REGISTER_801 = 853,
            SHODOW_HOLDING_REGISTER_802 = 854,
            SHODOW_HOLDING_REGISTER_803 = 855,
            SHODOW_HOLDING_REGISTER_804 = 856,
            SHODOW_HOLDING_REGISTER_805 = 857,
            SHODOW_HOLDING_REGISTER_806 = 858,
            SHODOW_HOLDING_REGISTER_807 = 859,
            SHODOW_HOLDING_REGISTER_808 = 860,
            SHODOW_HOLDING_REGISTER_809 = 861,
            SHODOW_HOLDING_REGISTER_810 = 862,
            SHODOW_HOLDING_REGISTER_811 = 863,
            SHODOW_HOLDING_REGISTER_812 = 864,
            SHODOW_HOLDING_REGISTER_813 = 865,
            SHODOW_HOLDING_REGISTER_814 = 866,
            SHODOW_HOLDING_REGISTER_815 = 867,
            SHODOW_HOLDING_REGISTER_816 = 868,
            SHODOW_HOLDING_REGISTER_817 = 869,
            SHODOW_HOLDING_REGISTER_818 = 870,
            SHODOW_HOLDING_REGISTER_819 = 871,
            SHODOW_HOLDING_REGISTER_820 = 872,
            SHODOW_HOLDING_REGISTER_821 = 873,
            SHODOW_HOLDING_REGISTER_822 = 874,
            SHODOW_HOLDING_REGISTER_823 = 875,
            SHODOW_HOLDING_REGISTER_824 = 876,
            SHODOW_HOLDING_REGISTER_825 = 877,
            SHODOW_HOLDING_REGISTER_826 = 878,
            SHODOW_HOLDING_REGISTER_827 = 879,
            SHODOW_HOLDING_REGISTER_828 = 880,
            SHODOW_HOLDING_REGISTER_829 = 881,
            SHODOW_HOLDING_REGISTER_830 = 882,
            SHODOW_HOLDING_REGISTER_831 = 883,
            SHODOW_HOLDING_REGISTER_832 = 884,
            SHODOW_HOLDING_REGISTER_833 = 885,
            SHODOW_HOLDING_REGISTER_834 = 886,
            SHODOW_HOLDING_REGISTER_835 = 887,
            SHODOW_HOLDING_REGISTER_836 = 888,
            SHODOW_HOLDING_REGISTER_837 = 889,
            SHODOW_HOLDING_REGISTER_838 = 890,
            SHODOW_HOLDING_REGISTER_839 = 891,
            SHODOW_HOLDING_REGISTER_840 = 892,
            SHODOW_HOLDING_REGISTER_841 = 893,
            SHODOW_HOLDING_REGISTER_842 = 894,
            SHODOW_HOLDING_REGISTER_843 = 895,
            SHODOW_HOLDING_REGISTER_844 = 896,
            SHODOW_HOLDING_REGISTER_845 = 897,
            SHODOW_HOLDING_REGISTER_846 = 898,
            SHODOW_HOLDING_REGISTER_847 = 899,
            SHODOW_HOLDING_REGISTER_848 = 900,
            SHODOW_HOLDING_REGISTER_849 = 901,
            SHODOW_HOLDING_REGISTER_850 = 902,
            SHODOW_HOLDING_REGISTER_851 = 903,
            SHODOW_HOLDING_REGISTER_852 = 904,
            SHODOW_HOLDING_REGISTER_853 = 905,
            SHODOW_HOLDING_REGISTER_854 = 906,
            SHODOW_HOLDING_REGISTER_855 = 907,
            SHODOW_HOLDING_REGISTER_856 = 908,
            SHODOW_HOLDING_REGISTER_857 = 909,
            SHODOW_HOLDING_REGISTER_858 = 910,
            SHODOW_HOLDING_REGISTER_859 = 911,
            SHODOW_HOLDING_REGISTER_860 = 912,
            SHODOW_HOLDING_REGISTER_861 = 913,
            SHODOW_HOLDING_REGISTER_862 = 914,
            SHODOW_HOLDING_REGISTER_863 = 915,
            SHODOW_HOLDING_REGISTER_864 = 916,
            SHODOW_HOLDING_REGISTER_865 = 917,
            SHODOW_HOLDING_REGISTER_866 = 918,
            SHODOW_HOLDING_REGISTER_867 = 919,
            SHODOW_HOLDING_REGISTER_868 = 920,
            SHODOW_HOLDING_REGISTER_869 = 921,
            SHODOW_HOLDING_REGISTER_870 = 922,
            SHODOW_HOLDING_REGISTER_871 = 923,
            SHODOW_HOLDING_REGISTER_872 = 924,
            SHODOW_HOLDING_REGISTER_873 = 925,
            SHODOW_HOLDING_REGISTER_874 = 926,
            SHODOW_HOLDING_REGISTER_875 = 927,
            SHODOW_HOLDING_REGISTER_876 = 928,
            SHODOW_HOLDING_REGISTER_877 = 929,
            SHODOW_HOLDING_REGISTER_878 = 930,
            SHODOW_HOLDING_REGISTER_879 = 931,
            SHODOW_HOLDING_REGISTER_880 = 932,
            SHODOW_HOLDING_REGISTER_881 = 933,
            SHODOW_HOLDING_REGISTER_882 = 934,
            SHODOW_HOLDING_REGISTER_883 = 935,
            SHODOW_HOLDING_REGISTER_884 = 936,
            SHODOW_HOLDING_REGISTER_885 = 937,
            SHODOW_HOLDING_REGISTER_886 = 938,
            SHODOW_HOLDING_REGISTER_887 = 939,
            SHODOW_HOLDING_REGISTER_888 = 940,
            SHODOW_HOLDING_REGISTER_889 = 941,
            SHODOW_HOLDING_REGISTER_890 = 942,
            SHODOW_HOLDING_REGISTER_891 = 943,
            SHODOW_HOLDING_REGISTER_892 = 944,
            SHODOW_HOLDING_REGISTER_893 = 945,
            SHODOW_HOLDING_REGISTER_894 = 946,
            SHODOW_HOLDING_REGISTER_895 = 947,
            SHODOW_HOLDING_REGISTER_896 = 948,
            SHODOW_HOLDING_REGISTER_897 = 949,
            SHODOW_HOLDING_REGISTER_898 = 950,
            SHODOW_HOLDING_REGISTER_899 = 951,
            SHODOW_HOLDING_REGISTER_900 = 952,
            SHODOW_HOLDING_REGISTER_901 = 953,
            SHODOW_HOLDING_REGISTER_902 = 954,
            SHODOW_HOLDING_REGISTER_903 = 955,
            SHODOW_HOLDING_REGISTER_904 = 956,
            SHODOW_HOLDING_REGISTER_905 = 957,
            SHODOW_HOLDING_REGISTER_906 = 958,
            SHODOW_HOLDING_REGISTER_907 = 959,
            SHODOW_HOLDING_REGISTER_908 = 960,
            SHODOW_HOLDING_REGISTER_909 = 961,
            SHODOW_HOLDING_REGISTER_910 = 962,
            SHODOW_HOLDING_REGISTER_911 = 963,
            SHODOW_HOLDING_REGISTER_912 = 964,
            SHODOW_HOLDING_REGISTER_913 = 965,
            SHODOW_HOLDING_REGISTER_914 = 966,
            SHODOW_HOLDING_REGISTER_915 = 967,
            SHODOW_HOLDING_REGISTER_916 = 968,
            SHODOW_HOLDING_REGISTER_917 = 969,
            SHODOW_HOLDING_REGISTER_918 = 970,
            SHODOW_HOLDING_REGISTER_919 = 971,
            SHODOW_HOLDING_REGISTER_920 = 972,
            SHODOW_HOLDING_REGISTER_921 = 973,
            SHODOW_HOLDING_REGISTER_922 = 974,
            SHODOW_HOLDING_REGISTER_923 = 975,
            SHODOW_HOLDING_REGISTER_924 = 976,
            SHODOW_HOLDING_REGISTER_925 = 977,
            SHODOW_HOLDING_REGISTER_926 = 978,
            SHODOW_HOLDING_REGISTER_927 = 979,
            SHODOW_HOLDING_REGISTER_928 = 980,
            SHODOW_HOLDING_REGISTER_929 = 981,
            SHODOW_HOLDING_REGISTER_930 = 982,
            SHODOW_HOLDING_REGISTER_931 = 983,
            SHODOW_HOLDING_REGISTER_932 = 984,
            SHODOW_HOLDING_REGISTER_933 = 985,
            SHODOW_HOLDING_REGISTER_934 = 986,
            SHODOW_HOLDING_REGISTER_935 = 987,
            SHODOW_HOLDING_REGISTER_936 = 988,
            SHODOW_HOLDING_REGISTER_937 = 989,
            SHODOW_HOLDING_REGISTER_938 = 990,
            SHODOW_HOLDING_REGISTER_939 = 991,
            SHODOW_HOLDING_REGISTER_940 = 992,
            SHODOW_HOLDING_REGISTER_941 = 993,
            SHODOW_HOLDING_REGISTER_942 = 994,
            SHODOW_HOLDING_REGISTER_943 = 995,
            SHODOW_HOLDING_REGISTER_944 = 996,
            SHODOW_HOLDING_REGISTER_945 = 997,
            SHODOW_HOLDING_REGISTER_946 = 998,
            SHODOW_HOLDING_REGISTER_947 = 999,
            SHODOW_HOLDING_REGISTER_948 = 1000,
            SHODOW_HOLDING_REGISTER_949 = 1001,
            SHODOW_HOLDING_REGISTER_950 = 1002,
            SHODOW_HOLDING_REGISTER_951 = 1003,
            SHODOW_HOLDING_REGISTER_952 = 1004,
            SHODOW_HOLDING_REGISTER_953 = 1005,
            SHODOW_HOLDING_REGISTER_954 = 1006,
            SHODOW_HOLDING_REGISTER_955 = 1007,
            SHODOW_HOLDING_REGISTER_956 = 1008,
            SHODOW_HOLDING_REGISTER_957 = 1009,
            SHODOW_HOLDING_REGISTER_958 = 1010,
            SHODOW_HOLDING_REGISTER_959 = 1011,
            SHODOW_HOLDING_REGISTER_960 = 1012,
            SHODOW_HOLDING_REGISTER_961 = 1013,
            SHODOW_HOLDING_REGISTER_962 = 1014,
            SHODOW_HOLDING_REGISTER_963 = 1015,
            SHODOW_HOLDING_REGISTER_964 = 1016,
            SHODOW_HOLDING_REGISTER_965 = 1017,
            SHODOW_HOLDING_REGISTER_966 = 1018,
            SHODOW_HOLDING_REGISTER_967 = 1019,
            SHODOW_HOLDING_REGISTER_968 = 1020,
            SHODOW_HOLDING_REGISTER_969 = 1021,
            SHODOW_HOLDING_REGISTER_970 = 1022,
            SHODOW_HOLDING_REGISTER_971 = 1023,
            SHODOW_HOLDING_REGISTER_972 = 1024,
            SHODOW_HOLDING_REGISTER_973 = 1025,
            SHODOW_HOLDING_REGISTER_974 = 1026,
            SHODOW_HOLDING_REGISTER_975 = 1027,
            SHODOW_HOLDING_REGISTER_976 = 1028,
            SHODOW_HOLDING_REGISTER_977 = 1029,
            SHODOW_HOLDING_REGISTER_978 = 1030,
            SHODOW_HOLDING_REGISTER_979 = 1031,
            SHODOW_HOLDING_REGISTER_980 = 1032,
            SHODOW_HOLDING_REGISTER_981 = 1033,
            SHODOW_HOLDING_REGISTER_982 = 1034,
            SHODOW_HOLDING_REGISTER_983 = 1035,
            SHODOW_HOLDING_REGISTER_984 = 1036,
            SHODOW_HOLDING_REGISTER_985 = 1037,
            SHODOW_HOLDING_REGISTER_986 = 1038,
            SHODOW_HOLDING_REGISTER_987 = 1039,
            SHODOW_HOLDING_REGISTER_988 = 1040,
            SHODOW_HOLDING_REGISTER_989 = 1041,
            SHODOW_HOLDING_REGISTER_990 = 1042,
            SHODOW_HOLDING_REGISTER_991 = 1043,
            SHODOW_HOLDING_REGISTER_992 = 1044,
            SHODOW_HOLDING_REGISTER_993 = 1045,
            SHODOW_HOLDING_REGISTER_994 = 1046,
            SHODOW_HOLDING_REGISTER_995 = 1047,
            SHODOW_HOLDING_REGISTER_996 = 1048,
            SHODOW_HOLDING_REGISTER_997 = 1049,
            SHODOW_HOLDING_REGISTER_998 = 1050,
            SHODOW_HOLDING_REGISTER_999 = 1051,
            SHODOW_HOLDING_REGISTER_CONFIG_0 = 1052,
            SHODOW_HOLDING_REGISTER_CONFIG_1 = 1053,
            SHODOW_HOLDING_REGISTER_CONFIG_2 = 1054,
            SHODOW_HOLDING_REGISTER_CONFIG_3 = 1055,
            SHODOW_HOLDING_REGISTER_CONFIG_4 = 1056,
            SHODOW_HOLDING_REGISTER_CONFIG_5 = 1057,
            SHODOW_HOLDING_REGISTER_CONFIG_6 = 1058,
            SHODOW_HOLDING_REGISTER_CONFIG_7 = 1059,
            SHODOW_HOLDING_REGISTER_CONFIG_8 = 1060,
            SHODOW_HOLDING_REGISTER_CONFIG_9 = 1061,
            SHODOW_HOLDING_REGISTER_CONFIG_10 = 1062,
            SHODOW_HOLDING_REGISTER_CONFIG_11 = 1063,
            SHODOW_HOLDING_REGISTER_CONFIG_12 = 1064,
            SHODOW_HOLDING_REGISTER_CONFIG_13 = 1065,
            SHODOW_HOLDING_REGISTER_CONFIG_14 = 1066,
            SHODOW_HOLDING_REGISTER_CONFIG_15 = 1067,
            SHODOW_HOLDING_REGISTER_CONFIG_16 = 1068,
            SHODOW_HOLDING_REGISTER_CONFIG_17 = 1069,
            SHODOW_HOLDING_REGISTER_CONFIG_18 = 1070,
            SHODOW_HOLDING_REGISTER_CONFIG_19 = 1071,
            SHODOW_HOLDING_REGISTER_CONFIG_20 = 1072,
            SHODOW_HOLDING_REGISTER_CONFIG_21 = 1073,
            SHODOW_HOLDING_REGISTER_CONFIG_22 = 1074,
            SHODOW_HOLDING_REGISTER_CONFIG_23 = 1075,
            SHODOW_HOLDING_REGISTER_CONFIG_24 = 1076,
            SHODOW_HOLDING_REGISTER_CONFIG_25 = 1077,
            SHODOW_HOLDING_REGISTER_CONFIG_26 = 1078,
            SHODOW_HOLDING_REGISTER_CONFIG_27 = 1079,
            SHODOW_HOLDING_REGISTER_CONFIG_28 = 1080,
            SHODOW_HOLDING_REGISTER_CONFIG_29 = 1081,
            SHODOW_HOLDING_REGISTER_CONFIG_30 = 1082,
            SHODOW_HOLDING_REGISTER_CONFIG_31 = 1083,
            SHODOW_HOLDING_REGISTER_CONFIG_32 = 1084,
            SHODOW_HOLDING_REGISTER_CONFIG_33 = 1085,
            SHODOW_HOLDING_REGISTER_CONFIG_34 = 1086,
            SHODOW_HOLDING_REGISTER_CONFIG_35 = 1087,
            SHODOW_HOLDING_REGISTER_CONFIG_36 = 1088,
            SHODOW_HOLDING_REGISTER_CONFIG_37 = 1089,
            SHODOW_HOLDING_REGISTER_CONFIG_38 = 1090,
            SHODOW_HOLDING_REGISTER_CONFIG_39 = 1091,
            SHODOW_HOLDING_REGISTER_CONFIG_40 = 1092,
            SHODOW_HOLDING_REGISTER_CONFIG_41 = 1093,
            SHODOW_HOLDING_REGISTER_CONFIG_42 = 1094,
            SHODOW_HOLDING_REGISTER_CONFIG_43 = 1095,
            SHODOW_HOLDING_REGISTER_CONFIG_44 = 1096,
            SHODOW_HOLDING_REGISTER_CONFIG_45 = 1097,
            SHODOW_HOLDING_REGISTER_CONFIG_46 = 1098,
            SHODOW_HOLDING_REGISTER_CONFIG_47 = 1099,
            SHODOW_HOLDING_REGISTER_CONFIG_48 = 1100,
            SHODOW_HOLDING_REGISTER_CONFIG_49 = 1101,
            SHODOW_HOLDING_REGISTER_CONFIG_50 = 1102,
            SHODOW_HOLDING_REGISTER_CONFIG_51 = 1103,
            SHODOW_HOLDING_REGISTER_CONFIG_52 = 1104,
            SHODOW_HOLDING_REGISTER_CONFIG_53 = 1105,
            SHODOW_HOLDING_REGISTER_CONFIG_54 = 1106,
            SHODOW_HOLDING_REGISTER_CONFIG_55 = 1107,
            SHODOW_HOLDING_REGISTER_CONFIG_56 = 1108,
            SHODOW_HOLDING_REGISTER_CONFIG_57 = 1109,
            SHODOW_HOLDING_REGISTER_CONFIG_58 = 1110,
            SHODOW_HOLDING_REGISTER_CONFIG_59 = 1111,
            SHODOW_HOLDING_REGISTER_CONFIG_60 = 1112,
            SHODOW_HOLDING_REGISTER_CONFIG_61 = 1113,
            SHODOW_HOLDING_REGISTER_CONFIG_62 = 1114,
            SHODOW_HOLDING_REGISTER_CONFIG_63 = 1115,
            SHODOW_HOLDING_REGISTER_CONFIG_64 = 1116,
            SHODOW_HOLDING_REGISTER_CONFIG_65 = 1117,
            SHODOW_HOLDING_REGISTER_CONFIG_66 = 1118,
            SHODOW_HOLDING_REGISTER_CONFIG_67 = 1119,
            SHODOW_HOLDING_REGISTER_CONFIG_68 = 1120,
            SHODOW_HOLDING_REGISTER_CONFIG_69 = 1121,
            SHODOW_HOLDING_REGISTER_CONFIG_70 = 1122,
            SHODOW_HOLDING_REGISTER_CONFIG_71 = 1123,
            SHODOW_HOLDING_REGISTER_CONFIG_72 = 1124,
            SHODOW_HOLDING_REGISTER_CONFIG_73 = 1125,
            SHODOW_HOLDING_REGISTER_CONFIG_74 = 1126,
            SHODOW_HOLDING_REGISTER_CONFIG_75 = 1127,
            SHODOW_HOLDING_REGISTER_CONFIG_76 = 1128,
            SHODOW_HOLDING_REGISTER_CONFIG_77 = 1129,
            SHODOW_HOLDING_REGISTER_CONFIG_78 = 1130,
            SHODOW_HOLDING_REGISTER_CONFIG_79 = 1131,
            SHODOW_HOLDING_REGISTER_CONFIG_80 = 1132,
            SHODOW_HOLDING_REGISTER_CONFIG_81 = 1133,
            SHODOW_HOLDING_REGISTER_CONFIG_82 = 1134,
            SHODOW_HOLDING_REGISTER_CONFIG_83 = 1135,
            SHODOW_HOLDING_REGISTER_CONFIG_84 = 1136,
            SHODOW_HOLDING_REGISTER_CONFIG_85 = 1137,
            SHODOW_HOLDING_REGISTER_CONFIG_86 = 1138,
            SHODOW_HOLDING_REGISTER_CONFIG_87 = 1139,
            SHODOW_HOLDING_REGISTER_CONFIG_88 = 1140,
            SHODOW_HOLDING_REGISTER_CONFIG_89 = 1141,
            SHODOW_HOLDING_REGISTER_CONFIG_90 = 1142,
            SHODOW_HOLDING_REGISTER_CONFIG_91 = 1143,
            SHODOW_HOLDING_REGISTER_CONFIG_92 = 1144,
            SHODOW_HOLDING_REGISTER_CONFIG_93 = 1145,
            SHODOW_HOLDING_REGISTER_CONFIG_94 = 1146,
            SHODOW_HOLDING_REGISTER_CONFIG_95 = 1147,
            SHODOW_HOLDING_REGISTER_CONFIG_96 = 1148,
            SHODOW_HOLDING_REGISTER_CONFIG_97 = 1149,
            SHODOW_HOLDING_REGISTER_CONFIG_98 = 1150,
            SHODOW_HOLDING_REGISTER_CONFIG_99 = 1151,
            SHODOW_HOLDING_REGISTER_CONFIG_100 = 1152,
            SHODOW_HOLDING_REGISTER_CONFIG_101 = 1153,
            SHODOW_HOLDING_REGISTER_CONFIG_102 = 1154,
            SHODOW_HOLDING_REGISTER_CONFIG_103 = 1155,
            SHODOW_HOLDING_REGISTER_CONFIG_104 = 1156,
            SHODOW_HOLDING_REGISTER_CONFIG_105 = 1157,
            SHODOW_HOLDING_REGISTER_CONFIG_106 = 1158,
            SHODOW_HOLDING_REGISTER_CONFIG_107 = 1159,
            SHODOW_HOLDING_REGISTER_CONFIG_108 = 1160,
            SHODOW_HOLDING_REGISTER_CONFIG_109 = 1161,
            SHODOW_HOLDING_REGISTER_CONFIG_110 = 1162,
            SHODOW_HOLDING_REGISTER_CONFIG_111 = 1163,
            SHODOW_HOLDING_REGISTER_CONFIG_112 = 1164,
            SHODOW_HOLDING_REGISTER_CONFIG_113 = 1165,
            SHODOW_HOLDING_REGISTER_CONFIG_114 = 1166,
            SHODOW_HOLDING_REGISTER_CONFIG_115 = 1167,
            SHODOW_HOLDING_REGISTER_CONFIG_116 = 1168,
            SHODOW_HOLDING_REGISTER_CONFIG_117 = 1169,
            SHODOW_HOLDING_REGISTER_CONFIG_118 = 1170,
            SHODOW_HOLDING_REGISTER_CONFIG_119 = 1171,
            SHODOW_HOLDING_REGISTER_CONFIG_120 = 1172,
            SHODOW_HOLDING_REGISTER_CONFIG_121 = 1173,
            SHODOW_HOLDING_REGISTER_CONFIG_122 = 1174,
            SHODOW_HOLDING_REGISTER_CONFIG_123 = 1175,
            SHODOW_HOLDING_REGISTER_CONFIG_124 = 1176,
            SHODOW_HOLDING_REGISTER_CONFIG_125 = 1177,
            SHODOW_HOLDING_REGISTER_CONFIG_126 = 1178,
            SHODOW_HOLDING_REGISTER_CONFIG_127 = 1179,
            SHODOW_HOLDING_REGISTER_CONFIG_128 = 1180,
            SHODOW_HOLDING_REGISTER_CONFIG_129 = 1181,
            SHODOW_HOLDING_REGISTER_CONFIG_130 = 1182,
            SHODOW_HOLDING_REGISTER_CONFIG_131 = 1183,
            SHODOW_HOLDING_REGISTER_CONFIG_132 = 1184,
            SHODOW_HOLDING_REGISTER_CONFIG_133 = 1185,
            SHODOW_HOLDING_REGISTER_CONFIG_134 = 1186,
            SHODOW_HOLDING_REGISTER_CONFIG_135 = 1187,
            SHODOW_HOLDING_REGISTER_CONFIG_136 = 1188,
            SHODOW_HOLDING_REGISTER_CONFIG_137 = 1189,
            SHODOW_HOLDING_REGISTER_CONFIG_138 = 1190,
            SHODOW_HOLDING_REGISTER_CONFIG_139 = 1191,
            SHODOW_HOLDING_REGISTER_CONFIG_140 = 1192,
            SHODOW_HOLDING_REGISTER_CONFIG_141 = 1193,
            SHODOW_HOLDING_REGISTER_CONFIG_142 = 1194,
            SHODOW_HOLDING_REGISTER_CONFIG_143 = 1195,
            SHODOW_HOLDING_REGISTER_CONFIG_144 = 1196,
            SHODOW_HOLDING_REGISTER_CONFIG_145 = 1197,
            SHODOW_HOLDING_REGISTER_CONFIG_146 = 1198,
            SHODOW_HOLDING_REGISTER_CONFIG_147 = 1199,
            SHODOW_HOLDING_REGISTER_CONFIG_148 = 1200,
            SHODOW_HOLDING_REGISTER_CONFIG_149 = 1201,
            SHODOW_HOLDING_REGISTER_CONFIG_150 = 1202,
            SHODOW_HOLDING_REGISTER_CONFIG_151 = 1203,
            SHODOW_HOLDING_REGISTER_CONFIG_152 = 1204,
            SHODOW_HOLDING_REGISTER_CONFIG_153 = 1205,
            SHODOW_HOLDING_REGISTER_CONFIG_154 = 1206,
            SHODOW_HOLDING_REGISTER_CONFIG_155 = 1207,
            SHODOW_HOLDING_REGISTER_CONFIG_156 = 1208,
            SHODOW_HOLDING_REGISTER_CONFIG_157 = 1209,
            SHODOW_HOLDING_REGISTER_CONFIG_158 = 1210,
            SHODOW_HOLDING_REGISTER_CONFIG_159 = 1211,
            SHODOW_HOLDING_REGISTER_CONFIG_160 = 1212,
            SHODOW_HOLDING_REGISTER_CONFIG_161 = 1213,
            SHODOW_HOLDING_REGISTER_CONFIG_162 = 1214,
            SHODOW_HOLDING_REGISTER_CONFIG_163 = 1215,
            SHODOW_HOLDING_REGISTER_CONFIG_164 = 1216,
            SHODOW_HOLDING_REGISTER_CONFIG_165 = 1217,
            SHODOW_HOLDING_REGISTER_CONFIG_166 = 1218,
            SHODOW_HOLDING_REGISTER_CONFIG_167 = 1219,
            SHODOW_HOLDING_REGISTER_CONFIG_168 = 1220,
            SHODOW_HOLDING_REGISTER_CONFIG_169 = 1221,
            SHODOW_HOLDING_REGISTER_CONFIG_170 = 1222,
            SHODOW_HOLDING_REGISTER_CONFIG_171 = 1223,
            SHODOW_HOLDING_REGISTER_CONFIG_172 = 1224,
            SHODOW_HOLDING_REGISTER_CONFIG_173 = 1225,
            SHODOW_HOLDING_REGISTER_CONFIG_174 = 1226,
            SHODOW_HOLDING_REGISTER_CONFIG_175 = 1227,
            SHODOW_HOLDING_REGISTER_CONFIG_176 = 1228,
            SHODOW_HOLDING_REGISTER_CONFIG_177 = 1229,
            SHODOW_HOLDING_REGISTER_CONFIG_178 = 1230,
            SHODOW_HOLDING_REGISTER_CONFIG_179 = 1231,
            SHODOW_HOLDING_REGISTER_CONFIG_180 = 1232,
            SHODOW_HOLDING_REGISTER_CONFIG_181 = 1233,
            SHODOW_HOLDING_REGISTER_CONFIG_182 = 1234,
            SHODOW_HOLDING_REGISTER_CONFIG_183 = 1235,
            SHODOW_HOLDING_REGISTER_CONFIG_184 = 1236,
            SHODOW_HOLDING_REGISTER_CONFIG_185 = 1237,
            SHODOW_HOLDING_REGISTER_CONFIG_186 = 1238,
            SHODOW_HOLDING_REGISTER_CONFIG_187 = 1239,
            SHODOW_HOLDING_REGISTER_CONFIG_188 = 1240,
            SHODOW_HOLDING_REGISTER_CONFIG_189 = 1241,
            SHODOW_HOLDING_REGISTER_CONFIG_190 = 1242,
            SHODOW_HOLDING_REGISTER_CONFIG_191 = 1243,
            SHODOW_HOLDING_REGISTER_CONFIG_192 = 1244,
            SHODOW_HOLDING_REGISTER_CONFIG_193 = 1245,
            SHODOW_HOLDING_REGISTER_CONFIG_194 = 1246,
            SHODOW_HOLDING_REGISTER_CONFIG_195 = 1247,
            SHODOW_HOLDING_REGISTER_CONFIG_196 = 1248,
            SHODOW_HOLDING_REGISTER_CONFIG_197 = 1249,
            SHODOW_HOLDING_REGISTER_CONFIG_198 = 1250,
            SHODOW_HOLDING_REGISTER_CONFIG_199 = 1251,
            SHODOW_HOLDING_REGISTER_CONFIG_200 = 1252,
            SHODOW_HOLDING_REGISTER_CONFIG_201 = 1253,
            SHODOW_HOLDING_REGISTER_CONFIG_202 = 1254,
            SHODOW_HOLDING_REGISTER_CONFIG_203 = 1255,
            SHODOW_HOLDING_REGISTER_CONFIG_204 = 1256,
            SHODOW_HOLDING_REGISTER_CONFIG_205 = 1257,
            SHODOW_HOLDING_REGISTER_CONFIG_206 = 1258,
            SHODOW_HOLDING_REGISTER_CONFIG_207 = 1259,
            SHODOW_HOLDING_REGISTER_CONFIG_208 = 1260,
            SHODOW_HOLDING_REGISTER_CONFIG_209 = 1261,
            SHODOW_HOLDING_REGISTER_CONFIG_210 = 1262,
            SHODOW_HOLDING_REGISTER_CONFIG_211 = 1263,
            SHODOW_HOLDING_REGISTER_CONFIG_212 = 1264,
            SHODOW_HOLDING_REGISTER_CONFIG_213 = 1265,
            SHODOW_HOLDING_REGISTER_CONFIG_214 = 1266,
            SHODOW_HOLDING_REGISTER_CONFIG_215 = 1267,
            SHODOW_HOLDING_REGISTER_CONFIG_216 = 1268,
            SHODOW_HOLDING_REGISTER_CONFIG_217 = 1269,
            SHODOW_HOLDING_REGISTER_CONFIG_218 = 1270,
            SHODOW_HOLDING_REGISTER_CONFIG_219 = 1271,
            SHODOW_HOLDING_REGISTER_CONFIG_220 = 1272,
            SHODOW_HOLDING_REGISTER_CONFIG_221 = 1273,
            SHODOW_HOLDING_REGISTER_CONFIG_222 = 1274,
            SHODOW_HOLDING_REGISTER_CONFIG_223 = 1275,
            SHODOW_HOLDING_REGISTER_CONFIG_224 = 1276,
            SHODOW_HOLDING_REGISTER_CONFIG_225 = 1277,
            SHODOW_HOLDING_REGISTER_CONFIG_226 = 1278,
            SHODOW_HOLDING_REGISTER_CONFIG_227 = 1279,
            SHODOW_HOLDING_REGISTER_CONFIG_228 = 1280,
            SHODOW_HOLDING_REGISTER_CONFIG_229 = 1281,
            SHODOW_HOLDING_REGISTER_CONFIG_230 = 1282,
            SHODOW_HOLDING_REGISTER_CONFIG_231 = 1283,
            SHODOW_HOLDING_REGISTER_CONFIG_232 = 1284,
            SHODOW_HOLDING_REGISTER_CONFIG_233 = 1285,
            SHODOW_HOLDING_REGISTER_CONFIG_234 = 1286,
            SHODOW_HOLDING_REGISTER_CONFIG_235 = 1287,
            SHODOW_HOLDING_REGISTER_CONFIG_236 = 1288,
            SHODOW_HOLDING_REGISTER_CONFIG_237 = 1289,
            SHODOW_HOLDING_REGISTER_CONFIG_238 = 1290,
            SHODOW_HOLDING_REGISTER_CONFIG_239 = 1291,
            SHODOW_HOLDING_REGISTER_CONFIG_240 = 1292,
            SHODOW_HOLDING_REGISTER_CONFIG_241 = 1293,
            SHODOW_HOLDING_REGISTER_CONFIG_242 = 1294,
            SHODOW_HOLDING_REGISTER_CONFIG_243 = 1295,
            SHODOW_HOLDING_REGISTER_CONFIG_244 = 1296,
            SHODOW_HOLDING_REGISTER_CONFIG_245 = 1297,
            SHODOW_HOLDING_REGISTER_CONFIG_246 = 1298,
            SHODOW_HOLDING_REGISTER_CONFIG_247 = 1299,
            SHODOW_HOLDING_REGISTER_CONFIG_248 = 1300,
            SHODOW_HOLDING_REGISTER_CONFIG_249 = 1301,
            SHODOW_HOLDING_REGISTER_CONFIG_250 = 1302,
            SHODOW_HOLDING_REGISTER_CONFIG_251 = 1303,
            SHODOW_HOLDING_REGISTER_CONFIG_252 = 1304,
            SHODOW_HOLDING_REGISTER_CONFIG_253 = 1305,
            SHODOW_HOLDING_REGISTER_CONFIG_254 = 1306,
            SHODOW_HOLDING_REGISTER_CONFIG_255 = 1307,
            SHODOW_HOLDING_REGISTER_CONFIG_256 = 1308,
            SHODOW_HOLDING_REGISTER_CONFIG_257 = 1309,
            SHODOW_HOLDING_REGISTER_CONFIG_258 = 1310,
            SHODOW_HOLDING_REGISTER_CONFIG_259 = 1311,
            SHODOW_HOLDING_REGISTER_CONFIG_260 = 1312,
            SHODOW_HOLDING_REGISTER_CONFIG_261 = 1313,
            SHODOW_HOLDING_REGISTER_CONFIG_262 = 1314,
            SHODOW_HOLDING_REGISTER_CONFIG_263 = 1315,
            SHODOW_HOLDING_REGISTER_CONFIG_264 = 1316,
            SHODOW_HOLDING_REGISTER_CONFIG_265 = 1317,
            SHODOW_HOLDING_REGISTER_CONFIG_266 = 1318,
            SHODOW_HOLDING_REGISTER_CONFIG_267 = 1319,
            SHODOW_HOLDING_REGISTER_CONFIG_268 = 1320,
            SHODOW_HOLDING_REGISTER_CONFIG_269 = 1321,
            SHODOW_HOLDING_REGISTER_CONFIG_270 = 1322,
            SHODOW_HOLDING_REGISTER_CONFIG_271 = 1323,
            SHODOW_HOLDING_REGISTER_CONFIG_272 = 1324,
            SHODOW_HOLDING_REGISTER_CONFIG_273 = 1325,
            SHODOW_HOLDING_REGISTER_CONFIG_274 = 1326,
            SHODOW_HOLDING_REGISTER_CONFIG_275 = 1327,
            SHODOW_HOLDING_REGISTER_CONFIG_276 = 1328,
            SHODOW_HOLDING_REGISTER_CONFIG_277 = 1329,
            SHODOW_HOLDING_REGISTER_CONFIG_278 = 1330,
            SHODOW_HOLDING_REGISTER_CONFIG_279 = 1331,
            SHODOW_HOLDING_REGISTER_CONFIG_280 = 1332,
            SHODOW_HOLDING_REGISTER_CONFIG_281 = 1333,
            SHODOW_HOLDING_REGISTER_CONFIG_282 = 1334,
            SHODOW_HOLDING_REGISTER_CONFIG_283 = 1335,
            SHODOW_HOLDING_REGISTER_CONFIG_284 = 1336,
            SHODOW_HOLDING_REGISTER_CONFIG_285 = 1337,
            SHODOW_HOLDING_REGISTER_CONFIG_286 = 1338,
            SHODOW_HOLDING_REGISTER_CONFIG_287 = 1339,
            SHODOW_HOLDING_REGISTER_CONFIG_288 = 1340,
            SHODOW_HOLDING_REGISTER_CONFIG_289 = 1341,
            SHODOW_HOLDING_REGISTER_CONFIG_290 = 1342,
            SHODOW_HOLDING_REGISTER_CONFIG_291 = 1343,
            SHODOW_HOLDING_REGISTER_CONFIG_292 = 1344,
            SHODOW_HOLDING_REGISTER_CONFIG_293 = 1345,
            SHODOW_HOLDING_REGISTER_CONFIG_294 = 1346,
            SHODOW_HOLDING_REGISTER_CONFIG_295 = 1347,
            SHODOW_HOLDING_REGISTER_CONFIG_296 = 1348,
            SHODOW_HOLDING_REGISTER_CONFIG_297 = 1349,
            SHODOW_HOLDING_REGISTER_CONFIG_298 = 1350,
            SHODOW_HOLDING_REGISTER_CONFIG_299 = 1351,
            SHODOW_HOLDING_REGISTER_CONFIG_300 = 1352,
            SHODOW_HOLDING_REGISTER_CONFIG_301 = 1353,
            SHODOW_HOLDING_REGISTER_CONFIG_302 = 1354,
            SHODOW_HOLDING_REGISTER_CONFIG_303 = 1355,
            SHODOW_HOLDING_REGISTER_CONFIG_304 = 1356,
            SHODOW_HOLDING_REGISTER_CONFIG_305 = 1357,
            SHODOW_HOLDING_REGISTER_CONFIG_306 = 1358,
            SHODOW_HOLDING_REGISTER_CONFIG_307 = 1359,
            SHODOW_HOLDING_REGISTER_CONFIG_308 = 1360,
            SHODOW_HOLDING_REGISTER_CONFIG_309 = 1361,
            SHODOW_HOLDING_REGISTER_CONFIG_310 = 1362,
            SHODOW_HOLDING_REGISTER_CONFIG_311 = 1363,
            SHODOW_HOLDING_REGISTER_CONFIG_312 = 1364,
            SHODOW_HOLDING_REGISTER_CONFIG_313 = 1365,
            SHODOW_HOLDING_REGISTER_CONFIG_314 = 1366,
            SHODOW_HOLDING_REGISTER_CONFIG_315 = 1367,
            SHODOW_HOLDING_REGISTER_CONFIG_316 = 1368,
            SHODOW_HOLDING_REGISTER_CONFIG_317 = 1369,
            SHODOW_HOLDING_REGISTER_CONFIG_318 = 1370,
            SHODOW_HOLDING_REGISTER_CONFIG_319 = 1371,
            SHODOW_HOLDING_REGISTER_CONFIG_320 = 1372,
            SHODOW_HOLDING_REGISTER_CONFIG_321 = 1373,
            SHODOW_HOLDING_REGISTER_CONFIG_322 = 1374,
            SHODOW_HOLDING_REGISTER_CONFIG_323 = 1375,
            SHODOW_HOLDING_REGISTER_CONFIG_324 = 1376,
            SHODOW_HOLDING_REGISTER_CONFIG_325 = 1377,
            SHODOW_HOLDING_REGISTER_CONFIG_326 = 1378,
            SHODOW_HOLDING_REGISTER_CONFIG_327 = 1379,
            SHODOW_HOLDING_REGISTER_CONFIG_328 = 1380,
            SHODOW_HOLDING_REGISTER_CONFIG_329 = 1381,
            SHODOW_HOLDING_REGISTER_CONFIG_330 = 1382,
            SHODOW_HOLDING_REGISTER_CONFIG_331 = 1383,
            SHODOW_HOLDING_REGISTER_CONFIG_332 = 1384,
            SHODOW_HOLDING_REGISTER_CONFIG_333 = 1385,
            SHODOW_HOLDING_REGISTER_CONFIG_334 = 1386,
            SHODOW_HOLDING_REGISTER_CONFIG_335 = 1387,
            SHODOW_HOLDING_REGISTER_CONFIG_336 = 1388,
            SHODOW_HOLDING_REGISTER_CONFIG_337 = 1389,
            SHODOW_HOLDING_REGISTER_CONFIG_338 = 1390,
            SHODOW_HOLDING_REGISTER_CONFIG_339 = 1391,
            SHODOW_HOLDING_REGISTER_CONFIG_340 = 1392,
            SHODOW_HOLDING_REGISTER_CONFIG_341 = 1393,
            SHODOW_HOLDING_REGISTER_CONFIG_342 = 1394,
            SHODOW_HOLDING_REGISTER_CONFIG_343 = 1395,
            SHODOW_HOLDING_REGISTER_CONFIG_344 = 1396,
            SHODOW_HOLDING_REGISTER_CONFIG_345 = 1397,
            SHODOW_HOLDING_REGISTER_CONFIG_346 = 1398,
            SHODOW_HOLDING_REGISTER_CONFIG_347 = 1399,
            SHODOW_HOLDING_REGISTER_CONFIG_348 = 1400,
            SHODOW_HOLDING_REGISTER_CONFIG_349 = 1401,
            SHODOW_HOLDING_REGISTER_CONFIG_350 = 1402,
            SHODOW_HOLDING_REGISTER_CONFIG_351 = 1403,
            SHODOW_HOLDING_REGISTER_CONFIG_352 = 1404,
            SHODOW_HOLDING_REGISTER_CONFIG_353 = 1405,
            SHODOW_HOLDING_REGISTER_CONFIG_354 = 1406,
            SHODOW_HOLDING_REGISTER_CONFIG_355 = 1407,
            SHODOW_HOLDING_REGISTER_CONFIG_356 = 1408,
            SHODOW_HOLDING_REGISTER_CONFIG_357 = 1409,
            SHODOW_HOLDING_REGISTER_CONFIG_358 = 1410,
            SHODOW_HOLDING_REGISTER_CONFIG_359 = 1411,
            SHODOW_HOLDING_REGISTER_CONFIG_360 = 1412,
            SHODOW_HOLDING_REGISTER_CONFIG_361 = 1413,
            SHODOW_HOLDING_REGISTER_CONFIG_362 = 1414,
            SHODOW_HOLDING_REGISTER_CONFIG_363 = 1415,
            SHODOW_HOLDING_REGISTER_CONFIG_364 = 1416,
            SHODOW_HOLDING_REGISTER_CONFIG_365 = 1417,
            SHODOW_HOLDING_REGISTER_CONFIG_366 = 1418,
            SHODOW_HOLDING_REGISTER_CONFIG_367 = 1419,
            SHODOW_HOLDING_REGISTER_CONFIG_368 = 1420,
            SHODOW_HOLDING_REGISTER_CONFIG_369 = 1421,
            SHODOW_HOLDING_REGISTER_CONFIG_370 = 1422,
            SHODOW_HOLDING_REGISTER_CONFIG_371 = 1423,
            SHODOW_HOLDING_REGISTER_CONFIG_372 = 1424,
            SHODOW_HOLDING_REGISTER_CONFIG_373 = 1425,
            SHODOW_HOLDING_REGISTER_CONFIG_374 = 1426,
            SHODOW_HOLDING_REGISTER_CONFIG_375 = 1427,
            SHODOW_HOLDING_REGISTER_CONFIG_376 = 1428,
            SHODOW_HOLDING_REGISTER_CONFIG_377 = 1429,
            SHODOW_HOLDING_REGISTER_CONFIG_378 = 1430,
            SHODOW_HOLDING_REGISTER_CONFIG_379 = 1431,
            SHODOW_HOLDING_REGISTER_CONFIG_380 = 1432,
            SHODOW_HOLDING_REGISTER_CONFIG_381 = 1433,
            SHODOW_HOLDING_REGISTER_CONFIG_382 = 1434,
            SHODOW_HOLDING_REGISTER_CONFIG_383 = 1435,
            SHODOW_HOLDING_REGISTER_CONFIG_384 = 1436,
            SHODOW_HOLDING_REGISTER_CONFIG_385 = 1437,
            SHODOW_HOLDING_REGISTER_CONFIG_386 = 1438,
            SHODOW_HOLDING_REGISTER_CONFIG_387 = 1439,
            SHODOW_HOLDING_REGISTER_CONFIG_388 = 1440,
            SHODOW_HOLDING_REGISTER_CONFIG_389 = 1441,
            SHODOW_HOLDING_REGISTER_CONFIG_390 = 1442,
            SHODOW_HOLDING_REGISTER_CONFIG_391 = 1443,
            SHODOW_HOLDING_REGISTER_CONFIG_392 = 1444,
            SHODOW_HOLDING_REGISTER_CONFIG_393 = 1445,
            SHODOW_HOLDING_REGISTER_CONFIG_394 = 1446,
            SHODOW_HOLDING_REGISTER_CONFIG_395 = 1447,
            SHODOW_HOLDING_REGISTER_CONFIG_396 = 1448,
            SHODOW_HOLDING_REGISTER_CONFIG_397 = 1449,
            SHODOW_HOLDING_REGISTER_CONFIG_398 = 1450,
            SHODOW_HOLDING_REGISTER_CONFIG_399 = 1451,
            SHODOW_HOLDING_REGISTER_CONFIG_400 = 1452,
            SHODOW_HOLDING_REGISTER_CONFIG_401 = 1453,
            SHODOW_HOLDING_REGISTER_CONFIG_402 = 1454,
            SHODOW_HOLDING_REGISTER_CONFIG_403 = 1455,
            SHODOW_HOLDING_REGISTER_CONFIG_404 = 1456,
            SHODOW_HOLDING_REGISTER_CONFIG_405 = 1457,
            SHODOW_HOLDING_REGISTER_CONFIG_406 = 1458,
            SHODOW_HOLDING_REGISTER_CONFIG_407 = 1459,
            SHODOW_HOLDING_REGISTER_CONFIG_408 = 1460,
            SHODOW_HOLDING_REGISTER_CONFIG_409 = 1461,
            SHODOW_HOLDING_REGISTER_CONFIG_410 = 1462,
            SHODOW_HOLDING_REGISTER_CONFIG_411 = 1463,
            SHODOW_HOLDING_REGISTER_CONFIG_412 = 1464,
            SHODOW_HOLDING_REGISTER_CONFIG_413 = 1465,
            SHODOW_HOLDING_REGISTER_CONFIG_414 = 1466,
            SHODOW_HOLDING_REGISTER_CONFIG_415 = 1467,
            SHODOW_HOLDING_REGISTER_CONFIG_416 = 1468,
            SHODOW_HOLDING_REGISTER_CONFIG_417 = 1469,
            SHODOW_HOLDING_REGISTER_CONFIG_418 = 1470,
            SHODOW_HOLDING_REGISTER_CONFIG_419 = 1471,
            SHODOW_HOLDING_REGISTER_CONFIG_420 = 1472,
            SHODOW_HOLDING_REGISTER_CONFIG_421 = 1473,
            SHODOW_HOLDING_REGISTER_CONFIG_422 = 1474,
            SHODOW_HOLDING_REGISTER_CONFIG_423 = 1475,
            SHODOW_HOLDING_REGISTER_CONFIG_424 = 1476,
            SHODOW_HOLDING_REGISTER_CONFIG_425 = 1477,
            SHODOW_HOLDING_REGISTER_CONFIG_426 = 1478,
            SHODOW_HOLDING_REGISTER_CONFIG_427 = 1479,
            SHODOW_HOLDING_REGISTER_CONFIG_428 = 1480,
            SHODOW_HOLDING_REGISTER_CONFIG_429 = 1481,
            SHODOW_HOLDING_REGISTER_CONFIG_430 = 1482,
            SHODOW_HOLDING_REGISTER_CONFIG_431 = 1483,
            SHODOW_HOLDING_REGISTER_CONFIG_432 = 1484,
            SHODOW_HOLDING_REGISTER_CONFIG_433 = 1485,
            SHODOW_HOLDING_REGISTER_CONFIG_434 = 1486,
            SHODOW_HOLDING_REGISTER_CONFIG_435 = 1487,
            SHODOW_HOLDING_REGISTER_CONFIG_436 = 1488,
            SHODOW_HOLDING_REGISTER_CONFIG_437 = 1489,
            SHODOW_HOLDING_REGISTER_CONFIG_438 = 1490,
            SHODOW_HOLDING_REGISTER_CONFIG_439 = 1491,
            SHODOW_HOLDING_REGISTER_CONFIG_440 = 1492,
            SHODOW_HOLDING_REGISTER_CONFIG_441 = 1493,
            SHODOW_HOLDING_REGISTER_CONFIG_442 = 1494,
            SHODOW_HOLDING_REGISTER_CONFIG_443 = 1495,
            SHODOW_HOLDING_REGISTER_CONFIG_444 = 1496,
            SHODOW_HOLDING_REGISTER_CONFIG_445 = 1497,
            SHODOW_HOLDING_REGISTER_CONFIG_446 = 1498,
            SHODOW_HOLDING_REGISTER_CONFIG_447 = 1499,
            SHODOW_HOLDING_REGISTER_CONFIG_448 = 1500,
            SHODOW_HOLDING_REGISTER_CONFIG_449 = 1501,
            SHODOW_HOLDING_REGISTER_CONFIG_450 = 1502,
            SHODOW_HOLDING_REGISTER_CONFIG_451 = 1503,
            SHODOW_HOLDING_REGISTER_CONFIG_452 = 1504,
            SHODOW_HOLDING_REGISTER_CONFIG_453 = 1505,
            SHODOW_HOLDING_REGISTER_CONFIG_454 = 1506,
            SHODOW_HOLDING_REGISTER_CONFIG_455 = 1507,
            SHODOW_HOLDING_REGISTER_CONFIG_456 = 1508,
            SHODOW_HOLDING_REGISTER_CONFIG_457 = 1509,
            SHODOW_HOLDING_REGISTER_CONFIG_458 = 1510,
            SHODOW_HOLDING_REGISTER_CONFIG_459 = 1511,
            SHODOW_HOLDING_REGISTER_CONFIG_460 = 1512,
            SHODOW_HOLDING_REGISTER_CONFIG_461 = 1513,
            SHODOW_HOLDING_REGISTER_CONFIG_462 = 1514,
            SHODOW_HOLDING_REGISTER_CONFIG_463 = 1515,
            SHODOW_HOLDING_REGISTER_CONFIG_464 = 1516,
            SHODOW_HOLDING_REGISTER_CONFIG_465 = 1517,
            SHODOW_HOLDING_REGISTER_CONFIG_466 = 1518,
            SHODOW_HOLDING_REGISTER_CONFIG_467 = 1519,
            SHODOW_HOLDING_REGISTER_CONFIG_468 = 1520,
            SHODOW_HOLDING_REGISTER_CONFIG_469 = 1521,
            SHODOW_HOLDING_REGISTER_CONFIG_470 = 1522,
            SHODOW_HOLDING_REGISTER_CONFIG_471 = 1523,
            SHODOW_HOLDING_REGISTER_CONFIG_472 = 1524,
            SHODOW_HOLDING_REGISTER_CONFIG_473 = 1525,
            SHODOW_HOLDING_REGISTER_CONFIG_474 = 1526,
            SHODOW_HOLDING_REGISTER_CONFIG_475 = 1527,
            SHODOW_HOLDING_REGISTER_CONFIG_476 = 1528,
            SHODOW_HOLDING_REGISTER_CONFIG_477 = 1529,
            SHODOW_HOLDING_REGISTER_CONFIG_478 = 1530,
            SHODOW_HOLDING_REGISTER_CONFIG_479 = 1531,
            SHODOW_HOLDING_REGISTER_CONFIG_480 = 1532,
            SHODOW_HOLDING_REGISTER_CONFIG_481 = 1533,
            SHODOW_HOLDING_REGISTER_CONFIG_482 = 1534,
            SHODOW_HOLDING_REGISTER_CONFIG_483 = 1535,
            SHODOW_HOLDING_REGISTER_CONFIG_484 = 1536,
            SHODOW_HOLDING_REGISTER_CONFIG_485 = 1537,
            SHODOW_HOLDING_REGISTER_CONFIG_486 = 1538,
            SHODOW_HOLDING_REGISTER_CONFIG_487 = 1539,
            SHODOW_HOLDING_REGISTER_CONFIG_488 = 1540,
            SHODOW_HOLDING_REGISTER_CONFIG_489 = 1541,
            SHODOW_HOLDING_REGISTER_CONFIG_490 = 1542,
            SHODOW_HOLDING_REGISTER_CONFIG_491 = 1543,
            SHODOW_HOLDING_REGISTER_CONFIG_492 = 1544,
            SHODOW_HOLDING_REGISTER_CONFIG_493 = 1545,
            SHODOW_HOLDING_REGISTER_CONFIG_494 = 1546,
            SHODOW_HOLDING_REGISTER_CONFIG_495 = 1547,
            SHODOW_HOLDING_REGISTER_CONFIG_496 = 1548,
            SHODOW_HOLDING_REGISTER_CONFIG_497 = 1549,
            SHODOW_HOLDING_REGISTER_CONFIG_498 = 1550,
            SHODOW_HOLDING_REGISTER_CONFIG_499 = 1551,
            SHODOW_HOLDING_REGISTER_CONFIG_500 = 1552,
            SHODOW_HOLDING_REGISTER_CONFIG_501 = 1553,
            SHODOW_HOLDING_REGISTER_CONFIG_502 = 1554,
            SHODOW_HOLDING_REGISTER_CONFIG_503 = 1555,
            SHODOW_HOLDING_REGISTER_CONFIG_504 = 1556,
            SHODOW_HOLDING_REGISTER_CONFIG_505 = 1557,
            SHODOW_HOLDING_REGISTER_CONFIG_506 = 1558,
            SHODOW_HOLDING_REGISTER_CONFIG_507 = 1559,
            SHODOW_HOLDING_REGISTER_CONFIG_508 = 1560,
            SHODOW_HOLDING_REGISTER_CONFIG_509 = 1561,
            SHODOW_HOLDING_REGISTER_CONFIG_510 = 1562,
            SHODOW_HOLDING_REGISTER_CONFIG_511 = 1563,
            SHODOW_HOLDING_REGISTER_CONFIG_512 = 1564,
            SHODOW_HOLDING_REGISTER_CONFIG_513 = 1565,
            SHODOW_HOLDING_REGISTER_CONFIG_514 = 1566,
            SHODOW_HOLDING_REGISTER_CONFIG_515 = 1567,
            SHODOW_HOLDING_REGISTER_CONFIG_516 = 1568,
            SHODOW_HOLDING_REGISTER_CONFIG_517 = 1569,
            SHODOW_HOLDING_REGISTER_CONFIG_518 = 1570,
            SHODOW_HOLDING_REGISTER_CONFIG_519 = 1571,
            SHODOW_HOLDING_REGISTER_CONFIG_520 = 1572,
            SHODOW_HOLDING_REGISTER_CONFIG_521 = 1573,
            SHODOW_HOLDING_REGISTER_CONFIG_522 = 1574,
            SHODOW_HOLDING_REGISTER_CONFIG_523 = 1575,
            SHODOW_HOLDING_REGISTER_CONFIG_524 = 1576,
            SHODOW_HOLDING_REGISTER_CONFIG_525 = 1577,
            SHODOW_HOLDING_REGISTER_CONFIG_526 = 1578,
            SHODOW_HOLDING_REGISTER_CONFIG_527 = 1579,
            SHODOW_HOLDING_REGISTER_CONFIG_528 = 1580,
            SHODOW_HOLDING_REGISTER_CONFIG_529 = 1581,
            SHODOW_HOLDING_REGISTER_CONFIG_530 = 1582,
            SHODOW_HOLDING_REGISTER_CONFIG_531 = 1583,
            SHODOW_HOLDING_REGISTER_CONFIG_532 = 1584,
            SHODOW_HOLDING_REGISTER_CONFIG_533 = 1585,
            SHODOW_HOLDING_REGISTER_CONFIG_534 = 1586,
            SHODOW_HOLDING_REGISTER_CONFIG_535 = 1587,
            SHODOW_HOLDING_REGISTER_CONFIG_536 = 1588,
            SHODOW_HOLDING_REGISTER_CONFIG_537 = 1589,
            SHODOW_HOLDING_REGISTER_CONFIG_538 = 1590,
            SHODOW_HOLDING_REGISTER_CONFIG_539 = 1591,
            SHODOW_HOLDING_REGISTER_CONFIG_540 = 1592,
            SHODOW_HOLDING_REGISTER_CONFIG_541 = 1593,
            SHODOW_HOLDING_REGISTER_CONFIG_542 = 1594,
            SHODOW_HOLDING_REGISTER_CONFIG_543 = 1595,
            SHODOW_HOLDING_REGISTER_CONFIG_544 = 1596,
            SHODOW_HOLDING_REGISTER_CONFIG_545 = 1597,
            SHODOW_HOLDING_REGISTER_CONFIG_546 = 1598,
            SHODOW_HOLDING_REGISTER_CONFIG_547 = 1599,
            SHODOW_HOLDING_REGISTER_CONFIG_548 = 1600,
            SHODOW_HOLDING_REGISTER_CONFIG_549 = 1601,
            SHODOW_HOLDING_REGISTER_CONFIG_550 = 1602,
            SHODOW_HOLDING_REGISTER_CONFIG_551 = 1603,
            SHODOW_HOLDING_REGISTER_CONFIG_552 = 1604,
            SHODOW_HOLDING_REGISTER_CONFIG_553 = 1605,
            SHODOW_HOLDING_REGISTER_CONFIG_554 = 1606,
            SHODOW_HOLDING_REGISTER_CONFIG_555 = 1607,
            SHODOW_HOLDING_REGISTER_CONFIG_556 = 1608,
            SHODOW_HOLDING_REGISTER_CONFIG_557 = 1609,
            SHODOW_HOLDING_REGISTER_CONFIG_558 = 1610,
            SHODOW_HOLDING_REGISTER_CONFIG_559 = 1611,
            SHODOW_HOLDING_REGISTER_CONFIG_560 = 1612,
            SHODOW_HOLDING_REGISTER_CONFIG_561 = 1613,
            SHODOW_HOLDING_REGISTER_CONFIG_562 = 1614,
            SHODOW_HOLDING_REGISTER_CONFIG_563 = 1615,
            SHODOW_HOLDING_REGISTER_CONFIG_564 = 1616,
            SHODOW_HOLDING_REGISTER_CONFIG_565 = 1617,
            SHODOW_HOLDING_REGISTER_CONFIG_566 = 1618,
            SHODOW_HOLDING_REGISTER_CONFIG_567 = 1619,
            SHODOW_HOLDING_REGISTER_CONFIG_568 = 1620,
            SHODOW_HOLDING_REGISTER_CONFIG_569 = 1621,
            SHODOW_HOLDING_REGISTER_CONFIG_570 = 1622,
            SHODOW_HOLDING_REGISTER_CONFIG_571 = 1623,
            SHODOW_HOLDING_REGISTER_CONFIG_572 = 1624,
            SHODOW_HOLDING_REGISTER_CONFIG_573 = 1625,
            SHODOW_HOLDING_REGISTER_CONFIG_574 = 1626,
            SHODOW_HOLDING_REGISTER_CONFIG_575 = 1627,
            SHODOW_HOLDING_REGISTER_CONFIG_576 = 1628,
            SHODOW_HOLDING_REGISTER_CONFIG_577 = 1629,
            SHODOW_HOLDING_REGISTER_CONFIG_578 = 1630,
            SHODOW_HOLDING_REGISTER_CONFIG_579 = 1631,
            SHODOW_HOLDING_REGISTER_CONFIG_580 = 1632,
            SHODOW_HOLDING_REGISTER_CONFIG_581 = 1633,
            SHODOW_HOLDING_REGISTER_CONFIG_582 = 1634,
            SHODOW_HOLDING_REGISTER_CONFIG_583 = 1635,
            SHODOW_HOLDING_REGISTER_CONFIG_584 = 1636,
            SHODOW_HOLDING_REGISTER_CONFIG_585 = 1637,
            SHODOW_HOLDING_REGISTER_CONFIG_586 = 1638,
            SHODOW_HOLDING_REGISTER_CONFIG_587 = 1639,
            SHODOW_HOLDING_REGISTER_CONFIG_588 = 1640,
            SHODOW_HOLDING_REGISTER_CONFIG_589 = 1641,
            SHODOW_HOLDING_REGISTER_CONFIG_590 = 1642,
            SHODOW_HOLDING_REGISTER_CONFIG_591 = 1643,
            SHODOW_HOLDING_REGISTER_CONFIG_592 = 1644,
            SHODOW_HOLDING_REGISTER_CONFIG_593 = 1645,
            SHODOW_HOLDING_REGISTER_CONFIG_594 = 1646,
            SHODOW_HOLDING_REGISTER_CONFIG_595 = 1647,
            SHODOW_HOLDING_REGISTER_CONFIG_596 = 1648,
            SHODOW_HOLDING_REGISTER_CONFIG_597 = 1649,
            SHODOW_HOLDING_REGISTER_CONFIG_598 = 1650,
            SHODOW_HOLDING_REGISTER_CONFIG_599 = 1651,
            SHODOW_HOLDING_REGISTER_CONFIG_600 = 1652,
            SHODOW_HOLDING_REGISTER_CONFIG_601 = 1653,
            SHODOW_HOLDING_REGISTER_CONFIG_602 = 1654,
            SHODOW_HOLDING_REGISTER_CONFIG_603 = 1655,
            SHODOW_HOLDING_REGISTER_CONFIG_604 = 1656,
            SHODOW_HOLDING_REGISTER_CONFIG_605 = 1657,
            SHODOW_HOLDING_REGISTER_CONFIG_606 = 1658,
            SHODOW_HOLDING_REGISTER_CONFIG_607 = 1659,
            SHODOW_HOLDING_REGISTER_CONFIG_608 = 1660,
            SHODOW_HOLDING_REGISTER_CONFIG_609 = 1661,
            SHODOW_HOLDING_REGISTER_CONFIG_610 = 1662,
            SHODOW_HOLDING_REGISTER_CONFIG_611 = 1663,
            SHODOW_HOLDING_REGISTER_CONFIG_612 = 1664,
            SHODOW_HOLDING_REGISTER_CONFIG_613 = 1665,
            SHODOW_HOLDING_REGISTER_CONFIG_614 = 1666,
            SHODOW_HOLDING_REGISTER_CONFIG_615 = 1667,
            SHODOW_HOLDING_REGISTER_CONFIG_616 = 1668,
            SHODOW_HOLDING_REGISTER_CONFIG_617 = 1669,
            SHODOW_HOLDING_REGISTER_CONFIG_618 = 1670,
            SHODOW_HOLDING_REGISTER_CONFIG_619 = 1671,
            SHODOW_HOLDING_REGISTER_CONFIG_620 = 1672,
            SHODOW_HOLDING_REGISTER_CONFIG_621 = 1673,
            SHODOW_HOLDING_REGISTER_CONFIG_622 = 1674,
            SHODOW_HOLDING_REGISTER_CONFIG_623 = 1675,
            SHODOW_HOLDING_REGISTER_CONFIG_624 = 1676,
            SHODOW_HOLDING_REGISTER_CONFIG_625 = 1677,
            SHODOW_HOLDING_REGISTER_CONFIG_626 = 1678,
            SHODOW_HOLDING_REGISTER_CONFIG_627 = 1679,
            SHODOW_HOLDING_REGISTER_CONFIG_628 = 1680,
            SHODOW_HOLDING_REGISTER_CONFIG_629 = 1681,
            SHODOW_HOLDING_REGISTER_CONFIG_630 = 1682,
            SHODOW_HOLDING_REGISTER_CONFIG_631 = 1683,
            SHODOW_HOLDING_REGISTER_CONFIG_632 = 1684,
            SHODOW_HOLDING_REGISTER_CONFIG_633 = 1685,
            SHODOW_HOLDING_REGISTER_CONFIG_634 = 1686,
            SHODOW_HOLDING_REGISTER_CONFIG_635 = 1687,
            SHODOW_HOLDING_REGISTER_CONFIG_636 = 1688,
            SHODOW_HOLDING_REGISTER_CONFIG_637 = 1689,
            SHODOW_HOLDING_REGISTER_CONFIG_638 = 1690,
            SHODOW_HOLDING_REGISTER_CONFIG_639 = 1691,
            SHODOW_HOLDING_REGISTER_CONFIG_640 = 1692,
            SHODOW_HOLDING_REGISTER_CONFIG_641 = 1693,
            SHODOW_HOLDING_REGISTER_CONFIG_642 = 1694,
            SHODOW_HOLDING_REGISTER_CONFIG_643 = 1695,
            SHODOW_HOLDING_REGISTER_CONFIG_644 = 1696,
            SHODOW_HOLDING_REGISTER_CONFIG_645 = 1697,
            SHODOW_HOLDING_REGISTER_CONFIG_646 = 1698,
            SHODOW_HOLDING_REGISTER_CONFIG_647 = 1699,
            SHODOW_HOLDING_REGISTER_CONFIG_648 = 1700,
            SHODOW_HOLDING_REGISTER_CONFIG_649 = 1701,
            SHODOW_HOLDING_REGISTER_CONFIG_650 = 1702,
            SHODOW_HOLDING_REGISTER_CONFIG_651 = 1703,
            SHODOW_HOLDING_REGISTER_CONFIG_652 = 1704,
            SHODOW_HOLDING_REGISTER_CONFIG_653 = 1705,
            SHODOW_HOLDING_REGISTER_CONFIG_654 = 1706,
            SHODOW_HOLDING_REGISTER_CONFIG_655 = 1707,
            SHODOW_HOLDING_REGISTER_CONFIG_656 = 1708,
            SHODOW_HOLDING_REGISTER_CONFIG_657 = 1709,
            SHODOW_HOLDING_REGISTER_CONFIG_658 = 1710,
            SHODOW_HOLDING_REGISTER_CONFIG_659 = 1711,
            SHODOW_HOLDING_REGISTER_CONFIG_660 = 1712,
            SHODOW_HOLDING_REGISTER_CONFIG_661 = 1713,
            SHODOW_HOLDING_REGISTER_CONFIG_662 = 1714,
            SHODOW_HOLDING_REGISTER_CONFIG_663 = 1715,
            SHODOW_HOLDING_REGISTER_CONFIG_664 = 1716,
            SHODOW_HOLDING_REGISTER_CONFIG_665 = 1717,
            SHODOW_HOLDING_REGISTER_CONFIG_666 = 1718,
            SHODOW_HOLDING_REGISTER_CONFIG_667 = 1719,
            SHODOW_HOLDING_REGISTER_CONFIG_668 = 1720,
            SHODOW_HOLDING_REGISTER_CONFIG_669 = 1721,
            SHODOW_HOLDING_REGISTER_CONFIG_670 = 1722,
            SHODOW_HOLDING_REGISTER_CONFIG_671 = 1723,
            SHODOW_HOLDING_REGISTER_CONFIG_672 = 1724,
            SHODOW_HOLDING_REGISTER_CONFIG_673 = 1725,
            SHODOW_HOLDING_REGISTER_CONFIG_674 = 1726,
            SHODOW_HOLDING_REGISTER_CONFIG_675 = 1727,
            SHODOW_HOLDING_REGISTER_CONFIG_676 = 1728,
            SHODOW_HOLDING_REGISTER_CONFIG_677 = 1729,
            SHODOW_HOLDING_REGISTER_CONFIG_678 = 1730,
            SHODOW_HOLDING_REGISTER_CONFIG_679 = 1731,
            SHODOW_HOLDING_REGISTER_CONFIG_680 = 1732,
            SHODOW_HOLDING_REGISTER_CONFIG_681 = 1733,
            SHODOW_HOLDING_REGISTER_CONFIG_682 = 1734,
            SHODOW_HOLDING_REGISTER_CONFIG_683 = 1735,
            SHODOW_HOLDING_REGISTER_CONFIG_684 = 1736,
            SHODOW_HOLDING_REGISTER_CONFIG_685 = 1737,
            SHODOW_HOLDING_REGISTER_CONFIG_686 = 1738,
            SHODOW_HOLDING_REGISTER_CONFIG_687 = 1739,
            SHODOW_HOLDING_REGISTER_CONFIG_688 = 1740,
            SHODOW_HOLDING_REGISTER_CONFIG_689 = 1741,
            SHODOW_HOLDING_REGISTER_CONFIG_690 = 1742,
            SHODOW_HOLDING_REGISTER_CONFIG_691 = 1743,
            SHODOW_HOLDING_REGISTER_CONFIG_692 = 1744,
            SHODOW_HOLDING_REGISTER_CONFIG_693 = 1745,
            SHODOW_HOLDING_REGISTER_CONFIG_694 = 1746,
            SHODOW_HOLDING_REGISTER_CONFIG_695 = 1747,
            SHODOW_HOLDING_REGISTER_CONFIG_696 = 1748,
            SHODOW_HOLDING_REGISTER_CONFIG_697 = 1749,
            SHODOW_HOLDING_REGISTER_CONFIG_698 = 1750,
            SHODOW_HOLDING_REGISTER_CONFIG_699 = 1751,
            SHODOW_HOLDING_REGISTER_CONFIG_700 = 1752,
            SHODOW_HOLDING_REGISTER_CONFIG_701 = 1753,
            SHODOW_HOLDING_REGISTER_CONFIG_702 = 1754,
            SHODOW_HOLDING_REGISTER_CONFIG_703 = 1755,
            SHODOW_HOLDING_REGISTER_CONFIG_704 = 1756,
            SHODOW_HOLDING_REGISTER_CONFIG_705 = 1757,
            SHODOW_HOLDING_REGISTER_CONFIG_706 = 1758,
            SHODOW_HOLDING_REGISTER_CONFIG_707 = 1759,
            SHODOW_HOLDING_REGISTER_CONFIG_708 = 1760,
            SHODOW_HOLDING_REGISTER_CONFIG_709 = 1761,
            SHODOW_HOLDING_REGISTER_CONFIG_710 = 1762,
            SHODOW_HOLDING_REGISTER_CONFIG_711 = 1763,
            SHODOW_HOLDING_REGISTER_CONFIG_712 = 1764,
            SHODOW_HOLDING_REGISTER_CONFIG_713 = 1765,
            SHODOW_HOLDING_REGISTER_CONFIG_714 = 1766,
            SHODOW_HOLDING_REGISTER_CONFIG_715 = 1767,
            SHODOW_HOLDING_REGISTER_CONFIG_716 = 1768,
            SHODOW_HOLDING_REGISTER_CONFIG_717 = 1769,
            SHODOW_HOLDING_REGISTER_CONFIG_718 = 1770,
            SHODOW_HOLDING_REGISTER_CONFIG_719 = 1771,
            SHODOW_HOLDING_REGISTER_CONFIG_720 = 1772,
            SHODOW_HOLDING_REGISTER_CONFIG_721 = 1773,
            SHODOW_HOLDING_REGISTER_CONFIG_722 = 1774,
            SHODOW_HOLDING_REGISTER_CONFIG_723 = 1775,
            SHODOW_HOLDING_REGISTER_CONFIG_724 = 1776,
            SHODOW_HOLDING_REGISTER_CONFIG_725 = 1777,
            SHODOW_HOLDING_REGISTER_CONFIG_726 = 1778,
            SHODOW_HOLDING_REGISTER_CONFIG_727 = 1779,
            SHODOW_HOLDING_REGISTER_CONFIG_728 = 1780,
            SHODOW_HOLDING_REGISTER_CONFIG_729 = 1781,
            SHODOW_HOLDING_REGISTER_CONFIG_730 = 1782,
            SHODOW_HOLDING_REGISTER_CONFIG_731 = 1783,
            SHODOW_HOLDING_REGISTER_CONFIG_732 = 1784,
            SHODOW_HOLDING_REGISTER_CONFIG_733 = 1785,
            SHODOW_HOLDING_REGISTER_CONFIG_734 = 1786,
            SHODOW_HOLDING_REGISTER_CONFIG_735 = 1787,
            SHODOW_HOLDING_REGISTER_CONFIG_736 = 1788,
            SHODOW_HOLDING_REGISTER_CONFIG_737 = 1789,
            SHODOW_HOLDING_REGISTER_CONFIG_738 = 1790,
            SHODOW_HOLDING_REGISTER_CONFIG_739 = 1791,
            SHODOW_HOLDING_REGISTER_CONFIG_740 = 1792,
            SHODOW_HOLDING_REGISTER_CONFIG_741 = 1793,
            SHODOW_HOLDING_REGISTER_CONFIG_742 = 1794,
            SHODOW_HOLDING_REGISTER_CONFIG_743 = 1795,
            SHODOW_HOLDING_REGISTER_CONFIG_744 = 1796,
            SHODOW_HOLDING_REGISTER_CONFIG_745 = 1797,
            SHODOW_HOLDING_REGISTER_CONFIG_746 = 1798,
            SHODOW_HOLDING_REGISTER_CONFIG_747 = 1799,
            SHODOW_HOLDING_REGISTER_CONFIG_748 = 1800,
            SHODOW_HOLDING_REGISTER_CONFIG_749 = 1801,
            SHODOW_HOLDING_REGISTER_CONFIG_750 = 1802,
            SHODOW_HOLDING_REGISTER_CONFIG_751 = 1803,
            SHODOW_HOLDING_REGISTER_CONFIG_752 = 1804,
            SHODOW_HOLDING_REGISTER_CONFIG_753 = 1805,
            SHODOW_HOLDING_REGISTER_CONFIG_754 = 1806,
            SHODOW_HOLDING_REGISTER_CONFIG_755 = 1807,
            SHODOW_HOLDING_REGISTER_CONFIG_756 = 1808,
            SHODOW_HOLDING_REGISTER_CONFIG_757 = 1809,
            SHODOW_HOLDING_REGISTER_CONFIG_758 = 1810,
            SHODOW_HOLDING_REGISTER_CONFIG_759 = 1811,
            SHODOW_HOLDING_REGISTER_CONFIG_760 = 1812,
            SHODOW_HOLDING_REGISTER_CONFIG_761 = 1813,
            SHODOW_HOLDING_REGISTER_CONFIG_762 = 1814,
            SHODOW_HOLDING_REGISTER_CONFIG_763 = 1815,
            SHODOW_HOLDING_REGISTER_CONFIG_764 = 1816,
            SHODOW_HOLDING_REGISTER_CONFIG_765 = 1817,
            SHODOW_HOLDING_REGISTER_CONFIG_766 = 1818,
            SHODOW_HOLDING_REGISTER_CONFIG_767 = 1819,
            SHODOW_HOLDING_REGISTER_CONFIG_768 = 1820,
            SHODOW_HOLDING_REGISTER_CONFIG_769 = 1821,
            SHODOW_HOLDING_REGISTER_CONFIG_770 = 1822,
            SHODOW_HOLDING_REGISTER_CONFIG_771 = 1823,
            SHODOW_HOLDING_REGISTER_CONFIG_772 = 1824,
            SHODOW_HOLDING_REGISTER_CONFIG_773 = 1825,
            SHODOW_HOLDING_REGISTER_CONFIG_774 = 1826,
            SHODOW_HOLDING_REGISTER_CONFIG_775 = 1827,
            SHODOW_HOLDING_REGISTER_CONFIG_776 = 1828,
            SHODOW_HOLDING_REGISTER_CONFIG_777 = 1829,
            SHODOW_HOLDING_REGISTER_CONFIG_778 = 1830,
            SHODOW_HOLDING_REGISTER_CONFIG_779 = 1831,
            SHODOW_HOLDING_REGISTER_CONFIG_780 = 1832,
            SHODOW_HOLDING_REGISTER_CONFIG_781 = 1833,
            SHODOW_HOLDING_REGISTER_CONFIG_782 = 1834,
            SHODOW_HOLDING_REGISTER_CONFIG_783 = 1835,
            SHODOW_HOLDING_REGISTER_CONFIG_784 = 1836,
            SHODOW_HOLDING_REGISTER_CONFIG_785 = 1837,
            SHODOW_HOLDING_REGISTER_CONFIG_786 = 1838,
            SHODOW_HOLDING_REGISTER_CONFIG_787 = 1839,
            SHODOW_HOLDING_REGISTER_CONFIG_788 = 1840,
            SHODOW_HOLDING_REGISTER_CONFIG_789 = 1841,
            SHODOW_HOLDING_REGISTER_CONFIG_790 = 1842,
            SHODOW_HOLDING_REGISTER_CONFIG_791 = 1843,
            SHODOW_HOLDING_REGISTER_CONFIG_792 = 1844,
            SHODOW_HOLDING_REGISTER_CONFIG_793 = 1845,
            SHODOW_HOLDING_REGISTER_CONFIG_794 = 1846,
            SHODOW_HOLDING_REGISTER_CONFIG_795 = 1847,
            SHODOW_HOLDING_REGISTER_CONFIG_796 = 1848,
            SHODOW_HOLDING_REGISTER_CONFIG_797 = 1849,
            SHODOW_HOLDING_REGISTER_CONFIG_798 = 1850,
            SHODOW_HOLDING_REGISTER_CONFIG_799 = 1851,
            SHODOW_HOLDING_REGISTER_CONFIG_800 = 1852,
            SHODOW_HOLDING_REGISTER_CONFIG_801 = 1853,
            SHODOW_HOLDING_REGISTER_CONFIG_802 = 1854,
            SHODOW_HOLDING_REGISTER_CONFIG_803 = 1855,
            SHODOW_HOLDING_REGISTER_CONFIG_804 = 1856,
            SHODOW_HOLDING_REGISTER_CONFIG_805 = 1857,
            SHODOW_HOLDING_REGISTER_CONFIG_806 = 1858,
            SHODOW_HOLDING_REGISTER_CONFIG_807 = 1859,
            SHODOW_HOLDING_REGISTER_CONFIG_808 = 1860,
            SHODOW_HOLDING_REGISTER_CONFIG_809 = 1861,
            SHODOW_HOLDING_REGISTER_CONFIG_810 = 1862,
            SHODOW_HOLDING_REGISTER_CONFIG_811 = 1863,
            SHODOW_HOLDING_REGISTER_CONFIG_812 = 1864,
            SHODOW_HOLDING_REGISTER_CONFIG_813 = 1865,
            SHODOW_HOLDING_REGISTER_CONFIG_814 = 1866,
            SHODOW_HOLDING_REGISTER_CONFIG_815 = 1867,
            SHODOW_HOLDING_REGISTER_CONFIG_816 = 1868,
            SHODOW_HOLDING_REGISTER_CONFIG_817 = 1869,
            SHODOW_HOLDING_REGISTER_CONFIG_818 = 1870,
            SHODOW_HOLDING_REGISTER_CONFIG_819 = 1871,
            SHODOW_HOLDING_REGISTER_CONFIG_820 = 1872,
            SHODOW_HOLDING_REGISTER_CONFIG_821 = 1873,
            SHODOW_HOLDING_REGISTER_CONFIG_822 = 1874,
            SHODOW_HOLDING_REGISTER_CONFIG_823 = 1875,
            SHODOW_HOLDING_REGISTER_CONFIG_824 = 1876,
            SHODOW_HOLDING_REGISTER_CONFIG_825 = 1877,
            SHODOW_HOLDING_REGISTER_CONFIG_826 = 1878,
            SHODOW_HOLDING_REGISTER_CONFIG_827 = 1879,
            SHODOW_HOLDING_REGISTER_CONFIG_828 = 1880,
            SHODOW_HOLDING_REGISTER_CONFIG_829 = 1881,
            SHODOW_HOLDING_REGISTER_CONFIG_830 = 1882,
            SHODOW_HOLDING_REGISTER_CONFIG_831 = 1883,
            SHODOW_HOLDING_REGISTER_CONFIG_832 = 1884,
            SHODOW_HOLDING_REGISTER_CONFIG_833 = 1885,
            SHODOW_HOLDING_REGISTER_CONFIG_834 = 1886,
            SHODOW_HOLDING_REGISTER_CONFIG_835 = 1887,
            SHODOW_HOLDING_REGISTER_CONFIG_836 = 1888,
            SHODOW_HOLDING_REGISTER_CONFIG_837 = 1889,
            SHODOW_HOLDING_REGISTER_CONFIG_838 = 1890,
            SHODOW_HOLDING_REGISTER_CONFIG_839 = 1891,
            SHODOW_HOLDING_REGISTER_CONFIG_840 = 1892,
            SHODOW_HOLDING_REGISTER_CONFIG_841 = 1893,
            SHODOW_HOLDING_REGISTER_CONFIG_842 = 1894,
            SHODOW_HOLDING_REGISTER_CONFIG_843 = 1895,
            SHODOW_HOLDING_REGISTER_CONFIG_844 = 1896,
            SHODOW_HOLDING_REGISTER_CONFIG_845 = 1897,
            SHODOW_HOLDING_REGISTER_CONFIG_846 = 1898,
            SHODOW_HOLDING_REGISTER_CONFIG_847 = 1899,
            SHODOW_HOLDING_REGISTER_CONFIG_848 = 1900,
            SHODOW_HOLDING_REGISTER_CONFIG_849 = 1901,
            SHODOW_HOLDING_REGISTER_CONFIG_850 = 1902,
            SHODOW_HOLDING_REGISTER_CONFIG_851 = 1903,
            SHODOW_HOLDING_REGISTER_CONFIG_852 = 1904,
            SHODOW_HOLDING_REGISTER_CONFIG_853 = 1905,
            SHODOW_HOLDING_REGISTER_CONFIG_854 = 1906,
            SHODOW_HOLDING_REGISTER_CONFIG_855 = 1907,
            SHODOW_HOLDING_REGISTER_CONFIG_856 = 1908,
            SHODOW_HOLDING_REGISTER_CONFIG_857 = 1909,
            SHODOW_HOLDING_REGISTER_CONFIG_858 = 1910,
            SHODOW_HOLDING_REGISTER_CONFIG_859 = 1911,
            SHODOW_HOLDING_REGISTER_CONFIG_860 = 1912,
            SHODOW_HOLDING_REGISTER_CONFIG_861 = 1913,
            SHODOW_HOLDING_REGISTER_CONFIG_862 = 1914,
            SHODOW_HOLDING_REGISTER_CONFIG_863 = 1915,
            SHODOW_HOLDING_REGISTER_CONFIG_864 = 1916,
            SHODOW_HOLDING_REGISTER_CONFIG_865 = 1917,
            SHODOW_HOLDING_REGISTER_CONFIG_866 = 1918,
            SHODOW_HOLDING_REGISTER_CONFIG_867 = 1919,
            SHODOW_HOLDING_REGISTER_CONFIG_868 = 1920,
            SHODOW_HOLDING_REGISTER_CONFIG_869 = 1921,
            SHODOW_HOLDING_REGISTER_CONFIG_870 = 1922,
            SHODOW_HOLDING_REGISTER_CONFIG_871 = 1923,
            SHODOW_HOLDING_REGISTER_CONFIG_872 = 1924,
            SHODOW_HOLDING_REGISTER_CONFIG_873 = 1925,
            SHODOW_HOLDING_REGISTER_CONFIG_874 = 1926,
            SHODOW_HOLDING_REGISTER_CONFIG_875 = 1927,
            SHODOW_HOLDING_REGISTER_CONFIG_876 = 1928,
            SHODOW_HOLDING_REGISTER_CONFIG_877 = 1929,
            SHODOW_HOLDING_REGISTER_CONFIG_878 = 1930,
            SHODOW_HOLDING_REGISTER_CONFIG_879 = 1931,
            SHODOW_HOLDING_REGISTER_CONFIG_880 = 1932,
            SHODOW_HOLDING_REGISTER_CONFIG_881 = 1933,
            SHODOW_HOLDING_REGISTER_CONFIG_882 = 1934,
            SHODOW_HOLDING_REGISTER_CONFIG_883 = 1935,
            SHODOW_HOLDING_REGISTER_CONFIG_884 = 1936,
            SHODOW_HOLDING_REGISTER_CONFIG_885 = 1937,
            SHODOW_HOLDING_REGISTER_CONFIG_886 = 1938,
            SHODOW_HOLDING_REGISTER_CONFIG_887 = 1939,
            SHODOW_HOLDING_REGISTER_CONFIG_888 = 1940,
            SHODOW_HOLDING_REGISTER_CONFIG_889 = 1941,
            SHODOW_HOLDING_REGISTER_CONFIG_890 = 1942,
            SHODOW_HOLDING_REGISTER_CONFIG_891 = 1943,
            SHODOW_HOLDING_REGISTER_CONFIG_892 = 1944,
            SHODOW_HOLDING_REGISTER_CONFIG_893 = 1945,
            SHODOW_HOLDING_REGISTER_CONFIG_894 = 1946,
            SHODOW_HOLDING_REGISTER_CONFIG_895 = 1947,
            SHODOW_HOLDING_REGISTER_CONFIG_896 = 1948,
            SHODOW_HOLDING_REGISTER_CONFIG_897 = 1949,
            SHODOW_HOLDING_REGISTER_CONFIG_898 = 1950,
            SHODOW_HOLDING_REGISTER_CONFIG_899 = 1951,
            SHODOW_HOLDING_REGISTER_CONFIG_900 = 1952,
            SHODOW_HOLDING_REGISTER_CONFIG_901 = 1953,
            SHODOW_HOLDING_REGISTER_CONFIG_902 = 1954,
            SHODOW_HOLDING_REGISTER_CONFIG_903 = 1955,
            SHODOW_HOLDING_REGISTER_CONFIG_904 = 1956,
            SHODOW_HOLDING_REGISTER_CONFIG_905 = 1957,
            SHODOW_HOLDING_REGISTER_CONFIG_906 = 1958,
            SHODOW_HOLDING_REGISTER_CONFIG_907 = 1959,
            SHODOW_HOLDING_REGISTER_CONFIG_908 = 1960,
            SHODOW_HOLDING_REGISTER_CONFIG_909 = 1961,
            SHODOW_HOLDING_REGISTER_CONFIG_910 = 1962,
            SHODOW_HOLDING_REGISTER_CONFIG_911 = 1963,
            SHODOW_HOLDING_REGISTER_CONFIG_912 = 1964,
            SHODOW_HOLDING_REGISTER_CONFIG_913 = 1965,
            SHODOW_HOLDING_REGISTER_CONFIG_914 = 1966,
            SHODOW_HOLDING_REGISTER_CONFIG_915 = 1967,
            SHODOW_HOLDING_REGISTER_CONFIG_916 = 1968,
            SHODOW_HOLDING_REGISTER_CONFIG_917 = 1969,
            SHODOW_HOLDING_REGISTER_CONFIG_918 = 1970,
            SHODOW_HOLDING_REGISTER_CONFIG_919 = 1971,
            SHODOW_HOLDING_REGISTER_CONFIG_920 = 1972,
            SHODOW_HOLDING_REGISTER_CONFIG_921 = 1973,
            SHODOW_HOLDING_REGISTER_CONFIG_922 = 1974,
            SHODOW_HOLDING_REGISTER_CONFIG_923 = 1975,
            SHODOW_HOLDING_REGISTER_CONFIG_924 = 1976,
            SHODOW_HOLDING_REGISTER_CONFIG_925 = 1977,
            SHODOW_HOLDING_REGISTER_CONFIG_926 = 1978,
            SHODOW_HOLDING_REGISTER_CONFIG_927 = 1979,
            SHODOW_HOLDING_REGISTER_CONFIG_928 = 1980,
            SHODOW_HOLDING_REGISTER_CONFIG_929 = 1981,
            SHODOW_HOLDING_REGISTER_CONFIG_930 = 1982,
            SHODOW_HOLDING_REGISTER_CONFIG_931 = 1983,
            SHODOW_HOLDING_REGISTER_CONFIG_932 = 1984,
            SHODOW_HOLDING_REGISTER_CONFIG_933 = 1985,
            SHODOW_HOLDING_REGISTER_CONFIG_934 = 1986,
            SHODOW_HOLDING_REGISTER_CONFIG_935 = 1987,
            SHODOW_HOLDING_REGISTER_CONFIG_936 = 1988,
            SHODOW_HOLDING_REGISTER_CONFIG_937 = 1989,
            SHODOW_HOLDING_REGISTER_CONFIG_938 = 1990,
            SHODOW_HOLDING_REGISTER_CONFIG_939 = 1991,
            SHODOW_HOLDING_REGISTER_CONFIG_940 = 1992,
            SHODOW_HOLDING_REGISTER_CONFIG_941 = 1993,
            SHODOW_HOLDING_REGISTER_CONFIG_942 = 1994,
            SHODOW_HOLDING_REGISTER_CONFIG_943 = 1995,
            SHODOW_HOLDING_REGISTER_CONFIG_944 = 1996,
            SHODOW_HOLDING_REGISTER_CONFIG_945 = 1997,
            SHODOW_HOLDING_REGISTER_CONFIG_946 = 1998,
            SHODOW_HOLDING_REGISTER_CONFIG_947 = 1999,
            SHODOW_HOLDING_REGISTER_CONFIG_948 = 2000,
            SHODOW_HOLDING_REGISTER_CONFIG_949 = 2001,
            SHODOW_HOLDING_REGISTER_CONFIG_950 = 2002,
            SHODOW_HOLDING_REGISTER_CONFIG_951 = 2003,
            SHODOW_HOLDING_REGISTER_CONFIG_952 = 2004,
            SHODOW_HOLDING_REGISTER_CONFIG_953 = 2005,
            SHODOW_HOLDING_REGISTER_CONFIG_954 = 2006,
            SHODOW_HOLDING_REGISTER_CONFIG_955 = 2007,
            SHODOW_HOLDING_REGISTER_CONFIG_956 = 2008,
            SHODOW_HOLDING_REGISTER_CONFIG_957 = 2009,
            SHODOW_HOLDING_REGISTER_CONFIG_958 = 2010,
            SHODOW_HOLDING_REGISTER_CONFIG_959 = 2011,
            SHODOW_HOLDING_REGISTER_CONFIG_960 = 2012,
            SHODOW_HOLDING_REGISTER_CONFIG_961 = 2013,
            SHODOW_HOLDING_REGISTER_CONFIG_962 = 2014,
            SHODOW_HOLDING_REGISTER_CONFIG_963 = 2015,
            SHODOW_HOLDING_REGISTER_CONFIG_964 = 2016,
            SHODOW_HOLDING_REGISTER_CONFIG_965 = 2017,
            SHODOW_HOLDING_REGISTER_CONFIG_966 = 2018,
            SHODOW_HOLDING_REGISTER_CONFIG_967 = 2019,
            SHODOW_HOLDING_REGISTER_CONFIG_968 = 2020,
            SHODOW_HOLDING_REGISTER_CONFIG_969 = 2021,
            SHODOW_HOLDING_REGISTER_CONFIG_970 = 2022,
            SHODOW_HOLDING_REGISTER_CONFIG_971 = 2023,
            SHODOW_HOLDING_REGISTER_CONFIG_972 = 2024,
            SHODOW_HOLDING_REGISTER_CONFIG_973 = 2025,
            SHODOW_HOLDING_REGISTER_CONFIG_974 = 2026,
            SHODOW_HOLDING_REGISTER_CONFIG_975 = 2027,
            SHODOW_HOLDING_REGISTER_CONFIG_976 = 2028,
            SHODOW_HOLDING_REGISTER_CONFIG_977 = 2029,
            SHODOW_HOLDING_REGISTER_CONFIG_978 = 2030,
            SHODOW_HOLDING_REGISTER_CONFIG_979 = 2031,
            SHODOW_HOLDING_REGISTER_CONFIG_980 = 2032,
            SHODOW_HOLDING_REGISTER_CONFIG_981 = 2033,
            SHODOW_HOLDING_REGISTER_CONFIG_982 = 2034,
            SHODOW_HOLDING_REGISTER_CONFIG_983 = 2035,
            SHODOW_HOLDING_REGISTER_CONFIG_984 = 2036,
            SHODOW_HOLDING_REGISTER_CONFIG_985 = 2037,
            SHODOW_HOLDING_REGISTER_CONFIG_986 = 2038,
            SHODOW_HOLDING_REGISTER_CONFIG_987 = 2039,
            SHODOW_HOLDING_REGISTER_CONFIG_988 = 2040,
            SHODOW_HOLDING_REGISTER_CONFIG_989 = 2041,
            SHODOW_HOLDING_REGISTER_CONFIG_990 = 2042,
            SHODOW_HOLDING_REGISTER_CONFIG_991 = 2043,
            SHODOW_HOLDING_REGISTER_CONFIG_992 = 2044,
            SHODOW_HOLDING_REGISTER_CONFIG_993 = 2045,
            SHODOW_HOLDING_REGISTER_CONFIG_994 = 2046,
            SHODOW_HOLDING_REGISTER_CONFIG_995 = 2047,
            SHODOW_HOLDING_REGISTER_CONFIG_996 = 2048,
            SHODOW_HOLDING_REGISTER_CONFIG_997 = 2049,
            SHODOW_HOLDING_REGISTER_CONFIG_998 = 2050,
            SHODOW_HOLDING_REGISTER_CONFIG_999 = 2051,
            SLAVE_ID = 2052,
            IDENTIFY_STATUS = 2053,
            STREAMING_ENABLE_CMD = 2054,
            STREAMING_DISABLE_CMD = 2055,
            DOWN_STREAM_BAUDRATE = 2056,
            UP_STREAM_RECEIVED_FRAME_QTY = 2057,
            UP_STREAM_RECEIVED_FRAME_MISMATCH_ID_QTY = 2058,
            UP_STREAM_RECEIVED_FRAME_BROADCAST_QTY = 2059,
            UP_STREAM_RECEIVED_FRAME_ERROR_QTY = 2060,
            UP_STREAM_SEND_FRAME_QTY = 2061,
            UP_STREAM_ENQUEUED_FRAME_QTY = 2062,
            UP_STREAM_ENQUEUE_FAILED_FRAME_QTY = 2063,
            UP_STREAM_RECEIVED_FRAME_HANDLE_EXECUTION_TIME_US = 2064,
            UP_STREAM_RECEIVED_FRAME_MEMORY_MAP_HANDLER_EXECUTION_TIME_US = 2065,
            UP_STREAM_RECEIVED_FRAME_MISMATCH_ID_HANDLER_EXECUTION_TIME_US = 2066,
            UP_STREAM_RECEIVED_FRAME_BROADCAST_HANDLER_EXECUTION_TIME_US = 2067,
            UP_STREAM_RECEIVED_FRAME_TRANSACTION_DONE_HANDLER_EXECUTION_TIME_US = 2068,
            UP_STREAM_RECEIVED_FRAME_ERROR_HANDLER_EXECUTION_TIME_US = 2069,
            UP_STREAM_SEND_FRAME_HANDLE_EXECUTION_TIME_US = 2070,
            UP_STREAM_DELAY_BETWEEN_FRAME_US = 2071,
            STREAMER_ENABLE = 2072,
            STREAMER_EXTENDED_HEADER_ENABLE = 2073,
            STREAMER_INTERNAL_CLOCK_INTERVAL_MS = 2074,
            STREAMER_PRESCALER = 2075,
            STREAMER_PARAMETER_IDS_0 = 2076,
            STREAMER_PARAMETER_IDS_1 = 2077,
            STREAMER_PARAMETER_IDS_2 = 2078,
            STREAMER_PARAMETER_IDS_3 = 2079,
            STREAMER_PARAMETER_IDS_4 = 2080,
            STREAMER_PARAMETER_IDS_5 = 2081,
            STREAMER_PARAMETER_IDS_6 = 2082,
            STREAMER_PARAMETER_IDS_7 = 2083,
            STREAMER_PARAMETER_IDS_8 = 2084,
            STREAMER_PARAMETER_IDS_9 = 2085,
            STREAMER_PARAMETER_IDS_10 = 2086,
            STREAMER_PARAMETER_IDS_11 = 2087,
            STREAMER_PARAMETER_IDS_12 = 2088,
            STREAMER_PARAMETER_IDS_13 = 2089,
            STREAMER_PARAMETER_IDS_14 = 2090,
            STREAMER_PARAMETER_IDS_15 = 2091,
            STREAMER_PARAMETER_IDS_16 = 2092,
            STREAMER_PARAMETER_IDS_17 = 2093,
            STREAMER_PARAMETER_IDS_18 = 2094,
            STREAMER_PARAMETER_IDS_19 = 2095,
            STREAMER_PARAMETER_IDS_20 = 2096,
            STREAMER_PARAMETER_IDS_21 = 2097,
            STREAMER_PARAMETER_IDS_22 = 2098,
            STREAMER_PARAMETER_IDS_23 = 2099,
            STREAMER_PARAMETER_IDS_24 = 2100,
            STREAMER_PARAMETER_IDS_25 = 2101,
            STREAMER_PARAMETER_IDS_26 = 2102,
            STREAMER_PARAMETER_IDS_27 = 2103,
            STREAMER_PARAMETER_IDS_28 = 2104,
            STREAMER_PARAMETER_IDS_29 = 2105,
            STREAMER_PARAMETER_IDS_30 = 2106,
            STREAMER_PARAMETER_IDS_31 = 2107,
            STREAMER_PARAMETER_IDS_32 = 2108,
            STREAMER_PARAMETER_IDS_33 = 2109,
            STREAMER_PARAMETER_IDS_34 = 2110,
            STREAMER_PARAMETER_IDS_35 = 2111,
            STREAMER_PARAMETER_IDS_36 = 2112,
            STREAMER_PARAMETER_IDS_37 = 2113,
            STREAMER_PARAMETER_IDS_38 = 2114,
            STREAMER_PARAMETER_IDS_39 = 2115,
            STREAMER_PARAMETER_IDS_40 = 2116,
            STREAMER_PARAMETER_IDS_41 = 2117,
            STREAMER_PARAMETER_IDS_42 = 2118,
            STREAMER_PARAMETER_IDS_43 = 2119,
            STREAMER_PARAMETER_IDS_44 = 2120,
            STREAMER_PARAMETER_IDS_45 = 2121,
            STREAMER_PARAMETER_IDS_46 = 2122,
            STREAMER_PARAMETER_IDS_47 = 2123,
            STREAMER_PARAMETER_IDS_48 = 2124,
            STREAMER_PARAMETER_IDS_49 = 2125,
            STREAMER_PARAMETER_IDS_50 = 2126,
            STREAMER_PARAMETER_IDS_51 = 2127,
            STREAMER_PARAMETER_IDS_52 = 2128,
            STREAMER_PARAMETER_IDS_53 = 2129,
            STREAMER_PARAMETER_IDS_54 = 2130,
            STREAMER_PARAMETER_IDS_55 = 2131,
            STREAMER_PARAMETER_IDS_56 = 2132,
            STREAMER_PARAMETER_IDS_57 = 2133,
            STREAMER_PARAMETER_IDS_58 = 2134,
            STREAMER_PARAMETER_IDS_59 = 2135,
            STREAMER_PARAMETER_IDS_60 = 2136,
            STREAMER_PARAMETER_IDS_61 = 2137,
            STREAMER_PARAMETER_IDS_62 = 2138,
            STREAMER_PARAMETER_IDS_63 = 2139,
            STREAMER_PARAMETER_IDS_64 = 2140,
            STREAMER_PARAMETER_IDS_65 = 2141,
            STREAMER_PARAMETER_IDS_66 = 2142,
            STREAMER_PARAMETER_IDS_67 = 2143,
            STREAMER_PARAMETER_IDS_68 = 2144,
            STREAMER_PARAMETER_IDS_69 = 2145,
            STREAMER_PARAMETER_IDS_70 = 2146,
            STREAMER_PARAMETER_IDS_71 = 2147,
            STREAMER_PARAMETER_IDS_72 = 2148,
            STREAMER_PARAMETER_IDS_73 = 2149,
            STREAMER_PARAMETER_IDS_74 = 2150,
            STREAMER_PARAMETER_IDS_75 = 2151,
            STREAMER_PARAMETER_IDS_76 = 2152,
            STREAMER_PARAMETER_IDS_77 = 2153,
            STREAMER_PARAMETER_IDS_78 = 2154,
            STREAMER_PARAMETER_IDS_79 = 2155,
            STREAMER_PARAMETER_IDS_80 = 2156,
            STREAMER_PARAMETER_IDS_81 = 2157,
            STREAMER_PARAMETER_IDS_82 = 2158,
            STREAMER_PARAMETER_IDS_83 = 2159,
            STREAMER_PARAMETER_IDS_84 = 2160,
            STREAMER_PARAMETER_IDS_85 = 2161,
            STREAMER_PARAMETER_IDS_86 = 2162,
            STREAMER_PARAMETER_IDS_87 = 2163,
            STREAMER_PARAMETER_IDS_88 = 2164,
            STREAMER_PARAMETER_IDS_89 = 2165,
            STREAMER_PARAMETER_IDS_90 = 2166,
            STREAMER_PARAMETER_IDS_91 = 2167,
            STREAMER_PARAMETER_IDS_92 = 2168,
            STREAMER_PARAMETER_IDS_93 = 2169,
            STREAMER_PARAMETER_IDS_94 = 2170,
            STREAMER_PARAMETER_IDS_95 = 2171,
            STREAMER_PARAMETER_IDS_96 = 2172,
            STREAMER_PARAMETER_IDS_97 = 2173,
            STREAMER_PARAMETER_IDS_98 = 2174,
            STREAMER_PARAMETER_IDS_99 = 2175,
            STREAMER_PARAMETER_IDS_100 = 2176,
            STREAMER_PARAMETER_IDS_101 = 2177,
            STREAMER_PARAMETER_IDS_102 = 2178,
            STREAMER_PARAMETER_IDS_103 = 2179,
            STREAMER_PARAMETER_IDS_104 = 2180,
            STREAMER_PARAMETER_IDS_105 = 2181,
            STREAMER_PARAMETER_IDS_106 = 2182,
            STREAMER_PARAMETER_IDS_107 = 2183,
            STREAMER_PARAMETER_IDS_108 = 2184,
            STREAMER_PARAMETER_IDS_109 = 2185,
            STREAMER_PARAMETER_IDS_110 = 2186,
            STREAMER_PARAMETER_IDS_111 = 2187,
            STREAMER_PARAMETER_IDS_112 = 2188,
            STREAMER_PARAMETER_IDS_113 = 2189,
            STREAMER_PARAMETER_IDS_114 = 2190,
            STREAMER_PARAMETER_IDS_115 = 2191,
            STREAMER_PARAMETER_IDS_116 = 2192,
            STREAMER_PARAMETER_IDS_117 = 2193,
            STREAMER_PARAMETER_IDS_118 = 2194,
            STREAMER_PARAMETER_IDS_119 = 2195,
            STREAMER_PARAMETER_IDS_120 = 2196,
            STREAMER_PARAMETER_IDS_121 = 2197,
            STREAMER_PARAMETER_IDS_122 = 2198,
            STREAMER_PARAMETER_IDS_123 = 2199,
            STREAMER_PARAMETER_IDS_124 = 2200,
            STREAMER_PARAMETER_IDS_125 = 2201,
            STREAMER_PARAMETER_IDS_126 = 2202,
            STREAMER_PARAMETER_IDS_127 = 2203,
            STREAMER_PARAMETER_IDS_128 = 2204,
            STREAMER_PARAMETER_IDS_129 = 2205,
            STREAMER_PARAMETER_IDS_130 = 2206,
            STREAMER_PARAMETER_IDS_131 = 2207,
            STREAMER_PARAMETER_IDS_132 = 2208,
            STREAMER_PARAMETER_IDS_133 = 2209,
            STREAMER_PARAMETER_IDS_134 = 2210,
            STREAMER_PARAMETER_IDS_135 = 2211,
            STREAMER_PARAMETER_IDS_136 = 2212,
            STREAMER_PARAMETER_IDS_137 = 2213,
            STREAMER_PARAMETER_IDS_138 = 2214,
            STREAMER_PARAMETER_IDS_139 = 2215,
            STREAMER_PARAMETER_IDS_140 = 2216,
            STREAMER_PARAMETER_IDS_141 = 2217,
            STREAMER_PARAMETER_IDS_142 = 2218,
            STREAMER_PARAMETER_IDS_143 = 2219,
            STREAMER_PARAMETER_IDS_144 = 2220,
            STREAMER_PARAMETER_IDS_145 = 2221,
            STREAMER_PARAMETER_IDS_146 = 2222,
            STREAMER_PARAMETER_IDS_147 = 2223,
            STREAMER_PARAMETER_IDS_148 = 2224,
            STREAMER_PARAMETER_IDS_149 = 2225,
            STREAMER_PARAMETER_IDS_150 = 2226,
            STREAMER_PARAMETER_IDS_151 = 2227,
            STREAMER_PARAMETER_IDS_152 = 2228,
            STREAMER_PARAMETER_IDS_153 = 2229,
            STREAMER_PARAMETER_IDS_154 = 2230,
            STREAMER_PARAMETER_IDS_155 = 2231,
            STREAMER_PARAMETER_IDS_156 = 2232,
            STREAMER_PARAMETER_IDS_157 = 2233,
            STREAMER_PARAMETER_IDS_158 = 2234,
            STREAMER_PARAMETER_IDS_159 = 2235,
            STREAMER_PARAMETER_IDS_160 = 2236,
            STREAMER_PARAMETER_IDS_161 = 2237,
            STREAMER_PARAMETER_IDS_162 = 2238,
            STREAMER_PARAMETER_IDS_163 = 2239,
            STREAMER_PARAMETER_IDS_164 = 2240,
            STREAMER_PARAMETER_IDS_165 = 2241,
            STREAMER_PARAMETER_IDS_166 = 2242,
            STREAMER_PARAMETER_IDS_167 = 2243,
            STREAMER_PARAMETER_IDS_168 = 2244,
            STREAMER_PARAMETER_IDS_169 = 2245,
            STREAMER_PARAMETER_IDS_170 = 2246,
            STREAMER_PARAMETER_IDS_171 = 2247,
            STREAMER_PARAMETER_IDS_172 = 2248,
            STREAMER_PARAMETER_IDS_173 = 2249,
            STREAMER_PARAMETER_IDS_174 = 2250,
            STREAMER_PARAMETER_IDS_175 = 2251,
            STREAMER_PARAMETER_IDS_176 = 2252,
            STREAMER_PARAMETER_IDS_177 = 2253,
            STREAMER_PARAMETER_IDS_178 = 2254,
            STREAMER_PARAMETER_IDS_179 = 2255,
            STREAMER_PARAMETER_IDS_180 = 2256,
            STREAMER_PARAMETER_IDS_181 = 2257,
            STREAMER_PARAMETER_IDS_182 = 2258,
            STREAMER_PARAMETER_IDS_183 = 2259,
            STREAMER_PARAMETER_IDS_184 = 2260,
            STREAMER_PARAMETER_IDS_185 = 2261,
            STREAMER_PARAMETER_IDS_186 = 2262,
            STREAMER_PARAMETER_IDS_187 = 2263,
            STREAMER_PARAMETER_IDS_188 = 2264,
            STREAMER_PARAMETER_IDS_189 = 2265,
            STREAMER_PARAMETER_IDS_190 = 2266,
            STREAMER_PARAMETER_IDS_191 = 2267,
            STREAMER_PARAMETER_IDS_192 = 2268,
            STREAMER_PARAMETER_IDS_193 = 2269,
            STREAMER_PARAMETER_IDS_194 = 2270,
            STREAMER_PARAMETER_IDS_195 = 2271,
            STREAMER_PARAMETER_IDS_196 = 2272,
            STREAMER_PARAMETER_IDS_197 = 2273,
            STREAMER_PARAMETER_IDS_198 = 2274,
            STREAMER_PARAMETER_IDS_199 = 2275,
            STREAMER_INTERVAL_US = 2276,
            STREAMER_FRAME_COUNTER = 2277,
            STREAMER_PARAMETER_QTY = 2278,
            STREAMER_FRAME_GENERATION_EXECUTION_TIME_US = 2279,
            BOARD_STARTUP_DELAY_MS = 2280,
            BOARD_STARTUP_RETRY_QTY = 2281,
            BOARD_STARTUP_RETRY_DELAY_MS = 2282,
            BOARD_STARTUP_REPORT_OVERALL_RESULT = 2283,
            BOARD_STARTUP_REPORT_EXECUTION_TIME_US = 2284,
            BOARD_STARTUP_REPORT_MS5611_CONNECTION_RESULT = 2285,
            BOARD_STARTUP_REPORT_MS5611_CONNECTION_RETRY = 2286,
            BOARD_STARTUP_REPORT_MS5611_CONNECTION_TIME_US = 2287,
            BOARD_STARTUP_REPORT_MS5611_CONFIG_RESULT = 2288,
            BOARD_STARTUP_REPORT_MS5611_CONFIG_RETRY = 2289,
            BOARD_STARTUP_REPORT_MS5611_CONFIG_TIME_US = 2290,
            BOARD_STARTUP_REPORT_DADC_CONNECTION_RESULT = 2291,
            BOARD_STARTUP_REPORT_DADC_CONNECTION_RETRY = 2292,
            BOARD_STARTUP_REPORT_DADC_CONNECTION_TIME_US = 2293,
            BOARD_STARTUP_REPORT_DADC_CONFIG_RESULT = 2294,
            BOARD_STARTUP_REPORT_DADC_CONFIG_RETRY = 2295,
            BOARD_STARTUP_REPORT_DADC_CONFIG_TIME_US = 2296,
            BOARD_STARTUP_REPORT_IBNS_MATCH_CONNECTION_RESULT = 2297,
            BOARD_STARTUP_REPORT_IBNS_MATCH_CONNECTION_RETRY = 2298,
            BOARD_STARTUP_REPORT_IBNS_MATCH_CONNECTION_TIME_US = 2299,
            BOARD_STARTUP_REPORT_IBNS_MATCH_CONFIG_RESULT = 2300,
            BOARD_STARTUP_REPORT_IBNS_MATCH_CONFIG_RETRY = 2301,
            BOARD_STARTUP_REPORT_IBNS_MATCH_CONFIG_TIME_US = 2302,
            BOARD_STARTUP_REPORT_IBNS_SPEED_CONNECTION_RESULT = 2303,
            BOARD_STARTUP_REPORT_IBNS_SPEED_CONNECTION_RETRY = 2304,
            BOARD_STARTUP_REPORT_IBNS_SPEED_CONNECTION_TIME_US = 2305,
            BOARD_STARTUP_REPORT_IBNS_SPEED_CONFIG_RESULT = 2306,
            BOARD_STARTUP_REPORT_IBNS_SPEED_CONFIG_RETRY = 2307,
            BOARD_STARTUP_REPORT_IBNS_SPEED_CONFIG_TIME_US = 2308,
            BOARD_STARTUP_REPORT_SADRA_CONNECTION_RESULT = 2309,
            BOARD_STARTUP_REPORT_SADRA_CONNECTION_RETRY = 2310,
            BOARD_STARTUP_REPORT_SADRA_CONNECTION_TIME_US = 2311,
            BOARD_STARTUP_REPORT_SADRA_CONFIG_RESULT = 2312,
            BOARD_STARTUP_REPORT_SADRA_CONFIG_RETRY = 2313,
            BOARD_STARTUP_REPORT_SADRA_CONFIG_TIME_US = 2314,
            BOARD_STARTUP_REPORT_HMC5983_CONNECTION_RESULT = 2315,
            BOARD_STARTUP_REPORT_HMC5983_CONNECTION_RETRY = 2316,
            BOARD_STARTUP_REPORT_HMC5983_CONNECTION_TIME_US = 2317,
            BOARD_STARTUP_REPORT_HMC5983_CONFIG_RESULT = 2318,
            BOARD_STARTUP_REPORT_HMC5983_CONFIG_RETRY = 2319,
            BOARD_STARTUP_REPORT_HMC5983_CONFIG_TIME_US = 2320,
            BOARD_STARTUP_REPORT_GPS_M9_N_CONNECTION_RESULT = 2321,
            BOARD_STARTUP_REPORT_GPS_M9_N_CONNECTION_RETRY = 2322,
            BOARD_STARTUP_REPORT_GPS_M9_N_CONNECTION_TIME_US = 2323,
            BOARD_STARTUP_REPORT_GPS_M9_N_CONFIG_RESULT = 2324,
            BOARD_STARTUP_REPORT_GPS_M9_N_CONFIG_RETRY = 2325,
            BOARD_STARTUP_REPORT_GPS_M9_N_CONFIG_TIME_US = 2326,
            BOARD_STARTUP_REPORT_IMU_CONNECTION_RESULT = 2327,
            BOARD_STARTUP_REPORT_IMU_CONNECTION_RETRY = 2328,
            BOARD_STARTUP_REPORT_IMU_CONNECTION_TIME_US = 2329,
            BOARD_STARTUP_REPORT_IMU_CONFIG_RESULT = 2330,
            BOARD_STARTUP_REPORT_IMU_CONFIG_RETRY = 2331,
            BOARD_STARTUP_REPORT_IMU_CONFIG_TIME_US = 2332,
            IMU_DATA_ACC_G_0_X = 2333,
            IMU_DATA_ACC_G_0_Y = 2334,
            IMU_DATA_ACC_G_0_Z = 2335,
            IMU_DATA_ACC_G_1_X = 2336,
            IMU_DATA_ACC_G_1_Y = 2337,
            IMU_DATA_ACC_G_1_Z = 2338,
            IMU_DATA_GYR_DPS_0_X = 2339,
            IMU_DATA_GYR_DPS_0_Y = 2340,
            IMU_DATA_GYR_DPS_0_Z = 2341,
            IMU_DATA_GYR_DPS_1_X = 2342,
            IMU_DATA_GYR_DPS_1_Y = 2343,
            IMU_DATA_GYR_DPS_1_Z = 2344,
            IMU_DATA_TEMPERATURE = 2345,
            IMU_DATA_SERIAL_NO = 2346,
            IMU_DATA_COUNTER = 2347,
            IMU_DATA_IS_NEW_DATA = 2348,
            IMU_DATA_ACTIVE = 2349,
            IMU_DATA_SUMMARY_STATUS = 2350,
            IMU_SETTING_TYPE = 2351,
            IMU_SETTING_DEC_RATE = 2352,
            IMU_SETTING_FILTER_ACC_XENABLE = 2353,
            IMU_SETTING_FILTER_ACC_XTYPE = 2354,
            IMU_SETTING_FILTER_ACC_YENABLE = 2355,
            IMU_SETTING_FILTER_ACC_YTYPE = 2356,
            IMU_SETTING_FILTER_ACC_ZENABLE = 2357,
            IMU_SETTING_FILTER_ACC_ZTYPE = 2358,
            IMU_SETTING_FILTER_GYRO_XENABLE = 2359,
            IMU_SETTING_FILTER_GYRO_XTYPE = 2360,
            IMU_SETTING_FILTER_GYRO_YENABLE = 2361,
            IMU_SETTING_FILTER_GYRO_YTYPE = 2362,
            IMU_SETTING_FILTER_GYRO_ZENABLE = 2363,
            IMU_SETTING_FILTER_GYRO_ZTYPE = 2364,
            IMU_SETTING_FILTER_MAG_XENABLE = 2365,
            IMU_SETTING_FILTER_MAG_XTYPE = 2366,
            IMU_SETTING_FILTER_MAG_YENABLE = 2367,
            IMU_SETTING_FILTER_MAG_YTYPE = 2368,
            IMU_SETTING_FILTER_MAG_ZENABLE = 2369,
            IMU_SETTING_FILTER_MAG_ZTYPE = 2370,
            IMU_SETTING_ENABLE = 2371,
            MS5611_DATA_PRESS = 2372,
            MS5611_DATA_TEMPERATURE = 2373,
            MS5611_DATA_IS_NEW_DATA = 2374,
            MS5611_DATA_ACTIVE = 2375,
            MS5611_DATA_SUMMARY_STATUS = 2376,
            MS5611_SETTING_OSR = 2377,
            MS5611_SETTING_ENABLE = 2378,
            M9N_DATA_ITOW = 2379,
            M9N_DATA_YEAR = 2380,
            M9N_DATA_MONTH = 2381,
            M9N_DATA_DAY = 2382,
            M9N_DATA_HOURS = 2383,
            M9N_DATA_MIN = 2384,
            M9N_DATA_SEC = 2385,
            M9N_DATA_VALID = 2386,
            M9N_DATA_TACC = 2387,
            M9N_DATA_NANO = 2388,
            M9N_DATA_FIX_TYPE = 2389,
            M9N_DATA_FLAGS = 2390,
            M9N_DATA_FLAGS2 = 2391,
            M9N_DATA_NUM_SV = 2392,
            M9N_DATA_LON = 2393,
            M9N_DATA_LAT = 2394,
            M9N_DATA_HEIGHT = 2395,
            M9N_DATA_HMSL = 2396,
            M9N_DATA_HACC = 2397,
            M9N_DATA_VACC = 2398,
            M9N_DATA_VEL_NED_0 = 2399,
            M9N_DATA_VEL_NED_1 = 2400,
            M9N_DATA_VEL_NED_2 = 2401,
            M9N_DATA_GSPEED = 2402,
            M9N_DATA_HEAD_MOT = 2403,
            M9N_DATA_SACC = 2404,
            M9N_DATA_HEAD_ACC = 2405,
            M9N_DATA_PDOP = 2406,
            M9N_DATA_RESESRVED_0 = 2407,
            M9N_DATA_RESESRVED_1 = 2408,
            M9N_DATA_RESESRVED_2 = 2409,
            M9N_DATA_RESESRVED_3 = 2410,
            M9N_DATA_HEAD_VEH = 2411,
            M9N_DATA_MAG_DEC = 2412,
            M9N_DATA_MAG_ACC = 2413,
            M9N_DATA_FRAME_COUNTER = 2414,
            M9N_DATA_FRAME_ERROR_COUNTER = 2415,
            M9N_DATA_IS_VALID_DATA = 2416,
            M9N_DATA_IS_NEW_DATA = 2417,
            M9N_DATA_ACTIVE = 2418,
            M9N_DATA_SUMMARY_STATUS = 2419,
            M9N_SETTING_BAUD_RATE = 2420,
            M9N_SETTING_ENABLE = 2421,
            DADC_DATA_ADC_IS_NEW_DATA = 2422,
            DADC_DATA_ADC_UNIT = 2423,
            DADC_DATA_ADC_OUTSIDE_PROBE_TEMP = 2424,
            DADC_DATA_ADC_INTERNAL_PROBE_TEMP = 2425,
            DADC_DATA_ADC_STATIC_PRESSURE = 2426,
            DADC_DATA_ADC_PITOT_DIFF_PRESSURE = 2427,
            DADC_DATA_ADA_IS_NEW_DATA = 2428,
            DADC_DATA_ADA_UNIT = 2429,
            DADC_DATA_ADA_PRESSURE_ALTITUDE = 2430,
            DADC_DATA_ADA_INDICATED_ALTITUDE = 2431,
            DADC_DATA_ADA_TRUE_ALTITUDE = 2432,
            DADC_DATA_ADA_RATE_OF_CLIMB = 2433,
            DADC_DATA_ADA_OUTSIDE_AIR_TEMPERATURE = 2434,
            DADC_DATA_ADA_TOTAL_AIR_TEMPERATURE = 2435,
            DADC_DATA_ADA_DIFF_OUTSIDE_AIR_TEMP_AND_ISA = 2436,
            DADC_DATA_ADV_IS_NEW_DATA = 2437,
            DADC_DATA_ADV_UNIT = 2438,
            DADC_DATA_ADV_CALIBRATED_AIR_SPEED = 2439,
            DADC_DATA_ADV_TRUE_AIRSPEED = 2440,
            DADC_DATA_ADV_MACH_NUM = 2441,
            DADC_DATA_ADV_AIR_DENSITY = 2442,
            DADC_DATA_ADR_IS_NEW_DATA = 2443,
            DADC_DATA_ADR_CPU_TEMP = 2444,
            DADC_DATA_ADR_OUTSIDE_RTD_MV = 2445,
            DADC_DATA_ADR_INSIDE_RTD_MV = 2446,
            DADC_DATA_ADR_STATIC_PRESS_V = 2447,
            DADC_DATA_ADR_DIFF_PRESS_V = 2448,
            DADC_DATA_ACTIVE = 2449,
            DADC_DATA_SUMMARY_STATUS = 2450,
            DADC_SETTING_ENABLE = 2451,
            HMC5983_DATA_MAG_X = 2452,
            HMC5983_DATA_MAG_Y = 2453,
            HMC5983_DATA_MAG_Z = 2454,
            HMC5983_DATA_TEMPERATURE = 2455,
            HMC5983_DATA_IS_NEW_DATA = 2456,
            HMC5983_DATA_ACTIVE = 2457,
            HMC5983_DATA_SUMMARY_STATUS = 2458,
            HMC5983_SETTING_ODR = 2459,
            HMC5983_SETTING_SAMPLE_AVERAGE = 2460,
            HMC5983_SETTING_GAIN = 2461,
            HMC5983_SETTING_ENABLE = 2462,
            IBNS_MATCH_DATA_JETSON_TIME_UTC = 2463,
            IBNS_MATCH_DATA_RAW_LAT_DEG = 2464,
            IBNS_MATCH_DATA_RAW_LON_DEG = 2465,
            IBNS_MATCH_DATA_EST_LAT_DEG = 2466,
            IBNS_MATCH_DATA_EST_LON_DEG = 2467,
            IBNS_MATCH_DATA_AGL_M = 2468,
            IBNS_MATCH_DATA_DEM_ALT_M = 2469,
            IBNS_MATCH_DATA_ROLL_FUS_DEG = 2470,
            IBNS_MATCH_DATA_PITCH_FUS_DEG = 2471,
            IBNS_MATCH_DATA_YAW_FUS_DEG = 2472,
            IBNS_MATCH_DATA_HEADING_DEG = 2473,
            IBNS_MATCH_DATA_COURES_DEG = 2474,
            IBNS_MATCH_DATA_QUALITY_MATCH = 2475,
            IBNS_MATCH_DATA_STATUS_FLAGS = 2476,
            IBNS_MATCH_DATA_UPDATE_MASK = 2477,
            IBNS_MATCH_DATA_EXCUTION_TIME_MS = 2478,
            IBNS_MATCH_DATA_IS_NEW_DATA = 2479,
            IBNS_MATCH_DATA_ACTIVE = 2480,
            IBNS_MATCH_DATA_SUMMARY_STATUS = 2481,
            IBNS_MATCH_SETTING_ENABLE = 2482,
            IBNS_SPEED_DATA_JETSON_TIME_UTC = 2483,
            IBNS_SPEED_DATA_ODOLAT_DEG = 2484,
            IBNS_SPEED_DATA_ODOLON_DEG = 2485,
            IBNS_SPEED_DATA_ALT_M = 2486,
            IBNS_SPEED_DATA_ROLL_FUS_DEG = 2487,
            IBNS_SPEED_DATA_PITCH_FUS_DEG = 2488,
            IBNS_SPEED_DATA_YAW_FUS_DEG = 2489,
            IBNS_SPEED_DATA_SPEED_MPS = 2490,
            IBNS_SPEED_DATA_QUALITY_SPEED = 2491,
            IBNS_SPEED_DATA_ODO_DX_M = 2492,
            IBNS_SPEED_DATA_ODO_DY_M = 2493,
            IBNS_SPEED_DATA_STATUS_FLAGS = 2494,
            IBNS_SPEED_DATA_UPDATE_MASK = 2495,
            IBNS_SPEED_DATA_EXCUTION_TIME_MS = 2496,
            IBNS_SPEED_DATA_IS_NEW_DATA = 2497,
            IBNS_SPEED_DATA_ACTIVE = 2498,
            IBNS_SPEED_DATA_SUMMARY_STATUS = 2499,
            IBNS_SPEED_SETTING_ENABLE = 2500,
            SADRA_DATA_INS_FRAME_IS_NEW_DATA = 2501,
            SADRA_DATA_INS_FRAME_EULER_RAD_0 = 2502,
            SADRA_DATA_INS_FRAME_EULER_RAD_1 = 2503,
            SADRA_DATA_INS_FRAME_EULER_RAD_2 = 2504,
            SADRA_DATA_INS_FRAME_COURSE_RAD = 2505,
            SADRA_DATA_INS_FRAME_ACC_ENU_MPS2_0 = 2506,
            SADRA_DATA_INS_FRAME_ACC_ENU_MPS2_1 = 2507,
            SADRA_DATA_INS_FRAME_ACC_ENU_MPS2_2 = 2508,
            SADRA_DATA_INS_FRAME_GYRO_ENU_RPS_0 = 2509,
            SADRA_DATA_INS_FRAME_GYRO_ENU_RPS_1 = 2510,
            SADRA_DATA_INS_FRAME_GYRO_ENU_RPS_2 = 2511,
            SADRA_DATA_INS_FRAME_STATUS = 2512,
            SADRA_DATA_INS_FRAME_LLA_RRM_0 = 2513,
            SADRA_DATA_INS_FRAME_LLA_RRM_1 = 2514,
            SADRA_DATA_INS_FRAME_LLA_RRM_2 = 2515,
            SADRA_DATA_INS_FRAME_VEL_ENU_0 = 2516,
            SADRA_DATA_INS_FRAME_VEL_ENU_1 = 2517,
            SADRA_DATA_INS_FRAME_VEL_ENU_2 = 2518,
            SADRA_DATA_GPS_FRAME_IS_NEW_DATA = 2519,
            SADRA_DATA_GPSFRAME_I_TOW = 2520,
            SADRA_DATA_GPSFRAME_F_TOW = 2521,
            SADRA_DATA_GPSFRAME_NUM_SV = 2522,
            SADRA_DATA_GPSFRAME_WEEK = 2523,
            SADRA_DATA_GPSFRAME_GPSFIX = 2524,
            SADRA_DATA_GPSFRAME_FLAG = 2525,
            SADRA_DATA_GPSFRAME_POS_ECEF_0 = 2526,
            SADRA_DATA_GPSFRAME_POS_ECEF_1 = 2527,
            SADRA_DATA_GPSFRAME_POS_ECEF_2 = 2528,
            SADRA_DATA_GPSFRAME_VEL_ECEF_0 = 2529,
            SADRA_DATA_GPSFRAME_VEL_ECEF_1 = 2530,
            SADRA_DATA_GPSFRAME_VEL_ECEF_2 = 2531,
            SADRA_DATA_ACTIVE = 2532,
            SADRA_DATA_SUMMARY_STATUS = 2533,
            SADRA_SETTING_ENABLE = 2534,
            MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_US = 2535,
            MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_MAXIMA_US = 2536,
            MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_MINIMA_US = 2537,
            MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_LIMIT_EXCEED_COUNTER = 2538,
            MAIN_LOOP_PROFILER_DATA_INTERVAL_TIMING_ERROR = 2539,
            MAIN_LOOP_PROFILER_DATA_EXECUTION_TIME_US = 2540,
            MAIN_LOOP_PROFILER_DATA_EXECUTION_TIME_MAXIMA_US = 2541,
            MAIN_LOOP_PROFILER_DATA_EXECUTION_TIME_MINIMA_US = 2542,
            MAIN_LOOP_PROFILER_DATA_RUN_COUNTER = 2543,
            MAIN_LOOP_PROFILER_SETTING_INTERVAL_TIME_NOMINAL_US = 2544,
            MAIN_LOOP_PROFILER_SETTING_INTERVAL_TIME_MAX_ALLOWED_JITTER_US = 2545,
            CALC_VERSION_MAJOR = 2546,
            CALC_VERSION_MINOR = 2547,
            CALC_VERSION_BUILD1 = 2548,
            CALC_VERSION_BUILD2 = 2549,
            CALC_STATUS = 2550,
            CALC_FREQ_HZ = 2551,
            CALC_COUNTER = 2552,
            DEBUG_SIGNALS_F64_0 = 2553,
            DEBUG_SIGNALS_F64_1 = 2554,
            DEBUG_SIGNALS_F64_2 = 2555,
            DEBUG_SIGNALS_F64_3 = 2556,
            DEBUG_SIGNALS_F64_4 = 2557,
            DEBUG_SIGNALS_F64_5 = 2558,
            DEBUG_SIGNALS_F64_6 = 2559,
            DEBUG_SIGNALS_F64_7 = 2560,
            DEBUG_SIGNALS_F64_8 = 2561,
            DEBUG_SIGNALS_F64_9 = 2562,
            DEBUG_SIGNALS_F64_10 = 2563,
            DEBUG_SIGNALS_F64_11 = 2564,
            DEBUG_SIGNALS_F64_12 = 2565,
            DEBUG_SIGNALS_F64_13 = 2566,
            DEBUG_SIGNALS_F64_14 = 2567,
            DEBUG_SIGNALS_F64_15 = 2568,
            DEBUG_SIGNALS_F64_16 = 2569,
            DEBUG_SIGNALS_F64_17 = 2570,
            DEBUG_SIGNALS_F64_18 = 2571,
            DEBUG_SIGNALS_F64_19 = 2572,
            DEBUG_SIGNALS_F64_20 = 2573,
            DEBUG_SIGNALS_F64_21 = 2574,
            DEBUG_SIGNALS_F64_22 = 2575,
            DEBUG_SIGNALS_F64_23 = 2576,
            DEBUG_SIGNALS_F64_24 = 2577,
            DEBUG_SIGNALS_F64_25 = 2578,
            DEBUG_SIGNALS_F64_26 = 2579,
            DEBUG_SIGNALS_F64_27 = 2580,
            DEBUG_SIGNALS_F64_28 = 2581,
            DEBUG_SIGNALS_F64_29 = 2582,
            DEBUG_SIGNALS_F64_30 = 2583,
            DEBUG_SIGNALS_F64_31 = 2584,
            DEBUG_SIGNALS_F64_32 = 2585,
            DEBUG_SIGNALS_F64_33 = 2586,
            DEBUG_SIGNALS_F64_34 = 2587,
            DEBUG_SIGNALS_F64_35 = 2588,
            DEBUG_SIGNALS_F64_36 = 2589,
            DEBUG_SIGNALS_F64_37 = 2590,
            DEBUG_SIGNALS_F64_38 = 2591,
            DEBUG_SIGNALS_F64_39 = 2592,
            DEBUG_SIGNALS_F64_40 = 2593,
            DEBUG_SIGNALS_F64_41 = 2594,
            DEBUG_SIGNALS_F64_42 = 2595,
            DEBUG_SIGNALS_F64_43 = 2596,
            DEBUG_SIGNALS_F64_44 = 2597,
            DEBUG_SIGNALS_F64_45 = 2598,
            DEBUG_SIGNALS_F64_46 = 2599,
            DEBUG_SIGNALS_F64_47 = 2600,
            DEBUG_SIGNALS_F64_48 = 2601,
            DEBUG_SIGNALS_F64_49 = 2602,
            DEBUG_SIGNALS_F32_0 = 2603,
            DEBUG_SIGNALS_F32_1 = 2604,
            DEBUG_SIGNALS_F32_2 = 2605,
            DEBUG_SIGNALS_F32_3 = 2606,
            DEBUG_SIGNALS_F32_4 = 2607,
            DEBUG_SIGNALS_F32_5 = 2608,
            DEBUG_SIGNALS_F32_6 = 2609,
            DEBUG_SIGNALS_F32_7 = 2610,
            DEBUG_SIGNALS_F32_8 = 2611,
            DEBUG_SIGNALS_F32_9 = 2612,
            DEBUG_SIGNALS_F32_10 = 2613,
            DEBUG_SIGNALS_F32_11 = 2614,
            DEBUG_SIGNALS_F32_12 = 2615,
            DEBUG_SIGNALS_F32_13 = 2616,
            DEBUG_SIGNALS_F32_14 = 2617,
            DEBUG_SIGNALS_F32_15 = 2618,
            DEBUG_SIGNALS_F32_16 = 2619,
            DEBUG_SIGNALS_F32_17 = 2620,
            DEBUG_SIGNALS_F32_18 = 2621,
            DEBUG_SIGNALS_F32_19 = 2622,
            DEBUG_SIGNALS_F32_20 = 2623,
            DEBUG_SIGNALS_F32_21 = 2624,
            DEBUG_SIGNALS_F32_22 = 2625,
            DEBUG_SIGNALS_F32_23 = 2626,
            DEBUG_SIGNALS_F32_24 = 2627,
            DEBUG_SIGNALS_F32_25 = 2628,
            DEBUG_SIGNALS_F32_26 = 2629,
            DEBUG_SIGNALS_F32_27 = 2630,
            DEBUG_SIGNALS_F32_28 = 2631,
            DEBUG_SIGNALS_F32_29 = 2632,
            DEBUG_SIGNALS_F32_30 = 2633,
            DEBUG_SIGNALS_F32_31 = 2634,
            DEBUG_SIGNALS_F32_32 = 2635,
            DEBUG_SIGNALS_F32_33 = 2636,
            DEBUG_SIGNALS_F32_34 = 2637,
            DEBUG_SIGNALS_F32_35 = 2638,
            DEBUG_SIGNALS_F32_36 = 2639,
            DEBUG_SIGNALS_F32_37 = 2640,
            DEBUG_SIGNALS_F32_38 = 2641,
            DEBUG_SIGNALS_F32_39 = 2642,
            DEBUG_SIGNALS_F32_40 = 2643,
            DEBUG_SIGNALS_F32_41 = 2644,
            DEBUG_SIGNALS_F32_42 = 2645,
            DEBUG_SIGNALS_F32_43 = 2646,
            DEBUG_SIGNALS_F32_44 = 2647,
            DEBUG_SIGNALS_F32_45 = 2648,
            DEBUG_SIGNALS_F32_46 = 2649,
            DEBUG_SIGNALS_F32_47 = 2650,
            DEBUG_SIGNALS_F32_48 = 2651,
            DEBUG_SIGNALS_F32_49 = 2652,
            DEBUG_SIGNALS_U32_0 = 2653,
            DEBUG_SIGNALS_U32_1 = 2654,
            DEBUG_SIGNALS_U32_2 = 2655,
            DEBUG_SIGNALS_U32_3 = 2656,
            DEBUG_SIGNALS_U32_4 = 2657,
            DEBUG_SIGNALS_U32_5 = 2658,
            DEBUG_SIGNALS_U32_6 = 2659,
            DEBUG_SIGNALS_U32_7 = 2660,
            DEBUG_SIGNALS_U32_8 = 2661,
            DEBUG_SIGNALS_U32_9 = 2662,
            DEBUG_SIGNALS_U32_10 = 2663,
            DEBUG_SIGNALS_U32_11 = 2664,
            DEBUG_SIGNALS_U32_12 = 2665,
            DEBUG_SIGNALS_U32_13 = 2666,
            DEBUG_SIGNALS_U32_14 = 2667,
            DEBUG_SIGNALS_U32_15 = 2668,
            DEBUG_SIGNALS_U32_16 = 2669,
            DEBUG_SIGNALS_U32_17 = 2670,
            DEBUG_SIGNALS_U32_18 = 2671,
            DEBUG_SIGNALS_U32_19 = 2672,
            DEBUG_SIGNALS_U32_20 = 2673,
            DEBUG_SIGNALS_U32_21 = 2674,
            DEBUG_SIGNALS_U32_22 = 2675,
            DEBUG_SIGNALS_U32_23 = 2676,
            DEBUG_SIGNALS_U32_24 = 2677,
            DEBUG_SIGNALS_U32_25 = 2678,
            DEBUG_SIGNALS_U32_26 = 2679,
            DEBUG_SIGNALS_U32_27 = 2680,
            DEBUG_SIGNALS_U32_28 = 2681,
            DEBUG_SIGNALS_U32_29 = 2682,
            DEBUG_SIGNALS_U32_30 = 2683,
            DEBUG_SIGNALS_U32_31 = 2684,
            DEBUG_SIGNALS_U32_32 = 2685,
            DEBUG_SIGNALS_U32_33 = 2686,
            DEBUG_SIGNALS_U32_34 = 2687,
            DEBUG_SIGNALS_U32_35 = 2688,
            DEBUG_SIGNALS_U32_36 = 2689,
            DEBUG_SIGNALS_U32_37 = 2690,
            DEBUG_SIGNALS_U32_38 = 2691,
            DEBUG_SIGNALS_U32_39 = 2692,
            DEBUG_SIGNALS_U32_40 = 2693,
            DEBUG_SIGNALS_U32_41 = 2694,
            DEBUG_SIGNALS_U32_42 = 2695,
            DEBUG_SIGNALS_U32_43 = 2696,
            DEBUG_SIGNALS_U32_44 = 2697,
            DEBUG_SIGNALS_U32_45 = 2698,
            DEBUG_SIGNALS_U32_46 = 2699,
            DEBUG_SIGNALS_U32_47 = 2700,
            DEBUG_SIGNALS_U32_48 = 2701,
            DEBUG_SIGNALS_U32_49 = 2702,
            DEBUG_SIGNALS_I32_0 = 2703,
            DEBUG_SIGNALS_I32_1 = 2704,
            DEBUG_SIGNALS_I32_2 = 2705,
            DEBUG_SIGNALS_I32_3 = 2706,
            DEBUG_SIGNALS_I32_4 = 2707,
            DEBUG_SIGNALS_I32_5 = 2708,
            DEBUG_SIGNALS_I32_6 = 2709,
            DEBUG_SIGNALS_I32_7 = 2710,
            DEBUG_SIGNALS_I32_8 = 2711,
            DEBUG_SIGNALS_I32_9 = 2712,
            DEBUG_SIGNALS_I32_10 = 2713,
            DEBUG_SIGNALS_I32_11 = 2714,
            DEBUG_SIGNALS_I32_12 = 2715,
            DEBUG_SIGNALS_I32_13 = 2716,
            DEBUG_SIGNALS_I32_14 = 2717,
            DEBUG_SIGNALS_I32_15 = 2718,
            DEBUG_SIGNALS_I32_16 = 2719,
            DEBUG_SIGNALS_I32_17 = 2720,
            DEBUG_SIGNALS_I32_18 = 2721,
            DEBUG_SIGNALS_I32_19 = 2722,
            DEBUG_SIGNALS_I32_20 = 2723,
            DEBUG_SIGNALS_I32_21 = 2724,
            DEBUG_SIGNALS_I32_22 = 2725,
            DEBUG_SIGNALS_I32_23 = 2726,
            DEBUG_SIGNALS_I32_24 = 2727,
            DEBUG_SIGNALS_I32_25 = 2728,
            DEBUG_SIGNALS_I32_26 = 2729,
            DEBUG_SIGNALS_I32_27 = 2730,
            DEBUG_SIGNALS_I32_28 = 2731,
            DEBUG_SIGNALS_I32_29 = 2732,
            DEBUG_SIGNALS_I32_30 = 2733,
            DEBUG_SIGNALS_I32_31 = 2734,
            DEBUG_SIGNALS_I32_32 = 2735,
            DEBUG_SIGNALS_I32_33 = 2736,
            DEBUG_SIGNALS_I32_34 = 2737,
            DEBUG_SIGNALS_I32_35 = 2738,
            DEBUG_SIGNALS_I32_36 = 2739,
            DEBUG_SIGNALS_I32_37 = 2740,
            DEBUG_SIGNALS_I32_38 = 2741,
            DEBUG_SIGNALS_I32_39 = 2742,
            DEBUG_SIGNALS_I32_40 = 2743,
            DEBUG_SIGNALS_I32_41 = 2744,
            DEBUG_SIGNALS_I32_42 = 2745,
            DEBUG_SIGNALS_I32_43 = 2746,
            DEBUG_SIGNALS_I32_44 = 2747,
            DEBUG_SIGNALS_I32_45 = 2748,
            DEBUG_SIGNALS_I32_46 = 2749,
            DEBUG_SIGNALS_I32_47 = 2750,
            DEBUG_SIGNALS_I32_48 = 2751,
            DEBUG_SIGNALS_I32_49 = 2752,
            DEBUG_SIGNALS_U16_0 = 2753,
            DEBUG_SIGNALS_U16_1 = 2754,
            DEBUG_SIGNALS_U16_2 = 2755,
            DEBUG_SIGNALS_U16_3 = 2756,
            DEBUG_SIGNALS_U16_4 = 2757,
            DEBUG_SIGNALS_U16_5 = 2758,
            DEBUG_SIGNALS_U16_6 = 2759,
            DEBUG_SIGNALS_U16_7 = 2760,
            DEBUG_SIGNALS_U16_8 = 2761,
            DEBUG_SIGNALS_U16_9 = 2762,
            DEBUG_SIGNALS_U16_10 = 2763,
            DEBUG_SIGNALS_U16_11 = 2764,
            DEBUG_SIGNALS_U16_12 = 2765,
            DEBUG_SIGNALS_U16_13 = 2766,
            DEBUG_SIGNALS_U16_14 = 2767,
            DEBUG_SIGNALS_U16_15 = 2768,
            DEBUG_SIGNALS_U16_16 = 2769,
            DEBUG_SIGNALS_U16_17 = 2770,
            DEBUG_SIGNALS_U16_18 = 2771,
            DEBUG_SIGNALS_U16_19 = 2772,
            DEBUG_SIGNALS_U16_20 = 2773,
            DEBUG_SIGNALS_U16_21 = 2774,
            DEBUG_SIGNALS_U16_22 = 2775,
            DEBUG_SIGNALS_U16_23 = 2776,
            DEBUG_SIGNALS_U16_24 = 2777,
            DEBUG_SIGNALS_U16_25 = 2778,
            DEBUG_SIGNALS_U16_26 = 2779,
            DEBUG_SIGNALS_U16_27 = 2780,
            DEBUG_SIGNALS_U16_28 = 2781,
            DEBUG_SIGNALS_U16_29 = 2782,
            DEBUG_SIGNALS_U16_30 = 2783,
            DEBUG_SIGNALS_U16_31 = 2784,
            DEBUG_SIGNALS_U16_32 = 2785,
            DEBUG_SIGNALS_U16_33 = 2786,
            DEBUG_SIGNALS_U16_34 = 2787,
            DEBUG_SIGNALS_U16_35 = 2788,
            DEBUG_SIGNALS_U16_36 = 2789,
            DEBUG_SIGNALS_U16_37 = 2790,
            DEBUG_SIGNALS_U16_38 = 2791,
            DEBUG_SIGNALS_U16_39 = 2792,
            DEBUG_SIGNALS_U16_40 = 2793,
            DEBUG_SIGNALS_U16_41 = 2794,
            DEBUG_SIGNALS_U16_42 = 2795,
            DEBUG_SIGNALS_U16_43 = 2796,
            DEBUG_SIGNALS_U16_44 = 2797,
            DEBUG_SIGNALS_U16_45 = 2798,
            DEBUG_SIGNALS_U16_46 = 2799,
            DEBUG_SIGNALS_U16_47 = 2800,
            DEBUG_SIGNALS_U16_48 = 2801,
            DEBUG_SIGNALS_U16_49 = 2802,
            DEBUG_SIGNALS_I16_0 = 2803,
            DEBUG_SIGNALS_I16_1 = 2804,
            DEBUG_SIGNALS_I16_2 = 2805,
            DEBUG_SIGNALS_I16_3 = 2806,
            DEBUG_SIGNALS_I16_4 = 2807,
            DEBUG_SIGNALS_I16_5 = 2808,
            DEBUG_SIGNALS_I16_6 = 2809,
            DEBUG_SIGNALS_I16_7 = 2810,
            DEBUG_SIGNALS_I16_8 = 2811,
            DEBUG_SIGNALS_I16_9 = 2812,
            DEBUG_SIGNALS_I16_10 = 2813,
            DEBUG_SIGNALS_I16_11 = 2814,
            DEBUG_SIGNALS_I16_12 = 2815,
            DEBUG_SIGNALS_I16_13 = 2816,
            DEBUG_SIGNALS_I16_14 = 2817,
            DEBUG_SIGNALS_I16_15 = 2818,
            DEBUG_SIGNALS_I16_16 = 2819,
            DEBUG_SIGNALS_I16_17 = 2820,
            DEBUG_SIGNALS_I16_18 = 2821,
            DEBUG_SIGNALS_I16_19 = 2822,
            DEBUG_SIGNALS_I16_20 = 2823,
            DEBUG_SIGNALS_I16_21 = 2824,
            DEBUG_SIGNALS_I16_22 = 2825,
            DEBUG_SIGNALS_I16_23 = 2826,
            DEBUG_SIGNALS_I16_24 = 2827,
            DEBUG_SIGNALS_I16_25 = 2828,
            DEBUG_SIGNALS_I16_26 = 2829,
            DEBUG_SIGNALS_I16_27 = 2830,
            DEBUG_SIGNALS_I16_28 = 2831,
            DEBUG_SIGNALS_I16_29 = 2832,
            DEBUG_SIGNALS_I16_30 = 2833,
            DEBUG_SIGNALS_I16_31 = 2834,
            DEBUG_SIGNALS_I16_32 = 2835,
            DEBUG_SIGNALS_I16_33 = 2836,
            DEBUG_SIGNALS_I16_34 = 2837,
            DEBUG_SIGNALS_I16_35 = 2838,
            DEBUG_SIGNALS_I16_36 = 2839,
            DEBUG_SIGNALS_I16_37 = 2840,
            DEBUG_SIGNALS_I16_38 = 2841,
            DEBUG_SIGNALS_I16_39 = 2842,
            DEBUG_SIGNALS_I16_40 = 2843,
            DEBUG_SIGNALS_I16_41 = 2844,
            DEBUG_SIGNALS_I16_42 = 2845,
            DEBUG_SIGNALS_I16_43 = 2846,
            DEBUG_SIGNALS_I16_44 = 2847,
            DEBUG_SIGNALS_I16_45 = 2848,
            DEBUG_SIGNALS_I16_46 = 2849,
            DEBUG_SIGNALS_I16_47 = 2850,
            DEBUG_SIGNALS_I16_48 = 2851,
            DEBUG_SIGNALS_I16_49 = 2852,
            DEBUG_CONTROL_SIGNALS_F64_0 = 2853,
            DEBUG_CONTROL_SIGNALS_F64_1 = 2854,
            DEBUG_CONTROL_SIGNALS_F64_2 = 2855,
            DEBUG_CONTROL_SIGNALS_F64_3 = 2856,
            DEBUG_CONTROL_SIGNALS_F64_4 = 2857,
            DEBUG_CONTROL_SIGNALS_F64_5 = 2858,
            DEBUG_CONTROL_SIGNALS_F64_6 = 2859,
            DEBUG_CONTROL_SIGNALS_F64_7 = 2860,
            DEBUG_CONTROL_SIGNALS_F64_8 = 2861,
            DEBUG_CONTROL_SIGNALS_F64_9 = 2862,
            DEBUG_CONTROL_SIGNALS_F64_10 = 2863,
            DEBUG_CONTROL_SIGNALS_F64_11 = 2864,
            DEBUG_CONTROL_SIGNALS_F64_12 = 2865,
            DEBUG_CONTROL_SIGNALS_F64_13 = 2866,
            DEBUG_CONTROL_SIGNALS_F64_14 = 2867,
            DEBUG_CONTROL_SIGNALS_F64_15 = 2868,
            DEBUG_CONTROL_SIGNALS_F64_16 = 2869,
            DEBUG_CONTROL_SIGNALS_F64_17 = 2870,
            DEBUG_CONTROL_SIGNALS_F64_18 = 2871,
            DEBUG_CONTROL_SIGNALS_F64_19 = 2872,
            DEBUG_CONTROL_SIGNALS_F64_20 = 2873,
            DEBUG_CONTROL_SIGNALS_F64_21 = 2874,
            DEBUG_CONTROL_SIGNALS_F64_22 = 2875,
            DEBUG_CONTROL_SIGNALS_F64_23 = 2876,
            DEBUG_CONTROL_SIGNALS_F64_24 = 2877,
            DEBUG_CONTROL_SIGNALS_F64_25 = 2878,
            DEBUG_CONTROL_SIGNALS_F64_26 = 2879,
            DEBUG_CONTROL_SIGNALS_F64_27 = 2880,
            DEBUG_CONTROL_SIGNALS_F64_28 = 2881,
            DEBUG_CONTROL_SIGNALS_F64_29 = 2882,
            DEBUG_CONTROL_SIGNALS_F64_30 = 2883,
            DEBUG_CONTROL_SIGNALS_F64_31 = 2884,
            DEBUG_CONTROL_SIGNALS_F64_32 = 2885,
            DEBUG_CONTROL_SIGNALS_F64_33 = 2886,
            DEBUG_CONTROL_SIGNALS_F64_34 = 2887,
            DEBUG_CONTROL_SIGNALS_F64_35 = 2888,
            DEBUG_CONTROL_SIGNALS_F64_36 = 2889,
            DEBUG_CONTROL_SIGNALS_F64_37 = 2890,
            DEBUG_CONTROL_SIGNALS_F64_38 = 2891,
            DEBUG_CONTROL_SIGNALS_F64_39 = 2892,
            DEBUG_CONTROL_SIGNALS_F64_40 = 2893,
            DEBUG_CONTROL_SIGNALS_F64_41 = 2894,
            DEBUG_CONTROL_SIGNALS_F64_42 = 2895,
            DEBUG_CONTROL_SIGNALS_F64_43 = 2896,
            DEBUG_CONTROL_SIGNALS_F64_44 = 2897,
            DEBUG_CONTROL_SIGNALS_F64_45 = 2898,
            DEBUG_CONTROL_SIGNALS_F64_46 = 2899,
            DEBUG_CONTROL_SIGNALS_F64_47 = 2900,
            DEBUG_CONTROL_SIGNALS_F64_48 = 2901,
            DEBUG_CONTROL_SIGNALS_F64_49 = 2902,
            DEBUG_CONTROL_SIGNALS_F32_0 = 2903,
            DEBUG_CONTROL_SIGNALS_F32_1 = 2904,
            DEBUG_CONTROL_SIGNALS_F32_2 = 2905,
            DEBUG_CONTROL_SIGNALS_F32_3 = 2906,
            DEBUG_CONTROL_SIGNALS_F32_4 = 2907,
            DEBUG_CONTROL_SIGNALS_F32_5 = 2908,
            DEBUG_CONTROL_SIGNALS_F32_6 = 2909,
            DEBUG_CONTROL_SIGNALS_F32_7 = 2910,
            DEBUG_CONTROL_SIGNALS_F32_8 = 2911,
            DEBUG_CONTROL_SIGNALS_F32_9 = 2912,
            DEBUG_CONTROL_SIGNALS_F32_10 = 2913,
            DEBUG_CONTROL_SIGNALS_F32_11 = 2914,
            DEBUG_CONTROL_SIGNALS_F32_12 = 2915,
            DEBUG_CONTROL_SIGNALS_F32_13 = 2916,
            DEBUG_CONTROL_SIGNALS_F32_14 = 2917,
            DEBUG_CONTROL_SIGNALS_F32_15 = 2918,
            DEBUG_CONTROL_SIGNALS_F32_16 = 2919,
            DEBUG_CONTROL_SIGNALS_F32_17 = 2920,
            DEBUG_CONTROL_SIGNALS_F32_18 = 2921,
            DEBUG_CONTROL_SIGNALS_F32_19 = 2922,
            DEBUG_CONTROL_SIGNALS_F32_20 = 2923,
            DEBUG_CONTROL_SIGNALS_F32_21 = 2924,
            DEBUG_CONTROL_SIGNALS_F32_22 = 2925,
            DEBUG_CONTROL_SIGNALS_F32_23 = 2926,
            DEBUG_CONTROL_SIGNALS_F32_24 = 2927,
            DEBUG_CONTROL_SIGNALS_F32_25 = 2928,
            DEBUG_CONTROL_SIGNALS_F32_26 = 2929,
            DEBUG_CONTROL_SIGNALS_F32_27 = 2930,
            DEBUG_CONTROL_SIGNALS_F32_28 = 2931,
            DEBUG_CONTROL_SIGNALS_F32_29 = 2932,
            DEBUG_CONTROL_SIGNALS_F32_30 = 2933,
            DEBUG_CONTROL_SIGNALS_F32_31 = 2934,
            DEBUG_CONTROL_SIGNALS_F32_32 = 2935,
            DEBUG_CONTROL_SIGNALS_F32_33 = 2936,
            DEBUG_CONTROL_SIGNALS_F32_34 = 2937,
            DEBUG_CONTROL_SIGNALS_F32_35 = 2938,
            DEBUG_CONTROL_SIGNALS_F32_36 = 2939,
            DEBUG_CONTROL_SIGNALS_F32_37 = 2940,
            DEBUG_CONTROL_SIGNALS_F32_38 = 2941,
            DEBUG_CONTROL_SIGNALS_F32_39 = 2942,
            DEBUG_CONTROL_SIGNALS_F32_40 = 2943,
            DEBUG_CONTROL_SIGNALS_F32_41 = 2944,
            DEBUG_CONTROL_SIGNALS_F32_42 = 2945,
            DEBUG_CONTROL_SIGNALS_F32_43 = 2946,
            DEBUG_CONTROL_SIGNALS_F32_44 = 2947,
            DEBUG_CONTROL_SIGNALS_F32_45 = 2948,
            DEBUG_CONTROL_SIGNALS_F32_46 = 2949,
            DEBUG_CONTROL_SIGNALS_F32_47 = 2950,
            DEBUG_CONTROL_SIGNALS_F32_48 = 2951,
            DEBUG_CONTROL_SIGNALS_F32_49 = 2952,
            DEBUG_CONTROL_SIGNALS_U32_0 = 2953,
            DEBUG_CONTROL_SIGNALS_U32_1 = 2954,
            DEBUG_CONTROL_SIGNALS_U32_2 = 2955,
            DEBUG_CONTROL_SIGNALS_U32_3 = 2956,
            DEBUG_CONTROL_SIGNALS_U32_4 = 2957,
            DEBUG_CONTROL_SIGNALS_U32_5 = 2958,
            DEBUG_CONTROL_SIGNALS_U32_6 = 2959,
            DEBUG_CONTROL_SIGNALS_U32_7 = 2960,
            DEBUG_CONTROL_SIGNALS_U32_8 = 2961,
            DEBUG_CONTROL_SIGNALS_U32_9 = 2962,
            DEBUG_CONTROL_SIGNALS_U32_10 = 2963,
            DEBUG_CONTROL_SIGNALS_U32_11 = 2964,
            DEBUG_CONTROL_SIGNALS_U32_12 = 2965,
            DEBUG_CONTROL_SIGNALS_U32_13 = 2966,
            DEBUG_CONTROL_SIGNALS_U32_14 = 2967,
            DEBUG_CONTROL_SIGNALS_U32_15 = 2968,
            DEBUG_CONTROL_SIGNALS_U32_16 = 2969,
            DEBUG_CONTROL_SIGNALS_U32_17 = 2970,
            DEBUG_CONTROL_SIGNALS_U32_18 = 2971,
            DEBUG_CONTROL_SIGNALS_U32_19 = 2972,
            DEBUG_CONTROL_SIGNALS_U32_20 = 2973,
            DEBUG_CONTROL_SIGNALS_U32_21 = 2974,
            DEBUG_CONTROL_SIGNALS_U32_22 = 2975,
            DEBUG_CONTROL_SIGNALS_U32_23 = 2976,
            DEBUG_CONTROL_SIGNALS_U32_24 = 2977,
            DEBUG_CONTROL_SIGNALS_U32_25 = 2978,
            DEBUG_CONTROL_SIGNALS_U32_26 = 2979,
            DEBUG_CONTROL_SIGNALS_U32_27 = 2980,
            DEBUG_CONTROL_SIGNALS_U32_28 = 2981,
            DEBUG_CONTROL_SIGNALS_U32_29 = 2982,
            DEBUG_CONTROL_SIGNALS_U32_30 = 2983,
            DEBUG_CONTROL_SIGNALS_U32_31 = 2984,
            DEBUG_CONTROL_SIGNALS_U32_32 = 2985,
            DEBUG_CONTROL_SIGNALS_U32_33 = 2986,
            DEBUG_CONTROL_SIGNALS_U32_34 = 2987,
            DEBUG_CONTROL_SIGNALS_U32_35 = 2988,
            DEBUG_CONTROL_SIGNALS_U32_36 = 2989,
            DEBUG_CONTROL_SIGNALS_U32_37 = 2990,
            DEBUG_CONTROL_SIGNALS_U32_38 = 2991,
            DEBUG_CONTROL_SIGNALS_U32_39 = 2992,
            DEBUG_CONTROL_SIGNALS_U32_40 = 2993,
            DEBUG_CONTROL_SIGNALS_U32_41 = 2994,
            DEBUG_CONTROL_SIGNALS_U32_42 = 2995,
            DEBUG_CONTROL_SIGNALS_U32_43 = 2996,
            DEBUG_CONTROL_SIGNALS_U32_44 = 2997,
            DEBUG_CONTROL_SIGNALS_U32_45 = 2998,
            DEBUG_CONTROL_SIGNALS_U32_46 = 2999,
            DEBUG_CONTROL_SIGNALS_U32_47 = 3000,
            DEBUG_CONTROL_SIGNALS_U32_48 = 3001,
            DEBUG_CONTROL_SIGNALS_U32_49 = 3002,
            DEBUG_CONTROL_SIGNALS_I32_0 = 3003,
            DEBUG_CONTROL_SIGNALS_I32_1 = 3004,
            DEBUG_CONTROL_SIGNALS_I32_2 = 3005,
            DEBUG_CONTROL_SIGNALS_I32_3 = 3006,
            DEBUG_CONTROL_SIGNALS_I32_4 = 3007,
            DEBUG_CONTROL_SIGNALS_I32_5 = 3008,
            DEBUG_CONTROL_SIGNALS_I32_6 = 3009,
            DEBUG_CONTROL_SIGNALS_I32_7 = 3010,
            DEBUG_CONTROL_SIGNALS_I32_8 = 3011,
            DEBUG_CONTROL_SIGNALS_I32_9 = 3012,
            DEBUG_CONTROL_SIGNALS_I32_10 = 3013,
            DEBUG_CONTROL_SIGNALS_I32_11 = 3014,
            DEBUG_CONTROL_SIGNALS_I32_12 = 3015,
            DEBUG_CONTROL_SIGNALS_I32_13 = 3016,
            DEBUG_CONTROL_SIGNALS_I32_14 = 3017,
            DEBUG_CONTROL_SIGNALS_I32_15 = 3018,
            DEBUG_CONTROL_SIGNALS_I32_16 = 3019,
            DEBUG_CONTROL_SIGNALS_I32_17 = 3020,
            DEBUG_CONTROL_SIGNALS_I32_18 = 3021,
            DEBUG_CONTROL_SIGNALS_I32_19 = 3022,
            DEBUG_CONTROL_SIGNALS_I32_20 = 3023,
            DEBUG_CONTROL_SIGNALS_I32_21 = 3024,
            DEBUG_CONTROL_SIGNALS_I32_22 = 3025,
            DEBUG_CONTROL_SIGNALS_I32_23 = 3026,
            DEBUG_CONTROL_SIGNALS_I32_24 = 3027,
            DEBUG_CONTROL_SIGNALS_I32_25 = 3028,
            DEBUG_CONTROL_SIGNALS_I32_26 = 3029,
            DEBUG_CONTROL_SIGNALS_I32_27 = 3030,
            DEBUG_CONTROL_SIGNALS_I32_28 = 3031,
            DEBUG_CONTROL_SIGNALS_I32_29 = 3032,
            DEBUG_CONTROL_SIGNALS_I32_30 = 3033,
            DEBUG_CONTROL_SIGNALS_I32_31 = 3034,
            DEBUG_CONTROL_SIGNALS_I32_32 = 3035,
            DEBUG_CONTROL_SIGNALS_I32_33 = 3036,
            DEBUG_CONTROL_SIGNALS_I32_34 = 3037,
            DEBUG_CONTROL_SIGNALS_I32_35 = 3038,
            DEBUG_CONTROL_SIGNALS_I32_36 = 3039,
            DEBUG_CONTROL_SIGNALS_I32_37 = 3040,
            DEBUG_CONTROL_SIGNALS_I32_38 = 3041,
            DEBUG_CONTROL_SIGNALS_I32_39 = 3042,
            DEBUG_CONTROL_SIGNALS_I32_40 = 3043,
            DEBUG_CONTROL_SIGNALS_I32_41 = 3044,
            DEBUG_CONTROL_SIGNALS_I32_42 = 3045,
            DEBUG_CONTROL_SIGNALS_I32_43 = 3046,
            DEBUG_CONTROL_SIGNALS_I32_44 = 3047,
            DEBUG_CONTROL_SIGNALS_I32_45 = 3048,
            DEBUG_CONTROL_SIGNALS_I32_46 = 3049,
            DEBUG_CONTROL_SIGNALS_I32_47 = 3050,
            DEBUG_CONTROL_SIGNALS_I32_48 = 3051,
            DEBUG_CONTROL_SIGNALS_I32_49 = 3052,
            DEBUG_CONTROL_SIGNALS_U16_0 = 3053,
            DEBUG_CONTROL_SIGNALS_U16_1 = 3054,
            DEBUG_CONTROL_SIGNALS_U16_2 = 3055,
            DEBUG_CONTROL_SIGNALS_U16_3 = 3056,
            DEBUG_CONTROL_SIGNALS_U16_4 = 3057,
            DEBUG_CONTROL_SIGNALS_U16_5 = 3058,
            DEBUG_CONTROL_SIGNALS_U16_6 = 3059,
            DEBUG_CONTROL_SIGNALS_U16_7 = 3060,
            DEBUG_CONTROL_SIGNALS_U16_8 = 3061,
            DEBUG_CONTROL_SIGNALS_U16_9 = 3062,
            DEBUG_CONTROL_SIGNALS_U16_10 = 3063,
            DEBUG_CONTROL_SIGNALS_U16_11 = 3064,
            DEBUG_CONTROL_SIGNALS_U16_12 = 3065,
            DEBUG_CONTROL_SIGNALS_U16_13 = 3066,
            DEBUG_CONTROL_SIGNALS_U16_14 = 3067,
            DEBUG_CONTROL_SIGNALS_U16_15 = 3068,
            DEBUG_CONTROL_SIGNALS_U16_16 = 3069,
            DEBUG_CONTROL_SIGNALS_U16_17 = 3070,
            DEBUG_CONTROL_SIGNALS_U16_18 = 3071,
            DEBUG_CONTROL_SIGNALS_U16_19 = 3072,
            DEBUG_CONTROL_SIGNALS_U16_20 = 3073,
            DEBUG_CONTROL_SIGNALS_U16_21 = 3074,
            DEBUG_CONTROL_SIGNALS_U16_22 = 3075,
            DEBUG_CONTROL_SIGNALS_U16_23 = 3076,
            DEBUG_CONTROL_SIGNALS_U16_24 = 3077,
            DEBUG_CONTROL_SIGNALS_U16_25 = 3078,
            DEBUG_CONTROL_SIGNALS_U16_26 = 3079,
            DEBUG_CONTROL_SIGNALS_U16_27 = 3080,
            DEBUG_CONTROL_SIGNALS_U16_28 = 3081,
            DEBUG_CONTROL_SIGNALS_U16_29 = 3082,
            DEBUG_CONTROL_SIGNALS_U16_30 = 3083,
            DEBUG_CONTROL_SIGNALS_U16_31 = 3084,
            DEBUG_CONTROL_SIGNALS_U16_32 = 3085,
            DEBUG_CONTROL_SIGNALS_U16_33 = 3086,
            DEBUG_CONTROL_SIGNALS_U16_34 = 3087,
            DEBUG_CONTROL_SIGNALS_U16_35 = 3088,
            DEBUG_CONTROL_SIGNALS_U16_36 = 3089,
            DEBUG_CONTROL_SIGNALS_U16_37 = 3090,
            DEBUG_CONTROL_SIGNALS_U16_38 = 3091,
            DEBUG_CONTROL_SIGNALS_U16_39 = 3092,
            DEBUG_CONTROL_SIGNALS_U16_40 = 3093,
            DEBUG_CONTROL_SIGNALS_U16_41 = 3094,
            DEBUG_CONTROL_SIGNALS_U16_42 = 3095,
            DEBUG_CONTROL_SIGNALS_U16_43 = 3096,
            DEBUG_CONTROL_SIGNALS_U16_44 = 3097,
            DEBUG_CONTROL_SIGNALS_U16_45 = 3098,
            DEBUG_CONTROL_SIGNALS_U16_46 = 3099,
            DEBUG_CONTROL_SIGNALS_U16_47 = 3100,
            DEBUG_CONTROL_SIGNALS_U16_48 = 3101,
            DEBUG_CONTROL_SIGNALS_U16_49 = 3102,
            ZUPTUSE = 3103,
            GNSSUSE = 3104,
            AIR_DATA_ALL_USE = 3105,
            AIR_DATA_SPEED_USE = 3106,
            AIR_DATA_ALTITUDE_USE = 3107,
            VISION_USE = 3108,
            MAG_USE = 3109,
            ALGORITHM_RESET = 3110,
            FLIGHT_ZERO = 3111,
            ARM = 3112,
            ALGORITHM_TYPE = 3113,
            GNSSTYPE = 3114,
            HEAD_TYPE = 3115,
            ALIGN_TYPE = 3116,
            NSENSOR = 3117,
            INIT_IDLE_TIME = 3118,
            INIT_LLA_RRM_0 = 3119,
            INIT_LLA_RRM_1 = 3120,
            INIT_LLA_RRM_2 = 3121,
            INIT_HEAD_RAD = 3122,
            ALIGN_TIME_S = 3123,
            REL_AZ_RAD = 3124,
            SPEED0_MPS = 3125,
            EULER0_RAD_0 = 3126,
            EULER0_RAD_1 = 3127,
            EULER0_RAD_2 = 3128,
            RUN_TIME_S = 3129,
            CURRENT_STATE = 3130,
            OBS_TYPE = 3131,
            CARRIER_TYPE = 3132,
            CONTROL_FLAGS_BITS_SUMMARY = 3133,
            ALIGN_COUNTER = 3134,
            ALIGN_ACC_AVERAGE_0 = 3135,
            ALIGN_ACC_AVERAGE_1 = 3136,
            ALIGN_ACC_AVERAGE_2 = 3137,
            ALIGN_GYR_AVERAGE_0 = 3138,
            ALIGN_GYR_AVERAGE_1 = 3139,
            ALIGN_GYR_AVERAGE_2 = 3140,
            ALIGN_EULER0_0 = 3141,
            ALIGN_EULER0_1 = 3142,
            ALIGN_EULER0_2 = 3143,
            ALIGN_QUAT0_0 = 3144,
            ALIGN_QUAT0_1 = 3145,
            ALIGN_QUAT0_2 = 3146,
            ALIGN_QUAT0_3 = 3147,
            ALIGN_GYR_NORM0 = 3148,
            ALIGN_ACC_NORM0 = 3149,
            ALIGN_GYR_ERR0_0 = 3150,
            ALIGN_GYR_ERR0_1 = 3151,
            ALIGN_GYR_ERR0_2 = 3152,
            NAV_COUNTER = 3153,
            NAV_QUAT_0 = 3154,
            NAV_QUAT_1 = 3155,
            NAV_QUAT_2 = 3156,
            NAV_QUAT_3 = 3157,
            NAV_EULER_0 = 3158,
            NAV_EULER_1 = 3159,
            NAV_EULER_2 = 3160,
            NAV_V_NED_0 = 3161,
            NAV_V_NED_1 = 3162,
            NAV_V_NED_2 = 3163,
            NAV_LLA_0 = 3164,
            NAV_LLA_1 = 3165,
            NAV_LLA_2 = 3166,
            NAV_R_NED_0 = 3167,
            NAV_R_NED_1 = 3168,
            NAV_R_NED_2 = 3169,
            FUS_COUNTER = 3170,
            FUS_EULER_0 = 3171,
            FUS_EULER_1 = 3172,
            FUS_EULER_2 = 3173,
            FUS_QUAT_0 = 3174,
            FUS_QUAT_1 = 3175,
            FUS_QUAT_2 = 3176,
            FUS_QUAT_3 = 3177,
            FUS_V_NED_0 = 3178,
            FUS_V_NED_1 = 3179,
            FUS_V_NED_2 = 3180,
            FUS_LLA_0 = 3181,
            FUS_LLA_1 = 3182,
            FUS_LLA_2 = 3183,
            FUS_BA_0 = 3184,
            FUS_BA_1 = 3185,
            FUS_BA_2 = 3186,
            FUS_BG_0 = 3187,
            FUS_BG_1 = 3188,
            FUS_BG_2 = 3189,
            FUS_PSI_CC_0 = 3190,
            FUS_PSI_CC_1 = 3191,
            FUS_PSI_CC_2 = 3192,
            FUS_RESET_CNT = 3193,
            QUAT_0 = 3194,
            QUAT_1 = 3195,
            QUAT_2 = 3196,
            QUAT_3 = 3197,
            EULER_0 = 3198,
            EULER_1 = 3199,
            EULER_2 = 3200,
            OUTPUT_COUNTER = 3201,
            OUTPUT_BOOT_TIME_MS = 3202,
            CHIP_STABILIZATION_CYCLE_QTY = 3203,
            OUTPUT_STABILIZATION_CYCLE_QTY = 3204,
            SEND_LOG_START = 3205,
            SEND_LOG_STOP = 3206,
            ERASE_ALL_LOGS = 3207,
            LOG_TIME_ELAPSED_S = 3208,
            TOTAL_SESSIONS_QTY = 3209,
            TOTAL_RECORDS_QTY = 3210,
            TOTAL_PAYLOADS_SIZE_BYTE = 3211,
            CURRENT_SESSION_RECORDS_QTY = 3212,
            CURRENT_SESSION_PAYLOADS_SIZE_BYTE = 3213,
            TOTAL_SESSIONS_CAPACITY = 3214,
            TOTAL_RECORDS_CAPACITY = 3215,
            TOTAL_PAYLOADS_CAPACITY_BYTE = 3216,
            SEND_LOG_REMAIN_RECORDS_QTY = 3217,
            SESSION_DATA_0_SESSION_ID = 3218,
            SESSION_DATA_0_RECORDS_OCCUPIED_QTY = 3219,
            SESSION_DATA_0_PAYLOADS_OCCUPIED_SIZE = 3220,
            SESSION_DATA_0_RECORDS_DURATION_US = 3221,
            SESSION_DATA_1_SESSION_ID = 3222,
            SESSION_DATA_1_RECORDS_OCCUPIED_QTY = 3223,
            SESSION_DATA_1_PAYLOADS_OCCUPIED_SIZE = 3224,
            SESSION_DATA_1_RECORDS_DURATION_US = 3225,
            SESSION_DATA_2_SESSION_ID = 3226,
            SESSION_DATA_2_RECORDS_OCCUPIED_QTY = 3227,
            SESSION_DATA_2_PAYLOADS_OCCUPIED_SIZE = 3228,
            SESSION_DATA_2_RECORDS_DURATION_US = 3229,
            SESSION_DATA_3_SESSION_ID = 3230,
            SESSION_DATA_3_RECORDS_OCCUPIED_QTY = 3231,
            SESSION_DATA_3_PAYLOADS_OCCUPIED_SIZE = 3232,
            SESSION_DATA_3_RECORDS_DURATION_US = 3233,
            SESSION_DATA_4_SESSION_ID = 3234,
            SESSION_DATA_4_RECORDS_OCCUPIED_QTY = 3235,
            SESSION_DATA_4_PAYLOADS_OCCUPIED_SIZE = 3236,
            SESSION_DATA_4_RECORDS_DURATION_US = 3237,
            SESSION_DATA_5_SESSION_ID = 3238,
            SESSION_DATA_5_RECORDS_OCCUPIED_QTY = 3239,
            SESSION_DATA_5_PAYLOADS_OCCUPIED_SIZE = 3240,
            SESSION_DATA_5_RECORDS_DURATION_US = 3241,
            SESSION_DATA_6_SESSION_ID = 3242,
            SESSION_DATA_6_RECORDS_OCCUPIED_QTY = 3243,
            SESSION_DATA_6_PAYLOADS_OCCUPIED_SIZE = 3244,
            SESSION_DATA_6_RECORDS_DURATION_US = 3245,
            SESSION_DATA_7_SESSION_ID = 3246,
            SESSION_DATA_7_RECORDS_OCCUPIED_QTY = 3247,
            SESSION_DATA_7_PAYLOADS_OCCUPIED_SIZE = 3248,
            SESSION_DATA_7_RECORDS_DURATION_US = 3249,
            SESSION_DATA_8_SESSION_ID = 3250,
            SESSION_DATA_8_RECORDS_OCCUPIED_QTY = 3251,
            SESSION_DATA_8_PAYLOADS_OCCUPIED_SIZE = 3252,
            SESSION_DATA_8_RECORDS_DURATION_US = 3253,
            SESSION_DATA_9_SESSION_ID = 3254,
            SESSION_DATA_9_RECORDS_OCCUPIED_QTY = 3255,
            SESSION_DATA_9_PAYLOADS_OCCUPIED_SIZE = 3256,
            SESSION_DATA_9_RECORDS_DURATION_US = 3257,
            SESSION_DATA_10_SESSION_ID = 3258,
            SESSION_DATA_10_RECORDS_OCCUPIED_QTY = 3259,
            SESSION_DATA_10_PAYLOADS_OCCUPIED_SIZE = 3260,
            SESSION_DATA_10_RECORDS_DURATION_US = 3261,
            SESSION_DATA_11_SESSION_ID = 3262,
            SESSION_DATA_11_RECORDS_OCCUPIED_QTY = 3263,
            SESSION_DATA_11_PAYLOADS_OCCUPIED_SIZE = 3264,
            SESSION_DATA_11_RECORDS_DURATION_US = 3265,
            SESSION_DATA_12_SESSION_ID = 3266,
            SESSION_DATA_12_RECORDS_OCCUPIED_QTY = 3267,
            SESSION_DATA_12_PAYLOADS_OCCUPIED_SIZE = 3268,
            SESSION_DATA_12_RECORDS_DURATION_US = 3269,
            SESSION_DATA_13_SESSION_ID = 3270,
            SESSION_DATA_13_RECORDS_OCCUPIED_QTY = 3271,
            SESSION_DATA_13_PAYLOADS_OCCUPIED_SIZE = 3272,
            SESSION_DATA_13_RECORDS_DURATION_US = 3273,
            SESSION_DATA_14_SESSION_ID = 3274,
            SESSION_DATA_14_RECORDS_OCCUPIED_QTY = 3275,
            SESSION_DATA_14_PAYLOADS_OCCUPIED_SIZE = 3276,
            SESSION_DATA_14_RECORDS_DURATION_US = 3277,
            SESSION_DATA_15_SESSION_ID = 3278,
            SESSION_DATA_15_RECORDS_OCCUPIED_QTY = 3279,
            SESSION_DATA_15_PAYLOADS_OCCUPIED_SIZE = 3280,
            SESSION_DATA_15_RECORDS_DURATION_US = 3281,
            SESSION_DATA_16_SESSION_ID = 3282,
            SESSION_DATA_16_RECORDS_OCCUPIED_QTY = 3283,
            SESSION_DATA_16_PAYLOADS_OCCUPIED_SIZE = 3284,
            SESSION_DATA_16_RECORDS_DURATION_US = 3285,
            SESSION_DATA_17_SESSION_ID = 3286,
            SESSION_DATA_17_RECORDS_OCCUPIED_QTY = 3287,
            SESSION_DATA_17_PAYLOADS_OCCUPIED_SIZE = 3288,
            SESSION_DATA_17_RECORDS_DURATION_US = 3289,
            SESSION_DATA_18_SESSION_ID = 3290,
            SESSION_DATA_18_RECORDS_OCCUPIED_QTY = 3291,
            SESSION_DATA_18_PAYLOADS_OCCUPIED_SIZE = 3292,
            SESSION_DATA_18_RECORDS_DURATION_US = 3293,
            SESSION_DATA_19_SESSION_ID = 3294,
            SESSION_DATA_19_RECORDS_OCCUPIED_QTY = 3295,
            SESSION_DATA_19_PAYLOADS_OCCUPIED_SIZE = 3296,
            SESSION_DATA_19_RECORDS_DURATION_US = 3297,
            GPS_M9N_BRIDGE_START_CMD = 3298,
            DADC_BRIDGE_START_CMD = 3299,
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
            PARAMETER_MB_ADDR_LOAD_BOARD = 208,
            PARAMETER_MB_ADDR_LOAD_RAPP_MAIN = 209,
            PARAMETER_MB_ADDR_LOAD_WITH_FORCE_ALL = 210,
            PARAMETER_MB_ADDR_LOAD_WITH_FORCE_INFO = 211,
            PARAMETER_MB_ADDR_LOAD_WITH_FORCE_MODBUS_EXT = 212,
            PARAMETER_MB_ADDR_LOAD_WITH_FORCE_BOARD = 213,
            PARAMETER_MB_ADDR_LOAD_WITH_FORCE_RAPP_MAIN = 214,
            PARAMETER_MB_ADDR_SAVE_ALL = 215,
            PARAMETER_MB_ADDR_SAVE_ALL_MEMORY_RESULT_0 = 216,
            PARAMETER_MB_ADDR_SAVE_ALL_MEMORY_RESULT_1 = 217,
            PARAMETER_MB_ADDR_SAVE_INFO = 218,
            PARAMETER_MB_ADDR_SAVE_MODBUS_EXT = 219,
            PARAMETER_MB_ADDR_SAVE_BOARD = 220,
            PARAMETER_MB_ADDR_SAVE_RAPP_MAIN = 221,
            PARAMETER_MB_ADDR_RESERVE1_0 = 222,
            PARAMETER_MB_ADDR_RESERVE1_1 = 223,
            PARAMETER_MB_ADDR_RESERVE1_2 = 224,
            PARAMETER_MB_ADDR_RESERVE1_3 = 225,
            PARAMETER_MB_ADDR_RESERVE1_4 = 226,
            PARAMETER_MB_ADDR_RESERVE1_5 = 227,
            PARAMETER_MB_ADDR_RESERVE1_6 = 228,
            PARAMETER_MB_ADDR_RESERVE1_7 = 229,
            PARAMETER_MB_ADDR_RESERVE1_8 = 230,
            PARAMETER_MB_ADDR_RESERVE1_9 = 231,
            PARAMETER_MB_ADDR_RESERVE1_10 = 232,
            PARAMETER_MB_ADDR_RESERVE1_11 = 233,
            PARAMETER_MB_ADDR_RESERVE1_12 = 234,
            PARAMETER_MB_ADDR_RESERVE1_13 = 235,
            PARAMETER_MB_ADDR_RESERVE1_14 = 236,
            PARAMETER_MB_ADDR_RESERVE1_15 = 237,
            PARAMETER_MB_ADDR_RESERVE1_16 = 238,
            PARAMETER_MB_ADDR_RESERVE1_17 = 239,
            PARAMETER_MB_ADDR_RESERVE1_18 = 240,
            PARAMETER_MB_ADDR_RESERVE1_19 = 241,
            PARAMETER_MB_ADDR_RESERVE1_20 = 242,
            PARAMETER_MB_ADDR_RESERVE1_21 = 243,
            PARAMETER_MB_ADDR_RESERVE1_22 = 244,
            PARAMETER_MB_ADDR_RESERVE1_23 = 245,
            PARAMETER_MB_ADDR_RESERVE1_24 = 246,
            PARAMETER_MB_ADDR_RESERVE1_25 = 247,
            PARAMETER_MB_ADDR_RESERVE1_26 = 248,
            PARAMETER_MB_ADDR_RESERVE1_27 = 249,
            PARAMETER_MB_ADDR_RESERVE1_28 = 250,
            PARAMETER_MB_ADDR_RESERVE1_29 = 251,
            PARAMETER_MB_ADDR_RESERVE1_30 = 252,
            PARAMETER_MB_ADDR_RESERVE1_31 = 253,
            PARAMETER_MB_ADDR_RESERVE1_32 = 254,
            PARAMETER_MB_ADDR_RESERVE1_33 = 255,
            PARAMETER_MB_ADDR_RESERVE1_34 = 256,
            PARAMETER_MB_ADDR_RESERVE1_35 = 257,
            PARAMETER_MB_ADDR_RESERVE1_36 = 258,
            PARAMETER_MB_ADDR_RESERVE1_37 = 259,
            PARAMETER_MB_ADDR_RESERVE1_38 = 260,
            PARAMETER_MB_ADDR_RESERVE1_39 = 261,
            PARAMETER_MB_ADDR_RESERVE1_40 = 262,
            PARAMETER_MB_ADDR_RESERVE1_41 = 263,
            PARAMETER_MB_ADDR_RESERVE1_42 = 264,
            PARAMETER_MB_ADDR_RESERVE1_43 = 265,
            PARAMETER_MB_ADDR_RESERVE1_44 = 266,
            PARAMETER_MB_ADDR_RESERVE1_45 = 267,
            PARAMETER_MB_ADDR_RESERVE1_46 = 268,
            PARAMETER_MB_ADDR_RESERVE1_47 = 269,
            PARAMETER_MB_ADDR_RESERVE1_48 = 270,
            PARAMETER_MB_ADDR_RESERVE1_49 = 271,
            PARAMETER_MB_ADDR_RESERVE1_50 = 272,
            PARAMETER_MB_ADDR_RESERVE1_51 = 273,
            PARAMETER_MB_ADDR_RESERVE1_52 = 274,
            PARAMETER_MB_ADDR_RESERVE1_53 = 275,
            PARAMETER_MB_ADDR_RESERVE1_54 = 276,
            PARAMETER_MB_ADDR_RESERVE1_55 = 277,
            PARAMETER_MB_ADDR_RESERVE1_56 = 278,
            PARAMETER_MB_ADDR_RESERVE1_57 = 279,
            PARAMETER_MB_ADDR_RESERVE1_58 = 280,
            PARAMETER_MB_ADDR_RESERVE1_59 = 281,
            PARAMETER_MB_ADDR_RESERVE1_60 = 282,
            PARAMETER_MB_ADDR_RESERVE1_61 = 283,
            PARAMETER_MB_ADDR_RESERVE1_62 = 284,
            PARAMETER_MB_ADDR_RESERVE1_63 = 285,
            PARAMETER_MB_ADDR_RESERVE1_64 = 286,
            PARAMETER_MB_ADDR_RESERVE1_65 = 287,
            PARAMETER_MB_ADDR_RESERVE1_66 = 288,
            PARAMETER_MB_ADDR_RESERVE1_67 = 289,
            PARAMETER_MB_ADDR_RESERVE1_68 = 290,
            PARAMETER_MB_ADDR_RESERVE1_69 = 291,
            PARAMETER_MB_ADDR_RESERVE1_70 = 292,
            PARAMETER_MB_ADDR_RESERVE1_71 = 293,
            PARAMETER_MB_ADDR_RESERVE1_72 = 294,
            PARAMETER_MB_ADDR_RESERVE1_73 = 295,
            PARAMETER_MB_ADDR_RESERVE1_74 = 296,
            PARAMETER_MB_ADDR_RESERVE1_75 = 297,
            PARAMETER_MB_ADDR_RESERVE1_76 = 298,
            PARAMETER_MB_ADDR_RESERVE1_77 = 299,
            PARAMETER_MB_ADDR_RESERVE1_78 = 300,
            PARAMETER_MB_ADDR_RESERVE1_79 = 301,
            PARAMETER_MB_ADDR_RESERVE1_80 = 302,
            PARAMETER_MB_ADDR_RESERVE1_81 = 303,
            PARAMETER_MB_ADDR_RESERVE1_82 = 304,
            PARAMETER_MB_ADDR_RESERVE1_83 = 305,
            PARAMETER_MB_ADDR_RESERVE1_84 = 306,
            PARAMETER_MB_ADDR_RESERVE1_85 = 307,
            PARAMETER_MB_ADDR_RESERVE1_86 = 308,
            PARAMETER_MB_ADDR_RESERVE1_87 = 309,
            PARAMETER_MB_ADDR_RESERVE1_88 = 310,
            PARAMETER_MB_ADDR_RESERVE1_89 = 311,
            PARAMETER_MB_ADDR_RESERVE1_90 = 312,
            PARAMETER_MB_ADDR_RESERVE1_91 = 313,
            PARAMETER_MB_ADDR_RESERVE1_92 = 314,
            PARAMETER_MB_ADDR_RESERVE1_93 = 315,
            PARAMETER_MB_ADDR_RESERVE1_94 = 316,
            PARAMETER_MB_ADDR_RESERVE1_95 = 317,
            PARAMETER_MB_ADDR_RESERVE1_96 = 318,
            PARAMETER_MB_ADDR_RESERVE1_97 = 319,
            PARAMETER_MB_ADDR_RESERVE1_98 = 320,
            PARAMETER_MB_ADDR_RESERVE1_99 = 321,
            PARAMETER_MB_ADDR_RESERVE1_100 = 322,
            PARAMETER_MB_ADDR_RESERVE1_101 = 323,
            PARAMETER_MB_ADDR_RESERVE1_102 = 324,
            PARAMETER_MB_ADDR_RESERVE1_103 = 325,
            PARAMETER_MB_ADDR_RESERVE1_104 = 326,
            PARAMETER_MB_ADDR_RESERVE1_105 = 327,
            PARAMETER_MB_ADDR_RESERVE1_106 = 328,
            PARAMETER_MB_ADDR_RESERVE1_107 = 329,
            PARAMETER_MB_ADDR_RESERVE1_108 = 330,
            PARAMETER_MB_ADDR_RESERVE1_109 = 331,
            PARAMETER_MB_ADDR_RESERVE1_110 = 332,
            PARAMETER_MB_ADDR_RESERVE1_111 = 333,
            PARAMETER_MB_ADDR_RESERVE1_112 = 334,
            PARAMETER_MB_ADDR_RESERVE1_113 = 335,
            PARAMETER_MB_ADDR_RESERVE1_114 = 336,
            PARAMETER_MB_ADDR_RESERVE1_115 = 337,
            PARAMETER_MB_ADDR_RESERVE1_116 = 338,
            PARAMETER_MB_ADDR_RESERVE1_117 = 339,
            PARAMETER_MB_ADDR_RESERVE1_118 = 340,
            PARAMETER_MB_ADDR_RESERVE1_119 = 341,
            PARAMETER_MB_ADDR_RESERVE1_120 = 342,
            PARAMETER_MB_ADDR_RESERVE1_121 = 343,
            PARAMETER_MB_ADDR_RESERVE1_122 = 344,
            PARAMETER_MB_ADDR_RESERVE1_123 = 345,
            PARAMETER_MB_ADDR_RESERVE1_124 = 346,
            PARAMETER_MB_ADDR_RESERVE1_125 = 347,
            PARAMETER_MB_ADDR_RESERVE1_126 = 348,
            PARAMETER_MB_ADDR_RESERVE1_127 = 349,
            PARAMETER_MB_ADDR_RESERVE1_128 = 350,
            PARAMETER_MB_ADDR_RESERVE1_129 = 351,
            PARAMETER_MB_ADDR_RESERVE1_130 = 352,
            PARAMETER_MB_ADDR_RESERVE1_131 = 353,
            PARAMETER_MB_ADDR_RESERVE1_132 = 354,
            PARAMETER_MB_ADDR_RESERVE1_133 = 355,
            PARAMETER_MB_ADDR_RESERVE1_134 = 356,
            PARAMETER_MB_ADDR_RESERVE1_135 = 357,
            PARAMETER_MB_ADDR_RESERVE1_136 = 358,
            PARAMETER_MB_ADDR_RESERVE1_137 = 359,
            PARAMETER_MB_ADDR_RESERVE1_138 = 360,
            PARAMETER_MB_ADDR_RESERVE1_139 = 361,
            PARAMETER_MB_ADDR_RESERVE1_140 = 362,
            PARAMETER_MB_ADDR_RESERVE1_141 = 363,
            PARAMETER_MB_ADDR_RESERVE1_142 = 364,
            PARAMETER_MB_ADDR_RESERVE1_143 = 365,
            PARAMETER_MB_ADDR_RESERVE1_144 = 366,
            PARAMETER_MB_ADDR_RESERVE1_145 = 367,
            PARAMETER_MB_ADDR_RESERVE1_146 = 368,
            PARAMETER_MB_ADDR_RESERVE1_147 = 369,
            PARAMETER_MB_ADDR_RESERVE1_148 = 370,
            PARAMETER_MB_ADDR_RESERVE1_149 = 371,
            PARAMETER_MB_ADDR_RESERVE1_150 = 372,
            PARAMETER_MB_ADDR_RESERVE1_151 = 373,
            PARAMETER_MB_ADDR_RESERVE1_152 = 374,
            PARAMETER_MB_ADDR_RESERVE1_153 = 375,
            PARAMETER_MB_ADDR_RESERVE1_154 = 376,
            PARAMETER_MB_ADDR_RESERVE1_155 = 377,
            PARAMETER_MB_ADDR_RESERVE1_156 = 378,
            PARAMETER_MB_ADDR_RESERVE1_157 = 379,
            PARAMETER_MB_ADDR_RESERVE1_158 = 380,
            PARAMETER_MB_ADDR_RESERVE1_159 = 381,
            PARAMETER_MB_ADDR_RESERVE1_160 = 382,
            PARAMETER_MB_ADDR_RESERVE1_161 = 383,
            PARAMETER_MB_ADDR_RESERVE1_162 = 384,
            PARAMETER_MB_ADDR_RESERVE1_163 = 385,
            PARAMETER_MB_ADDR_RESERVE1_164 = 386,
            PARAMETER_MB_ADDR_RESERVE1_165 = 387,
            PARAMETER_MB_ADDR_RESERVE1_166 = 388,
            PARAMETER_MB_ADDR_RESERVE1_167 = 389,
            PARAMETER_MB_ADDR_RESERVE1_168 = 390,
            PARAMETER_MB_ADDR_RESERVE1_169 = 391,
            PARAMETER_MB_ADDR_RESERVE1_170 = 392,
            PARAMETER_MB_ADDR_RESERVE1_171 = 393,
            PARAMETER_MB_ADDR_RESERVE1_172 = 394,
            PARAMETER_MB_ADDR_RESERVE1_173 = 395,
            PARAMETER_MB_ADDR_RESERVE1_174 = 396,
            PARAMETER_MB_ADDR_RESERVE1_175 = 397,
            PARAMETER_MB_ADDR_RESERVE1_176 = 398,
            PARAMETER_MB_ADDR_RESERVE1_177 = 399,
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
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_MS5611_CONNECTION_RESULT = 4252,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_MS5611_CONNECTION_RETRY = 4253,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_MS5611_CONNECTION_TIME_US_0 = 4254,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_MS5611_CONNECTION_TIME_US_1 = 4255,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_MS5611_CONFIG_RESULT = 4256,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_MS5611_CONFIG_RETRY = 4257,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_MS5611_CONFIG_TIME_US_0 = 4258,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_MS5611_CONFIG_TIME_US_1 = 4259,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_DADC_CONNECTION_RESULT = 4260,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_DADC_CONNECTION_RETRY = 4261,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_DADC_CONNECTION_TIME_US_0 = 4262,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_DADC_CONNECTION_TIME_US_1 = 4263,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_DADC_CONFIG_RESULT = 4264,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_DADC_CONFIG_RETRY = 4265,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_DADC_CONFIG_TIME_US_0 = 4266,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_DADC_CONFIG_TIME_US_1 = 4267,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_IBNS_MATCH_CONNECTION_RESULT = 4268,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_IBNS_MATCH_CONNECTION_RETRY = 4269,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_IBNS_MATCH_CONNECTION_TIME_US_0 = 4270,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_IBNS_MATCH_CONNECTION_TIME_US_1 = 4271,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_IBNS_MATCH_CONFIG_RESULT = 4272,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_IBNS_MATCH_CONFIG_RETRY = 4273,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_IBNS_MATCH_CONFIG_TIME_US_0 = 4274,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_IBNS_MATCH_CONFIG_TIME_US_1 = 4275,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_IBNS_SPEED_CONNECTION_RESULT = 4276,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_IBNS_SPEED_CONNECTION_RETRY = 4277,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_IBNS_SPEED_CONNECTION_TIME_US_0 = 4278,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_IBNS_SPEED_CONNECTION_TIME_US_1 = 4279,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_IBNS_SPEED_CONFIG_RESULT = 4280,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_IBNS_SPEED_CONFIG_RETRY = 4281,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_IBNS_SPEED_CONFIG_TIME_US_0 = 4282,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_IBNS_SPEED_CONFIG_TIME_US_1 = 4283,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_SADRA_CONNECTION_RESULT = 4284,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_SADRA_CONNECTION_RETRY = 4285,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_SADRA_CONNECTION_TIME_US_0 = 4286,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_SADRA_CONNECTION_TIME_US_1 = 4287,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_SADRA_CONFIG_RESULT = 4288,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_SADRA_CONFIG_RETRY = 4289,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_SADRA_CONFIG_TIME_US_0 = 4290,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_SADRA_CONFIG_TIME_US_1 = 4291,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_HMC5983_CONNECTION_RESULT = 4292,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_HMC5983_CONNECTION_RETRY = 4293,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_HMC5983_CONNECTION_TIME_US_0 = 4294,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_HMC5983_CONNECTION_TIME_US_1 = 4295,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_HMC5983_CONFIG_RESULT = 4296,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_HMC5983_CONFIG_RETRY = 4297,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_HMC5983_CONFIG_TIME_US_0 = 4298,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_HMC5983_CONFIG_TIME_US_1 = 4299,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_GPS_M9_N_CONNECTION_RESULT = 4300,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_GPS_M9_N_CONNECTION_RETRY = 4301,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_GPS_M9_N_CONNECTION_TIME_US_0 = 4302,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_GPS_M9_N_CONNECTION_TIME_US_1 = 4303,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_GPS_M9_N_CONFIG_RESULT = 4304,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_GPS_M9_N_CONFIG_RETRY = 4305,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_GPS_M9_N_CONFIG_TIME_US_0 = 4306,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_GPS_M9_N_CONFIG_TIME_US_1 = 4307,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_IMU_CONNECTION_RESULT = 4308,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_IMU_CONNECTION_RETRY = 4309,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_IMU_CONNECTION_TIME_US_0 = 4310,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_IMU_CONNECTION_TIME_US_1 = 4311,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_IMU_CONFIG_RESULT = 4312,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_IMU_CONFIG_RETRY = 4313,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_IMU_CONFIG_TIME_US_0 = 4314,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_IMU_CONFIG_TIME_US_1 = 4315,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_0_X_0 = 4316,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_0_X_1 = 4317,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_0_X_2 = 4318,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_0_X_3 = 4319,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_0_Y_0 = 4320,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_0_Y_1 = 4321,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_0_Y_2 = 4322,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_0_Y_3 = 4323,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_0_Z_0 = 4324,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_0_Z_1 = 4325,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_0_Z_2 = 4326,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_0_Z_3 = 4327,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_1_X_0 = 4328,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_1_X_1 = 4329,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_1_X_2 = 4330,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_1_X_3 = 4331,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_1_Y_0 = 4332,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_1_Y_1 = 4333,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_1_Y_2 = 4334,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_1_Y_3 = 4335,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_1_Z_0 = 4336,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_1_Z_1 = 4337,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_1_Z_2 = 4338,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_1_Z_3 = 4339,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_0_X_0 = 4340,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_0_X_1 = 4341,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_0_X_2 = 4342,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_0_X_3 = 4343,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_0_Y_0 = 4344,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_0_Y_1 = 4345,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_0_Y_2 = 4346,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_0_Y_3 = 4347,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_0_Z_0 = 4348,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_0_Z_1 = 4349,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_0_Z_2 = 4350,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_0_Z_3 = 4351,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_1_X_0 = 4352,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_1_X_1 = 4353,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_1_X_2 = 4354,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_1_X_3 = 4355,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_1_Y_0 = 4356,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_1_Y_1 = 4357,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_1_Y_2 = 4358,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_1_Y_3 = 4359,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_1_Z_0 = 4360,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_1_Z_1 = 4361,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_1_Z_2 = 4362,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_1_Z_3 = 4363,
            PARAMETER_MB_ADDR_IMU_DATA_TEMPERATURE_0 = 4364,
            PARAMETER_MB_ADDR_IMU_DATA_TEMPERATURE_1 = 4365,
            PARAMETER_MB_ADDR_IMU_DATA_TEMPERATURE_2 = 4366,
            PARAMETER_MB_ADDR_IMU_DATA_TEMPERATURE_3 = 4367,
            PARAMETER_MB_ADDR_IMU_DATA_SERIAL_NO = 4368,
            PARAMETER_MB_ADDR_IMU_DATA_COUNTER = 4369,
            PARAMETER_MB_ADDR_IMU_DATA_IS_NEW_DATA = 4370,
            PARAMETER_MB_ADDR_IMU_DATA_ACTIVE = 4371,
            PARAMETER_MB_ADDR_IMU_DATA_SUMMARY_STATUS_0 = 4372,
            PARAMETER_MB_ADDR_IMU_DATA_SUMMARY_STATUS_1 = 4373,
            PARAMETER_MB_ADDR_IMU_SETTING_TYPE = 4374,
            PARAMETER_MB_ADDR_IMU_SETTING_DEC_RATE = 4375,
            PARAMETER_MB_ADDR_IMU_SETTING_FILTER_ACC_XENABLE = 4376,
            PARAMETER_MB_ADDR_IMU_SETTING_FILTER_ACC_XTYPE = 4377,
            PARAMETER_MB_ADDR_IMU_SETTING_FILTER_ACC_YENABLE = 4378,
            PARAMETER_MB_ADDR_IMU_SETTING_FILTER_ACC_YTYPE = 4379,
            PARAMETER_MB_ADDR_IMU_SETTING_FILTER_ACC_ZENABLE = 4380,
            PARAMETER_MB_ADDR_IMU_SETTING_FILTER_ACC_ZTYPE = 4381,
            PARAMETER_MB_ADDR_IMU_SETTING_FILTER_GYRO_XENABLE = 4382,
            PARAMETER_MB_ADDR_IMU_SETTING_FILTER_GYRO_XTYPE = 4383,
            PARAMETER_MB_ADDR_IMU_SETTING_FILTER_GYRO_YENABLE = 4384,
            PARAMETER_MB_ADDR_IMU_SETTING_FILTER_GYRO_YTYPE = 4385,
            PARAMETER_MB_ADDR_IMU_SETTING_FILTER_GYRO_ZENABLE = 4386,
            PARAMETER_MB_ADDR_IMU_SETTING_FILTER_GYRO_ZTYPE = 4387,
            PARAMETER_MB_ADDR_IMU_SETTING_FILTER_MAG_XENABLE = 4388,
            PARAMETER_MB_ADDR_IMU_SETTING_FILTER_MAG_XTYPE = 4389,
            PARAMETER_MB_ADDR_IMU_SETTING_FILTER_MAG_YENABLE = 4390,
            PARAMETER_MB_ADDR_IMU_SETTING_FILTER_MAG_YTYPE = 4391,
            PARAMETER_MB_ADDR_IMU_SETTING_FILTER_MAG_ZENABLE = 4392,
            PARAMETER_MB_ADDR_IMU_SETTING_FILTER_MAG_ZTYPE = 4393,
            PARAMETER_MB_ADDR_IMU_SETTING_ENABLE = 4394,
            PARAMETER_MB_ADDR_MS5611_DATA_PRESS_0 = 4395,
            PARAMETER_MB_ADDR_MS5611_DATA_PRESS_1 = 4396,
            PARAMETER_MB_ADDR_MS5611_DATA_TEMPERATURE_0 = 4397,
            PARAMETER_MB_ADDR_MS5611_DATA_TEMPERATURE_1 = 4398,
            PARAMETER_MB_ADDR_MS5611_DATA_IS_NEW_DATA = 4399,
            PARAMETER_MB_ADDR_MS5611_DATA_ACTIVE = 4400,
            PARAMETER_MB_ADDR_MS5611_DATA_SUMMARY_STATUS_0 = 4401,
            PARAMETER_MB_ADDR_MS5611_DATA_SUMMARY_STATUS_1 = 4402,
            PARAMETER_MB_ADDR_MS5611_SETTING_OSR = 4403,
            PARAMETER_MB_ADDR_MS5611_SETTING_ENABLE = 4404,
            PARAMETER_MB_ADDR_M9N_DATA_ITOW_0 = 4405,
            PARAMETER_MB_ADDR_M9N_DATA_ITOW_1 = 4406,
            PARAMETER_MB_ADDR_M9N_DATA_YEAR = 4407,
            PARAMETER_MB_ADDR_M9N_DATA_MONTH = 4408,
            PARAMETER_MB_ADDR_M9N_DATA_DAY = 4409,
            PARAMETER_MB_ADDR_M9N_DATA_HOURS = 4410,
            PARAMETER_MB_ADDR_M9N_DATA_MIN = 4411,
            PARAMETER_MB_ADDR_M9N_DATA_SEC = 4412,
            PARAMETER_MB_ADDR_M9N_DATA_VALID = 4413,
            PARAMETER_MB_ADDR_M9N_DATA_TACC_0 = 4414,
            PARAMETER_MB_ADDR_M9N_DATA_TACC_1 = 4415,
            PARAMETER_MB_ADDR_M9N_DATA_NANO_0 = 4416,
            PARAMETER_MB_ADDR_M9N_DATA_NANO_1 = 4417,
            PARAMETER_MB_ADDR_M9N_DATA_FIX_TYPE = 4418,
            PARAMETER_MB_ADDR_M9N_DATA_FLAGS = 4419,
            PARAMETER_MB_ADDR_M9N_DATA_FLAGS2 = 4420,
            PARAMETER_MB_ADDR_M9N_DATA_NUM_SV = 4421,
            PARAMETER_MB_ADDR_M9N_DATA_LON_0 = 4422,
            PARAMETER_MB_ADDR_M9N_DATA_LON_1 = 4423,
            PARAMETER_MB_ADDR_M9N_DATA_LON_2 = 4424,
            PARAMETER_MB_ADDR_M9N_DATA_LON_3 = 4425,
            PARAMETER_MB_ADDR_M9N_DATA_LAT_0 = 4426,
            PARAMETER_MB_ADDR_M9N_DATA_LAT_1 = 4427,
            PARAMETER_MB_ADDR_M9N_DATA_LAT_2 = 4428,
            PARAMETER_MB_ADDR_M9N_DATA_LAT_3 = 4429,
            PARAMETER_MB_ADDR_M9N_DATA_HEIGHT_0 = 4430,
            PARAMETER_MB_ADDR_M9N_DATA_HEIGHT_1 = 4431,
            PARAMETER_MB_ADDR_M9N_DATA_HEIGHT_2 = 4432,
            PARAMETER_MB_ADDR_M9N_DATA_HEIGHT_3 = 4433,
            PARAMETER_MB_ADDR_M9N_DATA_HMSL_0 = 4434,
            PARAMETER_MB_ADDR_M9N_DATA_HMSL_1 = 4435,
            PARAMETER_MB_ADDR_M9N_DATA_HACC_0 = 4436,
            PARAMETER_MB_ADDR_M9N_DATA_HACC_1 = 4437,
            PARAMETER_MB_ADDR_M9N_DATA_VACC_0 = 4438,
            PARAMETER_MB_ADDR_M9N_DATA_VACC_1 = 4439,
            PARAMETER_MB_ADDR_M9N_DATA_VEL_NED_0_0 = 4440,
            PARAMETER_MB_ADDR_M9N_DATA_VEL_NED_0_1 = 4441,
            PARAMETER_MB_ADDR_M9N_DATA_VEL_NED_1_0 = 4442,
            PARAMETER_MB_ADDR_M9N_DATA_VEL_NED_1_1 = 4443,
            PARAMETER_MB_ADDR_M9N_DATA_VEL_NED_2_0 = 4444,
            PARAMETER_MB_ADDR_M9N_DATA_VEL_NED_2_1 = 4445,
            PARAMETER_MB_ADDR_M9N_DATA_GSPEED_0 = 4446,
            PARAMETER_MB_ADDR_M9N_DATA_GSPEED_1 = 4447,
            PARAMETER_MB_ADDR_M9N_DATA_HEAD_MOT_0 = 4448,
            PARAMETER_MB_ADDR_M9N_DATA_HEAD_MOT_1 = 4449,
            PARAMETER_MB_ADDR_M9N_DATA_SACC_0 = 4450,
            PARAMETER_MB_ADDR_M9N_DATA_SACC_1 = 4451,
            PARAMETER_MB_ADDR_M9N_DATA_HEAD_ACC_0 = 4452,
            PARAMETER_MB_ADDR_M9N_DATA_HEAD_ACC_1 = 4453,
            PARAMETER_MB_ADDR_M9N_DATA_PDOP = 4454,
            PARAMETER_MB_ADDR_M9N_DATA_RESESRVED_0 = 4455,
            PARAMETER_MB_ADDR_M9N_DATA_RESESRVED_1 = 4456,
            PARAMETER_MB_ADDR_M9N_DATA_RESESRVED_2 = 4457,
            PARAMETER_MB_ADDR_M9N_DATA_RESESRVED_3 = 4458,
            PARAMETER_MB_ADDR_M9N_DATA_HEAD_VEH_0 = 4459,
            PARAMETER_MB_ADDR_M9N_DATA_HEAD_VEH_1 = 4460,
            PARAMETER_MB_ADDR_M9N_DATA_MAG_DEC = 4461,
            PARAMETER_MB_ADDR_M9N_DATA_MAG_ACC = 4462,
            PARAMETER_MB_ADDR_M9N_DATA_FRAME_COUNTER_0 = 4463,
            PARAMETER_MB_ADDR_M9N_DATA_FRAME_COUNTER_1 = 4464,
            PARAMETER_MB_ADDR_M9N_DATA_FRAME_ERROR_COUNTER_0 = 4465,
            PARAMETER_MB_ADDR_M9N_DATA_FRAME_ERROR_COUNTER_1 = 4466,
            PARAMETER_MB_ADDR_M9N_DATA_IS_VALID_DATA = 4467,
            PARAMETER_MB_ADDR_M9N_DATA_IS_NEW_DATA = 4468,
            PARAMETER_MB_ADDR_M9N_DATA_ACTIVE = 4469,
            PARAMETER_MB_ADDR_M9N_DATA_SUMMARY_STATUS_0 = 4470,
            PARAMETER_MB_ADDR_M9N_DATA_SUMMARY_STATUS_1 = 4471,
            PARAMETER_MB_ADDR_M9N_SETTING_BAUD_RATE_0 = 4472,
            PARAMETER_MB_ADDR_M9N_SETTING_BAUD_RATE_1 = 4473,
            PARAMETER_MB_ADDR_M9N_SETTING_ENABLE = 4474,
            PARAMETER_MB_ADDR_DADC_DATA_ADC_IS_NEW_DATA = 4475,
            PARAMETER_MB_ADDR_DADC_DATA_ADC_UNIT = 4476,
            PARAMETER_MB_ADDR_DADC_DATA_ADC_OUTSIDE_PROBE_TEMP_0 = 4477,
            PARAMETER_MB_ADDR_DADC_DATA_ADC_OUTSIDE_PROBE_TEMP_1 = 4478,
            PARAMETER_MB_ADDR_DADC_DATA_ADC_INTERNAL_PROBE_TEMP_0 = 4479,
            PARAMETER_MB_ADDR_DADC_DATA_ADC_INTERNAL_PROBE_TEMP_1 = 4480,
            PARAMETER_MB_ADDR_DADC_DATA_ADC_STATIC_PRESSURE_0 = 4481,
            PARAMETER_MB_ADDR_DADC_DATA_ADC_STATIC_PRESSURE_1 = 4482,
            PARAMETER_MB_ADDR_DADC_DATA_ADC_PITOT_DIFF_PRESSURE_0 = 4483,
            PARAMETER_MB_ADDR_DADC_DATA_ADC_PITOT_DIFF_PRESSURE_1 = 4484,
            PARAMETER_MB_ADDR_DADC_DATA_ADA_IS_NEW_DATA = 4485,
            PARAMETER_MB_ADDR_DADC_DATA_ADA_UNIT = 4486,
            PARAMETER_MB_ADDR_DADC_DATA_ADA_PRESSURE_ALTITUDE_0 = 4487,
            PARAMETER_MB_ADDR_DADC_DATA_ADA_PRESSURE_ALTITUDE_1 = 4488,
            PARAMETER_MB_ADDR_DADC_DATA_ADA_INDICATED_ALTITUDE_0 = 4489,
            PARAMETER_MB_ADDR_DADC_DATA_ADA_INDICATED_ALTITUDE_1 = 4490,
            PARAMETER_MB_ADDR_DADC_DATA_ADA_TRUE_ALTITUDE_0 = 4491,
            PARAMETER_MB_ADDR_DADC_DATA_ADA_TRUE_ALTITUDE_1 = 4492,
            PARAMETER_MB_ADDR_DADC_DATA_ADA_RATE_OF_CLIMB_0 = 4493,
            PARAMETER_MB_ADDR_DADC_DATA_ADA_RATE_OF_CLIMB_1 = 4494,
            PARAMETER_MB_ADDR_DADC_DATA_ADA_OUTSIDE_AIR_TEMPERATURE_0 = 4495,
            PARAMETER_MB_ADDR_DADC_DATA_ADA_OUTSIDE_AIR_TEMPERATURE_1 = 4496,
            PARAMETER_MB_ADDR_DADC_DATA_ADA_TOTAL_AIR_TEMPERATURE_0 = 4497,
            PARAMETER_MB_ADDR_DADC_DATA_ADA_TOTAL_AIR_TEMPERATURE_1 = 4498,
            PARAMETER_MB_ADDR_DADC_DATA_ADA_DIFF_OUTSIDE_AIR_TEMP_AND_ISA_0 = 4499,
            PARAMETER_MB_ADDR_DADC_DATA_ADA_DIFF_OUTSIDE_AIR_TEMP_AND_ISA_1 = 4500,
            PARAMETER_MB_ADDR_DADC_DATA_ADV_IS_NEW_DATA = 4501,
            PARAMETER_MB_ADDR_DADC_DATA_ADV_UNIT = 4502,
            PARAMETER_MB_ADDR_DADC_DATA_ADV_CALIBRATED_AIR_SPEED_0 = 4503,
            PARAMETER_MB_ADDR_DADC_DATA_ADV_CALIBRATED_AIR_SPEED_1 = 4504,
            PARAMETER_MB_ADDR_DADC_DATA_ADV_TRUE_AIRSPEED_0 = 4505,
            PARAMETER_MB_ADDR_DADC_DATA_ADV_TRUE_AIRSPEED_1 = 4506,
            PARAMETER_MB_ADDR_DADC_DATA_ADV_MACH_NUM_0 = 4507,
            PARAMETER_MB_ADDR_DADC_DATA_ADV_MACH_NUM_1 = 4508,
            PARAMETER_MB_ADDR_DADC_DATA_ADV_AIR_DENSITY_0 = 4509,
            PARAMETER_MB_ADDR_DADC_DATA_ADV_AIR_DENSITY_1 = 4510,
            PARAMETER_MB_ADDR_DADC_DATA_ADR_IS_NEW_DATA = 4511,
            PARAMETER_MB_ADDR_DADC_DATA_ADR_CPU_TEMP_0 = 4512,
            PARAMETER_MB_ADDR_DADC_DATA_ADR_CPU_TEMP_1 = 4513,
            PARAMETER_MB_ADDR_DADC_DATA_ADR_OUTSIDE_RTD_MV_0 = 4514,
            PARAMETER_MB_ADDR_DADC_DATA_ADR_OUTSIDE_RTD_MV_1 = 4515,
            PARAMETER_MB_ADDR_DADC_DATA_ADR_INSIDE_RTD_MV_0 = 4516,
            PARAMETER_MB_ADDR_DADC_DATA_ADR_INSIDE_RTD_MV_1 = 4517,
            PARAMETER_MB_ADDR_DADC_DATA_ADR_STATIC_PRESS_V_0 = 4518,
            PARAMETER_MB_ADDR_DADC_DATA_ADR_STATIC_PRESS_V_1 = 4519,
            PARAMETER_MB_ADDR_DADC_DATA_ADR_DIFF_PRESS_V_0 = 4520,
            PARAMETER_MB_ADDR_DADC_DATA_ADR_DIFF_PRESS_V_1 = 4521,
            PARAMETER_MB_ADDR_DADC_DATA_ACTIVE = 4522,
            PARAMETER_MB_ADDR_DADC_DATA_SUMMARY_STATUS_0 = 4523,
            PARAMETER_MB_ADDR_DADC_DATA_SUMMARY_STATUS_1 = 4524,
            PARAMETER_MB_ADDR_DADC_SETTING_ENABLE = 4525,
            PARAMETER_MB_ADDR_HMC5983_DATA_MAG_X = 4526,
            PARAMETER_MB_ADDR_HMC5983_DATA_MAG_Y = 4527,
            PARAMETER_MB_ADDR_HMC5983_DATA_MAG_Z = 4528,
            PARAMETER_MB_ADDR_HMC5983_DATA_TEMPERATURE_0 = 4529,
            PARAMETER_MB_ADDR_HMC5983_DATA_TEMPERATURE_1 = 4530,
            PARAMETER_MB_ADDR_HMC5983_DATA_TEMPERATURE_2 = 4531,
            PARAMETER_MB_ADDR_HMC5983_DATA_TEMPERATURE_3 = 4532,
            PARAMETER_MB_ADDR_HMC5983_DATA_IS_NEW_DATA = 4533,
            PARAMETER_MB_ADDR_HMC5983_DATA_ACTIVE = 4534,
            PARAMETER_MB_ADDR_HMC5983_DATA_SUMMARY_STATUS_0 = 4535,
            PARAMETER_MB_ADDR_HMC5983_DATA_SUMMARY_STATUS_1 = 4536,
            PARAMETER_MB_ADDR_HMC5983_SETTING_ODR = 4537,
            PARAMETER_MB_ADDR_HMC5983_SETTING_SAMPLE_AVERAGE = 4538,
            PARAMETER_MB_ADDR_HMC5983_SETTING_GAIN = 4539,
            PARAMETER_MB_ADDR_HMC5983_SETTING_ENABLE = 4540,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_JETSON_TIME_UTC_0 = 4541,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_JETSON_TIME_UTC_1 = 4542,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_RAW_LAT_DEG_0 = 4543,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_RAW_LAT_DEG_1 = 4544,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_RAW_LAT_DEG_2 = 4545,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_RAW_LAT_DEG_3 = 4546,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_RAW_LON_DEG_0 = 4547,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_RAW_LON_DEG_1 = 4548,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_RAW_LON_DEG_2 = 4549,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_RAW_LON_DEG_3 = 4550,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_EST_LAT_DEG_0 = 4551,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_EST_LAT_DEG_1 = 4552,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_EST_LAT_DEG_2 = 4553,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_EST_LAT_DEG_3 = 4554,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_EST_LON_DEG_0 = 4555,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_EST_LON_DEG_1 = 4556,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_EST_LON_DEG_2 = 4557,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_EST_LON_DEG_3 = 4558,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_AGL_M_0 = 4559,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_AGL_M_1 = 4560,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_AGL_M_2 = 4561,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_AGL_M_3 = 4562,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_DEM_ALT_M_0 = 4563,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_DEM_ALT_M_1 = 4564,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_DEM_ALT_M_2 = 4565,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_DEM_ALT_M_3 = 4566,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_ROLL_FUS_DEG_0 = 4567,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_ROLL_FUS_DEG_1 = 4568,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_ROLL_FUS_DEG_2 = 4569,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_ROLL_FUS_DEG_3 = 4570,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_PITCH_FUS_DEG_0 = 4571,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_PITCH_FUS_DEG_1 = 4572,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_PITCH_FUS_DEG_2 = 4573,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_PITCH_FUS_DEG_3 = 4574,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_YAW_FUS_DEG_0 = 4575,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_YAW_FUS_DEG_1 = 4576,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_YAW_FUS_DEG_2 = 4577,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_YAW_FUS_DEG_3 = 4578,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_HEADING_DEG_0 = 4579,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_HEADING_DEG_1 = 4580,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_HEADING_DEG_2 = 4581,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_HEADING_DEG_3 = 4582,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_COURES_DEG_0 = 4583,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_COURES_DEG_1 = 4584,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_COURES_DEG_2 = 4585,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_COURES_DEG_3 = 4586,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_QUALITY_MATCH = 4587,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_STATUS_FLAGS = 4588,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_UPDATE_MASK_0 = 4589,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_UPDATE_MASK_1 = 4590,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_EXCUTION_TIME_MS = 4591,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_IS_NEW_DATA = 4592,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_ACTIVE = 4593,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_SUMMARY_STATUS_0 = 4594,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_SUMMARY_STATUS_1 = 4595,
            PARAMETER_MB_ADDR_IBNS_MATCH_SETTING_ENABLE = 4596,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_JETSON_TIME_UTC_0 = 4597,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_JETSON_TIME_UTC_1 = 4598,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ODOLAT_DEG_0 = 4599,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ODOLAT_DEG_1 = 4600,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ODOLAT_DEG_2 = 4601,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ODOLAT_DEG_3 = 4602,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ODOLON_DEG_0 = 4603,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ODOLON_DEG_1 = 4604,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ODOLON_DEG_2 = 4605,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ODOLON_DEG_3 = 4606,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ALT_M_0 = 4607,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ALT_M_1 = 4608,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ALT_M_2 = 4609,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ALT_M_3 = 4610,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ROLL_FUS_DEG_0 = 4611,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ROLL_FUS_DEG_1 = 4612,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ROLL_FUS_DEG_2 = 4613,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ROLL_FUS_DEG_3 = 4614,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_PITCH_FUS_DEG_0 = 4615,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_PITCH_FUS_DEG_1 = 4616,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_PITCH_FUS_DEG_2 = 4617,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_PITCH_FUS_DEG_3 = 4618,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_YAW_FUS_DEG_0 = 4619,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_YAW_FUS_DEG_1 = 4620,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_YAW_FUS_DEG_2 = 4621,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_YAW_FUS_DEG_3 = 4622,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_SPEED_MPS_0 = 4623,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_SPEED_MPS_1 = 4624,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_SPEED_MPS_2 = 4625,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_SPEED_MPS_3 = 4626,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_QUALITY_SPEED = 4627,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ODO_DX_M_0 = 4628,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ODO_DX_M_1 = 4629,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ODO_DX_M_2 = 4630,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ODO_DX_M_3 = 4631,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ODO_DY_M_0 = 4632,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ODO_DY_M_1 = 4633,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ODO_DY_M_2 = 4634,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ODO_DY_M_3 = 4635,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_STATUS_FLAGS = 4636,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_UPDATE_MASK_0 = 4637,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_UPDATE_MASK_1 = 4638,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_EXCUTION_TIME_MS = 4639,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_IS_NEW_DATA = 4640,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ACTIVE = 4641,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_SUMMARY_STATUS_0 = 4642,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_SUMMARY_STATUS_1 = 4643,
            PARAMETER_MB_ADDR_IBNS_SPEED_SETTING_ENABLE = 4644,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_IS_NEW_DATA = 4645,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_EULER_RAD_0_0 = 4646,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_EULER_RAD_0_1 = 4647,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_EULER_RAD_0_2 = 4648,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_EULER_RAD_0_3 = 4649,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_EULER_RAD_1_0 = 4650,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_EULER_RAD_1_1 = 4651,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_EULER_RAD_1_2 = 4652,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_EULER_RAD_1_3 = 4653,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_EULER_RAD_2_0 = 4654,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_EULER_RAD_2_1 = 4655,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_EULER_RAD_2_2 = 4656,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_EULER_RAD_2_3 = 4657,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_COURSE_RAD_0 = 4658,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_COURSE_RAD_1 = 4659,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_COURSE_RAD_2 = 4660,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_COURSE_RAD_3 = 4661,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_ACC_ENU_MPS2_0_0 = 4662,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_ACC_ENU_MPS2_0_1 = 4663,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_ACC_ENU_MPS2_0_2 = 4664,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_ACC_ENU_MPS2_0_3 = 4665,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_ACC_ENU_MPS2_1_0 = 4666,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_ACC_ENU_MPS2_1_1 = 4667,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_ACC_ENU_MPS2_1_2 = 4668,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_ACC_ENU_MPS2_1_3 = 4669,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_ACC_ENU_MPS2_2_0 = 4670,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_ACC_ENU_MPS2_2_1 = 4671,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_ACC_ENU_MPS2_2_2 = 4672,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_ACC_ENU_MPS2_2_3 = 4673,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_GYRO_ENU_RPS_0_0 = 4674,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_GYRO_ENU_RPS_0_1 = 4675,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_GYRO_ENU_RPS_0_2 = 4676,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_GYRO_ENU_RPS_0_3 = 4677,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_GYRO_ENU_RPS_1_0 = 4678,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_GYRO_ENU_RPS_1_1 = 4679,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_GYRO_ENU_RPS_1_2 = 4680,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_GYRO_ENU_RPS_1_3 = 4681,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_GYRO_ENU_RPS_2_0 = 4682,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_GYRO_ENU_RPS_2_1 = 4683,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_GYRO_ENU_RPS_2_2 = 4684,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_GYRO_ENU_RPS_2_3 = 4685,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_STATUS = 4686,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_LLA_RRM_0_0 = 4687,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_LLA_RRM_0_1 = 4688,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_LLA_RRM_0_2 = 4689,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_LLA_RRM_0_3 = 4690,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_LLA_RRM_1_0 = 4691,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_LLA_RRM_1_1 = 4692,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_LLA_RRM_1_2 = 4693,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_LLA_RRM_1_3 = 4694,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_LLA_RRM_2_0 = 4695,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_LLA_RRM_2_1 = 4696,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_LLA_RRM_2_2 = 4697,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_LLA_RRM_2_3 = 4698,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_VEL_ENU_0_0 = 4699,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_VEL_ENU_0_1 = 4700,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_VEL_ENU_0_2 = 4701,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_VEL_ENU_0_3 = 4702,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_VEL_ENU_1_0 = 4703,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_VEL_ENU_1_1 = 4704,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_VEL_ENU_1_2 = 4705,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_VEL_ENU_1_3 = 4706,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_VEL_ENU_2_0 = 4707,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_VEL_ENU_2_1 = 4708,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_VEL_ENU_2_2 = 4709,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_VEL_ENU_2_3 = 4710,
            PARAMETER_MB_ADDR_SADRA_DATA_GPS_FRAME_IS_NEW_DATA = 4711,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_I_TOW_0 = 4712,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_I_TOW_1 = 4713,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_F_TOW_0 = 4714,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_F_TOW_1 = 4715,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_NUM_SV = 4716,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_WEEK = 4717,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_GPSFIX = 4718,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_FLAG = 4719,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_POS_ECEF_0_0 = 4720,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_POS_ECEF_0_1 = 4721,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_POS_ECEF_0_2 = 4722,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_POS_ECEF_0_3 = 4723,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_POS_ECEF_1_0 = 4724,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_POS_ECEF_1_1 = 4725,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_POS_ECEF_1_2 = 4726,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_POS_ECEF_1_3 = 4727,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_POS_ECEF_2_0 = 4728,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_POS_ECEF_2_1 = 4729,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_POS_ECEF_2_2 = 4730,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_POS_ECEF_2_3 = 4731,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_VEL_ECEF_0_0 = 4732,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_VEL_ECEF_0_1 = 4733,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_VEL_ECEF_1_0 = 4734,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_VEL_ECEF_1_1 = 4735,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_VEL_ECEF_2_0 = 4736,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_VEL_ECEF_2_1 = 4737,
            PARAMETER_MB_ADDR_SADRA_DATA_ACTIVE = 4738,
            PARAMETER_MB_ADDR_SADRA_DATA_SUMMARY_STATUS_0 = 4739,
            PARAMETER_MB_ADDR_SADRA_DATA_SUMMARY_STATUS_1 = 4740,
            PARAMETER_MB_ADDR_SADRA_SETTING_ENABLE = 4741,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_US_0 = 4742,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_US_1 = 4743,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_MAXIMA_US_0 = 4744,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_MAXIMA_US_1 = 4745,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_MINIMA_US_0 = 4746,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_MINIMA_US_1 = 4747,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_LIMIT_EXCEED_COUNTER_0 = 4748,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_LIMIT_EXCEED_COUNTER_1 = 4749,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_INTERVAL_TIMING_ERROR = 4750,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_EXECUTION_TIME_US_0 = 4751,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_EXECUTION_TIME_US_1 = 4752,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_EXECUTION_TIME_MAXIMA_US_0 = 4753,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_EXECUTION_TIME_MAXIMA_US_1 = 4754,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_EXECUTION_TIME_MINIMA_US_0 = 4755,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_EXECUTION_TIME_MINIMA_US_1 = 4756,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_RUN_COUNTER_0 = 4757,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_RUN_COUNTER_1 = 4758,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_SETTING_INTERVAL_TIME_NOMINAL_US_0 = 4759,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_SETTING_INTERVAL_TIME_NOMINAL_US_1 = 4760,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_SETTING_INTERVAL_TIME_MAX_ALLOWED_JITTER_US_0 = 4761,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_SETTING_INTERVAL_TIME_MAX_ALLOWED_JITTER_US_1 = 4762,
            PARAMETER_MB_ADDR_CALC_VERSION_MAJOR = 4763,
            PARAMETER_MB_ADDR_CALC_VERSION_MINOR = 4764,
            PARAMETER_MB_ADDR_CALC_VERSION_BUILD1 = 4765,
            PARAMETER_MB_ADDR_CALC_VERSION_BUILD2_0 = 4766,
            PARAMETER_MB_ADDR_CALC_VERSION_BUILD2_1 = 4767,
            PARAMETER_MB_ADDR_CALC_STATUS_0 = 4768,
            PARAMETER_MB_ADDR_CALC_STATUS_1 = 4769,
            PARAMETER_MB_ADDR_CALC_FREQ_HZ = 4770,
            PARAMETER_MB_ADDR_CALC_COUNTER_0 = 4771,
            PARAMETER_MB_ADDR_CALC_COUNTER_1 = 4772,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_0_0 = 4773,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_0_1 = 4774,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_0_2 = 4775,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_0_3 = 4776,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_1_0 = 4777,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_1_1 = 4778,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_1_2 = 4779,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_1_3 = 4780,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_2_0 = 4781,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_2_1 = 4782,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_2_2 = 4783,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_2_3 = 4784,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_3_0 = 4785,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_3_1 = 4786,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_3_2 = 4787,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_3_3 = 4788,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_4_0 = 4789,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_4_1 = 4790,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_4_2 = 4791,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_4_3 = 4792,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_5_0 = 4793,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_5_1 = 4794,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_5_2 = 4795,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_5_3 = 4796,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_6_0 = 4797,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_6_1 = 4798,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_6_2 = 4799,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_6_3 = 4800,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_7_0 = 4801,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_7_1 = 4802,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_7_2 = 4803,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_7_3 = 4804,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_8_0 = 4805,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_8_1 = 4806,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_8_2 = 4807,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_8_3 = 4808,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_9_0 = 4809,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_9_1 = 4810,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_9_2 = 4811,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_9_3 = 4812,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_10_0 = 4813,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_10_1 = 4814,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_10_2 = 4815,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_10_3 = 4816,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_11_0 = 4817,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_11_1 = 4818,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_11_2 = 4819,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_11_3 = 4820,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_12_0 = 4821,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_12_1 = 4822,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_12_2 = 4823,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_12_3 = 4824,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_13_0 = 4825,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_13_1 = 4826,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_13_2 = 4827,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_13_3 = 4828,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_14_0 = 4829,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_14_1 = 4830,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_14_2 = 4831,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_14_3 = 4832,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_15_0 = 4833,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_15_1 = 4834,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_15_2 = 4835,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_15_3 = 4836,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_16_0 = 4837,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_16_1 = 4838,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_16_2 = 4839,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_16_3 = 4840,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_17_0 = 4841,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_17_1 = 4842,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_17_2 = 4843,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_17_3 = 4844,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_18_0 = 4845,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_18_1 = 4846,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_18_2 = 4847,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_18_3 = 4848,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_19_0 = 4849,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_19_1 = 4850,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_19_2 = 4851,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_19_3 = 4852,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_20_0 = 4853,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_20_1 = 4854,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_20_2 = 4855,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_20_3 = 4856,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_21_0 = 4857,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_21_1 = 4858,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_21_2 = 4859,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_21_3 = 4860,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_22_0 = 4861,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_22_1 = 4862,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_22_2 = 4863,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_22_3 = 4864,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_23_0 = 4865,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_23_1 = 4866,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_23_2 = 4867,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_23_3 = 4868,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_24_0 = 4869,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_24_1 = 4870,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_24_2 = 4871,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_24_3 = 4872,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_25_0 = 4873,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_25_1 = 4874,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_25_2 = 4875,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_25_3 = 4876,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_26_0 = 4877,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_26_1 = 4878,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_26_2 = 4879,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_26_3 = 4880,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_27_0 = 4881,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_27_1 = 4882,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_27_2 = 4883,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_27_3 = 4884,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_28_0 = 4885,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_28_1 = 4886,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_28_2 = 4887,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_28_3 = 4888,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_29_0 = 4889,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_29_1 = 4890,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_29_2 = 4891,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_29_3 = 4892,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_30_0 = 4893,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_30_1 = 4894,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_30_2 = 4895,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_30_3 = 4896,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_31_0 = 4897,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_31_1 = 4898,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_31_2 = 4899,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_31_3 = 4900,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_32_0 = 4901,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_32_1 = 4902,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_32_2 = 4903,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_32_3 = 4904,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_33_0 = 4905,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_33_1 = 4906,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_33_2 = 4907,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_33_3 = 4908,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_34_0 = 4909,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_34_1 = 4910,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_34_2 = 4911,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_34_3 = 4912,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_35_0 = 4913,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_35_1 = 4914,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_35_2 = 4915,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_35_3 = 4916,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_36_0 = 4917,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_36_1 = 4918,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_36_2 = 4919,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_36_3 = 4920,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_37_0 = 4921,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_37_1 = 4922,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_37_2 = 4923,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_37_3 = 4924,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_38_0 = 4925,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_38_1 = 4926,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_38_2 = 4927,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_38_3 = 4928,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_39_0 = 4929,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_39_1 = 4930,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_39_2 = 4931,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_39_3 = 4932,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_40_0 = 4933,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_40_1 = 4934,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_40_2 = 4935,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_40_3 = 4936,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_41_0 = 4937,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_41_1 = 4938,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_41_2 = 4939,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_41_3 = 4940,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_42_0 = 4941,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_42_1 = 4942,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_42_2 = 4943,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_42_3 = 4944,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_43_0 = 4945,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_43_1 = 4946,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_43_2 = 4947,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_43_3 = 4948,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_44_0 = 4949,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_44_1 = 4950,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_44_2 = 4951,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_44_3 = 4952,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_45_0 = 4953,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_45_1 = 4954,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_45_2 = 4955,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_45_3 = 4956,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_46_0 = 4957,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_46_1 = 4958,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_46_2 = 4959,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_46_3 = 4960,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_47_0 = 4961,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_47_1 = 4962,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_47_2 = 4963,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_47_3 = 4964,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_48_0 = 4965,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_48_1 = 4966,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_48_2 = 4967,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_48_3 = 4968,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_49_0 = 4969,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_49_1 = 4970,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_49_2 = 4971,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F64_49_3 = 4972,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_0_0 = 4973,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_0_1 = 4974,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_1_0 = 4975,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_1_1 = 4976,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_2_0 = 4977,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_2_1 = 4978,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_3_0 = 4979,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_3_1 = 4980,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_4_0 = 4981,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_4_1 = 4982,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_5_0 = 4983,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_5_1 = 4984,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_6_0 = 4985,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_6_1 = 4986,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_7_0 = 4987,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_7_1 = 4988,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_8_0 = 4989,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_8_1 = 4990,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_9_0 = 4991,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_9_1 = 4992,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_10_0 = 4993,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_10_1 = 4994,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_11_0 = 4995,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_11_1 = 4996,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_12_0 = 4997,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_12_1 = 4998,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_13_0 = 4999,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_13_1 = 5000,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_14_0 = 5001,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_14_1 = 5002,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_15_0 = 5003,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_15_1 = 5004,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_16_0 = 5005,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_16_1 = 5006,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_17_0 = 5007,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_17_1 = 5008,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_18_0 = 5009,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_18_1 = 5010,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_19_0 = 5011,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_19_1 = 5012,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_20_0 = 5013,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_20_1 = 5014,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_21_0 = 5015,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_21_1 = 5016,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_22_0 = 5017,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_22_1 = 5018,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_23_0 = 5019,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_23_1 = 5020,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_24_0 = 5021,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_24_1 = 5022,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_25_0 = 5023,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_25_1 = 5024,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_26_0 = 5025,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_26_1 = 5026,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_27_0 = 5027,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_27_1 = 5028,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_28_0 = 5029,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_28_1 = 5030,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_29_0 = 5031,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_29_1 = 5032,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_30_0 = 5033,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_30_1 = 5034,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_31_0 = 5035,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_31_1 = 5036,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_32_0 = 5037,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_32_1 = 5038,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_33_0 = 5039,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_33_1 = 5040,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_34_0 = 5041,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_34_1 = 5042,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_35_0 = 5043,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_35_1 = 5044,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_36_0 = 5045,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_36_1 = 5046,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_37_0 = 5047,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_37_1 = 5048,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_38_0 = 5049,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_38_1 = 5050,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_39_0 = 5051,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_39_1 = 5052,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_40_0 = 5053,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_40_1 = 5054,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_41_0 = 5055,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_41_1 = 5056,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_42_0 = 5057,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_42_1 = 5058,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_43_0 = 5059,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_43_1 = 5060,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_44_0 = 5061,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_44_1 = 5062,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_45_0 = 5063,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_45_1 = 5064,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_46_0 = 5065,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_46_1 = 5066,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_47_0 = 5067,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_47_1 = 5068,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_48_0 = 5069,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_48_1 = 5070,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_49_0 = 5071,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_F32_49_1 = 5072,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_0_0 = 5073,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_0_1 = 5074,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_1_0 = 5075,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_1_1 = 5076,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_2_0 = 5077,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_2_1 = 5078,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_3_0 = 5079,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_3_1 = 5080,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_4_0 = 5081,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_4_1 = 5082,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_5_0 = 5083,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_5_1 = 5084,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_6_0 = 5085,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_6_1 = 5086,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_7_0 = 5087,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_7_1 = 5088,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_8_0 = 5089,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_8_1 = 5090,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_9_0 = 5091,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_9_1 = 5092,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_10_0 = 5093,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_10_1 = 5094,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_11_0 = 5095,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_11_1 = 5096,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_12_0 = 5097,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_12_1 = 5098,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_13_0 = 5099,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_13_1 = 5100,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_14_0 = 5101,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_14_1 = 5102,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_15_0 = 5103,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_15_1 = 5104,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_16_0 = 5105,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_16_1 = 5106,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_17_0 = 5107,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_17_1 = 5108,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_18_0 = 5109,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_18_1 = 5110,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_19_0 = 5111,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_19_1 = 5112,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_20_0 = 5113,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_20_1 = 5114,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_21_0 = 5115,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_21_1 = 5116,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_22_0 = 5117,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_22_1 = 5118,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_23_0 = 5119,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_23_1 = 5120,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_24_0 = 5121,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_24_1 = 5122,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_25_0 = 5123,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_25_1 = 5124,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_26_0 = 5125,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_26_1 = 5126,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_27_0 = 5127,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_27_1 = 5128,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_28_0 = 5129,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_28_1 = 5130,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_29_0 = 5131,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_29_1 = 5132,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_30_0 = 5133,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_30_1 = 5134,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_31_0 = 5135,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_31_1 = 5136,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_32_0 = 5137,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_32_1 = 5138,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_33_0 = 5139,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_33_1 = 5140,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_34_0 = 5141,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_34_1 = 5142,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_35_0 = 5143,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_35_1 = 5144,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_36_0 = 5145,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_36_1 = 5146,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_37_0 = 5147,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_37_1 = 5148,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_38_0 = 5149,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_38_1 = 5150,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_39_0 = 5151,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_39_1 = 5152,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_40_0 = 5153,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_40_1 = 5154,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_41_0 = 5155,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_41_1 = 5156,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_42_0 = 5157,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_42_1 = 5158,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_43_0 = 5159,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_43_1 = 5160,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_44_0 = 5161,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_44_1 = 5162,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_45_0 = 5163,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_45_1 = 5164,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_46_0 = 5165,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_46_1 = 5166,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_47_0 = 5167,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_47_1 = 5168,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_48_0 = 5169,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_48_1 = 5170,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_49_0 = 5171,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U32_49_1 = 5172,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_0_0 = 5173,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_0_1 = 5174,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_1_0 = 5175,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_1_1 = 5176,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_2_0 = 5177,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_2_1 = 5178,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_3_0 = 5179,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_3_1 = 5180,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_4_0 = 5181,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_4_1 = 5182,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_5_0 = 5183,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_5_1 = 5184,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_6_0 = 5185,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_6_1 = 5186,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_7_0 = 5187,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_7_1 = 5188,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_8_0 = 5189,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_8_1 = 5190,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_9_0 = 5191,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_9_1 = 5192,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_10_0 = 5193,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_10_1 = 5194,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_11_0 = 5195,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_11_1 = 5196,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_12_0 = 5197,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_12_1 = 5198,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_13_0 = 5199,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_13_1 = 5200,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_14_0 = 5201,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_14_1 = 5202,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_15_0 = 5203,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_15_1 = 5204,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_16_0 = 5205,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_16_1 = 5206,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_17_0 = 5207,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_17_1 = 5208,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_18_0 = 5209,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_18_1 = 5210,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_19_0 = 5211,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_19_1 = 5212,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_20_0 = 5213,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_20_1 = 5214,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_21_0 = 5215,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_21_1 = 5216,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_22_0 = 5217,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_22_1 = 5218,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_23_0 = 5219,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_23_1 = 5220,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_24_0 = 5221,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_24_1 = 5222,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_25_0 = 5223,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_25_1 = 5224,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_26_0 = 5225,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_26_1 = 5226,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_27_0 = 5227,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_27_1 = 5228,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_28_0 = 5229,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_28_1 = 5230,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_29_0 = 5231,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_29_1 = 5232,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_30_0 = 5233,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_30_1 = 5234,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_31_0 = 5235,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_31_1 = 5236,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_32_0 = 5237,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_32_1 = 5238,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_33_0 = 5239,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_33_1 = 5240,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_34_0 = 5241,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_34_1 = 5242,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_35_0 = 5243,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_35_1 = 5244,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_36_0 = 5245,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_36_1 = 5246,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_37_0 = 5247,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_37_1 = 5248,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_38_0 = 5249,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_38_1 = 5250,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_39_0 = 5251,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_39_1 = 5252,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_40_0 = 5253,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_40_1 = 5254,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_41_0 = 5255,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_41_1 = 5256,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_42_0 = 5257,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_42_1 = 5258,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_43_0 = 5259,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_43_1 = 5260,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_44_0 = 5261,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_44_1 = 5262,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_45_0 = 5263,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_45_1 = 5264,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_46_0 = 5265,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_46_1 = 5266,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_47_0 = 5267,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_47_1 = 5268,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_48_0 = 5269,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_48_1 = 5270,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_49_0 = 5271,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I32_49_1 = 5272,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_0 = 5273,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_1 = 5274,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_2 = 5275,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_3 = 5276,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_4 = 5277,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_5 = 5278,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_6 = 5279,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_7 = 5280,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_8 = 5281,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_9 = 5282,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_10 = 5283,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_11 = 5284,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_12 = 5285,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_13 = 5286,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_14 = 5287,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_15 = 5288,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_16 = 5289,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_17 = 5290,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_18 = 5291,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_19 = 5292,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_20 = 5293,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_21 = 5294,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_22 = 5295,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_23 = 5296,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_24 = 5297,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_25 = 5298,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_26 = 5299,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_27 = 5300,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_28 = 5301,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_29 = 5302,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_30 = 5303,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_31 = 5304,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_32 = 5305,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_33 = 5306,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_34 = 5307,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_35 = 5308,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_36 = 5309,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_37 = 5310,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_38 = 5311,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_39 = 5312,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_40 = 5313,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_41 = 5314,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_42 = 5315,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_43 = 5316,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_44 = 5317,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_45 = 5318,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_46 = 5319,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_47 = 5320,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_48 = 5321,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_U16_49 = 5322,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_0 = 5323,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_1 = 5324,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_2 = 5325,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_3 = 5326,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_4 = 5327,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_5 = 5328,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_6 = 5329,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_7 = 5330,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_8 = 5331,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_9 = 5332,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_10 = 5333,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_11 = 5334,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_12 = 5335,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_13 = 5336,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_14 = 5337,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_15 = 5338,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_16 = 5339,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_17 = 5340,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_18 = 5341,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_19 = 5342,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_20 = 5343,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_21 = 5344,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_22 = 5345,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_23 = 5346,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_24 = 5347,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_25 = 5348,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_26 = 5349,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_27 = 5350,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_28 = 5351,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_29 = 5352,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_30 = 5353,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_31 = 5354,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_32 = 5355,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_33 = 5356,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_34 = 5357,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_35 = 5358,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_36 = 5359,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_37 = 5360,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_38 = 5361,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_39 = 5362,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_40 = 5363,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_41 = 5364,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_42 = 5365,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_43 = 5366,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_44 = 5367,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_45 = 5368,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_46 = 5369,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_47 = 5370,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_48 = 5371,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_I16_49 = 5372,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_0_0 = 5373,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_0_1 = 5374,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_0_2 = 5375,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_0_3 = 5376,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_1_0 = 5377,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_1_1 = 5378,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_1_2 = 5379,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_1_3 = 5380,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_2_0 = 5381,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_2_1 = 5382,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_2_2 = 5383,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_2_3 = 5384,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_3_0 = 5385,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_3_1 = 5386,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_3_2 = 5387,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_3_3 = 5388,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_4_0 = 5389,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_4_1 = 5390,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_4_2 = 5391,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_4_3 = 5392,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_5_0 = 5393,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_5_1 = 5394,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_5_2 = 5395,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_5_3 = 5396,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_6_0 = 5397,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_6_1 = 5398,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_6_2 = 5399,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_6_3 = 5400,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_7_0 = 5401,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_7_1 = 5402,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_7_2 = 5403,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_7_3 = 5404,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_8_0 = 5405,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_8_1 = 5406,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_8_2 = 5407,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_8_3 = 5408,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_9_0 = 5409,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_9_1 = 5410,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_9_2 = 5411,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_9_3 = 5412,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_10_0 = 5413,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_10_1 = 5414,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_10_2 = 5415,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_10_3 = 5416,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_11_0 = 5417,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_11_1 = 5418,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_11_2 = 5419,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_11_3 = 5420,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_12_0 = 5421,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_12_1 = 5422,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_12_2 = 5423,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_12_3 = 5424,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_13_0 = 5425,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_13_1 = 5426,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_13_2 = 5427,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_13_3 = 5428,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_14_0 = 5429,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_14_1 = 5430,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_14_2 = 5431,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_14_3 = 5432,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_15_0 = 5433,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_15_1 = 5434,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_15_2 = 5435,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_15_3 = 5436,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_16_0 = 5437,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_16_1 = 5438,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_16_2 = 5439,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_16_3 = 5440,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_17_0 = 5441,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_17_1 = 5442,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_17_2 = 5443,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_17_3 = 5444,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_18_0 = 5445,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_18_1 = 5446,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_18_2 = 5447,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_18_3 = 5448,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_19_0 = 5449,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_19_1 = 5450,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_19_2 = 5451,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_19_3 = 5452,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_20_0 = 5453,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_20_1 = 5454,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_20_2 = 5455,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_20_3 = 5456,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_21_0 = 5457,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_21_1 = 5458,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_21_2 = 5459,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_21_3 = 5460,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_22_0 = 5461,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_22_1 = 5462,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_22_2 = 5463,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_22_3 = 5464,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_23_0 = 5465,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_23_1 = 5466,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_23_2 = 5467,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_23_3 = 5468,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_24_0 = 5469,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_24_1 = 5470,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_24_2 = 5471,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_24_3 = 5472,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_25_0 = 5473,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_25_1 = 5474,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_25_2 = 5475,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_25_3 = 5476,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_26_0 = 5477,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_26_1 = 5478,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_26_2 = 5479,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_26_3 = 5480,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_27_0 = 5481,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_27_1 = 5482,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_27_2 = 5483,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_27_3 = 5484,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_28_0 = 5485,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_28_1 = 5486,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_28_2 = 5487,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_28_3 = 5488,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_29_0 = 5489,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_29_1 = 5490,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_29_2 = 5491,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_29_3 = 5492,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_30_0 = 5493,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_30_1 = 5494,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_30_2 = 5495,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_30_3 = 5496,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_31_0 = 5497,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_31_1 = 5498,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_31_2 = 5499,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_31_3 = 5500,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_32_0 = 5501,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_32_1 = 5502,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_32_2 = 5503,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_32_3 = 5504,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_33_0 = 5505,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_33_1 = 5506,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_33_2 = 5507,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_33_3 = 5508,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_34_0 = 5509,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_34_1 = 5510,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_34_2 = 5511,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_34_3 = 5512,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_35_0 = 5513,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_35_1 = 5514,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_35_2 = 5515,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_35_3 = 5516,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_36_0 = 5517,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_36_1 = 5518,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_36_2 = 5519,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_36_3 = 5520,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_37_0 = 5521,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_37_1 = 5522,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_37_2 = 5523,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_37_3 = 5524,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_38_0 = 5525,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_38_1 = 5526,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_38_2 = 5527,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_38_3 = 5528,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_39_0 = 5529,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_39_1 = 5530,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_39_2 = 5531,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_39_3 = 5532,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_40_0 = 5533,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_40_1 = 5534,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_40_2 = 5535,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_40_3 = 5536,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_41_0 = 5537,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_41_1 = 5538,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_41_2 = 5539,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_41_3 = 5540,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_42_0 = 5541,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_42_1 = 5542,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_42_2 = 5543,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_42_3 = 5544,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_43_0 = 5545,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_43_1 = 5546,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_43_2 = 5547,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_43_3 = 5548,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_44_0 = 5549,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_44_1 = 5550,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_44_2 = 5551,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_44_3 = 5552,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_45_0 = 5553,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_45_1 = 5554,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_45_2 = 5555,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_45_3 = 5556,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_46_0 = 5557,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_46_1 = 5558,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_46_2 = 5559,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_46_3 = 5560,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_47_0 = 5561,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_47_1 = 5562,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_47_2 = 5563,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_47_3 = 5564,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_48_0 = 5565,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_48_1 = 5566,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_48_2 = 5567,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_48_3 = 5568,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_49_0 = 5569,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_49_1 = 5570,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_49_2 = 5571,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F64_49_3 = 5572,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_0_0 = 5573,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_0_1 = 5574,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_1_0 = 5575,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_1_1 = 5576,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_2_0 = 5577,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_2_1 = 5578,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_3_0 = 5579,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_3_1 = 5580,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_4_0 = 5581,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_4_1 = 5582,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_5_0 = 5583,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_5_1 = 5584,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_6_0 = 5585,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_6_1 = 5586,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_7_0 = 5587,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_7_1 = 5588,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_8_0 = 5589,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_8_1 = 5590,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_9_0 = 5591,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_9_1 = 5592,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_10_0 = 5593,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_10_1 = 5594,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_11_0 = 5595,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_11_1 = 5596,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_12_0 = 5597,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_12_1 = 5598,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_13_0 = 5599,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_13_1 = 5600,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_14_0 = 5601,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_14_1 = 5602,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_15_0 = 5603,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_15_1 = 5604,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_16_0 = 5605,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_16_1 = 5606,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_17_0 = 5607,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_17_1 = 5608,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_18_0 = 5609,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_18_1 = 5610,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_19_0 = 5611,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_19_1 = 5612,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_20_0 = 5613,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_20_1 = 5614,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_21_0 = 5615,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_21_1 = 5616,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_22_0 = 5617,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_22_1 = 5618,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_23_0 = 5619,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_23_1 = 5620,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_24_0 = 5621,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_24_1 = 5622,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_25_0 = 5623,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_25_1 = 5624,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_26_0 = 5625,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_26_1 = 5626,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_27_0 = 5627,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_27_1 = 5628,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_28_0 = 5629,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_28_1 = 5630,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_29_0 = 5631,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_29_1 = 5632,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_30_0 = 5633,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_30_1 = 5634,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_31_0 = 5635,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_31_1 = 5636,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_32_0 = 5637,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_32_1 = 5638,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_33_0 = 5639,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_33_1 = 5640,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_34_0 = 5641,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_34_1 = 5642,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_35_0 = 5643,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_35_1 = 5644,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_36_0 = 5645,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_36_1 = 5646,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_37_0 = 5647,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_37_1 = 5648,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_38_0 = 5649,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_38_1 = 5650,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_39_0 = 5651,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_39_1 = 5652,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_40_0 = 5653,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_40_1 = 5654,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_41_0 = 5655,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_41_1 = 5656,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_42_0 = 5657,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_42_1 = 5658,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_43_0 = 5659,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_43_1 = 5660,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_44_0 = 5661,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_44_1 = 5662,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_45_0 = 5663,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_45_1 = 5664,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_46_0 = 5665,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_46_1 = 5666,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_47_0 = 5667,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_47_1 = 5668,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_48_0 = 5669,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_48_1 = 5670,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_49_0 = 5671,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_F32_49_1 = 5672,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_0_0 = 5673,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_0_1 = 5674,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_1_0 = 5675,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_1_1 = 5676,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_2_0 = 5677,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_2_1 = 5678,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_3_0 = 5679,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_3_1 = 5680,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_4_0 = 5681,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_4_1 = 5682,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_5_0 = 5683,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_5_1 = 5684,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_6_0 = 5685,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_6_1 = 5686,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_7_0 = 5687,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_7_1 = 5688,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_8_0 = 5689,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_8_1 = 5690,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_9_0 = 5691,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_9_1 = 5692,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_10_0 = 5693,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_10_1 = 5694,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_11_0 = 5695,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_11_1 = 5696,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_12_0 = 5697,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_12_1 = 5698,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_13_0 = 5699,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_13_1 = 5700,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_14_0 = 5701,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_14_1 = 5702,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_15_0 = 5703,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_15_1 = 5704,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_16_0 = 5705,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_16_1 = 5706,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_17_0 = 5707,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_17_1 = 5708,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_18_0 = 5709,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_18_1 = 5710,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_19_0 = 5711,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_19_1 = 5712,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_20_0 = 5713,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_20_1 = 5714,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_21_0 = 5715,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_21_1 = 5716,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_22_0 = 5717,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_22_1 = 5718,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_23_0 = 5719,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_23_1 = 5720,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_24_0 = 5721,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_24_1 = 5722,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_25_0 = 5723,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_25_1 = 5724,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_26_0 = 5725,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_26_1 = 5726,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_27_0 = 5727,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_27_1 = 5728,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_28_0 = 5729,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_28_1 = 5730,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_29_0 = 5731,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_29_1 = 5732,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_30_0 = 5733,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_30_1 = 5734,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_31_0 = 5735,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_31_1 = 5736,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_32_0 = 5737,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_32_1 = 5738,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_33_0 = 5739,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_33_1 = 5740,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_34_0 = 5741,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_34_1 = 5742,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_35_0 = 5743,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_35_1 = 5744,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_36_0 = 5745,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_36_1 = 5746,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_37_0 = 5747,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_37_1 = 5748,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_38_0 = 5749,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_38_1 = 5750,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_39_0 = 5751,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_39_1 = 5752,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_40_0 = 5753,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_40_1 = 5754,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_41_0 = 5755,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_41_1 = 5756,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_42_0 = 5757,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_42_1 = 5758,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_43_0 = 5759,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_43_1 = 5760,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_44_0 = 5761,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_44_1 = 5762,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_45_0 = 5763,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_45_1 = 5764,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_46_0 = 5765,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_46_1 = 5766,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_47_0 = 5767,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_47_1 = 5768,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_48_0 = 5769,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_48_1 = 5770,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_49_0 = 5771,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U32_49_1 = 5772,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_0_0 = 5773,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_0_1 = 5774,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_1_0 = 5775,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_1_1 = 5776,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_2_0 = 5777,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_2_1 = 5778,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_3_0 = 5779,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_3_1 = 5780,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_4_0 = 5781,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_4_1 = 5782,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_5_0 = 5783,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_5_1 = 5784,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_6_0 = 5785,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_6_1 = 5786,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_7_0 = 5787,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_7_1 = 5788,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_8_0 = 5789,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_8_1 = 5790,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_9_0 = 5791,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_9_1 = 5792,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_10_0 = 5793,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_10_1 = 5794,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_11_0 = 5795,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_11_1 = 5796,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_12_0 = 5797,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_12_1 = 5798,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_13_0 = 5799,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_13_1 = 5800,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_14_0 = 5801,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_14_1 = 5802,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_15_0 = 5803,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_15_1 = 5804,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_16_0 = 5805,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_16_1 = 5806,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_17_0 = 5807,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_17_1 = 5808,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_18_0 = 5809,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_18_1 = 5810,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_19_0 = 5811,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_19_1 = 5812,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_20_0 = 5813,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_20_1 = 5814,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_21_0 = 5815,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_21_1 = 5816,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_22_0 = 5817,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_22_1 = 5818,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_23_0 = 5819,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_23_1 = 5820,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_24_0 = 5821,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_24_1 = 5822,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_25_0 = 5823,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_25_1 = 5824,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_26_0 = 5825,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_26_1 = 5826,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_27_0 = 5827,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_27_1 = 5828,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_28_0 = 5829,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_28_1 = 5830,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_29_0 = 5831,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_29_1 = 5832,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_30_0 = 5833,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_30_1 = 5834,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_31_0 = 5835,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_31_1 = 5836,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_32_0 = 5837,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_32_1 = 5838,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_33_0 = 5839,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_33_1 = 5840,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_34_0 = 5841,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_34_1 = 5842,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_35_0 = 5843,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_35_1 = 5844,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_36_0 = 5845,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_36_1 = 5846,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_37_0 = 5847,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_37_1 = 5848,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_38_0 = 5849,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_38_1 = 5850,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_39_0 = 5851,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_39_1 = 5852,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_40_0 = 5853,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_40_1 = 5854,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_41_0 = 5855,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_41_1 = 5856,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_42_0 = 5857,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_42_1 = 5858,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_43_0 = 5859,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_43_1 = 5860,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_44_0 = 5861,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_44_1 = 5862,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_45_0 = 5863,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_45_1 = 5864,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_46_0 = 5865,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_46_1 = 5866,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_47_0 = 5867,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_47_1 = 5868,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_48_0 = 5869,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_48_1 = 5870,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_49_0 = 5871,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_I32_49_1 = 5872,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_0 = 5873,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_1 = 5874,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_2 = 5875,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_3 = 5876,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_4 = 5877,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_5 = 5878,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_6 = 5879,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_7 = 5880,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_8 = 5881,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_9 = 5882,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_10 = 5883,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_11 = 5884,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_12 = 5885,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_13 = 5886,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_14 = 5887,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_15 = 5888,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_16 = 5889,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_17 = 5890,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_18 = 5891,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_19 = 5892,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_20 = 5893,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_21 = 5894,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_22 = 5895,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_23 = 5896,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_24 = 5897,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_25 = 5898,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_26 = 5899,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_27 = 5900,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_28 = 5901,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_29 = 5902,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_30 = 5903,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_31 = 5904,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_32 = 5905,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_33 = 5906,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_34 = 5907,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_35 = 5908,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_36 = 5909,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_37 = 5910,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_38 = 5911,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_39 = 5912,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_40 = 5913,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_41 = 5914,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_42 = 5915,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_43 = 5916,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_44 = 5917,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_45 = 5918,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_46 = 5919,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_47 = 5920,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_48 = 5921,
            PARAMETER_MB_ADDR_DEBUG_CONTROL_SIGNALS_U16_49 = 5922,
            PARAMETER_MB_ADDR_ZUPTUSE = 5923,
            PARAMETER_MB_ADDR_GNSSUSE = 5924,
            PARAMETER_MB_ADDR_AIR_DATA_ALL_USE = 5925,
            PARAMETER_MB_ADDR_AIR_DATA_SPEED_USE = 5926,
            PARAMETER_MB_ADDR_AIR_DATA_ALTITUDE_USE = 5927,
            PARAMETER_MB_ADDR_VISION_USE = 5928,
            PARAMETER_MB_ADDR_MAG_USE = 5929,
            PARAMETER_MB_ADDR_ALGORITHM_RESET = 5930,
            PARAMETER_MB_ADDR_FLIGHT_ZERO = 5931,
            PARAMETER_MB_ADDR_ARM = 5932,
            PARAMETER_MB_ADDR_ALGORITHM_TYPE = 5933,
            PARAMETER_MB_ADDR_GNSSTYPE = 5934,
            PARAMETER_MB_ADDR_HEAD_TYPE = 5935,
            PARAMETER_MB_ADDR_ALIGN_TYPE = 5936,
            PARAMETER_MB_ADDR_NSENSOR = 5937,
            PARAMETER_MB_ADDR_INIT_IDLE_TIME_0 = 5938,
            PARAMETER_MB_ADDR_INIT_IDLE_TIME_1 = 5939,
            PARAMETER_MB_ADDR_INIT_IDLE_TIME_2 = 5940,
            PARAMETER_MB_ADDR_INIT_IDLE_TIME_3 = 5941,
            PARAMETER_MB_ADDR_INIT_LLA_RRM_0_0 = 5942,
            PARAMETER_MB_ADDR_INIT_LLA_RRM_0_1 = 5943,
            PARAMETER_MB_ADDR_INIT_LLA_RRM_0_2 = 5944,
            PARAMETER_MB_ADDR_INIT_LLA_RRM_0_3 = 5945,
            PARAMETER_MB_ADDR_INIT_LLA_RRM_1_0 = 5946,
            PARAMETER_MB_ADDR_INIT_LLA_RRM_1_1 = 5947,
            PARAMETER_MB_ADDR_INIT_LLA_RRM_1_2 = 5948,
            PARAMETER_MB_ADDR_INIT_LLA_RRM_1_3 = 5949,
            PARAMETER_MB_ADDR_INIT_LLA_RRM_2_0 = 5950,
            PARAMETER_MB_ADDR_INIT_LLA_RRM_2_1 = 5951,
            PARAMETER_MB_ADDR_INIT_LLA_RRM_2_2 = 5952,
            PARAMETER_MB_ADDR_INIT_LLA_RRM_2_3 = 5953,
            PARAMETER_MB_ADDR_INIT_HEAD_RAD_0 = 5954,
            PARAMETER_MB_ADDR_INIT_HEAD_RAD_1 = 5955,
            PARAMETER_MB_ADDR_INIT_HEAD_RAD_2 = 5956,
            PARAMETER_MB_ADDR_INIT_HEAD_RAD_3 = 5957,
            PARAMETER_MB_ADDR_ALIGN_TIME_S_0 = 5958,
            PARAMETER_MB_ADDR_ALIGN_TIME_S_1 = 5959,
            PARAMETER_MB_ADDR_ALIGN_TIME_S_2 = 5960,
            PARAMETER_MB_ADDR_ALIGN_TIME_S_3 = 5961,
            PARAMETER_MB_ADDR_REL_AZ_RAD_0 = 5962,
            PARAMETER_MB_ADDR_REL_AZ_RAD_1 = 5963,
            PARAMETER_MB_ADDR_REL_AZ_RAD_2 = 5964,
            PARAMETER_MB_ADDR_REL_AZ_RAD_3 = 5965,
            PARAMETER_MB_ADDR_SPEED0_MPS_0 = 5966,
            PARAMETER_MB_ADDR_SPEED0_MPS_1 = 5967,
            PARAMETER_MB_ADDR_SPEED0_MPS_2 = 5968,
            PARAMETER_MB_ADDR_SPEED0_MPS_3 = 5969,
            PARAMETER_MB_ADDR_EULER0_RAD_0_0 = 5970,
            PARAMETER_MB_ADDR_EULER0_RAD_0_1 = 5971,
            PARAMETER_MB_ADDR_EULER0_RAD_0_2 = 5972,
            PARAMETER_MB_ADDR_EULER0_RAD_0_3 = 5973,
            PARAMETER_MB_ADDR_EULER0_RAD_1_0 = 5974,
            PARAMETER_MB_ADDR_EULER0_RAD_1_1 = 5975,
            PARAMETER_MB_ADDR_EULER0_RAD_1_2 = 5976,
            PARAMETER_MB_ADDR_EULER0_RAD_1_3 = 5977,
            PARAMETER_MB_ADDR_EULER0_RAD_2_0 = 5978,
            PARAMETER_MB_ADDR_EULER0_RAD_2_1 = 5979,
            PARAMETER_MB_ADDR_EULER0_RAD_2_2 = 5980,
            PARAMETER_MB_ADDR_EULER0_RAD_2_3 = 5981,
            PARAMETER_MB_ADDR_RUN_TIME_S_0 = 5982,
            PARAMETER_MB_ADDR_RUN_TIME_S_1 = 5983,
            PARAMETER_MB_ADDR_RUN_TIME_S_2 = 5984,
            PARAMETER_MB_ADDR_RUN_TIME_S_3 = 5985,
            PARAMETER_MB_ADDR_CURRENT_STATE = 5986,
            PARAMETER_MB_ADDR_OBS_TYPE = 5987,
            PARAMETER_MB_ADDR_CARRIER_TYPE = 5988,
            PARAMETER_MB_ADDR_CONTROL_FLAGS_BITS_SUMMARY_0 = 5989,
            PARAMETER_MB_ADDR_CONTROL_FLAGS_BITS_SUMMARY_1 = 5990,
            PARAMETER_MB_ADDR_ALIGN_COUNTER_0 = 5991,
            PARAMETER_MB_ADDR_ALIGN_COUNTER_1 = 5992,
            PARAMETER_MB_ADDR_ALIGN_ACC_AVERAGE_0_0 = 5993,
            PARAMETER_MB_ADDR_ALIGN_ACC_AVERAGE_0_1 = 5994,
            PARAMETER_MB_ADDR_ALIGN_ACC_AVERAGE_0_2 = 5995,
            PARAMETER_MB_ADDR_ALIGN_ACC_AVERAGE_0_3 = 5996,
            PARAMETER_MB_ADDR_ALIGN_ACC_AVERAGE_1_0 = 5997,
            PARAMETER_MB_ADDR_ALIGN_ACC_AVERAGE_1_1 = 5998,
            PARAMETER_MB_ADDR_ALIGN_ACC_AVERAGE_1_2 = 5999,
            PARAMETER_MB_ADDR_ALIGN_ACC_AVERAGE_1_3 = 6000,
            PARAMETER_MB_ADDR_ALIGN_ACC_AVERAGE_2_0 = 6001,
            PARAMETER_MB_ADDR_ALIGN_ACC_AVERAGE_2_1 = 6002,
            PARAMETER_MB_ADDR_ALIGN_ACC_AVERAGE_2_2 = 6003,
            PARAMETER_MB_ADDR_ALIGN_ACC_AVERAGE_2_3 = 6004,
            PARAMETER_MB_ADDR_ALIGN_GYR_AVERAGE_0_0 = 6005,
            PARAMETER_MB_ADDR_ALIGN_GYR_AVERAGE_0_1 = 6006,
            PARAMETER_MB_ADDR_ALIGN_GYR_AVERAGE_0_2 = 6007,
            PARAMETER_MB_ADDR_ALIGN_GYR_AVERAGE_0_3 = 6008,
            PARAMETER_MB_ADDR_ALIGN_GYR_AVERAGE_1_0 = 6009,
            PARAMETER_MB_ADDR_ALIGN_GYR_AVERAGE_1_1 = 6010,
            PARAMETER_MB_ADDR_ALIGN_GYR_AVERAGE_1_2 = 6011,
            PARAMETER_MB_ADDR_ALIGN_GYR_AVERAGE_1_3 = 6012,
            PARAMETER_MB_ADDR_ALIGN_GYR_AVERAGE_2_0 = 6013,
            PARAMETER_MB_ADDR_ALIGN_GYR_AVERAGE_2_1 = 6014,
            PARAMETER_MB_ADDR_ALIGN_GYR_AVERAGE_2_2 = 6015,
            PARAMETER_MB_ADDR_ALIGN_GYR_AVERAGE_2_3 = 6016,
            PARAMETER_MB_ADDR_ALIGN_EULER0_0_0 = 6017,
            PARAMETER_MB_ADDR_ALIGN_EULER0_0_1 = 6018,
            PARAMETER_MB_ADDR_ALIGN_EULER0_0_2 = 6019,
            PARAMETER_MB_ADDR_ALIGN_EULER0_0_3 = 6020,
            PARAMETER_MB_ADDR_ALIGN_EULER0_1_0 = 6021,
            PARAMETER_MB_ADDR_ALIGN_EULER0_1_1 = 6022,
            PARAMETER_MB_ADDR_ALIGN_EULER0_1_2 = 6023,
            PARAMETER_MB_ADDR_ALIGN_EULER0_1_3 = 6024,
            PARAMETER_MB_ADDR_ALIGN_EULER0_2_0 = 6025,
            PARAMETER_MB_ADDR_ALIGN_EULER0_2_1 = 6026,
            PARAMETER_MB_ADDR_ALIGN_EULER0_2_2 = 6027,
            PARAMETER_MB_ADDR_ALIGN_EULER0_2_3 = 6028,
            PARAMETER_MB_ADDR_ALIGN_QUAT0_0_0 = 6029,
            PARAMETER_MB_ADDR_ALIGN_QUAT0_0_1 = 6030,
            PARAMETER_MB_ADDR_ALIGN_QUAT0_0_2 = 6031,
            PARAMETER_MB_ADDR_ALIGN_QUAT0_0_3 = 6032,
            PARAMETER_MB_ADDR_ALIGN_QUAT0_1_0 = 6033,
            PARAMETER_MB_ADDR_ALIGN_QUAT0_1_1 = 6034,
            PARAMETER_MB_ADDR_ALIGN_QUAT0_1_2 = 6035,
            PARAMETER_MB_ADDR_ALIGN_QUAT0_1_3 = 6036,
            PARAMETER_MB_ADDR_ALIGN_QUAT0_2_0 = 6037,
            PARAMETER_MB_ADDR_ALIGN_QUAT0_2_1 = 6038,
            PARAMETER_MB_ADDR_ALIGN_QUAT0_2_2 = 6039,
            PARAMETER_MB_ADDR_ALIGN_QUAT0_2_3 = 6040,
            PARAMETER_MB_ADDR_ALIGN_QUAT0_3_0 = 6041,
            PARAMETER_MB_ADDR_ALIGN_QUAT0_3_1 = 6042,
            PARAMETER_MB_ADDR_ALIGN_QUAT0_3_2 = 6043,
            PARAMETER_MB_ADDR_ALIGN_QUAT0_3_3 = 6044,
            PARAMETER_MB_ADDR_ALIGN_GYR_NORM0_0 = 6045,
            PARAMETER_MB_ADDR_ALIGN_GYR_NORM0_1 = 6046,
            PARAMETER_MB_ADDR_ALIGN_GYR_NORM0_2 = 6047,
            PARAMETER_MB_ADDR_ALIGN_GYR_NORM0_3 = 6048,
            PARAMETER_MB_ADDR_ALIGN_ACC_NORM0_0 = 6049,
            PARAMETER_MB_ADDR_ALIGN_ACC_NORM0_1 = 6050,
            PARAMETER_MB_ADDR_ALIGN_ACC_NORM0_2 = 6051,
            PARAMETER_MB_ADDR_ALIGN_ACC_NORM0_3 = 6052,
            PARAMETER_MB_ADDR_ALIGN_GYR_ERR0_0_0 = 6053,
            PARAMETER_MB_ADDR_ALIGN_GYR_ERR0_0_1 = 6054,
            PARAMETER_MB_ADDR_ALIGN_GYR_ERR0_0_2 = 6055,
            PARAMETER_MB_ADDR_ALIGN_GYR_ERR0_0_3 = 6056,
            PARAMETER_MB_ADDR_ALIGN_GYR_ERR0_1_0 = 6057,
            PARAMETER_MB_ADDR_ALIGN_GYR_ERR0_1_1 = 6058,
            PARAMETER_MB_ADDR_ALIGN_GYR_ERR0_1_2 = 6059,
            PARAMETER_MB_ADDR_ALIGN_GYR_ERR0_1_3 = 6060,
            PARAMETER_MB_ADDR_ALIGN_GYR_ERR0_2_0 = 6061,
            PARAMETER_MB_ADDR_ALIGN_GYR_ERR0_2_1 = 6062,
            PARAMETER_MB_ADDR_ALIGN_GYR_ERR0_2_2 = 6063,
            PARAMETER_MB_ADDR_ALIGN_GYR_ERR0_2_3 = 6064,
            PARAMETER_MB_ADDR_NAV_COUNTER_0 = 6065,
            PARAMETER_MB_ADDR_NAV_COUNTER_1 = 6066,
            PARAMETER_MB_ADDR_NAV_QUAT_0_0 = 6067,
            PARAMETER_MB_ADDR_NAV_QUAT_0_1 = 6068,
            PARAMETER_MB_ADDR_NAV_QUAT_0_2 = 6069,
            PARAMETER_MB_ADDR_NAV_QUAT_0_3 = 6070,
            PARAMETER_MB_ADDR_NAV_QUAT_1_0 = 6071,
            PARAMETER_MB_ADDR_NAV_QUAT_1_1 = 6072,
            PARAMETER_MB_ADDR_NAV_QUAT_1_2 = 6073,
            PARAMETER_MB_ADDR_NAV_QUAT_1_3 = 6074,
            PARAMETER_MB_ADDR_NAV_QUAT_2_0 = 6075,
            PARAMETER_MB_ADDR_NAV_QUAT_2_1 = 6076,
            PARAMETER_MB_ADDR_NAV_QUAT_2_2 = 6077,
            PARAMETER_MB_ADDR_NAV_QUAT_2_3 = 6078,
            PARAMETER_MB_ADDR_NAV_QUAT_3_0 = 6079,
            PARAMETER_MB_ADDR_NAV_QUAT_3_1 = 6080,
            PARAMETER_MB_ADDR_NAV_QUAT_3_2 = 6081,
            PARAMETER_MB_ADDR_NAV_QUAT_3_3 = 6082,
            PARAMETER_MB_ADDR_NAV_EULER_0_0 = 6083,
            PARAMETER_MB_ADDR_NAV_EULER_0_1 = 6084,
            PARAMETER_MB_ADDR_NAV_EULER_0_2 = 6085,
            PARAMETER_MB_ADDR_NAV_EULER_0_3 = 6086,
            PARAMETER_MB_ADDR_NAV_EULER_1_0 = 6087,
            PARAMETER_MB_ADDR_NAV_EULER_1_1 = 6088,
            PARAMETER_MB_ADDR_NAV_EULER_1_2 = 6089,
            PARAMETER_MB_ADDR_NAV_EULER_1_3 = 6090,
            PARAMETER_MB_ADDR_NAV_EULER_2_0 = 6091,
            PARAMETER_MB_ADDR_NAV_EULER_2_1 = 6092,
            PARAMETER_MB_ADDR_NAV_EULER_2_2 = 6093,
            PARAMETER_MB_ADDR_NAV_EULER_2_3 = 6094,
            PARAMETER_MB_ADDR_NAV_V_NED_0_0 = 6095,
            PARAMETER_MB_ADDR_NAV_V_NED_0_1 = 6096,
            PARAMETER_MB_ADDR_NAV_V_NED_0_2 = 6097,
            PARAMETER_MB_ADDR_NAV_V_NED_0_3 = 6098,
            PARAMETER_MB_ADDR_NAV_V_NED_1_0 = 6099,
            PARAMETER_MB_ADDR_NAV_V_NED_1_1 = 6100,
            PARAMETER_MB_ADDR_NAV_V_NED_1_2 = 6101,
            PARAMETER_MB_ADDR_NAV_V_NED_1_3 = 6102,
            PARAMETER_MB_ADDR_NAV_V_NED_2_0 = 6103,
            PARAMETER_MB_ADDR_NAV_V_NED_2_1 = 6104,
            PARAMETER_MB_ADDR_NAV_V_NED_2_2 = 6105,
            PARAMETER_MB_ADDR_NAV_V_NED_2_3 = 6106,
            PARAMETER_MB_ADDR_NAV_LLA_0_0 = 6107,
            PARAMETER_MB_ADDR_NAV_LLA_0_1 = 6108,
            PARAMETER_MB_ADDR_NAV_LLA_0_2 = 6109,
            PARAMETER_MB_ADDR_NAV_LLA_0_3 = 6110,
            PARAMETER_MB_ADDR_NAV_LLA_1_0 = 6111,
            PARAMETER_MB_ADDR_NAV_LLA_1_1 = 6112,
            PARAMETER_MB_ADDR_NAV_LLA_1_2 = 6113,
            PARAMETER_MB_ADDR_NAV_LLA_1_3 = 6114,
            PARAMETER_MB_ADDR_NAV_LLA_2_0 = 6115,
            PARAMETER_MB_ADDR_NAV_LLA_2_1 = 6116,
            PARAMETER_MB_ADDR_NAV_LLA_2_2 = 6117,
            PARAMETER_MB_ADDR_NAV_LLA_2_3 = 6118,
            PARAMETER_MB_ADDR_NAV_R_NED_0_0 = 6119,
            PARAMETER_MB_ADDR_NAV_R_NED_0_1 = 6120,
            PARAMETER_MB_ADDR_NAV_R_NED_0_2 = 6121,
            PARAMETER_MB_ADDR_NAV_R_NED_0_3 = 6122,
            PARAMETER_MB_ADDR_NAV_R_NED_1_0 = 6123,
            PARAMETER_MB_ADDR_NAV_R_NED_1_1 = 6124,
            PARAMETER_MB_ADDR_NAV_R_NED_1_2 = 6125,
            PARAMETER_MB_ADDR_NAV_R_NED_1_3 = 6126,
            PARAMETER_MB_ADDR_NAV_R_NED_2_0 = 6127,
            PARAMETER_MB_ADDR_NAV_R_NED_2_1 = 6128,
            PARAMETER_MB_ADDR_NAV_R_NED_2_2 = 6129,
            PARAMETER_MB_ADDR_NAV_R_NED_2_3 = 6130,
            PARAMETER_MB_ADDR_FUS_COUNTER_0 = 6131,
            PARAMETER_MB_ADDR_FUS_COUNTER_1 = 6132,
            PARAMETER_MB_ADDR_FUS_EULER_0_0 = 6133,
            PARAMETER_MB_ADDR_FUS_EULER_0_1 = 6134,
            PARAMETER_MB_ADDR_FUS_EULER_0_2 = 6135,
            PARAMETER_MB_ADDR_FUS_EULER_0_3 = 6136,
            PARAMETER_MB_ADDR_FUS_EULER_1_0 = 6137,
            PARAMETER_MB_ADDR_FUS_EULER_1_1 = 6138,
            PARAMETER_MB_ADDR_FUS_EULER_1_2 = 6139,
            PARAMETER_MB_ADDR_FUS_EULER_1_3 = 6140,
            PARAMETER_MB_ADDR_FUS_EULER_2_0 = 6141,
            PARAMETER_MB_ADDR_FUS_EULER_2_1 = 6142,
            PARAMETER_MB_ADDR_FUS_EULER_2_2 = 6143,
            PARAMETER_MB_ADDR_FUS_EULER_2_3 = 6144,
            PARAMETER_MB_ADDR_FUS_QUAT_0_0 = 6145,
            PARAMETER_MB_ADDR_FUS_QUAT_0_1 = 6146,
            PARAMETER_MB_ADDR_FUS_QUAT_0_2 = 6147,
            PARAMETER_MB_ADDR_FUS_QUAT_0_3 = 6148,
            PARAMETER_MB_ADDR_FUS_QUAT_1_0 = 6149,
            PARAMETER_MB_ADDR_FUS_QUAT_1_1 = 6150,
            PARAMETER_MB_ADDR_FUS_QUAT_1_2 = 6151,
            PARAMETER_MB_ADDR_FUS_QUAT_1_3 = 6152,
            PARAMETER_MB_ADDR_FUS_QUAT_2_0 = 6153,
            PARAMETER_MB_ADDR_FUS_QUAT_2_1 = 6154,
            PARAMETER_MB_ADDR_FUS_QUAT_2_2 = 6155,
            PARAMETER_MB_ADDR_FUS_QUAT_2_3 = 6156,
            PARAMETER_MB_ADDR_FUS_QUAT_3_0 = 6157,
            PARAMETER_MB_ADDR_FUS_QUAT_3_1 = 6158,
            PARAMETER_MB_ADDR_FUS_QUAT_3_2 = 6159,
            PARAMETER_MB_ADDR_FUS_QUAT_3_3 = 6160,
            PARAMETER_MB_ADDR_FUS_V_NED_0_0 = 6161,
            PARAMETER_MB_ADDR_FUS_V_NED_0_1 = 6162,
            PARAMETER_MB_ADDR_FUS_V_NED_0_2 = 6163,
            PARAMETER_MB_ADDR_FUS_V_NED_0_3 = 6164,
            PARAMETER_MB_ADDR_FUS_V_NED_1_0 = 6165,
            PARAMETER_MB_ADDR_FUS_V_NED_1_1 = 6166,
            PARAMETER_MB_ADDR_FUS_V_NED_1_2 = 6167,
            PARAMETER_MB_ADDR_FUS_V_NED_1_3 = 6168,
            PARAMETER_MB_ADDR_FUS_V_NED_2_0 = 6169,
            PARAMETER_MB_ADDR_FUS_V_NED_2_1 = 6170,
            PARAMETER_MB_ADDR_FUS_V_NED_2_2 = 6171,
            PARAMETER_MB_ADDR_FUS_V_NED_2_3 = 6172,
            PARAMETER_MB_ADDR_FUS_LLA_0_0 = 6173,
            PARAMETER_MB_ADDR_FUS_LLA_0_1 = 6174,
            PARAMETER_MB_ADDR_FUS_LLA_0_2 = 6175,
            PARAMETER_MB_ADDR_FUS_LLA_0_3 = 6176,
            PARAMETER_MB_ADDR_FUS_LLA_1_0 = 6177,
            PARAMETER_MB_ADDR_FUS_LLA_1_1 = 6178,
            PARAMETER_MB_ADDR_FUS_LLA_1_2 = 6179,
            PARAMETER_MB_ADDR_FUS_LLA_1_3 = 6180,
            PARAMETER_MB_ADDR_FUS_LLA_2_0 = 6181,
            PARAMETER_MB_ADDR_FUS_LLA_2_1 = 6182,
            PARAMETER_MB_ADDR_FUS_LLA_2_2 = 6183,
            PARAMETER_MB_ADDR_FUS_LLA_2_3 = 6184,
            PARAMETER_MB_ADDR_FUS_BA_0_0 = 6185,
            PARAMETER_MB_ADDR_FUS_BA_0_1 = 6186,
            PARAMETER_MB_ADDR_FUS_BA_0_2 = 6187,
            PARAMETER_MB_ADDR_FUS_BA_0_3 = 6188,
            PARAMETER_MB_ADDR_FUS_BA_1_0 = 6189,
            PARAMETER_MB_ADDR_FUS_BA_1_1 = 6190,
            PARAMETER_MB_ADDR_FUS_BA_1_2 = 6191,
            PARAMETER_MB_ADDR_FUS_BA_1_3 = 6192,
            PARAMETER_MB_ADDR_FUS_BA_2_0 = 6193,
            PARAMETER_MB_ADDR_FUS_BA_2_1 = 6194,
            PARAMETER_MB_ADDR_FUS_BA_2_2 = 6195,
            PARAMETER_MB_ADDR_FUS_BA_2_3 = 6196,
            PARAMETER_MB_ADDR_FUS_BG_0_0 = 6197,
            PARAMETER_MB_ADDR_FUS_BG_0_1 = 6198,
            PARAMETER_MB_ADDR_FUS_BG_0_2 = 6199,
            PARAMETER_MB_ADDR_FUS_BG_0_3 = 6200,
            PARAMETER_MB_ADDR_FUS_BG_1_0 = 6201,
            PARAMETER_MB_ADDR_FUS_BG_1_1 = 6202,
            PARAMETER_MB_ADDR_FUS_BG_1_2 = 6203,
            PARAMETER_MB_ADDR_FUS_BG_1_3 = 6204,
            PARAMETER_MB_ADDR_FUS_BG_2_0 = 6205,
            PARAMETER_MB_ADDR_FUS_BG_2_1 = 6206,
            PARAMETER_MB_ADDR_FUS_BG_2_2 = 6207,
            PARAMETER_MB_ADDR_FUS_BG_2_3 = 6208,
            PARAMETER_MB_ADDR_FUS_PSI_CC_0_0 = 6209,
            PARAMETER_MB_ADDR_FUS_PSI_CC_0_1 = 6210,
            PARAMETER_MB_ADDR_FUS_PSI_CC_0_2 = 6211,
            PARAMETER_MB_ADDR_FUS_PSI_CC_0_3 = 6212,
            PARAMETER_MB_ADDR_FUS_PSI_CC_1_0 = 6213,
            PARAMETER_MB_ADDR_FUS_PSI_CC_1_1 = 6214,
            PARAMETER_MB_ADDR_FUS_PSI_CC_1_2 = 6215,
            PARAMETER_MB_ADDR_FUS_PSI_CC_1_3 = 6216,
            PARAMETER_MB_ADDR_FUS_PSI_CC_2_0 = 6217,
            PARAMETER_MB_ADDR_FUS_PSI_CC_2_1 = 6218,
            PARAMETER_MB_ADDR_FUS_PSI_CC_2_2 = 6219,
            PARAMETER_MB_ADDR_FUS_PSI_CC_2_3 = 6220,
            PARAMETER_MB_ADDR_FUS_RESET_CNT_0 = 6221,
            PARAMETER_MB_ADDR_FUS_RESET_CNT_1 = 6222,
            PARAMETER_MB_ADDR_QUAT_0_0 = 6223,
            PARAMETER_MB_ADDR_QUAT_0_1 = 6224,
            PARAMETER_MB_ADDR_QUAT_0_2 = 6225,
            PARAMETER_MB_ADDR_QUAT_0_3 = 6226,
            PARAMETER_MB_ADDR_QUAT_1_0 = 6227,
            PARAMETER_MB_ADDR_QUAT_1_1 = 6228,
            PARAMETER_MB_ADDR_QUAT_1_2 = 6229,
            PARAMETER_MB_ADDR_QUAT_1_3 = 6230,
            PARAMETER_MB_ADDR_QUAT_2_0 = 6231,
            PARAMETER_MB_ADDR_QUAT_2_1 = 6232,
            PARAMETER_MB_ADDR_QUAT_2_2 = 6233,
            PARAMETER_MB_ADDR_QUAT_2_3 = 6234,
            PARAMETER_MB_ADDR_QUAT_3_0 = 6235,
            PARAMETER_MB_ADDR_QUAT_3_1 = 6236,
            PARAMETER_MB_ADDR_QUAT_3_2 = 6237,
            PARAMETER_MB_ADDR_QUAT_3_3 = 6238,
            PARAMETER_MB_ADDR_EULER_0_0 = 6239,
            PARAMETER_MB_ADDR_EULER_0_1 = 6240,
            PARAMETER_MB_ADDR_EULER_0_2 = 6241,
            PARAMETER_MB_ADDR_EULER_0_3 = 6242,
            PARAMETER_MB_ADDR_EULER_1_0 = 6243,
            PARAMETER_MB_ADDR_EULER_1_1 = 6244,
            PARAMETER_MB_ADDR_EULER_1_2 = 6245,
            PARAMETER_MB_ADDR_EULER_1_3 = 6246,
            PARAMETER_MB_ADDR_EULER_2_0 = 6247,
            PARAMETER_MB_ADDR_EULER_2_1 = 6248,
            PARAMETER_MB_ADDR_EULER_2_2 = 6249,
            PARAMETER_MB_ADDR_EULER_2_3 = 6250,
            PARAMETER_MB_ADDR_OUTPUT_COUNTER_0 = 6251,
            PARAMETER_MB_ADDR_OUTPUT_COUNTER_1 = 6252,
            PARAMETER_MB_ADDR_OUTPUT_BOOT_TIME_MS = 6253,
            PARAMETER_MB_ADDR_CHIP_STABILIZATION_CYCLE_QTY = 6254,
            PARAMETER_MB_ADDR_OUTPUT_STABILIZATION_CYCLE_QTY = 6255,
            PARAMETER_MB_ADDR_SEND_LOG_START = 6256,
            PARAMETER_MB_ADDR_SEND_LOG_STOP = 6257,
            PARAMETER_MB_ADDR_ERASE_ALL_LOGS = 6258,
            PARAMETER_MB_ADDR_LOG_TIME_ELAPSED_S_0 = 6259,
            PARAMETER_MB_ADDR_LOG_TIME_ELAPSED_S_1 = 6260,
            PARAMETER_MB_ADDR_TOTAL_SESSIONS_QTY = 6261,
            PARAMETER_MB_ADDR_TOTAL_RECORDS_QTY_0 = 6262,
            PARAMETER_MB_ADDR_TOTAL_RECORDS_QTY_1 = 6263,
            PARAMETER_MB_ADDR_TOTAL_PAYLOADS_SIZE_BYTE_0 = 6264,
            PARAMETER_MB_ADDR_TOTAL_PAYLOADS_SIZE_BYTE_1 = 6265,
            PARAMETER_MB_ADDR_CURRENT_SESSION_RECORDS_QTY_0 = 6266,
            PARAMETER_MB_ADDR_CURRENT_SESSION_RECORDS_QTY_1 = 6267,
            PARAMETER_MB_ADDR_CURRENT_SESSION_PAYLOADS_SIZE_BYTE_0 = 6268,
            PARAMETER_MB_ADDR_CURRENT_SESSION_PAYLOADS_SIZE_BYTE_1 = 6269,
            PARAMETER_MB_ADDR_TOTAL_SESSIONS_CAPACITY = 6270,
            PARAMETER_MB_ADDR_TOTAL_RECORDS_CAPACITY_0 = 6271,
            PARAMETER_MB_ADDR_TOTAL_RECORDS_CAPACITY_1 = 6272,
            PARAMETER_MB_ADDR_TOTAL_PAYLOADS_CAPACITY_BYTE_0 = 6273,
            PARAMETER_MB_ADDR_TOTAL_PAYLOADS_CAPACITY_BYTE_1 = 6274,
            PARAMETER_MB_ADDR_SEND_LOG_REMAIN_RECORDS_QTY_0 = 6275,
            PARAMETER_MB_ADDR_SEND_LOG_REMAIN_RECORDS_QTY_1 = 6276,
            PARAMETER_MB_ADDR_SESSION_DATA_0_SESSION_ID = 6277,
            PARAMETER_MB_ADDR_SESSION_DATA_0_RECORDS_OCCUPIED_QTY_0 = 6278,
            PARAMETER_MB_ADDR_SESSION_DATA_0_RECORDS_OCCUPIED_QTY_1 = 6279,
            PARAMETER_MB_ADDR_SESSION_DATA_0_PAYLOADS_OCCUPIED_SIZE_0 = 6280,
            PARAMETER_MB_ADDR_SESSION_DATA_0_PAYLOADS_OCCUPIED_SIZE_1 = 6281,
            PARAMETER_MB_ADDR_SESSION_DATA_0_RECORDS_DURATION_US_0 = 6282,
            PARAMETER_MB_ADDR_SESSION_DATA_0_RECORDS_DURATION_US_1 = 6283,
            PARAMETER_MB_ADDR_SESSION_DATA_1_SESSION_ID = 6284,
            PARAMETER_MB_ADDR_SESSION_DATA_1_RECORDS_OCCUPIED_QTY_0 = 6285,
            PARAMETER_MB_ADDR_SESSION_DATA_1_RECORDS_OCCUPIED_QTY_1 = 6286,
            PARAMETER_MB_ADDR_SESSION_DATA_1_PAYLOADS_OCCUPIED_SIZE_0 = 6287,
            PARAMETER_MB_ADDR_SESSION_DATA_1_PAYLOADS_OCCUPIED_SIZE_1 = 6288,
            PARAMETER_MB_ADDR_SESSION_DATA_1_RECORDS_DURATION_US_0 = 6289,
            PARAMETER_MB_ADDR_SESSION_DATA_1_RECORDS_DURATION_US_1 = 6290,
            PARAMETER_MB_ADDR_SESSION_DATA_2_SESSION_ID = 6291,
            PARAMETER_MB_ADDR_SESSION_DATA_2_RECORDS_OCCUPIED_QTY_0 = 6292,
            PARAMETER_MB_ADDR_SESSION_DATA_2_RECORDS_OCCUPIED_QTY_1 = 6293,
            PARAMETER_MB_ADDR_SESSION_DATA_2_PAYLOADS_OCCUPIED_SIZE_0 = 6294,
            PARAMETER_MB_ADDR_SESSION_DATA_2_PAYLOADS_OCCUPIED_SIZE_1 = 6295,
            PARAMETER_MB_ADDR_SESSION_DATA_2_RECORDS_DURATION_US_0 = 6296,
            PARAMETER_MB_ADDR_SESSION_DATA_2_RECORDS_DURATION_US_1 = 6297,
            PARAMETER_MB_ADDR_SESSION_DATA_3_SESSION_ID = 6298,
            PARAMETER_MB_ADDR_SESSION_DATA_3_RECORDS_OCCUPIED_QTY_0 = 6299,
            PARAMETER_MB_ADDR_SESSION_DATA_3_RECORDS_OCCUPIED_QTY_1 = 6300,
            PARAMETER_MB_ADDR_SESSION_DATA_3_PAYLOADS_OCCUPIED_SIZE_0 = 6301,
            PARAMETER_MB_ADDR_SESSION_DATA_3_PAYLOADS_OCCUPIED_SIZE_1 = 6302,
            PARAMETER_MB_ADDR_SESSION_DATA_3_RECORDS_DURATION_US_0 = 6303,
            PARAMETER_MB_ADDR_SESSION_DATA_3_RECORDS_DURATION_US_1 = 6304,
            PARAMETER_MB_ADDR_SESSION_DATA_4_SESSION_ID = 6305,
            PARAMETER_MB_ADDR_SESSION_DATA_4_RECORDS_OCCUPIED_QTY_0 = 6306,
            PARAMETER_MB_ADDR_SESSION_DATA_4_RECORDS_OCCUPIED_QTY_1 = 6307,
            PARAMETER_MB_ADDR_SESSION_DATA_4_PAYLOADS_OCCUPIED_SIZE_0 = 6308,
            PARAMETER_MB_ADDR_SESSION_DATA_4_PAYLOADS_OCCUPIED_SIZE_1 = 6309,
            PARAMETER_MB_ADDR_SESSION_DATA_4_RECORDS_DURATION_US_0 = 6310,
            PARAMETER_MB_ADDR_SESSION_DATA_4_RECORDS_DURATION_US_1 = 6311,
            PARAMETER_MB_ADDR_SESSION_DATA_5_SESSION_ID = 6312,
            PARAMETER_MB_ADDR_SESSION_DATA_5_RECORDS_OCCUPIED_QTY_0 = 6313,
            PARAMETER_MB_ADDR_SESSION_DATA_5_RECORDS_OCCUPIED_QTY_1 = 6314,
            PARAMETER_MB_ADDR_SESSION_DATA_5_PAYLOADS_OCCUPIED_SIZE_0 = 6315,
            PARAMETER_MB_ADDR_SESSION_DATA_5_PAYLOADS_OCCUPIED_SIZE_1 = 6316,
            PARAMETER_MB_ADDR_SESSION_DATA_5_RECORDS_DURATION_US_0 = 6317,
            PARAMETER_MB_ADDR_SESSION_DATA_5_RECORDS_DURATION_US_1 = 6318,
            PARAMETER_MB_ADDR_SESSION_DATA_6_SESSION_ID = 6319,
            PARAMETER_MB_ADDR_SESSION_DATA_6_RECORDS_OCCUPIED_QTY_0 = 6320,
            PARAMETER_MB_ADDR_SESSION_DATA_6_RECORDS_OCCUPIED_QTY_1 = 6321,
            PARAMETER_MB_ADDR_SESSION_DATA_6_PAYLOADS_OCCUPIED_SIZE_0 = 6322,
            PARAMETER_MB_ADDR_SESSION_DATA_6_PAYLOADS_OCCUPIED_SIZE_1 = 6323,
            PARAMETER_MB_ADDR_SESSION_DATA_6_RECORDS_DURATION_US_0 = 6324,
            PARAMETER_MB_ADDR_SESSION_DATA_6_RECORDS_DURATION_US_1 = 6325,
            PARAMETER_MB_ADDR_SESSION_DATA_7_SESSION_ID = 6326,
            PARAMETER_MB_ADDR_SESSION_DATA_7_RECORDS_OCCUPIED_QTY_0 = 6327,
            PARAMETER_MB_ADDR_SESSION_DATA_7_RECORDS_OCCUPIED_QTY_1 = 6328,
            PARAMETER_MB_ADDR_SESSION_DATA_7_PAYLOADS_OCCUPIED_SIZE_0 = 6329,
            PARAMETER_MB_ADDR_SESSION_DATA_7_PAYLOADS_OCCUPIED_SIZE_1 = 6330,
            PARAMETER_MB_ADDR_SESSION_DATA_7_RECORDS_DURATION_US_0 = 6331,
            PARAMETER_MB_ADDR_SESSION_DATA_7_RECORDS_DURATION_US_1 = 6332,
            PARAMETER_MB_ADDR_SESSION_DATA_8_SESSION_ID = 6333,
            PARAMETER_MB_ADDR_SESSION_DATA_8_RECORDS_OCCUPIED_QTY_0 = 6334,
            PARAMETER_MB_ADDR_SESSION_DATA_8_RECORDS_OCCUPIED_QTY_1 = 6335,
            PARAMETER_MB_ADDR_SESSION_DATA_8_PAYLOADS_OCCUPIED_SIZE_0 = 6336,
            PARAMETER_MB_ADDR_SESSION_DATA_8_PAYLOADS_OCCUPIED_SIZE_1 = 6337,
            PARAMETER_MB_ADDR_SESSION_DATA_8_RECORDS_DURATION_US_0 = 6338,
            PARAMETER_MB_ADDR_SESSION_DATA_8_RECORDS_DURATION_US_1 = 6339,
            PARAMETER_MB_ADDR_SESSION_DATA_9_SESSION_ID = 6340,
            PARAMETER_MB_ADDR_SESSION_DATA_9_RECORDS_OCCUPIED_QTY_0 = 6341,
            PARAMETER_MB_ADDR_SESSION_DATA_9_RECORDS_OCCUPIED_QTY_1 = 6342,
            PARAMETER_MB_ADDR_SESSION_DATA_9_PAYLOADS_OCCUPIED_SIZE_0 = 6343,
            PARAMETER_MB_ADDR_SESSION_DATA_9_PAYLOADS_OCCUPIED_SIZE_1 = 6344,
            PARAMETER_MB_ADDR_SESSION_DATA_9_RECORDS_DURATION_US_0 = 6345,
            PARAMETER_MB_ADDR_SESSION_DATA_9_RECORDS_DURATION_US_1 = 6346,
            PARAMETER_MB_ADDR_SESSION_DATA_10_SESSION_ID = 6347,
            PARAMETER_MB_ADDR_SESSION_DATA_10_RECORDS_OCCUPIED_QTY_0 = 6348,
            PARAMETER_MB_ADDR_SESSION_DATA_10_RECORDS_OCCUPIED_QTY_1 = 6349,
            PARAMETER_MB_ADDR_SESSION_DATA_10_PAYLOADS_OCCUPIED_SIZE_0 = 6350,
            PARAMETER_MB_ADDR_SESSION_DATA_10_PAYLOADS_OCCUPIED_SIZE_1 = 6351,
            PARAMETER_MB_ADDR_SESSION_DATA_10_RECORDS_DURATION_US_0 = 6352,
            PARAMETER_MB_ADDR_SESSION_DATA_10_RECORDS_DURATION_US_1 = 6353,
            PARAMETER_MB_ADDR_SESSION_DATA_11_SESSION_ID = 6354,
            PARAMETER_MB_ADDR_SESSION_DATA_11_RECORDS_OCCUPIED_QTY_0 = 6355,
            PARAMETER_MB_ADDR_SESSION_DATA_11_RECORDS_OCCUPIED_QTY_1 = 6356,
            PARAMETER_MB_ADDR_SESSION_DATA_11_PAYLOADS_OCCUPIED_SIZE_0 = 6357,
            PARAMETER_MB_ADDR_SESSION_DATA_11_PAYLOADS_OCCUPIED_SIZE_1 = 6358,
            PARAMETER_MB_ADDR_SESSION_DATA_11_RECORDS_DURATION_US_0 = 6359,
            PARAMETER_MB_ADDR_SESSION_DATA_11_RECORDS_DURATION_US_1 = 6360,
            PARAMETER_MB_ADDR_SESSION_DATA_12_SESSION_ID = 6361,
            PARAMETER_MB_ADDR_SESSION_DATA_12_RECORDS_OCCUPIED_QTY_0 = 6362,
            PARAMETER_MB_ADDR_SESSION_DATA_12_RECORDS_OCCUPIED_QTY_1 = 6363,
            PARAMETER_MB_ADDR_SESSION_DATA_12_PAYLOADS_OCCUPIED_SIZE_0 = 6364,
            PARAMETER_MB_ADDR_SESSION_DATA_12_PAYLOADS_OCCUPIED_SIZE_1 = 6365,
            PARAMETER_MB_ADDR_SESSION_DATA_12_RECORDS_DURATION_US_0 = 6366,
            PARAMETER_MB_ADDR_SESSION_DATA_12_RECORDS_DURATION_US_1 = 6367,
            PARAMETER_MB_ADDR_SESSION_DATA_13_SESSION_ID = 6368,
            PARAMETER_MB_ADDR_SESSION_DATA_13_RECORDS_OCCUPIED_QTY_0 = 6369,
            PARAMETER_MB_ADDR_SESSION_DATA_13_RECORDS_OCCUPIED_QTY_1 = 6370,
            PARAMETER_MB_ADDR_SESSION_DATA_13_PAYLOADS_OCCUPIED_SIZE_0 = 6371,
            PARAMETER_MB_ADDR_SESSION_DATA_13_PAYLOADS_OCCUPIED_SIZE_1 = 6372,
            PARAMETER_MB_ADDR_SESSION_DATA_13_RECORDS_DURATION_US_0 = 6373,
            PARAMETER_MB_ADDR_SESSION_DATA_13_RECORDS_DURATION_US_1 = 6374,
            PARAMETER_MB_ADDR_SESSION_DATA_14_SESSION_ID = 6375,
            PARAMETER_MB_ADDR_SESSION_DATA_14_RECORDS_OCCUPIED_QTY_0 = 6376,
            PARAMETER_MB_ADDR_SESSION_DATA_14_RECORDS_OCCUPIED_QTY_1 = 6377,
            PARAMETER_MB_ADDR_SESSION_DATA_14_PAYLOADS_OCCUPIED_SIZE_0 = 6378,
            PARAMETER_MB_ADDR_SESSION_DATA_14_PAYLOADS_OCCUPIED_SIZE_1 = 6379,
            PARAMETER_MB_ADDR_SESSION_DATA_14_RECORDS_DURATION_US_0 = 6380,
            PARAMETER_MB_ADDR_SESSION_DATA_14_RECORDS_DURATION_US_1 = 6381,
            PARAMETER_MB_ADDR_SESSION_DATA_15_SESSION_ID = 6382,
            PARAMETER_MB_ADDR_SESSION_DATA_15_RECORDS_OCCUPIED_QTY_0 = 6383,
            PARAMETER_MB_ADDR_SESSION_DATA_15_RECORDS_OCCUPIED_QTY_1 = 6384,
            PARAMETER_MB_ADDR_SESSION_DATA_15_PAYLOADS_OCCUPIED_SIZE_0 = 6385,
            PARAMETER_MB_ADDR_SESSION_DATA_15_PAYLOADS_OCCUPIED_SIZE_1 = 6386,
            PARAMETER_MB_ADDR_SESSION_DATA_15_RECORDS_DURATION_US_0 = 6387,
            PARAMETER_MB_ADDR_SESSION_DATA_15_RECORDS_DURATION_US_1 = 6388,
            PARAMETER_MB_ADDR_SESSION_DATA_16_SESSION_ID = 6389,
            PARAMETER_MB_ADDR_SESSION_DATA_16_RECORDS_OCCUPIED_QTY_0 = 6390,
            PARAMETER_MB_ADDR_SESSION_DATA_16_RECORDS_OCCUPIED_QTY_1 = 6391,
            PARAMETER_MB_ADDR_SESSION_DATA_16_PAYLOADS_OCCUPIED_SIZE_0 = 6392,
            PARAMETER_MB_ADDR_SESSION_DATA_16_PAYLOADS_OCCUPIED_SIZE_1 = 6393,
            PARAMETER_MB_ADDR_SESSION_DATA_16_RECORDS_DURATION_US_0 = 6394,
            PARAMETER_MB_ADDR_SESSION_DATA_16_RECORDS_DURATION_US_1 = 6395,
            PARAMETER_MB_ADDR_SESSION_DATA_17_SESSION_ID = 6396,
            PARAMETER_MB_ADDR_SESSION_DATA_17_RECORDS_OCCUPIED_QTY_0 = 6397,
            PARAMETER_MB_ADDR_SESSION_DATA_17_RECORDS_OCCUPIED_QTY_1 = 6398,
            PARAMETER_MB_ADDR_SESSION_DATA_17_PAYLOADS_OCCUPIED_SIZE_0 = 6399,
            PARAMETER_MB_ADDR_SESSION_DATA_17_PAYLOADS_OCCUPIED_SIZE_1 = 6400,
            PARAMETER_MB_ADDR_SESSION_DATA_17_RECORDS_DURATION_US_0 = 6401,
            PARAMETER_MB_ADDR_SESSION_DATA_17_RECORDS_DURATION_US_1 = 6402,
            PARAMETER_MB_ADDR_SESSION_DATA_18_SESSION_ID = 6403,
            PARAMETER_MB_ADDR_SESSION_DATA_18_RECORDS_OCCUPIED_QTY_0 = 6404,
            PARAMETER_MB_ADDR_SESSION_DATA_18_RECORDS_OCCUPIED_QTY_1 = 6405,
            PARAMETER_MB_ADDR_SESSION_DATA_18_PAYLOADS_OCCUPIED_SIZE_0 = 6406,
            PARAMETER_MB_ADDR_SESSION_DATA_18_PAYLOADS_OCCUPIED_SIZE_1 = 6407,
            PARAMETER_MB_ADDR_SESSION_DATA_18_RECORDS_DURATION_US_0 = 6408,
            PARAMETER_MB_ADDR_SESSION_DATA_18_RECORDS_DURATION_US_1 = 6409,
            PARAMETER_MB_ADDR_SESSION_DATA_19_SESSION_ID = 6410,
            PARAMETER_MB_ADDR_SESSION_DATA_19_RECORDS_OCCUPIED_QTY_0 = 6411,
            PARAMETER_MB_ADDR_SESSION_DATA_19_RECORDS_OCCUPIED_QTY_1 = 6412,
            PARAMETER_MB_ADDR_SESSION_DATA_19_PAYLOADS_OCCUPIED_SIZE_0 = 6413,
            PARAMETER_MB_ADDR_SESSION_DATA_19_PAYLOADS_OCCUPIED_SIZE_1 = 6414,
            PARAMETER_MB_ADDR_SESSION_DATA_19_RECORDS_DURATION_US_0 = 6415,
            PARAMETER_MB_ADDR_SESSION_DATA_19_RECORDS_DURATION_US_1 = 6416,
            PARAMETER_MB_ADDR_GPS_M9N_BRIDGE_START_CMD = 6417,
            PARAMETER_MB_ADDR_DADC_BRIDGE_START_CMD = 6418
        }
    }
}

