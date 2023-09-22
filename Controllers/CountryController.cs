using BasicConnectivity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity.Controllers
{
    internal class CountryController
    {
        private Country _country;
        private CountryView _countryView;
        public CountryController(Country country, CountryView countryView)
        {
            _country = country;
            _countryView = countryView;
        }
        public void GetAllData()
        {
            var results = _country.GetAll();
            if (!results.Any())
            {
                Console.WriteLine("No data found");
            }
            else
            {
                _countryView.List(results, "country");
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
                    input = _countryView.InputId();
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("cannot be empty");
                        continue;
                    }
                    isTrue = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            
            var result = _country.GetById(input);
            _countryView.Single(result, "Region");
        }
        public void InsertData()
        {
            string id = "";
            string name = "";
            int regionid = 0;
            string inputregion = "";
            var isTrue = true;
            while (isTrue)
            {
                try
                {
                    id = _countryView.InputId();
                    name = _countryView.InsertInput();
                    inputregion = _countryView.InputIdReg();
                    if (string.IsNullOrEmpty(id))
                    {
                        Console.WriteLine("name cannot be empty");
                        continue;
                    }else if (id.Length>2)
                    {
                        Console.WriteLine("to long. max 2 character");
                        continue;
                    }
                    if (!int.TryParse(inputregion, out regionid))
                    {
                        Console.WriteLine("Must be integer");
                        continue;
                    }
                    if (string.IsNullOrEmpty(name))
                    {
                        Console.WriteLine("name cannot be empty");
                        continue;
                    }
                    isTrue = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            //country.Insert("br", "Brunei", 3);
            var result = _country.Insert(id, name, regionid);
            _countryView.Transaction(result);
        }
        public void UpdateData()
        {
            int x = 0;
            string input = "";
            string updateName = "";
            var isTrue = true;
            while (isTrue)
            {
                try
                {
                    input = _countryView.InputId();
                    updateName = _countryView.InsertInput();
                    if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(updateName))
                    {
                        Console.WriteLine("name cannot be empty");
                        continue;
                    }
                    isTrue = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            var result = _country.Update(input, updateName);
            _countryView.Transaction(result);
        }
        public void DeleteData()
        {
            string input = "";
            var isTrue = true;
            while (isTrue)
            {
                try
                {
                    input = _countryView.InputId();
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("cannot be empty");
                        continue;
                    }
                    isTrue = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            var result = _country.Delete(input);
            _countryView.Transaction(result);
        }
    }
}
