using System;
using System.Windows.Forms;

namespace Sensit.TestSDK.Forms
{
	public partial class FormCalibration : Form
	{
		public Action Start;    // delegate that will run when the "Start" button is clicked
		public Action Stop;     // delegate that will run when the "Stop" button is clicked
		public Action Pause;    // delegate that will run to pause a test
		public Func<bool> Running;	// delegate to see if a test is running
		public Action Print;    // deletate that will run when the "Print" button is clicked

		private int _numDuts = 1;

		public int NumDuts
		{
			get { return _numDuts; }
			set
			{
				_numDuts = value;

				// Remove all DUT controls.
				foreach (Control c in tableLayoutPanelDevicesUnderTest.Controls)
				{
					tableLayoutPanelDevicesUnderTest.Controls.Remove(c);
				}

				// Set how many rows there should be.
				tableLayoutPanelDevicesUnderTest.RowCount = value;

				// Create new DUT controls.
				for (int i = 1; i < value; i++)
				{
					CheckBox checkBox = new CheckBox();
					checkBox.Name = "checkBoxDut" + i.ToString();
					checkBox.Text = "DUT" + i.ToString();
					checkBox.AutoSize = true;
					tableLayoutPanelDevicesUnderTest.Controls.Add(checkBox, 0, i);

					ComboBox comboBox = new ComboBox();
					comboBox.Name = "comboBoxDut" + i.ToString();
					tableLayoutPanelDevicesUnderTest.Controls.Add(comboBox, 1, i);

					TextBox textBox = new TextBox();
					textBox.Name = "textBoxDut" + i.ToString();
					tableLayoutPanelDevicesUnderTest.Controls.Add(textBox, 2, i);
				}
			}
		}

		public FormCalibration(int duts = 1)
		{
			InitializeComponent();

			// Set the amount of DUTs.
			NumDuts = duts;
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

		/// <summary>
		/// When File --> Exit menu item is clicked, close the application.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
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
			DialogResult result = DialogResult.OK;  // whether to quit or not

			// If the Running delegate exists and a test is running...
			if ((Running != null) && Running())
			{
				// Ask the user if they really want to stop the test.
				result = MessageBox.Show("Abort the test?", "Abort", MessageBoxButtons.OKCancel);
			}

			// If we're quitting...
			if (result == DialogResult.OK)
			{
				try
				{
					// Stop any active tests.
					Stop();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error");
				}
			}
			else
			{
				// Cancel application shutdown.
				e.Cancel = true;
			}
		}

		private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void numberOfDUTsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Prompt user to enter desired number of DUTs (current value as default).
			int numDuts = NumDuts;
			DialogResult result = InputDialog.Show("Number of DUTs", ref numDuts, 1, 12);

			// Set the number of DUTs.
			NumDuts = numDuts;
		}
	}
}
