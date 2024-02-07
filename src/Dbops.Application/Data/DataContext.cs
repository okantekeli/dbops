using System.Reflection;
using Dbops.Application.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Dbops.Application.Data;
public class DataContext: DbContext
{
    private readonly IConfiguration _configuration;
    
    public DataContext(DbContextOptions options) : base(options)
    {
       
    }

    public DbSet<User> Users { get; set; }
    public DbSet<QueryRequest> QueryRequests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//register all configuration on this assembly
        base.OnModelCreating(modelBuilder);
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseNpgUssql(_configuration["DbConn"]);
        base.OnConfiguring(optionsBuilder);
    }
}