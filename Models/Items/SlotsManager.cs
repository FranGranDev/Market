using Market.Models.Data;
using System.Collections.Generic;
using Market.Models.Users;


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
            get => dataBase.GetAllSlots();
        }


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
        }


        public void BuySlot(User user, MarketSlot slot)
        {
            
        }
    }
}
