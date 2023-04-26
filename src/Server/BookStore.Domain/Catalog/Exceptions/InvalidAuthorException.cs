namespace BookStore.Domain.Catalog.Exceptions;

using Common;

public class InvalidAuthorException : BaseDomainException
{
    public InvalidAuthorException()
    {
    }

    public InvalidAuthorException(string error) => this.Error = error;
}