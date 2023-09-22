﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BasicConnectivity
{
    internal class Employee
    {
        public int Id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public DateTime hire_date { get; set; }
        public int salary { get; set; }
        public Decimal commision_pct { get; set; }
        public int manager_id { get; set; }
        public string job_id { get; set; }
        public int department_id { get; set; }
        // deklarasi untuk koneksi database
        DBconnection database = new DBconnection();
        public List<Employee> GetAll()
        {
            //declarasi sebuah daftar dataJob, dan SqlCommand untuk menampung daftar query
            var Employee = new List<Employee>();
            using var command = new SqlCommand();

            command.Connection = database.getDB();
            command.CommandText = "SELECT * FROM employees";

            try
            {
                database.ConnectDB();

                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Employee.Add(new Employee
                        {
                            Id = reader.GetInt32(0),
                            first_name = reader.GetString(1),
                            last_name = reader.GetString(2),
                            email = reader.GetString(3),
                            phone_number = reader.GetString(4),
                            hire_date = reader.GetDateTime(5),
                            salary = reader.GetInt32(6),
                            commision_pct = reader.GetDecimal(7),
                            //manager_id = reader.GetInt32(8),
                            job_id = reader.GetString(9),
                            department_id = reader.GetInt32(10)
                        });
                    }
                    reader.Close();
                    database.CloseDB();

                    return Employee;
                }
                reader.Close();
                database.CloseDB();

                return new List<Employee>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return new List<Employee>();
        }
        public Employee GetById(int id)
        {
            //Id (int) street_address postal_code city stat_province (string) country_id (string/char)
            // declarasi database
            DBconnection database = new DBconnection();
            // declarasi command untuk tempat query SQL
            using var command = new SqlCommand();
            var connection = database.getDB();
            command.Connection = connection;
            // query select semua columns atau atribut sesuai id yang diinginkan
            command.CommandText = $"SELECT * FROM employees WHERE id= '{id}'";

            try
            {
                // hubungkan database
                connection.Open();
                // jalankan semua query yang sudah ditulis diatas pada variable command
                using var reader = command.ExecuteReader();
                // jika terdapat isinya maka datanya dikembalikan
                var datae = new Employee();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        datae.Id = reader.GetInt32(0);
                        datae.first_name = reader.GetString(1);
                        datae.last_name = reader.GetString(2);
                        datae.email = reader.GetString(3);
                        datae.phone_number = reader.GetString(4);
                        datae.hire_date = reader.GetDateTime(5);
                        datae.salary = reader.GetInt32(6);
                        datae.commision_pct = reader.GetDecimal(7);
                        datae.manager_id = reader.GetInt32(8);
                        datae.job_id = reader.GetString(9);
                        datae.department_id = reader.GetInt32(10);

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
            return new Employee();
        }
        //id,first_name,last_name,email,phone_number,hire_date,salary,commision_pct,manager_id
        public string Insert(int id, string first_name, string last_name, string email, string phone_number, DateTime hire_date, int salary, Double commision_pct, int manager_id)
        {
            // declarasi database
            DBconnection database = new DBconnection();
            // declarasi command untuk tempat query SQL
            using var command = new SqlCommand();
            var connection = database.getDB();
            command.Connection = connection;
            command.CommandText = "INSERT INTO departments VALUES (@id,@first_name,@last_name,@email,@phone_number,@hire_date,@salary,@commision_pct,@manager_id);";

            try
            {
                command.Parameters.Add(new SqlParameter("@id", id));
                command.Parameters.Add(new SqlParameter("@first_name", first_name));
                command.Parameters.Add(new SqlParameter("@last_name", last_name));
                command.Parameters.Add(new SqlParameter("@email", email));
                command.Parameters.Add(new SqlParameter("@phone_number", phone_number));
                command.Parameters.Add(new SqlParameter("@hire_date", hire_date));
                command.Parameters.Add(new SqlParameter("@salary", salary));
                command.Parameters.Add(new SqlParameter("@commision_pct", commision_pct));
                command.Parameters.Add(new SqlParameter("@manager_id", manager_id));

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
        public string Update(int id, string fname)
        {
            // declarasi database
            DBconnection database = new DBconnection();
            // declarasi command untuk tempat query SQL
            using var command = new SqlCommand();
            var connection = database.getDB();
            command.Connection = connection;
            // query update columns atau atribut nama region sesuai id yang diinginkan
            command.CommandText = "UPDATE employees SET first_name = @fname WHERE id = @id;";

            try
            {

                // tentukan data yang ingin dimasukan kedalam database,
                // dengan mengisi setiap parameter yang ditentukan pada commandText yang ditandai dengan simbol @
                command.Parameters.Add(new SqlParameter("@id", id));
                command.Parameters.Add(new SqlParameter("@fname", fname));

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
        public string Delete(int id)
        {
            // declarasi database
            DBconnection database = new DBconnection();
            // declarasi command untuk tempat query SQL
            using var command = new SqlCommand();
            var connection = database.getDB();
            command.Connection = connection;
            // query delete dari tabel regions sesuai ID
            command.CommandText = $"DELETE FROM employees WHERE id = {id}";

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
