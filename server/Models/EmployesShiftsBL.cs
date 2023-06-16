using System.Collections.Generic;
using System.Linq;

namespace The_Factory.Models
{
    public class EmployesShiftsBL
    {
        private Factory_ProjectEntities db = new Factory_ProjectEntities();

        public List<EmployeesShift> GetEmployee2Shifts()
        {
            List<EmployeesShift> empsh = db.EmployeesShifts.ToList();
            return empsh;
        }
        public EmployeesShift GetEmployee2Shift(int id)
        {
            return db.EmployeesShifts.Where(x => x.ID == id).First();
        }
        public List<Shifts4Emps> GetShiftsByEmp(int EmployeeID)
        {
            List<Shifts4Emps> EWS = new List<Shifts4Emps>();
            List<EmployeesShift> EmpShi = db.EmployeesShifts.Where(x => x.EmployeeID == EmployeeID).ToList();
            List<Shift> Shifts = new List<Shift>();
            foreach (EmployeesShift emp in EmpShi)
            {
                foreach (Shift shift in db.Shifts.Where(x => x.ID == emp.ShiftID))
                {
                    Shifts.Add(shift);

                }
            }
            foreach (Shift shift1n in Shifts)
            {
                Shifts4Emps E2S = new Shifts4Emps();
                E2S.Date = shift1n.Date;
                E2S.Start_Time = shift1n.Start_Time;
                E2S.End_Time = shift1n.End_Time;

                EWS.Add(E2S);
            }
            return EWS;
        }
        public List<Shifts> GetShift(int EmployeeID)
        {
            List<Shifts> EWS = new List<Shifts>();
            List<EmployeesShift> EmpShi = db.EmployeesShifts.Where(x => x.EmployeeID != EmployeeID).ToList();
            List<Shift> Shifts = new List<Shift>();
            foreach (EmployeesShift emp in EmpShi)
            {
                foreach (Shift shift in db.Shifts.Where(x => x.ID == emp.ShiftID))
                {
                    Shifts.Add(shift);
                }
            }
            return EWS;
        }
        public void AddShiftToEmp(EmployeesShift shift)
        {
            db.EmployeesShifts.Add(shift);
            db.SaveChanges();
        }
        public void UpdateShift(int ID, EmployeesShift shift2)
        {
            shift2 = new EmployeesShift();
            foreach (EmployeesShift shift1 in db.EmployeesShifts.Where(x => x.EmployeeID != ID))
            {
                shift2.ShiftID = shift1.ShiftID;
                shift2.EmployeeID = shift1.EmployeeID;
            }
            db.SaveChanges();
        }
        public void DeleteShift(int EmployeeID)
        {
            List<EmployeesShift> employeesShifts = db.EmployeesShifts.Where(x => x.EmployeeID == EmployeeID).ToList();
            foreach (EmployeesShift employeesShift in employeesShifts)
            {
                db.EmployeesShifts.Remove(employeesShift);
                db.SaveChanges();
            }
        }
    }
}