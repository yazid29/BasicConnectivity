using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity.ViewModels
{
    internal class RegionView : GeneralView
    {
        public string InputId()
        {
            Console.Write("Input ID:");
            var id = Console.ReadLine();
            return id;
        }
        public string InsertInput()
        {
            Console.WriteLine("Insert region name");
            var name = Console.ReadLine();

            return name;
        }

        public Region UpdateRegion()
        {
            Console.WriteLine("Insert region id");
            var id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Insert region name");
            var name = Console.ReadLine();

            return new Region
            {
                Id = id,
                Name = name
            };
        }
    }
}
