using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity.ViewModels
{
    internal class LocationView : GeneralView
    {
        public string InputId()
        {
            Console.Write("Input ID:");
            var id = Console.ReadLine();
            return id;
        }
        public string InsertInput(string str)
        {
            Console.WriteLine($"Insert {str} name");
            var name = Console.ReadLine();

            return name;
        }
    }
}
