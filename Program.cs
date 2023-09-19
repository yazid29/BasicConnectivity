using System;
using System.Collections.Generic;
using System.Data;
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

            ConnectDB();
            //InsertRegion("Australia");
            GetRegionById(21);
            //GetAllRegions();
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
        // INSERT: Region
        // masukan data ke dalam tabel region
        public static void InsertRegion(string name)
        {
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = "INSERT INTO regions VALUES (@name);";

            try
            {
                var pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.Value = name;
                pName.SqlDbType = SqlDbType.VarChar;
                command.Parameters.Add(pName);

                connection.Open();
                using var transaction = connection.BeginTransaction();
                try
                {
                    command.Transaction = transaction;

                    var result = command.ExecuteNonQuery();

                    transaction.Commit();
                    connection.Close();

                    switch (result)
                    {
                        case >= 1:
                            Console.WriteLine("Insert Success");
                            break;
                        default:
                            Console.WriteLine("Insert Failed");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine($"Error Transaction: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // GET BY ID: Region
        public static void GetRegionById(int id) {
            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = "SELECT * FROM regions WHERE id="+id;

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
                

        // UPDATE: Region
        public static void UpdateRegion(int id, string name) { }

        // DELETE: Region
        public static void DeleteRegion(int id) { }
    }
}
