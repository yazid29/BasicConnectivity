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
        public void InsertData()
        {
            // id int , name string, location_id int, manager_id int
            string input = "";
            int id = 0;
            string name = "";
            int location_id = 0;
            int manager_id = 0;
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
                    if (!int.TryParse(input, out id))
                    {
                        Console.WriteLine("Must be integer");
                        continue;
                    }
                    input = _departmentView.InputUser("Department Name");
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("cannot be empty");
                        continue;
                    }
                    else
                    {
                        name = input;
                    }
                    input = _departmentView.InputUser("Location ID");
                    if (string.IsNullOrEmpty(input) && !int.TryParse(input, out location_id))
                    {
                        Console.WriteLine("cannot be empty and Must be integer");
                        continue;
                    }
                    else
                    {
                        location_id = Convert.ToInt32(input);
                    }
                    input = _departmentView.InputUser("Manager ID");
                    if (string.IsNullOrEmpty(input) && !int.TryParse(input, out manager_id))
                    {
                        Console.WriteLine("cannot be empty and Must be integer");
                        continue;
                    }
                    else
                    {
                        manager_id = Convert.ToInt32(input);
                    }

                    isTrue = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            var status = _departments.Insert(id,name,location_id,manager_id);
            _departmentView.Transaction(status);
        }
        public void UpdateData()
        {
            var result = _departments.Update(2, "Yahya");
            _departmentView.Transaction(result);
        }
        public void DeleteData()
        {
            var result = _departments.Delete(13);
            _departmentView.Transaction(result);
        }
    }
}
