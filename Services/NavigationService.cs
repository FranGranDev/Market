using Market.Stores;
using Market.ViewModels;
using Market.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Services
{
    public class NavigationService
    {
        private readonly NavigationStore navigationStore;
        private readonly Func<object, ViewModelBase> createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<object, ViewModelBase> createViewModel)
        {
            this.navigationStore = navigationStore;
            this.createViewModel = createViewModel;
        }


        public void Navigate()
        {
            navigationStore.CurrantViewModel = createViewModel(null);
        }
        public void Navigate(MarketSlot slot)
        {
            navigationStore.CurrantViewModel = createViewModel(slot);
        }
    }
}
