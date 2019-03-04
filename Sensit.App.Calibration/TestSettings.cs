using System;
using System.Collections.Generic;
using System.ComponentModel;
using Sensit.TestSDK.Calculations;
using Sensit.TestSDK.Interfaces;

namespace Sensit.App.Calibration
{
	/// <summary>
	/// Configuration for a variable being measured or controlled during a test.
	/// </summary>
	public class TestVariable
	{
		[Category("Test Variable"), Description("Type of the variable.")]
		public VariableType VariableType { get; set; }

		[Category("Test Variable"), Description("Error tolerance around setpoints [% full scale].  If exceeded, Stability Time will reset.")]
		public double ErrorTolerance { get; set; } = 3.0;

		[Category("Test Variable"), Description("Tolerated rate of change of setpoints [% full scale / s].  If exceeded, Stability Time will reset.")]
		public double RateTolerance { get; set; } = 2.0;

		[Category("Test Variable"), Description("Setpoints [% full scale]; Required if calibration is part of the test.")]
		public List<double> Setpoints { get; set; }

		[Category("Test Variable"), Description("Required time to be at setpoint before continuing test.")]
		public TimeSpan StabilityTime { get; set; } = new TimeSpan(0, 0, 0);

		[Category("Test Variable"), Description("Timeout before aborting control.")]
		public TimeSpan Timeout { get; set; } = new TimeSpan(0, 0, 30);
	}

	/// <summary>
	/// Configuration for a component of a test.
	/// </summary>
	public class TestComponent
	{
		#region Constructors

		// Default constructor.
		public TestComponent() { }

		// Initializer with label.
		public TestComponent(string label)
		{
			Label = label;
		}

		#endregion

		[Category("Test Component"), Description("Name for this part of the test.")]
		public string Label { get; set; } = "";

		[Category("Test Component"), Description("Action to perform on the DUT during this test component.")]
		public Test.DutCommand DutCommand { get; set; }

		[Category("Test Component"), Description("Controlled/independent variables for this part of the test.")]
		public List<TestVariable> Variables { get; set; }

		[Category("Test Component"), Description("Number of samples taken from DUT at each setpoint.")]
		public int Samples { get; set; } = 1;

		[Category("Test Component"), Description("Time to wait between taking samples from DUT/variables.")]
		public TimeSpan Interval { get; set; } = new TimeSpan(0, 0, 0);
	}

	/// <summary>
	/// Tests that may be performed on a DUT
	/// </summary>
	[Serializable]
	public class TestSetting
	{
		#region Constructors

		// Default constructor.
		public TestSetting() { }

		// Initializer with label.
		public TestSetting(string label)
		{
			Label = label;
		}

