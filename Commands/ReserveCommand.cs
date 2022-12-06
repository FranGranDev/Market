using System;
using Market.Models.Items;
using Market.ViewModels;
using Market.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Commands
{
    public class ReserveCommand : CommandBase
    {
        public ReserveCommand(ReservationViewModel reservationViewModel, SlotsManager slotsManager, MarketSlot marketSlot, NavigationService backNavigationService)
        {
            this.slotsManager = slotsManager;
            this.marketSlot = marketSlot;
            this.reservationViewModel = reservationViewModel;

            reservationViewModel.PropertyChanged += OnViewModelPropertuChanged;
        }


        private readonly MarketSlot marketSlot;
        private readonly SlotsManager slotsManager;
        private readonly ReservationViewModel reservationViewModel;
        private readonly NavigationService backNavigationService;


        private void OnViewModelPropertuChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(reservationViewModel.Name) && !string.IsNullOrEmpty(reservationViewModel.Surname);
        }
        
        public override void Execute(object parameter)
        {


            backNavigationService.Navigate();
        }
    }
}
