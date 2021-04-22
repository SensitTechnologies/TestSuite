using System;
using System.Collections.Generic;
using System.Text;
using Sensit.TestSDK.Calculations;
using Sensit.TestSDK.Communication;
using Sensit.TestSDK.Exceptions;
using Sensit.TestSDK.Interfaces;

namespace Sensit.TestSDK.Devices
{
	public class SensitG2GLT : SerialDevice
	{
		// 115200 and 230400 baud are supported.
		public override List<int> SupportedBaudRates { get; } = new List<int> { 115200, 230400 };

		const int NUM_RETRIES = 20;

		#region Enumerations

		public enum CMDS
		{
			NULL = 0,
			ACK = 0x06,
			NAK = 0x15,
			RESPONSE = '#',
			STATUS_INFO = 'a',
			MONITORING_MODE = 'b',
			TRAINING_MODE = 'c',
			GET_INSTRUMENT_INFO = 'd',
			GET_LIVE_DATA = 'e',
			UPDATE_SENSOR_READING = 'f',
			PERFORM_AUTOZERO = 'g',
			FLOW_BLOCKED = 'h',
			CLEAR_FLOW_BLOCKED = 'i',
			SELECT_BH_MODE = 'j',
			START_BH_TEST = 'k',
			EXIT_BH_TEST = 'l',
			GET_BH_DATA = 'm',
			BATTERY_LOW = 'n',
			CLEAR_BATTERY_LOW = 'o',
			START_LEAKSEARCH = 'p',
			EXIT_LEAKSEARCH = 'q',
			GET_LEAK_SEARCH_DATA = 'r',
			START_PURGE_TEST = 's',
			EXIT_PURGE_TEST = 't',
			GET_PURGE_TEST_DATA = 'u',
			GET_DISPLAY_BUFF = 'v',
			START_STREAMING = 'w',
			STOP_STREAMING = 'x',
			START_NSC = 'y',
			CLEAR_NSC = 'z',
			START_NSR = 'A',
			CLEAR_NSR = 'B',
			CAL_DUE = 'C',
			START_TICK = 'D',
			EXIT_TICK = 'E',
			SELECT_CO_TEST = 'F',
			START_CO_TEST = 'G',
			EXIT_CO_TEST = 'H',
			SELECT_CF_TEST = 'I',
			START_CF_TEST = 'J',
			EXIT_CF_TEST = 'K',
			START_WDPK = 'L',
			EXIT_WDPK = 'M',
			SELECT_IM_MODE = 'N',
			IM_ACK = 'O',
			IM_EXIT = 'P',
			TICK_RESET_CMD = 'Q',
			START_STAND_BY = 'R',
			EXIT_STAND_BY = 'S'
		}

		public enum SENSOR_ID
		{
			NONE = 0,
			EX_TC,
			EX,
			CO,
			O2,
			H2S,
			HCN,
		}

		public enum UNIT
		{
			PPM = 0,
			LEL,
			LEL1DP,
			LEL2DP,
			VOL,
			VOL1DP,
			VOL2DP,
		}

		public enum LEL_UNIT
		{
			VOL = 0,
			LEL
		}

		public enum DEVICE_STATE
		{
			UNKNOWN = 0,
			WAIT,
			STARTUP,
			WARMUP,
			NORMAL,
			AUTOZERO,
			FLOW_BLOCKED,
			BARHOLE_START,
			BARHOLE_IN_PROGRESS,
			BARHOLE_RESULT,
			MENU,
			LEAK_SEARCH,
			PURGE_TEST,
			SHUTTING_DOWN,
			CO_START,
			CO_IN_PROGRESS,
			CO_RESULT,
			CF_START,
			CF_IN_PROGRESS,
			CF_RESULT,
			WORK_DISPLAY_PEAK,
			IM_SELECT_ACK,
			IM_RUN,
			IM_EXIST_ACK,
			STAND_BY
		}

		public enum SENSOR_STATE
		{
			NORMAL = 0,
			NSC,
			NSR,
			FAIL,
			NONE
		}

		public enum DEVICE_MODE
		{
			MONITORING = 0,
			TRAINING,
			NONE,
		}

