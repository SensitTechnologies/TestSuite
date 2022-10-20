using System.Globalization;
using CsvHelper.Configuration;

namespace Sensit.App.GPS
{
	public class GPSDataRecord
	{
		#region Properties

		//Data derived from form.
		public string? ComPortLocation { get; set; }
		public bool IsPanel { get; set; }
		public string PanelLocation { get; set; } = string.Empty;
		public string TestDuration { get; set; } = string.Empty;

		//Data derived from user inputs.
		public string PanelSerialNumber { get; set; } = string.Empty;
		public double UserLatitude { get; set; }
		public double UserLongitude { get; set; }
		public int TestTimeout { get; set; }
		public string UserName { get; set; } = string.Empty;

		//Indicates whether or not this board's test passed or failed
		public bool TestValid { get; set; }

		//Properties of GPS board
		public string BoardSerialNumber { get; set; } = string.Empty;
		public DateTime UTCTime { get; set; } = DateTime.MinValue;
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public double FixQuality { get; set; }
		public double SatelliteCount { get; set; }
		public double HDOP { get; set; } //Horizontal Dilution of Precision
		public double Altitude { get; set; }
		public double HeightOfGeoid { get; set; } //Height of geoid above WGS84 ellipsoid
		public string Checksum { get; set; } = string.Empty;

		//Tolerances allowed for testing
		public double PositionTolerance { get; set; }
		public TimeSpan TimeTolerance { get; set; }

		#endregion

		/// <summary>
		/// Take inputted data and set it to class properties
		/// IF data recieved passes validation. 
		/// </summary>
		/// <param name="message">Message GPS board recieved from the GPS antenna.</param>
		public void SetRecords(string message)
		{
			//Split the message
			string[] pieces = message.Split(',');

			//piece 0 = message type
			//Check message type and length
			if (pieces[0] == "$GPGGA" && pieces.Length == 15)
			{
				//piece 1 = date/time
				DateTime.TryParseExact(pieces[1],
							"HHmmss.fff",
							CultureInfo.InvariantCulture,
							DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal, out DateTime date);
				UTCTime = date;

				//piece 2 = latitude, 3 = latitude direction
				double latitudeConversion = (double.TryParse(pieces[2], out latitudeConversion) ? latitudeConversion : 0) / 100;
				Latitude = (pieces[3] == "S") ? (latitudeConversion *= -1) : latitudeConversion;

				//piece 4 = longitude, piece 5 = longitude direction
				double longitudeConversion = (double.TryParse(pieces[4], out longitudeConversion) ? longitudeConversion : 0) / 100;
				Longitude = (pieces[5] == "W") ? (longitudeConversion *= -1) : longitudeConversion;

				//piece 6 = fix quality
				FixQuality = Double.Parse(pieces[6]);

				//piece 7 = satellite count
				SatelliteCount = Double.Parse(pieces[7]);

				//piece 8 = horizontal dilution of precision
				HDOP = Double.Parse(pieces[8]);

				//piece 9 = altitude, piece 10 = measurement type
				Altitude = Double.Parse(pieces[9]);

				//piece 11 = height of geiod above WGS84 ellipsoid, piece 12 = measurement type
				HeightOfGeoid = Double.Parse(pieces[11]);

				//piece 13 = blank

				//piece 14 = checksum
				Checksum = pieces[14];

				//Check validity of records.
				if ((DateTime.UtcNow - UTCTime < TimeTolerance &&
					Math.Abs(Latitude - UserLatitude) < PositionTolerance &&
					Math.Abs(Longitude - UserLongitude) < PositionTolerance &&
					FixQuality > 0 &&
					SatelliteCount > 4))
				{
					TestValid = true;
				}
			}
			else
			{
				TestValid = false;
			}

		}

		/// <summary>
		/// Reset the board input's determined properties each time 
		/// a message received fails validation.
		/// Might not belong in the object's data class?
		/// </summary>
		public void ResetBoardRecord()
		{
			//Reset all GPS board dependent properties. 
			UTCTime = DateTime.MinValue;
			Latitude = 0;
			Longitude = 0;
			FixQuality = 0;
			SatelliteCount = 0;
			HDOP = 0;
			Altitude = 0;
			HeightOfGeoid = 0;
			Checksum = "0";
		}
	}

	public class GPSRecordMap : ClassMap<GPSDataRecord>
	{
		/// <summary>
		/// A map for .csvHelper. Determines the properties to input 
		/// into the .csv file, their order, and the column header 
		/// for each data type.
		/// I am not sure if it should be in its own file?
		/// </summary>
		public GPSRecordMap()
		{
			//Automap any properties that might be missed
			AutoMap(CultureInfo.InvariantCulture);

			//Properties to ignore.
			Map(r => r.ComPortLocation).Ignore();
			Map(r => r.IsPanel).Ignore();

			//Order of .csv file output.

			//Quick glance data first. Board identification and pass/fail
			Map(r => r.BoardSerialNumber).Name("Board Serial Number");
			Map(m => m.TestValid).Name("Test Passed?");

			//User/Form Information
			Map(r => r.UserName).Name("User");
			Map(r => r.UserLatitude).Name("User Latitude");
			Map(r => r.UserLongitude).Name("User Longitude");
			Map(r => r.TestDuration).Name("Test Duration");
			Map(r => r.TestTimeout).Name("Test Timeout");

			//Board Identification/Information
			Map(r => r.PanelLocation).Name("Board Location"); //See info doc in .csv export folder
			Map(r => r.UTCTime).Name("UTC Time");
			Map(r => r.Latitude).Name("Board Latitude");
			Map(r => r.Longitude).Name("Board Longitude");
			Map(r => r.FixQuality).Name("Fix Quality");
			Map(r => r.SatelliteCount).Name("Satellite Count");
			Map(r => r.HDOP).Name("HDOP");
			Map(r => r.Altitude).Name("Alitude");
			Map(r => r.HeightOfGeoid).Name("Height Of Geoid");
			Map(r => r.Checksum).Name("GPS Message Checksum");

			//Testing Information
			Map(r => r.PositionTolerance).Name("PositionTolerance");
			Map(r => r.TimeTolerance).Name("Time Tolerance");
		}
	}
}
