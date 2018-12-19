﻿using System;
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
        float[,] AO_All_CurveSweep_Params = new float[0, 0];
        bool AO_Sweep_CurveTuning_isEnabled = false;
        bool AO_Sweep_CurveTuning_inProgress = false;
        bool AO_Sweep_CurveTuning_StopFlag = false;

        List<object> ParamList_bkp = new List<object>();
        List<object> ParamList_final = new List<object>();

        UI.Log.Logger Log;
        AO_Filter Filter = null;
        System.Diagnostics.Stopwatch timer_for_sweep = new System.Diagnostics.Stopwatch();

        
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

            AO_FreqDeviation_Max_byTime = Filter.AO_FreqTuneSpeed_Max * AO_TimeDeviation;
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

            RB_Sweep_EasyMode.Checked = !AO_Sweep_CurveTuning_isEnabled;
            RB_Sweep_SpeciallMode.Checked = AO_Sweep_CurveTuning_isEnabled;
            TLP_Sweep_EasyMode.Enabled = AO_Sweep_Needed && !AO_Sweep_CurveTuning_isEnabled;
            TLP_Sweep_ProgramMode.Enabled = AO_Sweep_Needed && AO_Sweep_CurveTuning_isEnabled;


        }

        private void NUD_TimeFdev_ValueChanged(object sender, EventArgs e)
        {
            AO_TimeDeviation = (double)NUD_TimeFdev.Value;
            AO_FreqDeviation_Max_byTime = Filter.AO_FreqTuneSpeed_Max * AO_TimeDeviation / 2.0;
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

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RB_Sweep_EasyMode_CheckedChanged(object sender, EventArgs e)
        {
            AO_Sweep_CurveTuning_isEnabled = false;
            TLP_Sweep_EasyMode.Enabled = AO_Sweep_Needed && !AO_Sweep_CurveTuning_isEnabled;
            TLP_Sweep_ProgramMode.Enabled = AO_Sweep_Needed && AO_Sweep_CurveTuning_isEnabled;
            TLP_WLSlidingControls.Enabled = !AO_Sweep_CurveTuning_isEnabled;
            TLP_SetControls.Enabled = !AO_Sweep_CurveTuning_isEnabled;
        }

        private void RB_Sweep_SpeciallMode_CheckedChanged(object sender, EventArgs e)
        {
            AO_Sweep_CurveTuning_isEnabled = true;
            TLP_Sweep_EasyMode.Enabled = AO_Sweep_Needed && !AO_Sweep_CurveTuning_isEnabled;
            TLP_Sweep_ProgramMode.Enabled = AO_Sweep_Needed && AO_Sweep_CurveTuning_isEnabled;
            TLP_WLSlidingControls.Enabled = !AO_Sweep_CurveTuning_isEnabled;
            TLP_SetControls.Enabled = !AO_Sweep_CurveTuning_isEnabled;

        }

        private void ChB_ProgrammSweep_toogler_CheckedChanged(object sender, EventArgs e)
        {
            if (AO_Sweep_CurveTuning_isEnabled)
            {
                if(AO_Sweep_CurveTuning_inProgress)
                {
                    AO_Sweep_CurveTuning_StopFlag = true;                   
                }
                else
                {
                    AO_Sweep_CurveTuning_StopFlag = false;
                    AO_Sweep_CurveTuning_inProgress = true;
                    BGW_Sweep_Curve.RunWorkerAsync();
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
                PointF data_for_sweep = Filter.Sweep_Recalculate_borders(AO_All_CurveSweep_Params[i, 2], AO_All_CurveSweep_Params[i, 3]);
                Mass_of_params[i, 1] = data_for_sweep.X;//Частота Синтезатора
                Mass_of_params[i, 2] = data_for_sweep.Y;//пересчитанная девиация                 
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
                    Log.Message(String.Format("Перестройка прервана из-за внутренней ошибки."));
                    AO_Sweep_CurveTuning_StopFlag = false;
                    AO_Sweep_CurveTuning_inProgress = false;
                    if (Filter.is_inSweepMode) Filter.Set_Sweep_off();
                }
            }
      /*      for (int i = 1; i <= 10; i++)
            {
                if (pBGW.CancellationPending == true)
                {
                    pe.Cancel = true;
                    break;
                }
                else
                {
                    // Perform a time consuming operation and report progress.
                    System.Threading.Thread.Sleep(100);
                    pBGW.ReportProgress(i * 10);
                }
            }*/
        }
        private void BGW_Sweep_Curve_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Log.Message(String.Format("Перестройка прервана пользователем."));
            AO_Sweep_CurveTuning_StopFlag = false;
            AO_Sweep_CurveTuning_inProgress = false;
        }
    }
}
