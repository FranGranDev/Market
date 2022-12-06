using Market.Services;
using Market.Models.Users;
using Market.Models.Items;
using Market.Stores;


namespace Market.ViewModels.Factory
{
    public class ViewModelFactory
    {
        public ViewModelFactory(UsersManager usersManager, SlotsManager slotsManager, NavigationStore navigationStore)
        {
            this.slotsManager = slotsManager;
            this.usersManager = usersManager;
            this.navigationStore = navigationStore;
        }

        private readonly UsersManager usersManager;
        private readonly SlotsManager slotsManager;
        private readonly NavigationStore navigationStore;

        public StartViewModel CreateStartViewModel(object param)
        {
            return new StartViewModel(new NavigationService(navigationStore, CreateRegistrationViewModel), new NavigationService(navigationStore, CreateLoginViewModel));
        }

        public RegistrationViewModel CreateRegistrationViewModel(object param)
        {
            return new RegistrationViewModel(usersManager, new NavigationService(navigationStore, CreateStartViewModel), new NavigationService(navigationStore, CreateUserPanelViewModel));
        }

        public LoginViewModel CreateLoginViewModel(object param)
        {
            return new LoginViewModel(usersManager, new NavigationService(navigationStore, CreateAdminPanelViewModel), new NavigationService(navigationStore, CreateUserPanelViewModel), new NavigationService(navigationStore, CreateStartViewModel));
        }

        public UserListViewModel CreateUserListViewModel(object param)
        {
            return new UserListViewModel(usersManager, new NavigationService(navigationStore, CreateAdminPanelViewModel));
        }

        public AdminPanelViewModel CreateAdminPanelViewModel(object param)
        {
            return new AdminPanelViewModel(usersManager, new NavigationService(navigationStore, CreateUserListViewModel), new NavigationService(navigationStore, CreateAdminMarketViewModel), new NavigationService(navigationStore, CreateLoginViewModel));
        }


        public UserPanelViewModel CreateUserPanelViewModel(object param)
        {
            return new UserPanelViewModel(usersManager, new NavigationService(navigationStore, CreateUserMarketViewModel), new NavigationService(navigationStore, CreateLoginViewModel));
        }

        public AdminMarketSlotsViewModel CreateAdminMarketViewModel(object param)
        {
            return new AdminMarketSlotsViewModel(slotsManager, new NavigationService(navigationStore, CreateAdminPanelViewModel), new NavigationService(navigationStore, CreateMarketSlotCreationViewModel));
        }
        public UserMarketSlotsViewModel CreateUserMarketViewModel(object param)
        {
            return new UserMarketSlotsViewModel(slotsManager, new NavigationService(navigationStore, CreateReservationViewModel), new NavigationService(navigationStore, CreateUserPanelViewModel));
        }
        public ReservationViewModel CreateReservationViewModel(object param)
        {
            return new ReservationViewModel(slotsManager, (MarketSlot)param, new NavigationService(navigationStore, CreateUserMarketViewModel));
        }

        public MarketSlotCreationViewModel CreateMarketSlotCreationViewModel(object param)
        {
            return new MarketSlotCreationViewModel(slotsManager, new NavigationService(navigationStore, CreateAdminMarketViewModel));
        }
    }
}
