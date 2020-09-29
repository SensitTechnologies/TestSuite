using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using Sensit.TestSDK.Exceptions;
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
		private const int DUT_COLUMN_CHECKBOX = 0;
		private const int DUT_COLUMN_SERIALNUM = 1;
		private const int DUT_COLUMN_MODEL = 2;
		private const int DUT_COLUMN_CONFIG1 = 3;
		private const int DUT_COLUMN_CONFIG2 = 4;
		private const int DUT_COLUMN_STATUS = 5;
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

		// Object to represent devices under test.
		private List<Dut> _duts = new List<Dut>();

		// Object to represent tests.
		private Test _test;

		#endregion

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
						Control control = tableLayoutPanelDevicesUnderTest.GetControlFromPosition(i, j);
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
						Name = "checkBoxSelected" + i.ToString(CultureInfo.InvariantCulture),
						AutoSize = true,
						Anchor = AnchorStyles.Left | AnchorStyles.Top,
						Dock = DockStyle.None
					};
					tableLayoutPanelDevicesUnderTest.Controls.Add(checkBox, DUT_COLUMN_CHECKBOX, i - 1);

					TextBox textBoxSerialNumber = new TextBox
					{
						Name = "textBoxSerialNumber" + i.ToString(CultureInfo.InvariantCulture),
						Anchor = AnchorStyles.Left | AnchorStyles.Top,
						Dock = DockStyle.None,
						Text = "DUT" + i.ToString()
					};
					tableLayoutPanelDevicesUnderTest.Controls.Add(textBoxSerialNumber, DUT_COLUMN_SERIALNUM, i - 1);

					ComboBox comboBox = new ComboBox
					{
						Name = "comboBoxType" + i.ToString(CultureInfo.InvariantCulture),
						Anchor = AnchorStyles.Left | AnchorStyles.Top,
						Dock = DockStyle.None,
						DropDownStyle = ComboBoxStyle.DropDownList
					};
					tableLayoutPanelDevicesUnderTest.Controls.Add(comboBox, DUT_COLUMN_MODEL, i - 1);

					// Add an event handler to run when the comboBox's value is changed.
					comboBox.SelectedIndexChanged += new EventHandler(ComboBoxType_SelectedIndexChanged);

					// Populate the Model combobox based on DUT settings.
					comboBox.Items.Clear();
					DutSettings dutSettings = Settings.Load<DutSettings>(Properties.Settings.Default.DutSettingsFile);
					foreach (ModelSetting model in dutSettings.ModelSettings ?? new List<ModelSetting>())
					{
						comboBox.Items.Add(model.Label);
					}
					// Select whatever model has been selected by the combo box at the bottom of the form.
					comboBox.SelectedIndex = comboBoxModel.SelectedIndex;

					Label labelStatus = new Label
					{
						Name = "labelStatus" + i.ToString(CultureInfo.InvariantCulture),
						AutoSize = true,
						Anchor = AnchorStyles.Left | AnchorStyles.Top,
						Dock = DockStyle.None
					};
					tableLayoutPanelDevicesUnderTest.Controls.Add(labelStatus, DUT_COLUMN_STATUS, i - 1);
				}

				// Make the GUI act normally again.
				tableLayoutPanelDevicesUnderTest.ResumeLayout();
			}
		}

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

			// Set the number of DUTs.
			NumDuts = Properties.Settings.Default.NumDuts;

			// Select the most recently used DUTs.
			if (Properties.Settings.Default.DutSelections != null)
			{
				List<string> list = Properties.Settings.Default.DutSelections.Cast<string>().ToList();
				bool[] selections = list.Select(x => x == "true").ToArray();
				for (int i = 0; i < NumDuts; i++)
				{
					CheckBox checkBox = tableLayoutPanelDevicesUnderTest.GetControlFromPosition(DUT_COLUMN_CHECKBOX, i) as CheckBox;
					checkBox.Checked = selections[i];
				}
			}

			// Populate the Model combobox (at the bottom of the form, which updates all the individual controls) based on DUT settings.
			comboBoxModel.Items.Clear();
			DutSettings dutSettings = Settings.Load<DutSettings>(Properties.Settings.Default.DutSettingsFile);
			foreach (ModelSetting model in dutSettings.ModelSettings ?? new List<ModelSetting>())
			{
				comboBoxModel.Items.Add(model.Label);
			}

			// Select the most recently used model, or the first if that's not available.
			// This has to be done before setting the individual model selections, or it will override them.
			int index = comboBoxModel.FindStringExact(Properties.Settings.Default.Model);
			comboBoxModel.SelectedIndex = index == -1 ? 0 : index;

			// Select the individual Models.
			// This must be done after selecting the "Set all models" comboBox, or it will override the individual settings.
			if (Properties.Settings.Default.DutModels != null)
			{
				List<string> list = Properties.Settings.Default.DutModels.Cast<string>().ToList();
				for (int i = 0; i < NumDuts; i++)
				{
					ComboBox comboBox = tableLayoutPanelDevicesUnderTest.GetControlFromPosition(DUT_COLUMN_MODEL, i) as ComboBox;
					int j = comboBox.FindStringExact(list[i]);
					comboBox.SelectedIndex = j == -1 ? 0 : j;
				}
			}

			// Set the DUT description based on saved settings.
			if (Properties.Settings.Default.DutDescriptions != null)
			{
				List<string> list = Properties.Settings.Default.DutDescriptions.Cast<string>().ToList();
				for (int i = 0; i < NumDuts; i++)
				{
					TextBox textBox = tableLayoutPanelDevicesUnderTest.GetControlFromPosition(DUT_COLUMN_SERIALNUM, i) as TextBox;
					textBox.Text = list[i];
				}
			}

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
			index = comboBoxTest.FindStringExact(Properties.Settings.Default.Test);
			comboBoxTest.SelectedIndex = index == -1 ? 0 : index;

			// Select the most recently used termination option.
			radioButtonRepeatYes.Checked = Properties.Settings.Default.Repeat;
			radioButtonRepeatNo.Checked = !Properties.Settings.Default.Repeat;
		}

		#endregion

		#region Test

		/// <summary>
		/// When "Start" button is clicked, fetch settings, create equipment/test/DUTs, start test.
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

				comboBoxModel.Enabled = false;
				numericUpDownRange.Enabled = false;
				numericUpDownFlowRate.Enabled = false;
				comboBoxTest.Enabled = false;
				checkBoxSelectAll.Enabled = false;
				radioButtonRepeatNo.Enabled = false;
				radioButtonRepeatYes.Enabled = false;
				foreach (Control c in tableLayoutPanelDevicesUnderTest.Controls)
				{
					c.Enabled = false;
				}
				buttonStop.Enabled = true;
				buttonStart.Enabled = false;
				startToolStripMenuItem.Enabled = false;
				pauseToolStripMenuItem.Enabled = true;
				abortToolStripMenuItem.Enabled = true;

				// Create object for the equipment.
				_equipment = new Equipment(equipmentSettings);

				// Initialize the number of DUTs to configure the datalogger for.
				// TODO:  Move this somewhere more intuitive.
				_equipment.DutInterface.Channels.AddRange(new bool[NumDuts]);

				// TODO:  Fetch all equipment controls, not just power supply.
				CheckBox checkBoxGasMixer = tableLayoutPanelEquipment.GetControlFromPosition(DUT_COLUMN_CHECKBOX, 0) as CheckBox;
				_equipment.UseGasMixer = checkBoxGasMixer.Checked;

				CheckBox checkBoxMassFlow = tableLayoutPanelEquipment.GetControlFromPosition(DUT_COLUMN_CHECKBOX, 1) as CheckBox;
				_equipment.UseMassFlow = checkBoxMassFlow.Checked;

				CheckBox checkBoxVoltage = tableLayoutPanelEquipment.GetControlFromPosition(DUT_COLUMN_CHECKBOX, 7) as CheckBox;
				_equipment.UsePowerSupply = checkBoxVoltage.Checked;

				// Create objects for each DUT.
				_duts.Clear();
				for (uint i = 0; i < NumDuts; i++)
				{
					// Fetch user settings for DUT.
					CheckBox checkBox = tableLayoutPanelDevicesUnderTest.GetControlFromPosition(DUT_COLUMN_CHECKBOX, (int)i) as CheckBox;
					TextBox textBoxSerial = tableLayoutPanelDevicesUnderTest.GetControlFromPosition(DUT_COLUMN_SERIALNUM, (int)i) as TextBox;
					ComboBox comboBox = tableLayoutPanelDevicesUnderTest.GetControlFromPosition(DUT_COLUMN_MODEL, (int)i) as ComboBox;

					DutSettings dutSettings = Settings.Load<DutSettings>(Properties.Settings.Default.DutSettingsFile);
					ModelSetting modelSetting = dutSettings.ModelSettings.Find(j => j.Label == comboBox.Text);
					if (modelSetting == null)
					{
						throw new Exception("Model settings not found. Please contact Engineering.");
					}

					Dut dut = new Dut(modelSetting)
					{
						SetSerialNumber = SetDutSerialNumber,
						SetStatus = SetDutStatus,
						DutInterface = _equipment.DutInterface,
						Index = i + 1,
						Selected = checkBox.Checked,
						Status = DutStatus.Init,
						SerialNumber = textBoxSerial.Text,
						StatusMessage = string.Empty
					};

					// If the DUT has an associated serial port...
					if ((modelSetting.Label == "Sensit G3") || 
						(modelSetting.Label == "Serial Device"))
					{
						// Fetch the associated serial port.
						ComboBox comboBoxConfig = tableLayoutPanelDevicesUnderTest.GetControlFromPosition(DUT_COLUMN_CONFIG1, (int)i) as ComboBox;

						// Assign the serial port to the DUT.
						dut.CommPort = comboBoxConfig.Text;
					}

					// If the DUT has an associated serial prompt...
					if (modelSetting.Label == "Serial Device")
					{
						// Fetch the serial prompt.
						TextBox textBoxSerialPrompt = tableLayoutPanelDevicesUnderTest.GetControlFromPosition(DUT_COLUMN_CONFIG2, (int)i) as TextBox;

						// Assign the prompt to the DUT.
						dut.CommPrompt = textBoxSerialPrompt.Text;
					}

					_duts.Add(dut);
				}

				// Create test object and link its actions to actions on this form.
				// https://syncor.blogspot.com/2010/11/passing-getter-and-setter-of-c-property.html
				_test = new Test(testSetting, _equipment, _duts)
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

			// Initialize or clear DUT selections.
			if (Properties.Settings.Default.DutSelections == null)
			{
				Properties.Settings.Default.DutSelections = new System.Collections.Specialized.StringCollection();
			}
			else
			{
				Properties.Settings.Default.DutSelections.Clear();
			}

			// Remember DUT selections.
			for (int i = 0; i < NumDuts; i++)
			{
				CheckBox checkBox = tableLayoutPanelDevicesUnderTest.GetControlFromPosition(DUT_COLUMN_CHECKBOX, i) as CheckBox;
				Properties.Settings.Default.DutSelections.Add(checkBox.Checked ? "true" : "false");
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

			// Initialize or clear DUT type selections.
			if (Properties.Settings.Default.DutModels == null)
			{
				Properties.Settings.Default.DutModels = new System.Collections.Specialized.StringCollection();
			}
			else
			{
				Properties.Settings.Default.DutModels.Clear();
			}

			// Remember DUT type selections.
			for (int i = 0; i < NumDuts; i++)
			{
				ComboBox comboBox = tableLayoutPanelDevicesUnderTest.GetControlFromPosition(DUT_COLUMN_MODEL, i) as ComboBox;
				Properties.Settings.Default.DutModels.Add(comboBox.SelectedIndex.ToString());
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

			// Initialize or clear DUT description.
			if (Properties.Settings.Default.DutDescriptions == null)
			{
				Properties.Settings.Default.DutDescriptions = new System.Collections.Specialized.StringCollection();
			}
			else
			{
				Properties.Settings.Default.DutDescriptions.Clear();
			}

			// Remember DUT description.
			for (int i = 0; i < NumDuts; i++)
			{
				TextBox textBox = tableLayoutPanelDevicesUnderTest.GetControlFromPosition(DUT_COLUMN_SERIALNUM, i) as TextBox;
				Properties.Settings.Default.DutDescriptions.Add(textBox.Text);
			}

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

		#region DUT

		/// <summary>
		/// When the "Model" selection is changed, update the model of each individual DUT.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ComboBoxModel_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Remember the selected value.
			Properties.Settings.Default.Model = comboBoxModel.SelectedIndex.ToString();

			// Update the individual selections for all DUTs.
			for (int i = 0; i < NumDuts; i++)
			{
				ComboBox comboBox = tableLayoutPanelDevicesUnderTest.GetControlFromPosition(DUT_COLUMN_MODEL, i) as ComboBox;
				int j = comboBox.FindStringExact(comboBoxModel.SelectedIndex.ToString());
				comboBox.SelectedIndex = j == -1 ? 0 : j;
			}
		}

		/// <summary>
		/// When "Select/deselect all" checkbox is clicked, select/deselect all DUTs.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CheckBoxSelectAll_CheckedChanged(object sender, EventArgs e)
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
		/// When a DUT's type is changed, show relevant settings.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ComboBoxType_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Find the control's position.
			TableLayoutPanelCellPosition position = tableLayoutPanelDevicesUnderTest.GetPositionFromControl(((ComboBox)sender));

			// Remove any configuration controls previously added.
			tableLayoutPanelDevicesUnderTest.Controls.Remove(tableLayoutPanelDevicesUnderTest.GetControlFromPosition(DUT_COLUMN_CONFIG1, position.Row));
			tableLayoutPanelDevicesUnderTest.Controls.Remove(tableLayoutPanelDevicesUnderTest.GetControlFromPosition(DUT_COLUMN_CONFIG2, position.Row));

			// If the DUT is a G3...
			if ((((ComboBox)sender).SelectedItem.ToString().CompareTo("Sensit G3") == 0) ||
				(((ComboBox)sender).SelectedItem.ToString().CompareTo("Serial Device") == 0))
			{
				// Create a combobox for a serial port.
				ComboBox comboBox = new ComboBox
				{
					Name = "comboBoxSerialPort" + position.Row.ToString(),
					Anchor = AnchorStyles.Left | AnchorStyles.Top,
					Dock = DockStyle.None,
					DropDownStyle = ComboBoxStyle.DropDownList
				};
				tableLayoutPanelDevicesUnderTest.Controls.Add(comboBox, DUT_COLUMN_CONFIG1, position.Row);

				// Add all available serial ports as options in the text box.
				foreach (string s in SerialPort.GetPortNames())
				{
					comboBox.Items.Add(s);
				}
			}

			if (((ComboBox)sender).SelectedItem.ToString().CompareTo("Serial Device") == 0)
			{
				// Create a text box for prompt to send to device.
				TextBox textBox = new TextBox
				{
					Name = "textBoxSerialPrompt" + position.Row.ToString(),
					Anchor = AnchorStyles.Left | AnchorStyles.Top,
					Dock = DockStyle.None,
				};
				tableLayoutPanelDevicesUnderTest.Controls.Add(textBox, DUT_COLUMN_CONFIG2, position.Row);
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

			// Remove all DUT controls.
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
		/// When Edit --> Number of DUTs is selected, prompt the user to select the number of DUTS.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NumberOfDUTsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Prompt user to enter desired number of DUTs (current value as default).
			int numDuts = NumDuts;
			DialogResult result = InputDialog.Numeric("Number of DUTs", ref numDuts, 1, 24);

			// If the user clicks "OK"...
			if (result == DialogResult.OK)
			{
				// Update the property (which will also update the form).
				NumDuts = numDuts;
			}
		}

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
		/// When Tools --> DUT Settings menu is clicked, open an object browser for the settings.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DUTSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//EditSettings<DutSettings>(Properties.Settings.Default.DutSettingsFile);
		}

		/// <summary>
		/// When Tools --> Test Settings menu is clicked, open an object browser for the settings.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TestSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
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
			comboBoxModel.Enabled = true;
			numericUpDownRange.Enabled = true;
			numericUpDownFlowRate.Enabled = true;
			comboBoxTest.Enabled = true;
			checkBoxSelectAll.Enabled = true;
			radioButtonRepeatNo.Enabled = true;
			radioButtonRepeatYes.Enabled = true;
			foreach (Control c in tableLayoutPanelDevicesUnderTest.Controls)
			{
				c.Enabled = true;
			}

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

		public void SetDutStatus(uint dut, DutStatus status)
		{
			// Find the applicable DUT status textbox.
			// Remember that table layout panel has 0-based index, while DUTs have 1-based index.
			Label labelStatus = tableLayoutPanelDevicesUnderTest.GetControlFromPosition(DUT_COLUMN_STATUS, (int)dut - 1) as Label;

			// If called from a different thread than the form, invoke the method on the form's thread.
			// https://stackoverflow.com/questions/142003/cross-thread-operation-not-valid-control-accessed-from-a-thread-other-than-the
			if (labelStatus.InvokeRequired)
			{
				labelStatus.Invoke(new MethodInvoker(delegate { SetDutStatus(dut, status); }));
			}
			else
			{
				// Set the status text, and use bold text.
				labelStatus.Text = status.GetDescription();
				labelStatus.Font = new Font(labelStatus.Font, FontStyle.Bold);

				// Apply formatting.
				switch (status)
				{
					case DutStatus.Done:
						labelStatus.ForeColor = Color.Green;
						break;
					case DutStatus.Testing:
						labelStatus.ForeColor = Color.Blue;
						break;
					case DutStatus.Fail:
					case DutStatus.NotFound:
					case DutStatus.PortError:
						labelStatus.ForeColor = Color.Red;
						break;
				}
			}
		}

		public void SetDutSerialNumber(uint dut, string serialNumber)
		{
			// Find the applicable DUT serial number textbox.
			TextBox textBoxSerialNumber = tableLayoutPanelDevicesUnderTest.GetControlFromPosition(DUT_COLUMN_SERIALNUM, (int)dut - 1) as TextBox;

			// If called from a different thread than the form, invoke the method on the form's thread.
			if (textBoxSerialNumber.InvokeRequired)
			{
				textBoxSerialNumber.Invoke(new MethodInvoker(delegate { SetDutSerialNumber(dut, serialNumber); }));
			}
			else
			{
				// Set the text.
				textBoxSerialNumber.Text = serialNumber;
			}
		}

		#endregion
	}
}
