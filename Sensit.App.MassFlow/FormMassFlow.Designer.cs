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
			groupBoxSerialPort = new System.Windows.Forms.GroupBox();
			radioButtonClosed = new System.Windows.Forms.RadioButton();
			radioButtonOpen = new System.Windows.Forms.RadioButton();
			comboBoxSerialPort = new System.Windows.Forms.ComboBox();
			menuStrip1 = new System.Windows.Forms.MenuStrip();
			fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			groupBoxMassFlowControl = new System.Windows.Forms.GroupBox();
			tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			labelPressure = new System.Windows.Forms.Label();
			labelTemperature = new System.Windows.Forms.Label();
			textBoxPressure = new System.Windows.Forms.TextBox();
			textBoxTemperature = new System.Windows.Forms.TextBox();
			labelVolumetricFlow = new System.Windows.Forms.Label();
			textBoxVolumetricFlow = new System.Windows.Forms.TextBox();
			labelMassFlow = new System.Windows.Forms.Label();
			textBoxMassFlow = new System.Windows.Forms.TextBox();
			buttonReadAll = new System.Windows.Forms.Button();
			labelUnitPressure = new System.Windows.Forms.Label();
			labelUnitTemperature = new System.Windows.Forms.Label();
			labelUnitVolumetricFlow = new System.Windows.Forms.Label();
			labelUnitMassFlow = new System.Windows.Forms.Label();
			labelSetpoint = new System.Windows.Forms.Label();
			textBoxSetpoint = new System.Windows.Forms.TextBox();
			labelUnitSetpoint = new System.Windows.Forms.Label();
			labelGas = new System.Windows.Forms.Label();
			comboBoxGas = new System.Windows.Forms.ComboBox();
			buttonWriteSP = new System.Windows.Forms.Button();
			buttonWriteGas = new System.Windows.Forms.Button();
			statusStrip1 = new System.Windows.Forms.StatusStrip();
			toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			groupBoxSerialPort.SuspendLayout();
			menuStrip1.SuspendLayout();
			groupBoxMassFlowControl.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			statusStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// groupBoxSerialPort
			// 
			groupBoxSerialPort.AutoSize = true;
			groupBoxSerialPort.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			groupBoxSerialPort.Controls.Add(radioButtonClosed);
			groupBoxSerialPort.Controls.Add(radioButtonOpen);
			groupBoxSerialPort.Controls.Add(comboBoxSerialPort);
			groupBoxSerialPort.Dock = System.Windows.Forms.DockStyle.Top;
			groupBoxSerialPort.Location = new System.Drawing.Point(0, 24);
			groupBoxSerialPort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			groupBoxSerialPort.Name = "groupBoxSerialPort";
			groupBoxSerialPort.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			groupBoxSerialPort.Size = new System.Drawing.Size(390, 68);
			groupBoxSerialPort.TabIndex = 0;
			groupBoxSerialPort.TabStop = false;
			groupBoxSerialPort.Text = "Serial Port";
			// 
			// radioButtonClosed
			// 
			radioButtonClosed.AutoSize = true;
			radioButtonClosed.Checked = true;
			radioButtonClosed.Location = new System.Drawing.Point(232, 27);
			radioButtonClosed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			radioButtonClosed.Name = "radioButtonClosed";
			radioButtonClosed.Size = new System.Drawing.Size(61, 19);
			radioButtonClosed.TabIndex = 2;
			radioButtonClosed.TabStop = true;
			radioButtonClosed.Text = "Closed";
			radioButtonClosed.UseVisualStyleBackColor = true;
			radioButtonClosed.CheckedChanged += RadioButton_CheckedChanged;
			// 
			// radioButtonOpen
			// 
			radioButtonOpen.AutoSize = true;
			radioButtonOpen.Location = new System.Drawing.Point(164, 27);
			radioButtonOpen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			radioButtonOpen.Name = "radioButtonOpen";
			radioButtonOpen.Size = new System.Drawing.Size(54, 19);
			radioButtonOpen.TabIndex = 1;
			radioButtonOpen.Text = "Open";
			radioButtonOpen.UseVisualStyleBackColor = true;
			radioButtonOpen.CheckedChanged += RadioButton_CheckedChanged;
			// 
			// comboBoxSerialPort
			// 
			comboBoxSerialPort.FormattingEnabled = true;
			comboBoxSerialPort.Location = new System.Drawing.Point(15, 23);
			comboBoxSerialPort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			comboBoxSerialPort.Name = "comboBoxSerialPort";
			comboBoxSerialPort.Size = new System.Drawing.Size(140, 23);
			comboBoxSerialPort.TabIndex = 0;
			comboBoxSerialPort.SelectedIndexChanged += ComboBoxSerialPort_SelectedIndexChanged;
			// 
			// menuStrip1
			// 
			menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem });
			menuStrip1.Location = new System.Drawing.Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
			menuStrip1.Size = new System.Drawing.Size(390, 24);
			menuStrip1.TabIndex = 1;
			menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { exitToolStripMenuItem });
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			fileToolStripMenuItem.Text = "&File";
			// 
			// exitToolStripMenuItem
			// 
			exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
			exitToolStripMenuItem.Text = "&Exit";
			exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
			// 
			// groupBoxMassFlowControl
			// 
			groupBoxMassFlowControl.Controls.Add(tableLayoutPanel1);
			groupBoxMassFlowControl.Dock = System.Windows.Forms.DockStyle.Fill;
			groupBoxMassFlowControl.Enabled = false;
			groupBoxMassFlowControl.Location = new System.Drawing.Point(0, 92);
			groupBoxMassFlowControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			groupBoxMassFlowControl.Name = "groupBoxMassFlowControl";
			groupBoxMassFlowControl.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			groupBoxMassFlowControl.Size = new System.Drawing.Size(390, 250);
			groupBoxMassFlowControl.TabIndex = 2;
			groupBoxMassFlowControl.TabStop = false;
			groupBoxMassFlowControl.Text = "Mass Flow Control";
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.AutoSize = true;
			tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			tableLayoutPanel1.ColumnCount = 4;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel1.Controls.Add(labelPressure, 0, 0);
			tableLayoutPanel1.Controls.Add(labelTemperature, 0, 1);
			tableLayoutPanel1.Controls.Add(textBoxPressure, 1, 0);
			tableLayoutPanel1.Controls.Add(textBoxTemperature, 1, 1);
			tableLayoutPanel1.Controls.Add(labelVolumetricFlow, 0, 2);
			tableLayoutPanel1.Controls.Add(textBoxVolumetricFlow, 1, 2);
			tableLayoutPanel1.Controls.Add(labelMassFlow, 0, 3);
			tableLayoutPanel1.Controls.Add(textBoxMassFlow, 1, 3);
			tableLayoutPanel1.Controls.Add(buttonReadAll, 3, 0);
			tableLayoutPanel1.Controls.Add(labelUnitPressure, 2, 0);
			tableLayoutPanel1.Controls.Add(labelUnitTemperature, 2, 1);
			tableLayoutPanel1.Controls.Add(labelUnitVolumetricFlow, 2, 2);
			tableLayoutPanel1.Controls.Add(labelUnitMassFlow, 2, 3);
			tableLayoutPanel1.Controls.Add(labelSetpoint, 0, 5);
			tableLayoutPanel1.Controls.Add(textBoxSetpoint, 1, 5);
			tableLayoutPanel1.Controls.Add(labelUnitSetpoint, 2, 5);
			tableLayoutPanel1.Controls.Add(labelGas, 0, 4);
			tableLayoutPanel1.Controls.Add(comboBoxGas, 1, 4);
			tableLayoutPanel1.Controls.Add(buttonWriteSP, 3, 5);
			tableLayoutPanel1.Controls.Add(buttonWriteGas, 3, 4);
			tableLayoutPanel1.Location = new System.Drawing.Point(7, 22);
			tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 6;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.Size = new System.Drawing.Size(369, 186);
			tableLayoutPanel1.TabIndex = 1;
			// 
			// labelPressure
			// 
			labelPressure.Anchor = System.Windows.Forms.AnchorStyles.Left;
			labelPressure.AutoSize = true;
			labelPressure.Location = new System.Drawing.Point(4, 9);
			labelPressure.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelPressure.Name = "labelPressure";
			labelPressure.Size = new System.Drawing.Size(51, 15);
			labelPressure.TabIndex = 0;
			labelPressure.Text = "Pressure";
			// 
			// labelTemperature
			// 
			labelTemperature.Anchor = System.Windows.Forms.AnchorStyles.Left;
			labelTemperature.AutoSize = true;
			labelTemperature.Location = new System.Drawing.Point(4, 40);
			labelTemperature.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelTemperature.Name = "labelTemperature";
			labelTemperature.Size = new System.Drawing.Size(73, 15);
			labelTemperature.TabIndex = 1;
			labelTemperature.Text = "Temperature";
			// 
			// textBoxPressure
			// 
			textBoxPressure.Location = new System.Drawing.Point(104, 3);
			textBoxPressure.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			textBoxPressure.Name = "textBoxPressure";
			textBoxPressure.ReadOnly = true;
			textBoxPressure.Size = new System.Drawing.Size(116, 23);
			textBoxPressure.TabIndex = 2;
			// 
			// textBoxTemperature
			// 
			textBoxTemperature.Location = new System.Drawing.Point(104, 36);
			textBoxTemperature.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			textBoxTemperature.Name = "textBoxTemperature";
			textBoxTemperature.ReadOnly = true;
			textBoxTemperature.Size = new System.Drawing.Size(116, 23);
			textBoxTemperature.TabIndex = 3;
			// 
			// labelVolumetricFlow
			// 
			labelVolumetricFlow.Anchor = System.Windows.Forms.AnchorStyles.Left;
			labelVolumetricFlow.AutoSize = true;
			labelVolumetricFlow.Location = new System.Drawing.Point(4, 69);
			labelVolumetricFlow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelVolumetricFlow.Name = "labelVolumetricFlow";
			labelVolumetricFlow.Size = new System.Drawing.Size(92, 15);
			labelVolumetricFlow.TabIndex = 4;
			labelVolumetricFlow.Text = "Volumetric Flow";
			// 
			// textBoxVolumetricFlow
			// 
			textBoxVolumetricFlow.Location = new System.Drawing.Point(104, 65);
			textBoxVolumetricFlow.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			textBoxVolumetricFlow.Name = "textBoxVolumetricFlow";
			textBoxVolumetricFlow.ReadOnly = true;
			textBoxVolumetricFlow.Size = new System.Drawing.Size(116, 23);
			textBoxVolumetricFlow.TabIndex = 5;
			// 
			// labelMassFlow
			// 
			labelMassFlow.Anchor = System.Windows.Forms.AnchorStyles.Left;
			labelMassFlow.AutoSize = true;
			labelMassFlow.Location = new System.Drawing.Point(4, 98);
			labelMassFlow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelMassFlow.Name = "labelMassFlow";
			labelMassFlow.Size = new System.Drawing.Size(62, 15);
			labelMassFlow.TabIndex = 6;
			labelMassFlow.Text = "Mass Flow";
			// 
			// textBoxMassFlow
			// 
			textBoxMassFlow.Location = new System.Drawing.Point(104, 94);
			textBoxMassFlow.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			textBoxMassFlow.Name = "textBoxMassFlow";
			textBoxMassFlow.ReadOnly = true;
			textBoxMassFlow.Size = new System.Drawing.Size(116, 23);
			textBoxMassFlow.TabIndex = 7;
			// 
			// buttonReadAll
			// 
			buttonReadAll.Location = new System.Drawing.Point(277, 3);
			buttonReadAll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			buttonReadAll.Name = "buttonReadAll";
			buttonReadAll.Size = new System.Drawing.Size(88, 27);
			buttonReadAll.TabIndex = 2;
			buttonReadAll.Text = "Read All";
			buttonReadAll.UseVisualStyleBackColor = true;
			buttonReadAll.Click += ButtonReadAll_Click;
			// 
			// labelUnitPressure
			// 
			labelUnitPressure.Anchor = System.Windows.Forms.AnchorStyles.Left;
			labelUnitPressure.Location = new System.Drawing.Point(228, 9);
			labelUnitPressure.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelUnitPressure.Name = "labelUnitPressure";
			labelUnitPressure.Size = new System.Drawing.Size(41, 15);
			labelUnitPressure.TabIndex = 0;
			labelUnitPressure.Text = "PSIA";
			// 
			// labelUnitTemperature
			// 
			labelUnitTemperature.Anchor = System.Windows.Forms.AnchorStyles.Left;
			labelUnitTemperature.AutoSize = true;
			labelUnitTemperature.Location = new System.Drawing.Point(228, 40);
			labelUnitTemperature.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelUnitTemperature.Name = "labelUnitTemperature";
			labelUnitTemperature.Size = new System.Drawing.Size(20, 15);
			labelUnitTemperature.TabIndex = 11;
			labelUnitTemperature.Text = "°C";
			// 
			// labelUnitVolumetricFlow
			// 
			labelUnitVolumetricFlow.Anchor = System.Windows.Forms.AnchorStyles.Left;
			labelUnitVolumetricFlow.AutoSize = true;
			labelUnitVolumetricFlow.Location = new System.Drawing.Point(228, 69);
			labelUnitVolumetricFlow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelUnitVolumetricFlow.Name = "labelUnitVolumetricFlow";
			labelUnitVolumetricFlow.Size = new System.Drawing.Size(34, 15);
			labelUnitVolumetricFlow.TabIndex = 12;
			labelUnitVolumetricFlow.Text = "CCM";
			// 
			// labelUnitMassFlow
			// 
			labelUnitMassFlow.Anchor = System.Windows.Forms.AnchorStyles.Left;
			labelUnitMassFlow.AutoSize = true;
			labelUnitMassFlow.Location = new System.Drawing.Point(228, 98);
			labelUnitMassFlow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelUnitMassFlow.Name = "labelUnitMassFlow";
			labelUnitMassFlow.Size = new System.Drawing.Size(40, 15);
			labelUnitMassFlow.TabIndex = 13;
			labelUnitMassFlow.Text = "SCCM";
			// 
			// labelSetpoint
			// 
			labelSetpoint.Anchor = System.Windows.Forms.AnchorStyles.Left;
			labelSetpoint.AutoSize = true;
			labelSetpoint.Location = new System.Drawing.Point(4, 162);
			labelSetpoint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelSetpoint.Name = "labelSetpoint";
			labelSetpoint.Size = new System.Drawing.Size(51, 15);
			labelSetpoint.TabIndex = 8;
			labelSetpoint.Text = "Setpoint";
			// 
			// textBoxSetpoint
			// 
			textBoxSetpoint.Location = new System.Drawing.Point(104, 156);
			textBoxSetpoint.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			textBoxSetpoint.Name = "textBoxSetpoint";
			textBoxSetpoint.Size = new System.Drawing.Size(116, 23);
			textBoxSetpoint.TabIndex = 9;
			// 
			// labelUnitSetpoint
			// 
			labelUnitSetpoint.Anchor = System.Windows.Forms.AnchorStyles.Left;
			labelUnitSetpoint.AutoSize = true;
			labelUnitSetpoint.Location = new System.Drawing.Point(228, 162);
			labelUnitSetpoint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelUnitSetpoint.Name = "labelUnitSetpoint";
			labelUnitSetpoint.Size = new System.Drawing.Size(40, 15);
			labelUnitSetpoint.TabIndex = 14;
			labelUnitSetpoint.Text = "SCCM";
			// 
			// labelGas
			// 
			labelGas.Anchor = System.Windows.Forms.AnchorStyles.Left;
			labelGas.AutoSize = true;
			labelGas.Location = new System.Drawing.Point(4, 129);
			labelGas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelGas.Name = "labelGas";
			labelGas.Size = new System.Drawing.Size(26, 15);
			labelGas.TabIndex = 15;
			labelGas.Text = "Gas";
			// 
			// comboBoxGas
			// 
			comboBoxGas.FormattingEnabled = true;
			comboBoxGas.Location = new System.Drawing.Point(104, 123);
			comboBoxGas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			comboBoxGas.Name = "comboBoxGas";
			comboBoxGas.Size = new System.Drawing.Size(116, 23);
			comboBoxGas.TabIndex = 16;
			// 
			// buttonWriteSP
			// 
			buttonWriteSP.Location = new System.Drawing.Point(277, 156);
			buttonWriteSP.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			buttonWriteSP.Name = "buttonWriteSP";
			buttonWriteSP.Size = new System.Drawing.Size(88, 27);
			buttonWriteSP.TabIndex = 10;
			buttonWriteSP.Text = "Write SP";
			buttonWriteSP.UseVisualStyleBackColor = true;
			buttonWriteSP.Click += ButtonWrite_Click;
			// 
			// buttonWriteGas
			// 
			buttonWriteGas.Location = new System.Drawing.Point(277, 123);
			buttonWriteGas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			buttonWriteGas.Name = "buttonWriteGas";
			buttonWriteGas.Size = new System.Drawing.Size(88, 27);
			buttonWriteGas.TabIndex = 17;
			buttonWriteGas.Text = "Write Gas";
			buttonWriteGas.UseVisualStyleBackColor = true;
			buttonWriteGas.Click += ButtonWriteGas_Click;
			// 
			// statusStrip1
			// 
			statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel });
			statusStrip1.Location = new System.Drawing.Point(0, 320);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
			statusStrip1.Size = new System.Drawing.Size(390, 22);
			statusStrip1.TabIndex = 3;
			statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel
			// 
			toolStripStatusLabel.Name = "toolStripStatusLabel";
			toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
			toolStripStatusLabel.Text = "Ready";
			// 
			// FormMassFlow
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(390, 342);
			Controls.Add(statusStrip1);
			Controls.Add(groupBoxMassFlowControl);
			Controls.Add(groupBoxSerialPort);
			Controls.Add(menuStrip1);
			MainMenuStrip = menuStrip1;
			Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			MaximizeBox = false;
			Name = "FormMassFlow";
			Text = "Mass Flow Controller";
			FormClosed += FormMassFlow_FormClosed;
			groupBoxSerialPort.ResumeLayout(false);
			groupBoxSerialPort.PerformLayout();
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			groupBoxMassFlowControl.ResumeLayout(false);
			groupBoxMassFlowControl.PerformLayout();
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			statusStrip1.ResumeLayout(false);
			statusStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.GroupBox groupBoxSerialPort;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.RadioButton radioButtonClosed;
		private System.Windows.Forms.RadioButton radioButtonOpen;
		private System.Windows.Forms.ComboBox comboBoxSerialPort;
		private System.Windows.Forms.GroupBox groupBoxMassFlowControl;
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
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
	}
}

