using BaseUserManagement.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BaseUserManagement.Domain;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomainConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddDomainServices();
    }

    private static IServiceCollection AddDomainServices(this IServiceCollection services) =>
        services
            .AddScoped<IUserService, UserService>();
}