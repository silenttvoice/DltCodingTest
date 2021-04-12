using System;
using System.Collections.Generic;

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

                var productSummary = GetProductsSummary(items);



                
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static ShoppingBasket GetProductsSummary(IEnumerable<string> items)
        {
            var products = new List<string>();

            foreach (var item in items)
            {
                products.Add(item.ToLower());
            }

            var basket = new ShoppingBasket();

            basket.AddProducts(Helpers.Helpers.CreateProducts(products));

            return basket;
        }
    }
}
