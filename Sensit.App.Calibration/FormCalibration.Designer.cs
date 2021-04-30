namespace Sensit.App.Calibration
{
	partial class FormCalibration
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
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageDevices = new System.Windows.Forms.TabPage();
			this.groupBoxDevices = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanelDevices = new System.Windows.Forms.TableLayoutPanel();
			this.labelDeviceName = new System.Windows.Forms.Label();
			this.labelDeviceType = new System.Windows.Forms.Label();
			this.labelDeviceSerialPort = new System.Windows.Forms.Label();
			this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
			this.checkBoxDeviceSelectAll = new System.Windows.Forms.CheckBox();
			this.buttonDeviceDelete = new System.Windows.Forms.Button();
			this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
			this.buttonDeviceAdd = new System.Windows.Forms.Button();
			this.comboBoxDeviceType = new System.Windows.Forms.ComboBox();
			this.textBoxDeviceName = new System.Windows.Forms.TextBox();
			this.tabPageEvents = new System.Windows.Forms.TabPage();
			this.groupBoxEvents = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanelEvents = new System.Windows.Forms.TableLayoutPanel();
			this.labelEventDevice = new System.Windows.Forms.Label();
			this.labelEventVariable = new System.Windows.Forms.Label();
			this.labelEventValue = new System.Windows.Forms.Label();
			this.labelEventDuration = new System.Windows.Forms.Label();
			this.labelEventStatus = new System.Windows.Forms.Label();
			this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
			this.checkBoxEventSelectAll = new System.Windows.Forms.CheckBox();
			this.buttonEventDelete = new System.Windows.Forms.Button();
			this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
			this.comboBoxEventDevice = new System.Windows.Forms.ComboBox();
			this.buttonEventAdd = new System.Windows.Forms.Button();
			this.numericUpDownEventDuration = new System.Windows.Forms.NumericUpDown();
			this.comboBoxEventVariable = new System.Windows.Forms.ComboBox();
			this.numericUpDownEventValue = new System.Windows.Forms.NumericUpDown();
			this.tabPageLog = new System.Windows.Forms.TabPage();
			this.groupBoxLog = new System.Windows.Forms.GroupBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.textBoxLogFilename = new System.Windows.Forms.TextBox();
			this.buttonLogBrowse = new System.Windows.Forms.Button();
			this.tabPageStatus = new System.Windows.Forms.TabPage();
			this.groupBoxVariables = new System.Windows.Forms.GroupBox();
			this.flowLayoutPanelControlledVariables = new System.Windows.Forms.FlowLayoutPanel();
			this.groupBoxMassFlow = new System.Windows.Forms.GroupBox();
			this.labelVar1Unit2 = new System.Windows.Forms.Label();
			this.labelVar1Unit1 = new System.Windows.Forms.Label();
			this.textBoxMassFlowValue = new System.Windows.Forms.TextBox();
			this.textBoxMassFlowSetpoint = new System.Windows.Forms.TextBox();
			this.groupBoxVolumeFlow = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxVolumeFlowValue = new System.Windows.Forms.TextBox();
			this.textBoxVolumeFlowSetpoint = new System.Windows.Forms.TextBox();
			this.groupBoxVelocity = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxVelocityValue = new System.Windows.Forms.TextBox();
			this.textBoxVelocitySetpoint = new System.Windows.Forms.TextBox();
			this.groupBoxPressure = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.textBoxPressureValue = new System.Windows.Forms.TextBox();
			this.textBoxPressureSetpoint = new System.Windows.Forms.TextBox();
			this.groupBoxTemperature = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.textBoxTempValue = new System.Windows.Forms.TextBox();
			this.textBoxTempSetpoint = new System.Windows.Forms.TextBox();
			this.groupBoxCurrent = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.textBoxCurrentValue = new System.Windows.Forms.TextBox();
			this.textBoxCurrentSetpoint = new System.Windows.Forms.TextBox();
			this.groupBoxVoltage = new System.Windows.Forms.GroupBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.textBoxVoltageValue = new System.Windows.Forms.TextBox();
			this.textBoxVoltageSetpoint = new System.Windows.Forms.TextBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.supportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpProvider1 = new System.Windows.Forms.HelpProvider();
			this.buttonStart = new System.Windows.Forms.Button();
			this.buttonStop = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.tableLayoutPanelTest = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanelTestSetupButtons = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.labelRepeat = new System.Windows.Forms.Label();
			this.tableLayoutPanelRepeat = new System.Windows.Forms.TableLayoutPanel();
			this.radioButtonRepeatNo = new System.Windows.Forms.RadioButton();
			this.radioButtonRepeatYes = new System.Windows.Forms.RadioButton();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tabControl.SuspendLayout();
			this.tabPageDevices.SuspendLayout();
			this.groupBoxDevices.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.tableLayoutPanelDevices.SuspendLayout();
			this.tableLayoutPanel6.SuspendLayout();
			this.tableLayoutPanel11.SuspendLayout();
			this.tabPageEvents.SuspendLayout();
			this.groupBoxEvents.SuspendLayout();
			this.tableLayoutPanel7.SuspendLayout();
			this.tableLayoutPanelEvents.SuspendLayout();
			this.tableLayoutPanel9.SuspendLayout();
			this.tableLayoutPanel10.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownEventDuration)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownEventValue)).BeginInit();
			this.tabPageLog.SuspendLayout();
			this.groupBoxLog.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tabPageStatus.SuspendLayout();
			this.groupBoxVariables.SuspendLayout();
			this.flowLayoutPanelControlledVariables.SuspendLayout();
			this.groupBoxMassFlow.SuspendLayout();
			this.groupBoxVolumeFlow.SuspendLayout();
			this.groupBoxVelocity.SuspendLayout();
			this.groupBoxPressure.SuspendLayout();
			this.groupBoxTemperature.SuspendLayout();
			this.groupBoxCurrent.SuspendLayout();
			this.groupBoxVoltage.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.tableLayoutPanelTest.SuspendLayout();
			this.tableLayoutPanelTestSetupButtons.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tableLayoutPanelRepeat.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPageDevices);
			this.tabControl.Controls.Add(this.tabPageEvents);
			this.tabControl.Controls.Add(this.tabPageLog);
			this.tabControl.Controls.Add(this.tabPageStatus);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(4, 4);
			this.tabControl.Margin = new System.Windows.Forms.Padding(4);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(574, 330);
			this.tabControl.TabIndex = 0;
			// 
			// tabPageDevices
			// 
			this.tabPageDevices.Controls.Add(this.groupBoxDevices);
			this.tabPageDevices.Location = new System.Drawing.Point(4, 25);
			this.tabPageDevices.Margin = new System.Windows.Forms.Padding(4);
			this.tabPageDevices.Name = "tabPageDevices";
			this.tabPageDevices.Padding = new System.Windows.Forms.Padding(4);
			this.tabPageDevices.Size = new System.Drawing.Size(566, 301);
			this.tabPageDevices.TabIndex = 6;
			this.tabPageDevices.Text = "Devices";
			this.tabPageDevices.UseVisualStyleBackColor = true;
			// 
			// groupBoxDevices
			// 
			this.groupBoxDevices.AutoSize = true;
			this.groupBoxDevices.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxDevices.Controls.Add(this.tableLayoutPanel4);
			this.groupBoxDevices.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxDevices.Location = new System.Drawing.Point(4, 4);
			this.groupBoxDevices.Margin = new System.Windows.Forms.Padding(4);
			this.groupBoxDevices.Name = "groupBoxDevices";
			this.groupBoxDevices.Padding = new System.Windows.Forms.Padding(4);
			this.groupBoxDevices.Size = new System.Drawing.Size(558, 293);
			this.groupBoxDevices.TabIndex = 18;
			this.groupBoxDevices.TabStop = false;
			this.groupBoxDevices.Text = "What equipment does the test use?";
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.ColumnCount = 1;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanelDevices, 0, 0);
			this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 0, 2);
			this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel11, 0, 1);
			this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 19);
			this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 3;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(550, 270);
			this.tableLayoutPanel4.TabIndex = 19;
			// 
			// tableLayoutPanelDevices
			// 
			this.tableLayoutPanelDevices.AutoScroll = true;
			this.tableLayoutPanelDevices.AutoSize = true;
			this.tableLayoutPanelDevices.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelDevices.ColumnCount = 3;
			this.tableLayoutPanelDevices.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanelDevices.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
			this.tableLayoutPanelDevices.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
			this.tableLayoutPanelDevices.Controls.Add(this.labelDeviceName, 0, 0);
			this.tableLayoutPanelDevices.Controls.Add(this.labelDeviceType, 1, 0);
			this.tableLayoutPanelDevices.Controls.Add(this.labelDeviceSerialPort, 2, 0);
			this.tableLayoutPanelDevices.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelDevices.Location = new System.Drawing.Point(4, 4);
			this.tableLayoutPanelDevices.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanelDevices.Name = "tableLayoutPanelDevices";
			this.tableLayoutPanelDevices.RowCount = 1;
			this.tableLayoutPanelDevices.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelDevices.Size = new System.Drawing.Size(542, 175);
			this.tableLayoutPanelDevices.TabIndex = 6;
			// 
			// labelDeviceName
			// 
			this.labelDeviceName.AutoSize = true;
			this.labelDeviceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDeviceName.Location = new System.Drawing.Point(4, 0);
			this.labelDeviceName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelDeviceName.Name = "labelDeviceName";
			this.labelDeviceName.Size = new System.Drawing.Size(49, 17);
			this.labelDeviceName.TabIndex = 1;
			this.labelDeviceName.Text = "Name";
			// 
			// labelDeviceType
			// 
			this.labelDeviceType.AutoSize = true;
			this.labelDeviceType.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDeviceType.Location = new System.Drawing.Point(184, 0);
			this.labelDeviceType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelDeviceType.Name = "labelDeviceType";
			this.labelDeviceType.Size = new System.Drawing.Size(44, 17);
			this.labelDeviceType.TabIndex = 2;
			this.labelDeviceType.Text = "Type";
			// 
			// labelDeviceSerialPort
			// 
			this.labelDeviceSerialPort.AutoSize = true;
			this.labelDeviceSerialPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDeviceSerialPort.Location = new System.Drawing.Point(364, 0);
			this.labelDeviceSerialPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelDeviceSerialPort.Name = "labelDeviceSerialPort";
			this.labelDeviceSerialPort.Size = new System.Drawing.Size(85, 17);
			this.labelDeviceSerialPort.TabIndex = 3;
			this.labelDeviceSerialPort.Text = "Serial Port";
			// 
			// tableLayoutPanel6
			// 
			this.tableLayoutPanel6.AutoSize = true;
			this.tableLayoutPanel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel6.ColumnCount = 2;
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel6.Controls.Add(this.checkBoxDeviceSelectAll, 0, 0);
			this.tableLayoutPanel6.Controls.Add(this.buttonDeviceDelete, 1, 0);
			this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel6.Location = new System.Drawing.Point(4, 231);
			this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanel6.Name = "tableLayoutPanel6";
			this.tableLayoutPanel6.RowCount = 1;
			this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
			this.tableLayoutPanel6.Size = new System.Drawing.Size(542, 35);
			this.tableLayoutPanel6.TabIndex = 19;
			// 
			// checkBoxDeviceSelectAll
			// 
			this.checkBoxDeviceSelectAll.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.checkBoxDeviceSelectAll.AutoSize = true;
			this.checkBoxDeviceSelectAll.Location = new System.Drawing.Point(4, 7);
			this.checkBoxDeviceSelectAll.Margin = new System.Windows.Forms.Padding(4);
			this.checkBoxDeviceSelectAll.Name = "checkBoxDeviceSelectAll";
			this.checkBoxDeviceSelectAll.Size = new System.Drawing.Size(88, 21);
			this.checkBoxDeviceSelectAll.TabIndex = 0;
			this.checkBoxDeviceSelectAll.Text = "Select All";
			this.checkBoxDeviceSelectAll.UseVisualStyleBackColor = true;
			this.checkBoxDeviceSelectAll.CheckedChanged += new System.EventHandler(this.CheckBoxDeviceSelectAll_CheckedChanged);
			// 
			// buttonDeviceDelete
			// 
			this.buttonDeviceDelete.AutoSize = true;
			this.buttonDeviceDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonDeviceDelete.Location = new System.Drawing.Point(365, 4);
			this.buttonDeviceDelete.Margin = new System.Windows.Forms.Padding(4);
			this.buttonDeviceDelete.Name = "buttonDeviceDelete";
			this.buttonDeviceDelete.Size = new System.Drawing.Size(172, 27);
			this.buttonDeviceDelete.TabIndex = 1;
			this.buttonDeviceDelete.Text = "Delete Selected Devices";
			this.buttonDeviceDelete.UseVisualStyleBackColor = true;
			this.buttonDeviceDelete.Click += new System.EventHandler(this.ButtonDeviceDelete_Click);
			// 
			// tableLayoutPanel11
			// 
			this.tableLayoutPanel11.AutoSize = true;
			this.tableLayoutPanel11.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel11.ColumnCount = 3;
			this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
			this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
			this.tableLayoutPanel11.Controls.Add(this.buttonDeviceAdd, 2, 0);
			this.tableLayoutPanel11.Controls.Add(this.comboBoxDeviceType, 1, 0);
			this.tableLayoutPanel11.Controls.Add(this.textBoxDeviceName, 0, 0);
			this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel11.Location = new System.Drawing.Point(4, 187);
			this.tableLayoutPanel11.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanel11.Name = "tableLayoutPanel11";
			this.tableLayoutPanel11.RowCount = 1;
			this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
			this.tableLayoutPanel11.Size = new System.Drawing.Size(542, 36);
			this.tableLayoutPanel11.TabIndex = 20;
			// 
			// buttonDeviceAdd
			// 
			this.buttonDeviceAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonDeviceAdd.Location = new System.Drawing.Point(364, 4);
			this.buttonDeviceAdd.Margin = new System.Windows.Forms.Padding(4);
			this.buttonDeviceAdd.Name = "buttonDeviceAdd";
			this.buttonDeviceAdd.Size = new System.Drawing.Size(100, 28);
			this.buttonDeviceAdd.TabIndex = 2;
			this.buttonDeviceAdd.Text = "Add Device";
			this.buttonDeviceAdd.UseVisualStyleBackColor = true;
			this.buttonDeviceAdd.Click += new System.EventHandler(this.ButtonDeviceAdd_Click);
			// 
			// comboBoxDeviceType
			// 
			this.comboBoxDeviceType.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboBoxDeviceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxDeviceType.Location = new System.Drawing.Point(184, 4);
			this.comboBoxDeviceType.Margin = new System.Windows.Forms.Padding(4);
			this.comboBoxDeviceType.Name = "comboBoxDeviceType";
			this.comboBoxDeviceType.Size = new System.Drawing.Size(172, 24);
			this.comboBoxDeviceType.TabIndex = 0;
			// 
			// textBoxDeviceName
			// 
			this.textBoxDeviceName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxDeviceName.Location = new System.Drawing.Point(4, 4);
			this.textBoxDeviceName.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxDeviceName.Name = "textBoxDeviceName";
			this.textBoxDeviceName.Size = new System.Drawing.Size(172, 22);
			this.textBoxDeviceName.TabIndex = 3;
			// 
			// tabPageEvents
			// 
			this.tabPageEvents.Controls.Add(this.groupBoxEvents);
			this.tabPageEvents.Location = new System.Drawing.Point(4, 25);
			this.tabPageEvents.Margin = new System.Windows.Forms.Padding(4);
			this.tabPageEvents.Name = "tabPageEvents";
			this.tabPageEvents.Padding = new System.Windows.Forms.Padding(4);
			this.tabPageEvents.Size = new System.Drawing.Size(566, 301);
			this.tabPageEvents.TabIndex = 2;
			this.tabPageEvents.Text = "Events";
			this.tabPageEvents.UseVisualStyleBackColor = true;
			// 
			// groupBoxEvents
			// 
			this.groupBoxEvents.AutoSize = true;
			this.groupBoxEvents.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxEvents.Controls.Add(this.tableLayoutPanel7);
			this.groupBoxEvents.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxEvents.Location = new System.Drawing.Point(4, 4);
			this.groupBoxEvents.Margin = new System.Windows.Forms.Padding(4);
			this.groupBoxEvents.Name = "groupBoxEvents";
			this.groupBoxEvents.Padding = new System.Windows.Forms.Padding(4);
			this.groupBoxEvents.Size = new System.Drawing.Size(558, 293);
			this.groupBoxEvents.TabIndex = 17;
			this.groupBoxEvents.TabStop = false;
			this.groupBoxEvents.Text = "What should the equipment do?";
			// 
			// tableLayoutPanel7
			// 
			this.tableLayoutPanel7.ColumnCount = 1;
			this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanelEvents, 0, 0);
			this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel9, 0, 2);
			this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel10, 0, 1);
			this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel7.Location = new System.Drawing.Point(4, 19);
			this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanel7.Name = "tableLayoutPanel7";
			this.tableLayoutPanel7.RowCount = 3;
			this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel7.Size = new System.Drawing.Size(550, 270);
			this.tableLayoutPanel7.TabIndex = 19;
			// 
			// tableLayoutPanelEvents
			// 
			this.tableLayoutPanelEvents.AutoScroll = true;
			this.tableLayoutPanelEvents.AutoSize = true;
			this.tableLayoutPanelEvents.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelEvents.ColumnCount = 5;
			this.tableLayoutPanelEvents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanelEvents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanelEvents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanelEvents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanelEvents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanelEvents.Controls.Add(this.labelEventDevice, 0, 0);
			this.tableLayoutPanelEvents.Controls.Add(this.labelEventVariable, 1, 0);
			this.tableLayoutPanelEvents.Controls.Add(this.labelEventValue, 2, 0);
			this.tableLayoutPanelEvents.Controls.Add(this.labelEventDuration, 3, 0);
			this.tableLayoutPanelEvents.Controls.Add(this.labelEventStatus, 4, 0);
			this.tableLayoutPanelEvents.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelEvents.Location = new System.Drawing.Point(4, 4);
			this.tableLayoutPanelEvents.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanelEvents.Name = "tableLayoutPanelEvents";
			this.tableLayoutPanelEvents.RowCount = 1;
			this.tableLayoutPanelEvents.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelEvents.Size = new System.Drawing.Size(542, 175);
			this.tableLayoutPanelEvents.TabIndex = 6;
			// 
			// labelEventDevice
			// 
			this.labelEventDevice.AutoSize = true;
			this.labelEventDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelEventDevice.Location = new System.Drawing.Point(4, 0);
			this.labelEventDevice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelEventDevice.Name = "labelEventDevice";
			this.labelEventDevice.Size = new System.Drawing.Size(57, 17);
			this.labelEventDevice.TabIndex = 1;
			this.labelEventDevice.Text = "Device";
			// 
			// labelEventVariable
			// 
			this.labelEventVariable.AutoSize = true;
			this.labelEventVariable.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelEventVariable.Location = new System.Drawing.Point(112, 0);
			this.labelEventVariable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelEventVariable.Name = "labelEventVariable";
			this.labelEventVariable.Size = new System.Drawing.Size(68, 17);
			this.labelEventVariable.TabIndex = 2;
			this.labelEventVariable.Text = "Variable";
			// 
			// labelEventValue
			// 
			this.labelEventValue.AutoSize = true;
			this.labelEventValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelEventValue.Location = new System.Drawing.Point(220, 0);
			this.labelEventValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelEventValue.Name = "labelEventValue";
			this.labelEventValue.Size = new System.Drawing.Size(49, 17);
			this.labelEventValue.TabIndex = 3;
			this.labelEventValue.Text = "Value";
			// 
			// labelEventDuration
			// 
			this.labelEventDuration.AutoSize = true;
			this.labelEventDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelEventDuration.Location = new System.Drawing.Point(328, 0);
			this.labelEventDuration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelEventDuration.Name = "labelEventDuration";
			this.labelEventDuration.Size = new System.Drawing.Size(93, 17);
			this.labelEventDuration.TabIndex = 4;
			this.labelEventDuration.Text = "Duration [s]";
			// 
			// labelEventStatus
			// 
			this.labelEventStatus.AutoSize = true;
			this.labelEventStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelEventStatus.Location = new System.Drawing.Point(436, 0);
			this.labelEventStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelEventStatus.Name = "labelEventStatus";
			this.labelEventStatus.Size = new System.Drawing.Size(54, 17);
			this.labelEventStatus.TabIndex = 5;
			this.labelEventStatus.Text = "Status";
			// 
			// tableLayoutPanel9
			// 
			this.tableLayoutPanel9.AutoSize = true;
			this.tableLayoutPanel9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel9.ColumnCount = 2;
			this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
			this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel9.Controls.Add(this.checkBoxEventSelectAll, 0, 0);
			this.tableLayoutPanel9.Controls.Add(this.buttonEventDelete, 1, 0);
			this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel9.Location = new System.Drawing.Point(4, 231);
			this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanel9.Name = "tableLayoutPanel9";
			this.tableLayoutPanel9.RowCount = 1;
			this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
			this.tableLayoutPanel9.Size = new System.Drawing.Size(542, 35);
			this.tableLayoutPanel9.TabIndex = 19;
			// 
			// checkBoxEventSelectAll
			// 
			this.checkBoxEventSelectAll.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.checkBoxEventSelectAll.AutoSize = true;
			this.checkBoxEventSelectAll.Location = new System.Drawing.Point(4, 7);
			this.checkBoxEventSelectAll.Margin = new System.Windows.Forms.Padding(4);
			this.checkBoxEventSelectAll.Name = "checkBoxEventSelectAll";
			this.checkBoxEventSelectAll.Size = new System.Drawing.Size(88, 21);
			this.checkBoxEventSelectAll.TabIndex = 0;
			this.checkBoxEventSelectAll.Text = "Select All";
			this.checkBoxEventSelectAll.UseVisualStyleBackColor = true;
			this.checkBoxEventSelectAll.CheckedChanged += new System.EventHandler(this.CheckBoxEventSelectAll_CheckedChanged);
			// 
			// buttonEventDelete
			// 
			this.buttonEventDelete.AutoSize = true;
			this.buttonEventDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonEventDelete.Location = new System.Drawing.Point(365, 4);
			this.buttonEventDelete.Margin = new System.Windows.Forms.Padding(4);
			this.buttonEventDelete.Name = "buttonEventDelete";
			this.buttonEventDelete.Size = new System.Drawing.Size(165, 27);
			this.buttonEventDelete.TabIndex = 1;
			this.buttonEventDelete.Text = "Delete Selected Events";
			this.buttonEventDelete.UseVisualStyleBackColor = true;
			this.buttonEventDelete.Click += new System.EventHandler(this.ButtonEventDelete_Click);
			// 
			// tableLayoutPanel10
			// 
			this.tableLayoutPanel10.AutoSize = true;
			this.tableLayoutPanel10.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel10.ColumnCount = 5;
			this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel10.Controls.Add(this.comboBoxEventDevice, 0, 0);
			this.tableLayoutPanel10.Controls.Add(this.buttonEventAdd, 4, 0);
			this.tableLayoutPanel10.Controls.Add(this.numericUpDownEventDuration, 3, 0);
			this.tableLayoutPanel10.Controls.Add(this.comboBoxEventVariable, 1, 0);
			this.tableLayoutPanel10.Controls.Add(this.numericUpDownEventValue, 2, 0);
			this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel10.Location = new System.Drawing.Point(4, 187);
			this.tableLayoutPanel10.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanel10.Name = "tableLayoutPanel10";
			this.tableLayoutPanel10.RowCount = 1;
			this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel10.Size = new System.Drawing.Size(542, 36);
			this.tableLayoutPanel10.TabIndex = 20;
			// 
			// comboBoxEventDevice
			// 
			this.comboBoxEventDevice.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboBoxEventDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxEventDevice.FormattingEnabled = true;
			this.comboBoxEventDevice.Location = new System.Drawing.Point(4, 4);
			this.comboBoxEventDevice.Margin = new System.Windows.Forms.Padding(4);
			this.comboBoxEventDevice.Name = "comboBoxEventDevice";
			this.comboBoxEventDevice.Size = new System.Drawing.Size(100, 24);
			this.comboBoxEventDevice.TabIndex = 3;
			// 
			// buttonEventAdd
			// 
			this.buttonEventAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonEventAdd.Location = new System.Drawing.Point(436, 4);
			this.buttonEventAdd.Margin = new System.Windows.Forms.Padding(4);
			this.buttonEventAdd.Name = "buttonEventAdd";
			this.buttonEventAdd.Size = new System.Drawing.Size(100, 28);
			this.buttonEventAdd.TabIndex = 2;
			this.buttonEventAdd.Text = "Add Event";
			this.buttonEventAdd.UseVisualStyleBackColor = true;
			this.buttonEventAdd.Click += new System.EventHandler(this.ButtonEventAdd_Click);
			// 
			// numericUpDownEventDuration
			// 
			this.numericUpDownEventDuration.Dock = System.Windows.Forms.DockStyle.Fill;
			this.numericUpDownEventDuration.Increment = new decimal(new int[] {
            60,
            0,
            0,
            0});
			this.numericUpDownEventDuration.Location = new System.Drawing.Point(328, 4);
			this.numericUpDownEventDuration.Margin = new System.Windows.Forms.Padding(4);
			this.numericUpDownEventDuration.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
			this.numericUpDownEventDuration.Name = "numericUpDownEventDuration";
			this.numericUpDownEventDuration.Size = new System.Drawing.Size(100, 22);
			this.numericUpDownEventDuration.TabIndex = 5;
			// 
			// comboBoxEventVariable
			// 
			this.comboBoxEventVariable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboBoxEventVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxEventVariable.FormattingEnabled = true;
			this.comboBoxEventVariable.Location = new System.Drawing.Point(112, 4);
			this.comboBoxEventVariable.Margin = new System.Windows.Forms.Padding(4);
			this.comboBoxEventVariable.Name = "comboBoxEventVariable";
			this.comboBoxEventVariable.Size = new System.Drawing.Size(100, 24);
			this.comboBoxEventVariable.TabIndex = 4;
			// 
			// numericUpDownEventValue
			// 
			this.numericUpDownEventValue.DecimalPlaces = 2;
			this.numericUpDownEventValue.Dock = System.Windows.Forms.DockStyle.Fill;
			this.numericUpDownEventValue.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.numericUpDownEventValue.Location = new System.Drawing.Point(220, 4);
			this.numericUpDownEventValue.Margin = new System.Windows.Forms.Padding(4);
			this.numericUpDownEventValue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDownEventValue.Name = "numericUpDownEventValue";
			this.numericUpDownEventValue.Size = new System.Drawing.Size(100, 22);
			this.numericUpDownEventValue.TabIndex = 6;
			// 
			// tabPageLog
			// 
			this.tabPageLog.Controls.Add(this.groupBoxLog);
			this.tabPageLog.Location = new System.Drawing.Point(4, 25);
			this.tabPageLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPageLog.Name = "tabPageLog";
			this.tabPageLog.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPageLog.Size = new System.Drawing.Size(566, 301);
			this.tabPageLog.TabIndex = 7;
			this.tabPageLog.Text = "Log";
			this.tabPageLog.UseVisualStyleBackColor = true;
			// 
			// groupBoxLog
			// 
			this.groupBoxLog.AutoSize = true;
			this.groupBoxLog.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxLog.Controls.Add(this.groupBox1);
			this.groupBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxLog.Location = new System.Drawing.Point(3, 2);
			this.groupBoxLog.Margin = new System.Windows.Forms.Padding(4);
			this.groupBoxLog.Name = "groupBoxLog";
			this.groupBoxLog.Padding = new System.Windows.Forms.Padding(4);
			this.groupBoxLog.Size = new System.Drawing.Size(560, 297);
			this.groupBoxLog.TabIndex = 17;
			this.groupBoxLog.TabStop = false;
			this.groupBoxLog.Text = "Where should results be saved?";
			// 
			// groupBox1
			// 
			this.groupBox1.AutoSize = true;
			this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBox1.Controls.Add(this.tableLayoutPanel1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(4, 19);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox1.Size = new System.Drawing.Size(552, 59);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Filename";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.textBoxLogFilename, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.buttonLogBrowse, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 19);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(544, 36);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// textBoxLogFilename
			// 
			this.textBoxLogFilename.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxLogFilename.Location = new System.Drawing.Point(4, 4);
			this.textBoxLogFilename.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxLogFilename.Name = "textBoxLogFilename";
			this.textBoxLogFilename.Size = new System.Drawing.Size(428, 22);
			this.textBoxLogFilename.TabIndex = 9;
			this.textBoxLogFilename.TextChanged += new System.EventHandler(this.TextBoxLogFilename_TextChanged);
			// 
			// buttonLogBrowse
			// 
			this.buttonLogBrowse.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.buttonLogBrowse.Location = new System.Drawing.Point(440, 4);
			this.buttonLogBrowse.Margin = new System.Windows.Forms.Padding(4);
			this.buttonLogBrowse.Name = "buttonLogBrowse";
			this.buttonLogBrowse.Size = new System.Drawing.Size(100, 28);
			this.buttonLogBrowse.TabIndex = 2;
			this.buttonLogBrowse.Text = "Browse";
			this.buttonLogBrowse.UseVisualStyleBackColor = true;
			this.buttonLogBrowse.Click += new System.EventHandler(this.ButtonLogBrowse_Click);
			// 
			// tabPageStatus
			// 
			this.tabPageStatus.Controls.Add(this.groupBoxVariables);
			this.tabPageStatus.Location = new System.Drawing.Point(4, 25);
			this.tabPageStatus.Margin = new System.Windows.Forms.Padding(4);
			this.tabPageStatus.Name = "tabPageStatus";
			this.tabPageStatus.Padding = new System.Windows.Forms.Padding(4);
			this.tabPageStatus.Size = new System.Drawing.Size(566, 301);
			this.tabPageStatus.TabIndex = 4;
			this.tabPageStatus.Text = "Status";
			this.tabPageStatus.UseVisualStyleBackColor = true;
			// 
			// groupBoxVariables
			// 
			this.groupBoxVariables.Controls.Add(this.flowLayoutPanelControlledVariables);
			this.groupBoxVariables.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxVariables.Location = new System.Drawing.Point(4, 4);
			this.groupBoxVariables.Margin = new System.Windows.Forms.Padding(4);
			this.groupBoxVariables.Name = "groupBoxVariables";
			this.groupBoxVariables.Padding = new System.Windows.Forms.Padding(4);
			this.groupBoxVariables.Size = new System.Drawing.Size(558, 293);
			this.groupBoxVariables.TabIndex = 1;
			this.groupBoxVariables.TabStop = false;
			this.groupBoxVariables.Text = "Measured/Controlled Variables";
			// 
			// flowLayoutPanelControlledVariables
			// 
			this.flowLayoutPanelControlledVariables.AutoScroll = true;
			this.flowLayoutPanelControlledVariables.Controls.Add(this.groupBoxMassFlow);
			this.flowLayoutPanelControlledVariables.Controls.Add(this.groupBoxVolumeFlow);
			this.flowLayoutPanelControlledVariables.Controls.Add(this.groupBoxVelocity);
			this.flowLayoutPanelControlledVariables.Controls.Add(this.groupBoxPressure);
			this.flowLayoutPanelControlledVariables.Controls.Add(this.groupBoxTemperature);
			this.flowLayoutPanelControlledVariables.Controls.Add(this.groupBoxCurrent);
			this.flowLayoutPanelControlledVariables.Controls.Add(this.groupBoxVoltage);
			this.flowLayoutPanelControlledVariables.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanelControlledVariables.Location = new System.Drawing.Point(4, 19);
			this.flowLayoutPanelControlledVariables.Margin = new System.Windows.Forms.Padding(4);
			this.flowLayoutPanelControlledVariables.Name = "flowLayoutPanelControlledVariables";
			this.flowLayoutPanelControlledVariables.Size = new System.Drawing.Size(550, 270);
			this.flowLayoutPanelControlledVariables.TabIndex = 0;
			// 
			// groupBoxMassFlow
			// 
			this.groupBoxMassFlow.AutoSize = true;
			this.groupBoxMassFlow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxMassFlow.Controls.Add(this.labelVar1Unit2);
			this.groupBoxMassFlow.Controls.Add(this.labelVar1Unit1);
			this.groupBoxMassFlow.Controls.Add(this.textBoxMassFlowValue);
			this.groupBoxMassFlow.Controls.Add(this.textBoxMassFlowSetpoint);
			this.groupBoxMassFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBoxMassFlow.Location = new System.Drawing.Point(4, 4);
			this.groupBoxMassFlow.Margin = new System.Windows.Forms.Padding(4);
			this.groupBoxMassFlow.Name = "groupBoxMassFlow";
			this.groupBoxMassFlow.Padding = new System.Windows.Forms.Padding(4);
			this.groupBoxMassFlow.Size = new System.Drawing.Size(175, 124);
			this.groupBoxMassFlow.TabIndex = 0;
			this.groupBoxMassFlow.TabStop = false;
			this.groupBoxMassFlow.Text = "Mass Flow";
			// 
			// labelVar1Unit2
			// 
			this.labelVar1Unit2.AutoSize = true;
			this.labelVar1Unit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelVar1Unit2.Location = new System.Drawing.Point(109, 66);
			this.labelVar1Unit2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelVar1Unit2.Name = "labelVar1Unit2";
			this.labelVar1Unit2.Size = new System.Drawing.Size(58, 25);
			this.labelVar1Unit2.TabIndex = 5;
			this.labelVar1Unit2.Text = "sccm";
			// 
			// labelVar1Unit1
			// 
			this.labelVar1Unit1.AutoSize = true;
			this.labelVar1Unit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelVar1Unit1.Location = new System.Drawing.Point(109, 27);
			this.labelVar1Unit1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelVar1Unit1.Name = "labelVar1Unit1";
			this.labelVar1Unit1.Size = new System.Drawing.Size(58, 25);
			this.labelVar1Unit1.TabIndex = 4;
			this.labelVar1Unit1.Text = "sccm";
			// 
			// textBoxMassFlowValue
			// 
			this.textBoxMassFlowValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxMassFlowValue.Location = new System.Drawing.Point(8, 63);
			this.textBoxMassFlowValue.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxMassFlowValue.Name = "textBoxMassFlowValue";
			this.textBoxMassFlowValue.ReadOnly = true;
			this.textBoxMassFlowValue.Size = new System.Drawing.Size(92, 30);
			this.textBoxMassFlowValue.TabIndex = 1;
			this.textBoxMassFlowValue.Text = "0.000";
			// 
			// textBoxMassFlowSetpoint
			// 
			this.textBoxMassFlowSetpoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxMassFlowSetpoint.Location = new System.Drawing.Point(8, 23);
			this.textBoxMassFlowSetpoint.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxMassFlowSetpoint.Name = "textBoxMassFlowSetpoint";
			this.textBoxMassFlowSetpoint.ReadOnly = true;
			this.textBoxMassFlowSetpoint.Size = new System.Drawing.Size(92, 30);
			this.textBoxMassFlowSetpoint.TabIndex = 0;
			this.textBoxMassFlowSetpoint.Text = "0.000";
			// 
			// groupBoxVolumeFlow
			// 
			this.groupBoxVolumeFlow.AutoSize = true;
			this.groupBoxVolumeFlow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxVolumeFlow.Controls.Add(this.label1);
			this.groupBoxVolumeFlow.Controls.Add(this.label2);
			this.groupBoxVolumeFlow.Controls.Add(this.textBoxVolumeFlowValue);
			this.groupBoxVolumeFlow.Controls.Add(this.textBoxVolumeFlowSetpoint);
			this.groupBoxVolumeFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBoxVolumeFlow.Location = new System.Drawing.Point(187, 4);
			this.groupBoxVolumeFlow.Margin = new System.Windows.Forms.Padding(4);
			this.groupBoxVolumeFlow.Name = "groupBoxVolumeFlow";
			this.groupBoxVolumeFlow.Padding = new System.Windows.Forms.Padding(4);
			this.groupBoxVolumeFlow.Size = new System.Drawing.Size(165, 124);
			this.groupBoxVolumeFlow.TabIndex = 6;
			this.groupBoxVolumeFlow.TabStop = false;
			this.groupBoxVolumeFlow.Text = "Volume Flow";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(109, 66);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 25);
			this.label1.TabIndex = 5;
			this.label1.Text = "ccm";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(109, 27);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 25);
			this.label2.TabIndex = 4;
			this.label2.Text = "ccm";
			// 
			// textBoxVolumeFlowValue
			// 
			this.textBoxVolumeFlowValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxVolumeFlowValue.Location = new System.Drawing.Point(8, 63);
			this.textBoxVolumeFlowValue.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxVolumeFlowValue.Name = "textBoxVolumeFlowValue";
			this.textBoxVolumeFlowValue.ReadOnly = true;
			this.textBoxVolumeFlowValue.Size = new System.Drawing.Size(92, 30);
			this.textBoxVolumeFlowValue.TabIndex = 1;
			this.textBoxVolumeFlowValue.Text = "0.000";
			// 
			// textBoxVolumeFlowSetpoint
			// 
			this.textBoxVolumeFlowSetpoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxVolumeFlowSetpoint.Location = new System.Drawing.Point(8, 23);
			this.textBoxVolumeFlowSetpoint.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxVolumeFlowSetpoint.Name = "textBoxVolumeFlowSetpoint";
			this.textBoxVolumeFlowSetpoint.ReadOnly = true;
			this.textBoxVolumeFlowSetpoint.Size = new System.Drawing.Size(92, 30);
			this.textBoxVolumeFlowSetpoint.TabIndex = 0;
			this.textBoxVolumeFlowSetpoint.Text = "0.000";
			// 
			// groupBoxVelocity
			// 
			this.groupBoxVelocity.AutoSize = true;
			this.groupBoxVelocity.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxVelocity.Controls.Add(this.label3);
			this.groupBoxVelocity.Controls.Add(this.label4);
			this.groupBoxVelocity.Controls.Add(this.textBoxVelocityValue);
			this.groupBoxVelocity.Controls.Add(this.textBoxVelocitySetpoint);
			this.groupBoxVelocity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBoxVelocity.Location = new System.Drawing.Point(360, 4);
			this.groupBoxVelocity.Margin = new System.Windows.Forms.Padding(4);
			this.groupBoxVelocity.Name = "groupBoxVelocity";
			this.groupBoxVelocity.Padding = new System.Windows.Forms.Padding(4);
			this.groupBoxVelocity.Size = new System.Drawing.Size(161, 124);
			this.groupBoxVelocity.TabIndex = 7;
			this.groupBoxVelocity.TabStop = false;
			this.groupBoxVelocity.Text = "Velocity";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(109, 66);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 25);
			this.label3.TabIndex = 5;
			this.label3.Text = "m/s";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(109, 27);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(44, 25);
			this.label4.TabIndex = 4;
			this.label4.Text = "m/s";
			// 
			// textBoxVelocityValue
			// 
			this.textBoxVelocityValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxVelocityValue.Location = new System.Drawing.Point(8, 63);
			this.textBoxVelocityValue.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxVelocityValue.Name = "textBoxVelocityValue";
			this.textBoxVelocityValue.ReadOnly = true;
			this.textBoxVelocityValue.Size = new System.Drawing.Size(92, 30);
			this.textBoxVelocityValue.TabIndex = 1;
			this.textBoxVelocityValue.Text = "0.000";
			// 
			// textBoxVelocitySetpoint
			// 
			this.textBoxVelocitySetpoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxVelocitySetpoint.Location = new System.Drawing.Point(8, 23);
			this.textBoxVelocitySetpoint.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxVelocitySetpoint.Name = "textBoxVelocitySetpoint";
			this.textBoxVelocitySetpoint.ReadOnly = true;
			this.textBoxVelocitySetpoint.Size = new System.Drawing.Size(92, 30);
			this.textBoxVelocitySetpoint.TabIndex = 0;
			this.textBoxVelocitySetpoint.Text = "0.000";
			// 
			// groupBoxPressure
			// 
			this.groupBoxPressure.AutoSize = true;
			this.groupBoxPressure.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxPressure.Controls.Add(this.label5);
			this.groupBoxPressure.Controls.Add(this.label6);
			this.groupBoxPressure.Controls.Add(this.textBoxPressureValue);
			this.groupBoxPressure.Controls.Add(this.textBoxPressureSetpoint);
			this.groupBoxPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBoxPressure.Location = new System.Drawing.Point(4, 136);
			this.groupBoxPressure.Margin = new System.Windows.Forms.Padding(4);
			this.groupBoxPressure.Name = "groupBoxPressure";
			this.groupBoxPressure.Padding = new System.Windows.Forms.Padding(4);
			this.groupBoxPressure.Size = new System.Drawing.Size(163, 124);
			this.groupBoxPressure.TabIndex = 8;
			this.groupBoxPressure.TabStop = false;
			this.groupBoxPressure.Text = "Pressure";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(109, 66);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(46, 25);
			this.label5.TabIndex = 5;
			this.label5.Text = "kPa";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(109, 27);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(46, 25);
			this.label6.TabIndex = 4;
			this.label6.Text = "kPa";
			// 
			// textBoxPressureValue
			// 
			this.textBoxPressureValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxPressureValue.Location = new System.Drawing.Point(8, 63);
			this.textBoxPressureValue.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxPressureValue.Name = "textBoxPressureValue";
			this.textBoxPressureValue.ReadOnly = true;
			this.textBoxPressureValue.Size = new System.Drawing.Size(92, 30);
			this.textBoxPressureValue.TabIndex = 1;
			this.textBoxPressureValue.Text = "0.000";
			// 
			// textBoxPressureSetpoint
			// 
			this.textBoxPressureSetpoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxPressureSetpoint.Location = new System.Drawing.Point(8, 23);
			this.textBoxPressureSetpoint.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxPressureSetpoint.Name = "textBoxPressureSetpoint";
			this.textBoxPressureSetpoint.ReadOnly = true;
			this.textBoxPressureSetpoint.Size = new System.Drawing.Size(92, 30);
			this.textBoxPressureSetpoint.TabIndex = 0;
			this.textBoxPressureSetpoint.Text = "0.000";
			// 
			// groupBoxTemperature
			// 
			this.groupBoxTemperature.AutoSize = true;
			this.groupBoxTemperature.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxTemperature.Controls.Add(this.label7);
			this.groupBoxTemperature.Controls.Add(this.label8);
			this.groupBoxTemperature.Controls.Add(this.textBoxTempValue);
			this.groupBoxTemperature.Controls.Add(this.textBoxTempSetpoint);
			this.groupBoxTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBoxTemperature.Location = new System.Drawing.Point(175, 136);
			this.groupBoxTemperature.Margin = new System.Windows.Forms.Padding(4);
			this.groupBoxTemperature.Name = "groupBoxTemperature";
			this.groupBoxTemperature.Padding = new System.Windows.Forms.Padding(4);
			this.groupBoxTemperature.Size = new System.Drawing.Size(152, 124);
			this.groupBoxTemperature.TabIndex = 9;
			this.groupBoxTemperature.TabStop = false;
			this.groupBoxTemperature.Text = "Temp";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(109, 66);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(35, 25);
			this.label7.TabIndex = 5;
			this.label7.Text = "°C";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(109, 27);
			this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(35, 25);
			this.label8.TabIndex = 4;
			this.label8.Text = "°C";
			// 
			// textBoxTempValue
			// 
			this.textBoxTempValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxTempValue.Location = new System.Drawing.Point(8, 63);
			this.textBoxTempValue.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxTempValue.Name = "textBoxTempValue";
			this.textBoxTempValue.ReadOnly = true;
			this.textBoxTempValue.Size = new System.Drawing.Size(92, 30);
			this.textBoxTempValue.TabIndex = 1;
			this.textBoxTempValue.Text = "0.000";
			// 
			// textBoxTempSetpoint
			// 
			this.textBoxTempSetpoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxTempSetpoint.Location = new System.Drawing.Point(8, 23);
			this.textBoxTempSetpoint.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxTempSetpoint.Name = "textBoxTempSetpoint";
			this.textBoxTempSetpoint.ReadOnly = true;
			this.textBoxTempSetpoint.Size = new System.Drawing.Size(92, 30);
			this.textBoxTempSetpoint.TabIndex = 0;
			this.textBoxTempSetpoint.Text = "0.000";
			// 
			// groupBoxCurrent
			// 
			this.groupBoxCurrent.AutoSize = true;
			this.groupBoxCurrent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxCurrent.Controls.Add(this.label9);
			this.groupBoxCurrent.Controls.Add(this.label10);
			this.groupBoxCurrent.Controls.Add(this.textBoxCurrentValue);
			this.groupBoxCurrent.Controls.Add(this.textBoxCurrentSetpoint);
			this.groupBoxCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBoxCurrent.Location = new System.Drawing.Point(335, 136);
			this.groupBoxCurrent.Margin = new System.Windows.Forms.Padding(4);
			this.groupBoxCurrent.Name = "groupBoxCurrent";
			this.groupBoxCurrent.Padding = new System.Windows.Forms.Padding(4);
			this.groupBoxCurrent.Size = new System.Drawing.Size(159, 124);
			this.groupBoxCurrent.TabIndex = 10;
			this.groupBoxCurrent.TabStop = false;
			this.groupBoxCurrent.Text = "Current";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(109, 66);
			this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(42, 25);
			this.label9.TabIndex = 5;
			this.label9.Text = "mA";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(109, 27);
			this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(42, 25);
			this.label10.TabIndex = 4;
			this.label10.Text = "mA";
			// 
			// textBoxCurrentValue
			// 
			this.textBoxCurrentValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxCurrentValue.Location = new System.Drawing.Point(8, 63);
			this.textBoxCurrentValue.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxCurrentValue.Name = "textBoxCurrentValue";
			this.textBoxCurrentValue.ReadOnly = true;
			this.textBoxCurrentValue.Size = new System.Drawing.Size(92, 30);
			this.textBoxCurrentValue.TabIndex = 1;
			this.textBoxCurrentValue.Text = "0.000";
			// 
			// textBoxCurrentSetpoint
			// 
			this.textBoxCurrentSetpoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxCurrentSetpoint.Location = new System.Drawing.Point(8, 23);
			this.textBoxCurrentSetpoint.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxCurrentSetpoint.Name = "textBoxCurrentSetpoint";
			this.textBoxCurrentSetpoint.ReadOnly = true;
			this.textBoxCurrentSetpoint.Size = new System.Drawing.Size(92, 30);
			this.textBoxCurrentSetpoint.TabIndex = 0;
			this.textBoxCurrentSetpoint.Text = "0.000";
			// 
			// groupBoxVoltage
			// 
			this.groupBoxVoltage.AutoSize = true;
			this.groupBoxVoltage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxVoltage.Controls.Add(this.label11);
			this.groupBoxVoltage.Controls.Add(this.label12);
			this.groupBoxVoltage.Controls.Add(this.textBoxVoltageValue);
			this.groupBoxVoltage.Controls.Add(this.textBoxVoltageSetpoint);
			this.groupBoxVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBoxVoltage.Location = new System.Drawing.Point(4, 268);
			this.groupBoxVoltage.Margin = new System.Windows.Forms.Padding(4);
			this.groupBoxVoltage.Name = "groupBoxVoltage";
			this.groupBoxVoltage.Padding = new System.Windows.Forms.Padding(4);
			this.groupBoxVoltage.Size = new System.Drawing.Size(143, 124);
			this.groupBoxVoltage.TabIndex = 11;
			this.groupBoxVoltage.TabStop = false;
			this.groupBoxVoltage.Text = "Voltage";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(109, 66);
			this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(26, 25);
			this.label11.TabIndex = 5;
			this.label11.Text = "V";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.Location = new System.Drawing.Point(109, 27);
			this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(26, 25);
			this.label12.TabIndex = 4;
			this.label12.Text = "V";
			// 
			// textBoxVoltageValue
			// 
			this.textBoxVoltageValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxVoltageValue.Location = new System.Drawing.Point(8, 63);
			this.textBoxVoltageValue.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxVoltageValue.Name = "textBoxVoltageValue";
			this.textBoxVoltageValue.ReadOnly = true;
			this.textBoxVoltageValue.Size = new System.Drawing.Size(92, 30);
			this.textBoxVoltageValue.TabIndex = 1;
			this.textBoxVoltageValue.Text = "0.000";
			// 
			// textBoxVoltageSetpoint
			// 
			this.textBoxVoltageSetpoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxVoltageSetpoint.Location = new System.Drawing.Point(8, 23);
			this.textBoxVoltageSetpoint.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxVoltageSetpoint.Name = "textBoxVoltageSetpoint";
			this.textBoxVoltageSetpoint.ReadOnly = true;
			this.textBoxVoltageSetpoint.Size = new System.Drawing.Size(92, 30);
			this.textBoxVoltageSetpoint.TabIndex = 0;
			this.textBoxVoltageSetpoint.Text = "0.000";
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 419);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
			this.statusStrip1.Size = new System.Drawing.Size(582, 34);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripProgressBar1
			// 
			this.toolStripProgressBar1.Name = "toolStripProgressBar1";
			this.toolStripProgressBar1.Size = new System.Drawing.Size(133, 26);
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(77, 28);
			this.toolStripStatusLabel1.Text = "Ready...";
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.testToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
			this.menuStrip1.Size = new System.Drawing.Size(582, 28);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
			this.newToolStripMenuItem.Text = "&New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
			this.openToolStripMenuItem.Text = "&Open...";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
			this.saveToolStripMenuItem.Text = "&Save As...";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
			this.exitToolStripMenuItem.Text = "&Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
			// 
			// testToolStripMenuItem
			// 
			this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.stopToolStripMenuItem});
			this.testToolStripMenuItem.Name = "testToolStripMenuItem";
			this.testToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
			this.testToolStripMenuItem.Text = "&Test";
			// 
			// startToolStripMenuItem
			// 
			this.startToolStripMenuItem.Name = "startToolStripMenuItem";
			this.startToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.startToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
			this.startToolStripMenuItem.Text = "&Start";
			this.startToolStripMenuItem.Click += new System.EventHandler(this.ButtonStart_Click);
			// 
			// pauseToolStripMenuItem
			// 
			this.pauseToolStripMenuItem.Enabled = false;
			this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
			this.pauseToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
			this.pauseToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
			this.pauseToolStripMenuItem.Text = "&Pause";
			this.pauseToolStripMenuItem.ToolTipText = "Hault the current test temporarily";
			this.pauseToolStripMenuItem.Click += new System.EventHandler(this.PauseToolStripMenuItem_Click);
			// 
			// stopToolStripMenuItem
			// 
			this.stopToolStripMenuItem.Enabled = false;
			this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
			this.stopToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
			this.stopToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
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
			this.supportToolStripMenuItem.Click += new System.EventHandler(this.SupportToolStripMenuItem_Click);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
			this.aboutToolStripMenuItem.Text = "&About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
			// 
			// buttonStart
			// 
			this.helpProvider1.SetHelpString(this.buttonStart, "Begin testing with the selected options");
			this.buttonStart.Location = new System.Drawing.Point(4, 4);
			this.buttonStart.Margin = new System.Windows.Forms.Padding(4);
			this.buttonStart.Name = "buttonStart";
			this.helpProvider1.SetShowHelp(this.buttonStart, true);
			this.buttonStart.Size = new System.Drawing.Size(100, 28);
			this.buttonStart.TabIndex = 0;
			this.buttonStart.Text = "Start";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
			// 
			// buttonStop
			// 
			this.buttonStop.Enabled = false;
			this.helpProvider1.SetHelpString(this.buttonStop, "Abort the currently running test");
			this.buttonStop.Location = new System.Drawing.Point(112, 4);
			this.buttonStop.Margin = new System.Windows.Forms.Padding(4);
			this.buttonStop.Name = "buttonStop";
			this.helpProvider1.SetShowHelp(this.buttonStop, true);
			this.buttonStop.Size = new System.Drawing.Size(100, 28);
			this.buttonStop.TabIndex = 1;
			this.buttonStop.Text = "Stop";
			this.buttonStop.UseVisualStyleBackColor = true;
			this.buttonStop.Click += new System.EventHandler(this.ButtonStop_Click);
			// 
			// tableLayoutPanelTest
			// 
			this.tableLayoutPanelTest.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelTest.ColumnCount = 1;
			this.tableLayoutPanelTest.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelTest.Controls.Add(this.tabControl, 0, 0);
			this.tableLayoutPanelTest.Controls.Add(this.tableLayoutPanelTestSetupButtons, 0, 1);
			this.tableLayoutPanelTest.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelTest.Location = new System.Drawing.Point(0, 28);
			this.tableLayoutPanelTest.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanelTest.Name = "tableLayoutPanelTest";
			this.tableLayoutPanelTest.RowCount = 2;
			this.tableLayoutPanelTest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelTest.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelTest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanelTest.Size = new System.Drawing.Size(582, 391);
			this.tableLayoutPanelTest.TabIndex = 18;
			// 
			// tableLayoutPanelTestSetupButtons
			// 
			this.tableLayoutPanelTestSetupButtons.AutoSize = true;
			this.tableLayoutPanelTestSetupButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelTestSetupButtons.ColumnCount = 2;
			this.tableLayoutPanelTestSetupButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelTestSetupButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelTestSetupButtons.Controls.Add(this.tableLayoutPanel3, 0, 0);
			this.tableLayoutPanelTestSetupButtons.Controls.Add(this.tableLayoutPanel2, 1, 0);
			this.tableLayoutPanelTestSetupButtons.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelTestSetupButtons.Location = new System.Drawing.Point(4, 342);
			this.tableLayoutPanelTestSetupButtons.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanelTestSetupButtons.Name = "tableLayoutPanelTestSetupButtons";
			this.tableLayoutPanelTestSetupButtons.RowCount = 1;
			this.tableLayoutPanelTestSetupButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelTestSetupButtons.Size = new System.Drawing.Size(574, 45);
			this.tableLayoutPanelTestSetupButtons.TabIndex = 13;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.tableLayoutPanel3.AutoSize = true;
			this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.Controls.Add(this.labelRepeat, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanelRepeat, 1, 0);
			this.tableLayoutPanel3.Location = new System.Drawing.Point(40, 4);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.Size = new System.Drawing.Size(206, 37);
			this.tableLayoutPanel3.TabIndex = 17;
			// 
			// labelRepeat
			// 
			this.labelRepeat.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelRepeat.AutoSize = true;
			this.labelRepeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelRepeat.Location = new System.Drawing.Point(4, 6);
			this.labelRepeat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelRepeat.Name = "labelRepeat";
			this.labelRepeat.Size = new System.Drawing.Size(74, 25);
			this.labelRepeat.TabIndex = 22;
			this.labelRepeat.Text = "Repeat";
			// 
			// tableLayoutPanelRepeat
			// 
			this.tableLayoutPanelRepeat.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.tableLayoutPanelRepeat.AutoSize = true;
			this.tableLayoutPanelRepeat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelRepeat.ColumnCount = 2;
			this.tableLayoutPanelRepeat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelRepeat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelRepeat.Controls.Add(this.radioButtonRepeatNo, 1, 0);
			this.tableLayoutPanelRepeat.Controls.Add(this.radioButtonRepeatYes, 0, 0);
			this.tableLayoutPanelRepeat.Location = new System.Drawing.Point(86, 4);
			this.tableLayoutPanelRepeat.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanelRepeat.Name = "tableLayoutPanelRepeat";
			this.tableLayoutPanelRepeat.RowCount = 1;
			this.tableLayoutPanelRepeat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelRepeat.Size = new System.Drawing.Size(116, 29);
			this.tableLayoutPanelRepeat.TabIndex = 23;
			// 
			// radioButtonRepeatNo
			// 
			this.radioButtonRepeatNo.AutoSize = true;
			this.radioButtonRepeatNo.Location = new System.Drawing.Point(65, 4);
			this.radioButtonRepeatNo.Margin = new System.Windows.Forms.Padding(4);
			this.radioButtonRepeatNo.Name = "radioButtonRepeatNo";
			this.radioButtonRepeatNo.Size = new System.Drawing.Size(47, 21);
			this.radioButtonRepeatNo.TabIndex = 3;
			this.radioButtonRepeatNo.TabStop = true;
			this.radioButtonRepeatNo.Text = "No";
			this.radioButtonRepeatNo.UseVisualStyleBackColor = true;
			this.radioButtonRepeatNo.CheckedChanged += new System.EventHandler(this.RadioButtonRepeat_CheckedChanged);
			// 
			// radioButtonRepeatYes
			// 
			this.radioButtonRepeatYes.AutoSize = true;
			this.radioButtonRepeatYes.Location = new System.Drawing.Point(4, 4);
			this.radioButtonRepeatYes.Margin = new System.Windows.Forms.Padding(4);
			this.radioButtonRepeatYes.Name = "radioButtonRepeatYes";
			this.radioButtonRepeatYes.Size = new System.Drawing.Size(53, 21);
			this.radioButtonRepeatYes.TabIndex = 2;
			this.radioButtonRepeatYes.TabStop = true;
			this.radioButtonRepeatYes.Text = "Yes";
			this.radioButtonRepeatYes.UseVisualStyleBackColor = true;
			this.radioButtonRepeatYes.CheckedChanged += new System.EventHandler(this.RadioButtonRepeat_CheckedChanged);
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
			this.tableLayoutPanel2.Controls.Add(this.buttonStart, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.buttonStop, 1, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(322, 4);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(216, 36);
			this.tableLayoutPanel2.TabIndex = 14;
			// 
			// FormCalibration
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(582, 453);
			this.Controls.Add(this.tableLayoutPanelTest);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FormCalibration";
			this.Text = "Automated Test System";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCalibration_FormClosing);
			this.tabControl.ResumeLayout(false);
			this.tabPageDevices.ResumeLayout(false);
			this.tabPageDevices.PerformLayout();
			this.groupBoxDevices.ResumeLayout(false);
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel4.PerformLayout();
			this.tableLayoutPanelDevices.ResumeLayout(false);
			this.tableLayoutPanelDevices.PerformLayout();
			this.tableLayoutPanel6.ResumeLayout(false);
			this.tableLayoutPanel6.PerformLayout();
			this.tableLayoutPanel11.ResumeLayout(false);
			this.tableLayoutPanel11.PerformLayout();
			this.tabPageEvents.ResumeLayout(false);
			this.tabPageEvents.PerformLayout();
			this.groupBoxEvents.ResumeLayout(false);
			this.tableLayoutPanel7.ResumeLayout(false);
			this.tableLayoutPanel7.PerformLayout();
			this.tableLayoutPanelEvents.ResumeLayout(false);
			this.tableLayoutPanelEvents.PerformLayout();
			this.tableLayoutPanel9.ResumeLayout(false);
			this.tableLayoutPanel9.PerformLayout();
			this.tableLayoutPanel10.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownEventDuration)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownEventValue)).EndInit();
			this.tabPageLog.ResumeLayout(false);
			this.tabPageLog.PerformLayout();
			this.groupBoxLog.ResumeLayout(false);
			this.groupBoxLog.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tabPageStatus.ResumeLayout(false);
			this.groupBoxVariables.ResumeLayout(false);
			this.flowLayoutPanelControlledVariables.ResumeLayout(false);
			this.flowLayoutPanelControlledVariables.PerformLayout();
			this.groupBoxMassFlow.ResumeLayout(false);
			this.groupBoxMassFlow.PerformLayout();
			this.groupBoxVolumeFlow.ResumeLayout(false);
			this.groupBoxVolumeFlow.PerformLayout();
			this.groupBoxVelocity.ResumeLayout(false);
			this.groupBoxVelocity.PerformLayout();
			this.groupBoxPressure.ResumeLayout(false);
			this.groupBoxPressure.PerformLayout();
			this.groupBoxTemperature.ResumeLayout(false);
			this.groupBoxTemperature.PerformLayout();
			this.groupBoxCurrent.ResumeLayout(false);
			this.groupBoxCurrent.PerformLayout();
			this.groupBoxVoltage.ResumeLayout(false);
			this.groupBoxVoltage.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tableLayoutPanelTest.ResumeLayout(false);
			this.tableLayoutPanelTest.PerformLayout();
			this.tableLayoutPanelTestSetupButtons.ResumeLayout(false);
			this.tableLayoutPanelTestSetupButtons.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.tableLayoutPanelRepeat.ResumeLayout(false);
			this.tableLayoutPanelRepeat.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.TabPage tabPageEvents;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem supportToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.HelpProvider helpProvider1;
		private System.Windows.Forms.TabPage tabPageStatus;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
		private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.TabPage tabPageDevices;
		private System.Windows.Forms.GroupBox groupBoxVariables;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelControlledVariables;
		private System.Windows.Forms.GroupBox groupBoxMassFlow;
		private System.Windows.Forms.Label labelVar1Unit2;
		private System.Windows.Forms.Label labelVar1Unit1;
		private System.Windows.Forms.TextBox textBoxMassFlowValue;
		private System.Windows.Forms.TextBox textBoxMassFlowSetpoint;
		private System.Windows.Forms.GroupBox groupBoxVolumeFlow;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxVolumeFlowValue;
		private System.Windows.Forms.TextBox textBoxVolumeFlowSetpoint;
		private System.Windows.Forms.GroupBox groupBoxVelocity;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxVelocityValue;
		private System.Windows.Forms.TextBox textBoxVelocitySetpoint;
		private System.Windows.Forms.GroupBox groupBoxPressure;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBoxPressureValue;
		private System.Windows.Forms.TextBox textBoxPressureSetpoint;
		private System.Windows.Forms.GroupBox groupBoxTemperature;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBoxTempValue;
		private System.Windows.Forms.TextBox textBoxTempSetpoint;
		private System.Windows.Forms.GroupBox groupBoxCurrent;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBoxCurrentValue;
		private System.Windows.Forms.TextBox textBoxCurrentSetpoint;
		private System.Windows.Forms.GroupBox groupBoxVoltage;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox textBoxVoltageValue;
		private System.Windows.Forms.TextBox textBoxVoltageSetpoint;
		private System.Windows.Forms.TabPage tabPageLog;
		private System.Windows.Forms.GroupBox groupBoxLog;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTest;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTestSetupButtons;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.Button buttonStop;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TextBox textBoxLogFilename;
		private System.Windows.Forms.Button buttonLogBrowse;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Label labelRepeat;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRepeat;
		private System.Windows.Forms.RadioButton radioButtonRepeatNo;
		private System.Windows.Forms.RadioButton radioButtonRepeatYes;
		private System.Windows.Forms.GroupBox groupBoxEvents;
		private System.Windows.Forms.GroupBox groupBoxDevices;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDevices;
		private System.Windows.Forms.Label labelDeviceName;
		private System.Windows.Forms.Label labelDeviceType;
		private System.Windows.Forms.Label labelDeviceSerialPort;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
		private System.Windows.Forms.CheckBox checkBoxDeviceSelectAll;
		private System.Windows.Forms.Button buttonDeviceDelete;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
		private System.Windows.Forms.Button buttonDeviceAdd;
		private System.Windows.Forms.ComboBox comboBoxDeviceType;
		private System.Windows.Forms.TextBox textBoxDeviceName;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelEvents;
		private System.Windows.Forms.Label labelEventDevice;
		private System.Windows.Forms.Label labelEventVariable;
		private System.Windows.Forms.Label labelEventValue;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
		private System.Windows.Forms.CheckBox checkBoxEventSelectAll;
		private System.Windows.Forms.Button buttonEventDelete;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
		private System.Windows.Forms.Button buttonEventAdd;
		private System.Windows.Forms.Label labelEventDuration;
		private System.Windows.Forms.ComboBox comboBoxEventDevice;
		private System.Windows.Forms.ComboBox comboBoxEventVariable;
		private System.Windows.Forms.Label labelEventStatus;
		private System.Windows.Forms.NumericUpDown numericUpDownEventDuration;
		private System.Windows.Forms.NumericUpDown numericUpDownEventValue;
	}
}

