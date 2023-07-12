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

    public class LoginController : ApiController
    {
        private LoginsBL LoginsBL = new LoginsBL();
        // GET api/<controller>/5
        public Users Get(string username)
        {
            return LoginsBL.GetUserByName(username);
        }
    }
}