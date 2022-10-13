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

		private const double POSITION_TOLERANCE = 1.0;
		private readonly TimeSpan TIME_TOLERANCE = new(0, 2, 0);

		//851 Transport Drive (OG Building)
		private const double TRANSPORT_LATITUDE = 41.46095328477597;
		private const double TRANSPORT_LONGITUDE = -87.01571016084537;

		//1150 Loudermilk Lane (Production Building)
		private const double LOUDERMILK_LATITUDE = 41.45822418035022;
		private const double LOUDERMILK_LONGITUDE = -87.01414233228682;

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

		//User Location
		internal string? userLocation;

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

			//Set up most recent location
			comboBoxUserLocation.ResetText();
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
			//Reset Icons
			ResetIcons();

			// Clear the serial port checked box.
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
				//TODO: DELETE AFTER TESTING
				Debug.WriteLine(message);

				//Set allowed tolerances in gps records
				//TODO: see if this should be a user input. for now, they're what adam had.
				gpsRecord.PositionTolerance = POSITION_TOLERANCE;
				gpsRecord.TimeTolerance = TIME_TOLERANCE;

				//Set User Location in gps records.
				switch (comboBoxUserLocation.SelectedItem.ToString())
				{
					case "Loudermilk":
						gpsRecord.UserLatitude = LOUDERMILK_LATITUDE;
						gpsRecord.UserLongitude = LOUDERMILK_LONGITUDE;
						break;
					case "Transport":
						gpsRecord.UserLatitude = TRANSPORT_LATITUDE;
						gpsRecord.UserLongitude = TRANSPORT_LONGITUDE;
						break;
					default:
						throw new NotImplementedException();
				}
				gpsRecord.SetRecords(message);
				if (gpsRecord.IsValid == true)
				{
					SetStatus(gpsRecord.IsValid);
				}
				else
				{
					//If not valid, reset records
					gpsRecord.ResetBoardRecord();
				}
			}));
		}

		private void SetStatus(bool pass)
		{
			//Close serial port
			gpsDevice.Close();

			// Disable the timer.
			timer.Enabled = false;

			//Set Test Duration
			//TODO: fix this
			gpsRecord.TestDuration = gpsRecord.TestTimeout.ToString();

			//Set user name
			gpsRecord.UserName = textBoxName.Text;

			//Variable for the icon to change based on status
			PictureBox tag = SetDictionary(gpsRecord.PanelLocation);

			// Update user interface.
			groupBoxSettings.Enabled = true;
			buttonStartSingle.Enabled = true;
			buttonStartPanel.Enabled = true;
			buttonStop.Enabled = false;
			toolStripStatusLabel.Font = new Font(toolStripStatusLabel.Font, FontStyle.Regular);
			toolStripStatusLabel.ForeColor = SystemColors.ControlText;
			toolStripProgressBar.Value = toolStripProgressBar.Minimum;

			//// If all are passing...
			if (pass == true)
			{
				//Set test duration
				gpsRecord.TestDuration = timer.ToString();

				//Clear and change icon
				tag.BackgroundImage = Properties.Resources.green_tag;

				//Status strip update
				toolStripStatusLabel.Text = $"COM port {checkedListSerialPort.SelectedItem}: PASSED IN " + TimeSpan.FromSeconds(elapsedSeconds).ToString(@"m\:ss");

				//Give the user time to see the status strip message (3 seconds)
				Thread.Sleep(300);
			}
			else
			{
				//// Alert the user (and make it bold).
				tag.BackgroundImage = Properties.Resources.red_tag;

				//status strip update
				toolStripStatusLabel.Text = $"COM port {checkedListSerialPort.SelectedItem}: FAILED";

				//Give the user time to see the status strip message (3 seconds)
				Thread.Sleep(300);
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

						SetStatus(false);
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
				//Reset Icons
				ResetIcons();

				// Update the user interface.
				groupBoxSettings.Enabled = false;
				buttonStartSingle.Enabled = false;
				buttonStartPanel.Enabled = false;
				buttonStop.Enabled = true;
				toolStripProgressBar.Value = toolStripProgressBar.Minimum;
				toolStripStatusLabel.Font = new Font(toolStripStatusLabel.Font, FontStyle.Regular);
				toolStripStatusLabel.ForeColor = SystemColors.ControlText;

				if (checkedListSerialPort.CheckedItems.Count != 1)
				{
					throw new TestException("One port must be selected.");
				}

				if(comboBoxUserLocation == null)
				{
					throw new TestException("Please choose your location.");
				}
				else
				{
					userLocation = comboBoxUserLocation.SelectedItem.ToString();
				}

				//Set the timeout value
				Properties.Settings.Default.Timeout = (uint)numericUpDownTimeout.Value;

				// Set up progress bar.
				toolStripProgressBar.Maximum = (int)Properties.Settings.Default.Timeout;

				//Instantiate a new gps record. Tell record it is not a panel
				/* Temporary: Boards are currently not serialized. Future proofing
				 * has the property implemented already. For now, the "serial number" 
				 * will be "Single"
				 */
				gpsRecord = new()
				{
					IsPanel = false,
					PanelLocation = "Single",
					BoardSerialNumber = "Single",
					UserName = textBoxName.Text,
					TestTimeout = numericUpDownTimeout.Value
				};

				//Reset the message received 
				gpsDevice.MessageReceived = TestResponse;

				// Open the serial port (and let it know what serial port to use).
				gpsDevice.Open(checkedListSerialPort.SelectedItem.ToString());

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
			ResetIcons();

			try
			{
				//TODO: find a better way to get index of checked item in original list
				List<string> checkingIndices = new();
				foreach (string s in checkedListSerialPort.Items)
				{
					checkingIndices.Add(s);
				}

				List<string> port = new();
				foreach (string selectedItem in checkedListSerialPort.CheckedItems)
				{
					//TODO: we need to store port name and we need to store index. would a dictionary be better?
					port.Add(selectedItem);
				}

				//switch for exceptions regarding com port count
				switch (checkedListSerialPort.CheckedItems.Count) 
				{ 
					case 0:
						throw new NotImplementedException();
					case 1:
						throw new TestException($"Only {port[0]} selected. \r\n" +
							$"Select more ports or switch to single board programming.");
					default:
						break;
				};

				if (comboBoxUserLocation == null)
				{
					throw new TestException("Please choose your location.");
				}
				else
				{
					userLocation = comboBoxUserLocation.SelectedItem.ToString();
				}

				//Update: foreach loop causes the second port to be opened while the first one is testing, etc. This
				//causes a lot of errors. First, I'm going to see if I can use the timer being disabled to run each
				//iteration one after the other. If that doesn't work, I'm going to use an if statement with a counter.
				foreach (string gpsName in port)
				{
					//Set the timeout value
					Properties.Settings.Default.Timeout = (uint)numericUpDownTimeout.Value;

					//Instantiate new gps record for each board and set values
					/* Temporary: Boards are currently not serialized. Future proofing
					 * has the property implemented already. For now, the "serial number" 
					 * will be "Panel"
					 */

					gpsRecord = new()
					{
						IsPanel = true,
						PanelLocation = checkingIndices.IndexOf(gpsName).ToString(),
						BoardSerialNumber = "Panel",
					};

					// Set up progress bar.
					toolStripProgressBar.Maximum = (int)Properties.Settings.Default.Timeout;

					//Reset message received 
					gpsDevice.MessageReceived = TestResponse;

					//Open the serial port (and let it know what serial port to use).
					gpsDevice.Open(gpsName);

					// Update user interface.
					groupBoxSettings.Enabled = true;
					buttonStartSingle.Enabled = true;
					buttonStartPanel.Enabled = true;
					buttonStop.Enabled = false;
					toolStripStatusLabel.Text = "Panel Test Complete";
					toolStripStatusLabel.Font = new Font(toolStripStatusLabel.Font, FontStyle.Regular);
					toolStripStatusLabel.ForeColor = SystemColors.ControlText;
					toolStripProgressBar.Value = toolStripProgressBar.Minimum;

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

		private PictureBox SetDictionary(string gpsKey)
		{
			//use checklist to set the dictionary keys based off checked list index (which will become their location)
			List<string> checkedItems = new();
			foreach(string s in checkedListSerialPort.Items)
			{
				checkedItems.Add(s);
			}

			int count = 1;
			while(checkedItems.Count < 20)
			{
				checkedItems.Add($"empty port {count}");
				count++;
			}

			//make dictionary
			Dictionary<string, PictureBox> getPictureBox = new()
			{
				{ checkedItems[0], pictureBoxGPS0 },
				{ checkedItems[1], pictureBoxGPS1 },
				{ checkedItems[2], pictureBoxGPS2 },
				{ checkedItems[3], pictureBoxGPS3 },
				{ checkedItems[4], pictureBoxGPS4 },
				{ checkedItems[5], pictureBoxGPS5 },
				{ checkedItems[6], pictureBoxGPS6 },
				{ checkedItems[7], pictureBoxGPS7 },
				{ checkedItems[8], pictureBoxGPS8 },
				{ checkedItems[9], pictureBoxGPS9 },
				{ checkedItems[10], pictureBoxGPS10 },
				{ checkedItems[11], pictureBoxGPS11 },
				{ checkedItems[12], pictureBoxGPS12 },
				{ checkedItems[13], pictureBoxGPS13 },
				{ checkedItems[14], pictureBoxGPS14 },
				{ checkedItems[15], pictureBoxGPS15 },
				{ checkedItems[16], pictureBoxGPS16 },
				{ checkedItems[17], pictureBoxGPS17 },	
				{ checkedItems[18], pictureBoxGPS18 },
				{ checkedItems[19], pictureBoxGPS19 },

				//for the single board test program
				{ "Single", pictureBoxGPSSingle }
			};

			return getPictureBox[gpsKey];
		}

		private void ResetIcons()
		{
			//TODO: do this in a better and more efficient way
			pictureBoxGPS0.BackgroundImage = Properties.Resources.gps_board;
			pictureBoxGPS1.BackgroundImage = Properties.Resources.gps_board;
			pictureBoxGPS2.BackgroundImage = Properties.Resources.gps_board;
			pictureBoxGPS3.BackgroundImage = Properties.Resources.gps_board;
			pictureBoxGPS4.BackgroundImage = Properties.Resources.gps_board;
			pictureBoxGPS5.BackgroundImage = Properties.Resources.gps_board;
			pictureBoxGPS6.BackgroundImage = Properties.Resources.gps_board;
			pictureBoxGPS7.BackgroundImage = Properties.Resources.gps_board;
			pictureBoxGPS8.BackgroundImage = Properties.Resources.gps_board;
			pictureBoxGPS9.BackgroundImage = Properties.Resources.gps_board;
			pictureBoxGPS10.BackgroundImage = Properties.Resources.gps_board;
			pictureBoxGPS11.BackgroundImage = Properties.Resources.gps_board;
			pictureBoxGPS12.BackgroundImage = Properties.Resources.gps_board;
			pictureBoxGPS13.BackgroundImage = Properties.Resources.gps_board;
			pictureBoxGPS14.BackgroundImage = Properties.Resources.gps_board;
			pictureBoxGPS15.BackgroundImage = Properties.Resources.gps_board;
			pictureBoxGPS16.BackgroundImage = Properties.Resources.gps_board;
			pictureBoxGPS17.BackgroundImage = Properties.Resources.gps_board;
			pictureBoxGPS18.BackgroundImage = Properties.Resources.gps_board;
			pictureBoxGPS19.BackgroundImage = Properties.Resources.gps_board;
			pictureBoxGPSSingle.BackgroundImage = Properties.Resources.gps_board;
		}

		#endregion
	}
}