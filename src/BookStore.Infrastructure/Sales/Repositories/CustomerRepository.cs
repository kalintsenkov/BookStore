namespace BookStore.Infrastructure.Sales.Repositories;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Sales.Customers;
using AutoMapper;
using Common.Events;
using Common.Repositories;
using Data;
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
                .All()
                .Where(a => a.Id == id))
            .FirstOrDefaultAsync(cancellationToken);
}