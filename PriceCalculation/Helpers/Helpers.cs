using PriceCalculation.Discounts;
using PriceCalculation.Domain;
using PriceCalculation.Factories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculation.Helpers
{
    public static class Helpers
    {
        public static IEnumerable<ProductQuantity> CreateProducts(IEnumerable<string> products)
        {
            var productsAndQuantities = new List<ProductQuantity>();

            var productFactory = new ProductFactory();

            foreach (var product in products)
            {
                var existProduct = productsAndQuantities.SingleOrDefault(item =>
                    string.Equals(item.Product.ProductName, product, StringComparison.CurrentCultureIgnoreCase));

                if (existProduct == null)
                {
                    productsAndQuantities.Add(new ProductQuantity
                    {
                        Product = productFactory.CreateProduct(product),
                        Quantity = 1
                    });
                }
                else
                    existProduct.Quantity += 1;
            }

            return productsAndQuantities;
        }

        public static IEnumerable<IDiscount> CreateDiscounts()
        {
            return new List<IDiscount>
            {
                new FullPriceDiscount
                (
                    new ProductQuantity
                    {
                        Product = new Product
                        {
                            ProductId = 2,
                            ProductName = "Milk"
                        },
                        Quantity = 3
                    },
                    new DiscountedProduct
                    {
                        ProductId = 2,
                        ProductName = "Milk"
                    }
                ),
                new HalfPriceDiscount
                (
                    new ProductQuantity
                    {
                        Product = new Product
                        {
                            ProductId = 1,
                            ProductName = "Butter"
                        },
                        Quantity = 2
                    },
                    new DiscountedProduct
                    {
                        ProductId = 3,
                        ProductName = "Bread"
                    }
                )
            };
        }
    }
}
