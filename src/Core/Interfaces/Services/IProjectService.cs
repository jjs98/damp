using Core.Models;

namespace Core.Interfaces.Services;

public interface IProjectService
{
    Task<List<Project>> GetProjectsAsync(CancellationToken cancellationToken);
    Task AddProjectAsync(Project project, CancellationToken cancellationToken);
}
