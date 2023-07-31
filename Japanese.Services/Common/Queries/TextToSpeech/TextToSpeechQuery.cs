using Japanese.Core.CommonModels;
using Japanese.LanguageCore.Enum;
using MediatR;

namespace Japanese.Services.Common.Queries.TextToSpeech;

public class TextToSpeechQuery : IRequest<FileResult>
{
    public string? Text { get; set; }
    public VoiceOptions VoiceOptions { get; set; }
}
