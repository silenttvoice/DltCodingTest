using Moq;
using NUnit.Framework;
using PriceCalculation;
using PriceCalculation.Discounts;
using PriceCalculation.Domain;
using PriceCalculation.Enums;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.ShoppingBasketTests
{
    public class ShoppingBasketTests : ShoppingBasketMockObjects
    {
        [Test]
        public void AddProducts_ShouldMatch_ProductsCount()
        {
            var shoppingBasket = new ShoppingBasket(new List<IDiscount>());
            var mockedList = CreateFakeProductQuantities();
            shoppingBasket.AddProducts(mockedList);

            var result = shoppingBasket.ProductCount;

            Assert.AreEqual(result, mockedList.Count);
        }

        [Test]
        public void ShoppingBasket_CheckCalculatedTotalPrice_WithHalfPriceDiscount()
        {
            var halfPriceDiscount = new Mock<IDiscount>();
            halfPriceDiscount.Setup(mock => mock.DiscountsApplicable(It.IsAny<IEnumerable<ProductQuantity>>()))
                .Returns(CreateHalfPriceAppliedDiscount());
            var shoppingBasket = new ShoppingBasket(new List<IDiscount> { halfPriceDiscount.Object });
            shoppingBasket.AddProducts(CreateProductsForHalfPriceDiscount());

            var discountsTotal = shoppingBasket.GetBasketDiscounts().Sum(item => item.Amount);
            var result = shoppingBasket.SubTotal - discountsTotal;

            Assert.AreEqual(result, 3.10m);
        }

        [Test]
        public void ShoppingBasket_CheckCalculatedTotalPrice_WithFullPriceDiscount()
        {
            var fullPriceDiscount = new Mock<IDiscount>();
            fullPriceDiscount.Setup(mock => mock.DiscountsApplicable(It.IsAny<IEnumerable<ProductQuantity>>()))
                .Returns(CreateFullPriceAppliedDiscount());
            var shoppingBasket = new ShoppingBasket(new List<IDiscount> { fullPriceDiscount.Object });
            shoppingBasket.AddProducts(CreateProductsForFullPriceDiscount());

            var discountsTotal = shoppingBasket.GetBasketDiscounts().Sum(item => item.Amount);
            var result = shoppingBasket.SubTotal - discountsTotal;

            Assert.AreEqual(result, 3.45m);
        }
    }
}
