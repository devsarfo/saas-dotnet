using System.Text.Json;

namespace SaaS.NET.Shared.Utils;

public static class JsonHelper
{
    public static string? SerializeDictionary(Dictionary<string, object>? dict)
        => dict == null ? null : JsonSerializer.Serialize(dict);

    public static Dictionary<string, object>? DeserializeDictionary(string? json)
        => json == null ? null : JsonSerializer.Deserialize<Dictionary<string, object>>(json)!;

    public static bool CompareDictionaries(Dictionary<string, object>? d1, Dictionary<string, object>? d2)
    {
        if (d1 == null && d2 == null) return true;
        if (d1 == null || d2 == null) return false;
        if (d1.Count != d2.Count) return false;

        foreach (var kv in d1)
        {
            if (!d2.TryGetValue(kv.Key, out var v)) return false;
            if (!Equals(kv.Value, v)) return false;
        }

        return true;
    }


    public static int GetDictionaryHashCode(Dictionary<string, object>? dict)
    {
        if (dict == null) return 0;

        var hash = 0;
        foreach (var kv in dict)
        {
            hash ^= kv.Key.GetHashCode();
            hash ^= kv.Value?.GetHashCode() ?? 0;
        }

        return hash;
    }

    public static Dictionary<string, object>? CloneDictionary(Dictionary<string, object>? dict) =>
        dict == null ? null : new Dictionary<string, object>(dict);
}