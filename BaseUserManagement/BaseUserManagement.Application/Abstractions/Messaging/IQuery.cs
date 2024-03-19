using BaseUserManagement.Domain.Validations;
using MediatR;

namespace BaseUserManagement.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}