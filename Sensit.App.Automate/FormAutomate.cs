using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Diagnostics;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using Sensit.TestSDK.Exceptions;
using Sensit.TestSDK.Forms;
using Sensit.TestSDK.Interfaces;
using Sensit.TestSDK.Settings;
using Sensit.TestSDK.Utilities;

namespace Sensit.App.Automate
{
	/// <summary>
	/// GUI operations and settings access are handled here.
	/// </summary>
	public partial class FormAutomate : Form
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

		// test equipment
		private Equipment _equipment;

		// tests
		private Test _test;

		// organized list of variable-related controls that are updated during a test
		private readonly Dictionary<(string, VariableType), UserControlVariableStatus> _variableStatusControls =
			new Dictionary<(string, VariableType), UserControlVariableStatus>();

		// Number of completed events in currently running test
		private uint _eventsComplete;

		// flag set if there are unsaved changes to test settings
		private bool _unsaved = false;

		#endregion

		#region Constructor

		public FormAutomate()
		{
			// Initialize the form.
			InitializeComponent();

			// List the control devices in the form, and select the first one.
			List<Type> deviceTypes = Utilities.FindClasses(typeof(IDevice));
			foreach (Type deviceType in deviceTypes)
			{
				comboBoxDeviceType.Items.Add(deviceType.GetDisplayName());
			}
			comboBoxDeviceType.SelectedIndex = 0;

			// List the variable types in the form, and select the first one.
			foreach (VariableType v in (VariableType[])Enum.GetValues(typeof(VariableType)))
			{
				comboBoxEventVariable.Items.Add(v.GetDescription());
			}
			comboBoxEventVariable.SelectedIndex = 0;

			// Select the most recently used termination option.
			radioButtonRepeatYes.Checked = Properties.Settings.Default.Repeat;
			radioButtonRepeatNo.Checked = !Properties.Settings.Default.Repeat;

			// Select the most recently used logfile.
			textBoxLogFilename.Text = Properties.Settings.Default.Logfile;
		}

		#endregion

		#region Exit Methods

		/// <summary>
		/// When File --> Exit menu item is clicked, close the application.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
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
		private void FormAutomate_FormClosing(object sender, FormClosingEventArgs e)
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

			// If there are unsaved changes to test settings...
			DialogResult result = DialogResult.No;
			if (_unsaved)
			{
				result = MessageBox.Show("Save your changes?", "Unsaved changes", MessageBoxButtons.YesNoCancel);
			}

			switch (result)
			{
				// If the user chooses to save changes, show the save dialog.
				case DialogResult.Yes:
					SaveAsToolStripMenuItem_Click(sender, e);
					break;

				// If the user chooses to cancel, cancel application shutdown.
				case DialogResult.Cancel:
					e.Cancel = true;
					break;

				// If the user chooses to discard changes, do nothing (and the app will close).
			}

