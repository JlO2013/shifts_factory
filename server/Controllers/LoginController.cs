using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using The_Factory.Models;

namespace The_Factory.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        private LoginBL LoginBL = new LoginBL();
        // GET: api/Login/5
        public IEnumerable<User> GetUsers()
        {
            return LoginBL.GetUsers();
        }
        public IEnumerable<User> GetByUsername(string username)
        {
            return LoginBL.GetByUsername(username);
        }

    }
}
