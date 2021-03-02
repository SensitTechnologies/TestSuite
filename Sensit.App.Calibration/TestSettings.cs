using System;
using System.Collections.Generic;
using System.ComponentModel;
using Sensit.TestSDK.Interfaces;
using System.Xml.Serialization;
using System.Xml;

namespace Sensit.App.Calibration
{
	/// <summary>
	/// Configuration for a variable being controlled during a test.
	/// </summary>
	[Serializable]
	public class TestControlledVariable
	{
		[Category("Test Variable"), Description("Type of the variable.")]
		public VariableType VariableType { get; set; }

		[Category("Test Variable"), Description("Error tolerance around setpoints [% full scale].  If exceeded, Stability Time will reset.")]
		public double ErrorTolerance { get; set; } = 5.0;

		[Category("Test Variable"), Description("Tolerated rate of change of setpoints [% full scale / s].  If exceeded, Stability Time will reset.")]
		public double RateTolerance { get; set; } = 0.5;

		[Category("Test Variable"), Description("Setpoints [% full scale].")]
		public List<double> Setpoints { get; set; }

		// TimeSpans aren't serializable, see this for workaround:
		// https://stackoverflow.com/questions/637933/how-to-serialize-a-timespan-to-xml
		[Category("Test Variable"), Description("Required time to be at setpoint before continuing test."), XmlIgnore]
		public TimeSpan DwellTime { get; set; } = new TimeSpan(0, 0, 0);

		// XmlSerializer does not support TimeSpan, so use this property for serialization instead.
		[Browsable(false), XmlElement(DataType = "duration", ElementName = "DwellTime")]
		public string DwellTimeString
		{
			get { return XmlConvert.ToString(DwellTime); }
			set { DwellTime = string.IsNullOrEmpty(value) ? TimeSpan.Zero : XmlConvert.ToTimeSpan(value); }
		}

		// TimeSpans aren't serializable, so ignore.
		[Category("Test Variable"), Description("Timeout before aborting control."), XmlIgnore]
		public TimeSpan Timeout { get; set; } = new TimeSpan(0, 0, 30);

		// XmlSerializer does not support TimeSpan, so use this property for serialization instead.
		[Browsable(false), XmlElement(DataType = "duration", ElementName = "Timeout")]
		public string TimeoutString
		{
			get { return XmlConvert.ToString(Timeout); }
			set { Timeout = string.IsNullOrEmpty(value) ? TimeSpan.Zero : XmlConvert.ToTimeSpan(value); }
		}

		[Category("Test Component"), Description("Number of samples taken from DUT at each setpoint.")]
		public int Samples { get; set; } = 0;

		// TimeSpans aren't serializable, so ignore.
		[Category("Test Component"), Description("Time to wait between taking samples from DUT/variables."), XmlIgnore]
		public TimeSpan Interval { get; set; } = new TimeSpan(0, 0, 1);

		// XmlSerializer does not support TimeSpan, so use this property for serialization instead.
		[Browsable(false), XmlElement(DataType = "duration", ElementName = "Interval")]
		public string IntervalString
		{
			get { return XmlConvert.ToString(Interval); }
			set { Interval = string.IsNullOrEmpty(value) ? TimeSpan.Zero : XmlConvert.ToTimeSpan(value); }
		}
	}

	/// <summary>
	/// Configuration for a component of a test.
	/// </summary>
	[Serializable]
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
	public class TestSettings
	{
		[Category("Test Settings"), Description("Settings describing tests that can be performed.")]
		public List<TestSetting> Tests { get; set; }

