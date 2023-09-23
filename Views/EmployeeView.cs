using BasicConnectivity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity.Views
{
    internal class EmployeeView : GeneralView
    {
        public string InputId()
        {
            Console.Write("Input ID:");
            var id = Console.ReadLine();
            return id;
        }
    }
}
