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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 60);
            this.label1.MaximumSize = new System.Drawing.Size(350, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Step";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(6, 105);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(353, 45);
            this.textBox1.TabIndex = 3;
            this.textBox1.Visible = false;
            // 
            // radioButtonPass
            // 
            this.radioButtonPass.AutoSize = true;
            this.radioButtonPass.Location = new System.Drawing.Point(389, 3);
            this.radioButtonPass.Name = "radioButtonPass";
            this.radioButtonPass.Size = new System.Drawing.Size(57, 20);
            this.radioButtonPass.TabIndex = 4;
            this.radioButtonPass.TabStop = true;
            this.radioButtonPass.Text = "Pass";
            this.radioButtonPass.UseVisualStyleBackColor = true;
            this.radioButtonPass.CheckedChanged += new System.EventHandler(this.radioButtonPass_CheckedChanged);
            // 
            // radioButtonFail
            // 
            this.radioButtonFail.AutoSize = true;
            this.radioButtonFail.Location = new System.Drawing.Point(464, 3);
            this.radioButtonFail.Name = "radioButtonFail";
            this.radioButtonFail.Size = new System.Drawing.Size(48, 20);
            this.radioButtonFail.TabIndex = 5;
            this.radioButtonFail.TabStop = true;
            this.radioButtonFail.Text = "Fail";
            this.radioButtonFail.UseVisualStyleBackColor = true;
            this.radioButtonFail.CheckedChanged += new System.EventHandler(this.radioButtonFail_CheckedChanged);
            // 
            // UserCustomStep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.radioButtonFail);
            this.Controls.Add(this.radioButtonPass);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 9, 3, 25);
            this.Name = "UserCustomStep";
            this.Size = new System.Drawing.Size(529, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioButtonPass;
        private System.Windows.Forms.RadioButton radioButtonFail;
    }
}
