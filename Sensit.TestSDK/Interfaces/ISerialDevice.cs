using System.IO.Ports;

namespace Sensit.TestSDK.Interfaces
{
	/// <summary>
	/// Device that uses a serial port to communicate.
	/// </summary>
	public interface ISerialDevice
	{
		/// <summary>
		/// Initialize the serial interface.
		/// </summary>
		/// <param name="portName">name of port (i.e. "COM3")</param>
		/// <param name="baudRate">baud rate (i.e. "9600")</param>
		void Open(string portName, int baudRate);

		/// <summary>
		/// Set serial port properties.
		/// </summary>
		/// <param name="dataBits">number of data bits</param>
		/// <param name="parity">parity setting</param>
		/// <param name="stopBits">number of stop bits</param>
		void SetSerialProperties(int dataBits = 8, Parity parity = Parity.None, StopBits stopBits = StopBits.One);

		/// <summary>
		/// Close the serial interface.
		/// </summary>
		void Close();
	}
}
