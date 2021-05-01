using System;
using System.Globalization;
using System.Windows.Forms;

namespace Sensit.TestSDK.Controls
{
	public partial class UserControlVariableStatus : UserControl
	{
		public UserControlVariableStatus()
		{
			InitializeComponent();
		}

		#region Properties

		public string Title
		{
			get => groupBox.Text;
			set => groupBox.Text = value;
		}

		public decimal Value
		{
			get => Convert.ToDecimal(textBoxValue.Text, CultureInfo.InvariantCulture);
			set => textBoxValue.Text = value.ToString(CultureInfo.CurrentCulture);
		}

		public decimal Setpoint
		{
			get => Convert.ToDecimal(textBoxSetpoint.Text, CultureInfo.InvariantCulture);
			set => textBoxSetpoint.Text = value.ToString(CultureInfo.CurrentCulture);
		}

		public decimal Tolerance
		{
			get => Convert.ToDecimal(textBoxTolerance.Text, CultureInfo.InvariantCulture);
			set => textBoxTolerance.Text = value.ToString(CultureInfo.CurrentCulture);
		}

		public string UnitOfMeasure
		{
			get => labelUnitOfMeasure.Text;
			set => labelUnitOfMeasure.Text = value;
		}

		#endregion
	}
}
