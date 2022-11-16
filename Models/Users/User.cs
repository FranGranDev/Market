namespace Market.Models.Users
{
    public class User
    {
        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }


        private UserStates userState;


        public string Login { get; private set; }
        private string Password { get; set; }
        public virtual bool IsAdmin => false;
        public virtual UserStates UserState
        {
            get => userState;
            set => userState = value;
        }


        public bool ComparePassword(string password)
        {
            return Password == password;
        }


        public enum UserStates
        {
            Active,
            Blocked,
        }
    }
}
