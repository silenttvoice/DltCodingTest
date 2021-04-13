using PriceCalculation.Domain;
using PriceCalculation.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PriceCalculation.Discounts
{
    public class FullPriceDiscount : IDiscount
    {
        private readonly ProductQuantity _productsThatQualifyForDiscount;
        private readonly DiscountedProduct _discountProduct;

        public FullPriceDiscount(ProductQuantity productsThatQualifyForDiscount,
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
                    && (item.Quantity / _productsThatQualifyForDiscount.Quantity > 1))
                {
                    var numberOfFreeItems = item.Quantity / _productsThatQualifyForDiscount.Quantity;

                    var freeItems = itemList.Where(freeItem => freeItem.Product.ProductId == _discountProduct.ProductId)
                                                    .ToList();

                    if (freeItems.Count > 0)
                    {
                        var discount = ApplyDiscount(numberOfFreeItems, freeItems[0].Product);

                        discountApplied.Add(new AppliedDiscount
                        {
                            Type = DiscountType.FullPrice,
                            Amount = discount
                        });
                    }
                }
            }

            return discountApplied;
        }

        private decimal ApplyDiscount(int numberOfFreeItems, Product item)
        {
            return Math.Round(item.ProductCost * numberOfFreeItems, 2);
        }
    }
}
