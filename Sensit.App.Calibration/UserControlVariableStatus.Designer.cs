
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
			this.groupBox = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.textBoxValue = new System.Windows.Forms.TextBox();
			this.textBoxSetpoint = new System.Windows.Forms.TextBox();
			this.labelPlusMinus = new System.Windows.Forms.Label();
			this.labelUnitOfMeasure = new System.Windows.Forms.Label();
			this.textBoxTolerance = new System.Windows.Forms.TextBox();
			this.labelDesired = new System.Windows.Forms.Label();
			this.groupBox.SuspendLayout();
			this.tableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox
			// 
			this.groupBox.AutoSize = true;
			this.groupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBox.Controls.Add(this.tableLayoutPanel);
			this.groupBox.Location = new System.Drawing.Point(3, 3);
			this.groupBox.Name = "groupBox";
			this.groupBox.Size = new System.Drawing.Size(452, 49);
			this.groupBox.TabIndex = 0;
			this.groupBox.TabStop = false;
			this.groupBox.Text = "Title";
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.AutoSize = true;
			this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel.ColumnCount = 6;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel.Controls.Add(this.textBoxValue, 0, 0);
			this.tableLayoutPanel.Controls.Add(this.textBoxSetpoint, 2, 0);
			this.tableLayoutPanel.Controls.Add(this.labelPlusMinus, 3, 0);
			this.tableLayoutPanel.Controls.Add(this.labelUnitOfMeasure, 5, 0);
			this.tableLayoutPanel.Controls.Add(this.textBoxTolerance, 4, 0);
			this.tableLayoutPanel.Controls.Add(this.labelDesired, 1, 0);
			this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel.Location = new System.Drawing.Point(3, 18);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 1;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.Size = new System.Drawing.Size(446, 28);
			this.tableLayoutPanel.TabIndex = 0;
			// 
			// textBoxValue
			// 
			this.textBoxValue.Location = new System.Drawing.Point(3, 3);
			this.textBoxValue.Name = "textBoxValue";
			this.textBoxValue.ReadOnly = true;
			this.textBoxValue.Size = new System.Drawing.Size(100, 22);
			this.textBoxValue.TabIndex = 2;
			// 
			// textBoxSetpoint
			// 
			this.textBoxSetpoint.Location = new System.Drawing.Point(176, 3);
			this.textBoxSetpoint.Name = "textBoxSetpoint";
			this.textBoxSetpoint.ReadOnly = true;
			this.textBoxSetpoint.Size = new System.Drawing.Size(100, 22);
			this.textBoxSetpoint.TabIndex = 3;
			// 
			// labelPlusMinus
			// 
			this.labelPlusMinus.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelPlusMinus.AutoSize = true;
			this.labelPlusMinus.Location = new System.Drawing.Point(282, 5);
			this.labelPlusMinus.Name = "labelPlusMinus";
			this.labelPlusMinus.Size = new System.Drawing.Size(16, 17);
			this.labelPlusMinus.TabIndex = 4;
			this.labelPlusMinus.Text = "±";
			// 
			// labelUnitOfMeasure
			// 
			this.labelUnitOfMeasure.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelUnitOfMeasure.AutoSize = true;
			this.labelUnitOfMeasure.Location = new System.Drawing.Point(410, 5);
			this.labelUnitOfMeasure.Name = "labelUnitOfMeasure";
			this.labelUnitOfMeasure.Size = new System.Drawing.Size(33, 17);
			this.labelUnitOfMeasure.TabIndex = 5;
			this.labelUnitOfMeasure.Text = "Unit";
			// 
			// textBoxTolerance
			// 
			this.textBoxTolerance.Location = new System.Drawing.Point(304, 3);
			this.textBoxTolerance.Name = "textBoxTolerance";
			this.textBoxTolerance.ReadOnly = true;
			this.textBoxTolerance.Size = new System.Drawing.Size(100, 22);
			this.textBoxTolerance.TabIndex = 6;
			// 
			// labelDesired
			// 
			this.labelDesired.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelDesired.AutoSize = true;
			this.labelDesired.Location = new System.Drawing.Point(109, 5);
			this.labelDesired.Name = "labelDesired";
			this.labelDesired.Size = new System.Drawing.Size(61, 17);
			this.labelDesired.TabIndex = 7;
			this.labelDesired.Text = "Desired:";
			// 
			// UserControlVariableStatus
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.groupBox);
			this.Name = "UserControlVariableStatus";
			this.Size = new System.Drawing.Size(458, 55);
			this.groupBox.ResumeLayout(false);
			this.groupBox.PerformLayout();
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.TextBox textBoxValue;
		private System.Windows.Forms.TextBox textBoxSetpoint;
		private System.Windows.Forms.Label labelPlusMinus;
		private System.Windows.Forms.Label labelUnitOfMeasure;
		private System.Windows.Forms.TextBox textBoxTolerance;
		private System.Windows.Forms.Label labelDesired;
	}
}
