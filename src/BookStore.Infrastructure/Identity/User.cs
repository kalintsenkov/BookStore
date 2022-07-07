namespace BookStore.Infrastructure.Identity;

using Domain.Identity.Models;
using Microsoft.AspNetCore.Identity;

public class User : IdentityUser, IUser
{
    internal User(string email)
        : base(email) 
        => this.Email = email;
}