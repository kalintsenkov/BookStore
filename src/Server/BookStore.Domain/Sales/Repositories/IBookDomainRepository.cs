namespace BookStore.Domain.Sales.Repositories;

using System.Threading.Tasks;
using System.Threading;
using Common;
using Models.Books;

public interface IBookDomainRepository : IDomainRepository<Book>
{
    Task<Book?> Find(
        int id,
        CancellationToken cancellationToken = default);
}