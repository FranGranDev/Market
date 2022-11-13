using Market.Models.Users;
using Market.Stores;

namespace Market.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore navigationStore;

        public MainViewModel(NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;

            navigationStore.CurrenViewModelChanged += OnCurrantViewModelChanged;
        }

        private void OnCurrantViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrantViewModel));
        }

        public ViewModelBase CurrantViewModel { get => navigationStore.CurrantViewModel; }
    }
}
