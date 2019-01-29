using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Sensit.App.Calibration
{
	/// <summary>
	/// Components of a test
	/// </summary>
	public enum TestCommand
	{
		SetTemp,    // Go to a temperature setpoint.
		Default,    // Set factory default settings.
		SetRange,   // Set range settings.
		ColdCal,    // Perform cold-temperature compensation calibration.
		RoomCal,    // Perform room-temperature compensation calibration.
		HotCal,     // Perform hot-temperature compensation calibration.
		NoTempCal,  // Perform a temperature-agnostic calibration.
		Verify,     // Gather performance data.
		Zero,       // Perform zero-calibration.
		Span,       // Perform span-calibration.
	}

	public enum ToleranceType
	{
		/// <summary>
		/// Quantity of range.
		/// </summary>
		Absolute,

		/// <summary>
		/// Percent of positive range.
		/// </summary>
		PercentFullScale,

		/// <summary>
		/// Percent of reading.
		/// </summary>
		PercentReading
	}

	/// <summary>
	/// A series of related DUTs and their output characteristics
	/// </summary>
	[Serializable]
	public class ModelSetting
	{
		// Default constructor.
		public ModelSetting() { }

		// The following constructor has parameters for one of the properties.
		public ModelSetting(string label)
		{
			Label = label;
		}

		// This constructor has parameters for the label and list.
		public ModelSetting(string label, List<RangeSetting> rangeSettings)
		{
			Label = label;
			RangeSettings = rangeSettings;
		}

		// This constructor has parameters for all of the properties.
		public ModelSetting(string label, List<RangeSetting> rangeSettings, string type, int minVal, int maxVal)
		{
			Label = label;
			RangeSettings = rangeSettings;
			Type = type;
			MinVal = minVal;
			MaxVal = maxVal;
		}

		[Category("Model Settings"), Description("Name of the DUT series (as it will appear to the operator).")]
		public string Label { get; set; } = "";

		[Category("Model Settings"), Description("Input ranges associated with the DUT series.")]
		public List<RangeSetting> RangeSettings { get; set; }

		[Category("Model Settings"), Description("DUT's minimum output")]
		public double MinVal { get; set; } = 0.0;

		[Category("Model Settings"), Description("DUT's maximum output")]
		public double MaxVal { get; set; } = 5.0;

		[Category("Model Settings"), Description("Type of output DUT has")]
		public string Type { get; set; } = "Volts";
	}

	/// <summary>
	/// A DUT's input characteristics
	/// </summary>
	[Serializable]
	public class RangeSetting
	{
		// Default constructor.
		public RangeSetting() { }

		// Constructor with label.
		public RangeSetting(string label)
		{
			Label = label;
		}

		// This constructor is for unidirectional ranges.
		public RangeSetting(string label, double high)
		{
			Label = label;
			Low = 0.0;
			High = high;
		}

		// This constructor is for bidirectional ranges.
		public RangeSetting(string label, double low, double high)
		{
			Label = label;
			Low = low;
			High = high;
		}

		// Constructor with a single tolerance.
		public RangeSetting(string label, double low, double high, double tolerance, ToleranceType type)
		{
			Label = label;
			Low = low;
			High = high;

			// For a range with a single tolerance, the tolerance will always have the same high and low
			// values as the range itself.
			ToleranceSettings = new List<ToleranceSetting> { new ToleranceSetting(low, high, tolerance, type) };
		}

		// Constructor with all properties (including multiple tolerances).
		public RangeSetting(string label, double low, double high, List<ToleranceSetting> tolerances)
		{
			Label = label;
			Low = low;
			High = high;
			ToleranceSettings = tolerances;
		}

		[Category("Range Settings"), Description("Name of the range (as it will appear to the operator).")]
		public string Label { get; set; } = "";

		[Category("Range Settings"), Description("DUT's minimum input [volume %]")]
		public double Low { get; set; } = 0.0;

		[Category("Range Settings"), Description("DUT's maximum input [volume %]")]
		public double High { get; set; } = 1.0;

		[Category("Test Settings"), Description(
			"Pass/fail tolerance for the DUT. " +
			"Unit varies according to Tolerance Type.")]
		public List<ToleranceSetting> ToleranceSettings { get; set; }
	}

	/// <summary>
	/// A ranged tolerance.
	/// </summary>
	/// <remarks>
	/// A range setting has one or more tolerance settings.  This happens, for
	/// example, if accuracy is "5 PPM or 10% of reading, whichever is greater."
	/// </remarks>
	[Serializable]
	public class ToleranceSetting
	{
		// Constructor with no parameters.
		public ToleranceSetting() { }

		// Constructor with parameters.
		public ToleranceSetting(double low, double high, double tolerance, ToleranceType type)
		{
			Low = low;
			High = high;
			Tolerance = tolerance;
			Type = type;
		}

		[Category("Range Settings"), Description("Low bound of the tolerance range.")]
		public double Low { get; set; }

		[Category("Range Settings"), Description("High bound of the tolerance range.")]
		public double High { get; set; }

		[Category("Range Settings"), Description("Allowable tolerance.")]
		public double Tolerance { get; set; }

		[Category("Range Settings"), Description("Type of tolerance. Percent Full Scale, Percent Reading, or Greater of both")]
		public ToleranceType Type { get; set; }
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

		[Category("Range Settings"), Description(
			"True if test requires writing to DUT, false otherwise. " +
			"We write to a DUT during calibration. " +
			"In verification, we avoid erasing previous calibrations.")]
		public bool WriteEnable { get; set; } = false;

		[Category("Test Settings"), Description("Components of the test")]
		public List<TestCommand> Commands { get; set; }

		[Category("Test Settings"), Description(
			"Setpoints for calibration [% full scale]. +" +
			"Required if calibration is part of the test.")]
		public List<double> CalibrationSetpoints { get; set; }

		[Category("Test Settings"), Description(
			"Setpoints for verification [% full scale]. " +
			"Required if verification is part of the test.")]
		public List<double> VerifiySetpoints { get; set; }

		[Category("Test Settings"), Description("Tolerance for temperature drift during tests without resetting temperature dwell time [degrees].")]
		public double TemperatureTolerance { get; set; } = 4.0;

		[Category("Test Settings"), Description("Time to wait after achieving temperature setpoint before proceeding with test [minutes]")]
		public int TemperatureDwellTime { get; set; } = 60;

		[Category("Test Settings"), Description("Number of samples taken from DUT at each setpoint.")]
		public int NumberOfSamples { get; set; } = 1;

		[Category("Test Settings"), Description("Time to wait between each sample [s].")]
		public int SampleInterval { get; set; } = 0;

		[Category("Test Settings"), Description("Error tolerance around setpoints [% full scale].")]
		public double SetpointErrorTolerance { get; set; } = 3.0;

		[Category("Test Settings"), Description("Tolerated rate of change of setpoints [% full scale / s].")]
		public double SetpointRateTolerance { get; set; } = 2.0;

		[Category("Test Settings"), Description("Required time to be at setpoint [s].")]
		public int SetpointStabilityTime { get; set; } = 15;

		[Category("Test Settings"), Description("Timeout before aborting setpoint control [s].")]
		public int SetpointTimeout { get; set; } = 200;
	}

	[Serializable]
	public class ProductSettings : Attribute
	{
		[Category("Product Settings"), Description("Settings for Model, Range, Test.")]
		public string Label { get; set; } = "Product Settings";

		[Category("Product Settings"), Description("Settings describing tests that can be performed.")]
		public List<TestSetting> TestSettings { get; set; } = new List<TestSetting>
		{
			new TestSetting("Warm-Up Time"),
			new TestSetting("Linearity"),
			new TestSetting("Transient Response"),
			new TestSetting("Sustained Hysteresis"),
			new TestSetting("Short-term Stability"),
			new TestSetting("Long-term Stability"),
			new TestSetting("Thermal Effects"),
			new TestSetting("Thermal Transients"),
			new TestSetting("Cross-Sensitivity"),
			new TestSetting("Humidity Effects")
		};

		[Category("Product Settings"), Description("Settings describing a product series.")]
		public List<ModelSetting> ModelSettings { get; set; } = new List<ModelSetting>
		{
			new ModelSetting("Simulator", new List<RangeSetting>
			{
				new RangeSetting("0 - 10,000 PPM (1% V)", 0.0, 1.0, 10.0, ToleranceType.PercentReading),
				new RangeSetting("0 - 100 %LEL (2.2% V)", 0.0, 2.2, 10.0, ToleranceType.PercentReading),
				new RangeSetting("2.2 - 100% V",          2.2, 100, 5.0, ToleranceType.PercentReading),
				new RangeSetting("0 - 25% V", 0.0, 25.0, new List<ToleranceSetting>
				{
					new ToleranceSetting(0.0, 0.2, 0.2, ToleranceType.Absolute),
					new ToleranceSetting(0.2, 25.0, 10.0, ToleranceType.PercentReading)
				}),
				new RangeSetting("0 - 2,000 PPM", 0.0000, 0.2000, new List<ToleranceSetting>
				{
					new ToleranceSetting(0.0000, 0.0010, 0.0005, ToleranceType.Absolute),
					new ToleranceSetting(0.0010, 0.2000, 5.0, ToleranceType.PercentReading)
				})
			}),
			new ModelSetting("Propane", new List<RangeSetting>
			{
				new RangeSetting("0 - 10,000 PPM (1% V)", 0.0, 1.0, 10.0, ToleranceType.PercentReading),
				new RangeSetting("0 - 100 %LEL (2.2% V)", 0.0, 2.2, 10.0, ToleranceType.PercentReading),
				new RangeSetting("2.2 - 100% V",          2.2, 100, 5.0, ToleranceType.PercentReading)
			}),
			new ModelSetting("Methane", new List<RangeSetting>
			{
				new RangeSetting("0 - 10,000 PPM (1% V)", 0.0, 1.0, 10.0, ToleranceType.PercentReading),
				new RangeSetting("0 - 100 %LEL (5.0% V)", 0.0, 5.0, 10.0, ToleranceType.PercentReading),
				new RangeSetting("2.2 - 100% V",          5.0, 100, 5.0, ToleranceType.PercentReading)
			}),
			new ModelSetting("Oxygen (O2)", new List<RangeSetting>
			{
				new RangeSetting("0 - 25% V", 0.0, 25.0, new List<ToleranceSetting>
				{
					new ToleranceSetting(0.0, 0.2, 0.2, ToleranceType.Absolute),
					new ToleranceSetting(0.2, 25.0, 10.0, ToleranceType.PercentReading)
				})
			}),
			new ModelSetting("Carbon Monoxide (CO)", new List<RangeSetting>
			{
				new RangeSetting("0 - 2,000 PPM", 0.0000, 0.2000, new List<ToleranceSetting>
				{
					new ToleranceSetting(0.0000, 0.0010, 0.0005, ToleranceType.Absolute),
					new ToleranceSetting(0.0010, 0.2000, 5.0, ToleranceType.PercentReading)
				})
			}),

			// Specification for CO2 is unknown at present.
			new ModelSetting("Carbon Dioxide (CO2)"),

			new ModelSetting("Hydrogen Sulfide (H2S)", new List<RangeSetting>
			{
				new RangeSetting("0 - 100 PPM", 0.0000, 0.0100, new List<ToleranceSetting>
				{
					new ToleranceSetting(0.0000, 0.0004, 0.0002, ToleranceType.Absolute),
					new ToleranceSetting(0.0004, 0.0100, 5.0, ToleranceType.PercentReading)
				})
			}),
			new ModelSetting("Hydrogen Cyanide (HCN)", new List<RangeSetting>
			{
				new RangeSetting("0 - 30 PPM", 0.0000, 0.0030, new List<ToleranceSetting>
				{
					new ToleranceSetting(0.0000, 0.0004, 0.0002, ToleranceType.Absolute),
					new ToleranceSetting(0.0004, 0.0030, 5.0, ToleranceType.PercentReading)
				})
			}),
			new ModelSetting("Sulfer Dioxide (SO2)", new List<RangeSetting>
			{
				new RangeSetting("0 - 20 PPM", 0.0000, 0.0020, new List<ToleranceSetting>
				{
					new ToleranceSetting(0.0000, 0.0010, 0.0001, ToleranceType.Absolute),
					new ToleranceSetting(0.0010, 0.0020, 5.0, ToleranceType.PercentReading)
				})
			})
		};
	}
}
