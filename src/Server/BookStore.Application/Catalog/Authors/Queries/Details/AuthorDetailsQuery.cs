namespace BookStore.Application.Catalog.Authors.Queries.Details;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class AuthorDetailsQuery : IRequest<AuthorDetailsResponseModel?>
{
    public int Id { get; init; }

    public class AuthorDetailsQueryHandler : IRequestHandler<AuthorDetailsQuery, AuthorDetailsResponseModel?>
    {
        private readonly IAuthorQueryRepository authorRepository;

        public AuthorDetailsQueryHandler(IAuthorQueryRepository authorRepository)
            => this.authorRepository = authorRepository;

        public async Task<AuthorDetailsResponseModel?> Handle(
            AuthorDetailsQuery request,
            CancellationToken cancellationToken)
            => await this.authorRepository.Details(
                request.Id,
                cancellationToken);
    }
}