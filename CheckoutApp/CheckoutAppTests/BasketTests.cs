using CheckoutApp.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckoutAppTests
{
    [TestClass]
    public class BasketTests
    {
        [TestMethod]
        public void TestAddToBasketCorrect()
        {
            var basket = Basket.Instance();
            var itemToAdd = new Item("A", 10, null);
            basket.AddItem(itemToAdd);

            Assert.IsTrue(basket.Contains(itemToAdd));
        }

        [TestMethod]
        public void TestAddToBasketWrong()
        {
            var basket = Basket.Instance();
            var itemToAdd = new Item("A", 10, null);
            basket.AddItem(itemToAdd);

            var wrongItemToCheck = new Item("B", 10, null);

            Assert.IsFalse(basket.Contains(wrongItemToCheck));
        }

        [TestMethod]
        public void TestPriceCalculationOfBasket()
        {
            var basket = Basket.Instance();
            var itemToAdd = new Item("A", 10, null);
            var itemToAdd2 = new Item("B", 15, null);

            basket.AddItem(itemToAdd);
            basket.AddItem(itemToAdd2);

            Assert.AreEqual(25, basket.CalculatePrice());
        }

        [TestMethod]
        public void TestMultipleDiscountOfBasket()
        {
            var basket = Basket.Instance();
            var itemToAdd = new Item("B", 15, "3 for 40");
            var itemToAdd2 = new Item("B", 15, "3 for 40");
            var itemToAdd3 = new Item("B", 15, "3 for 40");

            basket.AddItem(itemToAdd);
            basket.AddItem(itemToAdd2);
            basket.AddItem(itemToAdd3);

            Assert.AreEqual(40, basket.CalculatePrice());
        }

        [TestMethod]
        public void TestMultipleDiscountOfBasket2()
        {
            var basket = Basket.Instance();
            var itemToAdd = new Item("B", 15, "3 for 40");
            var itemToAdd2 = new Item("B", 15, "3 for 40");
            var itemToAdd3 = new Item("B", 15, "3 for 40");

            var itemToAdd4 = new Item("C", 12, "3 for 35");
            var itemToAdd5 = new Item("C", 12, "3 for 35");
            var itemToAdd6 = new Item("C", 12, "3 for 35");

            basket.AddItem(itemToAdd);
            basket.AddItem(itemToAdd2);
            basket.AddItem(itemToAdd3);

            basket.AddItem(itemToAdd4);
            basket.AddItem(itemToAdd5);
            basket.AddItem(itemToAdd6);

            Assert.AreEqual(75, basket.CalculatePrice());
        }

        [TestMethod]
        public void TestMultipleDiscountOfBasketWithSingleItem()
        {
            var basket = Basket.Instance();
            var itemToAdd = new Item("B", 15, "3 for 40");
            var itemToAdd2 = new Item("B", 15, "3 for 40");
            var itemToAdd3 = new Item("B", 15, "3 for 40");

            var itemToAdd4 = new Item("C", 12, "3 for 35");
            var itemToAdd5 = new Item("C", 12, "3 for 35");
            var itemToAdd6 = new Item("C", 12, "3 for 35");


            var itemToAdd7 = new Item("A", 10, "");

            basket.AddItem(itemToAdd);
            basket.AddItem(itemToAdd2);
            basket.AddItem(itemToAdd3);

            basket.AddItem(itemToAdd4);
            basket.AddItem(itemToAdd5);
            basket.AddItem(itemToAdd6);

            basket.AddItem(itemToAdd7);


            Assert.AreEqual(85, basket.CalculatePrice());
        }
    }
}
