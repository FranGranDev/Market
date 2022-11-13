using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Market.Models.Users;
using Market.Services;
using Market.Commands;


namespace Market.ViewModels
{
    public class UserListViewModel : ViewModelBase
    {
        private readonly UsersManager usersManager;

        public UserListViewModel(UsersManager usersManager, NavigationService backNavigationService)
        {
            this.usersManager = usersManager;

            users = new ObservableCollection<UserViewModel>();

            BackCommand = new NavigateCommand(backNavigationService);

            UpdateUserList();
        }

        private readonly ObservableCollection<UserViewModel> users;

        public ObservableCollection<UserViewModel> Users => users;

        public ICommand BackCommand { get; }


        private void UpdateUserList()
        {
            users.Clear();

            foreach (User user in usersManager.Users)
            {
                users.Add(new UserViewModel(user));
            }
        }
    }
}
