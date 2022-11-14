using Market.Models.Users;
using Market.Services;
using Market.Models.Exceptions;
using Market.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System;

namespace Market.Commands
{
    public class LogInCommand : CommandBase
    {
        private readonly UsersManager usersManager;
        private readonly LoginViewModel loginViewModel;
        private readonly NavigationService adminNavigationService;
        private readonly NavigationService userNavigationService;

        public LogInCommand(LoginViewModel loginViewModel, NavigationService adminNavigationService, NavigationService userNavigationService, UsersManager usersManager)
        {
            this.loginViewModel = loginViewModel;
            this.usersManager = usersManager;

            this.adminNavigationService = adminNavigationService;
            this.userNavigationService = userNavigationService;

            loginViewModel.PropertyChanged += OnViewModelChange;
        }

        public override void Execute(object parameter)
        {
            try
            {
                usersManager.LogIn(loginViewModel.Login, loginViewModel.Password);

                if(usersManager.Currant.IsAdmin)
                {
                    adminNavigationService.Navigate();
                }
                else
                {
                    adminNavigationService.Navigate();
                }
            }
            catch(NoUserFindedException)
            {
                MessageBox.Show("User not founded", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(InvalidLoginOrPasswordException)
            {
                MessageBox.Show("Invalid login or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch
            {
                MessageBox.Show("Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override bool CanExecute(object parameter)
        {
            if (loginViewModel == null)
                return false;

            bool canExecute = base.CanExecute(parameter);

            canExecute = canExecute && !string.IsNullOrEmpty(loginViewModel.Login);
            canExecute = canExecute && !string.IsNullOrEmpty(loginViewModel.Password);

            return canExecute;
        }

        private void OnViewModelChange(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(LoginViewModel.Login) ||
               e.PropertyName == nameof(LoginViewModel.Password))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
