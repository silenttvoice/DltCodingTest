using AutoFixture;
using Moq;
using NUnit.Framework;
using PriceCalculation;
using PriceCalculation.Discounts;
using PriceCalculation.Domain;
using PriceCalculation.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTests.ShoppingBasketTests
{
    public class ShoppingBasketMockObjects
    {
        public static ICollection<ProductQuantity> CreateFakeProductQuantities()
        {
            var fakeBuilder = new Fixture();

            return fakeBuilder.Create<List<ProductQuantity>>();
        }

        public static ICollection<AppliedDiscount> CreateHalfPriceAppliedDiscount()
        {
            return new List<AppliedDiscount>
            {
                new AppliedDiscount
                {
                    Type = DiscountType.HalfPrice,
                    Amount = 0.50m
                }
            };
        }

        public static ICollection<ProductQuantity> CreateProductsForHalfPriceDiscount()
        {
            return new List<ProductQuantity>
            {
                new ProductQuantity
                {
                    Product = new Product
                    {
                        ProductId = 1,
                        ProductName = "Butter",
                        ProductCost = 0.80m
                    },
                    Quantity = 2
                },
                new ProductQuantity
                {
                    Product = new Product
                    {
                        ProductId = 3,
                        ProductName = "Bread",
                        ProductCost = 1.00m
                    },
                    Quantity = 2
                }
            };
        }

        public static ICollection<AppliedDiscount> CreateFullPriceAppliedDiscount()
        {
            return new List<AppliedDiscount>
            {
                new AppliedDiscount
                {
                    Type = DiscountType.FullPrice,
                    Amount = 1.15m
                }
            };
        }

        public static ICollection<ProductQuantity> CreateProductsForFullPriceDiscount()
        {
            return new List<ProductQuantity>
            {
                new ProductQuantity
                {
                    Product = new Product
                    {
                        ProductId = 1,
                        ProductName = "Milk",
                        ProductCost = 1.15m
                    },
                    Quantity = 4
                }
            };
        }
    }
}
