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
    }
}
