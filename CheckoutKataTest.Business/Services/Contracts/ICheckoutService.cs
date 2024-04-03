namespace CheckoutKataTest.Business.Services.Contracts;

public interface ICheckoutService
{
    void Scan(string item);
    int GetTotalPrice();
}