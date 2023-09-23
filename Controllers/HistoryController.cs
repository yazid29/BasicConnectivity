using BasicConnectivity.ViewModels;
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
        //Insert(DateTime start_date1, int employee_id1, DateTime end_date1, int department_id1, string job_id1)
        public void InsertData()
        {
            string input2 = "";
            DateTime start_date = new DateTime();
            string tgl,bln,thn;
            int employee_id = 0;
            DateTime end_date = new DateTime();
            int department_id = 0;
            string job_id = "";
            var isTrue = true;
            while (isTrue)
            {
                try
                {
                    input2 = _historyView.InputUser("ID Employee");
                    if (string.IsNullOrEmpty(input2) && !int.TryParse(input2, out employee_id))
                    {
                        Console.WriteLine("cannot be empty and must be integer");
                        continue;
                    }
                    else
                    {
                        employee_id = Convert.ToInt32(input2);
                    }
                    input2 = _historyView.InputUser("Department ID");
                    if (string.IsNullOrEmpty(input2) && !int.TryParse(input2, out department_id))
                    {
                        Console.WriteLine("cannot be empty and must be integer");
                        continue;
                    }
                    else
                    {
                        department_id = Convert.ToInt32(input2);
                    }
                    input2 = _historyView.InputUser("Job ID");
                    if (string.IsNullOrEmpty(input2) && input2.Length>2 && input2.Length<2)
                    {
                        Console.WriteLine("cannot be empty and must be 2 character");
                        continue;
                    }
                    else
                    {
                        job_id = input2;
                    }
                    Console.WriteLine("Start-Date");
                    tgl = _historyView.InputUser("Tanggal");
                    if (string.IsNullOrEmpty(tgl) && !int.TryParse(tgl, out int tgle))
                    {
                        Console.WriteLine("cannot be empty and must be integer");
                        continue;
                    }
                    bln = _historyView.InputUser("Bulan");
                    if (string.IsNullOrEmpty(bln) && !int.TryParse(tgl, out int blne))
                    {
                        Console.WriteLine("cannot be empty and must be integer");
                        continue;
                    }
                    thn = _historyView.InputUser("Tahun");
                    if (string.IsNullOrEmpty(thn) && !int.TryParse(tgl, out int thne))
                    {
                        Console.WriteLine("cannot be empty and must be integer");
                        continue;
                    }
                    start_date = new DateTime(Convert.ToInt32(thn), Convert.ToInt32(bln), Convert.ToInt32(tgl));
                    Console.WriteLine("End-Date");
                    tgl = _historyView.InputUser("Tanggal");
                    if (string.IsNullOrEmpty(tgl) && !int.TryParse(tgl, out int tgle2))
                    {
                        Console.WriteLine("cannot be empty and must be integer");
                        continue;
                    }
                    bln = _historyView.InputUser("Bulan");
                    if (string.IsNullOrEmpty(bln) && !int.TryParse(tgl, out int blne2))
                    {
                        Console.WriteLine("cannot be empty and must be integer");
                        continue;
                    }
                    thn = _historyView.InputUser("Tahun");
                    if (string.IsNullOrEmpty(thn) && !int.TryParse(tgl, out int thne2))
                    {
                        Console.WriteLine("cannot be empty and must be integer");
                        continue;
                    }
                    end_date = new DateTime(Convert.ToInt32(thn), Convert.ToInt32(bln), Convert.ToInt32(tgl));
                    
                    isTrue = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            var status = _history.Insert(start_date,employee_id,end_date,department_id,job_id);
            _historyView.Transaction(status);
        }
        public void UpdateData()
        {
            //DateTime start_date1, int employee_id1, int departments_id
            var result = _history.Update(new DateTime(2023,9,20), 3, 1);
            _historyView.Transaction(result);
        }
        public void DeleteData()
        {
            var result = _history.Delete(new DateTime(2023, 9, 20), 3);
            _historyView.Single(result, "History");
        }
    }
    
}
