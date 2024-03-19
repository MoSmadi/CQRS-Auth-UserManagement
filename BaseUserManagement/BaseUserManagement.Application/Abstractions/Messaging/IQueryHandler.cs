using BaseUserManagement.Domain.Validations;
using MediatR;

namespace BaseUserManagement.Application.Abstractions.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}