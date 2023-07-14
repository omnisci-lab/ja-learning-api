using Japanese.Core.CommonModels;
using MediatR;

namespace Japanese.Services.Sentence.Commands.CreateSentence;

public class CreateSentenceCommand : IRequest<ExecResult>
{
    public string? Text { get; set; }
    public string? Structure { get; set; }
    public int Jlpt { get; set; }
    public string? EnMeaning { get; set; }
    public string? ViMeaning { get; set; }
    public string? References { get; set; }
}