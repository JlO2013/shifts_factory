using System;
using System.Collections.Generic;

namespace The_Factory.Models
{
    public class Shifts
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public List<EmpWithDept> Employees { get; set; }

    }
}