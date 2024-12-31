using Japanese.Core.CommonModels;
using Japanese.Core.CQRS.Commands;
using MediatR;

namespace Japanese.Services.Kana.Commands.DeleteKana;

public class DeleteKanaCommand : IRequest<ExecResult>, IDeleteCommand
{
    public bool ForceDelete { get; set; }

    public string? Character { get; set; }
}