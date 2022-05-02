namespace BookStore.Application.Catalog.Authors;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Contracts;
using Domain.Catalog.Models.Authors;
using Domain.Common;
using Queries.Common;
using Queries.Details;

public interface IAuthorQueryRepository : IQueryRepository<Author>
{
    Task<AuthorDetailsResponseModel?> Details(
        int id,
        CancellationToken cancellationToken = default);

    Task<int> Total(
        Specification<Author> specification,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<AuthorResponseModel>> GetAuthorsListing(
        Specification<Author> specification,
        int skip = 0,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default);
}