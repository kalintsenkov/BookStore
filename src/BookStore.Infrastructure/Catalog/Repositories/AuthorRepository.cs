namespace BookStore.Infrastructure.Catalog.Repositories;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Catalog.Authors;
using Application.Catalog.Authors.Queries.Books;
using Common.Repositories;
using Domain.Catalog.Models.Authors;
using Domain.Catalog.Repositories;
using Microsoft.EntityFrameworkCore;

internal class AuthorRepository : DataRepository<ICatalogDbContext, Author>,
    IAuthorDomainRepository,
    IAuthorQueryRepository
{
    public AuthorRepository(ICatalogDbContext db)
        : base(db)
    {
    }

    public async Task<Author?> Find(
        string name,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(a => a.Name == name)
            .FirstOrDefaultAsync(cancellationToken);

    public Task<IEnumerable<AuthorBooksResponseModel>> GetBooks(
        int id,
        CancellationToken cancellationToken = default)
    {
        throw new System.NotImplementedException();
    }
}