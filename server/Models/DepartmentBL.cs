//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace The_Factory.Models
//{
//    public class DepartmentBL
//    {
//            private FactoryEntities3 db = new FactoryEntities3();

//            public List<Department> GetDepartments()
//            {
//                List<Department> departments = new List<Department>();
//                foreach (Department department in db.Departments)
//                {
//                    Department detailDept = new Department();
//                    detailDept.ID = department.ID;
//                    detailDept.Name = department.Name;
//                    department.Employee = db.Employees.Where(x => x.ID == department.Manager).First();
//                    detailDept.Manager = department.Employee.ID;
//                    List<Employee> employees = new List<Employee>();
//                    foreach (Employee employee in db.Employees.Where(x => x.DepartmentID == department.ID))
//                    {
//                        Employee employee1 = new Employee();
//                        employee1.ID = employee.ID;
//                        employee1.First_Name = employee.First_Name;
//                        employee1.Last_Name = employee.Last_Name;
//                        employee1.Start_work_year = employee.Start_work_year;
//                        employee1.DepartmentID = department.ID;
//                        employees.Add(employee1);

//                    }
//                    detailDept.Employees = employees;
//                    departments.Add(detailDept);
//                }
//                return departments;

//            }
//            public Department GetDepartment(int id)
//            {
//                List<Department> departments = new List<Department>();
//                foreach (Department department in db.Departments)
//                {
//                    Department detailDept = new Department();
//                    detailDept.ID = department.ID;
//                    detailDept.Name = department.Name;
//                    department.Employee = db.Employees.Where(x => x.ID == department.Manager).First();
//                    detailDept.Manager = department.Employee.ID;
//                    List<Employee> employees = new List<Employee>();
//                    foreach (Employee employee in db.Employees.Where(x => x.DepartmentID == department.ID))
//                    {
//                        Employee employee1 = new Employee();
//                        employee1.ID = employee.ID;
//                        employee1.First_Name = employee.First_Name;
//                        employee1.Last_Name = employee.Last_Name;
//                        employee1.Start_work_year = employee.Start_work_year;
//                        employee1.DepartmentID = department.ID;
//                        employees.Add(employee1);

//                    }
//                    detailDept.Employees = employees;
//                    departments.Add(detailDept);
//                }
//                return departments.Where(x => x.ID == id).First();
//            }
//            public Department GetDepartmentByName(string name)
//            {
//                List<Department> departments = new List<Department>();
//                foreach (Department department in db.Departments)
//                {
//                    Department detailDept = new Department();
//                    detailDept.ID = department.ID;
//                    detailDept.Name = department.Name;
//                    detailDept.Manager = db.Employees.Where(x => x.ID == department.Manager).First().ID;
//                    detailDept.Employees = new List<Employee>();
//                    foreach (Employee employee in db.Employees.Where(y => y.DepartmentID == department.ID))
//                    {
//                        Employee detailEmployee = new Employee();
//                        detailEmployee.ID = employee.ID;
//                        detailDept.Employees.Add(detailEmployee);
//                    }
//                    departments.Add(detailDept);
//                }
//                return departments.Where(x => x.Name == name).First();
//            }
//            public void AddDepartment(Department department)
//            {
//                db.Departments.Add(department);

//                db.SaveChanges();
//            }

//            public void UpdateDepartment(int ID, Department department)
//            {
//                Department dept = new Department();
//                Department depar = db.Departments.Where(x => x.ID == ID).First();
//                dept.Name = depar.Name;
//                dept.Manager = depar.Manager;
//                dept.Employees = new List<Employee>();
//                foreach (Employee employee in db.Employees.Where(y => y.DepartmentID == depar.ID))
//                {
//                    Employee detailEmployee = new Employee();
//                    detailEmployee.ID = employee.ID;
//                    dept.Employees.Add(detailEmployee);
//                }
//                db.SaveChanges();
//            }
//            public void DeleteDepartment(int ID)
//            {
//                Department department = db.Departments.Where(x => x.ID == ID).First();
//                db.Departments.Remove(department);
//                db.SaveChanges();
//            }
//        }
//    }
