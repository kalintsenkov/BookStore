namespace BookStore.Application.Catalog.Books.Queries.Details;

using System.Threading;
using System.Threading.Tasks;
using Common;
using MediatR;

public class BookDetailsQuery : IRequest<BookResponseModel?>
{
    public int Id { get; init; }

    public class BookDetailsQueryHandler : IRequestHandler<BookDetailsQuery, BookResponseModel?>
    {
        private readonly IBookQueryRepository bookRepository;

        public BookDetailsQueryHandler(IBookQueryRepository bookRepository)
            => this.bookRepository = bookRepository;

        public async Task<BookResponseModel?> Handle(
            BookDetailsQuery request,
            CancellationToken cancellationToken)
            => await this.bookRepository.Details(
                request.Id,
                cancellationToken);
    }
}