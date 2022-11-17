﻿using Market.Commands;
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
        public UserMarketSlotsViewModel(SlotsManager slotsManager, NavigationService backNavigationService)
        {
            this.slotsManager = slotsManager;

            BackCommand = new NavigateCommand(backNavigationService);

            slots = new ObservableCollection<MarketSlotViewModel>();

            UpdateSlots();
            slotsManager.OnItemsListChanged += UpdateSlots;
        }

        private readonly SlotsManager slotsManager;
        private readonly ObservableCollection<MarketSlotViewModel> slots;

        public ObservableCollection<MarketSlotViewModel> Slots => slots;


        public void UpdateSlots()
        {
            Slots.Clear();

            foreach (MarketSlot slot in slotsManager.Slots)
            {
                Slots.Add(new MarketSlotViewModel(slot, null, null));
            }
        }


        public ICommand CreateCommand { get; }
        public ICommand BackCommand { get; }
    }
}
