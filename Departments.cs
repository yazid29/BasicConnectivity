using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity
{
    internal class Departments
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int location_id { get; set; }
        public int manager_id { get; set; }
        // deklarasi untuk koneksi database
        DBconnection database = new DBconnection();

        //method untuk menampilkan semua dataDepartment
        public List<Departments> GetAll()
        {
            //declarasi sebuah daftar dataDepartment, dan SqlCommand untuk menampung daftar query
            var departments = new List<Departments>();
            using var command = new SqlCommand();

            command.Connection = database.getDB();
            command.CommandText = "SELECT * FROM departments";

            try
            {
                database.ConnectDB();

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
                    database.CloseDB();

                    return departments;
                }
                reader.Close();
                database.CloseDB();

                return new List<Departments>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return new List<Departments>();
        }
    }
}
