using Japanese.Core.CommonModels;
using MediatR;

namespace Japanese.Services.Features.Sentence.Commands.CreateSentence;

public class CreateSentenceCommand : IRequest<ExecResult>
{
    public string? Text { get; set; }
    public string? Structure { get; set; }
    public int Jlpt { get; set; }
    public string? EnMeanings { get; set; }
    public string? ViMeanings { get; set; }
    public string? References { get; set; }
}
