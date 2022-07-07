namespace BookStore.Application.Identity.Commands.Common;

public abstract class UserRequestModel
{
    protected UserRequestModel(string fullName, string email, string password)
    {
        this.FullName = fullName;
        this.Email = email;
        this.Password = password;
    }

    public string FullName { get; }

    public string Email { get; }

    public string Password { get; }
}