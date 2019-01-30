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
			this.textBoxActualResult = new System.Windows.Forms.TextBox();
			this.radioButtonPass = new System.Windows.Forms.RadioButton();
			this.radioButtonFail = new System.Windows.Forms.RadioButton();
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.labelExpectedResult = new System.Windows.Forms.Label();
			this.labelInstructions = new System.Windows.Forms.Label();
			this.groupBoxStep = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel.SuspendLayout();
			this.groupBoxStep.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxActualResult
			// 
			this.textBoxActualResult.BackColor = System.Drawing.Color.White;
			this.textBoxActualResult.Location = new System.Drawing.Point(0, 42);
			this.textBoxActualResult.Margin = new System.Windows.Forms.Padding(0);
			this.textBoxActualResult.Multiline = true;
			this.textBoxActualResult.Name = "textBoxActualResult";
			this.textBoxActualResult.Size = new System.Drawing.Size(200, 32);
			this.textBoxActualResult.TabIndex = 3;
			this.textBoxActualResult.Visible = false;
			// 
			// radioButtonPass
			// 
			this.radioButtonPass.AutoSize = true;
			this.radioButtonPass.Location = new System.Drawing.Point(202, 2);
			this.radioButtonPass.Margin = new System.Windows.Forms.Padding(2);
			this.radioButtonPass.Name = "radioButtonPass";
			this.radioButtonPass.Size = new System.Drawing.Size(48, 17);
			this.radioButtonPass.TabIndex = 4;
			this.radioButtonPass.TabStop = true;
			this.radioButtonPass.Text = "Pass";
			this.radioButtonPass.UseVisualStyleBackColor = true;
			this.radioButtonPass.CheckedChanged += new System.EventHandler(this.radioButtonPass_CheckedChanged);
			// 
			// radioButtonFail
			// 
			this.radioButtonFail.AutoSize = true;
			this.radioButtonFail.Location = new System.Drawing.Point(202, 23);
			this.radioButtonFail.Margin = new System.Windows.Forms.Padding(2);
			this.radioButtonFail.Name = "radioButtonFail";
			this.radioButtonFail.Size = new System.Drawing.Size(41, 17);
			this.radioButtonFail.TabIndex = 5;
			this.radioButtonFail.TabStop = true;
			this.radioButtonFail.Text = "Fail";
			this.radioButtonFail.UseVisualStyleBackColor = true;
			this.radioButtonFail.CheckedChanged += new System.EventHandler(this.radioButtonFail_CheckedChanged);
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.AutoSize = true;
			this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel.ColumnCount = 2;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel.Controls.Add(this.labelExpectedResult, 0, 1);
			this.tableLayoutPanel.Controls.Add(this.radioButtonPass, 1, 0);
			this.tableLayoutPanel.Controls.Add(this.labelInstructions, 0, 0);
			this.tableLayoutPanel.Controls.Add(this.textBoxActualResult, 0, 2);
			this.tableLayoutPanel.Controls.Add(this.radioButtonFail, 1, 1);
			this.tableLayoutPanel.Location = new System.Drawing.Point(6, 19);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 3;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.Size = new System.Drawing.Size(252, 74);
			this.tableLayoutPanel.TabIndex = 7;
			// 
			// labelExpectedResult
			// 
			this.labelExpectedResult.AutoSize = true;
			this.labelExpectedResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelExpectedResult.Location = new System.Drawing.Point(3, 21);
			this.labelExpectedResult.Name = "labelExpectedResult";
			this.labelExpectedResult.Size = new System.Drawing.Size(85, 13);
			this.labelExpectedResult.TabIndex = 9;
			this.labelExpectedResult.Text = "Expected Result";
			// 
			// labelInstructions
			// 
			this.labelInstructions.AutoSize = true;
			this.labelInstructions.Location = new System.Drawing.Point(3, 0);
			this.labelInstructions.Name = "labelInstructions";
			this.labelInstructions.Size = new System.Drawing.Size(61, 13);
			this.labelInstructions.TabIndex = 7;
			this.labelInstructions.Text = "Instructions";
			// 
			// groupBoxStep
			// 
			this.groupBoxStep.AutoSize = true;
			this.groupBoxStep.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxStep.Controls.Add(this.tableLayoutPanel);
			this.groupBoxStep.Location = new System.Drawing.Point(4, 4);
			this.groupBoxStep.Name = "groupBoxStep";
			this.groupBoxStep.Size = new System.Drawing.Size(264, 112);
			this.groupBoxStep.TabIndex = 8;
			this.groupBoxStep.TabStop = false;
			this.groupBoxStep.Text = "Step";
			// 
			// UserCustomStep
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.groupBoxStep);
			this.Margin = new System.Windows.Forms.Padding(2, 7, 2, 20);
			this.Name = "UserCustomStep";
			this.Size = new System.Drawing.Size(271, 119);
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			this.groupBoxStep.ResumeLayout(false);
			this.groupBoxStep.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxActualResult;
        private System.Windows.Forms.RadioButton radioButtonPass;
        private System.Windows.Forms.RadioButton radioButtonFail;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.Label labelInstructions;
		private System.Windows.Forms.GroupBox groupBoxStep;
		private System.Windows.Forms.Label labelExpectedResult;
	}
}
