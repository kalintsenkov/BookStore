namespace BookStore.Infrastructure.Catalog.Repositories;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Catalog.Books;
using Application.Catalog.Books.Queries.Details;
using AutoMapper;
using Common.Repositories;
using Domain.Catalog.Models.Books;
using Domain.Catalog.Repositories;
using Microsoft.EntityFrameworkCore;

internal class BookRepository : DataRepository<ICatalogDbContext, Book>,
    IBookDomainRepository,
    IBookQueryRepository
{
    private readonly IMapper mapper;

    public BookRepository(ICatalogDbContext db, IMapper mapper)
        : base(db)
        => this.mapper = mapper;

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
        var book = await this.Data.Books.FindAsync(id);

        if (book is null)
        {
            return false;
        }

        this.Data.Books.Remove(book);

        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<BookDetailsResponseModel?> Details(
        int id,
        CancellationToken cancellationToken = default)
        => await this.mapper
            .ProjectTo<BookDetailsResponseModel>(this
                .AllAsNoTracking()
                .Where(b => b.Id == id))
            .FirstOrDefaultAsync(cancellationToken);
}