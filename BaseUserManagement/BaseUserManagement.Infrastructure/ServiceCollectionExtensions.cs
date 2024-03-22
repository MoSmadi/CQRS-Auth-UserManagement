using BaseUserManagement.Domain.Authentication;
using BaseUserManagement.Domain.Users.Repositories;
using BaseUserManagement.Infrastructure.Authentication;
using BaseUserManagement.Infrastructure.Authentication.JwtSetup;
using BaseUserManagement.Infrastructure.Authentication.Options;
using BaseUserManagement.Infrastructure.Users.Mappers;
using BaseUserManagement.Infrastructure.Users.Repositories;
using Microsoft.EntityFrameworkCore;
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
                .AddMappers()
                .AddDbConnection(configuration)
                .AddAJwtOptions(configuration);
    }
    
    private static IServiceCollection AddMappers(this IServiceCollection services) =>
        services
            .AddSingleton<UserMapper>();
    
    private static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services
            .AddScoped<IUserRepository, UserRepository>();
    
    private static IServiceCollection AddProviders(this IServiceCollection services) =>
        services
            .AddScoped<IJwtProvider, JwtProvider>();

    private static IServiceCollection AddDbConnection(this IServiceCollection services, IConfiguration configuration) =>
        services
            .AddDbContext<BaseDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
    
    private static IServiceCollection AddAJwtOptions(this IServiceCollection services, IConfiguration configuration) =>
        services
            .Configure<JwtOptions>(configuration.GetSection("JwtSettings"))
            .ConfigureOptions<JwtOptionsSetup>();
}