namespace Market.Models
{
    public class User
    {
        public const int MIN_LOGIN_LENGHT = 4;
        public const int MAX_LOGIN_LENGHT = 16;

        public const int MIN_PASSWORD_LENGHT = 4;
        public const int MAX_PASSWORD_LENGHT = 16;


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