		public enum TC_MODE
		{
			PRO = 0,
			NAT,
		}

		public enum TICK_STATE
		{
			DISABLE = 0,
			ENABLE,
			NONE
		}

		public enum ALARM_STATE
		{
			NONE = 0,
			LOW,
			HIGH
		}

		#endregion

		#region Reference Device Methods

		public UnitOfMeasure.Concentration ConcentrationUnit { get; set; } = UnitOfMeasure.Concentration.PartsPerMillion;

		public Gas GasSelection { get; set; }

		public Dictionary<VariableType, double> Readings { get; private set; } = new Dictionary<VariableType, double>
		{
			{ VariableType.GasConcentration, 0.0 }
		};

		public void Read()
		{
			// Read sensor data from instrument.
			string message = TrySendingCommand(CreateMessage(CMDS.GET_LIVE_DATA));

			// Parse the response.
			G2StatusInfo g2StatusInfo = AnalyzeLiveData(message);

			switch (GasSelection)
			{
				case Gas.Methane:
					// TODO:  Parse the response.
					//Readings[VariableType.GasConcentration] = g2StatusInfo.SensorLiveData[0].Reading;
					break;

				case Gas.Oxygen:
					// TODO:  Parse the response.
					//Readings[VariableType.GasConcentration] = g2StatusInfo.SensorLiveData[1].Reading;
					break;

				default:
					throw new DeviceSettingNotSupportedException("Gas selection " + GasSelection.ToString() + " is not supported.");
			}

			// TODO:  Parse the reading and add it to the response queue.

		}

		#endregion

		private string TrySendingCommand(string command)
		{
			// how many times to retry a command
			uint retries = NUM_RETRIES;

			// Attempt sending command until we succeed or run out of retries.
			string reply;
			bool result = false;
			string errorMessage = string.Empty;
			do
			{
				// Send the command over the serial port.
				Console.Write(command);
				Port.Write(command);

				// Read the reply.
				reply = ReadBlocking();

				// If no reply was received...
				if (string.Compare(reply, string.Empty) == 0)
				{
					errorMessage = "No response from G2-GLT.";
				}
				// If checksum was invalid...
				else if (ValidateChecksum(reply) == false)
				{
					errorMessage = "Invalid checksum from G2-GLT.";
				}
				// If message was received and was valid...
				else
				{
					// Success!  We're done!
					result = true;
				}

				// Remember how many times we've attempted communication.
				retries--;
			} while ((result == false) && (retries != 0));

			// If we never got a valid response to our message...
			if (result == false)
				// Alert the application that something went wrong.
				throw new DeviceCommandFailedException(errorMessage);

			// Return the reply from the instrument.
			Console.Write(reply);
			return reply;
		}

		private static bool ValidateChecksum(string message)
		{
			// Convert the message to a byte array.
			byte[] messageBytes = Encoding.ASCII.GetBytes(message);

			ushort rx_crc;
			ushort calc_crc;
			int i = 0;
			int max_i = messageBytes.GetUpperBound(0) - 1;
			int size = 0;
			while (messageBytes[i++] != (byte)'*')
			{
				if (i >= max_i) return false;
			}

			size = i - 1;
			calc_crc = Checksum.Crc16(messageBytes);
			string rx_crc_str = "";
			while (messageBytes[i] != (byte)'\n')
			{
				rx_crc_str = rx_crc_str + ((char)messageBytes[i++]).ToString();
			}
			rx_crc = ushort.Parse(rx_crc_str);
			if (rx_crc == calc_crc) { return true; }
			else { return false; }
		}

		private class G2StatusInfo
		{
			public DEVICE_STATE DeviceState { get; set; }

			public SENSOR_STATE SensorState { get; set; }

			public DEVICE_MODE DeviceMode { get; set; }

			public TICK_STATE TickState { get; set; }

			public bool CalibrationDue { get; set; }

			public bool BatteryLow { get; set; }
			
			public string ModelName { get; set; }

			public ushort SerialNumber { get; set; }

			public string FirmwareRev { get; set; }

			public TC_MODE NatProMode { get; set; }

