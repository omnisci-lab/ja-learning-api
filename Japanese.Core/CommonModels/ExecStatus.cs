using System.Text.Json.Serialization;

namespace Japanese.Core.CommonModels;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ExecStatus
{
    Success, NotFound, AlreadyExists, Invalid, Failed, Exception
}
