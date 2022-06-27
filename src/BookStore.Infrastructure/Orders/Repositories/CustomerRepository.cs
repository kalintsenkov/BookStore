namespace BookStore.Infrastructure.Orders.Repositories;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Repositories;
using Domain.Orders.Models.Customers;
using Domain.Orders.Repositories;
using Microsoft.EntityFrameworkCore;

internal class CustomerRepository : DataRepository<IOrdersDbContext, Customer>, ICustomerDomainRepository
{
    public CustomerRepository(IOrdersDbContext db)
        : base(db)
    {
    }

    public async Task<Customer?> Find(
        int id,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
}