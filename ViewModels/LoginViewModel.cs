using Market.Commands;
using Market.Models.Users;
using Market.Services;
using Market.Stores;
using System;
using System.Windows.Input;


namespace Market.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel(UsersManager usersManager, NavigationService adminNavigationService, NavigationService userNavigationService, NavigationService backNavigationService)
        {
            LogInCommand = new LogInCommand(this, adminNavigationService, userNavigationService, usersManager);
            BackCommand = new NavigateCommand(backNavigationService);
        }

        private string login;
        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LogInCommand { get; }
        public ICommand BackCommand { get; }
    }
}
