using Sensit.App.Programmer;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Sensit.App.Programmer
{
    /******************/
    //NOT FUNCTIONING (or implemented at all)
    /*****************/
    internal class SensorDataLibrary
    {
        //Sensor Type Library. Determines sensor type so program can go to the correct class.
        private readonly Dictionary<int, string> sensorTypeCode;
        internal SensorDataLibrary()
        {
            //Populate sensorTypeCode
            sensorTypeCode = new()
             {
                {0x01, "GAS_O2" },
                {0x02, "GAS_02Pb"},
                {0x03, "GAS_CO" },
                {0x04, "GAS_H2S" },
                {0x05, "GAS_HCN" },
                {0x06, "GAS_SO2" },
                {0x07, "GAS_CL2" },
                {0x08, "GAS_NO2" },
                {0x09, "GAS_PH3" },
                {0x0A, "GAS_ETO" },
                {0x0B, "GAS_CO2" },
                {0x0C, "GAS_CH4" },
                {0x0D, "GAS_PROP" },
                {0x0E, "GAS_CH4_2611" },  //is this the LEL? if so, I don't think I need it
                {0x0F, "GAS_CH4_IR" },  //this one doesn't seem like a sensor either
                {0x10, "GAS_DUAL_CO_H2S" }
             };
        }
        public string sensorName;
        internal void SensorLibraryInput(int sensorKey)
        {
            sensorName = sensorTypeCode[sensorKey];
        }
    }
    internal abstract class BaseRecord : SensorDataLibrary
    {
        //input shared variables from linear/polynomial here. use derived classes (methods?) Legacy and Polynomial 
        //for not shared values
        //I think it is possible to make this cleaner by putting it into a dictionary. However, until I
        //get the code running properly, I'm going to leave it how it is.
        //pages 1-3 on EEPROM. so bytes 0 - 192?
        public int Validity { get; set; }
        public int SensorType { get; set; }
        public int SensorRev { get; set; }
        public int RecordFormat { get; set; } //Determines Legacy/Polynomial
        public int CalScale { get; set; }
        public int CalGasOne { get; set; }
        public int CalPointOne { get; set; }
        public int CalMaxOne { get; set; }
        public int CalMinOne { get; set; }
        public int CalGasTwo { get; set; }
        //table deviates here for Legacy vs. Polynomial. they reconvene at the end of the tables
        public int UnusedTwo { get; set; }
        public int AutoZero { get; set; }
        public int ZeroMax { get; set; }
        public int ZeroMin { get; set; }
        public int CheckSum { get; set; }
    }
    internal abstract class Legacy : BaseRecord
    {
        public int CalPointTwo { get; set; }
        public int CalMaxTwo { get; set; }
        public int CalMinTwo { get; set; }
        public int CalGasThree { get; set; }
        public int UnusedOne { get; set; }

    }
    internal abstract class Polynomial : BaseRecord
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int D { get; set; }
        public int Offset { get; set; }
        public int CalDate { get; set; }
    }


    internal abstract class DeviceID : SensorDataLibrary
    {
        //page 4 on the EEPROM. so 193 - 256?
        public int Validity { get; set; }
        public int Class { get; set; }
        public int ID { get; set; }
        public int RecordFormat { get; set; }
        public int DateCode { get; set; }
        public int SSDate { get; set; }
        public int SerialNumber { get; set; }
        public int MaxExposure { get; set; }
        public int MaxRange { get; set; }
        public int MinRange { get; set; }
        public int Issue { get; set; }
        public int Revision { get; set; }
        public int PointRelease { get; set; }
        public int Checksum { get; set; }
    }

    internal abstract class ManufactureID : SensorDataLibrary
    {
        //page 5 on the EEPROM. so 257 - 321?
        public int Validity { get; set; }
        public int Class { get; set; }
        public int ID { get; set; }
        public int Unused { get; set; }
        public int Issue { get; set; }
        public int Revision { get; set; }
        public int PointRelease { get; set; }
    }
}
