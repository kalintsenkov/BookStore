namespace BookStore.Application.Sales.Customers;

using Common.Contracts;
using Domain.Sales.Models.Customers;

public interface ICustomerQueryRepository : IQueryRepository<Customer>
{
}