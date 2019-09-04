using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static LDZ_Code.ServiceFunctions;

namespace AOF_Controller
{
    public partial class W_AO_SweepTuneCurve : Form
    {

        delegate void SaveToMain_del(float[,] Mass_from_window, bool IsCurveEnabled);
        delegate void QuitToMain_del(W_AO_SweepTuneCurve childForm);

        float W_WL_Max = 1000;
        float W_WL_Min = 1;
        float W_AO_TimeDeviation_Min = 1;
        float W_AO_TimeDeviation_Max = 2500;
        float W_AO_FreqDeviation_Min = 0;
        float W_AO_FreqDeviation_Max_byRange = 0.5f;

        float[,] Mass_of_vals = new float[0, 0];
        bool W_isCurveEnabled = false;
        int Num_of_Vars = 7;

        AO_Lib.AO_Devices.AO_Filter W_Filter;
       // SaveToMain_del SaveToMain;
        Action<float[,], bool> SaveToMain;
        Action<W_AO_SweepTuneCurve> QuitToMain;

        public W_AO_SweepTuneCurve(float[,] loaded_mass, AO_Lib.AO_Devices.AO_Filter pFilter,bool pAO_Sweep_CurveTuning_isEnabled,
            Action<float[,], bool> DelForSave, Action<W_AO_SweepTuneCurve> DelForQuit)
        {
            InitializeComponent();
            Mass_of_vals = loaded_mass;
            W_Filter = pFilter;
            {
                W_WL_Max = W_Filter.WL_Max;
                W_WL_Min = W_Filter.WL_Min;
                W_AO_TimeDeviation_Min = W_Filter.AO_TimeDeviation_Min;
                W_AO_TimeDeviation_Max = W_Filter.AO_TimeDeviation_Max;
                W_AO_FreqDeviation_Min = 0;
                W_AO_FreqDeviation_Max_byRange = W_Filter.AO_FreqDeviation_Max;
            }
            W_isCurveEnabled = pAO_Sweep_CurveTuning_isEnabled;
            SaveToMain = new Action<float[,], bool>(DelForSave);
            QuitToMain = new Action<W_AO_SweepTuneCurve>(DelForQuit);
            RefreshFinalTime();
        }

        private void W_AO_SweepTuneCurve_Load(object sender, EventArgs e)
        {
            ChB_ActivateCurveTuning.Checked = W_isCurveEnabled;
            panel1.Enabled = W_isCurveEnabled;
            RecreateTable(Mass_of_vals.GetLength(0));
            NUD_NumOfIntervals.Value = Mass_of_vals.GetLength(0);

         /*   float[,] testMass = new float[1, 7] { { 1, 10000000, 0, 0, 0, 0, 0 } };
            SaveToMain(testMass, isCurveEnabled);
            testMass = new float[1, 7] { { 2, 5000000, 0, 0, 0, 0, 0 } };
            SaveToMain(testMass, isCurveEnabled);
            QuitToMain(this);*/
        }
        private void TSMI_Save_Click(object sender, EventArgs e)
        {
            SaveToMain(Mass_of_vals, W_isCurveEnabled);
        }
        private void TSMI_SaveAndQuit_Click(object sender, EventArgs e)
        {
            //Вместо этого

            QuitToMain(this);
            SaveToMain(Mass_of_vals, W_isCurveEnabled);

            //делаю вот это
           // this.Close();//Там повесил сохранение ПОКА ЧТО
        }
        private void TSMI_Quit_nosave_Click(object sender, EventArgs e)
        {
            QuitToMain(this);
        }
        private void TLP_Main_Paint(object sender, PaintEventArgs e)
        {

        }

