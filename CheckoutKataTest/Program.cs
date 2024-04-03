using CheckoutKataTest.Business.Repository;
using CheckoutKataTest.Business.Services;
using CheckoutKataTest.Business.Services.Contracts;

var productRepository = new ProductRepository();

var volumeCheckout = new CheckoutService(new List<IPricingStrategy>()
{
    new VolumePricingStrategy(productRepository.Products.First(), 3, 130)
});

volumeCheckout.Scan("a");
volumeCheckout.Scan("b");
volumeCheckout.Scan("c");
volumeCheckout.Scan("d");
volumeCheckout.Scan("a");
volumeCheckout.Scan("a");
volumeCheckout.Scan("a");
volumeCheckout.Scan("a");

Console.WriteLine($"The total for the volume based checkout comes to {volumeCheckout.GetTotalPrice()}");

var xForYCheckout = new CheckoutService(new List<IPricingStrategy>()
{
    new XForThePriceOfYStrategy(productRepository.Products.First(), 4, 3)
});

xForYCheckout.Scan("a");
xForYCheckout.Scan("b");
xForYCheckout.Scan("c");
xForYCheckout.Scan("d");
xForYCheckout.Scan("a");
xForYCheckout.Scan("a");
xForYCheckout.Scan("a");
xForYCheckout.Scan("a");

Console.WriteLine($"The total for the x for y based checkout comes to {xForYCheckout.GetTotalPrice()}");