using Amazon.Polly;
using Amazon.Polly.Model;
using Amazon.Runtime;

namespace Japanese.LanguageCore.SynthesizeSpeech;

public class PollyService
{
    private AmazonPollyClient _pollyClient;

    public PollyService(BasicAWSCredentials basicAWSCredentials, AmazonPollyConfig pollyConfig) {
        _pollyClient = new AmazonPollyClient(basicAWSCredentials, pollyConfig);
    }

    public async Task<MemoryStream> SynthesizeSpeech(string input)
    {
        SynthesizeSpeechRequest request = new SynthesizeSpeechRequest
        {
            Text = input,
            LanguageCode = "ja-JP",
            VoiceId = VoiceId.Takumi, 
            OutputFormat = OutputFormat.Mp3
        };

        SynthesizeSpeechResponse response = await _pollyClient.SynthesizeSpeechAsync(request);

        MemoryStream memoryStream = new MemoryStream();
        response.AudioStream.CopyTo(memoryStream);
        return memoryStream;
    }
}
