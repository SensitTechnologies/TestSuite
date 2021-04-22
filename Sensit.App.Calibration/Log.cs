using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;	// TODO:  replace with Sensit.TestSDK.Files

namespace Sensit.App.Calibration
{
	public class TestResults
	{
		public TimeSpan? ElapsedTime { get; set; }
		public double? Setpoint { get; set; }
		public double? Reference { get; set; }
		public double? SensorValue { get; set; }
		public string SensorMessage { get; set; } = string.Empty;
	}

	/// <summary>
	/// Manage log file.
	/// </summary>
	public class Log : IDisposable
	{
		#region Fields

		// CSV writer
		StreamWriter _writer;
		CsvWriter _csv;

		#endregion

		#region Properties

		/// <summary>
		/// Data collected during a test.
		/// </summary>
		/// <remarks>
		/// This is a public property so it can be data bound to the GUI to show to the user.
		/// </remarks>
		public List<TestResults> Results { get; } = new List<TestResults>();

		/// <summary>
		/// File name for test information.
		/// </summary>
		public string Filename { get; set; }

		#endregion

		public void Open()
		{
			// Initialize CSV file writer.
			string filename = Filename + ".csv";
			string fullPath = Path.Combine(Properties.Settings.Default.LogDirectory, filename);
			_writer = new StreamWriter(fullPath, true);
			_csv = new CsvWriter(_writer, CultureInfo.CurrentCulture);
		}

		public void Read(TimeSpan elapsedTime, double setpoint, double reference)
		{
			// Format data from device.
			var testResult = new TestResults
			{
				ElapsedTime = elapsedTime,
				Setpoint = setpoint,
				Reference = reference,
			};

			// Save test results to csv file.
			_csv?.WriteRecords(new List<TestResults> { testResult });

			// Save the result.
			Results.Add(testResult);
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
				_csv?.Dispose();
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
