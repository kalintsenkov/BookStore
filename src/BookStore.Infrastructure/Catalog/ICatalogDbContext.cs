namespace BookStore.Infrastructure.Catalog;

using Common.Persistence;
using Data;
using Microsoft.EntityFrameworkCore;

internal interface ICatalogDbContext : IDbContext
{
    DbSet<BookData> Books { get; }

    DbSet<AuthorData> Authors { get; }
}