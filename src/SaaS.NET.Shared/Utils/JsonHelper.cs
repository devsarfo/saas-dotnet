using System.Text.Json;

namespace SaaS.NET.Shared.Utils;

public static class JsonHelper
{
    public static string? SerializeDictionary(Dictionary<string, object>? dict)
        => dict == null ? null : JsonSerializer.Serialize(dict);

    public static Dictionary<string, object>? DeserializeDictionary(string? json)
        => json == null ? null : JsonSerializer.Deserialize<Dictionary<string, object>>(json)!;
}