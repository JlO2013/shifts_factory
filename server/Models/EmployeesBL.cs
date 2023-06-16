using System.Collections.Generic;
using System.Linq;



namespace The_Factory.Models
{
    public class EmployeesBL
    {
        private Factory_ProjectEntities db = new Factory_ProjectEntities();
        public List<EmpWithDeptWithShift> GetEmplyees()
        {
            List<EmpWithDeptWithShift> employees = new List<EmpWithDeptWithShift>();
            foreach (Employee emp in db.Employees)
            {
                EmpWithDeptWithShift detailEmp = new EmpWithDeptWithShift();
                detailEmp.ID = emp.ID;
                detailEmp.First_Name = emp.First_Name;
                detailEmp.Last_Name = emp.Last_Name;
                detailEmp.Start_Work_Year = emp.Start_work_year;
                List<Department> empDept = db.Departments.Where(d => d.ID == emp.DepartmentID).ToList();
                foreach (Department dept in db.Departments)
                {
                    if (dept.ID == emp.DepartmentID)
                    {
                        detailEmp.Department = dept.Name;
                    }
                }
                List<Shifts4Emps> shifts = new List<Shifts4Emps>();
                List<EmployeesShift> empShifts = db.EmployeesShifts.Where(x => x.EmployeeID == emp.ID).ToList();
                foreach (EmployeesShift employeesShift in empShifts)
                {
                    foreach (Shift shi in db.Shifts.Where(x => x.ID == employeesShift.ShiftID))
                    {
                        Shifts4Emps shift = new Shifts4Emps();
                        shift.Date = shi.Date;
                        shift.Start_Time = shi.Start_Time;
                        shift.End_Time = shi.End_Time;
                        shifts.Add(shift);
                    }
                }
                detailEmp.Shift = shifts;
                employees.Add(detailEmp);
            }
            return employees;
        }
        public EmpWithDeptWithShift GetEmployee(int id)
        {
            List<EmpWithDeptWithShift> employees = new List<EmpWithDeptWithShift>();

            foreach (Employee emp in db.Employees)
            {
                EmpWithDeptWithShift detailEmp = new EmpWithDeptWithShift();
                detailEmp.ID = emp.ID;
                detailEmp.First_Name = emp.First_Name;
                detailEmp.Last_Name = emp.Last_Name;
                detailEmp.Start_Work_Year = emp.Start_work_year;
                foreach (Department dept in db.Departments.Where(d => d.ID == emp.DepartmentID))
                {
                    if (dept.ID == emp.DepartmentID)
                    {
                        Department department = new Department();
                        department.ID = emp.DepartmentID;
                        department.Name = dept.Name;
                        department.Manager = dept.Manager;
                        detailEmp.Department = department.Name;
                    }
                }
                List<EmployeesShift> shifts = db.EmployeesShifts.Where(d => d.EmployeeID == emp.ID).ToList();
                List<Shift> shifts1 = new List<Shift>();
                foreach (EmployeesShift emp2Shift in shifts)
                {
                    shifts1 = db.Shifts.Where(s => s.ID == emp2Shift.ShiftID).ToList();
                }
                List<Shifts4Emps> detShift = new List<Shifts4Emps>();
                foreach (Shift shis in shifts1)
                {
                    Shifts4Emps DetailShift = new Shifts4Emps();
                    DetailShift.Date = shis.Date;
                    DetailShift.Start_Time = shis.Start_Time;
                    DetailShift.End_Time = shis.End_Time;
                    detShift.Add(DetailShift);
                }
                detailEmp.Shift = detShift;
                employees.Add(detailEmp);
            }
            return employees.Where(x => x.ID == id).First();
        }
        public List<EmpWithDeptWithShift> GetEmployeeByFirst_Name(string name)
        {

            List<EmpWithDeptWithShift> emps = new List<EmpWithDeptWithShift>();
            foreach (Employee emp in db.Employees)
            {
                if (emp.First_Name == name)
                {
                    EmpWithDeptWithShift detailEmp = new EmpWithDeptWithShift();
                    detailEmp.ID = emp.ID;
                    detailEmp.First_Name = emp.First_Name;
                    detailEmp.Last_Name = emp.Last_Name;
                    detailEmp.Start_Work_Year = emp.Start_work_year;
                    foreach (Department dept in db.Departments.Where(d => d.ID == emp.DepartmentID))
                    {
                        if (dept.ID == emp.DepartmentID)
                        {
                            Department der = new Department();
                            der.ID = emp.DepartmentID;
                            der.Name = dept.Name;
                            detailEmp.Department = der.Name;
                        }
                    }
                    List<EmployeesShift> shifts = db.EmployeesShifts.Where(d => d.EmployeeID != emp.ID).ToList();
                    List<Shift> shifts1 = new List<Shift>();
                    foreach (EmployeesShift emp2Shift in shifts)
                    {
                        shifts1 = db.Shifts.Where(s => s.ID == emp2Shift.ShiftID).ToList();
                    }
                    List<Shifts4Emps> detShift = new List<Shifts4Emps>();
                    foreach (Shift shis in shifts1)
                    {
                        Shifts4Emps DetailShift = new Shifts4Emps();
                        DetailShift.Date = shis.Date;
                        DetailShift.Start_Time = shis.Start_Time;
                        DetailShift.End_Time = shis.End_Time;
                        detShift.Add(DetailShift);
                    }
                    detailEmp.Shift = detShift;
                    emps.Add(detailEmp);
                }
                else if (emp.Last_Name == name)
                {
                    EmpWithDeptWithShift detailEmp = new EmpWithDeptWithShift();
                    detailEmp.ID = emp.ID;
                    detailEmp.First_Name = emp.First_Name;
                    detailEmp.Last_Name = emp.Last_Name;
                    detailEmp.Start_Work_Year = emp.Start_work_year;
                    List<Department> empDept = db.Departments.Where(d => d.ID == emp.DepartmentID).ToList();
                    foreach (Department dept in db.Departments)
                    {
                        if (dept.ID == emp.DepartmentID)
                        {
                            detailEmp.Department = dept.Name;
                        }
                    }
                    List<EmployeesShift> shifts = db.EmployeesShifts.Where(d => d.EmployeeID != emp.ID).ToList();
                    List<Shift> shifts1 = new List<Shift>();
                    foreach (EmployeesShift emp2Shift in shifts)
                    {
                        shifts1 = db.Shifts.Where(s => s.ID == emp2Shift.ShiftID).ToList();
                    }
                    List<Shifts4Emps> detShift = new List<Shifts4Emps>();
                    foreach (Shift shis in shifts1)
                    {
                        Shifts4Emps DetailShift = new Shifts4Emps();
                        DetailShift.Date = shis.Date;
                        DetailShift.Start_Time = shis.Start_Time;
                        DetailShift.End_Time = shis.End_Time;
                        detShift.Add(DetailShift);
                    }
                    detailEmp.Shift = detShift;
                    emps.Add(detailEmp);
                }
            }
            return emps;
        }
        public List<EmpWithDeptWithShift> GetEmployeeByDept(int departmentID)
        {
            List<EmpWithDeptWithShift> employees = new List<EmpWithDeptWithShift>();

            foreach (Employee emp in db.Employees.Where(x => x.DepartmentID == departmentID))
            {
                EmpWithDeptWithShift detailEmp = new EmpWithDeptWithShift();
                detailEmp.ID = emp.ID;
                detailEmp.First_Name = emp.First_Name;
                detailEmp.Last_Name = emp.Last_Name;
                detailEmp.Start_Work_Year = emp.Start_work_year;
                List<Department> empDept = db.Departments.Where(d => d.ID == emp.DepartmentID).ToList();
                foreach (Department dept in db.Departments)
                {
                    if (dept.ID == emp.DepartmentID)
                    {
                        detailEmp.Department = dept.Name;
                    }
                }
                List<EmployeesShift> shifts = db.EmployeesShifts.Where(d => d.EmployeeID != emp.ID).ToList();
                List<Shift> shifts1 = new List<Shift>();
                foreach (EmployeesShift emp2Shift in shifts)
                {
                    shifts1 = db.Shifts.Where(s => s.ID == emp2Shift.ShiftID).ToList();
                }
                List<Shifts4Emps> detShift = new List<Shifts4Emps>();
                foreach (Shift shis in shifts1)
                {
                    Shifts4Emps DetailShift = new Shifts4Emps
                    {
                        Date = shis.Date,
                        Start_Time = shis.Start_Time,
                        End_Time = shis.End_Time
                    };
                    detShift.Add(DetailShift);
                }
                detailEmp.Shift = detShift;
                employees.Add(detailEmp);
            }
            return employees;
        }
        public void AddEmployee(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
        }
        public void UpdateEmployee(int id, Employee employee)
        {

            Employee employee1 = db.Employees.Where(x => x.ID == id).First();
            employee1.First_Name = employee.First_Name;
            employee1.Last_Name = employee.Last_Name;
            employee1.Start_work_year = employee.Start_work_year;
            employee1.DepartmentID = employee.DepartmentID;

            db.SaveChanges();
        }
        public void DeleteEmployee(int ID)
        {
            Employee emp = db.Employees.Where(x => x.ID == ID).First();
            db.Employees.Remove(emp);
            db.SaveChanges();
        }
    }

}