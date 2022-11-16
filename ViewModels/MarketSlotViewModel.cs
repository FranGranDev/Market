using Market.Models.Items;
using System;
using System.Windows.Input;

namespace Market.ViewModels
{
    public class MarketSlotViewModel : ViewModelBase
    {
        public MarketSlotViewModel(MarketSlot slot)
        {
            this.slot = slot;
        }

        private readonly MarketSlot slot;

        public string Model
        {
            get { return slot.Item.Model; }
            set
            {

            }
        }
        public string Brand
        {
            get { return slot.Item.Brand; }
            set
            {

            }
        }
        public DateTime Release
        {
            get { return slot.Item.Release; }
            set
            {

            }
        }
        public int BaseCost
        {
            get { return slot.Cost.BaseCost; }
            set
            {
                slot.Cost.BaseCost = value;
            }
        }
        public double Sale
        {
            get { return slot.Cost.Sale; }
            set
            {
                slot.Cost.Sale = value;
            }
        }
        public int FinalCost
        {
            get { return slot.Cost.FinalCost; }
            set
            {

            }
        }
        public int Count
        {
            get { return slot.Count; }
            set
            {
                slot.Count = value;
            }
        }

        public ICommand DeleteCommand { get; }
    }
}
