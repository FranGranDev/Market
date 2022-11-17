using Market.Models.Items;
using Market.Commands;
using System;
using System.Windows.Input;

namespace Market.ViewModels
{
    public class MarketSlotViewModel : ViewModelBase
    {
        public MarketSlotViewModel(MarketSlot slot, Action<MarketSlot> onChanged, Action<MarketSlot> onDeleted)
        {
            this.slot = slot;
            this.onChanged = onChanged;

            DeleteCommand = new ActionCommand(() => onDeleted?.Invoke(slot));
        }

        private readonly MarketSlot slot;
        private readonly Action<MarketSlot> onChanged;

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
                onChanged?.Invoke(slot);
            }
        }
        public double Sale
        {
            get { return slot.Cost.Sale; }
            set
            {
                slot.Cost.Sale = value;
                onChanged?.Invoke(slot);
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
                onChanged?.Invoke(slot);
            }
        }

        public ICommand DeleteCommand { get; }
    }
}
