using System;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;

namespace Sensit.TestSDK.Office.Excel
{
	/// <summary>
	/// Class to automate interaction with Microsoft Excel files.
	/// </summary>
	/// <remarks>
	/// This class will only work if Excel is installed on the PC.
	/// Inspired by the following links:
	/// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/interop/how-to-access-office-onterop-objects
	/// https://support.microsoft.com/en-us/help/302084/how-to-automate-microsoft-excel-from-microsoft-visual-c-net
	/// https://www.codeproject.com/Tips/696864/Working-with-Excel-Using-Csharp
	/// http://csharp.net-informations.com/excel/csharp-create-excel.htm
	/// https://www.dotnetperls.com/excel
	/// Also, this link explains why marshaling is necessary:
	/// https://www.add-in-express.com/creating-addins-blog/2013/11/05/release-excel-com-objects/
	/// Basically, it's bad practice to do something.something.something when using
	/// a COM object.
	/// </remarks>
	public class Excel
	{
		// objects used to interface to Excel and its files.
		// We purposely use Sheets instead of Worksheets, because a chart is
		// contained in Sheets but not in Worksheets.
		// https://stackoverflow.com/questions/14211437/difference-between-worksheets-and-sheets-in-excel-interop
		private Application _excelApp;		// Excel application object
		private Workbooks _workbooks;       // Excel workbooks object
		private Workbook _workbook;			// Excel workbook object
		private Sheets _worksheets;			// Excel worksheets object
		private Worksheet _worksheet;		// Excel worksheet object

		/// <summary>
		/// Default constructor; starts Microsoft Excel.
		/// </summary>
		/// <param name="visible">whether to make Excel visible to the user</param>
		public Excel(bool visible = true)
		{
			// Start Excel and get an application object.
			_excelApp = new Application();

			// If the object was not created...
			if (_excelApp == null)
			{
				// Excel is likely not installed on the PC.
				throw new Exception("Microsoft Excel must be installed to use this application.");
			}

			// Make Excel visible to the user.
			_excelApp.Visible = visible;
		}

		/// <summary>
		/// Opens a new Excel workbook.
		/// </summary>
		/// <remarks>
		/// If you specify a template file, Excel will create a new workbook that is
		/// a copy of the template file.
		/// </remarks>
		/// <param name="templateFile">optional path of Excel file to use as a template</param>
		public void New(string templateFile = "")
		{
			// If a template file was specified....
			if (String.IsNullOrEmpty(templateFile))
			{
				// Create a new Excel workbook based on the template.
				_workbooks = _excelApp.Workbooks;
				_workbooks.Add();
			}
			// If no template file was specified...
			else
			{
				// Create a new, empty, workbook.
				_workbooks = _excelApp.Workbooks;
				_workbooks.Add(templateFile);
			}

			// Remember the active workbook and worksheet.
			_workbook = _excelApp.ActiveWorkbook;
			_worksheets = _workbook.Sheets;
			_worksheet = _workbook.ActiveSheet;
		}

		/// <summary>
		/// Open an existing Excel workbook.
		/// </summary>
		/// <param name="filename">path of Excel file to open</param>
		/// <param name="worksheet">optional worksheet to set as the active sheet</param>
		public void Open(string filename, string worksheet = "")
		{
			// Open the specified workbook.
			_workbooks = _excelApp.Workbooks;
			_workbook = _workbooks.Open(filename);

			// If the object was not created...
			if (_workbook == null)
			{
				// The file was not able to be opened.
				throw new Exception("Unable to open Excel workbook.");
			}

			// If a worksheet was not specified...
			if (string.IsNullOrEmpty(worksheet))
			{
				// Act upon the active worksheet.
				_worksheet = _workbook.ActiveSheet;
			}
			// If a worksheet was specified...
			else
			{
				// Select an existing worksheet.
				_worksheet = _workbook.Worksheets[worksheet];
			}
		}

		/// <summary>
		/// Closes Excel (and an active workbook).
		/// </summary>
		/// <remarks>
		/// If a workbook is open, it will be closed first.
		/// You can specify whether to save changes.
		/// </remarks>
		/// <param name="saveChanges">whether to save changes on open workbook</param>
		public void Close(bool saveChanges = true)
		{
			try
			{
				// Close the spreadsheet (if it exists) (and save changes if desired).
				_workbook?.Close(saveChanges);

				// Close Excel.
				_excelApp.Quit();
			}
			finally
			{
				// Release all the excel COM objects.
				Dispose();
			}
		}

