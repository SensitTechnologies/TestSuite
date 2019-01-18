# Sensit Technologies Test Suite
This is a software suite for automating testing and calibration of sensors or
instrumentation.  It provides (1) integration with various types of test
equipment and Devices Under Test (DUTs), (2) automatic gathering and recording of
data, and (3) basic calibration and data analysis.

## Requirements
The first iteration of the project will be a desktop app which automates testing
of analog sensors using a datalogger and mass flow meter.  The deliverable will
have the following abilities:
* Use a Cole-Parmer Mass Flow Controller to control gas flow.
* Gather sensor data from a Keysight datalogger.
* Log test results in a csv or Excel file for further analysis.
* The second iteration of the project will add a Dwyer Temperature Controller to control gas temperature.

## Development Plan
The software suite is organized into several projects:
* A Software Development Kit (SDK) which contains utilities for each of the
 deliverables and can be reused in future applications.
* A Calibration app which utilizes the SDK to perform automated tests.
* Utility apps for standalone operation/testing of automated equipment.
* A collection of unit-tests for the SDK to aid development and maintenance.

This project's core features are in active development.  After the initial
application is delivered, support for more general testing/calibration, and
more types of test equipment will be added to the SDK as needed.  As automation
tools are added to the SDK, those tools may also be used to streamline
production of manufactured products.

The project is organized to facilitate rapid testing of the project itself.
* Whenever possible, each class is to have its own unit test.
* Each piece of automated test equipment is to have its own GUI project which
  can test its performance.
* Within the calibration app, a "simulator" can be chosen as the device under
  test, and any controlled or independent variable, rather than being gathered
  from a physical piece of equipment, can be provided by setting a "manual" test
  equipment option.  This allows any test to be run with any combination of
  virtual or real equipment and data.

## Features (and Status)
Features necessary for the first iteration are highlighted in bold.
* Interface to a variety of test equipment.
  * [x] Prompt an operator for manual control.
  * [x] **Cole-Parmer Mass Flow Controller**
  * [ ] **Keysight datalogger**
  * [ ] Dwyer 16B Temperature Controller
* Interface to a variety of devices under test.
  * [x] Device Under Test Simulator
  * [ ] **Analog sensor**
* Support a variety of communication protocols.
  * [x] **VISA.IVI**
  * [x] **SCPI**
  * [x] **Serial port**
  * [ ] MODBUS
* Provide a Graphic User Interface.
  * [x] **Present an *overview* where user can set options, run tests, see DUT status**
  * [ ] View *status* while testing, showing controlled and independent variables from test equipment
  * [ ] View data gathered from each *DUT* (via embedded Excel or simple data grid)
* Record test data for further analysis.
  * [ ] **CSV**
  * [ ] Excel
  * [ ] SQL or Mongo Database
* Provide a calculation library to generate test results.
  * [x] Convert units of measure.
  * [ ] Linearize calibration data.
* Store settings in serializable classes.
  * [x] System settings
  * [ ] DUT information (model, range, available tests).
  * [ ] Test information (variables, setpoints).
  * [ ] Provide a GUI to edit settings.

## Development Environment
* [Visual Studio 2017](https://visualstudio.microsoft.com) or later (Community
  edition is free for open source projects!)
* Microsoft .NET Framework 4.7.2 - If Visual Studio is already installed but the
  correct framework is not, run the Visual Studio Installer, navigate to
  *Individual Components* and select the appropriate framework.
* [Keysight IO Libraries Suite](https://www.keysight.com/en/pd-1985909/io-libraries-suite)
  - VISA drivers necessary to communicate with Keysight/Agilent instruments.
  You could also use the National Instruments VISA drivers.
* [Keysight Command Expert](https://www.keysight.com/en/pd-2036130/command-expert)
  - used to install necessary Agilent dll.  See included help file for
  instructions to install dependencies for specific instruments.

## Code Standards
Attention was given to making this software suite as easy to read and modify as
possible, and one part of that is making sure to follow community best practices
as much as possible.  The following links describe best practices that should be
considered by contributors to this project:
* [Microsoft - C# Coding Conventions (C# Programming Guide)](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions)
* [Code Project - Some Best Practices for C# Application Development (Explained)](https://www.codeproject.com/Articles/118853/%2FArticles%2F118853%2FSome-Best-Practices-for-C-Application-Developmen)
* [C# Corner - Best Practices Of Writing C# Code](https://www.c-sharpcorner.com/article/best-practice-of-write-c-sharp-code/)
* [dotnetspider - C# Coding Standards and Best Programming Practices](http://businessinteriorsidaho.com/wp-content/uploads/2016/09/DotNetCodingStandard.pdf)
