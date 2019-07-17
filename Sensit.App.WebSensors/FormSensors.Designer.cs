namespace Sensit.App.WebSensors
{
	partial class FormSensors
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 1D);
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 2D);
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(10D, 10D);
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.printSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.abortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.reconnectDUTsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.numberOfDUTsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.logDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.supportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpProvider1 = new System.Windows.Forms.HelpProvider();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.Overview = new System.Windows.Forms.TabPage();
			this.tableLayoutPanelOverview = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanelSensors = new System.Windows.Forms.TableLayoutPanel();
			this.checkBoxSelectAll = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanelTestSetupButtons = new System.Windows.Forms.TableLayoutPanel();
			this.buttonStop = new System.Windows.Forms.Button();
			this.buttonStart = new System.Windows.Forms.Button();
			this.tabControlSensors = new System.Windows.Forms.TabControl();
			this.tabPageSensor1 = new System.Windows.Forms.TabPage();
			this.chartSensor1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.statusStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.Overview.SuspendLayout();
			this.tableLayoutPanelOverview.SuspendLayout();
			this.tableLayoutPanelTestSetupButtons.SuspendLayout();
			this.tabControlSensors.SuspendLayout();
			this.tabPageSensor1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chartSensor1)).BeginInit();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 335);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(484, 26);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripProgressBar1
			// 
			this.toolStripProgressBar1.Name = "toolStripProgressBar1";
			this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 20);
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(62, 21);
			this.toolStripStatusLabel1.Text = "Ready...";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.testToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(484, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator2,
            this.printSetupToolStripMenuItem,
            this.printToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Enabled = false;
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
			this.newToolStripMenuItem.Text = "&New";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Enabled = false;
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
			this.openToolStripMenuItem.Text = "&Open Test";
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Enabled = false;
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
			this.closeToolStripMenuItem.Text = "&Close Test";
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Enabled = false;
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
			this.saveToolStripMenuItem.Text = "&Save Test";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(129, 6);
			// 
			// printSetupToolStripMenuItem
			// 
			this.printSetupToolStripMenuItem.Enabled = false;
			this.printSetupToolStripMenuItem.Name = "printSetupToolStripMenuItem";
			this.printSetupToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
			this.printSetupToolStripMenuItem.Text = "&Print Setup";
			// 
			// printToolStripMenuItem
			// 
			this.printToolStripMenuItem.Enabled = false;
			this.printToolStripMenuItem.Name = "printToolStripMenuItem";
			this.printToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
			this.printToolStripMenuItem.Text = "&Print";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(129, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
			this.exitToolStripMenuItem.Text = "&Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// testToolStripMenuItem
			// 
			this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.abortToolStripMenuItem,
            this.toolStripSeparator1,
            this.reconnectDUTsToolStripMenuItem});
			this.testToolStripMenuItem.Name = "testToolStripMenuItem";
			this.testToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.testToolStripMenuItem.Text = "&Test";
			// 
			// startToolStripMenuItem
			// 
			this.startToolStripMenuItem.Name = "startToolStripMenuItem";
			this.startToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.startToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.startToolStripMenuItem.Text = "&Start";
			this.startToolStripMenuItem.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// pauseToolStripMenuItem
			// 
			this.pauseToolStripMenuItem.Enabled = false;
			this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
			this.pauseToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
			this.pauseToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.pauseToolStripMenuItem.Text = "&Pause";
			this.pauseToolStripMenuItem.ToolTipText = "Hault the current test temporarily";
			// 
			// abortToolStripMenuItem
			// 
			this.abortToolStripMenuItem.Enabled = false;
			this.abortToolStripMenuItem.Name = "abortToolStripMenuItem";
			this.abortToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
			this.abortToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.abortToolStripMenuItem.Text = "&Abort";
			this.abortToolStripMenuItem.Click += new System.EventHandler(this.buttonStop_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(124, 6);
			// 
			// reconnectDUTsToolStripMenuItem
			// 
			this.reconnectDUTsToolStripMenuItem.Enabled = false;
			this.reconnectDUTsToolStripMenuItem.Name = "reconnectDUTsToolStripMenuItem";
			this.reconnectDUTsToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.reconnectDUTsToolStripMenuItem.Text = "&Find DUTs";
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.numberOfDUTsToolStripMenuItem,
            this.logDirectoryToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.toolsToolStripMenuItem.Text = "&Settings";
			// 
			// numberOfDUTsToolStripMenuItem
			// 
			this.numberOfDUTsToolStripMenuItem.Name = "numberOfDUTsToolStripMenuItem";
			this.numberOfDUTsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.numberOfDUTsToolStripMenuItem.Text = "&Number of Sensors";
			this.numberOfDUTsToolStripMenuItem.Click += new System.EventHandler(this.NumberOfSensorsToolStripMenuItem_Click);
			// 
			// logDirectoryToolStripMenuItem
			// 
			this.logDirectoryToolStripMenuItem.Name = "logDirectoryToolStripMenuItem";
			this.logDirectoryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.logDirectoryToolStripMenuItem.Text = "&Log Directory";
			this.logDirectoryToolStripMenuItem.Click += new System.EventHandler(this.LogDirectoryToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.supportToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.aboutToolStripMenuItem.Text = "&About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
			// 
			// supportToolStripMenuItem
			// 
			this.supportToolStripMenuItem.Enabled = false;
			this.supportToolStripMenuItem.Name = "supportToolStripMenuItem";
			this.supportToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.supportToolStripMenuItem.Text = "How Do I";
			// 
			// Overview
			// 
			this.Overview.Controls.Add(this.tableLayoutPanelOverview);
			this.Overview.Location = new System.Drawing.Point(4, 22);
			this.Overview.Name = "Overview";
			this.Overview.Padding = new System.Windows.Forms.Padding(3);
			this.Overview.Size = new System.Drawing.Size(476, 285);
			this.Overview.TabIndex = 2;
			this.Overview.Text = "Overview";
			this.Overview.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanelOverview
			// 
			this.tableLayoutPanelOverview.AutoSize = true;
			this.tableLayoutPanelOverview.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelOverview.ColumnCount = 2;
			this.tableLayoutPanelOverview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelOverview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelOverview.Controls.Add(this.tableLayoutPanelTestSetupButtons, 1, 1);
			this.tableLayoutPanelOverview.Controls.Add(this.checkBoxSelectAll, 0, 1);
			this.tableLayoutPanelOverview.Controls.Add(this.tableLayoutPanelSensors, 0, 0);
			this.tableLayoutPanelOverview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelOverview.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanelOverview.Name = "tableLayoutPanelOverview";
			this.tableLayoutPanelOverview.RowCount = 2;
			this.tableLayoutPanelOverview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelOverview.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelOverview.Size = new System.Drawing.Size(470, 279);
			this.tableLayoutPanelOverview.TabIndex = 17;
			// 
			// tableLayoutPanelSensors
			// 
			this.tableLayoutPanelSensors.ColumnCount = 3;
			this.tableLayoutPanelOverview.SetColumnSpan(this.tableLayoutPanelSensors, 2);
			this.tableLayoutPanelSensors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelSensors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelSensors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelSensors.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelSensors.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanelSensors.Name = "tableLayoutPanelSensors";
			this.tableLayoutPanelSensors.RowCount = 1;
			this.tableLayoutPanelSensors.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSensors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 238F));
			this.tableLayoutPanelSensors.Size = new System.Drawing.Size(464, 238);
			this.tableLayoutPanelSensors.TabIndex = 22;
			// 
			// checkBoxSelectAll
			// 
			this.checkBoxSelectAll.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.checkBoxSelectAll.AutoSize = true;
			this.checkBoxSelectAll.Location = new System.Drawing.Point(3, 253);
			this.checkBoxSelectAll.Name = "checkBoxSelectAll";
			this.checkBoxSelectAll.Size = new System.Drawing.Size(114, 17);
			this.checkBoxSelectAll.TabIndex = 21;
			this.checkBoxSelectAll.Text = "Select/deselect all";
			this.checkBoxSelectAll.UseVisualStyleBackColor = true;
			this.checkBoxSelectAll.CheckedChanged += new System.EventHandler(this.checkBoxSelectAll_CheckedChanged);
			// 
			// tableLayoutPanelTestSetupButtons
			// 
			this.tableLayoutPanelTestSetupButtons.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.tableLayoutPanelTestSetupButtons.AutoSize = true;
			this.tableLayoutPanelTestSetupButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelTestSetupButtons.ColumnCount = 2;
			this.tableLayoutPanelTestSetupButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelTestSetupButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelTestSetupButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanelTestSetupButtons.Controls.Add(this.buttonStart, 0, 0);
			this.tableLayoutPanelTestSetupButtons.Controls.Add(this.buttonStop, 1, 0);
			this.tableLayoutPanelTestSetupButtons.Location = new System.Drawing.Point(214, 247);
			this.tableLayoutPanelTestSetupButtons.Name = "tableLayoutPanelTestSetupButtons";
			this.tableLayoutPanelTestSetupButtons.RowCount = 1;
			this.tableLayoutPanelTestSetupButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelTestSetupButtons.Size = new System.Drawing.Size(162, 29);
			this.tableLayoutPanelTestSetupButtons.TabIndex = 13;
			// 
			// buttonStop
			// 
			this.buttonStop.Enabled = false;
			this.helpProvider1.SetHelpString(this.buttonStop, "Abort the currently running test");
			this.buttonStop.Location = new System.Drawing.Point(84, 3);
			this.buttonStop.Name = "buttonStop";
			this.helpProvider1.SetShowHelp(this.buttonStop, true);
			this.buttonStop.Size = new System.Drawing.Size(75, 23);
			this.buttonStop.TabIndex = 1;
			this.buttonStop.Text = "Stop";
			this.buttonStop.UseVisualStyleBackColor = true;
			this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
			// 
			// buttonStart
			// 
			this.helpProvider1.SetHelpString(this.buttonStart, "Begin testing with the selected options");
			this.buttonStart.Location = new System.Drawing.Point(3, 3);
			this.buttonStart.Name = "buttonStart";
			this.helpProvider1.SetShowHelp(this.buttonStart, true);
			this.buttonStart.Size = new System.Drawing.Size(75, 23);
			this.buttonStart.TabIndex = 0;
			this.buttonStart.Text = "Start";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// tabControlSensors
			// 
			this.tabControlSensors.Controls.Add(this.Overview);
			this.tabControlSensors.Controls.Add(this.tabPageSensor1);
			this.tabControlSensors.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlSensors.Location = new System.Drawing.Point(0, 24);
			this.tabControlSensors.Name = "tabControlSensors";
			this.tabControlSensors.SelectedIndex = 0;
			this.tabControlSensors.Size = new System.Drawing.Size(484, 311);
			this.tabControlSensors.TabIndex = 0;
			// 
			// tabPageSensor1
			// 
			this.tabPageSensor1.Controls.Add(this.chartSensor1);
			this.tabPageSensor1.Location = new System.Drawing.Point(4, 22);
			this.tabPageSensor1.Name = "tabPageSensor1";
			this.tabPageSensor1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageSensor1.Size = new System.Drawing.Size(476, 285);
			this.tabPageSensor1.TabIndex = 3;
			this.tabPageSensor1.Text = "Sensor 1";
			this.tabPageSensor1.UseVisualStyleBackColor = true;
			// 
			// chartSensor1
			// 
			chartArea1.Name = "ChartArea1";
			this.chartSensor1.ChartAreas.Add(chartArea1);
			this.chartSensor1.Dock = System.Windows.Forms.DockStyle.Fill;
			legend1.Name = "Legend1";
			this.chartSensor1.Legends.Add(legend1);
			this.chartSensor1.Location = new System.Drawing.Point(3, 3);
			this.chartSensor1.Name = "chartSensor1";
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			dataPoint1.IsVisibleInLegend = true;
			dataPoint1.Label = "";
			series1.Points.Add(dataPoint1);
			series1.Points.Add(dataPoint2);
			series1.Points.Add(dataPoint3);
			series1.Points.Add(dataPoint4);
			series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
			this.chartSensor1.Series.Add(series1);
			this.chartSensor1.Size = new System.Drawing.Size(470, 279);
			this.chartSensor1.TabIndex = 0;
			this.chartSensor1.Text = "chart1";
			// 
			// FormSensors
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(484, 361);
			this.Controls.Add(this.tabControlSensors);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FormSensors";
			this.Text = "Web Sensors";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCalibration_FormClosing);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.Overview.ResumeLayout(false);
			this.Overview.PerformLayout();
			this.tableLayoutPanelOverview.ResumeLayout(false);
			this.tableLayoutPanelOverview.PerformLayout();
			this.tableLayoutPanelTestSetupButtons.ResumeLayout(false);
			this.tabControlSensors.ResumeLayout(false);
			this.tabPageSensor1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chartSensor1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem supportToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem abortToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem reconnectDUTsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripMenuItem printSetupToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.HelpProvider helpProvider1;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
		private System.Windows.Forms.ToolStripMenuItem numberOfDUTsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem logDirectoryToolStripMenuItem;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.TabPage Overview;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelOverview;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTestSetupButtons;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.Button buttonStop;
		private System.Windows.Forms.CheckBox checkBoxSelectAll;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSensors;
		private System.Windows.Forms.TabControl tabControlSensors;
		private System.Windows.Forms.TabPage tabPageSensor1;
		private System.Windows.Forms.DataVisualization.Charting.Chart chartSensor1;
	}
}

