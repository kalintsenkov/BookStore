namespace BookStore.Application.Identity.Commands.Login;

using System.Threading;
using System.Threading.Tasks;
using Application.Common.Models;
using Common;
using MediatR;

public class UserLoginCommand : UserRequestModel, IRequest<Result<UserResponseModel>>
{
    public UserLoginCommand(
        string fullName,
        string email,
        string password)
        : base(fullName, email, password)
    {
    }

    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, Result<UserResponseModel>>
    {
        private readonly IIdentity identity;

        public UserLoginCommandHandler(IIdentity identity)
            => this.identity = identity;

        public async Task<Result<UserResponseModel>> Handle(
            UserLoginCommand request,
            CancellationToken cancellationToken)
            => await this.identity.Login(request);
    }
}