# Sensit Technologies Test Suite
This is a software suite for automating testing and calibration of sensors or instrumentation.  It provides (1) integration with various types of test equipment and Devices Under Test (DUTs), (2) automatic gathering and recording of data, and (in future versions) basic calibration and data analysis.

The Calibration App is a desktop app which automates testing of sensors using mass flow meters.  It has the following abilities:
* Use one or more Cole-Parmer Mass Flow Controllers to control gas flow.
* Gather sensor data from one or more serial ports.
* Log test results in a CSV file for further analysis.

## Installation
The first full release is not yet available, so installation requires building from source.  See the [Requirements](https://github.com/SensitTechnologies/TestSuite/wiki/Requirements) page on the project wiki for more information, but at minimum you need:
* [Microsoft Visual Studio](https://visualstudio.microsoft.com) with Microsoft .NET Framework 4.8.

After building, [publish the solution](https://docs.microsoft.com/en-us/dotnet/core/tutorials/publishing-with-visual-studio) to create an installer.  After running the installer, each program in the suite will be available from the Windows Start menu.

## Usage
To use the Calibration app (Sensit.App.Calibration), you'll need to have two of the following equipment (until the Simulator is supported):
* [Cole-Parmer Mass Flow Controller for Gas](https://www.coleparmer.com/p/cole-parmer-mass-flow-controllers-for-gas/43456)

Select the Model and Range of your sensor under test.  Select how many devices to test.  Click "Start", then wait for the test to complete.

For detailed information about using the other apps in the software suite, see the [project's wiki](https://github.com/SensitTechnologies/TestSuite/wiki).

## Contributing
Feel free to contribute, but first read the [Contributing Guidelines](https://github.com/SensitTechnologies/TestSuite/blob/master/CONTRIBUTING.md) to see how we do things.
