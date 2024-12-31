using Japanese.Core.CommonModels;
using Japanese.Core.CQRS.Commands;
using MediatR;

namespace Japanese.Services.Kanji.Commands.DeleteKanji;

public class DeleteKanjiCommand : IRequest<ExecResult>, IDeleteCommand
{
    public string? Character { get; set; }
    public bool ForceDelete { get; set; }
}