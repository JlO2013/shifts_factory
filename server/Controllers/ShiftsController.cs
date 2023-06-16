using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using The_Factory.Models;
using TheFactory.Models;

namespace TheFactory.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ShiftsController : ApiController
    {
        private ShiftsBL shiftsBL = new ShiftsBL();
        private EmployesShiftsBL employesShiftsBL = new EmployesShiftsBL();
        // GET: api/Shifts
        public IEnumerable<Shifts> Get()
        {
            return shiftsBL.GetShifts();
        }

        // GET: api/Shifts/5
        public Shifts Get(int id)
        {
            return shiftsBL.GetShift(id);
        }
        public List<Shifts4Emps> GetShiftsByEmp(int empsID)
        {
            return shiftsBL.GetShiftsByEmp(empsID);
        }

        // POST: api/Shifts
        public string Post(Shift shift)
        {
            shiftsBL.AddShift(shift);
            return "New shift created!";

        }

        // PUT: api/Shifts/5
        public string Put(int ID, EmployeesShift shift)
        {
            employesShiftsBL.AddShiftToEmp(shift);
            employesShiftsBL.UpdateShift(shift.ID, shift);

            return "Shift had been updated!";
        }

        // DELETE: api/Shifts/5
        public void Delete(int id)
        {
        }
    }
}
