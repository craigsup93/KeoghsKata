using System.Collections.Generic;

namespace CheckoutApp.Model
{
    public  class Item : IItem
    {
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public KeyValuePair<decimal, int>? MultipleDiscounts { get; set; }

        public Item(string sku, decimal price, KeyValuePair<decimal, int>? multipleDiscounts)
        {
            SKU = sku;
            Price = price;
            MultipleDiscounts = multipleDiscounts;
        }
    }
}