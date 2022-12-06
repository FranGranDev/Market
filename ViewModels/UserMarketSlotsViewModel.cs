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
    public class UserMarketSlotsViewModel : ViewModelBase
    {
        public UserMarketSlotsViewModel(SlotsManager slotsManager, NavigationService reserveNavigationService, NavigationService backNavigationService)
        {
            this.slotsManager = slotsManager;
            this.reserveNavigationService = reserveNavigationService;
            BackCommand = new NavigateCommand(backNavigationService);

            slots = new ObservableCollection<MarketSlotViewModel>();

            UpdateSlots();
            slotsManager.OnMarketItemsListChanged += UpdateSlots;
        }

        private readonly SlotsManager slotsManager;
        private readonly NavigationService reserveNavigationService;
        private readonly ObservableCollection<MarketSlotViewModel> slots;

        public ObservableCollection<MarketSlotViewModel> Slots => slots;


        public void UpdateSlots()
        {
            Slots.Clear();

            foreach (MarketSlot slot in slotsManager.Slots)
            {
                Slots.Add(new MarketSlotViewModel(slot, null, null, BuySlot));
            }
        }

        private void BuySlot(MarketSlot slot)
        {
            reserveNavigationService.Navigate(slot);
        }


        public ICommand CreateCommand { get; }
        public ICommand BackCommand { get; }
    }
}
