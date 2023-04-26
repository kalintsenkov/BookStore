namespace BookStore.Infrastructure.Catalog;

using Common.Persistence;
using Domain.Catalog.Models.Authors;
using Domain.Catalog.Models.Books;
using Microsoft.EntityFrameworkCore;

internal interface ICatalogDbContext : IDbContext
{
    DbSet<Book> CatalogBooks { get; }

    DbSet<Author> Authors { get; }
}