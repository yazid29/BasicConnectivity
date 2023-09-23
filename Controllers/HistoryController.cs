using BasicConnectivity.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity.Controllers
{
    internal class HistoryController
    {
        
        private History _history;
        private HistoryView _historyView;
        public HistoryController(History history, HistoryView historyview)
        {
            _history = history;
            _historyView = historyview;
        }
        public void GetAllData()
        {
            var results = _history.GetAll();
            if (!results.Any())
            {
                Console.WriteLine("No data found");
            }
            else
            {
                _historyView.List(results, "History");
            }
        }
        public void GetDataId()
        {
            DateTime input = new DateTime();
            string input2 = "";
            var isTrue = true;
            while (isTrue)
            {
                try
                {
                    Console.WriteLine("Start-Date");
                    string tgl = _historyView.InputUser("Tanggal");
                    if (string.IsNullOrEmpty(tgl) && !int.TryParse(tgl, out int tgle))
                    {
                        Console.WriteLine("cannot be empty and must be integer");
                        continue;
                    }
                    string bln = _historyView.InputUser("Bulan");
                    if (string.IsNullOrEmpty(bln) && !int.TryParse(tgl, out int blne))
                    {
                        Console.WriteLine("cannot be empty and must be integer");
                        continue;
                    }
                    string thn = _historyView.InputUser("Tahun");
                    if (string.IsNullOrEmpty(thn) && !int.TryParse(tgl, out int thne))
                    {
                        Console.WriteLine("cannot be empty and must be integer");
                        continue;
                    }

                    input2 = _historyView.InputUser("ID Employee");
                    if (string.IsNullOrEmpty(input2) && !int.TryParse(tgl, out int i))
                    {
                        Console.WriteLine("cannot be empty and must be integer");
                        continue;
                    }
                    input = new DateTime(Convert.ToInt32(thn), Convert.ToInt32(bln), Convert.ToInt32(tgl));
                    isTrue = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            
            var status = _history.GetById(input, Convert.ToInt32(input2));
            _historyView.Single(status, "Departments");
        }
    }
}
