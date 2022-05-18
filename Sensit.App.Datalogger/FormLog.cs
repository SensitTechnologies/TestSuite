using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Sensit.TestSDK.Devices;
using Sensit.TestSDK.Files;

namespace Sensit.App.Datalogger
{
	public partial class FormLog : Form
	{
		// timer to control when we take samples from the DUT
		private readonly System.Timers.Timer _timer = new();

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
		readonly EventWaitHandle _loggingLock = new(false, EventResetMode.AutoReset);

		// generic serial device (send a message, get a response)
		private readonly GenericSerialDevice _genericSerialDevice = new();

		/// <summary>
		/// Constructor
		/// </summary>
		public FormLog()
		{
			// Initialize the form.
			InitializeComponent();

			// Populate available settings.
			comboBoxSerialPort.DataSource = SerialPort.GetPortNames();
			comboBoxBaudRate.DataSource = _genericSerialDevice.SupportedBaudRates;
			comboBoxDataBits.DataSource = _genericSerialDevice.SupportedDataBits;
			comboBoxParity.DataSource = Enum.GetNames(typeof(Parity));
			comboBoxStopBits.DataSource = Enum.GetNames(typeof(StopBits));
			comboBoxHandshake.DataSource = Enum.GetNames(typeof(Handshake));

			// Select the most recently used settings.
			textBoxFilename.Text = Properties.Settings.Default.Filename;
			comboBoxSerialPort.Text = Properties.Settings.Default.Port;
			comboBoxBaudRate.Text = Properties.Settings.Default.BaudRate.ToString();
			comboBoxDataBits.Text = Properties.Settings.Default.DataBits.ToString();
			comboBoxParity.Text = Properties.Settings.Default.Parity;
			comboBoxStopBits.Text = Properties.Settings.Default.StopBits;
			comboBoxHandshake.Text = Properties.Settings.Default.Handshake;
			textBoxCommand.Text = Properties.Settings.Default.Command;
			numericUpDownInterval.Value = Properties.Settings.Default.Interval;

			// When the filename is changed, save the new value.
			textBoxFilename.TextChanged += new ((sender, e) =>
			{
				Properties.Settings.Default.Filename = textBoxFilename.Text;
			});

			// When the serial port is changed, save the new value.
			comboBoxSerialPort.SelectedIndexChanged += new ((sender, e) =>
			{
				Properties.Settings.Default.Port = comboBoxSerialPort.Text;
			});

			comboBoxBaudRate.SelectedIndexChanged += ComboBoxBaudRate_SelectedIndexChanged;
			comboBoxDataBits.SelectedIndexChanged += ComboBoxDataBits_SelectedIndexChanged;

			// When the parity is changed, save the new value.
			comboBoxParity.SelectedIndexChanged += new ((sender, e) =>
			{
				Properties.Settings.Default.Parity = comboBoxParity.Text;
			});

			// When the number of stop bits is changed, save the new value.
			comboBoxStopBits.SelectedIndexChanged += new ((sender, e) =>
			{
				Properties.Settings.Default.StopBits = comboBoxStopBits.Text;
			});

			// When the handshaking mode is changed, save the new value.
			comboBoxHandshake.SelectedIndexChanged += new ((sender, e) =>
			{
				Properties.Settings.Default.Handshake = comboBoxHandshake.Text;
			});

			// When the selected logging interval is changed, save the new value.
			// Set the timer's interval property (which controls how often samples are taken).
			numericUpDownInterval.ValueChanged += new ((sender, e) =>
			{
				_timer.Interval = decimal.ToDouble(numericUpDownInterval.Value);
			});

			// Set the method which runs when the timer elapses.
			_timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

			// We need to wait until one event is done to try another one.
			_timer.AutoReset = false;
		}

