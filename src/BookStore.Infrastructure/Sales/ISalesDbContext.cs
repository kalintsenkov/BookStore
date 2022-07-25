namespace BookStore.Infrastructure.Sales;

using Catalog.Data;
using Common.Persistence;
using Data;
using Microsoft.EntityFrameworkCore;

internal interface ISalesDbContext : IDbContext
{
    DbSet<AddressData> Addresses { get; }

    DbSet<CustomerData> Customers { get; }

    DbSet<BookData> Books { get; }

    DbSet<OrderData> Orders { get; }

    DbSet<OrderedBookData> OrderedBooks { get; }

    DbSet<ShoppingCartData> ShoppingCarts { get; }

    DbSet<ShoppingCartBookData> ShoppingCartBooks { get; }
}