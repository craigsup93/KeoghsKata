using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckoutApp.Model
{
    public class PriceEngine : IPriceEngine
    {
        public decimal CalculateBasketPrice(List<Item> items)
        {
            decimal total = 0;

            var mapOfItems = items.GroupBy(x => x.SKU);
            var promotionItems = items.GroupBy(x => x.Discount);


            foreach (var item in promotionItems.Where(x=>x.Key != null))
            {
                var discountType = item.First().Discount;

                if (discountType.Contains("for"))
                {
                    total = CalculateForDiscount(total, item, discountType);
                }
                else if (discountType.Contains("off"))
                {
                    CalculateOffDiscount(discountType);

                }
            }

            foreach(var nonPromoItem in items.Where(x=>x.Discount == null || x.Discount == ""))
            {
                total += nonPromoItem.Price;
            }

            return total;
        }

        private static void CalculateOffDiscount(string discountType)
        {
            // we discount all items
            var discount = decimal.Parse(discountType.Split(" ")[0].Trim());
            var quantityRequired = int.Parse(discountType.Split(" ")[2].Trim());
        }

        private static decimal CalculateForDiscount(decimal total, IGrouping<string, Item> item, string discountType)
        {
            // we disocunt if we have a set amount of items
            var quantityRequired = int.Parse(discountType.Split(" ")[0].Trim());
            var price = decimal.Parse(discountType.Split(" ")[2].Trim());

            if (item.Count() >= quantityRequired)
            {
                var individualPrice = item.First().Price;
                total += ((item.Count() / quantityRequired) * price) + ((item.Count() % quantityRequired) * individualPrice);
            }

            return total;
        }
    }
}
