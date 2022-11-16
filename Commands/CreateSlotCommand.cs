using System;
using Market.Services;
using Market.ViewModels;
using Market.Models.Items;


namespace Market.Commands
{
    public class CreateSlotCommand : CommandBase
    {
        public CreateSlotCommand(MarketSlotCreationViewModel creationViewModel, SlotsManager slotsManager, NavigationService navigationService)
        {
            this.creationViewModel = creationViewModel;
            this.slotsManager = slotsManager;
            this.navigationService = navigationService;
        }

        private readonly MarketSlotCreationViewModel creationViewModel;
        private readonly SlotsManager slotsManager;
        private readonly NavigationService navigationService;


        public override bool CanExecute(object parameter)
        {
            bool canExecute = base.CanExecute(parameter);
            return canExecute;
        }

        public override void Execute(object parameter)
        {

            navigationService.Navigate();
        }
    }
}
