using Fatcory_Shifts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;


namespace Fatcory_Shifts.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class EmployeeController : ApiController
    {
        private EmployeeBL EmployeeBL = new EmployeeBL();
        // GET api/<controller>
        public IEnumerable<Employee> Get()
        {
            return EmployeeBL.GetEmployees();
        }

        // GET api/<controller>/5
        public Employee Get(int id)
        {
            return EmployeeBL.GetEmployee(id);
        }

        public Employee Get(string name)
        {
            return EmployeeBL.GetEmployeeByName(name);
        }

        // POST api/<controller>
        public string Post(employees employee)
        {
            EmployeeBL.addEmployee(employee);
            return "Created with ID: " + employee.ID;
        }

        // PUT api/<controller>/5
        public string Put(int id, employees employee)
        {
            EmployeeBL.updateEmployee(id, employee);
            return "Employee details had been updated!";
        }

        // DELETE api/<controller>/5
        public string Delete(int id)
        {
            EmployeeBL.deleteEmployee(id);
            return "Employee had been deleted and shifts had been updated!";

        }
    }
}