		/// <summary>
		/// Dispose of resources used in the class.
		/// </summary>
		/// <remarks>
		/// If you want to leave Excel open after the application is closed, use this
		/// instead of the "Close" method.
		/// </remarks>
		public void Dispose()
		{
			// Release all our Excel COM objects.
			// This will leave Excel open.
			if (_worksheet != null) Marshal.ReleaseComObject(_worksheet);
			if (_worksheets != null) Marshal.ReleaseComObject(_worksheets);
			if (_workbook != null) Marshal.ReleaseComObject(_workbook);
			if (_workbooks != null) Marshal.ReleaseComObject(_workbooks);
			if (_excelApp != null) Marshal.ReleaseComObject(_excelApp);
		}

		/// <summary>
		/// Change the active sheet.
		/// </summary>
		/// <param name="worksheet"></param>
		public void SetActiveWorksheet(string worksheet)
		{
			// Set the active sheet (if the workbook exists).
			_worksheets?.Select(worksheet);
		}

		/// <summary>
		/// Save the workbook (if one is open).
		/// </summary>
		public void Save()
		{
			// Save the workbook (if it exists).
			_workbook?.Save();
		}

		/// <summary>
		/// Save the workbook (if one is open) as a new file.
		/// </summary>
		/// <param name="filename">path where the new file will be saved</param>
		public void SaveAs(string filename)
		{
			// Save the workbook (if it exists).
			_workbook?.SaveAs(filename);
		}

		private void ValidateCell(int row, int column)
		{
			if ((row < 1) || (column < 1))
			{
				throw new ArgumentOutOfRangeException("Row and Column are 1-based and so must be greater than zero.");
			}
		}

		public void SetCellValue<T>(int row, int column, T value)
		{
			// Check for invalid arguments.
			ValidateCell(row, column);

			_worksheet.Cells[row, column] = value;
		}

		public T GetCellValue<T>(int row, int column)
		{
			// Check for invalid arguments.
			ValidateCell(row, column);

			return _worksheet.Cells[row, column].Value;
		}

		/// <summary>
		/// Write a set of data to the Excel sheet.
		/// </summary>
		/// <remarks>
		/// See https://support.microsoft.com/en-us/help/302096/how-to-automate-excel-by-using-visual-c-to-fill-or-to-obtain-data-in-a
		/// </remarks>
		/// <typeparam name="T"></typeparam>
		/// <param name="row"></param>
		/// <param name="column"></param>
		/// <param name="values"></param>
		public void WriteMultiCellValues<T>(int row, int column, T[,] values)
		{
			// Check for invalid arguments.
			ValidateCell(row, column);

			// Create an Excel Range object encompassing the workbook's starting cell.
			Range range = (Range)_worksheet.Cells[row, column];
			
			// Get the width and height of the "values" multidimensional array.
			// FYI, values.Length() would return the number of rows * columns.
			int rows = values.GetLength(0);
			int columns = values.GetLength(1);

			// Resize the range to be the same size as the values array.
			range = range.get_Resize(rows, columns);

			// Write the range data to Excel.
			range.set_Value(value: values);
		}

		/// <summary>
		/// Read a set of data from the Excel sheet.
		/// </summary>
		/// <remarks>
		/// See https://stackoverflow.com/questions/50143566/c-sharp-excel-read-to-multidimensional-array
		/// </remarks>
		/// <param name="row"></param>
		/// <param name="column"></param>
		/// <param name="numRows"></param>
		/// <param name="numColumns"></param>
		/// <returns></returns>
		public object[,] ReadMultiCellValues(int row, int column, int numRows, int numColumns)
		{
			// Check for invalid arguments.
			ValidateCell(row, column);

			// Create an Excel Range object emcompassing the workbook's starting cell.
			Range range = (Range)_worksheet.Cells[row, column];

			// Resize the range to the desired dimensions.
			range = range.get_Resize(numRows, numColumns);

			// Read the cells' values from the spreadsheet.
			return (object[,])range.Value2;
		}

		public void CreateChart(double left, double top, double width, double height,
			string topLeftCell, string bottomRightCell, string title, string xAxisLabel, string yAxisLabel)
		{
			// Create an Excel chart object.
			ChartObjects charts = _worksheet?.ChartObjects();
			ChartObject chartObject = charts?.Add(left, top, width, height);
			Chart chart = chartObject?.Chart;

			// Set the chart's data range.
			Range range = _worksheet?.get_Range(topLeftCell, bottomRightCell);
			chart?.SetSourceData(range);

			// Set the chart's properties.
			// TODO:  Figure out how to check for null.
			chart.ChartType = XlChartType.xlXYScatter;
			chart?.ChartWizard(Source: range, Title: title, CategoryTitle: xAxisLabel, ValueTitle: yAxisLabel);
		}
	}
}
