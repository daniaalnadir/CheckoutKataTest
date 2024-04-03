using CheckoutKataTest.Business.Models;
using CheckoutKataTest.Business.Services.Contracts;

namespace CheckoutKataTest.Business.Services;

public class VolumePricingStrategy : IPricingStrategy
{
    private readonly int _volumePrice;
    private readonly int _volumeThreshold;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="product"></param>
    /// <param name="volumeThreshold">How many items are needed in the basket for the rule to trigger</param>
    /// <param name="volumePrice">How much we want to charge if the threshold is met</param>
    public VolumePricingStrategy(Product product, int volumeThreshold, int volumePrice)
    {
        _volumePrice = volumePrice;
        _volumeThreshold = volumeThreshold;
        Product = product;
    }

    public Product Product { get; set; }

    public int GetTotal(int units)
    {
        if (units >= _volumeThreshold)
        {
            // See if we have any left over items that are above the threshold but not enough to stack to the next threshold.
            var extraUnits = units % _volumeThreshold;

            // See if the discount can be applied multiple times. i.e a 3 for 130, 6 for 260
            var discountStackTimes = units / _volumeThreshold;

            if (extraUnits == 0)
            {
                var price = _volumePrice * discountStackTimes;
                return price;
            }
            else
            {
                var price = _volumePrice * discountStackTimes + (extraUnits * Product.UnitPrice);
                return price;
            }
        }
    }
}