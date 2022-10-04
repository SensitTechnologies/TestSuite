using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensit.App.GPS
{
	internal class GPSDataRecords
	{
		//TODO: program the gps data panel class. make grid, properties,
		//setting to the records, and create the csv output method here probably

		//Form data to record
		internal string SerialPort { get; set; } = "";
		internal int TestTimeout { get; set; }
		internal string UserName { get; set; } = "";
		internal string TestDuration { get; set; } = "";


		//Properties of GPS board
		internal string BoardSerialNumber { get; set; } = "";
		internal DateTime UTCTime { get; set; }
		internal double Latitude { get; set; }
		internal double Longitude { get; set; }
		internal double FixQuality { get; set; }
		internal double SatelliteCount { get; set; }
		internal double HDOP { get; set; } //Horizontal Dilution of Precision
		internal double Altitude { get; set; }
		internal double HeightOfGeoid { get; set; } //Height of geoid above WGS84 ellipsoid
		internal double Checksum { get; set; }

		//Abstract set data to class
		internal void SetRecords(string gpsMessage)
		{
			
		}

		//Abstract get data from class
		internal List<string> GetRecords()
		{
			List<string> records = new();



			return records;
		}
	}

}
