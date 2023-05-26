namespace BookStore.Application.Catalog.Books.Commands.Delete;

using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Contracts;
using Application.Common.Exceptions;
using Application.Common.Models;
using Domain.Catalog.Repositories;
using MediatR;
using static BooksCacheConstants;

public class BookDeleteCommand : EntityCommand<int>, IRequest<Result>
{
    public class BookDeleteCommandHandler : IRequestHandler<BookDeleteCommand, Result>
    {
        private readonly IDateTime dateTime;
        private readonly IMemoryDatabase memoryDatabase;
        private readonly IBookDomainRepository bookRepository;

        public BookDeleteCommandHandler(
            IDateTime dateTime,
            IMemoryDatabase memoryDatabase,
            IBookDomainRepository bookRepository)
        {
            this.dateTime = dateTime;
            this.memoryDatabase = memoryDatabase;
            this.bookRepository = bookRepository;
        }

        public async Task<Result> Handle(
            BookDeleteCommand request,
            CancellationToken cancellationToken)
        {
            var book = await this.bookRepository.Find(
                request.Id,
                cancellationToken);

            if (book is null)
            {
                throw new NotFoundException(nameof(book), request.Id);
            }

            book.Delete(this.dateTime.Now);

            await this.bookRepository.Save(book, cancellationToken);

            await this.memoryDatabase.Remove(BooksListingKey);

            await this.memoryDatabase.Remove(BookDetailsKey + request.Id);

            return Result.Success;
        }
    }
}