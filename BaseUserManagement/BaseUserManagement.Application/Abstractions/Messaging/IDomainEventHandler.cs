using BaseUserManagement.Domain.Primitives;
using MediatR;

namespace BaseUserManagement.Application.Abstractions.Messaging;

public interface IDomainEventHandler<in TEvent> : INotificationHandler<TEvent>
    where TEvent : IDomainEvent, INotification
{
}
