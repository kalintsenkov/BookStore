namespace BookStore.Application.Identity;

using System.Threading.Tasks;
using Commands.Common;
using Common.Models;

public interface IIdentity
{
    Task<Result<IUser>> Register(UserRequestModel userRequest);

    Task<Result<UserResponseModel>> Login(UserRequestModel userRequest);
}