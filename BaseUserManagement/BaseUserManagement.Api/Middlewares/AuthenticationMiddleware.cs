using BaseUserManagement.Api.Middlewares.Constants;
using BaseUserManagement.Api.Middlewares.Extensions;
using BaseUserManagement.Domain.Users.Repositories;
using BaseUserManagement.Domain.Users.Services;
using Microsoft.AspNetCore.Http;

namespace BaseUserManagement.Api.Middlewares;

public class AuthenticationMiddleware : IMiddleware 
{
    private readonly IUserContext _userContext;
    private readonly IUserRepository _userRepository;

    public AuthenticationMiddleware(IUserContext userContext, IUserRepository userRepository)
    {
        _userContext = userContext;
        _userRepository = userRepository;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.Request.Path.IsLoginPath())
        {
            await next(context);
        }
        else
        {
            var headers = context.Request.Headers;

            if (!headers.HasAuthorizationKey())
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync(AuthenticationConstants.UnauthorizedMissingTokenMessage);
                return;
            }

            var userId = headers.ExtractUserIdFromToken();
            
            if (userId is null)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(AuthenticationConstants.UnauthorizedInvalidTokenMessage);
            }
            else
            {
                var user = await _userRepository.GetUserByIdAsync(userId.Value, new CancellationToken());
                
                if (user is null)
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync(AuthenticationConstants.UnauthorizedInvalidTokenMessage);
                    return;
                }
                
                _userContext.SetUserId(userId.Value);
                await next(context);
            }
        }
    }
}