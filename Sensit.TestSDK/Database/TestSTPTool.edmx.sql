
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/27/2018 15:08:31
-- Generated from EDMX file: C:\Users\mclemens\SVN-Projects\STP-Tool\trunk\TestSDK\Database\TestSTPTool.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TestPlanDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_TestCaseTestStep]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TestSteps] DROP CONSTRAINT [FK_TestCaseTestStep];
GO
IF OBJECT_ID(N'[dbo].[FK_TestStepTestStepResult]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TestSteps] DROP CONSTRAINT [FK_TestStepTestStepResult];
GO
IF OBJECT_ID(N'[dbo].[FK_TestCaseTestRun]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TestRuns] DROP CONSTRAINT [FK_TestCaseTestRun];
GO
IF OBJECT_ID(N'[dbo].[FK_TestRunTestStepResult]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TestStepResults] DROP CONSTRAINT [FK_TestRunTestStepResult];
GO
IF OBJECT_ID(N'[dbo].[FK_TestRunEnvironment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TestRuns] DROP CONSTRAINT [FK_TestRunEnvironment];
GO
IF OBJECT_ID(N'[dbo].[FK_DeviceUnderTestDeviceComponent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DeviceComponents] DROP CONSTRAINT [FK_DeviceUnderTestDeviceComponent];
GO
IF OBJECT_ID(N'[dbo].[FK_TestSuiteTestCase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TestCases] DROP CONSTRAINT [FK_TestSuiteTestCase];
GO
IF OBJECT_ID(N'[dbo].[FK_TestSuiteEquipment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Equipment] DROP CONSTRAINT [FK_TestSuiteEquipment];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[TestCases]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TestCases];
GO
IF OBJECT_ID(N'[dbo].[TestSteps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TestSteps];
GO
IF OBJECT_ID(N'[dbo].[TestStepResults]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TestStepResults];
GO
IF OBJECT_ID(N'[dbo].[TestRuns]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TestRuns];
GO
IF OBJECT_ID(N'[dbo].[TestSuites]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TestSuites];
GO
IF OBJECT_ID(N'[dbo].[DeviceUnderTests]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DeviceUnderTests];
GO
IF OBJECT_ID(N'[dbo].[DeviceComponents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DeviceComponents];
GO
IF OBJECT_ID(N'[dbo].[Equipment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Equipment];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TestCases'
CREATE TABLE [dbo].[TestCases] (
    [TestCaseID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Objective] nvarchar(max)  NULL,
    [Owner] nvarchar(max)  NULL,
    [EstimatedTime] nvarchar(max)  NULL,
    [TestSuiteID] int  NOT NULL
);
GO

-- Creating table 'TestSteps'
CREATE TABLE [dbo].[TestSteps] (
    [TestStepID] int IDENTITY(1,1) NOT NULL,
    [Step] nvarchar(max)  NOT NULL,
    [ExpectedResult] nvarchar(max)  NULL,
    [TestCaseID] int  NOT NULL,
    [TestStepResult_TestStepResultID] int  NOT NULL
);
GO

-- Creating table 'TestStepResults'
CREATE TABLE [dbo].[TestStepResults] (
    [TestStepResultID] int IDENTITY(1,1) NOT NULL,
    [ActualResult] nvarchar(max)  NULL,
    [Status] nvarchar(max)  NULL,
    [TestRunID] int  NOT NULL
);
GO

-- Creating table 'TestRuns'
CREATE TABLE [dbo].[TestRuns] (
    [TestRunID] int IDENTITY(1,1) NOT NULL,
    [Date] nvarchar(max)  NULL,
    [Tester] nvarchar(max)  NULL,
    [TestCaseID] int  NOT NULL,
    [Notes] nvarchar(max)  NULL,
    [Issue] nvarchar(max)  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [Environment_EnvironmentID] int  NOT NULL
);
GO

-- Creating table 'TestSuites'
CREATE TABLE [dbo].[TestSuites] (
    [TestSuiteID] int IDENTITY(1,1) NOT NULL,
    [Product] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DeviceUnderTests'
CREATE TABLE [dbo].[DeviceUnderTests] (
    [EnvironmentID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'DeviceComponents'
CREATE TABLE [dbo].[DeviceComponents] (
    [DeviceUnderTestID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Version] nvarchar(max)  NULL,
    [EnvironmentID] int  NOT NULL
);
GO

-- Creating table 'Equipment'
CREATE TABLE [dbo].[Equipment] (
    [EquipmentID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Quantity] nvarchar(max)  NOT NULL,
    [TestSuiteID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [TestCaseID] in table 'TestCases'
ALTER TABLE [dbo].[TestCases]
ADD CONSTRAINT [PK_TestCases]
    PRIMARY KEY CLUSTERED ([TestCaseID] ASC);
GO

-- Creating primary key on [TestStepID] in table 'TestSteps'
ALTER TABLE [dbo].[TestSteps]
ADD CONSTRAINT [PK_TestSteps]
    PRIMARY KEY CLUSTERED ([TestStepID] ASC);
GO

-- Creating primary key on [TestStepResultID] in table 'TestStepResults'
ALTER TABLE [dbo].[TestStepResults]
ADD CONSTRAINT [PK_TestStepResults]
    PRIMARY KEY CLUSTERED ([TestStepResultID] ASC);
GO

-- Creating primary key on [TestRunID] in table 'TestRuns'
ALTER TABLE [dbo].[TestRuns]
ADD CONSTRAINT [PK_TestRuns]
    PRIMARY KEY CLUSTERED ([TestRunID] ASC);
GO

-- Creating primary key on [TestSuiteID] in table 'TestSuites'
ALTER TABLE [dbo].[TestSuites]
ADD CONSTRAINT [PK_TestSuites]
    PRIMARY KEY CLUSTERED ([TestSuiteID] ASC);
GO

-- Creating primary key on [EnvironmentID] in table 'DeviceUnderTests'
ALTER TABLE [dbo].[DeviceUnderTests]
ADD CONSTRAINT [PK_DeviceUnderTests]
    PRIMARY KEY CLUSTERED ([EnvironmentID] ASC);
GO

-- Creating primary key on [DeviceUnderTestID] in table 'DeviceComponents'
ALTER TABLE [dbo].[DeviceComponents]
ADD CONSTRAINT [PK_DeviceComponents]
    PRIMARY KEY CLUSTERED ([DeviceUnderTestID] ASC);
GO

-- Creating primary key on [EquipmentID] in table 'Equipment'
ALTER TABLE [dbo].[Equipment]
ADD CONSTRAINT [PK_Equipment]
    PRIMARY KEY CLUSTERED ([EquipmentID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TestCaseID] in table 'TestSteps'
ALTER TABLE [dbo].[TestSteps]
ADD CONSTRAINT [FK_TestCaseTestStep]
    FOREIGN KEY ([TestCaseID])
    REFERENCES [dbo].[TestCases]
        ([TestCaseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestCaseTestStep'
CREATE INDEX [IX_FK_TestCaseTestStep]
ON [dbo].[TestSteps]
    ([TestCaseID]);
GO

-- Creating foreign key on [TestStepResult_TestStepResultID] in table 'TestSteps'
ALTER TABLE [dbo].[TestSteps]
ADD CONSTRAINT [FK_TestStepTestStepResult]
    FOREIGN KEY ([TestStepResult_TestStepResultID])
    REFERENCES [dbo].[TestStepResults]
        ([TestStepResultID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestStepTestStepResult'
CREATE INDEX [IX_FK_TestStepTestStepResult]
ON [dbo].[TestSteps]
    ([TestStepResult_TestStepResultID]);
GO

-- Creating foreign key on [TestCaseID] in table 'TestRuns'
ALTER TABLE [dbo].[TestRuns]
ADD CONSTRAINT [FK_TestCaseTestRun]
    FOREIGN KEY ([TestCaseID])
    REFERENCES [dbo].[TestCases]
        ([TestCaseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestCaseTestRun'
CREATE INDEX [IX_FK_TestCaseTestRun]
ON [dbo].[TestRuns]
    ([TestCaseID]);
GO

-- Creating foreign key on [TestRunID] in table 'TestStepResults'
ALTER TABLE [dbo].[TestStepResults]
ADD CONSTRAINT [FK_TestRunTestStepResult]
    FOREIGN KEY ([TestRunID])
    REFERENCES [dbo].[TestRuns]
        ([TestRunID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestRunTestStepResult'
CREATE INDEX [IX_FK_TestRunTestStepResult]
ON [dbo].[TestStepResults]
    ([TestRunID]);
GO

-- Creating foreign key on [Environment_EnvironmentID] in table 'TestRuns'
ALTER TABLE [dbo].[TestRuns]
ADD CONSTRAINT [FK_TestRunEnvironment]
    FOREIGN KEY ([Environment_EnvironmentID])
    REFERENCES [dbo].[DeviceUnderTests]
        ([EnvironmentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestRunEnvironment'
CREATE INDEX [IX_FK_TestRunEnvironment]
ON [dbo].[TestRuns]
    ([Environment_EnvironmentID]);
GO

-- Creating foreign key on [EnvironmentID] in table 'DeviceComponents'
ALTER TABLE [dbo].[DeviceComponents]
ADD CONSTRAINT [FK_DeviceUnderTestDeviceComponent]
    FOREIGN KEY ([EnvironmentID])
    REFERENCES [dbo].[DeviceUnderTests]
        ([EnvironmentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DeviceUnderTestDeviceComponent'
CREATE INDEX [IX_FK_DeviceUnderTestDeviceComponent]
ON [dbo].[DeviceComponents]
    ([EnvironmentID]);
GO

-- Creating foreign key on [TestSuiteID] in table 'TestCases'
ALTER TABLE [dbo].[TestCases]
ADD CONSTRAINT [FK_TestSuiteTestCase]
    FOREIGN KEY ([TestSuiteID])
    REFERENCES [dbo].[TestSuites]
        ([TestSuiteID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestSuiteTestCase'
CREATE INDEX [IX_FK_TestSuiteTestCase]
ON [dbo].[TestCases]
    ([TestSuiteID]);
GO

-- Creating foreign key on [TestSuiteID] in table 'Equipment'
ALTER TABLE [dbo].[Equipment]
ADD CONSTRAINT [FK_TestSuiteEquipment]
    FOREIGN KEY ([TestSuiteID])
    REFERENCES [dbo].[TestSuites]
        ([TestSuiteID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestSuiteEquipment'
CREATE INDEX [IX_FK_TestSuiteEquipment]
ON [dbo].[Equipment]
    ([TestSuiteID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------