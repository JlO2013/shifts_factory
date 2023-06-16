using System.Collections.Generic;

namespace The_Factory.Models
{
    public class EmpWithDeptWithShift
    {
        public int ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public int Start_Work_Year { get; set; }
        public string Department { get; set; }
        public List<Shifts4Emps> Shift { get; set; }

    }
}