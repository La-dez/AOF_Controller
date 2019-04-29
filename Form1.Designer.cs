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
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.TRB_SoundFreq = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.TLP_SetControls = new System.Windows.Forms.TableLayoutPanel();
            this.BSetWL = new System.Windows.Forms.Button();
            this.tableLayoutPanel24 = new System.Windows.Forms.TableLayoutPanel();
            this.ChB_AutoSetWL = new System.Windows.Forms.CheckBox();
            this.label28 = new System.Windows.Forms.Label();
            this.NUD_CurMHz = new System.Windows.Forms.NumericUpDown();
            this.NUD_CurWL = new System.Windows.Forms.NumericUpDown();
            this.label29 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TLP_WLSlidingControls = new System.Windows.Forms.TableLayoutPanel();
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
            this.NUD_TimeFdev = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TLP_Sweep_ProgramMode = new System.Windows.Forms.TableLayoutPanel();
            this.ChB_ProgrammSweep_toogler = new System.Windows.Forms.CheckBox();
            this.TLP_STCspecial_Fun = new System.Windows.Forms.TableLayoutPanel();
            this.B_setHZSpecialSTC = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.NUD_PowerDecrement = new System.Windows.Forms.NumericUpDown();
            this.LBConsole = new System.Windows.Forms.ListBox();
            this.B_Quit = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_CreateCurve = new System.Windows.Forms.ToolStripMenuItem();
            this.BGW_Sweep_Curve = new System.ComponentModel.BackgroundWorker();
            this.Timer_sweepChecker = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel30.SuspendLayout();
            this.GB_AllAOFControls.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TRB_SoundFreq)).BeginInit();
            this.TLP_SetControls.SuspendLayout();
            this.tableLayoutPanel24.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_CurMHz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_CurWL)).BeginInit();
            this.TLP_WLSlidingControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrB_CurrentWL)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.Pan_SweepControls.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.TLP_Sweep_EasyMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_FreqDeviation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_TimeFdev)).BeginInit();
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(949, 578);
            this.tableLayoutPanel2.TabIndex = 82;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel30);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(943, 94);
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
            this.tableLayoutPanel30.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel30.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel30.Name = "tableLayoutPanel30";
            this.tableLayoutPanel30.RowCount = 3;
            this.tableLayoutPanel30.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel30.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel30.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel30.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel30.Size = new System.Drawing.Size(937, 75);
            this.tableLayoutPanel30.TabIndex = 80;
            // 
            // ChB_Power
            // 
            this.ChB_Power.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChB_Power.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChB_Power.Location = new System.Drawing.Point(656, 1);
            this.ChB_Power.Margin = new System.Windows.Forms.Padding(1);
            this.ChB_Power.Name = "ChB_Power";
            this.ChB_Power.Size = new System.Drawing.Size(280, 23);
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
            this.label18.Location = new System.Drawing.Point(3, 56);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(135, 13);
            this.label18.TabIndex = 79;
            this.label18.Text = "Загруженный .dev файл :";
            // 
            // L_RealDevName
            // 
            this.L_RealDevName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.L_RealDevName.AutoSize = true;
            this.tableLayoutPanel30.SetColumnSpan(this.L_RealDevName, 2);
            this.L_RealDevName.Location = new System.Drawing.Point(903, 56);
            this.L_RealDevName.Name = "L_RealDevName";
            this.L_RealDevName.Size = new System.Drawing.Size(31, 13);
            this.L_RealDevName.TabIndex = 80;
            this.L_RealDevName.Text = "none";
            // 
            // BDevOpen
            // 
            this.tableLayoutPanel30.SetColumnSpan(this.BDevOpen, 2);
            this.BDevOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BDevOpen.Location = new System.Drawing.Point(282, 1);
            this.BDevOpen.Margin = new System.Windows.Forms.Padding(1);
            this.BDevOpen.Name = "BDevOpen";
            this.BDevOpen.Size = new System.Drawing.Size(372, 23);
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
            this.L_RequiredDevName.Location = new System.Drawing.Point(867, 31);
            this.L_RequiredDevName.Name = "L_RequiredDevName";
            this.L_RequiredDevName.Size = new System.Drawing.Size(67, 13);
            this.L_RequiredDevName.TabIndex = 13;
            this.L_RequiredDevName.Text = "filename.dev";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.tableLayoutPanel30.SetColumnSpan(this.label17, 2);
            this.label17.Location = new System.Drawing.Point(3, 31);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(462, 13);
            this.label17.TabIndex = 78;
            this.label17.Text = "Требуемый .dev файл :";
            // 
            // GB_AllAOFControls
            // 
            this.GB_AllAOFControls.Controls.Add(this.tableLayoutPanel1);
            this.GB_AllAOFControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GB_AllAOFControls.Location = new System.Drawing.Point(3, 103);
            this.GB_AllAOFControls.Name = "GB_AllAOFControls";
            this.GB_AllAOFControls.Size = new System.Drawing.Size(943, 342);
            this.GB_AllAOFControls.TabIndex = 53;
            this.GB_AllAOFControls.TabStop = false;
            this.GB_AllAOFControls.Text = "Настройки длины волны пропускания:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.TLP_SetControls, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TLP_WLSlidingControls, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.TLP_STCspecial_Fun, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(937, 323);
            this.tableLayoutPanel1.TabIndex = 80;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel4.Controls.Add(this.TRB_SoundFreq, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 90);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(937, 30);
            this.tableLayoutPanel4.TabIndex = 84;
            // 
            // TRB_SoundFreq
            // 
            this.TRB_SoundFreq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TRB_SoundFreq.Location = new System.Drawing.Point(3, 3);
            this.TRB_SoundFreq.Maximum = 150000;
            this.TRB_SoundFreq.Minimum = 20000;
            this.TRB_SoundFreq.Name = "TRB_SoundFreq";
            this.TRB_SoundFreq.Size = new System.Drawing.Size(876, 24);
            this.TRB_SoundFreq.TabIndex = 35;
            this.TRB_SoundFreq.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TRB_SoundFreq.Value = 40000;
            this.TRB_SoundFreq.Scroll += new System.EventHandler(this.TRB_SoundFreq_Scroll);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(885, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 82;
            this.label2.Text = "МГц";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TLP_SetControls
            // 
            this.TLP_SetControls.ColumnCount = 6;
            this.TLP_SetControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.TLP_SetControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLP_SetControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TLP_SetControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLP_SetControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TLP_SetControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.TLP_SetControls.Controls.Add(this.BSetWL, 5, 0);
            this.TLP_SetControls.Controls.Add(this.tableLayoutPanel24, 0, 0);
            this.TLP_SetControls.Controls.Add(this.NUD_CurMHz, 3, 0);
            this.TLP_SetControls.Controls.Add(this.NUD_CurWL, 1, 0);
            this.TLP_SetControls.Controls.Add(this.label29, 2, 0);
            this.TLP_SetControls.Controls.Add(this.label3, 4, 0);
            this.TLP_SetControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_SetControls.Location = new System.Drawing.Point(0, 0);
            this.TLP_SetControls.Margin = new System.Windows.Forms.Padding(0);
            this.TLP_SetControls.Name = "TLP_SetControls";
            this.TLP_SetControls.RowCount = 1;
            this.TLP_SetControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_SetControls.Size = new System.Drawing.Size(937, 60);
            this.TLP_SetControls.TabIndex = 81;
            // 
            // BSetWL
            // 
            this.BSetWL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BSetWL.Location = new System.Drawing.Point(406, 0);
            this.BSetWL.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.BSetWL.Name = "BSetWL";
            this.BSetWL.Size = new System.Drawing.Size(530, 60);
            this.BSetWL.TabIndex = 5;
            this.BSetWL.Text = "Установить";
            this.BSetWL.UseVisualStyleBackColor = true;
            this.BSetWL.Click += new System.EventHandler(this.BSetWL_Click);
            // 
            // tableLayoutPanel24
            // 
            this.tableLayoutPanel24.ColumnCount = 2;
            this.tableLayoutPanel24.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel24.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel24.Controls.Add(this.ChB_AutoSetWL, 0, 0);
            this.tableLayoutPanel24.Controls.Add(this.label28, 1, 0);
            this.tableLayoutPanel24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel24.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel24.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel24.Name = "tableLayoutPanel24";
            this.tableLayoutPanel24.RowCount = 1;
            this.tableLayoutPanel24.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel24.Size = new System.Drawing.Size(100, 60);
            this.tableLayoutPanel24.TabIndex = 82;
            // 
            // ChB_AutoSetWL
            // 
            this.ChB_AutoSetWL.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ChB_AutoSetWL.AutoSize = true;
            this.ChB_AutoSetWL.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChB_AutoSetWL.Location = new System.Drawing.Point(2, 23);
            this.ChB_AutoSetWL.Margin = new System.Windows.Forms.Padding(0);
            this.ChB_AutoSetWL.Name = "ChB_AutoSetWL";
            this.ChB_AutoSetWL.Size = new System.Drawing.Size(15, 14);
            this.ChB_AutoSetWL.TabIndex = 35;
            this.ChB_AutoSetWL.UseVisualStyleBackColor = true;
            this.ChB_AutoSetWL.CheckedChanged += new System.EventHandler(this.ChBAutoSetWL_CheckedChanged);
            // 
            // label28
            // 
            this.label28.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(25, 17);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(72, 26);
            this.label28.TabIndex = 51;
            this.label28.Text = "Управление ползунком";
            this.label28.Click += new System.EventHandler(this.label28_Click);
            // 
            // NUD_CurMHz
            // 
            this.NUD_CurMHz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NUD_CurMHz.DecimalPlaces = 3;
            this.NUD_CurMHz.Location = new System.Drawing.Point(253, 20);
            this.NUD_CurMHz.Margin = new System.Windows.Forms.Padding(0);
            this.NUD_CurMHz.Name = "NUD_CurMHz";
            this.NUD_CurMHz.Size = new System.Drawing.Size(113, 20);
            this.NUD_CurMHz.TabIndex = 84;
            this.NUD_CurMHz.ValueChanged += new System.EventHandler(this.NUD_CurMHz_ValueChanged);
            // 
            // NUD_CurWL
            // 
            this.NUD_CurWL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NUD_CurWL.DecimalPlaces = 2;
            this.NUD_CurWL.Location = new System.Drawing.Point(100, 20);
            this.NUD_CurWL.Margin = new System.Windows.Forms.Padding(0);
            this.NUD_CurWL.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.NUD_CurWL.Name = "NUD_CurWL";
            this.NUD_CurWL.Size = new System.Drawing.Size(113, 20);
            this.NUD_CurWL.TabIndex = 83;
            this.NUD_CurWL.ValueChanged += new System.EventHandler(this.NUD_CurWL_ValueChanged);
            // 
            // label29
            // 
            this.label29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(216, 23);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(34, 13);
            this.label29.TabIndex = 53;
            this.label29.Text = "нм";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(372, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 85;
            this.label3.Text = "МГц";
            // 
            // TLP_WLSlidingControls
            // 
            this.TLP_WLSlidingControls.ColumnCount = 2;
            this.TLP_WLSlidingControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_WLSlidingControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.TLP_WLSlidingControls.Controls.Add(this.label1, 1, 0);
            this.TLP_WLSlidingControls.Controls.Add(this.TrB_CurrentWL, 0, 0);
            this.TLP_WLSlidingControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_WLSlidingControls.Location = new System.Drawing.Point(0, 60);
            this.TLP_WLSlidingControls.Margin = new System.Windows.Forms.Padding(0);
            this.TLP_WLSlidingControls.Name = "TLP_WLSlidingControls";
            this.TLP_WLSlidingControls.RowCount = 1;
            this.TLP_WLSlidingControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_WLSlidingControls.Size = new System.Drawing.Size(937, 30);
            this.TLP_WLSlidingControls.TabIndex = 81;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(885, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 82;
            this.label1.Text = "нм";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrB_CurrentWL
            // 
            this.TrB_CurrentWL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TrB_CurrentWL.Location = new System.Drawing.Point(3, 3);
            this.TrB_CurrentWL.Maximum = 200000;
            this.TrB_CurrentWL.Name = "TrB_CurrentWL";
            this.TrB_CurrentWL.Size = new System.Drawing.Size(876, 24);
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
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 170);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(937, 153);
            this.tableLayoutPanel5.TabIndex = 2;
            this.tableLayoutPanel5.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel5_Paint);
            // 
            // ChB_SweepEnabled
            // 
            this.ChB_SweepEnabled.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ChB_SweepEnabled.AutoSize = true;
            this.ChB_SweepEnabled.Location = new System.Drawing.Point(3, 6);
            this.ChB_SweepEnabled.Name = "ChB_SweepEnabled";
            this.ChB_SweepEnabled.Size = new System.Drawing.Size(188, 17);
            this.ChB_SweepEnabled.TabIndex = 1;
            this.ChB_SweepEnabled.Text = "Линейно - частотная модуляция";
            this.ChB_SweepEnabled.UseVisualStyleBackColor = true;
            this.ChB_SweepEnabled.CheckedChanged += new System.EventHandler(this.ChB_SweepEnabled_CheckedChanged);
            // 
            // Pan_SweepControls
            // 
            this.Pan_SweepControls.Controls.Add(this.tableLayoutPanel3);
            this.Pan_SweepControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pan_SweepControls.Location = new System.Drawing.Point(0, 30);
            this.Pan_SweepControls.Margin = new System.Windows.Forms.Padding(0);
            this.Pan_SweepControls.Name = "Pan_SweepControls";
            this.Pan_SweepControls.Size = new System.Drawing.Size(937, 123);
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
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(937, 123);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // RB_Sweep_SpeciallMode
            // 
            this.RB_Sweep_SpeciallMode.AutoSize = true;
            this.RB_Sweep_SpeciallMode.Location = new System.Drawing.Point(471, 3);
            this.RB_Sweep_SpeciallMode.Name = "RB_Sweep_SpeciallMode";
            this.RB_Sweep_SpeciallMode.Size = new System.Drawing.Size(121, 17);
            this.RB_Sweep_SpeciallMode.TabIndex = 1;
            this.RB_Sweep_SpeciallMode.Text = "Программируемая";
            this.RB_Sweep_SpeciallMode.UseVisualStyleBackColor = true;
            this.RB_Sweep_SpeciallMode.CheckedChanged += new System.EventHandler(this.RB_Sweep_SpeciallMode_CheckedChanged);
            // 
            // RB_Sweep_EasyMode
            // 
            this.RB_Sweep_EasyMode.AutoSize = true;
            this.RB_Sweep_EasyMode.Checked = true;
            this.RB_Sweep_EasyMode.Location = new System.Drawing.Point(3, 3);
            this.RB_Sweep_EasyMode.Name = "RB_Sweep_EasyMode";
            this.RB_Sweep_EasyMode.Size = new System.Drawing.Size(158, 17);
            this.RB_Sweep_EasyMode.TabIndex = 0;
            this.RB_Sweep_EasyMode.TabStop = true;
            this.RB_Sweep_EasyMode.Text = "На заданной длине волны";
            this.RB_Sweep_EasyMode.UseVisualStyleBackColor = true;
            this.RB_Sweep_EasyMode.CheckedChanged += new System.EventHandler(this.RB_Sweep_EasyMode_CheckedChanged);
            // 
            // TLP_Sweep_EasyMode
            // 
            this.TLP_Sweep_EasyMode.ColumnCount = 4;
            this.TLP_Sweep_EasyMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLP_Sweep_EasyMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333334F));
            this.TLP_Sweep_EasyMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.TLP_Sweep_EasyMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.TLP_Sweep_EasyMode.Controls.Add(this.label9, 3, 0);
            this.TLP_Sweep_EasyMode.Controls.Add(this.label10, 3, 1);
            this.TLP_Sweep_EasyMode.Controls.Add(this.NUD_FreqDeviation, 2, 0);
            this.TLP_Sweep_EasyMode.Controls.Add(this.NUD_TimeFdev, 2, 1);
            this.TLP_Sweep_EasyMode.Controls.Add(this.label8, 1, 0);
            this.TLP_Sweep_EasyMode.Controls.Add(this.label7, 0, 1);
            this.TLP_Sweep_EasyMode.Controls.Add(this.label6, 0, 0);
            this.TLP_Sweep_EasyMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_Sweep_EasyMode.Location = new System.Drawing.Point(0, 30);
            this.TLP_Sweep_EasyMode.Margin = new System.Windows.Forms.Padding(0);
            this.TLP_Sweep_EasyMode.Name = "TLP_Sweep_EasyMode";
            this.TLP_Sweep_EasyMode.RowCount = 3;
            this.TLP_Sweep_EasyMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TLP_Sweep_EasyMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TLP_Sweep_EasyMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_Sweep_EasyMode.Size = new System.Drawing.Size(468, 93);
            this.TLP_Sweep_EasyMode.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(379, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "МГц";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(380, 53);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "мс";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NUD_FreqDeviation
            // 
            this.NUD_FreqDeviation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NUD_FreqDeviation.DecimalPlaces = 3;
            this.NUD_FreqDeviation.Location = new System.Drawing.Point(125, 10);
            this.NUD_FreqDeviation.Margin = new System.Windows.Forms.Padding(0);
            this.NUD_FreqDeviation.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NUD_FreqDeviation.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.NUD_FreqDeviation.Name = "NUD_FreqDeviation";
            this.NUD_FreqDeviation.Size = new System.Drawing.Size(251, 20);
            this.NUD_FreqDeviation.TabIndex = 1;
            this.NUD_FreqDeviation.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.NUD_FreqDeviation.ValueChanged += new System.EventHandler(this.NUD_FreqDeviation_ValueChanged);
            // 
            // NUD_TimeFdev
            // 
            this.NUD_TimeFdev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NUD_TimeFdev.DecimalPlaces = 3;
            this.NUD_TimeFdev.Location = new System.Drawing.Point(125, 50);
            this.NUD_TimeFdev.Margin = new System.Windows.Forms.Padding(0);
            this.NUD_TimeFdev.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.NUD_TimeFdev.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NUD_TimeFdev.Name = "NUD_TimeFdev";
            this.NUD_TimeFdev.Size = new System.Drawing.Size(251, 20);
            this.NUD_TimeFdev.TabIndex = 2;
            this.NUD_TimeFdev.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NUD_TimeFdev.ValueChanged += new System.EventHandler(this.NUD_TimeFdev_ValueChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(97, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "±";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 26);
            this.label7.TabIndex = 2;
            this.label7.Text = "Время одной девиации:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 26);
            this.label6.TabIndex = 1;
            this.label6.Text = "Девиция частоты УЗ:";
            // 
            // TLP_Sweep_ProgramMode
            // 
            this.TLP_Sweep_ProgramMode.ColumnCount = 2;
            this.TLP_Sweep_ProgramMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Sweep_ProgramMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Sweep_ProgramMode.Controls.Add(this.ChB_ProgrammSweep_toogler, 0, 0);
            this.TLP_Sweep_ProgramMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_Sweep_ProgramMode.Location = new System.Drawing.Point(468, 30);
            this.TLP_Sweep_ProgramMode.Margin = new System.Windows.Forms.Padding(0);
            this.TLP_Sweep_ProgramMode.Name = "TLP_Sweep_ProgramMode";
            this.TLP_Sweep_ProgramMode.RowCount = 2;
            this.TLP_Sweep_ProgramMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Sweep_ProgramMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Sweep_ProgramMode.Size = new System.Drawing.Size(469, 93);
            this.TLP_Sweep_ProgramMode.TabIndex = 2;
            // 
            // ChB_ProgrammSweep_toogler
            // 
            this.ChB_ProgrammSweep_toogler.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChB_ProgrammSweep_toogler.Location = new System.Drawing.Point(3, 3);
            this.ChB_ProgrammSweep_toogler.Name = "ChB_ProgrammSweep_toogler";
            this.ChB_ProgrammSweep_toogler.Size = new System.Drawing.Size(129, 36);
            this.ChB_ProgrammSweep_toogler.TabIndex = 0;
            this.ChB_ProgrammSweep_toogler.Text = "Перестройка";
            this.ChB_ProgrammSweep_toogler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChB_ProgrammSweep_toogler.UseVisualStyleBackColor = true;
            this.ChB_ProgrammSweep_toogler.CheckedChanged += new System.EventHandler(this.ChB_ProgrammSweep_toogler_CheckedChanged);
            // 
            // TLP_STCspecial_Fun
            // 
            this.TLP_STCspecial_Fun.ColumnCount = 2;
            this.TLP_STCspecial_Fun.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.70011F));
            this.TLP_STCspecial_Fun.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.29989F));
            this.TLP_STCspecial_Fun.Controls.Add(this.B_setHZSpecialSTC, 1, 0);
            this.TLP_STCspecial_Fun.Controls.Add(this.label4, 0, 0);
            this.TLP_STCspecial_Fun.Controls.Add(this.NUD_PowerDecrement, 0, 1);
            this.TLP_STCspecial_Fun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_STCspecial_Fun.Location = new System.Drawing.Point(0, 120);
            this.TLP_STCspecial_Fun.Margin = new System.Windows.Forms.Padding(0);
            this.TLP_STCspecial_Fun.Name = "TLP_STCspecial_Fun";
            this.TLP_STCspecial_Fun.RowCount = 2;
            this.TLP_STCspecial_Fun.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_STCspecial_Fun.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_STCspecial_Fun.Size = new System.Drawing.Size(937, 50);
            this.TLP_STCspecial_Fun.TabIndex = 85;
            this.TLP_STCspecial_Fun.Visible = false;
            // 
            // B_setHZSpecialSTC
            // 
            this.B_setHZSpecialSTC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_setHZSpecialSTC.Location = new System.Drawing.Point(165, 0);
            this.B_setHZSpecialSTC.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.B_setHZSpecialSTC.Name = "B_setHZSpecialSTC";
            this.TLP_STCspecial_Fun.SetRowSpan(this.B_setHZSpecialSTC, 2);
            this.B_setHZSpecialSTC.Size = new System.Drawing.Size(771, 50);
            this.B_setHZSpecialSTC.TabIndex = 6;
            this.B_setHZSpecialSTC.Text = "Установить с учетом к.осл.";
            this.B_setHZSpecialSTC.UseVisualStyleBackColor = true;
            this.B_setHZSpecialSTC.Click += new System.EventHandler(this.B_setHZSpecialSTC_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "К.Ослабления";
            // 
            // NUD_PowerDecrement
            // 
            this.NUD_PowerDecrement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NUD_PowerDecrement.Location = new System.Drawing.Point(3, 28);
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
            this.NUD_PowerDecrement.Size = new System.Drawing.Size(159, 20);
            this.NUD_PowerDecrement.TabIndex = 4;
            this.NUD_PowerDecrement.Value = new decimal(new int[] {
            1700,
            0,
            0,
            0});
            // 
            // LBConsole
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.LBConsole, 3);
            this.LBConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBConsole.ForeColor = System.Drawing.SystemColors.WindowText;
            this.LBConsole.FormattingEnabled = true;
            this.LBConsole.Location = new System.Drawing.Point(4, 452);
            this.LBConsole.Margin = new System.Windows.Forms.Padding(4);
            this.LBConsole.Name = "LBConsole";
            this.LBConsole.Size = new System.Drawing.Size(941, 92);
            this.LBConsole.TabIndex = 64;
            // 
            // B_Quit
            // 
            this.B_Quit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Quit.Location = new System.Drawing.Point(3, 548);
            this.B_Quit.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.B_Quit.Name = "B_Quit";
            this.B_Quit.Size = new System.Drawing.Size(943, 27);
            this.B_Quit.TabIndex = 53;
            this.B_Quit.Text = "Выход";
            this.B_Quit.UseVisualStyleBackColor = true;
            this.B_Quit.Click += new System.EventHandler(this.B_Quit_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.TSMI_CreateCurve});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(949, 24);
            this.menuStrip1.TabIndex = 83;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // TSMI_CreateCurve
            // 
            this.TSMI_CreateCurve.Name = "TSMI_CreateCurve";
            this.TSMI_CreateCurve.Size = new System.Drawing.Size(192, 20);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 602);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TRB_SoundFreq)).EndInit();
            this.TLP_SetControls.ResumeLayout(false);
            this.TLP_SetControls.PerformLayout();
            this.tableLayoutPanel24.ResumeLayout(false);
            this.tableLayoutPanel24.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_CurMHz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_CurWL)).EndInit();
            this.TLP_WLSlidingControls.ResumeLayout(false);
            this.TLP_WLSlidingControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrB_CurrentWL)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.Pan_SweepControls.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.TLP_Sweep_EasyMode.ResumeLayout(false);
            this.TLP_Sweep_EasyMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_FreqDeviation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_TimeFdev)).EndInit();
            this.TLP_Sweep_ProgramMode.ResumeLayout(false);
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
        private System.Windows.Forms.NumericUpDown NUD_TimeFdev;
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel TLP_SetControls;
        private System.Windows.Forms.Button BSetWL;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel24;
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
    }
}

