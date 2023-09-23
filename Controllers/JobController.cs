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
    }
}
