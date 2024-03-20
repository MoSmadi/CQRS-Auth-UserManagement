using BaseUserManagement.Infrastructure.Authentication.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BaseUserManagement.Infrastructure.Authentication.JwtSetup;

public class JwtOptionsSetup : IConfigureNamedOptions<JwtOptions>
{
    private const string SectionName = "JwtSettings";
    private readonly IConfiguration _configuration;

    public JwtOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(JwtOptions options)
    {
        _configuration.GetSection(SectionName).Bind(options);
    }
    
    public void Configure(string? name, JwtOptions options) => Configure(options);
}