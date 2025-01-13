using khothemegiatot.WebApi.Models;
using MediatR;

namespace Japanese.Services.KanjiRadical.Commands.CreateAndUpdateKRadical;

public class CreateAndUpdateKRadicalCommand : IRequest<ExecResult>
{
    public bool IsUpdate { get; set; }

    public string? Character { get; set; }
}
