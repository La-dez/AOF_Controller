using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AOF_Controller
{
    public partial class W_AO_SweepTuneCurve : Form
    {
        float W_WL_Max = 1000;
        float W_WL_Min = 1;
        

        public W_AO_SweepTuneCurve()
        {
            InitializeComponent();
        }

        private void W_AO_SweepTuneCurve_Load(object sender, EventArgs e)
        {

        }
        private void TSMI_Save_Click(object sender, EventArgs e)
        {

        }
        private void TSMI_SaveAndQuit_Click(object sender, EventArgs e)
        {
        }
        private void TSMI_Quit_nosave_Click(object sender, EventArgs e)
        {

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
            int nameNumber = Convert.ToInt32(name_of_sender.Last().ToString());
            string Name = "NUD_WN_";
            var ctrl = TLP_DataTable.Controls.Find(Name + nameNumber, false);
            (ctrl[0] as NumericUpDown).Value = (decimal)(10000000.0/(double)((sender as NumericUpDown).Value));
        }

        private void NUD_WN_N_ValueChanged(object sender, EventArgs e)
        {
            string name_of_sender = (sender as NumericUpDown).Name;
            int nameNumber = Convert.ToInt32(name_of_sender.Last().ToString());
            string Name = "NUD_WL_";
            var ctrl = TLP_DataTable.Controls.Find(Name + nameNumber, false);
            (ctrl[0] as NumericUpDown).Value = (decimal)(10000000.0 / (double)((sender as NumericUpDown).Value));
        }

        private void NUD_dFreq_N_ValueChanged(object sender, EventArgs e)
        {

        }

        private void NUD_dTime_N_ValueChanged(object sender, EventArgs e)
        {

        }

        private void NUD_NumberOfd_N_ValueChanged(object sender, EventArgs e)
        {

        }

        private void B_ActivateCurveTuning_CheckedChanged(object sender, EventArgs e)
        {

        }



        #region Функции
        private void RecreateTable(int number_of_Values)
        {
            // 
            // TLP_DataTable
            // 

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
            1000,
            0,
            0,
            0});
                NUD_NumberOfd_N.Name = "NUD_NumberOfd_"+i.ToString();
                NUD_NumberOfd_N.Size = new System.Drawing.Size(85, 20);
                NUD_NumberOfd_N.TabIndex = 12;
                NUD_NumberOfd_N.ValueChanged += new System.EventHandler(NUD_NumberOfd_N_ValueChanged);
                // 
                // NUD_dTime_N
                // 
                NUD_dTime_N.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                NUD_dTime_N.Location = new System.Drawing.Point(370, 3);
                NUD_dTime_N.Margin = new System.Windows.Forms.Padding(0);
                NUD_dTime_N.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
                NUD_dTime_N.Name = "NUD_dTime_" + i.ToString();
                NUD_dTime_N.Size = new System.Drawing.Size(90, 20);
                NUD_dTime_N.TabIndex = 11;
                NUD_dTime_N.ValueChanged += new System.EventHandler(NUD_dTime_N_ValueChanged);
                // 
                // NUD_dFreq_N
                // 
                NUD_dFreq_N.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                NUD_dFreq_N.Location = new System.Drawing.Point(280, 3);
                NUD_dFreq_N.Margin = new System.Windows.Forms.Padding(0);
                NUD_dFreq_N.Name = "NUD_dFreq_" + i.ToString();
                NUD_dFreq_N.Size = new System.Drawing.Size(90, 20);
                NUD_dFreq_N.TabIndex = 10;
                NUD_dFreq_N.ValueChanged += new System.EventHandler(NUD_dFreq_N_ValueChanged);
                // 
                // NUD_WN_N
                // 
                NUD_WN_N.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                NUD_WN_N.DecimalPlaces = 2;
                NUD_WN_N.Location = new System.Drawing.Point(90, 3);
                NUD_WN_N.Margin = new System.Windows.Forms.Padding(0);
                NUD_WN_N.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
                NUD_WN_N.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
                NUD_WN_N.Name = "NUD_WN_" + i.ToString();
                NUD_WN_N.Size = new System.Drawing.Size(85, 20);
                NUD_WN_N.TabIndex = 9;
                NUD_WN_N.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
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
                L_SumTime_N.Text = "0";
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
                L_AOFreq_N.Text = "(частота)";
                L_AOFreq_N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                // 
                // NUD_WL_N
                // 
                NUD_WL_N.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                NUD_WL_N.Location = new System.Drawing.Point(40, 3);
                NUD_WL_N.Margin = new System.Windows.Forms.Padding(0);
                NUD_WL_N.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
                NUD_WL_N.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
                NUD_WL_N.Name = "NUD_WL_" + i.ToString();
                NUD_WL_N.Size = new System.Drawing.Size(50, 20);
                NUD_WL_N.TabIndex = 8;
                NUD_WL_N.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
                NUD_WL_N.ValueChanged += new System.EventHandler(NUD_WL_N_ValueChanged);


                TLP_DataTable.ResumeLayout(false);
                TLP_DataTable.PerformLayout();
                ((System.ComponentModel.ISupportInitialize)(NUD_NumberOfd_N)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(NUD_dTime_N)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(NUD_dFreq_N)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(NUD_WN_N)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(NUD_WL_N)).EndInit();          
                
                TLP_DataTable.Controls.Add(L_Number_N, 0, i);
                TLP_DataTable.Controls.Add(NUD_WL_N, 1, i);
                TLP_DataTable.Controls.Add(NUD_WN_N, 2, i);
                TLP_DataTable.Controls.Add(L_AOFreq_N, 3, i);
                TLP_DataTable.Controls.Add(NUD_dFreq_N, 4, i);
                TLP_DataTable.Controls.Add(NUD_dTime_N, 5, i);
                TLP_DataTable.Controls.Add(NUD_NumberOfd_N, 6, i);
                TLP_DataTable.Controls.Add(L_SumTime_N, 7, i);
            }
            panel1.Controls.Add(TLP_DataTable);
        }


        #endregion

        private void B_CreateTable_Click(object sender, EventArgs e)
        {
            RecreateTable((int)NUD_NumOfIntervals.Value);
        }
    }
}
