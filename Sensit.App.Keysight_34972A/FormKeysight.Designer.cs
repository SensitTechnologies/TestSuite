namespace Sensit.App.Keysight
{
	partial class FormKeysight
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
			this.groupBoxVisa = new System.Windows.Forms.GroupBox();
			this.buttonRefresh = new System.Windows.Forms.Button();
			this.radioButtonClosed = new System.Windows.Forms.RadioButton();
			this.radioButtonOpen = new System.Windows.Forms.RadioButton();
			this.comboBoxResources = new System.Windows.Forms.ComboBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBoxConfiguration = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDownNumChannels = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownBank = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonConfigure = new System.Windows.Forms.Button();
			this.buttonMeasure = new System.Windows.Forms.Button();
			this.groupBoxData = new System.Windows.Forms.GroupBox();
			this.dataGridViewMeasurements = new System.Windows.Forms.DataGridView();
			this.groupBoxVisa.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.groupBoxConfiguration.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumChannels)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownBank)).BeginInit();
			this.groupBoxData.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewMeasurements)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBoxVisa
			// 
			this.groupBoxVisa.AutoSize = true;
			this.groupBoxVisa.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxVisa.Controls.Add(this.buttonRefresh);
			this.groupBoxVisa.Controls.Add(this.radioButtonClosed);
			this.groupBoxVisa.Controls.Add(this.radioButtonOpen);
			this.groupBoxVisa.Controls.Add(this.comboBoxResources);
			this.groupBoxVisa.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBoxVisa.Location = new System.Drawing.Point(0, 24);
			this.groupBoxVisa.Name = "groupBoxVisa";
			this.groupBoxVisa.Size = new System.Drawing.Size(284, 89);
			this.groupBoxVisa.TabIndex = 1;
			this.groupBoxVisa.TabStop = false;
			this.groupBoxVisa.Text = "VISA Devices";
			// 
			// buttonRefresh
			// 
			this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRefresh.AutoSize = true;
			this.buttonRefresh.Location = new System.Drawing.Point(197, 47);
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
			this.buttonRefresh.TabIndex = 3;
			this.buttonRefresh.Text = "Refresh";
			this.buttonRefresh.UseVisualStyleBackColor = true;
			this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
			// 
			// radioButtonClosed
			// 
			this.radioButtonClosed.AutoSize = true;
			this.radioButtonClosed.Checked = true;
			this.radioButtonClosed.Location = new System.Drawing.Point(70, 47);
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
			this.radioButtonOpen.Location = new System.Drawing.Point(13, 47);
			this.radioButtonOpen.Name = "radioButtonOpen";
			this.radioButtonOpen.Size = new System.Drawing.Size(51, 17);
			this.radioButtonOpen.TabIndex = 1;
			this.radioButtonOpen.Text = "Open";
			this.radioButtonOpen.UseVisualStyleBackColor = true;
			this.radioButtonOpen.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// comboBoxResources
			// 
			this.comboBoxResources.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxResources.FormattingEnabled = true;
			this.comboBoxResources.Location = new System.Drawing.Point(13, 20);
			this.comboBoxResources.Name = "comboBoxResources";
			this.comboBoxResources.Size = new System.Drawing.Size(259, 21);
			this.comboBoxResources.TabIndex = 0;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 379);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(284, 22);
			this.statusStrip1.TabIndex = 3;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
			this.toolStripStatusLabel1.Text = "Ready";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(284, 24);
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
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
			this.exitToolStripMenuItem.Text = "&Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// groupBoxConfiguration
			// 
			this.groupBoxConfiguration.AutoSize = true;
			this.groupBoxConfiguration.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxConfiguration.Controls.Add(this.tableLayoutPanel1);
			this.groupBoxConfiguration.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBoxConfiguration.Enabled = false;
			this.groupBoxConfiguration.Location = new System.Drawing.Point(0, 113);
			this.groupBoxConfiguration.Name = "groupBoxConfiguration";
			this.groupBoxConfiguration.Size = new System.Drawing.Size(284, 94);
			this.groupBoxConfiguration.TabIndex = 4;
			this.groupBoxConfiguration.TabStop = false;
			this.groupBoxConfiguration.Text = "Datalogger Configuration";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.numericUpDownNumChannels, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.numericUpDownBank, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label3, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.buttonConfigure, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.buttonMeasure, 1, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(278, 75);
			this.tableLayoutPanel1.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(53, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Bank";
			// 
			// numericUpDownNumChannels
			// 
			this.numericUpDownNumChannels.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.numericUpDownNumChannels.Location = new System.Drawing.Point(168, 23);
			this.numericUpDownNumChannels.Name = "numericUpDownNumChannels";
			this.numericUpDownNumChannels.Size = new System.Drawing.Size(80, 20);
			this.numericUpDownNumChannels.TabIndex = 3;
			// 
			// numericUpDownBank
			// 
			this.numericUpDownBank.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.numericUpDownBank.Location = new System.Drawing.Point(29, 23);
			this.numericUpDownBank.Name = "numericUpDownBank";
			this.numericUpDownBank.Size = new System.Drawing.Size(80, 20);
			this.numericUpDownBank.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(142, 3);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(103, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Number of Channels";
			// 
			// buttonConfigure
			// 
			this.buttonConfigure.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.buttonConfigure.Location = new System.Drawing.Point(32, 49);
			this.buttonConfigure.Name = "buttonConfigure";
			this.buttonConfigure.Size = new System.Drawing.Size(75, 23);
			this.buttonConfigure.TabIndex = 8;
			this.buttonConfigure.Text = "Configure";
			this.buttonConfigure.UseVisualStyleBackColor = true;
			this.buttonConfigure.Click += new System.EventHandler(this.buttonConfigure_Click);
			// 
			// buttonMeasure
			// 
			this.buttonMeasure.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.buttonMeasure.Location = new System.Drawing.Point(171, 49);
			this.buttonMeasure.Name = "buttonMeasure";
			this.buttonMeasure.Size = new System.Drawing.Size(75, 23);
			this.buttonMeasure.TabIndex = 6;
			this.buttonMeasure.Text = "Measure";
			this.buttonMeasure.UseVisualStyleBackColor = true;
			this.buttonMeasure.Click += new System.EventHandler(this.buttonMeasure_Click);
			// 
			// groupBoxData
			// 
			this.groupBoxData.Controls.Add(this.dataGridViewMeasurements);
			this.groupBoxData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxData.Location = new System.Drawing.Point(0, 207);
			this.groupBoxData.Name = "groupBoxData";
			this.groupBoxData.Size = new System.Drawing.Size(284, 172);
			this.groupBoxData.TabIndex = 5;
			this.groupBoxData.TabStop = false;
			this.groupBoxData.Text = "Data";
			// 
			// dataGridViewMeasurements
			// 
			this.dataGridViewMeasurements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewMeasurements.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewMeasurements.Location = new System.Drawing.Point(3, 16);
			this.dataGridViewMeasurements.Name = "dataGridViewMeasurements";
			this.dataGridViewMeasurements.Size = new System.Drawing.Size(278, 153);
			this.dataGridViewMeasurements.TabIndex = 0;
			// 
			// FormKeysight
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 401);
			this.Controls.Add(this.groupBoxData);
			this.Controls.Add(this.groupBoxConfiguration);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.groupBoxVisa);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "FormKeysight";
			this.Text = "Keysight 34972A Datalogger";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormKeysight_FormClosing);
			this.groupBoxVisa.ResumeLayout(false);
			this.groupBoxVisa.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.groupBoxConfiguration.ResumeLayout(false);
			this.groupBoxConfiguration.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumChannels)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownBank)).EndInit();
			this.groupBoxData.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewMeasurements)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBoxVisa;
		private System.Windows.Forms.RadioButton radioButtonClosed;
		private System.Windows.Forms.RadioButton radioButtonOpen;
		private System.Windows.Forms.ComboBox comboBoxResources;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.Button buttonRefresh;
		private System.Windows.Forms.GroupBox groupBoxConfiguration;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.GroupBox groupBoxData;
		private System.Windows.Forms.DataGridView dataGridViewMeasurements;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numericUpDownNumChannels;
		private System.Windows.Forms.NumericUpDown numericUpDownBank;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button buttonConfigure;
		private System.Windows.Forms.Button buttonMeasure;
	}
}

