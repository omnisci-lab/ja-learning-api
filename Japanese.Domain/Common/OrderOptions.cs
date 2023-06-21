using System.Text.Json.Serialization;

namespace Japanese.Domain.Common;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OrderOptions
{
    ASC, DESC
}