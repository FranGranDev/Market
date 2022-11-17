using Market.Models.Users;
using Market.Commands;
using Market.Services;
using System;
using System.Windows.Input;


namespace Market.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        public RegistrationViewModel(UsersManager usersManager, NavigationService backNavigationService, NavigationService userPanelNavigationService)
        {
            RegistrateCommand = new RegistrateCommand(this, usersManager, userPanelNavigationService);

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

        private string confirm;
        public string Confirm
        {
            get
            {
                return confirm;
            }
            set
            {
                confirm = value;
                OnPropertyChanged(nameof(Confirm));
            }
        }

        public ICommand RegistrateCommand { get; }
        public ICommand BackCommand { get; }
    }
}
