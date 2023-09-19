using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity
{
    internal class Program
    {
        // database yang ingin dihubungkan
        static string connectionString = "Data Source=DESKTOP-PEBEEBS\\SQLSERVER;Database=db_hr_dts;Integrated Security=True;Connect Timeout=15;";
        //static SqlConnection connection;
        static void Main()
        {

            //ConnectDB();
            GetAllRegions();
        }
        // Method connectDB untuk mengecek koneksi ke database apakah berhasil atau tidak;
        public static void ConnectDB()
        {
            using SqlConnection connDB = new SqlConnection(connectionString);
            try
            {
                connDB.Open();
                Console.WriteLine("Sukses Terhubung ke Database");
                connDB.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        // Menampilkan semua data dari tabel regions
        public static void GetAllRegions()
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = "SELECT * FROM regions";

            try
            {
                connection.Open();

                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                    while (reader.Read())
                    {
                        Console.WriteLine("Id: " + reader.GetInt32(0));
                        Console.WriteLine("Name: " + reader.GetString(1));
                    }
                else
                    Console.WriteLine("No rows found.");

                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        /*
        public static void GetAllRegions()
        {
            connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM regions";

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Id: " + reader.GetInt32(0));
                        Console.WriteLine("Name: " + reader.GetString(1));
                    }
                }
                else
                {
                    Console.WriteLine("Not Found");
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error:{ex.Message}");
            };
        }
        */
    }
}
