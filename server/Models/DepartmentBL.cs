using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fatcory_Shifts.Models
{
    public class DepartmentBL
    {
        private New_factory_shiftsEntities db = new New_factory_shiftsEntities();
        public List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();
            foreach (Departments department in db.Departments)
            {
                Department depart = new Department();
                depart.Id = department.ID;
                depart.Name = department.Name;
                employees employee = db.employees.Where(x => x.ID == department.Manager).First();
                var managerName = string.Join(" ", employee.FirstName, employee.LastName);
                depart.Manager = managerName;

                departments.Add(depart);
            }
            return departments;
        }
        public Department GetDepartment(int id)
        {
            Department department1 = new Department();
            foreach (Departments department in db.Departments)
            {
                if (department.ID == id)
                {
                    department1.Id = id;
                    department1.Name = department.Name;
                    employees employee = db.employees.Where(x => x.ID == department.Manager).First();
                    var managerName = string.Join(" ", employee.FirstName, employee.LastName);
                    department1.Manager = managerName;
                }
            }
            return department1;
        }
        public  void addDepartment(Departments department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
        }
        public void updateDepatment(int id, Department department)
        {
            Departments depar = db.Departments.Where(x => x.ID == id).First();
            depar.ID = id;
            depar.Name = department.Name;
            var ManagerID = db.employees.Where(x => x.FirstName + " " + x.LastName == department.Manager).First().ID;
            depar.Manager = ManagerID;

            db.SaveChanges();
        }
        public void deleteDepartment(int id)
        {
            Departments department = db.Departments.Where(x =>x.ID == id).First();
            db.Departments.Remove(department);
            db.SaveChanges();
        }
    }
}