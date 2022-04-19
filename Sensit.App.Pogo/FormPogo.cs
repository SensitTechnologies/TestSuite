using System.Globalization;

namespace Sensit.App.Pogo
{
	/// <summary>
	/// GUI operations and settings access are handled here.
	/// </summary>
	public partial class FormPogo : Form
	{
		#region Fields

		// allow the form to wait for tests to cancel/complete before closing appliction
		private bool _closeAfterTest = false;

		// test equipment
		private Equipment _equipment;

		// tests
		private Test _test;

		// number of completed events in currently running test
		private uint _eventsComplete;

		// flag set if there are unsaved changes to test settings
		private bool _unsaved = false;

		#endregion

		#region Constructor

		public FormPogo()
		{
			// Initialize the form.
			InitializeComponent();

			// TODO:  Select previously used options from Properties.Settings.Default.
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
		/// Before closing, check the user's wishes and safely end testing.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormPogo_FormClosing(object sender, FormClosingEventArgs e)
		{
			// If a test exists and is running...
			if ((_test != null) && _test.IsBusy)
			{
				// Cancel application shutdown.
				e.Cancel = true;

				// If the user choooses to abort the test...
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

		#region Start, Stop, Pause Controls

		private void ButtonStart_Click(object sender, EventArgs e)
		{
			try
			{
				// Disable most of the user controls.
				SetControlEnable(true);

				// TODO:  Create a test setting object and populate it based on the user's choices.
				TestSetting testSetting = CreateTestSettings();

				// Create an equipment object and populate it with the user's choices.
				_equipment = new Equipment(testSetting.Devices);

				// Create a test object and link its actions to actions on this form.
				// https://syncor.blogspot.com/2010/11/passing-getter-and-setter-of-c-property.html
				_test = new Test(testSettings.Events)
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));

				SetControlEnable(false);
			}
		}

		private void ButtonStop_Click(object sender, EventArgs e)
		{

		}

		private void PauseToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		#endregion

		private void NewToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void StartToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void StopToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void SupportToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void FormPogo_DragDrop(object sender, DragEventArgs e)
		{

		}

		/// <summary>
		/// When the user drags a settings file onto the app, load the test profile.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormPogo_DragEnter(object sender, DragEventArgs e)
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

		}

		#region Helper Methods

		/// <summary>
		/// Enable/disable user controls based on whether test is being run.
		/// </summary>
		/// <param name="testInProgress">true if test is in progress; false otherwise</param>
		private void SetControlEnable(bool testInProgress)
		{
			// Buttons
			buttonStart.Enabled = !testInProgress;
			buttonStop.Enabled = testInProgress;

			// Menu items
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
			if ((_test != null) && _test.IsBusy)
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
	}
}