namespace BookStore.Application.Identity.Commands.Common;

public abstract class UserRequestModel
{
    protected internal UserRequestModel(string email, string password)
    {
        this.Email = email;
        this.Password = password;
    }

    public string Email { get; }

    public string Password { get; }
}