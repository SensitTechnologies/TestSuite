using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Sensit.TestSDK.Forms;
using Sensit.TestSDK.Interfaces;
using Sensit.TestSDK.Settings;
using Sensit.TestSDK.Utilities;

namespace Sensit.App.Calibration
{
	/// <summary>
	/// GUI operations and settings access are handled here.
	/// </summary>
	public partial class FormCalibration : Form
	{
		#region Constants

		// These constants specify the order that controls appear in the 
		// columns of tableLayoutPanelDevicesUnderTest.
		private const int COLUMN_DEVICES_NAME = 0;
		private const int COLUMN_DEVICES_TYPE = 1;
		private const int COLUMN_DEVICES_PORT = 2;
		private const int COLUMN_EVENTS_DEVICE = 0;
		private const int COLUMN_EVENTS_VARIABLE = 1;
		private const int COLUMN_EVENTS_VALUE = 2;
		private const int COLUMN_EVENTS_DURATION = 3;
		private const int COLUMN_EVENTS_STATUS = 4;

		#endregion

		#region Fields

		// allow the form to wait for tests to cancel/complete before closing application
		private bool _closeAfterTest = false;

		// Object to represent test equipment.
		private Equipment _equipment;

		// Object to represent tests.
		private Test _test;

		// Test settings
		TestSettings _testSettings;

		#endregion

		#region Constructor

		public FormCalibration()
		{
			// Initialize the form.
			InitializeComponent();

			// Add version string to title bar.
			if (ApplicationDeployment.IsNetworkDeployed)
			{
				Text += " " + ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
			}

			// Load settings from most recently used test settings file.
			TestSettings testSettings = Settings.Load<TestSettings>(Properties.Settings.Default.Test);
			// TODO:  Load settings from the file.

			// Select the most recently used termination option.
			radioButtonRepeatYes.Checked = Properties.Settings.Default.Repeat;
			radioButtonRepeatNo.Checked = !Properties.Settings.Default.Repeat;
		}

		#endregion

		#region Test

		/// <summary>
		/// Enable/disable user controls based on whether is test is being run.
		/// </summary>
		/// <param name="testInProgress">true if test is in progress; false otherwise</param>
		private void SetControlEnable(bool testInProgress)
		{
			// Settings group boxes.
			groupBoxDevices.Enabled = !testInProgress;
			groupBoxEvents.Enabled = !testInProgress;
			groupBoxLog.Enabled = !testInProgress;

			// Repeat controls.
			radioButtonRepeatNo.Enabled = testInProgress;
			radioButtonRepeatYes.Enabled = !testInProgress;

			// Start, stop buttons.
			buttonStart.Enabled = !testInProgress;
			buttonStop.Enabled = testInProgress;

			// Menu items.
			startToolStripMenuItem.Enabled = !testInProgress;
			pauseToolStripMenuItem.Enabled = testInProgress;
			stopToolStripMenuItem.Enabled = testInProgress;
			newToolStripMenuItem.Enabled = !testInProgress;
			openToolStripMenuItem.Enabled = !testInProgress;
			saveToolStripMenuItem.Enabled = !testInProgress;
		}

		/// <summary>
		/// When "Start" button is clicked, fetch settings, create equipment/test, start test.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonStart_Click(object sender, EventArgs e)
		{
			try
			{
				// Disable most of the user controls.
				SetControlEnable(true);

				// Create object for the equipment.
				_equipment = new Equipment();

				// TODO:  Add each piece of equipment used in the test.
				// foreach (row in tableLayoutPanelDevices)
				{
					CheckBox checkBoxDeviceName = tableLayoutPanelDevices.GetControlFromPosition(COLUMN_DEVICES_NAME, 1) as CheckBox;
					ComboBox comboBoxDeviceType = tableLayoutPanelDevices.GetControlFromPosition(COLUMN_DEVICES_TYPE, 1) as ComboBox;
					ComboBox comboBoxDevicePort = tableLayoutPanelDevices.GetControlFromPosition(COLUMN_DEVICES_PORT, 1) as ComboBox;
					//_equipment.Add(...);
				}

				// Create test object and link its actions to actions on this form.
				// https://syncor.blogspot.com/2010/11/passing-getter-and-setter-of-c-property.html
				_test = new Test(_testSettings, _equipment, textBoxLogFilename.Text)
				{
					Finished = TestFinished,
					UpdateProgress = TestUpdate,
					Repeat = Properties.Settings.Default.Repeat
				};

				// Start the test.
				_test.Start();
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
		private void ButtonStop_Click(object sender, EventArgs e)
		{
			ConfirmAbort();
		}

		/// <summary>
		/// Before exiting, check the user's wishes and safely end testing.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormCalibration_FormClosing(object sender, FormClosingEventArgs e)
		{
			// If a test exists and is running...
			if ((_test != null) && (_test.IsBusy()))
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

			// If a test exists and is running...
			if ((_test != null) && (_test.IsBusy()))
			{
				// Ask the user if they really want to stop the test.
				result = MessageBox.Show("Abort the test?", "Abort", MessageBoxButtons.OKCancel);
			}

			// If we're quitting, cancel a test.
			// Don't update GUI; the "TestFinished" method will do that.
			if (result == DialogResult.OK)
			{
				try
				{
					_test?.Stop();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Could not stop test." + Environment.NewLine + ex.Message, "Error");
				}
			}

			// Return whether or not we're stopping the test.
			return (result == DialogResult.OK);
		}

		/// <summary>
		/// When the "Repeat" selection is changed, remember the selection.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RadioButtonRepeat_CheckedChanged(object sender, EventArgs e)
		{
			// Do stuff only if the radio button is checked.
			// (Otherwise the actions will run twice.)
			if (((RadioButton)sender).Checked)
			{
				// If the "Open" radio button has been checked...
				if (((RadioButton)sender) == radioButtonRepeatYes)
				{
					Properties.Settings.Default.Repeat = true;
				}
				else if (((RadioButton)sender) == radioButtonRepeatNo)
				{
					Properties.Settings.Default.Repeat = false;
				}
			}
		}

		private void TextBoxLogFilename_TextChanged(object sender, EventArgs e)
		{
			// Remember logfile name.
			Properties.Settings.Default.Logfile = textBoxLogFilename.Text;
		}

		#endregion

		#region File Menu

		/// <summary>
		/// When File --> Exit menu item is clicked, close the application.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// This will invoke the "FormClosing" action, so nothing else to do here.

			// Exit the application.
			Application.Exit();
		}

		/// <summary>
		/// When Test --> Pause menu item is clicked, pause the test.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PauseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_test?.Pause();
		}

