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
            var choice = true;
            while (choice)
            {
                Console.WriteLine("1. Data Regions");
                Console.WriteLine("2. Data Countries");
                Console.WriteLine("3. Data Location");
                Console.WriteLine("4. Data Job");
                Console.WriteLine("5. Data Department");
                Console.WriteLine("6. Data Employee");
                Console.WriteLine("7. Data History");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice: ");
                var input = Console.ReadLine();
                choice = Menu(input);
            }
        }
        public static bool Menu(string input)
        {
            switch (input)
            {
                case "1":
                    Console.WriteLine("Data Region");
                    // GetAll Region: tampilkan semua region
                    var region = new Region();
                    //getRegion(region);
                    // Insert Region : masukan data region

                    //var insertRegion = region.Insert("Jawa Timur");
                    //Console.WriteLine("Sukses Insert");

                    //GetById Region : ambil data sesuai id
                    var getId = region.GetById(29);
                    Console.WriteLine("Diperoleh :");
                    Console.WriteLine($"ID : {getId.Id}");
                    Console.WriteLine($"Nama Region : {getId.Name}");

                    //panggil method update untuk memperbarui data
                    //var updateId = region.Update(29, "East Asia");
                    //Console.WriteLine(updateId);

                    //var getId2 = region.GetById(29);
                    //Console.WriteLine("Diperoleh :");
                    //Console.WriteLine($"ID : {getId2.Id}");
                    //Console.WriteLine($"Nama Region : {getId2.Name}");
                    // Delete Region : delete data region
                    //var delId = region.Delete(27);
                    //Console.WriteLine(delId);
                    break;
                case "2":
                    Console.WriteLine("Data Countries");
                    var country = new Country();
                    //getCountry(country);
                    //GetById Region : ambil data sesuai id

                    var getIdcountry = country.GetById("id");
                    Console.WriteLine("Diperoleh :");
                    Console.WriteLine($"ID : {getIdcountry.Id}");
                    Console.WriteLine($"Nama Region : {getIdcountry.Name}");
                    /*
                    //panggil method update untuk memperbarui data
                    //var updateId = country.Update("vi", "Vietnam");
                    //Console.WriteLine(updateId);
                    //var insertcountry = country.Insert("br","Brunei",3);
                    //Console.WriteLine(insertcountry);
                    var delId = country.Delete("es");
                    Console.WriteLine(delId);
                    */
                    break;
                case "3":
                    Console.WriteLine("Data Location");
                    var location = new Location();
                    //var insertlocation = location.Insert(11,"Tambak wedi", "60126", "Surabaya", "JawaTimur", "id");
                    //Console.WriteLine(insertlocation);
                    //getlocation(location);
                    //var updateId = location.Update(1, "Tenggumung","60153");
                    //Console.WriteLine(updateId);

                    var getIdloc = location.GetById(1);
                    Console.WriteLine("Diperoleh");
                    Console.WriteLine($"ID : {getIdloc.Id}");
                    Console.WriteLine($"Nama Lokasi : {getIdloc.street_address}");
                    var delId = location.Delete(6);
                    Console.WriteLine(delId);
                    getlocation(location);
                    break;
                case "4":
                    Console.WriteLine("Data Job");
                    var job = new Job();
                    getJobs(job);
                    break;
                case "5":
                    Console.WriteLine("Data Department");
                    var department = new Departments();
                    getDepartments(department);
                    break;
                case "6":
                    Console.WriteLine("Data Employee");
                    var employee = new Employee();
                    getemployee(employee);
                    break;
                case "7":
                    Console.WriteLine("Data History");
                    var history = new History();
                    gethistory(history);
                    break;
                case "8":
                    return false;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
            return true;
        }
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

        static void getCountry(Country country)
        {
            var getAllCountry = country.GetAll();
            if (getAllCountry.Count > 0)
            {
                foreach (var data in getAllCountry)
                {
                    Console.WriteLine($"Id: {data.Id}, Name: {data.Name}");
                }
            }
            else
            {
                Console.WriteLine("No data found");
            }
        }
        static void getDepartments(Departments departments)
        {
            var getAllDepartments = departments.GetAll();
            if (getAllDepartments.Count > 0)
            {
                foreach (var data in getAllDepartments)
                {
                    Console.WriteLine($"Id: {data.Id}, Name: {data.Name},location: {data.location_id},manager: {data.manager_id}");
                }
            }
            else
            {
                Console.WriteLine("No data found");
            }
        }

        static void getlocation(Location location)
        {
            var getAlllocation = location.GetAll();
            if (getAlllocation.Count > 0)
            {
                foreach (var data in getAlllocation)
                {
                    Console.WriteLine($"Id: {data.Id}, StreetAddress: {data.street_address},postalCode: {data.postal_code},City: {data.city},Province:{data.stat_province}");
                }
            }
            else
            {
                Console.WriteLine("No data found");
            }
        }
        static void getJobs(Job job)
        {
            var getJobss = job.GetAll();
            if (getJobss.Count > 0)
            {
                foreach (var data in getJobss)
                {
                    Console.WriteLine($"Id: {data.Id}, Name: {data.title},location: {data.min_salary},manager: {data.max_salary}");
                }
            }
            else
            {
                Console.WriteLine("No data found");
            }
        }

        static void getemployee(Employee employee)
        {
            var getemployeess = employee.GetAll();
            if (getemployeess.Count > 0)
            {
                foreach (var data in getemployeess)
                {
                    Console.WriteLine($"Id: {data.Id}, First_name: {data.first_name}," +
                        $" last name: {data.last_name}, email: {data.email}" +
                        $" phone: {data.phone_number}");
                    ///$"phone: {data.phone_number},hire_date: {data.hire_date},salary: {data.salary}");
                }
            }
            else
            {
                Console.WriteLine("No data found");
            }
        }
        static void gethistory(History history)
        {
            var gethistory = history.GetAll();
            if (gethistory.Count > 0)
            {
                foreach (var data in gethistory)
                {

                    Console.WriteLine($"start_date: {data.start_date}, empolyee_id: {data.empolyee_id}," +
                        $" end_date: {data.end_date}, department_id: {data.department_id}" +
                        $" job_id: {data.end_date}");

                }
            }
            else
            {
                Console.WriteLine("No data found");
            }
        }
    }
}
