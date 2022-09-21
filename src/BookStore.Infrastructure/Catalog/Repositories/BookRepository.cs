namespace BookStore.Infrastructure.Catalog.Repositories;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Catalog.Books;
using Application.Catalog.Books.Queries.Common;
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

    public async Task<bool> Delete(
        int id,
        CancellationToken cancellationToken = default)
    {
        var book = await this.Data.CatalogBooks.FindAsync(id);

        if (book is null)
        {
            return false;
        }

        this.Data.CatalogBooks.Remove(book);

        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<BookResponseModel?> Details(
        int id,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<BookResponseModel>(this
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