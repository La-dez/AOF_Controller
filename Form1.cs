using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LDZ_Code;

using static AO_Lib.AO_Devices;
using static LDZ_Code.ServiceFunctions;

namespace AOF_Controller
{
    public partial class Form1 : Form
    {
        // Все для работы АО
        bool AO_WL_Controlled_byslider = false;
        double AO_WL_precision = 100.0;
        double AO_HZ_precision = 1000.0;

        //Все для sweep
        double AO_FreqDeviation_Max_byTime = 0;
        double AO_FreqDeviation = 5;
        double AO_TimeDeviation = 10;
        bool AO_Sweep_Needed = false;
        float[,] AO_All_CurveSweep_Params = new float[0, 0];
        bool AO_Sweep_CurveTuning_isEnabled = true;
        bool AO_Sweep_CurveTuning_inProgress = false;
        bool AO_Sweep_CurveTuning_StopFlag = false;

        List<object> ParamList_bkp = new List<object>();
        List<object> ParamList_final = new List<object>();

        //
        List<float> ProgramMode_curve = new List<float>();
        //UI
        UI.Log.Logger Log;
        AO_Filter Filter = null;
        System.Diagnostics.Stopwatch timer_for_sweep = new System.Diagnostics.Stopwatch();
        bool Value_in_setting = false;
        bool Admin_mode = false;

        string AO_ProgramSweepCFG_filename = Application.StartupPath + "\\AOData.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {       
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            Text = "AOF Controller v" + " " + version.Major + "." + (9).ToString() + " (build " + (version.Build + version.Revision) + ")"; //change form title
            // this.Text =  + version;
            this.KeyPreview = true;
            Log = new UI.Log.Logger(LBConsole);
            Log.Message(" - текущее время");
            var Filters = AO_Lib.AO_Devices.AO_Filter.Find_all_filters();
            if (Filters.Count > 0)
            {
                if (Filters.Count > 1) Log.Message("Обнаружено несколько фильтров. Будет подключен первый обнаруженный...");
                Filter = Filters[0];
            }
            else if(Filters.Count == 0)
            {
                Log.Message("Не обнаружены именованные фильтры. Поиск неименнованного фильтра...");
                Filter = AO_Lib.AO_Devices.AO_Filter.Find_and_connect_AnyFilter();                
            }

            if (Filter.FilterType == FilterTypes.Emulator) { Log.Message("ПРЕДУПРЕЖДЕНИЕ: Не обнаружены подключенные АО фильтры. Фильтр будет эмулирован."); }
            else { Log.Message("Обнаружен подключенный АО фильтр. Тип фильтра: " + Filter.FilterType.ToString()); }
            Filter.onSetHz += Filter_onSetHz1;
            Filter.onSetWl += Filter_onSetWl1;
            ChB_Power.Enabled = false;
            GB_AllAOFControls.Enabled = false;
            TSMI_CreateCurve.Enabled = false;
            Test_datacalc();
            ReadData();

            
            //tests();
        }

        private void Filter_onSetWl1(AO_Filter sender, float WL_now, float HZ_now)
        {
            try
            {
                Log.Message(string.Format("Установленная длина волны: {0:0.00}. Частота синтезатора: {1:0.000}", WL_now, HZ_now));
            }
            catch(Exception e)
            {

            }
        }

        private void Filter_onSetHz1(AO_Filter sender, float WL_now, float HZ_now)
        {
            try
            {
                Log.Message(string.Format("Установленная длина волны: {0:0.00}. Частота синтезатора: {1:0.000}", WL_now, HZ_now));
            }
            catch (Exception e)
            {

            }

        }


