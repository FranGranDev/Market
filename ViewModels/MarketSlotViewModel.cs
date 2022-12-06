using Market.Models.Items;
using Market.Commands;
using System;
using System.Windows.Input;
using System.Windows;

namespace Market.ViewModels
{
    public class MarketSlotViewModel : ViewModelBase
    {
        public MarketSlotViewModel(MarketSlot slot, Action<MarketSlot> onChanged, Action<MarketSlot> onDeleted, Action<MarketSlot> onBuy)
        {
            this.slot = slot;
            this.onChanged = onChanged;
            this.onDeleted = onDeleted;

            DeleteCommand = new ActionCommand(Delete);
            ReserveCommand = new ActionCommand(() => onBuy?.Invoke(slot));
        }

        private readonly MarketSlot slot;
        private readonly Action<MarketSlot> onChanged;
        private readonly Action<MarketSlot> onDeleted;

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

        private void Delete()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure, all orders with this product will be also deleted?", "Item delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    onDeleted?.Invoke(slot);
                    break;
            }
        }

        public ICommand DeleteCommand { get; }
        public ICommand ReserveCommand { get; }
    }
}
