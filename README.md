# Sensit Technologies Test Suite
This is a software suite for automating testing and calibration of sensors or instrumentation.  It provides (1) integration with various types of test equipment and Devices Under Test (DUTs), (2) automatic gathering and recording of data, and (3) basic calibration and data analysis.

The first iteration of the project will be a desktop app which automates testing of analog sensors using a datalogger and mass flow meter.  The deliverable will have the following abilities:
* Use a Cole-Parmer Mass Flow Controller to control gas flow.
* Gather sensor data from a Keysight datalogger.
* Log test results in a csv or Excel file for further analysis.
* The second iteration of the project will add a Dwyer Temperature Controller to control gas temperature.

## Installation
The first full release is not yet available, so installation requires building from source.  See the Requirements page on the project wiki for more information, but at minimum you need:
* [Visual Studio 2017](https://visualstudio.microsoft.com) or later with Microsoft .NET Framework 4.7.2.
* [Keysight IO Libraries Suite](https://www.keysight.com/en/pd-1985909/io-libraries-suite)
* [Keysight Command Expert](https://www.keysight.com/en/pd-2036130/command-expert)
After building, [publish the solution](https://docs.microsoft.com/en-us/dotnet/core/tutorials/publishing-with-visual-studio) to create an installer.  Run the installer.  Then you'll see

## Usage
To use the Calibration app (Sensit.App.Calibration), you'll need to have the following equipment (until the Simulator is supported):
* [Keysight 34972A Datalogger](https://www.keysight.com/en/pd-1756491-pn-34972A/lxi-data-acquisition-data-logger-switch-unit)
* [Cole-Parmer Mass Flow Controller for Gas](https://www.coleparmer.com/p/cole-parmer-mass-flow-controllers-for-gas/43456)

Select the Model and Range of your sensor under test.  Select how many sensors to test.  Click "Start", then wait for the test to complete.

## Contributing
Attention was given to making this software suite as easy to read and modify as possible, and one part of that is making sure to follow community best practices as much as possible.  The following links describe best practices that should be considered by contributors to this project:
* [Microsoft - C# Coding Conventions (C# Programming Guide)](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions)
* [Microsoft - Framework Design Guidelines](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/)