        private void Test_datacalc()
        {
            //Testing of some new functions
            //Sweep_usual
            {
                double Ramp_min = 11.42; //ns
                double Ramp_max = Ramp_min * 256; //ns, =2.923 mcrs
                double Ramp_up_selected = 100; //ns
                double Ramp_down_selected = 50; //ns
                //user
                double Time_for_oneSweep = 10;//mcrs
                double f1 = 70; // MHz
                double f2 = 75; //MHz

                int mode = 0;   //0 -  f1-f2, after we will stop on f2
                                //1 -  f1-f2, after we will turn back to f1 at once
                                //2 -  f1-f2,after we will go back from f2 to f1 smoothly 


                int N_up = (int)(Time_for_oneSweep * 1000 / Ramp_up_selected);
                int N_down = (int)(Time_for_oneSweep * 1000 / Ramp_down_selected);
                double f_delta_up = (f2 - f1) * 1000 / (double)N_up; // KHz
                double f_delta_down = (f2 - f1) * 1000 / (double)N_down; // KHz

                byte[] ByteMass = new byte[1 + 4 + 4 + 4 + 4 + 1 + 1];
                ByteMass[0] = 0;//command here, according to mode

                ByteMass[1] = 0; //f1 bytes
                ByteMass[2] = 0;
                ByteMass[3] = 0;
                ByteMass[4] = 0;

                ByteMass[5] = 0; //f2 bytes
                ByteMass[6] = 0;
                ByteMass[7] = 0;
                ByteMass[8] = 0;

                ByteMass[9] = 0; //f_delta_up bytes
                ByteMass[10] = 0;
                ByteMass[11] = 0;
                ByteMass[12] = 0;

                ByteMass[13] = 0; //f_delta_down bytes
                ByteMass[14] = 0;
                ByteMass[15] = 0;
                ByteMass[16] = 0;

                ByteMass[17] = (byte)(Ramp_up_selected/ N_up); //RampUp Byte
                ByteMass[17] = (byte)(Ramp_down_selected / N_down); //RampUp Byte
                
            }

            //sweep programmed
            {
                int Number_of_ranges = 5;
                double Ramp_min = 11.42; //ns
                double Ramp_max = Ramp_min * 65536; //ns, =2.923 mcrs
                double Ramp_selected = 100; //ns
                double Time_all_max_ns = Ramp_max * (Number_of_ranges < 5 ? 800:1000); // ns /
                double Time_all_max_ms = Time_all_max_ns / 10e6; //59,87 ms

                double f_delta = 0.05;//MHz
                //user defined
                double[] Time_for_oneSweep = new double[5] { 0.4, 0.8, 0.7, 0.5, 0.1};//ms
                double[] f_N = new double[6] { 65, 70, 65, 75, 65, 75 };//MHz

             
                double f_total_lenght = 0;
                for (int i = 0; i < Number_of_ranges; i++)
                {
                    f_total_lenght+= System.Math.Abs(f_N[i + 1] - f_N[i]); 
                }
                int N_total = (int)(f_total_lenght / f_delta);

                //proportional decreasing of increasing depending on total latencity
                double SummaryTime = Time_for_oneSweep.Sum();
                if (SummaryTime * 10e6 > N_total*Ramp_max)
                {
                    Log.Message("Sum of times is more than " + Time_all_max_ms.ToString() + ". Do you want decrease it proportionnally?");
                    bool DecProp = false; //depend on user.
                    if (DecProp)
                    {
                        double coef = Time_all_max_ms / SummaryTime;
                        for (int i = 0; i < Number_of_ranges; i++) { Time_for_oneSweep[i] *= coef; }
                    }
                    else return;
                }
                else if (SummaryTime * 10e6 < N_total * Ramp_min)
                { 
                    Log.Message("Sum of times is more than " + Time_all_max_ms.ToString() + ". Do you want decrease it proportionnally?");
                    bool DecProp = false; //depend on user
                    if (DecProp)
                    {
                        double coef = N_total * Ramp_min / SummaryTime;
                        for (int i = 0; i < 5; i++) { Time_for_oneSweep[i] *= coef; }
                    }
                    else return;
                }

                if(Number_of_ranges<5) //Ramp is not fixed, number of ranges < 5
                {
                    int[] Num_of_memblocks_for_range = new int[Number_of_ranges];
                    double[] Ramps_selected = new double[Number_of_ranges];
                    for (int i = 0; i < Number_of_ranges; i++) // calculating of exact numbers of memory blocks for each range
                    {
                        Num_of_memblocks_for_range[i] = (int)(System.Math.Abs(f_N[i + 1] - f_N[i]) / f_delta);
                        double Ramp_nearest = Time_for_oneSweep[i] * 10e6 /  Num_of_memblocks_for_range[i]; //nearest ramp
                        int data = (int)(Ramp_nearest / Ramp_min); //exact ramp multiplier
                        Ramps_selected[i] = Ramp_min * (data < 1 ? 1 : data); //exact ramp
                    }
                }
                else //Ramp is fixed, number of ranges >=5
                {
                    //it was bad idea, because firstly, we'll recalculate number of step, and secondly, we can get more than 200 blocks per range
                    
                    /* double Ramp_nearest = SummaryTime * 10e6 / N_total; //nearest ramp
                     int data = (int)(Ramp_nearest / Ramp_min); //exact ramp multiplier
                     Ramp_selected = Ramp_min * (data<1? 1:data); //exact ramp*/
                   
                    //so, I've found another solution
                    double Ramp_nearest = Time_for_oneSweep.Max() * 10e6 / 200; //nearest ramp
                    int data = (int)(Ramp_nearest / Ramp_min); //exact ramp multiplier
                    Ramp_selected = Ramp_min * data;
                    if((int)(Time_for_oneSweep.Max() * 10e6 / Ramp_selected)>200) { Ramp_selected = Ramp_min * (data + 1); } //little check, idk if we really need it

                    int[] Num_of_memblocks_for_range = new int[Number_of_ranges];
                    for(int i =0;i< Number_of_ranges;i++) // calculating of exact numbers of memory blocks for each range
                    {
                        Num_of_memblocks_for_range[i] = (int)(Time_for_oneSweep[i] * 10e6 / Ramp_selected);
                    }
                    double[] f_delta_exact = new double[Number_of_ranges];
                    for (int i = 0; i < Number_of_ranges; i++) // recalculating of exact f-delta for each range
                    {
                        f_delta_exact[i] = (f_N[i + 1] - f_N[i]) / (double)Num_of_memblocks_for_range[i]; //MHz
                    }

                }
                //selecting of ramps, if ramps factors are different

            }
        }
        private void ReadData()
        {
            try
            {
                List<string> strings = Files.Read_txt(AO_ProgramSweepCFG_filename);
               

                for (int i = 0; i < strings.Count; i++)
                {
                    if (String.IsNullOrEmpty(strings[i])) { strings.RemoveAt(i); i--; }
                }
                AO_All_CurveSweep_Params = new float[strings.Count, 7];
                for (int i = 0; i != strings.Count; ++i)
                {

                    int startindex = 0;
                    int finishindex = 0;
                    for (int j = 0; j < 7; ++j)
                    {
                        if (j == 6)
                        {
                            finishindex = (strings[i].IndexOf("\t") > 0 ? strings[i].IndexOf("\t") : strings[i].Length);
                            string dataval = strings[i].Substring(startindex, finishindex - startindex).Replace('.', ',');
                            AO_All_CurveSweep_Params[i, j] = (float)Convert.ToDouble(dataval);
                        }
                        else
                        {
                            finishindex = strings[i].IndexOf("\t");
                            string dataval = strings[i].Substring(startindex, finishindex - startindex).Replace('.', ',');
                            AO_All_CurveSweep_Params[i, j] = (float)Convert.ToDouble(dataval);
                            startindex = 0;
                            strings[i] = strings[i].Substring(finishindex + 1);
                        }
                    }
                }
            }
            catch(Exception exc)
            {
                Log.Error("ORIGINAL:" + exc.Message);
                Log.Message("Не удалось считать файл с настройками программируемой перестройки.");
            }
            Log.Message("Количество интервалов программируемого режима: " + AO_All_CurveSweep_Params.GetLength(0).ToString());
        }
        private void SaveData()
        {
            List<string> result = new List<string>();
            int i_max = AO_All_CurveSweep_Params.GetLength(0);
            string datastring = null;
            for (int i = 0; i < i_max; i++)
            {
                datastring = null;
                for (int j = 0; j < 6; j++)
                {
                    datastring += AO_All_CurveSweep_Params[i, j].ToString() + "\t";
                }
                datastring += AO_All_CurveSweep_Params[i, 6].ToString();
                result.Add(datastring);
            }
            Files.Write_txt(AO_ProgramSweepCFG_filename, result);
        }
        private void BDevOpen_Click(object sender, EventArgs e)
        {
            string AO_DEV_loaded = null;
            string AO_DEV_loaded_fullPath = null;

            var DR = OpenDevSearcher(ref AO_DEV_loaded, ref AO_DEV_loaded_fullPath);

            if (DR == DialogResult.OK)
                try
                {
                    var Status = Filter.Read_dev_file(AO_DEV_loaded_fullPath);
                    if (Status == 0)
                        Log.Message(AO_DEV_loaded_fullPath + " - файл считан успешно!");
                    else
                        throw new Exception(Filter.Implement_Error(Status));

                    if (Filter.FilterType == FilterTypes.STC_Filter)
                    {
                        Log.Message("Бит инверсия (считана из файла): " + (Filter as STC_Filter).Bit_inverse_needed.ToString().ToLower());
                    }
                    else if ((Filter.FilterType == FilterTypes.Emulator))
                    {
                        Log.Message("Бит инверсия (считана из файла): " + (Filter as Emulator).Bit_inverse_needed.ToString().ToLower());
                    }

                }
                catch (Exception exc)
                {
                    Log.Message("Произошла ошибка при прочтении .dev файла");
                    Log.Error("ORIGINAL:" + exc.Message);
                    return;
                }
            else return;

            AO_FreqDeviation_Max_byTime = AO_TimeDeviation / (1000.0f / Filter.AO_ExchangeRate_Min);
            InitializeComponents_byVariables();
        }

