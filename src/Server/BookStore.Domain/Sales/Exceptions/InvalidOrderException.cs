namespace BookStore.Domain.Sales.Exceptions;

using Common;

public class InvalidOrderException : BaseDomainException
{
    public InvalidOrderException()
    {
    }

    public InvalidOrderException(string error) => this.Error = error;
}