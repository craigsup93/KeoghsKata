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
            var itemToAdd = new Item() { Name = "TestItem", Price = 10 };
            basket.AddItem(itemToAdd);

            Assert.IsTrue(basket.Contains(itemToAdd));
        }

        [TestMethod]
        public void TestAddToBasketWrong()
        {
            var basket = Basket.Instance();
            var itemToAdd = new Item() { Name = "TestItem", Price = 10 };
            basket.AddItem(itemToAdd);

            var wrongItemToCheck = new Item() { Name = "TestItem2", Price = 10 };

            Assert.IsFalse(basket.Contains(wrongItemToCheck));
        }

        [TestMethod]
        public void TestPriceCalculationOfBasket()
        {
            var basket = Basket.Instance();
            var itemToAdd = new Item() { Name = "TestItem", Price = 10 };
            basket.AddItem(itemToAdd);

            Assert.AreEqual(10, basket.CalculatePrice());
        }
    }
}
