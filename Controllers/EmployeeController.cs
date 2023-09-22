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
    }
}
