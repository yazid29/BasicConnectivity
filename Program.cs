using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BasicConnectivity
{
    internal class Program
    {
        static void Main()
        {
            //DBconnection database = new DBconnection();
            //database.ConnectDB();
            //database.CloseDB();

            
            var region = new Region();
            // GetAll Region : tampilkan semua region

            //getRegion(region);
            // Insert Region : masukan data region
            /*
            var insertRegion = region.Insert("Jawa Timur");
            if(insertRegion != null)
            {
                Console.WriteLine("Sukses Insert");
            }
            */
            // GetById Region : ambil data sesuai id
            
            var getId = region.GetById(29);
            Console.WriteLine("Diperoleh :");
            Console.WriteLine($"ID : {getId.Id}");
            Console.WriteLine($"Nama Region : {getId.Name}");

            var updateId = region.Update(29, "East Asia");
            Console.WriteLine(updateId);

            var getId2 = region.GetById(29);
            Console.WriteLine("Diperoleh :");
            Console.WriteLine($"ID : {getId2.Id}");
            Console.WriteLine($"Nama Region : {getId2.Name}");
            // Delete Region : delete data region
            //var delId = region.Delete(27);
            //Console.WriteLine(delId);

            // fungsi getRegion agar dapat dipanggil berulang kali
            static void getRegion(Region region)
            {
                var getAllRegion = region.GetAll();
                if (getAllRegion.Count > 0)
                {
                    foreach (var data in getAllRegion)
                    {
                        Console.WriteLine($"Id: {data.Id}, Name: {data.Name}");
                    }
                }
                else
                {
                    Console.WriteLine("No data found");
                }
            }
        }
    }
}
