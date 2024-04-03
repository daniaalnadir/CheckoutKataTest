# Checkout Code Kata

The logic in this program contains the solution to this [code kata](http://codekata.com/kata/kata09-back-to-the-checkout/).

I have decided to go for the strategy pattern as this allows for extensibility and complies with the open/closed principle.
In other words we can extend but not modify strategies. This means we don't have to
have messy "If/Else" blocks which is a code smell as it makes code difficult to read and makes testing easier because it's harder to miss execution paths.
Furthermore this reduces coupling to a single class and instead the coupling is between the strategy and the interface.

The solution also complies with the Single Responsibility Principle such that each service has its own job and does nothing else.
For example the CheckoutService only performs actions to do with checking out. The strategy services only perform specific jobs. 
The product repository which acts as the database only deals with getting products.

I have added unit tests which cover 100% of the business/core layer. I went for a TDD approach by thinking 
about and setting the tests first and then refactoring as I went along.

I have included sample usage of the program with a console application. Please also see the tests.

Lastly, just to show the extensibility side, i have added another strategy "XForThePriceOfY" 
to show that the program is extensible to not just one strategy but multiple strategies and the usage of this is 
shown in the console application.

Some thoughts regarding requirements:

Do we wanted the discount to stack ?
Do we want to set priority of the strategies ? 