			public ushort LELEquivalent { get; set; }

			public bool BarholeEnable { get; set; }

			public bool LeakSearchEnable { get; set; }

			public bool PurgeTestEnable { get; set; }

			public bool COTestEnable { get; set; }

			public bool CFTestEnable { get; set; }

			public bool NSCEnable { get; set; }

			public bool NSREnable { get; set; }

			public bool FlowBlockVisible { get; set; }

			/// <summary>
			/// Unit of measure when in LEL range.
			/// </summary>
			public LEL_UNIT LELUnit { get; set; }

			public ushort ExPPMRange { get; set; }

			public ushort LeakSearchPPM { get; set; }

			public ushort SensorCount { get; set; }

			/// <summary>
			/// Configuration of the instruments' sensors
			/// </summary>
			public List<G2SensorConfig> Sensors { get; set; } = new List<G2SensorConfig>();

			public bool WDPKTestEnable { get; set; }

			public bool InertModeTestEnable { get; set; }

			public bool StandbyEnable { get; set; }

			/// <summary>
			/// Actual data readings from sensors
			/// </summary>
			public List<G2SensorReading> SensorLiveData { get; set; } = new List<G2SensorReading>();
		}

		private class G2SensorConfig
		{
			/// <summary>
			/// Type of sensor (i.e. what gas it detects)
			/// </summary>
			public SENSOR_ID SensorID { get; set; }

			/// <summary>
			/// Low Alarm value
			/// </summary>
			public double LowAlarm { get; set; }

			/// <summary>
			/// High Alarm value
			/// </summary>
			public double HighAlarm { get; set; }

			/// <summary>
			/// Sensor's range
			/// </summary>
			public double MaxValue { get; set; }
		}

		private class G2SensorReading
		{
			public SENSOR_ID SensorID { get; set; }

			public int Reading { get; set; }

			public UNIT UnitOfMeasure { get; set; }

			public SENSOR_STATE SensorState { get; set; }

			public ALARM_STATE AlarmState { get; set; }
		}

		private G2StatusInfo AnalyzeStatusInfo(string message)
		{
			// Split the string using commas to separate each word.
			char[] separators = new char[] { ',', '*', '\n' };
			string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);

			int i = 2;

			// str[0] = "$#"
			// str[1] = CMD.GET_INSTRUMENT_INFO
			
			G2StatusInfo g2Status = new G2StatusInfo();

			if (words.Length >= i + 1)
				g2Status.DeviceState = (DEVICE_STATE)ushort.Parse(words[i++]);

			if (words.Length >= i + 1)
				g2Status.SensorState = (SENSOR_STATE)ushort.Parse(words[i++]);

			if (words.Length >= i + 1)
				g2Status.DeviceMode = (DEVICE_MODE)ushort.Parse(words[i++]);

			if (words.Length >= i + 1)
				g2Status.CalibrationDue = Convert.ToBoolean(int.Parse(words[i++]));

			if (words.Length >= i + 1)
				g2Status.BatteryLow = Convert.ToBoolean(int.Parse(words[i++]));

			if (words.Length >= i + 1)
				g2Status.TickState = (TICK_STATE)ushort.Parse(words[i++]);

			return g2Status;
		}

		private G2StatusInfo AnalyzeInstrumentInfo(string message)
		{
			// Split the string using commas to separate each word.
			char[] separators = new char[] { ',','*','\n' };
			string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);

			int max_values = words.GetUpperBound(0);

			int i = 2;

			// words[0] = "$#"
			// words[1] = CMD.GET_INSTRUMENT_INFO

			G2StatusInfo g2Status = new G2StatusInfo();

			if (words.Length >= i + 1)
				g2Status.DeviceState = (DEVICE_STATE)ushort.Parse(words[i++]);

			if (words.Length >= i + 1)
				g2Status.SensorState = (SENSOR_STATE)ushort.Parse(words[i++]);

			if (words.Length >= i + 1)
				g2Status.DeviceMode = (DEVICE_MODE)ushort.Parse(words[i++]);

			if (words.Length >= i + 1)
				g2Status.CalibrationDue = Convert.ToBoolean(int.Parse(words[i++]));

