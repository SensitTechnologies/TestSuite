namespace Sensit.App.G2GLT
{
	partial class FormG2GLT
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
			this.groupBoxSerialPorts = new System.Windows.Forms.GroupBox();
			this.radioButtonClosed = new System.Windows.Forms.RadioButton();
			this.radioButtonOpen = new System.Windows.Forms.RadioButton();
			this.comboBoxSerialPortRx = new System.Windows.Forms.ComboBox();
			this.comboBoxSerialPortTx = new System.Windows.Forms.ComboBox();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.groupBoxSerialPorts.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(394, 24);
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
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 428);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(394, 22);
			this.statusStrip1.TabIndex = 3;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
			this.toolStripStatusLabel1.Text = "Ready";
			// 
			// groupBoxSerialPorts
			// 
			this.groupBoxSerialPorts.AutoSize = true;
			this.groupBoxSerialPorts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxSerialPorts.Controls.Add(this.radioButtonClosed);
			this.groupBoxSerialPorts.Controls.Add(this.radioButtonOpen);
			this.groupBoxSerialPorts.Controls.Add(this.comboBoxSerialPortRx);
			this.groupBoxSerialPorts.Controls.Add(this.comboBoxSerialPortTx);
			this.groupBoxSerialPorts.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBoxSerialPorts.Location = new System.Drawing.Point(0, 24);
			this.groupBoxSerialPorts.Name = "groupBoxSerialPorts";
			this.groupBoxSerialPorts.Size = new System.Drawing.Size(394, 60);
			this.groupBoxSerialPorts.TabIndex = 4;
			this.groupBoxSerialPorts.TabStop = false;
			this.groupBoxSerialPorts.Text = "Serial Ports";
			// 
			// radioButtonClosed
			// 
			this.radioButtonClosed.AutoSize = true;
			this.radioButtonClosed.Checked = true;
			this.radioButtonClosed.Location = new System.Drawing.Point(324, 21);
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
			this.radioButtonOpen.Location = new System.Drawing.Point(267, 21);
			this.radioButtonOpen.Name = "radioButtonOpen";
			this.radioButtonOpen.Size = new System.Drawing.Size(51, 17);
			this.radioButtonOpen.TabIndex = 1;
			this.radioButtonOpen.Text = "Open";
			this.radioButtonOpen.UseVisualStyleBackColor = true;
			this.radioButtonOpen.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
			// 
			// comboBoxSerialPortRx
			// 
			this.comboBoxSerialPortRx.FormattingEnabled = true;
			this.comboBoxSerialPortRx.Location = new System.Drawing.Point(140, 20);
			this.comboBoxSerialPortRx.Name = "comboBoxSerialPortRx";
			this.comboBoxSerialPortRx.Size = new System.Drawing.Size(121, 21);
			this.comboBoxSerialPortRx.TabIndex = 0;
			this.comboBoxSerialPortRx.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSerialPortRx_SelectedIndexChanged);
			// 
			// comboBoxSerialPortTx
			// 
			this.comboBoxSerialPortTx.FormattingEnabled = true;
			this.comboBoxSerialPortTx.Location = new System.Drawing.Point(13, 20);
			this.comboBoxSerialPortTx.Name = "comboBoxSerialPortTx";
			this.comboBoxSerialPortTx.Size = new System.Drawing.Size(121, 21);
			this.comboBoxSerialPortTx.TabIndex = 0;
			this.comboBoxSerialPortTx.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSerialPortTx_SelectedIndexChanged);
			// 
			// FormG2GLT
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(394, 450);
			this.Controls.Add(this.groupBoxSerialPorts);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Name = "FormG2GLT";
			this.Text = "G2-GLT Interface";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormG2GLT_FormClosed);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.groupBoxSerialPorts.ResumeLayout(false);
			this.groupBoxSerialPorts.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.GroupBox groupBoxSerialPorts;
		private System.Windows.Forms.RadioButton radioButtonClosed;
		private System.Windows.Forms.RadioButton radioButtonOpen;
		private System.Windows.Forms.ComboBox comboBoxSerialPortRx;
		private System.Windows.Forms.ComboBox comboBoxSerialPortTx;
	}
}

