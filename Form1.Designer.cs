namespace AOF_Controller
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel30 = new System.Windows.Forms.TableLayoutPanel();
            this.ChB_Power = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.L_RealDevName = new System.Windows.Forms.Label();
            this.BDevOpen = new System.Windows.Forms.Button();
            this.L_RequiredDevName = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.GB_AllAOFControls = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TLP_SetControls = new System.Windows.Forms.TableLayoutPanel();
            this.NUD_Incr_CurMHz = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.BSetWL = new System.Windows.Forms.Button();
            this.NUD_CurMHz = new System.Windows.Forms.NumericUpDown();
            this.NUD_CurWL = new System.Windows.Forms.NumericUpDown();
            this.label29 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.ChB_AutoSetWL = new System.Windows.Forms.CheckBox();
            this.NUD_AO_Timeout_Value = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.ChB_TimeOut = new System.Windows.Forms.CheckBox();
            this.TLP_WLSlidingControls = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.TRB_SoundFreq = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.TrB_CurrentWL = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.ChB_SweepEnabled = new System.Windows.Forms.CheckBox();
            this.Pan_SweepControls = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.RB_Sweep_SpeciallMode = new System.Windows.Forms.RadioButton();
            this.RB_Sweep_EasyMode = new System.Windows.Forms.RadioButton();
            this.TLP_Sweep_EasyMode = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.NUD_FreqDeviation = new System.Windows.Forms.NumericUpDown();
            this.NUD_TimeFdev_up = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.B_SetSweep = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.NUD_TimeFdev_down = new System.Windows.Forms.NumericUpDown();
            this.NUD_Steps_on_Sweep = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.TLP_Sweep_ProgramMode = new System.Windows.Forms.TableLayoutPanel();
            this.ChB_ProgrammSweep_toogler = new System.Windows.Forms.CheckBox();
            this.B_BrowseCSVCurve = new System.Windows.Forms.Button();
            this.TB_CSVCurveFolder = new System.Windows.Forms.TextBox();
            this.B_EditCurve = new System.Windows.Forms.Button();
            this.B_CreateData = new System.Windows.Forms.Button();
            this.TLP_STCspecial_Fun = new System.Windows.Forms.TableLayoutPanel();
            this.B_setHZSpecialSTC = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.NUD_PowerDecrement = new System.Windows.Forms.NumericUpDown();
            this.ChB_Remember_AT = new System.Windows.Forms.CheckBox();
            this.B_Test = new System.Windows.Forms.Button();
            this.LBConsole = new System.Windows.Forms.ListBox();
            this.B_Quit = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_CreateCurve = new System.Windows.Forms.ToolStripMenuItem();
            this.BGW_Sweep_Curve = new System.ComponentModel.BackgroundWorker();
            this.Timer_sweepChecker = new System.Windows.Forms.Timer(this.components);
            this.BGW_ProgrammedTuning = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel30.SuspendLayout();
            this.GB_AllAOFControls.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.TLP_SetControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Incr_CurMHz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_CurMHz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_CurWL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_AO_Timeout_Value)).BeginInit();
            this.TLP_WLSlidingControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TRB_SoundFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrB_CurrentWL)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.Pan_SweepControls.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.TLP_Sweep_EasyMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_FreqDeviation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_TimeFdev_up)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_TimeFdev_down)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Steps_on_Sweep)).BeginInit();
            this.TLP_Sweep_ProgramMode.SuspendLayout();
            this.TLP_STCspecial_Fun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_PowerDecrement)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.GB_AllAOFControls, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.LBConsole, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.B_Quit, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 33);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1370, 925);
            this.tableLayoutPanel2.TabIndex = 82;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel30);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(4, 5);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(1362, 144);
            this.groupBox2.TabIndex = 63;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Элементы управления АОФ:";
            // 
            // tableLayoutPanel30
            // 
            this.tableLayoutPanel30.ColumnCount = 4;
            this.tableLayoutPanel30.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel30.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel30.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel30.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel30.Controls.Add(this.ChB_Power, 3, 0);
            this.tableLayoutPanel30.Controls.Add(this.label18, 0, 2);
            this.tableLayoutPanel30.Controls.Add(this.L_RealDevName, 2, 2);
            this.tableLayoutPanel30.Controls.Add(this.BDevOpen, 1, 0);
            this.tableLayoutPanel30.Controls.Add(this.L_RequiredDevName, 1, 1);
            this.tableLayoutPanel30.Controls.Add(this.label17, 0, 1);
            this.tableLayoutPanel30.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel30.Location = new System.Drawing.Point(4, 24);
            this.tableLayoutPanel30.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel30.Name = "tableLayoutPanel30";
            this.tableLayoutPanel30.RowCount = 3;
            this.tableLayoutPanel30.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel30.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel30.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel30.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel30.Size = new System.Drawing.Size(1354, 115);
            this.tableLayoutPanel30.TabIndex = 80;
            // 
            // ChB_Power
            // 
            this.ChB_Power.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChB_Power.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChB_Power.Location = new System.Drawing.Point(948, 2);
            this.ChB_Power.Margin = new System.Windows.Forms.Padding(2);
            this.ChB_Power.Name = "ChB_Power";
            this.ChB_Power.Size = new System.Drawing.Size(404, 35);
            this.ChB_Power.TabIndex = 82;
            this.ChB_Power.Text = "Питание";
            this.ChB_Power.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChB_Power.UseVisualStyleBackColor = true;
            this.ChB_Power.CheckedChanged += new System.EventHandler(this.ChB_Power_CheckedChanged);
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label18.AutoSize = true;
            this.tableLayoutPanel30.SetColumnSpan(this.label18, 2);
            this.label18.Location = new System.Drawing.Point(4, 86);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(198, 20);
            this.label18.TabIndex = 79;
            this.label18.Text = "Загруженный .dev файл :";
            // 
            // L_RealDevName
            // 
            this.L_RealDevName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.L_RealDevName.AutoSize = true;
            this.tableLayoutPanel30.SetColumnSpan(this.L_RealDevName, 2);
            this.L_RealDevName.Location = new System.Drawing.Point(1305, 86);
            this.L_RealDevName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L_RealDevName.Name = "L_RealDevName";
            this.L_RealDevName.Size = new System.Drawing.Size(45, 20);
            this.L_RealDevName.TabIndex = 80;
            this.L_RealDevName.Text = "none";
            // 
            // BDevOpen
            // 
            this.tableLayoutPanel30.SetColumnSpan(this.BDevOpen, 2);
            this.BDevOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BDevOpen.Location = new System.Drawing.Point(408, 2);
            this.BDevOpen.Margin = new System.Windows.Forms.Padding(2);
            this.BDevOpen.Name = "BDevOpen";
            this.BDevOpen.Size = new System.Drawing.Size(536, 35);
            this.BDevOpen.TabIndex = 13;
            this.BDevOpen.Text = "Открыть .dev файл";
            this.BDevOpen.UseVisualStyleBackColor = true;
            this.BDevOpen.Click += new System.EventHandler(this.BDevOpen_Click);
            // 
            // L_RequiredDevName
            // 
            this.L_RequiredDevName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.L_RequiredDevName.AutoSize = true;
            this.tableLayoutPanel30.SetColumnSpan(this.L_RequiredDevName, 2);
            this.L_RequiredDevName.Location = new System.Drawing.Point(1252, 48);
            this.L_RequiredDevName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L_RequiredDevName.Name = "L_RequiredDevName";
            this.L_RequiredDevName.Size = new System.Drawing.Size(98, 20);
            this.L_RequiredDevName.TabIndex = 13;
            this.L_RequiredDevName.Text = "filename.dev";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.tableLayoutPanel30.SetColumnSpan(this.label17, 2);
            this.label17.Location = new System.Drawing.Point(4, 48);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(668, 20);
            this.label17.TabIndex = 78;
            this.label17.Text = "Требуемый .dev файл :";
            // 
            // GB_AllAOFControls
            // 
            this.GB_AllAOFControls.Controls.Add(this.tableLayoutPanel1);
            this.GB_AllAOFControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GB_AllAOFControls.Location = new System.Drawing.Point(4, 159);
            this.GB_AllAOFControls.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GB_AllAOFControls.Name = "GB_AllAOFControls";
            this.GB_AllAOFControls.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GB_AllAOFControls.Size = new System.Drawing.Size(1362, 561);
            this.GB_AllAOFControls.TabIndex = 53;
            this.GB_AllAOFControls.TabStop = false;
            this.GB_AllAOFControls.Text = "Настройки длины волны пропускания:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.TLP_SetControls, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TLP_WLSlidingControls, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.TLP_STCspecial_Fun, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 24);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1354, 532);
            this.tableLayoutPanel1.TabIndex = 80;
            // 
            // TLP_SetControls
            // 
            this.TLP_SetControls.ColumnCount = 12;
            this.TLP_SetControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TLP_SetControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.TLP_SetControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLP_SetControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.TLP_SetControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLP_SetControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.TLP_SetControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLP_SetControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.TLP_SetControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TLP_SetControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLP_SetControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.TLP_SetControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.TLP_SetControls.Controls.Add(this.NUD_Incr_CurMHz, 6, 1);
            this.TLP_SetControls.Controls.Add(this.label5, 7, 1);
            this.TLP_SetControls.Controls.Add(this.BSetWL, 11, 0);
            this.TLP_SetControls.Controls.Add(this.NUD_CurMHz, 4, 1);
            this.TLP_SetControls.Controls.Add(this.NUD_CurWL, 2, 1);
            this.TLP_SetControls.Controls.Add(this.label29, 3, 1);
            this.TLP_SetControls.Controls.Add(this.label3, 5, 1);
            this.TLP_SetControls.Controls.Add(this.label11, 2, 0);
            this.TLP_SetControls.Controls.Add(this.label12, 4, 0);
            this.TLP_SetControls.Controls.Add(this.label13, 6, 0);
            this.TLP_SetControls.Controls.Add(this.label28, 1, 0);
            this.TLP_SetControls.Controls.Add(this.ChB_AutoSetWL, 1, 1);
            this.TLP_SetControls.Controls.Add(this.NUD_AO_Timeout_Value, 9, 1);
            this.TLP_SetControls.Controls.Add(this.label15, 10, 1);
            this.TLP_SetControls.Controls.Add(this.label14, 8, 0);
            this.TLP_SetControls.Controls.Add(this.ChB_TimeOut, 8, 1);
            this.TLP_SetControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_SetControls.Location = new System.Drawing.Point(0, 0);
            this.TLP_SetControls.Margin = new System.Windows.Forms.Padding(0);
            this.TLP_SetControls.Name = "TLP_SetControls";
            this.TLP_SetControls.RowCount = 2;
            this.TLP_SetControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.TLP_SetControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_SetControls.Size = new System.Drawing.Size(1354, 92);
            this.TLP_SetControls.TabIndex = 81;
            // 
            // NUD_Incr_CurMHz
            // 
            this.NUD_Incr_CurMHz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NUD_Incr_CurMHz.DecimalPlaces = 3;
            this.NUD_Incr_CurMHz.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.NUD_Incr_CurMHz.Location = new System.Drawing.Point(546, 60);
            this.NUD_Incr_CurMHz.Margin = new System.Windows.Forms.Padding(0);
            this.NUD_Incr_CurMHz.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.NUD_Incr_CurMHz.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.NUD_Incr_CurMHz.Name = "NUD_Incr_CurMHz";
            this.NUD_Incr_CurMHz.Size = new System.Drawing.Size(138, 26);
            this.NUD_Incr_CurMHz.TabIndex = 85;
            this.NUD_Incr_CurMHz.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.NUD_Incr_CurMHz.ValueChanged += new System.EventHandler(this.NUD_Incr_CurMHz_ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(694, 63);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 20);
            this.label5.TabIndex = 86;
            this.label5.Text = "МГц";
            // 
            // BSetWL
            // 
            this.BSetWL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BSetWL.Location = new System.Drawing.Point(982, 0);
            this.BSetWL.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.BSetWL.Name = "BSetWL";
            this.TLP_SetControls.SetRowSpan(this.BSetWL, 2);
            this.BSetWL.Size = new System.Drawing.Size(370, 92);
            this.BSetWL.TabIndex = 5;
            this.BSetWL.Text = "Установить";
            this.BSetWL.UseVisualStyleBackColor = true;
            this.BSetWL.Click += new System.EventHandler(this.BSetWL_Click);
            // 
            // NUD_CurMHz
            // 
            this.NUD_CurMHz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NUD_CurMHz.DecimalPlaces = 3;
            this.NUD_CurMHz.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.NUD_CurMHz.Location = new System.Drawing.Point(348, 60);
            this.NUD_CurMHz.Margin = new System.Windows.Forms.Padding(0);
            this.NUD_CurMHz.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.NUD_CurMHz.Name = "NUD_CurMHz";
            this.NUD_CurMHz.Size = new System.Drawing.Size(138, 26);
            this.NUD_CurMHz.TabIndex = 84;
            this.NUD_CurMHz.ValueChanged += new System.EventHandler(this.NUD_CurMHz_ValueChanged);
            // 
            // NUD_CurWL
            // 
            this.NUD_CurWL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NUD_CurWL.DecimalPlaces = 2;
            this.NUD_CurWL.Location = new System.Drawing.Point(150, 60);
            this.NUD_CurWL.Margin = new System.Windows.Forms.Padding(0);
            this.NUD_CurWL.Maximum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.NUD_CurWL.Name = "NUD_CurWL";
            this.NUD_CurWL.Size = new System.Drawing.Size(138, 26);
            this.NUD_CurWL.TabIndex = 83;
            this.NUD_CurWL.ValueChanged += new System.EventHandler(this.NUD_CurWL_ValueChanged);
            // 
            // label29
            // 
            this.label29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(292, 63);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(52, 20);
            this.label29.TabIndex = 53;
            this.label29.Text = "нм";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(496, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 85;
            this.label3.Text = "МГц";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(154, 17);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(130, 20);
            this.label11.TabIndex = 87;
            this.label11.Text = "Длина волны";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(352, 17);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 20);
            this.label12.TabIndex = 88;
            this.label12.Text = "Частота";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(550, 7);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(130, 40);
            this.label13.TabIndex = 89;
            this.label13.Text = "Инкремент частоты";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label28
            // 
            this.label28.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(41, 7);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(105, 40);
            this.label28.TabIndex = 51;
            this.label28.Text = "Управление ползунком";
            this.label28.Click += new System.EventHandler(this.label28_Click);
            // 
            // ChB_AutoSetWL
            // 
            this.ChB_AutoSetWL.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ChB_AutoSetWL.AutoSize = true;
            this.ChB_AutoSetWL.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChB_AutoSetWL.Location = new System.Drawing.Point(79, 62);
            this.ChB_AutoSetWL.Margin = new System.Windows.Forms.Padding(0);
            this.ChB_AutoSetWL.Name = "ChB_AutoSetWL";
            this.ChB_AutoSetWL.Size = new System.Drawing.Size(22, 21);
            this.ChB_AutoSetWL.TabIndex = 35;
            this.ChB_AutoSetWL.UseVisualStyleBackColor = true;
            this.ChB_AutoSetWL.CheckedChanged += new System.EventHandler(this.ChBAutoSetWL_CheckedChanged);
            // 
            // NUD_AO_Timeout_Value
            // 
            this.NUD_AO_Timeout_Value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NUD_AO_Timeout_Value.Enabled = false;
            this.NUD_AO_Timeout_Value.Location = new System.Drawing.Point(784, 60);
            this.NUD_AO_Timeout_Value.Margin = new System.Windows.Forms.Padding(0);
            this.NUD_AO_Timeout_Value.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.NUD_AO_Timeout_Value.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_AO_Timeout_Value.Name = "NUD_AO_Timeout_Value";
            this.NUD_AO_Timeout_Value.Size = new System.Drawing.Size(138, 26);
            this.NUD_AO_Timeout_Value.TabIndex = 91;
            this.NUD_AO_Timeout_Value.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_AO_Timeout_Value.ValueChanged += new System.EventHandler(this.NUD_AO_Timeout_Value_ValueChanged);
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(938, 63);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(28, 20);
            this.label15.TabIndex = 92;
            this.label15.Text = "мс";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.TLP_SetControls.SetColumnSpan(this.label14, 2);
            this.label14.Location = new System.Drawing.Point(748, 7);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(170, 40);
            this.label14.TabIndex = 90;
            this.label14.Text = "Таймаут перестройки";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChB_TimeOut
            // 
            this.ChB_TimeOut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ChB_TimeOut.AutoSize = true;
            this.ChB_TimeOut.Location = new System.Drawing.Point(753, 62);
            this.ChB_TimeOut.Name = "ChB_TimeOut";
            this.ChB_TimeOut.Size = new System.Drawing.Size(22, 21);
            this.ChB_TimeOut.TabIndex = 93;
            this.ChB_TimeOut.UseVisualStyleBackColor = true;
            this.ChB_TimeOut.CheckedChanged += new System.EventHandler(this.ChB_TimeOut_CheckedChanged);
            // 
            // TLP_WLSlidingControls
            // 
            this.TLP_WLSlidingControls.ColumnCount = 2;
            this.TLP_WLSlidingControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_WLSlidingControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.TLP_WLSlidingControls.Controls.Add(this.label2, 1, 1);
            this.TLP_WLSlidingControls.Controls.Add(this.TRB_SoundFreq, 0, 1);
            this.TLP_WLSlidingControls.Controls.Add(this.label1, 1, 0);
            this.TLP_WLSlidingControls.Controls.Add(this.TrB_CurrentWL, 0, 0);
            this.TLP_WLSlidingControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_WLSlidingControls.Location = new System.Drawing.Point(0, 92);
            this.TLP_WLSlidingControls.Margin = new System.Windows.Forms.Padding(0);
            this.TLP_WLSlidingControls.Name = "TLP_WLSlidingControls";
            this.TLP_WLSlidingControls.RowCount = 2;
            this.tableLayoutPanel1.SetRowSpan(this.TLP_WLSlidingControls, 2);
            this.TLP_WLSlidingControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_WLSlidingControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_WLSlidingControls.Size = new System.Drawing.Size(1354, 92);
            this.TLP_WLSlidingControls.TabIndex = 81;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1276, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 82;
            this.label2.Text = "МГц";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TRB_SoundFreq
            // 
            this.TRB_SoundFreq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TRB_SoundFreq.Location = new System.Drawing.Point(4, 51);
            this.TRB_SoundFreq.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TRB_SoundFreq.Maximum = 200000;
            this.TRB_SoundFreq.Name = "TRB_SoundFreq";
            this.TRB_SoundFreq.Size = new System.Drawing.Size(1264, 36);
            this.TRB_SoundFreq.TabIndex = 35;
            this.TRB_SoundFreq.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TRB_SoundFreq.Value = 40000;
            this.TRB_SoundFreq.Scroll += new System.EventHandler(this.TRB_SoundFreq_Scroll);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1276, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 82;
            this.label1.Text = "нм";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrB_CurrentWL
            // 
            this.TrB_CurrentWL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TrB_CurrentWL.Location = new System.Drawing.Point(4, 5);
            this.TrB_CurrentWL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TrB_CurrentWL.Maximum = 150000;
            this.TrB_CurrentWL.Name = "TrB_CurrentWL";
            this.TrB_CurrentWL.Size = new System.Drawing.Size(1264, 36);
            this.TrB_CurrentWL.TabIndex = 34;
            this.TrB_CurrentWL.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TrB_CurrentWL.Scroll += new System.EventHandler(this.TrB_CurrentWL_Scroll);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.ChB_SweepEnabled, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.Pan_SweepControls, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 261);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1354, 271);
            this.tableLayoutPanel5.TabIndex = 2;
            this.tableLayoutPanel5.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel5_Paint);
            // 
            // ChB_SweepEnabled
            // 
            this.ChB_SweepEnabled.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ChB_SweepEnabled.AutoSize = true;
            this.ChB_SweepEnabled.Location = new System.Drawing.Point(4, 11);
            this.ChB_SweepEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChB_SweepEnabled.Name = "ChB_SweepEnabled";
            this.ChB_SweepEnabled.Size = new System.Drawing.Size(276, 24);
            this.ChB_SweepEnabled.TabIndex = 1;
            this.ChB_SweepEnabled.Text = "Программируемая перестройка";
            this.ChB_SweepEnabled.UseVisualStyleBackColor = true;
            this.ChB_SweepEnabled.CheckedChanged += new System.EventHandler(this.ChB_SweepEnabled_CheckedChanged);
            // 
            // Pan_SweepControls
            // 
            this.Pan_SweepControls.Controls.Add(this.tableLayoutPanel3);
            this.Pan_SweepControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pan_SweepControls.Location = new System.Drawing.Point(0, 46);
            this.Pan_SweepControls.Margin = new System.Windows.Forms.Padding(0);
            this.Pan_SweepControls.Name = "Pan_SweepControls";
            this.Pan_SweepControls.Size = new System.Drawing.Size(1354, 225);
            this.Pan_SweepControls.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.RB_Sweep_SpeciallMode, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.RB_Sweep_EasyMode, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.TLP_Sweep_EasyMode, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.TLP_Sweep_ProgramMode, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1354, 225);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // RB_Sweep_SpeciallMode
            // 
            this.RB_Sweep_SpeciallMode.AutoSize = true;
            this.RB_Sweep_SpeciallMode.Location = new System.Drawing.Point(681, 5);
            this.RB_Sweep_SpeciallMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RB_Sweep_SpeciallMode.Name = "RB_Sweep_SpeciallMode";
            this.RB_Sweep_SpeciallMode.Size = new System.Drawing.Size(206, 24);
            this.RB_Sweep_SpeciallMode.TabIndex = 1;
            this.RB_Sweep_SpeciallMode.Text = "По заданному массиву";
            this.RB_Sweep_SpeciallMode.UseVisualStyleBackColor = true;
            this.RB_Sweep_SpeciallMode.CheckedChanged += new System.EventHandler(this.RB_Sweep_SpeciallMode_CheckedChanged);
            // 
            // RB_Sweep_EasyMode
            // 
            this.RB_Sweep_EasyMode.AutoSize = true;
            this.RB_Sweep_EasyMode.Checked = true;
            this.RB_Sweep_EasyMode.Location = new System.Drawing.Point(4, 5);
            this.RB_Sweep_EasyMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RB_Sweep_EasyMode.Name = "RB_Sweep_EasyMode";
            this.RB_Sweep_EasyMode.Size = new System.Drawing.Size(210, 24);
            this.RB_Sweep_EasyMode.TabIndex = 0;
            this.RB_Sweep_EasyMode.TabStop = true;
            this.RB_Sweep_EasyMode.Text = "ЛЧМ (На заданной ДВ)";
            this.RB_Sweep_EasyMode.UseVisualStyleBackColor = true;
            this.RB_Sweep_EasyMode.CheckedChanged += new System.EventHandler(this.RB_Sweep_EasyMode_CheckedChanged);
            // 
            // TLP_Sweep_EasyMode
            // 
            this.TLP_Sweep_EasyMode.ColumnCount = 8;
            this.TLP_Sweep_EasyMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLP_Sweep_EasyMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TLP_Sweep_EasyMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
            this.TLP_Sweep_EasyMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.TLP_Sweep_EasyMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLP_Sweep_EasyMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
            this.TLP_Sweep_EasyMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.TLP_Sweep_EasyMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLP_Sweep_EasyMode.Controls.Add(this.label9, 6, 0);
            this.TLP_Sweep_EasyMode.Controls.Add(this.label10, 6, 1);
            this.TLP_Sweep_EasyMode.Controls.Add(this.NUD_FreqDeviation, 2, 0);
            this.TLP_Sweep_EasyMode.Controls.Add(this.NUD_TimeFdev_up, 2, 1);
            this.TLP_Sweep_EasyMode.Controls.Add(this.label8, 1, 0);
            this.TLP_Sweep_EasyMode.Controls.Add(this.label7, 0, 1);
            this.TLP_Sweep_EasyMode.Controls.Add(this.label6, 0, 0);
            this.TLP_Sweep_EasyMode.Controls.Add(this.B_SetSweep, 7, 0);
            this.TLP_Sweep_EasyMode.Controls.Add(this.label16, 4, 1);
            this.TLP_Sweep_EasyMode.Controls.Add(this.NUD_TimeFdev_down, 5, 1);
            this.TLP_Sweep_EasyMode.Controls.Add(this.NUD_Steps_on_Sweep, 5, 0);
            this.TLP_Sweep_EasyMode.Controls.Add(this.label19, 4, 0);
            this.TLP_Sweep_EasyMode.Controls.Add(this.label20, 3, 0);
            this.TLP_Sweep_EasyMode.Controls.Add(this.label21, 3, 1);
            this.TLP_Sweep_EasyMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_Sweep_EasyMode.Location = new System.Drawing.Point(0, 46);
            this.TLP_Sweep_EasyMode.Margin = new System.Windows.Forms.Padding(0);
            this.TLP_Sweep_EasyMode.Name = "TLP_Sweep_EasyMode";
            this.TLP_Sweep_EasyMode.RowCount = 3;
            this.TLP_Sweep_EasyMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.TLP_Sweep_EasyMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.TLP_Sweep_EasyMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_Sweep_EasyMode.Size = new System.Drawing.Size(677, 179);
            this.TLP_Sweep_EasyMode.TabIndex = 0;
            this.TLP_Sweep_EasyMode.Paint += new System.Windows.Forms.PaintEventHandler(this.TLP_Sweep_EasyMode_Paint);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(540, 21);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "ед.";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(542, 83);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 20);
            this.label10.TabIndex = 2;
            this.label10.Text = "мкс";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NUD_FreqDeviation
            // 
            this.NUD_FreqDeviation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NUD_FreqDeviation.DecimalPlaces = 3;
            this.NUD_FreqDeviation.Location = new System.Drawing.Point(161, 18);
            this.NUD_FreqDeviation.Margin = new System.Windows.Forms.Padding(0);
            this.NUD_FreqDeviation.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUD_FreqDeviation.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.NUD_FreqDeviation.Name = "NUD_FreqDeviation";
            this.NUD_FreqDeviation.Size = new System.Drawing.Size(92, 26);
            this.NUD_FreqDeviation.TabIndex = 1;
            this.NUD_FreqDeviation.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NUD_FreqDeviation.ValueChanged += new System.EventHandler(this.NUD_FreqDeviation_ValueChanged);
            // 
            // NUD_TimeFdev_up
            // 
            this.NUD_TimeFdev_up.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NUD_TimeFdev_up.DecimalPlaces = 5;
            this.NUD_TimeFdev_up.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.NUD_TimeFdev_up.Location = new System.Drawing.Point(161, 80);
            this.NUD_TimeFdev_up.Margin = new System.Windows.Forms.Padding(0);
            this.NUD_TimeFdev_up.Maximum = new decimal(new int[] {
            74842,
            0,
            0,
            131072});
            this.NUD_TimeFdev_up.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_TimeFdev_up.Name = "NUD_TimeFdev_up";
            this.NUD_TimeFdev_up.Size = new System.Drawing.Size(92, 26);
            this.NUD_TimeFdev_up.TabIndex = 2;
            this.NUD_TimeFdev_up.Value = new decimal(new int[] {
            114286,
            0,
            0,
            327680});
            this.NUD_TimeFdev_up.ValueChanged += new System.EventHandler(this.NUD_TimeFdev_ValueChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(135, 21);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "±";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 73);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 40);
            this.label7.TabIndex = 2;
            this.label7.Text = "Время подъема:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 11);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 40);
            this.label6.TabIndex = 1;
            this.label6.Text = "Девиция частоты УЗ:";
            // 
            // B_SetSweep
            // 
            this.B_SetSweep.Location = new System.Drawing.Point(600, 5);
            this.B_SetSweep.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.B_SetSweep.Name = "B_SetSweep";
            this.TLP_Sweep_EasyMode.SetRowSpan(this.B_SetSweep, 2);
            this.B_SetSweep.Size = new System.Drawing.Size(72, 114);
            this.B_SetSweep.TabIndex = 3;
            this.B_SetSweep.Text = "Set Sweep";
            this.B_SetSweep.UseVisualStyleBackColor = true;
            this.B_SetSweep.Click += new System.EventHandler(this.B_SetSweep_Click);
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(317, 83);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(115, 20);
            this.label16.TabIndex = 4;
            this.label16.Text = "Время спуска:";
            // 
            // NUD_TimeFdev_down
            // 
            this.NUD_TimeFdev_down.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NUD_TimeFdev_down.DecimalPlaces = 5;
            this.NUD_TimeFdev_down.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.NUD_TimeFdev_down.Location = new System.Drawing.Point(444, 80);
            this.NUD_TimeFdev_down.Margin = new System.Windows.Forms.Padding(0);
            this.NUD_TimeFdev_down.Maximum = new decimal(new int[] {
            74842,
            0,
            0,
            131072});
            this.NUD_TimeFdev_down.Name = "NUD_TimeFdev_down";
            this.NUD_TimeFdev_down.Size = new System.Drawing.Size(92, 26);
            this.NUD_TimeFdev_down.TabIndex = 5;
            this.NUD_TimeFdev_down.Value = new decimal(new int[] {
            114286,
            0,
            0,
            327680});
            this.NUD_TimeFdev_down.ValueChanged += new System.EventHandler(this.NUD_TimeFdev_down_ValueChanged);
            // 
            // NUD_Steps_on_Sweep
            // 
            this.NUD_Steps_on_Sweep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NUD_Steps_on_Sweep.Location = new System.Drawing.Point(444, 18);
            this.NUD_Steps_on_Sweep.Margin = new System.Windows.Forms.Padding(0);
            this.NUD_Steps_on_Sweep.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NUD_Steps_on_Sweep.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.NUD_Steps_on_Sweep.Name = "NUD_Steps_on_Sweep";
            this.NUD_Steps_on_Sweep.Size = new System.Drawing.Size(92, 26);
            this.NUD_Steps_on_Sweep.TabIndex = 7;
            this.NUD_Steps_on_Sweep.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.NUD_Steps_on_Sweep.ValueChanged += new System.EventHandler(this.NUD_Steps_on_Sweep_ValueChanged);
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(317, 11);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(104, 40);
            this.label19.TabIndex = 6;
            this.label19.Text = "Количество шагов:";
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(257, 21);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(52, 20);
            this.label20.TabIndex = 8;
            this.label20.Text = "МГц";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(259, 83);
            this.label21.Margin = new System.Windows.Forms.Padding(6, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(50, 20);
            this.label21.TabIndex = 9;
            this.label21.Text = "мкс";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TLP_Sweep_ProgramMode
            // 
            this.TLP_Sweep_ProgramMode.ColumnCount = 3;
            this.TLP_Sweep_ProgramMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLP_Sweep_ProgramMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.TLP_Sweep_ProgramMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.TLP_Sweep_ProgramMode.Controls.Add(this.ChB_ProgrammSweep_toogler, 0, 1);
            this.TLP_Sweep_ProgramMode.Controls.Add(this.B_BrowseCSVCurve, 2, 0);
            this.TLP_Sweep_ProgramMode.Controls.Add(this.TB_CSVCurveFolder, 0, 0);
            this.TLP_Sweep_ProgramMode.Controls.Add(this.B_EditCurve, 2, 1);
            this.TLP_Sweep_ProgramMode.Controls.Add(this.B_CreateData, 1, 1);
            this.TLP_Sweep_ProgramMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_Sweep_ProgramMode.Location = new System.Drawing.Point(677, 46);
            this.TLP_Sweep_ProgramMode.Margin = new System.Windows.Forms.Padding(0);
            this.TLP_Sweep_ProgramMode.Name = "TLP_Sweep_ProgramMode";
            this.TLP_Sweep_ProgramMode.RowCount = 3;
            this.TLP_Sweep_ProgramMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.TLP_Sweep_ProgramMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.TLP_Sweep_ProgramMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_Sweep_ProgramMode.Size = new System.Drawing.Size(677, 179);
            this.TLP_Sweep_ProgramMode.TabIndex = 2;
            // 
            // ChB_ProgrammSweep_toogler
            // 
            this.ChB_ProgrammSweep_toogler.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChB_ProgrammSweep_toogler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChB_ProgrammSweep_toogler.Location = new System.Drawing.Point(4, 67);
            this.ChB_ProgrammSweep_toogler.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChB_ProgrammSweep_toogler.Name = "ChB_ProgrammSweep_toogler";
            this.ChB_ProgrammSweep_toogler.Size = new System.Drawing.Size(217, 52);
            this.ChB_ProgrammSweep_toogler.TabIndex = 0;
            this.ChB_ProgrammSweep_toogler.Text = "Перестройка";
            this.ChB_ProgrammSweep_toogler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChB_ProgrammSweep_toogler.UseVisualStyleBackColor = true;
            this.ChB_ProgrammSweep_toogler.CheckedChanged += new System.EventHandler(this.ChB_ProgrammSweep_toogler_CheckedChanged);
            // 
            // B_BrowseCSVCurve
            // 
            this.B_BrowseCSVCurve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_BrowseCSVCurve.Location = new System.Drawing.Point(454, 5);
            this.B_BrowseCSVCurve.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.B_BrowseCSVCurve.Name = "B_BrowseCSVCurve";
            this.B_BrowseCSVCurve.Size = new System.Drawing.Size(219, 52);
            this.B_BrowseCSVCurve.TabIndex = 2;
            this.B_BrowseCSVCurve.Text = "Обзор...";
            this.B_BrowseCSVCurve.UseVisualStyleBackColor = true;
            this.B_BrowseCSVCurve.Click += new System.EventHandler(this.B_BrowseCSVCurve_Click);
            // 
            // TB_CSVCurveFolder
            // 
            this.TB_CSVCurveFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TLP_Sweep_ProgramMode.SetColumnSpan(this.TB_CSVCurveFolder, 2);
            this.TB_CSVCurveFolder.Location = new System.Drawing.Point(4, 18);
            this.TB_CSVCurveFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_CSVCurveFolder.Name = "TB_CSVCurveFolder";
            this.TB_CSVCurveFolder.Size = new System.Drawing.Size(442, 26);
            this.TB_CSVCurveFolder.TabIndex = 1;
            // 
            // B_EditCurve
            // 
            this.B_EditCurve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_EditCurve.Enabled = false;
            this.B_EditCurve.Location = new System.Drawing.Point(453, 65);
            this.B_EditCurve.Name = "B_EditCurve";
            this.B_EditCurve.Size = new System.Drawing.Size(221, 56);
            this.B_EditCurve.TabIndex = 3;
            this.B_EditCurve.Text = "Редактировать кривую (coming soon)";
            this.B_EditCurve.UseVisualStyleBackColor = true;
            // 
            // B_CreateData
            // 
            this.B_CreateData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_CreateData.Location = new System.Drawing.Point(228, 65);
            this.B_CreateData.Name = "B_CreateData";
            this.B_CreateData.Size = new System.Drawing.Size(219, 56);
            this.B_CreateData.TabIndex = 4;
            this.B_CreateData.Text = "Синтезировать данные";
            this.B_CreateData.UseVisualStyleBackColor = true;
            this.B_CreateData.Click += new System.EventHandler(this.B_CreateData_Click);
            // 
            // TLP_STCspecial_Fun
            // 
            this.TLP_STCspecial_Fun.ColumnCount = 3;
            this.TLP_STCspecial_Fun.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLP_STCspecial_Fun.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLP_STCspecial_Fun.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.TLP_STCspecial_Fun.Controls.Add(this.B_setHZSpecialSTC, 2, 0);
            this.TLP_STCspecial_Fun.Controls.Add(this.label4, 0, 0);
            this.TLP_STCspecial_Fun.Controls.Add(this.NUD_PowerDecrement, 0, 1);
            this.TLP_STCspecial_Fun.Controls.Add(this.ChB_Remember_AT, 1, 1);
            this.TLP_STCspecial_Fun.Controls.Add(this.B_Test, 1, 0);
            this.TLP_STCspecial_Fun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_STCspecial_Fun.Location = new System.Drawing.Point(0, 184);
            this.TLP_STCspecial_Fun.Margin = new System.Windows.Forms.Padding(0);
            this.TLP_STCspecial_Fun.Name = "TLP_STCspecial_Fun";
            this.TLP_STCspecial_Fun.RowCount = 2;
            this.TLP_STCspecial_Fun.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_STCspecial_Fun.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_STCspecial_Fun.Size = new System.Drawing.Size(1354, 77);
            this.TLP_STCspecial_Fun.TabIndex = 85;
            this.TLP_STCspecial_Fun.Visible = false;
            // 
            // B_setHZSpecialSTC
            // 
            this.B_setHZSpecialSTC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_setHZSpecialSTC.Location = new System.Drawing.Point(540, 0);
            this.B_setHZSpecialSTC.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.B_setHZSpecialSTC.Name = "B_setHZSpecialSTC";
            this.TLP_STCspecial_Fun.SetRowSpan(this.B_setHZSpecialSTC, 2);
            this.B_setHZSpecialSTC.Size = new System.Drawing.Size(812, 77);
            this.B_setHZSpecialSTC.TabIndex = 6;
            this.B_setHZSpecialSTC.Text = "Установить с учетом к.осл.";
            this.B_setHZSpecialSTC.UseVisualStyleBackColor = true;
            this.B_setHZSpecialSTC.Click += new System.EventHandler(this.B_setHZSpecialSTC_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "К.Ослабления";
            // 
            // NUD_PowerDecrement
            // 
            this.NUD_PowerDecrement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NUD_PowerDecrement.Location = new System.Drawing.Point(4, 43);
            this.NUD_PowerDecrement.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NUD_PowerDecrement.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.NUD_PowerDecrement.Minimum = new decimal(new int[] {
            1700,
            0,
            0,
            0});
            this.NUD_PowerDecrement.Name = "NUD_PowerDecrement";
            this.NUD_PowerDecrement.Size = new System.Drawing.Size(262, 26);
            this.NUD_PowerDecrement.TabIndex = 4;
            this.NUD_PowerDecrement.Value = new decimal(new int[] {
            1700,
            0,
            0,
            0});
            this.NUD_PowerDecrement.ValueChanged += new System.EventHandler(this.NUD_PowerDecrement_ValueChanged);
            // 
            // ChB_Remember_AT
            // 
            this.ChB_Remember_AT.AutoSize = true;
            this.ChB_Remember_AT.Location = new System.Drawing.Point(274, 43);
            this.ChB_Remember_AT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChB_Remember_AT.Name = "ChB_Remember_AT";
            this.ChB_Remember_AT.Size = new System.Drawing.Size(248, 24);
            this.ChB_Remember_AT.TabIndex = 7;
            this.ChB_Remember_AT.Text = "Запомнить для всех частот";
            this.ChB_Remember_AT.UseVisualStyleBackColor = true;
            // 
            // B_Test
            // 
            this.B_Test.Location = new System.Drawing.Point(274, 5);
            this.B_Test.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.B_Test.Name = "B_Test";
            this.B_Test.Size = new System.Drawing.Size(112, 28);
            this.B_Test.TabIndex = 8;
            this.B_Test.Text = "MF Test";
            this.B_Test.UseVisualStyleBackColor = true;
            this.B_Test.Click += new System.EventHandler(this.B_Test_Click);
            // 
            // LBConsole
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.LBConsole, 3);
            this.LBConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBConsole.ForeColor = System.Drawing.SystemColors.WindowText;
            this.LBConsole.FormattingEnabled = true;
            this.LBConsole.ItemHeight = 20;
            this.LBConsole.Location = new System.Drawing.Point(6, 731);
            this.LBConsole.Margin = new System.Windows.Forms.Padding(6);
            this.LBConsole.Name = "LBConsole";
            this.LBConsole.Size = new System.Drawing.Size(1358, 142);
            this.LBConsole.TabIndex = 64;
            // 
            // B_Quit
            // 
            this.B_Quit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Quit.Location = new System.Drawing.Point(4, 879);
            this.B_Quit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 5);
            this.B_Quit.Name = "B_Quit";
            this.B_Quit.Size = new System.Drawing.Size(1362, 41);
            this.B_Quit.TabIndex = 53;
            this.B_Quit.Text = "Выход";
            this.B_Quit.UseVisualStyleBackColor = true;
            this.B_Quit.Click += new System.EventHandler(this.B_Quit_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.TSMI_CreateCurve});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1370, 33);
            this.menuStrip1.TabIndex = 83;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // TSMI_CreateCurve
            // 
            this.TSMI_CreateCurve.Name = "TSMI_CreateCurve";
            this.TSMI_CreateCurve.Size = new System.Drawing.Size(286, 29);
            this.TSMI_CreateCurve.Text = "Изменить кривую перестройки";
            this.TSMI_CreateCurve.Click += new System.EventHandler(this.TSMI_CreateCurve_Click);
            // 
            // BGW_Sweep_Curve
            // 
            this.BGW_Sweep_Curve.WorkerSupportsCancellation = true;
            this.BGW_Sweep_Curve.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGW_Sweep_Curve_DoWork);
            this.BGW_Sweep_Curve.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGW_Sweep_Curve_RunWorkerCompleted);
            // 
            // Timer_sweepChecker
            // 
            this.Timer_sweepChecker.Enabled = true;
            this.Timer_sweepChecker.Interval = 50;
            this.Timer_sweepChecker.Tick += new System.EventHandler(this.Timer_sweepChecker_Tick);
            // 
            // BGW_ProgrammedTuning
            // 
            this.BGW_ProgrammedTuning.WorkerSupportsCancellation = true;
            this.BGW_ProgrammedTuning.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGW_ProgrammedTuning_DoWork);
            this.BGW_ProgrammedTuning.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGW_ProgrammedTuning_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 958);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel30.ResumeLayout(false);
            this.tableLayoutPanel30.PerformLayout();
            this.GB_AllAOFControls.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.TLP_SetControls.ResumeLayout(false);
            this.TLP_SetControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Incr_CurMHz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_CurMHz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_CurWL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_AO_Timeout_Value)).EndInit();
            this.TLP_WLSlidingControls.ResumeLayout(false);
            this.TLP_WLSlidingControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TRB_SoundFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrB_CurrentWL)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.Pan_SweepControls.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.TLP_Sweep_EasyMode.ResumeLayout(false);
            this.TLP_Sweep_EasyMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_FreqDeviation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_TimeFdev_up)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_TimeFdev_down)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Steps_on_Sweep)).EndInit();
            this.TLP_Sweep_ProgramMode.ResumeLayout(false);
            this.TLP_Sweep_ProgramMode.PerformLayout();
            this.TLP_STCspecial_Fun.ResumeLayout(false);
            this.TLP_STCspecial_Fun.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_PowerDecrement)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel30;
        private System.Windows.Forms.CheckBox ChB_Power;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label L_RealDevName;
        private System.Windows.Forms.Button BDevOpen;
        private System.Windows.Forms.Label L_RequiredDevName;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox GB_AllAOFControls;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel TLP_WLSlidingControls;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar TrB_CurrentWL;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Panel Pan_SweepControls;
        private System.Windows.Forms.TableLayoutPanel TLP_Sweep_EasyMode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown NUD_FreqDeviation;
        private System.Windows.Forms.NumericUpDown NUD_TimeFdev_up;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button B_Quit;
        private System.Windows.Forms.ListBox LBConsole;
        private System.Windows.Forms.TrackBar TRB_SoundFreq;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSMI_CreateCurve;
        private System.Windows.Forms.RadioButton RB_Sweep_EasyMode;
        private System.Windows.Forms.RadioButton RB_Sweep_SpeciallMode;
        private System.Windows.Forms.CheckBox ChB_SweepEnabled;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel TLP_Sweep_ProgramMode;
        private System.Windows.Forms.CheckBox ChB_ProgrammSweep_toogler;
        private System.ComponentModel.BackgroundWorker BGW_Sweep_Curve;
        private System.Windows.Forms.Timer Timer_sweepChecker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel TLP_SetControls;
        private System.Windows.Forms.Button BSetWL;
        private System.Windows.Forms.CheckBox ChB_AutoSetWL;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.NumericUpDown NUD_CurMHz;
        private System.Windows.Forms.NumericUpDown NUD_CurWL;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel TLP_STCspecial_Fun;
        private System.Windows.Forms.Button B_setHZSpecialSTC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NUD_PowerDecrement;
        private System.Windows.Forms.CheckBox ChB_Remember_AT;
        private System.Windows.Forms.Button B_SetSweep;
        private System.Windows.Forms.NumericUpDown NUD_Incr_CurMHz;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown NUD_AO_Timeout_Value;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox ChB_TimeOut;
        private System.Windows.Forms.TextBox TB_CSVCurveFolder;
        private System.Windows.Forms.Button B_BrowseCSVCurve;
        private System.Windows.Forms.Button B_EditCurve;
        private System.ComponentModel.BackgroundWorker BGW_ProgrammedTuning;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown NUD_TimeFdev_down;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown NUD_Steps_on_Sweep;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button B_Test;
        private System.Windows.Forms.Button B_CreateData;
    }
}

