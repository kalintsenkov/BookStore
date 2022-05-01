namespace BookStore.Application.Catalog.Authors.Queries.Books;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class AuthorBooksQuery : IRequest<IEnumerable<AuthorBooksResponseModel>>
{
    public int Id { get; init; }

    public class AuthorBooksQueryHandler : IRequestHandler<AuthorBooksQuery, IEnumerable<AuthorBooksResponseModel>>
    {
        private readonly IAuthorQueryRepository authorRepository;

        public AuthorBooksQueryHandler(IAuthorQueryRepository authorRepository)
            => this.authorRepository = authorRepository;

        public async Task<IEnumerable<AuthorBooksResponseModel>> Handle(
            AuthorBooksQuery request,
            CancellationToken cancellationToken)
            => await this.authorRepository.GetBooks(
                request.Id,
                cancellationToken);
    }
}