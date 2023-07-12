using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fatcory_Shifts.Models
{
    public class Shift
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public List<Employee> Employees { get; set; }
    }
}