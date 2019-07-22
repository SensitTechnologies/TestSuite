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
			this.groupBoxSerialPort = new System.Windows.Forms.GroupBox();
			this.radioButtonClosed = new System.Windows.Forms.RadioButton();
			this.radioButtonOpen = new System.Windows.Forms.RadioButton();
			this.comboBoxSerialPort = new System.Windows.Forms.ComboBox();
			this.groupBoxCommands = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanelCommands = new System.Windows.Forms.TableLayoutPanel();
			this.labelMethane = new System.Windows.Forms.Label();
			this.labelOxygen = new System.Windows.Forms.Label();
			this.labelCarbonMonoxide = new System.Windows.Forms.Label();
			this.labelHydrogenSulfide = new System.Windows.Forms.Label();
			this.labeHydrogenCyanide = new System.Windows.Forms.Label();
			this.buttonReadMethane = new System.Windows.Forms.Button();
			this.buttonReadOxygen = new System.Windows.Forms.Button();
			this.buttonReadCarbonMonoxide = new System.Windows.Forms.Button();
			this.buttonReadHydrogenSulfide = new System.Windows.Forms.Button();
			this.buttonReadHydrogenCyanide = new System.Windows.Forms.Button();
			this.textBoxOxygen = new System.Windows.Forms.TextBox();
			this.textBoxMethane = new System.Windows.Forms.TextBox();
			this.textBoxCarbonMonoxide = new System.Windows.Forms.TextBox();
			this.textBoxHydrogenSulfide = new System.Windows.Forms.TextBox();
			this.textBoxHydrogenCyanide = new System.Windows.Forms.TextBox();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.groupBoxSerialPort.SuspendLayout();
			this.groupBoxCommands.SuspendLayout();
			this.tableLayoutPanelCommands.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(384, 24);
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
			this.statusStrip1.Location = new System.Drawing.Point(0, 269);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(384, 22);
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
			this.groupBoxSerialPort.Size = new System.Drawing.Size(384, 60);
			this.groupBoxSerialPort.TabIndex = 4;
			this.groupBoxSerialPort.TabStop = false;
			this.groupBoxSerialPort.Text = "Serial Port";
			// 
			// radioButtonClosed
			// 
			this.radioButtonClosed.AutoSize = true;
			this.radioButtonClosed.Checked = true;
			this.radioButtonClosed.Location = new System.Drawing.Point(190, 21);
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
			this.radioButtonOpen.Location = new System.Drawing.Point(140, 21);
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
			// groupBoxCommands
			// 
			this.groupBoxCommands.AutoSize = true;
			this.groupBoxCommands.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxCommands.Controls.Add(this.tableLayoutPanelCommands);
			this.groupBoxCommands.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxCommands.Enabled = false;
			this.groupBoxCommands.Location = new System.Drawing.Point(0, 84);
			this.groupBoxCommands.Name = "groupBoxCommands";
			this.groupBoxCommands.Size = new System.Drawing.Size(384, 185);
			this.groupBoxCommands.TabIndex = 5;
			this.groupBoxCommands.TabStop = false;
			this.groupBoxCommands.Text = "Commands";
			// 
			// tableLayoutPanelCommands
			// 
			this.tableLayoutPanelCommands.AutoSize = true;
			this.tableLayoutPanelCommands.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelCommands.ColumnCount = 3;
			this.tableLayoutPanelCommands.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelCommands.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelCommands.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelCommands.Controls.Add(this.labelMethane, 0, 0);
			this.tableLayoutPanelCommands.Controls.Add(this.labelOxygen, 0, 1);
			this.tableLayoutPanelCommands.Controls.Add(this.labelCarbonMonoxide, 0, 2);
			this.tableLayoutPanelCommands.Controls.Add(this.labelHydrogenSulfide, 0, 3);
			this.tableLayoutPanelCommands.Controls.Add(this.labeHydrogenCyanide, 0, 4);
			this.tableLayoutPanelCommands.Controls.Add(this.buttonReadMethane, 1, 0);
			this.tableLayoutPanelCommands.Controls.Add(this.buttonReadOxygen, 1, 1);
			this.tableLayoutPanelCommands.Controls.Add(this.buttonReadCarbonMonoxide, 1, 2);
			this.tableLayoutPanelCommands.Controls.Add(this.buttonReadHydrogenSulfide, 1, 3);
			this.tableLayoutPanelCommands.Controls.Add(this.buttonReadHydrogenCyanide, 1, 4);
			this.tableLayoutPanelCommands.Controls.Add(this.textBoxOxygen, 2, 1);
			this.tableLayoutPanelCommands.Controls.Add(this.textBoxMethane, 2, 0);
			this.tableLayoutPanelCommands.Controls.Add(this.textBoxCarbonMonoxide, 2, 2);
			this.tableLayoutPanelCommands.Controls.Add(this.textBoxHydrogenSulfide, 2, 3);
			this.tableLayoutPanelCommands.Controls.Add(this.textBoxHydrogenCyanide, 2, 4);
			this.tableLayoutPanelCommands.Location = new System.Drawing.Point(6, 19);
			this.tableLayoutPanelCommands.Name = "tableLayoutPanelCommands";
			this.tableLayoutPanelCommands.RowCount = 5;
			this.tableLayoutPanelCommands.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelCommands.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelCommands.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelCommands.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelCommands.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelCommands.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanelCommands.Size = new System.Drawing.Size(287, 145);
			this.tableLayoutPanelCommands.TabIndex = 1;
			// 
			// labelMethane
			// 
			this.labelMethane.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelMethane.AutoSize = true;
			this.labelMethane.Location = new System.Drawing.Point(3, 8);
			this.labelMethane.Name = "labelMethane";
			this.labelMethane.Size = new System.Drawing.Size(49, 13);
			this.labelMethane.TabIndex = 0;
			this.labelMethane.Text = "Methane";
			// 
			// labelOxygen
			// 
			this.labelOxygen.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelOxygen.AutoSize = true;
			this.labelOxygen.Location = new System.Drawing.Point(3, 37);
			this.labelOxygen.Name = "labelOxygen";
			this.labelOxygen.Size = new System.Drawing.Size(43, 13);
			this.labelOxygen.TabIndex = 1;
			this.labelOxygen.Text = "Oxygen";
			// 
			// labelCarbonMonoxide
			// 
			this.labelCarbonMonoxide.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelCarbonMonoxide.AutoSize = true;
			this.labelCarbonMonoxide.Location = new System.Drawing.Point(3, 66);
			this.labelCarbonMonoxide.Name = "labelCarbonMonoxide";
			this.labelCarbonMonoxide.Size = new System.Drawing.Size(90, 13);
			this.labelCarbonMonoxide.TabIndex = 4;
			this.labelCarbonMonoxide.Text = "Carbon Monoxide";
			// 
			// labelHydrogenSulfide
			// 
			this.labelHydrogenSulfide.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelHydrogenSulfide.AutoSize = true;
			this.labelHydrogenSulfide.Location = new System.Drawing.Point(3, 95);
			this.labelHydrogenSulfide.Name = "labelHydrogenSulfide";
			this.labelHydrogenSulfide.Size = new System.Drawing.Size(88, 13);
			this.labelHydrogenSulfide.TabIndex = 6;
			this.labelHydrogenSulfide.Text = "Hydrogen Sulfide";
			// 
			// labeHydrogenCyanide
			// 
			this.labeHydrogenCyanide.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labeHydrogenCyanide.AutoSize = true;
			this.labeHydrogenCyanide.Location = new System.Drawing.Point(3, 124);
			this.labeHydrogenCyanide.Name = "labeHydrogenCyanide";
			this.labeHydrogenCyanide.Size = new System.Drawing.Size(94, 13);
			this.labeHydrogenCyanide.TabIndex = 15;
			this.labeHydrogenCyanide.Text = "Hydrogen Cyanide";
			// 
			// buttonReadMethane
			// 
			this.buttonReadMethane.Location = new System.Drawing.Point(103, 3);
			this.buttonReadMethane.Name = "buttonReadMethane";
			this.buttonReadMethane.Size = new System.Drawing.Size(75, 23);
			this.buttonReadMethane.TabIndex = 2;
			this.buttonReadMethane.Text = "Read";
			this.buttonReadMethane.UseVisualStyleBackColor = true;
			this.buttonReadMethane.Click += new System.EventHandler(this.ButtonReadMethane_Click);
			// 
			// buttonReadOxygen
			// 
			this.buttonReadOxygen.Location = new System.Drawing.Point(103, 32);
			this.buttonReadOxygen.Name = "buttonReadOxygen";
			this.buttonReadOxygen.Size = new System.Drawing.Size(75, 23);
			this.buttonReadOxygen.TabIndex = 17;
			this.buttonReadOxygen.Text = "Read";
			this.buttonReadOxygen.UseVisualStyleBackColor = true;
			this.buttonReadOxygen.Click += new System.EventHandler(this.ButtonReadOxygen_Click);
			// 
			// buttonReadCarbonMonoxide
			// 
			this.buttonReadCarbonMonoxide.Location = new System.Drawing.Point(103, 61);
			this.buttonReadCarbonMonoxide.Name = "buttonReadCarbonMonoxide";
			this.buttonReadCarbonMonoxide.Size = new System.Drawing.Size(75, 23);
			this.buttonReadCarbonMonoxide.TabIndex = 18;
			this.buttonReadCarbonMonoxide.Text = "Read";
			this.buttonReadCarbonMonoxide.UseVisualStyleBackColor = true;
			this.buttonReadCarbonMonoxide.Click += new System.EventHandler(this.ButtonReadCarbonMonoxide_Click);
			// 
			// buttonReadHydrogenSulfide
			// 
			this.buttonReadHydrogenSulfide.Location = new System.Drawing.Point(103, 90);
			this.buttonReadHydrogenSulfide.Name = "buttonReadHydrogenSulfide";
			this.buttonReadHydrogenSulfide.Size = new System.Drawing.Size(75, 23);
			this.buttonReadHydrogenSulfide.TabIndex = 19;
			this.buttonReadHydrogenSulfide.Text = "Read";
			this.buttonReadHydrogenSulfide.UseVisualStyleBackColor = true;
			this.buttonReadHydrogenSulfide.Click += new System.EventHandler(this.ButtonReadHydrogenSulfide_Click);
			// 
			// buttonReadHydrogenCyanide
			// 
			this.buttonReadHydrogenCyanide.Location = new System.Drawing.Point(103, 119);
			this.buttonReadHydrogenCyanide.Name = "buttonReadHydrogenCyanide";
			this.buttonReadHydrogenCyanide.Size = new System.Drawing.Size(75, 23);
			this.buttonReadHydrogenCyanide.TabIndex = 10;
			this.buttonReadHydrogenCyanide.Text = "Read";
			this.buttonReadHydrogenCyanide.UseVisualStyleBackColor = true;
			this.buttonReadHydrogenCyanide.Click += new System.EventHandler(this.ButtonReadHydrogenCyanide_Click);
			// 
			// textBoxOxygen
			// 
			this.textBoxOxygen.Location = new System.Drawing.Point(184, 32);
			this.textBoxOxygen.Name = "textBoxOxygen";
			this.textBoxOxygen.ReadOnly = true;
			this.textBoxOxygen.Size = new System.Drawing.Size(100, 20);
			this.textBoxOxygen.TabIndex = 3;
			// 
			// textBoxMethane
			// 
			this.textBoxMethane.Location = new System.Drawing.Point(184, 3);
			this.textBoxMethane.Name = "textBoxMethane";
			this.textBoxMethane.ReadOnly = true;
			this.textBoxMethane.Size = new System.Drawing.Size(100, 20);
			this.textBoxMethane.TabIndex = 5;
			// 
			// textBoxCarbonMonoxide
			// 
			this.textBoxCarbonMonoxide.Location = new System.Drawing.Point(184, 61);
			this.textBoxCarbonMonoxide.Name = "textBoxCarbonMonoxide";
			this.textBoxCarbonMonoxide.ReadOnly = true;
			this.textBoxCarbonMonoxide.Size = new System.Drawing.Size(100, 20);
			this.textBoxCarbonMonoxide.TabIndex = 7;
			// 
			// textBoxHydrogenSulfide
			// 
			this.textBoxHydrogenSulfide.Location = new System.Drawing.Point(184, 90);
			this.textBoxHydrogenSulfide.Name = "textBoxHydrogenSulfide";
			this.textBoxHydrogenSulfide.ReadOnly = true;
			this.textBoxHydrogenSulfide.Size = new System.Drawing.Size(100, 20);
			this.textBoxHydrogenSulfide.TabIndex = 20;
			// 
			// textBoxHydrogenCyanide
			// 
			this.textBoxHydrogenCyanide.Location = new System.Drawing.Point(184, 119);
			this.textBoxHydrogenCyanide.Name = "textBoxHydrogenCyanide";
			this.textBoxHydrogenCyanide.ReadOnly = true;
			this.textBoxHydrogenCyanide.Size = new System.Drawing.Size(100, 20);
			this.textBoxHydrogenCyanide.TabIndex = 21;
			// 
			// FormG2GLT
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 291);
			this.Controls.Add(this.groupBoxCommands);
			this.Controls.Add(this.groupBoxSerialPort);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Name = "FormG2GLT";
			this.Text = "G2-GLT Interface";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormG2GLT_FormClosed);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.groupBoxSerialPort.ResumeLayout(false);
			this.groupBoxSerialPort.PerformLayout();
			this.groupBoxCommands.ResumeLayout(false);
			this.groupBoxCommands.PerformLayout();
			this.tableLayoutPanelCommands.ResumeLayout(false);
			this.tableLayoutPanelCommands.PerformLayout();
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
		private System.Windows.Forms.GroupBox groupBoxCommands;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCommands;
		private System.Windows.Forms.Label labelMethane;
		private System.Windows.Forms.Label labelOxygen;
		private System.Windows.Forms.Label labelCarbonMonoxide;
		private System.Windows.Forms.Label labelHydrogenSulfide;
		private System.Windows.Forms.Label labeHydrogenCyanide;
		private System.Windows.Forms.Button buttonReadMethane;
		private System.Windows.Forms.Button buttonReadOxygen;
		private System.Windows.Forms.Button buttonReadCarbonMonoxide;
		private System.Windows.Forms.Button buttonReadHydrogenSulfide;
		private System.Windows.Forms.Button buttonReadHydrogenCyanide;
		private System.Windows.Forms.TextBox textBoxOxygen;
		private System.Windows.Forms.TextBox textBoxMethane;
		private System.Windows.Forms.TextBox textBoxCarbonMonoxide;
		private System.Windows.Forms.TextBox textBoxHydrogenSulfide;
		private System.Windows.Forms.TextBox textBoxHydrogenCyanide;
	}
}

