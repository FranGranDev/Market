using Market.Models.Users;


namespace Market.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        public UserViewModel(User user)
        {
            this.user = user;
        }

        private readonly User user;


        public string Login => user.Login.ToString();
        public string State => user.UserState.ToString();
    }
}
