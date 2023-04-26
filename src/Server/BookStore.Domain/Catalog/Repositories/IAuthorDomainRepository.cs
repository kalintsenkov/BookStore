namespace BookStore.Domain.Catalog.Repositories;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Models.Authors;

public interface IAuthorDomainRepository : IDomainRepository<Author>
{
    Task<Author?> Find(
        int id,
        CancellationToken cancellationToken = default);

    Task<Author?> Find(
        string name,
        CancellationToken cancellationToken = default);

    Task<bool> Delete(
        int id,
        CancellationToken cancellationToken = default);
}