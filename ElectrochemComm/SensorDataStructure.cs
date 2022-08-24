using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sensit.TestSDK.Devices;
using System.Diagnostics;

namespace Sensit.App.Aardvark
{
    /******************/
    //NOT FUNCTIONING (or implemented at all)
    /*****************/
    internal class SensorDataStructure : SensorDataLibrary
    {
        #region Input Data
        /*Order to run data input in
         * 1. Pull Read data using everett's code.
         * 2. Pull out Serial Number (bytes ?208-239?)
         * 3. Confirm byte serial matches user inputted serial
         * 4. Pull Sensor type (byte 1)
         * 5. Send sensor type's class to Parsing along with everett's read data
         */
        internal List<byte> readEepromData = new();
        internal void InputAardvarkRead() {
            //Create an instance of AarvarkI2C
            AardvarkI2C aardvarkI2C = new AardvarkI2C();

            //Get READ data from instance of AardvarkI2C (address, location)
            readEepromData = new(aardvarkI2C.EepromRead(cat24AddNum, cat24AddLen));
        }

        internal void InputDataConfirmation()
        {
            //pull serial number out of bytes (208 - 239)?
            List<byte> serialNumberRead = readEepromData.GetRange(336, 32);

            //remove zero values in serial number list (this is done because I cannot remove null values)
            serialNumberRead.RemoveAll(data => data == 0);
        }
        #endregion

        #region Parse Data
        /*Order for things to parse in
         * 0. Receive data sent from Input region (List<byte> eepromDataRead, sensor's type class)
         * 1. Pull Base Record Data (from the type's class) (bytes 0 - 191 in eepromDataRead)
         * 2. Verify data. (make sure byte numbers match peter's defines & checksum matches)
         * 3. Pull Device ID. (bytes 192 - 256 in eepromDataRead)
         * 4. Verify Data. (make sure byte numbers match peter's defines)
         * 5. Pull Manufacturing Record (bytes 257 - 321 in eepromDataRead)
         * 6. Verify Data. (make sure byte numbers match peter's defines)
         */
        #endregion

        #region Output Data
        //Convert all parsed data into bytes (if needed). Then output back into everett's code 
        #endregion
    }
}
