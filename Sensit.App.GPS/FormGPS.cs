
using System.Globalization;
using System.IO.Ports;
using CsvHelper;
using CsvHelper.Configuration;
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

		//File papth to create and store csv data in
		private readonly string filePath = Path.GetFullPath(@"\\10.25.0.30\Public\Production Software\Data Logging\GPS Tester");

		//Tolerances for testing.
		private const double POSITION_TOLERANCE = 1.0;
		private readonly TimeSpan TIME_TOLERANCE = new(0, 2, 0);

		//Minimum Test Time (seconds)
		private readonly int MINIMUM_TIMEOUT = 10;

		#region Latitude/Longitude for each Location

		//851 Transport Drive (OG Building)
		private const double TRANSPORT_LATITUDE = 41.46095328477597;
		private const double TRANSPORT_LONGITUDE = -87.01571016084537;

		//1150 Loudermilk Lane (Production Building)
		private const double LOUDERMILK_LATITUDE = 41.45822418035022;
		private const double LOUDERMILK_LONGITUDE = -87.01414233228682;

		#endregion
		#endregion

		#region Enumerations

		/// <summary>
		/// List holding names of all testing locations we have. 
		/// Future: Could be updated with a dictionary to have latitude and longitude attached.
		/// i.e Dictionary<string, int, int> => Dictionary <location, latitude, longitude>
		/// </summary>
		internal readonly List<string> UserLocationList = new()
		{
			"Transport",
			"Loudermilk"
		};

		#endregion

		#region Fields

		/// <summary>
		/// Serial port to communicate with GPS module
		/// </summary>
		/// <remarks>
		/// 8-N-1 only supported at this time
		/// </remarks>
		private readonly SerialStreamDevice gpsDevice;

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

			//Populate user location box with all possible locations
			comboBoxUserLocation.DataSource = UserLocationList;

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

			//gpsRecord cannot be null when exiting constructor
			gpsRecord = new();

			//checkedPorts cannot be null when exiting constructor
			checkedPorts = new();

			//allPorts cannot be null when exiting constructor
			allPorts = new();

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
						//Close serial port
						gpsDevice.Close();

						throw new TestException("UserLocation not available");
				}
				gpsRecord.SetRecords(message);
				if (gpsRecord.IsValid == true)
				{
					//Close gpsDevice so no more messages call setstatus
					gpsDevice.Close();

					//clear any lingering messages? 
					message = String.Empty;

					SetStatus(gpsRecord.IsValid);
				}
				else
				{
					//If not valid, reset records
					gpsRecord.ResetBoardRecord();
				}
			}));
		}

		List<GPSDataRecord> csvList = new();
		private int panelTestCount;
		private void SetStatus(bool pass)
		{
			// Disable the timer.
			timer.Enabled = false;

			//Set Test Duration
			gpsRecord.TestDuration = elapsedSeconds.ToString();

			//Set user name
			gpsRecord.UserName = textBoxName.Text;

			//Variable for the icon to change based on status
			PictureBox tag = SetDictionary(gpsDevice.PortName);

			// If all are passing...
			if (pass == true)
			{
				//Clear and change icon
				tag.BackgroundImage = Properties.Resources.green_tag;

				//Status strip update
				toolStripStatusLabel.Text = $"COM port {gpsDevice.PortName}: PASSED IN " + elapsedSeconds;

				//Give the user time to see the status strip message (2 seconds)
				Thread.Sleep(2000);
			}
			else
			{
				//// Alert the user (and make it bold).
				tag.BackgroundImage = Properties.Resources.red_tag;

				//status strip update
				toolStripStatusLabel.Text = $"COM port {gpsDevice.PortName}: FAILED";

				//Give the user time to see the status strip message (2 seconds)
				Thread.Sleep(2000);
			}
			//Set testing to false and increase panel count
			inTest = false;
			panelTestCount++;
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
				toolStripStatusLabel.Text = "Elapsed time:  " + elapsedSeconds;

				// If a timeout exists...
				if (Properties.Settings.Default.Timeout != 0)
				{
					// Update the progress bar.
					toolStripProgressBar.Value = (int)elapsedSeconds;

					// If the timeout has elapsed...
					if (elapsedSeconds >= Properties.Settings.Default.Timeout)
					{
						//Elapsed seconds needs to be reset here as well so it doesn't throw exceptions in panel testing
						elapsedSeconds = 0;

						//Fail the test.
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

		#region Disposable variables for test

		//GPS Data Recording
		GPSDataRecord gpsRecord;

		//Indicator of whether a test is in process or not
		private bool inTest;

		//User Location
		internal string? userLocation;

		//List containing all checked values
		private List<string> checkedPorts;
		private List<string> allPorts;

		#endregion

		/// <summary>
		/// When "SingleTest" button is clicked, start a single test.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void ButtonStartSingle_Click(object sender, EventArgs e)
		{
			try
			{				
				//Check user input for error(s) and let it know isPanel == false.
				CheckUserInput(false);

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

				//Set the timeout value
				Properties.Settings.Default.Timeout = (uint)numericUpDownTimeout.Value;

				// Set up progress bar.
				toolStripProgressBar.Maximum = (int)Properties.Settings.Default.Timeout;

				//Reset names of all ports in checked box list.
				allPorts = new();

				//Get all names (in order) or checked serial ports
				foreach (string s in checkedListSerialPort.Items)
				{
					allPorts.Add(s);
				}

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
					TestTimeout = (int)numericUpDownTimeout.Value,
					ComPortLocation = checkedListSerialPort.CheckedItems[panelTestCount].ToString(),
				};

				//Reset panel test counter
				panelTestCount = 0;

				//Set testing to true
				inTest = true;

				// Open the serial port (and let it know what serial port to use).
				gpsDevice.Open(gpsRecord.ComPortLocation);

				// Reset elapsed time.
				elapsedSeconds = 0;

				// Start the timer.
				timer.Enabled = true;
			}
			// If an error occurs...
			catch (Exception ex)
			{
				//Reset GUI to being testing again
				groupBoxSettings.Enabled = true;
				buttonStartSingle.Enabled = true;
				buttonStartPanel.Enabled = true;
				buttonStop.Enabled = false;
				toolStripStatusLabel.Text = "Ready...";
				toolStripStatusLabel.Font = new Font(toolStripStatusLabel.Font, FontStyle.Regular);
				toolStripStatusLabel.ForeColor = SystemColors.ControlText;
				toolStripProgressBar.Value = toolStripProgressBar.Minimum;
				ResetIcons();

				// Alert the user.
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));
			}

			//Wait for async testing to finish
			while (inTest == true)
			{
				await Task.Delay(500);
			}

			// Update user interface.
			groupBoxSettings.Enabled = true;
			buttonStartSingle.Enabled = true;
			buttonStartPanel.Enabled = true;
			buttonStop.Enabled = false;
			toolStripStatusLabel.Font = new Font(toolStripStatusLabel.Font, FontStyle.Regular);
			toolStripStatusLabel.ForeColor = SystemColors.ControlText;
			toolStripProgressBar.Value = toolStripProgressBar.Minimum;

			//Export to .csv file
			ExporttoCsv(gpsRecord);
		}

		private async void ButtonStartPanel_Click(object sender, EventArgs e)
		{
			try
			{
				//Reset icons
				ResetIcons();

				//Check for user input error(s) and let it know isPanel == true.
				CheckUserInput(true);

				//Get both checked ports and all available ports.
				allPorts = new();
				checkedPorts = new();
				foreach (string s in checkedListSerialPort.Items)
				{
					allPorts.Add(s);
				}
				foreach (string s in checkedListSerialPort.CheckedItems)
				{
					checkedPorts.Add(s);
				}


				// Update the user interface.
				groupBoxSettings.Enabled = false;
				buttonStartSingle.Enabled = false;
				buttonStartPanel.Enabled = false;
				buttonStop.Enabled = true;
				toolStripProgressBar.Value = toolStripProgressBar.Minimum;
				toolStripStatusLabel.Font = new Font(toolStripStatusLabel.Font, FontStyle.Regular);
				toolStripStatusLabel.ForeColor = SystemColors.ControlText;

				//Set the timeout value
				Properties.Settings.Default.Timeout = (uint)numericUpDownTimeout.Value;

				//Reset panel test count
				panelTestCount = 0;

				//Test each selected serial port one at a time.
				foreach (string current in checkedPorts)
				{
					//Set testing to true
					inTest = true;

					//Instantiate new gps record for each board and set values
					/* Temporary: Boards are currently not serialized. Future proofing
					 * has the property implemented already. For now, the "serial number" 
					 * will be "Panel"
					 */
					gpsRecord = new()
					{
						IsPanel = true,
						PanelLocation = allPorts.IndexOf(current).ToString(),
						BoardSerialNumber = "Panel",
						UserName = textBoxName.Text,
						TestTimeout = (int)numericUpDownTimeout.Value,
						ComPortLocation = current,
					};

					//Set the timeout value
					Properties.Settings.Default.Timeout = (uint)numericUpDownTimeout.Value;

					// Set up progress bar.
					toolStripProgressBar.Maximum = (int)Properties.Settings.Default.Timeout;

					//Open the serial port (and let it know what serial port to use).
					gpsDevice.Open(current);

					//Wait for comport to finish
					//https://stackoverflow.com/questions/7219653/why-is-access-to-com-port-denied
					Thread.Sleep(500);

					//enable timer
					timer.Enabled = true;

					// Reset elapsed time.
					elapsedSeconds = 0;

					//Wait for any previous test to finish
					while (inTest == true)
					{
						await Task.Delay(1000);
					}

					//add record to csvList
					csvList.Add(gpsRecord);
				}

				//Wait for last test to finish
				while (inTest == true && csvList.Count != panelTestCount)
				{
					await Task.Delay(500);
				}

				// Update user interface.
				groupBoxSettings.Enabled = true;
				buttonStartSingle.Enabled = true;
				buttonStartPanel.Enabled = true;
				buttonStop.Enabled = false;
				toolStripStatusLabel.Font = new Font(toolStripStatusLabel.Font, FontStyle.Regular);
				toolStripStatusLabel.ForeColor = SystemColors.ControlText;
				toolStripProgressBar.Value = toolStripProgressBar.Minimum;

				ExporttoCsv(csvList);
			}
			// If an error occurs...
			catch (Exception ex)
			{
				//Reset GUI to being testing again
				groupBoxSettings.Enabled = true;
				buttonStartSingle.Enabled = true;
				buttonStartPanel.Enabled = true;
				buttonStop.Enabled = false;
				toolStripStatusLabel.Text = "Ready...";
				toolStripStatusLabel.Font = new Font(toolStripStatusLabel.Font, FontStyle.Regular);
				toolStripStatusLabel.ForeColor = SystemColors.ControlText;
				toolStripProgressBar.Value = toolStripProgressBar.Minimum;
				ResetIcons();

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
				//Reset GUI to being testing again
				groupBoxSettings.Enabled = true;
				buttonStartSingle.Enabled = true;
				buttonStartPanel.Enabled = true;
				buttonStop.Enabled = false;
				toolStripStatusLabel.Text = "Ready...";
				toolStripStatusLabel.Font = new Font(toolStripStatusLabel.Font, FontStyle.Regular);
				toolStripStatusLabel.ForeColor = SystemColors.ControlText;
				toolStripProgressBar.Value = toolStripProgressBar.Minimum;
				ResetIcons();

				// Alert the user.
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));
			}
		}

		#endregion

		#region Helper Methods

		/// <summary>
		/// Set the icon to its corresponding gps board.
		/// </summary>
		/// <param name="gpsKey">location key of gpsBoard</param>
		/// <returns></returns>
		private PictureBox SetDictionary(string gpsKey)
		{
			//Set internal counter to 0.
			int count = 0;

			//Remove any null ports (keeps the code from breaking)
			while (allPorts.Count < 20)
			{
				allPorts.Add("empty port" + count);
				count++;
			}

			//If doing a single GPS test, override comport location
			gpsKey = (gpsRecord.IsPanel) ? gpsKey : "Single";

			//Create a dictionary and determine where serial port is.
			Dictionary<string, PictureBox> getPictureBox = new()
			{
				{ allPorts[0], pictureBoxGPS0 },
				{ allPorts[1], pictureBoxGPS1 },
				{ allPorts[2], pictureBoxGPS2 },
				{ allPorts[3], pictureBoxGPS3 },
				{ allPorts[4], pictureBoxGPS4 },
				{ allPorts[5], pictureBoxGPS5 },
				{ allPorts[6], pictureBoxGPS6 },
				{ allPorts[7], pictureBoxGPS7 },
				{ allPorts[8], pictureBoxGPS8 },
				{ allPorts[9], pictureBoxGPS9 },
				{ allPorts[10], pictureBoxGPS10 },
				{ allPorts[11], pictureBoxGPS11 },
				{ allPorts[12], pictureBoxGPS12 },
				{ allPorts[13], pictureBoxGPS13 },
				{ allPorts[14], pictureBoxGPS14 },
				{ allPorts[15], pictureBoxGPS15 },
				{ allPorts[16], pictureBoxGPS16 },
				{ allPorts[17], pictureBoxGPS17 },
				{ allPorts[18], pictureBoxGPS18 },
				{ allPorts[19], pictureBoxGPS19 },

				//for the single board test program
				{ "Single", pictureBoxGPSSingle }
			};

			//Returns photo box with the location of the board.
			return getPictureBox[gpsKey];
		}

		/// <summary>
		/// Resets all the Panel Test and Single Test icons.
		/// </summary>
		private void ResetIcons()
		{
			//TODO: do this in a better and more efficient way when time allows
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

		/// <summary>
		/// Check the user's inputs to determine erors and/or bugs
		/// </summary>
		/// <param name="isPanel"></param>
		/// <exception cref="TestException"></exception>
		private void CheckUserInput(bool isPanel)
		{
			//Check for user name entry
			if (textBoxName.Text == null || textBoxName.Text == "")
			{
				throw new TestException("Please enter your Name in the text box labelled name.");
			}

			//Check for Location and make sure it's accurate
			userLocation = comboBoxUserLocation == null || !UserLocationList.Contains(comboBoxUserLocation.Text) ?
				throw new TestException("Please choose your location.")
				: comboBoxUserLocation.SelectedItem.ToString();

			//Check for a timeout. TODO: Set minimum timeout to 120 seconds
			if (numericUpDownTimeout.Value < MINIMUM_TIMEOUT)
			{
				throw new TestException($"Minimum timeout is {MINIMUM_TIMEOUT}. Please choose a longer testing time.");
			}

			//Check for Serial Port input (and Panel Number for Panel Test)
			//If it's a panel test
			if (isPanel == true)
			{
				//Check for Panel Number
				if (textBoxPanelNumber.Text == null || textBoxPanelNumber.Text == "")
				{
					throw new TestException("Panel Number required for Panel Test");
				}

				else
				{
					switch (checkedListSerialPort.CheckedItems.Count)
					{
						case 0:
							throw new TestException("No serial ports selected. Please check boxes next to ports and try again.");
						case 1:
							throw new TestException("Only one port selected for a Panel Test. Please select a minimum of two ports and try again.");
						default:
							break;
					};

				}

			}

			//If it's a single test
			else
			{
				switch (checkedListSerialPort.CheckedItems.Count)
				{
					case 0:
						throw new TestException("No serial ports selected. Please check boxes next to ports and try again.");
					case 1:
						break;
					default:
						throw new TestException("Only one port can be selected for a Single Test. Please lower selection to one and try again.");
				};
			}
		}
		#endregion

		#region Export using .csvHelper
		// Export data recieved to filepath
		// for panels, create new file and append all board data
		// for singles, create and write new file

		/// <summary>
		/// Panel export to CSV
		/// </summary>
		/// <param name="boardData"></param>
		internal void ExporttoCsv(List<GPSDataRecord> boardData)
		{
			//Create and name .csv file.
			string fileName = DateTime.Now.ToString("MMddyyyy_HHmm") + "_PANEL";

			//set configurations for csv mapping
			var config = new CsvConfiguration(cultureInfo: CultureInfo.InvariantCulture)
			{
				//Trim the whitespace around each field to ensure delimiters are seen
				TrimOptions = TrimOptions.Trim,
			};

			using StreamWriter writer = new(File.Create(filePath + fileName));
			using CsvWriter csv = new(writer, config);
			csv.Context.RegisterClassMap(typeof(GPSRecordMap));

			//write column headers
			csv.WriteHeader(typeof(GPSDataRecord));
			//end header line
			csv.NextRecord();
			//write each board record
			foreach (GPSDataRecord board in boardData)
			{
				//write board data
				csv.WriteRecord(board);

				//flush the writer
				csv.Flush();

				//end the line
				csv.NextRecord();
			}
		}

		internal void ExporttoCsv(GPSDataRecord boardData)
		{
			//Create and name .csv file.
			string fileName = DateTime.Now.ToString("MMddyyyy_HHmm") + "_SINGLE";

			//set configurations for csv mapping
			var config = new CsvConfiguration(cultureInfo: CultureInfo.InvariantCulture)
			{
				//Trim the whitespace around each field to ensure delimiters are seen
				TrimOptions = TrimOptions.Trim,
			};

			using StreamWriter writer = new(filePath + fileName);
			using CsvWriter csv = new(writer, config);
			csv.Context.RegisterClassMap(typeof(GPSRecordMap));

			//write column headers
			csv.WriteHeader(typeof(GPSDataRecord));
			//end header line
			csv.NextRecord();
			//write board record
			csv.WriteRecord(boardData);
			//flush the writer
			csv.Flush();
		}

		#endregion
	}
}