using System.Text.Json.Serialization;

namespace Japanese.Domain.Common;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ExecStatus
{
    Success, NotFound, AlreadyExists, Invalid, Failed, Exception
}
