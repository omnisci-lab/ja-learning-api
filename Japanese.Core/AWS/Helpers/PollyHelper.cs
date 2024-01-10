using Amazon.Polly;
using Amazon.Polly.Model;
using Amazon.Runtime;
using Japanese.Core.Enum;

namespace Japanese.Core.AWS.Helpers;

public class PollyHelper : IDisposable
{
    private readonly IAmazonPolly _pollyClient;
    private bool disposedValue;

    internal PollyHelper(BasicAWSCredentials credentials, AmazonPollyConfig cofig)
    {
        _pollyClient = new AmazonPollyClient(credentials, cofig);
    }

    private async Task<MemoryStream> SynthesizeSpeech(string input, Engine engine, VoiceId voiceId, OutputFormat outputFormat)
    {
        SynthesizeSpeechRequest request = new SynthesizeSpeechRequest
        {
            Text = input,
            LanguageCode = "ja-JP",
            VoiceId = voiceId,
            OutputFormat = outputFormat,
            Engine = engine,
        };

        SynthesizeSpeechResponse response = await _pollyClient.SynthesizeSpeechAsync(request);

        MemoryStream memoryStream = new MemoryStream();
        response.AudioStream.CopyTo(memoryStream);

        return memoryStream;
    }

    public async Task<MemoryStream> BasicSynthesizeSpeech(string input, VoiceOptions voiceSoundOptions)
    {
        VoiceId? voiceId = null;
        if (voiceSoundOptions == VoiceOptions.MaleVoiceSound)
            voiceId = VoiceId.Takumi;
        else
            voiceId = VoiceId.Mizuki;

        return await SynthesizeSpeech(input, Engine.Standard, voiceId, OutputFormat.Mp3);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _pollyClient.Dispose();
            }

            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}