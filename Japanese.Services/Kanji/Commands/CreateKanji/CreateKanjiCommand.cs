using Japanese.Core.CommonModels;
using MediatR;

namespace Japanese.Services.Kanji.Commands.CreateKanji;

public class CreateKanjiCommand : IRequest<ExecResult>
{
    public string? Kanji { get; set; }
    public List<string>? OnReadings { get; set; }
    public List<string>? KunReadings { get; set; }
    public List<string>? NameReadings { get; set; }
}
