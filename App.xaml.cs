using Market.Models.Users;
using Market.Models.Data;
using Market.Models.Items;
using Market.Stores;
using Market.View;
using Market.Services;
using Market.ViewModels;
using Market.ViewModels.Factory;
using System;
using System.Windows;


namespace Market
{
    public partial class App : Application
    {
        private readonly UsersManager usersManager;
        private readonly NavigationStore navigationStore;
        private readonly ViewModelFactory viewModelFactory;
        private readonly DataBase dataBase;


        public App()
        {
            dataBase = new DataBase();
            usersManager = new UsersManager(dataBase);
            navigationStore = new NavigationStore();
            viewModelFactory = new ViewModelFactory(usersManager, navigationStore);

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            navigationStore.CurrantViewModel = viewModelFactory.CreateStartViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
