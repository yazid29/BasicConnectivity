using BasicConnectivity.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity.Controllers
{
    internal class EmployeeController
    {
        private Employee _employees;
        private EmployeeView _employeeView;
        public EmployeeController(Employee employee, EmployeeView employeeView)
        {
            _employees = employee;
            _employeeView = employeeView;
        }
        public void GetAllData()
        {
            var results = _employees.GetAll();
            if (!results.Any())
            {
                Console.WriteLine("No data found");
            }
            else
            {
                _employeeView.List(results, "Department");
            }
        }
        public void GetDataId()
        {
            string input = "";
            var isTrue = true;
            while (isTrue)
            {
                try
                {
                    input = _employeeView.InputId();
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("cannot be empty");
                        continue;
                    }
                    if (!int.TryParse(input, out int id))
                    {
                        Console.WriteLine("Must be integer");
                        continue;
                    }
                    isTrue = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            var status = _employees.GetById(Convert.ToInt32(input));
            _employeeView.Single(status, "Employee");
        }
        public void InsertData()
        {
            int id = 0;
            string first_name = "";
            string last_name = "";
            string email = "";
            string phone_number = "";
            DateTime hire_date = new DateTime();
            int salary = 0; 
            Double commision_pct = 1.0;
            int manager_id = 0;
            string tgl, bln, thn;
            string input2 = "";
            var isTrue = true;
            while (isTrue)
            {
                try
                {
                    input2 = _employeeView.InputUser("ID Employee");
                    if (string.IsNullOrEmpty(input2) && !int.TryParse(input2, out id))
                    {
                        Console.WriteLine("cannot be empty and must be integer");
                        continue;
                    }
                    id = Convert.ToInt32(input2);
                    input2 = _employeeView.InputUser("First Name");
                    if (string.IsNullOrEmpty(input2))
                    {
                        Console.WriteLine("cannot be empty");
                        continue;
                    }
                    first_name = input2;
                    input2 = _employeeView.InputUser("Last Name");
                    if (string.IsNullOrEmpty(input2))
                    {
                        Console.WriteLine("cannot be empty");
                        continue;
                    }
                    last_name = input2;
                    input2 = _employeeView.InputUser("Email");
                    if (string.IsNullOrEmpty(input2))
                    {
                        Console.WriteLine("cannot be empty");
                        continue;
                    }
                    email = input2;
                    input2 = _employeeView.InputUser("Phone");
                    if (string.IsNullOrEmpty(input2))
                    {
                        Console.WriteLine("cannot be empty");
                        continue;
                    }
                    phone_number = input2;
                    Console.WriteLine("Hire Date");
                    tgl = _employeeView.InputUser("Tanggal");
                    if (string.IsNullOrEmpty(tgl) && !int.TryParse(tgl, out int tgle))
                    {
                        Console.WriteLine("cannot be empty and must be integer");
                        continue;
                    }
                    bln = _employeeView.InputUser("Bulan");
                    if (string.IsNullOrEmpty(bln) && !int.TryParse(tgl, out int blne))
                    {
                        Console.WriteLine("cannot be empty and must be integer");
                        continue;
                    }
                    thn = _employeeView.InputUser("Tahun");
                    if (string.IsNullOrEmpty(thn) && !int.TryParse(tgl, out int thne))
                    {
                        Console.WriteLine("cannot be empty and must be integer");
                        continue;
                    }
                    hire_date = new DateTime(Convert.ToInt32(thn), Convert.ToInt32(bln), Convert.ToInt32(tgl));
                    input2 = _employeeView.InputUser("Phone");
                    if (string.IsNullOrEmpty(input2) && !int.TryParse(input2, out salary))
                    {
                        Console.WriteLine("cannot be empty and must be integer");
                        continue;
                    }
                    salary = Convert.ToInt32(input2);
                    input2 = _employeeView.InputUser("Phone");
                    if (string.IsNullOrEmpty(input2) && !Double.TryParse(input2, out Double d))
                    {
                        Console.WriteLine("cannot be empty and must be integer");
                        continue;
                    }
                    commision_pct = Convert.ToDouble(input2);
                    input2 = _employeeView.InputUser("Phone");
                    if (string.IsNullOrEmpty(input2) && !int.TryParse(input2, out manager_id))
                    {
                        Console.WriteLine("cannot be empty and must be integer");
                        continue;
                    }
                    manager_id = Convert.ToInt32(input2);
                    isTrue = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            var status = _employees.Insert(id, first_name, last_name, email, phone_number, hire_date,salary, commision_pct,manager_id);
            _employeeView.Transaction(status);
        }
    }
}
