namespace Sensit.App.Datalogger
{
	partial class FormLog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLog));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.groupBoxMassFlow = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.textBoxFilename = new System.Windows.Forms.TextBox();
			this.buttonBrowse = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.buttonStop = new System.Windows.Forms.Button();
			this.buttonStart = new System.Windows.Forms.Button();
			this.tableLayoutPanelSerialPort = new System.Windows.Forms.TableLayoutPanel();
			this.labelComPort = new System.Windows.Forms.Label();
			this.comboBoxSerialPort = new System.Windows.Forms.ComboBox();
			this.buttonPortRefresh = new System.Windows.Forms.Button();
			this.labelBaudRate = new System.Windows.Forms.Label();
			this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
			this.labelStopBits = new System.Windows.Forms.Label();
			this.comboBoxStopBits = new System.Windows.Forms.ComboBox();
			this.labelParity = new System.Windows.Forms.Label();
			this.comboBoxParity = new System.Windows.Forms.ComboBox();
			this.radioButtonOpen = new System.Windows.Forms.RadioButton();
			this.radioButtonClosed = new System.Windows.Forms.RadioButton();
			this.groupBoxSerialPort = new System.Windows.Forms.GroupBox();
			this.groupBoxSample = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.groupBoxStop = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.numericUpDown7 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDown8 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDown9 = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
			this.groupBoxCommand = new System.Windows.Forms.GroupBox();
			this.textBoxCommand = new System.Windows.Forms.TextBox();
			this.groupBoxResponse = new System.Windows.Forms.GroupBox();
			this.textBoxResponse = new System.Windows.Forms.TextBox();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.groupBoxMassFlow.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanelSerialPort.SuspendLayout();
			this.groupBoxSerialPort.SuspendLayout();
			this.groupBoxSample.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
			this.groupBoxStop.SuspendLayout();
			this.tableLayoutPanel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown9)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
			this.groupBoxCommand.SuspendLayout();
			this.groupBoxResponse.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(384, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
			this.exitToolStripMenuItem.Text = "&Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 454);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(384, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
			this.toolStripStatusLabel1.Text = "Ready";
			// 
			// groupBoxMassFlow
			// 
			this.groupBoxMassFlow.AutoSize = true;
			this.groupBoxMassFlow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxMassFlow.Controls.Add(this.tableLayoutPanel1);
			this.groupBoxMassFlow.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBoxMassFlow.Location = new System.Drawing.Point(0, 24);
			this.groupBoxMassFlow.Name = "groupBoxMassFlow";
			this.groupBoxMassFlow.Size = new System.Drawing.Size(384, 48);
			this.groupBoxMassFlow.TabIndex = 7;
			this.groupBoxMassFlow.TabStop = false;
			this.groupBoxMassFlow.Text = "Filename";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.textBoxFilename, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.buttonBrowse, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(378, 29);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// textBoxFilename
			// 
			this.textBoxFilename.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxFilename.Location = new System.Drawing.Point(3, 3);
			this.textBoxFilename.Name = "textBoxFilename";
			this.textBoxFilename.Size = new System.Drawing.Size(291, 20);
			this.textBoxFilename.TabIndex = 9;
			// 
			// buttonBrowse
			// 
			this.buttonBrowse.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.buttonBrowse.Location = new System.Drawing.Point(300, 3);
			this.buttonBrowse.Name = "buttonBrowse";
			this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
			this.buttonBrowse.TabIndex = 2;
			this.buttonBrowse.Text = "Browse";
			this.buttonBrowse.UseVisualStyleBackColor = true;
			this.buttonBrowse.Click += new System.EventHandler(this.ButtonBrowse_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.AutoSize = true;
			this.groupBox4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBox4.Controls.Add(this.tableLayoutPanel3);
			this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox4.Location = new System.Drawing.Point(0, 400);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(384, 54);
			this.groupBox4.TabIndex = 13;
			this.groupBox4.TabStop = false;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.AutoSize = true;
			this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel3.ColumnCount = 1;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 0, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(378, 35);
			this.tableLayoutPanel3.TabIndex = 1;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Controls.Add(this.buttonStop, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.buttonStart, 0, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(108, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(162, 29);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// buttonStop
			// 
			this.buttonStop.Enabled = false;
			this.buttonStop.Location = new System.Drawing.Point(84, 3);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(75, 23);
			this.buttonStop.TabIndex = 1;
			this.buttonStop.Text = "Stop";
			this.buttonStop.UseVisualStyleBackColor = true;
			this.buttonStop.Click += new System.EventHandler(this.ButtonStop_Click);
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(3, 3);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(75, 23);
			this.buttonStart.TabIndex = 0;
			this.buttonStart.Text = "Start";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
			// 
			// tableLayoutPanelSerialPort
			// 
			this.tableLayoutPanelSerialPort.AutoSize = true;
			this.tableLayoutPanelSerialPort.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelSerialPort.ColumnCount = 6;
			this.tableLayoutPanelSerialPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelSerialPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelSerialPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelSerialPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelSerialPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelSerialPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelSerialPort.Controls.Add(this.labelComPort, 0, 0);
			this.tableLayoutPanelSerialPort.Controls.Add(this.comboBoxSerialPort, 1, 0);
			this.tableLayoutPanelSerialPort.Controls.Add(this.buttonPortRefresh, 2, 0);
			this.tableLayoutPanelSerialPort.Controls.Add(this.labelBaudRate, 0, 1);
			this.tableLayoutPanelSerialPort.Controls.Add(this.comboBoxBaudRate, 1, 1);
			this.tableLayoutPanelSerialPort.Controls.Add(this.labelStopBits, 3, 0);
			this.tableLayoutPanelSerialPort.Controls.Add(this.comboBoxStopBits, 4, 0);
			this.tableLayoutPanelSerialPort.Controls.Add(this.labelParity, 3, 1);
			this.tableLayoutPanelSerialPort.Controls.Add(this.comboBoxParity, 4, 1);
			this.tableLayoutPanelSerialPort.Controls.Add(this.radioButtonOpen, 5, 0);
			this.tableLayoutPanelSerialPort.Controls.Add(this.radioButtonClosed, 5, 1);
			this.tableLayoutPanelSerialPort.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanelSerialPort.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanelSerialPort.Name = "tableLayoutPanelSerialPort";
			this.tableLayoutPanelSerialPort.RowCount = 2;
			this.tableLayoutPanelSerialPort.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSerialPort.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSerialPort.Size = new System.Drawing.Size(378, 56);
			this.tableLayoutPanelSerialPort.TabIndex = 14;
			// 
			// labelComPort
			// 
			this.labelComPort.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelComPort.AutoSize = true;
			this.labelComPort.Location = new System.Drawing.Point(3, 8);
			this.labelComPort.Name = "labelComPort";
			this.labelComPort.Size = new System.Drawing.Size(56, 13);
			this.labelComPort.TabIndex = 0;
			this.labelComPort.Text = "COM Port:";
			// 
			// comboBoxSerialPort
			// 
			this.comboBoxSerialPort.AllowDrop = true;
			this.comboBoxSerialPort.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboBoxSerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSerialPort.FormattingEnabled = true;
			this.comboBoxSerialPort.Location = new System.Drawing.Point(70, 3);
			this.comboBoxSerialPort.Name = "comboBoxSerialPort";
			this.comboBoxSerialPort.Size = new System.Drawing.Size(72, 21);
			this.comboBoxSerialPort.TabIndex = 1;
			// 
			// buttonPortRefresh
			// 
			this.buttonPortRefresh.Image = ((System.Drawing.Image)(resources.GetObject("buttonPortRefresh.Image")));
			this.buttonPortRefresh.Location = new System.Drawing.Point(148, 3);
			this.buttonPortRefresh.Name = "buttonPortRefresh";
			this.buttonPortRefresh.Size = new System.Drawing.Size(28, 23);
			this.buttonPortRefresh.TabIndex = 2;
			this.buttonPortRefresh.UseVisualStyleBackColor = true;
			// 
			// labelBaudRate
			// 
			this.labelBaudRate.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelBaudRate.AutoSize = true;
			this.labelBaudRate.Location = new System.Drawing.Point(3, 36);
			this.labelBaudRate.Name = "labelBaudRate";
			this.labelBaudRate.Size = new System.Drawing.Size(61, 13);
			this.labelBaudRate.TabIndex = 3;
			this.labelBaudRate.Text = "Baud Rate:";
			// 
			// comboBoxBaudRate
			// 
			this.comboBoxBaudRate.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboBoxBaudRate.FormattingEnabled = true;
			this.comboBoxBaudRate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "76800",
            "115200"});
			this.comboBoxBaudRate.Location = new System.Drawing.Point(70, 32);
			this.comboBoxBaudRate.Name = "comboBoxBaudRate";
			this.comboBoxBaudRate.Size = new System.Drawing.Size(72, 21);
			this.comboBoxBaudRate.TabIndex = 4;
			// 
			// labelStopBits
			// 
			this.labelStopBits.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelStopBits.AutoSize = true;
			this.labelStopBits.Location = new System.Drawing.Point(182, 8);
			this.labelStopBits.Name = "labelStopBits";
			this.labelStopBits.Size = new System.Drawing.Size(52, 13);
			this.labelStopBits.TabIndex = 10;
			this.labelStopBits.Text = "Stop Bits:";
			// 
			// comboBoxStopBits
			// 
			this.comboBoxStopBits.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboBoxStopBits.FormattingEnabled = true;
			this.comboBoxStopBits.Items.AddRange(new object[] {
            "1",
            "2"});
			this.comboBoxStopBits.Location = new System.Drawing.Point(240, 3);
			this.comboBoxStopBits.Name = "comboBoxStopBits";
			this.comboBoxStopBits.Size = new System.Drawing.Size(72, 21);
			this.comboBoxStopBits.TabIndex = 11;
			// 
			// labelParity
			// 
			this.labelParity.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelParity.AutoSize = true;
			this.labelParity.Location = new System.Drawing.Point(182, 36);
			this.labelParity.Name = "labelParity";
			this.labelParity.Size = new System.Drawing.Size(36, 13);
			this.labelParity.TabIndex = 5;
			this.labelParity.Text = "Parity:";
			// 
			// comboBoxParity
			// 
			this.comboBoxParity.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboBoxParity.FormattingEnabled = true;
			this.comboBoxParity.Items.AddRange(new object[] {
            "Even",
            "Odd",
            "None"});
			this.comboBoxParity.Location = new System.Drawing.Point(240, 32);
			this.comboBoxParity.Name = "comboBoxParity";
			this.comboBoxParity.Size = new System.Drawing.Size(72, 21);
			this.comboBoxParity.TabIndex = 6;
			// 
			// radioButtonOpen
			// 
			this.radioButtonOpen.AutoSize = true;
			this.radioButtonOpen.Location = new System.Drawing.Point(318, 3);
			this.radioButtonOpen.Name = "radioButtonOpen";
			this.radioButtonOpen.Size = new System.Drawing.Size(51, 17);
			this.radioButtonOpen.TabIndex = 12;
			this.radioButtonOpen.Text = "Open";
			this.radioButtonOpen.UseVisualStyleBackColor = true;
			// 
			// radioButtonClosed
			// 
			this.radioButtonClosed.AutoSize = true;
			this.radioButtonClosed.Checked = true;
			this.radioButtonClosed.Location = new System.Drawing.Point(318, 32);
			this.radioButtonClosed.Name = "radioButtonClosed";
			this.radioButtonClosed.Size = new System.Drawing.Size(57, 17);
			this.radioButtonClosed.TabIndex = 13;
			this.radioButtonClosed.TabStop = true;
			this.radioButtonClosed.Text = "Closed";
			this.radioButtonClosed.UseVisualStyleBackColor = true;
			// 
			// groupBoxSerialPort
			// 
			this.groupBoxSerialPort.AutoSize = true;
			this.groupBoxSerialPort.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxSerialPort.Controls.Add(this.tableLayoutPanelSerialPort);
			this.groupBoxSerialPort.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBoxSerialPort.Location = new System.Drawing.Point(0, 72);
			this.groupBoxSerialPort.Name = "groupBoxSerialPort";
			this.groupBoxSerialPort.Size = new System.Drawing.Size(384, 75);
			this.groupBoxSerialPort.TabIndex = 8;
			this.groupBoxSerialPort.TabStop = false;
			this.groupBoxSerialPort.Text = "Serial Port";
			// 
			// groupBoxSample
			// 
			this.groupBoxSample.AutoSize = true;
			this.groupBoxSample.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxSample.Controls.Add(this.tableLayoutPanel4);
			this.groupBoxSample.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBoxSample.Location = new System.Drawing.Point(0, 147);
			this.groupBoxSample.Name = "groupBoxSample";
			this.groupBoxSample.Size = new System.Drawing.Size(384, 45);
			this.groupBoxSample.TabIndex = 17;
			this.groupBoxSample.TabStop = false;
			this.groupBoxSample.Text = "Sample Interval";
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.AutoSize = true;
			this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel4.ColumnCount = 2;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.15405F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.84595F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel4.Controls.Add(this.numericUpDownInterval, 0, 2);
			this.tableLayoutPanel4.Controls.Add(this.label5, 1, 2);
			this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 7;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.Size = new System.Drawing.Size(378, 26);
			this.tableLayoutPanel4.TabIndex = 14;
			// 
			// numericUpDownInterval
			// 
			this.numericUpDownInterval.Dock = System.Windows.Forms.DockStyle.Fill;
			this.numericUpDownInterval.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDownInterval.Location = new System.Drawing.Point(3, 3);
			this.numericUpDownInterval.Maximum = new decimal(new int[] {
            36000000,
            0,
            0,
            0});
			this.numericUpDownInterval.Name = "numericUpDownInterval";
			this.numericUpDownInterval.Size = new System.Drawing.Size(96, 20);
			this.numericUpDownInterval.TabIndex = 1;
			this.numericUpDownInterval.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(105, 6);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(20, 13);
			this.label5.TabIndex = 14;
			this.label5.Text = "ms";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Checked = false;
			this.tableLayoutPanel5.SetColumnSpan(this.dateTimePicker1, 2);
			this.dateTimePicker1.Enabled = false;
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.dateTimePicker1.Location = new System.Drawing.Point(238, 42);
			this.dateTimePicker1.MinDate = new System.DateTime(2021, 5, 28, 0, 0, 0, 0);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.ShowUpDown = true;
			this.dateTimePicker1.Size = new System.Drawing.Size(100, 20);
			this.dateTimePicker1.TabIndex = 27;
			// 
			// groupBoxStop
			// 
			this.groupBoxStop.AutoSize = true;
			this.groupBoxStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxStop.Controls.Add(this.tableLayoutPanel5);
			this.groupBoxStop.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBoxStop.Location = new System.Drawing.Point(0, 192);
			this.groupBoxStop.Name = "groupBoxStop";
			this.groupBoxStop.Size = new System.Drawing.Size(384, 133);
			this.groupBoxStop.TabIndex = 20;
			this.groupBoxStop.TabStop = false;
			this.groupBoxStop.Text = "Stop";
			// 
			// tableLayoutPanel5
			// 
			this.tableLayoutPanel5.AutoSize = true;
			this.tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel5.ColumnCount = 5;
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel5.Controls.Add(this.dateTimePicker1, 3, 2);
			this.tableLayoutPanel5.Controls.Add(this.radioButton2, 0, 1);
			this.tableLayoutPanel5.Controls.Add(this.radioButton3, 0, 2);
			this.tableLayoutPanel5.Controls.Add(this.dateTimePicker2, 1, 2);
			this.tableLayoutPanel5.Controls.Add(this.radioButton1, 0, 3);
			this.tableLayoutPanel5.Controls.Add(this.radioButton4, 0, 4);
			this.tableLayoutPanel5.Controls.Add(this.numericUpDown7, 1, 1);
			this.tableLayoutPanel5.Controls.Add(this.numericUpDown8, 2, 1);
			this.tableLayoutPanel5.Controls.Add(this.numericUpDown9, 3, 1);
			this.tableLayoutPanel5.Controls.Add(this.label1, 1, 0);
			this.tableLayoutPanel5.Controls.Add(this.label3, 2, 0);
			this.tableLayoutPanel5.Controls.Add(this.label4, 3, 0);
			this.tableLayoutPanel5.Controls.Add(this.numericUpDown6, 1, 3);
			this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel5.Name = "tableLayoutPanel5";
			this.tableLayoutPanel5.RowCount = 5;
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel5.Size = new System.Drawing.Size(378, 114);
			this.tableLayoutPanel5.TabIndex = 14;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(3, 16);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(89, 17);
			this.radioButton2.TabIndex = 19;
			this.radioButton2.Text = "Elapsed Time";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(3, 42);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(76, 17);
			this.radioButton3.TabIndex = 20;
			this.radioButton3.Text = "Date/Time";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// dateTimePicker2
			// 
			this.dateTimePicker2.Checked = false;
			this.tableLayoutPanel5.SetColumnSpan(this.dateTimePicker2, 2);
			this.dateTimePicker2.Enabled = false;
			this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePicker2.Location = new System.Drawing.Point(98, 42);
			this.dateTimePicker2.MinDate = new System.DateTime(2021, 5, 28, 16, 58, 24, 0);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.Size = new System.Drawing.Size(121, 20);
			this.dateTimePicker2.TabIndex = 27;
			this.dateTimePicker2.Value = new System.DateTime(2021, 5, 28, 16, 58, 24, 0);
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(3, 68);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(77, 17);
			this.radioButton1.TabIndex = 18;
			this.radioButton1.Text = "# of Scans";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// radioButton4
			// 
			this.radioButton4.AutoSize = true;
			this.radioButton4.Checked = true;
			this.radioButton4.Location = new System.Drawing.Point(3, 94);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(81, 17);
			this.radioButton4.TabIndex = 17;
			this.radioButton4.TabStop = true;
			this.radioButton4.Text = "Stop Button";
			this.radioButton4.UseVisualStyleBackColor = true;
			// 
			// numericUpDown7
			// 
			this.numericUpDown7.Enabled = false;
			this.numericUpDown7.Location = new System.Drawing.Point(98, 16);
			this.numericUpDown7.Maximum = new decimal(new int[] {
            36000000,
            0,
            0,
            0});
			this.numericUpDown7.Name = "numericUpDown7";
			this.numericUpDown7.Size = new System.Drawing.Size(51, 20);
			this.numericUpDown7.TabIndex = 22;
			this.numericUpDown7.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// numericUpDown8
			// 
			this.numericUpDown8.Enabled = false;
			this.numericUpDown8.Location = new System.Drawing.Point(168, 16);
			this.numericUpDown8.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
			this.numericUpDown8.Name = "numericUpDown8";
			this.numericUpDown8.Size = new System.Drawing.Size(51, 20);
			this.numericUpDown8.TabIndex = 23;
			this.numericUpDown8.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// numericUpDown9
			// 
			this.numericUpDown9.Enabled = false;
			this.numericUpDown9.Location = new System.Drawing.Point(238, 16);
			this.numericUpDown9.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
			this.numericUpDown9.Name = "numericUpDown9";
			this.numericUpDown9.Size = new System.Drawing.Size(52, 20);
			this.numericUpDown9.TabIndex = 24;
			this.numericUpDown9.Value = new decimal(new int[] {
            59,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(98, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 16;
			this.label1.Text = "Hours";
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(168, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 13);
			this.label3.TabIndex = 29;
			this.label3.Text = "Minutes";
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(238, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(49, 13);
			this.label4.TabIndex = 30;
			this.label4.Text = "Seconds";
			// 
			// numericUpDown6
			// 
			this.tableLayoutPanel5.SetColumnSpan(this.numericUpDown6, 3);
			this.numericUpDown6.Enabled = false;
			this.numericUpDown6.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDown6.Location = new System.Drawing.Point(98, 68);
			this.numericUpDown6.Maximum = new decimal(new int[] {
            36000000,
            0,
            0,
            0});
			this.numericUpDown6.Name = "numericUpDown6";
			this.numericUpDown6.Size = new System.Drawing.Size(90, 20);
			this.numericUpDown6.TabIndex = 21;
			this.numericUpDown6.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			// 
			// groupBoxCommand
			// 
			this.groupBoxCommand.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxCommand.Controls.Add(this.textBoxCommand);
			this.groupBoxCommand.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBoxCommand.Location = new System.Drawing.Point(0, 325);
			this.groupBoxCommand.Name = "groupBoxCommand";
			this.groupBoxCommand.Size = new System.Drawing.Size(384, 39);
			this.groupBoxCommand.TabIndex = 21;
			this.groupBoxCommand.TabStop = false;
			this.groupBoxCommand.Text = "Command";
			// 
			// textBoxCommand
			// 
			this.textBoxCommand.Dock = System.Windows.Forms.DockStyle.Top;
			this.textBoxCommand.Location = new System.Drawing.Point(3, 16);
			this.textBoxCommand.Name = "textBoxCommand";
			this.textBoxCommand.Size = new System.Drawing.Size(378, 20);
			this.textBoxCommand.TabIndex = 10;
			// 
			// groupBoxResponse
			// 
			this.groupBoxResponse.AutoSize = true;
			this.groupBoxResponse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxResponse.Controls.Add(this.textBoxResponse);
			this.groupBoxResponse.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBoxResponse.Location = new System.Drawing.Point(0, 364);
			this.groupBoxResponse.Name = "groupBoxResponse";
			this.groupBoxResponse.Size = new System.Drawing.Size(384, 39);
			this.groupBoxResponse.TabIndex = 22;
			this.groupBoxResponse.TabStop = false;
			this.groupBoxResponse.Text = "Response";
			// 
			// textBoxResponse
			// 
			this.textBoxResponse.Dock = System.Windows.Forms.DockStyle.Top;
			this.textBoxResponse.Location = new System.Drawing.Point(3, 16);
			this.textBoxResponse.Name = "textBoxResponse";
			this.textBoxResponse.ReadOnly = true;
			this.textBoxResponse.Size = new System.Drawing.Size(378, 20);
			this.textBoxResponse.TabIndex = 10;
			// 
			// FormLog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 476);
			this.Controls.Add(this.groupBoxResponse);
			this.Controls.Add(this.groupBoxCommand);
			this.Controls.Add(this.groupBoxStop);
			this.Controls.Add(this.groupBoxSample);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBoxSerialPort);
			this.Controls.Add(this.groupBoxMassFlow);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FormLog";
			this.Text = "Data logger";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLog_FormClosing);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.groupBoxMassFlow.ResumeLayout(false);
			this.groupBoxMassFlow.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanelSerialPort.ResumeLayout(false);
			this.tableLayoutPanelSerialPort.PerformLayout();
			this.groupBoxSerialPort.ResumeLayout(false);
			this.groupBoxSerialPort.PerformLayout();
			this.groupBoxSample.ResumeLayout(false);
			this.groupBoxSample.PerformLayout();
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
			this.groupBoxStop.ResumeLayout(false);
			this.groupBoxStop.PerformLayout();
			this.tableLayoutPanel5.ResumeLayout(false);
			this.tableLayoutPanel5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown9)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
			this.groupBoxCommand.ResumeLayout(false);
			this.groupBoxCommand.PerformLayout();
			this.groupBoxResponse.ResumeLayout(false);
			this.groupBoxResponse.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.GroupBox groupBoxMassFlow;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TextBox textBoxFilename;
		private System.Windows.Forms.Button buttonBrowse;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button buttonStop;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSerialPort;
		private System.Windows.Forms.Label labelComPort;
		private System.Windows.Forms.ComboBox comboBoxSerialPort;
		private System.Windows.Forms.Button buttonPortRefresh;
		private System.Windows.Forms.Label labelBaudRate;
		private System.Windows.Forms.ComboBox comboBoxBaudRate;
		private System.Windows.Forms.Label labelStopBits;
		private System.Windows.Forms.ComboBox comboBoxStopBits;
		private System.Windows.Forms.Label labelParity;
		private System.Windows.Forms.ComboBox comboBoxParity;
		private System.Windows.Forms.GroupBox groupBoxSerialPort;
		private System.Windows.Forms.RadioButton radioButtonOpen;
		private System.Windows.Forms.RadioButton radioButtonClosed;
		private System.Windows.Forms.GroupBox groupBoxSample;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.NumericUpDown numericUpDownInterval;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.GroupBox groupBoxStop;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.NumericUpDown numericUpDown6;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.NumericUpDown numericUpDown7;
		private System.Windows.Forms.NumericUpDown numericUpDown8;
		private System.Windows.Forms.NumericUpDown numericUpDown9;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.DateTimePicker dateTimePicker2;
		private System.Windows.Forms.GroupBox groupBoxCommand;
		private System.Windows.Forms.TextBox textBoxCommand;
		private System.Windows.Forms.GroupBox groupBoxResponse;
		private System.Windows.Forms.TextBox textBoxResponse;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
	}
}

