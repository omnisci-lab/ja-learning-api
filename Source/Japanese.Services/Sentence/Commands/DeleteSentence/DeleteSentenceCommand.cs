using Japanese.Core.CommonModels;
using MediatR;

namespace Japanese.Services.Sentence.Commands.DeleteSentence;

public class DeleteSentenceCommand : IRequest<ExecResult>
{
    public string? SentenceId { get; set; }
    public bool ForceDelete { get; set; }
}