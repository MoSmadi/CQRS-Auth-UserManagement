using BaseUserManagement.Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BaseUserManagement.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddBehaviors();
    }

    private static IServiceCollection AddBehaviors(this IServiceCollection services)
    {
        return services
            .AddMediatR(ApplicationAssemblyReference.Assembly)
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>))
            .AddValidatorsFromAssembly(typeof(ServiceCollectionExtensions).Assembly, includeInternalTypes: true);
    }
}