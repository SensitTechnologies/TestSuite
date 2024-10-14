using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Text.RegularExpressions;
using Sensit.TestSDK.Communication;
using Sensit.TestSDK.Exceptions;
using Sensit.TestSDK.Interfaces;
using Sensit.TestSDK.Protocols;

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
		// settings supported by the power supply
		public override List<int> SupportedBaudRates { get; } = [9600, 57600, 115200];
		public override List<int> SupportedDataBits { get; } = [8];
		public override List<Parity> SupportedParity { get; } = [Parity.None];
		public override List<StopBits> SupportedStopBits { get; } = [StopBits.One];
		public override List<Handshake> SupportedHandshake { get; } = [Handshake.None];

		public Dictionary<VariableType, decimal> Readings { get; } = new Dictionary<VariableType, decimal>
		{
			{ VariableType.Current1, 0.0M }, // Channel 1
			{ VariableType.Voltage1, 0.0M },
			{ VariableType.Current2, 0.0M }, // Channel 2
			{ VariableType.Voltage2, 0.0M },
			{ VariableType.Current3, 0.0M }, // Channel 3
			{ VariableType.Voltage3, 0.0M },
			{ VariableType.Current4, 0.0M }, // Channel 4
			{ VariableType.Voltage4, 0.0M }
		};

		public Dictionary<VariableType, decimal> Setpoints { get; } = new Dictionary<VariableType, decimal>
		{
			{ VariableType.Current1, 0.0M }, // Channel 1
			{ VariableType.Voltage1, 0.0M },
			{ VariableType.Current2, 0.0M }, // Channel 2
			{ VariableType.Voltage2, 0.0M },
			{ VariableType.Current3, 0.0M }, // Channel 3
			{ VariableType.Voltage3, 0.0M },
			{ VariableType.Current4, 0.0M }, // Channel 4
			{ VariableType.Voltage4, 0.0M }
		};

		public string Message { get; }

		public void WriteThenRead()
		{
			// Fetch current and voltage readings from each channel.
			Readings[VariableType.Voltage1] = SendQuery(new SCPI_GPDX303S().VOUT(1).Query());
			Readings[VariableType.Current1] = SendQuery(new SCPI_GPDX303S().IOUT(1).Query());
			Readings[VariableType.Voltage2] = SendQuery(new SCPI_GPDX303S().VOUT(2).Query());
			Readings[VariableType.Current2] = SendQuery(new SCPI_GPDX303S().IOUT(2).Query());
			Readings[VariableType.Voltage3] = SendQuery(new SCPI_GPDX303S().VOUT(3).Query());
			Readings[VariableType.Current3] = SendQuery(new SCPI_GPDX303S().IOUT(3).Query());
			Readings[VariableType.Voltage4] = SendQuery(new SCPI_GPDX303S().VOUT(4).Query());
			Readings[VariableType.Current4] = SendQuery(new SCPI_GPDX303S().IOUT(4).Query());
		}

		public void Write(VariableType variable, decimal value)
		{
			switch (variable)
			{
				case VariableType.Current1:
					SendCommand(new SCPI_GPDX303S().ISET(1, value).Command());
					break;

				case VariableType.Current2:
					SendCommand(new SCPI_GPDX303S().ISET(2, value).Command());
					break;

				case VariableType.Current3:
					SendCommand(new SCPI_GPDX303S().ISET(3, value).Command());
					break;

				case VariableType.Current4:
					SendCommand(new SCPI_GPDX303S().ISET(4, value).Command());
					break;

				case VariableType.Voltage1:
					SendCommand(new SCPI_GPDX303S().VSET(1, value).Command());
					break;

				case VariableType.Voltage2:
					SendCommand(new SCPI_GPDX303S().VSET(2, value).Command());
					break;

				case VariableType.Voltage3:
					SendCommand(new SCPI_GPDX303S().VSET(3, value).Command());
					break;

				case VariableType.Voltage4:
					SendCommand(new SCPI_GPDX303S().VSET(4, value).Command());
					break;

				default:
					throw new DeviceSettingNotSupportedException("GPDX303S power supply does not support " + variable.ToString() + ".");
			}

			// Remember the setpoint.
			Setpoints[variable] = value;
		}

		public void SetControlMode(ControlMode mode)
		{
			switch (mode)
			{
				case ControlMode.Passive:
					// Turn output off.
					SendCommand(new SCPI_GPDX303S().OUT(false).Command());
					break;
				case ControlMode.Active:
					// Turn output on.
					SendCommand(new SCPI_GPDX303S().OUT(true).Command());
					break;
				default:
					throw new DeviceSettingNotSupportedException("Cannot set GPDX303S power supply control mode:"
						+ Environment.NewLine + "Unrecognized mode.");
			}
		}

		private decimal ReadSetpoint(VariableType type)
		{
			decimal result;
			switch (type)
			{
				case VariableType.Current1:
					result = SendQuery(new SCPI_GPDX303S().ISET(1).Query());
					break;
				case VariableType.Current2:
					result = SendQuery(new SCPI_GPDX303S().ISET(2).Query());
					break;
				case VariableType.Current3:
					result = SendQuery(new SCPI_GPDX303S().ISET(3).Query());
					break;
				case VariableType.Current4:
					result = SendQuery(new SCPI_GPDX303S().ISET(4).Query());
					break;
				case VariableType.Voltage1:
					result = SendQuery(new SCPI_GPDX303S().VSET(1).Query());
					break;
				case VariableType.Voltage2:
					result = SendQuery(new SCPI_GPDX303S().VSET(2).Query());
					break;
				case VariableType.Voltage3:
					result = SendQuery(new SCPI_GPDX303S().VSET(3).Query());
					break;
				case VariableType.Voltage4:
					result = SendQuery(new SCPI_GPDX303S().VSET(4).Query());
					break;
				default:
					throw new DeviceSettingNotSupportedException("GPDX303S power supply does not support " + type.ToString() + ".");
			}

			// Update the setpoint.
			Setpoints[type] = result;

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
				throw new DevicePortException("Could not read from GPDX303S power supply."
					+ Environment.NewLine + ex.Message);
			}
			catch (TimeoutException ex)
			{
				throw new DeviceCommunicationException("No response from GPDX303S power supply."
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
				throw new DevicePortException("Could not read from GPDX303S power supply."
					+ Environment.NewLine + ex.Message);
			}
			catch (TimeoutException ex)
			{
				throw new DeviceCommunicationException("No response from GPDX303S power supply."
					+ Environment.NewLine + ex.Message);
			}

			return result;
		}
	}
}
