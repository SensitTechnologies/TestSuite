using System.Globalization;
using CsvHelper.Configuration;

namespace Sensit.App.GPS
{
	public class GPSDataRecord
	{
		//COM port being used
		public string? ComPortLocation { get; set; }

		//Is this board part of a panel?
		public bool IsPanel { get; set; }
		public string PanelLocation { get; set; } = "";

		//Form data to record
		public double UserLatitude { get; set; }
		public double UserLongitude { get; set; }
		public int TestTimeout { get; set; }
		public string UserName { get; set; } = "";
		public string TestDuration { get; set; } = "";

		//Validity of message received
		public bool IsValid { get; set; }

		//Properties of GPS board
		public string BoardSerialNumber { get; set; } = "empty";
		public DateTime UTCTime { get; set; } = DateTime.MinValue;
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public double FixQuality { get; set; }
		public double SatelliteCount { get; set; }
		public double HDOP { get; set; } //Horizontal Dilution of Precision
		public double Altitude { get; set; }
		public double HeightOfGeoid { get; set; } //Height of geoid above WGS84 ellipsoid
		public string Checksum { get; set; } = "empty";

		//Tolerances 
		public double PositionTolerance { get; set; }
		public TimeSpan TimeTolerance { get; set; }


		//Set data to class
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
					IsValid = true;
				}
			}
			else
			{
				IsValid = false;
			}

		}

		public void ResetBoardRecord()
		{
			//GPS message invalid. clear only board data before trying again.
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
		public GPSRecordMap()
		{
			AutoMap(CultureInfo.InvariantCulture);

			
			//Properties to ignore.
			Map(r => r.ComPortLocation).Ignore();

			//Put in properties to map along with their column name
			//	Map(r => r._).Name(" ");
			Map(r => r.BoardSerialNumber).Name("Board_Serial_Number");
			Map(r => r.IsPanel).Name("In_A_Panel");
			Map(r => r.PanelLocation).Name("Panel_Location");
			Map(r => r.UserName).Name("User_Name");
			Map(r => r.UserLatitude).Name("User_Latitude");
			Map(r => r.UserLongitude).Name("User_Longitude");
			Map(r => r.TestTimeout).Name("Test_Timeout");
			Map(r => r.TestDuration).Name("Test_Duration");
			Map(r => r.PositionTolerance).Name("Position_Tolerance");
			Map(r => r.TimeTolerance).Name("Time_Tolerance");
			Map(r => r.UTCTime).Name("UTC_Time");
			Map(r => r.Latitude).Name("Latitude");
			Map(r => r.Longitude).Name("Longitude");
			Map(r => r.FixQuality).Name("Fix_Quality");
			Map(r => r.SatelliteCount).Name("Satellite_Count");
			Map(r => r.HDOP).Name("HDOP");
			Map(r => r.Altitude).Name("Alitude");
			Map(r => r.HeightOfGeoid).Name("Height_Of_Geoid");
			Map(r => r.Checksum).Name("Checksum");
		}
	}
}
