using System;
using System.Data.SqlClient;

namespace BasicConnectivity
{

    internal class DBconnection
    {
        private static readonly string connectionString = "Data Source=DESKTOP-PEBEEBS\\SQLSERVER;Database=db_hr_dts;Integrated Security=True;Connect Timeout=15;";

        public static SqlConnection GetDBConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static SqlCommand GetDBCommand()
        {
            return new SqlCommand();
        }

        public static SqlParameter SetParameterQ(string name, object value)
        {
            return new SqlParameter(name, value);
        }

        SqlConnection database;
        public DBconnection()
        {
            this.database = new SqlConnection(connectionString);
        }

        public SqlConnection getDB()
        {
            return database;
        }
        public void ConnectDB()
        {
            try
            {
                database.Open();
                //Console.WriteLine("Sukses Terhubung ke Database");
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Gagal Terhubung ke Database");
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void CloseDB()
        {
            try
            {
                database.Close();
                Console.WriteLine("Sukses Putuskan Koneksi Database");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Gagal Terhubung ke Database");
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
