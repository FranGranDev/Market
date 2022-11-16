using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Models.Items
{
    public class ItemCost
    {
        public ItemCost(int baseCost, double sale = 0)
        {
            this.baseCost = baseCost;
            this.sale = sale;
        }

        
        private int baseCost;

        public int BaseCost
        {
            get { return baseCost; }
            set { baseCost = value; }
        }

        private double sale;

        public double Sale
        {
            get { return sale; }
            set { sale = value; }
        }

        public int FinalCost 
        {
            get => (int)Math.Round(BaseCost * Math.Max(100 - sale, 0) / 100);
        }
    }
}
