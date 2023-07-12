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

    public class DepartmentController : ApiController
    {
        private DepartmentBL DepartmentBL = new DepartmentBL();
        // GET api/<controller>
        public IEnumerable<Department> Get()
        {
            return DepartmentBL.GetDepartments();
        }

        // GET api/<controller>/5
        public Department Get(int id)
        {
            return DepartmentBL.GetDepartment(id);
        }

        // POST api/<controller>
        public string Post(Departments department)
        {
            DepartmentBL.addDepartment(department);
            return "New department created!";
        }

        // PUT api/<controller>/5
        public string Put(int id, Department department)
        {
            DepartmentBL.updateDepatment(id, department);
            return "Department updated!!";
        }

        // DELETE api/<controller>/5
        public string Delete(int id)
        {
            DepartmentBL.deleteDepartment(id);
            return "Department had been deleted!";
        }
    }
}