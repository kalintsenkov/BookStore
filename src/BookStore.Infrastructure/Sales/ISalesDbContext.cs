namespace BookStore.Infrastructure.Sales;

using Common.Persistence;
using Domain.Sales.Models.Books;
using Domain.Sales.Models.Customers;
using Domain.Sales.Models.Orders;
using Domain.Sales.Models.ShoppingCarts;
using Microsoft.EntityFrameworkCore;

internal interface ISalesDbContext : IDbContext
{
    DbSet<Address> Addresses { get; }

    DbSet<Book> SalesBooks { get; }

    DbSet<Customer> Customers { get; }

    DbSet<Order> Orders { get; }

    DbSet<OrderedBook> OrderedBooks { get; }

    DbSet<ShoppingCart> ShoppingCarts { get; }

    DbSet<ShoppingCartBook> ShoppingCartBooks { get; }
}