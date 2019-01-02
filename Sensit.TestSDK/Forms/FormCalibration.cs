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
			Start();
		}

		/// <summary>
		/// when the "Stop" button is clicked, run the Stop action.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonStop_Click(object sender, System.EventArgs e)
		{
			Stop();
		}

		/// <summary>
		/// When "Select All" button is clicked, select all DUTS.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonSelectAll_Click(object sender, System.EventArgs e)
		{
			// Look through each control.
			foreach (Control c in tableLayoutPanelDevicesUnderTest.Controls)
			{
				// If it's a checkbox...
				if (c is CheckBox cb)
				{
					// Check it.
					cb.Checked = true;
				}
			}
		}

		/// <summary>
		/// When "Select None" button is clicked, deselect all DUTs.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonSelectNone_Click(object sender, System.EventArgs e)
		{
			// Look through each control.
			foreach (Control c in tableLayoutPanelDevicesUnderTest.Controls)
			{
				// If it's a checkbox...
				if (c is CheckBox cb)
				{
					// Uncheck it.
					cb.Checked = false;
				}
			}
		}

		/// <summary>
		/// When "Print Labels" button is clicked, run the Print action.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonPrintLabels_Click(object sender, System.EventArgs e)
		{
			Print();
		}
	}
}
