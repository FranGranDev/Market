using System;
using Market.Models.Items;
using Market.Services;
using Market.Commands;
using System.Windows.Input;


namespace Market.ViewModels
{
    public class ReservationViewModel : ViewModelBase
    {
        public ReservationViewModel(SlotsManager slotsManager, MarketSlot slot, NavigationService backNavigationService)
        {

            ReserveCommand = new ReserveCommand(this, slotsManager, slot, backNavigationService);
            BackCommand = new NavigateCommand(backNavigationService);
        }


        private string name;
        private string surname;
        private string phone;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }


        public ICommand ReserveCommand { get; }
        public ICommand BackCommand { get; }
    }
}
