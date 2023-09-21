using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity
{
    internal class Country
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Region_id { get; set; }
        // deklarasi untuk koneksi database
        DBconnection database = new DBconnection();

        //method untuk menampilkan semua datacountry
        public List<Country> GetAll()
        {
            //declarasi sebuah daftar datacountry, dan SqlCommand untuk menampung daftar query
            var country = new List<Country>();
            using var command = new SqlCommand();

            command.Connection = database.getDB();
            command.CommandText = "SELECT * FROM countries";

            try
            {
                database.ConnectDB();

                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        country.Add(new Country
                        {
                            Id = reader.GetString(0),
                            Name = reader.GetString(1),
                            Region_id= reader.GetInt32(2)
                        });
                    }
                    reader.Close();
                    database.CloseDB();

                    return country;
                }
                reader.Close();
                database.CloseDB();

                return new List<Country>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return new List<Country>();
        }

        // INSERT: Country
        // masukan data ke dalam tabel Country
        public string Insert(string id,string name,int regionid)
        {
            // declarasi database
            DBconnection database = new DBconnection();
            // declarasi command untuk tempat query SQL
            using var command = new SqlCommand();
            var connection = database.getDB();
            command.Connection = connection;
            command.CommandText = "INSERT INTO countries VALUES (@id,@name,@regionid);";

            try
            {
                command.Parameters.Add(new SqlParameter("@id", id));
                command.Parameters.Add(new SqlParameter("@name", name));
                command.Parameters.Add(new SqlParameter("@regionid", regionid));

                database.ConnectDB();
                using var transaction = connection.BeginTransaction();
                try
                {
                    command.Transaction = transaction;

                    var result = command.ExecuteNonQuery();

                    transaction.Commit();
                    database.CloseDB();
                    Console.WriteLine("sukses");
                    return result.ToString();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("gagal");
                    return $"Error Transaction: {ex.Message}";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
        // GET BY ID: Country
        // menampilkan data sesuai dengan id yang di inginkan
        public Country GetById(string id)
        {
            // declarasi database
            DBconnection database = new DBconnection();
            // declarasi command untuk tempat query SQL
            using var command = new SqlCommand();
            var connection = database.getDB();
            command.Connection = connection;
            // query select semua columns atau atribut sesuai id yang diinginkan
            command.CommandText = $"SELECT * FROM countries WHERE id='{id}'";

            try
            {
                // hubungkan database
                connection.Open();
                // jalankan semua query yang sudah ditulis diatas pada variable command
                using var reader = command.ExecuteReader();
                // jika terdapat isinya maka datanya dikembalikan
                var datae = new Country();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        datae.Id = reader.GetString(0);
                        datae.Name = reader.GetString(1);
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
            return new Country();
        }
        // UPDATE: Country
        public string Update(string id, string name)
        {
            // declarasi database
            DBconnection database = new DBconnection();
            // declarasi command untuk tempat query SQL
            using var command = new SqlCommand();
            var connection = database.getDB();
            command.Connection = connection;
            // query update columns atau atribut nama Country sesuai id yang diinginkan
            command.CommandText = "update countries set name = @name where id=@id";

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
                pId.SqlDbType = SqlDbType.Char;
                command.Parameters.Add(pId);

                // hubungkan database
                connection.Open();
                // begintransaction digunakan jika dalam method ini melakukan pembaruhan atau perubahan dalam database
                // dan bisa disebut juga sebagai bukti transaksi database tersebut berhasil atau tidak, sebelum data dalam database diubah
                using var transaction = connection.BeginTransaction();
                try
                {
                    // jalankan query
                    var a = command.Transaction = transaction;
                    Console.WriteLine(a);
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
        // DELETE: Country
        public string Delete(string id)
        {
            // declarasi database
            DBconnection database = new DBconnection();
            // declarasi command untuk tempat query SQL
            using var command = new SqlCommand();
            var connection = database.getDB();
            command.Connection = connection;
            // query delete dari tabelcountry sesuai ID
            command.CommandText = $"DELETE FROM countries WHERE id = '{id}'";

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
