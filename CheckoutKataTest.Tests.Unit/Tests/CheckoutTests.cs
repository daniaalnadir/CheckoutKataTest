namespace CheckoutKataTest.Tests.Unit.Tests;

public class CheckoutTests
{
    public CheckoutTests()
    {
        
    }

    [Fact]
    public void GetTotalPrice_ShouldReturnCorrectRegularPrice_WhenNoStrategyPassedToCheckout()
    {
        // Arrange
        
        // Act
        
        // Assert
    }

    [Fact]
    public void GetTotalPrice_ShouldReturnCorrectVolumePrice_WhenVolumeStrategyPassedToCheckoutAndThresholdIsExact()
    {
        // Arrange
        
        // Act
        
        // Assert
    }

    [Fact]
    public void GetTotalPrice_ShouldReturnCorrectVolumePrice_WhenVolumeStrategyPassedToCheckoutAndThresholdIsExceeded()
    {
        // Arrange
        
        // Act
        
        // Assert
    }

    [Fact]
    public void GetTotalPrice_ShouldFallbackToRegularStrategy_WhenVolumeStrategyPassedToCheckoutAndThresholdIsBelow()
    {
        // Arrange
        
        // Act
        
        // Assert
    }

    [Fact]
    public void
        GetTotalPrice_ShouldStackDiscountAndReturnCorrectVolumePrice_WhenVolumeStrategyPassedToCheckoutAndThresholdIsExceeded()
    {
        // Arrange
        
        // Act
        
        // Assert
    }

    [Fact]
    public void
        GetTotalPrice_ShouldStackDiscountAndReturnCorrectPrice_WhenVolumeStrategyPassedToCheckoutAndThresholdIsExceededAndMixProductsPassed()
    {
        // Arrange
        
        // Act
        
        // Assert
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