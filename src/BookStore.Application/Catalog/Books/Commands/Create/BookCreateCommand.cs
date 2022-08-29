namespace BookStore.Application.Catalog.Books.Commands.Create;

using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Models;
using Common;
using Domain.Catalog.Factories.Books;
using Domain.Catalog.Models.Books;
using Domain.Catalog.Repositories;
using Domain.Common.Models;
using MediatR;

public class BookCreateCommand : BookCommand<BookCreateCommand>, IRequest<Result<int>>
{
    public class BookCreateCommandHandler : IRequestHandler<BookCreateCommand, Result<int>>
    {
        private readonly IBookFactory bookFactory;
        private readonly IBookDomainRepository bookRepository;
        private readonly IAuthorDomainRepository authorRepository;

        public BookCreateCommandHandler(
            IBookFactory bookFactory,
            IBookDomainRepository bookRepository,
            IAuthorDomainRepository authorRepository)
        {
            this.bookFactory = bookFactory;
            this.bookRepository = bookRepository;
            this.authorRepository = authorRepository;
        }

        public async Task<Result<int>> Handle(
            BookCreateCommand request,
            CancellationToken cancellationToken)
        {
            var author = await this.authorRepository.Find(
                request.Author,
                cancellationToken);

            if (author is null)
            {
                throw new NotFoundException(nameof(author), request.Author);
            }

            var book = this.bookFactory
                .WithTitle(request.Title)
                .WithPrice(request.Price)
                .WithQuantity(request.Quantity)
                .WithDescription(request.Description)
                .WithGenre(Enumeration.FromName<Genre>(
                    request.Genre))
                .FromAuthor(author)
                .Build();

            await this.bookRepository.Save(book, cancellationToken);

            return book.Id;
        }
    }
}