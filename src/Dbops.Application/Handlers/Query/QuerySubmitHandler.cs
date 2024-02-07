using Dbops.Application.Commands.Query;
using Dbops.Application.Events;
using MediatR;

namespace Dbops.Application.Handlers.Query;

public class QuerySubmitHandler : IRequestHandler<QuerySubmitRequest, QuerySubmitResponse>
{
    private readonly IPublisher _publisher;

    public QuerySubmitHandler(IPublisher publisher)
    {
        _publisher = publisher;
    }

    public Task<QuerySubmitResponse> Handle(QuerySubmitRequest request, CancellationToken cancellationToken)
    {
        QuerySubmitResponse querySubmitResponse = new();
        _publisher.Publish(new QuerySubmittedEvent(), cancellationToken);
        
        return Task.FromResult(querySubmitResponse);
    }
}