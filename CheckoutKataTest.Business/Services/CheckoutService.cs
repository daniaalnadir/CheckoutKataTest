using CheckoutKataTest.Business.Models;
using CheckoutKataTest.Business.Repository;
using CheckoutKataTest.Business.Services.Contracts;

namespace CheckoutKataTest.Business.Services;

public class CheckoutService : ICheckoutService
{
    private List<Product> _orderItems = new List<Product>();
    private List<IPricingStrategy>? _pricingStrategies;
    private ProductRepository _productRepository;

    public CheckoutService(List<IPricingStrategy>? pricingStrategies = null)
    {
        _pricingStrategies = pricingStrategies;
        _productRepository = new ProductRepository();
    }

    public void Scan(string sku)
    {
        _orderItems.Add(_productRepository.GetProductBySku(sku));
    }

    public int GetTotalPrice()
    {
        int total = 0;
        var items = _orderItems.GroupBy(x => x.Sku);

        foreach (var item in items)
        {
            // Do we want discounts to stack? Do we only want a discount of a select priority to be applied? Need requirements.
            var pricingStrategiesForProduct = _pricingStrategies?
                .Where(r => string.Equals(r.Product.Sku, item.Key, StringComparison.CurrentCultureIgnoreCase)).ToList();

            if (pricingStrategiesForProduct == null || pricingStrategiesForProduct?.Count == 0)
            {
                var regularPricingStrategy = new RegularPricingStrategy(_productRepository.GetProductBySku(item.Key));
                total += regularPricingStrategy.GetTotal(item.Count());
            }
            else
            {
                foreach (var pricingStrategy in pricingStrategiesForProduct)
                {
                    total += pricingStrategy.GetTotal(item.Count());
                }
            }
        }

        return total;
    }
}