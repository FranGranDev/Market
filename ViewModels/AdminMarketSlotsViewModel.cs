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
    public class AdminMarketSlotsViewModel : ViewModelBase
    {
        public AdminMarketSlotsViewModel(SlotsManager slotsManager, NavigationService backNavigationService, NavigationService createNewNavigationService)
        {
            this.slotsManager = slotsManager;

            CreateCommand = new NavigateCommand(createNewNavigationService);
            BackCommand = new NavigateCommand(backNavigationService);

            slots = new ObservableCollection<MarketSlotViewModel>();

            UpdateSlots();
            slotsManager.OnMarketItemsListChanged += UpdateSlots;
        }

        private readonly SlotsManager slotsManager;
        private readonly ObservableCollection<MarketSlotViewModel> slots;

        public ObservableCollection<MarketSlotViewModel> Slots => slots;


        public void UpdateSlots()
        {
            Slots.Clear();

            foreach(MarketSlot slot in slotsManager.Slots)
            {
                Slots.Add(new MarketSlotViewModel(slot, slotsManager.OverrideSlot, slotsManager.DeleteSlot, null));
            }
        }


        public ICommand CreateCommand { get; }
        public ICommand BackCommand { get; }
    }
}
