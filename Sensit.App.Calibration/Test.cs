using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sensit.TestSDK.Interfaces;

namespace Sensit.App.Calibration
{
	public class Test
	{
		private bool _running = false;

		public bool IsRunning()
		{
			return _running;

			// TODO:  Return whether the "TestProcess" thread is running.
		}

		/// <summary>
		/// Start a new thread to do tests.
		/// </summary>
		public void Start()
		{
			_running = true;

			// TODO:  Start a new thread (or background worker?) and run "TestProcess" within that thread.
		}

		/// <summary>
		/// Stop the test thread.
		/// </summary>
		public void Stop()
		{
			_running = false;

			// TODO:  Stop the "TestProcess" thread.
		}

		public void TestThread()
		{
			// Initialize abort flag.

			// Get start time.

			// Read settings.

			// Read DUT settings (specific to Model, Range, Test).

			// Initialize GUI.

			// Configure support devices.

			// Open selected DUTs.

			// Apply power to opened DUTs.

			// Wait for DUTs to power up.

			// Configure DUTs.

			// Perform test actions.

			// Close DUTs.

			// Identify passing DUTs.

			// Calculate end time.

			// Record log.

			// Close support devices.
		}
	}
}
