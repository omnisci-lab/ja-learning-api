using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.LanguageCore.SynthesizeSpeech;
using MediatR;

namespace Japanese.Services.Common.Queries.TextToSpeech;

public class TextToSpeechQueryHandler : IRequestHandler<TextToSpeechQuery, FileResult>
{
    private readonly PollyService _pollyService;

    public TextToSpeechQueryHandler(PollyService pollyService)
    {
        _pollyService = pollyService;
    }

    public async Task<FileResult> Handle(TextToSpeechQuery request, CancellationToken cancellationToken)
    {
        using MemoryStream memoryStream = await _pollyService.BasicSynthesizeSpeech(request.Text!, request.VoiceOptions);

        return new FileResult
        {
            Status = ExecStatus.Success,
            ContentType = "audio/mpeg",
            Data = memoryStream.ToArray(),
        };
    }
}
