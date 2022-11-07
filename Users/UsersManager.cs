using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Users
{
    class UsersManager
    {
        public UsersManager()
        {
            users = new List<User>()
            {
                new User("admin", "admin")
            };
        }

        private List<User> users;


        public void RegistrateNew(string login, string password)
        {

        }

        public User LogIn(string login, string password)
        {
            

            return null;
        }
    }
}
