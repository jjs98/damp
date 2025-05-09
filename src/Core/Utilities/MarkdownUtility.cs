using System.Text;
using Core.Models;

namespace Core.Utilities;

public class MarkdownUtility
{
    public static string GenerateMarkdownFromProject(Project project)
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
