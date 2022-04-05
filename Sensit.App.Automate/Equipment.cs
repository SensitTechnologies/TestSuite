using System;
using System.Collections.Generic;
using System.Linq;
using Sensit.TestSDK.Communication;
using Sensit.TestSDK.Interfaces;
using Sensit.TestSDK.Utilities;

namespace Sensit.App.Automate
{
	/// <summary>
	/// Manage devices used to collect data during tests.
	/// </summary>
	/// <remarks>
	/// We have one of each possible type of device.  Depending on the user's
	/// selections, we choose which device(s) to use and pass to the user for
	/// each needed interface.
	/// </remarks>
	public class Equipment : IDisposable
	{
		public Dictionary<string, IDevice> Devices { get; } = new Dictionary<string, IDevice>();

		public Equipment(List<DeviceSetting> deviceSettings)
		{
			// Make a list of possible device types.
			List<Type> deviceTypes = Utilities.FindClasses(typeof(IDevice));

			foreach (DeviceSetting d in deviceSettings ?? throw new ArgumentNullException(nameof(deviceSettings)))
			{
				// Find the device type with the correct display name.
				Type deviceType = deviceTypes.FirstOrDefault(o => o.GetDisplayName() == d.Type);

				// Create an instance of the device.
				object device = Activator.CreateInstance(deviceType);

				// If the device is a serial device...
				if (device is SerialDevice s)
				{
					// Set the serial port.
					s.PortName = d.SerialPort;
				}

				// Add the device to our list of devices.
				Devices.Add(d.Name, (IDevice)device);
			}
		}

		/// <summary>
		/// Initializes all equipment.
		/// </summary>
		public void Open()
		{
			foreach (IDevice d in Devices.Values)
			{
				if (d is SerialDevice s)
				{
					s.Open();
				}
			}
		}

		public void SetControlMode(ControlMode mode)
		{
			foreach (IDevice d in Devices.Values)
			{
				d.SetControlMode(mode);
			}
		}

		/// <summary>
		/// Update readings from all devices.
		/// </summary>
		public void Read()
		{
			foreach (IDevice d in Devices.Values)
			{
				d.WriteThenRead();
			}
		}

		/// <summary>
		/// Close all devices that have a "Close" method.
		/// </summary>
		public void Close()
		{
			foreach (IDevice d in Devices.Values)
			{
				if (d is SerialDevice s)
				{
					s.Close();
				}
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
				foreach (IDevice device in Devices.Values)
				{
					if (device is IDisposable d)
					{
						d.Dispose();
					}
				}
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
