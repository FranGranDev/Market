using System;
using Market.Services;
using Market.ViewModels;
using Market.Models.Items;
using System.ComponentModel;
using System.Windows;

namespace Market.Commands
{
    public class CreateSlotCommand : CommandBase
    {
        public CreateSlotCommand(MarketSlotCreationViewModel creationViewModel, SlotsManager slotsManager, NavigationService navigationService)
        {
            this.creationViewModel = creationViewModel;
            this.slotsManager = slotsManager;
            this.navigationService = navigationService;

            creationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private readonly MarketSlotCreationViewModel creationViewModel;
        private readonly SlotsManager slotsManager;
        private readonly NavigationService navigationService;


        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }

        public override bool CanExecute(object parameter)
        {
            bool canExecute = base.CanExecute(parameter);

            canExecute = canExecute && !string.IsNullOrEmpty(creationViewModel.Brand);
            canExecute = canExecute && !string.IsNullOrEmpty(creationViewModel.Model);
            canExecute = canExecute && !string.IsNullOrEmpty(creationViewModel.Count);
            canExecute = canExecute && !string.IsNullOrEmpty(creationViewModel.BaseCost);

            return canExecute;
        }

        public override void Execute(object parameter)
        {
            int baseCost = 0;
            double sale = 0;
            int count = 0;

            double.TryParse(creationViewModel.Sale, out sale);
            if (int.TryParse(creationViewModel.Count, out count) && int.TryParse(creationViewModel.BaseCost, out baseCost))
            {
                MarketItem item = new MarketItem(creationViewModel.Model, creationViewModel.Brand, creationViewModel.Release);
                ItemCost cost = new ItemCost(baseCost, sale);

                slotsManager.CreateNewSlot(item, cost, count);

                navigationService.Navigate();
            }
            else
            {
                MessageBox.Show("Can't resolve values", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
