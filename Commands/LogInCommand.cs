using Market.Models.Users;
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

        public LogInCommand(LoginViewModel loginViewModel, UsersManager usersManager)
        {
            this.loginViewModel = loginViewModel;
            this.usersManager = usersManager;

            loginViewModel.PropertyChanged += OnViewModelChange;
        }

        public override void Execute(object parameter)
        {
            try
            {
                usersManager.LogIn(loginViewModel.Login, loginViewModel.Password);
            }
            catch(NoUserFindedException)
            {
                MessageBox.Show("User not founded", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(InvalidLoginOrPasswordException)
            {
                MessageBox.Show("Invalid login or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
