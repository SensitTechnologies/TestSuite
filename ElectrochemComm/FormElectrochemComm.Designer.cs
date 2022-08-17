namespace ElectrochemComm
{
    partial class ElectrochemComm
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
            this.textBoxRAddress = new System.Windows.Forms.TextBox();
            this.textBoxWAddress = new System.Windows.Forms.TextBox();
            this.textBoxReadLength = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxData = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Location = new System.Drawing.Point(283, 12);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.Size = new System.Drawing.Size(196, 286);
            this.textBoxOutput.TabIndex = 0;
            // 
            // buttonWrite
            // 
            this.buttonWrite.Location = new System.Drawing.Point(12, 178);
            this.buttonWrite.Name = "buttonWrite";
            this.buttonWrite.Size = new System.Drawing.Size(116, 50);
            this.buttonWrite.TabIndex = 1;
            this.buttonWrite.Text = "EEPROM Write";
            this.buttonWrite.UseVisualStyleBackColor = true;
            this.buttonWrite.Click += new System.EventHandler(this.ButtonWrite_Click);
            // 
            // buttonRead
            // 
            this.buttonRead.Location = new System.Drawing.Point(12, 76);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(116, 45);
            this.buttonRead.TabIndex = 2;
            this.buttonRead.Text = "EEPROM Read";
            this.buttonRead.UseVisualStyleBackColor = true;
            this.buttonRead.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxRAddress
            // 
            this.textBoxRAddress.Location = new System.Drawing.Point(134, 76);
            this.textBoxRAddress.Name = "textBoxRAddress";
            this.textBoxRAddress.Size = new System.Drawing.Size(61, 23);
            this.textBoxRAddress.TabIndex = 3;
            this.textBoxRAddress.TextChanged += new System.EventHandler(this.textBoxRAddress_TextChanged);
            // 
            // textBoxWAddress
            // 
            this.textBoxWAddress.Location = new System.Drawing.Point(134, 178);
            this.textBoxWAddress.Name = "textBoxWAddress";
            this.textBoxWAddress.Size = new System.Drawing.Size(66, 23);
            this.textBoxWAddress.TabIndex = 5;
            this.textBoxWAddress.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // textBoxReadLength
            // 
            this.textBoxReadLength.Location = new System.Drawing.Point(211, 76);
            this.textBoxReadLength.Name = "textBoxReadLength";
            this.textBoxReadLength.Size = new System.Drawing.Size(66, 23);
            this.textBoxReadLength.TabIndex = 6;
            this.textBoxReadLength.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Address";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Length";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Address";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBoxData
            // 
            this.textBoxData.Location = new System.Drawing.Point(211, 178);
            this.textBoxData.Multiline = true;
            this.textBoxData.Name = "textBoxData";
            this.textBoxData.Size = new System.Drawing.Size(66, 120);
            this.textBoxData.TabIndex = 10;
            this.textBoxData.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(211, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Data";
            // 
            // ElectrochemComm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 322);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxReadLength);
            this.Controls.Add(this.textBoxWAddress);
            this.Controls.Add(this.textBoxRAddress);
            this.Controls.Add(this.buttonRead);
            this.Controls.Add(this.buttonWrite);
            this.Controls.Add(this.textBoxOutput);
            this.Name = "ElectrochemComm";
            this.Text = "ElectrochemComm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ElectrochemComm_FormClosed);
            this.Load += new System.EventHandler(this.ElectrochemComm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBoxOutput;
        private Button buttonWrite;
        private Button buttonRead;
        private TextBox textBoxRAddress;
        private TextBox textBoxWAddress;
        private TextBox textBoxReadLength;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxData;
        private Label label4;
    }
}