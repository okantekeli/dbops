using Dbops.Application.Data;
using Dbops.Application.Domain;

namespace Dbops.Application.Services;

public class UserService
{
    private readonly DataContext _dataContext;
    public UserService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public User Add(User user)
    {
        _dataContext.Add(user);
        _dataContext.SaveChanges();
        return user;
    }

    public User? Get(string email)
    {
        var x = _dataContext.Users.SingleOrDefault(f=> f.Email == email);
        return x;
    }

    public User? Get(int id)
    {
        var user = _dataContext.Users.SingleOrDefault(f=> f.UserId == id);
        return user;
    }
}
