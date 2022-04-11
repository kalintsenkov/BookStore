namespace BookStore.Domain.Books.Exceptions;

using Common;

public class InvalidAuthorException : BaseDomainException
{
    public InvalidAuthorException()
    {
    }

    public InvalidAuthorException(string error) => this.Error = error;
}