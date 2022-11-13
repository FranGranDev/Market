using Market.Models.Exceptions;
using Market.Models.Users;
using Market.ViewModels;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;


namespace Market.Commands
{
    class RegistrateCommand : CommandBase
    {
        private readonly UsersManager usersManager;
        private readonly RegistrationViewModel registrationViewModel;

        public RegistrateCommand(RegistrationViewModel registrationViewModel, UsersManager usersManager)
        {
            this.registrationViewModel = registrationViewModel;
            this.usersManager = usersManager;

            registrationViewModel.PropertyChanged += OnViewModelChange;
        }

        public override void Execute(object parameter)
        {
            try
            {
                usersManager.RegistrateNew(registrationViewModel.Login, registrationViewModel.Password);
            }
            catch (NoUserFindedException)
            {
                MessageBox.Show("User not founded", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (InvalidLoginOrPasswordException)
            {
                MessageBox.Show("Invalid login or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override bool CanExecute(object parameter)
        {
            bool canExecute = base.CanExecute(parameter);

            canExecute = canExecute && !string.IsNullOrEmpty(registrationViewModel.Login) && registrationViewModel.Login.Length >= UsersManager.MIN_LOGIN_LENGHT && registrationViewModel.Login.Length <= UsersManager.MAX_LOGIN_LENGHT;
            canExecute = canExecute && !string.IsNullOrEmpty(registrationViewModel.Password) && registrationViewModel.Password.Length >= UsersManager.MIN_PASSWORD_LENGHT && registrationViewModel.Password.Length <= UsersManager.MAX_PASSWORD_LENGHT;
            canExecute = canExecute && !string.IsNullOrEmpty(registrationViewModel.Confirm) && registrationViewModel.Confirm == registrationViewModel.Password;

            return canExecute;
        }


        private void OnViewModelChange(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(RegistrationViewModel.Login) ||
                e.PropertyName == nameof(RegistrationViewModel.Password) ||
                e.PropertyName == nameof(RegistrationViewModel.Confirm))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
