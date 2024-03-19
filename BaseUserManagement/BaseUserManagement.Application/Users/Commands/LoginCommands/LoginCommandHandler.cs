using BaseUserManagement.Application.Abstractions.Messaging;
using BaseUserManagement.Domain.Validations;

namespace BaseUserManagement.Application.Users.Commands.LoginCommands;

public class LoginCommandHandler : ICommandHandler<LoginCommand, string>
{
    public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}