namespace BookStore.Application.Catalog.Books.Commands.Create;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Domain.Catalog.Factories.Books;
using Domain.Catalog.Models.Books;
using Domain.Catalog.Repositories;
using Domain.Common.Models;
using MediatR;

public class BookCreateCommand : IRequest<Result<int>>
{
    public string Title { get; init; } = default!;

    public decimal Price { get; init; }

    public string Genre { get; init; } = default!;

    public class BookCreateCommandHandler : IRequestHandler<BookCreateCommand, Result<int>>
    {
        private readonly IBookFactory bookFactory;
        private readonly IBookDomainRepository bookRepository;

        public BookCreateCommandHandler(
            IBookFactory bookFactory,
            IBookDomainRepository bookRepository)
        {
            this.bookFactory = bookFactory;
            this.bookRepository = bookRepository;
        }

        public async Task<Result<int>> Handle(
            BookCreateCommand request,
            CancellationToken cancellationToken)
        {
            var book = this.bookFactory
                .WithTitle(request.Title)
                .WithPrice(request.Price)
                .WithGenre(Enumeration.FromName<Genre>(
                    request.Genre))
                .Build();

            await this.bookRepository.Save(book, cancellationToken);

            return book.Id;
        }
    }
}