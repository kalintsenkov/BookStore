namespace BookStore.Infrastructure.Sales.Repositories;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Sales.Customers;
using Application.Sales.Customers.Queries.Common;
using AutoMapper;
using Common.Events;
using Common.Repositories;
using Data;
using Domain.Common;
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

    public async Task<Customer?> Find(
        int id,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<Customer>(this
                .AllAsNoTracking()
                .Where(c => c.Id == id))
            .FirstOrDefaultAsync(cancellationToken);

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

    private IQueryable<Customer> GetCustomersQuery(
        Specification<Customer> specification)
        => this.Mapper
            .ProjectTo<Customer>(this
                .AllAsNoTracking())
            .Where(specification);
}