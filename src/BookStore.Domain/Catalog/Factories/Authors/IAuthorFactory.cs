namespace BookStore.Domain.Catalog.Factories.Authors;

using Common;
using Models.Authors;

public interface IAuthorFactory : IFactory<Author>
{
    IAuthorFactory WithName(string name);

    IAuthorFactory WithDescription(string description);
}