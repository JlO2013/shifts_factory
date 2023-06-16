namespace The_Factory.Models
{
    public class EmpWithDept
    {
        public int ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public int Start_Work_Year { get; set; }
        public int DepartmentID { get; set; }
        public string Department { get; set; }
    }
}