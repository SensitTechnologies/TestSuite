using System.Diagnostics;
using System.Globalization;
using System.IO.Ports;
using Sensit.TestSDK.Devices;
using Sensit.TestSDK.Exceptions;

namespace Sensit.App.GPS
{
	/// <summary>
	/// Evaluate a GPS module that sends NMEA GGA Sentences.
	/// </summary>
	public partial class FormGPS : Form
	{
		#region Constants

		// TODO:  Double-check latitude and longitude conversions.
		private const double LATITUDE = 41.46095328477597; //Sensit: 41.46095328477597 
		private const double LONGITUDE = -87.01571016084537; //Sensit: -87.01571016084537
		private const double POSITION_TOLERANCE = 1.0;
		private readonly TimeSpan TIME_TOLERANCE = new(0, 2, 0);

		#endregion

		#region Fields

		/// <summary>
		/// Serial port to communicate with GPS module
		/// </summary>
		/// <remarks>
		/// 8-N-1 only supported at this time
		/// </remarks>
		private SerialStreamDevice gpsDevice;       
		
		//GPS Data Recording
		GPSDataRecords gpsRecord;

		/// <summary>
		/// Timer to keep track of how long GPS module takes to find satellites.
		/// </summary>
		private readonly System.Windows.Forms.Timer timer = new();

		/// <summary>
		/// timestamp for elapsed time
		/// </summary>
		private uint elapsedSeconds = 0;

		#endregion

		#region Constructor

		/// <summary>
		/// Runs when the application starts.
		/// </summary>
		public FormGPS()
		{
			// Initialize the form.
			InitializeComponent();

			// Initialize the GPS serial stream device.
			gpsDevice = new()
			{
				// Specify the delegate that receives messages.
				MessageReceived = TestResponse
			};

			// Set timer interval to 1 second.
			timer.Interval = 1000;

			// Set timer callback.
			timer.Tick += new EventHandler(OnTimedEvent);

			// Find all available serial ports.
			checkedListSerialPort.Items.AddRange(SerialPort.GetPortNames());

			// Set the most recently used timeout.
			numericUpDownTimeout.Value = Properties.Settings.Default.Timeout;
		}

		#endregion

		#region Application

		/// <summary>
		/// When the application closes, save settings and close serial port.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormGPS_FormClosed(object sender, FormClosedEventArgs e)
		{
			// Close the serial port.
			gpsDevice.Close();

			// Store the current values of the application settings properties.
			// If this call is omitted, then the settings will not be saved after the application quits.
			Properties.Settings.Default.Save();
		}

		/// <summary>
		/// When File --> Exit menu item is clicked, close the application.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		#endregion

		#region Settings

		/// <summary>
		/// Remember the most recently selected test duration.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NumericUpDownTimeout_ValueChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.Timeout = (uint)numericUpDownTimeout.Value;
		}

		/// <summary>
		/// When the refresh button is clicked, search for serial ports.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonPortRefresh_Click(object sender, EventArgs e)
		{
			// Clear the serial port combo box.
			checkedListSerialPort.Items.Clear();

			// Find all available serial ports.
			checkedListSerialPort.Items.AddRange(SerialPort.GetPortNames());

			// Select the most recently used port.
			// The most recently used port is fetched from applications settings.
			checkedListSerialPort.Text = Properties.Settings.Default.Port;
		}

		#endregion

		#region Test

