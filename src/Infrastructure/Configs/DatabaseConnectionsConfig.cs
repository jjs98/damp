using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configs;

public class DatabaseConnectionsConfig : IEntityTypeConfiguration<DatabaseConnection>
{
    public void Configure(EntityTypeBuilder<DatabaseConnection> builder)
    {
        builder.ToTable("DatabaseConnections");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).UseIdentityColumn();
        builder.Property(m => m.HostedEnvironmentId).IsRequired();
        builder.Property(m => m.DatabaseServer).IsRequired();
        builder.Property(m => m.Database).IsRequired();
        builder.Property(m => m.User).IsRequired();

        builder
            .HasOne<HostedEnvironment>()
            .WithMany(m => m.DatabaseConnections)
            .HasForeignKey(m => m.HostedEnvironmentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
