using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using Sensit.TestSDK.Exceptions;

namespace Sensit.TestSDK.Logger
{
	public class Logger : IDisposable
	{
		#region Fields

		// CSV writer
		private StreamWriter _writer;
		private CsvWriter _csv;

		// log file directory
		private string _directory = string.Empty;

		// log file name
		private string _filename = string.Empty;

		#endregion

		#region Properties

		public string Directory
		{
			get => _directory;
			set
			{
				// Check for valid directory.
				if (Uri.IsWellFormedUriString(value, UriKind.RelativeOrAbsolute) == false)
				{
					throw new TestException("Invalid path for log file.");
				}

				// Save the value.
				_directory = value;
			}
		}

		public string Filename
		{
			get => _filename;
			set
			{
				// Check for empty string.
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new TestException("Invalid name for log file.");
				}

				// Save the value.
				_filename = value;
			}
		}

		#endregion

		#region Constructor

		public Logger()
		{

		}

		public Logger(string directory, string filename)
		{
			_directory = directory;
			_filename = filename;
		}

		#endregion

		public void Open()
		{
			// Check for valid directory.
			if (Uri.IsWellFormedUriString(_directory, UriKind.RelativeOrAbsolute) == false)
			{
				throw new TestException("Invalid path for log file.");
			}

			// Check for empty string.
			if (string.IsNullOrWhiteSpace(_filename))
			{
				throw new TestException("Invalid name for log file.");
			}

			// Initialize CSV file writer.
			string fullPath = Path.Combine(_directory, _filename);
			_writer = new StreamWriter(fullPath, true);
			_csv = new CsvWriter(_writer, CultureInfo.InvariantCulture);
		}

		public void Write(List<dynamic> data)
		{
			_csv?.WriteRecords(data);
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
