using System.Collections.Generic;
using System.Linq;

namespace The_Factory.Models
{
    public class LoginBL
    {
        Factory_ProjectEntities db = new Factory_ProjectEntities();
        
        public List<User> GetUsers()
        {
            List<User> users = db.Users.ToList();
            return users;
        }
        
        public List<User> GetByUsername(string Username)
        {
            return db.Users.Where(x => x.Username == Username).ToList();
        }
    }
}