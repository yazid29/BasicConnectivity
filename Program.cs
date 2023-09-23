using BasicConnectivity.Controllers;
using BasicConnectivity.ViewModels;
using BasicConnectivity.Views;
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
        public static void subMenu(string str)
        {
            Console.WriteLine($"1. List all {str}");
            Console.WriteLine($"2. Get data {str}");
            Console.WriteLine($"3. Insert new {str}");
            Console.WriteLine($"4. Update {str}");
            Console.WriteLine($"5. Delete {str}");
            Console.WriteLine("0. Back");
        }
        public static void RegionMenu()
        {
            var region = new Region();
            var regionView = new RegionView();

            var regionController = new RegionController(region, regionView);

            var isLoop = true;
            while (isLoop)
            {
                subMenu("Region");
                Console.Write("Enter your choice: ");
                var input2 = Console.ReadLine();
                switch (input2)
                {
                    case "0":
                        isLoop = false;
                        break;
                    case "1":
                        regionController.GetAllData();
                        break;
                    case "2":
                        regionController.GetDataId();
                        break;
                    case "3":
                        regionController.InsertData();
                        break;
                    case "4":
                        regionController.UpdateData();
                        break;
                    case "5":
                        regionController.DeleteData();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
        public static void CountryMenu()
        {
            var country = new Country();
            var countryView = new CountryView();

            var countryController = new CountryController(country, countryView);

            var isLoop = true;
            while (isLoop)
            {
                subMenu("Country");
                Console.Write("Enter your choice: ");
                var input2 = Console.ReadLine();
                switch (input2)
                {
                    case "0":
                        isLoop = false;
                        break;
                    case "1":
                        countryController.GetAllData();
                        break;
                    case "2":
                        countryController.GetDataId();
                        break;
                    case "3":
                        countryController.InsertData();
                        break;
                    case "4":
                        countryController.UpdateData();
                        break;
                    case "5":
                        countryController.DeleteData();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
        public static void LocationMenu()
        {
            var location = new Location();
            var locationView = new LocationView();

            var locationController = new LocationController(location, locationView);

            var isLoop = true;
            while (isLoop)
            {
                subMenu("Location");
                Console.Write("Enter your choice: ");
                var input2 = Console.ReadLine();
                switch (input2)
                {
                    case "0":
                        isLoop = false;
                        break;
                    case "1":
                        locationController.GetAllData();
                        break;
                    case "2":
                        locationController.GetDataId();
                        break;
                    case "3":
                        locationController.InsertData();
                        break;
                    case "4":
                        locationController.UpdateData();
                        break;
                        
                    case "5":
                        locationController.DeleteData();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
        public static void JobMenu()
        {
            var jobs = new Job();
            var jobsView = new JobView();

            var jobsController = new JobController(jobs, jobsView);

            var isLoop = true;
            while (isLoop)
            {
                subMenu("Jobs");
                Console.Write("Enter your choice: ");
                var input2 = Console.ReadLine();
                switch (input2)
                {
                    case "0":
                        isLoop = false;
                        break;
                    case "1":
                        jobsController.GetAllData();
                        break;
                    case "2":
                        jobsController.GetDataId();
                        break;
                    case "3":
                        jobsController.InsertData();
                        break;
                    case "4":
                        //jobsController.UpdateData();
                        break;

                    case "5":
                        //jobsController.DeleteData();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
        public static void DepartmentMenu()
        {
            var departments = new Departments();
            var departmentsView = new DepartmentView();

            var departmentsController = new DepartmentController(departments, departmentsView);

            var isLoop = true;
            while (isLoop)
            {
                subMenu("Department");
                Console.Write("Enter your choice: ");
                var input2 = Console.ReadLine();
                switch (input2)
                {
                    case "0":
                        isLoop = false;
                        break;
                    case "1":
                        departmentsController.GetAllData();
                        break;
                    case "2":
                        departmentsController.GetDataId();
                        break;
                    case "3":
                        departmentsController.InsertData();
                        break;
                    case "4":
                        //departmentsController.UpdateData();
                        break;

                    case "5":
                        //departmentsController.DeleteData();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
        
        public static void EmployeeMenu()
        {
            var employees = new Employee();
            var employeeView = new EmployeeView();

            var employeeController = new EmployeeController(employees, employeeView);

            var isLoop = true;
            while (isLoop)
            {
                subMenu("Employee");
                Console.Write("Enter your choice: ");
                var input2 = Console.ReadLine();
                switch (input2)
                {
                    case "0":
                        isLoop = false;
                        break;
                    case "1":
                        employeeController.GetAllData();
                        break;
                    case "2":
                        employeeController.GetDataId();
                        break;
                    case "3":
                        //employeeController.InsertData();
                        break;
                    case "4":
                        //employeeController.UpdateData();
                        break;

                    case "5":
                        //employeeController.DeleteData();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
        public static void HistoryMenu()
        {
            var history = new History();
            var historyView = new HistoryView();

            var historyController = new HistoryController(history, historyView);

            var isLoop = true;
            while (isLoop)
            {
                subMenu("History");
                Console.Write("Enter your choice: ");
                var input2 = Console.ReadLine();
                switch (input2)
                {
                    case "0":
                        isLoop = false;
                        break;
                    case "1":
                        historyController.GetAllData();
                        break;
                    case "2":
                        historyController.GetDataId();
                        break;
                    case "3":
                        //historyController.InsertData();
                        break;
                    case "4":
                        //historyController.UpdateData();
                        break;

                    case "5":
                        //historyController.DeleteData();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
        public static bool Menu(string input)
        {
            switch (input)
            {
                case "1":
                    RegionMenu();
                    break;
                case "2":
                    CountryMenu();
                    break;
                case "3":
                    LocationMenu();
                    break;
                case "4":
                    JobMenu();
                    break;
                case "5":
                    DepartmentMenu();
                    break;
                case "6":
                    EmployeeMenu();
                    break;
                case "7":
                    HistoryMenu();
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
                case "10":
                    break;
                case "99":
                    return false;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
            return true;
        }
    }
}
