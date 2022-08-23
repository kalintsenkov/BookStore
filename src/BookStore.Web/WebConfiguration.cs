namespace BookStore.Web;

using Application.Common.Contracts;
using Application.Common.Models;
using FluentValidation.AspNetCore;
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
            .AddControllers()
            .AddFluentValidation(validation => validation
                .RegisterValidatorsFromAssemblyContaining<Result>())
            .AddNewtonsoftJson();

        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        return services;
    }
}