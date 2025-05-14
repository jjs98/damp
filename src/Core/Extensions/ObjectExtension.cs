using System.Text.Json;

namespace Core.Extensions;

public static class ObjectExtension
{
    public static T DeepCopy<T>(this T self)
    {
        var json = JsonSerializer.Serialize(self);
        return JsonSerializer.Deserialize<T>(json)!;
    }
}