		public void Initialize()
		{
			Tests = new List<TestSetting>
			{
				new TestSetting("5min 0, 5min 100")
				{
					References = new List<VariableType>
					{
						VariableType.MassFlow,
						VariableType.GasConcentration
					},
					Components = new List<TestComponent>
					{
						new TestComponent("Apply 0%V analyte, 5 min")
						{
							ControlledVariables = new List<TestControlledVariable>
							{
								new TestControlledVariable()
								{
									VariableType = VariableType.MassFlow,
									Setpoints = new List<double> { 400.0 },
								},
								new TestControlledVariable()
								{
									VariableType = VariableType.GasConcentration,
									Setpoints = new List<double> { 0.0 },
									Samples = 300,
									Interval = new TimeSpan(0, 0, 0, 1)
								}
							}
						},
						new TestComponent("Apply 100% analyte, 5 min")
						{
							ControlledVariables = new List<TestControlledVariable>
							{
								new TestControlledVariable()
								{
									VariableType = VariableType.MassFlow,
									Setpoints = new List<double> { 400.0 },
								},
								new TestControlledVariable()
								{
									VariableType = VariableType.GasConcentration,
									Setpoints = new List<double> { 100.0 },
									Samples = 300,
									Interval = new TimeSpan(0, 0, 0, 1)
								}
							}
						},
						new TestComponent("Turn off DUT")
						{
							Commands = new List<Test.Command> { Test.Command.TurnOff }
						},
					},
				},
				new TestSetting("5min 0, 0, 0.6, 1.3, 2, 2.6, 3.3, 4, 8, 12...100")
				{
					References = new List<VariableType>
					{
						VariableType.MassFlow,
						VariableType.GasConcentration
					},
					Components = new List<TestComponent>
					{
						// Warm up for 5 min.  Measure gas every 1 second.  Don't wait for stability.
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
									Samples = 300,
									Interval = new TimeSpan(0, 0, 0, 0, 500)
								}
							},
						},
						// Ramp up.  Measure gas every 1 second.  Don't wait for stability.
						new TestComponent("Ramp up")
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
									},
									Samples = 240,
									Interval = new TimeSpan(0, 0, 0, 0, 500)
								}
							},
						},
						new TestComponent("Turn off DUT")
						{
							Commands = new List<Test.Command> { Test.Command.TurnOff }
						},
					}
				},
				// Test third curve on the G3 (5000 ppm to 70% LEL/3.5%V)
				// Linearity: 1-cycle, 93% varying increments, warmup
				new TestSetting("5min 0, 0, 3, 7, 10, 14, 17, 21, 25, 28, 42, 57, 71, 85, 100, 100...0")
				{
					References = new List<VariableType>
					{
						VariableType.MassFlow,
						VariableType.GasConcentration
					},
					Components = new List<TestComponent>
					{
						// Warm up for 5 min.  Measure gas every 1 second.  Don't wait for stability.
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
									Samples = 300,
									Interval = new TimeSpan(0, 0, 0, 0, 500)
								}
							},
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
						new TestComponent("Turn off DUT")
						{
							Commands = new List<Test.Command> { Test.Command.TurnOff }
						},
					}
				},
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
						new TestComponent("Turn off DUT")
						{
							Commands = new List<Test.Command> { Test.Command.TurnOff }
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
						},
						new TestComponent("Turn off DUT")
						{
							Commands = new List<Test.Command> { Test.Command.TurnOff }
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
						new TestComponent("Turn off DUT")
						{
							Commands = new List<Test.Command> { Test.Command.TurnOff }
						},
					}
				},
				new TestSetting("Linearity: 1-cycle, 100% / 5")
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
						new TestComponent("Turn off DUT")
						{
							Commands = new List<Test.Command> { Test.Command.TurnOff }
						},
					}
				},
				new TestSetting("Linearity: 1-cycle, 100% / 2.5")
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
									Setpoints = new List<double>
									{
										0, 2.5, 5.0, 7.5, 10.0, 12.5, 15.0, 17.5, 20.0, 22.5, 25.0, 27.5, 30.0, 32.5, 35.0, 37.5, 40.0, 42.5, 45.0, 47.5, 50.0,
										52.5, 55.0, 57.5, 60.0, 62.5, 65.0, 67.5, 70.0, 72.5, 75.0, 77.5, 80.0, 82.5, 85.0, 87.5, 90.0, 92.5, 95.0, 97.5, 100.0,
										100.0, 97.5, 95.0, 92.5, 90.0, 87.5, 85.0, 82.5, 80.0, 77.5, 75.0, 72.5, 70.0, 67.5, 65.0, 62.5, 60.0, 57.5, 55.0, 52.5,
										50.0, 47.5, 45.0, 42.5, 40.0, 37.5, 35.0, 32.5, 30.0, 27.5, 25.0, 22.5, 20.0, 17.5, 15.0, 12.5, 10.0, 7.5, 5.0, 2.5, 0,
									},
									Samples = 240,
									Interval = new TimeSpan(0, 0, 0, 0, 500)
								}
							},
						},
						new TestComponent("Turn off DUT")
						{
							Commands = new List<Test.Command> { Test.Command.TurnOff }
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
						new TestComponent("Turn off DUT")
						{
							Commands = new List<Test.Command> { Test.Command.TurnOff }
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
						},
						new TestComponent("Turn off DUT")
						{
							Commands = new List<Test.Command> { Test.Command.TurnOff }
						},
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
						},
						new TestComponent("Turn off DUT")
						{
							Commands = new List<Test.Command> { Test.Command.TurnOff }
						},
					}
				},
				new TestSetting("Fast Linearity, 100% / 10")
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
						new TestComponent("Turn off DUT")
						{
							Commands = new List<Test.Command> { Test.Command.TurnOff }
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
}
