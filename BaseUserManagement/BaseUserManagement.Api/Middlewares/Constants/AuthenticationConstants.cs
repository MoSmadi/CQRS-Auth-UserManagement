namespace BaseUserManagement.Api.Middlewares.Constants;

public static class AuthenticationConstants
{
    public const string AuthorizationKey = "Authorization";
    public const string UnauthorizedMissingTokenMessage = "Unauthorized - Missing token";
    public const string UnauthorizedInvalidTokenMessage = "Unauthorized - Invalid token";
    public const string BearerPrefix = "Bearer ";
    public const string LoginPath = "/api/user/login";
    public const string SubClaimType = "sub";
}