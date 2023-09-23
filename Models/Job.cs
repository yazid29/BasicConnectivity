using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace BasicConnectivity
{
    internal class Job
    {
        // id (string) title (string) min_salary max_salary (int)
        public string Id { get; set; }
        public string title { get; set; }
        public int min_salary { get; set; }
        public int max_salary { get; set; }
        public override string ToString()
        {
            return $"{Id} - {title} - {min_salary} - {max_salary}";
        }
        public List<Job> GetAll()
        {
            //declarasi sebuah daftar dataJob, dan SqlCommand untuk menampung daftar query
            var job = new List<Job>();
            // deklarasi untuk koneksi database
            using var connectDB = DBconnection.GetDBConnection();
            using var command = DBconnection.GetDBCommand();

            command.Connection = connectDB;
            command.CommandText = "SELECT * FROM jobs";

            try
            {
                connectDB.Open();

                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        job.Add(new Job
                        {
                            Id = reader.GetString(0),
                            title = reader.GetString(1),
                            min_salary = reader.GetInt32(2),
                            max_salary = reader.GetInt32(3),
                        });
                    }
                    reader.Close();
                    connectDB.Close();

                    return job;
                }
                reader.Close();
                connectDB.Close();

                return new List<Job>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return new List<Job>();
        }
        // id (string) title (string) min_salary max_salary (int)
        public Job GetById(string id)
        {
            //Id (int) street_address postal_code city stat_province (string) country_id (string/char)
            // deklarasi untuk koneksi database
            using var connectDB = DBconnection.GetDBConnection();
            using var command = DBconnection.GetDBCommand();

            command.Connection = connectDB;
            // query select semua columns atau atribut sesuai id yang diinginkan
            command.CommandText = $"SELECT * FROM jobs WHERE id= '{id}'";

            try
            {
                // hubungkan database
                connectDB.Open();
                // jalankan semua query yang sudah ditulis diatas pada variable command
                using var reader = command.ExecuteReader();
                // jika terdapat isinya maka datanya dikembalikan
                var datae = new Job();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        datae.Id = reader.GetString(0);
                        datae.title = reader.GetString(1);
                        datae.min_salary = reader.GetInt32(2);
                        datae.max_salary = reader.GetInt32(3);
                    }
                    reader.Close();
                    connectDB.Close();
                    return datae;
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
            return new Job();
        }
        public string Insert(string id, string title, int min_salary, int max_salary)
        {
            // deklarasi untuk koneksi database
            using var connectDB = DBconnection.GetDBConnection();
            using var command = DBconnection.GetDBCommand();

            command.Connection = connectDB;
            command.CommandText = "INSERT INTO jobs VALUES (@id,@title,@min_salary,@max_salary)";

            try
            {
                command.Parameters.Add(DBconnection.SetParameterQ("@id", id));
                command.Parameters.Add(DBconnection.SetParameterQ("@title", title));
                command.Parameters.Add(DBconnection.SetParameterQ("@min_salary", min_salary));
                command.Parameters.Add(DBconnection.SetParameterQ("@max_salary", max_salary));

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
        // id (string) title (string) min_salary max_salary (int)
        public string Update(string id, string title)
        {
            // deklarasi untuk koneksi database
            using var connectDB = DBconnection.GetDBConnection();
            using var command = DBconnection.GetDBCommand();

            command.Connection = connectDB;
            // query update columns atau atribut nama region sesuai id yang diinginkan
            command.CommandText = "UPDATE jobs SET title = @title WHERE id = @id;";

            try
            {

                // tentukan data yang ingin dimasukan kedalam database,
                // dengan mengisi setiap parameter yang ditentukan pada commandText yang ditandai dengan simbol @
                command.Parameters.Add(DBconnection.SetParameterQ("@id", id));
                command.Parameters.Add(DBconnection.SetParameterQ("@title", title));

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
        public string Delete(string id)
        {
            // deklarasi untuk koneksi database
            using var connectDB = DBconnection.GetDBConnection();
            using var command = DBconnection.GetDBCommand();

            command.Connection = connectDB;
            // query delete dari tabel regions sesuai ID
            command.CommandText = $"DELETE FROM jobs WHERE id = {id}";

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
