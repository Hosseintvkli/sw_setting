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
    public class Parameters_DeviceID_01012_00000 : IParameterListDevice
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
        public sSensorHmc5983Setting hmc5983_Setting;
        public sProfilerSetting mainLoopProfilerSetting;
        public UInt16 calcFreqHz;
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

        public Parameters_DeviceID_01012_00000()
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
            imu_Setting = new sSensorImuSetting((UInt16)(4510));
            hmc5983_Setting = new sSensorHmc5983Setting((UInt16)(4641));
            mainLoopProfilerSetting = new sProfilerSetting((UInt16)(4860));
            calcFreqHz = 2000;
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
        public eParameterId[] StreamerParameterIds
        {
            get
            {
                eParameterId[] propView = new eParameterId[200];
                for (UInt16 i = 0; i < 200; i++)
                {
                    propView[i] = (eParameterId)streamerParameterIds[i];
                }
                return propView;
            }
            set
            {
                UInt16[] propViewOut = new UInt16[200];
                for (UInt16 i = 0; i < 200; i++)
                {
                    propViewOut[i] = (UInt16)value[i];
                }

                if(MainForm.modbusExt.ModbusWrite(4039, 0, propViewOut, typeof(ushort), 200))
                {
                    streamerParameterIds = propViewOut;
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
                if(MainForm.modbusExt.ModbusWrite(4510, 0, value, typeof(sSensorImuSetting), 1))
                {
                    imu_Setting = value;
                }
            }
        }

        [Category("Hardware"), ReadOnly(false), Description("")]
        public sSensorHmc5983Setting Hmc5983_Setting
        {
            get { return hmc5983_Setting; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(4641, 0, value, typeof(sSensorHmc5983Setting), 1))
                {
                    hmc5983_Setting = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), Description("")]
        public sProfilerSetting MainLoopProfilerSetting
        {
            get { return mainLoopProfilerSetting; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(4860, 0, value, typeof(sProfilerSetting), 1))
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
                if(MainForm.modbusExt.ModbusWrite(4871, 0, value, typeof(UInt16), 1))
                {
                    calcFreqHz = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("")]
        public UInt16 ZUPTUse
        {
            get { return zUPTUse; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(5274, 0, value, typeof(UInt16), 1))
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
                if(MainForm.modbusExt.ModbusWrite(5275, 0, value, typeof(UInt16), 1))
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
                if(MainForm.modbusExt.ModbusWrite(5276, 0, value, typeof(UInt16), 1))
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
                if(MainForm.modbusExt.ModbusWrite(5277, 0, value, typeof(UInt16), 1))
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
                if(MainForm.modbusExt.ModbusWrite(5278, 0, value, typeof(UInt16), 1))
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
                if(MainForm.modbusExt.ModbusWrite(5279, 0, value, typeof(UInt16), 1))
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
                if(MainForm.modbusExt.ModbusWrite(5280, 0, value, typeof(UInt16), 1))
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
                if(MainForm.modbusExt.ModbusWrite(5284, 0, value, typeof(UInt16), 1))
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
                if(MainForm.modbusExt.ModbusWrite(5285, 0, value, typeof(UInt16), 1))
                {
                    gNSSType = value;
                }
            }
        }

        [Category("RappMain"), ReadOnly(false), DefaultValue(0), Description("eHeadMode")]
        public UInt16 HeadType
        {
            get { return headType; }
            set
            {
                if(MainForm.modbusExt.ModbusWrite(5286, 0, value, typeof(UInt16), 1))
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
                if(MainForm.modbusExt.ModbusWrite(5287, 0, value, typeof(UInt16), 1))
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
                if(MainForm.modbusExt.ModbusWrite(5288, 0, value, typeof(UInt16), 1))
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
                if(MainForm.modbusExt.ModbusWrite(5289, 0, value, typeof(Double), 1))
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
                if(MainForm.modbusExt.ModbusWrite(5293, 0, value, typeof(Double), 3))
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
                if(MainForm.modbusExt.ModbusWrite(5305, 0, value, typeof(Double), 1))
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
                if(MainForm.modbusExt.ModbusWrite(5309, 0, value, typeof(Double), 1))
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
                if(MainForm.modbusExt.ModbusWrite(5313, 0, value, typeof(Double), 1))
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
                if(MainForm.modbusExt.ModbusWrite(5317, 0, value, typeof(Double), 1))
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
                if(MainForm.modbusExt.ModbusWrite(5321, 0, value, typeof(Double), 3))
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
                if(MainForm.modbusExt.ModbusWrite(5605, 0, value, typeof(UInt16), 1))
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
                if(MainForm.modbusExt.ModbusWrite(5606, 0, value, typeof(UInt16), 1))
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
            _status &= hmc5983_Setting.ModbusWriteAll();
            _status &= mainLoopProfilerSetting.ModbusWriteAll();
            _status &= MainForm.modbusExt.ModbusWrite(4871, 0, calcFreqHz, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5274, 0, zUPTUse, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5275, 0, gNSSUse, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5276, 0, airDataAllUse, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5277, 0, airDataSpeedUse, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5278, 0, airDataAltitudeUse, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5279, 0, visionUse, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5280, 0, magUse, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5284, 0, algorithmType, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5285, 0, gNSSType, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5286, 0, headType, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5287, 0, alignType, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5288, 0, nSensor, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5289, 0, initIdleTime, typeof(Double), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5293, 0, initLLA_rrm, typeof(Double), 3);
            _status &= MainForm.modbusExt.ModbusWrite(5305, 0, initHead_rad, typeof(Double), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5309, 0, alignTime_s, typeof(Double), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5313, 0, relAz_rad, typeof(Double), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5317, 0, speed0_mps, typeof(Double), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5321, 0, euler0_rad, typeof(Double), 3);
            _status &= MainForm.modbusExt.ModbusWrite(5605, 0, chipStabilizationCycleQty, typeof(UInt16), 1);
            _status &= MainForm.modbusExt.ModbusWrite(5606, 0, outputStabilizationCycleQty, typeof(UInt16), 1);
            
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
                hmc5983_Setting.ModbusReadAll();
                mainLoopProfilerSetting.ModbusReadAll();
                calcFreqHz = MainForm.modbusExt.ModbusRead(4871, 0, typeof(UInt16), 1);
                zUPTUse = MainForm.modbusExt.ModbusRead(5274, 0, typeof(UInt16), 1);
                gNSSUse = MainForm.modbusExt.ModbusRead(5275, 0, typeof(UInt16), 1);
                airDataAllUse = MainForm.modbusExt.ModbusRead(5276, 0, typeof(UInt16), 1);
                airDataSpeedUse = MainForm.modbusExt.ModbusRead(5277, 0, typeof(UInt16), 1);
                airDataAltitudeUse = MainForm.modbusExt.ModbusRead(5278, 0, typeof(UInt16), 1);
                visionUse = MainForm.modbusExt.ModbusRead(5279, 0, typeof(UInt16), 1);
                magUse = MainForm.modbusExt.ModbusRead(5280, 0, typeof(UInt16), 1);
                algorithmType = MainForm.modbusExt.ModbusRead(5284, 0, typeof(UInt16), 1);
                gNSSType = MainForm.modbusExt.ModbusRead(5285, 0, typeof(UInt16), 1);
                headType = MainForm.modbusExt.ModbusRead(5286, 0, typeof(UInt16), 1);
                alignType = MainForm.modbusExt.ModbusRead(5287, 0, typeof(UInt16), 1);
                nSensor = MainForm.modbusExt.ModbusRead(5288, 0, typeof(UInt16), 1);
                initIdleTime = MainForm.modbusExt.ModbusRead(5289, 0, typeof(Double), 1);
                initLLA_rrm = MainForm.modbusExt.ModbusRead(5293, 0, typeof(Double), 3);
                initHead_rad = MainForm.modbusExt.ModbusRead(5305, 0, typeof(Double), 1);
                alignTime_s = MainForm.modbusExt.ModbusRead(5309, 0, typeof(Double), 1);
                relAz_rad = MainForm.modbusExt.ModbusRead(5313, 0, typeof(Double), 1);
                speed0_mps = MainForm.modbusExt.ModbusRead(5317, 0, typeof(Double), 1);
                euler0_rad = MainForm.modbusExt.ModbusRead(5321, 0, typeof(Double), 3);
                chipStabilizationCycleQty = MainForm.modbusExt.ModbusRead(5605, 0, typeof(UInt16), 1);
                outputStabilizationCycleQty = MainForm.modbusExt.ModbusRead(5606, 0, typeof(UInt16), 1);
            
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
        
            MainForm.modbusExt.ModbusWrite(5281, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(5281, 0, typeof(UInt16), 1);
        
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
        
            MainForm.modbusExt.ModbusWrite(5282, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(5282, 0, typeof(UInt16), 1);
        
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
        
            MainForm.modbusExt.ModbusWrite(5283, 0, (ushort)0xFFFF, typeof(UInt16), 1);
        
            byte cnt = 0;
            while (true)
            {
                ushort result = MainForm.modbusExt.ModbusRead(5283, 0, typeof(UInt16), 1);
        
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
            public sBoardStartupReportItem adxl357;

            private UInt16 ModbusBaseAddr;

            public static UInt16 ModbusSize = 202; // VarTypeSize in excel
            
            public sBoardStartupReport(UInt16 ObjectModbusBaseAddr)
            {
                ModbusBaseAddr = ObjectModbusBaseAddr;

                overallResult = 0;
                executionTimeUs = 0;

                bmi088Gyro = new sBoardStartupReportItem[12];
                for (UInt16 i = 0; i < 12; i++)
                {
                    bmi088Gyro[i] = new sBoardStartupReportItem((UInt16)(ModbusBaseAddr + 2 + (8 * i)));
                }

                bmi088Acc = new sBoardStartupReportItem[12];
                for (UInt16 i = 0; i < 12; i++)
                {
                    bmi088Acc[i] = new sBoardStartupReportItem((UInt16)(ModbusBaseAddr + 98 + (8 * i)));
                }

                adxl357 = new sBoardStartupReportItem((UInt16)(ModbusBaseAddr + 194));
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
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 2, value, typeof(sBoardStartupReportItem), 12))
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
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 98, value, typeof(sBoardStartupReportItem), 12))
                    {
                        bmi088Acc = value;
                    }
                }
            }

            public sBoardStartupReportItem Adxl357
            {
                get { return adxl357; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 194, value, typeof(sBoardStartupReportItem), 1))
                    {
                        adxl357 = value;
                    }
                }
            }

            public bool ModbusWriteAll()
            {
                bool _status = true;
            
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, overallResult, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 1, executionTimeUs, typeof(UInt16), 1);

                for (int i = 0; i < 12; i++)
                {
                    bmi088Gyro[i].ModbusWriteAll();
                }

                for (int i = 0; i < 12; i++)
                {
                    bmi088Acc[i].ModbusWriteAll();
                }

                _status &= adxl357.ModbusWriteAll();
                
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

                for (int i = 0; i < 12; i++)
                {
                    bmi088Gyro[i].ModbusReadAll();
                }

                for (int i = 0; i < 12; i++)
                {
                    bmi088Acc[i].ModbusReadAll();
                }

                adxl357.ModbusReadAll();
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
        public class sSensorImuSetting
        {
            public UInt16 type;
            public UInt16 decRate;
            public UInt16 enable;

            private UInt16 ModbusBaseAddr;

            public static UInt16 ModbusSize = 3; // VarTypeSize in excel
            
            public sSensorImuSetting(UInt16 ObjectModbusBaseAddr)
            {
                ModbusBaseAddr = ObjectModbusBaseAddr;

                type = 0;
                decRate = 0;
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
            
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 0, type, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 1, decRate, typeof(UInt16), 1);
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 2, enable, typeof(UInt16), 1);
                
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
                enable = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 2, typeof(UInt16), 1);
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class sSensorImuData
        {
            public s3d[] acc_g;
            public s3d[] gyr_dps;
            public Double temperature;
            public UInt32 counter;
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

            public UInt32 Counter
            {
                get { return counter; }
                set
                {
                    if(MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 52, value, typeof(UInt32), 1))
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
                _status &=  MainForm.modbusExt.ModbusWrite(ModbusBaseAddr, 52, counter, typeof(UInt32), 1);
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
                counter = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 52, typeof(UInt32), 1);
                isNewData = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 54, typeof(UInt16), 1);
                active = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 55, typeof(UInt16), 1);
                summaryStatus = MainForm.modbusExt.ModbusRead(ModbusBaseAddr, 56, typeof(UInt32), 1);
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

        public enum eSettingGroup : ushort
        {
            Info = 0,
            ModbusExt = 1,
            HardwareConfiguration = 2,
            Functional = 3
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

        public enum eHeadMode : ushort
        {
            eHEAD_MODE_TOTAL_STATION = 0,
            eHEAD_MODE_GYRO_COMPASSING = 1
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
            BOARD_STARTUP_REPORT_BMI088_GYRO_0_CONNECTION_RESULT = 2285,
            BOARD_STARTUP_REPORT_BMI088_GYRO_0_CONNECTION_RETRY = 2286,
            BOARD_STARTUP_REPORT_BMI088_GYRO_0_CONNECTION_TIME_US = 2287,
            BOARD_STARTUP_REPORT_BMI088_GYRO_0_CONFIG_RESULT = 2288,
            BOARD_STARTUP_REPORT_BMI088_GYRO_0_CONFIG_RETRY = 2289,
            BOARD_STARTUP_REPORT_BMI088_GYRO_0_CONFIG_TIME_US = 2290,
            BOARD_STARTUP_REPORT_BMI088_GYRO_1_CONNECTION_RESULT = 2291,
            BOARD_STARTUP_REPORT_BMI088_GYRO_1_CONNECTION_RETRY = 2292,
            BOARD_STARTUP_REPORT_BMI088_GYRO_1_CONNECTION_TIME_US = 2293,
            BOARD_STARTUP_REPORT_BMI088_GYRO_1_CONFIG_RESULT = 2294,
            BOARD_STARTUP_REPORT_BMI088_GYRO_1_CONFIG_RETRY = 2295,
            BOARD_STARTUP_REPORT_BMI088_GYRO_1_CONFIG_TIME_US = 2296,
            BOARD_STARTUP_REPORT_BMI088_GYRO_2_CONNECTION_RESULT = 2297,
            BOARD_STARTUP_REPORT_BMI088_GYRO_2_CONNECTION_RETRY = 2298,
            BOARD_STARTUP_REPORT_BMI088_GYRO_2_CONNECTION_TIME_US = 2299,
            BOARD_STARTUP_REPORT_BMI088_GYRO_2_CONFIG_RESULT = 2300,
            BOARD_STARTUP_REPORT_BMI088_GYRO_2_CONFIG_RETRY = 2301,
            BOARD_STARTUP_REPORT_BMI088_GYRO_2_CONFIG_TIME_US = 2302,
            BOARD_STARTUP_REPORT_BMI088_GYRO_3_CONNECTION_RESULT = 2303,
            BOARD_STARTUP_REPORT_BMI088_GYRO_3_CONNECTION_RETRY = 2304,
            BOARD_STARTUP_REPORT_BMI088_GYRO_3_CONNECTION_TIME_US = 2305,
            BOARD_STARTUP_REPORT_BMI088_GYRO_3_CONFIG_RESULT = 2306,
            BOARD_STARTUP_REPORT_BMI088_GYRO_3_CONFIG_RETRY = 2307,
            BOARD_STARTUP_REPORT_BMI088_GYRO_3_CONFIG_TIME_US = 2308,
            BOARD_STARTUP_REPORT_BMI088_GYRO_4_CONNECTION_RESULT = 2309,
            BOARD_STARTUP_REPORT_BMI088_GYRO_4_CONNECTION_RETRY = 2310,
            BOARD_STARTUP_REPORT_BMI088_GYRO_4_CONNECTION_TIME_US = 2311,
            BOARD_STARTUP_REPORT_BMI088_GYRO_4_CONFIG_RESULT = 2312,
            BOARD_STARTUP_REPORT_BMI088_GYRO_4_CONFIG_RETRY = 2313,
            BOARD_STARTUP_REPORT_BMI088_GYRO_4_CONFIG_TIME_US = 2314,
            BOARD_STARTUP_REPORT_BMI088_GYRO_5_CONNECTION_RESULT = 2315,
            BOARD_STARTUP_REPORT_BMI088_GYRO_5_CONNECTION_RETRY = 2316,
            BOARD_STARTUP_REPORT_BMI088_GYRO_5_CONNECTION_TIME_US = 2317,
            BOARD_STARTUP_REPORT_BMI088_GYRO_5_CONFIG_RESULT = 2318,
            BOARD_STARTUP_REPORT_BMI088_GYRO_5_CONFIG_RETRY = 2319,
            BOARD_STARTUP_REPORT_BMI088_GYRO_5_CONFIG_TIME_US = 2320,
            BOARD_STARTUP_REPORT_BMI088_GYRO_6_CONNECTION_RESULT = 2321,
            BOARD_STARTUP_REPORT_BMI088_GYRO_6_CONNECTION_RETRY = 2322,
            BOARD_STARTUP_REPORT_BMI088_GYRO_6_CONNECTION_TIME_US = 2323,
            BOARD_STARTUP_REPORT_BMI088_GYRO_6_CONFIG_RESULT = 2324,
            BOARD_STARTUP_REPORT_BMI088_GYRO_6_CONFIG_RETRY = 2325,
            BOARD_STARTUP_REPORT_BMI088_GYRO_6_CONFIG_TIME_US = 2326,
            BOARD_STARTUP_REPORT_BMI088_GYRO_7_CONNECTION_RESULT = 2327,
            BOARD_STARTUP_REPORT_BMI088_GYRO_7_CONNECTION_RETRY = 2328,
            BOARD_STARTUP_REPORT_BMI088_GYRO_7_CONNECTION_TIME_US = 2329,
            BOARD_STARTUP_REPORT_BMI088_GYRO_7_CONFIG_RESULT = 2330,
            BOARD_STARTUP_REPORT_BMI088_GYRO_7_CONFIG_RETRY = 2331,
            BOARD_STARTUP_REPORT_BMI088_GYRO_7_CONFIG_TIME_US = 2332,
            BOARD_STARTUP_REPORT_BMI088_GYRO_8_CONNECTION_RESULT = 2333,
            BOARD_STARTUP_REPORT_BMI088_GYRO_8_CONNECTION_RETRY = 2334,
            BOARD_STARTUP_REPORT_BMI088_GYRO_8_CONNECTION_TIME_US = 2335,
            BOARD_STARTUP_REPORT_BMI088_GYRO_8_CONFIG_RESULT = 2336,
            BOARD_STARTUP_REPORT_BMI088_GYRO_8_CONFIG_RETRY = 2337,
            BOARD_STARTUP_REPORT_BMI088_GYRO_8_CONFIG_TIME_US = 2338,
            BOARD_STARTUP_REPORT_BMI088_GYRO_9_CONNECTION_RESULT = 2339,
            BOARD_STARTUP_REPORT_BMI088_GYRO_9_CONNECTION_RETRY = 2340,
            BOARD_STARTUP_REPORT_BMI088_GYRO_9_CONNECTION_TIME_US = 2341,
            BOARD_STARTUP_REPORT_BMI088_GYRO_9_CONFIG_RESULT = 2342,
            BOARD_STARTUP_REPORT_BMI088_GYRO_9_CONFIG_RETRY = 2343,
            BOARD_STARTUP_REPORT_BMI088_GYRO_9_CONFIG_TIME_US = 2344,
            BOARD_STARTUP_REPORT_BMI088_GYRO_10_CONNECTION_RESULT = 2345,
            BOARD_STARTUP_REPORT_BMI088_GYRO_10_CONNECTION_RETRY = 2346,
            BOARD_STARTUP_REPORT_BMI088_GYRO_10_CONNECTION_TIME_US = 2347,
            BOARD_STARTUP_REPORT_BMI088_GYRO_10_CONFIG_RESULT = 2348,
            BOARD_STARTUP_REPORT_BMI088_GYRO_10_CONFIG_RETRY = 2349,
            BOARD_STARTUP_REPORT_BMI088_GYRO_10_CONFIG_TIME_US = 2350,
            BOARD_STARTUP_REPORT_BMI088_GYRO_11_CONNECTION_RESULT = 2351,
            BOARD_STARTUP_REPORT_BMI088_GYRO_11_CONNECTION_RETRY = 2352,
            BOARD_STARTUP_REPORT_BMI088_GYRO_11_CONNECTION_TIME_US = 2353,
            BOARD_STARTUP_REPORT_BMI088_GYRO_11_CONFIG_RESULT = 2354,
            BOARD_STARTUP_REPORT_BMI088_GYRO_11_CONFIG_RETRY = 2355,
            BOARD_STARTUP_REPORT_BMI088_GYRO_11_CONFIG_TIME_US = 2356,
            BOARD_STARTUP_REPORT_BMI088_ACC_0_CONNECTION_RESULT = 2357,
            BOARD_STARTUP_REPORT_BMI088_ACC_0_CONNECTION_RETRY = 2358,
            BOARD_STARTUP_REPORT_BMI088_ACC_0_CONNECTION_TIME_US = 2359,
            BOARD_STARTUP_REPORT_BMI088_ACC_0_CONFIG_RESULT = 2360,
            BOARD_STARTUP_REPORT_BMI088_ACC_0_CONFIG_RETRY = 2361,
            BOARD_STARTUP_REPORT_BMI088_ACC_0_CONFIG_TIME_US = 2362,
            BOARD_STARTUP_REPORT_BMI088_ACC_1_CONNECTION_RESULT = 2363,
            BOARD_STARTUP_REPORT_BMI088_ACC_1_CONNECTION_RETRY = 2364,
            BOARD_STARTUP_REPORT_BMI088_ACC_1_CONNECTION_TIME_US = 2365,
            BOARD_STARTUP_REPORT_BMI088_ACC_1_CONFIG_RESULT = 2366,
            BOARD_STARTUP_REPORT_BMI088_ACC_1_CONFIG_RETRY = 2367,
            BOARD_STARTUP_REPORT_BMI088_ACC_1_CONFIG_TIME_US = 2368,
            BOARD_STARTUP_REPORT_BMI088_ACC_2_CONNECTION_RESULT = 2369,
            BOARD_STARTUP_REPORT_BMI088_ACC_2_CONNECTION_RETRY = 2370,
            BOARD_STARTUP_REPORT_BMI088_ACC_2_CONNECTION_TIME_US = 2371,
            BOARD_STARTUP_REPORT_BMI088_ACC_2_CONFIG_RESULT = 2372,
            BOARD_STARTUP_REPORT_BMI088_ACC_2_CONFIG_RETRY = 2373,
            BOARD_STARTUP_REPORT_BMI088_ACC_2_CONFIG_TIME_US = 2374,
            BOARD_STARTUP_REPORT_BMI088_ACC_3_CONNECTION_RESULT = 2375,
            BOARD_STARTUP_REPORT_BMI088_ACC_3_CONNECTION_RETRY = 2376,
            BOARD_STARTUP_REPORT_BMI088_ACC_3_CONNECTION_TIME_US = 2377,
            BOARD_STARTUP_REPORT_BMI088_ACC_3_CONFIG_RESULT = 2378,
            BOARD_STARTUP_REPORT_BMI088_ACC_3_CONFIG_RETRY = 2379,
            BOARD_STARTUP_REPORT_BMI088_ACC_3_CONFIG_TIME_US = 2380,
            BOARD_STARTUP_REPORT_BMI088_ACC_4_CONNECTION_RESULT = 2381,
            BOARD_STARTUP_REPORT_BMI088_ACC_4_CONNECTION_RETRY = 2382,
            BOARD_STARTUP_REPORT_BMI088_ACC_4_CONNECTION_TIME_US = 2383,
            BOARD_STARTUP_REPORT_BMI088_ACC_4_CONFIG_RESULT = 2384,
            BOARD_STARTUP_REPORT_BMI088_ACC_4_CONFIG_RETRY = 2385,
            BOARD_STARTUP_REPORT_BMI088_ACC_4_CONFIG_TIME_US = 2386,
            BOARD_STARTUP_REPORT_BMI088_ACC_5_CONNECTION_RESULT = 2387,
            BOARD_STARTUP_REPORT_BMI088_ACC_5_CONNECTION_RETRY = 2388,
            BOARD_STARTUP_REPORT_BMI088_ACC_5_CONNECTION_TIME_US = 2389,
            BOARD_STARTUP_REPORT_BMI088_ACC_5_CONFIG_RESULT = 2390,
            BOARD_STARTUP_REPORT_BMI088_ACC_5_CONFIG_RETRY = 2391,
            BOARD_STARTUP_REPORT_BMI088_ACC_5_CONFIG_TIME_US = 2392,
            BOARD_STARTUP_REPORT_BMI088_ACC_6_CONNECTION_RESULT = 2393,
            BOARD_STARTUP_REPORT_BMI088_ACC_6_CONNECTION_RETRY = 2394,
            BOARD_STARTUP_REPORT_BMI088_ACC_6_CONNECTION_TIME_US = 2395,
            BOARD_STARTUP_REPORT_BMI088_ACC_6_CONFIG_RESULT = 2396,
            BOARD_STARTUP_REPORT_BMI088_ACC_6_CONFIG_RETRY = 2397,
            BOARD_STARTUP_REPORT_BMI088_ACC_6_CONFIG_TIME_US = 2398,
            BOARD_STARTUP_REPORT_BMI088_ACC_7_CONNECTION_RESULT = 2399,
            BOARD_STARTUP_REPORT_BMI088_ACC_7_CONNECTION_RETRY = 2400,
            BOARD_STARTUP_REPORT_BMI088_ACC_7_CONNECTION_TIME_US = 2401,
            BOARD_STARTUP_REPORT_BMI088_ACC_7_CONFIG_RESULT = 2402,
            BOARD_STARTUP_REPORT_BMI088_ACC_7_CONFIG_RETRY = 2403,
            BOARD_STARTUP_REPORT_BMI088_ACC_7_CONFIG_TIME_US = 2404,
            BOARD_STARTUP_REPORT_BMI088_ACC_8_CONNECTION_RESULT = 2405,
            BOARD_STARTUP_REPORT_BMI088_ACC_8_CONNECTION_RETRY = 2406,
            BOARD_STARTUP_REPORT_BMI088_ACC_8_CONNECTION_TIME_US = 2407,
            BOARD_STARTUP_REPORT_BMI088_ACC_8_CONFIG_RESULT = 2408,
            BOARD_STARTUP_REPORT_BMI088_ACC_8_CONFIG_RETRY = 2409,
            BOARD_STARTUP_REPORT_BMI088_ACC_8_CONFIG_TIME_US = 2410,
            BOARD_STARTUP_REPORT_BMI088_ACC_9_CONNECTION_RESULT = 2411,
            BOARD_STARTUP_REPORT_BMI088_ACC_9_CONNECTION_RETRY = 2412,
            BOARD_STARTUP_REPORT_BMI088_ACC_9_CONNECTION_TIME_US = 2413,
            BOARD_STARTUP_REPORT_BMI088_ACC_9_CONFIG_RESULT = 2414,
            BOARD_STARTUP_REPORT_BMI088_ACC_9_CONFIG_RETRY = 2415,
            BOARD_STARTUP_REPORT_BMI088_ACC_9_CONFIG_TIME_US = 2416,
            BOARD_STARTUP_REPORT_BMI088_ACC_10_CONNECTION_RESULT = 2417,
            BOARD_STARTUP_REPORT_BMI088_ACC_10_CONNECTION_RETRY = 2418,
            BOARD_STARTUP_REPORT_BMI088_ACC_10_CONNECTION_TIME_US = 2419,
            BOARD_STARTUP_REPORT_BMI088_ACC_10_CONFIG_RESULT = 2420,
            BOARD_STARTUP_REPORT_BMI088_ACC_10_CONFIG_RETRY = 2421,
            BOARD_STARTUP_REPORT_BMI088_ACC_10_CONFIG_TIME_US = 2422,
            BOARD_STARTUP_REPORT_BMI088_ACC_11_CONNECTION_RESULT = 2423,
            BOARD_STARTUP_REPORT_BMI088_ACC_11_CONNECTION_RETRY = 2424,
            BOARD_STARTUP_REPORT_BMI088_ACC_11_CONNECTION_TIME_US = 2425,
            BOARD_STARTUP_REPORT_BMI088_ACC_11_CONFIG_RESULT = 2426,
            BOARD_STARTUP_REPORT_BMI088_ACC_11_CONFIG_RETRY = 2427,
            BOARD_STARTUP_REPORT_BMI088_ACC_11_CONFIG_TIME_US = 2428,
            BOARD_STARTUP_REPORT_ADXL357_CONNECTION_RESULT = 2429,
            BOARD_STARTUP_REPORT_ADXL357_CONNECTION_RETRY = 2430,
            BOARD_STARTUP_REPORT_ADXL357_CONNECTION_TIME_US = 2431,
            BOARD_STARTUP_REPORT_ADXL357_CONFIG_RESULT = 2432,
            BOARD_STARTUP_REPORT_ADXL357_CONFIG_RETRY = 2433,
            BOARD_STARTUP_REPORT_ADXL357_CONFIG_TIME_US = 2434,
            IMU_DATA_ACC_G_0_X = 2435,
            IMU_DATA_ACC_G_0_Y = 2436,
            IMU_DATA_ACC_G_0_Z = 2437,
            IMU_DATA_ACC_G_1_X = 2438,
            IMU_DATA_ACC_G_1_Y = 2439,
            IMU_DATA_ACC_G_1_Z = 2440,
            IMU_DATA_GYR_DPS_0_X = 2441,
            IMU_DATA_GYR_DPS_0_Y = 2442,
            IMU_DATA_GYR_DPS_0_Z = 2443,
            IMU_DATA_GYR_DPS_1_X = 2444,
            IMU_DATA_GYR_DPS_1_Y = 2445,
            IMU_DATA_GYR_DPS_1_Z = 2446,
            IMU_DATA_TEMPERATURE = 2447,
            IMU_DATA_COUNTER = 2448,
            IMU_DATA_IS_NEW_DATA = 2449,
            IMU_DATA_ACTIVE = 2450,
            IMU_DATA_SUMMARY_STATUS = 2451,
            IMU_SETTING_TYPE = 2452,
            IMU_SETTING_DEC_RATE = 2453,
            IMU_SETTING_ENABLE = 2454,
            M9N_DATA_ITOW = 2455,
            M9N_DATA_YEAR = 2456,
            M9N_DATA_MONTH = 2457,
            M9N_DATA_DAY = 2458,
            M9N_DATA_HOURS = 2459,
            M9N_DATA_MIN = 2460,
            M9N_DATA_SEC = 2461,
            M9N_DATA_VALID = 2462,
            M9N_DATA_TACC = 2463,
            M9N_DATA_NANO = 2464,
            M9N_DATA_FIX_TYPE = 2465,
            M9N_DATA_FLAGS = 2466,
            M9N_DATA_FLAGS2 = 2467,
            M9N_DATA_NUM_SV = 2468,
            M9N_DATA_LON = 2469,
            M9N_DATA_LAT = 2470,
            M9N_DATA_HEIGHT = 2471,
            M9N_DATA_HMSL = 2472,
            M9N_DATA_HACC = 2473,
            M9N_DATA_VACC = 2474,
            M9N_DATA_VEL_NED_0 = 2475,
            M9N_DATA_VEL_NED_1 = 2476,
            M9N_DATA_VEL_NED_2 = 2477,
            M9N_DATA_GSPEED = 2478,
            M9N_DATA_HEAD_MOT = 2479,
            M9N_DATA_SACC = 2480,
            M9N_DATA_HEAD_ACC = 2481,
            M9N_DATA_PDOP = 2482,
            M9N_DATA_RESERVED_0 = 2483,
            M9N_DATA_RESERVED_1 = 2484,
            M9N_DATA_RESERVED_2 = 2485,
            M9N_DATA_RESERVED_3 = 2486,
            M9N_DATA_HEAD_VEH = 2487,
            M9N_DATA_MAG_DEC = 2488,
            M9N_DATA_MAG_ACC = 2489,
            M9N_DATA_FRAME_COUNTER = 2490,
            M9N_DATA_FRAME_ERROR_COUNTER = 2491,
            M9N_DATA_IS_VALID_DATA = 2492,
            M9N_DATA_IS_NEW_DATA = 2493,
            M9N_DATA_ACTIVE = 2494,
            M9N_DATA_SUMMARY_STATUS = 2495,
            DADC_DATA_ADC_IS_NEW_DATA = 2496,
            DADC_DATA_ADC_UNIT = 2497,
            DADC_DATA_ADC_OUTSIDE_PROBE_TEMP = 2498,
            DADC_DATA_ADC_INTERNAL_PROBE_TEMP = 2499,
            DADC_DATA_ADC_STATIC_PRESSURE = 2500,
            DADC_DATA_ADC_PITOT_DIFF_PRESSURE = 2501,
            DADC_DATA_ADA_IS_NEW_DATA = 2502,
            DADC_DATA_ADA_UNIT = 2503,
            DADC_DATA_ADA_PRESSURE_ALTITUDE = 2504,
            DADC_DATA_ADA_INDICATED_ALTITUDE = 2505,
            DADC_DATA_ADA_TRUE_ALTITUDE = 2506,
            DADC_DATA_ADA_RATE_OF_CLIMB = 2507,
            DADC_DATA_ADA_OUTSIDE_AIR_TEMPERATURE = 2508,
            DADC_DATA_ADA_TOTAL_AIR_TEMPERATURE = 2509,
            DADC_DATA_ADA_DIFF_OUTSIDE_AIR_TEMP_AND_ISA = 2510,
            DADC_DATA_ADV_IS_NEW_DATA = 2511,
            DADC_DATA_ADV_UNIT = 2512,
            DADC_DATA_ADV_CALIBRATED_AIR_SPEED = 2513,
            DADC_DATA_ADV_TRUE_AIRSPEED = 2514,
            DADC_DATA_ADV_MACH_NUM = 2515,
            DADC_DATA_ADV_AIR_DENSITY = 2516,
            DADC_DATA_ADR_IS_NEW_DATA = 2517,
            DADC_DATA_ADR_CPU_TEMP = 2518,
            DADC_DATA_ADR_OUTSIDE_RTD_MV = 2519,
            DADC_DATA_ADR_INSIDE_RTD_MV = 2520,
            DADC_DATA_ADR_STATIC_PRESS_V = 2521,
            DADC_DATA_ADR_DIFF_PRESS_V = 2522,
            DADC_DATA_ACTIVE = 2523,
            DADC_DATA_SUMMARY_STATUS = 2524,
            HMC5983_DATA_MAG_X = 2525,
            HMC5983_DATA_MAG_Y = 2526,
            HMC5983_DATA_MAG_Z = 2527,
            HMC5983_DATA_TEMPERATURE = 2528,
            HMC5983_DATA_IS_NEW_DATA = 2529,
            HMC5983_DATA_ACTIVE = 2530,
            HMC5983_DATA_SUMMARY_STATUS = 2531,
            HMC5983_SETTING_ODR = 2532,
            HMC5983_SETTING_SAMPLE_AVERAGE = 2533,
            HMC5983_SETTING_GAIN = 2534,
            HMC5983_SETTING_ENABLE = 2535,
            IBNS_MATCH_DATA_JETSON_TIME_UTC = 2536,
            IBNS_MATCH_DATA_RAW_LAT_DEG = 2537,
            IBNS_MATCH_DATA_RAW_LON_DEG = 2538,
            IBNS_MATCH_DATA_EST_LAT_DEG = 2539,
            IBNS_MATCH_DATA_EST_LON_DEG = 2540,
            IBNS_MATCH_DATA_AGL_M = 2541,
            IBNS_MATCH_DATA_DEM_ALT_M = 2542,
            IBNS_MATCH_DATA_ROLL_FUS_DEG = 2543,
            IBNS_MATCH_DATA_PITCH_FUS_DEG = 2544,
            IBNS_MATCH_DATA_YAW_FUS_DEG = 2545,
            IBNS_MATCH_DATA_HEADING_DEG = 2546,
            IBNS_MATCH_DATA_COURES_DEG = 2547,
            IBNS_MATCH_DATA_QUALITY_MATCH = 2548,
            IBNS_MATCH_DATA_STATUS_FLAGS = 2549,
            IBNS_MATCH_DATA_UPDATE_MASK = 2550,
            IBNS_MATCH_DATA_EXCUTION_TIME_MS = 2551,
            IBNS_MATCH_DATA_IS_NEW_DATA = 2552,
            IBNS_MATCH_DATA_ACTIVE = 2553,
            IBNS_MATCH_DATA_SUMMARY_STATUS = 2554,
            IBNS_SPEED_DATA_JETSON_TIME_UTC = 2555,
            IBNS_SPEED_DATA_ODOLAT_DEG = 2556,
            IBNS_SPEED_DATA_ODOLON_DEG = 2557,
            IBNS_SPEED_DATA_ALT_M = 2558,
            IBNS_SPEED_DATA_ROLL_FUS_DEG = 2559,
            IBNS_SPEED_DATA_PITCH_FUS_DEG = 2560,
            IBNS_SPEED_DATA_YAW_FUS_DEG = 2561,
            IBNS_SPEED_DATA_SPEED_MPS = 2562,
            IBNS_SPEED_DATA_QUALITY_SPEED = 2563,
            IBNS_SPEED_DATA_ODO_DX_M = 2564,
            IBNS_SPEED_DATA_ODO_DY_M = 2565,
            IBNS_SPEED_DATA_STATUS_FLAGS = 2566,
            IBNS_SPEED_DATA_UPDATE_MASK = 2567,
            IBNS_SPEED_DATA_EXCUTION_TIME_MS = 2568,
            IBNS_SPEED_DATA_IS_NEW_DATA = 2569,
            IBNS_SPEED_DATA_ACTIVE = 2570,
            IBNS_SPEED_DATA_SUMMARY_STATUS = 2571,
            SADRA_DATA_INS_FRAME_IS_NEW_DATA = 2572,
            SADRA_DATA_INS_FRAME_EULER_RAD_0 = 2573,
            SADRA_DATA_INS_FRAME_EULER_RAD_1 = 2574,
            SADRA_DATA_INS_FRAME_EULER_RAD_2 = 2575,
            SADRA_DATA_INS_FRAME_COURSE_RAD = 2576,
            SADRA_DATA_INS_FRAME_ACC_ENU_MPS2_0 = 2577,
            SADRA_DATA_INS_FRAME_ACC_ENU_MPS2_1 = 2578,
            SADRA_DATA_INS_FRAME_ACC_ENU_MPS2_2 = 2579,
            SADRA_DATA_INS_FRAME_GYRO_ENU_RPS_0 = 2580,
            SADRA_DATA_INS_FRAME_GYRO_ENU_RPS_1 = 2581,
            SADRA_DATA_INS_FRAME_GYRO_ENU_RPS_2 = 2582,
            SADRA_DATA_INS_FRAME_STATUS = 2583,
            SADRA_DATA_INS_FRAME_LLA_RRM_0 = 2584,
            SADRA_DATA_INS_FRAME_LLA_RRM_1 = 2585,
            SADRA_DATA_INS_FRAME_LLA_RRM_2 = 2586,
            SADRA_DATA_INS_FRAME_VEL_ENU_0 = 2587,
            SADRA_DATA_INS_FRAME_VEL_ENU_1 = 2588,
            SADRA_DATA_INS_FRAME_VEL_ENU_2 = 2589,
            SADRA_DATA_GPS_FRAME_IS_NEW_DATA = 2590,
            SADRA_DATA_GPSFRAME_I_TOW = 2591,
            SADRA_DATA_GPSFRAME_F_TOW = 2592,
            SADRA_DATA_GPSFRAME_NUM_SV = 2593,
            SADRA_DATA_GPSFRAME_WEEK = 2594,
            SADRA_DATA_GPSFRAME_GPSFIX = 2595,
            SADRA_DATA_GPSFRAME_FLAG = 2596,
            SADRA_DATA_GPSFRAME_POS_ECEF_0 = 2597,
            SADRA_DATA_GPSFRAME_POS_ECEF_1 = 2598,
            SADRA_DATA_GPSFRAME_POS_ECEF_2 = 2599,
            SADRA_DATA_GPSFRAME_VEL_ECEF_0 = 2600,
            SADRA_DATA_GPSFRAME_VEL_ECEF_1 = 2601,
            SADRA_DATA_GPSFRAME_VEL_ECEF_2 = 2602,
            SADRA_DATA_ACTIVE = 2603,
            SADRA_DATA_SUMMARY_STATUS = 2604,
            MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_US = 2605,
            MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_MAXIMA_US = 2606,
            MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_MINIMA_US = 2607,
            MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_LIMIT_EXCEED_COUNTER = 2608,
            MAIN_LOOP_PROFILER_DATA_INTERVAL_TIMING_ERROR = 2609,
            MAIN_LOOP_PROFILER_DATA_EXECUTION_TIME_US = 2610,
            MAIN_LOOP_PROFILER_DATA_EXECUTION_TIME_MAXIMA_US = 2611,
            MAIN_LOOP_PROFILER_DATA_EXECUTION_TIME_MINIMA_US = 2612,
            MAIN_LOOP_PROFILER_DATA_RUN_COUNTER = 2613,
            MAIN_LOOP_PROFILER_SETTING_INTERVAL_TIME_NOMINAL_US = 2614,
            MAIN_LOOP_PROFILER_SETTING_INTERVAL_TIME_MAX_ALLOWED_JITTER_US = 2615,
            CALC_VERSION_MAJOR = 2616,
            CALC_VERSION_MINOR = 2617,
            CALC_VERSION_BUILD1 = 2618,
            CALC_VERSION_BUILD2 = 2619,
            CALC_STATUS = 2620,
            CALC_FREQ_HZ = 2621,
            CALC_COUNTER = 2622,
            DEBUG_SIGNALS_0 = 2623,
            DEBUG_SIGNALS_1 = 2624,
            DEBUG_SIGNALS_2 = 2625,
            DEBUG_SIGNALS_3 = 2626,
            DEBUG_SIGNALS_4 = 2627,
            DEBUG_SIGNALS_5 = 2628,
            DEBUG_SIGNALS_6 = 2629,
            DEBUG_SIGNALS_7 = 2630,
            DEBUG_SIGNALS_8 = 2631,
            DEBUG_SIGNALS_9 = 2632,
            DEBUG_SIGNALS_10 = 2633,
            DEBUG_SIGNALS_11 = 2634,
            DEBUG_SIGNALS_12 = 2635,
            DEBUG_SIGNALS_13 = 2636,
            DEBUG_SIGNALS_14 = 2637,
            DEBUG_SIGNALS_15 = 2638,
            DEBUG_SIGNALS_16 = 2639,
            DEBUG_SIGNALS_17 = 2640,
            DEBUG_SIGNALS_18 = 2641,
            DEBUG_SIGNALS_19 = 2642,
            DEBUG_SIGNALS_20 = 2643,
            DEBUG_SIGNALS_21 = 2644,
            DEBUG_SIGNALS_22 = 2645,
            DEBUG_SIGNALS_23 = 2646,
            DEBUG_SIGNALS_24 = 2647,
            DEBUG_SIGNALS_25 = 2648,
            DEBUG_SIGNALS_26 = 2649,
            DEBUG_SIGNALS_27 = 2650,
            DEBUG_SIGNALS_28 = 2651,
            DEBUG_SIGNALS_29 = 2652,
            DEBUG_SIGNALS_30 = 2653,
            DEBUG_SIGNALS_31 = 2654,
            DEBUG_SIGNALS_32 = 2655,
            DEBUG_SIGNALS_33 = 2656,
            DEBUG_SIGNALS_34 = 2657,
            DEBUG_SIGNALS_35 = 2658,
            DEBUG_SIGNALS_36 = 2659,
            DEBUG_SIGNALS_37 = 2660,
            DEBUG_SIGNALS_38 = 2661,
            DEBUG_SIGNALS_39 = 2662,
            DEBUG_SIGNALS_40 = 2663,
            DEBUG_SIGNALS_41 = 2664,
            DEBUG_SIGNALS_42 = 2665,
            DEBUG_SIGNALS_43 = 2666,
            DEBUG_SIGNALS_44 = 2667,
            DEBUG_SIGNALS_45 = 2668,
            DEBUG_SIGNALS_46 = 2669,
            DEBUG_SIGNALS_47 = 2670,
            DEBUG_SIGNALS_48 = 2671,
            DEBUG_SIGNALS_49 = 2672,
            DEBUG_SIGNALS_50 = 2673,
            DEBUG_SIGNALS_51 = 2674,
            DEBUG_SIGNALS_52 = 2675,
            DEBUG_SIGNALS_53 = 2676,
            DEBUG_SIGNALS_54 = 2677,
            DEBUG_SIGNALS_55 = 2678,
            DEBUG_SIGNALS_56 = 2679,
            DEBUG_SIGNALS_57 = 2680,
            DEBUG_SIGNALS_58 = 2681,
            DEBUG_SIGNALS_59 = 2682,
            DEBUG_SIGNALS_60 = 2683,
            DEBUG_SIGNALS_61 = 2684,
            DEBUG_SIGNALS_62 = 2685,
            DEBUG_SIGNALS_63 = 2686,
            DEBUG_SIGNALS_64 = 2687,
            DEBUG_SIGNALS_65 = 2688,
            DEBUG_SIGNALS_66 = 2689,
            DEBUG_SIGNALS_67 = 2690,
            DEBUG_SIGNALS_68 = 2691,
            DEBUG_SIGNALS_69 = 2692,
            DEBUG_SIGNALS_70 = 2693,
            DEBUG_SIGNALS_71 = 2694,
            DEBUG_SIGNALS_72 = 2695,
            DEBUG_SIGNALS_73 = 2696,
            DEBUG_SIGNALS_74 = 2697,
            DEBUG_SIGNALS_75 = 2698,
            DEBUG_SIGNALS_76 = 2699,
            DEBUG_SIGNALS_77 = 2700,
            DEBUG_SIGNALS_78 = 2701,
            DEBUG_SIGNALS_79 = 2702,
            DEBUG_SIGNALS_80 = 2703,
            DEBUG_SIGNALS_81 = 2704,
            DEBUG_SIGNALS_82 = 2705,
            DEBUG_SIGNALS_83 = 2706,
            DEBUG_SIGNALS_84 = 2707,
            DEBUG_SIGNALS_85 = 2708,
            DEBUG_SIGNALS_86 = 2709,
            DEBUG_SIGNALS_87 = 2710,
            DEBUG_SIGNALS_88 = 2711,
            DEBUG_SIGNALS_89 = 2712,
            DEBUG_SIGNALS_90 = 2713,
            DEBUG_SIGNALS_91 = 2714,
            DEBUG_SIGNALS_92 = 2715,
            DEBUG_SIGNALS_93 = 2716,
            DEBUG_SIGNALS_94 = 2717,
            DEBUG_SIGNALS_95 = 2718,
            DEBUG_SIGNALS_96 = 2719,
            DEBUG_SIGNALS_97 = 2720,
            DEBUG_SIGNALS_98 = 2721,
            DEBUG_SIGNALS_99 = 2722,
            ZUPTUSE = 2723,
            GNSSUSE = 2724,
            AIR_DATA_ALL_USE = 2725,
            AIR_DATA_SPEED_USE = 2726,
            AIR_DATA_ALTITUDE_USE = 2727,
            VISION_USE = 2728,
            MAG_USE = 2729,
            ALGORITHM_RESET = 2730,
            FLIGHT_ZERO = 2731,
            ARM = 2732,
            ALGORITHM_TYPE = 2733,
            GNSSTYPE = 2734,
            HEAD_TYPE = 2735,
            ALIGN_TYPE = 2736,
            NSENSOR = 2737,
            INIT_IDLE_TIME = 2738,
            INIT_LLA_RRM_0 = 2739,
            INIT_LLA_RRM_1 = 2740,
            INIT_LLA_RRM_2 = 2741,
            INIT_HEAD_RAD = 2742,
            ALIGN_TIME_S = 2743,
            REL_AZ_RAD = 2744,
            SPEED0_MPS = 2745,
            EULER0_RAD_0 = 2746,
            EULER0_RAD_1 = 2747,
            EULER0_RAD_2 = 2748,
            RUN_TIME_S = 2749,
            CURRENT_STATE = 2750,
            OBS_TYPE = 2751,
            CARRIER_TYPE = 2752,
            CONTROL_FLAGS_BITS_SUMMARY = 2753,
            ALIGN_COUNTER = 2754,
            ALIGN_ACC_AVERAGE_0 = 2755,
            ALIGN_ACC_AVERAGE_1 = 2756,
            ALIGN_ACC_AVERAGE_2 = 2757,
            ALIGN_GYR_AVERAGE_0 = 2758,
            ALIGN_GYR_AVERAGE_1 = 2759,
            ALIGN_GYR_AVERAGE_2 = 2760,
            ALIGN_EULER0_0 = 2761,
            ALIGN_EULER0_1 = 2762,
            ALIGN_EULER0_2 = 2763,
            ALIGN_QUAT0_0 = 2764,
            ALIGN_QUAT0_1 = 2765,
            ALIGN_QUAT0_2 = 2766,
            ALIGN_QUAT0_3 = 2767,
            ALIGN_GYR_NORM0 = 2768,
            ALIGN_ACC_NORM0 = 2769,
            ALIGN_GYR_ERR0_0 = 2770,
            ALIGN_GYR_ERR0_1 = 2771,
            ALIGN_GYR_ERR0_2 = 2772,
            NAV_COUNTER = 2773,
            NAV_QUAT_0 = 2774,
            NAV_QUAT_1 = 2775,
            NAV_QUAT_2 = 2776,
            NAV_QUAT_3 = 2777,
            NAV_EULER_0 = 2778,
            NAV_EULER_1 = 2779,
            NAV_EULER_2 = 2780,
            NAV_V_NED_0 = 2781,
            NAV_V_NED_1 = 2782,
            NAV_V_NED_2 = 2783,
            NAV_LLA_0 = 2784,
            NAV_LLA_1 = 2785,
            NAV_LLA_2 = 2786,
            NAV_R_NED_0 = 2787,
            NAV_R_NED_1 = 2788,
            NAV_R_NED_2 = 2789,
            FUS_COUNTER = 2790,
            FUS_EULER_0 = 2791,
            FUS_EULER_1 = 2792,
            FUS_EULER_2 = 2793,
            FUS_QUAT_0 = 2794,
            FUS_QUAT_1 = 2795,
            FUS_QUAT_2 = 2796,
            FUS_QUAT_3 = 2797,
            FUS_V_NED_0 = 2798,
            FUS_V_NED_1 = 2799,
            FUS_V_NED_2 = 2800,
            FUS_LLA_0 = 2801,
            FUS_LLA_1 = 2802,
            FUS_LLA_2 = 2803,
            FUS_BA_0 = 2804,
            FUS_BA_1 = 2805,
            FUS_BA_2 = 2806,
            FUS_BG_0 = 2807,
            FUS_BG_1 = 2808,
            FUS_BG_2 = 2809,
            FUS_PSI_CC_0 = 2810,
            FUS_PSI_CC_1 = 2811,
            FUS_PSI_CC_2 = 2812,
            FUS_RESET_CNT = 2813,
            QUAT_0 = 2814,
            QUAT_1 = 2815,
            QUAT_2 = 2816,
            QUAT_3 = 2817,
            EULER_0 = 2818,
            EULER_1 = 2819,
            EULER_2 = 2820,
            OUTPUT_COUNTER = 2821,
            OUTPUT_BOOT_TIME_MS = 2822,
            CHIP_STABILIZATION_CYCLE_QTY = 2823,
            OUTPUT_STABILIZATION_CYCLE_QTY = 2824,
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
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_4_CONNECTION_RESULT = 4284,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_4_CONNECTION_RETRY = 4285,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_4_CONNECTION_TIME_US_0 = 4286,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_4_CONNECTION_TIME_US_1 = 4287,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_4_CONFIG_RESULT = 4288,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_4_CONFIG_RETRY = 4289,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_4_CONFIG_TIME_US_0 = 4290,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_4_CONFIG_TIME_US_1 = 4291,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_5_CONNECTION_RESULT = 4292,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_5_CONNECTION_RETRY = 4293,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_5_CONNECTION_TIME_US_0 = 4294,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_5_CONNECTION_TIME_US_1 = 4295,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_5_CONFIG_RESULT = 4296,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_5_CONFIG_RETRY = 4297,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_5_CONFIG_TIME_US_0 = 4298,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_5_CONFIG_TIME_US_1 = 4299,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_6_CONNECTION_RESULT = 4300,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_6_CONNECTION_RETRY = 4301,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_6_CONNECTION_TIME_US_0 = 4302,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_6_CONNECTION_TIME_US_1 = 4303,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_6_CONFIG_RESULT = 4304,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_6_CONFIG_RETRY = 4305,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_6_CONFIG_TIME_US_0 = 4306,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_6_CONFIG_TIME_US_1 = 4307,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_7_CONNECTION_RESULT = 4308,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_7_CONNECTION_RETRY = 4309,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_7_CONNECTION_TIME_US_0 = 4310,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_7_CONNECTION_TIME_US_1 = 4311,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_7_CONFIG_RESULT = 4312,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_7_CONFIG_RETRY = 4313,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_7_CONFIG_TIME_US_0 = 4314,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_7_CONFIG_TIME_US_1 = 4315,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_8_CONNECTION_RESULT = 4316,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_8_CONNECTION_RETRY = 4317,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_8_CONNECTION_TIME_US_0 = 4318,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_8_CONNECTION_TIME_US_1 = 4319,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_8_CONFIG_RESULT = 4320,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_8_CONFIG_RETRY = 4321,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_8_CONFIG_TIME_US_0 = 4322,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_8_CONFIG_TIME_US_1 = 4323,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_9_CONNECTION_RESULT = 4324,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_9_CONNECTION_RETRY = 4325,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_9_CONNECTION_TIME_US_0 = 4326,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_9_CONNECTION_TIME_US_1 = 4327,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_9_CONFIG_RESULT = 4328,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_9_CONFIG_RETRY = 4329,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_9_CONFIG_TIME_US_0 = 4330,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_9_CONFIG_TIME_US_1 = 4331,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_10_CONNECTION_RESULT = 4332,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_10_CONNECTION_RETRY = 4333,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_10_CONNECTION_TIME_US_0 = 4334,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_10_CONNECTION_TIME_US_1 = 4335,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_10_CONFIG_RESULT = 4336,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_10_CONFIG_RETRY = 4337,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_10_CONFIG_TIME_US_0 = 4338,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_10_CONFIG_TIME_US_1 = 4339,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_11_CONNECTION_RESULT = 4340,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_11_CONNECTION_RETRY = 4341,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_11_CONNECTION_TIME_US_0 = 4342,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_11_CONNECTION_TIME_US_1 = 4343,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_11_CONFIG_RESULT = 4344,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_11_CONFIG_RETRY = 4345,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_11_CONFIG_TIME_US_0 = 4346,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_GYRO_11_CONFIG_TIME_US_1 = 4347,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_0_CONNECTION_RESULT = 4348,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_0_CONNECTION_RETRY = 4349,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_0_CONNECTION_TIME_US_0 = 4350,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_0_CONNECTION_TIME_US_1 = 4351,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_0_CONFIG_RESULT = 4352,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_0_CONFIG_RETRY = 4353,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_0_CONFIG_TIME_US_0 = 4354,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_0_CONFIG_TIME_US_1 = 4355,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_1_CONNECTION_RESULT = 4356,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_1_CONNECTION_RETRY = 4357,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_1_CONNECTION_TIME_US_0 = 4358,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_1_CONNECTION_TIME_US_1 = 4359,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_1_CONFIG_RESULT = 4360,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_1_CONFIG_RETRY = 4361,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_1_CONFIG_TIME_US_0 = 4362,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_1_CONFIG_TIME_US_1 = 4363,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_2_CONNECTION_RESULT = 4364,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_2_CONNECTION_RETRY = 4365,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_2_CONNECTION_TIME_US_0 = 4366,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_2_CONNECTION_TIME_US_1 = 4367,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_2_CONFIG_RESULT = 4368,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_2_CONFIG_RETRY = 4369,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_2_CONFIG_TIME_US_0 = 4370,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_2_CONFIG_TIME_US_1 = 4371,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_3_CONNECTION_RESULT = 4372,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_3_CONNECTION_RETRY = 4373,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_3_CONNECTION_TIME_US_0 = 4374,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_3_CONNECTION_TIME_US_1 = 4375,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_3_CONFIG_RESULT = 4376,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_3_CONFIG_RETRY = 4377,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_3_CONFIG_TIME_US_0 = 4378,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_3_CONFIG_TIME_US_1 = 4379,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_4_CONNECTION_RESULT = 4380,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_4_CONNECTION_RETRY = 4381,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_4_CONNECTION_TIME_US_0 = 4382,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_4_CONNECTION_TIME_US_1 = 4383,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_4_CONFIG_RESULT = 4384,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_4_CONFIG_RETRY = 4385,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_4_CONFIG_TIME_US_0 = 4386,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_4_CONFIG_TIME_US_1 = 4387,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_5_CONNECTION_RESULT = 4388,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_5_CONNECTION_RETRY = 4389,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_5_CONNECTION_TIME_US_0 = 4390,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_5_CONNECTION_TIME_US_1 = 4391,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_5_CONFIG_RESULT = 4392,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_5_CONFIG_RETRY = 4393,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_5_CONFIG_TIME_US_0 = 4394,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_5_CONFIG_TIME_US_1 = 4395,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_6_CONNECTION_RESULT = 4396,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_6_CONNECTION_RETRY = 4397,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_6_CONNECTION_TIME_US_0 = 4398,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_6_CONNECTION_TIME_US_1 = 4399,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_6_CONFIG_RESULT = 4400,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_6_CONFIG_RETRY = 4401,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_6_CONFIG_TIME_US_0 = 4402,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_6_CONFIG_TIME_US_1 = 4403,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_7_CONNECTION_RESULT = 4404,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_7_CONNECTION_RETRY = 4405,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_7_CONNECTION_TIME_US_0 = 4406,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_7_CONNECTION_TIME_US_1 = 4407,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_7_CONFIG_RESULT = 4408,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_7_CONFIG_RETRY = 4409,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_7_CONFIG_TIME_US_0 = 4410,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_7_CONFIG_TIME_US_1 = 4411,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_8_CONNECTION_RESULT = 4412,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_8_CONNECTION_RETRY = 4413,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_8_CONNECTION_TIME_US_0 = 4414,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_8_CONNECTION_TIME_US_1 = 4415,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_8_CONFIG_RESULT = 4416,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_8_CONFIG_RETRY = 4417,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_8_CONFIG_TIME_US_0 = 4418,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_8_CONFIG_TIME_US_1 = 4419,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_9_CONNECTION_RESULT = 4420,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_9_CONNECTION_RETRY = 4421,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_9_CONNECTION_TIME_US_0 = 4422,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_9_CONNECTION_TIME_US_1 = 4423,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_9_CONFIG_RESULT = 4424,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_9_CONFIG_RETRY = 4425,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_9_CONFIG_TIME_US_0 = 4426,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_9_CONFIG_TIME_US_1 = 4427,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_10_CONNECTION_RESULT = 4428,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_10_CONNECTION_RETRY = 4429,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_10_CONNECTION_TIME_US_0 = 4430,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_10_CONNECTION_TIME_US_1 = 4431,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_10_CONFIG_RESULT = 4432,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_10_CONFIG_RETRY = 4433,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_10_CONFIG_TIME_US_0 = 4434,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_10_CONFIG_TIME_US_1 = 4435,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_11_CONNECTION_RESULT = 4436,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_11_CONNECTION_RETRY = 4437,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_11_CONNECTION_TIME_US_0 = 4438,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_11_CONNECTION_TIME_US_1 = 4439,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_11_CONFIG_RESULT = 4440,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_11_CONFIG_RETRY = 4441,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_11_CONFIG_TIME_US_0 = 4442,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_BMI088_ACC_11_CONFIG_TIME_US_1 = 4443,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_ADXL357_CONNECTION_RESULT = 4444,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_ADXL357_CONNECTION_RETRY = 4445,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_ADXL357_CONNECTION_TIME_US_0 = 4446,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_ADXL357_CONNECTION_TIME_US_1 = 4447,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_ADXL357_CONFIG_RESULT = 4448,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_ADXL357_CONFIG_RETRY = 4449,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_ADXL357_CONFIG_TIME_US_0 = 4450,
            PARAMETER_MB_ADDR_BOARD_STARTUP_REPORT_ADXL357_CONFIG_TIME_US_1 = 4451,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_0_X_0 = 4452,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_0_X_1 = 4453,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_0_X_2 = 4454,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_0_X_3 = 4455,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_0_Y_0 = 4456,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_0_Y_1 = 4457,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_0_Y_2 = 4458,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_0_Y_3 = 4459,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_0_Z_0 = 4460,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_0_Z_1 = 4461,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_0_Z_2 = 4462,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_0_Z_3 = 4463,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_1_X_0 = 4464,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_1_X_1 = 4465,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_1_X_2 = 4466,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_1_X_3 = 4467,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_1_Y_0 = 4468,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_1_Y_1 = 4469,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_1_Y_2 = 4470,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_1_Y_3 = 4471,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_1_Z_0 = 4472,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_1_Z_1 = 4473,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_1_Z_2 = 4474,
            PARAMETER_MB_ADDR_IMU_DATA_ACC_G_1_Z_3 = 4475,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_0_X_0 = 4476,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_0_X_1 = 4477,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_0_X_2 = 4478,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_0_X_3 = 4479,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_0_Y_0 = 4480,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_0_Y_1 = 4481,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_0_Y_2 = 4482,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_0_Y_3 = 4483,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_0_Z_0 = 4484,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_0_Z_1 = 4485,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_0_Z_2 = 4486,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_0_Z_3 = 4487,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_1_X_0 = 4488,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_1_X_1 = 4489,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_1_X_2 = 4490,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_1_X_3 = 4491,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_1_Y_0 = 4492,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_1_Y_1 = 4493,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_1_Y_2 = 4494,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_1_Y_3 = 4495,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_1_Z_0 = 4496,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_1_Z_1 = 4497,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_1_Z_2 = 4498,
            PARAMETER_MB_ADDR_IMU_DATA_GYR_DPS_1_Z_3 = 4499,
            PARAMETER_MB_ADDR_IMU_DATA_TEMPERATURE_0 = 4500,
            PARAMETER_MB_ADDR_IMU_DATA_TEMPERATURE_1 = 4501,
            PARAMETER_MB_ADDR_IMU_DATA_TEMPERATURE_2 = 4502,
            PARAMETER_MB_ADDR_IMU_DATA_TEMPERATURE_3 = 4503,
            PARAMETER_MB_ADDR_IMU_DATA_COUNTER_0 = 4504,
            PARAMETER_MB_ADDR_IMU_DATA_COUNTER_1 = 4505,
            PARAMETER_MB_ADDR_IMU_DATA_IS_NEW_DATA = 4506,
            PARAMETER_MB_ADDR_IMU_DATA_ACTIVE = 4507,
            PARAMETER_MB_ADDR_IMU_DATA_SUMMARY_STATUS_0 = 4508,
            PARAMETER_MB_ADDR_IMU_DATA_SUMMARY_STATUS_1 = 4509,
            PARAMETER_MB_ADDR_IMU_SETTING_TYPE = 4510,
            PARAMETER_MB_ADDR_IMU_SETTING_DEC_RATE = 4511,
            PARAMETER_MB_ADDR_IMU_SETTING_ENABLE = 4512,
            PARAMETER_MB_ADDR_M9N_DATA_ITOW_0 = 4513,
            PARAMETER_MB_ADDR_M9N_DATA_ITOW_1 = 4514,
            PARAMETER_MB_ADDR_M9N_DATA_YEAR = 4515,
            PARAMETER_MB_ADDR_M9N_DATA_MONTH = 4516,
            PARAMETER_MB_ADDR_M9N_DATA_DAY = 4517,
            PARAMETER_MB_ADDR_M9N_DATA_HOURS = 4518,
            PARAMETER_MB_ADDR_M9N_DATA_MIN = 4519,
            PARAMETER_MB_ADDR_M9N_DATA_SEC = 4520,
            PARAMETER_MB_ADDR_M9N_DATA_VALID = 4521,
            PARAMETER_MB_ADDR_M9N_DATA_TACC_0 = 4522,
            PARAMETER_MB_ADDR_M9N_DATA_TACC_1 = 4523,
            PARAMETER_MB_ADDR_M9N_DATA_NANO_0 = 4524,
            PARAMETER_MB_ADDR_M9N_DATA_NANO_1 = 4525,
            PARAMETER_MB_ADDR_M9N_DATA_FIX_TYPE = 4526,
            PARAMETER_MB_ADDR_M9N_DATA_FLAGS = 4527,
            PARAMETER_MB_ADDR_M9N_DATA_FLAGS2 = 4528,
            PARAMETER_MB_ADDR_M9N_DATA_NUM_SV = 4529,
            PARAMETER_MB_ADDR_M9N_DATA_LON_0 = 4530,
            PARAMETER_MB_ADDR_M9N_DATA_LON_1 = 4531,
            PARAMETER_MB_ADDR_M9N_DATA_LON_2 = 4532,
            PARAMETER_MB_ADDR_M9N_DATA_LON_3 = 4533,
            PARAMETER_MB_ADDR_M9N_DATA_LAT_0 = 4534,
            PARAMETER_MB_ADDR_M9N_DATA_LAT_1 = 4535,
            PARAMETER_MB_ADDR_M9N_DATA_LAT_2 = 4536,
            PARAMETER_MB_ADDR_M9N_DATA_LAT_3 = 4537,
            PARAMETER_MB_ADDR_M9N_DATA_HEIGHT_0 = 4538,
            PARAMETER_MB_ADDR_M9N_DATA_HEIGHT_1 = 4539,
            PARAMETER_MB_ADDR_M9N_DATA_HEIGHT_2 = 4540,
            PARAMETER_MB_ADDR_M9N_DATA_HEIGHT_3 = 4541,
            PARAMETER_MB_ADDR_M9N_DATA_HMSL_0 = 4542,
            PARAMETER_MB_ADDR_M9N_DATA_HMSL_1 = 4543,
            PARAMETER_MB_ADDR_M9N_DATA_HACC_0 = 4544,
            PARAMETER_MB_ADDR_M9N_DATA_HACC_1 = 4545,
            PARAMETER_MB_ADDR_M9N_DATA_VACC_0 = 4546,
            PARAMETER_MB_ADDR_M9N_DATA_VACC_1 = 4547,
            PARAMETER_MB_ADDR_M9N_DATA_VEL_NED_0_0 = 4548,
            PARAMETER_MB_ADDR_M9N_DATA_VEL_NED_0_1 = 4549,
            PARAMETER_MB_ADDR_M9N_DATA_VEL_NED_1_0 = 4550,
            PARAMETER_MB_ADDR_M9N_DATA_VEL_NED_1_1 = 4551,
            PARAMETER_MB_ADDR_M9N_DATA_VEL_NED_2_0 = 4552,
            PARAMETER_MB_ADDR_M9N_DATA_VEL_NED_2_1 = 4553,
            PARAMETER_MB_ADDR_M9N_DATA_GSPEED_0 = 4554,
            PARAMETER_MB_ADDR_M9N_DATA_GSPEED_1 = 4555,
            PARAMETER_MB_ADDR_M9N_DATA_HEAD_MOT_0 = 4556,
            PARAMETER_MB_ADDR_M9N_DATA_HEAD_MOT_1 = 4557,
            PARAMETER_MB_ADDR_M9N_DATA_SACC_0 = 4558,
            PARAMETER_MB_ADDR_M9N_DATA_SACC_1 = 4559,
            PARAMETER_MB_ADDR_M9N_DATA_HEAD_ACC_0 = 4560,
            PARAMETER_MB_ADDR_M9N_DATA_HEAD_ACC_1 = 4561,
            PARAMETER_MB_ADDR_M9N_DATA_PDOP = 4562,
            PARAMETER_MB_ADDR_M9N_DATA_RESERVED_0 = 4563,
            PARAMETER_MB_ADDR_M9N_DATA_RESERVED_1 = 4564,
            PARAMETER_MB_ADDR_M9N_DATA_RESERVED_2 = 4565,
            PARAMETER_MB_ADDR_M9N_DATA_RESERVED_3 = 4566,
            PARAMETER_MB_ADDR_M9N_DATA_HEAD_VEH_0 = 4567,
            PARAMETER_MB_ADDR_M9N_DATA_HEAD_VEH_1 = 4568,
            PARAMETER_MB_ADDR_M9N_DATA_MAG_DEC = 4569,
            PARAMETER_MB_ADDR_M9N_DATA_MAG_ACC = 4570,
            PARAMETER_MB_ADDR_M9N_DATA_FRAME_COUNTER_0 = 4571,
            PARAMETER_MB_ADDR_M9N_DATA_FRAME_COUNTER_1 = 4572,
            PARAMETER_MB_ADDR_M9N_DATA_FRAME_ERROR_COUNTER_0 = 4573,
            PARAMETER_MB_ADDR_M9N_DATA_FRAME_ERROR_COUNTER_1 = 4574,
            PARAMETER_MB_ADDR_M9N_DATA_IS_VALID_DATA = 4575,
            PARAMETER_MB_ADDR_M9N_DATA_IS_NEW_DATA = 4576,
            PARAMETER_MB_ADDR_M9N_DATA_ACTIVE = 4577,
            PARAMETER_MB_ADDR_M9N_DATA_SUMMARY_STATUS_0 = 4578,
            PARAMETER_MB_ADDR_M9N_DATA_SUMMARY_STATUS_1 = 4579,
            PARAMETER_MB_ADDR_DADC_DATA_ADC_IS_NEW_DATA = 4580,
            PARAMETER_MB_ADDR_DADC_DATA_ADC_UNIT = 4581,
            PARAMETER_MB_ADDR_DADC_DATA_ADC_OUTSIDE_PROBE_TEMP_0 = 4582,
            PARAMETER_MB_ADDR_DADC_DATA_ADC_OUTSIDE_PROBE_TEMP_1 = 4583,
            PARAMETER_MB_ADDR_DADC_DATA_ADC_INTERNAL_PROBE_TEMP_0 = 4584,
            PARAMETER_MB_ADDR_DADC_DATA_ADC_INTERNAL_PROBE_TEMP_1 = 4585,
            PARAMETER_MB_ADDR_DADC_DATA_ADC_STATIC_PRESSURE_0 = 4586,
            PARAMETER_MB_ADDR_DADC_DATA_ADC_STATIC_PRESSURE_1 = 4587,
            PARAMETER_MB_ADDR_DADC_DATA_ADC_PITOT_DIFF_PRESSURE_0 = 4588,
            PARAMETER_MB_ADDR_DADC_DATA_ADC_PITOT_DIFF_PRESSURE_1 = 4589,
            PARAMETER_MB_ADDR_DADC_DATA_ADA_IS_NEW_DATA = 4590,
            PARAMETER_MB_ADDR_DADC_DATA_ADA_UNIT = 4591,
            PARAMETER_MB_ADDR_DADC_DATA_ADA_PRESSURE_ALTITUDE_0 = 4592,
            PARAMETER_MB_ADDR_DADC_DATA_ADA_PRESSURE_ALTITUDE_1 = 4593,
            PARAMETER_MB_ADDR_DADC_DATA_ADA_INDICATED_ALTITUDE_0 = 4594,
            PARAMETER_MB_ADDR_DADC_DATA_ADA_INDICATED_ALTITUDE_1 = 4595,
            PARAMETER_MB_ADDR_DADC_DATA_ADA_TRUE_ALTITUDE_0 = 4596,
            PARAMETER_MB_ADDR_DADC_DATA_ADA_TRUE_ALTITUDE_1 = 4597,
            PARAMETER_MB_ADDR_DADC_DATA_ADA_RATE_OF_CLIMB_0 = 4598,
            PARAMETER_MB_ADDR_DADC_DATA_ADA_RATE_OF_CLIMB_1 = 4599,
            PARAMETER_MB_ADDR_DADC_DATA_ADA_OUTSIDE_AIR_TEMPERATURE_0 = 4600,
            PARAMETER_MB_ADDR_DADC_DATA_ADA_OUTSIDE_AIR_TEMPERATURE_1 = 4601,
            PARAMETER_MB_ADDR_DADC_DATA_ADA_TOTAL_AIR_TEMPERATURE_0 = 4602,
            PARAMETER_MB_ADDR_DADC_DATA_ADA_TOTAL_AIR_TEMPERATURE_1 = 4603,
            PARAMETER_MB_ADDR_DADC_DATA_ADA_DIFF_OUTSIDE_AIR_TEMP_AND_ISA_0 = 4604,
            PARAMETER_MB_ADDR_DADC_DATA_ADA_DIFF_OUTSIDE_AIR_TEMP_AND_ISA_1 = 4605,
            PARAMETER_MB_ADDR_DADC_DATA_ADV_IS_NEW_DATA = 4606,
            PARAMETER_MB_ADDR_DADC_DATA_ADV_UNIT = 4607,
            PARAMETER_MB_ADDR_DADC_DATA_ADV_CALIBRATED_AIR_SPEED_0 = 4608,
            PARAMETER_MB_ADDR_DADC_DATA_ADV_CALIBRATED_AIR_SPEED_1 = 4609,
            PARAMETER_MB_ADDR_DADC_DATA_ADV_TRUE_AIRSPEED_0 = 4610,
            PARAMETER_MB_ADDR_DADC_DATA_ADV_TRUE_AIRSPEED_1 = 4611,
            PARAMETER_MB_ADDR_DADC_DATA_ADV_MACH_NUM_0 = 4612,
            PARAMETER_MB_ADDR_DADC_DATA_ADV_MACH_NUM_1 = 4613,
            PARAMETER_MB_ADDR_DADC_DATA_ADV_AIR_DENSITY_0 = 4614,
            PARAMETER_MB_ADDR_DADC_DATA_ADV_AIR_DENSITY_1 = 4615,
            PARAMETER_MB_ADDR_DADC_DATA_ADR_IS_NEW_DATA = 4616,
            PARAMETER_MB_ADDR_DADC_DATA_ADR_CPU_TEMP_0 = 4617,
            PARAMETER_MB_ADDR_DADC_DATA_ADR_CPU_TEMP_1 = 4618,
            PARAMETER_MB_ADDR_DADC_DATA_ADR_OUTSIDE_RTD_MV_0 = 4619,
            PARAMETER_MB_ADDR_DADC_DATA_ADR_OUTSIDE_RTD_MV_1 = 4620,
            PARAMETER_MB_ADDR_DADC_DATA_ADR_INSIDE_RTD_MV_0 = 4621,
            PARAMETER_MB_ADDR_DADC_DATA_ADR_INSIDE_RTD_MV_1 = 4622,
            PARAMETER_MB_ADDR_DADC_DATA_ADR_STATIC_PRESS_V_0 = 4623,
            PARAMETER_MB_ADDR_DADC_DATA_ADR_STATIC_PRESS_V_1 = 4624,
            PARAMETER_MB_ADDR_DADC_DATA_ADR_DIFF_PRESS_V_0 = 4625,
            PARAMETER_MB_ADDR_DADC_DATA_ADR_DIFF_PRESS_V_1 = 4626,
            PARAMETER_MB_ADDR_DADC_DATA_ACTIVE = 4627,
            PARAMETER_MB_ADDR_DADC_DATA_SUMMARY_STATUS_0 = 4628,
            PARAMETER_MB_ADDR_DADC_DATA_SUMMARY_STATUS_1 = 4629,
            PARAMETER_MB_ADDR_HMC5983_DATA_MAG_X = 4630,
            PARAMETER_MB_ADDR_HMC5983_DATA_MAG_Y = 4631,
            PARAMETER_MB_ADDR_HMC5983_DATA_MAG_Z = 4632,
            PARAMETER_MB_ADDR_HMC5983_DATA_TEMPERATURE_0 = 4633,
            PARAMETER_MB_ADDR_HMC5983_DATA_TEMPERATURE_1 = 4634,
            PARAMETER_MB_ADDR_HMC5983_DATA_TEMPERATURE_2 = 4635,
            PARAMETER_MB_ADDR_HMC5983_DATA_TEMPERATURE_3 = 4636,
            PARAMETER_MB_ADDR_HMC5983_DATA_IS_NEW_DATA = 4637,
            PARAMETER_MB_ADDR_HMC5983_DATA_ACTIVE = 4638,
            PARAMETER_MB_ADDR_HMC5983_DATA_SUMMARY_STATUS_0 = 4639,
            PARAMETER_MB_ADDR_HMC5983_DATA_SUMMARY_STATUS_1 = 4640,
            PARAMETER_MB_ADDR_HMC5983_SETTING_ODR = 4641,
            PARAMETER_MB_ADDR_HMC5983_SETTING_SAMPLE_AVERAGE = 4642,
            PARAMETER_MB_ADDR_HMC5983_SETTING_GAIN = 4643,
            PARAMETER_MB_ADDR_HMC5983_SETTING_ENABLE = 4644,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_JETSON_TIME_UTC_0 = 4645,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_JETSON_TIME_UTC_1 = 4646,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_RAW_LAT_DEG_0 = 4647,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_RAW_LAT_DEG_1 = 4648,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_RAW_LAT_DEG_2 = 4649,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_RAW_LAT_DEG_3 = 4650,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_RAW_LON_DEG_0 = 4651,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_RAW_LON_DEG_1 = 4652,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_RAW_LON_DEG_2 = 4653,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_RAW_LON_DEG_3 = 4654,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_EST_LAT_DEG_0 = 4655,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_EST_LAT_DEG_1 = 4656,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_EST_LAT_DEG_2 = 4657,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_EST_LAT_DEG_3 = 4658,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_EST_LON_DEG_0 = 4659,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_EST_LON_DEG_1 = 4660,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_EST_LON_DEG_2 = 4661,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_EST_LON_DEG_3 = 4662,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_AGL_M_0 = 4663,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_AGL_M_1 = 4664,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_AGL_M_2 = 4665,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_AGL_M_3 = 4666,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_DEM_ALT_M_0 = 4667,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_DEM_ALT_M_1 = 4668,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_DEM_ALT_M_2 = 4669,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_DEM_ALT_M_3 = 4670,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_ROLL_FUS_DEG_0 = 4671,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_ROLL_FUS_DEG_1 = 4672,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_ROLL_FUS_DEG_2 = 4673,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_ROLL_FUS_DEG_3 = 4674,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_PITCH_FUS_DEG_0 = 4675,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_PITCH_FUS_DEG_1 = 4676,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_PITCH_FUS_DEG_2 = 4677,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_PITCH_FUS_DEG_3 = 4678,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_YAW_FUS_DEG_0 = 4679,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_YAW_FUS_DEG_1 = 4680,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_YAW_FUS_DEG_2 = 4681,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_YAW_FUS_DEG_3 = 4682,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_HEADING_DEG_0 = 4683,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_HEADING_DEG_1 = 4684,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_HEADING_DEG_2 = 4685,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_HEADING_DEG_3 = 4686,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_COURES_DEG_0 = 4687,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_COURES_DEG_1 = 4688,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_COURES_DEG_2 = 4689,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_COURES_DEG_3 = 4690,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_QUALITY_MATCH = 4691,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_STATUS_FLAGS = 4692,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_UPDATE_MASK_0 = 4693,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_UPDATE_MASK_1 = 4694,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_EXCUTION_TIME_MS = 4695,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_IS_NEW_DATA = 4696,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_ACTIVE = 4697,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_SUMMARY_STATUS_0 = 4698,
            PARAMETER_MB_ADDR_IBNS_MATCH_DATA_SUMMARY_STATUS_1 = 4699,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_JETSON_TIME_UTC_0 = 4700,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_JETSON_TIME_UTC_1 = 4701,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ODOLAT_DEG_0 = 4702,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ODOLAT_DEG_1 = 4703,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ODOLAT_DEG_2 = 4704,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ODOLAT_DEG_3 = 4705,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ODOLON_DEG_0 = 4706,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ODOLON_DEG_1 = 4707,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ODOLON_DEG_2 = 4708,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ODOLON_DEG_3 = 4709,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ALT_M_0 = 4710,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ALT_M_1 = 4711,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ALT_M_2 = 4712,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ALT_M_3 = 4713,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ROLL_FUS_DEG_0 = 4714,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ROLL_FUS_DEG_1 = 4715,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ROLL_FUS_DEG_2 = 4716,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ROLL_FUS_DEG_3 = 4717,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_PITCH_FUS_DEG_0 = 4718,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_PITCH_FUS_DEG_1 = 4719,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_PITCH_FUS_DEG_2 = 4720,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_PITCH_FUS_DEG_3 = 4721,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_YAW_FUS_DEG_0 = 4722,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_YAW_FUS_DEG_1 = 4723,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_YAW_FUS_DEG_2 = 4724,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_YAW_FUS_DEG_3 = 4725,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_SPEED_MPS_0 = 4726,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_SPEED_MPS_1 = 4727,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_SPEED_MPS_2 = 4728,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_SPEED_MPS_3 = 4729,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_QUALITY_SPEED = 4730,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ODO_DX_M_0 = 4731,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ODO_DX_M_1 = 4732,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ODO_DX_M_2 = 4733,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ODO_DX_M_3 = 4734,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ODO_DY_M_0 = 4735,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ODO_DY_M_1 = 4736,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ODO_DY_M_2 = 4737,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ODO_DY_M_3 = 4738,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_STATUS_FLAGS = 4739,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_UPDATE_MASK_0 = 4740,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_UPDATE_MASK_1 = 4741,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_EXCUTION_TIME_MS = 4742,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_IS_NEW_DATA = 4743,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_ACTIVE = 4744,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_SUMMARY_STATUS_0 = 4745,
            PARAMETER_MB_ADDR_IBNS_SPEED_DATA_SUMMARY_STATUS_1 = 4746,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_IS_NEW_DATA = 4747,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_EULER_RAD_0_0 = 4748,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_EULER_RAD_0_1 = 4749,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_EULER_RAD_0_2 = 4750,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_EULER_RAD_0_3 = 4751,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_EULER_RAD_1_0 = 4752,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_EULER_RAD_1_1 = 4753,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_EULER_RAD_1_2 = 4754,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_EULER_RAD_1_3 = 4755,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_EULER_RAD_2_0 = 4756,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_EULER_RAD_2_1 = 4757,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_EULER_RAD_2_2 = 4758,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_EULER_RAD_2_3 = 4759,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_COURSE_RAD_0 = 4760,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_COURSE_RAD_1 = 4761,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_COURSE_RAD_2 = 4762,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_COURSE_RAD_3 = 4763,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_ACC_ENU_MPS2_0_0 = 4764,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_ACC_ENU_MPS2_0_1 = 4765,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_ACC_ENU_MPS2_0_2 = 4766,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_ACC_ENU_MPS2_0_3 = 4767,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_ACC_ENU_MPS2_1_0 = 4768,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_ACC_ENU_MPS2_1_1 = 4769,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_ACC_ENU_MPS2_1_2 = 4770,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_ACC_ENU_MPS2_1_3 = 4771,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_ACC_ENU_MPS2_2_0 = 4772,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_ACC_ENU_MPS2_2_1 = 4773,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_ACC_ENU_MPS2_2_2 = 4774,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_ACC_ENU_MPS2_2_3 = 4775,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_GYRO_ENU_RPS_0_0 = 4776,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_GYRO_ENU_RPS_0_1 = 4777,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_GYRO_ENU_RPS_0_2 = 4778,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_GYRO_ENU_RPS_0_3 = 4779,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_GYRO_ENU_RPS_1_0 = 4780,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_GYRO_ENU_RPS_1_1 = 4781,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_GYRO_ENU_RPS_1_2 = 4782,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_GYRO_ENU_RPS_1_3 = 4783,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_GYRO_ENU_RPS_2_0 = 4784,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_GYRO_ENU_RPS_2_1 = 4785,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_GYRO_ENU_RPS_2_2 = 4786,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_GYRO_ENU_RPS_2_3 = 4787,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_STATUS = 4788,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_LLA_RRM_0_0 = 4789,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_LLA_RRM_0_1 = 4790,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_LLA_RRM_0_2 = 4791,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_LLA_RRM_0_3 = 4792,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_LLA_RRM_1_0 = 4793,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_LLA_RRM_1_1 = 4794,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_LLA_RRM_1_2 = 4795,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_LLA_RRM_1_3 = 4796,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_LLA_RRM_2_0 = 4797,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_LLA_RRM_2_1 = 4798,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_LLA_RRM_2_2 = 4799,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_LLA_RRM_2_3 = 4800,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_VEL_ENU_0_0 = 4801,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_VEL_ENU_0_1 = 4802,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_VEL_ENU_0_2 = 4803,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_VEL_ENU_0_3 = 4804,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_VEL_ENU_1_0 = 4805,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_VEL_ENU_1_1 = 4806,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_VEL_ENU_1_2 = 4807,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_VEL_ENU_1_3 = 4808,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_VEL_ENU_2_0 = 4809,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_VEL_ENU_2_1 = 4810,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_VEL_ENU_2_2 = 4811,
            PARAMETER_MB_ADDR_SADRA_DATA_INS_FRAME_VEL_ENU_2_3 = 4812,
            PARAMETER_MB_ADDR_SADRA_DATA_GPS_FRAME_IS_NEW_DATA = 4813,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_I_TOW_0 = 4814,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_I_TOW_1 = 4815,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_F_TOW_0 = 4816,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_F_TOW_1 = 4817,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_NUM_SV = 4818,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_WEEK = 4819,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_GPSFIX = 4820,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_FLAG = 4821,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_POS_ECEF_0_0 = 4822,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_POS_ECEF_0_1 = 4823,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_POS_ECEF_0_2 = 4824,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_POS_ECEF_0_3 = 4825,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_POS_ECEF_1_0 = 4826,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_POS_ECEF_1_1 = 4827,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_POS_ECEF_1_2 = 4828,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_POS_ECEF_1_3 = 4829,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_POS_ECEF_2_0 = 4830,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_POS_ECEF_2_1 = 4831,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_POS_ECEF_2_2 = 4832,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_POS_ECEF_2_3 = 4833,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_VEL_ECEF_0_0 = 4834,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_VEL_ECEF_0_1 = 4835,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_VEL_ECEF_1_0 = 4836,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_VEL_ECEF_1_1 = 4837,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_VEL_ECEF_2_0 = 4838,
            PARAMETER_MB_ADDR_SADRA_DATA_GPSFRAME_VEL_ECEF_2_1 = 4839,
            PARAMETER_MB_ADDR_SADRA_DATA_ACTIVE = 4840,
            PARAMETER_MB_ADDR_SADRA_DATA_SUMMARY_STATUS_0 = 4841,
            PARAMETER_MB_ADDR_SADRA_DATA_SUMMARY_STATUS_1 = 4842,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_US_0 = 4843,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_US_1 = 4844,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_MAXIMA_US_0 = 4845,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_MAXIMA_US_1 = 4846,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_MINIMA_US_0 = 4847,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_MINIMA_US_1 = 4848,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_LIMIT_EXCEED_COUNTER_0 = 4849,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_INTERVAL_TIME_LIMIT_EXCEED_COUNTER_1 = 4850,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_INTERVAL_TIMING_ERROR = 4851,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_EXECUTION_TIME_US_0 = 4852,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_EXECUTION_TIME_US_1 = 4853,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_EXECUTION_TIME_MAXIMA_US_0 = 4854,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_EXECUTION_TIME_MAXIMA_US_1 = 4855,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_EXECUTION_TIME_MINIMA_US_0 = 4856,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_EXECUTION_TIME_MINIMA_US_1 = 4857,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_RUN_COUNTER_0 = 4858,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_DATA_RUN_COUNTER_1 = 4859,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_SETTING_INTERVAL_TIME_NOMINAL_US_0 = 4860,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_SETTING_INTERVAL_TIME_NOMINAL_US_1 = 4861,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_SETTING_INTERVAL_TIME_MAX_ALLOWED_JITTER_US_0 = 4862,
            PARAMETER_MB_ADDR_MAIN_LOOP_PROFILER_SETTING_INTERVAL_TIME_MAX_ALLOWED_JITTER_US_1 = 4863,
            PARAMETER_MB_ADDR_CALC_VERSION_MAJOR = 4864,
            PARAMETER_MB_ADDR_CALC_VERSION_MINOR = 4865,
            PARAMETER_MB_ADDR_CALC_VERSION_BUILD1 = 4866,
            PARAMETER_MB_ADDR_CALC_VERSION_BUILD2_0 = 4867,
            PARAMETER_MB_ADDR_CALC_VERSION_BUILD2_1 = 4868,
            PARAMETER_MB_ADDR_CALC_STATUS_0 = 4869,
            PARAMETER_MB_ADDR_CALC_STATUS_1 = 4870,
            PARAMETER_MB_ADDR_CALC_FREQ_HZ = 4871,
            PARAMETER_MB_ADDR_CALC_COUNTER_0 = 4872,
            PARAMETER_MB_ADDR_CALC_COUNTER_1 = 4873,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_0_0 = 4874,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_0_1 = 4875,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_0_2 = 4876,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_0_3 = 4877,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_1_0 = 4878,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_1_1 = 4879,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_1_2 = 4880,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_1_3 = 4881,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_2_0 = 4882,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_2_1 = 4883,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_2_2 = 4884,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_2_3 = 4885,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_3_0 = 4886,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_3_1 = 4887,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_3_2 = 4888,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_3_3 = 4889,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_4_0 = 4890,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_4_1 = 4891,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_4_2 = 4892,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_4_3 = 4893,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_5_0 = 4894,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_5_1 = 4895,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_5_2 = 4896,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_5_3 = 4897,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_6_0 = 4898,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_6_1 = 4899,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_6_2 = 4900,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_6_3 = 4901,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_7_0 = 4902,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_7_1 = 4903,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_7_2 = 4904,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_7_3 = 4905,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_8_0 = 4906,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_8_1 = 4907,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_8_2 = 4908,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_8_3 = 4909,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_9_0 = 4910,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_9_1 = 4911,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_9_2 = 4912,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_9_3 = 4913,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_10_0 = 4914,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_10_1 = 4915,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_10_2 = 4916,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_10_3 = 4917,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_11_0 = 4918,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_11_1 = 4919,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_11_2 = 4920,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_11_3 = 4921,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_12_0 = 4922,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_12_1 = 4923,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_12_2 = 4924,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_12_3 = 4925,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_13_0 = 4926,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_13_1 = 4927,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_13_2 = 4928,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_13_3 = 4929,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_14_0 = 4930,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_14_1 = 4931,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_14_2 = 4932,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_14_3 = 4933,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_15_0 = 4934,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_15_1 = 4935,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_15_2 = 4936,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_15_3 = 4937,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_16_0 = 4938,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_16_1 = 4939,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_16_2 = 4940,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_16_3 = 4941,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_17_0 = 4942,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_17_1 = 4943,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_17_2 = 4944,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_17_3 = 4945,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_18_0 = 4946,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_18_1 = 4947,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_18_2 = 4948,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_18_3 = 4949,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_19_0 = 4950,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_19_1 = 4951,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_19_2 = 4952,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_19_3 = 4953,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_20_0 = 4954,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_20_1 = 4955,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_20_2 = 4956,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_20_3 = 4957,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_21_0 = 4958,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_21_1 = 4959,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_21_2 = 4960,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_21_3 = 4961,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_22_0 = 4962,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_22_1 = 4963,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_22_2 = 4964,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_22_3 = 4965,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_23_0 = 4966,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_23_1 = 4967,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_23_2 = 4968,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_23_3 = 4969,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_24_0 = 4970,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_24_1 = 4971,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_24_2 = 4972,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_24_3 = 4973,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_25_0 = 4974,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_25_1 = 4975,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_25_2 = 4976,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_25_3 = 4977,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_26_0 = 4978,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_26_1 = 4979,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_26_2 = 4980,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_26_3 = 4981,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_27_0 = 4982,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_27_1 = 4983,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_27_2 = 4984,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_27_3 = 4985,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_28_0 = 4986,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_28_1 = 4987,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_28_2 = 4988,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_28_3 = 4989,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_29_0 = 4990,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_29_1 = 4991,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_29_2 = 4992,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_29_3 = 4993,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_30_0 = 4994,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_30_1 = 4995,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_30_2 = 4996,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_30_3 = 4997,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_31_0 = 4998,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_31_1 = 4999,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_31_2 = 5000,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_31_3 = 5001,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_32_0 = 5002,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_32_1 = 5003,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_32_2 = 5004,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_32_3 = 5005,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_33_0 = 5006,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_33_1 = 5007,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_33_2 = 5008,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_33_3 = 5009,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_34_0 = 5010,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_34_1 = 5011,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_34_2 = 5012,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_34_3 = 5013,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_35_0 = 5014,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_35_1 = 5015,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_35_2 = 5016,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_35_3 = 5017,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_36_0 = 5018,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_36_1 = 5019,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_36_2 = 5020,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_36_3 = 5021,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_37_0 = 5022,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_37_1 = 5023,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_37_2 = 5024,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_37_3 = 5025,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_38_0 = 5026,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_38_1 = 5027,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_38_2 = 5028,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_38_3 = 5029,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_39_0 = 5030,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_39_1 = 5031,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_39_2 = 5032,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_39_3 = 5033,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_40_0 = 5034,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_40_1 = 5035,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_40_2 = 5036,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_40_3 = 5037,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_41_0 = 5038,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_41_1 = 5039,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_41_2 = 5040,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_41_3 = 5041,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_42_0 = 5042,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_42_1 = 5043,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_42_2 = 5044,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_42_3 = 5045,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_43_0 = 5046,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_43_1 = 5047,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_43_2 = 5048,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_43_3 = 5049,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_44_0 = 5050,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_44_1 = 5051,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_44_2 = 5052,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_44_3 = 5053,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_45_0 = 5054,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_45_1 = 5055,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_45_2 = 5056,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_45_3 = 5057,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_46_0 = 5058,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_46_1 = 5059,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_46_2 = 5060,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_46_3 = 5061,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_47_0 = 5062,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_47_1 = 5063,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_47_2 = 5064,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_47_3 = 5065,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_48_0 = 5066,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_48_1 = 5067,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_48_2 = 5068,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_48_3 = 5069,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_49_0 = 5070,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_49_1 = 5071,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_49_2 = 5072,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_49_3 = 5073,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_50_0 = 5074,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_50_1 = 5075,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_50_2 = 5076,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_50_3 = 5077,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_51_0 = 5078,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_51_1 = 5079,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_51_2 = 5080,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_51_3 = 5081,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_52_0 = 5082,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_52_1 = 5083,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_52_2 = 5084,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_52_3 = 5085,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_53_0 = 5086,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_53_1 = 5087,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_53_2 = 5088,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_53_3 = 5089,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_54_0 = 5090,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_54_1 = 5091,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_54_2 = 5092,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_54_3 = 5093,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_55_0 = 5094,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_55_1 = 5095,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_55_2 = 5096,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_55_3 = 5097,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_56_0 = 5098,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_56_1 = 5099,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_56_2 = 5100,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_56_3 = 5101,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_57_0 = 5102,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_57_1 = 5103,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_57_2 = 5104,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_57_3 = 5105,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_58_0 = 5106,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_58_1 = 5107,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_58_2 = 5108,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_58_3 = 5109,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_59_0 = 5110,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_59_1 = 5111,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_59_2 = 5112,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_59_3 = 5113,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_60_0 = 5114,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_60_1 = 5115,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_60_2 = 5116,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_60_3 = 5117,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_61_0 = 5118,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_61_1 = 5119,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_61_2 = 5120,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_61_3 = 5121,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_62_0 = 5122,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_62_1 = 5123,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_62_2 = 5124,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_62_3 = 5125,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_63_0 = 5126,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_63_1 = 5127,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_63_2 = 5128,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_63_3 = 5129,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_64_0 = 5130,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_64_1 = 5131,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_64_2 = 5132,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_64_3 = 5133,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_65_0 = 5134,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_65_1 = 5135,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_65_2 = 5136,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_65_3 = 5137,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_66_0 = 5138,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_66_1 = 5139,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_66_2 = 5140,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_66_3 = 5141,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_67_0 = 5142,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_67_1 = 5143,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_67_2 = 5144,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_67_3 = 5145,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_68_0 = 5146,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_68_1 = 5147,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_68_2 = 5148,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_68_3 = 5149,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_69_0 = 5150,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_69_1 = 5151,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_69_2 = 5152,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_69_3 = 5153,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_70_0 = 5154,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_70_1 = 5155,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_70_2 = 5156,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_70_3 = 5157,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_71_0 = 5158,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_71_1 = 5159,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_71_2 = 5160,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_71_3 = 5161,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_72_0 = 5162,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_72_1 = 5163,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_72_2 = 5164,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_72_3 = 5165,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_73_0 = 5166,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_73_1 = 5167,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_73_2 = 5168,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_73_3 = 5169,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_74_0 = 5170,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_74_1 = 5171,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_74_2 = 5172,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_74_3 = 5173,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_75_0 = 5174,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_75_1 = 5175,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_75_2 = 5176,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_75_3 = 5177,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_76_0 = 5178,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_76_1 = 5179,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_76_2 = 5180,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_76_3 = 5181,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_77_0 = 5182,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_77_1 = 5183,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_77_2 = 5184,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_77_3 = 5185,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_78_0 = 5186,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_78_1 = 5187,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_78_2 = 5188,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_78_3 = 5189,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_79_0 = 5190,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_79_1 = 5191,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_79_2 = 5192,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_79_3 = 5193,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_80_0 = 5194,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_80_1 = 5195,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_80_2 = 5196,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_80_3 = 5197,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_81_0 = 5198,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_81_1 = 5199,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_81_2 = 5200,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_81_3 = 5201,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_82_0 = 5202,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_82_1 = 5203,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_82_2 = 5204,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_82_3 = 5205,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_83_0 = 5206,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_83_1 = 5207,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_83_2 = 5208,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_83_3 = 5209,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_84_0 = 5210,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_84_1 = 5211,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_84_2 = 5212,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_84_3 = 5213,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_85_0 = 5214,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_85_1 = 5215,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_85_2 = 5216,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_85_3 = 5217,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_86_0 = 5218,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_86_1 = 5219,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_86_2 = 5220,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_86_3 = 5221,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_87_0 = 5222,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_87_1 = 5223,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_87_2 = 5224,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_87_3 = 5225,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_88_0 = 5226,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_88_1 = 5227,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_88_2 = 5228,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_88_3 = 5229,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_89_0 = 5230,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_89_1 = 5231,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_89_2 = 5232,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_89_3 = 5233,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_90_0 = 5234,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_90_1 = 5235,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_90_2 = 5236,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_90_3 = 5237,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_91_0 = 5238,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_91_1 = 5239,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_91_2 = 5240,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_91_3 = 5241,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_92_0 = 5242,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_92_1 = 5243,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_92_2 = 5244,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_92_3 = 5245,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_93_0 = 5246,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_93_1 = 5247,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_93_2 = 5248,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_93_3 = 5249,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_94_0 = 5250,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_94_1 = 5251,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_94_2 = 5252,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_94_3 = 5253,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_95_0 = 5254,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_95_1 = 5255,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_95_2 = 5256,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_95_3 = 5257,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_96_0 = 5258,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_96_1 = 5259,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_96_2 = 5260,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_96_3 = 5261,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_97_0 = 5262,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_97_1 = 5263,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_97_2 = 5264,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_97_3 = 5265,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_98_0 = 5266,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_98_1 = 5267,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_98_2 = 5268,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_98_3 = 5269,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_99_0 = 5270,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_99_1 = 5271,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_99_2 = 5272,
            PARAMETER_MB_ADDR_DEBUG_SIGNALS_99_3 = 5273,
            PARAMETER_MB_ADDR_ZUPTUSE = 5274,
            PARAMETER_MB_ADDR_GNSSUSE = 5275,
            PARAMETER_MB_ADDR_AIR_DATA_ALL_USE = 5276,
            PARAMETER_MB_ADDR_AIR_DATA_SPEED_USE = 5277,
            PARAMETER_MB_ADDR_AIR_DATA_ALTITUDE_USE = 5278,
            PARAMETER_MB_ADDR_VISION_USE = 5279,
            PARAMETER_MB_ADDR_MAG_USE = 5280,
            PARAMETER_MB_ADDR_ALGORITHM_RESET = 5281,
            PARAMETER_MB_ADDR_FLIGHT_ZERO = 5282,
            PARAMETER_MB_ADDR_ARM = 5283,
            PARAMETER_MB_ADDR_ALGORITHM_TYPE = 5284,
            PARAMETER_MB_ADDR_GNSSTYPE = 5285,
            PARAMETER_MB_ADDR_HEAD_TYPE = 5286,
            PARAMETER_MB_ADDR_ALIGN_TYPE = 5287,
            PARAMETER_MB_ADDR_NSENSOR = 5288,
            PARAMETER_MB_ADDR_INIT_IDLE_TIME_0 = 5289,
            PARAMETER_MB_ADDR_INIT_IDLE_TIME_1 = 5290,
            PARAMETER_MB_ADDR_INIT_IDLE_TIME_2 = 5291,
            PARAMETER_MB_ADDR_INIT_IDLE_TIME_3 = 5292,
            PARAMETER_MB_ADDR_INIT_LLA_RRM_0_0 = 5293,
            PARAMETER_MB_ADDR_INIT_LLA_RRM_0_1 = 5294,
            PARAMETER_MB_ADDR_INIT_LLA_RRM_0_2 = 5295,
            PARAMETER_MB_ADDR_INIT_LLA_RRM_0_3 = 5296,
            PARAMETER_MB_ADDR_INIT_LLA_RRM_1_0 = 5297,
            PARAMETER_MB_ADDR_INIT_LLA_RRM_1_1 = 5298,
            PARAMETER_MB_ADDR_INIT_LLA_RRM_1_2 = 5299,
            PARAMETER_MB_ADDR_INIT_LLA_RRM_1_3 = 5300,
            PARAMETER_MB_ADDR_INIT_LLA_RRM_2_0 = 5301,
            PARAMETER_MB_ADDR_INIT_LLA_RRM_2_1 = 5302,
            PARAMETER_MB_ADDR_INIT_LLA_RRM_2_2 = 5303,
            PARAMETER_MB_ADDR_INIT_LLA_RRM_2_3 = 5304,
            PARAMETER_MB_ADDR_INIT_HEAD_RAD_0 = 5305,
            PARAMETER_MB_ADDR_INIT_HEAD_RAD_1 = 5306,
            PARAMETER_MB_ADDR_INIT_HEAD_RAD_2 = 5307,
            PARAMETER_MB_ADDR_INIT_HEAD_RAD_3 = 5308,
            PARAMETER_MB_ADDR_ALIGN_TIME_S_0 = 5309,
            PARAMETER_MB_ADDR_ALIGN_TIME_S_1 = 5310,
            PARAMETER_MB_ADDR_ALIGN_TIME_S_2 = 5311,
            PARAMETER_MB_ADDR_ALIGN_TIME_S_3 = 5312,
            PARAMETER_MB_ADDR_REL_AZ_RAD_0 = 5313,
            PARAMETER_MB_ADDR_REL_AZ_RAD_1 = 5314,
            PARAMETER_MB_ADDR_REL_AZ_RAD_2 = 5315,
            PARAMETER_MB_ADDR_REL_AZ_RAD_3 = 5316,
            PARAMETER_MB_ADDR_SPEED0_MPS_0 = 5317,
            PARAMETER_MB_ADDR_SPEED0_MPS_1 = 5318,
            PARAMETER_MB_ADDR_SPEED0_MPS_2 = 5319,
            PARAMETER_MB_ADDR_SPEED0_MPS_3 = 5320,
            PARAMETER_MB_ADDR_EULER0_RAD_0_0 = 5321,
            PARAMETER_MB_ADDR_EULER0_RAD_0_1 = 5322,
            PARAMETER_MB_ADDR_EULER0_RAD_0_2 = 5323,
            PARAMETER_MB_ADDR_EULER0_RAD_0_3 = 5324,
            PARAMETER_MB_ADDR_EULER0_RAD_1_0 = 5325,
            PARAMETER_MB_ADDR_EULER0_RAD_1_1 = 5326,
            PARAMETER_MB_ADDR_EULER0_RAD_1_2 = 5327,
            PARAMETER_MB_ADDR_EULER0_RAD_1_3 = 5328,
            PARAMETER_MB_ADDR_EULER0_RAD_2_0 = 5329,
            PARAMETER_MB_ADDR_EULER0_RAD_2_1 = 5330,
            PARAMETER_MB_ADDR_EULER0_RAD_2_2 = 5331,
            PARAMETER_MB_ADDR_EULER0_RAD_2_3 = 5332,
            PARAMETER_MB_ADDR_RUN_TIME_S_0 = 5333,
            PARAMETER_MB_ADDR_RUN_TIME_S_1 = 5334,
            PARAMETER_MB_ADDR_RUN_TIME_S_2 = 5335,
            PARAMETER_MB_ADDR_RUN_TIME_S_3 = 5336,
            PARAMETER_MB_ADDR_CURRENT_STATE = 5337,
            PARAMETER_MB_ADDR_OBS_TYPE = 5338,
            PARAMETER_MB_ADDR_CARRIER_TYPE = 5339,
            PARAMETER_MB_ADDR_CONTROL_FLAGS_BITS_SUMMARY_0 = 5340,
            PARAMETER_MB_ADDR_CONTROL_FLAGS_BITS_SUMMARY_1 = 5341,
            PARAMETER_MB_ADDR_ALIGN_COUNTER_0 = 5342,
            PARAMETER_MB_ADDR_ALIGN_COUNTER_1 = 5343,
            PARAMETER_MB_ADDR_ALIGN_ACC_AVERAGE_0_0 = 5344,
            PARAMETER_MB_ADDR_ALIGN_ACC_AVERAGE_0_1 = 5345,
            PARAMETER_MB_ADDR_ALIGN_ACC_AVERAGE_0_2 = 5346,
            PARAMETER_MB_ADDR_ALIGN_ACC_AVERAGE_0_3 = 5347,
            PARAMETER_MB_ADDR_ALIGN_ACC_AVERAGE_1_0 = 5348,
            PARAMETER_MB_ADDR_ALIGN_ACC_AVERAGE_1_1 = 5349,
            PARAMETER_MB_ADDR_ALIGN_ACC_AVERAGE_1_2 = 5350,
            PARAMETER_MB_ADDR_ALIGN_ACC_AVERAGE_1_3 = 5351,
            PARAMETER_MB_ADDR_ALIGN_ACC_AVERAGE_2_0 = 5352,
            PARAMETER_MB_ADDR_ALIGN_ACC_AVERAGE_2_1 = 5353,
            PARAMETER_MB_ADDR_ALIGN_ACC_AVERAGE_2_2 = 5354,
            PARAMETER_MB_ADDR_ALIGN_ACC_AVERAGE_2_3 = 5355,
            PARAMETER_MB_ADDR_ALIGN_GYR_AVERAGE_0_0 = 5356,
            PARAMETER_MB_ADDR_ALIGN_GYR_AVERAGE_0_1 = 5357,
            PARAMETER_MB_ADDR_ALIGN_GYR_AVERAGE_0_2 = 5358,
            PARAMETER_MB_ADDR_ALIGN_GYR_AVERAGE_0_3 = 5359,
            PARAMETER_MB_ADDR_ALIGN_GYR_AVERAGE_1_0 = 5360,
            PARAMETER_MB_ADDR_ALIGN_GYR_AVERAGE_1_1 = 5361,
            PARAMETER_MB_ADDR_ALIGN_GYR_AVERAGE_1_2 = 5362,
            PARAMETER_MB_ADDR_ALIGN_GYR_AVERAGE_1_3 = 5363,
            PARAMETER_MB_ADDR_ALIGN_GYR_AVERAGE_2_0 = 5364,
            PARAMETER_MB_ADDR_ALIGN_GYR_AVERAGE_2_1 = 5365,
            PARAMETER_MB_ADDR_ALIGN_GYR_AVERAGE_2_2 = 5366,
            PARAMETER_MB_ADDR_ALIGN_GYR_AVERAGE_2_3 = 5367,
            PARAMETER_MB_ADDR_ALIGN_EULER0_0_0 = 5368,
            PARAMETER_MB_ADDR_ALIGN_EULER0_0_1 = 5369,
            PARAMETER_MB_ADDR_ALIGN_EULER0_0_2 = 5370,
            PARAMETER_MB_ADDR_ALIGN_EULER0_0_3 = 5371,
            PARAMETER_MB_ADDR_ALIGN_EULER0_1_0 = 5372,
            PARAMETER_MB_ADDR_ALIGN_EULER0_1_1 = 5373,
            PARAMETER_MB_ADDR_ALIGN_EULER0_1_2 = 5374,
            PARAMETER_MB_ADDR_ALIGN_EULER0_1_3 = 5375,
            PARAMETER_MB_ADDR_ALIGN_EULER0_2_0 = 5376,
            PARAMETER_MB_ADDR_ALIGN_EULER0_2_1 = 5377,
            PARAMETER_MB_ADDR_ALIGN_EULER0_2_2 = 5378,
            PARAMETER_MB_ADDR_ALIGN_EULER0_2_3 = 5379,
            PARAMETER_MB_ADDR_ALIGN_QUAT0_0_0 = 5380,
            PARAMETER_MB_ADDR_ALIGN_QUAT0_0_1 = 5381,
            PARAMETER_MB_ADDR_ALIGN_QUAT0_0_2 = 5382,
            PARAMETER_MB_ADDR_ALIGN_QUAT0_0_3 = 5383,
            PARAMETER_MB_ADDR_ALIGN_QUAT0_1_0 = 5384,
            PARAMETER_MB_ADDR_ALIGN_QUAT0_1_1 = 5385,
            PARAMETER_MB_ADDR_ALIGN_QUAT0_1_2 = 5386,
            PARAMETER_MB_ADDR_ALIGN_QUAT0_1_3 = 5387,
            PARAMETER_MB_ADDR_ALIGN_QUAT0_2_0 = 5388,
            PARAMETER_MB_ADDR_ALIGN_QUAT0_2_1 = 5389,
            PARAMETER_MB_ADDR_ALIGN_QUAT0_2_2 = 5390,
            PARAMETER_MB_ADDR_ALIGN_QUAT0_2_3 = 5391,
            PARAMETER_MB_ADDR_ALIGN_QUAT0_3_0 = 5392,
            PARAMETER_MB_ADDR_ALIGN_QUAT0_3_1 = 5393,
            PARAMETER_MB_ADDR_ALIGN_QUAT0_3_2 = 5394,
            PARAMETER_MB_ADDR_ALIGN_QUAT0_3_3 = 5395,
            PARAMETER_MB_ADDR_ALIGN_GYR_NORM0_0 = 5396,
            PARAMETER_MB_ADDR_ALIGN_GYR_NORM0_1 = 5397,
            PARAMETER_MB_ADDR_ALIGN_GYR_NORM0_2 = 5398,
            PARAMETER_MB_ADDR_ALIGN_GYR_NORM0_3 = 5399,
            PARAMETER_MB_ADDR_ALIGN_ACC_NORM0_0 = 5400,
            PARAMETER_MB_ADDR_ALIGN_ACC_NORM0_1 = 5401,
            PARAMETER_MB_ADDR_ALIGN_ACC_NORM0_2 = 5402,
            PARAMETER_MB_ADDR_ALIGN_ACC_NORM0_3 = 5403,
            PARAMETER_MB_ADDR_ALIGN_GYR_ERR0_0_0 = 5404,
            PARAMETER_MB_ADDR_ALIGN_GYR_ERR0_0_1 = 5405,
            PARAMETER_MB_ADDR_ALIGN_GYR_ERR0_0_2 = 5406,
            PARAMETER_MB_ADDR_ALIGN_GYR_ERR0_0_3 = 5407,
            PARAMETER_MB_ADDR_ALIGN_GYR_ERR0_1_0 = 5408,
            PARAMETER_MB_ADDR_ALIGN_GYR_ERR0_1_1 = 5409,
            PARAMETER_MB_ADDR_ALIGN_GYR_ERR0_1_2 = 5410,
            PARAMETER_MB_ADDR_ALIGN_GYR_ERR0_1_3 = 5411,
            PARAMETER_MB_ADDR_ALIGN_GYR_ERR0_2_0 = 5412,
            PARAMETER_MB_ADDR_ALIGN_GYR_ERR0_2_1 = 5413,
            PARAMETER_MB_ADDR_ALIGN_GYR_ERR0_2_2 = 5414,
            PARAMETER_MB_ADDR_ALIGN_GYR_ERR0_2_3 = 5415,
            PARAMETER_MB_ADDR_NAV_COUNTER_0 = 5416,
            PARAMETER_MB_ADDR_NAV_COUNTER_1 = 5417,
            PARAMETER_MB_ADDR_NAV_QUAT_0_0 = 5418,
            PARAMETER_MB_ADDR_NAV_QUAT_0_1 = 5419,
            PARAMETER_MB_ADDR_NAV_QUAT_0_2 = 5420,
            PARAMETER_MB_ADDR_NAV_QUAT_0_3 = 5421,
            PARAMETER_MB_ADDR_NAV_QUAT_1_0 = 5422,
            PARAMETER_MB_ADDR_NAV_QUAT_1_1 = 5423,
            PARAMETER_MB_ADDR_NAV_QUAT_1_2 = 5424,
            PARAMETER_MB_ADDR_NAV_QUAT_1_3 = 5425,
            PARAMETER_MB_ADDR_NAV_QUAT_2_0 = 5426,
            PARAMETER_MB_ADDR_NAV_QUAT_2_1 = 5427,
            PARAMETER_MB_ADDR_NAV_QUAT_2_2 = 5428,
            PARAMETER_MB_ADDR_NAV_QUAT_2_3 = 5429,
            PARAMETER_MB_ADDR_NAV_QUAT_3_0 = 5430,
            PARAMETER_MB_ADDR_NAV_QUAT_3_1 = 5431,
            PARAMETER_MB_ADDR_NAV_QUAT_3_2 = 5432,
            PARAMETER_MB_ADDR_NAV_QUAT_3_3 = 5433,
            PARAMETER_MB_ADDR_NAV_EULER_0_0 = 5434,
            PARAMETER_MB_ADDR_NAV_EULER_0_1 = 5435,
            PARAMETER_MB_ADDR_NAV_EULER_0_2 = 5436,
            PARAMETER_MB_ADDR_NAV_EULER_0_3 = 5437,
            PARAMETER_MB_ADDR_NAV_EULER_1_0 = 5438,
            PARAMETER_MB_ADDR_NAV_EULER_1_1 = 5439,
            PARAMETER_MB_ADDR_NAV_EULER_1_2 = 5440,
            PARAMETER_MB_ADDR_NAV_EULER_1_3 = 5441,
            PARAMETER_MB_ADDR_NAV_EULER_2_0 = 5442,
            PARAMETER_MB_ADDR_NAV_EULER_2_1 = 5443,
            PARAMETER_MB_ADDR_NAV_EULER_2_2 = 5444,
            PARAMETER_MB_ADDR_NAV_EULER_2_3 = 5445,
            PARAMETER_MB_ADDR_NAV_V_NED_0_0 = 5446,
            PARAMETER_MB_ADDR_NAV_V_NED_0_1 = 5447,
            PARAMETER_MB_ADDR_NAV_V_NED_0_2 = 5448,
            PARAMETER_MB_ADDR_NAV_V_NED_0_3 = 5449,
            PARAMETER_MB_ADDR_NAV_V_NED_1_0 = 5450,
            PARAMETER_MB_ADDR_NAV_V_NED_1_1 = 5451,
            PARAMETER_MB_ADDR_NAV_V_NED_1_2 = 5452,
            PARAMETER_MB_ADDR_NAV_V_NED_1_3 = 5453,
            PARAMETER_MB_ADDR_NAV_V_NED_2_0 = 5454,
            PARAMETER_MB_ADDR_NAV_V_NED_2_1 = 5455,
            PARAMETER_MB_ADDR_NAV_V_NED_2_2 = 5456,
            PARAMETER_MB_ADDR_NAV_V_NED_2_3 = 5457,
            PARAMETER_MB_ADDR_NAV_LLA_0_0 = 5458,
            PARAMETER_MB_ADDR_NAV_LLA_0_1 = 5459,
            PARAMETER_MB_ADDR_NAV_LLA_0_2 = 5460,
            PARAMETER_MB_ADDR_NAV_LLA_0_3 = 5461,
            PARAMETER_MB_ADDR_NAV_LLA_1_0 = 5462,
            PARAMETER_MB_ADDR_NAV_LLA_1_1 = 5463,
            PARAMETER_MB_ADDR_NAV_LLA_1_2 = 5464,
            PARAMETER_MB_ADDR_NAV_LLA_1_3 = 5465,
            PARAMETER_MB_ADDR_NAV_LLA_2_0 = 5466,
            PARAMETER_MB_ADDR_NAV_LLA_2_1 = 5467,
            PARAMETER_MB_ADDR_NAV_LLA_2_2 = 5468,
            PARAMETER_MB_ADDR_NAV_LLA_2_3 = 5469,
            PARAMETER_MB_ADDR_NAV_R_NED_0_0 = 5470,
            PARAMETER_MB_ADDR_NAV_R_NED_0_1 = 5471,
            PARAMETER_MB_ADDR_NAV_R_NED_0_2 = 5472,
            PARAMETER_MB_ADDR_NAV_R_NED_0_3 = 5473,
            PARAMETER_MB_ADDR_NAV_R_NED_1_0 = 5474,
            PARAMETER_MB_ADDR_NAV_R_NED_1_1 = 5475,
            PARAMETER_MB_ADDR_NAV_R_NED_1_2 = 5476,
            PARAMETER_MB_ADDR_NAV_R_NED_1_3 = 5477,
            PARAMETER_MB_ADDR_NAV_R_NED_2_0 = 5478,
            PARAMETER_MB_ADDR_NAV_R_NED_2_1 = 5479,
            PARAMETER_MB_ADDR_NAV_R_NED_2_2 = 5480,
            PARAMETER_MB_ADDR_NAV_R_NED_2_3 = 5481,
            PARAMETER_MB_ADDR_FUS_COUNTER_0 = 5482,
            PARAMETER_MB_ADDR_FUS_COUNTER_1 = 5483,
            PARAMETER_MB_ADDR_FUS_EULER_0_0 = 5484,
            PARAMETER_MB_ADDR_FUS_EULER_0_1 = 5485,
            PARAMETER_MB_ADDR_FUS_EULER_0_2 = 5486,
            PARAMETER_MB_ADDR_FUS_EULER_0_3 = 5487,
            PARAMETER_MB_ADDR_FUS_EULER_1_0 = 5488,
            PARAMETER_MB_ADDR_FUS_EULER_1_1 = 5489,
            PARAMETER_MB_ADDR_FUS_EULER_1_2 = 5490,
            PARAMETER_MB_ADDR_FUS_EULER_1_3 = 5491,
            PARAMETER_MB_ADDR_FUS_EULER_2_0 = 5492,
            PARAMETER_MB_ADDR_FUS_EULER_2_1 = 5493,
            PARAMETER_MB_ADDR_FUS_EULER_2_2 = 5494,
            PARAMETER_MB_ADDR_FUS_EULER_2_3 = 5495,
            PARAMETER_MB_ADDR_FUS_QUAT_0_0 = 5496,
            PARAMETER_MB_ADDR_FUS_QUAT_0_1 = 5497,
            PARAMETER_MB_ADDR_FUS_QUAT_0_2 = 5498,
            PARAMETER_MB_ADDR_FUS_QUAT_0_3 = 5499,
            PARAMETER_MB_ADDR_FUS_QUAT_1_0 = 5500,
            PARAMETER_MB_ADDR_FUS_QUAT_1_1 = 5501,
            PARAMETER_MB_ADDR_FUS_QUAT_1_2 = 5502,
            PARAMETER_MB_ADDR_FUS_QUAT_1_3 = 5503,
            PARAMETER_MB_ADDR_FUS_QUAT_2_0 = 5504,
            PARAMETER_MB_ADDR_FUS_QUAT_2_1 = 5505,
            PARAMETER_MB_ADDR_FUS_QUAT_2_2 = 5506,
            PARAMETER_MB_ADDR_FUS_QUAT_2_3 = 5507,
            PARAMETER_MB_ADDR_FUS_QUAT_3_0 = 5508,
            PARAMETER_MB_ADDR_FUS_QUAT_3_1 = 5509,
            PARAMETER_MB_ADDR_FUS_QUAT_3_2 = 5510,
            PARAMETER_MB_ADDR_FUS_QUAT_3_3 = 5511,
            PARAMETER_MB_ADDR_FUS_V_NED_0_0 = 5512,
            PARAMETER_MB_ADDR_FUS_V_NED_0_1 = 5513,
            PARAMETER_MB_ADDR_FUS_V_NED_0_2 = 5514,
            PARAMETER_MB_ADDR_FUS_V_NED_0_3 = 5515,
            PARAMETER_MB_ADDR_FUS_V_NED_1_0 = 5516,
            PARAMETER_MB_ADDR_FUS_V_NED_1_1 = 5517,
            PARAMETER_MB_ADDR_FUS_V_NED_1_2 = 5518,
            PARAMETER_MB_ADDR_FUS_V_NED_1_3 = 5519,
            PARAMETER_MB_ADDR_FUS_V_NED_2_0 = 5520,
            PARAMETER_MB_ADDR_FUS_V_NED_2_1 = 5521,
            PARAMETER_MB_ADDR_FUS_V_NED_2_2 = 5522,
            PARAMETER_MB_ADDR_FUS_V_NED_2_3 = 5523,
            PARAMETER_MB_ADDR_FUS_LLA_0_0 = 5524,
            PARAMETER_MB_ADDR_FUS_LLA_0_1 = 5525,
            PARAMETER_MB_ADDR_FUS_LLA_0_2 = 5526,
            PARAMETER_MB_ADDR_FUS_LLA_0_3 = 5527,
            PARAMETER_MB_ADDR_FUS_LLA_1_0 = 5528,
            PARAMETER_MB_ADDR_FUS_LLA_1_1 = 5529,
            PARAMETER_MB_ADDR_FUS_LLA_1_2 = 5530,
            PARAMETER_MB_ADDR_FUS_LLA_1_3 = 5531,
            PARAMETER_MB_ADDR_FUS_LLA_2_0 = 5532,
            PARAMETER_MB_ADDR_FUS_LLA_2_1 = 5533,
            PARAMETER_MB_ADDR_FUS_LLA_2_2 = 5534,
            PARAMETER_MB_ADDR_FUS_LLA_2_3 = 5535,
            PARAMETER_MB_ADDR_FUS_BA_0_0 = 5536,
            PARAMETER_MB_ADDR_FUS_BA_0_1 = 5537,
            PARAMETER_MB_ADDR_FUS_BA_0_2 = 5538,
            PARAMETER_MB_ADDR_FUS_BA_0_3 = 5539,
            PARAMETER_MB_ADDR_FUS_BA_1_0 = 5540,
            PARAMETER_MB_ADDR_FUS_BA_1_1 = 5541,
            PARAMETER_MB_ADDR_FUS_BA_1_2 = 5542,
            PARAMETER_MB_ADDR_FUS_BA_1_3 = 5543,
            PARAMETER_MB_ADDR_FUS_BA_2_0 = 5544,
            PARAMETER_MB_ADDR_FUS_BA_2_1 = 5545,
            PARAMETER_MB_ADDR_FUS_BA_2_2 = 5546,
            PARAMETER_MB_ADDR_FUS_BA_2_3 = 5547,
            PARAMETER_MB_ADDR_FUS_BG_0_0 = 5548,
            PARAMETER_MB_ADDR_FUS_BG_0_1 = 5549,
            PARAMETER_MB_ADDR_FUS_BG_0_2 = 5550,
            PARAMETER_MB_ADDR_FUS_BG_0_3 = 5551,
            PARAMETER_MB_ADDR_FUS_BG_1_0 = 5552,
            PARAMETER_MB_ADDR_FUS_BG_1_1 = 5553,
            PARAMETER_MB_ADDR_FUS_BG_1_2 = 5554,
            PARAMETER_MB_ADDR_FUS_BG_1_3 = 5555,
            PARAMETER_MB_ADDR_FUS_BG_2_0 = 5556,
            PARAMETER_MB_ADDR_FUS_BG_2_1 = 5557,
            PARAMETER_MB_ADDR_FUS_BG_2_2 = 5558,
            PARAMETER_MB_ADDR_FUS_BG_2_3 = 5559,
            PARAMETER_MB_ADDR_FUS_PSI_CC_0_0 = 5560,
            PARAMETER_MB_ADDR_FUS_PSI_CC_0_1 = 5561,
            PARAMETER_MB_ADDR_FUS_PSI_CC_0_2 = 5562,
            PARAMETER_MB_ADDR_FUS_PSI_CC_0_3 = 5563,
            PARAMETER_MB_ADDR_FUS_PSI_CC_1_0 = 5564,
            PARAMETER_MB_ADDR_FUS_PSI_CC_1_1 = 5565,
            PARAMETER_MB_ADDR_FUS_PSI_CC_1_2 = 5566,
            PARAMETER_MB_ADDR_FUS_PSI_CC_1_3 = 5567,
            PARAMETER_MB_ADDR_FUS_PSI_CC_2_0 = 5568,
            PARAMETER_MB_ADDR_FUS_PSI_CC_2_1 = 5569,
            PARAMETER_MB_ADDR_FUS_PSI_CC_2_2 = 5570,
            PARAMETER_MB_ADDR_FUS_PSI_CC_2_3 = 5571,
            PARAMETER_MB_ADDR_FUS_RESET_CNT_0 = 5572,
            PARAMETER_MB_ADDR_FUS_RESET_CNT_1 = 5573,
            PARAMETER_MB_ADDR_QUAT_0_0 = 5574,
            PARAMETER_MB_ADDR_QUAT_0_1 = 5575,
            PARAMETER_MB_ADDR_QUAT_0_2 = 5576,
            PARAMETER_MB_ADDR_QUAT_0_3 = 5577,
            PARAMETER_MB_ADDR_QUAT_1_0 = 5578,
            PARAMETER_MB_ADDR_QUAT_1_1 = 5579,
            PARAMETER_MB_ADDR_QUAT_1_2 = 5580,
            PARAMETER_MB_ADDR_QUAT_1_3 = 5581,
            PARAMETER_MB_ADDR_QUAT_2_0 = 5582,
            PARAMETER_MB_ADDR_QUAT_2_1 = 5583,
            PARAMETER_MB_ADDR_QUAT_2_2 = 5584,
            PARAMETER_MB_ADDR_QUAT_2_3 = 5585,
            PARAMETER_MB_ADDR_QUAT_3_0 = 5586,
            PARAMETER_MB_ADDR_QUAT_3_1 = 5587,
            PARAMETER_MB_ADDR_QUAT_3_2 = 5588,
            PARAMETER_MB_ADDR_QUAT_3_3 = 5589,
            PARAMETER_MB_ADDR_EULER_0_0 = 5590,
            PARAMETER_MB_ADDR_EULER_0_1 = 5591,
            PARAMETER_MB_ADDR_EULER_0_2 = 5592,
            PARAMETER_MB_ADDR_EULER_0_3 = 5593,
            PARAMETER_MB_ADDR_EULER_1_0 = 5594,
            PARAMETER_MB_ADDR_EULER_1_1 = 5595,
            PARAMETER_MB_ADDR_EULER_1_2 = 5596,
            PARAMETER_MB_ADDR_EULER_1_3 = 5597,
            PARAMETER_MB_ADDR_EULER_2_0 = 5598,
            PARAMETER_MB_ADDR_EULER_2_1 = 5599,
            PARAMETER_MB_ADDR_EULER_2_2 = 5600,
            PARAMETER_MB_ADDR_EULER_2_3 = 5601,
            PARAMETER_MB_ADDR_OUTPUT_COUNTER_0 = 5602,
            PARAMETER_MB_ADDR_OUTPUT_COUNTER_1 = 5603,
            PARAMETER_MB_ADDR_OUTPUT_BOOT_TIME_MS = 5604,
            PARAMETER_MB_ADDR_CHIP_STABILIZATION_CYCLE_QTY = 5605,
            PARAMETER_MB_ADDR_OUTPUT_STABILIZATION_CYCLE_QTY = 5606
        }
    }
}

