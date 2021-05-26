using Sensit.TestSDK.Communication;
using Sensit.TestSDK.Exceptions;

namespace Sensit.TestSDK.Devices
{
	/// <summary>
	/// Construct SCPI command strings for the GPDX303S power supply.
	/// </summary>
	/// <remarks>
	/// An attempt at creating an extendable way to construct SCPI command strings.
	/// </remarks>
	internal class GPDX303S_SCPI : SCPIDevice
	{
		// Mandated Commands
		public ISCPIQuery CLS { get { _command += "*CLS"; return this; } }
		public ISCPIQuery ESE { get { _command += "*ESE"; return this; } }
		public ISCPIQuery ESR { get { _command += "*ESR"; return this; } }
		public ISCPIQuery IDN { get { _command += "*IDN"; return this; } }
		public ISCPIQuery OPC { get { _command += "*OPC"; return this; } }
		public ISCPIQuery PSC { get { _command += "*PSC"; return this; } }

		public ISCPIQuery STATUS
		{
			get
			{
				_command += "STATUS";

				return this;
			}
		}

		public ISCPICommand LOCAL
		{
			get
			{
				_command += "LOCAL";

				return this;
			}
		}

		public ISCPIQuery ERR
		{
			get
			{
				_command += "ERR";

				return this;
			}
		}

		public ISCPIQuery HELP
		{
			get
			{
				_command += "HELP";

				return this;
			}
		}

		public ISCPIQuery ISET(int channel)
		{
			_command += "ISET" + channel.ToString();

			return this;
		}

		public ISCPICommand ISET(int channel, decimal current)
		{
			_command += "ISET" + channel.ToString() + ":" + current.ToString();

			return this;
		}

		public ISCPIQuery VSET(int channel)
		{
			_command += "VSET" + channel.ToString();

			return this;
		}

		public ISCPICommand VSET(int channel, decimal voltage)
		{
			_command += "VSET" + channel.ToString() + ":" + voltage.ToString();

			return this;
		}

		public ISCPIQuery IOUT(int channel)
		{
			_command += "IOUT" + channel.ToString();

			return this;
		}

		public ISCPIQuery VOUT(int channel)
		{
			_command += "VOUT" + channel.ToString();

			return this;
		}

		public enum TrackingMode
		{
			Independent,
			Series,
			Parallel
		}

		public ISCPICommand TRACK(TrackingMode mode)
		{
			_command += "TRACK";

			switch (mode)
			{
				case TrackingMode.Independent:
					_command += "0";
					break;
				case TrackingMode.Series:
					_command += "1";
					break;
				case TrackingMode.Parallel:
					_command += "2";
					break;
			}

			return this;
		}

		public ISCPICommand BEEP(bool enable)
		{
			_command += "BEEP";

			if (enable)
				_command += "1";
			else
				_command += "0";

			return this;
		}

		public ISCPICommand OUT(bool enable)
		{
			_command += "OUT";

			if (enable)
				_command += "1";
			else
				_command += "0";

			return this;
		}

		public ISCPICommand RCL(int memory)
		{
			if (memory > 4)
			{
				throw new DeviceSettingNotSupportedException("Invalid memory number");
			}

			_command += "RCL" + memory.ToString();

			return this;
		}

		public ISCPICommand SAV(int memory)
		{
			if (memory > 4)
			{
				throw new DeviceSettingNotSupportedException("Invalid memory number");
			}

			_command += "SAV" + memory.ToString();

			return this;
		}

		public enum Baudrate
		{
			BAUD115200,
			BAUD57600,
			BAUD9600,
		}

		public ISCPICommand BAUD(Baudrate baudrate)
		{
			_command += "BAUD";

			switch (baudrate)
			{
				case Baudrate.BAUD115200:
					_command += "0";
					break;
				case Baudrate.BAUD57600:
					_command += "1";
					break;
				case Baudrate.BAUD9600:
					_command += "2";
					break;
			}

			return this;
		}
	}
}
