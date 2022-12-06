using System;
using Market.Models.Items;
using Market.Models.Users;
using Market.Services;
using Market.Commands;
using System.Windows.Input;


namespace Market.ViewModels
{
    public class MakeReservationViewModel : ViewModelBase
    {
        public MakeReservationViewModel(UsersManager usersManager, SlotsManager slotsManager, MarketSlot slot, NavigationService backNavigationService)
        {
            this.slot = slot;

            ReserveCommand = new ReserveCommand(this, usersManager, slotsManager, slot, backNavigationService);
            BackCommand = new NavigateCommand(backNavigationService);
        }

        private readonly MarketSlot slot;

        private string name;
        private string surname;
        private string phone;

        public string Model
        {
            get { return slot.Item.Model; }
            set
            {

            }
        }
        public string Brand
        {
            get { return slot.Item.Brand; }
            set
            {

            }
        }
        public int FinalCost
        {
            get { return slot.Cost.FinalCost; }
            set
            {

            }
        }


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