        private void NUD_NumOfIntervals_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void NUD_WL_N_ValueChanged(object sender, EventArgs e)
        {
            string name_of_sender = (sender as NumericUpDown).Name;
            double value2write = 1000;
            int nameNumber = Convert.ToInt32(name_of_sender.Last().ToString());
            var ctrl = sender as NumericUpDown;
            string Name_NUD_WN = "NUD_WN_";
            try
            {
                var ctrl_to_change = TLP_DataTable.Controls.Find(Name_NUD_WN + nameNumber, false);
                value2write = 10000000.0 / (double)((sender as NumericUpDown).Value);
                (ctrl_to_change[0] as NumericUpDown).Value = (decimal)((int)(value2write*100))/100;

                Mass_of_vals[nameNumber, 0] = (float)ctrl.Value;
                Mass_of_vals[nameNumber, 1] = (float)value2write;
            }
            catch { }
            string Name_L_AO_Freq = "L_AOFreq_";
            try
            {
                var ctrl_to_change = TLP_DataTable.Controls.Find(Name_L_AO_Freq + nameNumber, false);
                value2write = ((float)((int)(W_Filter.Get_HZ_via_WL((float)ctrl.Value)*1000)))/1000.0f;
                (ctrl_to_change[0] as Label).Text = value2write.ToString();
                Mass_of_vals[nameNumber, 2] = (float)value2write;
            }
            catch { }

            SaveToMain(Mass_of_vals, W_isCurveEnabled);
        }

        private void NUD_WN_N_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string name_of_sender = (sender as NumericUpDown).Name;
            int nameNumber = Convert.ToInt32(name_of_sender.Last().ToString());
            string Name = "NUD_WL_";
            var ctrl_to_change = TLP_DataTable.Controls.Find(Name + nameNumber, false);

            double value2write = 10000000.0 / (double)((sender as NumericUpDown).Value);
            (ctrl_to_change[0] as NumericUpDown).Value = (decimal)(value2write);

