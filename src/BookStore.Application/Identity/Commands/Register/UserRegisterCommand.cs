namespace BookStore.Application.Identity.Commands.Register;

using System.Threading;
using System.Threading.Tasks;
using Common;
using MediatR;

public class UserRegisterCommand : UserRequestModel, IRequest<Result>
{
    public UserRegisterCommand(
        string email,
        string password,
        string confirmPassword)
        : base(email, password)
        => this.ConfirmPassword = confirmPassword;

    public string ConfirmPassword { get; }

    public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, Result>
    {
        private readonly IIdentity identity;

        public UserRegisterCommandHandler(IIdentity identity)
            => this.identity = identity;

        public async Task<Result> Handle(
            UserRegisterCommand request,
            CancellationToken cancellationToken)
            => await this.identity.Register(request);
    }
}