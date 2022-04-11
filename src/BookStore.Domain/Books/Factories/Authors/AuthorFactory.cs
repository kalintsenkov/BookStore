namespace BookStore.Domain.Books.Factories.Authors;

using Exceptions;
using Models.Authors;

internal class AuthorFactory : IAuthorFactory
{
    private string authorName = default!;
    private string authorDescription = default!;

    private bool isNameSet = false;
    private bool isDescriptionSet = false;

    public IAuthorFactory WithName(string name)
    {
        this.authorName = name;
        this.isNameSet = true;

        return this;
    }

    public IAuthorFactory WithDescription(string description)
    {
        this.authorDescription = description;
        this.isDescriptionSet = true;

        return this;
    }

    public Author Build()
    {
        if (!this.isNameSet || !this.isDescriptionSet)
        {
            throw new InvalidAuthorException("Name and description must have a value.");
        }

        return new Author(this.authorName, this.authorDescription);
    }
}