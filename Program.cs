using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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
                Console.WriteLine("8. Data Lengkap Employee dengan Join Table");
                Console.WriteLine("9. Beberapa detail");
                Console.WriteLine("99. Exit");
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

                    //var insertJob = job.Insert("ce", "CEO", 5000, 8000);
                    //Console.WriteLine(insertJob);
                    var updateJob = job.Update("ce", "CEO A");
                    Console.WriteLine(updateJob);

                    var getjob = job.GetById("ce");
                    Console.WriteLine("Diperoleh");
                    Console.WriteLine($"ID : {getjob.Id}");
                    Console.WriteLine($"Nama Lokasi : {getjob.title}");
                    //getJobs(job);
                    //var deljob = job.Delete("ce");
                    //Console.WriteLine(deljob);


                    break;
                case "5":
                    Console.WriteLine("Data Department");
                    var department = new Departments();

                    //var insertDe = department.Insert(13, "Trainer 2", 10,3);
                    //Console.WriteLine(insertDe);

                    //getDepartments(department);
                    //var updatedep = department.Update(12, "Trainer");
                    //Console.WriteLine(updatedep);
                    //getDepartments(department);
                    var getdep = department.GetById(13);
                    Console.WriteLine("Diperoleh");
                    Console.WriteLine($"ID : {getdep.Id}");
                    Console.WriteLine($"Nama Lokasi : {getdep.Name}");
                    //var deldepp = department.Delete(13);
                    //Console.WriteLine(deldepp);

                    break;
                case "6":
                    Console.WriteLine("Data Employee");
                    var employee = new Employee();
                    getemployee(employee);
                    //var insertEm = employee.Insert(31, "Moh", "Irfaan", "mohi@gmail.com", "082255556641", new DateTime(2023, 09, 20), 2000000, 3000.0,1);
                    //Console.WriteLine(insertEm);

                    //getDepartments(department);
                    var updatedem = employee.Update(28, "Abang");
                    Console.WriteLine(updatedem);
                    //getemployee(employee);
                    var getdemp = employee.GetById(28);
                    Console.WriteLine("Diperoleh");
                    //Console.WriteLine($"ID : {getdemp.department_id}");
                    Console.WriteLine($"Nama Lokasi : {getdemp.first_name}");
                    Console.WriteLine($"phone_number : {getdemp.phone_number}");
                    Console.WriteLine($"hire_date : {getdemp.hire_date}");
                    Console.WriteLine($"salary : {getdemp.salary}");
                    Console.WriteLine($"commision_pct : {getdemp.commision_pct}");
                    
                    //var delemp = employee.Delete(28);
                    //Console.WriteLine(delemp);
                    break;
                case "7":
                    Console.WriteLine("Data History");
                    var history = new History();
                    //var insertHis = history.Insert(new DateTime(2023, 09, 20), 3, new DateTime(2023, 09, 22), 3, "be");
                    //Console.WriteLine(insertHis);
                    var getdhisdate = history.GetById(new DateTime(2023, 09, 13), 2);
                    Console.WriteLine("Diperoleh");
                    Console.WriteLine($"StartDate : {getdhisdate.start_date}");
                    Console.WriteLine($"Id : {getdhisdate.department_id}");

                    var updatedHist = history.Update(new DateTime(2023, 09, 13), 2,4);
                    Console.WriteLine(updatedHist);

                    var getdhisdate2 = history.GetById(new DateTime(2023, 09, 13), 2);
                    Console.WriteLine("Diperoleh");
                    Console.WriteLine($"StartDate : {getdhisdate2.start_date}");
                    Console.WriteLine($"Id : {getdhisdate2.department_id}");

                    //var delemp = history.Delete(new DateTime(2023, 09, 20), 3);
                    //Console.WriteLine(delemp);
                    //gethistory(history);
                    break;
                case "8":
                    
                    var department3 = new Departments();
                    var country3 = new Country();
                    var region3 = new Region();
                    var location3 = new Location();
                    var employee3 = new Employee();

                    var getdepartment1 = department3.GetAll();
                    var getRegion1 = region3.GetAll();
                    var getLocation1 = location3.GetAll();
                    var getCountry1 = country3.GetAll();

                    var employee1 = employee3.GetAll();
                    
                    
                    var resultJoin = (from r in getRegion1
                                      join c in getCountry1 on r.Id equals c.Region_id
                                      join l in getLocation1 on c.Id equals l.country_id
                                      join d in getdepartment1 on l.Id equals d.location_id
                                      join emp in employee1 on d.Id equals emp.department_id
                                      select new 
                                      //select new
                                      {
                                          id_emp = emp.Id,
                                          id_fullname = emp.first_name+" "+emp.last_name,
                                          id_email = emp.email,
                                          id_phone=emp.phone_number,
                                          id_salary=emp.salary,
                                          departments_name = d.Name,
                                          departments_address = l.street_address,
                                          depart_country_name = c.Name,
                                          depart_region_name = r.Name,
                                          department_name = d.Name
                                      }).ToList();
                    
                    foreach (var item in resultJoin)
                    {
                        Console.WriteLine($"{item.id_emp} - {item.id_fullname} - {item.id_email} - {item.id_phone} - {item.id_salary} - " +
                            $"{item.departments_address} - {item.depart_country_name} - {item.depart_region_name}");
                    }

                    break;
                case "9":
                    var department4 = new Departments();
                    var getdepartment2 = department4.GetAll();
                    var employee4 = new Employee();
                    var getemployee4 = employee4.GetAll();
                    var job4 = new Job();
                    var getjob4 = job4.GetAll();
                    //department_name, total_employee, min_salary, max_salary, average_salary
                    var resultJoin2 = (from j in getjob4
                                       join emp2 in getemployee4 on j.Id equals emp2.job_id
                                       join deps in getdepartment2 on emp2.department_id equals deps.Id
                                       group emp2 by deps.Name into gp
                                       select new
                                       {
                                           name = gp.Key,
                                           total_employee= gp.Count(),
                                           min_salary = gp.Min(salaryEmp => salaryEmp.salary),
                                           max_salary = gp.Max(salaryEmp => salaryEmp.salary),
                                           average_salary = gp.Average(salaryEmp => salaryEmp.salary),
                                       })
                                       .ToList();
                    
                    foreach (var item in resultJoin2)
                    {
                        if (item.total_employee > 3) { 
                            Console.WriteLine($"Nama Departmen: {item.name}");
                            Console.WriteLine($"Jumlah:{item.total_employee}");
                            Console.WriteLine($"min_salary: {item.min_salary},max_salary: {item.max_salary},rata-rata: {item.average_salary}");
                        }
                    }
                    break;
                case "99":
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
                    Console.WriteLine($"hire_date: {data.hire_date}-{data.salary}-{data.job_id}-{data.department_id}");
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
