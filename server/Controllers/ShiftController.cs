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

    public class ShiftController : ApiController
    {
        private ShiftBL shiftBL = new ShiftBL();
        private EmployeeShiftsBL EmployeeShiftsBL = new EmployeeShiftsBL();
        // GET api/<controller>
        public IEnumerable<Shift> Get()
        {
            return shiftBL.GetShifts();
        }

        // GET api/<controller>/5
        public Shift Get(int id)
        {
            return shiftBL.GetShift(id);
        }

        // POST api/<controller>
        public string Post(Shifts shift)
        {
            shiftBL.AddShift(shift);
            return "Shift added!";
        }

        public string Put(EmployeeShift employeeShift)
        {
            EmployeeShiftsBL.AddShift2Employee(employeeShift);
            EmployeeShiftsBL.UpdateShift(employeeShift.ID, employeeShift);

            return "Shift had been updated!";
        }
    }
}