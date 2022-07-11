namespace BookStore.Infrastructure.Common.Persistence;

using System.Reflection;
using Catalog;
using Catalog.Data;
using Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sales;
using Sales.Data;

internal class BookStoreDbContext : IdentityDbContext<User>,
    ICatalogDbContext,
    ISalesDbContext
{
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {
    }

    public DbSet<BookData> Books { get; set; } = default!;

    public DbSet<AuthorData> Authors { get; set; } = default!;

    public DbSet<AddressData> Addresses { get; set; } = default!;

    public DbSet<CustomerData> Customers { get; set; } = default!;

    public DbSet<OrderData> Orders { get; set; } = default!;

    public DbSet<OrderedBookData> OrderedBooks { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}