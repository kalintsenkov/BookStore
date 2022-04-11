namespace BookStore.Domain.Books.Repositories;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Models.Books;

public interface IBookRepository : IDomainRepository<Book>
{
    Task<Book?> Find(
        int id,
        CancellationToken cancellationToken = default);
}