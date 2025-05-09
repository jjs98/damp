namespace Core.Models;

public class HostedEnvironment
{
    public required string Url { get; set; }
    public required string Environment { get; set; }
    public string? Description { get; set; }
    public IEnumerable<DatabaseConnection> DatabaseConnections { get; set; } = [];
}
