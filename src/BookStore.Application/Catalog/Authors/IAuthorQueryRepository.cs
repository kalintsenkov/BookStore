namespace BookStore.Application.Catalog.Authors;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Books;
using Common.Contracts;
using Domain.Catalog.Models.Authors;

public interface IAuthorQueryRepository : IQueryRepository<Author>
{
    Task<IEnumerable<AuthorBooksResponseModel>> GetBooks(
        int id,
        CancellationToken cancellationToken = default);
}