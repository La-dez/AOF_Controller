using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FT_HANDLE = System.UInt32;
//using aom; 

namespace LDZ_Code
{
    class AO
    {
        abstract public class Filter
        {
            public abstract string FilterDescriptor_or_name { set; get; }
            public abstract string FilterCfgName { set; get; }
            public abstract string FilterCfgPath { set; get; }
            public abstract string DllName { set; get; }

            public abstract float[] HZs { set; get; }
            public abstract float[] WLs { set; get; }
            public abstract float[] Intensity { set; get; }
            public abstract bool AOF_Loaded_without_fails { set; get; }

            public abstract float WL_Max { set; get; }
            public abstract float WL_Min { set; get; }

            public abstract int Set_Wl(int pWL);
            public abstract int Set_Hz(float freq);
            public abstract int Set_Sweep_on(float MHz_start, float Sweep_range_MHz, double Period/*[мс с точностью до двух знаков]*/, bool OnRepeat);
            public abstract int Set_Sweep_off();
            public abstract int Set_OutputPower(byte percentage);
            public abstract int Init_device(uint number);
            public abstract int Deinit_device();
            public abstract string Ask_required_dev_file();
            public abstract int Read_dev_file(string path);
            public abstract int PowerOn();
            public abstract int PowerOff();

        }
        public class Emulator : Filter
        {
            public override string FilterDescriptor_or_name { set; get; }
            public override string FilterCfgName { set; get; }
            public override string FilterCfgPath { set; get; }
            public override string DllName { set; get; }

            public override float[] HZs { set; get; }
            public override float[] WLs { set; get; }
            public override float[] Intensity { set; get; }
            public override bool AOF_Loaded_without_fails { set; get; }

            public override float WL_Max { set; get; }
            public override float WL_Min { set; get; }

            public Emulator()
            {

            }
            public override int Set_Wl(int pWL)
            {
                return 0;
            }
            public override int Set_Hz(float freq)
            {
                return 0;
            }
            public override int Set_Sweep_on(float MHz_start, float Sweep_range_MHz, double Period/*[мс с точностью до двух знаков]*/, bool OnRepeat)
            {
                return 0;
            }
            public override int Set_Sweep_off()
            {
                return 0;
            }
            public override int Init_device(uint number)
            {
                return 0;
            }

            public override int Deinit_device()
            {
                return 0;
            }
            public override string Ask_required_dev_file()
            {
                return "(any *.dev file)";
            }
            public override int Set_OutputPower(byte percentage)
            {
                return 0;
            }
            public override int Read_dev_file(string path)
            {
                return 0;
            }

            public override int PowerOn()
            {
                return 0;
            }
            public override int PowerOff()
            {
                return 0;
            }
            public static int Search_Devices()
            {
                return 0;
            }
        }
        public class VNIIFTRI_Filter_v15 : Filter
        {
            public override string FilterDescriptor_or_name { set; get; }
            public override string FilterCfgName { set; get; }
            public override string FilterCfgPath { set; get; }
            public override string DllName { set; get; }

            public override float[] HZs { set; get; }
            public override float[] WLs { set; get; }
            public override float[] Intensity { set; get; }
            public override bool AOF_Loaded_without_fails { set; get; }

            public override float WL_Max { set; get; }
            public override float WL_Min { set; get; }

            public VNIIFTRI_Filter_v15()
            {

            }
            public override int Set_Wl(int pWL)
            {
                return AOM_SetWL(pWL);
            }
            public override int Set_Hz(float freq)
            {
                return 0;
            }
            public override int Set_Sweep_on(float MHz_start, float Sweep_range_MHz, double Period/*[мс с точностью до двух знаков]*/, bool OnRepeat)
            {
                return -1;
            }
            public override int Set_Sweep_off()
            {
                return -1;
            }
            public override int Init_device(uint number)
            {
                AOM_Init((int)number);
                return 0;
            }
            public override int Deinit_device()
            {
                return AOM_Close();
            }
            public override string Ask_required_dev_file()
            {
                StringBuilder dev_name = new StringBuilder(7);
                AOM_GetID(dev_name);
                return dev_name.ToString();
            }
            public override int Set_OutputPower(byte percentage)
            {
                return -1;
            }
            public override int Read_dev_file(string path)
            {
                float min=0, max=0;
                try
                {
                    var Data_from_dev = ServiceFunctions.Files.Read_txt(path);
                    float[] pWLs, pHZs, pCoefs;
                    ServiceFunctions.Files.Get_WLData_byKnownCountofNumbers(3, Data_from_dev.ToArray(), out pWLs, out pHZs, out pCoefs);
                    ServiceFunctions.Math.Interpolate_curv(pWLs, pHZs);
                    ServiceFunctions.Math.Interpolate_curv(pWLs, pCoefs);
                    WLs = pWLs;
                    HZs = pHZs;
                    Intensity = pCoefs;
                    WL_Min = WLs[0];
                    WL_Max = WLs[WLs.Length - 1];
                    AOM_LoadSettings(path,ref min, ref max);
                    if ((min != WL_Min) || (max != WL_Max)) throw new Exception();
                }
                catch
                {
                    return -1;
                }
                return 0;
            }

            public override int PowerOn()
            {
                return AOM_PowerOn();
            }
            public override int PowerOff()
            {
                return AOM_PowerOff();
            }
            public static int Search_Devices()
            {
                return AOM_GetNumDevices();
            }


            #region DllFunctions
            public const string basepath = "aom_old.dll";
            //Назначение: функция возвращает число подключенных акустооптических фильтров.
            [DllImport(basepath, CallingConvention = CallingConvention.Cdecl)]
            public static extern int AOM_GetNumDevices();

            //Назначение: функция производит инициализацию подключенного акустооптического фильтра 
            //(обычное значение devicenum = 0, т.е. первое).
            [DllImport(basepath, CallingConvention = CallingConvention.Cdecl)]
            public static extern int AOM_Init(int devicenum);

            //Назначение: функция выполняет деинициализацию акустооптического фильтра.
            [DllImport(basepath, CallingConvention = CallingConvention.Cdecl)]
            public static extern int AOM_Close();