		#endregion

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
			new TestSetting("Diode Test")
			{
				Components = new List<TestComponent>
				{
					// Measure once per minute for 15 hours.
					new TestComponent("Measure")
					{
						Samples = 900,
						Interval = new TimeSpan(0, 1, 0),
					}
				}
			},
			new TestSetting("Warm-Up Stability")
			{
				Components = new List<TestComponent>
				{
					// Apply gas for 5 minutes.
					new TestComponent("Apply gas")
					{
						DutCommand = Test.DutCommand.TurnOff,
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								StabilityTime = new TimeSpan(0, 5, 0),
								Setpoints = new List<double> { 25.0 }
							}
						}
					},
					// Measure stability every second for 30 minutes.
					new TestComponent("Measure stability")
					{
						DutCommand = Test.DutCommand.TurnOn,
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 25.0 }
							}
						},
						Samples = 1800,
						Interval = new TimeSpan(0, 0, 1)
					}
				}
			},
			new TestSetting("Linearity")
			{
				Components = new List<TestComponent>
				{
					// Ramp up and down 5 times.  Measure gas every 1 second.  Don't wait for stability.
					// Setpoints for oxygen are 0% to 100% full scale, but full scale is 25% O2.
					// Take 15 samples per setpoint (per sensor).
					new TestComponent("Up 1")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0.0, 2.5, 5.0, 7.5, 10.0, 12.5, 15.0, 17.5, 20.0, 22.5, 25.0 }
							}
						},
						Samples = 240,
						Interval = new TimeSpan(0, 0, 0, 0, 500)
					},
					new TestComponent("Down 1")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 25.0, 22.5, 20.0, 17.5, 15.0, 12.5, 10.0, 7.5, 5.0, 2.5, 0.0 }
							}
						},
						Samples = 240,
						Interval = new TimeSpan(0, 0, 0, 0, 500)
					},
					new TestComponent("Up 2")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0.0, 2.5, 5.0, 7.5, 10.0, 12.5, 15.0, 17.5, 20.0, 22.5, 25.0 }
							}
						},
						Samples = 240,
						Interval = new TimeSpan(0, 0, 0, 0, 500)
					},
					new TestComponent("Down 2")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 25.0, 22.5, 20.0, 17.5, 15.0, 12.5, 10.0, 7.5, 5.0, 2.5, 0.0 }
							}
						},
						Samples = 240,
						Interval = new TimeSpan(0, 0, 0, 0, 500)
					},
					new TestComponent("Up 3")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0.0, 2.5, 5.0, 7.5, 10.0, 12.5, 15.0, 17.5, 20.0, 22.5, 25.0 }
							}
						},
						Samples = 240,
						Interval = new TimeSpan(0, 0, 0, 0, 500)
					},
					new TestComponent("Down 3")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 25.0, 22.5, 20.0, 17.5, 15.0, 12.5, 10.0, 7.5, 5.0, 2.5, 0.0 }
							}
						},
						// Take 15 samples per setpoint (per sensor).
						Samples = 240,
						Interval = new TimeSpan(0, 0, 0, 0, 500)
					},
					new TestComponent("Up 4")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0.0, 2.5, 5.0, 7.5, 10.0, 12.5, 15.0, 17.5, 20.0, 22.5, 25.0 }
							}
						},
						Samples = 240,
						Interval = new TimeSpan(0, 0, 0, 0, 500),
					},
					new TestComponent("Down 4")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 25.0, 22.5, 20.0, 17.5, 15.0, 12.5, 10.0, 7.5, 5.0, 2.5, 0.0 }
							}
						},
						Samples = 240,
						Interval = new TimeSpan(0, 0, 0, 0, 500),
					},
					new TestComponent("Up 5")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0.0, 2.5, 5.0, 7.5, 10.0, 12.5, 15.0, 17.5, 20.0, 22.5, 25.0 }
							}
						},
						Samples = 240,
						Interval = new TimeSpan(0, 0, 0, 0, 500),
					},
					new TestComponent("Down 5")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 25.0, 22.5, 20.0, 17.5, 15.0, 12.5, 10.0, 7.5, 5.0, 2.5, 0.0 }
							}
						},
						Samples = 240,
						Interval = new TimeSpan(0, 0, 0, 0, 500),
					},
				}
			},
			new TestSetting("Transient Response")
			{
				Components = new List<TestComponent>
				{
					// Allow DUT to stabilize for 1 hour with normal air applied.
					new TestComponent("Stabilize")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0.0 }
							}
						},
						Samples = 3600,
						Interval = new TimeSpan(0, 0, 1)
					},
					// Apply test gas mixure; record response.
					new TestComponent("Step Up 1")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 25.0 }
							}
						},
						Samples = 350,
						Interval = new TimeSpan(0, 0, 1)
					},
					// Apply normal air; record response.
					new TestComponent("Step Down 1")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0.0 }
							}
						},
						Samples = 350,
						Interval = new TimeSpan(0, 0, 1)
					},
					// Apply test gas mixure; record response.
					new TestComponent("Step Up 2")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 25.0 }
							}
						},
						Samples = 350,
						Interval = new TimeSpan(0, 0, 1)
					},
					// Apply normal air; record response.
					new TestComponent("Step Down 2")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0.0 }
							}
						},
						Samples = 350,
						Interval = new TimeSpan(0, 0, 1)
					},
					// Apply test gas mixure; record response.
					new TestComponent("Step Up 3")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 25.0 }
							}
						},
						Samples = 350,
						Interval = new TimeSpan(0, 0, 1)
					},
					// Apply normal air; record response.
					new TestComponent("Step Down 3")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0.0 }
							}
						},
						Samples = 350,
						Interval = new TimeSpan(0, 0, 1)
					},
					// Apply test gas mixure; record response.
					new TestComponent("Step Up 4")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 25.0 }
							}
						},
						Samples = 350,
						Interval = new TimeSpan(0, 0, 1)
					},
					// Apply normal air; record response.
					new TestComponent("Step Down 4")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0.0 }
							}
						},
						Samples = 350,
						Interval = new TimeSpan(0, 0, 1)
					},
					// Apply test gas mixure; record response.
					new TestComponent("Step Up 5")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 25.0 }
							}
						},
						Samples = 350,
						Interval = new TimeSpan(0, 0, 1)
					},
					// Apply normal air; record response.
					new TestComponent("Step Down 5")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0.0 }
							}
						},
						Samples = 350,
						Interval = new TimeSpan(0, 0, 1)
					}
				}
			},
			new TestSetting("Sustained Hysteresis"),
			new TestSetting("Short-term Stability")
			{
				Components = new List<TestComponent>
				{
					// Take samples every second for 10 minutes with 21% O2 (the amount in ambient air) applied.
					new TestComponent("Run 1")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 21.0 }
							}
						},
						Samples = 600,
						Interval = new TimeSpan(0, 0, 1)
					},
					// Expose DUT to test gas for 3 minutes, recording data.
					new TestComponent("Run 2")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 25.0 }
							}
						},
						Samples = 180,
						Interval = new TimeSpan(0, 0, 1)
					},
					// Expose DUT to ambient air for 7 minutes.
					new TestComponent("Run 3")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 21.0 }
							}
						},
						Samples = 420,
						Interval = new TimeSpan(0, 0, 1)
					},
					// Expose DUT to test gas for 3 minutes, recording data.
					new TestComponent("Run 4")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 25.0 }
							}
						},
						Samples = 180,
						Interval = new TimeSpan(0, 0, 1)
					},
					// Expose DUT to ambient air for 7 minutes.
					new TestComponent("Run 5")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 21.0 }
							}
						},
						Samples = 420,
						Interval = new TimeSpan(0, 0, 1)
					},
					// Expose DUT to test gas for 3 minutes, recording data.
					new TestComponent("Run 6")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 25.0 }
							}
						},
						Samples = 180,
						Interval = new TimeSpan(0, 0, 1)
					},
					// Expose DUT to ambient air for 7 minutes.
					new TestComponent("Run 7")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 21.0 }
							}
						},
						Samples = 420,
						Interval = new TimeSpan(0, 0, 1)
					},
					// Expose DUT to test gas for 3 minutes, recording data.
					new TestComponent("Run 8")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 25.0 }
							}
						},
						Samples = 180,
						Interval = new TimeSpan(0, 0, 1)
					},
					// Expose DUT to ambient air for 7 minutes.
					new TestComponent("Run 9")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 21.0 }
							}
						},
						Samples = 420,
						Interval = new TimeSpan(0, 0, 1)
					},
					// Expose DUT to test gas for 3 minutes, recording data.
					new TestComponent("Run 10")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 25.0 }
							}
						},
						Samples = 180,
						Interval = new TimeSpan(0, 0, 1)
					},
					// Expose DUT to ambient air for 7 minutes.
					new TestComponent("Run 11")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 21.0 }
							}
						},
						Samples = 420,
						Interval = new TimeSpan(0, 0, 1)
					},
					// Expose DUT to test gas for 3 minutes, recording data.
					new TestComponent("Run 12")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 25.0 }
							}
						},
						Samples = 180,
						Interval = new TimeSpan(0, 0, 1)
					},
					// Expose DUT to ambient air for 7 minutes.
					new TestComponent("Run 13")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 21.0 }
							}
						},
						Samples = 420,
						Interval = new TimeSpan(0, 0, 1)
					},
					// Expose DUT to test gas for 3 minutes, recording data.
					new TestComponent("Run 14")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 25.0 }
							}
						},
						Samples = 180,
						Interval = new TimeSpan(0, 0, 1)
					},
					// Expose DUT to ambient air for 7 minutes.
					new TestComponent("Run 3")
					{
						Variables = new List<TestVariable>
						{
							new TestVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 21.0 }
							}
						},
						Samples = 420,
						Interval = new TimeSpan(0, 0, 1)
					}
				}
			},
			new TestSetting("Long-term Stability"),
			new TestSetting("Thermal Effects"),
			new TestSetting("Thermal Transients"),
			new TestSetting("Cross-Sensitivity"),
			new TestSetting("Humidity Effects")
		};
	}
}
