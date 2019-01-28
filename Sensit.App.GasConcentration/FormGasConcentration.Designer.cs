namespace Sensit.App.GasConcentration
{
	partial class FormGasConcentration
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
			this.groupBoxSerialPort1 = new System.Windows.Forms.GroupBox();
			this.radioButtonClosed1 = new System.Windows.Forms.RadioButton();
			this.radioButtonOpen1 = new System.Windows.Forms.RadioButton();
			this.comboBoxSerialPort1 = new System.Windows.Forms.ComboBox();
			this.groupBoxSerialPort2 = new System.Windows.Forms.GroupBox();
			this.radioButtonClosed2 = new System.Windows.Forms.RadioButton();
			this.radioButtonOpen2 = new System.Windows.Forms.RadioButton();
			this.comboBoxSerialPort2 = new System.Windows.Forms.ComboBox();
			this.menuStrip1.SuspendLayout();
			this.groupBoxSerialPort1.SuspendLayout();
			this.groupBoxSerialPort2.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(334, 24);
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
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.exitToolStripMenuItem.Text = "&Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// groupBoxSerialPort1
			// 
			this.groupBoxSerialPort1.AutoSize = true;
			this.groupBoxSerialPort1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxSerialPort1.Controls.Add(this.radioButtonClosed1);
			this.groupBoxSerialPort1.Controls.Add(this.radioButtonOpen1);
			this.groupBoxSerialPort1.Controls.Add(this.comboBoxSerialPort1);
			this.groupBoxSerialPort1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBoxSerialPort1.Location = new System.Drawing.Point(0, 24);
			this.groupBoxSerialPort1.Name = "groupBoxSerialPort1";
			this.groupBoxSerialPort1.Size = new System.Drawing.Size(334, 60);
			this.groupBoxSerialPort1.TabIndex = 1;
			this.groupBoxSerialPort1.TabStop = false;
			this.groupBoxSerialPort1.Text = "Serial Port 1";
			// 
			// radioButtonClosed1
			// 
			this.radioButtonClosed1.AutoSize = true;
			this.radioButtonClosed1.Checked = true;
			this.radioButtonClosed1.Location = new System.Drawing.Point(199, 23);
			this.radioButtonClosed1.Name = "radioButtonClosed1";
			this.radioButtonClosed1.Size = new System.Drawing.Size(57, 17);
			this.radioButtonClosed1.TabIndex = 2;
			this.radioButtonClosed1.TabStop = true;
			this.radioButtonClosed1.Text = "Closed";
			this.radioButtonClosed1.UseVisualStyleBackColor = true;
			// 
			// radioButtonOpen1
			// 
			this.radioButtonOpen1.AutoSize = true;
			this.radioButtonOpen1.Location = new System.Drawing.Point(141, 23);
			this.radioButtonOpen1.Name = "radioButtonOpen1";
			this.radioButtonOpen1.Size = new System.Drawing.Size(51, 17);
			this.radioButtonOpen1.TabIndex = 1;
			this.radioButtonOpen1.Text = "Open";
			this.radioButtonOpen1.UseVisualStyleBackColor = true;
			// 
			// comboBoxSerialPort1
			// 
			this.comboBoxSerialPort1.FormattingEnabled = true;
			this.comboBoxSerialPort1.Location = new System.Drawing.Point(13, 20);
			this.comboBoxSerialPort1.Name = "comboBoxSerialPort1";
			this.comboBoxSerialPort1.Size = new System.Drawing.Size(121, 21);
			this.comboBoxSerialPort1.TabIndex = 0;
			// 
			// groupBoxSerialPort2
			// 
			this.groupBoxSerialPort2.AutoSize = true;
			this.groupBoxSerialPort2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxSerialPort2.Controls.Add(this.radioButtonClosed2);
			this.groupBoxSerialPort2.Controls.Add(this.radioButtonOpen2);
			this.groupBoxSerialPort2.Controls.Add(this.comboBoxSerialPort2);
			this.groupBoxSerialPort2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBoxSerialPort2.Location = new System.Drawing.Point(0, 84);
			this.groupBoxSerialPort2.Name = "groupBoxSerialPort2";
			this.groupBoxSerialPort2.Size = new System.Drawing.Size(334, 60);
			this.groupBoxSerialPort2.TabIndex = 2;
			this.groupBoxSerialPort2.TabStop = false;
			this.groupBoxSerialPort2.Text = "Serial Port 2";
			// 
			// radioButtonClosed2
			// 
			this.radioButtonClosed2.AutoSize = true;
			this.radioButtonClosed2.Checked = true;
			this.radioButtonClosed2.Location = new System.Drawing.Point(199, 23);
			this.radioButtonClosed2.Name = "radioButtonClosed2";
			this.radioButtonClosed2.Size = new System.Drawing.Size(57, 17);
			this.radioButtonClosed2.TabIndex = 2;
			this.radioButtonClosed2.TabStop = true;
			this.radioButtonClosed2.Text = "Closed";
			this.radioButtonClosed2.UseVisualStyleBackColor = true;
			// 
			// radioButtonOpen2
			// 
			this.radioButtonOpen2.AutoSize = true;
			this.radioButtonOpen2.Location = new System.Drawing.Point(141, 23);
			this.radioButtonOpen2.Name = "radioButtonOpen2";
			this.radioButtonOpen2.Size = new System.Drawing.Size(51, 17);
			this.radioButtonOpen2.TabIndex = 1;
			this.radioButtonOpen2.Text = "Open";
			this.radioButtonOpen2.UseVisualStyleBackColor = true;
			// 
			// comboBoxSerialPort2
			// 
			this.comboBoxSerialPort2.FormattingEnabled = true;
			this.comboBoxSerialPort2.Location = new System.Drawing.Point(13, 20);
			this.comboBoxSerialPort2.Name = "comboBoxSerialPort2";
			this.comboBoxSerialPort2.Size = new System.Drawing.Size(121, 21);
			this.comboBoxSerialPort2.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 359);
			this.Controls.Add(this.groupBoxSerialPort2);
			this.Controls.Add(this.groupBoxSerialPort1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.groupBoxSerialPort1.ResumeLayout(false);
			this.groupBoxSerialPort1.PerformLayout();
			this.groupBoxSerialPort2.ResumeLayout(false);
			this.groupBoxSerialPort2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.GroupBox groupBoxSerialPort1;
		private System.Windows.Forms.RadioButton radioButtonClosed1;
		private System.Windows.Forms.RadioButton radioButtonOpen1;
		private System.Windows.Forms.ComboBox comboBoxSerialPort1;
		private System.Windows.Forms.GroupBox groupBoxSerialPort2;
		private System.Windows.Forms.RadioButton radioButtonClosed2;
		private System.Windows.Forms.RadioButton radioButtonOpen2;
		private System.Windows.Forms.ComboBox comboBoxSerialPort2;
	}
}

