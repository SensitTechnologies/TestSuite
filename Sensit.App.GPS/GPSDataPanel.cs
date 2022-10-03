using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensit.App.GPS
{
	internal abstract class GPSDataRecords
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
		internal string UTCTime { get; set; } = "";
		internal int Latitude { get; set; }
		internal int Longitude { get; set; }
		internal int FixQuality { get; set; }
		internal int SatelliteCount { get; set; }
		internal int HDOP { get; set; } //Horizontal Dilution of Precision
		internal int Altitude { get; set; }
		internal int HeightOfGeoid { get; set; } //Height of geoid above WGS84 ellipsoid
		internal int Checksum { get; set; }

		//Abstract set data to class
		internal abstract List<object> SetRecords();

		//Abstract get data from class
		internal abstract List<object> GetRecords();
	}

	internal class PanelRecords : GPSDataRecords
	{
		//Panel-specific properties
		internal int PanelSerialNumber { get; set; }

		//TODO: might not need so leave separated a little
		//Board locations in panel for data grid
		internal int P1 { get; set; } //(1, 1)
		internal int P2 { get; set; } //(1, 2)
		internal int P3 { get; set; } //(1, 3)
		internal int P4 { get; set; } //(1, 4)
		internal int P5 { get; set; } //(1, 5)
		internal int P6 { get; set; } //(2, 1)
		internal int P7 { get; set; } //(2, 2)
		internal int P8 { get; set; } //(2, 3)
		internal int P9 { get; set; } //(2, 4)
		internal int P10 { get; set; } //(2, 5)
		internal int P11 { get; set; } //(3, 1)
		internal int P12 { get; set; } //(3, 2)
		internal int P13 { get; set; } //(3, 3)
		internal int P14 { get; set; } //(3, 4)
		internal int P15 { get; set; } //(3, 5)
		internal int P16 { get; set; } //(4, 1)
		internal int P17 { get; set; } //(4, 2)
		internal int P18 { get; set; } //(4, 3)
		internal int P19 { get; set; } //(4, 4)
		internal int P20 { get; set; } //(4, 5)

		//Set data to class
		internal override List<object> SetRecords()
		{
			throw new NotImplementedException();
		}
		//Get data from class
		internal override List<object> GetRecords()
		{
			throw new NotImplementedException();
		}

	}

	internal class SingleBoardRecords : GPSDataRecords
	{
		//No special properties


		//Set data to class
		internal override List<object> SetRecords()
		{
			throw new NotImplementedException();
		}
		//Get data from class
		internal override List<object> GetRecords()
		{
			throw new NotImplementedException();
		}
	}

}
