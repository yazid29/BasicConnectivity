using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public decimal commision_pct { get; set; }
        // deklarasi untuk koneksi database
        DBconnection database = new DBconnection();
        public List<Employee> GetAll()
        {
            //declarasi sebuah daftar dataJob, dan SqlCommand untuk menampung daftar query
            var job = new List<Employee>();
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
                        job.Add(new Employee
                        {
                            Id = reader.GetInt32(0),
                            first_name = reader.GetString(1),
                            last_name = reader.GetString(2),
                            email = reader.GetString(3),
                            phone_number = reader.GetString(4),
                        });
                    }
                    reader.Close();
                    database.CloseDB();

                    return job;
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
    }
}
