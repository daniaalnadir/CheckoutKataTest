using CheckoutKataTest.Business.Models;

namespace CheckoutKataTest.Business.Services;

public class XForThePriceOfYStrategy : RegularPricingStrategy
{
    private int _unitThreshold;
    private int _unitsCharged;

    /// <summary>
    /// This pricing rule implements the concept of x for they price of y for example 4 for 3.
    /// </summary>
    /// <param name="product">The product we want the rule to be applied against</param>
    /// <param name="unitThreshold">How many items are needed in the basket for the rule to trigger</param>
    /// <param name="unitsCharged">How many units we actually want to charge for if the threshold is met</param>
    public XForThePriceOfYStrategy(Product product, int unitThreshold, int unitsCharged) : base(product)
    {
        Product = product;
        _unitThreshold = unitThreshold;
        _unitsCharged = unitsCharged;
    }

    public override int GetTotal(int units)
    {
        if (units >= _unitThreshold)
        {
            // Check if we can apply the discount multiple times
            var extraUnits = units % _unitThreshold;

            // See if the discount can be applied multiple times. i.e a 4 for 3, 8 for 6
            var discountStackTimes = units / _unitThreshold;

            if (extraUnits == 0)
            {
                var price = Product.UnitPrice * (_unitsCharged * discountStackTimes);
                return price;
            }
            else
            {
                var price = Product.UnitPrice * (_unitsCharged * discountStackTimes) + (extraUnits * Product.UnitPrice);
                return price;
            }
        }

        return base.GetTotal(units);
    }
}