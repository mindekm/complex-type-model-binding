namespace Shared;

using System.Text.Json;
using System.Text.Json.Serialization;

public sealed class ResourceUrlJsonConverter : JsonConverter<ResourceUrl>
{
    public override ResourceUrl Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return ResourceUrl.TryParse(reader.GetString(), out var result)
            ? result
            : throw new JsonException();
    }

    public override void Write(Utf8JsonWriter writer, ResourceUrl value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}