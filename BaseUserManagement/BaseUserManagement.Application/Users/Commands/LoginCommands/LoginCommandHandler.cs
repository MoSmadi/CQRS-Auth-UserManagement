using BaseUserManagement.Application.Abstractions.Messaging;
using BaseUserManagement.Application.Users.Models.Responses;
using BaseUserManagement.Domain.Validations;

namespace BaseUserManagement.Application.Users.Commands.LoginCommands;

public class LoginCommandHandler : ICommandHandler<LoginCommand, LoginResponse>
{
    public async Task<Result<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var response = new LoginResponse("token");
        return Result.Success(response);
    }
}