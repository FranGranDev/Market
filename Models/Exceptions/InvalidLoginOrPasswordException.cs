using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Models.Exceptions
{
    public class InvalidLoginOrPasswordException : Exception
    {
        private string login;
        public string Login => login;

        public InvalidLoginOrPasswordException(string login)
        {
            this.login = login;
        }
    }
}
