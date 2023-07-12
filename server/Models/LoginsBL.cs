using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fatcory_Shifts.Models
{
    public class LoginsBL
    {
        private New_factory_shiftsEntities db = new New_factory_shiftsEntities();

        public Users GetUserByName(string username)
        {
            return db.Users.Where(x => x.Username == username).First();
        }
    }
}