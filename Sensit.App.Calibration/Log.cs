using System;
using System.Collections.Generic;
using System.IO;
using Sensit.TestSDK.Files;
using Sensit.TestSDK.Interfaces;

namespace Sensit.App.Calibration
{
	/// <summary>
	/// Manage log file.
	/// </summary>
	public class Log : IDisposable
	{
		// CSV writer
		private CsvWriter _writer;

		// name of the CSV file
		private string _filename;

		private Equipment _equipment;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="filename">desired filename to create/append to</param>
		public Log(string filename, Equipment equipment)
		{
			// Remember the file name.
			_filename = filename;

			// Save the equipment object (and check for null).
			_equipment = equipment ?? throw new ArgumentNullException(nameof(equipment));
		}

		/// <summary>
		/// Open the log file (for appending).
		/// </summary>
		/// <param name="filename"></param>
		public void Open()
		{
			// Set up the CSV file writer filestream.
			_writer = new CsvWriter(_filename, true);

			// Write column headers.
			List<string> row = new List<string>();

			// Write column header for elapsed time.
			row.Add("Elapsed Time");
			
			foreach (KeyValuePair<string, IDevice> device in _equipment.Devices)
			{
				// Add column headers for each setpoint.
				foreach (KeyValuePair<VariableType, double> setpoint in device.Value.Setpoints)
				{
					row.Add(device.Key + " " + setpoint.Key);
				}

				// Add column headers for each reading.
				foreach (KeyValuePair<VariableType, double> reading in device.Value.Readings)
				{
					row.Add(device.Key + " " + reading.Key);
				}
			}
		}

		/// <summary>
		/// Write a row of data to the log file.
		/// </summary>
		/// <param name="elapsedTime"></param>
		/// <param name="setpoint"></param>
		/// <param name="reference"></param>
		public void Write(TimeSpan elapsedTime)
		{
			// Save test results to csv file.
			// Log a timestamp and the sample value to a CSV file.
			List<string> row = new List<string>();
			row.Add(elapsedTime.ToString());

			foreach (KeyValuePair<string, IDevice> device in _equipment.Devices)
			{
				// Add column headers for each setpoint.
				foreach (KeyValuePair<VariableType, double> setpoint in device.Value.Setpoints)
				{
					row.Add(setpoint.Value.ToString());
				}

				// Add column headers for each reading.
				foreach (KeyValuePair<VariableType, double> reading in device.Value.Readings)
				{
					row.Add(reading.Value.ToString());
				}
			}

			_writer.WriteRow(row);
		}

		/// <summary>
		/// Close the log file.
		/// </summary>
		public void Close()
		{
			_writer.Close();
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
				_writer?.Dispose();
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
