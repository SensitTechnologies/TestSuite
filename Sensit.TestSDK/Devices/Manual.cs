using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Sensit.TestSDK.Interfaces;
using Sensit.TestSDK.Utilities;

namespace Sensit.TestSDK.Devices
{
	/// <summary>
	/// A virtual device.
	/// </summary>
	/// <remarks>
	/// Useful for testing software.
	/// </remarks>
	public class Manual : IDevice
	{
		// This dictionary is purposefully empty so software knows this device does not support any readings.
		public Dictionary<VariableType, decimal> Readings { get; } = new Dictionary<VariableType, decimal>();
		
		public string Message { get; }

		public void Read()
		{
			// Do nothing.  It's the user's responsibility to record any readings.
		}

		public void SetControlMode(ControlMode mode)
		{
			// Prompt the user to set the device's control mode.
			MessageBox.Show("Set manual device's control mode to:  " + mode.ToString() + ".");
		}

		public void Write(VariableType variable, decimal value)
		{
			// Prompt the user to set the variable's value.
			MessageBox.Show("Set " + variable.GetDescription() + " to " + value.ToString(CultureInfo.CurrentCulture) + ".");
		}
	}
}