            //Назначение: функция записывает в переменную id значение идентификатор подключенного акустооптического фильтра.
            [DllImport(basepath, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern int AOM_GetID([MarshalAs(UnmanagedType.LPStr)] StringBuilder id);

            //Назначение: функция производит загрузку значений максимальной
            //(wlmax) и минимальной длины волны (wlmin) из файла с именем filename с расширением *.dev.
            [DllImport(basepath,
                CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
            public static extern int AOM_LoadSettings(string filename, ref float wlmin, ref float wlmax);

            //Назначение: функция выполняет выгрузку установленных значений из калибровочного файла формата *.dev.
            [DllImport(basepath, CallingConvention = CallingConvention.Cdecl)]
            public static extern int AOM_UnloadSettings();

            //Назначение: функция производит установку требуемой частоты акустооптического фильтра
            [DllImport(basepath, CallingConvention = CallingConvention.Cdecl)]
            public static extern int AOM_SetWL(float wl);

            //Назначение: функция производит включение акустооптического фильтра.
            [DllImport(basepath, CallingConvention = CallingConvention.Cdecl)]
            public static extern int AOM_PowerOn();

            //Назначение: функция производит выключение акустооптического фильтра.
            [DllImport(basepath, CallingConvention = CallingConvention.Cdecl)]
            public static extern int AOM_PowerOff();

            public static string AOM_IntErr(int i)
            {
                string answer = null;
                switch (i)
                {
                    case 0:
                        answer = "AOM_OK";
                        break;
                    case 1:
                        answer = "AOM_ALREADY_INITIALIZED";
                        break;
                    case 2:
                        answer = "AOM_ALREADY_LOADED";
                        break;
                    case 3:
                        answer = "AOM_NOT_INITIALIZED";
                        break;
                    case 4:
                        answer = "AOM_DEVICE_NOTFOUND";
                        break;
                    case 5:
                        answer = "AOM_BAD_RESPONSE";
                        break;
                    case 6:
                        answer = "AOM_NULL_POINTER";
                        break;
                    case 7:
                        answer = "AOM_FILE_NOTFOUND";
                        break;
                    case 8:
                        answer = "AOM_FILE_READ_ERROR";
                        break;
                    case 9:
                        answer = "AOM_WINUSB_INIT_FAIL";
                        break;
                    case 10:
                        answer = "AOM_NOT_LOADED";
                        break;
                    case 11:
                        answer = "AOM_RANGE_ERROR";
                        break;
                }

                return answer;
            }
            #endregion
        }
        public class STC_Filter : Filter
        {
            public override string FilterDescriptor_or_name { set; get; }
            public override string FilterCfgName { set; get; }
            public override string FilterCfgPath { set; get; }
            public override string DllName { set; get; }

            public override float[] HZs { set; get; }
            public override float[] WLs { set; get; }
            public override float[] Intensity { set; get; }
            public override bool AOF_Loaded_without_fails { set; get; }

            public override float WL_Max { set; get; }
            public override float WL_Min { set; get; }

            private byte[] Own_UsbBuf = new byte[5000];
            private UInt32 Own_dwListDescFlags = 0;
            private UInt32 Own_m_hPort = 0;
            
            public STC_Filter(string Descriptor,uint number,FT_HANDLE ListFlag)
            {
                Own_dwListDescFlags = ListFlag;
                FilterDescriptor_or_name = Descriptor;
                Init_device(number);
            }
            public override int Set_Wl(int wl)
            {
                if (AOF_Loaded_without_fails)
                {
                    try
                    {
                        float fvspom; short MSB, LSB; ulong lvspom;
                        float freq_ret = 0;
                        uint ivspom;
                        //DWORD ret_bytes;
                        int i = 0; float freq = 0;
                        List<System.Drawing.PointF> PtsFinal = ServiceFunctions.Math.Interpolate_curv(WLs, HZs);

                        int max_count = PtsFinal.Count;
                        for (i = 0; i < max_count; i++)//Search freq by WL
                        {
                            if (PtsFinal[i].X == wl)
                            {
                                freq_ret = freq = PtsFinal[i].Y;
                            }
                        }
                        freq = (3.2f + freq); //little mistake in calculations
                        ivspom = 2800;
                        if (freq >= 125) { ivspom = 2800; }
                        if (freq < 125 && freq >= 120) { ivspom = 2800; }
                        if (freq < 120 && freq >= 100) { ivspom = 2800; }
                        if (freq < 100 && freq >= 90) { ivspom = 2900; }
                        if (freq < 90 && freq >= 85) { ivspom = 2900; }
                        if (freq < 85 && freq >= 80) { ivspom = 3100; }
                        if (freq < 80 && freq >= 75) { ivspom = 3150; }
                        if (freq < 75 && freq >= 60) { ivspom = 3200; }
                        if (freq < 60 && freq >= 40) { ivspom = 3300; }

                        freq = (float)freq * (float)1e6;
                        fvspom = (float)freq / (float)400e6;
                        lvspom = (ulong)(fvspom * 0xffffffff);
                        MSB = (short)(0x0000ffFF & (lvspom >> 16));
                        LSB = (short)lvspom;

                        Own_UsbBuf[0] = 0x03; //it means, we will send wavelength
                        Own_UsbBuf[1] = (byte)(0x00ff & (MSB >> 8));
                        Own_UsbBuf[2] = (byte)MSB;
                        Own_UsbBuf[3] = (byte)(0x00ff & (LSB >> 8));
                        Own_UsbBuf[4] = (byte)LSB;
                        Own_UsbBuf[5] = (byte)(0x00ff & (ivspom >> 8)); Own_UsbBuf[6] = (byte)ivspom;
                        int b2w = 7;
                        for(i = 0; i< b2w; i++)
                        {
                            Own_UsbBuf[i] = (byte)AO.FTDIController.Bit_reverse(Own_UsbBuf[i]);
                        }                          
                        WriteUsb(7);
                        return 0;
                    }
                    catch
                    {
                        return (int)FTDIController.FT_STATUS.FT_OTHER_ERROR;
                    }
                }
                else
                {
                    return (int)FTDIController.FT_STATUS.FT_DEVICE_NOT_FOUND;
                }
            }
            public override int Set_Hz(float freq)
            {
                if (AOF_Loaded_without_fails)
                {
                    try
                    {
                        float fvspom; short MSB, LSB; ulong lvspom;
                        uint ivspom;
                        //DWORD ret_bytes;
                        float freqwas = freq;
                        freq = (3.2f + freq); //little mistake in calculations
                        ivspom = 2800;
                        if (freq >= 125) { ivspom = 2800; }
                        if (freq < 125 && freq >= 120) { ivspom = 2800; }
                        if (freq < 120 && freq >= 100) { ivspom = 2800; }
                        if (freq < 100 && freq >= 90) { ivspom = 2900; }
                        if (freq < 90 && freq >= 85) { ivspom = 2900; }
                        if (freq < 85 && freq >= 80) { ivspom = 3100; }
                        if (freq < 80 && freq >= 75) { ivspom = 3150; }
                        if (freq < 75 && freq >= 60) { ivspom = 3200; }
                        if (freq < 60 && freq >= 40) { ivspom = 3300; }

                        freq = (float)freq * (float)1e6;
                        fvspom = (float)freq / (float)400e6;
                        lvspom = (ulong)(fvspom * 0xffffffff);
                        MSB = (short)(0x0000ffFF & (lvspom >> 16));
                        LSB = (short)lvspom;

                        Own_UsbBuf[0] = 0x03; //it means, we will send wavelength

                        Own_UsbBuf[1] = (byte)(0x00ff & (MSB >> 8));
                        Own_UsbBuf[2] = (byte)MSB;
                        Own_UsbBuf[3] = (byte)(0x00ff & (LSB >> 8));
                        Own_UsbBuf[4] = (byte)LSB;

                        Own_UsbBuf[5] = (byte)(0x00ff & (ivspom >> 8));
                        Own_UsbBuf[6] = (byte)ivspom;

                        int b2w = 7;
                        for (int i = 0; i < b2w; i++)
                        {
                            Own_UsbBuf[i] = (byte)AO.FTDIController.Bit_reverse(Own_UsbBuf[i]);
                        }
                        WriteUsb(7);
                 
                        return 0;
                    }
                    catch
                    {
                        return (int)FTDIController.FT_STATUS.FT_OTHER_ERROR;
                    }
                }
                else
                {
                    return (int)FTDIController.FT_STATUS.FT_DEVICE_NOT_FOUND;
                }
            }
            public override int Set_Sweep_on(float MHz_start, float Sweep_range_MHz, double Period/*[мс с точностью до двух знаков]*/, bool OnRepeat)
            {
                //здесь MHz_start = m_f0 - начальна частота в МГц    
                //Sweep_range_MHz = m_deltaf - девиация частоты в МГц
                try
                {

                    float freq, fvspom;
                    short MSB, LSB;
                    ulong lvspom;
                    Own_UsbBuf = new byte[5000];
                    uint ivspom;
                    float delta;
                    int steps;
                    int count;
                    int i;
                    float freqMCU = 74.99e6f;


                    float inp_freq = (float)(50000/*Period * 10*/); //  было 50000 = 5000*10 // предел для этого значения - 47.67~50, т.е. 5мс

                    freq = (3.2f + MHz_start);
                    count = 5;
                    steps = (int)Math.Floor(Sweep_range_MHz); // number of the steps
                    Own_UsbBuf[0] = 0x08; //it means, we will send sweep
                    for (i = 1; i < 5000; i++)
                    {
                        Own_UsbBuf[i] = 0;
                    }
                    for (i = 0; i <= steps; i++)
                    {
                        ivspom = 3000;
                        freq = (3.2f + MHz_start) * 1e6f + i * 1e5f;
                        if (freq >= 125e6) { ivspom = 2800; }
                        else if (freq < 125e6 && freq >= 120e6) { ivspom = 2800; }
                        else if (freq < 120e6 && freq >= 100e6) { ivspom = 2800; }
                        else if (freq < 100e6 && freq >= 90e6) { ivspom = 2900; }
                        else if (freq < 90e6 && freq >= 85e6) { ivspom = 2900; }
                        else if (freq < 85e6 && freq >= 80e6) { ivspom = 3100; }
                        else if (freq < 80e6 && freq >= 75e6) { ivspom = 3150; }
                        else if (freq < 75e6 && freq >= 60e6) { ivspom = 3200; }
                        else if (freq < 60e6 && freq >= 40e6) { ivspom = 3300; }


                        fvspom = freq / 400e6f;
                        lvspom = (ulong)(fvspom * Math.Pow(2.0, 32.0));
                        MSB = (short)(0x0000ffFF & (lvspom >> 16));
                        LSB = (short)lvspom;
                        Own_UsbBuf[count + 1] = (byte)(0x00ff & (MSB >> 8));
                        Own_UsbBuf[count + 2] = (byte)(MSB);
                        Own_UsbBuf[count + 3] = (byte)(0x00ff & (LSB >> 8));
                        Own_UsbBuf[count + 4] = (byte)(LSB);
                        Own_UsbBuf[count + 5] = (byte)(0x00ff & (ivspom >> 8));
                        Own_UsbBuf[count + 6] = (byte)(ivspom);
                        count += 6;
                    }
                    count -= 6; //компенсация последнего смещения
                    Own_UsbBuf[0] = 0x08;
                    Own_UsbBuf[1] = (byte)(0x00ff & (count >> 8));
                    Own_UsbBuf[2] = (byte)count;
                    //timer calculations
                    ivspom = (uint)(Math.Pow(2, 16) - (freqMCU / (2 * 12 * inp_freq)));
                    Own_UsbBuf[3] = (byte)(0x00ff & (ivspom >> 8));
                    Own_UsbBuf[4] = (byte)ivspom;
                    //
                    Own_UsbBuf[5] = (byte)Convert.ToInt16(OnRepeat); //default repeate
                    for (i = 0; i < count; i++)
                    {
                        Own_UsbBuf[i] = (byte)AO.FTDIController.Bit_reverse(Own_UsbBuf[i]);
                    }
                    //  AOF.FT_Purge(AOF.m_hPort, AOF.FT_PURGE_RX | AOF.FT_PURGE_TX); // Purge(FT_PURGE_RX || FT_PURGE_TX);
                    // AOF.FT_ResetDevice(AOF.m_hPort); //ResetDevice();
                    try
                    {
                        WriteUsb(count);
                    }
                    catch { return (int)FTDIController.FT_STATUS.FT_IO_ERROR; }
                    return 0;
                }
                catch { return (int)FTDIController.FT_STATUS.FT_OTHER_ERROR; }
            }
            public int Set_Sweep_on2(float MHz_start, float Sweep_range_MHz, double Period/*[мс с точностью до двух знаков]*/, bool OnRepeat)
            {
                //здесь MHz_start = m_f0 - начальна частота в МГц    
                //Sweep_range_MHz = m_deltaf - девиация частоты в МГц
                try
                {
                    
                    float freq, fvspom;
                    short MSB, LSB;
                    ulong lvspom;
                    Own_UsbBuf = new byte[5000];
                    uint ivspom;
                    float delta;
                    int steps;
                    int count;
                    int i;
                    float freqMCU = 74.99e6f;
                    float inp_freq = 5000; //in Hz, max 5000Hz

                    freq = (3.2f + MHz_start);
                    count = 5;
                    steps = (int)Math.Floor(Sweep_range_MHz * 5); // number of the steps
                    Own_UsbBuf[0] = 0x08; //it means, we will send sweep

                    for (i = 1; i < 5000; i++)
                    {
                        Own_UsbBuf[i] = 0;
                    }
                    for (i = 0; i <= steps; i++)//перепроверить цикл
                    {
                        ivspom = 3400;
                        freq = ((m_f0) * 1e6 + i * 2e5);
                        if (freq >= 125e6) { ivspom = 3100; }
                        if (freq < 125e6 && freq >= 120e6) { ivspom = 3000; }
                        if (freq < 120e6 && freq >= 110e6) { ivspom = 3100; }
                        if (freq < 110e6 && freq >= 100e6) { ivspom = 3150; }
                        if (freq < 100e6 && freq >= 90e6) { ivspom = 3200; }
                        if (freq < 90e6 && freq >= 85e6) { ivspom = 3150; }
                        if (freq < 85e6 && freq >= 80e6) { ivspom = 3200; }
                        if (freq < 80e6 && freq >= 75e6) { ivspom = 3250; }
                        if (freq < 75e6 && freq >= 65e6) { ivspom = 3250; }
                        if (freq < 65e6 && freq >= 50e6) { ivspom = 3400; }
                        if (freq < 50e6 && freq >= 30e6) { ivspom = 3450; }

                        freq = ((MHz_start) * 1e6f + i * 2e5) / 1.17;//1.17 коррекция частоты
                                                               //fvspom=freq/300e6;
                        lvspom = (freq) * (pow(2.0, 32.0) / 300e6); //расчет управляющего слова для частоты
                        MSB = (short)(0x0000ffFF & (lvspom >> 16));
                        LSB = (short)lvspom;
                        Own_UsbBuf[count + 1] = (byte)(0x00ff & (MSB >> 8));
                        Own_UsbBuf[count + 2] = (byte)(MSB);
                        Own_UsbBuf[count + 3] = (byte)(0x00ff & (LSB >> 8));
                        Own_UsbBuf[count + 4] = (byte)(LSB);
                        Own_UsbBuf[count + 5] = (byte)(0x00ff & (ivspom >> 8));
                        Own_UsbBuf[count + 6] = (byte)(ivspom);
                        count += 6;
                    }
                    for (i = 0; i <= steps; i++)
                    {
                        ivspom = 3000;
                        freq = (3.2f + MHz_start) * 1e6f + i * 1e5f;
                        if (freq >= 125e6) { ivspom = 2800; }
                        else if (freq < 125e6 && freq >= 120e6) { ivspom = 2800; }
                        else if (freq < 120e6 && freq >= 100e6) { ivspom = 2800; }
                        else if (freq < 100e6 && freq >= 90e6) { ivspom = 2900; }
                        else if (freq < 90e6 && freq >= 85e6) { ivspom = 2900; }
                        else if (freq < 85e6 && freq >= 80e6) { ivspom = 3100; }
                        else if (freq < 80e6 && freq >= 75e6) { ivspom = 3150; }
                        else if (freq < 75e6 && freq >= 60e6) { ivspom = 3200; }
                        else if (freq < 60e6 && freq >= 40e6) { ivspom = 3300; }


                        fvspom = freq / 400e6f;
                        lvspom = (ulong)(fvspom * Math.Pow(2.0, 32.0));
                        MSB = (short)(0x0000ffFF & (lvspom >> 16));
                        LSB = (short)lvspom;
                        Own_UsbBuf[count + 1] = (byte)(0x00ff & (MSB >> 8));
                        Own_UsbBuf[count + 2] = (byte)(MSB);
                        Own_UsbBuf[count + 3] = (byte)(0x00ff & (LSB >> 8));
                        Own_UsbBuf[count + 4] = (byte)(LSB);
                        Own_UsbBuf[count + 5] = (byte)(0x00ff & (ivspom >> 8));
                        Own_UsbBuf[count + 6] = (byte)(ivspom);
                        count += 6;
                    }
                    count -= 6; //компенсация последнего смещения
                    Own_UsbBuf[0] = 0x08;
                    Own_UsbBuf[1] = (byte)(0x00ff & (count >> 8));
                    Own_UsbBuf[2] = (byte)count;
                    //timer calculations
                    ivspom = (uint)(Math.Pow(2, 16) - (freqMCU / (2 * 12 * inp_freq)));
                    Own_UsbBuf[3] = (byte)(0x00ff & (ivspom >> 8));
                    Own_UsbBuf[4] = (byte)ivspom;
                    //
                    Own_UsbBuf[5] = (byte)Convert.ToInt16(OnRepeat); //default repeate
                    for (i = 0; i < count; i++)
                    {
                        Own_UsbBuf[i] = (byte)AO.FTDIController.Bit_reverse(Own_UsbBuf[i]);
                    }
                    //  AOF.FT_Purge(AOF.m_hPort, AOF.FT_PURGE_RX | AOF.FT_PURGE_TX); // Purge(FT_PURGE_RX || FT_PURGE_TX);
                    // AOF.FT_ResetDevice(AOF.m_hPort); //ResetDevice();
                    try
                    {
                        WriteUsb(count);
                    }
                    catch { return (int)FTDIController.FT_STATUS.FT_IO_ERROR; }
                    return 0;
                }
                catch { return (int)FTDIController.FT_STATUS.FT_OTHER_ERROR; }
            }
            public override int Set_Sweep_off()
            {
                try
                {
                    Own_UsbBuf = new byte[2];
                    //DWORD ret_bytes;
                    Own_UsbBuf[0] = 0x0a;
                    Own_UsbBuf[0] = (byte)AO.FTDIController.Bit_reverse(Own_UsbBuf[0]);

                    try { WriteUsb(1); }
                    catch { return (int)FTDIController.FT_STATUS.FT_IO_ERROR; }
                }
                catch { return (int)FTDIController.FT_STATUS.FT_OTHER_ERROR; }
                return 0;

            }
            public override int Set_OutputPower(byte Percentage)
            {
                try
                {
                    Own_UsbBuf[0] = 0x09; //it means, we will send off command
                    Own_UsbBuf[1] = Percentage;
                    try { WriteUsb(2); }
                    catch { return (int)FTDIController.FT_STATUS.FT_IO_ERROR; }
                }
                catch { return (int)FTDIController.FT_STATUS.FT_OTHER_ERROR; }
                return 0;
            }
            public override int Init_device(uint number)
            {
                LDZ_Code.AO.FTDIController.FT_STATUS ftStatus = LDZ_Code.AO.FTDIController.FT_STATUS.FT_OTHER_ERROR;
                UInt32 dwOpenFlag;

                if (Own_m_hPort == 0)
                {
                    dwOpenFlag = Own_dwListDescFlags & ~LDZ_Code.AO.FTDIController.FT_LIST_BY_INDEX;
                    dwOpenFlag = Own_dwListDescFlags & ~LDZ_Code.AO.FTDIController.FT_LIST_ALL;
                    dwOpenFlag = 0;
                    if (dwOpenFlag == 0)
                    {
                        //uiCurrentIndex = (uint)cmbDevList.SelectedIndex;
                        ftStatus = LDZ_Code.AO.FTDIController.FT_Open((uint)number, ref Own_m_hPort);
                    }
                    else
                    {
                        System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
                        byte[] sDevName = enc.GetBytes(FilterDescriptor_or_name);
                    }
                }

                if (ftStatus == LDZ_Code.AO.FTDIController.FT_STATUS.FT_OK)
                {
                    // Set up the port
                    FTDIController.FT_SetBaudRate(Own_m_hPort, 9600);
                    FTDIController.FT_Purge(Own_m_hPort, FTDIController.FT_PURGE_RX | FTDIController.FT_PURGE_TX);
                    FTDIController.FT_SetTimeouts(Own_m_hPort, 3000, 3000);
                }
                else
                {
                    return (int)ftStatus;
                }
                Own_UsbBuf[0] = 0x66;
                try { WriteUsb(1); }
                catch { return (int)FTDIController.FT_STATUS.FT_IO_ERROR; }
                return 0;
            }
            public override int Deinit_device()
            {
                System.Threading.Thread.Sleep(100);
                int result = Convert.ToInt16(LDZ_Code.AO.FTDIController.FT_Close(Own_m_hPort));
                return result;
            }
            public override string Ask_required_dev_file()
            {
                return ("(special *.dev file)");
            }
            public static unsafe int Search_Devices(out string data_FilterDescriptor_or_name, out uint data_dwListDescFlags)
            {
                FTDIController.FT_STATUS ftStatus = FTDIController.FT_STATUS.FT_OTHER_ERROR;
                UInt32 numDevs;
                int countofdevs_to_return = 0;
                int i;
                byte[] sDevName = new byte[64];
                void* p1;             

                p1 = (void*)&numDevs;
                ftStatus = FTDIController.FT_ListDevices(p1, null, FTDIController.FT_LIST_NUMBER_ONLY);
                countofdevs_to_return = (int)numDevs;
                data_dwListDescFlags = FTDIController.FT_LIST_BY_INDEX | FTDIController.FT_OPEN_BY_DESCRIPTION;
                string datastring = "";
                if (ftStatus == FTDIController.FT_STATUS.FT_OK)
                {
                    if (data_dwListDescFlags == FTDIController.FT_LIST_ALL)
                    {
                        for (i = 0; i < numDevs; i++)
                        {
                            //cmbDevList.Items.Add(i);
                        }
                    }
                    else
                    {

                        for (i = 0; i < numDevs; i++) // пройдемся по девайсам и спросим у них дескрипторы
                        {
                            fixed (byte* pBuf = sDevName)
                            {
                                ftStatus = FTDIController.FT_ListDevices((UInt32)i, pBuf, data_dwListDescFlags);
                                if (ftStatus == FTDIController.FT_STATUS.FT_OK)
                                {
                                    //string str;
                                    System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
                                    datastring = enc.GetString(sDevName, 0, sDevName.Length);
                                    //cmbDevList.Items.Add(str);
                                }
                                else
                                {
                                    data_FilterDescriptor_or_name = null;
                                    return (int)ftStatus;
                                }
                            }
                        }
                    }
                }
                data_FilterDescriptor_or_name = datastring;
                return countofdevs_to_return;
            }
            public override int PowerOn()
            {
                return 0;
            }
            public override int PowerOff()
            {
                try
                {
                    Own_UsbBuf[0] = 0x05; //it means, we will send off command
                    for (int i = 1; i < 2; i++) Own_UsbBuf[i] = 0;
                    Own_UsbBuf[0] = (byte)FTDIController.Bit_reverse(Own_UsbBuf[0]);
                    try { WriteUsb(1); }
                    catch { return (int)FTDIController.FT_STATUS.FT_IO_ERROR; }
                }
                catch { return (int)FTDIController.FT_STATUS.FT_OTHER_ERROR; }

                return 0;
            }
            public override int Read_dev_file(string path)
            {
                try
                {
                    var Data_from_dev = ServiceFunctions.Files.Read_txt(path);
                    float[] pWLs, pHZs, pCoefs;
                    ServiceFunctions.Files.Get_WLData_byKnownCountofNumbers(3, Data_from_dev.ToArray(), out pWLs, out pHZs, out pCoefs);
                    ServiceFunctions.Math.Interpolate_curv(pWLs, pHZs);
                    ServiceFunctions.Math.Interpolate_curv(pWLs, pCoefs);
                    WLs = pWLs;
                    HZs = pHZs;
                    Intensity = pCoefs;
                    WL_Min = WLs[0];
                    WL_Max = WLs[WLs.Length - 1];
                }
                catch
                {
                    return (int)FTDIController.FT_STATUS.FT_OTHER_ERROR;
                }
                return 0;
            }
            #region Перегрузки WriteUsb
            //Перегрузки, которую можно юзать
            public unsafe bool WriteUsb()
            {
                int count_in = Own_UsbBuf.Length;
                return AO.FTDIController.WriteUsb(Own_m_hPort,count_in, Own_UsbBuf);
            }

            //Перегрузка, которую юзаем везде
            public unsafe bool WriteUsb(int count)
            { return AO.FTDIController.WriteUsb(Own_m_hPort, count, Own_UsbBuf); }
            #endregion
        }
        private static class FTDIController
        {
            const string ftdi_dllname = "FTD2XX.dll";

            public enum FT_STATUS//:Uint32
            {
                FT_OK = 0,
                FT_INVALID_HANDLE,
                FT_DEVICE_NOT_FOUND,
                FT_DEVICE_NOT_OPENED,
                FT_IO_ERROR,
                FT_INSUFFICIENT_RESOURCES,
                FT_INVALID_PARAMETER,
                FT_INVALID_BAUD_RATE,
                FT_DEVICE_NOT_OPENED_FOR_ERASE,
                FT_DEVICE_NOT_OPENED_FOR_WRITE,
                FT_FAILED_TO_WRITE_DEVICE,
                FT_EEPROM_READ_FAILED,
                FT_EEPROM_WRITE_FAILED,
                FT_EEPROM_ERASE_FAILED,
                FT_EEPROM_NOT_PRESENT,
                FT_EEPROM_NOT_PROGRAMMED,
                FT_INVALID_ARGS,
                FT_OTHER_ERROR
            };

            public const UInt32 FT_BAUD_300 = 300;
            public const UInt32 FT_BAUD_600 = 600;
            public const UInt32 FT_BAUD_1200 = 1200;
            public const UInt32 FT_BAUD_2400 = 2400;
            public const UInt32 FT_BAUD_4800 = 4800;
            public const UInt32 FT_BAUD_9600 = 9600;
            public const UInt32 FT_BAUD_14400 = 14400;
            public const UInt32 FT_BAUD_19200 = 19200;
            public const UInt32 FT_BAUD_38400 = 38400;
            public const UInt32 FT_BAUD_57600 = 57600;
            public const UInt32 FT_BAUD_115200 = 115200;
            public const UInt32 FT_BAUD_230400 = 230400;
            public const UInt32 FT_BAUD_460800 = 460800;
            public const UInt32 FT_BAUD_921600 = 921600;

            public const UInt32 FT_LIST_NUMBER_ONLY = 0x80000000;
            public const UInt32 FT_LIST_BY_INDEX = 0x40000000;
            public const UInt32 FT_LIST_ALL = 0x20000000;
            public const UInt32 FT_OPEN_BY_SERIAL_NUMBER = 1;
            public const UInt32 FT_OPEN_BY_DESCRIPTION = 2;

            // Word Lengths
            public const byte FT_BITS_8 = 8;
            public const byte FT_BITS_7 = 7;
            public const byte FT_BITS_6 = 6;
            public const byte FT_BITS_5 = 5;

            // Stop Bits
            public const byte FT_STOP_BITS_1 = 0;
            public const byte FT_STOP_BITS_1_5 = 1;
            public const byte FT_STOP_BITS_2 = 2;

            // Parity
            public const byte FT_PARITY_NONE = 0;
            public const byte FT_PARITY_ODD = 1;
            public const byte FT_PARITY_EVEN = 2;
            public const byte FT_PARITY_MARK = 3;
            public const byte FT_PARITY_SPACE = 4;

            // Flow Control
            public const UInt16 FT_FLOW_NONE = 0;
            public const UInt16 FT_FLOW_RTS_CTS = 0x0100;
            public const UInt16 FT_FLOW_DTR_DSR = 0x0200;
            public const UInt16 FT_FLOW_XON_XOFF = 0x0400;

            // Purge rx and tx buffers
            public const byte FT_PURGE_RX = 1;
            public const byte FT_PURGE_TX = 2;

            // Events
            public const UInt32 FT_EVENT_RXCHAR = 1;
            public const UInt32 FT_EVENT_MODEM_STATUS = 2;

           
            //public static byte* pBuf;
            [DllImport(ftdi_dllname)]
            public static extern unsafe FT_STATUS FT_ListDevices(void* pvArg1, void* pvArg2, UInt32 dwFlags);  // FT_ListDevices by number only
            [DllImport(ftdi_dllname)]
            public static extern unsafe FT_STATUS FT_ListDevices(UInt32 pvArg1, void* pvArg2, UInt32 dwFlags); // FT_ListDevcies by serial number or description by index only
            [DllImport(ftdi_dllname)]
            public static extern FT_STATUS FT_Open(UInt32 uiPort, ref FT_HANDLE ftHandle);
            [DllImport(ftdi_dllname)]
            public static extern unsafe FT_STATUS FT_OpenEx(void* pvArg1, UInt32 dwFlags, ref FT_HANDLE ftHandle);
            [DllImport(ftdi_dllname)]
            public static extern FT_STATUS FT_Close(FT_HANDLE ftHandle);
            [DllImport(ftdi_dllname)]
            public static extern unsafe FT_STATUS FT_Read(FT_HANDLE ftHandle, void* lpBuffer, UInt32 dwBytesToRead, ref UInt32 lpdwBytesReturned);
            [DllImport(ftdi_dllname)]
            public static extern unsafe FT_STATUS FT_Write(FT_HANDLE ftHandle, void* lpBuffer, UInt32 dwBytesToRead, ref UInt32 lpdwBytesWritten);
            [DllImport(ftdi_dllname)]
            public static extern unsafe FT_STATUS FT_SetBaudRate(FT_HANDLE ftHandle, UInt32 dwBaudRate);
            [DllImport(ftdi_dllname)]
            static extern unsafe FT_STATUS FT_SetDataCharacteristics(FT_HANDLE ftHandle, byte uWordLength, byte uStopBits, byte uParity);
            [DllImport(ftdi_dllname)]
            static extern unsafe FT_STATUS FT_SetFlowControl(FT_HANDLE ftHandle, char usFlowControl, byte uXon, byte uXoff);
            [DllImport(ftdi_dllname)]
            static extern unsafe FT_STATUS FT_SetDtr(FT_HANDLE ftHandle);
            [DllImport(ftdi_dllname)]
            static extern unsafe FT_STATUS FT_ClrDtr(FT_HANDLE ftHandle);
            [DllImport(ftdi_dllname)]
            static extern unsafe FT_STATUS FT_SetRts(FT_HANDLE ftHandle);
            [DllImport(ftdi_dllname)]
            static extern unsafe FT_STATUS FT_ClrRts(FT_HANDLE ftHandle);
            [DllImport(ftdi_dllname)]
            static extern unsafe FT_STATUS FT_GetModemStatus(FT_HANDLE ftHandle, ref UInt32 lpdwModemStatus);
            [DllImport(ftdi_dllname)]
            static extern unsafe FT_STATUS FT_SetChars(FT_HANDLE ftHandle, byte uEventCh, byte uEventChEn, byte uErrorCh, byte uErrorChEn);
            [DllImport(ftdi_dllname)]
            public static extern unsafe FT_STATUS FT_Purge(FT_HANDLE ftHandle, UInt32 dwMask);
            [DllImport(ftdi_dllname)]
            public static extern unsafe FT_STATUS FT_SetTimeouts(FT_HANDLE ftHandle, UInt32 dwReadTimeout, UInt32 dwWriteTimeout);
            [DllImport(ftdi_dllname)]
            static extern unsafe FT_STATUS FT_GetQueueStatus(FT_HANDLE ftHandle, ref UInt32 lpdwAmountInRxQueue);
            [DllImport(ftdi_dllname)]
            static extern unsafe FT_STATUS FT_SetBreakOn(FT_HANDLE ftHandle);
            [DllImport(ftdi_dllname)]
            static extern unsafe FT_STATUS FT_SetBreakOff(FT_HANDLE ftHandle);
            [DllImport(ftdi_dllname)]
            static extern unsafe FT_STATUS FT_GetStatus(FT_HANDLE ftHandle, ref UInt32 lpdwAmountInRxQueue, ref UInt32 lpdwAmountInTxQueue, ref UInt32 lpdwEventStatus);
            [DllImport(ftdi_dllname)]
            static extern unsafe FT_STATUS FT_SetEventNotification(FT_HANDLE ftHandle, UInt32 dwEventMask, void* pvArg);
            [DllImport(ftdi_dllname)]
            static extern unsafe FT_STATUS FT_ResetDevice(FT_HANDLE ftHandle);
            [DllImport(ftdi_dllname)]
            static extern unsafe FT_STATUS FT_SetDivisor(FT_HANDLE ftHandle, char usDivisor);
            [DllImport(ftdi_dllname)]
            static extern unsafe FT_STATUS FT_GetLatencyTimer(FT_HANDLE ftHandle, ref byte pucTimer);
            [DllImport(ftdi_dllname)]
            static extern unsafe FT_STATUS FT_SetLatencyTimer(FT_HANDLE ftHandle, byte ucTimer);
            [DllImport(ftdi_dllname)]
            static extern unsafe FT_STATUS FT_GetBitMode(FT_HANDLE ftHandle, ref byte pucMode);
            [DllImport(ftdi_dllname)]
            static extern unsafe FT_STATUS FT_SetBitMode(FT_HANDLE ftHandle, byte ucMask, byte ucEnable);
            [DllImport(ftdi_dllname)]
            static extern unsafe FT_STATUS FT_SetUSBParameters(FT_HANDLE ftHandle, UInt32 dwInTransferSize, UInt32 dwOutTransferSize);

            //Сама функция
            public static unsafe bool WriteUsb(uint pm_hPort, int count, byte[] pUsbBuf)
            {
                UInt32 dwRet = 0;
                FTDIController.FT_STATUS ftStatus = FTDIController.FT_STATUS.FT_OTHER_ERROR;
                byte[] cBuf = new Byte[count + 1];

                fixed (byte* pBuf = pUsbBuf)
                {
                    ftStatus = FTDIController.FT_Write(pm_hPort, pBuf, (uint)(count + 1), ref dwRet);
                }
                if (ftStatus != FTDIController.FT_STATUS.FT_OK)
                {
                    MessageBox.Show("Failed To Write " + Convert.ToString(ftStatus));
                }
                return false;
            }
            public static unsafe bool WriteUsb(uint pm_hPort, byte[] pUsbBuf)
            {
                int count_in = pUsbBuf.Length;
                return AO.FTDIController.WriteUsb(pm_hPort, count_in, pUsbBuf);
            }

            public static int Bit_reverse(int input)
            {
                int output = 0;
                const int uchar_size = 8;

                for (int i = 0; i != uchar_size; ++i)
                {
                    output |= ((input >> i) & 1) << (uchar_size - 1 - i);
                }
                return output;
            }


        }
        
        //Функция пытается обнаружить хоть какой-то фильтр, который подключен к системе
        public static Filter Find_and_connect_AnyFilter(bool IsEmulator = false)
        {
            if (IsEmulator) return (new Emulator());

            int NumberOfTypes = 2;
            int[] Devices_per_type = new int[NumberOfTypes];

            string Descriptor_forSTCFilter; uint Flag_forSTC_filter;
            Devices_per_type[0] = STC_Filter.Search_Devices(out Descriptor_forSTCFilter, out Flag_forSTC_filter);
            Devices_per_type[1] = VNIIFTRI_Filter_v15.Search_Devices();
            if (Devices_per_type[0] != 0) return (new STC_Filter(Descriptor_forSTCFilter, (uint)(Devices_per_type[0]-1), Flag_forSTC_filter));
            else if (Devices_per_type[1] != 0) return (new VNIIFTRI_Filter_v15());
            else return null;

        }
        public static List<float> Find_freq_mass_by_Wls(float[] Wls, float[] Hzs, List<float> Wls_needed)
        {
            if (Wls_needed.Count == 0) return new List<float>();
            List<System.Drawing.PointF> PtsFinal = ServiceFunctions.Math.Interpolate_curv(Wls, Hzs);
            List<float> result = new List<float>();
            int max_count = PtsFinal.Count;
            int max_k = Wls_needed.Count;
            int k = 0;
            for (int i = 0; (i != max_count) && (k != max_k); ++i)//Search freq by WL
            {
                if (PtsFinal[i].X == Wls_needed[k])
                {
                    result.Add(PtsFinal[i].Y);
                    ++k;
                }
            }
            return result;
        }
        //для каждого значения в ГЦ возвращает массив с точками формата (левая граница, расстояние до правой границы)
        public static List<System.Drawing.PointF> Find_freq_borders_mass(List<float> Hzs_needed, float HZs_radius, float HZs_min, float HZs_max)
        {
            List<System.Drawing.PointF> result = new List<System.Drawing.PointF>(); // for each point: X is LeftBorder, Y is Width
            int max_count = Hzs_needed.Count;
            float preMin = 0, preMax = 0;
            for (int i = 0; i < max_count; i++)//Search freq by WL
            {
                preMin = Hzs_needed[i] - HZs_radius;
                preMax = Hzs_needed[i] + HZs_radius;
                preMin = preMin < HZs_min ? HZs_min : preMin;
                preMax = preMax > HZs_max ? HZs_max : preMax;
                result.Add(new System.Drawing.PointF(preMin, preMax - preMin));
            }
            return result;
        }

        private static void Sweep(float MHz_start, float Sweep_range_MHz, double Period/*[мс с точностью до двух знаков]*/, bool OnRepeat)
        {
            float fvspom; short MSB, LSB; ulong lvspom;
            uint ivspom = (uint)(Sweep_range_MHz * 1000); // разность между правой и левой границей
            //set init freq
            float freq = (3.2f + MHz_start) * (float)1e6;   // m_pfreq is frequency
            double Period_mks = (Period * 1000);         //макс. 6500 мкс //Убрали это ограничение с Алексеем
            uint Period_10mks = (uint)(Period_mks / 10.0);    //макс. 650 десятков мкс

            fvspom = freq / (float)400e6;                    //лев.гр
            lvspom = (ulong)(fvspom * 0xffffffff);           //2*девиация
            MSB = (short)(0x0000ffFF & (lvspom >> 16));      //старший разряд частоты
            LSB = (short)lvspom;                             // младший разряд частоты


            byte[] tx = new byte[10];
            tx[0] = 0x08; //it means, we will send sweep

            tx[1] = (byte)(0x00ff & (MSB >> 8));
            tx[2] = (byte)(MSB);

            tx[3] = (byte)(0x00ff & (LSB >> 8));
            tx[4] = (byte)(LSB);

            tx[5] = /*255*/(byte)(0x00ff & (ivspom >> 8));
            tx[6] = /*255*/(byte)(ivspom);

            tx[7] = /*255*/(byte)(0x00ff & (Period_10mks >> 8));
            tx[8] = /*255*/(byte)(Period_10mks);

            tx[9] = (byte)Convert.ToInt16(OnRepeat); //repeat or not

            /* for (int i = 0; i < 10; i++)
             { AOF.UsbBuf[i] = (byte)AOF.reverse(AOF.UsbBuf[i]); }*/

            FTDIController.WriteUsb(0,10, tx);
        }
        private static void Sweep_Alternative_on_step100khz(float MHz_start, float Sweep_range_MHz, double Period/*[мс с точностью до двух знаков]*/, bool OnRepeat)
        {
            //здесь MHz_start = m_f0 - начальна частота в МГц    
            //Sweep_range_MHz = m_deltaf - девиация частоты в МГц


            float freq, fvspom;
            short MSB, LSB;
            ulong lvspom;
            byte[] tx = new byte[5000];
            uint ivspom;
            float delta;
            int steps;
            int count;
            int i;
            float freqMCU = 74.99e6f;

            
            float inp_freq = (float)(50000/*Period * 10*/); //  было 50000 = 5000*10 // предел для этого значения - 47.67~50, т.е. 5мс

            freq = (3.2f + MHz_start);
            count = 5;
            steps = (int)Math.Round(Sweep_range_MHz * 10); // number of the steps
            tx[0] = 0x08; //it means, we will send sweep
            for (i = 1; i < 5000; i++)
            {
                tx[i] = 0;
            }
            for (i = 0; i <= steps; i++)
            {
                ivspom = 2300;
                freq = (3.2f + MHz_start) * 1e6f + (i * 1e5f);
                if (freq >= 125e6) { ivspom = 1700; }
                else if (freq < 125e6 && freq >= 120e6) { ivspom = 2800; }
                else if (freq < 120e6 && freq >= 90e6) { ivspom = 2900; }
                else if (freq < 90e6 && freq >= 85e6) { ivspom = 2900; }
                else if (freq < 85e6 && freq >= 80e6) { ivspom = 3100; }
                else if (freq < 80e6 && freq >= 75e6) { ivspom = 3200; }
                else if (freq < 75e6 && freq >= 40e6) { ivspom = 3300; }


                fvspom = freq / 400e6f;
                lvspom = (ulong)(fvspom * Math.Pow(2.0, 32.0));
                MSB = (short)(0x0000ffFF & (lvspom >> 16));
                LSB = (short)lvspom;
                tx[count + 1] = (byte)(0x00ff & (MSB >> 8));
                tx[count + 2] = (byte)(MSB);
                tx[count + 3] = (byte)(0x00ff & (LSB >> 8));
                tx[count + 4] = (byte)(LSB);
                tx[count + 5] = (byte)(0x00ff & (ivspom >> 8));
                tx[count + 6] = (byte)(ivspom);
                count += 6;
            }
            count -= 6; //компенсация последнего смещения
            tx[0] = 0x08;
            tx[1] = (byte)(0x00ff & (count >> 8));
            tx[2] = (byte)count;
            //timer calculations
            ivspom = (uint)(Math.Pow(2,16) - (freqMCU / (2 * 12 * inp_freq)));
            tx[3] = (byte)(0x00ff & (ivspom >> 8));
            tx[4] = (byte)ivspom;
            //
            tx[5] = (byte)Convert.ToInt16(OnRepeat); //default repeate
            for (i = 0; i < 5000; i++)
            {
                tx[i] = (byte)AO.FTDIController.Bit_reverse(tx[i]);
            }
          //  AOF.FT_Purge(AOF.m_hPort, AOF.FT_PURGE_RX | AOF.FT_PURGE_TX); // Purge(FT_PURGE_RX || FT_PURGE_TX);
           // AOF.FT_ResetDevice(AOF.m_hPort); //ResetDevice();
            AO.FTDIController.WriteUsb(0,count,tx);

        }

    }
}
