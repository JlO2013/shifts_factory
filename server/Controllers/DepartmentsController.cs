using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using The_Factory.Models;

namespace TheFactory.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class DepartmentsController : ApiController
    {
        private DepartmentsBL DepartmentsBL = new DepartmentsBL();
        // GET: api/Departments
        public IEnumerable<Department> Get()
        {
            return DepartmentsBL.GetDepartments();
        }

        // GET: api/Departments/5
        public Department Get(int id)
        {
            return DepartmentsBL.GetDepartment(id);
        }
        public Department Get(string name)
        {
            return DepartmentsBL.GetDepartmentByName(name);
        }
        // POST: api/Departments
        public string Post(Department department)
        {
            DepartmentsBL.AddDepartment(department);
            return "New department created!";
        }

        // PUT: api/Departments/5
        public string Put(Department department, int ID)
        {
            DepartmentsBL.UpdateDepartment(department, ID);
            return "Department updated!";
        }

        // DELETE: api/Departments/5
        public string Delete(int id)
        {
            DepartmentsBL.DeleteDepartment(id);
            return "Department had been deleted!";
        }
    }
}
