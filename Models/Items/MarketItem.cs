using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Models.Items
{
    public class MarketItem
    {
        public MarketItem(string model, string brand, DateTime release)
        {
            this.model = model;
            this.brand = brand;
            this.release = release;
        }

        private string model;
        private string brand;
        private DateTime release;


        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        public DateTime Release
        {
            get { return release; }
            set { release = value; }
        }
    }
}
