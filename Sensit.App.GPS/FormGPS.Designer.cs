namespace Sensit.App.GPS
{
	partial class FormGPS
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGPS));
			this.groupBoxSerialPort = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanelSerialPort = new System.Windows.Forms.TableLayoutPanel();
			this.comboBoxSerialPort = new System.Windows.Forms.ComboBox();
			this.buttonPortRefresh = new System.Windows.Forms.Button();
			this.radioButtonOpen = new System.Windows.Forms.RadioButton();
			this.radioButtonClosed = new System.Windows.Forms.RadioButton();
			this.groupBoxStatus = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanelStatus = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanelVariables = new System.Windows.Forms.TableLayoutPanel();
			this.textBoxPassFixType = new System.Windows.Forms.TextBox();
			this.textBoxPassLongitude = new System.Windows.Forms.TextBox();
			this.textBoxPassLatitude = new System.Windows.Forms.TextBox();
			this.labelTimestamp = new System.Windows.Forms.Label();
			this.labelLatitude = new System.Windows.Forms.Label();
			this.textBoxTimestamp = new System.Windows.Forms.TextBox();
			this.textBoxLatitude = new System.Windows.Forms.TextBox();
			this.labelLongitude = new System.Windows.Forms.Label();
			this.textBoxLongitude = new System.Windows.Forms.TextBox();
			this.labelFixType = new System.Windows.Forms.Label();
			this.labelUnitTimestamp = new System.Windows.Forms.Label();
			this.labelUnitLatitude = new System.Windows.Forms.Label();
			this.labelUnitLongitude = new System.Windows.Forms.Label();
			this.labelSatellites = new System.Windows.Forms.Label();
			this.textBoxPassTimestamp = new System.Windows.Forms.TextBox();
			this.textBoxPassSatellites = new System.Windows.Forms.TextBox();
			this.textBoxFixType = new System.Windows.Forms.TextBox();
			this.textBoxSatellites = new System.Windows.Forms.TextBox();
			this.labelUnitCh3Current = new System.Windows.Forms.Label();
			this.numericUpDownCh4Current = new System.Windows.Forms.NumericUpDown();
			this.groupBoxSerialPort.SuspendLayout();
			this.tableLayoutPanelSerialPort.SuspendLayout();
			this.groupBoxStatus.SuspendLayout();
			this.tableLayoutPanelStatus.SuspendLayout();
			this.tableLayoutPanelVariables.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh4Current)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBoxSerialPort
			// 
			this.groupBoxSerialPort.AutoSize = true;
			this.groupBoxSerialPort.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxSerialPort.Controls.Add(this.tableLayoutPanelSerialPort);
			this.groupBoxSerialPort.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBoxSerialPort.Location = new System.Drawing.Point(0, 0);
			this.groupBoxSerialPort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBoxSerialPort.Name = "groupBoxSerialPort";
			this.groupBoxSerialPort.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBoxSerialPort.Size = new System.Drawing.Size(314, 55);
			this.groupBoxSerialPort.TabIndex = 10;
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
			this.tableLayoutPanelSerialPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
			this.tableLayoutPanelSerialPort.Controls.Add(this.comboBoxSerialPort, 0, 0);
			this.tableLayoutPanelSerialPort.Controls.Add(this.buttonPortRefresh, 1, 0);
			this.tableLayoutPanelSerialPort.Controls.Add(this.radioButtonOpen, 2, 0);
			this.tableLayoutPanelSerialPort.Controls.Add(this.radioButtonClosed, 3, 0);
			this.tableLayoutPanelSerialPort.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanelSerialPort.Location = new System.Drawing.Point(4, 19);
			this.tableLayoutPanelSerialPort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.tableLayoutPanelSerialPort.Name = "tableLayoutPanelSerialPort";
			this.tableLayoutPanelSerialPort.RowCount = 1;
			this.tableLayoutPanelSerialPort.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSerialPort.Size = new System.Drawing.Size(306, 33);
			this.tableLayoutPanelSerialPort.TabIndex = 14;
			// 
			// comboBoxSerialPort
			// 
			this.comboBoxSerialPort.AllowDrop = true;
			this.comboBoxSerialPort.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboBoxSerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSerialPort.FormattingEnabled = true;
			this.comboBoxSerialPort.Location = new System.Drawing.Point(4, 3);
			this.comboBoxSerialPort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.comboBoxSerialPort.Name = "comboBoxSerialPort";
			this.comboBoxSerialPort.Size = new System.Drawing.Size(126, 23);
			this.comboBoxSerialPort.TabIndex = 1;
			this.comboBoxSerialPort.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSerialPort_SelectedIndexChanged);
			// 
			// buttonPortRefresh
			// 
			this.buttonPortRefresh.Image = ((System.Drawing.Image)(resources.GetObject("buttonPortRefresh.Image")));
			this.buttonPortRefresh.Location = new System.Drawing.Point(138, 3);
			this.buttonPortRefresh.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.buttonPortRefresh.Name = "buttonPortRefresh";
			this.buttonPortRefresh.Size = new System.Drawing.Size(33, 27);
			this.buttonPortRefresh.TabIndex = 2;
			this.buttonPortRefresh.UseVisualStyleBackColor = true;
			this.buttonPortRefresh.Click += new System.EventHandler(this.ButtonPortRefresh_Click);
			// 
			// radioButtonOpen
			// 
			this.radioButtonOpen.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.radioButtonOpen.AutoSize = true;
			this.radioButtonOpen.Location = new System.Drawing.Point(179, 7);
			this.radioButtonOpen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.radioButtonOpen.Name = "radioButtonOpen";
			this.radioButtonOpen.Size = new System.Drawing.Size(54, 19);
			this.radioButtonOpen.TabIndex = 3;
			this.radioButtonOpen.Text = "Open";
			this.radioButtonOpen.UseVisualStyleBackColor = true;
			this.radioButtonOpen.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
			// 
			// radioButtonClosed
			// 
			this.radioButtonClosed.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.radioButtonClosed.AutoSize = true;
			this.radioButtonClosed.Checked = true;
			this.radioButtonClosed.Location = new System.Drawing.Point(241, 7);
			this.radioButtonClosed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.radioButtonClosed.Name = "radioButtonClosed";
			this.radioButtonClosed.Size = new System.Drawing.Size(61, 19);
			this.radioButtonClosed.TabIndex = 4;
			this.radioButtonClosed.TabStop = true;
			this.radioButtonClosed.Text = "Closed";
			this.radioButtonClosed.UseVisualStyleBackColor = true;
			this.radioButtonClosed.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
			// 
			// groupBoxStatus
			// 
			this.groupBoxStatus.AutoSize = true;
			this.groupBoxStatus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxStatus.Controls.Add(this.tableLayoutPanelStatus);
			this.groupBoxStatus.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxStatus.Location = new System.Drawing.Point(0, 55);
			this.groupBoxStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBoxStatus.Name = "groupBoxStatus";
			this.groupBoxStatus.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBoxStatus.Size = new System.Drawing.Size(314, 186);
			this.groupBoxStatus.TabIndex = 13;
			this.groupBoxStatus.TabStop = false;
			this.groupBoxStatus.Text = "Status";
			// 
			// tableLayoutPanelStatus
			// 
			this.tableLayoutPanelStatus.ColumnCount = 1;
			this.tableLayoutPanelStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelStatus.Controls.Add(this.tableLayoutPanelVariables, 0, 0);
			this.tableLayoutPanelStatus.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelStatus.Location = new System.Drawing.Point(4, 19);
			this.tableLayoutPanelStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.tableLayoutPanelStatus.Name = "tableLayoutPanelStatus";
			this.tableLayoutPanelStatus.RowCount = 1;
			this.tableLayoutPanelStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 338F));
			this.tableLayoutPanelStatus.Size = new System.Drawing.Size(306, 164);
			this.tableLayoutPanelStatus.TabIndex = 0;
			// 
			// tableLayoutPanelVariables
			// 
			this.tableLayoutPanelVariables.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.tableLayoutPanelVariables.AutoSize = true;
			this.tableLayoutPanelVariables.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelVariables.ColumnCount = 4;
			this.tableLayoutPanelVariables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelVariables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelVariables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelVariables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelVariables.Controls.Add(this.textBoxPassFixType, 3, 3);
			this.tableLayoutPanelVariables.Controls.Add(this.textBoxPassLongitude, 3, 2);
			this.tableLayoutPanelVariables.Controls.Add(this.textBoxPassLatitude, 3, 1);
			this.tableLayoutPanelVariables.Controls.Add(this.labelTimestamp, 0, 0);
			this.tableLayoutPanelVariables.Controls.Add(this.labelLatitude, 0, 1);
			this.tableLayoutPanelVariables.Controls.Add(this.textBoxTimestamp, 1, 0);
			this.tableLayoutPanelVariables.Controls.Add(this.textBoxLatitude, 1, 1);
			this.tableLayoutPanelVariables.Controls.Add(this.labelLongitude, 0, 2);
			this.tableLayoutPanelVariables.Controls.Add(this.textBoxLongitude, 1, 2);
			this.tableLayoutPanelVariables.Controls.Add(this.labelFixType, 0, 3);
			this.tableLayoutPanelVariables.Controls.Add(this.labelUnitTimestamp, 2, 0);
			this.tableLayoutPanelVariables.Controls.Add(this.labelUnitLatitude, 2, 1);
			this.tableLayoutPanelVariables.Controls.Add(this.labelUnitLongitude, 2, 2);
			this.tableLayoutPanelVariables.Controls.Add(this.labelSatellites, 0, 4);
			this.tableLayoutPanelVariables.Controls.Add(this.textBoxPassTimestamp, 3, 0);
			this.tableLayoutPanelVariables.Controls.Add(this.textBoxPassSatellites, 3, 4);
			this.tableLayoutPanelVariables.Controls.Add(this.textBoxFixType, 1, 3);
			this.tableLayoutPanelVariables.Controls.Add(this.textBoxSatellites, 1, 4);
			this.tableLayoutPanelVariables.Location = new System.Drawing.Point(8, 9);
			this.tableLayoutPanelVariables.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.tableLayoutPanelVariables.Name = "tableLayoutPanelVariables";
			this.tableLayoutPanelVariables.RowCount = 5;
			this.tableLayoutPanelVariables.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelVariables.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelVariables.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelVariables.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelVariables.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelVariables.Size = new System.Drawing.Size(289, 145);
			this.tableLayoutPanelVariables.TabIndex = 2;
			// 
			// textBoxPassFixType
			// 
			this.textBoxPassFixType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.textBoxPassFixType.Location = new System.Drawing.Point(250, 90);
			this.textBoxPassFixType.Name = "textBoxPassFixType";
			this.textBoxPassFixType.Size = new System.Drawing.Size(36, 23);
			this.textBoxPassFixType.TabIndex = 20;
			// 
			// textBoxPassLongitude
			// 
			this.textBoxPassLongitude.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.textBoxPassLongitude.Location = new System.Drawing.Point(250, 61);
			this.textBoxPassLongitude.Name = "textBoxPassLongitude";
			this.textBoxPassLongitude.Size = new System.Drawing.Size(36, 23);
			this.textBoxPassLongitude.TabIndex = 19;
			// 
			// textBoxPassLatitude
			// 
			this.textBoxPassLatitude.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.textBoxPassLatitude.Location = new System.Drawing.Point(250, 32);
			this.textBoxPassLatitude.Name = "textBoxPassLatitude";
			this.textBoxPassLatitude.Size = new System.Drawing.Size(36, 23);
			this.textBoxPassLatitude.TabIndex = 18;
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
			// labelLatitude
			// 
			this.labelLatitude.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelLatitude.AutoSize = true;
			this.labelLatitude.Location = new System.Drawing.Point(4, 36);
			this.labelLatitude.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelLatitude.Name = "labelLatitude";
			this.labelLatitude.Size = new System.Drawing.Size(50, 15);
			this.labelLatitude.TabIndex = 1;
			this.labelLatitude.Text = "Latitude";
			// 
			// textBoxTimestamp
			// 
			this.textBoxTimestamp.Location = new System.Drawing.Point(78, 3);
			this.textBoxTimestamp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.textBoxTimestamp.Name = "textBoxTimestamp";
			this.textBoxTimestamp.ReadOnly = true;
			this.textBoxTimestamp.Size = new System.Drawing.Size(116, 23);
			this.textBoxTimestamp.TabIndex = 2;
			// 
			// textBoxLatitude
			// 
			this.textBoxLatitude.Location = new System.Drawing.Point(78, 32);
			this.textBoxLatitude.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.textBoxLatitude.Name = "textBoxLatitude";
			this.textBoxLatitude.ReadOnly = true;
			this.textBoxLatitude.Size = new System.Drawing.Size(116, 23);
			this.textBoxLatitude.TabIndex = 3;
			// 
			// labelLongitude
			// 
			this.labelLongitude.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelLongitude.AutoSize = true;
			this.labelLongitude.Location = new System.Drawing.Point(4, 65);
			this.labelLongitude.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelLongitude.Name = "labelLongitude";
			this.labelLongitude.Size = new System.Drawing.Size(61, 15);
			this.labelLongitude.TabIndex = 4;
			this.labelLongitude.Text = "Longitude";
			// 
			// textBoxLongitude
			// 
			this.textBoxLongitude.Location = new System.Drawing.Point(78, 61);
			this.textBoxLongitude.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.textBoxLongitude.Name = "textBoxLongitude";
			this.textBoxLongitude.ReadOnly = true;
			this.textBoxLongitude.Size = new System.Drawing.Size(116, 23);
			this.textBoxLongitude.TabIndex = 5;
			// 
			// labelFixType
			// 
			this.labelFixType.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelFixType.AutoSize = true;
			this.labelFixType.Location = new System.Drawing.Point(4, 94);
			this.labelFixType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelFixType.Name = "labelFixType";
			this.labelFixType.Size = new System.Drawing.Size(49, 15);
			this.labelFixType.TabIndex = 6;
			this.labelFixType.Text = "Fix Type";
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
			// labelSatellites
			// 
			this.labelSatellites.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelSatellites.AutoSize = true;
			this.labelSatellites.Location = new System.Drawing.Point(4, 123);
			this.labelSatellites.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelSatellites.Name = "labelSatellites";
			this.labelSatellites.Size = new System.Drawing.Size(53, 15);
			this.labelSatellites.TabIndex = 15;
			this.labelSatellites.Text = "Satellites";
			// 
			// textBoxPassTimestamp
			// 
			this.textBoxPassTimestamp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.textBoxPassTimestamp.Location = new System.Drawing.Point(250, 3);
			this.textBoxPassTimestamp.Name = "textBoxPassTimestamp";
			this.textBoxPassTimestamp.Size = new System.Drawing.Size(36, 23);
			this.textBoxPassTimestamp.TabIndex = 17;
			// 
			// textBoxPassSatellites
			// 
			this.textBoxPassSatellites.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.textBoxPassSatellites.Location = new System.Drawing.Point(250, 119);
			this.textBoxPassSatellites.Name = "textBoxPassSatellites";
			this.textBoxPassSatellites.Size = new System.Drawing.Size(36, 23);
			this.textBoxPassSatellites.TabIndex = 21;
			// 
			// textBoxFixType
			// 
			this.textBoxFixType.Location = new System.Drawing.Point(78, 90);
			this.textBoxFixType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.textBoxFixType.Name = "textBoxFixType";
			this.textBoxFixType.ReadOnly = true;
			this.textBoxFixType.Size = new System.Drawing.Size(116, 23);
			this.textBoxFixType.TabIndex = 7;
			// 
			// textBoxSatellites
			// 
			this.textBoxSatellites.Location = new System.Drawing.Point(78, 119);
			this.textBoxSatellites.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.textBoxSatellites.Name = "textBoxSatellites";
			this.textBoxSatellites.ReadOnly = true;
			this.textBoxSatellites.Size = new System.Drawing.Size(116, 23);
			this.textBoxSatellites.TabIndex = 22;
			// 
			// labelUnitCh3Current
			// 
			this.labelUnitCh3Current.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelUnitCh3Current.Location = new System.Drawing.Point(4, 52);
			this.labelUnitCh3Current.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelUnitCh3Current.Name = "labelUnitCh3Current";
			this.labelUnitCh3Current.Size = new System.Drawing.Size(41, 15);
			this.labelUnitCh3Current.TabIndex = 36;
			this.labelUnitCh3Current.Text = "A";
			// 
			// numericUpDownCh4Current
			// 
			this.numericUpDownCh4Current.DecimalPlaces = 2;
			this.numericUpDownCh4Current.Location = new System.Drawing.Point(4, 3);
			this.numericUpDownCh4Current.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.numericUpDownCh4Current.Name = "numericUpDownCh4Current";
			this.numericUpDownCh4Current.Size = new System.Drawing.Size(117, 23);
			this.numericUpDownCh4Current.TabIndex = 21;
			// 
			// FormGPS
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(314, 241);
			this.Controls.Add(this.groupBoxStatus);
			this.Controls.Add(this.groupBoxSerialPort);
			this.Name = "FormGPS";
			this.Text = "GPS Tester";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormGPS_FormClosed);
			this.groupBoxSerialPort.ResumeLayout(false);
			this.groupBoxSerialPort.PerformLayout();
			this.tableLayoutPanelSerialPort.ResumeLayout(false);
			this.tableLayoutPanelSerialPort.PerformLayout();
			this.groupBoxStatus.ResumeLayout(false);
			this.tableLayoutPanelStatus.ResumeLayout(false);
			this.tableLayoutPanelStatus.PerformLayout();
			this.tableLayoutPanelVariables.ResumeLayout(false);
			this.tableLayoutPanelVariables.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCh4Current)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private GroupBox groupBoxSerialPort;
		private TableLayoutPanel tableLayoutPanelSerialPort;
		private ComboBox comboBoxSerialPort;
		private Button buttonPortRefresh;
		private RadioButton radioButtonOpen;
		private RadioButton radioButtonClosed;
		private GroupBox groupBoxStatus;
		private TableLayoutPanel tableLayoutPanelStatus;
		private TableLayoutPanel tableLayoutPanelVariables;
		private Label labelTimestamp;
		private Label labelLatitude;
		private TextBox textBoxTimestamp;
		private TextBox textBoxLatitude;
		private Label labelLongitude;
		private TextBox textBoxLongitude;
		private Label labelFixType;
		private Label labelUnitTimestamp;
		private Label labelUnitLatitude;
		private Label labelUnitLongitude;
		private Label labelUnitCh3Current;
		private NumericUpDown numericUpDownCh4Current;
		private TextBox textBoxPassFixType;
		private TextBox textBoxPassLongitude;
		private TextBox textBoxPassLatitude;
		private TextBox textBoxPassTimestamp;
		private Label labelSatellites;
		private TextBox textBoxFixType;
		private TextBox textBoxPassSatellites;
		private TextBox textBoxSatellites;
	}
}