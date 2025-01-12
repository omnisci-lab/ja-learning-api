using khothemegiatot.WebApi.CQRS.Commands;
using khothemegiatot.WebApi.Models;
using MediatR;

namespace Japanese.Services.Kana.Commands.DeleteKana;

public class DeleteKanaCommand : IRequest<ExecResult>, IDeleteCommand
{
    public bool ForceDelete { get; set; }

    public string? Character { get; set; }
}