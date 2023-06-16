using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using The_Factory.Models;

namespace TheFactory.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeesController : ApiController
    {
        private EmployeesBL employeesBL = new EmployeesBL();
        private EmployesShiftsBL EmployesShiftsBL = new EmployesShiftsBL();
        // GET: api/Employees
        public IEnumerable<EmpWithDeptWithShift> Get()
        {
            return employeesBL.GetEmplyees();
        }

        // GET: api/Employees/5
        public EmpWithDeptWithShift Get(int id)
        {
            return employeesBL.GetEmployee(id);
        }

        public IEnumerable<EmpWithDeptWithShift> Get(string name)
        {
            return employeesBL.GetEmployeeByFirst_Name(name);
        }
        public IEnumerable<EmpWithDeptWithShift> GetDept(int departmentID)
        {
            return employeesBL.GetEmployeeByDept(departmentID);
        }

        // POST: api/Employees
        public string Post(Employee empl)
        {
            employeesBL.AddEmployee(empl);
            return "Created with ID: " + empl.ID;

        }

        // PUT: api/Employees/5
        public string Put(int id, Employee employee)
        {
            employeesBL.UpdateEmployee(id, employee);
            return " details had been updated!";
        }

        // DELETE: api/Employees/5
        public string Delete(int ID)
        {
            EmployesShiftsBL.DeleteShift(ID);

            employeesBL.DeleteEmployee(ID);
            return "Employee had been deleted and shifts had been updated!";
        }

    }
}
