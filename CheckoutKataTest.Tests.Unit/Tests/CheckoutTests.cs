using CheckoutKataTest.Business.Models;
using CheckoutKataTest.Business.Services;
using CheckoutKataTest.Business.Services.Contracts;
using FluentAssertions;
using Moq;

namespace CheckoutKataTest.Tests.Unit.Tests;

public class CheckoutTests
{
    private readonly Mock<IProductRepository> _productRepository;

    public CheckoutTests()
    {
        _productRepository = new Mock<IProductRepository>();
    }

    [Fact]
    public void GetTotalPrice_ShouldReturnCorrectRegularPrice_WhenNoStrategyPassedToCheckout()
    {
        // Arrange
        var product = new Product()
        {
            Sku = "A",
            UnitPrice = 50
        };

        _productRepository.Setup(x => x.GetProductBySku(product.Sku)).Returns(product);
        
        var checkout = new CheckoutService();

        // Act
        checkout.Scan(product.Sku);

        var total = checkout.GetTotalPrice();

        // Assert
        total.Should().Be(50);
    }

    [Fact]
    public void GetTotalPrice_ShouldReturnCorrectVolumePrice_WhenVolumeStrategyPassedToCheckoutAndThresholdIsExact()
    {
        // Arrange
        var product = new Product()
        {
            Sku = "A",
            UnitPrice = 50
        };

        _productRepository.Setup(x => x.GetProductBySku(product.Sku)).Returns(product);
        
        var pricingStrategies = new List<IPricingStrategy>()
        {
            new VolumePricingStrategy(product, 3, 130)
        };

        var checkout = new CheckoutService(pricingStrategies);

        // Act
        checkout.Scan(product.Sku);
        checkout.Scan(product.Sku);
        checkout.Scan(product.Sku);

        var total = checkout.GetTotalPrice();

        // Assert
        total.Should().Be(130);
    }

    [Fact]
    public void GetTotalPrice_ShouldReturnCorrectVolumePrice_WhenVolumeStrategyPassedToCheckoutAndThresholdIsExceeded()
    {
        // Arrange
        var product = new Product()
        {
            Sku = "A",
            UnitPrice = 50
        };

        _productRepository.Setup(x => x.GetProductBySku(product.Sku)).Returns(product);
        
        var pricingStrategies = new List<IPricingStrategy>()
        {
            new VolumePricingStrategy(product, 3, 130)
        };

        var checkout = new CheckoutService(pricingStrategies);

        // Act
        checkout.Scan(product.Sku);
        checkout.Scan(product.Sku);
        checkout.Scan(product.Sku);
        checkout.Scan(product.Sku);

        var total = checkout.GetTotalPrice();

        // Assert
        total.Should().Be(180);
    }

    [Fact]
    public void GetTotalPrice_ShouldFallbackToRegularStrategy_WhenVolumeStrategyPassedToCheckoutAndThresholdIsBelow()
    {
        // Arrange
        var product = new Product()
        {
            Sku = "A",
            UnitPrice = 50
        };

        _productRepository.Setup(x => x.GetProductBySku(product.Sku)).Returns(product);
        
        var pricingStrategies = new List<IPricingStrategy>()
        {
            new VolumePricingStrategy(product, 3, 130)
        };

        var checkout = new CheckoutService(pricingStrategies);

        // Act
        checkout.Scan(product.Sku);
        checkout.Scan(product.Sku);

        var total = checkout.GetTotalPrice();

        // Assert
        total.Should().Be(100);
    }

    [Fact]
    public void
        GetTotalPrice_ShouldStackDiscountAndReturnCorrectVolumePrice_WhenVolumeStrategyPassedToCheckoutAndThresholdIsExceeded()
    {
        // Arrange
        var product = new Product()
        {
            Sku = "A",
            UnitPrice = 50
        };

        _productRepository.Setup(x => x.GetProductBySku(product.Sku)).Returns(product);
        
        var pricingStrategies = new List<IPricingStrategy>()
        {
            new VolumePricingStrategy(product, 3, 130)
        };

        var checkout = new CheckoutService(pricingStrategies);

        // Act
        checkout.Scan(product.Sku);
        checkout.Scan(product.Sku);
        checkout.Scan(product.Sku);
        checkout.Scan(product.Sku);
        checkout.Scan(product.Sku);
        checkout.Scan(product.Sku);

        var total = checkout.GetTotalPrice();

        // Assert
        total.Should().Be(260);
    }

    [Fact]
    public void
        GetTotalPrice_ShouldStackDiscountAndReturnCorrectPrice_WhenVolumeStrategyPassedToCheckoutAndThresholdIsExceededAndMixProductsPassed()
    {
        // Arrange
        var product = new Product()
        {
            Sku = "A",
            UnitPrice = 50
        };
        
        var productTwo = new Product()
        {
            Sku = "B",
            UnitPrice = 30
        };

        _productRepository.Setup(x => x.GetProductBySku(product.Sku)).Returns(product);
        _productRepository.Setup(x => x.GetProductBySku(productTwo.Sku)).Returns(productTwo);

        var pricingStrategies = new List<IPricingStrategy>()
        {
            new VolumePricingStrategy(product, 3, 130)
        };

        var checkout = new CheckoutService(pricingStrategies);

        // Act
        checkout.Scan(product.Sku);
        checkout.Scan(product.Sku);
        checkout.Scan(productTwo.Sku);

        checkout.Scan(product.Sku);
        checkout.Scan(productTwo.Sku);
        
        var total = checkout.GetTotalPrice();

        // Assert
        total.Should().Be(190);
    }

    [Fact]
    public void
        GetTotalPrice_ShouldReturnCorrectPrice_WhenMultipleProductsAndStrategiesPassedAndThresholdsMetExactly()
    {
        // Arrange
        
        // Act
        
        // Assert
    }

    [Fact]
    public void GetTotalPrice_ShouldReturnCorrectPrice_WhenMultipleProductsAndStrategiesPassedAndThresholdsExceeded()
    {
        // Arrange
        
        // Act
        
        // Assert
    }

    [Fact]
    public void GetTotalPrice_ShouldReturnCorrectPrice_WhenMultipleStrategiesPassedAndThresholdIsNotExceeded()
    {
        // Arrange
        
        // Act
        
        // Assert
    }
}