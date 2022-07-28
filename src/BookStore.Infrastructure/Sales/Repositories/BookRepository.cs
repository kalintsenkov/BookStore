namespace BookStore.Infrastructure.Sales.Repositories;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Catalog.Data;
using Common.Events;
using Common.Repositories;
using Domain.Sales.Models.Books;
using Domain.Sales.Repositories;
using Microsoft.EntityFrameworkCore;

internal class BookRepository : DataRepository<ISalesDbContext, Book, BookData>,
    IBookDomainRepository
{
    public BookRepository(
        ISalesDbContext db,
        IMapper mapper,
        IEventDispatcher eventDispatcher)
        : base(db, mapper, eventDispatcher)
    {
    }

    public async Task<Book?> Find(
        int id,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<Book>(this
                .AllAsNoTracking()
                .Where(b => b.Id == id))
            .FirstOrDefaultAsync(cancellationToken);
}