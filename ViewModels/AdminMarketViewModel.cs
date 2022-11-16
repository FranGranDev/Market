using Market.Commands;
using Market.Models.Users;
using Market.Services;
using Market.Stores;
using Market.Models.Items;
using System;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Market.ViewModels
{
    public class AdminMarketViewModel : ViewModelBase
    {
        public AdminMarketViewModel(SlotsManager slotsManager, NavigationService backNavigationService, NavigationService createNewNavigationService)
        {
            this.slotsManager = slotsManager;


            CreateCommand = new NavigateCommand(createNewNavigationService);
            BackCommand = new NavigateCommand(backNavigationService);

            slots = new ObservableCollection<MarketSlotViewModel>();
            UpdateSlots();
        }

        private readonly SlotsManager slotsManager;
        private readonly ObservableCollection<MarketSlotViewModel> slots;

        public ObservableCollection<MarketSlotViewModel> Slots => slots;


        public void UpdateSlots()
        {
            Slots.Clear();

            foreach(MarketSlot slot in slotsManager.Slots)
            {
                Slots.Add(new MarketSlotViewModel(slot));
            }
        }


        public ICommand CreateCommand { get; }
        public ICommand BackCommand { get; }
    }
}
