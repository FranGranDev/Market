using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Market.Models.Exceptions
{
    public class NoUserFindedException : Exception
    {
        private string login;
        public string Login => login;

        public NoUserFindedException(string login) : base(login)
        {
            this.login = login;
        }
    }
}
