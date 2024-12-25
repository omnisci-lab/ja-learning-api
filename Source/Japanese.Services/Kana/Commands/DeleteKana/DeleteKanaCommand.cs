using Japanese.Core.CommonModels;
using MediatR;

namespace Japanese.Services.Kana.Commands.DeleteKana;

public class DeleteKanaCommand : IRequest<ExecResult>
{
    public bool ForceDelete { get; set; }

    public string? Character { get; set; }
}