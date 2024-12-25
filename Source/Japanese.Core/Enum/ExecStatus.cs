using System.Text.Json.Serialization;

namespace Japanese.Core.Enum;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ExecStatus
{
    Success, NotFound, AlreadyExists, Invalid, Failed, Exception
}
