namespace Sensit.App.Relay
{
	partial class FormRelay
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
			menuStrip1 = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			exitToolStripMenuItem = new ToolStripMenuItem();
			statusStrip1 = new StatusStrip();
			toolStripStatusLabel = new ToolStripStatusLabel();
			groupBoxSerialPort = new GroupBox();
			radioButtonClosed = new RadioButton();
			radioButtonOpen = new RadioButton();
			comboBoxSerialPort = new ComboBox();
			groupBoxMassFlow = new GroupBox();
			tableLayoutPanel1 = new TableLayoutPanel();
			labelPressure = new Label();
			labelTemperature = new Label();
			groupBoxAddress = new GroupBox();
			tableLayoutPanel2 = new TableLayoutPanel();
			numericUpDownAddress = new NumericUpDown();
			buttonReadAddress = new Button();
			buttonWriteAddress = new Button();
			groupBoxDigitalInputs = new GroupBox();
			tableLayoutPanel3 = new TableLayoutPanel();
			textBox3 = new TextBox();
			label3 = new Label();
			textBox1 = new TextBox();
			textBoxPressure = new TextBox();
			label1 = new Label();
			label2 = new Label();
			label4 = new Label();
			textBox2 = new TextBox();
			groupBoxAnalogInputs = new GroupBox();
			tableLayoutPanel4 = new TableLayoutPanel();
			label5 = new Label();
			label6 = new Label();
			label7 = new Label();
			label8 = new Label();
			progressBar1 = new ProgressBar();
			progressBar2 = new ProgressBar();
			progressBar3 = new ProgressBar();
			progressBar4 = new ProgressBar();
			groupBoxRelays = new GroupBox();
			tableLayoutPanel5 = new TableLayoutPanel();
			button1 = new Button();
			button2 = new Button();
			buttonToggle1 = new Button();
			buttonToggle2 = new Button();
			buttonToggle3 = new Button();
			buttonToggle4 = new Button();
			buttonToggle5 = new Button();
			buttonToggle8 = new Button();
			buttonToggle6 = new Button();
			buttonToggle7 = new Button();
			buttonAllOn = new Button();
			buttonAllOff = new Button();
			menuStrip1.SuspendLayout();
			statusStrip1.SuspendLayout();
			groupBoxSerialPort.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			groupBoxAddress.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDownAddress).BeginInit();
			groupBoxDigitalInputs.SuspendLayout();
			tableLayoutPanel3.SuspendLayout();
			groupBoxAnalogInputs.SuspendLayout();
			tableLayoutPanel4.SuspendLayout();
			groupBoxRelays.SuspendLayout();
			tableLayoutPanel5.SuspendLayout();
			SuspendLayout();
			// 
			// menuStrip1
			// 
			menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Padding = new Padding(7, 2, 0, 2);
			menuStrip1.Size = new Size(434, 24);
			menuStrip1.TabIndex = 2;
			menuStrip1.Text = "menuStrip1";
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
			exitToolStripMenuItem.Text = "&Exit";
			// 
			// statusStrip1
			// 
			statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
			statusStrip1.Location = new Point(0, 489);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Padding = new Padding(1, 0, 16, 0);
			statusStrip1.Size = new Size(434, 22);
			statusStrip1.TabIndex = 3;
			statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel
			// 
			toolStripStatusLabel.Name = "toolStripStatusLabel";
			toolStripStatusLabel.Size = new Size(39, 17);
			toolStripStatusLabel.Text = "Ready";
			// 
			// groupBoxSerialPort
			// 
			groupBoxSerialPort.AutoSize = true;
			groupBoxSerialPort.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			groupBoxSerialPort.Controls.Add(radioButtonClosed);
			groupBoxSerialPort.Controls.Add(radioButtonOpen);
			groupBoxSerialPort.Controls.Add(comboBoxSerialPort);
			groupBoxSerialPort.Dock = DockStyle.Top;
			groupBoxSerialPort.Location = new Point(0, 24);
			groupBoxSerialPort.Margin = new Padding(4, 3, 4, 3);
			groupBoxSerialPort.Name = "groupBoxSerialPort";
			groupBoxSerialPort.Padding = new Padding(4, 3, 4, 3);
			groupBoxSerialPort.Size = new Size(434, 68);
			groupBoxSerialPort.TabIndex = 4;
			groupBoxSerialPort.TabStop = false;
			groupBoxSerialPort.Text = "Serial Port";
			// 
			// radioButtonClosed
			// 
			radioButtonClosed.AutoSize = true;
			radioButtonClosed.Checked = true;
			radioButtonClosed.Location = new Point(233, 27);
			radioButtonClosed.Margin = new Padding(4, 3, 4, 3);
			radioButtonClosed.Name = "radioButtonClosed";
			radioButtonClosed.Size = new Size(61, 19);
			radioButtonClosed.TabIndex = 2;
			radioButtonClosed.TabStop = true;
			radioButtonClosed.Text = "Closed";
			radioButtonClosed.UseVisualStyleBackColor = true;
			// 
			// radioButtonOpen
			// 
			radioButtonOpen.AutoSize = true;
			radioButtonOpen.Location = new Point(165, 27);
			radioButtonOpen.Margin = new Padding(4, 3, 4, 3);
			radioButtonOpen.Name = "radioButtonOpen";
			radioButtonOpen.Size = new Size(54, 19);
			radioButtonOpen.TabIndex = 1;
			radioButtonOpen.Text = "Open";
			radioButtonOpen.UseVisualStyleBackColor = true;
			// 
			// comboBoxSerialPort
			// 
			comboBoxSerialPort.FormattingEnabled = true;
			comboBoxSerialPort.Location = new Point(15, 23);
			comboBoxSerialPort.Margin = new Padding(4, 3, 4, 3);
			comboBoxSerialPort.Name = "comboBoxSerialPort";
			comboBoxSerialPort.Size = new Size(140, 23);
			comboBoxSerialPort.TabIndex = 0;
			// 
			// groupBoxMassFlow
			// 
			groupBoxMassFlow.Location = new Point(0, 0);
			groupBoxMassFlow.Name = "groupBoxMassFlow";
			groupBoxMassFlow.Size = new Size(200, 100);
			groupBoxMassFlow.TabIndex = 0;
			groupBoxMassFlow.TabStop = false;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.AutoSize = true;
			tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			tableLayoutPanel1.ColumnCount = 4;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanel1.Controls.Add(labelPressure, 0, 0);
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 1;
			tableLayoutPanel1.Size = new Size(200, 100);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// labelPressure
			// 
			labelPressure.Anchor = AnchorStyles.Left;
			labelPressure.AutoSize = true;
			labelPressure.Location = new Point(4, 42);
			labelPressure.Margin = new Padding(4, 0, 4, 0);
			labelPressure.Name = "labelPressure";
			labelPressure.Size = new Size(51, 15);
			labelPressure.TabIndex = 0;
			labelPressure.Text = "Pressure";
			// 
			// labelTemperature
			// 
			labelTemperature.Anchor = AnchorStyles.Left;
			labelTemperature.AutoSize = true;
			labelTemperature.Location = new Point(4, 50);
			labelTemperature.Margin = new Padding(4, 0, 4, 0);
			labelTemperature.Name = "labelTemperature";
			labelTemperature.Size = new Size(73, 15);
			labelTemperature.TabIndex = 1;
			labelTemperature.Text = "Temperature";
			// 
			// groupBoxAddress
			// 
			groupBoxAddress.AutoSize = true;
			groupBoxAddress.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			groupBoxAddress.Controls.Add(tableLayoutPanel2);
			groupBoxAddress.Dock = DockStyle.Top;
			groupBoxAddress.Enabled = false;
			groupBoxAddress.Location = new Point(0, 92);
			groupBoxAddress.Margin = new Padding(4, 3, 4, 3);
			groupBoxAddress.Name = "groupBoxAddress";
			groupBoxAddress.Padding = new Padding(4, 3, 4, 3);
			groupBoxAddress.Size = new Size(434, 77);
			groupBoxAddress.TabIndex = 5;
			groupBoxAddress.TabStop = false;
			groupBoxAddress.Text = "Address";
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.AutoSize = true;
			tableLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			tableLayoutPanel2.ColumnCount = 3;
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanel2.Controls.Add(numericUpDownAddress, 0, 0);
			tableLayoutPanel2.Controls.Add(buttonReadAddress, 1, 0);
			tableLayoutPanel2.Controls.Add(buttonWriteAddress, 2, 0);
			tableLayoutPanel2.Location = new Point(8, 22);
			tableLayoutPanel2.Margin = new Padding(4, 3, 4, 3);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 1;
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			tableLayoutPanel2.Size = new Size(260, 33);
			tableLayoutPanel2.TabIndex = 1;
			// 
			// numericUpDownAddress
			// 
			numericUpDownAddress.Enabled = false;
			numericUpDownAddress.Location = new Point(4, 4);
			numericUpDownAddress.Margin = new Padding(4);
			numericUpDownAddress.Maximum = new decimal(new int[] { 36000000, 0, 0, 0 });
			numericUpDownAddress.Name = "numericUpDownAddress";
			numericUpDownAddress.Size = new Size(60, 23);
			numericUpDownAddress.TabIndex = 23;
			numericUpDownAddress.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// buttonReadAddress
			// 
			buttonReadAddress.Location = new Point(72, 3);
			buttonReadAddress.Margin = new Padding(4, 3, 4, 3);
			buttonReadAddress.Name = "buttonReadAddress";
			buttonReadAddress.Size = new Size(88, 27);
			buttonReadAddress.TabIndex = 2;
			buttonReadAddress.Text = "Read";
			buttonReadAddress.UseVisualStyleBackColor = true;
			// 
			// buttonWriteAddress
			// 
			buttonWriteAddress.Location = new Point(168, 3);
			buttonWriteAddress.Margin = new Padding(4, 3, 4, 3);
			buttonWriteAddress.Name = "buttonWriteAddress";
			buttonWriteAddress.Size = new Size(88, 27);
			buttonWriteAddress.TabIndex = 17;
			buttonWriteAddress.Text = "Write";
			buttonWriteAddress.UseVisualStyleBackColor = true;
			// 
			// groupBoxDigitalInputs
			// 
			groupBoxDigitalInputs.AutoSize = true;
			groupBoxDigitalInputs.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			groupBoxDigitalInputs.Controls.Add(button1);
			groupBoxDigitalInputs.Controls.Add(tableLayoutPanel3);
			groupBoxDigitalInputs.Dock = DockStyle.Top;
			groupBoxDigitalInputs.Enabled = false;
			groupBoxDigitalInputs.Location = new Point(0, 169);
			groupBoxDigitalInputs.Margin = new Padding(4, 3, 4, 3);
			groupBoxDigitalInputs.Name = "groupBoxDigitalInputs";
			groupBoxDigitalInputs.Padding = new Padding(4, 3, 4, 3);
			groupBoxDigitalInputs.Size = new Size(434, 88);
			groupBoxDigitalInputs.TabIndex = 6;
			groupBoxDigitalInputs.TabStop = false;
			groupBoxDigitalInputs.Text = "Digital Inputs";
			// 
			// tableLayoutPanel3
			// 
			tableLayoutPanel3.AutoSize = true;
			tableLayoutPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			tableLayoutPanel3.ColumnCount = 4;
			tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanel3.Controls.Add(textBox3, 0, 1);
			tableLayoutPanel3.Controls.Add(label3, 2, 0);
			tableLayoutPanel3.Controls.Add(textBox1, 0, 1);
			tableLayoutPanel3.Controls.Add(textBoxPressure, 0, 1);
			tableLayoutPanel3.Controls.Add(label1, 0, 0);
			tableLayoutPanel3.Controls.Add(label2, 1, 0);
			tableLayoutPanel3.Controls.Add(label4, 3, 0);
			tableLayoutPanel3.Controls.Add(textBox2, 1, 1);
			tableLayoutPanel3.Location = new Point(9, 22);
			tableLayoutPanel3.Margin = new Padding(4, 3, 4, 3);
			tableLayoutPanel3.Name = "tableLayoutPanel3";
			tableLayoutPanel3.RowCount = 2;
			tableLayoutPanel3.RowStyles.Add(new RowStyle());
			tableLayoutPanel3.RowStyles.Add(new RowStyle());
			tableLayoutPanel3.Size = new Size(192, 44);
			tableLayoutPanel3.TabIndex = 1;
			// 
			// textBox3
			// 
			textBox3.Location = new Point(4, 18);
			textBox3.Margin = new Padding(4, 3, 4, 3);
			textBox3.Name = "textBox3";
			textBox3.ReadOnly = true;
			textBox3.Size = new Size(40, 23);
			textBox3.TabIndex = 24;
			// 
			// label3
			// 
			label3.Anchor = AnchorStyles.None;
			label3.AutoSize = true;
			label3.Location = new Point(113, 0);
			label3.Margin = new Padding(4, 0, 4, 0);
			label3.Name = "label3";
			label3.Size = new Size(13, 15);
			label3.TabIndex = 21;
			label3.Text = "3";
			// 
			// textBox1
			// 
			textBox1.Location = new Point(52, 18);
			textBox1.Margin = new Padding(4, 3, 4, 3);
			textBox1.Name = "textBox1";
			textBox1.ReadOnly = true;
			textBox1.Size = new Size(40, 23);
			textBox1.TabIndex = 21;
			// 
			// textBoxPressure
			// 
			textBoxPressure.Location = new Point(100, 18);
			textBoxPressure.Margin = new Padding(4, 3, 4, 3);
			textBoxPressure.Name = "textBoxPressure";
			textBoxPressure.ReadOnly = true;
			textBoxPressure.Size = new Size(40, 23);
			textBoxPressure.TabIndex = 19;
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.None;
			label1.AutoSize = true;
			label1.Location = new Point(17, 0);
			label1.Margin = new Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new Size(13, 15);
			label1.TabIndex = 18;
			label1.Text = "1";
			// 
			// label2
			// 
			label2.Anchor = AnchorStyles.None;
			label2.AutoSize = true;
			label2.Location = new Point(65, 0);
			label2.Margin = new Padding(4, 0, 4, 0);
			label2.Name = "label2";
			label2.Size = new Size(13, 15);
			label2.TabIndex = 20;
			label2.Text = "2";
			// 
			// label4
			// 
			label4.Anchor = AnchorStyles.None;
			label4.AutoSize = true;
			label4.Location = new Point(161, 0);
			label4.Margin = new Padding(4, 0, 4, 0);
			label4.Name = "label4";
			label4.Size = new Size(13, 15);
			label4.TabIndex = 23;
			label4.Text = "4";
			// 
			// textBox2
			// 
			textBox2.Location = new Point(148, 18);
			textBox2.Margin = new Padding(4, 3, 4, 3);
			textBox2.Name = "textBox2";
			textBox2.ReadOnly = true;
			textBox2.Size = new Size(40, 23);
			textBox2.TabIndex = 22;
			// 
			// groupBoxAnalogInputs
			// 
			groupBoxAnalogInputs.AutoSize = true;
			groupBoxAnalogInputs.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			groupBoxAnalogInputs.Controls.Add(button2);
			groupBoxAnalogInputs.Controls.Add(tableLayoutPanel4);
			groupBoxAnalogInputs.Dock = DockStyle.Top;
			groupBoxAnalogInputs.Enabled = false;
			groupBoxAnalogInputs.Location = new Point(0, 257);
			groupBoxAnalogInputs.Margin = new Padding(4, 3, 4, 3);
			groupBoxAnalogInputs.Name = "groupBoxAnalogInputs";
			groupBoxAnalogInputs.Padding = new Padding(4, 3, 4, 3);
			groupBoxAnalogInputs.Size = new Size(434, 128);
			groupBoxAnalogInputs.TabIndex = 7;
			groupBoxAnalogInputs.TabStop = false;
			groupBoxAnalogInputs.Text = "Analog Inputs";
			// 
			// tableLayoutPanel4
			// 
			tableLayoutPanel4.AutoSize = true;
			tableLayoutPanel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			tableLayoutPanel4.ColumnCount = 2;
			tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanel4.Controls.Add(label6, 0, 0);
			tableLayoutPanel4.Controls.Add(label7, 0, 1);
			tableLayoutPanel4.Controls.Add(label5, 0, 2);
			tableLayoutPanel4.Controls.Add(label8, 0, 3);
			tableLayoutPanel4.Controls.Add(progressBar1, 1, 0);
			tableLayoutPanel4.Controls.Add(progressBar2, 1, 1);
			tableLayoutPanel4.Controls.Add(progressBar3, 1, 2);
			tableLayoutPanel4.Controls.Add(progressBar4, 1, 3);
			tableLayoutPanel4.Location = new Point(10, 22);
			tableLayoutPanel4.Margin = new Padding(4, 3, 4, 3);
			tableLayoutPanel4.Name = "tableLayoutPanel4";
			tableLayoutPanel4.RowCount = 4;
			tableLayoutPanel4.RowStyles.Add(new RowStyle());
			tableLayoutPanel4.RowStyles.Add(new RowStyle());
			tableLayoutPanel4.RowStyles.Add(new RowStyle());
			tableLayoutPanel4.RowStyles.Add(new RowStyle());
			tableLayoutPanel4.Size = new Size(237, 84);
			tableLayoutPanel4.TabIndex = 1;
			// 
			// label5
			// 
			label5.Anchor = AnchorStyles.None;
			label5.AutoSize = true;
			label5.Location = new Point(4, 45);
			label5.Margin = new Padding(4, 0, 4, 0);
			label5.Name = "label5";
			label5.Size = new Size(13, 15);
			label5.TabIndex = 21;
			label5.Text = "3";
			// 
			// label6
			// 
			label6.Anchor = AnchorStyles.None;
			label6.AutoSize = true;
			label6.Location = new Point(4, 3);
			label6.Margin = new Padding(4, 0, 4, 0);
			label6.Name = "label6";
			label6.Size = new Size(13, 15);
			label6.TabIndex = 18;
			label6.Text = "1";
			// 
			// label7
			// 
			label7.Anchor = AnchorStyles.None;
			label7.AutoSize = true;
			label7.Location = new Point(4, 24);
			label7.Margin = new Padding(4, 0, 4, 0);
			label7.Name = "label7";
			label7.Size = new Size(13, 15);
			label7.TabIndex = 20;
			label7.Text = "2";
			// 
			// label8
			// 
			label8.Anchor = AnchorStyles.None;
			label8.AutoSize = true;
			label8.Location = new Point(4, 66);
			label8.Margin = new Padding(4, 0, 4, 0);
			label8.Name = "label8";
			label8.Size = new Size(13, 15);
			label8.TabIndex = 23;
			label8.Text = "4";
			// 
			// progressBar1
			// 
			progressBar1.Location = new Point(25, 3);
			progressBar1.Margin = new Padding(4, 3, 4, 3);
			progressBar1.Maximum = 1023;
			progressBar1.Name = "progressBar1";
			progressBar1.Size = new Size(208, 15);
			progressBar1.Step = 1;
			progressBar1.Style = ProgressBarStyle.Continuous;
			progressBar1.TabIndex = 24;
			progressBar1.Value = 512;
			// 
			// progressBar2
			// 
			progressBar2.Location = new Point(25, 24);
			progressBar2.Margin = new Padding(4, 3, 4, 3);
			progressBar2.Maximum = 1023;
			progressBar2.Name = "progressBar2";
			progressBar2.Size = new Size(208, 15);
			progressBar2.Step = 1;
			progressBar2.Style = ProgressBarStyle.Continuous;
			progressBar2.TabIndex = 25;
			progressBar2.Value = 512;
			// 
			// progressBar3
			// 
			progressBar3.Location = new Point(25, 45);
			progressBar3.Margin = new Padding(4, 3, 4, 3);
			progressBar3.Maximum = 1023;
			progressBar3.Name = "progressBar3";
			progressBar3.Size = new Size(208, 15);
			progressBar3.Step = 1;
			progressBar3.Style = ProgressBarStyle.Continuous;
			progressBar3.TabIndex = 26;
			progressBar3.Value = 512;
			// 
			// progressBar4
			// 
			progressBar4.Location = new Point(25, 66);
			progressBar4.Margin = new Padding(4, 3, 4, 3);
			progressBar4.Maximum = 1023;
			progressBar4.Name = "progressBar4";
			progressBar4.Size = new Size(208, 15);
			progressBar4.Step = 1;
			progressBar4.Style = ProgressBarStyle.Continuous;
			progressBar4.TabIndex = 27;
			progressBar4.Value = 512;
			// 
			// groupBoxRelays
			// 
			groupBoxRelays.AutoSize = true;
			groupBoxRelays.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			groupBoxRelays.Controls.Add(tableLayoutPanel5);
			groupBoxRelays.Dock = DockStyle.Top;
			groupBoxRelays.Enabled = false;
			groupBoxRelays.Location = new Point(0, 385);
			groupBoxRelays.Margin = new Padding(4, 3, 4, 3);
			groupBoxRelays.Name = "groupBoxRelays";
			groupBoxRelays.Padding = new Padding(4, 3, 4, 3);
			groupBoxRelays.Size = new Size(434, 106);
			groupBoxRelays.TabIndex = 8;
			groupBoxRelays.TabStop = false;
			groupBoxRelays.Text = "Relays";
			// 
			// tableLayoutPanel5
			// 
			tableLayoutPanel5.AutoSize = true;
			tableLayoutPanel5.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			tableLayoutPanel5.ColumnCount = 5;
			tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanel5.Controls.Add(buttonToggle7, 0, 1);
			tableLayoutPanel5.Controls.Add(buttonToggle6, 0, 1);
			tableLayoutPanel5.Controls.Add(buttonToggle1, 0, 0);
			tableLayoutPanel5.Controls.Add(buttonToggle2, 1, 0);
			tableLayoutPanel5.Controls.Add(buttonToggle3, 2, 0);
			tableLayoutPanel5.Controls.Add(buttonToggle4, 3, 0);
			tableLayoutPanel5.Controls.Add(buttonToggle8, 2, 1);
			tableLayoutPanel5.Controls.Add(buttonToggle5, 0, 1);
			tableLayoutPanel5.Controls.Add(buttonAllOn, 4, 0);
			tableLayoutPanel5.Controls.Add(buttonAllOff, 4, 1);
			tableLayoutPanel5.Location = new Point(10, 22);
			tableLayoutPanel5.Margin = new Padding(4, 3, 4, 3);
			tableLayoutPanel5.Name = "tableLayoutPanel5";
			tableLayoutPanel5.RowCount = 2;
			tableLayoutPanel5.RowStyles.Add(new RowStyle());
			tableLayoutPanel5.RowStyles.Add(new RowStyle());
			tableLayoutPanel5.Size = new Size(400, 62);
			tableLayoutPanel5.TabIndex = 1;
			// 
			// button1
			// 
			button1.Location = new Point(266, 37);
			button1.Margin = new Padding(4, 3, 4, 3);
			button1.Name = "button1";
			button1.Size = new Size(88, 27);
			button1.TabIndex = 3;
			button1.Text = "Read";
			button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			button2.Location = new Point(266, 79);
			button2.Margin = new Padding(4, 3, 4, 3);
			button2.Name = "button2";
			button2.Size = new Size(88, 27);
			button2.TabIndex = 3;
			button2.Text = "Read";
			button2.UseVisualStyleBackColor = true;
			// 
			// buttonToggle1
			// 
			buttonToggle1.BackColor = Color.Red;
			buttonToggle1.ForeColor = Color.White;
			buttonToggle1.Location = new Point(4, 3);
			buttonToggle1.Margin = new Padding(4, 3, 4, 3);
			buttonToggle1.Name = "buttonToggle1";
			buttonToggle1.Size = new Size(72, 25);
			buttonToggle1.TabIndex = 29;
			buttonToggle1.Text = "Toggle 1";
			buttonToggle1.UseVisualStyleBackColor = false;
			// 
			// buttonToggle2
			// 
			buttonToggle2.BackColor = Color.Red;
			buttonToggle2.ForeColor = Color.White;
			buttonToggle2.Location = new Point(84, 3);
			buttonToggle2.Margin = new Padding(4, 3, 4, 3);
			buttonToggle2.Name = "buttonToggle2";
			buttonToggle2.Size = new Size(72, 25);
			buttonToggle2.TabIndex = 30;
			buttonToggle2.Text = "Toggle 2";
			buttonToggle2.UseVisualStyleBackColor = false;
			// 
			// buttonToggle3
			// 
			buttonToggle3.BackColor = Color.Red;
			buttonToggle3.ForeColor = Color.White;
			buttonToggle3.Location = new Point(164, 3);
			buttonToggle3.Margin = new Padding(4, 3, 4, 3);
			buttonToggle3.Name = "buttonToggle3";
			buttonToggle3.Size = new Size(72, 25);
			buttonToggle3.TabIndex = 31;
			buttonToggle3.Text = "Toggle 3";
			buttonToggle3.UseVisualStyleBackColor = false;
			// 
			// buttonToggle4
			// 
			buttonToggle4.BackColor = Color.Red;
			buttonToggle4.ForeColor = Color.White;
			buttonToggle4.Location = new Point(244, 3);
			buttonToggle4.Margin = new Padding(4, 3, 4, 3);
			buttonToggle4.Name = "buttonToggle4";
			buttonToggle4.Size = new Size(72, 25);
			buttonToggle4.TabIndex = 32;
			buttonToggle4.Text = "Toggle 4";
			buttonToggle4.UseVisualStyleBackColor = false;
			// 
			// buttonToggle5
			// 
			buttonToggle5.BackColor = Color.Red;
			buttonToggle5.ForeColor = Color.White;
			buttonToggle5.Location = new Point(4, 34);
			buttonToggle5.Margin = new Padding(4, 3, 4, 3);
			buttonToggle5.Name = "buttonToggle5";
			buttonToggle5.Size = new Size(72, 24);
			buttonToggle5.TabIndex = 33;
			buttonToggle5.Text = "Toggle 5";
			buttonToggle5.UseVisualStyleBackColor = false;
			// 
			// buttonToggle8
			// 
			buttonToggle8.BackColor = Color.Red;
			buttonToggle8.ForeColor = Color.White;
			buttonToggle8.Location = new Point(244, 34);
			buttonToggle8.Margin = new Padding(4, 3, 4, 3);
			buttonToggle8.Name = "buttonToggle8";
			buttonToggle8.Size = new Size(72, 24);
			buttonToggle8.TabIndex = 36;
			buttonToggle8.Text = "Toggle 8";
			buttonToggle8.UseVisualStyleBackColor = false;
			// 
			// buttonToggle6
			// 
			buttonToggle6.BackColor = Color.Red;
			buttonToggle6.ForeColor = Color.White;
			buttonToggle6.Location = new Point(84, 34);
			buttonToggle6.Margin = new Padding(4, 3, 4, 3);
			buttonToggle6.Name = "buttonToggle6";
			buttonToggle6.Size = new Size(72, 24);
			buttonToggle6.TabIndex = 34;
			buttonToggle6.Text = "Toggle 6";
			buttonToggle6.UseVisualStyleBackColor = false;
			// 
			// buttonToggle7
			// 
			buttonToggle7.BackColor = Color.Red;
			buttonToggle7.ForeColor = Color.White;
			buttonToggle7.Location = new Point(164, 34);
			buttonToggle7.Margin = new Padding(4, 3, 4, 3);
			buttonToggle7.Name = "buttonToggle7";
			buttonToggle7.Size = new Size(72, 24);
			buttonToggle7.TabIndex = 35;
			buttonToggle7.Text = "Toggle 7";
			buttonToggle7.UseVisualStyleBackColor = false;
			// 
			// buttonAllOn
			// 
			buttonAllOn.BackColor = SystemColors.Control;
			buttonAllOn.Location = new Point(324, 3);
			buttonAllOn.Margin = new Padding(4, 3, 4, 3);
			buttonAllOn.Name = "buttonAllOn";
			buttonAllOn.Size = new Size(72, 25);
			buttonAllOn.TabIndex = 37;
			buttonAllOn.Text = "ALL ON";
			buttonAllOn.UseVisualStyleBackColor = false;
			// 
			// buttonAllOff
			// 
			buttonAllOff.BackColor = SystemColors.Control;
			buttonAllOff.Location = new Point(324, 34);
			buttonAllOff.Margin = new Padding(4, 3, 4, 3);
			buttonAllOff.Name = "buttonAllOff";
			buttonAllOff.Size = new Size(72, 25);
			buttonAllOff.TabIndex = 38;
			buttonAllOff.Text = "ALL OFF";
			buttonAllOff.UseVisualStyleBackColor = false;
			// 
			// FormRelay
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(434, 511);
			Controls.Add(groupBoxRelays);
			Controls.Add(groupBoxAnalogInputs);
			Controls.Add(groupBoxDigitalInputs);
			Controls.Add(groupBoxAddress);
			Controls.Add(groupBoxSerialPort);
			Controls.Add(statusStrip1);
			Controls.Add(menuStrip1);
			Name = "FormRelay";
			Text = "Form1";
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			statusStrip1.ResumeLayout(false);
			statusStrip1.PerformLayout();
			groupBoxSerialPort.ResumeLayout(false);
			groupBoxSerialPort.PerformLayout();
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			groupBoxAddress.ResumeLayout(false);
			groupBoxAddress.PerformLayout();
			tableLayoutPanel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)numericUpDownAddress).EndInit();
			groupBoxDigitalInputs.ResumeLayout(false);
			groupBoxDigitalInputs.PerformLayout();
			tableLayoutPanel3.ResumeLayout(false);
			tableLayoutPanel3.PerformLayout();
			groupBoxAnalogInputs.ResumeLayout(false);
			groupBoxAnalogInputs.PerformLayout();
			tableLayoutPanel4.ResumeLayout(false);
			tableLayoutPanel4.PerformLayout();
			groupBoxRelays.ResumeLayout(false);
			groupBoxRelays.PerformLayout();
			tableLayoutPanel5.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private MenuStrip menuStrip1;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem exitToolStripMenuItem;
		private StatusStrip statusStrip1;
		private ToolStripStatusLabel toolStripStatusLabel;
		private GroupBox groupBoxSerialPort;
		private RadioButton radioButtonClosed;
		private RadioButton radioButtonOpen;
		private ComboBox comboBoxSerialPort;
		private GroupBox groupBoxMassFlow;
		private TableLayoutPanel tableLayoutPanel1;
		private Label labelPressure;
		private Label labelTemperature;
		private GroupBox groupBoxAddress;
		private TableLayoutPanel tableLayoutPanel2;
		private TextBox textBoxTemperature;
		private TextBox textBoxVolumetricFlow;
		private TextBox textBoxMassFlow;
		private Button buttonReadAddress;
		private NumericUpDown numericUpDownAddress;
		private Button buttonWriteAddress;
		private GroupBox groupBoxDigitalInputs;
		private TableLayoutPanel tableLayoutPanel3;
		private Label label1;
		private Label label3;
		private TextBox textBox2;
		private TextBox textBox1;
		private TextBox textBoxPressure;
		private Label label2;
		private TextBox textBox3;
		private Label label4;
		private GroupBox groupBoxAnalogInputs;
		private TableLayoutPanel tableLayoutPanel4;
		private Label label6;
		private Label label7;
		private Label label5;
		private Label label8;
		internal ProgressBar progressBar1;
		internal ProgressBar progressBar2;
		internal ProgressBar progressBar3;
		internal ProgressBar progressBar4;
		private GroupBox groupBoxRelays;
		private TableLayoutPanel tableLayoutPanel5;
		private Button button1;
		private Button button2;
		internal Button buttonToggle4;
		internal Button buttonToggle1;
		internal Button buttonToggle2;
		internal Button buttonToggle3;
		internal Button buttonToggle7;
		internal Button buttonToggle6;
		internal Button buttonToggle8;
		internal Button buttonToggle5;
		internal Button buttonAllOn;
		internal Button buttonAllOff;
		private Label labelUnitPressure;
		private Label labelUnitTemperature;
		private Label labelUnitVolumetricFlow;
		private Label labelUnitMassFlow;
		private TextBox textBoxSetpoint;
		private Label labelUnitSetpoint;
		private ComboBox comboBoxGas;
		private Button buttonWriteSP;
		private Button buttonWriteGas;
	}
}
