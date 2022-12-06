using Market.Commands;
using System.Linq;
using System.Collections.Generic;
using Market.Models.Users;
using Market.Services;
using Market.Stores;
using Market.Models.Items;
using System;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Market.ViewModels
{
    public class ReservationListViewModel : ViewModelBase
    {
        public ReservationListViewModel(SlotsManager slotsManager, NavigationService backNavigationService)
        {
            this.slotsManager = slotsManager;

            BackCommand = new NavigateCommand(backNavigationService);

            reservations = new ObservableCollection<ReservationViewModel>();

            UpdateReservations();

            slotsManager.OnReservationItemsListChanged += UpdateReservations;
        }

        private readonly SlotsManager slotsManager;
        private readonly ObservableCollection<ReservationViewModel> reservations;

        public ObservableCollection<ReservationViewModel> Reservations => reservations;


        public void UpdateReservations()
        {
            Reservations.Clear();

            List<ReservationData> data = slotsManager.Reservations;
            data = data.OrderBy(x => x.State).ToList();

            List<MarketSlot> slots = slotsManager.Slots;

            foreach (ReservationData reservation in data)
            {
                MarketSlot slot = slots.First(x => x.id == reservation.SlotId);
                Reservations.Add(new ReservationViewModel(reservation, slot, slotsManager.OverrideReservation, slotsManager.DeleteReservation));
            }
        }


        public ICommand CreateCommand { get; }
        public ICommand BackCommand { get; }
    }
}