        private void ChBAutoSetWL_CheckedChanged(object sender, EventArgs e)
        {
            AO_WL_Controlled_byslider = ChB_AutoSetWL.Checked;
        }

        private void BSetWL_Click(object sender, EventArgs e)
        {
            if (!Value_in_setting)
                Set_HZorWL_everywhere((float)NUD_CurMHz.Value, true, AO_WL_precision, AO_HZ_precision, true, false);
        }

        private void TrB_CurrentWL_Scroll(object sender, EventArgs e)
        {
            if (!Value_in_setting)
                Set_HZorWL_everywhere((float)(TrB_CurrentWL.Value/AO_WL_precision), false, AO_WL_precision, AO_HZ_precision, AO_WL_Controlled_byslider);
        }


        private void ChB_Power_CheckedChanged(object sender, EventArgs e)
        {
            bool newAOFPowerStatus = ChB_Power.Checked;
            if (newAOFPowerStatus)
            {
                try
                {
                    var state = Filter.PowerOn();
                    if (state == 0)
                    {
                        Log.Message("Активация АОФ успешна!");
                       
                        GB_AllAOFControls.Enabled = true;
                    }
                    else throw new Exception(Filter.Implement_Error(state));
                }
                catch (Exception exc)
                {
                    Log.Message("Возникла проблема при активации АОФ.");
                    Log.Error(exc.Message);
                }
            }
            else
            {
                GB_AllAOFControls.Enabled = false;
                Filter.PowerOff();
            }
        }

