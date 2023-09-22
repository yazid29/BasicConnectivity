using BasicConnectivity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        //Id(int) street_address postal_code city stat_province(string) country_id(string/char)
        public void InsertData()
        {
            string id = "";
            string street_address = "";
            string postal_code = "";
            string city = "";
            string stat_province = "";
            string country_id = "";
            
            var isTrue = true;
            while (isTrue)
            {
                try
                {
                    id = _locationView.InputId();
                    street_address = _locationView.InsertInput("Street Addres");
                    postal_code = _locationView.InsertInput("Postal Code");
                    city = _locationView.InsertInput("City");
                    stat_province = _locationView.InsertInput("Province");
                    country_id = _locationView.InsertInput("Country ID (MAX 2 Char)");
                    if (!int.TryParse(id, out int idangka))
                    {
                        Console.WriteLine("name cannot be empty");
                        continue;
                    }
                    if (string.IsNullOrEmpty(street_address)|| string.IsNullOrEmpty(postal_code)
                        || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(stat_province) 
                        || string.IsNullOrEmpty(country_id))
                    {
                        Console.WriteLine("cannot be empty");
                        continue;
                    }
                    else if (country_id.Length > 2)
                    {
                        Console.WriteLine("to long. max 2 character");
                        continue;
                    }
                    isTrue = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            var result = _location.Insert(Convert.ToInt32(id), street_address, postal_code, city, stat_province, country_id);
            _locationView.Transaction(result);
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
