
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.wikiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.groupBoxBarcode = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.textBoxBarcode = new System.Windows.Forms.TextBox();
			this.tableLayoutPanelStatus = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.labelTimestamp = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.labelUnitTimestamp = new System.Windows.Forms.Label();
			this.labelUnitLatitude = new System.Windows.Forms.Label();
			this.labelUnitLongitude = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.tableLayoutPanelTestSetupButtons = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanelStartStop = new System.Windows.Forms.TableLayoutPanel();
			this.buttonRead = new System.Windows.Forms.Button();
			this.buttonWrite = new System.Windows.Forms.Button();
			this.groupBoxStatus = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanelVariables = new System.Windows.Forms.TableLayoutPanel();
			this.labelDateProgrammed = new System.Windows.Forms.Label();
			this.labelSerialNumber = new System.Windows.Forms.Label();
			this.labelSensorType = new System.Windows.Forms.Label();
			this.textBoxSerialNumber = new System.Windows.Forms.TextBox();
			this.textBoxSensorType = new System.Windows.Forms.TextBox();
			this.labelSensorDate = new System.Windows.Forms.Label();
			this.textBoxSensorDateCode = new System.Windows.Forms.TextBox();
			this.textBoxDateProgrammed = new System.Windows.Forms.TextBox();
			this.menuStrip1.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.groupBoxBarcode.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanelTestSetupButtons.SuspendLayout();
			this.tableLayoutPanelStartStop.SuspendLayout();
			this.groupBoxStatus.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tableLayoutPanelVariables.SuspendLayout();
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
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
			this.menuStrip1.Size = new System.Drawing.Size(285, 24);
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
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wikiToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// wikiToolStripMenuItem
			// 
			this.wikiToolStripMenuItem.Name = "wikiToolStripMenuItem";
			this.wikiToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.wikiToolStripMenuItem.Text = "&Wiki";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.aboutToolStripMenuItem.Text = "&About";
			// 
			// statusStrip
			// 
			this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabel});
			this.statusStrip.Location = new System.Drawing.Point(0, 283);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
			this.statusStrip.Size = new System.Drawing.Size(285, 32);
			this.statusStrip.TabIndex = 4;
			this.statusStrip.Text = "statusStrip1";
			// 
			// toolStripProgressBar
			// 
			this.toolStripProgressBar.Name = "toolStripProgressBar";
			this.toolStripProgressBar.Size = new System.Drawing.Size(117, 26);
			// 
			// toolStripStatusLabel
			// 
			this.toolStripStatusLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.toolStripStatusLabel.Name = "toolStripStatusLabel";
			this.toolStripStatusLabel.Size = new System.Drawing.Size(62, 27);
			this.toolStripStatusLabel.Text = "Ready...";
			// 
			// groupBoxBarcode
			// 
			this.groupBoxBarcode.AutoSize = true;
			this.groupBoxBarcode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxBarcode.Controls.Add(this.tableLayoutPanel2);
			this.groupBoxBarcode.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBoxBarcode.Location = new System.Drawing.Point(0, 24);
			this.groupBoxBarcode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBoxBarcode.Name = "groupBoxBarcode";
			this.groupBoxBarcode.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBoxBarcode.Size = new System.Drawing.Size(285, 51);
			this.groupBoxBarcode.TabIndex = 0;
			this.groupBoxBarcode.TabStop = false;
			this.groupBoxBarcode.Text = "Barcode";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel2.Controls.Add(this.textBoxBarcode, 0, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 19);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.Size = new System.Drawing.Size(277, 29);
			this.tableLayoutPanel2.TabIndex = 1;
			// 
			// textBoxBarcode
			// 
			this.textBoxBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxBarcode.Location = new System.Drawing.Point(4, 3);
			this.textBoxBarcode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.textBoxBarcode.Name = "textBoxBarcode";
			this.textBoxBarcode.Size = new System.Drawing.Size(269, 23);
			this.textBoxBarcode.TabIndex = 5;
			// 
			// tableLayoutPanelStatus
			// 
			this.tableLayoutPanelStatus.ColumnCount = 1;
			this.tableLayoutPanelStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelStatus.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelStatus.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanelStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.tableLayoutPanelStatus.Name = "tableLayoutPanelStatus";
			this.tableLayoutPanelStatus.RowCount = 1;
			this.tableLayoutPanelStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanelStatus.Size = new System.Drawing.Size(200, 100);
			this.tableLayoutPanelStatus.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.textBox1, 3, 3);
			this.tableLayoutPanel1.Controls.Add(this.textBox2, 3, 2);
			this.tableLayoutPanel1.Controls.Add(this.textBox3, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelTimestamp, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.textBox4, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.textBox5, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.textBox6, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.labelUnitTimestamp, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelUnitLatitude, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelUnitLongitude, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.textBox7, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.textBox8, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.textBox9, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.textBox10, 3, 4);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 3);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(192, 145);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.textBox1.Location = new System.Drawing.Point(250, 90);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(36, 23);
			this.textBox1.TabIndex = 20;
			this.textBox1.TabStop = false;
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBox2
			// 
			this.textBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.textBox2.Location = new System.Drawing.Point(250, 61);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(36, 23);
			this.textBox2.TabIndex = 19;
			this.textBox2.TabStop = false;
			this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBox3
			// 
			this.textBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.textBox3.Location = new System.Drawing.Point(250, 32);
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(36, 23);
			this.textBox3.TabIndex = 18;
			this.textBox3.TabStop = false;
			this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// labelTimestamp
			// 
			this.labelTimestamp.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelTimestamp.AutoSize = true;
			this.labelTimestamp.Location = new System.Drawing.Point(4, 7);
			this.labelTimestamp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelTimestamp.Name = "labelTimestamp";
			this.labelTimestamp.Size = new System.Drawing.Size(66, 15);
			this.labelTimestamp.TabIndex = 0;
			this.labelTimestamp.Text = "Timestamp";
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 36);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = "Latitude";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(78, 3);
			this.textBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.textBox4.Name = "textBox4";
			this.textBox4.ReadOnly = true;
			this.textBox4.Size = new System.Drawing.Size(116, 23);
			this.textBox4.TabIndex = 2;
			this.textBox4.TabStop = false;
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(78, 32);
			this.textBox5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.textBox5.Name = "textBox5";
			this.textBox5.ReadOnly = true;
			this.textBox5.Size = new System.Drawing.Size(116, 23);
			this.textBox5.TabIndex = 3;
			this.textBox5.TabStop = false;
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(4, 65);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(61, 15);
			this.label2.TabIndex = 4;
			this.label2.Text = "Longitude";
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(78, 61);
			this.textBox6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.textBox6.Name = "textBox6";
			this.textBox6.ReadOnly = true;
			this.textBox6.Size = new System.Drawing.Size(116, 23);
			this.textBox6.TabIndex = 5;
			this.textBox6.TabStop = false;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(4, 94);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 15);
			this.label3.TabIndex = 6;
			this.label3.Text = "Fix Type";
			// 
			// labelUnitTimestamp
			// 
			this.labelUnitTimestamp.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelUnitTimestamp.Location = new System.Drawing.Point(202, 7);
			this.labelUnitTimestamp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelUnitTimestamp.Name = "labelUnitTimestamp";
			this.labelUnitTimestamp.Size = new System.Drawing.Size(41, 15);
			this.labelUnitTimestamp.TabIndex = 0;
			this.labelUnitTimestamp.Text = "UTC Time";
			// 
			// labelUnitLatitude
			// 
			this.labelUnitLatitude.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelUnitLatitude.AutoSize = true;
			this.labelUnitLatitude.Location = new System.Drawing.Point(202, 36);
			this.labelUnitLatitude.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelUnitLatitude.Name = "labelUnitLatitude";
			this.labelUnitLatitude.Size = new System.Drawing.Size(32, 15);
			this.labelUnitLatitude.TabIndex = 11;
			this.labelUnitLatitude.Text = "°N/S";
			// 
			// labelUnitLongitude
			// 
			this.labelUnitLongitude.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelUnitLongitude.AutoSize = true;
			this.labelUnitLongitude.Location = new System.Drawing.Point(202, 65);
			this.labelUnitLongitude.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelUnitLongitude.Name = "labelUnitLongitude";
			this.labelUnitLongitude.Size = new System.Drawing.Size(34, 15);
			this.labelUnitLongitude.TabIndex = 12;
			this.labelUnitLongitude.Text = "°E/W";
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(4, 123);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 15);
			this.label4.TabIndex = 15;
			this.label4.Text = "Satellites";
			// 
			// textBox7
			// 
			this.textBox7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.textBox7.Location = new System.Drawing.Point(250, 3);
			this.textBox7.Name = "textBox7";
			this.textBox7.ReadOnly = true;
			this.textBox7.Size = new System.Drawing.Size(36, 23);
			this.textBox7.TabIndex = 17;
			this.textBox7.TabStop = false;
			this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(78, 90);
			this.textBox8.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.textBox8.Name = "textBox8";
			this.textBox8.ReadOnly = true;
			this.textBox8.Size = new System.Drawing.Size(116, 23);
			this.textBox8.TabIndex = 7;
			this.textBox8.TabStop = false;
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(78, 119);
			this.textBox9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.textBox9.Name = "textBox9";
			this.textBox9.ReadOnly = true;
			this.textBox9.Size = new System.Drawing.Size(116, 23);
			this.textBox9.TabIndex = 22;
			this.textBox9.TabStop = false;
			// 
			// textBox10
			// 
			this.textBox10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.textBox10.Location = new System.Drawing.Point(250, 119);
			this.textBox10.Name = "textBox10";
			this.textBox10.ReadOnly = true;
			this.textBox10.Size = new System.Drawing.Size(36, 23);
			this.textBox10.TabIndex = 23;
			this.textBox10.TabStop = false;
			this.textBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tableLayoutPanelTestSetupButtons
			// 
			this.tableLayoutPanelTestSetupButtons.AutoSize = true;
			this.tableLayoutPanelTestSetupButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelTestSetupButtons.ColumnCount = 1;
			this.tableLayoutPanelTestSetupButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelTestSetupButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanelTestSetupButtons.Controls.Add(this.tableLayoutPanelStartStop, 0, 0);
			this.tableLayoutPanelTestSetupButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tableLayoutPanelTestSetupButtons.Location = new System.Drawing.Point(0, 244);
			this.tableLayoutPanelTestSetupButtons.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.tableLayoutPanelTestSetupButtons.Name = "tableLayoutPanelTestSetupButtons";
			this.tableLayoutPanelTestSetupButtons.RowCount = 1;
			this.tableLayoutPanelTestSetupButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelTestSetupButtons.Size = new System.Drawing.Size(285, 39);
			this.tableLayoutPanelTestSetupButtons.TabIndex = 17;
			// 
			// tableLayoutPanelStartStop
			// 
			this.tableLayoutPanelStartStop.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.tableLayoutPanelStartStop.AutoSize = true;
			this.tableLayoutPanelStartStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelStartStop.ColumnCount = 2;
			this.tableLayoutPanelStartStop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelStartStop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelStartStop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
			this.tableLayoutPanelStartStop.Controls.Add(this.buttonRead, 0, 0);
			this.tableLayoutPanelStartStop.Controls.Add(this.buttonWrite, 1, 0);
			this.tableLayoutPanelStartStop.Location = new System.Drawing.Point(46, 3);
			this.tableLayoutPanelStartStop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.tableLayoutPanelStartStop.Name = "tableLayoutPanelStartStop";
			this.tableLayoutPanelStartStop.RowCount = 1;
			this.tableLayoutPanelStartStop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelStartStop.Size = new System.Drawing.Size(192, 33);
			this.tableLayoutPanelStartStop.TabIndex = 17;
			// 
			// buttonRead
			// 
			this.buttonRead.Location = new System.Drawing.Point(4, 3);
			this.buttonRead.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.buttonRead.Name = "buttonRead";
			this.buttonRead.Size = new System.Drawing.Size(88, 27);
			this.buttonRead.TabIndex = 3;
			this.buttonRead.Text = "Read";
			this.buttonRead.UseVisualStyleBackColor = true;
			this.buttonRead.Click += new System.EventHandler(this.ButtonRead_Click);
			// 
			// buttonWrite
			// 
			this.buttonWrite.Location = new System.Drawing.Point(100, 3);
			this.buttonWrite.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.buttonWrite.Name = "buttonWrite";
			this.buttonWrite.Size = new System.Drawing.Size(88, 27);
			this.buttonWrite.TabIndex = 4;
			this.buttonWrite.Text = "Write";
			this.buttonWrite.UseVisualStyleBackColor = true;
			this.buttonWrite.Click += new System.EventHandler(this.ButtonWrite_Click);
			// 
			// groupBoxStatus
			// 
			this.groupBoxStatus.AutoSize = true;
			this.groupBoxStatus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxStatus.Controls.Add(this.tableLayoutPanel3);
			this.groupBoxStatus.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxStatus.Location = new System.Drawing.Point(0, 75);
			this.groupBoxStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBoxStatus.Name = "groupBoxStatus";
			this.groupBoxStatus.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBoxStatus.Size = new System.Drawing.Size(285, 169);
			this.groupBoxStatus.TabIndex = 18;
			this.groupBoxStatus.TabStop = false;
			this.groupBoxStatus.Text = "Status";
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 1;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanelVariables, 0, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 19);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 172F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(277, 147);
			this.tableLayoutPanel3.TabIndex = 1;
			// 
			// tableLayoutPanelVariables
			// 
			this.tableLayoutPanelVariables.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.tableLayoutPanelVariables.AutoSize = true;
			this.tableLayoutPanelVariables.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelVariables.ColumnCount = 2;
			this.tableLayoutPanelVariables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelVariables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelVariables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanelVariables.Controls.Add(this.labelDateProgrammed, 0, 3);
			this.tableLayoutPanelVariables.Controls.Add(this.labelSerialNumber, 0, 0);
			this.tableLayoutPanelVariables.Controls.Add(this.labelSensorType, 0, 1);
			this.tableLayoutPanelVariables.Controls.Add(this.textBoxSerialNumber, 1, 0);
			this.tableLayoutPanelVariables.Controls.Add(this.textBoxSensorType, 1, 1);
			this.tableLayoutPanelVariables.Controls.Add(this.labelSensorDate, 0, 2);
			this.tableLayoutPanelVariables.Controls.Add(this.textBoxSensorDateCode, 1, 2);
			this.tableLayoutPanelVariables.Controls.Add(this.textBoxDateProgrammed, 1, 3);
			this.tableLayoutPanelVariables.Location = new System.Drawing.Point(20, 15);
			this.tableLayoutPanelVariables.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.tableLayoutPanelVariables.Name = "tableLayoutPanelVariables";
			this.tableLayoutPanelVariables.RowCount = 4;
			this.tableLayoutPanelVariables.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelVariables.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelVariables.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelVariables.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelVariables.Size = new System.Drawing.Size(236, 116);
			this.tableLayoutPanelVariables.TabIndex = 2;
			// 
			// labelDateProgrammed
			// 
			this.labelDateProgrammed.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelDateProgrammed.AutoSize = true;
			this.labelDateProgrammed.Location = new System.Drawing.Point(4, 94);
			this.labelDateProgrammed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelDateProgrammed.Name = "labelDateProgrammed";
			this.labelDateProgrammed.Size = new System.Drawing.Size(104, 15);
			this.labelDateProgrammed.TabIndex = 20;
			this.labelDateProgrammed.Text = "Date Programmed";
			// 
			// labelSerialNumber
			// 
			this.labelSerialNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelSerialNumber.AutoSize = true;
			this.labelSerialNumber.Location = new System.Drawing.Point(4, 7);
			this.labelSerialNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelSerialNumber.Name = "labelSerialNumber";
			this.labelSerialNumber.Size = new System.Drawing.Size(82, 15);
			this.labelSerialNumber.TabIndex = 0;
			this.labelSerialNumber.Text = "Serial Number";
			// 
			// labelSensorType
			// 
			this.labelSensorType.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelSensorType.AutoSize = true;
			this.labelSensorType.Location = new System.Drawing.Point(4, 36);
			this.labelSensorType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelSensorType.Name = "labelSensorType";
			this.labelSensorType.Size = new System.Drawing.Size(69, 15);
			this.labelSensorType.TabIndex = 1;
			this.labelSensorType.Text = "Sensor Type";
			// 
			// textBoxSerialNumber
			// 
			this.textBoxSerialNumber.Location = new System.Drawing.Point(116, 3);
			this.textBoxSerialNumber.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.textBoxSerialNumber.Name = "textBoxSerialNumber";
			this.textBoxSerialNumber.ReadOnly = true;
			this.textBoxSerialNumber.Size = new System.Drawing.Size(116, 23);
			this.textBoxSerialNumber.TabIndex = 2;
			this.textBoxSerialNumber.TabStop = false;
			// 
			// textBoxSensorType
			// 
			this.textBoxSensorType.Location = new System.Drawing.Point(116, 32);
			this.textBoxSensorType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.textBoxSensorType.Name = "textBoxSensorType";
			this.textBoxSensorType.ReadOnly = true;
			this.textBoxSensorType.Size = new System.Drawing.Size(116, 23);
			this.textBoxSensorType.TabIndex = 3;
			this.textBoxSensorType.TabStop = false;
			// 
			// labelSensorDate
			// 
			this.labelSensorDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelSensorDate.AutoSize = true;
			this.labelSensorDate.Location = new System.Drawing.Point(4, 65);
			this.labelSensorDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelSensorDate.Name = "labelSensorDate";
			this.labelSensorDate.Size = new System.Drawing.Size(100, 15);
			this.labelSensorDate.TabIndex = 4;
			this.labelSensorDate.Text = "Sensor Date Code";
			// 
			// textBoxSensorDateCode
			// 
			this.textBoxSensorDateCode.Location = new System.Drawing.Point(116, 61);
			this.textBoxSensorDateCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.textBoxSensorDateCode.Name = "textBoxSensorDateCode";
			this.textBoxSensorDateCode.ReadOnly = true;
			this.textBoxSensorDateCode.Size = new System.Drawing.Size(116, 23);
			this.textBoxSensorDateCode.TabIndex = 5;
			this.textBoxSensorDateCode.TabStop = false;
			// 
			// textBoxDateProgrammed
			// 
			this.textBoxDateProgrammed.Location = new System.Drawing.Point(116, 90);
			this.textBoxDateProgrammed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.textBoxDateProgrammed.Name = "textBoxDateProgrammed";
			this.textBoxDateProgrammed.ReadOnly = true;
			this.textBoxDateProgrammed.Size = new System.Drawing.Size(116, 23);
			this.textBoxDateProgrammed.TabIndex = 21;
			this.textBoxDateProgrammed.TabStop = false;
			// 
			// FormProgrammer
			// 
			this.AcceptButton = this.buttonWrite;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(285, 315);
			this.Controls.Add(this.groupBoxStatus);
			this.Controls.Add(this.tableLayoutPanelTestSetupButtons);
			this.Controls.Add(this.groupBoxBarcode);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.Name = "FormProgrammer";
			this.Text = "Smart Sensor";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormProgrammer_FormClosed);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.groupBoxBarcode.ResumeLayout(false);
			this.groupBoxBarcode.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanelTestSetupButtons.ResumeLayout(false);
			this.tableLayoutPanelTestSetupButtons.PerformLayout();
			this.tableLayoutPanelStartStop.ResumeLayout(false);
			this.groupBoxStatus.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.tableLayoutPanelVariables.ResumeLayout(false);
			this.tableLayoutPanelVariables.PerformLayout();
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
		private System.Windows.Forms.GroupBox groupBoxBarcode;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TextBox textBoxBarcode;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelStatus;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label labelTimestamp;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label labelUnitTimestamp;
		private System.Windows.Forms.Label labelUnitLatitude;
		private System.Windows.Forms.Label labelUnitLongitude;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTestSetupButtons;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelStartStop;
		private System.Windows.Forms.Button buttonRead;
		private System.Windows.Forms.Button buttonWrite;
		private System.Windows.Forms.GroupBox groupBoxStatus;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelVariables;
		private System.Windows.Forms.Label labelSerialNumber;
		private System.Windows.Forms.Label labelSensorType;
		private System.Windows.Forms.TextBox textBoxSerialNumber;
		private System.Windows.Forms.TextBox textBoxSensorType;
		private System.Windows.Forms.Label labelSensorDate;
		private System.Windows.Forms.TextBox textBoxSensorDateCode;
		private System.Windows.Forms.Label labelDateProgrammed;
		private System.Windows.Forms.TextBox textBoxDateProgrammed;
	}
}

