using BaseUserManagement.Domain.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseUserManagement.Api.Abstractions;

[ApiController]
public abstract class ApiController : ControllerBase
{
    protected IActionResult HandleFailure(Result result)
    {
        if (result.IsSuccess)
        {
            throw new InvalidOperationException();
        }

        if (result is IValidationResult validationResult)
        {
            return BadRequest(CreateProblemDetails("Validation Error", StatusCodes.Status400BadRequest, result.Error, validationResult.Errors));
        }

        return BadRequest(CreateProblemDetails("Bad Request", StatusCodes.Status400BadRequest, result.Error));
    }

    private static ProblemDetails CreateProblemDetails(string title, int status, Error error, Error[]? errors = null) =>
        new()
        {
            Title = title,
            Type = error.Code,
            Detail = error.Message,
            Status = status,
            Extensions = { { nameof(errors), errors } }
        };
}
