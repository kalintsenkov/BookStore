namespace BookStore.Application.Identity.Commands.Register;

using Common;

public class UserRegisterRequestModel : UserRequestModel
{
    internal UserRegisterRequestModel(
        string fullName, 
        string email, 
        string password)
        : base(email, password) 
        => this.FullName = fullName;

    public string FullName { get; }
}