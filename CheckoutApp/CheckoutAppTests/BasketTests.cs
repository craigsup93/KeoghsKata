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
            var itemToAdd = new Item("A", 10, 0, null);
            basket.AddItem(itemToAdd);

            Assert.IsTrue(basket.Contains(itemToAdd));
        }

        [TestMethod]
        public void TestAddToBasketWrong()
        {
            var basket = Basket.Instance();
            var itemToAdd = new Item("A", 10, 0, null);
            basket.AddItem(itemToAdd);

            var wrongItemToCheck = new Item("B", 10, 0, null);

            Assert.IsFalse(basket.Contains(wrongItemToCheck));
        }

        [TestMethod]
        public void TestPriceCalculationOfBasket()
        {
            var basket = Basket.Instance();
            var itemToAdd = new Item("A", 10, 0, null);
            var itemToAdd2 = new Item("B", 15, 0, null);

            basket.AddItem(itemToAdd);
            basket.AddItem(itemToAdd2);

            Assert.AreEqual(25, basket.CalculatePrice());
        }

        [TestMethod]
        public void TestMultipleDiscountOfBasket()
        {
            var basket = Basket.Instance();
            var itemToAdd = new Item("B", 15, 0, null);
            var itemToAdd2 = new Item("B", 15, 0, null);
            var itemToAdd3 = new Item("B", 15, 0, null);

            basket.AddItem(itemToAdd);
            basket.AddItem(itemToAdd2);
            basket.AddItem(itemToAdd3);

            Assert.AreEqual(40, basket.CalculatePrice());
        }
    }
}
