using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sensit.TestSDK.Database.Tests
{
    [TestClass()]
    public class DatabaseTests
    {
        [TestMethod()]
        public void CheckConnection()
        {
            SqlServer database = new SqlServer();
            database.CheckConnection();
        }

        [TestMethod()]
        public void ModularQueryNoResult()
        {
            SqlServer database = new SqlServer();
            database.ModularQueryNoResult("update Equipment set Name ='PCN' where EquipmentID = 1");
        }

        [TestMethod()]
        public void InsertIntoTestSuites()
        {
            SqlServer database = new SqlServer();
            database.InsertIntoTestSuites("Lz-80");
        }

        [TestMethod()]
        public void InsertIntoTestCases()
        {
            SqlServer database = new SqlServer();
            database.InsertIntoTestCases("a new name", "Objective", "Owner 2", "A long time", "Lz-50");
        }

        [TestMethod()]
        public void InsertIntoDeviceUnderTests()
        {
            SqlServer database = new SqlServer();
            database.InsertIntoDeviceUnderTests();
        }

        [TestMethod()]
        public void InsertIntoTestRuns()
        {
            SqlServer database = new SqlServer();
            database.InsertIntoTestRuns("A new Date", "Tester", "Notes", "Issue", "Status");
        }

        [TestMethod()]
        public void InsertIntoDeviceComponents()
        {
            SqlServer database = new SqlServer();
            database.InsertIntoDeviceComponents("A new name", "Version 2");
        }

        [TestMethod()]
        public void InsertIntoEquipment()
        {
            SqlServer database = new SqlServer();
            database.InsertIntoEquipment("Equipment", "many");
        }

        [TestMethod()]
        public void InsertIntoTestSteps()
        {
            SqlServer database = new SqlServer();
            database.InsertIntoTestSteps("Step new", "expected result");
        }

        [TestMethod()]
        public void InsertIntoTestStepResults()
        {
            SqlServer database = new SqlServer();
            database.InsertIntoTestStepResults("Actual result 3", "Status");
        }
    }
}