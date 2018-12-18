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
        double AO_FreqDeviation = 1;
        double AO_TimeDeviation = 1;
        bool AO_Sweep_Needed = false;

        List<object> ParamList_bkp = new List<object>();
        List<object> ParamList_final = new List<object>();

        UI.Log.Logger Log;
        AO_Filter Filter = null;
        System.Diagnostics.Stopwatch timer_for_sweep = new System.Diagnostics.Stopwatch();

        float[,] AO_All_CurveSweep_Params = new float[0,0];
        bool AO_Sweep_CurveTuning_isEnabled = false;
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

            //tests();
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

            AO_FreqDeviation_Max_byTime = Filter.AO_FreqTuneSpeed * AO_TimeDeviation;
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
                    if (!timer_for_sweep.IsRunning || timer_for_sweep.ElapsedMilliseconds > 500)
                    {
                        timer_for_sweep.Restart();
                        ReSweep(data_CurrentWL);
                    }
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
        }

        private void NUD_TimeFdev_ValueChanged(object sender, EventArgs e)
        {
            AO_TimeDeviation = (double)NUD_TimeFdev.Value;
            AO_FreqDeviation_Max_byTime = Filter.AO_FreqTuneSpeed * AO_TimeDeviation / 2.0;
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

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            float realval = ((float)trackBar1.Value/1000.0f);
           /* string message = LDZ_Code.AO.Set_new_freq_byFreq(realval, true);
            Log.Message(message);*/
        }

        private void TSMI_CreateCurve_Click(object sender, EventArgs e)
        {

            W_AO_SweepTuneCurve Window = new W_AO_SweepTuneCurve(AO_All_CurveSweep_Params, Filter, AO_Sweep_CurveTuning_isEnabled,
            (Action<float[,],bool>)delegate(float[,] Mass_from_window, bool IsCurveEnabled)
            {
                AO_All_CurveSweep_Params = new float[Mass_from_window.GetLength(0), Mass_from_window.GetLength(1)];
                AO_All_CurveSweep_Params = Mass_from_window;
                AO_Sweep_CurveTuning_isEnabled = IsCurveEnabled;
            },
            (Action<W_AO_SweepTuneCurve>)delegate(W_AO_SweepTuneCurve ChildWindow)
            {
                ChildWindow.Close();
            }
            );
            Window.ShowDialog();
        }
    }
}
