using BaseUserManagement.Domain.Validations;
using MediatR;

namespace BaseUserManagement.Application.Abstractions.Messaging;

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
{
}