		/// <summary>
		/// When the File --> Exit menu item is clicked, exit the program.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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
		/// When the baud rate is changed, save the new value.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ComboBoxBaudRate_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				// Save the new setting to the application settings file.
				Properties.Settings.Default.BaudRate = Convert.ToInt32(comboBoxBaudRate.Text);
			}
			catch (FormatException ex)
			{
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));
			}
			catch (OverflowException ex)
			{
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));
			}
		}

		/// <summary>
		/// When the number of data bits is changed, save the new value.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <exception cref="NotImplementedException"></exception>
		private void ComboBoxDataBits_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				// Save the new setting to the application settings file.
				Properties.Settings.Default.DataBits = Convert.ToInt32(comboBoxDataBits.Text);
			}
			catch (FormatException ex)
			{
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));
			}
			catch (OverflowException ex)
			{
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));
			}
		}

		private void ComboBoxParity_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Save the new setting to the application settings file.
			Properties.Settings.Default.Parity = comboBoxParity.Text;
		}

		/// <summary>
		/// When the command is changed, save the new value.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TextBoxCommand_TextChanged(object sender, EventArgs e)
		{
			// Save the new command to the application settings file.
			Properties.Settings.Default.Command = textBoxCommand.Text;
		}

		/// <summary>
		/// When the timer ticks, log a datum.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="e"></param>
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
				// Insert newline characters as requested.
				_genericSerialDevice.Command = textBoxCommand.Text.Replace("\\n", "\n").Replace("\\r", "\r").Replace("\\t", "\t");

				// Fetch a value from the DUT.
				_genericSerialDevice.WriteThenRead();
				string sample = _genericSerialDevice.Message;

				// Log a timestamp and the sample value to a CSV file.
				List<string> row = new List<string>();
				row.Add(e.SignalTime.ToString());
				row.Add(sample);
				_writer.WriteRow(row);

				// Use a method invoker to interact with the Form's thread.
				// It must be asynchronous (BeginInvoke, not Invoke) or else the two
				// threads might get stuck waiting for each other).
				BeginInvoke(new Action(() =>
				{
					// Display the sample value to the user.
					textBoxResponse.Text = sample;

					// Update the status message.
					_samples++;
					toolStripStatusLabel.Text = "Logged " + _samples + " samples.";
				}));

				// Start the timer again.
				_timer.Enabled = true;
			}
			// If an error occurs...
			catch (Exception ex)
			{
				// Notify the user.
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));

				// Stop logging.
				// Use a method invoker because it needs to happen in the form's thread.
				BeginInvoke(new Action(StopLogging));
			}

			// Set timer to "Idle" state and broadcast that we've finished executing.
			_logging = 0;
			_loggingLock.Set();
		}

		/// <summary>
		/// When the "Start" button is clicked, attempt to start logging.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonStart_Click(object sender, EventArgs e)
		{
			// If logging is 2 "stopped"...
			if (_logging == 2)
			{
				try
				{
					// Parse the selected serial port settings.
					_genericSerialDevice.PortName = Properties.Settings.Default.Port;
					_genericSerialDevice.BaudRate = Convert.ToInt32(comboBoxBaudRate.Text);
					_genericSerialDevice.DataBits = Convert.ToInt32(comboBoxDataBits.Text);
					_genericSerialDevice.Parity = (Parity)Enum.Parse(typeof(Parity), comboBoxParity.Text);
					_genericSerialDevice.StopBits = (StopBits)Enum.Parse(typeof(StopBits), comboBoxStopBits.Text);
					_genericSerialDevice.Handshake = (Handshake)Enum.Parse(typeof(Handshake), comboBoxHandshake.Text);

					// Open the serial port.
					_genericSerialDevice.Open();

					// Set up the CSV file writer filestream.
					_writer = new CsvWriter(Properties.Settings.Default.Filename, true);

					// Start the timer.
					_timer.Enabled = true;

					// Set logging state to 0 "idle".
					_logging = 0;

					// Update GUI.
					toolStripStatusLabel.Text = "Logging data...";
					buttonStart.Enabled = false;
					buttonStop.Enabled = true;
				}
				// If an error occurs...
				catch (Exception ex)
				{
					// Notify the user.
					MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));

					// Undo whatever was started.
					StopLogging();
				}
			}
		}

		/// <summary>
		/// Attempt to stop logging.
		/// </summary>
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

					// Close the DUT serial port.
					_genericSerialDevice?.Close();

					// Update GUI.
					buttonStart.Enabled = true;
					buttonStop.Enabled = false;
					toolStripStatusLabel.Text = "Ready...";
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));
				}
			}
		}

		/// <summary>
		/// When the "Stop" button is clicked, attempt to stop logging.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonStop_Click(object sender, EventArgs e)
		{
			StopLogging();
		}

		/// <summary>
		/// Before exiting, confirm the user's wishes and safely end testing.
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

		private void RadioButton_CheckedChanged(object sender, EventArgs e)
		{

		}
	}
}
