namespace Core.Models;

public class DatabaseConnection
{
    public required string DatabaseServer { get; set; }
    public required string Database { get; set; }
    public required string User { get; set; }
}
