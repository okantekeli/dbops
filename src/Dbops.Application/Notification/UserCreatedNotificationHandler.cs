using Dbops.Application.Events;
using MediatR;

namespace Dbops.Application.Notification.Query;

public sealed class UserCreatedNotificationHandler : INotificationHandler<UserCreatedEvent>
{
    public Task Handle(UserCreatedEvent userCreated, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}