		#endregion

		#region Equipment

		/// <summary>
		/// Populate the equipment tab with selections for each type of peripheral.
		/// </summary>
		/// <param name="type"></param>
		private void AddDevice(Type type)
		{
			//// Stop the GUI from looking weird while we update it.
			//tableLayoutPanelDevices.SuspendLayout();

			//// Remove all equipment controls.
			//for (int i = 0; i < tableLayoutPanelEquipment.ColumnCount; i++)
			//{
			//	for (int j = 0; j < tableLayoutPanelEquipment.RowCount; j++)
			//	{
			//		Control control = tableLayoutPanelEquipment.GetControlFromPosition(i, j);
			//		tableLayoutPanelEquipment.Controls.Remove(control);
			//	}
			//}

			//// Make a list of the types of control devices (should be one per interface).
			//List<Type> controlTypes = Utilities.FindInterfaces(type);

			//// Set how many rows there should be.
			//tableLayoutPanelEquipment.RowCount = controlTypes.Count;

			//// Recall the most recently used equipment from settings.
			//bool[] selections = null;
			//if (Properties.Settings.Default.EquipmentSelections != null)
			//{
			//	List<string> list = Properties.Settings.Default.EquipmentSelections.Cast<string>().ToList();
			//	selections = list.Select(x => x == "true").ToArray();
			//}

			//// Recall model selections from settings.
			//List<string> models = null;
			//if (Properties.Settings.Default.EquipmentModels != null)
			//{
			//	models = Properties.Settings.Default.EquipmentModels.Cast<string>().ToList();
			//}

			//// Recall config from settings.
			//List<string> configs = null;
			//if (Properties.Settings.Default.EquipmentConfigs != null)
			//{
			//	configs = Properties.Settings.Default.EquipmentModels.Cast<string>().ToList();
			//}

			//// For each type of control device...
			//int k = 0;
			//foreach (Type t in controlTypes)
			//{
			//	// Add a checkbox for selecting the equipment.
			//	CheckBox checkBox = new CheckBox
			//	{
			//		AutoSize = true,
			//		Anchor = AnchorStyles.Left | AnchorStyles.Top,
			//		Dock = DockStyle.None,
			//	};
			//	tableLayoutPanelEquipment.Controls.Add(checkBox, EQUIPMENT_COLUMN_CHECKBOX, k);

			//	if (selections != null)
			//	{
			//		checkBox.Checked = selections[k];
			//	}

			//	// Add a label.
			//	Label label = new Label
			//	{
			//		Anchor = AnchorStyles.Left | AnchorStyles.Top,
			//		AutoSize = true,
			//		Dock = DockStyle.None,
			//		Text = t.GetDescription()
			//	};
			//	tableLayoutPanelEquipment.Controls.Add(label, EQUIPMENT_COLUMN_LABEL, k);

			//	// Add a comboBox for all the choices for that device type.
			//	ComboBox comboBox = new ComboBox
			//	{
			//		Anchor = AnchorStyles.Left | AnchorStyles.Top,
			//		Dock = DockStyle.None,
			//		DropDownStyle = ComboBoxStyle.DropDownList
			//	};
			//	tableLayoutPanelEquipment.Controls.Add(comboBox, EQUIPMENT_COLUMN_MODEL, k);

			//	// Add applicable devices.
			//	List<Type> deviceTypes = Utilities.FindClasses(t);
			//	foreach (Type d in deviceTypes)
			//	{
			//		comboBox.Items.Add(d.GetDescription());
			//	}

			//	// Select the most recently used device.
			//	if (models != null)
			//	{
			//		comboBox.SelectedIndex = Convert.ToInt32(models[k]);
			//	}

			//	// Add a combo box for configuration.
			//	ComboBox comboBoxConfig = new ComboBox
			//	{
			//		Anchor = AnchorStyles.Left | AnchorStyles.Top,
			//		Dock = DockStyle.None,
			//		DropDownStyle = ComboBoxStyle.DropDownList
			//	};
			//	tableLayoutPanelEquipment.Controls.Add(comboBoxConfig, EQUIPMENT_COLUMN_CONFIG, k);

			//	if (configs != null)
			//	{
			//		comboBox.SelectedIndex = Convert.ToInt32(configs[k]);
			//	}

			//	// Remember what row we're on.
			//	k++;
			//}

			//// Make the GUI act normally again.
			//tableLayoutPanelDevices.ResumeLayout();
		}

