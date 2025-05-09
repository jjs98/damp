using System.Text.Json;
using Core.Models;
using YamlDotNet.Serialization;

namespace Core.Utilities;

public class ProjectUtility
{
    public static Project ConvertYamlToProject(string yaml)
    {
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(
                YamlDotNet.Serialization.NamingConventions.CamelCaseNamingConvention.Instance
            )
            .Build();
        return deserializer.Deserialize<Project>(yaml);
    }

    public static Project ConvertJsonToProject(string json)
    {
        return JsonSerializer.Deserialize<Project>(json)
            ?? throw new JsonException("Failed to deserialize JSON to Project object.");
    }
}
