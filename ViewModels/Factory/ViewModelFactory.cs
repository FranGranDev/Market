using Market.Services;
using Market.Models.Users;
using Market.Stores;


namespace Market.ViewModels.Factory
{
    public class ViewModelFactory
    {
        public ViewModelFactory(UsersManager usersManager, NavigationStore navigationStore)
        {
            this.usersManager = usersManager;
            this.navigationStore = navigationStore;
        }

        private readonly UsersManager usersManager;
        private readonly NavigationStore navigationStore;

        public StartViewModel CreateStartViewModel()
        {
            return new StartViewModel(new NavigationService(navigationStore, CreateRegistrationViewModel), new NavigationService(navigationStore, CreateLoginViewModel));
        }

        public RegistrationViewModel CreateRegistrationViewModel()
        {
            return new RegistrationViewModel(usersManager, new NavigationService(navigationStore, CreateStartViewModel));
        }

        public LoginViewModel CreateLoginViewModel()
        {
            return new LoginViewModel(usersManager, new NavigationService(navigationStore, CreateAdminViewModel), new NavigationService(navigationStore, CreateStartViewModel));
        }

        public UserListViewModel CreateUserListViewModel()
        {
            return new UserListViewModel(usersManager, new NavigationService(navigationStore, CreateAdminViewModel));
        }

        public AdminViewModel CreateAdminViewModel()
        {
            return new AdminViewModel(usersManager, new NavigationService(navigationStore, CreateUserListViewModel), new NavigationService(navigationStore, CreateLoginViewModel));
        }

    }
}
