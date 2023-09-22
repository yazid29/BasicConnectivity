namespace BasicConnectivity
{
    internal class DetailDepartmentsVM
    {
        public string name_emp { get; set; }
        public string department_name { get; set; }
        public int department_id { get; set; }
        public int salary_emp { get; set; }
        public override string ToString()
        {
            return $"{name_emp} - {department_name} - {department_id} - {salary_emp} ";
        }
    }
}
