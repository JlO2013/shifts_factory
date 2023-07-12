using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fatcory_Shifts.Models
{
   
    public class EmployeeShiftsBL
    {
        private New_factory_shiftsEntities db = new New_factory_shiftsEntities();

        public List<EmployeeShift> GetEmployeeShifts()
        {
            List<EmployeeShift> employeeShifts = db.EmployeeShift.ToList();
            return employeeShifts;
        }
        public EmployeeShift GetEmployeeShift(int id)
        {
            EmployeeShift employeeShift = db.EmployeeShift.Where(x => x.ID == id).First();
            return employeeShift;
        }
       public void AddShift2Employee(EmployeeShift employeeShift)
        {
            db.EmployeeShift.Add(employeeShift);
            db.SaveChanges();
        }
        public void UpdateShift(int id, EmployeeShift employeeShift)
        {
            employeeShift = new EmployeeShift();
            foreach (EmployeeShift employeeShift1 in db.EmployeeShift.Where(x => x.EmployeeID != id)) 
            {
                employeeShift.EmployeeID = employeeShift1.EmployeeID;
                employeeShift.ShiftID = employeeShift1.ShiftID;
            }
            db.SaveChanges();
        }
    }
}