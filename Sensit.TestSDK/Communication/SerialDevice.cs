using System;
using System.Collections.Generic;
using System.IO.Ports;
using Sensit.TestSDK.Exceptions;

namespace Sensit.TestSDK.Communication
{
	public abstract class SerialDevice : IDisposable
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <remarks>
		/// Declaring an internal constructor means this class can only be extended
		/// within the SDK.
		/// https://stackoverflow.com/questions/61551474/why-are-internal-fields-preferable-to-protected-fields-in-an-abstract-class
		/// </remarks>
		internal SerialDevice() { }

		// port used to communicate with mass flow controller
		// (protected means it's accessible within derived classes, but not outside them)
		protected SerialPort Port { get; } = new SerialPort();

		/// <summary>
		/// List of supported baud rates
		/// </summary>
		public abstract List<int> SupportedBaudRates { get; }

		public string PortName
		{
			get => Port.PortName;
			set => Port.PortName = value;
		}

		// TODO:  Create lists and properties for other serial settings (data bits, parity, stop bits, handshaking).

		/// <summary>
		/// Baud rate used by the device.
		/// </summary>
		public int BaudRate
		{
			get
			{
				if (SupportedBaudRates.Contains(Port.BaudRate) == false)
				{
					Port.BaudRate = SupportedBaudRates[0];
				}
				return Port.BaudRate;
			}
			set
			{
				if (SupportedBaudRates.Contains(value))
				{
					Port.BaudRate = value;
				}
				else throw new DeviceSettingNotSupportedException(GetType().Name + " does not support baud rate " + value + ".");
			}
		}

		public string Newline
		{
			get => Port.NewLine;
			set => Port.NewLine = value;
		}

		/// <summary>
		/// Initialize the serial interface.
		/// </summary>
		public virtual void Open()
		{
			try
			{
				// Open the serial port.
				Port.Open();
			}
			catch (SystemException ex)
			{
				throw new DevicePortException("Could not open " + GetType().Name + "'s serial port."
					+ Environment.NewLine + ex.Message);
			}
		}

		/// <summary>
		/// Initialize the serial interface.
		/// </summary>
		/// <param name="portName">name of port (e.g. "COM3")</param>
		public void Open(string portName)
		{
			PortName = portName;

			Open();
		}

		/// <summary>
		/// Initialize the serial interface.
		/// </summary>
		/// <param name="portName">name of port (e.g. "COM3")</param>
		/// <param name="baudRate">baud rate (e.g. "9600")</param>
		public void Open(string portName, int baudRate)
		{
			// Set serial port settings.
			PortName = portName;
			BaudRate = baudRate;

			Open();
		}

		/// <summary>
		/// Initialize the serial interface.
		/// </summary>
		/// <param name="portName">name of port (e.g. "COM3")</param>
		/// <param name="baudRate">baud rate (e.g. "9600")</param>
		/// <param name="dataBits">number of data bits</param>
		/// <param name="parity">parity</param>
		/// <param name="stopBits">number of stop bits</param>
		public void Open(string portName, int baudRate, int dataBits, Parity parity, StopBits stopBits)
		{
			// Set serial port settings.
			PortName = portName;
			BaudRate = baudRate;
			Port.DataBits = dataBits;
			Port.Parity = parity;
			Port.StopBits = stopBits;

			Open();
		}

		/// <summary>
		/// Close the serial port (if it's open).
		/// </summary>
		public void Close()
		{
			// If the serial port is open...
			if (Port.IsOpen)
			{
				// Close the port.
				Port.Close();
			}
		}

		/// <summary>
		/// Dispose of managed resources.
		/// </summary>
		/// <remarks>
		/// See https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose
		/// </remarks>
		/// <param name="disposing"></param>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				// Dispose managed resources.
				Port?.Dispose();
			}
		}

		/// <summary>
		/// Dispose of managed resources.
		/// </summary>
		/// <remarks>
		/// See https://docs.microsoft.com/en-us/visualstudio/code-quality/ca1001
		/// </remarks>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
