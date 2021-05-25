using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Sensit.TestSDK.Files;
using Sensit.TestSDK.Interfaces;

namespace Sensit.App.Automate
{
	/// <summary>
	/// Manage log file.
	/// </summary>
	public class Log : IDisposable
	{
		// CSV writer
		private readonly CsvWriter _writer;

		/// <summary>
		/// Open the log file (for appending).
		/// </summary>
		/// <param name="filepath">desired file path to create/append to</param>
		public Log(string filepath)
		{
			// If the file exists...
			if (string.IsNullOrWhiteSpace(filepath))
			{
				throw new ArgumentException("Log file path is not valid." + Environment.NewLine, nameof(filepath));
			}

			// Set up the CSV file writer filestream.
			_writer = new CsvWriter(filepath, true);
		}

		public void WriteHeader(Dictionary<(string name, VariableType variable), TestVariable> variables)
		{
			// Check for null argument.
			if (variables == null)
			{
				throw new ArgumentNullException(nameof(variables));
			}

			// Create a list of column headers.
			List<string> row = new List<string>
			{
				// Write column header for date/time.
				"Timestamp"
			};

			foreach (KeyValuePair<(string name, VariableType variable), TestVariable> v in variables)
			{
				// Add column header for the setpoint.
				row.Add(v.Key.name + " " + v.Key.variable + " Setpoint");

				// Add column headers for each reading.
				row.Add(v.Key.name + " " + v.Key.variable);
			}

			_writer?.WriteRow(row);
		}

		/// <summary>
		/// Write a row of data to the log file.
		/// </summary>
		/// <param name="setpoint"></param>
		/// <param name="reference"></param>
		public void Write(Dictionary<(string name, VariableType variable), TestVariable> variables)
		{
			// Check for null argument.
			if (variables == null)
			{
				throw new ArgumentNullException(nameof(variables));
			}

			// Create a list of test data.
			List<string> row = new List<string>
			{
				// Log current date and time.
				DateTime.Now.ToString(CultureInfo.InvariantCulture)
			};

			foreach (KeyValuePair<(string name, VariableType variable), TestVariable> v in variables)
			{
				// Add each setpoint.
				row.Add(v.Value.Setpoint.ToString(CultureInfo.CurrentCulture));

				// Add each reading.
				row.Add(v.Value.Actual.ToString(CultureInfo.CurrentCulture));
			}

			_writer?.WriteRow(row);
		}

		public void WriteMessage(string message)
		{
			List<string> row = new List<string>() { message };
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
