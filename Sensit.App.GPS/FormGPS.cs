using Sensit.TestSDK.Devices;
using System.Globalization;
using System.IO.Ports;

namespace Sensit.App.GPS
{
	/// <summary>
	/// Evaluate a GPS module that sends NMEA GGA Sentances.
	/// </summary>
	public partial class FormGPS : Form
	{
		#region Constants

		private const double LATITUDE = 41.478142;
		private const double LONGITUDE = -87.055367;
		private const double POSITION_TOLERANCE = 1.0;
		private readonly TimeSpan TIME_TOLERANCE = new(0, 0, 1);

		#endregion

		#region Fields

		/// <summary>
		/// Serial port to communicate with GPS module
		/// </summary>
		/// <remarks>
		/// 8-N-1 only supported at this time
		/// </remarks>
		private SerialStreamDevice gpsDevice;

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

			// Find all available serial ports.
			comboBoxSerialPort.Items.AddRange(SerialPort.GetPortNames());

			// Select the most recently used port.
			// The most recently used port is fetched from applications settings.
			comboBoxSerialPort.Text = Properties.Settings.Default.Port;
		}

		#endregion

		#region Serial Port

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
		/// Remember the most recently selected serial port.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ComboBoxSerialPort_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Save the serial port selection in the application settings.
			Properties.Settings.Default.Port = comboBoxSerialPort.Text;
		}

		/// <summary>
		/// When the refresh button is clicked, search for serial ports.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonPortRefresh_Click(object sender, EventArgs e)
		{
			// Clear the serial port combo box.
			comboBoxSerialPort.Items.Clear();

			// Find all available serial ports.
			comboBoxSerialPort.Items.AddRange(SerialPort.GetPortNames());

			// Select the most recently used port.
			// The most recently used port is fetched from applications settings.
			comboBoxSerialPort.Text = Properties.Settings.Default.Port;
		}

		/// <summary>
		/// When the Open/Closed checkboxes are checked, open or close the serial port.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RadioButton_CheckedChanged(object sender, EventArgs e)
		{
			// Do stuff only if the radio button is checked.
			// (Otherwise the actions will run twice.)
			if (((RadioButton)sender).Checked)
			{
				try
				{
					// If the "Open" radio button has been checked...
					if (((RadioButton)sender) == radioButtonOpen)
					{
						// Open the Mass Flow Controller (and let it know what serial port to use).
						gpsDevice.Open(Properties.Settings.Default.Port);

						// Update the user interface.
						comboBoxSerialPort.Enabled = false;
					}
					else if (((RadioButton)sender) == radioButtonClosed)
					{
						// Close the serial port.
						gpsDevice.Close();

						// Update user interface.
						comboBoxSerialPort.Enabled = true;
					}
				}
				// If an error occurs...
				catch (Exception ex)
				{
					// Alert the user.
					MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));

					// Undo the user action.
					radioButtonClosed.Checked = true;
				}
			}
		}

		#endregion

		#region Status

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
					textBoxTimestamp.Text = dateTime.ToString("h:mm:ss tt");

					// Test timestamp.
					SetResult(textBoxPassTimestamp, (TimeSpan)(DateTime.UtcNow - dateTime) < TIME_TOLERANCE);

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
						textBoxLatitude.Text = latitude.ToString("0.00000") + " " + pieces[3];

						// Test latitude.
						SetResult(textBoxPassLatitude, Math.Abs(latitude - LATITUDE) < POSITION_TOLERANCE);
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
						textBoxLongitude.Text = longitude.ToString("0.00000") + " " + pieces[5];

						// Test longitude.
						SetResult(textBoxPassLongitude, Math.Abs(longitude - LONGITUDE) < POSITION_TOLERANCE);
					}

					// If GPS fix status format is correct...
					if (Int16.TryParse(pieces[6], out short fix))
					{
						// Display to the user.
						textBoxFixType.Text = pieces[6];

						// Ensure fix is established.
						SetResult(textBoxPassFixType, fix > 0);
					}

					// If satellite format is correct...
					if (Int16.TryParse(pieces[7], out short satellites))
					{
						// Display number of satellites to the user.
						textBoxSatellites.Text = satellites.ToString();

						// Ensure number of satellites is at least four.
						SetResult(textBoxPassSatellites, satellites >= 4);
					}
				}
			}));
		}

		private static void SetResult(TextBox control, bool pass)
		{
			if (pass)
			{
				control.Text = "PASS";
				control.ForeColor = Color.Green;
			}
			else
			{
				control.Text = "";
			}
		}

		#endregion
	}
}