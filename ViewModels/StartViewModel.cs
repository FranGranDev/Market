using System.Windows.Input;
using Market.Commands;
using Market.Stores;
using Market.Services;
using System;


namespace Market.ViewModels
{
    public class StartViewModel : ViewModelBase
    {
        public StartViewModel(NavigationService registartionNavigationService, NavigationService loginNavigationService)
        {
            LoginCommand = new NavigateCommand(loginNavigationService);
            RegistrationCommand = new NavigateCommand(registartionNavigationService);
            ExitCommand = new ExitAppCommand();
        }

        public ICommand LoginCommand { get; }
        public ICommand RegistrationCommand { get; }
        public ICommand ExitCommand { get; }
    }
}