			if (words.Length >= i + 1)
				g2Status.BatteryLow = Convert.ToBoolean(int.Parse(words[i++]));

			if (words.Length >= i + 1)
				g2Status.TickState = (TICK_STATE)ushort.Parse(words[i++]);

			if (words.Length >= i + 1)
				g2Status.ModelName = words[i++];

			if (words.Length >= i + 1)
				g2Status.SerialNumber = ushort.Parse(words[i++]);

			if (words.Length >= i + 1)
				g2Status.FirmwareRev = words[i++];

			if (words.Length >= i + 1)
				g2Status.NatProMode = (TC_MODE)ushort.Parse(words[i++]);

			if (words.Length >= i + 1)
				g2Status.LELEquivalent = ushort.Parse(words[i++]);

			if (words.Length >= i + 1)
				g2Status.BarholeEnable = Convert.ToBoolean(int.Parse(words[i++]));

			if (words.Length >= i + 1)
				g2Status.LeakSearchEnable = Convert.ToBoolean(int.Parse(words[i++]));

			if (words.Length >= i + 1)
				g2Status.PurgeTestEnable = Convert.ToBoolean(int.Parse(words[i++]));

			if (words.Length >= i + 1)
				g2Status.COTestEnable = Convert.ToBoolean(int.Parse(words[i++]));

			if (words.Length >= i + 1)
				g2Status.CFTestEnable = Convert.ToBoolean(int.Parse(words[i++]));

			if (words.Length >= i + 1)
				g2Status.NSCEnable = Convert.ToBoolean(int.Parse(words[i++]));

			if (words.Length >= i + 1)
				g2Status.NSREnable = Convert.ToBoolean(int.Parse(words[i++]));

			if (words.Length >= i + 1)
				g2Status.FlowBlockVisible = Convert.ToBoolean(int.Parse(words[i++]));

			if (words.Length >= i + 1)
				g2Status.LELUnit = (LEL_UNIT)Enum.Parse(typeof(LEL_UNIT), words[i++]); //(LEL_MODE)UInt16.Parse(words[i++]);

			if (words.Length >= i + 1)
				g2Status.ExPPMRange = ushort.Parse(words[i++]);

			if (words.Length >= i + 1)
				g2Status.LeakSearchPPM = ushort.Parse(words[i++]);

			if (words.Length >= i + 1)
				g2Status.SensorCount = ushort.Parse(words[i++]);

			// For each sensor in the instrument...
			for (int j = 0; j < g2Status.SensorCount; j++)
			{
				if (i >= max_values - 1)
					break;

				if (words.Length < i + 4)
					break;

				G2SensorConfig sensorConfig = new G2SensorConfig
				{
					SensorID = (SENSOR_ID)ushort.Parse(words[i++]),
					LowAlarm = ushort.Parse(words[i++]),
					HighAlarm = ushort.Parse(words[i++]),
					MaxValue = ushort.Parse(words[i++]),
				};

				g2Status.Sensors.Add(sensorConfig);
			}

			if (words.Length >= i + 1)
				g2Status.WDPKTestEnable = Convert.ToBoolean(int.Parse(words[i++]));

			if (words.Length >= i + 1)
				g2Status.InertModeTestEnable = Convert.ToBoolean(int.Parse(words[i++]));

			if (words.Length >= i + 1)
				g2Status.StandbyEnable = Convert.ToBoolean(int.Parse(words[i++]));

			#region "Firmware Version Specific Conditions"

			// Firmware versions greater than 2.02 contain CO test.
			// For versions less than this, consider the CO test disabled.
			if (Convert.ToDouble(g2Status.FirmwareRev) < 2.02)
				g2Status.COTestEnable = g2Status.CFTestEnable = false;

			#endregion

