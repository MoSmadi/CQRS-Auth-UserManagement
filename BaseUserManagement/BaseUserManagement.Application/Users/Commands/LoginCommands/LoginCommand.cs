using BaseUserManagement.Application.Abstractions.Messaging;

namespace BaseUserManagement.Application.Users.Commands.LoginCommands;

public record LoginCommand(string UserName, string Password) : ICommand<string>;