using PriceCalculation.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculation.Domain
{
    public class AppliedDiscount
    {
        public DiscountType Type { get; set; }

        public decimal Amount { get; set; }

    }
}
