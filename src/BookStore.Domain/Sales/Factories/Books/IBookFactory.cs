namespace BookStore.Domain.Sales.Factories.Books;

using Common;
using Models.Books;

public interface IBookFactory : IFactory<Book>
{
    IBookFactory WithTitle(string title);

    IBookFactory WithPrice(decimal price);

    IBookFactory WithQuantity(int quantity);
}