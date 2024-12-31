using Japanese.Core.CommonModels;
using Japanese.Core.CQRS.Commands;
using MediatR;

namespace Japanese.Services.Sentence.Commands.DeleteSentence;

public class DeleteSentenceCommand : IRequest<ExecResult>, IDeleteCommand
{
    public string? SentenceId { get; set; }
    public bool ForceDelete { get; set; }
}