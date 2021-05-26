namespace Sensit.App.PowerSupply
{
	partial class FormPowerSupply
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.groupBoxSerialPort = new System.Windows.Forms.GroupBox();
			this.radioButtonClosed = new System.Windows.Forms.RadioButton();
			this.radioButtonOpen = new System.Windows.Forms.RadioButton();
			this.comboBoxSerialPort = new System.Windows.Forms.ComboBox();
			this.groupBoxPowerSupply = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.labelCh1Voltage = new System.Windows.Forms.Label();
			this.labelCh1Current = new System.Windows.Forms.Label();
			this.labelUnitCh4Voltage = new System.Windows.Forms.Label();
			this.labelUnitCh4Current = new System.Windows.Forms.Label();
			this.buttonWrite = new System.Windows.Forms.Button();
			this.buttonRead = new System.Windows.Forms.Button();
			this.numericUpDownCh4Current = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownCh4Voltage = new System.Windows.Forms.NumericUpDown();
			this.groupBoxOutput = new System.Windows.Forms.GroupBox();
			this.radioButtonDisabled = new System.Windows.Forms.RadioButton();
			this.radioButtonEnabled = new System.Windows.Forms.RadioButton();
			this.labelChannel4 = new System.Windows.Forms.Label();
			this.labelChannel2 = new System.Windows.Forms.Label();
			this.labelCh2Current = new System.Windows.Forms.Label();
			this.labelCh2Voltage = new System.Windows.Forms.Label();
			this.numericUpDownCh2Current = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownCh2Voltage = new System.Windows.Forms.NumericUpDown();
			this.labelUnitCh2Current = new System.Windows.Forms.Label();
			this.labelUnitCh2Voltage = new System.Windows.Forms.Label();
			this.labelChannel3 = new System.Windows.Forms.Label();
			this.labelChannel1 = new System.Windows.Forms.Label();
			this.labelCh3Current = new System.Windows.Forms.Label();
			this.numericUpDownCh3Current = new System.Windows.Forms.NumericUpDown();
			this.labelUnitCh3Current = new System.Windows.Forms.Label();
			this.labelCh3Voltage = new System.Windows.Forms.Label();
			this.numericUpDownCh3Voltage = new System.Windows.Forms.NumericUpDown();
			this.labelUnitCh3Voltage = new System.Windows.Forms.Label();
			this.label1UnitCh1Voltage = new System.Windows.Forms.Label();
			this.label1UnitCh1Current = new System.Windows.Forms.Label();
			this.numericUpDownCh1Current = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownCh1Voltage = new System.Windows.Forms.NumericUpDown();
			this.label1Ch1Current = new System.Windows.Forms.Label();
			this.label1Ch1Voltage = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.groupBoxSerialPort.SuspendLayout();
			this.groupBoxPowerSupply.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh4Current)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh4Voltage)).BeginInit();
			this.groupBoxOutput.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh2Current)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh2Voltage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh3Current)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh3Voltage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh1Current)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh1Voltage)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(408, 24);
			this.menuStrip1.TabIndex = 2;
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
			this.statusStrip1.Location = new System.Drawing.Point(0, 329);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(408, 22);
			this.statusStrip1.TabIndex = 3;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
			this.toolStripStatusLabel1.Text = "Ready";
			// 
			// groupBoxSerialPort
			// 
			this.groupBoxSerialPort.AutoSize = true;
			this.groupBoxSerialPort.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxSerialPort.Controls.Add(this.radioButtonClosed);
			this.groupBoxSerialPort.Controls.Add(this.radioButtonOpen);
			this.groupBoxSerialPort.Controls.Add(this.comboBoxSerialPort);
			this.groupBoxSerialPort.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBoxSerialPort.Location = new System.Drawing.Point(0, 24);
			this.groupBoxSerialPort.Name = "groupBoxSerialPort";
			this.groupBoxSerialPort.Size = new System.Drawing.Size(408, 60);
			this.groupBoxSerialPort.TabIndex = 4;
			this.groupBoxSerialPort.TabStop = false;
			this.groupBoxSerialPort.Text = "Serial Port";
			// 
			// radioButtonClosed
			// 
			this.radioButtonClosed.AutoSize = true;
			this.radioButtonClosed.Checked = true;
			this.radioButtonClosed.Location = new System.Drawing.Point(199, 23);
			this.radioButtonClosed.Name = "radioButtonClosed";
			this.radioButtonClosed.Size = new System.Drawing.Size(57, 17);
			this.radioButtonClosed.TabIndex = 2;
			this.radioButtonClosed.TabStop = true;
			this.radioButtonClosed.Text = "Closed";
			this.radioButtonClosed.UseVisualStyleBackColor = true;
			this.radioButtonClosed.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
			// 
			// radioButtonOpen
			// 
			this.radioButtonOpen.AutoSize = true;
			this.radioButtonOpen.Location = new System.Drawing.Point(141, 23);
			this.radioButtonOpen.Name = "radioButtonOpen";
			this.radioButtonOpen.Size = new System.Drawing.Size(51, 17);
			this.radioButtonOpen.TabIndex = 1;
			this.radioButtonOpen.Text = "Open";
			this.radioButtonOpen.UseVisualStyleBackColor = true;
			this.radioButtonOpen.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
			// 
			// comboBoxSerialPort
			// 
			this.comboBoxSerialPort.FormattingEnabled = true;
			this.comboBoxSerialPort.Location = new System.Drawing.Point(13, 20);
			this.comboBoxSerialPort.Name = "comboBoxSerialPort";
			this.comboBoxSerialPort.Size = new System.Drawing.Size(121, 21);
			this.comboBoxSerialPort.TabIndex = 0;
			this.comboBoxSerialPort.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSerialPort_SelectedIndexChanged);
			// 
			// groupBoxPowerSupply
			// 
			this.groupBoxPowerSupply.AutoSize = true;
			this.groupBoxPowerSupply.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxPowerSupply.Controls.Add(this.tableLayoutPanel1);
			this.groupBoxPowerSupply.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBoxPowerSupply.Enabled = false;
			this.groupBoxPowerSupply.Location = new System.Drawing.Point(0, 144);
			this.groupBoxPowerSupply.Name = "groupBoxPowerSupply";
			this.groupBoxPowerSupply.Size = new System.Drawing.Size(408, 168);
			this.groupBoxPowerSupply.TabIndex = 5;
			this.groupBoxPowerSupply.TabStop = false;
			this.groupBoxPowerSupply.Text = "Power Supply";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 6;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Controls.Add(this.labelUnitCh3Current, 5, 1);
			this.tableLayoutPanel1.Controls.Add(this.numericUpDownCh4Current, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.numericUpDownCh4Voltage, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelCh1Voltage, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelCh1Current, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelChannel4, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelUnitCh4Voltage, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelUnitCh4Current, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelChannel2, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.labelCh2Current, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.labelCh2Voltage, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.numericUpDownCh2Voltage, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.labelUnitCh2Current, 2, 4);
			this.tableLayoutPanel1.Controls.Add(this.labelUnitCh2Voltage, 2, 5);
			this.tableLayoutPanel1.Controls.Add(this.labelChannel3, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelChannel1, 3, 3);
			this.tableLayoutPanel1.Controls.Add(this.labelCh3Current, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.numericUpDownCh3Current, 4, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelCh3Voltage, 3, 2);
			this.tableLayoutPanel1.Controls.Add(this.numericUpDownCh3Voltage, 4, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelUnitCh3Voltage, 5, 2);
			this.tableLayoutPanel1.Controls.Add(this.label1UnitCh1Voltage, 5, 5);
			this.tableLayoutPanel1.Controls.Add(this.label1UnitCh1Current, 5, 4);
			this.tableLayoutPanel1.Controls.Add(this.numericUpDownCh1Current, 4, 4);
			this.tableLayoutPanel1.Controls.Add(this.numericUpDownCh1Voltage, 4, 5);
			this.tableLayoutPanel1.Controls.Add(this.label1Ch1Current, 3, 4);
			this.tableLayoutPanel1.Controls.Add(this.label1Ch1Voltage, 3, 5);
			this.tableLayoutPanel1.Controls.Add(this.numericUpDownCh2Current, 1, 4);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 6;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(392, 130);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// labelCh1Voltage
			// 
			this.labelCh1Voltage.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelCh1Voltage.AutoSize = true;
			this.labelCh1Voltage.Location = new System.Drawing.Point(3, 45);
			this.labelCh1Voltage.Name = "labelCh1Voltage";
			this.labelCh1Voltage.Size = new System.Drawing.Size(43, 13);
			this.labelCh1Voltage.TabIndex = 1;
			this.labelCh1Voltage.Text = "Voltage";
			// 
			// labelCh1Current
			// 
			this.labelCh1Current.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelCh1Current.AutoSize = true;
			this.labelCh1Current.Location = new System.Drawing.Point(3, 19);
			this.labelCh1Current.Name = "labelCh1Current";
			this.labelCh1Current.Size = new System.Drawing.Size(41, 13);
			this.labelCh1Current.TabIndex = 0;
			this.labelCh1Current.Text = "Current";
			// 
			// labelUnitCh4Voltage
			// 
			this.labelUnitCh4Voltage.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelUnitCh4Voltage.AutoSize = true;
			this.labelUnitCh4Voltage.Location = new System.Drawing.Point(158, 45);
			this.labelUnitCh4Voltage.Name = "labelUnitCh4Voltage";
			this.labelUnitCh4Voltage.Size = new System.Drawing.Size(14, 13);
			this.labelUnitCh4Voltage.TabIndex = 11;
			this.labelUnitCh4Voltage.Text = "V";
			// 
			// labelUnitCh4Current
			// 
			this.labelUnitCh4Current.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelUnitCh4Current.Location = new System.Drawing.Point(158, 19);
			this.labelUnitCh4Current.Name = "labelUnitCh4Current";
			this.labelUnitCh4Current.Size = new System.Drawing.Size(35, 13);
			this.labelUnitCh4Current.TabIndex = 0;
			this.labelUnitCh4Current.Text = "A";
			// 
			// buttonWrite
			// 
			this.buttonWrite.Location = new System.Drawing.Point(301, 18);
			this.buttonWrite.Name = "buttonWrite";
			this.buttonWrite.Size = new System.Drawing.Size(75, 23);
			this.buttonWrite.TabIndex = 17;
			this.buttonWrite.Text = "Write All";
			this.buttonWrite.UseVisualStyleBackColor = true;
			this.buttonWrite.Click += new System.EventHandler(this.ButtonWrite_Click);
			// 
			// buttonRead
			// 
			this.buttonRead.Location = new System.Drawing.Point(220, 19);
			this.buttonRead.Name = "buttonRead";
			this.buttonRead.Size = new System.Drawing.Size(75, 22);
			this.buttonRead.TabIndex = 2;
			this.buttonRead.Text = "Read All";
			this.buttonRead.UseVisualStyleBackColor = true;
			this.buttonRead.Click += new System.EventHandler(this.ButtonRead_Click);
			// 
			// numericUpDownCh4Current
			// 
			this.numericUpDownCh4Current.DecimalPlaces = 2;
			this.numericUpDownCh4Current.Location = new System.Drawing.Point(52, 16);
			this.numericUpDownCh4Current.Name = "numericUpDownCh4Current";
			this.numericUpDownCh4Current.Size = new System.Drawing.Size(100, 20);
			this.numericUpDownCh4Current.TabIndex = 21;
			// 
			// numericUpDownCh4Voltage
			// 
			this.numericUpDownCh4Voltage.DecimalPlaces = 2;
			this.numericUpDownCh4Voltage.Location = new System.Drawing.Point(52, 42);
			this.numericUpDownCh4Voltage.Name = "numericUpDownCh4Voltage";
			this.numericUpDownCh4Voltage.Size = new System.Drawing.Size(100, 20);
			this.numericUpDownCh4Voltage.TabIndex = 22;
			// 
			// groupBoxOutput
			// 
			this.groupBoxOutput.AutoSize = true;
			this.groupBoxOutput.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxOutput.Controls.Add(this.radioButtonDisabled);
			this.groupBoxOutput.Controls.Add(this.radioButtonEnabled);
			this.groupBoxOutput.Controls.Add(this.buttonRead);
			this.groupBoxOutput.Controls.Add(this.buttonWrite);
			this.groupBoxOutput.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBoxOutput.Location = new System.Drawing.Point(0, 84);
			this.groupBoxOutput.Name = "groupBoxOutput";
			this.groupBoxOutput.Size = new System.Drawing.Size(408, 60);
			this.groupBoxOutput.TabIndex = 6;
			this.groupBoxOutput.TabStop = false;
			this.groupBoxOutput.Text = "Output";
			// 
			// radioButtonDisabled
			// 
			this.radioButtonDisabled.AutoSize = true;
			this.radioButtonDisabled.Checked = true;
			this.radioButtonDisabled.Location = new System.Drawing.Point(83, 20);
			this.radioButtonDisabled.Name = "radioButtonDisabled";
			this.radioButtonDisabled.Size = new System.Drawing.Size(66, 17);
			this.radioButtonDisabled.TabIndex = 1;
			this.radioButtonDisabled.TabStop = true;
			this.radioButtonDisabled.Text = "Disabled";
			this.radioButtonDisabled.UseVisualStyleBackColor = true;
			this.radioButtonDisabled.CheckedChanged += new System.EventHandler(this.RadioButtonOutput_CheckedChanged);
			// 
			// radioButtonEnabled
			// 
			this.radioButtonEnabled.AutoSize = true;
			this.radioButtonEnabled.Location = new System.Drawing.Point(13, 20);
			this.radioButtonEnabled.Name = "radioButtonEnabled";
			this.radioButtonEnabled.Size = new System.Drawing.Size(64, 17);
			this.radioButtonEnabled.TabIndex = 0;
			this.radioButtonEnabled.Text = "Enabled";
			this.radioButtonEnabled.UseVisualStyleBackColor = true;
			this.radioButtonEnabled.CheckedChanged += new System.EventHandler(this.RadioButtonOutput_CheckedChanged);
			// 
			// labelChannel4
			// 
			this.labelChannel4.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelChannel4.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.labelChannel4, 3);
			this.labelChannel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelChannel4.Location = new System.Drawing.Point(3, 0);
			this.labelChannel4.Name = "labelChannel4";
			this.labelChannel4.Size = new System.Drawing.Size(64, 13);
			this.labelChannel4.TabIndex = 24;
			this.labelChannel4.Text = "Channel 4";
			// 
			// labelChannel2
			// 
			this.labelChannel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelChannel2.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.labelChannel2, 3);
			this.labelChannel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelChannel2.Location = new System.Drawing.Point(3, 65);
			this.labelChannel2.Name = "labelChannel2";
			this.labelChannel2.Size = new System.Drawing.Size(64, 13);
			this.labelChannel2.TabIndex = 25;
			this.labelChannel2.Text = "Channel 2";
			// 
			// labelCh2Current
			// 
			this.labelCh2Current.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelCh2Current.AutoSize = true;
			this.labelCh2Current.Location = new System.Drawing.Point(3, 84);
			this.labelCh2Current.Name = "labelCh2Current";
			this.labelCh2Current.Size = new System.Drawing.Size(41, 13);
			this.labelCh2Current.TabIndex = 26;
			this.labelCh2Current.Text = "Current";
			// 
			// labelCh2Voltage
			// 
			this.labelCh2Voltage.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelCh2Voltage.AutoSize = true;
			this.labelCh2Voltage.Location = new System.Drawing.Point(3, 110);
			this.labelCh2Voltage.Name = "labelCh2Voltage";
			this.labelCh2Voltage.Size = new System.Drawing.Size(43, 13);
			this.labelCh2Voltage.TabIndex = 27;
			this.labelCh2Voltage.Text = "Voltage";
			// 
			// numericUpDownCh2Current
			// 
			this.numericUpDownCh2Current.DecimalPlaces = 2;
			this.numericUpDownCh2Current.Location = new System.Drawing.Point(52, 81);
			this.numericUpDownCh2Current.Name = "numericUpDownCh2Current";
			this.numericUpDownCh2Current.Size = new System.Drawing.Size(100, 20);
			this.numericUpDownCh2Current.TabIndex = 28;
			// 
			// numericUpDownCh2Voltage
			// 
			this.numericUpDownCh2Voltage.DecimalPlaces = 2;
			this.numericUpDownCh2Voltage.Location = new System.Drawing.Point(52, 107);
			this.numericUpDownCh2Voltage.Name = "numericUpDownCh2Voltage";
			this.numericUpDownCh2Voltage.Size = new System.Drawing.Size(100, 20);
			this.numericUpDownCh2Voltage.TabIndex = 29;
			// 
			// labelUnitCh2Current
			// 
			this.labelUnitCh2Current.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelUnitCh2Current.Location = new System.Drawing.Point(158, 84);
			this.labelUnitCh2Current.Name = "labelUnitCh2Current";
			this.labelUnitCh2Current.Size = new System.Drawing.Size(35, 13);
			this.labelUnitCh2Current.TabIndex = 30;
			this.labelUnitCh2Current.Text = "A";
			// 
			// labelUnitCh2Voltage
			// 
			this.labelUnitCh2Voltage.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelUnitCh2Voltage.AutoSize = true;
			this.labelUnitCh2Voltage.Location = new System.Drawing.Point(158, 110);
			this.labelUnitCh2Voltage.Name = "labelUnitCh2Voltage";
			this.labelUnitCh2Voltage.Size = new System.Drawing.Size(14, 13);
			this.labelUnitCh2Voltage.TabIndex = 31;
			this.labelUnitCh2Voltage.Text = "V";
			// 
			// labelChannel3
			// 
			this.labelChannel3.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelChannel3.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.labelChannel3, 3);
			this.labelChannel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelChannel3.Location = new System.Drawing.Point(199, 0);
			this.labelChannel3.Name = "labelChannel3";
			this.labelChannel3.Size = new System.Drawing.Size(64, 13);
			this.labelChannel3.TabIndex = 32;
			this.labelChannel3.Text = "Channel 3";
			// 
			// labelChannel1
			// 
			this.labelChannel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelChannel1.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.labelChannel1, 3);
			this.labelChannel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelChannel1.Location = new System.Drawing.Point(199, 65);
			this.labelChannel1.Name = "labelChannel1";
			this.labelChannel1.Size = new System.Drawing.Size(64, 13);
			this.labelChannel1.TabIndex = 33;
			this.labelChannel1.Text = "Channel 1";
			// 
			// labelCh3Current
			// 
			this.labelCh3Current.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelCh3Current.AutoSize = true;
			this.labelCh3Current.Location = new System.Drawing.Point(199, 19);
			this.labelCh3Current.Name = "labelCh3Current";
			this.labelCh3Current.Size = new System.Drawing.Size(41, 13);
			this.labelCh3Current.TabIndex = 34;
			this.labelCh3Current.Text = "Current";
			// 
			// numericUpDownCh3Current
			// 
			this.numericUpDownCh3Current.DecimalPlaces = 2;
			this.numericUpDownCh3Current.Location = new System.Drawing.Point(248, 16);
			this.numericUpDownCh3Current.Name = "numericUpDownCh3Current";
			this.numericUpDownCh3Current.Size = new System.Drawing.Size(100, 20);
			this.numericUpDownCh3Current.TabIndex = 35;
			// 
			// labelUnitCh3Current
			// 
			this.labelUnitCh3Current.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelUnitCh3Current.Location = new System.Drawing.Point(354, 19);
			this.labelUnitCh3Current.Name = "labelUnitCh3Current";
			this.labelUnitCh3Current.Size = new System.Drawing.Size(35, 13);
			this.labelUnitCh3Current.TabIndex = 36;
			this.labelUnitCh3Current.Text = "A";
			// 
			// labelCh3Voltage
			// 
			this.labelCh3Voltage.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelCh3Voltage.AutoSize = true;
			this.labelCh3Voltage.Location = new System.Drawing.Point(199, 45);
			this.labelCh3Voltage.Name = "labelCh3Voltage";
			this.labelCh3Voltage.Size = new System.Drawing.Size(43, 13);
			this.labelCh3Voltage.TabIndex = 37;
			this.labelCh3Voltage.Text = "Voltage";
			// 
			// numericUpDownCh3Voltage
			// 
			this.numericUpDownCh3Voltage.DecimalPlaces = 2;
			this.numericUpDownCh3Voltage.Location = new System.Drawing.Point(248, 42);
			this.numericUpDownCh3Voltage.Name = "numericUpDownCh3Voltage";
			this.numericUpDownCh3Voltage.Size = new System.Drawing.Size(100, 20);
			this.numericUpDownCh3Voltage.TabIndex = 38;
			// 
			// labelUnitCh3Voltage
			// 
			this.labelUnitCh3Voltage.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelUnitCh3Voltage.AutoSize = true;
			this.labelUnitCh3Voltage.Location = new System.Drawing.Point(354, 45);
			this.labelUnitCh3Voltage.Name = "labelUnitCh3Voltage";
			this.labelUnitCh3Voltage.Size = new System.Drawing.Size(14, 13);
			this.labelUnitCh3Voltage.TabIndex = 39;
			this.labelUnitCh3Voltage.Text = "V";
			// 
			// label1UnitCh1Voltage
			// 
			this.label1UnitCh1Voltage.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1UnitCh1Voltage.AutoSize = true;
			this.label1UnitCh1Voltage.Location = new System.Drawing.Point(354, 110);
			this.label1UnitCh1Voltage.Name = "label1UnitCh1Voltage";
			this.label1UnitCh1Voltage.Size = new System.Drawing.Size(14, 13);
			this.label1UnitCh1Voltage.TabIndex = 40;
			this.label1UnitCh1Voltage.Text = "V";
			// 
			// label1UnitCh1Current
			// 
			this.label1UnitCh1Current.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1UnitCh1Current.Location = new System.Drawing.Point(354, 84);
			this.label1UnitCh1Current.Name = "label1UnitCh1Current";
			this.label1UnitCh1Current.Size = new System.Drawing.Size(35, 13);
			this.label1UnitCh1Current.TabIndex = 41;
			this.label1UnitCh1Current.Text = "A";
			// 
			// numericUpDownCh1Current
			// 
			this.numericUpDownCh1Current.DecimalPlaces = 2;
			this.numericUpDownCh1Current.Location = new System.Drawing.Point(248, 81);
			this.numericUpDownCh1Current.Name = "numericUpDownCh1Current";
			this.numericUpDownCh1Current.Size = new System.Drawing.Size(100, 20);
			this.numericUpDownCh1Current.TabIndex = 42;
			// 
			// numericUpDownCh1Voltage
			// 
			this.numericUpDownCh1Voltage.DecimalPlaces = 2;
			this.numericUpDownCh1Voltage.Location = new System.Drawing.Point(248, 107);
			this.numericUpDownCh1Voltage.Name = "numericUpDownCh1Voltage";
			this.numericUpDownCh1Voltage.Size = new System.Drawing.Size(100, 20);
			this.numericUpDownCh1Voltage.TabIndex = 43;
			// 
			// label1Ch1Current
			// 
			this.label1Ch1Current.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1Ch1Current.AutoSize = true;
			this.label1Ch1Current.Location = new System.Drawing.Point(199, 84);
			this.label1Ch1Current.Name = "label1Ch1Current";
			this.label1Ch1Current.Size = new System.Drawing.Size(41, 13);
			this.label1Ch1Current.TabIndex = 44;
			this.label1Ch1Current.Text = "Current";
			// 
			// label1Ch1Voltage
			// 
			this.label1Ch1Voltage.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1Ch1Voltage.AutoSize = true;
			this.label1Ch1Voltage.Location = new System.Drawing.Point(199, 110);
			this.label1Ch1Voltage.Name = "label1Ch1Voltage";
			this.label1Ch1Voltage.Size = new System.Drawing.Size(43, 13);
			this.label1Ch1Voltage.TabIndex = 45;
			this.label1Ch1Voltage.Text = "Voltage";
			// 
			// FormPowerSupply
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(408, 351);
			this.Controls.Add(this.groupBoxPowerSupply);
			this.Controls.Add(this.groupBoxOutput);
			this.Controls.Add(this.groupBoxSerialPort);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Name = "FormPowerSupply";
			this.Text = "Power Supply";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormPowerSupply_FormClosed);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.groupBoxSerialPort.ResumeLayout(false);
			this.groupBoxSerialPort.PerformLayout();
			this.groupBoxPowerSupply.ResumeLayout(false);
			this.groupBoxPowerSupply.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh4Current)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh4Voltage)).EndInit();
			this.groupBoxOutput.ResumeLayout(false);
			this.groupBoxOutput.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh2Current)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh2Voltage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh3Current)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh3Voltage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh1Current)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh1Voltage)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.GroupBox groupBoxSerialPort;
		private System.Windows.Forms.RadioButton radioButtonClosed;
		private System.Windows.Forms.RadioButton radioButtonOpen;
		private System.Windows.Forms.ComboBox comboBoxSerialPort;
		private System.Windows.Forms.GroupBox groupBoxPowerSupply;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label labelCh1Current;
		private System.Windows.Forms.Label labelCh1Voltage;
		private System.Windows.Forms.Button buttonRead;
		private System.Windows.Forms.Label labelUnitCh4Current;
		private System.Windows.Forms.Label labelUnitCh4Voltage;
		private System.Windows.Forms.Button buttonWrite;
		private System.Windows.Forms.GroupBox groupBoxOutput;
		private System.Windows.Forms.RadioButton radioButtonDisabled;
		private System.Windows.Forms.RadioButton radioButtonEnabled;
		private System.Windows.Forms.NumericUpDown numericUpDownCh4Current;
		private System.Windows.Forms.NumericUpDown numericUpDownCh4Voltage;
		private System.Windows.Forms.Label labelChannel4;
		private System.Windows.Forms.Label labelChannel2;
		private System.Windows.Forms.Label labelCh2Current;
		private System.Windows.Forms.Label labelCh2Voltage;
		private System.Windows.Forms.NumericUpDown numericUpDownCh2Current;
		private System.Windows.Forms.NumericUpDown numericUpDownCh2Voltage;
		private System.Windows.Forms.Label labelUnitCh2Current;
		private System.Windows.Forms.Label labelUnitCh2Voltage;
		private System.Windows.Forms.Label labelUnitCh3Current;
		private System.Windows.Forms.Label labelChannel3;
		private System.Windows.Forms.Label labelChannel1;
		private System.Windows.Forms.Label labelCh3Current;
		private System.Windows.Forms.NumericUpDown numericUpDownCh3Current;
		private System.Windows.Forms.Label labelCh3Voltage;
		private System.Windows.Forms.NumericUpDown numericUpDownCh3Voltage;
		private System.Windows.Forms.Label labelUnitCh3Voltage;
		private System.Windows.Forms.Label label1UnitCh1Voltage;
		private System.Windows.Forms.Label label1UnitCh1Current;
		private System.Windows.Forms.NumericUpDown numericUpDownCh1Current;
		private System.Windows.Forms.NumericUpDown numericUpDownCh1Voltage;
		private System.Windows.Forms.Label label1Ch1Current;
		private System.Windows.Forms.Label label1Ch1Voltage;
	}
}

