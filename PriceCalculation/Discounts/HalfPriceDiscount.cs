using PriceCalculation.Domain;
using PriceCalculation.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculation.Discounts
{
    public class HalfPriceDiscount : IDiscount
    {
        private readonly ProductQuantity _productsThatQualifyForDiscount;
        private readonly DiscountedProduct _discountProduct;

        public HalfPriceDiscount(
            ProductQuantity productsThatQualifyForDiscount,
            DiscountedProduct discountProduct)
        {
            _productsThatQualifyForDiscount = productsThatQualifyForDiscount ?? throw new ArgumentNullException(nameof(productsThatQualifyForDiscount));
            _discountProduct = discountProduct ?? throw new ArgumentNullException(nameof(discountProduct));
        }

        public IEnumerable<AppliedDiscount> DiscountsApplicable(IEnumerable<ProductQuantity> items)
        {
            var itemList = items.ToList();

            var discountApplied = new List<AppliedDiscount>();

            foreach (var item in itemList)
            {
                if (item.Product.ProductId == _productsThatQualifyForDiscount.Product.ProductId
                    && item.Quantity >= _productsThatQualifyForDiscount.Quantity)
                {
                    var halfPriceItems = itemList.Where(halfPriceItem => halfPriceItem.Product.ProductId == _discountProduct.ProductId)
                                                    .ToList();

                    if (halfPriceItems.Count > 0)
                    {
                        var discount = ApplyDiscount(halfPriceItems[0].Product);

                        discountApplied.Add(new AppliedDiscount
                        {
                            Type = DiscountType.HalfPrice,
                            Amount = discount
                        });
                    }
                }
            }

            return discountApplied;
        }

        private decimal ApplyDiscount(Product item)
        {
            return Math.Round(item.ProductCost * 0.5m, 2);
        }
    }
}
