using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fatcory_Shifts.Models
{
    public class ShiftBL
    {
        private New_factory_shiftsEntities db = new New_factory_shiftsEntities();

        public List<Shift> GetShifts()
        {
            List<Shift> list = new List<Shift>();
            foreach(Shifts shifts in db.Shifts)
            {
                Shift s = new Shift();
                s.ID = shifts.ID;
                s.Date = shifts.Date;
                s.StartTime = shifts.StartTime;
                s.EndTime = shifts.EndTime;
                List<EmployeeShift> shiIDs = db.EmployeeShift.Where(x => x.ShiftID == shifts.ID).ToList();
                List<Employee> employeesList = new List<Employee>();

                foreach (EmployeeShift shi in shiIDs)
                {
                    employees empl = db.employees.Where(x => x.ID == shi.EmployeeID).First();
                    Employee employee = new Employee();
                    employee.ID = shi.EmployeeID;
                    employee.FirstName = empl.FirstName;
                    employee.LastName = empl.LastName;
                    employeesList.Add(employee);
                }
                s.Employees = employeesList;

                list.Add(s);
            }
            return list;
        }
        public Shift GetShift(int id)
        {
            Shift shift = new Shift();
            shift.ID  = db.Shifts.Where(x => x.ID == id).First().ID;
            shift.Date = db.Shifts.Where(x => x.ID == id).First().Date;
            shift.StartTime = db.Shifts.Where(x => x.ID == id).First().StartTime;
            shift.EndTime = db.Shifts.Where(x => x.ID == id).First().EndTime;
            List<EmployeeShift> shiIDs = db.EmployeeShift.Where(x => x.ShiftID == id).ToList();
            List<Employee> employeesList = new List<Employee>();

            foreach (EmployeeShift shi in shiIDs)
            {
                employees empl = db.employees.Where(x => x.ID == shi.EmployeeID).First();
                Employee employee = new Employee();
                employee.ID = shi.EmployeeID;
                employee.FirstName = empl.FirstName;
                employee.LastName = empl.LastName;
                employeesList.Add(employee);
            }
            shift.Employees = employeesList;
            return shift;
        }
        public void AddShift(Shifts shift)
        {
            db.Shifts.Add(shift);
            db.SaveChanges();
        }
        public void AddShift2Employee(EmployeeShift shift)
        {
            db.EmployeeShift.Add(shift);
            db.SaveChanges();
        }
        
    }
}