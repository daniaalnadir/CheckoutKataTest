using CheckoutKataTest.Business.Models;
using CheckoutKataTest.Business.Services.Contracts;

namespace CheckoutKataTest.Business.Services;

public class CheckoutService : ICheckoutService
{
    private List<Product> _orderItems = new List<Product>();
    public void Scan(string item)
    {
        throw new NotImplementedException();
    }

    public int GetTotalPrice()
    {
        throw new NotImplementedException();
    }
}