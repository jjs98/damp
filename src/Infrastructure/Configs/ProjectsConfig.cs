using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configs;

public class ProjectsConfig : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("Projects");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).UseIdentityColumn();
        builder.Property(m => m.Name).IsRequired();
        builder.Property(m => m.Description).IsRequired(false);
        builder.PrimitiveCollection(m => m.Tags).IsRequired();
        builder.PrimitiveCollection(m => m.Dependencies).IsRequired();
    }
}
