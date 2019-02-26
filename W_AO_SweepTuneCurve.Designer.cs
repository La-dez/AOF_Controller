namespace AOF_Controller
{
    partial class W_AO_SweepTuneCurve
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MS_MainStrip = new System.Windows.Forms.MenuStrip();
            this.TSMI_Quit_nosave = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_SaveAndQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.TLP_Table = new System.Windows.Forms.TableLayoutPanel();
            this.TLP_HeadLine = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TLP_DataTable = new System.Windows.Forms.TableLayoutPanel();
            this.NUD_NumberOfd_0 = new System.Windows.Forms.NumericUpDown();
            this.NUD_dTime_0 = new System.Windows.Forms.NumericUpDown();
            this.NUD_dFreq_0 = new System.Windows.Forms.NumericUpDown();
            this.NUD_WN_0 = new System.Windows.Forms.NumericUpDown();
            this.L_SumTime_0 = new System.Windows.Forms.Label();
            this.L_Number_0 = new System.Windows.Forms.Label();
            this.L_AOFreq_0 = new System.Windows.Forms.Label();
            this.NUD_WL_0 = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.L_FinalSumTime = new System.Windows.Forms.Label();
            this.ChB_ActivateCurveTuning = new System.Windows.Forms.CheckBox();
            this.L_Int = new System.Windows.Forms.Label();
            this.NUD_NumOfIntervals = new System.Windows.Forms.NumericUpDown();
            this.B_CreateTable = new System.Windows.Forms.Button();
            this.MS_MainStrip.SuspendLayout();
            this.TLP_Table.SuspendLayout();
            this.TLP_HeadLine.SuspendLayout();
            this.panel1.SuspendLayout();
            this.TLP_DataTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_NumberOfd_0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_dTime_0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_dFreq_0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_WN_0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_WL_0)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_NumOfIntervals)).BeginInit();
            this.SuspendLayout();
            // 
            // MS_MainStrip
            // 
            this.MS_MainStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MS_MainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_Quit_nosave,
            this.TSMI_Save,
            this.TSMI_SaveAndQuit});
            this.MS_MainStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.MS_MainStrip.Location = new System.Drawing.Point(0, 0);
            this.MS_MainStrip.Name = "MS_MainStrip";
            this.MS_MainStrip.Size = new System.Drawing.Size(753, 24);
            this.MS_MainStrip.TabIndex = 0;
            this.MS_MainStrip.Text = "menuStrip1";
            // 
            // TSMI_Quit_nosave
            // 
            this.TSMI_Quit_nosave.Name = "TSMI_Quit_nosave";
            this.TSMI_Quit_nosave.Size = new System.Drawing.Size(54, 20);
            this.TSMI_Quit_nosave.Text = "Выйти";
            this.TSMI_Quit_nosave.Click += new System.EventHandler(this.TSMI_Quit_nosave_Click);
            // 
            // TSMI_Save
            // 
            this.TSMI_Save.Name = "TSMI_Save";
            this.TSMI_Save.Size = new System.Drawing.Size(77, 20);
            this.TSMI_Save.Text = "Сохранить";
            this.TSMI_Save.Click += new System.EventHandler(this.TSMI_Save_Click);
            // 
            // TSMI_SaveAndQuit
            // 
            this.TSMI_SaveAndQuit.Name = "TSMI_SaveAndQuit";
            this.TSMI_SaveAndQuit.Size = new System.Drawing.Size(124, 20);
            this.TSMI_SaveAndQuit.Text = "Сохранить и выйти";
            this.TSMI_SaveAndQuit.Click += new System.EventHandler(this.TSMI_SaveAndQuit_Click);
            // 
            // TLP_Table
            // 
            this.TLP_Table.ColumnCount = 1;
            this.TLP_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_Table.Controls.Add(this.TLP_HeadLine, 0, 0);
            this.TLP_Table.Controls.Add(this.panel1, 0, 1);
            this.TLP_Table.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.TLP_Table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_Table.Location = new System.Drawing.Point(0, 24);
            this.TLP_Table.Name = "TLP_Table";
            this.TLP_Table.RowCount = 3;
            this.TLP_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TLP_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TLP_Table.Size = new System.Drawing.Size(753, 318);
            this.TLP_Table.TabIndex = 1;
            // 
            // TLP_HeadLine
            // 
            this.TLP_HeadLine.ColumnCount = 8;
            this.TLP_HeadLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.TLP_HeadLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TLP_HeadLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLP_HeadLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLP_HeadLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLP_HeadLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLP_HeadLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TLP_HeadLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLP_HeadLine.Controls.Add(this.label8, 7, 0);
            this.TLP_HeadLine.Controls.Add(this.label7, 6, 0);
            this.TLP_HeadLine.Controls.Add(this.label6, 5, 0);
            this.TLP_HeadLine.Controls.Add(this.label1, 0, 0);
            this.TLP_HeadLine.Controls.Add(this.label2, 1, 0);
            this.TLP_HeadLine.Controls.Add(this.label3, 2, 0);
            this.TLP_HeadLine.Controls.Add(this.label4, 3, 0);
            this.TLP_HeadLine.Controls.Add(this.label5, 4, 0);
            this.TLP_HeadLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_HeadLine.Location = new System.Drawing.Point(0, 0);
            this.TLP_HeadLine.Margin = new System.Windows.Forms.Padding(0);
            this.TLP_HeadLine.Name = "TLP_HeadLine";
            this.TLP_HeadLine.RowCount = 1;
            this.TLP_HeadLine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_HeadLine.Size = new System.Drawing.Size(753, 30);
            this.TLP_HeadLine.TabIndex = 3;
            this.TLP_HeadLine.Paint += new System.Windows.Forms.PaintEventHandler(this.TLP_Main_Paint);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(638, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Время (мс)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(563, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 26);
            this.label7.TabIndex = 6;
            this.label7.Text = "Количество девиаций";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(451, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 26);
            this.label6.TabIndex = 5;
            this.label6.Text = "Время одной девиации (мс)";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "№";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ДВ (нм)";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Обратная ДВ (см-1)";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(227, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "Частота синтезатора (МГц)";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(339, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "Девиация частоты (МГц)";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.TLP_DataTable);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(753, 258);
            this.panel1.TabIndex = 5;
            // 
            // TLP_DataTable
            // 
            this.TLP_DataTable.ColumnCount = 8;
            this.TLP_DataTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.TLP_DataTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TLP_DataTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLP_DataTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLP_DataTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLP_DataTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLP_DataTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TLP_DataTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLP_DataTable.Controls.Add(this.NUD_NumberOfd_0, 6, 0);
            this.TLP_DataTable.Controls.Add(this.NUD_dTime_0, 5, 0);
            this.TLP_DataTable.Controls.Add(this.NUD_dFreq_0, 4, 0);
            this.TLP_DataTable.Controls.Add(this.NUD_WN_0, 2, 0);
            this.TLP_DataTable.Controls.Add(this.L_SumTime_0, 7, 0);
            this.TLP_DataTable.Controls.Add(this.L_Number_0, 0, 0);
            this.TLP_DataTable.Controls.Add(this.L_AOFreq_0, 3, 0);
            this.TLP_DataTable.Controls.Add(this.NUD_WL_0, 1, 0);
            this.TLP_DataTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.TLP_DataTable.Location = new System.Drawing.Point(0, 0);
            this.TLP_DataTable.Margin = new System.Windows.Forms.Padding(0);
            this.TLP_DataTable.Name = "TLP_DataTable";
            this.TLP_DataTable.RowCount = 1;
            this.TLP_DataTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_DataTable.Size = new System.Drawing.Size(753, 26);
            this.TLP_DataTable.TabIndex = 4;
            // 
            // NUD_NumberOfd_0
            // 
            this.NUD_NumberOfd_0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NUD_NumberOfd_0.Location = new System.Drawing.Point(560, 3);
            this.NUD_NumberOfd_0.Margin = new System.Windows.Forms.Padding(0);
            this.NUD_NumberOfd_0.Maximum = new decimal(new int[] {
            254,
            0,
            0,
            0});
            this.NUD_NumberOfd_0.Name = "NUD_NumberOfd_0";
            this.NUD_NumberOfd_0.Size = new System.Drawing.Size(75, 20);
            this.NUD_NumberOfd_0.TabIndex = 11;
            this.NUD_NumberOfd_0.ValueChanged += new System.EventHandler(this.NUD_NumberOfd_N_ValueChanged);
            // 
            // NUD_dTime_0
            // 
            this.NUD_dTime_0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NUD_dTime_0.Location = new System.Drawing.Point(448, 3);
            this.NUD_dTime_0.Margin = new System.Windows.Forms.Padding(0);
            this.NUD_dTime_0.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NUD_dTime_0.Name = "NUD_dTime_0";
            this.NUD_dTime_0.Size = new System.Drawing.Size(112, 20);
            this.NUD_dTime_0.TabIndex = 9;
            this.NUD_dTime_0.ValueChanged += new System.EventHandler(this.NUD_dTime_N_ValueChanged);
            // 
            // NUD_dFreq_0
            // 
            this.NUD_dFreq_0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NUD_dFreq_0.Location = new System.Drawing.Point(336, 3);
            this.NUD_dFreq_0.Margin = new System.Windows.Forms.Padding(0);
            this.NUD_dFreq_0.Name = "NUD_dFreq_0";
            this.NUD_dFreq_0.Size = new System.Drawing.Size(112, 20);
            this.NUD_dFreq_0.TabIndex = 8;
            this.NUD_dFreq_0.ValueChanged += new System.EventHandler(this.NUD_dFreq_N_ValueChanged);
            // 
            // NUD_WN_0
            // 
            this.NUD_WN_0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NUD_WN_0.DecimalPlaces = 2;
            this.NUD_WN_0.Location = new System.Drawing.Point(112, 3);
            this.NUD_WN_0.Margin = new System.Windows.Forms.Padding(0);
            this.NUD_WN_0.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.NUD_WN_0.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NUD_WN_0.Name = "NUD_WN_0";
            this.NUD_WN_0.Size = new System.Drawing.Size(112, 20);
            this.NUD_WN_0.TabIndex = 6;
            this.NUD_WN_0.Value = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.NUD_WN_0.ValueChanged += new System.EventHandler(this.NUD_WN_N_ValueChanged);
            // 
            // L_SumTime_0
            // 
            this.L_SumTime_0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.L_SumTime_0.AutoSize = true;
            this.L_SumTime_0.Location = new System.Drawing.Point(638, 6);
            this.L_SumTime_0.Name = "L_SumTime_0";
            this.L_SumTime_0.Size = new System.Drawing.Size(112, 13);
            this.L_SumTime_0.TabIndex = 12;
            this.L_SumTime_0.Text = "0";
            this.L_SumTime_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // L_Number_0
            // 
            this.L_Number_0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.L_Number_0.AutoSize = true;
            this.L_Number_0.Location = new System.Drawing.Point(3, 6);
            this.L_Number_0.Name = "L_Number_0";
            this.L_Number_0.Size = new System.Drawing.Size(31, 13);
            this.L_Number_0.TabIndex = 4;
            this.L_Number_0.Text = "0";
            // 
            // L_AOFreq_0
            // 
            this.L_AOFreq_0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.L_AOFreq_0.AutoSize = true;
            this.L_AOFreq_0.Location = new System.Drawing.Point(227, 6);
            this.L_AOFreq_0.Name = "L_AOFreq_0";
            this.L_AOFreq_0.Size = new System.Drawing.Size(106, 13);
            this.L_AOFreq_0.TabIndex = 7;
            this.L_AOFreq_0.Text = "(частота)";
            this.L_AOFreq_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NUD_WL_0
            // 
            this.NUD_WL_0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NUD_WL_0.DecimalPlaces = 2;
            this.NUD_WL_0.Location = new System.Drawing.Point(37, 3);
            this.NUD_WL_0.Margin = new System.Windows.Forms.Padding(0);
            this.NUD_WL_0.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NUD_WL_0.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_WL_0.Name = "NUD_WL_0";
            this.NUD_WL_0.Size = new System.Drawing.Size(75, 20);
            this.NUD_WL_0.TabIndex = 5;
            this.NUD_WL_0.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_WL_0.ValueChanged += new System.EventHandler(this.NUD_WL_N_ValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.label9, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.L_FinalSumTime, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 288);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(753, 30);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(510, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Суммарное время (мс):";
            // 
            // L_FinalSumTime
            // 
            this.L_FinalSumTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.L_FinalSumTime.AutoSize = true;
            this.L_FinalSumTime.Location = new System.Drawing.Point(642, 8);
            this.L_FinalSumTime.Name = "L_FinalSumTime";
            this.L_FinalSumTime.Size = new System.Drawing.Size(108, 13);
            this.L_FinalSumTime.TabIndex = 1;
            this.L_FinalSumTime.Text = "0";
            this.L_FinalSumTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChB_ActivateCurveTuning
            // 
            this.ChB_ActivateCurveTuning.AutoSize = true;
            this.ChB_ActivateCurveTuning.BackColor = System.Drawing.Color.White;
            this.ChB_ActivateCurveTuning.Location = new System.Drawing.Point(530, 4);
            this.ChB_ActivateCurveTuning.Name = "ChB_ActivateCurveTuning";
            this.ChB_ActivateCurveTuning.Size = new System.Drawing.Size(205, 17);
            this.ChB_ActivateCurveTuning.TabIndex = 2;
            this.ChB_ActivateCurveTuning.Text = "Активировать кривую перестройки";
            this.ChB_ActivateCurveTuning.UseVisualStyleBackColor = false;
            this.ChB_ActivateCurveTuning.CheckedChanged += new System.EventHandler(this.ChB_ActivateCurveTuning_CheckedChanged);
            // 
            // L_Int
            // 
            this.L_Int.AutoSize = true;
            this.L_Int.Location = new System.Drawing.Point(269, 5);
            this.L_Int.Name = "L_Int";
            this.L_Int.Size = new System.Drawing.Size(131, 13);
            this.L_Int.TabIndex = 3;
            this.L_Int.Text = "Количество интервалов:";
            // 
            // NUD_NumOfIntervals
            // 
            this.NUD_NumOfIntervals.Location = new System.Drawing.Point(403, 3);
            this.NUD_NumOfIntervals.Name = "NUD_NumOfIntervals";
            this.NUD_NumOfIntervals.Size = new System.Drawing.Size(43, 20);
            this.NUD_NumOfIntervals.TabIndex = 4;
            this.NUD_NumOfIntervals.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_NumOfIntervals.ValueChanged += new System.EventHandler(this.NUD_NumOfIntervals_ValueChanged);
            // 
            // B_CreateTable
            // 
            this.B_CreateTable.Location = new System.Drawing.Point(451, 2);
            this.B_CreateTable.Name = "B_CreateTable";
            this.B_CreateTable.Size = new System.Drawing.Size(61, 21);
            this.B_CreateTable.TabIndex = 5;
            this.B_CreateTable.Text = "Создать";
            this.B_CreateTable.UseVisualStyleBackColor = true;
            this.B_CreateTable.Click += new System.EventHandler(this.B_CreateTable_Click);
            // 
            // W_AO_SweepTuneCurve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 342);
            this.Controls.Add(this.B_CreateTable);
            this.Controls.Add(this.NUD_NumOfIntervals);
            this.Controls.Add(this.L_Int);
            this.Controls.Add(this.ChB_ActivateCurveTuning);
            this.Controls.Add(this.TLP_Table);
            this.Controls.Add(this.MS_MainStrip);
            this.MainMenuStrip = this.MS_MainStrip;
            this.Name = "W_AO_SweepTuneCurve";
            this.Text = "W_AO_SweepTuneCurve";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.W_AO_SweepTuneCurve_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.W_AO_SweepTuneCurve_FormClosed);
            this.Load += new System.EventHandler(this.W_AO_SweepTuneCurve_Load);
            this.MS_MainStrip.ResumeLayout(false);
            this.MS_MainStrip.PerformLayout();
            this.TLP_Table.ResumeLayout(false);
            this.TLP_HeadLine.ResumeLayout(false);
            this.TLP_HeadLine.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.TLP_DataTable.ResumeLayout(false);
            this.TLP_DataTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_NumberOfd_0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_dTime_0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_dFreq_0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_WN_0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_WL_0)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_NumOfIntervals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MS_MainStrip;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Quit_nosave;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Save;
        private System.Windows.Forms.ToolStripMenuItem TSMI_SaveAndQuit;
        private System.Windows.Forms.TableLayoutPanel TLP_Table;
        private System.Windows.Forms.CheckBox ChB_ActivateCurveTuning;
        private System.Windows.Forms.TableLayoutPanel TLP_HeadLine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel TLP_DataTable;
        private System.Windows.Forms.NumericUpDown NUD_NumberOfd_0;
        private System.Windows.Forms.NumericUpDown NUD_dTime_0;
        private System.Windows.Forms.NumericUpDown NUD_dFreq_0;
        private System.Windows.Forms.NumericUpDown NUD_WN_0;
        private System.Windows.Forms.Label L_SumTime_0;
        private System.Windows.Forms.Label L_Number_0;
        private System.Windows.Forms.Label L_AOFreq_0;
        private System.Windows.Forms.NumericUpDown NUD_WL_0;
        private System.Windows.Forms.Label L_Int;
        private System.Windows.Forms.NumericUpDown NUD_NumOfIntervals;
        private System.Windows.Forms.Button B_CreateTable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label L_FinalSumTime;
    }
}