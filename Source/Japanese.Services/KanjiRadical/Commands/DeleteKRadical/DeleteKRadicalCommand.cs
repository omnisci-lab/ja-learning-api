using khothemegiatot.WebApi.CQRS.Commands;
using khothemegiatot.WebApi.Models;
using MediatR;

namespace Japanese.Services.KanjiRadical.Commands.DeleteKRadical;

public class DeleteKRadicalCommand : IRequest<ExecResult>, IDeleteCommand
{
    public bool ForceDelete { get; set; }

    public string? Character { get; set; }
}
