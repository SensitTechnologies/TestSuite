using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using Sensit.TestSDK.Communication;
using Sensit.TestSDK.Exceptions;

namespace Sensit.TestSDK.Devices
{
    /// <summary>
    /// Software control for the Ocean controls KTA-22x relay module. 
    /// </summary>
    public class KTA22x : SerialDevice
	{
        // Communication address as defined by the relay module. 
        // This address is module specific, but all relay modules respond to an address of 0
        private const int ADDRESS = 0;

        /// <summary>
        /// Defines the physical number of relay channels that the relay module supports.
        /// </summary>
        public const int MAX_RELAY_CHANNELS = 8;

		// supported serial settings
		public override List<int> SupportedBaudRates { get; } = new List<int> { 9600 };
		public override List<int> SupportedDataBits { get; } = new List<int> { 8 };
		public override List<Parity> SupportedParity { get; } = new List<Parity> { Parity.None };
		public override List<StopBits> SupportedStopBits { get; } = new List<StopBits> { StopBits.One };
		public override List<Handshake> SupportedHandshake { get; } = new List<Handshake> { Handshake.None };

        /// <summary>
        /// Turns on a single relay. Command is @AA ON X<CR>.
        /// </summary>
        /// <param name="relay">1 indexed relay ID.</param>
        public void TurnRelayOn(int relay)
        {
            if (relay <= 0)
            {
                throw new DeviceSettingNotSupportedException("Relay ID must be greater than 0.");
            }
            SetRelay(relay, true);
        }

        /// <summary>
        /// Turns off a single relay. Command is @AA OF X<CR>.
        /// </summary>
        /// <param name="relay">1 indexed relay ID</param>
        public void TurnRelayOff(int relay)
        {
            if (relay <= 0)
            {
                throw new DeviceSettingNotSupportedException("Relay ID must be greater than 0.");
            }
            SetRelay(relay, false);
        }

		/// <summary>
		/// Turns off all relays. Command is @AA OF 0<CR>.
		/// </summary>
		public void TurnAllRelaysOff()
		{
			SetRelay(0, false);
		}

		/// <summary>
		/// Sets on/off state of single relay. Command is @AA (ON/OF) X<CR>. 
		/// </summary>
		/// <param name="relay">1 indexed relay ID. a value of 0 will be applied to all relays</param>
		/// <param name="on">True if the state should be set to on.</param>
		private void SetRelay(int relay, bool on)
        {
            // Form the command.
            string state = on ? "ON" : "OF";
            string command = $"@{ADDRESS:D2} {state} {relay}\r";

            // Send the command.
            Write(command);
        }

		/// <summary>
		/// Reads the status of all relays in the relay module.
		/// </summary>
		/// <returns>true if any of the relays are on or false if no relays are on</returns>
		public bool AreAnyRelaysOn()
		{
			string command = $"@{ADDRESS:D2} RS 0\r";

			string response = WriteThenRead(command);

			try
			{
				// Split the input string by space
				string[] parts = response.Split(' ');

				if (parts.Length < 2)
				{
					return false;
				}
				// Extract the binary value part
				int decimalValue = int.Parse(parts[1]);
				return decimalValue > 0;
			}
			catch (ArgumentNullException ex)
			{
				throw new DeviceCommunicationException("Invalid response from relay module"
					+ Environment.NewLine + ex.Message);
			}
			catch (FormatException ex)
			{
				throw new DeviceCommunicationException("Invalid response from relay module"
					+ Environment.NewLine + ex.Message);
			}
			catch (OverflowException ex)
			{
				throw new DeviceCommunicationException("Invalid response from relay module."
					+ Environment.NewLine + ex.Message);
			}
		}

		/// <summary>
		/// Reads the status of all the relay channels
		/// </summary>
		/// <returns>The read response string from the relay module</returns>
		public string ReadAllRelayStatus()
		{
			string command = $"@{ADDRESS:D2} RS 0\r";

			return WriteThenRead(command);
		}

		/// <summary>
		/// Reads the status of a single relay and returns true if it is on or false if not.
		/// </summary>
		/// <param name="relay">The relay ID to check the status of.</param>
		/// <returns></returns>
		public bool IsRelayOn(int relay)
		{
			// Example command is "@00 RS X\r", where X is relay number.
			string command = $"@{ADDRESS:D2} RS " + relay + "\r";

			// Example response is "#00 X\r", where X is 0 or 1.
			string response = WriteThenRead(command);

			// Split the input string by space
			string[] parts = response.Split(' ');

			// Extract the decimal value part
			try
			{
				int decimalValue = int.Parse(parts[1]);

				// Check if value is 0 or 1.
				bool status = ((decimalValue & 1) != 0);

				return status;
			}
			catch (ArgumentNullException ex)
			{
				throw new DeviceCommunicationException("Invalid response from relay module"
					+ Environment.NewLine + ex.Message);
			}
			catch (FormatException ex)
			{
				throw new DeviceCommunicationException("Invalid response from relay module"
					+ Environment.NewLine + ex.Message);
			}
			catch (OverflowException ex)
			{
				throw new DeviceCommunicationException("Invalid response from relay module."
					+ Environment.NewLine + ex.Message);
			}
		}

		/// <summary>
		/// Sends the command via the serial port.
		/// </summary>
		/// <param name="data">The command to be sent over the serial port.</param>
		private void Write(string data)
        {
            try
            {
				Port.Write(data);
			}
			catch (InvalidOperationException ex)
			{
				throw new DevicePortException("Could not write to relay module."
					+ Environment.NewLine + ex.Message);
			}
			catch (ArgumentNullException ex)
			{
				throw new DeviceSettingNotSupportedException("Tried to send an empty string to relay module."
					+ Environment.NewLine + ex.Message);
			}
			catch (TimeoutException ex)
			{
				throw new DeviceCommunicationException("No response from relay module."
					+ Environment.NewLine + ex.Message);
			}
		}

        private string WriteThenRead(string data)
        {
            try
            {
				Port.DiscardInBuffer();

                Port.Write(data);

				string response = Port.ReadLine();

				Port.DiscardInBuffer();

				return response;
			}
			catch (IOException ex)
			{
				throw new DevicePortException("Could not communicate with relay module."
					+ Environment.NewLine + ex.Message);
			}
			catch (InvalidOperationException ex)
			{
				throw new DevicePortException("Could not communicate with relay module."
					+ Environment.NewLine + ex.Message);
			}
			catch (TimeoutException ex)
			{
				throw new DeviceCommunicationException("No response from relay module."
					+ Environment.NewLine + ex.Message);
			}
		}
    }
}
