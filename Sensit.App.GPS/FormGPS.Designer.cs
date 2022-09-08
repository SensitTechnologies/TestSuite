﻿namespace Sensit.App.GPS
{
	partial class FormGPS
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGPS));
			this.labelUnitCh3Current = new System.Windows.Forms.Label();
			this.numericUpDownCh4Current = new System.Windows.Forms.NumericUpDown();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.supportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.tableLayoutPanelTestSetupButtons = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanelStartStop = new System.Windows.Forms.TableLayoutPanel();
			this.buttonStart = new System.Windows.Forms.Button();
			this.buttonStop = new System.Windows.Forms.Button();
			this.groupBoxSerialPort = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanelSerialPort = new System.Windows.Forms.TableLayoutPanel();
			this.comboBoxSerialPort = new System.Windows.Forms.ComboBox();
			this.buttonPortRefresh = new System.Windows.Forms.Button();
			this.groupBoxStatus = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanelStatus = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanelVariables = new System.Windows.Forms.TableLayoutPanel();
			this.textBoxStatusFixType = new System.Windows.Forms.TextBox();
			this.textBoxStatusLongitude = new System.Windows.Forms.TextBox();
			this.textBoxStatusLatitude = new System.Windows.Forms.TextBox();
			this.labelTimestamp = new System.Windows.Forms.Label();
			this.labelLatitude = new System.Windows.Forms.Label();
			this.textBoxTimestamp = new System.Windows.Forms.TextBox();
			this.textBoxLatitude = new System.Windows.Forms.TextBox();
			this.labelLongitude = new System.Windows.Forms.Label();
			this.textBoxLongitude = new System.Windows.Forms.TextBox();
			this.labelFixType = new System.Windows.Forms.Label();
			this.labelUnitTimestamp = new System.Windows.Forms.Label();
			this.labelUnitLatitude = new System.Windows.Forms.Label();
			this.labelUnitLongitude = new System.Windows.Forms.Label();
			this.labelSatellites = new System.Windows.Forms.Label();
			this.textBoxStatusTimestamp = new System.Windows.Forms.TextBox();
			this.textBoxFixType = new System.Windows.Forms.TextBox();
			this.textBoxSatellites = new System.Windows.Forms.TextBox();
			this.textBoxStatusSatellites = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh4Current)).BeginInit();
			this.menuStrip.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.tableLayoutPanelTestSetupButtons.SuspendLayout();
			this.tableLayoutPanelStartStop.SuspendLayout();
			this.groupBoxSerialPort.SuspendLayout();
			this.tableLayoutPanelSerialPort.SuspendLayout();
			this.groupBoxStatus.SuspendLayout();
			this.tableLayoutPanelStatus.SuspendLayout();
			this.tableLayoutPanelVariables.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelUnitCh3Current
			// 
			this.labelUnitCh3Current.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelUnitCh3Current.Location = new System.Drawing.Point(4, 52);
			this.labelUnitCh3Current.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelUnitCh3Current.Name = "labelUnitCh3Current";
			this.labelUnitCh3Current.Size = new System.Drawing.Size(41, 15);
			this.labelUnitCh3Current.TabIndex = 36;
			this.labelUnitCh3Current.Text = "A";
			// 
			// numericUpDownCh4Current
			// 
			this.numericUpDownCh4Current.DecimalPlaces = 2;
			this.numericUpDownCh4Current.Location = new System.Drawing.Point(4, 3);
			this.numericUpDownCh4Current.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.numericUpDownCh4Current.Name = "numericUpDownCh4Current";
			this.numericUpDownCh4Current.Size = new System.Drawing.Size(117, 27);
			this.numericUpDownCh4Current.TabIndex = 21;
			// 
			// menuStrip
			// 
			this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.testToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
			this.menuStrip.Size = new System.Drawing.Size(363, 30);
			this.menuStrip.TabIndex = 14;
			this.menuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 26);
			this.exitToolStripMenuItem.Text = "&Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
			// 
			// testToolStripMenuItem
			// 
			this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem});
			this.testToolStripMenuItem.Name = "testToolStripMenuItem";
			this.testToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
			this.testToolStripMenuItem.Text = "&Test";
			// 
			// startToolStripMenuItem
			// 
			this.startToolStripMenuItem.Name = "startToolStripMenuItem";
			this.startToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.startToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
			this.startToolStripMenuItem.Text = "&Start";
			this.startToolStripMenuItem.Click += new System.EventHandler(this.ButtonStart_Click);
			// 
			// stopToolStripMenuItem
			// 
			this.stopToolStripMenuItem.Enabled = false;
			this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
			this.stopToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
			this.stopToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
			this.stopToolStripMenuItem.Text = "&Stop";
			this.stopToolStripMenuItem.Click += new System.EventHandler(this.ButtonStop_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supportToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// supportToolStripMenuItem
			// 
			this.supportToolStripMenuItem.Name = "supportToolStripMenuItem";
			this.supportToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
			this.supportToolStripMenuItem.Text = "&Wiki";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
			this.aboutToolStripMenuItem.Text = "&About";
			// 
			// statusStrip
			// 
			this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabel});
			this.statusStrip.Location = new System.Drawing.Point(0, 412);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 18, 0);
			this.statusStrip.Size = new System.Drawing.Size(363, 40);
			this.statusStrip.TabIndex = 15;
			this.statusStrip.Text = "statusStrip1";
			// 
			// toolStripProgressBar
			// 
			this.toolStripProgressBar.Name = "toolStripProgressBar";
			this.toolStripProgressBar.Size = new System.Drawing.Size(134, 32);
			// 
			// toolStripStatusLabel
			// 
			this.toolStripStatusLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.toolStripStatusLabel.Name = "toolStripStatusLabel";
			this.toolStripStatusLabel.Size = new System.Drawing.Size(77, 34);
			this.toolStripStatusLabel.Text = "Ready...";
			// 
			// tableLayoutPanelTestSetupButtons
			// 
			this.tableLayoutPanelTestSetupButtons.AutoSize = true;
			this.tableLayoutPanelTestSetupButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelTestSetupButtons.ColumnCount = 1;
			this.tableLayoutPanelTestSetupButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelTestSetupButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
			this.tableLayoutPanelTestSetupButtons.Controls.Add(this.tableLayoutPanelStartStop, 0, 0);
			this.tableLayoutPanelTestSetupButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tableLayoutPanelTestSetupButtons.Location = new System.Drawing.Point(0, 360);
			this.tableLayoutPanelTestSetupButtons.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.tableLayoutPanelTestSetupButtons.Name = "tableLayoutPanelTestSetupButtons";
			this.tableLayoutPanelTestSetupButtons.RowCount = 1;
			this.tableLayoutPanelTestSetupButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelTestSetupButtons.Size = new System.Drawing.Size(363, 52);
			this.tableLayoutPanelTestSetupButtons.TabIndex = 16;
			// 
			// tableLayoutPanelStartStop
			// 
			this.tableLayoutPanelStartStop.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.tableLayoutPanelStartStop.AutoSize = true;
			this.tableLayoutPanelStartStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelStartStop.ColumnCount = 2;
			this.tableLayoutPanelStartStop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelStartStop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelStartStop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
			this.tableLayoutPanelStartStop.Controls.Add(this.buttonStart, 0, 0);
			this.tableLayoutPanelStartStop.Controls.Add(this.buttonStop, 1, 0);
			this.tableLayoutPanelStartStop.Location = new System.Drawing.Point(70, 4);
			this.tableLayoutPanelStartStop.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.tableLayoutPanelStartStop.Name = "tableLayoutPanelStartStop";
			this.tableLayoutPanelStartStop.RowCount = 1;
			this.tableLayoutPanelStartStop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelStartStop.Size = new System.Drawing.Size(222, 44);
			this.tableLayoutPanelStartStop.TabIndex = 17;
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(5, 4);
			this.buttonStart.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(101, 36);
			this.buttonStart.TabIndex = 3;
			this.buttonStart.Text = "Start";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
			// 
			// buttonStop
			// 
			this.buttonStop.Enabled = false;
			this.buttonStop.Location = new System.Drawing.Point(116, 4);
			this.buttonStop.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(101, 36);
			this.buttonStop.TabIndex = 4;
			this.buttonStop.Text = "Stop";
			this.buttonStop.UseVisualStyleBackColor = true;
			this.buttonStop.Click += new System.EventHandler(this.ButtonStop_Click);
			// 
			// groupBoxSerialPort
			// 
			this.groupBoxSerialPort.AutoSize = true;
			this.groupBoxSerialPort.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxSerialPort.Controls.Add(this.tableLayoutPanelSerialPort);
			this.groupBoxSerialPort.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBoxSerialPort.Location = new System.Drawing.Point(0, 30);
			this.groupBoxSerialPort.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.groupBoxSerialPort.Name = "groupBoxSerialPort";
			this.groupBoxSerialPort.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.groupBoxSerialPort.Size = new System.Drawing.Size(363, 72);
			this.groupBoxSerialPort.TabIndex = 17;
			this.groupBoxSerialPort.TabStop = false;
			this.groupBoxSerialPort.Text = "Serial Port";
			// 
			// tableLayoutPanelSerialPort
			// 
			this.tableLayoutPanelSerialPort.AutoSize = true;
			this.tableLayoutPanelSerialPort.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelSerialPort.ColumnCount = 2;
			this.tableLayoutPanelSerialPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelSerialPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelSerialPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
			this.tableLayoutPanelSerialPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
			this.tableLayoutPanelSerialPort.Controls.Add(this.comboBoxSerialPort, 0, 0);
			this.tableLayoutPanelSerialPort.Controls.Add(this.buttonPortRefresh, 1, 0);
			this.tableLayoutPanelSerialPort.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelSerialPort.Location = new System.Drawing.Point(5, 24);
			this.tableLayoutPanelSerialPort.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.tableLayoutPanelSerialPort.Name = "tableLayoutPanelSerialPort";
			this.tableLayoutPanelSerialPort.RowCount = 1;
			this.tableLayoutPanelSerialPort.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSerialPort.Size = new System.Drawing.Size(353, 44);
			this.tableLayoutPanelSerialPort.TabIndex = 14;
			// 
			// comboBoxSerialPort
			// 
			this.comboBoxSerialPort.AllowDrop = true;
			this.comboBoxSerialPort.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboBoxSerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSerialPort.FormattingEnabled = true;
			this.comboBoxSerialPort.Location = new System.Drawing.Point(5, 4);
			this.comboBoxSerialPort.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.comboBoxSerialPort.Name = "comboBoxSerialPort";
			this.comboBoxSerialPort.Size = new System.Drawing.Size(295, 28);
			this.comboBoxSerialPort.TabIndex = 1;
			this.comboBoxSerialPort.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSerialPort_SelectedIndexChanged);
			// 
			// buttonPortRefresh
			// 
			this.buttonPortRefresh.Image = ((System.Drawing.Image)(resources.GetObject("buttonPortRefresh.Image")));
			this.buttonPortRefresh.Location = new System.Drawing.Point(310, 4);
			this.buttonPortRefresh.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.buttonPortRefresh.Name = "buttonPortRefresh";
			this.buttonPortRefresh.Size = new System.Drawing.Size(38, 36);
			this.buttonPortRefresh.TabIndex = 2;
			this.buttonPortRefresh.UseVisualStyleBackColor = true;
			this.buttonPortRefresh.Click += new System.EventHandler(this.ButtonPortRefresh_Click);
			// 
			// groupBoxStatus
			// 
			this.groupBoxStatus.AutoSize = true;
			this.groupBoxStatus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxStatus.Controls.Add(this.tableLayoutPanelStatus);
			this.groupBoxStatus.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxStatus.Location = new System.Drawing.Point(0, 102);
			this.groupBoxStatus.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.groupBoxStatus.Name = "groupBoxStatus";
			this.groupBoxStatus.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.groupBoxStatus.Size = new System.Drawing.Size(363, 258);
			this.groupBoxStatus.TabIndex = 18;
			this.groupBoxStatus.TabStop = false;
			this.groupBoxStatus.Text = "Status";
			// 
			// tableLayoutPanelStatus
			// 
			this.tableLayoutPanelStatus.ColumnCount = 1;
			this.tableLayoutPanelStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelStatus.Controls.Add(this.tableLayoutPanelVariables, 0, 0);
			this.tableLayoutPanelStatus.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelStatus.Location = new System.Drawing.Point(5, 24);
			this.tableLayoutPanelStatus.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.tableLayoutPanelStatus.Name = "tableLayoutPanelStatus";
			this.tableLayoutPanelStatus.RowCount = 1;
			this.tableLayoutPanelStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 223F));
			this.tableLayoutPanelStatus.Size = new System.Drawing.Size(353, 230);
			this.tableLayoutPanelStatus.TabIndex = 0;
			// 
			// tableLayoutPanelVariables
			// 
			this.tableLayoutPanelVariables.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.tableLayoutPanelVariables.AutoSize = true;
			this.tableLayoutPanelVariables.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelVariables.ColumnCount = 4;
			this.tableLayoutPanelVariables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelVariables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelVariables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelVariables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelVariables.Controls.Add(this.textBoxStatusFixType, 3, 3);
			this.tableLayoutPanelVariables.Controls.Add(this.textBoxStatusLongitude, 3, 2);
			this.tableLayoutPanelVariables.Controls.Add(this.textBoxStatusLatitude, 3, 1);
			this.tableLayoutPanelVariables.Controls.Add(this.labelTimestamp, 0, 0);
			this.tableLayoutPanelVariables.Controls.Add(this.labelLatitude, 0, 1);
			this.tableLayoutPanelVariables.Controls.Add(this.textBoxTimestamp, 1, 0);
			this.tableLayoutPanelVariables.Controls.Add(this.textBoxLatitude, 1, 1);
			this.tableLayoutPanelVariables.Controls.Add(this.labelLongitude, 0, 2);
			this.tableLayoutPanelVariables.Controls.Add(this.textBoxLongitude, 1, 2);
			this.tableLayoutPanelVariables.Controls.Add(this.labelFixType, 0, 3);
			this.tableLayoutPanelVariables.Controls.Add(this.labelUnitTimestamp, 2, 0);
			this.tableLayoutPanelVariables.Controls.Add(this.labelUnitLatitude, 2, 1);
			this.tableLayoutPanelVariables.Controls.Add(this.labelUnitLongitude, 2, 2);
			this.tableLayoutPanelVariables.Controls.Add(this.labelSatellites, 0, 4);
			this.tableLayoutPanelVariables.Controls.Add(this.textBoxStatusTimestamp, 3, 0);
			this.tableLayoutPanelVariables.Controls.Add(this.textBoxFixType, 1, 3);
			this.tableLayoutPanelVariables.Controls.Add(this.textBoxSatellites, 1, 4);
			this.tableLayoutPanelVariables.Controls.Add(this.textBoxStatusSatellites, 3, 4);
			this.tableLayoutPanelVariables.Location = new System.Drawing.Point(7, 27);
			this.tableLayoutPanelVariables.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.tableLayoutPanelVariables.Name = "tableLayoutPanelVariables";
			this.tableLayoutPanelVariables.RowCount = 5;
			this.tableLayoutPanelVariables.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelVariables.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelVariables.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelVariables.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelVariables.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelVariables.Size = new System.Drawing.Size(339, 175);
			this.tableLayoutPanelVariables.TabIndex = 2;
			// 
			// textBoxStatusFixType
			// 
			this.textBoxStatusFixType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.textBoxStatusFixType.Location = new System.Drawing.Point(295, 109);
			this.textBoxStatusFixType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBoxStatusFixType.Name = "textBoxStatusFixType";
			this.textBoxStatusFixType.ReadOnly = true;
			this.textBoxStatusFixType.Size = new System.Drawing.Size(41, 27);
			this.textBoxStatusFixType.TabIndex = 20;
			this.textBoxStatusFixType.TabStop = false;
			this.textBoxStatusFixType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBoxStatusLongitude
			// 
			this.textBoxStatusLongitude.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.textBoxStatusLongitude.Location = new System.Drawing.Point(295, 74);
			this.textBoxStatusLongitude.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBoxStatusLongitude.Name = "textBoxStatusLongitude";
			this.textBoxStatusLongitude.ReadOnly = true;
			this.textBoxStatusLongitude.Size = new System.Drawing.Size(41, 27);
			this.textBoxStatusLongitude.TabIndex = 19;
			this.textBoxStatusLongitude.TabStop = false;
			this.textBoxStatusLongitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBoxStatusLatitude
			// 
			this.textBoxStatusLatitude.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.textBoxStatusLatitude.Location = new System.Drawing.Point(295, 39);
			this.textBoxStatusLatitude.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBoxStatusLatitude.Name = "textBoxStatusLatitude";
			this.textBoxStatusLatitude.ReadOnly = true;
			this.textBoxStatusLatitude.Size = new System.Drawing.Size(41, 27);
			this.textBoxStatusLatitude.TabIndex = 18;
			this.textBoxStatusLatitude.TabStop = false;
			this.textBoxStatusLatitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// labelTimestamp
			// 
			this.labelTimestamp.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelTimestamp.AutoSize = true;
			this.labelTimestamp.Location = new System.Drawing.Point(5, 7);
			this.labelTimestamp.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.labelTimestamp.Name = "labelTimestamp";
			this.labelTimestamp.Size = new System.Drawing.Size(83, 20);
			this.labelTimestamp.TabIndex = 0;
			this.labelTimestamp.Text = "Timestamp";
			// 
			// labelLatitude
			// 
			this.labelLatitude.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelLatitude.AutoSize = true;
			this.labelLatitude.Location = new System.Drawing.Point(5, 42);
			this.labelLatitude.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.labelLatitude.Name = "labelLatitude";
			this.labelLatitude.Size = new System.Drawing.Size(63, 20);
			this.labelLatitude.TabIndex = 1;
			this.labelLatitude.Text = "Latitude";
			// 
			// textBoxTimestamp
			// 
			this.textBoxTimestamp.Location = new System.Drawing.Point(98, 4);
			this.textBoxTimestamp.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.textBoxTimestamp.Name = "textBoxTimestamp";
			this.textBoxTimestamp.ReadOnly = true;
			this.textBoxTimestamp.Size = new System.Drawing.Size(132, 27);
			this.textBoxTimestamp.TabIndex = 2;
			this.textBoxTimestamp.TabStop = false;
			// 
			// textBoxLatitude
			// 
			this.textBoxLatitude.Location = new System.Drawing.Point(98, 39);
			this.textBoxLatitude.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.textBoxLatitude.Name = "textBoxLatitude";
			this.textBoxLatitude.ReadOnly = true;
			this.textBoxLatitude.Size = new System.Drawing.Size(132, 27);
			this.textBoxLatitude.TabIndex = 3;
			this.textBoxLatitude.TabStop = false;
			// 
			// labelLongitude
			// 
			this.labelLongitude.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelLongitude.AutoSize = true;
			this.labelLongitude.Location = new System.Drawing.Point(5, 77);
			this.labelLongitude.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.labelLongitude.Name = "labelLongitude";
			this.labelLongitude.Size = new System.Drawing.Size(76, 20);
			this.labelLongitude.TabIndex = 4;
			this.labelLongitude.Text = "Longitude";
			// 
			// textBoxLongitude
			// 
			this.textBoxLongitude.Location = new System.Drawing.Point(98, 74);
			this.textBoxLongitude.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.textBoxLongitude.Name = "textBoxLongitude";
			this.textBoxLongitude.ReadOnly = true;
			this.textBoxLongitude.Size = new System.Drawing.Size(132, 27);
			this.textBoxLongitude.TabIndex = 5;
			this.textBoxLongitude.TabStop = false;
			// 
			// labelFixType
			// 
			this.labelFixType.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelFixType.AutoSize = true;
			this.labelFixType.Location = new System.Drawing.Point(5, 112);
			this.labelFixType.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.labelFixType.Name = "labelFixType";
			this.labelFixType.Size = new System.Drawing.Size(62, 20);
			this.labelFixType.TabIndex = 6;
			this.labelFixType.Text = "Fix Type";
			// 
			// labelUnitTimestamp
			// 
			this.labelUnitTimestamp.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelUnitTimestamp.Location = new System.Drawing.Point(240, 7);
			this.labelUnitTimestamp.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.labelUnitTimestamp.Name = "labelUnitTimestamp";
			this.labelUnitTimestamp.Size = new System.Drawing.Size(47, 20);
			this.labelUnitTimestamp.TabIndex = 0;
			this.labelUnitTimestamp.Text = "UTC Time";
			// 
			// labelUnitLatitude
			// 
			this.labelUnitLatitude.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelUnitLatitude.AutoSize = true;
			this.labelUnitLatitude.Location = new System.Drawing.Point(240, 42);
			this.labelUnitLatitude.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.labelUnitLatitude.Name = "labelUnitLatitude";
			this.labelUnitLatitude.Size = new System.Drawing.Size(40, 20);
			this.labelUnitLatitude.TabIndex = 11;
			this.labelUnitLatitude.Text = "°N/S";
			// 
			// labelUnitLongitude
			// 
			this.labelUnitLongitude.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelUnitLongitude.AutoSize = true;
			this.labelUnitLongitude.Location = new System.Drawing.Point(240, 77);
			this.labelUnitLongitude.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.labelUnitLongitude.Name = "labelUnitLongitude";
			this.labelUnitLongitude.Size = new System.Drawing.Size(43, 20);
			this.labelUnitLongitude.TabIndex = 12;
			this.labelUnitLongitude.Text = "°E/W";
			// 
			// labelSatellites
			// 
			this.labelSatellites.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelSatellites.AutoSize = true;
			this.labelSatellites.Location = new System.Drawing.Point(5, 147);
			this.labelSatellites.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.labelSatellites.Name = "labelSatellites";
			this.labelSatellites.Size = new System.Drawing.Size(69, 20);
			this.labelSatellites.TabIndex = 15;
			this.labelSatellites.Text = "Satellites";
			// 
			// textBoxStatusTimestamp
			// 
			this.textBoxStatusTimestamp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.textBoxStatusTimestamp.Location = new System.Drawing.Point(295, 4);
			this.textBoxStatusTimestamp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBoxStatusTimestamp.Name = "textBoxStatusTimestamp";
			this.textBoxStatusTimestamp.ReadOnly = true;
			this.textBoxStatusTimestamp.Size = new System.Drawing.Size(41, 27);
			this.textBoxStatusTimestamp.TabIndex = 17;
			this.textBoxStatusTimestamp.TabStop = false;
			this.textBoxStatusTimestamp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBoxFixType
			// 
			this.textBoxFixType.Location = new System.Drawing.Point(98, 109);
			this.textBoxFixType.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.textBoxFixType.Name = "textBoxFixType";
			this.textBoxFixType.ReadOnly = true;
			this.textBoxFixType.Size = new System.Drawing.Size(132, 27);
			this.textBoxFixType.TabIndex = 7;
			this.textBoxFixType.TabStop = false;
			// 
			// textBoxSatellites
			// 
			this.textBoxSatellites.Location = new System.Drawing.Point(98, 144);
			this.textBoxSatellites.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.textBoxSatellites.Name = "textBoxSatellites";
			this.textBoxSatellites.ReadOnly = true;
			this.textBoxSatellites.Size = new System.Drawing.Size(132, 27);
			this.textBoxSatellites.TabIndex = 22;
			this.textBoxSatellites.TabStop = false;
			// 
			// textBoxStatusSatellites
			// 
			this.textBoxStatusSatellites.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.textBoxStatusSatellites.Location = new System.Drawing.Point(295, 144);
			this.textBoxStatusSatellites.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBoxStatusSatellites.Name = "textBoxStatusSatellites";
			this.textBoxStatusSatellites.ReadOnly = true;
			this.textBoxStatusSatellites.Size = new System.Drawing.Size(41, 27);
			this.textBoxStatusSatellites.TabIndex = 23;
			this.textBoxStatusSatellites.TabStop = false;
			this.textBoxStatusSatellites.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// FormGPS
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(363, 452);
			this.Controls.Add(this.groupBoxStatus);
			this.Controls.Add(this.groupBoxSerialPort);
			this.Controls.Add(this.tableLayoutPanelTestSetupButtons);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.menuStrip);
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FormGPS";
			this.Text = "GPS Tester";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormGPS_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh4Current)).EndInit();
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.tableLayoutPanelTestSetupButtons.ResumeLayout(false);
			this.tableLayoutPanelTestSetupButtons.PerformLayout();
			this.tableLayoutPanelStartStop.ResumeLayout(false);
			this.groupBoxSerialPort.ResumeLayout(false);
			this.groupBoxSerialPort.PerformLayout();
			this.tableLayoutPanelSerialPort.ResumeLayout(false);
			this.groupBoxStatus.ResumeLayout(false);
			this.tableLayoutPanelStatus.ResumeLayout(false);
			this.tableLayoutPanelStatus.PerformLayout();
			this.tableLayoutPanelVariables.ResumeLayout(false);
			this.tableLayoutPanelVariables.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private Label labelUnitCh3Current;
		private NumericUpDown numericUpDownCh4Current;
		private MenuStrip menuStrip;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem exitToolStripMenuItem;
		private ToolStripMenuItem testToolStripMenuItem;
		private ToolStripMenuItem startToolStripMenuItem;
		private ToolStripMenuItem stopToolStripMenuItem;
		private ToolStripMenuItem helpToolStripMenuItem;
		private ToolStripMenuItem supportToolStripMenuItem;
		private ToolStripMenuItem aboutToolStripMenuItem;
		private StatusStrip statusStrip;
		private ToolStripProgressBar toolStripProgressBar;
		private ToolStripStatusLabel toolStripStatusLabel;
		private TableLayoutPanel tableLayoutPanelTestSetupButtons;
		private TableLayoutPanel tableLayoutPanelStartStop;
		private Button buttonStart;
		private Button buttonStop;
		private GroupBox groupBoxSerialPort;
		private TableLayoutPanel tableLayoutPanelSerialPort;
		private ComboBox comboBoxSerialPort;
		private Button buttonPortRefresh;
		private GroupBox groupBoxStatus;
		private TableLayoutPanel tableLayoutPanelStatus;
		private TableLayoutPanel tableLayoutPanelVariables;
		private TextBox textBoxStatusFixType;
		private Label labelTimestamp;
		private Label labelLatitude;
		private TextBox textBoxTimestamp;
		private TextBox textBoxLatitude;
		private Label labelLongitude;
		private TextBox textBoxLongitude;
		private Label labelFixType;
		private Label labelUnitTimestamp;
		private Label labelUnitLatitude;
		private Label labelUnitLongitude;
		private Label labelSatellites;
		private TextBox textBoxFixType;
		private TextBox textBoxSatellites;
		private TextBox textBoxStatusLongitude;
		private TextBox textBoxStatusLatitude;
		private TextBox textBoxStatusTimestamp;
		private TextBox textBoxStatusSatellites;
	}
}