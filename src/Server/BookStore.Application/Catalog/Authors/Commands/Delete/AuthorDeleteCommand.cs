namespace BookStore.Application.Catalog.Authors.Commands.Delete;

using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Models;
using Domain.Catalog.Repositories;
using MediatR;

public class AuthorDeleteCommand : EntityCommand<int>, IRequest<Result>
{
    public class AuthorDeleteCommandHandler : IRequestHandler<AuthorDeleteCommand, Result>
    {
        private readonly IAuthorDomainRepository authorRepository;

        public AuthorDeleteCommandHandler(IAuthorDomainRepository authorRepository)
            => this.authorRepository = authorRepository;

        public async Task<Result> Handle(
            AuthorDeleteCommand request,
            CancellationToken cancellationToken)
            => await this.authorRepository.Delete(
                request.Id,
                cancellationToken);
    }
}