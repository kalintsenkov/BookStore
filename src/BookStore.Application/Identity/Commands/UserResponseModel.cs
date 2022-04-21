namespace BookStore.Application.Identity.Commands;

public class UserResponseModel
{
    public UserResponseModel(string token) => this.Token = token;

    public string Token { get; }
}