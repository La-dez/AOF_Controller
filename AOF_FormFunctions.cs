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
        private void tests()
        {
            
            Filter.Read_dev_file("ampl_avm1-011-3.dev");
            Filter.PowerOn();
            Filter.Set_Wl(Filter.WL_Max);
            Filter.Set_Wl((Filter.WL_Max + Filter.WL_Min) / 2);
            Filter.Set_Wl(Filter.WL_Min);
            Filter.Set_Hz((Filter.HZ_Min + Filter.HZ_Max) / 2);
            float delta = 5;
            Filter.Set_Sweep_on((Filter.HZ_Max + Filter.HZ_Min) / 2 - delta, 2 * delta, 1, true);
            System.Threading.Thread.Sleep(2000);
            Filter.Set_Sweep_off();
            //  Filter.PowerOff();
        }
        private void InitializeComponents_byVariables()
        {
            try
            {
                ChB_Power.Checked = false;

                ChB_AutoSetWL.Checked = AO_WL_Controlled_byslider;

                L_RequiredDevName.Text = Filter.Ask_required_dev_file();
                L_RealDevName.Text = Filter.Ask_loaded_dev_file();
                float data_CurWL = (Filter.WL_Max + Filter.WL_Min) / 2;
                Filter.Set_Wl(data_CurWL);

                NUD_CurWL.Minimum = (decimal)Filter.WL_Min;
                TrB_CurrentWL.Minimum = (int)(Filter.WL_Min * AO_WL_precision);
                NUD_CurWL.Maximum = (decimal)Filter.WL_Max;
                TrB_CurrentWL.Maximum = (int)(Filter.WL_Max * AO_WL_precision);
                NUD_CurWL.Value = (decimal)data_CurWL;
                TrB_CurrentWL.Value = (int)(data_CurWL * AO_WL_precision);

                ChB_SweepEnabled.Checked = Filter.is_inSweepMode;
                Pan_SweepControls.Enabled = Filter.is_inSweepMode;

                var AOFWind_FreqDeviation_bkp = AO_FreqDeviation; // ибо AO_FreqDeviation изменяется, если изменяются максимумы
                NUD_FreqDeviation.Minimum = (decimal)Filter.AO_FreqDeviation_Min;
                NUD_FreqDeviation.Maximum = (decimal)
                    (AO_FreqDeviation_Max_byTime < Filter.AO_FreqDeviation_Max ? AO_FreqDeviation_Max_byTime : Filter.AO_FreqDeviation_Max);

                var AOFWind_TimeDeviation_bkp = AO_TimeDeviation; // ибо AOFWind_TimeDeviation изменяется, если изменяются максимумы
                NUD_TimeFdev.Minimum = (decimal)Filter.AO_TimeDeviation_Min;
                NUD_TimeFdev.Maximum = (decimal)Filter.AO_TimeDeviation_Max;

                NUD_TimeFdev.Value = (decimal)AOFWind_TimeDeviation_bkp;
                NUD_FreqDeviation.Value = (decimal)AOFWind_FreqDeviation_bkp > NUD_FreqDeviation.Maximum ? NUD_FreqDeviation.Maximum : (decimal)AO_FreqDeviation;

                ChB_Power.Enabled = true;
                TSMI_CreateCurve.Enabled = true;

                Log.Message("Инициализация элементов управления прошла успешно!");
            }
            catch(Exception exc)
            {
                Log.Error("Инициализация элементов управления завершилась с ошибкой.");
            }
        }

        private void SetWL_everywhere(int pwl)
        {
            NUD_CurWL.Value = pwl;
            TrB_CurrentWL.Value = pwl;
        }
        private void ReSweep(float p_data_CurrentWL)
        {
            Filter.Set_Sweep_off();
            float HZ_toset = Filter.Get_HZ_via_WL(p_data_CurrentWL);
            System.Drawing.PointF data_for_sweep = Filter.Sweep_Recalculate_borders(HZ_toset, (float)AO_FreqDeviation);

            Log.Message(String.Format("ЛЧМ Параметры: ДВ:{0} / Частота:{1} / Девиация частоты:{2}", p_data_CurrentWL, HZ_toset, AO_FreqDeviation));
            Log.Message(String.Format("Доступные для установки ЛЧМ параметры:  ДВ: {0} / Частота:{1} / Девиация частоты: {2} ",
                p_data_CurrentWL, HZ_toset, data_for_sweep.Y / 2));
            Log.Message(String.Format("Пересчет:  {0}+{1}", data_for_sweep.X, data_for_sweep.Y));

            

            var state = Filter.Set_Sweep_on(data_for_sweep.X, data_for_sweep.Y, AO_TimeDeviation, true);
            if (state != 0) throw new Exception(Filter.Implement_Error(state));
            Log.Message("Режим ЛЧМ около длины волны " + p_data_CurrentWL.ToString() + " нм запущен!");
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
