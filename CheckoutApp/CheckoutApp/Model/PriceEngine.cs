using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckoutApp.Model
{
    public class PriceEngine
    {
        public decimal CalculateBasketPrice(List<Item> items)
        {
            decimal total = 0;

            var mapOfItems = items.GroupBy(x => x.SKU);
            var promotionItems = items.GroupBy(x => x.Discount);


            foreach (var item in promotionItems)
            {
                var discountType = item.First().Discount;

                if (discountType.Contains("for"))
                {
                    // we disocunt if we have a set amount of items
                    var quantityRequired = int.Parse(discountType.Split(" ")[0].Trim());
                    var price = decimal.Parse(discountType.Split(" ")[2].Trim());

                    if (item.Count() >= quantityRequired)
                    {
                        var individualPrice = item.First().Price;
                        total += ((item.Count() / quantityRequired) * price) + ((item.Count() % quantityRequired)* individualPrice);
                    }
                }
                else if (discountType.Contains("off"))
                {
                    // we discount all items
                    var discount = decimal.Parse(discountType.Split(" ")[0].Trim());
                    var quantityRequired = int.Parse(discountType.Split(" ")[2].Trim());



                }
            }

            return total;
        }
    }
}
