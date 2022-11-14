using System;
using Market.Services;
using Market.Models.Users;

namespace Market.Commands
{
    public class LogOutCommand : CommandBase
    {
        private readonly NavigationService backNavigationService;
        private readonly UsersManager usersManager;

        public LogOutCommand(UsersManager usersManager, NavigationService backNavigationService)
        {
            this.usersManager = usersManager;
            this.backNavigationService = backNavigationService;
        }

        public override void Execute(object parameter)
        {
            usersManager.LogOut();
            backNavigationService.Navigate();
        }
    }
}
