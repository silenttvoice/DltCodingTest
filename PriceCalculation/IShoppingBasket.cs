using PriceCalculation.Domain;
using System.Collections.Generic;

namespace PriceCalculation
{
    public interface IShoppingBasket
    {
        void AddProducts(IEnumerable<ProductQuantity> items);
    }
}
