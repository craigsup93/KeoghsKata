using CheckoutApp.Model;
using System;

namespace CheckoutApp
{
    class Program
    {
        private static Basket _basket;

        static void Main(string[] args)
        {
            _basket = Basket.Instance();
            Console.WriteLine("Hello World!");

            
        }

        private void PrintMenu()
        {
            Console.WriteLine("1. Display Basket Contents");
            Console.WriteLine("2. Add Item to Basket");
            Console.WriteLine("3. Remove Item from Basket");
            Console.WriteLine("4. Display basket price");
        }
    }
}
