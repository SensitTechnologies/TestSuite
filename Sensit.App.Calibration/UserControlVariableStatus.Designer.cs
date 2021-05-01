
namespace Sensit.App.Calibration
{
	partial class UserControlVariableStatus
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
			this.groupBoxMassFlow = new System.Windows.Forms.GroupBox();
			this.labelVar1Unit2 = new System.Windows.Forms.Label();
			this.labelVar1Unit1 = new System.Windows.Forms.Label();
			this.textBoxMassFlowValue = new System.Windows.Forms.TextBox();
			this.textBoxMassFlowSetpoint = new System.Windows.Forms.TextBox();
			this.groupBoxMassFlow.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBoxMassFlow
			// 
			this.groupBoxMassFlow.AutoSize = true;
			this.groupBoxMassFlow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxMassFlow.Controls.Add(this.labelVar1Unit2);
			this.groupBoxMassFlow.Controls.Add(this.labelVar1Unit1);
			this.groupBoxMassFlow.Controls.Add(this.textBoxMassFlowValue);
			this.groupBoxMassFlow.Controls.Add(this.textBoxMassFlowSetpoint);
			this.groupBoxMassFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBoxMassFlow.Location = new System.Drawing.Point(4, 4);
			this.groupBoxMassFlow.Margin = new System.Windows.Forms.Padding(4);
			this.groupBoxMassFlow.Name = "groupBoxMassFlow";
			this.groupBoxMassFlow.Padding = new System.Windows.Forms.Padding(4);
			this.groupBoxMassFlow.Size = new System.Drawing.Size(175, 124);
			this.groupBoxMassFlow.TabIndex = 1;
			this.groupBoxMassFlow.TabStop = false;
			this.groupBoxMassFlow.Text = "Mass Flow";
			// 
			// labelVar1Unit2
			// 
			this.labelVar1Unit2.AutoSize = true;
			this.labelVar1Unit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelVar1Unit2.Location = new System.Drawing.Point(109, 66);
			this.labelVar1Unit2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelVar1Unit2.Name = "labelVar1Unit2";
			this.labelVar1Unit2.Size = new System.Drawing.Size(58, 25);
			this.labelVar1Unit2.TabIndex = 5;
			this.labelVar1Unit2.Text = "sccm";
			// 
			// labelVar1Unit1
			// 
			this.labelVar1Unit1.AutoSize = true;
			this.labelVar1Unit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelVar1Unit1.Location = new System.Drawing.Point(109, 27);
			this.labelVar1Unit1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelVar1Unit1.Name = "labelVar1Unit1";
			this.labelVar1Unit1.Size = new System.Drawing.Size(58, 25);
			this.labelVar1Unit1.TabIndex = 4;
			this.labelVar1Unit1.Text = "sccm";
			// 
			// textBoxMassFlowValue
			// 
			this.textBoxMassFlowValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxMassFlowValue.Location = new System.Drawing.Point(8, 63);
			this.textBoxMassFlowValue.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxMassFlowValue.Name = "textBoxMassFlowValue";
			this.textBoxMassFlowValue.ReadOnly = true;
			this.textBoxMassFlowValue.Size = new System.Drawing.Size(92, 30);
			this.textBoxMassFlowValue.TabIndex = 1;
			this.textBoxMassFlowValue.Text = "0.000";
			// 
			// textBoxMassFlowSetpoint
			// 
			this.textBoxMassFlowSetpoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxMassFlowSetpoint.Location = new System.Drawing.Point(8, 23);
			this.textBoxMassFlowSetpoint.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxMassFlowSetpoint.Name = "textBoxMassFlowSetpoint";
			this.textBoxMassFlowSetpoint.ReadOnly = true;
			this.textBoxMassFlowSetpoint.Size = new System.Drawing.Size(92, 30);
			this.textBoxMassFlowSetpoint.TabIndex = 0;
			this.textBoxMassFlowSetpoint.Text = "0.000";
			// 
			// UserControlVariableStatus
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.groupBoxMassFlow);
			this.Name = "UserControlVariableStatus";
			this.Size = new System.Drawing.Size(183, 132);
			this.groupBoxMassFlow.ResumeLayout(false);
			this.groupBoxMassFlow.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBoxMassFlow;
		private System.Windows.Forms.Label labelVar1Unit2;
		private System.Windows.Forms.Label labelVar1Unit1;
		private System.Windows.Forms.TextBox textBoxMassFlowValue;
		private System.Windows.Forms.TextBox textBoxMassFlowSetpoint;
	}
}
