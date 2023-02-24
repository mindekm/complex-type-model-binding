namespace Shared;

using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

public sealed partial class ResourceUrl : IEquatable<ResourceUrl>
{
    private ResourceUrl(string server, string tenant, string identifier)
    {
        Server = server;
        Tenant = tenant;
        Identifier = identifier;
    }

    public static bool operator ==(ResourceUrl left, ResourceUrl right) => Equals(left, right);

    public static bool operator !=(ResourceUrl left, ResourceUrl right) => !Equals(left, right);

    public string Server { get; }

    public string Tenant { get; }

    public string Identifier { get; }

    public static bool TryParse(string? value, [MaybeNullWhen(false)] out ResourceUrl result)
    {
        if (value is null)
        {
            result = default;
            return false;
        }

        var match = Format().Match(value.Trim());
        if (match.Success)
        {
            result = new ResourceUrl(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value);
            return true;
        }

        result = default;
        return false;
    }
    
    public bool Equals(ResourceUrl? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return string.Equals(Server, other.Server, StringComparison.OrdinalIgnoreCase) &&
               string.Equals(Tenant, other.Tenant, StringComparison.Ordinal) &&
               string.Equals(Identifier, other.Identifier, StringComparison.Ordinal);
    }

    public override bool Equals(object? obj) => obj is ResourceUrl other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(Server, Tenant, Identifier);

    public override string ToString() => $"{Server}/{Tenant}/resource/{Identifier}";

    [GeneratedRegex(
        @"^(https://service.company.com)/(tenant[1-9])/resource/([\w-]{23})$",
        RegexOptions.Compiled)]
    private static partial Regex Format();
}