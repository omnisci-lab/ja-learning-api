using System.Text.Json.Serialization;

namespace Japanese.Core.Enum;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum VoiceOptions
{
    MaleVoiceSound, FemaleVoiceSound
}
