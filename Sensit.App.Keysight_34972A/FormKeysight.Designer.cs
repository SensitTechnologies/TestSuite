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
            this.groupBoxScpi = new System.Windows.Forms.GroupBox();
            this.updownNumDut1 = new System.Windows.Forms.NumericUpDown();
            this.textboxVout1 = new System.Windows.Forms.TextBox();
            this.buttonMeasure1 = new System.Windows.Forms.Button();
            this.groupBoxVisa.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBoxScpi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updownNumDut1)).BeginInit();
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
            this.groupBoxVisa.Size = new System.Drawing.Size(404, 83);
            this.groupBoxVisa.TabIndex = 1;
            this.groupBoxVisa.TabStop = false;
            this.groupBoxVisa.Text = "VISA Devices";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefresh.AutoSize = true;
            this.buttonRefresh.Location = new System.Drawing.Point(323, 20);
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
            this.comboBoxResources.FormattingEnabled = true;
            this.comboBoxResources.Location = new System.Drawing.Point(13, 20);
            this.comboBoxResources.Name = "comboBoxResources";
            this.comboBoxResources.Size = new System.Drawing.Size(234, 21);
            this.comboBoxResources.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 359);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(404, 22);
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
            this.menuStrip1.Size = new System.Drawing.Size(404, 24);
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
            // groupBoxScpi
            // 
            this.groupBoxScpi.AutoSize = true;
            this.groupBoxScpi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxScpi.Controls.Add(this.updownNumDut1);
            this.groupBoxScpi.Controls.Add(this.textboxVout1);
            this.groupBoxScpi.Controls.Add(this.buttonMeasure1);
            this.groupBoxScpi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxScpi.Location = new System.Drawing.Point(0, 107);
            this.groupBoxScpi.Name = "groupBoxScpi";
            this.groupBoxScpi.Size = new System.Drawing.Size(404, 252);
            this.groupBoxScpi.TabIndex = 4;
            this.groupBoxScpi.TabStop = false;
            this.groupBoxScpi.Text = "SCPI";
            // 
            // updownNumDut1
            // 
            this.updownNumDut1.Location = new System.Drawing.Point(7, 48);
            this.updownNumDut1.Name = "updownNumDut1";
            this.updownNumDut1.Size = new System.Drawing.Size(120, 20);
            this.updownNumDut1.TabIndex = 2;
            this.updownNumDut1.ValueChanged += new System.EventHandler(this.numDut1_ValueChanged);
            // 
            // textboxVout1
            // 
            this.textboxVout1.Location = new System.Drawing.Point(292, 48);
            this.textboxVout1.Multiline = true;
            this.textboxVout1.Name = "textboxVout1";
            this.textboxVout1.Size = new System.Drawing.Size(100, 20);
            this.textboxVout1.TabIndex = 1;
            // 
            // buttonMeasure1
            // 
            this.buttonMeasure1.Location = new System.Drawing.Point(172, 48);
            this.buttonMeasure1.Name = "buttonMeasure1";
            this.buttonMeasure1.Size = new System.Drawing.Size(75, 23);
            this.buttonMeasure1.TabIndex = 0;
            this.buttonMeasure1.Text = "Measure";
            this.buttonMeasure1.UseVisualStyleBackColor = true;
            this.buttonMeasure1.Click += new System.EventHandler(this.buttonMeasure1_Click);
            // 
            // FormKeysight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 381);
            this.Controls.Add(this.groupBoxScpi);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBoxVisa);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormKeysight";
            this.Text = "Keysight 34972A Datalogger";
            this.groupBoxVisa.ResumeLayout(false);
            this.groupBoxVisa.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxScpi.ResumeLayout(false);
            this.groupBoxScpi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updownNumDut1)).EndInit();
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
		private System.Windows.Forms.GroupBox groupBoxScpi;
        private System.Windows.Forms.TextBox textboxVout1;
        private System.Windows.Forms.Button buttonMeasure1;
        private System.Windows.Forms.NumericUpDown updownNumDut1;
    }
}

