using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            InsertRegion("Australia");
            //GetRegionById(21);
            //UpdateRegion(21, "Australia Oceania");
            //DeleteRegion(21);
            GetAllRegions();
        }
        // Method connectDB untuk mengecek koneksi ke database apakah berhasil atau tidak;
        public static void ConnectDB()
        {
            // declarasi database
            using SqlConnection connDB = new SqlConnection(connectionString);
            try
            {
                // hubungkan database
                connDB.Open();
                Console.WriteLine("Sukses Terhubung ke Database");
                // putuskan koneksi database
                connDB.Close();
            }
            catch (Exception ex)
            {
                // error apabila gagal terhubung
                Console.WriteLine("Gagal Terhubung ke Database");
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        // Menampilkan semua data dari tabel regions
        public static void GetAllRegions()
        {
            // declarasi database
            using SqlConnection connection = new SqlConnection(connectionString);
            // declarasi command untuk tempat query SQL
            using SqlCommand command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = "SELECT * FROM regions";

            try
            {
                // hubungkan database
                connection.Open();
                // jalankan semua query yang sudah ditulis diatas pada variable command
                using var reader = command.ExecuteReader();

                // jika terdapat isinya maka ditampilkan datanya
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        Console.WriteLine("Id: " + reader.GetInt32(0));
                        Console.WriteLine("Name: " + reader.GetString(1));
                    }
                else
                    Console.WriteLine("No rows found.");

                // tutup semua koneksi database
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
            // declarasi database
            using var connection = new SqlConnection(connectionString);
            // declarasi command untuk tempat query SQL
            using var command = new SqlCommand();
            command.Connection = connection;
            // query insert pada tabel regions dengan value nama region
            command.CommandText = "INSERT INTO regions VALUES (@name);";

            try
            {
                // tentukan data yang ingin dimasukan kedalam database,
                // dengan mengisi VALUES sesuai parameter yang ditentukan pada commandText
                var pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.Value = name;
                pName.SqlDbType = SqlDbType.VarChar;
                command.Parameters.Add(pName);

                // hubungkan database
                connection.Open();
                // begintransaction digunakan jika dalam method ini melakukan pembaruhan atau perubahan dalam database.
                // dan bisa disebut juga sebagai bukti transaksi database tersebut berhasil atau tidak,
                // sebelum data dalam database diubah
                using var transaction = connection.BeginTransaction();
                try
                {
                    // jalankan query
                    command.Transaction = transaction;

                    var result = command.ExecuteNonQuery();
                    transaction.Commit();
                    // tutup semua koneksi database
                    connection.Close();

                    // jika query sukses dieksekusi maka isi dari result tidak akan 0 sehingga query berhasil dieksekusi
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
                    // rollback ke sebelumnya, apabila suatu query gagal dieksekusi
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
        // menampilkan data sesuai dengan id yang di inginkan
        public static void GetRegionById(int id) {
            // declarasi database
            using SqlConnection connection = new SqlConnection(connectionString);
            // declarasi command untuk tempat query SQL
            using SqlCommand command = new SqlCommand();

            command.Connection = connection;
            // query select semua columns atau atribut sesuai id yang diinginkan
            command.CommandText = "SELECT * FROM regions WHERE id="+id;

            try
            {
                // hubungkan database
                connection.Open();
                // jalankan semua query yang sudah ditulis diatas pada variable command
                using var reader = command.ExecuteReader();
                // jika terdapat isinya maka ditampilkan datanya
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        Console.WriteLine("Id: " + reader.GetInt32(0));
                        Console.WriteLine("Name: " + reader.GetString(1));
                    }
                else
                    Console.WriteLine("No rows found.");
                // tutup semua koneksi database
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
                

        // UPDATE: Region
        public static void UpdateRegion(int id, string name) {
            // declarasi database
            using var connection = new SqlConnection(connectionString);
            // declarasi command untuk tempat query SQL
            using var command = new SqlCommand();
            command.Connection = connection;
            // query update columns atau atribut nama region sesuai id yang diinginkan
            command.CommandText = "UPDATE regions SET name = @name WHERE id = @id;";

            try
            {

                // tentukan data yang ingin dimasukan kedalam database,
                // dengan mengisi setiap parameter yang ditentukan pada commandText yang ditandai dengan simbol @
                var pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.Value = name;
                pName.SqlDbType = SqlDbType.VarChar;
                command.Parameters.Add(pName);

                var pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.Int;
                command.Parameters.Add(pId);

                // hubungkan database
                connection.Open();
                // begintransaction digunakan jika dalam method ini melakukan pembaruhan atau perubahan dalam database
                // dan bisa disebut juga sebagai bukti transaksi database tersebut berhasil atau tidak, sebelum data dalam database diubah
                using var transaction = connection.BeginTransaction();
                try
                {
                    // jalankan query
                    command.Transaction = transaction;
                    var result = command.ExecuteNonQuery();
                    transaction.Commit();
                    // tutup semua koneksi database
                    connection.Close();

                    // jika query sukses dieksekusi maka isi dari result tidak akan 0 sehingga query berhasil dieksekusi
                    switch (result)
                    {
                        case >= 1:
                            Console.WriteLine("Update Success");
                            break;
                        default:
                            Console.WriteLine("Update Failed");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // rollback ke sebelumnya, apabila suatu query gagal dieksekusi
                    transaction.Rollback();
                    Console.WriteLine($"Error Transaction: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // DELETE: Region
        public static void DeleteRegion(int id) {
            // declarasi database
            using var connection = new SqlConnection(connectionString);
            // declarasi command untuk tempat query SQL
            using var command = new SqlCommand();
            command.Connection = connection;
            // query delete dari tabel regions sesuai ID
            command.CommandText = "DELETE FROM regions WHERE id = " + id;

            try
            {
                // hubungkan database
                connection.Open();
                // begintransaction digunakan jika dalam method ini melakukan pembaruhan atau perubahan dalam database
                // dan bisa disebut juga sebagai bukti transaksi database tersebut berhasil atau tidak, sebelum data dalam database diubah
                using var transaction = connection.BeginTransaction();
                try
                {
                    // jalankan query
                    command.Transaction = transaction;
                    var result = command.ExecuteNonQuery();
                    transaction.Commit();
                    // tutup semua koneksi database
                    connection.Close();

                    // jika query sukses dieksekusi maka isi dari result tidak akan 0 sehingga query berhasil dieksekusi
                    switch (result)
                    {
                        case >= 1:
                            Console.WriteLine("Delete Success");
                            break;
                        default:
                            Console.WriteLine("Delete Failed");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // rollback ke sebelumnya, apabila suatu query gagal dieksekusi
                    transaction.Rollback();
                    Console.WriteLine($"Error Transaction: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
