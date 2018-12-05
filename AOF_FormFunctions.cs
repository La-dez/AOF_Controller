using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using LDZ_Code;
using System.Threading;
using static LDZ_Code.ServiceFunctions;

namespace AOF_Controller
{
    public partial class Form1
    {        
 
        private void InitializeComponents_byVariables()
        {
            ChB_ActivateAOFSimulator.Checked = AO_IsEmulator;
            ChB_Power.Checked = AO_TurnedON;
            ChB_AutoSetWL.Checked = AO_WL_Controlled_byslider;

            L_RequiredDevName.Text = /*AO_DEV_required*/AO_DEV_loaded.ToLower();
            L_RealDevName.Text = AO_DEV_loaded;

            float data_curL = AO_CurrentWL; // В противном случае значение заменяется минимальной длиной волны
            
            NUD_CurWL.Minimum  = TrB_CurrentWL.Minimum = (int)AO_MinWL;
            NUD_CurWL.Maximum  = TrB_CurrentWL.Maximum  = (int)AO_MaxWL;

            AO_CurrentWL = data_curL;
            NUD_CurWL.Value = TrB_CurrentWL.Value = (int)AO_CurrentWL;


            ChB_SweepEnabled.Checked = AO_Sweep_On;
            Pan_SweepControls.Enabled = AO_Sweep_On;

            var AOFWind_FreqDeviation_bkp = AO_FreqDeviation;
            NUD_FreqDeviation.Minimum = (decimal)AO_FreqDeviation_Min;
            NUD_FreqDeviation.Maximum = (decimal)
                (AO_FreqDeviation_Max_byTime < AO_FreqDeviation_Max_byRange ? AO_FreqDeviation_Max_byTime : AO_FreqDeviation_Max_byRange);

            var AOFWind_TimeDeviation_bkp = AO_TimeDeviation; // ибо AOFWind_TimeDeviation изменяется, если изменяются максимумы
            NUD_TimeFdev.Minimum = (decimal)AO_TimeDeviation_Min;
            NUD_TimeFdev.Maximum = (decimal)AO_TimeDeviation_Max;

            NUD_TimeFdev.Value = (decimal)AOFWind_TimeDeviation_bkp;
            NUD_FreqDeviation.Value = (decimal)AOFWind_FreqDeviation_bkp > NUD_FreqDeviation.Maximum ? NUD_FreqDeviation.Maximum : (decimal)AO_FreqDeviation;
        }

        private void This_onQuit_AOM_OFF()
        {
            if (AO_TurnedON || LDZ_Code.AO.m_hPort != 0)
            {
                Thread.Sleep(100);
                LDZ_Code.AO.Sweep_Alternative_off();
                Thread.Sleep(100);
                LDZ_Code.AO.AOM_PowerOff_new2();
                LDZ_Code.AO.Deinit_Device();
                Thread.Sleep(100);
                LDZ_Code.AO.m_hPort = 0;
            }
        }
        private void SetWL_everywhere(int pwl)
        {
            NUD_CurWL.Value = pwl;
            TrB_CurrentWL.Value = pwl;
        }
        private bool Activate_alltheAOF()
        {
            string AO_Dev_forLoad = null;
            bool AOF_Loaded_without_fails;
            if (AO_IsEmulator) AO_Dev_forLoad = "avm1-011.dev";
            else
            {
                if (!String.IsNullOrEmpty(AO_DEV_loaded)) AO_Dev_forLoad = AO_DEV_loaded;
                else { Log.Message("Не выбран конфигурационный .dev файл!"); return false; }
            }
            
            float AO_StartWL = 0;
            float AO_EndWL = 0;

            AOF_Loaded_without_fails = ServiceFunctions.AO.ConnectAOF(AO_Dev_forLoad, ref TrB_CurrentWL, ref NUD_CurWL,
                AO_IsEmulator, new UI.Log.Logger.Log_del(Log.Message), new UI.Log.Logger.Log_del(Log.Error),
                ref AO_MinWL, ref AO_MaxWL, ref AO_StartWL, ref AO_EndWL, ref AO_CurrentWL,
                ref AO_DEV_required);

            if (!AOF_Loaded_without_fails)
            {
                //TLP_SaveGroup_C2.Enabled = false;
                Log.Message("ПРЕДУПРЕЖДЕНИЕ: перестройка АОФ может привести к необходимости перезапуска программы, " +
                    "так как библиотека контроллера была загружена некорректно");
            }
            return AOF_Loaded_without_fails;

        }
       
        private DialogResult OpenDevSearcher(ref string CfgToLoad, ref string CfgToLoad_fullPath)
        {

            OpenFileDialog OPF = new OpenFileDialog();
            OPF.InitialDirectory = Application.StartupPath;
            OPF.Filter = "DEV config files (*.dev)|*.dev|All files (*.*)|*.*";
            OPF.FilterIndex = 0;
            OPF.RestoreDirectory = true;

            if (OPF.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    int k = 1 + OPF.FileName.LastIndexOf('\\');
                    CfgToLoad_fullPath = OPF.FileName;
                    CfgToLoad = OPF.FileName.Substring(k, OPF.FileName.Length - k);
                }
                catch (Exception ex)
                {
                    Log.Error("Не удалось считать файл с диска. Оригинал ошибки: " + ex.Message);
                }
                return DialogResult.OK;
            }
            else return DialogResult.Cancel;
        }


    }
}
