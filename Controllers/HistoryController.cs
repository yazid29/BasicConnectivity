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
    }
}
