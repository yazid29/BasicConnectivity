using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
