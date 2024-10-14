namespace Sensit.App.Log
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
			menuStrip = new System.Windows.Forms.MenuStrip();
			fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			wikiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			statusStrip = new System.Windows.Forms.StatusStrip();
			toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			groupBoxFilename = new System.Windows.Forms.GroupBox();
			tableLayoutPanelFilename = new System.Windows.Forms.TableLayoutPanel();
			textBoxFilename = new System.Windows.Forms.TextBox();
			buttonBrowse = new System.Windows.Forms.Button();
			groupBoxStartStop = new System.Windows.Forms.GroupBox();
			tableLayoutPanelStartStop = new System.Windows.Forms.TableLayoutPanel();
			tableLayoutPanelButtons = new System.Windows.Forms.TableLayoutPanel();
			buttonStop = new System.Windows.Forms.Button();
			buttonStart = new System.Windows.Forms.Button();
			tableLayoutPanelSerialPort = new System.Windows.Forms.TableLayoutPanel();
			comboBoxDataBits = new System.Windows.Forms.ComboBox();
			labelDataBits = new System.Windows.Forms.Label();
			labelComPort = new System.Windows.Forms.Label();
			comboBoxSerialPort = new System.Windows.Forms.ComboBox();
			buttonPortRefresh = new System.Windows.Forms.Button();
			labelBaudRate = new System.Windows.Forms.Label();
			comboBoxBaudRate = new System.Windows.Forms.ComboBox();
			comboBoxParity = new System.Windows.Forms.ComboBox();
			labelStopBits = new System.Windows.Forms.Label();
			comboBoxStopBits = new System.Windows.Forms.ComboBox();
			labelParity = new System.Windows.Forms.Label();
			comboBoxHandshake = new System.Windows.Forms.ComboBox();
			labelHandshake = new System.Windows.Forms.Label();
			groupBoxSerialPort = new System.Windows.Forms.GroupBox();
			groupBoxSample = new System.Windows.Forms.GroupBox();
			tableLayoutPanelSample = new System.Windows.Forms.TableLayoutPanel();
			labelCommand = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			textBoxCommand = new System.Windows.Forms.TextBox();
			numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
			radioButtonPolled = new System.Windows.Forms.RadioButton();
			radioButtonStream = new System.Windows.Forms.RadioButton();
			label5 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			dateTimePickerTime = new System.Windows.Forms.DateTimePicker();
			groupBoxStop = new System.Windows.Forms.GroupBox();
			tableLayoutPanelStop = new System.Windows.Forms.TableLayoutPanel();
			radioButtonElapsedTime = new System.Windows.Forms.RadioButton();
			radioButtonDateTime = new System.Windows.Forms.RadioButton();
			dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
			radioButtonNumScans = new System.Windows.Forms.RadioButton();
			radioButtonStop = new System.Windows.Forms.RadioButton();
			numericUpDownHours = new System.Windows.Forms.NumericUpDown();
			numericUpDownMinutes = new System.Windows.Forms.NumericUpDown();
			numericUpDownSeconds = new System.Windows.Forms.NumericUpDown();
			label1 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			numericUpDownNumScans = new System.Windows.Forms.NumericUpDown();
			groupBoxResponse = new System.Windows.Forms.GroupBox();
			textBoxResponse = new System.Windows.Forms.TextBox();
			menuStrip.SuspendLayout();
			statusStrip.SuspendLayout();
			groupBoxFilename.SuspendLayout();
			tableLayoutPanelFilename.SuspendLayout();
			groupBoxStartStop.SuspendLayout();
			tableLayoutPanelStartStop.SuspendLayout();
			tableLayoutPanelButtons.SuspendLayout();
			tableLayoutPanelSerialPort.SuspendLayout();
			groupBoxSerialPort.SuspendLayout();
			groupBoxSample.SuspendLayout();
			tableLayoutPanelSample.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDownInterval).BeginInit();
			groupBoxStop.SuspendLayout();
			tableLayoutPanelStop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDownHours).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDownMinutes).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDownSeconds).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDownNumScans).BeginInit();
			groupBoxResponse.SuspendLayout();
			SuspendLayout();
			// 
			// menuStrip
			// 
			menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, testToolStripMenuItem, helpToolStripMenuItem });
			menuStrip.Location = new System.Drawing.Point(0, 0);
			menuStrip.Name = "menuStrip";
			menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
			menuStrip.Size = new System.Drawing.Size(484, 24);
			menuStrip.TabIndex = 0;
			menuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { exitToolStripMenuItem });
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			fileToolStripMenuItem.Text = "&File";
			// 
			// exitToolStripMenuItem
			// 
			exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
			exitToolStripMenuItem.Text = "&Exit";
			exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
			// 
			// testToolStripMenuItem
			// 
			testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { startToolStripMenuItem, stopToolStripMenuItem });
			testToolStripMenuItem.Name = "testToolStripMenuItem";
			testToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			testToolStripMenuItem.Text = "&Test";
			// 
			// startToolStripMenuItem
			// 
			startToolStripMenuItem.Name = "startToolStripMenuItem";
			startToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
			startToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			startToolStripMenuItem.Text = "&Start";
			startToolStripMenuItem.Click += ButtonStart_Click;
			// 
			// stopToolStripMenuItem
			// 
			stopToolStripMenuItem.Name = "stopToolStripMenuItem";
			stopToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
			stopToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			stopToolStripMenuItem.Text = "&Stop";
			stopToolStripMenuItem.Click += ButtonStop_Click;
			// 
			// helpToolStripMenuItem
			// 
			helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { wikiToolStripMenuItem, aboutToolStripMenuItem });
			helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			helpToolStripMenuItem.Text = "&Help";
			// 
			// wikiToolStripMenuItem
			// 
			wikiToolStripMenuItem.Name = "wikiToolStripMenuItem";
			wikiToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			wikiToolStripMenuItem.Text = "&Wiki";
			wikiToolStripMenuItem.Click += WikiToolStripMenuItem_Click;
			// 
			// aboutToolStripMenuItem
			// 
			aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			aboutToolStripMenuItem.Text = "&About";
			aboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
			// 
			// statusStrip
			// 
			statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel });
			statusStrip.Location = new System.Drawing.Point(0, 629);
			statusStrip.Name = "statusStrip";
			statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 17, 0);
			statusStrip.Size = new System.Drawing.Size(484, 22);
			statusStrip.TabIndex = 1;
			statusStrip.Text = "statusStrip1";
			// 
			// toolStripStatusLabel
			// 
			toolStripStatusLabel.Name = "toolStripStatusLabel";
			toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
			toolStripStatusLabel.Text = "Ready";
			// 
			// groupBoxFilename
			// 
			groupBoxFilename.AutoSize = true;
			groupBoxFilename.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			groupBoxFilename.Controls.Add(tableLayoutPanelFilename);
			groupBoxFilename.Dock = System.Windows.Forms.DockStyle.Top;
			groupBoxFilename.Location = new System.Drawing.Point(0, 24);
			groupBoxFilename.Margin = new System.Windows.Forms.Padding(4);
			groupBoxFilename.Name = "groupBoxFilename";
			groupBoxFilename.Padding = new System.Windows.Forms.Padding(4);
			groupBoxFilename.Size = new System.Drawing.Size(484, 58);
			groupBoxFilename.TabIndex = 7;
			groupBoxFilename.TabStop = false;
			groupBoxFilename.Text = "Filename";
			// 
			// tableLayoutPanelFilename
			// 
			tableLayoutPanelFilename.AutoSize = true;
			tableLayoutPanelFilename.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			tableLayoutPanelFilename.ColumnCount = 2;
			tableLayoutPanelFilename.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanelFilename.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanelFilename.Controls.Add(textBoxFilename, 0, 0);
			tableLayoutPanelFilename.Controls.Add(buttonBrowse, 1, 0);
			tableLayoutPanelFilename.Dock = System.Windows.Forms.DockStyle.Top;
			tableLayoutPanelFilename.Location = new System.Drawing.Point(4, 20);
			tableLayoutPanelFilename.Margin = new System.Windows.Forms.Padding(4);
			tableLayoutPanelFilename.Name = "tableLayoutPanelFilename";
			tableLayoutPanelFilename.RowCount = 1;
			tableLayoutPanelFilename.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanelFilename.Size = new System.Drawing.Size(476, 34);
			tableLayoutPanelFilename.TabIndex = 1;
			// 
			// textBoxFilename
			// 
			textBoxFilename.Dock = System.Windows.Forms.DockStyle.Fill;
			textBoxFilename.Location = new System.Drawing.Point(4, 4);
			textBoxFilename.Margin = new System.Windows.Forms.Padding(4);
			textBoxFilename.Name = "textBoxFilename";
			textBoxFilename.Size = new System.Drawing.Size(372, 23);
			textBoxFilename.TabIndex = 9;
			// 
			// buttonBrowse
			// 
			buttonBrowse.Anchor = System.Windows.Forms.AnchorStyles.Left;
			buttonBrowse.Location = new System.Drawing.Point(384, 4);
			buttonBrowse.Margin = new System.Windows.Forms.Padding(4);
			buttonBrowse.Name = "buttonBrowse";
			buttonBrowse.Size = new System.Drawing.Size(88, 26);
			buttonBrowse.TabIndex = 2;
			buttonBrowse.Text = "Browse";
			buttonBrowse.UseVisualStyleBackColor = true;
			buttonBrowse.Click += ButtonBrowse_Click;
			// 
			// groupBoxStartStop
			// 
			groupBoxStartStop.AutoSize = true;
			groupBoxStartStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			groupBoxStartStop.Controls.Add(tableLayoutPanelStartStop);
			groupBoxStartStop.Dock = System.Windows.Forms.DockStyle.Bottom;
			groupBoxStartStop.Location = new System.Drawing.Point(0, 563);
			groupBoxStartStop.Margin = new System.Windows.Forms.Padding(4);
			groupBoxStartStop.Name = "groupBoxStartStop";
			groupBoxStartStop.Padding = new System.Windows.Forms.Padding(4);
			groupBoxStartStop.Size = new System.Drawing.Size(484, 66);
			groupBoxStartStop.TabIndex = 13;
			groupBoxStartStop.TabStop = false;
			groupBoxStartStop.Text = "Start/Stop";
			// 
			// tableLayoutPanelStartStop
			// 
			tableLayoutPanelStartStop.AutoSize = true;
			tableLayoutPanelStartStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			tableLayoutPanelStartStop.ColumnCount = 1;
			tableLayoutPanelStartStop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanelStartStop.Controls.Add(tableLayoutPanelButtons, 0, 0);
			tableLayoutPanelStartStop.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanelStartStop.Location = new System.Drawing.Point(4, 20);
			tableLayoutPanelStartStop.Margin = new System.Windows.Forms.Padding(4);
			tableLayoutPanelStartStop.Name = "tableLayoutPanelStartStop";
			tableLayoutPanelStartStop.RowCount = 1;
			tableLayoutPanelStartStop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanelStartStop.Size = new System.Drawing.Size(476, 42);
			tableLayoutPanelStartStop.TabIndex = 1;
			// 
			// tableLayoutPanelButtons
			// 
			tableLayoutPanelButtons.Anchor = System.Windows.Forms.AnchorStyles.None;
			tableLayoutPanelButtons.AutoSize = true;
			tableLayoutPanelButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			tableLayoutPanelButtons.ColumnCount = 2;
			tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanelButtons.Controls.Add(buttonStop, 1, 0);
			tableLayoutPanelButtons.Controls.Add(buttonStart, 0, 0);
			tableLayoutPanelButtons.Location = new System.Drawing.Point(142, 4);
			tableLayoutPanelButtons.Margin = new System.Windows.Forms.Padding(4);
			tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
			tableLayoutPanelButtons.RowCount = 1;
			tableLayoutPanelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanelButtons.Size = new System.Drawing.Size(192, 34);
			tableLayoutPanelButtons.TabIndex = 0;
			// 
			// buttonStop
			// 
			buttonStop.Enabled = false;
			buttonStop.Location = new System.Drawing.Point(100, 4);
			buttonStop.Margin = new System.Windows.Forms.Padding(4);
			buttonStop.Name = "buttonStop";
			buttonStop.Size = new System.Drawing.Size(88, 26);
			buttonStop.TabIndex = 1;
			buttonStop.Text = "Stop";
			buttonStop.UseVisualStyleBackColor = true;
			buttonStop.Click += ButtonStop_Click;
			// 
			// buttonStart
			// 
			buttonStart.Location = new System.Drawing.Point(4, 4);
			buttonStart.Margin = new System.Windows.Forms.Padding(4);
			buttonStart.Name = "buttonStart";
			buttonStart.Size = new System.Drawing.Size(88, 26);
			buttonStart.TabIndex = 0;
			buttonStart.Text = "Start";
			buttonStart.UseVisualStyleBackColor = true;
			buttonStart.Click += ButtonStart_Click;
			// 
			// tableLayoutPanelSerialPort
			// 
			tableLayoutPanelSerialPort.AutoSize = true;
			tableLayoutPanelSerialPort.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			tableLayoutPanelSerialPort.ColumnCount = 5;
			tableLayoutPanelSerialPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanelSerialPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanelSerialPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanelSerialPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanelSerialPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanelSerialPort.Controls.Add(comboBoxDataBits, 0, 2);
			tableLayoutPanelSerialPort.Controls.Add(labelDataBits, 0, 2);
			tableLayoutPanelSerialPort.Controls.Add(labelComPort, 0, 0);
			tableLayoutPanelSerialPort.Controls.Add(comboBoxSerialPort, 1, 0);
			tableLayoutPanelSerialPort.Controls.Add(buttonPortRefresh, 2, 0);
			tableLayoutPanelSerialPort.Controls.Add(labelBaudRate, 0, 1);
			tableLayoutPanelSerialPort.Controls.Add(comboBoxBaudRate, 1, 1);
			tableLayoutPanelSerialPort.Controls.Add(comboBoxParity, 4, 0);
			tableLayoutPanelSerialPort.Controls.Add(labelStopBits, 3, 1);
			tableLayoutPanelSerialPort.Controls.Add(comboBoxStopBits, 4, 1);
			tableLayoutPanelSerialPort.Controls.Add(labelParity, 3, 0);
			tableLayoutPanelSerialPort.Controls.Add(comboBoxHandshake, 4, 2);
			tableLayoutPanelSerialPort.Controls.Add(labelHandshake, 3, 2);
			tableLayoutPanelSerialPort.Dock = System.Windows.Forms.DockStyle.Top;
			tableLayoutPanelSerialPort.Location = new System.Drawing.Point(4, 20);
			tableLayoutPanelSerialPort.Margin = new System.Windows.Forms.Padding(4);
			tableLayoutPanelSerialPort.Name = "tableLayoutPanelSerialPort";
			tableLayoutPanelSerialPort.RowCount = 3;
			tableLayoutPanelSerialPort.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanelSerialPort.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanelSerialPort.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanelSerialPort.Size = new System.Drawing.Size(476, 96);
			tableLayoutPanelSerialPort.TabIndex = 14;
			// 
			// comboBoxDataBits
			// 
			comboBoxDataBits.Dock = System.Windows.Forms.DockStyle.Fill;
			comboBoxDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBoxDataBits.FormattingEnabled = true;
			comboBoxDataBits.Location = new System.Drawing.Point(75, 69);
			comboBoxDataBits.Margin = new System.Windows.Forms.Padding(4);
			comboBoxDataBits.Name = "comboBoxDataBits";
			comboBoxDataBits.Size = new System.Drawing.Size(136, 23);
			comboBoxDataBits.TabIndex = 15;
			// 
			// labelDataBits
			// 
			labelDataBits.Anchor = System.Windows.Forms.AnchorStyles.Left;
			labelDataBits.AutoSize = true;
			labelDataBits.Location = new System.Drawing.Point(4, 73);
			labelDataBits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelDataBits.Name = "labelDataBits";
			labelDataBits.Size = new System.Drawing.Size(56, 15);
			labelDataBits.TabIndex = 14;
			labelDataBits.Text = "Data Bits:";
			// 
			// labelComPort
			// 
			labelComPort.Anchor = System.Windows.Forms.AnchorStyles.Left;
			labelComPort.AutoSize = true;
			labelComPort.Location = new System.Drawing.Point(4, 9);
			labelComPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelComPort.Name = "labelComPort";
			labelComPort.Size = new System.Drawing.Size(63, 15);
			labelComPort.TabIndex = 0;
			labelComPort.Text = "COM Port:";
			// 
			// comboBoxSerialPort
			// 
			comboBoxSerialPort.AllowDrop = true;
			comboBoxSerialPort.Dock = System.Windows.Forms.DockStyle.Fill;
			comboBoxSerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBoxSerialPort.FormattingEnabled = true;
			comboBoxSerialPort.Location = new System.Drawing.Point(75, 4);
			comboBoxSerialPort.Margin = new System.Windows.Forms.Padding(4);
			comboBoxSerialPort.Name = "comboBoxSerialPort";
			comboBoxSerialPort.Size = new System.Drawing.Size(136, 23);
			comboBoxSerialPort.TabIndex = 1;
			// 
			// buttonPortRefresh
			// 
			buttonPortRefresh.Image = (System.Drawing.Image)resources.GetObject("buttonPortRefresh.Image");
			buttonPortRefresh.Location = new System.Drawing.Point(219, 4);
			buttonPortRefresh.Margin = new System.Windows.Forms.Padding(4);
			buttonPortRefresh.Name = "buttonPortRefresh";
			buttonPortRefresh.Size = new System.Drawing.Size(32, 26);
			buttonPortRefresh.TabIndex = 2;
			buttonPortRefresh.UseVisualStyleBackColor = true;
			// 
			// labelBaudRate
			// 
			labelBaudRate.Anchor = System.Windows.Forms.AnchorStyles.Left;
			labelBaudRate.AutoSize = true;
			labelBaudRate.Location = new System.Drawing.Point(4, 42);
			labelBaudRate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelBaudRate.Name = "labelBaudRate";
			labelBaudRate.Size = new System.Drawing.Size(63, 15);
			labelBaudRate.TabIndex = 3;
			labelBaudRate.Text = "Baud Rate:";
			// 
			// comboBoxBaudRate
			// 
			comboBoxBaudRate.Dock = System.Windows.Forms.DockStyle.Fill;
			comboBoxBaudRate.FormattingEnabled = true;
			comboBoxBaudRate.Location = new System.Drawing.Point(75, 38);
			comboBoxBaudRate.Margin = new System.Windows.Forms.Padding(4);
			comboBoxBaudRate.Name = "comboBoxBaudRate";
			comboBoxBaudRate.Size = new System.Drawing.Size(136, 23);
			comboBoxBaudRate.TabIndex = 4;
			// 
			// comboBoxParity
			// 
			comboBoxParity.Dock = System.Windows.Forms.DockStyle.Fill;
			comboBoxParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBoxParity.FormattingEnabled = true;
			comboBoxParity.Location = new System.Drawing.Point(336, 4);
			comboBoxParity.Margin = new System.Windows.Forms.Padding(4);
			comboBoxParity.Name = "comboBoxParity";
			comboBoxParity.Size = new System.Drawing.Size(136, 23);
			comboBoxParity.TabIndex = 11;
			// 
			// labelStopBits
			// 
			labelStopBits.Anchor = System.Windows.Forms.AnchorStyles.Left;
			labelStopBits.AutoSize = true;
			labelStopBits.Location = new System.Drawing.Point(259, 42);
			labelStopBits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelStopBits.Name = "labelStopBits";
			labelStopBits.Size = new System.Drawing.Size(56, 15);
			labelStopBits.TabIndex = 5;
			labelStopBits.Text = "Stop Bits:";
			// 
			// comboBoxStopBits
			// 
			comboBoxStopBits.Dock = System.Windows.Forms.DockStyle.Fill;
			comboBoxStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBoxStopBits.FormattingEnabled = true;
			comboBoxStopBits.Location = new System.Drawing.Point(336, 38);
			comboBoxStopBits.Margin = new System.Windows.Forms.Padding(4);
			comboBoxStopBits.Name = "comboBoxStopBits";
			comboBoxStopBits.Size = new System.Drawing.Size(136, 23);
			comboBoxStopBits.TabIndex = 6;
			// 
			// labelParity
			// 
			labelParity.Anchor = System.Windows.Forms.AnchorStyles.Left;
			labelParity.AutoSize = true;
			labelParity.Location = new System.Drawing.Point(259, 9);
			labelParity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelParity.Name = "labelParity";
			labelParity.Size = new System.Drawing.Size(40, 15);
			labelParity.TabIndex = 12;
			labelParity.Text = "Parity:";
			// 
			// comboBoxHandshake
			// 
			comboBoxHandshake.Dock = System.Windows.Forms.DockStyle.Fill;
			comboBoxHandshake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBoxHandshake.FormattingEnabled = true;
			comboBoxHandshake.Location = new System.Drawing.Point(336, 69);
			comboBoxHandshake.Margin = new System.Windows.Forms.Padding(4);
			comboBoxHandshake.Name = "comboBoxHandshake";
			comboBoxHandshake.Size = new System.Drawing.Size(136, 23);
			comboBoxHandshake.TabIndex = 13;
			// 
			// labelHandshake
			// 
			labelHandshake.Anchor = System.Windows.Forms.AnchorStyles.Left;
			labelHandshake.AutoSize = true;
			labelHandshake.Location = new System.Drawing.Point(259, 73);
			labelHandshake.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelHandshake.Name = "labelHandshake";
			labelHandshake.Size = new System.Drawing.Size(69, 15);
			labelHandshake.TabIndex = 10;
			labelHandshake.Text = "Handshake:";
			// 
			// groupBoxSerialPort
			// 
			groupBoxSerialPort.AutoSize = true;
			groupBoxSerialPort.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			groupBoxSerialPort.Controls.Add(tableLayoutPanelSerialPort);
			groupBoxSerialPort.Dock = System.Windows.Forms.DockStyle.Top;
			groupBoxSerialPort.Location = new System.Drawing.Point(0, 82);
			groupBoxSerialPort.Margin = new System.Windows.Forms.Padding(4);
			groupBoxSerialPort.Name = "groupBoxSerialPort";
			groupBoxSerialPort.Padding = new System.Windows.Forms.Padding(4);
			groupBoxSerialPort.Size = new System.Drawing.Size(484, 120);
			groupBoxSerialPort.TabIndex = 8;
			groupBoxSerialPort.TabStop = false;
			groupBoxSerialPort.Text = "Serial Port";
			// 
			// groupBoxSample
			// 
			groupBoxSample.AutoSize = true;
			groupBoxSample.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			groupBoxSample.Controls.Add(tableLayoutPanelSample);
			groupBoxSample.Dock = System.Windows.Forms.DockStyle.Top;
			groupBoxSample.Location = new System.Drawing.Point(0, 202);
			groupBoxSample.Margin = new System.Windows.Forms.Padding(4);
			groupBoxSample.Name = "groupBoxSample";
			groupBoxSample.Padding = new System.Windows.Forms.Padding(4);
			groupBoxSample.Size = new System.Drawing.Size(484, 140);
			groupBoxSample.TabIndex = 17;
			groupBoxSample.TabStop = false;
			groupBoxSample.Text = "Sample";
			// 
			// tableLayoutPanelSample
			// 
			tableLayoutPanelSample.AutoSize = true;
			tableLayoutPanelSample.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			tableLayoutPanelSample.ColumnCount = 4;
			tableLayoutPanelSample.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanelSample.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanelSample.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanelSample.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanelSample.Controls.Add(labelCommand, 1, 2);
			tableLayoutPanelSample.Controls.Add(label6, 1, 0);
			tableLayoutPanelSample.Controls.Add(label2, 1, 1);
			tableLayoutPanelSample.Controls.Add(textBoxCommand, 2, 2);
			tableLayoutPanelSample.Controls.Add(numericUpDownInterval, 2, 3);
			tableLayoutPanelSample.Controls.Add(radioButtonPolled, 0, 1);
			tableLayoutPanelSample.Controls.Add(radioButtonStream, 0, 0);
			tableLayoutPanelSample.Controls.Add(label5, 3, 3);
			tableLayoutPanelSample.Controls.Add(label7, 1, 3);
			tableLayoutPanelSample.Dock = System.Windows.Forms.DockStyle.Top;
			tableLayoutPanelSample.Location = new System.Drawing.Point(4, 20);
			tableLayoutPanelSample.Margin = new System.Windows.Forms.Padding(4);
			tableLayoutPanelSample.Name = "tableLayoutPanelSample";
			tableLayoutPanelSample.RowCount = 4;
			tableLayoutPanelSample.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanelSample.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanelSample.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanelSample.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanelSample.Size = new System.Drawing.Size(476, 116);
			tableLayoutPanelSample.TabIndex = 14;
			// 
			// labelCommand
			// 
			labelCommand.Anchor = System.Windows.Forms.AnchorStyles.Left;
			labelCommand.AutoSize = true;
			labelCommand.Location = new System.Drawing.Point(91, 62);
			labelCommand.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelCommand.Name = "labelCommand";
			labelCommand.Size = new System.Drawing.Size(67, 15);
			labelCommand.TabIndex = 25;
			labelCommand.Text = "Command:";
			// 
			// label6
			// 
			label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label6.AutoSize = true;
			tableLayoutPanelSample.SetColumnSpan(label6, 3);
			label6.Location = new System.Drawing.Point(91, 6);
			label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(199, 15);
			label6.TabIndex = 24;
			label6.Text = "Device sends data at regular interval.";
			// 
			// label2
			// 
			label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label2.AutoSize = true;
			tableLayoutPanelSample.SetColumnSpan(label2, 3);
			label2.Location = new System.Drawing.Point(91, 33);
			label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(248, 15);
			label2.TabIndex = 23;
			label2.Text = "Device sends data in response to a command.";
			// 
			// textBoxCommand
			// 
			textBoxCommand.Dock = System.Windows.Forms.DockStyle.Top;
			textBoxCommand.Location = new System.Drawing.Point(166, 58);
			textBoxCommand.Margin = new System.Windows.Forms.Padding(4);
			textBoxCommand.Name = "textBoxCommand";
			textBoxCommand.Size = new System.Drawing.Size(122, 23);
			textBoxCommand.TabIndex = 22;
			// 
			// numericUpDownInterval
			// 
			numericUpDownInterval.Dock = System.Windows.Forms.DockStyle.Fill;
			numericUpDownInterval.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
			numericUpDownInterval.Location = new System.Drawing.Point(166, 89);
			numericUpDownInterval.Margin = new System.Windows.Forms.Padding(4);
			numericUpDownInterval.Maximum = new decimal(new int[] { 36000000, 0, 0, 0 });
			numericUpDownInterval.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			numericUpDownInterval.Name = "numericUpDownInterval";
			numericUpDownInterval.Size = new System.Drawing.Size(122, 23);
			numericUpDownInterval.TabIndex = 1;
			numericUpDownInterval.Value = new decimal(new int[] { 1000, 0, 0, 0 });
			// 
			// radioButtonPolled
			// 
			radioButtonPolled.AutoSize = true;
			radioButtonPolled.Checked = true;
			radioButtonPolled.Location = new System.Drawing.Point(4, 31);
			radioButtonPolled.Margin = new System.Windows.Forms.Padding(4);
			radioButtonPolled.Name = "radioButtonPolled";
			radioButtonPolled.Size = new System.Drawing.Size(58, 19);
			radioButtonPolled.TabIndex = 20;
			radioButtonPolled.TabStop = true;
			radioButtonPolled.Text = "Polled";
			radioButtonPolled.UseVisualStyleBackColor = true;
			radioButtonPolled.CheckedChanged += RadioButtonSample_CheckedChanged;
			// 
			// radioButtonStream
			// 
			radioButtonStream.AutoSize = true;
			radioButtonStream.Location = new System.Drawing.Point(4, 4);
			radioButtonStream.Margin = new System.Windows.Forms.Padding(4);
			radioButtonStream.Name = "radioButtonStream";
			radioButtonStream.Size = new System.Drawing.Size(79, 19);
			radioButtonStream.TabIndex = 21;
			radioButtonStream.Text = "Streaming";
			radioButtonStream.UseVisualStyleBackColor = true;
			radioButtonStream.CheckedChanged += RadioButtonSample_CheckedChanged;
			// 
			// label5
			// 
			label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(296, 93);
			label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(23, 15);
			label5.TabIndex = 14;
			label5.Text = "ms";
			// 
			// label7
			// 
			label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(91, 93);
			label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(49, 15);
			label7.TabIndex = 26;
			label7.Text = "Interval:";
			// 
			// dateTimePickerTime
			// 
			dateTimePickerTime.Checked = false;
			tableLayoutPanelStop.SetColumnSpan(dateTimePickerTime, 2);
			dateTimePickerTime.Enabled = false;
			dateTimePickerTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			dateTimePickerTime.Location = new System.Drawing.Point(292, 50);
			dateTimePickerTime.Margin = new System.Windows.Forms.Padding(4);
			dateTimePickerTime.MinDate = new System.DateTime(2021, 5, 28, 0, 0, 0, 0);
			dateTimePickerTime.Name = "dateTimePickerTime";
			dateTimePickerTime.ShowUpDown = true;
			dateTimePickerTime.Size = new System.Drawing.Size(116, 23);
			dateTimePickerTime.TabIndex = 27;
			// 
			// groupBoxStop
			// 
			groupBoxStop.AutoSize = true;
			groupBoxStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			groupBoxStop.Controls.Add(tableLayoutPanelStop);
			groupBoxStop.Dock = System.Windows.Forms.DockStyle.Top;
			groupBoxStop.Location = new System.Drawing.Point(0, 342);
			groupBoxStop.Margin = new System.Windows.Forms.Padding(4);
			groupBoxStop.Name = "groupBoxStop";
			groupBoxStop.Padding = new System.Windows.Forms.Padding(4);
			groupBoxStop.Size = new System.Drawing.Size(484, 159);
			groupBoxStop.TabIndex = 20;
			groupBoxStop.TabStop = false;
			groupBoxStop.Text = "Stop";
			// 
			// tableLayoutPanelStop
			// 
			tableLayoutPanelStop.AutoSize = true;
			tableLayoutPanelStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			tableLayoutPanelStop.ColumnCount = 5;
			tableLayoutPanelStop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanelStop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			tableLayoutPanelStop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			tableLayoutPanelStop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			tableLayoutPanelStop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			tableLayoutPanelStop.Controls.Add(dateTimePickerTime, 3, 2);
			tableLayoutPanelStop.Controls.Add(radioButtonElapsedTime, 0, 1);
			tableLayoutPanelStop.Controls.Add(radioButtonDateTime, 0, 2);
			tableLayoutPanelStop.Controls.Add(dateTimePickerDate, 1, 2);
			tableLayoutPanelStop.Controls.Add(radioButtonNumScans, 0, 3);
			tableLayoutPanelStop.Controls.Add(radioButtonStop, 0, 4);
			tableLayoutPanelStop.Controls.Add(numericUpDownHours, 1, 1);
			tableLayoutPanelStop.Controls.Add(numericUpDownMinutes, 2, 1);
			tableLayoutPanelStop.Controls.Add(numericUpDownSeconds, 3, 1);
			tableLayoutPanelStop.Controls.Add(label1, 1, 0);
			tableLayoutPanelStop.Controls.Add(label3, 2, 0);
			tableLayoutPanelStop.Controls.Add(label4, 3, 0);
			tableLayoutPanelStop.Controls.Add(numericUpDownNumScans, 1, 3);
			tableLayoutPanelStop.Dock = System.Windows.Forms.DockStyle.Top;
			tableLayoutPanelStop.Location = new System.Drawing.Point(4, 20);
			tableLayoutPanelStop.Margin = new System.Windows.Forms.Padding(4);
			tableLayoutPanelStop.Name = "tableLayoutPanelStop";
			tableLayoutPanelStop.RowCount = 5;
			tableLayoutPanelStop.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanelStop.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanelStop.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanelStop.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanelStop.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanelStop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
			tableLayoutPanelStop.Size = new System.Drawing.Size(476, 135);
			tableLayoutPanelStop.TabIndex = 14;
			// 
			// radioButtonElapsedTime
			// 
			radioButtonElapsedTime.AutoSize = true;
			radioButtonElapsedTime.Location = new System.Drawing.Point(4, 19);
			radioButtonElapsedTime.Margin = new System.Windows.Forms.Padding(4);
			radioButtonElapsedTime.Name = "radioButtonElapsedTime";
			radioButtonElapsedTime.Size = new System.Drawing.Size(94, 19);
			radioButtonElapsedTime.TabIndex = 19;
			radioButtonElapsedTime.Text = "Elapsed Time";
			radioButtonElapsedTime.UseVisualStyleBackColor = true;
			radioButtonElapsedTime.CheckedChanged += RadioButtonStop_CheckedChanged;
			// 
			// radioButtonDateTime
			// 
			radioButtonDateTime.AutoSize = true;
			radioButtonDateTime.Location = new System.Drawing.Point(4, 50);
			radioButtonDateTime.Margin = new System.Windows.Forms.Padding(4);
			radioButtonDateTime.Name = "radioButtonDateTime";
			radioButtonDateTime.Size = new System.Drawing.Size(80, 19);
			radioButtonDateTime.TabIndex = 20;
			radioButtonDateTime.Text = "Date/Time";
			radioButtonDateTime.UseVisualStyleBackColor = true;
			radioButtonDateTime.CheckedChanged += RadioButtonStop_CheckedChanged;
			// 
			// dateTimePickerDate
			// 
			dateTimePickerDate.Checked = false;
			tableLayoutPanelStop.SetColumnSpan(dateTimePickerDate, 2);
			dateTimePickerDate.CustomFormat = "M/dd/yyyy hh:mm:ss";
			dateTimePickerDate.Enabled = false;
			dateTimePickerDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			dateTimePickerDate.Location = new System.Drawing.Point(106, 50);
			dateTimePickerDate.Margin = new System.Windows.Forms.Padding(4);
			dateTimePickerDate.MinDate = new System.DateTime(2021, 5, 28, 16, 58, 24, 0);
			dateTimePickerDate.Name = "dateTimePickerDate";
			dateTimePickerDate.Size = new System.Drawing.Size(140, 23);
			dateTimePickerDate.TabIndex = 27;
			dateTimePickerDate.Value = new System.DateTime(2022, 5, 28, 16, 58, 1, 0);
			// 
			// radioButtonNumScans
			// 
			radioButtonNumScans.AutoSize = true;
			radioButtonNumScans.Location = new System.Drawing.Point(4, 81);
			radioButtonNumScans.Margin = new System.Windows.Forms.Padding(4);
			radioButtonNumScans.Name = "radioButtonNumScans";
			radioButtonNumScans.Size = new System.Drawing.Size(93, 19);
			radioButtonNumScans.TabIndex = 18;
			radioButtonNumScans.Text = "# of Samples";
			radioButtonNumScans.UseVisualStyleBackColor = true;
			radioButtonNumScans.CheckedChanged += RadioButtonStop_CheckedChanged;
			// 
			// radioButtonStop
			// 
			radioButtonStop.AutoSize = true;
			radioButtonStop.Checked = true;
			radioButtonStop.Location = new System.Drawing.Point(4, 112);
			radioButtonStop.Margin = new System.Windows.Forms.Padding(4);
			radioButtonStop.Name = "radioButtonStop";
			radioButtonStop.Size = new System.Drawing.Size(88, 19);
			radioButtonStop.TabIndex = 17;
			radioButtonStop.TabStop = true;
			radioButtonStop.Text = "Stop Button";
			radioButtonStop.UseVisualStyleBackColor = true;
			radioButtonStop.CheckedChanged += RadioButtonStop_CheckedChanged;
			// 
			// numericUpDownHours
			// 
			numericUpDownHours.Enabled = false;
			numericUpDownHours.Location = new System.Drawing.Point(106, 19);
			numericUpDownHours.Margin = new System.Windows.Forms.Padding(4);
			numericUpDownHours.Maximum = new decimal(new int[] { 36000000, 0, 0, 0 });
			numericUpDownHours.Name = "numericUpDownHours";
			numericUpDownHours.Size = new System.Drawing.Size(60, 23);
			numericUpDownHours.TabIndex = 22;
			numericUpDownHours.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// numericUpDownMinutes
			// 
			numericUpDownMinutes.Enabled = false;
			numericUpDownMinutes.Location = new System.Drawing.Point(199, 19);
			numericUpDownMinutes.Margin = new System.Windows.Forms.Padding(4);
			numericUpDownMinutes.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
			numericUpDownMinutes.Name = "numericUpDownMinutes";
			numericUpDownMinutes.Size = new System.Drawing.Size(60, 23);
			numericUpDownMinutes.TabIndex = 23;
			numericUpDownMinutes.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// numericUpDownSeconds
			// 
			numericUpDownSeconds.Enabled = false;
			numericUpDownSeconds.Location = new System.Drawing.Point(292, 19);
			numericUpDownSeconds.Margin = new System.Windows.Forms.Padding(4);
			numericUpDownSeconds.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
			numericUpDownSeconds.Name = "numericUpDownSeconds";
			numericUpDownSeconds.Size = new System.Drawing.Size(60, 23);
			numericUpDownSeconds.TabIndex = 24;
			numericUpDownSeconds.Value = new decimal(new int[] { 59, 0, 0, 0 });
			// 
			// label1
			// 
			label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(106, 0);
			label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(39, 15);
			label1.TabIndex = 16;
			label1.Text = "Hours";
			// 
			// label3
			// 
			label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(199, 0);
			label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(50, 15);
			label3.TabIndex = 29;
			label3.Text = "Minutes";
			// 
			// label4
			// 
			label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(292, 0);
			label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(51, 15);
			label4.TabIndex = 30;
			label4.Text = "Seconds";
			// 
			// numericUpDownNumScans
			// 
			tableLayoutPanelStop.SetColumnSpan(numericUpDownNumScans, 3);
			numericUpDownNumScans.Enabled = false;
			numericUpDownNumScans.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
			numericUpDownNumScans.Location = new System.Drawing.Point(106, 81);
			numericUpDownNumScans.Margin = new System.Windows.Forms.Padding(4);
			numericUpDownNumScans.Maximum = new decimal(new int[] { 36000000, 0, 0, 0 });
			numericUpDownNumScans.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			numericUpDownNumScans.Name = "numericUpDownNumScans";
			numericUpDownNumScans.Size = new System.Drawing.Size(105, 23);
			numericUpDownNumScans.TabIndex = 21;
			numericUpDownNumScans.Value = new decimal(new int[] { 1000, 0, 0, 0 });
			// 
			// groupBoxResponse
			// 
			groupBoxResponse.AutoSize = true;
			groupBoxResponse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			groupBoxResponse.Controls.Add(textBoxResponse);
			groupBoxResponse.Dock = System.Windows.Forms.DockStyle.Top;
			groupBoxResponse.Location = new System.Drawing.Point(0, 501);
			groupBoxResponse.Margin = new System.Windows.Forms.Padding(4);
			groupBoxResponse.Name = "groupBoxResponse";
			groupBoxResponse.Padding = new System.Windows.Forms.Padding(4);
			groupBoxResponse.Size = new System.Drawing.Size(484, 47);
			groupBoxResponse.TabIndex = 22;
			groupBoxResponse.TabStop = false;
			groupBoxResponse.Text = "Response";
			// 
			// textBoxResponse
			// 
			textBoxResponse.Dock = System.Windows.Forms.DockStyle.Top;
			textBoxResponse.Location = new System.Drawing.Point(4, 20);
			textBoxResponse.Margin = new System.Windows.Forms.Padding(4);
			textBoxResponse.Name = "textBoxResponse";
			textBoxResponse.ReadOnly = true;
			textBoxResponse.Size = new System.Drawing.Size(476, 23);
			textBoxResponse.TabIndex = 10;
			// 
			// FormLog
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(484, 651);
			Controls.Add(groupBoxResponse);
			Controls.Add(groupBoxStop);
			Controls.Add(groupBoxSample);
			Controls.Add(groupBoxStartStop);
			Controls.Add(groupBoxSerialPort);
			Controls.Add(groupBoxFilename);
			Controls.Add(statusStrip);
			Controls.Add(menuStrip);
			MainMenuStrip = menuStrip;
			Margin = new System.Windows.Forms.Padding(4);
			Name = "FormLog";
			Text = "Data logger";
			FormClosing += FormLog_FormClosing;
			menuStrip.ResumeLayout(false);
			menuStrip.PerformLayout();
			statusStrip.ResumeLayout(false);
			statusStrip.PerformLayout();
			groupBoxFilename.ResumeLayout(false);
			groupBoxFilename.PerformLayout();
			tableLayoutPanelFilename.ResumeLayout(false);
			tableLayoutPanelFilename.PerformLayout();
			groupBoxStartStop.ResumeLayout(false);
			groupBoxStartStop.PerformLayout();
			tableLayoutPanelStartStop.ResumeLayout(false);
			tableLayoutPanelStartStop.PerformLayout();
			tableLayoutPanelButtons.ResumeLayout(false);
			tableLayoutPanelSerialPort.ResumeLayout(false);
			tableLayoutPanelSerialPort.PerformLayout();
			groupBoxSerialPort.ResumeLayout(false);
			groupBoxSerialPort.PerformLayout();
			groupBoxSample.ResumeLayout(false);
			groupBoxSample.PerformLayout();
			tableLayoutPanelSample.ResumeLayout(false);
			tableLayoutPanelSample.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDownInterval).EndInit();
			groupBoxStop.ResumeLayout(false);
			groupBoxStop.PerformLayout();
			tableLayoutPanelStop.ResumeLayout(false);
			tableLayoutPanelStop.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDownHours).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDownMinutes).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDownSeconds).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDownNumScans).EndInit();
			groupBoxResponse.ResumeLayout(false);
			groupBoxResponse.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
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
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem wikiToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.RadioButton radioButtonStream;
		private System.Windows.Forms.NumericUpDown numericUpDownInterval;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.RadioButton radioButtonPolled;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxCommand;
		private System.Windows.Forms.Label labelCommand;
		private System.Windows.Forms.Label label7;
	}
}

