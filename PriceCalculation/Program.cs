using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please add products with space separated.");

                var items = Console.ReadLine().Split(' ');

                var discounts = Helpers.Helpers.CreateDiscounts();

                var basket = new ShoppingBasket(discounts);

                var productsSummary = GetProductsSummary(basket, items);

                var subTotal = productsSummary.SubTotal;

                var discountsApplied = basket.GetBasketDiscounts().ToList();

                var totalPrice = subTotal - discountsApplied.Sum(item => item.Amount);

                Console.WriteLine("Total Price: " + $"{ totalPrice }");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException("An application erro has occured", ex);
            }
        }

        private static ShoppingBasket GetProductsSummary(ShoppingBasket basket, IEnumerable<string> items)
        {
            var products = new List<string>();

            foreach (var item in items)
            {
                products.Add(item.ToLower());
            }

            basket.AddProducts(Helpers.Helpers.CreateProducts(products));

            return basket;
        }
    }
}
