using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity
{
    internal class Location
    {
        public int Id { get; set; }
        public string street_address { get; set; }
        public string postal_code { get; set; }
        public string city { get; set; }
        public string stat_province { get; set; }
        public char country_id { get; set; }
        // deklarasi untuk koneksi database
        DBconnection database = new DBconnection();

        //method untuk menampilkan semua datacountry
        public List<Location> GetAll()
        {
            //declarasi sebuah daftar datacountry, dan SqlCommand untuk menampung daftar query
            var location = new List<Location>();
            using var command = new SqlCommand();

            command.Connection = database.getDB();
            command.CommandText = "SELECT * FROM locations";

            try
            {
                database.ConnectDB();

                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        location.Add(new Location
                        {
                            Id = reader.GetInt32(0),
                            street_address = reader.GetString(1),
                            postal_code = reader.GetString(2),
                            city = reader.GetString(3),
                            stat_province = reader.GetString(4),
                        });
                    }
                    reader.Close();
                    database.CloseDB();

                    return location;
                }
                reader.Close();
                database.CloseDB();

                return new List<Location>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return new List<Location>();
        }
    }
}
