using Japanese.Core.CommonModels;
using MediatR;

namespace Japanese.Services.KanjiRadical.Commands.DeleteKRadical;

public class DeleteKRadicalCommand : IRequest<ExecResult>
{
    public bool ForceDelete { get; set; }

    public string? Character { get; set; }
}
