using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sensit.App.Calibration
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// Auto-generated code.
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			// Create an object to represent test equipment.
			Equipment equipment = new Equipment();

			// Create an object to represent the tests being run.
			Test test = new Test();

			// Create a GUI for user interaction.
			FormCalibration formCalibration = new FormCalibration
			{
				// Tell the GUI what models, ranges, tests are available.
				Models = test.Models,
				Ranges = test.Ranges,
				Tests = test.Tests,
				NumDuts = test.NumDuts
			};

			// TODO:  Every time a model, range, is updated, get new options.
			// TODO:  Tell the GUI and test objects what equipment is needed.
			// TODO:  Tell the GUI what variables to use. Maybe create test.Initialize that calls a form action and sends a list of references and controllers.
			// TODO:  Display tab for DUT.  Maybe show Excel in a web browser?

			// Set test actions.
			test.Update = formCalibration.TestUpdate;
			test.Finished = formCalibration.TestFinished;
			test.SystemOpen = equipment.Open;
			test.SystemClose = equipment.Close;
			test.SystemRead = equipment.Read;
			test.SetRanges = value => formCalibration.Ranges = value;
			
			// Set GUI actions.
			formCalibration.TestStart = test.Start;
			formCalibration.TestStop = test.Stop;
			formCalibration.TestBusy = test.IsBusy;
			formCalibration.Print = equipment.Print;
			formCalibration.Exit = test.SaveSettings;
			// https://syncor.blogspot.com/2010/11/passing-getter-and-setter-of-c-property.html
			formCalibration.NumDutsChanged = value => test.NumDuts = value;
			formCalibration.ModelChanged = value => test.SelectedModel = value;
			formCalibration.RangeChanged = value => test.SelectedRange = value;
			formCalibration.TestChanged = value => test.SelectedTest = value;

			// Run the GUI.
			Application.Run(formCalibration);
		}
	}
}
