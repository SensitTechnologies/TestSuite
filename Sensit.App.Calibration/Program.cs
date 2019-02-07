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
				// Tell the GUI how many DUTs are available.
				NumDuts = test.NumDuts
			};

			// TODO:  FormCalibration support for reading DUT selection, model.
			// TODO:  FormCalibration support for setting test equipment and fetching related user settings.
			// TODO:  FormCalibration support for setting test variables and updating their values.
			// TODO:  FormCalibration support for displaying data in a tab for each DUT.  Maybe show Excel in a web browser?

			// Set test actions.
			test.Update = formCalibration.TestUpdate;
			test.Finished = formCalibration.TestFinished;
			
			// Set GUI actions.
			formCalibration.TestStart = test.Start;
			formCalibration.TestStop = test.Stop;
			formCalibration.TestBusy = test.IsBusy;
			// https://syncor.blogspot.com/2010/11/passing-getter-and-setter-of-c-property.html
			formCalibration.NumDutsChanged = value => test.NumDuts = value;

			// Run the GUI.
			Application.Run(formCalibration);
		}
	}
}
