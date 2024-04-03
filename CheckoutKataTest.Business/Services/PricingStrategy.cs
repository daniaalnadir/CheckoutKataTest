using CheckoutKataTest.Business.Models;
using CheckoutKataTest.Business.Services.Contracts;

namespace CheckoutKataTest.Business.Services;

public class PricingStrategy : IPricingStrategy
{
    public Product Product { get; set; }
    
    public int GetTotal(int units)
    {
        return Product.UnitPrice * units;
    }
}