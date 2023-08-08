using Japanese.LanguageCore.Enum;

namespace Japanese.LanguageCore.AWS.Polly;

public interface IPollyHelper : IDisposable
{
    Task<MemoryStream> BasicSynthesizeSpeech(string input, VoiceOptions voiceSoundOptions);
}