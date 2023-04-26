namespace BookStore.Domain.Catalog.Exceptions;

using Common;

public class InvalidBookException : BaseDomainException
{
    public InvalidBookException()
    {
    }

    public InvalidBookException(string error) => this.Error = error;
}