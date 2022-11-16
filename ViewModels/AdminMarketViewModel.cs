using Market.Commands;
using Market.Models.Users;
using Market.Services;
using Market.Stores;
using Market.Models.Items;
using System;
using System.Windows.Input;


namespace Market.ViewModels
{
    public class AdminMarketViewModel : ViewModelBase
    {
        public AdminMarketViewModel(SlotsManager slotsManager, NavigationService backNavigationService, NavigationService createNewNavigationService)
        {
            this.slotsManager = slotsManager;


            CreateCommand = new NavigateCommand(createNewNavigationService);
            BackCommand = new NavigateCommand(backNavigationService);
        }

        private readonly SlotsManager slotsManager;

        public ICommand CreateCommand { get; }
        public ICommand BackCommand { get; }
    }
}
