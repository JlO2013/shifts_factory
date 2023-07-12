using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fatcory_Shifts.Models
{
    public class EmployeeBL
    {
        private New_factory_shiftsEntities db = new New_factory_shiftsEntities();
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            foreach (employees employee in db.employees)
            {
                Employee emp = new Employee();
                emp.ID = employee.ID;
                emp.FirstName = employee.FirstName;
                emp.LastName = employee.LastName;
                emp.StartWorkYear = employee.StartWorkYear;
                 Departments department = db.Departments.Where(x => x.ID == employee.DepartmentID).First();
                emp.DepartmentID = department.Name;
                List<Shifts> shifts= new List<Shifts>();
                foreach(EmployeeShift shift in db.EmployeeShift.Where(y => y.EmployeeID == employee.ID)) 
                {
                    foreach(Shifts shif in db.Shifts.Where(x => x.ID == shift.ShiftID))
                    {
                        Shifts shi = new Shifts();
                        shi.ID = shif.ID;
                        shi.Date = shif.Date;
                        shi.StartTime = shif.StartTime;
                        shi.EndTime = shif.EndTime;
                        shifts.Add(shi);
                    }
                }
                emp.Shifts = shifts;

                employees.Add(emp);
            }
            return employees;
        }
        public Employee GetEmployee(int ID)
        {
            Employee emp = new Employee();
            employees employee = db.employees.Where(x => x.ID == ID).First();
            emp.ID = employee.ID;
            emp.FirstName = employee.FirstName;
            emp.LastName = employee.LastName;
            emp.StartWorkYear = employee.StartWorkYear;
            emp.DepartmentID = db.Departments.Where(x => x.ID == employee.DepartmentID).First().Name;
            List<Shifts> shifts = new List<Shifts>();
            foreach (EmployeeShift shift in db.EmployeeShift)
            {
                foreach (Shifts shif in db.Shifts.Where(x => x.ID == shift.ShiftID))
                {
                    shifts.Add(shif);
                }
            }
            emp.Shifts = shifts;
            return emp;


        }
        public Employee GetEmployeeByName(string name)
        {
            Employee employee = new Employee();
            employees emp = db.employees.Where(x => x.LastName.Contains(name)).First();
            employee.ID = emp.ID;
            employee.FirstName = emp.FirstName;
            employee.LastName = emp.LastName;
            employee.StartWorkYear = emp.StartWorkYear;
            employee.DepartmentID = db.Departments.Where(x => x.ID == emp.DepartmentID).First().Name;
            List<Shifts> shifts = new List<Shifts>();
            foreach (EmployeeShift shift in db.EmployeeShift)
            {
                foreach (Shifts shif in db.Shifts.Where(x => x.ID == shift.ShiftID))
                {
                    shifts.Add(shif);
                }
            }
            employee.Shifts = shifts;
            return employee;
        }
        public void addEmployee(employees employee)
        {
            db.employees.Add(employee);
            db.SaveChanges();
        }
        public void updateEmployee(int id, employees employee)
        {
            employees emp = db.employees.Where(x => x.ID == id).First();
            emp.FirstName = employee.FirstName;
            emp.LastName = employee.LastName;
            emp.StartWorkYear = employee.StartWorkYear;
            List<Departments> depts = db.Departments.ToList();

            Departments dept = depts.Where(x => x.ID == emp.DepartmentID).Single();
            emp.DepartmentID = dept.ID;
            emp.DepartmentID = employee.DepartmentID;
            db.SaveChanges();
        }
        public void deleteEmployee(int id)
        {
            employees employee = db.employees.Where(x =>x.ID == id).First();
            db.employees.Remove(employee);
            db.SaveChanges();
        }
    }
}