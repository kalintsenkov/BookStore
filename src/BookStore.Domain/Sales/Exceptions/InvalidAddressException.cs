namespace BookStore.Domain.Sales.Exceptions;

using Common;

public class InvalidAddressException : BaseDomainException
{
    public InvalidAddressException()
    {
    }

    public InvalidAddressException(string error) => this.Error = error;
}