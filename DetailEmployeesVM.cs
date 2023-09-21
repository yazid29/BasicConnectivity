using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity
{
    internal class DetailEmployeesVM
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int salary { get; set; }
        public string street_address { get; set; }
        public string country_name { get; set; }
        public string region_name { get; set; }

        public override string ToString()
        {
            return $"{id} - {fullname} - {email} - {phone} - {salary} - {street_address} - {country_name} - {region_name}";
        }
    }
}
