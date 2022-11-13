using Market.Stores;
using Market.ViewModels;
using Market.Models;
using Market.Models.Users;
using Market.Services;
using System;

namespace Market.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly NavigationService navigationService;

        public NavigateCommand(NavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            navigationService.Navigate();
        }
    }
}
