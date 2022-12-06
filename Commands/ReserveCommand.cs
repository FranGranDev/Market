using System;
using Market.Models.Items;
using Market.Models.Users;
using Market.ViewModels;
using Market.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Market.Commands
{
    public class ReserveCommand : CommandBase
    {
        public ReserveCommand(MakeReservationViewModel reservationViewModel, UsersManager usersManager, SlotsManager slotsManager, MarketSlot marketSlot, NavigationService backNavigationService)
        {
            this.usersManager = usersManager;
            this.slotsManager = slotsManager;
            this.marketSlot = marketSlot;
            this.reservationViewModel = reservationViewModel;
            this.backNavigationService = backNavigationService;

            reservationViewModel.PropertyChanged += OnViewModelPropertuChanged;
        }


        private readonly MarketSlot marketSlot;
        private readonly UsersManager usersManager;
        private readonly SlotsManager slotsManager;
        private readonly MakeReservationViewModel reservationViewModel;
        private readonly NavigationService backNavigationService;


        private void OnViewModelPropertuChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(reservationViewModel.Name) && !string.IsNullOrEmpty(reservationViewModel.Surname) && !string.IsNullOrEmpty(reservationViewModel.Phone.ToString());
        }
        
        public override void Execute(object parameter)
        {
            if(marketSlot.Count <= 0)
            {
                MessageBox.Show("Product out of stock", "Order", MessageBoxButton.OK, MessageBoxImage.Warning);
                backNavigationService.Navigate();
                return;
            }
            string phoneStr = reservationViewModel.Phone;
            phoneStr = new string(phoneStr.Where(x => !char.IsWhiteSpace(x)).ToArray());

            slotsManager.MakeSlotReservation(new ReservationData(marketSlot.id, usersManager.Currant.Login, reservationViewModel.Name, reservationViewModel.Surname, Convert.ToInt64(phoneStr)));

            MessageBox.Show("Wait for manager call", "Phone ordered", MessageBoxButton.OK, MessageBoxImage.Information);

            backNavigationService.Navigate();
        }
    }
}
