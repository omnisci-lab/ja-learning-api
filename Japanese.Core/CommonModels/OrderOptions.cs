using System.Text.Json.Serialization;

namespace Japanese.Core.CommonModels;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OrderOptions
{
    ASC, DESC
}