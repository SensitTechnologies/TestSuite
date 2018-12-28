using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensit.TestSDK.Interfaces
{
	/// <summary>
	/// Device that controls one or more independent variables in a test.
	/// </summary>
	public interface IControlDevice
	{
		void Open(string portName, int baudRate);

		void SetSetpoint(float setpoint);

		float GetSetpoint();

		void Close();
	}
}
