using BasicConnectivity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity.Views
{
    public class DepartmentView : GeneralView
    {
        public string InputId()
        {
            Console.Write("Input ID:");
            var id = Console.ReadLine();
            return id;
        }
    }
}
