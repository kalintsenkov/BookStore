namespace BookStore.Application.Catalog.Books.Commands.Delete;

using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Models;
using Domain.Catalog.Repositories;
using MediatR;

public class BookDeleteCommand : EntityCommand<int>, IRequest<Result>
{
    public class BookDeleteCommandHandler : IRequestHandler<BookDeleteCommand, Result>
    {
        private readonly IBookDomainRepository bookRepository;

        public BookDeleteCommandHandler(IBookDomainRepository bookRepository)
            => this.bookRepository = bookRepository;

        public async Task<Result> Handle(
            BookDeleteCommand request,
            CancellationToken cancellationToken)
            => await this.bookRepository.Delete(
                request.Id,
                cancellationToken);
    }
}