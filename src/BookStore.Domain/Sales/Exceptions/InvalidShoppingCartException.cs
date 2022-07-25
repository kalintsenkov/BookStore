namespace BookStore.Domain.Sales.Exceptions;

using Common;

public class InvalidShoppingCartException : BaseDomainException
{
    public InvalidShoppingCartException()
    {
    }

    public InvalidShoppingCartException(string error) => this.Error = error;
}