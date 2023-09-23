using BasicConnectivity.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity.Controllers
{
    internal class JobController
    {
        private Job _job;
        private JobView _jobView;
        public JobController(Job job, JobView jobview)
        {
            _job = job;
            _jobView = jobview;
        }
        public void GetAllData()
        {
            var results = _job.GetAll();
            if (!results.Any())
            {
                Console.WriteLine("No data found");
            }
            else
            {
                _jobView.List(results, "Job");
            }
        }
        public void GetDataId()
        {
            string input = "";
            bool isTrue = true;
            while (isTrue)
            {
                try
                {
                    input = _jobView.inputId();
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("cannot be empty");
                        continue;
                    }
                    if(input.Length > 2)
                    {
                        Console.WriteLine("Max input 2 character");
                        continue;
                    }
                    isTrue = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            var status = _job.GetById(input);
            Console.WriteLine(status.title==null);
            _jobView.Single(status,"Job");
        }
        public void InsertData()
        {
            //string id, string title, int min_salary, int max_salary
            string id = "";
            string title = "";
            string min_salary = "";
            string max_salary = "";
            bool isTrue = true;
            while (isTrue)
            {
                try
                {
                    id = _jobView.inputId();
                    if (string.IsNullOrEmpty(id))
                    {
                        Console.WriteLine("cannot be empty");
                        continue;
                    }
                    if (id.Length > 2)
                    {
                        Console.WriteLine("Max input 2 character");
                        continue;
                    }
                    title = _jobView.inputUser("Title");
                    if (string.IsNullOrEmpty(title))
                    {
                        Console.WriteLine("cannot be empty");
                        continue;
                    }
                    min_salary = _jobView.inputUser("Min Salary");
                    if (string.IsNullOrEmpty(min_salary) && !int.TryParse(min_salary, out int min))
                    {
                        Console.WriteLine("Cannot be empty and Must be integer");
                        continue;
                    }
                    max_salary = _jobView.inputUser("Max Salary");
                    if (string.IsNullOrEmpty(max_salary) && !int.TryParse(max_salary, out int max))
                    {
                        Console.WriteLine("Cannot be empty and Must be integer");
                        continue;
                    }
                    isTrue = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            var status = _job.Insert(id,title,Convert.ToInt32(min_salary), Convert.ToInt32(max_salary));
            _jobView.Transaction(status);
        }
    }
}
