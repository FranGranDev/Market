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
            //ReserveCommand = new ReserveCommand();
            BackCommand = new NavigateCommand(backNavigationService);
        }


        private string model;
        private string brand;
        private DateTime release = DateTime.Now;
        private string baseCost;
        private string sale;
        private string count;


        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
                OnPropertyChanged(nameof(Model));
            }
        }
        public DateTime Release
        {
            get
            {
                return release;
            }
            set
            {
                release = value;
                OnPropertyChanged(nameof(Release));
            }
        }
        public string Brand
        {
            get
            {
                return brand;
            }
            set
            {
                brand = value;
                OnPropertyChanged(nameof(Brand));
            }
        }
        public string BaseCost
        {
            get
            {
                return baseCost;
            }
            set
            {
                baseCost = value;
                OnPropertyChanged(nameof(BaseCost));
            }
        }
        public string Sale
        {
            get
            {
                return sale;
            }
            set
            {
                sale = value;
                OnPropertyChanged(nameof(Sale));
            }
        }
        public string Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
                OnPropertyChanged(nameof(Count));
            }
        }


        public ICommand ReserveCommand { get; }
        public ICommand BackCommand { get; }
    }
}
