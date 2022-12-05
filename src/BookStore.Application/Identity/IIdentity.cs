namespace BookStore.Application.Identity;

using System.Threading.Tasks;
using Commands.Common;
using Commands.Register;
using Common.Models;

public interface IIdentity
{
    Task<Result<UserResponseModel>> Register(UserRegisterRequestModel userRequest);

    Task<Result<UserResponseModel>> Login(UserRequestModel userRequest);
}