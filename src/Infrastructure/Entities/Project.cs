namespace Infrastructure.Entities;

public class Project
{
    public Project() { }

    public Project(Core.Models.Project model)
    {
        Name = model.Name;
        Description = model.Description;
        Tags = [.. model.Tags];
        Dependencies = [.. model.Dependencies];
        HostedEnvironments = [.. model.HostedEnvironments.Select(x => new HostedEnvironment(x))];
    }

    public int Id { get; set; } = 0;

    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ICollection<HostedEnvironment> HostedEnvironments { get; set; } = [];
    public ICollection<string> Tags { get; set; } = [];
    public ICollection<int> Dependencies { get; set; } = [];

    public Core.Models.Project ToModel()
    {
        return new Core.Models.Project
        {
            Name = Name,
            Description = Description,
            Tags = [.. Tags],
            Dependencies = [.. Dependencies],
            HostedEnvironments = [.. HostedEnvironments.Select(x => x.ToModel())]
        };
    }
}
