namespace Sensit.App.Modbus
{
	partial class FormModbus
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormModbus));
			mainMenuStrip = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			exitToolStripMenuItem = new ToolStripMenuItem();
			groupBoxSerialPort = new GroupBox();
			tableLayoutPanelSerialPort = new TableLayoutPanel();
			labelComPort = new Label();
			comboBoxSerialPort = new ComboBox();
			buttonPortRefresh = new Button();
			labelBaudRate = new Label();
			comboBoxBaudRate = new ComboBox();
			labelStopBits = new Label();
			comboBoxStopBits = new ComboBox();
			labelParity = new Label();
			comboBoxParity = new ComboBox();
			labelMode = new Label();
			comboBoxMode = new ComboBox();
			radioButtonOpen = new RadioButton();
			radioButtonClosed = new RadioButton();
			labelDeviceAddress = new Label();
			textBoxDeviceAddressHex = new TextBox();
			statusStrip1 = new StatusStrip();
			labelMainStatus = new ToolStripStatusLabel();
			toolStripStatusLabel1 = new ToolStripStatusLabel();
			groupBoxAddress = new GroupBox();
			tableLayoutPanelCommunication = new TableLayoutPanel();
			labelDeviceAddress0x = new Label();
			textBoxDeviceAddressDecimal = new TextBox();
			labelDeviceAddress0d = new Label();
			tabControlData = new TabControl();
			tabPageCoils = new TabPage();
			tableLayoutPanelCoils = new TableLayoutPanel();
			labelCoilValue = new Label();
			labelCoilAddress = new Label();
			buttonCoilRead = new Button();
			textBoxCoilAddressHex = new TextBox();
			labelCoil0x = new Label();
			labelCoil0d = new Label();
			textBoxCoilAddressDecimal = new TextBox();
			buttonCoilWrite = new Button();
			radioButtonCoilFalse = new RadioButton();
			radioButtonCoilTrue = new RadioButton();
			tabPageDiscreteInputs = new TabPage();
			tableLayoutPanelDiscreteInputs = new TableLayoutPanel();
			labelDiscreteInputValue = new Label();
			labelDiscreteInputAddress = new Label();
			buttonDiscreteInputRead = new Button();
			textBoxDiscreteInputAddressDecimal = new TextBox();
			labelDiscreteInput0d = new Label();
			textBoxDiscreteInputAddressHex = new TextBox();
			labelDiscreteInput0x = new Label();
			buttonDiscreteInputPoll = new Button();
			radioButtonDiscreteInputFalse = new RadioButton();
			radioButtonDiscreteInputTrue = new RadioButton();
			tabPageInputRegisters = new TabPage();
			tableLayoutPanelInputRegisters = new TableLayoutPanel();
			labelInputRegisterAddress = new Label();
			buttonInputRegisterRead = new Button();
			labelInputRegisterStringLength = new Label();
			labelInputRegisterDataFormat = new Label();
			labelInputRegisterData = new Label();
			textBoxInputRegisterAddressDecimal = new TextBox();
			textBoxInputRegisterAddressHex = new TextBox();
			labelInputRegister0x = new Label();
			labelInputRegister0d = new Label();
			buttonInputRegisterPoll = new Button();
			textBoxInputRegisterData = new TextBox();
			textBoxInputRegisterStringLength = new TextBox();
			comboBoxInputRegisterFormat = new ComboBox();
			tabPageHoldingRegisters = new TabPage();
			tableLayoutPanelHoldingRegisters = new TableLayoutPanel();
			buttonHoldingRegisterRead = new Button();
			labelHoldingRegisterAddress = new Label();
			labelHoldingRegisterStringLength = new Label();
			labelHoldingRegisterData = new Label();
			labelHoldingRegisterFormat = new Label();
			textBoxHoldingRegisterAddressDecimal = new TextBox();
			textBoxHoldingRegisterAddressHex = new TextBox();
			labelHoldingRegister0x = new Label();
			labelHoldingRegister0d = new Label();
			buttonHoldingRegisterWrite = new Button();
			textBoxHoldingRegisterData = new TextBox();
			textBoxHoldingRegisterStringLength = new TextBox();
			comboBoxHoldingRegisterFormat = new ComboBox();
			groupBoxData = new GroupBox();
			mainMenuStrip.SuspendLayout();
			groupBoxSerialPort.SuspendLayout();
			tableLayoutPanelSerialPort.SuspendLayout();
			statusStrip1.SuspendLayout();
			groupBoxAddress.SuspendLayout();
			tableLayoutPanelCommunication.SuspendLayout();
			tabControlData.SuspendLayout();
			tabPageCoils.SuspendLayout();
			tableLayoutPanelCoils.SuspendLayout();
			tabPageDiscreteInputs.SuspendLayout();
			tableLayoutPanelDiscreteInputs.SuspendLayout();
			tabPageInputRegisters.SuspendLayout();
			tableLayoutPanelInputRegisters.SuspendLayout();
			tabPageHoldingRegisters.SuspendLayout();
			tableLayoutPanelHoldingRegisters.SuspendLayout();
			groupBoxData.SuspendLayout();
			SuspendLayout();
			// 
			// mainMenuStrip
			// 
			mainMenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
			mainMenuStrip.Location = new Point(0, 0);
			mainMenuStrip.Name = "mainMenuStrip";
			mainMenuStrip.Padding = new Padding(7, 2, 0, 2);
			mainMenuStrip.Size = new Size(451, 24);
			mainMenuStrip.TabIndex = 0;
			mainMenuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new Size(37, 20);
			fileToolStripMenuItem.Text = "&File";
			// 
			// exitToolStripMenuItem
			// 
			exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			exitToolStripMenuItem.Size = new Size(93, 22);
			exitToolStripMenuItem.Text = "E&xit";
			exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
			// 
			// groupBoxSerialPort
			// 
			groupBoxSerialPort.AutoSize = true;
			groupBoxSerialPort.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			groupBoxSerialPort.Controls.Add(tableLayoutPanelSerialPort);
			groupBoxSerialPort.Dock = DockStyle.Top;
			groupBoxSerialPort.Location = new Point(0, 24);
			groupBoxSerialPort.Margin = new Padding(4, 3, 4, 3);
			groupBoxSerialPort.Name = "groupBoxSerialPort";
			groupBoxSerialPort.Padding = new Padding(4, 3, 4, 3);
			groupBoxSerialPort.Size = new Size(451, 113);
			groupBoxSerialPort.TabIndex = 1;
			groupBoxSerialPort.TabStop = false;
			groupBoxSerialPort.Text = "Serial Port";
			// 
			// tableLayoutPanelSerialPort
			// 
			tableLayoutPanelSerialPort.AutoSize = true;
			tableLayoutPanelSerialPort.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			tableLayoutPanelSerialPort.ColumnCount = 6;
			tableLayoutPanelSerialPort.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelSerialPort.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelSerialPort.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelSerialPort.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelSerialPort.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelSerialPort.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelSerialPort.Controls.Add(labelComPort, 0, 0);
			tableLayoutPanelSerialPort.Controls.Add(comboBoxSerialPort, 1, 0);
			tableLayoutPanelSerialPort.Controls.Add(buttonPortRefresh, 2, 0);
			tableLayoutPanelSerialPort.Controls.Add(labelBaudRate, 0, 1);
			tableLayoutPanelSerialPort.Controls.Add(comboBoxBaudRate, 1, 1);
			tableLayoutPanelSerialPort.Controls.Add(labelStopBits, 3, 0);
			tableLayoutPanelSerialPort.Controls.Add(comboBoxStopBits, 4, 0);
			tableLayoutPanelSerialPort.Controls.Add(labelParity, 3, 1);
			tableLayoutPanelSerialPort.Controls.Add(comboBoxParity, 4, 1);
			tableLayoutPanelSerialPort.Controls.Add(labelMode, 3, 2);
			tableLayoutPanelSerialPort.Controls.Add(comboBoxMode, 4, 2);
			tableLayoutPanelSerialPort.Controls.Add(radioButtonOpen, 5, 0);
			tableLayoutPanelSerialPort.Controls.Add(radioButtonClosed, 5, 1);
			tableLayoutPanelSerialPort.Dock = DockStyle.Fill;
			tableLayoutPanelSerialPort.Location = new Point(4, 19);
			tableLayoutPanelSerialPort.Margin = new Padding(4, 3, 4, 3);
			tableLayoutPanelSerialPort.Name = "tableLayoutPanelSerialPort";
			tableLayoutPanelSerialPort.RowCount = 3;
			tableLayoutPanelSerialPort.RowStyles.Add(new RowStyle());
			tableLayoutPanelSerialPort.RowStyles.Add(new RowStyle());
			tableLayoutPanelSerialPort.RowStyles.Add(new RowStyle());
			tableLayoutPanelSerialPort.Size = new Size(443, 91);
			tableLayoutPanelSerialPort.TabIndex = 12;
			// 
			// labelComPort
			// 
			labelComPort.Anchor = AnchorStyles.Left;
			labelComPort.AutoSize = true;
			labelComPort.Location = new Point(4, 9);
			labelComPort.Margin = new Padding(4, 0, 4, 0);
			labelComPort.Name = "labelComPort";
			labelComPort.Size = new Size(63, 15);
			labelComPort.TabIndex = 0;
			labelComPort.Text = "COM Port:";
			// 
			// comboBoxSerialPort
			// 
			comboBoxSerialPort.FormattingEnabled = true;
			comboBoxSerialPort.Location = new Point(75, 3);
			comboBoxSerialPort.Margin = new Padding(4, 3, 4, 3);
			comboBoxSerialPort.Name = "comboBoxSerialPort";
			comboBoxSerialPort.Size = new Size(84, 23);
			comboBoxSerialPort.TabIndex = 1;
			// 
			// buttonPortRefresh
			// 
			buttonPortRefresh.Image = (Image)resources.GetObject("buttonPortRefresh.Image");
			buttonPortRefresh.Location = new Point(167, 3);
			buttonPortRefresh.Margin = new Padding(4, 3, 4, 3);
			buttonPortRefresh.Name = "buttonPortRefresh";
			buttonPortRefresh.Size = new Size(33, 27);
			buttonPortRefresh.TabIndex = 2;
			buttonPortRefresh.UseVisualStyleBackColor = true;
			buttonPortRefresh.Click += ButtonPortRefresh_Click;
			// 
			// labelBaudRate
			// 
			labelBaudRate.Anchor = AnchorStyles.Left;
			labelBaudRate.AutoSize = true;
			labelBaudRate.Location = new Point(4, 40);
			labelBaudRate.Margin = new Padding(4, 0, 4, 0);
			labelBaudRate.Name = "labelBaudRate";
			labelBaudRate.Size = new Size(63, 15);
			labelBaudRate.TabIndex = 3;
			labelBaudRate.Text = "Baud Rate:";
			// 
			// comboBoxBaudRate
			// 
			comboBoxBaudRate.FormattingEnabled = true;
			comboBoxBaudRate.Items.AddRange(new object[] { "9600", "19200", "38400", "57600", "76800", "115200" });
			comboBoxBaudRate.Location = new Point(75, 36);
			comboBoxBaudRate.Margin = new Padding(4, 3, 4, 3);
			comboBoxBaudRate.Name = "comboBoxBaudRate";
			comboBoxBaudRate.Size = new Size(84, 23);
			comboBoxBaudRate.TabIndex = 4;
			// 
			// labelStopBits
			// 
			labelStopBits.Anchor = AnchorStyles.Left;
			labelStopBits.AutoSize = true;
			labelStopBits.Location = new Point(208, 9);
			labelStopBits.Margin = new Padding(4, 0, 4, 0);
			labelStopBits.Name = "labelStopBits";
			labelStopBits.Size = new Size(56, 15);
			labelStopBits.TabIndex = 10;
			labelStopBits.Text = "Stop Bits:";
			// 
			// comboBoxStopBits
			// 
			comboBoxStopBits.FormattingEnabled = true;
			comboBoxStopBits.Items.AddRange(new object[] { "1", "2" });
			comboBoxStopBits.Location = new Point(272, 3);
			comboBoxStopBits.Margin = new Padding(4, 3, 4, 3);
			comboBoxStopBits.Name = "comboBoxStopBits";
			comboBoxStopBits.Size = new Size(84, 23);
			comboBoxStopBits.TabIndex = 11;
			// 
			// labelParity
			// 
			labelParity.Anchor = AnchorStyles.Left;
			labelParity.AutoSize = true;
			labelParity.Location = new Point(208, 40);
			labelParity.Margin = new Padding(4, 0, 4, 0);
			labelParity.Name = "labelParity";
			labelParity.Size = new Size(40, 15);
			labelParity.TabIndex = 5;
			labelParity.Text = "Parity:";
			// 
			// comboBoxParity
			// 
			comboBoxParity.FormattingEnabled = true;
			comboBoxParity.Items.AddRange(new object[] { "Even", "Odd", "None" });
			comboBoxParity.Location = new Point(272, 36);
			comboBoxParity.Margin = new Padding(4, 3, 4, 3);
			comboBoxParity.Name = "comboBoxParity";
			comboBoxParity.Size = new Size(84, 23);
			comboBoxParity.TabIndex = 6;
			// 
			// labelMode
			// 
			labelMode.Anchor = AnchorStyles.Left;
			labelMode.AutoSize = true;
			labelMode.Location = new Point(208, 69);
			labelMode.Margin = new Padding(4, 0, 4, 0);
			labelMode.Name = "labelMode";
			labelMode.Size = new Size(41, 15);
			labelMode.TabIndex = 7;
			labelMode.Text = "Mode:";
			// 
			// comboBoxMode
			// 
			comboBoxMode.FormattingEnabled = true;
			comboBoxMode.Items.AddRange(new object[] { "RTU", "ASCII" });
			comboBoxMode.Location = new Point(272, 65);
			comboBoxMode.Margin = new Padding(4, 3, 4, 3);
			comboBoxMode.Name = "comboBoxMode";
			comboBoxMode.Size = new Size(84, 23);
			comboBoxMode.TabIndex = 8;
			// 
			// radioButtonOpen
			// 
			radioButtonOpen.AutoSize = true;
			radioButtonOpen.Location = new Point(364, 3);
			radioButtonOpen.Margin = new Padding(4, 3, 4, 3);
			radioButtonOpen.Name = "radioButtonOpen";
			radioButtonOpen.Size = new Size(54, 19);
			radioButtonOpen.TabIndex = 12;
			radioButtonOpen.Text = "Open";
			radioButtonOpen.UseVisualStyleBackColor = true;
			radioButtonOpen.CheckedChanged += RadioButton_CheckedChanged;
			// 
			// radioButtonClosed
			// 
			radioButtonClosed.AutoSize = true;
			radioButtonClosed.Checked = true;
			radioButtonClosed.Location = new Point(364, 36);
			radioButtonClosed.Margin = new Padding(4, 3, 4, 3);
			radioButtonClosed.Name = "radioButtonClosed";
			radioButtonClosed.Size = new Size(61, 19);
			radioButtonClosed.TabIndex = 13;
			radioButtonClosed.TabStop = true;
			radioButtonClosed.Text = "Closed";
			radioButtonClosed.UseVisualStyleBackColor = true;
			radioButtonClosed.CheckedChanged += RadioButton_CheckedChanged;
			// 
			// labelDeviceAddress
			// 
			labelDeviceAddress.Anchor = AnchorStyles.Left;
			labelDeviceAddress.AutoSize = true;
			labelDeviceAddress.Location = new Point(4, 7);
			labelDeviceAddress.Margin = new Padding(4, 0, 4, 0);
			labelDeviceAddress.Name = "labelDeviceAddress";
			labelDeviceAddress.Size = new Size(52, 15);
			labelDeviceAddress.TabIndex = 3;
			labelDeviceAddress.Text = "Address:";
			// 
			// textBoxDeviceAddressHex
			// 
			textBoxDeviceAddressHex.Location = new Point(91, 3);
			textBoxDeviceAddressHex.Margin = new Padding(4, 3, 4, 3);
			textBoxDeviceAddressHex.Name = "textBoxDeviceAddressHex";
			textBoxDeviceAddressHex.Size = new Size(87, 23);
			textBoxDeviceAddressHex.TabIndex = 4;
			textBoxDeviceAddressHex.Leave += TextBoxDeviceAddressHex_Leave;
			// 
			// statusStrip1
			// 
			statusStrip1.Items.AddRange(new ToolStripItem[] { labelMainStatus, toolStripStatusLabel1 });
			statusStrip1.Location = new Point(0, 419);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Padding = new Padding(1, 0, 16, 0);
			statusStrip1.Size = new Size(451, 22);
			statusStrip1.TabIndex = 5;
			statusStrip1.Text = "statusStrip1";
			// 
			// labelMainStatus
			// 
			labelMainStatus.Name = "labelMainStatus";
			labelMainStatus.Size = new Size(0, 17);
			// 
			// toolStripStatusLabel1
			// 
			toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			toolStripStatusLabel1.Size = new Size(39, 17);
			toolStripStatusLabel1.Text = "Ready";
			// 
			// groupBoxAddress
			// 
			groupBoxAddress.AutoSize = true;
			groupBoxAddress.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			groupBoxAddress.Controls.Add(tableLayoutPanelCommunication);
			groupBoxAddress.Dock = DockStyle.Top;
			groupBoxAddress.Enabled = false;
			groupBoxAddress.Location = new Point(0, 137);
			groupBoxAddress.Margin = new Padding(4, 3, 4, 3);
			groupBoxAddress.Name = "groupBoxAddress";
			groupBoxAddress.Padding = new Padding(4, 3, 4, 3);
			groupBoxAddress.Size = new Size(451, 51);
			groupBoxAddress.TabIndex = 6;
			groupBoxAddress.TabStop = false;
			groupBoxAddress.Text = "Device Address";
			// 
			// tableLayoutPanelCommunication
			// 
			tableLayoutPanelCommunication.AutoSize = true;
			tableLayoutPanelCommunication.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			tableLayoutPanelCommunication.ColumnCount = 5;
			tableLayoutPanelCommunication.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelCommunication.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelCommunication.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelCommunication.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelCommunication.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelCommunication.Controls.Add(labelDeviceAddress0x, 0, 0);
			tableLayoutPanelCommunication.Controls.Add(labelDeviceAddress, 0, 0);
			tableLayoutPanelCommunication.Controls.Add(textBoxDeviceAddressDecimal, 4, 0);
			tableLayoutPanelCommunication.Controls.Add(labelDeviceAddress0d, 3, 0);
			tableLayoutPanelCommunication.Controls.Add(textBoxDeviceAddressHex, 2, 0);
			tableLayoutPanelCommunication.Dock = DockStyle.Top;
			tableLayoutPanelCommunication.Location = new Point(4, 19);
			tableLayoutPanelCommunication.Margin = new Padding(4, 3, 4, 3);
			tableLayoutPanelCommunication.Name = "tableLayoutPanelCommunication";
			tableLayoutPanelCommunication.RowCount = 1;
			tableLayoutPanelCommunication.RowStyles.Add(new RowStyle());
			tableLayoutPanelCommunication.Size = new Size(443, 29);
			tableLayoutPanelCommunication.TabIndex = 0;
			// 
			// labelDeviceAddress0x
			// 
			labelDeviceAddress0x.Anchor = AnchorStyles.Left;
			labelDeviceAddress0x.AutoSize = true;
			labelDeviceAddress0x.Location = new Point(64, 7);
			labelDeviceAddress0x.Margin = new Padding(4, 0, 4, 0);
			labelDeviceAddress0x.Name = "labelDeviceAddress0x";
			labelDeviceAddress0x.Size = new Size(19, 15);
			labelDeviceAddress0x.TabIndex = 7;
			labelDeviceAddress0x.Text = "0x";
			// 
			// textBoxDeviceAddressDecimal
			// 
			textBoxDeviceAddressDecimal.Location = new Point(214, 3);
			textBoxDeviceAddressDecimal.Margin = new Padding(4, 3, 4, 3);
			textBoxDeviceAddressDecimal.Name = "textBoxDeviceAddressDecimal";
			textBoxDeviceAddressDecimal.Size = new Size(87, 23);
			textBoxDeviceAddressDecimal.TabIndex = 6;
			textBoxDeviceAddressDecimal.Leave += TextBoxDeviceAddressDecimal_Leave;
			// 
			// labelDeviceAddress0d
			// 
			labelDeviceAddress0d.Anchor = AnchorStyles.Left;
			labelDeviceAddress0d.AutoSize = true;
			labelDeviceAddress0d.Location = new Point(186, 7);
			labelDeviceAddress0d.Margin = new Padding(4, 0, 4, 0);
			labelDeviceAddress0d.Name = "labelDeviceAddress0d";
			labelDeviceAddress0d.Size = new Size(20, 15);
			labelDeviceAddress0d.TabIndex = 5;
			labelDeviceAddress0d.Text = "0d";
			// 
			// tabControlData
			// 
			tabControlData.Controls.Add(tabPageCoils);
			tabControlData.Controls.Add(tabPageDiscreteInputs);
			tabControlData.Controls.Add(tabPageInputRegisters);
			tabControlData.Controls.Add(tabPageHoldingRegisters);
			tabControlData.Dock = DockStyle.Top;
			tabControlData.Location = new Point(4, 19);
			tabControlData.Margin = new Padding(4, 3, 4, 3);
			tabControlData.Name = "tabControlData";
			tabControlData.SelectedIndex = 0;
			tabControlData.Size = new Size(443, 190);
			tabControlData.TabIndex = 7;
			// 
			// tabPageCoils
			// 
			tabPageCoils.Controls.Add(tableLayoutPanelCoils);
			tabPageCoils.Location = new Point(4, 24);
			tabPageCoils.Margin = new Padding(4, 3, 4, 3);
			tabPageCoils.Name = "tabPageCoils";
			tabPageCoils.Padding = new Padding(4, 3, 4, 3);
			tabPageCoils.Size = new Size(435, 162);
			tabPageCoils.TabIndex = 2;
			tabPageCoils.Text = "Coils";
			tabPageCoils.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanelCoils
			// 
			tableLayoutPanelCoils.AutoSize = true;
			tableLayoutPanelCoils.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			tableLayoutPanelCoils.ColumnCount = 5;
			tableLayoutPanelCoils.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelCoils.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelCoils.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelCoils.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelCoils.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelCoils.Controls.Add(labelCoilValue, 0, 1);
			tableLayoutPanelCoils.Controls.Add(labelCoilAddress, 0, 0);
			tableLayoutPanelCoils.Controls.Add(buttonCoilRead, 0, 3);
			tableLayoutPanelCoils.Controls.Add(textBoxCoilAddressHex, 2, 0);
			tableLayoutPanelCoils.Controls.Add(labelCoil0x, 1, 0);
			tableLayoutPanelCoils.Controls.Add(labelCoil0d, 3, 0);
			tableLayoutPanelCoils.Controls.Add(textBoxCoilAddressDecimal, 4, 0);
			tableLayoutPanelCoils.Controls.Add(buttonCoilWrite, 2, 3);
			tableLayoutPanelCoils.Controls.Add(radioButtonCoilFalse, 2, 2);
			tableLayoutPanelCoils.Controls.Add(radioButtonCoilTrue, 2, 1);
			tableLayoutPanelCoils.Dock = DockStyle.Fill;
			tableLayoutPanelCoils.Location = new Point(4, 3);
			tableLayoutPanelCoils.Margin = new Padding(4, 3, 4, 3);
			tableLayoutPanelCoils.Name = "tableLayoutPanelCoils";
			tableLayoutPanelCoils.RowCount = 4;
			tableLayoutPanelCoils.RowStyles.Add(new RowStyle());
			tableLayoutPanelCoils.RowStyles.Add(new RowStyle());
			tableLayoutPanelCoils.RowStyles.Add(new RowStyle());
			tableLayoutPanelCoils.RowStyles.Add(new RowStyle());
			tableLayoutPanelCoils.Size = new Size(427, 156);
			tableLayoutPanelCoils.TabIndex = 7;
			// 
			// labelCoilValue
			// 
			labelCoilValue.Anchor = AnchorStyles.Left;
			labelCoilValue.AutoSize = true;
			labelCoilValue.Location = new Point(4, 34);
			labelCoilValue.Margin = new Padding(4, 0, 4, 0);
			labelCoilValue.Name = "labelCoilValue";
			labelCoilValue.Size = new Size(38, 15);
			labelCoilValue.TabIndex = 6;
			labelCoilValue.Text = "Value:";
			// 
			// labelCoilAddress
			// 
			labelCoilAddress.Anchor = AnchorStyles.Left;
			labelCoilAddress.AutoSize = true;
			labelCoilAddress.Location = new Point(4, 7);
			labelCoilAddress.Margin = new Padding(4, 0, 4, 0);
			labelCoilAddress.Name = "labelCoilAddress";
			labelCoilAddress.Size = new Size(52, 15);
			labelCoilAddress.TabIndex = 0;
			labelCoilAddress.Text = "Address:";
			// 
			// buttonCoilRead
			// 
			buttonCoilRead.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			tableLayoutPanelCoils.SetColumnSpan(buttonCoilRead, 2);
			buttonCoilRead.Location = new Point(4, 126);
			buttonCoilRead.Margin = new Padding(4, 3, 4, 3);
			buttonCoilRead.Name = "buttonCoilRead";
			buttonCoilRead.Size = new Size(88, 27);
			buttonCoilRead.TabIndex = 4;
			buttonCoilRead.Text = "Read";
			buttonCoilRead.UseVisualStyleBackColor = true;
			buttonCoilRead.Click += ButtonCoilRead_Click;
			// 
			// textBoxCoilAddressHex
			// 
			textBoxCoilAddressHex.Location = new Point(100, 3);
			textBoxCoilAddressHex.Margin = new Padding(4, 3, 4, 3);
			textBoxCoilAddressHex.Name = "textBoxCoilAddressHex";
			textBoxCoilAddressHex.Size = new Size(87, 23);
			textBoxCoilAddressHex.TabIndex = 1;
			textBoxCoilAddressHex.Leave += TextBoxCoilAddressHex_Leave;
			// 
			// labelCoil0x
			// 
			labelCoil0x.Anchor = AnchorStyles.Left;
			labelCoil0x.AutoSize = true;
			labelCoil0x.Location = new Point(64, 7);
			labelCoil0x.Margin = new Padding(4, 0, 4, 0);
			labelCoil0x.Name = "labelCoil0x";
			labelCoil0x.Size = new Size(19, 15);
			labelCoil0x.TabIndex = 7;
			labelCoil0x.Text = "0x";
			// 
			// labelCoil0d
			// 
			labelCoil0d.Anchor = AnchorStyles.Left;
			labelCoil0d.AutoSize = true;
			labelCoil0d.Location = new Point(195, 7);
			labelCoil0d.Margin = new Padding(4, 0, 4, 0);
			labelCoil0d.Name = "labelCoil0d";
			labelCoil0d.Size = new Size(20, 15);
			labelCoil0d.TabIndex = 8;
			labelCoil0d.Text = "0d";
			// 
			// textBoxCoilAddressDecimal
			// 
			textBoxCoilAddressDecimal.Location = new Point(223, 3);
			textBoxCoilAddressDecimal.Margin = new Padding(4, 3, 4, 3);
			textBoxCoilAddressDecimal.Name = "textBoxCoilAddressDecimal";
			textBoxCoilAddressDecimal.Size = new Size(87, 23);
			textBoxCoilAddressDecimal.TabIndex = 9;
			textBoxCoilAddressDecimal.Leave += TextBoxCoilAddressDecimal_Leave;
			// 
			// buttonCoilWrite
			// 
			buttonCoilWrite.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			tableLayoutPanelCoils.SetColumnSpan(buttonCoilWrite, 3);
			buttonCoilWrite.Location = new Point(100, 126);
			buttonCoilWrite.Margin = new Padding(4, 3, 4, 3);
			buttonCoilWrite.Name = "buttonCoilWrite";
			buttonCoilWrite.Size = new Size(88, 27);
			buttonCoilWrite.TabIndex = 5;
			buttonCoilWrite.Text = "Write";
			buttonCoilWrite.UseVisualStyleBackColor = true;
			buttonCoilWrite.Click += ButtonCoilWrite_Click;
			// 
			// radioButtonCoilFalse
			// 
			radioButtonCoilFalse.Anchor = AnchorStyles.Left;
			radioButtonCoilFalse.AutoSize = true;
			tableLayoutPanelCoils.SetColumnSpan(radioButtonCoilFalse, 3);
			radioButtonCoilFalse.Location = new Point(100, 57);
			radioButtonCoilFalse.Margin = new Padding(4, 3, 4, 3);
			radioButtonCoilFalse.Name = "radioButtonCoilFalse";
			radioButtonCoilFalse.Size = new Size(51, 19);
			radioButtonCoilFalse.TabIndex = 3;
			radioButtonCoilFalse.Text = "False";
			radioButtonCoilFalse.UseVisualStyleBackColor = true;
			// 
			// radioButtonCoilTrue
			// 
			radioButtonCoilTrue.Anchor = AnchorStyles.Left;
			radioButtonCoilTrue.AutoSize = true;
			radioButtonCoilTrue.Checked = true;
			tableLayoutPanelCoils.SetColumnSpan(radioButtonCoilTrue, 3);
			radioButtonCoilTrue.Location = new Point(100, 32);
			radioButtonCoilTrue.Margin = new Padding(4, 3, 4, 3);
			radioButtonCoilTrue.Name = "radioButtonCoilTrue";
			radioButtonCoilTrue.Size = new Size(47, 19);
			radioButtonCoilTrue.TabIndex = 2;
			radioButtonCoilTrue.TabStop = true;
			radioButtonCoilTrue.Text = "True";
			radioButtonCoilTrue.UseVisualStyleBackColor = true;
			// 
			// tabPageDiscreteInputs
			// 
			tabPageDiscreteInputs.Controls.Add(tableLayoutPanelDiscreteInputs);
			tabPageDiscreteInputs.Location = new Point(4, 24);
			tabPageDiscreteInputs.Margin = new Padding(4, 3, 4, 3);
			tabPageDiscreteInputs.Name = "tabPageDiscreteInputs";
			tabPageDiscreteInputs.Padding = new Padding(4, 3, 4, 3);
			tabPageDiscreteInputs.Size = new Size(435, 162);
			tabPageDiscreteInputs.TabIndex = 3;
			tabPageDiscreteInputs.Text = "Discrete Inputs";
			tabPageDiscreteInputs.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanelDiscreteInputs
			// 
			tableLayoutPanelDiscreteInputs.AutoSize = true;
			tableLayoutPanelDiscreteInputs.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			tableLayoutPanelDiscreteInputs.ColumnCount = 5;
			tableLayoutPanelDiscreteInputs.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelDiscreteInputs.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelDiscreteInputs.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelDiscreteInputs.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelDiscreteInputs.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelDiscreteInputs.Controls.Add(labelDiscreteInputValue, 0, 1);
			tableLayoutPanelDiscreteInputs.Controls.Add(labelDiscreteInputAddress, 0, 0);
			tableLayoutPanelDiscreteInputs.Controls.Add(buttonDiscreteInputRead, 0, 3);
			tableLayoutPanelDiscreteInputs.Controls.Add(textBoxDiscreteInputAddressDecimal, 4, 0);
			tableLayoutPanelDiscreteInputs.Controls.Add(labelDiscreteInput0d, 3, 0);
			tableLayoutPanelDiscreteInputs.Controls.Add(textBoxDiscreteInputAddressHex, 2, 0);
			tableLayoutPanelDiscreteInputs.Controls.Add(labelDiscreteInput0x, 1, 0);
			tableLayoutPanelDiscreteInputs.Controls.Add(buttonDiscreteInputPoll, 2, 3);
			tableLayoutPanelDiscreteInputs.Controls.Add(radioButtonDiscreteInputFalse, 2, 2);
			tableLayoutPanelDiscreteInputs.Controls.Add(radioButtonDiscreteInputTrue, 2, 1);
			tableLayoutPanelDiscreteInputs.Dock = DockStyle.Fill;
			tableLayoutPanelDiscreteInputs.Location = new Point(4, 3);
			tableLayoutPanelDiscreteInputs.Margin = new Padding(4, 3, 4, 3);
			tableLayoutPanelDiscreteInputs.Name = "tableLayoutPanelDiscreteInputs";
			tableLayoutPanelDiscreteInputs.RowCount = 4;
			tableLayoutPanelDiscreteInputs.RowStyles.Add(new RowStyle());
			tableLayoutPanelDiscreteInputs.RowStyles.Add(new RowStyle());
			tableLayoutPanelDiscreteInputs.RowStyles.Add(new RowStyle());
			tableLayoutPanelDiscreteInputs.RowStyles.Add(new RowStyle());
			tableLayoutPanelDiscreteInputs.Size = new Size(427, 156);
			tableLayoutPanelDiscreteInputs.TabIndex = 8;
			// 
			// labelDiscreteInputValue
			// 
			labelDiscreteInputValue.Anchor = AnchorStyles.Left;
			labelDiscreteInputValue.AutoSize = true;
			labelDiscreteInputValue.Location = new Point(4, 34);
			labelDiscreteInputValue.Margin = new Padding(4, 0, 4, 0);
			labelDiscreteInputValue.Name = "labelDiscreteInputValue";
			labelDiscreteInputValue.Size = new Size(38, 15);
			labelDiscreteInputValue.TabIndex = 6;
			labelDiscreteInputValue.Text = "Value:";
			// 
			// labelDiscreteInputAddress
			// 
			labelDiscreteInputAddress.Anchor = AnchorStyles.Left;
			labelDiscreteInputAddress.AutoSize = true;
			labelDiscreteInputAddress.Location = new Point(4, 7);
			labelDiscreteInputAddress.Margin = new Padding(4, 0, 4, 0);
			labelDiscreteInputAddress.Name = "labelDiscreteInputAddress";
			labelDiscreteInputAddress.Size = new Size(52, 15);
			labelDiscreteInputAddress.TabIndex = 0;
			labelDiscreteInputAddress.Text = "Address:";
			// 
			// buttonDiscreteInputRead
			// 
			buttonDiscreteInputRead.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			tableLayoutPanelDiscreteInputs.SetColumnSpan(buttonDiscreteInputRead, 2);
			buttonDiscreteInputRead.Enabled = false;
			buttonDiscreteInputRead.Location = new Point(4, 126);
			buttonDiscreteInputRead.Margin = new Padding(4, 3, 4, 3);
			buttonDiscreteInputRead.Name = "buttonDiscreteInputRead";
			buttonDiscreteInputRead.Size = new Size(88, 27);
			buttonDiscreteInputRead.TabIndex = 4;
			buttonDiscreteInputRead.Text = "Read";
			buttonDiscreteInputRead.UseVisualStyleBackColor = true;
			// 
			// textBoxDiscreteInputAddressDecimal
			// 
			textBoxDiscreteInputAddressDecimal.Location = new Point(223, 3);
			textBoxDiscreteInputAddressDecimal.Margin = new Padding(4, 3, 4, 3);
			textBoxDiscreteInputAddressDecimal.Name = "textBoxDiscreteInputAddressDecimal";
			textBoxDiscreteInputAddressDecimal.Size = new Size(87, 23);
			textBoxDiscreteInputAddressDecimal.TabIndex = 7;
			textBoxDiscreteInputAddressDecimal.Leave += TextBoxDiscreteInputAddressDecimal_Leave;
			// 
			// labelDiscreteInput0d
			// 
			labelDiscreteInput0d.Anchor = AnchorStyles.Left;
			labelDiscreteInput0d.AutoSize = true;
			labelDiscreteInput0d.Location = new Point(195, 7);
			labelDiscreteInput0d.Margin = new Padding(4, 0, 4, 0);
			labelDiscreteInput0d.Name = "labelDiscreteInput0d";
			labelDiscreteInput0d.Size = new Size(20, 15);
			labelDiscreteInput0d.TabIndex = 8;
			labelDiscreteInput0d.Text = "0d";
			// 
			// textBoxDiscreteInputAddressHex
			// 
			textBoxDiscreteInputAddressHex.Location = new Point(100, 3);
			textBoxDiscreteInputAddressHex.Margin = new Padding(4, 3, 4, 3);
			textBoxDiscreteInputAddressHex.Name = "textBoxDiscreteInputAddressHex";
			textBoxDiscreteInputAddressHex.Size = new Size(87, 23);
			textBoxDiscreteInputAddressHex.TabIndex = 1;
			textBoxDiscreteInputAddressHex.Leave += TextBoxDiscreteInputAddressHex_Leave;
			// 
			// labelDiscreteInput0x
			// 
			labelDiscreteInput0x.Anchor = AnchorStyles.Left;
			labelDiscreteInput0x.AutoSize = true;
			labelDiscreteInput0x.Location = new Point(64, 7);
			labelDiscreteInput0x.Margin = new Padding(4, 0, 4, 0);
			labelDiscreteInput0x.Name = "labelDiscreteInput0x";
			labelDiscreteInput0x.Size = new Size(19, 15);
			labelDiscreteInput0x.TabIndex = 9;
			labelDiscreteInput0x.Text = "0x";
			// 
			// buttonDiscreteInputPoll
			// 
			buttonDiscreteInputPoll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			tableLayoutPanelDiscreteInputs.SetColumnSpan(buttonDiscreteInputPoll, 3);
			buttonDiscreteInputPoll.Enabled = false;
			buttonDiscreteInputPoll.Location = new Point(100, 126);
			buttonDiscreteInputPoll.Margin = new Padding(4, 3, 4, 3);
			buttonDiscreteInputPoll.Name = "buttonDiscreteInputPoll";
			buttonDiscreteInputPoll.Size = new Size(88, 27);
			buttonDiscreteInputPoll.TabIndex = 5;
			buttonDiscreteInputPoll.Text = "Poll";
			buttonDiscreteInputPoll.UseVisualStyleBackColor = true;
			// 
			// radioButtonDiscreteInputFalse
			// 
			radioButtonDiscreteInputFalse.Anchor = AnchorStyles.Left;
			radioButtonDiscreteInputFalse.AutoSize = true;
			tableLayoutPanelDiscreteInputs.SetColumnSpan(radioButtonDiscreteInputFalse, 3);
			radioButtonDiscreteInputFalse.Location = new Point(100, 57);
			radioButtonDiscreteInputFalse.Margin = new Padding(4, 3, 4, 3);
			radioButtonDiscreteInputFalse.Name = "radioButtonDiscreteInputFalse";
			radioButtonDiscreteInputFalse.Size = new Size(51, 19);
			radioButtonDiscreteInputFalse.TabIndex = 3;
			radioButtonDiscreteInputFalse.Text = "False";
			radioButtonDiscreteInputFalse.UseVisualStyleBackColor = true;
			// 
			// radioButtonDiscreteInputTrue
			// 
			radioButtonDiscreteInputTrue.Anchor = AnchorStyles.Left;
			radioButtonDiscreteInputTrue.AutoSize = true;
			radioButtonDiscreteInputTrue.Checked = true;
			tableLayoutPanelDiscreteInputs.SetColumnSpan(radioButtonDiscreteInputTrue, 3);
			radioButtonDiscreteInputTrue.Location = new Point(100, 32);
			radioButtonDiscreteInputTrue.Margin = new Padding(4, 3, 4, 3);
			radioButtonDiscreteInputTrue.Name = "radioButtonDiscreteInputTrue";
			radioButtonDiscreteInputTrue.Size = new Size(47, 19);
			radioButtonDiscreteInputTrue.TabIndex = 2;
			radioButtonDiscreteInputTrue.TabStop = true;
			radioButtonDiscreteInputTrue.Text = "True";
			radioButtonDiscreteInputTrue.UseVisualStyleBackColor = true;
			// 
			// tabPageInputRegisters
			// 
			tabPageInputRegisters.Controls.Add(tableLayoutPanelInputRegisters);
			tabPageInputRegisters.Location = new Point(4, 24);
			tabPageInputRegisters.Margin = new Padding(4, 3, 4, 3);
			tabPageInputRegisters.Name = "tabPageInputRegisters";
			tabPageInputRegisters.Padding = new Padding(4, 3, 4, 3);
			tabPageInputRegisters.Size = new Size(435, 162);
			tabPageInputRegisters.TabIndex = 0;
			tabPageInputRegisters.Text = "Input Registers";
			tabPageInputRegisters.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanelInputRegisters
			// 
			tableLayoutPanelInputRegisters.AutoSize = true;
			tableLayoutPanelInputRegisters.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			tableLayoutPanelInputRegisters.ColumnCount = 5;
			tableLayoutPanelInputRegisters.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelInputRegisters.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelInputRegisters.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelInputRegisters.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelInputRegisters.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelInputRegisters.Controls.Add(labelInputRegisterAddress, 0, 0);
			tableLayoutPanelInputRegisters.Controls.Add(buttonInputRegisterRead, 0, 4);
			tableLayoutPanelInputRegisters.Controls.Add(labelInputRegisterStringLength, 0, 2);
			tableLayoutPanelInputRegisters.Controls.Add(labelInputRegisterDataFormat, 0, 1);
			tableLayoutPanelInputRegisters.Controls.Add(labelInputRegisterData, 0, 3);
			tableLayoutPanelInputRegisters.Controls.Add(textBoxInputRegisterAddressDecimal, 4, 0);
			tableLayoutPanelInputRegisters.Controls.Add(textBoxInputRegisterAddressHex, 2, 0);
			tableLayoutPanelInputRegisters.Controls.Add(labelInputRegister0x, 1, 0);
			tableLayoutPanelInputRegisters.Controls.Add(labelInputRegister0d, 3, 0);
			tableLayoutPanelInputRegisters.Controls.Add(buttonInputRegisterPoll, 2, 4);
			tableLayoutPanelInputRegisters.Controls.Add(textBoxInputRegisterData, 2, 3);
			tableLayoutPanelInputRegisters.Controls.Add(textBoxInputRegisterStringLength, 2, 2);
			tableLayoutPanelInputRegisters.Controls.Add(comboBoxInputRegisterFormat, 2, 1);
			tableLayoutPanelInputRegisters.Dock = DockStyle.Fill;
			tableLayoutPanelInputRegisters.Location = new Point(4, 3);
			tableLayoutPanelInputRegisters.Margin = new Padding(4, 3, 4, 3);
			tableLayoutPanelInputRegisters.Name = "tableLayoutPanelInputRegisters";
			tableLayoutPanelInputRegisters.RowCount = 5;
			tableLayoutPanelInputRegisters.RowStyles.Add(new RowStyle());
			tableLayoutPanelInputRegisters.RowStyles.Add(new RowStyle());
			tableLayoutPanelInputRegisters.RowStyles.Add(new RowStyle());
			tableLayoutPanelInputRegisters.RowStyles.Add(new RowStyle());
			tableLayoutPanelInputRegisters.RowStyles.Add(new RowStyle());
			tableLayoutPanelInputRegisters.Size = new Size(427, 156);
			tableLayoutPanelInputRegisters.TabIndex = 7;
			// 
			// labelInputRegisterAddress
			// 
			labelInputRegisterAddress.Anchor = AnchorStyles.Left;
			labelInputRegisterAddress.AutoSize = true;
			labelInputRegisterAddress.Location = new Point(4, 7);
			labelInputRegisterAddress.Margin = new Padding(4, 0, 4, 0);
			labelInputRegisterAddress.Name = "labelInputRegisterAddress";
			labelInputRegisterAddress.Size = new Size(52, 15);
			labelInputRegisterAddress.TabIndex = 0;
			labelInputRegisterAddress.Text = "Address:";
			// 
			// buttonInputRegisterRead
			// 
			tableLayoutPanelInputRegisters.SetColumnSpan(buttonInputRegisterRead, 2);
			buttonInputRegisterRead.Location = new Point(4, 119);
			buttonInputRegisterRead.Margin = new Padding(4, 3, 4, 3);
			buttonInputRegisterRead.Name = "buttonInputRegisterRead";
			buttonInputRegisterRead.Size = new Size(88, 27);
			buttonInputRegisterRead.TabIndex = 6;
			buttonInputRegisterRead.Text = "Read";
			buttonInputRegisterRead.UseVisualStyleBackColor = true;
			buttonInputRegisterRead.Click += ButtonInputRegisterRead_Click;
			// 
			// labelInputRegisterStringLength
			// 
			labelInputRegisterStringLength.Anchor = AnchorStyles.Left;
			labelInputRegisterStringLength.AutoSize = true;
			tableLayoutPanelInputRegisters.SetColumnSpan(labelInputRegisterStringLength, 2);
			labelInputRegisterStringLength.Location = new Point(4, 65);
			labelInputRegisterStringLength.Margin = new Padding(4, 0, 4, 0);
			labelInputRegisterStringLength.Name = "labelInputRegisterStringLength";
			labelInputRegisterStringLength.Size = new Size(81, 15);
			labelInputRegisterStringLength.TabIndex = 7;
			labelInputRegisterStringLength.Text = "String Length:";
			// 
			// labelInputRegisterDataFormat
			// 
			labelInputRegisterDataFormat.Anchor = AnchorStyles.Left;
			labelInputRegisterDataFormat.AutoSize = true;
			tableLayoutPanelInputRegisters.SetColumnSpan(labelInputRegisterDataFormat, 2);
			labelInputRegisterDataFormat.Location = new Point(4, 36);
			labelInputRegisterDataFormat.Margin = new Padding(4, 0, 4, 0);
			labelInputRegisterDataFormat.Name = "labelInputRegisterDataFormat";
			labelInputRegisterDataFormat.Size = new Size(75, 15);
			labelInputRegisterDataFormat.TabIndex = 3;
			labelInputRegisterDataFormat.Text = "Data Format:";
			// 
			// labelInputRegisterData
			// 
			labelInputRegisterData.Anchor = AnchorStyles.Left;
			labelInputRegisterData.AutoSize = true;
			tableLayoutPanelInputRegisters.SetColumnSpan(labelInputRegisterData, 2);
			labelInputRegisterData.Location = new Point(4, 94);
			labelInputRegisterData.Margin = new Padding(4, 0, 4, 0);
			labelInputRegisterData.Name = "labelInputRegisterData";
			labelInputRegisterData.Size = new Size(38, 15);
			labelInputRegisterData.TabIndex = 4;
			labelInputRegisterData.Text = "Value:";
			// 
			// textBoxInputRegisterAddressDecimal
			// 
			textBoxInputRegisterAddressDecimal.Location = new Point(223, 3);
			textBoxInputRegisterAddressDecimal.Margin = new Padding(4, 3, 4, 3);
			textBoxInputRegisterAddressDecimal.Name = "textBoxInputRegisterAddressDecimal";
			textBoxInputRegisterAddressDecimal.Size = new Size(87, 23);
			textBoxInputRegisterAddressDecimal.TabIndex = 10;
			textBoxInputRegisterAddressDecimal.Leave += TextBoxInputRegisterAddressDecimal_Leave;
			// 
			// textBoxInputRegisterAddressHex
			// 
			textBoxInputRegisterAddressHex.Location = new Point(100, 3);
			textBoxInputRegisterAddressHex.Margin = new Padding(4, 3, 4, 3);
			textBoxInputRegisterAddressHex.Name = "textBoxInputRegisterAddressHex";
			textBoxInputRegisterAddressHex.Size = new Size(87, 23);
			textBoxInputRegisterAddressHex.TabIndex = 1;
			textBoxInputRegisterAddressHex.Leave += TextBoxInputRegisterAddressHex_Leave;
			// 
			// labelInputRegister0x
			// 
			labelInputRegister0x.Anchor = AnchorStyles.Left;
			labelInputRegister0x.AutoSize = true;
			labelInputRegister0x.Location = new Point(64, 7);
			labelInputRegister0x.Margin = new Padding(4, 0, 4, 0);
			labelInputRegister0x.Name = "labelInputRegister0x";
			labelInputRegister0x.Size = new Size(19, 15);
			labelInputRegister0x.TabIndex = 11;
			labelInputRegister0x.Text = "0x";
			// 
			// labelInputRegister0d
			// 
			labelInputRegister0d.Anchor = AnchorStyles.Left;
			labelInputRegister0d.AutoSize = true;
			labelInputRegister0d.Location = new Point(195, 7);
			labelInputRegister0d.Margin = new Padding(4, 0, 4, 0);
			labelInputRegister0d.Name = "labelInputRegister0d";
			labelInputRegister0d.Size = new Size(20, 15);
			labelInputRegister0d.TabIndex = 12;
			labelInputRegister0d.Text = "0d";
			// 
			// buttonInputRegisterPoll
			// 
			tableLayoutPanelInputRegisters.SetColumnSpan(buttonInputRegisterPoll, 3);
			buttonInputRegisterPoll.Location = new Point(100, 119);
			buttonInputRegisterPoll.Margin = new Padding(4, 3, 4, 3);
			buttonInputRegisterPoll.Name = "buttonInputRegisterPoll";
			buttonInputRegisterPoll.Size = new Size(88, 27);
			buttonInputRegisterPoll.TabIndex = 9;
			buttonInputRegisterPoll.Text = "Poll";
			buttonInputRegisterPoll.UseVisualStyleBackColor = true;
			buttonInputRegisterPoll.Click += ButtonInputPoll_Click;
			// 
			// textBoxInputRegisterData
			// 
			tableLayoutPanelInputRegisters.SetColumnSpan(textBoxInputRegisterData, 3);
			textBoxInputRegisterData.Location = new Point(100, 90);
			textBoxInputRegisterData.Margin = new Padding(4, 3, 4, 3);
			textBoxInputRegisterData.Name = "textBoxInputRegisterData";
			textBoxInputRegisterData.Size = new Size(164, 23);
			textBoxInputRegisterData.TabIndex = 5;
			// 
			// textBoxInputRegisterStringLength
			// 
			tableLayoutPanelInputRegisters.SetColumnSpan(textBoxInputRegisterStringLength, 3);
			textBoxInputRegisterStringLength.Enabled = false;
			textBoxInputRegisterStringLength.Location = new Point(100, 61);
			textBoxInputRegisterStringLength.Margin = new Padding(4, 3, 4, 3);
			textBoxInputRegisterStringLength.Name = "textBoxInputRegisterStringLength";
			textBoxInputRegisterStringLength.Size = new Size(117, 23);
			textBoxInputRegisterStringLength.TabIndex = 8;
			// 
			// comboBoxInputRegisterFormat
			// 
			tableLayoutPanelInputRegisters.SetColumnSpan(comboBoxInputRegisterFormat, 3);
			comboBoxInputRegisterFormat.FormattingEnabled = true;
			comboBoxInputRegisterFormat.Items.AddRange(new object[] { "Float", "Int32", "UInt32", "Int16", "UInt16", "String" });
			comboBoxInputRegisterFormat.Location = new Point(100, 32);
			comboBoxInputRegisterFormat.Margin = new Padding(4, 3, 4, 3);
			comboBoxInputRegisterFormat.Name = "comboBoxInputRegisterFormat";
			comboBoxInputRegisterFormat.Size = new Size(140, 23);
			comboBoxInputRegisterFormat.TabIndex = 2;
			comboBoxInputRegisterFormat.SelectedIndexChanged += ComboBoxInputRegisterFormat_SelectedIndexChanged;
			// 
			// tabPageHoldingRegisters
			// 
			tabPageHoldingRegisters.Controls.Add(tableLayoutPanelHoldingRegisters);
			tabPageHoldingRegisters.Location = new Point(4, 24);
			tabPageHoldingRegisters.Margin = new Padding(4, 3, 4, 3);
			tabPageHoldingRegisters.Name = "tabPageHoldingRegisters";
			tabPageHoldingRegisters.Padding = new Padding(4, 3, 4, 3);
			tabPageHoldingRegisters.Size = new Size(435, 162);
			tabPageHoldingRegisters.TabIndex = 1;
			tabPageHoldingRegisters.Text = "Holding Registers";
			tabPageHoldingRegisters.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanelHoldingRegisters
			// 
			tableLayoutPanelHoldingRegisters.AutoSize = true;
			tableLayoutPanelHoldingRegisters.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			tableLayoutPanelHoldingRegisters.ColumnCount = 5;
			tableLayoutPanelHoldingRegisters.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelHoldingRegisters.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelHoldingRegisters.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelHoldingRegisters.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelHoldingRegisters.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelHoldingRegisters.Controls.Add(buttonHoldingRegisterRead, 0, 4);
			tableLayoutPanelHoldingRegisters.Controls.Add(labelHoldingRegisterAddress, 0, 0);
			tableLayoutPanelHoldingRegisters.Controls.Add(labelHoldingRegisterStringLength, 0, 2);
			tableLayoutPanelHoldingRegisters.Controls.Add(labelHoldingRegisterData, 0, 3);
			tableLayoutPanelHoldingRegisters.Controls.Add(labelHoldingRegisterFormat, 0, 1);
			tableLayoutPanelHoldingRegisters.Controls.Add(textBoxHoldingRegisterAddressDecimal, 4, 0);
			tableLayoutPanelHoldingRegisters.Controls.Add(textBoxHoldingRegisterAddressHex, 2, 0);
			tableLayoutPanelHoldingRegisters.Controls.Add(labelHoldingRegister0x, 1, 0);
			tableLayoutPanelHoldingRegisters.Controls.Add(labelHoldingRegister0d, 3, 0);
			tableLayoutPanelHoldingRegisters.Controls.Add(buttonHoldingRegisterWrite, 2, 4);
			tableLayoutPanelHoldingRegisters.Controls.Add(textBoxHoldingRegisterData, 2, 3);
			tableLayoutPanelHoldingRegisters.Controls.Add(textBoxHoldingRegisterStringLength, 2, 2);
			tableLayoutPanelHoldingRegisters.Controls.Add(comboBoxHoldingRegisterFormat, 2, 1);
			tableLayoutPanelHoldingRegisters.Dock = DockStyle.Fill;
			tableLayoutPanelHoldingRegisters.Location = new Point(4, 3);
			tableLayoutPanelHoldingRegisters.Margin = new Padding(4, 3, 4, 3);
			tableLayoutPanelHoldingRegisters.Name = "tableLayoutPanelHoldingRegisters";
			tableLayoutPanelHoldingRegisters.RowCount = 5;
			tableLayoutPanelHoldingRegisters.RowStyles.Add(new RowStyle());
			tableLayoutPanelHoldingRegisters.RowStyles.Add(new RowStyle());
			tableLayoutPanelHoldingRegisters.RowStyles.Add(new RowStyle());
			tableLayoutPanelHoldingRegisters.RowStyles.Add(new RowStyle());
			tableLayoutPanelHoldingRegisters.RowStyles.Add(new RowStyle());
			tableLayoutPanelHoldingRegisters.Size = new Size(427, 156);
			tableLayoutPanelHoldingRegisters.TabIndex = 7;
			// 
			// buttonHoldingRegisterRead
			// 
			tableLayoutPanelHoldingRegisters.SetColumnSpan(buttonHoldingRegisterRead, 2);
			buttonHoldingRegisterRead.Location = new Point(4, 119);
			buttonHoldingRegisterRead.Margin = new Padding(4, 3, 4, 3);
			buttonHoldingRegisterRead.Name = "buttonHoldingRegisterRead";
			buttonHoldingRegisterRead.Size = new Size(88, 27);
			buttonHoldingRegisterRead.TabIndex = 6;
			buttonHoldingRegisterRead.Text = "Read";
			buttonHoldingRegisterRead.UseVisualStyleBackColor = true;
			buttonHoldingRegisterRead.Click += ButtonHoldingRegisterRead_Click;
			// 
			// labelHoldingRegisterAddress
			// 
			labelHoldingRegisterAddress.Anchor = AnchorStyles.Left;
			labelHoldingRegisterAddress.AutoSize = true;
			labelHoldingRegisterAddress.Location = new Point(4, 7);
			labelHoldingRegisterAddress.Margin = new Padding(4, 0, 4, 0);
			labelHoldingRegisterAddress.Name = "labelHoldingRegisterAddress";
			labelHoldingRegisterAddress.Size = new Size(52, 15);
			labelHoldingRegisterAddress.TabIndex = 0;
			labelHoldingRegisterAddress.Text = "Address:";
			// 
			// labelHoldingRegisterStringLength
			// 
			labelHoldingRegisterStringLength.Anchor = AnchorStyles.Left;
			labelHoldingRegisterStringLength.AutoSize = true;
			tableLayoutPanelHoldingRegisters.SetColumnSpan(labelHoldingRegisterStringLength, 2);
			labelHoldingRegisterStringLength.Location = new Point(4, 65);
			labelHoldingRegisterStringLength.Margin = new Padding(4, 0, 4, 0);
			labelHoldingRegisterStringLength.Name = "labelHoldingRegisterStringLength";
			labelHoldingRegisterStringLength.Size = new Size(81, 15);
			labelHoldingRegisterStringLength.TabIndex = 8;
			labelHoldingRegisterStringLength.Text = "String Length:";
			// 
			// labelHoldingRegisterData
			// 
			labelHoldingRegisterData.Anchor = AnchorStyles.Left;
			labelHoldingRegisterData.AutoSize = true;
			tableLayoutPanelHoldingRegisters.SetColumnSpan(labelHoldingRegisterData, 2);
			labelHoldingRegisterData.Location = new Point(4, 94);
			labelHoldingRegisterData.Margin = new Padding(4, 0, 4, 0);
			labelHoldingRegisterData.Name = "labelHoldingRegisterData";
			labelHoldingRegisterData.Size = new Size(38, 15);
			labelHoldingRegisterData.TabIndex = 4;
			labelHoldingRegisterData.Text = "Value:";
			// 
			// labelHoldingRegisterFormat
			// 
			labelHoldingRegisterFormat.Anchor = AnchorStyles.Left;
			labelHoldingRegisterFormat.AutoSize = true;
			tableLayoutPanelHoldingRegisters.SetColumnSpan(labelHoldingRegisterFormat, 2);
			labelHoldingRegisterFormat.Location = new Point(4, 36);
			labelHoldingRegisterFormat.Margin = new Padding(4, 0, 4, 0);
			labelHoldingRegisterFormat.Name = "labelHoldingRegisterFormat";
			labelHoldingRegisterFormat.Size = new Size(75, 15);
			labelHoldingRegisterFormat.TabIndex = 2;
			labelHoldingRegisterFormat.Text = "Data Format:";
			// 
			// textBoxHoldingRegisterAddressDecimal
			// 
			textBoxHoldingRegisterAddressDecimal.Location = new Point(223, 3);
			textBoxHoldingRegisterAddressDecimal.Margin = new Padding(4, 3, 4, 3);
			textBoxHoldingRegisterAddressDecimal.Name = "textBoxHoldingRegisterAddressDecimal";
			textBoxHoldingRegisterAddressDecimal.Size = new Size(87, 23);
			textBoxHoldingRegisterAddressDecimal.TabIndex = 10;
			textBoxHoldingRegisterAddressDecimal.Leave += TextBoxHoldingRegisterAddressDecimal_Leave;
			// 
			// textBoxHoldingRegisterAddressHex
			// 
			textBoxHoldingRegisterAddressHex.Location = new Point(100, 3);
			textBoxHoldingRegisterAddressHex.Margin = new Padding(4, 3, 4, 3);
			textBoxHoldingRegisterAddressHex.Name = "textBoxHoldingRegisterAddressHex";
			textBoxHoldingRegisterAddressHex.Size = new Size(87, 23);
			textBoxHoldingRegisterAddressHex.TabIndex = 1;
			textBoxHoldingRegisterAddressHex.Leave += TextBoxHoldingRegisterAddressHex_Leave;
			// 
			// labelHoldingRegister0x
			// 
			labelHoldingRegister0x.Anchor = AnchorStyles.Left;
			labelHoldingRegister0x.AutoSize = true;
			labelHoldingRegister0x.Location = new Point(64, 7);
			labelHoldingRegister0x.Margin = new Padding(4, 0, 4, 0);
			labelHoldingRegister0x.Name = "labelHoldingRegister0x";
			labelHoldingRegister0x.Size = new Size(19, 15);
			labelHoldingRegister0x.TabIndex = 11;
			labelHoldingRegister0x.Text = "0x";
			// 
			// labelHoldingRegister0d
			// 
			labelHoldingRegister0d.Anchor = AnchorStyles.Left;
			labelHoldingRegister0d.AutoSize = true;
			labelHoldingRegister0d.Location = new Point(195, 7);
			labelHoldingRegister0d.Margin = new Padding(4, 0, 4, 0);
			labelHoldingRegister0d.Name = "labelHoldingRegister0d";
			labelHoldingRegister0d.Size = new Size(20, 15);
			labelHoldingRegister0d.TabIndex = 12;
			labelHoldingRegister0d.Text = "0d";
			// 
			// buttonHoldingRegisterWrite
			// 
			tableLayoutPanelHoldingRegisters.SetColumnSpan(buttonHoldingRegisterWrite, 3);
			buttonHoldingRegisterWrite.Location = new Point(100, 119);
			buttonHoldingRegisterWrite.Margin = new Padding(4, 3, 4, 3);
			buttonHoldingRegisterWrite.Name = "buttonHoldingRegisterWrite";
			buttonHoldingRegisterWrite.Size = new Size(88, 27);
			buttonHoldingRegisterWrite.TabIndex = 7;
			buttonHoldingRegisterWrite.Text = "Write";
			buttonHoldingRegisterWrite.UseVisualStyleBackColor = true;
			buttonHoldingRegisterWrite.Click += ButtonHoldingRegisterWrite_Click;
			// 
			// textBoxHoldingRegisterData
			// 
			tableLayoutPanelHoldingRegisters.SetColumnSpan(textBoxHoldingRegisterData, 3);
			textBoxHoldingRegisterData.Location = new Point(100, 90);
			textBoxHoldingRegisterData.Margin = new Padding(4, 3, 4, 3);
			textBoxHoldingRegisterData.Name = "textBoxHoldingRegisterData";
			textBoxHoldingRegisterData.Size = new Size(164, 23);
			textBoxHoldingRegisterData.TabIndex = 5;
			// 
			// textBoxHoldingRegisterStringLength
			// 
			tableLayoutPanelHoldingRegisters.SetColumnSpan(textBoxHoldingRegisterStringLength, 3);
			textBoxHoldingRegisterStringLength.Enabled = false;
			textBoxHoldingRegisterStringLength.Location = new Point(100, 61);
			textBoxHoldingRegisterStringLength.Margin = new Padding(4, 3, 4, 3);
			textBoxHoldingRegisterStringLength.Name = "textBoxHoldingRegisterStringLength";
			textBoxHoldingRegisterStringLength.Size = new Size(116, 23);
			textBoxHoldingRegisterStringLength.TabIndex = 9;
			// 
			// comboBoxHoldingRegisterFormat
			// 
			tableLayoutPanelHoldingRegisters.SetColumnSpan(comboBoxHoldingRegisterFormat, 3);
			comboBoxHoldingRegisterFormat.FormattingEnabled = true;
			comboBoxHoldingRegisterFormat.Items.AddRange(new object[] { "Float", "Int32", "UInt32", "Int16", "UInt16", "String" });
			comboBoxHoldingRegisterFormat.Location = new Point(100, 32);
			comboBoxHoldingRegisterFormat.Margin = new Padding(4, 3, 4, 3);
			comboBoxHoldingRegisterFormat.Name = "comboBoxHoldingRegisterFormat";
			comboBoxHoldingRegisterFormat.Size = new Size(140, 23);
			comboBoxHoldingRegisterFormat.TabIndex = 3;
			comboBoxHoldingRegisterFormat.SelectedIndexChanged += ComboBoxHoldingRegisterFormat_SelectedIndexChanged;
			// 
			// groupBoxData
			// 
			groupBoxData.AutoSize = true;
			groupBoxData.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			groupBoxData.Controls.Add(tabControlData);
			groupBoxData.Dock = DockStyle.Top;
			groupBoxData.Enabled = false;
			groupBoxData.Location = new Point(0, 188);
			groupBoxData.Margin = new Padding(4, 3, 4, 3);
			groupBoxData.Name = "groupBoxData";
			groupBoxData.Padding = new Padding(4, 3, 4, 3);
			groupBoxData.Size = new Size(451, 212);
			groupBoxData.TabIndex = 8;
			groupBoxData.TabStop = false;
			groupBoxData.Text = "Data";
			// 
			// FormModbus
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(451, 441);
			Controls.Add(groupBoxData);
			Controls.Add(groupBoxAddress);
			Controls.Add(groupBoxSerialPort);
			Controls.Add(statusStrip1);
			Controls.Add(mainMenuStrip);
			MainMenuStrip = mainMenuStrip;
			Margin = new Padding(4, 3, 4, 3);
			MaximizeBox = false;
			Name = "FormModbus";
			Text = "Modbus Interface";
			FormClosed += FormModbus_FormClosed;
			mainMenuStrip.ResumeLayout(false);
			mainMenuStrip.PerformLayout();
			groupBoxSerialPort.ResumeLayout(false);
			groupBoxSerialPort.PerformLayout();
			tableLayoutPanelSerialPort.ResumeLayout(false);
			tableLayoutPanelSerialPort.PerformLayout();
			statusStrip1.ResumeLayout(false);
			statusStrip1.PerformLayout();
			groupBoxAddress.ResumeLayout(false);
			groupBoxAddress.PerformLayout();
			tableLayoutPanelCommunication.ResumeLayout(false);
			tableLayoutPanelCommunication.PerformLayout();
			tabControlData.ResumeLayout(false);
			tabPageCoils.ResumeLayout(false);
			tabPageCoils.PerformLayout();
			tableLayoutPanelCoils.ResumeLayout(false);
			tableLayoutPanelCoils.PerformLayout();
			tabPageDiscreteInputs.ResumeLayout(false);
			tabPageDiscreteInputs.PerformLayout();
			tableLayoutPanelDiscreteInputs.ResumeLayout(false);
			tableLayoutPanelDiscreteInputs.PerformLayout();
			tabPageInputRegisters.ResumeLayout(false);
			tabPageInputRegisters.PerformLayout();
			tableLayoutPanelInputRegisters.ResumeLayout(false);
			tableLayoutPanelInputRegisters.PerformLayout();
			tabPageHoldingRegisters.ResumeLayout(false);
			tabPageHoldingRegisters.PerformLayout();
			tableLayoutPanelHoldingRegisters.ResumeLayout(false);
			tableLayoutPanelHoldingRegisters.PerformLayout();
			groupBoxData.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.MenuStrip mainMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.GroupBox groupBoxSerialPort;
		private System.Windows.Forms.ComboBox comboBoxParity;
		private System.Windows.Forms.Label labelParity;
		private System.Windows.Forms.ComboBox comboBoxBaudRate;
		private System.Windows.Forms.Label labelBaudRate;
		private System.Windows.Forms.Button buttonPortRefresh;
		private System.Windows.Forms.ComboBox comboBoxSerialPort;
		private System.Windows.Forms.Label labelComPort;
		private System.Windows.Forms.ComboBox comboBoxMode;
		private System.Windows.Forms.Label labelMode;
		private System.Windows.Forms.Label labelDeviceAddress;
		private System.Windows.Forms.TextBox textBoxDeviceAddressHex;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel labelMainStatus;
		private System.Windows.Forms.ComboBox comboBoxStopBits;
		private System.Windows.Forms.Label labelStopBits;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSerialPort;
		private System.Windows.Forms.GroupBox groupBoxAddress;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCommunication;
		private System.Windows.Forms.RadioButton radioButtonOpen;
		private System.Windows.Forms.RadioButton radioButtonClosed;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.Label labelDeviceAddress0d;
		private System.Windows.Forms.TextBox textBoxDeviceAddressDecimal;
		private System.Windows.Forms.TabControl tabControlData;
		private System.Windows.Forms.TabPage tabPageCoils;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCoils;
		private System.Windows.Forms.Label labelCoilValue;
		private System.Windows.Forms.Label labelCoilAddress;
		private System.Windows.Forms.Button buttonCoilRead;
		private System.Windows.Forms.TextBox textBoxCoilAddressHex;
		private System.Windows.Forms.Label labelCoil0x;
		private System.Windows.Forms.Label labelCoil0d;
		private System.Windows.Forms.TextBox textBoxCoilAddressDecimal;
		private System.Windows.Forms.Button buttonCoilWrite;
		private System.Windows.Forms.RadioButton radioButtonCoilFalse;
		private System.Windows.Forms.RadioButton radioButtonCoilTrue;
		private System.Windows.Forms.TabPage tabPageDiscreteInputs;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDiscreteInputs;
		private System.Windows.Forms.Label labelDiscreteInputValue;
		private System.Windows.Forms.Label labelDiscreteInputAddress;
		private System.Windows.Forms.Button buttonDiscreteInputRead;
		private System.Windows.Forms.TextBox textBoxDiscreteInputAddressDecimal;
		private System.Windows.Forms.Label labelDiscreteInput0d;
		private System.Windows.Forms.TextBox textBoxDiscreteInputAddressHex;
		private System.Windows.Forms.Label labelDiscreteInput0x;
		private System.Windows.Forms.Button buttonDiscreteInputPoll;
		private System.Windows.Forms.RadioButton radioButtonDiscreteInputFalse;
		private System.Windows.Forms.RadioButton radioButtonDiscreteInputTrue;
		private System.Windows.Forms.TabPage tabPageInputRegisters;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelInputRegisters;
		private System.Windows.Forms.Label labelInputRegisterAddress;
		private System.Windows.Forms.Button buttonInputRegisterRead;
		private System.Windows.Forms.Label labelInputRegisterStringLength;
		private System.Windows.Forms.Label labelInputRegisterDataFormat;
		private System.Windows.Forms.Label labelInputRegisterData;
		private System.Windows.Forms.TextBox textBoxInputRegisterAddressDecimal;
		private System.Windows.Forms.TextBox textBoxInputRegisterAddressHex;
		private System.Windows.Forms.Label labelInputRegister0x;
		private System.Windows.Forms.Label labelInputRegister0d;
		private System.Windows.Forms.Button buttonInputRegisterPoll;
		private System.Windows.Forms.TextBox textBoxInputRegisterData;
		private System.Windows.Forms.TextBox textBoxInputRegisterStringLength;
		private System.Windows.Forms.ComboBox comboBoxInputRegisterFormat;
		private System.Windows.Forms.TabPage tabPageHoldingRegisters;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHoldingRegisters;
		private System.Windows.Forms.Button buttonHoldingRegisterRead;
		private System.Windows.Forms.Label labelHoldingRegisterAddress;
		private System.Windows.Forms.Label labelHoldingRegisterStringLength;
		private System.Windows.Forms.Label labelHoldingRegisterData;
		private System.Windows.Forms.Label labelHoldingRegisterFormat;
		private System.Windows.Forms.TextBox textBoxHoldingRegisterAddressDecimal;
		private System.Windows.Forms.TextBox textBoxHoldingRegisterAddressHex;
		private System.Windows.Forms.Label labelHoldingRegister0x;
		private System.Windows.Forms.Label labelHoldingRegister0d;
		private System.Windows.Forms.Button buttonHoldingRegisterWrite;
		private System.Windows.Forms.TextBox textBoxHoldingRegisterData;
		private System.Windows.Forms.TextBox textBoxHoldingRegisterStringLength;
		private System.Windows.Forms.ComboBox comboBoxHoldingRegisterFormat;
		private System.Windows.Forms.GroupBox groupBoxData;
		private System.Windows.Forms.Label labelDeviceAddress0x;
	}
}

