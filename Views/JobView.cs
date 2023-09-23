using BasicConnectivity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity.Views
{
    internal class JobView : GeneralView
    {
        public string inputId()
        {
            Console.Write("Input ID: ");
            var id = Console.ReadLine();
            return id;
        }
        public string inputUser(string str)
        {
            Console.Write($"Input {str}: ");
            var id = Console.ReadLine();
            return id;
        }
    }
}