        private void NUD_CurWL_ValueChanged(object sender, EventArgs e)
        {
            if (!Value_in_setting)
                Set_HZorWL_everywhere((float)NUD_CurWL.Value, false, AO_WL_precision, AO_HZ_precision, AO_WL_Controlled_byslider);
        }


        private void NUD_StartL_ValueChanged(object sender, EventArgs e)
        {
            //  AOFWind_StartL = (float)NUD_StartL.Value;
        }

        private void NUD_FinishL_ValueChanged(object sender, EventArgs e)
        {
            //  AOFWind_EndL = (float)NUD_FinishL.Value;
        }

        private void NUD_StepL_ValueChanged(object sender, EventArgs e)
        {
            //  AOFWind_StepL = (float)NUD_StepL.Value;
        }

        private void ChB_SweepEnabled_CheckedChanged(object sender, EventArgs e)
        {
            AO_Sweep_Needed = ChB_SweepEnabled.Checked;
            Pan_SweepControls.Enabled = AO_Sweep_Needed;

            //   
            TLP_Sweep_EasyMode.Enabled = AO_Sweep_Needed;
            TLP_Sweep_ProgramMode.Enabled = AO_Sweep_Needed && AO_Sweep_CurveTuning_isEnabled;
            RB_Sweep_SpeciallMode.Enabled = AO_Sweep_Needed && AO_Sweep_CurveTuning_isEnabled; // false while not released

            Init_sweep_ctrls();

        }

        private void NUD_TimeFdev_ValueChanged(object sender, EventArgs e)
        {
            AO_TimeDeviation = (double)NUD_TimeFdev_up.Value;
            AO_FreqDeviation_Max_byTime = AO_TimeDeviation / (1000.0f / Filter.AO_ExchangeRate_Min);
            /*NUD_FreqDeviation.Maximum = (decimal)
                (AO_FreqDeviation_Max_byTime < Filter.AO_FreqDeviation_Max ? AO_FreqDeviation_Max_byTime : Filter.AO_FreqDeviation_Max);*/
            NUD_FreqDeviation.Maximum = (decimal)(Filter.AO_FreqDeviation_Max);
            NUD_FreqDeviation.Minimum = (decimal)(Filter.AO_FreqDeviation_Min);
        }

        private void NUD_FreqDeviation_ValueChanged(object sender, EventArgs e)
        {
            AO_FreqDeviation = (double)NUD_FreqDeviation.Value;
        }

