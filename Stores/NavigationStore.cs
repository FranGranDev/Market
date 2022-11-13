using Market.ViewModels;
using System;

namespace Market.Stores
{
    public class NavigationStore
    {
        private ViewModelBase currantViewModel;
        public ViewModelBase CurrantViewModel
        {
            get => currantViewModel;
            set
            {
                currantViewModel = value;
                OnCurrenViewModelChanged();
            }
        }

        private void OnCurrenViewModelChanged()
        {
            CurrenViewModelChanged?.Invoke();
        }

        public event Action CurrenViewModelChanged;
    }
}
