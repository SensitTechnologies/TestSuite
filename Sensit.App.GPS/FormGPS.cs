using System.Globalization;
using System.IO.Ports;
using Sensit.TestSDK.Devices;

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
		private List<SerialStreamDevice> gpsPanelList = new();

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
					// Convert timestamp to a date/time variable.
					DateTime.TryParseExact(pieces[1],
						"HHmmss.fff",
						CultureInfo.InvariantCulture,
						DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal,
						out DateTime dateTime);

					// Display timestamp to the user.
					//textBoxTimestamp.Text = dateTime.ToString("h:mm:ss tt");

					// Test timestamp.
					//SetStatus(textBoxStatusTimestamp, DateTime.UtcNow - dateTime < TIME_TOLERANCE);

					// If latitude format is correct...
					if (double.TryParse(pieces[2], out double latitude))
					{
						// Convert latitude to display format.
						latitude /= 100;
						if (pieces[3].Equals("S"))
						{
							latitude *= -1;
						}

						// Display latitude to the user.
						//textBoxLatitude.Text = latitude.ToString("0.00000") + " " + pieces[3];

						// Test latitude.
						//SetStatus(textBoxStatusLatitude, Math.Abs(latitude - LATITUDE) < POSITION_TOLERANCE);
					}

					// If longitude format is correct...
					if (double.TryParse(pieces[4], out double longitude))
					{
						// Convert longitude to display format.
						longitude /= 100;
						if (pieces[5].Equals("W"))
						{
							longitude *= -1;
						}

						// Display longitude to the user.
						//textBoxLongitude.Text = longitude.ToString("0.00000") + " " + pieces[5];

						// Test longitude.
						//SetStatus(textBoxStatusLongitude, Math.Abs(longitude - LONGITUDE) < POSITION_TOLERANCE);
					}

					// If GPS fix status format is correct...
					if (Int16.TryParse(pieces[6], out short fix))
					{
						// Display to the user.
						//textBoxFixType.Text = pieces[6];

						// Ensure fix is established.
						//SetStatus(textBoxStatusFixType, fix > 0);
					}

					// If satellite format is correct...
					if (Int16.TryParse(pieces[7], out short satellites))
					{
						// Display number of satellites to the user.
						//textBoxSatellites.Text = satellites.ToString();

						// Ensure number of satellites is at least four.
						//SetStatus(textBoxStatusSatellites, satellites >= 4);
					}
				}
			}));
		}

		private void SetStatus(TextBox control, bool pass)
		{
			if (pass)
			{
				control.Text = "OK";
			}
			else
			{
				control.Text = "";
			}

			//// If all are passing...
			//if (textBoxStatusTimestamp.Text.Equals("OK") &&
			//	textBoxStatusLatitude.Text.Equals("OK") &&
			//	textBoxStatusLongitude.Text.Equals("OK") &&
			//	textBoxStatusFixType.Text.Equals("OK") &&
			//	textBoxStatusSatellites.Text.Equals("OK"))
			//{
				//// Close the serial port.
				//gpsDevice.Close();

				//// Disable the timer.
				//timer.Enabled = false;

				//// Alert the user (and make it bold).
				//toolStripProgressBar.Value = toolStripProgressBar.Maximum;
				//toolStripStatusLabel.Text = "PASSED @ " + TimeSpan.FromSeconds(elapsedSeconds).ToString(@"m\:ss");
				//toolStripStatusLabel.Font = new Font(toolStripStatusLabel.Font, FontStyle.Bold);
				//toolStripStatusLabel.ForeColor = Color.Green;
				//groupBoxSettings.Enabled = true;
				//buttonStart.Enabled = true;
				//buttonStop.Enabled = false;
			//}
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
				//Set the timeout value
				Properties.Settings.Default.Timeout = (uint)numericUpDownTimeout.Value;

				// Set up progress bar.
				toolStripProgressBar.Maximum = (int)Properties.Settings.Default.Timeout;

				// Open the serial port (and let it know what serial port to use).
				gpsDevice.Open(checkedListSerialPort.Text);

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

		/// <summary>
		/// When Start Panel button is clicked, start programming each gps board individually.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonStartPanel_Click(object sender, EventArgs e)
		{
			foreach (SerialStreamDevice gpsDevice in gpsPanelList)
			{

				try
				{
					//Set the timeout value
					Properties.Settings.Default.Timeout = (uint)numericUpDownTimeout.Value;

					// Set up progress bar.
					toolStripProgressBar.Maximum = (int)Properties.Settings.Default.Timeout;

					//Open the serial port (and let it know what serial port to use).
					gpsDevice.Open(checkedListSerialPort.Text);

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
	}
}