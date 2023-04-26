namespace BookStore.Web.Features;

using System.Threading.Tasks;
using Application.Identity.Commands.Common;
using Application.Identity.Commands.Login;
using Application.Identity.Commands.Register;
using Microsoft.AspNetCore.Mvc;

public class IdentityController : ApiController
{
    [HttpPost]
    [Route(nameof(Login))]
    public async Task<ActionResult<UserResponseModel>> Login(
        UserLoginCommand command)
        => await this.Send(command);

    [HttpPost]
    [Route(nameof(Register))]
    public async Task<ActionResult<UserResponseModel>> Register(
        UserRegisterCommand command)
        => await this.Send(command);
}