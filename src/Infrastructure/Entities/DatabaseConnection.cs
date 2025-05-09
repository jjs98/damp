namespace Infrastructure.Entities;

public class DatabaseConnection
{
    public DatabaseConnection() { }

    public DatabaseConnection(Core.Models.DatabaseConnection model)
    {
        DatabaseServer = model.DatabaseServer;
        Database = model.Database;
        User = model.User;
    }

    public int Id { get; set; } = 0;
    public int HostedEnvironmentId { get; set; } = 0;

    public string DatabaseServer { get; set; } = string.Empty;
    public string Database { get; set; } = string.Empty;
    public string User { get; set; } = string.Empty;

    public Core.Models.DatabaseConnection ToModel()
    {
        return new Core.Models.DatabaseConnection
        {
            DatabaseServer = DatabaseServer,
            Database = Database,
            User = User
        };
    }
}
