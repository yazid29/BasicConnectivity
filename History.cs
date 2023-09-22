using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BasicConnectivity
{

    internal class History
    {
        public DateTime start_date { get; set; }
        public int empolyee_id { get; set; }
        public DateTime end_date { get; set; }
        public int department_id { get; set; }
        public string job_id { get; set; }
        // deklarasi untuk koneksi database
        DBconnection database = new DBconnection();
        public List<History> GetAll()
        {
            //declarasi sebuah daftar dataJob, dan SqlCommand untuk menampung daftar query
            var job = new List<History>();
            using var command = new SqlCommand();

            command.Connection = database.getDB();
            command.CommandText = "SELECT * FROM histories";

            try
            {
                database.ConnectDB();

                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        job.Add(new History
                        {

                            start_date = reader.GetDateTime(0),
                            empolyee_id = reader.GetInt32(1),
                            end_date = reader.GetDateTime(2),
                            department_id = reader.GetInt32(3),
                            job_id = reader.GetString(4),
                        });
                    }
                    reader.Close();
                    database.CloseDB();

                    return job;
                }
                reader.Close();
                database.CloseDB();

                return new List<History>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return new List<History>();
        }

        public History GetById(DateTime start_date, int id)
        {
            //Id (int) street_address postal_code city stat_province (string) country_id (string/char)
            // declarasi database
            DBconnection database = new DBconnection();
            // declarasi command untuk tempat query SQL
            using var command = new SqlCommand();
            var connection = database.getDB();
            command.Connection = connection;
            // query select semua columns atau atribut sesuai id yang diinginkan
            // select * from histories where start_date>2023-09-13 AND employee_id=2
            command.CommandText = $"SELECT * FROM histories WHERE start_date > @start_date AND employee_id= @id";

            try
            {
                command.Parameters.Add(new SqlParameter("@start_date", start_date));
                command.Parameters.Add(new SqlParameter("@id", id));
                // hubungkan database
                connection.Open();
                // jalankan semua query yang sudah ditulis diatas pada variable command
                using var reader = command.ExecuteReader();
                // jika terdapat isinya maka datanya dikembalikan
                var datae = new History();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        datae.start_date = reader.GetDateTime(0);
                        datae.empolyee_id = reader.GetInt32(1);
                        datae.end_date = reader.GetDateTime(2);
                        datae.department_id = reader.GetInt32(3);
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
            return new History();
        }


        // start_date,employee_id,end_date,department_id,job_id
        public string Insert(DateTime start_date1, int employee_id1, DateTime end_date1, int department_id1, string job_id1)
        {
            // declarasi database
            DBconnection database = new DBconnection();
            // declarasi command untuk tempat query SQL
            using var command = new SqlCommand();
            var connection = database.getDB();
            command.Connection = connection;
            command.CommandText = "INSERT INTO histories VALUES (@start_date,@employee_id,@end_date,@department_id,@job_id);";

            try
            {

                command.Parameters.Add(new SqlParameter("@start_date", start_date1));
                command.Parameters.Add(new SqlParameter("@employee_id", employee_id1));
                command.Parameters.Add(new SqlParameter("@end_date", end_date1));
                command.Parameters.Add(new SqlParameter("@department_id", department_id1));
                command.Parameters.Add(new SqlParameter("@job_id", job_id1));

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
        public string Update(DateTime start_date1, int employee_id1, int departments_id)
        {
            // declarasi database
            DBconnection database = new DBconnection();
            // declarasi command untuk tempat query SQL
            using var command = new SqlCommand();
            var connection = database.getDB();
            command.Connection = connection;
            // query update columns atau atribut nama region sesuai id yang diinginkan
            command.CommandText = "UPDATE histories SET department_id = @department_id WHERE start_date > @start_date AND employee_id=@employee_id1;";

            try
            {

                // tentukan data yang ingin dimasukan kedalam database,
                // dengan mengisi setiap parameter yang ditentukan pada commandText yang ditandai dengan simbol @
                command.Parameters.Add(new SqlParameter("@employee_id1", employee_id1));
                command.Parameters.Add(new SqlParameter("@start_date", start_date1));
                command.Parameters.Add(new SqlParameter("@department_id", departments_id));
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
        public string Delete(DateTime start_date1, int employee_id1)
        {
            // declarasi database
            DBconnection database = new DBconnection();
            // declarasi command untuk tempat query SQL
            using var command = new SqlCommand();
            var connection = database.getDB();
            command.Connection = connection;
            // query delete dari tabel regions sesuai ID
            command.CommandText = "DELETE FROM histories WHERE start_date>@start_date AND employee_id=@employee_id1";

            try
            {
                command.Parameters.Add(new SqlParameter("@start_date", start_date1));
                command.Parameters.Add(new SqlParameter("@employee_id", employee_id1));

                database.ConnectDB();
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
