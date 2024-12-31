using Japanese.Core.CommonModels;
using Japanese.Core.CQRS.Commands;
using MediatR;

namespace Japanese.Services.KanjiRadical.Commands.DeleteKRadical;

public class DeleteKRadicalCommand : IRequest<ExecResult>, IDeleteCommand
{
    public bool ForceDelete { get; set; }

    public string? Character { get; set; }
}
