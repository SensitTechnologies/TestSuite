using System;
using System.Collections;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace Sensit.TestSDK.Database
{
	/// <summary>
	/// Used for connecting with and using the database functionality
	/// </summary>
	/// <remarks>
	/// Inspired by: http://csharp.net-informations.com/data-providers/csharp-sqlcommand-executereader.htm
	/// Inspired by: https://stackoverflow.com/questions/1202935/convert-rows-from-a-data-reader-into-typed-results
	/// </remarks>
	public class SqlServer
	{
		private SqlConnection _connection;

		/// <summary>
		/// Name of Server instance for the Database
		/// </summary>
		public string Server { get; set; }

		/// <summary>
		/// Name of Database that you're connecting to
		/// </summary>
		public string Database { get; set; }

		/// <summary>
		/// Username of Database
		/// </summary>
		public string Username { get; set; }

		/// <summary>
		/// Password for Database
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		/// Open a connection to the specified database.
		/// </summary>
		public void Open()
		{
			// Form the connection string.
			string connectionString = "Data Source=" + Server + ";Initial Catalog=" + Database + ";User ID=" + Username + ";Password=" + Password;

			// Create new connection to SQL Server.
			_connection = new SqlConnection(connectionString);

			// Open the connection.
			_connection?.Open();
		}

		/// <summary>
		/// Close the connection to the database.
		/// </summary>
		public void Close()
		{
			// Close the connection.
			_connection?.Close();

			// Clean up.
			_connection?.Dispose();
		}

		/// <summary>
		/// Send a query to the database.
		/// </summary>
		/// <param name="query">query to be executed</param>
		public void SendQuery(string query)
		{
			SqlCommand command = new SqlCommand(query, _connection);
			command.ExecuteNonQuery();
			command.Dispose();
		}

		/// <summary>
		/// Inserts a product into the Test Suites table in the database
		/// </summary>
		/// <param name="product">Product that you want to add</param>
		public void InsertIntoTestSuites(string product)
		{
			// Form the command string.
			string commandText = "Insert into TestSuites (Product) values (\'" + product + "\');";

			// Execute the command.
			SendQuery(commandText);
		}

		/// <summary>
		/// Complete insertion for the Test Cases table in the database
		/// </summary>
		/// <param name="name">Name of Test Case</param>
		/// <param name="objective">Objective</param>
		/// <param name="owner">Owner</param>
		/// <param name="estimatedTime">Estimated Time</param>
		/// <param name="product">Project being tested</param>
		public void InsertIntoTestCases(string name, string objective, string owner, string estimatedTime, string product)
		{
			string sql =
				"insert into TestCases (Name,Objective,Owner,EstimatedTime,TestSuiteID) Values (\'" +
				name + "\',\'" + 
				objective + "\',\'" +
				owner + "\',\'" +
				estimatedTime + "\',(select TestSuiteID from TestSuites where Product = \'" +
				product + "\'));";

			// Execute the command.
			SendQuery(sql);
		}

		/// <summary>
		/// Complete insertion for the Device Under Tests table in the database
		/// </summary>
		public void InsertIntoDeviceUnderTests()
		{
			string sql = "insert DeviceUnderTests Default Values;";

			// Execute the command.
			SendQuery(sql);
		}

		/// <summary>
		/// Complete insertion for the Test Runs table in the database
		/// </summary>
		/// <param name="date">Date of Test Run</param>
		/// <param name="tester">Tester</param>
		/// <param name="notes">Notes</param>
		/// <param name="issue">Issues from test run</param>
		/// <param name="status">Status of results</param>
		public void InsertIntoTestRuns(string date, string tester, string notes, string issue, string status)
		{
			string sql = "insert into TestRuns (Date,Tester,TestCaseID,Notes,Issue,Status,EnvironmentID) Values (\'" + date + 
				"\',\'" + tester + "\',(select MAX(TestCaseID) from TestCases),\'" + notes + "\',\'" + issue +
				"\',\'" + status + "\',(select MAX(EnvironmentID) from DeviceUnderTests));";

			// Execute the command.
			SendQuery(sql);
		}

		/// <summary>
		/// Complete insertion for the Device Componenets table in the database
		/// </summary>
		/// <param name="name">Name</param>
		/// <param name="version">Version</param>
		public void InsertIntoDeviceComponents(string name, string version)
		{
			string sql = "insert into DeviceComponents(Name,Version,EnvironmentID) Values ('" + 
				name + "','" +
				version +
				"',(select MAX(EnvironmentID) from DeviceUnderTests));";

			// Execute the command.
			SendQuery(sql);
		}

		/// <summary>
		/// Complete insertion for the Equipment table in the database
		/// </summary>
		/// <param name="name">Name of Equipment</param>
		/// <param name="quantity">Quantity</param>
		public void InsertIntoEquipment(string name, string quantity)
		{
			string sql =
				"insert into Equipment (Name,Quantity,TestSuiteID) Values (\'" +
				name + "\',\'"
				+ quantity + "\',(select MAX(TestSuiteID) from TestSuites));";

			// Execute the command.
			SendQuery(sql);
		}

		/// <summary>
		/// Complete insertion for the Test Steps table in the database
		/// </summary>
		/// <param name="step">Step</param>
		/// <param name="expectedResult">Expected Result</param>
		public void InsertIntoTestSteps(string step, string expectedResult)
		{
			string sql = "insert into TestSteps (Step,ExpectedResult,TestCaseID) Values (\'" +
				step + "\',\'" + expectedResult +
				"\',(select MAX(TestCaseID) from TestCases));";

			// Execute the command.
			SendQuery(sql);
		}

		/// <summary>
		/// Complete insertion for the Test Step Results table
		/// </summary>
		/// <param name="actualResult">Actual Result</param>
		/// <param name="status">Status of step</param>
		public void InsertIntoTestStepResults(string actualResult, string status, string stepID)
		{
			string sql = "insert into TestStepResults (ActualResult,Status,TestRunID,TestStepID) Values (\'" +
				actualResult + "\',\'" + status + "\',(select MAX(TestRunID) from TestRuns),\'" + stepID + "\');";

			// Execute the command.
			SendQuery(sql);
		}

		/// <summary>
		/// A modular query that allows you to query anything you want from the database and return the result to the console.  Used for testing purposes.
		/// </summary>
		/// <param name="query">Query you want to execute</param>
		/// <param name="table">Name of Database table you're querying from (if you're looking for just the ID parameter from a certain table then use "ID")</param>
		/// <param name="nameOfId">Normally left empty unless you're using the ID table in which case you need to specify the name of the ID that you're expecting</param>
		public string ModularQueryWithResult(string query, string table, string nameOfId)
		{
			string sql = query;

			SqlCommand cmd = new SqlCommand(sql, _connection);
			SqlDataReader reader = cmd.ExecuteReader();
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
			return JsonConvert.SerializeObject(objs);
		}
	}
}
