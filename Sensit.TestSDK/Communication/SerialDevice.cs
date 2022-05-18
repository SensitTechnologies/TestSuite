using System;
using System.Collections.Generic;
using System.IO.Ports;
using Sensit.TestSDK.Exceptions;

namespace Sensit.TestSDK.Communication
{
	/// <summary>
	/// Abstract class for a serial device with properties for supported settings.
	/// </summary>
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

		// port used to communicate with device
		// (protected means it's accessible within derived classes, but not outside them)
		protected SerialPort Port { get; } = new SerialPort();

		/// <summary>
		/// Baud rates supported by the device
		/// </summary>
		public abstract List<int> SupportedBaudRates { get; }

		/// <summary>
		/// Baud rate used by the device
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

		/// <summary>
		/// Parity settings supported by the device
		/// </summary>
		public abstract List<Parity> SupportedParity { get; }

		/// <summary>
		/// Parity used by the device
		/// </summary>
		public Parity Parity
		{
			get
			{
				if (SupportedParity.Contains(Port.Parity) == false)
				{
					Port.Parity = SupportedParity[0];
				}
				return Port.Parity;
			}
			set
			{
				if (SupportedParity.Contains(value))
				{
					Port.Parity = value;
				}
				else throw new DeviceSettingNotSupportedException(GetType().Name + " does not support parity " + value + ".");
			}
		}

		/// <summary>
		/// Data bit settings supported by the device
		/// </summary>
		public abstract List<int> SupportedDataBits { get; }

		/// <summary>
		/// Data bits used by the device
		/// </summary>
		public int DataBits
		{
			get
			{
				if (SupportedDataBits.Contains(Port.DataBits) == false)
				{
					Port.DataBits = SupportedDataBits[0];
				}
				return Port.DataBits;
			}
			set
			{
				if (SupportedDataBits.Contains(value))
				{
					Port.DataBits = value;
				}
				else throw new DeviceSettingNotSupportedException(GetType().Name + " does not support " + value + " data bits.");
			}
		}

		/// <summary>
		/// Stop bit settings supported by the device
		/// </summary>
		public abstract List<StopBits> SupportedStopBits { get; }

		/// <summary>
		/// Stop bits used by the device.
		/// </summary>
		public StopBits StopBits
		{
			get
			{
				if (SupportedStopBits.Contains(Port.StopBits) == false)
				{
					Port.StopBits = SupportedStopBits[0];
				}
				return Port.StopBits;
			}
			set
			{
				if (SupportedStopBits.Contains(Port.StopBits))
				{
					Port.StopBits = value;
				}
				else throw new DeviceSettingNotSupportedException(GetType().Name + " does not support " + value + " stop bits.");
			}
		}

		/// <summary>
		/// Handshake settings supported by the device
		/// </summary>
		public abstract List<Handshake> SupportedHandshake { get; }

		/// <summary>
		/// Handshake setting used by the device
		/// </summary>
		public Handshake Handshake
		{
			get
			{
				if (SupportedHandshake.Contains(Port.Handshake) == false)
				{
					Port.Handshake = SupportedHandshake[0];
				}
				return Port.Handshake;
			}
			set
			{
				if (SupportedHandshake.Contains(Port.Handshake))
				{
					Port.Handshake = value;
				}
				else throw new DeviceSettingNotSupportedException(GetType().Name + " does not support handshake setting of " + value + ".");
			}
		}

		/// <summary>
		/// Name of the serial port to use (i.e. "COM3")
		/// </summary>
		public string PortName
		{
			get => Port.PortName;
			set => Port.PortName = value;
		}

		/// <summary>
		/// Initialize the serial interface.
		/// </summary>
		public virtual void Open()
		{
			try
			{
				// Open the serial port (if not already).
				if (Port.IsOpen == false)
				{
					Port.Open();
				}
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
		/// <param name="dataBits">number of data bits</param>
		/// <param name="parity">parity mode</param>
		/// <param name="stopBits">number of stop bits</param>
		/// <param name="handshake">handshake mode</param>
		public void Open(string portName, int baudRate, int dataBits, Parity parity, StopBits stopBits, Handshake handshake)
		{
			// Set serial port settings.
			PortName = portName;
			BaudRate = baudRate;
			DataBits = dataBits;
			Parity = parity;
			StopBits = stopBits;

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