        private void B_Quit_Click(object sender, EventArgs e)
        {

            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try {
                SaveData();
            }
            catch { }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void TSMI_CreateCurve_Click(object sender, EventArgs e)
        {
            W_AO_SweepTuneCurve Window = new W_AO_SweepTuneCurve(AO_All_CurveSweep_Params, Filter, AO_Sweep_CurveTuning_isEnabled,
            (Action<float[,], bool>)delegate (float[,] Mass_from_window, bool IsCurveEnabled)
             {
                 AO_All_CurveSweep_Params = new float[Mass_from_window.GetLength(0), Mass_from_window.GetLength(1)];
                 AO_All_CurveSweep_Params = Mass_from_window;
                 AO_Sweep_CurveTuning_isEnabled = IsCurveEnabled;
                 if (Filter.FilterType == FilterTypes.STC_Filter) (Filter as STC_Filter).Create_byteMass_forProgramm_mode(AO_All_CurveSweep_Params);
             },
            (Action<W_AO_SweepTuneCurve>)delegate (W_AO_SweepTuneCurve ChildWindow)
            {
                ChildWindow.Close();
            }
            );
            Window.ShowDialog();
        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RB_Sweep_EasyMode_CheckedChanged(object sender, EventArgs e)
        {
            ChB_SweepEnabled.Enabled = RB_Sweep_EasyMode.Checked && !RB_Sweep_SpeciallMode.Checked;

            TLP_Sweep_EasyMode.Enabled = AO_Sweep_Needed && !RB_Sweep_SpeciallMode.Checked;
            TLP_Sweep_ProgramMode.Enabled = AO_Sweep_Needed && AO_Sweep_CurveTuning_isEnabled && RB_Sweep_SpeciallMode.Checked;

            TLP_WLSlidingControls.Enabled = RB_Sweep_EasyMode.Checked && !RB_Sweep_SpeciallMode.Checked;
            TLP_SetControls.Enabled = RB_Sweep_EasyMode.Checked && !RB_Sweep_SpeciallMode.Checked;
        }

        private void RB_Sweep_SpeciallMode_CheckedChanged(object sender, EventArgs e)
        {
            ChB_SweepEnabled.Enabled = RB_Sweep_EasyMode.Checked && !RB_Sweep_SpeciallMode.Checked;

            TLP_Sweep_EasyMode.Enabled = AO_Sweep_Needed && !RB_Sweep_SpeciallMode.Checked;
            TLP_Sweep_ProgramMode.Enabled = AO_Sweep_Needed && /*AO_Sweep_CurveTuning_isEnabled &&*/ RB_Sweep_SpeciallMode.Checked;

            TLP_WLSlidingControls.Enabled = RB_Sweep_EasyMode.Checked && !RB_Sweep_SpeciallMode.Checked;
            TLP_SetControls.Enabled = RB_Sweep_EasyMode.Checked && !RB_Sweep_SpeciallMode.Checked;
        }

        private void ChB_ProgrammSweep_toogler_CheckedChanged(object sender, EventArgs e)
        {
            if(ChB_ProgrammSweep_toogler.Checked)
            {
                BGW_ProgrammedTuning.RunWorkerAsync();
            }
            else
            {
                BGW_ProgrammedTuning.CancelAsync();
            }
            
            //предыдущая версия. Была основана на загрузке кривой из меню сверху. В дальнейшем нужно возродить
            /*if (AO_Sweep_CurveTuning_isEnabled)
            {
                if (AO_Sweep_CurveTuning_inProgress)
                {
                    if (Filter.FilterType == FilterTypes.STC_Filter)
                    {
                        if (Filter.is_Programmed)
                            (Filter as STC_Filter).Set_ProgrammMode_off();
                        AO_Sweep_CurveTuning_inProgress = false;
                    }
                    else
                    {
                        AO_Sweep_CurveTuning_StopFlag = true;
                    }
                }
                else
                {
                    if (Filter.FilterType == FilterTypes.STC_Filter)
                    {
                        if (Filter.is_Programmed)
                            (Filter as STC_Filter).Set_ProgrammMode_on();

                        AO_Sweep_CurveTuning_inProgress = true;
                    }
                    else
                    {
                        AO_Sweep_CurveTuning_StopFlag = false;
                        AO_Sweep_CurveTuning_inProgress = true;
                        BGW_Sweep_Curve.RunWorkerAsync();
                    }
                }
            }*/
        }

        private void BGW_Sweep_Curve_DoWork(object sender, DoWorkEventArgs e)
        {
            Sweep_Especiall(sender as BackgroundWorker, e);
        }
        private void Sweep_Especiall(BackgroundWorker pBGW = null, DoWorkEventArgs pe = null)
        {
            int i_max = AO_All_CurveSweep_Params.GetLength(0);
            float[,] Mass_of_params = new float[i_max, 7];
            int i = 0;
            for (i = 0; i < i_max; i++)
            {
                Mass_of_params[i, 0] = AO_All_CurveSweep_Params[i, 0]; //ДВ (для отображения)
                if (AO_All_CurveSweep_Params[i, 3] != 0) //строка со свипом
                {
                    PointF data_for_sweep = Filter.Sweep_Recalculate_borders(AO_All_CurveSweep_Params[i, 2], AO_All_CurveSweep_Params[i, 3]);
                    Mass_of_params[i, 1] = data_for_sweep.X;//Частота Синтезатора
                    Mass_of_params[i, 2] = data_for_sweep.Y;//пересчитанная девиация 
                }
                else//строка с обычной перестройкой
                {
                    Mass_of_params[i, 1] = AO_All_CurveSweep_Params[i, 2];//Частота Синтезатора
                    Mass_of_params[i, 2] = 0;//пересчитанная девиация
                }
                Mass_of_params[i, 3] = AO_All_CurveSweep_Params[i, 4]; //время одной девиации
                Mass_of_params[i, 4] = AO_All_CurveSweep_Params[i, 5]; //количество девиаций
            }
            i = 0;
            Log.Message(String.Format("Перестройка запущена."));
            while (true)
            {
                try
                {
                    if (AO_Sweep_CurveTuning_StopFlag)
                    {
                        pe.Cancel = true;
                        break;
                    }

                    if (Mass_of_params[i, 2] == 0)//стандартная перестройка
                    {
                        int time_ms = (int)(Mass_of_params[i, 3] * Mass_of_params[i, 4]);
                        Log.Message(String.Format("Вход в интевал перестройки №{0}. Режим: без ЛЧМ. ДВ: {1} нм ({2} MHz). Необходимое время отработки: {3} мс.",
                            i, Mass_of_params[i, 0], Mass_of_params[i, 1], time_ms));
                        if (Filter.is_inSweepMode) Filter.Set_Sweep_off();
                        Filter.Set_Hz(Mass_of_params[i, 1]);
                        if (AO_Sweep_CurveTuning_StopFlag)
                        {
                            pe.Cancel = true;
                            break;
                        }
                        System.Threading.Thread.Sleep(time_ms);
                    }
                    else//свип
                    {
                        int time_ms = (int)(Mass_of_params[i, 3] * Mass_of_params[i, 4]);
                        Log.Message(String.Format("Вход в интевал перестройки №{0}. Режим: ЛЧМ. ДВ: {1} ({2} MHz). Левая граница: {3} MHz. Ширина:{4} MHz. Необходимое время отработки: {5} мс.",
                            i, Mass_of_params[i, 0], AO_All_CurveSweep_Params[i, 2], Mass_of_params[i, 1], Mass_of_params[i, 2], time_ms));
                        if (Filter.is_inSweepMode) Filter.Set_Sweep_off();
                        Filter.Set_Sweep_on(Mass_of_params[i, 1], Mass_of_params[i, 2], Mass_of_params[i, 3], true);
                        if (AO_Sweep_CurveTuning_StopFlag)
                        {
                            pe.Cancel = true;
                            break;
                        }
                        System.Threading.Thread.Sleep((int)(Mass_of_params[i, 3] * Mass_of_params[i, 4]));
                        if (Filter.is_inSweepMode) Filter.Set_Sweep_off();
                    }
                    i++;
                    if (i == i_max) i = 0;
                }
                catch (Exception exc)
                {
                    pe.Result = exc;
                    break;
                }
            }
        }

       
        private void BGW_Sweep_Curve_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Log.Message(String.Format("Перестройка прервана пользователем."));
                AO_Sweep_CurveTuning_StopFlag = false;
                AO_Sweep_CurveTuning_inProgress = false;
            }
            else
            {
                Log.Message(String.Format("Перестройка прервана из-за внутренней ошибки."));
                if (Filter.is_inSweepMode) Filter.Set_Sweep_off();
                AO_Sweep_CurveTuning_StopFlag = false;
                AO_Sweep_CurveTuning_inProgress = false;
                ChB_ProgrammSweep_toogler.Checked = false;
            }
        }

