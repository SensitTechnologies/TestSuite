# Sensit Technologies Test Suite
This is a software suite for automating testing and calibration of sensors or instrumentation.  It provides a series of .NET desktop apps that control various types of test equipment and Devices Under Test (DUTs) to automatically gather and record data.

## Installation
Click-once installers for the apps are available for download here:
* [Automated Test App](https://clickonceapp.blob.core.windows.net/clickonce-app-container/calibration/publish.htm)
* [Datalogger App](https://clickonceapp.blob.core.windows.net/clickonce-app-container/log/publish.htm)
* [Gas Concentration App](https://clickonceapp.blob.core.windows.net/clickonce-app-container/gasconcentration/publish.htm)
* [Mass Flow Controller App](https://clickonceapp.blob.core.windows.net/clickonce-app-container/massflow/publish.htm)

## Building and Publishing from Source
See the [Requirements](https://github.com/SensitTechnologies/TestSuite/wiki/Requirements) page on the project wiki for more information, but at minimum you need:
* [Microsoft Visual Studio](https://visualstudio.microsoft.com) with Microsoft .NET Framework 4.8.

After building, [publish the solution](https://docs.microsoft.com/en-us/dotnet/core/tutorials/publishing-with-visual-studio) to create an installer.  After running the installer, each program in the suite will be available from the Windows Start menu.  You can also publish the installer to a web location such as an Azure storage blob container (which is how the web installers linked above work).

## Usage
For detailed information about using the apps in the software suite, see the [project's wiki](https://github.com/SensitTechnologies/TestSuite/wiki).

## Contributing
Feel free to contribute, but first read the [Contributing Guidelines](https://github.com/SensitTechnologies/TestSuite/blob/master/CONTRIBUTING.md) to see how we do things.
