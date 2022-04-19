namespace Sensit.App.Pogo
{
	partial class FormPogo
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tableLayoutPanelStartStop = new System.Windows.Forms.TableLayoutPanel();
			this.buttonStart = new System.Windows.Forms.Button();
			this.buttonStop = new System.Windows.Forms.Button();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.supportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tableLayoutPanelStartStop.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.menuStrip.SuspendLayout();
			this.SuspendLayout();
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
			this.tableLayoutPanelStartStop.Controls.Add(this.buttonStart, 0, 0);
			this.tableLayoutPanelStartStop.Controls.Add(this.buttonStop, 1, 0);
			this.tableLayoutPanelStartStop.Location = new System.Drawing.Point(96, 59);
			this.tableLayoutPanelStartStop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.tableLayoutPanelStartStop.Name = "tableLayoutPanelStartStop";
			this.tableLayoutPanelStartStop.RowCount = 1;
			this.tableLayoutPanelStartStop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelStartStop.Size = new System.Drawing.Size(192, 33);
			this.tableLayoutPanelStartStop.TabIndex = 18;
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(4, 3);
			this.buttonStart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(88, 27);
			this.buttonStart.TabIndex = 1;
			this.buttonStart.Text = "Start";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
			// 
			// buttonStop
			// 
			this.buttonStop.Enabled = false;
			this.buttonStop.Location = new System.Drawing.Point(100, 3);
			this.buttonStop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(88, 27);
			this.buttonStop.TabIndex = 2;
			this.buttonStop.Text = "Stop";
			this.buttonStop.UseVisualStyleBackColor = true;
			this.buttonStop.Click += new System.EventHandler(this.ButtonStop_Click);
			// 
			// statusStrip
			// 
			this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabel});
			this.statusStrip.Location = new System.Drawing.Point(0, 118);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
			this.statusStrip.Size = new System.Drawing.Size(384, 32);
			this.statusStrip.TabIndex = 19;
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
			// menuStrip
			// 
			this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.testToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
			this.menuStrip.Size = new System.Drawing.Size(384, 24);
			this.menuStrip.TabIndex = 20;
			this.menuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.newToolStripMenuItem.Text = "&New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.openToolStripMenuItem.Text = "&Open...";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.saveToolStripMenuItem.Text = "&Save As...";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
			// 
			// toolStripSeparator
			// 
			this.toolStripSeparator.Name = "toolStripSeparator";
			this.toolStripSeparator.Size = new System.Drawing.Size(177, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.exitToolStripMenuItem.Text = "&Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
			// 
			// testToolStripMenuItem
			// 
			this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.stopToolStripMenuItem});
			this.testToolStripMenuItem.Name = "testToolStripMenuItem";
			this.testToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.testToolStripMenuItem.Text = "&Test";
			// 
			// startToolStripMenuItem
			// 
			this.startToolStripMenuItem.Name = "startToolStripMenuItem";
			this.startToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.startToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.startToolStripMenuItem.Text = "&Start";
			this.startToolStripMenuItem.Click += new System.EventHandler(this.ButtonStart_Click);
			// 
			// pauseToolStripMenuItem
			// 
			this.pauseToolStripMenuItem.Enabled = false;
			this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
			this.pauseToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
			this.pauseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.pauseToolStripMenuItem.Text = "&Pause";
			this.pauseToolStripMenuItem.ToolTipText = "Hault the current test temporarily";
			this.pauseToolStripMenuItem.Click += new System.EventHandler(this.PauseToolStripMenuItem_Click);
			// 
			// stopToolStripMenuItem
			// 
			this.stopToolStripMenuItem.Enabled = false;
			this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
			this.stopToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
			this.stopToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.stopToolStripMenuItem.Text = "&Stop";
			this.stopToolStripMenuItem.Click += new System.EventHandler(this.ButtonStop_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supportToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// supportToolStripMenuItem
			// 
			this.supportToolStripMenuItem.Name = "supportToolStripMenuItem";
			this.supportToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.supportToolStripMenuItem.Text = "&Wiki";
			this.supportToolStripMenuItem.Click += new System.EventHandler(this.SupportToolStripMenuItem_Click);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.aboutToolStripMenuItem.Text = "&About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
			// 
			// FormPogo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 150);
			this.Controls.Add(this.menuStrip);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.tableLayoutPanelStartStop);
			this.Name = "FormPogo";
			this.Text = "Pogo Pin Tester";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPogo_FormClosing);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormPogo_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormPogo_DragEnter);
			this.tableLayoutPanelStartStop.ResumeLayout(false);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private TableLayoutPanel tableLayoutPanelStartStop;
		private Button buttonStart;
		private Button buttonStop;
		private StatusStrip statusStrip;
		private ToolStripProgressBar toolStripProgressBar;
		private ToolStripStatusLabel toolStripStatusLabel;
		private MenuStrip menuStrip;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem newToolStripMenuItem;
		private ToolStripMenuItem openToolStripMenuItem;
		private ToolStripMenuItem saveToolStripMenuItem;
		private ToolStripSeparator toolStripSeparator;
		private ToolStripMenuItem exitToolStripMenuItem;
		private ToolStripMenuItem testToolStripMenuItem;
		private ToolStripMenuItem startToolStripMenuItem;
		private ToolStripMenuItem pauseToolStripMenuItem;
		private ToolStripMenuItem stopToolStripMenuItem;
		private ToolStripMenuItem helpToolStripMenuItem;
		private ToolStripMenuItem supportToolStripMenuItem;
		private ToolStripMenuItem aboutToolStripMenuItem;
	}
}