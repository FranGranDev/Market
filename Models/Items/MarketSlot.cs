using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Market.Models.Items
{
    public class MarketSlot
    {
        public MarketSlot(int id, MarketItem marketItem, ItemCost cost, int count = 1)
        {
            this.id = id;
            this.marketItem = marketItem;
            this.cost = cost;
            this.count = count;
        }

        private readonly MarketItem marketItem;
        private readonly ItemCost cost;
        private int count;
        public readonly int id;
        
        public MarketItem Item => marketItem;
        public ItemCost Cost => cost;
        public int Count
        {
            get => count;
            set
            {
                count = value;
            }
        }
    }
}
