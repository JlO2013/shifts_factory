using System.Collections.Generic;
using System.Linq;
using The_Factory.Models;

namespace TheFactory.Models
{
    public class ShiftsBL
    {
        private Factory_ProjectEntities db = new Factory_ProjectEntities();
        public List<Shifts> GetShifts()
        {
            List<Shifts> shifts = new List<Shifts>();
            foreach (Shift shis in db.Shifts)
            {
                Shifts DetailShift = new Shifts();
                DetailShift.ID = shis.ID;
                DetailShift.Date = shis.Date;
                DetailShift.StartTime = shis.Start_Time;
                DetailShift.EndTime = shis.End_Time;
                List<EmployeesShift> empsh = db.EmployeesShifts.Where(x => x.ShiftID == shis.ID).ToList();
                List<EmpWithDept> employees = new List<EmpWithDept>();
                List<Employee> emps = db.Employees.ToList();
                foreach (Employee emp in emps)
                {
                    if (empsh.Any(x => x.EmployeeID == emp.ID))
                    {
                        EmpWithDept EWDWS = new EmpWithDept();
                        EWDWS.ID = emp.ID;
                        EWDWS.First_Name = emp.First_Name;
                        EWDWS.Last_Name = emp.Last_Name;
                        employees.Add(EWDWS);
                    }
                }
                DetailShift.Employees = employees;
                shifts.Add(DetailShift);
            }
            return shifts;
        }
        public Shifts GetShift(int id)
        {
            Shifts shift = new Shifts();
            shift.ID = db.Shifts.Where(x => x.ID == id).First().ID;
            shift.Date = db.Shifts.Where(x => x.ID == id).First().Date;
            shift.StartTime = db.Shifts.Where(x => x.ID == id).First().Start_Time;
            shift.EndTime = db.Shifts.Where(x => x.ID == id).First().End_Time;
            List<EmployeesShift> empsh = db.EmployeesShifts.Where(x => x.ShiftID == shift.ID).ToList();
            List<EmpWithDept> employees = new List<EmpWithDept>();
            List<Employee> emps = db.Employees.ToList();
            foreach (Employee emp in emps)
            {
                if (empsh.Any(x => x.EmployeeID == emp.ID))
                {
                    EmpWithDept EWDWS = new EmpWithDept();
                    EWDWS.ID = emp.ID;
                    EWDWS.First_Name = emp.First_Name;
                    EWDWS.Last_Name = emp.Last_Name;
                    employees.Add(EWDWS);
                }
            }
            shift.Employees = employees;
            return shift;
        }
        public List<Shifts4Emps> GetShiftsByEmp(int empsID)
        {
            List<EmployeesShift> EmpShi = new List<EmployeesShift>();
            foreach (EmployeesShift employeesShift in db.EmployeesShifts.Where(x => x.EmployeeID != empsID))
            {
                EmpShi.Add(employeesShift);
            }
            List<Shifts4Emps> Shifts = new List<Shifts4Emps>();
            foreach (EmployeesShift emp in EmpShi)
            {
                foreach (Shift shift in db.Shifts.Where(x => x.ID == emp.ShiftID))
                {
                    Shifts4Emps shifts = new Shifts4Emps();
                    shifts.ID = shift.ID;
                    shifts.Date = shift.Date;
                    shifts.Start_Time = shift.Start_Time;
                    shifts.End_Time = shift.End_Time;
                    shifts.EmpID = empsID;
                    Shifts.Add(shifts);
                }
            }
            return Shifts;
        }
        public void AddShift(Shift shift)
        {
            db.Shifts.Add(shift);
            db.SaveChanges();
        }
        public void AddShiftToEmp(EmployeesShift shift)
        {
            db.EmployeesShifts.Add(shift);
            db.SaveChanges();
        }
        public void UpdateShift(int ID, EmployeesShift shift2)
        {
            shift2 = new EmployeesShift();
            foreach (EmployeesShift shift1 in db.EmployeesShifts.Where(x => x.ShiftID == 0))
            {
                shift2.EmployeeID = shift1.EmployeeID;
                shift2.ShiftID = shift1.ShiftID;
            }
            db.SaveChanges();
        }
    }
}