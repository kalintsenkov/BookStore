namespace BookStore.Infrastructure.Catalog.Repositories;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Catalog.Authors;
using Application.Catalog.Authors.Queries.Common;
using Application.Catalog.Authors.Queries.Details;
using AutoMapper;
using Common.Events;
using Common.Repositories;
using Data;
using Domain.Catalog.Models.Authors;
using Domain.Catalog.Repositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

internal class AuthorRepository : DataRepository<ICatalogDbContext, Author, AuthorData>,
    IAuthorDomainRepository,
    IAuthorQueryRepository
{
    public AuthorRepository(
        ICatalogDbContext db,
        IMapper mapper,
        IEventDispatcher eventDispatcher)
        : base(db, mapper, eventDispatcher)
    {
    }

    public async Task<Author?> Find(
        int id,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<Author>(this
                .AllAsNoTracking()
                .Where(a => a.Id == id))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<Author?> Find(
        string name,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<Author>(this
                .AllAsNoTracking()
                .Where(a => a.Name == name))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<bool> Delete(
        int id,
        CancellationToken cancellationToken = default)
    {
        var author = await this.Data.Authors.FindAsync(id);

        if (author is null)
        {
            return false;
        }

        this.Data.Authors.Remove(author);

        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<AuthorDetailsResponseModel?> Details(
        int id,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<AuthorDetailsResponseModel>(this
                .AllAsNoTracking()
                .Where(a => a.Id == id))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<int> Total(
        Specification<Author> specification,
        CancellationToken cancellationToken = default)
        => await this
            .GetAuthorsQuery(specification)
            .CountAsync(cancellationToken);

    public async Task<IEnumerable<AuthorResponseModel>> GetAuthorsListing(
        Specification<Author> specification,
        int skip = 0,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<AuthorResponseModel>(this
                .GetAuthorsQuery(specification)
                .OrderBy(a => a.Name)
                .Skip(skip)
                .Take(take))
            .ToListAsync(cancellationToken);

    private IQueryable<Author> GetAuthorsQuery(
        Specification<Author> specification)
        => this.Mapper
            .ProjectTo<Author>(this
                .AllAsNoTracking())
            .Where(specification);
}