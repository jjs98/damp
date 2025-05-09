using Infrastructure.Configs;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Project> Projects { get; set; }
    public DbSet<HostedEnvironment> HostedEnvironments { get; set; }
    public DbSet<DatabaseConnection> DatabaseConnections { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfiguration(new ProjectsConfig())
            .ApplyConfiguration(new HostedEnvironmentsConfig())
            .ApplyConfiguration(new DatabaseConnectionsConfig());
    }
}
