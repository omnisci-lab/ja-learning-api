using Japanese.Domain.Common;
using MediatR;

namespace Japanese.Services.Features.Sentence.Command.UpdateSentence;

public class UpdateSentenceCommand : IRequest<ExecResult>
{
    public string? SentenceId { get; set; }
}
