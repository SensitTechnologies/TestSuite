using System;
using System.Collections.Generic;
using Sensit.TestSDK.Communication;
using Sensit.TestSDK.Interfaces;

namespace Sensit.App.Calibration
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
		public Dictionary<string, IDevice> Devices { get; }

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
				else if (d is VisaDevice v)
				{
					v.Open();
				}
			}
		}

		/// <summary>
		/// Update readings from all devices.
		/// </summary>
		public void Read()
		{
			foreach (IDevice d in Devices.Values)
			{
				d.Read();
			}
		}

		/// <summary>
		/// Write setpoints to all devices.
		/// </summary>
		public void Write()
		{
			foreach (IDevice d in Devices.Values)
			{
				d.Write();
			}
		}

		/// <summary>
		/// Close all serial devices among the devices.
		/// </summary>
		public void Close()
		{
			foreach (IDevice d in Devices.Values)
			{
				if (d is SerialDevice s)
				{
					s.Close();
				}
				else if (d is VisaDevice v)
				{
					v.Close();
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
