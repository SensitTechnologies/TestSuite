using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
// Fix when adding Nuget Packages to the Project -> https://github.com/Microsoft/testfx/issues/216

namespace Sensit.TestSDK.Database.Tests
{
	[TestClass]
    public class DatabaseTests
    {
		[TestMethod]
        public void CheckConnection()
        {
			SqlServer database = new SqlServer();
            database.CheckConnection();
        }

        [TestMethod]
        public void ModularQueryNoResult()
        {
            SqlServer database = new SqlServer();
            database.ModularQueryNoResult("update Equipment set Name ='New Tool' where EquipmentID = 1");
			string result = database.ModularQueryWithResult("select * from Equipment where Name = 'New Tool'", "Equipment", "");
            var jo = JArray.Parse(result);
			string finalResult = (string) jo[0]["Name"];
            Assert.AreEqual(finalResult,"New Tool");
        }

        [TestMethod]
        public void InsertIntoTestSuites()
        {
            SqlServer database = new SqlServer();
            database.InsertIntoTestSuites("New Product");
			string result = database.ModularQueryWithResult("select * from TestSuites where Product = 'New Product'", "TestSuites", "");
            var jo = JArray.Parse(result);
			string finalResult = (string)jo[0]["Product"];
            Assert.AreEqual(finalResult, "New Product");
        }

        [TestMethod]
        public void InsertIntoTestCases()
        {
            SqlServer database = new SqlServer();
            database.InsertIntoTestCases("A New Name", "New Objective", "Owner 2", "A long time", "New Product");
			string result = database.ModularQueryWithResult("select * from TestCases where Objective = 'New Objective'", "TestCases", "");
            var jo = JArray.Parse(result);
			string finalResult = (string)jo[0]["Objective"];
            Assert.AreEqual(finalResult, "New Objective");
        }

        [TestMethod]
        public void InsertIntoDeviceUnderTests()
        {
            SqlServer database = new SqlServer();
            database.InsertIntoDeviceUnderTests();
            // No need to test this execution since the database will throw an error if there's a problem with the insertion since the primary key is the only thing being added to the table
        }

        [TestMethod]
        public void InsertIntoTestRuns()
        {
            SqlServer database = new SqlServer();
            database.InsertIntoTestRuns("A New Date", "Tester", "Notes", "Issue", "Status");
			string result = database.ModularQueryWithResult("select * from TestRuns where Date = 'A New Date'", "TestRuns", "");
            var jo = JArray.Parse(result);
			string finalResult = (string)jo[0]["Date"];
            Assert.AreEqual(finalResult, "A New Date");
        }

        [TestMethod]
        public void InsertIntoDeviceComponents()
        {
            SqlServer database = new SqlServer();
            database.InsertIntoDeviceComponents("A New Name", "Version 2");
			string result = database.ModularQueryWithResult("select * from DeviceComponents where Name = 'A New Name'", "DeviceComponents", "");
            var jo = JArray.Parse(result);
			string finalResult = (string)jo[0]["Name"];
            Assert.AreEqual(finalResult, "A New Name");
        }

        [TestMethod]
        public void InsertIntoEquipment()
        {
            SqlServer database = new SqlServer();
            database.InsertIntoEquipment("New Equipment", "Many");
			string result = database.ModularQueryWithResult("select * from Equipment where Name = 'New Equipment'", "Equipment", "");
            var jo = JArray.Parse(result);
			string finalResult = (string)jo[0]["Equipment"];
            Assert.AreEqual(finalResult, "New Equipment");
        }

        [TestMethod]
        public void InsertIntoTestSteps()
        {
            SqlServer database = new SqlServer();
            database.InsertIntoTestSteps("New Step", "Expected Result");
			string result = database.ModularQueryWithResult("select * from TestSteps where Step = 'New Step'", "TestSteps", "");
            var jo = JArray.Parse(result);
			string finalResult = (string)jo[0]["Step"];
            Assert.AreEqual(finalResult, "New Step");
        }

        [TestMethod]
        public void InsertIntoTestStepResults()
        {
            SqlServer database = new SqlServer();
            database.InsertIntoTestStepResults("New Actual Result", "Status", "New ID");
			string result = database.ModularQueryWithResult("select * from TestStepResults where ActualResult = 'New Actual Result'", "TestStepResults", "");
            var jo = JArray.Parse(result);
			string finalResult = (string)jo[0]["ActualResult"];
            Assert.AreEqual(finalResult, "New Actual Result");
        }
    }
}