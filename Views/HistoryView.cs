using BasicConnectivity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity.Views
{
    internal class HistoryView :GeneralView
    {
        public string InputUser(string str)
        {
            Console.Write($"Input {str}:");
            var id = Console.ReadLine();
            return id;
        }

    }
}
