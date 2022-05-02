namespace BookStore.Application.Catalog.Books.Commands.ChangeAvailability;

using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Exceptions;
using Application.Common.Models;
using Domain.Catalog.Repositories;
using MediatR;

public class BookChangeAvailabilityCommand : EntityCommand<int>, IRequest<Result>
{
    public class BookChangeAvailabilityCommandHandler : IRequestHandler<BookChangeAvailabilityCommand, Result>
    {
        private readonly IBookDomainRepository bookRepository;

        public BookChangeAvailabilityCommandHandler(IBookDomainRepository bookRepository)
            => this.bookRepository = bookRepository;

        public async Task<Result> Handle(
            BookChangeAvailabilityCommand request,
            CancellationToken cancellationToken)
        {
            var book = await this.bookRepository.Find(
                request.Id,
                cancellationToken);

            if (book is null)
            {
                throw new NotFoundException(
                    nameof(book),
                    request.Id);
            }

            book.ChangeAvailability();

            await this.bookRepository.Save(book, cancellationToken);

            return Result.Success;
        }
    }
}