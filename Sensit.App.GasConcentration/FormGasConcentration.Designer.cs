namespace Sensit.App.GasConcentration
{
	partial class FormGasConcentration
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
			this.groupBoxSerialPorts = new System.Windows.Forms.GroupBox();
			this.labelDilutentPort = new System.Windows.Forms.Label();
			this.labelGasUnderTestPort = new System.Windows.Forms.Label();
			this.radioButtonClosed = new System.Windows.Forms.RadioButton();
			this.radioButtonOpen = new System.Windows.Forms.RadioButton();
			this.comboBoxSerialPortDilutent = new System.Windows.Forms.ComboBox();
			this.comboBoxSerialPortGasUnderTest = new System.Windows.Forms.ComboBox();
			this.groupBoxMassFlow = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.labelSetpoint = new System.Windows.Forms.Label();
			this.labelGas = new System.Windows.Forms.Label();
			this.labelMassFlow = new System.Windows.Forms.Label();
			this.labelVolumetricFlow = new System.Windows.Forms.Label();
			this.labelTemperature = new System.Windows.Forms.Label();
			this.labelPressure = new System.Windows.Forms.Label();
			this.textBoxSetpoint = new System.Windows.Forms.TextBox();
			this.comboBoxGas = new System.Windows.Forms.ComboBox();
			this.textBoxMassFlow = new System.Windows.Forms.TextBox();
			this.textBoxVolumetricFlow = new System.Windows.Forms.TextBox();
			this.textBoxTemperature = new System.Windows.Forms.TextBox();
			this.textBoxPressure = new System.Windows.Forms.TextBox();
			this.labelGasUnderTest = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.labelUnitSetpoint = new System.Windows.Forms.Label();
			this.labelUnitMassFlow = new System.Windows.Forms.Label();
			this.labelUnitVolumetricFlow = new System.Windows.Forms.Label();
			this.labelUnitTemperature = new System.Windows.Forms.Label();
			this.labelUnitPressure = new System.Windows.Forms.Label();
			this.buttonWrite = new System.Windows.Forms.Button();
			this.buttonWriteGas = new System.Windows.Forms.Button();
			this.buttonReadAll = new System.Windows.Forms.Button();
			this.labelDilutent = new System.Windows.Forms.Label();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip1.SuspendLayout();
			this.groupBoxSerialPorts.SuspendLayout();
			this.groupBoxMassFlow.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(437, 24);
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
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
			this.exitToolStripMenuItem.Text = "&Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// groupBoxSerialPorts
			// 
			this.groupBoxSerialPorts.AutoSize = true;
			this.groupBoxSerialPorts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxSerialPorts.Controls.Add(this.labelDilutentPort);
			this.groupBoxSerialPorts.Controls.Add(this.labelGasUnderTestPort);
			this.groupBoxSerialPorts.Controls.Add(this.radioButtonClosed);
			this.groupBoxSerialPorts.Controls.Add(this.radioButtonOpen);
			this.groupBoxSerialPorts.Controls.Add(this.comboBoxSerialPortDilutent);
			this.groupBoxSerialPorts.Controls.Add(this.comboBoxSerialPortGasUnderTest);
			this.groupBoxSerialPorts.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBoxSerialPorts.Location = new System.Drawing.Point(0, 24);
			this.groupBoxSerialPorts.Name = "groupBoxSerialPorts";
			this.groupBoxSerialPorts.Size = new System.Drawing.Size(437, 72);
			this.groupBoxSerialPorts.TabIndex = 1;
			this.groupBoxSerialPorts.TabStop = false;
			this.groupBoxSerialPorts.Text = "Serial Ports";
			// 
			// labelDilutentPort
			// 
			this.labelDilutentPort.AutoSize = true;
			this.labelDilutentPort.Location = new System.Drawing.Point(133, 15);
			this.labelDilutentPort.Name = "labelDilutentPort";
			this.labelDilutentPort.Size = new System.Drawing.Size(43, 13);
			this.labelDilutentPort.TabIndex = 4;
			this.labelDilutentPort.Text = "Dilutent";
			// 
			// labelGasUnderTestPort
			// 
			this.labelGasUnderTestPort.AutoSize = true;
			this.labelGasUnderTestPort.Location = new System.Drawing.Point(6, 16);
			this.labelGasUnderTestPort.Name = "labelGasUnderTestPort";
			this.labelGasUnderTestPort.Size = new System.Drawing.Size(82, 13);
			this.labelGasUnderTestPort.TabIndex = 3;
			this.labelGasUnderTestPort.Text = "Gas Under Test";
			// 
			// radioButtonClosed
			// 
			this.radioButtonClosed.AutoSize = true;
			this.radioButtonClosed.Checked = true;
			this.radioButtonClosed.Location = new System.Drawing.Point(317, 33);
			this.radioButtonClosed.Name = "radioButtonClosed";
			this.radioButtonClosed.Size = new System.Drawing.Size(57, 17);
			this.radioButtonClosed.TabIndex = 2;
			this.radioButtonClosed.TabStop = true;
			this.radioButtonClosed.Text = "Closed";
			this.radioButtonClosed.UseVisualStyleBackColor = true;
			this.radioButtonClosed.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// radioButtonOpen
			// 
			this.radioButtonOpen.AutoSize = true;
			this.radioButtonOpen.Location = new System.Drawing.Point(260, 33);
			this.radioButtonOpen.Name = "radioButtonOpen";
			this.radioButtonOpen.Size = new System.Drawing.Size(51, 17);
			this.radioButtonOpen.TabIndex = 1;
			this.radioButtonOpen.Text = "Open";
			this.radioButtonOpen.UseVisualStyleBackColor = true;
			this.radioButtonOpen.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// comboBoxSerialPortDilutent
			// 
			this.comboBoxSerialPortDilutent.FormattingEnabled = true;
			this.comboBoxSerialPortDilutent.Location = new System.Drawing.Point(133, 32);
			this.comboBoxSerialPortDilutent.Name = "comboBoxSerialPortDilutent";
			this.comboBoxSerialPortDilutent.Size = new System.Drawing.Size(121, 21);
			this.comboBoxSerialPortDilutent.TabIndex = 0;
			this.comboBoxSerialPortDilutent.SelectedIndexChanged += new System.EventHandler(this.comboBoxSerialPortDilutent_SelectedIndexChanged);
			// 
			// comboBoxSerialPortGasUnderTest
			// 
			this.comboBoxSerialPortGasUnderTest.FormattingEnabled = true;
			this.comboBoxSerialPortGasUnderTest.Location = new System.Drawing.Point(6, 32);
			this.comboBoxSerialPortGasUnderTest.Name = "comboBoxSerialPortGasUnderTest";
			this.comboBoxSerialPortGasUnderTest.Size = new System.Drawing.Size(121, 21);
			this.comboBoxSerialPortGasUnderTest.TabIndex = 0;
			this.comboBoxSerialPortGasUnderTest.SelectedIndexChanged += new System.EventHandler(this.comboBoxSerialPortGasUnderTest_SelectedIndexChanged);
			// 
			// groupBoxMassFlow
			// 
			this.groupBoxMassFlow.Controls.Add(this.tableLayoutPanel1);
			this.groupBoxMassFlow.Controls.Add(this.statusStrip1);
			this.groupBoxMassFlow.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxMassFlow.Location = new System.Drawing.Point(0, 96);
			this.groupBoxMassFlow.Name = "groupBoxMassFlow";
			this.groupBoxMassFlow.Size = new System.Drawing.Size(437, 265);
			this.groupBoxMassFlow.TabIndex = 3;
			this.groupBoxMassFlow.TabStop = false;
			this.groupBoxMassFlow.Text = "Gas Concentration Control";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 5;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.labelSetpoint, 0, 6);
			this.tableLayoutPanel1.Controls.Add(this.labelGas, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.labelMassFlow, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.labelVolumetricFlow, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.labelTemperature, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelPressure, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.textBoxSetpoint, 1, 6);
			this.tableLayoutPanel1.Controls.Add(this.comboBoxGas, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.textBoxMassFlow, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.textBoxVolumetricFlow, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.textBoxTemperature, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.textBoxPressure, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelGasUnderTest, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.textBox6, 2, 6);
			this.tableLayoutPanel1.Controls.Add(this.comboBox1, 2, 5);
			this.tableLayoutPanel1.Controls.Add(this.textBox4, 2, 4);
			this.tableLayoutPanel1.Controls.Add(this.textBox3, 2, 3);
			this.tableLayoutPanel1.Controls.Add(this.textBox2, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.textBox1, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelUnitSetpoint, 3, 6);
			this.tableLayoutPanel1.Controls.Add(this.labelUnitMassFlow, 3, 4);
			this.tableLayoutPanel1.Controls.Add(this.labelUnitVolumetricFlow, 3, 3);
			this.tableLayoutPanel1.Controls.Add(this.labelUnitTemperature, 3, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelUnitPressure, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.buttonWrite, 4, 6);
			this.tableLayoutPanel1.Controls.Add(this.buttonWriteGas, 4, 5);
			this.tableLayoutPanel1.Controls.Add(this.buttonReadAll, 4, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelDilutent, 2, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 7;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(423, 178);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// labelSetpoint
			// 
			this.labelSetpoint.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelSetpoint.AutoSize = true;
			this.labelSetpoint.Location = new System.Drawing.Point(3, 157);
			this.labelSetpoint.Name = "labelSetpoint";
			this.labelSetpoint.Size = new System.Drawing.Size(46, 13);
			this.labelSetpoint.TabIndex = 8;
			this.labelSetpoint.Text = "Setpoint";
			// 
			// labelGas
			// 
			this.labelGas.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelGas.AutoSize = true;
			this.labelGas.Location = new System.Drawing.Point(3, 128);
			this.labelGas.Name = "labelGas";
			this.labelGas.Size = new System.Drawing.Size(26, 13);
			this.labelGas.TabIndex = 15;
			this.labelGas.Text = "Gas";
			// 
			// labelMassFlow
			// 
			this.labelMassFlow.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelMassFlow.AutoSize = true;
			this.labelMassFlow.Location = new System.Drawing.Point(3, 100);
			this.labelMassFlow.Name = "labelMassFlow";
			this.labelMassFlow.Size = new System.Drawing.Size(57, 13);
			this.labelMassFlow.TabIndex = 6;
			this.labelMassFlow.Text = "Mass Flow";
			// 
			// labelVolumetricFlow
			// 
			this.labelVolumetricFlow.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelVolumetricFlow.AutoSize = true;
			this.labelVolumetricFlow.Location = new System.Drawing.Point(3, 74);
			this.labelVolumetricFlow.Name = "labelVolumetricFlow";
			this.labelVolumetricFlow.Size = new System.Drawing.Size(81, 13);
			this.labelVolumetricFlow.TabIndex = 4;
			this.labelVolumetricFlow.Text = "Volumetric Flow";
			// 
			// labelTemperature
			// 
			this.labelTemperature.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelTemperature.AutoSize = true;
			this.labelTemperature.Location = new System.Drawing.Point(3, 48);
			this.labelTemperature.Name = "labelTemperature";
			this.labelTemperature.Size = new System.Drawing.Size(67, 13);
			this.labelTemperature.TabIndex = 1;
			this.labelTemperature.Text = "Temperature";
			// 
			// labelPressure
			// 
			this.labelPressure.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelPressure.AutoSize = true;
			this.labelPressure.Location = new System.Drawing.Point(3, 21);
			this.labelPressure.Name = "labelPressure";
			this.labelPressure.Size = new System.Drawing.Size(48, 13);
			this.labelPressure.TabIndex = 0;
			this.labelPressure.Text = "Pressure";
			// 
			// textBoxSetpoint
			// 
			this.textBoxSetpoint.Enabled = false;
			this.textBoxSetpoint.Location = new System.Drawing.Point(90, 152);
			this.textBoxSetpoint.Name = "textBoxSetpoint";
			this.textBoxSetpoint.Size = new System.Drawing.Size(100, 20);
			this.textBoxSetpoint.TabIndex = 9;
			// 
			// comboBoxGas
			// 
			this.comboBoxGas.Enabled = false;
			this.comboBoxGas.FormattingEnabled = true;
			this.comboBoxGas.Location = new System.Drawing.Point(90, 123);
			this.comboBoxGas.Name = "comboBoxGas";
			this.comboBoxGas.Size = new System.Drawing.Size(100, 21);
			this.comboBoxGas.TabIndex = 16;
			// 
			// textBoxMassFlow
			// 
			this.textBoxMassFlow.Location = new System.Drawing.Point(90, 97);
			this.textBoxMassFlow.Name = "textBoxMassFlow";
			this.textBoxMassFlow.ReadOnly = true;
			this.textBoxMassFlow.Size = new System.Drawing.Size(100, 20);
			this.textBoxMassFlow.TabIndex = 7;
			// 
			// textBoxVolumetricFlow
			// 
			this.textBoxVolumetricFlow.Location = new System.Drawing.Point(90, 71);
			this.textBoxVolumetricFlow.Name = "textBoxVolumetricFlow";
			this.textBoxVolumetricFlow.ReadOnly = true;
			this.textBoxVolumetricFlow.Size = new System.Drawing.Size(100, 20);
			this.textBoxVolumetricFlow.TabIndex = 5;
			// 
			// textBoxTemperature
			// 
			this.textBoxTemperature.Location = new System.Drawing.Point(90, 45);
			this.textBoxTemperature.Name = "textBoxTemperature";
			this.textBoxTemperature.ReadOnly = true;
			this.textBoxTemperature.Size = new System.Drawing.Size(100, 20);
			this.textBoxTemperature.TabIndex = 3;
			// 
			// textBoxPressure
			// 
			this.textBoxPressure.Location = new System.Drawing.Point(90, 16);
			this.textBoxPressure.Name = "textBoxPressure";
			this.textBoxPressure.ReadOnly = true;
			this.textBoxPressure.Size = new System.Drawing.Size(100, 20);
			this.textBoxPressure.TabIndex = 2;
			// 
			// labelGasUnderTest
			// 
			this.labelGasUnderTest.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelGasUnderTest.AutoSize = true;
			this.labelGasUnderTest.Location = new System.Drawing.Point(99, 0);
			this.labelGasUnderTest.Name = "labelGasUnderTest";
			this.labelGasUnderTest.Size = new System.Drawing.Size(82, 13);
			this.labelGasUnderTest.TabIndex = 23;
			this.labelGasUnderTest.Text = "Gas Under Test";
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(196, 152);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(100, 20);
			this.textBox6.TabIndex = 2;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(196, 123);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(100, 21);
			this.comboBox1.TabIndex = 22;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(196, 97);
			this.textBox4.Name = "textBox4";
			this.textBox4.ReadOnly = true;
			this.textBox4.Size = new System.Drawing.Size(100, 20);
			this.textBox4.TabIndex = 21;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(196, 71);
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(100, 20);
			this.textBox3.TabIndex = 20;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(196, 45);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(100, 20);
			this.textBox2.TabIndex = 19;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(196, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 18;
			// 
			// labelUnitSetpoint
			// 
			this.labelUnitSetpoint.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelUnitSetpoint.AutoSize = true;
			this.labelUnitSetpoint.Location = new System.Drawing.Point(302, 157);
			this.labelUnitSetpoint.Name = "labelUnitSetpoint";
			this.labelUnitSetpoint.Size = new System.Drawing.Size(37, 13);
			this.labelUnitSetpoint.TabIndex = 14;
			this.labelUnitSetpoint.Text = "SCCM";
			// 
			// labelUnitMassFlow
			// 
			this.labelUnitMassFlow.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelUnitMassFlow.AutoSize = true;
			this.labelUnitMassFlow.Location = new System.Drawing.Point(302, 100);
			this.labelUnitMassFlow.Name = "labelUnitMassFlow";
			this.labelUnitMassFlow.Size = new System.Drawing.Size(37, 13);
			this.labelUnitMassFlow.TabIndex = 13;
			this.labelUnitMassFlow.Text = "SCCM";
			// 
			// labelUnitVolumetricFlow
			// 
			this.labelUnitVolumetricFlow.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelUnitVolumetricFlow.AutoSize = true;
			this.labelUnitVolumetricFlow.Location = new System.Drawing.Point(302, 74);
			this.labelUnitVolumetricFlow.Name = "labelUnitVolumetricFlow";
			this.labelUnitVolumetricFlow.Size = new System.Drawing.Size(30, 13);
			this.labelUnitVolumetricFlow.TabIndex = 12;
			this.labelUnitVolumetricFlow.Text = "CCM";
			// 
			// labelUnitTemperature
			// 
			this.labelUnitTemperature.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelUnitTemperature.AutoSize = true;
			this.labelUnitTemperature.Location = new System.Drawing.Point(302, 48);
			this.labelUnitTemperature.Name = "labelUnitTemperature";
			this.labelUnitTemperature.Size = new System.Drawing.Size(18, 13);
			this.labelUnitTemperature.TabIndex = 11;
			this.labelUnitTemperature.Text = "°C";
			// 
			// labelUnitPressure
			// 
			this.labelUnitPressure.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelUnitPressure.Location = new System.Drawing.Point(302, 21);
			this.labelUnitPressure.Name = "labelUnitPressure";
			this.labelUnitPressure.Size = new System.Drawing.Size(35, 13);
			this.labelUnitPressure.TabIndex = 0;
			this.labelUnitPressure.Text = "PSIA";
			// 
			// buttonWrite
			// 
			this.buttonWrite.Enabled = false;
			this.buttonWrite.Location = new System.Drawing.Point(345, 152);
			this.buttonWrite.Name = "buttonWrite";
			this.buttonWrite.Size = new System.Drawing.Size(75, 23);
			this.buttonWrite.TabIndex = 10;
			this.buttonWrite.Text = "Write SP";
			this.buttonWrite.UseVisualStyleBackColor = true;
			// 
			// buttonWriteGas
			// 
			this.buttonWriteGas.Enabled = false;
			this.buttonWriteGas.Location = new System.Drawing.Point(345, 123);
			this.buttonWriteGas.Name = "buttonWriteGas";
			this.buttonWriteGas.Size = new System.Drawing.Size(75, 23);
			this.buttonWriteGas.TabIndex = 17;
			this.buttonWriteGas.Text = "Write Gas";
			this.buttonWriteGas.UseVisualStyleBackColor = true;
			// 
			// buttonReadAll
			// 
			this.buttonReadAll.Enabled = false;
			this.buttonReadAll.Location = new System.Drawing.Point(345, 16);
			this.buttonReadAll.Name = "buttonReadAll";
			this.buttonReadAll.Size = new System.Drawing.Size(75, 23);
			this.buttonReadAll.TabIndex = 2;
			this.buttonReadAll.Text = "Read All";
			this.buttonReadAll.UseVisualStyleBackColor = true;
			// 
			// labelDilutent
			// 
			this.labelDilutent.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelDilutent.AutoSize = true;
			this.labelDilutent.Location = new System.Drawing.Point(224, 0);
			this.labelDilutent.Name = "labelDilutent";
			this.labelDilutent.Size = new System.Drawing.Size(43, 13);
			this.labelDilutent.TabIndex = 24;
			this.labelDilutent.Text = "Dilutent";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(3, 240);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(431, 22);
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
			this.toolStripStatusLabel1.Text = "Ready";
			// 
			// FormGasConcentration
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(437, 361);
			this.Controls.Add(this.groupBoxMassFlow);
			this.Controls.Add(this.groupBoxSerialPorts);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FormGasConcentration";
			this.Text = "Gas Concentration Controller";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormGasConcentration_FormClosed);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.groupBoxSerialPorts.ResumeLayout(false);
			this.groupBoxSerialPorts.PerformLayout();
			this.groupBoxMassFlow.ResumeLayout(false);
			this.groupBoxMassFlow.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.GroupBox groupBoxSerialPorts;
		private System.Windows.Forms.RadioButton radioButtonClosed;
		private System.Windows.Forms.RadioButton radioButtonOpen;
		private System.Windows.Forms.ComboBox comboBoxSerialPortGasUnderTest;
		private System.Windows.Forms.ComboBox comboBoxSerialPortDilutent;
		private System.Windows.Forms.GroupBox groupBoxMassFlow;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label labelPressure;
		private System.Windows.Forms.Label labelTemperature;
		private System.Windows.Forms.TextBox textBoxPressure;
		private System.Windows.Forms.TextBox textBoxTemperature;
		private System.Windows.Forms.Label labelVolumetricFlow;
		private System.Windows.Forms.TextBox textBoxVolumetricFlow;
		private System.Windows.Forms.Label labelMassFlow;
		private System.Windows.Forms.TextBox textBoxMassFlow;
		private System.Windows.Forms.Button buttonReadAll;
		private System.Windows.Forms.Label labelUnitPressure;
		private System.Windows.Forms.Label labelUnitTemperature;
		private System.Windows.Forms.Label labelUnitVolumetricFlow;
		private System.Windows.Forms.Label labelUnitMassFlow;
		private System.Windows.Forms.Label labelSetpoint;
		private System.Windows.Forms.TextBox textBoxSetpoint;
		private System.Windows.Forms.Label labelUnitSetpoint;
		private System.Windows.Forms.Label labelGas;
		private System.Windows.Forms.ComboBox comboBoxGas;
		private System.Windows.Forms.Button buttonWrite;
		private System.Windows.Forms.Button buttonWriteGas;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.Label labelDilutentPort;
		private System.Windows.Forms.Label labelGasUnderTestPort;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label labelGasUnderTest;
		private System.Windows.Forms.Label labelDilutent;
	}
}

