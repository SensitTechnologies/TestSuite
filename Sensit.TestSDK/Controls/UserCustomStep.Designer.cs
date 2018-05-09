namespace Sensit.TestSDK.Controls
{
    partial class UserCustomStep
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radioButtonPass = new System.Windows.Forms.RadioButton();
            this.radioButtonFail = new System.Windows.Forms.RadioButton();
            this.expectedResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 70);
            this.label1.MaximumSize = new System.Drawing.Size(262, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Step";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(5, 81);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(259, 39);
            this.textBox1.TabIndex = 3;
            this.textBox1.Visible = false;
            // 
            // radioButtonPass
            // 
            this.radioButtonPass.AutoSize = true;
            this.radioButtonPass.Location = new System.Drawing.Point(292, 2);
            this.radioButtonPass.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonPass.Name = "radioButtonPass";
            this.radioButtonPass.Size = new System.Drawing.Size(55, 19);
            this.radioButtonPass.TabIndex = 4;
            this.radioButtonPass.TabStop = true;
            this.radioButtonPass.Text = "Pass";
            this.radioButtonPass.UseVisualStyleBackColor = true;
            this.radioButtonPass.CheckedChanged += new System.EventHandler(this.radioButtonPass_CheckedChanged);
            // 
            // radioButtonFail
            // 
            this.radioButtonFail.AutoSize = true;
            this.radioButtonFail.Location = new System.Drawing.Point(348, 2);
            this.radioButtonFail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonFail.Name = "radioButtonFail";
            this.radioButtonFail.Size = new System.Drawing.Size(48, 19);
            this.radioButtonFail.TabIndex = 5;
            this.radioButtonFail.TabStop = true;
            this.radioButtonFail.Text = "Fail";
            this.radioButtonFail.UseVisualStyleBackColor = true;
            this.radioButtonFail.CheckedChanged += new System.EventHandler(this.radioButtonFail_CheckedChanged);
            // 
            // expectedResult
            // 
            this.expectedResult.AllowDrop = true;
            this.expectedResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.expectedResult.AutoSize = true;
            this.expectedResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.6F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expectedResult.Location = new System.Drawing.Point(3, 52);
            this.expectedResult.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.expectedResult.MaximumSize = new System.Drawing.Size(262, 0);
            this.expectedResult.Name = "expectedResult";
            this.expectedResult.Size = new System.Drawing.Size(96, 15);
            this.expectedResult.TabIndex = 6;
            this.expectedResult.Text = "Expected Result";
            // 
            // UserCustomStep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.expectedResult);
            this.Controls.Add(this.radioButtonFail);
            this.Controls.Add(this.radioButtonPass);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 7, 2, 20);
            this.Name = "UserCustomStep";
            this.Size = new System.Drawing.Size(398, 121);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioButtonPass;
        private System.Windows.Forms.RadioButton radioButtonFail;
        private System.Windows.Forms.Label expectedResult;
    }
}
