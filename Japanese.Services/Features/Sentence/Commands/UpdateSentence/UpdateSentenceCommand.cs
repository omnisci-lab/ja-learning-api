using Japanese.Domain.Common;
using MediatR;

namespace Japanese.Services.Features.Sentence.Commands.UpdateSentence;

public class UpdateSentenceCommand : IRequest<ExecResult>
{
    public string? SentenceId { get; set; }

    public string? Text { get; set; }

    public string? EnMeanings { get; set; }

    public string? ViMeanings { get; set; }
}
