using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Sensit.TestSDK.Files;

namespace Sensit.App.Datalogger
{
	public partial class FormLog : Form
	{
		// timer to control when we take samples from the DUT
		private System.Timers.Timer _timer;

		// CSV file writer to log data captured from DUT
		private CsvWriter _writer;

		// number of samples logged
		private ulong _samples;

		/// <summary>
		/// Flag to tell if we're logging or not.
		/// </summary>
		/// <remarks>
		/// Has 3 states:  2 = stopped; 1 = running; 0 = idle.
		/// Initialized to "stopped" state.
		/// </remarks>
		private int _logging = 2;

		// This is a thread synchronizeation event handler; it makes us wait until the
		// timer finishes its current task before closing the resources it's using.
		EventWaitHandle _loggingLock = new EventWaitHandle(false, EventResetMode.AutoReset);

		/// <summary>
		/// Constructor
		/// </summary>
		public FormLog()
		{
			// Initialize the form.
			InitializeComponent();

			// Recall the most recently used log file.
			textBoxFilename.Text = Properties.Settings.Default.Filename;

			// Find all available serial ports.
			foreach (string s in SerialPort.GetPortNames())
			{
				comboBoxSerialPort.Items.Add(s);
			}

			// Select the most recently used serial port.
			comboBoxSerialPort.Text = Properties.Settings.Default.Port;

			// Instantiate the timer and set the most recent interval.
			_timer = new System.Timers.Timer(Properties.Settings.Default.Interval);

			// Set the method which runs when the timer elapses.
			_timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

			// We need to wait until one event is done to try another one.
			_timer.AutoReset = false;
		}

		private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Exit the program.
			Application.Exit();
		}

		/// <summary>
		/// When the "Browse" button is clicked, show a filebrowser.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonBrowse_Click(object sender, EventArgs e)
		{
			// Create a file browser.
			OpenFileDialog openFileDialog = new OpenFileDialog()
			{
				InitialDirectory = textBoxFilename.Text,
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
				textBoxFilename.Text = openFileDialog.FileName;

				// Remember it for next time.
				Properties.Settings.Default.Filename = openFileDialog.FileName;
			}
		}

		/// <summary>
		/// Before exiting, check the user's wishes and safely end testing.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormLog_FormClosing(object sender, FormClosingEventArgs e)
		{
			// Stop the logging operation.
			StopLogging();

			// Save settings.
			Properties.Settings.Default.Save();
		}

		private void ButtonStart_Click(object sender, EventArgs e)
		{
			// Toggle the logging process (by enabling/disabling the timer which does the logging).
			if (_logging != 2)
			{
				StopLogging();
			}
			else
			{
				StartLogging();
			}
		}

		private void ButtonStop_Click(object sender, EventArgs e)
		{
			// TODO:  Split up the start and stop buttons.
		}

		private void ComboBoxSerialPort_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Save the serial port number to the application settings file.
			Properties.Settings.Default.Port = comboBoxSerialPort.Text;
		}

		private void NumericUpDownInterval_ValueChanged(object sender, EventArgs e)
		{
			// Set the timer's interval property (which controls how often samples are taken).
			_timer.Interval = decimal.ToDouble(numericUpDownInterval.Value);
		}

		private void OnTimedEvent(object source, ElapsedEventArgs e)
		{
			// If logging = 0 "idle", set logging = 1 "running"
			// but don't let another thread change logging at the same time.
			// If logging was not 0 "idle", don't do anything.
			if (Interlocked.CompareExchange(ref _logging, 1, 0) != 0)
			{
				return;
			}

			try
			{
				// TODO:  Fetch a value from the DUT.
				string sample = string.Empty;
				int status = 0;
				// status = _dut.GetSample(out sample);

				// If we can't talk to the DUT, notify the user (but leave the timer on).
				if (status == 1)
				{
					MessageBox.Show("Communication timeout.  No sample to log :(", "ERROR");
				}
				else
				{
					// Display the sample value to the user.
					// Use a method invoker because it needs to happen in the Form's thread.
					// It must be asynchronous (BeginInvoke, not Invoke) or else the two
					// threads might get stuck waiting for each other).
					BeginInvoke(new Action(() => textBoxResponse.Text = sample));

					// Log a timestamp and the sample value to a CSV file.
					List<string> row = new List<string>();
					row.Add(e.SignalTime.ToString());
					row.Add(sample);
					_writer.WriteRow(row);

					// Update the status message.
					_samples++;
					toolStripStatusLabel1.Text = "Logged " + _samples + " samples.";
				}

				// Start the timer again.
				_timer.Enabled = true;
			}
			// If an error occurs...
			catch (Exception ex)
			{
				// Notify the user.
				MessageBox.Show(ex.Message, "ERROR");

				// Stop logging.
				// Use a method invoker because it needs to happen in the form's thread.
				BeginInvoke(new Action(StopLogging));
			}

			// Set timer to "Idle" state and broadcast that we've finished executing.
			_logging = 0;
			_loggingLock.Set();
		}

		private void StopLogging()
		{
			// Don't do anything if logging is already in "stopped" state.
			// Otherwise it will get stuck in the WaitOne loop.
			if (_logging != 2)
			{
				// Ensure timer is in "idle" state before stopping it.
				// If logging = 0 "idle", set logging = 2 "stopped"
				// but don't let another thrad change logging at the same time.
				// If logging was not 0 "idle", wait until it is.
				while (Interlocked.CompareExchange(ref _logging, 2, 0) != 0)
				{
					_loggingLock.WaitOne();
				}

				try
				{
					// Disable the timer.
					_timer.Enabled = false;

					// Close the filestream if necessary.
					_writer?.Close();

					// TODO:  Close the DUT serial port.

					// Update GUI.
					toolStripStatusLabel1.Text = "Ready...";
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "ERROR");
				}
			}
		}

		private void StartLogging()
		{
			try
			{
				// Update GUI.
				toolStripStatusLabel1.Text = "Logging data...";

				// TODO:  Open the DUT serial port if necessary.

				// Set up the CSV file writer filestream.
				_writer = new CsvWriter(Properties.Settings.Default.Filename, true);

				// Start the timer.
				_timer.Enabled = true;

				// Set logging state to 0 "idle".
			}
			// If an error occurs...
			catch (Exception ex)
			{
				// Notify the user.
				MessageBox.Show(ex.Message, "ERROR");

				// Undo whatever was started.
				StopLogging();
			}
		}
	}
}
