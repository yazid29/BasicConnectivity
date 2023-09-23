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
        public void GetDataId()
        {
            string input = "";
            var isTrue = true;
            while (isTrue)
            {
                try
                {
                    input = _departmentView.InputId();
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("cannot be empty");
                        continue;
                    }
                    if(!int.TryParse(input, out int id))
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
            var status = _departments.GetById(Convert.ToInt32(input));
            _departmentView.Single(status,"Departments");
        }
    }
}
