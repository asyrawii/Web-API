using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API.Models
{
    public class Inventory
    {
        //private float _profit;
        public string Name { get; set; }
        public string Category { get; set; }
        public int SerialNumber { get; set; }
        public float BuyingPrice { get; set; }
        public float SellingPrice { get; set; }
        public float Profit
        {
            get { return SellingPrice - BuyingPrice; }
        }

    }
}
