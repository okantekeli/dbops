using System.Security.Cryptography.X509Certificates;
using Dbops.Application.Commands.User;
using Dbops.Application.Data;
using Dbops.Application.Domain;
using Dbops.Application.Events;
using Dbops.Application.Handlers.User;
using Dbops.Application.Services;
using MediatR;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Moq;

namespace Dbops.ApplicationTest;

[TestClass]
public class UserTests
{
    private readonly DbContextOptions<DataContext> _contextOptions;

    public UserTests()
    {
        string id = string.Format("{0}.db", Guid.NewGuid().ToString());

        var builder = new SqliteConnectionStringBuilder()
        {
            DataSource = id,
            Mode = SqliteOpenMode.Memory,
            Cache = SqliteCacheMode.Shared
        };

        var connection = new SqliteConnection(builder.ConnectionString);
        _contextOptions = new DbContextOptionsBuilder<DataContext>()
        //.UseInMemoryDatabase("UserTests")
        .UseSqlite(connection).Options;

        using var context = new DataContext(_contextOptions);
        context.Database.OpenConnection();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        context.SaveChanges();
        
    }
    [TestMethod]
    public  void CreateUser()
    {
         
        using var context = new DataContext(_contextOptions);
        var publisher = new Mock<IPublisher>();
        var service = new UserService(context);
       
        UserCreateRequest request = new(){ Name="Unit", LastName= "Test", Email="unit@test.com", Password="StrongPasword"};
        CreateUserHandler handler = new CreateUserHandler(publisher.Object, service);
        
        //Act
        var response =  handler.Handle(request, new System.Threading.CancellationToken());
         
        Assert.AreNotEqual(false, response.Result.Status);

        request = new(){ Name="Unit", LastName= "Test", Email="unit@test.com", Password="StrongPasword"};
               
        Assert.ThrowsException<Microsoft.EntityFrameworkCore.DbUpdateException>(() => handler.Handle(request, new System.Threading.CancellationToken()));
    }

    [TestMethod]
    public void UpdateUser()
    {
        
    }
    
    
}