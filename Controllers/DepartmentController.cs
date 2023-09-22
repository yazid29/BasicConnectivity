using BasicConnectivity.ViewModels;
using BasicConnectivity.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity.Controllers
{
    internal class DepartmentController
    {
        private Departments _departments;
        private DepartmentView _departmentView;
        public DepartmentController(Departments department, DepartmentView departmentView)
        {
            _departments = department;
            _departmentView = departmentView;
        }
        public void GetAllData()
        {
            var results = _departments.GetAll();
            if (!results.Any())
            {
                Console.WriteLine("No data found");
            }
            else
            {
                _departmentView.List(results, "Department");
            }
        }
    }
}
