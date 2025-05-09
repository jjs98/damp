using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configs;

public class HostedEnvironmentsConfig : IEntityTypeConfiguration<HostedEnvironment>
{
    public void Configure(EntityTypeBuilder<HostedEnvironment> builder)
    {
        builder.ToTable("HostedEnvironments");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).UseIdentityColumn();
        builder.Property(m => m.ProjectId).IsRequired();
        builder.Property(m => m.Url).IsRequired();
        builder.Property(m => m.Environment).IsRequired();
        builder.Property(m => m.Description).IsRequired(false);

        builder
            .HasOne<Project>()
            .WithMany(m => m.HostedEnvironments)
            .HasForeignKey(m => m.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
