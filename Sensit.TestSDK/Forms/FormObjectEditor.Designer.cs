namespace Sensit.TestSDK.Forms
{
	partial class FormObjectEditor
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
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCan = new System.Windows.Forms.Button();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.SuspendLayout();
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Location = new System.Drawing.Point(174, 41);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(362, 409);
			this.propertyGrid1.TabIndex = 0;
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(12, 12);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// btnCan
			// 
			this.btnCan.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCan.Location = new System.Drawing.Point(93, 12);
			this.btnCan.Name = "btnCan";
			this.btnCan.Size = new System.Drawing.Size(75, 23);
			this.btnCan.TabIndex = 2;
			this.btnCan.Text = "Cancel";
			this.btnCan.UseVisualStyleBackColor = true;
			// 
			// treeView1
			// 
			this.treeView1.Location = new System.Drawing.Point(14, 66);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(154, 384);
			this.treeView1.TabIndex = 3;
			// 
			// FormObjectEditor
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCan;
			this.ClientSize = new System.Drawing.Size(549, 462);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.btnCan);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.propertyGrid1);
			this.MinimumSize = new System.Drawing.Size(400, 500);
			this.Name = "FormObjectEditor";
			this.Text = "frmObjectEditor";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCan;
		private System.Windows.Forms.TreeView treeView1;
	}
}