using System.Collections.Generic;

namespace CheckoutApp.Model
{
    public interface IPriceEngine
    {
        public decimal CalculateBasketPrice(List<Item> items);



    }
}