using MediatR;

namespace Dbops.Application.Commands.User;

public class UserCreateRequest : IRequest<UserCreateResponse>
{
    public string Email {get;set;} = string.Empty;
    public string Name {get;set;} = string.Empty;

    public string LastName {get;set;} = string.Empty;
    public string Password {get;set;} = string.Empty;
}
