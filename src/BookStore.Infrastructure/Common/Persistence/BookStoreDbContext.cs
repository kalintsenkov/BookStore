namespace BookStore.Infrastructure.Common.Persistence;

using System.Reflection;
using Domain.Catalog.Models.Authors;
using Domain.Catalog.Models.Books;
using Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

internal class BookStoreDbContext : IdentityDbContext<User>
{
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; } = default!;

    public DbSet<Genre> Genres { get; set; } = default!;

    public DbSet<Author> Authors { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}