using System.Text;
using FastEndpoints;

namespace DAMP.WebApi.Endpoints;

public class UploadProjectEndpoint : Endpoint<Project, string>
{
    public override void Configure()
    {
        Post("/projects/upload");
        AllowAnonymous();
        Description(x =>
            x.WithSummary("Upload a project")
                .Accepts<Project>("application/json")
                .Produces<string>(StatusCodes.Status200OK, contentType: "plain/text")
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status500InternalServerError)
        );
    }

    public override async Task HandleAsync(Project project, CancellationToken ct)
    {
        var markdown = GenerateMarkdownFromProject(project);

        await SendStringAsync(markdown, cancellation: ct);
    }

    private string GenerateMarkdownFromProject(Project project)
    {
        var projectMarkdown = new StringBuilder();

        projectMarkdown.AppendLine($"# {project.Name}");

        projectMarkdown.AppendLine("1. [Description](#description)");
        projectMarkdown.AppendLine("2. [Hosted Environments](#hosted-environments)");
        foreach (var environment in project.HostedEnvironments)
        {
            projectMarkdown.AppendLine(
                $"    - [{environment.Environment}](#{environment.Environment.ToLower().Replace(" ", "")})"
            );
        }
        projectMarkdown.AppendLine("3. [Dependencies](#dependencies)");
        projectMarkdown.AppendLine("4. [Tags](#tags)");

        projectMarkdown.AppendLine(
            $"## <div name=\"description\" /> Description\n{project.Description}"
        );
        projectMarkdown.AppendLine("## <div name=\"hosted-environments\" /> Hosted Environments");
        foreach (var environment in project.HostedEnvironments)
        {
            projectMarkdown.AppendLine(
                $"### <div name=\"{environment.Environment.ToLower().Replace(" ", "")}\" /> {environment.Environment}\n{environment.Url}\n\n{environment.Description}"
            );
            projectMarkdown.AppendLine("#### Database Connections");
            foreach (var connection in environment.DatabaseConnections)
            {
                projectMarkdown.AppendLine($"- Server: {connection.DatabaseServer}");
                projectMarkdown.AppendLine($"- Database: {connection.Database}");
                projectMarkdown.AppendLine($"- User: {connection.User}");
            }
        }
        projectMarkdown.AppendLine(
            $"## <div name=\"dependencies\" /> Dependencies\n{string.Join(", ", project.Dependencies)}"
        );
        projectMarkdown.AppendLine(
            $"## <div name=\"tags\" /> Tags\n{string.Join(", ", project.Tags)}"
        );

        return projectMarkdown.ToString();
    }
}

public class Project
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public IEnumerable<HostedEnvironment> HostedEnvironments { get; set; } = [];
    public IEnumerable<string> Tags { get; set; } = [];
    public IEnumerable<string> Dependencies { get; set; } = [];
}

public class HostedEnvironment
{
    public required string Url { get; set; }
    public required string Environment { get; set; }
    public string? Description { get; set; }
    public IEnumerable<DatabaseConnection> DatabaseConnections { get; set; } = [];
}

public class DatabaseConnection
{
    public required string DatabaseServer { get; set; }
    public required string Database { get; set; }
    public required string User { get; set; }
}
