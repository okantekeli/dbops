using Dbops.Application.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dbops.Application.Data.Configuration;

public class QueryRequestConfiguration : IEntityTypeConfiguration<QueryRequest>
{
    public void Configure(EntityTypeBuilder<QueryRequest> builder)
    {
        // map user 
        builder.ToTable("QueryRequests", "dbops").HasKey(p => p.RequestId);
        builder.Property(x => x.RequestId).HasColumnName("id");
        builder.Property(x => x.Content).HasColumnName("content").IsUnicode(false);
    }
}
