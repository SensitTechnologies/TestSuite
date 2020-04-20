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
			this.groupBoxGasses = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanelMassFlow = new System.Windows.Forms.TableLayoutPanel();
			this.labelAnalyte = new System.Windows.Forms.Label();
			this.labelDiluent = new System.Windows.Forms.Label();
			this.comboBoxDiluentGas = new System.Windows.Forms.ComboBox();
			this.comboBoxAnalyteGas = new System.Windows.Forms.ComboBox();
			this.labelGas = new System.Windows.Forms.Label();
			this.labelUnitSetpoint = new System.Windows.Forms.Label();
			this.buttonWriteGas = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.groupBoxFlowAndMixture = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanelGasConcentration = new System.Windows.Forms.TableLayoutPanel();
			this.labelUnitGasConcentration = new System.Windows.Forms.Label();
			this.labelTotalMassFlow = new System.Windows.Forms.Label();
			this.labelConcentration = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxMassFlow = new System.Windows.Forms.TextBox();
			this.textBoxGasConcentration = new System.Windows.Forms.TextBox();
			this.buttonReadAll = new System.Windows.Forms.Button();
			this.buttonWriteAll = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.groupBoxSerialPorts.SuspendLayout();
			this.groupBoxGasses.SuspendLayout();
			this.tableLayoutPanelMassFlow.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.groupBoxFlowAndMixture.SuspendLayout();
			this.tableLayoutPanelGasConcentration.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(387, 24);
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
			this.groupBoxSerialPorts.Size = new System.Drawing.Size(387, 72);
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
			this.radioButtonOpen.TabIndex = 2;
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
			this.comboBoxDiluentPort.TabIndex = 1;
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
			// groupBoxGasses
			// 
			this.groupBoxGasses.AutoSize = true;
			this.groupBoxGasses.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxGasses.Controls.Add(this.tableLayoutPanelMassFlow);
			this.groupBoxGasses.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBoxGasses.Enabled = false;
			this.groupBoxGasses.Location = new System.Drawing.Point(0, 96);
			this.groupBoxGasses.Name = "groupBoxGasses";
			this.groupBoxGasses.Size = new System.Drawing.Size(387, 80);
			this.groupBoxGasses.TabIndex = 3;
			this.groupBoxGasses.TabStop = false;
			this.groupBoxGasses.Text = "Gasses";
			// 
			// tableLayoutPanelMassFlow
			// 
			this.tableLayoutPanelMassFlow.AutoSize = true;
			this.tableLayoutPanelMassFlow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelMassFlow.ColumnCount = 4;
			this.tableLayoutPanelMassFlow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelMassFlow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelMassFlow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelMassFlow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelMassFlow.Controls.Add(this.labelAnalyte, 1, 0);
			this.tableLayoutPanelMassFlow.Controls.Add(this.labelDiluent, 2, 0);
			this.tableLayoutPanelMassFlow.Controls.Add(this.comboBoxDiluentGas, 2, 1);
			this.tableLayoutPanelMassFlow.Controls.Add(this.comboBoxAnalyteGas, 1, 1);
			this.tableLayoutPanelMassFlow.Controls.Add(this.labelGas, 0, 1);
			this.tableLayoutPanelMassFlow.Controls.Add(this.labelUnitSetpoint, 3, 0);
			this.tableLayoutPanelMassFlow.Controls.Add(this.buttonWriteGas, 3, 1);
			this.tableLayoutPanelMassFlow.Location = new System.Drawing.Point(6, 19);
			this.tableLayoutPanelMassFlow.Name = "tableLayoutPanelMassFlow";
			this.tableLayoutPanelMassFlow.RowCount = 2;
			this.tableLayoutPanelMassFlow.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMassFlow.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMassFlow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanelMassFlow.Size = new System.Drawing.Size(325, 42);
			this.tableLayoutPanelMassFlow.TabIndex = 1;
			// 
			// labelAnalyte
			// 
			this.labelAnalyte.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelAnalyte.AutoSize = true;
			this.labelAnalyte.Location = new System.Drawing.Point(64, 0);
			this.labelAnalyte.Name = "labelAnalyte";
			this.labelAnalyte.Size = new System.Drawing.Size(42, 13);
			this.labelAnalyte.TabIndex = 23;
			this.labelAnalyte.Text = "Analyte";
			// 
			// labelDiluent
			// 
			this.labelDiluent.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelDiluent.AutoSize = true;
			this.labelDiluent.Location = new System.Drawing.Point(171, 0);
			this.labelDiluent.Name = "labelDiluent";
			this.labelDiluent.Size = new System.Drawing.Size(40, 13);
			this.labelDiluent.TabIndex = 24;
			this.labelDiluent.Text = "Diluent";
			// 
			// comboBoxDiluentGas
			// 
			this.comboBoxDiluentGas.FormattingEnabled = true;
			this.comboBoxDiluentGas.Location = new System.Drawing.Point(141, 16);
			this.comboBoxDiluentGas.Name = "comboBoxDiluentGas";
			this.comboBoxDiluentGas.Size = new System.Drawing.Size(100, 21);
			this.comboBoxDiluentGas.TabIndex = 4;
			this.comboBoxDiluentGas.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDiluentGas_SelectedIndexChanged);
			// 
			// comboBoxAnalyteGas
			// 
			this.comboBoxAnalyteGas.FormattingEnabled = true;
			this.comboBoxAnalyteGas.Location = new System.Drawing.Point(35, 16);
			this.comboBoxAnalyteGas.Name = "comboBoxAnalyteGas";
			this.comboBoxAnalyteGas.Size = new System.Drawing.Size(100, 21);
			this.comboBoxAnalyteGas.TabIndex = 3;
			this.comboBoxAnalyteGas.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAnalyteGas_SelectedIndexChanged);
			// 
			// labelGas
			// 
			this.labelGas.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelGas.AutoSize = true;
			this.labelGas.Location = new System.Drawing.Point(3, 21);
			this.labelGas.Name = "labelGas";
			this.labelGas.Size = new System.Drawing.Size(26, 13);
			this.labelGas.TabIndex = 15;
			this.labelGas.Text = "Gas";
			// 
			// labelUnitSetpoint
			// 
			this.labelUnitSetpoint.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelUnitSetpoint.AutoSize = true;
			this.labelUnitSetpoint.Location = new System.Drawing.Point(247, 0);
			this.labelUnitSetpoint.Name = "labelUnitSetpoint";
			this.labelUnitSetpoint.Size = new System.Drawing.Size(37, 13);
			this.labelUnitSetpoint.TabIndex = 14;
			this.labelUnitSetpoint.Text = "SCCM";
			// 
			// buttonWriteGas
			// 
			this.buttonWriteGas.Location = new System.Drawing.Point(247, 16);
			this.buttonWriteGas.Name = "buttonWriteGas";
			this.buttonWriteGas.Size = new System.Drawing.Size(75, 23);
			this.buttonWriteGas.TabIndex = 5;
			this.buttonWriteGas.Text = "Write Gas";
			this.buttonWriteGas.UseVisualStyleBackColor = true;
			this.buttonWriteGas.Click += new System.EventHandler(this.buttonWriteGas_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 265);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(387, 22);
			this.statusStrip1.TabIndex = 4;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
			this.toolStripStatusLabel1.Text = "Ready";
			// 
			// groupBoxFlowAndMixture
			// 
			this.groupBoxFlowAndMixture.AutoSize = true;
			this.groupBoxFlowAndMixture.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxFlowAndMixture.Controls.Add(this.tableLayoutPanelGasConcentration);
			this.groupBoxFlowAndMixture.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxFlowAndMixture.Enabled = false;
			this.groupBoxFlowAndMixture.Location = new System.Drawing.Point(0, 176);
			this.groupBoxFlowAndMixture.Name = "groupBoxFlowAndMixture";
			this.groupBoxFlowAndMixture.Size = new System.Drawing.Size(387, 89);
			this.groupBoxFlowAndMixture.TabIndex = 5;
			this.groupBoxFlowAndMixture.TabStop = false;
			this.groupBoxFlowAndMixture.Text = "Flow && Mixture";
			// 
			// tableLayoutPanelGasConcentration
			// 
			this.tableLayoutPanelGasConcentration.AutoSize = true;
			this.tableLayoutPanelGasConcentration.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelGasConcentration.ColumnCount = 5;
			this.tableLayoutPanelGasConcentration.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelGasConcentration.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelGasConcentration.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelGasConcentration.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelGasConcentration.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelGasConcentration.Controls.Add(this.labelUnitGasConcentration, 2, 1);
			this.tableLayoutPanelGasConcentration.Controls.Add(this.labelTotalMassFlow, 0, 0);
			this.tableLayoutPanelGasConcentration.Controls.Add(this.labelConcentration, 0, 1);
			this.tableLayoutPanelGasConcentration.Controls.Add(this.label1, 2, 0);
			this.tableLayoutPanelGasConcentration.Controls.Add(this.textBoxMassFlow, 1, 0);
			this.tableLayoutPanelGasConcentration.Controls.Add(this.textBoxGasConcentration, 1, 1);
			this.tableLayoutPanelGasConcentration.Controls.Add(this.buttonReadAll, 4, 0);
			this.tableLayoutPanelGasConcentration.Controls.Add(this.buttonWriteAll, 4, 1);
			this.tableLayoutPanelGasConcentration.Location = new System.Drawing.Point(12, 19);
			this.tableLayoutPanelGasConcentration.Name = "tableLayoutPanelGasConcentration";
			this.tableLayoutPanelGasConcentration.RowCount = 2;
			this.tableLayoutPanelGasConcentration.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelGasConcentration.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelGasConcentration.Size = new System.Drawing.Size(334, 58);
			this.tableLayoutPanelGasConcentration.TabIndex = 0;
			// 
			// labelUnitGasConcentration
			// 
			this.labelUnitGasConcentration.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelUnitGasConcentration.AutoSize = true;
			this.labelUnitGasConcentration.Location = new System.Drawing.Point(210, 37);
			this.labelUnitGasConcentration.Name = "labelUnitGasConcentration";
			this.labelUnitGasConcentration.Size = new System.Drawing.Size(40, 13);
			this.labelUnitGasConcentration.TabIndex = 8;
			this.labelUnitGasConcentration.Text = "% Flow";
			// 
			// labelTotalMassFlow
			// 
			this.labelTotalMassFlow.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelTotalMassFlow.AutoSize = true;
			this.labelTotalMassFlow.Location = new System.Drawing.Point(3, 8);
			this.labelTotalMassFlow.Name = "labelTotalMassFlow";
			this.labelTotalMassFlow.Size = new System.Drawing.Size(84, 13);
			this.labelTotalMassFlow.TabIndex = 15;
			this.labelTotalMassFlow.Text = "Total Mass Flow";
			// 
			// labelConcentration
			// 
			this.labelConcentration.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelConcentration.AutoSize = true;
			this.labelConcentration.Location = new System.Drawing.Point(3, 37);
			this.labelConcentration.Name = "labelConcentration";
			this.labelConcentration.Size = new System.Drawing.Size(95, 13);
			this.labelConcentration.TabIndex = 0;
			this.labelConcentration.Text = "Gas Concentration";
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(210, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 13);
			this.label1.TabIndex = 17;
			this.label1.Text = "SCCM";
			// 
			// textBoxMassFlow
			// 
			this.textBoxMassFlow.Location = new System.Drawing.Point(104, 3);
			this.textBoxMassFlow.Name = "textBoxMassFlow";
			this.textBoxMassFlow.Size = new System.Drawing.Size(100, 20);
			this.textBoxMassFlow.TabIndex = 6;
			// 
			// textBoxGasConcentration
			// 
			this.textBoxGasConcentration.Location = new System.Drawing.Point(104, 32);
			this.textBoxGasConcentration.Name = "textBoxGasConcentration";
			this.textBoxGasConcentration.Size = new System.Drawing.Size(100, 20);
			this.textBoxGasConcentration.TabIndex = 8;
			// 
			// buttonReadAll
			// 
			this.buttonReadAll.Location = new System.Drawing.Point(256, 3);
			this.buttonReadAll.Name = "buttonReadAll";
			this.buttonReadAll.Size = new System.Drawing.Size(75, 23);
			this.buttonReadAll.TabIndex = 7;
			this.buttonReadAll.Text = "Read All";
			this.buttonReadAll.UseVisualStyleBackColor = true;
			this.buttonReadAll.Click += new System.EventHandler(this.buttonReadConcentration_Click);
			// 
			// buttonWriteAll
			// 
			this.buttonWriteAll.Location = new System.Drawing.Point(256, 32);
			this.buttonWriteAll.Name = "buttonWriteAll";
			this.buttonWriteAll.Size = new System.Drawing.Size(75, 23);
			this.buttonWriteAll.TabIndex = 9;
			this.buttonWriteAll.Text = "Write All";
			this.buttonWriteAll.UseVisualStyleBackColor = true;
			this.buttonWriteAll.Click += new System.EventHandler(this.buttonWriteGasConcentrationSetpoint_Click);
			// 
			// FormGasMixer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(387, 287);
			this.Controls.Add(this.groupBoxFlowAndMixture);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.groupBoxGasses);
			this.Controls.Add(this.groupBoxSerialPorts);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "FormGasMixer";
			this.Text = "Gas Mix Utility";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormGasConcentration_FormClosed);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.groupBoxSerialPorts.ResumeLayout(false);
			this.groupBoxSerialPorts.PerformLayout();
			this.groupBoxGasses.ResumeLayout(false);
			this.groupBoxGasses.PerformLayout();
			this.tableLayoutPanelMassFlow.ResumeLayout(false);
			this.tableLayoutPanelMassFlow.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.groupBoxFlowAndMixture.ResumeLayout(false);
			this.groupBoxFlowAndMixture.PerformLayout();
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
		private System.Windows.Forms.GroupBox groupBoxGasses;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMassFlow;
		private System.Windows.Forms.Label labelGas;
		private System.Windows.Forms.ComboBox comboBoxAnalyteGas;
		private System.Windows.Forms.Label labelDiluentPort;
		private System.Windows.Forms.Label labelAnalytePort;
		private System.Windows.Forms.ComboBox comboBoxDiluentGas;
		private System.Windows.Forms.Label labelAnalyte;
		private System.Windows.Forms.Label labelDiluent;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.GroupBox groupBoxFlowAndMixture;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGasConcentration;
		private System.Windows.Forms.Label labelConcentration;
		private System.Windows.Forms.TextBox textBoxMassFlow;
		private System.Windows.Forms.Label labelUnitGasConcentration;
		private System.Windows.Forms.Button buttonReadAll;
		private System.Windows.Forms.Label labelTotalMassFlow;
		private System.Windows.Forms.TextBox textBoxGasConcentration;
		private System.Windows.Forms.Button buttonWriteAll;
		private System.Windows.Forms.Label labelUnitSetpoint;
		private System.Windows.Forms.Button buttonWriteGas;
		private System.Windows.Forms.Label label1;
	}
}

