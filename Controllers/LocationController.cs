using BasicConnectivity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity.Controllers
{
    internal class LocationController
    {
        private Location _location;
        private LocationView _locationView;
        public LocationController(Location location, LocationView locationView)
        {
            _location = location;
            _locationView = locationView;
        }
        public void GetAllData()
        {
            var results = _location.GetAll();
            if (!results.Any())
            {
                Console.WriteLine("No data found");
            }
            else
            {
                _locationView.List(results, "Location");
            }
        }
        public void GetDataId()
        {
            int id = 0;
            string input = "";
            var isTrue = true;
            while (isTrue)
            {
                try
                {
                    input = _locationView.InputId();
                    if (string.IsNullOrEmpty(input) && !int.TryParse(input, out id))
                    {
                        Console.WriteLine("cannot be empty or must be integer");
                        continue;
                    }
                    isTrue = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            id = Convert.ToInt32(input);
            var result = _location.GetById(id);
            _locationView.Single(result, "Location");
        }
        public void DeleteData()
        {
            int id = 0;
            string input = "";
            var isTrue = true;
            while (isTrue)
            {
                try
                {
                    input = _locationView.InputId();
                    if (string.IsNullOrEmpty(input) && !int.TryParse(input, out id))
                    {
                        Console.WriteLine("cannot be empty or must be integer");
                        continue;
                    }
                    isTrue = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            id = Convert.ToInt32(input);
            var result = _location.Delete(id);
            _locationView.Single(result, "Location");
        }
    }
}
