namespace BookStore.Infrastructure.Sales;

using Common.Persistence;
using Domain.Sales.Models.Customers;
using Microsoft.EntityFrameworkCore;

internal interface ISalesDbContext : IDbContext
{
    DbSet<Address> Addresses { get; }

    DbSet<Customer> Customers { get; }
}