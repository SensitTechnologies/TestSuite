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
			this.labelVoltage = new System.Windows.Forms.Label();
			this.labelCurrent = new System.Windows.Forms.Label();
			this.labelUnitVoltage = new System.Windows.Forms.Label();
			this.labelUnitCurrent = new System.Windows.Forms.Label();
			this.labelChannel = new System.Windows.Forms.Label();
			this.numericUpDownChannel = new System.Windows.Forms.NumericUpDown();
			this.buttonWrite = new System.Windows.Forms.Button();
			this.buttonRead = new System.Windows.Forms.Button();
			this.groupBoxOutput = new System.Windows.Forms.GroupBox();
			this.radioButtonDisabled = new System.Windows.Forms.RadioButton();
			this.radioButtonEnabled = new System.Windows.Forms.RadioButton();
			this.numericUpDownCurrent = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownVoltage = new System.Windows.Forms.NumericUpDown();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.groupBoxSerialPort.SuspendLayout();
			this.groupBoxPowerSupply.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownChannel)).BeginInit();
			this.groupBoxOutput.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCurrent)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownVoltage)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(295, 24);
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
			this.statusStrip1.Location = new System.Drawing.Point(0, 266);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(295, 22);
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
			this.groupBoxSerialPort.Size = new System.Drawing.Size(295, 60);
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
			this.groupBoxPowerSupply.Location = new System.Drawing.Point(0, 140);
			this.groupBoxPowerSupply.Name = "groupBoxPowerSupply";
			this.groupBoxPowerSupply.Size = new System.Drawing.Size(295, 122);
			this.groupBoxPowerSupply.TabIndex = 5;
			this.groupBoxPowerSupply.TabStop = false;
			this.groupBoxPowerSupply.Text = "Power Supply";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.labelVoltage, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelCurrent, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelUnitVoltage, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelUnitCurrent, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelChannel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.numericUpDownChannel, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.buttonWrite, 3, 2);
			this.tableLayoutPanel1.Controls.Add(this.buttonRead, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.numericUpDownCurrent, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.numericUpDownVoltage, 1, 2);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(280, 84);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// labelVoltage
			// 
			this.labelVoltage.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelVoltage.AutoSize = true;
			this.labelVoltage.Location = new System.Drawing.Point(3, 63);
			this.labelVoltage.Name = "labelVoltage";
			this.labelVoltage.Size = new System.Drawing.Size(43, 13);
			this.labelVoltage.TabIndex = 1;
			this.labelVoltage.Text = "Voltage";
			// 
			// labelCurrent
			// 
			this.labelCurrent.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelCurrent.AutoSize = true;
			this.labelCurrent.Location = new System.Drawing.Point(3, 34);
			this.labelCurrent.Name = "labelCurrent";
			this.labelCurrent.Size = new System.Drawing.Size(41, 13);
			this.labelCurrent.TabIndex = 0;
			this.labelCurrent.Text = "Current";
			// 
			// labelUnitVoltage
			// 
			this.labelUnitVoltage.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelUnitVoltage.AutoSize = true;
			this.labelUnitVoltage.Location = new System.Drawing.Point(161, 63);
			this.labelUnitVoltage.Name = "labelUnitVoltage";
			this.labelUnitVoltage.Size = new System.Drawing.Size(14, 13);
			this.labelUnitVoltage.TabIndex = 11;
			this.labelUnitVoltage.Text = "V";
			// 
			// labelUnitCurrent
			// 
			this.labelUnitCurrent.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelUnitCurrent.Location = new System.Drawing.Point(161, 34);
			this.labelUnitCurrent.Name = "labelUnitCurrent";
			this.labelUnitCurrent.Size = new System.Drawing.Size(35, 13);
			this.labelUnitCurrent.TabIndex = 0;
			this.labelUnitCurrent.Text = "A";
			// 
			// labelChannel
			// 
			this.labelChannel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelChannel.AutoSize = true;
			this.labelChannel.Location = new System.Drawing.Point(3, 6);
			this.labelChannel.Name = "labelChannel";
			this.labelChannel.Size = new System.Drawing.Size(46, 13);
			this.labelChannel.TabIndex = 19;
			this.labelChannel.Text = "Channel";
			// 
			// numericUpDownChannel
			// 
			this.numericUpDownChannel.Location = new System.Drawing.Point(55, 3);
			this.numericUpDownChannel.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.numericUpDownChannel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownChannel.Name = "numericUpDownChannel";
			this.numericUpDownChannel.Size = new System.Drawing.Size(100, 20);
			this.numericUpDownChannel.TabIndex = 20;
			this.numericUpDownChannel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// buttonWrite
			// 
			this.buttonWrite.Location = new System.Drawing.Point(202, 58);
			this.buttonWrite.Name = "buttonWrite";
			this.buttonWrite.Size = new System.Drawing.Size(75, 23);
			this.buttonWrite.TabIndex = 17;
			this.buttonWrite.Text = "Write";
			this.buttonWrite.UseVisualStyleBackColor = true;
			this.buttonWrite.Click += new System.EventHandler(this.ButtonWrite_Click);
			// 
			// buttonRead
			// 
			this.buttonRead.Location = new System.Drawing.Point(202, 29);
			this.buttonRead.Name = "buttonRead";
			this.buttonRead.Size = new System.Drawing.Size(75, 23);
			this.buttonRead.TabIndex = 2;
			this.buttonRead.Text = "Read";
			this.buttonRead.UseVisualStyleBackColor = true;
			this.buttonRead.Click += new System.EventHandler(this.ButtonRead_Click);
			// 
			// groupBoxOutput
			// 
			this.groupBoxOutput.AutoSize = true;
			this.groupBoxOutput.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxOutput.Controls.Add(this.radioButtonDisabled);
			this.groupBoxOutput.Controls.Add(this.radioButtonEnabled);
			this.groupBoxOutput.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBoxOutput.Location = new System.Drawing.Point(0, 84);
			this.groupBoxOutput.Name = "groupBoxOutput";
			this.groupBoxOutput.Size = new System.Drawing.Size(295, 56);
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
			// numericUpDownCurrent
			// 
			this.numericUpDownCurrent.DecimalPlaces = 2;
			this.numericUpDownCurrent.Location = new System.Drawing.Point(55, 29);
			this.numericUpDownCurrent.Name = "numericUpDownCurrent";
			this.numericUpDownCurrent.Size = new System.Drawing.Size(100, 20);
			this.numericUpDownCurrent.TabIndex = 21;
			// 
			// numericUpDownVoltage
			// 
			this.numericUpDownVoltage.DecimalPlaces = 2;
			this.numericUpDownVoltage.Location = new System.Drawing.Point(55, 58);
			this.numericUpDownVoltage.Name = "numericUpDownVoltage";
			this.numericUpDownVoltage.Size = new System.Drawing.Size(100, 20);
			this.numericUpDownVoltage.TabIndex = 22;
			// 
			// FormPowerSupply
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(295, 288);
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
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownChannel)).EndInit();
			this.groupBoxOutput.ResumeLayout(false);
			this.groupBoxOutput.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCurrent)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownVoltage)).EndInit();
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
		private System.Windows.Forms.Label labelCurrent;
		private System.Windows.Forms.Label labelVoltage;
		private System.Windows.Forms.Button buttonRead;
		private System.Windows.Forms.Label labelUnitCurrent;
		private System.Windows.Forms.Label labelUnitVoltage;
		private System.Windows.Forms.Button buttonWrite;
		private System.Windows.Forms.GroupBox groupBoxOutput;
		private System.Windows.Forms.RadioButton radioButtonDisabled;
		private System.Windows.Forms.RadioButton radioButtonEnabled;
		private System.Windows.Forms.Label labelChannel;
		private System.Windows.Forms.NumericUpDown numericUpDownChannel;
		private System.Windows.Forms.NumericUpDown numericUpDownCurrent;
		private System.Windows.Forms.NumericUpDown numericUpDownVoltage;
	}
}

