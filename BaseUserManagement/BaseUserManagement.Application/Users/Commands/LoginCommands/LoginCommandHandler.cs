using BaseUserManagement.Application.Abstractions.Messaging;
using BaseUserManagement.Application.Users.Models.Responses;
using BaseUserManagement.Domain.Authentication;
using BaseUserManagement.Domain.Users.Services;
using BaseUserManagement.Domain.Validations;

namespace BaseUserManagement.Application.Users.Commands.LoginCommands;

public class LoginCommandHandler : ICommandHandler<LoginCommand, LoginResponse>
{
    private readonly IUserService _userService;
    private readonly IJwtProvider _jwtProvider;

    public LoginCommandHandler(IUserService userService, IJwtProvider jwtProvider)
    {
        _userService = userService;
        _jwtProvider = jwtProvider;
    }

    public async Task<Result<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var userResult = await _userService.ValidateLoginCredentialsAsync(request.UserName, request.Password, cancellationToken);

        if (userResult.IsFailure)
        {
            return Result.Failure<LoginResponse>(userResult.Error);
        }
        
        var token = _jwtProvider.GenerateJwtToken(userResult.Value);
        
        return Result.Success(new LoginResponse(token));
    }
}