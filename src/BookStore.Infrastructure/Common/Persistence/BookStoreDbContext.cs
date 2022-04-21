namespace BookStore.Infrastructure.Common.Persistence;

using Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

internal class BookStoreDbContext : IdentityDbContext<User>
{
}