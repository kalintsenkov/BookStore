namespace BookStore.Infrastructure.Common.Extensions;

using Microsoft.Extensions.Configuration;

public static class ConfigurationExtensions
{
    public static string GetDefaultConnectionString(
        this IConfiguration configuration)
        => configuration.GetConnectionString("DefaultConnection");

    public static string GetRedisConnectionString(
        this IConfiguration configuration)
        => configuration.GetConnectionString("RedisConnection");
}