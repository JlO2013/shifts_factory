using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fatcory_Shifts.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartWorkYear { get; set; }
        public string DepartmentID { get; set; }
        public List<Shifts> Shifts { get; set; }
    }
}