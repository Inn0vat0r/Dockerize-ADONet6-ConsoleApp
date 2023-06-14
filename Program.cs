using System;
using System.Threading;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ADO.NETAPP
{
    class Program
    {
        static void Main(string[] args)
        {

            //Declare the SqlDataReader
            SqlDataReader rdr = null;

            //Create connection
            SqlConnection conn = new SqlConnection("Server=tcp:xxxxx.database.windows.net,1433;Initial Catalog=SqlDatabaseName;Persist Security Info=False;User ID=sqladmin;Password=xxxxx;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=500;");

            //Create command
            SqlCommand cmd = new SqlCommand("SELECT TOP (2) * FROM [dbo].[Customers]", conn);

            try
            {
                //Open the connection
                conn.Open();
                // _logger.LogInformation("connected to sql server: ");

                // 1. get an instance of the SqlDataReader
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    // get the results of each column
                    string field1 = (string)rdr["Name"];
                    string field2 = (string)rdr["Email"];
                    Console.WriteLine($"Name:{field1}, Email:{field2}");
                }
            }
            finally
            {
                //_logger.LogInformation("Inside SQL finally : ");
                // 3. close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                // close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}
