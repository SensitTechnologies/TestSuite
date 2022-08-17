
namespace Sensit.App.Programmer
{
	partial class FormProgrammer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProgrammer));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wikiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBoxSerialPort = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelSerialPort = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxSerialPort = new System.Windows.Forms.ComboBox();
            this.buttonPortRefresh = new System.Windows.Forms.Button();
            this.groupBoxBarcode = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxBarcode = new System.Windows.Forms.TextBox();
            this.buttonProgram = new System.Windows.Forms.Button();
            this.groupBoxStatus = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelGasConcentration = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSensor4 = new System.Windows.Forms.Button();
            this.buttonSensor1 = new System.Windows.Forms.Button();
            this.buttonSensor2 = new System.Windows.Forms.Button();
            this.buttonSensor3 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.groupBoxSerialPort.SuspendLayout();
            this.tableLayoutPanelSerialPort.SuspendLayout();
            this.groupBoxBarcode.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBoxStatus.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanelGasConcentration.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(512, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 26);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wikiToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // wikiToolStripMenuItem
            // 
            this.wikiToolStripMenuItem.Name = "wikiToolStripMenuItem";
            this.wikiToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.wikiToolStripMenuItem.Text = "&Wiki";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 668);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 18, 0);
            this.statusStrip.Size = new System.Drawing.Size(512, 41);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(134, 33);
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(77, 35);
            this.toolStripStatusLabel.Text = "Ready...";
            // 
            // groupBoxSerialPort
            // 
            this.groupBoxSerialPort.AutoSize = true;
            this.groupBoxSerialPort.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxSerialPort.Controls.Add(this.tableLayoutPanelSerialPort);
            this.groupBoxSerialPort.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxSerialPort.Location = new System.Drawing.Point(0, 30);
            this.groupBoxSerialPort.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBoxSerialPort.Name = "groupBoxSerialPort";
            this.groupBoxSerialPort.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBoxSerialPort.Size = new System.Drawing.Size(512, 72);
            this.groupBoxSerialPort.TabIndex = 9;
            this.groupBoxSerialPort.TabStop = false;
            this.groupBoxSerialPort.Text = "Serial Port";
            // 
            // tableLayoutPanelSerialPort
            // 
            this.tableLayoutPanelSerialPort.AutoSize = true;
            this.tableLayoutPanelSerialPort.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelSerialPort.ColumnCount = 4;
            this.tableLayoutPanelSerialPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSerialPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSerialPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSerialPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSerialPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanelSerialPort.Controls.Add(this.comboBoxSerialPort, 0, 0);
            this.tableLayoutPanelSerialPort.Controls.Add(this.buttonPortRefresh, 1, 0);
            this.tableLayoutPanelSerialPort.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelSerialPort.Location = new System.Drawing.Point(5, 24);
            this.tableLayoutPanelSerialPort.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tableLayoutPanelSerialPort.Name = "tableLayoutPanelSerialPort";
            this.tableLayoutPanelSerialPort.RowCount = 1;
            this.tableLayoutPanelSerialPort.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSerialPort.Size = new System.Drawing.Size(502, 44);
            this.tableLayoutPanelSerialPort.TabIndex = 14;
            // 
            // comboBoxSerialPort
            // 
            this.comboBoxSerialPort.AllowDrop = true;
            this.comboBoxSerialPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxSerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSerialPort.FormattingEnabled = true;
            this.comboBoxSerialPort.Location = new System.Drawing.Point(5, 4);
            this.comboBoxSerialPort.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.comboBoxSerialPort.Name = "comboBoxSerialPort";
            this.comboBoxSerialPort.Size = new System.Drawing.Size(444, 28);
            this.comboBoxSerialPort.TabIndex = 1;
            this.comboBoxSerialPort.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSerialPort_SelectedIndexChanged);
            // 
            // buttonPortRefresh
            // 
            this.buttonPortRefresh.Image = ((System.Drawing.Image)(resources.GetObject("buttonPortRefresh.Image")));
            this.buttonPortRefresh.Location = new System.Drawing.Point(459, 4);
            this.buttonPortRefresh.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonPortRefresh.Name = "buttonPortRefresh";
            this.buttonPortRefresh.Size = new System.Drawing.Size(38, 36);
            this.buttonPortRefresh.TabIndex = 2;
            this.buttonPortRefresh.UseVisualStyleBackColor = true;
            this.buttonPortRefresh.Click += new System.EventHandler(this.ButtonPortRefresh_Click);
            // 
            // groupBoxBarcode
            // 
            this.groupBoxBarcode.AutoSize = true;
            this.groupBoxBarcode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxBarcode.Controls.Add(this.tableLayoutPanel2);
            this.groupBoxBarcode.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxBarcode.Location = new System.Drawing.Point(0, 102);
            this.groupBoxBarcode.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBoxBarcode.Name = "groupBoxBarcode";
            this.groupBoxBarcode.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBoxBarcode.Size = new System.Drawing.Size(512, 72);
            this.groupBoxBarcode.TabIndex = 0;
            this.groupBoxBarcode.TabStop = false;
            this.groupBoxBarcode.Text = "Barcode";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.textBoxBarcode, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonProgram, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 24);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(502, 44);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // textBoxBarcode
            // 
            this.textBoxBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxBarcode.Location = new System.Drawing.Point(5, 4);
            this.textBoxBarcode.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBoxBarcode.Name = "textBoxBarcode";
            this.textBoxBarcode.Size = new System.Drawing.Size(381, 27);
            this.textBoxBarcode.TabIndex = 5;
            // 
            // buttonProgram
            // 
            this.buttonProgram.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonProgram.Location = new System.Drawing.Point(396, 4);
            this.buttonProgram.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonProgram.Name = "buttonProgram";
            this.buttonProgram.Size = new System.Drawing.Size(101, 36);
            this.buttonProgram.TabIndex = 6;
            this.buttonProgram.Text = "Program";
            this.buttonProgram.UseVisualStyleBackColor = true;
            this.buttonProgram.Click += new System.EventHandler(this.ButtonProgram_Click);
            // 
            // groupBoxStatus
            // 
            this.groupBoxStatus.AutoSize = true;
            this.groupBoxStatus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxStatus.Controls.Add(this.tableLayoutPanel1);
            this.groupBoxStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxStatus.Location = new System.Drawing.Point(0, 174);
            this.groupBoxStatus.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBoxStatus.Name = "groupBoxStatus";
            this.groupBoxStatus.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBoxStatus.Size = new System.Drawing.Size(512, 494);
            this.groupBoxStatus.TabIndex = 12;
            this.groupBoxStatus.TabStop = false;
            this.groupBoxStatus.Text = "Status";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelGasConcentration, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 24);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 457F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(502, 466);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanelGasConcentration
            // 
            this.tableLayoutPanelGasConcentration.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanelGasConcentration.AutoSize = true;
            this.tableLayoutPanelGasConcentration.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelGasConcentration.ColumnCount = 2;
            this.tableLayoutPanelGasConcentration.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelGasConcentration.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelGasConcentration.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanelGasConcentration.Controls.Add(this.buttonSensor4, 0, 1);
            this.tableLayoutPanelGasConcentration.Controls.Add(this.buttonSensor1, 1, 1);
            this.tableLayoutPanelGasConcentration.Controls.Add(this.buttonSensor2, 1, 0);
            this.tableLayoutPanelGasConcentration.Controls.Add(this.buttonSensor3, 0, 0);
            this.tableLayoutPanelGasConcentration.Location = new System.Drawing.Point(107, 72);
            this.tableLayoutPanelGasConcentration.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tableLayoutPanelGasConcentration.Name = "tableLayoutPanelGasConcentration";
            this.tableLayoutPanelGasConcentration.RowCount = 2;
            this.tableLayoutPanelGasConcentration.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGasConcentration.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGasConcentration.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanelGasConcentration.Size = new System.Drawing.Size(288, 322);
            this.tableLayoutPanelGasConcentration.TabIndex = 1;
            // 
            // buttonSensor4
            // 
            this.buttonSensor4.Location = new System.Drawing.Point(5, 165);
            this.buttonSensor4.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonSensor4.Name = "buttonSensor4";
            this.buttonSensor4.Size = new System.Drawing.Size(134, 153);
            this.buttonSensor4.TabIndex = 10;
            this.buttonSensor4.Text = "4";
            this.buttonSensor4.UseVisualStyleBackColor = true;
            this.buttonSensor4.Click += new System.EventHandler(this.ButtonSensor4_Click);
            // 
            // buttonSensor1
            // 
            this.buttonSensor1.Location = new System.Drawing.Point(149, 165);
            this.buttonSensor1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonSensor1.Name = "buttonSensor1";
            this.buttonSensor1.Size = new System.Drawing.Size(134, 153);
            this.buttonSensor1.TabIndex = 7;
            this.buttonSensor1.Text = "1";
            this.buttonSensor1.UseVisualStyleBackColor = true;
            this.buttonSensor1.Click += new System.EventHandler(this.ButtonSensor1_Click);
            // 
            // buttonSensor2
            // 
            this.buttonSensor2.Location = new System.Drawing.Point(149, 4);
            this.buttonSensor2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonSensor2.Name = "buttonSensor2";
            this.buttonSensor2.Size = new System.Drawing.Size(134, 153);
            this.buttonSensor2.TabIndex = 8;
            this.buttonSensor2.Text = "2";
            this.buttonSensor2.UseVisualStyleBackColor = true;
            this.buttonSensor2.Click += new System.EventHandler(this.ButtonSensor2_Click);
            // 
            // buttonSensor3
            // 
            this.buttonSensor3.Location = new System.Drawing.Point(5, 4);
            this.buttonSensor3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonSensor3.Name = "buttonSensor3";
            this.buttonSensor3.Size = new System.Drawing.Size(134, 153);
            this.buttonSensor3.TabIndex = 9;
            this.buttonSensor3.Text = "3";
            this.buttonSensor3.UseVisualStyleBackColor = true;
            this.buttonSensor3.Click += new System.EventHandler(this.ButtonSensor3_Click);
            // 
            // FormProgrammer
            // 
            this.AcceptButton = this.buttonProgram;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 709);
            this.Controls.Add(this.groupBoxStatus);
            this.Controls.Add(this.groupBoxBarcode);
            this.Controls.Add(this.groupBoxSerialPort);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FormProgrammer";
            this.Text = "Smart Sensor Programmer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormProgrammer_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBoxSerialPort.ResumeLayout(false);
            this.groupBoxSerialPort.PerformLayout();
            this.tableLayoutPanelSerialPort.ResumeLayout(false);
            this.groupBoxBarcode.ResumeLayout(false);
            this.groupBoxBarcode.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBoxStatus.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanelGasConcentration.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem wikiToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
		private System.Windows.Forms.GroupBox groupBoxSerialPort;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSerialPort;
		private System.Windows.Forms.ComboBox comboBoxSerialPort;
		private System.Windows.Forms.Button buttonPortRefresh;
		private System.Windows.Forms.GroupBox groupBoxBarcode;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TextBox textBoxBarcode;
		private System.Windows.Forms.Button buttonProgram;
		private System.Windows.Forms.GroupBox groupBoxStatus;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGasConcentration;
		private System.Windows.Forms.Button buttonSensor4;
		private System.Windows.Forms.Button buttonSensor1;
		private System.Windows.Forms.Button buttonSensor2;
		private System.Windows.Forms.Button buttonSensor3;
	}
}

