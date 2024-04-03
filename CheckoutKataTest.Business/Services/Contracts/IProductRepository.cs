using CheckoutKataTest.Business.Models;

namespace CheckoutKataTest.Business.Services.Contracts;

public interface IProductRepository
{
    Product GetProductBySku(string name); 
}