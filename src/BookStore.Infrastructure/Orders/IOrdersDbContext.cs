namespace BookStore.Infrastructure.Orders;

using Common.Persistence;
using Domain.Orders.Models.Customers;
using Microsoft.EntityFrameworkCore;

internal interface IOrdersDbContext : IDbContext
{
    DbSet<Customer> Customers { get; }
}