using System;
using Market.Models.Items;
using Market.Services;
using Market.Commands;
using System.Windows.Input;


namespace Market.ViewModels
{
    public class MarketSlotCreationViewModel : ViewModelBase
    {
        public MarketSlotCreationViewModel(SlotsManager slotsManager, NavigationService backNavigationService)
        {
            CreateCommand = new CreateSlotCommand(this, slotsManager, backNavigationService);
            BackCommand = new NavigateCommand(backNavigationService);
        }


        private string model;
        private string brand;
        private DateTime release;
        private int baseCost;
        private double sale;
        private int count;


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
        public int BaseCost
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
        public double Sale
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
        public int Count
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


        public ICommand CreateCommand { get; }
        public ICommand BackCommand { get; }
    }
}
