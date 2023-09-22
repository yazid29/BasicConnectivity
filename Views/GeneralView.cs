using System;
using System.Collections.Generic;

namespace BasicConnectivity.ViewModels
{
    public class GeneralView
    {
        public void List<T>(List<T> items, string title)
        {
            Console.WriteLine($"List of {title}");
            Console.WriteLine("---------------");
            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("---------------");
        }

        public void Single<T>(T item, string title)
        {
            Console.WriteLine($"Data of {title}");
            Console.WriteLine("---------------");
            Console.WriteLine(item.ToString());
            Console.WriteLine("---------------");
        }

        public void Transaction(string result)
        {
            int.TryParse(result, out int res);
            if (res > 0)
            {
                Console.WriteLine("Transaction completed successfully");
            }
            else
            {
                Console.WriteLine("Transaction failed");
                Console.WriteLine(result);
            }
            Console.WriteLine("---------------");
        }
    }
}
