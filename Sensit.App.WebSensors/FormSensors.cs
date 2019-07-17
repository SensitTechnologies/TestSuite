using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Sensit.TestSDK.Forms;
using Sensit.TestSDK.Interfaces;
using Sensit.TestSDK.Utilities;

namespace Sensit.App.WebSensors
{
	/// <summary>
	/// GUI operations and settings access are handled here.
	/// </summary>
	public partial class FormSensors : Form
	{
		#region Fields

		// allow the form to wait for sensor readings to cancel/complete before closing application
		private bool _closeAfterStop = false;

		// Object to represent sensors.
		private List<Sensor> _sensors = new List<Sensor>();

		// Object to represent tests.
		private Test _test;

		#endregion

		#region Properties

		/// <summary>
		/// Number of sensors displayed in the application
		/// </summary>
		public int NumSensors
		{
			get => Properties.Settings.Default.NumSensors;
			set
			{
				Properties.Settings.Default.NumSensors = value;

				// Stop the GUI from looking weird while we update it.
				tableLayoutPanelSensors.SuspendLayout();

				// Remove all DUT controls.
				for (int i = 0; i < tableLayoutPanelSensors.ColumnCount; i++)
				{
					for (int j = 0; j < tableLayoutPanelSensors.RowCount; j++)
					{
						Control control = tableLayoutPanelSensors.GetControlFromPosition(i, j);
						tableLayoutPanelSensors.Controls.Remove(control);
					}
				}

				// Set how many rows there should be.
				tableLayoutPanelSensors.RowCount = value;

				// Make all the rows autosize.
				foreach (RowStyle s in tableLayoutPanelSensors.RowStyles)
				{
					s.SizeType = SizeType.AutoSize;
				}

				// Create new DUT controls.
				for (int i = 1; i <= value; i++)
				{
					CheckBox checkBox = new CheckBox
					{
						Name = "checkBoxSelected" + i.ToString(),
						Text = "Sensor " + i.ToString(),
						AutoSize = true,
						Anchor = AnchorStyles.Left | AnchorStyles.Top,
						Dock = DockStyle.None,
						Visible = true
					};
					tableLayoutPanelSensors.Controls.Add(checkBox, 0, i - 1);

					TextBox textBoxSerialNumber = new TextBox
					{
						Name = "textBoxSerialNumber" + i.ToString(),
						Anchor = AnchorStyles.Left | AnchorStyles.Top,
						Dock = DockStyle.None,
						Visible = true
					};
					tableLayoutPanelSensors.Controls.Add(textBoxSerialNumber, 1, i - 1);

					Label labelStatus = new Label
					{
						Name = "labelStatus" + i.ToString(),
						AutoSize = true,
						Anchor = AnchorStyles.Left | AnchorStyles.Top,
						Dock = DockStyle.None,
						Visible = true
					};
					tableLayoutPanelSensors.Controls.Add(labelStatus, 2, i - 1);
				}

				// Make the GUI act normally again.
				tableLayoutPanelSensors.ResumeLayout();
			}
		}

		#endregion

		#region Constructor

		public FormSensors()
		{
			// Initialize the form.
			InitializeComponent();

			// Add version string to title bar.
			if (ApplicationDeployment.IsNetworkDeployed)
			{
				Text += " " + ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
			}

			// Set the number of sensors.
			NumSensors = Properties.Settings.Default.NumSensors;

			// Select the most recently used sensors.
			if (Properties.Settings.Default.SensorSelections != null)
			{
				List<string> list = Properties.Settings.Default.SensorSelections.Cast<string>().ToList();
				bool[] selections = list.Select(x => x == "true").ToArray();
				for (int i = 0; i < NumSensors; i++)
				{
					CheckBox checkBox = tableLayoutPanelSensors.GetControlFromPosition(0, i) as CheckBox;
					checkBox.Checked = selections[i];
				}
			}
		}

		#endregion

		#region Overview Tab

		/// <summary>
		/// When "Start" button is clicked, fetch settings, create equipment/test/DUTs, start test.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonStart_Click(object sender, EventArgs e)
		{
			try
			{
				// Delete sensor tabs (if they exist) and any data on them.
				DestroySensorTabs();

				// Disable most of the user controls.
				checkBoxSelectAll.Enabled = false;
				foreach (Control c in tableLayoutPanelSensors.Controls)
				{
					c.Enabled = false;
				}
				buttonStop.Enabled = true;
				buttonStart.Enabled = false;

				// Create test object (which contains its own thread to poll sensors from).
				_test = new Test(_sensors)
				{
					Finished = TestFinished,
					Update = TestUpdate
				};

				for (uint i = 0; i < NumSensors; i++)
				{
					// Fetch user settings for the sensor.
					CheckBox checkBox = tableLayoutPanelSensors.GetControlFromPosition(0, (int)i) as CheckBox;
					TextBox textBox = tableLayoutPanelSensors.GetControlFromPosition(1, (int)i) as TextBox;

					// If the sensor is selected...
					if (checkBox.Checked)
					{
						// Create a sensor object to keep track of data we get.
						Sensor sensor = new Sensor()
						{
							Description = textBox.Text,
							Status = SensorStatus.Offline,
						};
						_sensors.Add(sensor);

						// Create a new tab for sensor data.
						CreateSensorTab("Sensor" + (i + 1).ToString(), "Sensor " + (i + 1).ToString());
					}
				}

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
		private void buttonStop_Click(object sender, EventArgs e)
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
					_closeAfterStop = true;
				}
			}

