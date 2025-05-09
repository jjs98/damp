using Core.Interfaces.Services;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ProjectService(IDbContextFactory<AppDbContext> contextFactory) : IProjectService
{
    public async Task<List<Core.Models.Project>> GetProjectsAsync(
        CancellationToken cancellationToken
    )
    {
        await using var context = contextFactory.CreateDbContext();
        return await context
            .Projects.Include(project => project.HostedEnvironments)
            .ThenInclude(hostedEnvironment => hostedEnvironment.DatabaseConnections)
            .AsNoTracking()
            .Select(project => project.ToModel())
            .ToListAsync(cancellationToken);
    }

    public async Task AddProjectAsync(
        Core.Models.Project project,
        CancellationToken cancellationToken
    )
    {
        await using var context = contextFactory.CreateDbContext();
        context.Projects.Add(new Project(project));
        await context.SaveChangesAsync(cancellationToken);
    }
}
