namespace BookStore.Infrastructure.Identity.Services;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using static Domain.Common.Models.ModelConstants.Common;

internal class JwtGeneratorService : IJwtGenerator
{
    private readonly IDateTime dateTime;
    private readonly UserManager<User> userManager;
    private readonly ApplicationSettings applicationSettings;

    public JwtGeneratorService(
        IDateTime dateTime,
        UserManager<User> userManager,
        IOptions<ApplicationSettings> applicationSettings)
    {
        this.dateTime = dateTime;
        this.userManager = userManager;
        this.applicationSettings = applicationSettings.Value;
    }

    public async Task<string> GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(this.applicationSettings.Secret);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.Email!)
            }),
            Expires = this.dateTime.Now.AddDays(7),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var isAdministrator = await this.userManager.IsInRoleAsync(
            user,
            AdministratorRoleName);

        if (isAdministrator)
        {
            tokenDescriptor.Subject.AddClaim(new Claim(
                ClaimTypes.Role,
                AdministratorRoleName));
        }

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var encryptedToken = tokenHandler.WriteToken(token);

        return encryptedToken;
    }
}