# Sensit Technologies Test Suite
[![Board Status](https://dev.azure.com/sensittechnologies/1e996872-9b0d-441e-88e1-78124cb6ccbf/c2ca1a45-950b-40d7-bd83-b8d3d220ae6f/_apis/work/boardbadge/6e32bfb0-03fb-4a80-94b9-bc168eddd5a9?columnOptions=1)](https://dev.azure.com/sensittechnologies/1e996872-9b0d-441e-88e1-78124cb6ccbf/_boards/board/t/c2ca1a45-950b-40d7-bd83-b8d3d220ae6f/Microsoft.RequirementCategory/)

This is a software suite for automating testing and calibration of sensors or instrumentation.  It provides a series of .NET desktop apps that control various types of test equipment and Devices Under Test (DUTs) to automatically gather and record data.

## Installation
Click-once installers for the apps are available for download here:  (Note that the applications have not been published since the migration to .NET 6.0, so they still require .NET Framework 4.8.)
* [Automated Test App](https://clickonceapp.blob.core.windows.net/clickonce-app-container/calibration/publish.htm)
* [Datalogger App](https://clickonceapp.blob.core.windows.net/clickonce-app-container/Sensit.App.Log/Publish.html)
* [Gas Concentration App](https://clickonceapp.blob.core.windows.net/clickonce-app-container/gasconcentration/publish.htm)
* [Mass Flow Controller App](https://clickonceapp.blob.core.windows.net/clickonce-app-container/massflow/publish.htm)
* Power Supply App (oops...not hosted online yet)

## Usage
For detailed information about using the apps in the software suite, see the [project's wiki](https://github.com/SensitTechnologies/TestSuite/wiki).  In a nutshell:
* Use the **Automated Test App** and the **Datalogger App** to run tests and collect data while you do more interesting things.  These apps were originally designed to help with gas testing (but you can use them for whatever you want).  The documentation folder has example configuration files for gas tests, as well as an Excel worksheet that helps calculate variable values.
* Microsoft Excel (or equivalent) can combine the data logs from both apps.
* Control equipment manually with the **Gas Concentration App**, **Mass Flow Controller App**, and **Power Supply App**.

## Building and Publishing from Source
The apps are written in C# with .NET 6.0 and use WinForms, so they work in a Microsoft Windows environment, but can also run on Linux if .NET is installed.
* [Microsoft Visual Studio](https://visualstudio.microsoft.com) (Community edition is free for open source projects!)
* Microsoft .NET 6.0 - If Visual Studio is already installed but the correct .NET version is not, run the _Visual Studio Installer_, navigate to _Individual Components_ and select the appropriate framework to install.  Or feel free to upgrade to the latest framework, then submit a pull request.

After building, [publish the solution](https://docs.microsoft.com/en-us/dotnet/core/tutorials/publishing-with-visual-studio) to create an installer.  After running the installer, each program in the suite will be available from the Windows Start menu.  You can also publish the installer to a web location such as an Azure storage blob container (which is how the web installers linked above work).

## Contributing
Feel free to contribute, but first read the [Contributing Guidelines](https://github.com/SensitTechnologies/TestSuite/blob/master/CONTRIBUTING.md) to see how we do things.
