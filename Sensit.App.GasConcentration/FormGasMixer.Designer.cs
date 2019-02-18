namespace Sensit.App.GasConcentration
{
	partial class FormGasMixer
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
			this.labelDiluentPort = new System.Windows.Forms.Label();
			this.labelAnalytePort = new System.Windows.Forms.Label();
			this.radioButtonClosed = new System.Windows.Forms.RadioButton();
			this.radioButtonOpen = new System.Windows.Forms.RadioButton();
			this.comboBoxDiluentPort = new System.Windows.Forms.ComboBox();
			this.comboBoxAnalytePort = new System.Windows.Forms.ComboBox();
			this.groupBoxMassFlow = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanelMassFlow = new System.Windows.Forms.TableLayoutPanel();
			this.labelSetpoint = new System.Windows.Forms.Label();
			this.labelGas = new System.Windows.Forms.Label();
			this.labelMassFlow = new System.Windows.Forms.Label();
			this.labelVolumetricFlow = new System.Windows.Forms.Label();
			this.labelTemperature = new System.Windows.Forms.Label();
			this.labelPressure = new System.Windows.Forms.Label();
			this.textBoxAnalyteSetpoint = new System.Windows.Forms.TextBox();
			this.comboBoxAnalyteGas = new System.Windows.Forms.ComboBox();
			this.textBoxAnalyteMassFlow = new System.Windows.Forms.TextBox();
			this.textBoxAnalyteVolumetricFlow = new System.Windows.Forms.TextBox();
			this.textBoxAnalyteTemperature = new System.Windows.Forms.TextBox();
			this.textBoxAnalytePressure = new System.Windows.Forms.TextBox();
			this.labelAnalyte = new System.Windows.Forms.Label();
			this.textBoxDiluentSetpoint = new System.Windows.Forms.TextBox();
			this.comboBoxDiluentGas = new System.Windows.Forms.ComboBox();
			this.textBoxDiluentMassFlow = new System.Windows.Forms.TextBox();
			this.textBoxDiluentVolumetricFlow = new System.Windows.Forms.TextBox();
			this.textBoxDiluentTemperature = new System.Windows.Forms.TextBox();
			this.textBoxDiluentPressure = new System.Windows.Forms.TextBox();
			this.labelUnitSetpoint = new System.Windows.Forms.Label();
			this.labelUnitMassFlow = new System.Windows.Forms.Label();
			this.labelUnitVolumetricFlow = new System.Windows.Forms.Label();
			this.labelUnitTemperature = new System.Windows.Forms.Label();
			this.labelUnitPressure = new System.Windows.Forms.Label();
			this.buttonWriteSP = new System.Windows.Forms.Button();
			this.buttonWriteGas = new System.Windows.Forms.Button();
			this.buttonReadMFCAll = new System.Windows.Forms.Button();
			this.labelDiluent = new System.Windows.Forms.Label();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.groupBoxGasConcentration = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanelGasConcentration = new System.Windows.Forms.TableLayoutPanel();
			this.labelGasConcentrationSetpoint = new System.Windows.Forms.Label();
			this.labelUnitGasConcentrationSetpoint = new System.Windows.Forms.Label();
			this.buttonWriteAll = new System.Windows.Forms.Button();
			this.textBoxGasConcentrationSetpoint = new System.Windows.Forms.TextBox();
			this.textBoxGasConcentration = new System.Windows.Forms.TextBox();
			this.labelUnitGasConcentration = new System.Windows.Forms.Label();
			this.labelConcentration = new System.Windows.Forms.Label();
			this.buttonReadAll = new System.Windows.Forms.Button();
			this.labelAnalyteBottleConcentration = new System.Windows.Forms.Label();
			this.labelMassFlowSetpoint = new System.Windows.Forms.Label();
			this.textBoxAnalyteBottleConcentration = new System.Windows.Forms.TextBox();
			this.textBoxMassFlowSetpoint = new System.Windows.Forms.TextBox();
			this.labelUnitAnalyteBottleConcentration = new System.Windows.Forms.Label();
			this.labelUnitMassFlowSetpoint = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.groupBoxSerialPorts.SuspendLayout();
			this.groupBoxMassFlow.SuspendLayout();
			this.tableLayoutPanelMassFlow.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.groupBoxGasConcentration.SuspendLayout();
			this.tableLayoutPanelGasConcentration.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(439, 24);
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
			this.groupBoxSerialPorts.Controls.Add(this.labelDiluentPort);
			this.groupBoxSerialPorts.Controls.Add(this.labelAnalytePort);
			this.groupBoxSerialPorts.Controls.Add(this.radioButtonClosed);
			this.groupBoxSerialPorts.Controls.Add(this.radioButtonOpen);
			this.groupBoxSerialPorts.Controls.Add(this.comboBoxDiluentPort);
			this.groupBoxSerialPorts.Controls.Add(this.comboBoxAnalytePort);
			this.groupBoxSerialPorts.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBoxSerialPorts.Location = new System.Drawing.Point(0, 24);
			this.groupBoxSerialPorts.Name = "groupBoxSerialPorts";
			this.groupBoxSerialPorts.Size = new System.Drawing.Size(439, 72);
			this.groupBoxSerialPorts.TabIndex = 1;
			this.groupBoxSerialPorts.TabStop = false;
			this.groupBoxSerialPorts.Text = "Serial Ports";
			// 
			// labelDiluentPort
			// 
			this.labelDiluentPort.AutoSize = true;
			this.labelDiluentPort.Location = new System.Drawing.Point(133, 15);
			this.labelDiluentPort.Name = "labelDiluentPort";
			this.labelDiluentPort.Size = new System.Drawing.Size(40, 13);
			this.labelDiluentPort.TabIndex = 4;
			this.labelDiluentPort.Text = "Diluent";
			// 
			// labelAnalytePort
			// 
			this.labelAnalytePort.AutoSize = true;
			this.labelAnalytePort.Location = new System.Drawing.Point(6, 16);
			this.labelAnalytePort.Name = "labelAnalytePort";
			this.labelAnalytePort.Size = new System.Drawing.Size(42, 13);
			this.labelAnalytePort.TabIndex = 3;
			this.labelAnalytePort.Text = "Analyte";
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
			// comboBoxDiluentPort
			// 
			this.comboBoxDiluentPort.FormattingEnabled = true;
			this.comboBoxDiluentPort.Location = new System.Drawing.Point(133, 32);
			this.comboBoxDiluentPort.Name = "comboBoxDiluentPort";
			this.comboBoxDiluentPort.Size = new System.Drawing.Size(121, 21);
			this.comboBoxDiluentPort.TabIndex = 0;
			this.comboBoxDiluentPort.SelectedIndexChanged += new System.EventHandler(this.comboBoxSerialPortDiluent_SelectedIndexChanged);
			// 
			// comboBoxAnalytePort
			// 
			this.comboBoxAnalytePort.FormattingEnabled = true;
			this.comboBoxAnalytePort.Location = new System.Drawing.Point(6, 32);
			this.comboBoxAnalytePort.Name = "comboBoxAnalytePort";
			this.comboBoxAnalytePort.Size = new System.Drawing.Size(121, 21);
			this.comboBoxAnalytePort.TabIndex = 0;
			this.comboBoxAnalytePort.SelectedIndexChanged += new System.EventHandler(this.comboBoxSerialPortGasUnderTest_SelectedIndexChanged);
			// 
			// groupBoxMassFlow
			// 
			this.groupBoxMassFlow.AutoSize = true;
			this.groupBoxMassFlow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxMassFlow.Controls.Add(this.tableLayoutPanelMassFlow);
			this.groupBoxMassFlow.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBoxMassFlow.Enabled = false;
			this.groupBoxMassFlow.Location = new System.Drawing.Point(0, 96);
			this.groupBoxMassFlow.Name = "groupBoxMassFlow";
			this.groupBoxMassFlow.Size = new System.Drawing.Size(439, 216);
			this.groupBoxMassFlow.TabIndex = 3;
			this.groupBoxMassFlow.TabStop = false;
			this.groupBoxMassFlow.Text = "Mass Flow";
			// 
			// tableLayoutPanelMassFlow
			// 
			this.tableLayoutPanelMassFlow.AutoSize = true;
			this.tableLayoutPanelMassFlow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelMassFlow.ColumnCount = 5;
			this.tableLayoutPanelMassFlow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelMassFlow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelMassFlow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelMassFlow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelMassFlow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelMassFlow.Controls.Add(this.labelSetpoint, 0, 6);
			this.tableLayoutPanelMassFlow.Controls.Add(this.labelGas, 0, 5);
			this.tableLayoutPanelMassFlow.Controls.Add(this.labelMassFlow, 0, 4);
			this.tableLayoutPanelMassFlow.Controls.Add(this.labelVolumetricFlow, 0, 3);
			this.tableLayoutPanelMassFlow.Controls.Add(this.labelTemperature, 0, 2);
			this.tableLayoutPanelMassFlow.Controls.Add(this.labelPressure, 0, 1);
			this.tableLayoutPanelMassFlow.Controls.Add(this.textBoxAnalyteSetpoint, 1, 6);
			this.tableLayoutPanelMassFlow.Controls.Add(this.comboBoxAnalyteGas, 1, 5);
			this.tableLayoutPanelMassFlow.Controls.Add(this.textBoxAnalyteMassFlow, 1, 4);
			this.tableLayoutPanelMassFlow.Controls.Add(this.textBoxAnalyteVolumetricFlow, 1, 3);
			this.tableLayoutPanelMassFlow.Controls.Add(this.textBoxAnalyteTemperature, 1, 2);
			this.tableLayoutPanelMassFlow.Controls.Add(this.textBoxAnalytePressure, 1, 1);
			this.tableLayoutPanelMassFlow.Controls.Add(this.labelAnalyte, 1, 0);
			this.tableLayoutPanelMassFlow.Controls.Add(this.textBoxDiluentSetpoint, 2, 6);
			this.tableLayoutPanelMassFlow.Controls.Add(this.comboBoxDiluentGas, 2, 5);
			this.tableLayoutPanelMassFlow.Controls.Add(this.textBoxDiluentMassFlow, 2, 4);
			this.tableLayoutPanelMassFlow.Controls.Add(this.textBoxDiluentVolumetricFlow, 2, 3);
			this.tableLayoutPanelMassFlow.Controls.Add(this.textBoxDiluentTemperature, 2, 2);
			this.tableLayoutPanelMassFlow.Controls.Add(this.textBoxDiluentPressure, 2, 1);
			this.tableLayoutPanelMassFlow.Controls.Add(this.labelUnitSetpoint, 3, 6);
			this.tableLayoutPanelMassFlow.Controls.Add(this.labelUnitMassFlow, 3, 4);
			this.tableLayoutPanelMassFlow.Controls.Add(this.labelUnitVolumetricFlow, 3, 3);
			this.tableLayoutPanelMassFlow.Controls.Add(this.labelUnitTemperature, 3, 2);
			this.tableLayoutPanelMassFlow.Controls.Add(this.labelUnitPressure, 3, 1);
			this.tableLayoutPanelMassFlow.Controls.Add(this.buttonWriteSP, 4, 6);
			this.tableLayoutPanelMassFlow.Controls.Add(this.buttonWriteGas, 4, 5);
			this.tableLayoutPanelMassFlow.Controls.Add(this.buttonReadMFCAll, 4, 1);
			this.tableLayoutPanelMassFlow.Controls.Add(this.labelDiluent, 2, 0);
			this.tableLayoutPanelMassFlow.Location = new System.Drawing.Point(6, 19);
			this.tableLayoutPanelMassFlow.Name = "tableLayoutPanelMassFlow";
			this.tableLayoutPanelMassFlow.RowCount = 7;
			this.tableLayoutPanelMassFlow.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMassFlow.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMassFlow.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMassFlow.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMassFlow.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMassFlow.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMassFlow.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMassFlow.Size = new System.Drawing.Size(423, 178);
			this.tableLayoutPanelMassFlow.TabIndex = 1;
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
			// textBoxAnalyteSetpoint
			// 
			this.textBoxAnalyteSetpoint.Location = new System.Drawing.Point(90, 152);
			this.textBoxAnalyteSetpoint.Name = "textBoxAnalyteSetpoint";
			this.textBoxAnalyteSetpoint.Size = new System.Drawing.Size(100, 20);
			this.textBoxAnalyteSetpoint.TabIndex = 9;
			// 
			// comboBoxAnalyteGas
			// 
			this.comboBoxAnalyteGas.FormattingEnabled = true;
			this.comboBoxAnalyteGas.Location = new System.Drawing.Point(90, 123);
			this.comboBoxAnalyteGas.Name = "comboBoxAnalyteGas";
			this.comboBoxAnalyteGas.Size = new System.Drawing.Size(100, 21);
			this.comboBoxAnalyteGas.TabIndex = 16;
			// 
			// textBoxAnalyteMassFlow
			// 
			this.textBoxAnalyteMassFlow.Location = new System.Drawing.Point(90, 97);
			this.textBoxAnalyteMassFlow.Name = "textBoxAnalyteMassFlow";
			this.textBoxAnalyteMassFlow.ReadOnly = true;
			this.textBoxAnalyteMassFlow.Size = new System.Drawing.Size(100, 20);
			this.textBoxAnalyteMassFlow.TabIndex = 7;
			// 
			// textBoxAnalyteVolumetricFlow
			// 
			this.textBoxAnalyteVolumetricFlow.Location = new System.Drawing.Point(90, 71);
			this.textBoxAnalyteVolumetricFlow.Name = "textBoxAnalyteVolumetricFlow";
			this.textBoxAnalyteVolumetricFlow.ReadOnly = true;
			this.textBoxAnalyteVolumetricFlow.Size = new System.Drawing.Size(100, 20);
			this.textBoxAnalyteVolumetricFlow.TabIndex = 5;
			// 
			// textBoxAnalyteTemperature
			// 
			this.textBoxAnalyteTemperature.Location = new System.Drawing.Point(90, 45);
			this.textBoxAnalyteTemperature.Name = "textBoxAnalyteTemperature";
			this.textBoxAnalyteTemperature.ReadOnly = true;
			this.textBoxAnalyteTemperature.Size = new System.Drawing.Size(100, 20);
			this.textBoxAnalyteTemperature.TabIndex = 3;
			// 
			// textBoxAnalytePressure
			// 
			this.textBoxAnalytePressure.Location = new System.Drawing.Point(90, 16);
			this.textBoxAnalytePressure.Name = "textBoxAnalytePressure";
			this.textBoxAnalytePressure.ReadOnly = true;
			this.textBoxAnalytePressure.Size = new System.Drawing.Size(100, 20);
			this.textBoxAnalytePressure.TabIndex = 2;
			// 
			// labelAnalyte
			// 
			this.labelAnalyte.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelAnalyte.AutoSize = true;
			this.labelAnalyte.Location = new System.Drawing.Point(119, 0);
			this.labelAnalyte.Name = "labelAnalyte";
			this.labelAnalyte.Size = new System.Drawing.Size(42, 13);
			this.labelAnalyte.TabIndex = 23;
			this.labelAnalyte.Text = "Analyte";
			// 
			// textBoxDiluentSetpoint
			// 
			this.textBoxDiluentSetpoint.Location = new System.Drawing.Point(196, 152);
			this.textBoxDiluentSetpoint.Name = "textBoxDiluentSetpoint";
			this.textBoxDiluentSetpoint.Size = new System.Drawing.Size(100, 20);
			this.textBoxDiluentSetpoint.TabIndex = 2;
			// 
			// comboBoxDiluentGas
			// 
			this.comboBoxDiluentGas.FormattingEnabled = true;
			this.comboBoxDiluentGas.Location = new System.Drawing.Point(196, 123);
			this.comboBoxDiluentGas.Name = "comboBoxDiluentGas";
			this.comboBoxDiluentGas.Size = new System.Drawing.Size(100, 21);
			this.comboBoxDiluentGas.TabIndex = 22;
			// 
			// textBoxDiluentMassFlow
			// 
			this.textBoxDiluentMassFlow.Location = new System.Drawing.Point(196, 97);
			this.textBoxDiluentMassFlow.Name = "textBoxDiluentMassFlow";
			this.textBoxDiluentMassFlow.ReadOnly = true;
			this.textBoxDiluentMassFlow.Size = new System.Drawing.Size(100, 20);
			this.textBoxDiluentMassFlow.TabIndex = 21;
			// 
			// textBoxDiluentVolumetricFlow
			// 
			this.textBoxDiluentVolumetricFlow.Location = new System.Drawing.Point(196, 71);
			this.textBoxDiluentVolumetricFlow.Name = "textBoxDiluentVolumetricFlow";
			this.textBoxDiluentVolumetricFlow.ReadOnly = true;
			this.textBoxDiluentVolumetricFlow.Size = new System.Drawing.Size(100, 20);
			this.textBoxDiluentVolumetricFlow.TabIndex = 20;
			// 
			// textBoxDiluentTemperature
			// 
			this.textBoxDiluentTemperature.Location = new System.Drawing.Point(196, 45);
			this.textBoxDiluentTemperature.Name = "textBoxDiluentTemperature";
			this.textBoxDiluentTemperature.ReadOnly = true;
			this.textBoxDiluentTemperature.Size = new System.Drawing.Size(100, 20);
			this.textBoxDiluentTemperature.TabIndex = 19;
			// 
			// textBoxDiluentPressure
			// 
			this.textBoxDiluentPressure.Location = new System.Drawing.Point(196, 16);
			this.textBoxDiluentPressure.Name = "textBoxDiluentPressure";
			this.textBoxDiluentPressure.ReadOnly = true;
			this.textBoxDiluentPressure.Size = new System.Drawing.Size(100, 20);
			this.textBoxDiluentPressure.TabIndex = 18;
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
			// buttonWriteSP
			// 
			this.buttonWriteSP.Location = new System.Drawing.Point(345, 152);
			this.buttonWriteSP.Name = "buttonWriteSP";
			this.buttonWriteSP.Size = new System.Drawing.Size(75, 23);
			this.buttonWriteSP.TabIndex = 10;
			this.buttonWriteSP.Text = "Write SP";
			this.buttonWriteSP.UseVisualStyleBackColor = true;
			this.buttonWriteSP.Click += new System.EventHandler(this.buttonWrite_Click);
			// 
			// buttonWriteGas
			// 
			this.buttonWriteGas.Location = new System.Drawing.Point(345, 123);
			this.buttonWriteGas.Name = "buttonWriteGas";
			this.buttonWriteGas.Size = new System.Drawing.Size(75, 23);
			this.buttonWriteGas.TabIndex = 17;
			this.buttonWriteGas.Text = "Write Gas";
			this.buttonWriteGas.UseVisualStyleBackColor = true;
			this.buttonWriteGas.Click += new System.EventHandler(this.buttonWriteGas_Click);
			// 
			// buttonReadMFCAll
			// 
			this.buttonReadMFCAll.Location = new System.Drawing.Point(345, 16);
			this.buttonReadMFCAll.Name = "buttonReadMFCAll";
			this.buttonReadMFCAll.Size = new System.Drawing.Size(75, 23);
			this.buttonReadMFCAll.TabIndex = 2;
			this.buttonReadMFCAll.Text = "Read All";
			this.buttonReadMFCAll.UseVisualStyleBackColor = true;
			this.buttonReadMFCAll.Click += new System.EventHandler(this.buttonReadAll_Click);
			// 
			// labelDiluent
			// 
			this.labelDiluent.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelDiluent.AutoSize = true;
			this.labelDiluent.Location = new System.Drawing.Point(226, 0);
			this.labelDiluent.Name = "labelDiluent";
			this.labelDiluent.Size = new System.Drawing.Size(40, 13);
			this.labelDiluent.TabIndex = 24;
			this.labelDiluent.Text = "Diluent";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 464);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(439, 22);
			this.statusStrip1.TabIndex = 4;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
			this.toolStripStatusLabel1.Text = "Ready";
			// 
			// groupBoxGasConcentration
			// 
			this.groupBoxGasConcentration.AutoSize = true;
			this.groupBoxGasConcentration.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxGasConcentration.Controls.Add(this.tableLayoutPanelGasConcentration);
			this.groupBoxGasConcentration.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxGasConcentration.Enabled = false;
			this.groupBoxGasConcentration.Location = new System.Drawing.Point(0, 312);
			this.groupBoxGasConcentration.Name = "groupBoxGasConcentration";
			this.groupBoxGasConcentration.Size = new System.Drawing.Size(439, 152);
			this.groupBoxGasConcentration.TabIndex = 5;
			this.groupBoxGasConcentration.TabStop = false;
			this.groupBoxGasConcentration.Text = "Gas Concentration";
			// 
			// tableLayoutPanelGasConcentration
			// 
			this.tableLayoutPanelGasConcentration.AutoSize = true;
			this.tableLayoutPanelGasConcentration.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelGasConcentration.ColumnCount = 5;
			this.tableLayoutPanelGasConcentration.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 185F));
			this.tableLayoutPanelGasConcentration.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelGasConcentration.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelGasConcentration.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelGasConcentration.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelGasConcentration.Controls.Add(this.labelGasConcentrationSetpoint, 0, 1);
			this.tableLayoutPanelGasConcentration.Controls.Add(this.labelUnitGasConcentrationSetpoint, 2, 1);
			this.tableLayoutPanelGasConcentration.Controls.Add(this.buttonWriteAll, 4, 1);
			this.tableLayoutPanelGasConcentration.Controls.Add(this.textBoxGasConcentrationSetpoint, 1, 1);
			this.tableLayoutPanelGasConcentration.Controls.Add(this.textBoxGasConcentration, 1, 0);
			this.tableLayoutPanelGasConcentration.Controls.Add(this.labelUnitGasConcentration, 2, 0);
			this.tableLayoutPanelGasConcentration.Controls.Add(this.labelConcentration, 0, 0);
			this.tableLayoutPanelGasConcentration.Controls.Add(this.buttonReadAll, 4, 0);
			this.tableLayoutPanelGasConcentration.Controls.Add(this.labelAnalyteBottleConcentration, 0, 3);
			this.tableLayoutPanelGasConcentration.Controls.Add(this.labelMassFlowSetpoint, 0, 2);
			this.tableLayoutPanelGasConcentration.Controls.Add(this.textBoxAnalyteBottleConcentration, 1, 3);
			this.tableLayoutPanelGasConcentration.Controls.Add(this.textBoxMassFlowSetpoint, 1, 2);
			this.tableLayoutPanelGasConcentration.Controls.Add(this.labelUnitAnalyteBottleConcentration, 2, 3);
			this.tableLayoutPanelGasConcentration.Controls.Add(this.labelUnitMassFlowSetpoint, 2, 2);
			this.tableLayoutPanelGasConcentration.Location = new System.Drawing.Point(12, 19);
			this.tableLayoutPanelGasConcentration.Name = "tableLayoutPanelGasConcentration";
			this.tableLayoutPanelGasConcentration.RowCount = 4;
			this.tableLayoutPanelGasConcentration.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelGasConcentration.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelGasConcentration.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelGasConcentration.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelGasConcentration.Size = new System.Drawing.Size(415, 110);
			this.tableLayoutPanelGasConcentration.TabIndex = 0;
			// 
			// labelGasConcentrationSetpoint
			// 
			this.labelGasConcentrationSetpoint.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelGasConcentrationSetpoint.AutoSize = true;
			this.labelGasConcentrationSetpoint.Location = new System.Drawing.Point(3, 37);
			this.labelGasConcentrationSetpoint.Name = "labelGasConcentrationSetpoint";
			this.labelGasConcentrationSetpoint.Size = new System.Drawing.Size(137, 13);
			this.labelGasConcentrationSetpoint.TabIndex = 3;
			this.labelGasConcentrationSetpoint.Text = "Gas Concentration Setpoint";
			// 
			// labelUnitGasConcentrationSetpoint
			// 
			this.labelUnitGasConcentrationSetpoint.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelUnitGasConcentrationSetpoint.AutoSize = true;
			this.labelUnitGasConcentrationSetpoint.Location = new System.Drawing.Point(294, 37);
			this.labelUnitGasConcentrationSetpoint.Name = "labelUnitGasConcentrationSetpoint";
			this.labelUnitGasConcentrationSetpoint.Size = new System.Drawing.Size(22, 13);
			this.labelUnitGasConcentrationSetpoint.TabIndex = 11;
			this.labelUnitGasConcentrationSetpoint.Text = "%V";
			// 
			// buttonWriteAll
			// 
			this.buttonWriteAll.Location = new System.Drawing.Point(337, 32);
			this.buttonWriteAll.Name = "buttonWriteAll";
			this.buttonWriteAll.Size = new System.Drawing.Size(75, 23);
			this.buttonWriteAll.TabIndex = 12;
			this.buttonWriteAll.Text = "Write All";
			this.buttonWriteAll.UseVisualStyleBackColor = true;
			this.buttonWriteAll.Click += new System.EventHandler(this.buttonWriteGasConcentrationSetpoint_Click);
			// 
			// textBoxGasConcentrationSetpoint
			// 
			this.textBoxGasConcentrationSetpoint.Location = new System.Drawing.Point(188, 32);
			this.textBoxGasConcentrationSetpoint.Name = "textBoxGasConcentrationSetpoint";
			this.textBoxGasConcentrationSetpoint.Size = new System.Drawing.Size(100, 20);
			this.textBoxGasConcentrationSetpoint.TabIndex = 0;
			// 
			// textBoxGasConcentration
			// 
			this.textBoxGasConcentration.Location = new System.Drawing.Point(188, 3);
			this.textBoxGasConcentration.Name = "textBoxGasConcentration";
			this.textBoxGasConcentration.ReadOnly = true;
			this.textBoxGasConcentration.Size = new System.Drawing.Size(100, 20);
			this.textBoxGasConcentration.TabIndex = 7;
			// 
			// labelUnitGasConcentration
			// 
			this.labelUnitGasConcentration.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelUnitGasConcentration.AutoSize = true;
			this.labelUnitGasConcentration.Location = new System.Drawing.Point(294, 8);
			this.labelUnitGasConcentration.Name = "labelUnitGasConcentration";
			this.labelUnitGasConcentration.Size = new System.Drawing.Size(22, 13);
			this.labelUnitGasConcentration.TabIndex = 8;
			this.labelUnitGasConcentration.Text = "%V";
			// 
			// labelConcentration
			// 
			this.labelConcentration.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelConcentration.AutoSize = true;
			this.labelConcentration.Location = new System.Drawing.Point(3, 8);
			this.labelConcentration.Name = "labelConcentration";
			this.labelConcentration.Size = new System.Drawing.Size(95, 13);
			this.labelConcentration.TabIndex = 0;
			this.labelConcentration.Text = "Gas Concentration";
			// 
			// buttonReadAll
			// 
			this.buttonReadAll.Location = new System.Drawing.Point(337, 3);
			this.buttonReadAll.Name = "buttonReadAll";
			this.buttonReadAll.Size = new System.Drawing.Size(75, 23);
			this.buttonReadAll.TabIndex = 14;
			this.buttonReadAll.Text = "Read All";
			this.buttonReadAll.UseVisualStyleBackColor = true;
			this.buttonReadAll.Click += new System.EventHandler(this.buttonReadConcentration_Click);
			// 
			// labelAnalyteBottleConcentration
			// 
			this.labelAnalyteBottleConcentration.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelAnalyteBottleConcentration.AutoSize = true;
			this.labelAnalyteBottleConcentration.Location = new System.Drawing.Point(3, 90);
			this.labelAnalyteBottleConcentration.Name = "labelAnalyteBottleConcentration";
			this.labelAnalyteBottleConcentration.Size = new System.Drawing.Size(141, 13);
			this.labelAnalyteBottleConcentration.TabIndex = 1;
			this.labelAnalyteBottleConcentration.Text = "Analyte Bottle Concentration";
			// 
			// labelMassFlowSetpoint
			// 
			this.labelMassFlowSetpoint.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelMassFlowSetpoint.AutoSize = true;
			this.labelMassFlowSetpoint.Location = new System.Drawing.Point(3, 64);
			this.labelMassFlowSetpoint.Name = "labelMassFlowSetpoint";
			this.labelMassFlowSetpoint.Size = new System.Drawing.Size(132, 13);
			this.labelMassFlowSetpoint.TabIndex = 2;
			this.labelMassFlowSetpoint.Text = "(Total) Mass Flow Setpoint";
			// 
			// textBoxAnalyteBottleConcentration
			// 
			this.textBoxAnalyteBottleConcentration.Location = new System.Drawing.Point(188, 87);
			this.textBoxAnalyteBottleConcentration.Name = "textBoxAnalyteBottleConcentration";
			this.textBoxAnalyteBottleConcentration.Size = new System.Drawing.Size(100, 20);
			this.textBoxAnalyteBottleConcentration.TabIndex = 5;
			// 
			// textBoxMassFlowSetpoint
			// 
			this.textBoxMassFlowSetpoint.Location = new System.Drawing.Point(188, 61);
			this.textBoxMassFlowSetpoint.Name = "textBoxMassFlowSetpoint";
			this.textBoxMassFlowSetpoint.Size = new System.Drawing.Size(100, 20);
			this.textBoxMassFlowSetpoint.TabIndex = 4;
			// 
			// labelUnitAnalyteBottleConcentration
			// 
			this.labelUnitAnalyteBottleConcentration.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelUnitAnalyteBottleConcentration.AutoSize = true;
			this.labelUnitAnalyteBottleConcentration.Location = new System.Drawing.Point(294, 90);
			this.labelUnitAnalyteBottleConcentration.Name = "labelUnitAnalyteBottleConcentration";
			this.labelUnitAnalyteBottleConcentration.Size = new System.Drawing.Size(22, 13);
			this.labelUnitAnalyteBottleConcentration.TabIndex = 9;
			this.labelUnitAnalyteBottleConcentration.Text = "%V";
			// 
			// labelUnitMassFlowSetpoint
			// 
			this.labelUnitMassFlowSetpoint.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelUnitMassFlowSetpoint.AutoSize = true;
			this.labelUnitMassFlowSetpoint.Location = new System.Drawing.Point(294, 64);
			this.labelUnitMassFlowSetpoint.Name = "labelUnitMassFlowSetpoint";
			this.labelUnitMassFlowSetpoint.Size = new System.Drawing.Size(37, 13);
			this.labelUnitMassFlowSetpoint.TabIndex = 10;
			this.labelUnitMassFlowSetpoint.Text = "SCCM";
			// 
			// FormGasMixer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(439, 486);
			this.Controls.Add(this.groupBoxGasConcentration);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.groupBoxMassFlow);
			this.Controls.Add(this.groupBoxSerialPorts);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FormGasMixer";
			this.Text = "Gas Mix Utility";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormGasConcentration_FormClosed);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.groupBoxSerialPorts.ResumeLayout(false);
			this.groupBoxSerialPorts.PerformLayout();
			this.groupBoxMassFlow.ResumeLayout(false);
			this.groupBoxMassFlow.PerformLayout();
			this.tableLayoutPanelMassFlow.ResumeLayout(false);
			this.tableLayoutPanelMassFlow.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.groupBoxGasConcentration.ResumeLayout(false);
			this.groupBoxGasConcentration.PerformLayout();
			this.tableLayoutPanelGasConcentration.ResumeLayout(false);
			this.tableLayoutPanelGasConcentration.PerformLayout();
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
		private System.Windows.Forms.ComboBox comboBoxAnalytePort;
		private System.Windows.Forms.ComboBox comboBoxDiluentPort;
		private System.Windows.Forms.GroupBox groupBoxMassFlow;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMassFlow;
		private System.Windows.Forms.Label labelPressure;
		private System.Windows.Forms.Label labelTemperature;
		private System.Windows.Forms.TextBox textBoxAnalytePressure;
		private System.Windows.Forms.TextBox textBoxAnalyteTemperature;
		private System.Windows.Forms.Label labelVolumetricFlow;
		private System.Windows.Forms.TextBox textBoxAnalyteVolumetricFlow;
		private System.Windows.Forms.Label labelMassFlow;
		private System.Windows.Forms.TextBox textBoxAnalyteMassFlow;
		private System.Windows.Forms.Button buttonReadMFCAll;
		private System.Windows.Forms.Label labelUnitPressure;
		private System.Windows.Forms.Label labelUnitTemperature;
		private System.Windows.Forms.Label labelUnitVolumetricFlow;
		private System.Windows.Forms.Label labelUnitMassFlow;
		private System.Windows.Forms.Label labelSetpoint;
		private System.Windows.Forms.TextBox textBoxAnalyteSetpoint;
		private System.Windows.Forms.Label labelUnitSetpoint;
		private System.Windows.Forms.Label labelGas;
		private System.Windows.Forms.ComboBox comboBoxAnalyteGas;
		private System.Windows.Forms.Button buttonWriteSP;
		private System.Windows.Forms.Button buttonWriteGas;
		private System.Windows.Forms.Label labelDiluentPort;
		private System.Windows.Forms.Label labelAnalytePort;
		private System.Windows.Forms.TextBox textBoxDiluentSetpoint;
		private System.Windows.Forms.TextBox textBoxDiluentPressure;
		private System.Windows.Forms.TextBox textBoxDiluentTemperature;
		private System.Windows.Forms.TextBox textBoxDiluentVolumetricFlow;
		private System.Windows.Forms.TextBox textBoxDiluentMassFlow;
		private System.Windows.Forms.ComboBox comboBoxDiluentGas;
		private System.Windows.Forms.Label labelAnalyte;
		private System.Windows.Forms.Label labelDiluent;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.GroupBox groupBoxGasConcentration;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGasConcentration;
		private System.Windows.Forms.Label labelConcentration;
		private System.Windows.Forms.Label labelAnalyteBottleConcentration;
		private System.Windows.Forms.Label labelMassFlowSetpoint;
		private System.Windows.Forms.Label labelGasConcentrationSetpoint;
		private System.Windows.Forms.TextBox textBoxMassFlowSetpoint;
		private System.Windows.Forms.TextBox textBoxAnalyteBottleConcentration;
		private System.Windows.Forms.TextBox textBoxGasConcentrationSetpoint;
		private System.Windows.Forms.TextBox textBoxGasConcentration;
		private System.Windows.Forms.Label labelUnitGasConcentration;
		private System.Windows.Forms.Label labelUnitAnalyteBottleConcentration;
		private System.Windows.Forms.Label labelUnitMassFlowSetpoint;
		private System.Windows.Forms.Label labelUnitGasConcentrationSetpoint;
		private System.Windows.Forms.Button buttonWriteAll;
		private System.Windows.Forms.Button buttonReadAll;
	}
}

