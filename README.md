# Sensit Technologies C# Test Suite & SDK
This is a software suite for automating instrumentation and sensor tests and calibration.  Core features are still in development, so check back daily.

## To Do
### High Priority
* **Agilent Datalogger**
  * VISA.IVI driver
  * SCPI Command Class
* **FormCalibration**
  * Tab control for each DUT.
  * Data view (Excel or data view grid) in each DUT tab
* **Datalogging** via Excel or CSV, whichever is easier to implement
* Test settings via serializable class
* **DUT** control via Agilent datalogger.

### Medium Priority
* **Temperature Control**
  * MODBUS protocol
  * Love Controller
* FormCalibration Features
  * Create/update/destroy controls for controlled variables on Status tab.
  * Create/read/destroy test equipment controls on Overview tab.
  * Update independent variable control parameters.
* Create form (accessible via FormCalibration menu) to edit Model, Range, Test settings.

## Development Environment
* [Visual Studio 2017](https://visualstudio.microsoft.com) or later - Community edition is free.
* Microsoft .NET Framework 4.7.2 - If Visual Studio is already installed but the correct framework is not, run the Visual Studio Installer, navigate to *Individual Components* and select the appropriate framework.
* [Keysight IO Libraries Suite](https://www.keysight.com/en/pd-1985909/io-libraries-suite) - VISA drivers necessary to communicate with Keysight/Agilent instruments.  You could also use the National Instruments VISA drivers.

## Code Standards
Attention was given to making this software suite as easy to read and modify as
possible, and one part of that is making sure to follow community best practices
as much as possible.  The following links describe best practices that should be
considered by contributors to this project:
* [Microsoft - C# Coding Conventions (C# Programming Guide)](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions)
* [Code Project - Some Best Practices for C# Application Development (Explained)](https://www.codeproject.com/Articles/118853/%2FArticles%2F118853%2FSome-Best-Practices-for-C-Application-Developmen)
* [C# Corner - Best Practices Of Writing C# Code](https://www.c-sharpcorner.com/article/best-practice-of-write-c-sharp-code/)
* [dotnetspider - C# Coding Standards and Best Programming Practices](http://businessinteriorsidaho.com/wp-content/uploads/2016/09/DotNetCodingStandard.pdf)
