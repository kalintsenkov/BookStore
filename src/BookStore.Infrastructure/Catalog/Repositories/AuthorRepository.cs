namespace BookStore.Infrastructure.Catalog.Repositories;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Catalog.Authors;
using Application.Catalog.Authors.Queries.Books;
using AutoMapper;
using Common.Repositories;
using Domain.Catalog.Models.Authors;
using Domain.Catalog.Models.Books;
using Domain.Catalog.Repositories;
using Microsoft.EntityFrameworkCore;

internal class AuthorRepository : DataRepository<ICatalogDbContext, Author>,
    IAuthorDomainRepository,
    IAuthorQueryRepository
{
    private readonly IMapper mapper;

    public AuthorRepository(ICatalogDbContext db, IMapper mapper)
        : base(db)
        => this.mapper = mapper;

    public async Task<Author?> Find(
        string name,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(a => a.Name == name)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<IEnumerable<AuthorBooksResponseModel>> GetBooks(
        int id,
        CancellationToken cancellationToken = default)
        => await this.mapper
            .ProjectTo<AuthorBooksResponseModel>(this
                .AllBooks()
                .Where(b => b.Author.Id == id))
            .ToListAsync(cancellationToken);

    private IQueryable<Book> AllBooks()
        => this
            .Data
            .Books
            .AsNoTracking();
}