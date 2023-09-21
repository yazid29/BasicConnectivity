using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity
{
    internal class Location
    {
        //Id (int) street_address postal_code city stat_province (string) country_id (string/char)
        public int Id { get; set; }
        public string street_address { get; set; }
        public string postal_code { get; set; }
        public string city { get; set; }
        public string stat_province { get; set; }
        public string country_id { get; set; }
        // deklarasi untuk koneksi database
        DBconnection database = new DBconnection();

        //method untuk menampilkan semua datacountry
        public List<Location> GetAll()
        {
            //declarasi sebuah daftar datacountry, dan SqlCommand untuk menampung daftar query
            var location = new List<Location>();
            using var command = new SqlCommand();

            command.Connection = database.getDB();
            command.CommandText = "SELECT * FROM locations";

            try
            {
                database.ConnectDB();

                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        location.Add(new Location
                        {
                            Id = reader.GetInt32(0),
                            street_address = reader.GetString(1),
                            postal_code = reader.GetString(2),
                            city = reader.GetString(3),
                            stat_province = reader.GetString(4),
                        });
                    }
                    reader.Close();
                    database.CloseDB();

                    return location;
                }
                reader.Close();
                database.CloseDB();

                return new List<Location>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return new List<Location>();
        }

        public Location GetById(int id)
        {
            //Id (int) street_address postal_code city stat_province (string) country_id (string/char)
            // declarasi database
            DBconnection database = new DBconnection();
            // declarasi command untuk tempat query SQL
            using var command = new SqlCommand();
            var connection = database.getDB();
            command.Connection = connection;
            // query select semua columns atau atribut sesuai id yang diinginkan
            command.CommandText = "SELECT * FROM locations WHERE id=" + id;

            try
            {
                // hubungkan database
                connection.Open();
                // jalankan semua query yang sudah ditulis diatas pada variable command
                using var reader = command.ExecuteReader();
                // jika terdapat isinya maka datanya dikembalikan
                var datae = new Location();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        datae.Id = reader.GetInt32(0);
                        datae.street_address = reader.GetString(1);
                        datae.postal_code = reader.GetString(2);
                        datae.city = reader.GetString(3);
                        datae.stat_province = reader.GetString(4);
                    }
                }
                // tutup semua koneksi database
                reader.Close();
                connection.Close();
                return datae;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return new Location();
        }
        public string Insert(int id,string street_address, string postal_code, string city, string state_province, string country_id)
        {
            //Id (int) street_address postal_code city stat_province (string) country_id (string/char)
            // declarasi database
            DBconnection database = new DBconnection();
            // declarasi command untuk tempat query SQL
            using var command = new SqlCommand();
            var connection = database.getDB();
            command.Connection = connection;
            //locations(id,street_address,postal_code,city,state_province,country_id)
            command.CommandText = "INSERT INTO locations VALUES (@id,@street_address,@postal_code,@city,@state_province,@country_id);";

            try
            {
                command.Parameters.Add(new SqlParameter("@id", id));
                command.Parameters.Add(new SqlParameter("@street_address", street_address));
                command.Parameters.Add(new SqlParameter("@postal_code", postal_code));
                command.Parameters.Add(new SqlParameter("@city", city));
                command.Parameters.Add(new SqlParameter("@state_province", state_province));
                command.Parameters.Add(new SqlParameter("@country_id", country_id));

                database.ConnectDB();
                using var transaction = connection.BeginTransaction();
                try
                {
                    command.Transaction = transaction;

                    var result = command.ExecuteNonQuery();

                    transaction.Commit();
                    database.CloseDB();
                    return result.ToString();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return $"Error Transaction: {ex.Message}";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
        public string Update(int id, string street_address, string postal_code)
        {
            // declarasi database
            DBconnection database = new DBconnection();
            // declarasi command untuk tempat query SQL
            using var command = new SqlCommand();
            var connection = database.getDB();
            command.Connection = connection;
            // query update columns atau atribut nama region sesuai id yang diinginkan
            command.CommandText = "UPDATE locations SET street_address = @street_address, postal_code = @postal_code WHERE id = @id;";

            try
            {

                // tentukan data yang ingin dimasukan kedalam database,
                // dengan mengisi setiap parameter yang ditentukan pada commandText yang ditandai dengan simbol @
                command.Parameters.Add(new SqlParameter("@id", id));
                command.Parameters.Add(new SqlParameter("@street_address", street_address));
                command.Parameters.Add(new SqlParameter("@postal_code", postal_code));

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
                    if (result >= 0)
                    {
                        return "Update Success";
                    }
                    return "Update Gagal";
                }
                catch (Exception ex)
                {
                    // rollback ke sebelumnya, apabila suatu query gagal dieksekusi
                    transaction.Rollback();
                    return $"Error Transaction: {ex.Message}";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
        // DELETE: Region
        public string Delete(int id)
        {
            // declarasi database
            DBconnection database = new DBconnection();
            // declarasi command untuk tempat query SQL
            using var command = new SqlCommand();
            var connection = database.getDB();
            command.Connection = connection;
            // query delete dari tabel regions sesuai ID
            command.CommandText = "DELETE FROM locations WHERE id = " + id;

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
                    if (result >= 1)
                    {
                        return "Data berhasil dihapus";
                    }
                    else
                    {
                        return "Data gagal dihapus";
                    }
                }
                catch (Exception ex)
                {
                    // rollback ke sebelumnya, apabila suatu query gagal dieksekusi
                    transaction.Rollback();
                    return $"Error Transaction: {ex.Message}";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