			// Initialize or clear sensor selections.
			if (Properties.Settings.Default.SensorSelections == null)
			{
				Properties.Settings.Default.SensorSelections = new System.Collections.Specialized.StringCollection();
			}
			else
			{
				Properties.Settings.Default.SensorSelections.Clear();
			}

			// Remember DUT selections.
			for (int i = 0; i < NumSensors; i++)
			{
				CheckBox checkBox = tableLayoutPanelSensors.GetControlFromPosition(0, i) as CheckBox;
				Properties.Settings.Default.SensorSelections.Add(checkBox.Checked ? "true" : "false");
			}

			// Save settings.
			Properties.Settings.Default.Save();
		}

		/// <summary>
		/// When "Select/deselect all" checkbox is clicked, select/deselect all DUTs.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void checkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
		{
			// Look through each control.
			foreach (Control c in tableLayoutPanelSensors.Controls)
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

		#endregion

		#region Sensor Tabs

		private void DestroySensorTabs()
		{
			// For each tab page in the form (except the first one)...
			for (int i = 1; i < tabControlSensors.TabPages.Count; i++)
			{
				// Remove the tab.
				tabControlSensors.TabPages.Remove(tabControlSensors.TabPages[i]);
			}
		}

		private void CreateSensorTab(string key, string name)
		{
			// Create a new tab page.
			TabPage tp = new TabPage(name);

			// Create some dummy data.
			double[] array = { 2.8, 4.4, 6.5, 8.3, 3.6, 5.6, 7.3, 9.2, 1.0 };

			// Add a chart.
			Chart c = new Chart();
			c.Series["Series 1"].Points.DataBindY(array);
			tp.Controls.Add(c);

			// Add the tab page to the tab control.
			tabControlSensors.TabPages.Add(key, name);
		}

		#endregion

		#region File Menu

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

		#endregion

		#region Settings Menu

		/// <summary>
		/// When Edit --> Number of Sensors is selected, prompt the user to select the number of sensors.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NumberOfSensorsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Prompt user to enter desired number of DUTs (current value as default).
			int numSensors = NumSensors;
			DialogResult result = InputDialog.Numeric("Number of Sensors", ref numSensors, 1, 24);

			if (result == DialogResult.OK)
			{
				// Update the property (which will also update the form).
				NumSensors = numSensors;
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

		#endregion

		#region Help Menu

		/// <summary>
		/// When the user clicks Help --> About, show an about box.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Create an about box.
			FormAbout formAbout = new FormAbout();

			// Show the about box.
			// ShowDialog() disables interaction with the app's other forms.
			// Show() does not.
			formAbout.ShowDialog();
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
		}

		/// <summary>
		/// Reset the form after a test is completed or cancelled.
		/// </summary>
		public void TestFinished()
		{
			// Enable most of the controls.
			checkBoxSelectAll.Enabled = true;
			foreach (Control c in tableLayoutPanelSensors.Controls)
			{
				c.Enabled = true;
			}

			// Enable the "Start" button and disable the "Stop" button.
			buttonStart.Enabled = true;
			buttonStop.Enabled = false;

			// If requested, close the application.
			if (_closeAfterStop)
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
			Label labelStatus = tableLayoutPanelSensors.GetControlFromPosition(2, (int)dut - 1) as Label;

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
					case DutStatus.Pass:
						labelStatus.ForeColor = Color.Green;
						break;
					case DutStatus.Found:
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

		public void SetDescription(uint sensor, string description)
		{
			// Find the applicable DUT description textbox.
			TextBox textBox = tableLayoutPanelSensors.GetControlFromPosition(1, (int)sensor - 1) as TextBox;

			// If called from a different thread than the form, invoke the method on the form's thread.
			if (textBox.InvokeRequired)
			{
				textBox.Invoke(new MethodInvoker(delegate { SetDescription(sensor, description); }));
			}
			else
			{
				// Set the text.
				textBox.Text = description;
			}
		}

		#endregion
	}
}
