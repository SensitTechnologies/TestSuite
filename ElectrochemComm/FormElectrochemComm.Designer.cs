namespace Sensit.App.Aardvark
{
    partial class ElectrochemForm
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
			this.textBoxOutput = new System.Windows.Forms.TextBox();
			this.buttonWrite = new System.Windows.Forms.Button();
			this.buttonRead = new System.Windows.Forms.Button();
			this.textBoxReadAddress = new System.Windows.Forms.TextBox();
			this.textBoxWriteAddress = new System.Windows.Forms.TextBox();
			this.textBoxReadLength = new System.Windows.Forms.TextBox();
			this.addressReadLabel = new System.Windows.Forms.Label();
			this.lengthReadLabel = new System.Windows.Forms.Label();
			this.addressWriteLabel = new System.Windows.Forms.Label();
			this.textBoxData = new System.Windows.Forms.TextBox();
			this.dataWriteLabel = new System.Windows.Forms.Label();
			this.progressBarRead = new System.Windows.Forms.ProgressBar();
			this.DebugBox = new System.Windows.Forms.GroupBox();
			this.DebugBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxOutput
			// 
			this.textBoxOutput.Location = new System.Drawing.Point(319, 8);
			this.textBoxOutput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBoxOutput.Multiline = true;
			this.textBoxOutput.Name = "textBoxOutput";
			this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxOutput.Size = new System.Drawing.Size(223, 380);
			this.textBoxOutput.TabIndex = 12;
			// 
			// buttonWrite
			// 
			this.buttonWrite.Location = new System.Drawing.Point(10, 229);
			this.buttonWrite.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.buttonWrite.Name = "buttonWrite";
			this.buttonWrite.Size = new System.Drawing.Size(133, 67);
			this.buttonWrite.TabIndex = 5;
			this.buttonWrite.Text = "EEPROM Write";
			this.buttonWrite.UseVisualStyleBackColor = true;
			this.buttonWrite.Click += new System.EventHandler(this.ButtonWrite_Click);
			// 
			// buttonRead
			// 
			this.buttonRead.Location = new System.Drawing.Point(10, 93);
			this.buttonRead.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.buttonRead.Name = "buttonRead";
			this.buttonRead.Size = new System.Drawing.Size(133, 60);
			this.buttonRead.TabIndex = 2;
			this.buttonRead.Text = "EEPROM Read";
			this.buttonRead.UseVisualStyleBackColor = true;
			this.buttonRead.Click += new System.EventHandler(this.ButtonRead_Click);
			// 
			// textBoxReadAddress
			// 
			this.textBoxReadAddress.Location = new System.Drawing.Point(149, 93);
			this.textBoxReadAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBoxReadAddress.Name = "textBoxReadAddress";
			this.textBoxReadAddress.Size = new System.Drawing.Size(69, 27);
			this.textBoxReadAddress.TabIndex = 0;
			// 
			// textBoxWAddress
			// 
			this.textBoxWriteAddress.Location = new System.Drawing.Point(149, 229);
			this.textBoxWriteAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBoxWriteAddress.Name = "textBoxWAddress";
			this.textBoxWriteAddress.Size = new System.Drawing.Size(75, 27);
			this.textBoxWriteAddress.TabIndex = 3;
			// 
			// textBoxReadLength
			// 
			this.textBoxReadLength.Location = new System.Drawing.Point(237, 93);
			this.textBoxReadLength.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBoxReadLength.Name = "textBoxReadLength";
			this.textBoxReadLength.Size = new System.Drawing.Size(75, 27);
			this.textBoxReadLength.TabIndex = 1;
			// 
			// addressReadLabel
			// 
			this.addressReadLabel.AutoSize = true;
			this.addressReadLabel.Location = new System.Drawing.Point(149, 69);
			this.addressReadLabel.Name = "addressReadLabel";
			this.addressReadLabel.Size = new System.Drawing.Size(62, 20);
			this.addressReadLabel.TabIndex = 9;
			this.addressReadLabel.Text = "Address";
			// 
			// lengthReadLabel
			// 
			this.lengthReadLabel.AutoSize = true;
			this.lengthReadLabel.Location = new System.Drawing.Point(237, 69);
			this.lengthReadLabel.Name = "lengthReadLabel";
			this.lengthReadLabel.Size = new System.Drawing.Size(54, 20);
			this.lengthReadLabel.TabIndex = 8;
			this.lengthReadLabel.Text = "Length";
			// 
			// addressWriteLabel
			// 
			this.addressWriteLabel.AutoSize = true;
			this.addressWriteLabel.Location = new System.Drawing.Point(149, 205);
			this.addressWriteLabel.Name = "addressWriteLabel";
			this.addressWriteLabel.Size = new System.Drawing.Size(62, 20);
			this.addressWriteLabel.TabIndex = 9;
			this.addressWriteLabel.Text = "Address";
			// 
			// textBoxData
			// 
			this.textBoxData.Location = new System.Drawing.Point(237, 229);
			this.textBoxData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBoxData.Multiline = true;
			this.textBoxData.Name = "textBoxData";
			this.textBoxData.Size = new System.Drawing.Size(75, 159);
			this.textBoxData.TabIndex = 4;
			// 
			// dataWriteLabel
			// 
			this.dataWriteLabel.AutoSize = true;
			this.dataWriteLabel.Location = new System.Drawing.Point(237, 205);
			this.dataWriteLabel.Name = "dataWriteLabel";
			this.dataWriteLabel.Size = new System.Drawing.Size(41, 20);
			this.dataWriteLabel.TabIndex = 11;
			this.dataWriteLabel.Text = "Data";
			// 
			// progressBarRead
			// 
			this.progressBarRead.AccessibleRole = System.Windows.Forms.AccessibleRole.ProgressBar;
			this.progressBarRead.Location = new System.Drawing.Point(10, 160);
			this.progressBarRead.Maximum = 32000;
			this.progressBarRead.Name = "progressBarRead";
			this.progressBarRead.Size = new System.Drawing.Size(133, 29);
			this.progressBarRead.TabIndex = 12;
			// 
			// DebugBox
			// 
			this.DebugBox.Controls.Add(this.progressBarRead);
			this.DebugBox.Controls.Add(this.dataWriteLabel);
			this.DebugBox.Controls.Add(this.textBoxData);
			this.DebugBox.Controls.Add(this.addressWriteLabel);
			this.DebugBox.Controls.Add(this.lengthReadLabel);
			this.DebugBox.Controls.Add(this.addressReadLabel);
			this.DebugBox.Controls.Add(this.textBoxReadLength);
			this.DebugBox.Controls.Add(this.textBoxWriteAddress);
			this.DebugBox.Controls.Add(this.textBoxReadAddress);
			this.DebugBox.Controls.Add(this.buttonRead);
			this.DebugBox.Controls.Add(this.buttonWrite);
			this.DebugBox.Controls.Add(this.textBoxOutput);
			this.DebugBox.Location = new System.Drawing.Point(12, 12);
			this.DebugBox.Name = "DebugBox";
			this.DebugBox.Size = new System.Drawing.Size(558, 411);
			this.DebugBox.TabIndex = 13;
			this.DebugBox.TabStop = false;
			this.DebugBox.Text = "Debug Box";
			// 
			// ElectrochemForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(574, 434);
			this.Controls.Add(this.DebugBox);
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "ElectrochemForm";
			this.Text = "Electrochem Sensor Programmer";
			this.DebugBox.ResumeLayout(false);
			this.DebugBox.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private TextBox textBoxOutput;
        private Button buttonWrite;
        private Button buttonRead;
        private TextBox textBoxWriteAddress;
        private TextBox textBoxReadLength;
        private Label addressReadLabel;
        private Label lengthReadLabel;
        private Label addressWriteLabel;
        private TextBox textBoxData;
        private Label dataWriteLabel;
        public TextBox textBoxReadAddress;
        public ProgressBar progressBarRead;
        private GroupBox DebugBox;
    }
}