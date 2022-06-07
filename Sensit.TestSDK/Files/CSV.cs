using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sensit.TestSDK.Files
{
	/// <summary>
	/// Class to write to a CSV file
	/// </summary>
	public class CsvWriter : StreamWriter
	{
		#region Constructors

		public CsvWriter(Stream stream) : base(stream) { }

		public CsvWriter(string filename) : base(filename) { }

		public CsvWriter(string filename, bool append) : base (filename, append) { }

		#endregion

		public void WriteRow(List<string> row)
		{
			// Check for valid data.
			if (row == null)
			{
				throw new ArgumentNullException(nameof(row));
			}

			StringBuilder sb = new();
			bool firstColumn = true;

			foreach (string value in row)
			{
				// If this isn't the first value...
				if (!firstColumn)
				{
					// Add separator (a comma).
					sb.Append(',');
				}

				// If the value contains a comma or quote...
				if (value.IndexOfAny(new char[] { '"', ',' }) != -1)
				{
					// Enclose in quotes.
					sb.AppendFormat("\"{0}\"", value.Replace("\"", "\"\""));
				}
				// If the string doesn't contain any special characters...
				else
				{
					// Use it as is.
					sb.Append(value);
				}

				// Remember that we need a separator for additional columns of data.
				firstColumn = false;
			}

			// Write the line to the CSV file.
			WriteLine(sb.ToString());

			// Ensure the file is written.
			Flush();
		}
	}

	public class CsvReader : StreamReader
	{
		#region Constructors

		public CsvReader(Stream stream) : base(stream) { }

		public CsvReader(string filename) : base(filename) { }

		#endregion

		public int ReadRow(List<string> row)
		{
			// Check for valid data.
			if (row == null)
			{
				throw new ArgumentNullException(nameof(row));
			}

			string lineText = ReadLine();
			int rows = 0;

			if (string.IsNullOrEmpty(lineText) == false)
			{
				int i = 0;
				while (i < lineText.Length)
				{
					string value;

					// Special handling for quoted field
					if (lineText[i] == '"')
					{
						// Skip initial quote
						i++;

						// Parse quoted value
						int start = i;
						while (i < lineText.Length)
						{
							// Test for quote character
							if (lineText[i] == '"')
							{
								// Found one
								i++;

								// If two quotes together, keep one
								// Otherwise, indicates end of value
								if (i >= lineText.Length ||
									lineText[i] != '"')
								{
									i--;
									break;
								}
							}
							i++;
						}
						value = lineText.Substring(start, i - start);
						value = value.Replace("\"\"", "\"");
					}
					else
					{
						// Parse unquoted value
						int start = i;
						while (i < lineText.Length && lineText[i] != ',')
							i++;
						value = lineText.Substring(start, i - start);
					}

					// Add field to list
					if (rows < row.Count)
						row[rows] = value;
					else
						row.Add(value);
					rows++;

					// Eat up to and including next comma
					while (i < lineText.Length && lineText[i] != ',')
						i++;
					if (i < lineText.Length)
						i++;
				}
				// Delete any unused items
				while (row.Count > rows)
					row.RemoveAt(rows);
			}

			// Return the number of columns read.
			return row.Count;
		}
	}
}
