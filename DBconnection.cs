using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity
{

    internal class DBconnection
    {
        string connectionString = "Data Source=DESKTOP-PEBEEBS\\SQLSERVER;Database=db_hr_dts;Integrated Security=True;Connect Timeout=15;";
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
                Console.WriteLine("Sukses Terhubung ke Database");
            }catch (Exception ex)
            {
                Console.WriteLine("Gagal Terhubung ke Database");
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
