using System;
using System.Windows.Forms;

namespace Sensit.TestSDK.Forms
{
	public partial class FormCalibration : Form
	{

		public Action Start;	// delegate that will run when the "Start" button is clicked
		public Action Stop;     // delegate that will run when the "Stop" button is clicked
		public Action Print;	// deletate that will run when the "Print" button is clicked

		public FormCalibration()
		{
			InitializeComponent();
		}

		/// <summary>
		/// When File --> Exit menu item is clicked, close the application.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		/// <summary>
		/// When "Start" button is clicked, run the Start action.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonStart_Click(object sender, System.EventArgs e)
		{
			try
			{
				Start();

				// Disable most of the controls.
				comboBoxModel.Enabled = false;
				comboBoxRange.Enabled = false;
				comboBoxTest.Enabled = false;
				checkBoxSelectAll.Enabled = false;
				foreach (Control c in tableLayoutPanelDevicesUnderTest.Controls)
				{
					c.Enabled = false;
				}

				// Enable the "Stop" button and disable the "Start" button.
				buttonStop.Enabled = true;
				buttonStart.Enabled = false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error");
			}
		}

		/// <summary>
		/// when the "Stop" button is clicked, run the Stop action.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonStop_Click(object sender, System.EventArgs e)
		{
			try
			{
				Stop();

				// Enable most of the controls.
				comboBoxModel.Enabled = true;
				comboBoxRange.Enabled = true;
				comboBoxTest.Enabled = true;
				checkBoxSelectAll.Enabled = true;
				foreach (Control c in tableLayoutPanelDevicesUnderTest.Controls)
				{
					c.Enabled = true;
				}

				// Enable the "Start" button and disable the "Stop" button.
				buttonStart.Enabled = true;
				buttonStop.Enabled = false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error");
			}
		}

		/// <summary>
		/// When "Print Labels" button is clicked, run the Print action.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonPrintLabels_Click(object sender, System.EventArgs e)
		{
			try
			{
				Print();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error");
			}
		}

		/// <summary>
		/// When "Select/deselect all" checkbox is clicked, select/deselect all DUTs.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void checkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
		{
			// Look through each control.
			foreach (Control c in tableLayoutPanelDevicesUnderTest.Controls)
			{
				// If it's a checkbox...
				if (c is CheckBox cb)
				{
					// Make its state match the select all checkbox.
					cb.Checked = ((CheckBox)sender).Checked;
				}
			}
		}
	}
}
