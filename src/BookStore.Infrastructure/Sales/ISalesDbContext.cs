namespace BookStore.Infrastructure.Sales;

using Common.Persistence;
using Domain.Sales.Models.Customers;
using Microsoft.EntityFrameworkCore;

internal interface ISalesDbContext : IDbContext
{
    DbSet<Customer> Customers { get; }
}