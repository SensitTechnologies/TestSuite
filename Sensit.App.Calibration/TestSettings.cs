using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Sensit.App.Calibration
{
	/// <summary>
	/// Configuration for a variable being measured or controlled during a test.
	/// </summary>
	public class TestVariable
	{
		// Default constructor.
		public TestVariable() { }

		// Initializer with variable type.
		public TestVariable(Test.VariableType type)
		{
			VariableType = type;
		}

		[Category("Test Variable"), Description("Type of the variable.")]
		public Test.VariableType VariableType { get; set; }

		[Category("Test Variable"), Description("Error tolerance around setpoints [% full scale].  If this is exceeded, Stability Time will reset.")]
		public double ErrorTolerance { get; set; } = 3.0;

		[Category("Test Variable"), Description("Tolerated rate of change of setpoints [% full scale / s].")]
		public double RateTolerance { get; set; } = 2.0;

		[Category("Test Variable"), Description("Required time to be at setpoint before continuing test.")]
		public TimeSpan StabilityTime { get; set; } = new TimeSpan(0, 0, 15);

		[Category("Test Variable"), Description("Timeout before aborting setpoint control.")]
		public TimeSpan Timeout { get; set; } = new TimeSpan(0, 3, 20);

		[Category("Test Variable"), Description("Time to wait between taking samples for this variable.")]
		public TimeSpan Interval { get; set; } = new TimeSpan(0, 0, 1);
	}

	/// <summary>
	/// Configuration for a component of a test.
	/// </summary>
	public class TestComponent
	{
		// Default constructor.
		public TestComponent() { }

		// Initializer with label.
		public TestComponent(string label)
		{
			Label = label;
		}

		[Category("Test Component"), Description("Name of the test component.")]
		public string Label { get; set; } = "";

		[Category("Test Component"), Description("Action to perform on the DUT during this test component.")]
		public Test.DutCommand DutCommand { get; set; }

		[Category("Test Component"), Description("Independent variable for this part of the test.")]
		public TestVariable IndependentVariable { get; set; }

		[Category("Test Component"), Description("Controlled variables for this part of the test.")]
		public List<TestVariable> ControlledVariables { get; set; }

		[Category("Test Component"), Description("Setpoints [% full scale]; Required if calibration is part of the test.")]
		public List<double> Setpoints { get; set; }

		[Category("Test Component"), Description("Number of samples taken from DUT at each setpoint.")]
		public int NumberOfSamples { get; set; } = 1;

		[Category("Test Component"), Description("Time to wait between taking samples from DUT.")]
		public TimeSpan SampleInterval { get; set; } = new TimeSpan(0, 0, 0);
	}

	/// <summary>
	/// Tests that may be performed on a DUT
	/// </summary>
	[Serializable]
	public class TestSetting
	{
		// Default constructor.
		public TestSetting() { }

		// Initializer with label.
		public TestSetting(string label)
		{
			Label = label;
		}

		[Category("Test Settings"), Description("Name of the test (as it will appear to the operator).")]
		public string Label { get; set; } = "";

		[Category("Test Settings"), Description("Actions performed during the test.")]
		public List<TestComponent> Components { get; set; }
	}

	[Serializable]
	public class TestSettings : Attribute
	{
		[Category("Test Settings"), Description("Settings describing tests that can be performed.")]
		public List<TestSetting> Tests { get; set; } = new List<TestSetting>
		{
			new TestSetting("Warm-Up Time"),
			new TestSetting("Linearity")
			{
				
				Components = new List<TestComponent>
				{
					new TestComponent("Characterize")
					{
						IndependentVariable = new TestVariable(Test.VariableType.GasConcentration)
						{
							// Take samples every 1 second.  Don't wait for stability.
							Interval = new TimeSpan(0, 0, 1),
							StabilityTime = new TimeSpan(0, 0, 0)
						},
						// Take 15 samples per setpoint (per sensor).
						NumberOfSamples = 15,
						// Setpoints for oxygen are 0% to 100% full scale, but full scale is 25% O2.
						Setpoints = new List<double> { 0.0, 2.5, 5.0, 7.5, 10.0, 12.5, 15.0, 17.5, 20, 22.5, 25.0 }
					}
				}
			},
			new TestSetting("Transient Response"),
			new TestSetting("Sustained Hysteresis"),
			new TestSetting("Short-term Stability"),
			new TestSetting("Long-term Stability"),
			new TestSetting("Thermal Effects"),
			new TestSetting("Thermal Transients"),
			new TestSetting("Cross-Sensitivity"),
			new TestSetting("Humidity Effects")
		};
	}
}
