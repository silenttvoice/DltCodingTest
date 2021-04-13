using PriceCalculation.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculation.Discounts
{
    public interface IDiscount
    {
        IEnumerable<AppliedDiscount> DiscountsApplicable(IEnumerable<ProductQuantity> items);
    }
}