		/// <summary>
		/// Evaluate messages sent from the GPS device.
		/// </summary>
		/// <remarks>
		/// Module will send a series of messages.  One of them will be of this form:
		/// $GPGGA,115739.00,4158.8441367,N,09147.4416929,W,4,13,0.9,255.747,M,-32.00,M,01,0000*6E
		/// For more info, see http://lefebure.com/articles/nmea-gga/.
		/// </remarks>
		/// <param name="message"></param>
		private void TestResponse(string message)
		{
			// Use a method invoker to interact with the Form's thread.
			// It must be asynchronous (BeginInvoke, not Invoke) or else the two
			// threads might get stuck waiting for each other).
			BeginInvoke(new Action(() =>
			{
				// Parse messages.
				string[] pieces = message.Split(',');

				// If the message begins with "SPGGA"...
				if (pieces[0].Equals("$GPGGA") && pieces.Length >= 14)
				{
					//***PARSE EVERYTHING***//
					// Convert timestamp to a date/time variable.
					DateTime.TryParseExact(pieces[1],
						"HHmmss.fff",
						CultureInfo.InvariantCulture,
						DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal,
						out DateTime dateTime);

					//Latitude
					double latitude = (double.TryParse(pieces[2], out latitude) ? latitude : 0) / 100;
					if (pieces[3] == "S") { latitude *= -1; }

					//Longitude
					double longitude = (double.TryParse(pieces[4], out longitude) ? longitude : 0) / 100;
					if (pieces[5] == "W") { longitude *= -1; }

					//Fix Quality
					double fix = double.TryParse(pieces[6], out fix) ? fix : 0;

					//Satellite Count
					double satellite = double.TryParse(pieces[7], out satellite) ? satellite : 0;


					//***TEST EVERYTHING***//
					// Test timestamp.
					if (DateTime.UtcNow - dateTime < TIME_TOLERANCE &&
						Math.Abs(latitude - LATITUDE) < POSITION_TOLERANCE &&
						Math.Abs(longitude - LONGITUDE) < POSITION_TOLERANCE &&
						fix > 0 &&
						satellite > 4)
					{
						SetStatus(true);
					}
				}
			}));
		}

		private void SetStatus(bool pass)
		{
			//// If all are passing...
			if (pass == true)
			{
				//// Close the serial port.
				gpsDevice.Close();

				//// Disable the timer.
				timer.Enabled = false;

				//// Alert the user (and make it bold).
				//TODO: change the gps board's icon to a red tag
			}
			else
			{
				//Close serial port
				gpsDevice.Close();

				//Disable timer
				timer.Enabled = false;

				//Alert user
				//TODO: change gps board icon to a red tag
			}
		}

