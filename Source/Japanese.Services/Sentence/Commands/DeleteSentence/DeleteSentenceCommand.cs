using khothemegiatot.WebApi.CQRS.Commands;
using khothemegiatot.WebApi.Models;
using MediatR;

namespace Japanese.Services.Sentence.Commands.DeleteSentence;

public class DeleteSentenceCommand : IRequest<ExecResult>, IDeleteCommand
{
    public string? SentenceId { get; set; }
    public bool ForceDelete { get; set; }
}