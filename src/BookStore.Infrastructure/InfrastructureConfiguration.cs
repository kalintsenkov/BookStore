namespace BookStore.Infrastructure;

using System.Text;
using Application.Common;
using Application.Common.Contracts;
using Application.Identity;
using Catalog;
using Common.Events;
using Common.Extensions;
using Common.Persistence;
using Common.Services;
using Domain.Common;
using Identity;
using Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Sales;
using StackExchange.Redis;

using static Domain.Common.Models.ModelConstants.Identity;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddDatabase(configuration)
            .AddRepositories()
            .AddIdentity(configuration)
            .AddTransient<IEventDispatcher, EventDispatcher>();

    private static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddDbContext<BookStoreDbContext>(options => options
                .UseSqlServer(
                    configuration.GetDefaultConnectionString(),
                    sqlServer => sqlServer.MigrationsAssembly(
                        typeof(BookStoreDbContext).Assembly.FullName)))
            .AddScoped<ICatalogDbContext>(provider => provider
                .GetService<BookStoreDbContext>()!)
            .AddScoped<ISalesDbContext>(provider => provider
                .GetService<BookStoreDbContext>()!)
            .AddTransient<IDbInitializer, BookStoreDbInitializer>();

    private static IServiceCollection AddMemoryDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddSingleton<IConnectionMultiplexer>(
                ConnectionMultiplexer.Connect(
                    configuration.GetRedisConnectionString()))
            .AddTransient<IMemoryDatabase, MemoryDatabase>();

    internal static IServiceCollection AddRepositories(
        this IServiceCollection services)
        => services
            .Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses(classes => classes
                    .AssignableTo(typeof(IDomainRepository<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime())
            .Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses(classes => classes
                    .AssignableTo(typeof(IQueryRepository<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

    private static IServiceCollection AddIdentity(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddTransient<IIdentity, IdentityService>()
            .AddTransient<IJwtGenerator, JwtGeneratorService>()
            .AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredLength = MinPasswordLength;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<BookStoreDbContext>();

        var secret = configuration
            .GetSection(nameof(ApplicationSettings))
            .GetValue<string>(nameof(ApplicationSettings.Secret));

        var key = Encoding.ASCII.GetBytes(secret);

        services
            .AddAuthentication(authentication =>
            {
                authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(bearer =>
            {
                bearer.RequireHttpsMetadata = false;
                bearer.SaveToken = true;
                bearer.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        return services;
    }
}