using BaseUserManagement.Domain.Validations;
using MediatR;

namespace BaseUserManagement.Application.Abstractions.Messaging;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
