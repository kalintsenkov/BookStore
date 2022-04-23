namespace BookStore.Application.Catalog.Books.Queries.Details;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class BookDetailsQuery : IRequest<BookDetailsResponseModel>
{
    public int Id { get; init; }

    public class BookDetailsQueryHandler : IRequestHandler<BookDetailsQuery, BookDetailsResponseModel?>
    {
        private readonly IBookQueryRepository bookRepository;

        public BookDetailsQueryHandler(IBookQueryRepository bookRepository)
            => this.bookRepository = bookRepository;

        public async Task<BookDetailsResponseModel?> Handle(
            BookDetailsQuery request,
            CancellationToken cancellationToken)
            => await this.bookRepository.Details(
                request.Id,
                cancellationToken);
    }
}