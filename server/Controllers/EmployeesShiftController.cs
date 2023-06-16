//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using System.Web.Http.Cors;
//using The_Factory.Models;
//using TheFactory.Models;

//namespace The_Factory.Controllers
//{
//    [EnableCors(origins: "*", headers: "*", methods: "*")]
//    public class EmployeesShiftController : ApiController
//    {
//        private EmployesShiftsBL EmployeesShiftBL = new EmployesShiftsBL();
//        // GET: api/EmployeesShift
//        public IEnumerable<EmployeesShift> Get()
//        {
//            return EmployeesShiftBL.GetEmployee2Shifts();
//        }

//        // GET: api/EmployeesShift/5
//        public string Get(int EmployeeID)
//        {
//            EmployeesShiftBL.GetShiftsByEmp(EmployeeID);
//            return "List of Shifts by Employee";
//        }

//        public string GetShift(int EmployeeID)
//        {
//            EmployeesShiftBL.GetShift(EmployeeID);
//            return "List of Shifts by Employee";
//        }

//        // POST: api/EmployeesShift
//        public void Post(EmployeesShift shift)
//        {
//            EmployeesShiftBL.AddShift(shift);
//        }

//        // PUT: api/EmployeesShift/5
//        public void Put(int EmployeeID, EmployeesShift employees)
//        {
//            EmployeesShiftBL.UpdateShift(EmployeeID, employees);
//        }


//    }
//}
