using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LDZ_Code;

using static LDZ_Code.AO_Devices;
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
        double AO_FreqDeviation = 0.5;
        double AO_TimeDeviation = 10;
        bool AO_Sweep_Needed = false;
        float[,] AO_All_CurveSweep_Params = new float[0, 0];
        bool AO_Sweep_CurveTuning_isEnabled = false;
        bool AO_Sweep_CurveTuning_inProgress = false;
        bool AO_Sweep_CurveTuning_StopFlag = false;

        List<object> ParamList_bkp = new List<object>();
        List<object> ParamList_final = new List<object>();

        UI.Log.Logger Log;
        AO_Filter Filter = null;
        System.Diagnostics.Stopwatch timer_for_sweep = new System.Diagnostics.Stopwatch();

        string AO_ProgramSweepCFG_filename = "AOData.txt";

        

        string version = "1.7";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Перестраиваемый источник "+ version;
            Log = new UI.Log.Logger(LBConsole);
            Log.Message(" - текущее время");
            Filter = LDZ_Code.AO_Devices.Find_and_connect_AnyFilter();
            if (Filter.FilterType == FilterTypes.Emulator) { Log.Message("ПРЕДУПРЕЖДЕНИЕ: Не обнаружены подключенные АО фильтры. Фильтр будет эмулирован."); }
            else { Log.Message("Обнаружен подключенный АО фильтр. Тип фильтра: " + Filter.FilterType.ToString()); }

            ChB_Power.Enabled = false;
            GB_AllAOFControls.Enabled = false;
            TSMI_CreateCurve.Enabled = false;

            ReadData(); 
            //tests();
        }
        private void ReadData()
        {
            List<string> strings = Files.Read_txt(AO_ProgramSweepCFG_filename);
            for(int i =0;i<strings.Count;i++)
            {
                if (String.IsNullOrEmpty(strings[i])) { strings.RemoveAt(i); i--; }
            }
            AO_All_CurveSweep_Params = new float[strings.Count, 7];
            for(int i=0;i!=strings.Count;++i)
            {

                int startindex = 0;
                int finishindex = 0;
                for (int j = 0;j<7;++j)
                {                   
                    if(j==6)
                    {
                        finishindex = (strings[i].IndexOf("\t")>0 ? strings[i].IndexOf("\t") : strings[i].Length);
                        string dataval = strings[i].Substring(startindex, finishindex - startindex).Replace('.', ',');
                        AO_All_CurveSweep_Params[i, j] = (float)Convert.ToDouble(dataval);
                    }
                    else
                    {
                        finishindex = strings[i].IndexOf("\t");
                        string dataval = strings[i].Substring(startindex, finishindex - startindex).Replace('.',',');
                        AO_All_CurveSweep_Params[i, j] = (float)Convert.ToDouble(dataval);
                        startindex = 0;
                        strings[i] = strings[i].Substring(finishindex+1);
                    }
                }
            }
            Log.Message(AO_All_CurveSweep_Params.GetLength(0).ToString());
        }
        private void SaveData()
        {
            List<string> result = new List<string>();
            int i_max = AO_All_CurveSweep_Params.GetLength(0);
            string datastring = null;
            for(int i=0;i<i_max;i++)
            {
                datastring = null;
                for(int j = 0;j < 6;j++)
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
                }
                catch (Exception exc)
                {
                    Log.Message("Произошла ошибка при прочтении .dev файла");
                    Log.Error("ORIGINAL:" + exc.Message);
                    return;
                }
            else return;

            AO_FreqDeviation_Max_byTime = AO_TimeDeviation / (1000.0f/Filter.AO_ExchangeRate_Min);
            InitializeComponents_byVariables();
        }

        private void ChBAutoSetWL_CheckedChanged(object sender, EventArgs e)
        {
            AO_WL_Controlled_byslider = ChB_AutoSetWL.Checked;
        }

        private void BSetWL_Click(object sender, EventArgs e)
        {
            float data_CurrentWL = (float)(TrB_CurrentWL.Value / AO_WL_precision);
            NUD_CurWL.Value = (decimal)(data_CurrentWL);

            if (AO_Sweep_Needed)
            {
                try
                {
                    ReSweep(data_CurrentWL);
                }
                catch (Exception exc)
                {
                    Log.Error(exc.Message);
                }
            }
            else
            {
                try
                {
                    if (Filter.is_inSweepMode) Filter.Set_Sweep_off();
                    System.Threading.Thread.Sleep(50);
                    var state = Filter.Set_Wl(data_CurrentWL);
                    if (state != 0) throw new Exception(Filter.Implement_Error(state));
                    Log.Message("Перестройка на длину волны " + data_CurrentWL.ToString() + " нм прошла успешно!");
                }
                catch (Exception exc)
                {
                    Log.Error(exc.Message);
                }
            }
        }

        private void TrB_CurrentWL_Scroll(object sender, EventArgs e)
        {
            float data_CurrentWL = (float)(TrB_CurrentWL.Value / AO_WL_precision);
            NUD_CurWL.Value = (decimal)(data_CurrentWL); //вот оно. Вызывает установление ДВ
        }
        private void CurrentWL_Change()
        {
            float data_CurrentWL = (float)(TrB_CurrentWL.Value / AO_WL_precision);
            if (AO_WL_Controlled_byslider)
            {
                if (AO_Sweep_Needed)
                {
                   /* if (!timer_for_sweep.IsRunning || timer_for_sweep.ElapsedMilliseconds > 500)
                    {
                        timer_for_sweep.Restart();
                        ReSweep(data_CurrentWL);
                    }*/
                }
                else
                {
                    try
                    {
                        var state = Filter.Set_Wl(data_CurrentWL);
                        if (state != 0) throw new Exception(Filter.Implement_Error(state));
                        Log.Message("Перестройка на длину волны " + data_CurrentWL.ToString() + " нм прошла успешно!");
                    }
                    catch (Exception exc)
                    {
                        Log.Error(exc.Message);
                    }
                }
            }
        }

        private void ChB_Power_CheckedChanged(object sender, EventArgs e)
        {
            bool newAOFPowerStatus = ChB_Power.Checked;
            if(newAOFPowerStatus)
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
                catch(Exception exc)
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
            TrB_CurrentWL.Value = (int)(NUD_CurWL.Value*(decimal)AO_WL_precision);
            CurrentWL_Change();
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
            RB_Sweep_SpeciallMode.Enabled = AO_Sweep_Needed && AO_Sweep_CurveTuning_isEnabled;

        }

        private void NUD_TimeFdev_ValueChanged(object sender, EventArgs e)
        {
            AO_TimeDeviation = (double)NUD_TimeFdev.Value;
            AO_FreqDeviation_Max_byTime = AO_TimeDeviation / (1000.0f / Filter.AO_ExchangeRate_Min);
            NUD_FreqDeviation.Maximum = (decimal)
                (AO_FreqDeviation_Max_byTime < Filter.AO_FreqDeviation_Max ? AO_FreqDeviation_Max_byTime : Filter.AO_FreqDeviation_Max);
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
            try { SaveData(); }
            catch { }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            float realval = ((float)trackBar1.Value/1000.0f);
            string message = Filter.Implement_Error(Filter.Set_Hz(realval));
            Log.Message(message+" "+ realval.ToString() );
        }

        private void TSMI_CreateCurve_Click(object sender, EventArgs e)
        {
            W_AO_SweepTuneCurve Window = new W_AO_SweepTuneCurve(AO_All_CurveSweep_Params, Filter, AO_Sweep_CurveTuning_isEnabled,
            (Action<float[,],bool>)delegate(float[,] Mass_from_window, bool IsCurveEnabled)
            {
                AO_All_CurveSweep_Params = new float[Mass_from_window.GetLength(0), Mass_from_window.GetLength(1)];
                AO_All_CurveSweep_Params = Mass_from_window;
                AO_Sweep_CurveTuning_isEnabled = IsCurveEnabled;
                if (Filter.FilterType == FilterTypes.STC_Filter) (Filter as STC_Filter).Create_byteMass_forProgramm_mode(AO_All_CurveSweep_Params);
            },
            (Action<W_AO_SweepTuneCurve>)delegate(W_AO_SweepTuneCurve ChildWindow)
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
            TLP_Sweep_ProgramMode.Enabled = AO_Sweep_Needed && AO_Sweep_CurveTuning_isEnabled && RB_Sweep_SpeciallMode.Checked;

            TLP_WLSlidingControls.Enabled = RB_Sweep_EasyMode.Checked && !RB_Sweep_SpeciallMode.Checked;
            TLP_SetControls.Enabled = RB_Sweep_EasyMode.Checked && !RB_Sweep_SpeciallMode.Checked;
        }

        private void ChB_ProgrammSweep_toogler_CheckedChanged(object sender, EventArgs e)
        {
            if (AO_Sweep_CurveTuning_isEnabled)
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
            }
        }

        private void BGW_Sweep_Curve_DoWork(object sender, DoWorkEventArgs e)
        {
            Sweep_Especiall(sender as BackgroundWorker,e);
        }
        private void Sweep_Especiall(BackgroundWorker pBGW = null,DoWorkEventArgs pe=null)
        {
            int i_max = AO_All_CurveSweep_Params.GetLength(0);
            float[,] Mass_of_params = new float[i_max, 7];
            int i = 0;
            for(i=0;i< i_max;i++)
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
                catch(Exception exc )
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
    }
}
