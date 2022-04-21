namespace BookStore.Application.Catalog.Books.Queries.Details;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Domain.Catalog.Factories.Books;
using Domain.Catalog.Models.Books;
using MediatR;

public class BookDetailsQuery : EntityCommand<int>, IRequest<Book>
{
    public class BookDetailsQueryHandler : IRequestHandler<BookDetailsQuery, Book>
    {
        private readonly IBookFactory bookFactory;

        public BookDetailsQueryHandler(IBookFactory bookFactory)
            => this.bookFactory = bookFactory;

        public Task<Book> Handle(
            BookDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var book = this.bookFactory
                .WithTitle("Some Title")
                .WithPrice(15.5m)
                .WithGenre(new Genre(
                    "Cool Genre",
                    "Some description"))
                .Build();

            return Task.FromResult(book);
        }
    }
}