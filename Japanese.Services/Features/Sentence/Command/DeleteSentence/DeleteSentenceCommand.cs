using Japanese.Domain.Common;
using MediatR;

namespace Japanese.Services.Features.Sentence.Command.DeleteSentence;

public class DeleteSentenceCommand : IRequest<ExecResult>
{
    public string? SentenceId { get; set; }
}
