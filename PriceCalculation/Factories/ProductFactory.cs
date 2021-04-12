using PriceCalculation.Domain;
using System;

namespace PriceCalculation.Factories
{
    public class ProductFactory
    {
        public Product CreateProduct(string productName)
        {
            switch (productName.ToLower())
            {
                case "butter":
                    return new Product
                    {
                        ProductId = 1,
                        ProductName = "Butter",
                        ProductCost = 0.80m
                    };
                case "milk":
                    return new Product
                    {
                        ProductId = 2,
                        ProductName = "Milk",
                        ProductCost = 1.15m
                    };
                case "bread":
                    return new Product
                    {
                        ProductId = 3,
                        ProductName = "Bread",
                        ProductCost = 1.00m
                    };
                default:
                    throw new NotSupportedException($"Unrecognized product name : { productName.ToLower() }");
            }
        }
    }
}
