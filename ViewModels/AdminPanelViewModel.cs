using System.Windows.Input;
using Market.Commands;
using Market.Models.Users;
using Market.Stores;
using Market.Services;
using System;


namespace Market.ViewModels
{
    public class AdminPanelViewModel : ViewModelBase
    {
        public AdminPanelViewModel(UsersManager usersManager, NavigationService userListNavigationService, NavigationService marketNavigationService, NavigationService reservationsNavigationService, NavigationService backNavigationService)
        {
            MarketCommand = new NavigateCommand(marketNavigationService);
            ReservationCommand = new NavigateCommand(reservationsNavigationService);
            UserListCommand = new NavigateCommand(userListNavigationService);
            BackCommand = new LogOutCommand(usersManager, backNavigationService);
        }

        public ICommand UserListCommand { get; }
        public ICommand MarketCommand { get; }
        public ICommand ReservationCommand { get; }
        public ICommand BackCommand { get; }
    }
}
