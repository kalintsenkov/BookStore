namespace BookStore.Application;

using System.Reflection;
using Common;
using Common.Behaviors;
using Common.Contracts;
using Common.Mapping;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class ApplicationConfiguration
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .Configure<ApplicationSettings>(
                configuration.GetSection(nameof(ApplicationSettings)),
                options => options.BindNonPublicProperties = true)
            .AddAutoMapper(cfg => cfg
                .AddProfile(new MappingProfile(Assembly.GetExecutingAssembly())))
            .AddMediatR(Assembly.GetExecutingAssembly())
            .AddEventHandlers()
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

    private static IServiceCollection AddEventHandlers(
        this IServiceCollection services)
        => services
            .Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses(classes => classes
                    .AssignableTo(typeof(IEventHandler<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());
}