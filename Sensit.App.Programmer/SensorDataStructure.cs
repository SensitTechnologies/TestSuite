using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace Sensit.App.Programmer
{
    /******************/
    //NOT FUNCTIONING (or implemented at all)
    /*****************/
    internal class SensorDataStructure : SensorDataLibrary
    {
        #region Class Variables
        //Form Programmer reference
        public Sensit.App.Programmer.FormProgrammer formProgrammer;
        #endregion

        #region Input Data
        /* currently a call method using a serial number to manipulate data until
         * desired result is achieved.*/

        public string serialNumber = "";
        public void InputDataFromAardvark()
        {
            byte[] inputData = aardvarkControllerRead.readBytes; //*broken until I pull code. also not efficient
            serialNumber = Encoding.ASCII.GetString(inputData);
        }
        public void InputManager()
        {
            //Currently manages running the data engine when called by the form programmer
            InputDataFromAardvark();
            if (serialNumber != "" && !serialNumber.All(char.IsDigit)) //could probably just switch the if and else if statements around
            {
                int sensorValue = (int)GetSensorIDValue();
                SensorLibraryInput(sensorValue);
                //use sensor name to determine class/dictionary to use and call here 

                //use a sensor to copy all EEPROM INFO into a debug
                OutputManager();
            }
            //make sure there are only numbers in serial number
            else if (!serialNumber.All(char.IsDigit))
            {
                throw new Exception("Serial number contains invalid characters. Please try again.");
            }
            else
            {
                throw new Exception("Serial number is invalid. Please try again.");
            }
        }
        #endregion

        #region Parse Data
        /* This region overall will be used to take converted byte data and manipulate it
         * into useable information. */

        public int serialLength;
        /// <summary>
        /// Method to input serial number and output desired info.
        /// </summary>
        /// <param name="serialNumber"></param>
        public void SensorData(string serialNumber)
        {
            serialLength = serialNumber.Length;
        }
        //Batch number of the sensor
        public int sensorBatch;
        //Number of sensors in batch
        public int sensorNum;
        /// <summary>
        /// Parse the serial number to return sensor value for sensorTypeCode. 
        /// "Parse the serial number.  It follows format 'TTTBBBBNN'
        ///  TTT = Sensor type (this could be only two digits if the first number is 0).
        ///  BBBB = Batch Number
        ///  NN = Number in Batch"
        ///  NEXT STEP: try and simplify the existing GetSensorIDValue() method.
        /// </summary>
        /// <param name="serialLength"></param>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private uint GetSensorIDValue()
        {
            uint value;

            if (serialLength == 10)
            {
                value = uint.Parse(serialNumber[..4]);
                sensorBatch = int.Parse(serialNumber.Substring(4, 4));
                sensorNum = int.Parse(serialNumber.Substring(8, 2));
                return value;
            }
            else if (serialLength == 9)
            {
                value = uint.Parse(serialNumber[..3]);
                sensorBatch = int.Parse(serialNumber.Substring(3, 4));
                sensorNum = int.Parse(serialNumber.Substring(7, 2));
                return value;
            }
            else if (serialLength == 8)
            {
                value = uint.Parse(serialNumber[..2]);
                sensorBatch = int.Parse(serialNumber.Substring(6, 2));
                sensorNum = int.Parse(serialNumber.Substring(6, 2));
                return value;
            }
            else
            {
                throw new Exception("Invalid serial number format");
            }
        }
        #endregion

        #region Output Data
        /*this region will be in charge of taking all necessary converted/manipulated data
         * and outputting it back to the AarvarkController_Skeleton.Write.AardvarkWriteData() method.
         * It will also be where methods used to output data to the FormProgrammer will be stored.
         */

        public void OutputManager()
        {
            //update: until i make further progress, needed info here will output to debug to test
            //sensorName(type)
            Debug.Print(sensorName);
            //validity. if i did hexadecimals right, valid is 0xAA (170) and erased is 0xFF (255)

            //revision number

            //Convert needed info to bytes. don't know what info is needed
            //Output bytes back to everett's code
            OutputDataToAardvark();
        }

        public void OutputDataToAardvark()
        {
            //don't know what needs to go here until afer i talk with peter.
        }


        #endregion
    }
}
