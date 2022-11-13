namespace Market.Models.Users
{
    public class Admin : User
    {
        public Admin(string login, string password) : base(login, password)
        {

        }

        public override bool IsAdmin => true;
        public override UserStates UserState
        {
            get => UserStates.Active;
            set => throw new System.Exception("Can't change admin state");
        }
    }
}
