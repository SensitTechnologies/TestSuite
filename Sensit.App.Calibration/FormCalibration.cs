using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Sensit.TestSDK.Forms;
using Sensit.TestSDK.Settings;

namespace Sensit.App.Calibration
{
	/// <summary>
	/// GUI operations and settings access are handled here.
	/// </summary>
	public partial class FormCalibration : Form
	{
		public Action TestStart;			// "Start" button action
		public Action TestStop;				// "Stop" button action
		public Action TestPause;			// action to pause a test
		public Func<bool> TestBusy;         // method to check if a test is running
		public Action Print;				// "Print" button action
		public Action<int> NumDutsChanged;  // method to call when the number of DUTs has changed

		// allow the form to wait for tests to cancel/complete before closing application
		private bool _closeAfterTest = false;

		// settings for model, range
		private DutSettings _dutSettings = Settings.Load<DutSettings>(Properties.Settings.Default.DutSettingsFile);

		// settings for tests
		private TestSettings _testSettings = Settings.Load<TestSettings>(Properties.Settings.Default.TestSettingsFile);

		#region Properties

		/// <summary>
		/// Number of DUTs displayed on the form
		/// </summary>
		public int NumDuts
		{
			get => Properties.Settings.Default.NumDuts;
			set
			{
				Properties.Settings.Default.NumDuts = value;

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

		#endregion

		#region Constructors

		public FormCalibration()
		{
			InitializeComponent();

			// Clear the Model, Range, Test comboboxes.
			comboBoxModel.Items.Clear();
			comboBoxRange.Items.Clear();
			comboBoxTest.Items.Clear();

			// Add each model in the settings.
			foreach (ModelSetting model in _dutSettings.ModelSettings ?? new List<ModelSetting>())
			{
				comboBoxModel.Items.Add(model.Label);
			}

			// Select the most recently used model, or the first if that's not available.
			int index = comboBoxModel.FindStringExact(Properties.Settings.Default.Model);
			if (index == -1)
				comboBoxModel.SelectedIndex = 0;
			else
				comboBoxModel.SelectedIndex = index;
			

			// Find the ranges associated with the selected model.
			ModelSetting m = _dutSettings.ModelSettings.Find(x => x.Label == comboBoxModel.Text);

			// Add each range in the settings.
			foreach (RangeSetting r in m?.RangeSettings ?? new List<RangeSetting>())
			{
				comboBoxRange.Items.Add(r.Label);
			}

			// Select the most recently used range, or the first if that's not available.
			index = comboBoxRange.FindStringExact(Properties.Settings.Default.Range);
			if (index == -1)
				comboBoxRange.SelectedIndex = 0;
			else
				comboBoxRange.SelectedIndex = index;


			// Add each test in the settings.
			foreach (TestSetting t in _testSettings.Tests ?? new List<TestSetting>())
			{
				comboBoxTest.Items.Add(t.Label);
			}

			// Select the most recently used test, or the first if that's not available.
			index = comboBoxTest.FindStringExact(Properties.Settings.Default.Test);
			if (index == -1)
				comboBoxTest.SelectedIndex = 0;
			else
				comboBoxTest.SelectedIndex = index;
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

				// Reload the settings files in case they changed since the app was started.
				_dutSettings = Settings.Load<DutSettings>(Properties.Settings.Default.DutSettingsFile);
				_testSettings = Settings.Load<TestSettings>(Properties.Settings.Default.TestSettingsFile);

				// Find the selected model settings.
				ModelSetting _modelSettings = _dutSettings.ModelSettings.Find(i => i.Label == comboBoxModel.SelectedText);
				if (_modelSettings == null)
				{
					throw new Exception("Model settings not found. Please contact Engineering.");
				}

				// Find the selected range settings.
				RangeSetting _rangeSettings = _modelSettings.RangeSettings.Find(i => i.Label == comboBoxRange.SelectedText);
				if (_rangeSettings == null)
				{
					throw new Exception("Range settings not found. Please contact Engineering.");
				}

				// Find the selected test settings.
				TestSetting _testSetting = _testSettings.Tests.Find(i => i.Label == comboBoxTest.SelectedText);
				if (_testSetting == null)
				{
					throw new Exception("Test settings not found. Please contact Engineering.");
				}

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

				TestStart();
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

			// Save settings.
			Properties.Settings.Default.Save();
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
		/// Present a settings file to the user to edit.
		/// </summary>
		/// <param name="filename"></param>
		private void EditSettings(string filename)
		{
			try
			{
				// Fetch equipment settings.
				EquipmentSettings settings = Settings.Load<EquipmentSettings>(filename);

				// Create and show a new object editor with the equipment settings.
				FormObjectEditor objectEditor = new FormObjectEditor();
				objectEditor.AddObject<EquipmentSettings>(settings, "Label");
				DialogResult result = objectEditor.ShowDialog();

				// If user selects "OK," save the settings.
				if (result == DialogResult.OK)
				{
					Settings.Save(settings, filename);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error");
			}
		}

		/// <summary>
		/// When Tools --> Equipment Settings menu is clicked, open an object browser for the settings.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void equipmentSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			EditSettings(Properties.Settings.Default.SystemSettingsFile);
		}

		/// <summary>
		/// When Tools --> DUT Settings menu is clicked, open an object browser for the settings.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dUTSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			EditSettings(Properties.Settings.Default.DutSettingsFile);
		}

		/// <summary>
		/// When Tools --> Test Settings menu is clicked, open an object browser for the settings.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void testSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			EditSettings(Properties.Settings.Default.TestSettingsFile);
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
		/// When the "Model" selection is changed, save the new selection and fetch new ranges.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void comboBoxModel_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Remember the selected value.
			Properties.Settings.Default.Model = comboBoxModel.SelectedItem.ToString();

			// TODO:  Re-populate the ranges available in the GUI.
		}

		/// <summary>
		/// When the "Range" selection is changed, save the new selection.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void comboBoxRange_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Remember the selected value.
			Properties.Settings.Default.Range = comboBoxRange.SelectedItem.ToString();
		}

		/// <summary>
		/// When the "Test" selection is changed, save the new selection.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void comboBoxTest_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Remember the selected value.
			Properties.Settings.Default.Test = comboBoxTest.SelectedItem.ToString();
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
