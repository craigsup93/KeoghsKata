using System.Collections.Generic;

namespace CheckoutApp.Model
{
    public  class Item : IItem
    {
        public string Name { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPercent { get; set; }
        public KeyValuePair<decimal, int> MultipleDiscounts { get; set; }


    }
}