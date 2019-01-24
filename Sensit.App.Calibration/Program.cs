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

			// TODO:  FormCalibration support for reading DUT selection, model.
			// TODO:  FormCalibration support for setting test equipment and fetching related user settings.
			// TODO:  FormCalibration support for setting test variables and updating their values.
			// TODO:  FormCalibration support for displaying data in a tab for each DUT.  Maybe show Excel in a web browser?
			// TODO:  Support for regulating gas concentration via two mass flow controllers.
			// TODO:  Call FormObjectEditor from FormCalibration to view/change test and equipment settings.
			// TODO:  Log data (create a logger class in the SDK).

			// Set test actions.
			test.Update = formCalibration.TestUpdate;
			test.Finished = formCalibration.TestFinished;
			test.SetRanges = value => formCalibration.Ranges = value;
			
			// Set GUI actions.
			formCalibration.TestStart = test.Start;
			formCalibration.TestStop = test.Stop;
			formCalibration.TestBusy = test.IsBusy;
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
