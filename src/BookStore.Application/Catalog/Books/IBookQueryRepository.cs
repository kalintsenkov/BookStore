namespace BookStore.Application.Catalog.Books;

using System.Threading;
using System.Threading.Tasks;
using Common.Contracts;
using Domain.Catalog.Models.Books;
using Queries.Details;

public interface IBookQueryRepository : IQueryRepository<Book>
{
    Task<BookDetailsResponseModel?> Details(
        int id,
        CancellationToken cancellationToken = default);
}