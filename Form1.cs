using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LDZ_Code;
using static LDZ_Code.ServiceFunctions;

namespace AOF_Controller
{
    public partial class Form1 : Form
    {
        // Все для работы АО
        bool AO_IsEmulator = false;
        bool AO_isAO_Found = false;
        bool AO_Dev_file_loaded = false;

        bool AO_WL_Controlled_byslider = false;

        private bool sAO_TurnedON = false;
        bool AO_TurnedON
        {
            get
            {
                return sAO_TurnedON;
            }
            set
            {
                sAO_TurnedON = value;
                GB_AllAOFControls.Enabled = sAO_TurnedON;
            }
        }

        string AO_DEV_required = null;
        string AO_DEV_loaded = null;
        string AO_DEV_loaded_fullPath = null;

        float AO_CurrentWL = 0;
        float AO_MaxWL = 0;
        float AO_MinWL = 0;

        //Все для sweep
        bool AO_Sweep_On = false;
        double AO_FreqDeviation_Max_byTime = 1;
        double AO_FreqDeviation_Max_byRange = 0;
        double AO_FreqDeviation = 0;
        double AO_FreqDeviation_Min = 0; // [МГц]
        double AO_TimeDeviation_Max = 10000;    // [мс]
        double AO_TimeDeviation = 1;
        double AO_TimeDeviation_Min = 1;   // [мс]
        double AO_FreqTuneSpeed = 1;        // [МГц / сек] 

        float[] AO_Wls;
        float[] AO_HZs;
        float[] AO_Coefs;

        List<object> ParamList_bkp = new List<object>();
        List<object> ParamList_final = new List<object>();

        UI.Log.Logger Log;

        System.Diagnostics.Stopwatch timer_for_sweep = new System.Diagnostics.Stopwatch();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Перестраиваемый источник v1.2b";
            Log = new UI.Log.Logger(LBConsole);
            Log.Message(" - текущее время");
            AO_TurnedON = false;
            ChB_Power.Enabled = false;
        }

        private void BDevOpen_Click(object sender, EventArgs e)
        {
            var DR = OpenDevSearcher(ref AO_DEV_loaded, ref AO_DEV_loaded_fullPath);

            if (DR == DialogResult.OK)
                try
                {
                    LDZ_Code.AO.AOM_ReadDev_byHands(AO_DEV_loaded_fullPath, ref AO_Wls, ref AO_HZs, ref AO_Coefs,
                    ref AO_MinWL, ref AO_MaxWL);
                    Log.Message(AO_DEV_loaded_fullPath + " файл считан успешно!");
                    AO_Dev_file_loaded = (DR == DialogResult.OK);
                }
                catch(Exception exc)
                {
                    Log.Message("Произошла ошибка при прочтении .dev файла");
                    Log.Error("ORIGINAL:" + exc.Message);
                    AO_Dev_file_loaded = false;
                    return;
                }

            if (AO_Dev_file_loaded)
            {
                if (AO_CurrentWL > AO_MaxWL) AO_CurrentWL = AO_MaxWL;
                if (AO_CurrentWL < AO_MinWL) AO_CurrentWL = AO_MinWL;
                AO_FreqDeviation_Max_byRange = AO_HZs[0] - AO_HZs.Last();
                AO_FreqDeviation_Max_byTime = AO_TimeDeviation * AO_FreqTuneSpeed / 2;
               
                if (AO_IsEmulator)
                {
                    InitializeComponents_byVariables();
                    GB_AllAOFControls.Enabled = true;
                    ChB_Power.Enabled = false;
                }
                else
                {
                   int NumberofNewDevs = LDZ_Code.AO.ListUnopenDevices();
                    if (NumberofNewDevs == 0)
                    {
                        GB_AllAOFControls.Enabled = false;
                        ChB_Power.Enabled = false;
                    }
                    else
                    {
                        ChB_Power.Enabled = true;
                    }
                }
            }
        }

        private void ChBActivateAOFSimulator_CheckedChanged(object sender, EventArgs e)
        {
            AO_IsEmulator = ChB_ActivateAOFSimulator.Checked;
            GB_AllAOFControls.Enabled = AO_IsEmulator && AO_Dev_file_loaded;
            if(AO_IsEmulator)
                ChB_Power.Enabled = false;
            else
                ChB_Power.Enabled = AO_isAO_Found;
        }

        private void ChBAutoSetWL_CheckedChanged(object sender, EventArgs e)
        {
            AO_WL_Controlled_byslider = ChB_AutoSetWL.Checked;
        }

        private void BSetWL_Click(object sender, EventArgs e)
        {
            AO_CurrentWL = TrB_CurrentWL.Value;
            NUD_CurWL.Value = (int)AO_CurrentWL;
            if (AO_Sweep_On)
            {
                LDZ_Code.AO.Sweep_Alternative_off();
                var HZ_toset = LDZ_Code.AO.Find_freq_mass_by_Wls(AO_Wls, AO_HZs, new List<float>() { AO_CurrentWL });
                PointF data_for_sweep = (LDZ_Code.AO.Find_freq_borders_mass(HZ_toset, (float)AO_FreqDeviation, AO_HZs.Last(), AO_HZs[0]))[0];
                LDZ_Code.AO.Sweep_Alternative_on_step1mhz(data_for_sweep.X, data_for_sweep.Y, AO_TimeDeviation, true);

                Log.Message(String.Format("ЛЧМ Параметры: ДВ:{0} / Частота:{1} / Девиация частоты:{2}", AO_CurrentWL, HZ_toset[0], AO_FreqDeviation));
                Log.Message(String.Format("Доступные для установки ЛЧМ параметры:  ДВ: {0} / Частота:{1} / Девиация частоты: {2} ",
                    AO_CurrentWL, HZ_toset[0], data_for_sweep.Y / 2));
                Log.Message(String.Format("Пересчет:  {0}+{1}", data_for_sweep.X, data_for_sweep.Y));
            }
            else
            {
                string mes = LDZ_Code.AO.Set_new_freq_byWL(TrB_CurrentWL.Value, AO_TurnedON, AO_Wls, AO_HZs);
                Log.Message(mes);
            }
        }

