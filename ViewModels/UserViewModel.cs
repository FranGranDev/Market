using Market.Models.Users;
using Market.Commands;
using System;
using System.Windows.Input;


namespace Market.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        public UserViewModel(User user, Action<UserViewModel> onUserDeleted)
        {
            this.user = user;
            
            DeleteCommand = new ActionCommand(() => onUserDeleted?.Invoke(this));
        }

        private readonly User user;

        public string Login => user.Login;
        public string State => user.UserState.ToString();


        private ICommand DeleteCommand { get; }
    }
}
