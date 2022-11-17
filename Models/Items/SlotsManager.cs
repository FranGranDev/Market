using Market.Models.Data;
using System.Collections.Generic;
using Market.Models.Users;
using System.Linq;
using System;

namespace Market.Models.Items
{
    public class SlotsManager
    {
        public SlotsManager(IMarketDataBase dataBase)
        {
            this.dataBase = dataBase;
        }

        private readonly IMarketDataBase dataBase;

        public List<MarketSlot> Slots
        {
            get
            {
                return dataBase.GetAllSlots();
            }
        }

        public event Action OnItemsListChanged;

        public void CreateNewSlot(MarketItem item, ItemCost cost, int count)
        {
            MarketSlot slot = new MarketSlot(-1, item, cost, count);

            dataBase.AddSlot(slot);
        }
        public void OverrideSlot(MarketSlot slot)
        {
            dataBase.ChangeSlot(slot.id, slot);
        }
        public void DeleteSlot(MarketSlot slot)
        {
            dataBase.RemoveSlot(slot.id);

            OnItemsListChanged?.Invoke();
        }


        public void BuySlot(User user, MarketSlot slot)
        {
            
        }

    }
}
