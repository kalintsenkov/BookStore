namespace BookStore.Infrastructure.Sales.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Application.Sales.Customers;
using Application.Sales.Customers.Queries.Common;
using AutoMapper;
using Common.Events;
using Common.Repositories;
using Data;
using Domain.Common;
using Domain.Sales.Exceptions;
using Domain.Sales.Models.Customers;
using Domain.Sales.Repositories;
using Microsoft.EntityFrameworkCore;

internal class CustomerRepository : DataRepository<ISalesDbContext, Customer, CustomerData>,
    ICustomerDomainRepository,
    ICustomerQueryRepository
{
    public CustomerRepository(
        ISalesDbContext db,
        IMapper mapper,
        IEventDispatcher eventDispatcher)
        : base(db, mapper, eventDispatcher)
    {
    }

    public async Task<Customer> FindByUser(
        string userId,
        CancellationToken cancellationToken = default)
        => this.Mapper.Map<Customer>(
            await this.Find(
                userId,
                customer => customer,
                customer => customer.Address!,
                cancellationToken));

    public async Task<int> GetCustomerId(
        string userId,
        CancellationToken cancellationToken = default)
        => await this.Find(
            userId,
            customer => customer.Id,
            cancellationToken: cancellationToken);

    public async Task<CustomerResponseModel?> Details(
        int id,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<CustomerResponseModel>(this
                .AllAsNoTracking()
                .Where(c => c.Id == id))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<int> Total(
        Specification<Customer> specification,
        CancellationToken cancellationToken = default)
        => await this
            .GetCustomersQuery(specification)
            .CountAsync(cancellationToken);

    public async Task<IEnumerable<CustomerResponseModel>> GetCustomersListing(
        Specification<Customer> specification,
        int skip = 0,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<CustomerResponseModel>(this
                .GetCustomersQuery(specification)
                .OrderBy(c => c.Id)
                .Skip(skip)
                .Take(take))
            .ToListAsync(cancellationToken);

    private async Task<T> Find<T>(
        string userId,
        Expression<Func<CustomerData, T>> selector,
        Expression<Func<CustomerData, AddressData>>? includeQuery = null,
        CancellationToken cancellationToken = default)
    {
        var query = this
            .AllAsNoTracking()
            .Where(u => u.UserId == userId);

        if (includeQuery is not null)
        {
            query = query.Include(includeQuery);
        }

        var customer = await query
            .Select(selector)
            .FirstOrDefaultAsync(cancellationToken);

        if (EqualityComparer<T>.Default.Equals(customer, default))
        {
            throw new InvalidCustomerException("This user is not a customer.");
        }

        return customer!;
    }

    private IQueryable<Customer> GetCustomersQuery(
        Specification<Customer> specification)
        => this.Mapper
            .ProjectTo<Customer>(this
                .AllAsNoTracking())
            .Where(specification);
}