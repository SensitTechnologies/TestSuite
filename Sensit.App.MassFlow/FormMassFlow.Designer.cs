namespace Sensit.App.MassFlow
{
	partial class FormMassFlow
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
			this.groupBoxSerialPort = new System.Windows.Forms.GroupBox();
			this.radioButtonClosed = new System.Windows.Forms.RadioButton();
			this.radioButtonOpen = new System.Windows.Forms.RadioButton();
			this.comboBoxSerialPort = new System.Windows.Forms.ComboBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBoxMassFlow = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.labelPressure = new System.Windows.Forms.Label();
			this.labelTemperature = new System.Windows.Forms.Label();
			this.textBoxPressure = new System.Windows.Forms.TextBox();
			this.textBoxTemperature = new System.Windows.Forms.TextBox();
			this.labelVolumetricFlow = new System.Windows.Forms.Label();
			this.textBoxVolumetricFlow = new System.Windows.Forms.TextBox();
			this.labelMassFlow = new System.Windows.Forms.Label();
			this.textBoxMassFlow = new System.Windows.Forms.TextBox();
			this.buttonReadAll = new System.Windows.Forms.Button();
			this.labelUnitPressure = new System.Windows.Forms.Label();
			this.labelUnitTemperature = new System.Windows.Forms.Label();
			this.labelUnitVolumetricFlow = new System.Windows.Forms.Label();
			this.labelUnitMassFlow = new System.Windows.Forms.Label();
			this.labelSetpoint = new System.Windows.Forms.Label();
			this.textBoxSetpoint = new System.Windows.Forms.TextBox();
			this.labelUnitSetpoint = new System.Windows.Forms.Label();
			this.labelGas = new System.Windows.Forms.Label();
			this.comboBoxGas = new System.Windows.Forms.ComboBox();
			this.buttonWriteSP = new System.Windows.Forms.Button();
			this.buttonWriteGas = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.groupBoxSerialPort.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.groupBoxMassFlow.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
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
			this.groupBoxSerialPort.Size = new System.Drawing.Size(334, 60);
			this.groupBoxSerialPort.TabIndex = 0;
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
			this.radioButtonClosed.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
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
			this.radioButtonOpen.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// comboBoxSerialPort
			// 
			this.comboBoxSerialPort.FormattingEnabled = true;
			this.comboBoxSerialPort.Location = new System.Drawing.Point(13, 20);
			this.comboBoxSerialPort.Name = "comboBoxSerialPort";
			this.comboBoxSerialPort.Size = new System.Drawing.Size(121, 21);
			this.comboBoxSerialPort.TabIndex = 0;
			this.comboBoxSerialPort.SelectedIndexChanged += new System.EventHandler(this.comboBoxSerialPort_SelectedIndexChanged);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(334, 24);
			this.menuStrip1.TabIndex = 1;
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
			// groupBoxMassFlow
			// 
			this.groupBoxMassFlow.Controls.Add(this.tableLayoutPanel1);
			this.groupBoxMassFlow.Controls.Add(this.statusStrip1);
			this.groupBoxMassFlow.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxMassFlow.Enabled = false;
			this.groupBoxMassFlow.Location = new System.Drawing.Point(0, 84);
			this.groupBoxMassFlow.Name = "groupBoxMassFlow";
			this.groupBoxMassFlow.Size = new System.Drawing.Size(334, 227);
			this.groupBoxMassFlow.TabIndex = 2;
			this.groupBoxMassFlow.TabStop = false;
			this.groupBoxMassFlow.Text = "Mass Flow Control";
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
			this.tableLayoutPanel1.Controls.Add(this.labelPressure, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelTemperature, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.textBoxPressure, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.textBoxTemperature, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelVolumetricFlow, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.textBoxVolumetricFlow, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelMassFlow, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.textBoxMassFlow, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.buttonReadAll, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelUnitPressure, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelUnitTemperature, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelUnitVolumetricFlow, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelUnitMassFlow, 2, 3);
			this.tableLayoutPanel1.Controls.Add(this.labelSetpoint, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.textBoxSetpoint, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.labelUnitSetpoint, 2, 5);
			this.tableLayoutPanel1.Controls.Add(this.labelGas, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.comboBoxGas, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.buttonWriteSP, 3, 5);
			this.tableLayoutPanel1.Controls.Add(this.buttonWriteGas, 3, 4);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 6;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(317, 165);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// labelPressure
			// 
			this.labelPressure.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelPressure.AutoSize = true;
			this.labelPressure.Location = new System.Drawing.Point(3, 8);
			this.labelPressure.Name = "labelPressure";
			this.labelPressure.Size = new System.Drawing.Size(48, 13);
			this.labelPressure.TabIndex = 0;
			this.labelPressure.Text = "Pressure";
			// 
			// labelTemperature
			// 
			this.labelTemperature.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelTemperature.AutoSize = true;
			this.labelTemperature.Location = new System.Drawing.Point(3, 35);
			this.labelTemperature.Name = "labelTemperature";
			this.labelTemperature.Size = new System.Drawing.Size(67, 13);
			this.labelTemperature.TabIndex = 1;
			this.labelTemperature.Text = "Temperature";
			// 
			// textBoxPressure
			// 
			this.textBoxPressure.Location = new System.Drawing.Point(90, 3);
			this.textBoxPressure.Name = "textBoxPressure";
			this.textBoxPressure.ReadOnly = true;
			this.textBoxPressure.Size = new System.Drawing.Size(100, 20);
			this.textBoxPressure.TabIndex = 2;
			// 
			// textBoxTemperature
			// 
			this.textBoxTemperature.Location = new System.Drawing.Point(90, 32);
			this.textBoxTemperature.Name = "textBoxTemperature";
			this.textBoxTemperature.ReadOnly = true;
			this.textBoxTemperature.Size = new System.Drawing.Size(100, 20);
			this.textBoxTemperature.TabIndex = 3;
			// 
			// labelVolumetricFlow
			// 
			this.labelVolumetricFlow.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelVolumetricFlow.AutoSize = true;
			this.labelVolumetricFlow.Location = new System.Drawing.Point(3, 61);
			this.labelVolumetricFlow.Name = "labelVolumetricFlow";
			this.labelVolumetricFlow.Size = new System.Drawing.Size(81, 13);
			this.labelVolumetricFlow.TabIndex = 4;
			this.labelVolumetricFlow.Text = "Volumetric Flow";
			// 
			// textBoxVolumetricFlow
			// 
			this.textBoxVolumetricFlow.Location = new System.Drawing.Point(90, 58);
			this.textBoxVolumetricFlow.Name = "textBoxVolumetricFlow";
			this.textBoxVolumetricFlow.ReadOnly = true;
			this.textBoxVolumetricFlow.Size = new System.Drawing.Size(100, 20);
			this.textBoxVolumetricFlow.TabIndex = 5;
			// 
			// labelMassFlow
			// 
			this.labelMassFlow.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelMassFlow.AutoSize = true;
			this.labelMassFlow.Location = new System.Drawing.Point(3, 87);
			this.labelMassFlow.Name = "labelMassFlow";
			this.labelMassFlow.Size = new System.Drawing.Size(57, 13);
			this.labelMassFlow.TabIndex = 6;
			this.labelMassFlow.Text = "Mass Flow";
			// 
			// textBoxMassFlow
			// 
			this.textBoxMassFlow.Location = new System.Drawing.Point(90, 84);
			this.textBoxMassFlow.Name = "textBoxMassFlow";
			this.textBoxMassFlow.ReadOnly = true;
			this.textBoxMassFlow.Size = new System.Drawing.Size(100, 20);
			this.textBoxMassFlow.TabIndex = 7;
			// 
			// buttonReadAll
			// 
			this.buttonReadAll.Location = new System.Drawing.Point(239, 3);
			this.buttonReadAll.Name = "buttonReadAll";
			this.buttonReadAll.Size = new System.Drawing.Size(75, 23);
			this.buttonReadAll.TabIndex = 2;
			this.buttonReadAll.Text = "Read All";
			this.buttonReadAll.UseVisualStyleBackColor = true;
			this.buttonReadAll.Click += new System.EventHandler(this.buttonReadAll_Click);
			// 
			// labelUnitPressure
			// 
			this.labelUnitPressure.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelUnitPressure.Location = new System.Drawing.Point(196, 8);
			this.labelUnitPressure.Name = "labelUnitPressure";
			this.labelUnitPressure.Size = new System.Drawing.Size(35, 13);
			this.labelUnitPressure.TabIndex = 0;
			this.labelUnitPressure.Text = "PSIA";
			// 
			// labelUnitTemperature
			// 
			this.labelUnitTemperature.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelUnitTemperature.AutoSize = true;
			this.labelUnitTemperature.Location = new System.Drawing.Point(196, 35);
			this.labelUnitTemperature.Name = "labelUnitTemperature";
			this.labelUnitTemperature.Size = new System.Drawing.Size(18, 13);
			this.labelUnitTemperature.TabIndex = 11;
			this.labelUnitTemperature.Text = "°C";
			// 
			// labelUnitVolumetricFlow
			// 
			this.labelUnitVolumetricFlow.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelUnitVolumetricFlow.AutoSize = true;
			this.labelUnitVolumetricFlow.Location = new System.Drawing.Point(196, 61);
			this.labelUnitVolumetricFlow.Name = "labelUnitVolumetricFlow";
			this.labelUnitVolumetricFlow.Size = new System.Drawing.Size(30, 13);
			this.labelUnitVolumetricFlow.TabIndex = 12;
			this.labelUnitVolumetricFlow.Text = "CCM";
			// 
			// labelUnitMassFlow
			// 
			this.labelUnitMassFlow.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelUnitMassFlow.AutoSize = true;
			this.labelUnitMassFlow.Location = new System.Drawing.Point(196, 87);
			this.labelUnitMassFlow.Name = "labelUnitMassFlow";
			this.labelUnitMassFlow.Size = new System.Drawing.Size(37, 13);
			this.labelUnitMassFlow.TabIndex = 13;
			this.labelUnitMassFlow.Text = "SCCM";
			// 
			// labelSetpoint
			// 
			this.labelSetpoint.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelSetpoint.AutoSize = true;
			this.labelSetpoint.Location = new System.Drawing.Point(3, 144);
			this.labelSetpoint.Name = "labelSetpoint";
			this.labelSetpoint.Size = new System.Drawing.Size(46, 13);
			this.labelSetpoint.TabIndex = 8;
			this.labelSetpoint.Text = "Setpoint";
			// 
			// textBoxSetpoint
			// 
			this.textBoxSetpoint.Location = new System.Drawing.Point(90, 139);
			this.textBoxSetpoint.Name = "textBoxSetpoint";
			this.textBoxSetpoint.Size = new System.Drawing.Size(100, 20);
			this.textBoxSetpoint.TabIndex = 9;
			// 
			// labelUnitSetpoint
			// 
			this.labelUnitSetpoint.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelUnitSetpoint.AutoSize = true;
			this.labelUnitSetpoint.Location = new System.Drawing.Point(196, 144);
			this.labelUnitSetpoint.Name = "labelUnitSetpoint";
			this.labelUnitSetpoint.Size = new System.Drawing.Size(37, 13);
			this.labelUnitSetpoint.TabIndex = 14;
			this.labelUnitSetpoint.Text = "SCCM";
			// 
			// labelGas
			// 
			this.labelGas.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelGas.AutoSize = true;
			this.labelGas.Location = new System.Drawing.Point(3, 115);
			this.labelGas.Name = "labelGas";
			this.labelGas.Size = new System.Drawing.Size(26, 13);
			this.labelGas.TabIndex = 15;
			this.labelGas.Text = "Gas";
			// 
			// comboBoxGas
			// 
			this.comboBoxGas.FormattingEnabled = true;
			this.comboBoxGas.Location = new System.Drawing.Point(90, 110);
			this.comboBoxGas.Name = "comboBoxGas";
			this.comboBoxGas.Size = new System.Drawing.Size(100, 21);
			this.comboBoxGas.TabIndex = 16;
			// 
			// buttonWriteSP
			// 
			this.buttonWriteSP.Location = new System.Drawing.Point(239, 139);
			this.buttonWriteSP.Name = "buttonWriteSP";
			this.buttonWriteSP.Size = new System.Drawing.Size(75, 23);
			this.buttonWriteSP.TabIndex = 10;
			this.buttonWriteSP.Text = "Write SP";
			this.buttonWriteSP.UseVisualStyleBackColor = true;
			this.buttonWriteSP.Click += new System.EventHandler(this.buttonWrite_Click);
			// 
			// buttonWriteGas
			// 
			this.buttonWriteGas.Location = new System.Drawing.Point(239, 110);
			this.buttonWriteGas.Name = "buttonWriteGas";
			this.buttonWriteGas.Size = new System.Drawing.Size(75, 23);
			this.buttonWriteGas.TabIndex = 17;
			this.buttonWriteGas.Text = "Write Gas";
			this.buttonWriteGas.UseVisualStyleBackColor = true;
			this.buttonWriteGas.Click += new System.EventHandler(this.buttonWriteGas_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(3, 202);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(328, 22);
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
			this.toolStripStatusLabel1.Text = "Ready";
			// 
			// FormMassFlow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 311);
			this.Controls.Add(this.groupBoxMassFlow);
			this.Controls.Add(this.groupBoxSerialPort);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FormMassFlow";
			this.Text = "Mass Flow Controller";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.groupBoxSerialPort.ResumeLayout(false);
			this.groupBoxSerialPort.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
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

		private System.Windows.Forms.GroupBox groupBoxSerialPort;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.RadioButton radioButtonClosed;
		private System.Windows.Forms.RadioButton radioButtonOpen;
		private System.Windows.Forms.ComboBox comboBoxSerialPort;
		private System.Windows.Forms.GroupBox groupBoxMassFlow;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label labelPressure;
		private System.Windows.Forms.Label labelTemperature;
		private System.Windows.Forms.TextBox textBoxPressure;
		private System.Windows.Forms.TextBox textBoxTemperature;
		private System.Windows.Forms.Label labelVolumetricFlow;
		private System.Windows.Forms.TextBox textBoxVolumetricFlow;
		private System.Windows.Forms.Label labelMassFlow;
		private System.Windows.Forms.TextBox textBoxMassFlow;
		private System.Windows.Forms.Label labelSetpoint;
		private System.Windows.Forms.TextBox textBoxSetpoint;
		private System.Windows.Forms.Button buttonReadAll;
		private System.Windows.Forms.Button buttonWriteSP;
		private System.Windows.Forms.Label labelUnitPressure;
		private System.Windows.Forms.Label labelUnitTemperature;
		private System.Windows.Forms.Label labelUnitVolumetricFlow;
		private System.Windows.Forms.Label labelUnitMassFlow;
		private System.Windows.Forms.Label labelUnitSetpoint;
		private System.Windows.Forms.Label labelGas;
		private System.Windows.Forms.ComboBox comboBoxGas;
		private System.Windows.Forms.Button buttonWriteGas;
	}
}