		#endregion

		#region Help Menu

		/// <summary>
		/// When the user clicks Help --> About, show an about box.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Show the repository where this program can be found.
			// For the sake of future engineers.
			string description = "Source code can be found at:" + Environment.NewLine
				+ "https://github.com/SensitTechnologies/TestSuite";

			// Create an about box.
			using (FormAbout formAbout = new FormAbout(description))
			{

				// Show the about box.
				// ShowDialog() disables interaction with the app's other forms.
				// Show() does not.
				formAbout.ShowDialog();
			}
		}

		#endregion

		#region Public Methods

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

			// Update variables in "Status" tab.
			UpdateVariable(groupBoxGasMix, textBoxGasMixSetpoint, textBoxGasMixValue, VariableType.GasConcentration);
			UpdateVariable(groupBoxMassFlow, textBoxMassFlowSetpoint, textBoxMassFlowValue, VariableType.MassFlow);
			UpdateVariable(groupBoxVolumeFlow, textBoxVolumeFlowSetpoint, textBoxVolumeFlowValue, VariableType.VolumeFlow);
			UpdateVariable(groupBoxVelocity, textBoxVelocitySetpoint, textBoxVelocityValue, VariableType.Velocity);
			UpdateVariable(groupBoxPressure, textBoxPressureSetpoint, textBoxPressureValue, VariableType.Pressure);
			UpdateVariable(groupBoxTemperature, textBoxTempSetpoint, textBoxTempValue, VariableType.Temperature);
			UpdateVariable(groupBoxCurrent, textBoxCurrentSetpoint, textBoxCurrentValue, VariableType.Current);
			UpdateVariable(groupBoxVoltage, textBoxVoltageSetpoint, textBoxVoltageValue, VariableType.Voltage);
		}

		private void UpdateVariable(GroupBox groupBox, TextBox setpoint, TextBox value, VariableType variableType)
		{
			if (_test.Variables.ContainsKey(variableType))
			{
				groupBox.Visible = true;
				setpoint.Text = _test.Variables[variableType].Setpoint.ToString("G4");
				value.Text = _test.Variables[variableType].Value.ToString("G4");
			}
			else
			{
				groupBox.Visible = false;
			}
		}

		/// <summary>
		/// Reset the form after a test is completed or cancelled.
		/// </summary>
		public void TestFinished()
		{
			// Enable most of the controls.
			SetControlEnable(false);

			// If requested, close the application.
			if (_closeAfterTest)
			{
				Application.Exit();
			}

			// Update the progress bar.
			toolStripProgressBar1.Value = 0;

			// Update the status message.
			toolStripStatusLabel1.Text = "Ready...";
		}

		#endregion

		private void SupportToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				ProcessStartInfo processStartInfo = new ProcessStartInfo("https://github.com/SensitTechnologies/TestSuite/wiki");
				Process.Start(processStartInfo);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + Environment.NewLine +
					"I was trying to navigate to: https://github.com/SensitTechnologies/TestSuite/wiki.", "ERROR");
			}
		}

		private void NewToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Allow the user to select a filename.
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "XML-File|*.xml";
			saveFileDialog.Title = "Save a default settings file";
			saveFileDialog.ShowDialog();

			// If a valid filename has been selected...
			if (!string.IsNullOrEmpty(saveFileDialog.FileName))
			{
				// Save to XML file.
				Settings.Save(_testSettings, saveFileDialog.FileName);
			}

			// Clean up.
			saveFileDialog.Dispose();
		}

		private void ButtonDeviceAdd_Click(object sender, EventArgs e)
		{

		}

		private void ButtonDeviceDelete_Click(object sender, EventArgs e)
		{

		}

		private void CheckBoxDeviceSelectAll_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void ButtonEventAdd_Click(object sender, EventArgs e)
		{

		}

		private void ButtonEventDelete_Click(object sender, EventArgs e)
		{

		}

		private void ButtonLogBrowse_Click(object sender, EventArgs e)
		{

		}

		private void CheckBoxEventSelectAll_CheckedChanged(object sender, EventArgs e)
		{

		}
	}
}
