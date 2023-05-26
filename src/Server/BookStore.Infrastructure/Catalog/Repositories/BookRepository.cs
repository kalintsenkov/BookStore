namespace BookStore.Infrastructure.Catalog.Repositories;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Catalog.Books;
using Application.Catalog.Books.Queries.Common;
using Application.Catalog.Books.Queries.Details;
using Application.Catalog.Books.Queries.Search;
using AutoMapper;
using Common.Events;
using Common.Extensions;
using Common.Repositories;
using Domain.Catalog.Models.Books;
using Domain.Catalog.Repositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

internal class BookRepository : DataRepository<ICatalogDbContext, Book>,
    IBookDomainRepository,
    IBookQueryRepository
{
    public BookRepository(
        ICatalogDbContext db,
        IMapper mapper,
        IEventDispatcher eventDispatcher)
        : base(db, mapper, eventDispatcher)
    {
    }

    public async Task<Book?> Find(
        int id,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(b => b.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<BookDetailsResponseModel?> Details(
        int id,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<BookDetailsResponseModel>(this
                .AllAsNoTracking()
                .Where(b => b.Id == id))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<int> Total(
        Specification<Book> specification,
        CancellationToken cancellationToken = default)
        => await this
            .GetBooksQuery(specification)
            .CountAsync(cancellationToken);

    public async Task<IEnumerable<BookResponseModel>> GetBooksListing(
        Specification<Book> specification,
        BooksSearchSortOrder sortOrder,
        int skip = 0,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<BookResponseModel>(this
                .GetBooksQuery(specification)
                .Sort(sortOrder)
                .Skip(skip)
                .Take(take))
            .ToListAsync(cancellationToken);

    private IQueryable<Book> GetBooksQuery(
        Specification<Book> specification)
        => this
            .AllAsNoTracking()
            .Where(specification);
}