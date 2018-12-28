using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensit.TestSDK.Interfaces
{
	/// <summary>
	/// Device that measures one or more dependent variables in a test.
	/// </summary>
	interface IReferenceDevice
	{
		void Open(string portName, int baudRate);

		void Close();
	}
}
