using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BasicConnectivity
{
    internal class Country
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Region_id { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name} - {Region_id}";
        }

        //method untuk menampilkan semua datacountry
        public List<Country> GetAll()
        {
            //declarasi sebuah daftar datacountry, dan SqlCommand untuk menampung daftar query
            var country = new List<Country>();
            var regions = new List<Region>();
            // deklarasi untuk koneksi database
            using var connectDB = DBconnection.GetDBConnection();
            using var command = DBconnection.GetDBCommand();

            command.Connection = connectDB;
            command.CommandText = "SELECT * FROM countries";

            try
            {
                connectDB.Open();

                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        country.Add(new Country
                        {
                            Id = reader.GetString(0),
                            Name = reader.GetString(1),
                            Region_id = reader.GetInt32(2)
                        });
                    }
                    reader.Close();
                    connectDB.Close();

                    return country;
                }
                reader.Close();
                connectDB.Close();

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
        public string Insert(string id, string name, int regionid)
        {
            //declarasi sebuah daftar datacountry, dan SqlCommand untuk menampung daftar query
            var country = new List<Country>();
            var regions = new List<Region>();
            // deklarasi untuk koneksi database
            using var connectDB = DBconnection.GetDBConnection();
            using var command = DBconnection.GetDBCommand();

            command.Connection = connectDB;
            command.CommandText = "INSERT INTO countries VALUES (@id,@name,@regionid);";

            try
            {
                command.Parameters.Add(new SqlParameter("@id", id));
                command.Parameters.Add(new SqlParameter("@name", name));
                command.Parameters.Add(new SqlParameter("@regionid", regionid));

                connectDB.Open();
                using var transaction = connectDB.BeginTransaction();
                try
                {
                    command.Transaction = transaction;

                    var result = command.ExecuteNonQuery();

                    transaction.Commit();
                    connectDB.Close();
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
            //declarasi sebuah daftar datacountry, dan SqlCommand untuk menampung daftar query
            var country = new List<Country>();
            var regions = new List<Region>();
            // deklarasi untuk koneksi database
            using var connectDB = DBconnection.GetDBConnection();
            using var command = DBconnection.GetDBCommand();

            command.Connection = connectDB;
            // query select semua columns atau atribut sesuai id yang diinginkan
            command.CommandText = $"SELECT * FROM countries WHERE id='{id}'";

            try
            {
                // hubungkan database
                connectDB.Open();
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
                        datae.Region_id = reader.GetInt32(2);
                    }
                }
                // tutup semua koneksi database
                reader.Close();
                connectDB.Close();
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
            //declarasi sebuah daftar datacountry, dan SqlCommand untuk menampung daftar query
            var country = new List<Country>();
            var regions = new List<Region>();
            // deklarasi untuk koneksi database
            using var connectDB = DBconnection.GetDBConnection();
            using var command = DBconnection.GetDBCommand();

            command.Connection = connectDB;
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
                connectDB.Open();
                // begintransaction digunakan jika dalam method ini melakukan pembaruhan atau perubahan dalam database
                // dan bisa disebut juga sebagai bukti transaksi database tersebut berhasil atau tidak, sebelum data dalam database diubah
                using var transaction = connectDB.BeginTransaction();
                try
                {
                    // jalankan query
                    var a = command.Transaction = transaction;
                    Console.WriteLine(a);
                    var result = command.ExecuteNonQuery();
                    transaction.Commit();
                    // tutup semua koneksi database
                    connectDB.Close();

                    // jika query sukses dieksekusi maka isi dari result tidak akan 0 sehingga query berhasil dieksekusi
                    if (result > 0)
                    {
                        result.ToString();
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
            //declarasi sebuah daftar datacountry, dan SqlCommand untuk menampung daftar query
            var country = new List<Country>();
            var regions = new List<Region>();
            // deklarasi untuk koneksi database
            using var connectDB = DBconnection.GetDBConnection();
            using var command = DBconnection.GetDBCommand();

            command.Connection = connectDB;
            // query delete dari tabelcountry sesuai ID
            command.CommandText = $"DELETE FROM countries WHERE id = '{id}'";

            try
            {
                // hubungkan database
                connectDB.Open();
                // begintransaction digunakan jika dalam method ini melakukan pembaruhan atau perubahan dalam database
                // dan bisa disebut juga sebagai bukti transaksi database tersebut berhasil atau tidak, sebelum data dalam database diubah
                using var transaction = connectDB.BeginTransaction();
                try
                {
                    // jalankan query
                    command.Transaction = transaction;
                    var result = command.ExecuteNonQuery();
                    transaction.Commit();
                    // tutup semua koneksi database
                    connectDB.Close();
                    // jika query sukses dieksekusi maka isi dari result tidak akan 0 sehingga query berhasil dieksekusi
                    if (result > 0)
                    {
                        return result.ToString();
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
