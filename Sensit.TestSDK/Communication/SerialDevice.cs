using System;
using System.IO.Ports;

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

		public string PortName
		{
			get => Port.PortName;
			set => Port.PortName = value;
		}

		public int BaudRate
		{
			get => Port.BaudRate;
			set =>Port.BaudRate = value;
		}

		public int DataBits
		{
			get => Port.DataBits;
			set => Port.DataBits = value;
		}

		public Parity Parity { get; set; }

		public StopBits StopBits { get; set; }

		/// <summary>
		/// Initialize the serial interface.
		/// </summary>
		public void Open()
		{
			Open(PortName, BaudRate);
		}

		/// <summary>
		/// Initialize the serial interface.
		/// </summary>
		/// <param name="portName">name of port (i.e. "COM3")</param>
		/// <param name="baudRate">baud rate (i.e. "9600")</param>
		public abstract void Open(string portName, int baudRate);

		/// <summary>
		/// Set serial port properties.
		/// </summary>
		/// <param name="dataBits">number of data bits</param>
		/// <param name="parity">parity setting</param>
		/// <param name="stopBits">number of stop bits</param>
		public abstract void WriteSerialProperties(int dataBits = 8, Parity parity = Parity.None, StopBits stopBits = StopBits.One);

		/// <summary>
		/// Close the serial port (if it's open).
		/// </summary>
		public void Close()
		{
			// If the serial port is open, close it.
			if (Port.IsOpen)
			{
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
