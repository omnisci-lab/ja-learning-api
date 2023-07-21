using Amazon.Polly;
using Amazon.Polly.Model;
using Amazon.Runtime;
using Japanese.LanguageCore.Enum;

namespace Japanese.LanguageCore.SynthesizeSpeech;

public class PollyService
{
    private AmazonPollyClient _pollyClient;

    public PollyService(BasicAWSCredentials basicAWSCredentials, AmazonPollyConfig pollyConfig)
    {
        _pollyClient = new AmazonPollyClient(basicAWSCredentials, pollyConfig);
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
}