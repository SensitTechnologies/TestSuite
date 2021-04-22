using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using Sensit.TestSDK.Devices;
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
		private const int EQUIPMENT_COLUMN_CHECKBOX = 0;
		private const int EQUIPMENT_COLUMN_LABEL = 1;
		private const int EQUIPMENT_COLUMN_MODEL = 2;
		private const int EQUIPMENT_COLUMN_CONFIG = 3;

		#endregion

		#region Fields

		// allow the form to wait for tests to cancel/complete before closing application
		private bool _closeAfterTest = false;

		// Object to represent test equipment.
		private Equipment _equipment;

		// Object to represent tests.
		private Test _test;

		// Object to represent test results (formerly a device under test).
		private Log _log;

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

			// Initialize the Equipment tab.
			InitEquipment(typeof(IControlDevice));

			// Select the most recently used range.
			numericUpDownRange.Value = Properties.Settings.Default.Range;

			// Select the most recently used flow rate.
			numericUpDownFlowRate.Value = Properties.Settings.Default.FlowRate;

			// Populate the Test combobox based on the test settings.
			comboBoxTest.Items.Clear();
			TestSettings testSettings = Settings.Load<TestSettings>(Properties.Settings.Default.TestSettingsFile);
			foreach (TestSetting t in testSettings.Tests ?? new List<TestSetting>())
			{
				comboBoxTest.Items.Add(t.Label);
			}

			// Select the most recently used test, or the first if that's not available.
			int index = comboBoxTest.FindStringExact(Properties.Settings.Default.Test);
			comboBoxTest.SelectedIndex = index == -1 ? 0 : index;

			// Select the most recently used termination option.
			radioButtonRepeatYes.Checked = Properties.Settings.Default.Repeat;
			radioButtonRepeatNo.Checked = !Properties.Settings.Default.Repeat;
		}

		#endregion

		#region Test

		/// <summary>
		/// When "Start" button is clicked, fetch settings, create equipment/test, start test.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonStart_Click(object sender, EventArgs e)
		{
			try
			{
				// Ensure the user has selected a test.
				if (comboBoxTest.SelectedItem == null)
				{
					throw new Exception("Please select test before starting test.");
				}

				// Ensure the range is valid.
				if ((numericUpDownRange.Value > 100) || (numericUpDownRange.Value < 0))
				{
					throw new Exception("Please choose a range multiplier between 0 and 100.");
				}

				// Ensure the flow rate is valid.
				if ((numericUpDownFlowRate.Value > 500) || (numericUpDownFlowRate.Value < 0))
				{
					throw new Exception("Please choose a flow rate between 0 and 500 sccm.");
				}

				//
				// Reload the settings files in case they changed since the app was started.
				//

				EquipmentSettings equipmentSettings = Settings.Load<EquipmentSettings>(Properties.Settings.Default.SystemSettingsFile);
				if (equipmentSettings == null)
				{
					throw new Exception("Equipment settings not found.  Please contact Engineering.");
				}

				TestSettings testSettings = Settings.Load<TestSettings>(Properties.Settings.Default.TestSettingsFile);
				TestSetting testSetting = testSettings.Tests.Find(i => i.Label == comboBoxTest.Text);
				if (testSetting == null)
				{
					throw new Exception("Test settings not found. Please contact Engineering.");
				}

				//
				// Disable most of the user controls.
				//

				numericUpDownRange.Enabled = false;
				numericUpDownFlowRate.Enabled = false;
				comboBoxTest.Enabled = false;
				radioButtonRepeatNo.Enabled = false;
				radioButtonRepeatYes.Enabled = false;
				buttonStop.Enabled = true;
				buttonStart.Enabled = false;
				startToolStripMenuItem.Enabled = false;
				pauseToolStripMenuItem.Enabled = true;
				abortToolStripMenuItem.Enabled = true;

				// Create object for the equipment.
				_equipment = new Equipment(equipmentSettings);

				// TODO:  Fetch all equipment controls, not just power supply.
				CheckBox checkBoxGasMixer = tableLayoutPanelEquipment.GetControlFromPosition(EQUIPMENT_COLUMN_CHECKBOX, 0) as CheckBox;
				_equipment.UseGasMixer = checkBoxGasMixer.Checked;

				CheckBox checkBoxMassFlow = tableLayoutPanelEquipment.GetControlFromPosition(EQUIPMENT_COLUMN_CHECKBOX, 1) as CheckBox;
				_equipment.UseMassFlow = checkBoxMassFlow.Checked;

				CheckBox checkBoxVoltage = tableLayoutPanelEquipment.GetControlFromPosition(EQUIPMENT_COLUMN_CHECKBOX, 7) as CheckBox;
				_equipment.UsePowerSupply = checkBoxVoltage.Checked;

				_log = new Log()
				{
					Filename = textBoxFilename.Text
				};

				// Create test object and link its actions to actions on this form.
				// https://syncor.blogspot.com/2010/11/passing-getter-and-setter-of-c-property.html
				_test = new Test(testSetting, _equipment, _log)
				{
					Finished = TestFinished,
					UpdateProgress = TestUpdate,
					GasMixRange = numericUpDownRange.Value,
					GasFlowRate = numericUpDownFlowRate.Value,
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

			// Initialize or clear Equipment selections.
			if (Properties.Settings.Default.EquipmentSelections == null)
			{
				Properties.Settings.Default.EquipmentSelections = new System.Collections.Specialized.StringCollection();
			}
			else
			{
				Properties.Settings.Default.EquipmentSelections.Clear();
			}

			// Remember equipment selections.
			for (int i = 0; i < tableLayoutPanelEquipment.RowCount; i++)
			{
				CheckBox checkBox = tableLayoutPanelEquipment.GetControlFromPosition(EQUIPMENT_COLUMN_CHECKBOX, i) as CheckBox;
				Properties.Settings.Default.EquipmentSelections.Add(checkBox.Checked ? "true" : "false");
			}

			// Initialize or clear Equipment type selections.
			if (Properties.Settings.Default.EquipmentModels == null)
			{
				Properties.Settings.Default.EquipmentModels = new System.Collections.Specialized.StringCollection();
			}
			else
			{
				Properties.Settings.Default.EquipmentModels.Clear();
			}

			// Remember Equipment type selections.
			for (int i = 0; i < tableLayoutPanelEquipment.RowCount; i++)
			{
				ComboBox comboBox = tableLayoutPanelEquipment.GetControlFromPosition(EQUIPMENT_COLUMN_MODEL, i) as ComboBox;
				Properties.Settings.Default.EquipmentModels.Add(comboBox.SelectedIndex.ToString());
			}

			// Remember logfile name.
			Properties.Settings.Default.LogfileName = textBoxFilename.Text;

			// Save settings.
			Properties.Settings.Default.Save();
		}

		/// <summary>
		/// When the "Range" is changed, save the new value.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NumericUpDownRange_ValueChanged(object sender, EventArgs e)
		{
			// Remember the selected value.
			Properties.Settings.Default.Range = numericUpDownRange.Value;
		}

		/// <summary>
		/// When the "Flow Rate" is changed, save the new value.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NumericUpDownFlowRate_ValueChanged(object sender, EventArgs e)
		{
			// Remember the selected value.
			Properties.Settings.Default.FlowRate = numericUpDownFlowRate.Value;
		}

		/// <summary>
		/// When the "Test" selection is changed, save the new selection.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ComboBoxTest_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Remember the selected value.
			Properties.Settings.Default.Test = comboBoxTest.SelectedIndex.ToString();
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
		private void InitEquipment(Type type)
		{
			// Stop the GUI from looking weird while we update it.
			tableLayoutPanelEquipment.SuspendLayout();

			// Remove all equipment controls.
			for (int i = 0; i < tableLayoutPanelEquipment.ColumnCount; i++)
			{
				for (int j = 0; j < tableLayoutPanelEquipment.RowCount; j++)
				{
					Control control = tableLayoutPanelEquipment.GetControlFromPosition(i, j);
					tableLayoutPanelEquipment.Controls.Remove(control);
				}
			}

			// Make a list of the types of control devices (should be one per interface).
			List<Type> controlTypes = Utilities.FindInterfaces(type);

			// Set how many rows there should be.
			tableLayoutPanelEquipment.RowCount = controlTypes.Count;

			// Recall the most recently used equipment from settings.
			bool[] selections = null;
			if (Properties.Settings.Default.EquipmentSelections != null)
			{
				List<string> list = Properties.Settings.Default.EquipmentSelections.Cast<string>().ToList();
				selections = list.Select(x => x == "true").ToArray();
			}

			// Recall model selections from settings.
			List<string> models = null;
			if (Properties.Settings.Default.EquipmentModels != null)
			{
				models = Properties.Settings.Default.EquipmentModels.Cast<string>().ToList();
			}

			// Recall config from settings.
			List<string> configs = null;
			if (Properties.Settings.Default.EquipmentConfigs != null)
			{
				configs = Properties.Settings.Default.EquipmentModels.Cast<string>().ToList();
			}

			// For each type of control device...
			int k = 0;
			foreach (Type t in controlTypes)
			{
				// Add a checkbox for selecting the equipment.
				CheckBox checkBox = new CheckBox
				{
					AutoSize = true,
					Anchor = AnchorStyles.Left | AnchorStyles.Top,
					Dock = DockStyle.None,
				};
				tableLayoutPanelEquipment.Controls.Add(checkBox, EQUIPMENT_COLUMN_CHECKBOX, k);

				if (selections != null)
				{
					checkBox.Checked = selections[k];
				}

				// Add a label.
				Label label = new Label
				{
					Anchor = AnchorStyles.Left | AnchorStyles.Top,
					AutoSize = true,
					Dock = DockStyle.None,
					Text = t.GetDescription()
				};
				tableLayoutPanelEquipment.Controls.Add(label, EQUIPMENT_COLUMN_LABEL, k);

				// Add a comboBox for all the choices for that device type.
				ComboBox comboBox = new ComboBox
				{
					Anchor = AnchorStyles.Left | AnchorStyles.Top,
					Dock = DockStyle.None,
					DropDownStyle = ComboBoxStyle.DropDownList
				};
				tableLayoutPanelEquipment.Controls.Add(comboBox, EQUIPMENT_COLUMN_MODEL, k);

				// Add applicable devices.
				List<Type> deviceTypes = Utilities.FindClasses(t);
				foreach (Type d in deviceTypes)
				{
					comboBox.Items.Add(d.GetDescription());
				}

				// Select the most recently used device.
				if (models != null)
				{
					comboBox.SelectedIndex = Convert.ToInt32(models[k]);
				}

				// Add a combo box for configuration.
				ComboBox comboBoxConfig = new ComboBox
				{
					Anchor = AnchorStyles.Left | AnchorStyles.Top,
					Dock = DockStyle.None,
					DropDownStyle = ComboBoxStyle.DropDownList
				};
				tableLayoutPanelEquipment.Controls.Add(comboBoxConfig, EQUIPMENT_COLUMN_CONFIG, k);

				if (configs != null)
				{
					comboBox.SelectedIndex = Convert.ToInt32(configs[k]);
				}

				// Remember what row we're on.
				k++;
			}

			// Make the GUI act normally again.
			tableLayoutPanelEquipment.ResumeLayout();
		}

		#endregion

		#region Settings Menu

		/// <summary>
		/// When Settings --> Log Directory is selected, prompt the user to
		/// select the directory where test results are stored.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LogDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Set the path first shown to the user to be the currently selected one.
			folderBrowserDialog1.SelectedPath = Properties.Settings.Default.LogDirectory;

			// Prompt the user to select a folder for output files.
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
			{
				Properties.Settings.Default.LogDirectory = folderBrowserDialog1.SelectedPath;
			}
		}

		/// <summary>
		/// Present a settings file to the user to edit.
		/// </summary>
		/// <param name="filename"></param>
		private void EditSettings<T>(string filename)
			where T : Attribute
		{
			try
			{
				// Fetch equipment settings.
				T settings = Settings.Load<T>(filename);

				// Create and show a new object editor with the equipment settings.
				FormObjectEditor objectEditor = new FormObjectEditor();
				objectEditor.AddObject<T>(settings, "Label");
				DialogResult result = objectEditor.ShowDialog();

				// If user selects "OK," save the settings.
				if (result == DialogResult.OK)
				{
					Settings.Save(objectEditor.FetchObject<T>(), filename);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Could not edit settings." + Environment.NewLine + ex.Message, "Error");
			}
		}

		/// <summary>
		/// When Tools --> Equipment Settings menu is clicked, open an object browser for the settings.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void EquipmentSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//EditSettings<EquipmentSettings>(Properties.Settings.Default.SystemSettingsFile);
		}

		/// <summary>
		/// When Tools --> Test Settings menu is clicked, open an object browser for the settings.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TestSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Find the file path.
			string filepath = Settings.GetFilePath(Properties.Settings.Default.TestSettingsFile);

			// Show it to the user.
			MessageBox.Show("This filepath has been copied to the clipboard:"
				+ Environment.NewLine + Environment.NewLine + filepath, "Edit this file:");
			Clipboard.SetText(filepath);
			//EditSettings<TestSettings>(Properties.Settings.Default.TestSettingsFile);
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
			numericUpDownRange.Enabled = true;
			numericUpDownFlowRate.Enabled = true;
			comboBoxTest.Enabled = true;
			radioButtonRepeatNo.Enabled = true;
			radioButtonRepeatYes.Enabled = true;

			// Enable the "Start" button and disable the "Stop" button.
			buttonStart.Enabled = true;
			buttonStop.Enabled = false;
			startToolStripMenuItem.Enabled = true;
			pauseToolStripMenuItem.Enabled = false;
			abortToolStripMenuItem.Enabled = false;

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

		/// <summary>
		/// Generate an XML file with the default settings.
		/// </summary>
		/// <remarks>
		/// This file can be substituted in the installation (or in the source repository).
		/// </remarks>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void GenerateFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Allow the user to select a filename.
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "XML-File|*.xml";
			saveFileDialog.Title = "Save a default settings file";
			saveFileDialog.ShowDialog();

			// If a valid filename has been selected...
			if (!string.IsNullOrEmpty(saveFileDialog.FileName))
			{
				// Create a new test settings class.
				TestSettings tests = new TestSettings();

				// Populate the list with default tests.
				tests.Initialize();

				// Save to XML file.
				Settings.Save(tests, saveFileDialog.FileName);
			}

			// Clean up.
			saveFileDialog.Dispose();
		}
	}
}
