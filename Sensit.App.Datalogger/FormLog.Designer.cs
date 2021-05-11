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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.groupBoxMassFlow = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.textBoxFilename = new System.Windows.Forms.TextBox();
			this.buttonBrowse = new System.Windows.Forms.Button();
			this.groupBoxSerialPort = new System.Windows.Forms.GroupBox();
			this.comboBoxSerialPort = new System.Windows.Forms.ComboBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.textBoxResponse = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.textBoxCommand = new System.Windows.Forms.TextBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.buttonStop = new System.Windows.Forms.Button();
			this.buttonStart = new System.Windows.Forms.Button();
			this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
			this.groupBoxInterval = new System.Windows.Forms.GroupBox();
			this.groupBoxBaudRate = new System.Windows.Forms.GroupBox();
			this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.groupBoxMassFlow.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.groupBoxSerialPort.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
			this.groupBoxInterval.SuspendLayout();
			this.groupBoxBaudRate.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(444, 24);
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
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
			this.exitToolStripMenuItem.Text = "&Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 339);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(444, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
			this.toolStripStatusLabel1.Text = "Ready";
			// 
			// groupBoxMassFlow
			// 
			this.groupBoxMassFlow.AutoSize = true;
			this.groupBoxMassFlow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxMassFlow.Controls.Add(this.tableLayoutPanel1);
			this.groupBoxMassFlow.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBoxMassFlow.Location = new System.Drawing.Point(0, 24);
			this.groupBoxMassFlow.Name = "groupBoxMassFlow";
			this.groupBoxMassFlow.Size = new System.Drawing.Size(444, 67);
			this.groupBoxMassFlow.TabIndex = 7;
			this.groupBoxMassFlow.TabStop = false;
			this.groupBoxMassFlow.Text = "Filename";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Controls.Add(this.textBoxFilename, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.buttonBrowse, 1, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(11, 19);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(424, 29);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// textBoxFilename
			// 
			this.textBoxFilename.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.textBoxFilename.Location = new System.Drawing.Point(3, 4);
			this.textBoxFilename.Name = "textBoxFilename";
			this.textBoxFilename.Size = new System.Drawing.Size(337, 20);
			this.textBoxFilename.TabIndex = 9;
			// 
			// buttonBrowse
			// 
			this.buttonBrowse.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.buttonBrowse.Location = new System.Drawing.Point(346, 3);
			this.buttonBrowse.Name = "buttonBrowse";
			this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
			this.buttonBrowse.TabIndex = 2;
			this.buttonBrowse.Text = "Browse";
			this.buttonBrowse.UseVisualStyleBackColor = true;
			this.buttonBrowse.Click += new System.EventHandler(this.ButtonBrowse_Click);
			// 
			// groupBoxSerialPort
			// 
			this.groupBoxSerialPort.AutoSize = true;
			this.groupBoxSerialPort.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxSerialPort.Controls.Add(this.comboBoxSerialPort);
			this.groupBoxSerialPort.Location = new System.Drawing.Point(0, 97);
			this.groupBoxSerialPort.Name = "groupBoxSerialPort";
			this.groupBoxSerialPort.Size = new System.Drawing.Size(140, 60);
			this.groupBoxSerialPort.TabIndex = 8;
			this.groupBoxSerialPort.TabStop = false;
			this.groupBoxSerialPort.Text = "Serial Port";
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
			// groupBox3
			// 
			this.groupBox3.AutoSize = true;
			this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBox3.Controls.Add(this.textBoxResponse);
			this.groupBox3.Location = new System.Drawing.Point(0, 227);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(435, 58);
			this.groupBox3.TabIndex = 11;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Response";
			// 
			// textBoxResponse
			// 
			this.textBoxResponse.Location = new System.Drawing.Point(11, 19);
			this.textBoxResponse.Name = "textBoxResponse";
			this.textBoxResponse.ReadOnly = true;
			this.textBoxResponse.Size = new System.Drawing.Size(418, 20);
			this.textBoxResponse.TabIndex = 10;
			// 
			// groupBox2
			// 
			this.groupBox2.AutoSize = true;
			this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBox2.Controls.Add(this.textBoxCommand);
			this.groupBox2.Location = new System.Drawing.Point(0, 163);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(435, 58);
			this.groupBox2.TabIndex = 12;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Command";
			// 
			// textBoxCommand
			// 
			this.textBoxCommand.Location = new System.Drawing.Point(11, 19);
			this.textBoxCommand.Name = "textBoxCommand";
			this.textBoxCommand.Size = new System.Drawing.Size(418, 20);
			this.textBoxCommand.TabIndex = 10;
			this.textBoxCommand.TextChanged += new System.EventHandler(this.TextBoxCommand_TextChanged);
			// 
			// groupBox4
			// 
			this.groupBox4.AutoSize = true;
			this.groupBox4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBox4.Controls.Add(this.tableLayoutPanel3);
			this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox4.Location = new System.Drawing.Point(0, 285);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(444, 54);
			this.groupBox4.TabIndex = 13;
			this.groupBox4.TabStop = false;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.AutoSize = true;
			this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel3.ColumnCount = 1;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 0, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(438, 35);
			this.tableLayoutPanel3.TabIndex = 1;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Controls.Add(this.buttonStop, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.buttonStart, 0, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(138, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(162, 29);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// buttonStop
			// 
			this.buttonStop.Enabled = false;
			this.buttonStop.Location = new System.Drawing.Point(84, 3);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(75, 23);
			this.buttonStop.TabIndex = 1;
			this.buttonStop.Text = "Stop";
			this.buttonStop.UseVisualStyleBackColor = true;
			this.buttonStop.Click += new System.EventHandler(this.ButtonStop_Click);
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(3, 3);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(75, 23);
			this.buttonStart.TabIndex = 0;
			this.buttonStart.Text = "Start";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
			// 
			// numericUpDownInterval
			// 
			this.numericUpDownInterval.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDownInterval.Location = new System.Drawing.Point(14, 21);
			this.numericUpDownInterval.Maximum = new decimal(new int[] {
            36000000,
            0,
            0,
            0});
			this.numericUpDownInterval.Name = "numericUpDownInterval";
			this.numericUpDownInterval.Size = new System.Drawing.Size(123, 20);
			this.numericUpDownInterval.TabIndex = 1;
			this.numericUpDownInterval.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDownInterval.ValueChanged += new System.EventHandler(this.NumericUpDownInterval_ValueChanged);
			// 
			// groupBoxInterval
			// 
			this.groupBoxInterval.AutoSize = true;
			this.groupBoxInterval.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxInterval.Controls.Add(this.numericUpDownInterval);
			this.groupBoxInterval.Location = new System.Drawing.Point(292, 97);
			this.groupBoxInterval.Name = "groupBoxInterval";
			this.groupBoxInterval.Size = new System.Drawing.Size(143, 60);
			this.groupBoxInterval.TabIndex = 10;
			this.groupBoxInterval.TabStop = false;
			this.groupBoxInterval.Text = "Sample Interval (ms)";
			// 
			// groupBoxBaudRate
			// 
			this.groupBoxBaudRate.AutoSize = true;
			this.groupBoxBaudRate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxBaudRate.Controls.Add(this.comboBoxBaudRate);
			this.groupBoxBaudRate.Location = new System.Drawing.Point(146, 97);
			this.groupBoxBaudRate.Name = "groupBoxBaudRate";
			this.groupBoxBaudRate.Size = new System.Drawing.Size(140, 60);
			this.groupBoxBaudRate.TabIndex = 9;
			this.groupBoxBaudRate.TabStop = false;
			this.groupBoxBaudRate.Text = "Baud Rate";
			// 
			// comboBoxBaudRate
			// 
			this.comboBoxBaudRate.FormattingEnabled = true;
			this.comboBoxBaudRate.Location = new System.Drawing.Point(13, 20);
			this.comboBoxBaudRate.Name = "comboBoxBaudRate";
			this.comboBoxBaudRate.Size = new System.Drawing.Size(121, 21);
			this.comboBoxBaudRate.TabIndex = 0;
			this.comboBoxBaudRate.SelectedIndexChanged += new System.EventHandler(this.ComboBoxBaudRate_SelectedIndexChanged);
			// 
			// FormLog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(444, 361);
			this.Controls.Add(this.groupBoxBaudRate);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBoxInterval);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBoxSerialPort);
			this.Controls.Add(this.groupBoxMassFlow);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FormLog";
			this.Text = "Data logger";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLog_FormClosing);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.groupBoxMassFlow.ResumeLayout(false);
			this.groupBoxMassFlow.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.groupBoxSerialPort.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
			this.groupBoxInterval.ResumeLayout(false);
			this.groupBoxBaudRate.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.GroupBox groupBoxMassFlow;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TextBox textBoxFilename;
		private System.Windows.Forms.Button buttonBrowse;
		private System.Windows.Forms.GroupBox groupBoxSerialPort;
		private System.Windows.Forms.ComboBox comboBoxSerialPort;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox textBoxResponse;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox textBoxCommand;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button buttonStop;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.NumericUpDown numericUpDownInterval;
		private System.Windows.Forms.GroupBox groupBoxInterval;
		private System.Windows.Forms.GroupBox groupBoxBaudRate;
		private System.Windows.Forms.ComboBox comboBoxBaudRate;
	}
}

