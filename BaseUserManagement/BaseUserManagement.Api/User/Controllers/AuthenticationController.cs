using BaseUserManagement.Api.Abstractions;
using BaseUserManagement.Application.Users.Commands.LoginCommands;
using BaseUserManagement.Application.Users.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BaseUserManagement.Api.User.Controllers;

[Route("api/user")]
public sealed class AuthenticationController : ApiController
{
    private readonly ISender _sender;

    public AuthenticationController(ISender sender)
    {
        _sender = sender;
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> LoginMember([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var command = new LoginCommand(request.UserName, request.Password);

        var tokenResult = await _sender.Send(command, cancellationToken);

        return tokenResult.IsFailure ? HandleFailure(tokenResult) : Ok(tokenResult.Value);
    }
}