namespace BookStore.Application.Catalog.Books;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Contracts;
using Domain.Catalog.Models.Books;
using Domain.Common;
using Queries.Common;
using Queries.Search;

public interface IBookQueryRepository : IQueryRepository<Book>
{
    Task<BookResponseModel?> Details(
        int id,
        CancellationToken cancellationToken = default);

    Task<int> Total(
        Specification<Book> specification,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<BookResponseModel>> GetBooksListing(
        Specification<Book> specification,
        BooksSearchSortOrder sortOrder,
        int skip = 0,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default);
}