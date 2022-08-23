namespace BookStore.Web;

using Application.Common.Contracts;
using Application.Common.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Services;

public static class WebConfiguration
{
    public static IServiceCollection AddWebComponents(
        this IServiceCollection services)
    {
        services
            .AddScoped<ICurrentUser, CurrentUserService>()
            .AddSwaggerGen()
            .AddValidatorsFromAssemblyContaining<Result>()
            .AddControllers()
            .AddNewtonsoftJson();

        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        return services;
    }
}