        private void созданиеКривыхToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void TrB_CurrentWL_ValueChanged(object sender, EventArgs e)
        {
            Log.Message("Meow");
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void Timer_sweepChecker_Tick(object sender, EventArgs e)
        {
            if (AO_WL_Controlled_byslider)
            {
                if (AO_Sweep_Needed)
                {
                    if (timer_for_sweep.ElapsedMilliseconds > 600)
                    {
                        float data_CurrentWL = (float)(TrB_CurrentWL.Value / AO_WL_precision);
                        timer_for_sweep.Reset();
                        ReSweep(data_CurrentWL);

                    }
                }
            }
        }

        private void NUD_CurMHz_ValueChanged(object sender, EventArgs e)
        {
            if (!Value_in_setting)
                Set_HZorWL_everywhere((float)NUD_CurMHz.Value, true, AO_WL_precision, AO_HZ_precision, AO_WL_Controlled_byslider);
        }

        private void TRB_SoundFreq_Scroll(object sender, EventArgs e)
        {
            if (!Value_in_setting)
                Set_HZorWL_everywhere((float)(TRB_SoundFreq.Value/AO_HZ_precision), true, AO_WL_precision, AO_HZ_precision, AO_WL_Controlled_byslider);
        }

        private void B_setHZSpecialSTC_Click(object sender, EventArgs e)
        {
            float MHz_toSet = (float)NUD_CurMHz.Value;
            float pDecr_val = (float)NUD_PowerDecrement.Value;
            if(Filter.FilterType == FilterTypes.STC_Filter)
            {
                (Filter as STC_Filter).Set_Hz(MHz_toSet, pDecr_val);
                Log.Message(String.Format("Установленная частота: {0}, коэффициент ослабления: {1}", MHz_toSet, pDecr_val));
            }
            else
            {
                Log.Error("Работа с коэффициентами усиления не поддерживается данным типом фильтров!");
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.A) && e.Alt)
            {
                Admin_mode = !Admin_mode;
                    TLP_STCspecial_Fun.Visible = Admin_mode && ((Filter.FilterType == FilterTypes.STC_Filter)||(Filter.FilterType == FilterTypes.Emulator));
            }
        }

        private void NUD_PowerDecrement_ValueChanged(object sender, EventArgs e)
        {

        }

        private void B_SetSweep_Click(object sender, EventArgs e)
        {
            PointF Sweep_Params = Filter.Sweep_Recalculate_borders((float)NUD_CurMHz.Value, (float)NUD_FreqDeviation.Value);
           if(Filter.FilterType==FilterTypes.STC_Filter)
                (Filter as STC_Filter).Set_Sweep_on(Sweep_Params.X, Sweep_Params.Y,(int)NUD_Steps_on_Sweep.Value,(double)NUD_TimeFdev_up.Value,(double)NUD_TimeFdev_down.Value);
            else Filter.Set_Sweep_on(Sweep_Params.X, Sweep_Params.Y, (double)NUD_TimeFdev_up.Value, true);

        }

        private void NUD_Incr_CurMHz_ValueChanged(object sender, EventArgs e)
        {
            NUD_CurMHz.Increment = NUD_Incr_CurMHz.Value;
        }