            var ctrl = sender as NumericUpDown;
            Mass_of_vals[nameNumber, 0] = (float)value2write;
            Mass_of_vals[nameNumber, 1] = (float)ctrl.Value;
            }
            catch { }
        }

        private void NUD_dFreq_N_ValueChanged(object sender, EventArgs e)
        {
            string name_of_sender = (sender as NumericUpDown).Name;
            int nameNumber = Convert.ToInt32(name_of_sender.Last().ToString());

            var ctrl = sender as NumericUpDown;
            Mass_of_vals[nameNumber, 3] = (float)ctrl.Value;

            //Вычисление максимума и минимума девиации по времени
            float AO_FreqDeviation = Mass_of_vals[nameNumber, 3];
           // decimal preferable_Max = (decimal)((int)(AO_FreqDeviation * 2f * 1000000f / (W_Filter.AO_ProgrammMode_step * W_Filter.AO_ExchangeRate_Min)));
           // decimal preferable_Min = (decimal)((int)(AO_FreqDeviation * 2f * 1000000f / (W_Filter.AO_ProgrammMode_step * W_Filter.AO_ExchangeRate_Max))+1);

            decimal preferable_Max = 40;
            decimal preferable_Min = 5;

            var ctrl_NUD_dTime = (TLP_DataTable.Controls.Find("NUD_dTime_" + nameNumber, false))[0] as NumericUpDown;
            if ((preferable_Max == preferable_Min) || (preferable_Max < preferable_Min))
            {
                ctrl_NUD_dTime.Value = 1;
                ctrl_NUD_dTime.Minimum = 1;
                ctrl_NUD_dTime.Maximum = 1000;
            }
            else
            {
                if ((ctrl_NUD_dTime.Value > preferable_Max) && (ctrl_NUD_dTime.Maximum > preferable_Max)) { ctrl_NUD_dTime.Value = preferable_Max; }
                ctrl_NUD_dTime.Maximum = preferable_Max;

                if ((ctrl_NUD_dTime.Minimum < preferable_Min) && (ctrl_NUD_dTime.Value < preferable_Min)) ctrl_NUD_dTime.Value = preferable_Min;
                ctrl_NUD_dTime.Minimum = preferable_Min;
            }
        }

        private void NUD_dTime_N_ValueChanged(object sender, EventArgs e)
        {
            //Занесение значения в таблицу данных
             string name_of_sender = (sender as NumericUpDown).Name;
            int nameNumber = Convert.ToInt32(name_of_sender.Last().ToString());

            var ctrl = sender as NumericUpDown;
            Mass_of_vals[nameNumber, 4] = (float)ctrl.Value;
            //Изменение суммарного времени девиации
            string Name_L_SunTime = "L_SumTime_";
            try
            {
                var ctrl_to_change = TLP_DataTable.Controls.Find(Name_L_SunTime + nameNumber, false);
                float value2write = Mass_of_vals[nameNumber, 4]* Mass_of_vals[nameNumber, 5];
                (ctrl_to_change[0] as Label).Text = (((float)((int)(value2write * 100))) / 100.0f).ToString();
                Mass_of_vals[nameNumber, 6] = value2write;
                RefreshFinalTime();
            }
            catch { }

           /* //Вычисление максимума девиации по частоте
            float AO_TimeDeviation = Mass_of_vals[nameNumber, 4];
            float AO_FreqDeviation_Max_byTime = AO_TimeDeviation / (1000.0f / W_Filter.AO_ExchangeRate_Min);
            float Choosen_Max = (AO_FreqDeviation_Max_byTime < W_Filter.AO_FreqDeviation_Max ? AO_FreqDeviation_Max_byTime : W_Filter.AO_FreqDeviation_Max);
            var ctrl_NUD_dFreq = (TLP_DataTable.Controls.Find("NUD_dFreq_" + nameNumber, false))[0] as NumericUpDown;
            if (ctrl_NUD_dFreq.Maximum < (decimal)Choosen_Max) ctrl_NUD_dFreq.Maximum = (decimal)Choosen_Max;
            else
            {
                if (ctrl_NUD_dFreq.Value > (decimal)Choosen_Max)
                { ctrl_NUD_dFreq.Value = (decimal)Choosen_Max; }
                ctrl_NUD_dFreq.Maximum = (decimal)Choosen_Max;
            }*/
        }

        private void NUD_NumberOfd_N_ValueChanged(object sender, EventArgs e)
        {
            string name_of_sender = (sender as NumericUpDown).Name;
            int nameNumber = Convert.ToInt32(name_of_sender.Last().ToString());

            var ctrl = sender as NumericUpDown;
            Mass_of_vals[nameNumber, 5] = (float)ctrl.Value;

            string Name_L_SunTime = "L_SumTime_";
            try
            {
                var ctrl_to_change = TLP_DataTable.Controls.Find(Name_L_SunTime + nameNumber, false);
                float value2write = Mass_of_vals[nameNumber, 4] * Mass_of_vals[nameNumber, 5];
                (ctrl_to_change[0] as Label).Text = (((float)((int)(value2write * 100))) / 100.0f).ToString();
                Mass_of_vals[nameNumber, 6] = value2write;
                RefreshFinalTime();
            }
            catch { }
        }

        private void ChB_ActivateCurveTuning_CheckedChanged(object sender, EventArgs e)
        {
            W_isCurveEnabled = ChB_ActivateCurveTuning.Checked;
            panel1.Enabled = W_isCurveEnabled;
        }



        #region Функции
        private void RecreateTable(int number_of_Values)
        { 
          // TLP_DataTable
          // старая<новая
            float[] InitLine = new float[7] { W_WL_Min, 10000000.0f/ W_WL_Min, 0, 1, 0, 0, 0 };
                int i_max = (Mass_of_vals.GetLength(0)) < number_of_Values ? Mass_of_vals.GetLength(0): number_of_Values;
            {
                float[,] datamass = new float[i_max, Num_of_Vars];
                for (int i = 0; i < i_max; i++)
                    for (int j = 0; j < Num_of_Vars; j++)
                    {
                        datamass[i, j] = Mass_of_vals[i, j];
                    }
                Mass_of_vals = new float[number_of_Values, Num_of_Vars];
                for (int i = 0; i < number_of_Values; i++)
                {
                    if(i<i_max)
                        for (int j = 0; j < Num_of_Vars; j++)
                        {
                            Mass_of_vals[i, j] = datamass[i, j];
                        }
                    else
                        for (int j = 0; j < Num_of_Vars; j++)
                        {
                            Mass_of_vals[i, j] = InitLine[j];
                        }
                }
            }
            panel1.Controls.Remove(this.TLP_DataTable) ;
            TLP_DataTable.Controls.Clear();

            TLP_DataTable = new System.Windows.Forms.TableLayoutPanel();
           // this.TLP_DataTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            TLP_DataTable.ColumnCount = 8;
            this.TLP_DataTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.TLP_DataTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TLP_DataTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLP_DataTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLP_DataTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLP_DataTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLP_DataTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TLP_DataTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            TLP_DataTable.Dock = System.Windows.Forms.DockStyle.Top;
            TLP_DataTable.Location = new System.Drawing.Point(0, 0);
            TLP_DataTable.Margin = new System.Windows.Forms.Padding(0);
            TLP_DataTable.Name = "TLP_DataTable";
            TLP_DataTable.RowCount = number_of_Values;

            TLP_DataTable.Size = new System.Drawing.Size(747, 26 * number_of_Values);

            for (int i = 0; i < number_of_Values; i++)
            {
                TLP_DataTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                TLP_DataTable.TabIndex = 4;

                NumericUpDown NUD_NumberOfd_N;
                NumericUpDown NUD_dTime_N;
                NumericUpDown NUD_dFreq_N;
                NumericUpDown NUD_WN_N;
                Label L_SumTime_N;
                Label L_Number_N;
                Label L_AOFreq_N;
                NumericUpDown NUD_WL_N;

                NUD_NumberOfd_N = new System.Windows.Forms.NumericUpDown();
                NUD_dTime_N = new System.Windows.Forms.NumericUpDown();
                NUD_dFreq_N = new System.Windows.Forms.NumericUpDown();
                NUD_WN_N = new System.Windows.Forms.NumericUpDown();
                L_SumTime_N = new System.Windows.Forms.Label();
                L_Number_N = new System.Windows.Forms.Label();
                L_AOFreq_N = new System.Windows.Forms.Label();
                NUD_WL_N = new System.Windows.Forms.NumericUpDown();

                TLP_DataTable.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(NUD_NumberOfd_N)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(NUD_dTime_N)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(NUD_dFreq_N)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(NUD_WN_N)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(NUD_WL_N)).BeginInit();

                
                // 
                // NUD_NumberOfd_N
                // 
                NUD_NumberOfd_N.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                NUD_NumberOfd_N.Location = new System.Drawing.Point(460, 3);
                NUD_NumberOfd_N.Margin = new System.Windows.Forms.Padding(0);
                NUD_NumberOfd_N.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
                NUD_NumberOfd_N.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
                NUD_NumberOfd_N.Name = "NUD_NumberOfd_"+i.ToString();
                NUD_NumberOfd_N.Size = new System.Drawing.Size(85, 20);
                NUD_NumberOfd_N.TabIndex = 12;
                NUD_NumberOfd_N.Value = (decimal)(Mass_of_vals[i,5]);
                NUD_NumberOfd_N.ValueChanged += new System.EventHandler(NUD_NumberOfd_N_ValueChanged);
                NUD_NumberOfd_N.Enabled = false;

                // 
                // NUD_dFreq_N
                // 
                NUD_dFreq_N.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                NUD_dFreq_N.DecimalPlaces = 1;
                NUD_dFreq_N.Location = new System.Drawing.Point(280, 3);
                NUD_dFreq_N.Margin = new System.Windows.Forms.Padding(0);
                //Вычислялось вот так. Давало ограничение в зависимости от времени перестройки
                //double maxvalue = (Mass_of_vals[i, 4] / (1000.0f / W_Filter.AO_ExchangeRate_Min)) < W_Filter.AO_FreqDeviation_Max ? (Mass_of_vals[i, 4] / (1000.0f / W_Filter.AO_ExchangeRate_Min)) : W_Filter.AO_FreqDeviation_Max;
                NUD_dFreq_N.Maximum = (decimal)5;
                NUD_dFreq_N.Minimum = (decimal)W_AO_FreqDeviation_Min;
                NUD_dFreq_N.Name = "NUD_dFreq_" + i.ToString();
                NUD_dFreq_N.Size = new System.Drawing.Size(90, 20);
                NUD_dFreq_N.TabIndex = 10;
                NUD_dFreq_N.Value = (decimal)Mass_of_vals[i, 3];
                NUD_dFreq_N.ValueChanged += new System.EventHandler(NUD_dFreq_N_ValueChanged);

                //ввести максимум и минимум временного интервала (dfreq.val*2/step)/min_ex_rate = (dfreq.val*2 / 0.5)*1000/ 500 = 4мс (в случае dfreq.val = 0.5)
                //                                                                                                      / 4500 = 0.44444 ~ 0.5 (в случае dfreq.val = 0.5)
                //                                                                                                      / 500 = 60(в случае dfreq.val = 0.5)
                //                                                                                                      / 4500 = 6,6666 ~ 7 мс (в случае dfreq.val = 7.5)
                //                                                                                                      / 500 = 40(в случае dfreq.val = 0.5)
                //                                                                                                      / 4500 = 4.4444 ~ 4.5 мс (в случае dfreq.val = 5.0)

                // 
                // NUD_dTime_N
                // 
                NUD_dTime_N.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                NUD_dTime_N.Location = new System.Drawing.Point(370, 3);
                NUD_dTime_N.Margin = new System.Windows.Forms.Padding(0);
                //измененения введены исходя из ExchangeRate (min-max) и фиксированного шага.
                //decimal preferable_Max = (decimal)((int)NUD_dFreq_N.Value * 2f * 1000000f / (W_Filter.AO_ProgrammMode_step * W_Filter.AO_ExchangeRate_Min));
                // decimal preferable_Min = (decimal)(((int)NUD_dFreq_N.Value * 2f * 1000000f / (W_Filter.AO_ProgrammMode_step * W_Filter.AO_ExchangeRate_Max)) + 1);
                //Последняя модификация - 20 точек на свип (фиксировано). Шаг расфиксирован.  Минимальное время: 20*1000(мс)/4500 ~ 5мс. максимальное время 20*1000(мс)/500 ~ 40мс
                decimal preferable_Max = 40;
                decimal preferable_Min = 5;
                if ((preferable_Max == preferable_Min) || (preferable_Max < preferable_Min))
                {
                    NUD_dTime_N.Value = 1;
                    NUD_dTime_N.Minimum = 1;
                    NUD_dTime_N.Maximum = 1000;
                }
                else
                {
                    NUD_dTime_N.Maximum = preferable_Max;
                    NUD_dTime_N.Minimum = preferable_Min;
                }
                //NUD_dTime_N.Maximum = (decimal)W_AO_TimeDeviation_Max;
               // NUD_dTime_N.Minimum = (decimal)W_AO_TimeDeviation_Min;
                NUD_dTime_N.Name = "NUD_dTime_" + i.ToString();
                NUD_dTime_N.Size = new System.Drawing.Size(90, 20);
                NUD_dTime_N.TabIndex = 11;
                NUD_dTime_N.Value = (decimal)Mass_of_vals[i, 4];
                NUD_dTime_N.ValueChanged += new System.EventHandler(NUD_dTime_N_ValueChanged);
                // 
                // NUD_WL_N
                // 
                NUD_WL_N.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                NUD_WL_N.DecimalPlaces = 2;
                NUD_WL_N.Location = new System.Drawing.Point(40, 3);
                NUD_WL_N.Margin = new System.Windows.Forms.Padding(0);
                NUD_WL_N.Maximum = (decimal)W_WL_Max;
                NUD_WL_N.Minimum = (decimal)W_WL_Min;
                NUD_WL_N.Name = "NUD_WL_" + i.ToString();
                NUD_WL_N.Size = new System.Drawing.Size(50, 20);
                NUD_WL_N.TabIndex = 8;
                NUD_WL_N.Value = (decimal)Mass_of_vals[i, 0];
                NUD_WL_N.ValueChanged += new System.EventHandler(NUD_WL_N_ValueChanged);
                // 
                // NUD_WN_N
                // 
                NUD_WN_N.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                NUD_WN_N.DecimalPlaces = 2;
                NUD_WN_N.Location = new System.Drawing.Point(90, 3);
                NUD_WN_N.Margin = new System.Windows.Forms.Padding(0);
                NUD_WN_N.Maximum = (decimal)(10000000.0f / W_WL_Min);
                NUD_WN_N.Minimum = (decimal)(10000000.0f / W_WL_Max);
                NUD_WN_N.Name = "NUD_WN_" + i.ToString();
                NUD_WN_N.Size = new System.Drawing.Size(85, 20);
                NUD_WN_N.TabIndex = 9;
                NUD_WN_N.Value = (decimal)Mass_of_vals[i, 1];
                NUD_WN_N.ValueChanged += new System.EventHandler(NUD_WN_N_ValueChanged);
                // 
                // L_SumTime_N
                // 
                L_SumTime_N.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                L_SumTime_N.AutoSize = true;
                L_SumTime_N.Location = new System.Drawing.Point(548, 6);
                L_SumTime_N.Name = "L_SumTime_" + i.ToString();
                L_SumTime_N.Size = new System.Drawing.Size(196, 13);
                L_SumTime_N.TabIndex = 7;
                L_SumTime_N.Text = ((float)((int)((Mass_of_vals[i,4] * Mass_of_vals[i, 5])*100))/100.0f).ToString();
                L_SumTime_N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                // 
                // L_Number_N
                // 
                L_Number_N.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                L_Number_N.AutoSize = true;
                L_Number_N.Location = new System.Drawing.Point(3, 6);
                L_Number_N.Name = "L_Number_" + i.ToString();
                L_Number_N.Size = new System.Drawing.Size(34, 13);
                L_Number_N.TabIndex = 0;
                L_Number_N.Text = i.ToString();
                // 
                // L_AOFreq_N
                // 
                L_AOFreq_N.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                L_AOFreq_N.AutoSize = true;
                L_AOFreq_N.Location = new System.Drawing.Point(178, 6);
                L_AOFreq_N.Name = "L_AOFreq_" + i.ToString();
                L_AOFreq_N.Size = new System.Drawing.Size(99, 13);
                L_AOFreq_N.TabIndex = 3;
                L_AOFreq_N.Text = W_Filter.Get_HZ_via_WL(Mass_of_vals[i, 0]).ToString();
                L_AOFreq_N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
               


                TLP_DataTable.ResumeLayout(false);
                TLP_DataTable.PerformLayout();   
                
                TLP_DataTable.Controls.Add(L_Number_N, 0, i);
                TLP_DataTable.Controls.Add(NUD_WL_N, 1, i);
                TLP_DataTable.Controls.Add(NUD_WN_N, 2, i);
                TLP_DataTable.Controls.Add(L_AOFreq_N, 3, i);
                TLP_DataTable.Controls.Add(NUD_dFreq_N, 4, i);
                TLP_DataTable.Controls.Add(NUD_dTime_N, 5, i);
                TLP_DataTable.Controls.Add(NUD_NumberOfd_N, 6, i);
                TLP_DataTable.Controls.Add(L_SumTime_N, 7, i);

                ((System.ComponentModel.ISupportInitialize)(NUD_NumberOfd_N)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(NUD_dTime_N)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(NUD_dFreq_N)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(NUD_WN_N)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(NUD_WL_N)).EndInit();
            }
            panel1.Controls.Add(TLP_DataTable);
        }
        private void RefreshFinalTime()
        {
            int rows_max = Mass_of_vals.GetLength(0);
            double SummaryTime = 0.0;
            for(int i =0;i<rows_max;i++)
            {
                SummaryTime += Mass_of_vals[i, 6];
            }
            L_FinalSumTime.Text = (System.Math.Round(SummaryTime * 100) / 100.0).ToString();
        }

        #endregion

        private void B_CreateTable_Click(object sender, EventArgs e)
        {
            RecreateTable((int)NUD_NumOfIntervals.Value);
        }

        private void W_AO_SweepTuneCurve_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void W_AO_SweepTuneCurve_FormClosed(object sender, FormClosedEventArgs e)
        {
          //  SaveToMain(Mass_of_vals, W_isCurveEnabled);
        }
    }
}
