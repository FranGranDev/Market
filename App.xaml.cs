using Market.Models.Users;
using Market.Stores;
using Market.View;
using Market.Services;
using Market.ViewModels;
using System;
using System.Windows;


namespace Market
{
    public partial class App : Application
    {
        private readonly UsersManager usersManager;
        private readonly NavigationStore navigationStore;

        public App()
        {
            usersManager = new UsersManager();
            navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            navigationStore.CurrantViewModel = CreateStartViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private StartViewModel CreateStartViewModel()
        {
            return new StartViewModel(new NavigationService(navigationStore, CreateRegistrationViewModel), new NavigationService(navigationStore, CreateUserListViewModel));
        }

        private RegistrationViewModel CreateRegistrationViewModel()
        {
            return new RegistrationViewModel(usersManager, new NavigationService(navigationStore, CreateStartViewModel));
        }

        private LoginViewModel CreateLoginViewModel()
        {
            return new LoginViewModel(usersManager, new NavigationService(navigationStore, CreateStartViewModel));
        }

        private UserListViewModel CreateUserListViewModel()
        {
            return new UserListViewModel(usersManager, new NavigationService(navigationStore, CreateStartViewModel));
        }

    }
}
