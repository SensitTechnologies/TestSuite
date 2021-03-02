using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Text.RegularExpressions;
using Sensit.TestSDK.Calculations;
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
	public class GPDX303S : SerialDevice, IVoltageReference, ICurrentReference,
		IVoltageController, ICurrentController
	{
		private int channel = 1;

		public int Channel
		{
			get
			{
				return channel;
			}
			set
			{
				// Verify valid value.
				if ((value < 1) || (value > 4))
				{
					throw new DeviceSettingNotSupportedException("Channel must be a number between 1 and 4, inclusive.");
				}

				channel = value;
			}
		}

		/// <summary>
		/// Baud rates supported by the mass flow controller.
		/// </summary>
		public new static List<int> SupportedBaudRates { get; } = new List<int> { 9600, 57600, 115200 };

		#region Reference Device Methods

		public Dictionary<VariableType, double> Readings { get; } = new Dictionary<VariableType, double>
		{
			{ VariableType.Current, 0.0 },
			{ VariableType.Voltage, 0.0 },
		};

		public UnitOfMeasure.Voltage VoltageUnit { get; set; } = UnitOfMeasure.Voltage.Volt;

		public UnitOfMeasure.Current CurrentUnit { get; set; } = UnitOfMeasure.Current.Amp;

		public void Read()
		{
			// Fetch the voltage reading.
			Readings[VariableType.Voltage] = SendQuery(new GPDX303S_SCPI().VOUT(channel).Query());

			// Fetch the current reading.
			Readings[VariableType.Current] = SendQuery(new GPDX303S_SCPI().IOUT(channel).Query());
		}

		#endregion

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

		private float SendQuery(string command)
		{
			float result;
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
				result = Convert.ToSingle(value, CultureInfo.InvariantCulture);
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

		#region Control Device Methods

		public void WriteSetpoint(VariableType type, double setpoint)
		{
			switch (type)
			{
				case VariableType.Current:
					SendCommand(new GPDX303S_SCPI().ISET(channel, Convert.ToSingle(setpoint)).Command());
					break;
				case VariableType.Voltage:
					SendCommand(new GPDX303S_SCPI().VSET(channel, Convert.ToSingle(setpoint)).Command());
					break;
				default:
					throw new DeviceSettingNotSupportedException("Power supply does not support " + type.ToString() + " setpoints.");
			}
		}

		public double ReadSetpoint(VariableType type)
		{
			double result;
			switch (type)
			{
				case VariableType.Current:
					result = SendQuery(new GPDX303S_SCPI().ISET(channel).Query());
					break;
				case VariableType.Voltage:
					// Fetch the voltage reading.
					result = SendQuery(new GPDX303S_SCPI().VSET(channel).Query());
					break;
				default:
					throw new DeviceSettingNotSupportedException("Power supply does not support " + type.ToString() + ".");
			}

			return result;
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

		#endregion
	}
}
