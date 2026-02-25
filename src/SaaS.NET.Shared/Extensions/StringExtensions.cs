using System.Globalization;
using System.Text.RegularExpressions;

namespace SaaS.NET.Shared.Extensions;

public static class StringExtensions
{
    public static string CapitaliseFirst(this string? value)
    {
        if (string.IsNullOrEmpty(value)) return value!;
        return char.ToUpper(value[0]) + value[1..];
    }

    public static string ToTitleCase(this string? value)
    {
        if (string.IsNullOrEmpty(value)) return value!;

        var cultureInfo = CultureInfo.CurrentCulture;
        return cultureInfo.TextInfo.ToTitleCase(value.ToLower());
    }
    
    public static string ToSnakeCase(this string? value)
    {
        if (string.IsNullOrEmpty(value)) return value!;

        var result = Regex.Replace(value, @"([a-z0-9])([A-Z])", "$1_$2");
        result = Regex.Replace(result, @"([A-Z]+)([A-Z][a-z])", "$1_$2");
        result = Regex.Replace(result, @"[\s\-]+", "_");
        return result.ToLowerInvariant();
    }
}