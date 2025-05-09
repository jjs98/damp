namespace Core.Models;

public class Project
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public IEnumerable<HostedEnvironment> HostedEnvironments { get; set; } = [];
    public IEnumerable<string> Tags { get; set; } = [];
    public IEnumerable<int> Dependencies { get; set; } = [];
}
