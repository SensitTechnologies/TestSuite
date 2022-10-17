using System.Globalization;

namespace Sensit.App.GPS
{
	internal class GPSDataRecords
	{
		//TODO: program the gps data panel class. make grid, properties,
		//setting to the records, and create the csv output method here probably

		//COM port being used
		//Doesn't need saved to .csv but it needs to be specific
		//for each board instance
		internal string? ComPortLocation { get; set; }

		//Is this board part of a panel?
		internal bool IsPanel { get; set; }
		internal string PanelLocation { get; set; } = "";

		//Form data to record
		internal double UserLatitude { get; set; }
		internal double UserLongitude { get; set; }
		internal decimal TestTimeout { get; set; }
		internal string UserName { get; set; } = "";
		internal string TestDuration { get; set; } = "";

		//Validity of message received
		internal bool IsValid { get; set; }

		//Properties of GPS board
		internal string? BoardSerialNumber { get; set; }
		internal DateTime? UTCTime { get; set; }
		internal double Latitude { get; set; }
		internal double Longitude { get; set; }
		internal double FixQuality { get; set; }
		internal double SatelliteCount { get; set; }
		internal double HDOP { get; set; } //Horizontal Dilution of Precision
		internal double Altitude { get; set; }
		internal double HeightOfGeoid { get; set; } //Height of geoid above WGS84 ellipsoid
		internal string? Checksum { get; set; }

		//Tolerances 
		internal double PositionTolerance { get; set; }
		internal TimeSpan TimeTolerance { get; set; }

		//Set data to class
		internal void SetRecords(string message)
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

		//Get data from class
		internal List<string> GetRecords()
		{
			List<string> records = new();



			return records;
		}

		internal void ResetBoardRecord()
		{
			//GPS message invalid. clear only board data before trying again.
			UTCTime = null;
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
}
