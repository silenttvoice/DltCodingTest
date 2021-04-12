using PriceCalculation.Domain;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculation
{
    public class ShoppingBasket : IShoppingBasket
    {
        private readonly List<ProductQuantity> _productItems;

        public ShoppingBasket()
        {
            _productItems = new List<ProductQuantity>();
        }

        public void AddProducts(IEnumerable<ProductQuantity> productItems)
        {
            _productItems.AddRange(productItems);
        }

        public int ProductCount => _productItems.Count;

        public decimal SubTotal => _productItems.Sum(item => item.Product.ProductCost * item.Quantity);
    }
}
