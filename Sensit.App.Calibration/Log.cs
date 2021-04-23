using System;
using System.Collections.Generic;
using System.IO;
using Sensit.TestSDK.Files;

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

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="filename">desired filename to create/append to</param>
		public Log(string filename)
		{
			// Remember the file name.
			_filename = filename;
		}

		/// <summary>
		/// Open the log file (for appending).
		/// </summary>
		/// <param name="filename"></param>
		public void Open()
		{
			// Set up the CSV file writer filestream.
			_writer = new CsvWriter(_filename, true);
		}

		/// <summary>
		/// Write a row of data to the log file.
		/// </summary>
		/// <param name="elapsedTime"></param>
		/// <param name="setpoint"></param>
		/// <param name="reference"></param>
		public void Write(TimeSpan elapsedTime, double setpoint, double reference)
		{
			// Save test results to csv file.
			// Log a timestamp and the sample value to a CSV file.
			List<string> row = new List<string>();
			row.Add(elapsedTime.ToString());
			row.Add(setpoint.ToString());
			row.Add(reference.ToString());
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
