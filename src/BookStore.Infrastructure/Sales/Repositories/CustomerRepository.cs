namespace BookStore.Infrastructure.Sales.Repositories;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Repositories;
using Domain.Sales.Models.Customers;
using Domain.Sales.Repositories;
using Microsoft.EntityFrameworkCore;

internal class CustomerRepository : DataRepository<ISalesDbContext, Customer>, ICustomerDomainRepository
{
    public CustomerRepository(ISalesDbContext db)
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