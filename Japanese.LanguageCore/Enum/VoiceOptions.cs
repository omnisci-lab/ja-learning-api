using System.Text.Json.Serialization;

namespace Japanese.LanguageCore.Enum;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum VoiceOptions
{
    MaleVoiceSound, FemaleVoiceSound
}
