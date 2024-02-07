using Dbops.Application.Events;
using MediatR;

namespace Dbops.Application.Notification.Query;

public sealed class QuerySubmittedNotificationHandler : INotificationHandler<QuerySubmittedEvent>
{
    public Task Handle(QuerySubmittedEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}