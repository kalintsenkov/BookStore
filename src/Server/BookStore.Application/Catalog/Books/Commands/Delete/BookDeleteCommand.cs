namespace BookStore.Application.Catalog.Books.Commands.Delete;

using System;
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
        private readonly IMemoryDatabase memoryDatabase;
        private readonly IBookDomainRepository bookRepository;

        public BookDeleteCommandHandler(
            IMemoryDatabase memoryDatabase,
            IBookDomainRepository bookRepository)
        {
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

            book.Delete(DateTime.UtcNow);

            await this.bookRepository.Save(book, cancellationToken);

            await this.memoryDatabase.Remove(BooksListingKey);

            await this.memoryDatabase.Remove(BookDetailsKey + request.Id);

            return Result.Success;
        }
    }
}