using System;
using System.Collections.Generic;
using System.ComponentModel;
using Sensit.TestSDK.Interfaces;

namespace Sensit.App.Calibration
{
	/// <summary>
	/// Configuration for a variable being controlled during a test.
	/// </summary>
	public class TestControlledVariable
	{
		[Category("Test Variable"), Description("Type of the variable.")]
		public VariableType VariableType { get; set; }

		[Category("Test Variable"), Description("Error tolerance around setpoints [% full scale].  If exceeded, Stability Time will reset.")]
		public double ErrorTolerance { get; set; } = 2.0;

		[Category("Test Variable"), Description("Tolerated rate of change of setpoints [% full scale / s].  If exceeded, Stability Time will reset.")]
		public double RateTolerance { get; set; } = 0.5;

		[Category("Test Variable"), Description("Setpoints [% full scale].")]
		public List<double> Setpoints { get; set; }

		[Category("Test Variable"), Description("Required time to be at setpoint before continuing test.")]
		public TimeSpan DwellTime { get; set; } = new TimeSpan(0, 0, 0);

		[Category("Test Variable"), Description("Timeout before aborting control.")]
		public TimeSpan Timeout { get; set; } = new TimeSpan(0, 0, 30);

		[Category("Test Component"), Description("Number of samples taken from DUT at each setpoint.")]
		public int Samples { get; set; } = 0;

		[Category("Test Component"), Description("Time to wait between taking samples from DUT/variables.")]
		public TimeSpan Interval { get; set; } = new TimeSpan(0, 0, 1);
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

		[Category("Test Component"), Description("Actions to perform on the DUT during this test component.")]
		public List<Test.Command> Commands { get; set; }

		[Category("Test Component"), Description("Controlled variables for this part of the test.")]
		public List<TestControlledVariable> ControlledVariables { get; set; }
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

		[Category("Test Settings"), Description("Variables measured (with reference devices) during the test.")]
		public List<VariableType> References { get; set; }
	}