			// Save settings.
			Properties.Settings.Default.Save();
		}

		#endregion

		#region Start, Stop, Pause, Repeat Controls

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

				// Create a test settings object and populate it with the user's choices.
				TestSetting testSetting = CreateTestSettings();

				// Create an equipment object and populate it with the user's choices.
				_equipment = new Equipment(testSetting.Devices);

				// Create a test object and link its actions to actions on this form.
				// https://syncor.blogspot.com/2010/11/passing-getter-and-setter-of-c-property.html
				_test = new Test(testSetting.Events, _equipment, textBoxLogFilename.Text)
				{
					Finished = TestFinished,
					UpdateProgress = TestUpdate,
					Repeat = Properties.Settings.Default.Repeat
				};

				// Remove all variables from "Status" tab and from the list of variable controls.
				flowLayoutPanelControlledVariables.Controls.Clear();
				foreach (UserControlVariableStatus c in _variableStatusControls.Values)
				{
					c.Dispose();
				}
				_variableStatusControls.Clear();

				// Add variables to "Status" tab.
				foreach (KeyValuePair<string, IDevice> device in _equipment.Devices)
				{
					foreach (VariableType setpoint in device.Value.Setpoints.Keys)
					{
						// Create a new control for the variable.
						UserControlVariableStatus userControlVariableStatus = new UserControlVariableStatus
						{
							Title = device.Key + " " + setpoint,
							UnitOfMeasure = "",
							Value = 0.0M,
							Setpoint = 0.0M,
							Tolerance = 0.0M
						};

						// Keep a reference to it in a dictionary.
						_variableStatusControls.Add((device.Key, setpoint), userControlVariableStatus);

						// Add the control to the form.
						flowLayoutPanelControlledVariables.Controls.Add(userControlVariableStatus);
					}
				}

				// Start the test.
				_test.Start();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));

				SetControlEnable(false);
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
		/// When Test --> Pause menu item is clicked, pause the test.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PauseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_test?.Pause();
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

				// If a test exists, update it with the new setting.
				if (_test != null)
				{
					_test.Repeat = Properties.Settings.Default.Repeat;
				}
			}
		}

		#endregion

		#region Devices and Events Tabs

		/// <summary>
		/// When the "Add Device" button is clicked, add the device to the device list panel.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonDeviceAdd_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(textBoxDeviceName.Text))
			{
				MessageBox.Show("Device name is empty!");
			}
			else
			{
				LayoutSuspend();

				// Add the device.
				AddDeviceToPanel(textBoxDeviceName.Text, comboBoxDeviceType.Text, "");

				LayoutResume();

				// Scroll to the bottom of the device's list so user can see the new device.
				panelDevices.VerticalScroll.Value = panelDevices.VerticalScroll.Maximum;

				// Remember there are unsaved changes.
				_unsaved = true;
			}
		}

		// TODO:  Remove these statements one by one until something slows down.
		private void LayoutSuspend()
		{
			// Stop the GUI from looking weird while we update it.
			tabControl.SuspendLayout();
			tabPageDevices.SuspendLayout();
			groupBoxDevices.SuspendLayout();
			tableLayoutPanelDevicesControls.SuspendLayout();
			tableLayoutPanelDevicesDelete.SuspendLayout();
			tableLayoutPanelDevicesAdd.SuspendLayout();
			panelDevices.SuspendLayout();
			tableLayoutPanelDevices.SuspendLayout();
			tabPageEvents.SuspendLayout();
			groupBoxEvents.SuspendLayout();
			tableLayoutPanelEventsControls.SuspendLayout();
			tableLayoutPanelEventsDelete.SuspendLayout();
			tableLayoutPanelEventsAdd.SuspendLayout();
			panelEvents.SuspendLayout();
			tableLayoutPanelEvents.SuspendLayout();
			tabPageLog.SuspendLayout();
			groupBoxLog.SuspendLayout();
			groupBoxFilename.SuspendLayout();
			tableLayoutPanelFilename.SuspendLayout();
			tabPageStatus.SuspendLayout();
			groupBoxVariables.SuspendLayout();
			statusStrip.SuspendLayout();
			menuStrip.SuspendLayout();
			tableLayoutPanelTest.SuspendLayout();
			tableLayoutPanelTestSetupButtons.SuspendLayout();
			tableLayoutPanelRepeat.SuspendLayout();
			tableLayoutPanelYesNo.SuspendLayout();
			tableLayoutPanelStartStop.SuspendLayout();
			SuspendLayout();
		}

		// TODO:  Remove these statements one by one until something slows down.
		private void LayoutResume()
		{
			// Make the GUI act normally again.
			tabControl.ResumeLayout();
			tabPageDevices.ResumeLayout();
			groupBoxDevices.ResumeLayout();
			tableLayoutPanelDevicesControls.ResumeLayout();
			tableLayoutPanelDevicesDelete.ResumeLayout();
			tableLayoutPanelDevicesAdd.ResumeLayout();
			panelDevices.ResumeLayout();
			tableLayoutPanelDevices.ResumeLayout();
			tabPageEvents.ResumeLayout();
			groupBoxEvents.ResumeLayout();
			tableLayoutPanelEventsControls.ResumeLayout();
			tableLayoutPanelEventsDelete.ResumeLayout();
			tableLayoutPanelEventsAdd.ResumeLayout();
			panelEvents.ResumeLayout();
			tableLayoutPanelEvents.ResumeLayout();
			tabPageLog.ResumeLayout();
			groupBoxLog.ResumeLayout();
			groupBoxFilename.ResumeLayout();
			tableLayoutPanelFilename.ResumeLayout();
			tabPageStatus.ResumeLayout();
			groupBoxVariables.ResumeLayout();
			statusStrip.ResumeLayout();
			menuStrip.ResumeLayout();
			tableLayoutPanelTest.ResumeLayout();
			tableLayoutPanelTestSetupButtons.ResumeLayout();
			tableLayoutPanelRepeat.ResumeLayout();
			tableLayoutPanelYesNo.ResumeLayout();
			tableLayoutPanelStartStop.ResumeLayout();
			ResumeLayout();
		}

		/// <summary>
		/// Add a device to the device list panel.
		/// </summary>
		/// <param name="name">unique identifier for the device</param>
		/// <param name="type">DisplayName of the class used for the device</param>
		/// <param name="port">serial port associated with the device</param>
		private void AddDeviceToPanel(string name, string type, string port)
		{
			// Add a new row to the table layout panel.
			tableLayoutPanelDevices.RowCount++;
			tableLayoutPanelDevices.RowStyles.Add(new RowStyle(SizeType.AutoSize));

			// Add a checkbox with the device's name.
			tableLayoutPanelDevices.Controls.Add(new CheckBox
			{
				AutoSize = true,
				Anchor = AnchorStyles.Left | AnchorStyles.Top,
				Dock = DockStyle.None,
				Text = name,
			}, COLUMN_DEVICES_NAME, tableLayoutPanelDevices.RowCount - 1);

			// Add the device type.
			tableLayoutPanelDevices.Controls.Add(new Label
			{
				Anchor = AnchorStyles.Left | AnchorStyles.Top,
				AutoSize = true,
				Dock = DockStyle.None,
				Text = type,
			}, COLUMN_DEVICES_TYPE, tableLayoutPanelDevices.RowCount - 1);

			// Add a comboBox for serial port.
			ComboBox comboBox = new ComboBox
			{
				Anchor = AnchorStyles.Left | AnchorStyles.Top,
				Dock = DockStyle.None,
				DropDownStyle = ComboBoxStyle.DropDownList
			};
			comboBox.Items.AddRange(SerialPort.GetPortNames());
			tableLayoutPanelDevices.Controls.Add(comboBox, COLUMN_DEVICES_PORT, tableLayoutPanelDevices.RowCount - 1);

			// Select previously used device serial port (if found).
			comboBox.SelectedIndex = comboBox.FindStringExact(port);

			// Add the device to the list of available devices on the "Events" tab.
			comboBoxEventDevice.Items.Add(name);
		}

		/// <summary>
		/// When the "Add Event" button is clicked, add the event to the event list panel.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonEventAdd_Click(object sender, EventArgs e)
		{
			LayoutSuspend();

			// Add a new event to the event list panel.
			AddEventToPanel(comboBoxEventDevice.Text, comboBoxEventVariable.Text, numericUpDownEventValue.Value, numericUpDownEventDuration.Value);

			LayoutResume();

			// Scroll to the bottom of the device's list so user can see the new device.
			panelEvents.VerticalScroll.Value = panelEvents.VerticalScroll.Maximum;

			// Remember there are unsaved changes.
			_unsaved = true;
		}

		/// <summary>
		/// Add an event to the event list panel.
		/// </summary>
		/// <param name="device">unique identifier for the device acted upon</param>
		/// <param name="variable">DisplayName of the variable acted upon</param>
		/// <param name="value">value to set the variable to</param>
		/// <param name="duration">time to wait before starting next event [seconds]</param>
		private void AddEventToPanel(string device, string variable, decimal value, decimal duration)
		{
			// Add a new row to the table layout panel.
			tableLayoutPanelEvents.RowCount++;
			tableLayoutPanelEvents.RowStyles.Add(new RowStyle(SizeType.AutoSize));

			// Add a checkbox with the event's name.
			tableLayoutPanelEvents.Controls.Add(new CheckBox
			{
				AutoSize = true,
				Anchor = AnchorStyles.Left | AnchorStyles.Top,
				Dock = DockStyle.None,
				Text = device,
			}, COLUMN_EVENTS_DEVICE, tableLayoutPanelEvents.RowCount - 1);

			// Add the variable.
			tableLayoutPanelEvents.Controls.Add(new Label
			{
				Anchor = AnchorStyles.Left | AnchorStyles.Top,
				AutoSize = true,
				Dock = DockStyle.None,
				Text = variable,
			}, COLUMN_EVENTS_VARIABLE, tableLayoutPanelEvents.RowCount - 1);

			// Add the variable's value.
			tableLayoutPanelEvents.Controls.Add(new TextBox
			{
				Anchor = AnchorStyles.Left | AnchorStyles.Top,
				AutoSize = true,
				Dock = DockStyle.None,
				Text = value.ToString(CultureInfo.InvariantCulture)
			}, COLUMN_EVENTS_VALUE, tableLayoutPanelEvents.RowCount - 1);

			// Add the duration.
			tableLayoutPanelEvents.Controls.Add(new TextBox
			{
				Anchor = AnchorStyles.Left | AnchorStyles.Top,
				AutoSize = true,
				Dock = DockStyle.None,
				Text = duration.ToString(CultureInfo.InvariantCulture)
			}, COLUMN_EVENTS_DURATION, tableLayoutPanelEvents.RowCount - 1);

			// Add the status.
			tableLayoutPanelEvents.Controls.Add(new Label
			{
				Anchor = AnchorStyles.Left | AnchorStyles.Top,
				AutoSize = true,
				Dock = DockStyle.None,
			}, COLUMN_EVENTS_STATUS, tableLayoutPanelEvents.RowCount - 1);
		}

		/// <summary>
		/// When the "Select All" checkbox on the Devices tab is clicked, either
		/// select or unselect all the devices shown.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CheckBoxDeviceSelectAll_CheckedChanged(object sender, EventArgs e)
		{
			foreach (CheckBox c in tableLayoutPanelDevices.Controls.OfType<CheckBox>())
			{
				c.Checked = ((CheckBox)sender).Checked;
			}
		}

		/// <summary>
		/// When the "Select All" checkbox on the Events tab is clicked, either
		/// select or unselect all the events shown.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CheckBoxEventSelectAll_CheckedChanged(object sender, EventArgs e)
		{
			foreach (CheckBox c in tableLayoutPanelEvents.Controls.OfType<CheckBox>())
			{
				c.Checked = ((CheckBox)sender).Checked;
			}
		}

		/// <summary>
		/// When the "Delete Selected" button on the Device tab is clicked,
		/// delete all selected devices.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonDeviceDelete_Click(object sender, EventArgs e)
		{
			LayoutSuspend();

			// Hunt backwards for checked boxes or we'll miss the last one selected.
			for (int row = tableLayoutPanelDevices.RowCount - 1; row >= 0; row--)
			{
				Control c = tableLayoutPanelDevices.GetControlFromPosition(0, row);
				if ((c is CheckBox box) && (box.Checked))
				{
					// Remove the controls in the row.
					Utilities.TableLayoutPanelRemoveRow(tableLayoutPanelDevices, row);

					// Remove the option from the "Events" tab.
					comboBoxEventDevice.Items.Remove(c.Text);

					// Remember there are unsaved changes.
					_unsaved = true;
				}
			}

			// Uncheck the checkbox.
			checkBoxDeviceSelectAll.Checked = false;

			LayoutResume();
		}

		/// <summary>
		/// When the "Delete Selected" button on the Events tab is clicked,
		/// delete all selected events.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonEventDelete_Click(object sender, EventArgs e)
		{
			LayoutSuspend();

			// Hunt backwards for checked items or we'll miss the last one selected.
			for (int row = tableLayoutPanelEvents.RowCount - 1; row >= 0; row--)
			{
				Control c = tableLayoutPanelEvents.GetControlFromPosition(0, row);
				if ((c is CheckBox box) && (box.Checked))
				{
					// Remove the controls in the row.
					Utilities.TableLayoutPanelRemoveRow(tableLayoutPanelEvents, row);

					// Remember there are unsaved changes.
					_unsaved = true;
				}
			}

			// Uncheck the checkbox.
			checkBoxEventSelectAll.Checked = false;

			LayoutResume();
		}

		#endregion

		#region Log Tab

		/// <summary>
		/// When the "Browse" button on the Log tab is clicked, allow the user to specify a file.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonLogBrowse_Click(object sender, EventArgs e)
		{
			// Create a file browser.
			OpenFileDialog openFileDialog = new OpenFileDialog()
			{
				InitialDirectory = textBoxLogFilename.Text,
				Title = "Browse Log Files",
				CheckFileExists = false,
				CheckPathExists = true,
				DefaultExt = "csv",
				Filter = "txt files (*.txt)|*.txt|csv files (*.csv)|*.csv|All files (*.*)|*.*",
				FilterIndex = 2,
			};

			// Show the dialog box to the user.
			// If the user selects a file...
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				// Use that file.
				textBoxLogFilename.Text = openFileDialog.FileName;

				// Remember it for next time.
				Properties.Settings.Default.Logfile = openFileDialog.FileName;
			}

			// Clean up.
			openFileDialog.Dispose();
		}

		/// <summary>
		/// When the log file name is edited, remember the user's edit.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TextBoxLogFilename_TextChanged(object sender, EventArgs e)
		{
			// Remember logfile name.
			Properties.Settings.Default.Logfile = textBoxLogFilename.Text;
		}

		#endregion

		#region File Operations

		private void NewToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// If there are unsaved changes...
			DialogResult dialogResult = DialogResult.No;
			if (_unsaved)
			{
				dialogResult = MessageBox.Show("Save your changes?", "Unsaved changes", MessageBoxButtons.YesNoCancel);
			}

			switch (dialogResult)
			{
				// If the user chooses to save changes, show the save dialog, then clear the form.
				case DialogResult.Yes:
					SaveAsToolStripMenuItem_Click(sender, e);
					ClearTestSettings();
					break;

				// If the user chooses to discard changes, clear the form.
				case DialogResult.No:
					ClearTestSettings();
					break;

				// If the user chooses to cancel, do nothing.
			}
		}

		private void ClearTestSettings()
		{
			LayoutSuspend();

			// Remove all devices.
			Utilities.TableLayoutPanelClear(tableLayoutPanelDevices);

			// Remove all events.
			Utilities.TableLayoutPanelClear(tableLayoutPanelEvents);

			// Remove all device choices from the "Events" tab.
			comboBoxEventDevice.Items.Clear();

			// Remember that there are no unsaved changes.
			_unsaved = false;

			LayoutResume();
		}

		private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// If there are unsaved changes...
			DialogResult result = DialogResult.No;
			if (_unsaved)
			{
				result = MessageBox.Show("Save your changes?", "Unsaved changes", MessageBoxButtons.YesNoCancel);
			}

			switch (result)
			{
				// If the user chooses to save changes, show the save dialog, then open a new test.
				case DialogResult.Yes:
					SaveAsToolStripMenuItem_Click(sender, e);
					break;

				// If the user chooses to discard changes, clear the form.
				case DialogResult.No:
					// Allow the user to select a filename.
					OpenFileDialog fileDialog = new OpenFileDialog();
					fileDialog.Filter = "XML-File|*.xml";
					fileDialog.Title = "Open test settings file";
					fileDialog.ShowDialog();

					OpenTestSettings(fileDialog.FileName);

					// Clean up.
					fileDialog.Dispose();
					break;

				// If the user chooses to cancel, do nothing.
			}
		}

		private void OpenTestSettings(string fileName)
		{
			// If a valid filename has been selected...
			if (!string.IsNullOrEmpty(fileName))
			{
				try
				{
					// Clear test settings.
					ClearTestSettings();

					// Load settings from file.
					TestSetting testSetting = Settings.Load<TestSetting>(fileName);

					// List the control devices in the form.
					List<Type> deviceTypes = Utilities.FindClasses(typeof(IDevice));

					LayoutSuspend();

					// Add each device to the form.
					foreach (DeviceSetting d in testSetting.Devices)
					{
						// Find the device type with the correct display name.
						Type deviceType = deviceTypes.FirstOrDefault(o => o.GetDisplayName() == d.Type);

						// Add device to "Devices" tab.
						AddDeviceToPanel(d.Name, deviceType.GetDisplayName(), d.SerialPort);
					}

					// Add each event to the form.
					foreach (EventSetting es in testSetting.Events)
					{
						AddEventToPanel(es.DeviceName, es.Variable.GetDescription(), es.Value, es.Duration);
					}

					LayoutResume();
				}
				catch (InvalidOperationException ex)
				{
					MessageBox.Show(ex.Message + Environment.NewLine + Environment.NewLine +
						"(This means the logfile you're trying to open is not formatted correctly.)",
						ex.GetType().Name.ToString(CultureInfo.CurrentCulture));
				}
			}

			// Remember that there are no unsaved changes.
			_unsaved = false;
		}

		private void FormAutomate_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.All;
			else
				e.Effect = DragDropEffects.None;
		}

		private void FormAutomate_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			foreach (string file in files)
			{
				// If there are unsaved changes...
				DialogResult result = DialogResult.No;
				if (_unsaved)
				{
					result = MessageBox.Show("Save your changes?", "Unsaved changes", MessageBoxButtons.YesNoCancel);
				}

				switch (result)
				{
					// If the user chooses to save changes, show the save dialog, then open a new test.
					case DialogResult.Yes:
						SaveAsToolStripMenuItem_Click(sender, e);
						break;

					// If the user chooses to discard changes, clear the form.
					case DialogResult.No:
						OpenTestSettings(file);
						break;

						// If the user chooses to cancel, do nothing.
				}
			}
		}

		private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Allow the user to select a filename.
			SaveFileDialog fileDialog = new SaveFileDialog
			{
				Filter = "XML-File|*.xml",
				Title = "Save test as"
			};
			fileDialog.ShowDialog();

			// If a valid filename has been selected...
			if (!string.IsNullOrEmpty(fileDialog.FileName))
			{
				try
				{
					// Create a new test settings object and populate it with the user's choices.
					TestSetting testSetting = CreateTestSettings();

					// Save to XML file.
					Settings.Save(testSetting, fileDialog.FileName);
				}
				catch (ArgumentException ex)
				{
					MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));
				}
				catch (FormatException ex)
				{
					MessageBox.Show("Can't save settings." + Environment.NewLine
						+ ex.Message + Environment.NewLine
						+ "Check events for a non-numeric Value or Duration.",
						ex.GetType().Name.ToString(CultureInfo.CurrentCulture));
				}
				catch (OverflowException ex)
				{
					MessageBox.Show("Can't save settings." + Environment.NewLine
						+ ex.Message + Environment.NewLine
						+ "Check the events for a number larger than a normal integer.",
						ex.GetType().Name.ToString(CultureInfo.CurrentCulture));
				}
				catch (TestException ex)
				{
					MessageBox.Show("Can't save settings." + Environment.NewLine
						+ ex.Message + Environment.NewLine,
						ex.GetType().Name.ToString(CultureInfo.CurrentCulture));
				}
			}

			// Clean up.
			fileDialog.Dispose();

			// Remember that there are no unsaved changes.
			_unsaved = false;
		}

		private TestSetting CreateTestSettings()
		{
			// Create a new test settings object.
			TestSetting testSetting = new TestSetting();

			// Add each device to the settings object.
			for (int row = 1; row < tableLayoutPanelDevices.RowCount; row++)
			{
				CheckBox checkBoxDeviceName = tableLayoutPanelDevices.GetControlFromPosition(COLUMN_DEVICES_NAME, row) as CheckBox;
				Label labelDeviceType = tableLayoutPanelDevices.GetControlFromPosition(COLUMN_DEVICES_TYPE, row) as Label;
				ComboBox comboBoxDevicePort = tableLayoutPanelDevices.GetControlFromPosition(COLUMN_DEVICES_PORT, row) as ComboBox;

				// If another device with the same name already exists...
				if (testSetting.Devices.FirstOrDefault(o => o.Name == checkBoxDeviceName.Text) != null)
				{
					// Let the user know.
					throw new TestException("Device " + checkBoxDeviceName.Text + " already exists." + Environment.NewLine +
						"Please use a unique name for each device.");
				}

				// List the control devices in the form.
				List<Type> deviceTypes = Utilities.FindClasses(typeof(IDevice));

				// Add the new device to settings.
				testSetting.Devices.Add(new DeviceSetting
				{
					Name = checkBoxDeviceName.Text,
					Type = labelDeviceType.Text,
					SerialPort = comboBoxDevicePort.Text
				});
			}

			// Add each event to the settings object.
			for (int row = 1; row < tableLayoutPanelEvents.RowCount; row++)
			{
				CheckBox checkBoxEventDevice = tableLayoutPanelEvents.GetControlFromPosition(COLUMN_EVENTS_DEVICE, row) as CheckBox;
				Label labelEventVariable = tableLayoutPanelEvents.GetControlFromPosition(COLUMN_EVENTS_VARIABLE, row) as Label;
				TextBox textBoxEventValue = tableLayoutPanelEvents.GetControlFromPosition(COLUMN_EVENTS_VALUE, row) as TextBox;
				TextBox textBoxEventDuration = tableLayoutPanelEvents.GetControlFromPosition(COLUMN_EVENTS_DURATION, row) as TextBox;

				// If the specified device does not exist...
				if (testSetting.Devices.FirstOrDefault(o => o.Name == checkBoxEventDevice.Text) == null)
				{
					// Alert the user.
					throw new TestException("Device " + checkBoxEventDevice.Text + " does not exist." + Environment.NewLine
						+ "Please either add that device, or remove events referencing it.");
				}

				// Convert the variable to the appropriate enumeration (and check that it's valid).
				try
				{
					VariableType variableType = Utilities.GetEnumValueFromDescription<VariableType>(labelEventVariable.Text);

					testSetting.Events.Add(new EventSetting
					{
						DeviceName = checkBoxEventDevice.Text,
						Variable = variableType,
						Value = Convert.ToDecimal(textBoxEventValue.Text, CultureInfo.InvariantCulture),
						Duration = Convert.ToUInt32(textBoxEventDuration.Text, CultureInfo.InvariantCulture)
					});
				}
				catch (ArgumentException ex)
				{
					throw new TestException("Unrecognized variable type in event " + row.ToString(CultureInfo.CurrentCulture), ex);
				}
			}

			return testSetting;
		}

		#endregion

		#region Help Menu

		/// <summary>
		/// When the user clicks Help --> Wiki, open a browser and navigate to the wiki page for this app.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SupportToolStripMenuItem_Click(object sender, EventArgs e)
		{
			const string wikiAddress = "https://github.com/SensitTechnologies/TestSuite/wiki/App:--Automated-Test-System";

			try
			{
				ProcessStartInfo processStartInfo = new ProcessStartInfo(wikiAddress);
				Process.Start(processStartInfo);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + Environment.NewLine +
					"I was trying to navigate to: " + wikiAddress + ".",
					ex.GetType().Name.ToString(CultureInfo.CurrentCulture));
			}
		}

		/// <summary>
		/// When the user clicks Help --> About, show an about box.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Create an about box.
			using (FormAbout formAbout = new FormAbout())
			{
				// Add version string to title bar.
				if (ApplicationDeployment.IsNetworkDeployed)
				{
					formAbout.Version = " " + ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
				}

				// Show the repository where this program can be found.
				// For the sake of future engineers.
				formAbout.Description +=
					Environment.NewLine +
					Environment.NewLine +
					"Source code can be found at:" +
					Environment.NewLine +
					"https://github.com/SensitTechnologies/TestSuite";

				// Show the about box.
				// ShowDialog() disables interaction with the app's other forms.
				// Show() does not.
				formAbout.ShowDialog();
			}
		}

		#endregion

		#region Status Tab, Progress Bar

		/// <summary>
		/// Update the status tab and progress bar with variable values and test status.
		/// </summary>
		/// <param name="message"></param>
		public void TestUpdate(int percent, string message)
		{
			// Stop the GUI from looking weird while we update it.
			flowLayoutPanelControlledVariables.SuspendLayout();

			// Update the progress bar.
			toolStripProgressBar.Value = percent;

			// Update the status message.
			toolStripStatusLabel.Text = message;

			// Update "Status" tab.
			for (int i = 0; i < _test.Variables.Count; i++)
			{
				(string name, VariableType variable) key = _test.Variables.ElementAt(i).Key;
				TestVariable value = _test.Variables.ElementAt(i).Value;

				// If the variable hasn't been displayed yet...
				if (_variableStatusControls.ContainsKey(key) == false)
				{
					// Create a new control for the variable.
					UserControlVariableStatus userControlVariableStatus = new UserControlVariableStatus
					{
						Title = key.name + " " + key.variable,
						UnitOfMeasure = "",
						Value = 0.0M,
						Setpoint = 0.0M,
						Tolerance = 0.0M
					};

					// Keep a reference to it in a dictionary.
					_variableStatusControls.Add(key, userControlVariableStatus);

					// Add the control to the form.
					flowLayoutPanelControlledVariables.Controls.Add(userControlVariableStatus);
				}

				_variableStatusControls[key].Value = value.Actual;
				_variableStatusControls[key].Setpoint = value.Setpoint;
				_variableStatusControls[key].Tolerance = value.Tolerance;
			}

			// If the number of complete events has been reset...
			if (_test.EventsComplete == 0)
			{
				// Reset event status.
				_eventsComplete = 0;
				for (int row = 1; row < tableLayoutPanelEvents.RowCount; row++)
				{
					Label labelStatus = tableLayoutPanelEvents.GetControlFromPosition(COLUMN_EVENTS_STATUS, row) as Label;
					labelStatus.Text = "Queued";
				}
			}
			// If the number of complete events has changed...
			else if (_eventsComplete != _test.EventsComplete)
			{
				// Remember how many events have been completed.
				_eventsComplete = _test.EventsComplete;

				// Update the status of the completed event.
				Label labelStatus = tableLayoutPanelEvents.GetControlFromPosition(COLUMN_EVENTS_STATUS, (int)_eventsComplete) as Label;
				labelStatus.Text = "Done";
			}

			// Make the GUI act normally again.
			flowLayoutPanelControlledVariables.ResumeLayout();
		}

		/// <summary>
		/// Reset the form after a test is completed or cancelled.
		/// </summary>
		public void TestFinished()
		{
			// Enable most of the controls.
			SetControlEnable(false);

			// Reset global variable.
			_eventsComplete = 0;

			// Dispose of managed resources.
			_equipment.Dispose();
			_test.Dispose();

			// If requested, close the application.
			if (_closeAfterTest)
			{
				Application.Exit();
			}

			// Update the progress bar.
			toolStripProgressBar.Value = 0;

			// Update the status message.
			toolStripStatusLabel.Text = "Ready...";
		}

		#endregion

		#region Helper Methods

		/// <summary>
		/// Enable/disable user controls based on whether is test is being run.
		/// </summary>
		/// <param name="testInProgress">true if test is in progress; false otherwise</param>
		private void SetControlEnable(bool testInProgress)
		{
			// Log file settings.
			groupBoxLog.Enabled = !testInProgress;

			// Device serial ports.
			for (int row = 1; row < tableLayoutPanelDevices.RowCount; row++)
			{
				ComboBox comboBoxDevicePort = tableLayoutPanelDevices.GetControlFromPosition(COLUMN_DEVICES_PORT, row) as ComboBox;
				comboBoxDevicePort.Enabled = !testInProgress;
			}

			// Buttons.
			buttonStart.Enabled = !testInProgress;
			buttonStop.Enabled = testInProgress;
			buttonDeviceAdd.Enabled = !testInProgress;
			buttonDeviceDelete.Enabled = !testInProgress;
			buttonEventAdd.Enabled = !testInProgress;
			buttonEventDelete.Enabled = !testInProgress;

			// Menu items.
			startToolStripMenuItem.Enabled = !testInProgress;
			pauseToolStripMenuItem.Enabled = testInProgress;
			stopToolStripMenuItem.Enabled = testInProgress;
			newToolStripMenuItem.Enabled = !testInProgress;
			openToolStripMenuItem.Enabled = !testInProgress;
			saveToolStripMenuItem.Enabled = !testInProgress;
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

			// If we're quitting, cancel a test (don't update GUI; the "TestFinished" method will do that).
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

		#endregion

		#region Tab and Mouse Helpers

		// used to make mouse/tab actions easier
		private bool _selectByMouse = false;

		/// <summary>
		/// If the user uses the Tab key to enter a numeric up/down control,
		/// highlight the value in the control to ease input of a new value.
		/// </summary>
		/// <remarks>
		/// Source:
		/// https://stackoverflow.com/questions/571074/how-to-select-all-text-in-winforms-numericupdown-upon-tab-in
		/// </remarks>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NumericUpDown_Enter(object sender, EventArgs e)
		{
			NumericUpDown curBox = sender as NumericUpDown;
			curBox.Select();
			curBox.Select(0, curBox.Text.Length);
			if (MouseButtons == MouseButtons.Left)
			{
				_selectByMouse = true;
			}
		}

		/// <summary>
		/// If the user uses the Tab key to enter a textbox,
		/// highlight the text in the control to ease input of a new string.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TextBox_Enter(object sender, EventArgs e)
		{
			TextBox textBox = sender as TextBox;
			textBox.SelectAll();
			if (MouseButtons == MouseButtons.Left)
			{
				_selectByMouse = true;
			}
		}

		/// <summary>
		/// If the user clicks on a numeric up/down control,
		/// highlight the value in the control to ease input of a new value.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NumericUpDown_MouseDown(object sender, MouseEventArgs e)
		{
			NumericUpDown curBox = sender as NumericUpDown;
			if (_selectByMouse)
			{
				curBox.Select(0, curBox.Text.Length);
				_selectByMouse = false;
			}
		}

		/// <summary>
		/// If a user clicks in a textbox,
		/// highlight the text in the control to ease input of a new string.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TextBox_MouseDown(object sender, MouseEventArgs e)
		{
			TextBox textBox = sender as TextBox;
			if (_selectByMouse)
			{
				textBox.SelectAll();
				_selectByMouse = false;
			}
		}

		#endregion
	}
}
