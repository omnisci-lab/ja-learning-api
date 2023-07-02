using Japanese.Domain.Common;
using MediatR;

namespace Japanese.Services.Features.Sentence.Commands.CreateSentence;

public class CreateSentenceCommand : IRequest<ExecResult>
{
    public string? Text { get; set; }

    public string? EnMeanings { get; set; }

    public string? ViMeanings { get; set; }
}
