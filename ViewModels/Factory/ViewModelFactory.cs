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

        public StartViewModel CreateStartViewModel()
        {
            return new StartViewModel(new NavigationService(navigationStore, CreateRegistrationViewModel), new NavigationService(navigationStore, CreateLoginViewModel));
        }

        public RegistrationViewModel CreateRegistrationViewModel()
        {
            return new RegistrationViewModel(usersManager, new NavigationService(navigationStore, CreateStartViewModel), new NavigationService(navigationStore, CreateUserPanelViewModel));
        }

        public LoginViewModel CreateLoginViewModel()
        {
            return new LoginViewModel(usersManager, new NavigationService(navigationStore, CreateAdminPanelViewModel), new NavigationService(navigationStore, CreateUserPanelViewModel), new NavigationService(navigationStore, CreateStartViewModel));
        }

        public UserListViewModel CreateUserListViewModel()
        {
            return new UserListViewModel(usersManager, new NavigationService(navigationStore, CreateAdminPanelViewModel));
        }

        public AdminPanelViewModel CreateAdminPanelViewModel()
        {
            return new AdminPanelViewModel(usersManager, new NavigationService(navigationStore, CreateUserListViewModel), new NavigationService(navigationStore, CreateAdminMarketViewModel), new NavigationService(navigationStore, CreateLoginViewModel));
        }


        public UserPanelViewModel CreateUserPanelViewModel()
        {
            return new UserPanelViewModel(usersManager, new NavigationService(navigationStore, CreateUserMarketViewModel), new NavigationService(navigationStore, CreateLoginViewModel));
        }

        public AdminMarketSlotsViewModel CreateAdminMarketViewModel()
        {
            return new AdminMarketSlotsViewModel(slotsManager, new NavigationService(navigationStore, CreateAdminPanelViewModel), new NavigationService(navigationStore, CreateMarketSlotCreationViewModel));
        }
        public UserMarketSlotsViewModel CreateUserMarketViewModel()
        {
            return new UserMarketSlotsViewModel(slotsManager, new NavigationService(navigationStore, CreateUserPanelViewModel));
        }

        public MarketSlotCreationViewModel CreateMarketSlotCreationViewModel()
        {
            return new MarketSlotCreationViewModel(slotsManager, new NavigationService(navigationStore, CreateAdminMarketViewModel));
        }
    }
}
