using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity.ViewModels
{
    internal class CountryView : GeneralView
    {
        public string InputId()
        {
            Console.Write("Input ID:");
            var id = Console.ReadLine();
            return id;
        }
        public string InputIdReg()
        {
            Console.Write("Input ID Region:");
            var id = Console.ReadLine();
            return id;
        }
        public string InsertInput()
        {
            Console.WriteLine("Insert Country name");
            var name = Console.ReadLine();

            return name;
        }

        public Country UpdateCountry()
        {
            Console.WriteLine("Insert region id");
            var id = Console.ReadLine();
            Console.WriteLine("Insert region name");
            var name = Console.ReadLine();

            return new Country
            {
                Id = id,
                Name = name,

            };
        }
    }
}
