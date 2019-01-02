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

		public bool Running()
		{
			return _running;
		}

		public void Start()
		{
			_running = true;
		}

		public void Stop()
		{
			_running = false;
		}
	}
}
