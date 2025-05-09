namespace Infrastructure.Entities;

public class HostedEnvironment
{
    public HostedEnvironment() { }

    public HostedEnvironment(Core.Models.HostedEnvironment model)
    {
        Url = model.Url;
        Environment = model.Environment;
        Description = model.Description;
        DatabaseConnections = [.. model.DatabaseConnections.Select(x => new DatabaseConnection(x))];
    }

    public int Id { get; set; } = 0;
    public int ProjectId { get; set; } = 0;

    public string Url { get; set; } = string.Empty;
    public string Environment { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ICollection<DatabaseConnection> DatabaseConnections { get; set; } = [];

    public Core.Models.HostedEnvironment ToModel()
    {
        return new Core.Models.HostedEnvironment
        {
            Url = Url,
            Environment = Environment,
            Description = Description,
            DatabaseConnections = [.. DatabaseConnections.Select(x => x.ToModel())]
        };
    }
}
