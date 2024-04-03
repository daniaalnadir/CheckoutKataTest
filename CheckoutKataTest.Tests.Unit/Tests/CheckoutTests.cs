namespace CheckoutKataTest.Tests.Unit.Tests;

public class CheckoutTests
{
    public CheckoutTests()
    {
        
    }

    [Fact]
    public void GetTotalPrice_ShouldReturnCorrectRegularPrice_WhenNoStrategyPassedToCheckout()
    {
        
    }

    [Fact]
    public void GetTotalPrice_ShouldReturnCorrectVolumePrice_WhenVolumeStrategyPassedToCheckoutAndThresholdIsExact()
    {
    }

    [Fact]
    public void GetTotalPrice_ShouldReturnCorrectVolumePrice_WhenVolumeStrategyPassedToCheckoutAndThresholdIsExceeded()
    {
    }

    [Fact]
    public void GetTotalPrice_ShouldFallbackToRegularStrategy_WhenVolumeStrategyPassedToCheckoutAndThresholdIsBelow()
    {
    }

    [Fact]
    public void
        GetTotalPrice_ShouldStackDiscountAndReturnCorrectVolumePrice_WhenVolumeStrategyPassedToCheckoutAndThresholdIsExceeded()
    {
    }

    [Fact]
    public void
        GetTotalPrice_ShouldStackDiscountAndReturnCorrectPrice_WhenVolumeStrategyPassedToCheckoutAndThresholdIsExceededAndMixProductsPassed()
    {
    }

    [Fact]
    public void
        GetTotalPrice_ShouldReturnCorrectPrice_WhenMultipleProductsAndStrategiesPassedAndThresholdsMetExactly()
    {
    }

    [Fact]
    public void GetTotalPrice_ShouldReturnCorrectPrice_WhenMultipleProductsAndStrategiesPassedAndThresholdsExceeded()
    {
    }

    [Fact]
    public void GetTotalPrice_ShouldReturnCorrectPrice_WhenMultipleStrategiesPassedAndThresholdIsNotExceeded()
    {
    }
}