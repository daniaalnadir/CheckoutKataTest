using CheckoutKataTest.Business.Models;
using CheckoutKataTest.Business.Services.Contracts;

namespace CheckoutKataTest.Business.Services;

public class RegularPricingStrategy : IPricingStrategy
{
    public RegularPricingStrategy(Product product)
    {
        Product = product;
    }
    
    public virtual int GetTotal(int units)
    {
        return Product.UnitPrice * units;
    }

    public Product Product { get; set; }
}