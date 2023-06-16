using System;

namespace The_Factory.Models
{
    public class Shifts4Emps
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int Start_Time { get; set; }
        public int End_Time { get; set; }
        public int EmpID { get; set; }
    }
}