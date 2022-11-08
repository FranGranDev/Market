using System;


namespace Market.Users
{
    public class User
    {
        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public string Login { get; private set; }
        private string Password { get; set; }


        public bool ComparePassword(string password)
        {
            return Password == password;
        }
    }
}
