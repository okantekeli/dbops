using Dbops.Application.Commands.User;
using Dbops.Application.Events;
using Dbops.Application.Services;
using MediatR;

namespace Dbops.Application.Handlers.User;

public class CreateUserHandler : IRequestHandler<UserCreateRequest, UserCreateResponse>
{
    private readonly IPublisher _publisher;
    private readonly UserService _userService;

    public CreateUserHandler(IPublisher publisher, UserService userService)
    {
        _publisher = publisher;
        _userService = userService;
    }

    public Task<UserCreateResponse> Handle(UserCreateRequest request, CancellationToken cancellationToken)
    {
        var user = _userService.Add(new Domain.User(){Name = request.Name, Email = request.Email, LastName = request.LastName, Password = request.Password});
        
        // user created 
        if (user.UserId> 0)
        {
             _publisher.Publish(new UserCreatedEvent(), cancellationToken);
             return Task.FromResult(new UserCreateResponse(){ Status=true});
        }
       return Task.FromResult(new UserCreateResponse(){ Status=false});
    
    }
}
