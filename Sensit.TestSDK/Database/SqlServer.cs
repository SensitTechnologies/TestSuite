using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace Sensit.TestSDK.Database
{
    /// <summary>
    /// Used for connecting with and using the database functionality
    /// </summary>
    /// <remarks>Inspired by: http://csharp.net-informations.com/data-providers/csharp-sqlcommand-executereader.htm </remarks>
    /// <remarks>Inspired by: https://stackoverflow.com/questions/1202935/convert-rows-from-a-data-reader-into-typed-results </remarks>
    public class SqlServer
    {

        private string _server; // Database Server instance
        private string _database; // Name of Database that you're connecting to
        private string _username; // Username
        private string _password; // Password

        /// <summary>
        /// Name of Server instance for the Database
        /// </summary>
        public string Server
        {
            get => _server;
            set => _server = value;
        }

        /// <summary>
        /// Name of Database that you're connecting to
        /// </summary>
        public string Database
        {
            get => _database;
            set => _database = value;
        }

        /// <summary>
        /// Username of Database
        /// </summary>
        public string Username
        {
            get => _username;
            set => _username = value;
        }

        /// <summary>
        /// Password for Database
        /// </summary>
        public string Password
        {
            get => _password;
            set => _password = value;
        }

        /// <summary>
        /// Used to test the connection to the database with the provided credentials from the application settings
        /// </summary>
        public void CheckConnection()
        {
            string connectionString = null;
            SqlConnection cnn;
            connectionString = "Data Source=" + _server + ";Initial Catalog=" + _database + ";User ID=" + _username +
                               ";Password=" + _password; //Sql Server connection string style
            cnn = new SqlConnection(connectionString); // Creates new connecting to SQL Server Instance
            cnn.Open(); // Opens connection
            Console.WriteLine("Connection opened successfully");
        }

        /// <summary>
        /// Inserts a product into the Test Suites table in the database
        /// </summary>
        /// <param name="product">Product that you want to add</param>
        public void InsertIntoTestSuites(String product)
        {
            string connectionString = null;
            SqlConnection connection;
            SqlCommand command;
            string sql = null;

            connectionString = "Data Source=" + _server + ";Initial Catalog=" + _database + ";User ID=" + _username +
                               ";Password=" + _password;
            sql = "Insert into TestSuites (Product) values (\'" + product + "\');";

            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            Console.WriteLine("Query executed successfully");

        }

        /// <summary>
        /// Complete insertion for the Test Cases table in the database
        /// </summary>
        /// <param name="name">Name of Test Case</param>
        /// <param name="objective">Objective</param>
        /// <param name="owner">Owner</param>
        /// <param name="estimatedTime">Estimated Time</param>
        /// <param name="product">Project being tested</param>
        public void InsertIntoTestCases(String name, String objective, String owner, String estimatedTime,
            String product)
        {
            string connectionString = null;
            SqlConnection connection;
            SqlCommand command;
            string sql = null;

            connectionString = "Data Source=" + _server + ";Initial Catalog=" + _database + ";User ID=" + _username +
                               ";Password=" + _password;
            sql = "insert into TestCases (Name,Objective,Owner,EstimatedTime,TestSuiteID) Values (\'" + name + "\',\'" +
                  objective + "\',\'" + owner + "\',\'" + estimatedTime +
                  "\',(select TestSuiteID from TestSuites where Product = \'" + product + "\'));";

            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            Console.WriteLine("Query executed successfully");
        }

        /// <summary>
        /// Complete insertion for the Device Under Tests table in the database
        /// </summary>
        public void InsertIntoDeviceUnderTests()
        {
            string connectionString = null;
            SqlConnection connection;
            SqlCommand command;
            string sql = null;

            connectionString = "Data Source=" + _server + ";Initial Catalog=" + _database + ";User ID=" + _username +
                               ";Password=" + _password;
            sql = "insert DeviceUnderTests Default Values;";

            connection = new SqlConnection(connectionString);

            connection.Open();
            command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            Console.WriteLine("Query executed successfully");
        }

        /// <summary>
        /// Complete insertion for the Test Runs table in the database
        /// </summary>
        /// <param name="date">Date of Test Run</param>
        /// <param name="tester">Tester</param>
        /// <param name="notes">Notes</param>
        /// <param name="issue">Issues from test run</param>
        /// <param name="status">Status of results</param>
        public void InsertIntoTestRuns(String date, String tester, String notes, String issue, String status)
        {
            string connectionString = null;
            SqlConnection connection;
            SqlCommand command;
            string sql = null;

            connectionString = "Data Source=" + _server + ";Initial Catalog=" + _database + ";User ID=" + _username +
                               ";Password=" + _password;
            sql = "insert into TestRuns (Date,Tester,TestCaseID,Notes,Issue,Status,EnvironmentID) Values (\'" + date +
                  "\',\'" + tester + "\',(select MAX(TestCaseID) from TestCases),\'" + notes + "\',\'" + issue +
                  "\',\'" + status + "\',(select MAX(EnvironmentID) from DeviceUnderTests));";

            connection = new SqlConnection(connectionString);

            connection.Open();
            command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            Console.WriteLine("Query executed successfully");
        }

        /// <summary>
        /// Complete insertion for the Device Componenets table in the database
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="version">Version</param>
        public void InsertIntoDeviceComponents(String name, String version)
        {
            string connectionString = null;
            SqlConnection connection;
            SqlCommand command;
            string sql = null;

            connectionString = "Data Source=" + _server + ";Initial Catalog=" + _database + ";User ID=" + _username +
                               ";Password=" + _password;
            sql = "insert into DeviceComponents(Name,Version,EnvironmentID) Values ('" + name + "','" + version +
                  "',(select MAX(EnvironmentID) from DeviceUnderTests));";

            connection = new SqlConnection(connectionString);

            connection.Open();
            command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            Console.WriteLine("Query executed successfully");
        }

        /// <summary>
        /// Complete insertion for the Equipment table in the database
        /// </summary>
        /// <param name="name">Name of Equipment</param>
        /// <param name="quantity">Quantity</param>
        public void InsertIntoEquipment(String name, String quantity)
        {
            string connectionString = null;
            SqlConnection connection;
            SqlCommand command;
            string sql = null;

            connectionString = "Data Source=" + _server + ";Initial Catalog=" + _database + ";User ID=" + _username +
                               ";Password=" + _password;
            sql = "insert into Equipment (Name,Quantity,TestSuiteID) Values (\'" + name + "\',\'" + quantity +
                  "\',(select MAX(TestSuiteID) from TestSuites));";

            connection = new SqlConnection(connectionString);

            connection.Open();
            command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            Console.WriteLine("Query executed successfully");
        }

        /// <summary>
        /// Complete insertion for the Test Steps table in the database
        /// </summary>
        /// <param name="step">Step</param>
        /// <param name="expectedResult">Expected Result</param>
        public void InsertIntoTestSteps(String step, String expectedResult)
        {
            string connectionString = null;
            SqlConnection connection;
            SqlCommand command;
            string sql = null;

            connectionString = "Data Source=" + _server + ";Initial Catalog=" + _database + ";User ID=" + _username +
                               ";Password=" + _password;
            sql = "insert into TestSteps (Step,ExpectedResult,TestCaseID) Values (\'" + step +
                  "\',\'" + expectedResult +
                  "\',(select MAX(TestCaseID) from TestCases));";

            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            Console.WriteLine("Query executed successfully");
        }

        /// <summary>
        /// Complete insertion for the Test Step Results table
        /// </summary>
        /// <param name="actualResult">Actual Result</param>
        /// <param name="status">Status of step</param>
        public void InsertIntoTestStepResults(String actualResult, String status)
        {
            string connectionString = null;
            SqlConnection connection;
            SqlCommand command;
            string sql = null;

            connectionString = "Data Source=" + _server + ";Initial Catalog=" + _database + ";User ID=" + _username +
                               ";Password=" + _password;
            sql = "insert into TestStepResults (ActualResult,Status,TestRunID) Values (\'" + actualResult + "\',\'" +
                  status + "\',(select MAX(TestRunID) from TestRuns));";

            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            Console.WriteLine("Query executed successfully");
        }

        /// <summary>
        /// A modular query that allows you to query anything you want from the database and return the result to the console.  Used for testing purposes.
        /// </summary>
        /// <param name="query">Query you want to execute</param>
        /// <param name="table">Name of Database table you're querying from (if you're looking for just the ID parameter from a certain table then use "ID")</param>
        /// <param name="nameOfId">Normally left empty unless you're using the ID table in which case you need to specify the name of the ID that you're expecting</param>
        public string ModularQueryWithResult(String query, string table, string nameOfId)
        {
            string connectionString = null;
            SqlConnection cnn;
            SqlCommand cmd;
            string sql = null;
            SqlDataReader reader;
            string result = null;

            connectionString = "Data Source=" + _server + ";Initial Catalog=" + _database + ";User ID=" + _username +
                               ";Password=" + _password;
            sql = query;


            cnn = new SqlConnection(connectionString);
            cnn.Open();
            cmd = new SqlCommand(sql, cnn);
            reader = cmd.ExecuteReader();
            ArrayList objs = new ArrayList();

            switch (table)
            {
                case "Device Components":
                    while (reader.Read())
                    {
                        objs.Add(new
                        {
                            DeviceUnderTestID = reader["DeviceUnderTestID"],
                            Name = reader["Name"],
                            Version = reader["Version"],
                            EnvironmentID = reader["EnvironmentID"]
                        });
                    }

                    break;

                case "DeviceUnderTests":
                    while (reader.Read())
                    {
                        objs.Add(new
                        {
                            EnvironmentID = reader["EnvironmentID"]
                        });
                    }

                    break;

                case "Equipment":
                    while (reader.Read())
                    {
                        objs.Add(new
                        {
                            EquipmentID = reader["EquipmentID"],
                            Name = reader["Name"],
                            Quantity = reader["Quantity"],
                            TestSuiteID = reader["TestSuiteID"]
                        });
                    }

                    break;

                case "TestCases":
                    while (reader.Read())
                    {
                        objs.Add(new
                        {
                            TestCaseID = reader["TestCaseID"],
                            Name = reader["Name"],
                            Objective = reader["Objective"],
                            Owner = reader["Owner"],
                            EstimatedTime = reader["EstimatedTime"],
                            TestSuiteID = reader["TestSuiteID"]
                        });
                    }

                    break;

                case "TestRuns":
                    while (reader.Read())
                    {
                        objs.Add(new
                        {
                            TestRunID = reader["TestRunID"],
                            Date = reader["Date"],
                            Tester = reader["Tester"],
                            TestCaseID = reader["TestCaseID"],
                            Notes = reader["Notes"],
                            Issue = reader["Issue"],
                            Status = reader["Status"],
                            EnvironmentID = reader["EnvironmentID"]
                        });
                    }

                    break;

                case "TestStepResults":
                    while (reader.Read())
                    {
                        objs.Add(new
                        {
                            TestStepResultID = reader["TestStepResultID"],
                            ActualResult = reader["ActualResult"],
                            Status = reader["Status"],
                            TestRunID = reader["TestRunID"]
                        });
                    }

                    break;

                case "TestSteps":
                    while (reader.Read())
                    {
                        objs.Add(new
                        {
                            TestStepID = reader["TestStepID"],
                            Step = reader["Step"],
                            ExpectedResult = reader["ExpectedResult"],
                            TestCaseID = reader["TestCaseID"]
                        });
                    }

                    break;

                case "TestSuites":
                    while (reader.Read())
                    {
                        objs.Add(new
                        {
                            TestSuiteID = reader["TestSuiteID"],
                            Product = reader["Product"]
                        });
                    }

                    break;

                case "ID":
                    while (reader.Read())
                    {
                        objs.Add(new
                        {
                            nameOfId = reader[nameOfId]
                        });
                    }

                    break;

            }

            cmd.Dispose();
            cnn.Close();
            return JsonConvert.SerializeObject(objs);
        }


        /// <summary>
        /// A modular query that will not return anything when called.  Used for queries such as update, insert, delete, patch
        /// </summary>
        /// <param name="query">Query to be executed</param>
        public void ModularQueryNoResult(String query)
        {
            string connectionString = null;
            SqlConnection connection;
            SqlCommand command;
            string sql = null;

            connectionString = "Data Source=" + _server + ";Initial Catalog=" + _database + ";User ID=" + _username + ";Password=" + _password;
            sql = query;

            connection = new SqlConnection(connectionString);

            connection.Open();
            command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            Console.WriteLine("Query executed successfully");
        }
    }
}
