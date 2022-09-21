namespace BookStore.Infrastructure.Common.Persistence;

using System.Reflection;
using Catalog;
using Domain.Catalog.Models.Authors;
using Domain.Sales.Models.Customers;
using Domain.Sales.Models.Orders;
using Domain.Sales.Models.ShoppingCarts;
using Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sales;

internal class BookStoreDbContext : IdentityDbContext<User>,
    ICatalogDbContext,
    ISalesDbContext
{
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {
    }

    public DbSet<Domain.Catalog.Models.Books.Book> CatalogBooks { get; set; } = default!;

    public DbSet<Domain.Sales.Models.Books.Book> SalesBooks { get; set; } = default!;

    public DbSet<Author> Authors { get; set; } = default!;

    public DbSet<Address> Addresses { get; set; } = default!;

    public DbSet<Customer> Customers { get; set; } = default!;

    public DbSet<Order> Orders { get; set; } = default!;

    public DbSet<OrderedBook> OrderedBooks { get; set; } = default!;

    public DbSet<ShoppingCart> ShoppingCarts { get; set; } = default!;

    public DbSet<ShoppingCartBook> ShoppingCartBooks { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}