        private void ChB_TimeOut_CheckedChanged(object sender, EventArgs e)
        {
            NUD_AO_Timeout_Value.Enabled = ChB_TimeOut.Checked;
            if (ChB_TimeOut.Checked) Filter.InitTimer((int)NUD_AO_Timeout_Value.Value);
            else Filter.DeinitTimer();
        }

        private void NUD_AO_Timeout_Value_ValueChanged(object sender, EventArgs e)
        {
            if (NUD_AO_Timeout_Value.Enabled) Filter.InitTimer((int)NUD_AO_Timeout_Value.Value);
        }

        
        private void B_BrowseCSVCurve_Click(object sender, EventArgs e)
        {
            var name =  ServiceFunctions.Files.OpenFile("Select CSV AO curve", false, "csv");
            if (String.IsNullOrEmpty(name)) return; 
            Log.Message("Selected curve file: "+ name);
            TB_CSVCurveFolder.Text = name;
            Process_file(name);

        }
        //старая версия функции. Была предназначена для проверки скорости перестройки
        double time_sum = 0;
        private void BGW_ProgrammedTuning_DoWork2(object sender, DoWorkEventArgs e)
        {
           /* int i = 0;
            int number_of_runs = 0;
            try
            {
                System.Diagnostics.Stopwatch STW = new System.Diagnostics.Stopwatch();
                while (!(sender as BackgroundWorker).CancellationPending)
                {
                    STW.Start();
                    while (i < ProgramMode_curve.Count)
                    {
                        this.Invoke(new Action(()=>(Filter as STC_Filter).Set_Hz_via_bytemass(ByteMass[i])));
                        i++;
                    }
                    STW.Stop();
                    time_sum += STW.Elapsed.TotalMilliseconds;
                    number_of_runs++;
                    i = 0;

                    // Log.Message("Частота: " + ProgramMode_curve[i].ToString());
                }
                time_sum /= number_of_runs;
                Log.Message(String.Format("Среднее время на перестройку {0} частот: {1}", ProgramMode_curve.Count, time_sum));
            }
            catch(Exception exc)
            {
                var message = exc.Message;
            }*/
        }
        private void BGW_ProgrammedTuning_DoWork(object sender, DoWorkEventArgs e)
        {
            //MF_mode_freqs
            if (Filter.FilterType != FilterTypes.STC_Filter && Filter.FilterType != FilterTypes.Emulator)
            {
                Log.Error("Реализация данного режима на этом типе фильтров невозможна!");
                return;
            }
            int amp_max = (int)Filter.Intensity_Max;
            int amp_min = (int)Filter.Intensity_Min;
            int amp_delta = amp_max - amp_min;

            if (amp_max < 1 || amp_min < 1)
            {
                Log.Error("Загрузите dev-файл с новыми амлитудами (целочисленные значения > 1000)!");
                return;
            }
            if (amp_max == amp_min)
            {
                Log.Error("Выберете dev-файл, в которым будут разные значения амплитуд!");
                return;
            }
            if (MF_mode_freqs.Count() < 2)
            {
                Log.Error("Задайте массив, в котором будет больше одной частоты!");
                return;
            }
            int MF_mode_CountOfFreqs = MF_mode_freqs.Count();
            double MF_mode_deltaT = MF_mode_times[1] - MF_mode_times[0];
            int[] Amps = new int[MF_mode_CountOfFreqs];
            for (int j = 0; j < MF_mode_CountOfFreqs; j++)
                Amps[j] = (int)(amp_min + MF_mode_magnitudes[j] * amp_delta);

            if (Filter.is_inSweepMode) Filter.Set_Sweep_off();

            //precalculating
            List<byte[]> ByteMass_list = new List<byte[]>();
           
            
            int deleted_freqs = 0;
            for (int j = 0; j < MF_mode_CountOfFreqs- deleted_freqs; j++)
            {
                if (MF_mode_freqs[j] < Filter.HZ_Min || MF_mode_freqs[j] > Filter.HZ_Max)
                {
                    MF_mode_freqs.RemoveAt(j);
                    j--; deleted_freqs++;
                }
            }

            if (Filter.FilterType == FilterTypes.STC_Filter)
            {
                for (int j = 0; j < MF_mode_CountOfFreqs; j++)
                {
                    if (MF_mode_freqs[j] >= Filter.HZ_Min || MF_mode_freqs[j] <= Filter.HZ_Max)
                        ByteMass_list.Add((Filter as STC_Filter).Create_byteMass_forHzTune(MF_mode_freqs[j], (uint)Amps[j]));
                }
            }

            if (Filter.FilterType == FilterTypes.STC_Filter) MF_mode_CountOfFreqs = ByteMass_list.Count;
            else MF_mode_CountOfFreqs = MF_mode_freqs.Count; //поскольку часть частот могла быть выкинута, пересчитаем их
            Log.Message(String.Format("Перестройка запущена."));
            int i = 0;
            if (Filter.FilterType == FilterTypes.STC_Filter)
            {
                while (!(sender as BackgroundWorker).CancellationPending)
                {
                    try
                    {

                        this.Invoke(new Action(() => (Filter as STC_Filter).Set_Hz_via_bytemass(ByteMass_list[i])));
                        if (AO_Sweep_CurveTuning_StopFlag)
                        {
                            e.Cancel = true;
                            break;
                        }
                        System.Threading.Thread.Sleep((int)(MF_mode_deltaT * 1000));


                        i++;
                        if (i == MF_mode_CountOfFreqs) i = 0;
                    }
                    catch (Exception exc)
                    {
                        e.Result = exc;
                        break;
                    }
                }

            }
            else
            {
                while (!(sender as BackgroundWorker).CancellationPending)
                {
                    try
                    {

                        int time_ms = (int)(MF_mode_deltaT * 1000);
                        this.Invoke(new Action(() => Filter.Set_Hz(MF_mode_freqs[i])));
                        Filter.Set_Hz(MF_mode_freqs[i]);
                        if (AO_Sweep_CurveTuning_StopFlag)
                        {
                            e.Cancel = true;
                            break;
                        }
                        System.Threading.Thread.Sleep(time_ms);


                        i++;
                        if (i == MF_mode_CountOfFreqs) i = 0;
                    }
                    catch (Exception exc)
                    {
                        e.Result = exc;
                        break;
                    }
                }
            }

        }
        private void NUD_Steps_on_Sweep_ValueChanged(object sender, EventArgs e)
        {
            Init_sweep_ctrls();
        }

