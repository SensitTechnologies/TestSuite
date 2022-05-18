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
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.groupBoxFilename = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanelFilename = new System.Windows.Forms.TableLayoutPanel();
			this.textBoxFilename = new System.Windows.Forms.TextBox();
			this.buttonBrowse = new System.Windows.Forms.Button();
			this.groupBoxStartStop = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanelStartStop = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanelButtons = new System.Windows.Forms.TableLayoutPanel();
			this.buttonStop = new System.Windows.Forms.Button();
			this.buttonStart = new System.Windows.Forms.Button();
			this.tableLayoutPanelSerialPort = new System.Windows.Forms.TableLayoutPanel();
			this.comboBoxDataBits = new System.Windows.Forms.ComboBox();
			this.labelDataBits = new System.Windows.Forms.Label();
			this.labelComPort = new System.Windows.Forms.Label();
			this.comboBoxSerialPort = new System.Windows.Forms.ComboBox();
			this.buttonPortRefresh = new System.Windows.Forms.Button();
			this.labelBaudRate = new System.Windows.Forms.Label();
			this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
			this.comboBoxParity = new System.Windows.Forms.ComboBox();
			this.labelStopBits = new System.Windows.Forms.Label();
			this.comboBoxStopBits = new System.Windows.Forms.ComboBox();
			this.labelParity = new System.Windows.Forms.Label();
			this.comboBoxHandshake = new System.Windows.Forms.ComboBox();
			this.labelHandshake = new System.Windows.Forms.Label();
			this.groupBoxSerialPort = new System.Windows.Forms.GroupBox();
			this.groupBoxSample = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanelSample = new System.Windows.Forms.TableLayoutPanel();
			this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.dateTimePickerTime = new System.Windows.Forms.DateTimePicker();
			this.groupBoxStop = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanelStop = new System.Windows.Forms.TableLayoutPanel();
			this.radioButtonElapsedTime = new System.Windows.Forms.RadioButton();
			this.radioButtonDateTime = new System.Windows.Forms.RadioButton();
			this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
			this.radioButtonNumScans = new System.Windows.Forms.RadioButton();
			this.radioButtonStop = new System.Windows.Forms.RadioButton();
			this.numericUpDownHours = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownMinutes = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownSeconds = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.numericUpDownNumScans = new System.Windows.Forms.NumericUpDown();
			this.groupBoxCommand = new System.Windows.Forms.GroupBox();
			this.textBoxCommand = new System.Windows.Forms.TextBox();
			this.groupBoxResponse = new System.Windows.Forms.GroupBox();
			this.textBoxResponse = new System.Windows.Forms.TextBox();
			this.menuStrip.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.groupBoxFilename.SuspendLayout();
			this.tableLayoutPanelFilename.SuspendLayout();
			this.groupBoxStartStop.SuspendLayout();
			this.tableLayoutPanelStartStop.SuspendLayout();
			this.tableLayoutPanelButtons.SuspendLayout();
			this.tableLayoutPanelSerialPort.SuspendLayout();
			this.groupBoxSerialPort.SuspendLayout();
			this.groupBoxSample.SuspendLayout();
			this.tableLayoutPanelSample.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
			this.groupBoxStop.SuspendLayout();
			this.tableLayoutPanelStop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownHours)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinutes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeconds)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumScans)).BeginInit();
			this.groupBoxCommand.SuspendLayout();
			this.groupBoxResponse.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.testToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
			this.menuStrip.Size = new System.Drawing.Size(466, 24);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "menuStrip1";
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
			// testToolStripMenuItem
			// 
			this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem});
			this.testToolStripMenuItem.Name = "testToolStripMenuItem";
			this.testToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.testToolStripMenuItem.Text = "&Test";
			// 
			// startToolStripMenuItem
			// 
			this.startToolStripMenuItem.Name = "startToolStripMenuItem";
			this.startToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.startToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.startToolStripMenuItem.Text = "&Start";
			this.startToolStripMenuItem.Click += new System.EventHandler(this.ButtonStart_Click);
			// 
			// stopToolStripMenuItem
			// 
			this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
			this.stopToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
			this.stopToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.stopToolStripMenuItem.Text = "&Stop";
			this.stopToolStripMenuItem.Click += new System.EventHandler(this.ButtonStop_Click);
			// 
			// statusStrip
			// 
			this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
			this.statusStrip.Location = new System.Drawing.Point(0, 543);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 17, 0);
			this.statusStrip.Size = new System.Drawing.Size(466, 22);
			this.statusStrip.TabIndex = 1;
			this.statusStrip.Text = "statusStrip1";
			// 
			// toolStripStatusLabel
			// 
			this.toolStripStatusLabel.Name = "toolStripStatusLabel";
			this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
			this.toolStripStatusLabel.Text = "Ready";
			// 
			// groupBoxFilename
			// 
			this.groupBoxFilename.AutoSize = true;
			this.groupBoxFilename.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxFilename.Controls.Add(this.tableLayoutPanelFilename);
			this.groupBoxFilename.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBoxFilename.Location = new System.Drawing.Point(0, 24);
			this.groupBoxFilename.Margin = new System.Windows.Forms.Padding(4);
			this.groupBoxFilename.Name = "groupBoxFilename";
			this.groupBoxFilename.Padding = new System.Windows.Forms.Padding(4);
			this.groupBoxFilename.Size = new System.Drawing.Size(466, 58);
			this.groupBoxFilename.TabIndex = 7;
			this.groupBoxFilename.TabStop = false;
			this.groupBoxFilename.Text = "Filename";
			// 
			// tableLayoutPanelFilename
			// 
			this.tableLayoutPanelFilename.AutoSize = true;
			this.tableLayoutPanelFilename.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelFilename.ColumnCount = 2;
			this.tableLayoutPanelFilename.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelFilename.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelFilename.Controls.Add(this.textBoxFilename, 0, 0);
			this.tableLayoutPanelFilename.Controls.Add(this.buttonBrowse, 1, 0);
			this.tableLayoutPanelFilename.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanelFilename.Location = new System.Drawing.Point(4, 20);
			this.tableLayoutPanelFilename.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanelFilename.Name = "tableLayoutPanelFilename";
			this.tableLayoutPanelFilename.RowCount = 1;
			this.tableLayoutPanelFilename.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelFilename.Size = new System.Drawing.Size(458, 34);
			this.tableLayoutPanelFilename.TabIndex = 1;
			// 
			// textBoxFilename
			// 
			this.textBoxFilename.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxFilename.Location = new System.Drawing.Point(4, 4);
			this.textBoxFilename.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxFilename.Name = "textBoxFilename";
			this.textBoxFilename.Size = new System.Drawing.Size(354, 23);
			this.textBoxFilename.TabIndex = 9;
			// 
			// buttonBrowse
			// 
			this.buttonBrowse.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.buttonBrowse.Location = new System.Drawing.Point(366, 4);
			this.buttonBrowse.Margin = new System.Windows.Forms.Padding(4);
			this.buttonBrowse.Name = "buttonBrowse";
			this.buttonBrowse.Size = new System.Drawing.Size(88, 26);
			this.buttonBrowse.TabIndex = 2;
			this.buttonBrowse.Text = "Browse";
			this.buttonBrowse.UseVisualStyleBackColor = true;
			this.buttonBrowse.Click += new System.EventHandler(this.ButtonBrowse_Click);
			// 
			// groupBoxStartStop
			// 
			this.groupBoxStartStop.AutoSize = true;
			this.groupBoxStartStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxStartStop.Controls.Add(this.tableLayoutPanelStartStop);
			this.groupBoxStartStop.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBoxStartStop.Location = new System.Drawing.Point(0, 481);
			this.groupBoxStartStop.Margin = new System.Windows.Forms.Padding(4);
			this.groupBoxStartStop.Name = "groupBoxStartStop";
			this.groupBoxStartStop.Padding = new System.Windows.Forms.Padding(4);
			this.groupBoxStartStop.Size = new System.Drawing.Size(466, 62);
			this.groupBoxStartStop.TabIndex = 13;
			this.groupBoxStartStop.TabStop = false;
			this.groupBoxStartStop.Text = "Start/Stop";
			// 
			// tableLayoutPanelStartStop
			// 
			this.tableLayoutPanelStartStop.AutoSize = true;
			this.tableLayoutPanelStartStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelStartStop.ColumnCount = 1;
			this.tableLayoutPanelStartStop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelStartStop.Controls.Add(this.tableLayoutPanelButtons, 0, 0);
			this.tableLayoutPanelStartStop.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelStartStop.Location = new System.Drawing.Point(4, 20);
			this.tableLayoutPanelStartStop.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanelStartStop.Name = "tableLayoutPanelStartStop";
			this.tableLayoutPanelStartStop.RowCount = 1;
			this.tableLayoutPanelStartStop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelStartStop.Size = new System.Drawing.Size(458, 38);
			this.tableLayoutPanelStartStop.TabIndex = 1;
			// 
			// tableLayoutPanelButtons
			// 
			this.tableLayoutPanelButtons.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.tableLayoutPanelButtons.AutoSize = true;
			this.tableLayoutPanelButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelButtons.ColumnCount = 2;
			this.tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelButtons.Controls.Add(this.buttonStop, 1, 0);
			this.tableLayoutPanelButtons.Controls.Add(this.buttonStart, 0, 0);
			this.tableLayoutPanelButtons.Location = new System.Drawing.Point(133, 4);
			this.tableLayoutPanelButtons.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
			this.tableLayoutPanelButtons.RowCount = 1;
			this.tableLayoutPanelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelButtons.Size = new System.Drawing.Size(192, 30);
			this.tableLayoutPanelButtons.TabIndex = 0;
			// 
			// buttonStop
			// 
			this.buttonStop.Enabled = false;
			this.buttonStop.Location = new System.Drawing.Point(100, 4);
			this.buttonStop.Margin = new System.Windows.Forms.Padding(4);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(88, 22);
			this.buttonStop.TabIndex = 1;
			this.buttonStop.Text = "Stop";
			this.buttonStop.UseVisualStyleBackColor = true;
			this.buttonStop.Click += new System.EventHandler(this.ButtonStop_Click);
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(4, 4);
			this.buttonStart.Margin = new System.Windows.Forms.Padding(4);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(88, 22);
			this.buttonStart.TabIndex = 0;
			this.buttonStart.Text = "Start";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
			// 
			// tableLayoutPanelSerialPort
			// 
			this.tableLayoutPanelSerialPort.AutoSize = true;
			this.tableLayoutPanelSerialPort.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelSerialPort.ColumnCount = 5;
			this.tableLayoutPanelSerialPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelSerialPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelSerialPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelSerialPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelSerialPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelSerialPort.Controls.Add(this.comboBoxDataBits, 0, 2);
			this.tableLayoutPanelSerialPort.Controls.Add(this.labelDataBits, 0, 2);
			this.tableLayoutPanelSerialPort.Controls.Add(this.labelComPort, 0, 0);
			this.tableLayoutPanelSerialPort.Controls.Add(this.comboBoxSerialPort, 1, 0);
			this.tableLayoutPanelSerialPort.Controls.Add(this.buttonPortRefresh, 2, 0);
			this.tableLayoutPanelSerialPort.Controls.Add(this.labelBaudRate, 0, 1);
			this.tableLayoutPanelSerialPort.Controls.Add(this.comboBoxBaudRate, 1, 1);
			this.tableLayoutPanelSerialPort.Controls.Add(this.comboBoxParity, 4, 0);
			this.tableLayoutPanelSerialPort.Controls.Add(this.labelStopBits, 3, 1);
			this.tableLayoutPanelSerialPort.Controls.Add(this.comboBoxStopBits, 4, 1);
			this.tableLayoutPanelSerialPort.Controls.Add(this.labelParity, 3, 0);
			this.tableLayoutPanelSerialPort.Controls.Add(this.comboBoxHandshake, 4, 2);
			this.tableLayoutPanelSerialPort.Controls.Add(this.labelHandshake, 3, 2);
			this.tableLayoutPanelSerialPort.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanelSerialPort.Location = new System.Drawing.Point(4, 20);
			this.tableLayoutPanelSerialPort.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanelSerialPort.Name = "tableLayoutPanelSerialPort";
			this.tableLayoutPanelSerialPort.RowCount = 3;
			this.tableLayoutPanelSerialPort.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSerialPort.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSerialPort.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSerialPort.Size = new System.Drawing.Size(458, 96);
			this.tableLayoutPanelSerialPort.TabIndex = 14;
			// 
			// comboBoxDataBits
			// 
			this.comboBoxDataBits.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboBoxDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxDataBits.FormattingEnabled = true;
			this.comboBoxDataBits.Location = new System.Drawing.Point(75, 69);
			this.comboBoxDataBits.Margin = new System.Windows.Forms.Padding(4);
			this.comboBoxDataBits.Name = "comboBoxDataBits";
			this.comboBoxDataBits.Size = new System.Drawing.Size(127, 23);
			this.comboBoxDataBits.TabIndex = 15;
			// 
			// labelDataBits
			// 
			this.labelDataBits.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelDataBits.AutoSize = true;
			this.labelDataBits.Location = new System.Drawing.Point(4, 73);
			this.labelDataBits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelDataBits.Name = "labelDataBits";
			this.labelDataBits.Size = new System.Drawing.Size(56, 15);
			this.labelDataBits.TabIndex = 14;
			this.labelDataBits.Text = "Data Bits:";
			// 
			// labelComPort
			// 
			this.labelComPort.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelComPort.AutoSize = true;
			this.labelComPort.Location = new System.Drawing.Point(4, 9);
			this.labelComPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelComPort.Name = "labelComPort";
			this.labelComPort.Size = new System.Drawing.Size(63, 15);
			this.labelComPort.TabIndex = 0;
			this.labelComPort.Text = "COM Port:";
			// 
			// comboBoxSerialPort
			// 
			this.comboBoxSerialPort.AllowDrop = true;
			this.comboBoxSerialPort.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboBoxSerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSerialPort.FormattingEnabled = true;
			this.comboBoxSerialPort.Location = new System.Drawing.Point(75, 4);
			this.comboBoxSerialPort.Margin = new System.Windows.Forms.Padding(4);
			this.comboBoxSerialPort.Name = "comboBoxSerialPort";
			this.comboBoxSerialPort.Size = new System.Drawing.Size(127, 23);
			this.comboBoxSerialPort.TabIndex = 1;
			// 
			// buttonPortRefresh
			// 
			this.buttonPortRefresh.Image = ((System.Drawing.Image)(resources.GetObject("buttonPortRefresh.Image")));
			this.buttonPortRefresh.Location = new System.Drawing.Point(210, 4);
			this.buttonPortRefresh.Margin = new System.Windows.Forms.Padding(4);
			this.buttonPortRefresh.Name = "buttonPortRefresh";
			this.buttonPortRefresh.Size = new System.Drawing.Size(32, 26);
			this.buttonPortRefresh.TabIndex = 2;
			this.buttonPortRefresh.UseVisualStyleBackColor = true;
			// 
			// labelBaudRate
			// 
			this.labelBaudRate.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelBaudRate.AutoSize = true;
			this.labelBaudRate.Location = new System.Drawing.Point(4, 42);
			this.labelBaudRate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelBaudRate.Name = "labelBaudRate";
			this.labelBaudRate.Size = new System.Drawing.Size(63, 15);
			this.labelBaudRate.TabIndex = 3;
			this.labelBaudRate.Text = "Baud Rate:";
			// 
			// comboBoxBaudRate
			// 
			this.comboBoxBaudRate.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboBoxBaudRate.FormattingEnabled = true;
			this.comboBoxBaudRate.Location = new System.Drawing.Point(75, 38);
			this.comboBoxBaudRate.Margin = new System.Windows.Forms.Padding(4);
			this.comboBoxBaudRate.Name = "comboBoxBaudRate";
			this.comboBoxBaudRate.Size = new System.Drawing.Size(127, 23);
			this.comboBoxBaudRate.TabIndex = 4;
			// 
			// comboBoxParity
			// 
			this.comboBoxParity.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboBoxParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxParity.FormattingEnabled = true;
			this.comboBoxParity.Location = new System.Drawing.Point(327, 4);
			this.comboBoxParity.Margin = new System.Windows.Forms.Padding(4);
			this.comboBoxParity.Name = "comboBoxParity";
			this.comboBoxParity.Size = new System.Drawing.Size(127, 23);
			this.comboBoxParity.TabIndex = 11;
			// 
			// labelStopBits
			// 
			this.labelStopBits.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelStopBits.AutoSize = true;
			this.labelStopBits.Location = new System.Drawing.Point(250, 42);
			this.labelStopBits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelStopBits.Name = "labelStopBits";
			this.labelStopBits.Size = new System.Drawing.Size(56, 15);
			this.labelStopBits.TabIndex = 5;
			this.labelStopBits.Text = "Stop Bits:";
			// 
			// comboBoxStopBits
			// 
			this.comboBoxStopBits.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboBoxStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxStopBits.FormattingEnabled = true;
			this.comboBoxStopBits.Location = new System.Drawing.Point(327, 38);
			this.comboBoxStopBits.Margin = new System.Windows.Forms.Padding(4);
			this.comboBoxStopBits.Name = "comboBoxStopBits";
			this.comboBoxStopBits.Size = new System.Drawing.Size(127, 23);
			this.comboBoxStopBits.TabIndex = 6;
			// 
			// labelParity
			// 
			this.labelParity.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelParity.AutoSize = true;
			this.labelParity.Location = new System.Drawing.Point(250, 9);
			this.labelParity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelParity.Name = "labelParity";
			this.labelParity.Size = new System.Drawing.Size(40, 15);
			this.labelParity.TabIndex = 12;
			this.labelParity.Text = "Parity:";
			// 
			// comboBoxHandshake
			// 
			this.comboBoxHandshake.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboBoxHandshake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxHandshake.FormattingEnabled = true;
			this.comboBoxHandshake.Location = new System.Drawing.Point(327, 69);
			this.comboBoxHandshake.Margin = new System.Windows.Forms.Padding(4);
			this.comboBoxHandshake.Name = "comboBoxHandshake";
			this.comboBoxHandshake.Size = new System.Drawing.Size(127, 23);
			this.comboBoxHandshake.TabIndex = 13;
			// 
			// labelHandshake
			// 
			this.labelHandshake.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelHandshake.AutoSize = true;
			this.labelHandshake.Location = new System.Drawing.Point(250, 73);
			this.labelHandshake.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelHandshake.Name = "labelHandshake";
			this.labelHandshake.Size = new System.Drawing.Size(69, 15);
			this.labelHandshake.TabIndex = 10;
			this.labelHandshake.Text = "Handshake:";
			// 
			// groupBoxSerialPort
			// 
			this.groupBoxSerialPort.AutoSize = true;
			this.groupBoxSerialPort.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxSerialPort.Controls.Add(this.tableLayoutPanelSerialPort);
			this.groupBoxSerialPort.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBoxSerialPort.Location = new System.Drawing.Point(0, 82);
			this.groupBoxSerialPort.Margin = new System.Windows.Forms.Padding(4);
			this.groupBoxSerialPort.Name = "groupBoxSerialPort";
			this.groupBoxSerialPort.Padding = new System.Windows.Forms.Padding(4);
			this.groupBoxSerialPort.Size = new System.Drawing.Size(466, 120);
			this.groupBoxSerialPort.TabIndex = 8;
			this.groupBoxSerialPort.TabStop = false;
			this.groupBoxSerialPort.Text = "Serial Port";
			// 
			// groupBoxSample
			// 
			this.groupBoxSample.AutoSize = true;
			this.groupBoxSample.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxSample.Controls.Add(this.tableLayoutPanelSample);
			this.groupBoxSample.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBoxSample.Location = new System.Drawing.Point(0, 202);
			this.groupBoxSample.Margin = new System.Windows.Forms.Padding(4);
			this.groupBoxSample.Name = "groupBoxSample";
			this.groupBoxSample.Padding = new System.Windows.Forms.Padding(4);
			this.groupBoxSample.Size = new System.Drawing.Size(466, 55);
			this.groupBoxSample.TabIndex = 17;
			this.groupBoxSample.TabStop = false;
			this.groupBoxSample.Text = "Sample Interval";
			// 
			// tableLayoutPanelSample
			// 
			this.tableLayoutPanelSample.AutoSize = true;
			this.tableLayoutPanelSample.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelSample.ColumnCount = 2;
			this.tableLayoutPanelSample.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.15405F));
			this.tableLayoutPanelSample.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.84595F));
			this.tableLayoutPanelSample.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
			this.tableLayoutPanelSample.Controls.Add(this.numericUpDownInterval, 0, 2);
			this.tableLayoutPanelSample.Controls.Add(this.label5, 1, 2);
			this.tableLayoutPanelSample.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanelSample.Location = new System.Drawing.Point(4, 20);
			this.tableLayoutPanelSample.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanelSample.Name = "tableLayoutPanelSample";
			this.tableLayoutPanelSample.RowCount = 7;
			this.tableLayoutPanelSample.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSample.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSample.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSample.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSample.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSample.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSample.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSample.Size = new System.Drawing.Size(458, 31);
			this.tableLayoutPanelSample.TabIndex = 14;
			// 
			// numericUpDownInterval
			// 
			this.numericUpDownInterval.Dock = System.Windows.Forms.DockStyle.Fill;
			this.numericUpDownInterval.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDownInterval.Location = new System.Drawing.Point(4, 4);
			this.numericUpDownInterval.Margin = new System.Windows.Forms.Padding(4);
			this.numericUpDownInterval.Maximum = new decimal(new int[] {
            36000000,
            0,
            0,
            0});
			this.numericUpDownInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownInterval.Name = "numericUpDownInterval";
			this.numericUpDownInterval.Size = new System.Drawing.Size(116, 23);
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
			this.label5.Location = new System.Drawing.Point(128, 8);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(23, 15);
			this.label5.TabIndex = 14;
			this.label5.Text = "ms";
			// 
			// dateTimePickerTime
			// 
			this.dateTimePickerTime.Checked = false;
			this.tableLayoutPanelStop.SetColumnSpan(this.dateTimePickerTime, 2);
			this.dateTimePickerTime.Enabled = false;
			this.dateTimePickerTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.dateTimePickerTime.Location = new System.Drawing.Point(284, 50);
			this.dateTimePickerTime.Margin = new System.Windows.Forms.Padding(4);
			this.dateTimePickerTime.MinDate = new System.DateTime(2021, 5, 28, 0, 0, 0, 0);
			this.dateTimePickerTime.Name = "dateTimePickerTime";
			this.dateTimePickerTime.ShowUpDown = true;
			this.dateTimePickerTime.Size = new System.Drawing.Size(116, 23);
			this.dateTimePickerTime.TabIndex = 27;
			// 
			// groupBoxStop
			// 
			this.groupBoxStop.AutoSize = true;
			this.groupBoxStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxStop.Controls.Add(this.tableLayoutPanelStop);
			this.groupBoxStop.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBoxStop.Location = new System.Drawing.Point(0, 257);
			this.groupBoxStop.Margin = new System.Windows.Forms.Padding(4);
			this.groupBoxStop.Name = "groupBoxStop";
			this.groupBoxStop.Padding = new System.Windows.Forms.Padding(4);
			this.groupBoxStop.Size = new System.Drawing.Size(466, 159);
			this.groupBoxStop.TabIndex = 20;
			this.groupBoxStop.TabStop = false;
			this.groupBoxStop.Text = "Stop";
			// 
			// tableLayoutPanelStop
			// 
			this.tableLayoutPanelStop.AutoSize = true;
			this.tableLayoutPanelStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelStop.ColumnCount = 5;
			this.tableLayoutPanelStop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelStop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanelStop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanelStop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanelStop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanelStop.Controls.Add(this.dateTimePickerTime, 3, 2);
			this.tableLayoutPanelStop.Controls.Add(this.radioButtonElapsedTime, 0, 1);
			this.tableLayoutPanelStop.Controls.Add(this.radioButtonDateTime, 0, 2);
			this.tableLayoutPanelStop.Controls.Add(this.dateTimePickerDate, 1, 2);
			this.tableLayoutPanelStop.Controls.Add(this.radioButtonNumScans, 0, 3);
			this.tableLayoutPanelStop.Controls.Add(this.radioButtonStop, 0, 4);
			this.tableLayoutPanelStop.Controls.Add(this.numericUpDownHours, 1, 1);
			this.tableLayoutPanelStop.Controls.Add(this.numericUpDownMinutes, 2, 1);
			this.tableLayoutPanelStop.Controls.Add(this.numericUpDownSeconds, 3, 1);
			this.tableLayoutPanelStop.Controls.Add(this.label1, 1, 0);
			this.tableLayoutPanelStop.Controls.Add(this.label3, 2, 0);
			this.tableLayoutPanelStop.Controls.Add(this.label4, 3, 0);
			this.tableLayoutPanelStop.Controls.Add(this.numericUpDownNumScans, 1, 3);
			this.tableLayoutPanelStop.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanelStop.Location = new System.Drawing.Point(4, 20);
			this.tableLayoutPanelStop.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanelStop.Name = "tableLayoutPanelStop";
			this.tableLayoutPanelStop.RowCount = 5;
			this.tableLayoutPanelStop.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelStop.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelStop.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelStop.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelStop.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelStop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
			this.tableLayoutPanelStop.Size = new System.Drawing.Size(458, 135);
			this.tableLayoutPanelStop.TabIndex = 14;
			// 
			// radioButtonElapsedTime
			// 
			this.radioButtonElapsedTime.AutoSize = true;
			this.radioButtonElapsedTime.Location = new System.Drawing.Point(4, 19);
			this.radioButtonElapsedTime.Margin = new System.Windows.Forms.Padding(4);
			this.radioButtonElapsedTime.Name = "radioButtonElapsedTime";
			this.radioButtonElapsedTime.Size = new System.Drawing.Size(94, 19);
			this.radioButtonElapsedTime.TabIndex = 19;
			this.radioButtonElapsedTime.Text = "Elapsed Time";
			this.radioButtonElapsedTime.UseVisualStyleBackColor = true;
			this.radioButtonElapsedTime.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
			// 
			// radioButtonDateTime
			// 
			this.radioButtonDateTime.AutoSize = true;
			this.radioButtonDateTime.Location = new System.Drawing.Point(4, 50);
			this.radioButtonDateTime.Margin = new System.Windows.Forms.Padding(4);
			this.radioButtonDateTime.Name = "radioButtonDateTime";
			this.radioButtonDateTime.Size = new System.Drawing.Size(80, 19);
			this.radioButtonDateTime.TabIndex = 20;
			this.radioButtonDateTime.Text = "Date/Time";
			this.radioButtonDateTime.UseVisualStyleBackColor = true;
			this.radioButtonDateTime.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
			// 
			// dateTimePickerDate
			// 
			this.dateTimePickerDate.Checked = false;
			this.tableLayoutPanelStop.SetColumnSpan(this.dateTimePickerDate, 2);
			this.dateTimePickerDate.CustomFormat = "M/dd/yyyy hh:mm:ss";
			this.dateTimePickerDate.Enabled = false;
			this.dateTimePickerDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePickerDate.Location = new System.Drawing.Point(106, 50);
			this.dateTimePickerDate.Margin = new System.Windows.Forms.Padding(4);
			this.dateTimePickerDate.MinDate = new System.DateTime(2021, 5, 28, 16, 58, 24, 0);
			this.dateTimePickerDate.Name = "dateTimePickerDate";
			this.dateTimePickerDate.Size = new System.Drawing.Size(140, 23);
			this.dateTimePickerDate.TabIndex = 27;
			this.dateTimePickerDate.Value = new System.DateTime(2022, 5, 28, 16, 58, 1, 0);
			// 
			// radioButtonNumScans
			// 
			this.radioButtonNumScans.AutoSize = true;
			this.radioButtonNumScans.Location = new System.Drawing.Point(4, 81);
			this.radioButtonNumScans.Margin = new System.Windows.Forms.Padding(4);
			this.radioButtonNumScans.Name = "radioButtonNumScans";
			this.radioButtonNumScans.Size = new System.Drawing.Size(79, 19);
			this.radioButtonNumScans.TabIndex = 18;
			this.radioButtonNumScans.Text = "# of Scans";
			this.radioButtonNumScans.UseVisualStyleBackColor = true;
			this.radioButtonNumScans.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
			// 
			// radioButtonStop
			// 
			this.radioButtonStop.AutoSize = true;
			this.radioButtonStop.Checked = true;
			this.radioButtonStop.Location = new System.Drawing.Point(4, 112);
			this.radioButtonStop.Margin = new System.Windows.Forms.Padding(4);
			this.radioButtonStop.Name = "radioButtonStop";
			this.radioButtonStop.Size = new System.Drawing.Size(88, 19);
			this.radioButtonStop.TabIndex = 17;
			this.radioButtonStop.TabStop = true;
			this.radioButtonStop.Text = "Stop Button";
			this.radioButtonStop.UseVisualStyleBackColor = true;
			this.radioButtonStop.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
			// 
			// numericUpDownHours
			// 
			this.numericUpDownHours.Enabled = false;
			this.numericUpDownHours.Location = new System.Drawing.Point(106, 19);
			this.numericUpDownHours.Margin = new System.Windows.Forms.Padding(4);
			this.numericUpDownHours.Maximum = new decimal(new int[] {
            36000000,
            0,
            0,
            0});
			this.numericUpDownHours.Name = "numericUpDownHours";
			this.numericUpDownHours.Size = new System.Drawing.Size(60, 23);
			this.numericUpDownHours.TabIndex = 22;
			this.numericUpDownHours.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// numericUpDownMinutes
			// 
			this.numericUpDownMinutes.Enabled = false;
			this.numericUpDownMinutes.Location = new System.Drawing.Point(195, 19);
			this.numericUpDownMinutes.Margin = new System.Windows.Forms.Padding(4);
			this.numericUpDownMinutes.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
			this.numericUpDownMinutes.Name = "numericUpDownMinutes";
			this.numericUpDownMinutes.Size = new System.Drawing.Size(60, 23);
			this.numericUpDownMinutes.TabIndex = 23;
			this.numericUpDownMinutes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// numericUpDownSeconds
			// 
			this.numericUpDownSeconds.Enabled = false;
			this.numericUpDownSeconds.Location = new System.Drawing.Point(284, 19);
			this.numericUpDownSeconds.Margin = new System.Windows.Forms.Padding(4);
			this.numericUpDownSeconds.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
			this.numericUpDownSeconds.Name = "numericUpDownSeconds";
			this.numericUpDownSeconds.Size = new System.Drawing.Size(60, 23);
			this.numericUpDownSeconds.TabIndex = 24;
			this.numericUpDownSeconds.Value = new decimal(new int[] {
            59,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(106, 0);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 15);
			this.label1.TabIndex = 16;
			this.label1.Text = "Hours";
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(195, 0);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(50, 15);
			this.label3.TabIndex = 29;
			this.label3.Text = "Minutes";
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(284, 0);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(51, 15);
			this.label4.TabIndex = 30;
			this.label4.Text = "Seconds";
			// 
			// numericUpDownNumScans
			// 
			this.tableLayoutPanelStop.SetColumnSpan(this.numericUpDownNumScans, 3);
			this.numericUpDownNumScans.Enabled = false;
			this.numericUpDownNumScans.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDownNumScans.Location = new System.Drawing.Point(106, 81);
			this.numericUpDownNumScans.Margin = new System.Windows.Forms.Padding(4);
			this.numericUpDownNumScans.Maximum = new decimal(new int[] {
            36000000,
            0,
            0,
            0});
			this.numericUpDownNumScans.Name = "numericUpDownNumScans";
			this.numericUpDownNumScans.Size = new System.Drawing.Size(105, 23);
			this.numericUpDownNumScans.TabIndex = 21;
			this.numericUpDownNumScans.Value = new decimal(new int[] {
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
			this.groupBoxCommand.Location = new System.Drawing.Point(0, 416);
			this.groupBoxCommand.Margin = new System.Windows.Forms.Padding(4);
			this.groupBoxCommand.Name = "groupBoxCommand";
			this.groupBoxCommand.Padding = new System.Windows.Forms.Padding(4);
			this.groupBoxCommand.Size = new System.Drawing.Size(466, 45);
			this.groupBoxCommand.TabIndex = 21;
			this.groupBoxCommand.TabStop = false;
			this.groupBoxCommand.Text = "Command";
			// 
			// textBoxCommand
			// 
			this.textBoxCommand.Dock = System.Windows.Forms.DockStyle.Top;
			this.textBoxCommand.Location = new System.Drawing.Point(4, 20);
			this.textBoxCommand.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxCommand.Name = "textBoxCommand";
			this.textBoxCommand.Size = new System.Drawing.Size(458, 23);
			this.textBoxCommand.TabIndex = 10;
			// 
			// groupBoxResponse
			// 
			this.groupBoxResponse.AutoSize = true;
			this.groupBoxResponse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxResponse.Controls.Add(this.textBoxResponse);
			this.groupBoxResponse.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBoxResponse.Location = new System.Drawing.Point(0, 461);
			this.groupBoxResponse.Margin = new System.Windows.Forms.Padding(4);
			this.groupBoxResponse.Name = "groupBoxResponse";
			this.groupBoxResponse.Padding = new System.Windows.Forms.Padding(4);
			this.groupBoxResponse.Size = new System.Drawing.Size(466, 47);
			this.groupBoxResponse.TabIndex = 22;
			this.groupBoxResponse.TabStop = false;
			this.groupBoxResponse.Text = "Response";
			// 
			// textBoxResponse
			// 
			this.textBoxResponse.Dock = System.Windows.Forms.DockStyle.Top;
			this.textBoxResponse.Location = new System.Drawing.Point(4, 20);
			this.textBoxResponse.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxResponse.Name = "textBoxResponse";
			this.textBoxResponse.ReadOnly = true;
			this.textBoxResponse.Size = new System.Drawing.Size(458, 23);
			this.textBoxResponse.TabIndex = 10;
			// 
			// FormLog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(466, 565);
			this.Controls.Add(this.groupBoxResponse);
			this.Controls.Add(this.groupBoxCommand);
			this.Controls.Add(this.groupBoxStop);
			this.Controls.Add(this.groupBoxSample);
			this.Controls.Add(this.groupBoxStartStop);
			this.Controls.Add(this.groupBoxSerialPort);
			this.Controls.Add(this.groupBoxFilename);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.menuStrip);
			this.MainMenuStrip = this.menuStrip;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FormLog";
			this.Text = "Data logger";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLog_FormClosing);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.groupBoxFilename.ResumeLayout(false);
			this.groupBoxFilename.PerformLayout();
			this.tableLayoutPanelFilename.ResumeLayout(false);
			this.tableLayoutPanelFilename.PerformLayout();
			this.groupBoxStartStop.ResumeLayout(false);
			this.groupBoxStartStop.PerformLayout();
			this.tableLayoutPanelStartStop.ResumeLayout(false);
			this.tableLayoutPanelStartStop.PerformLayout();
			this.tableLayoutPanelButtons.ResumeLayout(false);
			this.tableLayoutPanelSerialPort.ResumeLayout(false);
			this.tableLayoutPanelSerialPort.PerformLayout();
			this.groupBoxSerialPort.ResumeLayout(false);
			this.groupBoxSerialPort.PerformLayout();
			this.groupBoxSample.ResumeLayout(false);
			this.groupBoxSample.PerformLayout();
			this.tableLayoutPanelSample.ResumeLayout(false);
			this.tableLayoutPanelSample.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
			this.groupBoxStop.ResumeLayout(false);
			this.groupBoxStop.PerformLayout();
			this.tableLayoutPanelStop.ResumeLayout(false);
			this.tableLayoutPanelStop.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownHours)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinutes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeconds)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumScans)).EndInit();
			this.groupBoxCommand.ResumeLayout(false);
			this.groupBoxCommand.PerformLayout();
			this.groupBoxResponse.ResumeLayout(false);
			this.groupBoxResponse.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
		private System.Windows.Forms.GroupBox groupBoxFilename;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFilename;
		private System.Windows.Forms.TextBox textBoxFilename;
		private System.Windows.Forms.Button buttonBrowse;
		private System.Windows.Forms.GroupBox groupBoxStartStop;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelStartStop;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelButtons;
		private System.Windows.Forms.Button buttonStop;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSerialPort;
		private System.Windows.Forms.Label labelComPort;
		private System.Windows.Forms.ComboBox comboBoxSerialPort;
		private System.Windows.Forms.Button buttonPortRefresh;
		private System.Windows.Forms.Label labelBaudRate;
		private System.Windows.Forms.ComboBox comboBoxBaudRate;
		private System.Windows.Forms.Label labelHandshake;
		private System.Windows.Forms.Label labelStopBits;
		private System.Windows.Forms.ComboBox comboBoxStopBits;
		private System.Windows.Forms.GroupBox groupBoxSerialPort;
		private System.Windows.Forms.GroupBox groupBoxSample;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSample;
		private System.Windows.Forms.NumericUpDown numericUpDownInterval;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker dateTimePickerTime;
		private System.Windows.Forms.GroupBox groupBoxStop;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelStop;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton radioButtonNumScans;
		private System.Windows.Forms.NumericUpDown numericUpDownNumScans;
		private System.Windows.Forms.RadioButton radioButtonElapsedTime;
		private System.Windows.Forms.NumericUpDown numericUpDownHours;
		private System.Windows.Forms.NumericUpDown numericUpDownMinutes;
		private System.Windows.Forms.NumericUpDown numericUpDownSeconds;
		private System.Windows.Forms.RadioButton radioButtonDateTime;
		private System.Windows.Forms.DateTimePicker dateTimePickerDate;
		private System.Windows.Forms.GroupBox groupBoxCommand;
		private System.Windows.Forms.TextBox textBoxCommand;
		private System.Windows.Forms.GroupBox groupBoxResponse;
		private System.Windows.Forms.TextBox textBoxResponse;
		private System.Windows.Forms.RadioButton radioButtonStop;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBoxHandshake;
		private System.Windows.Forms.Label labelParity;
		private System.Windows.Forms.ComboBox comboBoxParity;
		private System.Windows.Forms.ComboBox comboBoxDataBits;
		private System.Windows.Forms.Label labelDataBits;
		private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
	}
}

