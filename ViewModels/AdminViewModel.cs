using System.Windows.Input;
using Market.Commands;
using Market.Models.Users;
using Market.Stores;
using Market.Services;
using System;


namespace Market.ViewModels
{
    public class AdminViewModel : ViewModelBase
    {
        public AdminViewModel(UsersManager usersManager, NavigationService userListNavigationService, NavigationService backNavigationService)
        {
            UserListCommand = new NavigateCommand(userListNavigationService);
            BackCommand = new LogOutCommand(usersManager, backNavigationService);
        }

        public ICommand UserListCommand { get; }
        public ICommand MarketCommand { get; }
        public ICommand BackCommand { get; }
    }
}
