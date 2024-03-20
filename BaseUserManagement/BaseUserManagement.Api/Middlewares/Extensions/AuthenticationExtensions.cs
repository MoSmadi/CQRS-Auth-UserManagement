using System.IdentityModel.Tokens.Jwt;
using BaseUserManagement.Api.Middlewares.Constants;
using Microsoft.AspNetCore.Http;

namespace BaseUserManagement.Api.Middlewares.Extensions;

public static class AuthenticationExtensions
{
    public static bool HasAuthorizationKey(this IHeaderDictionary headers)
    {
        return headers.ContainsKey(AuthenticationConstants.AuthorizationKey);
    }
    
    public static bool IsLoginPath(this PathString requestPath)
    {
        return requestPath.Equals(AuthenticationConstants.LoginPath, StringComparison.OrdinalIgnoreCase);
    }

    public static Guid? ExtractUserIdFromToken(this IHeaderDictionary headers)
    {
        var token = headers.ExtractToken();
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadJwtToken(token);
        var sub = jsonToken?.Claims.First(claim => claim.Type == AuthenticationConstants.SubClaimType).Value;

        return Guid.TryParse(sub, out var id) ? id : null;
    }
    
    private static string ExtractToken(this IHeaderDictionary headers)
    {
        var authHeader = headers[AuthenticationConstants.AuthorizationKey].ToString();
        return authHeader[AuthenticationConstants.BearerPrefix.Length..].Trim();
    }
}