		/// <summary>
		/// When the timer ticks, update elapsed time and fail if timeout is reached.
		/// <summary>
		private void OnTimedEvent(object state, EventArgs e)
		{
			try
			{
				// Increment elapsed time.
				elapsedSeconds++;

				// Convert to time span.
				TimeSpan t = TimeSpan.FromSeconds(elapsedSeconds);

				// Update the user interface.
				toolStripStatusLabel.Text = "Elapsed time:  " + t.ToString(@"m\:ss");

				// If a timeout exists...
				if (Properties.Settings.Default.Timeout != 0)
				{
					// Update the progress bar.
					toolStripProgressBar.Value = (int)elapsedSeconds;

					// If the timeout has elapsed...
					if (elapsedSeconds >= Properties.Settings.Default.Timeout)
					{
						// Close the serial port.
						gpsDevice.Close();

						// Disable the timer.
						timer.Enabled = false;

						// Update the user interface.
						toolStripProgressBar.Value = toolStripProgressBar.Minimum;

						//Determine board status
						//switch (textBoxLatitude.Text)
						//{
						//Board is not plugged in/board is plugged in backwards/board is dead.
						//case "":
						//	toolStripStatusLabel.Text = "FAIL: Not detected";
						//	break;
						////Board has faulty reading/components
						//case "0":
						//	toolStripStatusLabel.Text = "FAIL: Bad Position";
						//	break;
						////Unknown reason why program timed out
						//default:
						//	toolStripStatusLabel.Text = "FAIL";
						//	break;
						//}

						toolStripStatusLabel.Font = new Font(toolStripStatusLabel.Font, FontStyle.Bold);
						toolStripStatusLabel.ForeColor = Color.Red;
						groupBoxSettings.Enabled = true;
						buttonStartSingle.Enabled = true;
						buttonStop.Enabled = false;
					}
				}
			}
			// If an error occurs...
			catch (Exception ex)
			{
				// Alert the user.
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));
			}
		}

		/// <summary>
		/// When Start Single button is clicked, start the test.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonStartSingle_Click(object sender, EventArgs e)
		{
			try
			{
				if (checkedListSerialPort.CheckedItems.Count != 1)
				{
					throw new TestException("One port must be selected.");
				}

				//Set the timeout value
				Properties.Settings.Default.Timeout = (uint)numericUpDownTimeout.Value;

				// Set up progress bar.
				toolStripProgressBar.Maximum = (int)Properties.Settings.Default.Timeout;

				//instantiate new gps record
				gpsRecord = new();

				// Open the serial port (and let it know what serial port to use).
				gpsDevice.Open((string)checkedListSerialPort.SelectedItem);

				// Update the user interface.
				groupBoxSettings.Enabled = false;
				buttonStartSingle.Enabled = false;
				buttonStartPanel.Enabled = false;
				buttonStop.Enabled = true;
				toolStripProgressBar.Value = toolStripProgressBar.Minimum;
				toolStripStatusLabel.Text = "Testing...";
				toolStripStatusLabel.Font = new Font(toolStripStatusLabel.Font, FontStyle.Regular);
				toolStripStatusLabel.ForeColor = SystemColors.ControlText;

				// Reset elapsed time.
				elapsedSeconds = 0;

				// Start the timer.
				timer.Enabled = true;
			}
			// If an error occurs...
			catch (Exception ex)
			{
				// Alert the user.
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));
			}
		}

		private void ButtonStartPanel_Click(object sender, EventArgs e)
		{
			try
			{
				List<string> gpsPanelList = new(GetCheckedPorts());
				foreach (string gpsName in gpsPanelList)
				{
					//Set the timeout value
					Properties.Settings.Default.Timeout = (uint)numericUpDownTimeout.Value;

					// Set up progress bar.
					toolStripProgressBar.Maximum = (int)Properties.Settings.Default.Timeout;

					//Open the serial port (and let it know what serial port to use).
					gpsDevice.Open(gpsName);

					// Update the user interface.
					groupBoxSettings.Enabled = false;
					buttonStartSingle.Enabled = false;
					buttonStartPanel.Enabled = false;
					buttonStop.Enabled = true;
					toolStripProgressBar.Value = toolStripProgressBar.Minimum;
					toolStripStatusLabel.Text = "Testing...";
					toolStripStatusLabel.Font = new Font(toolStripStatusLabel.Font, FontStyle.Regular);
					toolStripStatusLabel.ForeColor = SystemColors.ControlText;

					// Reset elapsed time.
					elapsedSeconds = 0;

					// Start the timer.
					timer.Enabled = true;
				}
			}
			// If an error occurs...
			catch (Exception ex)
			{
				// Alert the user.
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));
			}
		}

		/// <summary>
		/// When Stop button is clicked, stop testing.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonStop_Click(object sender, EventArgs e)
		{
			try
			{
				// Close the serial port.
				gpsDevice.Close();

				// Disable the timer.
				timer.Enabled = false;

				// Update user interface.
				groupBoxSettings.Enabled = true;
				buttonStartSingle.Enabled = true;
				buttonStartPanel.Enabled = true;
				buttonStop.Enabled = false;
				toolStripStatusLabel.Text = "Ready...";
				toolStripStatusLabel.Font = new Font(toolStripStatusLabel.Font, FontStyle.Regular);
				toolStripStatusLabel.ForeColor = SystemColors.ControlText;
				toolStripProgressBar.Value = toolStripProgressBar.Minimum;
			}
			// If an error occurs...
			catch (Exception ex)
			{
				// Alert the user.
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));
			}
		}

		#endregion

		#region Helper Methods

		private List<string> GetCheckedPorts()
		{
			List<string> ports = new();

			if(checkedListSerialPort.CheckedItems.Count == 0)
			{
				throw new TestException("No checked ports");
			}

			foreach (string s in checkedListSerialPort.CheckedItems)
			{
				ports.Add(s);
			}

			return ports;
		}

		#endregion
	}
}