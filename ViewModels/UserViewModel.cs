using Market.Models.Users;
using Market.Commands;
using System;
using System.Windows.Input;
using System.Windows;

namespace Market.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        public UserViewModel(User user, Action<UserViewModel> onUserDeleted)
        {
            this.user = user;
            this.onUserDeleted = onUserDeleted;

            DeleteCommand = new ActionCommand(DeleteConfirm);
        }

        private readonly User user;
        private Action<UserViewModel> onUserDeleted;

        public string Login => user.Login;
        public string State => user.UserState.ToString();

        public ICommand DeleteCommand { get; }

        private void DeleteConfirm()
        {
            if (user.IsAdmin)
            {
                MessageBox.Show("Can't delete admin!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Are you sure?", "User delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    onUserDeleted?.Invoke(this);
                }
            }
        }
    }
}
