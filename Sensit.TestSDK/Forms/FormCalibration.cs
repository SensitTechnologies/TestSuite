using System;
using System.Windows.Forms;

namespace Sensit.TestSDK.Forms
{
	public partial class FormCalibration : Form
	{
		public Action TestStart;	// "Start" button action
		public Action TestStop;		// "Stop" button action
		public Action TestPause;	// action to pause a test
		public Func<bool> TestBusy;	// method to check if a test is running
		public Action Print;		// "Print" button action
		public Action Options;      // action to launch an "Options" form

		// allow the form to wait for tests to cancel/complete before closing application
		private bool _closeAfterTest = false;

		private int _numDuts = 1;

		public int NumDuts
		{
			get { return _numDuts; }
			set
			{
				_numDuts = value;

				// Remove all DUT controls.
				for (int i = 0; i < tableLayoutPanelDevicesUnderTest.ColumnCount; i++)
				{
					for (int j = 0; j < tableLayoutPanelDevicesUnderTest.RowCount; j++)
					{
						var control = tableLayoutPanelDevicesUnderTest.GetControlFromPosition(i, j);
						tableLayoutPanelDevicesUnderTest.Controls.Remove(control);
					}
				}

				// Set how many rows there should be.
				tableLayoutPanelDevicesUnderTest.RowCount = value;

				// Create new DUT controls.
				for (int i = 1; i <= value; i++)
				{
					CheckBox checkBox = new CheckBox();
					checkBox.Name = "checkBoxDut" + i.ToString();
					checkBox.Text = "DUT" + i.ToString();
					checkBox.AutoSize = true;
					tableLayoutPanelDevicesUnderTest.Controls.Add(checkBox, 0, i - 1);

					ComboBox comboBox = new ComboBox();
					comboBox.Name = "comboBoxDut" + i.ToString();
					tableLayoutPanelDevicesUnderTest.Controls.Add(comboBox, 1, i - 1);

					TextBox textBox = new TextBox();
					textBox.Name = "textBoxDut" + i.ToString();
					tableLayoutPanelDevicesUnderTest.Controls.Add(textBox, 2, i - 1);
				}
			}
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="duts">how many devices under test to provide controls for</param>
		public FormCalibration(int duts = 1)
		{
			InitializeComponent();

			// Set the amount of DUTs.
			NumDuts = duts;
		}

		#region Private Methods

		/// <summary>
		/// When "Start" button is clicked, run the Start action.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonStart_Click(object sender, System.EventArgs e)
		{
			try
			{
				TestStart();

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
			ConfirmAbort();
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

		/// <summary>
		/// When File --> Exit menu item is clicked, close the application.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			// Exit the application.
			// This will invoke the "FormClosing" action, so nothing else to do here.
			Application.Exit();
		}

		/// <summary>
		/// Before exiting, check the user's wishes and safely end testing.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormCalibration_FormClosing(object sender, FormClosingEventArgs e)
		{
			// If the TestBusy delegate exists and a test is running...
			if ((TestBusy != null) && TestBusy())
			{
				// Cancel application shutdown.
				e.Cancel = true;

				// If the user chooses to abort the test...
				if (ConfirmAbort() == true)
				{
					// Remember to close the application after the test finishes.
					_closeAfterTest = true;
				}
			}
		}

		/// <summary>
		/// Before exiting, check the user's wishes and safely end testing.
		/// </summary>
		/// <returns>true if we're quitting; false if cancelled</returns>
		private bool ConfirmAbort()
		{
			DialogResult result = DialogResult.OK;  // whether to quit or not

			// If the Running delegate exists and a test is running...
			if ((TestBusy != null) && TestBusy())
			{
				// Ask the user if they really want to stop the test.
				result = MessageBox.Show("Abort the test?", "Abort", MessageBoxButtons.OKCancel);
			}

			// If we're quitting...
			if (result == DialogResult.OK)
			{
				try
				{
					// Cancel a test. Don't update GUI; if the test ends it must
					// call the "TestFinished" method.
					TestStop();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error");
				}
			}

			// Return whether or not we're stopping the test.
			return (result == DialogResult.OK);
		}

		/// <summary>
		/// When Tools --> Options menu is clicked, run the Options actions.
		/// </summary>
		/// <remarks>
		/// The application should use this action to launch an app-specific options dialog or form.
		/// </remarks>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Options();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error");
			}
		}
		
		/// <summary>
		/// When Edit --> Number of DUTs is selected, prompt the user to select the number of DUTS.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void numberOfDUTsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Prompt user to enter desired number of DUTs (current value as default).
			int numDuts = NumDuts;
			DialogResult result = InputDialog.Show("Number of DUTs", ref numDuts, 1, 12);

			// Update the property (which will also update the form).
			NumDuts = numDuts;
		}

		#endregion

		/// <summary>
		/// Update the form with the test's status.
		/// </summary>
		/// <param name="message"></param>
		public void TestUpdate(int percent, string message)
		{
			// Update the progress bar.
			toolStripProgressBar1.Value = percent;

			// Update the status message.
			toolStripStatusLabel1.Text = message;
		}

		/// <summary>
		/// Reset the form after a test is completed or cancelled.
		/// </summary>
		public void TestFinished()
		{
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

			// If requested, close the application.
			if (_closeAfterTest)
			{
				Application.Exit();
			}
		}
	}
}
