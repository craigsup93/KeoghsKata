using System.Collections.Generic;

namespace CheckoutApp.Model
{
    public  class Item : IItem
    {
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public string Discount { get; set; }

        public Item(string sku, decimal price, string discount)
        {
            SKU = sku;
            Price = price;
            Discount = discount;
        }
    }
}