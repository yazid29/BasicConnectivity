using BasicConnectivity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity.Controllers
{
    internal class RegionController
    {
        private Region _region;
        private RegionView _regionView;

        public RegionController(Region region, RegionView regionView)
        {
            _region = region;
            _regionView = regionView;
        }
        public void GetAllData()
        {
            var results = _region.GetAll();
            if (!results.Any())
            {
                Console.WriteLine("No data found");
            }
            else
            {
                _regionView.List(results, "regions");
            }
        }
        public void GetDataId()
        {
            int x = 0;
            string input = "";
            var isTrue = true;
            while (isTrue)
            {
                try
                {
                    input = _regionView.InputId();
                    if (!int.TryParse(input, out x))
                    {
                        Console.WriteLine("ID must be integer");
                        continue;
                    }
                    isTrue = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            x = int.Parse(input);
            var result = _region.GetById(x);
            _regionView.Single(result,"Region");
        }
        public void InsertData()
        {
            string input = "";
            var isTrue = true;
            while (isTrue)
            {
                try
                {
                    input = _regionView.InsertInput();
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Region name cannot be empty");
                        continue;
                    }
                    isTrue = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            var result = _region.Insert(input);

            _regionView.Transaction(result);
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
                    input = _regionView.InputId();
                    updateName = _regionView.InsertInput();
                    if (!int.TryParse(input, out x))
                    {
                        Console.WriteLine("Must be integer");
                        continue;
                    }
                    if (string.IsNullOrEmpty(updateName))
                    {
                        Console.WriteLine("Region name cannot be empty");
                        continue;
                    }
                    isTrue = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            x = int.Parse(input);
            var result = _region.Update(x,updateName);
            _regionView.Transaction(result);
        }
        public void DeleteData()
        {
            int x;
            string input = "";
            var isTrue = true;
            while (isTrue)
            {
                try
                {
                    input = _regionView.InputId();
                    if (!int.TryParse(input, out x))
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

            x = int.Parse(input);
            var result = _region.Delete(x);
            _regionView.Transaction(result);
        }
    }
}
