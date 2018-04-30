using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Sensit.TestSDK.Database
{
    public class SqlServer
    {

        private string _server;     // Database Server instance
        private string _database;   // Name of Database that you're connecting to
        private string _username;   // Username
        private string _password;   // Password

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
            string connetionString = null;
            SqlConnection cnn;
            connetionString = "Data Source=" + _server + ";Initial Catalog=" + _database + ";User ID=" + _username + ";Password=" + _password;
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                Console.WriteLine("Connection opened successfully");
                cnn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went awry");
            }
        }

        /// <summary>
        /// Inserts a product into the Test Suites table in the database
        /// </summary>
        /// <param name="product">Product that you want to add</param>
        public void InsertIntoTestSuites(String product)
        {
            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;
            string sql = null;

            connetionString = "Data Source=" + _server + ";Initial Catalog=" + _database + ";User ID=" + _username + ";Password=" + _password;
            sql = "Insert into TestSuites (Product) values (\'" + product + "\');";

            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                Console.WriteLine("Query executed successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Query execution failed");
            }
        }

        /// <summary>
        /// A modular query that allows you to query anything you want from the database and return the result to the console.  Used for testing purposes.
        /// </summary>
        /// <param name="query">Query you want to execute</param>
        /// <param name="numColumns">Number of columns you expect back from the database</param>
        public void ModularQuery(String query, int numColumns)
        {
            string connetionString = null;
            SqlConnection cnn;
            SqlCommand cmd;
            string sql = null;
            SqlDataReader reader;
            string result = null;

            connetionString = "Data Source=" + _server + ";Initial Catalog=" + _database + ";User ID=" + _username + ";Password=" + _password;
            sql = query;


            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = "";
                    for (int i = 0; i < numColumns; i++)
                    {
                        result = result + reader.GetValue(i) + "  ";
                    }
                    Console.WriteLine(result);
                }
                reader.Close();
                cmd.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Query execution failed");
            }
        }
    }
}
