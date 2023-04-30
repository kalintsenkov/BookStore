namespace BookStore.Application.Catalog.Books.Commands.Delete;

using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Contracts;
using Application.Common.Models;
using Domain.Catalog.Repositories;
using MediatR;

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
            var deleted = await this.bookRepository.Delete(
                request.Id,
                cancellationToken);

            await this.memoryDatabase.Remove("books:search");

            await this.memoryDatabase.Remove("books:" + request.Id);

            return deleted;
        }
    }
}