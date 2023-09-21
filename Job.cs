using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity
{
    internal class Job
    {
        // id (string) title (string) min_salary max_salary (int)
        public string Id { get; set; }
        public string title { get; set; }
        public int min_salary { get; set; }
        public int max_salary { get; set; }
        // deklarasi untuk koneksi database
        DBconnection database = new DBconnection();
        public List<Job> GetAll()
        {
            //declarasi sebuah daftar dataJob, dan SqlCommand untuk menampung daftar query
            var job = new List<Job>();
            using var command = new SqlCommand();

            command.Connection = database.getDB();
            command.CommandText = "SELECT * FROM jobs";

            try
            {
                database.ConnectDB();

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
                    database.CloseDB();

                    return job;
                }
                reader.Close();
                database.CloseDB();

                return new List<Job>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return new List<Job>();
        }
    }
}