			return g2Status;
		}

		private G2StatusInfo AnalyzeLiveData(string message)
		{
			// Split the string using commas to separate each word.
			char[] separators = new char[] { ',', '*', '\n' };
			string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);

			int max_values = words.GetUpperBound(0);

			int i = 2;

			// str[0] = "$#"
			// str[1] = CMD.GET_INSTRUMENT_INFO

			G2StatusInfo g2Status = new G2StatusInfo();

			g2Status.DeviceState = (DEVICE_STATE)ushort.Parse(words[i++]);

			g2Status.SensorState = (SENSOR_STATE)ushort.Parse(words[i++]);

			g2Status.DeviceMode = (DEVICE_MODE)ushort.Parse(words[i++]);
			g2Status.CalibrationDue = Convert.ToBoolean(int.Parse(words[i++]));
			g2Status.BatteryLow = Convert.ToBoolean(int.Parse(words[i++]));
			g2Status.TickState = (TICK_STATE)ushort.Parse(words[i++]);

			// For each sensor in the instrument...
			for (int j = 0; j < 4; j++)
			{
				if (i >= max_values - 1)
					break;

				G2SensorReading sr = new G2SensorReading();
				sr.SensorID = (SENSOR_ID)ushort.Parse(words[i++]);

				sr.Reading = int.Parse(words[i++]);
				sr.UnitOfMeasure = (UNIT)ushort.Parse(words[i++]);
				sr.SensorState = (SENSOR_STATE)ushort.Parse(words[i++]);
				sr.AlarmState = (ALARM_STATE)ushort.Parse(words[i++]);

				g2Status.SensorLiveData.Add(sr);
			}

			return g2Status;
		}

		private string ReadBlocking()
		{
			string message = string.Empty;

			try
			{
				// Read from the serial port.
				while (Port.BytesToRead != 0)
				{
					message += Port.ReadExisting();
				}

				// Flush the port.
				Port.DiscardInBuffer();
			}
			catch (InvalidOperationException ex)
			{
				throw new DevicePortException("Could not read from G2-GLT."
					+ Environment.NewLine + ex.Message);
			}
			catch (TimeoutException ex)
			{
				throw new DeviceCommunicationException("No response from G2-GLT."
					+ Environment.NewLine + ex.Message);
			}

			return message;
		}

		private string CreateMessage(CMDS command)
		{
			// Create a string builder, and the message starts with "$".
			StringBuilder message = new StringBuilder("$", 10);

			// Add the command.
			message.Append((char)command);

			// Calculate checksum and convert to string.
			string checksum = Checksum.Crc16(Encoding.ASCII.GetBytes(message.ToString())).ToString();

			// Add checksum to the message, preceeded by an asterisk.
			message.Append('*' + checksum + '\n');

			return message.ToString();
		}

		private string CreateMessage(CMDS command, SENSOR_ID sensor, uint ppm)
		{
			// Create a byte array.
			byte[] outbuff = new byte[30];

			// Keep track of the message length.
			int i = 0;

			// Message starts with "$".
			outbuff[i++] = (byte)'$';

			// Add the command.
			outbuff[i++] = (byte)command;

			// Add comma delimiter.
			outbuff[i++] = (byte)',';

			// Add the sensor ID.
			string str = ((int)sensor).ToString();
			for (int j = 0; j < str.Length; j++)
			{
				outbuff[i++] = (byte)str[j];
			}

			// Add comma delimiter.
			outbuff[i++] = (byte)',';

			// Add sensor data.
			str = ppm.ToString();
			for (int j = 0; j < str.Length; j++)
			{
				outbuff[i++] = (byte)str[j];
			}

			// Add comma delimiter.
			outbuff[i++] = (byte)',';

			// Add unit of measure.
			str = ((int)UNIT.PPM).ToString();
			for (int j = 0; j < str.Length; j++)
			{
				outbuff[i++] = (byte)str[j];
			}

			// Calculate checksum.
			ushort crc_value = Checksum.Crc16(outbuff);

			// Checksum is preceeded by an asterisk.
			outbuff[i++] = (byte)'*';

			// Add the checksum to the message.
			string crc_str = crc_value.ToString();
			int crc_str_size = crc_str.Length;
			for (int j = 0; j < crc_str_size; j++)
			{
				outbuff[i++] = (byte)crc_str[j];
			}

			// Terminate message with newline.
			outbuff[i++] = (byte)('\n');

			return Encoding.ASCII.GetString(outbuff);
		}
	}
}
