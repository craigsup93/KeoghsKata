using System.Collections.Generic;
using System.Linq;

namespace CheckoutApp.Model
{
    public class Basket
    {
        private static Basket _instance;
        private static List<Item> _items;

        protected Basket()
        {

        }

        public static Basket Instance()
        {
            if (_instance == null)
            {
                _instance = new Basket();
                _items = new List<Item>();
            }

            return _instance;
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public void DeleteItem(Item item)
        {
            _items.Remove(item);
        }

        public bool Contains(Item item)
        {
            return _items.Contains(item);
        }

        public decimal CalculatePrice()
        {
            return 0;
        }
    }
}