        private void TLP_Sweep_EasyMode_Paint(object sender, PaintEventArgs e)
        {

        }

        private void NUD_TimeFdev_down_ValueChanged(object sender, EventArgs e)
        {
            if ((double)(NUD_TimeFdev_down.Value - (NUD_Steps_on_Sweep.Value * (decimal)(4.0f / 350f))) < -1e-5) //если значение времени сейчас = минимальному, то 
            {
                NUD_TimeFdev_down.Value = 0;
                NUD_TimeFdev_down.Increment = NUD_Steps_on_Sweep.Value * (decimal)(4.0f / 350f);
                NUD_TimeFdev_down.Minimum = 0;
            }
            else if(NUD_TimeFdev_down.Value<(decimal)1e-5)
            {
                NUD_TimeFdev_down.Increment = NUD_Steps_on_Sweep.Value * (decimal)(4.0f / 350f);
                NUD_TimeFdev_down.Minimum = 0;
            }
            else if ((double)System.Math.Abs(NUD_TimeFdev_down.Value - (NUD_Steps_on_Sweep.Value * (decimal)(4.0f / 350f))) < 1e-5)
            {
                NUD_TimeFdev_down.Increment = (decimal)0.001;
                NUD_TimeFdev_down.Minimum = 0;
            }
            else
            {
                NUD_TimeFdev_down.Increment = (decimal)0.001;
            }
            
        }

        private void B_Test_Click(object sender, EventArgs e)
        {
            var num_of_F = 10;
            float _df = (Filter.HZ_Max - Filter.HZ_Min) / (num_of_F+2);

            List<float> LoF = new List<float>();

            for (int i =0;i< num_of_F;i++)
            {
                LoF.Add(Filter.HZ_Min + (i + 1) * _df);
            }

            try
            {
                (Filter as STC_Filter).Set_MF_test(LoF, 20f);
            }   
            catch
            {
                Log.Error("Error in testing!");
            }        

        }

        private void B_CreateData_Click(object sender, EventArgs e)
        {
            var window = new AO_DataSynt(Process_file);
            window.ShowDialog();
        }
        List<float> MF_mode_times;
        List<float> MF_mode_freqs;
        List<float> MF_mode_magnitudes;
        private void Process_file(string FileName)
        {
            TB_CSVCurveFolder.Text = FileName;
            //some actions of loading
            MF_mode_times = CSV_MyHelper.Read_Frequencies_fromCSV(FileName, 1, 0);
            MF_mode_freqs = CSV_MyHelper.Read_Frequencies_fromCSV(FileName, 1, 1);
            MF_mode_magnitudes = CSV_MyHelper.Read_Frequencies_fromCSV(FileName, 1, 2);

            for(int i= MF_mode_freqs.Count-1; i>-1;i--)
            {
                Log.Message(String.Format("{0:0.000}\t{1:0.00000}\t\t{2:0.00000}", MF_mode_times[i], MF_mode_freqs[i], MF_mode_magnitudes[i]));
            }
            Log.Message("Количество прочитанных частот:" + MF_mode_freqs.Count); 

        }

        private void BGW_ProgrammedTuning_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Log.Message(String.Format("Перестройка прервана пользователем."));
                AO_Sweep_CurveTuning_StopFlag = false;
                AO_Sweep_CurveTuning_inProgress = false;
            }
            else
            {
                Log.Message(String.Format("Перестройка прервана из-за внутренней ошибки."));
                if (Filter.is_inSweepMode) Filter.Set_Sweep_off();
                AO_Sweep_CurveTuning_StopFlag = false;
                AO_Sweep_CurveTuning_inProgress = false;
                ChB_ProgrammSweep_toogler.Checked = false;
            }
        }
    }
}