	[Serializable]
	public class TestSettings : Attribute
	{
		[Category("Test Settings"), Description("Settings describing tests that can be performed.")]
		public List<TestSetting> Tests { get; set; } = new List<TestSetting>
		{
			new TestSetting("Flow Rate Test")
			{
				References = new List<VariableType>
				{
					VariableType.MassFlow,
					VariableType.GasConcentration
				},
				Components = new List<TestComponent>
				{
					new TestComponent("Purge")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 500.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0.0 },
								DwellTime = new TimeSpan(0, 4, 0),
								Interval = new TimeSpan(0, 0, 1)
							}
						}
					},
					new TestComponent("100 sccm")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 100 },
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 100.0 },
								Samples = 240,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							},
						},
					},
					new TestComponent("Purge")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 500.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0.0 },
								DwellTime = new TimeSpan(0, 4, 0),
								Interval = new TimeSpan(0, 0, 1)
							}
						}
					},
					new TestComponent("200 sccm")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 100 },
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 200.0 },
								Samples = 240,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
					new TestComponent("Purge")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 500.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0.0 },
								DwellTime = new TimeSpan(0, 4, 0),
								Interval = new TimeSpan(0, 0, 1)
							}
						}
					},
					new TestComponent("300 sccm")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 100 },
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 },
								Samples = 240,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
					new TestComponent("Purge")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 500.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0.0 },
								DwellTime = new TimeSpan(0, 4, 0),
								Interval = new TimeSpan(0, 0, 1)
							}
						}
					},
					new TestComponent("400 sccm")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 100 },
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 400.0 },
								Samples = 240,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
					new TestComponent("Purge")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 500.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0.0 },
								DwellTime = new TimeSpan(0, 4, 0),
								Interval = new TimeSpan(0, 0, 1)
							}
						}
					},
					new TestComponent("500 sccm")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 100 },
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 500.0 },
								Samples = 240,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
				}
			},
			new TestSetting("Warm-Up Stability")
			{
				References = new List<VariableType>
				{
					VariableType.MassFlow,
					VariableType.GasConcentration
				},
				Components = new List<TestComponent>
				{
					// Apply gas for 5 minutes.
					new TestComponent("Apply gas")
					{
						Commands = new List<Test.Command> { Test.Command.TurnOff },
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								DwellTime = new TimeSpan(0, 5, 0),
								Setpoints = new List<double> { 25.0 }
							}
						}
					},
					// Measure stability every second for 30 minutes.
					new TestComponent("Measure stability")
					{
						Commands = new List<Test.Command> { Test.Command.TurnOn },
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 25.0 },
								Samples = 1800,
								Interval = new TimeSpan(0, 0, 1)
							}
						},
					}
				}
			},
			// Calibrate the G3's 2611 (using 70% LEL analyte)
			new TestSetting("G3: 2611 Calibration (70% LEL analyte)")
			{
				References = new List<VariableType>
				{
					VariableType.MassFlow,
					VariableType.GasConcentration
				},
				Components = new List<TestComponent>
				{
					// Warm up for 30 min.  Measure gas every 1 second.  Don't wait for stability.
					new TestComponent("30-min Warmup")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0 },
								Samples = 1800,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
					// Set gas to 50% LEL (2.5% V).
					new TestComponent("Apply 50% LEL Methane")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								// 71.43% of 70% LEL is 50% LEL.
								Setpoints = new List<double> { 71.43 },
								Samples = 60,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
					// Calibrate.
					new TestComponent("Calibration")
					{
						Commands = new List<Test.Command> { Test.Command.Span }
					},
					// Monitor for a bit.
					new TestComponent("1 minute at 50% LEL Methane")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								// 71.43% of 70% LEL is 50% LEL.
								Setpoints = new List<double> { 71.43 },
								Samples = 60,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
				}
			},
			// Test second curve on the G3 (up to 5000 ppm)
			// Linearity: 1-cycle, 100% varying increments, warmup
			new TestSetting("G3: 5000 ppm")
			{
				References = new List<VariableType>
				{
					VariableType.MassFlow,
					VariableType.GasConcentration
				},
				Components = new List<TestComponent>
				{
					// Warm up for 1 hour.  Measure gas every 1 second.  Don't wait for stability.
					new TestComponent("1-hour Warmup")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0 },
								Samples = 3600,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
					// Perform zero calibration after warmup.
					new TestComponent("Auto Zero")
					{
						Commands = new List<Test.Command> { Test.Command.Zero }
					},
					// Ramp up and down.  Measure gas every 1 second.  Don't wait for stability.
					new TestComponent("Up and Down")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double>
								{
									0, 0.66666, 1.33333, 2, 2.66666, 3.33333, 4, 8, 12, 16, 20, 24, 28, 32, 36, 40, 44, 48, 52, 56, 60, 64, 68, 72, 76, 80, 84, 88, 92, 96, 100,
									100, 96, 92, 88, 84, 80, 76, 72, 68, 64, 60, 56, 52, 48, 44, 40, 36, 32, 28, 24, 20, 16, 12, 8, 4, 3.33333, 2.66666, 2, 1.33333, 0.66666, 0
								},
								Samples = 240,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
				}
			},
			// Test third curve on the G3 (5000 ppm to 70% LEL/3.5%V)
			// Linearity: 1-cycle, 93% varying increments, warmup
			new TestSetting("G3: 70% LEL")
			{
				References = new List<VariableType>
				{
					VariableType.MassFlow,
					VariableType.GasConcentration
				},
				Components = new List<TestComponent>
				{
					// Warm up for 30 min.  Measure gas every 1 second.  Don't wait for stability.
					new TestComponent("30-min Warmup")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0 },
								Samples = 1800,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
					// Set gas to 50% LEL (2.5% V).
					new TestComponent("Apply 50% LEL Methane")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								// 71.43% of 70% LEL is 2.5% LEL.
								Setpoints = new List<double> { 71.43 },
								Samples = 60,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
					// Calibrate.
					new TestComponent("Calibration")
					{
						Commands = new List<Test.Command> { Test.Command.Span }
					},
					// Warm up for 30 min.  Measure gas every 1 second.  Don't wait for stability.
					new TestComponent("30-min Warmup")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0 },
								Samples = 1800,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
					// Perform zero calibration after warmup.
					new TestComponent("Auto Zero")
					{
						Commands = new List<Test.Command> { Test.Command.Zero }
					},
					// Ramp up and down.  Measure gas every 1 second.  Don't wait for stability.
					new TestComponent("Up and Down")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double>
								{
									0, 3.57, 7.14, 10.71, 14.29, 17.86, 21.43, 25, 28.57, 42.86, 57.14, 71.43, 85.71, 100,
									100, 85.71, 71.43, 57.14, 42.86, 28.57, 25, 21.43, 17.86, 14.29, 10.71, 7.14, 3.57, 0
								},
								Samples = 240,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
				}
			},
			// Same thing as the other 70% LEL test, but using 75% LEL analyte.
			new TestSetting("G3: 70% LEL (using 75% LEL analyte)")
			{
				References = new List<VariableType>
				{
					VariableType.MassFlow,
					VariableType.GasConcentration
				},
				Components = new List<TestComponent>
				{
					// Warm up for 30 min.  Measure gas every 1 second.  Don't wait for stability.
					new TestComponent("30-min Warmup")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0 },
								Samples = 1800,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
					// Set gas to 50% LEL (2.5% V).
					new TestComponent("Apply 50% LEL Methane")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								// 66.66667% of 75% LEL is 50% LEL.
								Setpoints = new List<double> { 66.66667 },
								Samples = 60,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
					// Calibrate.
					new TestComponent("Calibration")
					{
						Commands = new List<Test.Command> { Test.Command.Span }
					},
					// Warm up for 30 min.  Measure gas every 1 second.  Don't wait for stability.
					new TestComponent("30-min Warmup")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0 },
								Samples = 1800,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
					// Perform zero calibration after warmup.
					new TestComponent("Auto Zero")
					{
						Commands = new List<Test.Command> { Test.Command.Zero }
					},
					// Ramp up and down.  Measure gas every 1 second.  Don't wait for stability.
					new TestComponent("Up and Down")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double>
								{
									0, 3.33333, 6.66667, 10, 13.33333, 16.66667, 20, 23.33333, 26.66667, 40, 53.33333, 66.66667, 80, 93.33333,
									93.33333, 80, 66.66667, 53.33333, 40, 26.66667, 23.33333, 20, 16.66667, 13.33333, 10, 6.66667, 3.33333, 0
								},
								Samples = 240,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
				}
			},
			new TestSetting("Linearity: 1-cycle, 100% / 10")
			{
				References = new List<VariableType>
				{
					VariableType.MassFlow,
					VariableType.GasConcentration
				},
				Components = new List<TestComponent>
				{
					// Ramp up and down.  Measure gas every 1 second.  Don't wait for stability.
					new TestComponent("Up and Down")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 100, 90, 80, 70, 60, 50, 40, 30, 20, 10, 0 },
								Samples = 240,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
				}
			},
			new TestSetting("Linearity: 1-cycle, 100% / 10, warmup")
			{
				References = new List<VariableType>
				{
					VariableType.MassFlow,
					VariableType.GasConcentration
				},
				Components = new List<TestComponent>
				{
					// Warm up for 1 hour.  Measure gas every 1 second.  Don't wait for stability.
					new TestComponent("Warmup")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0 },
								Samples = 3600,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
					// Perform zero calibration after warmup.
					new TestComponent("Auto Zero")
					{
						Commands = new List<Test.Command> { Test.Command.Zero }
					},
					// Ramp up and down.  Measure gas every 1 second.  Don't wait for stability.
					new TestComponent("Up and Down")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 100, 90, 80, 70, 60, 50, 40, 30, 20, 10, 0 },
								Samples = 240,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
				}
			},
			new TestSetting("Linearity: 1-cycle, 50% / 5")
			{
				References = new List<VariableType>
				{
					VariableType.MassFlow,
					VariableType.GasConcentration
				},
				Components = new List<TestComponent>
				{
					// Ramp up and down.  Measure gas every 1 second.  Don't wait for stability.
					new TestComponent("Up and Down")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 50, 45, 40, 35, 30, 25, 20, 15, 10, 5, 0 },
								Samples = 240,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
				}
			},
			new TestSetting("Linearity: 1-cycle, 25% / 2.5")
			{
				References = new List<VariableType>
				{
					VariableType.MassFlow,
					VariableType.GasConcentration
				},
				Components = new List<TestComponent>
				{
					// Ramp up and down.  Measure gas every 1 second.  Don't wait for stability.
					new TestComponent("Up and Down")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0.0, 2.5, 5.0, 7.5, 10.0, 12.5, 15.0, 17.5, 20.0, 22.5, 25.0, 25.0, 22.5, 20.0, 17.5, 15.0, 12.5, 10.0, 7.5, 5.0, 2.5, 0.0 },
								Samples = 240,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
				}
			},
			new TestSetting("Linearity: 1-cycle, 100% / 5, warmup")
			{
				References = new List<VariableType>
				{
					VariableType.MassFlow,
					VariableType.GasConcentration
				},
				Components = new List<TestComponent>
				{
					// Warm up for 1 hour.  Measure gas every 1 second.  Don't wait for stability.
					new TestComponent("Warmup")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0 },
								Samples = 3600,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
					// Perform zero calibration after warmup.
					new TestComponent("Auto Zero")
					{
						Commands = new List<Test.Command> { Test.Command.Zero }
					},
					// Ramp up and down.  Measure gas every 1 second.  Don't wait for stability.
					new TestComponent("Up and Down")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double>
								{
									0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100,
									100, 95, 90, 85, 80, 75, 70, 65, 60, 55, 50, 45, 40, 35, 30, 25, 20, 15, 10, 5, 0
								},
								Samples = 240,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
				}
			},
			new TestSetting("Linearity: 1-cycle, 50% / 5, warmup")
			{
				References = new List<VariableType>
				{
					VariableType.MassFlow,
					VariableType.GasConcentration
				},
				Components = new List<TestComponent>
				{
					// Warm up for 1 hour.  Measure gas every 1 second.  Don't wait for stability.
					new TestComponent("Warmup")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0 },
								Samples = 3600,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
					// Perform zero calibration after warmup.
					new TestComponent("Auto Zero")
					{
						Commands = new List<Test.Command> { Test.Command.Zero }
					},
					// Ramp up and down.  Measure gas every 1 second.  Don't wait for stability.
					new TestComponent("Up and Down")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double>
								{
									0, 2.5, 5.0, 7.5, 10.0, 12.5, 15.0, 17.5, 20.0, 22.5, 25.0, 27.5, 30.0, 32.5, 35.0, 37.5, 40.0, 42.5, 45.0, 47.5, 50.0,
									50.0, 47.5, 45.0, 42.5, 40.0, 37.5, 35.0, 32.5, 30.0, 27.5, 25.0, 22.5, 20.0, 17.5, 15.0, 12.5, 10.0, 7.5, 5.0, 2.5, 0
								},
								Samples = 240,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
				}
			},
			new TestSetting("Linearity: 1-cycle, 50% / 1, warmup")
			{
				References = new List<VariableType>
				{
					VariableType.MassFlow,
					VariableType.GasConcentration
				},
				Components = new List<TestComponent>
				{
					// Warm up for 1 hour.  Measure gas every 1 second.  Don't wait for stability.
					new TestComponent("Warmup")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0 },
								Samples = 3600,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
					// Perform zero calibration after warmup.
					new TestComponent("Auto Zero")
					{
						Commands = new List<Test.Command> { Test.Command.Zero }
					},
					// Ramp up and down.  Measure gas every 1 second.  Don't wait for stability.
					new TestComponent("Up and Down")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double>
								{
									00, 01, 02, 03, 04, 05, 06, 07, 08, 09, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25,
									26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50,
									50, 49, 48, 47, 46, 45, 44, 43, 42, 41, 40, 39, 38, 37, 36, 35, 34, 33, 32, 31, 30, 29, 28, 27, 26, 25,
									24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 09, 08, 07, 06, 05, 04, 03, 02, 01, 00
								},
								Samples = 240,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
				}
			},
			new TestSetting("Linearity: 1-cycle, 25% / 5, warmup")
			{
				References = new List<VariableType>
				{
					VariableType.MassFlow,
					VariableType.GasConcentration
				},
				Components = new List<TestComponent>
				{
					// Warm up for 1 hour.  Measure gas every 1 second.  Don't wait for stability.
					new TestComponent("Warmup")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0 },
								Samples = 3600,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
					// Perform zero calibration after warmup.
					new TestComponent("Auto Zero")
					{
						Commands = new List<Test.Command> { Test.Command.Zero }
					},
					// Ramp up and down.  Measure gas every 1 second.  Don't wait for stability.
					new TestComponent("Up and Down")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double>
								{
									0.00, 1.25, 2.50, 3.75, 5.00, 6.25, 7.50, 8.75, 10.00, 11.25, 12.50, 13.75, 15.00, 16.25, 17.50, 18.75, 20.00, 21.25, 22.50, 23.75, 25.00,
									25.00, 23.75, 22.50, 21.25, 20.00, 18.75, 17.50, 16.25, 15.00, 13.75, 12.50, 11.25, 10.00, 8.75, 7.50, 6.25, 5.00, 3.75, 2.50, 1.25, 0.00
								},
								Samples = 240,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
				}
			},
			new TestSetting("Linearity: 5-cycle, 100% / 10")
			{
				References = new List<VariableType>
				{
					VariableType.MassFlow,
					VariableType.GasConcentration
				},
				Components = new List<TestComponent>
				{
					// Ramp up and down 5 times.  Measure gas every 1 second.  Don't wait for stability.
					new TestComponent("Up and Down 5x")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double>
								{
									0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 100, 90, 80, 70, 60, 50, 40, 30, 20, 10, 0,
									0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 100, 90, 80, 70, 60, 50, 40, 30, 20, 10, 0,
									0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 100, 90, 80, 70, 60, 50, 40, 30, 20, 10, 0,
									0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 100, 90, 80, 70, 60, 50, 40, 30, 20, 10, 0,
									0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 100, 90, 80, 70, 60, 50, 40, 30, 20, 10, 0
								},
								Samples = 240,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
				}
			},
			new TestSetting("Linearity: 5-cycle, 50% / 5")
			{
				References = new List<VariableType>
				{
					VariableType.MassFlow,
					VariableType.GasConcentration
				},
				Components = new List<TestComponent>
				{
					// Ramp up and down 5 times.  Measure gas every 1 second.  Don't wait for stability.
					new TestComponent("Up and Down 5x")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								// Setpoints = new List<double> { 0.0, 2.5, 5.0, 7.5, 10.0, 12.5, 15.0, 17.5, 20.0, 22.5, 25.0, 25.0, 22.5, 20.0, 17.5, 15.0, 12.5, 10.0, 7.5, 5.0, 2.5, 0.0 },
								Setpoints = new List<double>
								{
									0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 50, 45, 40, 35, 30, 25, 20, 15, 10, 5, 0,
									0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 50, 45, 40, 35, 30, 25, 20, 15, 10, 5, 0,
									0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 50, 45, 40, 35, 30, 25, 20, 15, 10, 5, 0,
									0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 50, 45, 40, 35, 30, 25, 20, 15, 10, 5, 0,
									0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 50, 45, 40, 35, 30, 25, 20, 15, 10, 5, 0
								},
								Samples = 240,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
				}
			},
			new TestSetting("Linearity: 5-cycle, 25% / 2.5")
			{
				References = new List<VariableType>
				{
					VariableType.MassFlow,
					VariableType.GasConcentration
				},
				Components = new List<TestComponent>
				{
					// Ramp up and down 5 times.  Measure gas every 1 second.  Don't wait for stability.
					new TestComponent("Up and Down 5x")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double>
								{
									0.0, 2.5, 5.0, 7.5, 10.0, 12.5, 15.0, 17.5, 20.0, 22.5, 25.0, 25.0, 22.5, 20.0, 17.5, 15.0, 12.5, 10.0, 7.5, 5.0, 2.5, 0.0,
									0.0, 2.5, 5.0, 7.5, 10.0, 12.5, 15.0, 17.5, 20.0, 22.5, 25.0, 25.0, 22.5, 20.0, 17.5, 15.0, 12.5, 10.0, 7.5, 5.0, 2.5, 0.0,
									0.0, 2.5, 5.0, 7.5, 10.0, 12.5, 15.0, 17.5, 20.0, 22.5, 25.0, 25.0, 22.5, 20.0, 17.5, 15.0, 12.5, 10.0, 7.5, 5.0, 2.5, 0.0,
									0.0, 2.5, 5.0, 7.5, 10.0, 12.5, 15.0, 17.5, 20.0, 22.5, 25.0, 25.0, 22.5, 20.0, 17.5, 15.0, 12.5, 10.0, 7.5, 5.0, 2.5, 0.0,
									0.0, 2.5, 5.0, 7.5, 10.0, 12.5, 15.0, 17.5, 20.0, 22.5, 25.0, 25.0, 22.5, 20.0, 17.5, 15.0, 12.5, 10.0, 7.5, 5.0, 2.5, 0.0
								},
								Samples = 240,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
				}
			},
			new TestSetting("Transient Response")
			{
				References = new List<VariableType>
				{
					VariableType.MassFlow,
					VariableType.GasConcentration
				},
				Components = new List<TestComponent>
				{
					// Allow DUT to stabilize for 1 hour with normal air applied.
					new TestComponent("Stabilize")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0.0 },
								Samples = 3600,
								Interval = new TimeSpan(0, 0, 1)
							}
						},
					},
					// Apply test gas mixure; record response.
					new TestComponent("Step Up 1")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 25.0 },
								Samples = 350,
								Interval = new TimeSpan(0, 0, 1)
							}
						},
					},
					// Apply normal air; record response.
					new TestComponent("Step Down 1")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0.0 },
								Samples = 350,
								Interval = new TimeSpan(0, 0, 1)
							}
						},
					},
					// Apply test gas mixure; record response.
					new TestComponent("Step Up 2")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 25.0 },
								Samples = 350,
								Interval = new TimeSpan(0, 0, 1)
							}
						},
					},
					// Apply normal air; record response.
					new TestComponent("Step Down 2")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0.0 },
								Samples = 350,
								Interval = new TimeSpan(0, 0, 1)
							}
						},
					},
					// Apply test gas mixure; record response.
					new TestComponent("Step Up 3")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 25.0 },
								Samples = 350,
								Interval = new TimeSpan(0, 0, 1)
							}
						},
					},
					// Apply normal air; record response.
					new TestComponent("Step Down 3")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0.0 },
								Samples = 350,
								Interval = new TimeSpan(0, 0, 1)
							}
						},
					},
					// Apply test gas mixure; record response.
					new TestComponent("Step Up 4")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 25.0 },
								Samples = 350,
								Interval = new TimeSpan(0, 0, 1)
							}
						},
					},
					// Apply normal air; record response.
					new TestComponent("Step Down 4")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0.0 },
								Samples = 350,
								Interval = new TimeSpan(0, 0, 1)
							}
						},
					},
					// Apply test gas mixure; record response.
					new TestComponent("Step Up 5")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 25.0 },
								Samples = 350,
								Interval = new TimeSpan(0, 0, 1)
							}
						},
					},
					// Apply normal air; record response.
					new TestComponent("Step Down 5")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 0.0 },
								Samples = 350,
								Interval = new TimeSpan(0, 0, 1)
							}
						},
					}
				}
			},
			//new TestSetting("Sustained Hysteresis"),
			new TestSetting("Short-term Stability")
			{
				References = new List<VariableType>
				{
					VariableType.MassFlow,
					VariableType.GasConcentration
				},
				Components = new List<TestComponent>
				{
					// Take samples every second for 10 minutes with 21% O2 (the amount in ambient air) applied.
					new TestComponent("Run 1")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 21.0 },
								Samples = 600,
								Interval = new TimeSpan(0, 0, 1)
							}
						},
					},
					// Expose DUT to test gas for 3 minutes, recording data.
					new TestComponent("Run 2")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 25.0 },
								Samples = 180,
								Interval = new TimeSpan(0, 0, 1)
							}
						},
					},
					// Expose DUT to ambient air for 7 minutes.
					new TestComponent("Run 3")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 21.0 },
								Samples = 420,
								Interval = new TimeSpan(0, 0, 1)
							}
						},
					},
					// Expose DUT to test gas for 3 minutes, recording data.
					new TestComponent("Run 4")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 25.0 },
								Samples = 180,
								Interval = new TimeSpan(0, 0, 1)
							}
						},
					},
					// Expose DUT to ambient air for 7 minutes.
					new TestComponent("Run 5")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 21.0 },
								Samples = 420,
								Interval = new TimeSpan(0, 0, 1)
							}
						},
					},
					// Expose DUT to test gas for 3 minutes, recording data.
					new TestComponent("Run 6")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 25.0 },
								Samples = 180,
								Interval = new TimeSpan(0, 0, 1)
							}
						},
					},
					// Expose DUT to ambient air for 7 minutes.
					new TestComponent("Run 7")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 21.0 },
								Samples = 420,
								Interval = new TimeSpan(0, 0, 1)
							}
						},
					},
					// Expose DUT to test gas for 3 minutes, recording data.
					new TestComponent("Run 8")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 25.0 },
								Samples = 180,
								Interval = new TimeSpan(0, 0, 1)
							}
						},
					},
					// Expose DUT to ambient air for 7 minutes.
					new TestComponent("Run 9")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 21.0 },
								Samples = 420,
								Interval = new TimeSpan(0, 0, 1)
							}
						},
					},
					// Expose DUT to test gas for 3 minutes, recording data.
					new TestComponent("Run 10")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 25.0 },
								Samples = 180,
								Interval = new TimeSpan(0, 0, 1)
							}
						},
					},
					// Expose DUT to ambient air for 7 minutes.
					new TestComponent("Run 11")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 21.0 },
								Samples = 420,
								Interval = new TimeSpan(0, 0, 1)
							}
						},
					},
					// Expose DUT to test gas for 3 minutes, recording data.
					new TestComponent("Run 12")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 25.0 },
								Samples = 180,
								Interval = new TimeSpan(0, 0, 1)
							}
						},
					},
					// Expose DUT to ambient air for 7 minutes.
					new TestComponent("Run 13")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 21.0 },
								Samples = 420,
								Interval = new TimeSpan(0, 0, 1)
							}
						},
					},
					// Expose DUT to test gas for 3 minutes, recording data.
					new TestComponent("Run 14")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 25.0 },
								Samples = 180,
								Interval = new TimeSpan(0, 0, 1)
							}
						},
					},
					// Expose DUT to ambient air for 7 minutes.
					new TestComponent("Run 3")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double> { 21.0 },
								Samples = 420,
								Interval = new TimeSpan(0, 0, 1)
							}
						},
					}
				}
			},
			new TestSetting("Fast Linearity, 100%")
			{
				References = new List<VariableType>
				{
					VariableType.MassFlow,
					VariableType.GasConcentration
				},
				Components = new List<TestComponent>
				{
					// Ramp up and down many times to test the mass flow controller.  Measure gas every 1 second.  Don't wait for stability.
					new TestComponent("Up")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double>
								{
									0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 100, 90, 80, 70, 60, 50, 40, 30, 20, 10, 0,
								},
								Samples = 10,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
				},
			},
			new TestSetting("Fast Linearity, 50%")
			{
				References = new List<VariableType>
				{
					VariableType.MassFlow,
					VariableType.GasConcentration
				},
				Components = new List<TestComponent>
				{
					// Ramp up and down many times to test the mass flow controller.  Measure gas every 1 second.  Don't wait for stability.
					new TestComponent("Up and Down")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double>
								{
									0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 50, 45, 40, 35, 30, 25, 20, 15, 10, 5, 0
								},
								Samples = 10,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
				},
			},
			new TestSetting("Fast Linearity, 25%")
			{
				References = new List<VariableType>
				{
					VariableType.MassFlow,
					VariableType.GasConcentration
				},
				Components = new List<TestComponent>
				{
					// Ramp up and down many times to test the mass flow controller.  Measure gas every 1 second.  Don't wait for stability.
					new TestComponent("Up and Down")
					{
						ControlledVariables = new List<TestControlledVariable>
						{
							new TestControlledVariable()
							{
								VariableType = VariableType.MassFlow,
								Setpoints = new List<double> { 300.0 }
							},
							new TestControlledVariable()
							{
								VariableType = VariableType.GasConcentration,
								Setpoints = new List<double>
								{
									0.0, 2.5, 5.0, 7.5, 10.0, 12.5, 15.0, 17.5, 20.0, 22.5, 25.0, 25.0, 22.5, 20.0, 17.5, 15.0, 12.5, 10.0, 7.5, 5.0, 2.5, 0.0,
								},
								Samples = 10,
								Interval = new TimeSpan(0, 0, 0, 0, 500)
							}
						},
					},
				},
			},
			//new TestSetting("Long-term Stability"),
			//new TestSetting("Thermal Effects"),
			//new TestSetting("Thermal Transients"),
			//new TestSetting("Cross-Sensitivity"),
			//new TestSetting("Humidity Effects")
		};
	}
}
