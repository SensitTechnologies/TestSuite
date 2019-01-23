using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Sensit.TestSDK.Forms;

namespace Sensit.App.Calibration
{
	public partial class FormCalibration : Form
	{
		public Action TestStart;			// "Start" button action
		public Action TestStop;				// "Stop" button action
		public Action TestPause;			// action to pause a test
		public Func<bool> TestBusy;         // method to check if a test is running
		public Action<string> ModelChanged; // action when model is chanced
		public Action<string> RangeChanged; // action when range is changed
		public Action<string> TestChanged;	// action when test is changed
		public Action Print;				// "Print" button action
		public Action Options;				// action to launch an "Options" form
		public Action<int> NumDutsChanged;  // method to call when the number of DUTs has changed
		public Action Exit;					// action when the program exits

		// allow the form to wait for tests to cancel/complete before closing application
		private bool _closeAfterTest = false;

		// number of devices under test displayed on the form
		private int _numDuts = 1;

		#region Properties

		/// <summary>
		/// Number of DUTs displayed on the form
		/// </summary>
		public int NumDuts
		{
			get => _numDuts;
			set
			{
				_numDuts = value;

				// Stop the GUI from looking weird while we update it.
				tableLayoutPanelDevicesUnderTest.SuspendLayout();

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
					CheckBox checkBox = new CheckBox
					{
						Name = "checkBoxDut" + i.ToString(),
						Text = "DUT" + i.ToString(),
						AutoSize = true
					};
					tableLayoutPanelDevicesUnderTest.Controls.Add(checkBox, 0, i - 1);

					ComboBox comboBox = new ComboBox
					{
						Name = "comboBoxDut" + i.ToString()
					};
					tableLayoutPanelDevicesUnderTest.Controls.Add(comboBox, 1, i - 1);

					TextBox textBox = new TextBox
					{
						Name = "textBoxDut" + i.ToString()
					};
					tableLayoutPanelDevicesUnderTest.Controls.Add(textBox, 2, i - 1);
				}

				// Make the GUI act normally again.
				tableLayoutPanelDevicesUnderTest.ResumeLayout();

				// Inform the application that the number of DUTs has changed.
				NumDutsChanged?.Invoke(NumDuts);
			}
		}

		/// <summary>
		/// Items in the "Model" combobox
		/// </summary>
		public List<string> Models
		{
			set
			{
				// Remove existing items.
				comboBoxModel.Items.Clear();

				// Add new items.
				foreach (var model in value)
				{
					comboBoxModel.Items.Add(model);
				}

				// Select item from settings if it exists.
				comboBoxModel.SelectedIndex = comboBoxModel.FindStringExact(
					Properties.Settings.Default.Model);
			}
		}

		/// <summary>
		/// Items in the "Range" combobox
		/// </summary>
		public List<string> Ranges
		{
			set
			{
				// Remove existing items.
				comboBoxRange.Items.Clear();

				// Add new items.
				foreach (var range in value)
				{
					comboBoxRange.Items.Add(range);
				}

				// Select item from settings if it exists.
				comboBoxRange.SelectedIndex = comboBoxRange.FindStringExact(
					Properties.Settings.Default.Range);
			}
		}

		/// <summary>
		/// Items in the "Test" combobox
		/// </summary>
		public List<string> Tests
		{
			set
			{
				// Remove existing items.
				comboBoxTest.Items.Clear();

				// Add new items.
				foreach (var test in value)
				{
					comboBoxTest.Items.Add(test);
				}

				// Select item from settings if it exists.
				comboBoxTest.SelectedIndex = comboBoxTest.FindStringExact(
					Properties.Settings.Default.Test);
			}
		}

		#endregion

		#region Constructors

		public FormCalibration()
		{
			InitializeComponent();
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// When "Start" button is clicked, run the Start action.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonStart_Click(object sender, EventArgs e)
		{
			try
			{
				// Ensure the user has selected a model, range, and test.
				if ((comboBoxModel.SelectedItem == null) ||
					(comboBoxRange.SelectedItem == null) ||
					(comboBoxTest.SelectedItem == null))
				{
					throw new Exception("Please select model, range, test before starting test.");
				}

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

				// TODO:  Delete DUT tabs (if they exist) and any data on them.
				// TODO:  Clear the DUT data on the Overview tab.
			}
			catch (NullReferenceException)
			{
				MessageBox.Show("The application has not assigned an action to run when a test is started!"
					+ Environment.NewLine + "Please contact your engineering team.", "Error");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error");
			}
		}

		/// <summary>
		/// When the "Stop" button is clicked, run the Stop action.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonStop_Click(object sender, EventArgs e)
		{
			ConfirmAbort();
		}

		/// <summary>
		/// When the "Pause" menu item is clicked, run the Pause action.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				TestPause();
			}
			catch (NullReferenceException)
			{
				MessageBox.Show("This application does not support pausing a test."
					+ Environment.NewLine + "Please contact your engineering team.", "Error");
			}
		}

		/// <summary>
		/// When "Print Labels" button is clicked, run the Print action.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonPrintLabels_Click(object sender, EventArgs e)
		{
			try
			{
				Print();
			}
			catch (NullReferenceException)
			{
				MessageBox.Show("This application does not support printing."
					+ Environment.NewLine + "Please contact your engineering team.", "Error");
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
		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// This will invoke the "FormClosing" action, so nothing else to do here.

			// Run any exit action.
			Exit?.Invoke();

			// Exit the application.
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
				catch (NullReferenceException)
				{
					MessageBox.Show("The application has not assigned an action to run when a test is aborted!"
						+ Environment.NewLine + "Please contact your engineering team.", "Error");
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
			catch (NullReferenceException)
			{
				MessageBox.Show("This application has no options to set.", "Error");
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
			DialogResult result = InputDialog.Numeric("Number of DUTs", ref numDuts, 1, 24);

			// Update the property (which will also update the form).
			NumDuts = numDuts;
		}

		/// <summary>
		/// When the user clicks Help --> About, show an about box.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Create an about box.
			FormAbout formAbout = new FormAbout();

			// Show the about box.
			// ShowDialog() disables interaction with the app's other forms.
			// Show() does not.
			formAbout.ShowDialog();
		}

		/// <summary>
		/// When the "Model" selection is changed, alert the application.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void comboBoxModel_SelectedIndexChanged(object sender, EventArgs e)
		{
			ModelChanged?.Invoke(comboBoxModel.SelectedItem.ToString());
		}

		/// <summary>
		/// When the "Range" selection is changed, alert the application.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void comboBoxRange_SelectedIndexChanged(object sender, EventArgs e)
		{
			RangeChanged?.Invoke(comboBoxRange.SelectedItem.ToString());
		}

		/// <summary>
		/// When the "Test" selection is changed, alert the application.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void comboBoxTest_SelectedIndexChanged(object sender, EventArgs e)
		{
			TestChanged?.Invoke(comboBoxTest.SelectedItem.ToString());
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
				// Run any exit action.
				Exit?.Invoke();

				Application.Exit();
			}
		}
	}
}
