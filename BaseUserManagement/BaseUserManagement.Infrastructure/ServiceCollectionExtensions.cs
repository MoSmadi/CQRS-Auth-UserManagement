using BaseUserManagement.Domain.Authentication;
using BaseUserManagement.Domain.Users.Repositories;
using BaseUserManagement.Infrastructure.Authentication;
using BaseUserManagement.Infrastructure.Authentication.JwtSetup;
using BaseUserManagement.Infrastructure.Authentication.Options;
using BaseUserManagement.Infrastructure.Users.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BaseUserManagement.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        return services
                .AddRepositories()
                .AddProviders()
                .AddAJwtOptions(configuration);
    }
    
    private static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services
            .AddScoped<IUserRepository, UserRepository>();
    
    private static IServiceCollection AddProviders(this IServiceCollection services) =>
        services
            .AddScoped<IJwtProvider, JwtProvider>();

    private static IServiceCollection AddAJwtOptions(this IServiceCollection services, IConfiguration configuration) =>
        services
            .Configure<JwtOptions>(configuration.GetSection("JwtSettings"))
            .ConfigureOptions<JwtOptionsSetup>();
}