        private void TrB_CurrentWL_Scroll(object sender, EventArgs e)
        {
            if (AO_WL_Controlled_byslider)
            {
                AO_CurrentWL = TrB_CurrentWL.Value;
                NUD_CurWL.Value = (int)AO_CurrentWL;

                if (AO_Sweep_On)
                {
                    if (!timer_for_sweep.IsRunning || timer_for_sweep.ElapsedMilliseconds > 500)
                    {
                        timer_for_sweep.Restart();
                        if (!AO_IsEmulator) LDZ_Code.AO.Sweep_Alternative_off();
                        var HZ_toset = LDZ_Code.AO.Find_freq_mass_by_Wls(AO_Wls, AO_HZs, new List<float>() { AO_CurrentWL });
                        PointF data_for_sweep = (LDZ_Code.AO.Find_freq_borders_mass(HZ_toset, (float)AO_FreqDeviation, AO_HZs.Last(), AO_HZs[0]))[0];

                        if (!AO_IsEmulator) LDZ_Code.AO.Sweep_Alternative_on_step1mhz(data_for_sweep.X, data_for_sweep.Y, AO_TimeDeviation, true);

                        Log.Message(String.Format("ЛЧМ Параметры: ДВ:{0} / Частота:{1} / Девиация частоты:{2}", AO_CurrentWL, HZ_toset[0], AO_FreqDeviation));
                        Log.Message(String.Format("Доступные для установки ЛЧМ параметры:  ДВ: {0} / Частота:{1} / Девиация частоты: {2} ",
                            AO_CurrentWL, HZ_toset[0], data_for_sweep.Y / 2));
                        Log.Message(String.Format("Пересчет:  {0}+{1}", data_for_sweep.X, data_for_sweep.Y));
                    }
                }
                else
                {
                    if (!AO_IsEmulator) LDZ_Code.AO.Sweep_Alternative_off();
                    if (!AO_IsEmulator)
                    {
                        string mes = LDZ_Code.AO.Set_new_freq_byWL(TrB_CurrentWL.Value, AO_TurnedON, AO_Wls, AO_HZs);
                        Log.Message(mes);
                    }
                    else
                    {
                        Log.Message("Перестройска на длину волны " + TrB_CurrentWL.Value.ToString() + " прошла успешно!");
                    }
                }
            }
            // if (AOFWind_handling_byslider) AOFWind_Owner.SetValue_onWLTrackBar_Manually((int)AOFWind_CurrentL);
        }


        private void ChB_Power_CheckedChanged(object sender, EventArgs e)
        {
            AO_TurnedON = ChB_Power.Checked;
            if(AO_TurnedON)
            {
                try
                {
                    AO_isAO_Found = Activate_alltheAOF();

                    Log.Message("Активация АОФ успешна!");
                }
                catch
                {

                    Log.Message("Возникла проблема при активации АОФ");
                }
                if (AO_isAO_Found)
                {
                    ChB_Power.Enabled = true;
                    try
                    {
                        InitializeComponents_byVariables();
                        Log.Message("Инициализация контроллов прошла успешно!");
                    }
                    catch (Exception exc)
                    {

                        Log.Message("Ошибка при инициализации элементов управления");
                        Log.Error("ORIGINAL: " + exc.Message);

                    }

                }
            }
            else
            {
                GB_AllAOFControls.Enabled = false;
                This_onQuit_AOM_OFF();
            }
        }

        private void NUD_CurWL_ValueChanged(object sender, EventArgs e)
        {
            AO_CurrentWL = TrB_CurrentWL.Value = (int)NUD_CurWL.Value;
           // if (AOFWind_handling_byslider) AOFWind_Owner.SetValue_onWLTrackBar_Manually((int)AOFWind_CurrentL);
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
            AO_Sweep_On = ChB_SweepEnabled.Checked;
            Pan_SweepControls.Enabled = AO_Sweep_On;
        }

        private void NUD_TimeFdev_ValueChanged(object sender, EventArgs e)
        {
            AO_TimeDeviation = (double)NUD_TimeFdev.Value;
            AO_FreqDeviation_Max_byTime = AO_FreqTuneSpeed * AO_TimeDeviation / 2.0;
            NUD_FreqDeviation.Maximum = (decimal)
                (AO_FreqDeviation_Max_byTime < AO_FreqDeviation_Max_byRange ? AO_FreqDeviation_Max_byTime : AO_FreqDeviation_Max_byRange);
        }

        private void NUD_FreqDeviation_ValueChanged(object sender, EventArgs e)
        {
            AO_FreqDeviation = (double)NUD_FreqDeviation.Value;
        }

        private void B_Quit_Click(object sender, EventArgs e)
        {
            This_onQuit_AOM_OFF();
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            This_onQuit_AOM_OFF();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            float realval = ((float)trackBar1.Value/1000.0f);
            string message = LDZ_Code.AO.Set_new_freq_byFreq(realval, true);
            Log.Message(message);
        }
    }
}
