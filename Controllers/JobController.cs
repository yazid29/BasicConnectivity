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
    }
}
