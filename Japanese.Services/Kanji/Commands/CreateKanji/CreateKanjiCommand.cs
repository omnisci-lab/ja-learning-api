using Japanese.Core.CommonModels;
using MediatR;

namespace Japanese.Services.Kanji.Commands.CreateKanji;

public class CreateKanjiCommand : IRequest<ExecResult>
{
    public string? Kanji { get; set; }
    public int StrokeCount { get; set; }
    public int? Grade { get; set; }
    public List<string>? OnReadings { get; set; }
    public List<string>? KunReadings { get; set; }
    public List<string>? NameReadings { get; set; }
    public List<string>? EnMeanings { get; set; }
    public List<string>? SinoVietnamese { get; set; }
    public List<string>? ViMeanings { get; set; }
    public int? Jlpt { get; set; }
    public string? Unicode { get; set; }
}
