using System.Windows.Input;
using Market.Commands;
using Market.Models.Users;
using Market.Stores;
using Market.Services;
using System;


namespace Market.ViewModels
{
    public class UserPanelViewModel : ViewModelBase
    {
        public UserPanelViewModel(UsersManager usersManager, NavigationService marketNavigationService, NavigationService backNavigationService)
        {
            MarketCommand = new NavigateCommand(marketNavigationService);
            BackCommand = new LogOutCommand(usersManager, backNavigationService);
        }

        public ICommand UserListCommand { get; }
        public ICommand MarketCommand { get; }
        public ICommand BackCommand { get; }
    }
}
