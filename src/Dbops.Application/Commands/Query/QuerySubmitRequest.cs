
using MediatR;

namespace Dbops.Application.Commands.Query;

public class QuerySubmitRequest : IRequest<QuerySubmitResponse>
{
    public string Content {get;set;} = string.Empty;
    public string Token {get;set;} = string.Empty;
    public string ConnectionId {get;set;} = string.Empty;
}