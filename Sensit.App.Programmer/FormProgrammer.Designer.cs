
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
			menuStrip1 = new System.Windows.Forms.MenuStrip();
			fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			wikiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			statusStrip = new System.Windows.Forms.StatusStrip();
			toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			groupBoxBarcode = new System.Windows.Forms.GroupBox();
			tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			textBoxBarcode = new System.Windows.Forms.TextBox();
			tableLayoutPanelStatus = new System.Windows.Forms.TableLayoutPanel();
			tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			textBox1 = new System.Windows.Forms.TextBox();
			textBox2 = new System.Windows.Forms.TextBox();
			textBox3 = new System.Windows.Forms.TextBox();
			labelTimestamp = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			textBox4 = new System.Windows.Forms.TextBox();
			textBox5 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			textBox6 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			labelUnitTimestamp = new System.Windows.Forms.Label();
			labelUnitLatitude = new System.Windows.Forms.Label();
			labelUnitLongitude = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			textBox7 = new System.Windows.Forms.TextBox();
			textBox8 = new System.Windows.Forms.TextBox();
			textBox9 = new System.Windows.Forms.TextBox();
			textBox10 = new System.Windows.Forms.TextBox();
			tableLayoutPanelTestSetupButtons = new System.Windows.Forms.TableLayoutPanel();
			tableLayoutPanelStartStop = new System.Windows.Forms.TableLayoutPanel();
			buttonRead = new System.Windows.Forms.Button();
			buttonWrite = new System.Windows.Forms.Button();
			groupBoxStatus = new System.Windows.Forms.GroupBox();
			tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			tableLayoutPanelVariables = new System.Windows.Forms.TableLayoutPanel();
			textBoxSensorCounts = new System.Windows.Forms.TextBox();
			labelSensorCounts = new System.Windows.Forms.Label();
			labelDateProgrammed = new System.Windows.Forms.Label();
			labelSerialNumber = new System.Windows.Forms.Label();
			labelSensorType = new System.Windows.Forms.Label();
			textBoxSerialNumber = new System.Windows.Forms.TextBox();
			textBoxSensorType = new System.Windows.Forms.TextBox();
			textBoxDateProgrammed = new System.Windows.Forms.TextBox();
			menuStrip1.SuspendLayout();
			statusStrip.SuspendLayout();
			groupBoxBarcode.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			tableLayoutPanelTestSetupButtons.SuspendLayout();
			tableLayoutPanelStartStop.SuspendLayout();
			groupBoxStatus.SuspendLayout();
			tableLayoutPanel3.SuspendLayout();
			tableLayoutPanelVariables.SuspendLayout();
			SuspendLayout();
			// 
			// menuStrip1
			// 
			menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
			menuStrip1.Location = new System.Drawing.Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
			menuStrip1.Size = new System.Drawing.Size(285, 24);
			menuStrip1.TabIndex = 0;
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
			exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
			exitToolStripMenuItem.Text = "&Exit";
			exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
			// 
			// helpToolStripMenuItem
			// 
			helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { wikiToolStripMenuItem, aboutToolStripMenuItem });
			helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			helpToolStripMenuItem.Text = "&Help";
			// 
			// wikiToolStripMenuItem
			// 
			wikiToolStripMenuItem.Name = "wikiToolStripMenuItem";
			wikiToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			wikiToolStripMenuItem.Text = "&Wiki";
			// 
			// aboutToolStripMenuItem
			// 
			aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			aboutToolStripMenuItem.Text = "&About";
			// 
			// statusStrip
			// 
			statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripProgressBar, toolStripStatusLabel });
			statusStrip.Location = new System.Drawing.Point(0, 283);
			statusStrip.Name = "statusStrip";
			statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
			statusStrip.Size = new System.Drawing.Size(285, 32);
			statusStrip.TabIndex = 4;
			statusStrip.Text = "statusStrip1";
			// 
			// toolStripProgressBar
			// 
			toolStripProgressBar.Name = "toolStripProgressBar";
			toolStripProgressBar.Size = new System.Drawing.Size(117, 26);
			// 
			// toolStripStatusLabel
			// 
			toolStripStatusLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
			toolStripStatusLabel.Name = "toolStripStatusLabel";
			toolStripStatusLabel.Size = new System.Drawing.Size(62, 27);
			toolStripStatusLabel.Text = "Ready...";
			// 
			// groupBoxBarcode
			// 
			groupBoxBarcode.AutoSize = true;
			groupBoxBarcode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			groupBoxBarcode.Controls.Add(tableLayoutPanel2);
			groupBoxBarcode.Dock = System.Windows.Forms.DockStyle.Top;
			groupBoxBarcode.Location = new System.Drawing.Point(0, 24);
			groupBoxBarcode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			groupBoxBarcode.Name = "groupBoxBarcode";
			groupBoxBarcode.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			groupBoxBarcode.Size = new System.Drawing.Size(285, 51);
			groupBoxBarcode.TabIndex = 0;
			groupBoxBarcode.TabStop = false;
			groupBoxBarcode.Text = "Barcode";
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.AutoSize = true;
			tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			tableLayoutPanel2.ColumnCount = 1;
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			tableLayoutPanel2.Controls.Add(textBoxBarcode, 0, 0);
			tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
			tableLayoutPanel2.Location = new System.Drawing.Point(4, 19);
			tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 1;
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel2.Size = new System.Drawing.Size(277, 29);
			tableLayoutPanel2.TabIndex = 1;
			// 
			// textBoxBarcode
			// 
			textBoxBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
			textBoxBarcode.Location = new System.Drawing.Point(4, 3);
			textBoxBarcode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			textBoxBarcode.Name = "textBoxBarcode";
			textBoxBarcode.Size = new System.Drawing.Size(269, 23);
			textBoxBarcode.TabIndex = 5;
			// 
			// tableLayoutPanelStatus
			// 
			tableLayoutPanelStatus.ColumnCount = 1;
			tableLayoutPanelStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanelStatus.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanelStatus.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanelStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			tableLayoutPanelStatus.Name = "tableLayoutPanelStatus";
			tableLayoutPanelStatus.RowCount = 1;
			tableLayoutPanelStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			tableLayoutPanelStatus.Size = new System.Drawing.Size(200, 100);
			tableLayoutPanelStatus.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
			tableLayoutPanel1.AutoSize = true;
			tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			tableLayoutPanel1.ColumnCount = 4;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel1.Controls.Add(textBox1, 3, 3);
			tableLayoutPanel1.Controls.Add(textBox2, 3, 2);
			tableLayoutPanel1.Controls.Add(textBox3, 3, 1);
			tableLayoutPanel1.Controls.Add(labelTimestamp, 0, 0);
			tableLayoutPanel1.Controls.Add(label1, 0, 1);
			tableLayoutPanel1.Controls.Add(textBox4, 1, 0);
			tableLayoutPanel1.Controls.Add(textBox5, 1, 1);
			tableLayoutPanel1.Controls.Add(label2, 0, 2);
			tableLayoutPanel1.Controls.Add(textBox6, 1, 2);
			tableLayoutPanel1.Controls.Add(label3, 0, 3);
			tableLayoutPanel1.Controls.Add(labelUnitTimestamp, 2, 0);
			tableLayoutPanel1.Controls.Add(labelUnitLatitude, 2, 1);
			tableLayoutPanel1.Controls.Add(labelUnitLongitude, 2, 2);
			tableLayoutPanel1.Controls.Add(label4, 0, 4);
			tableLayoutPanel1.Controls.Add(textBox7, 3, 0);
			tableLayoutPanel1.Controls.Add(textBox8, 1, 3);
			tableLayoutPanel1.Controls.Add(textBox9, 1, 4);
			tableLayoutPanel1.Controls.Add(textBox10, 3, 4);
			tableLayoutPanel1.Location = new System.Drawing.Point(4, 3);
			tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 5;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.Size = new System.Drawing.Size(192, 145);
			tableLayoutPanel1.TabIndex = 2;
			// 
			// textBox1
			// 
			textBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
			textBox1.Location = new System.Drawing.Point(251, 90);
			textBox1.Name = "textBox1";
			textBox1.ReadOnly = true;
			textBox1.Size = new System.Drawing.Size(36, 23);
			textBox1.TabIndex = 20;
			textBox1.TabStop = false;
			textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBox2
			// 
			textBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
			textBox2.Location = new System.Drawing.Point(251, 61);
			textBox2.Name = "textBox2";
			textBox2.ReadOnly = true;
			textBox2.Size = new System.Drawing.Size(36, 23);
			textBox2.TabIndex = 19;
			textBox2.TabStop = false;
			textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBox3
			// 
			textBox3.Font = new System.Drawing.Font("Segoe UI", 9F);
			textBox3.Location = new System.Drawing.Point(251, 32);
			textBox3.Name = "textBox3";
			textBox3.ReadOnly = true;
			textBox3.Size = new System.Drawing.Size(36, 23);
			textBox3.TabIndex = 18;
			textBox3.TabStop = false;
			textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// labelTimestamp
			// 
			labelTimestamp.Anchor = System.Windows.Forms.AnchorStyles.Left;
			labelTimestamp.AutoSize = true;
			labelTimestamp.Location = new System.Drawing.Point(4, 7);
			labelTimestamp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelTimestamp.Name = "labelTimestamp";
			labelTimestamp.Size = new System.Drawing.Size(67, 15);
			labelTimestamp.TabIndex = 0;
			labelTimestamp.Text = "Timestamp";
			// 
			// label1
			// 
			label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(4, 36);
			label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(50, 15);
			label1.TabIndex = 1;
			label1.Text = "Latitude";
			// 
			// textBox4
			// 
			textBox4.Location = new System.Drawing.Point(79, 3);
			textBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			textBox4.Name = "textBox4";
			textBox4.ReadOnly = true;
			textBox4.Size = new System.Drawing.Size(116, 23);
			textBox4.TabIndex = 2;
			textBox4.TabStop = false;
			// 
			// textBox5
			// 
			textBox5.Location = new System.Drawing.Point(79, 32);
			textBox5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			textBox5.Name = "textBox5";
			textBox5.ReadOnly = true;
			textBox5.Size = new System.Drawing.Size(116, 23);
			textBox5.TabIndex = 3;
			textBox5.TabStop = false;
			// 
			// label2
			// 
			label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(4, 65);
			label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(61, 15);
			label2.TabIndex = 4;
			label2.Text = "Longitude";
			// 
			// textBox6
			// 
			textBox6.Location = new System.Drawing.Point(79, 61);
			textBox6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			textBox6.Name = "textBox6";
			textBox6.ReadOnly = true;
			textBox6.Size = new System.Drawing.Size(116, 23);
			textBox6.TabIndex = 5;
			textBox6.TabStop = false;
			// 
			// label3
			// 
			label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(4, 94);
			label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(49, 15);
			label3.TabIndex = 6;
			label3.Text = "Fix Type";
			// 
			// labelUnitTimestamp
			// 
			labelUnitTimestamp.Anchor = System.Windows.Forms.AnchorStyles.Left;
			labelUnitTimestamp.Location = new System.Drawing.Point(203, 7);
			labelUnitTimestamp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelUnitTimestamp.Name = "labelUnitTimestamp";
			labelUnitTimestamp.Size = new System.Drawing.Size(41, 15);
			labelUnitTimestamp.TabIndex = 0;
			labelUnitTimestamp.Text = "UTC Time";
			// 
			// labelUnitLatitude
			// 
			labelUnitLatitude.Anchor = System.Windows.Forms.AnchorStyles.Left;
			labelUnitLatitude.AutoSize = true;
			labelUnitLatitude.Location = new System.Drawing.Point(203, 36);
			labelUnitLatitude.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelUnitLatitude.Name = "labelUnitLatitude";
			labelUnitLatitude.Size = new System.Drawing.Size(32, 15);
			labelUnitLatitude.TabIndex = 11;
			labelUnitLatitude.Text = "°N/S";
			// 
			// labelUnitLongitude
			// 
			labelUnitLongitude.Anchor = System.Windows.Forms.AnchorStyles.Left;
			labelUnitLongitude.AutoSize = true;
			labelUnitLongitude.Location = new System.Drawing.Point(203, 65);
			labelUnitLongitude.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelUnitLongitude.Name = "labelUnitLongitude";
			labelUnitLongitude.Size = new System.Drawing.Size(34, 15);
			labelUnitLongitude.TabIndex = 12;
			labelUnitLongitude.Text = "°E/W";
			// 
			// label4
			// 
			label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(4, 123);
			label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(53, 15);
			label4.TabIndex = 15;
			label4.Text = "Satellites";
			// 
			// textBox7
			// 
			textBox7.Font = new System.Drawing.Font("Segoe UI", 9F);
			textBox7.Location = new System.Drawing.Point(251, 3);
			textBox7.Name = "textBox7";
			textBox7.ReadOnly = true;
			textBox7.Size = new System.Drawing.Size(36, 23);
			textBox7.TabIndex = 17;
			textBox7.TabStop = false;
			textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBox8
			// 
			textBox8.Location = new System.Drawing.Point(79, 90);
			textBox8.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			textBox8.Name = "textBox8";
			textBox8.ReadOnly = true;
			textBox8.Size = new System.Drawing.Size(116, 23);
			textBox8.TabIndex = 7;
			textBox8.TabStop = false;
			// 
			// textBox9
			// 
			textBox9.Location = new System.Drawing.Point(79, 119);
			textBox9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			textBox9.Name = "textBox9";
			textBox9.ReadOnly = true;
			textBox9.Size = new System.Drawing.Size(116, 23);
			textBox9.TabIndex = 22;
			textBox9.TabStop = false;
			// 
			// textBox10
			// 
			textBox10.Font = new System.Drawing.Font("Segoe UI", 9F);
			textBox10.Location = new System.Drawing.Point(251, 119);
			textBox10.Name = "textBox10";
			textBox10.ReadOnly = true;
			textBox10.Size = new System.Drawing.Size(36, 23);
			textBox10.TabIndex = 23;
			textBox10.TabStop = false;
			textBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tableLayoutPanelTestSetupButtons
			// 
			tableLayoutPanelTestSetupButtons.AutoSize = true;
			tableLayoutPanelTestSetupButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			tableLayoutPanelTestSetupButtons.ColumnCount = 1;
			tableLayoutPanelTestSetupButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanelTestSetupButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			tableLayoutPanelTestSetupButtons.Controls.Add(tableLayoutPanelStartStop, 0, 0);
			tableLayoutPanelTestSetupButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
			tableLayoutPanelTestSetupButtons.Location = new System.Drawing.Point(0, 244);
			tableLayoutPanelTestSetupButtons.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			tableLayoutPanelTestSetupButtons.Name = "tableLayoutPanelTestSetupButtons";
			tableLayoutPanelTestSetupButtons.RowCount = 1;
			tableLayoutPanelTestSetupButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanelTestSetupButtons.Size = new System.Drawing.Size(285, 39);
			tableLayoutPanelTestSetupButtons.TabIndex = 17;
			// 
			// tableLayoutPanelStartStop
			// 
			tableLayoutPanelStartStop.Anchor = System.Windows.Forms.AnchorStyles.None;
			tableLayoutPanelStartStop.AutoSize = true;
			tableLayoutPanelStartStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			tableLayoutPanelStartStop.ColumnCount = 2;
			tableLayoutPanelStartStop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanelStartStop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanelStartStop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
			tableLayoutPanelStartStop.Controls.Add(buttonRead, 0, 0);
			tableLayoutPanelStartStop.Controls.Add(buttonWrite, 1, 0);
			tableLayoutPanelStartStop.Location = new System.Drawing.Point(46, 3);
			tableLayoutPanelStartStop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			tableLayoutPanelStartStop.Name = "tableLayoutPanelStartStop";
			tableLayoutPanelStartStop.RowCount = 1;
			tableLayoutPanelStartStop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanelStartStop.Size = new System.Drawing.Size(192, 33);
			tableLayoutPanelStartStop.TabIndex = 17;
			// 
			// buttonRead
			// 
			buttonRead.Location = new System.Drawing.Point(4, 3);
			buttonRead.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			buttonRead.Name = "buttonRead";
			buttonRead.Size = new System.Drawing.Size(88, 27);
			buttonRead.TabIndex = 3;
			buttonRead.Text = "Read";
			buttonRead.UseVisualStyleBackColor = true;
			buttonRead.Click += ButtonRead_Click;
			// 
			// buttonWrite
			// 
			buttonWrite.Location = new System.Drawing.Point(100, 3);
			buttonWrite.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			buttonWrite.Name = "buttonWrite";
			buttonWrite.Size = new System.Drawing.Size(88, 27);
			buttonWrite.TabIndex = 4;
			buttonWrite.Text = "Write";
			buttonWrite.UseVisualStyleBackColor = true;
			buttonWrite.Click += ButtonWrite_Click;
			// 
			// groupBoxStatus
			// 
			groupBoxStatus.AutoSize = true;
			groupBoxStatus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			groupBoxStatus.Controls.Add(tableLayoutPanel3);
			groupBoxStatus.Dock = System.Windows.Forms.DockStyle.Fill;
			groupBoxStatus.Location = new System.Drawing.Point(0, 75);
			groupBoxStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			groupBoxStatus.Name = "groupBoxStatus";
			groupBoxStatus.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			groupBoxStatus.Size = new System.Drawing.Size(285, 169);
			groupBoxStatus.TabIndex = 18;
			groupBoxStatus.TabStop = false;
			groupBoxStatus.Text = "Status";
			// 
			// tableLayoutPanel3
			// 
			tableLayoutPanel3.ColumnCount = 1;
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanel3.Controls.Add(tableLayoutPanelVariables, 0, 0);
			tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel3.Location = new System.Drawing.Point(4, 19);
			tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			tableLayoutPanel3.Name = "tableLayoutPanel3";
			tableLayoutPanel3.RowCount = 1;
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 155F));
			tableLayoutPanel3.Size = new System.Drawing.Size(277, 147);
			tableLayoutPanel3.TabIndex = 1;
			// 
			// tableLayoutPanelVariables
			// 
			tableLayoutPanelVariables.Anchor = System.Windows.Forms.AnchorStyles.None;
			tableLayoutPanelVariables.AutoSize = true;
			tableLayoutPanelVariables.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			tableLayoutPanelVariables.ColumnCount = 2;
			tableLayoutPanelVariables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanelVariables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanelVariables.Controls.Add(textBoxSensorCounts, 1, 3);
			tableLayoutPanelVariables.Controls.Add(labelSensorCounts, 0, 3);
			tableLayoutPanelVariables.Controls.Add(labelDateProgrammed, 0, 2);
			tableLayoutPanelVariables.Controls.Add(labelSerialNumber, 0, 0);
			tableLayoutPanelVariables.Controls.Add(labelSensorType, 0, 1);
			tableLayoutPanelVariables.Controls.Add(textBoxSerialNumber, 1, 0);
			tableLayoutPanelVariables.Controls.Add(textBoxSensorType, 1, 1);
			tableLayoutPanelVariables.Controls.Add(textBoxDateProgrammed, 1, 2);
			tableLayoutPanelVariables.Location = new System.Drawing.Point(20, 15);
			tableLayoutPanelVariables.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			tableLayoutPanelVariables.Name = "tableLayoutPanelVariables";
			tableLayoutPanelVariables.RowCount = 4;
			tableLayoutPanelVariables.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanelVariables.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanelVariables.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanelVariables.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanelVariables.Size = new System.Drawing.Size(236, 116);
			tableLayoutPanelVariables.TabIndex = 2;
			// 
			// textBoxSensorCounts
			// 
			textBoxSensorCounts.Location = new System.Drawing.Point(116, 90);
			textBoxSensorCounts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			textBoxSensorCounts.Name = "textBoxSensorCounts";
			textBoxSensorCounts.ReadOnly = true;
			textBoxSensorCounts.Size = new System.Drawing.Size(116, 23);
			textBoxSensorCounts.TabIndex = 23;
			textBoxSensorCounts.TabStop = false;
			// 
			// labelSensorCounts
			// 
			labelSensorCounts.Anchor = System.Windows.Forms.AnchorStyles.Left;
			labelSensorCounts.AutoSize = true;
			labelSensorCounts.Location = new System.Drawing.Point(4, 94);
			labelSensorCounts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelSensorCounts.Name = "labelSensorCounts";
			labelSensorCounts.Size = new System.Drawing.Size(83, 15);
			labelSensorCounts.TabIndex = 22;
			labelSensorCounts.Text = "Sensor Counts";
			// 
			// labelDateProgrammed
			// 
			labelDateProgrammed.Anchor = System.Windows.Forms.AnchorStyles.Left;
			labelDateProgrammed.AutoSize = true;
			labelDateProgrammed.Location = new System.Drawing.Point(4, 65);
			labelDateProgrammed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelDateProgrammed.Name = "labelDateProgrammed";
			labelDateProgrammed.Size = new System.Drawing.Size(104, 15);
			labelDateProgrammed.TabIndex = 20;
			labelDateProgrammed.Text = "Date Programmed";
			// 
			// labelSerialNumber
			// 
			labelSerialNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
			labelSerialNumber.AutoSize = true;
			labelSerialNumber.Location = new System.Drawing.Point(4, 7);
			labelSerialNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelSerialNumber.Name = "labelSerialNumber";
			labelSerialNumber.Size = new System.Drawing.Size(82, 15);
			labelSerialNumber.TabIndex = 0;
			labelSerialNumber.Text = "Serial Number";
			// 
			// labelSensorType
			// 
			labelSensorType.Anchor = System.Windows.Forms.AnchorStyles.Left;
			labelSensorType.AutoSize = true;
			labelSensorType.Location = new System.Drawing.Point(4, 36);
			labelSensorType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelSensorType.Name = "labelSensorType";
			labelSensorType.Size = new System.Drawing.Size(70, 15);
			labelSensorType.TabIndex = 1;
			labelSensorType.Text = "Sensor Type";
			// 
			// textBoxSerialNumber
			// 
			textBoxSerialNumber.Location = new System.Drawing.Point(116, 3);
			textBoxSerialNumber.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			textBoxSerialNumber.Name = "textBoxSerialNumber";
			textBoxSerialNumber.ReadOnly = true;
			textBoxSerialNumber.Size = new System.Drawing.Size(116, 23);
			textBoxSerialNumber.TabIndex = 2;
			textBoxSerialNumber.TabStop = false;
			// 
			// textBoxSensorType
			// 
			textBoxSensorType.Location = new System.Drawing.Point(116, 32);
			textBoxSensorType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			textBoxSensorType.Name = "textBoxSensorType";
			textBoxSensorType.ReadOnly = true;
			textBoxSensorType.Size = new System.Drawing.Size(116, 23);
			textBoxSensorType.TabIndex = 3;
			textBoxSensorType.TabStop = false;
			// 
			// textBoxDateProgrammed
			// 
			textBoxDateProgrammed.Location = new System.Drawing.Point(116, 61);
			textBoxDateProgrammed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			textBoxDateProgrammed.Name = "textBoxDateProgrammed";
			textBoxDateProgrammed.ReadOnly = true;
			textBoxDateProgrammed.Size = new System.Drawing.Size(116, 23);
			textBoxDateProgrammed.TabIndex = 21;
			textBoxDateProgrammed.TabStop = false;
			// 
			// FormProgrammer
			// 
			AcceptButton = buttonWrite;
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(285, 315);
			Controls.Add(groupBoxStatus);
			Controls.Add(tableLayoutPanelTestSetupButtons);
			Controls.Add(groupBoxBarcode);
			Controls.Add(statusStrip);
			Controls.Add(menuStrip1);
			MainMenuStrip = menuStrip1;
			Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			Name = "FormProgrammer";
			Text = "Smart Sensor";
			FormClosed += FormProgrammer_FormClosed;
			Load += FormProgrammer_Load;
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			statusStrip.ResumeLayout(false);
			statusStrip.PerformLayout();
			groupBoxBarcode.ResumeLayout(false);
			groupBoxBarcode.PerformLayout();
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel2.PerformLayout();
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			tableLayoutPanelTestSetupButtons.ResumeLayout(false);
			tableLayoutPanelTestSetupButtons.PerformLayout();
			tableLayoutPanelStartStop.ResumeLayout(false);
			groupBoxStatus.ResumeLayout(false);
			tableLayoutPanel3.ResumeLayout(false);
			tableLayoutPanel3.PerformLayout();
			tableLayoutPanelVariables.ResumeLayout(false);
			tableLayoutPanelVariables.PerformLayout();
			ResumeLayout(false);
			PerformLayout();

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
		private System.Windows.Forms.Label labelDateProgrammed;
		private System.Windows.Forms.TextBox textBoxDateProgrammed;
		private System.Windows.Forms.TextBox textBoxSensorCounts;
		private System.Windows.Forms.Label labelSensorCounts;
	}
}

