namespace BookStore.Infrastructure.Common.Persistence;

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Catalog;
using Domain.Catalog.Models.Authors;
using Domain.Catalog.Models.Books;
using Domain.Common.Models;
using Domain.Sales.Models.Customers;
using Events;
using Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sales;

internal class BookStoreDbContext : IdentityDbContext<User>,
    ICatalogDbContext,
    ISalesDbContext
{
    private readonly IEventDispatcher eventDispatcher;
    private readonly Stack<object> savesChangesTracker;

    public BookStoreDbContext(
        DbContextOptions<BookStoreDbContext> options,
        IEventDispatcher eventDispatcher)
        : base(options)
    {
        this.eventDispatcher = eventDispatcher;

        this.savesChangesTracker = new Stack<object>();
    }

    public DbSet<Book> Books { get; set; } = default!;

    public DbSet<Author> Authors { get; set; } = default!;

    public DbSet<Address> Addresses { get; set; } = default!;

    public DbSet<Customer> Customers { get; set; } = default!;

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        this.savesChangesTracker.Push(new object());

        var entities = this.ChangeTracker
            .Entries<IEntity>()
            .Select(e => e.Entity)
            .Where(e => e.Events.Any())
            .ToArray();

        foreach (var entity in entities)
        {
            var events = entity.Events.ToArray();

            entity.ClearEvents();

            foreach (var domainEvent in events)
            {
                await this.eventDispatcher.Dispatch(domainEvent);
            }
        }

        this.savesChangesTracker.Pop();

        if (!this.savesChangesTracker.Any())
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        return 0;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}