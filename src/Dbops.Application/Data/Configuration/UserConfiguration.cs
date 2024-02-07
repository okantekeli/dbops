using Dbops.Application.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dbops.Application.Data.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // map user 
        builder.ToTable("Users", "dbops").HasKey(p => p.UserId);
        builder.Property(x => x.UserId).HasColumnName("id").ValueGeneratedOnAdd();
        builder.Property(x => x.Email).HasColumnName("email").IsUnicode(false);
        builder.Property(x => x.Password).HasColumnName("password").IsUnicode(false);
        builder.Property(x => x.Name).HasColumnName("name").IsUnicode(false);
        builder.Property(x => x.LastName).HasColumnName("lastname").IsUnicode(false);

        // create unique index
        builder.HasIndex(x=> x.Email).IsUnique().HasDatabaseName("idx_user_unique_email");
    }
}
