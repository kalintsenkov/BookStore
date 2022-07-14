namespace BookStore.Application.Catalog.Authors.Commands.Create;

using System.Threading;
using System.Threading.Tasks;
using Application.Common.Models;
using Common;
using Domain.Catalog.Factories.Authors;
using Domain.Catalog.Repositories;
using MediatR;

public class AuthorCreateCommand : AuthorCommand<AuthorCreateCommand>, IRequest<Result<int>>
{
    public class AuthorCreateCommandHandler : IRequestHandler<AuthorCreateCommand, Result<int>>
    {
        private readonly IAuthorFactory authorFactory;
        private readonly IAuthorDomainRepository authorRepository;

        public AuthorCreateCommandHandler(
            IAuthorFactory authorFactory,
            IAuthorDomainRepository authorRepository)
        {
            this.authorFactory = authorFactory;
            this.authorRepository = authorRepository;
        }

        public async Task<Result<int>> Handle(
            AuthorCreateCommand request,
            CancellationToken cancellationToken)
        {
            var author = this.authorFactory
                .WithName(request.Name)
                .WithDescription(request.Description)
                .Build();

            author = await this.authorRepository.Save(author, cancellationToken);

            return author.Id;
        }
    }
}