using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BasicConnectivity
{
    internal class Departments
    {
        // id int , name string, location_id int, manager_id int
        public int Id { get; set; }
        public string Name { get; set; }
        public int location_id { get; set; }
        public int manager_id { get; set; }
        public override string ToString()
        {
            return $"{Id} - {Name} - {location_id} - {manager_id}";
        }

        //method untuk menampilkan semua dataDepartment
        public List<Departments> GetAll()
        {
            //declarasi sebuah daftar dataDepartment, dan SqlCommand untuk menampung daftar query
            var departments = new List<Departments>();
            // deklarasi untuk koneksi database
            using var connectDB = DBconnection.GetDBConnection();
            using var command = DBconnection.GetDBCommand();

            command.Connection = connectDB;
            command.CommandText = "SELECT * FROM departments";

            try
            {
                connectDB.Open();

                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        departments.Add(new Departments
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            location_id = reader.GetInt32(2),
                            manager_id = reader.GetInt32(3),
                        });
                    }
                    reader.Close();
                    connectDB.Close();

                    return departments;
                }
                reader.Close();
                connectDB.Close();

                return new List<Departments>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return new List<Departments>();
        }

        // id int , name string, location_id int, manager_id int
        public Departments GetById(int id)
        {
            //Id (int) street_address postal_code city stat_province (string) country_id (string/char)
            // declarasi database
            var departments = new List<Departments>();
            // deklarasi untuk koneksi database
            using var connectDB = DBconnection.GetDBConnection();
            using var command = DBconnection.GetDBCommand();

            command.Connection = connectDB;
            // query select semua columns atau atribut sesuai id yang diinginkan
            command.CommandText = $"SELECT * FROM departments WHERE id= '{id}'";

            try
            {
                // hubungkan database
                connectDB.Open();
                // jalankan semua query yang sudah ditulis diatas pada variable command
                using var reader = command.ExecuteReader();
                // jika terdapat isinya maka datanya dikembalikan
                var datae = new Departments();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        datae.Id = reader.GetInt32(0);
                        datae.Name = reader.GetString(1);
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
            return new Departments();
        }
        public string Insert(int id, string title, int location_id, int manager_id)
        {
            // declarasi database
            var departments = new List<Departments>();
            // deklarasi untuk koneksi database
            using var connectDB = DBconnection.GetDBConnection();
            using var command = DBconnection.GetDBCommand();

            command.Connection = connectDB;
            command.CommandText = "INSERT INTO departments VALUES (@id,@title,@location_id,@manager_id);";

            try
            {
                command.Parameters.Add(new SqlParameter("@id", id));
                command.Parameters.Add(new SqlParameter("@title", title));
                command.Parameters.Add(new SqlParameter("@location_id", location_id));
                command.Parameters.Add(new SqlParameter("@manager_id", manager_id));

                connectDB.Open();
                using var transaction = connectDB.BeginTransaction();
                try
                {
                    command.Transaction = transaction;

                    var result = command.ExecuteNonQuery();

                    transaction.Commit();
                    connectDB.Close();
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
        public string Update(int id, string title)
        {
            // declarasi database
            var departments = new List<Departments>();
            // deklarasi untuk koneksi database
            using var connectDB = DBconnection.GetDBConnection();
            using var command = DBconnection.GetDBCommand();

            command.Connection = connectDB;
            // query update columns atau atribut nama region sesuai id yang diinginkan
            command.CommandText = "UPDATE departments SET name = @title WHERE id = @id;";

            try
            {

                // tentukan data yang ingin dimasukan kedalam database,
                // dengan mengisi setiap parameter yang ditentukan pada commandText yang ditandai dengan simbol @
                command.Parameters.Add(new SqlParameter("@id", id));
                command.Parameters.Add(new SqlParameter("@title", title));

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
        public string Delete(int id)
        {
            // declarasi database
            var departments = new List<Departments>();
            // deklarasi untuk koneksi database
            using var connectDB = DBconnection.GetDBConnection();
            using var command = DBconnection.GetDBCommand();

            command.Connection = connectDB;
            // query delete dari tabel regions sesuai ID
            command.CommandText = $"DELETE FROM departments WHERE id = {id}";

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
