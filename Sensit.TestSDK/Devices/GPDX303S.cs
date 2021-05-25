using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using Sensit.TestSDK.Communication;
using Sensit.TestSDK.Exceptions;
using Sensit.TestSDK.Interfaces;

namespace Sensit.TestSDK.Devices
{
	/// <summary>
	/// Communication driver for a GWInstek programmable power supply.
	/// </summary>
	/// <remarks>
	/// Product Website:
	/// https://www.gwinstek.com/en-global/products/detail/GPD-Series
	/// This is a four-channel programmable linear DC power supply.
	/// It communicates using a serial port and SCPI commands.
	/// </remarks>
	public class GPDX303S : SerialDevice, IDevice
	{
		private int _channel = 1;

		private int Channel
		{
			get => _channel;
			set
			{
				if ((value < 1) || (value > 4))
				{
					throw new DeviceSettingNotSupportedException("Channel must be a number between 1 and 4, inclusive.");
				}

				_channel = value;
			}
		}

		/// <summary>
		/// Baud rates supported by the mass flow controller.
		/// </summary>
		public override List<int> SupportedBaudRates { get; } = new List<int> { 9600, 57600, 115200 };

		public Dictionary<VariableType, decimal> Readings { get; } = new Dictionary<VariableType, decimal>
		{
			{ VariableType.Current, 0.0M },
			{ VariableType.Voltage, 0.0M },
		};

		public string Message { get; }

		public void Read()
		{
			// Fetch the voltage reading.
			Readings[VariableType.Voltage] = SendQuery(new GPDX303S_SCPI().VOUT(Channel).Query());

			// Fetch the current reading.
			Readings[VariableType.Current] = SendQuery(new GPDX303S_SCPI().IOUT(Channel).Query());
		}

		public void Write(VariableType variable, decimal value)
		{
			switch (variable)
			{
				case VariableType.Current:
					SendCommand(new GPDX303S_SCPI().ISET(Channel, Convert.ToSingle(value)).Command());
					break;

				case VariableType.Voltage:
					SendCommand(new GPDX303S_SCPI().VSET(Channel, Convert.ToSingle(value)).Command());
					break;

				case VariableType.Channel:
					Channel = (int)value;
					break;

				default:
					throw new DeviceSettingNotSupportedException("Power supply does not support " + variable.ToString() + ".");
			}
		}

		public void SetControlMode(ControlMode mode)
		{
			switch (mode)
			{
				case ControlMode.Passive:
					// Turn output off.
					SendCommand(new GPDX303S_SCPI().OUT(false).Command());
					break;
				case ControlMode.Active:
					// Turn output on.
					SendCommand(new GPDX303S_SCPI().OUT(true).Command());
					break;
				default:
					throw new DeviceSettingNotSupportedException("Cannot set power supply control mode:"
						+ Environment.NewLine + "Unrecognized mode.");
			}
		}

		private decimal ReadSetpoint(VariableType type)
		{
			decimal result;
			switch (type)
			{
				case VariableType.Channel:
					result = Channel;
					break;
				case VariableType.Current:
					result = SendQuery(new GPDX303S_SCPI().ISET(Channel).Query());
					break;
				case VariableType.Voltage:
					// Fetch the voltage reading.
					result = SendQuery(new GPDX303S_SCPI().VSET(Channel).Query());
					break;
				default:
					throw new DeviceSettingNotSupportedException("Power supply does not support " + type.ToString() + ".");
			}

			return result;
		}

		private void SendCommand(string command)
		{
			try
			{
				// Write the command to the device.
				Port.WriteLine(command);
			}
			catch (InvalidOperationException ex)
			{
				throw new DevicePortException("Could not read from power supply."
					+ Environment.NewLine + ex.Message);
			}
			catch (TimeoutException ex)
			{
				throw new DeviceCommunicationException("No response from power supply."
					+ Environment.NewLine + ex.Message);
			}
		}

		private decimal SendQuery(string command)
		{
			decimal result;
			try
			{
				// Write the command to the device.
				Port.WriteLine(command);

				// Read the response.
				string message = Port.ReadLine();

				// Remove any newlines or tabs.
				message = Regex.Replace(message, @"\t|\n|\r", "");

				// Split the string using spaces to separate each word.
				char[] separators = new char[] { ' ' };
				string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);

				// Remove any non-digit characters.
				string value = words[words.Length - 1].Trim('V', 'A');

				// Convert the last word to a number.
				result = Convert.ToDecimal(value, CultureInfo.InvariantCulture);
			}
			catch (InvalidOperationException ex)
			{
				throw new DevicePortException("Could not read from power supply."
					+ Environment.NewLine + ex.Message);
			}
			catch (TimeoutException ex)
			{
				throw new DeviceCommunicationException("No response from power supply."
					+ Environment.NewLine + ex.Message);
			}

			return result;
		}
	}
}
