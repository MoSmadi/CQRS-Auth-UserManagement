using BaseUserManagement.Application.Abstractions.Messaging;
using BaseUserManagement.Application.Users.Models.Responses;

namespace BaseUserManagement.Application.Users.Commands.LoginCommands;

public record LoginCommand(string UserName, string Password) : ICommand<LoginResponse>;