using Japanese.Domain.Common;
using MediatR;

namespace Japanese.Services.Features.Kanji.Commands.UpdateKanji;

public class UpdateKanjiCommand : IRequest<ExecResult>
{
    public string? Kanji { get; set; }
    public List<string>? OnReadings { get; set; }
    public List<string>? KunReadings { get; set; }
    public List<string>? NameReadings { get; set; }
}