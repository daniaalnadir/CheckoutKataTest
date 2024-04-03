using CheckoutKataTest.Business.Models;

namespace CheckoutKataTest.Business.Services.Contracts;

public interface IPricingStrategy
{
    public Product Product { get; set; }
    int GetTotal(int units);
}