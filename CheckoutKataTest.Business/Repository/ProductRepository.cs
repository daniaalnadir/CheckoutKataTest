using CheckoutKataTest.Business.Models;
using CheckoutKataTest.Business.Services.Contracts;

namespace CheckoutKataTest.Business.Repository;

public class ProductRepository : IProductRepository
{
    // This is acting as the database.
    public List<Product> Products = new List<Product>()
    {
        new Product()
        {
            Sku = "A",
            UnitPrice = 50
        },
        new Product()
        {
            Sku = "B",
            UnitPrice = 30
        },
        new Product()
        {
            Sku = "C",
            UnitPrice = 20
        },
        new Product()
        {
            Sku = "D",
            UnitPrice = 15
        }
    };

    public Product GetProductBySku(string sku)
    {
        return Products.Single(x => string.Equals(x.Sku, sku, StringComparison.CurrentCultureIgnoreCase));
    }
}