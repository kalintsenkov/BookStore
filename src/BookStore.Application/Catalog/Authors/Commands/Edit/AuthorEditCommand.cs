namespace BookStore.Application.Catalog.Authors.Commands.Edit;

using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Models;
using Common;
using Domain.Catalog.Repositories;
using MediatR;

public class AuthorEditCommand : AuthorCommand<AuthorEditCommand>, IRequest<Result<int>>
{
    public class AuthorEditCommandHandler : IRequestHandler<AuthorEditCommand, Result<int>>
    {
        private readonly IAuthorDomainRepository authorRepository;

        public AuthorEditCommandHandler(IAuthorDomainRepository authorRepository)
            => this.authorRepository = authorRepository;

        public async Task<Result<int>> Handle(
            AuthorEditCommand request,
            CancellationToken cancellationToken)
        {
            var author = await this.authorRepository.Find(
                request.Id,
                cancellationToken);

            if (author is null)
            {
                throw new NotFoundException(nameof(author), request.Id);
            }

            author
                .UpdateName(request.Name)
                .UpdateDescription(request.Description);

            await this.authorRepository.Save(author, cancellationToken);

            return author.Id;
        }
    }
}